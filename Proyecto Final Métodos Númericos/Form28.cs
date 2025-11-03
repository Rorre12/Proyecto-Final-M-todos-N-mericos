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
    public partial class Form28 : Form
    {
        public Form28()
        {
            InitializeComponent();
            panel3.Visible = false;
            panel4.Visible = false;
        }

        public Form28(string funcion) : this()
        {
            lblFuncionRecibida.Text = funcion;
        }

        private void btnEvaluar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Verifica tu función");

            // Validar y convertir coeficientes
            double a = LeerCoeficiente(txta0, "a₀");
            double a1 = LeerCoeficiente(txta1, "a₁");
            double a2 = LeerCoeficiente(txta2, "a₂");
            double a3 = LeerCoeficiente(txta3, "a₃");
            double a4 = LeerCoeficiente(txta4, "a₄");

            if (a == 0 && a1 == 0 && a2 == 0 && a3 == 0 && a4 == 0)
            {
                MessageBox.Show("La función no puede ser 0 en todos los términos.", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (a1 == 0 && a2 == 0 && a3 == 0 && a4 == 0)
            {
                MessageBox.Show("La función debe tener al menos un término con potencia.", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            panel3.Visible = true;
            panel4.Visible = true;

            // Construir la función como texto
            string resultado = "";

            if (a4 != 0)
                resultado += FormatearTermino(a4, "x⁴");

            if (a3 != 0)
                resultado += FormatearConSigno(resultado, a3, "x³");

            if (a2 != 0)
                resultado += FormatearConSigno(resultado, a2, "x²");

            if (a1 != 0)
                resultado += FormatearConSigno(resultado, a1, "x");

            if (a != 0)
                resultado += FormatearConSigno(resultado, a, "");

            lblResultado.Text = string.IsNullOrWhiteSpace(resultado) ? "0" : resultado;
        }

        private void lblLimpiar1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vuelve a insertar los coeficientes.");
            txta0.Clear();
            txta1.Clear();
            txta2.Clear();
            txta3.Clear();
            txta4.Clear();
            lblResultado.Text = "Inserta de nuevo";
        }

        private void lblLimpiar2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vuelve a insertar los límites.");
            txtL1.Clear();
            txtL2.Clear();
        }

        private void btnContinuar1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtL1.Text) || string.IsNullOrWhiteSpace(txtL2.Text))
            {
                MessageBox.Show("Debes ingresar los límites (L1 y L2).", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!double.TryParse(txtL1.Text, out double l1) || !double.TryParse(txtL2.Text, out double l2))
            {
                MessageBox.Show("Los límites deben ser números válidos.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double a0 = LeerCoeficiente(txta0, "a₀");
            double a1 = LeerCoeficiente(txta1, "a₁");
            double a2 = LeerCoeficiente(txta2, "a₂");
            double a3 = LeerCoeficiente(txta3, "a₃");
            double a4 = LeerCoeficiente(txta4, "a₄");

            this.Hide();
            try
            {
                using (var form29 = new Form29(lblResultado.Text, lblFuncionRecibida.Text, a0, a1, a2, a3, a4, l1, l2))
                {
                    form29.StartPosition = FormStartPosition.CenterParent;
                    form29.ShowDialog(this);
                }
            }
            finally { try { this.Show(); } catch { } }
        }

        // Función auxiliar para validar coeficientes
        private double LeerCoeficiente(TextBox txt, string nombre)
        {
            if (string.IsNullOrWhiteSpace(txt.Text)) return 0;

            if (!double.TryParse(txt.Text, out double valor))
            {
                MessageBox.Show($"El valor de {nombre} no es válido. Usa formato decimal (ej. 3.14)", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new FormatException();
            }

            return valor;
        }

        // Formatea el primer término sin signo
        private string FormatearTermino(double coef, string variable)
        {
            if (coef == 1) return variable;
            if (coef == -1) return "-" + variable;
            return coef.ToString("0.##") + variable;
        }

        // Formatea términos con signo según posición
        private string FormatearConSigno(string anterior, double coef, string variable)
        {
            string signo = coef > 0 ? " + " : " - ";
            double valor = Math.Abs(coef);

            if (valor == 1 && !string.IsNullOrEmpty(variable))
                return signo + variable;

            return signo + valor.ToString("0.##") + variable;
        }
    }
}