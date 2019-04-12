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
    /// This object represents the properties and methods of a Mall_Product_Picture.
    /// </summary>
    public partial class Mall_Product_Picture : EntityBase
    {
        public static Mall_Product_Picture[] GetMall_Product_PictureListByID(int ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ID == 0)
            {
                return new Mall_Product_Picture[] { };
            }
            conditions.Add("[ProductID]=@ID");
            parameters.Add(new SqlParameter("@ID", ID));
            string cmdtext = "select * from [Mall_Product_Picture] where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Mall_Product_Picture>(cmdtext, parameters).ToArray();
            return list;
        }
    }
}
