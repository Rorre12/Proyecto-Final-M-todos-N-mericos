using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form39 : Form
    {
        private Timer bgTimer;
        private float hue =210f;

        public Form39()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            try { typeof(Panel).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)?.SetValue(mainPanel, true, null); } catch { }
        }

        private void Form39_Load(object sender, EventArgs e)
        {
            try
            {
                VisualHelpers.ConfigureButtonVisual(btnIngresar, Color.FromArgb(0,170,200), Color.FromArgb(0,195,230));
                VisualHelpers.ConfigureButtonVisualSimple(btnRegresar, Color.FromArgb(200,60,80), Color.FromArgb(170,40,60));
                lblTitle.BackColor = Color.Transparent; lblTitle.ForeColor = Color.White; lblTitle.Parent = mainPanel;
                lblSubtitle.BackColor = Color.Transparent; lblSubtitle.ForeColor = Color.WhiteSmoke; lblSubtitle.Parent = mainPanel;
            }
            catch { }

            bgTimer = new Timer { Interval =60 };
            bgTimer.Tick += (s, a) => { hue +=0.5f; if (hue >360) hue -=360; mainPanel.Invalidate(); };
            try { bgTimer.Start(); } catch { }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias; var rect = mainPanel.ClientRectangle;
            var c1 = VisualHelpers.ColorFromHSL(hue,0.55f,0.12f); var c2 = VisualHelpers.ColorFromHSL((hue +90f) %360f,0.60f,0.06f);
            using (var lg = new LinearGradientBrush(rect, c1, c2,30f)) g.FillRectangle(lg, rect);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            try
            {
                using (var f = new Form40())
                { f.StartPosition = FormStartPosition.CenterParent; f.ShowDialog(this); }
            }
            finally
            { try { this.Show(); } catch { } }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        { this.Close(); }
    }
}
