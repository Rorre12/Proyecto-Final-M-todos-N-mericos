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

        // UI dinámicos
        private Label lblTitle;
        private TextBox txtSteps;

        public Form15(double[,] matrizCoef, double[] vectorConst)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(18, 18, 22);

            // Estilo consistente del botón regresar (rojo)
            try
            {
                btnBack.UseVisualStyleBackColor = false;
                btnBack.BackColor = Color.FromArgb(200, 60, 80);
                btnBack.ForeColor = Color.White;
                btnBack.FlatStyle = FlatStyle.Flat;
                btnBack.FlatAppearance.BorderSize = 0;
            }
            catch { }

            // Intentar aplicar helpers visuales si existen (no requerido)
            try { VisualHelpers.ConfigureButtonVisualSimple(btnBack, Color.FromArgb(200, 60, 80), Color.FromArgb(170, 40, 60)); } catch { }

            // Datos de entrada
            A = (double[,])matrizCoef.Clone();
            b = (double[])vectorConst.Clone();
            n = A.GetLength(0);

            // Construcción UI y render
            BuildUI();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            LayoutUI();
            RenderSolution();
        }

        private void Form15_Resize(object sender, EventArgs e)
        {
            LayoutUI();
        }

        private void BuildUI()
        {
            // Título persistente
            lblTitle = new Label
            {
                Text = "Solucionador de Matriz Inversa por Cofactores",
                Font = new Font("Segoe UI", 18f, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                BackColor = Color.Transparent
            };
            if (!panelMain.Controls.Contains(lblTitle))
                panelMain.Controls.Add(lblTitle);

            // Caja donde se imprimen los pasos
            txtSteps = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Consolas", 11f),
                BackColor = Color.FromArgb(36, 36, 40),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            if (!panelMain.Controls.Contains(txtSteps))
                panelMain.Controls.Add(txtSteps);

            // Ubicar botón regresar dentro del panel y en primer plano
            if (!panelMain.Controls.Contains(btnBack))
                panelMain.Controls.Add(btnBack);
            btnBack.BringToFront();
        }

        private void LayoutUI()
        {
            int margin = 20;

            // Título centrado arriba
            lblTitle.Left = Math.Max(margin, (panelMain.ClientSize.Width - lblTitle.PreferredWidth) / 2);
            lblTitle.Top = 14;

            // Botón regresar arriba-derecha
            btnBack.Left = panelMain.ClientSize.Width - btnBack.Width - margin;
            btnBack.Top = 12;
            btnBack.BringToFront();

            // Caja de pasos debajo del título
            int txtTop = lblTitle.Bottom + 16;
            txtSteps.Left = margin;
            txtSteps.Top = txtTop;
            txtSteps.Width = Math.Max(640, panelMain.ClientSize.Width - margin * 2);
            txtSteps.Height = Math.Max(200, panelMain.ClientSize.Height - txtTop - margin);
        }

        private void RenderSolution()
        {
            var sb = new StringBuilder();
            if (n == 2)
            {
                sb.AppendLine("Matriz A:");
                sb.AppendLine(MatrixToString(A));

                double det = A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0];
                sb.AppendLine($"Determinante(A) = {det:0.######}");
                if (Math.Abs(det) < 1e-12)
                {
                    sb.AppendLine("La matriz no es invertible (det = 0).");
                    txtSteps.Text = sb.ToString();
                    return;
                }

                sb.AppendLine("Matriz de cofactores C:");
                double[,] C = new double[2, 2]
                {
                    {  A[1,1], -A[1,0] },
                    { -A[0,1],  A[0,0] }
                };
                sb.AppendLine(MatrixToString(C));

                sb.AppendLine("Adjunta(A) = C^T:");
                var adj = Transponer(C);
                sb.AppendLine(MatrixToString(adj));

                sb.AppendLine("A^{-1} = (1/det) · Adj(A):");
                var inv = Escalar(adj, 1.0 / det);
                sb.AppendLine(MatrixToString(inv));

                sb.AppendLine("Solución x = A^{-1} · b:");
                var x = MulMatVec(inv, b);
                for (int i = 0; i < x.Length; i++) sb.AppendLine($"x{i + 1} = {x[i]:0.#####}");
            }
            else
            {
                sb.AppendLine("Matriz A:");
                sb.AppendLine(MatrixToString(A));

                double det = Determinante3x3(A);
                sb.AppendLine($"Determinante(A) = {det:0.######}");
                if (Math.Abs(det) < 1e-12)
                {
                    sb.AppendLine("La matriz no es invertible (det = 0).");
                    txtSteps.Text = sb.ToString();
                    return;
                }

                sb.AppendLine("Matriz de cofactores C:");
                var C = Cofactores3x3(A);
                sb.AppendLine(MatrixToString(C));

                sb.AppendLine("Adjunta(A) = C^T:");
                var adj = Transponer(C);
                sb.AppendLine(MatrixToString(adj));

                sb.AppendLine("A^{-1} = (1/det) · Adj(A):");
                var inv = Escalar(adj, 1.0 / det);
                sb.AppendLine(MatrixToString(inv));

                sb.AppendLine("Solución x = A^{-1} · b:");
                var x = MulMatVec(inv, b);
                for (int i = 0; i < x.Length; i++) sb.AppendLine($"x{i + 1} = {x[i]:0.#####}");
            }

            txtSteps.Text = sb.ToString();
        }

        // Utilidades de álgebra
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

        private double[,] Transponer(double[,] m)
        {
            int r = m.GetLength(0), c = m.GetLength(1);
            double[,] t = new double[c, r];
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    t[j, i] = m[i, j];
            return t;
        }

        private double[,] Escalar(double[,] m, double k)
        {
            int r = m.GetLength(0), c = m.GetLength(1);
            double[,] res = new double[r, c];
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    res[i, j] = m[i, j] * k;
            return res;
        }

        private double[] MulMatVec(double[,] m, double[] v)
        {
            int r = m.GetLength(0), c = m.GetLength(1);
            var res = new double[r];
            for (int i = 0; i < r; i++)
            {
                double acc = 0;
                for (int j = 0; j < c; j++)
                    acc += m[i, j] * v[j];
                res[i] = acc;
            }
            return res;
        }

        private double Determinante3x3(double[,] m)
        {
            return m[0, 0] * (m[1, 1] * m[2, 2] - m[1, 2] * m[2, 1])
                 - m[0, 1] * (m[1, 0] * m[2, 2] - m[1, 2] * m[2, 0])
                 + m[0, 2] * (m[1, 0] * m[2, 1] - m[1, 1] * m[2, 0]);
        }

        private double[,] Cofactores3x3(double[,] m)
        {
            double[,] c = new double[3, 3];
            c[0, 0] =  (m[1, 1] * m[2, 2] - m[1, 2] * m[2, 1]);
            c[0, 1] = -(m[1, 0] * m[2, 2] - m[1, 2] * m[2, 0]);
            c[0, 2] =  (m[1, 0] * m[2, 1] - m[1, 1] * m[2, 0]);

            c[1, 0] = -(m[0, 1] * m[2, 2] - m[0, 2] * m[2, 1]);
            c[1, 1] =  (m[0, 0] * m[2, 2] - m[0, 2] * m[2, 0]);
            c[1, 2] = -(m[0, 0] * m[2, 1] - m[0, 1] * m[2, 0]);

            c[2, 0] =  (m[0, 1] * m[1, 2] - m[0, 2] * m[1, 1]);
            c[2, 1] = -(m[0, 0] * m[1, 2] - m[0, 2] * m[1, 0]);
            c[2, 2] =  (m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0]);
            return c;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Cierra el solucionador (Form14 re-aparecerá porque lo abrió modalmente)
            this.Close();
        }
    }
}