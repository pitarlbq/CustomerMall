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
    /// This object represents the properties and methods of a Wechat_ChatRequest.
    /// </summary>
    public partial class Wechat_ChatRequest : EntityBase
    {
        public static bool SaveWechat_ChatRequestByUserID(int UserID, int ID, SqlHelper helper)
        {
            if (UserID <= 0)
            {
                return false;
            }
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserID", UserID));
            parameters.Add(new SqlParameter("@ID", ID));
            int count = helper.Execute("update Wechat_ChatRequest set [UserID]=@UserID,[AcceptTime]=getdate() where ID=@ID and UserID is null", CommandType.Text, parameters);
            return count > 0;
        }
        public static Wechat_ChatRequest GetUnGrabRequest(SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var data = GetOne<Wechat_ChatRequest>("select top 1 * from [Wechat_ChatRequest] where [UserID] is null", parameters, helper);
            return data;

        }
        public static Wechat_ServiceUser GetWechat_ServiceUserByUserID(int UserID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetWechat_ServiceUserByUserID(UserID, helper);
            }
        }
        public static Wechat_ServiceUser GetWechat_ServiceUserByUserID(int UserID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserID", UserID));
            var data = GetOne<Wechat_ServiceUser>("select top 1 * from [Wechat_ServiceUser] where [UserID]=@UserID", parameters, helper);
            return data;

        }
        public static int GetWechat_ChatRequestReadyCount()
        {
            using (SqlHelper helper = new SqlHelper())
            {
                var obj = helper.ExecuteScalar("select count(1) from [Wechat_ChatRequest] where [UserID] is null", CommandType.Text, new List<SqlParameter>());
                if (obj != null)
                {
                    return Convert.ToInt32(obj);
                }
            }
            return 0;
        }
        public static Wechat_ChatRequest CreateWechat_ChatRequestByOpenID(string OpenID)
        {
            if (string.IsNullOrEmpty(OpenID))
            {
                return null;
            }
            var data = new Wechat_ChatRequest();
            data.OpenID = OpenID;
            data.AddTime = DateTime.Now;
            data.Save();
            return data;
        }
        public static bool CheckCanChatStatus()
        {
            bool canchat = SysMenu.CheckSysModulesForUserByUserId(0, ModuleCode: "1191501");
            if (!canchat)
            {
                return false;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                string Name = SysConfigNameDefine.WechatChatStartTime.ToString();
                var start = SysConfig.GetSysConfigByName(Name, helper);
                if (start == null)
                {
                    return false;
                }
                Name = SysConfigNameDefine.WechatChatEndTime.ToString();
                var end = SysConfig.GetSysConfigByName(Name, helper);
                if (end == null)
                {
                    return false;
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(DateTime.Today.ToString("yyyy-MM-dd") + " " + start.Value, out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(DateTime.Today.ToString("yyyy-MM-dd") + " " + end.Value, out EndTime);
                if (StartTime > DateTime.Now)
                {
                    return false;
                }
                if (EndTime < DateTime.Now)
                {
                    return false;
                }
                return true;
            }
        }
        public static void SaveWechat_Config_Path(string VirName, Dictionary<string, object> dic)
        {
            var siteconfig = new Utility.SiteConfig();
            string ConfigPath = siteconfig.Wechat_SitePath + VirName + @"\weixin\Web.config";
            if (!System.IO.File.Exists(ConfigPath))
            {
                ConfigPath = siteconfig.Wechat_SitePath + @"weixin\Web.config";
            }
            if (!System.IO.File.Exists(ConfigPath))
            {
                ConfigPath = siteconfig.Wechat_SitePath + @"Web.config";
            }
            if (System.IO.File.Exists(ConfigPath))
            {
                Utility.IISManager.UpdateConfigValue(ConfigPath, dic);
            }
        }
        public bool CanAccept
        {
            get
            {
                if (this.UserID > 0)
                {
                    return false;
                }
                if (this.AddTime.AddDays(1) < DateTime.Now)
                {
                    return false;
                }
                return true;
            }
        }
    }
    public partial class Wechat_ChatRequestDetail : Wechat_ChatRequest
    {
        [DatabaseColumn("NickName")]
        public string NickName { get; set; }
        [DatabaseColumn("UserName")]
        public string UserName { get; set; }
        public static Ui.DataGrid GetWechat_ChatRequestDetailGridByKeywords(string Keywords, DateTime StartTime, DateTime EndTime, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([Title] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[AddTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[AddTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            string fieldList = "A.*";
            string Statement = " from (select [Wechat_ChatRequest].*,(select top 1 [NickName] from [Wechat_User] where [OpenId]=[Wechat_ChatRequest].OpenID) as NickName,(select top 1 [LoginName] from [User] where [UserID]=[Wechat_ChatRequest].UserID) as UserName from [Wechat_ChatRequest]) A where  " + string.Join(" and ", conditions.ToArray());
            Wechat_ChatRequestDetail[] list = GetList<Wechat_ChatRequestDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
