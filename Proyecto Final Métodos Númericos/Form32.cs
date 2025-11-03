using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Proyecto_Final_Métodos_Númericos.Expressions;

namespace Proyecto_Final_Métodos_Númericos
{
    public partial class Form32 : Form
    {
        private readonly string _fx;
        private readonly string _dfx;
        private readonly double _x0;
        private readonly double _tol;
        private readonly int _maxIt;

        public bool GoToMenu { get; private set; }

        public Form32(string fx, string dfx, double x0, double tol, int maxIt)
        {
            _fx = fx;
            _dfx = dfx ?? string.Empty;
            _x0 = x0;
            _tol = tol;
            _maxIt = maxIt > 1000 ? 1000 : (maxIt <= 0 ? 1000 : maxIt);
            InitializeComponent();
        }

        private void Form32_Load(object sender, EventArgs e)
        {
            // Configurar columnas
            dgvNewton.Columns.Clear();
            dgvNewton.Columns.Add("Iter", "Iter");
            dgvNewton.Columns.Add("X", "x");
            dgvNewton.Columns.Add("FX", "f(x)");
            dgvNewton.Columns.Add("DFX", "f'(x)");
            dgvNewton.Columns.Add("Err", "Error");

            try
            {
                var f = new ExpressionEvaluator(_fx);
                ExpressionEvaluator df = null;
                if (!string.IsNullOrWhiteSpace(_dfx))
                    df = new ExpressionEvaluator(_dfx);

                int n = 0;
                double x = _x0;
                double error = double.NaN;
                string estado = "En ejecución";

                while (n < _maxIt)
                {
                    double fx = f.Evaluate(x);
                    double dfx = df != null ? df.Evaluate(x) : DerivadaNumerica(f, x);
                    if (System.Math.Abs(dfx) < 1e-14)
                    {
                        estado = "Derivada ~ 0. No se puede continuar.";
                        break;
                    }

                    double x1 = x - fx / dfx;
                    error = System.Math.Abs(x1 - x);

                    dgvNewton.Rows.Add(
                        n.ToString(),
                        x.ToString("G17", CultureInfo.InvariantCulture),
                        fx.ToString("G17", CultureInfo.InvariantCulture),
                        dfx.ToString("G17", CultureInfo.InvariantCulture),
                        (double.IsNaN(error) ? "-" : error.ToString("G17", CultureInfo.InvariantCulture))
                    );

                    x = x1;
                    n++;

                    if (System.Math.Abs(fx) < _tol || error < _tol)
                    {
                        estado = "Convergió.";
                        break;
                    }
                }

                lblRaiz.Text = "Raíz: " + x.ToString("G17", CultureInfo.InvariantCulture);
                lblEstado.Text = $"Estado: {(n >= _maxIt ? "Máximo alcanzado" : "Listo")} · Iteraciones: {n} (límite " + _maxIt + ")";
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error: " + ex.Message;
            }
        }

        private static double DerivadaNumerica(ExpressionEvaluator f, double x)
        {
            const double h = 1e-6;
            return (f.Evaluate(x + h) - f.Evaluate(x - h)) / (2.0 * h);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            GoToMenu = true; // señalamos a Form31 que cierre y vuelva al menú (Form30)
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
