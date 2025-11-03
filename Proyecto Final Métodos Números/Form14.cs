using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form14 : Form
    {
        private int dimension = 2;
        private double[,] coef;
        private double[] constantes;

        public Form14()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(18, 18, 22);

            // === CONFIGURAR BOTÓN REGRESAR EN ROJO ===
            try
            {
                btnBack.Visible = true;
                btnBack.BackColor = Color.FromArgb(200, 50, 70); // Rojo fuerte
                btnBack.ForeColor = Color.White;
                btnBack.FlatStyle = FlatStyle.Flat;
                btnBack.FlatAppearance.BorderSize = 0;
                btnBack.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                btnBack.Cursor = Cursors.Hand;
            }
            catch { }

            // === CONFIGURAR OTROS BOTONES ===
            try
            {
                VisualHelpers.ConfigureButtonVisual(btnResolver, Color.FromArgb(34, 160, 255), Color.FromArgb(10, 120, 220));
                VisualHelpers.ConfigureButtonVisualSimple(btnLimpiar, Color.FromArgb(200, 60, 80), Color.FromArgb(170, 40, 60));
            }
            catch { }

            // === IMAGEN DECORATIVA ===
            try
            {
                var img = Proyecto_Final_Métodos_Númericos.Properties.Resources.decor;
                if (img != null) picDecor.Image = img;
            }
            catch { }
            picDecor.SizeMode = PictureBoxSizeMode.CenterImage;

            // === EVENTOS ===
            this.Load += Form14_Load;
            this.Resize += Form14_Resize;
            rdb2x2.CheckedChanged += Rdb2x2_CheckedChanged;
            rdb3x3.CheckedChanged += Rdb3x3_CheckedChanged;
            btnResolver.Click += BtnResolver_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
            btnBack.Click += BtnBack_Click;
            dgvMatriz.EditingControlShowing += DgvMatriz_EditingControlShowing;
            dgvMatriz.CellEndEdit += DgvMatriz_CellEndEdit;

            // === ESTADO INICIAL ===
            rdb2x2.Checked = true;
            rdb3x3.Checked = false;
            CrearGrid(dimension);
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            PositionBackButton();
        }

        private void Form14_Resize(object sender, EventArgs e)
        {
            PositionBackButton();
            CrearGrid(dimension);
        }

        private void PositionBackButton()
        {
            try
            {
                // Colocar el botón "Regresar" arriba a la derecha del cardPanel
                var right = cardPanel.Left + cardPanel.Width;
                btnBack.Left = Math.Max(cardPanel.Left + 12, right - btnBack.Width - 12);
                btnBack.Top = cardPanel.Top + 8;
                btnBack.BringToFront();
            }
            catch { }
        }

        private void Rdb2x2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb2x2.Checked)
            {
                dimension = 2;
                CrearGrid(dimension);
            }
        }

        private void Rdb3x3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb3x3.Checked)
            {
                dimension = 3;
                CrearGrid(dimension);
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

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            CrearGrid(dimension);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Vuelve al formulario anterior
        }

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

            var colConst = new DataGridViewTextBoxColumn { Name = "b", HeaderText = "b (const.)", Width = 110 };
            colConst.DefaultCellStyle = colStyle;
            dgvMatriz.Columns.Add(colConst);

            dgvMatriz.RowTemplate.Height = 46;
            dgvMatriz.Width = Math.Min(this.ClientSize.Width - 360, 540);
            dgvMatriz.Height = n * (dgvMatriz.RowTemplate.Height + 2) + 6;

            var cardLeft = cardPanel.Left;
            var cardWidth = cardPanel.Width;
            dgvMatriz.Left = cardLeft + (cardWidth - dgvMatriz.Width) / 2;
            dgvMatriz.Top = cardPanel.Top + 48;

            if (dgvMatriz.Left < cardPanel.Left + 8) dgvMatriz.Left = cardPanel.Left + 8;

            for (int r = 0; r < n; r++)
            {
                dgvMatriz.Rows.Add();
                for (int c = 0; c < n + 1; c++)
                    dgvMatriz.Rows[r].Cells[c].Value = "0";
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
                    if (!double.TryParse(v.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double tmp))
                    {
                        MessageBox.Show($"Valor inválido en fila {r + 1}, columna {c + 1}. Ingresa solo números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;
        }

        private void DgvMatriz_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox tb)
            {
                tb.KeyPress -= Tb_KeyPress;
                tb.KeyPress += Tb_KeyPress;
            }
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
            if (!double.TryParse(s, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double v))
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
    }
}
