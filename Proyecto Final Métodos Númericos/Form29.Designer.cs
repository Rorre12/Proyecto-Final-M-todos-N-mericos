namespace Proyecto_Final_Métodos_Númericos
{
    partial class Form29
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form29));
            this.btnRegresar = new System.Windows.Forms.Button();
            this.lblRaiz = new System.Windows.Forms.Label();
            this.dgvReglaFalsa = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.txtError = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReglaFalsa)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(242)))));
            this.btnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresar.FlatAppearance.BorderSize = 0;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.Location = new System.Drawing.Point(839, 103);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(148, 36);
            this.btnRegresar.TabIndex = 12;
            this.btnRegresar.Text = "Nueva Funcion";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // lblRaiz
            // 
            this.lblRaiz.AutoSize = true;
            this.lblRaiz.BackColor = System.Drawing.Color.Transparent;
            this.lblRaiz.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblRaiz.ForeColor = System.Drawing.Color.Black;
            this.lblRaiz.Location = new System.Drawing.Point(825, 35);
            this.lblRaiz.Name = "lblRaiz";
            this.lblRaiz.Size = new System.Drawing.Size(43, 25);
            this.lblRaiz.TabIndex = 13;
            this.lblRaiz.Text = "raiz";
            // 
            // dgvReglaFalsa
            // 
            this.dgvReglaFalsa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReglaFalsa.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReglaFalsa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReglaFalsa.Location = new System.Drawing.Point(-5, 155);
            this.dgvReglaFalsa.Name = "dgvReglaFalsa";
            this.dgvReglaFalsa.RowHeadersWidth = 51;
            this.dgvReglaFalsa.Size = new System.Drawing.Size(1007, 327);
            this.dgvReglaFalsa.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnCalcular);
            this.panel1.Controls.Add(this.txtError);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Location = new System.Drawing.Point(-45, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 116);
            this.panel1.TabIndex = 10;
            // 
            // btnCalcular
            // 
            this.btnCalcular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(242)))));
            this.btnCalcular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalcular.FlatAppearance.BorderSize = 0;
            this.btnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcular.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCalcular.ForeColor = System.Drawing.Color.White;
            this.btnCalcular.Location = new System.Drawing.Point(693, 73);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(111, 36);
            this.btnCalcular.TabIndex = 4;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // txtError
            // 
            this.txtError.BackColor = System.Drawing.Color.LightGray;
            this.txtError.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtError.Location = new System.Drawing.Point(710, 7);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(94, 33);
            this.txtError.TabIndex = 3;
            this.txtError.Click += new System.EventHandler(this.txtError_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(448, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingresa el error aproximado: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(80, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Datos: ";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblInfo.ForeColor = System.Drawing.Color.Black;
            this.lblInfo.Location = new System.Drawing.Point(91, 47);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(31, 25);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "ds";
            // 
            // Form29
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Final_Métodos_Númericos.Properties.Resources.Captura_de_pantalla_2025_10_07_223428;
            this.ClientSize = new System.Drawing.Size(1055, 504);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.lblRaiz);
            this.Controls.Add(this.dgvReglaFalsa);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form29";
            this.Text = "Solucionador de Regula Falsi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReglaFalsa)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label lblRaiz;
        private System.Windows.Forms.DataGridView dgvReglaFalsa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfo;
    }
}