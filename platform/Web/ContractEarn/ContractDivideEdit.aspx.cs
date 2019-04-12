using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ContractEarn
{
    public partial class ContractDivideEdit : BasePage
    {
        public int DivideID = 0;
        public bool can_edit = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                DivideID = Convert.ToInt32(Request.QueryString["ID"]);
            }
            if (Request.QueryString["op"] != null)
            {
                if (Request.QueryString["op"].Equals("view"))
                {
                    this.can_edit = false;
                }
            }
            Foresight.DataAccess.Contract_Divide data = null;
            if (DivideID > 0)
            {
                data = Foresight.DataAccess.Contract_Divide.GetContract_Divide(DivideID);
            }
            if (data == null)
            {
                Response.End();
                return;
            }
            if (data.ContractID > 0)
            {
                var contract = Foresight.DataAccess.Contract.GetContract(data.ContractID);
                this.tdContractNo.Value = contract == null ? string.Empty : contract.ContractNo;
                this.hdContractID.Value = contract == null ? "" : contract.ID.ToString();
            }
            this.tdRentName.Value = data.RentName;
            this.tdWirteDate.Value = data.WriteDate > DateTime.MinValue ? WebUtil.GetStrDate(data.WriteDate) : string.Empty;
            this.tdStartTime.Value = data.StartTime > DateTime.MinValue ? WebUtil.GetStrDate(data.StartTime) : string.Empty;
            this.tdEndTime.Value = data.EndTime > DateTime.MinValue ? WebUtil.GetStrDate(data.EndTime) : string.Empty;
            this.tdSellCost.Value = data.SellCost > 0 ? data.SellCost.ToString("0.00") : string.Empty;
            this.tdDivideType.Value = data.DivideType;
            this.tdRemark.Value = data.Remark;
            if (data.DivideType.Equals(Utility.EnumModel.ContractDivideTypeDefine.fixedpercent.ToString()))
            {
                var dividetype = Foresight.DataAccess.Contract_DivideType.GetContract_DivideTypeList(data.ID).FirstOrDefault(p => p.DivideType.Equals(data.DivideType));
                this.tdFixedPercent.Value = dividetype == null ? string.Empty : dividetype.Divide_Percent.ToString();
            }
        }
    }
}