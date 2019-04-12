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
    /// This object represents the properties and methods of a Contract_ModifyLog.
    /// </summary>
    public partial class Contract_ModifyLog : EntityBase
    {
        public static Contract_ModifyLog[] GetListByContractID(int ContractID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ContractID", ContractID));
            return GetList<Contract_ModifyLog>("select [ModifyMan],[ModifyTime],[Guid],[ModifyType],[ModifyTypeDesc] from [Contract_ModifyLog] where ContractID=@ContractID group by [ModifyMan],[ModifyTime],[Guid],[ModifyType],[ModifyTypeDesc] order by [ModifyTime] desc", parameters).ToArray();
        }
        public static Contract_ModifyLog[] GetListByGuid(string Guid)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Guid", Guid));
            return GetList<Contract_ModifyLog>("select * from [Contract_ModifyLog] where Guid=@Guid", parameters).ToArray();
        }
        public static Ui.DataGrid GetContract_ModifyLogGrid(int ContractID, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ContractID]=@ContractID");
            parameters.Add(new SqlParameter("@ContractID", ContractID));
            string fieldList = "[Contract_ModifyLog].*";
            string Statement = " from [Contract_ModifyLog] where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Contract_ModifyLog>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string ModifyTimeDesc
        {
            get
            {
                return this.ModifyTime > DateTime.MinValue ? this.ModifyTime.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;
            }
        }
        public string ModifyTypeDefineDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.ModifyType))
                {
                    return this.ModifyTypeDesc;
                }
                return Utility.EnumHelper.GetDescription<Utility.EnumModel.ContractModifyLogDefine>(this.ModifyType);
            }
        }
        public string ModifyDefineContent
        {
            get
            {
                string desc = string.Empty;
                if (!string.IsNullOrEmpty(this.ModifyTitle))
                {
                    desc += this.ModifyTitle + ": ";
                }
                if (!string.IsNullOrEmpty(this.OldValue) && !string.IsNullOrEmpty(this.NewValue))
                {
                    desc += "从 " + this.OldValue + " 变更为 " + this.NewValue;
                }
                else
                {
                    desc += this.ModifyTypeDefineDesc;
                }
                return desc;
            }
        }
    }
}
