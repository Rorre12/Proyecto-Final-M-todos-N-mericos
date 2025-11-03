namespace Proyecto_Final_Métodos_Númericos
{
    partial class Form12
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel cardPanel;
        private System.Windows.Forms.PictureBox picDecor;
        private System.Windows.Forms.Panel matrixPanel;
        private System.Windows.Forms.ComboBox cmbSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnExample;
        private System.Windows.Forms.Button btnOpenSolver;
        private System.Windows.Forms.Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form12));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.cardPanel = new System.Windows.Forms.Panel();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnExample = new System.Windows.Forms.Button();
            this.btnOpenSolver = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.matrixPanel = new System.Windows.Forms.Panel();
            this.picDecor = new System.Windows.Forms.PictureBox();
            this.mainPanel.SuspendLayout();
            this.cardPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDecor)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Controls.Add(this.lblHeader);
            this.mainPanel.Controls.Add(this.cardPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(995, 485);
            this.mainPanel.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(36, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(356, 37);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Inversa por Gauss - Jordan";
            // 
            // cardPanel
            // 
            this.cardPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.cardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardPanel.Controls.Add(this.cmbSize);
            this.cardPanel.Controls.Add(this.lblSize);
            this.cardPanel.Controls.Add(this.btnCreate);
            this.cardPanel.Controls.Add(this.btnExample);
            this.cardPanel.Controls.Add(this.btnOpenSolver);
            this.cardPanel.Controls.Add(this.btnBack);
            this.cardPanel.Controls.Add(this.matrixPanel);
            this.cardPanel.Location = new System.Drawing.Point(28, 78);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.Size = new System.Drawing.Size(480, 360);
            this.cardPanel.TabIndex = 1;
            // 
            // cmbSize
            // 
            this.cmbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSize.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbSize.FormattingEnabled = true;
            this.cmbSize.Items.AddRange(new object[] {
            "2",
            "3"});
            this.cmbSize.Location = new System.Drawing.Point(120, 20);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(80, 29);
            this.cmbSize.TabIndex = 0;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSize.ForeColor = System.Drawing.Color.White;
            this.lblSize.Location = new System.Drawing.Point(28, 24);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(90, 19);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "Dimensiones:";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(216, 18);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(110, 32);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Crear";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnExample
            // 
            this.btnExample.Location = new System.Drawing.Point(336, 18);
            this.btnExample.Name = "btnExample";
            this.btnExample.Size = new System.Drawing.Size(110, 32);
            this.btnExample.TabIndex = 2;
            this.btnExample.Text = "Ejemplo";
            this.btnExample.UseVisualStyleBackColor = true;
            this.btnExample.Click += new System.EventHandler(this.btnExample_Click);
            // 
            // btnOpenSolver
            // 
            this.btnOpenSolver.Location = new System.Drawing.Point(28, 64);
            this.btnOpenSolver.Name = "btnOpenSolver";
            this.btnOpenSolver.Size = new System.Drawing.Size(322, 36);
            this.btnOpenSolver.TabIndex = 3;
            this.btnOpenSolver.Text = "Abrir Solucionador";
            this.btnOpenSolver.UseVisualStyleBackColor = true;
            this.btnOpenSolver.Click += new System.EventHandler(this.btnOpenSolver_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(360, 64);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(88, 36);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Regresar";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // matrixPanel
            // 
            this.matrixPanel.BackColor = System.Drawing.Color.Transparent;
            this.matrixPanel.Location = new System.Drawing.Point(28, 120);
            this.matrixPanel.Name = "matrixPanel";
            this.matrixPanel.Size = new System.Drawing.Size(420, 216);
            this.matrixPanel.TabIndex = 5;
            // 
            // picDecor
            // 
            this.picDecor.BackColor = System.Drawing.Color.Transparent;
            this.picDecor.Location = new System.Drawing.Point(520, 78);
            this.picDecor.Name = "picDecor";
            this.picDecor.Size = new System.Drawing.Size(420, 360);
            this.picDecor.TabIndex = 2;
            this.picDecor.TabStop = false;
            // 
            // Form12
            // 
            this.ClientSize = new System.Drawing.Size(995, 485);
            this.Controls.Add(this.picDecor);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form12";
            this.Text = "Menú de la inversa por Gauss -Jordan";
            this.Load += new System.EventHandler(this.Form12_Load);
            this.Resize += new System.EventHandler(this.Form12_Resize);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.cardPanel.ResumeLayout(false);
            this.cardPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDecor)).EndInit();
            this.ResumeLayout(false);

        }
    }
}