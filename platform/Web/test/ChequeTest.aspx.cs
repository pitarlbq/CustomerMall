using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class ChequeTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDoLogin_Click(object sender, EventArgs e)
        {
            string result = Utility.ChequeHelper.doChequeLogin();
            this.tdLoginResponse.InnerHtml = result;
        }
        protected void btnWriteInvoice_Click(object sender, EventArgs e)
        {
            var itemlist = new List<Dictionary<string, string>>();
            var item = new Dictionary<string, string>();
            item["CPMC"] = "物业费";
            item["CPXH"] = "2018-10-01至2018-10-31";
            item["CPDW"] = "个";
            item["SL"] = "17";
            item["CPSL"] = "1";
            item["BHSJE"] = "1000";
            item["SE"] = "170";
            item["FLBM"] = "1060301020200000000";
            item["XSYH"] = "0";
            item["LSLBZ"] = "";
            item["YHSM"] = "";
            itemlist.Add(item);
            var headRequireItem = new Dictionary<string, string>();
            headRequireItem["XTLSH"] = "YY999999999";
            headRequireItem["KHMC"] = "重庆永友网络科技有限公司";
            headRequireItem["KHDZ"] = "永川区外包园B区";
            headRequireItem["KHSH"] = "9150 0118 3527 6074 0J";
            headRequireItem["QYKHYHZH"] = "5000 1143 6000 5022 9630";
            headRequireItem["KPJH"] = "0";
            headRequireItem["KPR"] = "易霞";
            headRequireItem["SKR"] = "刘关键";
            headRequireItem["FHR"] = "樊磊";
            string data = Utility.ChequeHelper.GetInvoiceContent(headRequireItem, itemlist);
            string msg = string.Empty;
            Utility.ChequeHelper.doChequeWriteReceipt(data, out msg);
            this.tdWriteInvoiceResponse.InnerHtml = msg;
        }

        protected void btnGetInvoiceResult_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            bool result = Utility.ChequeHelper.doGetInvoiceResult(this.tdReceiptNumber.Value, out msg);
            this.tdInvoiceResultResponse.InnerHtml = msg;
        }
    }
}