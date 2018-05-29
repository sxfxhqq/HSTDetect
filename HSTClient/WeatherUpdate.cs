using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace HSTClient
{
    public class WeatherUpdate
    {
        public static Label LB_NetState;
        public static Label LB_Weather;
        public static PictureBox Pic_Weather;
        public static Label LB_Tem;
        public static Label LB_WindPower;
        private static Client.MySqlHelper mysql = new Client.MySqlHelper();
        public static void update(WeatherDetail detail)
        {
            //天气
            LB_NetState.Text = "测试中";
            LB_NetState.ForeColor = Color.White;
            LB_Weather.Text = detail.weather.info;
            int index = -1;
            if (detail.weather.info.Contains("晴"))
                index = 0;
            else if (detail.weather.info.Contains("雨"))
                index = 1;
            else if (detail.weather.info.Contains("雪"))
                index = 2;
            else if (detail.weather.info.Contains("阴"))
                index = 3;
            else if (detail.weather.info.Contains("云"))
                index = 4;
            else if (detail.weather.info.Contains("雹"))
                index = 5;
            else if (detail.weather.info.Contains("雾") || detail.weather.info.Contains("霾"))
                index = 6;
            else if (detail.weather.info.Contains("沙"))
                index = 7;
            switch (index)
            {
                case 0:
                    Pic_Weather.Image = Image.FromFile(@"img/weather_sunshine.jpg");
                    break;
                case 1:
                    Pic_Weather.Image = Image.FromFile(@"img/weather_rain.png");
                    break;
                case 2:
                    Pic_Weather.Image = Image.FromFile(@"img/weather_snow.png");
                    break;
                case 3:
                    Pic_Weather.Image = Image.FromFile(@"img/weather_Overcast.png");
                    break;
                case 4:
                    Pic_Weather.Image = Image.FromFile(@"img/weather_Cloudy2sunny.png");
                    break;
                case 5:
                    Pic_Weather.Image = Image.FromFile(@"img/weather_hail.png");
                    break;
                case 6:
                    Pic_Weather.Image = Image.FromFile(@"img/weather_Haze.png");
                    break;
                case 7:
                    Pic_Weather.Image = Image.FromFile(@"img/weather_sand.png");
                    break;
            }
            //温度
            LB_Tem.Text = detail.weather.temperature.ToString() + "℃";
            //风力
            LB_WindPower.Text = detail.wind.power.ToString();
        }
        public static void readWeatherDetail()
        {
            string sqlString = string.Format("SELECT * FROM tb_weather WHERE uuid=(SELECT MAX(uuid) FROM tb_weather);");
            WeatherDetail detail = new WeatherDetail();
            detail.weather = new Weather();
            detail.wind = new Wind();
            try
            {
                DataTable dt= mysql.ExecuteDataTable(sqlString);
                detail.publish_time = dt.Rows[0]["time"].ToString();
                detail.weather.info = dt.Rows[0]["weather"].ToString();
                detail.wind.power = dt.Rows[0]["wind"].ToString();
                detail.weather.temperature = float.Parse(dt.Rows[0]["temperature"].ToString());
                update(detail);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
