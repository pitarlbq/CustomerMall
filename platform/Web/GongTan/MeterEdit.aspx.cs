using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web.GongTan
{
    public partial class MeterEdit : BasePage
    {
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int.TryParse(Request.QueryString["ID"], out ID);
                }
                ChargeMeter_Project data = null;
                if (ID > 0)
                {
                    data = ChargeMeter_Project.GetChargeMeter_Project(ID);
                }
                if (data == null)
                {
                    this.tdMeterCoefficient.Value = "1";
                    Response.End();
                    return;
                }
                SetInfo(data);
            }
        }
        private void SetInfo(ChargeMeter_Project data)
        {
            this.tdMeterName.Value = data.MeterName;
            this.tdMeterNumber.Value = data.MeterNumber;
            this.tdMeterCategory.Value = data.MeterCategoryID > 0 ? data.MeterCategoryID.ToString() : "";
            this.tdMeterType.Value = data.MeterType > 0 ? data.MeterType.ToString() : "";
            this.tdMeterSpec.Value = data.MeterSpec > 0 ? data.MeterSpec.ToString() : "";
            this.tdMeterCoefficient.Value = data.MeterCoefficient > decimal.MinValue ? data.MeterCoefficient.ToString() : "";
            var charge = ChargeSummary.GetChargeSummary(data.MeterChargeID);
            if (charge != null)
            {
                this.tdChargeSummary.InnerHtml = charge.Name;
            }
            this.tdMeterHouseNo.Value = data.MeterHouseNo;
            this.tdMeterLocation.Value = data.MeterLocation;
            this.tdSortOrder.Value = data.SortOrder > int.MinValue ? data.SortOrder.ToString() : "";
            this.tdMeterRemark.Value = data.MeterRemark;
            var project = Project.GetProject(data.ProjectID);
            if (project != null)
            {
                this.tdProjectNames.InnerHtml = project.FullName + "-" + project.Name;
            }
        }
    }
}