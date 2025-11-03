using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void AnimacionBoton(Button btn, bool entrar)
        {
            if (entrar)
            {
                btn.BackColor = ControlPaint.Light(btn.BackColor);
                btn.Size = new Size(btn.Width + 8, btn.Height + 4);
                btn.Location = new Point(btn.Location.X - 4, btn.Location.Y - 2);
            }
            else
            {
                if (btn == btnEcuaciones2)
                    btn.BackColor = Color.FromArgb(0, 123, 255);
                else
                    btn.BackColor = Color.FromArgb(255, 85, 85);

                btn.Size = new Size(280, 70);
                btn.Location = new Point(60, btn == btnEcuaciones2 ? 100 : 190);
            }
        }

        private void btnEcuaciones2_MouseEnter(object sender, EventArgs e)
        {
            AnimacionBoton(btnEcuaciones2, true);
        }

        private void btnEcuaciones2_MouseLeave(object sender, EventArgs e)
        {
            AnimacionBoton(btnEcuaciones2, false);
        }

        private void btnEcuaciones3_MouseEnter(object sender, EventArgs e)
        {
            AnimacionBoton(btnEcuaciones3, true);
        }

        private void btnEcuaciones3_MouseLeave(object sender, EventArgs e)
        {
            AnimacionBoton(btnEcuaciones3, false);
        }

        private void btnEcuaciones2_Click(object sender, EventArgs e)
        {
            // Open Form8 modally, hide this while the child is active
            this.Hide();
            try
            {
                using (var ventana = new Form8())
                {
                    ventana.StartPosition = FormStartPosition.CenterParent;
                    ventana.ShowDialog(this);
                }
            }
            finally
            {
                try { this.Show(); } catch { }
            }
        }

        private void btnEcuaciones3_Click(object sender, EventArgs e)
        {
            // Open Form9 modally, hide this while the child is active
            this.Hide();
            try
            {
                using (var ventana = new Form9())
                {
                    ventana.StartPosition = FormStartPosition.CenterParent;
                    ventana.ShowDialog(this);
                }
            }
            finally
            {
                try { this.Show(); } catch { }
            }
        }

        private void btnVolverSubmenu_Click(object sender, EventArgs e)
        {
            // Close this submenu to return to the caller (Form3 will re-show itself)
            this.Close();
        }
    }
}
