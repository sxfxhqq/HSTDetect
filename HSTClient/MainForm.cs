/*----------------------------------------------------------------             
// Copyright (C) 2018 North China University of Technology             
// 版权所有。              
//              
// 文件名：MainForm.cs       
// 文件功能描述： 
 * 主界面
// 创建人：谭磊
// 创建时间：2018-3-12
// 修改人：
// 修改时间：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace HSTClient
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer timer_weatherQuery = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer timer_check = new System.Windows.Forms.Timer();
        private int CamID = -1;
        private ControlsOperation operation = new ControlsOperation();
        private HisOperation HO = new HisOperation();
        private double XProportion;
        private double YProportion;
        private HistoryDataControl HD;
        private Settings setting;
        private MultiScreen MS;
        private OtherSettings otherSettings;
        private Client.MySqlHelper mysql = new Client.MySqlHelper();
        private Client.VLCPlayer vlc = new Client.VLCPlayer();
        private Threshold threshold = new Threshold();
        public MainForm()
        {
            InitializeComponent();
            //Client.HSTDataClass.CNeg = new Random().Next(10000, 20000);
            //Client.HSTDataClass.CPos = new Random().Next(10000, 20000);
        }

        private void Pic_ShutDown_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            timer.Tick += timer_Tick;
            timer.Interval = 1000;
            timer_weatherQuery.Tick+=timer_weatherQuery_Tick;
            timer_weatherQuery.Interval = 1800000;
            timer_weatherQuery.Start(); 

            timer_check.Tick+= timer_check_Tick;
            timer_check.Interval = 60000;
            //按比例调节各空间位置和大小
            XProportion = (double)this.Size.Width / (double)1366;
            YProportion = (double)this.Size.Height / (double)768;
            operation.ChangeWindowsSize(this, XProportion, YProportion);
            //获取天气
            WeatherUpdate.LB_NetState = this.LB_NetState;
            WeatherUpdate.LB_Tem = this.LB_Tem;
            WeatherUpdate.LB_Weather = this.LB_Weather;
            WeatherUpdate.LB_WindPower = this.LB_WindPower;
            WeatherUpdate.Pic_Weather = this.Pic_Weather;
            WeatherUpdate.readWeatherDetail();
        }

        private void timer_check_Tick(object state,EventArgs sender)
        {
            if (vlc.IsPlaying())
            {
                this.LB_ServerState.Text = "正常";
                this.LB_ServerState.ForeColor = Color.White;
            }
            else
            {
                this.LB_ServerState.Text = "异常";
                vlc.release();
                string str = string.Format("SELECT Url FROM tb_param WHERE CamID={0};", this.CBO_CamID.Text);
                try
                {
                    string url = mysql.ExecuteDataTable(str).Rows[0]["Url"].ToString();
                    vlc.playUrl(url, this.Pic_Monitor.Handle);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                this.LB_ServerState.ForeColor = Color.Red;
            }
        }
        private void timer_weatherQuery_Tick(object state,EventArgs sender)//查询天气
        {
            WeatherClass WC = new WeatherClass();
            WeatherDetail detail = new WeatherDetail();
            if (WC.WeatherQuery(Client.ConfigClass.getInstance().getValue("province"), Client.ConfigClass.getInstance().getValue("city"), out detail))
            {
                WeatherUpdate.update(detail);
            }
            else
            {
                this.LB_NetState.Text = "异常";
                this.LB_NetState.ForeColor = Color.Red;
            }
        }
        private int ExceptionCount = 0;
        private void timer_Tick(object state,EventArgs sender)
        {
            if (CamID > 0)
            {
                Client.DataFunction.readDataFromDB(CamID);
                //Client.EmulateData.doEmulate(CamID);//模拟数据
                if (Client.DataFunction.DataFlag)
                {
                    Client.DataFunction.showAsChart_Pflow(chart_volumn);//折线图展示
                    //数码管展示
                    //如果流量超出高于10w
                    if ((Client.HSTDataClass.CNeg + Client.HSTDataClass.CPos) >= 100000)
                    {
                        this.lb_quantifier1.Text = "(万人次)";
                        operation.showVolume(TotalLed1, TotalLed2, TotalLed3, TotalLed4, TotalLed5, (Client.HSTDataClass.CNeg + Client.HSTDataClass.CPos) / 10000);
                    }
                    else
                    {
                        this.lb_quantifier1.Text = "(人次)";
                        operation.showVolume(TotalLed1, TotalLed2, TotalLed3, TotalLed4, TotalLed5, Client.HSTDataClass.CNeg + Client.HSTDataClass.CPos);
                    }
                    if (Client.HSTDataClass.CPos >= 100000)
                    {
                        this.lb_quantifier2.Text = "(万人次)";
                        operation.showVolume(UpLed1, UpLed2, UpLed3, UpLed4, UpLed5, Client.HSTDataClass.CPos / 10000);
                    }
                    else
                    {
                        this.lb_quantifier2.Text = "(人次)";
                        operation.showVolume(UpLed1, UpLed2, UpLed3, UpLed4, UpLed5, Client.HSTDataClass.CPos);
                    }
                    if (Client.HSTDataClass.CNeg >= 100000)
                    {
                        this.lb_quantifier3.Text = "(万人次)";
                        operation.showVolume(DownLed1, DownLed2, DownLed3, DownLed4, DownLed5, Client.HSTDataClass.CNeg / 10000);
                    }
                    else
                    {
                        this.lb_quantifier3.Text = "(人次)";
                        operation.showVolume(DownLed1, DownLed2, DownLed3, DownLed4, DownLed5, Client.HSTDataClass.CNeg);
                    }
                    //仪表盘展示
                    operation.showAsDashboard(SpeedCtl, Client.HSTDataClass.Speed);
                    operation.showAsDashboard(DensityCtl, Client.HSTDataClass.Density);
                    //饼状图展示
                    operation.showAsPieChart(chart_Today, Client.HSTDataClass.CPos, Client.HSTDataClass.CNeg);
                    //报警提示
                    if(operation.showWarning(Client.HSTDataClass.Speed, Client.HSTDataClass.Density, threshold))
                    {
                        this.LB_State.Text = "异常";
                        this.LB_State.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(97)))), ((int)(((byte)(77)))));
                        this.Pic_State.Image = Image.FromFile(@"img/warning_red.png");
                    }
                    else
                    {
                        this.LB_State.Text = "正常 ";
                        this.LB_State.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(114)))), ((int)(((byte)(169)))));
                        this.Pic_State.Image = Image.FromFile(@"img/warning.png");
                    }
                    this.LB_DBState.Text = "正常";
                    this.LB_DBState.ForeColor = Color.White;
                    ExceptionCount = 0;

                }
                else
                {
                    ExceptionCount++;
                    if (ExceptionCount == 10)
                    {
                        this.LB_DBState.Text = "异常";
                        this.LB_DBState.ForeColor = Color.Red;
                        ExceptionCount = 0;
                    }
                }
            }
        }
        private void Pic_Change_Click(object sender, EventArgs e)
        {
            Pic_Change.Hide();
            CBO_CamID.Show();
        }

        private bool isPlaying = false;//是否正在播放标志位
        private void CBO_CamID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CBO_CamID.Text.Equals(""))
                MessageBox.Show("请选择线路");
            else if (!int.TryParse(this.CBO_CamID.Text, out CamID))
                MessageBox.Show("请输入正确的线路编号");
            else
            {
                CamID = int.Parse(this.CBO_CamID.Text);
                operation.readThresholdFromDB(CamID, threshold);//读取报警阈值
                this.chart_volumn.Series[0].Points.Clear();
                if (isPlaying)
                {
                    vlc.release();//释放VLC资源
                }
                try
                {
                    //获取摄像头URL
                    string str = string.Format("SELECT * FROM tb_param WHERE CamID={0};", this.CBO_CamID.Text);
                    DataTable dt = mysql.ExecuteDataTable(str);
                    string url = dt.Rows[0]["Url"].ToString();
                    this.lb_position.Text = "--" + dt.Rows[0]["Position"].ToString() + "--" + dt.Rows[0]["CamID"].ToString();
                    //播放网络视频,读取url
                    vlc.playUrl(url, this.Pic_Monitor.Handle);
                    // //播放本地视频
                    /// vlc.playLocalVideo(@"C:\Users\Tony\Desktop\CAM220140529142103.avi", this.Pic_Monitor.Handle);
                    // //
                    isPlaying = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("请输入正确编号");
                }
                CBO_CamID.Hide();
                Pic_Change.Show();
                timer.Start();
                timer_Tick(sender, e);
                timer_check.Start();
                HistoryData HD = new HistoryData();
                HO.ReadDayData(CamID, HD, DateTime.Now.AddDays(-1));
                operation.showAsPieChart(chart_Yes, HD.UpVolume, HD.DownVolume);//昨日饼状图
                HO.ReadWeekData(CamID, HD, DateTime.Now.AddDays(-7));
                HO.ShowAsBarChart_week_int(chart_lastWeek, HD.TotalVolumeList);//上周柱状图
                HO.ReadWeekData(CamID, HD, DateTime.Now);
                HO.ShowAsBarChart_week_int(chart_week, HD.TotalVolumeList);//本周柱状图
                //operation.showAsPieChart(chart_Yes, 123134, 123122);
                //operation.showAsBarGraph(chart_lastWeek, new List<int>() { 23451, 23453, 52234, 21345, 66774, 77425, 23435 });//上周柱状图
                //operation.showAsBarGraph(chart_week, new List<int>() { 53755, 83547, 14356, 45367, 98765, 34213, 47653 });//本周柱状图
            }
        }
        #region[全屏功能]
        private Client.FullScreen frm;
        private void Pic_FullScreen_Click(object sender, EventArgs e)
        {
            if (frm == null)
            {
                frm = new Client.FullScreen();
            }
            frm.KeyDown += frm_KeyDown;
            Pic_Monitor.DoubleClick += Pic_Monitor_DoubleClick;
            frm.Controls.Add(this.Pic_Monitor);
            frm.ShowDialog();
        }

        private void Pic_Monitor_DoubleClick(object sender, EventArgs e)
        {
            if(frm!=null)
            {
                frm.Controls.Clear();
                this.Panel_Monitor.Controls.Add(this.Pic_Monitor);
                frm.Close();
                frm = null;
            }
        }

        private void frm_KeyDown(object sender, KeyEventArgs e)
        {
            /*
             * 设置按下ALT+F4无效
             * 设置按下ESC退出全屏
            */
            if (e.KeyCode == Keys.F4 && e.Modifiers == Keys.Alt)
            {
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                frm.Controls.Clear();
                this.Panel_Monitor.Controls.Add(this.Pic_Monitor);
                frm.Close();
                frm = null;
            }
        }
        #endregion

        private void 历史数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HD == null)
            {
                HD = new HistoryDataControl();
                operation.ChangeWindowsSize(HD, XProportion, YProportion);
                Controls.Add(HD);
                HD.Location = new Point(0, this.Panel_Title.Size.Height + 1);
                HD.Size = new Size(this.Size.Width, this.Size.Height - this.Panel_Title.Size.Height);
            }
            HD.CamID = CamID;
            HD.Show();
            HD.BringToFront();
        }

        private void 参数设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (setting == null)
            {
                setting = new Settings();
                operation.ChangeWindowsSize(setting, XProportion, YProportion);
                Controls.Add(setting);
                setting.Location = new Point(0, this.Panel_Title.Size.Height + 1);
                setting.Size = new Size(this.Size.Width, this.Size.Height - this.Panel_Title.Size.Height);
            }
            setting.Show();
            setting.BringToFront();
        }
        private void 分屏显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MS == null)
            {
                MS = new MultiScreen();
                operation.ChangeWindowsSize(MS, XProportion, YProportion);
                Controls.Add(MS);
                MS.Location = new Point(0, this.Panel_Title.Size.Height + 1);
                MS.Size = new Size(this.Size.Width, this.Size.Height - this.Panel_Title.Size.Height);
            }
            MS.Show();
            MS.BringToFront();
        }

        private void 其他设置StripMenuItem_Click(object sender, EventArgs e)
        {
            if (otherSettings == null)
            {
                otherSettings = new OtherSettings();
                operation.ChangeWindowsSize(otherSettings, XProportion, YProportion);
                Controls.Add(otherSettings);
                otherSettings.Location = new Point(0, this.Panel_Title.Size.Height + 1);
                otherSettings.Size = new Size(this.Size.Width, this.Size.Height - this.Panel_Title.Size.Height);
            }
            otherSettings.Show();
            otherSettings.BringToFront();
        }
        private void 实时监控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (setting != null)
            {
                setting.Hide();
            }
            if (HD != null)
            {
                HD.Hide();
            }
            if (MS != null)
            {
                MS.Hide();
            }
            if (otherSettings != null)
            {
                otherSettings.Hide();
            }
        }

        private void Pic_MinState_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void CBO_CamID_Click(object sender, EventArgs e)
        {
            this.CBO_CamID.Items.Clear();
            //获取数据库存储的摄像头编号
            string str = string.Format("SELECT CamID FROM tb_param;");
            try
            {
                DataTable dt = mysql.ExecuteDataTable(str);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.CBO_CamID.Items.Add(dt.Rows[i]["CamID"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
