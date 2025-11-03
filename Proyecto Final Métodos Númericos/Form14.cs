using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form14 : Form
    {
        private int dimension = 2;
        private double[,] coef;
        private double[] constantes;

        // anim decor (fallback si no hay GIF)
        private Image prevDecor;
        private float decorAngle = 0f;
        private Timer decorTimer;
        private bool useProceduralDecor = true;

        public Form14()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(18, 18, 22);

            // colores de botones (distintos)
            StyleButtons();

            // layout dinámico
            this.Load += (s, e) => { LayoutControls(); InitDecor(); CrearGrid(dimension); };
            this.Resize += (s, e) => { LayoutControls(); if (useProceduralDecor) picDecor.Invalidate(); };

            // eventos de UI
            rdb2x2.CheckedChanged += (s, e) => { if (rdb2x2.Checked) { dimension = 2; CrearGrid(dimension); } };
            rdb3x3.CheckedChanged += (s, e) => { if (rdb3x3.Checked) { dimension = 3; CrearGrid(dimension); } };
            btnResolver.Click += BtnResolver_Click;
            btnLimpiar.Click += (s, e) => CrearGrid(dimension);
            btnBack.Click += (s, e) => this.Close();
            dgvMatriz.EditingControlShowing += DgvMatriz_EditingControlShowing;
            dgvMatriz.CellEndEdit += DgvMatriz_CellEndEdit;
        }

        private void StyleButtons()
        {
            btnResolver.UseVisualStyleBackColor = false;
            btnResolver.BackColor = Color.FromArgb(34, 160, 255); // azul
            btnResolver.ForeColor = Color.White;
            btnResolver.FlatStyle = FlatStyle.Flat;
            btnResolver.FlatAppearance.BorderSize = 0;

            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.BackColor = Color.FromArgb(80, 160, 80); // verde
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.FlatAppearance.BorderSize = 0;

            btnBack.UseVisualStyleBackColor = false;
            btnBack.BackColor = Color.FromArgb(200, 60, 80); // rojo
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
        }

        private void LayoutControls()
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            // panel de tarjeta a la izquierda
            cardPanel.Left = 28;
            cardPanel.Top = 78;
            cardPanel.Width = Math.Min(560, (int)(w * 0.55));
            cardPanel.Height = Math.Max(360, h - 160);

            // decor a la derecha
            picDecor.Left = cardPanel.Right + 24;
            picDecor.Top = 78;
            picDecor.Width = Math.Max(320, w - cardPanel.Right - 64);
            picDecor.Height = Math.Max(320, cardPanel.Height);
            picDecor.SizeMode = PictureBoxSizeMode.CenterImage;

            // distribuir fila superior dentro del card
            lblSize.Left = 18;
            lblSize.Top = 16;

            rdb2x2.Left = lblSize.Right + 8;
            rdb2x2.Top = lblSize.Top - 2;

            rdb3x3.Left = rdb2x2.Right + 12;
            rdb3x3.Top = rdb2x2.Top;

            // fila de botones
            btnResolver.Left = 22;
            btnResolver.Top = 52;
            btnResolver.Width = 180;

            btnLimpiar.Left = btnResolver.Right + 12;
            btnLimpiar.Top = 52;
            btnLimpiar.Width = 140;

            btnBack.Width = 120;
            btnBack.Left = cardPanel.Right - cardPanel.Left - btnBack.Width - 22; // relativo al card
            btnBack.Top = 52;

            // panel de matriz (↑ lo subimos un poco más)
            matrixPanel.Left = 22;
            matrixPanel.Top = 88; // antes 108 -> subido 20 px
            matrixPanel.Width = cardPanel.Width - 44;
            matrixPanel.Height = cardPanel.Height - 130;

            // centrar la grilla dentro del panel
            CenterGrid();
        }

        private void CenterGrid()
        {
            dgvMatriz.Left = Math.Max(6, (matrixPanel.Width - dgvMatriz.Width) / 2);
            dgvMatriz.Top = Math.Max(6, (matrixPanel.Height - dgvMatriz.Height) / 2);
        }

        // Añade este helper dentro de la clase Form14 (por encima o debajo de InitDecor)
        private Image TryGetImageResource(params string[] names)
        {
            try
            {
                var rm = Properties.Resources.ResourceManager;
                foreach (var n in names)
                {
                    var obj = rm.GetObject(n);
                    if (obj is Image img) return img;
                }
            }
            catch { }
            return null;
        }

        private void InitDecor()
        {
            // Intenta cargar por nombre; no requiere que existan propiedades tipadas en Resources
            var gif = TryGetImageResource("decor", "decor_gif", "cofactores", "cofactores_gif");
            if (gif != null)
            {
                useProceduralDecor = false;
                picDecor.SizeMode = PictureBoxSizeMode.CenterImage;
                picDecor.Image = gif; // PictureBox anima el GIF automáticamente
                return;
            }

            // Fallback: animación procedural (sin recursos)
            useProceduralDecor = true;
            decorTimer = new Timer { Interval = 40 };
            decorTimer.Tick += DecorTimer_Tick;
            decorTimer.Start();
        }

        private void DecorTimer_Tick(object sender, EventArgs e)
        {
            if (!useProceduralDecor) return;

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
                    string t = "Cofactores · Precisión · Visualización";
                    var sz = g.MeasureString(t, f);
                    using (var br = new SolidBrush(Color.FromArgb(220, Color.White)))
                        g.DrawString(t, f, br, center.X - sz.Width / 2, h - sz.Height - 18);
                }
            }

            var prev = prevDecor; picDecor.Image = bmp; prevDecor = bmp; if (prev != null) { try { prev.Dispose(); } catch { } }
        }

        // crear/rellenar grilla
        private void CrearGrid(int n)
        {
            dgvMatriz.Columns.Clear();
            dgvMatriz.Rows.Clear();
            dgvMatriz.AllowUserToAddRows = false;
            dgvMatriz.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            var colStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(36, 36, 40),
                ForeColor = Color.White,
                SelectionBackColor = Color.FromArgb(50, 100, 160),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 11f)
            };

            for (int c = 0; c < n; c++)
            {
                var col = new DataGridViewTextBoxColumn { Name = $"a{c + 1}", HeaderText = $"a{c + 1}", Width = 96 };
                col.DefaultCellStyle = colStyle;
                dgvMatriz.Columns.Add(col);
            }
            var colB = new DataGridViewTextBoxColumn { Name = "b", HeaderText = "b (const.)", Width = 110 };
            colB.DefaultCellStyle = colStyle;
            dgvMatriz.Columns.Add(colB);

            dgvMatriz.RowTemplate.Height = 46;
            dgvMatriz.Width = Math.Min(this.ClientSize.Width - 360, 540);
            dgvMatriz.Height = n * (dgvMatriz.RowTemplate.Height + 2) + 6;

            for (int r = 0; r < n; r++)
            {
                dgvMatriz.Rows.Add();
                for (int c = 0; c < n + 1; c++)
                    dgvMatriz.Rows[r].Cells[c].Value = "0";
            }

            CenterGrid();
        }

        // validación + entrada numérica
        private void DgvMatriz_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var tb = e.Control as TextBox;
            if (tb == null) return;
            tb.KeyPress -= Tb_KeyPress;
            tb.KeyPress += Tb_KeyPress;
        }
        private void Tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsControl(ch) || char.IsDigit(ch) || ch == '.' || ch == ',' || ch == '-') return;
            e.Handled = true;
        }
        private void DgvMatriz_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var cell = dgvMatriz.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell?.Value == null) return;
            var s = cell.Value.ToString().Trim().Replace(',', '.');
            if (!double.TryParse(s, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var v))
            {
                MessageBox.Show($"Valor no numérico en fila {e.RowIndex + 1}, columna {e.ColumnIndex + 1}. Se reemplazará por 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cell.Value = "0";
            }
            else
            {
                cell.Value = v.ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        private bool RecolectarDatos()
        {
            try
            {
                coef = new double[dimension, dimension];
                constantes = new double[dimension];
                for (int i = 0; i < dimension; i++)
                {
                    for (int j = 0; j < dimension; j++)
                        coef[i, j] = Convert.ToDouble(dgvMatriz.Rows[i].Cells[j].Value, System.Globalization.CultureInfo.InvariantCulture);
                    constantes[i] = Convert.ToDouble(dgvMatriz.Rows[i].Cells[dimension].Value, System.Globalization.CultureInfo.InvariantCulture);
                }
                return true;
            }
            catch
            {
                MessageBox.Show("Error al leer la matriz. Revisa entradas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void BtnResolver_Click(object sender, EventArgs e)
        {
            if (!ValidarGrid()) return;
            if (!RecolectarDatos()) return;

            this.Hide();
            try
            {
                using (var f = new Form15(coef, constantes))
                {
                    f.StartPosition = FormStartPosition.CenterParent;
                    f.ShowDialog();
                }
            }
            finally
            {
                try { CrearGrid(dimension); this.Show(); } catch { try { this.Show(); } catch { } }
            }
        }

        private bool ValidarGrid()
        {
            for (int r = 0; r < dimension; r++)
            {
                for (int c = 0; c < dimension + 1; c++)
                {
                    var v = dgvMatriz.Rows[r].Cells[c].Value;
                    if (v == null || string.IsNullOrWhiteSpace(v.ToString()))
                    {
                        MessageBox.Show($"Celda vacía en fila {r + 1}, columna {c + 1}.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (!double.TryParse(v.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out _))
                    {
                        MessageBox.Show($"Valor inválido en fila {r + 1}, columna {c + 1}. Ingresa solo números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try { decorTimer?.Stop(); decorTimer?.Dispose(); } catch { }
            try { if (prevDecor != null) { prevDecor.Dispose(); prevDecor = null; } } catch { }
            base.OnFormClosed(e);
        }
    }
}