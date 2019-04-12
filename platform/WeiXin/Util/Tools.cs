
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace WeiXin.Util
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
        public static string GetCustomerServiceErrorMsg(long ErrorCode)
        {
            string desc = string.Empty;
            switch (ErrorCode)
            {
                case 65400:
                    desc = "API不可用，没有开通新版客服功能";
                    break;
                case 65401:
                    desc = "";
                    break;
                case 65403:
                    desc = "客服昵称不合法";
                    break;
                case 65404:
                    desc = "客服帐号不合法";
                    break;
                case 65405:
                    desc = "帐号数目已达到上限，不能继续添加";
                    break;
                case 65406:
                    desc = "已经存在的客服帐号";
                    break;
                case 65407:
                    desc = "邀请对象已经是该公众号客服";
                    break;
                case 65408:
                    desc = "本公众号已经有一个邀请给该微信";
                    break;
                case 65409:
                    desc = "无效的微信号";
                    break;
                case 65410:
                    desc = "邀请对象绑定公众号客服数达到上限（目前每个微信号可以绑定5个公众号客服帐号）";
                    break;
                case 65411:
                    desc = "该帐号已经有一个等待确认的邀请，不能重复邀请";
                    break;
                case 65412:
                    desc = "该帐号已经绑定微信号，不能进行邀请";
                    break;
                case 65413:
                    desc = "不存在对应用户的会话信息";
                    break;
                case 65414:
                    desc = "粉丝正在被其他客服接待";
                    break;
                case 65415:
                    desc = "指定的客服不在线";
                    break;
                case 40005:
                    desc = "不支持的媒体类型";
                    break;
                case 40009:
                    desc = "媒体文件长度不合法";
                    break;
                default:
                    break;
            }
            return desc;
        }
    }
}
