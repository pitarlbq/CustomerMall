using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a ViewRoomBalance.
    /// </summary>
    public partial class ViewRoomBalance : EntityBaseReadOnly
    {
        public static decimal GetGuaranteeBalance(List<int> RoomIDList)
        {
            decimal guaranteefee = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                helper.BeginTransaction();
                try
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    string cmdwhere = string.Empty;
                    if (RoomIDList.Count > 0)
                    {
                        cmdwhere += " and RoomID in (" + string.Join(",", RoomIDList.ToArray()) + ")";
                    }
                    string cmdtext = @"select sum(RealCost) from RoomFeeHistory where ChargeID in
(select ID from ChargeSummary where CategoryID = 3) and ChargeState in(1,4) " + cmdwhere;
                    var TotalGuaranteeFee = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                    decimal totalguaranteefee = 0;
                    if (TotalGuaranteeFee != null)
                    {
                        decimal.TryParse(TotalGuaranteeFee.ToString(), out totalguaranteefee);
                    }

                    cmdtext = @"select sum(RealCost) from RoomFeeHistory where ChargeID in (select ID from ChargeSummary where CategoryID = 3) and ChargeState=3 " + cmdwhere;
                    var ConsumeGuaranteeFee = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                    decimal consumeguaranteefee = 0;
                    if (ConsumeGuaranteeFee != null)
                    {
                        decimal.TryParse(ConsumeGuaranteeFee.ToString(), out consumeguaranteefee);
                    }
                    guaranteefee = totalguaranteefee - consumeguaranteefee;
                    if (guaranteefee < 0)
                    {
                        guaranteefee = 0;
                    }
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                }
            }
            return guaranteefee;
        }
        public static decimal GetPreChargeBalance(List<int> RoomIDList, int ChargeID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetPreChargeBalance(RoomIDList, ChargeID, helper);
            }
        }
        public static decimal GetPreChargeBalance(List<int> RoomIDList, int ChargeID, SqlHelper helper)
        {
            decimal total = 0;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string cmdwhere1 = string.Empty;
                string cmdwhere2 = string.Empty;
                if (RoomIDList.Count > 0)
                {
                    cmdwhere1 += "and (RoomID in (select [RoomID] from [RoomRelation] where exists (select 1 from [RoomRelation] as RoomRelation_2 where RoomRelation_2.[RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + ") and RoomRelation_2.[GUID]=[RoomRelation].GUID)) or RoomID in (" + string.Join(",", RoomIDList.ToArray()) + "))";
                    cmdwhere2 += "and (RoomID in (select [RoomID] from [RoomRelation] where exists (select 1 from [RoomRelation] as RoomRelation_2 where RoomRelation_2.[RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + ") and RoomRelation_2.[GUID]=[RoomRelation].GUID)) or RoomID in (" + string.Join(",", RoomIDList.ToArray()) + "))";
                }
                if (ChargeID > 0)
                {
                    cmdwhere1 += " and ChargeID=@ChargeID";
                    cmdwhere2 += " and (ChargeID=@ChargeID or ChongDiChargeID=@ChargeID)";
                    parameters.Add(new SqlParameter("@ChargeID", ChargeID));
                }
                string cmdtext = @"select sum(RealCost) from RoomFeeHistory where ChargeID in (select ID
from ChargeSummary where  CategoryID = 4) and ChargeState in(1)" + cmdwhere1;
                var TotalBalance = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                decimal totalbalance = 0;//预收款收款金额
                if (TotalBalance != null)
                {
                    decimal.TryParse(TotalBalance.ToString(), out totalbalance);
                }
                cmdtext = @"select sum(RealCost) from RoomFeeHistory where ChargeState in (4,6)" + cmdwhere2;
                var ConsumeBalance = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                decimal consumebalance = 0;//冲抵-退预收款金额
                if (ConsumeBalance != null)
                {
                    decimal.TryParse(ConsumeBalance.ToString(), out consumebalance);
                }
                total = totalbalance - consumebalance;
                if (total < 0)
                {
                    total = 0;
                }
            }
            catch (Exception)
            {
            }
            return total;
        }

    }
}
