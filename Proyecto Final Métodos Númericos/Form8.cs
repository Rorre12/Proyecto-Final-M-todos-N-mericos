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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            // Close to return to the previous modal (Form7 will Show again)
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(a1.Text) ||
                string.IsNullOrWhiteSpace(a2.Text) ||
                string.IsNullOrWhiteSpace(b1.Text) ||
                string.IsNullOrWhiteSpace(b2.Text) ||
                string.IsNullOrWhiteSpace(c1.Text) ||
                string.IsNullOrWhiteSpace(c2.Text))
            {
                MessageBox.Show("No podemos procesar la operación sin valores. Por favor, rellene todos los campos.");
            }
            else
            {

                DialogResult respuesta = MessageBox.Show(
                "¿Los valores ingresados son correctos?",
                "Confirmar datos",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
);

                if (respuesta == DialogResult.No)
                {
                    MessageBox.Show("Proceso cancelado. Verifica los valores ingresados.");
                    return; // Detiene todo el cálculo
                }

                ///////////////////////////////////////////////////////////////////
                ////////////////////                              /////////////////
                ///////////////////     VERIFICACION DE DATOS    //////////////////
                //////////////////                              ///////////////////
                ///////////////////////////////////////////////////////////////////

                //verifica si no todo los valores son 0
                if (a1.Text == "0" && a2.Text == "0" &&
                     b1.Text == "0" && b2.Text == "0" &&
                     c1.Text == "0" && c2.Text == "0")
                {
                    MessageBox.Show("El sistema es inconsistente, vuelve a ingresar los valores");
                }

                //verifica si todos los operadores fueron seleccionados
                if (operador1.SelectedIndex == -1 || operador2.SelectedIndex == -1 || operador3.SelectedIndex == -1 || operador4.SelectedIndex == -1 || operador5.SelectedIndex == -1 || operador6.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un operador + o -");
                }

                //verifica si todos los campos tiene solo numeros
                double valor;
                if (!double.TryParse(a1.Text, out valor) ||
                    !double.TryParse(a2.Text, out valor) ||
                    !double.TryParse(b1.Text, out valor) ||
                    !double.TryParse(b2.Text, out valor) ||
                    !double.TryParse(c1.Text, out valor) ||
                    !double.TryParse(c2.Text, out valor))
                {
                    MessageBox.Show("Ingrese sólo números válidos en los campos.");
                }

                ///////////////////////////////////////////////////////////////////
                ////////////////////                              /////////////////
                ///////////////////  INICIA EL PROCESO DE DELTA  //////////////////
                //////////////////                              ///////////////////
                ///////////////////////////////////////////////////////////////////

                // Paso 1: Convertir y aplicar el signo según los operadores
                double A1 = double.Parse(a1.Text) * (operador1.Text == "-" ? -1 : 1);
                double A2 = double.Parse(a2.Text) * (operador2.Text == "-" ? -1 : 1);    //////////////////////////////////////
                double B1 = double.Parse(b1.Text) * (operador3.Text == "-" ? -1 : 1);    ///VARIABLES GENERALES, NO TOCAR!!!///
                double B2 = double.Parse(b2.Text) * (operador4.Text == "-" ? -1 : 1);    //////////////////////////////////////
                double C1 = double.Parse(c1.Text) * (operador5.Text == "-" ? -1 : 1);
                double C2 = double.Parse(c2.Text) * (operador6.Text == "-" ? -1 : 1);

                // Paso 2: Multiplicaciones
                double dd1 = A1 * B2;
                double dd2 = A2 * B1;

                // Guardamos el signo original de dd2
                bool dd2Negativo = dd2 < 0;

                // Invertimos el signo de dd2
                double dd2Invertido = -dd2;

                // Paso 3: Delta con dd2 invertido
                double delta = dd1 + dd2Invertido;


                // Mostrar resultados
                lbldd1.Text = dd1.ToString("0.00");
                lbldd2.Text = dd2.ToString("0.00");
                lbldelta.Text = delta.ToString("0.00");

                // Verificamos que el resultado no es 0
                double deltaValue;
                if (double.TryParse(lbldelta.Text, out deltaValue) && deltaValue == 0)
                {
                    MessageBox.Show("El sistema tiene múltiples resultados, ingrese valores de nuevo");
                }


                ///////////////////////////////////////////////////////////////////
                ////////////////////                              /////////////////
                ///////////////////    INICIA EL PROCESO DE x̄1   //////////////////
                //////////////////                              ///////////////////
                ///////////////////////////////////////////////////////////////////


                // Multiplicaciones
                double mult1 = C1 * B2;
                double mult2 = C2 * B1;
                double rdx1;

                // Guardamos el signo original de mult2
                bool mult2Negativo = mult2 < 0;

                // Invertimos el signo de mult2
                double mult2Invertido = -mult2;

                // Decidir suma o resta según el signo original de mult2
                double dx1 = mult1 + mult2Invertido;

                // Mostrar en el label con formato
                lbldx1.Text = dx1.ToString("0.00");

                //Sacamos el resultado de x̄1
                rdx1 = dx1 / delta;

                //Imprimimos el resulado final de x̄1
                lblrdx1.Text = rdx1.ToString("0.00");


                ///////////////////////////////////////////////////////////////////
                ////////////////////                              /////////////////
                ///////////////////    INICIA EL PROCESO DE x̄2   //////////////////
                //////////////////                              ///////////////////
                ///////////////////////////////////////////////////////////////////

                // Multiplicaciones
                double multx12 = A1 * C2;
                double multx22 = A2 * C1;
                double rdx2;


                // Invertimos el signo de mult2
                double multx22Invertido = -multx22;

                // Decidir suma o resta según el signo original de mult2
                double dx2 = multx12 + multx22Invertido;

                // Mostrar en el label con formato
                lbldx2.Text = dx2.ToString("0.00");

                //Sacamos el resultado de x̄2
                rdx2 = dx2 / delta;

                //Imprimimos el resulado final de x̄2
                lblrdx2.Text = rdx2.ToString("0.00");
            }

        }

        private void borrar_Click(object sender, EventArgs e)
        {

            ///////////////////////////////////////////////////////////////////
            ////////////////////                              /////////////////
            /////////////////// INICIA EL PROCESO DE BORRADO //////////////////
            //////////////////                              ///////////////////
            ///////////////////////////////////////////////////////////////////

            a1.Text = "";
            a2.Text = "";
            b1.Text = "";
            b2.Text = "";
            c1.Text = "";
            c2.Text = "";

            lbldd1.Text = "dd1";
            lbldd2.Text = "dd2";
            lbldelta.Text = "Delta";
            lbldx1.Text = "dx2";
            lbldx2.Text = "dx2";
            lblrdx1.Text = "rdx2";
            lblrdx2.Text = "rdx2";

        }

        private void abc3_Click(object sender, EventArgs e)
        {

        }
    }
}