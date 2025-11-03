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
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
            panel3.Visible = false;
            panel4.Visible = false;
        }

        public Form21(string funcion) : this()
        {
            lblFuncionRecibida.Text = funcion;
        }

        private void btnEvaluar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Verifica tu funcion");
            // Convertir valores
            int a = string.IsNullOrWhiteSpace(txta0.Text) ? 0 : int.Parse(txta0.Text);
            int a1 = string.IsNullOrWhiteSpace(txta1.Text) ? 0 : int.Parse(txta1.Text);
            int a2 = string.IsNullOrWhiteSpace(txta2.Text) ? 0 : int.Parse(txta2.Text);
            int a3 = string.IsNullOrWhiteSpace(txta3.Text) ? 0 : int.Parse(txta3.Text);
            int a4 = string.IsNullOrWhiteSpace(txta4.Text) ? 0 : int.Parse(txta4.Text);

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

            // Construir la función
            string resultado = "";

            if (a4 != 0)
                resultado += (a4 == 1 ? "x⁴" : a4 == -1 ? "-x⁴" : a4 + "x⁴");

            if (a3 != 0)
            {
                if (resultado != "")
                    resultado += (a3 > 0 ? " + " : " - ");
                int valor = Math.Abs(a3);
                resultado += (valor == 1 ? "x³" : valor + "x³");
            }

            if (a2 != 0)
            {
                if (resultado != "")
                    resultado += (a2 > 0 ? " + " : " - ");
                int valor = Math.Abs(a2);
                resultado += (valor == 1 ? "x²" : valor + "x²");
            }

            if (a1 != 0)
            {
                if (resultado != "")
                    resultado += (a1 > 0 ? " + " : " - ");
                int valor = Math.Abs(a1);
                resultado += (valor == 1 ? "x" : valor + "x");
            }

            if (a != 0)
            {
                if (resultado != "")
                    resultado += (a > 0 ? " + " : " - ");
                resultado += Math.Abs(a).ToString();
            }

            lblResultado.Text = resultado == "" ? "0" : resultado;
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

            double a0 = string.IsNullOrWhiteSpace(txta0.Text) ? 0 : Convert.ToDouble(txta0.Text);
            double a1 = string.IsNullOrWhiteSpace(txta1.Text) ? 0 : Convert.ToDouble(txta1.Text);
            double a2 = string.IsNullOrWhiteSpace(txta2.Text) ? 0 : Convert.ToDouble(txta2.Text);
            double a3 = string.IsNullOrWhiteSpace(txta3.Text) ? 0 : Convert.ToDouble(txta3.Text);
            double a4 = string.IsNullOrWhiteSpace(txta4.Text) ? 0 : Convert.ToDouble(txta4.Text);

            // Abrir soluciones de forma modal para mantener un solo form visible
            this.Hide();
            try
            {
                using (var form22 = new Form22(lblResultado.Text, lblFuncionRecibida.Text,
                                             a0, a1, a2, a3, a4, l1, l2))
                {
                    form22.StartPosition = FormStartPosition.CenterParent;
                    form22.ShowDialog(this);
                }
            }
            finally
            {
                try { this.Show(); } catch { }
            }
        }
    }
}