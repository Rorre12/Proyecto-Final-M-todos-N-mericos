namespace Proyecto_Final_Métodos_Númericos
{
    partial class Form38
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TextBox txtFuncion;
        private System.Windows.Forms.TextBox txtX0;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblFuncion;
        private System.Windows.Forms.Label lblX0;
        private System.Windows.Forms.Label lblH;
        private System.Windows.Forms.Label lblPaso;
        private System.Windows.Forms.TextBox txtXTarget;
        private System.Windows.Forms.Label lblXTarget;
        private System.Windows.Forms.TextBox txtX0MinusH;
        private System.Windows.Forms.Label lblX0MinusH;
        private System.Windows.Forms.TextBox txtFx0;
        private System.Windows.Forms.TextBox txtFx0MinusH;
        private System.Windows.Forms.Label lblFx0;
        private System.Windows.Forms.Label lblFx0MinusH;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label lblResultado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form38));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblPaso = new System.Windows.Forms.Label();
            this.lblX0MinusH = new System.Windows.Forms.Label();
            this.txtX0MinusH = new System.Windows.Forms.TextBox();
            this.lblFx0 = new System.Windows.Forms.Label();
            this.txtFx0 = new System.Windows.Forms.TextBox();
            this.lblFx0MinusH = new System.Windows.Forms.Label();
            this.txtFx0MinusH = new System.Windows.Forms.TextBox();
            this.lblResultado = new System.Windows.Forms.Label();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblFuncion = new System.Windows.Forms.Label();
            this.txtFuncion = new System.Windows.Forms.TextBox();
            this.lblXTarget = new System.Windows.Forms.Label();
            this.txtXTarget = new System.Windows.Forms.TextBox();
            this.lblX0 = new System.Windows.Forms.Label();
            this.txtX0 = new System.Windows.Forms.TextBox();
            this.lblH = new System.Windows.Forms.Label();
            this.txtH = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.lblSubtitle);
            this.mainPanel.Controls.Add(this.lblTitle);
            this.mainPanel.Controls.Add(this.panelRight);
            this.mainPanel.Controls.Add(this.panelLeft);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(980, 580);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Eras Medium ITC", 12F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSubtitle.Location = new System.Drawing.Point(362, 64);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(248, 19);
            this.lblSubtitle.TabIndex = 0;
            this.lblSubtitle.Text = "f\'(x0) = ( f(x0 + h) - f(x0 - h) ) / (2h)";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Eras Bold ITC", 22F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(360, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(497, 35);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Derivación numérica | Centrada";
            // 
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.BackColor = System.Drawing.Color.Transparent;
            this.panelRight.Controls.Add(this.lblPaso);
            this.panelRight.Controls.Add(this.lblX0MinusH);
            this.panelRight.Controls.Add(this.txtX0MinusH);
            this.panelRight.Controls.Add(this.lblFx0);
            this.panelRight.Controls.Add(this.txtFx0);
            this.panelRight.Controls.Add(this.lblFx0MinusH);
            this.panelRight.Controls.Add(this.txtFx0MinusH);
            this.panelRight.Controls.Add(this.lblResultado);
            this.panelRight.Controls.Add(this.txtResultado);
            this.panelRight.Location = new System.Drawing.Point(340, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(640, 580);
            this.panelRight.TabIndex = 2;
            this.panelRight.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRight_Paint);
            // 
            // lblPaso
            // 
            this.lblPaso.AutoSize = true;
            this.lblPaso.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblPaso.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPaso.Location = new System.Drawing.Point(24, 90);
            this.lblPaso.Name = "lblPaso";
            this.lblPaso.Size = new System.Drawing.Size(297, 19);
            this.lblPaso.TabIndex = 0;
            this.lblPaso.Text = "Paso: calcular x0 - h, evaluar f(x0-h) y f(x0)";
            // 
            // lblX0MinusH
            // 
            this.lblX0MinusH.AutoSize = true;
            this.lblX0MinusH.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblX0MinusH.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblX0MinusH.Location = new System.Drawing.Point(24, 134);
            this.lblX0MinusH.Name = "lblX0MinusH";
            this.lblX0MinusH.Size = new System.Drawing.Size(48, 19);
            this.lblX0MinusH.TabIndex = 1;
            this.lblX0MinusH.Text = "x0 - h:";
            // 
            // txtX0MinusH
            // 
            this.txtX0MinusH.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtX0MinusH.Location = new System.Drawing.Point(90, 132);
            this.txtX0MinusH.Name = "txtX0MinusH";
            this.txtX0MinusH.ReadOnly = true;
            this.txtX0MinusH.Size = new System.Drawing.Size(140, 26);
            this.txtX0MinusH.TabIndex = 2;
            // 
            // lblFx0
            // 
            this.lblFx0.AutoSize = true;
            this.lblFx0.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblFx0.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblFx0.Location = new System.Drawing.Point(250, 134);
            this.lblFx0.Name = "lblFx0";
            this.lblFx0.Size = new System.Drawing.Size(38, 19);
            this.lblFx0.TabIndex = 3;
            this.lblFx0.Text = "f(x0):";
            // 
            // txtFx0
            // 
            this.txtFx0.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtFx0.Location = new System.Drawing.Point(300, 132);
            this.txtFx0.Name = "txtFx0";
            this.txtFx0.ReadOnly = true;
            this.txtFx0.Size = new System.Drawing.Size(160, 26);
            this.txtFx0.TabIndex = 4;
            // 
            // lblFx0MinusH
            // 
            this.lblFx0MinusH.AutoSize = true;
            this.lblFx0MinusH.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblFx0MinusH.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblFx0MinusH.Location = new System.Drawing.Point(24, 172);
            this.lblFx0MinusH.Name = "lblFx0MinusH";
            this.lblFx0MinusH.Size = new System.Drawing.Size(60, 19);
            this.lblFx0MinusH.TabIndex = 5;
            this.lblFx0MinusH.Text = "f(x0 - h):";
            // 
            // txtFx0MinusH
            // 
            this.txtFx0MinusH.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtFx0MinusH.Location = new System.Drawing.Point(100, 170);
            this.txtFx0MinusH.Name = "txtFx0MinusH";
            this.txtFx0MinusH.ReadOnly = true;
            this.txtFx0MinusH.Size = new System.Drawing.Size(160, 26);
            this.txtFx0MinusH.TabIndex = 6;
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblResultado.ForeColor = System.Drawing.Color.White;
            this.lblResultado.Location = new System.Drawing.Point(24, 214);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(126, 20);
            this.lblResultado.TabIndex = 7;
            this.lblResultado.Text = "Resultado f\'(x0):";
            // 
            // txtResultado
            // 
            this.txtResultado.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtResultado.Location = new System.Drawing.Point(170, 212);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.Size = new System.Drawing.Size(220, 26);
            this.txtResultado.TabIndex = 8;
            // 
            // panelLeft
            // 
            this.panelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelLeft.BackColor = System.Drawing.Color.Transparent;
            this.panelLeft.Controls.Add(this.lblFuncion);
            this.panelLeft.Controls.Add(this.txtFuncion);
            this.panelLeft.Controls.Add(this.lblXTarget);
            this.panelLeft.Controls.Add(this.txtXTarget);
            this.panelLeft.Controls.Add(this.lblX0);
            this.panelLeft.Controls.Add(this.txtX0);
            this.panelLeft.Controls.Add(this.lblH);
            this.panelLeft.Controls.Add(this.txtH);
            this.panelLeft.Controls.Add(this.btnCalcular);
            this.panelLeft.Controls.Add(this.btnRegresar);
            this.panelLeft.Controls.Add(this.btnLimpiar);
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(340, 580);
            this.panelLeft.TabIndex = 3;
            this.panelLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLeft_Paint);
            // 
            // lblFuncion
            // 
            this.lblFuncion.AutoSize = true;
            this.lblFuncion.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblFuncion.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblFuncion.Location = new System.Drawing.Point(24, 90);
            this.lblFuncion.Name = "lblFuncion";
            this.lblFuncion.Size = new System.Drawing.Size(91, 19);
            this.lblFuncion.TabIndex = 0;
            this.lblFuncion.Text = "Función f(x):";
            // 
            // txtFuncion
            // 
            this.txtFuncion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtFuncion.Location = new System.Drawing.Point(24, 112);
            this.txtFuncion.Name = "txtFuncion";
            this.txtFuncion.Size = new System.Drawing.Size(290, 27);
            this.txtFuncion.TabIndex = 1;
            // 
            // lblXTarget
            // 
            this.lblXTarget.AutoSize = true;
            this.lblXTarget.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblXTarget.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblXTarget.Location = new System.Drawing.Point(24, 154);
            this.lblXTarget.Name = "lblXTarget";
            this.lblXTarget.Size = new System.Drawing.Size(66, 19);
            this.lblXTarget.TabIndex = 2;
            this.lblXTarget.Text = "f\'( ? ) en:";
            // 
            // txtXTarget
            // 
            this.txtXTarget.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtXTarget.Location = new System.Drawing.Point(110, 152);
            this.txtXTarget.Name = "txtXTarget";
            this.txtXTarget.Size = new System.Drawing.Size(90, 27);
            this.txtXTarget.TabIndex = 3;
            // 
            // lblX0
            // 
            this.lblX0.AutoSize = true;
            this.lblX0.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblX0.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblX0.Location = new System.Drawing.Point(24, 194);
            this.lblX0.Name = "lblX0";
            this.lblX0.Size = new System.Drawing.Size(29, 19);
            this.lblX0.TabIndex = 4;
            this.lblX0.Text = "x0:";
            // 
            // txtX0
            // 
            this.txtX0.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtX0.Location = new System.Drawing.Point(60, 192);
            this.txtX0.Name = "txtX0";
            this.txtX0.Size = new System.Drawing.Size(90, 27);
            this.txtX0.TabIndex = 5;
            // 
            // lblH
            // 
            this.lblH.AutoSize = true;
            this.lblH.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblH.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblH.Location = new System.Drawing.Point(170, 194);
            this.lblH.Name = "lblH";
            this.lblH.Size = new System.Drawing.Size(21, 19);
            this.lblH.TabIndex = 6;
            this.lblH.Text = "h:";
            // 
            // txtH
            // 
            this.txtH.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtH.Location = new System.Drawing.Point(195, 192);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(119, 27);
            this.txtH.TabIndex = 7;
            // 
            // btnCalcular
            // 
            this.btnCalcular.BackColor = System.Drawing.Color.Cyan;
            this.btnCalcular.Font = new System.Drawing.Font("Eras Demi ITC", 16F);
            this.btnCalcular.Location = new System.Drawing.Point(24, 248);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(290, 46);
            this.btnCalcular.TabIndex = 8;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.btnRegresar.Font = new System.Drawing.Font("Eras Demi ITC", 14F);
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.Location = new System.Drawing.Point(24, 306);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(290, 40);
            this.btnRegresar.TabIndex = 9;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(160)))));
            this.btnLimpiar.Font = new System.Drawing.Font("Eras Demi ITC", 14F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(24, 354);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(290, 40);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // Form38
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 580);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form38";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Centradas | Solucionador";
            this.Load += new System.EventHandler(this.Form38_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}