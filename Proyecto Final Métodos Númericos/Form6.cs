using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq; // para OfType()
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(18, 18, 22);

            // Hacer los labels transparentes y en primer plano sobre el panel
            lblHeader.Parent = mainPanel;
            lblHeader.BringToFront();
            lblHeader.BackColor = Color.Transparent;

            // No depender solamente del Label para el estilo del "PRÓXIMAMENTE":
            // mantendremos el Label pero lo coloreamos de forma viva y lo dibujamos con mayor contraste.
            lblSoon.Parent = mainPanel;
            lblSoon.BringToFront();
            lblSoon.BackColor = Color.Transparent;
            lblSoon.ForeColor = Color.FromArgb(255, 180, 120);
            lblSoon.Font = new Font(lblSoon.Font.FontFamily, 30f, FontStyle.Bold);

            // Botón cerrar con estilo
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.BackColor = Color.FromArgb(200, 60, 80);
            btnClose.ForeColor = Color.White;
            btnClose.MouseEnter += (s, e) => btnClose.BackColor = Color.FromArgb(170, 40, 60);
            btnClose.MouseLeave += (s, e) => btnClose.BackColor = Color.FromArgb(200, 60, 80);
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Fondo degradado
            using (var lg = new LinearGradientBrush(this.ClientRectangle,
                Color.FromArgb(12, 35, 40), Color.FromArgb(8, 10, 25), 45f))
            {
                g.FillRectangle(lg, this.ClientRectangle);
            }

            // dibujar un glow sutil detrás del texto "PRÓXIMAMENTE"
            try
            {
                var text = lblSoon.Text;
                using (var f = new Font(lblSoon.Font.FontFamily, lblSoon.Font.Size, FontStyle.Bold))
                {
                    var sz = g.MeasureString(text, f);
                    float x = lblSoon.Left;
                    float y = lblSoon.Top;

                    // glow: dibuja varias capas translúcidas
                    for (int i = 8; i >= 1; i--)
                    {
                        using (var brGlow = new SolidBrush(Color.FromArgb(20 * i, Color.White)))
                        {
                            g.DrawString(text, f, brGlow, x - i * 1.2f, y - i * 1.2f);
                        }
                    }

                    // texto principal con degradado
                    var rect = new RectangleF(x, y, sz.Width, sz.Height);
                    using (var lgText = new LinearGradientBrush(rect, Color.FromArgb(255, 200, 140), Color.FromArgb(220, 120, 240), LinearGradientMode.Horizontal))
                    {
                        g.DrawString(text, f, lgText, rect.Location);
                    }
                }
            }
            catch
            {
                // ignorar si no está todo posicionado en diseño
            }

            // decorativo alrededor del "PRÓXIMAMENTE"
            try
            {
                using (var p = new Pen(Color.FromArgb(40, Color.White), 2))
                {
                    int x = lblSoon.Left - 16;
                    int y = lblSoon.Top - 8;
                    int w = lblSoon.Width + 32;
                    int h = lblSoon.Height + 16;
                    g.DrawRoundedRectangle(p, x, y, w, h, 12);
                }
            }
            catch { }
        }

        private void NavigateToForm2()
        {
            try
            {
                var form2 = Application.OpenForms.OfType<Form2>().FirstOrDefault();
                if (form2 == null)
                {
                    form2 = new Form2 { StartPosition = FormStartPosition.CenterScreen };
                    form2.Show();
                }
                else
                {
                    form2.Show();
                }
                form2.WindowState = FormWindowState.Normal;
                form2.BringToFront();
                form2.Activate();

                foreach (Form f in Application.OpenForms.Cast<Form>().ToArray())
                {
                    if (!ReferenceEquals(f, form2))
                    {
                        if (ReferenceEquals(f, this))
                        {
                            bool isMain = ReferenceEquals(Application.OpenForms.Cast<Form>().FirstOrDefault(), this);
                            if (isMain) this.Hide(); else { try { this.Close(); } catch { this.Hide(); } }
                        }
                        else if (f.Visible)
                        {
                            try { f.Hide(); } catch { }
                        }
                    }
                }
            }
            catch { try { var f2 = new Form2 { StartPosition = FormStartPosition.CenterScreen }; f2.Show(); this.Hide(); } catch { } }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }
    }

    // Extensión para dibujar rectángulo redondeado
    internal static class GraphicsExtensions
    {
        public static void DrawRoundedRectangle(this Graphics g, Pen pen, int x, int y, int width, int height, int radius)
        {
            using (var path = new GraphicsPath())
            {
                int r = Math.Max(0, radius);
                path.AddArc(x, y, r, r, 180, 90);
                path.AddArc(x + width - r, y, r, r, 270, 90);
                path.AddArc(x + width - r, y + height - r, r, r, 0, 90);
                path.AddArc(x, y + height - r, r, r, 90, 90);
                path.CloseFigure();
                g.DrawPath(pen, path);
            }
        }
    }
}
