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
    /// This object represents the properties and methods of a Wechat_LotteryActivity.
    /// </summary>
    public partial class Wechat_LotteryActivity : EntityBase
    {
        public Utility.EnumModel.LotteryTypeDefine LotteryType
        {
            get { return Utility.EnumHelper.ParseEnum<Utility.EnumModel.LotteryTypeDefine>(this.Type); }
            set { this.Type = value.ToString(); }
        }

        public Utility.EnumModel.LotteryConsumeTypeDefine LotteryConsumeType
        {
            get { return Utility.EnumHelper.ParseEnum<Utility.EnumModel.LotteryConsumeTypeDefine>(this.ConsumeType); }
            set { this.ConsumeType = value.ToString(); }
        }

        public Utility.EnumModel.LotteryRepeatDefine LotteryRepeat
        {
            get { return Utility.EnumHelper.ParseEnum<Utility.EnumModel.LotteryRepeatDefine>(this.Repeat); }
            set { this.Repeat = value.ToString(); }
        }
        public static Ui.DataGrid GetWechat_LotteryActivityGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([ActivityName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[Wechat_LotteryActivity].* ";
            string Statement = " from [Wechat_LotteryActivity] where  " + string.Join(" and ", conditions.ToArray());
            Wechat_LotteryActivity[] list = GetList<Wechat_LotteryActivity>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string TypeDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.Type))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.LotteryTypeDefine), this.Type);
            }
        }
        public string RepeatDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.Repeat))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.LotteryRepeatDefine), this.Repeat);
            }
        }
        public string UserLimitDesc
        {
            get
            {
                return this.UserLimit ? "是" : "否";
            }
        }
    }
}
