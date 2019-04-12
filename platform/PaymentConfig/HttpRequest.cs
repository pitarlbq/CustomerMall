using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace PaymentConfig
{
    public class HttpRequest
    {
        public static string PostToWxServer(Dictionary<string, string> queryparameter, Dictionary<string, string> postform)
        {
            string apiurl = PaymentConfig.WeiXinConfig.WxApiUrl + "/api/api.ashx";
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
            var request = System.Net.HttpWebRequest.Create(apiurl);
            request.Method = "POST";
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
