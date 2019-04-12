using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using Foresight.DataAccess.Ui;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Utility;
using Web.APPCode;
using WeiXin.Domain;
using WxPayAPI;
using WeiXin;
using Web.Model;

namespace Web.Handler
{
    /// <summary>
    /// WechatHandler 的摘要说明
    /// </summary>
    public class WechatHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("WechatHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "getwechatuserlist":
                        getwechatuserlist(context);
                        break;
                    case "tongbuwechatuser":
                        tongbuwechatuser(context);
                        break;
                    case "connectroom":
                        connectroom(context);
                        break;
                    case "loadroomresourcelist":
                        loadroomresourcelist(context);
                        break;
                    case "disconnectroom":
                        disconnectroom(context);
                        break;
                    case "viewqrcode":
                        viewqrcode(context);
                        break;
                    case "getroomfeebyopenid":
                        getroomfeebyopenid(context);
                        break;
                    case "getroomfeehistorybyopenid":
                        getroomfeehistorybyopenid(context);
                        break;
                    case "wxpayroomfeeready":
                        wxpayroomfeeready(context);
                        break;
                    case "getservicelist":
                        getservicelist(context);
                        break;
                    case "deleteservice":
                        deleteservice(context);
                        break;
                    case "wxpayroomfeecomplete":
                        wxpayroomfeecomplete(context);
                        break;
                    case "saveservice":
                        saveservice(context);
                        break;
                    case "saveyanshou":
                        saveyanshou(context);
                        break;
                    case "savezhuangxiu":
                        savezhuangxiu(context);
                        break;
                    case "checkphonestatus":
                        checkphonestatus(context);
                        break;
                    case "sendverifycode":
                        sendverifycode(context);
                        break;
                    case "wxconnectroom":
                        wxconnectroom(context);
                        break;
                    case "getmsglist":
                        getmsglist(context);
                        break;
                    case "savewechatmsg":
                        savewechatmsg(context);
                        break;
                    case "loadwechatmsgcover":
                        loadwechatmsgcover(context);
                        break;
                    case "deleteconver":
                        deleteconver(context);
                        break;
                    case "deletemsg":
                        deletemsg(context);
                        break;
                    case "getroomfeebyid":
                        getroomfeebyid(context);
                        break;
                    case "loadwechatcontactgrid":
                        loadwechatcontactgrid(context);
                        break;
                    case "removewechatcontact":
                        removewechatcontact(context);
                        break;
                    case "savewechatcontact":
                        savewechatcontact(context);
                        break;
                    case "getfeehistorybyprintid":
                        getfeehistorybyprintid(context);
                        break;
                    case "getroomlistbyopenid":
                        getroomlistbyopenid(context);
                        break;
                    case "cancelroombyroomid":
                        cancelroombyroomid(context);
                        break;
                    case "sendweixinmsg":
                        sendweixinmsg(context);
                        break;
                    case "huishouyinreadypay":
                        huishouyinreadypay(context);
                        break;
                    case "gethuishouyinstatus":
                        gethuishouyinstatus(context);
                        break;
                    case "getpayqrcode":
                        getpayqrcode(context);
                        break;
                    case "cancelsubscribe":
                        cancelsubscribe(context);
                        break;
                    case "savewechatmsguser":
                        savewechatmsguser(context);
                        break;
                    case "cancelwechatmsguser":
                        cancelwechatmsguser(context);
                        break;
                    case "getwechatprojects":
                        getwechatprojects(context);
                        break;
                    case "getweixinnotifytemplates":
                        getweixinnotifytemplates(context);
                        break;
                    case "removeweixinnotifytemplate":
                        removeweixinnotifytemplate(context);
                        break;
                    case "savewechatnotify":
                        savewechatnotify(context);
                        break;
                    case "getsurveytree":
                        getsurveytree(context);
                        break;
                    case "savewechatsurvey":
                        savewechatsurvey(context);
                        break;
                    case "removesurveys":
                        removesurveys(context);
                        break;
                    case "getsurveyquestiongrid":
                        getsurveyquestiongrid(context);
                        break;
                    case "getsurveyquestionoptions":
                        getsurveyquestionoptions(context);
                        break;
                    case "removesurveyquestionoption":
                        removesurveyquestionoption(context);
                        break;
                    case "savewechatsurveyquestion":
                        savewechatsurveyquestion(context);
                        break;
                    case "removesurveyquestion":
                        removesurveyquestion(context);
                        break;
                    case "getsurveyresponse":
                        getsurveyresponse(context);
                        break;
                    case "getlotteryactivitygrid":
                        getlotteryactivitygrid(context);
                        break;
                    case "savelotteryactivity":
                        savelotteryactivity(context);
                        break;
                    case "deletelotteryactivity":
                        deletelotteryactivity(context);
                        break;
                    case "getlotteryprizegrid":
                        getlotteryprizegrid(context);
                        break;
                    case "savelotteryprize":
                        savelotteryprize(context);
                        break;
                    case "deletelotteryprize":
                        deletelotteryprize(context);
                        break;
                    case "getlotteryprizerecord":
                        getlotteryprizerecord(context);
                        break;
                    case "getlotteryusergrid":
                        getlotteryusergrid(context);
                        break;
                    case "savelotteryuser":
                        savelotteryuser(context);
                        break;
                    case "deletelotteryuser":
                        deletelotteryuser(context);
                        break;
                    case "getlotterycheckergrid":
                        getlotterycheckergrid(context);
                        break;
                    case "savelotterychecker":
                        savelotterychecker(context);
                        break;
                    case "deletelotterychecker":
                        deletelotterychecker(context);
                        break;
                    case "getuserlisthasopenid":
                        getuserlisthasopenid(context);
                        break;
                    case "viewqrcodebyurl":
                        viewqrcodebyurl(context);
                        break;
                    case "getwechatbusinessgrid":
                        getwechatbusinessgrid(context);
                        break;
                    case "savewechatbusiness":
                        savewechatbusiness(context);
                        break;
                    case "deletewechatbusiness":
                        deletewechatbusiness(context);
                        break;
                    case "getrentareatree":
                        getrentareatree(context);
                        break;
                    case "saverentarea":
                        saverentarea(context);
                        break;
                    case "removerentarea":
                        removerentarea(context);
                        break;
                    case "getrenthomegrid":
                        getrenthomegrid(context);
                        break;
                    case "geteditrenthomeparams":
                        geteditrenthomeparams(context);
                        break;
                    case "getrenthometype":
                        getrenthometype(context);
                        break;
                    case "removerenthometype":
                        removerenthometype(context);
                        break;
                    case "saverenthome":
                        saverenthome(context);
                        break;
                    case "loadrenthomeattachs":
                        loadrenthomeattachs(context);
                        break;
                    case "deleterenthomefile":
                        deleterenthomefile(context);
                        break;
                    case "getrentrequestgrid":
                        getrentrequestgrid(context);
                        break;
                    case "gethouseservicecategorytree":
                        gethouseservicecategorytree(context);
                        break;
                    case "savewechathouseservicecategory":
                        savewechathouseservicecategory(context);
                        break;
                    case "removehouseservicecategory":
                        removehouseservicecategory(context);
                        break;
                    case "gethouseservicegrid":
                        gethouseservicegrid(context);
                        break;
                    case "gethouseservicetype":
                        gethouseservicetype(context);
                        break;
                    case "removehouseservicetype":
                        removehouseservicetype(context);
                        break;
                    case "savehouseservice":
                        savehouseservice(context);
                        break;
                    case "getedithouseserviceparams":
                        getedithouseserviceparams(context);
                        break;
                    case "loadhouseserviceattachs":
                        loadhouseserviceattachs(context);
                        break;
                    case "deletehouseservicefile":
                        deletehouseservicefile(context);
                        break;
                    case "removehouseservice":
                        removehouseservice(context);
                        break;
                    case "removerenthome":
                        removerenthome(context);
                        break;
                    case "savewechatsetup":
                        savewechatsetup(context);
                        break;
                    case "savewechatapppaysetup":
                        savewechatapppaysetup(context);
                        break;
                    case "savewechathtmlpageconfig":
                        savewechathtmlpageconfig(context);
                        break;
                    case "getmsgcategorygrid":
                        getmsgcategorygrid(context);
                        break;
                    case "savewechatmsgcategory":
                        savewechatmsgcategory(context);
                        break;
                    case "deletemsgcategory":
                        deletemsgcategory(context);
                        break;
                    case "loadvoteitemcoverimg":
                        loadvoteitemcoverimg(context);
                        break;
                    case "deletevoteitemcoverimg":
                        deletevoteitemcoverimg(context);
                        break;
                    case "getsurveyvoteresponse":
                        getsurveyvoteresponse(context);
                        break;
                    case "jpushappwechatmsg":
                        jpushappwechatmsg(context);
                        break;
                    case "deletehouseservicecategorycorver":
                        deletehouseservicecategorycorver(context);
                        break;
                    case "deletehouseservicecorver":
                        deletehouseservicecorver(context);
                        break;
                    case "loadwechatserviceusergrid":
                        loadwechatserviceusergrid(context);
                        break;
                    case "removewechatserviceuser":
                        removewechatserviceuser(context);
                        break;
                    case "savewechatserviceuser":
                        savewechatserviceuser(context);
                        break;
                    case "loadwechatcontactcategorygrid":
                        loadwechatcontactcategorygrid(context);
                        break;
                    case "savewechatcontactcategory":
                        savewechatcontactcategory(context);
                        break;
                    case "deletewechatcontactcategory":
                        deletewechatcontactcategory(context);
                        break;
                    case "getwechatcontactcategorylist":
                        getwechatcontactcategorylist(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("WechatHandler", "命令:" + visit, ex);
                WebUtil.WriteJson(context, new { status = false });
            }
        }
        private void getwechatcontactcategorylist(HttpContext context)
        {
            string type = context.Request["type"];
            var list = new List<Dictionary<string, object>>();
            if (string.IsNullOrEmpty(type))
            {
                list = Wechat_ContactCategory.GetWechat_ContactCategories().OrderBy(p => p.SortOrder).Select(p =>
                {
                    var dic = new Dictionary<string, object>();
                    dic["ID"] = p.ID;
                    dic["Name"] = p.Name;
                    return dic;
                }).ToList();
            }
            else
            {
                var dic = new Dictionary<string, object>();
                dic["ID"] = "hujiaowuye";
                dic["Name"] = "呼叫物业";
                list.Add(dic);
            }
            WebUtil.WriteJson(context, new { status = true, list = list });
        }
        private void deletewechatcontactcategory(HttpContext context)
        {
            string ids = context.Request.Params["ids"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Wechat_ContactCategory] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("WechatHandler", "命令: deletewechatcontactcategory", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void savewechatcontactcategory(HttpContext context)
        {
            int id = WebUtil.GetIntValue(context, "id");
            string name = context.Request["name"];
            int sortorder = WebUtil.GetIntValue(context, "sortorder");
            Wechat_ContactCategory data = null;
            if (id > 0)
            {
                data = Wechat_ContactCategory.GetWechat_ContactCategory(id);
            }
            if (data == null)
            {
                data = new Wechat_ContactCategory();
                data.AddTime = DateTime.Now;
            }
            data.Name = name;
            data.SortOrder = sortorder;
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadwechatcontactcategorygrid(HttpContext context)
        {
            try
            {
                var list = Wechat_ContactCategory.GetWechat_ContactCategories().OrderBy(p => p.SortOrder).ToArray();
                var dg = new DataGrid();
                dg.rows = list;
                dg.total = list.Length;
                dg.page = 1;
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("WechatHandler", "命令: loadwechatcontactcategorygrid", ex);
                WebUtil.WriteJson(context, new DataGrid());
            }
        }
        private void savewechatserviceuser(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string Wx_Account = context.Request["Wx_Account"];
            bool can_invite = false;
            Wechat_ServiceUser data = null;
            if (ID > 0)
            {
                data = Wechat_ServiceUser.GetWechat_ServiceUser(ID);
            }
            if (data == null)
            {
                data = new Wechat_ServiceUser();
                data.AddTime = DateTime.Now;
                data.AddUser = WebUtil.GetUser(context).LoginName;
                data.AccountName = context.Request["AccountName"];
                data.Wx_Account = Wx_Account;
                if (!string.IsNullOrEmpty(Wx_Account))
                {
                    can_invite = true;
                }
            }
            data.NickName = context.Request["NickName"];
            data.UserID = WebUtil.GetIntValue(context, "UserID");
            if (data.ID <= 0)
            {
                //新增微信客服
                var response = MessageHandler.CreateCustomerServiceAccount(WeixinHelper.GetAccessToken(null), data.AccountName, data.NickName);
                if (response.IsError)
                {
                    WebUtil.WriteJson(context, new { status = false, error = response.ErrorMsg });
                    return;
                }
            }
            if (can_invite)
            {
                //邀请绑定客服帐号
                var invite_response = MessageHandler.InviteCustomerService(WeixinHelper.GetAccessToken(null), data.AccountName, data.Wx_Account);
                if (invite_response.IsError)
                {
                    WebUtil.WriteJson(context, new { status = false, error = invite_response.ErrorMsg });
                    return;
                }
            }
            if (data.ID > 0)
            {
                //更新微信客服
                var response = MessageHandler.UpdateCustomerServiceAccount(WeixinHelper.GetAccessToken(null), data.AccountName, data.NickName);
                if (response.IsError)
                {
                    WebUtil.WriteJson(context, new { status = false, error = response.ErrorMsg });
                    return;
                }
            }
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadwechatserviceusergrid(HttpContext context)
        {
            try
            {
                string keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = Wechat_ServiceUserDetail.GetWechat_ServiceUserDetailGridByKeywords(keywords, "order by [AddTime] desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler", "loadwechatserviceusergrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void removewechatserviceuser(HttpContext context)
        {
            string IDListStr = context.Request["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDListStr))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDListStr);
            }
            if (IDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        foreach (var ID in IDList)
                        {
                            var parameters = new List<SqlParameter>();
                            parameters.Add(new SqlParameter("@ID", ID));
                            var data = Wechat_ServiceUser.GetWechat_ServiceUser(ID, helper);
                            if (data == null)
                            {
                                continue;
                            }
                            var response = MessageHandler.RemoveCustomerServiceAccount(WeixinHelper.GetAccessToken(null), data.AccountName);
                            data.Delete(helper);
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        WebUtil.WriteJson(context, new { status = false, error = ex.Message });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void deletehouseservicecorver(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Wechat_HouseService.GetWechat_HouseService(ID);
            if (data != null)
            {
                data.IconLink = string.Empty;
                data.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void deletehouseservicecategorycorver(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Wechat_HouseServiceCategory.GetWechat_HouseServiceCategory(ID);
            int type = WebUtil.GetIntValue(context, "type");
            if (data != null)
            {
                if (type == 1)
                {
                    data.FilePath = string.Empty;
                }
                else if (type == 2)
                {
                    data.FilePath_Active = string.Empty;
                }
                data.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void jpushappwechatmsg(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Wechat_Msg.GetWechat_Msg(ID);
            int type = WebUtil.GetIntValue(context, "type");
            string[] android_cids = new string[] { };
            string[] ios_cids = new string[] { };
            int PushAPP = 0;
            string ContentType = "";
            int ContentCode = 0;
            string Title = string.Empty;
            int PushType = 0;
            if (data.MsgType.Equals(Utility.EnumModel.WechatMsgType.tongzhi.ToString()))
            {
                ContentType = "wechatmsg_gonggao";
                ContentCode = 101;
                Title = "物业公告";
                PushType = 2;
            }
            else if (data.MsgType.Equals(Utility.EnumModel.WechatMsgType.news.ToString()))
            {
                ContentType = "wechatmsg_news";
                ContentCode = 201;
                Title = "小区新闻";
                PushType = 3;
            }
            Dictionary<string, object> extras = new Dictionary<string, object>();
            var extra_model = new Utility.JpushContent(ContentCode, Type: ContentType);
            extras["code"] = extra_model.code;
            extras["msg"] = extra_model.msg;
            extras["type"] = extra_model.type;
            extras["id"] = data.ID;
            if (data.IsCustomerAPPSend)//业主通知
            {
                PushAPP = 2;
                var user_list = Foresight.DataAccess.User.GetAPPCustomerListByWechatMsgID(ID);
                var my_user_list = user_list.Where(p => !string.IsNullOrEmpty(p.DeviceId)).ToArray();
                if (my_user_list.Length == 0)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "没有符合条件的用户" });
                    return;
                }
                var android_users = my_user_list.Where(p => p.DeviceType.Equals("android")).ToArray();
                var ios_users = my_user_list.Where(p => p.DeviceType.Equals("ios")).ToArray();
                android_cids = android_users.Select(p => p.DeviceId).ToArray();
                ios_cids = ios_users.Select(p => p.DeviceId).ToArray();
                string result_push = JPush.JpushAPI.PushMessage(Title, extras, android_cids, ios_cids, extra_model.msg, PushAPP: PushAPP);
                Foresight.DataAccess.JPushLog.Insert_JPushLog(android_cids, ios_cids, extras, result_push, PushType, data.ID, true, Title);
            }
            if (data.IsUserAPPSend)//员工通知
            {
                PushAPP = 1;
                var user_list = Foresight.DataAccess.User.GetAPPUserListByWechatMsgID(ID);
                var my_user_list = user_list.Where(p => !string.IsNullOrEmpty(p.APPUserDeviceID)).ToArray();
                if (my_user_list.Length == 0)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "没有符合条件的用户" });
                    return;
                }
                var android_users = my_user_list.Where(p => p.APPUserDeviceType.Equals("android")).ToArray();
                var ios_users = my_user_list.Where(p => p.APPUserDeviceType.Equals("ios")).ToArray();
                android_cids = android_users.Select(p => p.APPUserDeviceID).ToArray();
                ios_cids = ios_users.Select(p => p.APPUserDeviceID).ToArray();
                string result_push = JPush.JpushAPI.PushMessage(Title, extras, android_cids, ios_cids, extra_model.msg, PushAPP: PushAPP);
                Foresight.DataAccess.JPushLog.Insert_JPushLog(android_cids, ios_cids, extras, result_push, PushType, data.ID, true, Title);
            }
            if (data.IsBusinessAPPSend)//商户通知
            {
                PushAPP = 3;
                var user_list = Foresight.DataAccess.User.GetAPPBusinessUserListByWechatMsgID(ID);
                var my_user_list = user_list.Where(p => !string.IsNullOrEmpty(p.APPBusinessDeviceID)).ToArray();
                if (my_user_list.Length == 0)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "没有符合条件的用户" });
                    return;
                }
                var android_users = my_user_list.Where(p => p.APPBusinessDeviceType.Equals("android")).ToArray();
                var ios_users = my_user_list.Where(p => p.APPBusinessDeviceType.Equals("ios")).ToArray();
                android_cids = android_users.Select(p => p.APPBusinessDeviceID).ToArray();
                ios_cids = ios_users.Select(p => p.APPBusinessDeviceID).ToArray();
                string result_push = JPush.JpushAPI.PushMessage(Title, extras, android_cids, ios_cids, extra_model.msg, PushAPP: PushAPP);
                Foresight.DataAccess.JPushLog.Insert_JPushLog(android_cids, ios_cids, extras, result_push, PushType, data.ID, true, Title);
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getsurveyvoteresponse(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Wechat_Survey.GetWechat_Survey(ID);
            var list = Foresight.DataAccess.Wechat_SurveyQuestion.GetWechat_SurveyQuestionListBySurveyID(data.ID);
            List<int> SurveryIDList = new List<int>();
            SurveryIDList.Add(data.ID);
            var response_list = Foresight.DataAccess.Wechat_SurveyOptionResponse.GetWechat_SurveyQuestionResponseListBySurveyIDList(SurveryIDList);
            var items = list.Select(p =>
            {
                var dic = new Dictionary<string, object>();
                string imageurl = string.IsNullOrEmpty(p.CoverImg) ? "../image/error-img.png" : WebUtil.GetContextPath() + p.CoverImg;
                var my_response_list = response_list.Where(q => q.SurveyQuestionID == p.ID).ToArray();
                string votecountdesc = "总票数: " + my_response_list.Length;
                dic["id"] = p.ID;
                dic["imageurl"] = imageurl;
                dic["title"] = p.QuestionContent;
                dic["summary"] = p.QuestionSummary;
                dic["votecountdesc"] = votecountdesc;
                dic["votecount"] = my_response_list.Length;
                return dic;
            }).ToList();
            items = items.OrderByDescending(p => Convert.ToInt32(p["votecount"])).ToList();
            int TotalPeopleCount = response_list.Select(p => p.UserID).Distinct().ToList().Count;
            int TotalCount = response_list.ToList().Count;
            WebUtil.WriteJson(context, new { status = true, list = items, TotalPeopleCount = TotalPeopleCount, TotalCount = TotalCount });
        }
        private void deletevoteitemcoverimg(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Wechat_SurveyQuestion.GetWechat_SurveyQuestion(ID);
            if (data != null && !string.IsNullOrEmpty(data.CoverImg))
            {
                data.CoverImg = string.Empty;
                data.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadvoteitemcoverimg(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Wechat_SurveyQuestion.GetWechat_SurveyQuestion(ID);
            if (data != null && !string.IsNullOrEmpty(data.CoverImg))
            {
                WebUtil.WriteJson(context, new { status = true, CoverImg = WebUtil.GetContextPath() + data.CoverImg });
                return;
            }
            WebUtil.WriteJson(context, new { status = false });
        }
        private void deletemsgcategory(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Wechat_MsgCategory] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("WechatHandler", "命令: deletemsgcategory", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void savewechatmsgcategory(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Wechat_MsgCategory data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Wechat_MsgCategory.GetWechat_MsgCategory(ID);
            }
            if (data == null)
            {
                data = new Wechat_MsgCategory();
                data.AddTime = DateTime.Now;
                data.AddUser = WebUtil.GetUser(context).RealName;
            }
            data.CategoryName = getValue(context, "tdCategoryName");
            data.SortOrder = getIntValue(context, "tdSortOrder");
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmsgcategorygrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = Wechat_MsgCategory.GeWechat_MsgCategoryGridByKeywords(Keywords, "order by [SortOrder] asc, [AddTime] desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler", "getmsgcategorygrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void savewechathtmlpageconfig(HttpContext context)
        {
            var list = Foresight.DataAccess.SysConfig.GetSysConfigListByType("Wechat");
            var Name = SysConfigNameDefine.WechatConnnectRoomSummary.ToString();
            Foresight.DataAccess.SysConfig.SaveSysConfigByType(list, Name, getValue(context, "tdWechatConnnectRoomSummary"));
            var imageList = Mall_RotatingImage.GetMall_RotatingImages().ToArray();
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile postedFile = uploadFiles[i];
                    string fileOriName = postedFile.FileName;
                    if (fileOriName != "" && fileOriName != null)
                    {
                        string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                        string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                        string filepath = "/upload/Wechat/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        int imageType = 11;
                        if (i == 1)
                        {
                            imageType = 12;
                        }
                        var myImageData = imageList.FirstOrDefault(p => p.Type == imageType);
                        if (myImageData == null)
                        {
                            myImageData = new Mall_RotatingImage();
                            myImageData.AddTime = DateTime.Now;
                            myImageData.Type = imageType;
                            myImageData.SortOrder = 1;
                            myImageData.URLLinkType = 0;
                            myImageData.IsActive = true;
                        }
                        myImageData.ImagePath = filepath + fileName;
                        myImageData.Save();
                    }
                }
            }
            PaymentConfig.WeiXinConfig.ClearCache();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savewechatapppaysetup(HttpContext context)
        {
            var list = Foresight.DataAccess.SysConfig.GetSysConfigListByType("Wechat");

            Foresight.DataAccess.SysConfig.SaveSysConfigByType(list, "MobileAppID", getValue(context, "tdMobileAPPID"));
            Foresight.DataAccess.SysConfig.SaveSysConfigByType(list, "MobileAppSecret", getValue(context, "tdMobileAppSecret"));
            Foresight.DataAccess.SysConfig.SaveSysConfigByType(list, "MobileMCHID", getValue(context, "tdMobileMCHID"));
            Foresight.DataAccess.SysConfig.SaveSysConfigByType(list, "MobileMCHKey", getValue(context, "tdMobileMCHKey"));
            Foresight.DataAccess.SysConfig.SaveSysConfigByType(list, "MobileSSLCERT_PASSWORD", getValue(context, "tdMobileSSLCERT_PASSWORD"));

            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                HttpPostedFile postedFile = uploadFiles[0];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/Wechat/Cert/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    Foresight.DataAccess.SysConfig.SaveSysConfigByType(list, "MobileSSLCERT_PATH", filepath + fileName);
                }
            }
            PaymentConfig.WeiXinConfig.ClearCache();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savewechatsetup(HttpContext context)
        {
            var list = Foresight.DataAccess.SysConfig.GetSysConfigListByType("Wechat");
            string AppID = getValue(context, "tdAppID");
            string AppSecret = getValue(context, "tdAppSecret");
            string Token = getValue(context, "tdToken");
            Foresight.DataAccess.SysConfig.SaveSysConfigByType(list, "AppID", AppID);
            Foresight.DataAccess.SysConfig.SaveSysConfigByType(list, "AppSecret", AppSecret);
            Foresight.DataAccess.SysConfig.SaveSysConfigByType(list, "Token", Token);
            Foresight.DataAccess.SysConfig.SaveSysConfigByType(list, "Oauth2Url", getValue(context, "tdOauth2Url"));
            Foresight.DataAccess.SysConfig.SaveSysConfigByType(list, "WxApiUrl", getValue(context, "tdWxApiUrl"));
            Foresight.DataAccess.SysConfig.SaveSysConfigByType(list, "MCHID", getValue(context, "tdMCHID"));
            Foresight.DataAccess.SysConfig.SaveSysConfigByType(list, "MCHKey", getValue(context, "tdMCHKey"));
            Foresight.DataAccess.SysConfig.SaveSysConfigByType(list, "SSLCERT_PASSWORD", getValue(context, "tdSSLCERT_PASSWORD"));
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile postedFile = uploadFiles[i];
                    string fileOriName = postedFile.FileName;
                    if (fileOriName != "" && fileOriName != null)
                    {
                        string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                        if (i == 0)
                        {
                            postedFile.SaveAs(HttpContext.Current.Server.MapPath("~/") + fileOriName);
                            continue;
                        }
                        string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                        string filepath = "/upload/Wechat/Cert/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        if (i == 1)
                        {
                            Foresight.DataAccess.SysConfig.SaveSysConfigByType(list, "SSLCERT_PATH", filepath + fileName);
                        }
                    }
                }
            }
            PaymentConfig.WeiXinConfig.ClearCache();
            var siteconfig = new Utility.SiteConfig();
            string VirName = WebUtil.GetVirName();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["wx_AppId"] = AppID;
            dic["wx_Token"] = Token;
            dic["wx_AppSecret"] = AppSecret;
            Wechat_ChatRequest.SaveWechat_Config_Path(VirName, dic);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removerenthome(HttpContext context)
        {
            string IDListStr = context.Request["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDListStr))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDListStr);
            }
            if (IDList.Count > 0)
            {
                string cmdtext = string.Empty;
                cmdtext += "delete from [Wechat_RentHomeImg] where RentHomeID in (" + string.Join(",", IDList.ToArray()) + ");";
                cmdtext += "delete from [Wechat_RentHomeType] where RentRoomID in (" + string.Join(",", IDList.ToArray()) + ");";
                cmdtext += "delete from [Wechat_RentHome] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception)
                    {
                        helper.Rollback();
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removehouseservice(HttpContext context)
        {
            string IDListStr = context.Request["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDListStr))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDListStr);
            }
            if (IDList.Count > 0)
            {
                string cmdtext = string.Empty;
                cmdtext += "delete from [Wechat_HouseServiceImg] where ServiceID in (" + string.Join(",", IDList.ToArray()) + ");";
                cmdtext += "delete from [Wechat_HouseServiceType] where ServiceID in (" + string.Join(",", IDList.ToArray()) + ");";
                cmdtext += "delete from [Wechat_HouseService] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception)
                    {
                        helper.Rollback();
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void deletehouseservicefile(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Wechat_HouseServiceImg.DeleteWechat_HouseServiceImg(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadhouseserviceattachs(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var list = Foresight.DataAccess.Wechat_HouseServiceImg.GetWechat_HouseServiceImgList(ID);
            var items = list.Select(p =>
            {
                var dic = p.ToJsonObject();
                dic["AttachedFilePath"] = !string.IsNullOrEmpty(p.AttachedFilePath) ? WebUtil.GetContextPath() + p.AttachedFilePath : "";
                return dic;
            });
            WebUtil.WriteJson(context, items);
        }
        private void getedithouseserviceparams(HttpContext context)
        {
            int type = WebUtil.GetIntValue(context, "type");
            var list = Foresight.DataAccess.Wechat_HouseServiceCategory.GetWechat_HouseServiceCategories().ToArray();
            if (type == 1)
            {
                list = list.Where(p => p.IsWechatShow).ToArray();
            }
            else
            {
                list = list.Where(p => p.IsAPPCustomerShow || p.IsAPPUserShow).ToArray();
            }
            var items = list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.CategoryName };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, categorylist = items });
        }
        private void savehouseservice(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Wechat_HouseService data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Wechat_HouseService.GetWechat_HouseService(ID);
            }
            if (data == null)
            {
                data = new Wechat_HouseService();
                data.AddTime = DateTime.Now;
            }
            data.UseOutLink = getIntValue(context, "tdUseOutLink") == 1;
            data.OutLinkURL = getValue(context, "tdOutLinkURL");
            data.ServiceType = WebUtil.GetIntValue(context, "type");
            data.Title = getValue(context, "tdTitle");
            data.ContactPhone = getValue(context, "tdContactPhone");
            data.CategoryID = getIntValue(context, "tdCategory");
            data.IsPublish = getIntValue(context, "tdPublishStatus") == 1;
            data.ServiceIncude = context.Request["ServiceIncude"];
            data.ServiceStandard = context.Request["ServiceStandard"];
            data.AppointNotify = context.Request["AppointNotify"];
            data.SortOrder = getIntValue(context, "tdSortOrder");
            data.IsWechatShow = WebUtil.GetIntValue(context, "IsWechatSend") == 1;
            data.IsAPPCustomerShow = WebUtil.GetIntValue(context, "IsCustomerAPPSend") == 1;
            data.IsAPPUserShow = WebUtil.GetIntValue(context, "IsUserAPPSend") == 1;
            string options = context.Request["options"];
            List<Utility.HouseServiceOption> optionlist = new List<Utility.HouseServiceOption>();
            if (!string.IsNullOrEmpty(options))
            {
                optionlist = JsonConvert.DeserializeObject<List<Utility.HouseServiceOption>>(options);
            }
            List<Foresight.DataAccess.Wechat_HouseServiceType> option_list = new List<Wechat_HouseServiceType>();
            foreach (var item in optionlist)
            {
                Foresight.DataAccess.Wechat_HouseServiceType option = null;
                if (item.ID > 0)
                {
                    option = Foresight.DataAccess.Wechat_HouseServiceType.GetWechat_HouseServiceType(item.ID);
                }
                if (option == null)
                {
                    option = new Wechat_HouseServiceType();
                    option.AddTime = DateTime.Now;
                }
                option.BasicPrice = item.BasicPrice;
                option.TypeName = item.TypeName;
                option.UnitPrice = item.UnitPrice;
                option.Unit = item.Unit;
                option.Remark = item.Remark;
                option_list.Add(option);
            }
            List<Foresight.DataAccess.Wechat_HouseServiceImg> attachlist = new List<Foresight.DataAccess.Wechat_HouseServiceImg>();
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/HouseService/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    if (i == 0)
                    {
                        data.IconLink = filepath + fileName;
                    }
                    else
                    {
                        Foresight.DataAccess.Wechat_HouseServiceImg attach = new Foresight.DataAccess.Wechat_HouseServiceImg();
                        attach.FileOriName = fileOriName;
                        attach.AttachedFilePath = filepath + fileName;
                        attach.AddTime = DateTime.Now;
                        attachlist.Add(attach);
                    }
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    foreach (var item in option_list)
                    {
                        item.ServiceID = data.ID;
                        item.Save(helper);
                    }
                    foreach (var item in attachlist)
                    {
                        item.ServiceID = data.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
        }
        private void removehouseservicetype(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Wechat_HouseServiceType.DeleteWechat_HouseServiceType(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void gethouseservicetype(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var list = Foresight.DataAccess.Wechat_HouseServiceType.GetWechat_HouseServiceTypeListByServiceID(ID);
            int count = 0;
            var items = list.Select(p =>
            {
                count++;
                var item = new { ID = p.ID, TypeName = p.TypeName, BasicPrice = p.BasicPrice > decimal.MinValue ? p.BasicPrice : 0, UnitPrice = p.UnitPrice, Unit = p.Unit, Remark = p.Remark, TypeTags = p.Remark, count = count };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void gethouseservicegrid(HttpContext context)
        {
            try
            {
                int type = WebUtil.GetIntValue(context, "type");
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string CategoryIDListStr = context.Request["CategoryIDList"];
                List<int> CategoryIDList = new List<int>();
                if (!string.IsNullOrEmpty(CategoryIDListStr))
                {
                    CategoryIDList = JsonConvert.DeserializeObject<List<int>>(CategoryIDListStr);
                }
                DataGrid dg = Wechat_HouseServiceDetail.GetWechat_HouseServiceDetailGridByKeywords(Keywords, CategoryIDList, "order by [SortOrder] asc, AddTime asc", startRowIndex, pageSize, type);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler.ashx", "gethouseservicegrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
        }
        private void removehouseservicecategory(HttpContext context)
        {
            List<int> CategoryIDList = JsonConvert.DeserializeObject<List<int>>(context.Request.Params["CategoryIDList"]);
            if (CategoryIDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择需要删除的类别" });
                return;
            }
            var service_list = Foresight.DataAccess.Wechat_HouseServiceDetail.GetWechat_HouseServiceDetailListByAreaIDList(CategoryIDList);
            if (service_list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = string.Join(",", service_list.Select(p => p.CategoryName).Distinct().ToArray()) + "下包含服务,删除取消" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = string.Empty;
                    cmdtext += "delete from [Wechat_HouseServiceCategory] where [ID] in (" + string.Join(",", CategoryIDList.ToArray()) + ");";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("WechatHandler.ashx", "命令: removehouseservicecategory", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savewechathouseservicecategory(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            int type = WebUtil.GetIntValue(context, "type");
            Foresight.DataAccess.Wechat_HouseServiceCategory data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Wechat_HouseServiceCategory.GetWechat_HouseServiceCategory(ID);
            }
            if (data == null)
            {
                data = new Wechat_HouseServiceCategory();
                data.AddTime = DateTime.Now;
            }
            data.ServiceType = type;
            data.IsWechatShow = WebUtil.GetIntValue(context, "IsWechatSend") == 1;
            data.IsAPPCustomerShow = WebUtil.GetIntValue(context, "IsCustomerAPPSend") == 1;
            data.IsAPPUserShow = WebUtil.GetIntValue(context, "IsUserAPPSend") == 1;
            data.CategoryName = getValue(context, "tdCategoryName");
            data.SortOrder = getIntValue(context, "tdSortOrder");
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/HouseService/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    if (i == 0)
                    {
                        data.FilePath = filepath + fileName;
                    }
                    else if (i == 1)
                    {
                        data.FilePath_Active = filepath + fileName;
                    }
                }
            }
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void gethouseservicecategorytree(HttpContext context)
        {
            try
            {
                int type = WebUtil.GetIntValue(context, "type");
                string Keywords = context.Request.Params["Keywords"];
                var list = Foresight.DataAccess.Wechat_HouseServiceCategory.GetWechat_HouseServiceCategoryListByKeywords(Keywords, type).OrderBy(p => p.SortOrder).ToArray();
                TreeModule treeModule = null;
                var items = list.Select(p =>
                {
                    treeModule = new TreeModule();
                    treeModule.id = "category_" + p.ID.ToString();
                    treeModule.ID = p.ID;
                    treeModule.pId = "category_0";
                    treeModule.name = p.CategoryName;
                    treeModule.isParent = false;
                    treeModule.open = false;
                    treeModule.type = "category";
                    return treeModule;
                }).ToList();
                treeModule = new TreeModule();
                treeModule.id = "category_0";
                treeModule.ID = 0;
                treeModule.pId = "0";
                treeModule.name = WebUtil.GetCompany(context).CompanyName;
                bool hasckChild = list.Length > 0;
                treeModule.isParent = hasckChild;
                treeModule.open = hasckChild;
                treeModule.type = "company";
                items.Add(treeModule);
                WebUtil.WriteJson(context, items);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler.ashx", "visit: gethouseservicecategorytree", ex);
                context.Response.Write("[]");
            }
        }
        private void getrentrequestgrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string AreaIDListStr = context.Request["AreaIDList"];
                List<int> AreaIDList = new List<int>();
                if (!string.IsNullOrEmpty(AreaIDListStr))
                {
                    AreaIDList = JsonConvert.DeserializeObject<List<int>>(AreaIDListStr);
                }
                string BuildingIDListStr = context.Request["BuildingIDList"];
                List<int> BuildingIDList = new List<int>();
                if (!string.IsNullOrEmpty(BuildingIDListStr))
                {
                    BuildingIDList = JsonConvert.DeserializeObject<List<int>>(BuildingIDListStr);
                }
                DataGrid dg = Wechat_RentRequestDetail.GetWechat_RentRequestDetailGridByKeywords(Keywords, AreaIDList, BuildingIDList, "order by AddTime asc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler.ashx", "getrenthomegrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
        }
        private void deleterenthomefile(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Wechat_RentHomeImg.DeleteWechat_RentHomeImg(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadrenthomeattachs(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var list = Foresight.DataAccess.Wechat_RentHomeImg.GetWechat_RentHomeImgList(ID);
            var items = list.Select(p =>
            {
                var dic = p.ToJsonObject();
                dic["AttachedFilePath"] = !string.IsNullOrEmpty(p.AttachedFilePath) ? WebUtil.GetContextPath() + p.AttachedFilePath : "";
                return dic;
            });
            WebUtil.WriteJson(context, items);
        }
        private void saverenthome(HttpContext context)
        {
            int HomeID = WebUtil.GetIntValue(context, "HomeID");
            Foresight.DataAccess.Wechat_RentHome data = null;
            if (HomeID > 0)
            {
                data = Foresight.DataAccess.Wechat_RentHome.GetWechat_RentHome(HomeID);
            }
            if (data == null)
            {
                data = new Wechat_RentHome();
                data.AddMan = WebUtil.GetUser(context).RealName;
                data.AddTime = DateTime.Now;
            }
            data.HomeName = getValue(context, "tdHomeName");
            data.PhoneNumber = getValue(context, "tdPhoneNumber");
            data.HomeLocation = getValue(context, "tdHomeLocation");
            data.AreaID = getIntValue(context, "tdRentArea");
            data.HomeType = getValue(context, "tdHomeType");
            data.Subways = getValue(context, "tdSubways");
            data.Traffics = getValue(context, "tdTraffics");
            data.SuperMarkets = getValue(context, "tdSuperMarkets");
            data.RoomOwners = getValue(context, "tdRoomOwners");
            data.PublicOwners = getValue(context, "tdPublicOwners");
            data.RoomDescription = getValue(context, "tdRoomDescription");
            data.MapLocation = getValue(context, "tdMapLocation");
            data.BuildingID = getIntValue(context, "tdRentBuilding");
            string options = context.Request["options"];
            List<Utility.RentHomeTypeOption> optionlist = new List<Utility.RentHomeTypeOption>();
            if (!string.IsNullOrEmpty(options))
            {
                optionlist = JsonConvert.DeserializeObject<List<Utility.RentHomeTypeOption>>(options);
            }
            List<Foresight.DataAccess.Wechat_RentHomeType> option_list = new List<Wechat_RentHomeType>();
            foreach (var item in optionlist)
            {
                Foresight.DataAccess.Wechat_RentHomeType option = null;
                if (item.ID > 0)
                {
                    option = Foresight.DataAccess.Wechat_RentHomeType.GetWechat_RentHomeType(item.ID);
                }
                if (option == null)
                {
                    option = new Wechat_RentHomeType();
                    option.AddTime = DateTime.Now;
                    option.AddMan = WebUtil.GetUser(context).RealName;
                }
                option.TypeName = item.TypeName;
                option.UnitPrice = item.UnitPrice;
                option.Unit = item.Unit;
                option.TypeArea = item.TypeArea;
                option.TypeTags = item.TypeTags;
                option.RentStatus = item.RentStatus;
                option_list.Add(option);
            }
            List<Foresight.DataAccess.Wechat_RentHomeImg> attachlist = new List<Foresight.DataAccess.Wechat_RentHomeImg>();
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/RentHome/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    Foresight.DataAccess.Wechat_RentHomeImg attach = new Foresight.DataAccess.Wechat_RentHomeImg();
                    attach.FileOriName = fileOriName;
                    attach.AttachedFilePath = filepath + fileName;
                    attach.AddTime = DateTime.Now;
                    attachlist.Add(attach);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    foreach (var item in option_list)
                    {
                        item.RentRoomID = data.ID;
                        item.Save(helper);
                    }
                    foreach (var item in attachlist)
                    {
                        item.RentHomeID = data.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
        }
        private void removerenthometype(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Wechat_RentHomeType.DeleteWechat_RentHomeType(ID);
            WebUtil.WriteJsonResult(context, new { status = true });
        }
        private void getrenthometype(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var list = Foresight.DataAccess.Wechat_RentHomeType.GetWechat_RentHomeTypeListByHomeID(ID);
            int count = 0;
            var items = list.Select(p =>
            {
                count++;
                var item = new { ID = p.ID, TypeName = p.TypeName, UnitPrice = p.UnitPrice, Unit = p.Unit, TypeArea = p.TypeArea, TypeTags = p.TypeTags, RentStatus = p.RentStatus, count = count };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void geteditrenthomeparams(HttpContext context)
        {
            var list = Foresight.DataAccess.Wechat_RentArea.GetWechat_RentAreas();
            var items = list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.AreaName };
                return item;
            });
            var list_building = Foresight.DataAccess.Wechat_RentBuilding.GetWechat_RentBuildings();
            var items_building = list_building.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.BuildingName, AreaID = p.AreaID };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, arealist = items, buildinglist = items_building });
        }
        private void getrenthomegrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string AreaIDListStr = context.Request["AreaIDList"];
                List<int> AreaIDList = new List<int>();
                if (!string.IsNullOrEmpty(AreaIDListStr))
                {
                    AreaIDList = JsonConvert.DeserializeObject<List<int>>(AreaIDListStr);
                }
                string BuildingIDListStr = context.Request["BuildingIDList"];
                List<int> BuildingIDList = new List<int>();
                if (!string.IsNullOrEmpty(BuildingIDListStr))
                {
                    BuildingIDList = JsonConvert.DeserializeObject<List<int>>(BuildingIDListStr);
                }
                DataGrid dg = Wechat_RentHomeDetail.GeWechat_RentHomeDetailGridByKeywords(Keywords, AreaIDList, BuildingIDList, "order by AddTime asc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler.ashx", "getrenthomegrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
        }
        private void removerentarea(HttpContext context)
        {
            List<int> AreaIDList = JsonConvert.DeserializeObject<List<int>>(context.Request.Params["AreaIDList"]);
            List<int> BuildingIDList = JsonConvert.DeserializeObject<List<int>>(context.Request.Params["BuildingIDList"]);
            if (AreaIDList.Count == 0 && BuildingIDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择需要删除的区域或者楼盘" });
                return;
            }
            var list = Foresight.DataAccess.Wechat_RentBuildingDetail.GeWechat_RentBuildingDetailListByAreaIDList(BuildingIDList, AreaIDList);
            if (list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请先删除" + string.Join(",", list.Select(p => p.AreaName).ToArray()) + "下的楼盘" });
                return;
            }
            var home_list = Foresight.DataAccess.Wechat_RentHomeDetail.GetWechat_RentHomeDetailListByAreaIDList(AreaIDList, BuildingIDList);
            if (home_list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = string.Join(",", home_list.Select(p => p.AreaName).Distinct().ToArray()) + "下包含发布的房源" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = string.Empty;
                    if (BuildingIDList.Count > 0)
                    {
                        cmdtext += "delete from [Wechat_RentBuilding] where [ID] in (" + string.Join(",", BuildingIDList.ToArray()) + ");";
                    }
                    if (AreaIDList.Count > 0)
                    {
                        cmdtext += "delete from [Wechat_RentArea] where [ID] in (" + string.Join(",", AreaIDList.ToArray()) + ");";
                    }
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("WechatHandler.ashx", "命令: removerentarea", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void saverentarea(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string type = context.Request["Type"];
            int AreaID = WebUtil.GetIntValue(context, "AreaID");
            if (type.Equals("area"))
            {
                Foresight.DataAccess.Wechat_RentArea data = null;
                if (ID > 0)
                {
                    data = Foresight.DataAccess.Wechat_RentArea.GetWechat_RentArea(ID);
                }
                if (data == null)
                {
                    data = new Wechat_RentArea();
                    data.AddTime = DateTime.Now;
                }
                data.AreaName = getValue(context, "tdAreaName");
                data.Save();
            }
            else if (type.Equals("building"))
            {
                Foresight.DataAccess.Wechat_RentBuilding data = null;
                if (ID > 0)
                {
                    data = Foresight.DataAccess.Wechat_RentBuilding.GetWechat_RentBuilding(ID);
                }
                if (data == null)
                {
                    data = new Wechat_RentBuilding();
                    data.AddTime = DateTime.Now;
                    data.AreaID = AreaID;
                }
                data.BuildingName = getValue(context, "tdAreaName");
                data.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getrentareatree(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                var list = Foresight.DataAccess.Wechat_RentArea.GeWechat_RentAreaListByKeywords(Keywords);
                List<int> AreaIDList = list.Select(p => p.ID).ToList();
                var building_list = Foresight.DataAccess.Wechat_RentBuilding.GeWechat_RentBuildingListByKeywords(AreaIDList, Keywords);
                TreeModule treeModule = null;
                var items = list.Select(p =>
                {
                    var my_buildings = building_list.Where(q => q.AreaID == p.ID).ToArray();
                    treeModule = new TreeModule();
                    treeModule.id = "area_" + p.ID.ToString();
                    treeModule.ID = p.ID;
                    treeModule.pId = "area_0";
                    treeModule.name = p.AreaName;
                    treeModule.isParent = my_buildings.Length > 0;
                    treeModule.open = my_buildings.Length > 0;
                    treeModule.type = "area";
                    return treeModule;
                }).ToList();
                var building_items = building_list.Select(p =>
                {
                    treeModule = new TreeModule();
                    treeModule.id = "building_" + p.ID.ToString();
                    treeModule.ID = p.ID;
                    treeModule.pId = "area_" + p.AreaID;
                    treeModule.name = p.BuildingName;
                    treeModule.isParent = false;
                    treeModule.open = false;
                    treeModule.type = "building";
                    return treeModule;
                }).ToList();
                items = items.Concat(building_items).ToList();
                treeModule = new TreeModule();
                treeModule.id = "area_0";
                treeModule.ID = 0;
                treeModule.pId = "0";
                treeModule.name = WebUtil.GetCompany(context).CompanyName;
                bool hasckChild = list.Length > 0;
                treeModule.isParent = hasckChild;
                treeModule.open = hasckChild;
                treeModule.type = "company";
                items.Add(treeModule);
                WebUtil.WriteJson(context, items);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler.ashx", "visit: getrentareatree", ex);
                context.Response.Write("[]");
            }
        }
        private void deletewechatbusiness(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            if (IDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = string.Empty;
                        cmdtext += "delete from [Wechat_Business] where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("WechatHandler.ashx", "命令: deletewechatbusiness", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savewechatbusiness(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Wechat_Business data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Wechat_Business.GetWechat_Business(ID);
            }
            if (data == null)
            {
                data = new Wechat_Business();
                data.AddTime = DateTime.Now;
            }
            data.BusinessName = getValue(context, "tdBusinessName");
            data.PhoneNumber = getValue(context, "tdPhoneNumber");
            data.BusinessSummary = getValue(context, "tdBusinessSummary");
            data.IsPublish = getIntValue(context, "tdIsPublish") == 1;
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                HttpPostedFile postedFile = uploadFiles[0];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string filepath = "/upload/WechatBusiness/";
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    data.BusinessImg = filepath + fileName;
                }
            }
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getwechatbusinessgrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = Wechat_Business.GeWechat_BusinessGridByKeywords(Keywords, "order by AddTime asc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler.ashx", "getwechatbusinessgrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
        }
        private void viewqrcodebyurl(HttpContext context)
        {
            string pageurl = context.Request["pageurl"];
            if (string.IsNullOrEmpty(pageurl))
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            string FullPath = string.Empty;
            var qrcode = Foresight.DataAccess.Wechat_Qrcode.GetWechat_QrcodeByPageURL(pageurl);
            if (qrcode == null)
            {
                string squarePicUrl = string.Empty;
                string QrcodePath = WeixinHelper.CreateQrCode(pageurl, out squarePicUrl);
                FullPath = WebUtil.GetContextPath() + QrcodePath;
                qrcode = new Wechat_Qrcode();
                qrcode.AddTime = DateTime.Now;
                qrcode.QrCodeImgPath = QrcodePath;
                qrcode.QrCodeURL = pageurl;
                qrcode.Save();
            }
            if (qrcode.QrCodeImgPath.StartsWith("http"))
            {
                FullPath = qrcode.QrCodeImgPath;
            }
            else
            {
                FullPath = WebUtil.GetContextPath() + qrcode.QrCodeImgPath;
            }
            WebUtil.WriteJson(context, new { status = true, qrcodeurl = FullPath });
        }
        private void getuserlisthasopenid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = UserDetail.GeUserDetailGridByKeywordsWithOpenID(Keywords, "order by UserID asc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler.ashx", "getlotterycheckergrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
        }
        private void deletelotterychecker(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            if (IDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = string.Empty;
                        cmdtext += "delete from [Wechat_LotteryChecker] where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("WechatHandler.ashx", "命令: deletelotterychecker", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savelotterychecker(HttpContext context)
        {
            int ActivityID = WebUtil.GetIntValue(context, "ActivityID");
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            if (IDList.Count > 0)
            {
                foreach (var UserID in IDList)
                {
                    var data = Foresight.DataAccess.Wechat_LotteryChecker.GetWechat_LotteryCheckerByActivityID(ActivityID, UserID);
                    if (data == null)
                    {
                        data = new Wechat_LotteryChecker();
                        data.ActivityID = ActivityID;
                        data.UserID = UserID;
                        data.Save();
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getlotterycheckergrid(HttpContext context)
        {
            try
            {
                int ActivityID = WebUtil.GetIntValue(context, "ActivityID");
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = ViewWechatLotteryChecker.GetViewWechatLotteryCheckerList(Keywords, ActivityID, "order by ID asc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler.ashx", "getlotterycheckergrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
        }
        private void deletelotteryuser(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            if (IDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = string.Empty;
                        cmdtext += "delete from [Wechat_LotteryActivityUser] where [ID] in (" + string.Join(",", IDList.ToArray()) + ") and [ActivityID] not in (select [ActivityID] from [Wechat_LotteryActivityRecord]);";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("WechatHandler.ashx", "命令: deletelotteryuser", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savelotteryuser(HttpContext context)
        {
            Foresight.DataAccess.Wechat_LotteryActivityUser data = null;
            int ID = WebUtil.GetIntValue(context, "ID");
            int ActivityID = WebUtil.GetIntValue(context, "ActivityID");
            if (ID > 0)
            {
                data = Foresight.DataAccess.Wechat_LotteryActivityUser.GetWechat_LotteryActivityUser(ID);
            }
            if (data == null)
            {
                data = new Wechat_LotteryActivityUser();
                data.ActivityID = ActivityID;
                data.AddTime = DateTime.Now;
            }
            data.CustomerName = getValue(context, "tdCustomerName");
            data.PhoneNumber = getValue(context, "tdPhoneNumber");
            data.Save();
            WebUtil.WriteJson(context, new { status = true, ID = data.ID });
        }
        private void getlotteryusergrid(HttpContext context)
        {
            try
            {
                int ActivityID = WebUtil.GetIntValue(context, "ActivityID");
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = Wechat_LotteryActivityUser.GetWechat_LotteryActivityUserList(Keywords, ActivityID, "order by ID asc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler.ashx", "getlotteryusergrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
        }
        private void getlotteryprizerecord(HttpContext context)
        {
            try
            {
                int ActivityID = WebUtil.GetIntValue(context, "ActivityID");
                bool? completeSend = null;
                int CompleteSend = WebUtil.GetIntValue(context, "CompleteSend");
                if (CompleteSend == 1)
                {
                    completeSend = true;
                }
                else if (CompleteSend == 2)
                {
                    completeSend = false;
                }
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = ViewWechatLotteryActivityRecord.GetViewWechatLotteryActivityRecordList(Keywords, completeSend, ActivityID, "order by ID asc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler.ashx", "getlotteryprizegrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
        }
        private void deletelotteryprize(HttpContext context)
        {
            int ActivityID = WebUtil.GetIntValue(context, "ActivityID");
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            if (IDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = string.Empty;
                        cmdtext += "delete from [Wechat_LotteryActivityPrize] where [ID] in (" + string.Join(",", IDList.ToArray()) + ") and [ActivityID] not in (select [ActivityID] from [Wechat_LotteryActivityRecord]);";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("WechatHandler.ashx", "命令: deletelotteryprize", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                LotteryHelper.ClearCache(ActivityID);
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savelotteryprize(HttpContext context)
        {
            Foresight.DataAccess.Wechat_LotteryActivityPrize data = null;
            int ID = WebUtil.GetIntValue(context, "ID");
            int ActivityID = WebUtil.GetIntValue(context, "ActivityID");
            if (ID > 0)
            {
                data = Foresight.DataAccess.Wechat_LotteryActivityPrize.GetWechat_LotteryActivityPrize(ID);
            }
            if (data == null)
            {
                data = new Wechat_LotteryActivityPrize();
                data.ActivityID = ActivityID;
            }
            data.LevelName = getValue(context, "tdLevelName");
            data.Quota = getIntValue(context, "tdQuota");
            data.PrizeName = getValue(context, "tdPrizeName");
            data.Type = getValue(context, "tdType");
            data.PrizeQuantity = getDecimalValue(context, "tdPrizeQuantity");
            data.PrizeUnit = getValue(context, "tdPrizeUnit");
            data.RepeatTime = getIntValue(context, "tdRepeatTime");
            data.Save();
            LotteryHelper.ClearCache(ActivityID);
            WebUtil.WriteJson(context, new { status = true, ID = data.ID });
        }
        private void getlotteryprizegrid(HttpContext context)
        {
            try
            {
                int ActivityID = WebUtil.GetIntValue(context, "ActivityID");
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = Wechat_LotteryActivityPrize.GetWechat_LotteryActivityPrizeGridByKeywords(Keywords, ActivityID, "order by ID asc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler.ashx", "getlotteryprizegrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
        }
        private void deletelotteryactivity(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            if (IDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = string.Empty;
                        cmdtext += "delete from [Wechat_LotteryActivityPrize] where [ActivityID] in (" + string.Join(",", IDList.ToArray()) + ") and [ActivityID] not in (select [ActivityID] from [Wechat_LotteryActivityRecord]);";
                        cmdtext += "delete from [Wechat_LotteryActivityUser] where [ActivityID] in (" + string.Join(",", IDList.ToArray()) + ") and [ActivityID] not in (select [ActivityID] from [Wechat_LotteryActivityRecord]);";
                        cmdtext += "delete from [Wechat_LotteryActivity] where [ID] in (" + string.Join(",", IDList.ToArray()) + ") and [ID] not in (select [ActivityID] from [Wechat_LotteryActivityRecord]);";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("WechatHandler.ashx", "命令: deletelotteryartivity", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                foreach (var ID in IDList)
                {
                    LotteryHelper.ClearCache(ID);
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savelotteryactivity(HttpContext context)
        {
            Foresight.DataAccess.Wechat_LotteryActivity data = null;
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID > 0)
            {
                data = Foresight.DataAccess.Wechat_LotteryActivity.GetWechat_LotteryActivity(ID);
            }
            if (data == null)
            {
                data = new Wechat_LotteryActivity();
                data.CreationTime = DateTime.Now;
                data.CreatorName = WebUtil.GetUser(context).RealName;
                data.ConsumeType = Utility.EnumModel.LotteryConsumeTypeDefine.NormalPrize.ToString();
            }
            data.ActivityName = getValue(context, "tdActivityName");
            data.MerchantName = getValue(context, "tdMerchantName");
            data.Type = getValue(context, "tdType");
            data.Repeat = getValue(context, "tdRepeat");
            data.RepeatTime = getIntValue(context, "tdRepeatTime");
            data.ParticipantNumber = getIntValue(context, "tdParticipantNumber");
            data.UserLimit = getIntValue(context, "tdUserLimit") == 1;
            data.NoLimitMsg = getValue(context, "tdNoLimitMsg");
            data.StartTime = getTimeValue(context, "tdStartTime");
            data.EndTime = getTimeValue(context, "tdEndTime");
            data.RuleDescription = getValue(context, "tdRuleDescription");
            data.Description = getValue(context, "tdDescription");
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                HttpPostedFile postedFile = uploadFiles[0];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string filepath = "/upload/Lottery/";
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    data.CoverImg = filepath + fileName;
                }
            }
            data.Save();
            LotteryHelper.ClearCache(data.ID);
            WebUtil.WriteJson(context, new { status = true, ID = data.ID });
        }
        private void getlotteryactivitygrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = Wechat_LotteryActivity.GetWechat_LotteryActivityGridByKeywords(Keywords, "order by CreationTime desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler.ashx", "getlotteryarticlegrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
        }
        private void getsurveyresponse(HttpContext context)
        {
            int SurveyID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Wechat_Survey data = null;
            if (SurveyID > 0)
            {
                data = Wechat_Survey.GetWechat_Survey(SurveyID);
            }
            if (data == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "该调查问卷不存在" });
                return;
            }
            var questions = Foresight.DataAccess.Wechat_SurveyQuestion.GetWechat_SurveyQuestionListBySurveyID(SurveyID);
            var options = Foresight.DataAccess.Wechat_SurveyQuestionOptionDetail.GetWechat_SurveyQuestionOptionDetailListBySurveyID(SurveyID);
            int total_count = Foresight.DataAccess.Wechat_SurveyOptionResponse.GetWechat_SurveyOptionResponseCountBySurveyID(SurveyID);
            var items = questions.Select(p =>
            {
                var my_options = options.Where(q => q.SurveyQuestionID == p.ID).Select(m =>
                {
                    var my_option = new { OptionID = m.ID, TotalCount = m.TotalCount, Content = m.OptionContent };
                    return my_option;
                }).ToList();
                var item = new { QuestionID = p.ID, Title = p.QuestionContent, type = p.QuestionType, options = my_options };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, TotalCount = total_count, questions = items });
        }
        private void removesurveyquestion(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            int SurveyType = WebUtil.GetIntValue(context, "SurveyType");
            int SurveyID = WebUtil.GetIntValue(context, "SurveyID");
            string UserIDs = context.Request.Params["UserIDList"];
            List<int> UserIDList = new List<int>();
            if (!string.IsNullOrEmpty(UserIDs))
            {
                UserIDList = JsonConvert.DeserializeObject<List<int>>(UserIDs);
            }
            if (IDList.Count == 0 && UserIDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = true });
                return;
            }
            var user_list = new Foresight.DataAccess.User[] { };
            if (UserIDList.Count > 0)
            {
                user_list = Foresight.DataAccess.User.GetUserListByIDList(UserIDList);
            }
            string AddUserName = WebUtil.GetUser(context).LoginName;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = string.Empty;
                    if (IDList.Count > 0)
                    {
                        if (SurveyType == 3)
                        {
                            cmdtext = "update [Wechat_SurveyQuestion] set [IsDeleted]=1 where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        }
                        else
                        {
                            cmdtext = "delete from [Wechat_SurveyQuestion] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        }
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                    }
                    if (UserIDList.Count > 0)
                    {
                        foreach (var UserID in UserIDList)
                        {
                            var user = user_list.FirstOrDefault(p => p.UserID == UserID);
                            var data = new Foresight.DataAccess.Wechat_SurveyQuestion();
                            data.SurveyID = SurveyID;
                            data.QuestionContent = user.NickName;
                            data.QuestionType = 1;
                            data.SortOrder = 1;
                            data.AddTime = DateTime.Now;
                            data.AddMan = AddUserName;
                            data.CoverImg = user.HeadImg;
                            data.QuestionDescription = user.Summary;
                            data.QuestionDescription = user.Summary;
                            data.IsDisabled = false;
                            data.IsDeleted = true;
                            data.UserID = user.UserID;
                            data.Save(helper);
                        }
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("WechatHandler.ashx", "命令: removesurveyquestion", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savewechatsurveyquestion(HttpContext context)
        {
            int SurveyID = WebUtil.GetIntValue(context, "SurveyID");
            int QuestionID = WebUtil.GetIntValue(context, "QuestionID");
            int UserID = WebUtil.GetIntValue(context, "UserID");
            Foresight.DataAccess.Wechat_SurveyQuestion data = null;
            if (QuestionID > 0)
            {
                data = Foresight.DataAccess.Wechat_SurveyQuestion.GetWechat_SurveyQuestion(QuestionID);
            }
            if (data == null)
            {
                data = new Wechat_SurveyQuestion();
                data.AddMan = WebUtil.GetUser(context).RealName;
                data.AddTime = DateTime.Now;
                data.SurveyID = SurveyID;
                data.UserID = UserID;
            }
            data.QuestionContent = getValue(context, "tdQuestionContent");
            data.QuestionType = getIntValue(context, "tdQuestionType");
            data.SortOrder = getIntValue(context, "tdSortOrder");
            data.QuestionSummary = getValue(context, "tdQuestionSummary");
            data.QuestionDescription = context.Request["HTMLContent"];
            data.IsDisabled = WebUtil.GetIntValue(context, "IsDisabled") == 1;
            string options = context.Request["options"];
            List<Utility.SurveyOption> optionlist = new List<Utility.SurveyOption>();
            if (!string.IsNullOrEmpty(options))
            {
                optionlist = JsonConvert.DeserializeObject<List<Utility.SurveyOption>>(options);
            }
            List<Foresight.DataAccess.Wechat_SurveyQuestionOption> option_list = new List<Wechat_SurveyQuestionOption>();
            foreach (var item in optionlist)
            {
                Foresight.DataAccess.Wechat_SurveyQuestionOption option = null;
                if (item.ID > 0)
                {
                    option = Foresight.DataAccess.Wechat_SurveyQuestionOption.GetWechat_SurveyQuestionOption(item.ID);
                }
                if (option == null)
                {
                    option = new Wechat_SurveyQuestionOption();
                    option.AddTime = DateTime.Now;
                }
                option.OptionContent = item.OptionContent;
                option.SortOrder = item.SortOrder;
                option_list.Add(option);
            }
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                HttpPostedFile postedFile = uploadFiles[0];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string filepath = "/upload/WechatMsg/";
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    data.CoverImg = filepath + fileName;
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    foreach (var item in option_list)
                    {
                        item.SurveyID = data.SurveyID;
                        item.SurveyQuestionID = data.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("WechatHandler", "savewechatsurveyquestion", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removesurveyquestionoption(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Wechat_SurveyQuestionOption.DeleteWechat_SurveyQuestionOption(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getsurveyquestionoptions(HttpContext context)
        {
            int QuestionID = WebUtil.GetIntValue(context, "QuestionID");
            var list = Wechat_SurveyQuestionOption.GetWechat_SurveyQuestionOptionListByQuestionID(QuestionID);
            int count = 0;
            var items = list.Select(p =>
            {
                count++;
                var item = new { ID = p.ID, OptionContent = p.OptionContent, SortOrder = p.SortOrder, count = count };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void getsurveyquestiongrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string TreeIDs = context.Request["TreeIDList"];
                List<int> TreeIDList = JsonConvert.DeserializeObject<List<int>>(TreeIDs);
                int SurveyType = WebUtil.GetIntValue(context, "SurveyType");
                if (SurveyType == 3)
                {
                    DataGrid dg = Wechat_SurveyQuestion.GetWechat_SurveyQuestionPhraseGridByKeywords(Keywords, TreeIDList, "order by [UserID] desc", startRowIndex, pageSize);
                    WebUtil.WriteJson(context, dg);
                }
                else
                {
                    DataGrid dg = Wechat_SurveyQuestion.GetWechat_SurveyQuestionGridByKeywords(Keywords, TreeIDList, "order by SortOrder asc,AddTime asc", startRowIndex, pageSize);
                    WebUtil.WriteJson(context, dg);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler.ashx", "getsurveyquestiongrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
        }
        private void removesurveys(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            if (IDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [Wechat_SurveyProject] where [Wechat_SurveyID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        cmdtext += "delete from [Wechat_SurveyQuestion] where [SurveyID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        cmdtext += "delete from [Wechat_SurveyQuestionOption] where [SurveyID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        cmdtext += "delete from [Wechat_Survey] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("WechatHandler.ashx", "命令: removesurveys", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savewechatsurvey(HttpContext context)
        {
            int SurveyID = WebUtil.GetIntValue(context, "SurveyID");
            Foresight.DataAccess.Wechat_Survey data = null;
            if (SurveyID > 0)
            {
                data = Foresight.DataAccess.Wechat_Survey.GetWechat_Survey(SurveyID);
            }
            if (data == null)
            {
                data = new Wechat_Survey();
                data.AddMan = WebUtil.GetUser(context).RealName;
                data.AddTime = DateTime.Now;
            }
            data.Title = getValue(context, "tdTitle");
            data.Description = getValue(context, "tdDescription");
            data.Status = getIntValue(context, "tdStatus");
            data.StartTime = getTimeValue(context, "tdStartTime");
            data.EndTime = getTimeValue(context, "tdEndTime");
            data.SurveyType = WebUtil.GetIntValue(context, "SurveyType");
            data.IsWechatShow = WebUtil.GetIntValue(context, "IsWechatSend") == 1;
            data.IsAPPCustomerShow = WebUtil.GetIntValue(context, "IsCustomerAPPSend") == 1;
            data.IsAPPUserShow = WebUtil.GetIntValue(context, "IsUserAPPSend") == 1;
            data.ALLVoteLimitCount = 0;
            data.DayVoteLimitCount = getIntValue(context, "tdDayVoteLimitCount");
            data.IsAllowRepeatVote = WebUtil.GetIntValue(context, "IsAllowRepeatVoteYes") == 1;
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                HttpPostedFile postedFile = uploadFiles[0];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string filepath = "/upload/Survey/";
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    data.CoverImg = filepath + fileName;
                }
            }
            string ProjectIDs = context.Request["ProjectIDList"];
            List<int> ProjectIDList = new List<int>();
            if (!string.IsNullOrEmpty(ProjectIDs))
            {
                ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    helper.Execute("delete from [Wechat_SurveyProject] where [Wechat_SurveyID]=" + data.ID + ";", CommandType.Text, new List<SqlParameter>());
                    foreach (var ProjectID in ProjectIDList)
                    {
                        var survery_project = new Wechat_SurveyProject();
                        survery_project.ProjectID = ProjectID;
                        survery_project.Wechat_SurveyID = data.ID;
                        survery_project.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("WechatHandler", "savewechatsurvey", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            foreach (var item in ProjectIDList)
            {

            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getsurveytree(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                int type = WebUtil.GetIntValue(context, "type");
                int SurveyType = WebUtil.GetIntValue(context, "SurveyType");
                var list = Foresight.DataAccess.Wechat_Survey.GetWechat_SurveyListByKeywords(Keywords, type, SurveyType);
                TreeModule treeModule = null;
                var items = list.Select(p =>
                {
                    treeModule = new TreeModule();
                    treeModule.id = "survey_" + p.ID.ToString();
                    treeModule.ID = p.ID;
                    treeModule.pId = "survey_0";
                    treeModule.name = p.Title;
                    treeModule.isParent = false;
                    treeModule.open = true;
                    return treeModule;
                }).ToList();
                treeModule = new TreeModule();
                treeModule.id = "survey_0";
                treeModule.ID = 0;
                treeModule.pId = "0";
                treeModule.name = WebUtil.GetCompany(context).CompanyName;
                bool hasckChild = list.Length > 0;
                treeModule.isParent = hasckChild;
                treeModule.open = hasckChild;
                items.Add(treeModule);
                WebUtil.WriteJson(context, items);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler.ashx", "visit: getsurveytree", ex);
                context.Response.Write("[]");
            }
        }
        private void savewechatnotify(HttpContext context)
        {
            string list_str = context.Request["list"];
            List<Utility.WechatNotifyModel> List = new List<Utility.WechatNotifyModel>();
            if (!string.IsNullOrEmpty(list_str))
            {
                List = JsonConvert.DeserializeObject<List<Utility.WechatNotifyModel>>(list_str);
            }
            List<Foresight.DataAccess.SysConfig> ConfigList = new List<SysConfig>();
            foreach (var item in List)
            {
                if (string.IsNullOrEmpty(item.Value))
                {
                    continue;
                }
                SysConfig config = null;
                if (item.ID > 0)
                {
                    config = SysConfig.GetSysConfig(item.ID);
                }
                if (config == null)
                {
                    config = new SysConfig();
                    config.Name = Foresight.DataAccess.SysConfigNameDefine.WechatFeeNotify.ToString();
                    config.Value = item.Value;
                    config.AddTime = DateTime.Now;
                }
                else
                {
                    config.Value = item.Value;
                }
                ConfigList.Add(config);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in ConfigList)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("WechatHandler", "savewechatnotify", ex);
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removeweixinnotifytemplate(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var template = Foresight.DataAccess.SysConfig.GetSysConfig(ID);
            if (template != null)
            {
                template.Delete();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getweixinnotifytemplates(HttpContext context)
        {
            var list = Foresight.DataAccess.SysConfig.GetSysConfigListByName(Foresight.DataAccess.SysConfigNameDefine.WechatFeeNotify.ToString());
            int count = 0;
            var items = list.Select(p =>
            {
                count++;
                var item = new { ID = p.ID, Value = p.Value, count = count };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void getwechatprojects(HttpContext context)
        {
            string ProjectIDs = context.Request["ProjectIDs"];
            if (!string.IsNullOrEmpty(ProjectIDs))
            {
                List<int> ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
                var projectnames = Foresight.DataAccess.Project.GetProjectListByIDs(ProjectIDList).ToList().Select(p => p.Name);
                WebUtil.WriteJson(context, new { status = true, namestr = string.Join(",", projectnames.ToArray()) });
                return;
            }
            WebUtil.WriteJson(context, new { status = true, namestr = string.Empty });
        }
        private void cancelwechatmsguser(HttpContext context)
        {
            int MsgID = WebUtil.GetIntValue(context, "MsgID");
            if (MsgID <= 0)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "参数错误" });
                return;
            }
            var wechat_msg = Foresight.DataAccess.Wechat_Msg.GetWechat_Msg(MsgID);
            if (wechat_msg == null)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "参数错误" });
                return;
            }
            string strs = context.Request["List"];
            if (string.IsNullOrEmpty(strs))
            {
                WebUtil.WriteJson(context, new { status = false, msg = "参数错误" });
                return;
            }
            List<string> OpenIDList = JsonConvert.DeserializeObject<List<string>>(strs);
            foreach (var OpenID in OpenIDList)
            {
                var msg_user = Foresight.DataAccess.Wechat_MsgUser.GetWechat_MsgUserByOpenID(OpenID, MsgID);
                if (msg_user != null)
                {
                    msg_user.Delete();
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savewechatmsguser(HttpContext context)
        {
            int MsgID = WebUtil.GetIntValue(context, "MsgID");
            if (MsgID <= 0)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "参数错误" });
                return;
            }
            var wechat_msg = Foresight.DataAccess.Wechat_Msg.GetWechat_Msg(MsgID);
            if (wechat_msg == null)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "参数错误" });
                return;
            }
            string strs = context.Request["List"];
            if (string.IsNullOrEmpty(strs))
            {
                WebUtil.WriteJson(context, new { status = false, msg = "参数错误" });
                return;
            }
            List<string> OpenIDList = JsonConvert.DeserializeObject<List<string>>(strs);
            foreach (var OpenID in OpenIDList)
            {
                var msg_user = Foresight.DataAccess.Wechat_MsgUser.GetWechat_MsgUserByOpenID(OpenID, MsgID);
                if (msg_user == null)
                {
                    msg_user = new Foresight.DataAccess.Wechat_MsgUser();
                    msg_user.Wechat_MsgID = wechat_msg.ID;
                    msg_user.OpenID = OpenID;
                    msg_user.AddTime = DateTime.Now;
                    msg_user.Save();
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void cancelsubscribe(HttpContext context)
        {
            string Liststr = context.Request["List"];
            List<Utility.CancelSubscribeModel> List = JsonConvert.DeserializeObject<List<Utility.CancelSubscribeModel>>(Liststr);
            foreach (var item in List)
            {
                var userproject = Foresight.DataAccess.WechatUser_Project.GetWechatUser_Project(item.RoomID, item.OpenID);
                if (userproject != null)
                {
                    userproject.Delete();
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getpayqrcode(HttpContext context)
        {
            string payurl = context.Request["payurl"];
            if (!payurl.ToLower().Contains("weixin://"))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "payurl不合法");
                return;
            }
            string squarePicUrl = string.Empty;
            string QrcodePath = WeixinHelper.CreateQrCode(payurl, out squarePicUrl);
            string FullPath = WebUtil.GetContextPath() + QrcodePath;
            WebUtil.WriteJsonResult(context, new { payurl = FullPath });
        }
        private void gethuishouyinstatus(HttpContext context)
        {
            string hy_bill_no = context.Request["hy_bill_no"];
            if (string.IsNullOrEmpty(hy_bill_no))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "hy_bill_no为空");
                return;
            }
            var huireturn = Foresight.DataAccess.HuiShouYinReturn.GetHuiShouYinReturn(hy_bill_no);
            if (huireturn == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "汇收银未返回数据");
                return;
            }
            if (!string.IsNullOrEmpty(huireturn.OpenID))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "已收款");
                return;
            }
            if (!huireturn.trade_status.ToLower().Equals("success"))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "收款状态: " + huireturn.trade_status);
                return;
            }
            huireturn.OpenID = GetOpenID(context);
            huireturn.Save();
            WebUtil.WriteJsonResult(context, "收款成功");
        }
        private void huishouyinreadypay(HttpContext context)
        {
            try
            {
                int total_fee = Convert.ToInt32(WebUtil.GetDecimalValue(context, "total_fee") * 100);
                string idlist = context.Request["idlist"];
                var biz_content = new HuiShouYin.Domain.ApplyPay_BizContent();
                biz_content.out_trade_no = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                biz_content.subject = ConfigurationManager.AppSettings["CompanyName"];
                biz_content.total_fee = total_fee.ToString();
                biz_content.client_ip = "127.0.0.1";
                biz_content.notify_url = WebUtil.GetContextPath() + "/recive/pay/notify.aspx";
                biz_content.return_url = WebUtil.GetContextPath() + "/recive/pay/return.aspx";
                biz_content.channel_type = "101";
                List<Utility.WeiXinPayModel> ListOption = JsonConvert.DeserializeObject<List<Utility.WeiXinPayModel>>(idlist);
                if (ListOption.Count > 0)
                {
                    string liststr = string.Empty;
                    liststr += "[";
                    for (int i = 0; i < ListOption.Count; i++)
                    {
                        var option = ListOption[i];
                        DateTime FinalEndTime = DateTime.MinValue;
                        if (option.EndTime.HasValue)
                        {
                            FinalEndTime = Convert.ToDateTime(option.EndTime);
                        }
                        liststr += "{\\\"ID\\\":" + option.ID + ",\\\"EndTime\\\":\\\"" + FinalEndTime.ToString("yyyy-MM-dd") + "\\\"}";
                        if (i < ListOption.Count - 1)
                        {
                            liststr += ",";
                        }
                    }
                    liststr += "]";
                    biz_content.pay_option = "{\\\"idlist\\\":" + liststr + ",\\\"openid\\\":\\\"" + GetOpenID(context) + "\\\"}";
                }
                var response = HuiShouYin.MessageHandler.SendApplyPay(biz_content);
                if (response.IsError)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器内部异常");
                    return;
                }
                var items = new { hsy_enable = true, payurl = response.ApplyPay.hy_js_auth_pay_url, hy_bill_no = response.ApplyPay.hy_bill_no };
                WebUtil.WriteJson(context, items);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler", "huifubaoreadypay", ex);
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器内部异常");
            }
        }
        private void sendweixinmsg(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [Wechat_Msg] set [IsSending]=1,SendingMan=@SendingMan where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    string SendingMan = WebUtil.GetUser(context).RealName;
                    SendingMan = string.IsNullOrEmpty(SendingMan) ? "管理员" : SendingMan;
                    parameters.Add(new SqlParameter("@SendingMan", SendingMan));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("WechatHandler", "命令: sendweixinmsg", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void cancelroombyroomid(HttpContext context)
        {
            string openid = GetOpenID(context);
            if (string.IsNullOrEmpty(openid))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "获取用户信息失败,请在微信端打开此页面");
                return;
            }
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [WechatUser_Project] where OpenID=@OpenID and ProjectID=@RoomID";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@OpenID", openid));
                    parameters.Add(new SqlParameter("@RoomID", RoomID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("WechatHandler", "visit: cancelroombyroomid", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "取消关联成功");
        }
        private void getroomlistbyopenid(HttpContext context)
        {
            string openid = GetOpenID(context);
            if (string.IsNullOrEmpty(openid))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "获取用户信息失败,请在微信端打开此页面");
                return;
            }
            ViewRoomBasic[] roomlist = ViewRoomBasic.GetRoomBasicListByOpenID(openid);
            var RoomID = WebUtil.GetIntValue(context, "RoomID");
            if (RoomID > 0)
            {
                roomlist = roomlist.Where(p => p.RoomID == RoomID).ToArray();
            }
            WebUtil.WriteJsonResult(context, new { roomlist = roomlist });
        }
        private void getfeehistorybyprintid(HttpContext context)
        {
            int printid = WebUtil.GetIntValue(context, "printid");
            var list = ViewRoomFeeHistory.GetViewRoomFeeHistoryListByPrintID(printid);
            if (list.Length > 0)
            {
                string RelationName = list[0].RelationName;
                string RoomName = list[0].RoomName;
                string FullName = list[0].FullName;
                decimal TotalCost = list.Sum(p => p.RealCost);
                WebUtil.WriteJsonResult(context, new { RelationName = RelationName, RoomName = RoomName, FullName = FullName, historylist = list, TotalCost = TotalCost });
            }
            else
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "list为空");
            }
        }
        private void savewechatcontact(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string type = context.Request["type"];
            Foresight.DataAccess.Wechat_Contact contact = null;
            if (ID > 0)
            {
                contact = Wechat_Contact.GetWechat_Contact(ID);
            }
            if (contact == null)
            {
                contact = new Wechat_Contact();
                contact.AddTime = DateTime.Now;
                contact.AddMan = context.Request.Params["AddMan"];
            }
            if (!string.IsNullOrEmpty(type))
            {
                contact.PhoneType = type;
                contact.CategoryID = 0;
            }
            else
            {
                contact.PhoneType = string.Empty;
                contact.CategoryID = WebUtil.GetIntValue(context, "PhoneType");
            }
            contact.Name = context.Request.Params["Name"];
            contact.PhoneNumber = context.Request.Params["PhoneNumber"];
            contact.Remark = context.Request.Params["Remark"];
            string ProjectIDs = context.Request["ProjectIDs"];
            List<Wechat_ContactProject> msgproject_list = new List<Wechat_ContactProject>();
            if (!string.IsNullOrEmpty(ProjectIDs))
            {
                List<int> ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
                if (contact.ID > 0)
                {
                    var exist_projectid_list = Foresight.DataAccess.Wechat_ContactProject.GetWechat_ContactProjectList(contact.ID).Select(p => p.ProjectID).ToList();
                    foreach (var ProjectID in ProjectIDList)
                    {
                        if (!exist_projectid_list.Contains(ProjectID))
                        {
                            var msgproject = new Wechat_ContactProject();
                            msgproject.ProjectID = ProjectID;
                            msgproject_list.Add(msgproject);
                        }
                    }
                }
                else
                {
                    foreach (var ProjectID in ProjectIDList)
                    {
                        var msgproject = new Wechat_ContactProject();
                        msgproject.ProjectID = ProjectID;
                        msgproject_list.Add(msgproject);
                    }
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    contact.Save(helper);
                    foreach (var item in msgproject_list)
                    {
                        item.WechatContactID = contact.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("WechatHandler", "savewechatcontact", ex);
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removewechatcontact(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Wechat_Contact] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("UserHandler", "命令: removewechatcontact", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void loadwechatcontactgrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> EqualProjectIDList = new List<int>();
                List<int> InProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    List<int> MyProjectIDList = new List<int>();
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        MyProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    Web.APPCode.CacheHelper.GetMyProjectListByUserID(WebUtil.GetUser(context).UserID, out EqualProjectIDList, out InProjectIDList, ProjectIDList: MyProjectIDList);
                }
                string PhoneType = context.Request["PhoneType"];
                DataGrid dg = Wechat_ContactDetail.GetWechat_ContactGridByKeywords(Keywords, "order by AddTime desc", startRowIndex, pageSize, EqualProjectIDList: EqualProjectIDList, PhoneType: PhoneType);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler", "命令: loadwechatcontactgrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void getroomfeebyid(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "id");
            DateTime EndTime = WebUtil.GetDateValue(context, "endtime");
            var roomfee = RoomFeeAnalysis.GetRoomFeeAnalysisByEndTime(ID, EndTime);
            var totalcost = roomfee == null ? 0 : roomfee.TotalCost;
            WebUtil.WriteJsonResult(context, new { TotalCost = totalcost });
        }
        private void deletemsg(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Wechat_Msg] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("WechatHandler", "命令: deletemsg", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void deleteconver(HttpContext context)
        {
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            if (ID > 0)
            {
                var msg = Foresight.DataAccess.Wechat_Msg.GetWechat_Msg(ID);
                if (msg != null)
                {
                    msg.PicPath = "";
                    msg.Save();
                    WebUtil.WriteJson(context, new { status = true });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = false });
        }
        private void loadwechatmsgcover(HttpContext context)
        {
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            if (ID > 0)
            {
                var msg = Foresight.DataAccess.Wechat_Msg.GetWechat_Msg(ID);
                if (msg != null && !string.IsNullOrEmpty(msg.PicPath))
                {
                    WebUtil.WriteJson(context, new { status = true, PicPath = WebUtil.GetContextPath() + msg.PicPath });
                    return;
                }
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            WebUtil.WriteJson(context, new { status = false });
        }
        private void savewechatmsg(HttpContext context)
        {
            Foresight.DataAccess.Wechat_Msg msg = null;
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            string guid = context.Request["guid"];
            if (ID > 0)
            {
                msg = Foresight.DataAccess.Wechat_Msg.GetWechat_Msg(ID);
            }
            if (msg == null)
            {
                msg = new Wechat_Msg();
                msg.AddTime = DateTime.Now;
                msg.IsSending = false;
            }
            msg.MsgTitle = getValue(context, "tdTitle");
            msg.MsgSummary = getValue(context, "tdSummary");
            msg.MsgContent = context.Request["MsgContent"];
            msg.HTMLContent = context.Request["HTMLContent"];
            msg.PublishTime = getTimeValue(context, "tdPublishTime");
            msg.SortOrder = getIntValue(context, "tdSortOrder");
            msg.IsShow = getIntValue(context, "tdIsShow") == 1 ? true : false;
            msg.IsWechatSend = WebUtil.GetIntValue(context, "IsWechatSend") == 1 ? true : false;
            msg.IsCustomerAPPSend = WebUtil.GetIntValue(context, "IsCustomerAPPSend") == 1 ? true : false;
            msg.IsUserAPPSend = WebUtil.GetIntValue(context, "IsUserAPPSend") == 1 ? true : false;
            msg.IsBusinessAPPSend = WebUtil.GetIntValue(context, "IsBusinessAPPSend") == 1 ? true : false;
            msg.MsgType = context.Request.Params["MsgType"];
            msg.IsTopShow = getIntValue(context, "tdIsTopShow") == 1 ? true : false;
            msg.StartTime = getTimeValue(context, "tdStartTime");
            msg.EndTime = getTimeValue(context, "tdEndTime");
            msg.CategoryID = getIntValue(context, "tdCategoryID");
            if (msg.IsWechatSend && msg.MobileSendTime == DateTime.MinValue)
            {
                msg.IsSending = true;
            }
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                HttpPostedFile postedFile = uploadFiles[0];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string filepath = "/upload/WechatMsg/";
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    msg.PicPath = filepath + fileName;
                }
            }
            string ProjectIDs = context.Request["ProjectIDs"];
            List<Wechat_MsgProject> msgproject_list = new List<Wechat_MsgProject>();
            if (!string.IsNullOrEmpty(ProjectIDs))
            {
                List<int> ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
                if (msg.ID > 0)
                {
                    var exist_projectid_list = Foresight.DataAccess.Wechat_MsgProject.GetWechat_MsgProjectList(msg.ID).Select(p => p.ProjectID).ToList();
                    foreach (var ProjectID in ProjectIDList)
                    {
                        if (!exist_projectid_list.Contains(ProjectID))
                        {
                            var msgproject = new Wechat_MsgProject();
                            msgproject.ProjectID = ProjectID;
                            msgproject_list.Add(msgproject);
                        }
                    }
                }
                else
                {
                    foreach (var ProjectID in ProjectIDList)
                    {
                        var msgproject = new Wechat_MsgProject();
                        msgproject.ProjectID = ProjectID;
                        msgproject_list.Add(msgproject);
                    }
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    msg.Save(helper);
                    foreach (var item in msgproject_list)
                    {
                        item.MsgID = msg.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("WechatHandler", "savewechatmsg", ex);
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true, ID = msg.ID });
        }
        private void getmsglist(HttpContext context)
        {
            string Keywords = context.Request.Params["keywords"];
            string msgtype = context.Request.Params["msgtype"];
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            int type = WebUtil.GetIntValue(context, "type");
            int msgtypeid = WebUtil.GetIntValue(context, "msgtypeid");
            string RoomIDs = context.Request.Params["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            string ProjectIDs = context.Request.Params["ProjectIDs"];
            List<int> EqualProjectIDList = new List<int>();
            List<int> InProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                List<int> MyProjectIDList = new List<int>();
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    MyProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                Web.APPCode.CacheHelper.GetMyProjectListByUserID(WebUtil.GetUser(context).UserID, out EqualProjectIDList, out InProjectIDList, ProjectIDList: MyProjectIDList);
            }
            DataGrid dg = Wechat_Msg.GeWechat_MsgGridByKeywords(Keywords, msgtype, "order by [AddTime] desc", startRowIndex, pageSize, type, msgtypeid, EqualProjectIDList: EqualProjectIDList);
            string result = JsonConvert.SerializeObject(dg);
            context.Response.Write(result);
        }
        private void wxconnectroom(HttpContext context)
        {
            string PhoneNumber = context.Request.Params["PhoneNumber"];
            string VerifyCode = context.Request.Params["VerifyCode"];
            string OpenID = GetOpenID(context);
            var list = Foresight.DataAccess.Project.GetProjectListByPhoneNumber(PhoneNumber);
            if (list.Length > 0)
            {
                var wechatVerifyCode = Wechat_VerifyCode.GetWechat_VerifyCodeByUserOpenId(OpenID, PhoneNumber, DateTime.MinValue);
                if (wechatVerifyCode == null || !wechatVerifyCode.VerifyCode.Equals(VerifyCode))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您输入的验证码有误");
                    return;
                }
                List<WechatUser_Project> wProjectList = new List<WechatUser_Project>();
                foreach (var project in list)
                {
                    var wProject = WechatUser_Project.GetWechatUser_Project(project.ID, OpenID);
                    if (wProject != null)
                    {
                        continue;
                    }
                    wProject = new WechatUser_Project();
                    wProject.ProjectID = project.ID;
                    wProject.OpenID = OpenID;
                    wProjectList.Add(wProject);
                }
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        wechatVerifyCode.IsUsed = true;
                        wechatVerifyCode.Save(helper);
                        foreach (var item in wProjectList)
                        {
                            item.Save(helper);
                        }
                        helper.Commit();
                        WebUtil.WriteJsonResult(context, "房间关联成功");
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("WechatHandler", "wxconnectroom", ex);
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器异常");
                    }
                }
            }
            else
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您输入的号码未关联任何房源");
            }
        }
        private void sendverifycode(HttpContext context)
        {
            try
            {
                string PhoneNumber = context.Request.Params["PhoneNumber"].ToString();
                Random rnd = new Random();
                string verifycode = rnd.Next(1000, 9999).ToString();
                //发送短信验证码start               
                string content = "您正在进行登录验证，验证码" + verifycode + "，请在15分钟内按页面提示提交验证码，切勿将验证码泄露于他人。";
                string restcount = string.Empty;
                bool issent = Utility.KXTSms.Send(PhoneNumber, content, out restcount);
                //bool issent = SendMessageType.SendVerifyCode(content, mobiles, out verifycode);
                //发送短信验证码end
                string OpenID = GetOpenID(context);
                if (issent)
                {
                    Foresight.DataAccess.Wechat_VerifyCode.SaveWechatVerifyCode(PhoneNumber, verifycode, SendResult: restcount, OpenID: OpenID);
                    WebUtil.WriteJsonResult(context, "发送成功");
                }
                else
                {
                    LogHelper.WriteInfo("发送短信系统异常", verifycode);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "发送短信系统异常，请稍候再试");
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Login", "发送验证码失败", ex);
                WebUtil.WriteJsonResult(context, 4);
            }
        }
        private void checkphonestatus(HttpContext context)
        {
            var PhoneNumber = context.Request.Params["PhoneNumber"];
            var list = Foresight.DataAccess.Project.GetProjectListByPhoneNumber(PhoneNumber);
            if (list.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "号码未关联房间");
                return;
            }
            string OpenID = GetOpenID(context);
            bool EnableSMS = new SiteConfig().SmsServerEnable;
            if (EnableSMS)
            {
                WebUtil.WriteJsonResult(context, new { EnableSMS = EnableSMS });
                return;
            }
            List<WechatUser_Project> wProjectList = new List<WechatUser_Project>();
            foreach (var project in list)
            {
                var wProject = WechatUser_Project.GetWechatUser_Project(project.ID, OpenID);
                if (wProject != null)
                {
                    continue;
                }
                wProject = new WechatUser_Project();
                wProject.ProjectID = project.ID;
                wProject.OpenID = OpenID;
                wProjectList.Add(wProject);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in wProjectList)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("WechatHandler", "checkphonestatus", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器异常");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, new { EnableSMS = EnableSMS });
        }
        private void savezhuangxiu(HttpContext context)
        {
            try
            {
                int serviceid = 0;
                int.TryParse(context.Request["serviceid"], out serviceid);
                string OpenID = GetOpenID(context);
                Foresight.DataAccess.Wechat_ZhuangXiu service = Foresight.DataAccess.Wechat_ZhuangXiu.GetWechat_ZhuangXiu(serviceid);
                if (service == null)
                {
                    service = new Foresight.DataAccess.Wechat_ZhuangXiu();
                    service.AddTime = DateTime.Now;
                }
                service.ZXMonth = WebUtil.GetIntValue(context, "ZXMonth");
                service.SGFDW = context.Request.Params["SGFDW"];
                service.SGFFZR = context.Request.Params["SGFFZR"];
                service.SGFLXDH = context.Request.Params["SGFLXDH"];
                service.ZXXM = context.Request.Params["ZXXM"];
                service.OpenID = OpenID;
                string MediaIds = context.Request["mediaids"];
                if (string.IsNullOrEmpty(MediaIds))
                {
                    service.Save();
                    WebUtil.WriteJsonResult(context, new { status = true, serviceid = service.ID });
                    return;
                }
                List<string> ListMediaIds = JsonConvert.DeserializeObject<List<string>>(MediaIds);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        service.Save(helper);
                        foreach (var MediaID in ListMediaIds)
                        {
                            WeixinHelper.SaveImgbyMediaid(service.ID, MediaID, OpenID, helper);
                        }
                        helper.Commit();
                        WebUtil.WriteJsonResult(context, new { status = true, serviceid = service.ID });
                        return;
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("WechatHandler", "savezhuangxiu", ex);
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器异常");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("APIHandler", "savezhuangxiu", ex);
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器异常");
            }
        }
        private void saveyanshou(HttpContext context)
        {
            try
            {
                int serviceid = 0;
                int.TryParse(context.Request["serviceid"], out serviceid);
                string OpenID = GetOpenID(context);
                Foresight.DataAccess.Wechat_YanShou service = Foresight.DataAccess.Wechat_YanShou.GetWechat_YanShou(serviceid);
                if (service == null)
                {
                    service = new Foresight.DataAccess.Wechat_YanShou();
                    service.AddTime = DateTime.Now;
                }
                service.SBDS = WebUtil.GetDecimalValue(context, "sbds");
                service.DBDS = WebUtil.GetDecimalValue(context, "dbds");
                service.QBDS = WebUtil.GetDecimalValue(context, "qbds");
                service.YSResult = context.Request.Params["ysjg"];
                service.YSContent = context.Request.Params["ysyj"];
                service.OpenID = GetOpenID(context);
                string MediaIds = context.Request["mediaids"];
                if (string.IsNullOrEmpty(MediaIds))
                {
                    service.Save();
                    WebUtil.WriteJsonResult(context, new { status = true, serviceid = service.ID });
                    return;
                }
                List<string> ListMediaIds = JsonConvert.DeserializeObject<List<string>>(MediaIds);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        service.Save(helper);
                        foreach (var MediaID in ListMediaIds)
                        {
                            WeixinHelper.SaveImgbyMediaid(service.ID, MediaID, OpenID, helper);
                        }
                        helper.Commit();
                        WebUtil.WriteJsonResult(context, new { status = true, serviceid = service.ID });
                        return;
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("WechatHandler", "saveyanshou", ex);
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器异常");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("APIHandler", "saveyanshou", ex);
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器异常");
            }
        }
        private void saveservice(HttpContext context)
        {
            try
            {
                int serviceid = 0;
                int.TryParse(context.Request["serviceid"], out serviceid);
                string OpenID = GetOpenID(context);
                var wechat = Foresight.DataAccess.Wechat_User.GetWechat_UserByUserOpenID(OpenID);
                Foresight.DataAccess.Wechat_Service service = Foresight.DataAccess.Wechat_Service.GetWechat_Service(serviceid);
                if (service == null)
                {
                    service = new Foresight.DataAccess.Wechat_Service();
                    service.AddTime = DateTime.Now;
                }
                service.ServiceType = context.Request.Params["ServiceType"];
                service.ServiceType = string.IsNullOrEmpty(service.ServiceType) ? Utility.EnumModel.WechatServiceType.bsbx.ToString() : service.ServiceType;
                service.ServiceContent = context.Request.Params["ServiceContent"];
                service.ServiceAddTime = WebUtil.GetDateValue(context, "ServiceAddTime");
                service.PhoneNumber = context.Request.Params["PhoneNumber"];
                service.RoomID = WebUtil.GetIntValue(context, "RoomID");
                service.OpenID = OpenID;
                service.ServiceFrom = Utility.EnumModel.WechatServiceFromDefine.weixin.ToString();
                if (service.RoomID > 0)
                {
                    var project = Foresight.DataAccess.Project.GetProject(service.RoomID);
                    service.FullName = project == null ? "" : project.FullName + "-" + project.Name;
                }
                string token = context.Request["token"];
                string MediaIds = context.Request["mediaids"];
                var customer_service = new Foresight.DataAccess.CustomerService();
                customer_service.AddTime = DateTime.Now;
                customer_service.StartTime = DateTime.Now;
                customer_service.AddMan = wechat != null ? wechat.NickName : OpenID;
                customer_service.AddUserName = wechat != null ? wechat.NickName : OpenID;
                customer_service.ServiceFrom = service.ServiceFrom;
                customer_service.ServiceFullName = service.FullName;
                customer_service.ProjectName = "无";
                customer_service.ProjectID = service.RoomID;
                string ServiceTypeDesc = Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatServiceType), service.ServiceType);
                var type = Foresight.DataAccess.ServiceType.GetServiceTypes().FirstOrDefault(p => ServiceTypeDesc.Contains(p.ServiceTypeName));
                customer_service.ServiceTypeID = type != null ? type.ID : int.MinValue;
                customer_service.ServiceTypeName = type != null ? type.ServiceTypeName : string.Empty;
                customer_service.AddCustomerName = !string.IsNullOrEmpty(service.ServiceMan) ? service.ServiceMan : (wechat != null ? wechat.NickName : "");
                customer_service.ServiceContent = service.ServiceContent;
                customer_service.ServiceAppointTime = service.AddTime;
                customer_service.AddCallPhone = service.PhoneNumber;
                customer_service.ServiceAccpetManID = JsonConvert.SerializeObject(new int[] { service.AddUserID });
                customer_service.ServiceStatus = 3;
                customer_service.IsAPPShow = true;
                if (service.AddUserID > 0)
                {
                    var user = Foresight.DataAccess.User.GetUser(service.AddUserID);
                    customer_service.ServiceAccpetMan = user != null ? user.RealName : "";
                }
                List<string> ListMediaIds = new List<string>();
                if (!string.IsNullOrEmpty(MediaIds))
                {
                    ListMediaIds = JsonConvert.DeserializeObject<List<string>>(MediaIds);
                }
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        service.Save(helper);
                        customer_service.WechatServiceID = service.ID;
                        customer_service.Save(helper);
                        foreach (var MediaID in ListMediaIds)
                        {
                            WeixinHelper.SaveImgbyMediaid(service.ID, MediaID, OpenID, helper);
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("WechatHandler", "saveservice", ex);
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器异常");
                        return;
                    }
                }
                List<Foresight.DataAccess.CustomerServiceAttach> attachlist = new List<Foresight.DataAccess.CustomerServiceAttach>();
                var wechat_service_attachlist = Foresight.DataAccess.Wechat_ServiceImg.GetWechat_ServiceImgList(service.ID);
                foreach (var item in wechat_service_attachlist)
                {
                    Foresight.DataAccess.CustomerServiceAttach attach = new Foresight.DataAccess.CustomerServiceAttach();
                    attach.FileOriName = item.FileName;
                    attach.AttachedFilePath = item.Large;
                    attach.AddTime = DateTime.Now;
                    attachlist.Add(attach);
                }
                foreach (var item in attachlist)
                {
                    item.ServiceID = customer_service.ID;
                    item.Save();
                }
                WebUtil.WriteJsonResult(context, new { status = true, serviceid = service.ID });
                return;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("APIHandler", "saveservice", ex);
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器异常");
                return;
            }
        }
        private void wxpayroomfeecomplete(HttpContext context)
        {
            string OpenID = GetOpenID(context);
            var wuser = Foresight.DataAccess.Wechat_User.GetWechat_UserByUserOpenID(OpenID);
            string AddMan = (wuser != null && !string.IsNullOrEmpty(wuser.NickName)) ? wuser.NickName : OpenID;
            PrintRoomFeeHistory printRoomFeeHistory = new PrintRoomFeeHistory();
            string liststr = context.Request.Params["idlist"];
            if (string.IsNullOrEmpty(liststr))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "需要支付的费项不存在");
                return;
            }
            List<Utility.WeiXinPayModel> ModelList = JsonConvert.DeserializeObject<List<Utility.WeiXinPayModel>>(liststr);
            if (ModelList.Count == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "需要支付的费项不存在");
                return;
            }
            int RoomID = 0;
            string AllParentID = string.Empty;
            var list = new List<RoomFeeAnalysis>();
            foreach (var item in ModelList)
            {
                DateTime FinalEndTime = DateTime.MinValue;
                if (item.EndTime.HasValue)
                {
                    FinalEndTime = Convert.ToDateTime(item.EndTime);
                }
                var viewRoomFee = RoomFeeAnalysis.GetRoomFeeAnalysisByEndTime(item.ID, FinalEndTime);
                list.Add(viewRoomFee);
                RoomID = viewRoomFee.RoomID;
                AllParentID = viewRoomFee.AllParentID;
            }
            if (list.Count == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "需要支付的费项不存在");
                return;
            }
            var ConfigName = SysConfigNameDefine.WeixinChargeMan;
            var sysConfigList = SysConfig.Get_SysConfigListByProjectIDList(MinProjectID: RoomID, MaxProjectID: RoomID, ConfigName: ConfigName);
            string ChargeMan = SysConfig.GetConfigValueByList(sysConfigList, ConfigName, AllParentID: AllParentID);
            decimal TotalCost = list.Sum(p => p.TotalCost);
            var ViewChargeSummaryList = ViewChargeSummary.GetViewChargeSummaries().ToArray();
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    SavePrintRoomFeeHistory(context, printRoomFeeHistory, list[0].RoomID, TotalCost, ChargeMan, helper);
                    foreach (var item in list)
                    {
                        var roomFee = Foresight.DataAccess.RoomFee.GetRoomFee(item.ID, helper);
                        roomFee.RealCost = item.TotalCost;
                        roomFee.Cost = item.TotalCost;
                        roomFee.EndTime = item.CalculateEndTime;
                        roomFee.UseCount = item.CalculateUseCount;
                        roomFee.Remark = "微信支付";
                        roomFee.IsCharged = true;
                        roomFee.Save(helper);
                        #region 收费后续操作
                        Web.APPCode.HandlerHelper.SaveRoomFee(roomFee, OpenID, helper, printRoomFeeHistory, ViewChargeSummaryList, OpenID: OpenID);
                        #endregion
                    }
                    helper.Commit();
                    var items = new { status = true, PrintID = printRoomFeeHistory.ID };
                    WebUtil.WriteJsonResult(context, items);
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("WechatHandler", "visit: wxpayroomfeecomplete;liststr:" + liststr, ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex);
                }
            }
        }
        private void deleteservice(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            if (string.IsNullOrEmpty(IDs) || IDs.Equals("[]"))
            {
                WebUtil.WriteJson(context, new { status = true });
                return;
            }
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Wechat_Service] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("WechatHandler", "visit: deleteservice", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void getservicelist(HttpContext context)
        {
            string Keywords = context.Request.Params["keywords"];
            string ServiceType = context.Request.Params["servicetype"];
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            DataGrid dg = Wechat_ServiceDetail.GeWechat_ServiceGridByKeywords(Keywords, ServiceType, "order by [AddTime] desc", startRowIndex, pageSize);
            string result = JsonConvert.SerializeObject(dg);
            context.Response.Write(result);
        }
        private void wxpayroomfeeready(HttpContext context)
        {
            var config = new Utility.SiteConfig();
            bool HuiShouYin_Enable = false;
            bool.TryParse(config.HuiShouYin_Enable, out HuiShouYin_Enable);
            if (HuiShouYin_Enable)
            {
                huishouyinreadypay(context);
                return;
            }
            JsApiPay jsApiPay = new JsApiPay(null);
            jsApiPay.openid = GetOpenID(context);
            int total_fee = Convert.ToInt32(WebUtil.GetDecimalValue(context, "total_fee") * 100);
            //total_fee = 1;
            jsApiPay.total_fee = total_fee;
            string body = context.Request["contentbody"];
            if (string.IsNullOrEmpty(body))
            {
                var company = WebUtil.GetCompany(context);
                body = company != null ? company.CompanyName : ConfigurationManager.AppSettings["CompanyName"];
            }
            try
            {
                string notify_url = WebUtil.GetContextPath() + "/recive/wx/paycallback.aspx";
                string tradeno = WxPayApi.GenerateOutTradeNo();
                WxPayData unifiedOrderResult = jsApiPay.GetUnifiedOrderResult(body, tradeno, notify_url);
                string wxJsApiParam = jsApiPay.GetJsApiParameters();//获取H5调起JS API参数
                LogHelper.WriteInfo("wxJsApiParam", wxJsApiParam);
                context.Response.Write(wxJsApiParam);
                //WebUtil.WriteJsonResult(context, new { wxJsApiParam = wxJsApiParam });
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WechatHandler", "wxpayroomfeeready", ex);
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex);
            }
        }
        private void getroomfeehistorybyopenid(HttpContext context)
        {
            string openid = GetOpenID(context);
            if (string.IsNullOrEmpty(openid))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "获取用户信息失败,请在微信端打开此页面");
                return;
            }
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            var historylist = Foresight.DataAccess.PrintRoomFeeHistory.GetPrintRoomFeeHistoryListByOpenID(openid, RoomID).Where(p => p.RealCost > 0).OrderByDescending(p => p.RealCost).OrderByDescending(p => p.ChargeTime);
            List<RoomFeeModel> list = new List<RoomFeeModel>();
            RoomFeeModel roomFeeModel = null;
            var chargetypelist = Foresight.DataAccess.ChargeMoneyType.GetChargeMoneyTypes();
            var summarylist = Foresight.DataAccess.ChargeSummary.GetChargeSummaries();
            foreach (var fee in historylist)
            {
                var chargetype = chargetypelist.FirstOrDefault(p => p.ChargeTypeID == fee.ChageType1);
                string ChargeTypeName = chargetype == null ? "" : chargetype.ChargeTypeName;
                if (fee.RealMoneyCost2 > 0)
                {
                    chargetype = chargetypelist.FirstOrDefault(p => p.ChargeTypeID == fee.ChageType2);
                    if (chargetype != null)
                    {
                        ChargeTypeName += "&" + chargetype.ChargeTypeName;
                    }
                }
                roomFeeModel = new RoomFeeModel();
                roomFeeModel.ID = fee.ID;
                roomFeeModel.Name = ChargeTypeName;
                roomFeeModel.TotalCost = fee.RealCost;
                roomFeeModel.StartTime = fee.ChargeTime == DateTime.MinValue ? "" : fee.ChargeTime.ToString("yyyy-MM-dd HH:mm");
                roomFeeModel.PrintID = fee.ID;
                roomFeeModel.historylist = Foresight.DataAccess.ViewRoomFeeHistory.GetViewRoomFeeHistoryListByPrintID(fee.ID);
                list.Add(roomFeeModel);
            }
            WebUtil.WriteJsonResult(context, list);
        }
        private void getroomfeebyopenid(HttpContext context)
        {
            string openid = GetOpenID(context);
            if (string.IsNullOrEmpty(openid))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "获取用户信息失败,请在微信端打开此页面");
                return;
            }
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            ViewRoomBasic[] roomlist = new ViewRoomBasic[] { };
            if (RoomID <= 0)
            {
                roomlist = ViewRoomBasic.GetRoomBasicListByOpenID(openid);
                if (roomlist.Length == 0)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "未关联房间");
                    return;
                }
                RoomID = roomlist[0].RoomID;
            }
            bool showall = false;
            bool.TryParse(context.Request.Params["showall"], out showall);
            if (showall)
            {
                RoomID = 0;
            }
            var feelist = ViewRoomFee.GetViewRoomFeeListByOpenID(openid, RoomID).Where(p => p.TotalCost > 0);
            var summaryidlist = feelist.Select(p => p.ChargeID).ToList();
            var summarylist = ChargeSummary.GetChargeSummaries();
            List<RoomFeeModel> list = new List<RoomFeeModel>();
            RoomFeeModel roomFeeModel = null;
            decimal HeJiCost = 0;
            foreach (var fee in feelist)
            {
                roomFeeModel = new RoomFeeModel();
                roomFeeModel.ID = fee.ID;
                roomFeeModel.Name = fee.Name;
                roomFeeModel.TotalCost = fee.TotalCost > 0 ? fee.TotalCost : 0;
                roomFeeModel.StartTime = fee.CalculateStartTime > DateTime.MinValue ? fee.CalculateStartTime.ToString("yyyy-MM-dd") : "";
                roomFeeModel.EndTime = fee.CalculateEndTime > DateTime.MinValue ? fee.CalculateEndTime.ToString("yyyy-MM-dd") : "";
                if (fee.IsReading)
                {
                    roomFeeModel.StartEndPoint = fee.FinalStartPoint + "/" + fee.FinalEndPoint;
                }
                list.Add(roomFeeModel);
                HeJiCost += roomFeeModel.TotalCost;
            }
            roomFeeModel = new RoomFeeModel();
            roomFeeModel.Name = "合计";
            roomFeeModel.TotalCost = HeJiCost;
            var wechat_contact = Foresight.DataAccess.Wechat_Contact.GetWechat_ContactByPhoneType(Utility.EnumModel.WechatContactType.hujiaowuye.ToString());
            WebUtil.WriteJsonResult(context, new { summarylist = list, idlist = feelist.Select(p => p.ID).ToList(), HeJiCost = HeJiCost, roomlist = roomlist, totalsummary = roomFeeModel, wechat_contact = wechat_contact != null ? wechat_contact.PhoneNumber : "", wechat_contact_title = wechat_contact != null ? wechat_contact.Name : "" });
        }
        private void viewqrcode(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string PicPath = WeixinHelper.CreateQrCode(ID);
            WebUtil.WriteJson(context, new { status = string.IsNullOrEmpty(PicPath) ? false : true, PicPath = WebUtil.GetContextPath() + PicPath });
        }
        private void disconnectroom(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var wechatuser = Wechat_User.GetWechat_User(ID);
            if (wechatuser == null)
            {
                WebUtil.WriteJson(context, new { status = true, msg = "ID不合法" });
                return;
            }
            string RoomIDs = context.Request.Params["RoomIDList"];
            List<int> RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [WechatUser_Project] where OpenID=@OpenID and ProjectID in (" + string.Join(",", RoomIDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@OpenID", wechatuser.OpenId));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("WechatHandler", "visit: disconnectroom", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true, msg = "取消关联成功" });
        }
        private void loadroomresourcelist(HttpContext context)
        {
            try
            {
                int ID = WebUtil.GetIntValue(context, "ID");
                var wechatuser = Wechat_User.GetWechat_User(ID);
                if (wechatuser == null)
                {
                    WebUtil.WriteJson(context, new { status = true, msg = "ID不合法" });
                    return;
                }
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                string RoomID = context.Request.Params["RoomID"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomID))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomID);
                }
                string ProjectID = context.Request.Params["ProjectID"];
                List<int> ProjectIDList = new List<int>();
                if (!string.IsNullOrEmpty(ProjectID))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectID);
                }
                string Keywords = context.Request.Params["Keywords"];
                int RoomStatus = int.MinValue;
                if (!string.IsNullOrEmpty(context.Request.Params["RoomStatus"]))
                {
                    RoomStatus = WebUtil.GetIntValue(context, "RoomStatus");
                }
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = ViewRoomBasic.GetRoomBasicListByKeywords(RoomIDList, ProjectIDList, string.Empty, string.Empty, Keywords, new List<string>(), "order by [DefaultOrder] asc", startRowIndex, pageSize, wechatuser.OpenId, RoomStatus);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("WechatHandler", "命令:LoadRoomResourceList", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void connectroom(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var wechatuser = Wechat_User.GetWechat_User(ID);
            if (wechatuser == null)
            {
                WebUtil.WriteJson(context, new { status = true, msg = "ID不合法" });
                return;
            }
            string RoomIDs = context.Request.Params["RoomIDList"];
            List<int> RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            List<WechatUser_Project> wechatprojectlist = new List<WechatUser_Project>();
            foreach (var RoomID in RoomIDList)
            {
                var wechatproject = WechatUser_Project.GetWechatUser_Project(RoomID, wechatuser.OpenId);
                if (wechatproject != null)
                {
                    continue;
                }
                wechatproject = new WechatUser_Project();
                wechatproject.ProjectID = RoomID;
                wechatproject.OpenID = wechatuser.OpenId;
                wechatprojectlist.Add(wechatproject);
            }
            if (wechatprojectlist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        foreach (var item in wechatprojectlist)
                        {
                            item.Save(helper);
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("WechatHandler", "visit: connectroom", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true, msg = "关联成功" });
        }
        private void tongbuwechatuser(HttpContext context)
        {
            var openids = WeixinHelper.GetAttentionsList();
            var wUser = Wechat_User.GetWechat_Users().ToList();

            foreach (var wu in wUser)
            {
                if (!openids.Contains(wu.OpenId))
                {
                    openids.Add(wu.OpenId);
                }
            }

            string accesstoken = WeixinHelper.GetAccessToken(null);
            for (var i = 0; i < openids.Count; i++)
            {
                var openID = openids[i];

                ErrInfo err = null;
                var wechatuser = WeixinHelper.GetUserInfo(openID, accesstoken, out err);
                if (wechatuser == null)
                {
                    if (err.ErrCode == 40001)//invalid credential
                    {
                        accesstoken = WeixinHelper.GetAccessToken(accesstoken);
                        wechatuser = WeixinHelper.GetUserInfo(openID, accesstoken, out err);
                    }
                }
                if (wechatuser == null)
                {
                    break;
                }
                var user = wUser.FirstOrDefault(p => p.OpenId == openID);
                if (user == null)
                {
                    user = new Foresight.DataAccess.Wechat_User()
                    {
                        OpenId = openID,
                    };
                }
                if (!string.IsNullOrEmpty(wechatuser.NickName))
                    user.NickName = wechatuser.NickName;

                if (!string.IsNullOrEmpty(wechatuser.HeadImgUrl))
                    user.HeadImgUrl = wechatuser.HeadImgUrl.Replace("\\", "");

                if (!string.IsNullOrEmpty(wechatuser.Sex))
                    user.Sex = int.Parse(wechatuser.Sex);

                if (!string.IsNullOrEmpty(wechatuser.City))
                    user.City = wechatuser.City;

                if (!string.IsNullOrEmpty(wechatuser.Country))
                    user.Country = wechatuser.Country;

                if (!string.IsNullOrEmpty(wechatuser.Province))
                    user.Province = wechatuser.Province;

                if (!string.IsNullOrEmpty(wechatuser.Language))
                    user.Language = wechatuser.Language;

                if (!string.IsNullOrEmpty(wechatuser.SubScribe))
                    user.SubScribe = int.Parse(wechatuser.SubScribe);

                if (!string.IsNullOrEmpty(wechatuser.SubscribeTime))
                    user.SubscribeTime = ConvertDate(wechatuser.SubscribeTime);
                if (user.SubScribe != 0)
                {
                    user.UnSubscribeTime = DateTime.MinValue;
                }
                else
                {
                    if (user.UnSubscribeTime == DateTime.MinValue)
                    {
                        user.UnSubscribeTime = DateTime.Now;
                    }
                }
                if (user.FirstSubScribeTime == DateTime.MinValue)
                {
                    user.FirstSubScribeTime = user.SubscribeTime;
                }
                user.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getwechatuserlist(HttpContext context)
        {
            string Keywords = context.Request.Params["keywords"];
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            string RoomID = context.Request.Params["RoomID"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomID))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomID);
            }
            string ProjectIDs = context.Request.Params["ProjectID"];
            List<int> ProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            }
            bool IsShowSubscribe = WebUtil.GetIntValue(context, "IsShowSubscribe") == 1 ? true : false;
            bool IsShowUnSubscribe = WebUtil.GetIntValue(context, "IsShowUnSubscribe") == 1 ? true : false;
            bool excludeproject = false;
            if (!string.IsNullOrEmpty(context.Request["excludeproject"]))
            {
                bool.TryParse(context.Request["excludeproject"], out excludeproject);
            }
            DataGrid dg = new Foresight.DataAccess.Ui.DataGrid();
            if (!excludeproject)
            {
                dg = ViewWechatUserProject.GeViewWechatUserProjectGridByKeywords(Keywords, IsShowSubscribe, IsShowUnSubscribe, ProjectIDList, RoomIDList, "order by [SubscribeTime] desc", startRowIndex, pageSize);
            }
            else
            {
                int Wechat_MsgID = WebUtil.GetIntValue(context, "Wechat_MsgID");
                int ChooseState = 0;
                if (!string.IsNullOrEmpty(context.Request["ChooseState"]))
                {
                    ChooseState = WebUtil.GetIntValue(context, "ChooseState");
                }
                dg = Foresight.DataAccess.Wechat_UserDetail.GeWechat_UserGridByKeywords(Keywords, Wechat_MsgID, ChooseState, "order by isnull(IsChosen,0) desc,[SubscribeTime] desc", startRowIndex, pageSize);
            }
            string result = JsonConvert.SerializeObject(dg);
            context.Response.Write(result);
        }
        private DateTime ConvertDate(string datestr)
        {
            DateTime conTime = new DateTime();
            DateTime firstTime = new DateTime(1970, 1, 1);
            int stime = -1;
            if (int.TryParse(datestr, out stime) == false)
            {
                conTime = Convert.ToDateTime(datestr);
            }
            else
            {
                conTime = Convert.ToDateTime(firstTime.AddSeconds(stime));
            }
            return conTime;
        }
        private string GetOpenID(HttpContext context)
        {
            string openid = context.Request["wxopenid"];
            if (!string.IsNullOrEmpty(openid))
            {
                return openid;
            }
            string CookieKey = WebUtil.GetOpenIDPrefix();
            openid = context.Request[CookieKey];
            if (string.IsNullOrEmpty(openid))
            {
                throw new Exception(CookieKey + ": openid获取失败");
            }
            return openid;
        }
        private string getValue(HttpContext context, string name)
        {
            string PostName = "ctl00$content$";
            return context.Request.Params[PostName + name];
        }
        private int getIntValue(HttpContext context, string name)
        {
            int result = 0;
            int.TryParse(getValue(context, name), out result);
            return result;
        }
        private DateTime getTimeValue(HttpContext context, string name)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(getValue(context, name), out result);
            return result;
        }
        private decimal getDecimalValue(HttpContext context, string name)
        {
            decimal result = 0;
            decimal.TryParse(getValue(context, name), out result);
            return result;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        #region 通用方法
        private DateTime GetEndTime(ChargeFee chargeFee, DateTime StartTime)
        {
            DateTime EndTime = DateTime.MinValue;
            if (chargeFee.EndTypeID == 1)
            {
                EndTime = StartTime.AddMonths(chargeFee.ChargeTypeCount).AddDays(-1);
            }
            else if (chargeFee.EndTypeID == 2)
            {
                EndTime = StartTime.AddDays(chargeFee.ChargeTypeCount - 1);
            }
            return EndTime;
        }
        private void SavePrintRoomFeeHistory(HttpContext context, PrintRoomFeeHistory printRoomFeeHistory, int RoomID, decimal RealCost, string ChargeMan, SqlHelper helper)
        {
            int ChargeType1 = 7;
            int ChargeType2 = 0;
            int OrderNumberID = 0;
            string PrintNumber = Foresight.DataAccess.PrintRoomFeeHistory.GetLastestPrintNumber(Foresight.DataAccess.OrderTypeNameDefine.chargefee.ToString(), RoomID, helper, out OrderNumberID);
            decimal PreChargeMoney = 0;
            decimal ChargeBackMoney = 0;
            decimal RealMoneyCost1 = RealCost;
            decimal RealMoneyCost2 = 0;
            decimal DiscountMoney = 0;
            decimal money = RealCost;
            string MoneyDaXie = Tools.CmycurD(RealCost);
            DateTime ChargeTime = DateTime.Now;
            string Remark = "微信支付";
            printRoomFeeHistory.PrintNumber = PrintNumber;
            printRoomFeeHistory.OrderNumberID = OrderNumberID;
            printRoomFeeHistory.Cost = money;
            printRoomFeeHistory.CostCapital = MoneyDaXie;
            printRoomFeeHistory.RealCost = RealCost;
            printRoomFeeHistory.PreChargeMoney = PreChargeMoney;
            printRoomFeeHistory.ChargeBackMoney = ChargeBackMoney;
            printRoomFeeHistory.RealMoneyCost1 = RealMoneyCost1;
            printRoomFeeHistory.RealMoneyCost2 = RealMoneyCost2;
            printRoomFeeHistory.DiscountMoney = DiscountMoney;
            printRoomFeeHistory.ChargeMan = ChargeMan;
            printRoomFeeHistory.ChargeTime = ChargeTime;
            printRoomFeeHistory.Remark = Remark;
            printRoomFeeHistory.ChageType1 = ChargeType1;
            printRoomFeeHistory.ChageType2 = ChargeType2;
            if (printRoomFeeHistory.AddTime == DateTime.MinValue)
            {
                printRoomFeeHistory.AddTime = DateTime.Now;
            }
            printRoomFeeHistory.WeiShuMore = 0;
            printRoomFeeHistory.WeiShuConsume = 0;
            printRoomFeeHistory.RoomFullName = context.Request.Params["RoomFullName"];
            printRoomFeeHistory.RoomOwnerName = context.Request.Params["RoomOwnerName"];
            printRoomFeeHistory.Save(helper);

        }
        #endregion
    }
    public class RoomFeeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal TotalCost { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int PrintID { get; set; }
        public string StartEndPoint { get; set; }
        public ViewRoomFeeHistory[] historylist { get; set; }
    }
    public class TreeModule
    {
        public string id { get; set; }
        public int ID { get; set; }
        public string pId { get; set; }
        public string name { get; set; }
        public bool isParent { get; set; }
        public bool open { get; set; }
        public string type { get; set; }
    }
}