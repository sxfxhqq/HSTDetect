/*----------------------------------------------------------------             
// Copyright (C) 2018 North China University of Technology             
// 版权所有。              
//              
// 文件名：FullScreen.cs       
// 文件功能描述： 
/*
* 仅供全屏显示窗体用
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

namespace Client
{
    public partial class FullScreen : Form
    {
        public FullScreen()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;//设置在任务栏中不显示图标
        }
    }
}
