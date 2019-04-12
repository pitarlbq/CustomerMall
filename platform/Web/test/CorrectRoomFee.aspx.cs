using Foresight.DataAccess.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.test
{
    public partial class CorrectRoomFee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var ViewChargeSummaryList = Foresight.DataAccess.ViewChargeSummary.GetViewChargeSummaries().ToArray();
            var list = Foresight.DataAccess.RoomFeeHistory.GetInCorrectRoomFeeHistoryList();
            var viewRoomFeeList = Foresight.DataAccess.RoomFeeAnalysis.GetRoomFeeAnalysisListByIDList(list.Select(p => p.ID).ToList());
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var field in list)
                    {
                        var viewroomFee = viewRoomFeeList.FirstOrDefault(p => p.ID == field.ID);
                        if (viewroomFee == null)
                        {
                            continue;
                        }
                        var roomFee = Foresight.DataAccess.RoomFee.GetRoomFee(field.ID, helper);
                        if (roomFee == null)
                        {
                            continue;
                        }
                        field.Cost = viewroomFee.TotalCost;
                        field.Save(helper);
                        if (viewroomFee.TotalCost != (field.RealCost + (field.Discount > 0 ? field.Discount : 0)))
                        {
                            continue;
                        }
                        roomFee.Delete(helper);
                        if (roomFee.NewEndTime > DateTime.MinValue && roomFee.EndTime <= roomFee.NewEndTime)
                        {
                            continue;
                        }
                        if (viewroomFee.FeeType != 1)
                        {
                            continue;
                        }
                        DateTime RoomFee_StartTime = DateTime.MinValue;
                        if (field.EndTime > DateTime.MinValue && field.EndTime < DateTime.MaxValue)
                        {
                            RoomFee_StartTime = field.EndTime.AddDays(1);
                        }
                        DateTime RoomFee_EndTime = DateTime.MinValue;
                        if (roomFee.ContractID > 0)
                        {
                            RoomFee_EndTime = roomFee.NewEndTime;
                        }
                        else
                        {
                            var viewChargeSummary = ViewChargeSummaryList.FirstOrDefault(p => p.ID == roomFee.ChargeID);
                            RoomFee_EndTime = Web.APPCode.CommHelper.GetEndTime(viewChargeSummary, RoomFee_StartTime);
                        }
                        var newRoomFee = Foresight.DataAccess.RoomFee.SetInfo_RoomFee(roomFee.RoomID, RoomFee_StartTime, RoomFee_EndTime, 0, 0, roomFee.UnitPrice, roomFee.ChargeID, NewEndTime: roomFee.NewEndTime, ContractID: roomFee.ContractID, DefaultChargeManID: roomFee.DefaultChargeManID, DefaultChargeManName: roomFee.DefaultChargeManName, Contract_RoomChargeID: roomFee.Contract_RoomChargeID, ContractDivideID: roomFee.ContractDivideID, IsTempFee: roomFee.IsTempFee, IsImportFee: roomFee.IsImportFee, IsCycleFee: roomFee.IsCycleFee, IsMeterFee: roomFee.IsMeterFee, cansave: true, helper: helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("CorrectRoomFee", "visit: Submit", ex);
                    return;
                }
            }
        }
    }
}