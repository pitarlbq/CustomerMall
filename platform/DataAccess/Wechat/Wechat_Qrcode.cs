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
	/// This object represents the properties and methods of a Wechat_Qrcode.
	/// </summary>
	public partial class Wechat_Qrcode : EntityBase
	{
        public static Wechat_Qrcode GetWechat_QrcodeByPageURL(string QrCodeURL)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            parameters.Add(new SqlParameter("@QrCodeURL", QrCodeURL));
            conditions.Add("[QrCodeURL]=@QrCodeURL");

            return GetOne<Wechat_Qrcode>("select top 1 * from [" + TableName + "] where " + string.Join(" and ", conditions.ToArray()) + " order by [ID] desc", parameters);
        }
	}
}
