using lab_03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab_03
{
    internal class Newton
    {
        public int n_pow = 0;
        public int N = 0;
        private const double Infinity = double.PositiveInfinity;
        public List<Point> points = new List<Point>();

        /*public void add_newton_points(Chart mainChart)
        {
            // Добавляем точки для Ньютона
            if (n_pow < Interpolation.N)
                for (double xi = Interpolation.x[0]; xi <= Interpolation.x[Interpolation.N - 1]; xi += 0.01)
                {
                    double yi = NewtonPolynom(n_pow + 1, xi);
                    mainChart.Series["Newton"].Points.AddXY(xi, yi);
                }
            else
            {
                MessageBox.Show("Ошибка: Невозможно построить полином Ньютона. Необходимо указать больше N точек!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        public double calc_newton_point(double x_val)
        {
            double y_val = NewtonPolynom(points, n_pow + 1, x_val, N);
            return y_val;
        }

        public void set_points()
        {
            for (uint i = 0; i < N; i++)
            {
                points.Add(new Point(Interpolation.x[i], Interpolation.y[i]));
            }
        }

        private int GetIndex(double x)
        {
            double dif = Math.Abs(points[0].x - x);
            int index = 0;
            for (int i = 0; i < N && points[i].x <= x; i++)
            {
                if (Math.Abs(points[i].x - x) < dif)
                {
                    dif = Math.Abs(points[i].x - x);
                    index = i;
                }
            }
            return index;
        }

        private List<Point> GetWorkingPoints(int index, int n)
        {
            int left = index;
            int right = index;
            for (int i = 0; i < n - 1; i++)
            {
                if (i % 2 == 1)
                {
                    if (left == 0)
                    {
                        right++;
                    }
                    else
                    {
                        left--;
                    }
                }
                else
                {
                    if (right == N - 1)
                    {
                        left--;
                    }
                    else
                    {
                        right++;
                    }
                }
            }
            /*return points.GetRange(left, right);*/
            return points.GetRange(left, right - left + 1);
        }

        public List<List<double>> NewtonMethod(List<Point> workingTable)
        {
            int countOfRowsOfTableData = 2;
            List<List<double>> tableOfSub = new List<List<double>>();
            foreach (var point in workingTable)
            {
                tableOfSub.Add(new List<double> { point.x, point.y });
            }

            var transposedTable = tableOfSub.Transpose();
            var xRow = transposedTable[0];

            for (int countOfArgs = 1; countOfArgs < xRow.Count; countOfArgs++)
            {
                transposedTable.Add(new List<double>());
                var curYRow = transposedTable[transposedTable.Count - countOfRowsOfTableData];
                for (int j = 0; j < xRow.Count - countOfArgs; j++)
                {
                    double cur;
                    if (curYRow[j] == Infinity && curYRow[j + 1] == Infinity)
                    {
                        cur = 1;
                    }
                    else if (curYRow[j] == Infinity)
                    {
                        cur = curYRow[j + 1] / (xRow[j] - xRow[j + countOfArgs]);
                    }
                    else if (curYRow[j + 1] == Infinity)
                    {
                        cur = curYRow[j] / (xRow[j] - xRow[j + countOfArgs]);
                    }
                    else
                    {
                        cur = (curYRow[j] - curYRow[j + 1]) / (xRow[j] - xRow[j + countOfArgs]);
                    }
                    //transposedTable[transposedTable.Count - 1].Add(cur);
                    transposedTable[countOfArgs + countOfRowsOfTableData - 1].Add(cur);
                }
            }

            return transposedTable;
        }

        public double NewtonPolynom(List<Point> new_points, int n, double x, int cnt)
        {
            //set_points();
            N = new_points.Count;
            points = new List<Point>(new_points);
            var workingTable = GetWorkingPoints(GetIndex(x), n);
            var subs = NewtonMethod(workingTable);

            /*#region "debug subs print"
            Console.WriteLine($"x = {x}");
            foreach (var row in subs)
            {
                foreach (double num in row)
                {
                    Console.Write($"{num}\t");
                }
                Console.Write($"\n");
            }
            #endregion*/


            double sum;
            sum = subs[1][0];
            double mainPart = 1;

            for (int i = 0; i < n - 1; i++)
            {
                mainPart *= (x - subs[0][i]);

                if (subs[i + 2][0] != Infinity)
                    sum += mainPart * subs[i + 2][0];
            }
            /*for (int i = 0; i < n; i++)
                        {
                            mainPart = subs[i][0];
                            for (int j = 0; j < i - 1; j++)
                            {
                                mainPart *= (x - subs[i + 1][0]);
                            }
                            sum += mainPart;
                        }*/

            return sum;
        }

        /*public static double FindDerivativeNewtonPolynom(int n, double x)
        {
            var workingTable = GetWorkingPoints(GetIndex(x), n);
            var subs = NewtonMethod(workingTable);

            Func<double, double> approxFunc = val =>
            {
                double res = 0;
                for (int i = 0; i < subs.Count; i++)
                {
                    res += subs[i][0] * Math.Pow(val, i);
                }
                return res;
            };

            Func<double, double> square_parabola = val =>
            {
                return Math.Pow(val, 2);
            };
            *//*Console.WriteLine($"{Differentiate.SecondDerivative(cubic_parabola, 4)}");*//*

            Console.WriteLine($"Current ddx in this func (for x = {x}) = {Differentiate.SecondDerivative(square_parabola, x)}");
            return Differentiate.SecondDerivative(square_parabola, x);
        }*/
    }
    public static class Extensions
    {
        public static List<List<T>> Transpose<T>(this List<List<T>> input)
        {
            var output = new List<List<T>>();
            for (int i = 0; i < input[0].Count; i++)
            {
                output.Add(new List<T>());
                for (int j = 0; j < input.Count; j++)
                {
                    output[i].Add(input[j][i]);
                }
            }
            return output;
        }
    }

    public class Point
    {
        public double x { get; set; }
        public double y { get; set; }

        public Point(double x, double y) { this.x = x; this.y = y; }
    }
}
