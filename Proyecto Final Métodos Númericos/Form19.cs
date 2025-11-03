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
    public partial class Form19 : Form
    {

        public Form19()
        {
            InitializeComponent();
            panel3.Visible = false;
            panel4.Visible = false;


        }
        public Form19(string funcion) : this()
        {
            lblFuncionRecibida.Text = funcion;
        }


        private void btnEvaluar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Verifica tu funcion");
            // Convertir valores: si el TextBox está vacío, se toma como0
            int a = string.IsNullOrWhiteSpace(txta1.Text) ?0 : int.Parse(txta1.Text); // término independiente
            int a1 = string.IsNullOrWhiteSpace(txta2.Text) ?0 : int.Parse(txta2.Text); // coeficiente de x
            int a2 = string.IsNullOrWhiteSpace(txta3.Text) ?0 : int.Parse(txta3.Text); // coeficiente de x^2

            // Validar que no estén todos en0
            if (a ==0 && a1 ==0 && a2 ==0)
            {
                MessageBox.Show("La función no puede ser0 en todos los términos. Ingresa algún valor.",
 "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // aquí se corta y NO muestra paneles
            }

            // Validar que al menos a1 o a2 tengan valor
            if (a1 ==0 && a2 ==0)
            {
                MessageBox.Show("La función debe tener al menos un término con potencia (x o x²).",
 "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // aquí se corta y NO muestra paneles
            }

            // ✅ Sólo si pasa validaciones se muestran los paneles
            panel3.Visible = true;
            panel4.Visible = true;

            // Construir la expresión
            string resultado = "";

            // Término cuadrático
            if (a2 !=0)
            {
                resultado += (a2 ==1 ? "x²" : a2 == -1 ? "-x²" : a2 + "x²");
            }

            // Término lineal
            if (a1 !=0)
            {
                if (resultado != "")
                    resultado += (a1 >0 ? " + " : " - ");

                int valor = Math.Abs(a1);
                resultado += (valor ==1 ? "x" : valor + "x");
            }

            // Término independiente
            if (a !=0)
            {
                if (resultado != "")
                    resultado += (a >0 ? " + " : " - ");

                resultado += Math.Abs(a).ToString();
            }

            // Mostrar en el label
            lblResultado.Text = resultado == "" ? "0" : resultado;


        }

        private void lblLimpiar1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vuelve a instertar los datos");
            // Limpiar los TextBox
            txta1.Clear();
            txta2.Clear();
            txta3.Clear();

            // Limpiar el Label
            lblResultado.Text = "Inserta de nuevo";
        }



        private void lblLimpiar2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vuelve a instertar los limites");
            txtL1.Clear();
            txtL2.Clear();
        }

        private void btnContinuar1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtL1.Text) || string.IsNullOrWhiteSpace(txtL2.Text))
            {
                MessageBox.Show("Debes ingresar los límites (L1 y L2).",
 "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Usar double.TryParse para mayor robustez
            if (!double.TryParse(txtL1.Text, out double l1) || !double.TryParse(txtL2.Text, out double l2))
            {
                MessageBox.Show("Los límites deben ser números válidos.",
 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Coeficientes: permitir decimales también
            double a = string.IsNullOrWhiteSpace(txta1.Text) ?0 : (double)Convert.ToDouble(txta1.Text);
            double a1 = string.IsNullOrWhiteSpace(txta2.Text) ?0 : (double)Convert.ToDouble(txta2.Text);
            double a2 = string.IsNullOrWhiteSpace(txta3.Text) ?0 : (double)Convert.ToDouble(txta3.Text);

            // Llamamos al constructor que recibe todos los valores (orden: funcionFormateada, funcionOriginal, a, a1, a2, l1, l2)
 this.Hide();
 try
 {
 using (var form22 = new Form22(lblResultado.Text, lblFuncionRecibida.Text,
 a, a1, a2, l1, l2))
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