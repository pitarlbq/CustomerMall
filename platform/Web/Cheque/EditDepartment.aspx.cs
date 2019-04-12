using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class EditDepartment : BasePage
    {
        public int ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.Cheque_Department.GetCheque_Department(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Cheque_Department data)
        {
            this.tdDepartmentName.Value = data.DepartmentName;
            this.tdDescription.Value = data.Description;
            this.tdDepartmentNumber.Value = data.DepartmentNumber;
            this.tdDepartmentInChargeMan.Value = data.DepartmentInChargeMan;
            this.tdDepartmentCategoryID.Value = data.DepartmentCategoryID > 0 ? data.DepartmentCategoryID.ToString() : "";
        }
    }
}