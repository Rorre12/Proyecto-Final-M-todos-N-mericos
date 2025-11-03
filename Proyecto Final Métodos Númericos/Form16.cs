using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        // Entrar/Calcular -> NO cerrar Form16. Ocúltalo, abre Form17 en modal y re-muéstralo al volver.
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            this.Hide();
            try
            {
                using (var form17 = new Form17())
                {
                    form17.StartPosition = FormStartPosition.CenterParent;
                    form17.ShowDialog(this);
                }
            }
            finally
            {
                try { this.Show(); } catch { }
            }
        }

        // Si este botón también entra al siguiente paso, aplica el mismo patrón modal.
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            try
            {
                using (var form17 = new Form17())
                {
                    form17.StartPosition = FormStartPosition.CenterParent;
                    form17.ShowDialog(this);
                }
            }
            finally
            {
                try { this.Show(); } catch { }
            }
        }

        // Regresar -> Cierra este form para volver al que lo abrió (Form4). NO crear nuevas instancias.
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

