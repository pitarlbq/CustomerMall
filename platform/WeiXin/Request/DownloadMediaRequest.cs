﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeiXin.Response;
using WeiXin.Domain;

namespace WeiXin.Request
{
    /// <summary>
    /// 多媒体文件下载请求
    /// </summary>
    public class DownloadMediaRequest : RequestBase<DownloadMediaResponse>, IMpRequest<DownloadMediaResponse>
    {
        public string Method
        {
            get
            {
                return "GET";
            }
        }

        /// <summary>
        /// AppId信息
        /// </summary>
        public AppIdInfo AppIdInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 调用接口凭证 
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 媒体ID
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 下载后保存目录
        /// </summary>
        public string SaveDir { get; set; }

 
        /// 需要POST发送的数据
        /// </summary>
        public string SendData { get; set; }

        /// <summary>
        /// 获取Api请求地址
        /// </summary>
        /// <returns></returns>
        public string GetReqUrl()
        {
            string urlFormat = "http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}";
            string url = string.Format(urlFormat, AccessToken, MediaId);
            return url;
        }

        public IDictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>();
        }

        public void Validate()
        {

        }

        public DownloadMediaResponse  ParseHtmlToResponse(string body)
        {
            DownloadMediaResponse response = new DownloadMediaResponse();
            response.Body = body;

            if (response.HasError())
            {
                response.ErrInfo = response.GetErrInfo();
            }
            else
            {
                response.SaveFileName = body.Trim();
            }
            return response;
        }
    }
}
