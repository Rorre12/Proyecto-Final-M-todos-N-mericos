using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    partial class Form30
    {
        private System.ComponentModel.IContainer components = null;
        private Panel mainPanel;
        private Label lblHeader;
        private Panel cardPanel;
        private Button btnComenzar;
        private Button btnBack;
        private PictureBox picDecor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form30));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.cardPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnComenzar = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.picDecor = new System.Windows.Forms.PictureBox();
            this.mainPanel.SuspendLayout();
            this.cardPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDecor)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(22)))));
            this.mainPanel.Controls.Add(this.lblHeader);
            this.mainPanel.Controls.Add(this.cardPanel);
            this.mainPanel.Controls.Add(this.picDecor);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(980, 560);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(28, 18);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(267, 41);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Newton–Raphson";
            // 
            // cardPanel
            // 
            this.cardPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.cardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardPanel.Controls.Add(this.pictureBox1);
            this.cardPanel.Controls.Add(this.btnComenzar);
            this.cardPanel.Controls.Add(this.btnBack);
            this.cardPanel.Location = new System.Drawing.Point(28, 78);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.Size = new System.Drawing.Size(560, 440);
            this.cardPanel.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Proyecto_Final_Métodos_Númericos.Properties.Resources.images;
            this.pictureBox1.Location = new System.Drawing.Point(117, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 287);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnComenzar
            // 
            this.btnComenzar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnComenzar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.btnComenzar.FlatAppearance.BorderSize = 0;
            this.btnComenzar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComenzar.ForeColor = System.Drawing.Color.White;
            this.btnComenzar.Location = new System.Drawing.Point(53, 370);
            this.btnComenzar.Name = "btnComenzar";
            this.btnComenzar.Size = new System.Drawing.Size(160, 40);
            this.btnComenzar.TabIndex = 1;
            this.btnComenzar.Text = "Comenzar";
            this.btnComenzar.UseVisualStyleBackColor = false;
            this.btnComenzar.Click += new System.EventHandler(this.btnComenzar_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(322, 370);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(160, 40);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Regresar";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // picDecor
            // 
            this.picDecor.BackColor = System.Drawing.Color.Transparent;
            this.picDecor.Location = new System.Drawing.Point(612, 78);
            this.picDecor.Name = "picDecor";
            this.picDecor.Size = new System.Drawing.Size(340, 440);
            this.picDecor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDecor.TabIndex = 2;
            this.picDecor.TabStop = false;
            // 
            // Form30
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(980, 560);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form30";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Newton–Raphson | Bienvenida";
            this.Load += new System.EventHandler(this.Form30_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.cardPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDecor)).EndInit();
            this.ResumeLayout(false);

        }

        private PictureBox pictureBox1;
    }
}
