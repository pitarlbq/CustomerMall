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
    /// This object represents the properties and methods of a CKProperty.
    /// </summary>
    public partial class CKProperty : EntityBase
    {
        public string PropertyStateDesc
        {
            get
            {
                string desc = string.Empty;
                switch (this.PropertyState)
                {
                    case 1:
                        desc = "在用";
                        break;
                    case 2:
                        desc = "封存";
                        break;
                    case 3:
                        desc = "待报废";
                        break;
                    case 4:
                        desc = "报废";
                        break;
                    case 5:
                        desc = "租赁";
                        break;
                    case 6:
                        desc = "出租";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
    }
    public partial class CKPropertyDetails : CKProperty
    {
        [DatabaseColumn("PropertyDepartmentName")]
        public string PropertyDepartmentName { get; set; }
        [DatabaseColumn("PropertyCategoryName")]
        public string PropertyCategoryName { get; set; }
        public static CKPropertyDetails GetCKPropertyDetailsByPropertyNo(string PropertyNo)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(PropertyNo))
            {
                conditions.Add("[PropertyNo]=@PropertyNo");
                parameters.Add(new SqlParameter("@PropertyNo", PropertyNo));
            }
            return GetOne<CKPropertyDetails>("select top 1 *,(select [DepartmentName] from [CKDepartment] where ID=[CKProperty].PropertyDepartmentID) as PropertyDepartmentName,(select [PropertyCategoryName] from [CKPropertyCategory] where ID=[CKProperty].PropertyCategoryID) as PropertyCategoryName from [CKProperty] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static Ui.DataGrid GetCKPropertyDetailsGridByKeywords(string Keywords, DateTime StartTime, DateTime EndTime, List<int> DepartmentIDList, string orderBy, long startRowIndex, int pageSize, bool canexport = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (DepartmentIDList.Count > 0)
            {
                conditions.Add("[PropertyDepartmentID] in (" + string.Join(",", DepartmentIDList.ToArray()) + ")");
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([PropertyName] like @Keywords or [PropertyNo] like @Keywords or [PropertyModelNo] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[PropertyPurchaseDate]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[PropertyPurchaseDate]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            string fieldList = "[CKProperty].*,(select [DepartmentName] from [CKDepartment] where ID=[CKProperty].PropertyDepartmentID) as PropertyDepartmentName,(select [PropertyCategoryName] from [CKPropertyCategory] where ID=[CKProperty].PropertyCategoryID) as PropertyCategoryName";
            string Statement = " from [CKProperty] where  " + string.Join(" and ", conditions.ToArray());
            CKPropertyDetails[] list = new CKPropertyDetails[] { };
            if (canexport)
            {
                list = GetList<CKPropertyDetails>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
                totalRows = list.Length;
            }
            else
            {
                list = GetList<CKPropertyDetails>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
