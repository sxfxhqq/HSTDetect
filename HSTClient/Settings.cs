/*----------------------------------------------------------------             
// Copyright (C) 2018 North China University of Technology             
// 版权所有。              
//              
// 文件名：Settings.cs       
// 文件功能描述： 
 * 参数设置界面
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
    public partial class Settings : UserControl
    {
        private SettingsOperation sop = new SettingsOperation();
        public Settings()
        {
            InitializeComponent();
            this.Visible = false;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Settings_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                sop.ReadCameraParam(this.dataGridView);
            }
        }

        private void Btn_CaculateParam_Click(object sender, EventArgs e)
        {
            sop.ReadCaculateParam(this.dataGridView);
        }

        private void Btn_CamParam_Click(object sender, EventArgs e)
        {
            sop.ReadCameraParam(this.dataGridView);
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            this.Btn_Add.Enabled = false;
            sop.AddNewParam(this.dataGridView);
        }

        private void Btn_Delet_Click(object sender, EventArgs e)
        {
            sop.DeleteParam(this.dataGridView);
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认保存？", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                sop.SaveParam(this.dataGridView);
                this.Btn_Add.Enabled = true;
            }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            sop.CancelParam(this.dataGridView);
            this.Btn_Add.Enabled = true;
        }
    }
}
