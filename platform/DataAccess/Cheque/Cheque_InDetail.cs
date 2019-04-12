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
    /// This object represents the properties and methods of a Cheque_InDetail.
    /// </summary>
    public partial class Cheque_InDetail : EntityBase
    {
        public static Ui.DataGrid GetCheque_InDetailGridByKeywords(int InSummaryID, string GUID, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[GUID]=@GUID");
            parameters.Add(new SqlParameter("@GUID", GUID));
            if (InSummaryID > 0)
            {
                conditions.Add("[InSummaryID]=@InSummaryID");
                parameters.Add(new SqlParameter("@InSummaryID", InSummaryID));
            }
            string fieldList = "[Cheque_InDetail].*";
            string Statement = " from [Cheque_InDetail] where  " + string.Join(" or ", conditions.ToArray());
            Cheque_InDetail[] list = GetList<Cheque_InDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            string footertext = "select '合计' as [ProductName],'' as [ModelNumber],'' as [Unit], sum(isnull([TotalCost],0)) as TotalCost,sum(isnull([TotalTaxCost],0)) as TotalTaxCost from [Cheque_InDetail] where  " + string.Join(" or ", conditions.ToArray()) + @" UNION ALL select '税价合计(大写)' as[ProductName], dbo.MoneyToCapital(sum(isnull([TotalSummaryCost],0)),0,2) as [ModelNumber],'小写' as[Unit],  sum(isnull([TotalSummaryCost],0)) as TotalCost, 0 as TotalTaxCost from [Cheque_InDetail] where " + string.Join(" or ", conditions.ToArray());
            dg.footer = GetList<Cheque_InDetail>(footertext, parameters).ToArray();
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Cheque_InDetail[] GetCheque_InDetailList(int InSummaryID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (InSummaryID > 0)
            {
                conditions.Add("[InSummaryID]=@InSummaryID");
                parameters.Add(new SqlParameter("@InSummaryID", InSummaryID));
            }
            string Statement = "select * from [Cheque_InDetail] where  " + string.Join(" and ", conditions.ToArray());
            Cheque_InDetail[] list = GetList<Cheque_InDetail>(Statement, parameters).ToArray();
            return list;
        }
        public static Cheque_InDetail[] GetCheque_InDetailList(int InSummaryID, string GUID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[GUID]=@GUID");
            parameters.Add(new SqlParameter("@GUID", GUID));
            if (InSummaryID > 0)
            {
                conditions.Add("[InSummaryID]=@InSummaryID");
                parameters.Add(new SqlParameter("@InSummaryID", InSummaryID));
            }
            string Statement = "select * from [Cheque_InDetail] where  " + string.Join(" or ", conditions.ToArray());
            Cheque_InDetail[] list = GetList<Cheque_InDetail>(Statement, parameters).ToArray();
            return list;
        }
        public static Cheque_InDetail GetCheque_InDetail(int InSummaryID, int ProductID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetCheque_InDetail(InSummaryID, ProductID, helper);
            }
        }
        public static Cheque_InDetail GetCheque_InDetail(int InSummaryID, int ProductID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ProductID > 0)
            {
                conditions.Add("[ProductID]=@ProductID");
                parameters.Add(new SqlParameter("@ProductID", ProductID));
            }
            if (InSummaryID > 0)
            {
                conditions.Add("[InSummaryID]=@InSummaryID");
                parameters.Add(new SqlParameter("@InSummaryID", InSummaryID));
            }
            string Statement = "select * from [Cheque_InDetail] where  " + string.Join(" and ", conditions.ToArray());
            return GetOne<Cheque_InDetail>(Statement, parameters, helper);
        }
    }
}
