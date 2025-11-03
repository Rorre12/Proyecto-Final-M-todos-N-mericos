using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form29 : Form
    {
        private string funcionFormateada;
        private string funcionOriginal;
        private double c0, c1, c2, c3, c4;
        private double limite1, limite2;
        private int grado;

        private Form29()
        {
            InitializeComponent();
        }

        public Form29(string funcionFormateada, string funcionOriginal,
                          double c0, double c1,
                          double limite1, double limite2)
            : this()
        {
            this.funcionFormateada = funcionFormateada;
            this.funcionOriginal = funcionOriginal;
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = this.c3 = this.c4 = 0;
            this.limite1 = limite1;
            this.limite2 = limite2;
            this.grado = 1;
            ConfigurarInterfaz();
        }

        public Form29(string funcionFormateada, string funcionOriginal,
                          double c0, double c1, double c2,
                          double limite1, double limite2)
            : this()
        {
            this.funcionFormateada = funcionFormateada;
            this.funcionOriginal = funcionOriginal;
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = this.c4 = 0;
            this.limite1 = limite1;
            this.limite2 = limite2;
            this.grado = 2;
            ConfigurarInterfaz();
        }

        public Form29(string funcionFormateada, string funcionOriginal,
                          double c0, double c1, double c2, double c3,
                          double limite1, double limite2)
            : this()
        {
            this.funcionFormateada = funcionFormateada;
            this.funcionOriginal = funcionOriginal;
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
            this.c4 = 0;
            this.limite1 = limite1;
            this.limite2 = limite2;
            this.grado = 3;
            ConfigurarInterfaz();
        }

        public Form29(string funcionFormateada, string funcionOriginal,
                          double c0, double c1, double c2, double c3, double c4,
                          double limite1, double limite2)
            : this()
        {
            this.funcionFormateada = funcionFormateada;
            this.funcionOriginal = funcionOriginal;
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
            this.c4 = c4;
            this.limite1 = limite1;
            this.limite2 = limite2;
            this.grado = 4;
            ConfigurarInterfaz();
        }

        private void Soluciones_Load(object sender, EventArgs e) { }

        private void txtError_TextChanged(object sender, EventArgs e) { }

        private void dgvReglaFalsa_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void EstilizarDataGridView()
        {
            dgvReglaFalsa.BorderStyle = BorderStyle.None;
            dgvReglaFalsa.BackgroundColor = Color.FromArgb(20, 18, 46);
            dgvReglaFalsa.EnableHeadersVisualStyles = false;

            dgvReglaFalsa.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 70);
            dgvReglaFalsa.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReglaFalsa.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgvReglaFalsa.ColumnHeadersHeight = 40;
            dgvReglaFalsa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvReglaFalsa.DefaultCellStyle.BackColor = Color.FromArgb(35, 33, 70);
            dgvReglaFalsa.DefaultCellStyle.ForeColor = Color.White;
            dgvReglaFalsa.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            dgvReglaFalsa.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 120);
            dgvReglaFalsa.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvReglaFalsa.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(40, 38, 80);
            dgvReglaFalsa.GridColor = Color.FromArgb(50, 50, 90);
            dgvReglaFalsa.RowHeadersVisible = false;
            dgvReglaFalsa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvReglaFalsa.AllowUserToAddRows = false;
            dgvReglaFalsa.ReadOnly = true;
        }

        private void ConfigurarInterfaz()
        {
            lblInfo.Text = $"Método de Regla Falsa\nFunción: {funcionFormateada}   Límites: [{limite1:F3} , {limite2:F3}]\n\n";

            dgvReglaFalsa.ColumnCount = 8;
            dgvReglaFalsa.Columns[0].Name = "i";
            dgvReglaFalsa.Columns[1].Name = "a";
            dgvReglaFalsa.Columns[2].Name = "b";
            dgvReglaFalsa.Columns[3].Name = "f(a)";
            dgvReglaFalsa.Columns[4].Name = "f(b)";
            dgvReglaFalsa.Columns[5].Name = "xi";
            dgvReglaFalsa.Columns[6].Name = "f(xi)";
            dgvReglaFalsa.Columns[7].Name = "E";

            dgvReglaFalsa.Visible = false;
            EstilizarDataGridView();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            dgvReglaFalsa.Visible = true;

            // Validar el error ingresado
            if (string.IsNullOrWhiteSpace(txtError.Text) || !double.TryParse(txtError.Text, out double tolerancia))
            {
                MessageBox.Show("Ingresa un valor de error válido en txtError", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double A = limite1;
            double B = limite2;
            double xi = 0, xiAnterior = 0;
            double fa, fb, fxi;
            double error = 100;

            dgvReglaFalsa.Rows.Clear();
            int iteracion = 1;
            int maxIteraciones = 1000;

            fa = EvaluarFuncion(A);
            fb = EvaluarFuncion(B);

            // Validación de signos con opción de continuar
            if (fa * fb > 0)
            {
                DialogResult respuesta = MessageBox.Show(
                    "Advertencia: f(a) y f(b) tienen el mismo signo.\n" +
                    "Probablemente no exista una raíz en este intervalo.\n\n¿Deseas continuar de todos modos?",
                    "Atención",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (respuesta == DialogResult.No)
                    return; // El usuario decide no continuar
            }

            // Iteraciones del método Regula Falsi
            do
            {
                fa = EvaluarFuncion(A);
                fb = EvaluarFuncion(B);
                xi = B - (fb * (A - B)) / (fa - fb);
                fxi = EvaluarFuncion(xi);

                if (iteracion == 1 && fxi == 0)
                {
                    dgvReglaFalsa.Rows.Add(
                        iteracion,
                        A.ToString("F3"),
                        B.ToString("F3"),
                        fa.ToString("F3"),
                        fb.ToString("F3"),
                        xi.ToString("F3"),
                        fxi.ToString("F3"),
                        "0.000"
                    );

                    lblRaiz.Text = $"Raíz exacta encontrada en la primera iteración: {xi:F3}";

                    DataGridViewCell celdaXi = dgvReglaFalsa.Rows[0].Cells[5];
                    celdaXi.Style.BackColor = Color.FromArgb(255, 215, 0);
                    celdaXi.Style.ForeColor = Color.Black;
                    celdaXi.Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                    return;
                }

                error = Math.Abs(xi - xiAnterior) / Math.Abs(xi);

                dgvReglaFalsa.Rows.Add(
                    iteracion,
                    A.ToString("F3"),
                    B.ToString("F3"),
                    fa.ToString("F3"),
                    fb.ToString("F3"),
                    xi.ToString("F3"),
                    fxi.ToString("F3"),
                    error.ToString("F3")
                );

                if (error < tolerancia) break;

                if (fa * fxi < 0)
                    B = xi;
                else
                    A = xi;

                xiAnterior = xi;
                iteracion++;

            } while (iteracion <= maxIteraciones);

            lblRaiz.Text = $"Raíz aproximada: {xi:F3}";

            int ultimaFilaIndex = dgvReglaFalsa.Rows.Count - 1;
            if (ultimaFilaIndex >= 0)
            {
                DataGridViewCell celdaXi = dgvReglaFalsa.Rows[ultimaFilaIndex].Cells[5];
                celdaXi.Style.BackColor = Color.FromArgb(255, 215, 0);
                celdaXi.Style.ForeColor = Color.Black;
                celdaXi.Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }
        }

        private double EvaluarFuncion(double x)
        {
            double resultado = 0;

            if (grado >= 1) resultado += c1 * x + c0;
            if (grado >= 2) resultado += c2 * Math.Pow(x, 2);
            if (grado >= 3) resultado += c3 * Math.Pow(x, 3);
            if (grado == 4) resultado += c4 * Math.Pow(x, 4);

            return resultado;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            // this.Owner = Form25/26/27/28 (quien abrió este Form29)
            var parent = this.Owner as Form;
            var grandParent = parent?.Owner as Form; // debería ser Form24

            // Mostrar el Form24 si existe en la cadena modal
            if (grandParent != null)
            {
                try { grandParent.Show(); } catch { }
                try { parent?.Close(); } catch { } // cierra el intermedio
                this.Close();                       // cierra el solucionador
                return;
            }

            // Fallback: buscar un Form24 oculto en la app (por seguridad)
            foreach (Form f in Application.OpenForms)
            {
                if (f is Form24)
                {
                    try { f.Show(); } catch { }
                    break;
                }
            }
            this.Close();
        }
    }
}
