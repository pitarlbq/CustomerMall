using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Device
{
    public partial class EditDevice : BasePage
    {
        public Foresight.DataAccess.Device device = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                device = Foresight.DataAccess.Device.GetDevice(ID);
                if (device != null)
                {
                    SetInfo(device);
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Device data)
        {
            this.tdDeviceNo.Value = data.DeviceNo;
            this.tdDeviceType.Value = data.DeviceTypeID > 0 ? data.DeviceTypeID.ToString() : "";
            this.tdDeviceName.Value = data.DeviceName;
            this.tdDeviceGroup.Value = data.DeviceGroupID > 0 ? data.DeviceGroupID.ToString() : "";
            this.tdModelNo.Value = data.ModelNo;
            this.tdDeviceStatus.Value = data.DeviceStatus > 0 ? data.DeviceStatus.ToString() : "";
            this.tdDeviceLevel.Value = data.DeviceLevel;
            this.tdTaskType.Value = data.TaskTypeID > 0 ? data.TaskTypeID.ToString() : "";
            this.tdSupplier.Value = data.Supplier;
            this.tdSupplierMan.Value = data.SupplierMan;
            this.tdSupplierPhone.Value = data.SupplierPhone;
            this.tdRepairCompany.Value = data.RepairCompany;
            this.tdRepairUser.Value = data.RepairUserID > 0 ? data.RepairUserID.ToString() : "";
            this.tdRepairUserPhone.Value = data.RepairUserPhone;
            this.tdFirstRepairDate.Value = data.FirstRepairDate == DateTime.MinValue ? "" : data.FirstRepairDate.ToString("yyyy-MM-dd");
            this.tdRepairCount.Value = data.RepairCount > 0 ? data.RepairCount.ToString() : "";
            this.tdRepairCycle.Value = data.RepairCycle;
            this.tdLastRepairDate.Value = data.LastRepairDate == DateTime.MinValue ? "" : data.LastRepairDate.ToString("yyyy-MM-dd");
            this.tdThisRepairDate.Value = data.ThisRepairDate == DateTime.MinValue ? "" : data.ThisRepairDate.ToString("yyyy-MM-dd");
            this.tdCheckUser.Value = data.CheckUserID > 0 ? data.CheckUserID.ToString() : "";
            this.tdFirstCheckDate.Value = data.FirstCheckDate == DateTime.MinValue ? "" : data.FirstCheckDate.ToString("yyyy-MM-dd");
            this.tdCheckCount.Value = data.CheckCount > 0 ? data.CheckCount.ToString() : "";
            this.tdCheckCycle.Value = data.CheckCycle;
            this.tdLastCheckDate.Value = data.LastCheckDate == DateTime.MinValue ? "" : data.LastCheckDate.ToString("yyyy-MM-dd");
            this.tdThisCheckDate.Value = data.ThisCheckDate == DateTime.MinValue ? "" : data.ThisCheckDate.ToString("yyyy-MM-dd");
            this.tdRemark.Value = data.Remark;
            this.tdPurchaseDate.Value = data.PurchaseDate > DateTime.MinValue ? data.PurchaseDate.ToString("yyyy-MM-dd") : "";
            this.tdGuaranteeDate.Value = data.GuaranteeDate;
            this.tdGuaranteeEndDate.Value = data.GuaranteeEndDate > DateTime.MinValue ? data.GuaranteeEndDate.ToString("yyyy-MM-dd") : "";
            this.tdProjectName.Value = data.ProjectID > 0 ? data.ProjectID.ToString() : "";
            this.tdLocationPlace.Value = data.LocationPlace;
        }
        protected override void ProcessAjaxRequest(HttpContext context, string action)
        {
            switch (action)
            {
                case "getdeviceimgs":
                    getdeviceimgs(context);
                    break;
                case "deletedeviceimg":
                    deletedeviceimg(context);
                    break;
                default:
                    base.ProcessAjaxRequest(context, action);
                    break;
            }
        }
        private void deletedeviceimg(HttpContext context)
        {
            int ID = int.Parse(context.Request.Params["ID"]);
            Foresight.DataAccess.Device_Image.DeleteDevice_Image(ID);
            WebUtil.WriteJsonResult(context, "删除成功");
        }
        private void getdeviceimgs(HttpContext context)
        {
            int ID = int.Parse(context.Request.Params["ID"]);
            var list = Foresight.DataAccess.Device_Image.GetDevice_ImageListByDeviceID(ID);
            var items = list.Select(p =>
            {
                var item = new { ID = p.ID, FileOriName = p.FileOriName, AttachedFilePath = WebUtil.GetContextPath() + p.AttachedFilePath };
                return item;
            });
            WebUtil.WriteJsonResult(context, items);
        }
    }
}