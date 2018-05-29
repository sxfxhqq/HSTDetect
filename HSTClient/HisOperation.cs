/*----------------------------------------------------------------             
// Copyright (C) 2018 North China University of Technology             
// 版权所有。              
//              
// 文件名：HisOperation.cs       
// 文件功能描述： 
*历史数据查询操作类
// 创建人：谭磊
// 创建时间：2018-4-2
// 修改人：
// 修改时间：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HSTClient
{
    class HisOperation
    {
        private Client.MySqlHelper mysql = new Client.MySqlHelper();
        /// <summary>
        /// 读取日数据
        /// </summary>
        public void ReadDayData(int CamID, HistoryData HD,DateTime date)
        {
            string str = string.Format("select * from pflow_tb_data_hor where CamID={0} and Detecttime like '{1}%';", CamID,date.ToString("yyyy-MM-dd"));
            try
            {
                DataTable dt = mysql.ExecuteDataTable(str);
                if (dt.Rows.Count > 0)
                {
                    ChangeType(dt, HD);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 读取周数据
        /// </summary>
        /// <param name="CamID"></param>
        /// <param name="HD"></param>
        /// <param name="date"></param>
        public void ReadWeekData(int CamID,HistoryData HD,DateTime date)
        {
            DateTime beginDate = date.AddDays(1-Convert.ToInt32(date.DayOfWeek.ToString("d")));;
            DateTime endDate = beginDate.AddDays(6);
            string str = string.Format("select * FROM pflow_tb_data_day where CamID={0} and detecttime between  '{1} 00:00:00'  and '{2} 00:00:00';", CamID, beginDate.ToString("yyyy-MM-dd"), endDate.AddDays(1).ToString("yyyy-MM-dd"));
            try
            {
                DataTable dt = mysql.ExecuteDataTable(str);
                if (dt.Rows.Count > 0)
                {
                    ChangeType(dt, HD);
                }
                else
                    HD.TotalVolumeList.Clear();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// 读取月数据
        /// </summary>
        /// <param name="CamID"></param>
        /// <param name="HD"></param>
        /// <param name="date"></param>
        public void ReadMonthData(int CamID,HistoryData HD,DateTime date)
        {
            string str = string.Format("select * from pflow_tb_data_day where CamID={0} and month(detecttime)={1} and year(detecttime)={2};", CamID, date.Month, date.Year);
            try
            {
                DataTable dt = mysql.ExecuteDataTable(str);
                if (dt.Rows.Count > 0)
                {
                    ChangeType(dt, HD);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 读取年数据
        /// </summary>
        /// <param name="CamID"></param>
        /// <param name="HD"></param>
        /// <param name="date"></param>
        public void ReadYearData(int CamID, HistoryData HD, DateTime date)
        {
            string str = string.Format("select * from pflow_tb_data_month where CamID={0} and year(detecttime)={1}", CamID, date.Year);
            try
            {
                DataTable dt = mysql.ExecuteDataTable(str);
                if (dt.Rows.Count > 0)
                {
                    ChangeType(dt, HD);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 获取摄像头信息
        /// </summary>
        /// <param name="CamID"></param>
        /// <param name="msg"></param>
        public void ReadCamMesg(int CamID, out string msg)
        {
            string str = string.Format("select * from tb_param where CamID = {0}", CamID);
            try
            {
                DataTable dt = mysql.ExecuteDataTable(str);
                if (dt.Rows.Count > 0)
                {
                    msg = dt.Rows[0]["Position"].ToString();
                }
                else
                    msg = "无信息";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                msg = "无信息";
            }
        }
        /// <summary>
        /// 柱状图（日）int类型数据
        /// </summary>
        /// <param name="barChart"></param>
        /// <param name="list"></param>
        public void ShowAsBarChart_day_int(System.Windows.Forms.DataVisualization.Charting.Chart barChart, Dictionary<DateTime, int> list)
        {
            barChart.Series[0].Points.Clear();
            int[] data = new int[24];
            foreach(var item in list)
            {
                int hourIndex = Convert.ToInt32(item.Key.ToString("HH"));
                data[hourIndex] += item.Value;
            }
            for (int i = 1; i < 25; i++)
            {
                barChart.Series[0].Points.AddXY(i, data[i-1]);
            }
            barChart.ChartAreas[0].AxisX.Maximum = 24;
            barChart.ChartAreas[0].AxisX.Minimum = 1;
        }
        /// <summary>
        /// 柱状图（日）Double类型数据
        /// </summary>
        /// <param name="barChart"></param>
        /// <param name="list"></param>
        public void ShowAsBarChart_day_double(System.Windows.Forms.DataVisualization.Charting.Chart barChart, Dictionary<DateTime, double> list)
        {
            barChart.Series[0].Points.Clear();
            double[] data = new double[24];
            foreach (var item in list)
            {
                int hourIndex = Convert.ToInt32(item.Key.ToString("HH"));
                data[hourIndex] += item.Value;
            }
            for (int i = 1; i < 25; i++)
            {
                barChart.Series[0].Points.AddXY(i, data[i - 1]);
            }
            barChart.ChartAreas[0].AxisX.Maximum = 24;
            barChart.ChartAreas[0].AxisX.Minimum = 1;
        }
        /// <summary>
        /// 柱状图（周）int类型数据
        /// </summary>
        /// <param name="barChart"></param>
        /// <param name="list"></param>
        public void ShowAsBarChart_week_int(System.Windows.Forms.DataVisualization.Charting.Chart barChart,Dictionary<DateTime,int> list)
        {
            barChart.Series[0].Points.Clear();
            int[] data = new int[8];
            foreach(var item in list)
            {
                int dayIndex = Convert.ToInt32(item.Key.DayOfWeek.ToString("d"));
               
                if(dayIndex ==0)
                {
                    data[7] += item.Value;
                }
                else
                    data[dayIndex] += item.Value;
            }
            for(int i =1;i<8;i++)
            {
                switch(i)
                {
                    case 1:
                        barChart.Series[0].Points.AddXY("Mon.", data[i]);
                        break;
                    case 2:
                        barChart.Series[0].Points.AddXY("Tues.", data[i]);
                        break;
                    case 3:
                        barChart.Series[0].Points.AddXY("Wed.", data[i]);
                        break;
                    case 4:
                        barChart.Series[0].Points.AddXY("Thur.", data[i]);
                        break;
                    case 5:
                        barChart.Series[0].Points.AddXY("Fri.", data[i]);
                        break;
                    case 6:
                        barChart.Series[0].Points.AddXY("Sat.", data[i]);
                        break;
                    case 7:
                        barChart.Series[0].Points.AddXY("Sun.", data[i]);
                        break;
                }
            }
            barChart.ChartAreas[0].AxisX.Maximum = 7;
            barChart.ChartAreas[0].AxisX.Minimum = 1;
        }
        /// <summary>
        /// 柱状图（周）double类型数据
        /// </summary>
        /// <param name="barChart"></param>
        /// <param name="list"></param>
        public void ShowAsBarChart_week_double(System.Windows.Forms.DataVisualization.Charting.Chart barChart, Dictionary<DateTime, double> list)
        {
            barChart.Series[0].Points.Clear();
            double[] data = new double[8];
            foreach (var item in list)
            {
                int dayIndex = Convert.ToInt32(item.Key.DayOfWeek.ToString("d"));
                if (dayIndex == 0)
                {
                    data[7] += item.Value;
                }
                else
                    data[dayIndex] += item.Value;
            }
            for (int i = 1; i < 8; i++)
            {
                switch (i)
                {
                    case 1:
                        barChart.Series[0].Points.AddXY("Mon.", data[i]);
                        break;
                    case 2:
                        barChart.Series[0].Points.AddXY("Tues.", data[i]);
                        break;
                    case 3:
                        barChart.Series[0].Points.AddXY("Wed.", data[i]);
                        break;
                    case 4:
                        barChart.Series[0].Points.AddXY("Thur.", data[i]);
                        break;
                    case 5:
                        barChart.Series[0].Points.AddXY("Fri.", data[i]);
                        break;
                    case 6:
                        barChart.Series[0].Points.AddXY("Sat.", data[i]);
                        break;
                    case 7:
                        barChart.Series[0].Points.AddXY("Sun.", data[i]);
                        break;
                }
            } 
            barChart.ChartAreas[0].AxisX.Maximum = 7;
            barChart.ChartAreas[0].AxisX.Minimum = 1;
        }
        /// <summary>
        /// 柱状图（月）int类型数据
        /// </summary>
        /// <param name="barChart"></param>
        /// <param name="list"></param>
        public void ShowAsBarChart_month_int(System.Windows.Forms.DataVisualization.Charting.Chart barChart,Dictionary<DateTime,int> list)
        {
            barChart.Series[0].Points.Clear();

            int[] data = new int[32];
            foreach(var item in list)
            {
                int monthIndex = Convert.ToInt32(item.Key.Day);
                data[monthIndex] += item.Value;
            }
            for(int i =1;i<32;i++)
            {
                barChart.Series[0].Points.AddXY(i, data[i]);
            }
            barChart.ChartAreas[0].AxisX.Maximum = 31;
            barChart.ChartAreas[0].AxisX.Minimum = 1;
        }
        /// <summary>
        /// 柱状图（月）double类型数据
        /// </summary>
        /// <param name="barChart"></param>
        /// <param name="list"></param>
        public void ShowAsBarChart_month_double(System.Windows.Forms.DataVisualization.Charting.Chart barChart, Dictionary<DateTime, double> list)
        {
            barChart.Series[0].Points.Clear();

            double[] data = new double[32];
            foreach (var item in list)
            {
                int monthIndex = Convert.ToInt32(item.Key.Day);
                data[monthIndex] += item.Value;
            }
            for (int i = 1; i < 32; i++)
            {
                barChart.Series[0].Points.AddXY(i, data[i]);
            }
            barChart.ChartAreas[0].AxisX.Maximum = 31;
            barChart.ChartAreas[0].AxisX.Minimum = 1;
        }
        /// <summary>
        /// 柱状图（年）int类型数据
        /// </summary>
        /// <param name="barChart"></param>
        /// <param name="list"></param>
        public void ShowAsBarChart_year_int(System.Windows.Forms.DataVisualization.Charting.Chart barChart, Dictionary<DateTime, int> list)
        {
            barChart.Series[0].Points.Clear();

            int[] data = new int[13];
            foreach(var item in list)
            {
                int monthIndex = Convert.ToInt32(item.Key.Month);
                data[monthIndex] += item.Value;
            }
            for(int i =1;i<13;i++)
            {
                switch (i)
                {
                    case 1:
                        barChart.Series[0].Points.AddXY("Jan.", data[i]);
                        break;
                    case 2:
                        barChart.Series[0].Points.AddXY("Feb.", data[i]);
                        break;
                    case 3:
                        barChart.Series[0].Points.AddXY("Mar.", data[i]);
                        break;
                    case 4:
                        barChart.Series[0].Points.AddXY("Apr.", data[i]);
                        break;
                    case 5:
                        barChart.Series[0].Points.AddXY("May.", data[i]);
                        break;
                    case 6:
                        barChart.Series[0].Points.AddXY("Jun.", data[i]);
                        break;
                    case 7:
                        barChart.Series[0].Points.AddXY("Jul.", data[i]);
                        break;
                    case 8:
                        barChart.Series[0].Points.AddXY("Aug.", data[i]);
                        break;
                    case 9:
                        barChart.Series[0].Points.AddXY("Sept.", data[i]);
                        break;
                    case 10:
                        barChart.Series[0].Points.AddXY("Oct.", data[i]);
                        break;
                    case 11:
                        barChart.Series[0].Points.AddXY("Nov.", data[i]);
                        break;
                    case 12:
                        barChart.Series[0].Points.AddXY("Dec.", data[i]);
                        break;
                }
            }
            barChart.ChartAreas[0].AxisX.Maximum = 12;
            barChart.ChartAreas[0].AxisX.Minimum = 1;
        }
        /// <summary>
        /// 柱状图（年）double类型数据
        /// </summary>
        /// <param name="barChart"></param>
        /// <param name="list"></param>
        public void ShowAsBarChart_year_double(System.Windows.Forms.DataVisualization.Charting.Chart barChart, Dictionary<DateTime, double> list)
        {
            barChart.Series[0].Points.Clear();

            double[] data = new double[13];
            int[] count = new int[13];
            foreach(var item in list)
            {
                int monthIndex = Convert.ToInt32(item.Key.Month);
                count[monthIndex]++;
                data[monthIndex] += item.Value;
            }
            double[] data_average = new double[13];
            for (int i = 1; i < data.Count(); i++)
            {
                data_average[i] = data[i] / count[i];
            }
            for (int i = 1; i < 13; i++)
            {
                switch (i)
                {
                    case 1:
                        barChart.Series[0].Points.AddXY("Jan.", data_average[i]);
                        break;
                    case 2:
                        barChart.Series[0].Points.AddXY("Feb.", data_average[i]);
                        break;
                    case 3:
                        barChart.Series[0].Points.AddXY("Mar.", data_average[i]);
                        break;
                    case 4:
                        barChart.Series[0].Points.AddXY("Apr.", data_average[i]);
                        break;
                    case 5:
                        barChart.Series[0].Points.AddXY("May.", data_average[i]);
                        break;
                    case 6:
                        barChart.Series[0].Points.AddXY("Jun.", data_average[i]);
                        break;
                    case 7:
                        barChart.Series[0].Points.AddXY("Jul.", data_average[i]);
                        break;
                    case 8:
                        barChart.Series[0].Points.AddXY("Aug.", data_average[i]);
                        break;
                    case 9:
                        barChart.Series[0].Points.AddXY("Sept.", data_average[i]);
                        break;
                    case 10:
                        barChart.Series[0].Points.AddXY("Oct.", data_average[i]);
                        break;
                    case 11:
                        barChart.Series[0].Points.AddXY("Nov.", data_average[i]);
                        break;
                    case 12:
                        barChart.Series[0].Points.AddXY("Dec.", data_average[i]);
                        break;
                }
            }
            barChart.ChartAreas[0].AxisX.Maximum = 12;
            barChart.ChartAreas[0].AxisX.Minimum = 1;
        }
        /// <summary>
        /// datatable转换成自定义数据类
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="HD"></param>
        private void ChangeType(DataTable dt,HistoryData HD)
        {
            initData(HD);
            List<double> MaxSpeedList = new List<double>();
            List<double> MinSpeedList = new List<double>();
            List<double> MaxDensityList = new List<double>();
            List<double> MinDensityList = new List<double>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HD.UpVolume += Convert.ToInt32(dt.Rows[i]["CPos_incr"]);//上行总量
                HD.DownVolume += Convert.ToInt32(dt.Rows[i]["CNeg_incr"]);//下行总量
                //         HD.AlarmList.Add(Convert.ToDateTime(dt.Rows[i]["DetectTime"]), Convert.ToInt32(dt.Rows[i]["alarmtype"])); //报警数量（未添加）
                if (!HD.DensityList.Keys.Contains(Convert.ToDateTime(dt.Rows[i]["DetectTime"])))
                    HD.DensityList.Add(Convert.ToDateTime(dt.Rows[i]["DetectTime"]), Convert.ToDouble(dt.Rows[i]["Density"]));//密度
                if (!HD.SpeedList.Keys.Contains(Convert.ToDateTime(dt.Rows[i]["DetectTime"])))
                    HD.SpeedList.Add(Convert.ToDateTime(dt.Rows[i]["DetectTime"]), Convert.ToDouble(dt.Rows[i]["Speed"]));//速度
                if (!HD.UpVolumeList.Keys.Contains(Convert.ToDateTime(dt.Rows[i]["DetectTime"])))
                    HD.UpVolumeList.Add(Convert.ToDateTime(dt.Rows[i]["DetectTime"]), Convert.ToInt32(dt.Rows[i]["CPos_incr"]));//上行量
                if (!HD.DownVolmeList.Keys.Contains(Convert.ToDateTime(dt.Rows[i]["DetectTime"])))
                    HD.DownVolmeList.Add(Convert.ToDateTime(dt.Rows[i]["DetectTime"]), Convert.ToInt32(dt.Rows[i]["CNeg_incr"]));//下行量
                if (!HD.TotalVolumeList.Keys.Contains(Convert.ToDateTime(dt.Rows[i]["DetectTime"])))
                    HD.TotalVolumeList.Add(Convert.ToDateTime(dt.Rows[i]["DetectTime"]), Convert.ToInt32(dt.Rows[i]["CPos_incr"]) + Convert.ToInt32(dt.Rows[i]["CNeg_incr"]));//总量
            }
            HD.TotalVolume = HD.UpVolume + HD.DownVolume;//总流量
            HD.MaxDensity = HD.DensityList.Values.Max();
            HD.MaxSpeed = HD.SpeedList.Values.Max();
            HD.MinSpeed = HD.SpeedList.Values.Min();
            HD.MinDensity = HD.DensityList.Values.Min();

        }
        /// <summary>
        /// 初始化自定义类
        /// </summary>
        /// <param name="HD"></param>
        private void initData(HistoryData HD)
        {
            HD.TotalVolume = 0;
            HD.UpVolume = 0;
            HD.DownVolume = 0;
            HD.MaxDensity = 0;
            HD.MinDensity = 0;
            HD.MaxSpeed = 0;
            HD.MinSpeed = 0;
            HD.AlarmList.Clear();
            HD.DensityList.Clear();
            HD.DownVolmeList.Clear();
            HD.SpeedList.Clear();
            HD.TotalVolumeList.Clear();
            HD.UpVolumeList.Clear();
        }
    }

    class HistoryData
    {
        public int TotalVolume;
        public int UpVolume;
        public int DownVolume;
        public double MaxSpeed;
        public double MinSpeed;
        public double MaxDensity;
        public double MinDensity;
        public Dictionary<DateTime, int> TotalVolumeList = new Dictionary<DateTime, int>();
        public Dictionary<DateTime, int> UpVolumeList = new Dictionary<DateTime, int>();
        public Dictionary<DateTime, int> DownVolmeList = new Dictionary<DateTime, int>();
        public Dictionary<DateTime, int> AlarmList = new Dictionary<DateTime, int>();
        public Dictionary<DateTime, double> DensityList = new Dictionary<DateTime, double>();
        public Dictionary<DateTime, double> SpeedList = new Dictionary<DateTime, double>();
    }
}
