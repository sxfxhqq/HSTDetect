/*----------------------------------------------------------------             
// Copyright (C) 2018 North China University of Technology             
// 版权所有。              
//              
// 文件名：MultiScreen.cs       
// 文件功能描述： 
 * 分屏显示界面
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
    public partial class MultiScreen : UserControl
    {
        private Client.VLCPlayer[] vlc = new Client.VLCPlayer[9];
        private Client.MySqlHelper mysql = new Client.MySqlHelper();
        private DataTable dt;
        private Dictionary<string, string> dic = new Dictionary<string, string>();
        private int count = 0;
        private MultiScreenControl msc = new MultiScreenControl();
        private List<int> SelectedNodesLst = new List<int>();
        public MultiScreen()
        {
            InitializeComponent();
            this.Visible = false;
        }
        
        private void MultiScreen_Load(object sender, EventArgs e)
        {
            this.panel1.Controls.Add(msc);
            msc.Dock = DockStyle.Fill;
        }
        private void MultiScreen_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                this.treeView1.ImageList = this.imageList1;

                for (int i = 0; i < vlc.Count(); i++)
                {
                    if (vlc[i] == null)
                    {
                        vlc[i] = new Client.VLCPlayer();
                    }
                }
                this.treeView1.Nodes[0].Nodes.Clear();
                try
                {
                    dt = mysql.ExecuteDataTable("Select * from tb_param");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        this.treeView1.Nodes[0].Nodes.Add(dt.Rows[i]["CamID"].ToString());
                        if (!dic.Keys.Contains(dt.Rows[i]["CamID"].ToString()))
                        {
                            dic.Add(dt.Rows[i]["CamID"].ToString(), dt.Rows[i]["url"].ToString());
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("读取参数错误");
                }
            }
            if(this.Visible == false)
            {
                realseSource();
            }
        }

        //private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    //string nodeselect = this.treeView1.SelectedNode.Text;
        //    //if (nodeselect != "摄像头")
        //    //{
        //    //    if (count == 9)
        //    //    {
        //    //        MessageBox.Show("请停止后再添加");
        //    //    }
        //    //    else
        //    //    {
        //    //        string url;
        //    //        dic.TryGetValue(nodeselect, out url);
        //    //        switch (count)
        //    //        {
        //    //            case 0:
        //    //                vlc[count].playUrl(url, msc.handles[0]);
        //    //                break;
        //    //            case 1:
        //    //                vlc[count].playUrl(url, msc.handles[1]);
        //    //                break;
        //    //            case 2:
        //    //                vlc[count].playUrl(url, msc.handles[2]);
        //    //                break;
        //    //            case 3:
        //    //                vlc[count].playUrl(url, msc.handles[3]);
        //    //                break;
        //    //            case 4:
        //    //                vlc[count].playUrl(url,msc.handles[4]);
        //    //                break;
        //    //            case 5:
        //    //                vlc[count].playUrl(url, msc.handles[5]);
        //    //                break;
        //    //            case 6:
        //    //                vlc[count].playUrl(url, msc.handles[6]);
        //    //                break;
        //    //            case 7:
        //    //                vlc[count].playUrl(url, msc.handles[7]);
        //    //                break;
        //    //            case 8:
        //    //                vlc[count].playUrl(url, msc.handles[8]);
        //    //                break;
        //    //        }
        //    //        count++;
        //    //    }
        //    //}
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            realseSource();
        }

        private Client.FullScreen frm;
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            if (frm == null)
            {
                frm = new Client.FullScreen();
            }
            msc.KeyDown += frm_KeyDown;
            msc.Dock = DockStyle.Fill;
            frm.Controls.Add(this.msc);
            frm.Show();
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
                if (frm != null)
                {
                    frm.Controls.Clear();
                    this.panel1.Controls.Add(this.msc);
                    frm.Close();
                    frm = null;
                }
            }
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string nodeselect = e.Node.Text;
            if (nodeselect != "摄像头")
            {
                if (SelectedNodesLst.Contains(int.Parse(nodeselect)))
                {
                    MessageBox.Show("已添加该摄像头");
                }
                else
                {
                    SelectedNodesLst.Add(int.Parse(nodeselect));
                    e.Node.NodeFont = new Font("微软雅黑", 10, FontStyle.Underline | FontStyle.Bold);
                    if (count == 9)
                    {
                        MessageBox.Show("请停止后再添加");
                    }
                    else
                    {
                        string url;
                        dic.TryGetValue(nodeselect, out url);
                        switch (count)
                        {
                            case 0:
                                vlc[count].playUrl(url, msc.handles[0]);
                                break;
                            case 1:
                                vlc[count].playUrl(url, msc.handles[1]);
                                break;
                            case 2:
                                vlc[count].playUrl(url, msc.handles[2]);
                                break;
                            case 3:
                                vlc[count].playUrl(url, msc.handles[3]);
                                break;
                            case 4:
                                vlc[count].playUrl(url, msc.handles[4]);
                                break;
                            case 5:
                                vlc[count].playUrl(url, msc.handles[5]);
                                break;
                            case 6:
                                vlc[count].playUrl(url, msc.handles[6]);
                                break;
                            case 7:
                                vlc[count].playUrl(url, msc.handles[7]);
                                break;
                            case 8:
                                vlc[count].playUrl(url, msc.handles[8]);
                                break;
                        }
                        count++;
                    }
                }
            }
        }

        private void realseSource()
        {
            SelectedNodesLst.Clear();
            count = 0;
            for (int i = 0; i < vlc.Count(); i++)
            {
                if (vlc[i] != null)
                    vlc[i].Stop();
            }
            foreach(TreeNode item in this.treeView1.Nodes[0].Nodes)
            {
                item.NodeFont = new Font("微软雅黑", 9, FontStyle.Regular);
            }
        }
        private PictureBox pb;
        int index = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Visible = false;
            this.comboBox1.Visible = true;
        }

        private void pb_DoubleClick(object sender, EventArgs e)
        {
            if (frm != null)
            {
                frm.Controls.Clear();
                this.msc.Controls.Add(pb);
                pb.Dock = DockStyle.None;
                pb.Location = msc.dictionary.Keys.ElementAt(index);
                frm.Close();
                frm = null;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.button2.Visible = true;
            this.comboBox1.Visible = false;
            if (frm == null)
            {
                frm = new Client.FullScreen();
            }
            if (int.TryParse(this.comboBox1.Text.ToString(), out index))
            {
                index -= 1;
                pb = msc.dictionary.Values.ElementAt(index);
                frm.Controls.Add(pb);
                pb.DoubleClick += pb_DoubleClick;
                pb.Dock = DockStyle.Fill;
                frm.ShowDialog();
            }
        }
    }

}
