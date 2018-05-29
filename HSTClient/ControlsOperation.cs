/*----------------------------------------------------------------             
// Copyright (C) 2018 North China University of Technology             
// 版权所有。              
//              
// 文件名：ControlsOperation.cs       
// 文件功能描述： 
*控件相关操作类
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
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace HSTClient
{
    public class ControlsOperation
    {
        /// <summary>
        /// LED显示方法
        /// </summary>
        /// <param name="ctl1"></param>
        /// <param name="ctl2"></param>
        /// <param name="ctl3"></param>
        /// <param name="ctl4"></param>
        /// <param name="ctl5"></param>
        /// <param name="volume"></param>
        public void showVolume(LedCtl.LedCtl ctl1, LedCtl.LedCtl ctl2, LedCtl.LedCtl ctl3, LedCtl.LedCtl ctl4, LedCtl.LedCtl ctl5, int volume)
        {
            ctl1.DisplayNumber = volume / 10000;
            ctl2.DisplayNumber = (volume - ctl1.DisplayNumber * 10000) / 1000;
            ctl3.DisplayNumber = (volume - ctl1.DisplayNumber * 10000 - ctl2.DisplayNumber * 1000) / 100;
            ctl4.DisplayNumber = (volume - ctl1.DisplayNumber * 10000 - ctl2.DisplayNumber * 1000 - ctl3.DisplayNumber * 100) / 10;
            ctl5.DisplayNumber = (volume - ctl1.DisplayNumber * 10000 - ctl2.DisplayNumber * 1000 - ctl3.DisplayNumber * 100 - ctl4.DisplayNumber * 10);
        }
        /// <summary>
        /// 仪表盘显示方法
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="value"></param>
        public void showAsDashboard(InstrumentPanelLib.InstrumentPanelControl ctl, double value)
        {
            if (value > ctl.EndScaleValue)
            {
                value = 0;
            }
            else
            {
                ctl.CurrentValue = value;
                ctl.Invalidate();
            }
        }
        /// <summary>
        /// 饼状图显示方法
        /// </summary>
        /// <param name="PieChart">饼状图控件</param>
        /// <param name="UpValue">上行流量</param>
        /// <param name="DownValue">下行流量</param>
        public void showAsPieChart(System.Windows.Forms.DataVisualization.Charting.Chart PieChart,int UpValue,int DownValue)
        {
            PieChart.Series[0].Points.Clear();
            PieChart.Series[0].Points.AddXY("上行", UpValue);
            PieChart.Series[0].Points.AddXY("下行", DownValue);
        }
        /// <summary>
        /// 柱状图显示方法
        /// </summary>
        /// <param name="barChart">柱状图控件</param>
        /// <param name="WeekVolume">每周的流量数据</param>
        public void showAsBarGraph(System.Windows.Forms.DataVisualization.Charting.Chart barChart,List<int> WeekVolume)
        {
            barChart.Series[0].Points.Clear();
            barChart.Series[0].Points.AddXY("Mon.", WeekVolume[0]);
            barChart.Series[0].Points.AddXY("Tue.", WeekVolume[1]);
            barChart.Series[0].Points.AddXY("Wed.", WeekVolume[2]);
            barChart.Series[0].Points.AddXY("Thu.", WeekVolume[3]);
            barChart.Series[0].Points.AddXY("Fri", WeekVolume[4]);
            barChart.Series[0].Points.AddXY("Sat.", WeekVolume[5]);
            barChart.Series[0].Points.AddXY("Sun.", WeekVolume[6]);
        }
        public bool showWarning(double speed,double density, Threshold threshold)
        {
            if (density > threshold.DensityThreshold && speed > 0 && speed < threshold.SpeedThresshold)
            {
                return true;
            }
            else
                return false;
        }
        public void readThresholdFromDB(int camid, Threshold threshold)
        {
            Client.MySqlHelper mysql = new Client.MySqlHelper();
            string sqlString = string.Format("SELECT DensityThreshold, SpeedThresshold FROM tb_param WHERE CamID={0};", camid);
            try
            {
                DataTable dt = mysql.ExecuteDataTable(sqlString);
                double.TryParse(dt.Rows[0]["DensityThreshold"].ToString(), out threshold.DensityThreshold);
                double.TryParse(dt.Rows[0]["SpeedThresshold"].ToString(), out threshold.SpeedThresshold);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private Dictionary<Control, Size> ctl_size = new Dictionary<Control, Size>();
        private Dictionary<Control, Point> ctl_location = new Dictionary<Control, Point>();
        /// <summary>
        /// 控件自适应方法
        /// </summary>
        /// <param name="control"></param>
        /// <param name="size_x_proportion"></param>
        /// <param name="size_y_proportion"></param>
        public void ChangeWindowsSize(Control control,double size_x_proportion,double size_y_proportion)//X，Y缩放比例
        {
            GetControls(control);

            foreach (Control item in ctl_size.Keys)
            {
                if (item.GetType().Equals(typeof(Label)))
                {
                    item.Font =
                        new Font("微软雅黑",
                                      (float)(float.Parse(item.Font.Size.ToString()) * size_x_proportion),
                                      FontStyle.Regular);
                }
                else
                {
                    item.Size = new Size(
                        (int)(ctl_size[item].Width * size_x_proportion),
                        (int)(ctl_size[item].Height * size_y_proportion));
                }
            }
            foreach (Control item in ctl_location.Keys)
            {
                item.Location = new Point(
                    (int)(ctl_location[item].X * size_x_proportion),
                    (int)(ctl_location[item].Y * size_y_proportion));
            }

            ctl_size.Clear();
            ctl_location.Clear();
        }
        private void GetControls(Control fatherControl)
        {
            Control.ControlCollection sonControls = fatherControl.Controls;
            //遍历所有控件  
            foreach (Control control in sonControls)
            {
                if (control.Controls != null)
                {
                    ctl_size.Add(control, control.Size);
                    ctl_location.Add(control, control.Location);
                    GetControls(control);
                }
            }
        }  
    }
    public class Threshold
    {
        public double DensityThreshold;
        public double SpeedThresshold;
    }
}
