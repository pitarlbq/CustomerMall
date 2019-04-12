
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using HuiShouYin.Domain;
using System.IO;
using System.Xml;
using HuiShouYin.Util;
using HuiShouYin.Request;
using HuiShouYin.Response;
using Utility;

namespace HuiShouYin
{
    /// <summary>
    /// 消息处理类
    /// </summary>
    public class MessageHandler
    {
        public static GetApplyPayResponse SendApplyPay(ApplyPay_BizContent _ApplyPay_BizContent)
        {
            IMpClient mpClient = new MpClient();
            GetApplyPayRequest request = new GetApplyPayRequest();
            var applyPayRequest = new ApplyPayRequest(_ApplyPay_BizContent);
            request.SendData = JsonConvert.SerializeObject(applyPayRequest);
            GetApplyPayResponse response = mpClient.Execute(request);
            if (response.IsError)
            {

            }
            return response;
        }
        public static GetApplyRefundResponse SendApplyPay(ApplyRefund_BizContent _ApplyRefund_BizContent)
        {
            IMpClient mpClient = new MpClient();
            GetApplyRefundRequest request = new GetApplyRefundRequest();
            var applyPayRequest = new ApplyRefundRequest(_ApplyRefund_BizContent);
            request.SendData = JsonConvert.SerializeObject(applyPayRequest);
            GetApplyRefundResponse response = mpClient.Execute(request);
            if (response.IsError)
            {

            }
            return response;
        }
    }
}
