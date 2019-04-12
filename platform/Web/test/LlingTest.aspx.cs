using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web
{
    public partial class LlingTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tdSumit_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(this.tdPage.Text);
            int rows = Convert.ToInt32(this.tdRows.Text);
            string error = string.Empty;
            var result = LLingHelper.doQueryOpenDoorLog(page, rows, out error);
            this.tdResult.Text = Utility.JsonConvert.SerializeObject(result);
        }
    }
}