using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace YongYou.Server
{
    public class HttpRequest
    {
        static Encoding m_Encoding = Encoding.UTF8;
        public static string getAPIURL()
        {
            string apiurl = ConfigurationManager.AppSettings["API_URL"];
            apiurl = string.IsNullOrEmpty(apiurl) ? "http://172.18.174.157:10086/" : apiurl;
            return apiurl + getAPIParams();
        }
        public static string getAPIParams()
        {
            return "/Api/DeviceApi.ashx";
        }
        public static string Get(Dictionary<string, string> queryparameter)
        {
            return Get(string.Empty, queryparameter);
        }
        public static string Get(string apiurl, Dictionary<string, string> queryparameter)
        {
            if (string.IsNullOrEmpty(apiurl))
            {
                apiurl = getAPIURL();
            }
            if (queryparameter != null && queryparameter.Keys.Count > 0)
            {
                string querystr = string.Join("&", queryparameter.Select(p => p.Key + "=" + HttpUtility.UrlEncode(p.Value)).ToArray());
                if (apiurl.EndsWith("?") || apiurl.EndsWith("&"))
                {
                    apiurl += querystr;
                }
                else if (apiurl.Contains("?"))
                {
                    apiurl += ("&" + querystr);
                }
                else
                {
                    apiurl += ("?" + querystr);
                }
            }

            var request = (HttpWebRequest)System.Net.HttpWebRequest.Create(apiurl);
            request.Method = "GET";
            System.Net.ServicePointManager.DefaultConnectionLimit = 512;
            request.Timeout = 60000;
            request.KeepAlive = false;
            var res = request.GetResponse();
            string result = null;

            using (StreamReader sr = new StreamReader(res.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }
            res.Close();
            return result;
        }
        public static string Post(Dictionary<string, string> queryparameter, Dictionary<string, string> postform)
        {
            return Post(string.Empty, queryparameter, postform);
        }
        public static string Post(string apiurl, Dictionary<string, string> queryparameter, Dictionary<string, string> postform)
        {
            if (string.IsNullOrEmpty(apiurl))
            {
                apiurl = getAPIURL();
            }
            if (queryparameter != null && queryparameter.Keys.Count > 0)
            {
                string querystr = string.Join("&", queryparameter.Select(p => p.Key + "=" + HttpUtility.UrlEncode(p.Value)).ToArray());
                if (apiurl.EndsWith("?") || apiurl.EndsWith("&"))
                {
                    apiurl += querystr;
                }
                else if (apiurl.Contains("?"))
                {
                    apiurl += ("&" + querystr);
                }
                else
                {
                    apiurl += ("?" + querystr);
                }
            }
            var request = (HttpWebRequest)System.Net.HttpWebRequest.Create(apiurl);
            request.Method = "POST";
            System.Net.ServicePointManager.DefaultConnectionLimit = 512;
            request.Timeout = 60000;
            request.KeepAlive = false;
            string postContent = string.Empty;
            if (postform != null)
            {
                postContent = string.Join("&", postform.Select(p => p.Key + "=" + p.Value).ToArray());
            }
            byte[] buffer = Encoding.UTF8.GetBytes(postContent);
            request.ContentLength = buffer.Length;
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

            var reqStream = request.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Flush();

            var res = request.GetResponse();
            string result = null;

            using (StreamReader sr = new StreamReader(res.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }
            res.Close();
            return result;
        }
    }
}
