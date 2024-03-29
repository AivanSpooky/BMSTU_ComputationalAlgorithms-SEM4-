namespace lab_02
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pointTable = new System.Windows.Forms.DataGridView();
            this.btn_spline = new System.Windows.Forms.Button();
            this.x_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_newton = new System.Windows.Forms.Button();
            this.lb_y_spline_info = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_y_spline_x0xn_info = new System.Windows.Forms.Label();
            this.lb_y_spline_xn_info = new System.Windows.Forms.Label();
            this.lb_y_newton_info = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkbox_spline_x0xn = new System.Windows.Forms.CheckBox();
            this.checkbox_spline_0xn = new System.Windows.Forms.CheckBox();
            this.dots_checkbox = new System.Windows.Forms.CheckBox();
            this.checkbox_newton = new System.Windows.Forms.CheckBox();
            this.checkbox_spline = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainChart
            // 
            chartArea1.Name = "ChartArea1";
            this.mainChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.mainChart.Legends.Add(legend1);
            this.mainChart.Location = new System.Drawing.Point(12, 12);
            this.mainChart.Name = "mainChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Points";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Color = System.Drawing.Color.Blue;
            series2.Legend = "Legend1";
            series2.MarkerSize = 10;
            series2.Name = "SplinePoint";
            series2.YValuesPerPoint = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Color = System.Drawing.Color.Lime;
            series3.Legend = "Legend1";
            series3.MarkerSize = 10;
            series3.Name = "NewtonPoint";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Spline 0";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series5.Legend = "Legend1";
            series5.Name = "Newton";
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Spline 1";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "Spline 2";
            this.mainChart.Series.Add(series1);
            this.mainChart.Series.Add(series2);
            this.mainChart.Series.Add(series3);
            this.mainChart.Series.Add(series4);
            this.mainChart.Series.Add(series5);
            this.mainChart.Series.Add(series6);
            this.mainChart.Series.Add(series7);
            this.mainChart.Size = new System.Drawing.Size(862, 607);
            this.mainChart.TabIndex = 0;
            this.mainChart.Text = "chart1";
            this.mainChart.Click += new System.EventHandler(this.chart1_Click);
            // 
            // pointTable
            // 
            this.pointTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pointTable.Location = new System.Drawing.Point(880, 26);
            this.pointTable.Name = "pointTable";
            this.pointTable.Size = new System.Drawing.Size(240, 257);
            this.pointTable.TabIndex = 1;
            this.pointTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btn_spline
            // 
            this.btn_spline.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_spline.Location = new System.Drawing.Point(10, 113);
            this.btn_spline.Name = "btn_spline";
            this.btn_spline.Size = new System.Drawing.Size(224, 55);
            this.btn_spline.TabIndex = 2;
            this.btn_spline.Text = "Вычислить по сплайну";
            this.btn_spline.UseVisualStyleBackColor = true;
            this.btn_spline.Click += new System.EventHandler(this.btn_spline_Click_1);
            // 
            // x_textbox
            // 
            this.x_textbox.Location = new System.Drawing.Point(10, 71);
            this.x_textbox.Multiline = true;
            this.x_textbox.Name = "x_textbox";
            this.x_textbox.Size = new System.Drawing.Size(224, 36);
            this.x_textbox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введи значение X:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_newton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_spline);
            this.groupBox1.Controls.Add(this.x_textbox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(1141, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 257);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Действия";
            // 
            // btn_newton
            // 
            this.btn_newton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_newton.Location = new System.Drawing.Point(10, 174);
            this.btn_newton.Name = "btn_newton";
            this.btn_newton.Size = new System.Drawing.Size(224, 56);
            this.btn_newton.TabIndex = 8;
            this.btn_newton.Text = "Вычислить по ньютону";
            this.btn_newton.UseVisualStyleBackColor = true;
            this.btn_newton.Click += new System.EventHandler(this.btn_newton_Click);
            // 
            // lb_y_spline_info
            // 
            this.lb_y_spline_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_y_spline_info.Location = new System.Drawing.Point(6, 22);
            this.lb_y_spline_info.Name = "lb_y_spline_info";
            this.lb_y_spline_info.Size = new System.Drawing.Size(489, 55);
            this.lb_y_spline_info.TabIndex = 6;
            this.lb_y_spline_info.Text = "Вычисленное значение Y (сплайн 0 и 0):";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb_y_spline_x0xn_info);
            this.groupBox2.Controls.Add(this.lb_y_spline_xn_info);
            this.groupBox2.Controls.Add(this.lb_y_newton_info);
            this.groupBox2.Controls.Add(this.lb_y_spline_info);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(880, 308);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(501, 311);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Вычисления";
            // 
            // lb_y_spline_x0xn_info
            // 
            this.lb_y_spline_x0xn_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_y_spline_x0xn_info.Location = new System.Drawing.Point(6, 135);
            this.lb_y_spline_x0xn_info.Name = "lb_y_spline_x0xn_info";
            this.lb_y_spline_x0xn_info.Size = new System.Drawing.Size(489, 55);
            this.lb_y_spline_x0xn_info.TabIndex = 9;
            this.lb_y_spline_x0xn_info.Text = "Вычисленное значение Y (сплайн x0 и xn):";
            // 
            // lb_y_spline_xn_info
            // 
            this.lb_y_spline_xn_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_y_spline_xn_info.Location = new System.Drawing.Point(6, 77);
            this.lb_y_spline_xn_info.Name = "lb_y_spline_xn_info";
            this.lb_y_spline_xn_info.Size = new System.Drawing.Size(489, 55);
            this.lb_y_spline_xn_info.TabIndex = 8;
            this.lb_y_spline_xn_info.Text = "Вычисленное значение Y (сплайн 0 и xn):";
            // 
            // lb_y_newton_info
            // 
            this.lb_y_newton_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_y_newton_info.Location = new System.Drawing.Point(6, 256);
            this.lb_y_newton_info.Name = "lb_y_newton_info";
            this.lb_y_newton_info.Size = new System.Drawing.Size(489, 55);
            this.lb_y_newton_info.TabIndex = 7;
            this.lb_y_newton_info.Text = "Вычисленное значение Y (ньютон):";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkbox_spline_x0xn);
            this.groupBox3.Controls.Add(this.checkbox_spline_0xn);
            this.groupBox3.Controls.Add(this.dots_checkbox);
            this.groupBox3.Controls.Add(this.checkbox_newton);
            this.groupBox3.Controls.Add(this.checkbox_spline);
            this.groupBox3.Location = new System.Drawing.Point(768, 462);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(106, 157);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Графики";
            // 
            // checkbox_spline_x0xn
            // 
            this.checkbox_spline_x0xn.AutoSize = true;
            this.checkbox_spline_x0xn.Checked = true;
            this.checkbox_spline_x0xn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_spline_x0xn.Location = new System.Drawing.Point(6, 65);
            this.checkbox_spline_x0xn.Name = "checkbox_spline_x0xn";
            this.checkbox_spline_x0xn.Size = new System.Drawing.Size(72, 17);
            this.checkbox_spline_x0xn.TabIndex = 4;
            this.checkbox_spline_x0xn.Text = "Сплайн 2";
            this.checkbox_spline_x0xn.UseVisualStyleBackColor = true;
            this.checkbox_spline_x0xn.CheckedChanged += new System.EventHandler(this.checkbox_spline_x0xn_CheckedChanged);
            // 
            // checkbox_spline_0xn
            // 
            this.checkbox_spline_0xn.AutoSize = true;
            this.checkbox_spline_0xn.Checked = true;
            this.checkbox_spline_0xn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_spline_0xn.Location = new System.Drawing.Point(6, 42);
            this.checkbox_spline_0xn.Name = "checkbox_spline_0xn";
            this.checkbox_spline_0xn.Size = new System.Drawing.Size(72, 17);
            this.checkbox_spline_0xn.TabIndex = 3;
            this.checkbox_spline_0xn.Text = "Сплайн 1";
            this.checkbox_spline_0xn.UseVisualStyleBackColor = true;
            this.checkbox_spline_0xn.CheckedChanged += new System.EventHandler(this.checkbox_spline_0xn_CheckedChanged);
            // 
            // dots_checkbox
            // 
            this.dots_checkbox.AutoSize = true;
            this.dots_checkbox.Checked = true;
            this.dots_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dots_checkbox.Location = new System.Drawing.Point(6, 111);
            this.dots_checkbox.Name = "dots_checkbox";
            this.dots_checkbox.Size = new System.Drawing.Size(56, 17);
            this.dots_checkbox.TabIndex = 2;
            this.dots_checkbox.Text = "Точки";
            this.dots_checkbox.UseVisualStyleBackColor = true;
            this.dots_checkbox.CheckedChanged += new System.EventHandler(this.dots_checkbox_CheckedChanged);
            // 
            // checkbox_newton
            // 
            this.checkbox_newton.AutoSize = true;
            this.checkbox_newton.Checked = true;
            this.checkbox_newton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_newton.Location = new System.Drawing.Point(6, 88);
            this.checkbox_newton.Name = "checkbox_newton";
            this.checkbox_newton.Size = new System.Drawing.Size(65, 17);
            this.checkbox_newton.TabIndex = 1;
            this.checkbox_newton.Text = "Ньютон";
            this.checkbox_newton.UseVisualStyleBackColor = true;
            this.checkbox_newton.CheckedChanged += new System.EventHandler(this.checkbox_newton_CheckedChanged);
            // 
            // checkbox_spline
            // 
            this.checkbox_spline.AutoSize = true;
            this.checkbox_spline.Checked = true;
            this.checkbox_spline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_spline.Location = new System.Drawing.Point(6, 19);
            this.checkbox_spline.Name = "checkbox_spline";
            this.checkbox_spline.Size = new System.Drawing.Size(72, 17);
            this.checkbox_spline.TabIndex = 0;
            this.checkbox_spline.Text = "Сплайн 0";
            this.checkbox_spline.UseVisualStyleBackColor = true;
            this.checkbox_spline.CheckedChanged += new System.EventHandler(this.checkbox_spline_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 640);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pointTable);
            this.Controls.Add(this.mainChart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.DataGridView pointTable;
        private System.Windows.Forms.Button btn_spline;
        private System.Windows.Forms.TextBox x_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_y_spline_info;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_newton;
        private System.Windows.Forms.Label lb_y_newton_info;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkbox_newton;
        private System.Windows.Forms.CheckBox checkbox_spline;
        private System.Windows.Forms.CheckBox dots_checkbox;
        private System.Windows.Forms.CheckBox checkbox_spline_x0xn;
        private System.Windows.Forms.CheckBox checkbox_spline_0xn;
        private System.Windows.Forms.Label lb_y_spline_xn_info;
        private System.Windows.Forms.Label lb_y_spline_x0xn_info;
    }
}

