using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Contract
{
    public partial class EditTemplate : BasePage
    {
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int.TryParse(Request.QueryString["ID"], out ID);
                if (ID > 0)
                {
                    var data = Foresight.DataAccess.Contract_Template.GetContract_Template(ID);
                    SetInfo(data);
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Contract_Template data)
        {
            this.tdTemplateNo.Value = data.TemplateNo;
            this.tdTemplateName.Value = data.TemplateName;
            this.tdTemplateSummary.Value = data.TemplateSummary;
            this.hdContent.Value = data.TemplateContent;
        }
    }
}