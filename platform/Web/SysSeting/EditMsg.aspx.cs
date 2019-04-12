using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;


namespace Web.SysSeting
{
    public partial class EditMsg : BasePage
    {
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.SystemMsg.GetSystemMsg(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.SystemMsg data)
        {
            this.tdTitle.Value = data.Title;
            this.tdSortOrder.Value = data.SortOrder > 0 ? data.SortOrder.ToString() : "";
            this.hdContent.Value = string.IsNullOrEmpty(data.ContentSummary) ? string.Empty : data.ContentSummary;
            this.tdIsTopShow.Value = data.IsTopShow ? "1" : "0";
            var list = Foresight.DataAccess.SystemMsg_Company.GetSystemMsg_CompanyList(data.ID);
            var CompanyIDList = list.Select(p => p.CompanyID).ToList();
            if (CompanyIDList.Count > 0)
            {
                this.hdCompanys.Value = JsonConvert.SerializeObject(CompanyIDList);
                var companylist = Foresight.DataAccess.Company.GetAllActiveCompanyList().Where(p => CompanyIDList.Contains(p.CompanyID)).ToArray();
                this.tdCompanyNames.Value = string.Join(",", companylist.Select(p => p.CompanyName).ToArray());
            }
            this.tdDisableNotify.Value = data.DisableNotify ? "1" : "0";
            this.tdIsNotifyALL.Value = data.IsNotifyALL ? "1" : "0";
        }
    }
}