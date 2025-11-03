using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form30 : Form
    {
        private Timer decorTimer;
        private float angle = 0f;
        private Image prev;

        public Form30()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(18, 18, 22);
        }

        private void Form30_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnComenzar;
            // Animación decorativa (sin textos ni labels adicionales)
            decorTimer = new Timer { Interval = 40 };
            decorTimer.Tick += (s, ev) => DrawDecor();
            decorTimer.Start();
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            // Asegura solo una ventana visible a la vez
            this.Hide();
            using (var f = new Form31())
            {
                f.ShowDialog(this);
            }
            this.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Regresa al formulario anterior (Form4 debe ser quien abre este form)
            this.Close();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            using (var lg = new LinearGradientBrush(this.ClientRectangle,
                       Color.FromArgb(12, 35, 40), Color.FromArgb(8, 10, 25), 45f))
            {
                e.Graphics.FillRectangle(lg, this.ClientRectangle);
            }
        }

        private void DrawDecor()
        {
            if (picDecor == null) return;

            angle += 4f;
            if (angle > 360f) angle -= 360f;

            int w = Math.Max(1, picDecor.Width);
            int h = Math.Max(1, picDecor.Height);
            var bmp = new Bitmap(w, h, PixelFormat.Format32bppPArgb);

            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                // suave degradado de fondo del área de animación
                using (var lg = new LinearGradientBrush(new Rectangle(0, 0, w, h),
                    Color.FromArgb(16, 40, 60), Color.FromArgb(8, 16, 30), 90f))
                {
                    g.FillRectangle(lg, 0, 0, w, h);
                }

                var center = new PointF(w / 2f, h * 0.40f);
                float maxR = Math.Min(w, h * 0.7f) * 0.42f;

                for (int k = 0; k < 4; k++)
                {
                    float r = maxR * (0.35f + k * 0.18f);
                    float thickness = 6f + k * 2.2f;
                    float ang = angle * (1 + k * 0.35f) + k * 28f;
                    Color col = FromHsl((ang + k * 60) % 360f, 0.85f, 0.58f);

                    using (var pen = new Pen(col, thickness))
                    {
                        pen.StartCap = LineCap.Round;
                        pen.EndCap = LineCap.Round;
                        g.DrawArc(pen, center.X - r, center.Y - r, r * 2, r * 2, ang, 220);
                    }
                }
            }

            var old = prev;
            picDecor.Image = bmp;
            prev = bmp;
            if (old != null) { try { old.Dispose(); } catch { } }
        }

        private static Color FromHsl(float h, float s, float l)
        {
            h = (h % 360f + 360f) % 360f;
            s = Math.Max(0f, Math.Min(1f, s));
            l = Math.Max(0f, Math.Min(1f, l));

            float c = (1f - Math.Abs(2f * l - 1f)) * s;
            float x = c * (1f - Math.Abs((h / 60f) % 2f - 1f));
            float m = l - c / 2f;
            float r1 = 0, g1 = 0, b1 = 0;

            if (h < 60f) { r1 = c; g1 = x; b1 = 0; }
            else if (h < 120f) { r1 = x; g1 = c; b1 = 0; }
            else if (h < 180f) { r1 = 0; g1 = c; b1 = x; }
            else if (h < 240f) { r1 = 0; g1 = x; b1 = c; }
            else if (h < 300f) { r1 = x; g1 = 0; b1 = c; }
            else { r1 = c; g1 = 0; b1 = x; }

            int r = (int)Math.Round((r1 + m) * 255);
            int g = (int)Math.Round((g1 + m) * 255);
            int b = (int)Math.Round((b1 + m) * 255);
            r = Math.Max(0, Math.Min(255, r));
            g = Math.Max(0, Math.Min(255, g));
            b = Math.Max(0, Math.Min(255, b));
            return Color.FromArgb(r, g, b);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try { decorTimer?.Stop(); decorTimer?.Dispose(); } catch { }
            try { prev?.Dispose(); } catch { }
            base.OnFormClosed(e);
        }
    }
}
