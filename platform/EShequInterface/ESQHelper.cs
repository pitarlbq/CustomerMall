using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EShequInterface
{
    public class ESQHelper
    {
        /// <summary>
        /// 授权码获取
        /// </summary>
        /// <returns></returns>
        public static string GetAuthSDO()
        {
            var dic = new Dictionary<string, object>();
            dic["csp_name"] = ESQConfig.csp_name;
            dic["mch_id"] = ESQConfig.mch_id;
            var response = Utility.HttpRequestHelper.DoPostData<AuthSDOResponse>(dic, ESQConfig.getAuthSDO);
            if (response == null)
            {
                return string.Empty;
            }
            if (response.result.Equals("0"))
            {
                return string.Empty;
            }
            return response.data;
        }
    }
    public class ESQConfig
    {
        public static string HOST_SERVER = "https://www.e-shequ.com/mobileInterface/wuyeapi/";
        public static string csp_name = "chenhui8866";//填写您的Account账户
        public static string mch_id = "bf36f01d-4487-4d1e-88f6-617518c79816";//填写您的signature
        /// <summary>
        /// 授权码接口
        /// </summary>
        public static string getAuthSDO = "getAuthSDO";
        /// <summary>
        /// 获取小区信息列表
        /// </summary>
        public static string getSectListSDO = "getSectListSDO";
    }
}
