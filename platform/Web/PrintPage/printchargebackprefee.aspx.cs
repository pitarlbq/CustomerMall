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
    public partial class printchargebackprefee : BasePage
    {
        public string MoneyDaXie = string.Empty;
        public decimal money = 0;
        public ViewRoomFee viewRoomFee;
        public string FullName = string.Empty;
        public string PrintNumber = string.Empty;
        public PrintRoomFeeHistory printRoomFeeHistory = null;
        public string OwnerName = string.Empty;
        public int PrintID = 0;
        public int ChargeID = 0;
        public string RoomIDs = string.Empty;
        public string FirstTitle = string.Empty;
        public string SubTitle = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.tdWidth.Value = "210";
                this.tdHeight.Value = "99";
                int.TryParse(Request.QueryString["PrintID"], out PrintID);
                int.TryParse(Request.QueryString["ChargeID"], out ChargeID);
                this.RoomIDs = Request.QueryString["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                var newlist = new List<Utility.RoomFeeModule>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                if (PrintID > 0)
                {
                    printRoomFeeHistory = PrintRoomFeeHistory.GetPrintRoomFeeHistory(PrintID);
                    var list = ViewRoomFeeHistory.GetPreChargeViewRoomFeeHistoryList(PrintID);
                    for (int i = 0; i < list.Length; i++)
                    {
                        var roomFeeModule = new Utility.RoomFeeModule();
                        roomFeeModule.ChargeFeeSummaryName = list[i].ChargeFeeSummaryName;
                        roomFeeModule.RealCost = list[i].RealCost;
                        roomFeeModule.ChargeFeeCurrentBalance = list[i].ChargeFeeCurrentBalance;
                        roomFeeModule.TotalRestBalance = list[i].ChargeFeeCurrentBalance - list[i].RealCost;
                        newlist.Add(roomFeeModule);
                    }
                    this.money = printRoomFeeHistory.RealCost;
                }
                else
                {
                    string ChargeFeeSummaryName = "退预收款";
                    if (ChargeID > 0)
                    {
                        var chargesummary = Foresight.DataAccess.ChargeSummary.GetChargeSummary(ChargeID);
                        ChargeFeeSummaryName = chargesummary != null ? "退" + chargesummary.Name : "退预收款";
                    }
                    decimal ChargeFeeCurrentBalance = Foresight.DataAccess.ViewRoomBalance.GetPreChargeBalance(RoomIDList, ChargeID);
                    var roomFeeModule = new Utility.RoomFeeModule();
                    roomFeeModule.ChargeFeeSummaryName = ChargeFeeSummaryName;
                    roomFeeModule.RealCost = ChargeFeeCurrentBalance;
                    roomFeeModule.ChargeFeeCurrentBalance = ChargeFeeCurrentBalance;
                    roomFeeModule.TotalRestBalance = 0;
                    newlist.Add(roomFeeModule);
                    this.money = ChargeFeeCurrentBalance;
                }
                this.rptProject.DataSource = newlist;
                this.rptProject.DataBind();
                var project = Foresight.DataAccess.Project.GetProject(RoomIDList[0]);
                if (project != null)
                {
                    this.tdRemark.Value = project.PrintNote;
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
                    this.FirstTitle = project.PayPrintTitle;
                    this.SubTitle = project.PayPrintSubTitle;
                    if (string.IsNullOrEmpty(this.FirstTitle))
                    {
                        this.FirstTitle = WebUtil.GetCompany(this.Context).CompanyName;
                    }
                    this.tdFirstTitle.InnerHtml = this.FirstTitle;
                    if (string.IsNullOrEmpty(this.SubTitle))
                    {
                        this.SubTitle = "付款单据";
                    }
                    this.tdSubTitle.InnerText = this.SubTitle;
                    this.FullName = project.FullName + "-" + project.Name;
                }
                RoomPhoneRelation relation = null;
                if (relation == null)
                {
                    relation = RoomPhoneRelation.GetDefaultInChargeFeeRoomPhoneRelation(RoomIDList[0], 0);
                }
                if (relation != null)
                {
                    this.OwnerName = relation.RelationName;
                }
                if (printRoomFeeHistory == null)
                {
                    GetInfo(RoomIDList[0]);
                }
                SetInfo();
            }
        }
        private void SetInfo()
        {
            this.tdPrintNumber.Value = printRoomFeeHistory.PrintNumber;
            this.MoneyDaXie = printRoomFeeHistory.CostCapital;
            this.tdChargeMan.Value = printRoomFeeHistory.ChargeMan;
            this.tdChargeTime.Value = printRoomFeeHistory.ChargeTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.tdRemark.Value = printRoomFeeHistory.Remark;
            this.hdChargeMoneyType.Value = printRoomFeeHistory.ChageType1.ToString();
            this.hdOrderNumberID.Value = printRoomFeeHistory.OrderNumberID < 0 ? "0" : printRoomFeeHistory.OrderNumberID.ToString();
        }
        private void GetInfo(int RoomID)
        {
            if (printRoomFeeHistory == null)
            {
                printRoomFeeHistory = new PrintRoomFeeHistory();
            }
            int OrderNumberID = 0;
            string PrintNumber = Foresight.DataAccess.PrintRoomFeeHistory.GetLastestPrintNumber(Foresight.DataAccess.OrderTypeNameDefine.chargebackfee.ToString(), RoomID, out OrderNumberID);
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
            printRoomFeeHistory.ChageType1 = 0;
        }
    }
}