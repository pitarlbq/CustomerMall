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
    /// This object represents the properties and methods of a Contract_Divide.
    /// </summary>
    public partial class Contract_Divide : EntityBase
    {
        public decimal ContractBasicRentCost { get; set; }
        public static Dictionary<int, decimal> totalcostdic = new Dictionary<int, decimal>();
        public static Dictionary<int, Contract_DivideType[]> typedic = new Dictionary<int, Contract_DivideType[]>();
        public static Contract_DivideType[] typelist = new Contract_DivideType[] { };
        public static void ReSetParams()
        {
            totalcostdic = new Dictionary<int, decimal>();
            typedic = new Dictionary<int, Contract_DivideType[]>();
            typelist = new Contract_DivideType[] { };
        }
        public static Contract_Divide[] Get_Contract_DivideList()
        {
            var list = Contract_Divide.GetContract_Divides().ToArray();
            GetFinalContract_DivideList(list);
            return list;
        }
        public static Contract_Divide[] GetContract_DivideList(List<int> IDList)
        {
            ReSetParams();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            var list = GetList<Contract_Divide>("select * from [Contract_Divide] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters).ToArray();
            GetFinalContract_DivideList(list);
            return list;
        }
        public static void GetFinalContract_DivideList(Contract_Divide[] list)
        {
            if (list.Length > 0)
            {
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
        }
        public decimal TotalCost
        {
            get
            {
                decimal cost = calculate_cost(this.ID, this.SellCost, this.DivideType);
                if (this.ContractBasicRentCost > cost)
                {
                    return this.ContractBasicRentCost;
                }
                return cost;
            }
        }
        public static decimal calculate_cost(int ID, decimal SellCost, string DivideType)
        {
            if (totalcostdic.ContainsKey(ID))
            {
                return totalcostdic[ID];
            }
            if (SellCost <= 0)
            {
                return 0;
            }
            Contract_DivideType[] mytypelist = new Contract_DivideType[] { };
            if (typedic.ContainsKey(ID))
            {
                mytypelist = typedic[ID];
            }
            else
            {
                mytypelist = getdividetypelist().Where(p => p.Contract_DivideID == ID).ToArray();
                typedic.Add(ID, mytypelist);
            }
            if (mytypelist.Length == 0)
            {
                return 0;
            }
            decimal cost = 0;
            if (DivideType.Equals(Utility.EnumModel.ContractDivideTypeDefine.fixedpercent.ToString()))
            {
                var mytype = mytypelist.FirstOrDefault(p => p.DivideType.Equals(DivideType));
                if (mytype == null)
                {
                    return 0;
                }
                if (mytype.Divide_Percent <= 0)
                {
                    return 0;
                }
                cost = SellCost * mytype.Divide_Percent / 100;
            }
            else if (DivideType.Equals(Utility.EnumModel.ContractDivideTypeDefine.jietipercent.ToString()))
            {
                var mytypes = mytypelist.Where(p => p.DivideType.Equals(DivideType)).OrderBy(p => p.DivideStartCost).ToArray();
                foreach (var item in mytypes)
                {
                    if (item.DivideEndCost < item.DivideStartCost)
                    {
                        continue;
                    }
                    if (item.DivideEndCost <= SellCost)
                    {
                        cost += (item.DivideEndCost - item.DivideStartCost) * item.Divide_Percent / 100;
                    }
                }
            }
            totalcostdic.Add(ID, cost);
            return cost;
        }
        private static Contract_DivideType[] getdividetypelist()
        {
            if (typelist.Length == 0)
            {
                typelist = Contract_DivideType.GetContract_DivideTypes().ToArray();
            }
            return typelist;
        }
    }
}
