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
    public partial class Form22 : Form
    {
        private string funcionFormateada;
        private string funcionOriginal;

        //Coeficientes de la función (hasta grado 4)
        private double c0, c1, c2, c3, c4;
        private double limite1, limite2;
        private int grado; // Indica el grado de la función (1,2,3 o 4)

        //  Constructor privado (base)
        private Form22()
        {
            InitializeComponent();
        }

        // Constructor para grado 1: f(x) = c1*x + c0
        public Form22(string funcionFormateada, string funcionOriginal,
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

        //Constructor para grado 2: f(x) = c2*x² + c1*x + c0
        public Form22 (string funcionFormateada, string funcionOriginal,
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

        //Constructor para grado 3: f(x) = c3*x³ + c2*x² + c1*x + c0
        public Form22(string funcionFormateada, string funcionOriginal,
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

        //Constructor para grado 4: f(x) = c4*x⁴ + c3*x³ + c2*x² + c1*x + c0
        public Form22(string funcionFormateada, string funcionOriginal,
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

        //Evento de carga del formulario
        private void Soluciones_Load(object sender, EventArgs e) { }

        // Aplica estilos al DataGridView para mostrar la tabla bonita
        private void EstilizarDataGridView()
        {
            dgvBiseccion.BorderStyle = BorderStyle.None;
            dgvBiseccion.BackgroundColor = Color.FromArgb(20, 18, 46);
            dgvBiseccion.EnableHeadersVisualStyles = false;

            // Estilo del encabezado
            dgvBiseccion.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 70);
            dgvBiseccion.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBiseccion.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgvBiseccion.ColumnHeadersHeight = 40;
            dgvBiseccion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Estilo de celdas
            dgvBiseccion.DefaultCellStyle.BackColor = Color.FromArgb(35, 33, 70);
            dgvBiseccion.DefaultCellStyle.ForeColor = Color.White;
            dgvBiseccion.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            dgvBiseccion.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 120);
            dgvBiseccion.DefaultCellStyle.SelectionForeColor = Color.White;

            // Estilo de filas alternadas
            dgvBiseccion.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(40, 38, 80);

            // Otros ajustes
            dgvBiseccion.GridColor = Color.FromArgb(50, 50, 90);
            dgvBiseccion.RowHeadersVisible = false;
            dgvBiseccion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvBiseccion.AllowUserToAddRows = false;
            dgvBiseccion.ReadOnly = true;
        }

        //  Configura las columnas de la tabla y muestra la función con los límites
        private void ConfigurarInterfaz()
        {
            lblInfo.Text =
                $"Función: {this.funcionFormateada}   " +
                $"Límites: [{this.limite1} , {this.limite2}]\n\n";

            dgvBiseccion.ColumnCount = 8;
            dgvBiseccion.Columns[0].Name = "i";
            dgvBiseccion.Columns[1].Name = "a";
            dgvBiseccion.Columns[2].Name = "b";
            dgvBiseccion.Columns[3].Name = "f(a)";
            dgvBiseccion.Columns[4].Name = "f(b)";
            dgvBiseccion.Columns[5].Name = "xi";
            dgvBiseccion.Columns[6].Name = "f(xi)";
            dgvBiseccion.Columns[7].Name = "E";

            dgvBiseccion.Visible = false;
            EstilizarDataGridView();
        }

        // Botón para calcular la raíz con el método de Bisección
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            dgvBiseccion.Visible = true;

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

            dgvBiseccion.Rows.Clear();
            int iteracion = 1;
            int maxIteraciones = 1000;

            //  Verificar condición de Bolzano antes de comenzar
            fa = EvaluarFuncion(A);
            fb = EvaluarFuncion(B);

            if (fa * fb > 0)
            {
                MessageBox.Show(
                    "⚠️ Advertencia: f(a) y f(b) tienen el mismo signo.\n" +
                    "Probablemente no exista una raíz en este intervalo.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return; //Se corta el cálculo
            }

            // Ciclo de bisección
            do
            {
                fa = EvaluarFuncion(A);
                fb = EvaluarFuncion(B);
                xi = (A + B) / 2.0;
                fxi = EvaluarFuncion(xi);

                // Caso especial: encontramos la raíz exacta en la primera iteración
                if (iteracion == 1 && fxi == 0)
                {
                    dgvBiseccion.Rows.Add(
                        iteracion,
                        A.ToString("F10"),
                        B.ToString("F10"),
                        fa.ToString("F10"),
                        fb.ToString("F10"),
                        xi.ToString("F10"),
                        fxi.ToString("F10"),
                        "0.0000000000"
                    );

                    lblRaiz.Text = $"Raíz exacta encontrada en la primera iteración: {xi:F10}";

                    // Pintar celda dorada
                    DataGridViewCell celdaXi = dgvBiseccion.Rows[0].Cells[5];
                    celdaXi.Style.BackColor = Color.FromArgb(255, 215, 0);
                    celdaXi.Style.ForeColor = Color.Black;
                    celdaXi.Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                    return; // 🔹 Salimos de la función inmediatamente
                }

                //  Calcular error relativo
                if (xi == 0)
                    error = Math.Abs(xi - xiAnterior) * 100;
                else
                    error = Math.Abs((xi - xiAnterior) / xi) * 100;

                // Guardar resultados en la tabla
                dgvBiseccion.Rows.Add(
                    iteracion,
                    A.ToString("F10"),
                    B.ToString("F10"),
                    fa.ToString("F10"),
                    fb.ToString("F10"),
                    xi.ToString("F10"),
                    fxi.ToString("F10"),
                    error.ToString("F10")
                );

                if (error < tolerancia)
                    break;

                //Condición de Bolzano: escoger subintervalo correcto
                if (fa * fxi < 0)
                    B = xi;
                else
                    A = xi;

                xiAnterior = xi;
                iteracion++;

            } while (iteracion <= maxIteraciones);

            // Mostrar raíz aproximada
            lblRaiz.Text = $"Raíz aproximada: {xi:F10}";

            // Pintar última raíz en dorado
            int ultimaFilaIndex = dgvBiseccion.Rows.Count - 1;
            if (ultimaFilaIndex >= 0)
            {
                DataGridViewCell celdaXi = dgvBiseccion.Rows[ultimaFilaIndex].Cells[5];
                celdaXi.Style.BackColor = Color.FromArgb(255, 215, 0);
                celdaXi.Style.ForeColor = Color.Black;
                celdaXi.Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }
        }

        //Evalúa la función f(x) según el grado y los coeficientes
        private double EvaluarFuncion(double x)
        {
            double resultado = 0;

            if (grado >= 1) resultado += c1 * x + c0;
            if (grado >= 2) resultado += c2 * Math.Pow(x, 2);
            if (grado >= 3) resultado += c3 * Math.Pow(x, 3);
            if (grado == 4) resultado += c4 * Math.Pow(x, 4);

            return resultado;
        }

        // Botón Regresar: cerrar solo este form para volver al que lo abrió modalmente
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}