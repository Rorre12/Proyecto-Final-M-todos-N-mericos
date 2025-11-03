using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form11 : Form
    {
        private double[,] aug; // matriz aumentada n x (n+1)

        public Form11(double[,] augmentedMatrix)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(18, 18, 22);
            lblHeader.Parent = mainPanel; lblHeader.BringToFront(); lblHeader.BackColor = Color.Transparent;
            solverPanel.Parent = mainPanel; solverPanel.BringToFront();

            aug = (double[,])augmentedMatrix.Clone();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            // ejecutar y mostrar pasos
            try
            {
                var steps = SolveGaussian(aug);
                rtbSteps.Clear();
                foreach (var s in steps)
                {
                    rtbSteps.AppendText(s + Environment.NewLine + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al resolver: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            using (var lg = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(12, 18, 30), Color.FromArgb(8, 10, 20), 45f))
                g.FillRectangle(lg, this.ClientRectangle);
        }

        // Algoritmo de eliminación Gaussiana con registro de pasos (partial pivoting)
        private System.Collections.Generic.List<string> SolveGaussian(double[,] A)
        {
            int n = A.GetLength(0);
            int m = A.GetLength(1); // n+1
            var steps = new System.Collections.Generic.List<string>();
            var M = (double[,])A.Clone();

            string PrintMatrix(double[,] mat)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < n; i++)
                {
                    sb.Append("| ");
                    for (int j = 0; j < m; j++)
                    {
                        sb.AppendFormat("{0,9:0.###}", mat[i, j]);
                        if (j < m - 1) sb.Append(" ");
                    }
                    sb.Append(" |");
                    if (i < n - 1) sb.AppendLine();
                }
                return sb.ToString();
            }

            steps.Add("Matriz inicial:");
            steps.Add(PrintMatrix(M));

            // Forward elimination
            for (int k = 0; k < n; k++)
            {
                // Partial pivot
                int maxRow = k;
                double maxVal = Math.Abs(M[k, k]);
                for (int i = k + 1; i < n; i++)
                {
                    if (Math.Abs(M[i, k]) > maxVal)
                    {
                        maxVal = Math.Abs(M[i, k]);
                        maxRow = i;
                    }
                }
                if (maxRow != k)
                {
                    // swap rows
                    for (int j = k; j < m; j++)
                    {
                        double tmp = M[k, j];
                        M[k, j] = M[maxRow, j];
                        M[maxRow, j] = tmp;
                    }
                    steps.Add($"Intercambio de filas {k + 1} y {maxRow + 1}:");
                    steps.Add(PrintMatrix(M));
                }

                if (Math.Abs(M[k, k]) < 1e-12)
                {
                    steps.Add($"Pivote nulo en columna {k + 1}. El sistema puede no tener solución única.");
                    continue;
                }

                // eliminate
                for (int i = k + 1; i < n; i++)
                {
                    double factor = M[i, k] / M[k, k];
                    for (int j = k; j < m; j++)
                    {
                        M[i, j] -= factor * M[k, j];
                    }
                    steps.Add($"Eliminando elemento ({i + 1},{k + 1}) usando factor {factor:0.###}:");
                    steps.Add(PrintMatrix(M));
                }
            }

            // Back substitution
            var x = new double[n];
            bool singular = false;
            for (int i = n - 1; i >= 0; i--)
            {
                double s = M[i, m - 1];
                double diag = M[i, i];
                for (int j = i + 1; j < n; j++)
                {
                    s -= M[i, j] * x[j];
                }
                if (Math.Abs(diag) < 1e-12)
                {
                    if (Math.Abs(s) < 1e-12)
                    {
                        steps.Add("Sistema dependiente: infinitas soluciones (detected).");
                        singular = true;
                        break;
                    }
                    else
                    {
                        steps.Add("Sistema inconsistente: sin solución.");
                        singular = true;
                        break;
                    }
                }
                x[i] = s / diag;
            }

            if (!singular)
            {
                steps.Add("Resultado (solución vector x):");
                var sb = new StringBuilder();
                for (int i = 0; i < n; i++)
                    sb.AppendLine($"x[{i + 1}] = {x[i]:0.######}");
                steps.Add(sb.ToString());
            }

            return steps;
        }
    }
}