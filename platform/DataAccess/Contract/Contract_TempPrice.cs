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
    /// This object represents the properties and methods of a Contract_TempPrice.
    /// </summary>
    public partial class Contract_TempPrice : EntityBase
    {

        public static Contract_TempPrice[] GetContract_TempPriceListByGuid(string guid, List<int> ChargeIDList = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(guid))
            {
                conditions.Add("[GUID]=@guid");
                parameters.Add(new SqlParameter("@guid", guid));
            }
            if (ChargeIDList != null && ChargeIDList.Count > 0)
            {
                conditions.Add("[ChargeID] in (" + string.Join(",", ChargeIDList.ToArray()) + ")");
            }
            string fieldList = "select [Contract_TempPrice].* from [Contract_TempPrice] where  " + string.Join(" and ", conditions.ToArray());
            Contract_TempPrice[] list = GetList<Contract_TempPrice>(fieldList, parameters).ToArray();
            return list;
        }
        public static Contract_TempPrice Add_Contract_TempPrice(decimal BasicPrice, DateTime BasicStartTime, DateTime BasicEndTime, string CalculateType, decimal CalculatePercent, decimal CalculateAmount, string GUID, DateTime ReadyChargeTime, DateTime CalculateStartTime, DateTime CalculateEndTime, decimal CalculatePrice)
        {
            var data = new Contract_TempPrice();
            data.BasicPrice = BasicPrice;
            data.BasicStartTime = BasicStartTime;
            data.BasicEndTime = BasicEndTime;
            data.CalculateType = CalculateType;
            data.CalculatePercent = CalculatePercent;
            data.CalculateAmount = CalculateAmount;
            data.GUID = GUID;
            data.AddTime = DateTime.Now;
            data.ReadyChargeTime = ReadyChargeTime;
            data.CalculateStartTime = CalculateStartTime;
            data.CalculateEndTime = CalculateEndTime;
            data.CalculatePrice = CalculatePrice;
            return data;
        }
    }
}
