using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form1 : Form
    {
        // Animación y partículas
        private float hue = 0f;
        private readonly Random rnd = new Random();
        private readonly List<Particle> particles = new List<Particle>();
        private Point mousePos = Point.Empty;

        // Síntesis/otros (no usamos TTS ahora)
        // Control de intro
        private int introStep = 0;

        // Back buffer para evitar parpadeo
        private Bitmap backBuffer;

        private struct Particle
        {
            public float X, Y;
            public float VX, VY;
            public float Size;
            public float Alpha;
            public float HueOffset;
        }

        public Form1()
        {
            InitializeComponent();

            // Mejor renderizado general
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            this.DoubleBuffered = true;

            // Habilitar DoubleBuffered en el panel (propiedad protegida)
            try
            {
                typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                    .SetValue(mainPanel, true, null);
            }
            catch
            {
                // Ignorar si no se puede
            }

            // Ocultamos las etiquetas reales (dibujamos nosotros)
            lblTitle.Visible = false;
            lblSubtitle.Visible = false;

            // Establecer textos: ahora el subtítulo es único y no repite el título
            lblTitle.Text = "Bienvenido a nuestra calculadora";
            lblSubtitle.Text = "Calculadora interactiva de métodos numéricos — integra, resuelve y visualiza";

            // Inicializa partículas
            for (int i = 0; i < 40; i++)
                particles.Add(CreateParticle(true));

            // Ocultar el progress bar de inicio (ya no se muestra)
            try
            {
                progressBar.Visible = false;
            }
            catch { /* si no existe, no pasa nada */ }

            // Registrar cierre para liberar recursos
            this.FormClosing += Form1_FormClosing;

            // Inicia animaciones (sin sonido)
            animationTimer.Start();
            introTimer.Start();
        }

        // Manejador Load (seguro si el diseñador lo referencia)
        private void Form1_Load(object sender, EventArgs e)
        {
            if (backBuffer != null)
            {
                backBuffer.Dispose();
                backBuffer = null;
            }
            mainPanel.Invalidate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            animationTimer.Stop();
            introTimer.Stop();
            if (backBuffer != null)
            {
                backBuffer.Dispose();
                backBuffer = null;
            }
        }

        private Particle CreateParticle(bool randomPos = false)
        {
            var p = new Particle();
            int w = mainPanel.Width > 0 ? mainPanel.Width : 1000;
            int h = mainPanel.Height > 0 ? mainPanel.Height : 600;
            p.X = randomPos ? rnd.Next(0, w) : w / 2f;
            p.Y = randomPos ? rnd.Next(0, h) : h / 2f;
            p.VX = (float)(rnd.NextDouble() * 2 - 1) * 0.6f;
            p.VY = (float)(rnd.NextDouble() * 2 - 1) * 0.6f;
            p.Size = (float)(rnd.NextDouble() * 40 + 10);
            p.Alpha = (float)(rnd.NextDouble() * 0.6 + 0.2);
            p.HueOffset = (float)rnd.NextDouble() * 60f;
            return p;
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            // Actualiza hue para el degradado
            hue += 0.15f;
            if (hue > 360f) hue -= 360f;

            // Actualiza partículas
            int w = mainPanel.Width;
            int h = mainPanel.Height;
            for (int i = 0; i < particles.Count; i++)
            {
                var p = particles[i];
                // interacción con el mouse
                float dx = (mousePos.X - p.X);
                float dy = (mousePos.Y - p.Y);
                float dist = (float)Math.Sqrt(dx * dx + dy * dy);
                if (dist < 200 && dist > 0)
                {
                    float force = (200 - dist) / 200f;
                    p.VX -= dx / dist * 0.3f * force;
                    p.VY -= dy / dist * 0.3f * force;
                }

                p.X += p.VX;
                p.Y += p.VY;

                // fricción y reposo
                p.VX *= 0.995f;
                p.VY *= 0.995f;
                if (p.X < -50 || p.X > w + 50 || p.Y < -50 || p.Y > h + 50)
                {
                    p = CreateParticle(true);
                    if (mousePos != Point.Empty)
                    {
                        p.X = mousePos.X + rnd.Next(-80, 80);
                        p.Y = mousePos.Y + rnd.Next(-80, 80);
                    }
                }
                particles[i] = p;
            }

            // Si quieres mantener la barra interna, podríamos actualizarla aunque esté oculta.
            if (introStep > 0 && introStep <= 100)
            {
                try { progressBar.Value = Math.Min(100, progressBar.Value + 1); } catch { }
            }

            // Invalidar solo el panel (se repinta usando backBuffer en Paint)
            mainPanel.Invalidate();
        }

        // Nuevo: manejar movimiento del ratón para interacción con partículas
        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos = e.Location;
        }

        // Nuevo: manejador del timer de intro (mantiene compatibilidad con el diseñador)
        private void introTimer_Tick(object sender, EventArgs e)
        {
            introStep++;
            if (introStep == 1)
            {
                for (int i = 0; i < 6; i++) particles.Add(CreateParticle(true));
            }
            if (introStep > 120)
            {
                try { introTimer.Stop(); } catch { }
                try { progressBar.Value = 100; } catch { }
            }
        }

        // Botón Entrar: mostrar LoadingForm y abrir Form2
        private void btnStart_Click(object sender, EventArgs e)
        {
            try { animationTimer.Stop(); } catch { }

            // Mostrar ventana de carga modal con barra de progreso (~3000 ms)
            try
            {
                using (var loading = new LoadingForm(3000))
                {
                    loading.ShowDialog(this);
                }
            }
            catch
            {
                // si LoadingForm no existe o falla, continuar abriendo Form2
            }

            try
            {
                var menu = new Form2();
                menu.StartPosition = FormStartPosition.CenterScreen;
                // Cuando el menú se cierre, cerramos definitivamente la bienvenida
                menu.FormClosed += (s, args) => { try { this.Close(); } catch { } };
                menu.Show();
                this.Hide();
            }
            catch
            {
                // si algo falla al abrir Form2, volver a arrancar animación
                try { animationTimer.Start(); } catch { }
            }
        }

        // Botón Salir
        private void btnExit_Click(object sender, EventArgs e)
        {
            try { Application.Exit(); } catch { }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            int w = Math.Max(1, mainPanel.Width);
            int h = Math.Max(1, mainPanel.Height);

            // Crear/recrear backBuffer si cambia el tamaño
            if (backBuffer == null || backBuffer.Width != w || backBuffer.Height != h)
            {
                if (backBuffer != null) backBuffer.Dispose();
                backBuffer = new Bitmap(w, h, PixelFormat.Format32bppPArgb);
            }

            // Dibujamos todo en el backBuffer
            using (Graphics g = Graphics.FromImage(backBuffer))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                // Degradado dinámico basado en hue (tenue para menos parpadeo)
                Color c1 = ColorFromHSL(hue, 0.65f, 0.12f);
                Color c2 = ColorFromHSL((hue + 80f) % 360f, 0.65f, 0.03f);
                using (var lg = new LinearGradientBrush(new Rectangle(0, 0, w, h), c1, c2, LinearGradientMode.ForwardDiagonal))
                {
                    g.FillRectangle(lg, 0, 0, w, h);
                }

                // capa de textura sutil
                using (var texturePen = new Pen(Color.FromArgb(10, Color.White)))
                {
                    for (int i = 0; i < w; i += 80)
                        g.DrawLine(texturePen, i, 0, i - 40, h);
                }

                // partículas
                foreach (var p in particles)
                {
                    float size = p.Size;
                    float alpha = Math.Max(0.03f, p.Alpha);
                    Color baseColor = ColorFromHSL((hue + p.HueOffset) % 360f, 0.85f, 0.55f);
                    for (int k = 0; k < 3; k++)
                    {
                        int s = (int)(size * (1.0 - k * 0.28));
                        var rect = new RectangleF(p.X - s / 2f, p.Y - s / 2f, s, s);
                        var b = Color.FromArgb((int)(alpha * 255 / (k + 1)), baseColor);
                        using (var br = new SolidBrush(b))
                        {
                            g.FillEllipse(br, rect);
                        }
                    }
                }

                // logo vectorial
                DrawVectorLogo(g, new Rectangle(24, 24, 120, 120), hue);

                // texto principal (título)
                float titleY = h * 0.14f;
                DrawReflectiveText(g, lblTitle.Text, lblTitle.Font, hue, new PointF(w / 2f, titleY));

                // subtítulo: texto único y más vivo (misma paleta que el título)
                using (var f = new Font(lblSubtitle.Font.FontFamily, 14f, FontStyle.Bold))
                {
                    var subText = lblSubtitle.Text;
                    var subSize = g.MeasureString(subText, f);
                    var rect = new RectangleF((w - subSize.Width) / 2f, titleY + 70f, subSize.Width, subSize.Height);

                    // Usamos una paleta similar a la del título para mantener coherencia
                    Color sg1 = ColorFromHSL((hue + 180f) % 360f, 0.9f, 0.75f);
                    Color sg2 = ColorFromHSL((hue + 240f) % 360f, 0.9f, 0.65f);

                    using (var shadow = new SolidBrush(Color.FromArgb(220, Color.Black)))
                    {
                        g.DrawString(subText, f, shadow, rect.X + 2, rect.Y + 2); // sombra ligera
                    }

                    using (var sb = new LinearGradientBrush(rect, sg1, sg2, LinearGradientMode.Horizontal))
                    {
                        g.DrawString(subText, f, sb, rect.Location);
                    }
                }

                // glow para el botón (dibujo bajo el control real)
                DrawButtonGlow(g, btnStart.Bounds, hue);
            }

            // Pinta backBuffer en pantalla
            e.Graphics.DrawImageUnscaled(backBuffer, 0, 0);
        }

        private void DrawVectorLogo(Graphics g, Rectangle rect, float baseHue)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            Color outer = ColorFromHSL((baseHue + 10f) % 360f, 0.8f, 0.45f);

            using (var circlePath = new GraphicsPath())
            {
                circlePath.AddEllipse(rect);
                using (var pb = new PathGradientBrush(circlePath))
                {
                    pb.CenterColor = outer;
                    pb.SurroundColors = new[] { Color.FromArgb(0, outer) };
                    g.FillPath(pb, circlePath);
                }
            }

            using (var pen = new Pen(Color.White, 6) { EndCap = LineCap.Round, StartCap = LineCap.Round })
            {
                var path = new GraphicsPath();
                int lx = rect.X + rect.Width / 5;
                int rx = rect.Right - rect.Width / 5;
                int ty = rect.Y + rect.Height / 6;
                int by = rect.Bottom - rect.Height / 6;
                path.StartFigure();
                path.AddLine(lx, by, lx, ty);
                path.AddLine(lx, ty, rx, by);
                path.AddLine(rx, by, rx, ty);
                path.CloseFigure();
                g.DrawPath(pen, path);
            }
        }

        private void DrawReflectiveText(Graphics g, string text, Font font, float hueForText, PointF centerPos)
        {
            var size = g.MeasureString(text, font);
            float x = centerPos.X - size.Width / 2f;
            float y = centerPos.Y;

            // Sombra suave
            using (var shadowBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0)))
                g.DrawString(text, font, shadowBrush, x + 4f, y + 6f);

            // Glow exterior (capas)
            for (int i = 6; i >= 1; i--)
            {
                int alpha = Math.Max(8, 28 / i);
                var glowColor = ColorFromHSL((hueForText + 160f) % 360f, 0.9f, 0.55f);
                using (var glowBrush = new SolidBrush(Color.FromArgb(alpha, glowColor)))
                    g.DrawString(text, font, glowBrush, x - i * 0.6f, y - i * 0.6f);
            }

            // Texto principal con degradado
            var gradRect = new RectangleF(x, y, size.Width, size.Height);
            Color g1 = ColorFromHSL((hueForText + 180f) % 360f, 0.9f, 0.75f);
            Color g2 = ColorFromHSL((hueForText + 240f) % 360f, 0.9f, 0.65f);
            using (var lg = new LinearGradientBrush(gradRect, g1, g2, LinearGradientMode.Horizontal))
            {
                g.DrawString(text, font, lg, x, y);
            }
        }

        private void DrawButtonGlow(Graphics g, Rectangle rect, float hueBase)
        {
            Color glow = ColorFromHSL((hueBase + 220f) % 360f, 0.9f, 0.55f);
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(rect.Left - 8, rect.Top - 8, rect.Width + 16, rect.Height + 16);
                using (var pg = new PathGradientBrush(path))
                {
                    pg.CenterColor = Color.FromArgb(140, glow);
                    pg.SurroundColors = new[] { Color.FromArgb(0, glow) };
                    g.FillPath(pg, path);
                }
            }
        }

        // Conversión HSL -> Color
        private Color ColorFromHSL(float h, float s, float l)
        {
            h = (h % 360 + 360) % 360;
            s = Math.Max(0f, Math.Min(1f, s));
            l = Math.Max(0f, Math.Min(1f, l));
            double c = (1 - Math.Abs(2 * l - 1)) * s;
            double x = c * (1 - Math.Abs((h / 60.0) % 2 - 1));
            double m = l - c / 2;
            double r1 = 0, g1 = 0, b1 = 0;
            if (h < 60) { r1 = c; g1 = x; b1 = 0; }
            else if (h < 120) { r1 = x; g1 = c; b1 = 0; }
            else if (h < 180) { r1 = 0; g1 = c; b1 = x; }
            else if (h < 240) { r1 = 0; g1 = x; b1 = c; }
            else if (h < 300) { r1 = x; g1 = 0; b1 = c; }
            else { r1 = c; g1 = 0; b1 = x; }
            int r = (int)((r1 + m) * 255);
            int g = (int)((g1 + m) * 255);
            int b = (int)((b1 + m) * 255);
            return Color.FromArgb(r, g, b);
        }
    }

    // Extensión auxiliar mínima para crear Graphics desde Bitmap cuando sea necesario
    internal static class BitmapExtensions
    {
        public static Graphics GraphicsForImage(this Bitmap bmp)
        {
            var g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            return g;
        }
    }
}