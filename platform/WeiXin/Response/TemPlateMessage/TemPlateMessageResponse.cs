using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeiXin.Domain;

namespace WeiXin.Response
{
    /// <summary>
    /// 模板消息回应信息
    /// </summary>
    public class TemPlateMessageResponse : MpResponse
    {
        public GetIndustryInfo IndustryInfo { get; set; }
        public GetTemplateInfo TemplateInfo { get; set; }
    }
}
