namespace Proyecto_Final_Métodos_Númericos
{
    partial class Form40
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
        private System.Windows.Forms.Label lblPasoCentrada;
        private System.Windows.Forms.TextBox txtXTarget;
        private System.Windows.Forms.Label lblXTarget;
        private System.Windows.Forms.TextBox txtX0MinusH;
        private System.Windows.Forms.Label lblX0MinusH;
        private System.Windows.Forms.TextBox txtFx0;
        private System.Windows.Forms.TextBox txtFx0MinusH;
        private System.Windows.Forms.Label lblFx0;
        private System.Windows.Forms.Label lblFx0MinusH;
        private System.Windows.Forms.Label lblPasoRichardson;
        private System.Windows.Forms.TextBox txtX0PlusH2;
        private System.Windows.Forms.TextBox txtX0MinusH2;
        private System.Windows.Forms.Label lblX0PlusH2;
        private System.Windows.Forms.Label lblX0MinusH2;
        private System.Windows.Forms.TextBox txtFx0PlusH2;
        private System.Windows.Forms.TextBox txtFx0MinusH2;
        private System.Windows.Forms.Label lblFx0PlusH2;
        private System.Windows.Forms.Label lblFx0MinusH2;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label lblResultado;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form40));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblPasoCentrada = new System.Windows.Forms.Label();
            this.lblX0MinusH = new System.Windows.Forms.Label();
            this.txtX0MinusH = new System.Windows.Forms.TextBox();
            this.lblFx0 = new System.Windows.Forms.Label();
            this.txtFx0 = new System.Windows.Forms.TextBox();
            this.lblFx0MinusH = new System.Windows.Forms.Label();
            this.txtFx0MinusH = new System.Windows.Forms.TextBox();
            this.lblPasoRichardson = new System.Windows.Forms.Label();
            this.lblX0PlusH2 = new System.Windows.Forms.Label();
            this.txtX0PlusH2 = new System.Windows.Forms.TextBox();
            this.lblX0MinusH2 = new System.Windows.Forms.Label();
            this.txtX0MinusH2 = new System.Windows.Forms.TextBox();
            this.lblFx0PlusH2 = new System.Windows.Forms.Label();
            this.txtFx0PlusH2 = new System.Windows.Forms.TextBox();
            this.lblFx0MinusH2 = new System.Windows.Forms.Label();
            this.txtFx0MinusH2 = new System.Windows.Forms.TextBox();
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
            this.mainPanel.Size = new System.Drawing.Size(1080, 640);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Eras Medium ITC", 12F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSubtitle.Location = new System.Drawing.Point(382, 64);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(449, 19);
            this.lblSubtitle.TabIndex = 0;
            this.lblSubtitle.Text = "Primero centrada, luego Richardson: f\'(x0) ≈ (4f\'(h/2) - f\'(h))/3";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Eras Bold ITC", 22F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(380, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(427, 35);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Richardson | Extrapolación";
            // 
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.BackColor = System.Drawing.Color.Transparent;
            this.panelRight.Controls.Add(this.lblPasoCentrada);
            this.panelRight.Controls.Add(this.lblX0MinusH);
            this.panelRight.Controls.Add(this.txtX0MinusH);
            this.panelRight.Controls.Add(this.lblFx0);
            this.panelRight.Controls.Add(this.txtFx0);
            this.panelRight.Controls.Add(this.lblFx0MinusH);
            this.panelRight.Controls.Add(this.txtFx0MinusH);
            this.panelRight.Controls.Add(this.lblPasoRichardson);
            this.panelRight.Controls.Add(this.lblX0PlusH2);
            this.panelRight.Controls.Add(this.txtX0PlusH2);
            this.panelRight.Controls.Add(this.lblX0MinusH2);
            this.panelRight.Controls.Add(this.txtX0MinusH2);
            this.panelRight.Controls.Add(this.lblFx0PlusH2);
            this.panelRight.Controls.Add(this.txtFx0PlusH2);
            this.panelRight.Controls.Add(this.lblFx0MinusH2);
            this.panelRight.Controls.Add(this.txtFx0MinusH2);
            this.panelRight.Controls.Add(this.lblResultado);
            this.panelRight.Controls.Add(this.txtResultado);
            this.panelRight.Location = new System.Drawing.Point(360, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(720, 640);
            this.panelRight.TabIndex = 2;
            this.panelRight.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRight_Paint);
            // 
            // lblPasoCentrada
            // 
            this.lblPasoCentrada.AutoSize = true;
            this.lblPasoCentrada.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblPasoCentrada.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPasoCentrada.Location = new System.Drawing.Point(24, 90);
            this.lblPasoCentrada.Name = "lblPasoCentrada";
            this.lblPasoCentrada.Size = new System.Drawing.Size(230, 19);
            this.lblPasoCentrada.TabIndex = 0;
            this.lblPasoCentrada.Text = "Centrada: calcular x0 - h y x0 + h";
            // 
            // lblX0MinusH
            // 
            this.lblX0MinusH.AutoSize = true;
            this.lblX0MinusH.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblX0MinusH.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblX0MinusH.Location = new System.Drawing.Point(24, 130);
            this.lblX0MinusH.Name = "lblX0MinusH";
            this.lblX0MinusH.Size = new System.Drawing.Size(48, 19);
            this.lblX0MinusH.TabIndex = 1;
            this.lblX0MinusH.Text = "x0 - h:";
            // 
            // txtX0MinusH
            // 
            this.txtX0MinusH.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtX0MinusH.Location = new System.Drawing.Point(90, 128);
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
            this.lblFx0.Location = new System.Drawing.Point(250, 130);
            this.lblFx0.Name = "lblFx0";
            this.lblFx0.Size = new System.Drawing.Size(38, 19);
            this.lblFx0.TabIndex = 3;
            this.lblFx0.Text = "f(x0):";
            // 
            // txtFx0
            // 
            this.txtFx0.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtFx0.Location = new System.Drawing.Point(300, 128);
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
            this.lblFx0MinusH.Location = new System.Drawing.Point(24, 160);
            this.lblFx0MinusH.Name = "lblFx0MinusH";
            this.lblFx0MinusH.Size = new System.Drawing.Size(60, 19);
            this.lblFx0MinusH.TabIndex = 5;
            this.lblFx0MinusH.Text = "f(x0 - h):";
            // 
            // txtFx0MinusH
            // 
            this.txtFx0MinusH.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtFx0MinusH.Location = new System.Drawing.Point(100, 158);
            this.txtFx0MinusH.Name = "txtFx0MinusH";
            this.txtFx0MinusH.ReadOnly = true;
            this.txtFx0MinusH.Size = new System.Drawing.Size(160, 26);
            this.txtFx0MinusH.TabIndex = 6;
            // 
            // lblPasoRichardson
            // 
            this.lblPasoRichardson.AutoSize = true;
            this.lblPasoRichardson.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblPasoRichardson.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPasoRichardson.Location = new System.Drawing.Point(24, 210);
            this.lblPasoRichardson.Name = "lblPasoRichardson";
            this.lblPasoRichardson.Size = new System.Drawing.Size(145, 19);
            this.lblPasoRichardson.TabIndex = 7;
            this.lblPasoRichardson.Text = "Richardson: usar h/2";
            // 
            // lblX0PlusH2
            // 
            this.lblX0PlusH2.AutoSize = true;
            this.lblX0PlusH2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblX0PlusH2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblX0PlusH2.Location = new System.Drawing.Point(24, 240);
            this.lblX0PlusH2.Name = "lblX0PlusH2";
            this.lblX0PlusH2.Size = new System.Drawing.Size(65, 19);
            this.lblX0PlusH2.TabIndex = 8;
            this.lblX0PlusH2.Text = "x0 + h/2:";
            // 
            // txtX0PlusH2
            // 
            this.txtX0PlusH2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtX0PlusH2.Location = new System.Drawing.Point(100, 238);
            this.txtX0PlusH2.Name = "txtX0PlusH2";
            this.txtX0PlusH2.ReadOnly = true;
            this.txtX0PlusH2.Size = new System.Drawing.Size(140, 26);
            this.txtX0PlusH2.TabIndex = 9;
            // 
            // lblX0MinusH2
            // 
            this.lblX0MinusH2.AutoSize = true;
            this.lblX0MinusH2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblX0MinusH2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblX0MinusH2.Location = new System.Drawing.Point(260, 240);
            this.lblX0MinusH2.Name = "lblX0MinusH2";
            this.lblX0MinusH2.Size = new System.Drawing.Size(61, 19);
            this.lblX0MinusH2.TabIndex = 10;
            this.lblX0MinusH2.Text = "x0 - h/2:";
            // 
            // txtX0MinusH2
            // 
            this.txtX0MinusH2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtX0MinusH2.Location = new System.Drawing.Point(335, 238);
            this.txtX0MinusH2.Name = "txtX0MinusH2";
            this.txtX0MinusH2.ReadOnly = true;
            this.txtX0MinusH2.Size = new System.Drawing.Size(140, 26);
            this.txtX0MinusH2.TabIndex = 11;
            // 
            // lblFx0PlusH2
            // 
            this.lblFx0PlusH2.AutoSize = true;
            this.lblFx0PlusH2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblFx0PlusH2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblFx0PlusH2.Location = new System.Drawing.Point(24, 270);
            this.lblFx0PlusH2.Name = "lblFx0PlusH2";
            this.lblFx0PlusH2.Size = new System.Drawing.Size(77, 19);
            this.lblFx0PlusH2.TabIndex = 12;
            this.lblFx0PlusH2.Text = "f(x0 + h/2):";
            // 
            // txtFx0PlusH2
            // 
            this.txtFx0PlusH2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtFx0PlusH2.Location = new System.Drawing.Point(110, 268);
            this.txtFx0PlusH2.Name = "txtFx0PlusH2";
            this.txtFx0PlusH2.ReadOnly = true;
            this.txtFx0PlusH2.Size = new System.Drawing.Size(160, 26);
            this.txtFx0PlusH2.TabIndex = 13;
            // 
            // lblFx0MinusH2
            // 
            this.lblFx0MinusH2.AutoSize = true;
            this.lblFx0MinusH2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblFx0MinusH2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblFx0MinusH2.Location = new System.Drawing.Point(290, 270);
            this.lblFx0MinusH2.Name = "lblFx0MinusH2";
            this.lblFx0MinusH2.Size = new System.Drawing.Size(73, 19);
            this.lblFx0MinusH2.TabIndex = 14;
            this.lblFx0MinusH2.Text = "f(x0 - h/2):";
            // 
            // txtFx0MinusH2
            // 
            this.txtFx0MinusH2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtFx0MinusH2.Location = new System.Drawing.Point(370, 268);
            this.txtFx0MinusH2.Name = "txtFx0MinusH2";
            this.txtFx0MinusH2.ReadOnly = true;
            this.txtFx0MinusH2.Size = new System.Drawing.Size(160, 26);
            this.txtFx0MinusH2.TabIndex = 15;
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblResultado.ForeColor = System.Drawing.Color.White;
            this.lblResultado.Location = new System.Drawing.Point(24, 318);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(126, 20);
            this.lblResultado.TabIndex = 16;
            this.lblResultado.Text = "Resultado f\'(x0):";
            // 
            // txtResultado
            // 
            this.txtResultado.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtResultado.Location = new System.Drawing.Point(170, 316);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.Size = new System.Drawing.Size(240, 26);
            this.txtResultado.TabIndex = 17;
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
            this.panelLeft.Size = new System.Drawing.Size(360, 640);
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
            this.txtFuncion.Size = new System.Drawing.Size(310, 27);
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
            this.txtH.Size = new System.Drawing.Size(139, 27);
            this.txtH.TabIndex = 7;
            // 
            // btnCalcular
            // 
            this.btnCalcular.BackColor = System.Drawing.Color.Cyan;
            this.btnCalcular.Font = new System.Drawing.Font("Eras Demi ITC", 16F);
            this.btnCalcular.Location = new System.Drawing.Point(24, 248);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(310, 46);
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
            this.btnRegresar.Size = new System.Drawing.Size(310, 40);
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
            this.btnLimpiar.Size = new System.Drawing.Size(310, 40);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // Form40
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 640);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form40";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Richardson | Cálculo";
            this.Load += new System.EventHandler(this.Form40_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}