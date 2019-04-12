using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.InsideCustomer
{
    public partial class EditInsideCustomer : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    Response.End();
                    return;
                }
                int ID = int.Parse(Request.QueryString["ID"]);
                var customer = Foresight.DataAccess.InsideCustomer.GetInsideCustomer(ID);
                if (customer == null)
                {
                    Response.End();
                    return;
                }
                SetInfo(customer);
            }
        }
        private void SetInfo(Foresight.DataAccess.InsideCustomer data)
        {
            this.tdCustomerName.Value = data.CustomerName;
            this.tdCategoryName.Value = data.CategoryName;
            this.tdInteresting.Value = data.Interesting;
            this.tdContactMan.Value = data.ContactMan;
            this.tdContactPhone.Value = data.ContactPhone;
            this.tdQQNo.Value = data.QQNo;
            this.tdQQGroupInvitation.Value = data.QQGroupInvitation;
            this.tdWechatNo.Value = data.WechatNo;
            this.tdWechaGroupInvitation.Value = data.WechaGroupInvitation;
            this.tdOtherContactMan.Value = data.OtherContactMan;
            this.tdNewFollowup.Value = string.Empty;
            this.tdBusinessStage.Value = data.BusinessStage;
            this.tdCost.Value = data.Cost > 0 ? data.Cost.ToString() : "0";
            this.tdDealProbably.Value = data.DealProbably;
            this.tdRemark.Value = data.Remark;
            var followupList = Foresight.DataAccess.InsideCustomer_Followup.GetInsideCustomer_FollowupList(data.ID);
            string historyFollowupContent = string.Empty;
            foreach (var item in followupList)
            {
                historyFollowupContent += item.FollowupDate.ToString("yyyy-MM-dd HH:mm:ss") + "： " + item.FollowupContent + "。 ";
            }
            this.tdHistoryNewFollowup.Value = historyFollowupContent;
        }
    }
}