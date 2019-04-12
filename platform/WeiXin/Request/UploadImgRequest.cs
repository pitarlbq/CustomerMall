
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeiXin.Response;
using WeiXin.Domain;
using WeiXin.Util;

namespace WeiXin.Request
{
    /// <summary>
    /// 上传多媒体文件请求
    /// </summary>
    public class UploadImgRequest : RequestBase<UploadImgResponse>, IMpRequest<UploadImgResponse>
    {
        public string Method
        {
            get
            {
                return "POST";
            }
        }

        /// <summary>
        /// 调用接口凭证 
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 媒体文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb）
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 多媒体文件名
        /// </summary>
        public string FileName { get; set; }

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
            string urlFormat = "https://api.weixin.qq.com/cgi-bin/material/add_material?access_token={0}&type={1}";
            string url = string.Format(urlFormat, AccessToken, Type);
            return url;
        }

        public IDictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>();
        }

        public void Validate()
        {

        }

        public UploadImgResponse ParseHtmlToResponse(string body)
        {
            UploadImgResponse response = new UploadImgResponse();
            response.Body = body;

            if (response.HasError())
            {
                response.ErrInfo = response.GetErrInfo();
            }
            else
            {
                response.URL = Tools.GetJosnValue(body, "URL");
                response.media_id = Tools.GetJosnValue(body, "media_id");
                if (WebUtils.IsNullOrWhiteSpace(response.media_id))
                {
                    response.media_id = Tools.GetJosnValue(body, "thumb_media_id");
                }
                // {"type":"image","media_id":"RuYGs6yryePCLvsS3NSvR0BnHmNjBBPg91oa4PNZ1xjpUZvYV71UmRvkDg0uDlMh","created_at":1390135096}
            }
            return response;
        }


    }
}
