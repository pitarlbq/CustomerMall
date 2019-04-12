using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CangKu
{
    public partial class EditCkOut : BasePage
    {
        public int ID = 0;
        public int ServiceID = 0;
        public string ContractNumber = string.Empty;
        public int CKCategoryID = 0;
        public bool canEdit = false;
        public string op = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceID = 0;
            int.TryParse(Request.QueryString["ServiceID"], out ServiceID);
            ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            op = Request.QueryString["op"];
            op = string.IsNullOrEmpty(op) ? "view" : op;
            if (ID <= 0)
            {
                canEdit = true;
            }
            if (ID > 0)
            {
                var data = Foresight.DataAccess.CKProductOutSumary.GetCKProductOutSumary(ID);
                if (data != null)
                {

                    if (op.Equals("edit"))
                    {
                        canEdit = true;
                        if (data.ApproveStatus == 1)
                        {
                            canEdit = false;
                        }
                    }
                    SetInfo(data);
                    return;
                }
            }
            int.TryParse(Request.QueryString["CKCategoryID"], out CKCategoryID);
            SetCKName(CKCategoryID);
            this.tdAddUserName.Value = WebUtil.GetUser(this.Context).RealName;
            this.tdOutTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //ContractNumber = Foresight.DataAccess.CKContarct.GetLastestContractNumber();
        }
        private void SetInfo(Foresight.DataAccess.CKProductOutSumary data)
        {
            this.tdAddUserName.Value = data.AddUserName;
            this.tdOutTime.Value = data.OutTime > DateTime.MinValue ? data.OutTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
            this.tdOrderNumber.Value = data.OrderNumber;
            this.tdAccpetUser.Value = data.AcceptUserID > 0 ? data.AcceptUserID.ToString() : "";
            this.tdAccpetDepartmentName.Value = data.AccpetDepartmentName;
            this.tdUseFor.Value = data.UseFor;
            this.tdInCategory.Value = data.InCategoryID > 0 ? data.InCategoryID.ToString() : "";
            this.tdBelongTeamName.Value = data.BelongDepartmentID > 0 ? data.BelongDepartmentID.ToString() : "";
            if (data.CKCategoryID > 0)
            {
                this.CKCategoryID = data.CKCategoryID;
                SetCKName(data.CKCategoryID);
            }
        }
        private void SetCKName(int CKCategoryID)
        {
            if (CKCategoryID > 0)
            {
                string CKName = WebUtil.GetCompany(this.Context).CompanyName;
                var ckcategory = Foresight.DataAccess.CKCategory.GetCKCategory(CKCategoryID);
                if (ckcategory != null)
                {
                    if (ckcategory.ParentID == 1)
                    {
                        CKName = CKName + " - " + ckcategory.CategoryName;
                    }
                    else if (ckcategory.ParentID > 1)
                    {
                        var parent_ckcategory = Foresight.DataAccess.CKCategory.GetCKCategory(ckcategory.ParentID);
                        if (parent_ckcategory != null)
                        {
                            CKName = CKName + " - " + parent_ckcategory.CategoryName;
                        }
                        CKName = CKName + " - " + ckcategory.CategoryName;
                    }
                }
                this.CKCategoryName.InnerHtml = CKName;
            }
        }
    }
}