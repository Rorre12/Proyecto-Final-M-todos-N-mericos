using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    partial class Form10
    {
        private IContainer components = null;
        private Panel mainPanel;
        private Label lblHeader;
        private Panel cardPanel;
        private Label lblSubtitle;
        private Label lblSize;
        private NumericUpDown nudSize;
        private Button btnCreate;
        private Button btnExample;
        private Button btnOpenSolver;
        private Button btnBack;
        private Button btnRegresar;
        private PictureBox picDecor;
        private Panel matrixPanel; // nuevo panel para la matriz

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form10));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.picDecor = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cardPanel = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.nudSize = new System.Windows.Forms.NumericUpDown();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnExample = new System.Windows.Forms.Button();
            this.btnOpenSolver = new System.Windows.Forms.Button();
            this.matrixPanel = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDecor)).BeginInit();
            this.cardPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.picDecor);
            this.mainPanel.Controls.Add(this.button1);
            this.mainPanel.Controls.Add(this.cardPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(980, 540);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // picDecor
            // 
            this.picDecor.BackColor = System.Drawing.Color.Transparent;
            this.picDecor.Location = new System.Drawing.Point(613, 53);
            this.picDecor.Name = "picDecor";
            this.picDecor.Size = new System.Drawing.Size(355, 465);
            this.picDecor.TabIndex = 2;
            this.picDecor.TabStop = false;
            this.picDecor.Click += new System.EventHandler(this.picDecor_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(872, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cardPanel
            // 
            this.cardPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.cardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardPanel.Controls.Add(this.lblSubtitle);
            this.cardPanel.Controls.Add(this.lblSize);
            this.cardPanel.Controls.Add(this.nudSize);
            this.cardPanel.Controls.Add(this.btnCreate);
            this.cardPanel.Controls.Add(this.btnExample);
            this.cardPanel.Controls.Add(this.btnOpenSolver);
            this.cardPanel.Controls.Add(this.matrixPanel);
            this.cardPanel.Location = new System.Drawing.Point(12, 53);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.Size = new System.Drawing.Size(595, 465);
            this.cardPanel.TabIndex = 3;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblSubtitle.Location = new System.Drawing.Point(3, 0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(425, 19);
            this.lblSubtitle.TabIndex = 0;
            this.lblSubtitle.Text = "Configura tu sistema y abre el solucionador de eliminación de Gauss";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSize.ForeColor = System.Drawing.Color.White;
            this.lblSize.Location = new System.Drawing.Point(3, 26);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(127, 20);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "Tamaño n (n×n):";
            // 
            // nudSize
            // 
            this.nudSize.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.nudSize.Location = new System.Drawing.Point(18, 49);
            this.nudSize.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudSize.Name = "nudSize";
            this.nudSize.Size = new System.Drawing.Size(80, 29);
            this.nudSize.TabIndex = 2;
            this.nudSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudSize.ValueChanged += new System.EventHandler(this.nudSize_ValueChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(130, 49);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(94, 32);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Crear";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnExample
            // 
            this.btnExample.Location = new System.Drawing.Point(253, 49);
            this.btnExample.Name = "btnExample";
            this.btnExample.Size = new System.Drawing.Size(85, 32);
            this.btnExample.TabIndex = 2;
            this.btnExample.Text = "Ejemplo";
            this.btnExample.UseVisualStyleBackColor = true;
            this.btnExample.Click += new System.EventHandler(this.btnExample_Click);
            // 
            // btnOpenSolver
            // 
            this.btnOpenSolver.Location = new System.Drawing.Point(359, 47);
            this.btnOpenSolver.Name = "btnOpenSolver";
            this.btnOpenSolver.Size = new System.Drawing.Size(140, 36);
            this.btnOpenSolver.TabIndex = 3;
            this.btnOpenSolver.Text = "Abrir Solucionador";
            this.btnOpenSolver.UseVisualStyleBackColor = true;
            this.btnOpenSolver.Click += new System.EventHandler(this.btnOpenSolver_Click);
            // 
            // matrixPanel
            // 
            this.matrixPanel.BackColor = System.Drawing.Color.Transparent;
            this.matrixPanel.Location = new System.Drawing.Point(18, 154);
            this.matrixPanel.Name = "matrixPanel";
            this.matrixPanel.Size = new System.Drawing.Size(520, 280);
            this.matrixPanel.TabIndex = 5;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(28, 16);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(300, 41);
            this.lblHeader.TabIndex = 4;
            this.lblHeader.Text = "Eliminación Gaussiana";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(408, 60);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(64, 36);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Cerrar";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(484, 60);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(64, 36);
            this.btnRegresar.TabIndex = 5;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // Form10
            // 
            this.ClientSize = new System.Drawing.Size(980, 540);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form10";
            this.Text = "Eliminación Gaussiana";
            this.Load += new System.EventHandler(this.Form10_Load);
            this.Resize += new System.EventHandler(this.Form10_Resize);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDecor)).EndInit();
            this.cardPanel.ResumeLayout(false);
            this.cardPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
    }
}