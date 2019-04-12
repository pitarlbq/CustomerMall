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
    /// This object represents the properties and methods of a CKProudctInDetail.
    /// </summary>
    public partial class CKProudctInDetail : EntityBase
    {
        public static int GetTotalInventory(int ProductID)
        {
            int TotalInventory = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    string cmdtext = "select sum(ISNULL(InTotalCount, 0)) AS InTotalCount from CKProudctInDetail where ProductID=@ProductID";
                    parameters.Add(new SqlParameter("@ProductID", ProductID));
                    object result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                    int InTotalCount = 0;
                    if (result != null)
                    {
                        int.TryParse(result.ToString(), out InTotalCount);
                    }
                    cmdtext = "select sum(ISNULL(OutTotalCount, 0)) AS OutTotalCount from CKProudctOutDetail where  ProductID=@ProductID";
                    result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                    int OutTotalCount = 0;
                    if (result != null)
                    {
                        int.TryParse(result.ToString(), out OutTotalCount);
                    }
                    TotalInventory = InTotalCount - OutTotalCount;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return TotalInventory;
        }
        public static string GetLatestProductOrderNumber(SqlHelper helper)
        {
            string number_1 = DateTime.Now.ToString("yyyyMMdd");
            string number_2 = "01";
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdtext = "select top 1 * from CKProudctInDetail order by isnull([SysProductOrderNumber],'') desc";
            var result = GetOne<CKProudctInDetail>(cmdtext, parameters, helper);
            if (result != null && !string.IsNullOrEmpty(result.SysProductOrderNumber) && result.SysProductOrderNumber.Length > 8)
            {
                if (number_1.Equals(result.SysProductOrderNumber.Substring(0, 8)))
                {
                    number_2 = result.SysProductOrderNumber.Substring(8, result.SysProductOrderNumber.Length - 8);
                    int number2 = 0;
                    int.TryParse(number_2, out number2);
                    number2 += 1;
                    number_2 = number2.ToString("D2");
                }
            }
            return number_1 + number_2;
        }
    }
    public partial class CKProudctInDetail2 : CKProudctInDetail
    {
        [DatabaseColumn("OutTotalCount")]
        public int OutTotalCount { get; set; }
        [DatabaseColumn("InTime")]
        public DateTime InTime { get; set; }
        public static CKProudctInDetail2[] GetCKProudctInDetailListByProductIDList(List<int> ProductIDList, int CKCategoryID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ProductIDList.Count == 0)
            {
                return new CKProudctInDetail2[] { };
            }
            if (CKCategoryID > 0)
            {
                conditions.Add("[InSummaryID] in (select ID from [CKProductInSumary] where [CKCategoryID]=@CKCategoryID)");
                parameters.Add(new SqlParameter("@CKCategoryID", CKCategoryID));
            }
            conditions.Add(@"[ProductID] in (" + string.Join(",", ProductIDList.ToArray()) + ")");
            string Statement = "select * from (select *,(select sum(Inventory) from [CKInOutSummary] where [CKProudctInDetailID]=[CKProudctInDetail].ID) as OutTotalCount,(select top 1 [InTime] from [CKProductInSumary] where [ID]=[CKProudctInDetail].InSummaryID) as InTime from [CKProudctInDetail] where  " + string.Join(" and ", conditions.ToArray()) +
                //@" order by isnull([SysProductOrderNumber],'') asc,AddTime asc"+
            @")A order by InTime asc";
            return GetList<CKProudctInDetail2>(Statement, parameters).ToArray();
        }
    }
}
