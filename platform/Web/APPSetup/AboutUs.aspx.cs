using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.APPSetup
{
    public partial class AboutUs : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var list = Foresight.DataAccess.Mall_Content.GetMall_Contents().ToArray();
                string name = Utility.EnumModel.MallContentNameDefine.aboutus.ToString();
                var data = list.FirstOrDefault(p => p.Name.Equals(name));
                if (data != null)
                {
                    this.hdContent.Value = data.Value;
                }

                name = Utility.EnumModel.MallContentNameDefine.contactus.ToString();
                data = list.FirstOrDefault(p => p.Name.Equals(name));
                if (data != null)
                {
                    this.tdPhoneNumber.Value = data.Value;
                }

                name = Utility.EnumModel.MallContentNameDefine.sharetitle.ToString();
                data = list.FirstOrDefault(p => p.Name.Equals(name));
                if (data != null)
                {
                    this.tdShareTile.Value = data.Value;
                }

                name = Utility.EnumModel.MallContentNameDefine.sharedescription.ToString();
                data = list.FirstOrDefault(p => p.Name.Equals(name));
                if (data != null)
                {
                    this.tdShareDescription.Value = data.Value;
                }

                name = Utility.EnumModel.MallContentNameDefine.androiddownloadurl.ToString();
                data = list.FirstOrDefault(p => p.Name.Equals(name));
                if (data != null)
                {
                    this.tdAndroidDownloadURL.Value = data.Value;
                }

                name = Utility.EnumModel.MallContentNameDefine.iosdownloadurl.ToString();
                data = list.FirstOrDefault(p => p.Name.Equals(name));
                if (data != null)
                {
                    this.tdIOSDownloadURL.Value = data.Value;
                }
            }
        }
    }
}