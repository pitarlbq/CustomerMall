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
    public partial class printoffsetchargefee : BasePage
    {
        public string MoneyDaXie = string.Empty;
        public decimal money = 0;
        public decimal TotalCost = 0;
        public ViewRoomFee viewRoomFee;
        public string FullName = string.Empty;
        public string PrintNumber = string.Empty;
        public PrintRoomFeeHistory printRoomFeeHistory = new PrintRoomFeeHistory();
        public string OwnerName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.tdWidth.Value = "210";
            this.tdHeight.Value = "99";
            int PrintID = 0;
            int.TryParse(Request.QueryString["PrintID"], out PrintID);
            string IDs = Request.QueryString["IDs"];
            List<int> IDList = new List<int>();
            List<int> RoomIDList = new List<int>();
            if (PrintID == 0)
            {
                if (string.IsNullOrEmpty(IDs))
                {
                    Response.End();
                    return;
                }
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
                if (PrintID > 0)
                {
                    var list = ViewRoomFeeHistory.GetViewRoomFeeHistoryListByIDs(0, IDList, PrintID);
                    if (list.Length > 0)
                    {
                        RoomID = list[0].RoomID;
                        ContractID = list[0].ContractID;
                        DefaultChargeManID = list[0].DefaultChargeManID;
                    }
                    this.rptProject.DataSource = list;
                    this.rptProject.DataBind();
                    printRoomFeeHistory = PrintRoomFeeHistory.GetPrintRoomFeeHistory(PrintID);
                }
                else
                {
                    var list = ViewTempRoomFeeHistory.GetViewTempRoomFeeHistoryListByIDs(IDList);
                    if (list.Length > 0)
                    {
                        RoomID = list[0].RoomID;
                    }
                    foreach (var item in list)
                    {
                        money += item.ChargeFee;
                        TotalCost += item.Cost;
                    }
                    var historyfees = list;
                    this.rptProject.DataSource = historyfees;
                    this.rptProject.DataBind();
                }
                var project = Foresight.DataAccess.Project.GetProjectByID(ID: RoomID, ContractID: ContractID);
                if (project != null)
                {
                    this.tdRemark.Value = project.PrintNote;
                    this.tdFirstTitle.Value = project.PrintTitle;
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
                if (PrintID <= 0)
                {
                    GetInfo(RoomID);
                }
                SetInfo();
            }
        }
        private void SetInfo()
        {

            this.tdPrintNumber.Value = printRoomFeeHistory.PrintNumber;
            this.MoneyDaXie = printRoomFeeHistory.CostCapital;
            this.money = printRoomFeeHistory.Cost;
            this.tdChargeMan.Value = printRoomFeeHistory.ChargeMan;
            this.tdChargeTime.Value = printRoomFeeHistory.ChargeTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.tdRemark.Value = printRoomFeeHistory.Remark;
            this.hdOrderNumberID.Value = printRoomFeeHistory.OrderNumberID < 0 ? "0" : printRoomFeeHistory.OrderNumberID.ToString();
            this.tdChargeForSummary.Value = printRoomFeeHistory.ChargeForSummary;
            this.tdChargeMethods.Value = printRoomFeeHistory.ChargeMethods;
        }
        private void GetInfo(int RoomID)
        {
            int OrderNumberID = 0;
            string PrintNumber = Foresight.DataAccess.PrintRoomFeeHistory.GetLastestPrintNumber(Foresight.DataAccess.OrderTypeNameDefine.offseefee.ToString(), RoomID, out OrderNumberID);
            printRoomFeeHistory.PrintNumber = PrintNumber;
            printRoomFeeHistory.OrderNumberID = OrderNumberID;
            printRoomFeeHistory.Cost = money;
            printRoomFeeHistory.CostCapital = Tools.CmycurD(money);
            printRoomFeeHistory.RealCost = money;
            printRoomFeeHistory.PreChargeMoney = 0;
            printRoomFeeHistory.ChargeBackMoney = 0;
            printRoomFeeHistory.ChargeMan = WebUtil.GetUser(this.Context).RealName;
            printRoomFeeHistory.ChargeTime = DateTime.Now;
            printRoomFeeHistory.RealMoneyCost1 = money;
            printRoomFeeHistory.RealMoneyCost2 = 0;
            printRoomFeeHistory.DiscountMoney = 0;
            printRoomFeeHistory.AddMan = WebUtil.GetUser(this.Context).RealName;
            printRoomFeeHistory.AddTime = DateTime.Now;
            printRoomFeeHistory.ChageType1 = 3;
        }
        protected void rptProject_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}