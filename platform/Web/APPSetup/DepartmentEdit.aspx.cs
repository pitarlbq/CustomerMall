using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class DepartmentEdit : BasePage
    {
        public int DepartmentID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["ID"], out DepartmentID);
            if (DepartmentID > 0)
            {
                var data = Foresight.DataAccess.Mall_Department.GetMall_Department(DepartmentID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_Department data)
        {
            this.tdDepartmentName.Value = data.Name;
            this.tdDescription.Value = data.Summary;
            this.tdSortOrder.Value = data.SortOrder > int.MinValue ? data.SortOrder.ToString() : "0";
        }
    }
}