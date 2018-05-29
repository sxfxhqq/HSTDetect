/*----------------------------------------------------------------             
// Copyright (C) 2018 North China University of Technology             
// 版权所有。              
//              
// 文件名：MultiScreenControl.cs       
// 文件功能描述： 
 *分屏显示控件
// 创建人：谭磊
// 创建时间：2018-4-12
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
    public partial class MultiScreenControl : UserControl
    {
        public IntPtr[] handles = new IntPtr[9];
        public MultiScreenControl()
        {
            InitializeComponent();
        }

        private void MultiScreenControl_Load(object sender, EventArgs e)
        {
            handles[0] = this.pictureBox1.Handle;
            handles[1] = this.pictureBox2.Handle;
            handles[2] = this.pictureBox3.Handle;
            handles[3] = this.pictureBox4.Handle;
            handles[4] = this.pictureBox5.Handle;
            handles[5] = this.pictureBox6.Handle;
            handles[6] = this.pictureBox7.Handle;
            handles[7] = this.pictureBox8.Handle;
            handles[8] = this.pictureBox9.Handle;
        }

        private void MultiScreenControl_SizeChanged(object sender, EventArgs e)
        {
            this.pictureBox1.Location = new Point(0, 0);
            this.pictureBox2.Location = new Point(this.Size.Width / 3, 0);
            this.pictureBox3.Location = new Point(this.Size.Width / 3 * 2, 0);
            this.pictureBox4.Location = new Point(0, this.Size.Height / 3);
            this.pictureBox5.Location = new Point(this.Size.Width / 3, this.Size.Height / 3);
            this.pictureBox6.Location = new Point(this.Size.Width / 3 * 2, this.Size.Height / 3);
            this.pictureBox7.Location = new Point(0, this.Size.Height / 3 * 2);
            this.pictureBox8.Location = new Point(this.Size.Width/3,this.Size.Height/3*2);
            this.pictureBox9.Location = new Point(this.Size.Width/3*2,this.Size.Height/3*2);

            this.pictureBox1.Size = new Size(this.Size.Width / 3, this.Size.Height / 3);
            this.pictureBox2.Size = new Size(this.Size.Width / 3, this.Size.Height / 3);
            this.pictureBox3.Size = new Size(this.Size.Width / 3, this.Size.Height / 3);
            this.pictureBox4.Size = new Size(this.Size.Width / 3, this.Size.Height / 3);
            this.pictureBox5.Size = new Size(this.Size.Width / 3, this.Size.Height / 3);
            this.pictureBox6.Size = new Size(this.Size.Width / 3, this.Size.Height / 3);
            this.pictureBox7.Size = new Size(this.Size.Width / 3, this.Size.Height / 3);
            this.pictureBox8.Size = new Size(this.Size.Width / 3, this.Size.Height / 3);
            this.pictureBox9.Size = new Size(this.Size.Width / 3, this.Size.Height / 3);
        }
    }
}
