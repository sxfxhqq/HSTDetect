/*----------------------------------------------------------------             
// Copyright (C) 2018 North China University of Technology             
// 版权所有。              
//              
// 文件名：MySqlHelper.cs       
// 文件功能描述： 数据库操作类
// 创建人：谭磊
// 创建时间：2018-3-11
// 修改人：
// 修改时间：
//----------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Configuration;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Client
{
    public class MySqlHelper
    {
        #region【私有变量】
        private string connectionString;
        private MySqlConnection conn;
        private bool isConnected = false;
        #endregion

        #region【公有方法】
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void closeDB()
        {
            conn.Close();
            isConnected = false;
        }
        /// <summary> 
        /// 执行查询语句，返回DataTable 
        /// </summary> 
        /// <param name="SQLString">查询语句</param> 
        /// <returns>DataTable</returns> 
        public DataTable ExecuteDataTable(string SQLString)
        {
            if (!isConnected)
                if (!connectDB())
                    return null;
            using (MySqlDataAdapter command = new MySqlDataAdapter(SQLString, conn))
            {
                DataSet ds = new DataSet();
                try
                {
                    command.Fill(ds, "ds");
                }
                catch (MySqlException ex)
                {
                    conn.Close();
                    throw new Exception(ex.Message);
                }
                return ds.Tables[0];
            }
        }

        /// <summary> 
        /// 执行SQL语句，返回影响的记录数 
        /// </summary> 
        /// <param name="SQLString">SQL语句</param> 
        /// <returns>影响的记录数</returns>
        public int ExecuteNonQuery(string SQLString)
        {
            if (!isConnected)
                if (!connectDB())
                    return -1;
            using (MySqlCommand cmd = new MySqlCommand(SQLString, conn))
            {
                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (MySql.Data.MySqlClient.MySqlException e)
                {
                    conn.Close();
                    throw new Exception(e.Message);
                }
            }
        }
        /// <summary> 
        /// 执行一条计算查询结果语句，返回查询结果（object）。 
        /// </summary> 
        /// <param name="SQLString">计算查询结果语句</param> 
        /// <returns>查询结果（object）</returns> 
        public object ExecuteScalar(string SQLString)
        {
            if (!isConnected)
                if (!connectDB())
                    return null;
            using (MySqlCommand cmd = new MySqlCommand(SQLString, conn))
            {
                try
                {
                    object obj = cmd.ExecuteScalar();
                    return obj;
                }
                catch (MySql.Data.MySqlClient.MySqlException e)
                {
                    conn.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        public bool connectTest()
        {
            try
            {
                connectionString = ConfigClass.getInstance().getValue("connectionString");
                conn = new MySqlConnection(connectionString);
                conn.Open();
            }
            catch (MySqlException ex)
            {
                return false;
            }
            if (conn.State == ConnectionState.Open)
            {
                isConnected = true;
                return true;
            }
            else
                return false;
        }

        #endregion

        #region【私有函数】
        /// <summary>
        /// 从配置文件读取连接信息
        /// 连接数据库
        /// </summary>
        private bool connectDB()
        {
            connectionString = ConfigClass.getInstance().getValue("connectionString");
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                return false;
            }
            if (conn.State == ConnectionState.Open)
                isConnected = true;
            return true;
        }
        #endregion
    }
}


