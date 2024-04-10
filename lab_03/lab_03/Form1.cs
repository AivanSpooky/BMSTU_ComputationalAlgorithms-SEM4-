using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Interpolation.generate_function_data();
            if (Interpolation.use_arrs)
            {
                lightningChart.View3D.XAxisPrimary3D.Maximum = Interpolation.x.Max();
                lightningChart.View3D.XAxisPrimary3D.Minimum = Interpolation.x.Min();
                lightningChart.View3D.YAxisPrimary3D.Maximum = Interpolation.y.Max();
                lightningChart.View3D.YAxisPrimary3D.Minimum = Interpolation.y.Min();
                lightningChart.View3D.ZAxisPrimary3D.Maximum = Interpolation.z.Max();
                lightningChart.View3D.ZAxisPrimary3D.Minimum = Interpolation.z.Min();
            }
            else
            {
                lightningChart.View3D.XAxisPrimary3D.Maximum = Interpolation.x_range[1];
                lightningChart.View3D.XAxisPrimary3D.Minimum = Interpolation.x_range[0];
                lightningChart.View3D.YAxisPrimary3D.Maximum = Interpolation.y_range[1];
                lightningChart.View3D.YAxisPrimary3D.Minimum = Interpolation.y_range[0];
                lightningChart.View3D.ZAxisPrimary3D.Maximum = Interpolation.z_range[1];
                lightningChart.View3D.ZAxisPrimary3D.Minimum = Interpolation.z_range[0];
            }
        }

        private void rb_x_spline_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_x_spline.Checked)
                tb_nx.Enabled = false;
            else
                tb_nx.Enabled = true;
        }

        private void rb_y_spline_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_y_spline.Checked)
                tb_ny.Enabled = false;
            else
                tb_ny.Enabled = true;
        }

        private void rb_z_spline_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_z_spline.Checked)
                tb_nz.Enabled = false;
            else
                tb_nz.Enabled = true;
        }

        private void rb_x_newton_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_x_newton.Checked)
                Interpolation.n_x_needed = true;
            else
                Interpolation.n_x_needed = false;
        }

        private void rb_y_newton_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_y_newton.Checked)
                Interpolation.n_y_needed = true;
            else
                Interpolation.n_y_needed = false;
        }

        private void rb_z_newton_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_z_newton.Checked)
                Interpolation.n_z_needed = true;
            else
                Interpolation.n_z_needed = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rc = Interpolation.SetValuesFromTextBoxes(tb_x, tb_y, tb_z, tb_nx, tb_ny, tb_nz);
            if (rc == 0)
            {
                double u = Interpolation.Interpolate(Interpolation.x_enter, Interpolation.y_enter, Interpolation.z_enter);
                u_label.Text = $"u = f(x, y, z) = {u:F8}";
            }
            
        }

        public void generate_graphics()
        {
            lightningChart.View3D.PointLineSeries3D[0].Clear();
            lightningChart.View3D.PointLineSeries3D[0].PointStyle.Shape3D = Arction.WinForms.Charting.PointShape3D.Sphere;
            Interpolation.generate_graphics(lightningChart);
        }

        private void btn_plot_all_Click(object sender, EventArgs e)
        {
            lightningChart.View3D.PointLineSeries3D[0].Clear();
            lightningChart.View3D.PointLineSeries3D[0].PointStyle.Shape3D = Arction.WinForms.Charting.PointShape3D.Sphere;
            Interpolation.generate_graphics(lightningChart);
        }

        private void btn_plot_z_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(tb_cur_z.Text, out double zValue))
            {
                MessageBox.Show("Ошибка ввода для cur_z");
                return;
            }

            lightningChart.View3D.PointLineSeries3D[0].Clear();
            lightningChart.View3D.PointLineSeries3D[0].PointStyle.Shape3D = Arction.WinForms.Charting.PointShape3D.Box;
            Interpolation.generate_graphics(lightningChart, zValue);
        }

        private void tb_x_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
