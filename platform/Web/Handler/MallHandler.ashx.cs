using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using Foresight.DataAccess.Ui;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace Web.Handler
{
    /// <summary>
    /// MallHandler 的摘要说明
    /// </summary>
    public class MallHandler : IHttpHandler, IRequiresSessionState
    {
        const string LogModule = "MallHandler";

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug(LogModule, "visit为空");
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "savemallcategory":
                        savemallcategory(context);
                        break;
                    case "getmallcategorypic":
                        getmallcategorypic(context);
                        break;
                    case "deletemallcategorypic":
                        deletemallcategorypic(context);
                        break;
                    case "loadmallcategorygrid":
                        loadmallcategorygrid(context);
                        break;
                    case "removemallcategory":
                        removemallcategory(context);
                        break;
                    case "savemallbusiness":
                        savemallbusiness(context);
                        break;
                    case "getmallbusinesspic":
                        getmallbusinesspic(context);
                        break;
                    case "deletemallbusinesspic":
                        deletemallbusinesspic(context);
                        break;
                    case "loadmallbusinessgrid":
                        loadmallbusinessgrid(context);
                        break;
                    case "removemallbusiness":
                        removemallbusiness(context);
                        break;
                    case "approvemallbusiness":
                        approvemallbusiness(context);
                        break;
                    case "getmallproducteditcategorytreeparams":
                        getmallproducteditcategorytreeparams(context);
                        break;
                    case "getmallproducteditparams":
                        getmallproducteditparams(context);
                        break;
                    case "savemallproduct":
                        savemallproduct(context);
                        break;
                    case "loadmallproductgrid":
                        loadmallproductgrid(context);
                        break;
                    case "removemallproduct":
                        removemallproduct(context);
                        break;
                    case "getmallproductpics":
                        getmallproductpics(context);
                        break;
                    case "deletemallproductpic":
                        deletemallproductpic(context);
                        break;
                    case "savemallproductcategories":
                        savemallproductcategories(context);
                        break;
                    case "savemallproductprices":
                        savemallproductprices(context);
                        break;
                    case "offlinemallproduct":
                        offlinemallproduct(context);
                        break;
                    case "getmallbusinesseditparams":
                        getmallbusinesseditparams(context);
                        break;
                    case "getmallproductvariants":
                        getmallproductvariants(context);
                        break;
                    case "removemallproductvariant":
                        removemallproductvariant(context);
                        break;
                    case "getmallproductpricelist":
                        getmallproductpricelist(context);
                        break;
                    case "loadmallordergrid":
                        loadmallordergrid(context);
                        break;
                    case "loadmallorderitemgrid":
                        loadmallorderitemgrid(context);
                        break;
                    case "getmallapprotatingimage":
                        getmallapprotatingimage(context);
                        break;
                    case "savemallapprotatingimg":
                        savemallapprotatingimg(context);
                        break;
                    case "deletemallapprotatingimg":
                        deletemallapprotatingimg(context);
                        break;
                    case "deletemallbusinesscoverimg":
                        deletemallbusinesscoverimg(context);
                        break;
                    case "getconfigcity":
                        getconfigcity(context);
                        break;
                    case "saveconfigcity":
                        saveconfigcity(context);
                        break;
                    case "getmallproductpinuserlist":
                        getmallproductpinuserlist(context);
                        break;
                    case "closemallpinuser":
                        closemallpinuser(context);
                        break;
                    case "createmallpinorder":
                        createmallpinorder(context);
                        break;
                    case "dopaymallorder":
                        dopaymallorder(context);
                        break;
                    case "savemallordership":
                        savemallordership(context);
                        break;
                    case "completemallorder":
                        completemallorder(context);
                        break;
                    case "closemallorder":
                        closemallorder(context);
                        break;
                    case "loadmallcouponcodegrid":
                        loadmallcouponcodegrid(context);
                        break;
                    case "savemallcouponcode":
                        savemallcouponcode(context);
                        break;
                    case "getmallproductbyids":
                        getmallproductbyids(context);
                        break;
                    case "removemallcouponcode":
                        removemallcouponcode(context);
                        break;
                    case "getbindprojectlist":
                        getbindprojectlist(context);
                        break;
                    case "canceluserbind":
                        canceluserbind(context);
                        break;
                    case "getmallsuggestiongrid":
                        getmallsuggestiongrid(context);
                        break;
                    case "saveaboutus":
                        saveaboutus(context);
                        break;
                    case "approvemallproduct":
                        approvemallproduct(context);
                        break;
                    case "getmallrotatingimagegrid":
                        getmallrotatingimagegrid(context);
                        break;
                    case "deleteroatingimage":
                        deleteroatingimage(context);
                        break;
                    case "saverotatingimage":
                        saverotatingimage(context);
                        break;
                    case "removerotatingimageurl":
                        removerotatingimageurl(context);
                        break;
                    case "saveconfigparam":
                        saveconfigparam(context);
                        break;
                    case "removemallorder":
                        removemallorder(context);
                        break;
                    case "savebusinessconfigparam":
                        savebusinessconfigparam(context);
                        break;
                    case "loadmallpointrulegrid":
                        loadmallpointrulegrid(context);
                        break;
                    case "savemallpointrule":
                        savemallpointrule(context);
                        break;
                    case "removemallraterule":
                        removemallraterule(context);
                        break;
                    case "startmallraterule":
                        startmallraterule(context);
                        break;
                    case "stopmallraterule":
                        stopmallraterule(context);
                        break;
                    case "loadmallshipcompanygrid":
                        loadmallshipcompanygrid(context);
                        break;
                    case "savemallshipcompany":
                        savemallshipcompany(context);
                        break;
                    case "removemallshipcompany":
                        removemallshipcompany(context);
                        break;
                    case "getmallorderlistparams":
                        getmallorderlistparams(context);
                        break;
                    case "getdoordershipparams":
                        getdoordershipparams(context);
                        break;
                    case "loadmalltaggrid":
                        loadmalltaggrid(context);
                        break;
                    case "savemalltag":
                        savemalltag(context);
                        break;
                    case "removemalltag":
                        removemalltag(context);
                        break;
                    case "getmalltagparams":
                        getmalltagparams(context);
                        break;
                    case "getmallorderlistbyvue":
                        getmallorderlistbyvue(context);
                        break;
                    case "savemallordercost":
                        savemallordercost(context);
                        break;
                    case "savemallordernote":
                        savemallordernote(context);
                        break;
                    case "getmalldoordevicegrid":
                        getmalldoordevicegrid(context);
                        break;
                    case "getmalldoordeviceeditparams":
                        getmalldoordeviceeditparams(context);
                        break;
                    case "savemalldoordevice":
                        savemalldoordevice(context);
                        break;
                    case "deletedoordevice":
                        deletedoordevice(context);
                        break;
                    case "getmalldoorcardeditparams":
                        getmalldoorcardeditparams(context);
                        break;
                    case "loadmallprojectusergrid":
                        loadmallprojectusergrid(context);
                        break;
                    case "savemalldoorcard":
                        savemalldoorcard(context);
                        break;
                    case "getmalldoorcardgrid":
                        getmalldoorcardgrid(context);
                        break;
                    case "getmalldoorcardanalysisgrid":
                        getmalldoorcardanalysisgrid(context);
                        break;
                    case "deletedoorcard":
                        deletedoorcard(context);
                        break;
                    case "loadmallratecustomerlist":
                        loadmallratecustomerlist(context);
                        break;
                    case "deletemallproductcover":
                        deletemallproductcover(context);
                        break;
                    case "savemallshiprate":
                        savemallshiprate(context);
                        break;
                    case "getmallshipratedetails":
                        getmallshipratedetails(context);
                        break;
                    case "removemallshipratedetail":
                        removemallshipratedetail(context);
                        break;
                    case "loadmallshiprategrid":
                        loadmallshiprategrid(context);
                        break;
                    case "removemallshiprate":
                        removemallshiprate(context);
                        break;
                    case "savemallordershiprate":
                        savemallordershiprate(context);
                        break;
                    case "doremoteopendoor":
                        doremoteopendoor(context);
                        break;
                    case "savemallorderrefund":
                        savemallorderrefund(context);
                        break;
                    case "getchatkeywords":
                        getchatkeywords(context);
                        break;
                    case "removechatkeywords":
                        removechatkeywords(context);
                        break;
                    case "savechatkeywords":
                        savechatkeywords(context);
                        break;
                    case "getmallhotsaleeditparams":
                        getmallhotsaleeditparams(context);
                        break;
                    case "savemallhotsale":
                        savemallhotsale(context);
                        break;
                    case "loadmallhotsalegrid":
                        loadmallhotsalegrid(context);
                        break;
                    case "removemallhotsale":
                        removemallhotsale(context);
                        break;
                    case "getmallthreadgrid":
                        getmallthreadgrid(context);
                        break;
                    case "getmallthreadcommentgrid":
                        getmallthreadcommentgrid(context);
                        break;
                    case "removemallthread":
                        removemallthread(context);
                        break;
                    case "removemallthreadcomment":
                        removemallthreadcomment(context);
                        break;
                    case "stopmallthread":
                        stopmallthread(context);
                        break;
                    case "savemalluserforbidden":
                        savemalluserforbidden(context);
                        break;
                    case "getmalluserforbiddengrid":
                        getmalluserforbiddengrid(context);
                        break;
                    case "removemalluserforbidden":
                        removemalluserforbidden(context);
                        break;
                    case "getmalldoorremoteusergrid":
                        getmalldoorremoteusergrid(context);
                        break;
                    case "savemalldoorremoteuser":
                        savemalldoorremoteuser(context);
                        break;
                    case "removedoorremoteuser":
                        removedoorremoteuser(context);
                        break;
                    case "getamountruleeditparam":
                        getamountruleeditparam(context);
                        break;
                    case "savemallamountrule":
                        savemallamountrule(context);
                        break;
                    case "loadmallmemberamountrulegrid":
                        loadmallmemberamountrulegrid(context);
                        break;
                    case "removemallamountrule":
                        removemallamountrule(context);
                        break;
                    case "loadmalldepartmentgrid":
                        loadmalldepartmentgrid(context);
                        break;
                    case "savemalldepartment":
                        savemalldepartment(context);
                        break;
                    case "removemalldepartment":
                        removemalldepartment(context);
                        break;
                    case "getusereditparams":
                        getusereditparams(context);
                        break;
                    case "getcheckcategorytree":
                        getcheckcategorytree(context);
                        break;
                    case "removecheckcategory":
                        removecheckcategory(context);
                        break;
                    case "getmallcheckrulegrid":
                        getmallcheckrulegrid(context);
                        break;
                    case "removemallcheckrules":
                        removemallcheckrules(context);
                        break;
                    case "savemallcheckcategory":
                        savemallcheckcategory(context);
                        break;
                    case "savemallcheckrule":
                        savemallcheckrule(context);
                        break;
                    case "getmallcheckrequestattachs":
                        getmallcheckrequestattachs(context);
                        break;
                    case "deletemallcheckrequestattach":
                        deletemallcheckrequestattach(context);
                        break;
                    case "getmallcheckrequestrulelist":
                        getmallcheckrequestrulelist(context);
                        break;
                    case "removemallcheckrequestrule":
                        removemallcheckrequestrule(context);
                        break;
                    case "savemallusercheck":
                        savemallusercheck(context);
                        break;
                    case "loadmallusercheckgrid":
                        loadmallusercheckgrid(context);
                        break;
                    case "removemallusercheck":
                        removemallusercheck(context);
                        break;
                    case "domallusercheckapplication":
                        domallusercheckapplication(context);
                        break;
                    case "approvemallusercheck":
                        approvemallusercheck(context);
                        break;
                    case "processmallusercheck":
                        processmallusercheck(context);
                        break;
                    case "loadmallusercheckpointgrid":
                        loadmallusercheckpointgrid(context);
                        break;
                    case "loadmallmemberpointgrid":
                        loadmallmemberpointgrid(context);
                        break;
                    case "loadmalluserlevelgrid":
                        loadmalluserlevelgrid(context);
                        break;
                    case "savemalluserlevel":
                        savemalluserlevel(context);
                        break;
                    case "removeuserlevel":
                        removeuserlevel(context);
                        break;
                    case "sendmallusercouponcode":
                        sendmallusercouponcode(context);
                        break;
                    case "getmallcouponcodecover":
                        getmallcouponcodecover(context);
                        break;
                    case "deletemallcouponcodecover":
                        deletemallcouponcodecover(context);
                        break;
                    case "getmallproductchangetagparams":
                        getmallproductchangetagparams(context);
                        break;
                    case "savemallproducttags":
                        savemallproducttags(context);
                        break;
                    case "loadmalluserlevelapprovegrid":
                        loadmalluserlevelapprovegrid(context);
                        break;
                    case "approvemalluserlevel":
                        approvemalluserlevel(context);
                        break;
                    case "loadusercoupongrid":
                        loadusercoupongrid(context);
                        break;
                    case "savemallusercoupon":
                        savemallusercoupon(context);
                        break;
                    case "activeusercoupon":
                        activeusercoupon(context);
                        break;
                    case "getmallproductyouxuanlist":
                        getmallproductyouxuanlist(context);
                        break;
                    case "savemallproductyouxuan":
                        savemallproductyouxuan(context);
                        break;
                    case "getmallbusinesssortlist":
                        getmallbusinesssortlist(context);
                        break;
                    case "savemallbusinesssort":
                        savemallbusinesssort(context);
                        break;
                    case "removeusercoupon":
                        removeusercoupon(context);
                        break;
                    case "getuserlevelapproveeditparam":
                        getuserlevelapproveeditparam(context);
                        break;
                    case "saveapprovemalluserlevel":
                        saveapprovemalluserlevel(context);
                        break;
                    case "removeuserlevelapprove":
                        removeuserlevelapprove(context);
                        break;
                    case "startapproveuserlevelapprove":
                        startapproveuserlevelapprove(context);
                        break;
                    case "getdoordersendappparams":
                        getdoordersendappparams(context);
                        break;
                    case "savemallordersendapp":
                        savemallordersendapp(context);
                        break;
                    case "getmalldoorremoteusertimegrid":
                        getmalldoorremoteusertimegrid(context);
                        break;
                    case "delayremoteusertime":
                        delayremoteusertime(context);
                        break;
                    case "savedroorremoteusertime":
                        savedroorremoteusertime(context);
                        break;
                    case "synchdoorcard":
                        synchdoorcard(context);
                        break;
                    case "loadmallbalancerulegrid":
                        loadmallbalancerulegrid(context);
                        break;
                    case "removemallbalancerule":
                        removemallbalancerule(context);
                        break;
                    case "savemallbalancerule":
                        savemallbalancerule(context);
                        break;
                    case "loadmallbusinessbalancegrid":
                        loadmallbusinessbalancegrid(context);
                        break;
                    case "getbalanceapplicationlist":
                        getbalanceapplicationlist(context);
                        break;
                    case "savebalanceapplication":
                        savebalanceapplication(context);
                        break;
                    case "loadmallbalanceapprovegrid":
                        loadmallbalanceapprovegrid(context);
                        break;
                    case "savemallbalanceapprove":
                        savemallbalanceapprove(context);
                        break;
                    case "getroomownerbalanceaddparams":
                        getroomownerbalanceaddparams(context);
                        break;
                    case "savemallroomownerbalance":
                        savemallroomownerbalance(context);
                        break;
                    case "loadmallroomownerbalancegrid":
                        loadmallroomownerbalancegrid(context);
                        break;
                    case "savemallroomownerbalancestatus":
                        savemallroomownerbalancestatus(context);
                        break;
                    case "loadmallmemberamountgrid":
                        loadmallmemberamountgrid(context);
                        break;
                    case "savemallmemberamount":
                        savemallmemberamount(context);
                        break;
                    case "loadmallroomownerbalanceapplicationgrid":
                        loadmallroomownerbalanceapplicationgrid(context);
                        break;
                    case "loadmallroomownerorderlist":
                        loadmallroomownerorderlist(context);
                        break;
                    case "getprintidbyorderid":
                        getprintidbyorderid(context);
                        break;
                    case "loadrequestdiscountgrid":
                        loadrequestdiscountgrid(context);
                        break;
                    case "removerequestdiscount":
                        removerequestdiscount(context);
                        break;
                    case "approverequestdiscount":
                        approverequestdiscount(context);
                        break;
                    case "saveconfigparamfile":
                        saveconfigparamfile(context);
                        break;
                    case "loadmallbusinessdiscountproductgrid":
                        loadmallbusinessdiscountproductgrid(context);
                        break;
                    case "loadcheckpointconvertmgr":
                        loadcheckpointconvertmgr(context);
                        break;
                    case "removecheckpointcovert":
                        removecheckpointcovert(context);
                        break;
                    case "savecheckpointconvert":
                        savecheckpointconvert(context);
                        break;
                    case "loadpointconvertrecordmgr":
                        loadpointconvertrecordmgr(context);
                        break;
                    case "approvecheckpointconvert":
                        approvecheckpointconvert(context);
                        break;
                    case "loadpointwithdrawrecordmgr":
                        loadpointwithdrawrecordmgr(context);
                        break;
                    case "approvecheckpointwithdraw":
                        approvecheckpointwithdraw(context);
                        break;
                    case "getmalldooropenlog":
                        getmalldooropenlog(context);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "visit: " + visit, ex);
                WebUtil.WriteJson(context, new { status = false });
            }
        }
        private void getmalldooropenlog(HttpContext context)
        {
            int page = WebUtil.GetIntValue(context, "page");
            int rows = WebUtil.GetIntValue(context, "rows");
            long startRowIndex = (long)(page - 1) * rows;
            int pageSize = rows;
            string keywords = context.Request["keywords"];
            string RoomIDs = context.Request.Params["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            string ProjectIDs = context.Request.Params["ProjectIDs"];
            List<int> ProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                //ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
            }
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            var dg = Mall_DoorOpenLog.GetMall_DoorOpenLogDataGrid(keywords, startRowIndex, pageSize, ProjectIDList, RoomIDList, StartTime, EndTime, canexport: canexport);
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadDoorOpenLog(dg, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
            }
            else
            {
                WebUtil.WriteJson(context, dg);
            }
        }
        private void approvecheckpointwithdraw(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_PointWithDrawRecord data = Mall_PointWithDrawRecord.GetMall_PointWithDrawRecord(ID);
            data.ApproveRemark = WebUtil.getServerValue(context, "tdApproveRemark");
            data.Status = WebUtil.GetIntValue(context, "Status");
            data.ApproveTime = DateTime.Now;
            data.ApproveUserName = WebUtil.GetUser(context).LoginName;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    var jiXiaoPoint = Mall_UserJiXiaoPoint.GetMall_UserJiXiaoPoint(data.Mall_UserJiXiaoPointID, helper);
                    if (data.Status == 1)
                    {
                        if (jiXiaoPoint != null)
                        {
                            jiXiaoPoint.PointStatus = 1;
                            jiXiaoPoint.Save(helper);
                        }
                    }
                    if (data.Status == 3)
                    {
                        if (jiXiaoPoint != null)
                        {
                            jiXiaoPoint.PointStatus = 0;
                            jiXiaoPoint.Save(helper);
                        }
                    }
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadpointwithdrawrecordmgr(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = Mall_PointWithDrawRecord.GetMall_PointWithDrawRecordGridList(keywords, startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception)
            {
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void approvecheckpointconvert(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_PointCovertRecord data = Mall_PointCovertRecord.GetMall_PointCovertRecord(ID);
            data.ApproveRemark = WebUtil.getServerValue(context, "tdApproveRemark");
            data.Status = WebUtil.GetIntValue(context, "Status");
            data.ApproveTime = DateTime.Now;
            data.ApproveUserName = WebUtil.GetUser(context).LoginName;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    var jiXiaoPoint = Mall_UserJiXiaoPoint.GetMall_UserJiXiaoPoint(data.Mall_UserJiXiaoPointID, helper);
                    var userPoint = Mall_UserPoint.GetMall_UserPoint(data.Mall_UserPointID, helper);
                    if (data.Status == 1)
                    {
                        if (jiXiaoPoint != null)
                        {
                            jiXiaoPoint.PointStatus = 1;
                            jiXiaoPoint.Save(helper);
                        }
                        if (userPoint != null)
                        {
                            userPoint.PointStatus = 1;
                            userPoint.Save(helper);
                        }
                    }
                    if (data.Status == 3)
                    {
                        if (jiXiaoPoint != null)
                        {
                            jiXiaoPoint.PointStatus = 0;
                            jiXiaoPoint.Save(helper);
                        }
                        if (userPoint != null)
                        {
                            userPoint.PointStatus = 0;
                            userPoint.Save(helper);
                        }
                    }
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadpointconvertrecordmgr(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = Mall_PointCovertRecord.GetMall_PointCovertRecordGridList(keywords, startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception)
            {
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void savecheckpointconvert(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Mall_UserPointRule data = null;
            if (ID > 0)
            {
                data = Mall_UserPointRule.GetMall_UserPointRule(ID);
            }
            if (data == null)
            {
                data = new Mall_UserPointRule();
                data.AddTime = DateTime.Now;
                data.AddUserName = WebUtil.GetUser(context).LoginName;
                data.IsUseForALLProduct = false;
            }
            data.StartPoint = WebUtil.getServerIntValue(context, "tdStartPoint");
            data.EndPoint = WebUtil.getServerIntValue(context, "tdEndPoint");
            data.PointType = WebUtil.getServerIntValue(context, "tdPointType");
            data.PointValue = WebUtil.getServerDecimalValue(context, "tdPointValue");
            data.Remark = WebUtil.getServerValue(context, "tdRemark");
            data.IsActive = WebUtil.getServerIntValue(context, "tdIsActive") == 1;
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removecheckpointcovert(HttpContext context)
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
                        string cmdtext = "delete from [Mall_UserPointRule] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removecheckpointcovert", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadcheckpointconvertmgr(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = Mall_UserPointRule.GetMall_UserPointRuleGridList(keywords, startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception)
            {
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void loadmallbusinessdiscountproductgrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int ID = WebUtil.GetIntValue(context, "ID");
                //DataGrid dg = Mall_OrderDetail.GetMall_OrderDetailRoomOwnerGrid(RoomID, startRowIndex, pageSize, StartTime, EndTime);
                var list = Mall_BusinessDiscountRequest_ProductDetail.GetMall_BusinessDiscountRequest_ProductDetailListByBusinessDiscountRequestID(ID, string.Empty);
                var dg = new Foresight.DataAccess.Ui.DataGrid();
                dg.rows = list;
                dg.page = 1;
                dg.total = list.Length;
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception)
            {
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void saveconfigparamfile(HttpContext context)
        {
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                var syslist = Foresight.DataAccess.SysConfig.GetSysConfigs().ToArray();
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile postedFile = uploadFiles[i];
                    string fileOriName = postedFile.FileName;
                    if (fileOriName == "" || fileOriName == null)
                    {
                        continue;
                    }
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileNameWithOutExtenSion = DateTime.Now.ToFileTime().ToString();
                    string fileName = fileNameWithOutExtenSion + extension;
                    string filepath = "/upload/Mall/ConfigParams/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    if (i == 0)
                    {

                        string Name = Foresight.DataAccess.SysConfigNameDefine.OpenDoorVideoFilePath.ToString();
                        string Value = filepath + fileName;
                        SaveConfig(syslist, Name, Value);
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void approverequestdiscount(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_BusinessDiscountRequest data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Mall_BusinessDiscountRequest.GetMall_BusinessDiscountRequest(ID);
            }
            if (data == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            if (data.Status != 1)
            {
                WebUtil.WriteJson(context, new { status = false, error = "已审核，请不要重复审核" });
                return;
            }
            data.Status = WebUtil.GetIntValue(context, "Status");
            data.ApproveRemark = getValue(context, "tdApproveRemark");
            data.ApproveTime = DateTime.Now;
            data.ApproveUserMan = WebUtil.GetUser(context).RealName;
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removerequestdiscount(HttpContext context)
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
                        string cmdtext = "delete from [Mall_BusinessDiscountRequest] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removemallbusinessrequestdiscount", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadrequestdiscountgrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = Mall_BusinessDiscountRequestDetail.GetMall_BusinessDiscountRequestDetailGridList(keywords, startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception)
            {
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void getprintidbyorderid(HttpContext context)
        {
            int PrintID = 0;
            int ID = WebUtil.GetIntValue(context, "ID");
            var order = Mall_Order.GetMall_Order(ID);
            if (order.ProductTypeID == 10)
            {
                var list = RoomFeeHistory.GetRoomFeeHistoryListByTradeNo(order.TradeNo, OrderID: order.ID);
                if (list.Length > 0)
                {
                    PrintID = list[0].PrintID;
                }
            }
            WebUtil.WriteJson(context, new { status = true, PrintID = PrintID });
        }
        private void loadmallroomownerorderlist(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int RoomID = WebUtil.GetIntValue(context, "RoomID");
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                DataGrid dg = Mall_OrderDetail.GetMall_OrderDetailRoomOwnerGrid(RoomID, startRowIndex, pageSize, StartTime, EndTime);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception)
            {
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void loadmallroomownerbalanceapplicationgrid(HttpContext context)
        {
            try
            {
                int status = WebUtil.GetIntValue(context, "status");
                string Keywords = context.Request.Params["keywords"];
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
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                DataGrid dg = Mall_RoomOwnerBalanceApplicationDetail.GetMall_RoomOwnerBalanceDetailApplicationGridByKeywords(Keywords, startRowIndex, pageSize, RoomIDList, ProjectIDList, StartTime, EndTime, UserID: WebUtil.GetUser(context).UserID);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception)
            {
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void savemallmemberamount(HttpContext context)
        {
            var my_user = WebUtil.GetUser(context);
            string ApproveRemark = string.Empty;
            int BalanceType = WebUtil.GetIntValue(context, "BalanceType");
            int UserID = WebUtil.GetIntValue(context, "UserID");
            int RelationID = WebUtil.GetIntValue(context, "RelationID");
            var relation = RoomPhoneRelation.GetRoomPhoneRelation(RelationID);
            if (relation == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "业主信息有误" });
                return;
            }
            var user = User.Save_UserData(UserID, relation.RelatePhoneNumber, relation.RelationName, UserTypeDefine.APPCustomer, relation.ID);
            relation.UserID = user.UserID;
            string Remark = getValue(context, "tdRemark");
            decimal BalanceValue = getDecimalValue(context, "tdBalanceValue");
            string Title = "线下扣除";
            int CategoryType = 10;
            if (BalanceType == 1)
            {
                Title = "线下充值";
                CategoryType = 8;
            }
            else
            {
                BalanceValue = -BalanceValue;
            }
            Mall_UserBalance.Insert_Mall_UserBalance(relation.UserID, BalanceType, BalanceValue, Title, "", CategoryType, my_user.LoginName, 1, "", Remark: Remark);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadmallmemberamountgrid(HttpContext context)
        {
            try
            {
                int status = WebUtil.GetIntValue(context, "status");
                string Keywords = context.Request.Params["keywords"];
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int AmountType = WebUtil.GetIntValue(context, "AmountType");
                int IncomingType = WebUtil.GetIntValue(context, "IncomingType");
                int OutcomingType = WebUtil.GetIntValue(context, "OutcomingType");
                DataGrid dg = Mall_UserBalanceDetail.GetMall_UserBalanceDetailGridByKeywords(Keywords, StartTime, EndTime, AmountType, startRowIndex, pageSize, IncomingType, OutcomingType);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception)
            {
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void savemallroomownerbalancestatus(HttpContext context)
        {
            string IDListStr = context.Request["IDList"];
            var IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDListStr))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDListStr);
            }
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "参数错误" });
                return;
            }
            var user = WebUtil.GetUser(context);
            string ApproveRemark = string.Empty;
            int BalanceStatus = WebUtil.GetIntValue(context, "BalanceStatus");
            string cmdtext = string.Empty;
            var parameters = new List<SqlParameter>();
            if (BalanceStatus == 2 || BalanceStatus == 3)
            {
                ApproveRemark = getValue(context, "tdApproveRemark");
                cmdtext = "update [Mall_RoomOwnerBalance] set [BalanceStatus]=@BalanceStatus,ApproveRemark=@ApproveRemark,ApproveTime=@ApproveTime,ApproveUserMan=@ApproveUserMan where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                parameters.Add(new SqlParameter("@ApproveRemark", ApproveRemark));
                parameters.Add(new SqlParameter("@ApproveTime", DateTime.Now));
                parameters.Add(new SqlParameter("@ApproveUserMan", user.LoginName));
            }
            else
            {
                cmdtext = "update [Mall_RoomOwnerBalance] set [BalanceStatus]=@BalanceStatus,ApplicationTime=@ApplicationTime,ApplicationUserMan=@ApplicationUserMan where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                parameters.Add(new SqlParameter("@ApplicationTime", DateTime.Now));
                parameters.Add(new SqlParameter("@ApplicationUserMan", user.LoginName));
            }
            var list = Mall_RoomOwnerBalance.GetMall_RoomOwnerBalanceListByIDList(IDList);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    parameters.Add(new SqlParameter("@BalanceStatus", BalanceStatus));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    if (BalanceStatus == 2)
                    {
                        //业主结算现金充值
                        foreach (var item in list)
                        {
                            Mall_UserBalance.Insert_Mall_UserBalance(item.UserID, 1, item.BalanceAmount, "业主结算", "", 9, user.LoginName, 1, "", RelatedID: item.ID, helper: helper);
                        }
                    }
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadmallroomownerbalancegrid(HttpContext context)
        {
            try
            {
                int status = WebUtil.GetIntValue(context, "status");
                string Keywords = context.Request.Params["keywords"];
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int BalanceStatus = WebUtil.GetIntValue(context, "BalanceStatus");
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DataGrid dg = Mall_RoomOwnerBalanceDetail.GetMall_RoomOwnerBalanceDetailGridByKeywords(Keywords, StartTime, EndTime, BalanceStatus, startRowIndex, pageSize, RoomIDList, ProjectIDList, UserID: WebUtil.GetUser(context).UserID);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception)
            {
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void savemallroomownerbalance(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Mall_RoomOwnerBalance data = null;
            if (ID > 0)
            {
                data = Mall_RoomOwnerBalance.GetMall_RoomOwnerBalance(ID);
            }
            if (data == null)
            {
                data = new Mall_RoomOwnerBalance();
                data.AddTime = DateTime.Now;
                data.AddUserMan = WebUtil.GetUser(context).LoginName;
                data.BalanceStatus = 1;
                data.ApplicationTime = DateTime.Now;
                data.ApplicationUserMan = WebUtil.GetUser(context).LoginName;
            }
            data.UserID = WebUtil.GetIntValue(context, "UserID");
            data.BalanceRuleID = getIntValue(context, "tdBalanceRuleID");
            data.BalanceAmount = getDecimalValue(context, "tdBalanceAmount");
            data.TotalCost = getDecimalValue(context, "tdTotalCost");
            data.RoomPhoneRelationID = WebUtil.GetIntValue(context, "RelationID");
            data.MemberLevel = context.Request["MemberLevelName"];
            data.ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getroomownerbalanceaddparams(HttpContext context)
        {
            var rule_list = Mall_BalanceRule.GetMall_BalanceRules().Where(p => p.IsActive && p.RuleType == 2).ToArray();
            var rulelist = rule_list.Select(p =>
            {
                decimal BackAmount = p.BackBalanceType == 1 ? p.BackPercent : p.BackAmount;
                var item = new { ID = p.ID, Title = p.Title, BackBalanceType = p.BackBalanceType, BackAmount = BackAmount };
                return item;
            }).ToArray();
            WebUtil.WriteJson(context, new { status = true, rulelist = rulelist });
        }
        private void savemallbalanceapprove(HttpContext context)
        {
            string IDListStr = context.Request["IDList"];
            var IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDListStr))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDListStr);
            }
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "参数错误" });
                return;
            }
            int BalanceStatus = WebUtil.GetIntValue(context, "BalanceStatus");
            string ApproveRemark = getValue(context, "tdApproveRemark");
            var user = WebUtil.GetUser(context);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [Mall_BusinessBalance] set [BalanceStatus]=@BalanceStatus,ApproveRemark=@ApproveRemark,ApproveTime=@ApproveTime,ApproveUserMan=@ApproveUserMan where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@BalanceStatus", BalanceStatus));
                    parameters.Add(new SqlParameter("@ApproveRemark", ApproveRemark));
                    parameters.Add(new SqlParameter("@ApproveTime", DateTime.Now));
                    parameters.Add(new SqlParameter("@ApproveUserMan", user.LoginName));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadmallbalanceapprovegrid(HttpContext context)
        {
            try
            {
                int status = WebUtil.GetIntValue(context, "status");
                string Keywords = context.Request.Params["keywords"];
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int BalanceStatus = WebUtil.GetIntValue(context, "BalanceStatus");
                DataGrid dg = Mall_BusinessBalanceDetail.GetMall_BusinessBalanceDetailGridByKeywords(Keywords, StartTime, EndTime, BalanceStatus, startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception)
            {
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void savebalanceapplication(HttpContext context)
        {
            string ListStr = context.Request["List"];
            var list = new List<Dictionary<string, object>>();
            if (!string.IsNullOrEmpty(ListStr))
            {
                list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(ListStr);
            }
            if (list.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "参数错误" });
                return;
            }
            var user = WebUtil.GetUser(context);
            List<Dictionary<string, object>> save_list = new List<Dictionary<string, object>>();
            foreach (var item in list)
            {
                var save_dic = new Dictionary<string, object>();
                var data = new Mall_BusinessBalance();
                data.BusinessID = Convert.ToInt32(item["BusinessID"]);
                data.BusinessAccount = item["BusinessBalanceAccount"].ToString();
                int BalanceRuleID = 0;
                int.TryParse(item["BalanceRuleID"].ToString(), out BalanceRuleID);
                data.BalanceRuleID = BalanceRuleID;
                data.BalanceStatus = 1;
                decimal BalanceAmount = 0;
                decimal.TryParse(item["BalanceAmount"].ToString(), out BalanceAmount);
                data.BalanceAmount = BalanceAmount;
                if (data.BalanceAmount <= 0)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "商户" + item["BusinessName"].ToString() + "结算金额小于0" });
                    return;
                }
                data.AddTime = DateTime.Now;
                data.AddUserMan = user.LoginName;
                data.ApplicationTime = DateTime.Now;
                data.ApplicationUserMan = user.LoginName;
                save_dic["data"] = data;
                string OrderIDListStr = item["OrderIDList"].ToString();
                var balance_order_list = new List<Mall_BusinessBalance_Order>();
                if (!string.IsNullOrEmpty(OrderIDListStr))
                {
                    int[] OrderIDList = OrderIDListStr.Split(',').Select(p => { return Convert.ToInt32(p); }).ToArray();
                    foreach (var OrderID in OrderIDList)
                    {
                        var data_order = new Mall_BusinessBalance_Order();
                        data_order.OrderID = OrderID;
                        balance_order_list.Add(data_order);
                    }
                }
                save_dic["balance_order_list"] = balance_order_list;
                save_list.Add(save_dic);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in save_list)
                    {
                        var data = item["data"] as Mall_BusinessBalance;
                        data.Save(helper);
                        var balance_order_list = item["balance_order_list"] as List<Mall_BusinessBalance_Order>;
                        foreach (var balance_order in balance_order_list)
                        {
                            balance_order.BusinessBalanceID = data.ID;
                            balance_order.Save(helper);
                        }
                    }
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getbalanceapplicationlist(HttpContext context)
        {
            List<int> IDList = new List<int>();
            string IDs = context.Request["OrderIDList"];
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择订单" });
                return;
            }
            var order_list = Mall_Order.GetMall_OrderListByIDList(IDList);
            var BusinessIDList = order_list.Select(p => p.BusinessID).Where(p => p > 0).Distinct().ToList();
            var business_list = Mall_Business.GetMall_BusinessListByIDList(BusinessIDList);
            var list = new List<Dictionary<string, object>>();
            BusinessIDList.Insert(0, 0);
            foreach (var BusinessID in BusinessIDList)
            {
                var my_order_list = order_list.Where(p =>
                    {
                        p.BusinessID = p.BusinessID > 0 ? p.BusinessID : 0;
                        return p.BusinessID == BusinessID;
                    }).ToArray();
                if (my_order_list.Length == 0)
                {
                    continue;
                }
                string BusinessName = string.Empty;
                string BusinessContactMan = string.Empty;
                string BusinessBalanceAccount = string.Empty;
                if (BusinessID == 0)
                {
                    BusinessName = "福顺居自营";
                }
                else
                {
                    var myBusiness = business_list.FirstOrDefault(p => p.ID == BusinessID);
                    if (myBusiness != null)
                    {
                        BusinessName = myBusiness.BusinessName;
                        BusinessContactMan = myBusiness.ContactName;
                        BusinessBalanceAccount = myBusiness.BalanceAccount;
                    }
                    else
                    {
                        BusinessName = "商户已删除";
                    }
                }
                var dic = new Dictionary<string, object>();
                dic["BusinessID"] = BusinessID;
                dic["BusinessName"] = BusinessName;
                dic["BusinessContactMan"] = BusinessContactMan;
                dic["TotalCount"] = my_order_list.Length;
                dic["TotalCost"] = my_order_list.Sum(p => p.TotalCost);
                dic["BusinessBalanceAccount"] = BusinessBalanceAccount;
                dic["BalanceRuleID"] = "";
                dic["BalanceAmount"] = 0;
                dic["OrderIDList"] = string.Join(",", my_order_list.Select(p => p.ID).ToArray());
                list.Add(dic);
            }
            var rule_list = Mall_BalanceRule.GetMall_BalanceRules().Where(p => p.IsActive && p.RuleType == 1).ToArray();
            var rulelist = rule_list.Select(p =>
            {
                decimal BackAmount = p.BackBalanceType == 1 ? p.BackPercent : p.BackAmount;
                var item = new { ID = p.ID, Title = p.Title, BackBalanceType = p.BackBalanceType, BackAmount = BackAmount };
                return item;
            }).ToArray();
            WebUtil.WriteJson(context, new { status = true, list = list, rulelist = rulelist });
        }
        private void loadmallbusinessbalancegrid(HttpContext context)
        {
            try
            {
                int status = WebUtil.GetIntValue(context, "status");
                string Keywords = context.Request.Params["Keywords"];
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int BalanceStatus = WebUtil.GetIntValue(context, "BalanceStatus");
                int BusinessBalanceID = WebUtil.GetIntValue(context, "BusinessBalanceID");
                int BusinessType = WebUtil.GetIntValue(context, "BusinessType");
                DataGrid dg = Mall_OrderDetail.GetMall_OrderDetailGridByKeywords(Keywords, StartTime, EndTime, BalanceStatus, startRowIndex, pageSize, BusinessBalanceID, BusinessType);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception)
            {
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void savemallbalancerule(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Mall_BalanceRule data = null;
            if (ID > 0)
            {
                data = Mall_BalanceRule.GetMall_BalanceRule(ID);
            }
            if (data == null)
            {
                data = new Mall_BalanceRule();
                data.AddTime = DateTime.Now;
                data.AddUserName = WebUtil.GetUser(context).LoginName;
            }
            data.Title = getValue(context, "tdTitle");
            data.BackAmount = 0;
            data.BackPercent = 0;
            data.Remark = getValue(context, "tdRemark");
            data.IsActive = getIntValue(context, "tdIsActive") == 1;
            data.BackBalanceType = getIntValue(context, "tdBackBalanceType");
            data.RuleType = getIntValue(context, "tdRuleType");
            if (data.BackBalanceType == 1)
            {
                data.BackPercent = getDecimalValue(context, "tdBackAmount");
            }
            else
            {
                data.BackAmount = getDecimalValue(context, "tdBackAmount");
            }
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removemallbalancerule(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            if (IDList.Count > 0)
            {
                var balance_list = Foresight.DataAccess.Mall_BusinessBalance.GetMall_BusinessBalanceListByRuleIDList(IDList);
                if (balance_list.Length > 0)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "该规则已被使用，禁止删除操作" });
                }
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [Mall_BalanceRule] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removemallbalancerule", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadmallbalancerulegrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                int RuleType = WebUtil.GetIntValue(context, "RuleType");
                DataGrid dg = Mall_BalanceRule.GetMall_BalanceRuleGridByKeywords(keywords, startRowIndex, pageSize, RuleType);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "loadmallbalancerulegrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void synchdoorcard(HttpContext context)
        {
            List<Dictionary<string, object>> List = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(context.Request["List"]);
            if (List.Count > 0)
            {
                var card_list = Mall_DoorCard.GetMall_DoorCards().ToArray();
                var device_list = Mall_DoorDevice.GetMall_DoorDevices().ToArray();
                var card_device_list = Mall_DoorCardDevice.GetMall_DoorCardDevices().ToArray();
                foreach (var item in List)
                {
                    DateTime FeeEndDate = DateTime.MinValue;
                    DateTime.TryParse(item["FeeEndDate"].ToString(), out FeeEndDate);
                    if (FeeEndDate == DateTime.MinValue)
                    {
                        continue;
                    }
                    int EndDays = Convert.ToInt32((FeeEndDate - DateTime.Today).TotalDays);
                    if (EndDays > 65535)
                    {
                        EndDays = 65535;
                    }
                    int ID = 0;
                    int.TryParse(item["ID"].ToString(), out ID);
                    var my_card = card_list.FirstOrDefault(p => p.ID == ID);
                    if (my_card == null)
                    {
                        continue;
                    }
                    var my_card_device_list = card_device_list.Where(p => p.DoorCardID == ID).ToArray();
                    var my_device_list = device_list.Where(p => (my_card_device_list.Select(q => q.DoorDeviceID).ToList()).Contains(p.DeviceID)).ToArray();
                    if (my_device_list.Length == 0)
                    {
                        continue;
                    }
                    string[] cardUids = new string[] { my_card.CardUID };
                    int[] deviceIds = my_device_list.Select(p => p.DeviceID).ToArray();
                    string error = string.Empty;
                    bool result = Utility.LLingHelper.doUpdateDoorOpenCard(cardUids, deviceIds, EndDays, out error);
                    if (result)
                    {
                        my_card.EndDays = EndDays;
                        my_card.ExpireDate = DateTime.Today.AddDays(EndDays);
                        my_card.Save();
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savedroorremoteusertime(HttpContext context)
        {
            List<Dictionary<string, int>> DataList = new List<Dictionary<string, int>>();
            string listtrs = context.Request["list"];
            if (!string.IsNullOrEmpty(listtrs))
            {
                DataList = JsonConvert.DeserializeObject<List<Dictionary<string, int>>>(listtrs);
            }
            if (DataList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择房间" });
                return;
            }
            List<int> RoomIDList = DataList.Select(p => { return p["RoomID"]; }).ToList();
            var time_list = Mall_DoorRemoteUserTime.GetMall_DoorRemoteUserTimeListByRoomIDList(RoomIDList);
            List<Mall_DoorRemoteUserTime> db_time_list = new List<Mall_DoorRemoteUserTime>();
            var user = WebUtil.GetUser(context);
            bool IsDisable = WebUtil.GetIntValue(context, "Enable") == 0;
            DateTime DelayDate = WebUtil.GetDateValue(context, "DelayDate");
            foreach (var item in DataList)
            {
                int RoomID = item["RoomID"];
                var my_item = time_list.FirstOrDefault(p => p.RoomID == RoomID);
                if (my_item == null)
                {
                    my_item = new Mall_DoorRemoteUserTime();
                    my_item.AddTime = DateTime.Now;
                    my_item.AddUserMan = user.LoginName;
                    my_item.RoomID = RoomID;
                }
                my_item.IsDisable = IsDisable;
                if (DelayDate > DateTime.MinValue)
                {
                    my_item.DelayDate = DelayDate;
                }
                db_time_list.Add(my_item);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in db_time_list)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void delayremoteusertime(HttpContext context)
        {
            List<Dictionary<string, int>> DataList = new List<Dictionary<string, int>>();
            string listtrs = context.Request["list"];
            if (!string.IsNullOrEmpty(listtrs))
            {
                DataList = JsonConvert.DeserializeObject<List<Dictionary<string, int>>>(listtrs);
            }
            if (DataList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择房间" });
                return;
            }
            var config = SysConfig.GetSysConfigByName(SysConfigNameDefine.DoorDelayDay.ToString());
            int delayday = 3;
            if (config != null && !string.IsNullOrEmpty(config.Value))
            {
                int.TryParse(config.Value, out delayday);
            }
            delayday = delayday > 0 ? delayday : 3;
            List<int> RoomIDList = DataList.Select(p => { return p["RoomID"]; }).ToList();
            var history_list = RoomFeeHistory.GetRoomFeeHistoryListByRoomIDList(RoomIDList, ChargeFeeType: 1);
            var fee_list = RoomFee.GetRoomFeeListByRoomIDList(-1, RoomIDList, 0, ChargeFeeType: 1);
            var time_list = Mall_DoorRemoteUserTime.GetMall_DoorRemoteUserTimeListByRoomIDList(RoomIDList);
            var user = WebUtil.GetUser(context);
            List<Mall_DoorRemoteUserTime> db_time_list = new List<Mall_DoorRemoteUserTime>();
            foreach (var item in DataList)
            {
                int RoomID = item["RoomID"];
                var my_history = history_list.Where(p => p.RoomID == RoomID).OrderByDescending(p => p.ChargeTime).FirstOrDefault();
                var my_fee = fee_list.Where(p => p.RoomID == RoomID).OrderByDescending(p => p.StartTime).FirstOrDefault();
                var my_item = time_list.FirstOrDefault(p => p.RoomID == RoomID);
                if (my_item == null)
                {
                    my_item = new Mall_DoorRemoteUserTime();
                    my_item.AddTime = DateTime.Now;
                    my_item.AddUserMan = user.LoginName;
                    my_item.RoomID = RoomID;
                }
                my_item.DelayDay = delayday;
                DateTime StartTime = DateTime.Now;
                DateTime EndTime = DateTime.Now;
                if (my_history != null)
                {
                    StartTime = my_history.StartTime;
                    EndTime = my_history.EndTime;
                }
                if (my_fee != null && my_fee.StartTime != DateTime.MinValue)
                {
                    EndTime = my_fee.StartTime.AddDays(-1);
                }
                StartTime = StartTime == DateTime.MinValue ? DateTime.Now : StartTime;
                EndTime = EndTime == DateTime.MinValue ? DateTime.Now : EndTime;
                my_item.StartTime = StartTime;
                my_item.EndTime = EndTime;
                my_item.DelayDay = delayday;
                my_item.DelayDate = EndTime.AddDays(delayday);
                db_time_list.Add(my_item);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in db_time_list)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmalldoorremoteusertimegrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DataGrid dg = Mall_DoorRemoteUserTimeDetail.GetMall_DoorRemoteUserTimeDetailGridByKeywords(keywords, startRowIndex, pageSize, ProjectIDList, RoomIDList);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "getmalldoorremoteusertimegrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void savemallordersendapp(HttpContext context)
        {
            var current_user = WebUtil.GetUser(context);
            int ID = WebUtil.GetIntValue(context, "ID");
            List<Mall_Order> orderlist = new List<Mall_Order>();
            if (ID > 0)
            {
                var order = Foresight.DataAccess.Mall_Order.GetMall_Order(ID);
                if (order == null)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已不存在" });
                    return;
                }
                if (order.OrderStatus == 3)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已完成" });
                    return;
                }
                if (order.OrderStatus == 1)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单未付款" });
                    return;
                }
                if (order.IsClosed)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已关闭" });
                    return;
                }
                orderlist.Add(order);
            }
            else
            {
                string IDs = context.Request["IDList"];
                List<int> IDList = new List<int>();
                if (!string.IsNullOrEmpty(IDs))
                {
                    IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
                }
                if (IDList.Count > 0)
                {
                    orderlist = Foresight.DataAccess.Mall_Order.GetMall_OrderListByIDList(IDList).ToList();
                }
            }
            int SendType = getIntValue(context, "tdSendType");
            string UserIDs = getValue(context, "hdUserIDList");
            List<int> UserIDList = new List<int>();
            if (!string.IsNullOrEmpty(UserIDs))
            {
                UserIDList = JsonConvert.DeserializeObject<List<int>>(UserIDs);
            }
            if (SendType == 1 && UserIDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择接单员工" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in orderlist)
                    {
                        string cmdtext = "update Mall_OrderAPPUser set [AccpetStatus]=3 where [OrderID]=@OrderID";
                        var parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@OrderID", item.ID));
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        if (SendType == 2)
                        {
                            Mall_Order.GetGrabOrderInfo(item);
                        }
                        else
                        {
                            item.IsAPPUserSent = true;
                            item.IsCanGrab = false;
                            item.GrabStatus = 2;
                            foreach (var UserID in UserIDList)
                            {
                                Mall_OrderAPPUser.Save_Mall_OrderAPPUser(0, helper, IsAPPSend: false, APPSendResult: "", UserID: UserID, OrderID: item.ID, IsAPPShow: true, AddUserMan: current_user.LoginName);
                            }
                        }
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getdoordersendappparams(HttpContext context)
        {
            string UserType = UserTypeDefine.APPUser.ToString();
            var list = User.GetAPPCustomerUserList(UserType);
            var items = list.Select(p =>
            {
                string Name = p.FinalRealName;
                if (!string.IsNullOrEmpty(p.PhoneNumber))
                {
                    Name += "(" + p.PhoneNumber + ")";
                }
                var item = new { ID = p.UserID, Name = Name };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void startapproveuserlevelapprove(HttpContext context)
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
                        string cmdtext = "update [Mall_UserLevelApprove] set [ApproveStatus]=0,[RequestTime]=getdate() where [ID] in (" + string.Join(",", IDList.ToArray()) + ") and [IsManualIncoming]=1 and [ApproveStatus]=3";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: startapproveuserlevelapprove", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removeuserlevelapprove(HttpContext context)
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
                        string cmdtext = "delete from [Mall_UserLevelApprove] where [ID] in (" + string.Join(",", IDList.ToArray()) + ") and [IsManualIncoming]=1 and [ApproveStatus] not in (0,1)";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removeuserlevelapprove", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void saveapprovemalluserlevel(HttpContext context)
        {
            Mall_UserLevelApprove data = null;
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID > 0)
            {
                data = Mall_UserLevelApprove.GetMall_UserLevelApprove(ID);
            }
            if (data == null)
            {
                data = new Mall_UserLevelApprove();
                data.RequestTime = DateTime.Now;
                data.AddUserName = WebUtil.GetUser(context).LoginName;
                data.ApproveTime = DateTime.Now;
                data.ApproveStatus = 3;
                data.UserBalanceID = 0;
                data.IsManualIncoming = true;
                data.UserID = 0;
            }
            data.ApproveUserLevelID = getIntValue(context, "tdUserLevelID");
            data.IncomingAmount = getDecimalValue(context, "tdIncomingAmount");
            data.IncomingTime = getTimeValue(context, "tdIncomingTime");
            data.IncomingType = getValue(context, "tdIncomingType");
            data.DealManName = getValue(context, "tdDealManName");
            data.RoomPhoneRelationID = getIntValue(context, "hdRelationID");
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                HttpPostedFile postedFile = uploadFiles[0];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileNameWithOutExtenSion = DateTime.Now.ToFileTime().ToString();
                    string fileName = fileNameWithOutExtenSion + extension;
                    string filepath = "/upload/Mall/UserCheck/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    data.FilePath = filepath + fileName;
                }
            }
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getuserlevelapproveeditparam(HttpContext context)
        {
            var list = Mall_UserLevel.GetMall_UserLevels().OrderBy(p => p.StartAmount).ToArray();
            var items = list.Select(p =>
            {
                var item = new { id = p.ID, value = p.Name };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void removeusercoupon(HttpContext context)
        {
            string IDListArry = context.Request["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            if (IDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [Mall_CouponUser] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removeusercoupon", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemallbusinesssort(HttpContext context)
        {
            int type = WebUtil.GetIntValue(context, "type");
            string lists = context.Request["list"];
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            if (!string.IsNullOrEmpty(lists))
            {
                list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(lists);
            }
            string cmdtext = string.Empty;
            foreach (var item in list)
            {
                int SortOrder = 0;
                int.TryParse(item["sortorder"].ToString(), out SortOrder);
                int ID = 0;
                int.TryParse(item["id"].ToString(), out ID);
                cmdtext += "update [Mall_Business] set [SortOrder]=" + SortOrder + " where ID=" + ID + ";";
            }
            if (!string.IsNullOrEmpty(cmdtext))
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "savemallbusinesssort", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmallbusinesssortlist(HttpContext context)
        {
            var business_list = Foresight.DataAccess.Mall_Business.GetMall_Businesses().Where(p => p.IsSuggestion && p.IsShowOnHome && p.Status == 1).OrderBy(p => p.SortOrder).ThenByDescending(p => p.AddTime).ToArray();
            var businessitems = business_list.Select(p =>
            {
                var item = new { id = p.ID, title = p.BusinessName, sortorder = p.SortOrder > int.MinValue ? p.SortOrder : 0 };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = businessitems });
        }
        private void savemallproductyouxuan(HttpContext context)
        {
            int type = WebUtil.GetIntValue(context, "type");
            string lists = context.Request["list"];
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            if (!string.IsNullOrEmpty(lists))
            {
                list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(lists);
            }
            string cmdtext = string.Empty;
            foreach (var item in list)
            {
                int SortOrder = 0;
                int.TryParse(item["sortorder"].ToString(), out SortOrder);
                int ID = 0;
                int.TryParse(item["id"].ToString(), out ID);
                if (type == 1)
                {
                    cmdtext += "update [Mall_Product] set [YouXuanSortOrder]=" + SortOrder + " where ID=" + ID + ";";
                }
                else if (type == 2)
                {
                    cmdtext += "update [Mall_Product] set [PinTuanSortOrder]=" + SortOrder + "where ID=" + ID + ";";
                }
            }
            if (!string.IsNullOrEmpty(cmdtext))
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "savemallproductyouxuan", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmallproductyouxuanlist(HttpContext context)
        {
            int type = WebUtil.GetIntValue(context, "type");
            var productlist = Foresight.DataAccess.Mall_ProductDetail.GetMall_ProductDetailList(IsShowOnHome: true, IsAllowProductBuy: true).ToArray();
            if (type == 1)
            {
                var ziying_list = productlist.Where(p => p.ProductTypeID == 1 && p.IsYouXuan).OrderBy(p => p.YouXuanSortOrder).ToArray();
                var ziyingitems = ziying_list.Select(p =>
                {
                    var item = new { id = p.ID, title = p.ProductName, price = p.NormalPriceDesc, sortorder = (p.YouXuanSortOrder > int.MinValue ? p.YouXuanSortOrder : 0) };
                    return item;
                });
                WebUtil.WriteJson(context, new { status = true, list = ziyingitems });
                return;
            }
            if (type == 2)
            {
                var pin_list = productlist.Where(p => p.ProductTypeID == 3 || p.ProductTypeID == 4).OrderBy(p => p.PinTuanSortOrder).ToArray();
                var pintuanitems = pin_list.Select(p =>
                {
                    var item = new { id = p.ID, title = p.ProductName, price = p.NormalPriceDesc, sortorder = (p.PinTuanSortOrder > int.MinValue ? p.PinTuanSortOrder : 0) };
                    return item;
                });
                WebUtil.WriteJson(context, new { status = true, list = pintuanitems });
                return;
            }
            WebUtil.WriteJson(context, new { status = false });
        }
        private void activeusercoupon(HttpContext context)
        {
            int Status = WebUtil.GetIntValue(context, "status");
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            if (IDList.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "update [Mall_CouponUser] set [IsActive]=@Status where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@Status", Status));
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: activeusercoupon", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemallusercoupon(HttpContext context)
        {
            bool IsActive = getIntValue(context, "tdIsActive") == 1;
            DateTime StartTime = getTimeValue(context, "tdStartTime");
            DateTime EndTime = getTimeValue(context, "tdEndTime");
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID > 0)
            {
                var coupon_user = Mall_CouponUser.GetMall_CouponUser(ID);
                coupon_user.IsActive = IsActive;
                coupon_user.StartTime = StartTime;
                coupon_user.EndTime = EndTime;
                coupon_user.Save();
                WebUtil.WriteJson(context, new { status = true });
                return;
            }
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (IDList.Count > 0)
            {
                var coupon_user_list = Mall_CouponUser.GetMall_CouponUsers().Where(p => IDList.Contains(p.ID)).ToArray();
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        foreach (var item in coupon_user_list)
                        {
                            item.IsActive = IsActive;
                            item.StartTime = StartTime;
                            item.EndTime = EndTime;
                            item.Save(helper);
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "savemallusercoupon", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadusercoupongrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                int CouponType = WebUtil.GetIntValue(context, "CouponType");
                int UserID = WebUtil.GetIntValue(context, "UserID");
                int IsUsed = WebUtil.GetIntValue(context, "IsUsed");
                int IsActive = WebUtil.GetIntValue(context, "IsActive");
                DataGrid dg = Mall_CouponUserDetail2.GetMall_CouponUserDetail2GridByKeywords(keywords, UserID, CouponType, IsUsed, IsActive, startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "loadusercoupongrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void approvemalluserlevel(HttpContext context)
        {
            var current_user = WebUtil.GetUser(context);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Mall_UserLevelApprove.GetMall_UserLevelApprove(ID);
            data.ApproveStatus = WebUtil.GetIntValue(context, "status");
            data.ApproveTime = DateTime.Now;
            data.ApproveUserName = current_user.LoginName;
            data.ApproveRemark = getValue(context, "tdApproveRemark");
            Foresight.DataAccess.User user = null;
            if (data.ApproveStatus == 1)
            {
                if (data.RoomPhoneRelationID > 0)
                {
                    var relation = RoomPhoneRelation.GetRoomPhoneRelation(data.RoomPhoneRelationID);
                    if (relation != null && !string.IsNullOrEmpty(relation.RelatePhoneNumber))
                    {
                        user = User.Save_UserData(relation.UserID, relation.RelatePhoneNumber, relation.RelationName, UserTypeDefine.APPCustomer, relation.ID, IsAllowAPPCustomerLogin: true);
                    }
                }
                else
                {
                    user = Foresight.DataAccess.User.GetUser(data.UserID);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    if (data.ApproveStatus == 1 && data.IsManualIncoming)
                    {
                        if (user != null)
                        {
                            user.UserLevelID = data.ApproveUserLevelID;
                            user.Save(helper);
                            data.UserID = user.UserID;
                            Mall_UserBalance.Insert_Mall_UserBalance(user.UserID, 1, data.IncomingAmount, "线下充值", string.Empty, 8, current_user.LoginName, 1, string.Empty, helper: helper, PaymentMethod: data.IncomingType, IsManualIncoming: true, UserLevelApproveID: data.ID);
                        }
                    }
                    data.Save(helper);
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadmalluserlevelapprovegrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                int status = WebUtil.GetIntValue(context, "status");
                DataGrid dg = Mall_UserLevelApproveDetail.GetMall_UserLevelApproveDetailGridByKeywords(keywords, status, startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "loadmalluserlevelapprovegrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void savemallproducttags(HttpContext context)
        {
            int[] ProductIDList = JsonConvert.DeserializeObject<int[]>(context.Request["ProductIDList"]).Where(p => p > 0).ToArray();
            int[] TagIDList = JsonConvert.DeserializeObject<int[]>(context.Request["TagIDList"]).Where(p => p > 0).ToArray();
            List<Foresight.DataAccess.Mall_ProductTag> product_tag_list = new List<Mall_ProductTag>();
            foreach (var TagID in TagIDList)
            {
                foreach (var ProductID in ProductIDList)
                {
                    var product_tag = new Foresight.DataAccess.Mall_ProductTag();
                    product_tag.TagID = TagID;
                    product_tag.ProductID = ProductID;
                    product_tag_list.Add(product_tag);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_ProductTag] where [ProductID] in (" + string.Join(",", ProductIDList) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    foreach (var item in product_tag_list)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "savemallproducttags", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmallproductchangetagparams(HttpContext context)
        {
            var list = Foresight.DataAccess.Mall_Tag.GetMall_Tags();
            var items = list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.TagName };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void deletemallcouponcodecover(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Mall_Coupon.GetMall_Coupon(ID);
            if (data == null)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            data.CoverImage = string.Empty;
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmallcouponcodecover(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Mall_Coupon.GetMall_Coupon(ID);
            if (data == null)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            string CoverImage = string.IsNullOrEmpty(data.CoverImage) ? string.Empty : WebUtil.GetContextPath() + data.CoverImage;
            WebUtil.WriteJson(context, new { status = true, CoverImage = CoverImage });
        }
        private void sendmallusercouponcode(HttpContext context)
        {
            string UserIDs = context.Request["UserIDList"];
            string CouponIDs = context.Request["CouponIDList"];
            int SendCount = WebUtil.GetIntValue(context, "SendCount");
            List<int> UserIDList = new List<int>();
            List<int> CouponIDList = new List<int>();
            if (!string.IsNullOrEmpty(UserIDs))
            {
                UserIDList = JsonConvert.DeserializeObject<List<int>>(UserIDs);
            }
            if (!string.IsNullOrEmpty(CouponIDs))
            {
                CouponIDList = JsonConvert.DeserializeObject<List<int>>(CouponIDs);
            }
            if (UserIDList.Count == 0 || CouponIDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            string UserName = WebUtil.GetUser(context).LoginName;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    for (int i = 0; i < SendCount; i++)
                    {
                        foreach (var UserID in UserIDList)
                        {
                            foreach (var CouponID in CouponIDList)
                            {
                                var data = new Mall_CouponUser();
                                data.UserID = UserID;
                                data.CouponID = CouponID;
                                data.AddTime = DateTime.Now;
                                data.AddUserMan = UserName;
                                data.UseType = 0;
                                data.IsUsed = false;
                                data.IsSent = true;
                                data.CouponType = 4;
                                data.AmountRuleID = 0;
                                data.IsRead = false;
                                data.IsActive = true;
                                data.IsTaken = false;
                                data.Save(helper);
                            }
                        }
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "sendmallusercouponcode", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removeuserlevel(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            if (IDList.Count > 0)
            {
                var user_list = Foresight.DataAccess.User.GetUserListByLevelIDList(IDList);
                if (user_list.Length > 0)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "该等级使用中，禁止删除" });
                }
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [Mall_UserLevel] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removeuserlevel", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemalluserlevel(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            decimal StartAmount = getDecimalValue(context, "tdStartAmount");
            decimal EndAmount = getDecimalValue(context, "tdEndAmount");
            var list = Mall_UserLevel.GetMall_UserLevelListByAmount(StartAmount, EndAmount, ID: ID);
            if (list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "金额区间有冲突" });
                return;
            }
            Mall_UserLevel data = null;
            if (ID > 0)
            {
                data = Mall_UserLevel.GetMall_UserLevel(ID);
            }
            if (data == null)
            {
                data = new Mall_UserLevel();
                data.AddTime = DateTime.Now;
                data.AddUserName = WebUtil.GetUser(context).LoginName;
            }
            data.Name = getValue(context, "tdName");
            data.Remark = getValue(context, "tdRemark");
            data.StartAmount = StartAmount;
            data.EndAmount = EndAmount;
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadmalluserlevelgrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = Mall_UserLevelDetail.GetMall_UserLevelDetailGridByKeywords(keywords, startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "loadmallmemberamountrulegrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void loadmallmemberpointgrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                DataGrid dg = Mall_UserPoint.GetMall_UserPointGridByKeywords(Keywords, StartTime, EndTime, "order by [UserID] desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "loadmallmemberpointgrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
        }
        private void loadmallusercheckpointgrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                DataGrid dg = Mall_UserJiXiaoPointDetail.GetMall_UserJiXiaoPointDetailGridByKeywords(Keywords, StartTime, EndTime, "order by ApproveTime desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "loadmallusercheckpointgrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
        }
        private void processmallusercheck(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            int ID = WebUtil.GetIntValue(context, "ID");
            if (IDList.Count == 0 && ID <= 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择需要处理的数据" });
                return;
            }
            int ProcessStatus = WebUtil.GetIntValue(context, "Status");
            string ProcessRemark = getValue(context, "tdProcessRemark");
            string ProcessUserName = WebUtil.GetUser(context).LoginName;
            int ProcessUserID = WebUtil.GetUser(context).UserID;
            if (IDList.Count > 0 || ID > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = string.Empty;
                        List<string> conditions = new List<string>();
                        List<string> conditions2 = new List<string>();
                        conditions.Add("isnull([ProcessStatus],0)=0");
                        conditions2.Add("isnull([ProcessStatus],0)=0");
                        if (IDList.Count > 0)
                        {
                            conditions.Add("[RequestID] in (" + string.Join(",", IDList.ToArray()) + ")");
                            conditions2.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
                        }
                        else if (ID > 0)
                        {
                            conditions.Add("[RequestID]=@ID");
                            conditions2.Add("[ID]=@ID");
                        }
                        cmdtext += "update [Mall_CheckRequestConfirm] set ProcessStatus=@ProcessStatus,[ProcessUserID]=@ProcessUserID,[ProcessUserName]=@ProcessUserName,[ProcessTime]=@ProcessTime,[ProcessRemark]=@ProcessRemark where " + string.Join(" and ", conditions.ToArray()) + ";";
                        cmdtext += "update [Mall_CheckRequest] set ProcessStatus=@ProcessStatus,[ProcessRemark]=@ProcessRemark,[ProcessUserName]=@ProcessUserName,[ProcessTime]=@ProcessTime where " + string.Join(" and ", conditions2.ToArray()) + ";";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@ProcessStatus", ProcessStatus));
                        parameters.Add(new SqlParameter("@ProcessUserID", ProcessUserID));
                        parameters.Add(new SqlParameter("@ProcessUserName", ProcessUserName));
                        parameters.Add(new SqlParameter("@ProcessTime", DateTime.Now));
                        parameters.Add(new SqlParameter("@ProcessRemark", ProcessRemark));
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: processmallusercheck", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            Mall_CheckRequest.senduserjixiaopoint(IDList);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void approvemallusercheck(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            int Status = WebUtil.GetIntValue(context, "Status");
            var data = new Mall_CheckRequestApprove();
            data.ApproveStatus = Status;
            data.ApproveMan = WebUtil.GetUser(context).LoginName;
            data.ApproveUserID = WebUtil.GetUser(context).UserID;
            data.ApproveTime = DateTime.Now;
            data.ApproveRemark = getValue(context, "tdApproveRemark");
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择数据" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [Mall_CheckRequest] set ApproveStatus=@Status,[ApproveMan]=@ApproveMan,[ApproveTime]=@ApproveTime,[ApproveRemark]=@ApproveRemark where [ID] in (" + string.Join(",", IDList.ToArray()) + ") and [ApproveStatus]!=1;";
                    foreach (var ID in IDList)
                    {
                        data = new Mall_CheckRequestApprove();
                        data.ApproveStatus = Status;
                        data.ApproveMan = WebUtil.GetUser(context).LoginName;
                        data.ApproveUserID = WebUtil.GetUser(context).UserID;
                        data.ApproveTime = DateTime.Now;
                        data.ApproveRemark = getValue(context, "tdApproveRemark");
                        data.RequestID = ID;
                        data.Save(helper);
                        cmdtext += "update [Mall_CheckRequest] set CheckApproveID=" + data.ID + " where [ID]=" + ID + " and [ApproveStatus]!=1;";
                    }
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@Status", Status));
                    parameters.Add(new SqlParameter("@ApproveMan", data.ApproveMan));
                    parameters.Add(new SqlParameter("@ApproveTime", data.ApproveTime));
                    parameters.Add(new SqlParameter("@ApproveRemark", data.ApproveRemark));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "命令: approvemallusercheck", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            if (Status == 1)
            {
                var user_list = Foresight.DataAccess.User.GetAPPUserListByCheckRequestIDList(IDList).Where(p => !string.IsNullOrEmpty(p.DeviceId)).ToArray();
                Dictionary<string, object> extras = new Dictionary<string, object>();
                var extra_model = new Utility.JpushContent(801, Type: "mallcheck_approved");
                extras["code"] = extra_model.code;
                extras["msg"] = extra_model.msg;
                extras["type"] = extra_model.type;
                var users_android = user_list.Where(p => p.APPUserDeviceType.Equals("android")).ToArray();
                var users_ios = user_list.Where(p => p.APPUserDeviceType.Equals("ios")).ToArray();
                string[] android_cids = new string[] { };
                string[] ios_cids = new string[] { };
                if (users_android.Length > 0)
                {
                    android_cids = users_android.Select(p => p.APPUserDeviceID).ToArray();
                }
                if (users_ios.Length > 0)
                {
                    ios_cids = users_ios.Select(p => p.APPUserDeviceID).ToArray();
                }
                var company = WebUtil.GetCompany(context);
                string title = company == null ? "永友网络" : company.CompanyName;
                string result_push = JPush.JpushAPI.PushMessage(title, extras, android_cids, ios_cids, extra_model.msg);
                Foresight.DataAccess.JPushLog.Insert_JPushLog(android_cids, ios_cids, extras, result_push, 11, 0, true, title);
                Mall_CheckRequest.senduserjixiaopoint(IDList);
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void domallusercheckapplication(HttpContext context)
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
                        string cmdtext = "update [Mall_CheckRequest] set ApproveStatus=3 where [ID] in (" + string.Join(",", IDList.ToArray()) + ") and [ApproveStatus]!=1 and [ApproveStatus]!=3";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: domallusercheckapplication", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removemallusercheck(HttpContext context)
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
                        string cmdtext = "delete from [Mall_CheckRequestConfirm] where [RequestID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        cmdtext += "delete from [Mall_CheckRequestApprove] where [RequestID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        cmdtext += "delete from [Mall_CheckRequestRule] where [RequestID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        cmdtext += "delete from [Mall_CheckRequestUser] where [RequestID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        cmdtext += "delete from [Mall_CheckRequest] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removemallusercheck", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadmallusercheckgrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int CheckType = WebUtil.GetIntValue(context, "CheckType");
                int approvestatus = WebUtil.GetIntValue(context, "approvestatus");
                int confirmstatus = WebUtil.GetIntValue(context, "confirmstatus");
                int UserID = WebUtil.GetIntValue(context, "UserID");
                int RequestType = WebUtil.GetIntValue(context, "RequestType");
                int processstatus = WebUtil.GetIntValue(context, "processstatus");
                DataGrid dg = Mall_CheckRequestDetail.GetMall_CheckRequestDetailGridByKeywords(Keywords, CheckType, approvestatus, confirmstatus, processstatus, "order by AddTime asc", startRowIndex, pageSize, UserID, RequestType);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "getmallcheckrulegrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
        }
        private void savemallusercheck(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Mall_CheckRequest data = null;
            if (ID > 0)
            {
                data = Mall_CheckRequest.GetMall_CheckRequest(ID);
            }
            if (data == null)
            {
                data = new Mall_CheckRequest();
                data.AddTime = DateTime.Now;
                data.AddUserName = WebUtil.GetUser(context).LoginName;
                data.ApproveStatus = 0;
                data.ConfirmStatus = 0;
                data.RequestType = 1;
            }
            data.Remark = getValue(context, "tdRemark");
            string UserIDs = context.Request["UserIDList"];
            List<int> UserIDList = new List<int>();
            if (!string.IsNullOrEmpty(UserIDs))
            {
                UserIDList = JsonConvert.DeserializeObject<List<int>>(UserIDs);
            }
            List<Mall_CheckRequestUser> check_user_list = new List<Mall_CheckRequestUser>();
            foreach (var UserID in UserIDList)
            {
                var check_user = new Mall_CheckRequestUser();
                check_user.UserID = UserID;
                check_user_list.Add(check_user);
            }
            HttpFileCollection uploadFiles = context.Request.Files;
            List<string> ImagePathList = new List<string>();
            if (uploadFiles.Count > 0)
            {
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile postedFile = uploadFiles[i];
                    string fileOriName = postedFile.FileName;
                    if (fileOriName != "" && fileOriName != null)
                    {
                        string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                        string fileNameWithOutExtenSion = DateTime.Now.ToFileTime().ToString();
                        string fileName = fileNameWithOutExtenSion + extension;
                        string filepath = "/upload/Mall/UserCheck/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        ImagePathList.Add(filepath + fileName);
                    }
                }
            }
            if (ImagePathList.Count > 0)
            {
                data.ImagePath = string.Join(",", ImagePathList.ToArray());
            }
            string CheckRules = context.Request["RuleList"];
            List<Dictionary<string, object>> RuleList = new List<Dictionary<string, object>>();
            if (!string.IsNullOrEmpty(CheckRules))
            {
                RuleList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(CheckRules);
            }
            Mall_CheckRequestRule[] db_check_rule_list = new Mall_CheckRequestRule[] { };
            if (data.ID > 0)
            {
                db_check_rule_list = Mall_CheckRequestRule.GetMall_CheckRequestRuleListByRequestID(data.ID);
            }
            List<Mall_CheckRequestRule> check_rule_list = new List<Mall_CheckRequestRule>();
            foreach (var item in RuleList)
            {
                Mall_CheckRequestRule request_rule = null;
                int RequestRuleID = 0;
                int.TryParse(item["ID"].ToString(), out RequestRuleID);
                if (RequestRuleID > 0)
                {
                    request_rule = db_check_rule_list.FirstOrDefault(p => p.ID == RequestRuleID);
                }
                int RuleID = 0;
                int.TryParse(item["RuleID"].ToString(), out RuleID);
                int CategoryType = 0;
                int.TryParse(item["CategoryType"].ToString(), out CategoryType);
                if (request_rule == null)
                {
                    request_rule = new Mall_CheckRequestRule();
                    request_rule.AddTime = DateTime.Now;
                    request_rule.RuleID = RuleID;
                    request_rule.EarnType = CategoryType;
                }
                int PointValue = 0;
                int.TryParse(item["PointValue"].ToString(), out PointValue);
                request_rule.PointValue = PointValue;
                check_rule_list.Add(request_rule);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@RequestID", data.ID));
                    helper.Execute("delete from [Mall_CheckRequestUser] where [RequestID]=@RequestID", CommandType.Text, parameters);
                    foreach (var item in check_user_list)
                    {
                        item.RequestID = data.ID;
                        item.Save(helper);
                    }
                    foreach (var item in check_rule_list)
                    {
                        item.RequestID = data.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "savemallusercheck", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removemallcheckrequestrule(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Mall_CheckRequestRule.DeleteMall_CheckRequestRule(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmallcheckrequestrulelist(HttpContext context)
        {
            try
            {
                int RequestID = WebUtil.GetIntValue(context, "RequestID");
                var data = Mall_CheckRequest.GetMall_CheckRequest(RequestID);
                var list = Mall_CheckRequestRuleDetail.GetMall_CheckRequestRuleDetailListByRequestID(RequestID);
                var count = 0;
                var items = list.Select(p =>
                {
                    count++;
                    string PointRange = data.RequestType == 2 ? "" : p.PointRange;
                    var item = new { ID = p.ID, RuleID = p.RuleID, CategoryTypeDesc = p.CategoryTypeDesc, CategoryName = p.CategoryName, CheckName = p.CheckName, PointRange = PointRange, PointValue = p.PointValue, StartPoint = p.StartPoint, EndPoint = p.EndPoint, count = count };
                    return item;
                });
                WebUtil.WriteJson(context, new { status = true, list = list });
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "getmallcheckrequestrulelist", ex);
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
        }
        private void deletemallcheckrequestattach(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Mall_CheckRequest.GetMall_CheckRequest(ID);
            if (data == null)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            if (string.IsNullOrEmpty(data.ImagePath))
            {
                WebUtil.WriteJson(context, new { status = true });
                return;
            }
            int index = WebUtil.GetIntValue(context, "index");
            string[] ImageList = data.ImagePath.Split(',');
            string NewImagePath = string.Empty;
            var count = 0;
            foreach (var ImagePath in ImageList)
            {
                if (index == 0)
                {
                    if (count > 1)
                    {
                        NewImagePath += ",";
                    }
                }
                else if (count > 0)
                {
                    NewImagePath += ",";
                }
                if (count != index)
                {
                    NewImagePath += ImagePath;
                }
                count++;
            }
            data.ImagePath = NewImagePath;
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmallcheckrequestattachs(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Mall_CheckRequest.GetMall_CheckRequest(ID);
            if (data == null)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            if (string.IsNullOrEmpty(data.ImagePath))
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            string[] ImageList = data.ImagePath.Split(',');
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            var index = 0;
            foreach (var ImagePath in ImageList)
            {
                var dic = new Dictionary<string, object>();
                dic["index"] = index;
                dic["ImagePath"] = ImagePath;
                list.Add(dic);
                index++;
            }
            WebUtil.WriteJson(context, new { status = true, list = list });
        }
        private void savemallcheckrule(HttpContext context)
        {
            int CategoryID = WebUtil.GetIntValue(context, "CategoryID");
            int ID = WebUtil.GetIntValue(context, "ID");
            Mall_CheckInfo data = null;
            if (ID > 0)
            {
                data = Mall_CheckInfo.GetMall_CheckInfo(ID);
            }
            if (data == null)
            {
                data = new Mall_CheckInfo();
                data.AddTime = DateTime.Now;
                data.AddUserName = WebUtil.GetUser(context).LoginName;
            }
            data.CheckCategoryID = CategoryID;
            data.CheckName = context.Request["CheckName"];
            data.CheckSummary = context.Request["CheckSummary"];
            data.StartPoint = WebUtil.GetIntValue(context, "StartPoint");
            data.EndPoint = WebUtil.GetIntValue(context, "EndPoint");
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemallcheckcategory(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Mall_CheckCategory data = null;
            if (ID > 0)
            {
                data = Mall_CheckCategory.GetMall_CheckCategory(ID);
            }
            if (data == null)
            {
                data = new Mall_CheckCategory();
                data.AddTime = DateTime.Now;
                data.AddUserName = WebUtil.GetUser(context).LoginName;
            }
            data.CategoryName = context.Request["CategoryName"];
            data.CategoryType = WebUtil.GetIntValue(context, "CategoryType");
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removemallcheckrules(HttpContext context)
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
                        string cmdtext = "delete from [Mall_CheckInfo] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removemallcheckrules", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmallcheckrulegrid(HttpContext context)
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
                int CategoryType = WebUtil.GetIntValue(context, "CategoryType");
                DataGrid dg = Mall_CheckInfoDetail.GetMall_CheckInfoDetailGridByKeywords(Keywords, TreeIDList, "order by AddTime asc", startRowIndex, pageSize, CategoryType);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "getmallcheckrulegrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
                return;
            }
        }
        private void removecheckcategory(HttpContext context)
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
                        string cmdtext = "delete from [Mall_CheckInfo] where [CheckCategoryID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        cmdtext += "delete from [Mall_CheckCategory] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError(LogModule, "命令: removecheckcategory", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getcheckcategorytree(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                int type = WebUtil.GetIntValue(context, "type");
                var list = Foresight.DataAccess.Mall_CheckCategory.GetMall_CheckCategoryListByKeywords(Keywords, type);
                TreeModule treeModule = null;
                var items = list.Select(p =>
                {
                    treeModule = new TreeModule();
                    treeModule.id = "checkcategory_" + p.ID.ToString();
                    treeModule.ID = p.ID;
                    treeModule.pId = "checkcategory_0";
                    treeModule.name = p.CategoryName;
                    treeModule.isParent = false;
                    treeModule.open = true;
                    return treeModule;
                }).ToList();
                treeModule = new TreeModule();
                treeModule.id = "checkcategory_0";
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
                LogHelper.WriteError(LogModule, "visit: getcheckcategorytree", ex);
                context.Response.Write("[]");
            }
        }
        private void getusereditparams(HttpContext context)
        {
            //var department_list = Mall_Department.GetMall_Departments();
            var department_list = CKDepartment.GetCKDepartments().OrderBy(p => p.SortOrder).ThenByDescending(p => p.AddTime).ToArray();
            var department_items = department_list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.DepartmentName };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, departments = department_items });
        }
        private void removemalldepartment(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_Department] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "removemalldepartment", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemalldepartment(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Mall_Department data = null;
            if (ID > 0)
            {
                data = Mall_Department.GetMall_Department(ID);
            }
            if (data == null)
            {
                data = new Mall_Department();
                data.AddTime = DateTime.Now;
                data.AddUserName = WebUtil.GetUser(context).LoginName;
            }
            data.Name = context.Request["DepartmentName"];
            data.Summary = context.Request["Description"];
            data.SortOrder = WebUtil.GetIntValue(context, "SortOrder");
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadmalldepartmentgrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = CKDepartment.GetCKDepartmentGridByKeywords(keywords, "order by [SortOrder] asc, AddTime desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "loadmalldepartmentgrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void removemallamountrule(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            var list = Mall_DoorRemoteUser.GetMall_DoorRemoteUsers().Where(p => IDList.Contains(p.ID)).ToArray();
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_AmountRule] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "removemallamountrule", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadmallmemberamountrulegrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                int RuleType = WebUtil.GetIntValue(context, "RuleType");
                int AmountType = WebUtil.GetIntValue(context, "AmountType");
                DataGrid dg = Mall_AmountRuleDetail.GetMall_AmountRuleDetailGridByKeywords(keywords, startRowIndex, pageSize, RuleType, AmountType);
                var list = dg.rows as Mall_AmountRuleDetail[];
                List<int> amount_rule_idlist = list.Select(p => p.ID).ToList();
                if (amount_rule_idlist.Count > 0)
                {
                    var service_list = Mall_AmountRuleServiceDetail.GetMall_AmountRuleServiceDetailListByAmountRuleIDList(amount_rule_idlist);
                    foreach (var item in list)
                    {
                        var my_service_list = service_list.Where(p => p.AmountRuleID == item.ID).ToArray();
                        string AdditionalEarnServiceDesc = string.Empty;
                        if (my_service_list.Length > 0)
                        {
                            for (int i = 0; i < my_service_list.Length; i++)
                            {
                                if (i > 0)
                                {
                                    AdditionalEarnServiceDesc += ", ";
                                }
                                AdditionalEarnServiceDesc += my_service_list[i].CouponName;
                            }
                        }
                        else
                        {
                            AdditionalEarnServiceDesc = "无";
                        }
                        item.AdditionalEarnServiceDesc = AdditionalEarnServiceDesc;
                    }
                    dg.rows = list;
                }
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "loadmallmemberamountrulegrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void savemallamountrule(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            decimal StartAmount = getDecimalValue(context, "tdStartAmount");
            decimal EndAmount = getDecimalValue(context, "tdEndAmount");
            int AmountType = getIntValue(context, "tdAmountType");
            int RuleType = getIntValue(context, "tdRuleType");
            string ProjectIDs = context.Request["ProjectIDList"];
            List<int> ProjectIDList = new List<int>();
            if (!string.IsNullOrEmpty(ProjectIDs))
            {
                ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
            }
            bool IsUseForALLProject = getIntValue(context, "tdIsUseForALLProject") == 1;
            var list = Mall_AmountRule.GetMall_AmountRuleListByAmount(StartAmount, EndAmount, ID: ID, AmountType: AmountType, RuleType: RuleType, ProjectIDList: ProjectIDList, IsUseForALLProject: IsUseForALLProject);
            if (list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "金额区间有冲突" });
                return;
            }
            Mall_AmountRule data = null;
            if (ID > 0)
            {
                data = Mall_AmountRule.GetMall_AmountRule(ID);
            }
            if (data == null)
            {
                data = new Mall_AmountRule();
                data.AddTime = DateTime.Now;
                data.AddUserName = WebUtil.GetUser(context).LoginName;
            }
            data.RuleType = RuleType;
            data.BackAmount = 0;
            data.BackPoint = 0;
            data.AdditionalEarnService = false;
            if (data.RuleType == 1)
            {
                data.BackPoint = getIntValue(context, "tdBackPoint");
                data.BackPointType = getIntValue(context, "tdBackPointType");
            }
            else if (data.RuleType == 2)
            {
                data.BackAmount = getDecimalValue(context, "tdBackAmount");
                data.BackAmountType = getIntValue(context, "tdBackAmountType");
            }
            else if (data.RuleType == 3)
            {
                data.AdditionalEarnService = true;
            }
            data.Title = getValue(context, "tdTitle");
            data.StartAmount = getDecimalValue(context, "tdStartAmount");
            data.EndAmount = getDecimalValue(context, "tdEndAmount");
            data.Remark = getValue(context, "tdRemark");
            data.IsActive = getIntValue(context, "tdIsActive") == 1;
            data.AmountType = AmountType;
            data.IsSendNow = getIntValue(context, "tdIsSendNow") == 1;
            data.IsReadySendTime = getTimeValue(context, "tdIsReadySendTime");
            data.SendCouponCount = getIntValue(context, "tdSendCouponCount");
            data.IsUseForALLProject = IsUseForALLProject;
            data.IsUseForALLProduct = WebUtil.getServerIntValue(context, "tdIsUseForALLProduct") == 1;
            data.IsUseForALLService = WebUtil.getServerIntValue(context, "tdIsUseForALLService") == 1;
            data.PopupUnTakeDay = getIntValue(context, "tdPopupUnTakeDay");
            data.PopupBeforeExpireDay = getIntValue(context, "tdPopupBeforeExpireDay");
            List<Mall_AmountRuleService> rule_service_list = new List<Mall_AmountRuleService>();
            if (data.AdditionalEarnService)
            {
                string serviceitems = context.Request["servicelist"];
                List<int> CouponCodeIDList = new List<int>();
                if (!string.IsNullOrEmpty(serviceitems))
                {
                    CouponCodeIDList = JsonConvert.DeserializeObject<List<int>>(serviceitems);
                }
                foreach (var CouponCodeID in CouponCodeIDList)
                {
                    var rule_service_data = new Mall_AmountRuleService();
                    rule_service_data.Quantity = 1;
                    rule_service_data.CouponCodeID = CouponCodeID;
                    rule_service_data.AddTime = DateTime.Now;
                    rule_service_list.Add(rule_service_data);
                }
            }
            var user = WebUtil.GetUser(context);
            List<Mall_AmountRuleProduct> amount_productlist = new List<Mall_AmountRuleProduct>();
            List<int> ProductIDList = new List<int>();
            if (!string.IsNullOrEmpty(context.Request["ProductIDList"]) && !data.IsUseForALLProduct)
            {
                ProductIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["ProductIDList"]);
            }
            List<int> ServiceIDList = new List<int>();
            if (!string.IsNullOrEmpty(context.Request["ServiceIDList"]) && !data.IsUseForALLService)
            {
                ServiceIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["ServiceIDList"]);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    string cmdtext = "delete from [Mall_AmountRuleService] where AmountRuleID=@AmountRuleID";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@AmountRuleID", data.ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    foreach (var item in rule_service_list)
                    {
                        item.AmountRuleID = data.ID;
                        item.Save(helper);
                    }
                    cmdtext = "delete from [Mall_AmountRuleProject] where Mall_AmountRuleID=@AmountRuleID";
                    parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@AmountRuleID", data.ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    if (!data.IsUseForALLProject)
                    {
                        foreach (var ProjectID in ProjectIDList)
                        {
                            var item = new Mall_AmountRuleProject();
                            item.ProjectID = ProjectID;
                            item.Mall_AmountRuleID = data.ID;
                            item.Save(helper);
                        }
                    }
                    
                    cmdtext = "delete from [Mall_AmountRuleProduct] where AmountRuleID=@AmountRuleID";
                    parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@AmountRuleID", data.ID));
                    if (!data.IsUseForALLProduct)
                    {
                        foreach (var ProductID in ProductIDList)
                        {
                            var item = new Mall_AmountRuleProduct();
                            item.ProductID = ProductID;
                            item.AddTime = DateTime.Now;
                            item.AddUserName = user.LoginName;
                            item.AmountRuleID = data.ID;
                            item.Save(helper);
                        }
                    }
                    if (!data.IsUseForALLService)
                    {
                        foreach (var ServiceID in ServiceIDList)
                        {
                            var item = new Mall_AmountRuleProduct();
                            item.ServiceID = ServiceID;
                            item.AddTime = DateTime.Now;
                            item.AddUserName = user.LoginName;
                            item.AmountRuleID = data.ID;
                            item.Save(helper);
                        }
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "savemallamountrule", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getamountruleeditparam(HttpContext context)
        {
            var level_list = Foresight.DataAccess.Mall_UserLevel.GetMall_UserLevels();
            var level_items = level_list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.Name };
                return item;
            }).ToList();
            level_items.Insert(0, new { ID = 0, Name = "无" });
            WebUtil.WriteJson(context, new { stats = true, levellist = level_items });
        }
        private void removedoorremoteuser(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            var list = Mall_DoorRemoteUser.GetMall_DoorRemoteUsers().Where(p => IDList.Contains(p.ID)).ToArray();
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_DoorRemoteUserDevice] where DoorRemoteID in (" + string.Join(",", IDList.ToArray()) + ");";
                    cmdtext += "delete from [Mall_DoorRemoteUser] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "removedoorremoteuser", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemalldoorremoteuser(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string ProjectName = context.Request["ProjectName"];
            int UserID = WebUtil.GetIntValue(context, "UserID");
            int RelationID = WebUtil.GetIntValue(context, "RelationID");
            if (RelationID <= 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择用户" });
                return;
            }
            List<int> DeviceIDList = new List<int>();
            if (string.IsNullOrEmpty(context.Request["DeviceIDList"]))
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择设备" });
                return;
            }
            DeviceIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["DeviceIDList"]);
            var device_list = Mall_DoorDevice.GetALLActiveMall_DoorDeviceList().Where(p => DeviceIDList.Contains(p.ID)).ToArray();
            int ProjectID = getIntValue(context, "tdProjectID");

            string Title = getValue(context, "tdTile");
            bool IsForever = getIntValue(context, "tdIsForever") == 1;
            DateTime EndTime = getTimeValue(context, "tdEndTime");
            bool IsActive = getIntValue(context, "tdIsActive") == 1;
            string Description = getValue(context, "tdDescription");
            int EndDays = getIntValue(context, "tdEndDays");
            if (!IsForever && EndTime < DateTime.Now.AddDays(-1))
            {
                WebUtil.WriteJson(context, new { status = false, error = "结束日期不能小于当前日期" });
                return;
            }
            int[] deviceIds = device_list.Select(p => p.DeviceID).ToArray();
            Mall_DoorRemoteUser data = null;
            if (ID > 0)
            {
                data = Mall_DoorRemoteUser.GetMall_DoorRemoteUser(ID);
            }
            if (data == null)
            {
                data = new Mall_DoorRemoteUser();
                data.AddTime = DateTime.Now;
                data.AddUserName = WebUtil.GetUser(context).LoginName;
            }
            UserID = UserID > 0 ? UserID : 0;
            data.ProjectID = ProjectID;
            data.ProjectName = ProjectName;
            data.UserID = UserID;
            data.RoomPhoneRelationID = WebUtil.GetIntValue(context, "RelationID");
            data.Title = Title;
            data.Description = Description;
            data.IsForever = IsForever;
            data.EndTime = EndTime;
            data.IsActive = IsActive;
            List<Mall_DoorRemoteUserDevice> insert_card_device_list = new List<Mall_DoorRemoteUserDevice>();
            foreach (var item in device_list)
            {
                var my_remote_device = new Mall_DoorRemoteUserDevice();
                my_remote_device.DoorDeviceID = item.DeviceID;
                insert_card_device_list.Add(my_remote_device);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@DoorRemoteID", data.ID));
                    helper.Execute("delete from [Mall_DoorRemoteUserDevice] where [DoorRemoteID]=@DoorRemoteID", CommandType.Text, parameters);
                    foreach (var item in insert_card_device_list)
                    {
                        item.DoorRemoteID = data.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "savemalldoorremoteuser", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmalldoorremoteusergrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = Mall_DoorRemoteUserDetail.GetMall_DoorRemoteUserDetailGridByKeywords(keywords, startRowIndex, pageSize);
                var list = dg.rows as Mall_DoorRemoteUserDetail[];
                if (list.Length > 0)
                {
                    List<int> remote_idlist = list.Select(p => p.ID).ToList();
                    var remote_device_list = Mall_DoorRemoteUserDevice.GetMall_DoorRemoteUserDevices().Where(p => remote_idlist.Contains(p.DoorRemoteID)).ToArray();
                    var device_list = Mall_DoorDevice.GetALLActiveMall_DoorDeviceList().ToArray();
                    var user_list = Foresight.DataAccess.RoomPhoneRelation.GetRoomPhoneRelations().Where(p => list.Select(q => q.RoomPhoneRelationID).Contains(p.ID)).ToArray();
                    foreach (var item in list)
                    {
                        var my_remote_device_list = remote_device_list.Where(p => p.DoorRemoteID == item.ID).ToArray();
                        List<int> my_deviceidlist = my_remote_device_list.Select(p => p.DoorDeviceID).ToList();
                        var my_device_list = device_list.Where(p => my_deviceidlist.Contains(p.DeviceID)).ToArray();
                        if (my_device_list.Length > 0)
                        {
                            item.DeviceInfo = string.Join(",", my_device_list.Select(p =>
                            {
                                return "【" + p.DeviceID + "," + p.DeviceName + "】";
                            }).ToArray());
                        }
                        var my_user = user_list.FirstOrDefault(p => p.ID == item.RoomPhoneRelationID);
                        if (my_user != null)
                        {
                            item.NickName = my_user.RelationName;
                            item.PhoneNumber = my_user.RelatePhoneNumber;
                        }
                    }
                    dg.rows = list;
                }
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "getmalldoorremoteusergrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void removemalluserforbidden(HttpContext context)
        {
            string IDs = context.Request["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = true });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_UserForbidden] where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "removemalluserforbidden", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmalluserforbiddengrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = Mall_UserForbiddenDetail.GetMall_UserForbiddenDetailGridByKeyword(keywords, startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "getmalluserforbiddengrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void savemalluserforbidden(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Mall_UserForbidden data = null;
            if (ID > 0)
            {
                data = Mall_UserForbidden.GetMall_UserForbidden(ID);
            }
            if (data == null)
            {
                data = new Mall_UserForbidden();
                data.AddTime = DateTime.Now;
            }
            data.UserID = getIntValue(context, "hdUserID");
            data.ForbiddenStartTime = getTimeValue(context, "tdStartTime");
            data.ForbiddenEndTime = getTimeValue(context, "tdEndTime");
            data.ThreadID = 0;
            data.Save();
            WebUtil.WriteJson(context, new { status = true, ID = data.ID });
        }
        private void stopmallthread(HttpContext context)
        {
            string IDs = context.Request["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = true });
                return;
            }
            int type = WebUtil.GetIntValue(context, "type");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [Mall_Thread] set [IsStopComment]=@type where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@type", type));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "stopmallthread", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removemallthreadcomment(HttpContext context)
        {
            string IDs = context.Request["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = true });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_ThreadComment] where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "removemallthread", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removemallthread(HttpContext context)
        {
            string IDs = context.Request["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = true });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_ThreadComment] where [ThreadID] in (" + string.Join(",", IDList.ToArray()) + ");";
                    cmdtext += "delete from [Mall_ThreadImage] where [ThreadID] in (" + string.Join(",", IDList.ToArray()) + ");";
                    cmdtext += "delete from [Mall_ThreadPraise] where [ThreadID] in (" + string.Join(",", IDList.ToArray()) + ");";
                    cmdtext += "delete from [Mall_Thread] where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "removemallthread", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmallthreadcommentgrid(HttpContext context)
        {
            try
            {
                int ID = WebUtil.GetIntValue(context, "ID");
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = Mall_ThreadCommentDetail.GetMall_ThreadCommentDetailGridByKeyword(ID, keywords, startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "getmallthreadcommentgrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void getmallthreadgrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                int Type = WebUtil.GetIntValue(context, "Type");
                DataGrid dg = Mall_ThreadDetail.GetMall_ThreadDetailListByKeyword(keywords, startRowIndex, pageSize, ThreadType: Type);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "getmallthreadgrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void removemallhotsale(HttpContext context)
        {
            string IDs = context.Request["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = true });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_HotSale] where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "removemallhotsale", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadmallhotsalegrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = Mall_HotSaleDetail.GetMall_HotSaleDetailGridByKeywords(keywords, startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "loadmallhotsalegrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void savemallhotsale(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Mall_HotSale data = null;
            if (ID > 0)
            {
                data = Mall_HotSale.GetMall_HotSale(ID);
            }
            if (data == null)
            {
                data = new Mall_HotSale();
                data.AddTime = DateTime.Now;
            }
            data.Type = getIntValue(context, "tdType");
            data.SortOrder = getIntValue(context, "tdSortOrder");
            if (data.Type == 1)
            {
                data.RelatedID = getIntValue(context, "tdProductID");
            }
            else if (data.Type == 2)
            {
                data.RelatedID = getIntValue(context, "tdBusinessID");
            }
            data.StartTime = getTimeValue(context, "tdStartTime");
            data.EndTime = getTimeValue(context, "tdEndTime");
            data.Save();
            WebUtil.WriteJson(context, new { status = true, ID = data.ID });
        }
        private void getmallhotsaleeditparams(HttpContext context)
        {
            var product_list = Mall_Product.GetMall_Products().Where(p => p.Status == 10).ToArray();
            var business_list = Mall_Business.GetMall_Businesses().Where(p => p.Status == 1).ToArray();
            var product_items = product_list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.ProductName };
                return item;
            });
            var business_items = business_list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.BusinessName };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, product_list = product_items, business_list = business_items });
        }
        private void savechatkeywords(HttpContext context)
        {
            string key_values = context.Request["list"];
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            if (!string.IsNullOrEmpty(key_values))
            {
                list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(key_values);
            }
            if (list.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            List<int> IDList = list.Where(p => Convert.ToInt32(p["id"]) > 0).Select(p =>
            {
                return Convert.ToInt32(p["ID"]);
            }).ToList();
            var keywords_list = Mall_ChatSensitive.GetMall_ChatSensitiveListByIDList(IDList);
            List<Mall_ChatSensitive> db_list = new List<Mall_ChatSensitive>();
            foreach (var item in list)
            {
                var my_keywords = keywords_list.FirstOrDefault(p => IDList.Contains(p.ID));
                if (my_keywords == null)
                {
                    my_keywords = new Mall_ChatSensitive();
                    my_keywords.AddTime = DateTime.Now;
                }
                my_keywords.Keywords = item["value"].ToString();
                my_keywords.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removechatkeywords(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Mall_ChatSensitive.DeleteMall_ChatSensitive(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getchatkeywords(HttpContext context)
        {
            var list = Mall_ChatSensitive.GetMall_ChatSensitives().ToArray();
            var keywords_items = list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.Keywords };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, keywords_list = keywords_items });
        }
        private void savemallorderrefund(HttpContext context)
        {
            var user = WebUtil.GetUser(context);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Mall_Order.GetMall_Order(ID);
            if (data == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "订单不存在" });
                return;
            }
            if (data.OrderStatus != 6 || data.TotalOrderCost <= 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "操作不允许" });
                return;
            }
            var list = Foresight.DataAccess.Mall_OrderRefundRequest.GetMall_OrderRefundRequestListByOrderID(data.ID).OrderByDescending(p => p.AddTime).ToArray();
            if (list.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "申请退款已删除" });
                return;
            }
            var refund_request = list[0];
            string RefundNo = WxPayAPI.WxPayApi.GenerateOutTradeNo();
            int RefundAmount = Convert.ToInt32(data.TotalOrderCost * 100);
            string result = string.Empty;
            bool IsSuccess = false;
            if (data.PaymentMethod.Equals(Utility.EnumModel.Mall_OrderPaymentMethodDefine.wxpay.ToString()))
            {
                IsSuccess = APPCode.PaymentHelper.WxPayRefundRequest(data.TradeNo, RefundAmount, RefundNo, out result);
                if (IsSuccess)
                {
                    //返还账户余额退款后清除
                    Mall_UserBalance.Insert_Mall_UserBalance(data.UserID, 2, data.TotalOrderCost, "退款赠予金额清除", "OrderID:" + data.ID, 7, user.LoginName, 1, data.TradeNo, RelatedID: data.ID, PaymentMethod: data.PaymentMethod);
                    //返还积分退款后清除
                    Mall_UserPoint.Insert_Mall_UserPoint(data.UserID, 2, data.TotalOrderCost, "退款赠与积分清除", "OrderID:" + data.ID, 7, user.LoginName, 1, data.TradeNo, data.ID, RelatedID: data.ID);
                }
            }
            else if (data.PaymentMethod.Equals(Utility.EnumModel.Mall_OrderPaymentMethodDefine.alipay.ToString()))
            {
                IsSuccess = APPCode.PaymentHelper.AliPayRefundRequest(data.TradeNo, data.TotalOrderCost.ToString("0.00"), RefundNo, out result);
                if (IsSuccess)
                {
                    //返还账户余额退款后清除
                    Mall_UserBalance.Insert_Mall_UserBalance(data.UserID, 2, data.TotalOrderCost, "退款赠予金额清除", "OrderID:" + data.ID, 7, user.LoginName, 1, data.TradeNo, RelatedID: data.ID, PaymentMethod: data.PaymentMethod);
                    //返还积分退款后清除
                    Mall_UserPoint.Insert_Mall_UserPoint(data.UserID, 2, data.TotalOrderCost, "退款赠与积分清除", "OrderID:" + data.ID, 7, user.LoginName, 1, data.TradeNo, data.ID, RelatedID: data.ID);
                }
            }
            else if (data.PaymentMethod.Equals(Utility.EnumModel.Mall_OrderPaymentMethodDefine.balance.ToString()))
            {
                //消费账户金额返回到账户
                Mall_UserBalance.Insert_Mall_UserBalance(data.UserID, 1, data.TotalOrderCost, "订单退款", "OrderID:" + data.ID, 4, user.LoginName, 1, RefundNo, RelatedID: data.ID, PaymentMethod: data.PaymentMethod);
                //返还账户余额退款后清除
                Mall_UserBalance.Insert_Mall_UserBalance(data.UserID, 2, data.TotalOrderCost, "退款赠予金额清除", "OrderID:" + data.ID, 7, user.LoginName, 1, data.TradeNo, RelatedID: data.ID, PaymentMethod: data.PaymentMethod);
                //返还积分退款后清除
                Mall_UserPoint.Insert_Mall_UserPoint(data.UserID, 2, data.TotalOrderCost, "退款赠与积分清除", "OrderID:" + data.ID, 7, user.LoginName, 1, data.TradeNo, data.ID, RelatedID: data.ID);
                IsSuccess = true;
                result = "账户余额消费退款成功";
            }
            else if (data.PaymentMethod.Equals(Utility.EnumModel.Mall_OrderPaymentMethodDefine.point.ToString()))
            {
                Mall_UserPoint.Insert_Mall_UserPoint(data.UserID, 1, data.TotalOrderCost, "积分购买退货返回", "OrderID:" + data.ID, 3, "System", 1, RefundNo, data.ID, RelatedID: data.ID);
                IsSuccess = true;
                result = "积分消费退款成功";
            }
            if (IsSuccess)
            {
                data.RefundTrackNo = RefundNo;
                data.RefundTime = DateTime.Now;
                data.OrderStatus = 7;
                data.Save();
                refund_request.RefundAmount = Convert.ToDecimal(RefundAmount);
                refund_request.RefundTrackNo = RefundNo;
                refund_request.IsSuccess = IsSuccess;
                refund_request.Result = result;
                refund_request.Save();
                //推送通知用户
                var app_user = Foresight.DataAccess.User.GetUser(data.UserID);
                if (app_user != null && !string.IsNullOrEmpty(app_user.DeviceId))
                {
                    var company = Foresight.DataAccess.Company.GetCompanies().FirstOrDefault();
                    string companyname = company != null ? company.CompanyName : "永友网络";
                    string[] android_cids = app_user.DeviceType.Equals("android") ? new string[] { app_user.DeviceId } : new string[] { };
                    string[] ios_cids = app_user.DeviceType.Equals("ios") ? new string[] { app_user.DeviceId } : new string[] { };
                    Dictionary<string, object> extras = new Dictionary<string, object>();
                    int ContentCode = 601;
                    string ContentMsg = "您的订单" + data.OrderNumber + "已退款成功";
                    var extra_model = new Utility.JpushContent(ContentCode, Msg: ContentMsg, Type: "mallorder_refund");
                    extras["code"] = extra_model.code;
                    extras["msg"] = extra_model.msg;
                    extras["type"] = extra_model.type;
                    extras["id"] = data.ID;
                    string push_result = JPush.JpushAPI.PushMessage(companyname, extras, android_cids: android_cids, ios_cids: ios_cids, msg_content: extra_model.msg, PushAPP: 2, IsToAll: false);
                    Foresight.DataAccess.JPushLog.Insert_JPushLog(android_cids, ios_cids, extras, push_result, 9, data.ID, true, companyname);
                }
            }
            WebUtil.WriteJson(context, new { status = IsSuccess, error = result });
        }
        private void doremoteopendoor(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Mall_DoorDevice.GetMall_DoorDeviceSDKKeyByID(ID);
            string error = string.Empty;
            bool result = Utility.LLingHelper.doRemoteOpenDoor(data.SDKKey, out error);
            if (!result)
            {
                data.SDKKeyExpireDate = DateTime.Now;
                data.Save();
            }
            WebUtil.WriteJson(context, new { status = result, error = error });
        }
        private void savemallordershiprate(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            decimal ShipRateAmount = getDecimalValue(context, "tdShipRateAmount");
            if (ID > 0)
            {
                var order = Foresight.DataAccess.Mall_Order.GetMall_Order(ID);
                if (order.OrderStatus == 2)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已发货" });
                    return;
                }
                if (order.OrderStatus == 3)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已完成" });
                    return;
                }
                if (order.OrderStatus == 5)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已付款" });
                    return;
                }
                if (order.OrderStatus == 6)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已申请退款" });
                    return;
                }
                if (order.OrderStatus == 7)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已退款" });
                    return;
                }
                if (order.IsClosed)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已关闭" });
                    return;
                }
                order.ShipRateAmount = ShipRateAmount;
                order.Save();
            }
            else
            {
                string IDs = context.Request["IDList"];
                List<int> IDList = new List<int>();
                if (!string.IsNullOrEmpty(IDs))
                {
                    IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
                }
                if (IDList.Count > 0)
                {
                    var orderlist = Foresight.DataAccess.Mall_Order.GetMall_OrderListByIDList(IDList);
                    foreach (var item in orderlist)
                    {
                        if (item.OrderStatus == 2)
                        {
                            WebUtil.WriteJson(context, new { status = false, error = "订单已发货" });
                            return;
                        }
                        if (item.OrderStatus == 3)
                        {
                            WebUtil.WriteJson(context, new { status = false, error = "订单已完成" });
                            return;
                        }
                        if (item.OrderStatus == 5)
                        {
                            WebUtil.WriteJson(context, new { status = false, error = "订单已付款" });
                            return;
                        }
                        if (item.OrderStatus == 6)
                        {
                            WebUtil.WriteJson(context, new { status = false, error = "订单已申请退款" });
                            return;
                        }
                        if (item.OrderStatus == 7)
                        {
                            WebUtil.WriteJson(context, new { status = false, error = "订单已退款" });
                            return;
                        }
                        if (item.IsClosed)
                        {
                            WebUtil.WriteJson(context, new { status = false, error = "订单已关闭" });
                            return;
                        }
                        if (item.OriginalTotalCost <= 0)
                        {
                            item.OriginalTotalCost = item.TotalCost;
                        }
                        item.ShipRateAmount = ShipRateAmount;
                    }
                    using (SqlHelper helper = new SqlHelper())
                    {
                        try
                        {
                            helper.BeginTransaction();
                            foreach (var item in orderlist)
                            {
                                item.Save(helper);
                            }
                            helper.Commit();
                        }
                        catch (Exception ex)
                        {
                            helper.Rollback();
                            LogHelper.WriteError(LogModule, "savemallordershiprate", ex);
                            WebUtil.WriteJson(context, new { status = false });
                            return;
                        }
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removemallshiprate(HttpContext context)
        {
            string IDs = context.Request["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = true });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_ShipRateDetail_Province] where [RateID] in (" + string.Join(",", IDList.ToArray()) + ");";
                    cmdtext += "delete from [Mall_ShipRateDetail] where [RateID] in (" + string.Join(",", IDList.ToArray()) + ");";
                    cmdtext += "delete from [Mall_ShipRate] where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "removemallshiprate", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadmallshiprategrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = Mall_ShipRateAdditonal.GetMall_ShipRateAdditonalGridByKeywords(keywords, startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "loadmallshiprategrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void removemallshipratedetail(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_ShipRateDetail_Province] where [RateDetailID]=@RateDetailID;";
                    cmdtext += "delete from [Mall_ShipRateDetail] where [ID]=@RateDetailID;";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@RateDetailID", ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "removemallshipratedetail", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmallshipratedetails(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var shiprate_detail_dblist = Mall_ShipRateDetail.GetMall_ShipRateDetailListByRateID(ID);
            var shiprate_detail_province_dblist = Mall_ShipRateDetail_Province.GetMall_ShipRateDetail_ProvinceListByRateID(ID);
            int count = 0;
            var items = shiprate_detail_dblist.Select(p =>
            {
                count++;
                var my_shiprate_detail_province_dblist = shiprate_detail_province_dblist.Where(q => q.RateDetailID == p.ID).ToArray();
                List<int> ProvinceIDList = my_shiprate_detail_province_dblist.Select(q => q.ProvinceID).ToList();
                var item = new { ID = p.ID, RateID = p.RateID, DefaultQuantity = p.DefaultQuantity, DefaultAmount = p.DefaultMoney, AdditionalQuantity = p.AdditionalQuantity, AdditionalAmount = p.AdditionalMoney, count = count, ProvinceIDList = ProvinceIDList };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void savemallshiprate(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Mall_ShipRate data = null;
            Mall_ShipRateDetail default_rate_detail = null;
            Mall_ShipRateDetail[] shiprate_detail_dblist = new Mall_ShipRateDetail[] { };
            Mall_ShipRateDetail_Province[] shiprate_detail_province_dblist = new Mall_ShipRateDetail_Province[] { };
            if (ID > 0)
            {
                data = Mall_ShipRate.GetMall_ShipRate(ID);
                default_rate_detail = Mall_ShipRateDetail.GetDefaultMall_ShipRateDetailByRateID(ID);
                shiprate_detail_dblist = Mall_ShipRateDetail.GetMall_ShipRateDetailListByRateID(ID);
                shiprate_detail_province_dblist = Mall_ShipRateDetail_Province.GetMall_ShipRateDetail_ProvinceListByRateID(ID);
            }
            var user = WebUtil.GetUser(context);
            if (data == null)
            {
                data = new Mall_ShipRate();
                data.AddTime = DateTime.Now;
                data.AddUserName = user.LoginName;
            }
            data.RateTile = getValue(context, "tdRateTitle");
            data.RateType = getIntValue(context, "tdRateType");
            data.RateSummary = getValue(context, "tdRateSummary");
            data.IsDefault = getIntValue(context, "tdIsDefault") == 1;
            if (data.RateType == 1)
            {
                if (default_rate_detail == null)
                {
                    default_rate_detail = new Mall_ShipRateDetail();
                    default_rate_detail.IsDefault = true;
                    default_rate_detail.AddTime = DateTime.Now;
                    default_rate_detail.AddUserName = user.LoginName;
                }
                default_rate_detail.DefaultQuantity = getIntValue(context, "tdDefaultQuantity");
                default_rate_detail.DefaultMoney = getDecimalValue(context, "tdDefaultAmount");
                default_rate_detail.AdditionalQuantity = getIntValue(context, "tdAdditionalQuantity");
                default_rate_detail.AdditionalMoney = getDecimalValue(context, "tdAdditionalAmount");
            }
            string ratedetails = context.Request["ratedetails"];
            List<Dictionary<string, object>> ratedetail_dic_list = new List<Dictionary<string, object>>();
            if (!string.IsNullOrEmpty(ratedetails))
            {
                ratedetail_dic_list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(ratedetails);
            }
            List<Dictionary<string, object>> rate_detail_list = new List<Dictionary<string, object>>();
            if (ratedetail_dic_list.Count > 0)
            {
                foreach (var item in ratedetail_dic_list)
                {
                    var ratedetail_dic = new Dictionary<string, object>();
                    int DetailID = 0;
                    int.TryParse(item["ID"].ToString(), out DetailID);
                    Mall_ShipRateDetail rate_detail = null;
                    if (DetailID > 0)
                    {
                        rate_detail = shiprate_detail_dblist.FirstOrDefault(p => p.ID == DetailID);
                    }
                    if (rate_detail == null)
                    {
                        rate_detail = new Mall_ShipRateDetail();
                        rate_detail.IsDefault = false;
                        rate_detail.AddTime = DateTime.Now;
                        rate_detail.AddUserName = user.LoginName;
                    }
                    int DefaultQuantity = 0;
                    int.TryParse(item["DefaultQuantity"].ToString(), out DefaultQuantity);
                    decimal DefaultAmount = 0;
                    decimal.TryParse(item["DefaultAmount"].ToString(), out DefaultAmount);
                    int AdditionalQuantity = 0;
                    int.TryParse(item["AdditionalQuantity"].ToString(), out AdditionalQuantity);
                    decimal AdditionalAmount = 0;
                    decimal.TryParse(item["AdditionalAmount"].ToString(), out AdditionalAmount);
                    rate_detail.DefaultQuantity = DefaultQuantity;
                    rate_detail.DefaultMoney = DefaultAmount;
                    rate_detail.AdditionalQuantity = AdditionalQuantity;
                    rate_detail.AdditionalMoney = AdditionalAmount;
                    ratedetail_dic["rate_detail"] = rate_detail;
                    List<Mall_ShipRateDetail_Province> detail_province_list = new List<Mall_ShipRateDetail_Province>();
                    List<Mall_ShipRateDetail_Province> exisit_detail_province_list = new List<Mall_ShipRateDetail_Province>();
                    if (rate_detail.ID > 0)
                    {
                        exisit_detail_province_list = shiprate_detail_province_dblist.Where(p => p.RateDetailID == rate_detail.ID).ToList();
                    }
                    ratedetail_dic["exisit_detail_province_list"] = exisit_detail_province_list;
                    if (item["ProvinceIDList"] != null)
                    {
                        List<int> ProvinceIDList = JsonConvert.DeserializeObject<List<int>>(item["ProvinceIDList"].ToString());
                        foreach (var ProvinceID in ProvinceIDList)
                        {
                            var provice_data = new Mall_ShipRateDetail_Province();
                            provice_data.AddTime = DateTime.Now;
                            provice_data.AddUserName = user.LoginName;
                            provice_data.ProvinceID = ProvinceID;
                            detail_province_list.Add(provice_data);
                        }

                    }
                    ratedetail_dic["detail_province_list"] = detail_province_list;
                    rate_detail_list.Add(ratedetail_dic);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    if (default_rate_detail != null)
                    {
                        if (data.RateType == 2)
                        {
                            default_rate_detail.Delete(helper);
                        }
                        else
                        {
                            default_rate_detail.RateID = data.ID;
                            default_rate_detail.Save(helper);
                        }
                    }
                    foreach (var item in rate_detail_list)
                    {
                        var rate_detail = item["rate_detail"] as Mall_ShipRateDetail;
                        rate_detail.RateID = data.ID;
                        rate_detail.Save(helper);
                        var exisit_detail_province_list = item["exisit_detail_province_list"] as List<Mall_ShipRateDetail_Province>;
                        foreach (var item2 in exisit_detail_province_list)
                        {
                            item2.Delete(helper);
                        }
                        var detail_province_list = item["detail_province_list"] as List<Mall_ShipRateDetail_Province>;
                        foreach (var item2 in detail_province_list)
                        {
                            item2.RateID = data.ID;
                            item2.RateDetailID = rate_detail.ID;
                            item2.Save(helper);
                        }
                    }
                    if (data.IsDefault)
                    {
                        helper.Execute("update [Mall_ShipRate] set [IsDefault]=0 where ID !=" + data.ID + ";", CommandType.Text, new List<SqlParameter>());
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true, ID = data.ID });
        }
        private void deletemallproductcover(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Mall_Product.GetMall_Product(ID);
            data.CoverImage = string.Empty;
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadmallratecustomerlist(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = Mall_OrderCommentDetail.GetMall_OrderCommentDetailGridByKeywords(keywords, startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "loadmallratecustomerlist", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void deletedoorcard(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            var list = Mall_DoorCard.GetMall_DoorCards().Where(p => IDList.Contains(p.ID)).ToArray();
            string[] cardUids = list.Select(p => p.CardUID).ToArray();
            string error = string.Empty;
            bool result = Utility.LLingHelper.doRemoveOpenDoorCard(cardUids, out error);
            if (!result)
            {
                WebUtil.WriteJson(context, new { status = false, error = error });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_DoorCardDevice] where DoorCardID in (" + string.Join(",", IDList.ToArray()) + ");";
                    cmdtext += "delete from [Mall_DoorCard] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "deletedoorcard", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmalldoorcardanalysisgrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                DataGrid dg = Mall_DoorCardAnalysis.GetMall_DoorCardAnalysisGridByKeywords(keywords, startRowIndex, pageSize, ProjectIDList, RoomIDList, StartTime, EndTime);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "getmalldoorcardanalysisgrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void getmalldoorcardgrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                DataGrid dg = Mall_DoorCardDetail.GetMall_DoorCardDetailGridByKeywords(keywords, startRowIndex, pageSize, ProjectIDList, RoomIDList, StartTime, EndTime);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "getmalldoorcardgrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void savemalldoorcard(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string ProjectName = context.Request["ProjectName"];
            int UserID = WebUtil.GetIntValue(context, "UserID");
            int RelationID = WebUtil.GetIntValue(context, "RelationID");
            if (RelationID <= 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择用户" });
                return;
            }
            List<int> DeviceIDList = new List<int>();
            if (string.IsNullOrEmpty(context.Request["DeviceIDList"]))
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择设备" });
                return;
            }
            DeviceIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["DeviceIDList"]);
            var device_list = Mall_DoorDevice.GetALLActiveMall_DoorDeviceList().Where(p => DeviceIDList.Contains(p.ID)).ToArray();
            int ProjectID = getIntValue(context, "tdProjectID");

            string CardName = getValue(context, "tdCardName");
            string CardSummary = getValue(context, "tdCardSummary");
            string CardUID = getValue(context, "tdCardUID");
            DateTime ExpireDate = getTimeValue(context, "tdExpireDate");
            if (ExpireDate <= DateTime.Today)
            {
                WebUtil.WriteJson(context, new { status = false, error = "截止日期必须大于今天" });
                return;
            }
            int EndDays = Convert.ToInt32((ExpireDate - DateTime.Today).TotalDays);
            if (EndDays <= 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "截止日期必须大于今天" });
                return;
            }
            if (CardUID.Length < 8 || CardUID.Length > 16)
            {
                WebUtil.WriteJson(context, new { status = false, error = "cardUid卡必须是8位或者16位大写的16进制数" });
                return;
            }
            string[] cardUids = new string[] { CardUID };
            int[] deviceIds = device_list.Select(p => p.DeviceID).ToArray();
            Mall_DoorCard data = null;
            if (ID > 0)
            {
                data = Mall_DoorCard.GetMall_DoorCard(ID);
            }
            if (data == null)
            {
                string error = string.Empty;
                bool result = Utility.LLingHelper.doAddDoorOpenCard(cardUids, deviceIds, EndDays, out error);
                if (!result)
                {
                    WebUtil.WriteJson(context, new { status = false, error = error });
                    return;
                }
                data = new Mall_DoorCard();
                data.AddTime = DateTime.Now;
                data.AddUserName = WebUtil.GetUser(context).LoginName;
            }
            else
            {
                string error = string.Empty;
                bool result = Utility.LLingHelper.doUpdateDoorOpenCard(cardUids, deviceIds, EndDays, out error);
                if (!result)
                {
                    WebUtil.WriteJson(context, new { status = false, error = error });
                    return;
                }
            }
            data.ProjectID = ProjectID;
            data.ProjectName = ProjectName;
            data.UserID = UserID;
            data.RoomPhoneRelationID = RelationID;
            data.CardName = CardName;
            data.CardSummary = CardSummary;
            data.CardUID = CardUID;
            data.EndDays = EndDays;
            data.ExpireDate = ExpireDate;
            data.DoorNumber = getValue(context, "tdDoorNumber");
            data.SortOrder = getIntValue(context, "tdSortOrder");
            var card_device_list = new Mall_DoorCardDevice[] { };
            if (data.ID > 0)
            {
                card_device_list = Mall_DoorCardDevice.GetMall_DoorCardDeviceListByCardID(data.ID);
            }
            List<Mall_DoorCardDevice> insert_card_device_list = new List<Mall_DoorCardDevice>();
            foreach (var item in device_list)
            {
                var my_card_device = card_device_list.FirstOrDefault(p => p.DoorDeviceID == item.DeviceID);
                if (my_card_device == null)
                {
                    my_card_device = new Mall_DoorCardDevice();
                    my_card_device.DoorDeviceID = item.DeviceID;
                    insert_card_device_list.Add(my_card_device);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    foreach (var item in insert_card_device_list)
                    {
                        item.DoorCardID = data.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "savemalldoorcard", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadmallprojectusergrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
                bool IsHuHuoRen = WebUtil.GetIntValue(context, "IsHuHuoRen") == 1;
                DataGrid dg = ViewRoomPhoneRelation.GetViewRoomPhoneRelationGridByKeywords(keywords, ProjectID, startRowIndex, pageSize, IsHuHuoRen);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "loadmallprojectusergrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void getmalldoorcardeditparams(HttpContext context)
        {
            var project_list = Foresight.DataAccess.Project.GetProjectByParentID(1);
            var project_items = project_list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.Name };
                return item;
            });
            var device_list = Mall_DoorDevice.GetALLActiveMall_DoorDeviceList();
            var device_items = device_list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.DeviceName, ProjectID = p.ProjectID };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, project_list = project_items, device_list = device_items });
        }
        private void deletedoordevice(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            var list = Mall_DoorDevice.GetALLActiveMall_DoorDeviceList().Where(p => IDList.Contains(p.ID)).ToArray();
            List<int> Success_IDList = new List<int>();
            foreach (var item in list)
            {
                string error = string.Empty;
                bool result = Utility.LLingHelper.doRemoveDevice(item.DeviceID, out error);
                if (!result)
                {
                    WebUtil.WriteJson(context, new { status = false, error = error });
                    return;
                }
                Success_IDList.Add(item.ID);
            }
            if (Success_IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "门禁服务器异常" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_DoorDevice] where ID in (" + string.Join(",", Success_IDList.ToArray()) + ");";
                    helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "deletedoordevice", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemalldoordevice(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string DeviceName = getValue(context, "tdDeviceName");
            string DeviceCode = getValue(context, "tdDeviceCode");
            int ProjectID = getIntValue(context, "tdProjectID");
            string ProjectName = context.Request["ProjectName"];
            Mall_DoorDevice data = null;
            if (ID > 0)
            {
                data = Mall_DoorDevice.GetMall_DoorDevice(ID);
            }
            if (data == null)
            {
                data = new Mall_DoorDevice();
                data.AddTime = DateTime.Now;
                data.AddUserName = WebUtil.GetUser(context).LoginName;
                string error = string.Empty;
                int deviceID = Utility.LLingHelper.doAddDevice(DeviceName, DeviceCode, out error);
                if (deviceID == 0)
                {
                    WebUtil.WriteJson(context, new { status = false, error = error });
                    return;
                }
                data.DeviceID = deviceID;
                data.Status = 1;
            }
            else
            {
                string error = string.Empty;
                bool result = Utility.LLingHelper.doEditDevice(data.DeviceID, DeviceName, DeviceCode, out error);
                if (!result)
                {
                    WebUtil.WriteJson(context, new { status = false, error = error });
                    return;
                }
                var response = Utility.LLingHelper.doQueryDeviceSDKKeyList(new int[] { data.DeviceID }, out error);
                if (response.ContainsKey(data.DeviceID))
                {
                    data.SDKKey = response[data.DeviceID];
                    data.SDKKeyExpireDate = DateTime.Now.AddDays(99);
                }
            }
            data.DeviceCode = DeviceCode;
            data.DeviceName = DeviceName;
            data.ProjectID = ProjectID;
            data.ProjectName = ProjectName;
            data.IsUseAll = getIntValue(context, "tdUseForAll") == 1;
            data.SortOrder = getIntValue(context, "tdSortOrder");
            data.DisableQrCodeOpen = getIntValue(context, "tdDisableQrCodeOpen") == 0;
            string RoomIDs = context.Request["RoomIDs"];
            List<int> ProjectIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                ProjectIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            List<Mall_DoorDeviceProject> device_project_list = new List<Mall_DoorDeviceProject>();
            foreach (var RoomID in ProjectIDList)
            {
                var device_project = new Mall_DoorDeviceProject();
                device_project.ProjectID = RoomID;
                device_project_list.Add(device_project);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@DoorDeviceID", data.ID));
                    helper.Execute("delete from [Mall_DoorDeviceProject] where [DoorDeviceID]=@DoorDeviceID", CommandType.Text, parameters);
                    if (!data.IsUseAll)
                    {
                        foreach (var item in device_project_list)
                        {
                            item.DoorDeviceID = data.ID;
                            item.Save(helper);
                        }
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "savemalldoordevice", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmalldoordeviceeditparams(HttpContext context)
        {
            var project_list = Foresight.DataAccess.Project.GetProjectByParentID(1);
            var project_items = project_list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.Name };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, project_list = project_items });
        }
        private void getmalldoordevicegrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                DataGrid dg = Mall_DoorDevice.GetMall_DoorDeviceGridByKeywords(keywords, startRowIndex, pageSize, ProjectIDList, RoomIDList);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "loadmalltaggrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void savemallordernote(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string UserNote = getValue(context, "tdUserNote");
            if (ID > 0)
            {
                var order = Foresight.DataAccess.Mall_Order.GetMall_Order(ID);
                order.SellerNote = UserNote;
                order.Save();
            }
            else
            {
                string IDs = context.Request["IDList"];
                List<int> IDList = new List<int>();
                if (!string.IsNullOrEmpty(IDs))
                {
                    IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
                }
                if (IDList.Count > 0)
                {
                    var orderlist = Foresight.DataAccess.Mall_Order.GetMall_OrderListByIDList(IDList);
                    foreach (var item in orderlist)
                    {
                        item.SellerNote = UserNote;
                    }
                    using (SqlHelper helper = new SqlHelper())
                    {
                        try
                        {
                            helper.BeginTransaction();
                            foreach (var item in orderlist)
                            {
                                item.Save(helper);
                            }
                            helper.Commit();
                        }
                        catch (Exception ex)
                        {
                            helper.Rollback();
                            LogHelper.WriteError(LogModule, "savemallordernote", ex);
                            WebUtil.WriteJson(context, new { status = false });
                            return;
                        }
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemallordercost(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            decimal TotalCost = getDecimalValue(context, "tdTotalCost");
            if (ID > 0)
            {
                var order = Foresight.DataAccess.Mall_Order.GetMall_Order(ID);
                if (order.OrderStatus == 2)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已发货" });
                    return;
                }
                if (order.OrderStatus == 3)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已完成" });
                    return;
                }
                if (order.OrderStatus == 5)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已付款" });
                    return;
                }
                if (order.OrderStatus == 6)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已申请退款" });
                    return;
                }
                if (order.OrderStatus == 7)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已退款" });
                    return;
                }
                if (order.IsClosed)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已关闭" });
                    return;
                }
                if (order.OriginalTotalCost <= 0)
                {
                    order.OriginalTotalCost = order.TotalCost;
                }
                order.LastTotalCost = order.TotalCost;
                order.TotalCost = TotalCost;
                order.Save();
            }
            else
            {
                string IDs = context.Request["IDList"];
                List<int> IDList = new List<int>();
                if (!string.IsNullOrEmpty(IDs))
                {
                    IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
                }
                if (IDList.Count > 0)
                {
                    var orderlist = Foresight.DataAccess.Mall_Order.GetMall_OrderListByIDList(IDList);
                    foreach (var item in orderlist)
                    {
                        if (item.OrderStatus == 2)
                        {
                            WebUtil.WriteJson(context, new { status = false, error = "订单已发货" });
                            return;
                        }
                        if (item.OrderStatus == 3)
                        {
                            WebUtil.WriteJson(context, new { status = false, error = "订单已完成" });
                            return;
                        }
                        if (item.OrderStatus == 5)
                        {
                            WebUtil.WriteJson(context, new { status = false, error = "订单已付款" });
                            return;
                        }
                        if (item.OrderStatus == 6)
                        {
                            WebUtil.WriteJson(context, new { status = false, error = "订单已申请退款" });
                            return;
                        }
                        if (item.OrderStatus == 7)
                        {
                            WebUtil.WriteJson(context, new { status = false, error = "订单已退款" });
                            return;
                        }
                        if (item.IsClosed)
                        {
                            WebUtil.WriteJson(context, new { status = false, error = "订单已关闭" });
                            return;
                        }
                        if (item.OriginalTotalCost <= 0)
                        {
                            item.OriginalTotalCost = item.TotalCost;
                        }
                        item.LastTotalCost = item.TotalCost;
                        item.TotalCost = TotalCost;
                    }
                    using (SqlHelper helper = new SqlHelper())
                    {
                        try
                        {
                            helper.BeginTransaction();
                            foreach (var item in orderlist)
                            {
                                item.Save(helper);
                            }
                            helper.Commit();
                        }
                        catch (Exception ex)
                        {
                            helper.Rollback();
                            LogHelper.WriteError(LogModule, "savemallordercost", ex);
                            WebUtil.WriteJson(context, new { status = false });
                            return;
                        }
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmallorderlistbyvue(HttpContext context)
        {
            try
            {
                int status = WebUtil.GetIntValue(context, "status");
                string Keywords = context.Request.Params["Keywords"];
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string ProductName = context.Request["ProductName"];
                DateTime PayStartTime = WebUtil.GetDateValue(context, "PayStartTime");
                DateTime PayEndTime = WebUtil.GetDateValue(context, "PayEndTime");
                string BuyerNickName = context.Request["BuyerNickName"];
                int OrderStatus = WebUtil.GetIntValue(context, "OrderStatus");
                int RateStatus = WebUtil.GetIntValue(context, "RateStatus");
                string OrderNumber = context.Request["OrderNumber"];
                string ShipCompany = context.Request["ShipCompany"];
                int OrderType = WebUtil.GetIntValue(context, "OrderType");
                string BusinessName = context.Request["BusinessName"];
                string BuyerPhoneNumber = context.Request["BuyerPhoneNumber"];
                bool HideClose = false;
                bool.TryParse(context.Request["HideClose"], out HideClose);
                int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
                long totalRows = 0;
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                int ShareUserID = WebUtil.GetIntValue(context, "ShareUserID");
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                var orderlist = Mall_Order.GetMall_OrderListByKeywords(Keywords, StartTime, EndTime, status, startRowIndex, pageSize, ProductName, PayStartTime, PayEndTime, BuyerNickName, BuyerPhoneNumber, OrderStatus, RateStatus, OrderNumber, ShipCompany, OrderType, BusinessName, HideClose, ProjectID, out totalRows, canexport: canexport, ShareUserID: ShareUserID, ProjectIDList: ProjectIDList, RoomIDList: RoomIDList);
                var itemlist = Mall_OrderItem.GetMall_OrderItemListByOrderIDList(orderlist.Select(p => p.ID).ToList());
                var product_list = Mall_Product.GetMall_Products().ToArray();
                var business_list = Mall_Business.GetMall_Businesses().ToArray();
                var ShareUserIDList = orderlist.Where(p => p.ShareUserID > 0).Select(p => p.ShareUserID).Distinct().ToList();
                var share_user_list = Foresight.DataAccess.User.GetUserListByIDList(ShareUserIDList);
                var typeList = Wechat_HouseServiceTypeDetail.Get_Wechat_HouseServiceTypeList().ToArray();
                var items = orderlist.Select(p =>
                {
                    var item = p.ToJsonObject();
                    var my_itemlist = itemlist.Where(q => q.OrderID == p.ID);
                    var my_business = business_list.FirstOrDefault(q => my_itemlist.Select(m => m.BusinessID).ToList().Contains(q.ID));
                    var my_share_user = share_user_list.FirstOrDefault(q => q.UserID == p.ShareUserID);
                    item["ShareUserName"] = my_share_user == null ? "匿名" : my_share_user.FinalRealName;
                    item["BuyerName"] = p.AddressUserName;
                    item["BuyerPhone"] = p.AddressPhoneNumber;
                    item["FullAddressInfo"] = p.FinalAddressName;
                    item["ischecked"] = false;
                    item["BusinessName"] = my_business != null ? my_business.BusinessName : "自营";
                    item["AddTime"] = p.AddTime.ToString("yyyy-MM-dd HH:mm:ss");
                    item["OrderStatusDesc"] = p.OrderStatusDesc;
                    item["ProductTypeDesc"] = p.ProductTypeDesc;
                    item["PaymentMethodDesc"] = p.PaymentMethodDesc;
                    item["OrderID"] = p.ID;
                    item["TotalPoint"] = p.TotalOrderPointCost > 0 ? p.TotalOrderPointCost.ToString("0") : "0";
                    item["TotalCost"] = p.TotalOrderCost > 0 ? p.TotalOrderCost.ToString("0.00") : "0.00";
                    item["CouponAmount"] = p.CouponAmount > 0 ? p.CouponAmount.ToString("0.00") : "0.00";
                    item["itemlist"] = my_itemlist.Select(q =>
                    {
                        var item2 = q.ToJsonObject();
                        string imageurl = "../styles/images/error-img.png";
                        if (p.ProductTypeID == 10)
                        {
                            if (p.ProductTypeID == 10)
                            {
                                imageurl = "../styles/images/wyicon.jpg";
                            }
                        }
                        else if (p.ProductTypeID == 5)
                        {
                            var myType = typeList.FirstOrDefault(m => m.ID == q.ProductID);
                            if (myType != null && !string.IsNullOrEmpty(myType.CoverImage))
                            {
                                imageurl = WebUtil.GetContextPath() + myType.CoverImage;
                            }
                        }
                        else
                        {
                            var my_product = product_list.FirstOrDefault(m => m.ID == q.ProductID);
                            if (my_product != null && !string.IsNullOrEmpty(my_product.CoverImage))
                            {
                                imageurl = WebUtil.GetContextPath() + my_product.CoverImage;
                            }
                        }
                        item2["imageurl"] = imageurl;
                        item2["ProductTitle"] = q.ProductTitle;
                        item2["ProductSubTitle"] = q.ProductSubTitle;
                        return item2;
                    }).ToList();
                    return item;
                }).ToList();
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string errormsg = string.Empty;
                    bool downloadstatus = APPCode.ExportHelper.DownLoadMallOrderData(items, out downloadurl, out errormsg);
                    WebUtil.WriteJson(context, new { status = downloadstatus, downloadurl = downloadurl, error = errormsg });
                    return;
                }
                WebUtil.WriteJson(context, new { status = true, orderlist = items, totalrows = totalRows });
                return;
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "getmallorderlistbyvue", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void getmalltagparams(HttpContext context)
        {
            var list = Mall_Tag.GetMall_Tags().OrderBy(p => p.SortOrder).ThenByDescending(p => p.AddTime).ToArray();
            var items = list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.TagName };
                return item;
            }).ToList();
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void removemalltag(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_Tag] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "removemalltag", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemalltag(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_Tag data = null;
            if (ID > 0)
            {
                data = Mall_Tag.GetMall_Tag(ID);
            }
            if (data == null)
            {
                data = new Mall_Tag();
                data.AddTime = DateTime.Now;
            }
            data.TagName = getValue(context, "tdTagName");
            data.SortOrder = getIntValue(context, "tdSortOrder");
            data.Save();
            WebUtil.WriteJson(context, new { status = true, ID = data.ID });
        }
        private void loadmalltaggrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = Mall_Tag.GetMall_TagGridByKeywords(keywords, startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "loadmalltaggrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void getdoordershipparams(HttpContext context)
        {
            var list = Mall_ShipRate.GetMall_ShipRates().OrderByDescending(p => p.IsDefault).ThenByDescending(p => p.AddTime).ToArray();
            var items = list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.RateTile, RateType = p.RateType };
                return item;
            }).ToArray();
            WebUtil.WriteJson(context, new { status = true, ship_list = items });
        }
        private void getmallorderlistparams(HttpContext context)
        {
            var ship_list = Mall_ShipCompany.GetMall_ShipCompanies().OrderBy(p => p.SortOrder).ThenByDescending(p => p.AddTime).ToArray();
            var ship_items = ship_list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.ShipCompanyName };
                return item;
            }).ToList();
            ship_items.Insert(0, new { ID = 0, Name = "全部" });
            var project_list = Foresight.DataAccess.Project.GetProjectByParentID(1);
            var project_items = project_list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.Name };
                return item;
            }).ToList();
            project_items.Insert(0, new { ID = 0, Name = "全部" });
            WebUtil.WriteJson(context, new { status = true, ship_list = ship_items, project_list = project_items });
        }
        private void removemallshipcompany(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_ShipCompany] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "removemallshipcompany", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemallshipcompany(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_ShipCompany data = null;
            if (ID > 0)
            {
                data = Mall_ShipCompany.GetMall_ShipCompany(ID);
            }
            if (data == null)
            {
                data = new Mall_ShipCompany();
                data.AddTime = DateTime.Now;
            }
            data.ShipCompanyName = getValue(context, "tdShipCompanyName");
            data.SortOrder = getIntValue(context, "tdSortOrder");
            data.Save();
            WebUtil.WriteJson(context, new { status = true, ID = data.ID });
        }
        private void loadmallshipcompanygrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = Mall_ShipCompany.GetMall_ShipCompanyGridByKeywords(keywords, startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "loadmallshipcompanygrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void stopmallraterule(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [Mall_PointRule] set [RuleStatus]=0 where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "stopmallraterule", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void startmallraterule(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [Mall_PointRule] set [RuleStatus]=1 where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "startmallraterule", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removemallraterule(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_PointRule] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "removemallraterule", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemallpointrule(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_PointRule data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Mall_PointRule.GetMall_PointRule(ID);
            }
            if (data == null)
            {
                data = new Mall_PointRule();
                data.AddTime = DateTime.Now;
                data.AddUserName = WebUtil.GetUser(context).LoginName;
            }
            data.RuleName = getValue(context, "tdRuleName");
            data.RuleStatus = getIntValue(context, "tdRuleStatus");
            data.RuleSummary = getValue(context, "tdSummary");
            data.StartTime = getTimeValue(context, "tdStartTime");
            data.EndTime = getTimeValue(context, "tdEndTime");
            data.RuleType = getIntValue(context, "tdRuleType");
            data.IsUseForAllProduct = getIntValue(context, "tdUseForALL") == 1;
            data.ProductIDRange = context.Request["ProductIDList"];
            data.ReturnPoint = getIntValue(context, "tdReturnPoint");
            data.Save();
            WebUtil.WriteJson(context, new { status = true, ID = data.ID });
        }
        private void loadmallpointrulegrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = Mall_PointRule.GetMall_PointRuleGridByKeywords(keywords, startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "loadmallpointrulegrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void savebusinessconfigparam(HttpContext context)
        {
            var syslist = Foresight.DataAccess.SysConfig.GetSysConfigs().ToArray();
            var data = syslist.FirstOrDefault(p => p.Name.Equals(Foresight.DataAccess.SysConfigNameDefine.BusinessDistance.ToString()));
            if (data == null)
            {
                data = new Foresight.DataAccess.SysConfig();
                data.Name = Foresight.DataAccess.SysConfigNameDefine.BusinessDistance.ToString();
                data.AddTime = DateTime.Now;
            }
            data.Value = context.Request["BusinessDistance"];
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removemallorder(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            var orders = Foresight.DataAccess.Mall_Order.GetMall_OrderListByIDList(IDList);
            if (orders.FirstOrDefault(p => !p.IsClosed) != null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "订单未关闭" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var order in orders)
                    {
                        order.Delete(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "removemallorder", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void SaveConfig(SysConfig[] syslist, string Name, string Value)
        {
            var data = syslist.FirstOrDefault(p => p.Name.Equals(Name));
            if (data == null)
            {
                data = new Foresight.DataAccess.SysConfig();
                data.Name = Name;
                data.AddTime = DateTime.Now;
            }
            data.Value = Value;
            data.Save();
        }
        private void saveconfigparam(HttpContext context)
        {
            var syslist = Foresight.DataAccess.SysConfig.GetSysConfigs().ToArray();

            string Name = Foresight.DataAccess.SysConfigNameDefine.OrderCloseTime.ToString();
            string Value = context.Request["OrderCloseTime"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.OrderAuoShipped.ToString();
            Value = context.Request["OrderAuoShipped"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.OrderAutoRate.ToString();
            Value = context.Request["OrderAutoRate"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.OrderRefundTime.ToString();
            Value = context.Request["OrderRefundTime"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.AllowDefineAddress.ToString();
            Value = context.Request["AllowDefineAddress"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.JPushTuanGouNotify.ToString();
            Value = context.Request["JPushTuanGouNotify"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.JPushXianShiNotify.ToString();
            Value = context.Request["JPushXianShiNotify"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.UserBirthdayBefore.ToString();
            Value = context.Request["UserBirthdayBefore"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.UserBirthdayCoupon.ToString();
            Value = context.Request["UserBirthdayCoupon"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.MallCategoryLineCount.ToString();
            Value = context.Request["MallCategoryLineCount"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.SendJiXiaoPointDay.ToString();
            Value = context.Request["SendJiXiaoPointDay"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.FixedPointActiveDay.ToString();
            Value = context.Request["FixedPointActiveDay"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.FirstChangeBirthdayNote.ToString();
            Value = context.Request["FirstChangeBirthdayNote"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.MallHomeBusinessCount.ToString();
            Value = context.Request["MallHomeBusinessCount"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.MallHomeHotSaleCount.ToString();
            Value = context.Request["MallHomeHotSaleCount"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.MallHomePinTanCount.ToString();
            Value = context.Request["MallHomePinTanCount"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.MallHomeYouXuanCount.ToString();
            Value = context.Request["MallHomeYouXuanCount"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.MallMallBusinessCount.ToString();
            Value = context.Request["MallMallBusinessCount"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.MallMallCategoryCount.ToString();
            Value = context.Request["MallMallCategoryCount"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.NoGrabTransfer.ToString();
            Value = context.Request["NoGrabTransfer"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.DoorDelayDay.ToString();
            Value = context.Request["DoorDelayDay"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.NotifyOpenDoorBeforeFeeDay.ToString();
            Value = context.Request["NotifyOpenDoorBeforeFeeDay"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.QrCodeMaxEndTime.ToString();
            Value = context.Request["QrCodeMaxEndTime"];
            SaveConfig(syslist, Name, Value);

            Name = Foresight.DataAccess.SysConfigNameDefine.QrCodeMaxOpenCount.ToString();
            Value = context.Request["QrCodeMaxOpenCount"];
            SaveConfig(syslist, Name, Value);

            WebUtil.WriteJson(context, new { status = true });
        }
        private void removerotatingimageurl(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_RotatingImage data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Mall_RotatingImage.GetMall_RotatingImage(ID);
            }
            if (data != null)
            {
                data.ImagePath = string.Empty;
                data.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void saverotatingimage(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_RotatingImage data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Mall_RotatingImage.GetMall_RotatingImage(ID);
            }
            if (data == null)
            {
                data = new Mall_RotatingImage();
                data.AddTime = DateTime.Now;
            }
            data.Type = getIntValue(context, "tdType");
            data.SortOrder = getIntValue(context, "tdSortOrder", int.MinValue);
            data.URLLinkType = getIntValue(context, "tdURLLinkType");
            if (!string.IsNullOrEmpty(getValue(context, "hdProducts")))
            {
                List<int> ProductIDList = JsonConvert.DeserializeObject<List<int>>(getValue(context, "hdProducts"));
                if (ProductIDList.Count > 0)
                {
                    data.URLLinkID = ProductIDList[0];
                }
            }
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                HttpPostedFile postedFile = uploadFiles[0];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileNameWithOutExtenSion = DateTime.Now.ToFileTime().ToString();
                    string fileName = fileNameWithOutExtenSion + extension;
                    string filepath = "/upload/Mall/APPRotating/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    data.ImagePath = filepath + fileName;
                }
            }
            data.WaitSecond = getIntValue(context, "tdWaitSecond");
            data.IsActive = getIntValue(context, "tdIsActive") == 1;
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void deleteroatingimage(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_RotatingImage] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "deleteroatingimage", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmallrotatingimagegrid(HttpContext context)
        {
            try
            {
                int Type = WebUtil.GetIntValue(context, "Type");
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = Mall_RotatingImage.GetMall_RotatingImageGridByType(Type, "order by [Type] asc,[SortOrder] asc,[AddTime] desc", startRowIndex, pageSize);
                var list = dg.rows as Mall_RotatingImage[];
                foreach (var item in list)
                {
                    item.ImagePath = string.IsNullOrEmpty(item.ImagePath) ? "../styles/images/error-img.png" : WebUtil.GetContextPath() + item.ImagePath;
                }
                dg.rows = list;
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "getmallrotatingimagegrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void approvemallproduct(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            int status = WebUtil.GetIntValue(context, "status");
            var data = Foresight.DataAccess.Mall_Product.GetMall_Product(ID);
            data.Status = status;
            data.ApproveRemark = getValue(context, "tdApproveRemark");
            data.ApproveTime = DateTime.Now;
            data.ApproveMan = WebUtil.GetUser(context).LoginName;
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void saveaboutus(HttpContext context)
        {
            var list = Foresight.DataAccess.Mall_Content.GetMall_Contents().ToArray();
            string name = Utility.EnumModel.MallContentNameDefine.aboutus.ToString();
            var data = list.FirstOrDefault(p => p.Name.Equals(name));
            if (data == null)
            {
                data = new Mall_Content();
                data.AddTime = DateTime.Now;
                data.Name = name;
            }
            data.Value = context.Request["HTMLContent"];
            data.Save();

            name = Utility.EnumModel.MallContentNameDefine.contactus.ToString();
            data = list.FirstOrDefault(p => p.Name.Equals(name));
            if (data == null)
            {
                data = new Mall_Content();
                data.AddTime = DateTime.Now;
                data.Name = name;
            }
            data.Value = context.Request["phone"];
            data.Save();

            name = Utility.EnumModel.MallContentNameDefine.sharetitle.ToString();
            data = list.FirstOrDefault(p => p.Name.Equals(name));
            if (data == null)
            {
                data = new Mall_Content();
                data.AddTime = DateTime.Now;
                data.Name = name;
            }
            data.Value = getValue(context, "tdShareTile");
            data.Save();

            name = Utility.EnumModel.MallContentNameDefine.sharedescription.ToString();
            data = list.FirstOrDefault(p => p.Name.Equals(name));
            if (data == null)
            {
                data = new Mall_Content();
                data.AddTime = DateTime.Now;
                data.Name = name;
            }
            data.Value = getValue(context, "tdShareDescription");
            data.Save();

            name = Utility.EnumModel.MallContentNameDefine.androiddownloadurl.ToString();
            data = list.FirstOrDefault(p => p.Name.Equals(name));
            if (data == null)
            {
                data = new Mall_Content();
                data.AddTime = DateTime.Now;
                data.Name = name;
            }
            data.Value = getValue(context, "tdAndroidDownloadURL");
            data.Save();

            name = Utility.EnumModel.MallContentNameDefine.iosdownloadurl.ToString();
            data = list.FirstOrDefault(p => p.Name.Equals(name));
            if (data == null)
            {
                data = new Mall_Content();
                data.AddTime = DateTime.Now;
                data.Name = name;
            }
            data.Value = getValue(context, "tdIOSDownloadURL");
            data.Save();

            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmallsuggestiongrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = Mall_SuggestionDetail.GetMall_SuggestionDetailByKeywords(Keywords, "order by [AddTime] desc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "getmallsuggestiongrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void canceluserbind(HttpContext context)
        {
            List<Dictionary<string, object>> List = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(context.Request["List"]);
            string cmdtext = string.Empty;
            List<int> UserIDList = List.Select(p =>
            {
                return WebUtil.GetIntByStr(p["UserID"].ToString());
            }).ToList();
            var user_list = Foresight.DataAccess.User.GetUserListByIDList(UserIDList);
            foreach (var item in List)
            {
                int ProjectID = WebUtil.GetIntByStr(item["RoomID"].ToString());
                int UserID = WebUtil.GetIntByStr(item["UserID"].ToString());
                if (ProjectID == 0 || UserID == 0)
                {
                    continue;
                }
                var my_user = user_list.FirstOrDefault(p => p.UserID == UserID);
                cmdtext += "delete from [Mall_UserProject] where [UserID]=" + UserID + " and [ProjectID]=" + ProjectID + " and isnull(IsManualAdd,0)=1;";
                cmdtext += "update [Mall_UserProject] set [IsDisable]=1 where [UserID]=" + UserID + " and [ProjectID]=" + ProjectID + " and isnull(IsManualAdd,0)=0;";
                cmdtext += "delete from [Mall_Address] where [UserID]=" + UserID + " and [RoomID]=" + ProjectID + ";";
                if (my_user != null)
                {
                    cmdtext += "delete from [RoomPhoneRelation] where RoomID=" + ProjectID + " and (RelatePhoneNumber='" + my_user.LoginName + "' or UserID=" + UserID + ");";
                }
                else
                {
                    cmdtext += "delete from [RoomPhoneRelation] where RoomID=" + ProjectID + " and UserID=" + UserID + ";";
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "canceluserbind", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getbindprojectlist(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
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
                DataGrid dg = ProjectDetail3.GetProjectDetail3GridByKeywords(Keywords, IsShowSubscribe, IsShowUnSubscribe, ProjectIDList, RoomIDList, "order by [DefaultOrder] asc", startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "getbindprojectlist", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void removemallcouponcode(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_Coupon] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    cmdtext += "delete from [Mall_CouponProduct] where CouponID in (" + string.Join(",", IDList.ToArray()) + ")";
                    cmdtext += "delete from [Mall_CouponUser] where CouponID in (" + string.Join(",", IDList.ToArray()) + ")";
                    helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "removemallcouponcode", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmallproductbyids(HttpContext context)
        {
            List<int> ProductIDList = new List<int>();
            if (!string.IsNullOrEmpty(context.Request["IDList"]))
            {
                ProductIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            }
            if (ProductIDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false });
            }
            var list = Foresight.DataAccess.Mall_Product.GetMall_ProductListByIDList(ProductIDList);
            if (list.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false });
            }
            string names = string.Join(",", list.Select(p => p.ProductName).ToArray());
            WebUtil.WriteJson(context, new { status = true, names = names });
        }
        private void savemallcouponcode(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_Coupon data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Mall_Coupon.GetMall_Coupon(ID);
            }
            if (data == null)
            {
                data = new Mall_Coupon();
                data.AddTime = DateTime.Now;
                data.AddUser = WebUtil.GetUser(context).LoginName;
            }
            data.CouponType = getIntValue(context, "tdCouponType");
            data.IsUseForWY = WebUtil.GetIntValue(context, "IsUseForWY") == 1;
            data.IsUseForProduct = WebUtil.GetIntValue(context, "IsUseForProduct") == 1;
            data.IsUseForService = WebUtil.GetIntValue(context, "IsUseForService") == 1;
            data.CouponName = getValue(context, "tdCouponName");
            data.Summary = getValue(context, "tdSummary");
            data.StartTime = getTimeValue(context, "tdStartTime");
            data.EndTime = getTimeValue(context, "tdEndTime");
            data.IsUseForALLProduct = getIntValue(context, "tdIsUseForALLProduct") == 1;
            data.UseType = getIntValue(context, "tdUseType");
            data.UseNeedAmount = getDecimalValue(context, "tdUseNeedAmount");
            data.IsUseForALLService = getIntValue(context, "tdIsUseForALLService") == 1;
            if (data.UseType == 1)
            {
                data.ReduceAmount = getDecimalValue(context, "tdReduceAmount1");
            }
            else
            {
                data.ReduceAmount = getDecimalValue(context, "tdReduceAmount2");
            }
            data.IsActive = getIntValue(context, "tdIsActive") == 1;
            data.AmountType = getIntValue(context, "tdAmountType");
            data.IsUseForALLStore = getIntValue(context, "tdIsUseForALLStore") == 1;
            data.IsUseForALLCategory = getIntValue(context, "tdIsUseForALLCategory") == 1;
            data.IsAutoShowOnProduct = WebUtil.getServerIntValue(context, "tdIsAutoShowOnProduct") == 1;

            var user = WebUtil.GetUser(context);
            List<Mall_CouponProduct> coupon_productlist = new List<Mall_CouponProduct>();
            List<int> ProductIDList = new List<int>();
            if (!string.IsNullOrEmpty(context.Request["ProductIDList"]) && !data.IsUseForALLProduct && data.IsUseForProduct)
            {
                ProductIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["ProductIDList"]);
            }
            foreach (var ProductID in ProductIDList)
            {
                var coupon_product = new Mall_CouponProduct();
                coupon_product.ProductID = ProductID;
                coupon_product.AddTime = DateTime.Now;
                coupon_product.AddUserName = user.LoginName;
                coupon_productlist.Add(coupon_product);
            }

            List<int> ServiceIDList = new List<int>();
            if (!string.IsNullOrEmpty(context.Request["ServiceIDList"]) && !data.IsUseForALLService && data.IsUseForService)
            {
                ServiceIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["ServiceIDList"]);
            }
            foreach (var ServiceID in ServiceIDList)
            {
                var coupon_product = new Mall_CouponProduct();
                coupon_product.ServiceID = ServiceID;
                coupon_product.AddTime = DateTime.Now;
                coupon_product.AddUserName = user.LoginName;
                coupon_productlist.Add(coupon_product);
            }

            List<int> BusinessIDList = new List<int>();
            if (!string.IsNullOrEmpty(context.Request["BusinessIDList"]) && !data.IsUseForALLStore)
            {
                BusinessIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["BusinessIDList"]);
            }
            foreach (var BusinessID in BusinessIDList)
            {
                var coupon_product = new Mall_CouponProduct();
                coupon_product.BusinessID = BusinessID;
                coupon_product.AddTime = DateTime.Now;
                coupon_product.AddUserName = user.LoginName;
                coupon_productlist.Add(coupon_product);
            }

            List<int> ProductCategoryIDList = new List<int>();
            if (!string.IsNullOrEmpty(context.Request["ProductCategoryIDList"]) && !data.IsUseForALLCategory)
            {
                ProductCategoryIDList = JsonConvert.DeserializeObject<List<int>>(context.Request["ProductCategoryIDList"]);
            }
            foreach (var ProductCategoryID in ProductCategoryIDList)
            {
                var coupon_product = new Mall_CouponProduct();
                coupon_product.ProductCategoryID = ProductCategoryID;
                coupon_product.AddTime = DateTime.Now;
                coupon_product.AddUserName = user.LoginName;
                coupon_productlist.Add(coupon_product);
            }
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                HttpPostedFile postedFile = uploadFiles[0];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileNameWithOutExtenSion = DateTime.Now.ToFileTime().ToString();
                    string fileName = fileNameWithOutExtenSion + extension;
                    string filepath = "/upload/Mall/Coupon/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    data.CoverImage = filepath + fileName;
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    string cmdtext = "delete from [Mall_CouponProduct] where [CouponID]=@CouponID";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@CouponID", data.ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    foreach (var item in coupon_productlist)
                    {
                        item.CouponID = data.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "savemallcouponcode", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true, ID = data.ID });
        }
        private void loadmallcouponcodegrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string keywords = context.Request["keywords"];
                DataGrid dg = Mall_CouponDetail.GetMall_CouponDetailGridByKeywords(keywords, startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "loadmallcouponcodegrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void closemallorder(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            var orders = Foresight.DataAccess.Mall_Order.GetMall_OrderListByIDList(IDList);
            if (orders.FirstOrDefault(p => p.IsClosed) != null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "订单已关闭" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var order in orders)
                    {
                        order.CloseTime = DateTime.Now;
                        order.CloseUserName = WebUtil.GetUser(context).LoginName;
                        order.IsClosed = true;
                        order.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "completemallorder", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void completemallorder(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            var orders = Foresight.DataAccess.Mall_Order.GetMall_OrderListByIDList(IDList);
            if (orders.FirstOrDefault(p => p.OrderStatus == 3) != null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "订单已完成" });
                return;
            }
            if (orders.FirstOrDefault(p => p.IsClosed) != null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "订单已关闭" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var order in orders)
                    {
                        order.CompleteTime = DateTime.Now;
                        order.CompleteUserName = WebUtil.GetUser(context).LoginName;
                        order.OrderStatus = 3;
                        order.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "completemallorder", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemallordership(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            DateTime ShipTime = getTimeValue(context, "tdShipTime");
            //string ShipUserName = WebUtil.GetUser(context).LoginName;
            string ShipTrackNo = getValue(context, "tdShipTrackNo");
            string ShipCompanyName = getValue(context, "tdShipCompany");
            string ShipUserName = getValue(context, "tdShipUserName");
            string ShipDelivererName = getValue(context, "tdShipDelivererName");
            List<Mall_Order> orderlist = new List<Mall_Order>();
            if (ID > 0)
            {
                var order = Foresight.DataAccess.Mall_Order.GetMall_Order(ID);
                if (order == null)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已不存在" });
                    return;
                }
                if (order.OrderStatus == 3)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已完成" });
                    return;
                }
                if (order.OrderStatus == 1)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单未付款" });
                    return;
                }
                if (order.IsClosed)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已关闭" });
                    return;
                }
                orderlist.Add(order);
            }
            else
            {
                string IDs = context.Request["IDList"];
                List<int> IDList = new List<int>();
                if (!string.IsNullOrEmpty(IDs))
                {
                    IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
                }
                if (IDList.Count > 0)
                {
                    orderlist = Foresight.DataAccess.Mall_Order.GetMall_OrderListByIDList(IDList).ToList();
                }
            }
            foreach (var item in orderlist)
            {
                if (item.OrderStatus == 3)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已完成" });
                    return;
                }
                if (item.OrderStatus == 1)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单未付款" });
                    return;
                }
                if (item.IsClosed)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "订单已关闭" });
                    return;
                }
                item.ShipTime = ShipTime;
                item.ShipUserName = ShipUserName;
                item.ShipTrackNo = ShipTrackNo;
                item.ShipCompanyName = ShipCompanyName;
                item.ShipDelivererName = ShipDelivererName;
                item.OrderStatus = 2;
                //推送通知用户
                var app_user = Foresight.DataAccess.User.GetUser(item.UserID);
                if (app_user != null && !string.IsNullOrEmpty(app_user.DeviceId))
                {
                    var company = Foresight.DataAccess.Company.GetCompanies().FirstOrDefault();
                    string companyname = company != null ? company.CompanyName : "永友网络";
                    string[] android_cids = app_user.DeviceType.Equals("android") ? new string[] { app_user.DeviceId } : new string[] { };
                    string[] ios_cids = app_user.DeviceType.Equals("ios") ? new string[] { app_user.DeviceId } : new string[] { };
                    Dictionary<string, object> extras = new Dictionary<string, object>();
                    int ContentCode = 701;
                    string ContentMsg = "您的订单" + item.OrderNumber + "已发货";
                    var extra_model = new Utility.JpushContent(ContentCode, Msg: ContentMsg, Type: "mallorder_shipped");
                    extras["code"] = extra_model.code;
                    extras["msg"] = extra_model.msg;
                    extras["type"] = extra_model.type;
                    extras["id"] = item.ID;
                    string push_result = JPush.JpushAPI.PushMessage(companyname, extras, android_cids: android_cids, ios_cids: ios_cids, msg_content: extra_model.msg, PushAPP: 2, IsToAll: false);
                    Foresight.DataAccess.JPushLog.Insert_JPushLog(android_cids, ios_cids, extras, push_result, 10, item.ID, true, companyname);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in orderlist)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "savemallordership", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void dopaymallorder(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            var orders = Foresight.DataAccess.Mall_Order.GetMall_OrderListByIDList(IDList);
            if (orders.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择有效订单" });
                return;
            }
            var close_order = orders.FirstOrDefault(p => p.IsClosed);
            if (close_order != null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "订单已关闭" });
                return;
            }
            var pay_order = orders.FirstOrDefault(p => p.OrderStatus != 1);
            if (close_order != null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "订单已付款" });
                return;
            }
            List<Foresight.DataAccess.Payment> payment_list = new List<Payment>();
            foreach (var item in orders)
            {
                if (!string.IsNullOrEmpty(item.TradeNo))
                {
                    var payment = Foresight.DataAccess.Payment.GetPaymentByTradeNo(item.TradeNo);
                    if (payment != null && payment.Status != 2)
                    {
                        payment_list.Add(payment);
                    }
                }
                if (item.ProductTypeID == 10 && !string.IsNullOrEmpty(item.TradeNo))
                {
                    var history_count = Foresight.DataAccess.RoomFeeHistory.GetRoomFeeHistoryCountByTradeNo(item.TradeNo, OrderID: item.ID);
                    if (history_count > 0)
                    {
                        continue;
                    }
                    var fee_count = Foresight.DataAccess.RoomFee.GetRoomFeeCountByTradeNo(item.TradeNo, OrderID: item.ID);
                    if (fee_count == 0)
                    {
                        continue;
                    }
                    Web.APPCode.PaymentHelper.SaveRoomFee(item.TradeNo, "后台订单手动结算", "现金", OrderID: item.ID);
                }
            }
            bool can_socket_notify = false;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in orders)
                    {
                        if (item.ProductTypeID == 10)
                        {
                            item.OrderStatus = 3;
                        }
                        else
                        {
                            item.OrderStatus = 5;
                            item.IsReadNewOrder = false;
                            can_socket_notify = true;
                        }
                        item.PayTime = DateTime.Now;
                        item.PayUserName = WebUtil.GetUser(context).LoginName;
                        item.PaymentMethod = Utility.EnumModel.Mall_OrderPaymentMethodDefine.platform.ToString();
                        item.Save(helper);
                    }
                    foreach (var item in payment_list)
                    {
                        item.Status = 2;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("", "dopaymallorder", ex);
                    WebUtil.WriteJson(context, new { status = false, error = ex.Message });
                    return;
                }
            }
            if (can_socket_notify)
            {
                APPCode.SocketNotify.PushSocketNotifyAlert(Utility.EnumModel.SocketNotifyDefine.notifyorderpaied);
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void createmallpinorder(HttpContext context)
        {
            int ProductID = WebUtil.GetIntValue(context, "ProductID");
            int ID = WebUtil.GetIntValue(context, "ID");
            var organiser = Foresight.DataAccess.Mall_ProductPinOrganiserDetail.GetMall_ProductPinOrganiserDetail(ID);
            if (organiser.FinalStatus == 2)
            {
                WebUtil.WriteJson(context, new { status = false, error = "当前拼团已生成订单" });
                return;
            }
            if (organiser.FinalStatus == 3 || organiser.FinalStatus == 5)
            {
                WebUtil.WriteJson(context, new { status = false, error = "当前拼团已生成订单且已付款" });
                return;
            }
            if (organiser.FinalStatus == 4)
            {
                WebUtil.WriteJson(context, new { status = false, error = "当前拼团已关闭" });
                return;
            }
            var pin_user_list = Foresight.DataAccess.Mall_ProductPinUserDetail.GetMall_ProductPinUserDetailListByOrganiserID(organiser.ID);
            var product = Foresight.DataAccess.Mall_Product.GetMall_Product(ProductID);
            var variant_list = Foresight.DataAccess.Mall_Product_VariantDetail.GetMall_Product_VariantDetailListByProductID(ProductID);
            var user_list = Foresight.DataAccess.User.GetUserListByIDList(pin_user_list.Select(p => p.UserID).ToList());

            List<Mall_Order> order_list = new List<Mall_Order>();
            List<Mall_OrderItem> orderitem_list = new List<Mall_OrderItem>();
            foreach (var item in pin_user_list)
            {
                if (item.FinalStatus != 1)
                {
                    continue;
                }
                decimal price = product.PinSalePrice;
                Foresight.DataAccess.Mall_Product_VariantDetail my_variant = null;
                if (item.VariantID > 0)
                {
                    my_variant = variant_list.FirstOrDefault(p => p.ID == item.VariantID);
                }
                string VariantTitle = string.Empty;
                string VariantName = string.Empty;
                if (my_variant != null)
                {
                    VariantTitle = my_variant.FinalVariantTitle;
                    VariantName = my_variant.VariantName;
                }
                var user = user_list.FirstOrDefault(p => p.UserID == item.UserID);
                var order_item = new Mall_OrderItem();
                order_item.IsDiscountPrice = my_variant.IsDiscountEnable;
                order_item.AddTime = DateTime.Now;
                order_item.AddMan = user.LoginName;
                order_item.ProductID = product.ID;
                order_item.ProductName = product.ProductName;
                order_item.VariantID = item.VariantID;
                order_item.VariantTitle = VariantTitle;
                order_item.VariantName = VariantName;
                order_item.BusinessID = product.BusinessID;
                order_item.Price = price;
                order_item.Quantity = item.Quantity;
                order_item.TotalPrice = price * item.Quantity;
                order_item.ProductTypeID = product.ProductTypeID;
                orderitem_list.Add(order_item);
                decimal total = price * item.Quantity;
                Foresight.DataAccess.Mall_Order order = new Mall_Order();
                order.BusinessID = product.BusinessID;
                order.AddTime = DateTime.Now;
                order.AddUser = user.LoginName;
                order.OrderNumber = Mall_Order.GetLastestOrderNumber();
                order.OrderType = 1;
                order.TotalCost = total;
                order.OriginalTotalCost = order.TotalCost;
                order.OrderStatus = 1;
                order.UserID = user.UserID;
                order.UserName = user.LoginName;
                order.UserNote = context.Request["user_note"];
                order.ProductTypeID = product.ProductTypeID;
                order.Pin_OrganiserID = organiser.ID;
                order.Pin_UserID = item.ID;
                order_list.Add(order);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    for (int i = 0; i < order_list.Count; i++)
                    {
                        order_list[i].Save(helper);
                        orderitem_list[i].OrderID = order_list[i].ID;
                        orderitem_list[i].Save(helper);
                    }
                    organiser.Status = 2;
                    organiser.UpdateTime = DateTime.Now;
                    organiser.Save(helper);
                    foreach (var item in pin_user_list)
                    {
                        if (item.Status == 1)
                        {
                            item.Status = 2;
                            item.UpdateTime = DateTime.Now;
                            item.Save(helper);
                        }
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "createmallpinorder", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void closemallpinuser(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var organiser_detail = Foresight.DataAccess.Mall_ProductPinOrganiserDetail.GetMall_ProductPinOrganiserDetail(ID);
            if (organiser_detail.FinalStatus == 4)
            {
                WebUtil.WriteJson(context, new { status = false, error = "当前拼团已关闭" });
                return;
            }

            var organiser = Foresight.DataAccess.Mall_ProductPinOrganiser.GetMall_ProductPinOrganiser(ID);
            List<Dictionary<string, object>> list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(context.Request["list"]);

            var user_detail_list = Foresight.DataAccess.Mall_ProductPinUserDetail.GetMall_ProductPinUserDetailListByOrganiserID(organiser.ID);
            if (user_detail_list.FirstOrDefault(p => p.FinalStatus == 4) != null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "当前拼团选中的买家已关闭" });
                return;
            }
            var user_list = Foresight.DataAccess.Mall_ProductPinUser.GetMall_ProductPinUserListByOrganiserID(organiser.ID);
            bool can_update = user_list.Length == list.Count;
            List<Mall_ProductPinUser> update_user_list = new List<Mall_ProductPinUser>();
            List<Mall_Order> update_order_list = new List<Mall_Order>();
            foreach (var item in list)
            {
                int user_id = Convert.ToInt32(item["ID"]);
                var my_user = user_list.FirstOrDefault(p => p.ID == user_id);
                if (my_user != null)
                {
                    my_user.Status = 4;
                    my_user.UpdateTime = DateTime.Now;
                    update_user_list.Add(my_user);
                    var order = Mall_Order.GetMall_OrderByPin_UserID(my_user.ID);
                    if (order != null && order.OrderStatus == 1)
                    {
                        order.IsClosed = true;
                        order.CloseTime = DateTime.Now;
                        order.CloseUserName = WebUtil.GetUser(context).LoginName;
                        update_order_list.Add(order);
                    }
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    if (can_update)
                    {
                        organiser.Status = 4;
                        organiser.UpdateTime = DateTime.Now;
                        organiser.Save(helper);
                    }
                    foreach (var item in update_user_list)
                    {
                        item.Save(helper);
                    }
                    foreach (var item in update_order_list)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "closemallpinuser", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmallproductpinuserlist(HttpContext context)
        {
            int ProductID = WebUtil.GetIntValue(context, "ProductID");
            var product = Foresight.DataAccess.Mall_Product.GetMall_Product(ProductID);
            int total_count = product.PinPeopleCount;
            var organiser_list = Foresight.DataAccess.Mall_ProductPinOrganiserDetail.GetMall_ProductPinOrganiserDetailListByProductID(ProductID);
            var user_list = Mall_ProductPinUserDetail.GetMall_ProductPinUserDetailListByProductID(ProductID);
            var items = organiser_list.Select(p =>
            {
                var sub_items = user_list.Where(q => q.OrganiserID == p.ID).Select(q =>
                {
                    var sub_item = new { ID = q.ID, UserID = q.UserID, NickName = q.NickName, PhoneNumber = q.PhoneNumber, AddTime = q.AddTime.ToString("yyyy-MM-dd HH:mm"), Quantity = q.Quantity, VariantName = q.VariantName, StatusDesc = q.StatusDesc, ischecked = true };
                    return sub_item;
                }).ToList();
                var item = new { ID = p.ID, UserName = p.UserName, AddTime = p.AddTime.ToString("yyyy-MM-dd HH:mm"), StatusDesc = p.StatusDesc, ischecked = true, list = sub_items, JoinCount = sub_items.Count, LeftCount = total_count - sub_items.Count, Status = p.FinalStatus };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void saveconfigcity(HttpContext context)
        {
            string city = context.Request["city"];
            var data = Foresight.DataAccess.SysConfig.GetSysConfigByName("MapCity");
            if (data == null)
            {
                data = new SysConfig();
                data.AddTime = DateTime.Now;
                data.Name = "MapCity";
            }
            data.Value = city;
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getconfigcity(HttpContext context)
        {
            string city = string.Empty;
            var data = Foresight.DataAccess.SysConfig.GetSysConfigByName("MapCity");
            if (data != null)
            {
                city = data.Value;
            }
            WebUtil.WriteJson(context, new { status = true, city = city });
        }
        private void deletemallbusinesscoverimg(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Mall_Business.GetMall_Business(ID);
            data.CoverImage = string.Empty;
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void deletemallapprotatingimg(HttpContext context)
        {
            Foresight.DataAccess.SysConfig.DeleteSysConfig(WebUtil.GetIntValue(context, "ID"));
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemallapprotatingimg(HttpContext context)
        {
            string name = context.Request["name"];
            List<Foresight.DataAccess.SysConfig> pic_list = new List<SysConfig>();
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
                        string fileNameWithOutExtenSion = DateTime.Now.ToFileTime().ToString();
                        string fileName = fileNameWithOutExtenSion + extension;
                        string filepath = "/upload/Mall/APPRotating/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        Foresight.DataAccess.SysConfig config = null;
                        if (name.Equals("APPUserMySelfImg"))
                        {
                            config = Foresight.DataAccess.SysConfig.GetSysConfigByName(name);
                        }
                        if (config == null)
                        {
                            config = new Foresight.DataAccess.SysConfig();
                            config.AddTime = DateTime.Now;
                            config.ConfigType = "APPRotatingImg";
                            config.Name = name;
                        }
                        config.Value = filepath + fileName;
                        pic_list.Add(config);
                    }
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in pic_list)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "savemallapprotatingimg", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmallapprotatingimage(HttpContext context)
        {
            string name = context.Request["name"];
            var list = Foresight.DataAccess.SysConfig.GetSysConfigListByType("APPRotatingImg");
            var items = list.Where(p => p.Name.Equals(name)).Select(p =>
            {
                var item = new { ID = p.ID, Name = p.Name, PicPath = WebUtil.GetContextPath() + p.Value };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void loadmallorderitemgrid(HttpContext context)
        {
            try
            {
                int OrderID = WebUtil.GetIntValue(context, "OrderID");
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = Mall_OrderItem.GetMall_OrderItemGridByKeywords(OrderID, startRowIndex, pageSize);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "loadmallorderitemgrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void loadmallordergrid(HttpContext context)
        {
            try
            {
                int status = WebUtil.GetIntValue(context, "status");
                string Keywords = context.Request.Params["Keywords"];
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string ProductName = context.Request["ProductName"];
                DateTime PayStartTime = WebUtil.GetDateValue(context, "PayStartTime");
                DateTime PayEndTime = WebUtil.GetDateValue(context, "PayEndTime");
                string BuyerNickName = context.Request["BuyerNickName"];
                int OrderStatus = WebUtil.GetIntValue(context, "OrderStatus");
                int RateStatus = WebUtil.GetIntValue(context, "RateStatus");
                string OrderNumber = context.Request["OrderNumber"];
                string ShipCompany = context.Request["ShipCompany"];
                int OrderType = WebUtil.GetIntValue(context, "OrderType");
                string BusinessName = context.Request["BusinessName"];
                string BuyerPhoneNumber = context.Request["BuyerPhoneNumber"];

                DataGrid dg = ViewMall_OrderItem.GetViewMall_OrderItemGridByKeywords(Keywords, StartTime, EndTime, status, startRowIndex, pageSize, ProductName, PayStartTime, PayEndTime, BuyerNickName, BuyerPhoneNumber, OrderStatus, RateStatus, OrderNumber, ShipCompany, OrderType, BusinessName);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "loadmallordergrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void getmallproductpricelist(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            var variant_list = Foresight.DataAccess.Mall_Product_VariantDetail.GetMall_Product_VariantDetailListByProductIDList(IDList);
            var product_list = Foresight.DataAccess.Mall_Product.GetMall_ProductListByIDList(IDList);
            List<Utility.MallProductVariantPriceModel> list = new List<Utility.MallProductVariantPriceModel>();
            Utility.MallProductVariantPriceModel result = null;
            foreach (var item in product_list)
            {
                var my_variant_list = variant_list.Where(p => p.ProductID == item.ID).ToArray();
                if (my_variant_list.Length > 0)
                {
                    var pricemodel_list = my_variant_list.Select(p =>
                    {
                        result = new Utility.MallProductVariantPriceModel();
                        result.ProductID = item.ID;
                        result.VariantID = p.ID;
                        result.VariantName = item.ProductName + "-" + p.VariantName;
                        result.VariantPrice = p.FinalVariantPrice;
                        return result;
                    }).ToList();
                    list.AddRange(pricemodel_list);
                    continue;
                }
                result = new Utility.MallProductVariantPriceModel();
                result.ProductID = item.ID;
                result.VariantID = 0;
                result.VariantName = item.ProductName;
                result.VariantPrice = item.SalePrice;
                list.Add(result);
            }
            WebUtil.WriteJson(context, new { status = true, list = list });
        }
        private void removemallproductvariant(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_Product_Variant.DeleteMall_Product_Variant(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmallproductvariants(HttpContext context)
        {
            int ProductID = WebUtil.GetIntValue(context, "ProductID");
            var list = Foresight.DataAccess.Mall_Product_VariantDetail.GetMall_Product_VariantDetailListByProductID(ProductID, IncludeDefault: false);
            int count = 0;
            var items = list.Select(p =>
            {
                count++;
                var item = new { ID = p.ID, VariantTitle = p.VariantTitle, VariantName = p.VariantName, VariantBasicPrice = p.VariantBasicPrice > 0 ? p.VariantBasicPrice : 0, VariantPrice = p.FinalVariantPrice > 0 ? p.FinalVariantPrice : 0, VariantPointPrice = p.VariantPointPrice > 0 ? p.VariantPointPrice : 0, VariantPoint = p.VariantPoint > 0 ? p.VariantPoint : 0, VariantVIPPrice = p.VariantVIPPrice > 0 ? p.VariantVIPPrice : 0, VariantVIPPoint = p.VariantVIPPoint > 0 ? p.VariantVIPPoint : 0, VariantStaffPrice = p.VariantStaffPrice > 0 ? p.VariantStaffPrice : 0, VariantStaffPoint = p.VariantStaffPoint > 0 ? p.VariantStaffPoint : 0, Inventory = p.Inventory > 0 ? p.Inventory : 0, count = count };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void getmallbusinesseditparams(HttpContext context)
        {
            var list = Mall_CategoryDetail.GetMall_Categories().Where(p => p.CategoryType.Equals(Utility.EnumModel.Mall_CategoryTypeDefine.businesscategory.ToString())).ToArray();
            string result = GetCategoryTreeJson(0, list);
            WebUtil.WriteJson(context, result);
        }
        private void offlinemallproduct(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [Mall_Product] set Status=2 where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "offlinemallproduct", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemallproductprices(HttpContext context)
        {
            List<Utility.Mall_ProductPriceChangeModel> list = JsonConvert.DeserializeObject<List<Utility.Mall_ProductPriceChangeModel>>(context.Request["List"]);
            List<int> ProductIDList = list.Where(p => p.VariantID == 0).Select(p => p.ProductID).ToList();
            List<int> VariantIDList = list.Where(p => p.VariantID > 0).Select(p => p.VariantID).ToList();
            var product_list = Foresight.DataAccess.Mall_Product.GetMall_ProductListByIDList(ProductIDList);
            var variant_list = Foresight.DataAccess.Mall_Product_Variant.GetMall_Product_VariantListByIDList(VariantIDList);
            foreach (var item in product_list)
            {
                var changemodel = list.FirstOrDefault(p => p.ProductID == item.ID && p.VariantID == 0);
                if (changemodel != null)
                {
                    item.SalePrice = changemodel.NewSalePrice;
                }
            }
            foreach (var item in variant_list)
            {
                var changemodel = list.FirstOrDefault(p => p.VariantID == item.ID);
                if (changemodel != null)
                {
                    item.VariantPrice = changemodel.NewSalePrice;
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in product_list)
                    {
                        item.Save(helper);
                    }
                    foreach (var item in variant_list)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "savemallproductprices", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemallproductcategories(HttpContext context)
        {
            int[] ProductIDList = JsonConvert.DeserializeObject<int[]>(context.Request["ProductIDList"]).Where(p => p > 0).ToArray();
            int[] CategoryIDList = JsonConvert.DeserializeObject<int[]>(context.Request["CategoryIDList"]).Where(p => p > 0).ToArray();
            List<Foresight.DataAccess.Mall_Product_Category> product_category_list = new List<Mall_Product_Category>();
            foreach (var CategoryID in CategoryIDList)
            {
                foreach (var ProductID in ProductIDList)
                {
                    var product_category = new Foresight.DataAccess.Mall_Product_Category();
                    product_category.CategoryID = CategoryID;
                    product_category.ProductID = ProductID;
                    product_category_list.Add(product_category);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_Product_Category] where [ProductID] in (" + string.Join(",", ProductIDList) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    foreach (var item in product_category_list)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "savemallproductcategories", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void deletemallproductpic(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_Product_Picture.DeleteMall_Product_Picture(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmallproductpics(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_Product data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Mall_Product.GetMall_Product(ID);
            }
            if (data == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            var list = Foresight.DataAccess.Mall_Product_Picture.GetMall_Product_PictureListByID(data.ID);
            string context_path = WebUtil.GetContextPath();
            var items = list.Select(p =>
            {
                var item = new { ID = p.ID, IconPicPath = context_path + p.IconPicPath, MediumPicPath = context_path + p.MediumPicPath, LargePicPath = context_path + p.LargePicPath };
                return item;
            });
            string CoverImage = string.IsNullOrEmpty(data.CoverImage) ? string.Empty : context_path + data.CoverImage;
            WebUtil.WriteJson(context, new { status = true, list = items, CoverImage = CoverImage });
        }
        private void removemallproduct(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_Product] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    cmdtext += "delete from [Mall_Product_Category] where ProductID in (" + string.Join(",", IDList.ToArray()) + ");";
                    cmdtext += "delete from [Mall_Product_Picture] where ProductID in (" + string.Join(",", IDList.ToArray()) + ");";
                    cmdtext += "delete from [Mall_ProductDesc] where ProductID in (" + string.Join(",", IDList.ToArray()) + ");";
                    helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "removemallproduct", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadmallproductgrid(HttpContext context)
        {
            try
            {
                int SortOrder = WebUtil.GetIntValue(context, "SortOrder");
                string Keywords = context.Request.Params["Keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int status = WebUtil.GetIntValue(context, "status");
                int IsZiYing = WebUtil.GetIntValue(context, "IsZiYing");
                int type = WebUtil.GetIntValue(context, "type");
                bool IsAllowProductBuy = WebUtil.GetIntValue(context, "IsAllowProductBuy") == 1;
                bool IsAllowPointBuy = WebUtil.GetIntValue(context, "IsAllowPointBuy") == 1;
                bool IsAllowVIPBuy = WebUtil.GetIntValue(context, "IsAllowVIPBuy") == 1;
                DataGrid dg = Mall_ProductDetail.GetMall_ProductDetailGridByKeywords(Keywords, startRowIndex, pageSize, SortOrder, status, type, IsZiYing, IsAllowProductBuy, IsAllowPointBuy, IsAllowVIPBuy);
                var list = dg.rows as Mall_ProductDetail[];
                foreach (var item in list)
                {
                    item.CoverImage = string.IsNullOrEmpty(item.CoverImage) ? "../styles/images/error-img.png" : WebUtil.GetContextPath() + item.CoverImage;
                }
                dg.rows = list;
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "loadmallproductgrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void savemallproduct(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_Product data = null;
            var user = WebUtil.GetUser(context);
            if (ID > 0)
            {
                data = Foresight.DataAccess.Mall_Product.GetMall_Product(ID);
            }
            if (data == null)
            {
                data = new Foresight.DataAccess.Mall_Product();
                data.AddTime = DateTime.Now;
                data.AddMan = user.RealName;
            }
            data.IsZiYing = getIntValue(context, "tdIsZiYing") == 1;
            data.ProductName = getValue(context, "tdProductName");
            if (!data.IsZiYing)
            {
                data.BusinessID = WebUtil.GetIntValue(context, "BusinessID");
            }
            else
            {
                data.BusinessID = 0;
            }
            data.TotalCount = getIntValue(context, "tdTotalCount");
            data.BasicPrice = getDecimalValue(context, "tdBasicPrice");
            data.SalePrice = getDecimalValue(context, "tdSalePrice");
            data.ModelNumber = getValue(context, "tdModelNumber");
            data.Status = getIntValue(context, "tdStatus");
            data.ProductTypeID = WebUtil.GetIntValue(context, "ProductTypeID");
            data.Description = context.Request["Description"];
            data.Unit = getValue(context, "tdCountUnit");
            if (data.ProductTypeID == 3)
            {
                data.PinSalePrice = getDecimalValue(context, "tdPinSalePrice");
                data.PinPeopleCount = getIntValue(context, "tdPinPeopleCount");
                data.ActiveTimeRange = getDecimalValue(context, "tdActiveTimeRange");
                data.PinStartTime = getTimeValue(context, "tdPinStartTime");
                data.PinEndTime = getTimeValue(context, "tdPinEndTime");
            }
            if (data.ProductTypeID == 4)
            {
                data.XianShiSalePrice = getDecimalValue(context, "tdXianShiSalePrice");
                data.XianShiStartTime = getTimeValue(context, "tdXianShiStartTime");
                data.XianShiEndTime = getTimeValue(context, "tdXianShiEndTime");
            }
            data.IsShowOnHome = getIntValue(context, "tdIsShowOnHome") == 1;
            data.ProductSummary = getValue(context, "tdProductSummary");
            data.QuantityLimit = getIntValue(context, "tdQuantityLimit");
            data.SortOrder = getIntValue(context, "tdSortOrder", int.MinValue);
            data.IsSuggestion = getIntValue(context, "tdIsSuggestion", int.MinValue) == 1;
            data.IsYouXuan = getIntValue(context, "tdIsYouXuan") == 1;
            data.ShipRateID = getIntValue(context, "tdShipRateID");
            Mall_ShipRate ship_rate = null;
            if (data.ShipRateID > 0)
            {
                ship_rate = Mall_ShipRate.GetMall_ShipRate(data.ShipRateID);
            }
            if (ship_rate != null)
            {
                data.ShipRateType = ship_rate.RateType;
                data.ShipRateID = ship_rate.ID;
            }
            else
            {
                data.ShipRateID = 0;
                data.ShipRateType = 0;
            }
            data.IsAllowProductBuy = getIntValue(context, "tdIsAllowProductBuy") == 1;
            data.IsAllowPointBuy = getIntValue(context, "tdIsAllowPointBuy") == 1;
            data.IsAllowVIPBuy = getIntValue(context, "tdIsAllowVIPBuy") == 1;
            data.IsAllowStaffBuy = getIntValue(context, "tdIsAllowStaffBuy") == 1;
            List<Foresight.DataAccess.Mall_Product_Picture> pic_list = new List<Mall_Product_Picture>();
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
                        string fileNameWithOutExtenSion = DateTime.Now.ToFileTime().ToString();
                        string fileName = fileNameWithOutExtenSion + extension;
                        string filepath = "/upload/Mall/Product/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        if (i == 0)
                        {
                            data.CoverImage = filepath + fileName;
                            continue;
                        }
                        System.Drawing.Image img = Image.FromFile(Path);
                        Mall_Product_Picture pic = new Mall_Product_Picture();
                        pic.AddTime = DateTime.Now;
                        pic.AddMan = user.RealName;
                        string IconPicPath = WebUtil.CreatThumbnail(img, System.IO.Path.Combine(rootPath, string.Format("{0}\\{1}.jpg", "icon", fileNameWithOutExtenSion)), 180, 320);
                        string MediumPicPath = WebUtil.CreatThumbnail(img, System.IO.Path.Combine(rootPath, string.Format("{0}\\{1}.jpg", "medium", fileNameWithOutExtenSion)), 540, 960);
                        string LargePicPath = WebUtil.CreatThumbnail(img, System.IO.Path.Combine(rootPath, string.Format("{0}\\{1}.jpg", "large", fileNameWithOutExtenSion)), 0, 0);
                        pic.IconPicPath = IconPicPath.Replace(rootPath, "\\" + filepath).Replace("\\", "/");
                        pic.MediumPicPath = MediumPicPath.Replace(rootPath, "\\" + filepath).Replace("\\", "/");
                        pic.LargePicPath = LargePicPath.Replace(rootPath, "\\" + filepath).Replace("\\", "/");
                        pic_list.Add(pic);
                    }
                }
            }
            List<Foresight.DataAccess.Mall_Product_Category> product_category_list = new List<Mall_Product_Category>();
            string categoryids = context.Request["CategoryIDs"];
            int[] CategoryIDList = JsonConvert.DeserializeObject<int[]>(categoryids);
            foreach (var CategoryID in CategoryIDList)
            {
                if (CategoryID > 0)
                {
                    var product_category = new Foresight.DataAccess.Mall_Product_Category();
                    product_category.CategoryID = CategoryID;
                    product_category_list.Add(product_category);
                }
            }
            var request_variant_list = new List<Utility.MallProductVariantModel>();
            string Variants = context.Request["Variants"];
            if (!string.IsNullOrEmpty(Variants))
            {
                request_variant_list = JsonConvert.DeserializeObject<List<Utility.MallProductVariantModel>>(Variants);
            }
            List<Foresight.DataAccess.Mall_Product_Variant> variant_list = new List<Mall_Product_Variant>();
            var default_variant = Mall_Product_Variant.GetDefaultMall_Product_VarianByProductID(data.ID);
            foreach (var item in request_variant_list)
            {
                Foresight.DataAccess.Mall_Product_Variant variant = null;
                if (item.ID > 0)
                {
                    variant = Foresight.DataAccess.Mall_Product_Variant.GetMall_Product_Variant(item.ID);
                }
                if (variant == null)
                {
                    variant = new Mall_Product_Variant();
                    variant.AddTime = DateTime.Now;
                    variant.AddMan = user.RealName;
                }
                variant.VariantTitle = item.VariantTitle;
                variant.VariantName = item.VariantName;
                variant.Inventory = item.Inventory;
                variant.VariantBasicPrice = item.VariantBasicPrice;
                if (data.IsAllowProductBuy)
                {
                    variant.VariantPrice = item.VariantPrice;
                }
                else
                {
                    variant.VariantPrice = 0;
                }
                if (data.IsAllowPointBuy)
                {
                    variant.VariantPoint = item.VariantPoint;
                    variant.VariantPointPrice = item.VariantPointPrice;
                }
                else
                {
                    variant.VariantPoint = 0;
                    variant.VariantPointPrice = 0;
                }
                if (data.IsAllowVIPBuy)
                {
                    variant.VariantVIPPrice = item.VariantVIPPrice;
                    variant.VariantVIPPoint = item.VariantVIPPoint;
                }
                else
                {
                    variant.VariantVIPPrice = 0;
                    variant.VariantVIPPoint = 0;
                }
                if (data.IsAllowStaffBuy)
                {
                    variant.VariantStaffPoint = item.VariantStaffPoint;
                    variant.VariantStaffPrice = item.VariantStaffPrice;
                }
                else
                {
                    variant.VariantStaffPoint = 0;
                    variant.VariantStaffPrice = 0;
                }
                variant_list.Add(variant);
            }
            string TagName = context.Request["TagName"];
            List<int> TagIDList = new List<int>();
            if (!string.IsNullOrEmpty(TagName))
            {
                TagIDList = JsonConvert.DeserializeObject<List<int>>(TagName);
            }
            List<Mall_ProductTag> product_tag_list = new List<Mall_ProductTag>();
            if (TagIDList.Count > 0)
            {
                foreach (var TagID in TagIDList)
                {
                    var product_tag = new Mall_ProductTag();
                    product_tag.TagID = TagID;
                    product_tag_list.Add(product_tag);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    foreach (var item in pic_list)
                    {
                        item.ProductID = data.ID;
                        item.Save(helper);
                    }
                    string cmdtext = "delete from [Mall_Product_Category] where [ProductID]=@ProductID";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ProductID", data.ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    foreach (var item in product_category_list)
                    {
                        item.ProductID = data.ID;
                        item.Save(helper);
                    }
                    foreach (var item in variant_list)
                    {
                        item.ProductID = data.ID;
                        item.Save(helper);
                    }
                    if (variant_list.Count > 0)
                    {
                        if (default_variant != null)
                        {
                            default_variant.Delete(helper);
                        }
                    }
                    else
                    {
                        if (default_variant == null)
                        {
                            default_variant = new Mall_Product_Variant();
                            default_variant.AddMan = user.LoginName;
                            default_variant.AddTime = DateTime.Now;
                            default_variant.VariantTitle = "规格";
                            default_variant.ProductID = data.ID;
                        }
                        default_variant.IsDefault = true;
                        default_variant.VariantName = "默认";
                        default_variant.Inventory = data.TotalCount;
                        default_variant.VariantBasicPrice = data.BasicPrice;
                        if (data.IsAllowProductBuy)
                        {
                            default_variant.VariantPrice = data.SalePrice;
                        }
                        else
                        {
                            default_variant.VariantPrice = 0;
                        }
                        if (data.IsAllowPointBuy)
                        {
                            default_variant.VariantPoint = getIntValue(context, "tdVariantPoint");
                            default_variant.VariantPointPrice = getDecimalValue(context, "tdVariantPointPrice");
                        }
                        else
                        {
                            default_variant.VariantPoint = 0;
                            default_variant.VariantPointPrice = 0;
                        }
                        if (data.IsAllowVIPBuy)
                        {
                            default_variant.VariantVIPPrice = getDecimalValue(context, "tdVariantVIPPrice");
                            default_variant.VariantVIPPoint = getIntValue(context, "tdVariantVIPPoint");
                        }
                        else
                        {
                            default_variant.VariantVIPPrice = 0;
                            default_variant.VariantVIPPoint = 0;
                        }
                        if (data.IsAllowStaffBuy)
                        {
                            default_variant.VariantStaffPrice = getDecimalValue(context, "tdVariantStaffPrice");
                            default_variant.VariantStaffPoint = getIntValue(context, "tdVariantStaffPoint");
                        }
                        else
                        {
                            default_variant.VariantStaffPrice = 0;
                            default_variant.VariantStaffPoint = 0;
                        }
                        default_variant.Save(helper);
                    }
                    cmdtext = "delete from [Mall_ProductTag] where [ProductID]=@ProductID";
                    parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ProductID", data.ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    foreach (var item in product_tag_list)
                    {
                        item.ProductID = data.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "savemallproduct", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true, ID = data.ID });
        }
        private void getmallproducteditparams(HttpContext context)
        {
            var business_list = Foresight.DataAccess.Mall_Business.GetMall_Businesses();
            var items = business_list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.BusinessName };
                return item;
            });
            var shiprate_list = Mall_ShipRate.GetMall_ShipRates();
            var shiprate_items = shiprate_list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.RateTile };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, businesses = items, shiprates = shiprate_items });
        }
        private void getmallproducteditcategorytreeparams(HttpContext context)
        {
            var list = Mall_CategoryDetail.GetMall_Categories().Where(p => p.CategoryType.Equals(Utility.EnumModel.Mall_CategoryTypeDefine.productcategory.ToString())).ToArray();
            string result = GetCategoryTreeJson(0, list);
            WebUtil.WriteJson(context, result);
        }
        private void approvemallbusiness(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_Business data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Mall_Business.GetMall_Business(ID);
            }
            if (data == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            if (data.Status == 1)
            {
                WebUtil.WriteJson(context, new { status = false, error = "已通过审核，请不要重复审核" });
                return;
            }
            data.Status = WebUtil.GetIntValue(context, "Status");
            data.ApproveRemark = getValue(context, "tdApproveRemark");
            data.ApproveTime = DateTime.Now;
            data.ApproveMan = WebUtil.GetUser(context).RealName;
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void removemallbusiness(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = string.Empty;
                    cmdtext += "delete from [User] where UserID in  (select [UserID] from [Mall_Business] where ID in (" + string.Join(",", IDList.ToArray()) + "))";
                    cmdtext += "delete from [Mall_Business_Picture] where BusinessID in (" + string.Join(",", IDList.ToArray()) + ")";
                    cmdtext += "delete from [Mall_Business] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "removemallbusiness", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadmallbusinessgrid(HttpContext context)
        {
            try
            {
                int Status = WebUtil.GetIntValue(context, "Status");
                string Keywords = context.Request.Params["Keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = Mall_BusinessDetail.GetMall_BusinessGridByKeywords(Keywords, "order by [AddTime] desc", startRowIndex, pageSize, Status);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(LogModule, "loadmallbusinessgrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void deletemallbusinesspic(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_Business_Picture.DeleteMall_Business_Picture(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmallbusinesspic(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_Business data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Mall_Business.GetMall_Business(ID);
            }
            if (data == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            var list = Foresight.DataAccess.Mall_Business_Picture.GetMall_Business_PictureListByID(data.ID);
            string context_path = WebUtil.GetContextPath();
            var items = list.Select(p =>
            {
                var item = new { ID = p.ID, IconPicPath = context_path + p.IconPicPath, MediumPicPath = context_path + p.MediumPicPath, LargePicPath = context_path + p.LargePicPath };
                return item;
            });
            string CoverImage = string.IsNullOrEmpty(data.CoverImage) ? string.Empty : WebUtil.GetContextPath() + data.CoverImage;
            WebUtil.WriteJson(context, new { status = true, list = items, CoverImage = CoverImage });
        }
        private void savemallbusiness(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_Business data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Mall_Business.GetMall_Business(ID);
            }
            if (data == null)
            {
                data = new Mall_Business();
                data.AddMan = WebUtil.GetUser(context).RealName;
                data.AddTime = DateTime.Now;
                data.Status = 1;
            }
            data.BusinessName = getValue(context, "tdBusinessName");
            data.BusinessAddress = getValue(context, "tdBusinessAddress");
            data.ContactName = getValue(context, "tdContactName");
            data.ContactPhone = getValue(context, "tdContactPhone");
            data.LicenseNumber = getValue(context, "tdLicenseNumber");
            data.IsShowOnHome = getIntValue(context, "tdIsShowOnHome") == 1;
            data.IsSuggestion = getIntValue(context, "tdIsSuggestion") == 1;
            data.MapLocation = getValue(context, "tdMapLocation");
            data.ShortAddress = getValue(context, "tdShortAddress");
            data.IsTopShow = getIntValue(context, "tdIsTopShow") == 1;
            data.Remark = getValue(context, "tdRemark");
            List<Foresight.DataAccess.Mall_Business_Picture> pic_list = new List<Mall_Business_Picture>();
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
                        string fileNameWithOutExtenSion = DateTime.Now.ToFileTime().ToString();
                        string fileName = fileNameWithOutExtenSion + extension;
                        string filepath = "/upload/Mall/Business/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        if (i == 0)
                        {
                            data.CoverImage = filepath + fileName;
                            continue;
                        }
                        System.Drawing.Image img = Image.FromFile(Path);
                        Mall_Business_Picture pic = new Mall_Business_Picture();
                        pic.AddTime = DateTime.Now;
                        pic.AddMan = WebUtil.GetUser(context).RealName;
                        string IconPicPath = WebUtil.CreatThumbnail(img, System.IO.Path.Combine(rootPath, string.Format("{0}\\{1}.jpg", "icon", fileNameWithOutExtenSion)), 180, 320);
                        string MediumPicPath = WebUtil.CreatThumbnail(img, System.IO.Path.Combine(rootPath, string.Format("{0}\\{1}.jpg", "medium", fileNameWithOutExtenSion)), 540, 960);
                        string LargePicPath = WebUtil.CreatThumbnail(img, System.IO.Path.Combine(rootPath, string.Format("{0}\\{1}.jpg", "large", fileNameWithOutExtenSion)), 0, 0);
                        pic.IconPicPath = IconPicPath.Replace(rootPath, "\\" + filepath).Replace("\\", "/");
                        pic.MediumPicPath = MediumPicPath.Replace(rootPath, "\\" + filepath).Replace("\\", "/");
                        pic.LargePicPath = LargePicPath.Replace(rootPath, "\\" + filepath).Replace("\\", "/");
                        pic_list.Add(pic);
                    }
                }
            }
            List<Foresight.DataAccess.Mall_Business_Category> business_category_list = new List<Mall_Business_Category>();
            string categoryids = context.Request["CategoryIDs"];
            int[] CategoryIDList = JsonConvert.DeserializeObject<int[]>(categoryids);
            foreach (var CategoryID in CategoryIDList)
            {
                if (CategoryID > 0)
                {
                    var business_category = new Foresight.DataAccess.Mall_Business_Category();
                    business_category.CategoryID = CategoryID;
                    business_category_list.Add(business_category);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    foreach (var item in pic_list)
                    {
                        item.BusinessID = data.ID;
                        item.Save(helper);
                    }
                    string cmdtext = "delete from [Mall_Business_Category] where [BusinessID]=@BusinessID";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@BusinessID", data.ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    foreach (var item in business_category_list)
                    {
                        item.BusinessID = data.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "savemallbusiness", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true, ID = data.ID });
        }
        private void removemallcategory(HttpContext context)
        {
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "非法请求" });
                return;
            }
            var child_list = Foresight.DataAccess.Mall_Category.GetMall_CategoryListByParentIDList(IDList);
            if (child_list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请先删除子分类" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Mall_Category] where ID in (" + string.Join(",", IDList.ToArray()) + ") and (CanNotDelete is null or CanNotDelete=0)";
                    helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "removemallcategory", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadmallcategorygrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                int type = WebUtil.GetIntValue(context, "type");
                var list = Mall_CategoryDetail.GetMall_CategoryDetailListByKeywords(Keywords, "order by [SortOrder] asc,[AddTime] desc", type);
                var items = list.Select(p =>
                {
                    var dic = p.ToJsonObject();
                    dic["id"] = p.ID;
                    dic["name"] = p.CategoryName;
                    dic["_parentId"] = p.ParentID < 0 ? 0 : p.ParentID;
                    if (list.Any(o => o.ParentID == p.ID))
                    {
                        dic["state"] = "closed";
                    }
                    dic["PicturePath"] = !string.IsNullOrEmpty(p.PicturePath) ? WebUtil.GetContextPath() + p.PicturePath : "../styles/images/error-img.png";
                    dic["IsDisabledDesc"] = p.IsDisabledDesc;
                    return dic;
                }).ToList();
                DataGrid dg = new DataGrid();
                dg.rows = items;
                dg.total = items.Count;
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "loadmallcategorygrid", ex);
                WebUtil.WriteJson(context, new Foresight.DataAccess.Ui.DataGrid());
            }
        }
        private void deletemallcategorypic(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_Category data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Mall_Category.GetMall_Category(ID);
            }
            if (data != null)
            {
                data.PicturePath = string.Empty;
                data.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getmallcategorypic(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Mall_Category data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Mall_Category.GetMall_Category(ID);
            }
            if (data != null && !string.IsNullOrEmpty(data.PicturePath))
            {
                WebUtil.WriteJson(context, new { status = true, PicPath = WebUtil.GetContextPath() + data.PicturePath });
                return;
            }
            WebUtil.WriteJson(context, new { status = false });
        }
        private void savemallcategory(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            int type = WebUtil.GetIntValue(context, "type");
            Foresight.DataAccess.Mall_Category data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.Mall_Category.GetMall_Category(ID);
            }
            if (data == null)
            {
                data = new Foresight.DataAccess.Mall_Category();
                data.AddMan = WebUtil.GetUser(context).RealName;
                data.AddTime = DateTime.Now;
            }
            if (type == 1)
            {
                data.CategoryType = Utility.EnumModel.Mall_CategoryTypeDefine.productcategory.ToString();
            }
            else if (type == 2)
            {
                data.CategoryType = Utility.EnumModel.Mall_CategoryTypeDefine.businesscategory.ToString();
            }
            else if (type == 3)
            {
                data.CategoryType = Utility.EnumModel.Mall_CategoryTypeDefine.threadcategory.ToString();
            }
            data.ParentID = WebUtil.GetIntValue(context, "ParentID");
            data.CategoryName = getValue(context, "tdCategoryName");
            data.SortOrder = getIntValue(context, "tdSortOrder", int.MinValue);
            data.IsDisabled = getIntValue(context, "tdIsDisabled") == 1;
            data.IsShowOnMallYouXuan = getIntValue(context, "tdIsShowOnMallYouXuan") == 1;
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                HttpPostedFile postedFile = uploadFiles[0];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/Mall/Category/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    data.PicturePath = filepath + fileName;
                }
            }
            string TagName = context.Request["TagName"];
            List<int> TagIDList = new List<int>();
            if (!string.IsNullOrEmpty(TagName))
            {
                TagIDList = JsonConvert.DeserializeObject<List<int>>(TagName);
            }
            List<Mall_CategoryTag> category_tag_list = new List<Mall_CategoryTag>();
            if (TagIDList.Count > 0)
            {
                foreach (var TagID in TagIDList)
                {
                    var category_tag = new Mall_CategoryTag();
                    category_tag.TagID = TagID;
                    category_tag_list.Add(category_tag);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    var parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@CategoryID", data.ID));
                    helper.Execute("delete from [Mall_CategoryTag] where [CategoryID]=@CategoryID", CommandType.Text, parameters);
                    foreach (var item in category_tag_list)
                    {
                        item.CategoryID = data.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModule, "savemallcategory", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            data.Save();
            WebUtil.WriteJson(context, new { status = true, ID = data.ID });
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        private string getValue(HttpContext context, string name)
        {
            string PostName = "ctl00$content$";
            return context.Request.Params[PostName + name];
        }
        private int getIntValue(HttpContext context, string name, int defaultvalue = 0)
        {
            int result = defaultvalue;
            string value = getValue(context, name);
            if (!string.IsNullOrEmpty(value))
            {
                int.TryParse(value, out result);
            }
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
        public string GetCategoryTreeJson(int ParentID, Foresight.DataAccess.Mall_Category[] categories)
        {
            StringBuilder sb = new StringBuilder("");
            var my_categories = categories.Where(p => p.ParentID == ParentID).ToArray();
            if (my_categories.Length > 0)
            {
                if (ParentID > 0)
                {
                    sb.Append(",");
                    sb.Append("\"children\":");
                }
                sb.Append("[");
                for (int i = 0; i < my_categories.Length; i++)
                {
                    if (i == 0)
                    {
                        sb.Append("{");
                    }
                    else
                    {
                        sb.Append(",{");
                    }
                    sb.Append(string.Format("\"id\":{0},\"text\":\"{1}\"", my_categories[i].ID, my_categories[i].CategoryName));
                    sb.Append(GetCategoryTreeJson(my_categories[i].ID, categories));
                    sb.Append("}");
                }
                sb.Append("]");
            }
            string result = sb.ToString();
            return result;
        }
    }
}