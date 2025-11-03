using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form24 : Form
    {
        public Form24()
        {
            InitializeComponent();
            panel1.Visible = false;
            radioButton1.Visible = false;
            radioButton1.Checked = true;
            btnEvaluarGrado1.Visible = false;
            btnEvaluar.Visible = false;
            btnEvaluar2.Visible = false;
            btnEvaluar3.Visible = false;

            // Asegurar que el botón esté cableado aunque el diseñador se pierda
            try { this.btnEvaluarGrado1.Click -= btnEvaluarGrado1_Click_1; } catch { }
            this.btnEvaluarGrado1.Click += btnEvaluarGrado1_Click_1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Cerrar para volver a Form23 (quien abrió este formulario modalmente)
            this.Close();
        }

        private void btnEvaluarGrado1_Click_1(object sender, EventArgs e)
        {
            string funcion = lblFuncion.Text;
            if (string.IsNullOrWhiteSpace(funcion))
            {
                MessageBox.Show("No hay ninguna función para verificar.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var respuesta = MessageBox.Show($"Verifica tu función:\n{funcion}\n\n¿Deseas continuar?",
                                            "Confirmar función", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (respuesta != DialogResult.OK) return;

            this.Hide();
            try
            {
                using (var form25 = new Form25(funcion))
                {
                    form25.StartPosition = FormStartPosition.CenterParent;
                    form25.ShowDialog(this);
                }
            }
            finally { try { this.Show(); } catch { } }
        }

        private void btnEvaluar3_Click_1(object sender, EventArgs e)
        {
            string funcion = lblFuncion.Text;

            if (string.IsNullOrWhiteSpace(funcion))
            {
                MessageBox.Show("No hay ninguna función para verificar.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mensaje = $"Verifica tu función:\n{funcion}\n\n¿Deseas continuar?";
            DialogResult respuesta = MessageBox.Show(mensaje, "Confirmar función",
                                                     MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (respuesta == DialogResult.OK)
            {
                this.Hide();
                try
                {
                    using (var form28 = new Form28(funcion))
                    {
                        form28.StartPosition = FormStartPosition.CenterParent;
                        form28.ShowDialog(this);
                    }
                }
                finally { try { this.Show(); } catch { } }
            }
        }

        private void btnEvaluar2_Click_1(object sender, EventArgs e)
        {
            string funcion = lblFuncion.Text;


            if (string.IsNullOrWhiteSpace(funcion))
            {
                MessageBox.Show("No hay ninguna función para verificar.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string mensaje = $"Verifica tu función:\n{funcion}\n\n¿Deseas continuar?";
            DialogResult respuesta = MessageBox.Show(mensaje, "Confirmar función",
                                                     MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            if (respuesta == DialogResult.OK)
            {

                this.Hide();
                try
                {
                    using (var form27 = new Form27(funcion))
                    {
                        form27.StartPosition = FormStartPosition.CenterParent;
                        form27.ShowDialog(this);
                    }
                }
                finally { try { this.Show(); } catch { } }
            }
        }

        private void btnEvaluar_Click_1(object sender, EventArgs e)
        {
            string funcion = lblFuncion.Text;


            if (string.IsNullOrWhiteSpace(funcion))
            {
                MessageBox.Show("No hay ninguna función para verificar.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string mensaje = $"Verifica tu función:\n{funcion}\n\n¿Deseas continuar?";
            DialogResult respuesta = MessageBox.Show(mensaje, "Confirmar función",
                                                     MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            if (respuesta == DialogResult.OK)
            {

                this.Hide();
                try
                {
                    using (var form26 = new Form26(funcion))
                    {
                        form26.StartPosition = FormStartPosition.CenterParent;
                        form26.ShowDialog(this);
                    }
                }
                finally { try { this.Show(); } catch { } }
            }
        }

        private void rbGrado1_CheckedChanged(object sender, EventArgs e)
        {
            btnEvaluarGrado1.Visible = true;
            btnEvaluar.Visible = false;
            btnEvaluar2.Visible = false;
            btnEvaluar3.Visible = false;
            if (rbGrado1.Checked)
            {
                panel1.Visible = true;
                lblFuncion.Text = "a₁x\u00B9 + a";

            }
        }

        private void rbGrado2_CheckedChanged(object sender, EventArgs e)
        {
            btnEvaluarGrado1.Visible = false;
            btnEvaluar.Visible = true;
            btnEvaluar2.Visible = false;
            btnEvaluar3.Visible = false;
            if (rbGrado2.Checked)
            {
                panel1.Visible = true;
                lblFuncion.Text = "a₂x² + a₁x + a";
            }
        }

        private void rbGrado3_CheckedChanged(object sender, EventArgs e)
        {
            btnEvaluarGrado1.Visible = false;
            btnEvaluar.Visible = false;
            btnEvaluar2.Visible = true;
            btnEvaluar3.Visible = false;
            if (rbGrado3.Checked)
            {
                panel1.Visible = true;
                lblFuncion.Text = "a₃x³ +a₂x² + a₁x + a";

            }
        }

        private void rbGrado4_CheckedChanged(object sender, EventArgs e)
        {
            btnEvaluarGrado1.Visible = false;
            btnEvaluar.Visible = false;
            btnEvaluar2.Visible = false;
            btnEvaluar3.Visible = true;
            if (rbGrado4.Checked)
            {
                panel1.Visible = true;
                lblFuncion.Text = "a₄x⁴ + a₃x³ +a₂x² + a₁x + a";

            }
        }
    }
}