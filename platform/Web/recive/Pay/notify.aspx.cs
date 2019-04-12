using Foresight.DataAccess;
using Foresight.DataAccess.Framework;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Pay
{
    public partial class notify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string PostData = PostInput();
                HuiShouYin.Domain.PayNotify notify = JsonConvert.DeserializeObject<HuiShouYin.Domain.PayNotify>(PostData);
                string subject = notify.subject;
                string out_trade_no = notify.out_trade_no;
                string hy_bill_no = notify.hy_bill_no;
                int total_fee = Convert.ToInt32(notify.total_fee);
                int real_fee = Convert.ToInt32(notify.real_fee);
                string trade_status = notify.trade_status;
                string pay_option = notify.pay_option;

                //string subject = HuiShouYin.Util.Tools.GetJosnValue(PostData, "subject");
                //string out_trade_no = HuiShouYin.Util.Tools.GetJosnValue(PostData, "out_trade_no");
                //string hy_bill_no = HuiShouYin.Util.Tools.GetJosnValue(PostData, "hy_bill_no");
                //int total_fee = Convert.ToInt32(HuiShouYin.Util.Tools.GetJosnValue(PostData, "total_fee"));
                //int real_fee = Convert.ToInt32(HuiShouYin.Util.Tools.GetJosnValue(PostData, "real_fee"));
                //string trade_status = HuiShouYin.Util.Tools.GetJosnValue(PostData, "trade_status");
                //string pay_option = HuiShouYin.Util.Tools.GetJosnValue(PostData, "pay_option");
                LogHelper.WriteInfo("", string.Format("subject:{0},out_trade_no:{1},hy_bill_no:{2},total_fee:{3},real_fee{4},trade_status{5},pay_option{6}", subject, out_trade_no, hy_bill_no, total_fee, real_fee, trade_status, pay_option));
                if (!string.IsNullOrEmpty(trade_status))
                {
                    var HuiReturn = Foresight.DataAccess.HuiShouYinReturn.GetHuiShouYinReturn(hy_bill_no);
                    if (HuiReturn == null)
                    {
                        HuiReturn = new Foresight.DataAccess.HuiShouYinReturn();
                    }
                    HuiReturn.subject = subject;
                    HuiReturn.out_trade_no = out_trade_no;
                    HuiReturn.hy_bill_no = hy_bill_no;
                    HuiReturn.total_fee = total_fee;
                    HuiReturn.real_fee = real_fee;
                    HuiReturn.trade_status = trade_status;
                    HuiReturn.pay_option = pay_option;
                    HuiReturn.Save();
                    //pay_option = pay_option.Replace("\\", "");
                    var model = JsonConvert.DeserializeObject<HuiShouYin.Domain.Pay_Option>(pay_option);
                    string errormsg = string.Empty;
                    if (!WxPayComplete(model, out errormsg))
                    {
                        //HuiReturn.Delete();
                        LogHelper.WriteDebug("Web.Pay._return", errormsg);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Web.Pay", "_return", ex);
            }
            Response.Write("success");
        }
        private bool WxPayComplete(HuiShouYin.Domain.Pay_Option PayOption, out  string errormsg)
        {
            errormsg = string.Empty;
            string OpenID = PayOption.openid;
            var wuser = Foresight.DataAccess.Wechat_User.GetWechat_UserByUserOpenID(OpenID);
            string AddMan = (wuser != null && !string.IsNullOrEmpty(wuser.NickName)) ? wuser.NickName : OpenID;
            PrintRoomFeeHistory printRoomFeeHistory = new PrintRoomFeeHistory();
            var ModelList = PayOption.idlist;
            if (ModelList.Count == 0)
            {
                errormsg = "需要支付的费项不存在";
                return false;
            }
            var list = new List<RoomFeeAnalysis>();
            int RoomID = 0;
            string AllParentID = string.Empty;
            foreach (var item in ModelList)
            {
                var viewRoomFee = RoomFeeAnalysis.GetRoomFeeAnalysisByEndTime(item.ID, Convert.ToDateTime(item.EndTime));
                if (viewRoomFee == null)
                {
                    continue;
                }
                list.Add(viewRoomFee);
                RoomID = viewRoomFee.RoomID;
                AllParentID = viewRoomFee.AllParentID;
            }
            if (list.Count == 0)
            {
                errormsg = "需要支付的费项不存在";
                return false;
            }
            var ConfigName = SysConfigNameDefine.WeixinChargeMan;
            var sysConfigList = SysConfig.Get_SysConfigListByProjectIDList(MinProjectID: RoomID, MaxProjectID: RoomID, ConfigName: ConfigName);
            string ChargeMan = SysConfig.GetConfigValueByList(sysConfigList, ConfigName, AllParentID: AllParentID);
            decimal TotalCost = list.Sum(p => p.TotalCost);
            var ViewChargeSummaryList = ViewChargeSummary.GetViewChargeSummaries().ToArray();
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    SavePrintRoomFeeHistory(printRoomFeeHistory, list[0].RoomID, TotalCost, ChargeMan, helper, list[0].FullName + "-" + list[0].RoomName, list[0].FinalCustomerName);
                    foreach (var field in list)
                    {
                        var roomFee = Foresight.DataAccess.RoomFee.GetRoomFee(field.ID, helper);
                        if (roomFee == null)
                        {
                            continue;
                        }
                        roomFee.StartTime = field.CalculateStartTime > DateTime.MinValue ? field.CalculateStartTime : DateTime.MinValue;
                        roomFee.EndTime = field.CalculateEndTime > DateTime.MinValue ? field.CalculateEndTime : DateTime.MinValue;
                        roomFee.NewEndTime = field.NewEndTime > DateTime.MinValue ? field.NewEndTime : DateTime.MinValue;
                        roomFee.OutDays = roomFee.OutDays;
                        roomFee.UseCount = field.UseCount;
                        roomFee.Cost = field.TotalCost;
                        roomFee.Remark = roomFee.Remark;
                        roomFee.IsCharged = true;
                        roomFee.UnitPrice = field.CalculateUnitPrice > decimal.MinValue ? field.CalculateUnitPrice : 0;
                        roomFee.ChargeFee = roomFee.ChargeFee > decimal.MinValue ? roomFee.ChargeFee : 0;
                        roomFee.RealCost = roomFee.ChargeFee > 0 ? roomFee.ChargeFee : (field.TotalCost > decimal.MinValue ? field.TotalCost : 0);
                        roomFee.Discount = field.Discount > decimal.MinValue ? field.Discount : 0;
                        roomFee.TotalRealCost = (roomFee.TotalRealCost < 0 ? 0 : roomFee.TotalRealCost) + roomFee.RealCost;
                        roomFee.TotalDiscountCost = (roomFee.TotalDiscountCost < 0 ? 0 : roomFee.TotalDiscountCost) + roomFee.Discount;
                        decimal restcost = roomFee.Cost - roomFee.TotalDiscountCost - roomFee.TotalRealCost;
                        if (restcost < 0)
                        {
                            restcost = 0;
                        }
                        roomFee.RestCost = restcost;
                        roomFee.ContractID = field.ContractID;
                        roomFee.DiscountID = roomFee.DiscountID;
                        roomFee.CuiShouStartTime = field.CuiShouStartTime > DateTime.MinValue ? field.CuiShouStartTime : DateTime.MinValue;
                        roomFee.CuiShouEndTime = field.CuiShouEndTime > DateTime.MinValue ? field.CuiShouEndTime : DateTime.MinValue;
                        roomFee.RelatedFeeID = field.RelatedFeeID;
                        roomFee.ChongDiChargeID = roomFee.ChongDiChargeID;
                        roomFee.DefaultChargeManID = roomFee.DefaultChargeManID;
                        roomFee.DefaultChargeManName = field.DefaultChargeManName;
                        roomFee.Remark = "汇收银支付";
                        roomFee.Save(helper);
                        #region 收费后续操作
                        Web.APPCode.HandlerHelper.SaveRoomFee(roomFee, ChargeMan, helper, printRoomFeeHistory, ViewChargeSummaryList);
                        #endregion
                    }
                    helper.Commit();
                    var items = new { status = true, PrintID = printRoomFeeHistory.ID };
                    return true;
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("WechatHandler", "visit: wxpayroomfeecomplete", ex);
                    errormsg = ex.Message;
                    return false;
                }
            }
        }
        private void SavePrintRoomFeeHistory(PrintRoomFeeHistory printRoomFeeHistory, int RoomID, decimal RealCost, string ChargeMan, SqlHelper helper, string RoomFullName, string RoomOwnerName)
        {
            int ChargeType1 = 7;
            int ChargeType2 = 0;
            int OrderNumberID = 0;
            string PrintNumber = Foresight.DataAccess.PrintRoomFeeHistory.GetLastestPrintNumber(Foresight.DataAccess.OrderTypeNameDefine.chargefee.ToString(), RoomID, helper, out OrderNumberID);
            decimal PreChargeMoney = 0;
            decimal ChargeBackMoney = 0;
            decimal RealMoneyCost1 = RealCost;
            decimal RealMoneyCost2 = 0;
            decimal DiscountMoney = 0;
            decimal money = RealCost;
            string MoneyDaXie = Tools.CmycurD(RealCost);
            DateTime ChargeTime = DateTime.Now;
            string Remark = "汇收银支付";
            printRoomFeeHistory.PrintNumber = PrintNumber;
            printRoomFeeHistory.OrderNumberID = OrderNumberID;
            printRoomFeeHistory.Cost = money;
            printRoomFeeHistory.CostCapital = MoneyDaXie;
            printRoomFeeHistory.RealCost = RealCost;
            printRoomFeeHistory.PreChargeMoney = PreChargeMoney;
            printRoomFeeHistory.ChargeBackMoney = ChargeBackMoney;
            printRoomFeeHistory.RealMoneyCost1 = RealMoneyCost1;
            printRoomFeeHistory.RealMoneyCost2 = RealMoneyCost2;
            printRoomFeeHistory.DiscountMoney = DiscountMoney;
            printRoomFeeHistory.ChargeMan = ChargeMan;
            printRoomFeeHistory.ChargeTime = ChargeTime;
            printRoomFeeHistory.Remark = Remark;
            printRoomFeeHistory.ChageType1 = ChargeType1;
            printRoomFeeHistory.ChageType2 = ChargeType2;
            if (printRoomFeeHistory.AddTime == DateTime.MinValue)
            {
                printRoomFeeHistory.AddTime = DateTime.Now;
            }
            printRoomFeeHistory.WeiShuMore = 0;
            printRoomFeeHistory.WeiShuConsume = 0;
            printRoomFeeHistory.RoomFullName = RoomFullName;
            printRoomFeeHistory.RoomOwnerName = RoomOwnerName;
            printRoomFeeHistory.Save(helper);

        }
        // 获取POST返回来的数据  
        private string PostInput()
        {
            try
            {
                string result = string.Empty;
                using (StreamReader streamReader = new StreamReader(Request.InputStream))
                {
                    result = streamReader.ReadToEnd();
                }
                LogHelper.WriteInfo("Web.Receive.Pay.Notify.PostInput", result);
                return result;
            }
            catch (Exception ex)
            { throw ex; }
        }
        //获取GET返回来的数据  
        private NameValueCollection GETInput()
        {
            return Request.QueryString;
        }
    }
}