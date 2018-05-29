using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace LedCtl
{
	/// <summary>
	/// Led�еĶΣ�һ�������ʻ������߶�֮һ
	/// </summary>
	public struct Section
	{
		public Section(int numberofPoints)
		{
			this.P=new Point[numberofPoints];
		}
		/// <summary>
		/// ������
		/// </summary>
		public Point[] P;
	}


	/// <summary>
	/// LedCtl : ģ���߶�ʽ����ܵĿؼ�
	/// </summary>
	public class LedCtl : System.Windows.Forms.UserControl
	{
		/// <summary>
		/// ����ֽ�����������Щ�α�������
		/// </summary>
		private byte m_DisplayCode=(byte)0x37;

		/// <summary>
		/// ��Ϩ��ʱ����ɫ������Ϊǰ��ɫ
		/// </summary>
		private Color m_OffColor=Color.FromArgb(20,50,50);

		/// <summary>
		/// ��offcolor����Ϩ��ʻ��ı�Ե���������������
		/// </summary>
		private bool b_DrawSectionBorder=true;
		/// <summary>
		/// ��ˢ
		/// </summary>
		private SolidBrush m_Brush;
		/// <summary>
		/// Ǧ��
		/// </summary>
		private Pen m_Pen;
		/// <summary>
		/// �ʻ����
		/// </summary>
		private int m_SectionThick=5;
		/// <summary>
		/// ��0~6�����飡����ע�⣬��7�β�������С���㣡����
		/// </summary>
		private Section[] m_Sections=new Section[7];
		/// <summary>
		/// ���½ǵ�С����
		/// </summary>
		private Point m_Dot=new Point(0,0);
		
		/// <summary>
		/// һЩ�������ַ�����
		/// </summary>
		private byte[] m_NumCodes=
			{
				(byte)0x7d,//0
				(byte)0x50,//1
				(byte)0x37,//2
				(byte)0x57,//3
				(byte)0x5a,//4
				(byte)0x4f,//5
				(byte)0x6f,//6
				(byte)0x54,//7
				(byte)0x7f,//8
				(byte)0x5f,//9
				(byte)0x00,//turn off all sections
				(byte)0x02,//-
			};
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;


		/// <summary>
		/// ���캯��
		/// </summary>
		public LedCtl()
		{
			InitializeComponent();
			//����˫����ģʽ
			this.SetStyle(
				ControlStyles.DoubleBuffer
				|ControlStyles.AllPaintingInWmPaint
				|ControlStyles.UserPaint
				|ControlStyles.ResizeRedraw,
				true);
			this.UpdateStyles();
			this.m_Pen=new Pen(this.m_OffColor);
			this.m_Brush=new SolidBrush(this.BackColor);
			for(int i=0;i<this.m_Sections.Length;i++)
			{
				this.m_Sections[i]=new Section(6);
			}
			//���������
			this.ComputeSections(this.Width,this.Height);
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region �����������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭�� 
		/// �޸Ĵ˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// LedCtl
			// 
			this.BackColor = System.Drawing.Color.Black;
			this.ForeColor = System.Drawing.Color.Lime;
			this.Name = "LedCtl";
			this.Size = new System.Drawing.Size(64, 136);
			this.Resize += new System.EventHandler(this.LedCtl_Resize);
			this.SizeChanged += new System.EventHandler(this.LedCtl_SizeChanged);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.LedCtl_Paint);

		}
		#endregion

		/// <summary>
		/// ���û��߻�ȡ�Ƿ����Ϩ��section��border������������
		/// </summary>
		public bool DrawSectionBorder
		{
			get{return this.b_DrawSectionBorder;}
			set
			{
				if(this.b_DrawSectionBorder!=value)
				{
					this.b_DrawSectionBorder=value;
					this.Invalidate();
				}
			}
		}
		/// <summary>
		/// ��ȡ����������ʾ��
		/// </summary>
		public byte DisplayCode
		{
			get
			{
				return this.m_DisplayCode;
			}
			set
			{
				if(this.m_DisplayCode!=value)
				{
					this.m_DisplayCode=value;
					this.Invalidate();
				}
			}
		}

		/// <summary>
		/// ������ʾ�����֣�������
		/// </summary>
		public int DisplayNumber
		{
			get
			{
				//�������-1˵����ʾ�Ĳ������֣�����
				return Array.IndexOf(this.m_NumCodes,(byte)this.m_DisplayCode);
			}
			set
			{
				if(value<0 ||value>9)
				{
					//����ǳ�����0~9�ķ�Χ����ȫϨ��
					this.DisplayCode=(byte)0x00;
					return;
				}
				this.DisplayCode=this.m_NumCodes[value];
			}
		}

		/// <summary>
		/// ��ȡ�������ñʻ����
		/// </summary>
		public int SectionThick
		{
			get
			{
				return this.m_SectionThick;
			}
			set
			{
				if(this.m_SectionThick!=value)
				{
					this.m_SectionThick=value;
					this.ComputeSections(this.Width,this.Height);
					this.Invalidate();
				}
			}
		}

		/// <summary>
		/// ��ȡ������Ϩ����ɫ
		/// </summary>
		public Color OffColor
		{
			get
			{
				return this.m_OffColor;
			}
			set
			{
				if(this.m_OffColor!=value)
				{
					this.m_OffColor=value;
					this.Invalidate();
				}
			}
		}
		/// <summary>
		/// ���Ʒ���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LedCtl_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g=e.Graphics;
			//g.SmoothingMode=System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//������ݣ�
			//��䱳��
			this.m_Brush.Color=this.BackColor;
			g.FillRectangle(this.m_Brush,0,0,this.Height,this.Height);			
			//�����߶�
			for(int i=0;i<this.m_Sections.Length;i++)
			{
				if((this.m_DisplayCode & (1<<i))!=0)
				{
					this.m_Brush.Color=this.ForeColor;
					g.FillPolygon(this.m_Brush,this.m_Sections[i].P);
				}
				else
				{
					//Ϩ��
					if(!this.b_DrawSectionBorder)
					{
						this.m_Brush.Color=this.m_OffColor;
						g.FillPolygon(this.m_Brush,this.m_Sections[i].P);
					}
					else
					{
						this.m_Pen.Color=this.m_OffColor;
						g.DrawPolygon(this.m_Pen,this.m_Sections[i].P);
					}
				}
			}
		}

		/// <summary>
		/// ���¼���ε����꣡���������ַ����ó���ͼ�ν���ʸ���ģ���������Ӱ�죩
		/// </summary>
		private void ComputeSections(int ledwidth,int ledheight)
		{
			//������ؼ����ĵ������
			int cx=ledwidth/2;
			int cy=ledheight/2;

			int t1=this.m_SectionThick*3/4;	//��б�³�
			int t2=this.m_SectionThick/4;	//Сб�³�
			int t3=this.m_SectionThick/2;	//��б�³�
			//�ε�һ�볤�ȣ�
			int hw=cx-this.m_SectionThick-4;	//half width of section �����Ե2����
			int hh=cy-this.m_SectionThick-4;	//half height of section
			Section[] s=this.m_Sections;

			//��0�Σ������һ�ᣩ
			s[0].P[0].X=cx-hw-this.m_SectionThick*5/16;
			s[0].P[0].Y=cy+hh+this.m_SectionThick*3/16;
			s[0].P[1].X=s[0].P[0].X-t2;
			s[0].P[1].Y=s[0].P[0].Y-t2;
			s[0].P[2].X=s[0].P[1].X+t1;
			s[0].P[2].Y=s[0].P[1].Y-t1;

			//��1��(�����м��һ�ᣬ��Ϊ�������κζζ�û�Գƹ�ϵ��ֻ����д��)
			s[1].P[0].X=cx-hw+this.m_SectionThick*5/16;
			s[1].P[0].Y=cy+t3;
			s[1].P[1].X=s[1].P[0].X-t3;
			s[1].P[1].Y=s[1].P[0].Y-t3;
			s[1].P[2].X=s[1].P[0].X;
			s[1].P[2].Y=cy-t3;

			//��2��(������һ�ᣬ���0�ΰ�y��Գ�)
			for(int i=0;i<3;i++)
			{
				s[2].P[i].X=s[0].P[2-i].X;
				s[2].P[i].Y=ledheight-s[0].P[2-i].Y;
			}
			//ѭ��Ϊ0��1��2����ˮƽ�ε�p[3],p[4],p[5]��ֵ��ע���⼸��ֵ���Ը���Ǯ���������
			for(int i=0;i<3;i++)
			{
				for(int j=3;j<6;j++)
				{
					s[i].P[j].X=ledwidth-s[i].P[5-j].X;
					s[i].P[j].Y=s[i].P[5-j].Y;
				}
			}
			//�����������Ѿ��������0��1��2�ε�ȫ�����꣬���濪ʼ����3~6�Σ����Ǿ����໥�ԳƵĹ�ϵ��
			
			//��3�Σ����ϵ�����(ע�Ȿ���Լ�Ҳ���߱��Գƹ�ϵ��6���㶼Ҫ��д)
			s[3].P[0].X=cx-hw+this.m_SectionThick/5;
			s[3].P[0].Y=cy-this.m_SectionThick*3/5;
			s[3].P[1].X=s[3].P[0].X-t3;
			s[3].P[1].Y=s[3].P[0].Y+t3;
			s[3].P[2].X=s[3].P[1].X-t3;
			s[3].P[2].Y=s[3].P[1].Y-t3;
			s[3].P[3].X=s[3].P[2].X;
			s[3].P[3].Y=s[3].P[0].Y-hh+this.m_SectionThick;
			s[3].P[4].X=s[3].P[3].X+t2;
			s[3].P[4].Y=s[3].P[3].Y-t2;
			s[3].P[5].X=s[3].P[4].X+t1;
			s[3].P[5].Y=s[3].P[4].Y+t1;

			//����4,5,6�εĵ����꣨4��3��x�Գ�,5��3��y�Գ�,6��3��ԭ��Գƣ�
			for(int i=0;i<6;i++)
			{
				int m=(8-i)%6;
				s[4].P[i].X=ledwidth-s[3].P[m].X;
				s[4].P[i].Y=s[3].P[m].Y;

				s[5].P[i].X=s[3].P[m].X;
				s[5].P[i].Y=ledheight-s[3].P[m].Y;

				s[6].P[i].X=ledwidth-s[3].P[i].X;
				s[6].P[i].Y=ledheight-s[3].P[i].Y;
			}
		}

		/// <summary>
		/// �ı��Сʱ��Ҫ���¼���sections
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LedCtl_SizeChanged(object sender, System.EventArgs e)
		{
			this.ComputeSections(this.Width,this.Height);
		}

		private void LedCtl_Resize(object sender, System.EventArgs e)
		{
			this.ComputeSections(this.Width,this.Height);		
		}

	}
}
