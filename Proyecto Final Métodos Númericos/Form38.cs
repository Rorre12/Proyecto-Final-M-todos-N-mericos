using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Proyecto_Final_Métodos_Númericos.Expressions;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form38 : Form
    {
        private Timer bgTimer; private float hue =210f;
        public Form38()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            try { typeof(Panel).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)?.SetValue(mainPanel, true, null); } catch { }
            try { typeof(Panel).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)?.SetValue(panelLeft, true, null); } catch { }
            try { typeof(Panel).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)?.SetValue(panelRight, true, null); } catch { }
        }
        private void Form38_Load(object sender, EventArgs e)
        {
            try
            {
                VisualHelpers.ConfigureButtonVisual(btnCalcular, Color.FromArgb(0,170,200), Color.FromArgb(0,195,230));
                VisualHelpers.ConfigureButtonVisualSimple(btnRegresar, Color.FromArgb(200,60,80), Color.FromArgb(170,40,60));
                foreach (var lbl in new[] { lblTitle, lblSubtitle, lblFuncion, lblXTarget, lblX0, lblH, lblPaso, lblX0MinusH, lblFx0, lblFx0MinusH, lblResultado })
                { lbl.BackColor = Color.Transparent; lbl.ForeColor = Color.WhiteSmoke; }
            }
            catch { }
            bgTimer = new Timer { Interval =60 };
            bgTimer.Tick += (s, a) => { hue +=0.5f; if (hue >360) hue -=360; mainPanel.Invalidate(); panelLeft.Invalidate(); panelRight.Invalidate(); };
            try { bgTimer.Start(); } catch { }
        }
        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias; var rect = mainPanel.ClientRectangle;
            var c1 = VisualHelpers.ColorFromHSL(hue,0.50f,0.10f); var c2 = VisualHelpers.ColorFromHSL((hue +88f) %360f,0.58f,0.06f);
            using (var lg = new LinearGradientBrush(rect, c1, c2,30f)) g.FillRectangle(lg, rect);
        }
        private void panelLeft_Paint(object s, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias; var rect = panelLeft.ClientRectangle;
            using (var lg = new LinearGradientBrush(rect, Color.FromArgb(40,70,120), Color.FromArgb(25,40,85), LinearGradientMode.Vertical)) g.FillRectangle(lg, rect);
            using (var p = new Pen(Color.FromArgb(0,170,200),2)) g.DrawLine(p, rect.Right-1,0, rect.Right-1, rect.Bottom);
        }
        private void panelRight_Paint(object s, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias; var rect = panelRight.ClientRectangle;
            using (var lg = new LinearGradientBrush(rect, Color.FromArgb(16,28,38), Color.FromArgb(10,14,28),25f)) g.FillRectangle(lg, rect);
        }
        private string NormalizeExpression(string expr)
        {
            if (string.IsNullOrWhiteSpace(expr)) return expr; string s = expr.Replace(",", "."); s = Regex.Replace(s, @"\s+", "");
            s = Regex.Replace(s, @"(?<num>\d)(?=[A-Za-z\(])", "${num}*"); s = Regex.Replace(s, @"(?<var>[A-Za-z\)])(?=\d)", "${var}*");
            s = Regex.Replace(s, @"x(?=\()", "x*"); s = Regex.Replace(s, @"\)(?=[A-Za-z0-9\(])", ")*"); return s;
        }
        private bool TryParseDouble(TextBox tb, out double v, string name)
        {
            if (!double.TryParse(tb.Text, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out v))
            { MessageBox.Show($"El campo '{name}' debe ser numérico (usa punto decimal).", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning); tb.Focus(); tb.SelectAll(); return false; }
            return true;
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            var funcion = NormalizeExpression((txtFuncion.Text ?? string.Empty).Trim()); if (string.IsNullOrWhiteSpace(funcion)) { MessageBox.Show("Proporcione la función f(x).", "Falta función", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtFuncion.Focus(); return; }
            double xTarget, x0, h; if (!TryParseDouble(txtXTarget, out xTarget, "f'(?) en")) return; if (!TryParseDouble(txtX0, out x0, "x0")) return; if (!TryParseDouble(txtH, out h, "h")) return; if (Math.Abs(h) <1e-15) { MessageBox.Show("'h' no puede ser0.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtH.Focus(); return; }
            try
            {
                double x0MinusH = x0 - h; txtX0MinusH.Text = x0MinusH.ToString("G8", System.Globalization.CultureInfo.InvariantCulture);
                var evaluator = new ExpressionEvaluator(funcion); double fx0 = evaluator.Evaluate(x0); double fx0m = evaluator.Evaluate(x0MinusH);
                txtFx0.Text = fx0.ToString("G10", System.Globalization.CultureInfo.InvariantCulture); txtFx0MinusH.Text = fx0m.ToString("G10", System.Globalization.CultureInfo.InvariantCulture);
                double deriv = (evaluator.Evaluate(x0 + h) - fx0m) /(2*h); txtResultado.Text = deriv.ToString("G12", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            { MessageBox.Show("Error al evaluar la función. Revise la sintaxis y use x como variable. Detalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnRegresar_Click(object sender, EventArgs e) { this.Close(); }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFuncion.Clear(); txtXTarget.Clear(); txtX0.Clear(); txtH.Clear(); txtX0MinusH.Clear(); txtFx0.Clear(); txtFx0MinusH.Clear(); txtResultado.Clear(); txtFuncion.Focus();
        }
    }
}
