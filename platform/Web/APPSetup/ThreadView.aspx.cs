using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class ThreadView : BasePage
    {
        public int ID = 0;
        public string ImagePath = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int.TryParse(Request.QueryString["ID"], out ID);
                }
                if (ID > 0)
                {
                    var data = Foresight.DataAccess.Mall_Thread.GetMall_Thread(ID);
                    if (data != null)
                    {
                        SetInfo(data);
                    }
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Mall_Thread data)
        {
            this.tdUserName.InnerHtml = data.UserName;
            this.tdAddTime.InnerHtml = data.AddTime.ToString("yyyy-MM-dd HH:mm;ss");
            if (data.CategoryID > 0)
            {
                var category = Foresight.DataAccess.Mall_Category.GetMall_Category(data.CategoryID);
                if (category != null)
                {
                    this.tdCategoryID.InnerHtml = category.CategoryName;
                }
            }
            this.tdDescription.InnerHtml = data.Description;
        }
    }
}