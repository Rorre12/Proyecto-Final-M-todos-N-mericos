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
    public partial class Form25 : Form
    {
        public Form25()
        {
            InitializeComponent();
            panel3.Visible = false;
            panel4.Visible = false;
        }
        public Form25(string funcion) : this()
        {
            lblFuncionRecibida.Text = funcion;
        }

        private void btnEvaluar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Verifica tu funcion");
            // Obtener coeficientes
            int a0 = string.IsNullOrWhiteSpace(txta0.Text) ? 0 : int.Parse(txta0.Text);  // término independiente
            int a1 = string.IsNullOrWhiteSpace(txta1.Text) ? 0 : int.Parse(txta1.Text);  // coeficiente de x

            if (a0 == 0 && a1 == 0)
            {
                MessageBox.Show("La función no puede ser 0 completamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (a1 == 0)
            {
                MessageBox.Show("Debe haber al menos un término con x.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mostrar función formateada
            string resultado = "";
            resultado += (a1 == 1) ? "x" : (a1 == -1 ? "-x" : $"{a1}x");

            if (a0 != 0)
                resultado += a0 > 0 ? $" + {a0}" : $" - {Math.Abs(a0)}";

            lblResultado.Text = resultado;
            panel3.Visible = true;
            panel4.Visible = true;
        }

        private void btnContinuar1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtL1.Text, out double l1) || !double.TryParse(txtL2.Text, out double l2))
            {
                MessageBox.Show("Ingresa límites válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double a0 = string.IsNullOrWhiteSpace(txta0.Text) ? 0 : Convert.ToDouble(txta0.Text);
            double a1 = string.IsNullOrWhiteSpace(txta1.Text) ? 0 : Convert.ToDouble(txta1.Text);

            this.Hide();
            try
            {
                using (var form29 = new Form29(lblResultado.Text, lblFuncionRecibida.Text, a0, a1, l1, l2))
                {
                    form29.StartPosition = FormStartPosition.CenterParent;
                    form29.ShowDialog(this);
                }
            }
            finally { try { this.Show(); } catch { } }
        }

        private void lblLimpiar1_Click(object sender, EventArgs e)
        {
            txta0.Clear();
            txta0.Clear();
            lblResultado.Text = "Inserta de nuevo";
            panel4.Visible = false;
        }

        private void lblLimpiar2_Click(object sender, EventArgs e)
        {
            txtL1.Clear();
            txtL2.Clear();
        }

    }
}