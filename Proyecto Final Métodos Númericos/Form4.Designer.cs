using System.ComponentModel;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    partial class Form4
    {
        private IContainer components = null;
        private Panel mainPanel;
        private Label lblHeader;
        private Button btnBolzano;
        private Button btnRegula;
        private Button btnNewton;
        private Button btnSecante;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnBolzano = new System.Windows.Forms.Button();
            this.btnRegula = new System.Windows.Forms.Button();
            this.btnNewton = new System.Windows.Forms.Button();
            this.btnSecante = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 420);
            this.mainPanel.TabIndex = 6;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(24, 18);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(289, 37);
            this.lblHeader.TabIndex = 5;
            this.lblHeader.Text = "Raíces de polinomios";
            // 
            // btnBolzano
            // 
            this.btnBolzano.FlatAppearance.BorderSize = 0;
            this.btnBolzano.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBolzano.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBolzano.ForeColor = System.Drawing.Color.White;
            this.btnBolzano.Location = new System.Drawing.Point(24, 84);
            this.btnBolzano.Name = "btnBolzano";
            this.btnBolzano.Size = new System.Drawing.Size(360, 64);
            this.btnBolzano.TabIndex = 4;
            this.btnBolzano.Text = "Bolzano (Bisección)";
            this.btnBolzano.Click += new System.EventHandler(this.btnBolzano_Click);
            // 
            // btnRegula
            // 
            this.btnRegula.FlatAppearance.BorderSize = 0;
            this.btnRegula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegula.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRegula.ForeColor = System.Drawing.Color.White;
            this.btnRegula.Location = new System.Drawing.Point(24, 160);
            this.btnRegula.Name = "btnRegula";
            this.btnRegula.Size = new System.Drawing.Size(360, 64);
            this.btnRegula.TabIndex = 3;
            this.btnRegula.Text = "Regula Falsi";
            this.btnRegula.Click += new System.EventHandler(this.btnRegula_Click);
            // 
            // btnNewton
            // 
            this.btnNewton.FlatAppearance.BorderSize = 0;
            this.btnNewton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnNewton.ForeColor = System.Drawing.Color.White;
            this.btnNewton.Location = new System.Drawing.Point(24, 236);
            this.btnNewton.Name = "btnNewton";
            this.btnNewton.Size = new System.Drawing.Size(360, 64);
            this.btnNewton.TabIndex = 2;
            this.btnNewton.Text = "Newton-Raphson";
            this.btnNewton.Click += new System.EventHandler(this.btnNewton_Click);
            // 
            // btnSecante
            // 
            this.btnSecante.FlatAppearance.BorderSize = 0;
            this.btnSecante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecante.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSecante.ForeColor = System.Drawing.Color.White;
            this.btnSecante.Location = new System.Drawing.Point(24, 312);
            this.btnSecante.Name = "btnSecante";
            this.btnSecante.Size = new System.Drawing.Size(360, 64);
            this.btnSecante.TabIndex = 1;
            this.btnSecante.Text = "Secante";
            this.btnSecante.Click += new System.EventHandler(this.btnSecante_Click);
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
            this.btnClose.Text = "Cerrar";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form4
            // 
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSecante);
            this.Controls.Add(this.btnNewton);
            this.Controls.Add(this.btnRegula);
            this.Controls.Add(this.btnBolzano);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apartado de Raíces";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}