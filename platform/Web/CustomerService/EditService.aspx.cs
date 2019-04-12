using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CustomerService
{
    public partial class EditService : BasePage
    {
        public Foresight.DataAccess.CustomerService service;
        public string guid = string.Empty;
        public int ProjectID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            guid = System.Guid.NewGuid().ToString();
            int ID = 0;
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                Response.Write("ID不合法");
                Response.End();
                return;
            }
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID <= 0)
            {
                Response.Write("ID不合法");
                Response.End();
                return;
            }
            service = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            if (service != null)
            {
                SetInfo(service);
            }
            else
            {
                Response.Write("ID不合法");
                Response.End();
                return;
            }
        }
        private void SetInfo(Foresight.DataAccess.CustomerService data)
        {
            ProjectID = data.ProjectID;
            this.tdFullName.Value = data.ServiceFullName;
            this.tdProjectName.Value = data.ProjectName;
            this.tdServiceType.Value = data.ServiceTypeID == int.MinValue ? "" : data.ServiceTypeID.ToString();
            if (data.ServiceTypeID > 0)
            {
                var servicetype = Foresight.DataAccess.ServiceType.GetServiceType(data.ServiceTypeID);
                if (servicetype != null)
                {
                    this.hdServiceTypeName.Value = servicetype.ServiceTypeName;
                }
            }

            this.sAddUserName.InnerHtml = this.tdAddUserName.Value = string.IsNullOrEmpty(data.AddUserName) ? data.AddMan : data.AddUserName;
            this.sStartTime.InnerHtml = this.tdStartTime.Value = data.StartTime == DateTime.MinValue ? (data.AddTime > DateTime.MinValue ? data.AddTime.ToString("yyyy-MM-dd HH:mm:ss") : "") : data.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.tdServiceArea.Value = data.ServiceArea;
            this.tdServiceNumber.Value = data.ServiceNumber;
            this.tdAddCustomerName.Value = data.AddCustomerName;
            this.tdAddCallPhone.Value = data.AddCallPhone;
            this.tdServiceContent.Value = data.ServiceContent;
            this.tdAcceptMan.Value = (!string.IsNullOrEmpty(data.ServiceAccpetManID) && data.ServiceAccpetManID.Equals("0")) ? string.Empty : data.ServiceAccpetManID.Replace("[", "").Replace("]", "");
            this.tdAppointTime.Value = data.ServiceAppointTime == DateTime.MinValue ? "" : data.ServiceAppointTime.ToString("yyyy-MM-dd HH:mm:ss");

            this.tdHandelFee.Value = data.HandelFee;
            this.tdTotalFee.Value = data.TotalFee > 0 ? data.TotalFee.ToString() : "";
            this.tdIsRequireCost.Checked = data.IsRequireCost;
            this.tdIsRequireProduct.Checked = data.IsRequireCost;
            this.tdIsSendAPP.Checked = data.IsAPPShow;
            this.tdTaskType.Value = data.TaskType > 0 ? data.TaskType.ToString() : "";
            this.tdAcceptManInput.Value = data.ServiceAccpetMan;
            this.hdDepartmentID.Value = this.tdBelongTeamName.Value = data.DepartmentID > 0 ? data.DepartmentID.ToString() : "";
        }
    }
}