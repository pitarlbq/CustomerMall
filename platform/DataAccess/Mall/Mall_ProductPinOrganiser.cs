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
    /// This object represents the properties and methods of a Mall_ProductPinOrganiser.
    /// </summary>
    public partial class Mall_ProductPinOrganiser : EntityBase
    {
        public static Mall_ProductPinOrganiser GetMall_ProductPinOrganiserByProductID(int ProductID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[Status]=1");
            if (ProductID <= 0)
            {
                return new Mall_ProductPinOrganiser();
            }
            conditions.Add("[ProductID]=@ProductID");
            parameters.Add(new SqlParameter("@ProductID", ProductID));
            string cmdtext = "select top 1 * from [Mall_ProductPinOrganiser] where " + string.Join(" and ", conditions.ToArray()) + " order by ID desc";
            return GetOne<Mall_ProductPinOrganiser>(cmdtext, parameters);
        }
    }
    public partial class Mall_ProductPinOrganiserDetail : Mall_ProductPinOrganiser
    {
        [DatabaseColumn("UserName")]
        public string UserName { get; set; }
        [DatabaseColumn("WaitPayCount")]
        public int WaitPayCount { get; set; }
        [DatabaseColumn("PaidCount")]
        public int PaidCount { get; set; }
        [DatabaseColumn("CloseCount")]
        public int CloseCount { get; set; }
        /// <summary>
        /// 1-进行中 2-待付款 3-已全部付款 4-已关闭 5-已部分付款
        /// </summary>
        public int FinalStatus
        {
            get
            {
                if (this.Status == 4)
                {
                    return 4;
                }
                if (PaidCount > 0)
                {
                    if (WaitPayCount > 0)
                    {
                        return 5;
                    }
                    return 3;
                }
                if (WaitPayCount > 0)
                {
                    return 2;
                }
                if (this.CloseCount > 0)
                {
                    return 4;
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
                        desc = "已全部付款";
                        break;
                    case 4:
                        desc = "已关闭";
                        break;
                    case 5:
                        desc = "已部分付款";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public static Mall_ProductPinOrganiserDetail[] GetMall_ProductPinOrganiserDetailListByProductID(int ProductID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ProductID > 0)
            {
                conditions.Add("[ProductID]=@ProductID");
                parameters.Add(new SqlParameter("@ProductID", ProductID));
            }
            string cmdtext = "select *,(select LoginName from [User] where [User].UserID=[Mall_ProductPinOrganiser].UserID) as UserName,(select count(1) from [Mall_Order] where [Mall_Order].[Pin_OrganiserID]=[Mall_ProductPinOrganiser].ID and [OrderStatus]=1) as WaitPayCount,(select count(1) from [Mall_Order] where [Mall_Order].[Pin_OrganiserID]=[Mall_ProductPinOrganiser].ID and [OrderStatus]!=1 and [OrderStatus]!=4) as PaidCount,(select count(1) from [Mall_Order] where [Mall_Order].[Pin_OrganiserID]=[Mall_ProductPinOrganiser].ID and [IsClosed]=1) as CloseCount from [Mall_ProductPinOrganiser] where " + string.Join(" and ", conditions.ToArray()) + " order by ID desc";
            return GetList<Mall_ProductPinOrganiserDetail>(cmdtext, parameters).ToArray();
        }
        public static Mall_ProductPinOrganiserDetail GetMall_ProductPinOrganiserDetail(int ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID]=@ID");
            parameters.Add(new SqlParameter("@ID", ID));
            string cmdtext = "select *,(select count(1) from [Mall_Order] where [Mall_Order].[Pin_OrganiserID]=[Mall_ProductPinOrganiser].ID and [OrderStatus]=1) as WaitPayCount,(select count(1) from [Mall_Order] where [Mall_Order].[Pin_OrganiserID]=[Mall_ProductPinOrganiser].ID and [OrderStatus]!=1 and [OrderStatus]!=4) as PaidCount,(select count(1) from [Mall_Order] where [Mall_Order].[Pin_OrganiserID]=[Mall_ProductPinOrganiser].ID and [IsClosed]=1) as CloseCount from [Mall_ProductPinOrganiser] where " + string.Join(" and ", conditions.ToArray());
            return GetOne<Mall_ProductPinOrganiserDetail>(cmdtext, parameters);
        }
    }
}
