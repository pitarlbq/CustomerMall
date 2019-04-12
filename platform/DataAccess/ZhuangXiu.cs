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
    /// This object represents the properties and methods of a ZhuangXiu.
    /// </summary>
    public partial class ZhuangXiu : EntityBase
    {
        public string StatusDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.Status))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.ZhuangXiuStatus), this.Status);
            }
        }
    }
}
