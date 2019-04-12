using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Utility;

namespace Web.APPCode
{
    public class CommHelper
    {
        public static void GetPriceRangeInfo(ChargePriceRange[] PriceRangeList, decimal TotalUseCount, decimal TotalPoint, decimal ImportCoefficient, out decimal UnitPrice, out decimal FinalTotalCost)
        {
            UnitPrice = 0;
            int indexcount = 0;
            FinalTotalCost = 0;
            foreach (var pricerange in PriceRangeList)
            {
                indexcount++;
                decimal MinValue = 0;
                decimal.TryParse(pricerange.MinValue, out MinValue);
                decimal MaxValue = 0;
                decimal.TryParse(pricerange.MaxValue, out MaxValue);
                decimal NianTotal = 0;
                if (pricerange.BaseType.Equals(Utility.EnumModel.PriceRangeType.qnyl.ToString()))
                {
                    NianTotal = TotalUseCount > 0 ? TotalUseCount : 0;
                }
                if ((NianTotal + TotalPoint) >= MinValue && (NianTotal + TotalPoint) < MaxValue)
                {
                    UnitPrice = pricerange.BasePrice;
                    if (NianTotal > MinValue)
                    {
                        FinalTotalCost += TotalPoint * pricerange.BasePrice * (ImportCoefficient > 0 ? ImportCoefficient : 1);
                    }
                    else
                    {
                        FinalTotalCost += (NianTotal + TotalPoint - MinValue) * pricerange.BasePrice * (ImportCoefficient > 0 ? ImportCoefficient : 1);
                    }
                    break;
                }
                if (indexcount == PriceRangeList.Length)
                {
                    UnitPrice = PriceRangeList.Max(p => p.BasePrice);
                    FinalTotalCost += (NianTotal + TotalPoint - MinValue) * pricerange.BasePrice * (ImportCoefficient > 0 ? ImportCoefficient : 1);
                    break;
                }
                if (pricerange.BaseType.Equals(Utility.EnumModel.PriceRangeType.qnyl.ToString()))
                {
                    if (MaxValue > NianTotal)
                    {
                        MinValue = (NianTotal > MinValue ? NianTotal : MinValue);
                        FinalTotalCost += (MaxValue - MinValue) * pricerange.BasePrice * (ImportCoefficient > 0 ? ImportCoefficient : 1);
                    }
                    continue;
                }
                else
                {
                    FinalTotalCost += (MaxValue - MinValue) * pricerange.BasePrice * (ImportCoefficient > 0 ? ImportCoefficient : 1);
                }
            }
        }
        public static void SaveContractLog(Foresight.DataAccess.Contract oldcontract, Foresight.DataAccess.Contract newcontract, string ModifyMan)
        {
            PropertyInfo[] oldc = oldcontract.GetType().GetProperties();
            PropertyInfo[] newc = newcontract.GetType().GetProperties();
            List<Foresight.DataAccess.Contract_ModifyLog> loglist = new List<Foresight.DataAccess.Contract_ModifyLog>();
            DateTime now = DateTime.Now;
            var guid = Guid.NewGuid();
            if (oldc != null && newc != null)
            {
                foreach (var item1 in oldc)
                {
                    string Desc = GetContractNameDesc(item1.Name);
                    if (string.IsNullOrEmpty(Desc))
                    {
                        continue;
                    }
                    foreach (var item2 in newc)
                    {
                        if (item1.Name.Equals(item2.Name))
                        {
                            object value1 = item1.GetValue(oldcontract, null);
                            object value2 = item2.GetValue(newcontract, null);
                            string valueStr1 = value1 == null ? string.Empty : value1.ToString();
                            string valueStr2 = value2 == null ? string.Empty : value2.ToString();
                            if (!valueStr1.Equals(valueStr2))
                            {
                                Foresight.DataAccess.Contract_ModifyLog log = new Foresight.DataAccess.Contract_ModifyLog();
                                log.ModifyTime = now;
                                log.ContractID = newcontract.ID;
                                log.ModifyMan = ModifyMan;
                                log.ModifyTitle = Desc;
                                log.OldValue = (valueStr1.Equals("0001-01-01 00:00:00") || valueStr1.Equals("0001/1/1 0:00:00")) ? "" : valueStr1;
                                log.NewValue = (valueStr2.Equals("0001-01-01 00:00:00") || valueStr2.Equals("0001/1/1 0:00:00")) ? "" : value2.ToString();
                                log.Guid = guid.ToString();
                                log.ModifyType = Utility.EnumModel.ContractModifyLogDefine.htbg.ToString();
                                log.ModifyTypeDesc = "合同变更";
                                log.Contract_RoomChargeID = 0;
                                log.Contract_RoomID = 0;
                                loglist.Add(log);
                            }
                            break;
                        }
                    }
                }
                if (loglist.Count > 0)
                {
                    using (SqlHelper helper = new SqlHelper())
                    {
                        try
                        {
                            helper.BeginTransaction();
                            foreach (var item in loglist)
                            {
                                item.Save(helper);
                            }
                            helper.Commit();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteError("CommHelper", "SaveContractLog", ex);
                            helper.Rollback();
                        }
                    }
                }
            }
        }
        public static string GetContractNameDesc(string Name)
        {
            string[] listDesc = new string[] { "租户名称", "合同状态", "所租铺位", "租赁面积", "铺位功能", "铺位状态", "合同编号", "合同名称", "合同押金", "合同期限", "签约日期", "开始日期", "结束日期", "免租天数", "免租开始日期", "免租结束日期", "开业日期", "进场日期", "退场日期", "租金价格", "计费周期", "收费周期", "经营商品", "每年递增", "业态品类/品牌", "合同描述", "联系电话", "通讯地址", "客户联系人", "身份证号", "交付时间", "身份证地址", "租赁用途", "营业执照" };
            string[] listName = new string[] { "RentName", "ContractStatus", "RoomLocation", "RoomArea", "RoomUseFor", "RoomStatus", "ContractNo", "ContractName", "ContractDeposit", "TimeLimit", "SignTime", "RentStartTime", "RentEndTime", "FreeDays", "FreeStartTime", "FreeEndTime", "OpenTime", "InTime", "OutTime", "RentPrice", "RentRange", "ChargeRange", "SellerProduct", "EveryYearUp", "BrandModel", "ContractSummary", "PhoneNumber", "Address", "CustomerName", "IDCardNo", "DeliverTime", "IDCardAddress", "RentUseFor", "BusinessLicense" };
            string Desc = string.Empty;
            for (int i = 0; i < listName.Length; i++)
            {
                if (listName[i].Equals(Name))
                {
                    Desc = listDesc[i];
                    break;
                }
            }
            return Desc;
        }
        public static void SaveContractRoomChargeLog(Foresight.DataAccess.Contract_RoomCharge oldcontract, Foresight.DataAccess.Contract_RoomCharge newcontract, string ModifyMan)
        {
            PropertyInfo[] oldc = oldcontract.GetType().GetProperties();
            PropertyInfo[] newc = newcontract.GetType().GetProperties();
            List<Foresight.DataAccess.Contract_ModifyLog> loglist = new List<Foresight.DataAccess.Contract_ModifyLog>();
            DateTime now = DateTime.Now;
            var guid = Guid.NewGuid();
            if (oldc != null && newc != null)
            {
                foreach (var item1 in oldc)
                {
                    string Desc = GetContractRoomChargeNameDesc(item1.Name);
                    if (string.IsNullOrEmpty(Desc))
                    {
                        continue;
                    }
                    foreach (var item2 in newc)
                    {
                        if (item1.Name.Equals(item2.Name))
                        {
                            object value1 = item1.GetValue(oldcontract, null);
                            object value2 = item2.GetValue(newcontract, null);
                            string valueStr1 = value1 == null ? string.Empty : value1.ToString();
                            string valueStr2 = value2 == null ? string.Empty : value2.ToString();
                            if (!valueStr1.Equals(valueStr2))
                            {
                                Foresight.DataAccess.Contract_ModifyLog log = new Foresight.DataAccess.Contract_ModifyLog();
                                log.ModifyTime = now;
                                log.ContractID = newcontract.ContractID;
                                log.ModifyMan = ModifyMan;
                                log.ModifyTitle = Desc;
                                log.OldValue = (valueStr1.Equals("0001-01-01 00:00:00") || valueStr1.Equals("0001/1/1 0:00:00")) ? "" : valueStr1;
                                log.NewValue = (valueStr2.Equals("0001-01-01 00:00:00") || valueStr2.Equals("0001/1/1 0:00:00")) ? "" : valueStr2;
                                log.Guid = guid.ToString();
                                log.ModifyType = Utility.EnumModel.ContractModifyLogDefine.htsfbzbg.ToString();
                                log.ModifyTypeDesc = "合同收费标准变更";
                                log.Contract_RoomChargeID = newcontract.ID;
                                log.Contract_RoomID = 0;
                                loglist.Add(log);
                            }
                            break;
                        }
                    }
                }
                if (loglist.Count > 0)
                {
                    using (SqlHelper helper = new SqlHelper())
                    {
                        try
                        {
                            helper.BeginTransaction();
                            foreach (var item in loglist)
                            {
                                item.Save(helper);
                            }
                            helper.Commit();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteError("CommHelper", "SaveContractLog", ex);
                            helper.Rollback();
                        }
                    }
                }
            }
        }
        public static void SaveContractRoomChargeRemoveorAddLog(Foresight.DataAccess.Contract_RoomCharge[] datalist, string ModifyMan, string ModifyType = "htsfbzsc")
        {
            List<Foresight.DataAccess.Contract_ModifyLog> loglist = new List<Foresight.DataAccess.Contract_ModifyLog>();
            foreach (var newcontract in datalist)
            {
                PropertyInfo[] newc = newcontract.GetType().GetProperties();
                DateTime now = DateTime.Now;
                var guid = Guid.NewGuid();
                if (newc != null)
                {
                    foreach (var item in newc)
                    {
                        string Desc = GetContractRoomChargeNameDesc(item.Name);
                        if (string.IsNullOrEmpty(Desc))
                        {
                            continue;
                        }
                        object value = item.GetValue(newcontract, null);
                        string valueStr = value == null ? string.Empty : value.ToString();
                        Foresight.DataAccess.Contract_ModifyLog log = new Foresight.DataAccess.Contract_ModifyLog();
                        log.ModifyTime = now;
                        log.ContractID = newcontract.ContractID;
                        log.ModifyMan = ModifyMan;
                        log.ModifyTitle = Desc;
                        log.OldValue = (valueStr.Equals("0001-01-01 00:00:00") || valueStr.Equals("0001/1/1 0:00:00")) ? "" : valueStr;
                        log.NewValue = (valueStr.Equals("0001-01-01 00:00:00") || valueStr.Equals("0001/1/1 0:00:00")) ? "" : valueStr;
                        log.Guid = guid.ToString();
                        if (ModifyType.Equals("htsfbzxz"))
                        {
                            log.ModifyType = Utility.EnumModel.ContractModifyLogDefine.htsfbzxz.ToString();
                            log.ModifyTypeDesc = "合同收费标准新增";
                        }
                        else if (ModifyType.Equals("htsfbzxuzu"))
                        {
                            log.ModifyType = Utility.EnumModel.ContractModifyLogDefine.htsfbzxuzu.ToString();
                            log.ModifyTypeDesc = "合同收费标准续租";
                        }
                        else
                        {
                            log.ModifyType = Utility.EnumModel.ContractModifyLogDefine.htsfbzsc.ToString();
                            log.ModifyTypeDesc = "合同收费标准删除";
                        }
                        log.Contract_RoomChargeID = newcontract.ID;
                        log.Contract_RoomID = 0;
                        loglist.Add(log);
                    }
                }
            }

            if (loglist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        foreach (var item in loglist)
                        {
                            item.Save(helper);
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteError("CommHelper", "SaveContractLog", ex);
                        helper.Rollback();
                    }
                }
            }
        }
        public static string GetContractRoomChargeNameDesc(string Name)
        {
            string[] listDesc = new string[] { "单价", "计费开始日期", "计费结束日期", "计费停用日期", "合同金额", "合同面积", "备注" };
            string[] listName = new string[] { "RoomUnitPrice", "RoomStartTime", "RoomEndTime", "RoomNewEndTime", "RoomCost", "RoomUseCount", "Remark" };
            string Desc = string.Empty;
            for (int i = 0; i < listName.Length; i++)
            {
                if (listName[i].Equals(Name))
                {
                    Desc = listDesc[i];
                    break;
                }
            }
            return Desc;
        }
        public static void SaveContractRoomRemoveorAddLog(Foresight.DataAccess.Contract_Room[] datalist, string ModifyMan, string ModifyType = "htzlzysc")
        {
            List<Foresight.DataAccess.Contract_ModifyLog> loglist = new List<Foresight.DataAccess.Contract_ModifyLog>();
            foreach (var newcontract in datalist)
            {
                var guid = Guid.NewGuid();
                DateTime now = DateTime.Now;
                var project = Foresight.DataAccess.Project.GetProject(newcontract.RoomID);
                for (int i = 0; i < 2; i++)
                {
                    Foresight.DataAccess.Contract_ModifyLog log = new Foresight.DataAccess.Contract_ModifyLog();
                    log.ModifyTime = now;
                    log.ContractID = newcontract.ContractID;
                    log.ModifyMan = ModifyMan;
                    if (i == 0)
                    {
                        log.ModifyTitle = "资源编号";
                        log.OldValue = project.Name;
                        log.NewValue = project.Name;
                    }
                    else if (i == 1)
                    {
                        log.ModifyTitle = "资源位置";
                        log.OldValue = project.FullName;
                        log.NewValue = project.FullName;
                    }
                    log.Guid = guid.ToString();
                    if (ModifyType.Equals("htzlzyxz"))
                    {
                        log.ModifyType = Utility.EnumModel.ContractModifyLogDefine.htzlzyxz.ToString();
                        log.ModifyTypeDesc = "合同租赁资源新增";
                    }
                    else
                    {
                        log.ModifyType = Utility.EnumModel.ContractModifyLogDefine.htzlzysc.ToString();
                        log.ModifyTypeDesc = "合同租赁资源删除";
                    }
                    log.Contract_RoomChargeID = 0;
                    log.Contract_RoomID = newcontract.ID;
                    loglist.Add(log);
                }

                PropertyInfo[] newc = newcontract.GetType().GetProperties();
                if (newc != null)
                {
                    foreach (var item in newc)
                    {
                        string Desc = GetContractRoomChargeNameDesc(item.Name);
                        if (string.IsNullOrEmpty(Desc))
                        {
                            continue;
                        }
                        object value = item.GetValue(newcontract, null);

                    }
                }
            }

            if (loglist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        foreach (var item in loglist)
                        {
                            item.Save(helper);
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteError("CommHelper", "SaveContractLog", ex);
                        helper.Rollback();
                    }
                }
            }
        }
        public static void SaveContractCustomerRemoveorAddLog(Foresight.DataAccess.Contract_Customer[] datalist, string ModifyMan, string ModifyType = "add")
        {
            List<Foresight.DataAccess.Contract_ModifyLog> loglist = new List<Foresight.DataAccess.Contract_ModifyLog>();
            foreach (var data in datalist)
            {
                var guid = Guid.NewGuid();
                DateTime now = DateTime.Now;
                Foresight.DataAccess.Contract_ModifyLog log = new Foresight.DataAccess.Contract_ModifyLog();
                log.ModifyTime = now;
                log.ContractID = data.ContractID;
                log.ModifyMan = ModifyMan;
                log.ModifyTitle = data.CustomerTypeDesc;
                log.OldValue = data.CustomerName;
                log.NewValue = string.Empty;
                log.Guid = guid.ToString();
                if (ModifyType.Equals("add"))
                {
                    if (data.CustomerType == 1)
                    {
                        log.ModifyType = Utility.EnumModel.ContractModifyLogDefine.contractcustomerpartaadd.ToString();
                    }
                    else
                    {
                        log.ModifyType = Utility.EnumModel.ContractModifyLogDefine.contractcustomerpartbadd.ToString();
                    }
                    log.ModifyTypeDesc = "新增" + data.CustomerTypeDesc;
                }
                else
                {
                    if (data.CustomerType == 1)
                    {
                        log.ModifyType = Utility.EnumModel.ContractModifyLogDefine.contractcustomerpartaremove.ToString();
                    }
                    else
                    {
                        log.ModifyType = Utility.EnumModel.ContractModifyLogDefine.contractcustomerpartbremove.ToString();
                    }
                    log.ModifyTypeDesc = "删除" + data.CustomerTypeDesc;
                }
                log.Contract_RoomChargeID = 0;
                log.Contract_RoomID = 0;
                loglist.Add(log);
            }
            if (loglist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        foreach (var item in loglist)
                        {
                            item.Save(helper);
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteError("CommHelper", "SaveContractCustomerRemoveorAddLog", ex);
                        helper.Rollback();
                    }
                }
            }
        }
        public static string GetContractRoomNameDesc(string Name)
        {
            string[] listDesc = new string[] { "资源编号", "资源位置" };
            string[] listName = new string[] { "RentName", "RoomLocation" };
            string Desc = string.Empty;
            for (int i = 0; i < listName.Length; i++)
            {
                if (listName[i].Equals(Name))
                {
                    Desc = listDesc[i];
                    break;
                }
            }
            return Desc;
        }
        public static List<DateTime> GetContractEndTime(ViewChargeSummary summary)
        {
            return GetContractEndTime(summary, summary.SummaryStartTime, summary.SummaryEndStartTime);
        }
        public static List<DateTime> GetContractEndTime(ViewChargeSummary summary, DateTime SummaryStartTime, DateTime SummaryEndStartTime)
        {
            List<DateTime> list = new List<DateTime>();
            DateTime InitialStartTime = SummaryStartTime;
            DateTime InitialEndTime = SummaryEndStartTime;
            if (InitialStartTime == DateTime.MinValue)
            {
                InitialStartTime = DateTime.Now;
            }
            if (InitialEndTime == DateTime.MinValue)
            {
                InitialEndTime = InitialStartTime.AddDays(1);
            }
            DateTime EndTime = DateTime.Now;
            for (int i = 0; i < (InitialEndTime - InitialStartTime).TotalDays; i++)
            {
                if (i == 0)
                {
                    EndTime = GetEndTime(summary, InitialStartTime);
                }
                else
                {
                    EndTime = GetEndTime(summary, EndTime.AddDays(1));
                }
                if (EndTime >= InitialEndTime)
                {
                    list.Add(InitialEndTime);
                    break;
                }
                list.Add(EndTime);
            }
            return list;
        }
        public static DateTime GetSingleContractEndTime(ViewChargeSummary summary, DateTime StartTime)
        {
            DateTime EndTime = DateTime.MinValue;
            int SummaryChargeTypeCount = summary.SummaryChargeTypeCount;
            SummaryChargeTypeCount = SummaryChargeTypeCount < 0 ? 1 : SummaryChargeTypeCount;
            if (summary.EndTypeID == 1)
            {
                EndTime = StartTime.AddMonths(SummaryChargeTypeCount).AddDays(-1);
            }
            else if (summary.EndTypeID == 2)
            {
                EndTime = StartTime.AddDays(SummaryChargeTypeCount - 1);
            }
            return EndTime;
        }
        public static DateTime GetEndTime(ChargeFee chargeFee, DateTime StartTime)
        {
            DateTime EndTime = DateTime.MinValue;
            if (chargeFee.EndTypeID == 1)
            {
                EndTime = StartTime.AddMonths(chargeFee.ChargeTypeCount).AddDays(-1);
            }
            else if (chargeFee.EndTypeID == 2)
            {
                EndTime = StartTime.AddDays(chargeFee.ChargeTypeCount - 1);
            }
            return EndTime;
        }
        public static DateTime GetEndTime(ViewChargeSummary summary, DateTime StartTime, DateTime? EndTime = null)
        {
            return Utility.Tools.GetRoomFeeEndTime(summary.FeeType, summary.SummaryChargeTypeCount, summary.EndNumberType, summary.EndTypeID, summary.AutoToMonthEnd, StartTime, EndTime);
        }
        public static decimal CalculateContractTempPrice(decimal RoomUnitPrice, int number, string CalculateType, decimal CalculatePercent, decimal CalculateAmount)
        {
            decimal calculatePrice = RoomUnitPrice;
            if (number > 0)
            {
                if (CalculateType.Equals("percent"))
                {
                    for (int i = 0; i < number; i++)
                    {
                        calculatePrice = calculatePrice + Math.Round((decimal)(calculatePrice * CalculatePercent / 100), 2, MidpointRounding.AwayFromZero);
                    }
                }
                else if (CalculateType.Equals("amount"))
                {
                    for (int i = 0; i < number; i++)
                    {
                        calculatePrice = calculatePrice + CalculateAmount;
                    }
                }
            }
            return calculatePrice;
        }
        public static DateTime CalculateContractTempStartTime(DateTime StartTime, DateTime EndTime, int number, int CalculateMonth, int CalculateType = 1)
        {
            DateTime calculateStartTime = StartTime;
            if (number > 0)
            {
                for (int i = 0; i < number; i++)
                {
                    if (CalculateType == 1)
                    {
                        calculateStartTime = calculateStartTime.AddMonths(CalculateMonth);
                    }
                    else
                    {
                        calculateStartTime = calculateStartTime.AddDays(CalculateMonth);
                    }
                }
            }
            return calculateStartTime > EndTime ? EndTime : calculateStartTime;
        }
        public static DateTime CalculateContractTempEndTime(DateTime StartTime, DateTime EndTime, int number, int CalculateMonth, int CalculateType = 1)
        {
            DateTime LastStartTime = CalculateContractTempStartTime(StartTime, EndTime, number, CalculateMonth, CalculateType: CalculateType);
            DateTime calculateEndTime = DateTime.MinValue;
            if (CalculateType == 1)
            {
                calculateEndTime = LastStartTime.AddMonths(CalculateMonth).AddDays(-1);
            }
            else
            {
                calculateEndTime = LastStartTime.AddDays(CalculateMonth).AddDays(-1);
            }
            return calculateEndTime > EndTime ? EndTime : calculateEndTime;
        }
        public static DateTime CalculateContractFinalEndTime(DateTime StartTime, int CalculateMonth)
        {
            DateTime CalculateEndTime = StartTime.AddMonths(CalculateMonth).AddDays(-1);
            return CalculateEndTime;
        }
        public static void CheckRoomFeeWeiYue(int[] RoomIDList)
        {
            if (RoomIDList.Length == 0)
            {
                return;
            }
            var roomFeeList = Foresight.DataAccess.RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomIDList(RoomIDList);
            if (roomFeeList.Length == 0)
            {
                return;
            }
            var ChargeIDList = roomFeeList.Select(p => p.ChargeID).Distinct().ToArray();
            var weiyue_summary_list = Foresight.DataAccess.ChargeSummary.GetWeiYueSummaryList(ChargeIDList);
            var RoomFeeIDList = roomFeeList.Select(p => p.ID).Distinct().ToArray();
            var weiyue_roomfee_list = Foresight.DataAccess.RoomFee.GetRoomFeeWeiYueList(RoomFeeIDList);
            var breakcontract_list = Foresight.DataAccess.RoomFee_BreakContract.GetRoomFee_BreakContractList(RoomFeeIDList);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var ChargeID in ChargeIDList)
                    {
                        var my_weiyue_summary_list = weiyue_summary_list.Where(p => p.RelateCharges.Contains("," + ChargeID + ",")).ToArray();
                        if (my_weiyue_summary_list.Length == 0)
                        {
                            continue;
                        }
                        var myFeeList = roomFeeList.Where(p => p.ChargeID == ChargeID).ToArray();
                        foreach (var weiyue_summary in my_weiyue_summary_list)
                        {
                            foreach (var fee in myFeeList)
                            {
                                var my_weiyue_roomfee_list = weiyue_roomfee_list.Where(p => p.RelatedFeeID == fee.ID && p.ChargeID == weiyue_summary.ID).ToArray();
                                foreach (var item in my_weiyue_roomfee_list)
                                {
                                    item.Delete(helper);
                                }
                                var my_breakcontract = breakcontract_list.Where(p => p.RoomFeeID == fee.ID && p.SummaryID == weiyue_summary.ID).ToArray();
                                foreach (var item in my_breakcontract)
                                {
                                    item.Delete(helper);
                                }
                                if (FeeIsWeiYue(fee, weiyue_summary))
                                {
                                    CreateWeiYueFee(fee, weiyue_summary, helper);
                                }
                            }
                        }
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("CommHelper.cs", "CheckRoomFeeWeiYue", ex);
                    helper.Rollback();
                }
            }
        }
        private static bool FeeIsWeiYue(RoomFeeAnalysis roomFee, Foresight.DataAccess.ChargeSummary weiyue_summary)
        {
            DateTime ActiveTime = DateTime.MinValue;
            //DateTime StartTime = DateTime.MinValue;
            if (weiyue_summary.WeiYueActiveStartDate.Equals(EnumModel.ChargeSummaryWeiYueStartDate.starttime.ToString()))
            {
                ActiveTime = roomFee.CalculateStartTime;
            }
            else if (weiyue_summary.WeiYueActiveStartDate.Equals(EnumModel.ChargeSummaryWeiYueStartDate.endtime.ToString()))
            {
                ActiveTime = roomFee.CalculateEndTime;
            }
            if (ActiveTime == DateTime.MinValue)
            {
                return false;
            }
            int dayormonths = weiyue_summary.WeiYueActiveCount > 0 ? weiyue_summary.WeiYueActiveCount : 0;
            if (weiyue_summary.WeiYueActiveBeforeAfter.Equals(EnumModel.ChargeSummaryWeiYueBeforeAfter.after.ToString()))
            {
                if (weiyue_summary.WeiYueActiveDayMonth.Equals(EnumModel.ChargeSummaryWeiYueDayMonth.day.ToString()))
                {
                    return ActiveTime >= DateTime.Now.AddDays(dayormonths);
                }
                else if (weiyue_summary.WeiYueActiveDayMonth.Equals(EnumModel.ChargeSummaryWeiYueDayMonth.month.ToString()))
                {
                    return ActiveTime >= DateTime.Now.AddMonths(dayormonths);
                }
                return false;
            }
            if (weiyue_summary.WeiYueActiveBeforeAfter.Equals(EnumModel.ChargeSummaryWeiYueBeforeAfter.before.ToString()))
            {
                if (weiyue_summary.WeiYueActiveDayMonth.Equals(EnumModel.ChargeSummaryWeiYueDayMonth.day.ToString()))
                {
                    return ActiveTime.AddDays(dayormonths) <= DateTime.Now;
                }
                else if (weiyue_summary.WeiYueActiveDayMonth.Equals(EnumModel.ChargeSummaryWeiYueDayMonth.month.ToString()))
                {
                    return ActiveTime.AddMonths(dayormonths) <= DateTime.Now;
                }
                return false;
            }
            return false;
        }
        public static void CreateWeiYueFee(RoomFeeAnalysis roomFee, Foresight.DataAccess.ChargeSummary weiyue_summary, SqlHelper helper)
        {
            if (weiyue_summary.WeiYuePercent <= 0)
            {
                return;
                //summary.WeiYuePercent = 0;
            }
            DateTime StartTime = DateTime.MinValue;
            DateTime EndTime = DateTime.Now;
            #region 计算开始日期
            if (weiyue_summary.WeiYueStartDate.Equals(EnumModel.ChargeSummaryWeiYueStartDate.starttime.ToString()))
            {
                StartTime = roomFee.CalculateStartTime;
            }
            else if (weiyue_summary.WeiYueStartDate.Equals(EnumModel.ChargeSummaryWeiYueStartDate.endtime.ToString()))
            {
                StartTime = roomFee.CalculateEndTime;
            }
            int days = weiyue_summary.WeiYueDays > 0 ? weiyue_summary.WeiYueDays : 0;
            if (weiyue_summary.WeiYueBefore.Equals(EnumModel.ChargeSummaryWeiYueBeforeAfter.before.ToString()))
            {
                days = -days;
            }
            StartTime = StartTime == DateTime.MinValue ? DateTime.Now : StartTime;
            StartTime = StartTime.AddDays(days);
            #endregion
            if (StartTime > DateTime.Now)
            {
                return;
            }
            #region 计算违约金
            decimal weiyuetotal = 0;
            if (weiyue_summary.ChargeWeiYueType == 1 && weiyue_summary.WeiYuePercent > 0 && StartTime > DateTime.MinValue && EndTime > DateTime.MinValue && roomFee.TotalCost > 0)
            {
                int weiyuedays = Convert.ToInt32((EndTime - StartTime).TotalSeconds / (60 * 60 * 24));
                if (weiyue_summary.DayGunLi)
                {
                    calculateRateCost(roomFee.TotalCost, 0, weiyuedays, weiyue_summary.WeiYuePercent);
                    foreach (var item in ratecostlist)
                    {
                        weiyuetotal += item;
                    }
                }
                else
                {
                    weiyuetotal = roomFee.TotalCost * weiyuedays * weiyue_summary.WeiYuePercent;
                }
            }
            if (weiyuetotal <= 0)
            {
                //return;
                weiyuetotal = 0;
            }
            weiyuetotal = Math.Round((decimal)weiyuetotal, weiyue_summary.EndNumberCount, MidpointRounding.AwayFromZero);
            #endregion
            var newRoomFee = Foresight.DataAccess.RoomFee.SetInfo_RoomFee(roomFee.RoomID, StartTime, EndTime, weiyuetotal, weiyuetotal, 0, weiyue_summary.ID, ContractID: roomFee.ContractID, RelatedFeeID: roomFee.ID, cansave: true, helper: helper);
            var breakcontract = new Foresight.DataAccess.RoomFee_BreakContract();
            breakcontract.RoomFeeID = roomFee.ID;
            breakcontract.SummaryID = weiyue_summary.ID;
            breakcontract.AddTime = DateTime.Now;
            breakcontract.TotalCost = roomFee.TotalCost;
            breakcontract.Save(helper);
        }
        public static List<decimal> ratecostlist = new List<decimal>();
        public static void calculateRateCost(decimal CalculateUnitPrice, int startnumber, int weiyuedays, decimal WeiYuePercent)
        {
            if (startnumber == 0)
            {
                ratecostlist = new List<decimal>();
            }
            startnumber++;
            if (startnumber > weiyuedays)
            {
                return;
            }
            decimal totalcost = CalculateUnitPrice * (1 + WeiYuePercent);
            ratecostlist.Add(totalcost);
            calculateRateCost(totalcost, startnumber, weiyuedays, WeiYuePercent);
            return;
        }
        private List<Foresight.DataAccess.DefineField> DefineField_List = new List<DefineField>();
        private string origin_tablename = string.Empty;
        public string GetExistColumns(string TableName, string ColumnName)
        {
            if (string.IsNullOrEmpty(TableName))
            {
                return string.Empty;
            }
            if (DefineField_List.Count == 0)
            {
                DefineField_List = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(TableName, 2).ToList();
            }
            else
            {
                if (!origin_tablename.Equals(TableName))
                {
                    DefineField_List = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(TableName, 2).ToList();
                }
                origin_tablename = TableName;
            }
            if (DefineField_List.Count > 0)
            {
                var define_field = DefineField_List.FirstOrDefault(p => p.ColumnName.Equals(ColumnName));
                if (define_field != null)
                {
                    return define_field.FieldName;
                }
            }
            return string.Empty;
        }

        public static string GetContractTemplateHtml(string content, Foresight.DataAccess.Contract contract)
        {
            var contract_rooms = Foresight.DataAccess.ViewContractRoom.GetViewContractRoomListByContractID(contract.ID, string.Empty);
            string renthomename = string.Empty;
            decimal totalarea = 0;
            if (contract_rooms.Length > 0)
            {
                renthomename = string.Join(",", contract_rooms.Select(p => p.Name).ToArray());
                totalarea = contract_rooms.Where(p => p.ContractArea > 0).Sum(p => p.ContractArea);
            }
            string RentTime = contract.RentStartTime > DateTime.MinValue ? contract.RentStartTime.ToString("yyyy-MM-dd") : "--";
            RentTime += " 至 ";
            RentTime += contract.RentEndTime > DateTime.MinValue ? contract.RentEndTime.ToString("yyyy-MM-dd") : "--";
            content = content.Replace("{客户名称}", contract.RentName)
                .Replace("{联系方式}", contract.ContractPhone)
                .Replace("{签约日期}", contract.SignTime > DateTime.MinValue ? contract.SignTime.ToString("yyyy-MM-dd") : "")
                .Replace("{租赁日期}", RentTime).Replace("{预警日期}", contract.WarningTime > DateTime.MinValue ? contract.WarningTime.ToString("yyyy-MM-dd") : "")
                .Replace("{租金}", contract.RentPrice > 0 ? contract.RentPrice.ToString() : "")
                .Replace("{租金大写}", contract.RentPrice > 0 ? Tools.CmycurD(contract.RentPrice) : "")
                .Replace("{押金}", contract.ContractDeposit > 0 ? contract.ContractDeposit.ToString() : "")
                .Replace("{免租期}", contract.FreeDays > 0 ? contract.FreeDays.ToString() : "")
                .Replace("{租赁资源}", renthomename)
                .Replace("{合同面积}", totalarea.ToString())
                .Replace("{法人代表}", contract.InChargeMan)
                .Replace("{通讯地址}", contract.Address)
                .Replace("{身份证号}", contract.IDCardNo)
                .Replace("{身份证地址}", contract.IDCardAddress);
            return content;
        }
        public static decimal CalculateUseCount(RoomBasic basic, ChargeSummary summary)
        {
            decimal CalculateUseCount = 0;
            if (summary.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.jifei.ToString()))
            {
                CalculateUseCount = basic.BuildingArea;
            }
            else if (summary.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.jianzhu.ToString()))
            {
                CalculateUseCount = basic.BuildOutArea;
            }
            else if (summary.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.taonei.ToString()))
            {
                CalculateUseCount = basic.BuildInArea;
            }
            else if (summary.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.gongtan.ToString()))
            {
                CalculateUseCount = basic.GonTanArea;
            }
            else if (summary.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.chanquan.ToString()))
            {
                CalculateUseCount = basic.ChanQuanArea;
            }
            else if (summary.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.shiyong.ToString()))
            {
                CalculateUseCount = basic.UseArea;
            }
            else if (summary.CalculateAreaType.Equals(Utility.EnumModel.ChargeSummaryCalculateAreaType.peitao.ToString()))
            {
                CalculateUseCount = basic.PeiTaoArea;
            }
            if (CalculateUseCount > 0)
            {
                return CalculateUseCount;
            }
            return basic.ContractArea > 0 ? basic.ContractArea : 0;
        }
        public static void SaveOperationLog(string OperationContent, string OperationKey, string OperationTitle, string OperationTableKey, string OperationTableName, string OperationMan = "", DateTime? LogoutTime = null, bool IsHide = false)
        {
            DateTime _LogoutTime = DateTime.MinValue;
            if (LogoutTime.HasValue)
            {
                _LogoutTime = Convert.ToDateTime(LogoutTime);
            }
            var context = HttpContext.Current;
            if (string.IsNullOrEmpty(OperationMan))
            {
                OperationMan = WebUtil.GetUser(context).LoginName;
            }
            string IPAddress = GetHostAddress();
            var log = new OperationLog();
            log.OperationTime = DateTime.Now;
            log.OperationMan = OperationMan;
            log.OperationContent = OperationContent;
            log.OperationKey = OperationKey;
            log.LogoutTime = _LogoutTime;
            log.IPAddress = IPAddress;
            log.OperationTitle = OperationTitle;
            log.OperationTableKey = OperationTableKey;
            log.OperationTableName = OperationTableName;
            log.IsHide = IsHide;
            log.Save();
        }
        /// <summary>
        /// 获取客户端IP地址（无视代理）
        /// </summary>
        /// <returns>若失败则返回回送地址</returns>
        public static string GetHostAddress()
        {
            string userHostAddress = HttpContext.Current.Request.UserHostAddress;
            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            //最后判断获取是否成功，并检查IP地址的格式（检查其格式非常重要）
            if (!string.IsNullOrEmpty(userHostAddress) && IsIP(userHostAddress))
            {
                return userHostAddress;
            }
            return "127.0.0.1";
        }

        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
        public static void UpdateProjectOrder()
        {
            var url_list = Foresight.DataAccess.Company.GetAllActiveCompanyList().Select(o => o.BaseURL).ToList();
            foreach (var url in url_list)
            {
                string apiurl = url + "/Handler/ProjectHandler.ashx";
                try
                {
                    Foresight.Web.HttpRequest.Post(null, new Dictionary<string, string>() { { "visit", "saveprojectneworder" }, { "ProjectID", "1" }, { "SortOrder", "1" } }, apiurl: apiurl);
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("UpdateProjectOrder", url, ex);
                }
            }
        }
        public static bool SaveSystemMsg(string apiurl, Utility.SystemMsgModel[] list)
        {
            ResponseData response = null;
            apiurl = apiurl + "/Handler/Api.ashx";
            try
            {
                string liststr = HttpUtility.UrlEncode(JsonConvert.SerializeObject(list), System.Text.Encoding.UTF8);
                string result = Foresight.Web.HttpRequest.Post(null, new Dictionary<string, string>() { { "visit", "savesystemmsg" }, { "list", liststr } }, apiurl: apiurl, UrlEncode: false);
                response = JsonConvert.DeserializeObject<ResponseData>(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("SaveSystemMsg", apiurl, ex);
            }
            if (response == null)
            {
                return false;
            }
            return response.status;
        }
        public static bool DeleteSystemMsg(string apiurl, int[] idlist)
        {
            ResponseData response = null;
            apiurl = apiurl + "/Handler/Api.ashx";
            try
            {
                string result = Foresight.Web.HttpRequest.Post(null, new Dictionary<string, string>() { { "visit", "deletesystemmsg" }, { "list", JsonConvert.SerializeObject(idlist) } }, apiurl: apiurl);
                response = JsonConvert.DeserializeObject<ResponseData>(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("SaveSystemMsg", apiurl, ex);
            }
            if (response == null)
            {
                return false;
            }
            return response.status;
        }
        public static List<Dictionary<string, object>> getshoppingcartitems(Mall_ShoppingCart[] list, Mall_ProductDetail[] products, Mall_Product_VariantDetail[] product_variants, int BusinessID, out decimal totalprice, out int totalsalepoint, out string totalpricedesc)
        {
            totalprice = 0;
            totalsalepoint = 0;
            totalpricedesc = string.Empty;
            int totalquantity = 0;
            return Mall_ShoppingCart.getshoppingcartitems(list, products, product_variants, BusinessID, WebUtil.GetContextPath(), out totalprice, out totalsalepoint, out totalquantity, out totalpricedesc);
        }
        public static Model.CartOrderModel getmallorderitems(Mall_ShoppingCart[] cart_list, Mall_Product[] product_list, Mall_Product_VariantDetail[] variant_list, Foresight.DataAccess.User user, string user_note, int BusinessID, int AddressProvinceID = 0, int UserID = 0)
        {
            Model.CartOrderModel data = new Model.CartOrderModel();
            List<Mall_OrderItem> orderitems = new List<Mall_OrderItem>();
            Mall_Product[] my_products = new Mall_Product[] { };
            if (BusinessID > 0)
            {
                my_products = product_list.Where(p => p.BusinessID == BusinessID).ToArray();
            }
            else
            {
                my_products = product_list.Where(p => p.IsZiYing).ToArray();
            }
            var my_cartlist = cart_list.Where(p => my_products.Select(q => q.ID).ToList().Contains(p.ProductID)).ToArray();
            decimal totalprice = 0;
            decimal total_ship_amount = 0;
            int totalsalepoint = 0;
            int viptotalsalepoint = 0;
            int totalstaffpoint = 0;
            foreach (var item in my_cartlist)
            {
                var my_product = product_list.FirstOrDefault(p => p.ID == item.ProductID);
                if (my_product == null)
                {
                    continue;
                }
                var my_variant = variant_list.FirstOrDefault(p => p.ID == item.VariantID);
                decimal price = 0;
                int salepoint = 0;
                bool isallowproductsale = false;
                bool isallowpointsale = false;
                bool isallowvipsale = false;
                bool isallowstaffsale = false;
                string totalpricedesc = string.Empty;
                string pricedesc = Mall_Product.GetOrderItemPriceDesc(my_product, my_variant, item.Quantity, out price, out salepoint, out isallowproductsale, out isallowpointsale, out isallowvipsale, out isallowstaffsale, out totalpricedesc, ProductOrderType: item.ProductOrderType);
                string VariantTitle = item.VariantTitle;
                string VariantName = item.VariantName;
                if (my_variant != null)
                {
                    VariantTitle = my_variant.FinalVariantTitle;
                    VariantName = my_variant.VariantName;
                }
                string ShipRateTitle = string.Empty;
                decimal ShipRateAmount = 0;
                int ShipRateID = 0;
                int ShipRateType = 0;
                if (AddressProvinceID > 0)
                {
                    Mall_ShipRateDetail.GetMall_ShipRateDetailByKeywords(my_product.ID, new List<int>(), 0, out ShipRateTitle, out ShipRateAmount, out ShipRateID, out ShipRateType, ProvinceID: AddressProvinceID, Quantity: item.Quantity, UserID: UserID);
                }
                var order_item = new Mall_OrderItem();
                order_item.IsDiscountPrice = my_variant.IsDiscountEnable;
                order_item.AddTime = DateTime.Now;
                order_item.AddMan = user.LoginName;
                order_item.ProductID = my_product.ID;
                order_item.ProductName = my_product.ProductName;
                order_item.VariantID = item.VariantID;
                order_item.VariantTitle = VariantTitle;
                order_item.VariantName = VariantName;
                order_item.BusinessID = my_product.BusinessID;
                order_item.Price = price;
                order_item.Quantity = item.Quantity;
                order_item.TotalPrice = price * item.Quantity;
                order_item.SalePoint = 0;
                order_item.TotalSalePoint = 0;
                order_item.VIPSalePoint = 0;
                order_item.VIPTotalSalePoint = 0;
                order_item.ProductTypeID = my_product.ProductTypeID;
                order_item.ShipRateAmount = ShipRateAmount;
                order_item.ShipRateID = ShipRateID;
                order_item.ShipRateTitle = ShipRateTitle;
                order_item.ShipRateType = ShipRateType;
                order_item.ProductBuyType = item.ProductOrderType > 0 ? item.ProductOrderType : 16;
                if (order_item.ProductBuyType == 17)
                {
                    order_item.SalePoint = salepoint;
                    order_item.TotalSalePoint = salepoint * item.Quantity;
                    totalsalepoint += salepoint * item.Quantity;
                }
                if (order_item.ProductBuyType == 18)
                {
                    order_item.VIPSalePoint = salepoint;
                    order_item.VIPTotalSalePoint = salepoint * item.Quantity;
                    viptotalsalepoint += salepoint * item.Quantity;
                }
                if (order_item.ProductBuyType == 25)
                {
                    order_item.StaffPoint = salepoint;
                    order_item.TotalSalePoint = salepoint * item.Quantity;
                    totalstaffpoint += salepoint * item.Quantity;
                }
                orderitems.Add(order_item);
                totalprice += price * item.Quantity;
                total_ship_amount += ShipRateAmount;
            }
            Foresight.DataAccess.Mall_Order order = new Mall_Order();
            order.BusinessID = BusinessID > 0 ? BusinessID : 0;
            order.AddTime = DateTime.Now;
            order.AddUser = user.LoginName;
            order.OrderNumber = Mall_Order.GetLastestOrderNumber();
            order.OrderType = 1;
            order.TotalCost = totalprice;
            order.TotalSalePoint = totalsalepoint;
            order.TotalVIPSalePoint = viptotalsalepoint;
            order.TotalSaleStaffPoint = totalstaffpoint;
            order.OriginalTotalCost = order.TotalCost;
            order.OrderStatus = 1;
            order.UserID = UserID;
            order.UserName = user.LoginName;
            order.UserNote = user_note;
            order.ProductTypeID = 1;
            order.ShipRateAmount = total_ship_amount;
            data.order = order;
            data.OrderItemList = orderitems;
            return data;
        }
        public static Dictionary<string, object> getorderinfo(Mall_Order order, int paytype, int uid, out string errormsg)
        {
            var resultobj = new Dictionary<string, object>();
            errormsg = "";
            if (order == null)
            {
                return null;
            }
            //支付完成，验证付款情况
            if (paytype == 7)
            {
                order.IsPaied = true;
                order.Save();
                APPCode.PaymentHelper.SaveMallOrder(order);
            }
            string paymentmethod = string.Empty;
            string paytime = string.Empty;
            string shiptime = string.Empty;
            string shipcompany = string.Empty;
            string trackno = string.Empty;
            string completetime = string.Empty;
            string closetime = string.Empty;
            string refundtime = string.Empty;
            if (order.IsClosed)
            {
                closetime = order.CloseTime > DateTime.MinValue ? order.CloseTime.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;
            }
            else
            {
                if (order.OrderStatus == 2 || order.OrderStatus == 3 || order.OrderStatus == 5)
                {
                    paytime = order.PayTime > DateTime.MinValue ? order.PayTime.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;
                    paymentmethod = order.PaymentMethodDesc;
                }
                if (order.OrderStatus == 2 || order.OrderStatus == 3)
                {
                    shiptime = order.ShipTime > DateTime.MinValue ? order.ShipTime.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;
                    shipcompany = order.ShipCompanyName;
                    trackno = order.ShipTrackNo;
                }
                if (order.OrderStatus == 3)
                {
                    completetime = order.CompleteTime > DateTime.MinValue ? order.CompleteTime.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;
                }
                if (order.OrderStatus == 7)
                {
                    refundtime = order.RefundTime > DateTime.MinValue ? order.RefundTime.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;
                }
            }
            var orderinfo = new { orderno = order.OrderNumber, createtime = order.AddTime.ToString("yyyy-MM-dd HH:mm:ss"), paytime = paytime, paystatus = order.OrderStatusDesc, orderstatus = order.OrderStatus, shiptime = shiptime, shipcompany = shipcompany, trackno = trackno, completetime = completetime, closetime = closetime, ispoint = order.TotalOrderPointCost > 0, refundtime = refundtime, paymentmethod = paymentmethod, totalprice = order.TotalOrderCost, totalpricedesc = order.TotalOrderCostDesc };
            var list = Foresight.DataAccess.Mall_OrderItem.GetMall_OrderItemListByOrderID(order.ID);
            Mall_Business business = null;
            int businessid = 0;
            string businessname = "福顺优选";
            string businessimage = string.Empty;
            int businesstype = 1;
            bool show_address = true;
            if (order.ProductTypeID == 10)
            {
                businessname = "物业缴费";
                businesstype = 2;
                show_address = false;
            }
            else if (order.ProductTypeID == 5)
            {
                businessname = "生活服务";
                businesstype = 3;
                show_address = false;
                if (list.Length > 0)
                {
                    var house_service = Wechat_HouseService.GetWechat_HouseService(list[0].ProductID);
                    if (house_service != null)
                    {
                        var service_category = Wechat_HouseServiceCategory.GetWechat_HouseServiceCategory(house_service.CategoryID);
                        if (service_category != null)
                        {
                            businessid = service_category.ID;
                            businessname = service_category.CategoryName;
                        }
                    }
                }
            }
            else
            {
                if (list.Length > 0)
                {
                    business = Mall_Business.GetMall_Business(list[0].BusinessID);
                    if (business != null)
                    {
                        businessid = business.ID;
                        businessname = business.BusinessName;
                        businessimage = string.IsNullOrEmpty(business.CoverImage) ? "" : WebUtil.GetContextPath() + business.CoverImage;
                    }
                }
            }
            var businessinfo = new { id = businessid, name = businessname, businessimage = businessimage, businesstype = businesstype };
            List<Dictionary<string, object>> productlist = new List<Dictionary<string, object>>();
            string totalpricedesc = order.TotalOrderCostDesc;
            int totalsalepoint = order.TotalOrderPointCost > 0 ? order.TotalOrderPointCost : 0;
            if (order.ProductTypeID == 10)
            {
                foreach (var item in list)
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic["ID"] = item.ID;
                    dic["imageurl"] = "../image/icons/wuyejiaofei_order.png";
                    dic["title"] = item.ProductTitle;
                    dic["desc"] = item.ProductSubTitle;
                    dic["pricedesc"] = item.PriceDesc;
                    dic["price"] = item.Price;
                    dic["salepoint"] = item.FinalSalePoint;
                    dic["quantity"] = "x1";
                    dic["productid"] = 0;
                    dic["ProductTypeID"] = order.ProductTypeID;
                    dic["ProductOrderType"] = item.ProductOrderType;
                    productlist.Add(dic);
                }
                if (productlist.Count == 0)
                {
                    errormsg = "没有相关费项";
                    return null;
                }
                var productsummary = new { totaldesc = "共" + productlist.Count.ToString() + "个商品", totalprice = order.TotalCost, ispoint = order.TotalOrderPointCost > 0, totalpoint = 0, shipratename = "", shiprateamount = 0, couponamount = order.CouponAmount > 0 ? order.CouponAmount : 0, totalpricedesc = order.TotalCostDesc, totalsalepoint = totalsalepoint };
                var ordersummary = new Utility.OrderSummary { totalprice = order.TotalOrderCost, ispoint = totalsalepoint > 0, totalpoint = 0, totalsalepoint = totalsalepoint, totalpricedesc = totalpricedesc, stafftotalpoint = order.TotalSaleStaffPoint };
                resultobj["show_shiprate"] = false;
                resultobj["show_address"] = false;
                resultobj["productlist"] = productlist;
                resultobj["productsummary"] = productsummary;
                resultobj["orderinfo"] = orderinfo;
                resultobj["businessinfo"] = businessinfo;
                resultobj["show_address"] = show_address;
                resultobj["ordersummary"] = ordersummary;
                return resultobj;
            }
            else if (order.ProductTypeID == 5)
            {
                foreach (var item in list)
                {
                    var houser_service = Wechat_HouseService.GetWechat_HouseService(item.ProductID);
                    string imageurl = !string.IsNullOrEmpty(houser_service.IconLink) ? WebUtil.GetContextPath() + houser_service.IconLink : "../image/error-img.png";
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic["ID"] = item.ID;
                    dic["imageurl"] = imageurl;
                    dic["title"] = item.ProductTitle;
                    dic["desc"] = item.ProductSubTitle;
                    dic["pricedesc"] = item.PriceDesc;
                    dic["price"] = item.Price;
                    dic["salepoint"] = item.SalePoint;
                    dic["quantity"] = "x" + item.Quantity.ToString();
                    dic["productid"] = item.ProductID;
                    dic["ProductTypeID"] = order.ProductTypeID;
                    dic["ProductOrderType"] = item.ProductOrderType;
                    productlist.Add(dic);
                }
                if (productlist.Count == 0)
                {
                    errormsg = "没有相关服务";
                    return null;
                }
                var productsummary = new { totaldesc = "共" + productlist.Count.ToString() + "个商品", totalprice = order.TotalCost, ispoint = order.TotalOrderPointCost > 0, totalpoint = 0, shipratename = "", shiprateamount = 0, couponamount = order.CouponAmount > 0 ? order.CouponAmount : 0, totalpricedesc = order.TotalCostDesc, totalsalepoint = totalsalepoint };
                var ordersummary = new Utility.OrderSummary { totalprice = order.TotalOrderCost, ispoint = totalsalepoint > 0, totalpoint = 0, totalsalepoint = totalsalepoint, totalpricedesc = totalpricedesc, stafftotalpoint = order.TotalSaleStaffPoint };
                resultobj["show_shiprate"] = false;
                resultobj["show_address"] = false;
                if (order.AddressID > 0)
                {
                    var myaddress = new { id = order.AddressID, username = order.AddressUserName, phonenumber = order.AddressPhoneNumber, addressdetail = order.FullAddressInfo };
                    resultobj["myaddress"] = myaddress;
                    resultobj["show_address"] = true;
                    resultobj["show_shiprate"] = true;
                }
                resultobj["productlist"] = productlist;
                resultobj["productsummary"] = productsummary;
                resultobj["orderinfo"] = orderinfo;
                resultobj["businessinfo"] = businessinfo;
                resultobj["show_address"] = show_address;
                resultobj["ordersummary"] = ordersummary;
                return resultobj;
            }
            else
            {
                var product_list = Foresight.DataAccess.Mall_Product.GetMall_ProductListByIDList(list.Select(p => p.ProductID).ToList());
                string shipratename = order.ShipCompanyName;
                foreach (var item in list)
                {
                    string imageurl = "../image/error-img.png";
                    var my_product = product_list.FirstOrDefault(p => p.ID == item.ProductID);
                    if (my_product != null)
                    {
                        imageurl = !string.IsNullOrEmpty(my_product.CoverImage) ? WebUtil.GetContextPath() + my_product.CoverImage : imageurl;
                    }
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic["ID"] = item.ID;
                    dic["imageurl"] = imageurl;
                    dic["title"] = item.ProductTitle;
                    dic["desc"] = item.ProductSubTitle;
                    dic["pricedesc"] = item.PriceDesc;
                    dic["price"] = item.Price;
                    dic["salepoint"] = item.SalePoint;
                    dic["quantity"] = "x" + item.Quantity.ToString();
                    dic["productid"] = item.ProductID;
                    dic["ProductTypeID"] = order.ProductTypeID;
                    dic["ProductOrderType"] = item.ProductOrderType;
                    productlist.Add(dic);
                }
                if (productlist.Count == 0)
                {
                    errormsg = "没有相关产品";
                    return resultobj;
                }
                decimal point_balance = Mall_UserPoint.GetMall_UserPointBalance(uid);
                var productsummary = new { totaldesc = "共" + productlist.Count.ToString() + "个商品", totalprice = order.TotalCost, ispoint = order.TotalOrderPointCost > 0, totalpoint = point_balance, shipratename = shipratename, shiprateamount = order.ShipRateAmount > 0 ? order.ShipRateAmount : 0, couponamount = order.CouponAmount > 0 ? order.CouponAmount : 0, totalpricedesc = order.TotalCostDesc, totalsalepoint = totalsalepoint };
                var ordersummary = new Utility.OrderSummary { totalprice = order.TotalOrderCost, ispoint = totalsalepoint > 0, totalpoint = point_balance, totalsalepoint = totalsalepoint, totalpricedesc = totalpricedesc, stafftotalpoint = order.TotalSaleStaffPoint };
                resultobj["show_shiprate"] = false;
                resultobj["show_address"] = false;
                if (order.AddressID > 0)
                {
                    var myaddress = new { id = order.AddressID, username = order.AddressUserName, phonenumber = order.AddressPhoneNumber, addressdetail = order.FullAddressInfo };
                    resultobj["myaddress"] = myaddress;
                    resultobj["show_shiprate"] = true;
                    resultobj["show_address"] = true;
                }
                resultobj["productlist"] = productlist;
                resultobj["productsummary"] = productsummary;
                resultobj["orderinfo"] = orderinfo;
                resultobj["businessinfo"] = businessinfo;
                resultobj["show_address"] = show_address;
                resultobj["ordersummary"] = ordersummary;
                return resultobj;
            }
        }
        public static string gettotalpricedesc(decimal TotalCost, decimal TotalSalePoint, int StaffTotalPoint)
        {
            if (TotalSalePoint > 0 && TotalCost > 0)
            {
                return "￥" + TotalCost.ToString("0.00") + " + " + TotalSalePoint.ToString() + "积分";
            }
            if (StaffTotalPoint > 0 && TotalCost > 0)
            {
                return "￥" + TotalCost.ToString("0.00") + " + " + StaffTotalPoint.ToString() + "积分";
            }
            if (TotalCost > 0)
            {
                return "￥" + TotalCost.ToString("0.00");
            }
            if (TotalSalePoint > 0)
            {
                return TotalSalePoint.ToString() + "积分";
            }
            if (StaffTotalPoint > 0)
            {
                return StaffTotalPoint.ToString() + "积分";
            }
            return "￥0.00";
        }
        public static List<Utility.ContractTempPriceModel> GetContractTempPriceList(List<Utility.ContractCalculateTypeModel> tempList, DateTime StartTime, DateTime EndTime, DateTime FirstReadyChargeTime, decimal RoomUnitPrice, int CalculateMonth, DateTime FirstStartTime, int FirstReadyChargeDay)
        {
            var tempList1 = new List<Utility.ContractTempPriceModel>();
            DateTime FinalStartTime = StartTime;
            DateTime FinalEndTime = EndTime;
            int startIndex = 0;
            if (FirstStartTime > DateTime.MinValue)
            {
                FinalStartTime = FirstStartTime.AddDays(1);
                var data = new Utility.ContractTempPriceModel();
                data.StartTime = StartTime;
                data.EndTime = FirstStartTime;
                data.CalculateValue = RoomUnitPrice;
                data.CalculatePercent = 0;
                data.CalculateAmount = 0;
                if (FirstReadyChargeDay > 0)
                {
                    data.ReadyChargeTime = data.StartTime.AddDays(-FirstReadyChargeDay);
                }
                else if (FirstReadyChargeTime > DateTime.MinValue)
                {
                    data.ReadyChargeTime = FirstReadyChargeTime;
                }
                tempList1.Add(data);
                startIndex = 1;
            }
            int FinalMonth = CalculateMonth;
            var list = new List<Utility.ContractTempPriceModel>();
            decimal TotalMonth = (FinalEndTime.Year - FinalStartTime.Year) * 12 + (FinalEndTime.Month - FinalStartTime.Month);
            int TotalNumber = Convert.ToInt32(Math.Ceiling(TotalMonth / FinalMonth));
            for (int i = 0; i <= TotalNumber; i++)
            {
                var data = new Utility.ContractTempPriceModel();
                data.StartTime = CommHelper.CalculateContractTempStartTime(FinalStartTime, FinalEndTime, i, FinalMonth);
                data.EndTime = CommHelper.CalculateContractTempEndTime(FinalStartTime, FinalEndTime, i, FinalMonth);
                data.CalculateValue = RoomUnitPrice;
                data.CalculatePercent = 0;
                data.CalculateAmount = 0;
                if (FirstReadyChargeDay > 0)
                {
                    data.ReadyChargeTime = data.StartTime.AddDays(-FirstReadyChargeDay);
                }
                else if (FirstReadyChargeTime > DateTime.MinValue)
                {
                    data.ReadyChargeTime = FirstReadyChargeTime.AddMonths((startIndex + i) * FinalMonth);
                }
                tempList1.Add(data);
            }
            var tempList2 = new List<Utility.ContractTempPriceModel>();
            foreach (var item in tempList)
            {
                FinalStartTime = item.FirstReadyChargePriceTime;
                FinalEndTime = item.LastReadyChargePriceTime;
                FinalMonth = item.CalcualtePriceMonth;
                if (item.CalculateMonthType == 1)
                {
                    TotalMonth = (FinalEndTime.Year - FinalStartTime.Year) * 12 + (FinalEndTime.Month - FinalStartTime.Month);
                    TotalNumber = Convert.ToInt32(Math.Ceiling(TotalMonth / FinalMonth));
                    for (int i = 0; i <= TotalNumber; i++)
                    {
                        var data = new Utility.ContractTempPriceModel();
                        data.StartTime = CommHelper.CalculateContractTempStartTime(FinalStartTime, FinalEndTime, i, FinalMonth);
                        data.EndTime = CommHelper.CalculateContractTempEndTime(FinalStartTime, FinalEndTime, i, FinalMonth);
                        if (item.CalculateType == "amount")
                        {
                            data.CalculatePercent = 0;
                            data.CalculateAmount = item.CalculateValue;
                        }
                        else
                        {
                            data.CalculateAmount = 0;
                            data.CalculatePercent = item.CalculateValue;
                        }
                        data.CalculateValue = CommHelper.CalculateContractTempPrice(RoomUnitPrice, i + 1, item.CalculateType, item.CalculateValue, item.CalculateValue);
                        data.CalculateType = item.CalculateType;
                        tempList2.Add(data);
                    }
                }
                else
                {
                    TotalMonth = (decimal)(FinalEndTime - FinalStartTime).TotalDays + 1;
                    TotalNumber = Convert.ToInt32(Math.Ceiling(TotalMonth / FinalMonth));
                    for (int i = 0; i <= TotalNumber; i++)
                    {
                        var data = new Utility.ContractTempPriceModel();
                        data.StartTime = CommHelper.CalculateContractTempStartTime(FinalStartTime, FinalEndTime, i, FinalMonth, CalculateType: 2);
                        data.EndTime = CommHelper.CalculateContractTempEndTime(FinalStartTime, FinalEndTime, i, FinalMonth, CalculateType: 2);
                        if (item.CalculateType == "amount")
                        {
                            data.CalculatePercent = 0;
                            data.CalculateAmount = item.CalculateValue;
                        }
                        else
                        {
                            data.CalculateAmount = 0;
                            data.CalculatePercent = item.CalculateValue;
                        }
                        data.CalculateValue = CommHelper.CalculateContractTempPrice(RoomUnitPrice, i + 1, item.CalculateType, item.CalculateValue, item.CalculateValue);
                        data.CalculateType = item.CalculateType;
                        tempList2.Add(data);
                    }
                }
            }
            var timeList2 = tempList1.Select(p => p.EndTime).ToList();
            timeList2.Add(StartTime);
            var timeList4 = tempList2.Select(p => p.EndTime).ToList();

            var timeList = new List<DateTime>();
            timeList.AddRange(timeList2);
            timeList.AddRange(timeList4);
            timeList = timeList.Distinct().ToList();
            foreach (var item in tempList)
            {
                if (timeList.Contains(item.FirstReadyChargePriceTime.AddDays(-1)) && item.FirstReadyChargePriceTime.AddDays(-1) > StartTime)
                {
                    continue;
                }
                if (item.FirstReadyChargePriceTime == item.LastReadyChargePriceTime && item.FirstReadyChargePriceTime == StartTime)
                {
                    timeList.Add(item.FirstReadyChargePriceTime);
                }
                else
                {
                    timeList.Add(item.FirstReadyChargePriceTime.AddDays(-1));
                }
            }
            timeList = timeList.OrderBy(p => p).ToList();
            int count = 0;
            decimal lastUnitPrice = RoomUnitPrice;
            for (int i = 0; i < timeList.Count; i++)
            {
                var time = timeList[i];
                if (time < StartTime || time >= EndTime)
                {
                    continue;
                }
                if (i == timeList.Count - 1)
                {
                    break;
                }
                var nextTime = timeList[i + 1];
                var data = new Utility.ContractTempPriceModel();
                if (count == 0)
                {
                    data.StartTime = time;
                }
                else
                {
                    data.StartTime = time.AddDays(1);
                }
                data.EndTime = nextTime;
                var tempData1 = tempList1.FirstOrDefault(p => data.StartTime >= p.StartTime && data.StartTime <= p.EndTime);
                data.ReadyChargeTime = tempData1 != null ? tempData1.ReadyChargeTime : DateTime.MinValue;
                var tempData2 = tempList2.FirstOrDefault(p => data.StartTime >= p.StartTime && data.StartTime <= p.EndTime);
                data.CalculateValue = tempData2 != null ? tempData2.CalculateValue : lastUnitPrice;
                data.CalculateType = tempData2 != null ? tempData2.CalculateType : string.Empty;
                data.CalculateAmount = tempData2 != null ? tempData2.CalculateAmount : 0;
                data.CalculatePercent = tempData2 != null ? tempData2.CalculatePercent : 0;
                list.Add(data);
                lastUnitPrice = data.CalculateValue;
                count++;
            }
            return list;
        }
    }
}