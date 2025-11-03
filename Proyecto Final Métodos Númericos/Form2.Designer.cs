using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Proyecto_Final_Métodos_Númericos
{
    partial class Form2
    {
        private IContainer components = null;
        private Panel mainPanel;
        private Label lblHeader;
        private Button btnSystems;
        private Button btnRoots;
        private Button btnDerivation;
        private Button btnIntegration;
        private Button btnBack;
        private PictureBox picAnim;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnSystems = new System.Windows.Forms.Button();
            this.btnRoots = new System.Windows.Forms.Button();
            this.btnDerivation = new System.Windows.Forms.Button();
            this.btnIntegration = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.picAnim = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAnim)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(980, 520);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(80, 16);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(600, 45);
            this.lblHeader.TabIndex = 6;
            this.lblHeader.Text = "Menú Principal — Métodos Numéricos";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSystems
            // 
            this.btnSystems.FlatAppearance.BorderSize = 0;
            this.btnSystems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystems.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSystems.ForeColor = System.Drawing.Color.White;
            this.btnSystems.Location = new System.Drawing.Point(0, 0);
            this.btnSystems.Name = "btnSystems";
            this.btnSystems.Size = new System.Drawing.Size(360, 84);
            this.btnSystems.TabIndex = 4;
            this.btnSystems.Text = "Sistemas de ecuaciones lineales";
            this.btnSystems.Click += new System.EventHandler(this.btnSystems_Click);
            // 
            // btnRoots
            // 
            this.btnRoots.FlatAppearance.BorderSize = 0;
            this.btnRoots.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoots.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRoots.ForeColor = System.Drawing.Color.White;
            this.btnRoots.Location = new System.Drawing.Point(0, 0);
            this.btnRoots.Name = "btnRoots";
            this.btnRoots.Size = new System.Drawing.Size(360, 84);
            this.btnRoots.TabIndex = 3;
            this.btnRoots.Text = "Raíces de polinomios";
            this.btnRoots.Click += new System.EventHandler(this.btnRoots_Click);
            // 
            // btnDerivation
            // 
            this.btnDerivation.FlatAppearance.BorderSize = 0;
            this.btnDerivation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDerivation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDerivation.ForeColor = System.Drawing.Color.White;
            this.btnDerivation.Location = new System.Drawing.Point(0, 0);
            this.btnDerivation.Name = "btnDerivation";
            this.btnDerivation.Size = new System.Drawing.Size(360, 84);
            this.btnDerivation.TabIndex = 2;
            this.btnDerivation.Text = "Derivación numérica";
            this.btnDerivation.Click += new System.EventHandler(this.btnDerivation_Click);
            // 
            // btnIntegration
            // 
            this.btnIntegration.FlatAppearance.BorderSize = 0;
            this.btnIntegration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIntegration.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnIntegration.ForeColor = System.Drawing.Color.White;
            this.btnIntegration.Location = new System.Drawing.Point(0, 0);
            this.btnIntegration.Name = "btnIntegration";
            this.btnIntegration.Size = new System.Drawing.Size(360, 84);
            this.btnIntegration.TabIndex = 1;
            this.btnIntegration.Text = "Integración numérica";
            this.btnIntegration.Click += new System.EventHandler(this.btnIntegration_Click);
            // 
            // btnBack
            // 
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(840, 16);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 36);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Cerrar";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // picAnim
            // 
            this.picAnim.BackColor = System.Drawing.Color.Transparent;
            this.picAnim.Location = new System.Drawing.Point(330, 94);
            this.picAnim.Name = "picAnim";
            this.picAnim.Size = new System.Drawing.Size(320, 160);
            this.picAnim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picAnim.TabIndex = 5;
            this.picAnim.TabStop = false;
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(980, 520);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnIntegration);
            this.Controls.Add(this.btnDerivation);
            this.Controls.Add(this.btnRoots);
            this.Controls.Add(this.btnSystems);
            this.Controls.Add(this.picAnim);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú principal del sistema";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Resize += new System.EventHandler(this.Form2_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picAnim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}