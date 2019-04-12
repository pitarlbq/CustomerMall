using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;
using System.Web.Script.Serialization;
using Foresight.DataAccess.Framework;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using Foresight.DataAccess;
using Utility;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace Web
{
    public static class EncryptHelper
    {
        public static string GetURL(HttpContext context)
        {
            string key = context.Request["key"];
            if (!string.IsNullOrEmpty(key))
            {
                if (key.ToLower().StartsWith("http://") || key.ToLower().StartsWith("https://"))
                {
                    return key;
                }
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["DES"]))
                {
                    string sKey = "saasyy20";
                    byte[] inputByteArray = Convert.FromBase64String(key);
                    using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                    {
                        des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                        des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(inputByteArray, 0, inputByteArray.Length);
                            cs.FlushFinalBlock();
                            cs.Close();
                        }
                        string str = Encoding.UTF8.GetString(ms.ToArray());
                        ms.Close();
                        return str;
                    }
                }
                else
                {
                    try
                    {
                        System.Web.Security.FormsAuthenticationTicket ticket = System.Web.Security.FormsAuthentication.Decrypt(key);
                        if (ticket != null)
                        {
                            return ticket.Name;
                        }
                        else
                        {
                            return key;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteError("Foresight.Web.WebUtil", "Decrpty URL fail.", ex);
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }
        public static bool IsInternalSys(out string errormsg, bool includedemo = true)
        {
            Company company = null;
            return IsInternalSys(out errormsg, out company, includedemo);
        }
        public static bool IsInternalSys(out string errormsg, out Company company, bool includedemo = true)
        {
            var siteConfig = new Utility.SiteConfig();
            errormsg = string.Empty;
            company = null;
            string requestURL = WebUtil.GetContextPath();
            if (siteConfig.IsDemoSite && includedemo)
            {
                errormsg = "内部系统，无须审核";
                company = Foresight.DataAccess.Company.GetCompanies().Where(p => p.BaseURL.Contains(WebUtil.GetContextPath())).FirstOrDefault();
                return true;
            }
            if (siteConfig.IsAdminSite)
            {
                errormsg = "内部系统，无须审核";
                company = Foresight.DataAccess.Company.GetCompanies().Where(p => p.BaseURL.Contains(WebUtil.GetContextPath())).FirstOrDefault();
                return true;
            }
            if (requestURL.Contains("http://localhost"))
            {
                company = Foresight.DataAccess.Company.GetCompanies().FirstOrDefault();
                errormsg = "本地系统，测试使用";
                return true;
            }
            return false;
        }
        public static bool DoUpgradeSite(Foresight.DataAccess.Company company, List<Utility.SiteVersionModel> list, int VersionCode, out string errormsg)
        {
            errormsg = string.Empty;
            if (IsLocalSystem())
            {
                errormsg = "局域网单机系统无法升级";
                return false;
            }
            string apiurl = company.BaseURL + "/upgrade/api/api.ashx";
            ResponseData response = null;
            int i = 0;
            do
            {
                try
                {
                    i++;
                    string key = EncriptName(company.BaseURL);
                    string result = Foresight.Web.HttpRequest.Post(null, new Dictionary<string, string>() { { "action", "doupgrade" }, { "VersionCode", VersionCode.ToString() }, { "versions", JsonConvert.SerializeObject(list) } }, apiurl: apiurl);
                    response = JsonConvert.DeserializeObject<ResponseData>(result);
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("EncryptHelper", "DoUpgradeSite", ex);
                }

            } while (response == null && i <= 3);
            if (response != null)
            {
                errormsg = response.errormsg;
                return response.status;
            }
            errormsg = "操作超时，请稍候重试";
            return false;
        }
        public static bool SaveAPPUser(Foresight.DataAccess.Company company, string LoginName, string Password, int FromUserID, string UserType, out string errormsg)
        {
            errormsg = string.Empty;
            if (IsLocalSystem())
            {
                errormsg = "局域网单机系统无法保存APP用户";
                return false;
            }
            if (IsInternalSys(out errormsg, false))
            {
                errormsg = "内部系统，无须审核";
                return true;
            }
            ResponseData response = null;
            int i = 0;
            do
            {
                try
                {
                    i++;
                    string key = EncriptName(company.BaseURL);
                    string result = Foresight.Web.HttpRequest.Post(null, new Dictionary<string, string>() { { "visit", "saveappuser" }, { "key", key }, { "signature", SysConfig.GetSignature() }, { "token", SysConfig.GetToken() }, { "LoginName", LoginName }, { "Password", Password }, { "FromUserID", FromUserID.ToString() }, { "UserType", UserType } });
                    response = JsonConvert.DeserializeObject<ResponseData>(result);
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("EncryptHelper", "SaveAPPUser", ex);
                }

            } while (response == null && i <= 3);
            if (response != null)
            {
                errormsg = response.errormsg;
                return response.status;
            }
            errormsg = "操作超时，请稍候重试";
            return false;
        }
        public static bool SaveCompany(Foresight.DataAccess.Company company, out string errormsg)
        {
            errormsg = string.Empty;
            if (IsLocalSystem())
            {
                return Web.APPCode.SqlLiteHelper.SaveCompany(company, out errormsg);
            }
            if (IsInternalSys(out errormsg, false))
            {
                errormsg = "内部系统，无须审核";
                return true;
            }
            ResponseData response = null;
            int i = 0;
            do
            {
                try
                {
                    i++;
                    string key = EncriptName(company.BaseURL);
                    string result = Foresight.Web.HttpRequest.Post(null, new Dictionary<string, string>() { { "visit", "savecompanyinfo" }, { "key", key }, { "signature", SysConfig.GetSignature() }, { "token", SysConfig.GetToken() }, { "CompanyName", company.CompanyName }, { "Address", company.Address }, { "PhoneNumber", company.PhoneNumber }, { "CompanyDesc", company.CompanyDesc }, { "ChargePerson", company.ChargePerson } });
                    response = JsonConvert.DeserializeObject<ResponseData>(result);
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("EncryptHelper", "SaveCompany", ex);
                }

            } while (response == null && i <= 3);
            if (response != null)
            {
                errormsg = response.errormsg;
                return response.status;
            }
            errormsg = "操作超时，请稍候重试";
            return false;
        }
        public static bool GetCompanyInfo(string BaseURL, int FromCompanyID, out string errormsg, out Foresight.DataAccess.Company company, bool includedemo = true)
        {
            company = null;
            errormsg = string.Empty;
            if (IsInternalSys(out errormsg, out company, includedemo))
            {
                return true;
            }
            if (IsLocalSystem())
            {
                return Web.APPCode.SqlLiteHelper.GetCompanyInfo(BaseURL, FromCompanyID, out errormsg, out company, includedemo: includedemo);
            }
            ResponseCompany response = null;
            int i = 0;
            do
            {
                try
                {
                    i++;
                    string key = EncriptName(BaseURL);
                    string result = Foresight.Web.HttpRequest.Get(new Dictionary<string, string>() { { "visit", "getcompanyinfo" }, { "key", key }, { "signature", SysConfig.GetSignature() }, { "token", SysConfig.GetToken() } });
                    response = JsonConvert.DeserializeObject<ResponseCompany>(result);
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("EncryptHelper", "GetCompanyInfo", ex);
                }

            } while (response == null && i <= 3);
            if (response != null)
            {
                company = response.company;
                errormsg = response.errormsg;
                return response.status;
            }
            errormsg = "操作超时，请稍候重试";
            return false;
        }
        public static bool CheckCompany(string BaseURL, int FromCompanyID, out string errormsg)
        {
            errormsg = string.Empty;
            if (IsLocalSystem())
            {
                return Web.APPCode.SqlLiteHelper.CheckCompany(BaseURL, FromCompanyID, out errormsg);
            }
            if (IsInternalSys(out errormsg, false))
            {
                return true;
            }
            ResponseData response = null;
            int i = 0;
            do
            {
                try
                {
                    i++;
                    string key = EncriptName(BaseURL);
                    string result = Foresight.Web.HttpRequest.Get(new Dictionary<string, string>() { { "visit", "checkcompany" }, { "key", key }, { "signature", SysConfig.GetSignature() }, { "token", SysConfig.GetToken() } });
                    response = JsonConvert.DeserializeObject<ResponseData>(result);
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("EncryptHelper", "CheckCompany", ex);
                }

            } while (response == null && i <= 3);
            if (response != null)
            {
                errormsg = response.errormsg;
                return response.status;
            }
            errormsg = "操作超时，请稍候重试";
            return false;
        }
        public static bool RegisterCompany(string BaseURL, string CompanyName, string PhoneNumber, string LoginName, string Password, out string errormsg)
        {
            if (IsLocalSystem())
            {
                errormsg = "局域网单机系统无法注册";
                return false;
            }
            ResponseData response = null;
            int i = 0;
            do
            {
                try
                {
                    i++;
                    string key = EncriptName(BaseURL);
                    string result = Foresight.Web.HttpRequest.Get(new Dictionary<string, string>() { { "visit", "registercompany" }, { "key", key }, { "signature", SysConfig.GetSignature() }, { "token", SysConfig.GetToken() }, { "CompanyName", CompanyName }, { "PhoneNumber", PhoneNumber }, { "LoginName", LoginName }, { "Password", Password } });
                    response = JsonConvert.DeserializeObject<ResponseData>(result);
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("EncryptHelper", "RegisterCompany", ex);
                }
            } while (response == null && i <= 3);
            if (response != null)
            {
                errormsg = response.errormsg;
                return response.status;
            }
            errormsg = "操作超时，请稍候重试";
            return false;
        }
        public static bool RemoveAPPUser(Foresight.DataAccess.Company company, List<int> UserIDList, out string errormsg)
        {
            errormsg = string.Empty;
            if (IsLocalSystem())
            {
                errormsg = "局域网单机系统无法删除APP用户";
                return false;
            }
            if (IsInternalSys(out errormsg, false))
            {
                errormsg = "内部系统，无须审核";
                return true;
            }
            ResponseData response = null;
            int i = 0;
            do
            {
                try
                {
                    i++;
                    string key = EncriptName(company.BaseURL);
                    string result = Foresight.Web.HttpRequest.Post(null, new Dictionary<string, string>() { { "visit", "removeappuser" }, { "key", key }, { "signature", SysConfig.GetSignature() }, { "token", SysConfig.GetToken() }, { "UserIDList", JsonConvert.SerializeObject(UserIDList) } });
                    response = JsonConvert.DeserializeObject<ResponseData>(result);
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("EncryptHelper", "RemoveAPPUser", ex);
                }

            } while (response == null && i <= 3);
            if (response != null)
            {
                errormsg = response.errormsg;
                return response.status;
            }
            errormsg = "操作超时，请稍候重试";
            return false;
        }
        private static string EncriptName(string Name)
        {
            var config = new Utility.SiteConfig();
            string EncriptURL = config.EncriptURL;
            if (!string.IsNullOrEmpty(EncriptURL) && EncriptURL.Equals("0"))
            {
                return Name;
            }
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["DES"]))
            {
                string sKey = "saasyy20";
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    byte[] inputByteArray = Encoding.UTF8.GetBytes(Name);
                    des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                    des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        cs.Close();
                    }
                    string str = Convert.ToBase64String(ms.ToArray());
                    ms.Close();
                    return str;
                }
            }
            else
            {
                System.Web.Security.FormsAuthenticationTicket ticket = new System.Web.Security.FormsAuthenticationTicket(1, Name, DateTime.Now, DateTime.Now.AddMinutes(10), true, string.Empty);
                string key = System.Web.Security.FormsAuthentication.Encrypt(ticket);
                return key;
            }
        }
        public static bool GetSysMenuList(string BaseURL, int FromCompanyID, out string errormsg, out Foresight.DataAccess.SysMenu[] list)
        {
            list = new SysMenu[] { };
            if (IsLocalSystem())
            {
                return Web.APPCode.SqlLiteHelper.GetSysMenuList(BaseURL, FromCompanyID, out errormsg, out list);
            }
            if (IsInternalSys(out errormsg, false))
            {
                errormsg = "内部系统，无须审核";
                return true;
            }
            ResponseSysMenu response = null;
            int i = 0;
            do
            {
                try
                {
                    i++;
                    string key = EncriptName(BaseURL);
                    string result = Foresight.Web.HttpRequest.Get(new Dictionary<string, string>() { { "visit", "getsysmenulist" }, { "key", key }, { "signature", SysConfig.GetSignature() }, { "token", SysConfig.GetToken() } });
                    response = JsonConvert.DeserializeObject<ResponseSysMenu>(result);
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("EncryptHelper", "GetSysMenuList", ex);
                }

            } while (response == null && i <= 3);
            if (response != null)
            {
                list = response.list;
                errormsg = response.errormsg;
                return response.status;
            }
            errormsg = "操作超时，请稍候重试";
            return false;
        }
        private static bool IsLocalSystem()
        {
            var config = new Utility.SiteConfig();
            return Convert.ToBoolean(config.IsLocalSite);
        }
    }
    public class ResponseData
    {
        public bool status { get; set; }
        public string errormsg { get; set; }
    }
    public class ResponseCompany : ResponseData
    {
        public Foresight.DataAccess.Company company { get; set; }
    }
    public class ResponseSysMenu : ResponseData
    {
        public Foresight.DataAccess.SysMenu[] list { get; set; }
    }
}
