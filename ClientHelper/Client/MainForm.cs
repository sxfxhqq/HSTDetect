using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Configuration;

namespace Client
{
    public partial class CarDetect : Form
    {
        #region【私有变量】
        private System.Windows.Forms.Timer timer;//5秒定时器
        private int IDCam;//摄像头编号
        #endregion
        public CarDetect()
        {
            InitializeComponent();
        }
        private void CarDetect_Load(object sender, EventArgs e)
        {
            this.skinEngine1.SkinFile = @"Skins/Silver.ssk";//加载窗体皮肤
            //初始化
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000;
            timer.Tick += timer_Tick;
            //
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            /*模拟数据 */
          //  EmulateData.doEmulate(IDCam);
            /*真实数据 */
            DataFunction.readDataFromDB(IDCam);
            DataFunction.showAsGridView(this.DataGrid);
            DataFunction.showAsChart_Pflow(this.chart_Volumn);
            DataFunction.showAsChart_Speed(this.chart_Speed);
        }

        #region【全屏功能】
        private FullScreen frm;
        private void Btn_FullScreen_Click(object sender, EventArgs e)//全屏
        {
            if (frm == null)
            {
                frm = new FullScreen();
            }
            frm.KeyDown += frm_KeyDown;
            frm.Controls.Add(this.PB_Monitor);
            frm.ShowDialog();
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
                this.Panel_Monitor.Controls.Add(this.PB_Monitor);
                frm.Close();
                frm = null;
            }
        }
        #endregion

        #region【开始监控】
        private bool isPlaying = false;//是否正在播放标志位
        private void Btn_Begin_Click(object sender, EventArgs e)//开始监控
        {
            if (Cbo_ID.Text.Equals(""))
                MessageBox.Show("请选择线路");
            else if (!int.TryParse(Cbo_ID.Text, out IDCam))
                MessageBox.Show("请输入正确的线路编号");
            else
            {
                IDCam = int.Parse(Cbo_ID.Text);
                if (isPlaying)
                {
                    VLCPlayer.getInstance().release();//释放VLC资源
                }
                try
                {
                     //播放网络视频,读取url
                    VLCPlayer.getInstance().playUrl(ConfigClass.getInstance().getValue("url" + Cbo_ID.Text), this.PB_Monitor.Handle);
                    // //播放本地视频
                    //VLCPlayer.getInstance().playLocalVideo(@"C:\Users\Tony\Desktop\CAM220140529142103.avi", this.PB_Monitor.Handle);
                    // //
                    isPlaying = true;
                    timer.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("配置文件未找到线路信息，请检查后重试");
                }
            }
        }
        #endregion

        private void Btn_PTZ_Click(object sender, EventArgs e)
        {


        }
        private void Btn_RoiArea_Click(object sender, EventArgs e)
        {

        }
        #region【MenuStrip】
        private void 实时监控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                foreach (Control item in Controls)
                {
                    if (item.GetType().ToString().Equals("Client.AllCams"))
                    {
                        Controls.Remove(item);
                        break;
                    }
                    if (item.GetType().ToString().Equals("Client.HistAlarm"))
                    {
                        Controls.Remove(item);
                        break;
                    }
                    if (item.GetType().ToString().Equals("Client.ParamControl"))
                    {
                        Controls.Remove(item);
                        break;
                    }
                    if (item.GetType().ToString().Equals("Client.HistData"))
                    {
                        Controls.Remove(item);
                        break;
                    }
                }
            }
        }
        
        private void 路段信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllCams AC = new AllCams();
            Controls.Add(AC);
            AC.Dock = DockStyle.Fill;
            AC.BringToFront();
        }

        private void 历史报警ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistAlarm HA = new HistAlarm();
            Controls.Add(HA);
            HA.Dock = DockStyle.Fill;
            HA.BringToFront();

        }

        private void 历史数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistData HD = new HistData();
            Controls.Add(HD);
            HD.Dock = DockStyle.Fill;
            HD.BringToFront();
        }

        private void 参数设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ParamControl PC = new ParamControl();
            Controls.Add(PC);
            PC.Dock = DockStyle.Fill;
            PC.BringToFront();
        }
        #endregion
    }
  
}