using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Wechat
{
    public partial class EditWechatContact : BasePage
    {
        public string type = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["type"] != null)
                {
                    type = Request.QueryString["type"];
                }
                int ID = 0;
                int.TryParse(Request.QueryString["ID"], out ID);
                if (ID > 0)
                {
                    var data = Foresight.DataAccess.Wechat_Contact.GetWechat_Contact(ID);
                    if (data != null)
                    {
                        SetInfo(data);
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(type))
                {
                    this.tdPhoneType.Value = type;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Wechat_Contact data)
        {
            if (!string.IsNullOrEmpty(type))
            {
                this.tdPhoneType.Value = type;
            }
            else
            {
                this.tdPhoneType.Value = data.CategoryID > 0 ? data.CategoryID.ToString() : "";
            }
            this.tdName.Value = data.Name;
            this.tdPhoneNumber.Value = data.PhoneNumber;
            this.tdRemark.Value = data.Remark;
            var list = Foresight.DataAccess.Wechat_ContactProject.GetWechat_ContactProjectList(data.ID);
            var ProjectIDList = list.Select(p => p.ProjectID).ToList();
            if (ProjectIDList.Count > 0)
            {
                this.hdProjectIDs.Value = JsonConvert.SerializeObject(ProjectIDList);
            }
        }
    }
}