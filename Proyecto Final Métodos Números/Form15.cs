using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form15 : Form
    {
        private double[,] A;
        private double[] b;
        private int n;
        private string pasos;
        private Label lblSolverTitle;

        public Form15(double[,] matrizCoef, double[] vectorConst)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(18, 18, 22);

            // asegurar boton regresar visible y en rojo
            try
            {
                btnBack.BackColor = Color.FromArgb(200, 60, 80);
                btnBack.ForeColor = Color.White;
                btnBack.FlatStyle = FlatStyle.Flat;
                btnBack.FlatAppearance.BorderSize = 0;
            }
            catch { }

            btnBack.BringToFront();
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBack.Left = this.ClientSize.Width - btnBack.Width - 20;
            btnBack.Top = 12;

            // crear label persistente con el título del solucionador (se mantiene siempre encima)
            lblSolverTitle = new Label
            {
                Text = "Solucionador de Inversa por Cofactores",
                Font = new Font("Segoe UI", 14f, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Left = 20,
                Top = 12
            };

            // añadir el label al panel principal (si el designer ya lo añadiera se evita duplicado)
            try
            {
                if (!panelMain.Controls.Contains(lblSolverTitle))
                    panelMain.Controls.Add(lblSolverTitle);
            }
            catch { }

            A = (double[,])matrizCoef.Clone();
            b = (double[])vectorConst.Clone();
            n = A.GetLength(0);

            CalcularYMostrar();
        }

        private void CalcularYMostrar()
        {
            pasos = "";
            if (n == 2)
            {
                // 2x2 paso a paso
                var sb = new StringBuilder();
                sb.AppendLine("Matriz A:");
                sb.AppendLine(MatrixToString(A));
                double det = A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0];
                sb.AppendLine($"Determinante = {det:0.######}");
                if (Math.Abs(det) < 1e-12)
                {
                    sb.AppendLine("La matriz no es invertible.");
                    MostrarTexto(sb.ToString());
                    return;
                }
                sb.AppendLine("Matriz de cofactores:");
                double[,] cof = new double[2, 2] { { A[1, 1], -A[1, 0] }, { -A[0, 1], A[0, 0] } };
                sb.AppendLine(MatrixToString(cof));
                sb.AppendLine("Adjunta (transpuesta de cofactores):");
                sb.AppendLine(MatrixToString(TransponerMatriz(cof)));
                var inv = Inversa2x2(A);
                sb.AppendLine("Matriz inversa (1/det * adjunta):");
                sb.AppendLine(MatrixToString(inv));
                var sol = MultiplicarMatrizPorVector(inv, b);
                sb.AppendLine("Soluciones (x = A^-1 * b):");
                for (int i = 0; i < sol.Length; i++) sb.AppendLine($"x{i + 1} = {sol[i]:0.#####}");
                pasos = sb.ToString();
                MostrarTexto(pasos);
            }
            else
            {
                var sb = new StringBuilder();
                sb.AppendLine("Matriz A:");
                sb.AppendLine(MatrixToString(A));
                double det = Determinante3x3(A);
                sb.AppendLine($"Determinante = {det:0.######}");
                if (Math.Abs(det) < 1e-12)
                {
                    sb.AppendLine("La matriz no es invertible.");
                    MostrarTexto(sb.ToString());
                    return;
                }
                sb.AppendLine("Matriz de cofactores:");
                var cof = ObtenerMatrizCofactores(A);
                sb.AppendLine(MatrixToString(cof));
                sb.AppendLine("Adjunta (transpuesta de cofactores):");
                var adj = TransponerMatriz(cof);
                sb.AppendLine(MatrixToString(adj));
                sb.AppendLine("Matriz inversa (1/det * adjunta):");
                var inv = MultiplicarMatrizPorEscalar(adj, 1.0 / det);
                sb.AppendLine(MatrixToString(inv));
                var sol = MultiplicarMatrizPorVector(inv, b);
                sb.AppendLine("Soluciones (x = A^-1 * b):");
                for (int i = 0; i < sol.Length; i++) sb.AppendLine($"x{i + 1} = {sol[i]:0.#####}");
                pasos = sb.ToString();
                MostrarTexto(pasos);
            }
        }

        private void MostrarTexto(string t)
        {
            panelMain.Controls.Clear();

            // 🔹 Label superior elegante y fijo
            lblSolverTitle = new Label
            {
                Text = "Solucionador de Matriz Inversa por Cofactores",
                Font = new Font("Segoe UI", 18f, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Centrar horizontalmente el título dentro del panel
            lblSolverTitle.Left = (panelMain.ClientSize.Width - lblSolverTitle.PreferredWidth) / 2;
            lblSolverTitle.Top = 15;

            panelMain.Controls.Add(lblSolverTitle);

            // 🔹 Caja de texto con los pasos (justo debajo del título)
            var txt = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Consolas", 11f),
                BackColor = Color.FromArgb(36, 36, 40),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Left = 20,
                Top = lblSolverTitle.Bottom + 20,
                Width = Math.Max(640, this.ClientSize.Width - 80),
                Height = this.ClientSize.Height - lblSolverTitle.Height - 120,
                Text = t
            };
            panelMain.Controls.Add(txt);

            // 🔹 Línea decorativa debajo del título (opcional, da un toque profesional)
            Panel lineaDecorativa = new Panel
            {
                BackColor = Color.White,
                Height = 2,
                Width = panelMain.ClientSize.Width - 80,
                Left = 40,
                Top = lblSolverTitle.Bottom + 10
            };
            panelMain.Controls.Add(lineaDecorativa);
            lineaDecorativa.BringToFront();

            // 🔹 Botón de regresar visible y fijo arriba a la derecha
            if (!panelMain.Controls.Contains(btnBack))
                panelMain.Controls.Add(btnBack);

            btnBack.BringToFront();
            btnBack.Left = panelMain.ClientSize.Width - btnBack.Width - 20;
            btnBack.Top = 15;
        }



        private string MatrixToString(double[,] m)
        {
            var sb = new StringBuilder();
            int r = m.GetLength(0), c = m.GetLength(1);
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++) sb.Append($"{m[i, j],10:0.###}");
                sb.AppendLine();
            }
            sb.AppendLine();
            return sb.ToString();
        }

        private double[,] Inversa2x2(double[,] m)
        {
            double det = m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0];
            double invDet = 1.0 / det;
            return new double[,] { { m[1, 1] * invDet, -m[0, 1] * invDet }, { -m[1, 0] * invDet, m[0, 0] * invDet } };
        }

        private double Determinante3x3(double[,] m)
        {
            return m[0, 0] * (m[1, 1] * m[2, 2] - m[1, 2] * m[2, 1])
                 - m[0, 1] * (m[1, 0] * m[2, 2] - m[1, 2] * m[2, 0])
                 + m[0, 2] * (m[1, 0] * m[2, 1] - m[1, 1] * m[2, 0]);
        }

        // (Resto de métodos auxiliares: ObtenerMatrizCofactores, TransponerMatriz, etc.)
        private double[,] ObtenerMatrizCofactores(double[,] m)
        {
            double[,] cofactores = new double[3, 3];
            cofactores[0, 0] = (m[1, 1] * m[2, 2] - m[1, 2] * m[2, 1]);
            cofactores[0, 1] = -(m[1, 0] * m[2, 2] - m[1, 2] * m[2, 0]);
            cofactores[0, 2] = (m[1, 0] * m[2, 1] - m[1, 1] * m[2, 0]);
            cofactores[1, 0] = -(m[0, 1] * m[2, 2] - m[0, 2] * m[2, 1]);
            cofactores[1, 1] = (m[0, 0] * m[2, 2] - m[0, 2] * m[2, 0]);
            cofactores[1, 2] = -(m[0, 0] * m[2, 1] - m[0, 1] * m[2, 0]);
            cofactores[2, 0] = (m[0, 1] * m[1, 2] - m[0, 2] * m[1, 1]);
            cofactores[2, 1] = -(m[0, 0] * m[1, 2] - m[0, 2] * m[1, 0]);
            cofactores[2, 2] = (m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0]);
            return cofactores;
        }

        private double[,] TransponerMatriz(double[,] m)
        {
            double[,] t = new double[m.GetLength(1), m.GetLength(0)];
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                    t[j, i] = m[i, j];
            return t;
        }

        private double[,] MultiplicarMatrizPorEscalar(double[,] m, double esc)
        {
            var res = new double[m.GetLength(0), m.GetLength(1)];
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                    res[i, j] = m[i, j] * esc;
            return res;
        }

        private double[] MultiplicarMatrizPorVector(double[,] m, double[] v)
        {
            var res = new double[m.GetLength(0)];
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                    res[i] += m[i, j] * v[j];
            return res;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}