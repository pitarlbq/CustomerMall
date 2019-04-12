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
    /// This object represents the properties and methods of a ViewWechatLotteryActivityRecord.
    /// </summary>
    public partial class ViewWechatLotteryActivityRecord : EntityBaseReadOnly
    {
        public Utility.EnumModel.LotteryPrizeTypeDefine PrizeType
        {
            get { return (Utility.EnumModel.LotteryPrizeTypeDefine)Enum.Parse(typeof(Utility.EnumModel.LotteryPrizeTypeDefine), this.Type); }
        }
        public static Ui.DataGrid GetViewWechatLotteryActivityRecordList(string keywords, bool? completeSend, int activityID, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            conditions.Add("[PrizeID]>0");
            if (!string.IsNullOrEmpty(keywords))
            {
                parameters.Add(new SqlParameter("@Keywords", "%" + keywords + "%"));
                conditions.Add("([NickName] like @Keywords or [LevelName] like @Keywords)");
            }
            if (completeSend != null && completeSend.HasValue)
            {
                if (completeSend.Value)
                {
                    conditions.Add("[CompleteSend]=1");
                }
                else
                {
                    conditions.Add("ISNULL([CompleteSend],0)=0");
                }
            }
            if (activityID > 0)
            {
                parameters.Add(new SqlParameter("@ActivityID", activityID));
                conditions.Add("[ActivityID]=@ActivityID");
            }
            var list = GetList<ViewWechatLotteryActivityRecord>("*", "from " + ViewName + " where " + string.Join(" and ", conditions.ToArray()), parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static ViewWechatLotteryActivityRecord[] GetViewWechatLotteryActivityRecordByOpenID(string OpenID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();

            parameters.Add(new SqlParameter("@OpenID", OpenID));
            conditions.Add("[OpenID]=@OpenID");

            return GetList<ViewWechatLotteryActivityRecord>("select * from " + ViewName + " where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static ViewWechatLotteryActivityRecord GetViewWechatLotteryActivityRecord(int RecordID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();

            parameters.Add(new SqlParameter("@ID", RecordID));
            conditions.Add("[ID]=@ID");

            return GetOne<ViewWechatLotteryActivityRecord>("select * from " + ViewName + " where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
    }
}
