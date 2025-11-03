using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class SubmenuForm : Form
    {
        public SubmenuForm(string title)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(20, 20, 28);
            lblTitle.Text = title;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}