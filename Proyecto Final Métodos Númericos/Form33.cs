using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form33 : Form
    {
        SpeechSynthesizer voz;

        private float hue = 200f;
        private Timer bgTimer;

        public Form33()
        {
            InitializeComponent();

            // Suavizar repintados (flicker-free) en el formulario
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.DoubleBuffered = true;

            // Activar DoubleBuffered en el panel principal (propiedad protegida)
            try
            {
                var pi = typeof(Panel).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
                pi?.SetValue(mainPanel, true, null);
            }
            catch { }

            // Configurar la voz al iniciar
            voz = new SpeechSynthesizer();
            voz.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 0, new System.Globalization.CultureInfo("es-MX"));

            // Asegurar liberación del timer al cerrar
            this.FormClosing += (s, e) =>
            {
                try { bgTimer?.Stop(); bgTimer?.Dispose(); } catch { }
            };
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            voz.SpeakAsync("¡Bienvenido a la calculadora del método de la secante!");
        }
        private void btnAbrirCalculadora_Click(object sender, EventArgs e)
        {
            // Abrir únicamente Form34 de manera modal; no abrir otros formularios
            this.Hide();
            try
            {
                using (var calculadora = new Form34())
                {
                    calculadora.StartPosition = FormStartPosition.CenterParent;
                    calculadora.ShowDialog(this);
                }
            }
            finally
            {
                try { this.Show(); } catch { }
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Solo cerrar este formulario; Form4 será re-mostrado por su caller
            this.Close();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            // Solo cerrar este formulario; Form4 será re-mostrado por su caller
            this.Close();
        }

        private void Form33_Load(object sender, EventArgs e)
        {
            // Estilo de botones
            try
            {
                VisualHelpers.ConfigureButtonVisual(btnAbrirCalculadora, Color.FromArgb(0, 170, 200), Color.FromArgb(0, 195, 230));
                VisualHelpers.ConfigureButtonVisualSimple(btnSalir, Color.FromArgb(200, 60, 80), Color.FromArgb(170, 40, 60));
            }
            catch { }

            // Timer para animar fondo (más lento para evitar parpadeos perceptibles)
            bgTimer = new Timer { Interval = 60 };
            bgTimer.Tick += (s, a) =>
            {
                hue += 0.5f; if (hue > 360) hue -= 360;
                // Invalida solo el panel (doble buffer activo)
                try { mainPanel.Invalidate(); } catch { }
            };
            try { bgTimer.Start(); } catch { }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            int w = mainPanel.Width; int h = mainPanel.Height;
            Color c1 = VisualHelpers.ColorFromHSL(hue, 0.55f, 0.12f);
            Color c2 = VisualHelpers.ColorFromHSL((hue + 90f) % 360, 0.60f, 0.06f);
            using (var lg = new LinearGradientBrush(new Rectangle(0, 0, w, h), c1, c2, 30f))
                g.FillRectangle(lg, 0, 0, w, h);

            // Aureola detrás del botón principal
            var center = new PointF(w / 2f, h * 0.62f);
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(center.X - 150, center.Y - 40, 300, 120);
                using (var pg = new PathGradientBrush(path))
                {
                    pg.CenterColor = Color.FromArgb(80, Color.White);
                    pg.SurroundColors = new[] { Color.FromArgb(0, Color.White) };
                    g.FillPath(pg, path);
                }
            }
        }
    }
}
