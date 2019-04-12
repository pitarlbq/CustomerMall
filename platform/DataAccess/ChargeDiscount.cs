using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a ChargeDiscount.
    /// </summary>
    public partial class ChargeDiscount : EntityBase
    {
        public string DicountTypeDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.DiscountType))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.ChargeDiscountType), this.DiscountType);
            }
        }
    }
}
