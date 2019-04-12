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
    /// This object represents the properties and methods of a Mall_BusinessDiscountRequest.
    /// </summary>
    public partial class Mall_BusinessDiscountRequest : EntityBase
    {
        public static Mall_BusinessDiscountRequest[] GetMall_BusinessDiscountRequestByUserID(int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (UserID == 0)
            {
                return null;
            }
            conditions.Add("[BusinessID] in (select ID from [Mall_Business] where [UserID]=@UserID) or [BusinessID] in (select [BusinessID] from [Mall_BusinessUser] where [UserID]=@UserID)");
            parameters.Add(new SqlParameter("@UserID", UserID));
            return GetList<Mall_BusinessDiscountRequest>("select * from [Mall_BusinessDiscountRequest] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public string StatusDesc
        {
            get
            {
                if (this.Status == 1)
                {
                    return "待审核";
                }
                if (this.Status == 2)
                {
                    return "审核通过";
                }
                if (this.Status == 3)
                {
                    return "审核未通过";
                }
                return "待审核";
            }
        }
        public string AddTimeDesc
        {
            get
            {
                return this.AddTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public string ApproveTimeDesc
        {
            get
            {
                if (this.ApproveTime == DateTime.MinValue)
                {
                    return "";
                }
                return this.ApproveTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
    }
    public partial class Mall_BusinessDiscountRequestDetail : Mall_BusinessDiscountRequest
    {
        [DatabaseColumn("BusinessName")]
        public string BusinessName { get; set; }
        public static Ui.DataGrid GetMall_BusinessDiscountRequestDetailGridList(string keywords, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            string OrderBy = " order by AddTime desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([BusinessName] like @keywords or [RequestContent] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "A.*";
            string Statement = " from (select [Mall_BusinessDiscountRequest].*,(select top 1 BusinessName from [Mall_Business] where [ID]=Mall_BusinessDiscountRequest.BusinessID) as BusinessName from [Mall_BusinessDiscountRequest])A where  " + string.Join(" and ", conditions.ToArray());
            Mall_BusinessDiscountRequestDetail[] list = GetList<Mall_BusinessDiscountRequestDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
