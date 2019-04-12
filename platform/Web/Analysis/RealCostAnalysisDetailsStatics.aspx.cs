using ExcelProcess;
using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;
using Web.APPCode;

namespace Web.Analysis
{
    public partial class RealCostAnalysisDetailsStatics : BasePage
    {
        public string StartTime;
        public string EndTime;
        public string op = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["op"] != null)
                {
                    op = Request.QueryString["op"];
                }
                DateTime Start = DateTime.MinValue;
                DateTime End = DateTime.MinValue;
                string Title = string.Empty;
                AnalysisTimeHelper.GetSK(WebUtil.GetUser(this.Context).UserID, out Start, out End, out Title);
                StartTime = Start > DateTime.MinValue ? Start.ToString("yyyy-MM-dd HH:mm:ss") : "";
                EndTime = End > DateTime.MinValue ? End.ToString("yyyy-MM-dd HH:mm:ss") : "";
            }
        }
    }
}