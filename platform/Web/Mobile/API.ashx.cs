using Foresight.DataAccess;
using Foresight.DataAccess.Framework;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace Web.Mobile
{
    /// <summary>
    /// API 的摘要说明
    /// </summary>
    public class API : IHttpHandler, IRequiresSessionState
    {
        const string LogModuel = "Mobile.API";
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
                    case "getapi":
                        getapi(context);
                        break;
                    case "login":
                        login(context);
                        break;
                    case "getchaobiaolist"://加载抄表登记列表
                        getchaobiaolist(context);
                        break;
                    case "savechaobiaopoint"://抄表登记
                        savechaobiaopoint(context);
                        break;
                    case "getprojectlist":
                        getprojectlist(context);
                        break;
                    case "getroomfeelistbykeywords":
                        getroomfeelistbykeywords(context);
                        break;
                    case "savedeviceid":
                        savedeviceid(context);
                        break;
                    case "getservicelist"://工单列表
                        getservicelist(context);
                        break;
                    case "grabservice"://抢单
                        grabservice(context);
                        break;
                    case "getservicedetail"://工单详情
                        getservicedetail(context);
                        break;
                    case "acceptservice"://接单
                        acceptservice(context);
                        break;
                    case "completeservice"://完成
                        completeservice(context);
                        break;
                    case "getservicestauscount"://任务工单状态数量
                        getservicestauscount(context);
                        break;
                    case "savebaoshibaoxiu"://报事报修提交
                        savebaoshibaoxiu(context);
                        break;
                    case "getbaoshicount"://处理跟进状态数量
                        getbaoshicount(context);
                        break;
                    case "getdevicestauscount"://设备巡检任务状态数量
                        getdevicestauscount(context);
                        break;
                    case "getdevicetasklist"://设备巡检任务列表
                        getdevicetasklist(context);
                        break;
                    case "acceptdevicetask"://巡检任务接单
                        acceptdevicetask(context);
                        break;
                    case "getdevicetaskdetail"://巡检任务详情
                        getdevicetaskdetail(context);
                        break;
                    case "completedevicetask"://巡检任务完成
                        completedevicetask(context);
                        break;
                    case "getmsglist"://获取通知消息列表
                        getmsglist(context);
                        break;
                    case "getmsgdetail"://获取通知消息详情
                        getmsgdetail(context);
                        break;
                    case "saveserviceprocess"://工单处理
                        saveserviceprocess(context);
                        break;
                    case "getservicechulilist"://获取工单处理列表
                        getservicechulilist(context);
                        break;
                    case "saveheadimg"://修改用户头像
                        saveheadimg(context);
                        break;
                    case "saveusernickname"://修改用户昵称
                        saveusernickname(context);
                        break;
                    case "saveuserphone"://修改用户手机号码
                        saveuserphone(context);
                        break;
                    case "savepassword"://修改用户登录密码
                        savepassword(context);
                        break;
                    case "getmallcheckcount"://员工绩效考核状态数量
                        getmallcheckcount(context);
                        break;
                    case "getmallcheckrulerequestlist"://员工绩效考核列表
                        getmallcheckrulerequestlist(context);
                        break;
                    case "getmallcheckrulerequestdetail"://员工绩效考核详情
                        getmallcheckrulerequestdetail(context);
                        break;
                    case "confirmmallcheckrulerequest"://员工绩效考核无异议
                        confirmmallcheckrulerequest(context);
                        break;
                    case "savemallcheckrequestreject"://员工绩效考核有异议
                        savemallcheckrequestreject(context);
                        break;
                    case "getmallcheckrequestreject"://员工绩效考核有异议处理结果
                        getmallcheckrequestreject(context);
                        break;
                    case "getmyordercount"://获取订单总数
                        getmyordercount(context);
                        break;
                    case "getmyorderlist"://获取订单列表
                        getmyorderlist(context);
                        break;
                    case "grabmallorder"://抢单
                        grabmallorder(context);
                        break;
                    case "acceptmallorder"://接单
                        acceptmallorder(context);
                        break;
                    case "saveordershipcomplete"://已完成送货
                        saveordershipcomplete(context);
                        break;
                    case "getservicelistgroupbyproject"://根据项目获取工单列表
                        getservicelistgroupbyproject(context);
                        break;
                    case "getservicelistgroupbyuser"://根据用户和项目获取工单列表
                        getservicelistgroupbyuser(context);
                        break;
                    case "getmenulist"://获取物业内控APP菜单
                        getmenulist(context);
                        break;
                    case "getappversion":
                        getappversion(context);
                        break;
                    case "getprojectlistbyparentid":
                        getprojectlistbyparentid(context);
                        break;
                    case "dosaveserviceuser":
                        dosaveserviceuser(context);
                        break;
                    case "getserviceuserlist"://获取服务人员列表
                        getserviceuserlist(context);
                        break;
                    case "getservicedepartmentlist"://获取服务部门
                        getservicedepartmentlist(context);
                        break;
                    case "socketinit":
                        socketinit(context);
                        break;
                    case "getshipcompanylist":
                        getshipcompanylist(context);
                        break;
                    case "getmeterprojectpointlist":
                        getmeterprojectpointlist(context);
                        break;
                    case "savemeterprojectpoint":
                        savemeterprojectpoint(context);
                        break;
                    case "getlogindata":
                        getlogindata(context);
                        break;
                    case "checkloginstatus":
                        checkloginstatus(context);
                        break;
                    case "getpublicprojectlistbyparentid":
                        getpublicprojectlistbyparentid(context);
                        break;
                    case "getmypointvalue":
                        getmypointvalue(context);
                        break;
                    case "gettransfercheckpoint":
                        gettransfercheckpoint(context);
                        break;
                    case "savetransfercheckpoint":
                        savetransfercheckpoint(context);
                        break;
                    case "getcheckpointtransferlist":
                        getcheckpointtransferlist(context);
                        break;
                    case "getmycheckpointvalue":
                        getmycheckpointvalue(context);
                        break;
                    case "savewithdrawcheckpoint":
                        savewithdrawcheckpoint(context);
                        break;
                    case "getcheckpointwithdrawlist":
                        getcheckpointwithdrawlist(context);
                        break;
                    case "getroomfeelist":
                        getroomfeelist(context);
                        break;
                    case "getroomfeebyid":
                        getroomfeebyid(context);
                        break;
                    default:
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
        private void getroomfeelist(HttpContext context)
        {
            var uid = GetUID(context);
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            string keywords = context.Request["keywords"];
            var feeitems = new List<Dictionary<string, object>>();
            var feelist = new RoomFeeAnalysis[] { };
            int PreRoomID = 0;
            int NextRoomID = 0;
            int CurrentRoomID = 0;
            if (ProjectID == 0 && RoomID == 0 && string.IsNullOrEmpty(keywords))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请输入关键字");
                return;
            }
            var project_list = WebUtil.GetMyProjects(uid);
            var ProjectIDList = project_list.Select(p => p.ID).ToList();
            RoomFee.GetRoomFeeRoomIDList(RoomID, out PreRoomID, out NextRoomID, out CurrentRoomID, keywords, ALLProjectIDList: ProjectIDList, UserID: uid, ProjectID: ProjectID);
            if (CurrentRoomID == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有账单数据");
                return;
            }
            feelist = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomIDList(new int[] { CurrentRoomID });
            if (feelist.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有账单数据");
                return;
            }
            List<Utility.RoomFeeModel> list = new List<Utility.RoomFeeModel>();
            Utility.RoomFeeModel roomFeeModel = null;
            decimal HeJiCost = 0;
            string FullName = string.Empty;
            string OwnerName = string.Empty;
            string OwnerPhone = string.Empty;
            int MinRoomID = 0;
            int MaxRoomID = 0;
            if (feelist.Length > 0)
            {
                MinRoomID = feelist.Min(p => p.RoomID);
                MaxRoomID = feelist.Max(p => p.RoomID);
            }
            var relationPhoneList = RoomPhoneRelation.GetRoomPhoneRelationListByMinMaxRoomID(MinRoomID, MaxRoomID);
            foreach (var fee in feelist)
            {
                var myRelation = relationPhoneList.FirstOrDefault(p => p.RoomID == fee.RoomID && p.IsChargeFee);
                if (myRelation == null)
                {
                    relationPhoneList.FirstOrDefault(p => p.RoomID == fee.RoomID && p.IsDefault);
                }
                if (string.IsNullOrEmpty(OwnerName) && myRelation != null)
                {
                    OwnerName = myRelation.RelationName;
                    OwnerPhone = myRelation.RelatePhoneNumber;
                }
                if (string.IsNullOrEmpty(FullName))
                {
                    FullName = fee.FullName + "-" + fee.RoomName;
                }
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
            WebUtil.WriteJsonResult(context, new { summarylist = list, HeJiCost = HeJiCost, PreRoomID = PreRoomID, NextRoomID = NextRoomID, CurrentRoomID = CurrentRoomID, FullName = FullName, OwnerName = OwnerName, OwnerPhone = OwnerPhone });
        }
        private void getcheckpointwithdrawlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var list = Mall_PointWithDrawRecord.Get_Mall_PointWithDrawRecordListByUserID(uid);
            var items = list.Select(p =>
            {
                var item = new { id = p.ID, title = "岗位积分提现: " + p.PointValue.ToString(), time = p.AddTime.ToString("yyyy-MM-dd HH:mm:ss"), statusdesc = p.StatusDesc, status = p.Status };
                return item;
            }).ToArray();
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void savewithdrawcheckpoint(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            decimal maxpointvalue = Mall_UserJiXiaoPoint.GetMall_UserJiXiaoPointBalance(uid);
            decimal pointvalue = WebUtil.GetDecimalValue(context, "pointvalue");
            if (maxpointvalue < pointvalue)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "待提现积分不能大于当前积分");
                return;
            }
            if (pointvalue <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "提现的岗位积分为0");
                return;
            }
            Mall_UserJiXiaoPoint.Insert_Mall_UserJiXiaoPoint(uid, 2, 1, "提现", "提现:" + pointvalue.ToString(), 4, user.LoginName, 1, PointValue: -(int)pointvalue, RelatedID: 0, EarnType: 3, BeforePointValue: pointvalue);

            WebUtil.WriteJsonResult(context, "success");
        }
        private void getmycheckpointvalue(HttpContext context)
        {
            int uid = GetUID(context);
            decimal maxpointvalue = Mall_UserJiXiaoPoint.GetMall_UserJiXiaoPointBalance(uid);
            WebUtil.WriteJsonResult(context, new { maxpointvalue = maxpointvalue });
        }
        private void getcheckpointtransferlist(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            var list = Mall_PointCovertRecord.Get_Mall_PointCovertRecordListByUserID(uid);
            var items = list.Select(p =>
            {
                var item = new { id = p.ID, title = "积分" + p.PointValue.ToString() + "兑换" + p.CheckPointValue.ToString() + "岗位积分", time = p.AddTime.ToString("yyyy-MM-dd HH:mm:ss"), statusdesc = p.StatusDesc, status = p.Status };
                return item;
            }).ToArray();
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void savetransfercheckpoint(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            int uid = GetUID(context, out user);
            decimal maxpointvalue = Mall_UserPoint.GetMall_UserPointBalance(uid);
            decimal pointvalue = WebUtil.GetDecimalValue(context, "pointvalue");
            if (maxpointvalue < pointvalue)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "待兑换积分不能大于当前积分");
                return;
            }
            Mall_UserPointRule data = null;
            decimal checkpointvalue = Mall_UserPointRule.GetCheckPointValueByPoint(pointvalue, out data);
            if (checkpointvalue <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "兑换的岗位积分为0");
                return;
            }
            if (data != null)
            {
                Mall_UserJiXiaoPoint.Insert_Mall_UserJiXiaoPoint(uid, 1, 1, "积分兑换", "积分:" + pointvalue.ToString() + "兑换" + checkpointvalue.ToString(), 3, user.LoginName, 0, PointValue: (int)checkpointvalue, RelatedID: data.ID, InfoName: data.ConvertValueDesc, EarnType: 2, BeforePointValue: pointvalue);
                WebUtil.WriteJsonResult(context, new { checkpointvalue = checkpointvalue });
            }
            WebUtil.WriteJsonResult(context, "success");
        }
        private void getmypointvalue(HttpContext context)
        {
            int uid = GetUID(context);
            decimal maxpointvalue = Mall_UserPoint.GetMall_UserPointBalance(uid);
            WebUtil.WriteJsonResult(context, new { maxpointvalue = maxpointvalue });
        }
        private void gettransfercheckpoint(HttpContext context)
        {
            int uid = GetUID(context);
            decimal maxpointvalue = Mall_UserPoint.GetMall_UserPointBalance(uid);
            decimal pointvalue = WebUtil.GetDecimalValue(context, "pointvalue");
            if (maxpointvalue < pointvalue)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "待兑换积分不能大于当前积分");
            }
            Mall_UserPointRule data = null;
            decimal checkpointvalue = Mall_UserPointRule.GetCheckPointValueByPoint(pointvalue, out data);
            WebUtil.WriteJsonResult(context, new { checkpointvalue = checkpointvalue });
        }
        private void getpublicprojectlistbyparentid(HttpContext context)
        {
            int uid = GetUID(context);
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
                var list = ProjectTree.GetProjectTreeListByID(ParentRoomID, string.Empty, uid, 0);
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
        private void checkloginstatus(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            try
            {
                int uid = GetUID(context, out user);
            }
            catch (Exception)
            {
            }
            if (user != null)
            {
                WebUtil.WriteJsonResult(context, "Success");
                return;
            }
            bool IsLoginCheck = WebUtil.GetIntValue(context, "IsLoginCheck") == 1;
            bool IsAppUserLoginOn = new Utility.SiteConfig().IsAppUserLoginOn;
            if (IsLoginCheck && !IsAppUserLoginOn)
            {
                WebUtil.WriteJsonResult(context, "Success");
                return;
            }
            WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请登录");
        }
        private void getlogindata(HttpContext context)
        {
            WebUtil.WriteJsonResult(context, new { CanAPPUserRegister = new SiteConfig().CanAPPUserRegister });
        }
        private void savemeterprojectpoint(HttpContext context)
        {
            var uid = GetUID(context);
            string liststr = context.Request["list"];
            ChaoBiaoModel[] list = JsonConvert.DeserializeObject<ChaoBiaoModel[]>(liststr);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in list)
                    {
                        var importfee = ChargeMeter_Project.GetChargeMeter_Project(item.ID, helper);
                        if (importfee == null)
                        {
                            continue;
                        }
                        if (!importfee.IsAPPWriteEnable)
                        {
                            continue;
                        }
                        var TotalPoint = item.EndPoint - item.StartPoint;
                        if (TotalPoint < 0)
                        {
                            continue;
                        }
                        bool is_changed = false;
                        if (importfee.MeterStartPoint != item.StartPoint || importfee.MeterEndPoint != item.EndPoint)
                        {
                            is_changed = true;
                        }
                        if (is_changed)
                        {
                            importfee.MeterStartPoint = item.StartPoint;
                            importfee.MeterEndPoint = item.EndPoint;
                            importfee.MeterTotalPoint = TotalPoint;
                            importfee.Save(helper);
                            ChargeMeter_Project_Point.Save_ChargeMeter_Project_Point(importfee, helper);
                        }
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "savemeterprojectpoint", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器异常");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void getmeterprojectpointlist(HttpContext context)
        {
            var uid = GetUID(context);
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            string keywords = context.Request["keywords"];
            var importitems = new List<Dictionary<string, object>>();
            var importlist = new ChargeMeter_ProjectDetail[] { };
            int PreRoomID = 0;
            int NextRoomID = 0;
            int CurrentRoomID = 0;
            int MeterType = WebUtil.GetIntValue(context, "type");//2-公表0-住户表
            //公共资源
            if (MeterType == 2)
            {
                if (ProjectID == 0)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请选择公共资源");
                    return;
                }
                importlist = Foresight.DataAccess.ChargeMeter_ProjectDetail.GetChargeMeter_ProjectDetailListByRoomID(0, MeterType: 2, ProjectID: ProjectID, keywords: keywords);
            }
            else
            {
                if (ProjectID == 0 && RoomID == 0)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请选择公共资源");
                    return;
                }
                var project_list = WebUtil.GetMyProjects(uid);
                var ProjectIDList = project_list.Select(p => p.ID).ToList();
                ChargeMeter_ProjectDetail.GetChargeMeter_ProjectDetailRoomIDList(RoomID, out PreRoomID, out NextRoomID, out CurrentRoomID, keywords, ALLProjectIDList: ProjectIDList, UserID: uid, ProjectID: ProjectID);
                importlist = Foresight.DataAccess.ChargeMeter_ProjectDetail.GetChargeMeter_ProjectDetailListByRoomID(CurrentRoomID, ProjectIDList: ProjectIDList, UserID: uid, ProjectID: ProjectID);
            }
            if (importlist.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有相关仪表数据");
                return;
            }
            importitems = importlist.Select(p =>
            {
                var dic = new Dictionary<string, object>();
                dic["ID"] = p.ID;
                dic["name"] = p.APPMeterName;
                dic["status"] = p.PointStatus;
                dic["statusdesc"] = p.PointStatusDesc;
                dic["FullName"] = p.FinalName;
                dic["StartPoint"] = p.FinalStartPoint;
                dic["EndPoint"] = "";
                return dic;
            }).ToList();
            WebUtil.WriteJsonResult(context, new { importlist = importitems, PreRoomID = PreRoomID, NextRoomID = NextRoomID });
        }
        private void getshipcompanylist(HttpContext context)
        {
            var list = Mall_ShipRate.GetMall_ShipRates().OrderByDescending(p => p.IsDefault).ThenByDescending(p => p.AddTime).ToArray();
            var items = list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.RateTile, RateType = p.RateType };
                return item;
            }).ToArray();
            WebUtil.WriteJsonResult(context, new { list = items });
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
        private void getservicedepartmentlist(HttpContext context)
        {
            var departments = Foresight.DataAccess.CKDepartment.GetCKDepartments().Select(p =>
            {
                var item = new { ID = p.ID, Name = p.DepartmentName, ischecked = false };
                return item;
            }).ToList();
            departments.Insert(0, new { ID = 0, Name = "不限", ischecked = false });
            WebUtil.WriteJsonResult(context, new { list = departments });
        }
        private void getserviceuserlist(HttpContext context)
        {
            int DepartmentID = WebUtil.GetIntValue(context, "DepartmentID");
            var userlist = Foresight.DataAccess.User.GetAPPUserList(DepartmentID: DepartmentID);
            var items = userlist.Select(p =>
            {
                var item = new { UserID = p.UserID, RealName = p.FinalRealName, ischecked = false };
                return item;
            }).ToList();
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void dosaveserviceuser(HttpContext context)
        {
            User user = null;
            var uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            data.ServiceStatus = 10;
            data.IsAPPSend = false;
            data.IsAPPShow = true;
            data.ServiceAccpetManID = context.Request["UserIDList"];
            data.DepartmentID = WebUtil.GetIntValue(context, "DepartmentID");
            data.Save();
            var config = new Utility.SiteConfig();
            if (!string.IsNullOrEmpty(config.JPushKey_User))
            {
                var company = WebUtil.GetCompany(HttpContext.Current);
                string title = company == null ? "永友网络" : company.CompanyName;
                string ErrorMsg = "";
                APPCode.JPushHelper.SendJpushMsgByServiceID(data.ID, out ErrorMsg, title: title, SendUserID: user.UserID, SendUserName: user.LoginName);
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getprojectlistbyparentid(HttpContext context)
        {
            var uid = GetUID(context);
            int parentid = WebUtil.GetIntValue(context, "parentid");
            string title = "小区";
            int type = WebUtil.GetIntValue(context, "type");
            bool ExceptRoom = type == 2;
            var project_list = Foresight.DataAccess.ProjectTree.GetProjectTreeListByID(parentid, string.Empty, uid, ExceptRoom: ExceptRoom);
            var items = project_list.Select(p =>
            {
                title = p.TypeDesc;
                string fullname = p.isParent ? p.FullName : p.FullName + '-' + p.Name;
                return new { id = p.ID, name = p.Name, fullname = fullname, isParent = p.isParent, title = p.TypeDesc };
            });
            WebUtil.WriteJsonResult(context, new { list = items, title = title });
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
        private void getmenulist(HttpContext context)
        {
            User user = null;
            int uid = 0;
            var list = new List<Dictionary<string, object>>();
            try
            {
                uid = GetUID(context, out user);
            }
            catch (Exception)
            {
            }
            if (user != null)
            {
                list = SysMenu.GetAPPUserMenuList(user.UserID);
            }
            if (!new Utility.SiteConfig().IsMallOn)
            {
                WebUtil.WriteJsonResult(context, new { list = list });
                return;
            }
            var img_list = Mall_RotatingImage.GetMall_RotatingImageListByType(15);
            var imagelist = img_list.Select(p =>
            {
                var item = new { imageurl = WebUtil.GetContextPath() + p.ImagePath };
                return item;
            }).ToArray();
            WebUtil.WriteJsonResult(context, new { list = list, imagelist = imagelist });
        }
        private void getservicelistgroupbyuser(HttpContext context)
        {
            User user = null;
            var uid = GetUID(context, out user);
            int status = WebUtil.GetIntValue(context, "status");
            int ProjectID = WebUtil.GetIntValue(context, "id");
            var list = Foresight.DataAccess.CustomerServiceDetail.GetCustomerServiceCountGroupByUserStatus(uid, status, ProjectID);
            WebUtil.WriteJsonResult(context, new { gongdanlist = list });
        }
        private void getservicelistgroupbyproject(HttpContext context)
        {
            User user = null;
            var uid = GetUID(context, out user);
            int status = WebUtil.GetIntValue(context, "status");
            var list = Foresight.DataAccess.CustomerServiceDetail.GetCustomerServiceCountGroupByProjectStatus(uid, status);
            WebUtil.WriteJsonResult(context, new { gongdanlist = list });
        }
        private void saveordershipcomplete(HttpContext context)
        {
            User user = null;
            var uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Mall_Order.GetMall_Order(ID);
            if (data.OrderStatus != 2 && data.OrderStatus != 5)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单状态不允许此操作");
                return;
            }
            string ShipTimeStr = context.Request["ShipTime"].Replace("T", " ");
            data.OrderStatus = 2;
            data.ShipCompanyName = context.Request["ShipCompanyName"];
            data.ShipTime = WebUtil.GetDateTimeByStr(ShipTimeStr);
            data.ShipUserName = user.LoginName;
            data.ShipTrackNo = context.Request["ShipTrackNo"];
            data.ShipRemark = context.Request["Remark"];
            data.ShipDelivererName = context.Request["ShipDelivererName"];
            data.Save();
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void acceptmallorder(HttpContext context)
        {
            User user = null;
            var uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Mall_Order.GetMall_Order(ID);
            if (data.GrabStatus != 2)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单不允许接单");
                return;
            }
            var list = Mall_OrderAPPUser.GetMall_OrderAPPUserListByOrderID(data.ID);
            Mall_OrderAPPUser order_user = null;
            if (list.Length > 0)
            {
                order_user = list.FirstOrDefault(p => p.UserID == uid && p.AccpetStatus == 4);
            }
            if (order_user == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单已不属于您了");
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.GrabStatus = 4;
                    data.Save(helper);
                    Mall_OrderAPPUser.Save_Mall_OrderAPPUser(1, helper, IsAPPSend: true, data: order_user, IsAPPShow: true);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "acceptmallorder", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "内部错误");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void grabmallorder(HttpContext context)
        {
            User user = null;
            var uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Mall_Order.GetMall_Order(ID);
            if (data.GrabStatus != 1)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单不允许抢单");
                return;
            }
            var list = Mall_OrderAPPUser.GetMall_OrderAPPUserListByOrderID(data.ID);
            Mall_OrderAPPUser order_user = null;
            if (list.Length > 0)
            {
                var my_user = list.FirstOrDefault(p => p.UserID != uid && p.AccpetStatus == 1);
                if (my_user != null)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "订单已被别人抢到");
                    return;
                }
                order_user = list.FirstOrDefault(p => p.UserID == uid);
            }
            if (order_user == null)
            {
                order_user = new Mall_OrderAPPUser();
                order_user.OrderID = data.ID;
                order_user.UserID = uid;
                order_user.AddTime = DateTime.Now;
                order_user.AddUserMan = user.LoginName;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.GrabStatus = 4;
                    data.Save(helper);
                    Mall_OrderAPPUser.Save_Mall_OrderAPPUser(1, helper, IsAPPSend: true, data: order_user, IsAPPShow: true);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "grabmallorder", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "内部错误");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        /// <summary>
        /// 订单派送列表status 1-待抢单 2-待接收 3-待发货 4-已完成
        /// </summary>
        /// <param name="context"></param>
        private void getmyorderlist(HttpContext context)
        {
            User user = null;
            var uid = GetUID(context, out user);
            int status = WebUtil.GetIntValue(context, "status");
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            long totals = 0;
            var list = Mall_Order.GetAPPUserMall_OrderListByStatus(uid, status, startRowIndex, pageSize, out totals);
            var ProjectIDList = list.Where(p => p.AddressProjectID > 0).Select(p => p.AddressProjectID).Distinct().ToList();
            var items = list.Select(p =>
            {
                string AddTime = p.PayTime == DateTime.MinValue ? p.AddTime.ToString("yyyy-MM-dd") : p.PayTime.ToString("yyyy-MM-dd");
                var item = new { ID = p.ID, Title = p.FinalTitle, Summary = p.FullAddressInfo, AddTime = AddTime, OrderType = p.ProductTypeDesc };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void getmyordercount(HttpContext context)
        {
            try
            {
                var uid = GetUID(context);
                int qiangdan_count = Mall_Order.GetMall_OrderCountByStatus(uid, 1);
                int jieshou_count = Mall_Order.GetMall_OrderCountByStatus(uid, 2);
                int fahuo_count = Mall_Order.GetMall_OrderCountByStatus(uid, 3);
                int wancheng_count = Mall_Order.GetMall_OrderCountByStatus(uid, 4);
                var item = new { qiangdan_count = qiangdan_count, jieshou_count = jieshou_count, fahuo_count = fahuo_count, wancheng_count = wancheng_count };
                WebUtil.WriteJsonResult(context, new { countform = item });
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModuel, "getmyordercount", ex);
                var item = new { qiangdan_count = 0, jieshou_count = 0, fahuo_count = 0, wancheng_count = 0 };
                WebUtil.WriteJsonResult(context, new { countform = item });
            }
        }
        private void getmallcheckrequestreject(HttpContext context)
        {
            var uid = GetUID(context);
            int ID = WebUtil.GetIntValue(context, "id");
            Mall_CheckRequest data = Mall_CheckRequest.GetMall_CheckRequest(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            string Content = string.Empty;
            string Result = string.Empty;
            if (data.CheckConfirmID > 0)
            {
                var confirm = Mall_CheckRequestConfirm.GetMall_CheckRequestConfirm(data.CheckConfirmID);
                if (confirm != null && confirm.ConfirmStatus == 2)
                {
                    Content = confirm.ConfirmRemark;
                    if (confirm.ProcessStatus <= 0)
                    {
                        Result = "申诉处理中，请耐心等待";
                    }
                    else if (confirm.ProcessStatus == 1)
                    {
                        Result = "申诉被驳回,处理意见: " + confirm.ProcessRemark;
                    }
                    else if (confirm.ProcessStatus == 2)
                    {
                        Result = "申诉已接纳,处理意见: " + confirm.ProcessRemark;
                    }
                }
            }
            WebUtil.WriteJsonResult(context, new { id = data.ID, Content = Content, Result = Result });
        }
        private void savemallcheckrequestreject(HttpContext context)
        {
            var uid = GetUID(context);
            var user = Foresight.DataAccess.User.GetUser(uid);
            int ID = WebUtil.GetIntValue(context, "id");
            Mall_CheckRequest data = Mall_CheckRequest.GetMall_CheckRequest(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            data.ConfirmStatus = 2;
            data.ConfirmRemark = context.Request["Content"];
            data.ConfirmTime = DateTime.Now;
            data.ConfirmUserName = user.LoginName;
            var confirm = new Mall_CheckRequestConfirm();
            confirm.RequestID = data.ID;
            confirm.ConfirmStatus = 2;
            confirm.ConfirmTime = DateTime.Now;
            confirm.ConfirmMan = user.LoginName;
            confirm.ConfirmUserID = uid;
            confirm.ConfirmRemark = context.Request["Content"];
            confirm.ProcessStatus = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    confirm.Save(helper);
                    data.CheckConfirmID = confirm.ID;
                    data.Save(helper);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "savemallcheckrequestreject", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void confirmmallcheckrulerequest(HttpContext context)
        {
            var uid = GetUID(context);
            int ID = WebUtil.GetIntValue(context, "id");
            var user = Foresight.DataAccess.User.GetUser(uid);
            Mall_CheckRequest data = Mall_CheckRequest.GetMall_CheckRequest(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            data.ConfirmStatus = 1;
            data.ConfirmTime = DateTime.Now;
            data.ConfirmUserName = user.LoginName;
            var confirm = new Mall_CheckRequestConfirm();
            confirm.RequestID = data.ID;
            confirm.ConfirmStatus = 1;
            confirm.ConfirmTime = DateTime.Now;
            confirm.ConfirmMan = user.LoginName;
            confirm.ConfirmUserID = uid;
            confirm.ProcessStatus = 0;
            var rule_list = Mall_CheckRequestRuleDetail.GetMall_CheckRequestRuleDetailListByRequestID(data.ID);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    confirm.Save(helper);
                    data.CheckConfirmID = confirm.ID;
                    data.Save(helper);
                    //foreach (var item in rule_list)
                    //{
                    //    string Title = item.EarnType == 1 ? "业绩考核奖励" : "业绩考核扣除";
                    //    int PointType = item.EarnType;
                    //    int CategoryType = item.EarnType;
                    //    int BackPoint = item.EarnType == 1 ? item.PointValue : -item.PointValue;
                    //    Mall_UserJiXiaoPoint.Insert_Mall_UserJiXiaoPoint(uid, PointType, 0, Title, "Mall_CheckRequestID:" + data.ID, CategoryType, "System", 1, "", 0, RelatedID: data.ID, PointValue: BackPoint, AmountRuleID: 0, helper: helper);
                    //}
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "confirmmallcheckrulerequest", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                    return;
                }
            }
            Mall_CheckRequest.senduserjixiaopoint(new List<int>() { ID });
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getmallcheckrulerequestdetail(HttpContext context)
        {
            var uid = GetUID(context);
            int ID = WebUtil.GetIntValue(context, "id");
            Mall_CheckRequest data = Mall_CheckRequest.GetMall_CheckRequest(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非法请求");
                return;
            }
            var rule_list = Mall_CheckRequestRuleDetail.GetMall_CheckRequestRuleDetailListByRequestID(data.ID);
            var rule_items = rule_list.Select(p =>
            {
                var item = new { CategoryTypeDesc = p.CategoryTypeDesc, CategoryName = p.CategoryName, CheckName = p.CheckName, PointValue = p.PointValue, CategoryType = p.CategoryType };
                return item;
            });
            List<Dictionary<string, object>> image_list = new List<Dictionary<string, object>>();
            if (!string.IsNullOrEmpty(data.ImagePath))
            {
                string[] ImagePathList = data.ImagePath.Split(',');
                foreach (var ImagePath in ImagePathList)
                {
                    var dic = new Dictionary<string, object>();
                    dic["url"] = WebUtil.GetContextPath() + ImagePath;
                    dic["cacheurl"] = "";
                    image_list.Add(dic);
                }
            }
            WebUtil.WriteJsonResult(context, new { id = data.ID, ConfirmStatus = data.ConfirmStatus, Remark = data.Remark, list = rule_items, imglist = image_list });
        }
        private void getmallcheckrulerequestlist(HttpContext context)
        {
            var uid = GetUID(context);
            int status = WebUtil.GetIntValue(context, "status");
            bool onlybaoshi = false;
            if (!string.IsNullOrEmpty(context.Request["onlybaoshi"]))
            {
                bool.TryParse(context.Request["onlybaoshi"], out onlybaoshi);
            }
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            var list = Mall_CheckRequestDetail.GetMall_CheckRequestDetailListByConfirmStatus(status, " order by [AddTime] desc", startRowIndex, pageSize, uid);
            var rule_list = Mall_CheckRequestRule.GetMall_CheckRequestRuleListByRequestIDList(list.Select(p => p.ID).ToList());
            var items = list.Select(p =>
            {
                string addtime = p.AddTime.ToString("yyyy-MM-dd");
                if (p.RequestType == 2)
                {
                    var my_rule = rule_list.FirstOrDefault(q => q.RequestID == p.ID);
                    addtime = my_rule != null ? my_rule.FixedPointDateTime.ToString("yyyy年MM月") : addtime;
                }
                var item = new { ID = p.ID, Content = p.PointValueDesc, AddTime = addtime, ConfirmStatus = p.ConfirmStatus, ProcessStatusDesc = p.APPProcessStatusDesc };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void getmallcheckcount(HttpContext context)
        {
            var uid = GetUID(context);
            int daichuli_count = Mall_CheckRequest.GetMall_CheckRequestCountByStatus(uid, 0);
            int wuyiyi_count = Mall_CheckRequest.GetMall_CheckRequestCountByStatus(uid, 1);
            int shensuzhong_count = Mall_CheckRequest.GetMall_CheckRequestCountByStatus(uid, 2);
            WebUtil.WriteJsonResult(context, new { daichuli_count = daichuli_count, wuyiyi_count = wuyiyi_count, shensuzhong_count = shensuzhong_count });
        }
        private void savepassword(HttpContext context)
        {
            var uid = GetUID(context);
            var user = Foresight.DataAccess.User.GetUser(uid);
            if (user == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.AuthenticationFail, "没有登录");
                return;
            }
            if (!string.IsNullOrEmpty(context.Request["Password"]))
            {
                user.Password = Foresight.DataAccess.User.EncryptPassword(context.Request["Password"]);
                var company = Foresight.DataAccess.Company.GetCompanies().FirstOrDefault();
                string errormsg = string.Empty;
                if (EncryptHelper.SaveAPPUser(company, user.LoginName, user.Password, user.UserID, user.Type, out errormsg))
                {
                    user.Save();
                }
                else
                {
                    WebUtil.WriteJsonResult(context, "服务器异常，请稍后重试");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void saveuserphone(HttpContext context)
        {
            var uid = GetUID(context);
            var user = Foresight.DataAccess.User.GetUser(uid);
            if (user == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.AuthenticationFail, "没有登录");
                return;
            }
            user.PhoneNumber = context.Request["PhoneNo"];
            user.Save();
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void saveusernickname(HttpContext context)
        {
            var uid = GetUID(context);
            var user = Foresight.DataAccess.User.GetUser(uid);
            if (user == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.AuthenticationFail, "没有登录");
                return;
            }
            if (!string.IsNullOrEmpty(context.Request["NickName"]))
            {
                user.NickName = context.Request["NickName"];
                user.RealName = user.NickName;
                user.Save();
            }
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void saveheadimg(HttpContext context)
        {
            var uid = GetUID(context);
            var user = Foresight.DataAccess.User.GetUser(uid);
            if (user == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.AuthenticationFail, "没有登录");
                return;
            }
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
                    user.Save();
                }
            }
            WebUtil.WriteJsonResult(context, new { headimg = WebUtil.GetContextPath() + user.HeadImg });
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
        private void saveserviceprocess(HttpContext context)
        {
            var uid = GetUID(context);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不存在");
                return;
            }
            if (string.IsNullOrEmpty(data.ServiceAccpetManID))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不属于您,禁止该操作");
                return;
            }
            List<int> ServiceAccpetManIDList = JsonConvert.DeserializeObject<List<int>>(data.ServiceAccpetManID);
            if (!ServiceAccpetManIDList.Contains(uid))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不属于您,禁止该操作");
                return;
            }
            if (data.ServiceStatus != 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前工单状态不允许该操作");
                return;
            }
            string CompleteContent = context.Request["CompleteContent"];
            decimal RepairFee = WebUtil.GetDecimalValue(context, "RepairFee");
            decimal OtherFee = WebUtil.GetDecimalValue(context, "OtherFee");
            decimal TotalFee = OtherFee + RepairFee;
            var user = Foresight.DataAccess.User.GetUser(uid);
            var chuli = new Foresight.DataAccess.CustomerServiceChuli();
            var attachlist = new List<CustomerServiceChuli_Attach>();
            chuli.ServiceID = data.ID;
            chuli.ChuliDate = DateTime.Now;
            chuli.ChuliNote = CompleteContent;
            chuli.AddTime = DateTime.Now;
            chuli.HandelFee = RepairFee;
            chuli.OtherFee = OtherFee;
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
                        Foresight.DataAccess.CustomerServiceChuli_Attach attach = new Foresight.DataAccess.CustomerServiceChuli_Attach();
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
                    chuli.Save(helper);
                    foreach (var item in attachlist)
                    {
                        item.ChuliID = chuli.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "saveserviceprocess", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.ServerError, "服务器异常");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void getmsgdetail(HttpContext context)
        {
            var uid = GetUID(context);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Wechat_Msg.GetWechat_Msg(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该消息不存在");
                return;
            }
            var item = new
            {
                ID = data.ID,
                Title = data.MsgTitle,
                Content = data.HTMLContent,
            };
            WebUtil.WriteJsonResult(context, item);
        }
        private void getmsglist(HttpContext context)
        {
            var uid = GetUID(context);
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            List<int> ProjectIDList = Foresight.DataAccess.RoleProject.GetRoleProjectListByUserID(uid).Select(p => p.ProjectID).ToList();
            long totals = 0;
            var list = Foresight.DataAccess.Wechat_Msg.GetWechat_MsgListByMsgType(string.Empty, startRowIndex, pageSize, out totals, IsUserAPPSend: true, ProjectIDList: ProjectIDList, UserID: uid);
            var items = list.Select(p =>
            {
                string Summary = string.IsNullOrEmpty(p.MsgSummary) ? "暂无详细说明" : p.MsgSummary;
                string AddTime = p.PublishTime == DateTime.MinValue ? p.AddTime.ToString("yyyy-MM-dd") : p.PublishTime.ToString("yyyy-MM-dd");
                string ImgUrl = string.IsNullOrEmpty(p.PicPath) ? "../image/message.png" : WebUtil.GetContextPath() + p.PicPath;
                var item = new { ID = p.ID, ImgUrl = ImgUrl, Title = p.MsgTitle, Summary = Summary, AddTime = AddTime, MsgType = p.MsgTypeDesc };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { tongzhilist = items });
        }
        private void completedevicetask(HttpContext context)
        {
            var uid = GetUID(context);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Device_Task.GetDevice_Task(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该任务不存在");
                return;
            }
            if (data.TaskChargeManID != uid)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该任务不属于您,禁止该操作");
                return;
            }
            if (data.TaskStatus != 2)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前工单状态不允许该操作");
                return;
            }
            string CompleteContent = context.Request["CompleteContent"];
            CompleteContent = string.IsNullOrEmpty(CompleteContent) ? "NULL" : "'" + CompleteContent + "'";
            var user = Foresight.DataAccess.User.GetUser(uid);
            List<Foresight.DataAccess.DeviceTask_Image> attachlist = new List<Foresight.DataAccess.DeviceTask_Image>();
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
                        Foresight.DataAccess.DeviceTask_Image attach = new Foresight.DataAccess.DeviceTask_Image();
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
                    string cmdtext = "update Device_Task set [TaskStatus]=3,[TaskCompleteTime]=getdate(),[TaskCompleteContent]=" + CompleteContent + " where [ID]=@ID and [TaskStatus]=2;";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ID", data.ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    foreach (var item in attachlist)
                    {
                        item.DeviceTaskID = data.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "completedevicetask", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.ServerError, "服务器异常");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void getdevicetaskdetail(HttpContext context)
        {
            var uid = GetUID(context);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.ViewDeviceTask.GetViewDeviceTaskByID(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该任务不存在");
                return;
            }
            string ChargeMan = string.Empty;
            if (data.TaskChargeManID > 0)
            {
                var user = Foresight.DataAccess.User.GetUser(data.TaskChargeManID);
                if (user != null)
                {
                    ChargeMan = string.IsNullOrEmpty(user.RealName) ? user.LoginName : user.RealName;
                }
            }
            if (string.IsNullOrEmpty(ChargeMan))
            {
                var user = Foresight.DataAccess.User.GetUser(uid);
                if (user != null)
                {
                    ChargeMan = string.IsNullOrEmpty(user.RealName) ? user.LoginName : user.RealName;
                }
            }
            var taskimgs = Foresight.DataAccess.DeviceTask_Image.GetDeviceTask_ImageListByDeviceTaskID(data.ID);
            var imglist = taskimgs.Select(p =>
            {
                return new { url = WebUtil.GetContextPath() + p.AttachedFilePath, cacheurl = "" };
            });
            var item = new
            {
                ID = data.ID,
                Status = data.TaskStatus,
                DeviceName = data.DeviceName,
                DeviceType = data.DeviceTypeName,
                DeviceGroup = data.DeviceGroupName,
                DeviceModel = data.ModelNo,
                TaskFrom = data.TaskFromDesc,
                TaskType = data.TaskTypeDesc,
                TaskLevel = data.TaskLevel,
                Content = string.IsNullOrEmpty(data.TaskContent) ? "暂无详细描述" : data.TaskContent,
                ChargeMan = ChargeMan,
                TaskTime = data.TaskTime > DateTime.MinValue ? data.TaskTime.ToString("yyyy-MM-dd HH:mm") : "",
                AccpetTime = data.TaskAcceptTime > DateTime.MinValue ? data.TaskAcceptTime.ToString("yyyy-MM-dd HH:mm") : "",
                CompleteTime = data.TaskCompleteTime > DateTime.MinValue ? data.TaskCompleteTime.ToString("yyyy-MM-dd HH:mm") : "",
                CompleteResult = data.TaskCompleteContent,
                imglist = imglist
            };
            WebUtil.WriteJsonResult(context, item);
        }
        private void acceptdevicetask(HttpContext context)
        {
            var uid = GetUID(context);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.Device_Task.GetDevice_Task(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该任务不存在");
                return;
            }
            if (data.TaskChargeManID != uid)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该任务不属于您,禁止该操作");
                return;
            }
            if (data.TaskStatus != 1)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前任务状态不允许该操作");
                return;
            }
            var user = Foresight.DataAccess.User.GetUser(uid);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update Device_Task set [TaskStatus]=2,[TaskAcceptTime]=getdate() where [ID]=@ID and [TaskStatus]=1";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ID", data.ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "acceptdevicetask", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.ServerError, "服务器异常");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void getdevicetasklist(HttpContext context)
        {
            var uid = GetUID(context);
            int status = WebUtil.GetIntValue(context, "status");
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            long totals = 0;
            var list = Foresight.DataAccess.ViewDeviceTask.GetViewDeviceTaskListByStatus(status, uid, startRowIndex, pageSize, out totals);
            var items = list.Select(p =>
            {
                string content = string.IsNullOrEmpty(p.TaskContent) ? "暂无详细说明" : p.TaskContent;
                var item = new { ID = p.ID, Title = p.DeviceName, Content = content, ServiceType = p.TaskTypeDesc, Status = p.TaskStatus };
                return item;
            });
            WebUtil.WriteJsonResult(context, new { gongdanlist = items });
        }
        private void getdevicestauscount(HttpContext context)
        {
            try
            {
                var uid = GetUID(context);
                int jieshou_count = Foresight.DataAccess.Device_Task.GetDevice_TaskCountByStatus(uid, 1);
                int chuli_count = Foresight.DataAccess.Device_Task.GetDevice_TaskCountByStatus(uid, 2);
                int banjie_count = 0;
                var item = new { jieshou_count = jieshou_count, chuli_count = chuli_count, banjie_count = banjie_count };
                WebUtil.WriteJsonResult(context, new { devicecount = item });
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModuel, "getdevicestauscount", ex);
                var item = new { jieshou_count = 0, chuli_count = 0, banjie_count = 0 };
                WebUtil.WriteJsonResult(context, new { devicecount = item });
            }
        }
        private void getbaoshicount(HttpContext context)
        {
            try
            {
                var uid = GetUID(context);
                int chuligenjin_count = Foresight.DataAccess.CustomerService.GetChuliGenjinCount(uid);
                var item = new { chuligenjin_count = chuligenjin_count };
                WebUtil.WriteJsonResult(context, new { baoshicount = item });
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModuel, "getbaoshicount", ex);
                var item = new { chuligenjin_count = 0 };
                WebUtil.WriteJsonResult(context, new { baoshicount = item });
            }
        }
        private void savebaoshibaoxiu(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            var uid = GetUID(context, out user);
            int Type = WebUtil.GetIntValue(context, "Type");
            string AppointTimeStr = context.Request["AppointTime"].Replace("T", " ");
            DateTime AppointTime = DateTime.MinValue;
            DateTime.TryParse(AppointTimeStr, out AppointTime);
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            int PublicProjectID = WebUtil.GetIntValue(context, "PublicProjectID");
            string ServiceType = Utility.EnumModel.WechatServiceType.bsbx.ToString();
            string ServiceContent = context.Request.Params["Content"];
            //string ServiceAddTime = AppointTime;
            string PhoneNumber = context.Request.Params["PhoneNo"];
            string FullName = context.Request["FullName"];
            string ProjectName = context.Request["ProjectName"];
            string ServiceMan = user.LoginName;
            string ServiceFrom = Utility.EnumModel.WechatServiceFromDefine.app.ToString();
            var customer_service = new Foresight.DataAccess.CustomerService();
            customer_service.AddTime = DateTime.Now;
            customer_service.StartTime = DateTime.Now;
            customer_service.AddMan = user.RealName;
            customer_service.AddUserName = user.RealName;
            customer_service.ServiceFrom = ServiceFrom;
            customer_service.ServiceFullName = FullName;
            customer_service.ProjectName = ProjectName;
            string ServiceTypeDesc = Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatServiceType), ServiceType);
            var type = Foresight.DataAccess.ServiceType.GetServiceTypes().FirstOrDefault(p => ServiceTypeDesc.Contains(p.ServiceTypeName));
            customer_service.ServiceTypeID = type != null ? type.ID : int.MinValue;
            customer_service.ServiceTypeName = type != null ? type.ServiceTypeName : string.Empty;
            customer_service.AddCustomerName = ServiceMan;
            customer_service.ServiceContent = ServiceContent;
            customer_service.ServiceAppointTime = DateTime.Now;
            customer_service.AddCallPhone = PhoneNumber;
            //customer_service.ServiceAccpetManID = service.AddUserID;
            customer_service.ServiceStatus = 3;
            customer_service.IsAPPShow = true;
            customer_service.IsUnRead = true;
            customer_service.PublicProjectID = Type == 1 ? PublicProjectID : 0;
            customer_service.ProjectID = Type == 2 ? RoomID : 0;
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
            //通知后台
            APPCode.SocketNotify.PushSocketNotifyAlert(Utility.EnumModel.SocketNotifyDefine.notifyservice);
            WebUtil.WriteJsonResult(context, "保存成功");
        }
        private void getservicestauscount(HttpContext context)
        {
            try
            {
                var uid = GetUID(context);
                int type = WebUtil.GetIntValue(context, "type");
                int qiangdan_count = 0;
                int jieshou_count = 0;
                int chuli_count = 0;
                qiangdan_count = Foresight.DataAccess.CustomerService.GetCustomerServiceCountByStatus(uid, 3, Type: type);
                jieshou_count = Foresight.DataAccess.CustomerService.GetCustomerServiceCountByStatus(uid, 10, Type: type);
                chuli_count = Foresight.DataAccess.CustomerService.GetCustomerServiceCountByStatus(uid, 0, Type: type);
                int banjie_count = 0;
                if (type > 0)
                {
                    banjie_count = Foresight.DataAccess.CustomerService.GetCustomerServiceCountByStatus(uid, 1, Type: type);
                }
                var item = new { qiangdan_count = qiangdan_count, jieshou_count = jieshou_count, chuli_count = chuli_count, banjie_count = banjie_count };
                WebUtil.WriteJsonResult(context, new { servicecount = item });
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModuel, "getservicestauscount", ex);
                var item = new { qiangdan_count = 0, jieshou_count = 0, chuli_count = 0, banjie_count = 0 };
                WebUtil.WriteJsonResult(context, new { servicecount = item });
            }
        }
        private void completeservice(HttpContext context)
        {
            var uid = GetUID(context);
            var user = Foresight.DataAccess.User.GetUser(uid);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不存在");
                return;
            }
            if (string.IsNullOrEmpty(data.ServiceAccpetManID))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不属于您,禁止该操作");
                return;
            }
            List<int> ServiceAccpetManIDList = JsonConvert.DeserializeObject<List<int>>(data.ServiceAccpetManID);
            if (!ServiceAccpetManIDList.Contains(uid))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不属于您,禁止该操作");
                return;
            }
            if (data.ServiceStatus != 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前工单状态不允许该操作");
                return;
            }
            decimal RepairFee = WebUtil.GetDecimalValue(context, "RepairFee");
            decimal OtherFee = WebUtil.GetDecimalValue(context, "OtherFee");
            decimal TotalFee = OtherFee + RepairFee;
            string CompleteContent = context.Request["CompleteContent"];
            CompleteContent = string.IsNullOrEmpty(CompleteContent) ? "NULL" : "'" + CompleteContent + "'";
            var chuli = new Foresight.DataAccess.CustomerServiceChuli();
            var attachlist = new List<CustomerServiceChuli_Attach>();
            chuli.ServiceID = data.ID;
            chuli.ChuliDate = DateTime.Now;
            chuli.ChuliNote = context.Request["CompleteContent"];
            chuli.AddTime = DateTime.Now;
            chuli.HandelFee = RepairFee;
            chuli.OtherFee = OtherFee;
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
                        Foresight.DataAccess.CustomerServiceChuli_Attach attach = new Foresight.DataAccess.CustomerServiceChuli_Attach();
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
                    int IsRequireCost = TotalFee > 0 ? 1 : 0;
                    string BanJieManName = !string.IsNullOrEmpty(user.RealName) ? "'" + user.RealName + "'" : "NULL";
                    string cmdtext = "update CustomerService set [ServiceStatus]=1,[HandelFee]=@HandelFee,[TotalFee]=@TotalFee,[BanJieTime]=getdate(),[IsRequireCost]=@IsRequireCost,[BanJieNote]=" + CompleteContent + ",[BanJieManUserID]=" + uid + ",BanJieManName=" + BanJieManName + " where [ID]=@ID and [ServiceStatus]=0;";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ID", data.ID));
                    parameters.Add(new SqlParameter("@HandelFee", RepairFee));
                    parameters.Add(new SqlParameter("@TotalFee", TotalFee));
                    parameters.Add(new SqlParameter("@IsRequireCost", IsRequireCost));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    chuli.Save(helper);
                    foreach (var item in attachlist)
                    {
                        item.ChuliID = chuli.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "completeservice", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.ServerError, "服务器异常");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void acceptservice(HttpContext context)
        {
            var uid = GetUID(context);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不存在");
                return;
            }
            if (string.IsNullOrEmpty(data.ServiceAccpetManID))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不属于您,禁止该操作");
                return;
            }
            List<int> ServiceAccpetManIDList = JsonConvert.DeserializeObject<List<int>>(data.ServiceAccpetManID);
            if (!ServiceAccpetManIDList.Contains(uid))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不属于您,禁止该操作");
                return;
            }
            if (data.ServiceStatus != 10)
            {

                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前工单状态不允许该操作");
                return;
            }
            var user = Foresight.DataAccess.User.GetUser(uid);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update CustomerService set [ServiceStatus]=0,[AcceptTime]=getdate() where [ID]=@ID and [ServiceStatus]=10";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ID", data.ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "acceptservice", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.ServerError, "服务器异常");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void getservicedetail(HttpContext context)
        {
            var uid = GetUID(context);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.ViewCustomerService.GetViewCustomerServiceByID(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不存在");
                return;
            }
            decimal HandelFee = 0;
            decimal.TryParse(data.HandelFee, out HandelFee);
            decimal TotalFee = data.TotalFee > 0 ? data.TotalFee : 0;
            decimal OtherFee = (TotalFee - HandelFee) > 0 ? (TotalFee - HandelFee) : 0;
            var serviceimgs = Foresight.DataAccess.CustomerServiceAttach.GetCustomerServiceAttachList(data.ID);
            var imglist = serviceimgs.Select(p =>
            {
                return new { url = WebUtil.GetContextPath() + p.AttachedFilePath, cacheurl = "" };
            });
            var item = new
            {
                ID = data.ID,
                ServiceType = data.ServiceTypeName,
                FullName = data.ServiceFullName,
                AppointTime = data.ServiceAppointTime > DateTime.MinValue ? data.ServiceAppointTime.ToString("yyyy-MM-dd HH:mm") : "",
                Content = string.IsNullOrEmpty(data.ServiceContent) ? "暂无详细描述" : data.ServiceContent,
                CustomerName = data.AddCustomerName,
                Status = data.ServiceStatus,
                RepairFee = HandelFee,
                TotalFee = TotalFee,
                OtherFee = OtherFee,
                CompleteTime = data.BanJieTime > DateTime.MinValue ? data.BanJieTime.ToString("yyyy-MM-dd HH:mm") : "",
                Result = data.BanJieNote,
                imglist = imglist,
                CustomerPhone = data.AddCallPhone,
                ServiceAccpetMan = data.FinalServiceAccpetMan,
                AcceptTime = data.AcceptTime > DateTime.MinValue ? data.AcceptTime.ToString("yyy-MM-dd HH:mm") : data.AddTime.ToString("yyy-MM-dd HH:mm")
            };
            WebUtil.WriteJsonResult(context, item);
        }
        private void grabservice(HttpContext context)
        {
            var uid = GetUID(context);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不存在");
                return;
            }
            if (data.ServiceStatus != 3)
            {
                if (string.IsNullOrEmpty(data.ServiceAccpetManID))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不属于您,禁止该操作");
                    return;
                }
                List<int> ServiceAccpetManIDList = JsonConvert.DeserializeObject<List<int>>(data.ServiceAccpetManID);
                if (!ServiceAccpetManIDList.Contains(uid))
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不属于您,禁止该操作");
                    return;
                }
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单已被其他工友抢到");
                return;
            }
            var user = Foresight.DataAccess.User.GetUser(uid);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update CustomerService set [ServiceAccpetManID]=@ServiceAccpetManID,[ServiceAccpetMan]=@ServiceAccpetMan,[ServiceStatus]=0 where [ID]=@ID and [ServiceStatus]=3";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ServiceAccpetManID", "[" + user.UserID + "]"));
                    parameters.Add(new SqlParameter("@ServiceAccpetMan", user.RealName));
                    parameters.Add(new SqlParameter("@ID", data.ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "grabservice", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.ServerError, "服务器异常");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void getservicelist(HttpContext context)
        {
            var uid = GetUID(context);
            int status = WebUtil.GetIntValue(context, "status");
            bool onlybaoshi = false;
            if (!string.IsNullOrEmpty(context.Request["onlybaoshi"]))
            {
                bool.TryParse(context.Request["onlybaoshi"], out onlybaoshi);
            }
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            int UserID = WebUtil.GetIntValue(context, "UserID");
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            List<int> ProjectIDList = new List<int>();
            long totals = 0;
            if (UserID == -1 || UserID > 0)
            {
                uid = UserID;
            }
            if (ProjectID > 0)
            {
                ProjectIDList = new List<int>() { ProjectID };
            }
            else
            {
                ProjectIDList = Foresight.DataAccess.RoleProject.GetRoleProjectListByUserID(uid).Select(p => p.ProjectID).ToList();
            }
            var list = Foresight.DataAccess.ViewCustomerService.GetViewCustomerServiceListByStatus(status, uid, startRowIndex, pageSize, out totals, onlybaoshi, ProjectIDList: ProjectIDList);
            var items = list.Select(p =>
            {
                string content = string.IsNullOrEmpty(p.ServiceContent) ? "暂无详细说明" : p.ServiceContent;
                var item = new { ID = p.ID, Title = p.ServiceFullName, Content = content, ServiceType = p.ServiceTypeName, Status = p.ServiceStatus };
                return item;
            });
            bool showsendbtn = SysMenu.CheckSysModulesForUserByUserId(uid, ModuleCode: "1191497");
            WebUtil.WriteJsonResult(context, new { gongdanlist = items, showsendbtn = showsendbtn });
        }
        private void savedeviceid(HttpContext context)
        {
            var uid = GetUID(context);
            var user = Foresight.DataAccess.User.GetUser(uid);
            string DeviceId = context.Request["device_id"];
            string DeviceType = context.Request["device_type"];
            if (!string.IsNullOrEmpty(DeviceId))
            {
                user.APPUserDeviceID = DeviceId;
                user.APPUserDeviceType = DeviceType;
                user.Save();
            }
            WebUtil.WriteJsonResult(context, "保存成功");
        }
        private void getroomfeelistbykeywords(HttpContext context)
        {
            var uid = GetUID(context);
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            string keywords = context.Request["keywords"];
            if (ProjectID <= 0 && RoomID <= 0 && string.IsNullOrEmpty(keywords))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请输入关键字");
                return;
            }
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            long totals = 0;
            var roomlist = ViewRoomBasic.GetViewRoomBasicListByKeywords(ProjectID, RoomID, keywords, startRowIndex, pageSize, out totals);
            List<Dictionary<string, object>> items = new List<Dictionary<string, object>>();
            if (roomlist.Length > 0)
            {
                List<int> RoomIDList = roomlist.Select(p => p.RoomID).ToList();
                var feelist = RoomFeeAnalysis.GetRoomFeeAnalysisListByRoomID(RoomIDList, new List<int>(), DateTime.MinValue, DateTime.MinValue, new int[] { }, UserID: uid);
                foreach (var item in roomlist)
                {
                    var roomfeelist = feelist.Where(q => q.RoomID == item.RoomID);
                    decimal TotalCost = roomfeelist.Sum(p => p.TotalCost);
                    if (TotalCost > 0)
                    {
                        var dic = new Dictionary<string, object>();
                        dic["ProjectName"] = item.FullName + "-" + item.Name;
                        dic["CustomerName"] = item.RelationName;
                        dic["PhoneNo"] = item.RelatePhoneNumber;
                        dic["roomfeelist"] = roomfeelist.Select(q =>
                        {
                            var dic2 = new Dictionary<string, object>();
                            dic2["ID"] = q.ID;
                            dic2["ChargeName"] = q.Name;
                            dic2["TotalCost"] = q.TotalCost;
                            dic2["StartTime"] = q.CalculateStartTime > DateTime.MinValue ? q.CalculateStartTime.ToString("yyyy-MM-dd") : "";
                            dic2["EndTime"] = q.CalculateEndTime > DateTime.MinValue ? q.CalculateEndTime.ToString("yyyy-MM-dd") : "";
                            return dic2;
                        });
                        items.Add(dic);
                    }
                }
            }
            WebUtil.WriteJsonResult(context, new { items = items });
        }
        private void getprojectlist(HttpContext context)
        {
            var uid = GetUID(context);
            var list = WebUtil.GetMyXiaoQuProjects(uid);
            if (list.Length == 0)
            {
                list = Foresight.DataAccess.Project.GetProjectByParentID(1);
            }
            var items = list.Select(p =>
            {
                return new { ID = p.ID, ProjectName = p.Name };
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void savechaobiaopoint(HttpContext context)
        {
            var uid = GetUID(context);
            string liststr = context.Request["list"];
            ChaoBiaoModel[] list = JsonConvert.DeserializeObject<ChaoBiaoModel[]>(liststr);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in list)
                    {
                        var importfee = Foresight.DataAccess.ImportFee.GetOrCreateImportFeeByID(item.ID, helper, CanCreate: false);
                        if (importfee == null)
                        {
                            continue;
                        }
                        importfee.StartPoint = item.StartPoint;
                        importfee.EndPoint = item.EndPoint;
                        var TotalPoint = item.EndPoint - item.StartPoint;
                        importfee.TotalPoint = TotalPoint > 0 ? TotalPoint : 0;
                        importfee.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "savechaobiaopoint", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器异常");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void getchaobiaolist(HttpContext context)
        {
            var uid = GetUID(context);
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            var projectlist = new Foresight.DataAccess.Project[] { };
            if (ProjectID <= 0)
            {
                projectlist = WebUtil.GetMyXiaoQuProjects(uid);
                if (projectlist.Length == 0)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有相关资源信息");
                    return;
                }
                ProjectID = projectlist.FirstOrDefault().ID;
            }
            var projectitems = new List<Dictionary<string, object>>();
            var chargeitems = new List<Dictionary<string, object>>();
            var importitems = new List<Dictionary<string, object>>();
            if (ProjectID <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有相关资源信息");
                return;
            }
            projectitems = projectlist.Select(p =>
            {
                var dic = new Dictionary<string, object>();
                dic["ID"] = p.ID;
                dic["Name"] = p.Name;
                return dic;
            }).ToList();
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            int ChargeID = WebUtil.GetIntValue(context, "ChargeID");
            string keywords = context.Request["keywords"];
            //if (!string.IsNullOrEmpty(keywords))
            //{
            //    ChargeID = 0;
            //}
            List<int> ProjectIDList = new List<int>();
            ProjectIDList.Add(ProjectID);
            int[] RoomIDList = Foresight.DataAccess.ImportFee.GetImportFeeRoomIDList(ProjectIDList, keywords);
            if (RoomID <= 0 && RoomIDList.Length > 0)
            {
                RoomID = RoomIDList[0];
                ChargeID = 0;
            }
            if (RoomID <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有相关房间信息");
                return;
            }
            int PreRoomID = 0;
            int NextRoomID = 0;
            if (RoomIDList.Length > 1)
            {
                int currentindex = RoomIDList.ToList().FindIndex(c => c == RoomID);
                if (currentindex == 0)
                {
                    PreRoomID = 0;
                }
                else
                {
                    PreRoomID = RoomIDList[currentindex - 1];
                }
                if (currentindex < RoomIDList.Length - 1)
                {
                    NextRoomID = RoomIDList[currentindex + 1];
                }
                else
                {
                    NextRoomID = 0;
                }
            }
            var chargelist = new Foresight.DataAccess.ChargeSummary[] { };
            if (ChargeID <= 0)
            {
                chargelist = Foresight.DataAccess.ChargeSummary.GetChargeSummarysByImportRoomID(RoomID);
                if (chargelist.Length == 0)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有收费项目信息");
                    return;
                }
                ChargeID = chargelist.FirstOrDefault().ID;
            }
            if (ChargeID <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "没有收费项目信息");
                return;
            }
            chargeitems = chargelist.Select(p =>
            {
                var dic = new Dictionary<string, object>();
                dic["ID"] = p.ID;
                dic["Name"] = p.Name;
                return dic;
            }).ToList();
            var importlist = Foresight.DataAccess.ImportFeeDetails.GetImportFeeDetailsListByRoomID(RoomID, ChargeID);
            importitems = importlist.Select(p =>
            {
                var dic = new Dictionary<string, object>();
                dic["ID"] = p.ID;
                dic["Name"] = p.RoomName;
                dic["FullName"] = p.FinalFullName;
                dic["ImportBiaoCategory"] = p.ImportBiaoCategory;
                dic["ImportBiaoName"] = p.ImportBiaoName;
                dic["StartPoint"] = p.StartPoint > 0 ? p.StartPoint : 0;
                dic["EndPoint"] = p.EndPoint > 0 ? p.EndPoint : 0;
                dic["TotalPoint"] = p.TotalPoint > 0 ? p.TotalPoint : 0;
                dic["ImportCoefficient"] = p.ImportCoefficient > 0 ? p.ImportCoefficient : 0;
                dic["StartTime"] = p.StartTime > DateTime.MinValue ? p.StartTime.ToString("yyyy-MM-dd") : "";
                dic["EndTime"] = p.EndTime > DateTime.MinValue ? p.EndTime.ToString("yyyy-MM-dd") : "";
                return dic;
            }).ToList();
            WebUtil.WriteJsonResult(context, new { projectlist = projectitems, chargelist = chargeitems, importlist = importitems, ProjectID = ProjectID, ChargeID = ChargeID, RoomID = RoomID, PreRoomID = PreRoomID, NextRoomID = NextRoomID });
        }
        private void getapi(HttpContext context)
        {
            string SystemNumber = context.Request["SystemNumber"];
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
            Company company = null;
            if (!string.IsNullOrEmpty(SystemNumber))
            {
                company = Company.GetCompanyBySystenNumber(SystemNumber);
                if (company == null)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "系统编号错误");
                    return;
                }
            }
            else
            {
                company = Company.GetCompanyByLogin(LoginName, Password);
                if (company == null)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "用户名或密码错误");
                    return;
                }
            }
            WebUtil.WriteJsonResult(context, new { apiurl = company.BaseURL + "/Mobile/API.ashx", companyname = company.CompanyName });
        }
        private void login(HttpContext context)
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
            var user = User.GetAPPUserByLoginNamePassWord(LoginName, Password, UserTypeDefine.APPUser.ToString());
            if (user == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "用户名或密码错误");
                return;
            }
            if (user.IsLocked)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "帐号已被锁定,禁止登陆");
                return;
            }
            if (user.Type != UserTypeDefine.APPUser.ToString() && !user.IsAllowAPPUserLogin)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非APP账号，禁止登陆");
                return;
            }
            string DeviceId = context.Request["device_id"];
            string DeviceType = context.Request["device_type"];
            if (!string.IsNullOrEmpty(DeviceId))
            {
                user.APPUserDeviceID = DeviceId;
                user.APPUserDeviceType = DeviceType;
            }
            user.Save();
            var ticket = new System.Web.Security.FormsAuthenticationTicket(1, user.UserID.ToString(), DateTime.Now,
                       DateTime.Now.AddYears(1), true, string.Empty);
            var uid = System.Web.Security.FormsAuthentication.Encrypt(ticket);
            string headimg = string.IsNullOrEmpty(user.HeadImg) ? "" : WebUtil.GetContextPath() + user.HeadImg;
            string RealName = string.IsNullOrEmpty(user.RealName) ? user.LoginName : user.RealName;
            WebUtil.WriteJsonResult(context, new { uid = uid, username = RealName, headimg = headimg, phonenumber = user.PhoneNumber });
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        #region Comm Methods
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
                    throw new Exception("Decrypt uid fail", ex);
                }
                return uid;
            }
            else
            {
                throw new Exception("uid null");
            }
        }
        static int GetUID(HttpContext context, out User user)
        {
            user = null;
            int uid = GetUID(context);
            user = User.GetUser(uid);
            if (user == null)
            {
                throw new Exception("uid null");
            }
            return uid;
        }
        #endregion
    }
    public class ChaoBiaoModel
    {
        public int ID { get; set; }
        public decimal StartPoint { get; set; }
        public decimal EndPoint { get; set; }
    }
}