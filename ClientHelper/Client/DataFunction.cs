/*----------------------------------------------------------------             
// Copyright (C) 2018 North China University of Technology             
// 版权所有。              
//              
// 文件名：DataFunction.cs       
// 文件功能描述： 数据操作及显示类
// 创建人：谭磊
// 创建时间：2018-3-12
// 修改人：
// 修改时间：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace Client
{
    public class DataFunction
    {
        #region【私有变量】
        private static MySqlHelper Mysql = new MySqlHelper();
        private static bool isPflowChartInited = false;
        private static bool isDensityChartInited = false;

        #endregion

        #region【公有函数】
        public static bool DataFlag = false;
        /// <summary>
        /// 读取数据库最新数据
        /// </summary>
        /// <param name="IDCam">摄像头编号</param>
        public static void readDataFromDB(int IDCam)
        {
            string sqlString = string.Format("SELECT * FROM PFLOW_TB_DATA WHERE CAMID={0} AND ID=(SELECT MAX(ID) FROM PFLOW_TB_DATA WHERE CAMID={0})", IDCam);
            try
            {
                DataTable dt = Mysql.ExecuteDataTable(sqlString);
                if (dt.Rows.Count > 0)
                {
                    if (HSTDataClass.ID != long.Parse(dt.Rows[0]["ID"].ToString()))
                    {
                        HSTDataClass.CNeg_incr = int.Parse(dt.Rows[0]["CNeg_incr"].ToString());
                        HSTDataClass.CPos_incr = int.Parse(dt.Rows[0]["CPos_incr"].ToString());
                        HSTDataClass.ID = long.Parse(dt.Rows[0]["ID"].ToString());
                        HSTDataClass.CamID = int.Parse(dt.Rows[0]["CamID"].ToString());
                        HSTDataClass.CNeg = int.Parse(dt.Rows[0]["CNeg"].ToString());
                        HSTDataClass.CPos = int.Parse(dt.Rows[0]["CPos"].ToString());
                        HSTDataClass.Density = double.Parse(dt.Rows[0]["Density"].ToString());
                        HSTDataClass.detectTime = DateTime.Parse(dt.Rows[0]["detecttime"].ToString());
                        HSTDataClass.Speed = double.Parse(dt.Rows[0]["Speed"].ToString());
                        HSTDataClass.increment = HSTDataClass.CNeg_incr + HSTDataClass.CPos_incr;
                        DataFlag = true;
                    }
                    else
                    {
                        DataFlag = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                DataFlag = false;
            }
        }
    
        /// <summary>
        /// 在chart上画折线图，5秒流量增量
        /// </summary>
        /// <param name="chart">流量折线图控件</param>
        public static void showAsChart_Pflow(Chart chart)
        {
            if (!isPflowChartInited)
                pflowChartInit(chart);
            chart.Series[0].Points.AddXY(HSTDataClass.detectTime.ToString("HH:mm:ss"), HSTDataClass.increment);

            chart.ChartAreas[0].AxisX.ScaleView.Position = chart.Series[0].Points.Count - 6;
        }
        
        /// <summary>
        /// 在chart上画折线图，平均速度
        /// </summary>
        /// <param name="chart">速度折线图控件</param>
        public static void showAsChart_Speed(Chart chart)//chart作图（速度）
        {
            if (!isDensityChartInited)
                densityChartInit(chart);
            chart.Series[0].Points.AddXY(HSTDataClass.detectTime.ToString("HH:mm:ss"), HSTDataClass.Speed);

            chart.ChartAreas[0].AxisX.ScaleView.Position = chart.Series[0].Points.Count - 6;
        }
        

        /// <summary>
        /// 数据库读取到的数据显示到网格表中
        /// </summary>
        /// <param name="dgv">网格表控件</param>
        public static void showAsGridView(DataGridView dgv)
        {
            dgv.Rows[0].Cells[0].Value = HSTDataClass.CamID;
            dgv.Rows[0].Cells[1].Value = HSTDataClass.increment;
            dgv.Rows[0].Cells[2].Value = HSTDataClass.CPos;
            dgv.Rows[0].Cells[3].Value = HSTDataClass.CNeg;
            dgv.Rows[0].Cells[4].Value = HSTDataClass.Speed;
            dgv.Rows[0].Cells[5].Value = HSTDataClass.Density;
            dgv.Rows[0].Cells[6].Value = "正常";
        }
        #endregion

        #region【私有函数】
        private static void pflowChartInit(Chart chart)//流量图初始化
        {
            chart.ChartAreas[0].AxisX.ScaleView.Size = 6;//X轴缩放大小
            isPflowChartInited = true;
        }
        private static void densityChartInit(Chart chart)//速度图初始化
        {
            chart.ChartAreas[0].AxisX.ScaleView.Size = 6;//X轴缩放大小
            isDensityChartInited = true;
        }
        #endregion
    }

    public class HSTDataClass //数据存储类
    {
        public static int CPos_incr;
        public static int CNeg_incr;
        public static long ID;
        public static int increment;
        public static int CamID;
        public static DateTime detectTime;
        public static int CPos;
        public static int CNeg;
        public static double Speed;
        public static double Density;
    }

    public class EmulateData //模拟数据类
    {
        private static Random rand = new Random();
        public static void doEmulate(int id)
        {
            HSTDataClass.CamID = id;
            HSTDataClass.CNeg += rand.Next(50);
            HSTDataClass.CPos += rand.Next(50);
            HSTDataClass.Density = rand.Next(10);
            HSTDataClass.detectTime = DateTime.Now;
            HSTDataClass.Speed = rand.Next(5);
            HSTDataClass.increment = rand.Next(100);
        }
    }
}
