using lab_03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static lab_03.Spline;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace lab_03
{
    internal class Spline
    {
        public int N = 0;
        double[] a = new double[Interpolation.N + 1];
        double[] b = new double[Interpolation.N + 1];
        double[] c = new double[Interpolation.N + 1];
        double[] d = new double[Interpolation.N + 1];

        double[] h = new double[Interpolation.N + 1];
        double[] xiCoef = new double[Interpolation.N + 1];
        double[] etaCoef = new double[Interpolation.N + 1];

        private List<Point> points = new List<Point>();

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

        public void HandleConditional()
        {
            set_x0_xn_conds func;
            func = cond_0_and_0;

            func();
        }

        public void cond_0_and_0()
        {
            x0_cond = 0;
            xn_cond = 0;
        }

        /*public void cond_0_and_xn()
        {
            x0_cond = 0;
            xn_cond = Newton.FindDerivativeNewtonPolynom(Newton.n_pow + 1, x[N - 1]);
        }

        public void cond_x0_and_xn()
        {
            x0_cond = Newton.FindDerivativeNewtonPolynom(Newton.n_pow + 1, x[0]);
            xn_cond = Newton.FindDerivativeNewtonPolynom(Newton.n_pow + 1, x[N - 1]);
            //Console.WriteLine($"{x0_cond} {xn_cond}");
        }*/


        int GetPos(double x_val)
        {
            int pos = 0;

            if (x_val < points[0].x)
                pos = 0;
            else if (x_val > points[(int)N - 1].x)
                pos = (int)N - 1;
            else
            {
                for (int i = 1; i <= Interpolation.N - 1; i++)
                {
                    if (x_val > points[i - 1].x && x_val <= points[i].x)
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
            for (int i = 1; i < Interpolation.N; i++)
            {
                pointTable.Rows.Add(a[i], b[i], c[i], d[i], $"{points[i - 1].x} <= x <= {points[i].x}");
            }
        }
        public void add_raw_points(Chart mainChart)
        {
            // Добавляем точки
            for (int i = 0; i < (int)Interpolation.N; i++)
            {
                mainChart.Series["Points"].Points.AddXY(points[i].x, points[i].y);
            }
        }

        public void add_spline_points(Chart mainChart, conds cond)
        {
            int num = get_num_cond(cond);
            // Добавляем точки сплайна
            for (double xi = points[0].x; xi <= points[(int)Interpolation.N - 1].x; xi += 0.01)
            {
                double yi = SplineInterpolation(xi);
                mainChart.Series[$"Spline {num}"].Points.AddXY(xi, yi);
            }
        }

        public double calc_spline_point(double x_val)
        {
            double y_val = SplineInterpolation(x_val);
            return y_val;
        }

        public void CalculateCoefficients()
        {
            //Console.WriteLine($"{x0_cond} {xn_cond}");
            a[0] = 0;
            b[0] = 0;
            c[0] = 0;
            c[1] = x0_cond / 2;

            d[0] = 0;
            h[0] = 0;
            for (int i = 1; i <= N; i++)
            {
                a[i] = points[i - 1].y;
            }

            for (int i = 1; i < N; i++)
            {
                h[i] = points[i].x - points[i - 1].x;
                c[i] = 0;
            }
            c[N] = 0;

            xiCoef[0] = 0;
            etaCoef[0] = 0;
            etaCoef[2] = x0_cond / 2;

            for (int i = 3; i < N + 1; i++)
            {
                double xii = h[i - 1] / (-2 * (h[i - 1] + h[i - 2]) - h[i - 2] * xiCoef[i - 1]);
                xiCoef[i] = xii;

                double fStrong = -3 * ((points[i - 1].y - points[i - 2].y) / h[i - 1] - (points[i - 2].y - points[i - 3].y) / h[i - 2]);
                double etai = (fStrong + h[i - 2] * etaCoef[i - 1]) / (-2 * (h[i - 1] + h[i - 2]) - h[i - 2] * xiCoef[i - 1]);
                etaCoef[i] = etai;
            }

            //Console.WriteLine(string.Join(", ", etaCoef));
            c[N] = xiCoef[xiCoef.Length - 1] * xn_cond / 2 + etaCoef[etaCoef.Length - 1];
            for (int i = N - 1; i > 0; i--)
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
            /*Console.WriteLine($"{c[1]}, {c[N]}");*/
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
            double dx = xi - points[pos].x;
            double res = a[pos + 1] + b[pos + 1] * dx + c[pos + 1] * dx * dx + d[pos + 1] * dx * dx * dx;
            // ПРИ РАЗНЫХ КОЭФФАХ ВЫДАЕТ ОДИНАКОВЫЙ РЕЗУЛЬТАТ - КАК ТАК?
            /*if (pos == 1)
                Console.WriteLine($"a = {a[pos + 1]};b = {b[pos + 1]};c = {c[pos + 1]};d = {d[pos + 1]}, dx = {dx}, res = {a[pos + 1] + b[pos + 1] * dx + c[pos + 1] * dx * dx + d[pos + 1] * dx * dx * dx}");
            */
            return res;
        }

        internal void Start_Interpolation(List<Point> new_points)
        {
            points = new List<Point>(new_points);
            N = new_points.Count;
            Array.Clear(a, 0, a.Length);
            Array.Clear(b, 0, b.Length);
            Array.Clear(c, 0, c.Length);
            Array.Clear(d, 0, d.Length);
            Array.Clear(h, 0, h.Length);
            Array.Clear(etaCoef, 0, etaCoef.Length);
            Array.Clear(xiCoef, 0, xiCoef.Length);

            HandleConditional();

            CalculateCoefficients();

            //add_raw_points(chart);

            //add_spline_points(chart, cond);
        }
    }
}
