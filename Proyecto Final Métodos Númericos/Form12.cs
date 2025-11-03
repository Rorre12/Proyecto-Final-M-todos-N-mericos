using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form12 : Form
    {
        private Image prevDecor;
        private float decorAngle = 0f;
        private Timer decorTimer;

        private TextBox[,] matrixBoxes;
        private int currentSize = 0;

        public Form12()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(18, 18, 22);

            lblHeader.Parent = mainPanel; lblHeader.BringToFront(); lblHeader.BackColor = Color.Transparent;
            cardPanel.Parent = mainPanel; cardPanel.BringToFront();

            VisualHelpers.ConfigureButtonVisual(btnCreate, Color.FromArgb(34, 160, 255), Color.FromArgb(10, 120, 220));
            VisualHelpers.ConfigureButtonVisual(btnExample, Color.FromArgb(120, 200, 100), Color.FromArgb(80, 160, 80));
            VisualHelpers.ConfigureButtonVisual(btnOpenSolver, Color.FromArgb(255, 110, 120), Color.FromArgb(220, 70, 90));
            VisualHelpers.ConfigureButtonVisualSimple(btnBack, Color.FromArgb(200, 60, 80), Color.FromArgb(170, 40, 60));

            decorTimer = new Timer { Interval = 40 };
            decorTimer.Tick += DecorTimer_Tick;
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            LayoutControls();
            decorTimer.Start();
            // ensure combo has default values
            if (cmbSize.Items.Count == 0)
            {
                cmbSize.Items.Add("2");
                cmbSize.Items.Add("3");
                cmbSize.SelectedIndex = 0;
            }
            CreateMatrixInputs(int.Parse(cmbSize.SelectedItem?.ToString() ?? "2"));
        }

        private void Form12_Resize(object sender, EventArgs e)
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
            cardPanel.Width = Math.Min(560, (int)(w * 0.55));
            cardPanel.Height = Math.Max(360, h - 160);

            picDecor.Left = cardPanel.Right + 24;
            picDecor.Top = 78;
            picDecor.Width = Math.Max(320, w - cardPanel.Right - 64);
            picDecor.Height = Math.Max(320, cardPanel.Height);

            // 🔼 Subimos el panel de la matriz y le damos más altura
            matrixPanel.Left = 24;
            matrixPanel.Top = 120; // antes 244, subido
            matrixPanel.Width = cardPanel.Width - 48;
            matrixPanel.Height = Math.Max(220, cardPanel.Height - 180); // más altura útil
        }

        private void DecorTimer_Tick(object sender, EventArgs e)
        {
            decorAngle += 3.5f; if (decorAngle > 360f) decorAngle -= 360f;
            int w = Math.Max(1, picDecor.Width); int h = Math.Max(1, picDecor.Height);
            var bmp = new Bitmap(w, h, PixelFormat.Format32bppPArgb);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias; g.Clear(Color.Transparent);
                using (var lg = new LinearGradientBrush(new Rectangle(0, 0, w, h), Color.FromArgb(10, 255, 255, 255), Color.FromArgb(6, 0, 0, 0), LinearGradientMode.ForwardDiagonal))
                    g.FillRectangle(lg, 0, 0, w, h);
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
                    string t = "Inversa · Precisión · Visualización";
                    var sz = g.MeasureString(t, f);
                    using (var br = new SolidBrush(Color.FromArgb(220, Color.White))) g.DrawString(t, f, br, center.X - sz.Width / 2, h - sz.Height - 18);
                }
            }
            var prev = prevDecor; picDecor.Image = bmp; prevDecor = bmp; if (prev != null) { try { prev.Dispose(); } catch { } }
        }

        // create bigger textboxes for matrix input
        private void CreateMatrixInputs(int n)
        {
            matrixPanel.Controls.Clear();
            matrixBoxes = new TextBox[n, n];
            currentSize = n;
            int tbW = 84;
            int tbH = 40;
            int gap = 10;
            int totalW = n * tbW + (n - 1) * gap;
            int totalH = n * tbH + (n - 1) * gap;

            int startX = Math.Max(6, (matrixPanel.Width - totalW) / 2);

            // 🔼 Centramos visualmente la matriz más arriba
            int startY = Math.Max(10, (matrixPanel.Height - totalH) / 2 - 20);

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
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
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Segoe UI", 12f, FontStyle.Regular),
                        Text = "0"
                    };
                    matrixPanel.Controls.Add(tb);
                    matrixBoxes[r, c] = tb;
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateMatrixInputs(int.Parse(cmbSize.SelectedItem?.ToString() ?? "2"));
        }

        private void btnExample_Click(object sender, EventArgs e)
        {
            int n = int.Parse(cmbSize.SelectedItem?.ToString() ?? "2");
            CreateMatrixInputs(n);
            if (n == 2)
            {
                double[,] ex = { { 4, 7 }, { 2, 6 } };
                for (int i = 0; i < 2; i++) for (int j = 0; j < 2; j++) matrixBoxes[i, j].Text = ex[i, j].ToString();
            }
            else
            {
                double[,] ex = { { 2, -1, 0 }, { -1, 2, -1 }, { 0, -1, 2 } };
                for (int i = 0; i < 3; i++) for (int j = 0; j < 3; j++) matrixBoxes[i, j].Text = ex[i, j].ToString();
            }
        }

        private void btnOpenSolver_Click(object sender, EventArgs e)
        {
            if (currentSize < 2) { MessageBox.Show("Crea primero la matriz.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            int n = currentSize;
            double[,] mat = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (!double.TryParse(matrixBoxes[i, j].Text, out mat[i, j]))
                    {
                        MessageBox.Show($"Valor inválido en fila {i + 1}, columna {j + 1}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            // hide this and open Form13 modally
            this.Hide();
            try
            {
                using (var f = new Form13(mat))
                {
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.ShowDialog();
                }
            }
            finally
            {
                try { this.Show(); CreateMatrixInputs(currentSize); } catch { }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
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
    }
}