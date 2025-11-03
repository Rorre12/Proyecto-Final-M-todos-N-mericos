using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();

            // Estado inicial según tu lógica existente
            panel1.Visible = false;
            radioButton1.Visible = false;
            radioButton1.Checked = true;
            btnEvaluarGrado1.Visible = false;
            btnEvaluar.Visible = false;
            btnEvaluar2.Visible = false;
            btnEvaluar3.Visible = false;
        }

        private void Grados_Load(object sender, EventArgs e)
        {
        }

        // ARREGLADO: funcionalidad del botón Evaluar (grado 2)
        private void btnEvaluar_Click(object sender, EventArgs e)
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

            if (respuesta == DialogResult.OK)
            {
                // Mantener un solo formulario visible
                this.Hide();
                try
                {
                    using (var form19 = new Form19(funcion))
                    {
                        form19.StartPosition = FormStartPosition.CenterParent;
                        form19.ShowDialog(this);
                    }
                }
                finally
                {
                    try { this.Show(); } catch { }
                }
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
                lblFuncion.Text = "a₃x³ + a₂x² + a₁x + a";
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
                lblFuncion.Text = "a₄x⁴ + a₃x³ + a₂x² + a₁x + a";
            }
        }

        private void btnEvaluar2_Click(object sender, EventArgs e)
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

            if (respuesta == DialogResult.OK)
            {
                this.Hide();
                try
                {
                    using (var form20 = new Form20(funcion))
                    {
                        form20.StartPosition = FormStartPosition.CenterParent;
                        form20.ShowDialog(this);
                    }
                }
                finally { try { this.Show(); } catch { } }
            }
        }

        private void btnEvaluar3_Click(object sender, EventArgs e)
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

            if (respuesta == DialogResult.OK)
            {
                this.Hide();
                try
                {
                    using (var form21 = new Form21(funcion))
                    {
                        form21.StartPosition = FormStartPosition.CenterParent;
                        form21.ShowDialog(this);
                    }
                }
                finally { try { this.Show(); } catch { } }
            }
        }

        private void btnEvaluarGrado1_Click(object sender, EventArgs e)
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

            if (respuesta == DialogResult.OK)
            {
                this.Hide();
                try
                {
                    using (var form18 = new Form18(funcion))
                    {
                        form18.StartPosition = FormStartPosition.CenterParent;
                        form18.ShowDialog(this);
                    }
                }
                finally { try { this.Show(); } catch { } }
            }
        }

        // Si existe un botón Regresar en Form17, que solo cierre:
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}