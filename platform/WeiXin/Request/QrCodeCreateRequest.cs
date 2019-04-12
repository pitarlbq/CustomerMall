
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeiXin.Response;
using WeiXin.Domain;
using System.Web.Script.Serialization;
using WeiXin.Util;

namespace WeiXin.Request
{
    /// <summary>
    /// 创建二维码请求
    /// </summary>
    public class QrCodeCreateRequest : RequestBase<QrCodeCreateResponse>, IMpRequest<QrCodeCreateResponse>
    {
        public string Method
        {
            get
            {
                return "POST";
            }
        }

        /// <summary>
        /// 创建二维码消息
        /// </summary>
        public QrCodeCreateMessage QrCodeCreateMessage { get; set; }

        /// <summary>
        /// 需要POST发送的数据
        /// </summary>
        public string SendData
        {
            get
            {
                return this.QrCodeCreateMessage.ToJsonString();
            }
            set
            {

            }
        }

        /// <summary>
        /// 调用接口凭证 
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// AppId信息
        /// </summary>
        public AppIdInfo AppIdInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 获取Api请求地址
        /// </summary>
        /// <returns></returns>
        public string GetReqUrl()
        {
            string urlFormat = "https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}";
            string url = string.Format(urlFormat, AccessToken);
            return url;
        }

        public IDictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>();
        }

        public void Validate()
        {

        }

        public QrCodeCreateResponse ParseHtmlToResponse(string body)
        {
            QrCodeCreateResponse response = new QrCodeCreateResponse();
            response.Body = body;

            if (response.HasError())
            {
                response.ErrInfo = response.GetErrInfo();
            }
            else
            {
                response.Ticket = Tools.GetJosnValue(body, "ticket");
                string exp = Tools.GetJosnValue(body, "expire_seconds");
                if (!WebUtils.IsNullOrWhiteSpace(exp))
                {
                    response.ExpireSeconds = Convert.ToInt32(exp);
                }
                response.Url = Tools.GetJosnValue(body, "url");

                //if (!WebUtils.IsNullOrWhiteSpace(this.QrCodeCreateMessage.LocalStoredDir))
                //{
                //    WebUtils webUtils = new WebUtils();
                //    string fileName = string.Empty;
                //    string errMsg  = string.Empty;
                //    System.Threading.Thread.Sleep(3000);
                //    //暂时下载不了文件，可能腾讯限制了
                //    if (!webUtils.DownloadFile(response.QrCodeUrl, this.QrCodeCreateMessage.LocalStoredDir, out fileName, out errMsg))
                //    {
                //        response.ErrInfo = new ErrInfo()
                //        {
                //            ErrCode = -9999,
                //            ErrMsg = "创建二维码请求成功，但是下载到本地失败"
                //        };
                //    }
                //}
            }
            return response;
        }
    }
}

