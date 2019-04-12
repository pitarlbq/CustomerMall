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
    /// This object represents the properties and methods of a Contract_File.
    /// </summary>
    public partial class Contract_File : EntityBase
    {
        public static Contract_File[] GetContract_FileAttachList(int RelateID, string FileType)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[RelateID]=@RelateID");
            parameters.Add(new SqlParameter("@RelateID", RelateID));
            conditions.Add("[FileType]=@FileType");
            parameters.Add(new SqlParameter("@FileType", FileType));
            return GetList<Contract_File>("select * from [Contract_File] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters).ToArray();
        }
    }
}
