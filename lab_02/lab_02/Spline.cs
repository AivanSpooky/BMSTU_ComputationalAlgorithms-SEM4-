using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static lab_02.Spline;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace lab_02
{
    internal class Spline
    {
        // РАЗНЫЕ ТЕСТЫ!!
        /*public static uint N = 11;
        public static double[] x = { 0, 0.5, 0.75, 1.25, 1.5, 2, 3, 4, 5, 6, 7 };
        public static double[] y = { 0.250, 0.571, 0.842, 0.842, 0.571, 0.250, 0.077, 0.036, 0.020, 0.013, 0.009 };*/

        public static uint N = 5;
        public static double[] x = { -2, -1, 0, 1, 2 
        
        };
        public static double[] y = { 4, 1, 0, 1, 4 };

        /*public static uint N = 7;
        public static double[] x = { -3, -2, -1, 0, 1, 2, 3 };
        public static double[] y = { 9, 4, 1, 0, 1, 4, 9 };*/


        /*public static uint N = 8;
        public static double[] x = { -3, -2, -1, 0, 0.5, 1, 2, 3 };
        public static double[] y = { -27, -8, -1, 0, 0.125, 1, 8, 27 };*/

        /*public static uint N = 3;
        public static double[] x = { 0, 1, 3 };
        public static double[] y = { 0, 1, 3 };*/

        /*public static uint N = 2;
        public static double[] x = { 2, 4 };
        public static double[] y = { 4, 2 };*/

        /*public static uint N = 3;
        public static double[] x = { 2, 4, 6 };
        public static double[] y = { 4, 2, 3.5 };*/

        /*public static uint N = 5;
        public static double[] x = { -2, -1, 0, 1, 2 };
        public static double[] y = { 4, 1, 0, 1, 4 };*/

        // Данные из первой лабы
        /*public static uint N = 22;
        public static double[] x = { 0, 0.2, 0.4, 0.6, 0.8, 1, 1.2, 1.4, 1.6, 1.8, 2, 2.2, 2.4, 2.6, 2.8, 3, 3.2, 3.4, 3.6, 3.8, 4, 4.2 };
        public static double[] y = { -1.000, -0.411, 0.117, 0.532, 0.800, 0.909, 0.875, 0.735, 0.542, 0.357, 0.243, 0.248, 0.404, 0.717, 1.169, 1.721, 2.317, 2.894, 3.394, 3.768, 3.989, 4.055 };
*/
        double[] a = new double[N + 1];
        double[] b = new double[N + 1];
        double[] c = new double[N + 1];
        double[] d = new double[N + 1];

        double[] h = new double[N + 1];
        double[] xiCoef = new double[N + 1];
        double[] etaCoef = new double[N + 1];

        double x0_cond = 0;
        double xn_cond = 0;

        public enum conds
        {
            cond_0_0 = 0,
            cond_0_xn = 1,
            cond_x0_xn = 2,
        };

        private static int get_num_cond(conds cond)
        {
            switch (cond)
            {
                case conds.cond_0_0:
                    return 0;
                case conds.cond_0_xn:
                    return 1;
                case conds.cond_x0_xn:
                    return 2;
                default:
                    return -1;
            }
        }

        public delegate void set_x0_xn_conds();

        public void HandleConditional(conds cond)
        {
            set_x0_xn_conds func;
            switch (cond)
            {
                case conds.cond_0_0:
                    func = cond_0_and_0;
                    break;
                case conds.cond_0_xn:
                    func = cond_0_and_xn;
                    break;
                case conds.cond_x0_xn:
                    func = cond_x0_and_xn;
                    break;
                default:
                    func = null;
                    break;
            }
            func();
        }

        public void cond_0_and_0()
        {
            x0_cond = 0;
            xn_cond = 0;
        }

        public void cond_0_and_xn()
        {
            x0_cond = 0;
            xn_cond = Newton.FindDerivativeNewtonPolynom(Newton.n_pow + 1, x[N - 1]);
        }

        public void cond_x0_and_xn()
        {
            x0_cond = Newton.FindDerivativeNewtonPolynom(Newton.n_pow + 1, x[0]);
            xn_cond = Newton.FindDerivativeNewtonPolynom(Newton.n_pow + 1, x[N - 1]);
            //Console.WriteLine($"{x0_cond} {xn_cond}");
        }


        static int GetPos(double x_val)
        {
            uint pos = 0;

            if (x_val < x[0])
                pos = 0;
            else if (x_val > x[N - 1])
                pos = N - 1;
            else
            {
                for (uint i = 1; i <= N - 1; i++)
                {
                    if (x_val > x[i - 1] && x_val <= x[i])
                    {
                        pos = i - 1;
                        break;
                    }
                }
            }

            return (int)pos;
        }

        public void set_table(DataGridView pointTable)
        {
            // Добавляем колонки в таблицу
            pointTable.Columns.Add("a", "a");
            pointTable.Columns.Add("b", "b");
            pointTable.Columns.Add("c", "c");
            pointTable.Columns.Add("d", "d");
            pointTable.Columns.Add("Segment", "Отрезок");
            for (int i = 1; i < N; i++)
            {
                pointTable.Rows.Add(a[i], b[i], c[i], d[i], $"{x[i - 1]} <= x <= {x[i]}");
            }
        }
        public static void add_raw_points(Chart mainChart)
        {
            // Добавляем точки
            for (uint i = 0; i < N; i++)
            {
                mainChart.Series["Points"].Points.AddXY(x[i], y[i]);
            }
        }

        public void add_spline_points(Chart mainChart, conds cond)
        {
            int num = get_num_cond(cond);
            // Добавляем точки сплайна
            for (double xi = x[0]; xi <= x[N - 1]; xi += 0.01)
            {
                double yi = SplineInterpolation(xi);
                mainChart.Series[$"Spline {num}"].Points.AddXY(xi, yi);
            }
        }

        public void calc_spline_point(Chart mainChart, double x_val, Label y_info)
        {
            double y_val = SplineInterpolation(x_val);
            if (x0_cond == 0 && xn_cond == 0)
            {
                mainChart.Series["SplinePoint"].Points.Clear();
                mainChart.Series["SplinePoint"].Points.AddXY(x_val, y_val);
                y_info.Text = $"Вычисленное значение Y (сплайн 0 и 0: x = {x_val}): {y_val.ToString("F9")}";
            }
            else if (x0_cond == 0 && xn_cond != 0)
                y_info.Text = $"Вычисленное значение Y (сплайн 0 и P''(xn): x = {x_val}): {y_val.ToString("F9")}";
            else
                y_info.Text = $"Вычисленное значение Y (сплайн P''(x0) и P''(xn): x = {x_val}): {y_val.ToString("F9")}";
        }

        public void CalculateCoefficients()
        {
            //Console.WriteLine($"{x0_cond} {xn_cond}");
            a[0] = 0;
            b[0] = 0;
            c[0] = 0;
            c[1] = x0_cond / 2;
            //c[2] = xn_cond / 2;

            d[0] = 0;
            h[0] = 0;
            for (int i = 1; i <= N; i++)
            {
                a[i] = y[i - 1];
            }

            for (int i = 1; i < N; i++)
            {
                h[i] = x[i] - x[i - 1];
                c[i] = 0;
            }
            c[N] = 0;

            xiCoef[0] = 0;
           /* xiCoef[1] = x0_cond / 2;
            xiCoef[2] = xn_cond / 2;*/
            etaCoef[0] = 0;
            etaCoef[2] = x0_cond / 2;
            //etaCoef[2] = xn_cond / 2;

            for (int i = 3; i < N + 1; i++)
            {
                double xii = h[i - 1] / (-2 * (h[i - 1] + h[i - 2]) - h[i - 2] * xiCoef[i - 1]);
                xiCoef[i] = xii;

                double fStrong = -3 * ((y[i - 1] - y[i - 2]) / h[i - 1] - (y[i - 2] - y[i - 3]) / h[i - 2]);
                double etai = (fStrong + h[i - 2] * etaCoef[i - 1]) / (-2 * (h[i - 1] + h[i - 2]) - h[i - 2] * xiCoef[i - 1]);
                etaCoef[i] = etai;
            }

            //Console.WriteLine(string.Join(", ", etaCoef));
            c[N] = xiCoef[xiCoef.Length - 1] * xn_cond/2 + etaCoef[etaCoef.Length - 1];
            for (uint i = N - 1; i > 0; i--)
            {
                c[i] = xiCoef[i + 1] * c[i + 1] + etaCoef[i + 1];
            }

            //Console.WriteLine(string.Join(", ", c));

            for (int i = 1; i < N; i++)
            {
                b[i] = (a[i + 1] - a[i]) / h[i] - h[i] / 3 * (c[i + 1] + 2 * c[i]);
                d[i] = (c[i + 1] - c[i]) / 3 / h[i];
            }

            b[N] = 0;
            d[N] = 0;
            Console.WriteLine($"{c[1]}, {c[N]}");
        }

        double SplineInterpolation(double xi)
        {
            /*int k = 0;
            for (int i = 0; i < N; i++)
            {
                if (xi >= x[i] && xi <= x[i + 1])
                {
                    k = i + 1;
                    break;
                }
            }*/
            int pos = GetPos(xi);
            double dx = xi - x[pos];
            double res = a[pos + 1] + b[pos + 1] * dx + c[pos + 1] * dx * dx + d[pos + 1] * dx * dx * dx;
            // ПРИ РАЗНЫХ КОЭФФАХ ВЫДАЕТ ОДИНАКОВЫЙ РЕЗУЛЬТАТ - КАК ТАК?
            /*if (pos == 1)
                Console.WriteLine($"a = {a[pos + 1]};b = {b[pos + 1]};c = {c[pos + 1]};d = {d[pos + 1]}, dx = {dx}, res = {a[pos + 1] + b[pos + 1] * dx + c[pos + 1] * dx * dx + d[pos + 1] * dx * dx * dx}");
            */return res;
        }

        internal void Start_Interpolation(Chart chart, conds cond)
        {
            Array.Clear(a, 0, a.Length);
            Array.Clear(b, 0, b.Length);
            Array.Clear(c, 0, c.Length);
            Array.Clear(d, 0, d.Length);
            Array.Clear(h, 0, h.Length);
            Array.Clear(etaCoef, 0, etaCoef.Length);
            Array.Clear(xiCoef, 0, xiCoef.Length);

            HandleConditional(cond);

            CalculateCoefficients();

            //add_raw_points(chart);

            add_spline_points(chart, cond);
        }
    }
}
