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
    /// This object represents the properties and methods of a SystemMsg_Company.
    /// </summary>
    public partial class SystemMsg_Company : EntityBase
    {
        public static SystemMsg_Company[] GetSystemMsg_CompanyListByCompanyID(int CompanyID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdwhere = string.Empty;
            if (CompanyID == 0)
            {
                return new SystemMsg_Company[] { };
            }
            cmdwhere += " and [CompanyID]=@CompanyID";
            parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            return GetList<SystemMsg_Company>("select * from [SystemMsg_Company] where 1=1 " + cmdwhere, parameters).ToArray();
        }
        public static SystemMsg_Company[] GetSystemMsg_CompanyList(int SystemMsgID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdwhere = string.Empty;
            if (SystemMsgID > 0)
            {
                cmdwhere += " and [SystemMsgID]=@SystemMsgID";
                parameters.Add(new SqlParameter("@SystemMsgID", SystemMsgID));
            }
            return GetList<SystemMsg_Company>("select * from [SystemMsg_Company] where 1=1 " + cmdwhere, parameters).ToArray();
        }
        public static SystemMsg_Company[] GetReadSystemMsg_CompanyList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdwhere = " and isnull([IsReading],0)=1";
            return GetList<SystemMsg_Company>("select * from [SystemMsg_Company] where 1=1 " + cmdwhere, parameters).ToArray();
        }
    }
}
