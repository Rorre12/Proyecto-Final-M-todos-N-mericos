using System.ComponentModel;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    partial class Form3
    {
        private IContainer components = null;
        private Panel mainPanel;
        private Label lblHeader;
        private Button btnCramer;
        private Button btnGauss;
        private Button btnGaussJordan;
        private Button btnCofactores;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnCramer = new System.Windows.Forms.Button();
            this.btnGauss = new System.Windows.Forms.Button();
            this.btnGaussJordan = new System.Windows.Forms.Button();
            this.btnCofactores = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 420);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(24, 18);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(420, 37);
            this.lblHeader.TabIndex = 5;
            this.lblHeader.Text = "Sistemas de ecuaciones lineales";
            // 
            // btnCramer
            // 
            this.btnCramer.FlatAppearance.BorderSize = 0;
            this.btnCramer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCramer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCramer.ForeColor = System.Drawing.Color.White;
            this.btnCramer.Location = new System.Drawing.Point(24, 84);
            this.btnCramer.Name = "btnCramer";
            this.btnCramer.Size = new System.Drawing.Size(360, 64);
            this.btnCramer.TabIndex = 4;
            this.btnCramer.Text = "Cramer";
            this.btnCramer.Click += new System.EventHandler(this.btnCramer_Click);
            // 
            // btnGauss
            // 
            this.btnGauss.FlatAppearance.BorderSize = 0;
            this.btnGauss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGauss.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGauss.ForeColor = System.Drawing.Color.White;
            this.btnGauss.Location = new System.Drawing.Point(24, 160);
            this.btnGauss.Name = "btnGauss";
            this.btnGauss.Size = new System.Drawing.Size(360, 64);
            this.btnGauss.TabIndex = 3;
            this.btnGauss.Text = "Eliminación de Gauss";
            this.btnGauss.Click += new System.EventHandler(this.btnGauss_Click);
            // 
            // btnGaussJordan
            // 
            this.btnGaussJordan.FlatAppearance.BorderSize = 0;
            this.btnGaussJordan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGaussJordan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGaussJordan.ForeColor = System.Drawing.Color.White;
            this.btnGaussJordan.Location = new System.Drawing.Point(24, 236);
            this.btnGaussJordan.Name = "btnGaussJordan";
            this.btnGaussJordan.Size = new System.Drawing.Size(360, 64);
            this.btnGaussJordan.TabIndex = 2;
            this.btnGaussJordan.Text = "Inversa por Gauss-Jordan";
            this.btnGaussJordan.Click += new System.EventHandler(this.btnGaussJordan_Click);
            // 
            // btnCofactores
            // 
            this.btnCofactores.FlatAppearance.BorderSize = 0;
            this.btnCofactores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCofactores.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCofactores.ForeColor = System.Drawing.Color.White;
            this.btnCofactores.Location = new System.Drawing.Point(24, 312);
            this.btnCofactores.Name = "btnCofactores";
            this.btnCofactores.Size = new System.Drawing.Size(360, 64);
            this.btnCofactores.TabIndex = 1;
            this.btnCofactores.Text = "Inversa por cofactores";
            this.btnCofactores.Click += new System.EventHandler(this.btnCofactores_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(660, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Regresar";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form3
            // 
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCofactores);
            this.Controls.Add(this.btnGaussJordan);
            this.Controls.Add(this.btnGauss);
            this.Controls.Add(this.btnCramer);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apartado de Sistemas de ecuaciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}