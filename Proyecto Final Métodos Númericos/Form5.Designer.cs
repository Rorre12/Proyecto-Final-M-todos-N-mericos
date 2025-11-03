using System.ComponentModel;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    partial class Form5
    {
        private IContainer components = null;
        private Panel mainPanel;
        private Label lblHeader;
        private Button btnProgresiva;
        private Button btnCentrada;
        private Button btnOrdenSuperior;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnProgresiva = new System.Windows.Forms.Button();
            this.btnCentrada = new System.Windows.Forms.Button();
            this.btnOrdenSuperior = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.btnClose);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 420);
            this.mainPanel.TabIndex = 5;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(24, 18);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(281, 37);
            this.lblHeader.TabIndex = 4;
            this.lblHeader.Text = "Derivación numérica";
            // 
            // btnProgresiva
            // 
            this.btnProgresiva.FlatAppearance.BorderSize = 0;
            this.btnProgresiva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProgresiva.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProgresiva.ForeColor = System.Drawing.Color.White;
            this.btnProgresiva.Location = new System.Drawing.Point(24, 84);
            this.btnProgresiva.Name = "btnProgresiva";
            this.btnProgresiva.Size = new System.Drawing.Size(360, 64);
            this.btnProgresiva.TabIndex = 3;
            this.btnProgresiva.Text = "Fórmulas progresivas";
            this.btnProgresiva.Click += new System.EventHandler(this.btnProgresiva_Click);
            // 
            // btnCentrada
            // 
            this.btnCentrada.FlatAppearance.BorderSize = 0;
            this.btnCentrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCentrada.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCentrada.ForeColor = System.Drawing.Color.White;
            this.btnCentrada.Location = new System.Drawing.Point(24, 160);
            this.btnCentrada.Name = "btnCentrada";
            this.btnCentrada.Size = new System.Drawing.Size(360, 64);
            this.btnCentrada.TabIndex = 2;
            this.btnCentrada.Text = "Fórmulas centradas";
            this.btnCentrada.Click += new System.EventHandler(this.btnCentrada_Click);
            // 
            // btnOrdenSuperior
            // 
            this.btnOrdenSuperior.FlatAppearance.BorderSize = 0;
            this.btnOrdenSuperior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenSuperior.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnOrdenSuperior.ForeColor = System.Drawing.Color.White;
            this.btnOrdenSuperior.Location = new System.Drawing.Point(24, 236);
            this.btnOrdenSuperior.Name = "btnOrdenSuperior";
            this.btnOrdenSuperior.Size = new System.Drawing.Size(360, 64);
            this.btnOrdenSuperior.TabIndex = 1;
            this.btnOrdenSuperior.Text = "Fórmulas de orden superior";
            this.btnOrdenSuperior.Click += new System.EventHandler(this.btnOrdenSuperior_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.CausesValidation = false;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(668, 24);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Regresar";
            this.btnClose.UseMnemonic = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form5
            // 
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.btnOrdenSuperior);
            this.Controls.Add(this.btnCentrada);
            this.Controls.Add(this.btnProgresiva);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apartado de derivación";
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}