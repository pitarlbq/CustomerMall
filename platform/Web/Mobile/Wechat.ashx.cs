using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
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
using Web.Model;
using WeiXin.Domain;
using WxPayAPI;
using WeiXin;

namespace Web.Mobile
{
    /// <summary>
    /// Wechat 的摘要说明
    /// </summary>
    public class Wechat : IHttpHandler, IRequiresSessionState
    {

        const string LogModuel = "Mobile.Wechat.ashx";
        public string action = string.Empty;
        public string wx_openid = string.Empty;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                wx_openid = GetOpenID(context);
                if (string.IsNullOrEmpty(wx_openid))
                {
                    bool ignoreopenid = WebUtil.GetBoolValue(context, "ignoreopenid");
                    if (!ignoreopenid)
                    {
                        LogHelper.WriteDebug(LogModuel, "wx_openid为空");
                        WebUtil.WriteJsonError(context, ErrorCode.AuthenticationFail, new { ResponseURL = WebUtil.GetContextPath() + "/WeiXin/HomeRedirect.aspx" });
                        return;
                    }
                }
                action = context.Request["action"];
                if (string.IsNullOrEmpty(action))
                {
                    LogHelper.WriteDebug(LogModuel, "action为空");
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "action为空");
                    return;
                }

                action = action.ToLower();
                switch (action)
                {
                    case "getroomfeebyopenid":
                        getroomfeebyopenid(context);
                        break;
                    case "loadhometongzhi":
                        loadhometongzhi(context);
                        break;
                    case "loadtongzhilist":
                        loadtongzhilist(context);
                        break;
                    case "loadtongzhidetail":
                        loadtongzhidetail(context);
                        break;
                    case "getroomfeebyid":
                        getroomfeebyid(context);
                        break;
                    case "wxpayroomfeeready":
                        wxpayroomfeeready(context);
                        break;
                    case "wxpayroomfeecomplete":
                        wxpayroomfeecomplete(context);
                        break;
                    case "getroomfeehistorybyopenid":
                        getroomfeehistorybyopenid(context);
                        break;
                    case "getroomsourcebyopenid":
                        getroomsourcebyopenid(context);
                        break;
                    case "saveservice":
                        saveservice(context);
                        break;
                    case "getjssignature":
                        getjssignature(context);
                        break;
                    case "getbianmin":
                        getbianmin(context);
                        break;
                    case "getuserinfo":
                        getuserinfo(context);
                        break;
                    case "getroomlistbyopenid":
                        getroomlistbyopenid(context);
                        break;
                    case "cancelroombyroomid":
                        cancelroombyroomid(context);
                        break;
                    case "sendverifycode":
                        sendverifycode(context);
                        break;
                    case "checkphonestatus":
                        checkphonestatus(context);
                        break;
                    case "wxconnectroom":
                        wxconnectroom(context);
                        break;
                    case "getsurveyquestionsbyid":
                        getsurveyquestionsbyid(context);
                        break;
                    case "savesurvyresonse":
                        savesurvyresonse(context);
                        break;
                    case "getlotteryaction":
                        getlotteryaction(context);
                        break;
                    case "createlotteryrecord":
                        createlotteryrecord(context);
                        break;
                    case "getmyprizelist":
                        getmyprizelist(context);
                        break;
                    case "getmyprizeresult":
                        getmyprizeresult(context);
                        break;
                    case "getmyprizecheckresult":
                        getmyprizecheckresult(context);
                        break;
                    case "saveprizecheck":
                        saveprizecheck(context);
                        break;
                    case "loadwechatbusinesslist":
                        loadwechatbusinesslist(context);
                        break;
                    case "getwechatrenthomelist":
                        getwechatrenthomelist(context);
                        break;
                    case "getrenthomedetail":
                        getrenthomedetail(context);
                        break;
                    case "getrentarealist":
                        getrentarealist(context);
                        break;
                    case "savewechatrentrequest":
                        savewechatrentrequest(context);
                        break;
                    case "gethouseservicelist":
                        gethouseservicelist(context);
                        break;
                    case "gethouseservicedetail":
                        gethouseservicedetail(context);
                        break;
                    case "getpaymentmethod":
                        getpaymentmethod(context);
                        break;
                    case "huishouyinreadypay":
                        huishouyinreadypay(context);
                        break;
                    case "alipayroomfeeready":
                        alipayroomfeeready(context);
                        break;
                    case "alipaypayprocess":
                        alipaypayprocess(context);
                        break;
                    case "getsurveylist":
                        getsurveylist(context);
                        break;
                    case "getwechathomesource":
                        getwechathomesource(context);
                        break;
                    case "getapphouseservicelist":
                        getapphouseservicelist(context);
                        break;
                    case "getapphouseservicedetail":
                        getapphouseservicedetail(context);
                        break;
                    case "startchatready":
                        startchatready(context);
                        break;
                    case "getpublicprojectlistbyparentid":
                        getpublicprojectlistbyparentid(context);
                        break;
                    case "getmyxiaoqulist":
                        getmyxiaoqulist(context);
                        break;
                    case "dochoosemyxiao":
                        dochoosemyxiao(context);
                        break;
                    case "getsurveyvotesbyid":
                        getsurveyvotesbyid(context);
                        break;
                    case "savesurveyvoteresponse":
                        savesurveyvoteresponse(context);
                        break;
                    case "getservicelist":
                        getservicelist(context);
                        break;
                    case "getservicedetail":
                        getservicedetail(context);
                        break;
                    case "getrotatingimages":
                        getrotatingimages(context);
                        break;
                    case "getconnectroomdata":
                        getconnectroomdata(context);
                        break;
                    default:
                        LogHelper.WriteDebug(LogModuel, "action：" + action);
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "action不合法");
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModuel, "action: " + action, ex);
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
            }
        }
        private void getconnectroomdata(HttpContext context)
        {
            var imagelist = Foresight.DataAccess.Mall_RotatingImage.GetMall_RotatingImageListByType(12).ToList();
            string Name = SysConfigNameDefine.WechatConnnectRoomSummary.ToString();
            var configData = SysConfig.GetSysConfigByName(Name);
            string imageurl = string.Empty;
            string imagedesc = string.Empty;
            if (imagelist.Count > 0)
            {
                imageurl = WebUtil.GetContextPath() + imagelist[0].ImagePath;
            }
            if (configData != null)
            {
                imagedesc = configData.Value;
            }
            WebUtil.WriteJsonResult(context, new { imageurl = imageurl, imagedesc = imagedesc });
        }
        private void getrotatingimages(HttpContext context)
        {
            int type = WebUtil.GetIntValue(context, "type");
            //滑动图片
            var imagelist = Foresight.DataAccess.Mall_RotatingImage.GetMall_RotatingImageListByType(type).ToList();
            int totalsecond = 0;
            List<Dictionary<string, object>> imageitems = new List<Dictionary<string, object>>();
            string footer_banner_img = string.Empty;
            foreach (var item in imagelist)
            {
                var dic = new Dictionary<string, object>();
                dic["ID"] = item.ID;
                dic["imageurl"] = WebUtil.GetContextPath() + item.ImagePath;
                dic["productid"] = item.URLLinkID;
                dic["type"] = item.URLLinkType;
                dic["cacheurl"] = "";
                imageitems.Add(dic);
            }
            WebUtil.WriteJsonResult(context, new { imagelist = imageitems, totalsecond = totalsecond, footer_banner_img = footer_banner_img });
        }
        private void getservicedetail(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不存在");
                return;
            }
            Foresight.DataAccess.User[] user_list = new Foresight.DataAccess.User[] { };
            List<int> UserIDList = new List<int>();
            if (data.SendUserID > 0)
            {
                UserIDList.Add(data.SendUserID);
            }
            if (data.BanJieManUserID > 0)
            {
                UserIDList.Add(data.BanJieManUserID);
            }
            List<int> ServiceAccpetManIDList = new List<int>();
            Foresight.DataAccess.User[] accpet_user = new Foresight.DataAccess.User[] { };
            if (!string.IsNullOrEmpty(data.ServiceAccpetManID))
            {
                ServiceAccpetManIDList = JsonConvert.DeserializeObject<List<int>>(data.ServiceAccpetManID);
                UserIDList.AddRange(ServiceAccpetManIDList);
            }
            user_list = Foresight.DataAccess.User.GetUserListByIDList(UserIDList);
            var send_user = user_list.FirstOrDefault(p => p.UserID == data.SendUserID);
            if (ServiceAccpetManIDList.Count > 0)
            {
                accpet_user = user_list.Where(p => ServiceAccpetManIDList.Contains(p.UserID)).ToArray();
            }
            string ServiceAccpetMan = string.Empty;
            string ServiceAccpetManPhone = string.Empty;
            if (accpet_user.Length > 0)
            {
                ServiceAccpetMan = string.Join(",", accpet_user.Select(p => p.RealName).ToArray());
                ServiceAccpetManPhone = string.Join(",", accpet_user.Select(p => p.PhoneNumber).ToArray());
            }
            var banjie_user = user_list.FirstOrDefault(p => p.UserID == data.BanJieManUserID);
            var form = new
            {
                ID = data.ID,
                APPSendTime = data.APPSendTime > DateTime.MinValue ? data.APPSendTime.ToString("yyyy-MM-dd HH:mm:ss") : "",
                SendUserName = send_user != null ? send_user.RealName : "",
                SendUserPhone = send_user != null ? send_user.PhoneNumber : "",
                AcceptTime = data.AcceptTime > DateTime.MinValue ? data.AcceptTime.ToString("yyyy-MM-dd HH:mm:ss") : "",
                ServiceAccpetMan = ServiceAccpetMan,
                ServiceAccpetManPhone = ServiceAccpetManPhone,
                BanJieTime = data.BanJieTime > DateTime.MinValue ? data.BanJieTime.ToString("yyyy-MM-dd HH:mm:ss") : "",
                BanJieManName = banjie_user != null ? banjie_user.RealName : "",
                BanJieManPhone = banjie_user != null ? banjie_user.PhoneNumber : "",
            };
            var chulilist = Foresight.DataAccess.CustomerServiceChuli.GetCustomerServiceChuliList(ID);
            var chuliattachlist = Foresight.DataAccess.CustomerServiceChuli_Attach.GetCustomerServiceChuli_AttachListByServiceID(ID);
            var items = chulilist.Select(p =>
            {
                var dic = new Dictionary<string, object>();
                dic["ChuliDate"] = p.ChuliDate > DateTime.MinValue ? p.ChuliDate.ToString("yyyy-MM-dd HH:mm") : "";
                dic["CompleteContent"] = p.ChuliNote;
                dic["RepairFee"] = p.HandelFee > 0 ? p.HandelFee : 0;
                dic["OtherFee"] = p.OtherFee > 0 ? p.OtherFee : 0;
                dic["imglist"] = chuliattachlist.Where(q => q.ChuliID == p.ID).Select(q =>
                {
                    var item = new { url = WebUtil.GetContextPath() + q.AttachedFilePath, cacheurl = "" };
                    return item;
                });
                return dic;
            });
            WebUtil.WriteJsonResult(context, new { form = form, list = items });
        }
        private void getservicelist(HttpContext context)
        {
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            long totals = 0;
            bool IsSuggestion = WebUtil.GetBoolValue(context, "IsSuggestion");
            var list = Foresight.DataAccess.ViewCustomerService.GetAPPCustomerViewCustomerServiceListByStatus(-1, 0, startRowIndex, pageSize, out totals, IsSuggestion: IsSuggestion, OpenID: wx_openid);
            var items = list.Select(p =>
            {
                string content = string.IsNullOrEmpty(p.ServiceContent) ? "暂无详细说明" : p.ServiceContent;
                var item = new { ID = p.ID, Title = p.ServiceFullName, Content = content, ServiceType = p.ServiceTypeName, Status = p.ServiceStatus, StatusDesc = p.ServiceStatusDesc };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { gongdanlist = items });
        }
        private void savesurveyvoteresponse(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "id");
            var question = Foresight.DataAccess.Wechat_SurveyQuestion.GetWechat_SurveyQuestion(ID);
            if (question == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "投票已过期");
                return;
            }
            var survey = Wechat_Survey.GetWechat_Survey(question.SurveyID);
            var list = Foresight.DataAccess.Wechat_SurveyOptionResponse.GetWechat_SurveyQuestionResponseListByQuestionID(ID, 0, OpenID: wx_openid);
            bool canvote = Wechat_SurveyQuestion.CheckWechat_SurveyQuestionVoteStatus(survey, 0, list, OpenID: wx_openid);
            if (!canvote)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您已投过票了");
                return;
            }
            var data = new Wechat_SurveyOptionResponse();
            data.AddTime = DateTime.Now;
            data.UserID = 0;
            data.OpenID = wx_openid;
            data.SurveyQuestionOptionID = 0;
            data.SurveyQuestionID = question.ID;
            data.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getsurveyvotesbyid(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Wechat_Survey.GetWechat_Survey(ID);
            var list = Foresight.DataAccess.Wechat_SurveyQuestion.GetWechat_SurveyQuestionListBySurveyID(data.ID);
            List<int> SurveryIDList = new List<int>();
            SurveryIDList.Add(data.ID);
            var response_list = Foresight.DataAccess.Wechat_SurveyOptionResponse.GetWechat_SurveyQuestionResponseListBySurveyIDList(SurveryIDList);
            bool default_canvote = true;
            string default_votedesc = "投我一票";
            if (data.StartTime > DateTime.Now)
            {
                default_canvote = false;
                default_votedesc = "未开始";
            }
            if (data.EndTime < DateTime.Now)
            {
                default_canvote = false;
                default_votedesc = "已结束";
            }
            var items = list.Select(p =>
            {
                string imageurl = string.IsNullOrEmpty(p.CoverImg) ? "../image/error-img.png" : WebUtil.GetContextPath() + p.CoverImg;
                var my_response_list = response_list.Where(q => q.SurveyQuestionID == p.ID).ToArray();
                string votecountdesc = "总票数: " + my_response_list.Length;
                bool canvote = false;
                string votedesc = default_votedesc;
                if (default_canvote)
                {
                    canvote = Wechat_SurveyQuestion.CheckWechat_SurveyQuestionVoteStatus(data, 0, my_response_list, OpenID: wx_openid);
                }
                votedesc = canvote ? "投我一票" : votedesc;
                var item = new { id = p.ID, imageurl = imageurl, title = p.QuestionContent, summary = p.QuestionSummary, votecountdesc = votecountdesc, canvote = canvote, votedesc = votedesc };
                return item;
            });
            var form = new { id = data.ID, title = data.Title, summary = data.Description };
            WebUtil.WriteJsonResult(context, new { list = items, form = form });
        }
        private void dochoosemyxiao(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var project = APPCode.CacheHelper.SaveMyWechatCurrentProject(wx_openid, ID);
            string xiaoquname = project != null ? project.Name : "";
            WebUtil.WriteJsonResult(context, new { name = xiaoquname });
        }
        private void getmyxiaoqulist(HttpContext context)
        {
            Project[] xiaoqu_list = WeixinHelper.GetMyWechatXiaoquList(wx_openid);
            var xiaoqu_items = new List<Dictionary<string, object>>();
            Project project = null;
            if (xiaoqu_list.Length > 0)
            {
                project = xiaoqu_list[0];
                xiaoqu_items = xiaoqu_list.Select(p =>
                {
                    var dic = new Dictionary<string, object>();
                    dic["id"] = p.ID;
                    dic["name"] = p.Name;
                    return dic;
                }).ToList();
            }
            var currentProject = APPCode.CacheHelper.GetMyWechatCurrentProject(wx_openid, UseCache: true);
            if (currentProject == null && project != null)
            {
                currentProject = APPCode.CacheHelper.SaveMyWechatCurrentProject(wx_openid, project.ID);
            }
            string xiaoquname = currentProject != null ? currentProject.Name : "";
            bool canchat = Wechat_ChatRequest.CheckCanChatStatus();
            string CookieHasRoomKey = WebUtil.GetHasRoomPrefix();
            bool HasRoom = WechatUser_Project.CheckWechatUser_ProjectByOpenid(wx_openid);
            context.Response.Cookies.Remove(CookieHasRoomKey);
            context.Response.Cookies.Add(new HttpCookie(CookieHasRoomKey, (HasRoom ? "1" : "0")));
            WebUtil.WriteJsonResult(context, new { list = xiaoqu_items, name = xiaoquname, canchat = canchat });
        }
        private void getpublicprojectlistbyparentid(HttpContext context)
        {
            int ParentID = WebUtil.GetIntValue(context, "parentid");
            int ParentProjectID = WebUtil.GetIntValue(context, "parentprojectid");
            int ParentRoomID = WebUtil.GetIntValue(context, "ParentRoomID");
            string title = "公共资源";
            var items = new List<Dictionary<string, object>>();
            var dic = new Dictionary<string, object>();
            int type = 0;//1-项目 2-公共资源
            if (ParentRoomID >= 1)
            {
                type = 1;
                if (ParentRoomID == 1)
                {
                    var wechat_user = Wechat_User.GetWechat_UserByUserOpenID(wx_openid);
                    if (wechat_user != null && wechat_user.CurrentProjectID > 0)
                    {
                        ParentRoomID = wechat_user.CurrentProjectID;
                    }
                }
                var list = ProjectTree.GetProjectTreeListByID(ParentRoomID, string.Empty, 0, 0);
                items = list.Select(p =>
               {
                   dic = new Dictionary<string, object>();
                   dic["id"] = p.ID;
                   dic["name"] = p.Name;
                   dic["fullname"] = p.FullName;
                   dic["checked"] = false;
                   dic["isparent"] = p.ParentID == 1;
                   return dic;
               }).ToList();
            }
            else
            {
                type = 2;
                var list = Project_Public.GetProjectPublicTreeListByParentID(ParentID, ParentProjectID, string.Empty);
                items = list.Select(p =>
                {
                    dic = new Dictionary<string, object>();
                    dic["id"] = p.ID;
                    dic["name"] = p.Name;
                    dic["fullname"] = p.FullName;
                    dic["checked"] = false;
                    dic["type"] = Utility.EnumModel.PublicProjectTypeDefine.publicproject.ToString();
                    return dic;
                }).ToList();
            }
            WebUtil.WriteJsonResult(context, new { list = items, title = title, type = type });
        }
        private void startchatready(HttpContext context)
        {
            string template_file_path = WebUtil.GetWechatTemplatePath(new Utility.SiteConfig().kftztx);
            if (string.IsNullOrEmpty(template_file_path))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "客服功能未上线，敬请期待");
                return;
            }
            var data = Wechat_ChatRequest.CreateWechat_ChatRequestByOpenID(wx_openid);
            //通知后台
            APPCode.SocketNotify.PushSocketNotifyAlert(Utility.EnumModel.SocketNotifyDefine.notifychat, ID: data.ID);
            //通知微信公众号
            string DomainURL = PaymentConfig.WeiXinConfig.Oauth2Url;
            var sendbackmessage = WeixinHelper.SendTemPlateMessage(template_file_path,
                             data.OpenID,
                             new List<string> 
                              { 
                                  "我们正在安排客服人员为您服务,请耐心等待", 
                                  "未知", 
                                  "在线客服", 
                                  "等待接单",
                                  DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"),
                                  ""
                              }, "");
            if (sendbackmessage.IsError)
            {
                LogHelper.WriteError("客服通知提醒:startchatready", sendbackmessage.Body, null);
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getapphouseservicedetail(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Wechat_HouseService.GetWechat_HouseService(ID);
            var data_types = Foresight.DataAccess.Wechat_HouseServiceType.GetWechat_HouseServiceTypeListByServiceID(ID);
            string pricedesc = string.Empty;
            string chosenvariatname = string.Empty;
            int typeid = 0;
            if (data_types.Length > 0)
            {
                var data_type = data_types[0];
                pricedesc = "￥" + data_type.UnitPrice.ToString("0.00");
                chosenvariatname = "已选: " + data_type.TypeName;
                typeid = data_type.ID;
            }
            var data_item = new
            {
                ID = data.ID,
                Title = data.Title,
                ContactPhone = data.ContactPhone,
                ServiceIncude = data.ServiceIncude,
                ServiceStandard = data.ServiceStandard,
                AppointNotify = data.AppointNotify,
                imageurl = string.IsNullOrEmpty(data.IconLink) ? "" : WebUtil.GetContextPath() + data.IconLink,
                pricedesc = pricedesc,
                chosenvariatname = chosenvariatname,
                quantity = 1,
                typeid = typeid,
            };
            var type_list = data_types.Select(p =>
            {
                bool isselected = typeid == p.ID;
                var item = new { ID = p.ID, TypeName = string.IsNullOrEmpty(p.TypeName) ? "默认" : p.TypeName, UnitPrice = p.UnitPrice > 0 ? p.UnitPrice : 0, Unit = p.Unit, Remark = p.Remark, selected = isselected };
                return item;
            });
            var data_imgs = Foresight.DataAccess.Wechat_HouseServiceImg.GetWechat_HouseServiceImgList(ID);
            var img_list = data_imgs.Select(p =>
            {
                var item = new { ID = p.ID, imgurl = WebUtil.GetContextPath() + p.AttachedFilePath };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { data_item = data_item, typelist = type_list, imglist = img_list });
        }
        private void getapphouseservicelist(HttpContext context)
        {
            var house_categories = Foresight.DataAccess.Wechat_HouseServiceCategory.GetWechat_HouseServiceCategories().Where(p => p.IsWechatShow).OrderBy(p => p.SortOrder).ToArray();
            var house_services = Foresight.DataAccess.Wechat_HouseService.GetWechat_HouseServices().Where(p => p.IsWechatShow).OrderBy(p => p.SortOrder).ToArray();
            var dic = new Dictionary<string, object>();
            var sub_dic = new Dictionary<string, object>();
            var sub_menus = new List<Dictionary<string, object>>();
            var menus = new List<Dictionary<string, object>>();
            foreach (var item in house_categories)
            {
                var my_house_services = house_services.Where(q => q.CategoryID == item.ID).ToArray();
                if (my_house_services.Length == 0)
                {
                    continue;
                }
                sub_menus = my_house_services.Select(q =>
                {
                    sub_dic = new Dictionary<string, object>();
                    sub_dic["id"] = q.ID;
                    sub_dic["title"] = q.Title;
                    sub_dic["iconcss"] = string.IsNullOrEmpty(q.IconLink) ? "../image/error-img.png" : WebUtil.GetContextPath() + q.IconLink;
                    sub_dic["name"] = "servicedetail_frm";
                    sub_dic["isoutlink"] = q.UseOutLink;
                    sub_dic["outlinkurl"] = q.OutLinkURL;
                    return sub_dic;
                }).ToList();
                dic = new Dictionary<string, object>();
                dic["id"] = item.ID;
                dic["title"] = item.CategoryName;
                dic["is_active"] = false;
                dic["coverimage"] = string.IsNullOrEmpty(item.FilePath) ? "" : WebUtil.GetContextPath() + item.FilePath;
                dic["coverimage_active"] = string.IsNullOrEmpty(item.FilePath_Active) ? "" : WebUtil.GetContextPath() + item.FilePath_Active;
                dic["sub_menus"] = sub_menus;
                menus.Add(dic);
            }
            WebUtil.WriteJsonResult(context, new { menus = menus });
        }
        private void getwechathomesource(HttpContext context)
        {
            bool HasRoom = false;
            List<int> ProjectIDList = WeixinHelper.GetMyWechatProjectIDList(wx_openid, out HasRoom);
            bool canchat = SysMenu.CheckSysModulesForUserByUserId(0, ModuleCode: "1191501");
            var wechat_contact_list = Foresight.DataAccess.Wechat_Contact.GetWechat_ContactListByMsgPhoneType(Utility.EnumModel.WechatContactType.hujiaowuye.ToString(), ProjectIDList);
            string wechat_contact_title = string.Empty;
            string wechat_contact = string.Empty;
            if (wechat_contact_list.Length > 0)
            {
                wechat_contact = wechat_contact_list[0].PhoneNumber;
                wechat_contact_title = wechat_contact_list[0].Name;
            }
            if (!HasRoom)
            {
                WebUtil.WriteJsonResult(context, new { TotalCost = 0, TotalCount = 0, wechat_contact = wechat_contact, wechat_contact_title = wechat_contact_title, canchat = canchat });
                return;
            }
            var feelist = ViewRoomFee.GetViewRoomFeeListByOpenID(wx_openid, 0).Where(p => p.TotalCost > 0).ToArray();
            decimal TotalCost = feelist.Sum(p => p.TotalCost);
            int TotalCount = feelist.Length;
            WebUtil.WriteJsonResult(context, new { TotalCost = TotalCost, TotalCount = TotalCount, wechat_contact = wechat_contact, wechat_contact_title = wechat_contact_title, canchat = canchat, openid = wx_openid });
        }
        private void getsurveylist(HttpContext context)
        {
            int type = WebUtil.GetIntValue(context, "type");
            var list = Foresight.DataAccess.Wechat_Survey.GetWechat_Surveys().Where(p => p.Status == 1 && p.SurveyType == type).ToArray();
            List<int> survey_idlist = list.Select(p => p.ID).ToList();
            var option_list = Foresight.DataAccess.Wechat_SurveyQuestionOption.GetWechat_SurveyQuestionOptionListBySurveyIDList(survey_idlist);
            var res_list = Foresight.DataAccess.Wechat_SurveyOptionResponse.GetWechat_SurveyOptionResponses();
            var items = list.Select(p =>
            {
                var my_option_idlist = option_list.Where(q => q.SurveyID == p.ID).Select(q => q.ID).ToList();
                var user_idlist = res_list.Where(q => my_option_idlist.Contains(q.SurveyQuestionOptionID)).Select(q => q.UserID).Distinct();
                string time = string.Empty;
                if (p.StartTime > DateTime.MinValue)
                {
                    time += p.StartTime.ToString("yyyy-MM-dd") + " 至 ";
                }
                if (p.EndTime > DateTime.MinValue)
                {
                    if (string.IsNullOrEmpty(time))
                    {
                        time += "-- 至 ";
                    }
                    time += p.EndTime.ToString("yyyy-MM-dd");
                }
                var item = new { id = p.ID, title = p.Title, imageurl = string.IsNullOrEmpty(p.CoverImg) ? "../image/error-img.png" : WebUtil.GetContextPath() + p.CoverImg, time = time, totalcount = "已参与: " + user_idlist.Count().ToString() + "人" };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void alipayroomfeeready(HttpContext context)
        {
            try
            {
                string idlist = context.Request["idlist"];
                List<Utility.WeiXinPayModel> ListOption = new List<Utility.WeiXinPayModel>();
                if (!string.IsNullOrEmpty(idlist))
                {
                    ListOption = JsonConvert.DeserializeObject<List<Utility.WeiXinPayModel>>(idlist);
                }
                if (ListOption.Count == 0)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请选择需要缴费的费项");
                    return;
                }
                List<int> fee_idlist = ListOption.Select(p => p.ID).ToList();
                var roomfee_list = Foresight.DataAccess.RoomFee.GetRoomFeeListByIDs(fee_idlist).ToArray();
                List<string> exist_tradenos = roomfee_list.Where(p => !string.IsNullOrEmpty(p.TradeNo)).Select(p => p.TradeNo).Distinct().ToList();
                if (exist_tradenos.Count > 0)
                {
                    foreach (var exist_tradeno in exist_tradenos)
                    {
                        try
                        {
                            int PayStatus = PaymentHelper.OrderQuery(exist_tradeno);
                            if (PayStatus == 2)
                            {
                                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "选中的账单已支付成功");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteError("AliPayApi", "OrderQuery", ex);
                        }
                    }
                }
                decimal total_fee = WebUtil.GetDecimalValue(context, "total_fee");
                //string body = context.Request["contentbody"];
                string body = string.Empty;
                if (string.IsNullOrEmpty(body))
                {
                    var company = WebUtil.GetCompany(context);
                    body = company != null ? company.CompanyName : ConfigurationManager.AppSettings["CompanyName"];
                }
                string tradeno = WxPayApi.GenerateOutTradeNo();
                DefaultAopClient client = new DefaultAopClient(AlipayConfig.mobile_gatewayUrl, AlipayConfig.mobile_app_id, AlipayConfig.mobile_private_key_value, "json", "1.0", AlipayConfig.sign_type, AlipayConfig.mobile_public_key_value, AlipayConfig.charset, false);
                // 组装业务参数model
                AlipayTradeWapPayModel model = new AlipayTradeWapPayModel();
                model.Body = body;
                model.Subject = "yongyoualipay";
                model.TotalAmount = total_fee.ToString("0.00");
                model.OutTradeNo = tradeno;
                model.ProductCode = AlipayConfig.wap_product_code;
                model.QuitUrl = "";
                AlipayTradeWapPayRequest request = new AlipayTradeWapPayRequest();
                // 设置支付完成同步回调地址
                request.SetReturnUrl(AlipayConfig.wx_return_url);
                // 设置支付完成异步通知接收地址
                request.SetNotifyUrl(AlipayConfig.notify_url);
                // 将业务model载入到request
                request.SetBizModel(model);
                AlipayTradeWapPayResponse response = null;
                string response_body = string.Empty;
                try
                {
                    response = client.pageExecute(request, null, "post");
                    response_body = response.Body;
                }
                catch (Exception exp)
                {
                    LogHelper.WriteError("Alipay", "pageExecute", exp);
                }
                List<Payment_Request> request_list = new List<Payment_Request>();
                foreach (var item in ListOption)
                {
                    var payment_request = new Foresight.DataAccess.Payment_Request();
                    payment_request.RoomFeeID = item.ID;
                    payment_request.EndTime = item.EndTime.HasValue ? Convert.ToDateTime(item.EndTime) : DateTime.MinValue;
                    payment_request.AddTime = DateTime.Now;
                    payment_request.AddMan = wx_openid;
                    request_list.Add(payment_request);
                }
                var payment = Payment.Insert_Payment(total_fee, Utility.EnumModel.PaymentTypeDefine.alipay.ToString(), tradeno, 1, wx_openid, "微信公众号支付宝支付", ResponseContent: response_body, CanSave: true, fee_list: roomfee_list.ToList(), request_list: request_list);
                WebUtil.WriteJsonResult(context, new { paymentid = payment.ID });
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModuel, "alipayroomfeeready", ex);
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器内部异常");
            }
        }
        private void alipaypayprocess(HttpContext context)
        {
            try
            {
                int paymentid = WebUtil.GetIntValue(context, "paymentid");
                if (paymentid <= 0)
                {
                    //WebUtil.WriteJson(context, new { message = "id不合法" });
                    WebUtil.WriteJson(context, "1");
                    return;
                }
                var payment = Foresight.DataAccess.Payment.GetPayment(paymentid);
                if (payment == null)
                {
                    WebUtil.WriteJson(context, "2");
                    //WebUtil.WriteJson(context, new { message = "暂无相关支付信息" });
                    return;
                }
                if (payment.Status == 2)
                {
                    WebUtil.WriteJson(context, "5");
                    return;
                }
                var request_list = Foresight.DataAccess.Payment_Request.GetPayment_RequestByPaymentID(paymentid);
                if (request_list.Length == 0)
                {
                    WebUtil.WriteJson(context, "2");
                    //WebUtil.WriteJson(context, new { message = "暂无相关支付信息" });
                    return;
                }
                string idlist = context.Request["idlist"];
                List<Utility.WeiXinPayModel> ListOption = request_list.Select(p =>
                {
                    var item = new Utility.WeiXinPayModel();
                    item.ID = p.RoomFeeID;
                    item.EndTime = p.EndTime;
                    return item;
                }).ToList();
                if (ListOption.Count == 0)
                {
                    WebUtil.WriteJson(context, "3");
                    //WebUtil.WriteJson(context, new { message = "请选择需要缴费的费项" });
                    return;
                }
                WebUtil.WriteJson(context, payment.ResponseContent);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModuel, "alipaypayprocess", ex);
                WebUtil.WriteJson(context, "4");
                //WebUtil.WriteJson(context, new { message = "服务器内部异常" });
            }
        }
        private void getpaymentmethod(HttpContext context)
        {
            var config = new Utility.SiteConfig();
            var list = Foresight.DataAccess.PaymentMethod.GetPaymentMethods().Where(p => p.IsActive).ToArray();
            bool HuiShouYin_Enable = false;
            bool.TryParse(config.HuiShouYin_Enable, out HuiShouYin_Enable);
            if (!HuiShouYin_Enable)
            {
                list = list.Where(p => !p.PaymentMethodName.Equals("汇收银")).ToArray();
            }
            var items = list.Select(p =>
            {
                var item = new { text = p.PaymentMethodName, image = p.IconPath, value = p.Value };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void gethouseservicedetail(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Wechat_HouseService.GetWechat_HouseService(ID);
            var data_item = new
            {
                ID = data.ID,
                Title = data.Title,
                ContactPhone = data.ContactPhone,
                ServiceIncude = data.ServiceIncude,
                ServiceStandard = data.ServiceStandard,
                AppointNotify = data.AppointNotify
            };
            var data_types = Foresight.DataAccess.Wechat_HouseServiceType.GetWechat_HouseServiceTypeListByServiceID(ID);
            var type_list = data_types.Select(p =>
            {
                var item = new { ID = p.ID, TypeName = p.TypeName, UnitPrice = p.UnitPrice, Unit = p.Unit, Remark = p.Remark };
                return item;
            });
            var data_imgs = Foresight.DataAccess.Wechat_HouseServiceImg.GetWechat_HouseServiceImgList(ID);
            var img_list = data_imgs.Select(p =>
            {
                var item = new { ID = p.ID, imgurl = WebUtil.GetContextPath() + p.AttachedFilePath };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { data_item = data_item, typelist = type_list, imglist = img_list });
        }
        private void gethouseservicelist(HttpContext context)
        {
            var list = Foresight.DataAccess.Wechat_HouseServiceCategory.GetWechat_HouseServiceCategories().Where(p => p.IsWechatShow).ToArray();
            var services = Foresight.DataAccess.Wechat_HouseService.GetWechat_HouseServices().Where(p => p.IsWechatShow).ToArray();
            List<Dictionary<string, object>> diclist = new List<Dictionary<string, object>>();
            foreach (var item in list)
            {
                var my_services = services.Where(p => p.CategoryID == item.ID).ToArray();
                if (my_services.Length == 0)
                {
                    continue;
                }
                var dic = new Dictionary<string, object>();
                dic["CategoryID"] = item.ID;
                dic["CategoryName"] = item.CategoryName;
                dic["ServiceList"] = my_services.Select(p =>
                {
                    var my_item = new { ID = p.ID, Title = p.Title, IconLink = string.IsNullOrEmpty(p.IconLink) ? string.Empty : WebUtil.GetContextPath() + p.IconLink };
                    return my_item;
                });
                diclist.Add(dic);
            }
            WebUtil.WriteJsonResult(context, new { list = diclist });
        }
        private void savewechatrentrequest(HttpContext context)
        {
            var data = new Foresight.DataAccess.Wechat_RentRequest();
            data.AddTime = DateTime.Now;
            data.OpenID = wx_openid;
            data.AreaID = WebUtil.GetIntValue(context, "AreaID");
            data.BuildingID = WebUtil.GetIntValue(context, "BuildingID");
            data.ContactName = context.Request["ContactName"];
            data.ContactPhone = context.Request["ContactPhone"];
            data.RentType = context.Request["CurrentRentTypeID"];
            data.BuildingProperty = context.Request["CurrentBuildingPropertyID"];
            data.Remark = context.Request["Remark"];
            data.Save();
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void getrentarealist(HttpContext context)
        {
            var list = Foresight.DataAccess.Wechat_RentArea.GetWechat_RentAreas();
            var list_building = Foresight.DataAccess.Wechat_RentBuilding.GetWechat_RentBuildings();
            var items_area = list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.AreaName };
                return item;
            });
            var items_building = list_building.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.BuildingName, AreaID = p.AreaID };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { arealist = items_area, buildinglist = items_building });
        }
        private void getrenthomedetail(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Wechat_RentHome.GetWechat_RentHome(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            var rent_imgs = Foresight.DataAccess.Wechat_RentHomeImg.GetWechat_RentHomeImgList(data.ID);
            var rent_types = Foresight.DataAccess.Wechat_RentHomeType.GetWechat_RentHomeTypeListByHomeID(data.ID);
            var type = rent_types.Where(q => q.RentStatus == 0).OrderBy(q => q.UnitPrice).FirstOrDefault();
            decimal UnitPrice = 0;
            string Unit = string.Empty;
            if (type != null)
            {
                UnitPrice = type.UnitPrice > 0 ? type.UnitPrice : 0;
                Unit = type.Unit;
            }
            var data_form = new { ID = data.ID, HomeName = data.HomeName, UnitPrice = UnitPrice, Unit = Unit, HomeLocation = data.HomeLocation, Subways = data.Subways, Traffics = data.Traffics, PhoneNumber = data.PhoneNumber, RoomDescription = data.RoomDescription, MapLocation = data.MapLocation, SuperMarkets = data.SuperMarkets };
            var imglist = rent_imgs.Select(p =>
            {
                var item = new { ID = p.ID, imgurl = WebUtil.GetContextPath() + p.AttachedFilePath };
                return item;
            });
            var typelist = rent_types.Select(p =>
            {
                var item = new { ID = p.ID, TypeName = p.TypeName, TypeArea = p.TypeArea > 0 ? p.TypeArea : 0, UnitPrice = p.UnitPrice > 0 ? p.UnitPrice : 0, Unit = p.Unit, RentStatus = p.RentStatus > 0 ? p.RentStatus : 0 };
                return item;
            });
            List<Dictionary<string, object>> RoomOwners = new List<Dictionary<string, object>>();
            if (!string.IsNullOrEmpty(data.RoomOwners))
            {
                string[] RoomOwnersArray = data.RoomOwners.Split(',');
                foreach (var item in RoomOwnersArray)
                {
                    if (string.IsNullOrEmpty(item))
                    {
                        continue;
                    }
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic["Name"] = item;
                    RoomOwners.Add(dic);
                }
            }
            List<Dictionary<string, object>> PublicOwners = new List<Dictionary<string, object>>();
            if (!string.IsNullOrEmpty(data.PublicOwners))
            {
                string[] PublicOwnersArray = data.PublicOwners.Split(',');
                foreach (var item in PublicOwnersArray)
                {
                    if (string.IsNullOrEmpty(item))
                    {
                        continue;
                    }
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic["Name"] = item;
                    PublicOwners.Add(dic);
                }
            }
            WebUtil.WriteJsonResult(context, new { data_form = data_form, imglist = imglist, typelist = typelist, RoomOwners = RoomOwners, PublicOwners = PublicOwners });
        }
        private void getwechatrenthomelist(HttpContext context)
        {
            string keywords = context.Request["keywords"];
            string pageindex = context.Request["pageindex"];
            string pagesize = context.Request["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            List<string> arealist = new List<string>();
            if (!string.IsNullOrEmpty(context.Request["arealist"]) && !context.Request["arealist"].Equals("[]"))
            {
                arealist = JsonConvert.DeserializeObject<List<string>>(context.Request["arealist"]);
            }
            List<string> pricelist = new List<string>();
            if (!string.IsNullOrEmpty(context.Request["pricelist"]) && !context.Request["pricelist"].Equals("[]"))
            {
                pricelist = JsonConvert.DeserializeObject<List<string>>(context.Request["pricelist"]);
            }
            List<string> subwaylist = new List<string>();
            if (!string.IsNullOrEmpty(context.Request["subwaylist"]) && !context.Request["subwaylist"].Equals("[]"))
            {
                subwaylist = JsonConvert.DeserializeObject<List<string>>(context.Request["subwaylist"]);
            }
            List<string> roomtypelist = new List<string>();
            if (!string.IsNullOrEmpty(context.Request["roomtypelist"]) && !context.Request["roomtypelist"].Equals("[]"))
            {
                roomtypelist = JsonConvert.DeserializeObject<List<string>>(context.Request["roomtypelist"]);
            }
            long totals = 0;
            var list = Foresight.DataAccess.Wechat_RentHomeDetail.GetWechat_RentHomeDetailListByKeywords(keywords, arealist, pricelist, subwaylist, roomtypelist, startRowIndex, pageSize, out totals);
            var HomeIDList = list.Select(p => p.ID).ToList();
            var list_type = Foresight.DataAccess.Wechat_RentHomeType.GetWechat_RentHomeTypeListByHomeIDList(HomeIDList);
            var list_img = Foresight.DataAccess.Wechat_RentHomeImg.GetWechat_RentHomeImgList(HomeIDList);
            var items = list.Select(p =>
            {
                var type = list_type.Where(q => q.RentRoomID == p.ID && q.RentStatus == 0).OrderBy(q => q.UnitPrice).FirstOrDefault();
                decimal UnitPrice = 0;
                string Unit = string.Empty;
                if (type != null)
                {
                    UnitPrice = type.UnitPrice > 0 ? type.UnitPrice : 0;
                    Unit = type.Unit;
                }
                var image = list_img.Where(q => q.RentHomeID == p.ID).OrderBy(q => q.AddTime).FirstOrDefault();
                string ImgUrl = string.Empty;
                if (image != null)
                {
                    ImgUrl = !string.IsNullOrEmpty(image.AttachedFilePath) ? WebUtil.GetContextPath() + image.AttachedFilePath : string.Empty;
                }
                var item = new { ID = p.ID, Title = p.HomeName, Address = p.HomeLocation, UnitPrice = UnitPrice, Unit = Unit, ImgUrl = ImgUrl };
                return item;
            });
            var list_area = Foresight.DataAccess.Wechat_RentArea.GetWechat_RentAreas();
            var area_items = list_area.Select(p =>
            {
                var item = new { ID = p.ID, title = p.AreaName, is_click = false, css = "", value = p.ID.ToString() };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items, arealist = area_items });
        }
        private void loadwechatbusinesslist(HttpContext context)
        {
            var list = Foresight.DataAccess.Wechat_Business.GetWechat_Businesses().Where(p => p.IsPublish);
            var items = list.Select(p =>
            {
                string ImgUrl = string.IsNullOrEmpty(p.BusinessImg) ? string.Empty : WebUtil.GetContextPath() + p.BusinessImg;
                var item = new { ID = p.ID, BusinessName = p.BusinessName, BusinessSummary = p.BusinessSummary, PhoneNumber = p.PhoneNumber, ImgUrl = ImgUrl };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void saveprizecheck(HttpContext context)
        {
            int RecordID = WebUtil.GetIntValue(context, "ID");
            if (RecordID <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            Foresight.DataAccess.Wechat_LotteryActivityRecord record = Foresight.DataAccess.Wechat_LotteryActivityRecord.GetWechat_LotteryActivityRecord(RecordID);
            if (record == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "参数recordid不正确");
                return;
            }
            var checker = Foresight.DataAccess.User.GetUserByOpenID(wx_openid);
            if (checker == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "身份验证失败");
                return;
            }
            if (!record.OpenID.Equals(checker.OpenID))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "身份验证失败");
                return;
            }
            var lottery_checker = Foresight.DataAccess.Wechat_LotteryChecker.GetWechat_LotteryCheckerByActivityID(record.ActivityID, checker.UserID);
            if (lottery_checker == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "身份验证失败");
                return;
            }
            if (record.CompleteSend)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您已兑奖，请不要重复兑奖！");
                return;
            }
            record.CompleteSend = true;
            record.Sender = checker.RealName;
            record.SendTime = DateTime.Now;
            record.SendResult = "已发送";
            record.Save();
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void getmyprizecheckresult(HttpContext context)
        {
            int RecordID = WebUtil.GetIntValue(context, "ID");
            if (RecordID <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            Foresight.DataAccess.ViewWechatLotteryActivityRecord record = Foresight.DataAccess.ViewWechatLotteryActivityRecord.GetViewWechatLotteryActivityRecord(RecordID);
            if (record == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "参数recordid不正确");
                return;
            }
            var checker = Foresight.DataAccess.User.GetUserByOpenID(wx_openid);
            if (checker == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "身份验证失败");
                return;
            }
            if (!record.OpenID.Equals(checker.OpenID))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "身份验证失败");
                return;
            }
            var lottery_checker = Foresight.DataAccess.Wechat_LotteryChecker.GetWechat_LotteryCheckerByActivityID(record.ActivityID, checker.UserID);
            if (lottery_checker == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "身份验证失败");
                return;
            }
            string PrizeName = record.PrizeName + record.PrizeQuantity + record.PrizeUnit;
            WebUtil.WriteJsonResult(context, new { form = new { ID = record.ID, Status = record.PrizeID > 0 ? 1 : 0, PrizeName = PrizeName, CompleteSend = record.CompleteSend, PrizeType = record.PrizeType, SendTime = record.SendTime > DateTime.MinValue ? record.SendTime.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty, LevelName = record.LevelName, SendResult = record.SendResult } });
        }
        private void getmyprizeresult(HttpContext context)
        {
            int RecordID = WebUtil.GetIntValue(context, "ID");
            if (RecordID <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            Foresight.DataAccess.ViewWechatLotteryActivityRecord record = Foresight.DataAccess.ViewWechatLotteryActivityRecord.GetViewWechatLotteryActivityRecord(RecordID);
            if (record == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            if (!record.OpenID.Equals(wx_openid))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            string squarePicUrl = string.Empty;
            string QrcodePath = WeixinHelper.CreateQrCode(WebUtil.GetContextPath() + "/WeiXin/LotteryPrizeCheckRedirect.aspx?RecordID=" + record.ID, out squarePicUrl);
            string QrFullPath = WebUtil.GetContextPath() + QrcodePath;
            string PrizeName = record.PrizeName + record.PrizeQuantity + record.PrizeUnit;
            WebUtil.WriteJsonResult(context, new { form = new { ID = record.ID, Status = record.PrizeID > 0 ? 1 : 0, PrizeName = PrizeName, CompleteSend = record.CompleteSend, CompleteSendStatus = record.CompleteSend ? "已领奖" : "未领奖", PrizeType = record.PrizeType, QrFullPath = QrFullPath, LevelName = record.LevelName } });
        }
        private void getmyprizelist(HttpContext context)
        {
            if (string.Compare(context.Request.HttpMethod, "POST", true) != 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            var recordList = Foresight.DataAccess.ViewWechatLotteryActivityRecord.GetViewWechatLotteryActivityRecordByOpenID(wx_openid);
            var list = recordList.Where(p => p.PrizeID > 0).OrderByDescending(p => p.RecordTime).ToList();
            var items = list.Select(p =>
            {
                var item = new { ID = p.ID, ActivityID = p.ActivityID, ActivityName = p.ActivityName, PrizeName = p.PrizeName, RecordTime = p.RecordTime > DateTime.MinValue ? p.RecordTime.ToString("yyyy-MM-dd HH:mm:ss") : "", CompleteSendStatus = p.CompleteSend ? "已领取" : "未领取", CompleteSend = p.CompleteSend };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void createlotteryrecord(HttpContext context)
        {
            if (string.Compare(context.Request.HttpMethod, "POST", true) != 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            int ActivityID = GetActivityID(context);
            if (ActivityID < 1)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "参数activityid不正确");
                return;
            }
            Foresight.DataAccess.Wechat_LotteryActivityRecord record = null;
            Foresight.DataAccess.Wechat_LotteryActivityPrize prize = null;
            string err = string.Empty;
            int leftTime = 0;
            var code = LotteryHelper.CreateRecord(ActivityID, wx_openid, out record, out prize, out err, out leftTime);

            bool retry = false;
            string msg = string.Empty;
            string url = string.Empty;
            switch (code)
            {
                case LotteryCodeDefine.Succeed:
                    retry = false;
                    if (record.PrizeID > 0)
                    {
                        url = WeixinHelper.ResolveClientUrl("/WeiXin/LotteryResultRedirect.aspx?RecordID=" + record.ID);
                        msg = string.Format("恭喜您抽中{0}，获得{1}{2:0.##}{3}", prize.LevelName, prize.PrizeName, prize.PrizeQuantity, prize.PrizeUnit);
                    }
                    else
                    {
                        msg = "感谢您的参与";
                    }
                    break;
                case LotteryCodeDefine.HasRecord:
                    retry = false;
                    msg = err;
                    break;
                case LotteryCodeDefine.NotBegin:
                    retry = true;
                    msg = "活动还未开始";
                    break;
                case LotteryCodeDefine.HasEnd:
                    retry = false;
                    msg = "活动已经结束";
                    break;
                case LotteryCodeDefine.ActivityNotExists:
                    retry = false;
                    msg = "活动已关闭";
                    break;
            }

            WebUtil.WriteJsonResult(context, new
            {
                msg = msg,
                retry = retry,
                url = url,
                lefttime = leftTime,
                level = prize != null ? prize.LevelName : null
            });
        }
        private void getlotteryaction(HttpContext context)
        {

            if (string.Compare(context.Request.HttpMethod, "POST", true) != 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            int ActivityID = GetActivityID(context);
            if (ActivityID < 1)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "参数activityid不正确");
                return;
            }
            if (string.IsNullOrEmpty(wx_openid))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "参数openid不正确");
                return;
            }
            var activity = LotteryHelper.GetActivity(ActivityID);
            string err = string.Empty;
            int leftTime = 0;
            var canjoin = LotteryHelper.CheckRecord(ActivityID, wx_openid, out err, out leftTime);

            if (activity != null)
            {
                var jsTime = new DateTime(1970, 1, 1);
                var timenow = DateTime.Now;

                string text = string.Empty;
                long leftseconds = 0;
                string url = WeixinHelper.ResolveClientUrl("/WeiXin/LotteryListRedirect.aspx");
                Foresight.DataAccess.Wechat_LotteryActivityPrize[] prizelist = new Foresight.DataAccess.Wechat_LotteryActivityPrize[] { };
                prizelist = LotteryHelper.GetActivityPrizeList(activity.ID);
                if (timenow >= activity.StartTime && timenow < activity.EndTime)
                {
                    text = "现在开始";
                    prizelist = LotteryHelper.GetActivityPrizeList(activity.ID);
                    if (!canjoin)
                    {
                        leftseconds = -1;
                        text = err;
                    }
                }
                else if (timenow >= activity.EndTime)
                {
                    text = "活动已结束";
                    leftseconds = -2;
                }
                else
                {
                    text = "活动还未开始";
                    leftseconds = (long)((activity.StartTime - timenow).TotalSeconds);
                }
                WebUtil.WriteJsonResult(context, new
                {
                    text = text,
                    leftseconds = leftseconds,
                    url = url,
                    prizelist = prizelist,
                    ruldesc = activity.RuleDescription,
                });
            }
            else
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "活动已关闭");
            }
        }
        private void savesurvyresonse(HttpContext context)
        {
            int SurveyID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Wechat_Survey data = null;
            if (SurveyID > 0)
            {
                data = Wechat_Survey.GetWechat_Survey(SurveyID);
            }
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该调查问卷不存在");
                return;
            }
            var list = Foresight.DataAccess.Wechat_SurveyOptionResponse.GetWechat_SurveyOptionResponseListBySurveyID(SurveyID, wx_openid);
            if (list.Length > 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您已参与过该调查");
                return;
            }
            string liststr = context.Request["list"];
            var questions = new List<Utility.WechatSurveyQuestionResponse>();
            if (!string.IsNullOrEmpty(liststr))
            {
                questions = JsonConvert.DeserializeObject<List<Utility.WechatSurveyQuestionResponse>>(liststr);
            }
            if (questions.Count > 0)
            {
                string cmdtext = string.Empty;
                foreach (var question in questions)
                {
                    foreach (var option in question.options)
                    {
                        if (option.Selected)
                        {
                            cmdtext += @"insert into [Wechat_SurveyOptionResponse] ([OpenID],[SurveyQuestionOptionID],[AddTime]) values ('" + wx_openid + "'," + option.OptionID + ",getdate());";
                        }
                    }
                }
                if (string.IsNullOrEmpty(cmdtext))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您没有完成选择");
                    return;
                }
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
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "系统异常");
                        return;
                    }
                }
            }
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void getsurveyquestionsbyid(HttpContext context)
        {
            int SurveyID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Wechat_Survey data = null;
            if (SurveyID > 0)
            {
                data = Wechat_Survey.GetWechat_Survey(SurveyID);
            }
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该调查问卷不存在");
                return;
            }
            if (data.Status == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该调查问卷未开始");
                return;
            }
            if (data.StartTime > DateTime.MinValue && data.StartTime > DateTime.Now)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该调查问卷未开始");
                return;
            }
            if (data.EndTime > DateTime.MinValue && data.EndTime < DateTime.Now)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该调查问卷已结束");
                return;
            }
            var list = Foresight.DataAccess.Wechat_SurveyOptionResponse.GetWechat_SurveyOptionResponseListBySurveyID(SurveyID, wx_openid);
            if (list.Length > 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您已参与过该调查");
                return;
            }
            var questions = Foresight.DataAccess.Wechat_SurveyQuestion.GetWechat_SurveyQuestionListBySurveyID(SurveyID);
            var options = Foresight.DataAccess.Wechat_SurveyQuestionOption.GetWechat_SurveyQuestionOptionListBySurveyID(SurveyID);
            var items = questions.Select(p =>
            {
                List<Utility.WechatSurveyOptionResponse> my_options = options.Where(q => q.SurveyQuestionID == p.ID).Select(m =>
                {
                    var my_option = new Utility.WechatSurveyOptionResponse { OptionID = m.ID, Selected = false, Content = m.OptionContent };
                    return my_option;
                }).ToList();
                var item = new Utility.WechatSurveyQuestionResponse { QuestionID = p.ID, Title = p.QuestionContent, type = p.QuestionType, options = my_options };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { questions = items });
        }
        private void wxconnectroom(HttpContext context)
        {
            string PhoneNumber = context.Request.Params["PhoneNumber"];
            string VerifyCode = context.Request.Params["VerifyCode"];
            var list = Foresight.DataAccess.Project.GetProjectListByPhoneNumber(PhoneNumber);
            if (list.Length > 0)
            {
                var wechatVerifyCode = Wechat_VerifyCode.GetWechat_VerifyCodeByUserOpenId(wx_openid, PhoneNumber, DateTime.Now);
                if (wechatVerifyCode == null || !wechatVerifyCode.VerifyCode.Equals(VerifyCode))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您输入的验证码有误");
                    return;
                }
                List<WechatUser_Project> wProjectList = new List<WechatUser_Project>();
                foreach (var project in list)
                {
                    var wProject = WechatUser_Project.GetWechatUser_Project(project.ID, wx_openid);
                    if (wProject != null)
                    {
                        continue;
                    }
                    wProject = new WechatUser_Project();
                    wProject.ProjectID = project.ID;
                    wProject.OpenID = wx_openid;
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
                        LogHelper.WriteError(LogModuel, "wxconnectroom", ex);
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器异常");
                    }
                }
            }
            else
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您输入的号码未关联任何房源");
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
            bool EnableSMS = new Utility.SiteConfig().SmsServerEnable;
            if (EnableSMS)
            {
                WebUtil.WriteJsonResult(context, new { EnableSMS = EnableSMS });
                return;
            }
            List<WechatUser_Project> wProjectList = new List<WechatUser_Project>();
            foreach (var project in list)
            {
                var wProject = WechatUser_Project.GetWechatUser_Project(project.ID, wx_openid);
                if (wProject != null)
                {
                    continue;
                }
                wProject = new WechatUser_Project();
                wProject.ProjectID = project.ID;
                wProject.OpenID = wx_openid;
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
                    LogHelper.WriteError(LogModuel, "checkphonestatus", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器异常");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, new { EnableSMS = EnableSMS });
        }
        private void sendverifycode(HttpContext context)
        {
            try
            {
                string PhoneNumber = context.Request.Params["PhoneNumber"].ToString();
                string verifycode = Utility.Tools.GetVerifyCode();
                //发送短信验证码start               
                string content = "您正在进行登录验证，验证码" + verifycode + "，请在15分钟内按页面提示提交验证码，切勿将验证码泄露于他人。";
                string restcount = string.Empty;
                bool issent = Utility.SmsHelper.SendSms(PhoneNumber, content, verifycode);
                //bool issent = Utility.KXTSms.Send(PhoneNumber, content, out restcount);
                //bool issent = SendMessageType.SendVerifyCode(content, mobiles, out verifycode);
                //发送短信验证码end
                if (issent)
                {
                    Foresight.DataAccess.Wechat_VerifyCode.SaveWechatVerifyCode(PhoneNumber, verifycode, SendResult: restcount, OpenID: wx_openid);
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
                LogHelper.WriteError(LogModuel, "sendverifycode", ex);
                WebUtil.WriteJsonResult(context, 4);
            }
        }
        private void cancelroombyroomid(HttpContext context)
        {
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [WechatUser_Project] where OpenID=@OpenID and ProjectID=@RoomID";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@OpenID", wx_openid));
                    parameters.Add(new SqlParameter("@RoomID", RoomID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "action: cancelroombyroomid", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "取消关联成功");
        }
        private void getroomlistbyopenid(HttpContext context)
        {
            ViewRoomBasic[] roomlist = ViewRoomBasic.GetRoomBasicListByOpenID(wx_openid);
            var RoomID = WebUtil.GetIntValue(context, "RoomID");
            if (RoomID > 0)
            {
                roomlist = roomlist.Where(p => p.RoomID == RoomID).ToArray();
            }
            if (roomlist.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有关联房间");
                return;
            }
            var items = roomlist.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.Name, FullName = p.FullName, RoomID = p.RoomID };
                return item;
            }).ToArray();
            var data = roomlist[0];
            string qrcodeurl = WeixinHelper.CreateQrCode(data.RoomID);
            qrcodeurl = string.IsNullOrEmpty(qrcodeurl) ? string.Empty : WebUtil.GetContextPath() + qrcodeurl;
            var form = new { ID = data.ID, Name = data.Name, FullName = data.FullName, RoomID = data.RoomID, RelationName = data.RelationName, RelatePhoneNumber = data.RelatePhoneNumber, BuildingArea = data.BuildInArea > 0 ? data.BuildInArea : 0, qrcodeurl = qrcodeurl };
            WebUtil.WriteJsonResult(context, new { roomlist = items, form = form });
        }
        private void getuserinfo(HttpContext context)
        {
            ErrInfo err = new ErrInfo();
            string accesstoken = WeixinHelper.GetAccessToken(null);
            var wechatuser = WeixinHelper.GetUserInfo(wx_openid, accesstoken, out err);
            if (wechatuser == null)
            {
                if (err.ErrCode == 40001)//invalid credential
                {
                    accesstoken = WeixinHelper.GetAccessToken(accesstoken);
                    wechatuser = WeixinHelper.GetUserInfo(wx_openid, accesstoken, out err);
                }
            }
            if (wechatuser == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, err.ErrMsg);
                return;
            }
            Foresight.DataAccess.Wechat_User user = Foresight.DataAccess.Wechat_User.GetWechat_UserByUserOpenID(wx_openid);
            if (user == null)
            {
                user = new Foresight.DataAccess.Wechat_User()
                {
                    OpenId = wx_openid,
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
                user.SubscribeTime = WebUtil.GetDateTimeByStr(wechatuser.SubscribeTime);
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
            WebUtil.WriteJsonResult(context, new { status = true, HeadImgUrl = user.HeadImgUrl, NickName = user.NickName });
        }
        private void getbianmin(HttpContext context)
        {
            bool hasRoom = false;
            List<int> ProjectIDList = WeixinHelper.GetMyWechatProjectIDList(wx_openid, out hasRoom);
            if (ProjectIDList.Count == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "list为空");
                return;
            }
            var list = Foresight.DataAccess.Wechat_ContactDetail.GetWechat_ContactDetailListByMsgPhoneType(string.Empty, ProjectIDList: ProjectIDList);
            List<string> titles = list.Select(p => p.CategoryName).Distinct().ToList();
            List<Dictionary<string, object>> diclist = new List<Dictionary<string, object>>();
            foreach (var title in titles)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic["title"] = string.IsNullOrEmpty(title) ? "未设置" : title;
                dic["phonelist"] = list.Where(p => p.CategoryName.Equals(title));
                diclist.Add(dic);
            }
            WebUtil.WriteJsonResult(context, new { list = diclist });
        }
        private void getjssignature(HttpContext context)
        {
            string appId = PaymentConfig.WeiXinConfig.AppID;
            long timestamp = (long)((DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds);
            string nonceStr = "yongyou2016";
            string url = context.Request.Params["pageurl"];
            if (!url.StartsWith("http"))
            {
                url = WebUtil.GetContextPath() + url;
            }
            string signature = WeixinHelper.GetJsApiSignature(nonceStr, timestamp, url);
            WebUtil.WriteJsonResult(context, new { url = url, appId = appId, timestamp = timestamp, nonceStr = nonceStr, signature = signature });
        }
        private void saveservice(HttpContext context)
        {
            try
            {
                int serviceid = 0;
                int.TryParse(context.Request["serviceid"], out serviceid);
                string ServiceType = context.Request.Params["ServiceType"];
                bool isowner = WebUtil.GetBoolValue(context, "isowner");
                string ProjectName = context.Request["ProjectName"];
                int Type = WebUtil.GetIntValue(context, "Type");
                int RoomID = WebUtil.GetIntValue(context, "RoomID");
                int PublicProjectID = WebUtil.GetIntValue(context, "PublicProjectID");
                var wechat = Foresight.DataAccess.Wechat_User.GetWechat_UserByUserOpenID(wx_openid);
                Foresight.DataAccess.Wechat_Service service = Foresight.DataAccess.Wechat_Service.GetWechat_Service(serviceid);
                if (service == null)
                {
                    service = new Foresight.DataAccess.Wechat_Service();
                    service.AddTime = DateTime.Now;
                }
                service.ServiceType = ServiceType;
                service.ServiceType = string.IsNullOrEmpty(service.ServiceType) ? Utility.EnumModel.WechatServiceType.bsbx.ToString() : service.ServiceType;
                service.ServiceContent = context.Request.Params["ServiceContent"];
                service.ServiceAddTime = WebUtil.GetDateValue(context, "ServiceAddTime");
                service.PhoneNumber = context.Request.Params["PhoneNumber"];
                service.RoomID = Type == 2 ? RoomID : 0;
                service.PublicProjectID = Type == 1 ? PublicProjectID : 0;
                service.OpenID = wx_openid;
                service.ServiceFrom = Utility.EnumModel.WechatServiceFromDefine.weixin.ToString();
                if (service.RoomID > 0)
                {
                    var project = Foresight.DataAccess.Project.GetProject(service.RoomID);
                    service.FullName = project == null ? "" : project.FullName + "-" + project.Name;
                }
                else if (service.PublicProjectID > 0)
                {
                    var public_project = Foresight.DataAccess.Project_Public.GetProject_Public(service.PublicProjectID);
                    service.FullName = public_project == null ? "" : public_project.FullName;
                }
                else
                {
                    service.FullName = ProjectName;
                }
                string token = context.Request["token"];
                string MediaIds = context.Request["mediaids"];
                var customer_service = new Foresight.DataAccess.CustomerService();
                customer_service.AddTime = DateTime.Now;
                customer_service.StartTime = DateTime.Now;
                customer_service.AddMan = wechat != null ? wechat.NickName : wx_openid;
                customer_service.AddUserName = wechat != null ? wechat.NickName : wx_openid;
                customer_service.ServiceFrom = service.ServiceFrom;
                customer_service.ServiceFullName = service.FullName;
                customer_service.ProjectName = "无";
                string ServiceTypeDesc = Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatServiceType), service.ServiceType);
                var type = Foresight.DataAccess.ServiceType.GetServiceTypes().FirstOrDefault(p => ServiceTypeDesc.Contains(p.ServiceTypeName));
                customer_service.ServiceTypeID = type != null ? type.ID : int.MinValue;
                customer_service.ServiceTypeName = type != null ? type.ServiceTypeName : string.Empty;
                customer_service.AddCustomerName = !string.IsNullOrEmpty(service.ServiceMan) ? service.ServiceMan : (wechat != null ? wechat.NickName : "");
                customer_service.ServiceContent = service.ServiceContent;
                customer_service.ServiceAppointTime = service.AddTime;
                customer_service.AddCallPhone = service.PhoneNumber;
                customer_service.ServiceStatus = 3;
                customer_service.IsAPPShow = true;
                customer_service.IsUnRead = true;
                customer_service.PublicProjectID = Type == 1 ? PublicProjectID : 0;
                customer_service.ProjectID = Type == 2 ? RoomID : 0;
                customer_service.ServiceArea = Type == 1 ? "公共区域" : "个人区域";
                if (service.ServiceType.Equals(Utility.EnumModel.WechatServiceType.yjfk.ToString()))
                {
                    customer_service.IsSuggestion = true;
                }
                if (service.AddUserID > 0)
                {
                    var user = Foresight.DataAccess.User.GetUser(service.AddUserID);
                    customer_service.ServiceAccpetMan = user != null ? user.RealName : "";
                    customer_service.ServiceAccpetManID = JsonConvert.SerializeObject(new int[] { service.AddUserID });
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
                            WeixinHelper.SaveImgbyMediaid(service.ID, MediaID, wx_openid, helper);
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModuel, "saveservice", ex);
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
                string ErrorMsg = string.Empty;
                if (service.ServiceType.Equals(Utility.EnumModel.WechatServiceType.bsbx.ToString()))
                {
                    var company = Company.GetCompanies().FirstOrDefault();
                    string title = company == null ? "永友网络" : company.CompanyName;
                    APPCode.JPushHelper.SendJpushMsgByServiceID(customer_service.ID, out ErrorMsg, title: title, SendUserID: 0, SendUserName: wx_openid);
                    //通知后台
                    APPCode.SocketNotify.PushSocketNotifyAlert(EnumModel.SocketNotifyDefine.notifyservice);
                }
                else
                {
                    string notify_msg = APPCode.SocketNotify.PushSocketNotifyAlert(EnumModel.SocketNotifyDefine.notifysuggestion);
                    if (!string.IsNullOrEmpty(notify_msg))
                    {
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, notify_msg);
                        return;
                    }
                }
                WebUtil.WriteJsonResult(context, new { status = true, serviceid = service.ID });
                return;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModuel, "saveservice", ex);
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器异常");
                return;
            }
        }
        private void getroomsourcebyopenid(HttpContext context)
        {
            var list = ViewRoomBasic.GetRoomBasicListByOpenID(wx_openid);
            var items = list.Select(p =>
            {
                var item = new { RoomID = p.RoomID, RelatePhoneNumber = p.RelatePhoneNumber, Name = p.FullName.Replace("-", "") + p.Name };
                return item;
            });
            WebUtil.WriteJsonResult(context, items);
        }
        private void getroomfeehistorybyopenid(HttpContext context)
        {
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            var historylist = Foresight.DataAccess.PrintRoomFeeHistory.GetPrintRoomFeeHistoryListByOpenID(string.Empty, RoomID).Where(p => p.RealCost > 0).OrderByDescending(p => p.RealCost).OrderByDescending(p => p.ChargeTime);
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
                roomFeeModel.ShowMore = false;
                var historyitems = Foresight.DataAccess.ViewRoomFeeHistory.GetViewRoomFeeHistoryListByPrintID(fee.ID).Select(p =>
                {
                    var item = new { ChargeName = p.ChargeName, TotalFee = p.RealCost };
                    return item;
                }).ToArray();
                roomFeeModel.historylist = historyitems;
                list.Add(roomFeeModel);
            }
            WebUtil.WriteJsonResult(context, list);
        }
        private void wxpayroomfeecomplete(HttpContext context)
        {
            var wuser = Foresight.DataAccess.Wechat_User.GetWechat_UserByUserOpenID(wx_openid);
            string AddMan = (wuser != null && !string.IsNullOrEmpty(wuser.NickName)) ? wuser.NickName : wx_openid;
            PrintRoomFeeHistory printRoomFeeHistory = new PrintRoomFeeHistory();
            string liststr = context.Request.Params["idlist"];
            string TradeNo = context.Request["TradeNo"];
            if (string.IsNullOrEmpty(liststr))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "需要支付的费项不存在");
                return;
            }
            List<Utility.WeiXinPayModel> ModelList = JsonConvert.DeserializeObject<List<Utility.WeiXinPayModel>>(liststr);
            if (ModelList.Count == 0 && !string.IsNullOrEmpty(TradeNo))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "需要支付的费项不存在");
                return;
            }
            var history_list = new Foresight.DataAccess.RoomFeeHistory[] { };
            var fee_list = new Foresight.DataAccess.RoomFee[] { };
            if (!string.IsNullOrEmpty(TradeNo))
            {
                history_list = RoomFeeHistory.GetRoomFeeHistoryListByTradeNo(TradeNo);
                fee_list = RoomFee.GetRoomFeeListByTradeNo(TradeNo);
            }
            else
            {
                history_list = Foresight.DataAccess.RoomFeeHistory.GetRoomFeeHistoryByFeeIDList(ModelList.Select(p => p.ID).ToList());
                fee_list = Foresight.DataAccess.RoomFee.GetRoomFeeListByIDs(ModelList.Select(p => p.ID).ToList());
                if (fee_list.Length > 0)
                {
                    TradeNo = fee_list[0].TradeNo;
                }
            }
            if (history_list.Length > 0)
            {
                WebUtil.WriteJsonResult(context, "成功");
                return;
            }
            if (fee_list.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "需要支付的费项不存在");
                return;
            }
            if (string.IsNullOrEmpty(TradeNo))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "TradeNo获取失败");
                return;
            }
            Web.APPCode.PaymentHelper.SaveRoomFee(TradeNo, "微信公众号微信支付", "微信支付");
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void huishouyinreadypay(HttpContext context)
        {
            try
            {
                var config = new Utility.SiteConfig();
                bool HuiShouYin_Enable = false;
                bool.TryParse(config.HuiShouYin_Enable, out HuiShouYin_Enable);
                if (!HuiShouYin_Enable)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "汇收银支付未启用" });
                    return;
                }
                int total_fee = Convert.ToInt32(WebUtil.GetDecimalValue(context, "total_fee") * 100);
                string idlist = context.Request["idlist"];
                var biz_content = new HuiShouYin.Domain.ApplyPay_BizContent();
                biz_content.out_trade_no = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                biz_content.subject = ConfigurationManager.AppSettings["CompanyName"];
                biz_content.total_fee = total_fee.ToString();
                biz_content.client_ip = "127.0.0.1";
                biz_content.notify_url = WebUtil.GetContextPath() + "/recive/pay/notify.aspx";
                //biz_content.return_url = WebUtil.GetContextPath() + "/recive/pay/return.aspx";
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
                    biz_content.pay_option = "{\\\"idlist\\\":" + liststr + ",\\\"openid\\\":\\\"" + wx_openid + "\\\"}";
                }
                var response = HuiShouYin.MessageHandler.SendApplyPay(biz_content);
                if (response.IsError)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "汇收银服务器内部异常" });
                    return;
                }
                var items = new { status = true, hsy_enable = true, payurl = response.ApplyPay.hy_js_auth_pay_url, hy_bill_no = response.ApplyPay.hy_bill_no };
                WebUtil.WriteJson(context, items);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModuel, "huifubaoreadypay", ex);
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器内部异常");
            }
        }
        private void wxpayroomfeeready(HttpContext context)
        {
            try
            {
                string idlist = context.Request["idlist"];
                List<Utility.WeiXinPayModel> ListOption = new List<Utility.WeiXinPayModel>();
                if (!string.IsNullOrEmpty(idlist))
                {
                    ListOption = JsonConvert.DeserializeObject<List<Utility.WeiXinPayModel>>(idlist);
                }
                if (ListOption.Count == 0)
                {
                    WebUtil.WriteJson(context, new { message = "请选择需要缴费的费项" });
                    return;
                }
                List<int> fee_idlist = ListOption.Select(p => p.ID).ToList();
                var roomfee_list = Foresight.DataAccess.RoomFee.GetRoomFeeListByIDs(fee_idlist).ToArray();
                List<string> exist_tradenos = roomfee_list.Where(p => !string.IsNullOrEmpty(p.TradeNo)).Select(p => p.TradeNo).Distinct().ToList();
                if (exist_tradenos.Count > 0)
                {
                    foreach (var exist_tradeno in exist_tradenos)
                    {
                        try
                        {
                            int PayStatus = PaymentHelper.OrderQuery(exist_tradeno);
                            if (PayStatus == 2)
                            {
                                WebUtil.WriteJson(context, new { message = "选中的账单已支付成功" });
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteError("WxPayApi", "OrderQuery", ex);
                        }
                    }
                }
                int total_fee = Convert.ToInt32(WebUtil.GetDecimalValue(context, "total_fee") * 100);
                string tradeno = WxPayApi.GenerateOutTradeNo();
                List<Payment_Request> request_list = new List<Payment_Request>();
                foreach (var item in ListOption)
                {
                    var payment_request = new Foresight.DataAccess.Payment_Request();
                    payment_request.RoomFeeID = item.ID;
                    payment_request.EndTime = item.EndTime.HasValue ? Convert.ToDateTime(item.EndTime) : DateTime.MinValue;
                    payment_request.AddTime = DateTime.Now;
                    payment_request.AddMan = wx_openid;
                    request_list.Add(payment_request);
                }
                var payment = Payment.Insert_Payment(total_fee, Utility.EnumModel.PaymentTypeDefine.wx.ToString(), tradeno, 1, wx_openid, "微信公众号微信支付", CanSave: true, fee_list: roomfee_list.ToList(), request_list: request_list);
                string wxJsApiParam = string.Empty;
                JsApiPay jsApiPay = new JsApiPay(null);
                jsApiPay.openid = wx_openid;
                jsApiPay.total_fee = total_fee;
                string body = string.Empty;
                if (string.IsNullOrEmpty(body))
                {
                    var company = WebUtil.GetCompany(context);
                    body = company != null ? company.CompanyName : ConfigurationManager.AppSettings["CompanyName"];
                }
                string notify_url = WeixinConfig.notify_url;
                WxPayData unifiedOrderResult = jsApiPay.GetUnifiedOrderResult(body, tradeno, notify_url);
                wxJsApiParam = jsApiPay.GetJsApiParameters();//获取H5调起JS API参数
                WebUtil.WriteJson(context, new { Result = wxJsApiParam, TradeNo = payment.TradeNo });
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModuel, "wxpayroomfeeready", ex);
                WebUtil.WriteJson(context, new { message = "服务器内部异常" });
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
        private void loadtongzhidetail(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Wechat_Msg.GetWechat_Msg(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "ID不合法");
                return;
            }
            WebUtil.WriteJsonResult(context, new { ID = data.ID, Title = data.MsgTitle, Content = data.HTMLContent });
        }
        private void loadtongzhilist(HttpContext context)
        {
            bool HasRoom = false;
            List<int> ProjectIDList = WeixinHelper.GetMyWechatProjectIDList(wx_openid, out HasRoom);
            string MsgType = context.Request["MsgType"];
            long totals = 0;
            var list = Foresight.DataAccess.Wechat_Msg.GetWechat_MsgListByMsgType(MsgType, 0, int.MaxValue, out totals, IsWechatSend: true, ProjectIDList: ProjectIDList).ToArray();
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID > 0)
            {
                list = list.Where(p => p.ID == ID).ToArray();
            }
            string default_img = "../image/tongzhi_icon.png";
            if (MsgType.Equals(Utility.EnumModel.WechatMsgType.huodong.ToString()))
            {
                default_img = "../image/huodong_icon.png";
            }
            var items = list.Select(p =>
            {
                string Summary = string.IsNullOrEmpty(p.MsgSummary) ? "暂无详细说明" : p.MsgSummary;
                string AddTime = p.PublishTime == DateTime.MinValue ? p.AddTime.ToString("yyyy-MM-dd") : p.PublishTime.ToString("yyyy-MM-dd");
                string ImgUrl = string.IsNullOrEmpty(p.PicPath) ? default_img : WebUtil.GetContextPath() + p.PicPath;
                var item = new { ID = p.ID, ImgUrl = ImgUrl, Title = p.MsgTitle, Summary = Summary, AddTime = AddTime, MsgType = p.MsgTypeDesc };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void loadhometongzhi(HttpContext context)
        {
            bool HasRoom = false;
            List<int> ProjectIDList = WeixinHelper.GetMyWechatProjectIDList(wx_openid, out HasRoom);
            string MsgType = Utility.EnumModel.WechatMsgType.tongzhi.ToString();
            long totals = 0;
            var list = Foresight.DataAccess.Wechat_Msg.GetWechat_MsgListByMsgType(string.Empty, 0, int.MaxValue, out totals, IsWechatSend: true, ProjectIDList: ProjectIDList).ToArray();
            var tongzhilist = list.Where(p => p.MsgType.Equals(MsgType)).Take(5).Select(p =>
            {
                var item = new { ID = p.ID, Title = p.MsgTitle, ImgUrl = string.IsNullOrEmpty(p.PicPath) ? "../image/tongzhi_icon.png" : WebUtil.GetContextPath() + p.PicPath, AddTime = p.PublishTime > DateTime.MinValue ? p.PublishTime.ToString("yyyy-MM-dd") : p.AddTime.ToString("yyyy-MM-dd"), Summary = p.MsgSummary };
                return item;
            }).ToList();
            MsgType = Utility.EnumModel.WechatMsgType.huodong.ToString();
            var huodonglist = list.Where(p => p.MsgType.Equals(MsgType)).Take(5).Select(p =>
            {
                var item = new { ID = p.ID, Title = p.MsgTitle, ImgUrl = string.IsNullOrEmpty(p.PicPath) ? "../image/huodong_icon.png" : WebUtil.GetContextPath() + p.PicPath, AddTime = p.PublishTime > DateTime.MinValue ? p.PublishTime.ToString("yyyy-MM-dd") : p.AddTime.ToString("yyyy-MM-dd"), Summary = p.MsgSummary };
                return item;
            }).ToList();
            WebUtil.WriteJsonResult(context, new { tongzhilist = tongzhilist, huodonglist = huodonglist, ProjectIDList = ProjectIDList });
        }
        private void getroomfeebyopenid(HttpContext context)
        {
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            ViewRoomBasic[] roomlist = new ViewRoomBasic[] { };
            List<Dictionary<string, object>> roomitems = new List<Dictionary<string, object>>();
            string OwnerName = string.Empty;
            roomlist = ViewRoomBasic.GetRoomBasicListByOpenID(wx_openid);
            if (roomlist.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "未关联房间");
                return;
            }
            roomitems = roomlist.Select(p =>
            {
                var dic = new Dictionary<string, object>();
                dic["RoomID"] = p.RoomID;
                dic["Name"] = p.FullName.Replace("-", "") + p.Name;
                return dic;
            }).ToList();
            bool showall = false;
            bool.TryParse(context.Request.Params["showall"], out showall);
            ViewRoomFee[] feelist = new ViewRoomFee[] { };
            int[] summaryidlist = new int[] { };
            if (showall)
            {
                RoomID = 0;
            }
            else if (RoomID <= 0)
            {
                RoomID = roomlist[0].RoomID;
                OwnerName = roomlist[0].RelationName;
            }
            else
            {
                var room_basic = roomlist.FirstOrDefault(p => p.RoomID == RoomID);
                RoomID = room_basic != null ? room_basic.RoomID : 0;
                OwnerName = room_basic != null ? room_basic.RelationName : "";
            }
            feelist = ViewRoomFee.GetViewRoomFeeListByOpenID(wx_openid, RoomID).Where(p => p.TotalCost > 0).ToArray();
            summaryidlist = feelist.Select(p => p.ChargeID).ToArray();
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
                roomFeeModel.Selected = false;
                list.Add(roomFeeModel);
                HeJiCost += roomFeeModel.TotalCost;
            }
            roomFeeModel = new RoomFeeModel();
            roomFeeModel.Name = "合计";
            roomFeeModel.TotalCost = HeJiCost;
            var wechat_contact = Foresight.DataAccess.Wechat_Contact.GetWechat_ContactByPhoneType(Utility.EnumModel.WechatContactType.hujiaowuye.ToString());
            WebUtil.WriteJsonResult(context, new { summarylist = list, idlist = feelist.Select(p => p.ID).ToList(), HeJiCost = HeJiCost, roomlist = roomitems, totalsummary = roomFeeModel, wechat_contact = wechat_contact != null ? wechat_contact.PhoneNumber : "", wechat_contact_title = wechat_contact != null ? wechat_contact.Name : "", OwnerName = OwnerName, RoomID = RoomID });
        }
        #region Coom Method
        private int GetActivityID(HttpContext context)
        {
            string CookieKey = WebUtil.getApplicationPath();
            string activityid_key = string.IsNullOrEmpty(CookieKey) ? "activity" : CookieKey + "_activity";
            string activityid_str = context.Request[activityid_key];
            if (string.IsNullOrEmpty(activityid_str))
            {
                throw new Exception(CookieKey + ": activityid获取失败");
            }
            int activityid = Convert.ToInt32(activityid_str);
            if (activityid <= 0)
            {
                throw new Exception(CookieKey + ": activityid获取失败");
            }
            return activityid;
        }
        private string GetOpenID(HttpContext context)
        {
            //return "oN3xdxEMDRRPQUbAT8FkwP2FDYkU";
            string openid = context.Request["wxopenid"];
            if (!string.IsNullOrEmpty(openid) && openid != "undefined")
            {
                return openid;
            }
            string CookieKey = WebUtil.GetOpenIDPrefix();
            if (context.Request.Cookies[CookieKey] != null)
            {
                openid = context.Request.Cookies[CookieKey].Value;
            }
            if (string.IsNullOrEmpty(openid))
            {
                bool ignoreopenid = WebUtil.GetBoolValue(context, "ignoreopenid");
                if (ignoreopenid)
                {
                    return openid;
                }
                throw new Exception(CookieKey + ": openid获取失败");
            }
            return openid;
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
        public class RoomFeeModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public decimal TotalCost { get; set; }
            public string StartTime { get; set; }
            public string EndTime { get; set; }
            public int PrintID { get; set; }
            public string StartEndPoint { get; set; }
            public object[] historylist { get; set; }
            public bool Selected { get; set; }
            public bool ShowMore { get; set; }
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}