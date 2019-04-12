
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;

namespace HuiShouYin.Util
{
    /// <summary>
    /// 辅助工具类
    /// </summary>
    public class Tools
    {
        #region 获取Json string某节点的值。
        /// <summary>
        /// 获取Json string某节点的值。
        /// </summary>
        /// <param name="json"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetJosnValue(string jsonStr, string key)
        {
            string result = string.Empty;
            if (!WebUtils.IsNullOrWhiteSpace(jsonStr))
            {
                key = "\"" + key.Trim('"') + "\"";
                int index = jsonStr.IndexOf(key) + key.Length + 1;
                if (index > key.Length + 1)
                {
                    //先截逗号，若是最后一个，截“｝”号，取最小值

                    int end = jsonStr.IndexOf(',', index);
                    if (end == -1)
                    {
                        end = jsonStr.IndexOf('}', index);
                    }
                    //index = json.IndexOf('"', index + key.Length + 1) + 1;
                    result = jsonStr.Substring(index, end - index);
                    //过滤引号或空格
                    result = result.Trim(new char[] { '"', ' ', '\'' });
                }
            }
            return result;
        }
        public static string GetJosnListValue(string jsonStr, string key)
        {
            string result = string.Empty;
            if (!WebUtils.IsNullOrWhiteSpace(jsonStr))
            {
                key = "\"" + key.Trim('"') + "\"";
                int index = jsonStr.IndexOf(key) + key.Length + 1;
                if (index > key.Length + 1)
                {
                    //先截逗号，若是最后一个，截“｝”号，取最小值

                    int end = jsonStr.IndexOf("],", index);
                    if (end == -1)
                    {
                        end = jsonStr.IndexOf(']', index);
                    }
                    //index = json.IndexOf('"', index + key.Length + 1) + 1;
                    result = jsonStr.Substring(index, end - index);
                    //过滤引号或空格
                    result = result.Trim(new char[] { '"', ' ', '\'' });
                }
            }
            return result;
        }
        #endregion

        /// <summary>
        /// datetime转换成unixtime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (long)(time - startTime).TotalSeconds;
        }

        /// <summary>
        /// 将Unix时间戳转换为DateTime类型时间
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static System.DateTime ConvertIntDateTime(double d)
        {
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddSeconds(d);
            return time;
        }

        /// <summary>
        /// Json序列化对象
        /// </summary>
        /// <typeparam name="ObjType"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJsonString<ObjType>(ObjType obj) where ObjType : class
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string s = jsonSerializer.Serialize(obj);
            return s;
        }

        public static string Sinature(string s)
        {
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(s);
            byte[] md5Bytes = md5.ComputeHash(bytes);
            md5.Clear();
            string ret = "";
            for (int i = 0; i < md5Bytes.Length; i++)
            {
                ret += md5Bytes[i].ToString("x");
            }

            return ret;
        }
        public static string MD5Encrypt(string oldvalue)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(oldvalue, "MD5");

            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(oldvalue));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString().ToUpper();
        }
    }
}
