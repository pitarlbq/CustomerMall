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
    public partial class printchargebackguaranteefee : BasePage
    {
        public string MoneyDaXie = string.Empty;
        public decimal money = 0;
        public ViewRoomFee viewRoomFee;
        public string FullName = string.Empty;
        public string PrintNumber = string.Empty;
        public PrintRoomFeeHistory printRoomFeeHistory = new PrintRoomFeeHistory();
        public string OwnerName = string.Empty;
        public string FirstTitle = string.Empty;
        public string SubTitle = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string GUID = Request.QueryString["guid"];
            var temp = ChargeBackGuaranteeTemp.GetChargeBackGuaranteeTempListByGUID(GUID);
            List<decimal> RealPayList = new List<decimal>();
            List<string> RemarkList = new List<string>();
            this.tdWidth.Value = "210";
            this.tdHeight.Value = "99";
            List<int> IDList = temp.Select(p => p.HistoryID).ToList();
            if (IDList.Count == 0)
            {
                Response.End();
                return;
            }
            if (!IsPostBack)
            {
                int RoomID = 0;
                int DefaultChargeManID = 0;
                var list = ViewRoomFeeHistory.GetViewRoomFeeHistoryListByIDs(IDList);
                if (list.Length == 0)
                {
                    Response.End();
                    return;
                }
                RoomID = list[0].RoomID;
                DefaultChargeManID = list[0].DefaultChargeManID;
                var historyfees = list;
                var newlist = new List<RoomFeeModule>();
                foreach (var item in temp)
                {
                    var roomFeeModule = new RoomFeeModule();
                    var viewRoomFeeHistory = list.FirstOrDefault(p => p.HistoryID == item.HistoryID);
                    if (viewRoomFeeHistory != null)
                    {
                        roomFeeModule.HistoryID = viewRoomFeeHistory.HistoryID;
                        roomFeeModule.ChargeTime = viewRoomFeeHistory.ChargeTime;
                        roomFeeModule.RealCost = item.RealPay;
                        roomFeeModule.ChargeName = viewRoomFeeHistory.ChargeName;
                        roomFeeModule.PrintNumber = viewRoomFeeHistory.PrintNumber;
                        roomFeeModule.Remark = item.Remark;
                        roomFeeModule.ChargeMan = viewRoomFeeHistory.ChargeMan;
                        this.money += roomFeeModule.RealCost;
                        newlist.Add(roomFeeModule);
                    }
                }
                this.rptProject.DataSource = newlist;
                this.rptProject.DataBind();
                var project = Foresight.DataAccess.Project.GetProjectByID(ID: RoomID, ContractID: 0);
                if (project != null)
                {
                    this.tdRemark.Value = project.PrintCancelNote;
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
                if (DefaultChargeManID > 0)
                {
                    relation = RoomPhoneRelation.GetRoomPhoneRelation(DefaultChargeManID);
                }
                if (relation == null)
                {
                    relation = RoomPhoneRelation.GetDefaultInChargeFeeRoomPhoneRelation(RoomID, ContractID: 0);
                }
                if (relation != null)
                {
                    this.OwnerName = relation.RelationName;
                }
                GetInfo(RoomID);
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