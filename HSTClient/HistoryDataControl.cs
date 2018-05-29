/*----------------------------------------------------------------             
// Copyright (C) 2018 North China University of Technology             
// 版权所有。              
//              
// 文件名：HistoryDataControl.cs       
// 文件功能描述： 
 *历史数据查询界面
// 创建人：谭磊
// 创建时间：2018-4-2
// 修改人：
// 修改时间：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HSTClient
{
    public partial class HistoryDataControl : UserControl
    {
        public int CamID = -1;
        private HisOperation HO = new HisOperation();
        private HistoryData HD = new HistoryData();
        private ControlsOperation CO = new ControlsOperation();
        private Client.MySqlHelper mysql = new Client.MySqlHelper();
        private bool IsDayFlag = true;
        private bool IsWeekFlag = false;
        private bool IsMonthFlag = false;
        private bool IsYearFlag = false;
        public HistoryDataControl()
        {
            InitializeComponent();
            this.Visible = false;
        }
        private void HistoryData_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                if (CamID >= 0 && IsDayFlag)
                {
                    this.chart.ChartAreas[0].AxisX.Maximum = 24;
                    this.chart.ChartAreas[0].AxisX.Minimum = 1;

                    HO.ReadDayData(CamID, HD, this.dateTimePicker.Value);//获取今日数据

                    this.LB_TotalVolume.Text = ((double)HD.TotalVolume / 10000).ToString("0.00") + "万";
                    this.LB_UpVolume.Text = ((double)HD.UpVolume / 10000).ToString("0.00") + "万";
                    this.LB_DownVolume.Text = ((double)HD.DownVolume / 10000).ToString("0.00") + "万";


                    CO.showAsPieChart(piechart, HD.UpVolume, HD.DownVolume);//饼状图

                    string msg = "";
                    HO.ReadCamMesg(CamID, out msg);//摄像头相关信息
                    this.LB_Location.Text = msg;

                    this.LB_CamID.Text = CamID.ToString();
                    this.LB_Date.Text = dateTimePicker.Value.ToString("yyyy年MM月dd日");

                    HO.ShowAsBarChart_day_int(this.chart, HD.TotalVolumeList);//折线图
                }
            }
        }
        private void Btn_Confirm_Click(object sender, EventArgs e)
        {
            if (CBO_CamID.Text == "")
                return;
            this.CamID = Convert.ToInt32(CBO_CamID.Text);
            this.chart.Series[0].Points.Clear();
            if (CamID >= 0)
            {
                if (IsDayFlag)//按天查询
                {
                    HO.ReadDayData(CamID, HD, this.dateTimePicker.Value);//获取今日数据
                    HO.ShowAsBarChart_day_int(this.chart, HD.TotalVolumeList);//折线图
                }
                if(IsWeekFlag)
                {
                    HO.ReadWeekData(CamID, HD, this.dateTimePicker.Value);
                    HO.ShowAsBarChart_week_int(this.chart, HD.TotalVolumeList);
                }
                if(IsMonthFlag)
                {
                    HO.ReadMonthData(CamID, HD, this.dateTimePicker.Value);
                    HO.ShowAsBarChart_month_int(this.chart, HD.TotalVolumeList);
                }
                if(IsYearFlag)
                {
                    HO.ReadYearData(CamID, HD, this.dateTimePicker.Value);
                    HO.ShowAsBarChart_year_int(this.chart, HD.TotalVolumeList);
                }

                this.LB_TotalVolume.Text = ((double)HD.TotalVolume / 10000).ToString("0.00") + "万";
                this.LB_UpVolume.Text = ((double)HD.UpVolume / 10000).ToString("0.00") + "万";
                this.LB_DownVolume.Text = ((double)HD.DownVolume / 10000).ToString("0.00") + "万";

                CO.showAsPieChart(piechart, HD.UpVolume, HD.DownVolume);//饼状图

                string CamMsg = "";
                HO.ReadCamMesg(CamID, out CamMsg);//摄像头相关信息
                this.LB_Location.Text = CamMsg;

                this.LB_CamID.Text = CamID.ToString();
                this.LB_Date.Text = dateTimePicker.Value.ToString("yyyy年MM月dd日");

                this.LB_MaxDensity.Text = HD.MaxDensity.ToString();
                this.LB_MaxSpeed.Text = HD.MaxSpeed.ToString();
                this.LB_MinDensity.Text = HD.MinDensity.ToString();
                this.LB_MinDensity.Text = HD.MinDensity.ToString();
            }
        }
        private void Btn_TotalVolume_Click(object sender, EventArgs e)
        {
            Btn_Speed.Enabled = true;
            Btn_Density.Enabled = true;
            Btn_Alarm.Enabled = true;
            Btn_DownVolume.Enabled = true;
            Btn_UpVolume.Enabled = true;
            Btn_TotalVolume.Enabled = false;
            this.chart.Titles[0].Text = "总流量分布";
            if (IsDayFlag)
            {
                HO.ShowAsBarChart_day_int(this.chart, HD.TotalVolumeList);
            }
            if (IsWeekFlag)
            {
                HO.ShowAsBarChart_week_int(this.chart, HD.TotalVolumeList);
            }
            if (IsMonthFlag)
            {
                HO.ShowAsBarChart_month_int(this.chart, HD.TotalVolumeList);
            }
            if (IsYearFlag)
            {
                HO.ShowAsBarChart_year_int(this.chart, HD.TotalVolumeList);
            }
        }

        private void Btn_UpVolume_Click(object sender, EventArgs e)
        {
            Btn_Speed.Enabled = true;
            Btn_Density.Enabled = true;
            Btn_Alarm.Enabled = true;
            Btn_DownVolume.Enabled = true;
            Btn_UpVolume.Enabled = false;
            Btn_TotalVolume.Enabled = true;
            this.chart.Titles[0].Text = "上行流量分布";
            if (IsDayFlag)
            {
                HO.ShowAsBarChart_day_int(this.chart, HD.UpVolumeList);
            }
            if (IsWeekFlag)
            {
                HO.ShowAsBarChart_week_int(this.chart, HD.UpVolumeList);
            }
            if (IsMonthFlag)
            {
                HO.ShowAsBarChart_month_int(this.chart, HD.UpVolumeList);
            }
            if (IsYearFlag)
            {
                HO.ShowAsBarChart_year_int(this.chart, HD.UpVolumeList);
            }
        }

        private void Btn_DownVolume_Click(object sender, EventArgs e)
        {
            Btn_Speed.Enabled = true;
            Btn_Density.Enabled = true;
            Btn_Alarm.Enabled = true;
            Btn_DownVolume.Enabled = false;
            Btn_UpVolume.Enabled = true;
            Btn_TotalVolume.Enabled = true;
            this.chart.Titles[0].Text = "下行流量分布";
            if (IsDayFlag)
            {
                HO.ShowAsBarChart_day_int(this.chart, HD.DownVolmeList);
            }
            if (IsWeekFlag)
            {
                HO.ShowAsBarChart_week_int(this.chart, HD.DownVolmeList);
            }
            if (IsMonthFlag)
            {
                HO.ShowAsBarChart_month_int(this.chart, HD.DownVolmeList);
            }
            if (IsYearFlag)
            {
                HO.ShowAsBarChart_year_int(this.chart, HD.DownVolmeList);
            }
        }

        private void Btn_Alarm_Click(object sender, EventArgs e)
        {
            Btn_Speed.Enabled = true;
            Btn_Density.Enabled = true;
            Btn_Alarm.Enabled = false;
            Btn_DownVolume.Enabled = true;
            Btn_UpVolume.Enabled = true;
            Btn_TotalVolume.Enabled = true;
            this.chart.Titles[0].Text = "报警分布";
            //HO.ShowAsBarChart(this.chart_lastWeek, HD.AlarmList);  //未添加
        }

        private void Btn_Density_Click(object sender, EventArgs e)
        {
            Btn_Speed.Enabled = true;
            Btn_Density.Enabled = false;
            Btn_Alarm.Enabled = true;
            Btn_DownVolume.Enabled = true;
            Btn_UpVolume.Enabled = true;
            Btn_TotalVolume.Enabled = true;
            this.chart.Titles[0].Text = "密度分布";
            if (IsDayFlag)
            {
                HO.ShowAsBarChart_day_double(this.chart, HD.DensityList);
            }
            if (IsWeekFlag)
            {
                HO.ShowAsBarChart_week_double(this.chart, HD.DensityList);
            }
            if (IsMonthFlag)
            {
                HO.ShowAsBarChart_month_double(this.chart, HD.DensityList);
            }
            if (IsYearFlag)
            {
                HO.ShowAsBarChart_year_double(this.chart, HD.DensityList);
            }
        }

        private void Btn_Speed_Click(object sender, EventArgs e)
        {
            Btn_Speed.Enabled = false;
            Btn_Density.Enabled = true;
            Btn_Alarm.Enabled = true;
            Btn_DownVolume.Enabled = true;
            Btn_UpVolume.Enabled = true;
            Btn_TotalVolume.Enabled = true;
            this.chart.Titles[0].Text = "速度分布";
            if (IsDayFlag)
            {
                HO.ShowAsBarChart_day_double(this.chart, HD.SpeedList);
            }
            if (IsWeekFlag)
            {
                HO.ShowAsBarChart_week_double(this.chart, HD.SpeedList);
            }
            if (IsMonthFlag)
            {
                HO.ShowAsBarChart_month_double(this.chart, HD.SpeedList);
            }
            if (IsYearFlag)
            {
                HO.ShowAsBarChart_year_double(this.chart, HD.SpeedList);
            }
        }

        private void Btn_Day_Click(object sender, EventArgs e)
        {
            this.Btn_Return.Visible = true;
            IsDayFlag = true;
            IsWeekFlag = false;
            IsMonthFlag = false;
            IsYearFlag = false;

            this.dateTimePicker.Visible = true;
            this.Btn_Day.Visible = false;
            this.Btn_Week.Visible = false;
            this.Btn_Month.Visible = false;
            this.Btn_Year.Visible = false;
        }

        private void Btn_Week_Click(object sender, EventArgs e)
        {
            this.Btn_Return.Visible = true;
            IsDayFlag = false;
            IsWeekFlag = true;
            IsMonthFlag = false;
            IsYearFlag = false;

            this.dateTimePicker.Visible = true;
            this.Btn_Day.Visible = false;
            this.Btn_Week.Visible = false;
            this.Btn_Month.Visible = false;
            this.Btn_Year.Visible = false;
        }

        private void Btn_Month_Click(object sender, EventArgs e)
        {
            this.Btn_Return.Visible = true;
            IsDayFlag = false;
            IsWeekFlag = false;
            IsMonthFlag = true;
            IsYearFlag = false;

            this.dateTimePicker.Visible = true;
            this.Btn_Day.Visible = false;
            this.Btn_Week.Visible = false;
            this.Btn_Month.Visible = false;
            this.Btn_Year.Visible = false;
        }
        private void Btn_Year_Click(object sender, EventArgs e)
        {
            this.Btn_Return.Visible = true;

            IsDayFlag = false;
            IsWeekFlag = false;
            IsMonthFlag = false;
            IsYearFlag = true;

            this.dateTimePicker.Visible = true;
            this.Btn_Day.Visible = false;
            this.Btn_Week.Visible = false;
            this.Btn_Month.Visible = false;
            this.Btn_Year.Visible = false;

        }

        private void Btn_Return_Click(object sender, EventArgs e)
        {
            this.Btn_Day.Visible = true;
            this.Btn_Week.Visible = true;
            this.Btn_Month.Visible = true;
            this.Btn_Year.Visible = true;

            this.Btn_Return.Visible = false;
            this.dateTimePicker.Visible = false;
        }

        private void CBO_CamID_Click(object sender, EventArgs e)
        {
            CBO_CamID.Items.Clear();
            try
            {
                DataTable dt = mysql.ExecuteDataTable("SELECT CamID FROM tb_param");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CBO_CamID.Items.Add(dt.Rows[i]["CamID"]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
