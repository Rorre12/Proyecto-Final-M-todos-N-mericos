using System;
using System.Collections.Generic;
using System.Globalization;

namespace Proyecto_Final_Métodos_Númericos.Expressions
{
    // Evaluador simple de expresiones: soporta +, -, *, /, ^, paréntesis, x y funciones comunes:
    // sin, cos, tan, exp, log (base e), ln, sqrt, abs.
    internal class ExpressionEvaluator
    {
        private readonly string _expr;
        private readonly List<Token> _rpn;

        public ExpressionEvaluator(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                throw new ArgumentException("La expresión no puede estar vacía.");

            _expr = expression.Replace(" ", "");
            var tokens = Tokenize(_expr);
            _rpn = ToRpn(tokens);
        }

        public double Evaluate(double x)
        {
            var stack = new Stack<double>();
            foreach (var t in _rpn)
            {
                switch (t.Kind)
                {
                    case TokenKind.Number:
                        stack.Push(t.Value);
                        break;
                    case TokenKind.Variable:
                        stack.Push(x);
                        break;
                    case TokenKind.Function:
                        if (stack.Count < 1) throw new InvalidOperationException("Argumento insuficiente.");
                        var a = stack.Pop();
                        stack.Push(ApplyFunc(t.Text, a));
                        break;
                    case TokenKind.Operator:
                        if (t.Text == "u-") // unario menos
                        {
                            if (stack.Count < 1) throw new InvalidOperationException("Argumento insuficiente.");
                            stack.Push(-stack.Pop());
                            break;
                        }
                        if (stack.Count < 2) throw new InvalidOperationException("Argumentos insuficientes.");
                        var b = stack.Pop();
                        var c = stack.Pop();
                        stack.Push(ApplyOp(t.Text, c, b));
                        break;
                    default:
                        throw new InvalidOperationException("Token desconocido.");
                }
            }
            if (stack.Count != 1) throw new InvalidOperationException("Expresión inválida.");
            return stack.Pop();
        }

        private static double ApplyOp(string op, double a, double b)
        {
            switch (op)
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/": return a / b;
                case "^": return System.Math.Pow(a, b);
                default: throw new InvalidOperationException("Operador no soportado: " + op);
            }
        }

        private static double ApplyFunc(string f, double a)
        {
            switch (f)
            {
                case "sin": return System.Math.Sin(a);
                case "cos": return System.Math.Cos(a);
                case "tan": return System.Math.Tan(a);
                case "exp": return System.Math.Exp(a);
                case "log": return System.Math.Log(a);
                case "ln": return System.Math.Log(a);
                case "sqrt": return System.Math.Sqrt(a);
                case "abs": return System.Math.Abs(a);
                default: throw new InvalidOperationException("Función no soportada: " + f);
            }
        }

        private static List<Token> Tokenize(string s)
        {
            var tokens = new List<Token>();
            int i = 0;
            while (i < s.Length)
            {
                char c = s[i];

                if (char.IsDigit(c) || (c == '.' && i + 1 < s.Length && char.IsDigit(s[i + 1])))
                {
                    int start = i;
                    i++;
                    while (i < s.Length && (char.IsDigit(s[i]) || s[i] == '.')) i++;
                    var num = double.Parse(s.Substring(start, i - start), CultureInfo.InvariantCulture);
                    tokens.Add(new Token(TokenKind.Number, s.Substring(start, i - start), num));
                    continue;
                }

                if (char.IsLetter(c))
                {
                    int start = i;
                    i++;
                    while (i < s.Length && char.IsLetter(s[i])) i++;
                    var name = s.Substring(start, i - start).ToLowerInvariant();
                    if (name == "x")
                        tokens.Add(new Token(TokenKind.Variable, "x"));
                    else
                        tokens.Add(new Token(TokenKind.Function, name));
                    continue;
                }

                if ("+-*/^()".IndexOf(c) >= 0)
                {
                    tokens.Add(new Token(TokenKind.Symbol, c.ToString()));
                    i++;
                    continue;
                }

                throw new InvalidOperationException("Carácter no reconocido: " + c);
            }

            // Resolver unarios
            var outTokens = new List<Token>();
            for (int k = 0; k < tokens.Count; k++)
            {
                var t = tokens[k];
                if (t.Kind == TokenKind.Symbol && t.Text == "-" &&
                    (k == 0 || (outTokens.Count > 0 && (IsOperatorOrLeftParen(outTokens[outTokens.Count - 1])))))
                {
                    outTokens.Add(new Token(TokenKind.Operator, "u-"));
                }
                else if (t.Kind == TokenKind.Symbol && "+-*/^".IndexOf(t.Text) >= 0)
                {
                    outTokens.Add(new Token(TokenKind.Operator, t.Text));
                }
                else if (t.Kind == TokenKind.Symbol && (t.Text == "(" || t.Text == ")"))
                {
                    outTokens.Add(new Token(TokenKind.Symbol, t.Text));
                }
                else
                {
                    outTokens.Add(t);
                }
            }

            return outTokens;
        }

        private static bool IsOperatorOrLeftParen(Token t)
        {
            return t.Kind == TokenKind.Operator || (t.Kind == TokenKind.Symbol && t.Text == "(");
        }

        private static int Precedence(string op)
        {
            switch (op)
            {
                case "u-": return 4;
                case "^": return 3;
                case "*":
                case "/": return 2;
                case "+":
                case "-": return 1;
                default: return 0;
            }
        }

        private static bool IsRightAssociative(string op)
        {
            return op == "^" || op == "u-";
        }

        private static List<Token> ToRpn(List<Token> tokens)
        {
            var output = new List<Token>();
            var ops = new Stack<Token>();

            foreach (var t in tokens)
            {
                switch (t.Kind)
                {
                    case TokenKind.Number:
                    case TokenKind.Variable:
                        output.Add(t);
                        break;
                    case TokenKind.Function:
                        ops.Push(t);
                        break;
                    case TokenKind.Operator:
                        while (ops.Count > 0 && (
                               (ops.Peek().Kind == TokenKind.Function) ||
                               (ops.Peek().Kind == TokenKind.Operator &&
                                 (Precedence(ops.Peek().Text) > Precedence(t.Text) ||
                                  (Precedence(ops.Peek().Text) == Precedence(t.Text) && !IsRightAssociative(t.Text))))))
                        {
                            output.Add(ops.Pop());
                        }
                        ops.Push(t);
                        break;
                    case TokenKind.Symbol:
                        if (t.Text == "(")
                        {
                            ops.Push(t);
                        }
                        else if (t.Text == ")")
                        {
                            while (ops.Count > 0 && !(ops.Peek().Kind == TokenKind.Symbol && ops.Peek().Text == "("))
                                output.Add(ops.Pop());
                            if (ops.Count == 0) throw new InvalidOperationException("Paréntesis desequilibrados.");
                            ops.Pop();
                            if (ops.Count > 0 && ops.Peek().Kind == TokenKind.Function)
                                output.Add(ops.Pop());
                        }
                        break;
                }
            }

            while (ops.Count > 0)
            {
                var op = ops.Pop();
                if (op.Kind == TokenKind.Symbol) throw new InvalidOperationException("Paréntesis desequilibrados.");
                output.Add(op);
            }

            return output;
        }

        private enum TokenKind { Number, Variable, Operator, Function, Symbol }

        private struct Token
        {
            public TokenKind Kind;
            public string Text;
            public double Value;

            public Token(TokenKind kind, string text, double value = 0)
            {
                Kind = kind;
                Text = text;
                Value = value;
            }
        }
    }
}