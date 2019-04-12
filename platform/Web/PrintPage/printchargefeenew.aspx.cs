using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Foresight.DataAccess;
using Utility;
using Foresight.DataAccess.Framework;

namespace Web.PrintPage
{
    public partial class printchargefeenew : BasePage
    {
        public string IDs = string.Empty;
        public int RoomID = 0;
        public bool CanPrintCheque = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["IDs"]))
                {
                    IDs = Request.QueryString["IDs"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["RoomID"]))
                {
                    int.TryParse(Request.QueryString["RoomID"], out RoomID);   
                }
                CanPrintCheque = new Utility.SiteConfig().IsWriteChequeOn;
            }
        }
    }
}