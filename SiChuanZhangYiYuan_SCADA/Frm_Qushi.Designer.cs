
namespace SiChuanZhangYiYuan_SCADA
{
    partial class Frm_Qushi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SeeSharpTools.JY.GUI.StripChartXSeries stripChartXSeries4 = new SeeSharpTools.JY.GUI.StripChartXSeries();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_PLC_Connect = new System.Windows.Forms.Label();
            this.pcb_PLC_Connect = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_WX = new System.Windows.Forms.Label();
            this.lbl_week = new System.Windows.Forms.Label();
            this.lbl_QX = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_timeweek = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.chart_Trend = new SeeSharpTools.JY.GUI.StripChartX();
            this.ckb_LP1_Speed = new System.Windows.Forms.CheckBox();
            this.ckb_SL1_Speed = new System.Windows.Forms.CheckBox();
            this.ckb_SL2_Speed = new System.Windows.Forms.CheckBox();
            this.ckb_XG5_Speed = new System.Windows.Forms.CheckBox();
            this.ckb_TB6_Speed = new System.Windows.Forms.CheckBox();
            this.ckb_ZH7_Speed = new System.Windows.Forms.CheckBox();
            this.lbl_QX_qh = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_PLC_Connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(67)))), ((int)(((byte)(123)))));
            this.label3.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(766, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 35);
            this.label3.TabIndex = 14;
            this.label3.Text = "趋势查看";
            // 
            // lbl_PLC_Connect
            // 
            this.lbl_PLC_Connect.AutoSize = true;
            this.lbl_PLC_Connect.BackColor = System.Drawing.Color.Transparent;
            this.lbl_PLC_Connect.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_PLC_Connect.ForeColor = System.Drawing.Color.White;
            this.lbl_PLC_Connect.Location = new System.Drawing.Point(1553, 33);
            this.lbl_PLC_Connect.Name = "lbl_PLC_Connect";
            this.lbl_PLC_Connect.Size = new System.Drawing.Size(135, 24);
            this.lbl_PLC_Connect.TabIndex = 13;
            this.lbl_PLC_Connect.Text = "系统已连接";
            // 
            // pcb_PLC_Connect
            // 
            this.pcb_PLC_Connect.BackColor = System.Drawing.Color.Transparent;
            this.pcb_PLC_Connect.Image = global::SiChuanZhangYiYuan_SCADA.Properties.Resources.system_status_06_1;
            this.pcb_PLC_Connect.Location = new System.Drawing.Point(1496, 22);
            this.pcb_PLC_Connect.Name = "pcb_PLC_Connect";
            this.pcb_PLC_Connect.Size = new System.Drawing.Size(51, 45);
            this.pcb_PLC_Connect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcb_PLC_Connect.TabIndex = 12;
            this.pcb_PLC_Connect.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::SiChuanZhangYiYuan_SCADA.Properties.Resources.nav_03;
            this.pictureBox1.Location = new System.Drawing.Point(536, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(628, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_WX
            // 
            this.lbl_WX.AutoSize = true;
            this.lbl_WX.BackColor = System.Drawing.Color.Transparent;
            this.lbl_WX.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_WX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(51)))), ((int)(((byte)(2)))));
            this.lbl_WX.Location = new System.Drawing.Point(1181, 16);
            this.lbl_WX.Name = "lbl_WX";
            this.lbl_WX.Size = new System.Drawing.Size(309, 56);
            this.lbl_WX.TabIndex = 83;
            this.lbl_WX.Text = "网络有问题";
            this.lbl_WX.Visible = false;
            // 
            // lbl_week
            // 
            this.lbl_week.AutoSize = true;
            this.lbl_week.BackColor = System.Drawing.Color.Transparent;
            this.lbl_week.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_week.ForeColor = System.Drawing.Color.White;
            this.lbl_week.Location = new System.Drawing.Point(322, 13);
            this.lbl_week.Name = "lbl_week";
            this.lbl_week.Size = new System.Drawing.Size(103, 29);
            this.lbl_week.TabIndex = 93;
            this.lbl_week.Text = "星期一";
            // 
            // lbl_QX
            // 
            this.lbl_QX.AutoSize = true;
            this.lbl_QX.BackColor = System.Drawing.Color.Transparent;
            this.lbl_QX.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_QX.ForeColor = System.Drawing.Color.White;
            this.lbl_QX.Location = new System.Drawing.Point(114, 17);
            this.lbl_QX.Name = "lbl_QX";
            this.lbl_QX.Size = new System.Drawing.Size(103, 29);
            this.lbl_QX.TabIndex = 92;
            this.lbl_QX.Text = "操作员";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 35);
            this.label1.TabIndex = 91;
            this.label1.Text = "权限:";
            // 
            // lbl_timeweek
            // 
            this.lbl_timeweek.AutoSize = true;
            this.lbl_timeweek.BackColor = System.Drawing.Color.Transparent;
            this.lbl_timeweek.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_timeweek.ForeColor = System.Drawing.Color.White;
            this.lbl_timeweek.Location = new System.Drawing.Point(213, 58);
            this.lbl_timeweek.Name = "lbl_timeweek";
            this.lbl_timeweek.Size = new System.Drawing.Size(317, 29);
            this.lbl_timeweek.TabIndex = 90;
            this.lbl_timeweek.Text = "2022/11/16 12:12:12";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::SiChuanZhangYiYuan_SCADA.Properties.Resources.main_bg_03;
            this.pictureBox2.Location = new System.Drawing.Point(12, 108);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1676, 688);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 94;
            this.pictureBox2.TabStop = false;
            // 
            // chart_Trend
            // 
            this.chart_Trend.AxisX.AutoScale = false;
            this.chart_Trend.AxisX.AutoZoomReset = false;
            this.chart_Trend.AxisX.Color = System.Drawing.Color.Black;
            this.chart_Trend.AxisX.InitWithScaleView = false;
            this.chart_Trend.AxisX.IsLogarithmic = false;
            this.chart_Trend.AxisX.LabelAngle = 0;
            this.chart_Trend.AxisX.LabelEnabled = true;
            this.chart_Trend.AxisX.LabelFormat = null;
            this.chart_Trend.AxisX.MajorGridColor = System.Drawing.Color.Black;
            this.chart_Trend.AxisX.MajorGridCount = 6;
            this.chart_Trend.AxisX.MajorGridEnabled = true;
            this.chart_Trend.AxisX.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_Trend.AxisX.Maximum = 1000D;
            this.chart_Trend.AxisX.Minimum = 0D;
            this.chart_Trend.AxisX.MinorGridColor = System.Drawing.Color.Black;
            this.chart_Trend.AxisX.MinorGridEnabled = false;
            this.chart_Trend.AxisX.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_Trend.AxisX.TickWidth = 1F;
            this.chart_Trend.AxisX.Title = "";
            this.chart_Trend.AxisX.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_Trend.AxisX.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_Trend.AxisX.ViewMaximum = 1000D;
            this.chart_Trend.AxisX.ViewMinimum = 0D;
            this.chart_Trend.AxisX2.AutoScale = false;
            this.chart_Trend.AxisX2.AutoZoomReset = false;
            this.chart_Trend.AxisX2.Color = System.Drawing.Color.Black;
            this.chart_Trend.AxisX2.InitWithScaleView = false;
            this.chart_Trend.AxisX2.IsLogarithmic = false;
            this.chart_Trend.AxisX2.LabelAngle = 0;
            this.chart_Trend.AxisX2.LabelEnabled = true;
            this.chart_Trend.AxisX2.LabelFormat = null;
            this.chart_Trend.AxisX2.MajorGridColor = System.Drawing.Color.Black;
            this.chart_Trend.AxisX2.MajorGridCount = 6;
            this.chart_Trend.AxisX2.MajorGridEnabled = true;
            this.chart_Trend.AxisX2.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_Trend.AxisX2.Maximum = 1000D;
            this.chart_Trend.AxisX2.Minimum = 0D;
            this.chart_Trend.AxisX2.MinorGridColor = System.Drawing.Color.Black;
            this.chart_Trend.AxisX2.MinorGridEnabled = false;
            this.chart_Trend.AxisX2.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_Trend.AxisX2.TickWidth = 1F;
            this.chart_Trend.AxisX2.Title = "";
            this.chart_Trend.AxisX2.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_Trend.AxisX2.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_Trend.AxisX2.ViewMaximum = 1000D;
            this.chart_Trend.AxisX2.ViewMinimum = 0D;
            this.chart_Trend.AxisY.AutoScale = true;
            this.chart_Trend.AxisY.AutoZoomReset = false;
            this.chart_Trend.AxisY.Color = System.Drawing.Color.Black;
            this.chart_Trend.AxisY.InitWithScaleView = false;
            this.chart_Trend.AxisY.IsLogarithmic = false;
            this.chart_Trend.AxisY.LabelAngle = 0;
            this.chart_Trend.AxisY.LabelEnabled = true;
            this.chart_Trend.AxisY.LabelFormat = null;
            this.chart_Trend.AxisY.MajorGridColor = System.Drawing.Color.Black;
            this.chart_Trend.AxisY.MajorGridCount = 6;
            this.chart_Trend.AxisY.MajorGridEnabled = true;
            this.chart_Trend.AxisY.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_Trend.AxisY.Maximum = 3.5D;
            this.chart_Trend.AxisY.Minimum = 0.5D;
            this.chart_Trend.AxisY.MinorGridColor = System.Drawing.Color.Black;
            this.chart_Trend.AxisY.MinorGridEnabled = false;
            this.chart_Trend.AxisY.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_Trend.AxisY.TickWidth = 1F;
            this.chart_Trend.AxisY.Title = "";
            this.chart_Trend.AxisY.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_Trend.AxisY.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_Trend.AxisY.ViewMaximum = 3.5D;
            this.chart_Trend.AxisY.ViewMinimum = 0.5D;
            this.chart_Trend.AxisY2.AutoScale = true;
            this.chart_Trend.AxisY2.AutoZoomReset = false;
            this.chart_Trend.AxisY2.Color = System.Drawing.Color.Black;
            this.chart_Trend.AxisY2.InitWithScaleView = false;
            this.chart_Trend.AxisY2.IsLogarithmic = false;
            this.chart_Trend.AxisY2.LabelAngle = 0;
            this.chart_Trend.AxisY2.LabelEnabled = true;
            this.chart_Trend.AxisY2.LabelFormat = null;
            this.chart_Trend.AxisY2.MajorGridColor = System.Drawing.Color.Black;
            this.chart_Trend.AxisY2.MajorGridCount = 6;
            this.chart_Trend.AxisY2.MajorGridEnabled = true;
            this.chart_Trend.AxisY2.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_Trend.AxisY2.Maximum = 3.5D;
            this.chart_Trend.AxisY2.Minimum = 0.5D;
            this.chart_Trend.AxisY2.MinorGridColor = System.Drawing.Color.Black;
            this.chart_Trend.AxisY2.MinorGridEnabled = false;
            this.chart_Trend.AxisY2.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_Trend.AxisY2.TickWidth = 1F;
            this.chart_Trend.AxisY2.Title = "";
            this.chart_Trend.AxisY2.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_Trend.AxisY2.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_Trend.AxisY2.ViewMaximum = 3.5D;
            this.chart_Trend.AxisY2.ViewMinimum = 0.5D;
            this.chart_Trend.BackColor = System.Drawing.Color.Transparent;
            this.chart_Trend.ChartAreaBackColor = System.Drawing.Color.White;
            this.chart_Trend.Direction = SeeSharpTools.JY.GUI.StripChartX.ScrollDirection.LeftToRight;
            this.chart_Trend.DisplayPoints = 4000;
            this.chart_Trend.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chart_Trend.ForeColor = System.Drawing.Color.White;
            this.chart_Trend.GradientStyle = SeeSharpTools.JY.GUI.StripChartX.ChartGradientStyle.None;
            this.chart_Trend.LegendBackColor = System.Drawing.Color.Transparent;
            this.chart_Trend.LegendFont = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chart_Trend.LegendForeColor = System.Drawing.Color.White;
            this.chart_Trend.LegendVisible = true;
            stripChartXSeries4.Color = System.Drawing.Color.Red;
            stripChartXSeries4.Marker = SeeSharpTools.JY.GUI.StripChartXSeries.MarkerType.None;
            stripChartXSeries4.Name = "Series1";
            stripChartXSeries4.Type = SeeSharpTools.JY.GUI.StripChartXSeries.LineType.FastLine;
            stripChartXSeries4.Visible = true;
            stripChartXSeries4.Width = SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Thin;
            stripChartXSeries4.XPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            stripChartXSeries4.YPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            this.chart_Trend.LineSeries.Add(stripChartXSeries4);
            this.chart_Trend.Location = new System.Drawing.Point(30, 130);
            this.chart_Trend.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.chart_Trend.Miscellaneous.CheckInfinity = false;
            this.chart_Trend.Miscellaneous.CheckNaN = false;
            this.chart_Trend.Miscellaneous.CheckNegtiveOrZero = false;
            this.chart_Trend.Miscellaneous.DirectionChartCount = 3;
            this.chart_Trend.Miscellaneous.Fitting = SeeSharpTools.JY.GUI.StripChartX.FitType.Range;
            this.chart_Trend.Miscellaneous.MaxSeriesCount = 32;
            this.chart_Trend.Miscellaneous.MaxSeriesPointCount = 4000;
            this.chart_Trend.Miscellaneous.SplitLayoutColumnInterval = 0F;
            this.chart_Trend.Miscellaneous.SplitLayoutDirection = SeeSharpTools.JY.GUI.StripChartXUtility.LayoutDirection.LeftToRight;
            this.chart_Trend.Miscellaneous.SplitLayoutRowInterval = 0F;
            this.chart_Trend.Miscellaneous.SplitViewAutoLayout = true;
            this.chart_Trend.Name = "chart_Trend";
            this.chart_Trend.NextTimeStamp = new System.DateTime(((long)(0)));
            this.chart_Trend.ScrollType = SeeSharpTools.JY.GUI.StripChartX.StripScrollType.Cumulation;
            this.chart_Trend.SeriesCount = 1;
            this.chart_Trend.Size = new System.Drawing.Size(1643, 640);
            this.chart_Trend.SplitView = false;
            this.chart_Trend.StartIndex = 0;
            this.chart_Trend.TabIndex = 95;
            this.chart_Trend.TimeInterval = System.TimeSpan.Parse("00:00:00");
            this.chart_Trend.TimeStampFormat = null;
            this.chart_Trend.XCursor.AutoInterval = true;
            this.chart_Trend.XCursor.Color = System.Drawing.Color.DeepSkyBlue;
            this.chart_Trend.XCursor.Interval = 0.001D;
            this.chart_Trend.XCursor.Mode = SeeSharpTools.JY.GUI.StripChartXCursor.CursorMode.Zoom;
            this.chart_Trend.XCursor.SelectionColor = System.Drawing.Color.LightGray;
            this.chart_Trend.XCursor.Value = double.NaN;
            this.chart_Trend.XDataType = SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.Index;
            this.chart_Trend.YCursor.AutoInterval = true;
            this.chart_Trend.YCursor.Color = System.Drawing.Color.DeepSkyBlue;
            this.chart_Trend.YCursor.Interval = 0.001D;
            this.chart_Trend.YCursor.Mode = SeeSharpTools.JY.GUI.StripChartXCursor.CursorMode.Disabled;
            this.chart_Trend.YCursor.SelectionColor = System.Drawing.Color.LightGray;
            this.chart_Trend.YCursor.Value = double.NaN;
            // 
            // ckb_LP1_Speed
            // 
            this.ckb_LP1_Speed.AutoSize = true;
            this.ckb_LP1_Speed.BackColor = System.Drawing.Color.Transparent;
            this.ckb_LP1_Speed.Checked = true;
            this.ckb_LP1_Speed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_LP1_Speed.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_LP1_Speed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ckb_LP1_Speed.Location = new System.Drawing.Point(1408, 447);
            this.ckb_LP1_Speed.Name = "ckb_LP1_Speed";
            this.ckb_LP1_Speed.Size = new System.Drawing.Size(250, 33);
            this.ckb_LP1_Speed.TabIndex = 96;
            this.ckb_LP1_Speed.Text = "显示理瓶机-产速";
            this.ckb_LP1_Speed.UseVisualStyleBackColor = false;
            this.ckb_LP1_Speed.CheckedChanged += new System.EventHandler(this.ckb_LP1_Speed_CheckedChanged);
            // 
            // ckb_SL1_Speed
            // 
            this.ckb_SL1_Speed.AutoSize = true;
            this.ckb_SL1_Speed.BackColor = System.Drawing.Color.Transparent;
            this.ckb_SL1_Speed.Checked = true;
            this.ckb_SL1_Speed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_SL1_Speed.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_SL1_Speed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ckb_SL1_Speed.Location = new System.Drawing.Point(1408, 486);
            this.ckb_SL1_Speed.Name = "ckb_SL1_Speed";
            this.ckb_SL1_Speed.Size = new System.Drawing.Size(265, 33);
            this.ckb_SL1_Speed.TabIndex = 97;
            this.ckb_SL1_Speed.Text = "显示数粒机1-产速";
            this.ckb_SL1_Speed.UseVisualStyleBackColor = false;
            this.ckb_SL1_Speed.CheckedChanged += new System.EventHandler(this.ckb_SL1_Speed_CheckedChanged);
            // 
            // ckb_SL2_Speed
            // 
            this.ckb_SL2_Speed.AutoSize = true;
            this.ckb_SL2_Speed.BackColor = System.Drawing.Color.Transparent;
            this.ckb_SL2_Speed.Checked = true;
            this.ckb_SL2_Speed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_SL2_Speed.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_SL2_Speed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ckb_SL2_Speed.Location = new System.Drawing.Point(1408, 525);
            this.ckb_SL2_Speed.Name = "ckb_SL2_Speed";
            this.ckb_SL2_Speed.Size = new System.Drawing.Size(265, 33);
            this.ckb_SL2_Speed.TabIndex = 98;
            this.ckb_SL2_Speed.Text = "显示数粒机2-产速";
            this.ckb_SL2_Speed.UseVisualStyleBackColor = false;
            this.ckb_SL2_Speed.CheckedChanged += new System.EventHandler(this.ckb_SL2_Speed_CheckedChanged);
            // 
            // ckb_XG5_Speed
            // 
            this.ckb_XG5_Speed.AutoSize = true;
            this.ckb_XG5_Speed.BackColor = System.Drawing.Color.Transparent;
            this.ckb_XG5_Speed.Checked = true;
            this.ckb_XG5_Speed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_XG5_Speed.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_XG5_Speed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ckb_XG5_Speed.Location = new System.Drawing.Point(1408, 564);
            this.ckb_XG5_Speed.Name = "ckb_XG5_Speed";
            this.ckb_XG5_Speed.Size = new System.Drawing.Size(250, 33);
            this.ckb_XG5_Speed.TabIndex = 99;
            this.ckb_XG5_Speed.Text = "显示旋盖机-产速";
            this.ckb_XG5_Speed.UseVisualStyleBackColor = false;
            this.ckb_XG5_Speed.CheckedChanged += new System.EventHandler(this.ckb_XG5_Speed_CheckedChanged);
            // 
            // ckb_TB6_Speed
            // 
            this.ckb_TB6_Speed.AutoSize = true;
            this.ckb_TB6_Speed.BackColor = System.Drawing.Color.Transparent;
            this.ckb_TB6_Speed.Checked = true;
            this.ckb_TB6_Speed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_TB6_Speed.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_TB6_Speed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ckb_TB6_Speed.Location = new System.Drawing.Point(1408, 603);
            this.ckb_TB6_Speed.Name = "ckb_TB6_Speed";
            this.ckb_TB6_Speed.Size = new System.Drawing.Size(250, 33);
            this.ckb_TB6_Speed.TabIndex = 100;
            this.ckb_TB6_Speed.Text = "显示贴标机-产速";
            this.ckb_TB6_Speed.UseVisualStyleBackColor = false;
            this.ckb_TB6_Speed.CheckedChanged += new System.EventHandler(this.ckb_TB6_Speed_CheckedChanged);
            // 
            // ckb_ZH7_Speed
            // 
            this.ckb_ZH7_Speed.AutoSize = true;
            this.ckb_ZH7_Speed.BackColor = System.Drawing.Color.Transparent;
            this.ckb_ZH7_Speed.Checked = true;
            this.ckb_ZH7_Speed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_ZH7_Speed.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_ZH7_Speed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ckb_ZH7_Speed.Location = new System.Drawing.Point(1408, 642);
            this.ckb_ZH7_Speed.Name = "ckb_ZH7_Speed";
            this.ckb_ZH7_Speed.Size = new System.Drawing.Size(250, 33);
            this.ckb_ZH7_Speed.TabIndex = 101;
            this.ckb_ZH7_Speed.Text = "显示装盒机-产速";
            this.ckb_ZH7_Speed.UseVisualStyleBackColor = false;
            this.ckb_ZH7_Speed.CheckedChanged += new System.EventHandler(this.ckb_ZH7_Speed_CheckedChanged);
            // 
            // lbl_QX_qh
            // 
            this.lbl_QX_qh.AutoSize = true;
            this.lbl_QX_qh.BackColor = System.Drawing.Color.Transparent;
            this.lbl_QX_qh.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_QX_qh.ForeColor = System.Drawing.Color.White;
            this.lbl_QX_qh.Location = new System.Drawing.Point(43, 58);
            this.lbl_QX_qh.Name = "lbl_QX_qh";
            this.lbl_QX_qh.Size = new System.Drawing.Size(133, 29);
            this.lbl_QX_qh.TabIndex = 107;
            this.lbl_QX_qh.Text = "切换权限";
            this.lbl_QX_qh.Click += new System.EventHandler(this.lbl_QX_qh_Click);
            // 
            // Frm_Qushi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SiChuanZhangYiYuan_SCADA.Properties.Resources.bg1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1700, 808);
            this.Controls.Add(this.lbl_QX_qh);
            this.Controls.Add(this.ckb_ZH7_Speed);
            this.Controls.Add(this.ckb_TB6_Speed);
            this.Controls.Add(this.ckb_XG5_Speed);
            this.Controls.Add(this.ckb_SL2_Speed);
            this.Controls.Add(this.ckb_SL1_Speed);
            this.Controls.Add(this.ckb_LP1_Speed);
            this.Controls.Add(this.chart_Trend);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lbl_week);
            this.Controls.Add(this.lbl_QX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_timeweek);
            this.Controls.Add(this.lbl_WX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_PLC_Connect);
            this.Controls.Add(this.pcb_PLC_Connect);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Qushi";
            this.Text = "Frm_Qushi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Qushi_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Qushi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcb_PLC_Connect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_PLC_Connect;
        private System.Windows.Forms.PictureBox pcb_PLC_Connect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_WX;
        private System.Windows.Forms.Label lbl_week;
        private System.Windows.Forms.Label lbl_QX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_timeweek;
        private System.Windows.Forms.PictureBox pictureBox2;
        private SeeSharpTools.JY.GUI.StripChartX chart_Trend;
        private System.Windows.Forms.CheckBox ckb_LP1_Speed;
        private System.Windows.Forms.CheckBox ckb_SL1_Speed;
        private System.Windows.Forms.CheckBox ckb_SL2_Speed;
        private System.Windows.Forms.CheckBox ckb_XG5_Speed;
        private System.Windows.Forms.CheckBox ckb_TB6_Speed;
        private System.Windows.Forms.CheckBox ckb_ZH7_Speed;
        private System.Windows.Forms.Label lbl_QX_qh;
    }
}