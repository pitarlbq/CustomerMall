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
    /// This object represents the properties and methods of a CKPropertyTemp.
    /// </summary>
    public partial class CKPropertyTemp : EntityBase
    {
        public static void InsertCKPropertyTempByPropertyID(int PropertyID, string AddMan)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    AddMan = string.IsNullOrEmpty(AddMan) ? "NULL" : "'" + AddMan + "'";
                    string cmdtext = @"
                    INSERT INTO [dbo].[CKPropertyTemp]
                   ([ID]
                   ,[PropertyName]
                   ,[PropertyCategoryID]
                   ,[PropertyNo]
                   ,[PropertyModelNo]
                   ,[PropertyUnit]
                   ,[PropertyCount]
                   ,[PropertyUnitPrice]
                   ,[PropertyCost]
                   ,[PropertyPurchaseDate]
                   ,[PropertyUseYear]
                   ,[PropertyRealCost]
                   ,[PropertyChangeType]
                   ,[PropertyState]
                   ,[PropertyDepartmentID]
                   ,[PropertyLocation]
                   ,[PropertyUseMan]
                   ,[PropertyContractName]
                   ,[PropertyContactPhone]
                   ,[PropertyRemark]
                   ,[AddMan]
                   ,[AddTime]
                   ,[PropertyDiscountCost]
                   ,[UpdateMan]
                   ,[UpdateTime]
                   ,[ModifyTime]
                   ,[ModifyMan])
                    select *,getdate()," + AddMan + " from [CKProperty] where ID=@ID";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ID", PropertyID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                }
            }
        }
        public static Ui.DataGrid GetCKPropertyTempGridByKeywords(int PropertyID, string Keywords, DateTime StartTime, DateTime EndTime, List<int> DepartmentIDList, string orderBy, long startRowIndex, int pageSize)
        {
            ResetCache();
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (PropertyID > 0)
            {
                conditions.Add("[ID]=@PropertyID");
                parameters.Add(new SqlParameter("@PropertyID", PropertyID));
            }
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
                conditions.Add("[ModifyTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[ModifyTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            string fieldList = "[CKPropertyTemp].*";
            string Statement = " from [CKPropertyTemp] where  " + string.Join(" and ", conditions.ToArray());
            CKPropertyTemp[] list = GetList<CKPropertyTemp>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string PropertyDepartmentName
        {
            get
            {
                string desc = string.Empty;
                if (CKDepartmentList == null)
                {
                    CKDepartmentList = DataAccess.CKDepartment.GetCKDepartments().ToArray();
                }
                var data = CKDepartmentList.FirstOrDefault(p => p.ID == this.PropertyDepartmentID);
                return data == null ? string.Empty : data.DepartmentName;
            }
        }
        public string PropertyCategoryName
        {
            get
            {
                string desc = string.Empty;
                if (CKPropertyCategoryList == null)
                {
                    CKPropertyCategoryList = DataAccess.CKPropertyCategory.GetCKPropertyCategories().ToArray();
                }
                var data = CKPropertyCategoryList.FirstOrDefault(p => p.ID == this.PropertyCategoryID);
                return data == null ? string.Empty : data.PropertyCategoryName;
            }
        }
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
        public static CKDepartment[] CKDepartmentList = null;
        public static CKPropertyCategory[] CKPropertyCategoryList = null;
        public static void ResetCache()
        {
            CKDepartmentList = null;
            CKPropertyCategoryList = null;
        }
    }
}
