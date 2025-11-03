using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Proyecto_Final_Métodos_Númericos.Expressions;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form31 : Form
    {
        public Form31()
        {
            InitializeComponent();
            this.AcceptButton = btnSiguiente;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            // Construir polinomio a4*x^4 + a3*x^3 + a2*x^2 + a1*x + a0
            double a4 = ParseOrZero(txtA4.Text);
            double a3 = ParseOrZero(txtA3.Text);
            double a2 = ParseOrZero(txtA2.Text);
            double a1 = ParseOrZero(txtA1.Text);
            double a0 = ParseOrZero(txtA0.Text);

            if (a4 == 0 && a3 == 0 && a2 == 0 && a1 == 0 && a0 == 0)
            {
                MessageBox.Show("Ingresa al menos un coeficiente distinto de 0.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fx = BuildPoly(a4, a3, a2, a1, a0);
            txtVista.Text = fx;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtA4.Text = txtA3.Text = txtA2.Text = txtA1.Text = txtA0.Text = string.Empty;
            txtVista.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            bool enable = !txtA4.Enabled;
            txtA4.Enabled = txtA3.Enabled = txtA2.Enabled = txtA1.Enabled = txtA0.Enabled = enable;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            double a4 = ParseOrZero(txtA4.Text);
            double a3 = ParseOrZero(txtA3.Text);
            double a2 = ParseOrZero(txtA2.Text);
            double a1 = ParseOrZero(txtA1.Text);
            double a0 = ParseOrZero(txtA0.Text);

            if (a4 == 0 && a3 == 0 && a2 == 0 && a1 == 0 && a0 == 0)
            {
                MessageBox.Show("Primero inserta la función (coeficientes).", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fx = BuildPoly(a4, a3, a2, a1, a0);
            string dfx = BuildPolyDerivative(a4, a3, a2, a1);

            // Pedir x0, tolerancia y máx. iteraciones
            if (!AskParams(out double x0, out double tol, out int maxIt)) return;

            // Validar que la expresión se evalúa
            try
            {
                var ev = new ExpressionEvaluator(fx);
                ev.Evaluate(x0);
                var evd = new ExpressionEvaluator(dfx);
                evd.Evaluate(x0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la función generada: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Hide();
            using (var f = new Form32(fx, dfx, x0, tol, maxIt))
            {
                f.ShowDialog(this);
            }
            this.Show();
        }

        // -------- Helpers --------
        private static double ParseOrZero(string s)
        {
            double v;
            if (double.TryParse((s ?? "").Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out v))
                return v;
            if (double.TryParse((s ?? "").Trim(), out v)) return v;
            return 0.0;
        }

        private static string BuildPoly(double a4, double a3, double a2, double a1, double a0)
        {
            var sb = new StringBuilder();
            AppendTerm(sb, a4, "x^4");
            AppendTerm(sb, a3, "x^3");
            AppendTerm(sb, a2, "x^2");
            AppendTerm(sb, a1, "x");
            AppendTerm(sb, a0, "");
            return sb.Length == 0 ? "0" : sb.ToString();
        }

        private static string BuildPolyDerivative(double a4, double a3, double a2, double a1)
        {
            var sb = new StringBuilder();
            AppendTerm(sb, 4 * a4, "x^3");
            AppendTerm(sb, 3 * a3, "x^2");
            AppendTerm(sb, 2 * a2, "x");
            AppendTerm(sb, a1, "");
            return sb.Length == 0 ? "0" : sb.ToString();
        }

        private static void AppendTerm(StringBuilder sb, double coef, string monomial)
        {
            if (System.Math.Abs(coef) < 1e-15) return;
            string sign = coef >= 0 ? "+" : "-";
            double abs = System.Math.Abs(coef);
            if (sb.Length == 0)
                sign = coef >= 0 ? "" : "-";

            if (monomial == "")
                sb.AppendFormat(CultureInfo.InvariantCulture, "{0}{1}", sign, abs);
            else if (System.Math.Abs(abs - 1.0) < 1e-15)
                sb.AppendFormat("{0}{1}", sign, monomial);
            else
                sb.AppendFormat(CultureInfo.InvariantCulture, "{0}{1}*{2}", sign, abs, monomial);
        }

        private bool AskParams(out double x0, out double tol, out int maxIt)
        {
            x0 = 0; tol = 1e-3; maxIt = 100;

            using (var dlg = new Form())
            {
                dlg.Text = "Parámetros de Newton–Raphson";
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.MinimizeBox = false; dlg.MaximizeBox = false;
                dlg.ClientSize = new System.Drawing.Size(360, 170);

                var lblX0 = new Label { Left = 20, Top = 20, Width = 100, Text = "x0:" };
                var txtX0 = new TextBox { Left = 130, Top = 18, Width = 200, Text = "1.0" };
                var lblTol = new Label { Left = 20, Top = 55, Width = 100, Text = "Tolerancia:" };
                var txtTol = new TextBox { Left = 130, Top = 53, Width = 200, Text = "0.001" };
                var lblMax = new Label { Left = 20, Top = 90, Width = 100, Text = "Máx. iteraciones:" };
                var txtMax = new TextBox { Left = 130, Top = 88, Width = 200, Text = "100" };

                var btnOk = new Button { Text = "Aceptar", Left = 170, Width = 80, Top = 125, DialogResult = DialogResult.OK, BackColor = System.Drawing.Color.MediumSeaGreen, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
                btnOk.FlatAppearance.BorderSize = 0;
                var btnCancel = new Button { Text = "Cancelar", Left = 260, Width = 80, Top = 125, DialogResult = DialogResult.Cancel };

                dlg.Controls.AddRange(new Control[] { lblX0, txtX0, lblTol, txtTol, lblMax, txtMax, btnOk, btnCancel });
                dlg.AcceptButton = btnOk;
                dlg.CancelButton = btnCancel;

                if (dlg.ShowDialog(this) != DialogResult.OK) return false;

                if (!double.TryParse(txtX0.Text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out x0) &&
                    !double.TryParse(txtX0.Text.Trim(), out x0))
                {
                    MessageBox.Show("x0 no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if ((!double.TryParse(txtTol.Text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out tol) &&
                    !double.TryParse(txtTol.Text.Trim(), out tol)) || tol <= 0)
                {
                    MessageBox.Show("Tolerancia debe ser > 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!int.TryParse(txtMax.Text.Trim(), out maxIt) || maxIt <= 0) maxIt = 100;
                if (maxIt > 1000) maxIt = 1000;
            }
            return true;
        }
    }
}
