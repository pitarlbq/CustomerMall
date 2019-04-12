using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using WeiXin.Domain;
using WeiXin.Response;

namespace WeiXin.Request
{
    /// <summary>
    /// 模板消息处理
    /// </summary>
    public class TemPlateMessage : RequestBase<TemPlateMessageResponse>, IMpRequest<TemPlateMessageResponse>
    {
        /// <summary>
        /// 提交方式
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// 调用接口凭证 
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 请求URL
        /// </summary>
        public string ReqUrl { get; set; }

        /// <summary>
        /// AppId信息
        /// </summary>
        public AppIdInfo AppIdInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 需要POST发送的数据
        /// </summary>
        public string SendData { get; set; }


        /// <summary>
        /// 获取Api请求地址
        /// </summary>
        /// <returns></returns>
        public string GetReqUrl()
        {
            return string.Format(ReqUrl, AccessToken);
        }

        public IDictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>();
        }

        public void Validate()
        {

        }

        public TemPlateMessageResponse ParseHtmlToResponse(string body)
        {
            var response = new TemPlateMessageResponse();
            response.Body = body;

            if (response.HasError())
            {
                response.ErrInfo = response.GetErrInfo();
            }
            else
            {
                ////Get方式反序列化model
                //JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                //Groups mg = jsonSerializer.Deserialize<Groups>(response.Body);
                //response.Groups = mg;
            }
            return response;
        }
    }
}
