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
    /// This object represents the properties and methods of a ChargeBackGuaranteeTemp.
    /// </summary>
    public partial class ChargeBackGuaranteeTemp : EntityBase
    {
        public static ChargeBackGuaranteeTemp[] GetChargeBackGuaranteeTempListByGUID(string GUID)
        {
            if (string.IsNullOrEmpty(GUID))
            {
                return new ChargeBackGuaranteeTemp[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[GUID]=@GUID");
            parameters.Add(new SqlParameter("@GUID", GUID));
            ChargeBackGuaranteeTemp[] list = GetList<ChargeBackGuaranteeTemp>("select * from [ChargeBackGuaranteeTemp] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
    }
}
