using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab_02
{
    public partial class Form1 : Form
    {
        static Spline zero_and_zero = new Spline();
        static Spline zero_and_ddx = new Spline();
        static Spline ddx_and_ddx = new Spline();

        private double originalXMin;
        private double originalXMax;
        public Form1()
        {
            InitializeComponent();
            mainChart.Cursor = Cursors.Cross;
            /*mainChart.MouseDown += mainChart_MouseDown;
            mainChart.MouseUp += mainChart_MouseUp;*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Debug.WriteLine("Loaded");
            // Newton stuff
            Newton.add_newton_points(mainChart);
            // add points
            Spline.add_raw_points(mainChart);
            // 0 and 0
            // СОЗДАТЬ РАЗНЫЕ ЭКЗЕМПЛЯРЫ!
            zero_and_zero.Start_Interpolation(mainChart, Spline.conds.cond_0_0);
            
            if (Newton.can_use_newton)
            {
                // 0 and P''(xn)
                zero_and_ddx.Start_Interpolation(mainChart, Spline.conds.cond_0_xn);
                // P''(x0) and P''(xn)
                ddx_and_ddx.Start_Interpolation(mainChart, Spline.conds.cond_x0_xn);
            }

            originalXMin = mainChart.ChartAreas[0].AxisX.Minimum;
            originalXMax = mainChart.ChartAreas[0].AxisX.Maximum;

            mainChart.Titles.Add("График сплайна");

            // Создаем таблицу для коэффициентов сплайнов
            pointTable.RowHeadersVisible = false; // Скрываем заголовки строк
            zero_and_zero.set_table(pointTable);
        }



        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private bool get_x_from_textbox(out double x)
        {
            string inputText = x_textbox.Text;

            if (double.TryParse(inputText, out x))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Ошибка: Невозможно прочитать число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                x = 0;
                return false;
            }
        }

        private void btn_newton_Click(object sender, EventArgs e)
        {
            double x;
            if (Newton.can_use_newton && get_x_from_textbox(out x))
                Newton.calc_newton_point(mainChart, x, lb_y_newton_info);
        }

        private void btn_spline_Click_1(object sender, EventArgs e)
        {
            double x;
            if (get_x_from_textbox(out x))
            {
                zero_and_zero.calc_spline_point(mainChart, x, lb_y_spline_info);
                if (Newton.can_use_newton)
                {
                    zero_and_ddx.calc_spline_point(mainChart, x, lb_y_spline_xn_info);
                    ddx_and_ddx.calc_spline_point(mainChart, x, lb_y_spline_x0xn_info);
                }
            }
        }

        private void checkbox_newton_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_newton.Checked)
            {
                mainChart.Series["Newton"].Enabled = true; // Показать серию
                mainChart.Series["NewtonPoint"].Enabled = true; // Показать серию
            }
            else
            {
                mainChart.Series["Newton"].Enabled = false; // Спрятать серию
                mainChart.Series["NewtonPoint"].Enabled = false; // Показать серию
            }
        }

        private void checkbox_spline_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_spline.Checked)
            {
                mainChart.Series["Spline 0"].Enabled = true; // Показать серию
                mainChart.Series["SplinePoint"].Enabled = true; // Показать серию
            }
            else
            {
                mainChart.Series["Spline 0"].Enabled = false; // Спрятать серию
                mainChart.Series["SplinePoint"].Enabled = false; // Показать серию
            }
        }

        private void dots_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (dots_checkbox.Checked)
            {
                mainChart.Series["Points"].Enabled = true;
            }
            else
            {
                mainChart.Series["Points"].Enabled = false;
            }
        }

        private void checkbox_spline_0xn_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_spline_0xn.Checked)
            {
                mainChart.Series["Spline 1"].Enabled = true; // Показать серию
                //mainChart.Series["SplinePoint"].Enabled = true; // Показать серию
            }
            else
            {
                mainChart.Series["Spline 1"].Enabled = false; // Спрятать серию
                //mainChart.Series["SplinePoint"].Enabled = false; // Показать серию
            }
        }

        private void checkbox_spline_x0xn_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_spline_x0xn.Checked)
            {
                mainChart.Series["Spline 2"].Enabled = true; // Показать серию
                //mainChart.Series["SplinePoint"].Enabled = true; // Показать серию
            }
            else
            {
                mainChart.Series["Spline 2"].Enabled = false; // Спрятать серию
                //mainChart.Series["SplinePoint"].Enabled = false; // Показать серию
            }
        }

        /*private void mainChart_MouseDown(object sender, MouseEventArgs e)
        {
            Chart chart = (Chart)sender;
            chart.ChartAreas[0].CursorX.SelectionStart = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
        }

        private void mainChart_MouseUp(object sender, MouseEventArgs e)
        {
            Chart chart = (Chart)sender;
            chart.ChartAreas[0].CursorX.SelectionEnd = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.X);

            // Обновляем представление масштабирования
            chart.ChartAreas[0].AxisX.ScaleView.Zoom(
                Math.Min(chart.ChartAreas[0].CursorX.SelectionStart, chart.ChartAreas[0].CursorX.SelectionEnd),
                Math.Max(chart.ChartAreas[0].CursorX.SelectionStart, chart.ChartAreas[0].CursorX.SelectionEnd));
        }*/

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Проверяем, была ли нажата комбинация Ctrl + Z
            if (e.KeyCode == Keys.Z)
            {
                // Возвращаем график в исходное положение
                Console.WriteLine("lmao");
                mainChart.ChartAreas[0].AxisX.ScaleView.Zoom(originalXMin, originalXMax);
            }
        }
    }
}
