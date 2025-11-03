using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form3 : Form
    {
        private Timer rightTimer;
        private Image prevRightImage;
        private float rightAngle = 0f;
        private PictureBox picRight;

        public Form3()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(18, 18, 22);
            lblHeader.Parent = mainPanel;
            lblHeader.BringToFront();
            lblHeader.BackColor = Color.Transparent;

            VisualHelpers.ConfigureButtonVisual(btnCramer, Color.FromArgb(255, 140, 60), Color.FromArgb(235, 110, 40));
            VisualHelpers.ConfigureButtonVisual(btnGauss, Color.FromArgb(34, 160, 255), Color.FromArgb(10, 120, 220));
            VisualHelpers.ConfigureButtonVisual(btnGaussJordan, Color.FromArgb(120, 90, 255), Color.FromArgb(80, 50, 200));
            VisualHelpers.ConfigureButtonVisual(btnCofactores, Color.FromArgb(120, 255, 150), Color.FromArgb(40, 200, 160));
            VisualHelpers.ConfigureButtonVisualSimple(btnClose, Color.FromArgb(200, 60, 80), Color.FromArgb(170, 40, 60));

            InitializeRightAnimation();
            this.Load += Form3_Load;
            this.Resize += Form3_Resize;
        }

        private void InitializeRightAnimation()
        {
            picRight = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.CenterImage,
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right
            };
            mainPanel.Controls.Add(picRight);
            picRight.BringToFront();

            rightTimer = new Timer { Interval = 40 };
            rightTimer.Tick += RightTimer_Tick;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LayoutRight();
            rightTimer.Start();
        }

        private void Form3_Resize(object sender, EventArgs e)
        {
            LayoutRight();
        }

        private void LayoutRight()
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            int animW = Math.Min(420, Math.Max(280, w / 3));   // mayor
            int animH = (int)(animW * 1.05);
            picRight.Size = new Size(animW, animH);

            // Centrado vertical en el lado derecho y ligeramente más bajo
            picRight.Left = this.ClientSize.Width - animW - 32;
            picRight.Top = Math.Max(40, (h - animH) / 2 + 20);
        }

        private void RightTimer_Tick(object sender, EventArgs e)
        {
            rightAngle += 6f; if (rightAngle > 360f) rightAngle -= 360f;
            int w = Math.Max(1, picRight.Width); int h = Math.Max(1, picRight.Height);
            var bmp = new Bitmap(w, h, PixelFormat.Format32bppPArgb);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias; g.Clear(Color.Transparent);
                using (var lg = new LinearGradientBrush(new Rectangle(0, 0, w, h), Color.FromArgb(10, Color.White), Color.FromArgb(10, Color.Black), LinearGradientMode.Vertical))
                    g.FillRectangle(lg, 0, 0, w, h);

                var center = new PointF(w / 2f, h * 0.36f); // dejar espacio a la leyenda abajo
                float maxR = Math.Min(w, h * 0.7f) * 0.38f;

                for (int k = 0; k < 3; k++)
                {
                    float r = maxR * (0.35f + k * 0.22f);
                    float thickness = 7f + k * 3f;
                    float ang = rightAngle * (1 + k * 0.4f) + k * 25f;
                    Color col = VisualHelpers.ColorFromHSL((ang + k * 45) % 360, 0.85f, 0.55f);
                    using (var pen = new Pen(col, thickness)) { pen.StartCap = LineCap.Round; pen.EndCap = LineCap.Round; g.DrawArc(pen, center.X - r, center.Y - r, r * 2, r * 2, ang, 200); }
                }

                for (int i = 0; i < 6; i++)
                {
                    double a = (rightAngle * (1 + i * 0.25) + i * 70) * Math.PI / 180.0;
                    float rr = maxR * (0.2f + (i % 2) * 0.15f);
                    float x = center.X + (float)Math.Cos(a) * rr;
                    float y = center.Y + (float)Math.Sin(a) * rr;
                    var c = VisualHelpers.ColorFromHSL((rightAngle * 2 + i * 70) % 360, 0.9f, 0.6f);
                    using (var br = new SolidBrush(c)) g.FillEllipse(br, x - 8, y - 8, 16, 16);
                }

                // Leyenda centrada debajo del GIF
                string leyenda = "Interactúa · Aprende · Visualiza";
                using (var f = new Font("Segoe UI", 14f, FontStyle.Bold))
                {
                    var sz = g.MeasureString(leyenda, f);
                    float leyendaY = center.Y + maxR + 28;
                    using (var br = new SolidBrush(Color.FromArgb(235, 245, 255)))
                        g.DrawString(leyenda, f, br, (w - sz.Width) / 2, leyendaY);
                }
            }

            var prev = prevRightImage;
            picRight.Image = bmp;
            prevRightImage = bmp;
            if (prev != null) { try { prev.Dispose(); } catch { } }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            using (var lg = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(12, 35, 40), Color.FromArgb(8, 10, 25), 45f))
                g.FillRectangle(lg, this.ClientRectangle);
        }

        private void btnCramer_Click(object sender, EventArgs e)
        {
            // Hide this form while the Cramer subform is shown to avoid duplicate windows
            this.Hide();
            try
            {
                using (var f = new Form7())
                {
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.ShowDialog();
                }
            }
            finally
            {
                // Show this form again when the child closes
                try { this.Show(); } catch { }
            }
        }

        private void btnGauss_Click(object sender, EventArgs e)
        {
            this.Hide();
            try
            {
                using (var f = new Form10())
                {
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.ShowDialog();
                }
            }
            finally
            {
                try { this.Show(); } catch { }
            }
        }
       private void btnGaussJordan_Click(object sender, EventArgs e)
        {
            this.Hide();
            try
            {
                using (var f = new Form12())
                {
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.ShowDialog();
                }
            }
            finally
            {
                try { this.Show(); } catch { }
            }
        }
        private void btnCofactores_Click(object sender, EventArgs e)
        {
            this.Hide();
            try
            {
                using (var f = new Form14())
                {
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.ShowDialog();
                }
            }
            finally
            {
                try { this.Show(); } catch { }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            // Open Form2 modally to avoid multiple visible forms
            this.Hide();
            try
            {
                using (var f = new Form2())
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

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try { rightTimer?.Stop(); rightTimer?.Dispose(); } catch { }
            try { prevRightImage?.Dispose(); } catch { }
            base.OnFormClosed(e);
        }
    }
}
