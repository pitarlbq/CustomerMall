using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Device
{
    public partial class EditDeviceType : BasePage
    {
        public Foresight.DataAccess.Device_Type devicetype = null;
        public Foresight.DataAccess.Device_Type parenttype = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int TypeID = 0;
                int.TryParse(Request.QueryString["ID"], out TypeID);
                int ParentID = 0;
                int.TryParse(Request.QueryString["ParentID"], out ParentID);
                if (TypeID > 0)
                {
                    devicetype = Foresight.DataAccess.Device_Type.GetDevice_Type(TypeID);
                    if (devicetype == null)
                    {
                        Response.Write("ID不合法");
                        Response.End();
                    }
                    this.tdCode.Value = devicetype.Code;
                    if (devicetype.ParentID > 0)
                    {
                        parenttype = Foresight.DataAccess.Device_Type.GetDevice_Type(devicetype.ParentID);
                        if (parenttype != null)
                        {
                            this.tdParentID.Value = parenttype.DeviceTypeName;
                        }
                    }
                    this.tdDeviceTypeName.Value = devicetype.DeviceTypeName;
                    this.tdDescription.Value = devicetype.Description;
                }
                else if (ParentID > 0)
                {
                    parenttype = Foresight.DataAccess.Device_Type.GetDevice_Type(ParentID);
                    if (parenttype != null)
                    {
                        this.tdParentID.Value = parenttype.DeviceTypeName;
                    }
                }
            }
        }
    }
}