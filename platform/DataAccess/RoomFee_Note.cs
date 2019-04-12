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
    /// This object represents the properties and methods of a RoomFee_Note.
    /// </summary>
    public partial class RoomFee_Note : EntityBase
    {
        public static RoomFee_Note[] GetRoomFee_NoteListByRoomID(int RoomID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoomID > 0)
            {
                conditions.Add("([RoomID]=@RoomID or [RoomID] in (select [RoomID] from [RoomRelation] where [GUID] in (select [GUID] from [RoomRelation] where [RoomID]=@RoomID)))");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
            }
            return GetList<RoomFee_Note>("select * from [RoomFee_Note] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
