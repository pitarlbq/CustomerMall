using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Master
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected string GetContextPath()
        {
            return "http://" + Request.ServerVariables["HTTP_HOST"].ToString() + getApplicationPath();
        }
        private string getApplicationPath()
        {
            string _ApplicationPath = HttpContext.Current.Request.ApplicationPath;
            if (_ApplicationPath.Length == 1)
            {
                _ApplicationPath = "";
            }
            else if (!_ApplicationPath.StartsWith("/"))
            {
                _ApplicationPath = "/" + _ApplicationPath;
            }
            return _ApplicationPath;
        }
    }
}