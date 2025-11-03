using System;
using System.Windows.Forms;
using System.Drawing;

namespace Proyecto_Final_Métodos_Númericos
{
    partial class Form32
    {
        private System.ComponentModel.IContainer components = null;
        private Panel mainPanel;
        private Label lblHeader;
        private DataGridView dgvNewton;
        private Label lblRaiz;
        private Label lblEstado;
        private Button btnRegresar;
        private Button btnCerrar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form32));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.dgvNewton = new System.Windows.Forms.DataGridView();
            this.lblRaiz = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewton)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.mainPanel.Controls.Add(this.lblHeader);
            this.mainPanel.Controls.Add(this.dgvNewton);
            this.mainPanel.Controls.Add(this.lblRaiz);
            this.mainPanel.Controls.Add(this.lblEstado);
            this.mainPanel.Controls.Add(this.btnRegresar);
            this.mainPanel.Controls.Add(this.btnCerrar);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(760, 460);
            this.mainPanel.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(20, 16);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(293, 25);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Iteraciones - Newton - Raphson";
            // 
            // dgvNewton
            // 
            this.dgvNewton.AllowUserToAddRows = false;
            this.dgvNewton.AllowUserToDeleteRows = false;
            this.dgvNewton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(33)))), ((int)(((byte)(70)))));
            this.dgvNewton.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNewton.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewton.Location = new System.Drawing.Point(24, 54);
            this.dgvNewton.Name = "dgvNewton";
            this.dgvNewton.ReadOnly = true;
            this.dgvNewton.RowHeadersVisible = false;
            this.dgvNewton.Size = new System.Drawing.Size(712, 320);
            this.dgvNewton.TabIndex = 1;
            // 
            // lblRaiz
            // 
            this.lblRaiz.AutoSize = true;
            this.lblRaiz.ForeColor = System.Drawing.Color.White;
            this.lblRaiz.Location = new System.Drawing.Point(24, 384);
            this.lblRaiz.Name = "lblRaiz";
            this.lblRaiz.Size = new System.Drawing.Size(84, 13);
            this.lblRaiz.TabIndex = 2;
            this.lblRaiz.Text = "Raíz: ————————";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblEstado.Location = new System.Drawing.Point(24, 404);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(52, 13);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Estado: —";
            // 
            // btnRegresar
            // 
            this.btnRegresar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRegresar.BackColor = System.Drawing.Color.Firebrick;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.Location = new System.Drawing.Point(444, 408);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(140, 34);
            this.btnRegresar.TabIndex = 4;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCerrar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(596, 408);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(140, 34);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // Form32
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(760, 460);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form32";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Método de Newton–Raphson - Iteraciones";
            this.Load += new System.EventHandler(this.Form32_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewton)).EndInit();
            this.ResumeLayout(false);

        }
    }
}