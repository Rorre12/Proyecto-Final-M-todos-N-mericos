using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Proyecto_Final_Métodos_Númericos.Expressions;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form36 : Form
    {
        private Timer bgTimer;
        private float hue =210f;

        public Form36()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            try { typeof(Panel).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)?.SetValue(mainPanel, true, null); } catch { }
            try { typeof(Panel).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)?.SetValue(panelLeft, true, null); } catch { }
            try { typeof(Panel).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)?.SetValue(panelRight, true, null); } catch { }
        }

        private void Form36_Load(object sender, EventArgs e)
        {
            try
            {
                VisualHelpers.ConfigureButtonVisual(btnCalcular, Color.FromArgb(0,170,200), Color.FromArgb(0,195,230));
                VisualHelpers.ConfigureButtonVisualSimple(btnRegresar, Color.FromArgb(200,60,80), Color.FromArgb(170,40,60));

                // Título/subtítulo sobre el fondo general
                lblTitle.BackColor = Color.Transparent; lblTitle.ForeColor = Color.White; lblTitle.Parent = mainPanel;
                lblSubtitle.BackColor = Color.Transparent; lblSubtitle.ForeColor = Color.WhiteSmoke; lblSubtitle.Parent = mainPanel;

                // Labels del panel izquierdo (entradas)
                foreach (var lbl in new[] { lblFuncion, lblXTarget, lblX0, lblH })
                { lbl.BackColor = Color.Transparent; lbl.ForeColor = Color.WhiteSmoke; lbl.Parent = panelLeft; }

                // Labels del panel derecho (salidas)
                foreach (var lbl in new[] { lblPaso, lblX0PlusH, lblFx0, lblFx0PlusH, lblResultado })
                { lbl.BackColor = Color.Transparent; lbl.ForeColor = Color.WhiteSmoke; lbl.Parent = panelRight; }
            }
            catch { }

            bgTimer = new Timer { Interval =60 };
            bgTimer.Tick += (s, a) => { hue +=0.5f; if (hue >360) hue -=360; mainPanel.Invalidate(); panelLeft.Invalidate(); panelRight.Invalidate(); };
            try { bgTimer.Start(); } catch { }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = mainPanel.ClientRectangle;
            var c1 = VisualHelpers.ColorFromHSL(hue,0.50f,0.10f);
            var c2 = VisualHelpers.ColorFromHSL((hue +88f) %360f,0.58f,0.06f);
            using (var lg = new LinearGradientBrush(rect, c1, c2,30f)) g.FillRectangle(lg, rect);
        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = panelLeft.ClientRectangle;
            using (var lg = new LinearGradientBrush(rect, Color.FromArgb(40,70,120), Color.FromArgb(25,40,85), LinearGradientMode.Vertical)) g.FillRectangle(lg, rect);
            using (var p = new Pen(Color.FromArgb(0,170,200),2)) g.DrawLine(p, rect.Right-1,0, rect.Right-1, rect.Bottom);
        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = panelRight.ClientRectangle;
            using (var lg = new LinearGradientBrush(rect, Color.FromArgb(16,28,38), Color.FromArgb(10,14,28),25f)) g.FillRectangle(lg, rect);
        }

        // Inserta multiplicación implícita y normaliza la expresión del usuario (3x ->3*x, x(x+1)-> x*(x+1))
        private string NormalizeExpression(string expr)
        {
            if (string.IsNullOrWhiteSpace(expr)) return expr;
            string s = expr.Replace(",", ".");
            // quitar espacios
            s = Regex.Replace(s, @"\s+", "");
            //3x ->3*x,2(x+1) ->2*(x+1)
            s = Regex.Replace(s, @"(?<num>\d)(?=[A-Za-z\(])", "${num}*");
            // x2 -> x*2 (raro pero por consistencia si alguien escribe x2)
            s = Regex.Replace(s, @"(?<var>[A-Za-z\)])(?=\d)", "${var}*");
            // x( -> x*( (pero no romper sin/cos/etc.)
            s = Regex.Replace(s, @"x(?=\()", "x*");
            // )x o )3 o )( -> )*x | )*3 | )*(
            s = Regex.Replace(s, @"\)(?=[A-Za-z0-9\(])", ")*");
            return s;
        }

        private bool TryParseDouble(TextBox tb, out double value, string fieldName)
        {
            if (!double.TryParse(tb.Text, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out value))
            {
                MessageBox.Show($"El campo '{fieldName}' debe ser numérico (usa punto decimal).", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb.Focus(); tb.SelectAll(); return false;
            }
            return true;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            var funcionRaw = (txtFuncion.Text ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(funcionRaw))
            { MessageBox.Show("Proporcione la función f(x).", "Falta función", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtFuncion.Focus(); return; }
            var funcion = NormalizeExpression(funcionRaw);

            double xTarget, x0, h;
            if (!TryParseDouble(txtXTarget, out xTarget, "f'(?) en")) return;
            if (!TryParseDouble(txtX0, out x0, "x0")) return;
            if (!TryParseDouble(txtH, out h, "h")) return;
            if (Math.Abs(h) <1e-15)
            { MessageBox.Show("'h' no puede ser0.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtH.Focus(); return; }

            try
            {
                double x0PlusH = x0 + h;
                txtX0PlusH.Text = x0PlusH.ToString("G8", System.Globalization.CultureInfo.InvariantCulture);

                var evaluator = new ExpressionEvaluator(funcion);
                // Evaluaciones solicitadas
                double fx0 = evaluator.Evaluate(x0);
                double fx0h = evaluator.Evaluate(x0PlusH);
                txtFx0.Text = fx0.ToString("G10", System.Globalization.CultureInfo.InvariantCulture);
                txtFx0PlusH.Text = fx0h.ToString("G10", System.Globalization.CultureInfo.InvariantCulture);

                // Derivada progresiva: ( f(x0+h) - f(x0) ) / h
                double deriv = (fx0h - fx0) / h;
                txtResultado.Text = deriv.ToString("G12", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al evaluar la función. Revise la sintaxis y use x como variable. Detalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                txtFuncion.Clear();
                txtXTarget.Clear();
                txtX0.Clear();
                txtH.Clear();
                txtX0PlusH.Clear();
                txtFx0.Clear();
                txtFx0PlusH.Clear();
                txtResultado.Clear();
                txtFuncion.Focus();
            }
            catch { }
        }
    }
}
