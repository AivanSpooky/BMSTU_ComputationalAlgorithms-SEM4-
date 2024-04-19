using Arction.WinForms.Charting;
using lab_03;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_03
{
    internal static class Interpolation
    {
        public static double x_enter = 0;
        public static double y_enter = 0;
        public static double z_enter = 0;
        private enum rcodes
        {
            NOTHING_HAPPENED = -1,
            OK = 0,
            ERR_Z_RANGE = 1,
            ERR_Y_RANGE = 2,
            ERR_X_RANGE = 3,
            ERR_X_INPUT = 4,
            ERR_Y_INPUT = 5,
            ERR_Z_INPUT = 6,
            ERR_NX_INPUT = 7,
            ERR_NY_INPUT = 8,
            ERR_NZ_INPUT = 9,
            ERR_NX_VALUE = 10,
            ERR_NY_VALUE = 11,
            ERR_NZ_VALUE = 12,
        };

        public static void add_smth(ref int x, ref int y, ref int z)
        {
            x += 100;
            y += 100;
            z += 100;
        }

        public static bool n_x_needed = true;
        public static int n_x = 4;
        public static bool n_y_needed = true;
        public static int n_y = 4;
        public static bool n_z_needed = true;
        public static int n_z = 4;

        public static uint N = 5;
        public static bool use_arrs = true;
        public static double[] x = { 0, 1, 2, 3, 4 };
        /*public static double[] x = { 0, 1, 2, 3, 4 };*/
        public static double[] x_range = { 0, 4, 1 };
        public static double[] y = { 0, 1, 2, 3, 4 };
        public static double[] y_range = { 0, 4, 1 };
        public static double[] z = { 0, 1, 2, 3, 4 };
        public static double[] z_range = { 0, 4, 1 };

        public static void change_points()
        {
            /*
             * -0,152
             * 1,141
             * 1,43
             *  должно быть примерно 0,48
             */

            /*double start_x = -5;
            double end_x = 5;
            int steps_x = 120;
            double start_y = -3;
            double end_y = 4;
            int steps_y = 150;
            double start_z = -1;
            double end_z = 2;
            int steps_z = 130;*/
            double start_x = -5;
            double end_x = 5;
            int steps_x = 20;
            double start_y = -3;
            double end_y = 4;
            int steps_y = 50;
            double start_z = -1;
            double end_z = 2;
            int steps_z = 30;


            add_smth(ref steps_x, ref steps_y, ref steps_z);
            function_values = new List<List<double>>[steps_z];

            x = new double[steps_x];
            y = new double[steps_y];
            z = new double[steps_z];
            double step_x = (end_x - start_x) / steps_x;
            double step_y = (end_y - start_y) / steps_y;
            double step_z = (end_z - start_z) / steps_z;

            for (int i = 0; i < steps_x; i++)
            {
                x[i] = start_x;
                start_x += step_x;
            }
            for (int i = 0; i < steps_y; i++)
            {
                y[i] = start_y;
                start_y += step_y;
            }
            for (int i = 0; i < steps_z; i++)
            {
                z[i] = start_z;
                start_z += step_z;
            }
            N = (uint)(x.Length + y.Length + z.Length);
        }

        public static List<List<double>>[] function_values = new List<List<double>>[N];

        public static function_generator func;

        public delegate double function_generator(double x, double y, double z);

        public static double func_squares(double x, double y, double z)
        {
            return Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2);
        }

        public static double func_squares_strange(double x, double y, double z)
        {
            return (-1)*Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2);
        }
        public static double func_squares_strange_y(double x, double y, double z)
        {
            return Math.Pow(x, 2) - Math.Pow(y, 2) + Math.Pow(z, 2);
        }

        public static double func_shahnovich(double x, double y, double z)
        {
            if (Math.Abs(x + y) < 1e-10)
                return 1e6;
            return 1 / (x + y) - z;
        }

        public static double func_lobach(double x, double y, double z)
        {
            return Math.Exp(2 * x - y) * z;
        }

        public static double func_xyz(double x, double y, double z)
        {
            return x * y * z;
        }

        public static double func_center(double x, double y, double z)
        {
            return 1 / Math.Abs(x - 2 - double.Epsilon) + 1 / Math.Abs(y - 2 - double.Epsilon) + 1 / Math.Abs(z - 2 - double.Epsilon);
        }

        public static double func_linear(double x, double y, double z)
        {
            return x + y + z;
        }

        public static double func_without_z(double x, double y, double z)
        {
            return x + y;
        }

        public static double func_bool(double x, double y, double z)
        {
            return (x > y ? 1 : 0) + (x > z ? 1 : 0);
        }

        public static double func_changed(double x, double y, double z)
        {
            return (x > y ? x : z);
        }

        public static double func_linear_strange(double x, double y, double z)
        {
            return x - y + z;
        }

        public static double func_kozyrnov(double x, double y, double z)
        {
            return Math.Pow(x, 2) + Math.Pow(y, 3) + Math.Sqrt(z);
        }

        private static int fill_function_values(function_generator func, bool use_arrays)
        {
            if (use_arrays == false)
            {
                int rc = (int)rcodes.OK;
                uint cur_matrix = 0, cur_row = 0, cur_col = 0;
                for (double k = z_range[0]; k <= z_range[1]; k += z_range[2])
                {
                    if (cur_matrix >= z.Length)
                    {
                        rc = (int)rcodes.ERR_Z_RANGE;
                        return rc;
                    }
                    List<List<double>> cur_matrix_values = new List<List<double>>();
                    cur_row = 0;
                    for (double j = y_range[0]; j <= y_range[1]; j += y_range[2])
                    {
                        if (cur_row >= y.Length)
                        {
                            rc = (int)rcodes.ERR_Y_RANGE;
                            return rc;
                        }
                        List<double> cur_row_values = new List<double>();
                        cur_col = 0;
                        for (double i = x_range[0]; i <= x_range[1]; i += x_range[2])
                        {
                            Console.WriteLine($"{cur_col} x={i}");
                            if (cur_col >= x.Length)
                            {
                                rc = (int)rcodes.ERR_X_RANGE;
                                return rc;
                            }
                            double value = func(i, j, k);
                            cur_row_values.Add(value);
                            cur_col++;
                        }
                        cur_matrix_values.Add(cur_row_values);
                        cur_row++;
                    }
                    function_values[cur_matrix] = cur_matrix_values;
                    cur_matrix++;
                }
                return rc;
            }
            else
            {
                int rc = (int)rcodes.OK;
                for (int k = 0; k < z.Length; k++)
                {
                    List<List<double>> cur_matrix_values = new List<List<double>>();
                    for (int j = 0; j < y.Length; j++)
                    {
                        List<double> cur_row_values = new List<double>();
                        for (int i = 0; i < x.Length; i++)
                        {
                            double value = func(x[i], y[j], z[k]);
                            cur_row_values.Add(value);
                        }
                        cur_matrix_values.Add(cur_row_values);
                    }
                    function_values[k] = cur_matrix_values;
                }
                return rc;
            }
        }

        public static void print_function_values(bool use_arrays)
        {
            /*string format = "F4";*/
            string format = "F2";
            if (use_arrays)
            {
                for (int k = 0; k < z.Length; k++)
                {
                    Console.WriteLine($"z = {z[k]}; Matrix {k + 1}");
                    Console.WriteLine("y\\x\t\t" + string.Join("\t", x.Select(val => val.ToString(format))));
                    for (int j = 0; j < y.Length; j++)
                    {
                        Console.Write($"{y[j].ToString(format)}\t");
                        for (int i = 0; i < x.Length; i++)
                        {
                            Console.Write($"{function_values[k][j][i].ToString(format)}\t");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                double cur_z = z_range[0];
                for (uint cur_matrix = 0; cur_matrix < N; cur_matrix++)
                {
                    Console.WriteLine($"z = {cur_z}; Matrix {cur_matrix + 1}");
                    Console.WriteLine("y\\x\t\t" + string.Join("\t", Enumerable.Range(0, (int)N).Select(i => (x_range[0] + i * x_range[2]).ToString(format))));
                    for (int j = 0; j < N; j++)
                    {
                        Console.Write($"{(y_range[0] + j * y_range[2]).ToString(format)}\t");
                        for (int i = 0; i < N; i++)
                        {
                            Console.Write($"{function_values[cur_matrix][j][i].ToString(format)}\t");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    cur_z += z_range[2];
                }
            }
        }

        public static void generate_function_data()
        {
            change_points();
            /*function_generator func = new function_generator(func_squares);*/
            /*function_generator func = new function_generator(func_linear);*/
            /*function_generator func = new function_generator(func_squares_strange);*/
            /*function_generator func = new function_generator(func_linear_strange);*/
            /*function_generator func = new function_generator(func_kozyrnov);*/
            /*function_generator func = new function_generator(func_center);*/
            /*function_generator func = new function_generator(func_without_z);*/
            /*function_generator func = new function_generator(func_bool);*/
            /*function_generator func = new function_generator(func_changed);*/
            /*function_generator func = new function_generator(func_lobach);*/


            func = new function_generator(func_shahnovich);


            int rc = fill_function_values(func, use_arrs);

            Console.Write("x: ");
            foreach (var val in x)
            {
                Console.Write($"{val}\t");
            }
            Console.Write("\n");
            /*if (rc == (int)rcodes.OK)
                print_function_values(use_arrs);*/
        }






        public static int SetValuesFromTextBoxes(TextBox tb_x, TextBox tb_y, TextBox tb_z, TextBox tb_nx, TextBox tb_ny, TextBox tb_nz)
        {
            if (!double.TryParse(tb_x.Text, out double xValue))
            {
                MessageBox.Show("Ошибка ввода для x");
                return (int)rcodes.ERR_X_INPUT;
            }

            if (!double.TryParse(tb_y.Text, out double yValue))
            {
                MessageBox.Show("Ошибка ввода для y");
                return (int)rcodes.ERR_Y_INPUT;
            }

            if (!double.TryParse(tb_z.Text, out double zValue))
            {
                MessageBox.Show("Ошибка ввода для z");
                return (int)rcodes.ERR_Z_INPUT;
            }

            int nxValue = 0, nyValue = 0, nzValue = 0;

            if (n_x_needed && !int.TryParse(tb_nx.Text, out nxValue))
            {
                MessageBox.Show("Ошибка ввода для nx");
                return (int)rcodes.ERR_NX_INPUT;
            }

            if (n_y_needed && !int.TryParse(tb_ny.Text, out nyValue))
            {
                MessageBox.Show("Ошибка ввода для ny");
                return (int)rcodes.ERR_NY_INPUT;
            }

            if (n_z_needed && !int.TryParse(tb_nz.Text, out nzValue))
            {
                MessageBox.Show("Ошибка ввода для nz");
                return (int)rcodes.ERR_NZ_INPUT;
            }

            if (nxValue >= x.Length)
            {
                MessageBox.Show("Задана слишком большая степень nx");
                return (int)rcodes.ERR_NX_VALUE;
            }
            if (nyValue >= y.Length)
            {
                MessageBox.Show("Задана слишком большая степень ny");
                return (int)rcodes.ERR_NX_VALUE;
            }
            if (nzValue >= z.Length)
            {
                MessageBox.Show("Задана слишком большая степень nz");
                return (int)rcodes.ERR_NX_VALUE;
            }
            x_enter = xValue;
            y_enter = yValue;
            z_enter = zValue;

            n_x = nxValue;
            n_y = nyValue;
            n_z = nzValue;

            return (int)rcodes.OK;
        }

        public static double Interpolate(double x_e, double y_e, double z_e)
        {
            double u = 0;
            List<Point> z_values = new List<Point>();
            if (use_arrs)
            {
                for (int k = 0; k < z.Length; k++)
                {
                    List<Point> y_values = new List<Point>();
                    for (int j = 0; j < y.Length; j++)
                    {
                        List<Point> x_values = new List<Point>();
                        for (int i = 0; i < x.Length; i++)
                        {
                            x_values.Add(new Point(x[i], function_values[k][j][i] /*u ()*/));
                        }
                        if (n_x_needed)
                        {
                            Newton NP = new Newton();
                            y_values.Add(new Point(y[j], NP.NewtonPolynom(x_values, n_x + 1, x_e, x.Length)));
                        }
                        else
                        {
                            Spline SP = new Spline();
                            SP.Start_Interpolation(x_values);
                            y_values.Add(new Point(y[j], SP.calc_spline_point(x_e)));
                        }
                    }
                    if (n_y_needed)
                    {
                        Newton NP = new Newton();
                        z_values.Add(new Point(z[k], NP.NewtonPolynom(y_values, n_y + 1, y_e, y.Length)));
                    }
                    else
                    {
                        Spline SP = new Spline();
                        SP.Start_Interpolation(y_values);
                        z_values.Add(new Point(z[k], SP.calc_spline_point(y_e)));
                    }
                }
                if (n_z_needed)
                {
                    Newton NP = new Newton();
                    u = NP.NewtonPolynom(z_values, n_z + 1, z_e, z.Length);
                }
                else
                {
                    Spline SP = new Spline();
                    SP.Start_Interpolation(z_values);
                    u = SP.calc_spline_point(z_e);
                }
            }
            else
            {
                int cur_z = 0, cur_y = 0, cur_x = 0;
                for (double k = z_range[0]; k <= z_range[1]; k += z_range[2])
                {
                    List<Point> y_values = new List<Point>();
                    cur_y = 0;
                    for (double j = y_range[0]; j <= y_range[1]; j += y_range[2])
                    {
                        List<Point> x_values = new List<Point>();
                        cur_x = 0;
                        for (double i = x_range[0]; i <= x_range[1]; i += x_range[2])
                        {
                            x_values.Add(new Point(i, function_values[cur_z][cur_y][cur_x]));
                            cur_x++;
                        }

                        // Интерполируем по x_values для фиксированных y и z
                        if (n_x_needed)
                        {
                            Newton NP = new Newton();
                            double interpolatedValue = NP.NewtonPolynom(x_values, n_x + 1, x_e, x.Length);
                            y_values.Add(new Point(j, interpolatedValue));
                        }
                        else
                        {
                            Spline SP = new Spline();
                            SP.Start_Interpolation(x_values);
                            double interpolatedValue = SP.calc_spline_point(x_e);
                            y_values.Add(new Point(j, interpolatedValue));
                        }
                        cur_y++;
                    }

                    // Интерполируем по y_values для фиксированного z
                    if (n_y_needed)
                    {
                        Newton NP = new Newton();
                        double interpolatedValue = NP.NewtonPolynom(y_values, n_y + 1, y_e, y.Length);
                        z_values.Clear();
                        z_values.Add(new Point(k, interpolatedValue));
                    }
                    else
                    {
                        Spline SP = new Spline();
                        SP.Start_Interpolation(y_values);
                        double interpolatedValue = SP.calc_spline_point(y_e);
                        z_values.Clear();
                        z_values.Add(new Point(k, interpolatedValue));
                    }
                    cur_z++;
                }

                // Интерполируем по z_values
                if (n_z_needed)
                {
                    Newton NP = new Newton();
                    u = NP.NewtonPolynom(z_values, n_z + 1, z_e, z.Length);
                }
                else
                {
                    Spline SP = new Spline();
                    SP.Start_Interpolation(z_values);
                    u = SP.calc_spline_point(z_e);
                }
            }
            return u;
        }

        public static double calc_interpolation_point(double x, double y, double z)
        {
            double u = 0;
            List<Point> z_values = new List<Point>();
            int cur_z = 0, cur_y = 0, cur_x = 0;
            for (double k = z_range[0]; k <= z_range[1]; k += z_range[2])
            {
                List<Point> y_values = new List<Point>();
                cur_y = 0;
                for (double j = y_range[0]; j <= y_range[1]; j += y_range[2])
                {
                    List<Point> x_values = new List<Point>();
                    cur_x = 0;
                    for (double i = x_range[0]; i <= x_range[1]; i += x_range[2])
                    {
                        x_values.Add(new Point(i, function_values[cur_z][cur_y][cur_x]));
                        cur_x++;
                    }

                    // Интерполируем по x_values для фиксированных y и z
                    if (n_x_needed)
                    {
                        Newton NP = new Newton();
                        double interpolatedValue = NP.NewtonPolynom(x_values, n_x + 1, x, cur_x);
                        y_values.Add(new Point(j, interpolatedValue));
                    }
                    else
                    {
                        Spline SP = new Spline();
                        SP.Start_Interpolation(x_values);
                        double interpolatedValue = SP.calc_spline_point(x);
                        y_values.Add(new Point(j, interpolatedValue));
                    }
                    cur_y++;
                }

                // Интерполируем по y_values для фиксированного z
                if (n_y_needed)
                {
                    Newton NP = new Newton();
                    double interpolatedValue = NP.NewtonPolynom(y_values, n_y + 1, y, cur_y);
                    z_values.Clear();
                    z_values.Add(new Point(k, interpolatedValue));
                }
                else
                {
                    Spline SP = new Spline();
                    SP.Start_Interpolation(y_values);
                    double interpolatedValue = SP.calc_spline_point(y);
                    z_values.Clear();
                    z_values.Add(new Point(k, interpolatedValue));
                }
                cur_z++;
            }

            // Интерполируем по z_values
            if (n_z_needed)
            {
                Newton NP = new Newton();
                u = NP.NewtonPolynom(z_values, n_z + 1, z, cur_z);
            }
            else
            {
                Spline SP = new Spline();
                SP.Start_Interpolation(z_values);
                u = SP.calc_spline_point(z);
            }
            return u;
        }
        public static void generate_graphics(LightningChart lc)
        {
            double start_x = x_range[0], end_x = x_range[1], start_y = y_range[0], end_y = y_range[1], start_z = z_range[0], end_z = z_range[1];
            if (use_arrs)
            {
                start_x = x.Min();
                end_x = x.Max();
                start_y = y.Min();
                end_y = y.Max();
                start_z = z.Min();
                end_z = z.Max();
            }
            /*double x_step = x_range[2], y_step = y_range[2], z_step = z_range[2];*/
            double x_step = 1e-1, y_step = 1e-1, z_step = 1;
            List<double> xs = new List<double>();
            List<double> ys = new List<double>();
            List<double> zs = new List<double>();
            List<double> us = new List<double>();
            while (start_x <= end_x)
            {
                start_y = y_range[0];
                while (start_y <= end_y)
                {
                    start_z = z_range[0];
                    while (start_z <= end_z)
                    {
                        double u = Interpolate(start_x, start_y, start_z);
                        xs.Add(start_x);
                        ys.Add(start_y);
                        zs.Add(start_z);
                        us.Add(u);
                        start_z += z_step;
                    }
                    start_y += y_step;
                }
                start_x += x_step;
            }
            Plot(lc, xs, ys, zs, us);
        }

        public static void generate_graphics(LightningChart lc, double z_set)
        {
            double start_x = x_range[0], end_x = x_range[1], start_y = y_range[0], end_y = y_range[1], start_z = z_set, end_z = z_set;
            /*double x_step = x_range[2], y_step = y_range[2], z_step = z_range[2];*/
            double x_step = 2, y_step = 2, z_step = 2;
            List<double> xs = new List<double>();
            List<double> ys = new List<double>();
            List<double> zs = new List<double>();
            List<double> us = new List<double>();
            while (start_x <= end_x)
            {
                start_y = y_range[0];
                while (start_y <= end_y)
                {
                    start_z = z_set;
                    while (start_z <= end_z)
                    {
                        double u = Interpolate(start_x, start_y, start_z);
                        xs.Add(start_x);
                        ys.Add(start_y);
                        zs.Add(start_z);
                        us.Add(u);
                        start_z += z_step;
                    }
                    start_y += y_step;
                }
                start_x += x_step;
            }
            Plot(lc, xs, ys, zs, us);
        }

        public static void Plot(LightningChart lc, List<double> x, List<double> y, List<double> z, List<double> u)
        {
            // Создание точек и задание им цвета в зависимости от значения u
            SeriesPoint3D[] points = new SeriesPoint3D[u.Count];
            for (int i = 0; i < u.Count; i++)
            {
                // Определение цвета в зависимости от значения u
                Color color = Color.FromArgb(
                    255,
                    255 - (int)(255 * (u[i] - u.Min()) / (u.Max() - u.Min())), // Уменьшаем красный канал
                    0,
                    (int)(255 * (u[i] - u.Min()) / (u.Max() - u.Min())) // Увеличиваем синий канал
                );


                /*PointDoubleXYZ point = new PointDoubleXYZ(x[i], y[i], z[i]);*/
                /*Console.WriteLine($"x={x[i]}, y={y[i]}, z={z[i]}, u={u[i]}, color={color}");*/
                SeriesPoint3D point = new SeriesPoint3D(x[i], y[i], z[i], color);
                points[i] = point;
            }
            lc.View3D.PointLineSeries3D[0].AddPoints(points, false);
        }
    }
}
