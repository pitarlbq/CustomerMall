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
    /// This object represents the properties and methods of a Mall_OrderComment.
    /// </summary>
    public partial class Mall_OrderComment : EntityBase
    {
        public static Mall_OrderComment[] GetMall_OrderCommentListByUserID(int UserID, int OrderID, int ProductID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (UserID == 0 && OrderID == 0 && ProductID == 0)
            {
                return new Mall_OrderComment[] { };
            }
            if (UserID > 0)
            {
                conditions.Add("[UserID]=@UserID");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            if (OrderID > 0)
            {
                conditions.Add("[OrderID]=@OrderID");
                parameters.Add(new SqlParameter("@OrderID", OrderID));
            }
            if (ProductID > 0)
            {
                conditions.Add("[ProductID]=@ProductID");
                parameters.Add(new SqlParameter("@ProductID", ProductID));
            }
            string Statement = @"select * from Mall_OrderComment where " + string.Join(" and ", conditions);
            return GetList<Mall_OrderComment>(Statement, parameters).ToArray();
        }
        public static Mall_OrderComment[] GetMall_OrderCommentListByOrderIDList(List<int> OrderIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (OrderIDList.Count == 0)
            {
                return new Mall_OrderComment[] { };
            }
            conditions.Add("[OrderID] in (" + string.Join(",", OrderIDList.ToArray()) + ")");
            string Statement = @"select * from Mall_OrderComment where " + string.Join(" and ", conditions);
            return GetList<Mall_OrderComment>(Statement, parameters).ToArray();
        }
        public string RateStarDesc
        {
            get
            {
                if (this.RateStar <= 0)
                {
                    return "";
                }
                return this.RateStar.ToString("0") + "星";
            }
        }
    }
    public partial class Mall_OrderCommentDetail : Mall_OrderComment
    {
        [DatabaseColumn("NickName")]
        public string NickName { get; set; }
        [DatabaseColumn("HeadImg")]
        public string HeadImg { get; set; }
        [DatabaseColumn("PhoneNumber")]
        public string PhoneNumber { get; set; }
        [DatabaseColumn("OrderNumber")]
        public string OrderNumber { get; set; }
        [DatabaseColumn("TotalPoint")]
        public int TotalPoint { get; set; }
        public static Mall_OrderCommentDetail[] GetMall_OrderCommentDetailListByProductID(int ProductID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (ProductID == 0)
            {
                return new Mall_OrderCommentDetail[] { };
            }
            conditions.Add("[ProductID]=@ProductID");
            parameters.Add(new SqlParameter("@ProductID", ProductID));
            string Statement = @"select *,(select NickName from [User] where [User].UserID=Mall_OrderComment.UserID) as NickName,(select HeadImg from [User] where [User].UserID=Mall_OrderComment.UserID) as HeadImg from Mall_OrderComment where " + string.Join(" and ", conditions);
            return GetList<Mall_OrderCommentDetail>(Statement, parameters).ToArray();
        }
        public static Ui.DataGrid GetMall_OrderCommentDetailGridByKeywords(string Keywords, long startRowIndex, int pageSize)
        {
            string OrderBy = " order by [AddTime] desc";
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([ProductName] like @Keywords or [ModelNumber] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "A.*";
            string Statement = " from (select *,(select NickName from [User] where [User].UserID=[Mall_OrderComment].UserID) as NickName,(select PhoneNumber from [User] where [User].UserID=[Mall_OrderComment].UserID) as PhoneNumber,(select OrderNumber from [Mall_Order] where [Mall_Order].ID=[Mall_OrderComment].OrderID) as OrderNumber,(select Sum(PointValue) from [Mall_UserPoint] where [Mall_UserPoint].RelatedID=[Mall_OrderComment].OrderID and CategoryType in (2,4)) as TotalPoint from [Mall_OrderComment])A where  " + string.Join(" and ", conditions.ToArray());
            Mall_OrderCommentDetail[] list = GetList<Mall_OrderCommentDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
