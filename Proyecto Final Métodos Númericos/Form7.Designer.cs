namespace Proyecto_Final_Métodos_Númericos
{
    partial class Form7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnEcuaciones3 = new System.Windows.Forms.Button();
            this.btnEcuaciones2 = new System.Windows.Forms.Button();
            this.btnVolverSubmenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(935, 80);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Seleccione un método";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEcuaciones3
            // 
            this.btnEcuaciones3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnEcuaciones3.FlatAppearance.BorderSize = 0;
            this.btnEcuaciones3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEcuaciones3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnEcuaciones3.ForeColor = System.Drawing.Color.White;
            this.btnEcuaciones3.Location = new System.Drawing.Point(330, 196);
            this.btnEcuaciones3.Name = "btnEcuaciones3";
            this.btnEcuaciones3.Size = new System.Drawing.Size(280, 70);
            this.btnEcuaciones3.TabIndex = 4;
            this.btnEcuaciones3.Text = "Ecuaciones lineales de 3 incógnitas";
            this.btnEcuaciones3.UseVisualStyleBackColor = false;
            this.btnEcuaciones3.Click += new System.EventHandler(this.btnEcuaciones3_Click);
            // 
            // btnEcuaciones2
            // 
            this.btnEcuaciones2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnEcuaciones2.FlatAppearance.BorderSize = 0;
            this.btnEcuaciones2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEcuaciones2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnEcuaciones2.ForeColor = System.Drawing.Color.White;
            this.btnEcuaciones2.Location = new System.Drawing.Point(330, 107);
            this.btnEcuaciones2.Name = "btnEcuaciones2";
            this.btnEcuaciones2.Size = new System.Drawing.Size(280, 70);
            this.btnEcuaciones2.TabIndex = 3;
            this.btnEcuaciones2.Text = "Ecuaciones lineales de 2 incógnitas";
            this.btnEcuaciones2.UseVisualStyleBackColor = false;
            this.btnEcuaciones2.Click += new System.EventHandler(this.btnEcuaciones2_Click);
            // 
            // btnVolverSubmenu
            // 
            this.btnVolverSubmenu.BackColor = System.Drawing.Color.Peru;
            this.btnVolverSubmenu.FlatAppearance.BorderSize = 0;
            this.btnVolverSubmenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolverSubmenu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnVolverSubmenu.ForeColor = System.Drawing.Color.White;
            this.btnVolverSubmenu.Location = new System.Drawing.Point(330, 284);
            this.btnVolverSubmenu.Name = "btnVolverSubmenu";
            this.btnVolverSubmenu.Size = new System.Drawing.Size(280, 70);
            this.btnVolverSubmenu.TabIndex = 6;
            this.btnVolverSubmenu.Text = "Volver al submenú";
            this.btnVolverSubmenu.UseVisualStyleBackColor = false;
            this.btnVolverSubmenu.Click += new System.EventHandler(this.btnVolverSubmenu_Click);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(935, 467);
            this.Controls.Add(this.btnVolverSubmenu);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnEcuaciones3);
            this.Controls.Add(this.btnEcuaciones2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form7";
            this.Text = "Menú principal de Cramer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnEcuaciones3;
        private System.Windows.Forms.Button btnEcuaciones2;
        private System.Windows.Forms.Button btnVolverSubmenu;
    }
}