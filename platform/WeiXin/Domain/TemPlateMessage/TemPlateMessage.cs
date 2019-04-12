using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiXin.Domain
{
    public abstract class TemPlateMessage
    {
        /// <summary>
        /// 将对象转化为Json字符串
        /// </summary>
        /// <returns></returns>
        public abstract string ToJsonString();
    }
    /// <summary>
    /// 发送模板消息
    /// </summary>
    public class SendTemPlateMessage : TemPlateMessage
    {
        /// <summary>
        /// 普通用户openid 
        /// </summary>
        public string touser { get; set; }

        /// <summary>
        /// 模板ID
        /// </summary>
        public string template_id { get; set; }

        /// <summary>
        /// 返回的URL
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public List<TemPlateMessageItem> data { get; set; }

        /// <summary>
        /// 将对象转化为Json字符串
        /// </summary>
        /// <returns></returns>
        public override string ToJsonString()
        {
            var datastr = string.Empty;
            for (var i = 0; i < data.Count; i++)
            {
                if (i + 1 == data.Count)
                {
                    datastr += "\"" + data[i].key + "\":{\"value\":\"" + data[i].value.Replace("\r\n", "<br/>").Replace("\r", "").Replace("\n", "") + "\",\"color\":\"" + data[i].color + "\"}";
                }
                else
                {
                    datastr += "\"" + data[i].key + "\":{\"value\":\"" + data[i].value.Replace("\r\n", "<br>").Replace("\r", "").Replace("\n", "") + "\",\"color\":\"" + data[i].color + "\"},";
                }
            }
            var s = "{\"touser\":\"" + touser + "\",\"template_id\":\"" + template_id + "\",\"url\":\"" + url + "\",\"data\":{" + datastr + "}}";
            return s;
        }
    }
    /// <summary>
    /// 模板消息列
    /// </summary>
    public class TemPlateMessageItem
    {
        public string key { get; set; }
        public string value { get; set; }
        public string color { get; set; }
    }
    /// <summary>
    /// 设置所属行业
    /// </summary>
    public class SetIndustry : TemPlateMessage
    {
        public List<IndustryItem> Industry { get; set; }

        public override string ToJsonString()
        {
            var datastr = string.Empty;
            for (int i = 0; i < Industry.Count; i++)
            {
                if (i + 1 == Industry.Count)
                {
                    datastr += "\"" + Industry[i].name + "\":\"" + Industry[i].id + "\"";
                }
                else
                {
                    datastr += "\"" + Industry[i].name + "\":\"" + Industry[i].id + "\",";
                }
            }
            return "{" + datastr + "}";
        }
    }
    /// <summary>
    /// 所属行业列
    /// </summary>
    public class IndustryItem
    {
        public string name { get; set; }
        public string id { get; set; }
    }
    /// <summary>
    /// 获取行业信息
    /// </summary>
    public class GetIndustryInfo
    {
        public GetIndustryInfoItem primary_industry { get; set; }
        public GetIndustryInfoItem secondary_industry { get; set; }
    }
    /// <summary>
    /// 获取行业信息列
    /// </summary>
    public class GetIndustryInfoItem
    {
        public string first_class { get; set; }
        public string second_class { get; set; }
    }
    /// <summary>
    /// 获取模板名称
    /// </summary>
    public class GetTemPlateID : TemPlateMessage
    {
        public string template_id_short { get; set; }

        public override string ToJsonString()
        {
            return "{\"template_id_short\":\"" + template_id_short + "\"}";
        }
    }
    /// <summary>
    /// 获取模板信息
    /// </summary>
    public class GetTemplateInfo
    {
        private List<GetTemplateInfoItem> template_list { get; set; }
    }
    /// <summary>
    /// 模板信息列
    /// </summary>
    public class GetTemplateInfoItem
    {
        public string template_id { get; set; }
        public string title { get; set; }
        public string primary_industry { get; set; }
        public string deputy_industry { get; set; }
        public string content { get; set; }
        public string example { get; set; }
    }
    /// <summary>
    /// 删除模板信息
    /// </summary>
    public class DeleteTemPlate : TemPlateMessage
    {
        public string template_id { get; set; }

        public override string ToJsonString()
        {
            return "{\"template_id\":\"" + template_id + "\"}";
        }
    }
}
