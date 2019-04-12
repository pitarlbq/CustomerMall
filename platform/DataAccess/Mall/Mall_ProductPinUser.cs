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
    /// This object represents the properties and methods of a Mall_ProductPinUser.
    /// </summary>
    public partial class Mall_ProductPinUser : EntityBase
    {
        public static Mall_ProductPinUser[] GetMall_ProductPinUserListByOrganiserID(int OrganiserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (OrganiserID > 0)
            {
                conditions.Add("[OrganiserID]=@OrganiserID");
                parameters.Add(new SqlParameter("@OrganiserID", OrganiserID));
            }
            string cmdtext = "select * from [Mall_ProductPinUser] where " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_ProductPinUser>(cmdtext, parameters).ToArray();
        }
    }
    public partial class Mall_ProductPinUserDetail : Mall_ProductPinUser
    {
        [DatabaseColumn("NickName")]
        public string NickName { get; set; }
        [DatabaseColumn("PhoneNumber")]
        public string PhoneNumber { get; set; }
        [DatabaseColumn("VariantName")]
        public string VariantName { get; set; }
        [DatabaseColumn("OrderStatus")]
        public int OrderStatus { get; set; }
        [DatabaseColumn("IsClosed")]
        public bool IsClosed { get; set; }
        /// <summary>
        /// 1-进行中 2-待付款 3-已付款 4-已关闭
        /// </summary>
        public int FinalStatus
        {
            get
            {
                if (this.IsClosed)
                {
                    return 4;
                }
                else
                {
                    if (this.Status == 4)
                    {
                        return this.Status;
                    }
                    if (this.OrderStatus == 1)
                    {
                        return 2;
                    }
                    if (this.OrderStatus > 0)
                    {
                        return 3;
                    }
                }
                return this.Status;
            }
        }
        public string StatusDesc
        {
            get
            {
                string desc = string.Empty;
                switch (this.FinalStatus)
                {
                    case 1:
                        desc = "进行中";
                        break;
                    case 2:
                        desc = "待付款";
                        break;
                    case 3:
                        desc = "已付款";
                        break;
                    case 4:
                        desc = "已关闭";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public static Mall_ProductPinUserDetail[] GetMall_ProductPinUserDetailListByProductID(int ProductID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ProductID > 0)
            {
                conditions.Add("[ProductID]=@ProductID");
                parameters.Add(new SqlParameter("@ProductID", ProductID));
            }
            string cmdtext = "select A.* from (select [Mall_ProductPinUser].*,[User].[NickName],[User].LoginName as PhoneNumber,(select VariantName from [Mall_Product_Variant] where ID=[Mall_ProductPinUser].VariantID) as VariantName,(select OrderStatus from [Mall_Order] where [Mall_Order].[Pin_UserID]=[Mall_ProductPinUser].ID) as OrderStatus,(select IsClosed from [Mall_Order] where [Mall_Order].[Pin_UserID]=[Mall_ProductPinUser].ID) as IsClosed from [Mall_ProductPinUser] left join [User] on [User].UserID=Mall_ProductPinUser.UserID)A where " + string.Join(" and ", conditions.ToArray()) + " order by ID asc";
            return GetList<Mall_ProductPinUserDetail>(cmdtext, parameters).ToArray();
        }
        public static Mall_ProductPinUserDetail[] GetMall_ProductPinUserDetailListByOrganiserID(int OrganiserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (OrganiserID > 0)
            {
                conditions.Add("[OrganiserID]=@OrganiserID");
                parameters.Add(new SqlParameter("@OrganiserID", OrganiserID));
            }
            string cmdtext = "select *,(select OrderStatus from [Mall_Order] where [Mall_Order].[Pin_UserID]=[Mall_ProductPinUser].ID) as OrderStatus,(select IsClosed from [Mall_Order] where [Mall_Order].[Pin_UserID]=[Mall_ProductPinUser].ID) as IsClosed from [Mall_ProductPinUser] where " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_ProductPinUserDetail>(cmdtext, parameters).ToArray();
        }
        public static Mall_ProductPinUserDetail[] GetMall_ProductPinUserDetailByUserID(int UserID, int ProductID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (UserID == 0)
            {
                return new Mall_ProductPinUserDetail[] { };
            }
            conditions.Add("[UserID]=@UserID");
            conditions.Add("[ProductID]=@ProductID");
            parameters.Add(new SqlParameter("@UserID", UserID));
            parameters.Add(new SqlParameter("@ProductID", ProductID));
            string cmdtext = "select *,(select OrderStatus from [Mall_Order] where [Mall_Order].[Pin_UserID]=[Mall_ProductPinUser].ID) as OrderStatus,(select IsClosed from [Mall_Order] where [Mall_Order].[Pin_UserID]=[Mall_ProductPinUser].ID) as IsClosed from [Mall_ProductPinUser] where " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_ProductPinUserDetail>(cmdtext, parameters).ToArray();
        }
        public static int GetMall_ProductPinUserDetailCountByProductID(int ProductID)
        {
            var list = GetMall_ProductPinUserDetailListByProductID(ProductID);
            int count = list.Where(p => p.FinalStatus != 4).ToArray().Length;
            return count;
        }
        public static Mall_ProductPinUserDetail[] GetMall_ProductPinUserDetailList(List<int> ProductIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ProductIDList.Count == 0)
            {
                return new Mall_ProductPinUserDetail[] { };
            }
            conditions.Add("[ProductID] in (" + string.Join(",", ProductIDList.ToArray()) + ")");
            string cmdtext = "select *,(select OrderStatus from [Mall_Order] where [Mall_Order].[Pin_UserID]=[Mall_ProductPinUser].ID) as OrderStatus,(select IsClosed from [Mall_Order] where [Mall_Order].[Pin_UserID]=[Mall_ProductPinUser].ID) as IsClosed from [Mall_ProductPinUser] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_ProductPinUserDetail>(cmdtext, parameters).ToArray();
            return list.Where(p => p.FinalStatus != 4).ToArray();
        }
    }
}
