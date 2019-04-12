using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Contract
{
    public partial class CancelContract : BasePage
    {
        public Foresight.DataAccess.Contract_Stop stop = null;
        public int StopID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ContractID = 0;
                int.TryParse(Request.QueryString["ID"], out ContractID);
                stop = Foresight.DataAccess.Contract_Stop.GetContract_StopByContractID(ContractID);
                if (stop != null)
                {
                    StopID = stop.ID;
                    SetInfo(stop);
                }
                else
                {
                    this.tdProcessMan.Value = WebUtil.GetUser(this.Context).RealName;
                    this.tdStopTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Contract_Stop data)
        {
            this.tdProcessMan.Value = data.ProcessMan;
            this.tdStopReason.Value = data.StopReason;
            this.tdStopTime.Value = data.StopTime == DateTime.MinValue ? "" : data.StopTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}