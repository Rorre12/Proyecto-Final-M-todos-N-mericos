using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Final_Métodos_Númericos
{
    internal static class VisualHelpers
    {
        // Conversión HSL -> Color (misma implementación coherente)
        public static Color ColorFromHSL(float h, float s, float l)
        {
            h = (h % 360 + 360) % 360;
            s = Math.Max(0f, Math.Min(1f, s));
            l = Math.Max(0f, Math.Min(1f, l));
            double c = (1 - Math.Abs(2 * l - 1)) * s;
            double x = c * (1 - Math.Abs((h / 60.0) % 2 - 1));
            double m = l - c / 2;
            double r1 = 0, g1 = 0, b1 = 0;
            if (h < 60) { r1 = c; g1 = x; b1 = 0; }
            else if (h < 120) { r1 = x; g1 = c; b1 = 0; }
            else if (h < 180) { r1 = 0; g1 = c; b1 = x; }
            else if (h < 240) { r1 = 0; g1 = x; b1 = c; }
            else if (h < 300) { r1 = x; g1 = 0; b1 = c; }
            else { r1 = c; g1 = 0; b1 = x; }
            int r = (int)((r1 + m) * 255);
            int g = (int)((g1 + m) * 255);
            int b = (int)((b1 + m) * 255);
            return Color.FromArgb(r, g, b);
        }

        // Estiliza un botón con color normal y hover
        public static void ConfigureButtonVisual(Button b, Color normal, Color hover)
        {
            if (b == null) return;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = normal;
            b.ForeColor = Color.White;
            b.Font = new Font(b.Font.FontFamily, b.Font.Size, FontStyle.Bold);
            b.Tag = hover;
            b.MouseEnter += (s, e) => { b.BackColor = (Color)b.Tag; b.Cursor = Cursors.Hand; };
            b.MouseLeave += (s, e) => { b.BackColor = normal; b.Cursor = Cursors.Default; };
        }

        // Versión simple (cerrar, etc.)
        public static void ConfigureButtonVisualSimple(Button b, Color normal, Color hover)
        {
            if (b == null) return;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = normal;
            b.ForeColor = Color.White;
            b.Tag = hover;
            b.MouseEnter += (s, e) => { b.BackColor = (Color)b.Tag; b.Cursor = Cursors.Hand; };
            b.MouseLeave += (s, e) => { b.BackColor = normal; b.Cursor = Cursors.Default; };
        }
    }
}