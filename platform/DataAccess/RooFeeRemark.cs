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
    /// This object represents the properties and methods of a RooFeeRemark.
    /// </summary>
    public partial class RooFeeRemark : EntityBase
    {
        public static RooFeeRemark GetRooFeeRemarkByRoomFeeID(int RooFeeID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RooFeeID > 0)
            {
                conditions.Add("[RooFeeID]=@RooFeeID");
                parameters.Add(new SqlParameter("@RooFeeID", RooFeeID));
            }
            return GetOne<RooFeeRemark>("select top 1 * from [RooFeeRemark] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
    }
}
