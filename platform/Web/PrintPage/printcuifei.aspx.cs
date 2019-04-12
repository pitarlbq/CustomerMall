using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Foresight.DataAccess;
using Utility;
using Foresight.DataAccess.Framework;

namespace Web.PrintPage
{
    public partial class printcuifei : BasePage
    {
        public string MoneyDaXie = string.Empty;
        public decimal money = 0;
        public string FullName = string.Empty;
        public string PrintNumber = string.Empty;
        public string OwnerName = string.Empty;
        public int ColumnCount = 7;
        public bool IsPrintUnitPrice = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.tdWidth.Value = "210";
            this.tdHeight.Value = "99";
            string IDs = Request.QueryString["IDs"];
            List<int> IDList = new List<int>();
            if (string.IsNullOrEmpty(IDs))
            {
                Response.End();
                return;
            }
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (!IsPostBack)
            {
                int RoomID = 0;
                int ContractID = 0;
                int DefaultChargeManID = 0;
                var list = ViewRoomFee.GetViewRoomFeeListByIDs(IDList, UserID: WebUtil.GetUser(this.Context).UserID);
                if (list.Length > 0)
                {
                    RoomID = list[0].RoomID;
                    ContractID = list[0].ContractID;
                    DefaultChargeManID = list[0].DefaultChargeManID;
                }
                foreach (var item in list)
                {
                    money += item.TotalCost;
                }
                this.rptProject.DataSource = list;
                this.rptProject.DataBind();
                var project = Foresight.DataAccess.Project.GetProjectByID(ID: RoomID, ContractID: ContractID);
                if (project != null)
                {
                    this.tdRemark.Value = project.CuiFeiNote;
                    this.tdFirstTitle.InnerHtml = project.PrintTitle;
                    if (project.IsDefinePrintSize)
                    {
                        this.tdWidth.Value = project.PrintWidth > 0 ? project.PrintWidth.ToString() : "210";
                        this.tdHeight.Value = project.PrintHeight > 0 ? project.PrintHeight.ToString() : WebUtil.GetPrintHeight().ToString();
                    }
                    else
                    {
                        this.tdWidth.Value = "210";
                        this.tdHeight.Value = WebUtil.GetPrintHeight(project.PrintType).ToString();
                    }
                    this.IsPrintUnitPrice = project.IsPrintUnitPrice;
                    if (this.IsPrintUnitPrice)
                    {
                        this.ColumnCount++;
                    }
                    this.FullName = project.FullName + "-" + project.Name;
                }
                RoomPhoneRelation relation = null;
                if (DefaultChargeManID > 0)
                {
                    relation = RoomPhoneRelation.GetRoomPhoneRelation(DefaultChargeManID);
                }
                if (relation == null)
                {
                    relation = RoomPhoneRelation.GetDefaultInChargeFeeRoomPhoneRelation(RoomID, ContractID);
                }
                if (relation != null)
                {
                    this.OwnerName = relation.RelationName;
                }
                SetInfo(RoomID);
            }
        }
        private void SetInfo(int RoomID)
        {
            this.tdChargeMan.Value = WebUtil.GetUser(this.Context).RealName;
            this.tdChargeTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        protected void rptProject_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}