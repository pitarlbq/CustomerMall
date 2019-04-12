using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Utility
{
    public class SQLHelper
    {
        public static void ExecuteSQLFile(String sqlFileName, string DatabaseName)
        {
            System.Data.SqlClient.SqlConnection mySqlConnection = null;
            try
            {
                var config = new Utility.SiteConfig();
                string connStr = config.ConnString;
                mySqlConnection = new System.Data.SqlClient.SqlConnection(connStr);
                System.Data.SqlClient.SqlCommand Command = mySqlConnection.CreateCommand();
                Command.Connection.Open();
                Command.Connection.ChangeDatabase(DatabaseName);
                using (FileStream stream = new FileStream(sqlFileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    StreamReader reader = new StreamReader(stream, Encoding.Default);
                    StringBuilder builder = new StringBuilder();
                    String strLine = "";
                    char spaceChar = ' ';
                    string sprit = "/", whiffletree = "-";
                    while ((strLine = reader.ReadLine()) != null)
                    {
                        // 文件结束
                        if (strLine == null) break;
                        // 跳过注释行
                        if (strLine.StartsWith(sprit) || strLine.StartsWith(whiffletree)) continue;
                        // 去除右边空格
                        strLine = strLine.TrimEnd(spaceChar);
                        if (strLine.Trim().ToUpper() != @"GO")
                        {
                            builder.AppendLine(strLine);
                        }
                        else
                        {
                            Command.CommandText = builder.ToString().TrimEnd(' ');
                            try
                            {
                                Command.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                LogHelper.WriteError("更新数据库失败", DatabaseName, ex);
                            }
                            builder.Remove(0, builder.Length);
                        }
                    }
                    stream.Dispose();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (mySqlConnection != null && mySqlConnection.State != ConnectionState.Closed)
                {
                    mySqlConnection.Close();
                }
            }
        }
        public static void ExecuteSql(string DatabaseName, string cmdText)
        {
            var config = new Utility.SiteConfig();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(config.ConnString);
            System.Data.SqlClient.SqlCommand cmdBakRst = null;
            try
            {
                cmdBakRst = new System.Data.SqlClient.SqlCommand(cmdText, conn);
                cmdBakRst.Connection = conn;
                cmdBakRst.CommandType = System.Data.CommandType.Text;
                cmdBakRst.Connection.Open();
                String[] sqlArr = System.Text.RegularExpressions.Regex.Split(cmdText.Trim(), "GO", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                foreach (string strsql in sqlArr)
                {
                    if (strsql.Trim().Length > 1)
                    {
                        cmdBakRst.CommandText = strsql.Trim();
                        cmdBakRst.ExecuteNonQuery();
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException sexc)
            {
                LogHelper.WriteError("Utility.SQLHelper", "ExecuteSql", sexc);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Utility.SQLHelper", "ExecuteSql", ex);
            }
            finally
            {
                cmdBakRst.Connection.Close();
                cmdBakRst.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
        public static void CreateDataBase(string DatabaseName, int CompanyID)
        {
            var config = new Utility.SiteConfig();
            try
            {
                string DBFilePath = config.DBFilePath;
                string cmdtext = @"create database " + DatabaseName + @" on primary (name=" + DatabaseName + @"_data,filename='" + DBFilePath + DatabaseName + @"_data.mdf',size=5,filegrowth=1) log on (name=" + DatabaseName + @"_data_log,filename='" + DBFilePath + DatabaseName + "_data_log.ldf',size=5,filegrowth=10%)GO";
                Utility.SQLHelper.ExecuteSql("master", cmdtext);//调用ExecuteNonQuery()来创建数据库
            }
            catch (Exception)
            {
            }
            string sqlFileName = config.sqlFileName;
            Utility.SQLHelper.ExecuteSQLFile(sqlFileName, DatabaseName);
            string sqlFileData = config.sqlFileData;
            Utility.SQLHelper.ExecuteSQLFile(sqlFileData, DatabaseName);
        }
    }
}
