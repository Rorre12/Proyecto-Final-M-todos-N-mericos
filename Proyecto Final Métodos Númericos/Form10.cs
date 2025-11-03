using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form10 : Form
    {
        private Image prevDecor;
        private float decorAngle = 0f;
        private Timer decorTimer;

        // controles dinámicos de la matriz
        private TextBox[,] matrixBoxes;
        private int currentSize = 0;

        public Form10()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(18, 18, 22);

            // estilo labels y botones
            lblHeader.Parent = mainPanel; lblHeader.BringToFront(); lblHeader.BackColor = Color.Transparent;
            cardPanel.Parent = mainPanel; cardPanel.BringToFront();

            VisualHelpers.ConfigureButtonVisual(btnCreate, Color.FromArgb(34, 160, 255), Color.FromArgb(10, 120, 220));
            VisualHelpers.ConfigureButtonVisual(btnExample, Color.FromArgb(120, 200, 100), Color.FromArgb(80, 160, 80));
            VisualHelpers.ConfigureButtonVisual(btnOpenSolver, Color.FromArgb(255, 110, 120), Color.FromArgb(220, 70, 90));
            VisualHelpers.ConfigureButtonVisualSimple(btnBack, Color.FromArgb(200, 60, 80), Color.FromArgb(170, 40, 60));
            VisualHelpers.ConfigureButtonVisualSimple(btnRegresar, Color.FromArgb(160, 120, 255), Color.FromArgb(120, 90, 220));

            // preparación de la decoración animada en picDecor (simple)
            decorTimer = new Timer { Interval = 40 };
            decorTimer.Tick += DecorTimer_Tick;
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            LayoutControls();
            decorTimer.Start();
            // crear matriz por defecto
            CreateMatrixInputs((int)nudSize.Value);
        }

        private void Form10_Resize(object sender, EventArgs e)
        {
            LayoutControls();
            picDecor.Invalidate();
        }

        private void LayoutControls()
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            cardPanel.Left = 28;
            cardPanel.Top = 78;
            cardPanel.Width = Math.Min(520, (int)(w * 0.52));
            cardPanel.Height = Math.Max(320, h - 160);

            picDecor.Left = cardPanel.Right + 24;
            picDecor.Top = 78;
            picDecor.Width = Math.Max(320, w - cardPanel.Right - 64);
            picDecor.Height = Math.Max(320, cardPanel.Height);

            // ajustar matrixPanel dentro de cardPanel: mantener más arriba y centrado
            matrixPanel.Left = 18;
            matrixPanel.Top = 110; // fijo más arriba para que las casillas estén cerca del encabezado
            matrixPanel.Width = cardPanel.Width - 36;
            matrixPanel.Height = Math.Max(140, cardPanel.Height - 220);
        }

        private void DecorTimer_Tick(object sender, EventArgs e)
        {
            decorAngle += 3.5f;
            if (decorAngle > 360f) decorAngle -= 360f;

            int w = Math.Max(1, picDecor.Width);
            int h = Math.Max(1, picDecor.Height);
            var bmp = new Bitmap(w, h, PixelFormat.Format32bppPArgb);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);
                using (var lg = new LinearGradientBrush(new Rectangle(0, 0, w, h),
                    Color.FromArgb(10, 255, 255, 255), Color.FromArgb(6, 0, 0, 0), LinearGradientMode.ForwardDiagonal))
                {
                    g.FillRectangle(lg, 0, 0, w, h);
                }

                var center = new PointF(w / 2f, h / 2f);
                float maxR = Math.Min(w, h) * 0.45f;

                for (int i = 0; i < 4; i++)
                {
                    float r = maxR * (0.25f + i * 0.15f);
                    float thickness = 8 - i * 2;
                    float ang = decorAngle * (1 + i * 0.25f) + i * 25f;
                    Color col = VisualHelpers.ColorFromHSL((ang + i * 50) % 360, 0.8f, 0.55f);
                    using (var pen = new Pen(col, thickness)) { pen.StartCap = LineCap.Round; pen.EndCap = LineCap.Round; g.DrawArc(pen, center.X - r, center.Y - r, r * 2, r * 2, ang, 220); }
                }

                using (var f = new Font("Segoe UI", 12f, FontStyle.Bold))
                {
                    string t = "Eliminación · Análisis · Visualización";
                    var sz = g.MeasureString(t, f);
                    using (var br = new SolidBrush(Color.FromArgb(220, Color.White)))
                    {
                        g.DrawString(t, f, br, center.X - sz.Width / 2, h - sz.Height - 18);
                    }
                }
            }

            var prev = prevDecor;
            picDecor.Image = bmp;
            prevDecor = bmp;
            if (prev != null) { try { prev.Dispose(); } catch { } }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var lg = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(12, 18, 30), Color.FromArgb(8, 10, 20), 45f))
                g.FillRectangle(lg, this.ClientRectangle);

            var rc = new Rectangle(cardPanel.Left - 8, cardPanel.Top - 8, cardPanel.Width + 16, cardPanel.Height + 16);
            using (var p = new Pen(Color.FromArgb(20, Color.White), 1))
            using (var br = new SolidBrush(Color.FromArgb(24, 28, 36)))
            {
                var gp = new GraphicsPath();
                gp.AddArc(rc.X, rc.Y, 18, 18, 180, 90);
                gp.AddArc(rc.Right - 18, rc.Y, 18, 18, 270, 90);
                gp.AddArc(rc.Right - 18, rc.Bottom - 18, 18, 18, 0, 90);
                gp.AddArc(rc.X, rc.Bottom - 18, 18, 18, 90, 90);
                gp.CloseFigure();
                g.FillPath(br, gp);
                g.DrawPath(p, gp);
            }
        }

        // crea TextBoxes dinámicos para una matriz aumentada n x (n+1)
        private void CreateMatrixInputs(int n)
        {
            matrixPanel.Controls.Clear();
            matrixBoxes = new TextBox[n, n + 1];
            currentSize = n;

            int tbW = 70; // aumentado
            int tbH = 36; // aumentado
            int gap = 8;
            int totalW = (n + 1) * tbW + (n) * gap;
            int totalH = n * tbH + (n - 1) * gap;
            int startX = Math.Max(6, (matrixPanel.Width - totalW) / 2);
            // subir un poco las casillas para que estén más cerca del encabezado
            int startY = Math.Max(6, (matrixPanel.Height - totalH) / 2 - 48);

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n + 1; c++)
                {
                    var tb = new TextBox
                    {
                        Width = tbW,
                        Height = tbH,
                        Left = startX + c * (tbW + gap),
                        Top = startY + r * (tbH + gap),
                        BackColor = Color.FromArgb(36, 36, 40),
                        ForeColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle,
                        Text = "0",
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Segoe UI", 12f, FontStyle.Regular)
                    };
                    matrixPanel.Controls.Add(tb);
                    matrixBoxes[r, c] = tb;
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateMatrixInputs((int)nudSize.Value);
        }

        private void btnExample_Click(object sender, EventArgs e)
        {
            // ejemplo 3x3 con vector
            nudSize.Value = 3;
            CreateMatrixInputs(3);
            // ejemplo: system
            double[,] ex = new double[,]
            {
                {2, -1, 1, 8},
                {1,  1, 1, 6},
                {3, -1, -1, 2}
            };
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 4; j++)
                    matrixBoxes[i, j].Text = ex[i, j].ToString();
        }

        private void btnOpenSolver_Click(object sender, EventArgs e)
        {
            // validar y construir matriz aumentada
            if (currentSize < 2) { MessageBox.Show("Crea primero la matriz.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int n = currentSize;
            double[,] aug = new double[n, n + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    if (!double.TryParse(matrixBoxes[i, j].Text, out aug[i, j]))
                    {
                        MessageBox.Show($"Valor inválido en fila {i + 1}, columna {j + 1}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            // abrir Form11 pasando la matriz (ocultar temporalmente para evitar acumulación)
            this.Hide();
            try
            {
                using (var f = new Form11(aug))
                {
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.ShowDialog();
                }
            }
            finally
            {
                // volver a mostrar este menú al regresar y limpiar las casillas
                try { this.Show(); CreateMatrixInputs(currentSize); } catch { }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            // Close to return to caller (Form3 will re-show itself)
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try { decorTimer?.Stop(); decorTimer?.Dispose(); } catch { }
            try { if (prevDecor != null) { prevDecor.Dispose(); prevDecor = null; } } catch { }
            base.OnFormClosed(e);
        }

        private void picDecor_Click(object sender, EventArgs e)
        {
            // Close to return to caller (Form3 will re-show itself)
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Close to return to caller (Form3 will re-show itself)
            this.Close();
        }

        private void nudSize_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}