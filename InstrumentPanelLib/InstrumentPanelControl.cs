using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace InstrumentPanelLib
{
    public partial class InstrumentPanelControl : UserControl
    {
        /// <summary>
        /// 初始化控件
        /// 设置绘图参数
        /// </summary>
        public InstrumentPanelControl()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            StepTimer = new Timer();
            StepTimer.Interval = 10;
            StepTimer.Tick +=new EventHandler(StepTimer_Tick);
        }

        /// <summary>
        /// 仪表盘边框颜色
        /// </summary>
        private Color panelFrameColor = Color.LightGray;
        [CategoryAttribute("背景"), Description("仪表盘边框颜色")]
        public Color PanelFrameColor
        {
            set { panelFrameColor = value; }
            get { return panelFrameColor; }
        }

        /// <summary>
        /// 仪表盘背景颜色
        /// </summary>
        private Color panelBackColor = Color.White;
        [CategoryAttribute("背景"), Description("仪表盘背景颜色")]
        public Color PanelBackColor
        {
            set { panelBackColor = value; }
            get { return panelBackColor; }
        }

        /// <summary>
        /// 仪表盘中心圆点的颜色
        /// </summary>
        private Color centerPointerColor = Color.Black;
        [CategoryAttribute("背景"), Description("仪表盘中心圆点的颜色")]
        public Color CenterPointerColor
        {
            set { centerPointerColor = value; }
            get { return centerPointerColor; }
        }

        /// <summary>
        /// 仪表盘大刻度的数量
        /// </summary>
        private int bigScaleNum = 5;
        [CategoryAttribute("刻度"), Description("仪表盘大刻度的数量")]
        public int BigScaleNum
        {
            set { bigScaleNum = value; }
            get { return bigScaleNum; }
        }

        /// <summary>
        /// 仪表盘小刻度的数量
        /// </summary>
        private int smallScaleNum = 5;
        [CategoryAttribute("刻度"), Description("仪表盘小刻度的数量")]
        public int SmallScaleNum
        {
            set { smallScaleNum = value; }
            get { return smallScaleNum; }
        }

        /// <summary>
        /// 仪表盘大刻度的颜色
        /// </summary>
        private Color bigScaleColor = Color.Black;
        [CategoryAttribute("刻度"), Description("仪表盘大刻度的颜色")]
        public Color BigScaleColor
        {
            set { bigScaleColor = value; }
            get { return bigScaleColor; }
        }

        /// <summary>
        /// 仪表盘小刻度的颜色
        /// </summary>
        private Color smallScaleColor = Color.Black;
        [CategoryAttribute("刻度"), Description("仪表盘小刻度的颜色")]
        public Color SmallScaleColor
        {
            set { smallScaleColor = value; }
            get { return smallScaleColor; }
        }

        /// <summary>
        /// 仪表盘上数字刻度的颜色
        /// </summary>
        private Color numberScaleColor = Color.Black;
        [CategoryAttribute("刻度"), Description("表盘上数字刻度的颜色")]
        public Color NumberScaleColor
        {
            set { numberScaleColor = value; }
            get { return numberScaleColor; }
        }

        /// <summary>
        /// 仪表盘上数字刻度的字体,大小,粗细
        /// </summary>
        private Font numberScaleFont = new Font("Arial", 20);
        [CategoryAttribute("刻度"), Description("仪表盘上数字刻度的字体,大小,粗细")]
        public Font NumberScaleFont
        {
            set { numberScaleFont = value; }
            get { return numberScaleFont; }
        }

        /// <summary>
        /// 刻度起始角度
        /// 3点钟处为0度,顺时正,逆时负
        /// </summary>
        private int beginScaleAngle = -225;
        [CategoryAttribute("刻度"), Description("刻度起始角度")]
        public int BeginScaleAngle
        {
            set { beginScaleAngle = value; }
            get { return beginScaleAngle; }
        }

        /// <summary>
        /// 刻度终止角度
        /// </summary>
        private int endScaleAngle = 45;
        [CategoryAttribute("刻度"), Description("刻度终止角度")]
        public int EndScaleAngle
        {
            set { endScaleAngle = value; }
            get { return endScaleAngle; }
        }
        
        /// <summary>
        /// 刻度起始表示的数值
        /// </summary>
        private double beginScaleValue = 0;
        [CategoryAttribute("刻度"), Description("刻度起始表示的数值")]
        public double BeginScaleValue
        {
            set { beginScaleValue = value; }
            get { return beginScaleValue; }
        }

        /// <summary>
        /// 刻度终止表示的数值
        /// </summary>
        private double endScaleValue = 100;
        [CategoryAttribute("刻度"), Description("刻度终止表示的数值")]
        public double EndScaleValue
        {
            set { endScaleValue = value; }
            get { return endScaleValue; }
        }

        /// <summary>
        /// 指针颜色
        /// </summary>
        private Color pointerColor = Color.Black;
        [CategoryAttribute("背景"), Description("指针颜色")]
        public Color PointerColor
        {
            set { pointerColor = value; }
            get { return pointerColor; }
        }

        /// <summary>
        /// 当前指针所指的数值
        /// </summary>
        private double currentValue = 0;
        [CategoryAttribute("数值"), Description("当前指针所指的数值")]
        public double CurrentValue
        {
            set { currentValue = value; }
            get { return currentValue; }
        }

        /// <summary>
        /// 指针转动的步进值
        /// </summary>
        private double stepValue = 1;
        [CategoryAttribute("数值"), Description("指针转动的步进值")]
        public double StepValue
        {
            set { stepValue = value; }
            get { return stepValue; }
        }

        /// <summary>
        /// 指针跳动一个步进值的时间间隔(默认25ms)
        /// </summary>
        private int stepTimeInterval = 25;
        [CategoryAttribute("数值"), Description("指针跳动一个步进值的时间间隔(默认25ms)")]
        public int StepTimeInterval
        {
            set { stepTimeInterval = value; }
            get { return stepTimeInterval; }
        }

        private Graphics g;
        private double LastValue;
        private Timer StepTimer;

        /// <summary>
        /// 定时器响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StepTimer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            StepTimer.Stop();
        }

        /// <summary>
        /// 控件绘制响应控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InstrumentPanelControl_Paint(object sender, PaintEventArgs e)
        {
            // 判断当前数值是否在表盘最大和最小值的范围内
            if (currentValue > endScaleValue || currentValue < beginScaleValue)
            {
                MessageBox.Show("当前设置的指针数值超出仪表盘范围,仪表盘重新将当前值设置为了最小值!");
                currentValue = beginScaleValue;
            }

            // 进行步进跳动计算,使仪表平滑移动到下一个数值的地方
            if (currentValue > LastValue)
            {
                if ((currentValue - LastValue) > stepValue)
                {
                    LastValue += stepValue;
                    StepTimer.Start();
                }
                else
                {
                    LastValue = currentValue;
                }
            }
            else
            {
                if ((LastValue - currentValue) > stepValue)
                {
                    LastValue -= stepValue;
                    StepTimer.Start();
                }
                else
                {
                    LastValue = currentValue;
                }
            }


            // 创建画板和设置画板
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            // 获取仪表盘直径
            int diameter;
            if (this.Width > this.Height)
                diameter = this.Height;
            else
                diameter = this.Width;
            float centerPoint = diameter / 2;
            diameter -= 5;

            // 绘制仪表盘背景色和边框
            g.FillEllipse(new SolidBrush(panelBackColor), 2, 2, diameter, diameter);
            g.DrawEllipse(new Pen(panelFrameColor, 4), 2, 2, diameter, diameter);

            // 绘制仪表盘刻度
            int bigScaleLength = diameter / 10;
            int smallScaleLength = bigScaleLength / 2;
            int scaleCount = smallScaleNum * bigScaleNum;
            float scaleInterval = (float)(endScaleAngle - beginScaleAngle) / scaleCount;
            g.TranslateTransform(centerPoint, centerPoint);
            g.RotateTransform((float)beginScaleAngle);
            g.DrawLine(new Pen(bigScaleColor, 4), (diameter / 2 - smallScaleLength / 2), 0, (diameter / 2 - bigScaleLength), 0);
            for (int i = 1; i <= scaleCount; i++)
            {
                g.RotateTransform(scaleInterval);
                if ((i % smallScaleNum) == 0)
                {
                    g.DrawLine(new Pen(bigScaleColor, 4), (diameter / 2 - smallScaleLength / 2), 0, (diameter / 2 - bigScaleLength), 0);
                }
                else
                {
                    g.DrawLine(new Pen(smallScaleColor, 2), (diameter / 2 - smallScaleLength / 2), 0, (diameter / 2 - smallScaleLength), 0);
                }
            }
            g.ResetTransform();
            g.TranslateTransform(centerPoint, centerPoint);

            // 绘制数字
            double intervalScaleValue = (endScaleValue - beginScaleValue) / bigScaleNum;
            double intervalAngle = (double)(endScaleAngle - beginScaleAngle) / bigScaleNum;
            double mathL = (diameter - diameter / 10 * 3) / 2;
            StringFormat drawNumberFormat = new StringFormat(StringFormatFlags.NoClip);
            drawNumberFormat.LineAlignment = StringAlignment.Center;
            drawNumberFormat.Alignment = StringAlignment.Center;
            for (int i = 0; i <= bigScaleNum; i++)
            {
                double radian = (beginScaleAngle + i * intervalAngle) * Math.PI / 180;
                double mathX = mathL * Math.Cos(radian);
                double mathY = mathL * Math.Sin(radian);
                double stringNumber = beginScaleValue + i * intervalScaleValue;
                g.DrawString(stringNumber.ToString(), numberScaleFont, new SolidBrush(numberScaleColor), (float)mathX, (float)mathY, drawNumberFormat);
            }

            // 绘制当前指针的位置
            int pointerLength = diameter / 2 * 8 / 10;
            double perAngle = (double)(endScaleAngle - beginScaleAngle) / (endScaleValue - beginScaleValue);
            g.RotateTransform((float)(beginScaleAngle + LastValue * perAngle));
            g.DrawLine(new Pen(pointerColor, 3), 0, 0, pointerLength, 0);

            // 绘制中心圆环
            int centerAnnulusDiameter = diameter / 30;
            g.DrawEllipse(new Pen(centerPointerColor, 3), -centerAnnulusDiameter, -centerAnnulusDiameter, centerAnnulusDiameter * 2, centerAnnulusDiameter * 2);
            g.FillEllipse(new SolidBrush(centerPointerColor), -centerAnnulusDiameter / 2, -centerAnnulusDiameter / 2, centerAnnulusDiameter, centerAnnulusDiameter);
            g.ResetTransform();
        }
    }
}
