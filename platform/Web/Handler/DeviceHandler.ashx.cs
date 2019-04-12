using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using Foresight.DataAccess.Ui;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace Web.Handler
{
    /// <summary>
    /// DeviceHandler 的摘要说明
    /// </summary>
    public class DeviceHandler : IHttpHandler, IRequiresSessionState
    {
        const string ModelName = "DeviceHandler";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug(ModelName, "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "loaddevicegrid":
                        loaddevicegrid(context);
                        break;
                    case "getdeviceparams":
                        getdeviceparams(context);
                        break;
                    case "savedevice":
                        savedevice(context);
                        break;
                    case "removedevice":
                        removedevice(context);
                        break;
                    case "getuserlist":
                        getuserlist(context);
                        break;
                    case "loaddevicetype":
                        loaddevicetype(context);
                        break;
                    case "savedevicetype":
                        savedevicetype(context);
                        break;
                    case "deletedevicetype":
                        deletedevicetype(context);
                        break;
                    case "loaddevicegroupgrid":
                        loaddevicegroupgrid(context);
                        break;
                    case "deletedevicegroup":
                        deletedevicegroup(context);
                        break;
                    case "savedevicegroup":
                        savedevicegroup(context);
                        break;
                    case "savesetting":
                        savesetting(context);
                        break;
                    case "batchsavedevice":
                        batchsavedevice(context);
                        break;
                    case "loaddevicetaskgrid":
                        loaddevicetaskgrid(context);
                        break;
                    case "removedevicetask":
                        removedevicetask(context);
                        break;
                    case "getdevicetaskimgs":
                        getdevicetaskimgs(context);
                        break;
                    case "removedevicetaskimg":
                        removedevicetaskimg(context);
                        break;
                    case "savedevicetask":
                        savedevicetask(context);
                        break;
                    case "getdevicetaskparams":
                        getdevicetaskparams(context);
                        break;
                    case "getdevicetasktypeparams":
                        getdevicetasktypeparams(context);
                        break;
                    case "savecomboboxtasktype":
                        savecomboboxtasktype(context);
                        break;
                    case "deletecomboboxtasktype":
                        deletecomboboxtasktype(context);
                        break;
                    case "getdevicemgrparams":
                        getdevicemgrparams(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ModelName, "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void getdevicemgrparams(HttpContext context)
        {
            var devicegroup = Foresight.DataAccess.Device_Group.GetDevice_Groups();
            var items = devicegroup.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.DeviceGroupName };
                return item;
            }).ToList();
            var firstitem = new { ID = 0, Name = "全部" };
            items.Insert(0, firstitem);
            WebUtil.WriteJson(context, new { devicegroup = items });
        }
        private void deletecomboboxtasktype(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var list = Foresight.DataAccess.Device.GetDeviceListByParams(new int[] { ID });
            if (list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "维保任务类型使用中，禁止删除" });
                return;
            }
            Foresight.DataAccess.Device_TaskType.DeleteDevice_TaskType(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savecomboboxtasktype(HttpContext context)
        {
            string liststr = context.Request["list"];
            if (string.IsNullOrEmpty(liststr))
            {
                WebUtil.WriteJson(context, new { status = false, msg = "参数错误" });
                return;
            }
            List<Utility.BasicModel> list = JsonConvert.DeserializeObject<List<Utility.BasicModel>>(liststr);
            foreach (var item in list)
            {
                Foresight.DataAccess.Device_TaskType data = null;
                if (item.id > 0)
                {
                    data = Foresight.DataAccess.Device_TaskType.GetDevice_TaskType(item.id);
                }
                if (data == null)
                {
                    data = new Device_TaskType();
                    data.AddTime = DateTime.Now;
                }
                data.TaskTypeName = item.value;
                data.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getdevicetasktypeparams(HttpContext context)
        {
            var list = Foresight.DataAccess.Device_TaskType.GetDevice_TaskTypes().OrderBy(p => p.ID).Select(p =>
            {
                var item = new { ID = p.ID, Name = p.TaskTypeName };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = list });

        }
        private void getdevicetaskparams(HttpContext context)
        {
            var users = Foresight.DataAccess.User.GetAPPUserList();
            WebUtil.WriteJson(context, new { users = users });
        }
        private void savedevicetask(HttpContext context)
        {
            Foresight.DataAccess.Device_Task device = null;
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            if (ID > 0)
            {
                device = Foresight.DataAccess.Device_Task.GetDevice_Task(ID);
            }
            if (device == null)
            {
                device = new Foresight.DataAccess.Device_Task();
                device.TaskAddTime = DateTime.Now;
                device.TaskAddMan = WebUtil.GetUser(context).RealName;
                device.IsAPPShow = true;
                device.IsAPPSend = false;
            }
            device.DeviceID = getIntValue(context, "hdDeviceID");
            device.TaskFrom = getValue(context, "tdTaskFrom");
            device.TaskType = getValue(context, "tdTaskType");
            device.TaskLevel = getValue(context, "tdTaskLevel");
            device.TaskStatus = getIntValue(context, "tdTaskStatus");
            device.TaskChargeManID = getIntValue(context, "tdTaskChargeMan");
            device.TaskChargeManName = context.Request["tdTaskChargeManName"];
            device.TaskChargeManPhone = getValue(context, "tdTaskChargeManPhone");
            device.TaskContent = getValue(context, "tdTaskContent");
            device.TaskTime = getTimeValue(context, "tdTaskTime");
            device.TaskCompleteTime = getTimeValue(context, "tdTaskCompleteTime");
            device.TaskCompleteContent = getValue(context, "tdTaskCompleteContent");

            HttpFileCollection uploadFiles = context.Request.Files;
            List<Foresight.DataAccess.DeviceTask_Image> filelist = new List<Foresight.DataAccess.DeviceTask_Image>();
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string FileName = postedFile.FileName;
                if (FileName != "" && FileName != null)
                {
                    string fileOriName = FileName;
                    string[] filearray = FileName.Split(':');
                    if (filearray.Length > 1)
                    {
                        fileOriName = System.IO.Path.GetFileName(FileName);
                    }
                    string extension = System.IO.Path.GetExtension(FileName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/device/";
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
                    filelist.Add(attach);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    device.Save(helper);
                    foreach (var item in filelist)
                    {
                        item.DeviceTaskID = device.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("DeviceHandler", "命令: savedevicetask", ex);
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true, ID = device.ID });
        }
        private void removedevicetaskimg(HttpContext context)
        {
            int ID = int.Parse(context.Request.Params["ID"]);
            Foresight.DataAccess.DeviceTask_Image.DeleteDeviceTask_Image(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getdevicetaskimgs(HttpContext context)
        {
            int ID = int.Parse(context.Request.Params["ID"]);
            var list = Foresight.DataAccess.DeviceTask_Image.GetDeviceTask_ImageListByDeviceTaskID(ID);
            var items = list.Select(p =>
            {
                var item = new { ID = p.ID, FileOriName = p.FileOriName, AttachedFilePath = WebUtil.GetContextPath() + p.AttachedFilePath };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void removedevicetask(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Device_Task] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError(ModelName, "命令: removedevicetask", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void loaddevicetaskgrid(HttpContext context)
        {
            string Keywords = context.Request.Params["Keywords"];
            string TaskFrom = context.Request["TaskFrom"];
            string TaskType = context.Request["TaskType"];
            string NewTaskType = context.Request["NewTaskType"];
            int Status = WebUtil.GetIntValue(context, "status");
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            int DeviceID = WebUtil.GetIntValue(context, "DeviceID");
            DataGrid dg = ViewDeviceTask.GetViewDeviceTaskGridByKeywords(Keywords, TaskFrom, TaskType, NewTaskType, DeviceID, Status, "order by TaskAddTime desc", startRowIndex, pageSize);
            string result = JsonConvert.SerializeObject(dg);
            context.Response.Write(result);
        }
        private void batchsavedevice(HttpContext context)
        {
            string ids = context.Request["ids"];
            if (string.IsNullOrEmpty(ids))
            {
                WebUtil.WriteJson(context, new { status = false, msg = "请选择设备" });
                return;
            }
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            string cmdset = string.Empty;
            string DeviceType = context.Request["DeviceType"];
            string DeviceGroup = context.Request["DeviceGroup"];
            string DeviceStatus = context.Request["DeviceStatus"];
            string DeviceLevel = context.Request["DeviceLevel"];
            string RepairType = context.Request["RepairType"];
            string RepairCompany = context.Request["RepairCompany"];
            string ThisRepairDate = context.Request["ThisRepairDate"];
            string ThisCheckDate = context.Request["ThisCheckDate"];
            if (!string.IsNullOrEmpty(DeviceType))
            {
                cmdset += ",[DeviceTypeID]='" + DeviceType + "'";
            }
            if (!string.IsNullOrEmpty(DeviceGroup))
            {
                cmdset += ",[DeviceGroupID]='" + DeviceGroup + "'";
            }
            if (!string.IsNullOrEmpty(DeviceStatus))
            {
                cmdset += ",[DeviceStatus]='" + DeviceStatus + "'";
            }
            if (!string.IsNullOrEmpty(DeviceLevel))
            {
                cmdset += ",[DeviceLevel]='" + DeviceLevel + "'";
            }
            if (!string.IsNullOrEmpty(RepairType))
            {
                cmdset += ",[RepairType]='" + RepairType + "'";
            }
            if (!string.IsNullOrEmpty(RepairCompany))
            {
                cmdset += ",[RepairCompany]='" + RepairCompany + "'";
            }
            if (!string.IsNullOrEmpty(ThisRepairDate))
            {
                DateTime _ThisRepairDate = DateTime.MinValue;
                DateTime.TryParse(ThisRepairDate, out _ThisRepairDate);
                if (_ThisRepairDate > DateTime.MinValue)
                {
                    cmdset += ",[ThisRepairDate]='" + _ThisRepairDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                }
            }
            if (!string.IsNullOrEmpty(ThisCheckDate))
            {
                DateTime _ThisCheckDate = DateTime.MinValue;
                DateTime.TryParse(ThisCheckDate, out _ThisCheckDate);
                if (_ThisCheckDate > DateTime.MinValue)
                {
                    cmdset += ",[ThisCheckDate]='" + _ThisCheckDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                }
            }
            if (!string.IsNullOrEmpty(cmdset))
            {
                cmdset = cmdset.Substring(1, cmdset.Length - 1);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "update [Device] set " + cmdset + " where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteError("DeviceHandler", "batchsavedevice", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savesetting(HttpContext context)
        {
            var list = Foresight.DataAccess.DeviceSetting.GetDeviceSettings();
            var repairtimesetup = list.FirstOrDefault(p => p.ModuleCode.Equals(Utility.EnumModel.DeviceSettingCode.repairtimesetup.ToString()));
            if (repairtimesetup == null)
            {
                repairtimesetup = new DeviceSetting();
                repairtimesetup.ModuleCode = "repairtimesetup";
                repairtimesetup.Title = "维保任务生成时间设置";
                repairtimesetup.AddTime = DateTime.Now;
            }
            repairtimesetup.Parameters1 = getServerValue(context, "tdrepairtimecount");
            repairtimesetup.Parameters2 = getServerValue(context, "tdrepairtimetype");
            var checktimesetup = list.FirstOrDefault(p => p.ModuleCode.Equals(Utility.EnumModel.DeviceSettingCode.checktimesetup.ToString()));
            if (checktimesetup == null)
            {
                checktimesetup = new DeviceSetting();
                checktimesetup.ModuleCode = "checktimesetup";
                checktimesetup.Title = "巡检任务生成时间设置";
                checktimesetup.AddTime = DateTime.Now;
            }
            checktimesetup.Parameters1 = getServerValue(context, "tdchecktimecount");
            checktimesetup.Parameters2 = getServerValue(context, "tdchecktimetype");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    repairtimesetup.Save(helper);
                    checktimesetup.Save(helper);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError(ModelName, "命令: savesetting", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void savedevicegroup(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.Device_Group group = null;
            if (ID > 0)
            {
                group = Foresight.DataAccess.Device_Group.GetDevice_Group(ID);
            }
            if (group == null)
            {
                group = new Device_Group();
                group.AddTime = DateTime.Now;
            }
            group.Code = getServerValue(context, "tdCode");
            group.DeviceGroupName = getServerValue(context, "tdDeviceGroupName");
            group.Description = getServerValue(context, "tdDescription");
            group.RepairUserID = getServerIntValue(context, "tdRepairUserID");
            group.CheckUserID = getServerIntValue(context, "tdCheckUserID");
            group.Save();
            WebUtil.WriteJson(context, new { status = true, ID = group.ID });
        }
        private void deletedevicegroup(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Device_Group] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true,\"success\":true}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError(ModelName, "命令: deletedevicegroup", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void loaddevicegroupgrid(HttpContext context)
        {
            string Keywords = context.Request.Params["Keywords"];
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            DataGrid dg = ViewDeviceGroup.GetViewDeviceGroupGridByKeywords(Keywords, "order by AddTime desc", startRowIndex, pageSize);
            string result = JsonConvert.SerializeObject(dg);
            context.Response.Write(result);
        }
        private void deletedevicetype(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            var list = Device_Type.GetChildDevice_Types(IDList);
            if (list.Length > 0)
            {
                context.Response.Write("{\"status\":true,\"success\":false}");
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Device_Type] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true,\"success\":true}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError(ModelName, "命令: deletedevicetype", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void savedevicetype(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            int ParentID = WebUtil.GetIntValue(context, "ParentID");
            Foresight.DataAccess.Device_Type devicetype = null;
            if (ID > 0)
            {
                devicetype = Foresight.DataAccess.Device_Type.GetDevice_Type(ID);
            }
            if (devicetype == null)
            {
                devicetype = new Device_Type();
                devicetype.AddTime = DateTime.Now;
            }
            else
            {
                ParentID = devicetype.ParentID;
            }
            Foresight.DataAccess.Device_Type parenttype = null;
            if (ParentID > 0)
            {
                parenttype = Foresight.DataAccess.Device_Type.GetDevice_Type(ParentID);
            }
            if (parenttype != null)
            {
                int type_level = parenttype.TypeLevel > 0 ? parenttype.TypeLevel : 1;
                devicetype.ParentID = parenttype.ID;
                devicetype.TypeLevel = parenttype.TypeLevel + 1;
            }
            else
            {
                devicetype.ParentID = 0;
                devicetype.TypeLevel = 1;
            }
            devicetype.Code = getServerValue(context, "tdCode");
            devicetype.DeviceTypeName = getServerValue(context, "tdDeviceTypeName");
            devicetype.Description = getServerValue(context, "tdDescription");
            devicetype.Save();
            WebUtil.WriteJson(context, new { status = true, ID = devicetype.ID });
        }
        private Device_Type[] mTypeList = new Device_Type[] { };
        public List<TypeListTree> AllList = new List<TypeListTree>();
        public Device_Type[] GetTypeList()
        {
            if (mTypeList.Length == 0)
            {
                mTypeList = Device_Type.GetDevice_Types().ToArray();
            }
            return mTypeList;
        }
        private void loaddevicetype(HttpContext context)
        {
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            int startRowIndex = (int.Parse(page) - 1) * int.Parse(rows);
            int pageSize = int.Parse(rows);
            string Keywords = context.Request["Keywords"];
            var TypeList = GetTypeList();
            var topTypeList = TypeList.Where(p => p.ParentID == 0 || p.ParentID == int.MinValue).ToArray();
            if (!string.IsNullOrEmpty(Keywords))
            {
                topTypeList = topTypeList.Where(p => p.DeviceTypeName.Contains(Keywords)).ToArray();
            }
            var topList = topTypeList.Skip(startRowIndex).Take(pageSize).ToArray();
            AllList = new List<TypeListTree>();
            for (int i = 0; i < topList.Length; i++)
            {
                var typeListTree = new TypeListTree();
                typeListTree.ID = topList[i].ID;
                typeListTree.DeviceTypeName = topList[i].DeviceTypeName;
                typeListTree.Code = topList[i].Code;
                typeListTree.Description = topList[i].Description;
                typeListTree._parentId = 0;
                typeListTree.TypeLevel = topList[i].TypeLevel;
                AllList.Add(typeListTree);
                LoadSubTree(topList[i].ID, Keywords);
            }
            DataGrid dg = new DataGrid();
            dg.total = topTypeList.Length;
            dg.rows = AllList;
            dg.page = pageSize;
            WebUtil.WriteJson(context, dg);
        }
        private void LoadSubTree(int ID, string Keywords = "")
        {
            var TypeList = GetTypeList();
            var subList = TypeList.Where(p => p.ParentID == ID).ToArray();
            if (!string.IsNullOrEmpty(Keywords))
            {
                subList = subList.Where(p => p.DeviceTypeName.Contains(Keywords)).ToArray();
            }
            if (subList.Length == 0)
            {
                return;
            }
            for (int i = 0; i < subList.Length; i++)
            {
                var typeListTree = new TypeListTree();
                typeListTree.ID = subList[i].ID;
                typeListTree.DeviceTypeName = subList[i].DeviceTypeName;
                typeListTree.Code = subList[i].Code;
                typeListTree.Description = subList[i].Description;
                typeListTree._parentId = subList[i].ParentID;
                typeListTree.TypeLevel = subList[i].TypeLevel;
                AllList.Add(typeListTree);
                LoadSubTree(subList[i].ID, Keywords);
            }
            return;
        }
        private void getuserlist(HttpContext context)
        {
            var userlist = Foresight.DataAccess.User.GetAPPUserList();
            WebUtil.WriteJson(context, new { UserList = userlist });
        }
        private void removedevice(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            if (IDList.Count > 0)
            {
                var list = Foresight.DataAccess.Device_Task.GetDevice_TaskListByDeviceIDList(IDList);
                if (list.Length > 0)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "设备有维保任务，禁止删除" });
                    return;
                }
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [Device] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        Utility.LogHelper.WriteError(ModelName, "命令: removedevice", ex);
                        helper.Rollback();
                        context.Response.Write("{\"status\":false}");
                    }
                }
            }
            context.Response.Write("{\"status\":true}");
        }
        private void savedevice(HttpContext context)
        {
            Foresight.DataAccess.Device device = null;
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            if (ID > 0)
            {
                device = Foresight.DataAccess.Device.GetDevice(ID);
            }
            if (device == null)
            {
                device = new Foresight.DataAccess.Device();
                device.AddTime = DateTime.Now;
                device.AddMan = WebUtil.GetUser(context).RealName;
            }
            device.DeviceNo = getValue(context, "tdDeviceNo");
            device.DeviceTypeID = getIntValue(context, "tdDeviceType");
            device.DeviceGroupID = getIntValue(context, "tdDeviceGroup");
            device.ProjectID = getIntValue(context, "tdProjectName");
            device.DeviceName = getValue(context, "tdDeviceName");
            device.ModelNo = getValue(context, "tdModelNo");
            device.DeviceStatus = getIntValue(context, "tdDeviceStatus");
            device.DeviceLevel = getValue(context, "tdDeviceLevel");
            device.RepairType = getValue(context, "tdRepairType");
            device.Supplier = getValue(context, "tdSupplier");
            device.SupplierMan = getValue(context, "tdSupplierMan");
            device.SupplierPhone = getValue(context, "tdSupplierPhone");
            device.RepairCompany = getValue(context, "tdRepairCompany");
            device.RepairUserID = getIntValue(context, "tdRepairUser");
            device.RepairUserPhone = getValue(context, "tdRepairUserPhone");
            device.FirstRepairDate = getTimeValue(context, "tdFirstRepairDate");
            device.RepairCount = getIntValue(context, "tdRepairCount");
            device.RepairCycle = getValue(context, "tdRepairCycle");
            device.CheckUserID = getIntValue(context, "tdCheckUser");
            device.FirstCheckDate = getTimeValue(context, "tdFirstCheckDate");
            device.CheckCount = getIntValue(context, "tdCheckCount");
            device.CheckCycle = getValue(context, "tdCheckCycle");
            device.Remark = getValue(context, "tdRemark");
            device.ThisRepairDate = getTimeValue(context, "tdThisRepairDate");
            device.ThisCheckDate = getTimeValue(context, "tdThisCheckDate");
            device.TaskTypeID = getIntValue(context, "tdTaskType");
            device.PurchaseDate = getTimeValue(context, "tdPurchaseDate");
            device.GuaranteeDate = getValue(context, "tdGuaranteeDate");
            device.GuaranteeEndDate = getTimeValue(context, "tdGuaranteeEndDate");
            device.LocationPlace = getValue(context, "tdLocationPlace");
            HttpFileCollection uploadFiles = context.Request.Files;
            List<Foresight.DataAccess.Device_Image> filelist = new List<Foresight.DataAccess.Device_Image>();
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string FileName = postedFile.FileName;
                if (FileName != "" && FileName != null)
                {
                    string fileOriName = FileName;
                    string[] filearray = FileName.Split(':');
                    if (filearray.Length > 1)
                    {
                        fileOriName = System.IO.Path.GetFileName(FileName);
                    }
                    string extension = System.IO.Path.GetExtension(FileName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/device/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    Foresight.DataAccess.Device_Image attach = new Foresight.DataAccess.Device_Image();
                    attach.FileOriName = fileOriName;
                    attach.AttachedFilePath = filepath + fileName;
                    attach.AddTime = DateTime.Now;
                    filelist.Add(attach);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    device.Save(helper);
                    foreach (var item in filelist)
                    {
                        item.DeviceID = device.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("DeviceHandler", "命令: savedevice", ex);
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true, ID = device.ID });
        }
        private void getdeviceparams(HttpContext context)
        {
            var devicetype = Foresight.DataAccess.Device_Type.GetDevice_Types();
            var devicegroup = Foresight.DataAccess.Device_Group.GetDevice_Groups();
            var users = Foresight.DataAccess.User.GetAPPUserList();
            var tasktypes = Foresight.DataAccess.Device_TaskType.GetDevice_TaskTypes();
            var projects = WebUtil.GetMyProjectsByLevel(1, WebUtil.GetUser(context).UserID);
            WebUtil.WriteJson(context, new { devicetype = devicetype, devicegroup = devicegroup, users = users, tasktypes = tasktypes, projects = projects });
        }
        private void loaddevicegrid(HttpContext context)
        {
            string Keywords = context.Request.Params["Keywords"];
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            int DeviceGroupID = WebUtil.GetIntValue(context, "DeviceGroupID");
            string ProjectIDs = context.Request["ProjectIDList"];
            List<int> ProjectIDList = new List<int>();
            if (!string.IsNullOrEmpty(ProjectIDs))
            {
                ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
            }
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            DataGrid dg = ViewDevice.GetViewDeviceGridByKeywords(Keywords, DeviceGroupID, ProjectIDList, "order by AddTime asc", startRowIndex, pageSize, canexport: canexport);
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadDeviceData(dg, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                return;
            }

            string result = JsonConvert.SerializeObject(dg);
            context.Response.Write(result);
        }
        private string getServerValue(HttpContext context, string name)
        {
            string PostName = "ctl00$content$";
            return context.Request.Params[PostName + name];
        }
        private int getServerIntValue(HttpContext context, string name)
        {
            int result = 0;
            int.TryParse(getServerValue(context, name), out result);
            return result;
        }
        private DateTime getServerTimeValue(HttpContext context, string name)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(getServerValue(context, name), out result);
            return result;
        }
        private decimal getServerDecimalValue(HttpContext context, string name)
        {
            decimal result = 0;
            decimal.TryParse(getServerValue(context, name), out result);
            return result;
        }
        private string getValue(HttpContext context, string name)
        {
            string skey = "ctl00$content$";
            return context.Request.Params[skey + name];
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
    }
    public class TypeListTree
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string DeviceTypeName { get; set; }
        public int TypeLevel { get; set; }
        public string Description { get; set; }
        public int _parentId { get; set; }
    }
}