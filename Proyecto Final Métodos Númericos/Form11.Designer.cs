using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    partial class Form11
    {
        private IContainer components = null;
        private Panel mainPanel;
        private Label lblHeader;
        private Panel solverPanel;
        private Button btnBack;
        private RichTextBox rtbSteps; // para mostrar pasos

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form11));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.solverPanel = new System.Windows.Forms.Panel();
            this.rtbSteps = new System.Windows.Forms.RichTextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.solverPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.btnBack);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(940, 520);
            this.mainPanel.TabIndex = 3;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(24, 18);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(431, 37);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "Solucionador: Eliminación Gauss";
            // 
            // solverPanel
            // 
            this.solverPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.solverPanel.Controls.Add(this.rtbSteps);
            this.solverPanel.Location = new System.Drawing.Point(24, 78);
            this.solverPanel.Name = "solverPanel";
            this.solverPanel.Size = new System.Drawing.Size(880, 360);
            this.solverPanel.TabIndex = 1;
            // 
            // rtbSteps
            // 
            this.rtbSteps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(22)))));
            this.rtbSteps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSteps.Font = new System.Drawing.Font("Consolas", 10F);
            this.rtbSteps.ForeColor = System.Drawing.Color.White;
            this.rtbSteps.Location = new System.Drawing.Point(30, 3);
            this.rtbSteps.Name = "rtbSteps";
            this.rtbSteps.ReadOnly = true;
            this.rtbSteps.Size = new System.Drawing.Size(840, 347);
            this.rtbSteps.TabIndex = 0;
            this.rtbSteps.Text = "";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(808, 25);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(96, 36);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Regresar";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Form11
            // 
            this.ClientSize = new System.Drawing.Size(940, 520);
            this.Controls.Add(this.solverPanel);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form11";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Solucionador — Gauss";
            this.Load += new System.EventHandler(this.Form11_Load);
            this.mainPanel.ResumeLayout(false);
            this.solverPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}