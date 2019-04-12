using HuiShouYin;
using HuiShouYin.Domain;
using HuiShouYin.Request;
using Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class hsytest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click_Click(object sender, EventArgs e)
        {
            string out_refund_no = Utility.Tools.GetRandomString(24);
            var _ApplyRefund_BizContent = new ApplyRefund_BizContent();
            _ApplyRefund_BizContent.out_trade_no = this.tdtradeno.Value;
            _ApplyRefund_BizContent.refund_fee = Convert.ToInt32(this.tdRefundFee.Value);
            _ApplyRefund_BizContent.total_fee = Convert.ToInt32(this.tdTotalFee.Value);
            _ApplyRefund_BizContent.out_refund_no = out_refund_no;
            IMpClient mpClient = new MpClient();
            GetApplyRefundRequest request = new GetApplyRefundRequest();
            var applyPayRequest = new ApplyRefundRequest(_ApplyRefund_BizContent);
            request.SendData = JsonConvert.SerializeObject(applyPayRequest);
            string requestdata = string.Empty;
            string responsedata = string.Empty;
            var response = mpClient.Execute(request, out requestdata, out responsedata);
            this.tdRequestData.Value = requestdata;
            this.tdResponseData.Value = responsedata;
            this.tdrefundno.Value = out_refund_no;
        }
    }
}