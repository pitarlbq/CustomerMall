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
    /// This object represents the properties and methods of a ViewGuaranteeHistoryFee.
    /// </summary>
    public partial class ViewGuaranteeHistoryFee : EntityBaseReadOnly
    {
        [DatabaseColumn("BackCost")]
        public decimal BackCost { get; set; }
        public static Ui.DataGrid GetGuaranteeRoomFeeGridByRoomID(List<int> RoomID, int CategoryID, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ChargeState] in(1,4)");
            conditions.Add("[RealCost]>isnull([BackCost],0)");
            if (RoomID.Count > 0)
            {
                conditions.Add("[RoomID] in (" + string.Join(",", RoomID.ToArray()) + ")");
            }
            if (CategoryID > 0)
            {
                conditions.Add("[CategoryID]=@CategoryID");
                parameters.Add(new SqlParameter("@CategoryID", CategoryID));
            }
            conditions.Add("isnull([BackCost],0)<[RealCost]");
            string fieldList = "A.*";
            string Statement = " from (select *,(select sum(RealCost) from [RoomFeeHistory] where ChargeID=[ViewGuaranteeHistoryFee].ChargeID and ChargeState=3 and [ParentHistoryID]=[ViewGuaranteeHistoryFee].HistoryID) as BackCost from [ViewGuaranteeHistoryFee])A where  " + string.Join(" and ", conditions.ToArray());
            ViewGuaranteeHistoryFee[] list = new ViewGuaranteeHistoryFee[] { };
            list = GetList<ViewGuaranteeHistoryFee>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string ChargeStateDesc
        {
            get
            {
                string typedesc = string.Empty;
                switch (this.ChargeState)
                {
                    case 1:
                        typedesc = "已收费";
                        break;
                    case 2:
                        typedesc = "已作废";
                        break;
                    case 3:
                        typedesc = "退保证金";
                        break;
                    case 4:
                        typedesc = "冲抵收费";
                        break;
                    default:
                        break;
                }
                return typedesc;
            }
        }
    }
}
