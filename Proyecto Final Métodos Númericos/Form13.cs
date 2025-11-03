using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form13 : Form
    {
        private double[,] originalMatrix;
        private double[,] inverseMatrix;
        private string pasosGaussJordan;
        private int n;

        public Form13(double[,] matrix)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(18, 18, 22);

            // Estilo del botón (si tienes el helper)
            try { VisualHelpers.ConfigureButtonVisualSimple(btnBack, Color.FromArgb(200, 60, 80), Color.FromArgb(170, 40, 60)); } catch { }

            // asegurar visibilidad y posición inicial del botón
            btnBack.Visible = true;
            btnBack.BringToFront();
            btnBack.Left = Math.Max(8, panelMain.ClientSize.Width - btnBack.Width - 20);
            btnBack.Top = 12;

            n = matrix.GetLength(0);
            originalMatrix = (double[,])matrix.Clone();

            CalcularInversaGaussJordan();
            MostrarResultados();
        }

        private void CalcularInversaGaussJordan()
        {
            int size = n;
            double[,] a = (double[,])originalMatrix.Clone();
            double[,] inv = new double[size, size];
            for (int i = 0; i < size; i++) inv[i, i] = 1.0;
            StringBuilder pasos = new StringBuilder();
            pasos.AppendLine("Matriz aumentada inicial:");
            pasos.AppendLine(MatrixToString(a, inv));

            for (int i = 0; i < size; i++)
            {
                // Pivot if needed
                if (Math.Abs(a[i, i]) < 1e-12)
                {
                    bool found = false;
                    for (int k = i + 1; k < size; k++)
                    {
                        if (Math.Abs(a[k, i]) > 1e-12)
                        {
                            SwapRows(a, i, k);
                            SwapRows(inv, i, k);
                            pasos.AppendLine($"Intercambio de fila {i + 1} con fila {k + 1}:");
                            pasos.AppendLine(MatrixToString(a, inv));
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        pasos.AppendLine("La matriz no es invertible (pivot cero).");
                        inverseMatrix = null;
                        pasosGaussJordan = pasos.ToString();
                        return;
                    }
                }

                // Normalize pivot row
                double diag = a[i, i];
                for (int j = 0; j < size; j++)
                {
                    a[i, j] /= diag;
                    inv[i, j] /= diag;
                }
                pasos.AppendLine($"Normalizando fila {i + 1}:");
                pasos.AppendLine(MatrixToString(a, inv));

                // Eliminate other rows
                for (int k = 0; k < size; k++)
                {
                    if (k == i) continue;
                    double factor = a[k, i];
                    for (int j = 0; j < size; j++)
                    {
                        a[k, j] -= factor * a[i, j];
                        inv[k, j] -= factor * inv[i, j];
                    }
                    pasos.AppendLine($"Eliminando columna {i + 1} de fila {k + 1} (factor {factor:0.###}):");
                    pasos.AppendLine(MatrixToString(a, inv));
                }
            }

            inverseMatrix = inv;
            pasos.AppendLine("Matriz inversa obtenida:");
            pasos.AppendLine(MatrixToString(inv));
            pasosGaussJordan = pasos.ToString();
        }

        private void SwapRows(double[,] m, int i, int k)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                double tmp = m[i, j];
                m[i, j] = m[k, j];
                m[k, j] = tmp;
            }
        }

        private string MatrixToString(double[,] a, double[,] b = null)
        {
            int size = a.GetLength(0);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    sb.Append($"{a[i, j],8:0.###}");
                if (b != null)
                {
                    sb.Append("  |");
                    for (int j = 0; j < size; j++)
                        sb.Append($"{b[i, j],8:0.###}");
                }
                sb.AppendLine();
            }
            sb.AppendLine();
            return sb.ToString();
        }

        // Método que arma la UI con matriz original a la izquierda, inversa a la derecha y pasos debajo
        private void MostrarResultados()
        {
            panelMain.SuspendLayout();
            panelMain.Controls.Clear();

            int margin = 20;
            int y = margin;

            // Título
            var lblTitulo = new Label
            {
                Text = "Inversa por Gauss-Jordan",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Left = margin,
                Top = y
            };
            panelMain.Controls.Add(lblTitulo);

            // Colocar el botón dentro de panelMain (de nuevo) y asegurarnos que esté visible
            panelMain.Controls.Add(btnBack);
            btnBack.BringToFront();
            btnBack.Left = panelMain.ClientSize.Width - btnBack.Width - margin;
            btnBack.Top = margin;

            // Mover y por debajo del título
            y += lblTitulo.Height + 12;

            // Área para matrices lado a lado (resto igual)
            int availableWidth = panelMain.ClientSize.Width - margin * 2;
            int cellW = 70, cellH = 36, gap = 8;
            int gridWidth = n * cellW + (n - 1) * gap + 8;
            int gridHeight = n * cellH + (n - 1) * gap + 8;
            bool sideBySide = (gridWidth * 2 + 24) <= availableWidth;

            if (sideBySide)
            {
                int totalMatricesWidth = gridWidth * 2 + 24;
                int leftStart = (panelMain.ClientSize.Width - totalMatricesWidth) / 2;

                var leftHolder = new Panel
                {
                    Left = leftStart,
                    Top = y,
                    Width = gridWidth,
                    Height = gridHeight + 28,
                    BackColor = Color.Transparent
                };
                var lblOrig = new Label
                {
                    Text = "Matriz original",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.FromArgb(120, 200, 255),
                    AutoSize = true,
                    Left = 0,
                    Top = 0
                };
                leftHolder.Controls.Add(lblOrig);
                leftHolder.Controls.Add(CrearGridMatrix(originalMatrix, 0, lblOrig.Height + 8));
                panelMain.Controls.Add(leftHolder);

                var rightHolder = new Panel
                {
                    Left = leftHolder.Right + 24,
                    Top = y,
                    Width = gridWidth,
                    Height = gridHeight + 28,
                    BackColor = Color.Transparent
                };
                var lblInv = new Label
                {
                    Text = "Matriz inversa",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.FromArgb(120, 255, 180),
                    AutoSize = true,
                    Left = 0,
                    Top = 0
                };
                rightHolder.Controls.Add(lblInv);
                if (inverseMatrix != null) rightHolder.Controls.Add(CrearGridMatrix(inverseMatrix, 0, lblInv.Height + 8));
                else
                {
                    var lblNoInv = new Label
                    {
                        Text = "La matriz no es invertible.",
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        ForeColor = Color.FromArgb(255, 120, 120),
                        AutoSize = true,
                        Left = 0,
                        Top = lblInv.Height + 8
                    };
                    rightHolder.Controls.Add(lblNoInv);
                }
                panelMain.Controls.Add(rightHolder);

                y += Math.Max(leftHolder.Height, rightHolder.Height) + 12;
            }
            else
            {
                var topHolder = new Panel
                {
                    Left = (panelMain.ClientSize.Width - gridWidth) / 2,
                    Top = y,
                    Width = gridWidth,
                    Height = gridHeight + 28,
                    BackColor = Color.Transparent
                };
                var lblOrig = new Label
                {
                    Text = "Matriz original",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.FromArgb(120, 200, 255),
                    AutoSize = true,
                    Left = 0,
                    Top = 0
                };
                topHolder.Controls.Add(lblOrig);
                topHolder.Controls.Add(CrearGridMatrix(originalMatrix, 0, lblOrig.Height + 8));
                panelMain.Controls.Add(topHolder);
                y += topHolder.Height + 8;

                var bottomHolder = new Panel
                {
                    Left = (panelMain.ClientSize.Width - gridWidth) / 2,
                    Top = y,
                    Width = gridWidth,
                    Height = gridHeight + 28,
                    BackColor = Color.Transparent
                };
                var lblInv2 = new Label
                {
                    Text = "Matriz inversa",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.FromArgb(120, 255, 180),
                    AutoSize = true,
                    Left = 0,
                    Top = 0
                };
                bottomHolder.Controls.Add(lblInv2);
                if (inverseMatrix != null) bottomHolder.Controls.Add(CrearGridMatrix(inverseMatrix, 0, lblInv2.Height + 8));
                else
                {
                    var lblNoInv = new Label
                    {
                        Text = "La matriz no es invertible.",
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        ForeColor = Color.FromArgb(255, 120, 120),
                        AutoSize = true,
                        Left = 0,
                        Top = lblInv2.Height + 8
                    };
                    bottomHolder.Controls.Add(lblNoInv);
                }
                panelMain.Controls.Add(bottomHolder);
                y += bottomHolder.Height + 12;
            }

            var lblPasos = new Label
            {
                Text = "Pasos del método:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(180, 180, 255),
                AutoSize = true,
                Left = margin,
                Top = y
            };
            panelMain.Controls.Add(lblPasos);
            y += lblPasos.Height + 8;

            var txtPasos = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Consolas", 10, FontStyle.Regular),
                BackColor = Color.FromArgb(36, 36, 40),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Left = margin,
                Top = y,
                Width = Math.Max(360, panelMain.ClientSize.Width - margin * 2),
                Height = Math.Max(180, panelMain.ClientSize.Height - y - margin - 20),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top
            };
            txtPasos.Text = pasosGaussJordan ?? "";
            panelMain.Controls.Add(txtPasos);

            // asegurar que btnBack quede al frente y en su posición final
            btnBack.BringToFront();
            btnBack.Left = panelMain.ClientSize.Width - btnBack.Width - margin;
            btnBack.Top = margin;

            panelMain.ResumeLayout();
        }

        // Crea un panel con la representación tipo grid de la matriz (labels)
        private Panel CrearGridMatrix(double[,] matrix, int left, int top)
        {
            int size = matrix.GetLength(0);
            int cellW = 70, cellH = 36, gap = 8;
            var panel = new Panel
            {
                Left = left,
                Top = top,
                Width = size * cellW + (size - 1) * gap + 8,
                Height = size * cellH + (size - 1) * gap + 8,
                BackColor = Color.Transparent,
                AutoSize = false
            };
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var lbl = new Label
                    {
                        Text = matrix[i, j].ToString("0.###"),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Segoe UI", 12, FontStyle.Regular),
                        ForeColor = Color.White,
                        BackColor = Color.FromArgb(44, 44, 54),
                        Width = cellW,
                        Height = cellH,
                        Left = j * (cellW + gap),
                        Top = i * (cellH + gap),
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    panel.Controls.Add(lbl);
                }
            }
            return panel;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Cerrar Form13 para que el Form12 (que lo abrió modalmente) vuelva a mostrarse.
            this.Close();
        }
    }
}
