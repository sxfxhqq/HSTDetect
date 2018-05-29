namespace Client
{
    partial class CarDetect
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarDetect));
            this.chart_Speed = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Panel_Chart = new System.Windows.Forms.Panel();
            this.chart_Volumn = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.实时监控ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.路段信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.历史报警ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.历史数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.参数设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Cbo_ID = new System.Windows.Forms.ComboBox();
            this.Btn_Begin = new System.Windows.Forms.Button();
            this.Btn_FullScreen = new System.Windows.Forms.Button();
            this.LB_CamID = new System.Windows.Forms.Label();
            this.label_Chanel = new System.Windows.Forms.Label();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Btn_PTZ = new System.Windows.Forms.Button();
            this.LB_picturebox = new System.Windows.Forms.Label();
            this.LB_ServerState = new System.Windows.Forms.Label();
            this.PB_Connected = new System.Windows.Forms.PictureBox();
            this.PB_Reconnect = new System.Windows.Forms.PictureBox();
            this.PB_Unconnect = new System.Windows.Forms.PictureBox();
            this.LBstate_normal = new System.Windows.Forms.Label();
            this.LBstate_reconnect = new System.Windows.Forms.Label();
            this.LBstate_unconnect = new System.Windows.Forms.Label();
            this.Cbo_Reset = new System.Windows.Forms.CheckBox();
            this.Btn_RoiArea = new System.Windows.Forms.Button();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.Panel_Monitor = new System.Windows.Forms.Panel();
            this.PB_Monitor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Speed)).BeginInit();
            this.Panel_Chart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Volumn)).BeginInit();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Connected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Reconnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Unconnect)).BeginInit();
            this.Panel_Monitor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Monitor)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_Speed
            // 
            this.chart_Speed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chart_Speed.BackColor = System.Drawing.Color.Transparent;
            this.chart_Speed.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Maroon;
            chartArea1.AxisX.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.ScrollBar.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.ScrollBar.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Maroon;
            chartArea1.AxisY.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.OrangeRed;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.Name = "ChartArea1";
            this.chart_Speed.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chart_Speed.Legends.Add(legend1);
            this.chart_Speed.Location = new System.Drawing.Point(0, 249);
            this.chart_Speed.Name = "chart_Speed";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.OrangeRed;
            series1.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.LabelForeColor = System.Drawing.Color.Coral;
            series1.Legend = "Legend1";
            series1.Name = "客流平均速度(Km/h)";
            this.chart_Speed.Series.Add(series1);
            this.chart_Speed.Size = new System.Drawing.Size(550, 250);
            this.chart_Speed.TabIndex = 8;
            this.chart_Speed.Text = "chart1";
            // 
            // Panel_Chart
            // 
            this.Panel_Chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Chart.AutoScroll = true;
            this.Panel_Chart.BackColor = System.Drawing.Color.White;
            this.Panel_Chart.Controls.Add(this.chart_Speed);
            this.Panel_Chart.Controls.Add(this.chart_Volumn);
            this.Panel_Chart.Location = new System.Drawing.Point(646, 121);
            this.Panel_Chart.Name = "Panel_Chart";
            this.Panel_Chart.Size = new System.Drawing.Size(550, 499);
            this.Panel_Chart.TabIndex = 15;
            this.Panel_Chart.Tag = "9999";
            // 
            // chart_Volumn
            // 
            this.chart_Volumn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chart_Volumn.BackColor = System.Drawing.Color.Transparent;
            this.chart_Volumn.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Maroon;
            chartArea2.AxisX.LineColor = System.Drawing.Color.Gray;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisX.ScrollBar.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.ScrollBar.LineColor = System.Drawing.Color.Gray;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Maroon;
            chartArea2.AxisY.LineColor = System.Drawing.Color.Gray;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.BorderColor = System.Drawing.Color.DeepSkyBlue;
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.Name = "ChartArea1";
            this.chart_Volumn.ChartAreas.Add(chartArea2);
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Name = "Legend1";
            this.chart_Volumn.Legends.Add(legend2);
            this.chart_Volumn.Location = new System.Drawing.Point(0, 0);
            this.chart_Volumn.Name = "chart_Volumn";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.DeepSkyBlue;
            series2.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.LabelForeColor = System.Drawing.Color.RoyalBlue;
            series2.Legend = "Legend1";
            series2.Name = "总客流增量(人次/5秒)";
            this.chart_Volumn.Series.Add(series2);
            this.chart_Volumn.Size = new System.Drawing.Size(550, 250);
            this.chart_Volumn.TabIndex = 11;
            this.chart_Volumn.Text = "chart1";
            // 
            // MenuStrip
            // 
            this.MenuStrip.AutoSize = false;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.实时监控ToolStripMenuItem,
            this.路段信息ToolStripMenuItem,
            this.历史报警ToolStripMenuItem,
            this.历史数据ToolStripMenuItem,
            this.参数设置ToolStripMenuItem1});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1198, 55);
            this.MenuStrip.TabIndex = 16;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // 实时监控ToolStripMenuItem
            // 
            this.实时监控ToolStripMenuItem.Name = "实时监控ToolStripMenuItem";
            this.实时监控ToolStripMenuItem.Size = new System.Drawing.Size(68, 51);
            this.实时监控ToolStripMenuItem.Text = "实时监控";
            this.实时监控ToolStripMenuItem.Click += new System.EventHandler(this.实时监控ToolStripMenuItem_Click);
            // 
            // 路段信息ToolStripMenuItem
            // 
            this.路段信息ToolStripMenuItem.Name = "路段信息ToolStripMenuItem";
            this.路段信息ToolStripMenuItem.Size = new System.Drawing.Size(68, 51);
            this.路段信息ToolStripMenuItem.Text = "路段信息";
            this.路段信息ToolStripMenuItem.Click += new System.EventHandler(this.路段信息ToolStripMenuItem_Click);
            // 
            // 历史报警ToolStripMenuItem
            // 
            this.历史报警ToolStripMenuItem.Name = "历史报警ToolStripMenuItem";
            this.历史报警ToolStripMenuItem.Size = new System.Drawing.Size(68, 51);
            this.历史报警ToolStripMenuItem.Text = "历史报警";
            this.历史报警ToolStripMenuItem.Click += new System.EventHandler(this.历史报警ToolStripMenuItem_Click);
            // 
            // 历史数据ToolStripMenuItem
            // 
            this.历史数据ToolStripMenuItem.Name = "历史数据ToolStripMenuItem";
            this.历史数据ToolStripMenuItem.Size = new System.Drawing.Size(68, 51);
            this.历史数据ToolStripMenuItem.Text = "历史数据";
            this.历史数据ToolStripMenuItem.Click += new System.EventHandler(this.历史数据ToolStripMenuItem_Click);
            // 
            // 参数设置ToolStripMenuItem1
            // 
            this.参数设置ToolStripMenuItem1.Name = "参数设置ToolStripMenuItem1";
            this.参数设置ToolStripMenuItem1.Size = new System.Drawing.Size(68, 51);
            this.参数设置ToolStripMenuItem1.Text = "参数设置";
            this.参数设置ToolStripMenuItem1.Click += new System.EventHandler(this.参数设置ToolStripMenuItem1_Click);
            // 
            // Cbo_ID
            // 
            this.Cbo_ID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cbo_ID.FormattingEnabled = true;
            this.Cbo_ID.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "123"});
            this.Cbo_ID.Location = new System.Drawing.Point(416, 588);
            this.Cbo_ID.Name = "Cbo_ID";
            this.Cbo_ID.Size = new System.Drawing.Size(121, 20);
            this.Cbo_ID.TabIndex = 4;
            // 
            // Btn_Begin
            // 
            this.Btn_Begin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Begin.Location = new System.Drawing.Point(560, 588);
            this.Btn_Begin.Name = "Btn_Begin";
            this.Btn_Begin.Size = new System.Drawing.Size(75, 23);
            this.Btn_Begin.TabIndex = 5;
            this.Btn_Begin.Text = "开始监控";
            this.Btn_Begin.UseVisualStyleBackColor = true;
            this.Btn_Begin.Click += new System.EventHandler(this.Btn_Begin_Click);
            // 
            // Btn_FullScreen
            // 
            this.Btn_FullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_FullScreen.Location = new System.Drawing.Point(560, 488);
            this.Btn_FullScreen.Name = "Btn_FullScreen";
            this.Btn_FullScreen.Size = new System.Drawing.Size(75, 23);
            this.Btn_FullScreen.TabIndex = 2;
            this.Btn_FullScreen.Text = "全屏查看";
            this.Btn_FullScreen.UseVisualStyleBackColor = true;
            this.Btn_FullScreen.Click += new System.EventHandler(this.Btn_FullScreen_Click);
            // 
            // LB_CamID
            // 
            this.LB_CamID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_CamID.AutoSize = true;
            this.LB_CamID.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LB_CamID.ForeColor = System.Drawing.Color.Red;
            this.LB_CamID.Location = new System.Drawing.Point(375, 589);
            this.LB_CamID.Name = "LB_CamID";
            this.LB_CamID.Size = new System.Drawing.Size(35, 17);
            this.LB_CamID.TabIndex = 12;
            this.LB_CamID.Text = "线路:";
            // 
            // label_Chanel
            // 
            this.label_Chanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Chanel.AutoSize = true;
            this.label_Chanel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Chanel.ForeColor = System.Drawing.Color.Red;
            this.label_Chanel.Location = new System.Drawing.Point(375, 551);
            this.label_Chanel.Name = "label_Chanel";
            this.label_Chanel.Size = new System.Drawing.Size(56, 17);
            this.label_Chanel.TabIndex = 7;
            this.label_Chanel.Text = "路段信息";
            // 
            // DataGrid
            // 
            this.DataGrid.AllowUserToDeleteRows = false;
            this.DataGrid.AllowUserToResizeColumns = false;
            this.DataGrid.AllowUserToResizeRows = false;
            this.DataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGrid.Location = new System.Drawing.Point(0, 58);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.ReadOnly = true;
            this.DataGrid.RowHeadersVisible = false;
            this.DataGrid.RowTemplate.Height = 23;
            this.DataGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DataGrid.Size = new System.Drawing.Size(1196, 57);
            this.DataGrid.TabIndex = 1;
            this.DataGrid.Tag = "";
            // 
            // Column1
            // 
            this.Column1.FillWeight = 132F;
            this.Column1.HeaderText = "摄像头编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "总客流量";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "上行流量";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "下行流量";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "客流速度";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "客流密度";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "道路信息";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Btn_PTZ
            // 
            this.Btn_PTZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_PTZ.Location = new System.Drawing.Point(462, 488);
            this.Btn_PTZ.Name = "Btn_PTZ";
            this.Btn_PTZ.Size = new System.Drawing.Size(75, 23);
            this.Btn_PTZ.TabIndex = 17;
            this.Btn_PTZ.Text = "云台控制";
            this.Btn_PTZ.UseVisualStyleBackColor = true;
            this.Btn_PTZ.Click += new System.EventHandler(this.Btn_PTZ_Click);
            // 
            // LB_picturebox
            // 
            this.LB_picturebox.AutoSize = true;
            this.LB_picturebox.BackColor = System.Drawing.Color.Transparent;
            this.LB_picturebox.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LB_picturebox.ForeColor = System.Drawing.Color.Red;
            this.LB_picturebox.Location = new System.Drawing.Point(0, 0);
            this.LB_picturebox.Name = "LB_picturebox";
            this.LB_picturebox.Size = new System.Drawing.Size(0, 25);
            this.LB_picturebox.TabIndex = 18;
            this.LB_picturebox.Tag = "9999";
            // 
            // LB_ServerState
            // 
            this.LB_ServerState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LB_ServerState.AutoSize = true;
            this.LB_ServerState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LB_ServerState.ForeColor = System.Drawing.Color.Red;
            this.LB_ServerState.Location = new System.Drawing.Point(12, 498);
            this.LB_ServerState.Name = "LB_ServerState";
            this.LB_ServerState.Size = new System.Drawing.Size(126, 21);
            this.LB_ServerState.TabIndex = 14;
            this.LB_ServerState.Tag = "";
            this.LB_ServerState.Text = "服务器连接状况:";
            // 
            // PB_Connected
            // 
            this.PB_Connected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PB_Connected.BackColor = System.Drawing.Color.Transparent;
            this.PB_Connected.Image = ((System.Drawing.Image)(resources.GetObject("PB_Connected.Image")));
            this.PB_Connected.Location = new System.Drawing.Point(18, 533);
            this.PB_Connected.Name = "PB_Connected";
            this.PB_Connected.Size = new System.Drawing.Size(15, 12);
            this.PB_Connected.TabIndex = 20;
            this.PB_Connected.TabStop = false;
            // 
            // PB_Reconnect
            // 
            this.PB_Reconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PB_Reconnect.BackColor = System.Drawing.Color.Transparent;
            this.PB_Reconnect.Image = ((System.Drawing.Image)(resources.GetObject("PB_Reconnect.Image")));
            this.PB_Reconnect.Location = new System.Drawing.Point(19, 574);
            this.PB_Reconnect.Name = "PB_Reconnect";
            this.PB_Reconnect.Size = new System.Drawing.Size(17, 17);
            this.PB_Reconnect.TabIndex = 21;
            this.PB_Reconnect.TabStop = false;
            // 
            // PB_Unconnect
            // 
            this.PB_Unconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PB_Unconnect.BackColor = System.Drawing.Color.Transparent;
            this.PB_Unconnect.Image = ((System.Drawing.Image)(resources.GetObject("PB_Unconnect.Image")));
            this.PB_Unconnect.Location = new System.Drawing.Point(16, 552);
            this.PB_Unconnect.Name = "PB_Unconnect";
            this.PB_Unconnect.Size = new System.Drawing.Size(17, 20);
            this.PB_Unconnect.TabIndex = 22;
            this.PB_Unconnect.TabStop = false;
            // 
            // LBstate_normal
            // 
            this.LBstate_normal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LBstate_normal.AutoSize = true;
            this.LBstate_normal.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBstate_normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(116)))), ((int)(((byte)(173)))));
            this.LBstate_normal.Location = new System.Drawing.Point(39, 531);
            this.LBstate_normal.Name = "LBstate_normal";
            this.LBstate_normal.Size = new System.Drawing.Size(32, 17);
            this.LBstate_normal.TabIndex = 23;
            this.LBstate_normal.Tag = "9999";
            this.LBstate_normal.Text = "已连";
            // 
            // LBstate_reconnect
            // 
            this.LBstate_reconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LBstate_reconnect.AutoSize = true;
            this.LBstate_reconnect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBstate_reconnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(116)))), ((int)(((byte)(173)))));
            this.LBstate_reconnect.Location = new System.Drawing.Point(39, 571);
            this.LBstate_reconnect.Name = "LBstate_reconnect";
            this.LBstate_reconnect.Size = new System.Drawing.Size(32, 17);
            this.LBstate_reconnect.TabIndex = 24;
            this.LBstate_reconnect.Tag = "9999";
            this.LBstate_reconnect.Text = "重连";
            // 
            // LBstate_unconnect
            // 
            this.LBstate_unconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LBstate_unconnect.AutoSize = true;
            this.LBstate_unconnect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBstate_unconnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(116)))), ((int)(((byte)(173)))));
            this.LBstate_unconnect.Location = new System.Drawing.Point(39, 550);
            this.LBstate_unconnect.Name = "LBstate_unconnect";
            this.LBstate_unconnect.Size = new System.Drawing.Size(32, 17);
            this.LBstate_unconnect.TabIndex = 25;
            this.LBstate_unconnect.Tag = "9999";
            this.LBstate_unconnect.Text = "未连";
            // 
            // Cbo_Reset
            // 
            this.Cbo_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cbo_Reset.AutoSize = true;
            this.Cbo_Reset.Location = new System.Drawing.Point(378, 491);
            this.Cbo_Reset.Name = "Cbo_Reset";
            this.Cbo_Reset.Size = new System.Drawing.Size(72, 16);
            this.Cbo_Reset.TabIndex = 26;
            this.Cbo_Reset.Text = "自动归位";
            this.Cbo_Reset.UseVisualStyleBackColor = true;
            // 
            // Btn_RoiArea
            // 
            this.Btn_RoiArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_RoiArea.Location = new System.Drawing.Point(462, 521);
            this.Btn_RoiArea.Name = "Btn_RoiArea";
            this.Btn_RoiArea.Size = new System.Drawing.Size(75, 23);
            this.Btn_RoiArea.TabIndex = 27;
            this.Btn_RoiArea.Text = "检测区域";
            this.Btn_RoiArea.UseVisualStyleBackColor = true;
            this.Btn_RoiArea.Click += new System.EventHandler(this.Btn_RoiArea_Click);
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // Panel_Monitor
            // 
            this.Panel_Monitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Monitor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Panel_Monitor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel_Monitor.BackgroundImage")));
            this.Panel_Monitor.Controls.Add(this.PB_Monitor);
            this.Panel_Monitor.Location = new System.Drawing.Point(0, 121);
            this.Panel_Monitor.Name = "Panel_Monitor";
            this.Panel_Monitor.Size = new System.Drawing.Size(640, 360);
            this.Panel_Monitor.TabIndex = 19;
            // 
            // PB_Monitor
            // 
            this.PB_Monitor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PB_Monitor.BackgroundImage")));
            this.PB_Monitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PB_Monitor.Location = new System.Drawing.Point(0, 0);
            this.PB_Monitor.Name = "PB_Monitor";
            this.PB_Monitor.Size = new System.Drawing.Size(640, 360);
            this.PB_Monitor.TabIndex = 0;
            this.PB_Monitor.TabStop = false;
            // 
            // CarDetect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1198, 620);
            this.Controls.Add(this.Panel_Monitor);
            this.Controls.Add(this.Btn_RoiArea);
            this.Controls.Add(this.Cbo_Reset);
            this.Controls.Add(this.LBstate_unconnect);
            this.Controls.Add(this.LBstate_reconnect);
            this.Controls.Add(this.LBstate_normal);
            this.Controls.Add(this.PB_Unconnect);
            this.Controls.Add(this.PB_Reconnect);
            this.Controls.Add(this.PB_Connected);
            this.Controls.Add(this.LB_ServerState);
            this.Controls.Add(this.LB_picturebox);
            this.Controls.Add(this.Btn_PTZ);
            this.Controls.Add(this.LB_CamID);
            this.Controls.Add(this.label_Chanel);
            this.Controls.Add(this.Panel_Chart);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.Btn_FullScreen);
            this.Controls.Add(this.Btn_Begin);
            this.Controls.Add(this.Cbo_ID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CarDetect";
            this.Text = "客流检测";
            this.Load += new System.EventHandler(this.CarDetect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_Speed)).EndInit();
            this.Panel_Chart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_Volumn)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Connected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Reconnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Unconnect)).EndInit();
            this.Panel_Monitor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Monitor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Speed;
        private System.Windows.Forms.Panel Panel_Chart;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 实时监控ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 路段信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 历史报警ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 历史数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 参数设置ToolStripMenuItem1;
        private System.Windows.Forms.ComboBox Cbo_ID;
        private System.Windows.Forms.Button Btn_Begin;
        private System.Windows.Forms.Button Btn_FullScreen;
        private System.Windows.Forms.Label LB_CamID;
        private System.Windows.Forms.Label label_Chanel;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Button Btn_PTZ;
        private System.Windows.Forms.Label LB_picturebox;
        private System.Windows.Forms.Label LB_ServerState;
        private System.Windows.Forms.PictureBox PB_Connected;
        private System.Windows.Forms.PictureBox PB_Reconnect;
        private System.Windows.Forms.PictureBox PB_Unconnect;
        private System.Windows.Forms.Label LBstate_normal;
        private System.Windows.Forms.Label LBstate_reconnect;
        private System.Windows.Forms.Label LBstate_unconnect;
        private System.Windows.Forms.CheckBox Cbo_Reset;
        private System.Windows.Forms.Button Btn_RoiArea;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Volumn;
        private System.Windows.Forms.Panel Panel_Monitor;
        private System.Windows.Forms.PictureBox PB_Monitor;
    }
}

