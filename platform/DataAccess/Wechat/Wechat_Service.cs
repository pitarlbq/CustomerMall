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
    /// This object represents the properties and methods of a Wechat_Service.
    /// </summary>
    public partial class Wechat_Service : EntityBase
    {

        public string ServiceTypeDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.ServiceType))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatServiceType), this.ServiceType);
            }
        }
        public string ServiceFromDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.ServiceFrom))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatServiceFromDefine), this.ServiceFrom);
            }
        }
    }
    public partial class Wechat_ServiceDetail : Wechat_Service
    {
        [DatabaseColumn("RoomFullName")]
        public string RoomFullName { get; set; }
        [DatabaseColumn("RoomName")]
        public string RoomName { get; set; }
        [DatabaseColumn("NickName")]
        public string NickName { get; set; }
        public static Ui.DataGrid GeWechat_ServiceGridByKeywords(string Keywords, string ServiceType, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([ServiceContent] like @Keywords or [PhoneNumber] like @Keywords or [OpenID] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (!string.IsNullOrEmpty(ServiceType))
            {
                conditions.Add("[ServiceType]=@ServiceType");
                parameters.Add(new SqlParameter("@ServiceType", ServiceType));
            }
            string fieldList = "[Wechat_Service].*,(select [FullName] from [Project] where [Project].ID=[Wechat_Service].RoomID) as RoomFullName,(select [Name] from [Project] where [Project].ID=[Wechat_Service].RoomID) as RoomName,(select [NickName] from [Wechat_User] where [Wechat_Service].OpenID=[Wechat_User].OpenID) as NickName";
            string Statement = " from [Wechat_Service] where " + string.Join(" and ", conditions.ToArray());
            Wechat_ServiceDetail[] list = GetList<Wechat_ServiceDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
