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
    /// This object represents the properties and methods of a Wechat_HouseServiceType.
    /// </summary>
    public partial class Wechat_HouseServiceType : EntityBase
    {
        public static Wechat_HouseServiceType[] GetWechat_HouseServiceTypeListByServiceID(int ServiceID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ServiceID <= 0)
            {
                return new Wechat_HouseServiceType[] { };
            }
            conditions.Add("[ServiceID]=@ServiceID");
            parameters.Add(new SqlParameter("@ServiceID", ServiceID));
            string Statement = "select * from [Wechat_HouseServiceType] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Wechat_HouseServiceType>(Statement, parameters).ToArray();
        }
    }
    public partial class Wechat_HouseServiceTypeDetail : Wechat_HouseServiceType
    {
        [DatabaseColumn("CoverImage")]
        public string CoverImage { get; set; }
        public static Wechat_HouseServiceTypeDetail[] Get_Wechat_HouseServiceTypeList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            string Statement = "select *,(select [IconLink] from [Wechat_HouseService] where ID=Wechat_HouseServiceType.ServiceID) as CoverImage from [Wechat_HouseServiceType]";
            return GetList<Wechat_HouseServiceTypeDetail>(Statement, parameters).ToArray();
        }
    }
}
