using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// config 的摘要说明
/// </summary>
public class WeixinConfig
{
    public WeixinConfig()
    {
    }
    public static string notify_url = Web.WebUtil.GetContextPath() + "/recive/wx/paycallback.aspx";
    public static string app_notify_url = Web.WebUtil.GetContextPath() + "/recive/wx/paycallbackapp.aspx";
    public static string app_chongzhi_notify_url = Web.WebUtil.GetContextPath() + "/recive/wx/paycallbackchongzhi.aspx";
}