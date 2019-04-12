using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class EditProject : BasePage
    {
        public int ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.Cheque_Project.GetCheque_Project(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Cheque_Project data)
        {
            this.tdProjectName.Value = data.ProjectName;
            this.tdProjectNumber.Value = data.ProjectNumber;
            this.tdProjectCategoryID.Value = data.ProjectCategoryID > 0 ? data.ProjectCategoryID.ToString() : "";
            this.tdDepartmentID.Value = data.DepartmentID > 0 ? data.DepartmentID.ToString() : "";
            this.tdDepartmentName.Value = data.DepartmentName;
            this.tdManagerName.Value = data.ManagerName;
        }
    }
}