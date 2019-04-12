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
    public partial class printchargepayservice : BasePage
    {
        public string MoneyDaXie = string.Empty;
        public decimal money = 0;
        public ViewRoomFee viewRoomFee;
        public string FullName = string.Empty;
        public string PrintNumber = string.Empty;
        public PrintRoomFeeHistory printRoomFeeHistory = new PrintRoomFeeHistory();
        public string OwnerName = string.Empty;
        public int TempHistoryID = 0;
        public int PayServiceID = 0;
        public int PrintID = 0;
        public string FirstTitle = string.Empty;
        public string SubTitle = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int.TryParse(Request.QueryString["TempID"], out TempHistoryID);
                int.TryParse(Request.QueryString["PayServiceID"], out PayServiceID);
                int.TryParse(Request.QueryString["PrintID"], out PrintID);
                this.tdWidth.Value = "210";
                this.tdHeight.Value = "99";
                var newlist = new List<RoomFeeModule>();
                if (PrintID > 0)
                {
                    var payservice = Foresight.DataAccess.PayService.GetPayServiceByPrintID(PrintID);
                    PayServiceID = payservice != null ? payservice.ID : PayServiceID;
                    printRoomFeeHistory = PrintRoomFeeHistory.GetPrintRoomFeeHistory(PrintID);
                    var historys = Foresight.DataAccess.RoomFeeHistory.GetRoomFeeHistoryByPrintID(PrintID);
                    int RoomID = 0;
                    if (historys.Length > 0)
                    {
                        foreach (var item in historys)
                        {
                            var roomFeeModule = new RoomFeeModule();
                            roomFeeModule.HistoryID = item.HistoryID;
                            roomFeeModule.ChargeTime = item.ChargeTime;
                            roomFeeModule.RealCost = item.RealCost;
                            roomFeeModule.ChargeName = item.ChargeFeeSummaryName;
                            roomFeeModule.PrintNumber = item.PrintNumber;
                            roomFeeModule.Remark = item.BackGuaranteeRemark;
                            roomFeeModule.ChargeMan = item.ChargeMan;
                            this.money += roomFeeModule.RealCost;
                            newlist.Add(roomFeeModule);
                        }
                        RoomID = historys[0].RoomID;
                    }
                    else
                    {
                        var temhistorys = Foresight.DataAccess.TempRoomFeeHistory.GetTempRoomFeeHistorysByPrintID(PrintID);
                        if (temhistorys.Length > 0)
                        {
                            foreach (var item in temhistorys)
                            {
                                var roomFeeModule = new RoomFeeModule();
                                roomFeeModule.HistoryID = item.TempHistoryID;
                                roomFeeModule.ChargeTime = item.ChargeTime;
                                roomFeeModule.RealCost = item.RealCost;
                                roomFeeModule.ChargeName = item.ChargeFeeSummaryName;
                                roomFeeModule.PrintNumber = item.PrintNumber;
                                roomFeeModule.Remark = item.BackGuaranteeRemark;
                                roomFeeModule.ChargeMan = item.ChargeMan;
                                this.money += roomFeeModule.RealCost;
                                newlist.Add(roomFeeModule);
                            }
                            RoomID = temhistorys[0].RoomID;
                        }
                    }
                    var project = Foresight.DataAccess.Project.GetProject(RoomID);
                    if (project != null)
                    {
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
                    }
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
                }
                else
                {
                    var temphistory = Foresight.DataAccess.TempRoomFeeHistory.GetTempRoomFeeHistory(TempHistoryID);
                    if (temphistory == null)
                    {
                        Response.End();
                        return;
                    }
                    List<decimal> RealPayList = new List<decimal>();
                    List<string> RemarkList = new List<string>();

                    TempRoomFeeHistory[] list = new TempRoomFeeHistory[] { temphistory };
                    foreach (var item in list)
                    {
                        var roomFeeModule = new RoomFeeModule();
                        roomFeeModule.HistoryID = item.TempHistoryID;
                        roomFeeModule.ChargeTime = item.ChargeTime;
                        roomFeeModule.RealCost = item.RealCost;
                        roomFeeModule.ChargeName = item.ChargeFeeSummaryName;
                        roomFeeModule.PrintNumber = item.PrintNumber;
                        roomFeeModule.Remark = item.BackGuaranteeRemark;
                        roomFeeModule.ChargeMan = item.ChargeMan;
                        this.money += roomFeeModule.RealCost;
                        newlist.Add(roomFeeModule);
                    }

                    var project = Foresight.DataAccess.Project.GetProject(list[0].RoomID);
                    if (project != null)
                    {
                        printRoomFeeHistory.Remark = project.PrintCancelNote;
                        printRoomFeeHistory.RoomFullName = project.FullName;
                        var basic = Foresight.DataAccess.ViewRoomBasic.GetViewRoomBasicByRoomID(list[0].RoomID);
                        if (basic != null)
                        {
                            printRoomFeeHistory.RoomFullName = printRoomFeeHistory.RoomFullName + "-" + project.Name;
                            printRoomFeeHistory.RoomOwnerName = basic.RelationName;
                            this.OwnerName = basic.RelationName;
                        }
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
                    }
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
                    GetInfo(list[0].RoomID);
                }
                this.rptProject.DataSource = newlist;
                this.rptProject.DataBind();
                SetInfo();
            }
        }
        public class RoomFeeModule
        {
            public int HistoryID { get; set; }
            public DateTime ChargeTime { get; set; }

            public string ChargeName { get; set; }
            public decimal RealCost { get; set; }
            public string PrintNumber { get; set; }
            public string Remark { get; set; }
            public string ChargeMan { get; set; }
        }
        private void SetInfo()
        {
            this.tdPrintNumber.Value = printRoomFeeHistory.PrintNumber;
            this.MoneyDaXie = Tools.CmycurD(this.money);
            this.tdChargeMan.Value = printRoomFeeHistory.ChargeMan;
            this.tdChargeTime.Value = printRoomFeeHistory.ChargeTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.hdChargeMoneyType.Value = printRoomFeeHistory.ChageType1.ToString();
            this.hdOrderNumberID.Value = printRoomFeeHistory.OrderNumberID < 0 ? "0" : printRoomFeeHistory.OrderNumberID.ToString();
            this.tdRemark.Value = printRoomFeeHistory.Remark;
            this.FullName = printRoomFeeHistory.RoomFullName;
            this.OwnerName = printRoomFeeHistory.RoomOwnerName;
        }
        private void GetInfo(int RoomID)
        {
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