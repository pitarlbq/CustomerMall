using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cheque
{
    public partial class AddOutingService : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            var _cheque_OutingService = Foresight.DataAccess.Cheque_OutingService.GetCheque_OutingService(ID);
            if (_cheque_OutingService != null)
            {
                SetInfo(_cheque_OutingService);
            }
        }
        private void SetInfo(Foresight.DataAccess.Cheque_OutingService data)
        {
            this.tdServiceName.Value = data.ServiceName;
            this.tdServiceAddress.Value = data.ServiceAddress;
            this.tdServiceStartTime.Value = data.ServiceStartTime > DateTime.MinValue ? data.ServiceStartTime.ToString("yyyy-MM-dd") : "";
            this.tdServiceEndTime.Value = data.ServiceEndTime > DateTime.MinValue ? data.ServiceEndTime.ToString("yyyy-MM-dd") : "";
            this.tdContractMoney.Value = data.ContractMoney > 0 ? data.ContractMoney.ToString() : "";
        }
    }
}