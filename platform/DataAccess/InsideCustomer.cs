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
    /// This object represents the properties and methods of a InsideCustomer.
    /// </summary>
    public partial class InsideCustomer : EntityBase
    {
        public static Ui.DataGrid GeInsideCustomerGrid(string CustomerBelonger, DateTime StartTime, DateTime EndTime, string Region, string Province, string City, string CustomerName, string IndustryName, string CategoryName, string Interesting, string orderBy, long startRowIndex, int pageSize, bool canexport = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(CustomerBelonger))
            {
                conditions.Add("[CustomerBelonger] like @CustomerBelonger");
                parameters.Add(new SqlParameter("@CustomerBelonger", "%" + CustomerBelonger + "%"));
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[NewFollowupDate]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[NewFollowupDate]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (!string.IsNullOrEmpty(Region))
            {
                conditions.Add("[Region] like @Region");
                parameters.Add(new SqlParameter("@Region", "%" + Region + "%"));
            }
            if (!string.IsNullOrEmpty(Province))
            {
                conditions.Add("[Province] like @Province");
                parameters.Add(new SqlParameter("@Province", "%" + Province + "%"));
            }
            if (!string.IsNullOrEmpty(City))
            {
                conditions.Add("[City] like @City");
                parameters.Add(new SqlParameter("@City", "%" + City + "%"));
            }
            if (!string.IsNullOrEmpty(CustomerName))
            {
                conditions.Add("[CustomerName] like @CustomerName");
                parameters.Add(new SqlParameter("@CustomerName", "%" + CustomerName + "%"));
            }
            if (!string.IsNullOrEmpty(IndustryName))
            {
                conditions.Add("[IndustryName] like @IndustryName");
                parameters.Add(new SqlParameter("@IndustryName", "%" + IndustryName + "%"));
            }
            if (!string.IsNullOrEmpty(CategoryName))
            {
                conditions.Add("[CategoryName] like @CategoryName");
                parameters.Add(new SqlParameter("@CategoryName", "%" + CategoryName + "%"));
            }
            if (!string.IsNullOrEmpty(Interesting))
            {
                conditions.Add("[Interesting] like @Interesting");
                parameters.Add(new SqlParameter("@Interesting", "%" + Interesting + "%"));
            }
            string fieldList = "[InsideCustomer].*";
            string Statement = " from [InsideCustomer] where " + string.Join(" and ", conditions.ToArray());
            InsideCustomer[] list = new InsideCustomer[] { };
            if (canexport)
            {
                list = GetList<InsideCustomer>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
            }
            else
            {
                list = GetList<InsideCustomer>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static InsideCustomer[] GeInsideCustomerList(List<int> IDList, string OrderBy)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count > 0)
            {
                conditions.Add("ID in (" + string.Join(",", IDList.ToArray()) + ")");
            }
            string fieldList = "select [InsideCustomer].* from [InsideCustomer] where " + string.Join(" and ", conditions.ToArray()) + " " + OrderBy;
            InsideCustomer[] list = new InsideCustomer[] { };
            list = GetList<InsideCustomer>(fieldList, parameters).ToArray();
            return list;
        }
        public static InsideCustomer GeInsideCustomerByParams(string CustomerName, string ContactPhone, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(CustomerName))
            {
                conditions.Add("[CustomerName]=@CustomerName");
                parameters.Add(new SqlParameter("@CustomerName", CustomerName));
            }
            if (!string.IsNullOrEmpty(ContactPhone))
            {
                conditions.Add("[ContactPhone]=@ContactPhone");
                parameters.Add(new SqlParameter("@ContactPhone", ContactPhone));
            }
            string fieldList = "select top 1 * from [InsideCustomer] where " + string.Join(" and ", conditions.ToArray());
            return GetOne<InsideCustomer>(fieldList, parameters, helper);
        }
        public static InsideCustomer GetNextInsideCustomer(int ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ID > 0)
            {
                conditions.Add("[ID]<@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            string fieldList = "select top 1 * from [InsideCustomer] where " + string.Join(" and ", conditions.ToArray()) + " order by ID desc";
            return GetOne<InsideCustomer>(fieldList, parameters);
        }
    }
}
