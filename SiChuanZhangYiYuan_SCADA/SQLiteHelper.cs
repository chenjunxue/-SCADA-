using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace SiChuanZhangYiYuan_SCADA
{
    public static class SQLiteHelper
    {
        public  static  string ConStr ="";
        /// <summary>
        /// 执行增删改
        /// </summary>
        /// <param name="sql"><
        /// ram>
        /// <returns></returns>
        public static int Update(string sql)
        {
            SQLiteConnection DBConnection = new SQLiteConnection(ConStr);
            SQLiteCommand cmd = new SQLiteCommand(sql, DBConnection);
            try
            {
                DBConnection.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBConnection.Close();
            }
        }
        /// <summary>
        /// 获取单一结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql)
        {
            SQLiteConnection DBConnection = new SQLiteConnection(ConStr);
            SQLiteCommand cmd = new SQLiteCommand(sql, DBConnection);
            try
            {
                DBConnection.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                DBConnection.Close();
            }
        }
        /// <summary>
        /// 返回结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SQLiteDataReader GetReader(string sql)
        {
            SQLiteConnection DBConnection = new SQLiteConnection(ConStr);
            SQLiteCommand cmd = new SQLiteCommand(sql, DBConnection);
            try
            {
                DBConnection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                DBConnection.Close();
                throw ex;
            }


        }
        /// <summary>
        /// 返回数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql)
        {
            SQLiteConnection DBConnection = new SQLiteConnection(ConStr);
            SQLiteCommand cmd = new SQLiteCommand(sql, DBConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
             DataSet ds = new DataSet();
            try
            {
                DBConnection.Open();
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                DBConnection.Close();
            }
        }


        #region 启用事务执行多条SQL语句
        /// <summary>
        /// 启用事务执行多条SQL语句
        /// </summary>
        /// <param name="sqlList"></param>
        /// <returns></returns>
        public static bool UpdateByTran(List<string> sqlList)
        {
            SQLiteConnection DBConnection = new SQLiteConnection(ConStr);
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = DBConnection;
            try
            {
                DBConnection.Open();
                cmd.Transaction = DBConnection.BeginTransaction();//开启事务
                foreach (string itemsql in sqlList)
                {
                    cmd.CommandText = itemsql;
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();//提交事务
                return true;
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                    cmd.Transaction.Rollback();//回滚事务
                throw new Exception("调用事务方法时出现错误：" + ex.Message);
            }
            finally
            {
                if (cmd.Transaction != null)
                    cmd.Transaction = null;//清空事务
                DBConnection.Close();

            }
        }
        #endregion

        #region 错误信息写入日志
        /// <summary>
        /// 将错误信息写入日志文件
        /// </summary>
        /// <param name="msg"></param>
        private static void WriteLog(string msg)
        {
            FileStream fs = new FileStream("Log.text", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("[{0}]  错误信息：{1}", DateTime.Now.ToString(), msg);
            sw.Close();
            fs.Close();
        }
        #endregion

        #region 执行带参数的SQL语句
        /// <summary>
        /// 执行增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Update(string sql, SQLiteParameter[] param)
        {
            SQLiteConnection DBConnection = new SQLiteConnection(ConStr);
            SQLiteCommand cmd = new SQLiteCommand(sql, DBConnection);
            try
            {
                DBConnection.Open();
                cmd.Parameters.AddRange(param);//添加参数
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                WriteLog("执行Update(string sql)方法发生错误，错误日志：" + ex.Message);
                throw;
            }
            finally
            {
                DBConnection.Close();
            }
        }
        /// <summary>
        /// 返回单一结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql, SQLiteParameter[] param)
        {
            SQLiteConnection DBConnection = new SQLiteConnection(ConStr);
            SQLiteCommand cmd = new SQLiteCommand(sql, DBConnection);
            try
            {
                DBConnection.Open();
                cmd.Parameters.AddRange(param);//添加参数
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                WriteLog("执行GetSingleResult(string sql)方法发生错误，错误日志：" + ex.Message);
                throw;
            }
            finally
            {
                DBConnection.Close();
            }
        }
        /// <summary>
        /// 返回数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SQLiteDataReader GetReader(string sql, SQLiteParameter[] param)
        {
            SQLiteConnection DBConnection = new SQLiteConnection(ConStr);
            SQLiteCommand cmd = new SQLiteCommand(sql, DBConnection);
            try
            {
                DBConnection.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                WriteLog("执行GetReader(string sql)方法发生错误，错误日志：" + ex.Message);
                DBConnection.Close();
                throw ex;
            }

        }
        #endregion
    }
}
