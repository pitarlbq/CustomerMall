using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class smstest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tdSumit_Click(object sender, EventArgs e)
        {
            string mobile = this.tdPhoneNumber.Text;//发送手机号
            string body = this.tdContent.Text;//短信内容
            string restcount = string.Empty;
            string result = Utility.Tools.SendVerifyCode(mobile, body);
            this.tdResult.Text = result;
        }
    }
}