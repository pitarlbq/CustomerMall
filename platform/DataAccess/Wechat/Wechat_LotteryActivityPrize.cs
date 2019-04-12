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
    /// This object represents the properties and methods of a Wechat_LotteryActivityPrize.
    /// </summary>
    public partial class Wechat_LotteryActivityPrize : EntityBase
    {
        public static Wechat_LotteryActivityPrize[] GetWechat_LotteryActivityPrizes(int activityID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");

            parameters.Add(new SqlParameter("@ActivityID", activityID));
            conditions.Add("[ActivityID]=@ActivityID");

            return GetList<Wechat_LotteryActivityPrize>("select * from  " + TableName + " where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Ui.DataGrid GetWechat_LotteryActivityPrizeGridByKeywords(string Keywords, int ActivityID, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([LevelName] like @Keywords or [PrizeName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (ActivityID > 0)
            {
                conditions.Add("[ActivityID]=@ActivityID");
                parameters.Add(new SqlParameter("@ActivityID", ActivityID));
            }
            string fieldList = "[Wechat_LotteryActivityPrize].* ";
            string Statement = " from [Wechat_LotteryActivityPrize] where  " + string.Join(" and ", conditions.ToArray());
            Wechat_LotteryActivityPrize[] list = GetList<Wechat_LotteryActivityPrize>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string PrizeTypeDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.Type))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.LotteryPrizeTypeDefine), this.Type);
            }
        }
    }
}
