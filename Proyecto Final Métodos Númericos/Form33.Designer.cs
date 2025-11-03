namespace Proyecto_Final_Métodos_Númericos
{
    partial class Form33
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form33));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAbrirCalculadora = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.lblSubtitle);
            this.mainPanel.Controls.Add(this.lblTitle);
            this.mainPanel.Controls.Add(this.btnSalir);
            this.mainPanel.Controls.Add(this.btnAbrirCalculadora);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(966, 489);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Eras Medium ITC", 13.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSubtitle.Location = new System.Drawing.Point(183, 140);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(517, 21);
            this.lblSubtitle.TabIndex = 7;
            this.lblSubtitle.Text = "Calculadora del método de la secante — simple, clara y precisa";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Eras Bold ITC", 26F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(141, 80);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(673, 40);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "¡Bienvenido al método de la secante!";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.btnSalir.Font = new System.Drawing.Font("Eras Demi ITC", 14F);
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(811, 28);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(129, 38);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Regresar";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // btnAbrirCalculadora
            // 
            this.btnAbrirCalculadora.BackColor = System.Drawing.Color.Cyan;
            this.btnAbrirCalculadora.Font = new System.Drawing.Font("Eras Demi ITC", 16F);
            this.btnAbrirCalculadora.Location = new System.Drawing.Point(378, 260);
            this.btnAbrirCalculadora.Name = "btnAbrirCalculadora";
            this.btnAbrirCalculadora.Size = new System.Drawing.Size(210, 72);
            this.btnAbrirCalculadora.TabIndex = 4;
            this.btnAbrirCalculadora.Text = "Ingresar";
            this.btnAbrirCalculadora.UseVisualStyleBackColor = false;
            this.btnAbrirCalculadora.Click += new System.EventHandler(this.btnAbrirCalculadora_Click);
            // 
            // Form33
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 489);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form33";
            this.Text = "Método de la Secante | Bienvenida";
            this.Load += new System.EventHandler(this.Form33_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAbrirCalculadora;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
    }
}