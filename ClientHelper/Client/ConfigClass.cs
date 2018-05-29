/*----------------------------------------------------------------             
// Copyright (C) 2018 North China University of Technology             
// 版权所有。              
//              
// 文件名：ConfigClass.cs       
// 文件功能描述： 
 * 配置文件相关类
 * App.config
// 创建人：谭磊
// 创建时间：2018-3-12
// 修改人：
// 修改时间：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Configuration;

namespace Client
{
    public class ConfigClass
    {
        private static ConfigClass instance; //单例模式
        private Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private ConfigClass() { }
        public static ConfigClass getInstance()
        {
            if(instance !=null)
            {
                return instance;
            }
            else
            {
                instance = new ConfigClass();
                return instance;
            }
        }
        /// <summary>
        /// 根据Key查询值
        /// 确保配置文件中存在该键值对
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>查询到的字符串</returns>
        public string getValue(string key)
        {
            return config.AppSettings.Settings[key].Value;
        }
    }
}
