using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form2 : Form
    {
        private Timer gifTimer;
        private Image prevAnimImage;
        private float animAngle = 0f;

        public Form2()
        {
            InitializeComponent();
            // Ajustes visuales adicionales
            this.BackColor = Color.FromArgb(18, 18, 22);

            // hacer label transparente y solo texto (sin "rectángulo")
            lblHeader.BackColor = Color.Transparent;
            lblHeader.AutoSize = true;
            lblHeader.Parent = mainPanel;
            lblHeader.BringToFront();

            StyleButtons();

            // Inicializar animación tipo "gif" (generada en tiempo de ejecución)
            gifTimer = new Timer();
            gifTimer.Interval = 40; // ~25 FPS
            gifTimer.Tick += GifTimer_Tick;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LayoutControls(); // centra botones y posición inicial del picAnim
            gifTimer.Start();
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            LayoutControls();
        }

        private void StyleButtons()
        {
            Color base1 = Color.FromArgb(34, 160, 255);
            Color base2 = Color.FromArgb(120, 90, 255);

            ConfigureButtonVisual(btnSystems, base1, base2);
            ConfigureButtonVisual(btnRoots, Color.FromArgb(255, 135, 80), Color.FromArgb(255, 95, 130));
            ConfigureButtonVisual(btnDerivation, Color.FromArgb(120, 255, 150), Color.FromArgb(40, 200, 160));
            ConfigureButtonVisual(btnIntegration, Color.FromArgb(200, 120, 255), Color.FromArgb(100, 60, 255));
        }

        private void ConfigureButtonVisual(Button b, Color c1, Color c2)
        {
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = c1;
            b.Tag = new Tuple<Color, Color>(c1, c2);
            b.MouseEnter += (s, e) =>
            {
                var t = (Tuple<Color, Color>)b.Tag;
                b.BackColor = t.Item2;
                b.Cursor = Cursors.Hand;
            };
            b.MouseLeave += (s, e) =>
            {
                var t = (Tuple<Color, Color>)b.Tag;
                b.BackColor = t.Item1;
                b.Cursor = Cursors.Default;
            };
        }

        private void LayoutControls()
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            // centrar header
            lblHeader.Left = (w - lblHeader.Width) / 2;
            lblHeader.Top = 16;

            // animación debajo del header
            int animW = Math.Min(420, Math.Max(240, this.ClientSize.Width / 3));
            int animH = (int)(animW * 0.5);
            picAnim.Size = new Size(animW, animH);
            picAnim.Left = (w - picAnim.Width) / 2;
            picAnim.Top = lblHeader.Bottom + 8;

            // botones en dos columnas centradas
            int btnW = btnSystems.Width;
            int btnH = btnSystems.Height;
            int gapX = 40;
            int totalWidth = btnW * 2 + gapX;
            int startX = (w - totalWidth) / 2;
            int startY = picAnim.Bottom + 16;

            btnSystems.Left = startX;
            btnSystems.Top = startY;

            btnRoots.Left = startX + btnW + gapX;
            btnRoots.Top = startY;

            btnDerivation.Left = startX;
            btnDerivation.Top = startY + btnH + 18;

            btnIntegration.Left = startX + btnW + gapX;
            btnIntegration.Top = startY + btnH + 18;

            btnBack.Left = w - btnBack.Width - 20;
            btnBack.Top = 14;

            mainPanel.Invalidate();
            picAnim.Invalidate();
        }

        private void GifTimer_Tick(object sender, EventArgs e)
        {
            animAngle += 4.5f;
            if (animAngle > 360f) animAngle -= 360f;

            int w = Math.Max(1, picAnim.Width);
            int h = Math.Max(1, picAnim.Height);
            var bmp = new Bitmap(w, h, PixelFormat.Format32bppPArgb);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                using (var lg = new LinearGradientBrush(new Rectangle(0, 0, w, h),
                    Color.FromArgb(12, Color.White), Color.FromArgb(8, Color.Black), LinearGradientMode.Vertical))
                {
                    g.FillRectangle(lg, 0, 0, w, h);
                }

                var center = new PointF(w / 2f, h / 2f);
                float maxR = Math.Min(w, h) * 0.45f;

                for (int ring = 0; ring < 4; ring++)
                {
                    float r = maxR * (0.25f + ring * 0.18f);
                    float thickness = 6f + ring * 3f;
                    float angleOffset = animAngle * (1 + ring * 0.4f) + ring * 30f;
                    Color col = ColorFromHSL((angleOffset + ring * 40) % 360, 0.85f, 0.55f);
                    using (var pen = new Pen(col, thickness))
                    {
                        pen.EndCap = LineCap.Round;
                        pen.StartCap = LineCap.Round;
                        var rect = new RectangleF(center.X - r, center.Y - r, r * 2, r * 2);
                        g.DrawArc(pen, rect, angleOffset, 220);
                    }
                }

                for (int i = 0; i < 6; i++)
                {
                    double a = (animAngle * (1 + i * 0.2) + i * 60) * Math.PI / 180.0;
                    float rr = maxR * (0.12f + (i % 3) * 0.12f);
                    float x = center.X + (float)Math.Cos(a) * rr;
                    float y = center.Y + (float)Math.Sin(a) * rr;
                    var c = ColorFromHSL((animAngle * 2 + i * 40) % 360, 0.9f, 0.6f);
                    using (var b = new SolidBrush(c))
                        g.FillEllipse(b, x - 6, y - 6, 12, 12);
                }

                using (var f = new Font("Segoe UI", 9f, FontStyle.Bold))
                {
                    string t = "Interactúa · Aprende · Visualiza";
                    var sz = g.MeasureString(t, f);
                    using (var br = new SolidBrush(Color.FromArgb(200, Color.White)))
                    {
                        g.DrawString(t, f, br, center.X - sz.Width / 2, h - sz.Height - 6);
                    }
                }
            }

            var previous = prevAnimImage;
            picAnim.Image = bmp;
            prevAnimImage = bmp;
            if (previous != null)
            {
                try { previous.Dispose(); } catch { }
            }
        }

        // Este método es el que resolvía el error: manejador del Paint del mainPanel.
        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Fondo degradado elegante (coherente con resto de la app)
            using (var lg = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(12, 35, 40), Color.FromArgb(8, 10, 25), 45f))
            {
                g.FillRectangle(lg, this.ClientRectangle);
            }

            // Pequeñas partículas decorativas (ópticas) en la parte inferior
            for (int i = 0; i < 8; i++)
            {
                int x = 40 + i * 120;
                using (var b = new SolidBrush(Color.FromArgb(20, Color.White)))
                    g.FillEllipse(b, x, this.ClientSize.Height - 100, 10, 10);
            }
        }

        // Navegación: abrir Forms 3..6
        private void btnSystems_Click(object sender, EventArgs e)
        {
            this.Hide();
            try
            {
                using (var f = new Form3())
                {
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.ShowDialog();
                }
            }
            finally
            {
                this.Close();
            }
        }

        private void btnRoots_Click(object sender, EventArgs e)
        {
            this.Hide();
            try
            {
                using (var f = new Form4())
                {
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.ShowDialog();
                }
            }
            finally
            {
                this.Close();
            }
        }

        private void btnDerivation_Click(object sender, EventArgs e)
        {
            this.Hide();
            try
            {
                using (var f = new Form5())
                {
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.ShowDialog();
                }
            }
            finally
            {
                this.Close();
            }
        }

        private void btnIntegration_Click(object sender, EventArgs e)
        {
           this.Hide();
            try
            {
                using (var f = new Form6())
                {
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.ShowDialog();
                }
            }
            finally
            {
                this.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try { gifTimer?.Stop(); gifTimer?.Dispose(); } catch { }
            try { if (prevAnimImage != null) { prevAnimImage.Dispose(); prevAnimImage = null; } } catch { }
            base.OnFormClosed(e);
        }

        // Conversión HSL -> Color (copiada para coherencia)
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
}
