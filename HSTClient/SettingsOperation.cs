/*----------------------------------------------------------------             
// Copyright (C) 2018 North China University of Technology             
// 版权所有。              
//              
// 文件名：SettingsOperation.cs       
// 文件功能描述： 
 * 参数设置操作类
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
using System.Windows;
using System.Windows.Forms;
using System.Data;

namespace HSTClient
{
    class SettingsOperation
    {
        private Client.MySqlHelper mysql = new Client.MySqlHelper();
        private DataTable dt;
        private List<int> index_list = new List<int>();
        private bool IsCamFlag = false;
        private bool addFlag = false;
        private bool deleteFlag = false;
        /// <summary>
        /// 读取摄像头参数
        /// </summary>
        public void ReadCameraParam(DataGridView dgv)
        {
            IsCamFlag = true; 
            dgv.AllowUserToAddRows = false;
            addFlag = false;
            deleteFlag = false;
            index_list.Clear();
            string str = string.Format("SELECT * FROM TB_PARAM");
            try
            {
                dt = mysql.ExecuteDataTable(str);

                dgv.DataSource = dt;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dgv.Columns[0].Visible = false;
        }
        /// <summary>
        /// 读取计算参数
        /// </summary>
        /// <param name="dgv"></param>
        public void ReadCaculateParam(DataGridView dgv)
        {
            IsCamFlag = false; 

            dgv.AllowUserToAddRows = false;
            addFlag = false;
            deleteFlag = false;
            index_list.Clear();

            string str = string.Format("SELECT * FROM TB_CACULATEPARAM");
            try
            {
                dt = mysql.ExecuteDataTable(str);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dgv.DataSource = dt;

            dgv.Columns[0].Visible = false;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dgv"></param>
        public void AddNewParam(DataGridView dgv)
        {
            addFlag = true;
            dgv.AllowUserToAddRows = true;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="dgv"></param>
        public void DeleteParam(DataGridView dgv)
        {
            deleteFlag = true;
            index_list.Add(int.Parse(dt.Rows[dgv.CurrentCell.RowIndex]["ID"].ToString()));

            dt.Rows.RemoveAt(dgv.CurrentCell.RowIndex);
            dgv.DataSource = dt;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="dgv"></param>
        public void SaveParam(DataGridView dgv)
        {
            DataTable dt_new = (dgv.DataSource as DataTable);
            if (IsCamFlag)//如果是摄像头参数
            {
                if (addFlag)
                {
                    int count = 0;
                    foreach (DataRow dr in dt_new.Rows)//获取已有行数
                    {
                        if (dr["ID"].ToString() != "")
                        {
                            count++;
                        }
                    }

                    if (count < dt_new.Rows.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            string str = string.Format("UPDATE TB_PARAM SET CamID={0},Position='{1}',RTSPAdress='{2}',Url='{3}',UserName='{4}',Password='{5}',Port='{6}',VideoWidth='{7}',VideoHeight='{8}',Remarks='{9}',DensityThreshold={10} ,SpeedThresshold={11} WHERE ID={12}",
                                                                   dt.Rows[i]["CamID"], dt.Rows[i]["Position"], dt.Rows[i]["RTSPAdress"], dt.Rows[i]["Url"], dt.Rows[i]["UserName"], dt.Rows[i]["Password"], dt.Rows[i]["Port"], dt.Rows[i]["VideoWidth"], dt.Rows[i]["VideoHeight"], dt.Rows[i]["Remarks"], dt.Rows[i]["DensityThreshold"],dt.Rows[i]["SpeedThresshold"],dt.Rows[i]["ID"]);
                            try
                            {
                                mysql.ExecuteNonQuery(str);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                MessageBox.Show("出现错误！");
                                break;
                            }
                        }

                        for (int i = count; i < dt_new.Rows.Count; i++)
                        {
                            string str = string.Format("INSERT INTO TB_PARAM (CamID,Position,RTSPAdress,Url,UserName,Password,Port,VideoWidth,VideoHeight,Remarks,DensityThreshold ,SpeedThresshold)VALUE('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", dt.Rows[i]["CamID"], dt.Rows[i]["Position"], dt.Rows[i]["RTSPAdress"], dt.Rows[i]["Url"], dt.Rows[i]["UserName"], dt.Rows[i]["Password"], dt.Rows[i]["Port"], dt.Rows[i]["VideoWidth"], dt.Rows[i]["VideoHeight"], dt.Rows[i]["Remarks"], dt.Rows[i]["DensityThreshold"], dt.Rows[i]["SpeedThresshold"]);
                            try
                            {
                                mysql.ExecuteNonQuery(str);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                MessageBox.Show("出现错误(保证DensityThreshold ,SpeedThresshold不为空)！");
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = count; i < dt_new.Rows.Count; i++)
                        {
                            string str = string.Format("UPDATE TB_PARAM SET CamID={0},Position='{1}',RTSPAdress='{2}',Url='{3}',UserName='{4}',Password='{5}',Port='{6}',VideoWidth='{7}',VideoHeight='{8}',Remarks='{9}' ,DensityThreshold={10} ,SpeedThresshold={11} WHERE ID={12}",
                                                                   dt.Rows[i]["CamID"], dt.Rows[i]["Position"], dt.Rows[i]["RTSPAdress"], dt.Rows[i]["Url"], dt.Rows[i]["UserName"], dt.Rows[i]["Password"], dt.Rows[i]["Port"], dt.Rows[i]["VideoWidth"], dt.Rows[i]["VideoHeight"], dt.Rows[i]["Remarks"], dt.Rows[i]["DensityThreshold"], dt.Rows[i]["SpeedThresshold"], dt.Rows[i]["ID"]);

                            try
                            {
                                mysql.ExecuteNonQuery(str);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                MessageBox.Show("出现错误！");
                                break;
                            }
                        }
                    }
                }
                else if (deleteFlag)
                {
                    for (int i = 0; i < index_list.Count; i++)
                    {
                        string str = string.Format("DELETE FROM TB_PARAM WHERE ID={0}", index_list[i]);
                        try
                        {
                            mysql.ExecuteNonQuery(str);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            MessageBox.Show("出现错误！");
                            break;
                        }
                    }
                    index_list.Clear();
                }
                else
                {
                    for (int i = 0; i < dt_new.Rows.Count; i++)
                    {
                        string str = string.Format("UPDATE TB_PARAM SET CamID={0},Position='{1}',RTSPAdress='{2}',Url='{3}',UserName='{4}',Password='{5}',Port='{6}',VideoWidth='{7}',VideoHeight='{8}',Remarks='{9}' ,DensityThreshold={10} ,SpeedThresshold={11} WHERE ID={10}",
                                                               dt.Rows[i]["CamID"], dt.Rows[i]["Position"], dt.Rows[i]["RTSPAdress"], dt.Rows[i]["Url"], dt.Rows[i]["UserName"], dt.Rows[i]["Password"], dt.Rows[i]["Port"], dt.Rows[i]["VideoWidth"], dt.Rows[i]["VideoHeight"], dt.Rows[i]["Remarks"], dt.Rows[i]["DensityThreshold"], dt.Rows[i]["SpeedThresshold"], dt.Rows[i]["ID"]);
                        try
                        {
                            mysql.ExecuteNonQuery(str);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            MessageBox.Show("出现错误！");
                            break;
                        }
                    }
                }
            }
            else//如果是计算参数
            {
                if (addFlag)
                {
                    int count = 0;
                    foreach (DataRow dr in dt_new.Rows)//获取已有行数
                    {
                        if (dr["ID"].ToString() != "")
                        {
                            count++;
                        }
                    }

                    if (count < dt_new.Rows.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            string str = string.Format("UPDATE TB_CACULATEPARAM SET CamID={0},StartPos_x='{1}',StartPos_y='{2}',EndPos_x='{3}',EndPos_y='{4}',StartNeg_x='{5}',StartNeg_y='{6}',EndNeg_x='{7}',EndNeg_y='{8}',CameraHeight='{9}',MeasureAngle='{10}',TiltAngle='{11}' WHERE ID={12}",
                                                                   dt.Rows[i]["CamID"], dt.Rows[i]["StartPos_x"], dt.Rows[i]["StartPos_y"], dt.Rows[i]["EndPos_x"], dt.Rows[i]["EndPos_y"], dt.Rows[i]["StartNeg_x"], dt.Rows[i]["StartNeg_y"], dt.Rows[i]["EndNeg_x"], dt.Rows[i]["EndNeg_y"], dt.Rows[i]["CameraHeight"], dt.Rows[i]["MeasureAngle"], dt.Rows[i]["TiltAngle"], dt.Rows[i]["ID"]);
                            try
                            {
                                mysql.ExecuteNonQuery(str);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                MessageBox.Show("出现错误！");
                                break;
                            }
                        }

                        for (int i = count; i < dt_new.Rows.Count; i++)
                        {
                            string str = string.Format("INSERT INTO TB_CACULATEPARAM (CamID,StartPos_x,StartPos_y,EndPos_x,EndPos_y,StartNeg_x,StartNeg_y,EndNeg_x,EndNeg_y,CameraHeight,MeasureAngle,TiltAngle)VALUE({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", dt.Rows[i]["CamID"], dt.Rows[i]["StartPos_x"], dt.Rows[i]["StartPos_y"], dt.Rows[i]["EndPos_x"], dt.Rows[i]["EndPos_y"], dt.Rows[i]["StartNeg_x"], dt.Rows[i]["StartNeg_y"], dt.Rows[i]["EndNeg_x"], dt.Rows[i]["EndNeg_y"], dt.Rows[i]["CameraHeight"], dt.Rows[i]["MeasureAngle"], dt.Rows[i]["TiltAngle"]);
                            try
                            {
                                mysql.ExecuteNonQuery(str);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                MessageBox.Show("出现错误！");
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = count; i < dt_new.Rows.Count; i++)
                        {
                            string str = string.Format("INSERT INTO TB_CACULATEPARAM (CamID,StartPos_x,StartPos_y,EndPos_x,EndPos_y,StartNeg_x,StartNeg_y,EndNeg_x,EndNeg_y,CameraHeight,MeasureAngle,TiltAngle)VALUE({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", dt.Rows[i]["CamID"], dt.Rows[i]["StartPos_x"], dt.Rows[i]["StartPos_y"], dt.Rows[i]["EndPos_x"], dt.Rows[i]["EndPos_y"], dt.Rows[i]["StartNeg_x"], dt.Rows[i]["StartNeg_y"], dt.Rows[i]["EndNeg_x"], dt.Rows[i]["EndNeg_y"], dt.Rows[i]["CameraHeight"], dt.Rows[i]["MeasureAngle"], dt.Rows[i]["TiltAngle"]);
                            try
                            {
                                mysql.ExecuteNonQuery(str);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                MessageBox.Show("出现错误！");
                                break;
                            }
                        }
                    }
                }
                if (deleteFlag)
                {
                    for (int i = 0; i < index_list.Count; i++)
                    {
                        string str = string.Format("DELETE FROM TB_CACULATEPARAM WHERE ID={0}", index_list[i]);
                        try
                        {
                            mysql.ExecuteNonQuery(str);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            MessageBox.Show("出现错误！");
                            break;
                        }
                    }
                    index_list.Clear();
                }
            }
            CancelParam(dgv);
        }
        
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="dgv"></param>
        public void CancelParam(DataGridView dgv)
        {
            if (IsCamFlag)
            {
                ReadCameraParam(dgv);
            }
            else
                ReadCaculateParam(dgv);
            dgv.AllowUserToAddRows = false;
            addFlag = false;
            deleteFlag = false;
            index_list.Clear();
        }
    }
}