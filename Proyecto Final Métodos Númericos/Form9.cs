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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
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
                if (a1.Text == "0" && a2.Text == "0" && a3.Text == "0" &&
                 b1.Text == "0" && b2.Text == "0" && b3.Text == "0" &&
                 c1.Text == "0" && c2.Text == "0" && c3.Text == "0" &&
                 d1.Text == "0" && d2.Text == "0" && d3.Text == "0")
                {
                    MessageBox.Show("El sistema es inconsistente, vuelve a ingresar los valores");
                }


                //verifica si todos los campos tiene solo numeros
                double valor;
                if (!double.TryParse(a1.Text, out valor) ||
                    !double.TryParse(a2.Text, out valor) ||
                    !double.TryParse(a3.Text, out valor) ||
                    !double.TryParse(b1.Text, out valor) ||
                    !double.TryParse(b2.Text, out valor) ||
                    !double.TryParse(b3.Text, out valor) ||
                    !double.TryParse(c1.Text, out valor) ||
                    !double.TryParse(c2.Text, out valor) ||
                    !double.TryParse(c3.Text, out valor) ||
                    !double.TryParse(d1.Text, out valor) ||
                    !double.TryParse(d2.Text, out valor) ||
                    !double.TryParse(d3.Text, out valor))
                {
                    MessageBox.Show("Ingrese solo números en todos los campos");
                }

                ///////////////////////////////////////////////////////////////////
                ////////////////////                              /////////////////
                ///////////////////  INICIA EL PROCESO DE DELTA  //////////////////
                //////////////////                              ///////////////////
                ///////////////////////////////////////////////////////////////////

                double A1 = double.Parse(a1.Text);
                double A2 = double.Parse(a2.Text);
                double A3 = double.Parse(a3.Text);

                double B1 = double.Parse(b1.Text);     ////////////////////////////////////////
                double B2 = double.Parse(b2.Text);    /// VARIABLES GENERALES, NO TOCAR!!! ///
                double B3 = double.Parse(b3.Text);   ////////////////////////////////////////

                double C1 = double.Parse(c1.Text);
                double C2 = double.Parse(c2.Text);
                double C3 = double.Parse(c3.Text);


                ////////////////////// INICIA EL PROCESO DE DATO DE DELTA 1 ///////////////////

                double dd11 = B2 * C3;
                double dd12 = B3 * C2;
                double dd13 = dd11 - dd12;
                double dd1 = A1 * dd13;

                lbldd1.Text = dd1.ToString("0.00");

                ////////////////////// INICIA EL PROCESO DE DATO DE DELTA 2 ///////////////////


                double dd21 = A2 * C3;
                double dd22 = A3 * C2;
                double dd23 = dd21 - dd22;
                double dd2 = B1 * dd23;


                lbldd2.Text = dd2.ToString("0.00");


                ////////////////////// INICIA EL PROCESO DE DATO DE DELTA 3 ///////////////////


                double dd31 = A2 * B3;
                double dd32 = A3 * B2;
                double dd33 = dd31 - dd32;
                double dd3 = C1 * dd33;

                lbldd3.Text = dd3.ToString("0.00");

                ////////////////// INICIA EL PROCESO DE SUMA DE DATOS DE DELTA ///////////////

                double delta = dd1 - dd2 + dd3;
                lbldelta.Text = delta.ToString("0.00");

                if (delta == 0)
                {
                    MessageBox.Show("El sistema es inconsistente o tiene infinitas soluciones. Verifica los valores ingresados.");
                    return; // Detiene el cálculo de x1, x2, x3
                }


                //////////////////////////////////////////////////////////////////////////////
                ////////////////////                                       //////////////////
                ///////////////////  INICIA EL PROCESO DE DETERMINANTES   //////////////////
                //////////////////                                       //////////////////
                //////////////////////////////////////////////////////////////////////////


                // Determinante dx1
                double dx11 = double.Parse(d1.Text) * (B2 * C3 - B3 * C2);
                double dx12 = B1 * (double.Parse(d2.Text) * C3 - double.Parse(d3.Text) * C2);
                double dx13 = C1 * (double.Parse(d2.Text) * B3 - double.Parse(d3.Text) * B2);

                double dx1 = dx11 - dx12 + dx13;

                lbldx1.Text = (dx1 / delta).ToString("0.00"); // x1 = Δx1 / Δ

                // Determinante dx2
                double dx21 = A1 * (double.Parse(d2.Text) * C3 - double.Parse(d3.Text) * C2);
                double dx22 = double.Parse(d1.Text) * (A2 * C3 - A3 * C2);
                double dx23 = C1 * (A2 * double.Parse(d3.Text) - A3 * double.Parse(d2.Text));

                double dx2 = dx21 - dx22 + dx23;

                lbldx2.Text = (dx2 / delta).ToString("0.00"); // x2 = Δx2 / Δ



                // Determinante dx3
                double dx31 = A1 * (B2 * double.Parse(d3.Text) - B3 * double.Parse(d2.Text));
                double dx32 = B1 * (A2 * double.Parse(d3.Text) - A3 * double.Parse(d2.Text));
                double dx33 = double.Parse(d1.Text) * (A2 * B3 - A3 * B2);

                double dx3 = dx31 - dx32 + dx33;

                lbldx3.Text = (dx3 / delta).ToString("0.00"); // x3 = Δx3 / Δ

            }



        }

        private void btnregresar_Click_1(object sender, EventArgs e)
        {
            Form7 ventana = new Form7();
            ventana.Show();
            this.Hide();
        }

        private void borrar2_Click_1(object sender, EventArgs e)
        {
            ///////////////////////////////////////////////////////////////////
            ////////////////////                              /////////////////
            /////////////////// INICIA EL PROCESO DE BORRADO //////////////////
            //////////////////                              ///////////////////
            ///////////////////////////////////////////////////////////////////

            a1.Text = "";
            a2.Text = "";
            a3.Text = "";
            b1.Text = "";
            b2.Text = "";
            b3.Text = "";
            c1.Text = "";
            c2.Text = "";
            c3.Text = "";
            d1.Text = "";
            d2.Text = "";
            d3.Text = "";

            lbldd1.Text = "";
            lbldd2.Text = "";
            lbldelta.Text = "";
            lbldx1.Text = "";
            lbldx2.Text = "";
            lblrdx1.Text = "";
            lblrdx2.Text = "";
            lbldd3.Text = "";
            lbldd3.Text = "";
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {

        }
    }
}
