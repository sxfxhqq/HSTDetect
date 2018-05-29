/*----------------------------------------------------------------             
// Copyright (C) 2018 North China University of Technology             
// 版权所有。              
//              
// 文件名：OtherSettings.cs       
// 文件功能描述： 
 * 其他参数设置界面
// 创建人：谭磊
// 创建时间：2018-5-12
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
    public partial class OtherSettings : UserControl
    {
        public OtherSettings()
        {
            InitializeComponent();
        }

        private void Btn_Confirm_Click(object sender, EventArgs e)
        {
            if (this.dateTime.Value != null && this.cbo_weather.Text != null && this.tbo_temperature.Text != null && this.tbo_wind.Text != null)
            {
                float temperature;
                if (float.TryParse(this.tbo_temperature.Text, out temperature))
                {
                    DateTime dt = this.dateTime.Value;
                    string weather = this.cbo_weather.Text.ToString();
                    string wind = this.tbo_wind.Text;
                    Client.MySqlHelper mysql = new Client.MySqlHelper();
                    string sqlString = string.Format("INSERT INTO tb_weather SET time='{0}',weather='{1}',temperature={2},wind='{3}';", dt, weather, temperature, wind);
                    try
                    {
                        mysql.ExecuteNonQuery(sqlString);
                        WeatherDetail detail = new WeatherDetail();
                        detail.weather = new Weather();
                        detail.wind = new Wind();
                        detail.publish_time = dt.ToString();
                        detail.weather.temperature = temperature;
                        detail.wind.power = wind;
                        detail.weather.info = weather;
                        WeatherUpdate.update(detail);
                        this.tbo_temperature.Text = "";
                        this.tbo_wind.Text = "";
                        this.cbo_weather.Text = "";
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show("写入数据库失败");
                    }
                }
                else
                    MessageBox.Show("请输入正确温度");
            }
            else
                MessageBox.Show("请输入全部信息");
        }

    }
}
