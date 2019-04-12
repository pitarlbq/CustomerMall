using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.RoomResource
{
    public partial class EditRoomName : BasePage
    {
        public int show_address = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                Response.End();
                return;
            }
            int ID = 0;
            if (!int.TryParse(Request.QueryString["ID"], out ID))
            {
                Response.End();
                return;
            }
            var project = Project.GetProject(ID);
            if (project == null)
            {
                Response.End();
                return;
            }
            if (project.ParentID == 1)
            {
                show_address = 1;
            }
            if (project.PrintWidth == decimal.MinValue && project.PrintHeight == decimal.MinValue)
            {
                project.PrintTitle = WebUtil.GetCompany(this.Context).CompanyName;
                project.CuiShouPrintTitle = WebUtil.GetCompany(this.Context).CompanyName;
                project.PrintFont = "100%";
                project.PrintSubTitle = "收款单据";
                project.CuiShouPrintSubTitle = "催费通知单";
                project.IsPrintCount = true;
                project.IsPrintNote = true;
                project.IsPrintCost = true;
                project.IsPrintDiscount = true;
                project.PrintWidth = 210;
                project.PrintHeight = 99;
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        project.Save(helper);
                        string commandText = @"update Project set [PrintTitle]=" + (string.IsNullOrEmpty(project.PrintTitle) ? "NULL" : "'" + project.PrintTitle + "'") + ",[PrintSubTitle]=" + (string.IsNullOrEmpty(project.PrintSubTitle) ? "NULL" : "'" + project.PrintSubTitle + "'") + ",[CuiShouPrintTitle]=" + (string.IsNullOrEmpty(project.CuiShouPrintTitle) ? "NULL" : "'" + project.CuiShouPrintTitle + "'") + ",[CuiShouPrintSubTitle]=" + (string.IsNullOrEmpty(project.CuiShouPrintSubTitle) ? "NULL" : "'" + project.CuiShouPrintSubTitle + "'") + ",[PrintFont]=" + (string.IsNullOrEmpty(project.PrintFont) ? "NULL" : "'" + project.PrintFont + "'") + ",[IsPrintNote]=1,[IsPrintCount]=1,[PrintWidth]=210,[PrintHeight]=99,[IsPrintCost]=1,[IsPrintDiscount]=1,[IsPrintRoomNo]=1 where [AllParentID] like '%," + project.ID + ",%' or [ID]=" + project.ID;
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(commandText, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception)
                    {
                        helper.Rollback();
                    }
                }
            }
            this.tdProjectName.Value = project.Name;
            this.tdOrderBy.Value = project.OrderBy == int.MinValue ? "" : project.OrderBy.ToString();
            this.hdAddressProvice.Value = this.tdAddressProvice.Value = project.AddressProvinceID > 0 ? project.AddressProvinceID.ToString() : "";
            this.hdAddressCity.Value = this.tdAddressCity.Value = project.AddressCity;
            this.hdAddressDistrict.Value = this.tdAddressDistrict.Value = project.AddressDistrict;
        }
    }
}