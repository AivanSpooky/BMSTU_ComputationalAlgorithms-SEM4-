namespace lab_03
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Arction.WinForms.Charting.LightningChart.ThemeBasics themeBasics1 = new Arction.WinForms.Charting.LightningChart.ThemeBasics();
            Arction.WinForms.Charting.LightningChart.Wall3DColors wall3DColors1 = new Arction.WinForms.Charting.LightningChart.Wall3DColors();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.u_label = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tb_z = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_y = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_x = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.tb_nz = new System.Windows.Forms.TextBox();
            this.rb_z_spline = new System.Windows.Forms.RadioButton();
            this.rb_z_newton = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tb_nx = new System.Windows.Forms.TextBox();
            this.rb_x_spline = new System.Windows.Forms.RadioButton();
            this.rb_x_newton = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tb_ny = new System.Windows.Forms.TextBox();
            this.rb_y_spline = new System.Windows.Forms.RadioButton();
            this.rb_y_newton = new System.Windows.Forms.RadioButton();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.tb_cur_z = new System.Windows.Forms.TextBox();
            this.lightningChart = new Arction.WinForms.Charting.LightningChart();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.btn_plot_all = new System.Windows.Forms.Button();
            this.btn_plot_z = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.u_label);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(1190, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 326);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Нахождение значения";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Найти U";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // u_label
            // 
            this.u_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.u_label.Location = new System.Drawing.Point(9, 249);
            this.u_label.Name = "u_label";
            this.u_label.Size = new System.Drawing.Size(173, 74);
            this.u_label.TabIndex = 2;
            this.u_label.Text = "u = f(x, y, z) =";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tb_z);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(6, 141);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(182, 52);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Z:";
            // 
            // tb_z
            // 
            this.tb_z.Location = new System.Drawing.Point(6, 21);
            this.tb_z.Name = "tb_z";
            this.tb_z.Size = new System.Drawing.Size(170, 22);
            this.tb_z.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tb_y);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(6, 83);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(182, 52);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Y:";
            // 
            // tb_y
            // 
            this.tb_y.Location = new System.Drawing.Point(6, 21);
            this.tb_y.Name = "tb_y";
            this.tb_y.Size = new System.Drawing.Size(170, 22);
            this.tb_y.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_x);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(6, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 52);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "X:";
            // 
            // tb_x
            // 
            this.tb_x.Location = new System.Drawing.Point(6, 21);
            this.tb_x.Name = "tb_x";
            this.tb_x.Size = new System.Drawing.Size(170, 22);
            this.tb_x.TabIndex = 3;
            this.tb_x.TextChanged += new System.EventHandler(this.tb_x_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox10);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.groupBox8);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(1390, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 441);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Выбор интерполяции";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.groupBox11);
            this.groupBox10.Controls.Add(this.rb_z_spline);
            this.groupBox10.Controls.Add(this.rb_z_newton);
            this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox10.Location = new System.Drawing.Point(6, 253);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(188, 106);
            this.groupBox10.TabIndex = 5;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Z:";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.tb_nz);
            this.groupBox11.Location = new System.Drawing.Point(6, 52);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(176, 47);
            this.groupBox11.TabIndex = 4;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "nz:";
            // 
            // tb_nz
            // 
            this.tb_nz.Location = new System.Drawing.Point(6, 18);
            this.tb_nz.Name = "tb_nz";
            this.tb_nz.Size = new System.Drawing.Size(164, 22);
            this.tb_nz.TabIndex = 4;
            // 
            // rb_z_spline
            // 
            this.rb_z_spline.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_z_spline.Location = new System.Drawing.Point(103, 22);
            this.rb_z_spline.Name = "rb_z_spline";
            this.rb_z_spline.Size = new System.Drawing.Size(79, 24);
            this.rb_z_spline.TabIndex = 4;
            this.rb_z_spline.Text = "Spline";
            this.rb_z_spline.UseVisualStyleBackColor = true;
            this.rb_z_spline.CheckedChanged += new System.EventHandler(this.rb_z_spline_CheckedChanged);
            // 
            // rb_z_newton
            // 
            this.rb_z_newton.Checked = true;
            this.rb_z_newton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_z_newton.Location = new System.Drawing.Point(6, 22);
            this.rb_z_newton.Name = "rb_z_newton";
            this.rb_z_newton.Size = new System.Drawing.Size(79, 24);
            this.rb_z_newton.TabIndex = 3;
            this.rb_z_newton.TabStop = true;
            this.rb_z_newton.Text = "Newton";
            this.rb_z_newton.UseVisualStyleBackColor = true;
            this.rb_z_newton.CheckedChanged += new System.EventHandler(this.rb_z_newton_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Controls.Add(this.rb_x_spline);
            this.groupBox6.Controls.Add(this.rb_x_newton);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox6.Location = new System.Drawing.Point(6, 25);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(188, 106);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "X:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tb_nx);
            this.groupBox7.Location = new System.Drawing.Point(6, 52);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(176, 47);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "nx:";
            // 
            // tb_nx
            // 
            this.tb_nx.Location = new System.Drawing.Point(6, 18);
            this.tb_nx.Name = "tb_nx";
            this.tb_nx.Size = new System.Drawing.Size(164, 22);
            this.tb_nx.TabIndex = 4;
            // 
            // rb_x_spline
            // 
            this.rb_x_spline.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_x_spline.Location = new System.Drawing.Point(103, 22);
            this.rb_x_spline.Name = "rb_x_spline";
            this.rb_x_spline.Size = new System.Drawing.Size(79, 24);
            this.rb_x_spline.TabIndex = 4;
            this.rb_x_spline.Text = "Spline";
            this.rb_x_spline.UseVisualStyleBackColor = true;
            this.rb_x_spline.CheckedChanged += new System.EventHandler(this.rb_x_spline_CheckedChanged);
            // 
            // rb_x_newton
            // 
            this.rb_x_newton.Checked = true;
            this.rb_x_newton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_x_newton.Location = new System.Drawing.Point(6, 22);
            this.rb_x_newton.Name = "rb_x_newton";
            this.rb_x_newton.Size = new System.Drawing.Size(79, 24);
            this.rb_x_newton.TabIndex = 3;
            this.rb_x_newton.TabStop = true;
            this.rb_x_newton.Text = "Newton";
            this.rb_x_newton.UseVisualStyleBackColor = true;
            this.rb_x_newton.CheckedChanged += new System.EventHandler(this.rb_x_newton_CheckedChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.groupBox9);
            this.groupBox8.Controls.Add(this.rb_y_spline);
            this.groupBox8.Controls.Add(this.rb_y_newton);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox8.Location = new System.Drawing.Point(6, 141);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(188, 106);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Y:";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.tb_ny);
            this.groupBox9.Location = new System.Drawing.Point(6, 52);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(176, 47);
            this.groupBox9.TabIndex = 4;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "ny:";
            // 
            // tb_ny
            // 
            this.tb_ny.Location = new System.Drawing.Point(6, 18);
            this.tb_ny.Name = "tb_ny";
            this.tb_ny.Size = new System.Drawing.Size(164, 22);
            this.tb_ny.TabIndex = 4;
            // 
            // rb_y_spline
            // 
            this.rb_y_spline.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_y_spline.Location = new System.Drawing.Point(103, 22);
            this.rb_y_spline.Name = "rb_y_spline";
            this.rb_y_spline.Size = new System.Drawing.Size(79, 24);
            this.rb_y_spline.TabIndex = 4;
            this.rb_y_spline.Text = "Spline";
            this.rb_y_spline.UseVisualStyleBackColor = true;
            this.rb_y_spline.CheckedChanged += new System.EventHandler(this.rb_y_spline_CheckedChanged);
            // 
            // rb_y_newton
            // 
            this.rb_y_newton.Checked = true;
            this.rb_y_newton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_y_newton.Location = new System.Drawing.Point(6, 22);
            this.rb_y_newton.Name = "rb_y_newton";
            this.rb_y_newton.Size = new System.Drawing.Size(79, 24);
            this.rb_y_newton.TabIndex = 3;
            this.rb_y_newton.TabStop = true;
            this.rb_y_newton.Text = "Newton";
            this.rb_y_newton.UseVisualStyleBackColor = true;
            this.rb_y_newton.CheckedChanged += new System.EventHandler(this.rb_y_newton_CheckedChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.tb_cur_z);
            this.groupBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox12.Location = new System.Drawing.Point(6, 25);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(182, 52);
            this.groupBox12.TabIndex = 4;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Z:";
            // 
            // tb_cur_z
            // 
            this.tb_cur_z.Location = new System.Drawing.Point(6, 21);
            this.tb_cur_z.Name = "tb_cur_z";
            this.tb_cur_z.Size = new System.Drawing.Size(170, 22);
            this.tb_cur_z.TabIndex = 3;
            // 
            // lightningChart
            // 
            this.lightningChart.ActiveView = Arction.WinForms.Charting.ActiveView.View3D;
            this.lightningChart.BackColor = System.Drawing.Color.Gray;
            this.lightningChart.Background = ((Arction.WinForms.Charting.Fill)(resources.GetObject("lightningChart.Background")));
            this.lightningChart.ChartManager = null;
            themeBasics1.AlphaLevel = 127;
            themeBasics1.AnnotationBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            themeBasics1.AnnotationTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            themeBasics1.AxisColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(231)))), ((int)(((byte)(21)))));
            themeBasics1.AxisLabelColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(231)))), ((int)(((byte)(21)))));
            themeBasics1.AxisTitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(231)))), ((int)(((byte)(21)))));
            themeBasics1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            themeBasics1.BackgroundGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            themeBasics1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            themeBasics1.ChartTitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            themeBasics1.ColorSaturation = 1D;
            themeBasics1.ColorStrength = 1D;
            themeBasics1.ColorToGradient = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            themeBasics1.CustomDynamicBackgroundImage = null;
            themeBasics1.CustomPalette = ((Arction.WinForms.Charting.ValueRangePalette)(resources.GetObject("themeBasics1.CustomPalette")));
            themeBasics1.customPaletteSteps = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(42))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(191)))))};
            themeBasics1.darkLightBlendColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            themeBasics1.DataCursorResultTableTextColor = System.Drawing.Color.White;
            themeBasics1.DynamicBackgroundFillStyle = Arction.WinForms.Charting.RectFillStyle.ColorOverBitmap;
            themeBasics1.DynamicBackgroundImage = Arction.WinForms.Charting.DynamicBackgroundImage.BrickWall;
            themeBasics1.DynamicBackgroundLayout = Arction.WinForms.Charting.BitmapFillLayout.Tile;
            themeBasics1.ForceLabelsWhite = false;
            themeBasics1.GradientStrength = 35D;
            themeBasics1.GraphBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            themeBasics1.GraphBackgroundGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            themeBasics1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            themeBasics1.LegendFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            themeBasics1.LegendFillGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            themeBasics1.LegendTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            themeBasics1.MarkerSingleColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(30)))));
            themeBasics1.MasterHueDeg = 30D;
            themeBasics1.MultiColorAxis = true;
            themeBasics1.MultiColorSeries = true;
            themeBasics1.ScrollBarBackgroundFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(95)))), ((int)(((byte)(0)))));
            themeBasics1.ScrollBarFrontFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(63)))));
            themeBasics1.SectorSingleColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            themeBasics1.SliceHueStep = 23;
            wall3DColors1.Ambient = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            wall3DColors1.Diffuse = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            wall3DColors1.Emissive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            wall3DColors1.GridStrip1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            wall3DColors1.GridStrip2 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            wall3DColors1.Specular = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            wall3DColors1.SpecularPower = 5D;
            themeBasics1.View3DWallsColoring = wall3DColors1;
            themeBasics1.ZoomRectcolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lightningChart.CustomDynamicTheme = themeBasics1;
            this.lightningChart.Location = new System.Drawing.Point(12, 8);
            this.lightningChart.MinimumSize = new System.Drawing.Size(110, 90);
            this.lightningChart.Name = "lightningChart";
            this.lightningChart.Options = ((Arction.WinForms.Charting.ChartOptions)(resources.GetObject("lightningChart.Options")));
            this.lightningChart.OutputStream = null;
            this.lightningChart.RenderOptions = ((Arction.WinForms.Charting.Views.RenderOptionsCommon)(resources.GetObject("lightningChart.RenderOptions")));
            this.lightningChart.Size = new System.Drawing.Size(1172, 922);
            this.lightningChart.TabIndex = 5;
            this.lightningChart.Title = ((Arction.WinForms.Charting.Titles.ChartTitle)(resources.GetObject("lightningChart.Title")));
            this.lightningChart.View3D = ((Arction.WinForms.Charting.Views.View3D.View3D)(resources.GetObject("lightningChart.View3D")));
            this.lightningChart.ViewPie3D = ((Arction.WinForms.Charting.Views.ViewPie3D.ViewPie3D)(resources.GetObject("lightningChart.ViewPie3D")));
            this.lightningChart.ViewPolar = ((Arction.WinForms.Charting.Views.ViewPolar.ViewPolar)(resources.GetObject("lightningChart.ViewPolar")));
            this.lightningChart.ViewSmith = ((Arction.WinForms.Charting.Views.ViewSmith.ViewSmith)(resources.GetObject("lightningChart.ViewSmith")));
            this.lightningChart.ViewXY = ((Arction.WinForms.Charting.Views.ViewXY.ViewXY)(resources.GetObject("lightningChart.ViewXY")));
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.btn_plot_all);
            this.groupBox13.Controls.Add(this.btn_plot_z);
            this.groupBox13.Controls.Add(this.groupBox12);
            this.groupBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox13.Location = new System.Drawing.Point(1190, 343);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(194, 185);
            this.groupBox13.TabIndex = 6;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Настройки графика";
            // 
            // btn_plot_all
            // 
            this.btn_plot_all.Location = new System.Drawing.Point(6, 139);
            this.btn_plot_all.Name = "btn_plot_all";
            this.btn_plot_all.Size = new System.Drawing.Size(182, 40);
            this.btn_plot_all.TabIndex = 8;
            this.btn_plot_all.Text = "Нарисовать все";
            this.btn_plot_all.UseVisualStyleBackColor = true;
            this.btn_plot_all.Click += new System.EventHandler(this.btn_plot_all_Click);
            // 
            // btn_plot_z
            // 
            this.btn_plot_z.Location = new System.Drawing.Point(6, 83);
            this.btn_plot_z.Name = "btn_plot_z";
            this.btn_plot_z.Size = new System.Drawing.Size(182, 40);
            this.btn_plot_z.TabIndex = 7;
            this.btn_plot_z.Text = "Нарисовать для Z";
            this.btn_plot_z.UseVisualStyleBackColor = true;
            this.btn_plot_z.Click += new System.EventHandler(this.btn_plot_z_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1597, 942);
            this.Controls.Add(this.groupBox13);
            this.Controls.Add(this.lightningChart);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label u_label;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tb_z;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tb_y;
        private System.Windows.Forms.TextBox tb_x;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rb_x_spline;
        private System.Windows.Forms.RadioButton rb_x_newton;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox tb_nz;
        private System.Windows.Forms.RadioButton rb_z_spline;
        private System.Windows.Forms.RadioButton rb_z_newton;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox tb_nx;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox tb_ny;
        private System.Windows.Forms.RadioButton rb_y_spline;
        private System.Windows.Forms.RadioButton rb_y_newton;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.TextBox tb_cur_z;
        private System.Windows.Forms.Button button1;
        private Arction.WinForms.Charting.LightningChart lightningChart;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Button btn_plot_all;
        private System.Windows.Forms.Button btn_plot_z;
    }
}

