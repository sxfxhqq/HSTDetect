/*----------------------------------------------------------------             
// Copyright (C) 2018 North China University of Technology             
// 版权所有。              
//              
// 文件名：WeatherClass.cs       
// 文件功能描述： 
 * 天气查询类
// 创建人：谭磊
// 创建时间：2018-4-12
// 修改人：
// 修改时间：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace HSTClient
{
    public class WeatherClass
    {
        public bool WeatherQuery(string provice, string city, out WeatherDetail detailResult)
        {
            try
            {
                HttpWebRequest request = WebRequest.CreateHttp(@"http://www.nmc.gov.cn/f/rest/province");

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string content = reader.ReadToEnd();
                List<Province> provinceResult = JsonConvert.DeserializeObject<List<Province>>(content);
                Dictionary<string, string> proviceNamedict = new Dictionary<string, string>();
                provinceResult.ForEach(x =>
                {
                    if (!proviceNamedict.Keys.Contains(x.name))
                    {
                        proviceNamedict.Add(x.name, x.code);
                    }
                });
                string str = string.Format(@"http://www.nmc.gov.cn/f/rest/province/{0}", proviceNamedict[provice]);
                request = WebRequest.CreateHttp(str);
                response = request.GetResponse() as HttpWebResponse;
                stream = response.GetResponseStream();
                reader = new StreamReader(stream);
                content = reader.ReadToEnd();
                List<City> cityResult = JsonConvert.DeserializeObject<List<City>>(content);
                Dictionary<string, string> cityNamedict = new Dictionary<string, string>();
                cityResult.ForEach(x =>
                {
                    if (!cityNamedict.Keys.Contains(x.city))
                    {
                        cityNamedict.Add(x.city, x.code);
                    }
                });
                string str1 = string.Format("http://www.nmc.gov.cn/f/rest/real/{0}", cityNamedict[city]);
                request = WebRequest.CreateHttp(str1);
                response = request.GetResponse() as HttpWebResponse;
                stream = response.GetResponseStream();
                reader = new StreamReader(stream);
                content = reader.ReadToEnd();
                detailResult = JsonConvert.DeserializeObject<WeatherDetail>(content);
                return true;
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
                detailResult = null;
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                detailResult = null;
                return false;
            }
        }
    }
    public class Province
    {
        public string code { set; get; }
        public string name { set; get; }
        public string url { set; get; }
    }

    public class City
    {
        public string url { set; get; }
        public string code { set; get; }
        public string city { set; get; }
        public string province { set; get; }
    }


    public class Weather
    {
        public float temperature { set; get; }
        public float temperatureDiff { set; get; }
        public float airpressure { set; get; }
        public float humidity { set; get; }
        public float rain { set; get; }
        public float rcomfort { set; get; }
        public float icomfort { set; get; }
        public string info { set; get; }
        public string img { set; get; }
        public float feelst { set; get; }
    }

    public class Wind
    {
        public string direct { set; get; }
        public string power { set; get; }
        public float speed { set; get; }
    }
    public class Warn
    {
        public string alert { set; get; }
        public string pic { set; get; }
        public string province { set; get; }
        public string city { set; get; }
        public string url { set; get; }
        public string issuecontent { set; get; }
        public string fmeans { set; get; }
    }
    public class WeatherDetail
    {
        public City station { set; get; }
        public string publish_time { set; get; }
        public Weather weather { set; get; }
        public Wind wind { set; get; }
        public Warn warn { set; get; }
    }
}
