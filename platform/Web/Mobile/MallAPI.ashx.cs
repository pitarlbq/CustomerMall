using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Utility;
using WxPayAPI;

namespace Web.Mobile
{
    /// <summary>
    /// _ 的摘要说明
    /// </summary>
    public class MallAPI : IHttpHandler
    {
        const string LogModuel = "MallAPI";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.Params["action"];
            if (string.IsNullOrEmpty(action))
            {
                LogHelper.WriteDebug(LogModuel, "action为空");
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "action为空");
                return;
            }
            action = action.ToLower();
            try
            {
                switch (action)
                {
                    case "login":
                        dologin(context);
                        break;
                    case "socketinit":
                        socketinit(context);
                        break;
                    case "registercheckphone":
                        registercheckphone(context);
                        break;
                    case "completeregister":
                        completeregister(context);
                        break;
                    case "checkconnectroom":
                        checkconnectroom(context);
                        break;
                    case "getroomfeebyuid":
                        getroomfeebyuid(context);
                        break;
                    case "getroomfeebyid":
                        getroomfeebyid(context);
                        break;
                    case "getroomfeehistorybyuid":
                        getroomfeehistorybyuid(context);
                        break;
                    case "readypayroomfee":
                        readypayroomfee(context);
                        break;
                    case "getroomfeeorderlist":
                        getroomfeeorderlist(context);
                        break;
                    case "createfeeorder":
                        createfeeorder(context);
                        break;
                    case "getorderinfo":
                        getorderinfo(context);
                        break;
                    case "getorderlistinfo":
                        getorderlistinfo(context);
                        break;
                    case "wxpayorderready":
                        wxpayorderready(context);
                        break;
                    case "wxpayorderreadychongzhi":
                        wxpayorderreadychongzhi(context);
                        break;
                    case "getwuyegonggaolist":
                        getwuyegonggaolist(context);
                        break;
                    case "checkloginstatus":
                        checkloginstatus(context);
                        break;
                    case "getwuyegonggaodetail":
                        getwuyegonggaodetail(context);
                        break;
                    case "getxiaoqunewslist":
                        getxiaoqunewslist(context);
                        break;
                    case "getmyroomsourcelist":
                        getmyroomsourcelist(context);
                        break;
                    case "savebaoxiujianyi":
                        savebaoxiujianyi(context);
                        break;
                    case "getmallcategorylist":
                        getmallcategorylist(context);
                        break;
                    case "getappyouxuansourcelist":
                        getappyouxuansourcelist(context);
                        break;
                    case "getproductlistbycategoryid":
                        getproductlistbycategoryid(context);
                        break;
                    case "getmallproductdetail":
                        getmallproductdetail(context);
                        break;
                    case "getproductorderlist":
                        getproductorderlist(context);
                        break;
                    case "createproductorder":
                        createproductorder(context);
                        break;
                    case "addproducttocart":
                        addproducttocart(context);
                        break;
                    case "getshoppingcartlist":
                        getshoppingcartlist(context);
                        break;
                    case "removeshoppingcart":
                        removeshoppingcart(context);
                        break;
                    case "getshoppingcartorderlist":
                        getshoppingcartorderlist(context);
                        break;
                    case "updateshoppingcartquantity":
                        updateshoppingcartquantity(context);
                        break;
                    case "getmyshipaddressinfo":
                        getmyshipaddressinfo(context);
                        break;
                    case "getmyaddressshiprate":
                        getmyaddressshiprate(context);
                        break;
                    case "savemyaddressinfo":
                        savemyaddressinfo(context);
                        break;
                    case "getmyaddresslist":
                        getmyaddresslist(context);
                        break;
                    case "getmyaddressdetail":
                        getmyaddressdetail(context);
                        break;
                    case "removemyaddress":
                        removemyaddress(context);
                        break;
                    case "createcartorder":
                        createcartorder(context);
                        break;
                    case "getshoppingcartitemcount":
                        getshoppingcartitemcount(context);
                        break;
                    case "getmyorderlist":
                        getmyorderlist(context);
                        break;
                    case "alipayorderready":
                        alipayorderready(context);
                        break;
                    case "alipayorderreadychongzhi":
                        alipayorderreadychongzhi(context);
                        break;
                    case "closemyorder":
                        closemyorder(context);
                        break;
                    case "gethouseservicelist":
                        gethouseservicelist(context);
                        break;
                    case "gethouseservicedetail":
                        gethouseservicedetail(context);
                        break;
                    case "getapphomesource":
                        getapphomesource(context);
                        break;
                    case "getproductlistbybusinessid":
                        getproductlistbybusinessid(context);
                        break;
                    case "getbusinesslistbycategoryid":
                        getbusinesslistbycategoryid(context);
                        break;
                    case "addproducttopindan":
                        addproducttopindan(context);
                        break;
                    case "savemynickname":
                        savemynickname(context);
                        break;
                    case "createpintuanorder":
                        createpintuanorder(context);
                        break;
                    case "getmallsurveylist":
                        getmallsurveylist(context);
                        break;
                    case "getsurveyquestionsbyid":
                        getsurveyquestionsbyid(context);
                        break;
                    case "savesurveyresponse":
                        savesurveyresponse(context);
                        break;
                    case "getsurveyvotesbyid":
                        getsurveyvotesbyid(context);
                        break;
                    case "savesurveyvoteresponse":
                        savesurveyvoteresponse(context);
                        break;
                    case "savethreadpost":
                        savethreadpost(context);
                        break;
                    case "getthreadlist":
                        getthreadlist(context);
                        break;
                    case "getthreaddetail":
                        getthreaddetail(context);
                        break;
                    case "postthreadpraise":
                        postthreadpraise(context);
                        break;
                    case "postthreadcomment":
                        postthreadcomment(context);
                        break;
                    case "getthreadcommentlist":
                        getthreadcommentlist(context);
                        break;
                    case "getrotatingimages":
                        getrotatingimages(context);
                        break;
                    case "saveuserinfo":
                        saveuserinfo(context);
                        break;
                    case "getuserinfo":
                        getuserinfo(context);
                        break;
                    case "savenewphoneno":
                        savenewphoneno(context);
                        break;
                    case "savemallorderrate":
                        savemallorderrate(context);
                        break;
                    case "getmallorderratestatus":
                        getmallorderratestatus(context);
                        break;
                    case "getmyrooms":
                        getmyrooms(context);
                        break;
                    case "retrievelpwdcheckphone":
                        retrievelpwdcheckphone(context);
                        break;
                    case "completeretrievepwd":
                        completeretrievepwd(context);
                        break;
                    case "changephonecheck":
                        changephonecheck(context);
                        break;
                    case "removeuserappopenid":
                        removeuserappopenid(context);
                        break;
                    case "adduserappopenid":
                        adduserappopenid(context);
                        break;
                    case "binduserroom":
                        binduserroom(context);
                        break;
                    case "removemyroom":
                        removemyroom(context);
                        break;
                    case "savemysuggestion":
                        savemysuggestion(context);
                        break;
                    case "getmallhotline":
                        getmallhotline(context);
                        break;
                    case "getmallaboutus":
                        getmallaboutus(context);
                        break;
                    case "removemyorder":
                        removemyorder(context);
                        break;
                    case "savemallorderrefund":
                        savemallorderrefund(context);
                        break;
                    case "getmyxiaoqulist":
                        getmyxiaoqulist(context);
                        break;
                    case "getmyroomlist":
                        getmyroomlist(context);
                        break;
                    case "savereadingpage":
                        savereadingpage(context);
                        break;
                    case "getservicelist":
                        getservicelist(context);
                        break;
                    case "getservicedetail":
                        getservicedetail(context);
                        break;
                    case "getserviceratelist":
                        getserviceratelist(context);
                        break;
                    case "saveservicerate":
                        saveservicerate(context);
                        break;
                    case "getuserandbalanceinfo":
                        getuserandbalanceinfo(context);
                        break;
                    case "getuseramountbalance":
                        getuseramountbalance(context);
                        break;
                    case "getamountbalancelist":
                        getamountbalancelist(context);
                        break;
                    case "balanceorderready":
                        balanceorderready(context);
                        break;
                    case "payorderbybalance":
                        payorderbybalance(context);
                        break;
                    case "payordercheckpwd":
                        payordercheckpwd(context);
                        break;
                    case "verifypaypassword":
                        verifypaypassword(context);
                        break;
                    case "retrievelpaypwdcheckphone":
                        retrievelpaypwdcheckphone(context);
                        break;
                    case "completeretrievepaypwd":
                        completeretrievepaypwd(context);
                        break;
                    case "savenewpassword":
                        savenewpassword(context);
                        break;
                    case "savenewpaypassword":
                        savenewpaypassword(context);
                        break;
                    case "getuserpointbalance":
                        getuserpointbalance(context);
                        break;
                    case "getstaffpointbalance":
                        getstaffpointbalance(context);
                        break;
                    case "getpointbalancelist":
                        getpointbalancelist(context);
                        break;
                    case "getstaffbalancelist":
                        getstaffbalancelist(context);
                        break;
                    case "buyitemcheckpoint":
                        buyitemcheckpoint(context);
                        break;
                    case "checkproductinventory":
                        checkproductinventory(context);
                        break;
                    case "dopaypointorder":
                        dopaypointorder(context);
                        break;
                    case "dopaystaffpointorder":
                        dopaystaffpointorder(context);
                        break;
                    case "getmyfamilylist":
                        getmyfamilylist(context);
                        break;
                    case "removemyfamily":
                        removemyfamily(context);
                        break;
                    case "getmyfamilydetail":
                        getmyfamilydetail(context);
                        break;
                    case "savemyfamilyinfo":
                        savemyfamilyinfo(context);
                        break;
                    case "gettaglistbycategoryid":
                        gettaglistbycategoryid(context);
                        break;
                    case "gethouseserviceorderlist":
                        gethouseserviceorderlist(context);
                        break;
                    case "createhouseserviceorder":
                        createhouseserviceorder(context);
                        break;
                    case "getllingsdkkey":
                        getllingsdkkey(context);
                        break;
                    case "getmallchatdetaillist":
                        getmallchatdetaillist(context);
                        break;
                    case "postmallchatcontent":
                        postmallchatcontent(context);
                        break;
                    case "getappversion":
                        getappversion(context);
                        break;
                    case "checkuserpostthreadstatus":
                        checkuserpostthreadstatus(context);
                        break;
                    case "getmydoordevices":
                        getmydoordevices(context);
                        break;
                    case "getmyremotedoordevices":
                        getmyremotedoordevices(context);
                        break;
                    case "doremoteopendoor":
                        doremoteopendoor(context);
                        break;
                    case "uploadeditimage":
                        uploadeditimage(context);
                        break;
                    case "getencriptuid":
                        getencriptuid(context);
                        break;
                    case "wxh5payorderready":
                        wxh5payorderready(context);
                        break;
                    case "alipayh5payorderready":
                        alipayh5payorderready(context);
                        break;
                    case "thridbindlogin":
                        thridbindlogin(context);
                        break;
                    case "firstloginsaveuser":
                        firstloginsaveuser(context);
                        break;
                    case "getexisitphoneverifycode":
                        getexisitphoneverifycode(context);
                        break;
                    case "getmallamountsummary":
                        getmallamountsummary(context);
                        break;
                    case "getmycouponlist":
                        getmycouponlist(context);
                        break;
                    case "getmycouponcounts":
                        getmycouponcounts(context);
                        break;
                    case "getordercouponlist":
                        getordercouponlist(context);
                        break;
                    case "sendphoneverifycode":
                        sendphoneverifycode(context);
                        break;
                    case "getmallshareinfo":
                        getmallshareinfo(context);
                        break;
                    case "getmyunreadmallcoupon":
                        getmyunreadmallcoupon(context);
                        break;
                    case "takeallmycoupons":
                        takeallmycoupons(context);
                        break;
                    case "readallmycoupons":
                        readallmycoupons(context);
                        break;
                    case "gettakecouponlist":
                        gettakecouponlist(context);
                        break;
                    case "takemallcoupon":
                        takemallcoupon(context);
                        break;
                    case "dopayfreeorder":
                        dopayfreeorder(context);
                        break;
                    case "createopendoorqrcode":
                        createopendoorqrcode(context);
                        break;
                    case "getopendoorqrcode":
                        getopendoorqrcode(context);
                        break;
                    case "confirmreceivemyorder":
                        confirmreceivemyorder(context);
                        break;
                    case "takemycoupon":
                        takemycoupon(context);
                        break;
                    case "getphraseuserlist":
                        getphraseuserlist(context);
                        break;
                    case "getmallhotsalelist":
                        getmallhotsalelist(context);
                        break;
                    case "savephraseuser":
                        savephraseuser(context);
                        break;
                    case "getxiaoquqrcode":
                        getxiaoquqrcode(context);
                        break;
                    case "checkthridenablestatus":
                        checkthridenablestatus(context);
                        break;
                    case "savedeviceid":
                        savedeviceid(context);
                        break;
                    case "getservicechulilist"://获取工单处理列表
                        getservicechulilist(context);
                        break;
                    case "getbusinessinfobyid"://
                        getbusinessinfobyid(context);
                        break;
                    case "getmyshareorderanalysis":
                        getmyshareorderanalysis(context);
                        break;
                    case "getvisitqrcodecount":
                        getvisitqrcodecount(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "action不合法");
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModuel, action, ex);
                if (ex.Message.Equals("get_uid_failed"))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.AuthenticationFail, ex.Message);
                    return;
                }
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
            }
        }
        private void getbusinessinfobyid(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Mall_Business data = null;
            if (ID > 0)
            {
                data = Mall_Business.GetMall_Business(ID);
            }
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "商家不存在");
                return;
            }
            var image_list = Mall_Business_Picture.GetMall_Business_PictureListByID(data.ID);
            var image_items = image_list.Select(p =>
            {
                var item = new { imageurl = WebUtil.GetContextPath() + p.LargePicPath };
                return item;
            }).ToList();
            if (!string.IsNullOrEmpty(data.CoverImage))
            {
                image_items.Insert(0, new { imageurl = WebUtil.GetContextPath() + data.CoverImage });
            }
            var businessinfo = new { id = data.ID, title = data.BusinessName, address = data.BusinessAddress, summary = data.Remark, phonenumber = data.ContactPhone };
            WebUtil.WriteJsonResult(context, new { businessinfo = businessinfo, imagelist = image_items });
        }
        private void getservicechulilist(HttpContext context)
        {
            var uid = GetUID(context);
            int ID = WebUtil.GetIntValue(context, "ID");
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
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void savedeviceid(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = 0;
            try
            {
                uid = GetUID(context, out user);
            }
            catch (Exception)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "未登录");
                return;
            }
            string DeviceId = context.Request["device_id"];
            string DeviceType = context.Request["device_type"];
            if (!string.IsNullOrEmpty(DeviceId))
            {
                user.DeviceId = DeviceId;
                user.DeviceType = DeviceType;
                user.Save();
            }
            WebUtil.WriteJsonResult(context, "保存成功");
        }
        private void checkthridenablestatus(HttpContext context)
        {
            var list = SysConfig.GetSysConfigs().ToArray();
            string Name = Utility.EnumModel.Mall_ThridLoginDefine.wxlogin.ToString();
            List<SysConfig> add_list = new List<SysConfig>();
            var wx_item = list.FirstOrDefault(p => p.Name.Equals(Name));
            if (wx_item == null)
            {
                wx_item = new SysConfig();
                wx_item.Name = Name;
                wx_item.Value = "0";
                wx_item.AddTime = DateTime.Now;
                add_list.Add(wx_item);
            }
            Name = Utility.EnumModel.Mall_ThridLoginDefine.weibologin.ToString();
            var weibo_item = list.FirstOrDefault(p => p.Name.Equals(Name));
            if (weibo_item == null)
            {
                wx_item = new SysConfig();
                wx_item.Name = Name;
                wx_item.Value = "0";
                wx_item.AddTime = DateTime.Now;
                add_list.Add(wx_item);
            }
            Name = Utility.EnumModel.Mall_ThridLoginDefine.qqlogin.ToString();
            var qq_item = list.FirstOrDefault(p => p.Name.Equals(Name));
            if (qq_item == null)
            {
                wx_item = new SysConfig();
                wx_item.Name = Name;
                wx_item.Value = "0";
                wx_item.AddTime = DateTime.Now;
                add_list.Add(wx_item);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in add_list)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                }
            }
            bool showweixin = wx_item.Value.Equals("1");
            bool showqq = qq_item.Value.Equals("1");
            bool showweibo = weibo_item.Value.Equals("1");
            WebUtil.WriteJsonResult(context, new { showweixin = showweixin, showweibo = showweibo, showqq = showqq });
        }
        private void getxiaoquqrcode(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string FullPath = string.Empty;
            string pageurl = Utility.Tools.Encrypt(ID.ToString());
            var qrcode = Foresight.DataAccess.Wechat_Qrcode.GetWechat_QrcodeByPageURL(pageurl);
            if (qrcode == null)
            {
                string squarePicUrl = string.Empty;
                string QrcodePath = Web.APPCode.WeixinHelper.CreateQrCode(pageurl, out squarePicUrl);
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
            WebUtil.WriteJsonResult(context, new { qrcodeurl = FullPath });
        }
        private void savephraseuser(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "id");
            int UserID = WebUtil.GetIntValue(context, "userid");
            int SurveyID = WebUtil.GetIntValue(context, "surveyid");
            var survey = Wechat_Survey.GetWechat_Survey(SurveyID);
            if (survey == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该点赞活动已失效");
                return;
            }
            var list = Foresight.DataAccess.Wechat_SurveyOptionResponse.GetWechat_SurveyQuestionResponseListByQuestionID(ID, uid);
            bool canvote = Wechat_SurveyQuestion.CheckWechat_SurveyQuestionVoteStatus(survey, uid, list);
            if (!canvote)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您已点过赞了");
                return;
            }
            Wechat_SurveyQuestion question = null;
            if (ID > 0)
            {
                question = Foresight.DataAccess.Wechat_SurveyQuestion.GetWechat_SurveyQuestion(ID);
            }
            if (question == null)
            {
                var my_user = User.GetUser(UserID);
                question = new Wechat_SurveyQuestion();
                question.SurveyID = SurveyID;
                question.QuestionContent = my_user.LoginName;
                question.QuestionType = 1;
                question.SortOrder = 1;
                question.AddTime = DateTime.Now;
                question.AddMan = user.LoginName;
                question.CoverImg = my_user.HeadImg;
                question.QuestionSummary = my_user.Summary;
                question.IsDisabled = false;
                question.IsDeleted = false;
                question.UserID = UserID;
            }

            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    question.Save(helper);
                    var data = new Wechat_SurveyOptionResponse();
                    data.AddTime = DateTime.Now;
                    data.UserID = uid;
                    data.SurveyQuestionOptionID = 0;
                    data.SurveyQuestionID = question.ID;
                    data.Save(helper);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "savephraseuser", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getmallhotsalelist(HttpContext context)
        {
            string keywords = context.Request["keywords"];
            int sortby = WebUtil.GetIntValue(context, "sortby");
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            //热门消费
            var hotsalelist = Mall_HotSaleDetail.GetMall_HotSaleListByKeywords(keywords, sortby, startRowIndex, pageSize);
            WebUtil.WriteJsonResult(context, new { list = hotsalelist });
        }
        private void getphraseuserlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var survery_list = Wechat_Survey.GetWechat_SurveyListByUserID(uid);
            if (survery_list.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "暂无相关点赞人员");
                return;
            }
            var data = survery_list[0];
            var list = Foresight.DataAccess.Wechat_SurveyQuestion.GetWechat_SurveyQuestionPhraseListByUserID(uid, data.ID);
            List<int> SurveryIDList = new List<int>();
            SurveryIDList.Add(data.ID);
            var response_list = Foresight.DataAccess.Wechat_SurveyOptionResponse.GetWechat_SurveyQuestionResponseListBySurveyIDList(SurveryIDList);
            bool default_canvote = true;
            string default_votedesc = "点赞";
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
                string imageurl = string.IsNullOrEmpty(p["CoverImg"].ToString()) ? "../image/error-img.png" : WebUtil.GetContextPath() + p["CoverImg"].ToString();
                var my_response_list = response_list.Where(q => q.SurveyQuestionID == Convert.ToInt32(p["ID"])).ToArray();
                string votecountdesc = "总点赞数: " + my_response_list.Length;
                bool canvote = false;
                string votedesc = default_votedesc;
                if (default_canvote)
                {
                    canvote = Wechat_SurveyQuestion.CheckWechat_SurveyQuestionVoteStatus(data, uid, my_response_list);
                }
                votedesc = canvote ? "点赞" : votedesc;
                var item = new { id = Convert.ToInt32(p["ID"]), imageurl = imageurl, title = p["QuestionContent"].ToString(), summary = p["QuestionSummary"].ToString(), votecountdesc = votecountdesc, canvote = canvote, votedesc = votedesc, userid = Convert.ToInt32(p["UserID"]) };
                return item;
            });
            var form = new { id = data.ID, title = data.Title, summary = data.Description };
            WebUtil.WriteJsonResult(context, new { list = items, form = form });
        }
        private void takemycoupon(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "id");
            var data = Mall_CouponUser.GetMall_CouponUser(ID);
            if (!data.IsRead)
            {
                data.IsRead = true;
                data.ReadDate = DateTime.Now;
            }
            data.IsTaken = true;
            data.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void confirmreceivemyorder(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "id");
            var order = Foresight.DataAccess.Mall_Order.GetMall_Order(ID);
            order.OrderStatus = 3;
            order.CompleteTime = DateTime.Now;
            order.CompleteUserName = user.LoginName;
            order.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getopendoorqrcode(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int id = WebUtil.GetIntValue(context, "id");
            var data = Mall_DoorRemoteQrCode.GetMall_DoorRemoteQrCode(id);
            string shareUrl = WebUtil.GetContextPath() + "/WeiXin/MallDoorQrCode.aspx?CodeID=" + data.ID.ToString();
            WebUtil.WriteJsonResult(context, new { id = data.ID, nickname = data.NickName, sex = data.Sex, endtime = data.EndTime.ToString("HH:mm"), imagepath = WebUtil.GetContextPath() + data.QrCodePath, OpenCount = data.EffecNumber > 0 ? data.EffecNumber : 1, shareUrl = shareUrl });
        }
        private void getvisitqrcodecount(HttpContext context)
        {
            var list = SysConfig.Get_SysConfigList();
            string Name = SysConfigNameDefine.QrCodeMaxEndTime.ToString();
            var timeData = list.FirstOrDefault(p => p.Name.Equals(Name));
            Name = SysConfigNameDefine.QrCodeMaxOpenCount.ToString();
            var countData = list.FirstOrDefault(p => p.Name.Equals(Name));
            int MaxEndTime = 10;
            int MaxOpenCount = 5;
            if (timeData != null)
            {
                int.TryParse(timeData.Value, out MaxEndTime);
            }
            if (countData != null)
            {
                int.TryParse(countData.Value, out MaxOpenCount);
            }
            MaxEndTime = MaxEndTime > 0 ? MaxEndTime : 10;
            MaxOpenCount = MaxOpenCount > 0 ? MaxOpenCount : 5;
            WebUtil.WriteJsonResult(context, new { MaxOpenCount = MaxOpenCount, MaxEndTime = MaxEndTime });
        }
        private void createopendoorqrcode(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int id = WebUtil.GetIntValue(context, "id");
            var device = Mall_DoorDevice.GetMall_DoorDeviceSDKKeyByID(id);
            string nickname = context.Request["nickname"];
            string sex = context.Request["sex"];
            int endtime = WebUtil.GetIntValue(context, "endtime");
            int OpenCount = WebUtil.GetIntValue(context, "OpenCount");
            OpenCount = OpenCount > 0 ? OpenCount : 1;
            string lingLingId = string.Empty;
            string strKey = string.Empty;
            int codeId = 0;
            string qrcodeKey = string.Empty;
            bool result = Utility.LLingHelper.doAddVisitorQrCode(device.SDKKey, endtime, OpenCount, out lingLingId, out strKey, out  codeId, out qrcodeKey);
            if (!result)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "门禁服务器异常");
                return;
            }
            string squarePicUrl = string.Empty;
            string QrcodePath = Web.APPCode.WeixinHelper.CreateQrCode(qrcodeKey, out squarePicUrl);
            var data = new Mall_DoorRemoteQrCode();
            data.DoorDeviceID = device.ID;
            data.NickName = nickname;
            data.Sex = sex;
            data.StartTime = DateTime.Now;
            data.EndTime = DateTime.Now.AddMinutes(endtime);
            data.EndMinute = endtime;
            data.LingLingID = lingLingId;
            data.EffecNumber = OpenCount;
            data.StrKey = strKey;
            data.UseType = 1;
            data.AddTime = DateTime.Now;
            data.AddUserName = user.LoginName;
            data.CodeID = codeId;
            data.QrCodeKey = qrcodeKey;
            data.QrCodePath = QrcodePath;
            data.OpenCount = OpenCount;
            data.Save();
            WebUtil.WriteJsonResult(context, new { id = data.ID });
        }
        private void dopayfreeorder(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int orderid = WebUtil.GetIntValue(context, "orderid");
            string ids = context.Request["orderidlist"];
            List<int> OrderIDList = new List<int>();
            if (!string.IsNullOrEmpty(ids))
            {
                OrderIDList = JsonConvert.DeserializeObject<List<int>>(ids);
            }
            if (!OrderIDList.Contains(orderid) && orderid > 0)
            {
                OrderIDList.Add(orderid);
            }
            var order_list = Mall_Order.GetMall_OrderListByIDList(OrderIDList);
            bool can_socket_notify = false;
            foreach (var order in order_list)
            {
                if (order.TotalOrderCost > 0)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非免费订单");
                    return;
                }
                order.PayTime = DateTime.Now;
                order.PayUserName = user.LoginName;
                order.PaymentMethod = Utility.EnumModel.Mall_OrderPaymentMethodDefine.free.ToString();
                if (order.ProductTypeID == 10)
                {
                    order.OrderStatus = 3;
                }
                else
                {
                    order.OrderStatus = 5;
                    order.IsReadNewOrder = false;
                    can_socket_notify = true;
                }
                order.Save();
                var list = RoomFee.GetRoomFeeListByTradeNo(order.TradeNo, OrderID: order.ID);
                if (list.Length > 0)
                {
                    Web.APPCode.PaymentHelper.SaveRoomFee(order.TradeNo, "APP福顺券减免", "减免");
                }
            }
            if (can_socket_notify)
            {
                APPCode.SocketNotify.PushSocketNotifyAlert(Utility.EnumModel.SocketNotifyDefine.notifyorderpaied);
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void takemallcoupon(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int couponid = WebUtil.GetIntValue(context, "couponid");
            if (couponid <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "福顺券无效");
                return;
            }
            var coupon = Mall_Coupon.GetMall_Coupon(couponid);
            if (coupon == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "福顺券无效");
                return;
            }
            var coupon_user_list = Mall_CouponUser.GetMall_CouponUserListByCouponType(5, uid);
            var data = coupon_user_list.FirstOrDefault(p => p.CouponID == couponid);
            if (data != null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您已领取过");
                return;
            }
            data = new Mall_CouponUser();
            data.UserID = uid;
            data.CouponID = couponid;
            data.AddTime = DateTime.Now;
            data.AddUserMan = user.LoginName;
            data.IsUsed = false;
            data.UseType = 0;
            data.CouponType = 5;
            data.AmountRuleID = 0;
            data.IsSent = true;
            data.IsTaken = true;
            data.IsRead = true;
            data.IsActive = true;
            data.StartTime = coupon.StartTime;
            data.EndTime = coupon.EndTime;
            data.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void gettakecouponlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = 0;
            try
            {
                uid = GetUID(context, out user);
            }
            catch (Exception)
            {
            }
            int CouponType = WebUtil.GetIntValue(context, "coupontype");
            int ProductID = WebUtil.GetIntValue(context, "productid");
            int BusinessID = WebUtil.GetIntValue(context, "businessid");
            var coupon_list = Mall_Coupon.GetMall_CouponListByCouponType(CouponType, ProductID: ProductID, BusinessID: BusinessID);
            var coupon_user_list = Mall_CouponUser.GetMall_CouponUserListByCouponType(5, uid);
            var coupon_items = coupon_list.Select(p =>
            {
                var my_coupon_user = coupon_user_list.FirstOrDefault(q => q.CouponID == p.ID);
                bool istaken = my_coupon_user != null;
                string title = p.CouponName;
                if (istaken)
                {
                    title = p.CouponName + "(已领取)";
                }
                var item = new { id = p.ID, title = title, istaken = istaken };
                return item;
            });
            bool hascoupon = coupon_list.Length > 0;
            WebUtil.WriteJsonResult(context, new { couponlist = coupon_items, hascoupon = hascoupon });
        }
        private void readallmycoupons(HttpContext context)
        {
            var liststr = context.Request["list"];
            List<Dictionary<string, object>> List = new List<Dictionary<string, object>>();
            if (!string.IsNullOrEmpty(liststr))
            {
                List = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(liststr);
            }
            List<int> IDList = List.Select(p => Convert.ToInt32(p["ID"])).ToList();
            if (IDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        helper.Execute("update [Mall_CouponUser] set [IsRead]=1,[ReadDate]=getdate() where ID in (" + string.Join(",", IDList.ToArray()) + ");", CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModuel, "readallmycoupons", ex);
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                        return;
                    }
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void takeallmycoupons(HttpContext context)
        {
            var liststr = context.Request["list"];
            List<Dictionary<string, object>> List = new List<Dictionary<string, object>>();
            if (!string.IsNullOrEmpty(liststr))
            {
                List = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(liststr);
            }
            List<int> IDList = List.Select(p => Convert.ToInt32(p["ID"])).ToList();
            if (IDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        helper.Execute("update [Mall_CouponUser] set [IsRead]=1,[ReadDate]=getdate(),[IsTaken]=1 where ID in (" + string.Join(",", IDList.ToArray()) + ");", CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModuel, "takeallmycoupons", ex);
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                        return;
                    }
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getmyunreadmallcoupon(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = 0;
            try
            {
                uid = GetUID(context, out user);
            }
            catch (Exception)
            {
            }
            if (uid <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "未登录");
                return;
            }
            List<Dictionary<string, object>> items = new List<Dictionary<string, object>>();
            List<Dictionary<string, object>> expire_items = Mall_CouponUser.GetExpiringMall_CouponUserListByUserID(uid);
            if (expire_items.Count == 0)
            {
                items = Mall_CouponUser.GetMySendMall_CouponUserListByUserID(uid);
            }
            if (items.Count == 0 && expire_items.Count == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有相关优惠券");
                return;
            }
            var coupon_images = Mall_RotatingImage.GetMall_RotatingImages().Where(p => p.IsActive).ToArray();
            string coupon_background = string.Empty;
            string expire_coupon_background = string.Empty;
            if (coupon_images.Length > 0)
            {
                var coupon_image = coupon_images.FirstOrDefault(p => p.Type == 8);
                coupon_background = coupon_image != null ? WebUtil.GetContextPath() + coupon_image.ImagePath : "";
                var expire_coupon_image = coupon_images.FirstOrDefault(p => p.Type == 10);
                expire_coupon_background = expire_coupon_image != null ? WebUtil.GetContextPath() + expire_coupon_image.ImagePath : "";
            }
            WebUtil.WriteJsonResult(context, new { show_coupon = true, list = items, coupon_background = coupon_background, expiring_list = expire_items, expire_coupon_background = expire_coupon_background });
        }
        private void getmallshareinfo(HttpContext context)
        {
            string devicetype = context.Request["devicetype"];
            var list = Mall_Content.GetMall_Contents().ToArray();
            var title_item = list.FirstOrDefault(p => p.Name.Equals(Utility.EnumModel.MallContentNameDefine.sharetitle.ToString()));
            string title = title_item != null ? title_item.Value : "福顺居";

            var description_item = list.FirstOrDefault(p => p.Name.Equals(Utility.EnumModel.MallContentNameDefine.sharedescription.ToString()));
            string description = description_item != null ? description_item.Value : "福顺居业主APP下载";

            string downloadurl = string.Empty;
            if (devicetype.Equals("android"))
            {
                var android_item = list.FirstOrDefault(p => p.Name.Equals(Utility.EnumModel.MallContentNameDefine.androiddownloadurl.ToString()));
                downloadurl = android_item != null ? android_item.Value : "";
            }
            else
            {
                var ios_item = list.FirstOrDefault(p => p.Name.Equals(Utility.EnumModel.MallContentNameDefine.iosdownloadurl.ToString()));
                downloadurl = ios_item != null ? ios_item.Value : "";
            }
            WebUtil.WriteJsonResult(context, new { title = title, description = description, downloadurl = downloadurl });
        }
        private void getordercouponlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int id = WebUtil.GetIntValue(context, "id");
            int productid = WebUtil.GetIntValue(context, "productid");
            string cartidlist = context.Request["cartidlist"];
            int paymentid = WebUtil.GetIntValue(context, "paymentid");
            int type = WebUtil.GetIntValue(context, "type");
            decimal totalprice = WebUtil.GetDecimalValue(context, "totalprice");
            var list = Mall_CouponUser.GetOrderMall_CouponUserList(type, uid, id, productid, paymentid, cartidlist);
            List<int> CouponIDList = list.Select(p => p.CouponID).ToList();
            var all_coupons = Mall_Coupon.GetMall_CouponListByIDList(CouponIDList);
            list = list.Where(p => all_coupons.Select(q => q.ID).ToList().Contains(p.CouponID)).ToArray();
            var items = new List<Dictionary<string, object>>();
            List<int> MyIDList = new List<int>();
            foreach (var item in list)
            {
                var my_coupon = all_coupons.FirstOrDefault(q => q.ID == item.CouponID);
                if (my_coupon == null)
                {
                    continue;
                }
                decimal price = Mall_Coupon.CalculateCouponPrice(totalprice, my_coupon);
                if (price <= 0)
                {
                    continue;
                }
                if (MyIDList.Contains(item.CouponID))
                {
                    continue;
                }
                MyIDList.Add(item.CouponID);
                var dic = new Dictionary<string, object>();
                dic.Add("id", item.ID);
                dic.Add("text", my_coupon.CouponName);
                dic.Add("selected", "");
                dic.Add("price", price);
                dic.Add("pricedesc", "￥-" + price.ToString("0.00"));
                items.Add(dic);
            }
            WebUtil.WriteJsonResult(context, new { couponlist = items });
        }
        private void getmycouponcounts(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int nottakecount = Mall_CouponUser.GetMall_CouponUserCountByUserIDStatus(0, uid);
            int notusecount = Mall_CouponUser.GetMall_CouponUserCountByUserIDStatus(1, uid);
            int usedcount = Mall_CouponUser.GetMall_CouponUserCountByUserIDStatus(2, uid);
            int expiredcount = Mall_CouponUser.GetMall_CouponUserCountByUserIDStatus(3, uid);
            WebUtil.WriteJsonResult(context, new { nottakecount = nottakecount, notusecount = notusecount, usedcount = usedcount, expiredcount = expiredcount });
        }
        private void getmycouponlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int status = WebUtil.GetIntValue(context, "status");
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            long totals = 0;
            var user_coupon_list = Foresight.DataAccess.Mall_CouponUser.GetMall_CouponUserListByStatus(status, startRowIndex, pageSize, out totals, uid);
            List<int> CouponIDList = user_coupon_list.Select(p => p.CouponID).Distinct().ToList();
            var coupon_list = Foresight.DataAccess.Mall_Coupon.GetMall_CouponListByIDList(CouponIDList);
            var coupon_product_list = Mall_CouponProduct.GetMall_CouponProductListByIDList(CouponIDList);
            var items = user_coupon_list.Select(p =>
            {
                var my_coupon = coupon_list.FirstOrDefault(q => q.ID == p.CouponID);
                string title = "已移除";
                string time = string.Empty;
                string coupontype = string.Empty;
                string price = string.Empty;
                string usedesc = string.Empty;
                string usetype = string.Empty;
                int coupontypeid = 0;
                int relatedid = 0;
                if (my_coupon != null)
                {
                    title = my_coupon.CouponName;
                    time = my_coupon.ActiveTimeRangeDesc;
                    coupontype = my_coupon.CouponTypeDesc;
                    price = my_coupon.UseTitle;
                    usedesc = my_coupon.UseSubTitle;
                    usetype = my_coupon.UseForALLDesc;
                    coupontypeid = my_coupon.CouponType;
                    if (my_coupon.IsUseForALLProduct || my_coupon.IsUseForALLService || my_coupon.IsUseForALLStore)
                    {
                        coupontypeid = 3;
                    }
                    else
                    {
                        var my_coupon_product_list = coupon_product_list.Where(q => q.CouponID == my_coupon.ID).ToArray();
                        if (my_coupon_product_list.Length > 0)
                        {
                            if (coupontypeid == 1)
                            {
                                foreach (var my_coupon_product in my_coupon_product_list)
                                {
                                    if (my_coupon_product.ProductID > 0)
                                    {
                                        relatedid = my_coupon_product.ProductID;
                                        break;
                                    }
                                }
                            }
                            else if (coupontypeid == 2)
                            {
                                foreach (var my_coupon_product in my_coupon_product_list)
                                {
                                    if (my_coupon_product.BusinessID > 0)
                                    {
                                        relatedid = my_coupon_product.BusinessID;
                                        break;
                                    }
                                }
                            }
                            else if (coupontypeid == 4)
                            {
                                foreach (var my_coupon_product in my_coupon_product_list)
                                {
                                    if (my_coupon_product.ProductCategoryID > 0)
                                    {
                                        relatedid = my_coupon_product.ProductCategoryID;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                var item = new { id = p.ID, title = title, time = time, coupontype = coupontype, price = price, usedesc = usedesc, usetype = usetype, coupontypeid = coupontypeid, relatedid = relatedid };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void wxh5payorderready(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int paymentid = WebUtil.GetIntValue(context, "paymentid");
            int orderid = WebUtil.GetIntValue(context, "orderid");
            var order = Foresight.DataAccess.Mall_Order.GetMall_Order(orderid);
            if (order == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单不存在");
                return;
            }
            if (order.IsClosed)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单已关闭");
                return;
            }
            if (order.OrderStatus != 1)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单已支付");
                return;
            }
            if (!string.IsNullOrEmpty(order.TradeNo))
            {
                try
                {
                    int PayStatus = APPCode.PaymentHelper.OrderQuery(order.TradeNo);
                    if (PayStatus == 2)
                    {
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "选中的订单已支付成功");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError(LogModuel, "wxh5payorderready.OrderQuery", ex);
                }
            }
            string TradeNo = WxPayApi.GenerateOutTradeNo();
            Foresight.DataAccess.Payment payment = null;
            if (paymentid > 0)
            {
                payment = Payment.GetPayment(paymentid);
                TradeNo = payment != null ? payment.TradeNo : TradeNo;
            }
            var all_request_list = new List<Payment_Request>();
            var all_fee_list = new List<RoomFee>();
            var all_order_list = new List<Mall_Order>();
            bool IsWuYe = false;
            if (!string.IsNullOrEmpty(order.TradeNo))
            {
                payment = Foresight.DataAccess.Payment.GetPaymentByTradeNo(order.TradeNo);
                if (order.ProductTypeID == 10)
                {
                    var fee_list = Foresight.DataAccess.RoomFee.GetRoomFeeListByTradeNo(order.TradeNo, OrderID: order.ID);
                    foreach (var item in fee_list)
                    {
                        item.TradeNo = TradeNo;
                        all_fee_list.Add(item);
                    }
                    all_request_list = Payment_Request.GetPayment_RequestByTradeNo(order.TradeNo, OrderID: order.ID).ToList();
                    IsWuYe = true;
                }
            }
            order.TradeNo = TradeNo;
            all_order_list.Add(order);
            payment = Payment.Insert_Payment(order.TotalOrderCost * 100, Utility.EnumModel.PaymentTypeDefine.app_wx.ToString(), order.TradeNo, 1, user.LoginName, "H5支付微信支付申请", payment: payment, request_list: all_request_list, fee_list: all_fee_list, order_list: all_order_list, OrderID: order.ID, IsWuYe: IsWuYe);
            var orderitems = Foresight.DataAccess.Mall_OrderItem.GetMall_OrderItemListByOrderID(orderid);
            string ProductNames = string.Empty;
            int count = 0;
            foreach (var orderItem in orderitems)
            {
                count++;
                if (count >= 2)
                {
                    ProductNames += "等" + orderitems.Length.ToString() + "项";
                    break;
                }
                if (count > 1)
                {
                    ProductNames += "," + orderItem.ProductTitle;
                    continue;
                }
                ProductNames += orderItem.ProductTitle;
            }
            try
            {
                Dictionary<string, string> result = APPCode.PaymentHelper.H5WxPayUnifiedorder(order.TradeNo, new SiteConfig().SystemName + ProductNames, (order.TotalOrderCost * 100).ToString("0"));
                if (result.ContainsKey("failure"))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, result["failure"]);
                }
                else
                {
                    WebUtil.WriteJsonResult(context, new { mweb_url = result["mweb_url"] });
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModuel, "wxh5payorderready", ex);
                WebUtil.WriteJsonError(context, ErrorCode.ServerError, ex.Message);
            }
        }
        public void alipayh5payorderready(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var now = DateTime.Now;
            int paymentid = WebUtil.GetIntValue(context, "paymentid");
            int orderid = WebUtil.GetIntValue(context, "orderid");
            string ids = context.Request["orderidlist"];
            List<int> OrderIDList = new List<int>();
            if (!string.IsNullOrEmpty(ids))
            {
                OrderIDList = JsonConvert.DeserializeObject<List<int>>(ids);
            }
            if (!OrderIDList.Contains(orderid) && orderid > 0)
            {
                OrderIDList.Add(orderid);
            }
            var order_list = Mall_Order.GetMall_OrderListByIDList(OrderIDList);
            if (order_list.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单不存在");
                return;
            }
            int TotalOrderPointCost = order_list.Where(p => p.TotalOrderPointCost > 0).Sum(p => p.TotalOrderPointCost);
            if (TotalOrderPointCost > 0)
            {
                var total_point_balance = Mall_UserPoint.GetMall_UserPointBalance(uid);
                if (total_point_balance < TotalOrderPointCost)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前积分不足");
                    return;
                }
            }
            decimal TotalOrderCost = order_list.Sum(p => p.TotalOrderCost);
            if (TotalOrderCost <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前订单金额为0");
                return;
            }
            Foresight.DataAccess.Payment payment = null;
            string TradeNo = WxPayApi.GenerateOutTradeNo();
            if (paymentid > 0)
            {
                payment = Payment.GetPayment(paymentid);
                TradeNo = payment != null ? payment.TradeNo : TradeNo;
            }
            var all_request_list = new List<Payment_Request>();
            var all_fee_list = new List<RoomFee>();
            var all_order_list = new List<Mall_Order>();
            foreach (var order in order_list)
            {
                if (order.IsClosed)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单已关闭");
                    return;
                }
                if (order.OrderStatus != 1)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单已支付");
                    return;
                }
                if (!string.IsNullOrEmpty(order.TradeNo))
                {
                    try
                    {
                        int PayStatus = APPCode.PaymentHelper.OrderQuery(order.TradeNo);
                        if (PayStatus == 2)
                        {
                            WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "选中的订单已支付成功");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteError(LogModuel, "alipayh5payorderready.OrderQuery", ex);
                    }
                    if (order.ProductTypeID == 10)
                    {
                        var fee_list = Foresight.DataAccess.RoomFee.GetRoomFeeListByTradeNo(order.TradeNo, OrderID: order.ID);
                        foreach (var item in fee_list)
                        {
                            item.TradeNo = TradeNo;
                            all_fee_list.Add(item);
                        }
                        var my_request_list = Payment_Request.GetPayment_RequestByTradeNo(order.TradeNo, OrderID: order.ID).ToList();
                        foreach (var item in my_request_list)
                        {
                            all_request_list.Add(item);
                        }
                    }
                }
                order.TradeNo = TradeNo;
                order.PaymentMethod = Utility.EnumModel.Mall_OrderPaymentMethodDefine.wxpay.ToString();
                all_order_list.Add(order);
            }
            payment = Payment.Insert_Payment(TotalOrderCost * 100, Utility.EnumModel.PaymentTypeDefine.app_alipay.ToString(), TradeNo, 1, user.LoginName, "APP支付支付宝申请", payment: payment, request_list: all_request_list, fee_list: all_fee_list, order_list: all_order_list);
            var orderitems = Foresight.DataAccess.Mall_OrderItem.GetMall_OrderItemListByOrderIDList(OrderIDList);
            string ProductNames = string.Empty;
            int count = 0;
            foreach (var orderItem in orderitems)
            {
                count++;
                if (count >= 2)
                {
                    ProductNames += "等" + orderitems.Length.ToString() + "项";
                    break;
                }
                if (count > 1)
                {
                    ProductNames += "," + orderItem.ProductTitle;
                    continue;
                }
                ProductNames += orderItem.ProductTitle;
            }
            DefaultAopClient client = new DefaultAopClient(AlipayConfig.mobile_gatewayUrl, AlipayConfig.mobile_app_id, AlipayConfig.mobile_private_key_value, "json", "1.0", AlipayConfig.sign_type, AlipayConfig.mobile_public_key_value, AlipayConfig.charset, false);
            // 组装业务参数model
            AlipayTradeWapPayModel model = new AlipayTradeWapPayModel();
            model.Body = ProductNames;
            model.Subject = new SiteConfig().SystemName;
            model.TotalAmount = TotalOrderCost.ToString("0.00");
            model.OutTradeNo = TradeNo;
            model.ProductCode = AlipayConfig.wap_product_code;
            model.QuitUrl = "";
            AlipayTradeWapPayRequest request = new AlipayTradeWapPayRequest();
            // 设置支付完成同步回调地址
            var userkey = context.Request["userkey"];
            request.SetReturnUrl(AlipayConfig.wap_return_url + "?id=" + orderid + "&userkey=" + userkey + "&type=7");
            // 设置支付完成异步通知接收地址
            request.SetNotifyUrl(AlipayConfig.mobile_notify_url);
            // 将业务model载入到request
            request.SetBizModel(model);
            AlipayTradeWapPayResponse response = null;
            string response_body = string.Empty;
            try
            {
                response = client.pageExecute(request, null, "post");
                if (response.IsError)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, response.Msg);
                    return;
                }
                response_body = response.Body;
                WebUtil.WriteJsonResult(context, response_body);
            }
            catch (Exception exp)
            {
                LogHelper.WriteError("alipayh5payorderready", "pageExecute", exp);
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, exp.Message);
            }
        }
        private void getencriptuid(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            string encript_uid = Utility.Tools.Encrypt(uid.ToString());
            WebUtil.WriteJsonResult(context, new { uid = encript_uid });
        }
        private void uploadeditimage(HttpContext context)
        {
            try
            {
                string filefullpath = string.Empty;
                HttpFileCollection uploadFiles = context.Request.Files;
                if (uploadFiles.Count > 0)
                {
                    HttpPostedFile postedFile = uploadFiles[0];
                    string fileOriName = postedFile.FileName;
                    if (fileOriName != "" && fileOriName != null)
                    {
                        string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                        string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                        string filepath = "/upload/Editor/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        filefullpath = WebUtil.GetContextPath() + filepath + fileName;
                    }
                }
                WebUtil.WriteJson(context, new { code = "success", data = new { url = filefullpath, width = "100%", heigth = "100%" } });
            }
            catch (Exception ex)
            {
                WebUtil.WriteJson(context, new { code = "failed" });
            }
        }
        private void doremoteopendoor(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "id");
            var data = Mall_DoorDevice.GetMall_DoorDeviceSDKKeyByID(ID);
            string error = string.Empty;
            bool result = Utility.LLingHelper.doRemoteOpenDoor(data.SDKKey, out error);
            if (!result)
            {
                data.SDKKeyExpireDate = DateTime.Now;
                data.Save();
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, error);
                return;
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getmydoordevices(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var list = Mall_DoorDevice.GetMall_DoorDeviceSDKKeyByUserID(uid, SelfUserID: user.UserID);
            if (list.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有绑定门禁");
                return;
            }
            var items = list.Select(p =>
            {
                var item = new { id = p.ID, deviceid = p.DeviceID, SDKKey = p.SDKKey, name = p.DeviceName };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void getmyremotedoordevices(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            //检查是否有权限使用
            bool IsExpire = false;
            bool IsBeforeThreeDayExpire = false;
            List<int> ExpireProjectIDList = new List<int>();
            Mall_DoorRemoteUserTimeDetail.GetMall_DoorRemoteUserTimeDetailListUserID(uid, out IsExpire, out IsBeforeThreeDayExpire, out ExpireProjectIDList, user.UserID);
            var phone_list = RoomPhoneRelation.GetRoomPhoneRelationsByPhone(user.LoginName, user.FinalUserID);
            Mall_UserProject.Insert_UserProjectList(phone_list, user);
            var list = Mall_DoorDevice.GetRemoteMall_DoorDeviceSDKKeyByUserID(uid, user.UserID);
            if (list.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有绑定门禁");
                return;
            }
            var door_device_project_list = Mall_DoorDeviceProject.GetMall_DoorDeviceProjectListByDeviceIDList(list.Select(p => p.ID).ToList());
            var my_list = list.Where(p => !p.IsUseAll).Select(p =>
            {
                var dic = p.ToJsonObject();
                dic["StatusDesc"] = p.StatusDesc;
                dic["canopen"] = false;
                var my_door_device_project_list = door_device_project_list.Where(q => q.DoorDeviceID == p.ID && !ExpireProjectIDList.Contains(q.ProjectID)).ToArray();
                if (!p.IsUseAll && my_door_device_project_list.Length > 0)
                {
                    dic["canopen"] = true;
                }
                return dic;
            }).ToList();
            var my_list2 = list.Where(p => p.IsUseAll).Select(p =>
            {
                var dic = p.ToJsonObject();
                dic["StatusDesc"] = p.StatusDesc;
                dic["canopen"] = false;
                if (!ExpireProjectIDList.Contains(p.ProjectID))
                {
                    dic["canopen"] = true;
                }
                if (ExpireProjectIDList.Contains(p.ProjectID) && my_list.Where(q => Convert.ToBoolean(q["canopen"])).Select(q => Convert.ToInt32(q["ProjectID"])).Contains(p.ProjectID))
                {
                    dic["canopen"] = true;
                }
                return dic;
            }).ToList();
            my_list.AddRange(my_list2);
            string ExpireMessage = string.Empty;
            if (IsExpire)
            {
                ExpireMessage = "物业已欠费，智能门禁已暂停使用，现在立即去缴费?";
            }
            if (IsBeforeThreeDayExpire)
            {
                ExpireMessage = "请及时缴纳物业费,到期后智能门禁将失效,现在立即去缴费?";
            }
            List<int> ProjectIDList = my_list.Select(p => Convert.ToInt32(p["ProjectID"])).Distinct().ToList();
            var project_list = Project.GetProjectListByIDs(ProjectIDList);
            List<Dictionary<string, object>> allitems = new List<Dictionary<string, object>>();
            foreach (var ProjectID in ProjectIDList)
            {
                var my_project = project_list.FirstOrDefault(p => p.ID == ProjectID);
                if (my_project != null)
                {
                    var dic = new Dictionary<string, object>();
                    dic["project"] = new { id = my_project.ID, name = my_project.Name };
                    dic["list"] = my_list.Where(p => Convert.ToInt32(p["ProjectID"]) == ProjectID).Select(p =>
                    {
                        bool canopen = Convert.ToBoolean(p["canopen"]);
                        string StatusDesc = p["StatusDesc"].ToString();
                        if (!canopen)
                        {
                            StatusDesc = "物业欠费";
                        }
                        var item = new { id = Convert.ToInt32(p["ID"]), deviceid = Convert.ToInt32(p["DeviceID"]), SDKKey = p["SDKKey"], name = p["DeviceName"], status = StatusDesc, isonline = Convert.ToInt32(p["Status"]) == 1, EnableQrCode = !Convert.ToBoolean(p["DisableQrCodeOpen"]), canopen = canopen };
                        return item;
                    });
                    allitems.Add(dic);
                }
            }
            WebUtil.WriteJsonResult(context, new { list = allitems, IsBeforeThreeDayExpire = IsBeforeThreeDayExpire, ExpireMessage = ExpireMessage, IsExpire = IsExpire });
        }
        private void checkuserpostthreadstatus(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var list = Mall_UserForbidden.GetMall_UserForbiddenListByUserID(uid);
            var data = list.FirstOrDefault(p => p.IsActive);
            if (data != null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "用户禁言");
                return;
            }
            WebUtil.WriteJsonResult(context, "用户没有禁言");
        }
        private void getappversion(HttpContext context)
        {
            string version = context.Request["version"];
            string versiontype = context.Request["versiontype"];
            int APPType = WebUtil.GetIntValue(context, "APPType");
            APPType = APPType > 0 ? APPType : 1;
            var data = Foresight.DataAccess.SiteVersion.GetAPPVersionByAPPVersionDesc(version, APPType: APPType, VersionType: versiontype);
            Foresight.DataAccess.SiteVersion last_data = null;
            int APPVersionCode = 0;
            if (data != null)
            {
                APPVersionCode = data.APPVersionCode;
            }
            last_data = Foresight.DataAccess.SiteVersion.GetLatestAPPVersion(APPVersionCode, APPType: APPType, VersionType: versiontype);
            if (last_data != null)
            {
                bool can_update = Utility.Tools.CheckVersionCode(version, last_data.APPVersionDesc);
                if (!can_update)
                {
                    WebUtil.WriteJsonResult(context, new { update = false });
                    return;
                }
                string time = last_data.PublishDate > DateTime.MinValue ? last_data.PublishDate.ToString("yyyy-MM-dd") : "";
                WebUtil.WriteJsonResult(context, new { update = true, closed = false, version = last_data.APPVersionDesc, versionDes = last_data.VersionDesc, time = time, source = WebUtil.GetContextPath() + last_data.FilePath, isforceupdate = last_data.IsForceUpdate });
                return;
            }
            WebUtil.WriteJsonResult(context, new { update = false });
        }
        private void postmallchatcontent(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "id");
            string Content = context.Request["content"];
            if (string.IsNullOrEmpty(Content))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "消息不能为空");
                return;
            }
            var list = Mall_ChatSensitive.GetMall_ChatSensitiveListByKeywords(Content);
            if (list.Length > 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您输入的消息含有敏感关键词");
                return;
            }
            var data = new Mall_ChatMessage();
            data.AddTime = DateTime.Now;
            data.ChatID = ID;
            data.ChatType = 1;
            data.ChatContent = Content;
            data.UserID = uid;
            data.AddUserName = user.LoginName;
            data.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getmallchatdetaillist(HttpContext context)
        {
            List<Dictionary<string, object>> items = new List<Dictionary<string, object>>();
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "id");
            int ProductID = WebUtil.GetIntValue(context, "productid");
            Mall_Business business = null;
            Mall_ChatTitle chat_title = null;
            if (ID > 0)
            {
                chat_title = Mall_ChatTitle.GetMall_ChatTitle(ID);
                if (chat_title == null)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "ID不合法");
                    return;
                }
                business = Mall_Business.GetMall_Business(chat_title.ToBusinessID);
            }
            else if (ProductID > 0)
            {
                business = Mall_Business.GetMall_BusinessByProductID(ProductID);
                chat_title = Mall_ChatTitle.GetMall_ChatTitleByAPPUserID(uid, ProductID);
                if (chat_title == null)
                {
                    chat_title = new Mall_ChatTitle();
                    chat_title.FromUserID = uid;
                    chat_title.ToUserID = 0;
                    chat_title.ToBusinessID = business == null ? 0 : business.ID;
                    chat_title.AddTime = DateTime.Now;
                    chat_title.AddUserName = user.LoginName;
                    chat_title.ProductID = ProductID;
                    chat_title.Save();
                    WebUtil.WriteJsonResult(context, new { list = items, id = chat_title.ID });
                    return;
                }
            }
            var list = Mall_ChatMessage.GetMall_ChatMessageListByBusinesChatID(chat_title.ID, onlyTotay: true);
            string seller_headimage = "../image/error-img.png";
            string buyer_headimage = "../image/error-img.png";
            string seller_nickname = "匿名";
            if (business != null)
            {
                seller_headimage = string.IsNullOrEmpty(business.CoverImage) ? seller_headimage : WebUtil.GetContextPath() + business.CoverImage;
                seller_nickname = business.BusinessName;
            }
            buyer_headimage = string.IsNullOrEmpty(user.HeadImg) ? buyer_headimage : WebUtil.GetContextPath() + user.HeadImg;
            var orderby_list = list.GroupBy(p => p.AddTime.ToString("yyyy-MM-dd HH:mm")).Select(p => (new { name = p.Key, count = p.Count() })).ToArray();
            foreach (var item in orderby_list)
            {
                var my_list = list.Where(p => p.AddTime.ToString("yyyy-MM-dd HH:mm").Equals(item.name)).ToArray();
                var dic = new Dictionary<string, object>();
                dic["addtime"] = item.name;
                dic["list"] = my_list.Select(p =>
                {
                    string css = p.ChatType == 1 ? "aui-chat-right" : "aui-chat-left";
                    string headimage = p.ChatType == 1 ? buyer_headimage : seller_headimage;
                    string nickname = p.ChatType == 1 ? user.NickName : seller_nickname;
                    nickname = string.IsNullOrEmpty(nickname) ? "匿名" : nickname;
                    var my_item = new { id = p.ID, headimage = headimage, css = css, nickname = nickname, msgcontent = p.ChatContent };
                    return my_item;
                });
                items.Add(dic);
            }
            var unread_list = list.Where(p => p.CustomerReadTime == DateTime.MinValue).ToArray();
            if (unread_list.Length > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        foreach (var item in unread_list)
                        {
                            item.CustomerReadTime = DateTime.Now;
                            item.Save(helper);
                        }
                        helper.Commit();
                    }
                    catch (Exception)
                    {
                        helper.Rollback();
                    }
                }
            }
            WebUtil.WriteJsonResult(context, new { list = items, id = chat_title.ID });
        }
        private void getllingsdkkey(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = 0;
            try
            {
                uid = GetUID(context, out user);
            }
            catch (Exception)
            {
            }
            if (uid <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "未登录");
                return;
            }
            //检查是否有权限使用
            bool IsExpire = false;
            bool IsBeforeThreeDayExpire = false;
            List<int> ExpireProjectIDList = new List<int>();
            Mall_DoorRemoteUserTimeDetail.GetMall_DoorRemoteUserTimeDetailListUserID(uid, out IsExpire, out IsBeforeThreeDayExpire, out ExpireProjectIDList, user.UserID);
            var list = new Mall_DoorDevice[] { };
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID > 0)
            {
                var data = Mall_DoorDevice.GetMall_DoorDeviceSDKKeyByID(ID);
                if (data != null)
                {
                    list = new Mall_DoorDevice[] { data };
                }
            }
            else
            {
                //list = Mall_DoorDevice.GetMall_DoorDeviceSDKKeyByUserID(uid, user.UserID);
                list = Mall_DoorDevice.GetRemoteMall_DoorDeviceSDKKeyByUserID(uid, user.UserID);
            }
            if (list.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您当前认证房间未绑定门禁");
                return;
            }

            var door_device_project_list = Mall_DoorDeviceProject.GetMall_DoorDeviceProjectListByDeviceIDList(list.Select(p => p.ID).ToList());
            var my_list = list.Where(p =>
            {
                var my_door_device_project_list = door_device_project_list.Where(q => q.DoorDeviceID == p.ID && !ExpireProjectIDList.Contains(q.ProjectID)).ToArray();
                if (!p.IsUseAll && my_door_device_project_list.Length > 0)
                {
                    return true;
                }
                return false;
            }).ToList();
            var my_list2 = list.Where(p =>
            {
                if (p.IsUseAll)
                {
                    if (!ExpireProjectIDList.Contains(p.ProjectID))
                    {
                        return true;
                    }
                    if (ExpireProjectIDList.Contains(p.ProjectID) && my_list.Select(q => q.ProjectID).Contains(p.ProjectID))
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }).ToList();

            my_list.AddRange(my_list2);
            string ExpireMessage = string.Empty;
            if (IsExpire)
            {
                ExpireMessage = "物业已欠费,智能门禁已暂停使用,现在立即去缴费?";
            }
            if (IsBeforeThreeDayExpire)
            {
                ExpireMessage = "请及时缴纳物业费,到期后智能门禁将失效,现在立即去缴费?";
            }
            var items = my_list.Select(p =>
            {
                var item = new { id = p.ID, key = p.SDKKey };
                return item;
            });
            string account = Utility.LLingHttpConfig.HOST_ACCOUNT;
            WebUtil.WriteJsonResult(context, new { key = string.Join(",", my_list.Select(p => p.SDKKey)), name = "当前开门: " + string.Join(",", my_list.Select(p => p.DeviceName)), account = account, items = items, IsBeforeThreeDayExpire = IsBeforeThreeDayExpire, ExpireMessage = ExpireMessage, IsExpire = IsExpire });
        }
        private void createhouseserviceorder(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int id = WebUtil.GetIntValue(context, "id");
            int variantid = WebUtil.GetIntValue(context, "variantid");
            int quantity = WebUtil.GetIntValue(context, "quantity");
            quantity = quantity > 0 ? quantity : 1;
            var data = Foresight.DataAccess.Wechat_HouseService.GetWechat_HouseService(id);
            int addressid = WebUtil.GetIntValue(context, "addressid");
            Foresight.DataAccess.Mall_Address mall_address = null;
            if (addressid > 0)
            {
                mall_address = Foresight.DataAccess.Mall_Address.GetMall_Address(addressid);
                if (mall_address == null)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请选择收货地址");
                }
            }
            var type_list = Foresight.DataAccess.Wechat_HouseServiceType.GetWechat_HouseServiceTypeListByServiceID(id);
            Wechat_HouseServiceType data_type = null;
            if (variantid > 0)
            {
                data_type = type_list.FirstOrDefault(p => p.ID == variantid);
            }
            if (data_type == null)
            {
                type_list.OrderBy(p => p.UnitPrice).FirstOrDefault();
            }
            var data_category = Wechat_HouseServiceCategory.GetWechat_HouseServiceCategory(data.CategoryID);
            decimal price = 0;
            string VariantTitle = string.Empty;
            string VariantName = string.Empty;
            if (data_type != null)
            {
                price = data_type.UnitPrice;
                VariantTitle = data_category != null ? data_category.CategoryName : "生活服务";
                VariantName = data_type.TypeName;
            }
            Foresight.DataAccess.Mall_Order order = new Mall_Order();
            List<Mall_OrderItem> orderitems = new List<Mall_OrderItem>();
            order.BusinessID = 0;
            order.AddTime = DateTime.Now;
            order.AddUser = user.LoginName;
            order.OrderNumber = Mall_Order.GetLastestOrderNumber();
            order.OrderType = 1;
            order.TotalCost = price * quantity;
            order.TotalSalePoint = 0;
            order.TotalVIPSalePoint = 0;
            order.TotalSaleStaffPoint = 0;
            order.OriginalTotalCost = order.TotalCost;
            order.OrderStatus = 1;
            order.UserID = uid;
            order.UserName = user.LoginName;
            order.UserNote = context.Request["user_note"];
            order.ProductTypeID = 5;
            order.CouponID = WebUtil.GetIntValue(context, "couponid");
            order.CouponUserID = WebUtil.GetIntValue(context, "couponuserid");
            order.CouponAmount = WebUtil.GetDecimalValue(context, "couponprice");
            if (mall_address != null)
            {
                order.AddressID = mall_address.ID;
                order.AddressUserName = mall_address.AddressUserName;
                order.AddressPhoneNumber = mall_address.AddressPhoneNo;
                order.AddressProvince = mall_address.AddressProvice;
                order.AddressCity = mall_address.AddressCity;
                order.AddressDistrict = mall_address.AddressDistrict;
                order.AddressDetailInfo = mall_address.AddressDetailInfo;
                order.AddressProjectID = mall_address.ProjectID;
                order.AddressRoomID = mall_address.RoomID;
            }
            var order_item = new Mall_OrderItem();
            order_item.IsDiscountPrice = false;
            order_item.AddTime = order.AddTime;
            order_item.AddMan = order.AddUser;
            order_item.ProductID = data.ID;
            order_item.ProductName = data.Title;
            order_item.VariantID = variantid;
            order_item.VariantTitle = VariantTitle;
            order_item.VariantName = VariantName;
            order_item.Price = price;
            order_item.Quantity = quantity;
            order_item.TotalPrice = price * quantity;
            order_item.SalePoint = 0;
            order_item.TotalSalePoint = 0;
            order_item.VIPTotalSalePoint = 0;
            order_item.VIPSalePoint = 0;
            order_item.StaffPoint = 0;
            order_item.TotalStaffPoint = 0;
            order_item.BusinessID = 0;
            order_item.ProductTypeID = 5;
            order_item.BusinessName = VariantTitle;
            order_item.ProductBuyType = 16;
            orderitems.Add(order_item);
            int orderid = 0;
            Mall_CouponUser coupon_user = null;
            if (order.CouponUserID > 0)
            {
                coupon_user = Mall_CouponUser.GetMall_CouponUser(order.CouponUserID);
            }

            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    order.Save(helper);
                    foreach (var item in orderitems)
                    {
                        item.OrderID = order.ID;
                        item.Save(helper);
                    }
                    orderid = order.ID;
                    if (coupon_user != null)
                    {
                        coupon_user.IsUsed = true;
                        coupon_user.UseTime = DateTime.Now;
                        coupon_user.UseType = 4;
                        coupon_user.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "createhouseserviceorder", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "内部异常");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, new { id = orderid });
            return;
        }
        private void gethouseserviceorderlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int id = WebUtil.GetIntValue(context, "id");
            int variantid = WebUtil.GetIntValue(context, "variantid");
            int quantity = WebUtil.GetIntValue(context, "quantity");
            quantity = quantity > 0 ? quantity : 1;
            var data = Foresight.DataAccess.Wechat_HouseService.GetWechat_HouseService(id);
            var type_list = Foresight.DataAccess.Wechat_HouseServiceType.GetWechat_HouseServiceTypeListByServiceID(id);
            Wechat_HouseServiceType data_type = null;
            if (variantid > 0)
            {
                data_type = type_list.FirstOrDefault(p => p.ID == variantid);
            }
            if (data_type == null)
            {
                type_list.OrderBy(p => p.UnitPrice).FirstOrDefault();
            }
            var data_category = Wechat_HouseServiceCategory.GetWechat_HouseServiceCategory(data.CategoryID);
            decimal price = 0;
            string desc = string.Empty;
            if (data_type != null)
            {
                price = data_type.UnitPrice;
                desc = data_type.TypeName;
            }
            List<Dictionary<string, object>> productlist = new List<Dictionary<string, object>>();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["productid"] = data.ID;
            dic["variantid"] = 0;
            dic["imageurl"] = !string.IsNullOrEmpty(data.IconLink) ? WebUtil.GetContextPath() + data.IconLink : "../image/error-img.png";
            dic["title"] = data.Title;
            dic["desc"] = desc;
            dic["pricedesc"] = "￥" + price.ToString("0.00");
            dic["price"] = price;
            dic["salepoint"] = 0;
            dic["quantity"] = "x" + quantity;
            productlist.Add(dic);
            if (productlist.Count == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有相关商品");
                return;
            }
            string business_name = data_category != null ? data_category.CategoryName : "生活服务";
            var business = new { name = business_name, id = 0, businessimage = string.Empty };
            decimal totalprice = price * quantity;
            string totalpricedesc = "￥" + totalprice.ToString("0.00");
            var productsummary = new { totaldesc = "共" + productlist.Count.ToString() + "项", totalprice = totalprice, isservice = true, totalpricedesc = totalpricedesc, totalsalepoint = 0 };
            var couponlist = new List<Dictionary<string, object>>();
            var allcouponlist = Mall_CouponUserDetail.GetOrderMall_CouponUserDicList(totalprice, 0, uid, out couponlist, ServiceIDList: new int[] { data.ID });
            WebUtil.WriteJsonResult(context, new { productlist = productlist, productsummary = productsummary, business = business, ordersummary = productsummary, couponlist = couponlist, allcouponlist = allcouponlist });
        }
        private void gettaglistbycategoryid(HttpContext context)
        {
            int categoryid = WebUtil.GetIntValue(context, "categoryid");
            var list = Foresight.DataAccess.Mall_Tag.GetMall_TagListByCategoryID(categoryid);
            var items = list.Select(p =>
            {
                var item = new { id = p.ID, title = p.TagName, is_active = false };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { sub_menus = items });
        }
        private void savemyfamilyinfo(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            string phonenumber = context.Request["phonenumber"];
            string verifycode = context.Request["verifycode"];
            var wechatVerifyCode = Wechat_VerifyCode.GetWechat_VerifyCodeByUserOpenId(string.Empty, phonenumber, DateTime.Now);
            if (wechatVerifyCode == null || !wechatVerifyCode.VerifyCode.Equals(verifycode))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "验证码不正确");
                return;
            }
            //FamilyUserID
            int id = WebUtil.GetIntValue(context, "id");
            string username = context.Request["username"];
            string password = context.Request["password"];
            string sex = context.Request["sex"];
            string detail = context.Request["detail"];
            string moredetail = context.Request["moredetail"];
            bool isdefinerelation = false;
            if (context.Request["isdefinerelation"] != null)
            {
                bool.TryParse(context.Request["isdefinerelation"], out isdefinerelation);
            }
            Foresight.DataAccess.User main_user = null;
            Mall_UserFamily data = null;
            if (id > 0)
            {
                data = Mall_UserFamily.GetMall_UserFamily(id);
                main_user = Foresight.DataAccess.User.GetAPPUserByFamilyUserID(id);
            }
            var exist_user_list = Foresight.DataAccess.User.GetAPPUserListByLoginName(phonenumber);
            Foresight.DataAccess.User exist_user = null;
            if (exist_user_list.Length > 0)
            {
                exist_user = exist_user_list.FirstOrDefault(p => p.Type.Equals(UserTypeDefine.APPUser.ToString()));
                if (exist_user != null)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码为员工账号");
                    return;
                }
                exist_user = exist_user_list.FirstOrDefault(p => p.Type.Equals(UserTypeDefine.APPCustomer.ToString()));
                if (exist_user != null)
                {
                    var child_user_list = Foresight.DataAccess.User.GetAPPUserListByParentUserID(exist_user.UserID);
                    if (child_user_list.Length > 0)
                    {
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码已有家庭成员");
                        return;
                    }
                }
                exist_user = exist_user_list.FirstOrDefault(p => p.Type.Equals(UserTypeDefine.APPCustomerFamily.ToString()));
                if (exist_user != null && main_user == null && exist_user.FinalParentUserID != uid)
                {
                    var my_parent_user = Foresight.DataAccess.User.GetUser(exist_user.FinalParentUserID);
                    if (my_parent_user != null)
                    {
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码为已经是家庭成员");
                        return;
                    }
                }
                if (main_user == null)
                {
                    main_user = exist_user_list.FirstOrDefault(p => p.Type.Equals(UserTypeDefine.APPCustomerFamily.ToString()));
                }
                if (main_user == null)
                {
                    main_user = exist_user_list.FirstOrDefault(p => p.Type.Equals(UserTypeDefine.APPCustomer.ToString()));
                }
            }
            if (main_user != null && main_user.FinalParentUserID != uid)
            {
                var my_parent_user = Foresight.DataAccess.User.GetUser(main_user.FinalParentUserID);
                if (my_parent_user != null)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码为已经是家庭成员");
                    return;
                }
            }
            if (data == null)
            {
                data = new Mall_UserFamily();
                data.AddTime = DateTime.Now;
                data.AddUserMan = user.LoginName;
                data.UserID = uid;
            }
            data.LoginName = phonenumber;
            if (!string.IsNullOrEmpty(password))
            {
                data.LoginPwd = User.EncryptPassword(password);
            }
            data.RealName = username;
            data.PhoneNumber = phonenumber;
            data.Sex = sex;
            data.Description = moredetail;
            data.RelationDesc = detail;
            data.IsDefineRelation = isdefinerelation;
            if (main_user == null)
            {
                main_user = new Foresight.DataAccess.User();
                main_user.CreateTime = DateTime.Now;
                main_user.IsLocked = false;
            }
            main_user.ParentUserID = uid;
            main_user.LoginName = phonenumber;
            if (!string.IsNullOrEmpty(password))
            {
                main_user.Password = User.EncryptPassword(password);
            }
            main_user.PhoneNumber = phonenumber;
            main_user.NickName = username;
            main_user.RealName = username;
            main_user.Gender = sex;
            main_user.Type = UserTypeDefine.APPCustomerFamily.ToString();
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    main_user.FamilyUserID = data.ID;
                    main_user.Save(helper);

                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "savemyfamilyinfo", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getmyfamilydetail(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int id = WebUtil.GetIntValue(context, "id");
            var data = Mall_UserFamily.GetMall_UserFamily(id);
            var item = new { id = data.ID, username = data.RealName, phonenumber = data.PhoneNumber, detail = data.RelationDesc, sex = data.Sex, password = "", repassword = "", codeissent = false, codesentcomplete = false, countdown = "", verifycode = "", isdefinerelation = data.IsDefineRelation, moredetail = data.Description };
            WebUtil.WriteJsonResult(context, new { form = item });
        }
        private void removemyfamily(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int id = WebUtil.GetIntValue(context, "id");
            Mall_UserFamily.DeleteMall_UserFamily(id);
            var main_user = Foresight.DataAccess.User.GetAPPUserByFamilyUserID(id);
            if (main_user != null)
            {
                main_user.FamilyUserID = 0;
                main_user.ParentUserID = 0;
                main_user.Type = UserTypeDefine.APPCustomer.ToString();
                main_user.Save();
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getmyfamilylist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            if (user == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.AuthenticationFail, "user not exists");
                return;
            }
            var list = Foresight.DataAccess.Mall_UserFamily.GetMall_UserFamilyListByUserID(uid);
            var items = list.Select(p =>
            {
                string detail = p.RelationDesc;
                if (p.IsDefineRelation)
                {
                    detail = string.IsNullOrEmpty(p.Description) ? detail : p.Description;
                }
                var item = new { id = p.ID, name = p.RealName, phone = p.PhoneNumber, detail = detail, sex = p.Sex };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void dopaypointorder(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int orderid = WebUtil.GetIntValue(context, "orderid");
            string ids = context.Request["orderidlist"];
            List<int> OrderIDList = new List<int>();
            if (!string.IsNullOrEmpty(ids))
            {
                OrderIDList = JsonConvert.DeserializeObject<List<int>>(ids);
            }
            if (!OrderIDList.Contains(orderid) && orderid > 0)
            {
                OrderIDList.Add(orderid);
            }
            var order_list = Mall_Order.GetMall_OrderListByIDList(OrderIDList);
            decimal point_balance = Mall_UserPoint.GetMall_UserPointBalance(uid);
            int TotalOrderPointCost = order_list.Sum(p => p.TotalOrderPointCost);
            if (point_balance < TotalOrderPointCost)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前积分不足");
                return;
            }
            bool can_socket_notify = false;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var order in order_list)
                    {
                        order.PayTime = DateTime.Now;
                        order.PayUserName = user.LoginName;
                        order.PaymentMethod = Utility.EnumModel.Mall_OrderPaymentMethodDefine.point.ToString();
                        order.OrderStatus = 5;
                        order.IsReadNewOrder = false;
                        can_socket_notify = true;
                        order.Save(helper);
                        Mall_UserPoint.Insert_Mall_UserPoint(order.UserID, 2, 0, "积分购买消费", "OrderID:" + order.ID, 1, user.LoginName, 1, order.TradeNo, order.ID, helper, PointValue: -order.TotalOrderPointCost, RelatedID: order.ID);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "dopaypointorder", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器内部异常");
                    return;
                }
            }
            if (can_socket_notify)
            {
                APPCode.SocketNotify.PushSocketNotifyAlert(Utility.EnumModel.SocketNotifyDefine.notifyorderpaied);
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void dopaystaffpointorder(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int orderid = WebUtil.GetIntValue(context, "orderid");
            string ids = context.Request["orderidlist"];
            List<int> OrderIDList = new List<int>();
            if (!string.IsNullOrEmpty(ids))
            {
                OrderIDList = JsonConvert.DeserializeObject<List<int>>(ids);
            }
            if (!OrderIDList.Contains(orderid) && orderid > 0)
            {
                OrderIDList.Add(orderid);
            }
            var order_list = Mall_Order.GetMall_OrderListByIDList(OrderIDList);
            decimal point_balance = Mall_UserJiXiaoPoint.GetMall_UserJiXiaoPointBalance(uid);
            int TotalSaleStaffPoint = order_list.Sum(p => { return (p.TotalSaleStaffPoint > 0 ? p.TotalSaleStaffPoint : 0); });
            if (point_balance < TotalSaleStaffPoint)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前岗位积分不足");
                return;
            }
            bool can_socket_notify = false;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var order in order_list)
                    {
                        order.PayTime = DateTime.Now;
                        order.PayUserName = user.LoginName;
                        order.PaymentMethod = Utility.EnumModel.Mall_OrderPaymentMethodDefine.staffpoint.ToString();
                        order.OrderStatus = 5;
                        order.IsReadNewOrder = false;
                        order.Save(helper);
                        can_socket_notify = true;
                        Mall_UserJiXiaoPoint.Insert_Mall_UserJiXiaoPoint(uid, 2, order.TotalSaleStaffPoint, "购买消费", "order ID:" + order.ID, 1, user.LoginName, 1, helper, PointValue: -order.TotalSaleStaffPoint, RelatedID: order.ID);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "dopaystaffpointorder", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器内部异常");
                    return;
                }
            }
            if (can_socket_notify)
            {
                APPCode.SocketNotify.PushSocketNotifyAlert(Utility.EnumModel.SocketNotifyDefine.notifyorderpaied);
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void checkproductinventory(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int productid = WebUtil.GetIntValue(context, "productid");
            int variantid = WebUtil.GetIntValue(context, "variantid");
            int quantity = WebUtil.GetIntValue(context, "quantity");
            Mall_Product_Variant product_variant = null;
            if (variantid > 0)
            {
                product_variant = Mall_Product_Variant.GetMall_Product_Variant(variantid);
            }
            int inventory = 0;
            if (product_variant != null)
            {
                inventory = product_variant.Inventory > 0 ? product_variant.Inventory : 0;
            }
            else
            {
                var product = Mall_ProductDetail.GetMall_ProductDetailByID(productid);
                if (product != null)
                {
                    inventory = product.Inventory > 0 ? product.Inventory : 0;
                }
            }
            if (inventory < quantity)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该商品库存不足");
                return;
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void buyitemcheckpoint(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int productid = WebUtil.GetIntValue(context, "productid");
            int variantid = WebUtil.GetIntValue(context, "variantid");
            decimal price = 0;
            var product = Mall_Product.GetMall_Product(productid);
            var variant = Mall_Product_Variant.GetMall_Product_Variant(variantid);
            price = variant != null ? variant.VariantPoint : 0;
            var balance = Mall_UserPoint.GetMall_UserPointBalance(uid);
            if (balance < price)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前积分不足");
                return;
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getstaffbalancelist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var list = Mall_UserJiXiaoPoint.GetMall_UserJiXiaoPointList(uid);
            var items = list.Select(p =>
            {
                string balance = p.PointValue > 0 ? "+" + p.PointValue.ToString("0") : p.PointValue.ToString("0");
                var item = new { id = p.ID, title = p.Title, time = p.AddTime.ToString("yyyy-MM-dd HH:mm:ss"), balance = balance, type = p.PointType };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void getpointbalancelist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var list = Mall_UserPoint.GetMall_UserPointList(uid);
            var items = list.Select(p =>
            {
                string balance = p.PointValue > 0 ? "+" + p.PointValue.ToString("0") : p.PointValue.ToString("0");
                var item = new { id = p.ID, title = p.Title, time = p.AddTime.ToString("yyyy-MM-dd HH:mm:ss"), balance = balance, type = p.PointType };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void getstaffpointbalance(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            decimal amount_balance = Mall_UserJiXiaoPoint.GetMall_UserJiXiaoPointBalance(uid);
            bool isselfuser = user.Type.Equals(UserTypeDefine.APPUser.ToString()) || user.IsAllowAPPUserLogin;
            WebUtil.WriteJsonResult(context, new { amount_balance = amount_balance.ToString("0"), isselfuser = isselfuser });
        }
        private void getuserpointbalance(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            decimal amount_balance = Mall_UserPoint.GetMall_UserPointBalance(uid);
            bool isselfuser = user.Type.Equals(UserTypeDefine.APPUser.ToString());
            WebUtil.WriteJsonResult(context, new { amount_balance = amount_balance.ToString("0"), isselfuser = isselfuser });
        }
        private void savenewpaypassword(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            string password = context.Request["password"];
            user.PayPassword = User.EncryptPassword(password);
            user.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void savenewpassword(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            string password = context.Request["password"];
            if (!User.EncryptPassword(password).Equals(user.Password))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "原密码不正确");
                return;
            }
            string newpassword = context.Request["newpassword"];
            user.Password = User.EncryptPassword(newpassword);
            user.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void completeretrievepaypwd(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            string password = context.Request["password"];
            string verifycode = context.Request["verifycode"];
            var wechatVerifyCode = Wechat_VerifyCode.GetWechat_VerifyCodeByUserOpenId(string.Empty, user.LoginName, DateTime.Now);
            if (wechatVerifyCode == null || !wechatVerifyCode.VerifyCode.Equals(verifycode))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "验证码不正确");
                return;
            }
            user.PayPassword = User.EncryptPassword(password);
            user.Save();
            wechatVerifyCode.IsUsed = true;
            wechatVerifyCode.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void retrievelpaypwdcheckphone(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            string content = "验证码{0}，请在15分钟内按页面提示输入验证码，切勿将验证码泄露于他人。";
            string VerifyCode = Utility.Tools.SendVerifyCode(user.LoginName, content);
            Foresight.DataAccess.Wechat_VerifyCode.SaveWechatVerifyCode(user.LoginName, VerifyCode);
            WebUtil.WriteJsonResult(context, "Success");
            return;
        }
        private void verifypaypassword(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            string password = context.Request["password"];
            if (!User.EncryptPassword(password).Equals(user.PayPassword))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "原支付密码输入不正确");
                return;
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void payordercheckpwd(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            string password = context.Request["password"];
            if (!User.EncryptPassword(password).Equals(user.PayPassword))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "支付密码不正确");
                return;
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void payorderbybalance(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int orderid = WebUtil.GetIntValue(context, "orderid");
            string ids = context.Request["orderidlist"];
            List<int> OrderIDList = new List<int>();
            if (!string.IsNullOrEmpty(ids))
            {
                OrderIDList = JsonConvert.DeserializeObject<List<int>>(ids);
            }
            if (!OrderIDList.Contains(orderid) && orderid > 0)
            {
                OrderIDList.Add(orderid);
            }
            var order_list = Mall_Order.GetMall_OrderListByIDList(OrderIDList);
            decimal TotalOrderPointCost = order_list.Sum(p => p.TotalOrderPointCost);
            decimal TotalOrderCost = order_list.Sum(p => p.TotalOrderCost);
            bool requirepoint = TotalOrderPointCost > 0;
            bool requireamount = TotalOrderCost > 0;
            if (!requirepoint && !requireamount)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法申请");
                return;
            }
            string PaymentMethod = string.Empty;
            string Remark = string.Empty;
            if (requirepoint && requireamount)
            {
                PaymentMethod = Utility.EnumModel.Mall_OrderPaymentMethodDefine.balance_point.ToString();
                Remark = "APP支付账户余额+积分支付申请";
            }
            else if (requireamount)
            {
                PaymentMethod = Utility.EnumModel.Mall_OrderPaymentMethodDefine.balance.ToString();
                Remark = "APP支付账户余额支付申请";
            }
            else
            {
                PaymentMethod = Utility.EnumModel.Mall_OrderPaymentMethodDefine.point.ToString();
                Remark = "APP支付积分支付申请";
            }
            if (order_list.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单不存在");
                return;
            }
            if (requirepoint)
            {
                decimal balance_point = Mall_UserPoint.GetMall_UserPointBalance(uid);
                if (balance_point < TotalOrderPointCost)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "积分余额不足，付款失败");
                    return;
                }
            }
            if (requireamount)
            {
                decimal balance_amount = Mall_UserBalance.GetMall_UserBalanceBalance(uid);
                if (balance_amount < TotalOrderCost)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "账户余额不足，付款失败");
                    return;
                }
            }
            bool can_socket_notify = false;
            foreach (var order in order_list)
            {
                if (order.IsClosed)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单已关闭");
                    return;
                }
                if (order.OrderStatus != 1)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单已支付");
                    return;
                }
                string title = "购买商品";
                if (order.ProductTypeID == 10)
                {
                    order.OrderStatus = 3;
                    order.CompleteTime = DateTime.Now;
                    title = "物业缴费";
                }
                else if (order.ProductTypeID == 5)
                {
                    title = "购买服务";
                    order.OrderStatus = 5;
                    order.IsReadNewOrder = false;
                    can_socket_notify = true;
                }
                else
                {
                    order.OrderStatus = 5;
                    order.IsReadNewOrder = false;
                    can_socket_notify = true;
                }
                order.PayTime = DateTime.Now;
                order.PaymentMethod = Utility.EnumModel.Mall_OrderPaymentMethodDefine.balance.ToString();
                var payment = Foresight.DataAccess.Payment.GetPaymentByTradeNo(order.TradeNo);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        Payment.CompletePayment(helper, TradeNo: order.TradeNo, payment: payment, order: order);
                        Mall_UserBalance.Insert_Mall_UserBalance(uid, 2, -order.TotalOrderCost, title, "OrderID:" + order.ID, 1, user.LoginName, 1, order.TradeNo, RelatedID: order.ID, helper: helper, PaymentMethod: order.PaymentMethod);
                        if (order.TotalOrderPointCost > 0)
                        {
                            Mall_UserPoint.Insert_Mall_UserPoint(uid, 2, 0, title, "OrderID:" + order.ID, 1, "System", 1, order.TradeNo, order.ID, helper, RelatedID: order.ID, PointValue: -order.TotalOrderPointCost, AmountRuleID: 0);
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModuel, "payorderbybalance", ex);
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                        return;
                    }
                }
                Mall_UserBalance.GetEarnThroughBuy(order);
                var history_count = Foresight.DataAccess.RoomFeeHistory.GetRoomFeeHistoryCountByTradeNo(order.TradeNo, OrderID: order.ID);
                if (history_count > 0)
                {
                    continue;
                }
                var roomfee_count = RoomFee.GetRoomFeeCountByTradeNo(order.TradeNo, OrderID: order.ID);
                if (roomfee_count == 0)
                {
                    continue;
                }
                Web.APPCode.PaymentHelper.SaveRoomFee(order.TradeNo, "APP账户余额支付", "余额支付");
            }
            if (can_socket_notify)
            {
                APPCode.SocketNotify.PushSocketNotifyAlert(Utility.EnumModel.SocketNotifyDefine.notifyorderpaied);
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void balanceorderready(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int paymentid = WebUtil.GetIntValue(context, "paymentid");
            int orderid = WebUtil.GetIntValue(context, "orderid");
            string ids = context.Request["orderidlist"];
            List<int> OrderIDList = new List<int>();
            if (!string.IsNullOrEmpty(ids))
            {
                OrderIDList = JsonConvert.DeserializeObject<List<int>>(ids);
            }
            if (!OrderIDList.Contains(orderid) && orderid > 0)
            {
                OrderIDList.Add(orderid);
            }
            var order_list = Mall_Order.GetMall_OrderListByIDList(OrderIDList);
            if (order_list.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单不存在");
                return;
            }
            string paymentmethod = context.Request["payment"];
            paymentmethod = string.IsNullOrEmpty(paymentmethod) ? string.Empty : paymentmethod;
            decimal TotalOrderPointCost = order_list.Sum(p => p.TotalOrderPointCost);
            decimal TotalOrderCost = order_list.Sum(p => p.TotalOrderCost);
            decimal TotalStaffPoint = order_list.Sum(p => { return (p.TotalSaleStaffPoint > 0 ? p.TotalSaleStaffPoint : 0); });
            bool requirepoint = TotalOrderPointCost > 0;
            bool requireamount = TotalOrderCost > 0 && paymentmethod.Equals("balance");
            bool requirestaffpoint = TotalStaffPoint > 0 && paymentmethod.Equals("staffpoint");
            if (!requirepoint && !requireamount && !requirestaffpoint)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法申请");
                return;
            }
            string PaymentMethod = string.Empty;
            string Remark = string.Empty;
            if (requirepoint && requireamount)
            {
                PaymentMethod = Utility.EnumModel.Mall_OrderPaymentMethodDefine.balance_point.ToString();
                Remark = "APP支付账户余额+积分支付申请";
            }
            else if (requireamount)
            {
                PaymentMethod = Utility.EnumModel.Mall_OrderPaymentMethodDefine.balance.ToString();
                Remark = "APP支付账户余额支付申请";
            }
            else if (requirestaffpoint)
            {
                PaymentMethod = Utility.EnumModel.Mall_OrderPaymentMethodDefine.staffpoint.ToString();
                Remark = "岗位积分支付申请";
            }
            else
            {
                PaymentMethod = Utility.EnumModel.Mall_OrderPaymentMethodDefine.point.ToString();
                Remark = "APP支付积分支付申请";
            }
            if (requireamount)
            {
                decimal balance = Mall_UserBalance.GetMall_UserBalanceBalance(uid);
                if (balance <= TotalOrderCost)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "账户余额不足，请选择其他付款方式");
                    return;
                }
            }
            if (requirepoint)
            {
                decimal balance_point = Mall_UserPoint.GetMall_UserPointBalance(uid);
                if (balance_point <= TotalOrderPointCost)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "积分余额不足，付款失败");
                    return;
                }
            }
            if (requirestaffpoint)
            {
                decimal balance_point = Mall_UserJiXiaoPoint.GetMall_UserJiXiaoPointBalance(uid);
                if (balance_point <= TotalStaffPoint)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "岗位积分余额不足，付款失败");
                    return;
                }
            }
            string TradeNo = WxPayApi.GenerateOutTradeNo();
            Foresight.DataAccess.Payment payment = null;
            if (paymentid > 0)
            {
                payment = Payment.GetPayment(paymentid);
                TradeNo = payment != null ? payment.TradeNo : TradeNo;
            }
            var all_request_list = new List<Payment_Request>();
            var all_fee_list = new List<RoomFee>();
            var all_order_list = new List<Mall_Order>();
            bool IsWuYe = false;
            foreach (var order in order_list)
            {
                if (order.IsClosed)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单已关闭");
                    return;
                }
                if (order.OrderStatus != 1)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单已支付");
                    return;
                }
                if (order.ProductTypeID == 10)
                {
                    var fee_list = Foresight.DataAccess.RoomFee.GetRoomFeeListByTradeNo(order.TradeNo, OrderID: order.ID);
                    foreach (var item in fee_list)
                    {
                        item.TradeNo = TradeNo;
                        all_fee_list.Add(item);
                    }
                    var my_request_list = Payment_Request.GetPayment_RequestByTradeNo(order.TradeNo, OrderID: order.ID).ToList();
                    foreach (var item in my_request_list)
                    {
                        all_request_list.Add(item);
                    }
                    IsWuYe = true;
                }
                order.TradeNo = TradeNo;
                order.PaymentMethod = PaymentMethod;
                all_order_list.Add(order);
            }
            payment = Payment.Insert_Payment(TotalOrderCost * 100, Utility.EnumModel.PaymentTypeDefine.app_balance_pay.ToString(), TradeNo, 1, user.LoginName, Remark, payment: payment, request_list: all_request_list, fee_list: all_fee_list, order_list: all_order_list, IsWuYe: IsWuYe);
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getmallamountsummary(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int status = WebUtil.GetIntValue(context, "status");
            var list = Mall_UserBalance.GetMall_UserBalanceList(uid);
            //累计充值
            string totalinamount = "￥" + list.Where(p => p.CategoryType == 2 || p.CategoryType == 3 || p.CategoryType == 8).ToArray().Sum(p => p.BalanceValue).ToString("0.00");
            //累计消费
            string totaloutamount = "￥" + list.Where(p => p.CategoryType == 1 || p.CategoryType == 10).ToArray().Sum(p => p.BalanceValue).ToString("0.00");
            //累计赠与
            string totalbackamount = "￥" + list.Where(p => p.CategoryType == 5 || p.CategoryType == 6).ToArray().Sum(p => p.BalanceValue).ToString("0.00");
            WebUtil.WriteJsonResult(context, new { totalinamount = totalinamount, totaloutamount = totaloutamount, totalbackamount = totalbackamount });
        }
        private void getamountbalancelist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int status = WebUtil.GetIntValue(context, "status");
            var list = Mall_UserBalance.GetMall_UserBalanceList(uid);
            //累计充值
            if (status == 2)
            {
                list = list.Where(p => p.CategoryType == 2 || p.CategoryType == 3 || p.CategoryType == 8).ToArray();
            }
            //累计消费
            else if (status == 1)
            {
                list = list.Where(p => p.CategoryType == 1 || p.CategoryType == 10).ToArray();
            }
            //累计赠与
            else if (status == 3)
            {
                list = list.Where(p => p.CategoryType == 5 || p.CategoryType == 6).ToArray();
            }
            var items = list.Select(p =>
            {
                string balance = p.BalanceValue > 0 ? "+" + p.BalanceValue.ToString("0.00") : p.BalanceValue.ToString("0.00");
                var item = new { id = p.ID, title = p.Title, time = p.AddTime.ToString("yyyy-MM-dd HH:mm:ss"), balance = balance, type = p.BalanceType };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void getuseramountbalance(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            decimal amount_balance = Mall_UserBalance.GetMall_UserBalanceBalance(uid);
            WebUtil.WriteJsonResult(context, new { amount_balance = amount_balance.ToString("0.00") });
        }
        private void getuserandbalanceinfo(HttpContext context)
        {
            int uid = 0;
            Foresight.DataAccess.User user = null;
            try
            {
                uid = GetUID(context, out user);
            }
            catch (Exception)
            {
            }
            if (user == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有登录");
                return;
            }
            string headimg = string.IsNullOrEmpty(user.HeadImg) ? "../image/default_user.png" : WebUtil.GetContextPath() + user.HeadImg;
            string RealName = string.IsNullOrEmpty(user.NickName) ? "匿名用户" : user.NickName;
            decimal amount_balance = Mall_UserBalance.GetMall_UserBalanceBalance(uid);
            decimal point_balance = Mall_UserPoint.GetMall_UserPointBalance(uid);
            int fushun_coupon = Mall_CouponUser.GetMall_CouponUserCount(uid);
            decimal fushun_balance = Mall_UserJiXiaoPoint.GetMall_UserJiXiaoPointBalance(uid);
            bool isselfuser = user.Type.Equals(UserTypeDefine.APPUser.ToString());
            string levelname = string.Empty;
            int UserLevelID = user.UserLevelID > 0 ? user.UserLevelID : 0;
            string mallname = "积分商城";
            if (user.FinalParentUserID > 0)
            {
                var parent_user = Foresight.DataAccess.User.GetUser(user.FinalParentUserID);
                UserLevelID = parent_user != null ? parent_user.UserLevelID : UserLevelID;
            }
            if (UserLevelID > 0)
            {
                var user_level = Mall_UserLevel.GetMall_UserLevel(UserLevelID);
                levelname = user_level == null ? string.Empty : "(" + user_level.Name + ")";
                mallname = user_level == null ? mallname : "合伙人商城";
            }
            WebUtil.WriteJsonResult(context, new { username = RealName, headimg = headimg, phonenumber = user.PhoneNumber, amount_balance = amount_balance.ToString("0.00"), point_balance = point_balance, fushun_balance = fushun_balance, isselfuser = isselfuser, fushun_coupon = fushun_coupon.ToString() + "张", levelname = levelname, userlevelid = UserLevelID, mallname = mallname });
        }
        private void saveservicerate(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "ID");
            var dataitem = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            var data = new Foresight.DataAccess.Mall_ServiceComment();
            data.ServiceID = dataitem.ID;
            data.UserID = uid;
            data.RateStar = WebUtil.GetIntValue(context, "RateCount");
            data.RateComment = context.Request["Content"];
            data.AddTime = DateTime.Now;
            List<Foresight.DataAccess.Mall_ServiceCommentImage> attachlist = new List<Foresight.DataAccess.Mall_ServiceCommentImage>();
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
                        string filepath = "/upload/Rate/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        Foresight.DataAccess.Mall_ServiceCommentImage attach = new Foresight.DataAccess.Mall_ServiceCommentImage();
                        attach.FileOriName = fileOriName;
                        attach.ImagePath = filepath + fileName;
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
                    foreach (var item in attachlist)
                    {
                        item.ServiceID = data.ServiceID;
                        item.ServiceCommentID = data.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getserviceratelist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int id = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.CustomerService.GetCustomerService(id);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            var data_comments = Foresight.DataAccess.Mall_ServiceCommentDetail.GetMall_ServiceCommentDetailListByServiceID(data.ID);
            bool IsRated = data_comments.Length > 0;
            var comments_imagelist = Mall_ServiceCommentImage.GetMall_ServiceCommentImageListByServiceID(data.ID);
            var comment_items = data_comments.Select(p =>
            {
                string HeadImg = string.IsNullOrEmpty(p.HeadImg) ? "../image/default_user.png" : WebUtil.GetContextPath() + p.HeadImg;
                var my_imagelist = comments_imagelist.Where(q => q.ServiceCommentID == p.ID).ToArray();
                var imglist = my_imagelist.Select(q =>
                {
                    var img_item = new { url = WebUtil.GetContextPath() + q.ImagePath };
                    return img_item;
                });
                var item = new { id = p.ID, comment = p.RateComment, starcount = p.RateStar, addtime = p.AddTime.ToString("yyyy-MM-dd"), nickname = p.NickName, HeadImg = HeadImg, imglist = imglist };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { commentlist = comment_items, IsRated = IsRated });
        }
        private void getservicedetail(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不存在");
                return;
            }
            Foresight.DataAccess.User[] user_list = new User[] { };
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
            Foresight.DataAccess.User[] accpet_user = new User[] { };
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
            var item = new
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
            WebUtil.WriteJsonResult(context, item);
        }
        private void getservicelist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            long totals = 0;
            bool IsSuggestion = WebUtil.GetBoolValue(context, "IsSuggestion");
            var list = Foresight.DataAccess.ViewCustomerService.GetAPPCustomerViewCustomerServiceListByStatus(-1, uid, startRowIndex, pageSize, out totals, IsSuggestion: IsSuggestion);
            var items = list.Select(p =>
            {
                string content = string.IsNullOrEmpty(p.ServiceContent) ? "暂无详细说明" : p.ServiceContent;
                var item = new { ID = p.ID, Title = p.ServiceFullName, Content = content, ServiceType = p.ServiceTypeName, Status = p.ServiceStatus, StatusDesc = p.ServiceStatusDesc };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { gongdanlist = items });
        }
        private void savereadingpage(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int type = WebUtil.GetIntValue(context, "type");
            int id = WebUtil.GetIntValue(context, "id");
            string deviceid = context.Request["deviceid"];
            Mall_ReadPageLog.SaveMallReadPageLog(type, id, deviceid, uid);
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getmyroomlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "xiaoquid");
            var list = Foresight.DataAccess.Project.GetProjectListByAPPUserID(uid).Where(p => p.AllParentID.Contains("," + ID + ",")).ToArray();
            var items = list.Select(p =>
            {
                var item = new { id = p.ID, name = p.FullName + "-" + p.Name };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void getmyxiaoqulist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = 0;
            try
            {
                uid = GetUID(context, out user);
            }
            catch (Exception)
            {
            }
            if (uid <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "未登录");
                return;
            }
            var list = Project.GetXiaoQuProjectListByAPPUserID(uid);
            if (list.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请先绑定房间");
                return;
            }
            var items = list.Select(p =>
            {
                string addressdetail = string.Empty;
                if (!string.IsNullOrEmpty(p.AddressProvice))
                {
                    addressdetail += p.AddressProvice;
                }
                if (!string.IsNullOrEmpty(addressdetail))
                {
                    addressdetail += "-";
                }
                if (!string.IsNullOrEmpty(p.AddressCity))
                {
                    addressdetail += p.AddressCity;
                }
                if (!string.IsNullOrEmpty(addressdetail))
                {
                    addressdetail += "-";
                }
                if (!string.IsNullOrEmpty(p.AddressDistrict))
                {
                    addressdetail += p.AddressDistrict;
                }
                if (!string.IsNullOrEmpty(addressdetail))
                {
                    addressdetail += "-";
                }
                addressdetail += p.Name;
                var item = new { id = p.ID, name = p.Name, addressdetail = addressdetail };
                return item;
            });
            bool canaddaddress = false;
            var config_list = SysConfig.GetSysConfigs().ToArray();
            string config_name = SysConfigNameDefine.AllowDefineAddress.ToString();
            var sysconfig = config_list.FirstOrDefault(p => p.Name.Equals(config_name));
            if (sysconfig != null && sysconfig.Value.Equals("1"))
            {
                canaddaddress = true;
            }
            config_name = SysConfigNameDefine.OpenDoorVideoFilePath.ToString();
            sysconfig = config_list.FirstOrDefault(p => p.Name.Equals(config_name));
            string OpenDoorVideoFilePath = string.Empty;
            string OpenDoorVideoFileName = string.Empty;
            if (sysconfig != null && !string.IsNullOrEmpty(sysconfig.Value))
            {
                OpenDoorVideoFilePath = WebUtil.GetContextPath() + sysconfig.Value;
                string[] PathArray = sysconfig.Value.Split('/');
                if (PathArray.Length > 1)
                {
                    OpenDoorVideoFileName = PathArray[PathArray.Length - 1];
                }
            }
            WebUtil.WriteJsonResult(context, new { canaddaddress = canaddaddress, list = items, FilePath = OpenDoorVideoFilePath, FileName = OpenDoorVideoFileName });
        }
        private void savemallorderrefund(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int id = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Mall_Order.GetMall_Order(id);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单不存在");
                return;
            }
            if ((data.OrderStatus != 5 && data.OrderStatus != 2) || data.TotalOrderCost <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "操作不允许");
                return;
            }
            string RefundNo = string.IsNullOrEmpty(data.RefundTrackNo) ? WxPayApi.GenerateOutTradeNo() : data.RefundTrackNo;
            int RefundAmount = Convert.ToInt32(data.TotalOrderCost * 100);
            var refund_request = new Foresight.DataAccess.Mall_OrderRefundRequest();
            refund_request.OrderID = data.ID;
            refund_request.RefundTrackNo = RefundNo;
            refund_request.RefundAmount = RefundAmount;
            refund_request.AddTime = DateTime.Now;
            refund_request.AddUser = user.LoginName;
            refund_request.IsSuccess = false;
            refund_request.Result = string.Empty;
            refund_request.RefundType = data.PaymentMethod;
            List<string> UploadImages = new List<string>();
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
                        string filepath = "/upload/MallOrder/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        UploadImages.Add(filepath + fileName);
                    }
                }
            }
            if (UploadImages.Count > 0)
            {
                refund_request.UploadImages = string.Join(",", UploadImages.ToArray());
            }
            refund_request.Remark = context.Request["Content"];
            refund_request.Save();
            data.RefundRequestTime = DateTime.Now;
            data.OrderStatus = 6;
            data.IsReadRefundOrder = false;
            data.RefundTrackNo = RefundNo;
            data.Save();
            APPCode.SocketNotify.PushSocketNotifyAlert(Utility.EnumModel.SocketNotifyDefine.notifyorderrefundrequest);
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void removemyorder(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int id = WebUtil.GetIntValue(context, "id");
            var data = Foresight.DataAccess.Mall_Order.GetMall_Order(id);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单不存在");
                return;
            }
            if (!data.IsClosed)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单为非关闭状态");
                return;
            }
            data.IsDeleted = true;
            data.DeleteTime = DateTime.Now;
            data.DeleteUserName = Foresight.DataAccess.User.GetUser(uid).LoginName;
            data.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getmallaboutus(HttpContext context)
        {
            string content = string.Empty;
            string name = Utility.EnumModel.MallContentNameDefine.aboutus.ToString();
            var data = Foresight.DataAccess.Mall_Content.GetMall_ContentByName(name);
            if (data != null)
            {
                content = data.Value;
            }
            WebUtil.WriteJsonResult(context, new { content = content });
        }
        private void getmallhotline(HttpContext context)
        {
            string hotline = string.Empty;
            string name = Utility.EnumModel.MallContentNameDefine.contactus.ToString();
            var data = Foresight.DataAccess.Mall_Content.GetMall_ContentByName(name);
            if (data != null)
            {
                hotline = data.Value;
            }
            WebUtil.WriteJsonResult(context, new { hotline = hotline });
        }
        private void savemysuggestion(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            string content = context.Request["content"];
            var data = new Foresight.DataAccess.Mall_Suggestion();
            data.AddTime = DateTime.Now;
            data.UserID = uid;
            data.SummaryContent = content;
            data.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void removemyroom(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            var list = Mall_UserProject.GetMall_UserProjectListByUserID_ProjectID(uid, ProjectID, user.UserID);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in list)
                    {
                        if (item.IsManualAdd)
                        {
                            item.Delete(helper);
                        }
                        else
                        {
                            item.IsDisable = true;
                            item.Save(helper);
                        }
                    }
                    string cmdtext = "delete from [RoomPhoneRelation] where RoomID=" + ProjectID + " and (RelatePhoneNumber='" + user.LoginName + "' or UserID=" + user.UserID + ");";
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "内部异常");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void binduserroom(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ProjectID = 0;
            int.TryParse(Utility.Tools.Decrypt(context.Request["ID"]), out ProjectID);
            if (ProjectID == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            var data = Foresight.DataAccess.Mall_UserProject.GetMall_UserProject(uid, ProjectID);
            string phonenumber = string.IsNullOrEmpty(user.PhoneNumber) ? user.LoginName : user.PhoneNumber;
            var room_relation = RoomPhoneRelation.GetRoomPhoneRelationsByRoomIDAndPhone(ProjectID, phonenumber);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    if (data == null)
                    {
                        data = new Mall_UserProject();
                        data.UserID = uid;
                        data.ProjectID = ProjectID;
                        data.IsManualAdd = true;
                    }
                    data.IsDisable = false;
                    data.Save(helper);
                    if (room_relation == null)
                    {
                        room_relation = new RoomPhoneRelation();
                        room_relation.RoomID = ProjectID;
                        room_relation.RelatePhoneNumber = phonenumber;
                        room_relation.RelationName = user.NickName;
                        room_relation.IsDefault = false;
                        room_relation.AddTime = DateTime.Now;
                        room_relation.RelationType = RelationTypeDefine.homefamily.ToString();
                        room_relation.IDCardType = 1;
                        room_relation.Birthday = user.Birthday;
                        room_relation.RelationProperty = RelationPropertyDefine.geren.ToString();
                        room_relation.IsChargeFee = false;
                        room_relation.HeadImg = user.HeadImg;
                        room_relation.IsChargeMan = false;
                    }
                    room_relation.UserID = user.UserID;
                    room_relation.Save(helper);
                    user.RelationID = room_relation.ID;
                    user.Save(helper);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "binduserroom", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void adduserappopenid(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int type = WebUtil.GetIntValue(context, "type");
            string openid = context.Request["openid"];
            if (type == 8)
            {
                var my_user = Foresight.DataAccess.User.GetAPPUserByWxOpenID(openid);
                if (my_user != null)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前微信已绑定其他账号");
                    return;
                }
            }
            if (type == 9)
            {
                var my_user = Foresight.DataAccess.User.GetAPPUserByQQOpenID(openid);
                if (my_user != null)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前QQ已绑定其他账号");
                    return;
                }
            }
            if (type == 10)
            {
                var my_user = Foresight.DataAccess.User.GetAPPUserByWeiboUserID(openid);
                if (my_user != null)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前微博已绑定其他账号");
                    return;
                }
            }
            if (type == 8)
            {
                user.APPWxOpenID = context.Request["openid"];
            }
            if (type == 9)
            {
                user.APPQQOpenID = context.Request["openid"];
            }
            if (type == 10)
            {
                user.APPWeiBoUserID = context.Request["openid"];
            }
            user.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void removeuserappopenid(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int type = WebUtil.GetIntValue(context, "type");
            if (type == 8)
            {
                user.APPWxOpenID = string.Empty;
            }
            if (type == 9)
            {
                user.APPQQOpenID = string.Empty;
            }
            if (type == 10)
            {
                user.APPWeiBoUserID = string.Empty;
            }
            user.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void changephonecheck(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            string LoginName = context.Request["Username"];
            if (LoginName.Equals(user.LoginName))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请输入新的手机号码");
                return;
            }
            var new_user = Foresight.DataAccess.User.GetAPPUserByLoginName(LoginName);
            if (new_user != null && user.UserID != new_user.UserID)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码已被其他人使用");
                return;
            }
            string content = "验证码{0}，请在15分钟内按页面提示输入验证码，切勿将验证码泄露于他人。";
            string VerifyCode = Utility.Tools.SendVerifyCode(LoginName, content);
            Foresight.DataAccess.Wechat_VerifyCode.SaveWechatVerifyCode(LoginName, VerifyCode);
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void completeretrievepwd(HttpContext context)
        {
            string LoginName = context.Request["Username"];
            string password = context.Request["password"];
            string verifycode = context.Request["verifycode"];
            string UserType = context.Request["UserType"];
            var wechatVerifyCode = Wechat_VerifyCode.GetWechat_VerifyCodeByUserOpenId(string.Empty, LoginName, DateTime.Now);
            if (wechatVerifyCode == null || !wechatVerifyCode.VerifyCode.Equals(verifycode))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "验证码不正确");
                return;
            }
            var user = Foresight.DataAccess.User.GetAPPUserByLoginName(LoginName, UserType: UserType);
            if (user == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码未注册");
                return;
            }
            user.Password = User.EncryptPassword(password);
            user.Save();
            wechatVerifyCode.IsUsed = true;
            wechatVerifyCode.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void retrievelpwdcheckphone(HttpContext context)
        {
            string LoginName = context.Request["Username"];
            string UserType = context.Request["UserType"];
            var user = Foresight.DataAccess.User.GetAPPUserByLoginName(LoginName, UserType: UserType);
            if (user == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码未注册");
                return;
            }
            string content = "验证码{0}，请在15分钟内按页面提示输入验证码，切勿将验证码泄露于他人。";
            string VerifyCode = Utility.Tools.SendVerifyCode(LoginName, content);
            Foresight.DataAccess.Wechat_VerifyCode.SaveWechatVerifyCode(LoginName, VerifyCode);
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getmyrooms(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var roomlist = ViewRoomBasic.GetViewRoomBasicListByUserID(user, IncludeRelation: false, PhoneNumber: user.LoginName);
            if (roomlist.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请先绑定房间");
                return;
            }
            var items = roomlist.Select(p =>
            {
                var item = new { id = p.RoomID, name = p.Name, fullname = p.FullName };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void getmallorderratestatus(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "ID");
            var orderitem = Foresight.DataAccess.Mall_OrderItem.GetMall_OrderItem(ID);
            var list = Foresight.DataAccess.Mall_OrderComment.GetMall_OrderCommentListByUserID(uid, orderitem.OrderID, orderitem.ProductID);
            if (list.Length > 0)
            {
                WebUtil.WriteJsonResult(context, new { IsRated = true });
                return;
            }
            WebUtil.WriteJsonResult(context, new { IsRated = false });
        }
        private void savemallorderrate(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "ID");
            var orderitem = Foresight.DataAccess.Mall_OrderItem.GetMall_OrderItem(ID);
            var list = Foresight.DataAccess.Mall_OrderComment.GetMall_OrderCommentListByUserID(uid, orderitem.OrderID, orderitem.ProductID);
            if (list.Length > 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您已评价过");
                return;
            }
            var data = new Foresight.DataAccess.Mall_OrderComment();
            data.OrderID = orderitem.OrderID;
            data.ProductID = orderitem.ProductID;
            data.BusinessID = orderitem.BusinessID;
            data.UserID = uid;
            data.RateStar = WebUtil.GetIntValue(context, "RateCount");
            data.RateComment = context.Request["Content"];
            data.AddTime = DateTime.Now;
            List<Foresight.DataAccess.Mall_OrderCommentImage> attachlist = new List<Foresight.DataAccess.Mall_OrderCommentImage>();
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
                        string filepath = "/upload/Rate/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        Foresight.DataAccess.Mall_OrderCommentImage attach = new Foresight.DataAccess.Mall_OrderCommentImage();
                        attach.FileOriName = fileOriName;
                        attach.ImagePath = filepath + fileName;
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
                    foreach (var item in attachlist)
                    {
                        item.OrderCommentID = data.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void savenewphoneno(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            string LoginName = context.Request["Username"];
            string verifycode = context.Request["verifycode"];
            var wechatVerifyCode = Wechat_VerifyCode.GetWechat_VerifyCodeByUserOpenId(string.Empty, LoginName, DateTime.Now);
            if (wechatVerifyCode == null || !wechatVerifyCode.VerifyCode.Equals(verifycode))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "验证码不正确");
                return;
            }
            var new_user = Foresight.DataAccess.User.GetAPPUserByLoginName(LoginName);
            if (new_user != null && user.UserID != new_user.UserID)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码已被其他人使用");
                return;
            }
            user.LoginName = LoginName;
            user.PhoneNumber = LoginName;
            user.Save();
            wechatVerifyCode.IsUsed = true;
            wechatVerifyCode.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getuserinfo(HttpContext context)
        {
            int uid = 0;
            Foresight.DataAccess.User user = null;
            try
            {
                uid = GetUID(context, out user);
            }
            catch (Exception)
            {
            }
            if (user == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有登录");
                return;
            }
            string headimg = string.IsNullOrEmpty(user.HeadImg) ? "../image/default_user.png" : WebUtil.GetContextPath() + user.HeadImg;
            string RealName = string.IsNullOrEmpty(user.NickName) ? "匿名用户" : user.NickName;
            bool iswxbind = !string.IsNullOrEmpty(user.APPWxOpenID);
            bool isqqbind = !string.IsNullOrEmpty(user.APPQQOpenID);
            bool isweibobind = !string.IsNullOrEmpty(user.APPWeiBoUserID);
            var config = SysConfig.GetSysConfigByName(SysConfigNameDefine.FirstChangeBirthdayNote.ToString());
            string firstchangenote = "点击保存后就无法修改，生日当天会有好礼相送";
            if (config != null && !string.IsNullOrEmpty(config.Value))
            {
                firstchangenote = config.Value;
            }
            bool firstchangebirthday = false;
            if (!user.FirstChangeBirthday || user.Birthday == DateTime.MinValue)
            {
                firstchangebirthday = true;
            }
            WebUtil.WriteJsonResult(context, new { nickname = RealName, imageurl = headimg, phoneno = user.PhoneNumber, sex = user.Gender, birthday = (user.Birthday > DateTime.MinValue ? user.Birthday.ToString("yyyy-MM-dd") : ""), iswxbind = iswxbind, isqqbind = isqqbind, isweibobind = isweibobind, firstchangebirthday = firstchangebirthday, firstchangenote = firstchangenote });
        }
        private void saveuserinfo(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                HttpPostedFile postedFile = uploadFiles[0];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/UserCenter/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    user.HeadImg = filepath + fileName;
                }
            }
            if (context.Request["sex"] != null)
            {
                user.Gender = context.Request["sex"];
            }
            if (context.Request["phoneno"] != null)
            {
                user.PhoneNumber = context.Request["phoneno"];
            }
            if (context.Request["nickname"] != null)
            {
                user.NickName = context.Request["nickname"];
            }
            bool savebirthday = false;
            if (context.Request["savebirthday"] != null)
            {
                bool.TryParse(context.Request["savebirthday"], out savebirthday);
            }
            if (savebirthday)
            {
                user.FirstChangeBirthday = true;
            }
            if (context.Request["birthday"] != null)
            {
                user.Birthday = WebUtil.GetDateValue(context, "birthday");
            }
            user.Save();
            WebUtil.WriteJsonResult(context, new { headimg = WebUtil.GetContextPath() + user.HeadImg });
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
                int waitsecond = 0;
                if (item.Type == 7)
                {
                    if (string.IsNullOrEmpty(footer_banner_img))
                    {
                        var banner_imagelist = Foresight.DataAccess.Mall_RotatingImage.GetMall_RotatingImageListByType(9).ToList();
                        if (banner_imagelist.Count > 0)
                        {
                            footer_banner_img = WebUtil.GetContextPath() + banner_imagelist[0].ImagePath;
                        }
                    }
                    waitsecond = item.WaitSecond > 0 ? item.WaitSecond : 0;
                }
                totalsecond += waitsecond;
                var dic = new Dictionary<string, object>();
                dic["ID"] = item.ID;
                dic["imageurl"] = WebUtil.GetContextPath() + item.ImagePath;
                dic["productid"] = item.URLLinkID;
                dic["type"] = item.URLLinkType;
                dic["cacheurl"] = "";
                dic["waitsecond"] = waitsecond;
                imageitems.Add(dic);
                //var item = new { ID = p.ID, imageurl = WebUtil.GetContextPath() + p.ImagePath, productid = p.URLLinkID, type = p.URLLinkType, cacheurl = "", waitsecond = waitsecond };
            }
            WebUtil.WriteJsonResult(context, new { imagelist = imageitems, totalsecond = totalsecond, footer_banner_img = footer_banner_img });
        }
        private void getthreadcommentlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int id = WebUtil.GetIntValue(context, "id");
            var list = Mall_ThreadComment.GetMall_ThreadCommentListByThreadID(id);
            List<int> UserIDList = list.Where(p => p.UserID > 0).Select(p => p.UserID).ToList();
            var userlist = Foresight.DataAccess.User.GetUserListByIDList(UserIDList);
            var xiaoqu_list = Foresight.DataAccess.Project.GetXiaoQuProjectListByAPPUserIDList(UserIDList);
            var user_project_list = Mall_UserProject.GetMall_UserProjectListByUserIDList(UserIDList);
            var project_list = Foresight.DataAccess.Project.GetProjectListByAPPUserIDList(UserIDList);
            var items = list.Select(p =>
            {
                var my_user = userlist.FirstOrDefault(q => q.UserID == p.UserID);
                string headimage = "../image/default_user.png";
                string Name = "匿名用户";
                if (my_user != null)
                {
                    headimage = string.IsNullOrEmpty(my_user.HeadImg) ? headimage : WebUtil.GetContextPath() + my_user.HeadImg;
                    Name = string.IsNullOrEmpty(my_user.NickName) ? Name : my_user.NickName;
                }
                string AddTime = p.AddTime.ToString("yyyy-MM-dd");
                if (DateTime.Now.ToString("yyyy-MM-dd").Equals(p.AddTime.ToString("yyyy-MM-dd")))
                {
                    AddTime = p.AddTime.ToString("HH:mm");
                }
                string Content = p.Comment;
                string ResponseUserName = string.Empty;
                if (p.ResponseUserID > 0)
                {
                    var res_user = userlist.FirstOrDefault(q => q.UserID == p.ResponseUserID);
                    if (res_user != null)
                    {
                        ResponseUserName = string.IsNullOrEmpty(res_user.NickName) ? "匿名用户" : res_user.NickName;
                    }
                }
                var my_user_project_id_list = user_project_list.Where(q => q.UserID == p.UserID).Select(q => q.ProjectID).ToArray();
                var my_project_list = project_list.Where(q => my_user_project_id_list.Contains(q.ID)).ToArray();
                var my_xiaoqu_list = Foresight.DataAccess.Project.GetMyXiaoQuListByMyAPPProjectList(xiaoqu_list, my_project_list);
                string myxiaoquname = my_xiaoqu_list.Length == 0 ? "" : my_xiaoqu_list[0].Name;
                var item = new { id = p.ID, headimage = headimage, Name = Name, AddTime = AddTime, Content = Content, ResponseUserName = ResponseUserName, ResponseUserID = p.ResponseUserID, UserID = p.UserID, myxiaoquname = myxiaoquname };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { commentlist = items });
        }
        private void postthreadcomment(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            string Content = context.Request["Content"];
            if (string.IsNullOrEmpty(Content))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您什么也没留下");
                return;
            }
            var waring_keywords = Mall_ChatSensitive.GetMall_ChatSensitiveListByKeywords(Content);
            if (waring_keywords.Length > 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您输入的消息含有敏感关键词");
                return;
            }
            int id = WebUtil.GetIntValue(context, "id");
            var data = new Mall_ThreadComment();
            data.AddTime = DateTime.Now;
            data.UserID = uid;
            data.ThreadID = id;
            data.Comment = context.Request["Content"];
            data.ResponseUserID = WebUtil.GetIntValue(context, "ResponseUserID");
            data.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void postthreadpraise(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int id = WebUtil.GetIntValue(context, "id");
            var data = Foresight.DataAccess.Mall_ThreadPraise.GetMall_ThreadPraiseByThreadID(id, uid);
            if (data != null && data.IsPraise)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您已赞过");
                return;
            }
            if (data == null)
            {
                data = new Mall_ThreadPraise();
                data.AddTime = DateTime.Now;
                data.UserID = uid;
                data.ThreadID = id;
            }
            data.IsPraise = true;
            data.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getthreaddetail(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Mall_Thread.GetMall_Thread(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            string AddTime = data.AddTime.ToString("yyyy-MM-dd");
            if (DateTime.Now.ToString("yyyy-MM-dd").Equals(data.AddTime.ToString("yyyy-MM-dd")))
            {
                AddTime = data.AddTime.ToString("HH:mm");
            }
            string GroupName = string.Empty;
            if (data.CategoryID > 0)
            {
                var category = Foresight.DataAccess.Mall_Category.GetMall_Category(data.CategoryID);
                GroupName = category == null ? string.Empty : category.CategoryName;
            }
            string headimage = "../image/default_user.png";
            string Name = "匿名用户";
            if (data.UserID > 0)
            {
                var my_user = Foresight.DataAccess.User.GetUser(data.UserID);
                if (my_user != null)
                {
                    headimage = !string.IsNullOrEmpty(my_user.HeadImg) ? WebUtil.GetContextPath() + my_user.HeadImg : headimage;
                    Name = !string.IsNullOrEmpty(my_user.NickName) ? my_user.NickName : Name;
                }
            }
            var imagelist = Foresight.DataAccess.Mall_ThreadImage.GetMall_ThreadImageListByThreadID(data.ID);
            var imageitems = imagelist.Select(p =>
            {
                var item = new { id = p.ID, url = WebUtil.GetContextPath() + p.ImagePath, cacheurl = "" };
                return item;
            });
            var thread_praise_list = Foresight.DataAccess.Mall_ThreadPraise.GetMall_ThreadPraiseListByThreadID(data.ID);
            string praisecountdesc = thread_praise_list.Length > 0 ? thread_praise_list.Length.ToString() : "赞";
            bool ispraised = false;
            var my_thread_praise = thread_praise_list.FirstOrDefault(p => p.UserID == uid);
            if (my_thread_praise != null && my_thread_praise.IsPraise)
            {
                ispraised = true;
            }
            bool userforbiddened = false;
            var list = Mall_UserForbidden.GetMall_UserForbiddenListByUserID(uid);
            var user_forbidden = list.FirstOrDefault(p => p.IsActive);
            if (user_forbidden != null)
            {
                userforbiddened = true;
            }
            var my_xiaoqu_list = Foresight.DataAccess.Project.GetXiaoQuProjectListByAPPUserID(data.UserID);
            string myxiaoquname = my_xiaoqu_list.Length == 0 ? "" : my_xiaoqu_list[0].Name;
            string CityName = "兴义市";
            CityName = string.IsNullOrEmpty(data.CityName) ? CityName : data.CityName;
            myxiaoquname = CityName + " - " + myxiaoquname;
            var form = new { id = data.ID, Name = Name, AddTime = AddTime, GroupName = GroupName, Content = data.Description, headimage = headimage, praisecountdesc = praisecountdesc, ispraised = ispraised, myxiaoquname = myxiaoquname, cancomment = !data.IsStopComment, userforbiddened = userforbiddened };
            WebUtil.WriteJsonResult(context, new { form = form, imglist = imageitems });
        }
        private void getthreadlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var category_list = Foresight.DataAccess.Mall_Category.GetMall_Categories().Where(p => p.CategoryType.Equals(Utility.EnumModel.Mall_CategoryTypeDefine.threadcategory.ToString()) && !p.IsDisabled).OrderBy(p => p.SortOrder).ThenByDescending(p => p.AddTime).ToArray();
            int CategoryID = WebUtil.GetIntValue(context, "CategoryID");
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            int top = WebUtil.GetIntValue(context, "top");
            top = top > 0 ? top : 5;
            long startRowIndex = pageindex != null ? long.Parse(pageindex) : 0;
            int pageSize = pagesize != null ? int.Parse(pagesize) : top;
            int type = WebUtil.GetIntValue(context, "type");
            long total = 0;
            var list = Foresight.DataAccess.Mall_Thread.GetMall_ThreadListByKeyword(CategoryID, startRowIndex, pageSize, out total, ThreadType: type);
            List<int> UserIDList = list.Where(p => p.UserID > 0).Select(p => p.UserID).ToList();
            var user_list = Foresight.DataAccess.User.GetUserListByIDList(UserIDList);
            var thread_praise_list = Foresight.DataAccess.Mall_ThreadPraise.GetMall_ThreadPraiseListByThreadIDList(list.Select(p => p.ID).ToList());
            var xiaoqu_list = Foresight.DataAccess.Project.GetXiaoQuProjectListByAPPUserIDList(UserIDList);
            var user_project_list = Mall_UserProject.GetMall_UserProjectListByUserIDList(UserIDList);
            var project_list = Foresight.DataAccess.Project.GetProjectListByAPPUserIDList(UserIDList);
            var chatlist = list.Select(p =>
            {
                var my_category = category_list.FirstOrDefault(q => q.ID == p.CategoryID);
                string GroupName = my_category != null ? my_category.CategoryName : string.Empty;
                string AddTime = p.AddTime.ToString("yyyy-MM-dd");
                if (DateTime.Now.ToString("yyyy-MM-dd").Equals(p.AddTime.ToString("yyyy-MM-dd")))
                {
                    AddTime = p.AddTime.ToString("HH:mm");
                }
                var my_user = user_list.FirstOrDefault(q => q.UserID == p.UserID);
                string headimage = "../image/default_user.png";
                string UserName = "匿名用户";
                if (my_user != null)
                {
                    if (!string.IsNullOrEmpty(my_user.HeadImg))
                    {
                        headimage = WebUtil.GetContextPath() + my_user.HeadImg;
                    }
                    UserName = string.IsNullOrEmpty(my_user.NickName) ? UserName : my_user.NickName;
                }
                var my_thread_praise_list = thread_praise_list.Where(q => q.ThreadID == p.ID).ToArray();
                bool ispraised = false;
                var my_thread_praise = my_thread_praise_list.FirstOrDefault(q => q.UserID == uid);
                if (my_thread_praise != null && my_thread_praise.IsPraise)
                {
                    ispraised = true;
                }
                string praisecountdesc = my_thread_praise_list.Length > 0 ? my_thread_praise_list.Length.ToString() : "赞";
                var my_user_project_id_list = user_project_list.Where(q => q.UserID == p.UserID).Select(q => q.ProjectID).ToArray();
                var my_project_list = project_list.Where(q => my_user_project_id_list.Contains(q.ID)).ToArray();
                var my_xiaoqu_list = Foresight.DataAccess.Project.GetMyXiaoQuListByMyAPPProjectList(xiaoqu_list, my_project_list);
                string myxiaoquname = my_xiaoqu_list.Length == 0 ? "" : my_xiaoqu_list[0].Name;
                string CityName = "兴义市";
                if (!string.IsNullOrEmpty(p.CityName))
                {
                    CityName = p.CityName;
                }
                myxiaoquname = CityName + " - " + myxiaoquname;
                var item = new { id = p.ID, Name = UserName, AddTime = AddTime, GroupName = GroupName, Content = p.Description, headimage = headimage, praisecountdesc = praisecountdesc, ispraised = ispraised, myxiaoquname = myxiaoquname, cancomment = !p.IsStopComment };
                return item;
            });
            int count = 0;
            var menus = category_list.Select(p =>
            {
                bool is_active = false;
                if (CategoryID > 0)
                {
                    is_active = p.ID == CategoryID;
                }
                else
                {
                    count++;
                    is_active = false;
                }
                var item = new { id = p.ID, title = p.CategoryName, is_active = is_active };
                return item;
            }).ToList();
            int hidemore = WebUtil.GetIntValue(context, "hidemore");
            if (hidemore == 0)
            {
                if (menus.Count > 0)
                {
                    menus.Add(new { id = 0, title = "更多", is_active = false });
                }
            }
            if (CategoryID == 0 && category_list.Length > 0)
            {
                CategoryID = category_list[0].ID;
            }
            WebUtil.WriteJsonResult(context, new { menus = menus, chatlist = chatlist, CategoryID = CategoryID });
        }
        private void savethreadpost(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            string Content = context.Request["Content"];
            if (string.IsNullOrEmpty(Content))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您什么也没留下");
                return;
            }
            var waring_keywords = Mall_ChatSensitive.GetMall_ChatSensitiveListByKeywords(Content);
            if (waring_keywords.Length > 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您输入的消息含有敏感关键词");
                return;
            }
            int CategoryID = WebUtil.GetIntValue(context, "CategoryID");
            var data = new Foresight.DataAccess.Mall_Thread();
            data.AddTime = DateTime.Now;
            data.UserID = uid;
            data.Description = Content;
            data.UserName = user.NickName;
            data.CategoryID = CategoryID;
            data.CityName = context.Request["CityName"];
            data.ThreadType = WebUtil.GetIntValue(context, "type");
            List<Foresight.DataAccess.Mall_ThreadImage> customer_attachlist = new List<Foresight.DataAccess.Mall_ThreadImage>();
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
                        string filepath = "/upload/Thread/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        Foresight.DataAccess.Mall_ThreadImage customer_attach = new Foresight.DataAccess.Mall_ThreadImage();
                        customer_attach.FileOriName = fileOriName;
                        customer_attach.ImagePath = filepath + fileName;
                        customer_attach.AddTime = DateTime.Now;
                        customer_attachlist.Add(customer_attach);
                    }
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    foreach (var attach in customer_attachlist)
                    {
                        attach.ThreadID = data.ID;
                        attach.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "savethreadpost", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器异常");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
            return;
        }
        private void savesurveyvoteresponse(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "id");
            var question = Foresight.DataAccess.Wechat_SurveyQuestion.GetWechat_SurveyQuestion(ID);
            if (question == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "投票已过期");
                return;
            }
            var survey = Wechat_Survey.GetWechat_Survey(question.SurveyID);
            var list = Foresight.DataAccess.Wechat_SurveyOptionResponse.GetWechat_SurveyQuestionResponseListByQuestionID(ID, uid);
            bool canvote = Wechat_SurveyQuestion.CheckWechat_SurveyQuestionVoteStatus(survey, uid, list);
            if (!canvote)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "您已投过票了");
                return;
            }
            var data = new Wechat_SurveyOptionResponse();
            data.AddTime = DateTime.Now;
            data.UserID = uid;
            data.SurveyQuestionOptionID = 0;
            data.SurveyQuestionID = question.ID;
            data.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getsurveyvotesbyid(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
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
                    canvote = Wechat_SurveyQuestion.CheckWechat_SurveyQuestionVoteStatus(data, uid, my_response_list);
                }
                votedesc = canvote ? "投我一票" : votedesc;
                var item = new { id = p.ID, imageurl = imageurl, title = p.QuestionContent, summary = p.QuestionSummary, votecountdesc = votecountdesc, canvote = canvote, votedesc = votedesc };
                return item;
            });
            var form = new { id = data.ID, title = data.Title, summary = data.Description };
            WebUtil.WriteJsonResult(context, new { list = items, form = form });
        }
        private void savesurveyresponse(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
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
            var list = Foresight.DataAccess.Wechat_SurveyOptionResponse.GetWechat_SurveyOptionResponseListBySurveyID(SurveyID, UserID: uid);
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
                            cmdtext += @"insert into [Wechat_SurveyOptionResponse] ([UserID],[SurveyQuestionOptionID],[AddTime]) values ('" + uid + "'," + option.OptionID + ",getdate());";
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
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
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
            var list = Foresight.DataAccess.Wechat_SurveyOptionResponse.GetWechat_SurveyOptionResponseListBySurveyID(SurveyID, UserID: uid);
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
            WebUtil.WriteJsonResult(context, new { questions = items, form = new { id = data.ID, title = data.Title } });
        }
        private void getmallsurveylist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int type = WebUtil.GetIntValue(context, "type");
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            long totals = 0;
            var list = Foresight.DataAccess.Wechat_Survey.GetWechat_SurveyListBySurveyType(type, startRowIndex, pageSize, out  totals, IsAPPCustomerShow: true);
            List<int> survey_idlist = list.Select(p => p.ID).ToList();
            Foresight.DataAccess.Wechat_SurveyQuestionOption[] option_list = null;
            Foresight.DataAccess.Wechat_SurveyQuestion[] question_list = null;
            Foresight.DataAccess.Wechat_SurveyOptionResponse[] res_list = null;
            if (type == 1)
            {
                option_list = Foresight.DataAccess.Wechat_SurveyQuestionOption.GetWechat_SurveyQuestionOptionListBySurveyIDList(survey_idlist);
                res_list = Foresight.DataAccess.Wechat_SurveyOptionResponse.GetWechat_SurveyOptionResponseListBySurveyIDList(survey_idlist);
            }
            else if (type == 2)
            {
                question_list = Foresight.DataAccess.Wechat_SurveyQuestion.GetWechat_SurveyQuestionListBySurveyIDList(survey_idlist);
                res_list = Foresight.DataAccess.Wechat_SurveyOptionResponse.GetWechat_SurveyQuestionResponseListBySurveyIDList(survey_idlist);
            }
            var items = list.Select(p =>
            {
                int joingcount = 0;
                if (type == 1)
                {
                    var my_option_idlist = option_list.Where(q => q.SurveyID == p.ID).Select(q => q.ID).ToList();
                    joingcount = res_list.Where(q => my_option_idlist.Contains(q.SurveyQuestionOptionID)).Select(q => q.UserID).Distinct().Count();
                }
                else if (type == 2)
                {
                    var my_question_idlist = question_list.Where(q => q.SurveyID == p.ID).Select(q => q.ID).ToList();
                    joingcount = res_list.Where(q => my_question_idlist.Contains(q.SurveyQuestionID)).Select(q => q.UserID).Distinct().Count();
                }
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
                var item = new { id = p.ID, title = p.Title, imageurl = string.IsNullOrEmpty(p.CoverImg) ? "../image/error-img.png" : WebUtil.GetContextPath() + p.CoverImg, time = time, totalcount = "已参与: " + joingcount.ToString() + "人" };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void createpintuanorder(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int orderid = WebUtil.GetIntValue(context, "orderid");
            string user_note = context.Request["user_note"];
            int addressid = WebUtil.GetIntValue(context, "addressid");
            var order = Foresight.DataAccess.Mall_Order.GetMall_Order(orderid);
            order.UserNote = user_note;
            Foresight.DataAccess.Mall_Address mall_address = null;
            if (addressid > 0)
            {
                mall_address = Foresight.DataAccess.Mall_Address.GetMall_Address(addressid);
            }
            if (mall_address == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请选择收货地址");
            }
            string ShipRateTitle = context.Request["shipratename"];
            decimal ShipRateAmount = WebUtil.GetDecimalValue(context, "shiprateamount");
            int ShipRateID = WebUtil.GetIntValue(context, "shiprateid");
            int ShipRateType = WebUtil.GetIntValue(context, "shipratetype");
            order.ShipRateID = ShipRateID;
            order.ShipRateAmount = ShipRateAmount;
            order.ShipRateName = ShipRateTitle;
            order.ShipCompanyName = ShipRateTitle;
            if (mall_address != null)
            {
                order.AddressID = mall_address.ID;
                order.AddressUserName = mall_address.AddressUserName;
                order.AddressPhoneNumber = mall_address.AddressPhoneNo;
                order.AddressProvince = mall_address.AddressProvice;
                order.AddressCity = mall_address.AddressCity;
                order.AddressDistrict = mall_address.AddressDistrict;
                order.AddressDetailInfo = mall_address.AddressDetailInfo;
                order.AddressProjectID = mall_address.ProjectID;
                order.AddressRoomID = mall_address.RoomID;
                var order_item_list = Mall_OrderItem.GetMall_OrderItemListByOrderID(order.ID);
                if (order_item_list.Length > 0)
                {
                    var my_orderitem = order_item_list[0];
                    my_orderitem.ShipRateAmount = ShipRateAmount;
                    my_orderitem.ShipRateID = ShipRateID;
                    my_orderitem.ShipRateTitle = ShipRateTitle;
                    my_orderitem.ShipRateType = ShipRateType;
                    my_orderitem.TotalSalePoint = 0;
                    my_orderitem.SalePoint = 0;
                    my_orderitem.VIPSalePoint = 0;
                    my_orderitem.VIPTotalSalePoint = 0;
                    my_orderitem.StaffPoint = 0;
                    my_orderitem.TotalSalePoint = 0;
                    my_orderitem.ProductBuyType = 16;
                    my_orderitem.Save();
                }
            }
            order.CouponID = WebUtil.GetIntValue(context, "couponid");
            order.CouponUserID = WebUtil.GetIntValue(context, "couponuserid");
            order.CouponAmount = WebUtil.GetDecimalValue(context, "couponprice");
            order.TotalSalePoint = 0;
            order.TotalVIPSalePoint = 0;
            order.TotalSaleStaffPoint = 0;
            order.Save();
            Mall_CouponUser coupon_user = null;
            if (order.CouponUserID > 0)
            {
                coupon_user = Mall_CouponUser.GetMall_CouponUser(order.CouponUserID);
            }
            if (coupon_user != null)
            {
                coupon_user.IsUsed = true;
                coupon_user.UseTime = DateTime.Now;
                coupon_user.UseType = 1;
                coupon_user.Save();
            }
            WebUtil.WriteJsonResult(context, new { id = order.ID });
        }
        private void savemynickname(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            user.NickName = context.Request["nickname"];
            user.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void addproducttopindan(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int productid = WebUtil.GetIntValue(context, "productid");
            int variantid = WebUtil.GetIntValue(context, "variantid");
            int quantity = WebUtil.GetIntValue(context, "quantity");
            var product = Foresight.DataAccess.Mall_Product.GetMall_Product(productid);
            if (product.ProductTypeID != 3)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该商品未参与拼团活动");
                return;
            }
            var pin_user_list = Mall_ProductPinUserDetail.GetMall_ProductPinUserDetailByUserID(uid, product.ID);
            if (pin_user_list.Length > 0)
            {
                if (pin_user_list.FirstOrDefault(p => p.FinalStatus == 1) != null)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "你已参与该商品的拼团活动");
                    return;
                }
                if (pin_user_list.FirstOrDefault(p => p.FinalStatus == 2) != null)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请先支付上次参与的该商品的拼团活动");
                    return;
                }
            }
            int joincount = Mall_ProductPinUserDetail.GetMall_ProductPinUserDetailCountByProductID(product.ID);
            var list = Mall_ProductPinUserDetail.GetMall_ProductPinUserDetailListByProductID(product.ID);
            if (joincount == product.PinPeopleCount)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该团已达到人数要求，请下次再来");
                return;
            }
            var data = Mall_ProductPinOrganiser.GetMall_ProductPinOrganiserByProductID(product.ID);
            if (data == null)
            {
                data = new Mall_ProductPinOrganiser();
                data.AddTime = DateTime.Now;
                data.UserID = uid;
                data.ProductID = product.ID;
                data.VariantID = variantid;
                data.Status = 1;
            }
            var pin_user = new Mall_ProductPinUser();
            pin_user.ProductID = product.ID;
            pin_user.StartTime = product.PinStartTime;
            pin_user.EndTime = product.PinEndTime;
            pin_user.PinSalePrice = product.PinSalePrice;
            pin_user.VariantID = variantid;
            pin_user.Quantity = quantity;
            pin_user.UserID = uid;
            pin_user.AddTime = DateTime.Now;
            pin_user.Status = 1;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    pin_user.OrganiserID = data.ID;
                    pin_user.Save(helper);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "addproducttopindan", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getbusinesslistbycategoryid(HttpContext context)
        {
            int get_category = WebUtil.GetIntValue(context, "get_category");
            string type = context.Request["type"];
            List<Dictionary<string, object>> menus = new List<Dictionary<string, object>>();
            if (get_category == 1)
            {
                var categories = Foresight.DataAccess.Mall_Category.GetMall_Categories().Where(p => p.CategoryType.Equals(type) && !p.IsDisabled).OrderBy(p => p.SortOrder).ThenByDescending(p => p.AddTime).ToArray();
                menus = categories.Select(p =>
                {
                    string src = string.IsNullOrEmpty(p.PicturePath) ? "../image/error-img.png" : WebUtil.GetContextPath() + p.PicturePath;
                    var dic = new Dictionary<string, object>();
                    dic["id"] = p.ID;
                    dic["title"] = p.CategoryName;
                    dic["is_active"] = false;
                    dic["src"] = src;
                    return dic;
                }).ToList();
                int notaddall = WebUtil.GetIntValue(context, "notaddall");
                if (notaddall == 0 && menus.Count > 0)
                {
                    menus.Insert(0, new Dictionary<string, object> { { "id", 0 }, { "title", "全部分类" }, { "is_active", true } });
                }
            }
            int sortby = WebUtil.GetIntValue(context, "sortby");
            int categoryid = WebUtil.GetIntValue(context, "categoryid");
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            long totals = 0;
            double lon = 0;
            double lat = 0;
            if (!string.IsNullOrEmpty(context.Request["lon"]))
            {
                double.TryParse(context.Request["lon"], out lon);
            }
            if (!string.IsNullOrEmpty(context.Request["lat"]))
            {
                double.TryParse(context.Request["lat"], out lat);
            }
            int tagid = WebUtil.GetIntValue(context, "tagid");
            bool issuggestion = WebUtil.GetIntValue(context, "issuggestion") == 1;
            var list = Foresight.DataAccess.Mall_BusinessDetail.GetMall_BusinessDetailListByKeywords(string.Empty, sortby, startRowIndex, pageSize, out totals, CategoryID: categoryid, lon: lon, lat: lat, TagID: tagid, issuggestion: issuggestion);
            var items = list.Select(p =>
            {
                string imageurl = string.IsNullOrEmpty(p.CoverImage) ? "../image/error-img.png" : WebUtil.GetContextPath() + p.CoverImage;
                var item = new { id = p.ID, title = p.BusinessName, rate = p.RateComment, price = string.Empty, address = p.BusinessAddress, distance = p.Distance, distancedesc = p.DistanceDesc, imageurl = imageurl, istopshow = p.IsTopShow, PhoneNumber = p.ContactPhone, Remark = p.Remark };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { menus = menus, list = items });
        }
        private void getproductlistbybusinessid(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = 0;
            try
            {
                uid = GetUID(context, out user);
            }
            catch (Exception)
            {
            }
            string keywords = context.Request["keywords"];
            int sortby = WebUtil.GetIntValue(context, "sortby");
            int businessid = WebUtil.GetIntValue(context, "businessid");
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            long totals = 0;
            bool isallowpointbuy = WebUtil.GetIntValue(context, "isallowpointbuy") == 1;
            bool IsAllowProductBuy = WebUtil.GetIntValue(context, "IsAllowProductBuy") == 1;
            bool IsAllowVIPBuy = WebUtil.GetIntValue(context, "IsAllowVIPBuy") == 1;
            var list = Foresight.DataAccess.Mall_ProductDetail.GetMall_ProductDetailListByKeywords(keywords, sortby, startRowIndex, pageSize, out totals, BusinessID: businessid, ProductTypeID: 1, isallowpointbuy: isallowpointbuy, IsAllowProductBuy: IsAllowProductBuy, IsAllowVIPBuy: IsAllowVIPBuy);
            var ProductIDList = list.Select(p => p.ID).ToList();
            var items = list.Select(p =>
            {
                string imageurl = string.IsNullOrEmpty(p.CoverImage) ? "../image/error-img.png" : WebUtil.GetContextPath() + p.CoverImage;
                string PriceDesc = string.Empty;
                if (IsAllowProductBuy)
                {
                    PriceDesc = p.NormalPriceDesc;
                }
                else if (isallowpointbuy)
                {
                    PriceDesc = p.PointPriceDesc;
                }
                else if (IsAllowVIPBuy)
                {
                    PriceDesc = p.VIPPointPriceDesc;
                }
                var item = new { id = p.ID, title = p.ProductName, price = PriceDesc, saledesc = p.SaleCountDesc, imageurl = imageurl };
                return item;
            });
            var coupon_list = Mall_Coupon.GetMall_CouponListByCouponType(2, BusinessID: businessid);
            var coupon_user_list = Mall_CouponUser.GetMall_CouponUserListByCouponType(5, uid);
            var coupon_items = coupon_list.Select(p =>
            {
                var my_coupon_user = coupon_user_list.FirstOrDefault(q => q.CouponID == p.ID);
                bool istaken = my_coupon_user != null;
                string title = p.CouponName;
                if (istaken)
                {
                    title = p.CouponName + "(已领取)";
                }
                var item = new { id = p.ID, title = title, istaken = istaken };
                return item;
            });
            bool hascoupon = coupon_list.Length > 0;
            if (businessid > 0)
            {
                var business = Foresight.DataAccess.Mall_Business.GetMall_Business(businessid);
                if (business != null)
                {
                    string rate = string.Empty;
                    string distance = string.Empty;
                    string imageurl = string.IsNullOrEmpty(business.CoverImage) ? "../image/error-img.png" : WebUtil.GetContextPath() + business.CoverImage;
                    WebUtil.WriteJsonResult(context, new { list = items, businessinfo = new { id = business.ID, title = business.BusinessName, rate = rate, address = business.BusinessAddress, distance = distance, imageurl = imageurl, is_ziying = false, hascoupon = hascoupon }, couponlist = coupon_items });
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void getapphomesource(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = 0;
            try
            {
                uid = GetUID(context, out user);
            }
            catch (Exception)
            {
            }
            //滚动消息
            var msglist = Foresight.DataAccess.Wechat_Msg.GetWechat_Msgs().ToArray();
            var notifylist = msglist.Where(p => !p.MsgType.Equals(Utility.EnumModel.WechatMsgType.news.ToString()) && p.IsCustomerAPPSend && p.IsTopShow).ToArray();
            var msgitems = notifylist.Select(p =>
            {
                string title_tag = Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatMsgType), p.MsgType);
                var item = new { id = p.ID, title = title_tag + ": " + p.MsgTitle };
                return item;
            });
            //社区新闻
            var msg_categories = Foresight.DataAccess.Wechat_MsgCategory.GetWechat_MsgCategories().ToArray();
            var newslist = msglist.Where(p => p.MsgType.Equals(Utility.EnumModel.WechatMsgType.news.ToString()) && p.IsCustomerAPPSend && p.IsTopShow).ToArray();
            var newsitems = newslist.Select(p =>
            {
                var msg_category = msg_categories.FirstOrDefault(q => q.ID == p.CategoryID);
                string categoryname = msg_category == null ? string.Empty : msg_category.CategoryName;
                string imageurl = string.IsNullOrEmpty(p.PicPath) ? "../image/error-img.png" : WebUtil.GetContextPath() + p.PicPath;
                string title_tag = Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatMsgType), p.MsgType);
                var item = new { id = p.ID, title = p.MsgTitle, categoryname = categoryname, imageurl = imageurl };
                return item;
            });
            var config_list = SysConfig.GetSysConfigs().ToArray();
            //福顺优选
            var config_youxuan = config_list.FirstOrDefault(p => p.Name.Equals(SysConfigNameDefine.MallHomeYouXuanCount.ToString()));
            int youxuan_count = 10;
            if (config_youxuan != null)
            {
                int.TryParse(config_youxuan.Value, out youxuan_count);
                youxuan_count = youxuan_count > 0 ? youxuan_count : 10;
            }
            var productlist = Foresight.DataAccess.Mall_ProductDetail.GetMall_ProductDetailList(IsShowOnHome: true, IsAllowProductBuy: true).ToArray();
            var ziying_list = productlist.Where(p => p.ProductTypeID == 1 && p.IsYouXuan).OrderBy(p => p.YouXuanSortOrder).Take(youxuan_count).ToArray();
            var ziyingitems = ziying_list.Select(p =>
            {
                string imageurl = string.IsNullOrEmpty(p.CoverImage) ? "../image/error-img.png" : WebUtil.GetContextPath() + p.CoverImage;
                var item = new { id = p.ID, title = p.ProductName, price = p.NormalPriceDesc, salepoint = p.VariantPoint, saleprice = p.FinalVariantPrice, imageurl = imageurl };
                return item;
            });
            //拼团抢购
            var config_tuan = config_list.FirstOrDefault(p => p.Name.Equals(SysConfigNameDefine.MallHomePinTanCount.ToString()));
            int pint_count = 4;
            if (config_tuan != null)
            {
                int.TryParse(config_tuan.Value, out pint_count);
                pint_count = pint_count > 0 ? pint_count : 4;
            }
            var pin_list = productlist.Where(p => p.ProductTypeID == 3 || p.ProductTypeID == 4).OrderBy(p => p.PinTuanSortOrder).Take(4).ToArray();
            var pintuanitems = pin_list.Select(p =>
            {
                string imageurl = string.IsNullOrEmpty(p.CoverImage) ? "../image/error-img.png" : WebUtil.GetContextPath() + p.CoverImage;
                string countdowndate = p.countdowndate > DateTime.MinValue ? p.countdowndate.ToString("yyyy-MM-dd HH:mm:ss") : "";
                var item = new { id = p.ID, title = p.ProductName, price = p.NormalPriceDesc, imageurl = imageurl, status = p.PinStatus, statusdesc = p.PinStatusDesc, inventory = p.Inventory, inventorydesc = p.InventoryDesc, countdownenable = p.countdownenable, countdown_timmer = 0, countdowndate = countdowndate, leftTime = 0, countdownday = "", countdowndesc = p.countdowndesc };
                return item;
            });
            //推荐商家
            var config_business = config_list.FirstOrDefault(p => p.Name.Equals(SysConfigNameDefine.MallHomeBusinessCount.ToString()));
            int business_count = 6;
            if (config_business != null)
            {
                int.TryParse(config_business.Value, out business_count);
                business_count = business_count > 0 ? business_count : 6;
            }
            var business_list = Foresight.DataAccess.Mall_Business.GetMall_Businesses().Where(p => p.IsSuggestion && p.IsShowOnHome && p.Status == 1).OrderBy(p => p.SortOrder).ThenByDescending(p => p.AddTime).Take(business_count).ToArray();
            var businessitems = business_list.Select(p =>
            {
                string imageurl = string.IsNullOrEmpty(p.CoverImage) ? "../image/error-img.png" : WebUtil.GetContextPath() + p.CoverImage;
                var item = new { id = p.ID, title = p.BusinessName, imageurl = imageurl };
                return item;
            });
            //热门消费
            var config_hotsale = config_list.FirstOrDefault(p => p.Name.Equals(SysConfigNameDefine.MallHomeHotSaleCount.ToString()));
            int hotsale_count = 10;
            if (config_hotsale != null)
            {
                int.TryParse(config_hotsale.Value, out hotsale_count);
                hotsale_count = hotsale_count > 0 ? hotsale_count : 6;
            }
            var hotsalelist = Mall_HotSaleDetail.GetMall_HotSaleList().Take(hotsale_count).ToList();
            var xiaoqu_items = new List<Dictionary<string, object>>();
            //我的小区
            if (uid > 0)
            {
                var xiaoqu_list = Foresight.DataAccess.Project.GetXiaoQuProjectListByAPPUserID(uid);
                xiaoqu_items = xiaoqu_list.Select(p =>
                {
                    var dic = new Dictionary<string, object>();
                    dic["id"] = p.ID;
                    dic["name"] = p.Name;
                    return dic;
                }).ToList();
            }
            string newcomingimgsrc = "";
            var rotate_img = Mall_RotatingImage.GetMall_RotatingImageListByType(14);
            if (rotate_img.Length > 0)
            {
                newcomingimgsrc = string.IsNullOrEmpty(rotate_img[0].ImagePath) ? string.Empty : WebUtil.GetContextPath() + rotate_img[0].ImagePath;
            }
            WebUtil.WriteJsonResult(context, new { notifylist = msgitems, newslist = newsitems, productlist = ziyingitems, pintuanlist = pintuanitems, businesslist = businessitems, hotsalelist = hotsalelist, xiaoqulist = xiaoqu_items, newcomingimgsrc = newcomingimgsrc });
        }
        private void gethouseservicedetail(HttpContext context)
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
        private void gethouseservicelist(HttpContext context)
        {
            var house_categories = Foresight.DataAccess.Wechat_HouseServiceCategory.GetWechat_HouseServiceCategories().Where(p => p.IsAPPCustomerShow).OrderBy(p => p.SortOrder).ToArray();
            var house_services = Foresight.DataAccess.Wechat_HouseService.GetWechat_HouseServices().Where(p => p.IsAPPCustomerShow).OrderBy(p => p.SortOrder).ToArray();
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
            sub_menus = new List<Dictionary<string, object>>();
            sub_dic = gethouseservice_wyfw("门禁钥匙", "../image/icons/menjin_icon_new.png", "mjys");
            sub_menus.Add(sub_dic);

            sub_dic = gethouseservice_wyfw("管家电话", "../image/icons/guanjiadianhua_icon.png", "gjsh");
            sub_menus.Add(sub_dic);

            sub_dic = gethouseservice_wyfw("报修服务", "../image/icons/baoxiufuwu_icon_new.png", "baoxiuservice_frm");
            sub_menus.Add(sub_dic);

            sub_dic = gethouseservice_wyfw("物业缴费", "../image/icons/wyejiaofei_icon_new.png", "wuyejf_frm");
            sub_menus.Add(sub_dic);

            sub_dic = gethouseservice_wyfw("生活缴费", "../image/icons/shenghuojiaofei_icon_new.png", "shjf");
            sub_menus.Add(sub_dic);

            sub_dic = gethouseservice_wyfw("物业公告", "../image/icons/wuyegonggao_icon_new.png", "sqgonggao_frm");
            sub_menus.Add(sub_dic);

            sub_dic = gethouseservice_wyfw("投诉建议", "../image/icons/tousujianyi_icon_new.png", "tousujianyi_frm");
            sub_menus.Add(sub_dic);

            dic = new Dictionary<string, object>();
            dic["id"] = 0;
            dic["title"] = "物业服务";
            dic["is_active"] = true;
            dic["coverimage"] = "../image/icons/wuyefuwu_icon.png";
            dic["coverimage_active"] = "../image/icons/wuyefuwu_icon_active.png";
            dic["sub_menus"] = sub_menus;
            menus.Insert(0, dic);
            WebUtil.WriteJsonResult(context, new { menus = menus });
        }
        private Dictionary<string, object> gethouseservice_wyfw(string title, string iconcss, string name)
        {
            var sub_dic = new Dictionary<string, object>();
            sub_dic["id"] = 0;
            sub_dic["title"] = title;
            sub_dic["iconcss"] = iconcss;
            sub_dic["name"] = name;
            return sub_dic;
        }
        private void closemyorder(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "id");
            var order = Foresight.DataAccess.Mall_Order.GetMall_Order(ID);
            order.IsClosed = true;
            order.CloseTime = DateTime.Now;
            order.CloseUserName = user.LoginName;
            order.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getmyshareorderanalysis(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int TotalCount = 0;
            decimal TotalCost = 0;
            int TotalPeople = 0;
            Mall_Order.GetShareOrderCount(user.UserID, out TotalCount, out TotalCost, out TotalPeople);
            WebUtil.WriteJsonResult(context, new { TotalCount = TotalCount, TotalCost = TotalCost, TotalPeople = TotalPeople });
        }
        private void getmyorderlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int status = WebUtil.GetIntValue(context, "status");
            bool isshareorder = WebUtil.GetBoolValue(context, "isshareorder");
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            long totals = 0;
            var order_list = Foresight.DataAccess.Mall_Order.GetMall_OrderListByStatus(status, startRowIndex, pageSize, out totals, UserID: uid, isshareorder: isshareorder);
            var order_items_list = Foresight.DataAccess.Mall_OrderItem.GetMall_OrderItemListByOrderIDList(order_list.Select(p => p.ID).ToList());
            List<int> ProductIDList = order_items_list.Where(p => p.ProductTypeID != 5 && p.ProductTypeID != 10).Select(p => p.ProductID).ToList();
            var product_list = Foresight.DataAccess.Mall_Product.GetMall_ProductListByIDList(ProductIDList);
            var business_list = Foresight.DataAccess.Mall_Business.GetMall_Businesses().ToArray();
            var houseservice_list = Foresight.DataAccess.Wechat_HouseService.GetWechat_HouseServices().ToArray();
            int refunt_min = 0;
            var paramconfig = Foresight.DataAccess.SysConfig.GetSysConfigByName(Foresight.DataAccess.SysConfigNameDefine.OrderRefundTime.ToString());
            List<int> HouseServiceIDList = order_items_list.Where(p => p.ProductTypeID == 5).Select(p => p.ProductID).ToList();
            var house_service_list = Wechat_HouseService.GetWechat_HouseServices().Where(p => HouseServiceIDList.Contains(p.ID)).ToArray();
            var house_service_category_list = Wechat_HouseServiceCategory.GetWechat_HouseServiceCategories().Where(p => p.ServiceType == 2).ToArray();
            if (paramconfig != null)
            {
                int.TryParse(paramconfig.Value, out refunt_min);
            }
            var items = order_list.Select(p =>
            {
                bool canpay = false;
                if (p.OrderStatus == 1 && !p.IsClosed)
                {
                    canpay = true;
                }
                bool canrate = false;
                if (p.OrderStatus == 3 && !p.IsClosed)
                {
                    canrate = true;
                }
                bool canrefund = false;
                if ((p.OrderStatus == 5 || p.OrderStatus == 2) && refunt_min > 0 && !p.IsClosed)
                {
                    if (DateTime.Now <= p.PayTime.AddMinutes(refunt_min))
                    {
                        canrefund = true;
                    }
                }
                bool canclose = false;
                if ((p.OrderStatus == 1 || p.OrderStatus == 7) && !p.IsClosed)
                {
                    canclose = true;
                }
                bool candelete = false;
                if (p.IsClosed)
                {
                    candelete = true;
                }
                bool canconfirmship = false;
                if (p.OrderStatus == 2 && !p.IsClosed)
                {
                    canconfirmship = true;
                }
                bool ispoint = p.TotalOrderPointCost > 0;
                int BusinessID = 0;
                int BusinessType = 0;
                string BusinessName = string.Empty;
                string BusinessImage = string.Empty;
                var my_order_items = order_items_list.Where(q => q.OrderID == p.ID).ToArray();
                string shipratename = string.Empty;
                decimal shiprateamount = p.ShipRateAmount > 0 ? p.ShipRateAmount : 0;
                var productlist = my_order_items.Select(q =>
                {
                    if (!string.IsNullOrEmpty(q.ShipRateTitle))
                    {
                        shipratename += q.ShipRateTitle + " ";
                    }
                    if (string.IsNullOrEmpty(BusinessName))
                    {
                        if (p.ProductTypeID == 10)
                        {
                            BusinessName = "物业缴费";
                            BusinessType = 2;
                        }
                        else if (p.ProductTypeID == 5)
                        {
                            BusinessName = "生活服务";
                            var my_house_service = house_service_list.FirstOrDefault(m => m.ID == q.ProductID);
                            if (my_house_service != null)
                            {
                                var my_house_service_category = house_service_category_list.FirstOrDefault(m => m.ID == my_house_service.CategoryID);
                                if (my_house_service_category != null)
                                {
                                    BusinessName = my_house_service_category.CategoryName;
                                    BusinessID = my_house_service_category.ID;
                                }
                            }
                            BusinessType = 3;
                        }
                        else if (q.BusinessID == 0)
                        {
                            BusinessName = "福顺自营";
                            BusinessType = 1;
                        }
                        else
                        {
                            BusinessType = 1;
                            var my_business = business_list.FirstOrDefault(m => m.ID == q.BusinessID);
                            BusinessName = my_business != null ? my_business.BusinessName : "";
                            BusinessImage = my_business != null ? my_business.CoverImage : "";
                            BusinessImage = string.IsNullOrEmpty(BusinessImage) ? "" : WebUtil.GetContextPath() + BusinessImage;
                            BusinessID = my_business != null ? my_business.ID : 0;
                        }
                    }
                    string imageurl = "../image/error-img.png";
                    if (p.ProductTypeID == 10)
                    {
                        imageurl = "../image/icons/wuyejiaofei_order.png";
                    }
                    else if (p.ProductTypeID == 5)
                    {
                        var my_houseservice = houseservice_list.FirstOrDefault(m => m.ID == q.ProductID);
                        if (my_houseservice != null)
                        {
                            imageurl = !string.IsNullOrEmpty(my_houseservice.IconLink) ? WebUtil.GetContextPath() + my_houseservice.IconLink : imageurl;
                        }
                    }
                    else
                    {
                        var my_product = product_list.FirstOrDefault(o => o.ID == q.ProductID);
                        if (my_product != null && !string.IsNullOrEmpty(my_product.CoverImage))
                        {
                            imageurl = WebUtil.GetContextPath() + my_product.CoverImage;
                        }
                    }
                    string price = q.PriceDesc;
                    var product_item = new { id = q.ID, productid = q.ProductID, variantid = q.VariantID, imageurl = imageurl, title = q.ProductTitle, desc = q.ProductSubTitle, price = price, quantity = "x" + q.Quantity.ToString(), producttypeid = q.ProductTypeID, orderid = q.OrderID, canrate = canrate };
                    return product_item;
                }).ToList();
                var productsummary = new { totaldesc = "共" + productlist.Count + "件商品", totalprice = p.TotalOrderCost, totalpoint = p.TotalOrderPointCost, shipratename = shipratename, shiprateamount = shiprateamount, totalpricedesc = p.TotalCostDesc };
                var ordersummary = new { id = p.ID, status = p.OrderStatus, ordernumber = p.OrderNumber, ordertime = p.AddTime.ToString("yyyy-MM-dd HH:mm:ss"), producttypeid = p.ProductTypeID, statusdesc = p.OrderStatusDesc, canrefund = canrefund, canclose = canclose, candelete = candelete, canpay = canpay, ispoint = ispoint, businessname = BusinessName, businessimage = BusinessImage, businesstype = BusinessType, businessid = BusinessID, shipratename = shipratename, shiprateamount = shiprateamount, canconfirmship = canconfirmship, ischecked = false, countdownday = "", countdown_timmer = 0, countdowndate = p.ShipTime.AddDays(3).ToString("yyyy-MM-dd HH:mm:ss"), leftTime = 0 };
                bool show_shiprate = true;
                if (p.ProductTypeID == 5 || p.ProductTypeID == 10)
                {
                    show_shiprate = false;
                }
                var item = new { productlist = productlist, productsummary = productsummary, ordersummary = ordersummary, show_shiprate = show_shiprate };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void getshoppingcartitemcount(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int total = Mall_ShoppingCart.GetTotalCount(uid);
            WebUtil.WriteJsonResult(context, new { total = total });
        }
        private void createcartorder(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int addressid = WebUtil.GetIntValue(context, "addressid");
            Foresight.DataAccess.Mall_Address mall_address = null;
            if (addressid > 0)
            {
                mall_address = Foresight.DataAccess.Mall_Address.GetMall_Address(addressid);
            }
            if (mall_address == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请选择收货地址");
            }
            List<int> cartidlist = JsonConvert.DeserializeObject<List<int>>(context.Request["cartidlist"]);
            var cart_list = Foresight.DataAccess.Mall_ShoppingCart.GetMall_ShoppingCartListByIDList(cartidlist, uid);
            var product_list = Foresight.DataAccess.Mall_Product.GetMall_ProductListByIDList(cart_list.Select(p => p.ProductID).ToList());
            var variant_list = Foresight.DataAccess.Mall_Product_VariantDetail.GetMall_Product_VariantDetailListByIDList(cart_list.Select(p => p.VariantID).ToList());
            List<Model.CartOrderModel> orderlist = new List<Model.CartOrderModel>();
            var business_list = Foresight.DataAccess.Mall_Business.GetMall_BusinessListByIDList(product_list.Select(p => p.BusinessID).ToList());
            string dataforms = context.Request["formlist"];
            List<Dictionary<string, object>> data_list = new List<Dictionary<string, object>>();
            if (!string.IsNullOrEmpty(dataforms))
            {
                data_list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(dataforms);
            }
            List<Mall_CouponUser> coupon_user_list = new List<Mall_CouponUser>();
            foreach (var business in business_list)
            {
                Dictionary<string, object> couponform = null;
                Dictionary<string, object> shiprateform = null;
                string user_note = string.Empty;
                foreach (var item in data_list)
                {
                    int businessid = 0;
                    int.TryParse(item["businessid"].ToString(), out businessid);
                    if (businessid == business.ID)
                    {
                        couponform = JsonConvert.DeserializeObject<Dictionary<string, object>>(item["couponform"].ToString());
                        shiprateform = JsonConvert.DeserializeObject<Dictionary<string, object>>(item["shiprateform"].ToString());
                        user_note = item["user_note"].ToString();
                        break;
                    }
                }
                int CouponID = 0;
                decimal CouponAmount = 0;
                int CouponUserID = 0;
                if (couponform != null)
                {
                    int.TryParse(couponform["couponid"].ToString(), out CouponID);
                    decimal.TryParse(couponform["price"].ToString(), out CouponAmount);
                    int.TryParse(couponform["id"].ToString(), out CouponUserID);
                }
                int ShipRateID = 0;
                string ShipRateTitle = string.Empty;
                decimal ShipRateAmount = 0;
                int ShipRateType = 0;
                if (shiprateform != null)
                {
                    int.TryParse(shiprateform["id"].ToString(), out ShipRateID);
                    ShipRateTitle = shiprateform["name"].ToString();
                    decimal.TryParse(shiprateform["amount"].ToString(), out ShipRateAmount);
                    int.TryParse(shiprateform["RateType"].ToString(), out ShipRateType);
                }
                var data = APPCode.CommHelper.getmallorderitems(cart_list, product_list, variant_list, user, user_note, business.ID, AddressProvinceID: mall_address.AddressProvinceID, UserID: uid);
                data.order.CouponID = CouponID;
                data.order.CouponAmount = CouponAmount;
                data.order.CouponUserID = CouponUserID;
                data.order.ShipRateID = ShipRateID;
                data.order.ShipRateName = ShipRateTitle;
                data.order.ShipRateAmount = ShipRateAmount;
                data.order.ShipCompanyName = ShipRateTitle;
                orderlist.Add(data);
                Mall_CouponUser coupon_user = null;
                if (CouponUserID > 0)
                {
                    coupon_user = Mall_CouponUser.GetMall_CouponUser(CouponUserID);
                }
                if (coupon_user != null)
                {
                    coupon_user.IsUsed = true;
                    coupon_user.UseTime = DateTime.Now;
                    coupon_user.UseType = 1;
                    coupon_user_list.Add(coupon_user);
                }
            }
            var self_products = product_list.Where(p => p.IsZiYing).ToArray();
            if (self_products.Length > 0)
            {
                Dictionary<string, object> couponform = null;
                Dictionary<string, object> shiprateform = null;
                string user_note = string.Empty;
                foreach (var item in data_list)
                {
                    int businessid = 0;
                    int.TryParse(item["businessid"].ToString(), out businessid);
                    if (businessid == 0)
                    {
                        couponform = JsonConvert.DeserializeObject<Dictionary<string, object>>(item["couponform"].ToString());
                        shiprateform = JsonConvert.DeserializeObject<Dictionary<string, object>>(item["shiprateform"].ToString());
                        user_note = item["user_note"].ToString();
                        break;
                    }
                }
                int CouponID = 0;
                decimal CouponAmount = 0;
                int CouponUserID = 0;
                if (couponform != null)
                {
                    int.TryParse(couponform["couponid"].ToString(), out CouponID);
                    decimal.TryParse(couponform["price"].ToString(), out CouponAmount);
                    int.TryParse(couponform["id"].ToString(), out CouponUserID);
                }
                int ShipRateID = 0;
                string ShipRateTitle = string.Empty;
                decimal ShipRateAmount = 0;
                int ShipRateType = 0;
                if (shiprateform != null)
                {
                    int.TryParse(shiprateform["id"].ToString(), out ShipRateID);
                    ShipRateTitle = shiprateform["name"].ToString();
                    decimal.TryParse(shiprateform["amount"].ToString(), out ShipRateAmount);
                    int.TryParse(shiprateform["RateType"].ToString(), out ShipRateType);
                }
                var cartitem = new Dictionary<string, object>();
                var data = APPCode.CommHelper.getmallorderitems(cart_list, product_list, variant_list, user, user_note, 0, AddressProvinceID: mall_address.AddressProvinceID, UserID: uid);
                data.order.CouponID = CouponID;
                data.order.CouponAmount = CouponAmount;
                data.order.CouponUserID = CouponUserID;
                data.order.ShipRateID = ShipRateID;
                data.order.ShipRateName = ShipRateTitle;
                data.order.ShipRateAmount = ShipRateAmount;
                data.order.ShipCompanyName = ShipRateTitle;
                orderlist.Insert(0, data);
                Mall_CouponUser coupon_user = null;
                if (CouponUserID > 0)
                {
                    coupon_user = Mall_CouponUser.GetMall_CouponUser(CouponUserID);
                }
                if (coupon_user != null)
                {
                    coupon_user.IsUsed = true;
                    coupon_user.UseTime = DateTime.Now;
                    coupon_user.UseType = 1;
                    coupon_user_list.Add(coupon_user);
                }
            }
            List<int> orderid_list = new List<int>();
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in orderlist)
                    {
                        if (mall_address != null)
                        {
                            item.order.AddressID = mall_address.ID;
                            item.order.AddressUserName = mall_address.AddressUserName;
                            item.order.AddressPhoneNumber = mall_address.AddressPhoneNo;
                            item.order.AddressProvince = mall_address.AddressProvice;
                            item.order.AddressCity = mall_address.AddressCity;
                            item.order.AddressDistrict = mall_address.AddressDistrict;
                            item.order.AddressDetailInfo = mall_address.AddressDetailInfo;
                            item.order.AddressProjectID = mall_address.ProjectID;
                            item.order.AddressRoomID = mall_address.RoomID;
                        }
                        item.order.Save(helper);
                        foreach (var orderitem in item.OrderItemList)
                        {
                            orderitem.OrderID = item.order.ID;
                            orderitem.Save(helper);
                        }
                        orderid_list.Add(item.order.ID);
                    }
                    foreach (var item in cart_list)
                    {
                        item.Delete(helper);
                    }
                    foreach (var item in coupon_user_list)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "createcartorder", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "内部异常");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, new { idlist = orderid_list });
            return;
        }
        private void removemyaddress(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int id = WebUtil.GetIntValue(context, "id");
            Mall_Address.DeleteMall_Address(id);
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getmyaddressdetail(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int id = WebUtil.GetIntValue(context, "id");
            var data = Mall_Address.GetMall_Address(id);
            bool isroomaddress = data.ProjectID > 0;
            var form = new { id = data.ID, username = data.AddressUserName, phonenumber = data.AddressPhoneNo, addressdetail = data.AddressDetailInfo, province = data.AddressProvice, city = data.AddressCity, district = data.AddressDistrict, isdefault = data.IsDefault, isroomaddress = isroomaddress, xiaoquid = data.ProjectID > 0 ? data.ProjectID : 0, xiaoquname = data.ProjectName, roomname = data.AddressDetailInfo, roomid = data.RoomID > 0 ? data.RoomID : 0, ProjectFullName = data.ProjectFullName, provinceID = data.AddressProvinceID > 0 ? data.AddressProvinceID : 0 };
            WebUtil.WriteJsonResult(context, new { form = form });
        }
        private void getmyaddresslist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            Mall_Address.GetDefaultAddress(uid, UserID: user.UserID, LoginName: user.LoginName);
            var list = Foresight.DataAccess.Mall_Address.GetMall_AddressListByUserID(uid, user.UserID);
            var items = list.Select(p =>
            {
                string address = p.AddressProvice + p.AddressCity + p.AddressDistrict + p.AddressDetailInfo;
                var item = new { id = p.ID, name = p.AddressUserName, phone = p.AddressPhoneNo, address = address, isdefault = p.IsDefault, IsRelationAddress = p.IsRelationAddress };
                return item;
            });
            bool canaddaddress = false;
            var sysconfig = Foresight.DataAccess.SysConfig.GetSysConfigByName(SysConfigNameDefine.AllowDefineAddress.ToString());
            if (sysconfig != null && sysconfig.Value.Equals("1"))
            {
                canaddaddress = true;
            }
            WebUtil.WriteJsonResult(context, new { list = items, canaddaddress = canaddaddress });
        }
        private void savemyaddressinfo(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int id = WebUtil.GetIntValue(context, "id");
            Foresight.DataAccess.Mall_Address data = null;
            if (id > 0)
            {
                data = Mall_Address.GetMall_Address(id);
            }
            if (data == null)
            {
                data = new Mall_Address();
                data.AddTime = DateTime.Now;
                data.AddUser = user.LoginName;
                data.UserID = uid;
            }
            data.AddressUserName = context.Request["username"];
            data.AddressPhoneNo = context.Request["phonenumber"];
            int xiaoquid = WebUtil.GetIntValue(context, "xiaoquid");
            int roomid = WebUtil.GetIntValue(context, "roomid");
            data.ProjectID = xiaoquid;
            data.RoomID = roomid;
            Foresight.DataAccess.Project project = null;
            Foresight.DataAccess.Project room = null;
            if (xiaoquid > 0)
            {
                project = Foresight.DataAccess.Project.GetProject(xiaoquid);
            }
            if (roomid > 0)
            {
                room = Foresight.DataAccess.Project.GetProject(roomid);
            }
            if (project != null && room != null)
            {
                data.AddressProvice = project.AddressProvice;
                data.AddressCity = project.AddressCity;
                data.AddressDistrict = project.AddressDistrict;
                data.AddressDetailInfo = room.FullName + "-" + room.Name;
                data.ProjectFullName = room.FullName;
                data.RoomName = room.Name;
                data.ProjectName = project.Name;
                data.AddressProvinceID = project.AddressProvinceID;
            }
            else
            {
                data.AddressProvice = context.Request["province"];
                data.AddressCity = context.Request["city"];
                data.AddressDistrict = context.Request["district"];
                data.AddressDetailInfo = context.Request["addressdetail"];
                data.AddressProvinceID = WebUtil.GetIntValue(context, "provinceID");
            }
            bool IsDefault = false;
            bool.TryParse(context.Request["isdefault"], out IsDefault);
            data.IsDefault = IsDefault;

            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.IsDefault = IsDefault;
                    data.Save(helper);
                    if (IsDefault)
                    {
                        string cmdtext = "update Mall_Address set [IsDefault]=0 where [UserID]=@UserID and ID!=@ID";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@UserID", uid));
                        parameters.Add(new SqlParameter("@ID", data.ID));
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, new { id = data.ID });
        }
        private void getmyshipaddressinfo(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            Foresight.DataAccess.Mall_Address default_address = null;
            string addressdetail = string.Empty;
            int id = WebUtil.GetIntValue(context, "id");
            if (id > 0)
            {
                default_address = Mall_Address.GetMall_Address(id);
            }
            else
            {
                default_address = Mall_Address.GetDefaultAddress(uid, UserID: user.UserID, LoginName: user.LoginName);
            }
            if (default_address == null)
            {
                WebUtil.WriteJsonResult(context, new { noaddress = true });
                return;
            }
            int quantity = WebUtil.GetIntValue(context, "quantity");
            int productid = WebUtil.GetIntValue(context, "productid");
            int orderid = WebUtil.GetIntValue(context, "orderid");
            string cartidlist = context.Request["cartidlist"];
            List<int> CartIDList = new List<int>();
            if (!string.IsNullOrEmpty(cartidlist))
            {
                CartIDList = JsonConvert.DeserializeObject<List<int>>(cartidlist);
            }
            List<Dictionary<string, object>> shipratelist = new List<Dictionary<string, object>>();
            Mall_ShipRateDetail.GetMall_ShipRateDetailByCardIDList(productid, CartIDList, orderid, out shipratelist, ProvinceID: default_address.AddressProvinceID, Quantity: quantity, UserID: uid);
            addressdetail = default_address.AddressProvice + default_address.AddressCity + default_address.AddressDistrict + default_address.AddressDetailInfo;

            WebUtil.WriteJsonResult(context, new { noaddress = false, myaddress = new { id = default_address.ID, username = default_address.AddressUserName, phonenumber = default_address.AddressPhoneNo, addressdetail = addressdetail }, shipratelist = shipratelist });
        }
        private void getmyaddressshiprate(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int quantity = WebUtil.GetIntValue(context, "quantity");
            int productid = WebUtil.GetIntValue(context, "productid");
            int orderid = WebUtil.GetIntValue(context, "orderid");
            string cartidlist = context.Request["cartidlist"];
            int AddressProvinceID = WebUtil.GetIntValue(context, "provinceid");
            List<int> CartIDList = new List<int>();
            if (!string.IsNullOrEmpty(cartidlist))
            {
                CartIDList = JsonConvert.DeserializeObject<List<int>>(cartidlist);
            }
            string RateTitle = string.Empty;
            decimal RateAmount = 0;
            int RateID = 0;
            int RateType = 0;
            Mall_ShipRateDetail.GetMall_ShipRateDetailByKeywords(productid, CartIDList, orderid, out RateTitle, out RateAmount, out RateID, out RateType, ProvinceID: AddressProvinceID, Quantity: quantity, UserID: uid);

            WebUtil.WriteJsonResult(context, new { shiprate = new { name = RateTitle, amountdesc = "￥" + RateAmount.ToString("0.00"), amount = RateAmount } });
        }
        private void updateshoppingcartquantity(HttpContext context)
        {
            int id = WebUtil.GetIntValue(context, "id");
            var data = Foresight.DataAccess.Mall_ShoppingCart.GetMall_ShoppingCart(id);
            data.Quantity = WebUtil.GetIntValue(context, "quantity");
            data.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getshoppingcartorderlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["cartidlist"]);
            var cart_list = Foresight.DataAccess.Mall_ShoppingCart.GetMall_ShoppingCartListByIDList(IDList, uid);
            var product_list = Foresight.DataAccess.Mall_ProductDetail.GetMall_ProductDetailListByIDList(cart_list.Select(p => p.ProductID).ToList());
            var variant_list = Foresight.DataAccess.Mall_Product_VariantDetail.GetMall_Product_VariantDetailListByIDList(cart_list.Select(p => p.VariantID).ToList());
            List<Dictionary<string, object>> cartlist = new List<Dictionary<string, object>>();
            var business_list = Foresight.DataAccess.Mall_Business.GetMall_BusinessListByIDList(product_list.Select(p => p.BusinessID).ToList());
            decimal ordertotalprice = 0;
            int ordertotalsalepoint = 0;
            foreach (var business in business_list)
            {
                var cartitem = new Dictionary<string, object>();
                string businessimage = string.IsNullOrEmpty(business.CoverImage) ? "" : WebUtil.GetContextPath() + business.CoverImage;
                cartitem["business"] = new { name = business.BusinessName, id = business.ID, businessimage = businessimage };
                decimal totalprice = 0;
                int totalsalepoint = 0;
                string totalpricedesc = string.Empty;
                var productlist = APPCode.CommHelper.getshoppingcartitems(cart_list, product_list, variant_list, business.ID, out totalprice, out totalsalepoint, out totalpricedesc);
                cartitem["productlist"] = productlist;
                var productsummary = new { totaldesc = "共" + productlist.Count.ToString() + "项", totalprice = totalprice, totalpricedesc = totalpricedesc };
                cartitem["productsummary"] = productsummary;
                cartitem["shiprate"] = new { name = "", amountdesc = "" };
                cartitem["shipratelist"] = new List<object>();
                int[] ProductIDList = productlist.Select(p =>
                {
                    int ProductID = 0;
                    int.TryParse(p["productid"].ToString(), out ProductID);
                    return ProductID;
                }).ToArray();
                var couponlist = new List<Dictionary<string, object>>();
                var allcouponlist = Mall_CouponUserDetail.GetOrderMall_CouponUserDicList(totalprice, business.ID, uid, out couponlist, ProductIDList: ProductIDList);
                cartitem["couponlist"] = couponlist;
                cartitem["allcouponlist"] = allcouponlist;
                string currentcouponname = "无";
                if (couponlist.Count > 0)
                {
                    currentcouponname = "请选择";
                }
                cartitem["couponform"] = new { text = currentcouponname, id = 0, couponid = 0, price = 0, pricedesc = "" };
                cartitem["user_note"] = string.Empty;
                cartlist.Add(cartitem);
                ordertotalprice += totalprice;
                ordertotalsalepoint += totalsalepoint;
            }
            var self_products = product_list.Where(p => p.IsZiYing).ToArray();
            if (self_products.Length > 0)
            {
                var cartitem = new Dictionary<string, object>();
                cartitem["business"] = new { name = "福顺优选", id = 0, businessimage = "" };
                decimal totalprice = 0;
                int totalsalepoint = 0;
                string totalpricedesc = string.Empty;
                var productlist = APPCode.CommHelper.getshoppingcartitems(cart_list, product_list, variant_list, 0, out totalprice, out totalsalepoint, out totalpricedesc);
                cartitem["productlist"] = productlist;
                var productsummary = new { totaldesc = "共" + productlist.Count.ToString() + "项", totalprice = totalprice, totalpricedesc = totalpricedesc };
                cartitem["productsummary"] = productsummary;
                cartitem["shiprate"] = new { name = "", amountdesc = "" };
                cartitem["shipratelist"] = new List<object>();
                int[] ProductIDList = productlist.Select(p =>
                {
                    int ProductID = 0;
                    int.TryParse(p["productid"].ToString(), out ProductID);
                    return ProductID;
                }).ToArray();
                var couponlist = new List<Dictionary<string, object>>();
                var allcouponlist = Mall_CouponUserDetail.GetOrderMall_CouponUserDicList(totalprice, 0, uid, out couponlist, ProductIDList: ProductIDList);
                cartitem["couponlist"] = couponlist;
                cartitem["allcouponlist"] = allcouponlist;
                string currentcouponname = "无";
                if (couponlist.Count > 0)
                {
                    currentcouponname = "请选择";
                }
                cartitem["couponform"] = new { text = currentcouponname, id = 0, couponid = 0, price = 0, pricedesc = "" };
                cartitem["user_note"] = string.Empty;
                cartlist.Insert(0, cartitem);
                ordertotalprice += totalprice;
                ordertotalsalepoint += totalsalepoint;
            }
            if (cartlist.Count == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有相关商品");
                return;
            }
            var ordersummary = new { totalprice = ordertotalprice, totalsalepoint = ordertotalsalepoint };
            var ship_rate_list = Mall_ShipRate.GetMall_ShipRateListByIDList(product_list.Where(p => p.ShipRateID > 0).Select(p => p.ShipRateID).ToList()).ToArray();
            bool show_address = true;
            if (ship_rate_list.Length > 0)
            {
                var my_ship_rate_list = ship_rate_list.Where(p => p.RateType == 1).ToArray();
                show_address = my_ship_rate_list.Length > 0;
            }
            WebUtil.WriteJsonResult(context, new { cartlist = cartlist, ordersummary = ordersummary, show_address = show_address });
        }
        private void removeshoppingcart(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int id = WebUtil.GetIntValue(context, "id");
            if (id > 0)
            {
                Foresight.DataAccess.Mall_ShoppingCart.DeleteMall_ShoppingCart(id);
            }
            string ids = context.Request["ids"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(ids))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            }
            if (IDList.Count > 0)
            {
                Mall_ShoppingCart.DeleteMall_ShoppingCartListByIDList(IDList);
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getshoppingcartlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var list = Foresight.DataAccess.Mall_ShoppingCart.GetMall_ShoppingCartListByUserID(uid);
            var productid_list = list.Select(p => p.ProductID).ToList();
            var products = Foresight.DataAccess.Mall_ProductDetail.GetMall_ProductDetailListByIDList(productid_list).Where(p => p.Status == 10).ToArray();
            var variantid_list = list.Select(p => p.VariantID).ToList();
            var product_variants = Foresight.DataAccess.Mall_Product_VariantDetail.GetMall_Product_VariantDetailListByIDList(variantid_list);
            List<Dictionary<string, object>> cartlist = new List<Dictionary<string, object>>();
            var business_list = Foresight.DataAccess.Mall_Business.GetMall_BusinessListByIDList(products.Select(p => p.BusinessID).ToList());
            decimal ordertotalprice = 0;
            int ordertotalsalepoint = 0;
            foreach (var business in business_list)
            {
                var cartitem = new Dictionary<string, object>();
                cartitem["business"] = new { name = business.BusinessName, id = business.ID, ischecked = false };
                decimal totalprice = 0;
                int totalsalepoint = 0;
                string totalpricedesc = string.Empty;
                var productlist = APPCode.CommHelper.getshoppingcartitems(list, products, product_variants, business.ID, out totalprice, out totalsalepoint, out totalpricedesc);
                cartitem["productlist"] = productlist;
                var productsummary = new { totaldesc = "共" + productlist.Count.ToString() + "项", totalprice = totalprice };
                cartitem["productsummary"] = productsummary;
                cartlist.Add(cartitem);
                ordertotalprice += totalprice;
                ordertotalsalepoint += totalsalepoint;
            }
            var self_products = products.Where(p => p.IsZiYing).ToArray();
            if (self_products.Length > 0)
            {
                var cartitem = new Dictionary<string, object>();
                cartitem["business"] = new { name = "自营商品", id = 0, ischecked = false };
                decimal totalprice = 0;
                int totalsalepoint = 0;
                string totalpricedesc = string.Empty;
                var productlist = APPCode.CommHelper.getshoppingcartitems(list, products, product_variants, 0, out totalprice, out totalsalepoint, out totalpricedesc);
                cartitem["productlist"] = productlist;
                var productsummary = new { totaldesc = "共" + productlist.Count.ToString() + "项", totalprice = totalprice };
                cartitem["productsummary"] = productsummary;
                cartlist.Insert(0, cartitem);
                ordertotalprice += totalprice;
                ordertotalsalepoint += totalsalepoint;
            }
            string ordertotalpricedesc = string.Empty;
            if (ordertotalprice > 0 && ordertotalsalepoint > 0)
            {
                ordertotalpricedesc = "￥" + ordertotalprice.ToString("0.00") + " + " + ordertotalsalepoint.ToString() + "积分";
            }
            else if (ordertotalprice > 0)
            {
                ordertotalpricedesc = "￥" + ordertotalprice.ToString("0.00");
            }
            else if (ordertotalsalepoint > 0)
            {
                ordertotalpricedesc = ordertotalsalepoint.ToString() + "积分";
            }
            var ordersummary = new { totalprice = ordertotalprice, totalsalepoint = ordertotalsalepoint, totalpricedesc = ordertotalpricedesc };
            WebUtil.WriteJsonResult(context, new { cartlist = cartlist, ordersummary = ordersummary });
        }
        private void addproducttocart(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int quantity = WebUtil.GetIntValue(context, "quantity");
            int productid = WebUtil.GetIntValue(context, "productid");
            int variantid = WebUtil.GetIntValue(context, "variantid");
            int type = WebUtil.GetIntValue(context, "type");
            var product = Foresight.DataAccess.Mall_Product.GetMall_Product(productid);
            type = Mall_Product.GetFinalProductOrderType(type, product.ProductOrderType);
            Foresight.DataAccess.Mall_Product_VariantDetail product_variant = null;
            if (variantid > 0)
            {
                product_variant = Foresight.DataAccess.Mall_Product_VariantDetail.GetMall_Product_VariantDetailByID(variantid);
            }
            decimal price = product.SalePrice;
            string VariantTitle = string.Empty;
            string VariantName = string.Empty;
            if (product_variant != null)
            {
                price = product_variant.FinalVariantPrice;
                VariantTitle = product_variant.FinalVariantTitle;
                VariantName = product_variant.VariantName;
            }
            var cart = Foresight.DataAccess.Mall_ShoppingCart.GetMall_ShoppingCartByProductID(productid, variantid, uid, type);
            if (cart == null)
            {
                cart = new Mall_ShoppingCart();
                cart.AddTime = DateTime.Now;
                cart.AddMan = user.LoginName;
                cart.UserID = uid;
                cart.Quantity = 0;
            }
            if (cart.Quantity >= product.QuantityLimit && product.QuantityLimit > 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "此商品限购" + product.QuantityLimit + "个");
                return;
            }
            cart.ProductOrderType = type;
            cart.ProductID = product.ID;
            cart.ProductName = product.ProductName;
            cart.VariantID = variantid;
            cart.VariantTitle = VariantTitle;
            cart.VariantName = VariantName;
            cart.SalePrice = price;
            cart.Quantity = cart.Quantity + quantity;
            cart.TotalPrice = cart.SalePrice * cart.Quantity;
            cart.Save();
            int total = Mall_ShoppingCart.GetTotalCount(uid);
            WebUtil.WriteJsonResult(context, new { total = total });
        }
        private void createproductorder(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int quantity = WebUtil.GetIntValue(context, "quantity");
            int productid = WebUtil.GetIntValue(context, "productid");
            int variantid = WebUtil.GetIntValue(context, "variantid");
            int type = WebUtil.GetIntValue(context, "type");
            var product = Foresight.DataAccess.Mall_Product.GetMall_Product(productid);
            type = Mall_Product.GetFinalProductOrderType(type, product.ProductOrderType);
            Foresight.DataAccess.Mall_Product_VariantDetail product_variant = null;
            if (variantid > 0)
            {
                product_variant = Foresight.DataAccess.Mall_Product_VariantDetail.GetMall_Product_VariantDetailByID(variantid);
            }
            bool isshareorder = false;
            if (context.Request["isshareorder"] != null)
            {
                bool.TryParse(context.Request["isshareorder"], out isshareorder);
            }
            Foresight.DataAccess.Mall_Address mall_address = null;
            Foresight.DataAccess.User share_user = null;
            if (isshareorder)
            {
                string phonenumber = context.Request["phonenumber"];
                if (string.IsNullOrEmpty(phonenumber))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "地址电话不能为空");
                    return;
                }
                string verifycode = context.Request["verifycode"];
                var wechatVerifyCode = Wechat_VerifyCode.GetWechat_VerifyCodeByUserOpenId(string.Empty, phonenumber, DateTime.Now);
                if (wechatVerifyCode == null || !wechatVerifyCode.VerifyCode.Equals(verifycode))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "验证码不正确");
                    return;
                }
                mall_address = new Mall_Address();
                mall_address.AddressUserName = context.Request["username"];
                mall_address.AddressPhoneNo = context.Request["phonenumber"];
                mall_address.AddressProvinceID = WebUtil.GetIntValue(context, "provinceid");
                mall_address.AddressProvice = context.Request["province"];
                mall_address.AddressCity = context.Request["city"];
                mall_address.AddressDistrict = context.Request["district"];
                mall_address.AddressDetailInfo = context.Request["street"];
                mall_address.AddTime = DateTime.Now;
                mall_address.IsDefault = true;
                share_user = Foresight.DataAccess.User.GetAPPUserByLoginName(mall_address.AddressPhoneNo);
                if (share_user == null)
                {
                    share_user = new Foresight.DataAccess.User();
                    share_user.CreateTime = DateTime.Now;
                    share_user.LoginName = mall_address.AddressPhoneNo;
                    share_user.PhoneNumber = mall_address.AddressPhoneNo;
                    share_user.Type = UserTypeDefine.APPCustomerShare.ToString();
                    share_user.IsLocked = false;
                    share_user.FromUserID = uid;
                }
            }
            else
            {
                int addressid = WebUtil.GetIntValue(context, "addressid");
                if (addressid > 0)
                {
                    mall_address = Foresight.DataAccess.Mall_Address.GetMall_Address(addressid);
                }
                if (mall_address == null)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请选择收货地址");
                }
            }

            string VariantTitle = string.Empty;
            string VariantName = string.Empty;
            if (product_variant != null)
            {
                VariantTitle = product_variant.FinalVariantTitle;
                VariantName = product_variant.VariantName;
            }
            decimal price = 0;
            int salepoint = 0;
            bool isallowproductsale = false;
            bool isallowpointsale = false;
            bool isallowvipsale = false;
            bool isallowstaffsale = false;
            string totalpricedesc = string.Empty;
            string pricedesc = Mall_Product.GetOrderItemPriceDesc(product, product_variant, quantity, out price, out salepoint, out isallowproductsale, out isallowpointsale, out isallowvipsale, out isallowstaffsale, out totalpricedesc, ProductOrderType: type);
            Foresight.DataAccess.Mall_Order order = new Mall_Order();
            List<Mall_OrderItem> orderitems = new List<Mall_OrderItem>();
            order.BusinessID = product.BusinessID;
            order.AddTime = DateTime.Now;
            order.AddUser = user.LoginName;
            order.OrderNumber = Mall_Order.GetLastestOrderNumber();
            order.OrderType = 1;
            order.TotalCost = price * quantity;
            order.TotalSalePoint = 0;
            order.TotalVIPSalePoint = 0;
            order.TotalSaleStaffPoint = 0;
            if (type == 17)
            {
                order.TotalSalePoint = salepoint * quantity;
            }
            else if (type == 18)
            {
                order.TotalVIPSalePoint = salepoint * quantity;
            }
            else if (type == 25)
            {
                order.TotalSaleStaffPoint = salepoint * quantity;
            }
            order.OriginalTotalCost = order.TotalCost;
            order.OrderStatus = 1;
            order.UserID = uid;
            order.UserName = user.LoginName;
            order.UserNote = context.Request["user_note"];
            order.ProductTypeID = product.ProductTypeID;
            order.CouponID = WebUtil.GetIntValue(context, "couponid");
            order.CouponAmount = WebUtil.GetDecimalValue(context, "couponprice");
            order.CouponUserID = WebUtil.GetIntValue(context, "couponuserid");
            string ShipRateTitle = context.Request["shipratename"];
            decimal ShipRateAmount = WebUtil.GetDecimalValue(context, "shiprateamount");
            int ShipRateID = WebUtil.GetIntValue(context, "shiprateid");
            int ShipRateType = WebUtil.GetIntValue(context, "shipratetype");
            order.ShipRateID = ShipRateID;
            order.ShipRateName = ShipRateTitle;
            order.ShipRateAmount = ShipRateAmount;
            order.ShipCompanyName = ShipRateTitle;
            if (mall_address != null)
            {
                order.AddressID = mall_address.ID > 0 ? mall_address.ID : 0;
                order.AddressUserName = mall_address.AddressUserName;
                order.AddressPhoneNumber = mall_address.AddressPhoneNo;
                order.AddressProvinceID = mall_address.AddressProvinceID;
                order.AddressProvince = mall_address.AddressProvice;
                order.AddressCity = mall_address.AddressCity;
                order.AddressDistrict = mall_address.AddressDistrict;
                order.AddressDetailInfo = mall_address.AddressDetailInfo;
                order.AddressProjectID = mall_address.ProjectID > 0 ? mall_address.ProjectID : 0;
                order.AddressRoomID = mall_address.RoomID > 0 ? mall_address.RoomID : 0;
            }
            var order_item = new Mall_OrderItem();
            order_item.IsDiscountPrice = product_variant.IsDiscountEnable;
            order_item.AddTime = order.AddTime;
            order_item.AddMan = order.AddUser;
            order_item.ProductID = product.ID;
            order_item.ProductName = product.ProductName;
            order_item.VariantID = variantid;
            order_item.VariantTitle = VariantTitle;
            order_item.VariantName = VariantName;
            order_item.Price = price;
            order_item.Quantity = quantity;
            order_item.TotalPrice = price * quantity;
            order_item.TotalSalePoint = 0;
            order_item.SalePoint = 0;
            order_item.StaffPoint = 0;
            order_item.TotalStaffPoint = 0;
            if (type == 17)
            {
                order_item.TotalSalePoint = salepoint * quantity;
                order_item.SalePoint = salepoint;
            }
            else if (type == 18)
            {
                order_item.VIPTotalSalePoint = salepoint * quantity;
                order_item.VIPSalePoint = salepoint;
            }
            else if (type == 25)
            {
                order_item.TotalStaffPoint = salepoint * quantity;
                order_item.StaffPoint = salepoint;
            }
            order_item.BusinessID = product.BusinessID;
            order_item.ProductTypeID = product.ProductTypeID;
            order_item.ShipRateTitle = ShipRateTitle;
            order_item.ShipRateID = ShipRateID;
            order_item.ShipRateAmount = ShipRateAmount;
            order_item.ShipRateType = ShipRateType;
            order_item.ProductBuyType = type;
            var mall_business = Foresight.DataAccess.Mall_Business.GetMall_Business(product.BusinessID);
            order_item.BusinessName = mall_business != null ? mall_business.BusinessName : string.Empty;
            orderitems.Add(order_item);
            int orderid = 0;
            Mall_CouponUser coupon_user = null;
            if (order.CouponUserID > 0)
            {
                coupon_user = Mall_CouponUser.GetMall_CouponUser(order.CouponUserID);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    if (isshareorder)
                    {
                        if (share_user != null)
                        {
                            share_user.Save(helper);
                            order.UserID = share_user.UserID;
                        }
                        if (mall_address != null)
                        {
                            mall_address.AddUser = share_user.LoginName;
                            mall_address.UserID = share_user.UserID;
                            mall_address.Save(helper);
                        }
                        order.ShareUserID = uid;
                        order.IsShareOrder = true;
                    }
                    if (mall_address != null)
                    {
                        order.AddressID = mall_address.ID;
                    }
                    order.Save(helper);
                    foreach (var item in orderitems)
                    {
                        item.OrderID = order.ID;
                        item.Save(helper);
                    }
                    orderid = order.ID;
                    if (coupon_user != null)
                    {
                        coupon_user.IsUsed = true;
                        coupon_user.UseTime = DateTime.Now;
                        coupon_user.UseType = 1;
                        coupon_user.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "createproductorder", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "内部异常");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, new { id = orderid });
        }
        private void getproductorderlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int quantity = WebUtil.GetIntValue(context, "quantity");
            int productid = WebUtil.GetIntValue(context, "productid");
            int variantid = WebUtil.GetIntValue(context, "variantid");
            int type = WebUtil.GetIntValue(context, "type");
            var product = Foresight.DataAccess.Mall_Product.GetMall_Product(productid);
            Foresight.DataAccess.Mall_Product_VariantDetail product_variant = null;
            if (variantid > 0)
            {
                product_variant = Foresight.DataAccess.Mall_Product_VariantDetail.GetMall_Product_VariantDetailByID(variantid);
            }
            type = Mall_Product.GetFinalProductOrderType(type, product.ProductOrderType);
            List<Dictionary<string, object>> productlist = new List<Dictionary<string, object>>();
            decimal price = 0;
            int salepoint = 0;
            bool isallowproductsale = false;
            bool isallowpointsale = false;
            bool isallowvipsale = false;
            bool isallowstaffsale = false;
            string totalpricedesc = string.Empty;
            string pricedesc = Mall_Product.GetOrderItemPriceDesc(product, product_variant, quantity, out price, out salepoint, out isallowproductsale, out isallowpointsale, out isallowvipsale, out isallowstaffsale, out totalpricedesc, ProductOrderType: type);
            string desc = string.Empty;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (product_variant != null)
            {
                desc = product_variant.FinalVariantTitle + ": " + product_variant.VariantName;
                dic["FinalVariantPrice"] = product_variant.FinalVariantPrice;
            }
            dic["isallowproductsale"] = isallowproductsale;
            dic["ProductOrderType"] = type;
            dic["productid"] = productid;
            dic["variantid"] = variantid;
            dic["imageurl"] = !string.IsNullOrEmpty(product.CoverImage) ? WebUtil.GetContextPath() + product.CoverImage : "../image/error-img.png";
            dic["title"] = product.ProductName;
            dic["desc"] = desc;
            dic["pricedesc"] = pricedesc;
            dic["price"] = price;
            dic["salepoint"] = salepoint;
            dic["quantity"] = "x" + quantity.ToString();
            productlist.Add(dic);
            if (productlist.Count == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有相关商品");
                return;
            }
            string business_name = "福顺优选";
            int business_id = 0;
            string businessimage = string.Empty;
            if (product.BusinessID > 0)
            {
                var business_data = Foresight.DataAccess.Mall_Business.GetMall_Business(product.BusinessID);
                if (business_data != null)
                {
                    business_name = business_data.BusinessName;
                    business_id = business_data.ID;
                    businessimage = string.IsNullOrEmpty(business_data.CoverImage) ? "" : WebUtil.GetContextPath() + business_data.CoverImage;
                }
            }
            var business = new { name = business_name, id = business_id, businessimage = businessimage };
            decimal totalprice = price * quantity;
            int totalsalepoint = salepoint * quantity;
            decimal fushun_balance = Mall_UserJiXiaoPoint.GetMall_UserJiXiaoPointBalance(uid);
            var productsummary = new { totaldesc = "共" + productlist.Count.ToString() + "项", totalprice = totalprice, totalpricedesc = totalpricedesc, ispoint = isallowpointsale, totalsalepoint = totalsalepoint, balancepointdesc = fushun_balance + "积分", balancepoint = fushun_balance };
            bool show_address = true;
            if (product.ShipRateID > 0)
            {
                var ship_rate = Mall_ShipRate.GetMall_ShipRate(product.ShipRateID);
                if (ship_rate != null)
                {
                    show_address = ship_rate.RateType == 1;
                }
            }
            var couponlist = new List<Dictionary<string, object>>();
            var allcouponlist = Mall_CouponUserDetail.GetOrderMall_CouponUserDicList(totalprice, business_id, uid, out couponlist, ProductIDList: new int[] { productid });
            WebUtil.WriteJsonResult(context, new { productlist = productlist, productsummary = productsummary, business = business, show_address = show_address, ordersummary = new { totalprice = totalprice, ispoint = isallowpointsale, totalpricedesc = totalpricedesc, totalsalepoint = totalsalepoint }, couponlist = couponlist, allcouponlist = allcouponlist });
        }
        private void getmallproductdetail(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = 0;
            try
            {
                uid = GetUID(context, out user);
            }
            catch (Exception)
            {
            }
            int id = WebUtil.GetIntValue(context, "id");
            int type = WebUtil.GetIntValue(context, "type");
            var product = Foresight.DataAccess.Mall_ProductDetail.GetMall_ProductDetailByID(id);
            if (product == null)
            {
                WebUtil.WriteJsonResult(context, new { status = false, code = 1 });
                return;
            }
            if (product.Status != 10)
            {
                WebUtil.WriteJsonResult(context, new { status = false, code = 2 });
                return;
            }
            type = Mall_Product.GetFinalProductOrderType(type, product.ProductOrderType);
            var product_imgs = Foresight.DataAccess.Mall_Product_Picture.GetMall_Product_PictureListByID(id);
            string imageurl = !string.IsNullOrEmpty(product.CoverImage) ? WebUtil.GetContextPath() + product.CoverImage : "../image/error-img.png";
            var product_variants = Foresight.DataAccess.Mall_Product_VariantDetail.GetMall_Product_VariantDetailListByProductID(id);
            int joincount = 0;
            int leftcount = 0;
            decimal saleprice = product.FinalSalePrice;
            decimal cost = 0;
            bool isjoinpintuan = false;
            bool ispintuantopay = false;
            int orderid = 0;
            if (product.ProductTypeID == 3)
            {
                joincount = Mall_ProductPinUserDetail.GetMall_ProductPinUserDetailCountByProductID(product.ID);
                leftcount = product.PinPeopleCount - joincount;
                saleprice = product.PinSalePrice;
                cost = product.FinalVariantPrice;
                var pin_user_list = Mall_ProductPinUserDetail.GetMall_ProductPinUserDetailByUserID(uid, product.ID);
                if (pin_user_list.Length > 0)
                {
                    isjoinpintuan = pin_user_list.FirstOrDefault(p => p.FinalStatus == 1) != null;
                    var pin_user = pin_user_list.FirstOrDefault(p => p.FinalStatus == 2);
                    if (pin_user != null)
                    {
                        ispintuantopay = true;
                        var order = Mall_Order.GetMall_OrderByPin_UserID(pin_user.ID);
                        orderid = order != null ? order.ID : 0;
                    }
                }
            }
            if (product.ProductTypeID == 4)
            {
                saleprice = product.XianShiSalePrice;
                cost = product.SalePrice;
            }
            bool canchat = product.BusinessID > 0;
            int quantitylimit = (product.MaxQuantity > 0 ? product.MaxQuantity : 0);
            string countdowndate = product.countdowndate > DateTime.MinValue ? product.countdowndate.ToString("yyyy-MM-dd HH:mm:ss") : "";
            bool show_business = true;
            string businessimg = string.Empty;
            string businessname = "福顺优选";
            string address = string.Empty;
            if (product.BusinessID > 0)
            {
                var business = Mall_Business.GetMall_Business(product.BusinessID);
                if (business != null)
                {
                    businessimg = !string.IsNullOrEmpty(business.CoverImage) ? WebUtil.GetContextPath() + business.CoverImage : "";
                    businessname = business.BusinessName;
                    address = business.ShortAddress;
                }
            }
            string delivery_type = "自提";
            string delivery_summary = "";
            var shiprate = Mall_ShipRate.GetDefaultMall_ShipRate();
            if (shiprate != null)
            {
                delivery_summary = shiprate.RateSummary;
                if (shiprate.RateType == 2)
                {
                    delivery_type = shiprate.RateTile;
                }
                else
                {
                    var default_ship_rate_detail = Mall_ShipRateDetail.GetDefaultMall_ShipRateDetailByRateID(product.ShipRateID);
                    if (default_ship_rate_detail != null)
                    {
                        delivery_type = shiprate.RateTile + " " + default_ship_rate_detail.DefaultMoney.ToString("0.00");
                    }
                }
            }
            string PriceDesc = product.NormalPriceDesc;
            if (type == 17)
            {
                PriceDesc = product.PointPriceDesc;
            }
            else if (type == 18)
            {
                PriceDesc = product.VIPPointPriceDesc;
            }
            else if (type == 25)
            {
                PriceDesc = product.StaffPriceDesc;
            }
            bool canshare = false;
            if (type == 16)
            {
                canshare = true;
            }
            bool isallowpointbuy = product.IsAllowPointBuy && product.VariantPoint > 0;
            var coupon_list = Mall_Coupon.GetMall_CouponListByCouponType(1, ProductID: product.ID);
            var coupon_user_list = Mall_CouponUser.GetMall_CouponUserListByCouponType(5, uid);
            var coupon_items = coupon_list.Select(p =>
            {
                var my_coupon_user = coupon_user_list.FirstOrDefault(q => q.CouponID == p.ID);
                bool istaken = my_coupon_user != null;
                string title = p.CouponName;
                if (istaken)
                {
                    title = p.CouponName + "(已领取)";
                }
                var item = new { id = p.ID, title = title, istaken = istaken };
                return item;
            });
            bool hascoupon = coupon_list.Length > 0;
            var productinfo = new { type = type, id = product.ID, title = product.ProductName, summary = product.ProductSummary, saleprice = saleprice, cost = cost, pricedesc = PriceDesc, salepointprice = product.VariantPointPrice, salepoint = product.VariantPoint, salevipprice = product.VariantVIPPrice, salevippoint = product.VariantVIPPoint, salestaffprice = product.VariantStaffPrice, salestaffpoint = product.VariantStaffPoint, sellcount = product.SaleCountDesc, delivery_type = delivery_type, delivery_summary = delivery_summary, description = product.Description, imageurl = imageurl, variantid = product.VariantID, quantity = 1, variantname = product.VariantName, producttypeid = product.ProductTypeID, joincount = joincount, leftcount = leftcount, pinsaleprice = product.PinSalePrice, basicsaleprice = product.SalePrice, isjoinpintuan = isjoinpintuan, ispintuantopay = ispintuantopay, orderid = orderid, pinstatus = product.PinStatus, xianshistatus = product.XianShiStatus, maxquantity = product.Inventory, countdownenable = product.countdownenable, countdowndesc = product.countdowndesc, countdowndate = countdowndate, countdownday = product.countdownday, quantitylimit = quantitylimit, canchat = canchat, show_business = show_business, businessimg = businessimg, businessname = businessname, businessid = product.BusinessID, address = address, isallowpointbuy = isallowpointbuy, canshare = canshare, hascoupon = hascoupon, inventorydesc = "库存: " + product.Inventory + "个", inventory = product.Inventory, chosenvariatname = "已选规格: " + product.VariantName };
            var productimages = product_imgs.Select(p =>
            {
                var item = new { imageurl = WebUtil.GetContextPath() + p.MediumPicPath, largeimage = WebUtil.GetContextPath() + p.LargePicPath, cacheurl = "" };
                return item;
            });
            int totalcount = 0;
            if (uid > 0)
            {
                totalcount = Mall_ShoppingCart.GetTotalCount(uid);
            }
            var product_comments = Foresight.DataAccess.Mall_OrderCommentDetail.GetMall_OrderCommentDetailListByProductID(product.ID);
            var comment_items = product_comments.Select(p =>
            {
                string HeadImg = string.IsNullOrEmpty(p.HeadImg) ? "../image/default_user.png" : WebUtil.GetContextPath() + p.HeadImg;
                var item = new { id = p.ID, comment = p.RateComment, starcount = p.RateStar, addtime = p.AddTime.ToString("yyyy-MM-dd"), nickname = p.NickName, HeadImg = HeadImg };
                return item;
            });
            if (product_variants.Length == 0)
            {
                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                var variant_obj = new Dictionary<string, object>();
                variant_obj["id"] = 0;
                variant_obj["name"] = "默认";
                variant_obj["price"] = product.SalePrice;
                variant_obj["salepoint"] = 0;
                variant_obj["salepointprice"] = 0;
                variant_obj["salevipprice"] = 0;
                variant_obj["salevippoint"] = 0;
                variant_obj["salestaffprice"] = 0;
                variant_obj["salestaffpoint"] = 0;
                variant_obj["selected"] = true;
                variant_obj["quantitylimit"] = quantitylimit;
                variant_obj["inventory"] = product.Inventory;
                list.Add(variant_obj);
                WebUtil.WriteJsonResult(context, new { status = true, productinfo = productinfo, productimages = productimages, has_variants = false, productvariants = new { title = "规格", list = list }, totalcount = totalcount, commentlist = comment_items });
                return;
            }
            var productvariants = new
            {
                title = product_variants[0].FinalVariantTitle,
                list = product_variants.Select(p =>
                {
                    bool isselected = product.VariantID == p.ID;
                    var item = new { id = p.ID, name = p.VariantName, price = p.FinalVariantPrice, selected = isselected, quantitylimit = p.MaxQuantity, salepoint = p.VariantPoint, salepointprice = p.VariantPointPrice, salevipprice = p.VariantVIPPrice, salevippoint = p.VariantVIPPoint, salestaffprice = p.VariantStaffPrice, salestaffpoint = p.VariantStaffPoint, inventory = p.VariantInventory };
                    return item;
                })
            };
            WebUtil.WriteJsonResult(context, new { status = true, productinfo = productinfo, productimages = productimages, has_variants = true, productvariants = productvariants, totalcount = totalcount, commentlist = comment_items, couponlist = coupon_items });
        }
        private void getproductlistbycategoryid(HttpContext context)
        {
            int get_category = WebUtil.GetIntValue(context, "get_category");
            string type = context.Request["type"];
            int ParentID = WebUtil.GetIntValue(context, "parentid");
            List<Dictionary<string, object>> menus = new List<Dictionary<string, object>>();
            if (get_category == 1)
            {
                var categories = Foresight.DataAccess.Mall_Category.GetMall_Categories().Where(p => p.CategoryType.Equals(type) && p.ParentID == ParentID && !p.IsDisabled).OrderBy(p => p.SortOrder).ThenByDescending(p => p.AddTime).ToArray();
                menus = categories.Select(p =>
                {
                    var dic = new Dictionary<string, object>();
                    dic["id"] = p.ID;
                    dic["title"] = p.CategoryName;
                    dic["is_active"] = false;
                    return dic;
                }).ToList();
                if (menus.Count > 0)
                {
                    menus.Insert(0, new Dictionary<string, object> { { "id", ParentID }, { "title", "全部分类" }, { "is_active", true } });
                }
            }
            string keywords = context.Request["keywords"];
            int sortby = WebUtil.GetIntValue(context, "sortby");
            int categoryid = WebUtil.GetIntValue(context, "categoryid");
            int tagid = WebUtil.GetIntValue(context, "tagid");
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            int ProductTypeID = WebUtil.GetIntValue(context, "ProductTypeID");
            bool isallowpointbuy = WebUtil.GetIntValue(context, "isallowpointbuy") == 1;
            bool IsAllowProductBuy = WebUtil.GetIntValue(context, "IsAllowProductBuy") == 1;
            bool IsAllowVIPBuy = WebUtil.GetIntValue(context, "IsAllowVIPBuy") == 1;
            bool IsAllowStaffBuy = WebUtil.GetIntValue(context, "isallowstaffbuy") == 1;
            long totals = 0;
            var list = Foresight.DataAccess.Mall_ProductDetail.GetMall_ProductDetailListByKeywords(keywords, sortby, startRowIndex, pageSize, out totals, CategoryID: categoryid, ProductTypeID: ProductTypeID, TagID: tagid, isallowpointbuy: isallowpointbuy, IsAllowProductBuy: IsAllowProductBuy, IsAllowVIPBuy: IsAllowVIPBuy, IsAllowStaffBuy: IsAllowStaffBuy);
            var ProductIDList = list.Select(p => p.ID).ToList();
            var pin_user_list = Foresight.DataAccess.Mall_ProductPinUserDetail.GetMall_ProductPinUserDetailList(ProductIDList);
            var items = list.Select(p =>
            {
                string PriceDesc = string.Empty;
                if (IsAllowProductBuy)
                {
                    PriceDesc = p.NormalPriceDesc;
                }
                else if (isallowpointbuy)
                {
                    PriceDesc = p.PointPriceDesc;
                }
                else if (IsAllowVIPBuy)
                {
                    PriceDesc = p.VIPPointPriceDesc;
                }
                else if (IsAllowStaffBuy)
                {
                    PriceDesc = p.StaffPriceDesc;
                }
                string imageurl = string.IsNullOrEmpty(p.CoverImage) ? "../image/error-img.png" : WebUtil.GetContextPath() + p.CoverImage;
                string totalcount = string.Empty;
                if (p.ProductTypeID == 3)
                {
                    var my_pin_user_list = pin_user_list.Where(q => q.ProductID == p.ID).ToArray();
                    totalcount = "已参团" + my_pin_user_list.Length.ToString() + "人";
                }
                string countdowndate = p.countdowndate > DateTime.MinValue ? p.countdowndate.ToString("yyyy-MM-dd HH:mm:ss") : "";
                var item = new { id = p.ID, title = p.ProductName, price = PriceDesc, saledesc = p.SaleCountDesc, imageurl = imageurl, time = p.TimeDesc, totalcount = totalcount, countdownenable = p.countdownenable, countdown_timmer = 0, countdowndate = countdowndate, leftTime = 0, countdownday = "", countdowndesc = p.countdowndesc };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { menus = menus, list = items });
        }
        private void getappyouxuansourcelist(HttpContext context)
        {
            string type = context.Request["type"];
            int ParentID = WebUtil.GetIntValue(context, "parentid");
            var list = Foresight.DataAccess.Mall_Category.GetMall_Categories().Where(p => p.CategoryType.Equals(type) && !p.IsDisabled && p.IsShowOnMallYouXuan).OrderBy(p => p.SortOrder).ThenByDescending(p => p.AddTime).ToArray();
            var configs = SysConfig.GetSysConfigs().ToArray();
            int categorycount = 3;
            var configcategory = configs.FirstOrDefault(p => p.Name.Equals(SysConfigNameDefine.MallMallBusinessCount));
            if (configcategory != null)
            {
                int.TryParse(configcategory.Value, out categorycount);
                categorycount = categorycount > 0 ? categorycount : 3;
            }
            var items = list.Take(categorycount).Select(p =>
            {
                var imgurl = !string.IsNullOrEmpty(p.PicturePath) ? WebUtil.GetContextPath() + p.PicturePath : "../image/error-img.png";
                int parentid = p.ParentID > 0 ? p.ParentID : 0;
                var item = new { id = p.ID, title = p.CategoryName, src = imgurl, selected = false, parentid = parentid };
                return item;
            });
            int business_count = 3;
            var config_business = configs.FirstOrDefault(p => p.Name.Equals(SysConfigNameDefine.MallMallBusinessCount));
            if (config_business != null)
            {
                int.TryParse(config_business.Value, out business_count);
                business_count = business_count > 0 ? business_count : 3;
            }
            long totals = 0;
            var businesslist = Foresight.DataAccess.Mall_BusinessDetail.GetMall_BusinessDetailListByKeywords(string.Empty, 1, 0, int.MaxValue, out totals, issuggestion: true).Take(business_count).ToArray();
            var businessitems = businesslist.Select(p =>
            {
                string imageurl = string.IsNullOrEmpty(p.CoverImage) ? "../image/error-img.png" : WebUtil.GetContextPath() + p.CoverImage;
                var item = new { id = p.ID, title = p.BusinessName, rate = p.RateComment, price = string.Empty, address = p.BusinessAddress, distance = p.Distance, distancedesc = p.DistanceDesc, imageurl = imageurl, istopshow = p.IsTopShow };
                return item;
            });
            //热门消费
            var config_hotsale = configs.FirstOrDefault(p => p.Name.Equals(SysConfigNameDefine.MallHomeHotSaleCount.ToString()));
            int hotsale_count = 10;
            if (config_hotsale != null)
            {
                int.TryParse(config_hotsale.Value, out hotsale_count);
                hotsale_count = hotsale_count > 0 ? hotsale_count : 4;
            }
            var hotsalelist = Mall_HotSaleDetail.GetMall_HotSaleList().Take(hotsale_count).ToList();
            var config_category = configs.FirstOrDefault(p => p.Name.Equals(SysConfigNameDefine.MallCategoryLineCount.ToString()));
            int category_count = 4;
            if (config_category != null)
            {
                int.TryParse(config_category.Value, out category_count);
            }
            if (category_count != 4 && category_count != 3)
            {
                category_count = 4;
            }
            //优选 团购 抢购
            var image_list = Mall_RotatingImage.GetMall_RotatingImages().ToArray();
            var youxuan_item = image_list.FirstOrDefault(p => p.Type == 11);
            var tuangou_item = image_list.FirstOrDefault(p => p.Type == 12);
            var qianggou_item = image_list.FirstOrDefault(p => p.Type == 13);
            List<Dictionary<string, object>> youxuanlist = new List<Dictionary<string, object>>();
            string youxuanimage = "../image/icons/fushunyouxuan_box_new.jpg";
            if (youxuan_item != null && !string.IsNullOrEmpty(youxuan_item.ImagePath))
            {
                youxuanimage = WebUtil.GetContextPath() + youxuan_item.ImagePath;
            }
            string tuangouimage = "../image/icons/shanagquan_tuangou_icon.jpg";
            if (tuangou_item != null && !string.IsNullOrEmpty(tuangou_item.ImagePath))
            {
                tuangouimage = WebUtil.GetContextPath() + tuangou_item.ImagePath;
            }
            string qianggouimage = "../image/icons/shangquan_qg_icon.jpg";
            if (qianggou_item != null && !string.IsNullOrEmpty(qianggou_item.ImagePath))
            {
                qianggouimage = WebUtil.GetContextPath() + qianggou_item.ImagePath;
            }
            var youxuanform = new
            {
                youxuantitle = "福顺优选",
                youxuansummary = "好生活一起抢",
                youxuanimage = youxuanimage,
                tuangoutitle = "团购",
                tuangousummary = "好品质",
                tuangouimage = tuangouimage,
                qianggoutitle = "抢购",
                qianggousummary = "超低价",
                qianggouimage = qianggouimage
            };
            WebUtil.WriteJsonResult(context, new { servicelist = items, businesslist = businessitems, hotsalelist = hotsalelist, categorycount = category_count, youxuanform = youxuanform });
        }
        private void getmallcategorylist(HttpContext context)
        {
            string type = context.Request["type"];
            int ParentID = WebUtil.GetIntValue(context, "parentid");
            var list = Foresight.DataAccess.Mall_Category.GetMall_Categories().Where(p => p.CategoryType.Equals(type) && p.ParentID == ParentID && !p.IsDisabled).OrderBy(p => p.SortOrder).ThenByDescending(p => p.AddTime).ToArray();
            var items = list.Select(p =>
            {
                var imgurl = !string.IsNullOrEmpty(p.PicturePath) ? WebUtil.GetContextPath() + p.PicturePath : "../image/error-img.png";
                int parentid = p.ParentID > 0 ? p.ParentID : 0;
                var item = new { id = p.ID, title = p.CategoryName, src = imgurl, selected = false, parentid = parentid };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { servicelist = items });
        }
        private void savebaoxiujianyi(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            DateTime AppointTime = DateTime.MinValue;
            if (!string.IsNullOrEmpty(context.Request["AppointTime"]))
            {
                string AppointTimeStr = context.Request["AppointTime"].Replace("T", " ");
                DateTime.TryParse(AppointTimeStr, out AppointTime);
            }
            string FullName = context.Request["FullName"];
            string ProjectName = string.Empty;
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            if (RoomID > 0)
            {
                var room_basic = Foresight.DataAccess.ViewRoomBasic.GetViewRoomBasicByRoomID(RoomID);
                if (room_basic != null)
                {
                    FullName = room_basic.FullName + "-" + room_basic.Name;
                    ProjectName = room_basic.FullName;
                }
            }
            string ServiceContent = context.Request["Content"];
            string PhoneNo = context.Request["PhoneNo"];
            string ServiceType = context.Request["ServiceType"];
            var customer_service = new Foresight.DataAccess.CustomerService();
            customer_service.AddUserID = uid;
            customer_service.AddTime = DateTime.Now;
            customer_service.StartTime = DateTime.Now;
            customer_service.AddMan = user.LoginName;
            customer_service.AddUserName = user.LoginName;
            customer_service.ServiceFrom = Utility.EnumModel.WechatServiceFromDefine.customerapp.ToString();
            customer_service.AddCustomerName = user.LoginName;
            customer_service.ServiceStatus = 3;
            customer_service.IsAPPShow = true;
            customer_service.ServiceFullName = FullName;
            customer_service.ProjectID = RoomID;
            customer_service.ServiceFullName = FullName;
            customer_service.ProjectName = ProjectName;
            string ServiceTypeDesc = Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatServiceType), ServiceType);
            var type = Foresight.DataAccess.ServiceType.GetServiceTypes().FirstOrDefault(p => ServiceTypeDesc.Contains(p.ServiceTypeName));
            customer_service.ServiceTypeID = type != null ? type.ID : int.MinValue;
            customer_service.ServiceTypeName = type != null ? type.ServiceTypeName : string.Empty;
            customer_service.ServiceContent = ServiceContent;
            customer_service.ServiceAppointTime = AppointTime;
            customer_service.AddCallPhone = PhoneNo;
            customer_service.IsUnRead = true;

            List<Foresight.DataAccess.CustomerServiceAttach> customer_attachlist = new List<Foresight.DataAccess.CustomerServiceAttach>();
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
                        string filepath = "/upload/WechatServiceImg/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        Foresight.DataAccess.CustomerServiceAttach customer_attach = new Foresight.DataAccess.CustomerServiceAttach();
                        customer_attach.FileOriName = fileOriName;
                        customer_attach.AttachedFilePath = filepath + fileName;
                        customer_attach.AddTime = DateTime.Now;
                        customer_attachlist.Add(customer_attach);
                    }
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    if (!ServiceType.Equals("bsbx"))
                    {
                        customer_service.IsSuggestion = true;
                    }
                    customer_service.Save(helper);
                    foreach (var attach in customer_attachlist)
                    {
                        attach.ServiceID = customer_service.ID;
                        attach.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "savebaoshibaoxiu", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器异常");
                    return;
                }
            }
            if (ServiceType.Equals("bsbx"))
            {
                string ErrorMsg = string.Empty;
                var company = Company.GetCompanies().FirstOrDefault();
                string title = company == null ? "永友网络" : company.CompanyName;
                APPCode.JPushHelper.SendJpushMsgByServiceID(customer_service.ID, out ErrorMsg, title: title, SendUserID: user.UserID, SendUserName: user.LoginName);
                //通知后台
                APPCode.SocketNotify.PushSocketNotifyAlert(Utility.EnumModel.SocketNotifyDefine.notifyservice);
            }
            else
            {
                //通知后台
                APPCode.SocketNotify.PushSocketNotifyAlert(Utility.EnumModel.SocketNotifyDefine.notifysuggestion);
            }
            WebUtil.WriteJsonResult(context, "保存成功");
        }
        private void getmyroomsourcelist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var list = ViewRoomBasic.GetViewRoomBasicListByUserID(user, IncludeRelation: false, PhoneNumber: user.LoginName);
            if (list.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请先绑定房间");
                return;
            }
            var items = list.Select(p =>
            {
                var item = new { RoomID = p.RoomID, RelatePhoneNumber = p.RelatePhoneNumber, Name = p.FullName.Replace("-", "") + p.Name };
                return item;
            });
            var form = new { RoomID = list[0].RoomID, FullName = list[0].FullName.Replace("-", "") + list[0].Name, PhoneNo = user.LoginName, AppointTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm"), Content = "" };
            WebUtil.WriteJsonResult(context, new { list = items, form = form });
        }
        private void getxiaoqunewslist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int get_category = WebUtil.GetIntValue(context, "get_category");
            List<Dictionary<string, object>> menus = new List<Dictionary<string, object>>();
            if (get_category == 1)
            {
                var categories = Foresight.DataAccess.Wechat_MsgCategory.GetWechat_MsgCategories().OrderBy(p => p.SortOrder).ThenBy(p => p.AddTime).ToArray();
                menus = categories.Select(p =>
               {
                   var dic = new Dictionary<string, object>();
                   dic["id"] = p.ID;
                   dic["title"] = p.CategoryName;
                   dic["is_active"] = false;
                   return dic;
               }).ToList();
                if (menus.Count > 0)
                {
                    menus.Insert(0, new Dictionary<string, object> { { "id", 0 }, { "title", "全部分类" }, { "is_active", true } });
                }
            }
            int categoryid = WebUtil.GetIntValue(context, "categoryid");
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            List<int> ProjectIDList = Foresight.DataAccess.Mall_UserProject.GetMall_UserProjectListByUserID(uid).Select(p => p.ProjectID).ToList();
            long totals = 0;
            var list = Foresight.DataAccess.Wechat_Msg.GetWechat_MsgListByMsgType(Utility.EnumModel.WechatMsgType.news.ToString(), startRowIndex, pageSize, out totals, IsCustomerAPPSend: true, CategoryID: categoryid, ProjectIDList: ProjectIDList, UserID: uid);
            var items = list.Select(p =>
            {
                string time = p.PublishTime == DateTime.MinValue ? p.AddTime.ToString("yyyy-MM-dd HH:mm:ss") : p.PublishTime.ToString("yyyy-MM-dd HH:mm:ss");
                string ImgUrl = string.IsNullOrEmpty(p.PicPath) ? "../image/error-img.png" : WebUtil.GetContextPath() + p.PicPath;
                var item = new { id = p.ID, title = p.MsgTitle, time = time, tag = p.MsgTypeDesc, imageurl = ImgUrl };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { menus = menus, list = items });
        }
        private void getwuyegonggaodetail(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int id = WebUtil.GetIntValue(context, "id");
            var data = Foresight.DataAccess.Wechat_Msg.GetWechat_Msg(id);
            string time = data.PublishTime == DateTime.MinValue ? data.AddTime.ToString("yyyy-MM-dd HH:mm:ss") : data.PublishTime.ToString("yyyy-MM-dd HH:mm:ss");
            var item = new { id = data.ID, title = data.MsgTitle, tag = data.MsgTypeDesc, time = time, content = data.HTMLContent };
            WebUtil.WriteJsonResult(context, item);
        }
        private void checkloginstatus(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getwuyegonggaolist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            long totals = 0;
            List<int> ProjectIDList = Foresight.DataAccess.Mall_UserProject.GetMall_UserProjectListByUserID(uid).Select(p => p.ProjectID).ToList();
            var list = Foresight.DataAccess.Wechat_Msg.GetWechat_MsgListByMsgType(Utility.EnumModel.WechatMsgType.tongzhi.ToString(), startRowIndex, pageSize, out totals, IsCustomerAPPSend: true, ProjectIDList: ProjectIDList, UserID: uid);
            var items = list.Select(p =>
            {
                string Summary = string.IsNullOrEmpty(p.MsgSummary) ? "暂无详细说明" : p.MsgSummary;
                string time = p.PublishTime == DateTime.MinValue ? p.AddTime.ToString("yyyy-MM-dd HH:mm:ss") : p.PublishTime.ToString("yyyy-MM-dd HH:mm:ss");
                var item = new { id = p.ID, title = p.MsgTitle, readcount = p.APPCustomerReadCount > 0 ? p.APPCustomerReadCount : 0, summary = Summary, time = time, tag = p.MsgTypeDesc };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        public void alipayorderready(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var now = DateTime.Now;
            int paymentid = WebUtil.GetIntValue(context, "paymentid");
            int orderid = WebUtil.GetIntValue(context, "orderid");
            string ids = context.Request["orderidlist"];
            List<int> OrderIDList = new List<int>();
            if (!string.IsNullOrEmpty(ids))
            {
                OrderIDList = JsonConvert.DeserializeObject<List<int>>(ids);
            }
            if (!OrderIDList.Contains(orderid) && orderid > 0)
            {
                OrderIDList.Add(orderid);
            }
            var order_list = Mall_Order.GetMall_OrderListByIDList(OrderIDList);
            if (order_list.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单不存在");
                return;
            }
            int TotalOrderPointCost = order_list.Where(p => p.TotalOrderPointCost > 0).Sum(p => p.TotalOrderPointCost);
            if (TotalOrderPointCost > 0)
            {
                var total_point_balance = Mall_UserPoint.GetMall_UserPointBalance(uid);
                if (total_point_balance < TotalOrderPointCost)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前积分不足");
                    return;
                }
            }
            decimal TotalOrderCost = order_list.Sum(p => p.TotalOrderCost);
            if (TotalOrderCost <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前订单金额为0");
                return;
            }
            Foresight.DataAccess.Payment payment = null;
            string TradeNo = WxPayApi.GenerateOutTradeNo();
            if (paymentid > 0)
            {
                payment = Payment.GetPayment(paymentid);
                TradeNo = payment != null ? payment.TradeNo : TradeNo;
            }
            var all_request_list = new List<Payment_Request>();
            var all_fee_list = new List<RoomFee>();
            var all_order_list = new List<Mall_Order>();
            List<int> FeeOrderIDList = new List<int>();
            foreach (var order in order_list)
            {
                if (order.IsClosed)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单已关闭");
                    return;
                }
                if (order.OrderStatus != 1)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单已支付");
                    return;
                }
                if (!string.IsNullOrEmpty(order.TradeNo))
                {
                    try
                    {
                        int PayStatus = APPCode.PaymentHelper.OrderQuery(order.TradeNo);
                        if (PayStatus == 2)
                        {
                            WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "选中的订单已支付成功");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteError(LogModuel, "alipayorderready.OrderQuery", ex);
                    }
                    if (order.ProductTypeID == 10)
                    {
                        var fee_list = Foresight.DataAccess.RoomFee.GetRoomFeeListByTradeNo(order.TradeNo, OrderID: order.ID);
                        foreach (var item in fee_list)
                        {
                            item.TradeNo = TradeNo;
                            all_fee_list.Add(item);
                        }
                        var my_request_list = Payment_Request.GetPayment_RequestByTradeNo(order.TradeNo, OrderID: order.ID).ToList();
                        foreach (var item in my_request_list)
                        {
                            all_request_list.Add(item);
                        }
                        FeeOrderIDList.Add(order.ID);
                    }
                }
                order.TradeNo = TradeNo;
                order.PaymentMethod = Utility.EnumModel.Mall_OrderPaymentMethodDefine.wxpay.ToString();
                all_order_list.Add(order);
            }
            int FeeOrderID = FeeOrderIDList.Count == 1 ? FeeOrderIDList[0] : 0;
            payment = Payment.Insert_Payment(TotalOrderCost * 100, Utility.EnumModel.PaymentTypeDefine.app_alipay.ToString(), TradeNo, 1, user.LoginName, "APP支付支付宝申请", payment: payment, request_list: all_request_list, fee_list: all_fee_list, order_list: all_order_list, OrderID: FeeOrderID);
            var orderitems = Foresight.DataAccess.Mall_OrderItem.GetMall_OrderItemListByOrderIDList(OrderIDList);
            string ProductNames = string.Empty;
            int count = 0;
            foreach (var orderItem in orderitems)
            {
                count++;
                if (count >= 2)
                {
                    ProductNames += "等" + orderitems.Length.ToString() + "项";
                    break;
                }
                if (count > 1)
                {
                    ProductNames += "," + orderItem.ProductTitle;
                    continue;
                }
                ProductNames += orderItem.ProductTitle;
            }
            var app_id = AlipayConfig.mobile_app_id;
            var mobile_gatewayUrl = AlipayConfig.mobile_gatewayUrl;
            var charset = AlipayConfig.charset;
            var timeout_express = AlipayConfig.timeout_express;
            var seller_id = AlipayConfig.mobile_seller_id;
            var product_code = AlipayConfig.mobile_product_code;
            var notify_url = AlipayConfig.mobile_notify_url;
            var sign_type = AlipayConfig.sign_type;
            var version = AlipayConfig.version;
            var site_config = new SiteConfig();
            IAopClient client = new DefaultAopClient(mobile_gatewayUrl, app_id, AlipayConfig.mobile_private_key_value, "json", version, sign_type, AlipayConfig.mobile_public_key_value, charset, false);
            AlipayTradeAppPayRequest request = new AlipayTradeAppPayRequest();
            AlipayTradeAppPayModel model = new AlipayTradeAppPayModel();
            model.SellerId = seller_id;
            model.Body = ProductNames;
            model.Subject = site_config.SystemName + "-" + ProductNames;
            model.TotalAmount = TotalOrderCost.ToString("0.00");
            model.ProductCode = product_code;
            model.OutTradeNo = TradeNo;
            model.TimeoutExpress = timeout_express;
            model.ExtendParams = new ExtendParams() { SysServiceProviderId = seller_id };

            request.SetBizModel(model);
            request.SetNotifyUrl(notify_url);
            AlipayTradeAppPayResponse response = client.SdkExecute(request);
            WebUtil.WriteJson(context, "{\"Code\":0,\"Result\":\"" + response.Body + "\"}");
        }
        public void alipayorderreadychongzhi(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var now = DateTime.Now;
            decimal amount = WebUtil.GetDecimalValue(context, "amount");
            if (amount <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "充值金额必须大于0");
                return;
            }
            string TradeNo = WxPayApi.GenerateOutTradeNo();
            var payment = Payment.Insert_Payment(amount * 100, Utility.EnumModel.PaymentTypeDefine.app_chongzhi_alipay.ToString(), TradeNo, 1, user.LoginName, "APP账户支付宝充值", CanSave: false);
            var app_id = AlipayConfig.mobile_app_id;
            var mobile_gatewayUrl = AlipayConfig.mobile_gatewayUrl;
            var charset = AlipayConfig.charset;
            var timeout_express = AlipayConfig.timeout_express;
            var seller_id = AlipayConfig.mobile_seller_id;
            var product_code = AlipayConfig.mobile_product_code;
            //var method = AlipayConfig.mobile_method;
            var notify_url = AlipayConfig.mobile_notify_url_chongzhi;
            var sign_type = AlipayConfig.sign_type;
            var version = AlipayConfig.version;
            IAopClient client = new DefaultAopClient(mobile_gatewayUrl, app_id, AlipayConfig.mobile_private_key_value, "json", version, sign_type, AlipayConfig.mobile_public_key_value, charset, false);
            AlipayTradeAppPayRequest request = new AlipayTradeAppPayRequest();
            AlipayTradeAppPayModel model = new AlipayTradeAppPayModel();
            model.SellerId = seller_id;
            model.Body = "支付宝充值";
            model.Subject = "支付宝充值";
            model.TotalAmount = amount.ToString("0.00");
            model.ProductCode = product_code;
            model.OutTradeNo = TradeNo;
            model.TimeoutExpress = timeout_express;
            model.ExtendParams = new ExtendParams() { SysServiceProviderId = seller_id };
            request.SetBizModel(model);
            request.SetNotifyUrl(notify_url);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    payment.Save(helper);
                    Mall_UserBalance.Insert_Mall_UserBalance(uid, 1, amount, "支付宝充值", "", 3, user.LoginName, 0, TradeNo, helper: helper, PaymentMethod: Utility.EnumModel.Mall_OrderPaymentMethodDefine.alipay.ToString());
                    AlipayTradeAppPayResponse response = client.SdkExecute(request);
                    helper.Commit();
                    WebUtil.WriteJson(context, "{\"Code\":0,\"Result\":\"" + response.Body + "\"}");
                    return;
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "alipayorderreadychongzhi", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.ServerError, ex.Message);
                    return;
                }
            }
        }
        private void wxpayorderready(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int paymentid = WebUtil.GetIntValue(context, "paymentid");
            int orderid = WebUtil.GetIntValue(context, "orderid");
            string ids = context.Request["orderidlist"];
            List<int> OrderIDList = new List<int>();
            if (!string.IsNullOrEmpty(ids))
            {
                OrderIDList = JsonConvert.DeserializeObject<List<int>>(ids);
            }
            if (!OrderIDList.Contains(orderid) && orderid > 0)
            {
                OrderIDList.Add(orderid);
            }
            var order_list = Mall_Order.GetMall_OrderListByIDList(OrderIDList);
            if (order_list.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单不存在");
                return;
            }
            int TotalOrderPointCost = order_list.Where(p => p.TotalOrderPointCost > 0).Sum(p => p.TotalOrderPointCost);
            if (TotalOrderPointCost > 0)
            {
                var total_point_balance = Mall_UserPoint.GetMall_UserPointBalance(uid);
                if (total_point_balance < TotalOrderPointCost)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前积分不足");
                    return;
                }
            }
            decimal TotalOrderCost = order_list.Sum(p => p.TotalOrderCost);
            if (TotalOrderCost <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前订单金额为0");
                return;
            }
            Foresight.DataAccess.Payment payment = null;
            string TradeNo = WxPayApi.GenerateOutTradeNo();
            if (paymentid > 0)
            {
                payment = Payment.GetPayment(paymentid);
                TradeNo = payment != null ? payment.TradeNo : TradeNo;
            }
            var all_request_list = new List<Payment_Request>();
            var all_fee_list = new List<RoomFee>();
            var all_order_list = new List<Mall_Order>();
            List<int> FeeOrderIDList = new List<int>();
            foreach (var order in order_list)
            {
                if (order.IsClosed)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单已关闭");
                    return;
                }
                if (order.OrderStatus != 1)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单已支付");
                    return;
                }
                if (!string.IsNullOrEmpty(order.TradeNo))
                {
                    try
                    {
                        int PayStatus = APPCode.PaymentHelper.OrderQuery(order.TradeNo);
                        if (PayStatus == 2)
                        {
                            WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "选中的订单已支付成功");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteError(LogModuel, "wxpayorderready.OrderQuery", ex);
                    }
                    if (order.ProductTypeID == 10)
                    {
                        var my_fee_list = Foresight.DataAccess.RoomFee.GetRoomFeeListByTradeNo(order.TradeNo, OrderID: order.ID);
                        foreach (var item in my_fee_list)
                        {
                            item.TradeNo = TradeNo;
                            all_fee_list.Add(item);
                        }
                        var my_request_list = Payment_Request.GetPayment_RequestByTradeNo(order.TradeNo, OrderID: order.ID).ToList();
                        foreach (var item in my_request_list)
                        {
                            all_request_list.Add(item);
                        }
                        FeeOrderIDList.Add(order.ID);
                    }
                }
                order.TradeNo = TradeNo;
                order.PaymentMethod = Utility.EnumModel.Mall_OrderPaymentMethodDefine.wxpay.ToString();
                all_order_list.Add(order);
            }
            int FeeOrderID = FeeOrderIDList.Count == 1 ? FeeOrderIDList[0] : 0;
            payment = Payment.Insert_Payment(TotalOrderCost * 100, Utility.EnumModel.PaymentTypeDefine.app_wx.ToString(), TradeNo, 1, user.LoginName, "APP支付微信支付申请", payment: payment, request_list: all_request_list, fee_list: all_fee_list, order_list: all_order_list, OrderID: FeeOrderID);
            var orderitems = Foresight.DataAccess.Mall_OrderItem.GetMall_OrderItemListByOrderIDList(OrderIDList);
            string ProductNames = string.Empty;
            int count = 0;
            foreach (var orderItem in orderitems)
            {
                count++;
                if (count >= 2)
                {
                    ProductNames += "等" + orderitems.Length.ToString() + "项";
                    break;
                }
                if (count > 1)
                {
                    ProductNames += "," + orderItem.ProductTitle;
                    continue;
                }
                ProductNames += orderItem.ProductTitle;
            }
            try
            {
                string body = APPCode.WeixinHelper.GetPayBodyContent(ProductNames);
                Dictionary<string, string> result = APPCode.PaymentHelper.APPWxPayUnifiedorder(TradeNo, body, (TotalOrderCost * 100).ToString("0"));
                if (result.ContainsKey("failure"))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, result["failure"]);
                }
                else
                {
                    WebUtil.WriteJsonResult(context, new { apiKey = result["appid"], orderId = result["prepayid"], mchId = result["partnerid"], noncestr = result["noncestr"], timestamp = result["timestamp"], package = result["package"], sign = result["sign"] });
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModuel, "wxpayorderready", ex);
                WebUtil.WriteJsonError(context, ErrorCode.ServerError, ex.Message);
            }
        }
        private void wxpayorderreadychongzhi(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            decimal amount = WebUtil.GetDecimalValue(context, "amount");
            if (amount <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "充值金额必须大于0");
                return;
            }
            string TradeNo = WxPayApi.GenerateOutTradeNo();
            var payment = Payment.Insert_Payment(amount * 100, Utility.EnumModel.PaymentTypeDefine.app_chongzhi_wx.ToString(), TradeNo, 1, user.LoginName, "APP账户微信充值", CanSave: false);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    payment.Save(helper);
                    Mall_UserBalance.Insert_Mall_UserBalance(uid, 1, amount, "微信充值", "", 2, user.LoginName, 0, TradeNo, helper: helper, PaymentMethod: Utility.EnumModel.Mall_OrderPaymentMethodDefine.wxpay.ToString());
                    Dictionary<string, string> result = APPCode.PaymentHelper.APPWxPayUnifiedorder(TradeNo, "微信充值", (amount * 100).ToString("0"), IsOrder: false, IsChongZhi: true);
                    if (result.ContainsKey("failure"))
                    {
                        helper.Rollback();
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, result["failure"]);
                        return;
                    }
                    else
                    {
                        helper.Commit();
                        WebUtil.WriteJsonResult(context, new { apiKey = result["appid"], orderId = result["prepayid"], mchId = result["partnerid"], noncestr = result["noncestr"], timestamp = result["timestamp"], package = result["package"], sign = result["sign"] });
                        return;
                    }
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "wxpayorderreadychongzhi", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.ServerError, ex.Message);
                    return;
                }
            }
        }
        private void getorderinfo(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = 0;
            try
            {
                uid = GetUID(context, out user);
            }
            catch (Exception)
            {
            }
            int orderid = WebUtil.GetIntValue(context, "orderid");
            var order = Foresight.DataAccess.Mall_Order.GetMall_Order(orderid);
            if (order == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单不存在");
                return;
            }
            int paytype = WebUtil.GetIntValue(context, "paytype");
            string errormsg = "";
            var data = APPCode.CommHelper.getorderinfo(order, paytype, uid, out errormsg);
            if (!string.IsNullOrEmpty(errormsg))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, errormsg);
                return;
            }
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器内部异常");
                return;
            }
            WebUtil.WriteJsonResult(context, data);
        }
        private void getorderlistinfo(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = 0;
            try
            {
                uid = GetUID(context, out user);
            }
            catch (Exception)
            {
            }
            int orderid = WebUtil.GetIntValue(context, "orderid");
            string ids = context.Request["orderidlist"];
            List<int> OrderIDList = new List<int>();
            if (!string.IsNullOrEmpty(ids))
            {
                OrderIDList = JsonConvert.DeserializeObject<List<int>>(ids);
            }
            if (!OrderIDList.Contains(orderid) && orderid > 0)
            {
                OrderIDList.Add(orderid);
            }
            var order_list = Mall_Order.GetMall_OrderListByIDList(OrderIDList);
            if (order_list.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有相关订单");
                return;
            }
            int paytype = WebUtil.GetIntValue(context, "paytype");
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            decimal totalprice = 0;
            int totalsalepoint = 0;
            int stafftotalpoint = 0;
            //var ordersummary = new { totalprice = order.TotalOrderCost, ispoint = totalsalepoint > 0, totalpoint = point_balance, totalsalepoint = totalsalepoint, totalpricedesc = totalpricedesc };
            foreach (var order in order_list)
            {
                string errormsg = "";
                var data = APPCode.CommHelper.getorderinfo(order, paytype, uid, out errormsg);
                if (!string.IsNullOrEmpty(errormsg))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, errormsg);
                    return;
                }
                if (data == null)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器内部异常");
                    return;
                }
                var summary = data["ordersummary"] as Utility.OrderSummary;
                totalprice += summary.totalprice;
                totalsalepoint += (summary.totalsalepoint > 0 ? summary.totalsalepoint : 0);
                stafftotalpoint += (summary.stafftotalpoint > 0 ? summary.stafftotalpoint : 0);
                list.Add(data);
            }
            if (list.Count == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有相关订单");
                return;
            }
            string totalpricedesc = APPCode.CommHelper.gettotalpricedesc(totalprice, totalsalepoint, stafftotalpoint);
            var ordersummary = new Utility.OrderSummary { totalprice = totalprice, ispoint = totalsalepoint > 0, totalpoint = 0, totalsalepoint = totalsalepoint, totalpricedesc = totalpricedesc, stafftotalpoint = stafftotalpoint };
            WebUtil.WriteJsonResult(context, new { list = list, ordersummary = ordersummary });
        }
        private void createfeeorder(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int paymentid = WebUtil.GetIntValue(context, "paymentid");
            var payment = Foresight.DataAccess.Payment.GetPayment(paymentid);
            if (payment == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单失效，请重新下单");
                return;
            }
            var request_list = Payment_Request.GetPayment_RequestByPaymentID(paymentid);
            if (request_list.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单失效，请重新下单");
                return;
            }
            Foresight.DataAccess.Mall_Order order = new Mall_Order();
            List<Mall_OrderItem> orderitems = new List<Mall_OrderItem>();
            order.AddTime = DateTime.Now;
            order.AddUser = user.LoginName;
            order.OrderNumber = Mall_Order.GetLastestOrderNumber();
            order.TradeNo = payment.TradeNo;
            order.OrderType = 2;
            order.TotalCost = payment.Amount / 100;
            order.OriginalTotalCost = order.TotalCost;
            order.OrderStatus = 1;
            order.UserID = uid;
            order.UserName = user.LoginName;
            order.UserNote = context.Request["user_note"];
            order.ProductTypeID = 10;
            order.CouponID = WebUtil.GetIntValue(context, "couponid");
            order.CouponAmount = WebUtil.GetDecimalValue(context, "couponprice");
            order.CouponID = WebUtil.GetIntValue(context, "couponid");
            order.CouponUserID = WebUtil.GetIntValue(context, "couponuserid");
            order.CouponAmount = WebUtil.GetIntValue(context, "couponprice");
            order.TotalSalePoint = 0;
            order.TotalVIPSalePoint = 0;
            order.TotalSaleStaffPoint = 0;
            var list = Foresight.DataAccess.Payment_Request.GetPayment_RequestByPaymentID(paymentid);
            List<int> fee_idlist = list.Select(p => p.RoomFeeID).ToList();
            var roomfee_list = RoomFeeAnalysis.GetRoomFeeAnalysisListByIDList(fee_idlist).ToArray();
            foreach (var item in list)
            {
                var roomfee = roomfee_list.FirstOrDefault(p => p.ID == item.RoomFeeID);
                var order_item = new Mall_OrderItem();
                order_item.IsDiscountPrice = false;
                order_item.AddTime = order.AddTime;
                order_item.AddMan = order.AddUser;
                order_item.ProductID = item.RoomFeeID;
                order_item.RoomID = roomfee.RoomID;
                order_item.RoomName = roomfee.FullName + "-" + roomfee.RoomName;
                order_item.ChargeID = roomfee.ChargeID;
                order_item.ChargeName = roomfee.Name;
                order_item.StartTime = roomfee.CalculateStartTime;
                order_item.EndTime = item.EndTime;
                order_item.Price = item.TotalCost;
                order_item.Quantity = 1;
                order_item.BusinessID = 0;
                order_item.ProductTypeID = 10;
                order_item.TotalPrice = item.TotalCost;
                order_item.SalePoint = 0;
                order_item.TotalSalePoint = 0;
                order_item.VIPSalePoint = 0;
                order_item.VIPTotalSalePoint = 0;
                order_item.StaffPoint = 0;
                order_item.TotalStaffPoint = 0;
                orderitems.Add(order_item);
            }
            int orderid = 0;
            Mall_CouponUser coupon_user = null;
            if (order.CouponUserID > 0)
            {
                coupon_user = Mall_CouponUser.GetMall_CouponUser(order.CouponUserID);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    order.Save(helper);
                    payment.OrderID = order.ID;
                    payment.Save(helper);
                    foreach (var item in request_list)
                    {
                        item.OrderID = order.ID;
                        item.Save(helper);
                    }
                    foreach (var item in orderitems)
                    {
                        item.OrderID = order.ID;
                        item.Save(helper);
                    }
                    orderid = order.ID;
                    if (coupon_user != null)
                    {
                        coupon_user.IsUsed = true;
                        coupon_user.UseTime = DateTime.Now;
                        coupon_user.UseType = 3;
                        coupon_user.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "createfeeorder", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "内部异常");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, new { id = orderid });
            return;
        }
        private void getroomfeeorderlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int paymentid = WebUtil.GetIntValue(context, "paymentid");
            var payment = Foresight.DataAccess.Payment.GetPayment(paymentid);
            if (payment == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "paymentid不合法");
                return;
            }
            var list = Foresight.DataAccess.Payment_Request.GetPayment_RequestByPaymentID(paymentid);
            List<Dictionary<string, object>> productlist = new List<Dictionary<string, object>>();
            decimal totalprice = 0;
            foreach (var item in list)
            {
                var room_fee = RoomFeeAnalysis.GetRoomFeeAnalysisByEndTime(item.RoomFeeID, item.EndTime, uid);
                if (room_fee == null)
                {
                    continue;
                }
                string title = room_fee.FullName + "-" + room_fee.RoomName + "(" + room_fee.Name + ")";
                string start_time = room_fee.CalculateStartTime > DateTime.MinValue ? room_fee.CalculateStartTime.ToString("yyyy-MM-dd") : "--";
                string end_time = room_fee.CalculateEndTime > DateTime.MinValue ? room_fee.CalculateEndTime.ToString("yyyy-MM-dd") : "--";
                string desc = start_time + " 至 " + end_time;
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic["ID"] = item.ID;
                dic["productid"] = 0;
                dic["variantid"] = 0;
                dic["imageurl"] = "../image/icons/wuyejiaofei_order.png";
                dic["title"] = title;
                dic["desc"] = desc;
                dic["pricedesc"] = "￥" + item.TotalCost;
                dic["price"] = item.TotalCost;
                dic["salepoint"] = 0;
                dic["quantity"] = "x1";
                productlist.Add(dic);
                totalprice += item.TotalCost;
            }
            if (productlist.Count == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有相关费项");
                return;
            }
            string totalpricedesc = "￥" + totalprice.ToString("0.00");
            var productsummary = new { totaldesc = "共" + productlist.Count.ToString() + "项", totalprice = totalprice, totalpricedesc = totalpricedesc, totalsalepoint = 0 };
            var couponlist = new List<Dictionary<string, object>>();
            var allcouponlist = Mall_CouponUserDetail.GetOrderMall_CouponUserDicList(totalprice, 0, uid, out couponlist, PaymentID: paymentid);
            WebUtil.WriteJsonResult(context, new { productlist = productlist, productsummary = productsummary, ordersummary = new { totalprice = totalprice, totalsalepoint = 0 }, couponlist = couponlist, allcouponlist = allcouponlist });
        }
        private void readypayroomfee(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            string idlist = context.Request["idlist"];
            List<Utility.APPPayModel> ListOption = new List<Utility.APPPayModel>();
            if (!string.IsNullOrEmpty(idlist))
            {
                ListOption = JsonConvert.DeserializeObject<List<Utility.APPPayModel>>(idlist);
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
                        int PayStatus = APPCode.PaymentHelper.OrderQuery(exist_tradeno);
                        if (PayStatus == 2)
                        {
                            WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "选中的账单已支付成功");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteError(LogModuel, "readypayroomfee.OrderQuery", ex);
                    }
                }
            }
            int total_fee = Convert.ToInt32(WebUtil.GetDecimalValue(context, "total_fee") * 100);
            string tradeno = WxPayApi.GenerateOutTradeNo();
            List<Payment_Request> request_list = new List<Payment_Request>();
            Mall_Order.UpdateMall_OrderListByRoomFeeIDList(ListOption.Select(p => p.ID).ToArray());
            foreach (var item in ListOption)
            {
                var payment_request = new Payment_Request();
                payment_request.RoomFeeID = item.ID;
                payment_request.EndTime = item.EndTime.HasValue ? Convert.ToDateTime(item.EndTime) : DateTime.MinValue;
                payment_request.AddMan = user.LoginName;
                payment_request.TotalCost = item.TotalCost;
                payment_request.AddTime = DateTime.Now;
                request_list.Add(payment_request);
            }
            var payment = Payment.Insert_Payment(total_fee, Utility.EnumModel.PaymentTypeDefine.app_wx.ToString(), tradeno, 1, user.LoginName, "APP支付申请", fee_list: roomfee_list.ToList(), request_list: request_list);
            WebUtil.WriteJsonResult(context, new { paymentid = payment.ID });
        }
        private void getroomfeehistorybyuid(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            var historylist = Foresight.DataAccess.PrintRoomFeeHistory.GetPrintRoomFeeHistoryListByOpenID(string.Empty, RoomID).Where(p => p.RealCost > 0).OrderByDescending(p => p.RealCost).OrderByDescending(p => p.ChargeTime);
            List<Utility.RoomFeeModel> list = new List<Utility.RoomFeeModel>();
            Utility.RoomFeeModel roomFeeModel = null;
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
                roomFeeModel = new Utility.RoomFeeModel();
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
        private void getroomfeebyid(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "id");
            DateTime EndTime = WebUtil.GetDateValue(context, "endtime");
            var roomfee = RoomFeeAnalysis.GetRoomFeeAnalysisByEndTime(ID, EndTime);
            var totalcost = roomfee == null ? 0 : roomfee.TotalCost;
            WebUtil.WriteJsonResult(context, new { TotalCost = totalcost });
        }
        private void checkconnectroom(HttpContext context)
        {
            bool openerror = false;
            if (context.Request["openerror"] != null)
            {
                bool.TryParse(context.Request["openerror"], out openerror);
            }
            Foresight.DataAccess.User user = null;
            int uid = 0;
            if (openerror)
            {
                try
                {
                    uid = GetUID(context, out user);
                }
                catch (Exception)
                {
                }
            }
            else
            {
                uid = GetUID(context, out user);
            }
            if (user == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请先登录");
                return;
            }
            var phone_list = RoomPhoneRelation.GetRoomPhoneRelationsByPhone(user.LoginName, user.FinalUserID);
            if (phone_list.Length == 0)
            {
                var list = Mall_UserProject.GetMall_UserProjectListByUserID_ProjectID(uid, SelfUserID: user.UserID);
                if (list.Length == 0)
                {
                    if (openerror)
                    {
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请先绑定房间");
                        return;
                    }
                    WebUtil.WriteJsonError(context, ErrorCode.UNROOMCONNECTED, "请先绑定房间");
                    return;
                }
            }
            Mall_UserProject.Insert_UserProjectList(phone_list, user);
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getroomfeebyuid(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            ViewRoomBasic[] roomlist = new ViewRoomBasic[] { };
            List<Dictionary<string, object>> roomitems = new List<Dictionary<string, object>>();
            string OwnerName = string.Empty;
            string FullName = string.Empty;
            if (RoomID <= 0)
            {
                roomlist = ViewRoomBasic.GetViewRoomBasicListByUserID(user, IncludeRelation: false, PhoneNumber: user.LoginName);
                if (roomlist.Length == 0)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请先绑定房间");
                    return;
                }
                roomitems = roomlist.Select(p =>
                {
                    var dic = new Dictionary<string, object>();
                    dic["id"] = p.RoomID;
                    dic["ID"] = p.RoomID;
                    dic["text"] = p.FullName.Replace("-", "") + p.Name;
                    dic["Name"] = p.FullName.Replace("-", "") + p.Name;
                    return dic;
                }).ToList();
            }
            bool showall = false;
            bool.TryParse(context.Request.Params["showall"], out showall);
            RoomFeeAnalysis[] feelist = new RoomFeeAnalysis[] { };
            int[] summaryidlist = new int[] { };
            if (showall)
            {
                feelist = RoomFeeAnalysis.GetRoomFeeAnalysisListByUserID(uid, 0).Where(p => p.TotalFinalCost > 0).ToArray();
                summaryidlist = feelist.Select(p => p.ChargeID).ToArray();
            }
            else if (RoomID <= 0 && roomlist.Length > 0)
            {
                RoomID = roomlist[0].RoomID;
                OwnerName = roomlist[0].RelationName;
                FullName = roomlist[0].FullName.Replace("-", "") + roomlist[0].Name;
                foreach (var item in roomlist)
                {
                    if (feelist.Length > 0)
                    {
                        RoomID = item.RoomID;
                        OwnerName = feelist[0].FinalCustomerName;
                        FullName = feelist[0].FullName.Replace("-", "") + feelist[0].RoomName;
                        summaryidlist = feelist.Select(p => p.ChargeID).ToArray();
                        break;
                    }
                    feelist = RoomFeeAnalysis.GetRoomFeeAnalysisListByUserID(uid, item.RoomID).Where(p => p.TotalFinalCost > 0).ToArray();
                }
            }
            else
            {
                feelist = RoomFeeAnalysis.GetRoomFeeAnalysisListByUserID(uid, RoomID).Where(p => p.TotalFinalCost > 0).ToArray();
                if (feelist.Length > 0)
                {
                    OwnerName = feelist[0].FinalCustomerName;
                    FullName = feelist[0].FullName.Replace("-", "") + feelist[0].RoomName;
                    summaryidlist = feelist.Select(p => p.ChargeID).ToArray();
                }
            }
            var summarylist = ChargeSummary.GetChargeSummaries();
            List<Utility.RoomFeeModel> list = new List<Utility.RoomFeeModel>();
            Utility.RoomFeeModel roomFeeModel = null;
            decimal HeJiCost = 0;
            foreach (var fee in feelist)
            {
                roomFeeModel = new Utility.RoomFeeModel();
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
            roomFeeModel = new Utility.RoomFeeModel();
            roomFeeModel.Name = "合计";
            roomFeeModel.TotalCost = HeJiCost;
            WebUtil.WriteJsonResult(context, new { summarylist = list, idlist = feelist.Select(p => p.ID).ToList(), HeJiCost = HeJiCost, roomlist = roomitems, totalsummary = roomFeeModel, RoomID = RoomID, OwnerName = OwnerName, FullName = FullName });
        }
        private void thridbindlogin(HttpContext context)
        {
            string LoginName = context.Request["Username"];
            string password = context.Request["password"];
            string verifycode = context.Request["verifycode"];
            string OpenID = context.Request["openid"];
            int type = WebUtil.GetIntValue(context, "type");
            var wechatVerifyCode = Wechat_VerifyCode.GetWechat_VerifyCodeByUserOpenId(string.Empty, LoginName, DateTime.Now);
            if (wechatVerifyCode == null || !wechatVerifyCode.VerifyCode.Equals(verifycode))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "验证码不正确");
                return;
            }
            var user = Foresight.DataAccess.User.GetAPPUserByLoginName(LoginName);
            if (type == 8)
            {
                if (user != null && !string.IsNullOrEmpty(user.APPWxOpenID) && !user.APPWxOpenID.Equals(OpenID))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码已被使用");
                    return;
                }
                if (user == null)
                {
                    user = Foresight.DataAccess.User.GetAPPUserByWxOpenID(OpenID);
                }
            }
            else if (type == 9)
            {
                if (user != null && !string.IsNullOrEmpty(user.APPQQOpenID) && !user.APPQQOpenID.Equals(OpenID))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码已被使用");
                    return;
                }
                if (user == null)
                {
                    user = Foresight.DataAccess.User.GetAPPUserByQQOpenID(OpenID);
                }
            }
            else if (type == 10)
            {
                if (user != null && !string.IsNullOrEmpty(user.APPWeiBoUserID) && !user.APPWeiBoUserID.Equals(OpenID))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码已被使用");
                    return;
                }
                if (user == null)
                {
                    user = Foresight.DataAccess.User.GetAPPUserByWeiboUserID(OpenID);
                }
            }
            else
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法登录");
                return;
            }
            if (user == null)
            {
                user = new Foresight.DataAccess.User();
                user.CreateTime = DateTime.Now;
                user.Type = UserTypeDefine.APPCustomer.ToString();
            }
            if (type == 8)
            {
                user.APPWxOpenID = OpenID;
            }
            else if (type == 9)
            {
                user.APPQQOpenID = OpenID;
            }
            else if (type == 10)
            {
                user.APPWeiBoUserID = OpenID;
            }
            user.LoginName = LoginName;
            user.Password = User.EncryptPassword(password);
            user.PhoneNumber = LoginName;
            user.IsLocked = false;
            if (!string.IsNullOrEmpty(context.Request["device_id"]))
            {
                user.DeviceId = context.Request["device_id"];
            }
            user.DeviceType = context.Request["device_type"];
            bool isfamily = false;
            int parentuid = 0;
            Foresight.DataAccess.User parent_user = null;
            if (user.Type.Equals(UserTypeDefine.APPCustomerFamily.ToString()))
            {
                parent_user = Foresight.DataAccess.User.GetUser(user.FinalParentUserID);
                if (parent_user == null)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该家庭账号主账号已被删除,登录失败");
                    return;
                }
                if (!parent_user.Type.Equals(UserTypeDefine.APPCustomer.ToString()))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该家庭账号主账号异常,登录失败");
                    return;
                }
                if (user.IsLocked)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该家庭账号主账号已被锁定,登录失败");
                    return;
                }
                parentuid = parent_user.UserID;
                isfamily = true;
            }
            var phone_list = RoomPhoneRelation.GetRoomPhoneRelationsByPhone(user.LoginName, uid: user.FinalUserID);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    wechatVerifyCode.IsUsed = true;
                    wechatVerifyCode.Save(helper);
                    user.Save(helper);
                    Mall_UserProject.Insert_UserProjectList(phone_list, user, helper);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.ServerError, "服务器出问题了");
                    return;
                }
            }
            if (!string.IsNullOrEmpty(OpenID))
            {
                string uid = string.Empty;
                string familyuid = string.Empty;
                if (parentuid > 0)
                {
                    uid = EncriptUID(parentuid);
                    familyuid = EncriptUID(user.UserID);
                }
                else
                {
                    uid = EncriptUID(user.UserID);
                }
                string headimg = string.IsNullOrEmpty(user.HeadImg) ? "" : WebUtil.GetContextPath() + user.HeadImg;
                string RealName = string.IsNullOrEmpty(user.NickName) ? "匿名用户" : user.NickName;
                WebUtil.WriteJsonResult(context, new { uid = uid, username = RealName, headimg = headimg, phonenumber = user.PhoneNumber, sex = user.Gender, familyuid = familyuid, isfamily = isfamily });
                return;
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void completeregister(HttpContext context)
        {
            string LoginName = context.Request["Username"];
            string password = context.Request["password"];
            string verifycode = context.Request["verifycode"];
            var wechatVerifyCode = Wechat_VerifyCode.GetWechat_VerifyCodeByUserOpenId(string.Empty, LoginName, DateTime.Now);
            if (wechatVerifyCode == null || !wechatVerifyCode.VerifyCode.Equals(verifycode))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "验证码不正确");
                return;
            }
            string UserType = context.Request["UserType"];
            var user = Foresight.DataAccess.User.GetAPPUserByLoginName(LoginName);
            if (user != null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码已被使用");
                return;
            }
            UserType = string.IsNullOrEmpty(UserType) ? UserTypeDefine.APPCustomer.ToString() : UserType;
            user = new Foresight.DataAccess.User();
            user.CreateTime = DateTime.Now;
            user.Type = UserType;
            user.LoginName = LoginName;
            user.Password = User.EncryptPassword(password);
            user.PhoneNumber = LoginName;
            user.IsLocked = false;
            string DeviceId = context.Request["device_id"];
            string DeviceType = context.Request["device_type"];
            if (!string.IsNullOrEmpty(DeviceId))
            {
                user.DeviceId = context.Request["device_id"];
                user.DeviceType = DeviceType;
            }
            var phone_list = RoomPhoneRelation.GetRoomPhoneRelationsByPhone(user.LoginName, user.FinalUserID);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    wechatVerifyCode.IsUsed = true;
                    wechatVerifyCode.Save(helper);
                    user.Save(helper);
                    Mall_UserProject.Insert_UserProjectList(phone_list, user, helper);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.ServerError, "服务器出问题了");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void registercheckphone(HttpContext context)
        {
            string LoginName = context.Request["Username"];
            int type = WebUtil.GetIntValue(context, "type");
            string openid = context.Request["openid"];
            string UserType = context.Request["UserType"];
            var user = Foresight.DataAccess.User.GetAPPUserByLoginName(LoginName, UserType: UserType);
            if (!string.IsNullOrEmpty(openid))
            {
                if (type == 8)
                {
                    if (user != null && !user.APPWxOpenID.Equals(openid) && !string.IsNullOrEmpty(user.APPWxOpenID))
                    {
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码已被使用");
                        return;
                    }
                }
                else if (type == 9)
                {
                    if (user != null && !user.APPQQOpenID.Equals(openid) && !string.IsNullOrEmpty(user.APPQQOpenID))
                    {
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码已被使用");
                        return;
                    }
                }
                else if (type == 10)
                {
                    if (user != null && !user.APPWeiBoUserID.Equals(openid) && !string.IsNullOrEmpty(user.APPWeiBoUserID))
                    {
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码已被使用");
                        return;
                    }
                }
            }
            else if (user != null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码已被使用");
                return;
            }
            string content = "验证码{0}，请在15分钟内按页面提示输入验证码，切勿将验证码泄露于他人。";
            string VerifyCode = Utility.Tools.SendVerifyCode(LoginName, content);
            Foresight.DataAccess.Wechat_VerifyCode.SaveWechatVerifyCode(LoginName, VerifyCode);
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void sendphoneverifycode(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            string PhoneNumber = context.Request["PhoneNumber"];
            string content = "验证码{0}，请在15分钟内按页面提示输入验证码，切勿将验证码泄露于他人。";
            string VerifyCode = Utility.Tools.SendVerifyCode(PhoneNumber, content);
            Foresight.DataAccess.Wechat_VerifyCode.SaveWechatVerifyCode(PhoneNumber, VerifyCode);
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getexisitphoneverifycode(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            string phonenumber = context.Request["Username"];
            int id = WebUtil.GetIntValue(context, "id");
            Foresight.DataAccess.User main_user = null;
            if (id > 0)
            {
                main_user = Foresight.DataAccess.User.GetAPPUserByFamilyUserID(id);
            }
            var exist_user_list = Foresight.DataAccess.User.GetAPPUserListByLoginName(phonenumber);
            Foresight.DataAccess.User exist_user = null;
            if (exist_user_list.Length > 0)
            {
                exist_user = exist_user_list.FirstOrDefault(p => p.Type.Equals(UserTypeDefine.APPUser.ToString()));
                if (exist_user != null)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码为员工账号");
                    return;
                }
                exist_user = exist_user_list.FirstOrDefault(p => p.Type.Equals(UserTypeDefine.APPCustomer.ToString()));
                if (exist_user != null)
                {
                    var child_user_list = Foresight.DataAccess.User.GetAPPUserListByParentUserID(exist_user.UserID);
                    if (child_user_list.Length > 0)
                    {
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码已有家庭成员");
                        return;
                    }
                }
                exist_user = exist_user_list.FirstOrDefault(p => p.Type.Equals(UserTypeDefine.APPCustomerFamily.ToString()));
                if (exist_user != null && main_user == null)
                {
                    var my_parent_user = Foresight.DataAccess.User.GetUser(exist_user.FinalParentUserID);
                    if (my_parent_user != null)
                    {
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码为已经是家庭成员");
                        return;
                    }
                }
            }
            if (main_user != null && main_user.FinalParentUserID != uid)
            {
                var my_parent_user = Foresight.DataAccess.User.GetUser(main_user.FinalParentUserID);
                if (my_parent_user != null)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号码为已经是家庭成员");
                    return;
                }
            }
            string content = "验证码{0}，请在15分钟内按页面提示输入验证码，切勿将验证码泄露于他人。";
            string VerifyCode = Utility.Tools.SendVerifyCode(phonenumber, content);
            Foresight.DataAccess.Wechat_VerifyCode.SaveWechatVerifyCode(phonenumber, VerifyCode);
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void firstloginsaveuser(HttpContext context)
        {
            string LoginName = context.Request["Username"];
            string password = context.Request["password"];
            string verifycode = context.Request["verifycode"];
            var wechatVerifyCode = Wechat_VerifyCode.GetWechat_VerifyCodeByUserOpenId(string.Empty, LoginName, DateTime.Now);
            if (wechatVerifyCode == null || !wechatVerifyCode.VerifyCode.Equals(verifycode))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "验证码不正确");
                return;
            }
            var user = Foresight.DataAccess.User.GetAPPUserByLoginName(LoginName);
            if (user != null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前帐号已存在，请使用找回密码");
                return;
            }
            var phone_list = RoomPhoneRelation.GetRoomPhoneRelationsByPhone(LoginName);
            if (phone_list.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前手机号没有认证的房源");
                return;
            }
            user = new Foresight.DataAccess.User();
            user.CreateTime = DateTime.Now;
            user.LoginName = LoginName;
            user.Password = User.EncryptPassword(password);
            user.PhoneNumber = LoginName;
            user.IsLocked = false;
            user.Type = UserTypeDefine.APPCustomer.ToString();
            if (!string.IsNullOrEmpty(context.Request["device_id"]))
            {
                user.DeviceId = context.Request["device_id"];
            }
            user.DeviceType = context.Request["device_type"];
            List<Mall_UserProject> mall_user_project_list = new List<Mall_UserProject>();
            foreach (var item in phone_list)
            {
                var mall_user_project = new Foresight.DataAccess.Mall_UserProject();
                mall_user_project.ProjectID = item.RoomID;
                mall_user_project_list.Add(mall_user_project);
            }
            user.RelationID = phone_list[0].ID;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    wechatVerifyCode.IsUsed = true;
                    wechatVerifyCode.Save(helper);
                    user.Save(helper);
                    Mall_UserProject.Insert_UserProjectList(phone_list, user, helper);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.ServerError, "服务器出问题了");
                    return;
                }
            }
            string uid = EncriptUID(user.UserID);
            string headimg = string.IsNullOrEmpty(user.HeadImg) ? "" : WebUtil.GetContextPath() + user.HeadImg;
            string RealName = string.IsNullOrEmpty(user.NickName) ? "匿名用户" : user.NickName;
            WebUtil.WriteJsonResult(context, new { uid = uid, username = RealName, headimg = headimg, phonenumber = user.PhoneNumber, sex = user.Gender });
        }
        private void socketinit(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = 0;
            try
            {
                uid = GetUID(context, out user);
            }
            catch (Exception)
            {
            }
            if (user == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "未登录");
                return;
            }
            var config = new Utility.SiteConfig();
            string socketserverurl = config.SocketURL;
            WebUtil.WriteJsonResult(context, new { loginname = Web.WebUtil.GetUserLoginFullName(context) + user.LoginName, url = WebUtil.GetContextPath(), guid = Guid.NewGuid().ToString(), socketserverurl = socketserverurl });
        }
        private void dologin(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            string openid = context.Request["openid"];
            int logintype = WebUtil.GetIntValue(context, "logintype");
            RoomPhoneRelation[] phone_list = new RoomPhoneRelation[] { };
            if (!string.IsNullOrEmpty(openid))
            {
                if (logintype == 8)
                {
                    user = Foresight.DataAccess.User.GetAPPUserByWxOpenID(openid);
                }
                else if (logintype == 9)
                {
                    user = Foresight.DataAccess.User.GetAPPUserByQQOpenID(openid);
                }
                else if (logintype == 10)
                {
                    user = Foresight.DataAccess.User.GetAPPUserByWeiboUserID(openid);
                }
                if (user == null)
                {
                    WebUtil.WriteJsonResult(context, new { needphone = true });
                    return;
                }
            }
            else
            {
                string LoginName = context.Request["Username"];
                string Password = context.Request["Password"];
                if (string.IsNullOrEmpty(LoginName))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "用户名不能为空");
                    return;
                }
                if (string.IsNullOrEmpty(Password))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "密码不能为空");
                    return;
                }
                user = User.GetAPPUserByLoginNamePassWord(LoginName, Password);
                if (user == null)
                {
                    var exist_user = User.GetAPPUserByLoginName(LoginName);
                    if (exist_user != null)
                    {
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "用户名或密码错误");
                        return;
                    }
                    phone_list = RoomPhoneRelation.GetRoomPhoneRelationsByPhone(LoginName);
                    if (phone_list.Length == 0)
                    {
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "用户名或密码错误");
                        return;
                    }
                    WebUtil.WriteJsonResult(context, new { firstlogin = true });
                    return;
                }
            }
            if (!user.Type.Equals(UserTypeDefine.APPCustomer.ToString()) && !user.Type.Equals(UserTypeDefine.APPCustomerFamily.ToString()) && !user.Type.Equals(UserTypeDefine.APPUser.ToString()))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "用户名或密码错误");
                return;
            }
            if (user.IsLocked)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "帐号已被锁定,登录失败");
                return;
            }
            string uid = string.Empty;
            string familyuid = string.Empty;
            bool IsFamily = false;
            int UserID = user.UserID;
            int ParentUserID = 0;
            if (user.Type.Equals(UserTypeDefine.APPCustomerFamily.ToString()))
            {
                IsFamily = true;
                var parent_user = Foresight.DataAccess.User.GetUser(user.FinalParentUserID);
                if (parent_user == null)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该家庭账号主账号已被删除,登录失败");
                    return;
                }
                if (!parent_user.Type.Equals(UserTypeDefine.APPCustomer.ToString()))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该家庭账号主账号异常,登录失败");
                    return;
                }
                if (user.IsLocked)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该家庭账号主账号已被锁定,登录失败");
                    return;
                }
                uid = EncriptUID(parent_user.UserID);
                familyuid = EncriptUID(user.UserID);
                ParentUserID = parent_user.UserID;
            }
            else
            {
                uid = EncriptUID(user.UserID);
            }
            if (!string.IsNullOrEmpty(context.Request["device_id"]))
            {
                user.DeviceId = context.Request["device_id"];
            }
            user.DeviceType = context.Request["device_type"];
            phone_list = RoomPhoneRelation.GetRoomPhoneRelationsByPhone(user.LoginName, user.FinalUserID);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    user.Save(helper);
                    Mall_UserProject.Insert_UserProjectList(phone_list, user, helper);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "login", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                    return;
                }
            }
            bool isappuser = user.Type.Equals(UserTypeDefine.APPUser.ToString());
            string headimg = string.IsNullOrEmpty(user.HeadImg) ? "" : WebUtil.GetContextPath() + user.HeadImg;
            string RealName = string.IsNullOrEmpty(user.NickName) ? "匿名用户" : user.NickName;
            WebUtil.WriteJsonResult(context, new { uid = uid, username = RealName, headimg = headimg, phonenumber = user.PhoneNumber, sex = user.Gender, isfamily = IsFamily, familyuid = familyuid, isappuser = isappuser });
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        static int GetUID(HttpContext context)
        {
            var uidStr = context.Request["uid"];
            if (!string.IsNullOrEmpty(uidStr))
            {
                var uid = 0;
                try
                {
                    var ticket = System.Web.Security.FormsAuthentication.Decrypt(uidStr);
                    uid = Convert.ToInt32(ticket.Name);
                }
                catch (Exception ex)
                {
                    throw new Exception("get_uid_failed", ex);
                }
                return uid;
            }
            else
            {
                throw new Exception("get_uid_failed");
            }
        }
        static int GetUID(HttpContext context, out Foresight.DataAccess.User user)
        {
            user = null;
            var uidStr = context.Request["uid"];
            var userkey = context.Request["userkey"];
            if (!string.IsNullOrEmpty(uidStr))
            {
                int uid = 0;
                try
                {
                    var ticket = System.Web.Security.FormsAuthentication.Decrypt(uidStr);
                    uid = Convert.ToInt32(ticket.Name);
                }
                catch (Exception ex)
                {
                    throw new Exception("get_uid_failed", ex);
                }
                user = Foresight.DataAccess.User.GetUser(uid);
                if (user == null)
                {
                    throw new Exception("get_uid_failed");
                }
                var familyuidStr = context.Request["familyuid"];
                int familyuid = 0;
                if (!string.IsNullOrEmpty(familyuidStr))
                {
                    try
                    {
                        var ticket = System.Web.Security.FormsAuthentication.Decrypt(familyuidStr);
                        familyuid = Convert.ToInt32(ticket.Name);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("get_uid_failed", ex);
                    }
                    user = Foresight.DataAccess.User.GetUser(familyuid);
                    if (user == null)
                    {
                        throw new Exception("get_uid_failed");
                    }
                }
                return uid;
            }
            else if (!string.IsNullOrEmpty(userkey))
            {
                int uid = 0;
                try
                {
                    string userkeyStr = Utility.Tools.Decrypt(userkey);
                    uid = Convert.ToInt32(userkeyStr);
                }
                catch (Exception ex)
                {
                    throw new Exception("参数userkey无效", ex);
                }
                user = Foresight.DataAccess.User.GetUser(uid);
                if (user == null)
                {
                    throw new Exception("参数userkey无效");
                }
                return uid;
            }
            else
            {
                throw new Exception("get_uid_failed");
            }
        }
        static string EncriptUID(int UserID)
        {
            var ticket = new System.Web.Security.FormsAuthenticationTicket(1, UserID.ToString(), DateTime.Now,
                      DateTime.Now.AddYears(1), true, string.Empty);
            string uid = System.Web.Security.FormsAuthentication.Encrypt(ticket);
            return uid;
        }
    }
}