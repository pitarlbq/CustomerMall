using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Encript;
using Utility;

namespace Web.APPCode
{
    public class SqlLiteHelper
    {
        public static Foresight.DataAccess.Company GetSQLCompany(string BaseURL, int FromCompanyID)
        {
            var company = GetSqlLiteCompany(BaseURL: BaseURL, FromCompanyID: FromCompanyID);
            if (company == null)
            {
                return null;
            }
            var my_company = new Foresight.DataAccess.Company();
            my_company.CompanyID = company.CompanyID;
            my_company.BaseURL = company.BaseURL;
            my_company.CompanyName = company.CompanyName;
            my_company.IsActive = company.IsActive;
            my_company.BaseURL = company.BaseURL;
            my_company.UserCount = company.UserCount;
            my_company.ServerStartTime = company.ServerStartTime;
            my_company.ServerEndTime = company.ServerEndTime;
            my_company.IsPay = company.IsPay;
            my_company.IsAdmin = company.IsAdmin;
            my_company.IsCustomer = company.IsCustomer;
            my_company.Login_LogImg = company.Login_LogImg;
            my_company.Login_BodyImg = company.Login_BodyImg;
            my_company.Home_LogoImg = company.Home_LogoImg;
            my_company.VersionCode = company.VersionCode;
            return my_company;
        }
        public static Encript.CompanyModel GetSqlLiteCompany(Foresight.DataAccess.Company company = null, string BaseURL = "", int FromCompanyID = 0)
        {
            if (company == null && string.IsNullOrEmpty(BaseURL))
            {
                return null;
            }
            BaseURL = company != null ? company.BaseURL : BaseURL;
            FromCompanyID = company != null ? company.CompanyID : FromCompanyID;
            var my_company = SqlLite.GetMyCompany(BaseURL, FromCompanyID);
            if (company == null)
            {
                return my_company;
            }
            if (my_company == null)
            {
                my_company = new Encript.CompanyModel();
                my_company.CompanyID = company.CompanyID;
                my_company.BaseURL = company.BaseURL;
                SqlLite.InsertCompany(my_company);
            }
            my_company.CompanyName = company.CompanyName;
            my_company.IsActive = company.IsActive;
            my_company.BaseURL = company.BaseURL;
            my_company.UserCount = company.UserCount;
            my_company.ServerStartTime = company.ServerStartTime;
            my_company.ServerEndTime = company.ServerEndTime;
            my_company.IsPay = company.IsPay;
            my_company.IsAdmin = company.IsAdmin;
            my_company.IsCustomer = company.IsCustomer;
            my_company.Login_LogImg = company.Login_LogImg;
            my_company.Login_BodyImg = company.Login_BodyImg;
            my_company.Home_LogoImg = company.Home_LogoImg;
            my_company.VersionCode = company.VersionCode;
            return my_company;
        }
        /// <summary>
        /// admin使用
        /// </summary>
        /// <param name="company"></param>
        /// <param name="errormsg"></param>
        /// <returns></returns>
        public static bool SaveCompany(Foresight.DataAccess.Company company, out string errormsg)
        {
            errormsg = string.Empty;
            try
            {
                //if (EncryptHelper.IsInternalSys(out errormsg, false))
                //{
                //    errormsg = "内部系统，无须审核";
                //    return true;
                //}
                Encript.CompanyModel my_company = GetSqlLiteCompany(company);
                if (my_company == null)
                {
                    errormsg = "公司不存在";
                    return false;
                }
                my_company.CompanyName = company.CompanyName;
                SqlLite.SaveCompany(my_company);
                errormsg = "成功";
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("SqlLiteHelper", "SaveCompany", ex);
                errormsg = "内部异常";
                return false;
            }
        }
        public static bool GetCompanyInfo(string BaseURL, int FromCompanyID, out string errormsg, out Foresight.DataAccess.Company company, bool includedemo = true)
        {
            company = null;
            errormsg = string.Empty;
            try
            {
                if (EncryptHelper.IsInternalSys(out errormsg, out company, includedemo))
                {
                    return true;
                }
                if (string.IsNullOrEmpty(BaseURL))
                {
                    return false;
                }
                company = GetSQLCompany(BaseURL, FromCompanyID);
                if (company == null)
                {
                    errormsg = "公司不存在";
                    return false;
                }
                errormsg = "成功";
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("SqlLiteHelper", "GetCompanyInfo", ex);
                errormsg = "内部异常";
                return false;
            }
        }
        public static bool CheckCompany(string BaseURL, int FromCompanyID, out string errormsg)
        {
            errormsg = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(BaseURL))
                {
                    errormsg = "公司域名不合法";
                    return false;
                }
                Foresight.DataAccess.Company company = GetSQLCompany(BaseURL, FromCompanyID);
                if (company == null)
                {
                    errormsg = "公司未登记";
                    return false;
                }
                if (company.IsAdmin)
                {
                    return true;
                }
                if (!company.IsPay)
                {
                    errormsg = "当前公司未付费，禁止登陆";
                    return false;
                }
                if (DateTime.Now < company.ServerStartTime || DateTime.Now > company.ServerEndTime)
                {
                    errormsg = "当前公司已超过使用期限，禁止登陆";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("SqlLiteHelper", "CheckCompany", ex);
                errormsg = "内部异常";
                return false;
            }
        }
        public static bool GetSysMenuList(string BaseURL, int FromCompanyID, out string errormsg, out Foresight.DataAccess.SysMenu[] list)
        {
            errormsg = string.Empty;
            list = new Foresight.DataAccess.SysMenu[] { };
            try
            {
                Encript.CompanyModel my_company = GetSqlLiteCompany(BaseURL: BaseURL, FromCompanyID: FromCompanyID);
                if (my_company == null)
                {
                    errormsg = "公司不存在";
                    return false;
                }
                Encript.CompanyModuleModel[] menu_list = Encript.SqlLite.GetCompanyModuleList(my_company);
                list = Foresight.DataAccess.SysMenu.GetSysModulesByIDList(menu_list.Select(p => p.ModuleID).ToList());
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("SqlLiteHelper", "GetSysMenuList", ex);
                errormsg = "内部异常";
                return false;
            }
        }
        public static bool SaveCompanyModule(Foresight.DataAccess.Company company, out string errormsg)
        {
            errormsg = string.Empty;
            try
            {
                var sys_menus = Foresight.DataAccess.SysMenu.GetSysModulesByCompany(company.CompanyID);
                List<CompanyModuleModel> modellist = new List<CompanyModuleModel>();
                foreach (var item in sys_menus)
                {
                    Encript.CompanyModuleModel model = new CompanyModuleModel();
                    model.CompanyID = company.CompanyID;
                    model.ModuleID = item.ID;
                    modellist.Add(model);
                }
                Encript.SqlLite.InsertCompanyModule(modellist.ToArray(), company.CompanyID);
                errormsg = "";
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("SqlLiteHelper", "SaveCompanyModule", ex);
                errormsg = "内部异常";
                return false;
            }
        }
    }
}