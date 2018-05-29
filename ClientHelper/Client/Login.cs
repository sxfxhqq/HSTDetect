/*----------------------------------------------------------------             
// Copyright (C) 2018 North China University of Technology             
// 版权所有。              
//              
// 文件名：Login.cs       
// 文件功能描述： 
/*
* 登录界面
* 2018-3-12
*/
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

namespace Client
{
    public partial class Login : Form
    {
        delegate void DoLogin();
        public bool ExitFlag = false;
        ManualResetEvent manu = new ManualResetEvent(false);
        bool flag = false;
        MySqlHelper Mysql = new MySqlHelper();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.label1.Parent = this.pictureBox1;
            this.label2.Parent = this.pictureBox1;
            this.pictureBox2.Parent = this.pictureBox1;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ExitFlag = true;
            this.Close();
            this.Dispose();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.button2.Hide();
            this.button3.Hide();
            this.label2.Show();
            DoLogin dl = new DoLogin(login);
            IAsyncResult IR = dl.BeginInvoke(new AsyncCallback(asyncCallback), null);
            manu.WaitOne();
            if (!flag)
            {
                MessageBox.Show("数据库未连接成功，请检查配置");
                ExitFlag = true;
            }
            this.Close();
            this.Dispose();
        }
        private void asyncCallback(IAsyncResult IR)
        {

        }
        private void login()
        {
            flag = Mysql.connectTest();
            manu.Set();
        }
    }
}
