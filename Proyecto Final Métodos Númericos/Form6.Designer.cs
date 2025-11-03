using System.ComponentModel;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    partial class Form6
    {
        private IContainer components = null;
        private Panel mainPanel;
        private Label lblHeader;
        private Label lblSoon;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblSoon = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 420);
            this.mainPanel.TabIndex = 3;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(24, 18);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(291, 37);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "Integración numérica";
            // 
            // lblSoon
            // 
            this.lblSoon.AutoSize = true;
            this.lblSoon.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblSoon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.lblSoon.Location = new System.Drawing.Point(120, 140);
            this.lblSoon.Name = "lblSoon";
            this.lblSoon.Size = new System.Drawing.Size(326, 51);
            this.lblSoon.TabIndex = 1;
            this.lblSoon.Text = "PRÓXIMAMENTE";
            // 
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(660, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Regresar";
            this.btnClose.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // Form6
            // 
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblSoon);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apartado de Integración";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}