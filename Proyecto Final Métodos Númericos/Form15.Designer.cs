namespace Proyecto_Final_Métodos_Númericos
{
    partial class Form15
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(28, 28, 34);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(0);
            this.panelMain.Size = new System.Drawing.Size(920, 560);
            this.panelMain.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.UseVisualStyleBackColor = false; // importante para que se respete el BackColor
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(200, 60, 80); // rojo
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 34);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Regresar";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Form15
            // 
            this.ClientSize = new System.Drawing.Size(920, 560);
            this.Controls.Add(this.panelMain);
            this.Name = "Form15";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Solución — Inversa por Cofactores";
            this.Load += new System.EventHandler(this.Form15_Load);
            this.Resize += new System.EventHandler(this.Form15_Resize);
            this.ResumeLayout(false);
        }
    }
}
