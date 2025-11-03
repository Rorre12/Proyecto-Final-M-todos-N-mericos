using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class LoadingForm : Form
    {
        private Timer timer;
        private int durationMs;
        private int elapsed;

        public LoadingForm(int durationMilliseconds = 3000)
        {
            InitializeComponent();
            this.durationMs = Math.Max(200, durationMilliseconds);
            this.Opacity = 0.98;
            this.BackColor = Color.FromArgb(30, 30, 35);
            this.lblStatus.ForeColor = Color.White;
            this.lblStatus.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            this.progressBar.Value = 0;

            timer = new Timer();
            timer.Interval = 30;
            timer.Tick += Timer_Tick;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            elapsed = 0;
            progressBar.Value = 0;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsed += timer.Interval;
            double p = (double)elapsed / durationMs;
            int value = Math.Min(100, (int)(p * 100));
            progressBar.Value = value;
            lblStatus.Text = $"Cargando menú... {value}%";

            if (elapsed >= durationMs)
            {
                timer.Stop();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        // Liberar timer en OnFormClosed (evita duplicar Dispose generado por el diseñador)
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try
            {
                timer?.Stop();
                timer?.Dispose();
            }
            catch
            {
                // no hacer nada en caso de fallo de liberación
            }
            finally
            {
                base.OnFormClosed(e);
            }
        }
    }
}