namespace Proyecto_Final_Métodos_Númericos
{
    partial class Form24
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form24));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbGrado4 = new System.Windows.Forms.RadioButton();
            this.rbGrado3 = new System.Windows.Forms.RadioButton();
            this.rbGrado2 = new System.Windows.Forms.RadioButton();
            this.rbGrado1 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEvaluarGrado1 = new System.Windows.Forms.Button();
            this.btnEvaluar3 = new System.Windows.Forms.Button();
            this.btnEvaluar2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFuncion = new System.Windows.Forms.Label();
            this.btnEvaluar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbGrado4);
            this.groupBox1.Controls.Add(this.rbGrado3);
            this.groupBox1.Controls.Add(this.rbGrado2);
            this.groupBox1.Controls.Add(this.rbGrado1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Location = new System.Drawing.Point(68, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 199);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecciona el grado ";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.ForeColor = System.Drawing.Color.Black;
            this.radioButton1.Location = new System.Drawing.Point(509, 42);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(44, 29);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = " x";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(425, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "identifica el exponente mas grande de tu funcion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 4;
            // 
            // rbGrado4
            // 
            this.rbGrado4.AutoSize = true;
            this.rbGrado4.ForeColor = System.Drawing.Color.Black;
            this.rbGrado4.Location = new System.Drawing.Point(337, 143);
            this.rbGrado4.Name = "rbGrado4";
            this.rbGrado4.Size = new System.Drawing.Size(46, 29);
            this.rbGrado4.TabIndex = 3;
            this.rbGrado4.TabStop = true;
            this.rbGrado4.Text = "x⁴";
            this.rbGrado4.UseVisualStyleBackColor = true;
            this.rbGrado4.Click += new System.EventHandler(this.rbGrado4_CheckedChanged);
            // 
            // rbGrado3
            // 
            this.rbGrado3.AutoSize = true;
            this.rbGrado3.ForeColor = System.Drawing.Color.Black;
            this.rbGrado3.Location = new System.Drawing.Point(337, 91);
            this.rbGrado3.Name = "rbGrado3";
            this.rbGrado3.Size = new System.Drawing.Size(51, 29);
            this.rbGrado3.TabIndex = 2;
            this.rbGrado3.TabStop = true;
            this.rbGrado3.Text = " x³";
            this.rbGrado3.UseVisualStyleBackColor = true;
            this.rbGrado3.CheckedChanged += new System.EventHandler(this.rbGrado3_CheckedChanged);
            // 
            // rbGrado2
            // 
            this.rbGrado2.AutoSize = true;
            this.rbGrado2.ForeColor = System.Drawing.Color.Black;
            this.rbGrado2.Location = new System.Drawing.Point(94, 143);
            this.rbGrado2.Name = "rbGrado2";
            this.rbGrado2.Size = new System.Drawing.Size(46, 29);
            this.rbGrado2.TabIndex = 1;
            this.rbGrado2.TabStop = true;
            this.rbGrado2.Text = "x²";
            this.rbGrado2.UseVisualStyleBackColor = true;
            this.rbGrado2.Click += new System.EventHandler(this.rbGrado2_CheckedChanged);
            // 
            // rbGrado1
            // 
            this.rbGrado1.AutoSize = true;
            this.rbGrado1.ForeColor = System.Drawing.Color.Black;
            this.rbGrado1.Location = new System.Drawing.Point(94, 91);
            this.rbGrado1.Name = "rbGrado1";
            this.rbGrado1.Size = new System.Drawing.Size(44, 29);
            this.rbGrado1.TabIndex = 0;
            this.rbGrado1.TabStop = true;
            this.rbGrado1.Text = " x";
            this.rbGrado1.UseVisualStyleBackColor = true;
            this.rbGrado1.Click += new System.EventHandler(this.rbGrado1_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnEvaluarGrado1);
            this.panel1.Controls.Add(this.btnEvaluar3);
            this.panel1.Controls.Add(this.btnEvaluar2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblFuncion);
            this.panel1.Controls.Add(this.btnEvaluar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.panel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Location = new System.Drawing.Point(68, 217);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 215);
            this.panel1.TabIndex = 10;
            // 
            // btnEvaluarGrado1
            // 
            this.btnEvaluarGrado1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(242)))));
            this.btnEvaluarGrado1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEvaluarGrado1.FlatAppearance.BorderSize = 0;
            this.btnEvaluarGrado1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvaluarGrado1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnEvaluarGrado1.ForeColor = System.Drawing.Color.White;
            this.btnEvaluarGrado1.Location = new System.Drawing.Point(433, 151);
            this.btnEvaluarGrado1.Name = "btnEvaluarGrado1";
            this.btnEvaluarGrado1.Size = new System.Drawing.Size(140, 37);
            this.btnEvaluarGrado1.TabIndex = 9;
            this.btnEvaluarGrado1.Text = "Evaluar";
            this.btnEvaluarGrado1.UseVisualStyleBackColor = false;
            this.btnEvaluarGrado1.Click += new System.EventHandler(this.btnEvaluarGrado1_Click_1);
            // 
            // btnEvaluar3
            // 
            this.btnEvaluar3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(242)))));
            this.btnEvaluar3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEvaluar3.FlatAppearance.BorderSize = 0;
            this.btnEvaluar3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvaluar3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnEvaluar3.ForeColor = System.Drawing.Color.White;
            this.btnEvaluar3.Location = new System.Drawing.Point(433, 151);
            this.btnEvaluar3.Name = "btnEvaluar3";
            this.btnEvaluar3.Size = new System.Drawing.Size(140, 37);
            this.btnEvaluar3.TabIndex = 8;
            this.btnEvaluar3.Text = "Evaluar";
            this.btnEvaluar3.UseVisualStyleBackColor = false;
            this.btnEvaluar3.Click += new System.EventHandler(this.btnEvaluar3_Click_1);
            // 
            // btnEvaluar2
            // 
            this.btnEvaluar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(242)))));
            this.btnEvaluar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEvaluar2.FlatAppearance.BorderSize = 0;
            this.btnEvaluar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvaluar2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnEvaluar2.ForeColor = System.Drawing.Color.White;
            this.btnEvaluar2.Location = new System.Drawing.Point(433, 151);
            this.btnEvaluar2.Name = "btnEvaluar2";
            this.btnEvaluar2.Size = new System.Drawing.Size(140, 37);
            this.btnEvaluar2.TabIndex = 7;
            this.btnEvaluar2.Text = "Evaluar";
            this.btnEvaluar2.UseVisualStyleBackColor = false;
            this.btnEvaluar2.Click += new System.EventHandler(this.btnEvaluar2_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(218, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "\"a\" es un valor numerico";
            // 
            // lblFuncion
            // 
            this.lblFuncion.AutoSize = true;
            this.lblFuncion.Location = new System.Drawing.Point(86, 73);
            this.lblFuncion.Name = "lblFuncion";
            this.lblFuncion.Size = new System.Drawing.Size(79, 25);
            this.lblFuncion.TabIndex = 1;
            this.lblFuncion.Text = "Funcion";
            // 
            // btnEvaluar
            // 
            this.btnEvaluar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(242)))));
            this.btnEvaluar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEvaluar.FlatAppearance.BorderSize = 0;
            this.btnEvaluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvaluar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnEvaluar.ForeColor = System.Drawing.Color.White;
            this.btnEvaluar.Location = new System.Drawing.Point(433, 151);
            this.btnEvaluar.Name = "btnEvaluar";
            this.btnEvaluar.Size = new System.Drawing.Size(140, 37);
            this.btnEvaluar.TabIndex = 5;
            this.btnEvaluar.Text = "Evaluar";
            this.btnEvaluar.UseVisualStyleBackColor = false;
            this.btnEvaluar.Click += new System.EventHandler(this.btnEvaluar_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(357, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tu funcion debe ser similar a la siguiente";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(630, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 34);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Regresar";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Form24
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BackgroundImage = global::Proyecto_Final_Métodos_Númericos.Properties.Resources.Captura_de_pantalla_2025_10_07_223428;
            this.ClientSize = new System.Drawing.Size(762, 477);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form24";
            this.Text = "Elección de grado - Regula Falsi";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbGrado4;
        private System.Windows.Forms.RadioButton rbGrado3;
        private System.Windows.Forms.RadioButton rbGrado2;
        private System.Windows.Forms.RadioButton rbGrado1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEvaluarGrado1;
        private System.Windows.Forms.Button btnEvaluar3;
        private System.Windows.Forms.Button btnEvaluar2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFuncion;
        private System.Windows.Forms.Button btnEvaluar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBack;
    }
}