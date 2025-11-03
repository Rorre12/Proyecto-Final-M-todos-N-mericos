using System.ComponentModel;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    partial class LoadingForm
    {
        private IContainer components = null;
        private ProgressBar progressBar;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            this.components = new Container();
            this.progressBar = new ProgressBar();
            this.lblStatus = new Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(18, 44);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(324, 18);
            this.progressBar.Style = ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.Size = new System.Drawing.Size(324, 24);
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Location = new System.Drawing.Point(18, 12);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Cargando menú...";
            // 
            // LoadingForm
            // 
            this.ClientSize = new System.Drawing.Size(360, 80);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.Name = "LoadingForm";
            this.TopMost = true;
            this.ResumeLayout(false);
        }

        #endregion
    }
}   