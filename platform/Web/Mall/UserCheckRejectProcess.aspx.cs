
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Mall
{
    public partial class UserCheckRejectProcess : BasePage
    {
        public int RequestID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int.TryParse(Request.QueryString["ID"], out RequestID);
                }
                if (RequestID > 0)
                {
                    var data = Foresight.DataAccess.Mall_CheckRequest.GetMall_CheckRequest(RequestID);
                    if (data != null)
                    {
                        SetInfo(data);
                    }
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_CheckRequest data)
        {
            if (data.CheckConfirmID > 0)
            {
                var confirm = Foresight.DataAccess.Mall_CheckRequestConfirm.GetMall_CheckRequestConfirm(data.CheckConfirmID);
                if (confirm != null && confirm.ConfirmStatus == 2)
                {
                    this.tdConfirmMan.Value = confirm.ConfirmMan;
                    this.tdConfirmRemark.Value = data.ConfirmRemark;
                    this.tdConfirmTime.Value = data.ConfirmTime > DateTime.MinValue ? data.ConfirmTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
                }
            }
        }
    }
}