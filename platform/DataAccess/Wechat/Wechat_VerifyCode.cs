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
    /// This object represents the properties and methods of a Wechat_VerifyCode.
    /// </summary>
    public partial class Wechat_VerifyCode : EntityBase
    {
        public static Wechat_VerifyCode GetWechat_VerifyCodeByUserOpenId(string OpenID, string MobilePhone, DateTime now)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[SendStatus]=1");
            conditions.Add("isnull([IsUsed],0)=0");
            if (now > DateTime.MinValue)
            {
                conditions.Add("[ExpireTime]>=@ExpireTime");
                parameters.Add(new SqlParameter("@ExpireTime", now));
            }
            if (!string.IsNullOrEmpty(OpenID))
            {
                conditions.Add("[OpenID]=@OpenID");
                parameters.Add(new SqlParameter("@OpenID", OpenID));
            }
            conditions.Add("[MobilePhone]=@MobilePhone");
            parameters.Add(new SqlParameter("@MobilePhone", MobilePhone));
            return GetOne<Wechat_VerifyCode>("select top 1 * from [Wechat_VerifyCode] where " + string.Join(" and ", conditions.ToArray()) + " order by [ID] desc", parameters);
        }
        public static void SaveWechatVerifyCode(string MobilePhone, string VerifyCode, bool SendStatus = true, string SendResult = "", string OpenID = "")
        {
            Foresight.DataAccess.Wechat_VerifyCode code = Foresight.DataAccess.Wechat_VerifyCode.GetWechat_VerifyCodeByUserOpenId(OpenID, MobilePhone, DateTime.Now);
            if (code == null)
            {
                code = new Foresight.DataAccess.Wechat_VerifyCode();
            }
            code.AddTime = DateTime.Now;
            code.MobilePhone = MobilePhone;
            code.VerifyCode = VerifyCode;
            code.ExpireTime = DateTime.Now.AddMinutes(15);
            code.SendStatus = SendStatus;
            code.SendResult = SendResult;
            code.OpenID = OpenID;
            code.IsUsed = false;
            code.Save();
        }
    }
}
