namespace Proyecto_Final_Métodos_Númericos
{
    partial class Form14
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel cardPanel;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.RadioButton rdb2x2;
        private System.Windows.Forms.RadioButton rdb3x3;
        private System.Windows.Forms.Button btnResolver;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel matrixPanel;
        private System.Windows.Forms.DataGridView dgvMatriz;
        private System.Windows.Forms.PictureBox picDecor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form14));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.cardPanel = new System.Windows.Forms.Panel();
            this.lblSize = new System.Windows.Forms.Label();
            this.rdb2x2 = new System.Windows.Forms.RadioButton();
            this.rdb3x3 = new System.Windows.Forms.RadioButton();
            this.btnResolver = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.matrixPanel = new System.Windows.Forms.Panel();
            this.dgvMatriz = new System.Windows.Forms.DataGridView();
            this.picDecor = new System.Windows.Forms.PictureBox();
            this.mainPanel.SuspendLayout();
            this.cardPanel.SuspendLayout();
            this.matrixPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatriz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDecor)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Controls.Add(this.lblHeader);
            this.mainPanel.Controls.Add(this.cardPanel);
            this.mainPanel.Controls.Add(this.picDecor);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(980, 480);
            this.mainPanel.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(28, 18);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(307, 37);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Inversa por Cofactores";
            // 
            // cardPanel
            // 
            this.cardPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.cardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardPanel.Controls.Add(this.lblSize);
            this.cardPanel.Controls.Add(this.rdb2x2);
            this.cardPanel.Controls.Add(this.rdb3x3);
            this.cardPanel.Controls.Add(this.btnResolver);
            this.cardPanel.Controls.Add(this.btnLimpiar);
            this.cardPanel.Controls.Add(this.btnBack);
            this.cardPanel.Controls.Add(this.matrixPanel);
            this.cardPanel.Location = new System.Drawing.Point(28, 78);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.Size = new System.Drawing.Size(560, 360);
            this.cardPanel.TabIndex = 1;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSize.ForeColor = System.Drawing.Color.White;
            this.lblSize.Location = new System.Drawing.Point(18, 16);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(118, 19);
            this.lblSize.TabIndex = 0;
            this.lblSize.Text = "Tamaño (n x n):";
            // 
            // rdb2x2
            // 
            this.rdb2x2.AutoSize = true;
            this.rdb2x2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdb2x2.ForeColor = System.Drawing.Color.White;
            this.rdb2x2.Location = new System.Drawing.Point(150, 14);
            this.rdb2x2.Name = "rdb2x2";
            this.rdb2x2.Size = new System.Drawing.Size(57, 23);
            this.rdb2x2.TabIndex = 1;
            this.rdb2x2.Text = "2 x 2";
            // 
            // rdb3x3
            // 
            this.rdb3x3.AutoSize = true;
            this.rdb3x3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdb3x3.ForeColor = System.Drawing.Color.White;
            this.rdb3x3.Location = new System.Drawing.Point(220, 14);
            this.rdb3x3.Name = "rdb3x3";
            this.rdb3x3.Size = new System.Drawing.Size(57, 23);
            this.rdb3x3.TabIndex = 2;
            this.rdb3x3.Text = "3 x 3";
            // 
            // btnResolver
            // 
            this.btnResolver.Location = new System.Drawing.Point(22, 52);
            this.btnResolver.Name = "btnResolver";
            this.btnResolver.Size = new System.Drawing.Size(180, 36);
            this.btnResolver.TabIndex = 3;
            this.btnResolver.Text = "Abrir Solucionador";
            this.btnResolver.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(212, 52);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(140, 36);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(418, 52);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 36);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Regresar";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // matrixPanel
            // 
            this.matrixPanel.BackColor = System.Drawing.Color.Transparent;
            this.matrixPanel.Controls.Add(this.dgvMatriz);
            this.matrixPanel.Location = new System.Drawing.Point(22, 108);
            this.matrixPanel.Name = "matrixPanel";
            this.matrixPanel.Size = new System.Drawing.Size(516, 230);
            this.matrixPanel.TabIndex = 6;
            // 
            // dgvMatriz
            // 
            this.dgvMatriz.AllowUserToAddRows = false;
            this.dgvMatriz.AllowUserToDeleteRows = false;
            this.dgvMatriz.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.dgvMatriz.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMatriz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatriz.Location = new System.Drawing.Point(0, 0);
            this.dgvMatriz.Name = "dgvMatriz";
            this.dgvMatriz.RowHeadersVisible = false;
            this.dgvMatriz.Size = new System.Drawing.Size(516, 230);
            this.dgvMatriz.TabIndex = 0;
            // 
            // picDecor
            // 
            this.picDecor.BackColor = System.Drawing.Color.Transparent;
            this.picDecor.Location = new System.Drawing.Point(612, 78);
            this.picDecor.Name = "picDecor";
            this.picDecor.Size = new System.Drawing.Size(340, 360);
            this.picDecor.TabIndex = 2;
            this.picDecor.TabStop = false;
            // 
            // Form14
            // 
            this.ClientSize = new System.Drawing.Size(980, 480);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form14";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Menú - Inversa por Cofactores";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.cardPanel.ResumeLayout(false);
            this.cardPanel.PerformLayout();
            this.matrixPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatriz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDecor)).EndInit();
            this.ResumeLayout(false);
        }
    }
}