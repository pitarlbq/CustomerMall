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
    public partial class printchargefee : BasePage
    {
        public string MoneyDaXie = string.Empty;
        public decimal money = 0;
        public decimal RealCost = 0;
        public ViewRoomFee viewRoomFee;
        public string FullName = string.Empty;
        public string PrintNumber = string.Empty;
        public PrintRoomFeeHistory printRoomFeeHistory = new PrintRoomFeeHistory();
        public string OwnerName = string.Empty;
        public int PrintID = 0;
        public string FirstTitle = string.Empty;
        public string SubTitle = string.Empty;
        public string PrintFont = string.Empty;
        public bool IsPrintCount = true;
        public bool IsPrintNote = true;
        public int ColumnCount = 4;
        public bool IsPrintCost = true;
        public bool IsPrintDiscount = true;
        public bool IsPrintRoomNo = true;
        public bool IsPrintTotalRealCost = true;
        public bool IsPrintRealCost = true;
        public string LogoPath = string.Empty;
        public decimal TotalCost = 0;
        public bool ShowWeiShu = true;
        public bool IsPrintMonthCount = true;
        public int LogoWidth = 0;
        public int LogoHeight = 0;
        public bool IsPrintUnitPrice = true;
        public bool CanPrintCheque = false;
        public int RoomID = 0;
        public int ContractID = 0;
        public int DefaultRelationID = 0;
        public int PrintChargeTypeCount = 2;
        protected void Page_Load(object sender, EventArgs e)
        {
            CanPrintCheque = new Utility.SiteConfig().IsWriteChequeOn;
            this.tdWidth.Value = "210";
            this.tdHeight.Value = "99";
            int.TryParse(Request.QueryString["PrintID"], out PrintID);
            string IDs = Request.QueryString["IDs"];
            List<int> IDList = new List<int>();
            List<int> RoomIDList = new List<int>();
            List<int> ContractIDList = new List<int>();
            List<string> OwnerNameList = new List<string>();
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
                if (PrintID > 0)
                {
                    var list = ViewRoomFeeHistory.GetViewRoomFeeHistoryListByIDs(0, IDList, PrintID);
                    if (list.Length > 0)
                    {
                        RoomIDList = list.Select(p => p.RoomID).Distinct().ToList();
                    }
                    else
                    {
                        Response.End();
                        return;
                    }
                    this.rptProject.DataSource = list;
                    this.rptProject.DataBind();
                    OwnerNameList = list.Where(p => !string.IsNullOrEmpty(p.DefaultChargeManName)).Select(p => p.DefaultChargeManName).Distinct().ToList();
                    printRoomFeeHistory = PrintRoomFeeHistory.GetPrintRoomFeeHistory(PrintID);
                }
                else
                {
                    var list = ViewTempRoomFeeHistory.GetViewTempRoomFeeHistoryListByIDs(IDList);
                    if (list.Length > 0)
                    {
                        RoomIDList = list.Select(p => p.RoomID).Distinct().ToList();
                        ContractIDList = list.Where(p => p.ContractID > 0).Select(p => p.ContractID).Distinct().ToList();
                    }
                    foreach (var item in list)
                    {
                        money += item.RealCost;
                        TotalCost += item.Cost;
                    }
                    this.rptProject.DataSource = list;
                    this.rptProject.DataBind();
                    OwnerNameList = list.Where(p => !string.IsNullOrEmpty(p.DefaultChargeManName)).Select(p => p.DefaultChargeManName).Distinct().ToList();
                }
                RoomID = RoomIDList.Count > 0 ? RoomIDList[0] : 0;
                ContractID = ContractIDList.Count > 0 ? ContractIDList[0] : 0;
                if (RoomIDList.Count > 0)
                {
                    RoomID = RoomIDList[0];
                }
                var project = Foresight.DataAccess.Project.GetProjectByID(ID: RoomID, ContractID: ContractID);
                var relation = Foresight.DataAccess.RoomPhoneRelation.GetDefaultInChargeFeeRoomPhoneRelation(RoomID, ContractID);
                DefaultRelationID = relation != null ? relation.ID : 0;
                string AllParentID = string.Empty;
                if (project != null)
                {
                    AllParentID = project.AllParentID;
                    this.tdRemark.Value = project.PrintNote;
                    this.FirstTitle = project.PrintTitle;
                    this.SubTitle = project.PrintSubTitle;
                    this.PrintFont = project.PrintFont;
                    this.IsPrintCount = project.IsPrintCount;
                    this.IsPrintNote = project.IsPrintNote;
                    this.IsPrintCost = project.IsPrintCost;
                    this.IsPrintDiscount = project.IsPrintDiscount;
                    this.IsPrintRoomNo = project.IsPrintRoomNo;
                    this.IsPrintTotalRealCost = project.IsPrintTotalRealCost;
                    this.IsPrintRealCost = project.IsPrintRealCost;
                    this.IsPrintMonthCount = project.IsPrintMonthCount;
                    this.LogoPath = project.LogoPath;
                    this.LogoWidth = project.LogoWidth;
                    this.LogoHeight = project.LogoHeight;
                    this.IsPrintUnitPrice = project.IsPrintUnitPrice;
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
                    this.PrintChargeTypeCount = project.PrintChargeTypeCount;
                }
                if (this.IsPrintCount)
                {
                    this.ColumnCount++;
                }
                if (this.IsPrintNote)
                {
                    this.ColumnCount++;
                }
                if (this.IsPrintCost)
                {
                    this.ColumnCount++;
                }
                if (this.IsPrintDiscount)
                {
                    this.ColumnCount++;
                }
                if (this.IsPrintRoomNo)
                {
                    this.ColumnCount++;
                }
                if (this.IsPrintTotalRealCost)
                {
                    this.ColumnCount++;
                }
                if (this.IsPrintRealCost)
                {
                    this.ColumnCount++;
                }
                if (this.IsPrintMonthCount)
                {
                    this.ColumnCount++;
                }
                if (this.IsPrintUnitPrice)
                {
                    this.ColumnCount++;
                }
                if (string.IsNullOrEmpty(this.FirstTitle))
                {
                    this.FirstTitle = WebUtil.GetCompany(this.Context).CompanyName;
                }
                this.tdFirstTitle.Value = this.FirstTitle;
                if (string.IsNullOrEmpty(this.SubTitle))
                {
                    this.SubTitle = "收款单据";
                }
                this.tdSubTitle.InnerText = this.SubTitle;
                var configList = SysConfig.Get_SysConfigListByProjectIDList(MinProjectID: RoomID, MaxProjectID: RoomID, ConfigName: SysConfigNameDefine.RealCostCouZhengOn);
                bool isCouZhengOn = SysConfig.IsCouZhengOn(configList, AllParentID);
                if (isCouZhengOn)
                {
                    this.ShowWeiShu = true;
                }
                if (PrintID <= 0)
                {
                    GetInfo(RoomID, isCouZhengOn);
                }
                SetInfo(RoomID, isCouZhengOn);
                if (OwnerNameList.Count > 0)
                {
                    if (OwnerNameList.Count <= 3)
                    {
                        this.OwnerName = string.Join(",", OwnerNameList.ToArray());
                    }
                    else
                    {
                        this.OwnerName = OwnerNameList[0];
                    }
                }
            }
        }
        private void SetInfo(int RoomID, bool isCouZhengOn)
        {
            this.hdWeiShu.Value = "0.00";
            this.tdWeiShu.InnerHtml = "0.00";
            decimal finalweishu = PrintRoomFeeHistory.GetRoomWeiShuBalance(printRoomFeeHistory.ID, RoomID);
            if (printRoomFeeHistory.ID > 0)
            {
                this.tdWeiShu.InnerHtml = (finalweishu > 0 ? finalweishu : 0).ToString("F2");
                this.hdWeiShu.Value = (finalweishu - (printRoomFeeHistory.WeiShuMore - printRoomFeeHistory.WeiShuConsume)).ToString();
            }
            else
            {

                decimal weishumore = printRoomFeeHistory.RealCost - money;
                if (finalweishu >= (1 - weishumore))
                {
                    printRoomFeeHistory.WeiShuMore = 0;
                    printRoomFeeHistory.WeiShuConsume = (1 - weishumore);
                    if (isCouZhengOn)
                    {
                        printRoomFeeHistory.RealCost = (Math.Ceiling(money) - 1);
                        printRoomFeeHistory.RealMoneyCost1 = printRoomFeeHistory.RealCost;
                        this.hdWeiShu.Value = finalweishu.ToString("F2");
                        var final = finalweishu + (printRoomFeeHistory.WeiShuMore - printRoomFeeHistory.WeiShuConsume);
                        this.tdWeiShu.InnerHtml = final.ToString("F2");
                    }
                }
                else
                {
                    printRoomFeeHistory.WeiShuMore = weishumore;
                    printRoomFeeHistory.WeiShuConsume = 0;
                    if (isCouZhengOn)
                    {
                        printRoomFeeHistory.RealCost = Math.Ceiling(money);
                        printRoomFeeHistory.RealMoneyCost1 = printRoomFeeHistory.RealCost;
                        this.hdWeiShu.Value = finalweishu.ToString("F2");
                        var final = finalweishu + (printRoomFeeHistory.WeiShuMore - printRoomFeeHistory.WeiShuConsume);
                        this.tdWeiShu.InnerHtml = final.ToString("F2");
                    }
                }
            }

            this.tdPrintNumber.Value = printRoomFeeHistory.PrintNumber;
            this.MoneyDaXie = printRoomFeeHistory.CostCapital;
            this.TotalCost = printRoomFeeHistory.Cost;
            this.RealCost = printRoomFeeHistory.RealCost;
            this.tdRealCost.InnerHtml = printRoomFeeHistory.RealCost.ToString("F2");
            this.formatRealCost.InnerHtml = WebUtil.FormatMoney(printRoomFeeHistory.RealCost);
            this.tdPreChargeMoney.Value = printRoomFeeHistory.PreChargeMoney.ToString();
            this.tdChargeBackMoney.Value = printRoomFeeHistory.ChargeBackMoney.ToString();
            this.tdChargeMan.Value = printRoomFeeHistory.ChargeMan;
            this.tdChargeTime.Value = printRoomFeeHistory.ChargeTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.tdRealMoneyCost1.Value = printRoomFeeHistory.RealMoneyCost1 == decimal.MinValue ? "0.00" : printRoomFeeHistory.RealMoneyCost1.ToString("F2");
            this.tdRealMoneyCost2.Value = printRoomFeeHistory.RealMoneyCost2 == decimal.MinValue ? "0.00" : printRoomFeeHistory.RealMoneyCost2.ToString("F2");
            this.tdDiscountMoney.Value = printRoomFeeHistory.DiscountMoney.ToString();
            this.tdRemark.Value = printRoomFeeHistory.Remark;
            this.hdOrderNumberID.Value = printRoomFeeHistory.OrderNumberID < 0 ? "0" : printRoomFeeHistory.OrderNumberID.ToString();

        }
        private void GetInfo(int RoomID, bool isCouZhengOn)
        {
            int OrderNumberID = 0;
            string PrintNumber = Foresight.DataAccess.PrintRoomFeeHistory.GetLastestPrintNumber(Foresight.DataAccess.OrderTypeNameDefine.chargefee.ToString(), RoomID, out OrderNumberID);
            printRoomFeeHistory.PrintNumber = PrintNumber;
            printRoomFeeHistory.OrderNumberID = OrderNumberID;
            printRoomFeeHistory.Cost = TotalCost;
            printRoomFeeHistory.PreChargeMoney = 0;
            printRoomFeeHistory.ChargeBackMoney = 0;
            printRoomFeeHistory.ChargeMan = WebUtil.GetUser(this.Context).RealName;
            printRoomFeeHistory.ChargeTime = DateTime.Now;
            printRoomFeeHistory.RealMoneyCost2 = 0;
            printRoomFeeHistory.DiscountMoney = 0;
            printRoomFeeHistory.AddMan = WebUtil.GetUser(this.Context).RealName;
            printRoomFeeHistory.AddTime = DateTime.Now;
            int ChageType1 = 0;
            int.TryParse(this.tdChargeMoneyType1.Value, out ChageType1);
            printRoomFeeHistory.ChageType1 = ChageType1;
            int ChageType2 = 0;
            int.TryParse(this.tdChargeMoneyType2.Value, out ChageType2);
            printRoomFeeHistory.ChageType2 = ChageType2;
            printRoomFeeHistory.Remark = this.tdRemark.Value;
            if (isCouZhengOn)
            {
                printRoomFeeHistory.RealCost = Math.Ceiling(money);
                printRoomFeeHistory.RealMoneyCost1 = Math.Ceiling(money);
            }
            else
            {
                printRoomFeeHistory.RealCost = money;
                printRoomFeeHistory.RealMoneyCost1 = money;
            }
            printRoomFeeHistory.WeiShuMore = 0;
            printRoomFeeHistory.WeiShuConsume = 0;
            printRoomFeeHistory.CostCapital = Tools.CmycurD(printRoomFeeHistory.RealCost);
        }
        protected void rptProject_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}