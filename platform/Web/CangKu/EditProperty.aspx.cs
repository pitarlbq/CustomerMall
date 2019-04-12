using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.CangKu
{
    public partial class EditProperty : BasePage
    {
        public int PropertyID = 0;
        public string op = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["op"] != null)
            {
                op = Request.QueryString["op"];
            }
            var categories = Foresight.DataAccess.CKPropertyCategory.GetCKPropertyCategories();
            this.hdCategories.Value = JsonConvert.SerializeObject(categories);
            var departments = Foresight.DataAccess.CKDepartment.GetCKDepartments();
            this.hdDepartments.Value = JsonConvert.SerializeObject(departments);
            int.TryParse(Request.QueryString["ID"], out PropertyID);
            if (PropertyID > 0)
            {
                var data = Foresight.DataAccess.CKProperty.GetCKProperty(PropertyID);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.CKProperty data)
        {
            this.tdPropertyCategory.Value = data.PropertyCategoryID > 0 ? data.PropertyCategoryID.ToString() : "";
            this.tdPropertyNo.Value = data.PropertyNo;
            this.tdPropertyName.Value = data.PropertyName;
            this.tdPropertyModelNo.Value = data.PropertyModelNo;
            this.tdPropertyUnit.Value = data.PropertyUnit;
            this.tdPropertyCount.Value = data.PropertyCount > int.MinValue ? data.PropertyCount.ToString() : "";
            this.tdPropertyUnitPrice.Value = data.PropertyUnitPrice > decimal.MinValue ? data.PropertyUnitPrice.ToString() : "";
            this.tdPropertyCost.Value = data.PropertyCost > decimal.MinValue ? data.PropertyCost.ToString() : "";
            this.tdPropertyPurchaseDate.Value = data.PropertyPurchaseDate > DateTime.MinValue ? data.PropertyPurchaseDate.ToString("yyyy-MM-dd") : "";
            this.tdPropertyUseYear.Value = data.PropertyUseYear > decimal.MinValue ? data.PropertyUseYear.ToString() : "";
            this.tdPropertyRealCost.Value = data.PropertyRealCost > decimal.MinValue ? data.PropertyRealCost.ToString() : "";
            this.tdPropertyDiscountCost.Value = data.PropertyDiscountCost > decimal.MinValue ? data.PropertyDiscountCost.ToString() : "";
            this.tdPropertyChangeType.Value = data.PropertyChangeType;
            this.tdPropertyState.Value = data.PropertyState > int.MinValue ? data.PropertyState.ToString() : "";
            this.tdPropertyDepartment.Value = data.PropertyDepartmentID > 0 ? data.PropertyDepartmentID.ToString() : "";
            this.tdPropertyLocation.Value = data.PropertyLocation;
            this.tdPropertyUseMan.Value = data.PropertyUseMan;
            this.tdPropertyContractName.Value = data.PropertyContractName;
            this.tdPropertyContactPhone.Value = data.PropertyContactPhone;
            this.tdPropertyRemark.Value = data.PropertyRemark;
        }
    }
}