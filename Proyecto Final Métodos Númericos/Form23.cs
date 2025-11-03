using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form23 : Form
    {
        private Timer decorTimer;
        private float angle =0f;
        private Image prev;

        public Form23()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(18,18,22);

            // Estilo del botón comenzar
            try
            {
                VisualHelpers.ConfigureButtonVisual(btnContinuar, Color.FromArgb(34,160,255), Color.FromArgb(10,120,220));
                VisualHelpers.ConfigureButtonVisualSimple(btnBack, Color.FromArgb(200,60,80), Color.FromArgb(170,40,60));
            }
            catch
            {
                btnContinuar.UseVisualStyleBackColor = false;
                btnContinuar.BackColor = Color.FromArgb(34,160,255);
                btnContinuar.ForeColor = Color.White;
                btnContinuar.FlatStyle = FlatStyle.Flat;
                btnContinuar.FlatAppearance.BorderSize =0;

                btnBack.UseVisualStyleBackColor = false;
                btnBack.BackColor = Color.FromArgb(200,60,80);
                btnBack.ForeColor = Color.White;
                btnBack.FlatStyle = FlatStyle.Flat;
                btnBack.FlatAppearance.BorderSize =0;
            }

            decorTimer = new Timer { Interval =40 };
            decorTimer.Tick += (s, e) => DrawDecor();
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            LayoutControls();
            decorTimer.Start();
        }

        private void Form23_Resize(object sender, EventArgs e)
        {
            LayoutControls();
            picDecor?.Invalidate();
        }

        private void LayoutControls()
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            cardPanel.Left =28;
            cardPanel.Top =78;
            cardPanel.Width = Math.Min(560, (int)(w *0.55));
            cardPanel.Height = Math.Max(360, h -140);

            picDecor.Left = cardPanel.Right +24;
            picDecor.Top =78;
            picDecor.Width = Math.Max(300, w - cardPanel.Right -64);
            picDecor.Height = Math.Max(320, cardPanel.Height);
            picDecor.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void DrawDecor()
        {
            angle +=5f; if (angle >360f) angle -=360f;
            int w = Math.Max(1, picDecor.Width); int h = Math.Max(1, picDecor.Height);
            var bmp = new Bitmap(w, h, PixelFormat.Format32bppPArgb);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias; g.Clear(Color.Transparent);
                using (var lg = new LinearGradientBrush(new Rectangle(0,0, w, h), Color.FromArgb(10, Color.White), Color.FromArgb(10, Color.Black), LinearGradientMode.Vertical))
                    g.FillRectangle(lg,0,0, w, h);

                var center = new PointF(w /2f, h *0.36f); float maxR = Math.Min(w, h *0.7f) *0.38f;
                for (int k =0; k <3; k++)
                {
                    float r = maxR * (0.35f + k *0.22f);
                    float thickness =7f + k *3f;
                    float ang = angle * (1 + k *0.4f) + k *25f;
                    Color col = VisualHelpers.ColorFromHSL((ang + k *45) %360,0.85f,0.55f);
                    using (var pen = new Pen(col, thickness)) { pen.StartCap = LineCap.Round; pen.EndCap = LineCap.Round; g.DrawArc(pen, center.X - r, center.Y - r, r *2, r *2, ang,200); }
                }

                string leyenda = "Regula Falsi · Segmentos · Interpolación";
                using (var f = new Font("Segoe UI",13f, FontStyle.Bold))
                {
                    var sz = g.MeasureString(leyenda, f);
                    using (var br = new SolidBrush(Color.FromArgb(235,245,255)))
                        g.DrawString(leyenda, f, br, (w - sz.Width) /2, center.Y + maxR +26);
                }
            }
            var old = prev; picDecor.Image = bmp; prev = bmp; if (old != null) { try { old.Dispose(); } catch { } }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            using (var lg = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(12,35,40), Color.FromArgb(8,10,25),45f))
                e.Graphics.FillRectangle(lg, this.ClientRectangle);
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            // Navegación al Form24 con un solo form visible
            this.Hide();
            try
            {
                using (var f = new Form24())
                {
                    f.StartPosition = FormStartPosition.CenterParent;
                    f.ShowDialog(this);
                }
            }
            finally
            {
                try { this.Show(); } catch { }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Cerrar para volver a Form4 (quien lo abrió modal)
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try { decorTimer?.Stop(); decorTimer?.Dispose(); } catch { }
            try { prev?.Dispose(); } catch { }
            base.OnFormClosed(e);
        }
    }
}
