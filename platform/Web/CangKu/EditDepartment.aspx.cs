using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CangKu
{
    public partial class EditDepartment : BasePage
    {
        public int ID;
        public int ParentID;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.CKDepartment.GetCKDepartment(ID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.CKDepartment data)
        {
            this.tdDepartmentName.Value = data.DepartmentName;
            this.tdDescription.Value = data.Description;
            this.tdSortOrder.Value = data.SortOrder > int.MinValue ? data.SortOrder.ToString() : "";
        }
    }
}