using System.ComponentModel;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    partial class SubmenuForm
    {
        private IContainer components = null;
        private Label lblTitle;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            this.components = new Container();
            this.lblTitle = new Label();
            this.btnClose = new Button();

            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Size = new System.Drawing.Size(760, 44);
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.Location = new System.Drawing.Point(660, 14);
            this.btnClose.Text = "Cerrar";
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Name = "SubmenuForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Submenú";
        }

        #endregion
    }
}