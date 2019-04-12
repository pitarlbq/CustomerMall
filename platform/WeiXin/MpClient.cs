
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeiXin.Util;
using WeiXin.Request;

namespace WeiXin
{
    /// <summary>
    /// 微信公众平台客户端
    /// </summary>
    public class MpClient : IMpClient
    {
        private WebUtils webUtils;

        /// <summary>
        /// 执行微信公众平台API请求
        /// </summary>
        /// <typeparam name="T">领域对象</typeparam>
        /// <param name="request">具体的微信公众平台请求</param>
        /// <returns>领域对象</returns>
        public T Execute<T>(IMpRequest<T> request) where T : MpResponse
        {
            request.Validate();
            string body;
            webUtils = new WebUtils();
            string url = request.GetReqUrl();

            if (request.Method.Equals("GET", StringComparison.InvariantCultureIgnoreCase))
            {
                if (request.GetType().ToString() == "WeiXin.Request.DownloadMediaRequest")
                {
                    body = string.Empty;

                    string fileName = string.Empty;
                    string errHtml = string.Empty;
                    bool isSuc = webUtils.DownloadFile(url, Guid.NewGuid().ToString(), (request as DownloadMediaRequest).SaveDir, out fileName, out errHtml);
                    if (isSuc)
                    {
                        body = fileName;
                    }
                    else
                    {
                        body = errHtml;
                    }
                }
                else
                {
                    body = webUtils.DoGet(url, null);
                }
            }
            else
            {
                //上传接口
                if (request.GetType().ToString() == "Foresight.Weixin.Request.UploadMediaRequest")
                {
                    Dictionary<string, FileItem> files = new Dictionary<string, FileItem>();
                    FileItem fileItem = new FileItem((request as UploadMediaRequest).FileName);
                    files.Add(System.Guid.NewGuid().ToString(), fileItem);
                    body = webUtils.DoPost(url, request.GetParameters(), files);
                }
                else if (request.GetType().ToString() == "Foresight.Weixin.Request.UploadImgRequest")
                {
                    Dictionary<string, FileItem> files = new Dictionary<string, FileItem>();
                    FileItem fileItem = new FileItem((request as UploadImgRequest).FileName);
                    files.Add("media", fileItem);
                    body = webUtils.DoPost(url, request.GetParameters(), files);
                }
                else
                {
                    body = webUtils.DoPost(url, request.SendData);
                }
            }

            if (WebUtils.IsNullOrWhiteSpace(body))
            {
                return null;
            }

            T response = request.ParseHtmlToResponse(body);

            return response;
        }
    }
}
