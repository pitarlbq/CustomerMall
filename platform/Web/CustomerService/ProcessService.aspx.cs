using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web.CustomerService
{
    public partial class ProcessService : BasePage
    {
        public Foresight.DataAccess.CustomerService service;
        public string guid = string.Empty;
        public string op = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            guid = System.Guid.NewGuid().ToString();
            int ID = 0;
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                Response.Write("ID不合法");
                Response.End();
                return;
            }
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID <= 0)
            {
                Response.Write("ID不合法");
                Response.End();
                return;
            }
            if (Request.QueryString["op"] != null)
            {
                op = Request.QueryString["op"];
            }
            service = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            if (service != null)
            {
                SetInfo(service);
            }
            else
            {
                Response.Write("ID不合法");
                Response.End();
                return;
            }
        }
        private void SetInfo(Foresight.DataAccess.CustomerService data)
        {
            this.tdAcceptMan.Value = data.FinalServiceAccpetMan;
            this.tdAppointTime.Value = data.ServiceAppointTime == DateTime.MinValue ? "" : data.ServiceAppointTime.ToString("yyyy-MM-dd HH:mm:ss");
            var chulilist = Foresight.DataAccess.CustomerServiceChuli.GetCustomerServiceChuliList(data.ID);
            this.rptRecord.DataSource = chulilist;
            this.rptRecord.DataBind();
            this.tdHandelFee.Value = data.HandelFee;
            this.tdTotalFee.Value = data.TotalFee > 0 ? data.TotalFee.ToString() : "";
            this.tdIsRequireProduct.Checked = data.IsRequireProduct;
        }

        protected void FileRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptRecord_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater fileRep = (Repeater)e.Item.FindControl("FileRepeater");
                var data = ((Foresight.DataAccess.CustomerServiceChuli)e.Item.DataItem);
                fileRep.DataSource = Foresight.DataAccess.CustomerServiceChuli_Attach.GetCustomerServiceChuli_AttachList(data.ID);
                fileRep.DataBind();
            }
        }
    }
}