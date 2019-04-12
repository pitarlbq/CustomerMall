using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.SetupFee
{
    public partial class EditFee : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetCalculateAreaTypeList();
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                int ID = 0;
                if (int.TryParse(Request.QueryString["ID"], out ID))
                {
                    var viewsummary = Foresight.DataAccess.ViewChargeSummary.GetViewChargeSummaryByChargeID(ID);
                    if (viewsummary != null)
                    {
                        SetInfo(viewsummary);
                        return;
                    }
                }
            }
            this.tdIsOrderFeeOn.Value = "1";
        }
        private void SetInfo(Foresight.DataAccess.ViewChargeSummary data)
        {
            this.tdName.Value = data.Name;
            int FeeType = data.FeeType == int.MinValue ? 1 : data.FeeType;
            this.tdFeeType.Value = FeeType.ToString();
            this.tdCategory.Value = data.CategoryID == int.MinValue ? "1" : data.CategoryID.ToString();
            this.tdUnitPrice.Value = data.SummaryUnitPrice == decimal.MinValue ? "0" : data.SummaryUnitPrice.ToString();
            this.tdStartTime.Value = data.SummaryStartTime == DateTime.MinValue ? "" : data.SummaryStartTime.ToString("yyyy-MM-dd");
            this.tdEndTime.Value = data.SummaryEndStartTime == DateTime.MinValue ? "" : data.SummaryEndStartTime.ToString("yyyy-MM-dd");
            this.tdChargeType.Value = data.TypeID == int.MinValue ? "1" : data.TypeID.ToString();
            this.tdEndType.Value = data.EndTypeID == int.MinValue ? "1" : data.EndTypeID.ToString();
            this.tdChargeTypeCount.Value = data.SummaryChargeTypeCount == int.MinValue ? "" : data.SummaryChargeTypeCount.ToString();
            this.tdEndNumberCount.Value = data.EndNumberCount == int.MinValue ? "" : data.EndNumberCount.ToString();
            this.tdUnit.Value = data.Unit;
            this.tdAllowImport.Value = data.IsAllowImport ? "1" : "0";
            this.tdIsReading.Value = data.IsReading ? "1" : "0";
            this.tbRemark.Value = data.Remark;
            this.tdEndNumberType.Value = data.EndNumberType == int.MinValue ? "1" : data.EndNumberType.ToString();
            this.tdAutoNextMonth.Checked = data.AutoToMonthEnd;
            this.tdBiaoCategory.Value = data.BiaoCategory;
            this.tdTimeAuto.Value = data.TimeAuto ? "1" : "0";
            this.tdSortOrder.Value = data.OrderBy == int.MinValue ? "0" : data.OrderBy.ToString();
            this.tdIsOrderFeeOn.Value = data.IsOrderFeeOn ? "1" : "0";
            this.tdWeiYuePercent.Value = data.WeiYuePercent > decimal.MinValue ? data.WeiYuePercent.ToString() : "";
            string RelateCharges = data.RelateCharges;
            if (!string.IsNullOrEmpty(RelateCharges))
            {
                RelateCharges = RelateCharges.Substring(1, RelateCharges.Length - 2);
            }
            this.tdRelateCharges.Value = RelateCharges;
            this.tdChargeWeiYueType.Value = data.ChargeWeiYueType > int.MinValue ? data.ChargeWeiYueType.ToString() : "";
            this.tdDayGunLi.Checked = data.DayGunLi;
            this.tdWeiYueStartDate.Value = data.WeiYueStartDate;
            this.tdWeiYueBefore.Value = data.WeiYueBefore;
            this.tdWeiYueDays.Value = data.WeiYueDays > int.MinValue ? data.WeiYueDays.ToString() : "";
            this.tdCalculateAreaType.Value = data.CalculateAreaType;
            this.tdWeiYueActiveStartDate.Value = data.WeiYueActiveStartDate;
            this.tdWeiYueActiveBeforeAfter.Value = data.WeiYueActiveBeforeAfter;
            this.tdWeiYueActiveCount.Value = data.WeiYueActiveCount > int.MinValue ? data.WeiYueActiveCount.ToString() : "";
            this.tdWeiYueActiveDayMonth.Value = data.WeiYueActiveDayMonth;
            this.tdWeiYueEndDate.Value = data.WeiYueEndDate;
            this.StartPriceRange.Checked = data.StartPriceRange;
            this.tdDisableDefaultImportFee.Value = data.DisableDefaultImportFee ? "1" : "0";
            this.tdPriceRangeStartTime.Value = WebUtil.GetStrDate(data.PriceRangeStartTime);
            this.tdChargeFeeType.Value = data.ChargeFeeType > 0 ? data.ChargeFeeType.ToString() : "0";
        }
        private void GetCalculateAreaTypeList()
        {
            string TableName = Utility.EnumModel.DefineFieldTableName.RoomBasic.ToString();
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            var dic = new Dictionary<string, object>();
            dic["ID"] = "";
            dic["Name"] = "无";
            list.Add(dic);
            //计费面积
            dic = new Dictionary<string, object>();
            dic["ID"] = Utility.EnumModel.ChargeSummaryCalculateAreaType.jifei.ToString();
            dic["Name"] = base.GetExistColumns(TableName, "BuildingArea");
            list.Add(dic);
            //建筑面积
            dic = new Dictionary<string, object>();
            dic["ID"] = Utility.EnumModel.ChargeSummaryCalculateAreaType.jianzhu.ToString();
            dic["Name"] = base.GetExistColumns(TableName, "BuildOutArea");
            list.Add(dic);
            //套内面积
            dic = new Dictionary<string, object>();
            dic["ID"] = Utility.EnumModel.ChargeSummaryCalculateAreaType.taonei.ToString();
            dic["Name"] = base.GetExistColumns(TableName, "BuildInArea");
            list.Add(dic);
            //公摊面积
            dic = new Dictionary<string, object>();
            dic["ID"] = Utility.EnumModel.ChargeSummaryCalculateAreaType.gongtan.ToString();
            dic["Name"] = base.GetExistColumns(TableName, "GonTanArea");
            list.Add(dic);
            //产权面积
            dic = new Dictionary<string, object>();
            dic["ID"] = Utility.EnumModel.ChargeSummaryCalculateAreaType.chanquan.ToString();
            dic["Name"] = base.GetExistColumns(TableName, "ChanQuanArea");
            list.Add(dic);
            //使用面积
            dic = new Dictionary<string, object>();
            dic["ID"] = Utility.EnumModel.ChargeSummaryCalculateAreaType.shiyong.ToString();
            dic["Name"] = base.GetExistColumns(TableName, "UseArea");
            list.Add(dic);
            //配套面积
            dic = new Dictionary<string, object>();
            dic["ID"] = Utility.EnumModel.ChargeSummaryCalculateAreaType.peitao.ToString();
            dic["Name"] = base.GetExistColumns(TableName, "PeiTaoArea");
            list.Add(dic);
            this.hdCalculateAreaType.Value = JsonConvert.SerializeObject(list);
        }
    }
}