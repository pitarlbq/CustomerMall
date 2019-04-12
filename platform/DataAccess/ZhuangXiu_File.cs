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
	/// This object represents the properties and methods of a ZhuangXiu_File.
	/// </summary>
	public partial class ZhuangXiu_File : EntityBase
	{
        public static ZhuangXiu_File[] GetZhuangXiu_FileAttachList(int RelateID, string FileType)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[RelateID]=@RelateID");
            parameters.Add(new SqlParameter("@RelateID", RelateID));
            conditions.Add("[FileType]=@FileType");
            parameters.Add(new SqlParameter("@FileType", FileType));
            return GetList<ZhuangXiu_File>("select * from [ZhuangXiu_File] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters).ToArray();
        }
	}
}
