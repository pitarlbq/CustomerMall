using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Foresight.DataAccess.Framework;
using System.Linq;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a Contract_Customer.
    /// </summary>
    public partial class Contract_Customer : EntityBase
    {
        public string CustomerTypeDesc
        {
            get
            {
                if (this.CustomerType == 1)
                {
                    return "收款方";
                }
                if (this.CustomerType == 2)
                {
                    return "承租方";
                }
                return string.Empty;
            }
        }
        public int[] ChargeIDList
        {
            get
            {
                if (!string.IsNullOrEmpty(this.ChargeIDs))
                {
                    return Utility.JsonConvert.DeserializeObject<int[]>(this.ChargeIDs);
                }
                return new int[] { };
            }
        }
        public string ChargeName { get; set; }
        public static Ui.DataGrid GetContract_CustomerGrid(int ContractID, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ContractID]=@ContractID");
            parameters.Add(new SqlParameter("@ContractID", ContractID));
            string fieldList = "[Contract_Customer].*";
            string Statement = " from [Contract_Customer] where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Contract_Customer>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            if (list.Length > 0)
            {
                var chargeList = ChargeSummary.GetChargeSummaries().ToArray();
                list = list.Select(p =>
                {
                    var myChargeList = chargeList.Where(q => p.ChargeIDList.Contains(q.ID)).ToArray();
                    if (myChargeList.Length > 0)
                    {
                        p.ChargeName = string.Join(",", myChargeList.Select(q => q.Name).ToArray());
                    }
                    return p;
                }).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Contract_Customer[] GetContract_CustomerListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count > 0)
            {
                conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            return GetList<Contract_Customer>("select * from [Contract_Customer] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static List<DivideHistoryListModel> GetTempRoomFeeHistoryByDivide(ViewTempRoomFeeHistory[] list)
        {
            var data = new List<DivideHistoryListModel>();
            DivideHistoryListModel modelItem = null;
            int[] ContractIDList = list.Where(p => p.ContractDivideID <= 0).Select(p => p.ContractID).ToArray();
            if (ContractIDList.Length == 0)
            {
                modelItem = new DivideHistoryListModel();
                modelItem.CustomerID = 0;
                modelItem.viewTempList = list;
                data.Add(modelItem);
                return data;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("exists(select 1 from [Contract] where [ContractType]=3)");
            conditions.Add("[CustomerType]=1");
            conditions.Add("[ContractID] in (" + string.Join(",", ContractIDList.ToArray()) + ")");
            var customerList = GetList<Contract_Customer>("select * from [Contract_Customer] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            var allChargeIDList = new List<int>();
            foreach (var item in customerList)
            {
                if (item.ChargeIDList.Length == 0)
                {
                    continue;
                }
                allChargeIDList.AddRange(item.ChargeIDList);
                modelItem = new DivideHistoryListModel();
                modelItem.CustomerID = item.ID;
                modelItem.ContractID = item.ContractID;
                modelItem.CustomerName = item.CustomerName;
                modelItem.viewTempList = list.Where(p => item.ChargeIDList.Contains(p.ChargeID)).ToArray();
                data.Add(modelItem);
            }
            var restList = list.Where(p => !allChargeIDList.Contains(p.ChargeID)).ToArray();
            if (restList.Length > 0)
            {
                modelItem = new DivideHistoryListModel();
                modelItem.CustomerID = 0;
                modelItem.viewTempList = restList;
                data.Add(modelItem);
                return data;
            }
            return data;
        }
    }
    public class DivideHistoryListModel
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int ContractID { get; set; }
        public ViewTempRoomFeeHistory[] viewTempList { get; set; }
    }
}
