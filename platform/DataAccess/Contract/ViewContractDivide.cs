using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a ViewContractDivide.
    /// </summary>
    public partial class ViewContractDivide : EntityBaseReadOnly
    {
        public decimal ContractBasicRentCost { get; set; }
        public decimal TotalCost
        {
            get
            {
                if (costdic.ContainsKey(this.ID))
                {
                    return costdic[this.ID];
                }
                decimal cost = Contract_Divide.calculate_cost(this.ID, this.SellCost, this.DivideType);
                if (this.ContractBasicRentCost > cost)
                {
                    cost = this.ContractBasicRentCost;
                }
                return cost;
                costdic.Add(this.ID, cost);
                return cost;
            }
        }
        public decimal DiscountCost
        {
            get
            {
                if (discountcostdic.ContainsKey(this.ID))
                {
                    return discountcostdic[this.ID];
                }
                decimal discount = 0;
                if (this.ChargeStatus != 2)
                {
                    discount = feelist.Where(p => p.ContractDivideID == this.ID && p.Discount > 0).Sum(p => p.Discount);
                    discount += historylist.Where(p => p.ContractDivideID == this.ID && p.Discount > 0).Sum(p => p.Discount);
                }
                discountcostdic.Add(this.ID, discount);
                return discount;
            }
        }
        public decimal RealCost
        {
            get
            {
                if (realcostdic.ContainsKey(this.ID))
                {
                    return realcostdic[this.ID];
                }
                decimal realcost = 0;
                if (this.ChargeStatus != 2)
                {
                    realcost = historylist.Where(p => p.ContractDivideID == this.ID && p.RealCost > 0).Sum(p => p.RealCost);
                }
                realcostdic.Add(this.ID, realcost);
                return realcost;
            }
        }
        public decimal RestCost
        {
            get
            {
                if (restcostdic.ContainsKey(this.ID))
                {
                    return restcostdic[this.ID];
                }
                decimal restcost = this.TotalCost - this.DiscountCost - this.RealCost;
                restcostdic.Add(this.ID, restcost);
                return restcost;
            }
        }
        public static RoomFeeAnalysis[] feelist = new RoomFeeAnalysis[] { };
        public static RoomFeeHistory[] historylist = new RoomFeeHistory[] { };
        public static Dictionary<int, decimal> discountcostdic = new Dictionary<int, decimal>();
        public static Dictionary<int, decimal> realcostdic = new Dictionary<int, decimal>();
        public static Dictionary<int, decimal> restcostdic = new Dictionary<int, decimal>();
        public static Dictionary<int, decimal> costdic = new Dictionary<int, decimal>();
        public static void ReSetParams()
        {
            Contract_Divide.ReSetParams();
            feelist = new RoomFeeAnalysis[] { };
            historylist = new RoomFeeHistory[] { };
            discountcostdic = new Dictionary<int, decimal>();
            realcostdic = new Dictionary<int, decimal>();
            restcostdic = new Dictionary<int, decimal>();
            costdic = new Dictionary<int, decimal>();
        }
        public static Ui.DataGrid GetViewContractDivideGridByKeywords(string Keywords, DateTime StartTime, DateTime EndTime, string orderBy, long startRowIndex, int pageSize, List<int> ProjectIDList, List<int> RoomIDList, int ContractID, bool canexport = false)
        {
            ReSetParams();
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            #region 关键字查询
            string cmd = string.Empty;
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([ContractNo] like @Keywords or [ContractName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            #endregion
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[WriteDate]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[WriteDate]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (ContractID > 0)
            {
                conditions.Add("[ContractID]=@ContractID");
                parameters.Add(new SqlParameter("@ContractID", ContractID));
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("([AllParentID] like '%," + ProjectID + ",%' or [ID] =" + ProjectID + ")");
                }
                conditions.Add("[ContractID] in (select [ContractID] from [Contract_Room] where [RoomID] in (select [ID] from [Project] where (" + string.Join(" or ", cmdlist.ToArray()) + ")))");
            }
            if (RoomIDList.Count > 0)
            {
                conditions.Add("[ContractID] in (select [ContractID] from [Contract_Room] where [RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + "))");
            }
            string fieldList = "[ViewContractDivide].*";
            string Statement = " from [ViewContractDivide] where  " + string.Join(" and ", conditions.ToArray()) + cmd;
            ViewContractDivide[] list = new ViewContractDivide[] { };
            if (canexport)
            {
                list = GetList<ViewContractDivide>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
            }
            else
            {
                list = GetList<ViewContractDivide>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            if (list.Length > 0)
            {
                var idlist = list.Where(p => p.ChargeStatus != 2).Select(p => p.ID).ToList();
                feelist = RoomFeeAnalysis.GetRoomFeeAnalysisListByContractDivideIDList(idlist);
                historylist = RoomFeeHistory.GetRoomFeeHistoryListByContractDivideIDList(idlist);
                int MinContractID = list.Min(p => p.ContractID);
                int MaxContractID = list.Max(p => p.ContractID);
                var contractList = GetList<Contract>("select ID,ContractBasicRentCost from [Contract] where ID between " + MinContractID + " and " + MaxContractID, new List<SqlParameter>()).ToArray();
                foreach (var item in list)
                {
                    var myContract = contractList.FirstOrDefault(p => p.ID == item.ContractID);
                    if (myContract != null)
                    {
                        item.ContractBasicRentCost = myContract.ContractBasicRentCost;
                    }
                }
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string ChargeStatusDesc
        {
            get
            {
                switch (this.ChargeStatus)
                {
                    case 0:
                        return "未收";
                        break;
                    case 1:
                        return "已收";
                        break;
                    case 2:
                        return "草稿";
                        break;
                    default:
                        return "草稿";
                        break;
                }
            }
        }
        public string DivideTypeDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.DivideType))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.ContractDivideTypeDefine), this.DivideType);
            }
        }
    }
    public partial class ViewContractDivideDetail : ViewContractDivide
    {

    }
}
