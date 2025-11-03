using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    partial class Form31
    {
        private System.ComponentModel.IContainer components = null;
        private Panel mainPanel;
        private Panel headerPanel;
        private Label lblTitle;

        private TextBox txtA4;
        private TextBox txtA3;
        private TextBox txtA2;
        private TextBox txtA1;
        private TextBox txtA0; // nuevo término independiente
        private Label lblPow4;
        private Label lblPow3;
        private Label lblPow2;
        private Label lblPow1;
        private Label lblX4;
        private Label lblX3;
        private Label lblX2;
        private Label lblX1;

        private TextBox txtVista;

        private Button btnInsertar;
        private Button btnBorrar;
        private Button btnSalir;
        private Button btnEditar;
        private Button btnSiguiente;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form31));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtA4 = new System.Windows.Forms.TextBox();
            this.txtA3 = new System.Windows.Forms.TextBox();
            this.txtA2 = new System.Windows.Forms.TextBox();
            this.txtA1 = new System.Windows.Forms.TextBox();
            this.txtA0 = new System.Windows.Forms.TextBox();
            this.lblPow4 = new System.Windows.Forms.Label();
            this.lblPow3 = new System.Windows.Forms.Label();
            this.lblPow2 = new System.Windows.Forms.Label();
            this.lblPow1 = new System.Windows.Forms.Label();
            this.lblX4 = new System.Windows.Forms.Label();
            this.lblX3 = new System.Windows.Forms.Label();
            this.lblX2 = new System.Windows.Forms.Label();
            this.lblX1 = new System.Windows.Forms.Label();
            this.txtVista = new System.Windows.Forms.TextBox();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.mainPanel.Controls.Add(this.headerPanel);
            this.mainPanel.Controls.Add(this.txtA4);
            this.mainPanel.Controls.Add(this.txtA3);
            this.mainPanel.Controls.Add(this.txtA2);
            this.mainPanel.Controls.Add(this.txtA1);
            this.mainPanel.Controls.Add(this.txtA0);
            this.mainPanel.Controls.Add(this.lblPow4);
            this.mainPanel.Controls.Add(this.lblPow3);
            this.mainPanel.Controls.Add(this.lblPow2);
            this.mainPanel.Controls.Add(this.lblPow1);
            this.mainPanel.Controls.Add(this.lblX4);
            this.mainPanel.Controls.Add(this.lblX3);
            this.mainPanel.Controls.Add(this.lblX2);
            this.mainPanel.Controls.Add(this.lblX1);
            this.mainPanel.Controls.Add(this.txtVista);
            this.mainPanel.Controls.Add(this.btnInsertar);
            this.mainPanel.Controls.Add(this.btnBorrar);
            this.mainPanel.Controls.Add(this.btnSalir);
            this.mainPanel.Controls.Add(this.btnEditar);
            this.mainPanel.Controls.Add(this.btnSiguiente);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(826, 420);
            this.mainPanel.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(826, 56);
            this.headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(206, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ingreso de datos";
            // 
            // txtA4
            // 
            this.txtA4.Location = new System.Drawing.Point(80, 90);
            this.txtA4.Name = "txtA4";
            this.txtA4.Size = new System.Drawing.Size(60, 20);
            this.txtA4.TabIndex = 1;
            // 
            // txtA3
            // 
            this.txtA3.Location = new System.Drawing.Point(200, 90);
            this.txtA3.Name = "txtA3";
            this.txtA3.Size = new System.Drawing.Size(60, 20);
            this.txtA3.TabIndex = 2;
            // 
            // txtA2
            // 
            this.txtA2.Location = new System.Drawing.Point(320, 90);
            this.txtA2.Name = "txtA2";
            this.txtA2.Size = new System.Drawing.Size(60, 20);
            this.txtA2.TabIndex = 3;
            // 
            // txtA1
            // 
            this.txtA1.Location = new System.Drawing.Point(440, 90);
            this.txtA1.Name = "txtA1";
            this.txtA1.Size = new System.Drawing.Size(60, 20);
            this.txtA1.TabIndex = 4;
            // 
            // txtA0
            // 
            this.txtA0.Location = new System.Drawing.Point(560, 90);
            this.txtA0.Name = "txtA0";
            this.txtA0.Size = new System.Drawing.Size(60, 20);
            this.txtA0.TabIndex = 5;
            // 
            // lblPow4
            // 
            this.lblPow4.AutoSize = true;
            this.lblPow4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblPow4.ForeColor = System.Drawing.Color.White;
            this.lblPow4.Location = new System.Drawing.Point(160, 80);
            this.lblPow4.Name = "lblPow4";
            this.lblPow4.Size = new System.Drawing.Size(13, 13);
            this.lblPow4.TabIndex = 6;
            this.lblPow4.Text = "4";
            // 
            // lblPow3
            // 
            this.lblPow3.AutoSize = true;
            this.lblPow3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblPow3.ForeColor = System.Drawing.Color.White;
            this.lblPow3.Location = new System.Drawing.Point(280, 80);
            this.lblPow3.Name = "lblPow3";
            this.lblPow3.Size = new System.Drawing.Size(13, 13);
            this.lblPow3.TabIndex = 7;
            this.lblPow3.Text = "3";
            // 
            // lblPow2
            // 
            this.lblPow2.AutoSize = true;
            this.lblPow2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblPow2.ForeColor = System.Drawing.Color.White;
            this.lblPow2.Location = new System.Drawing.Point(400, 80);
            this.lblPow2.Name = "lblPow2";
            this.lblPow2.Size = new System.Drawing.Size(13, 13);
            this.lblPow2.TabIndex = 8;
            this.lblPow2.Text = "2";
            // 
            // lblPow1
            // 
            this.lblPow1.AutoSize = true;
            this.lblPow1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblPow1.ForeColor = System.Drawing.Color.White;
            this.lblPow1.Location = new System.Drawing.Point(520, 80);
            this.lblPow1.Name = "lblPow1";
            this.lblPow1.Size = new System.Drawing.Size(0, 13);
            this.lblPow1.TabIndex = 9;
            this.lblPow1.Visible = false;
            // 
            // lblX4
            // 
            this.lblX4.AutoSize = true;
            this.lblX4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblX4.ForeColor = System.Drawing.Color.White;
            this.lblX4.Location = new System.Drawing.Point(150, 89);
            this.lblX4.Name = "lblX4";
            this.lblX4.Size = new System.Drawing.Size(19, 21);
            this.lblX4.TabIndex = 10;
            this.lblX4.Text = "x";
            // 
            // lblX3
            // 
            this.lblX3.AutoSize = true;
            this.lblX3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblX3.ForeColor = System.Drawing.Color.White;
            this.lblX3.Location = new System.Drawing.Point(270, 89);
            this.lblX3.Name = "lblX3";
            this.lblX3.Size = new System.Drawing.Size(19, 21);
            this.lblX3.TabIndex = 11;
            this.lblX3.Text = "x";
            // 
            // lblX2
            // 
            this.lblX2.AutoSize = true;
            this.lblX2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblX2.ForeColor = System.Drawing.Color.White;
            this.lblX2.Location = new System.Drawing.Point(390, 89);
            this.lblX2.Name = "lblX2";
            this.lblX2.Size = new System.Drawing.Size(19, 21);
            this.lblX2.TabIndex = 12;
            this.lblX2.Text = "x";
            // 
            // lblX1
            // 
            this.lblX1.AutoSize = true;
            this.lblX1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblX1.ForeColor = System.Drawing.Color.White;
            this.lblX1.Location = new System.Drawing.Point(510, 89);
            this.lblX1.Name = "lblX1";
            this.lblX1.Size = new System.Drawing.Size(19, 21);
            this.lblX1.TabIndex = 13;
            this.lblX1.Text = "x";
            // 
            // txtVista
            // 
            this.txtVista.Location = new System.Drawing.Point(163, 139);
            this.txtVista.Multiline = true;
            this.txtVista.Name = "txtVista";
            this.txtVista.ReadOnly = true;
            this.txtVista.Size = new System.Drawing.Size(440, 120);
            this.txtVista.TabIndex = 20;
            // 
            // btnInsertar
            // 
            this.btnInsertar.BackColor = System.Drawing.Color.Gold;
            this.btnInsertar.FlatAppearance.BorderSize = 0;
            this.btnInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertar.ForeColor = System.Drawing.Color.Black;
            this.btnInsertar.Location = new System.Drawing.Point(39, 290);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(120, 36);
            this.btnInsertar.TabIndex = 21;
            this.btnInsertar.Text = "Insertar función";
            this.btnInsertar.UseVisualStyleBackColor = false;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnBorrar.FlatAppearance.BorderSize = 0;
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrar.ForeColor = System.Drawing.Color.White;
            this.btnBorrar.Location = new System.Drawing.Point(243, 290);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(120, 36);
            this.btnBorrar.TabIndex = 22;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(80)))));
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(409, 290);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(120, 36);
            this.btnSalir.TabIndex = 23;
            this.btnSalir.Text = "Regresar";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(602, 290);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(120, 36);
            this.btnEditar.TabIndex = 24;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSiguiente.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.ForeColor = System.Drawing.Color.White;
            this.btnSiguiente.Location = new System.Drawing.Point(674, 86);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(120, 40);
            this.btnSiguiente.TabIndex = 25;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // Form31
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(826, 420);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form31";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Datos iniciales - Newton–Raphson";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}