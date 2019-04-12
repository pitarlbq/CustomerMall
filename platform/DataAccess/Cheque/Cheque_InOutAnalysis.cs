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
    /// This object represents the properties and methods of a Cheque_Buyer.
    /// </summary>
    public partial class Cheque_InOutAnalysis : EntityBaseReadOnly
    {
        [DatabaseColumn("Name")]
        public string Name { get; set; }
        [DatabaseColumn("TaxRate")]
        public decimal TaxRate { get; set; }
        [DatabaseColumn("TotalCount")]
        public int TotalCount { get; set; }
        [DatabaseColumn("TotalCost")]
        public decimal TotalCost { get; set; }
        [DatabaseColumn("TotalTaxCost")]
        public decimal TotalTaxCost { get; set; }
        [DatabaseColumn("TotalSumCost")]
        public decimal TotalSumCost { get; set; }
        #region Non-Public Methods
        /// <summary>
        /// This is called before an entity is saved to ensure that any parent entities keys are set properly
        /// </summary>
        protected override void EnsureParentProperties()
        {
        }
        #endregion
        public static Cheque_InOutAnalysis[] GetCheque_InOutAnalysisList(DateTime StartTime, DateTime EndTime, int KeyType)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdtext = string.Empty;
            string cmdwhere1 = string.Empty;
            if (StartTime > DateTime.MinValue)
            {
                cmdwhere1 += " and [ChequeTime]>=@StartTime";
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            var list = new Cheque_InOutAnalysis[] { };
            if (KeyType == 1)
            {
                string cmdtext1 = "(select DepartmentID,count(1) as TotalCount from [Cheque_InSummary] where 1=1 " + cmdwhere1 + " group by [DepartmentID]) as AA";
                string cmdtext2 = "(select DepartmentID,sum(TotalCost) as TotalCost from (select [Cheque_InSummary].[ChequeTime],[Cheque_InSummary].[DepartmentID], [Cheque_InDetail].* from [Cheque_InSummary] left join [Cheque_InDetail] on [Cheque_InDetail].[InSummaryID]=[Cheque_InSummary].[ID] where 1=1 " + cmdwhere1 + ")A where 1=1 " + cmdwhere1 + " group by A.[DepartmentID]) as BB";
                string cmdtext3 = "(select DepartmentID,sum(TotalTaxCost) as TotalTaxCost from (select [Cheque_InSummary].[ChequeTime],[Cheque_InSummary].[DepartmentID], [Cheque_InDetail].* from [Cheque_InSummary] left join [Cheque_InDetail] on [Cheque_InDetail].[InSummaryID]=[Cheque_InSummary].[ID] where 1=1 " + cmdwhere1 + ")A where 1=1 " + cmdwhere1 + " group by A.[DepartmentID]) as CC";
                string cmdtext4 = "(select DepartmentID,count(1) as TotalProductCount from (select [Cheque_InSummary].[ChequeTime],[Cheque_InSummary].[DepartmentID], [Cheque_InDetail].* from [Cheque_InSummary] left join [Cheque_InDetail] on [Cheque_InDetail].[InSummaryID]=[Cheque_InSummary].[ID] where 1=1 " + cmdwhere1 + ")A where 1=1 " + cmdwhere1 + " group by A.[DepartmentID]) as DD";
                string cmdtext5 = "(select DepartmentID,sum(CONVERT (decimal(18,2),TaxRate)) as TaxRate from (select [Cheque_InSummary].[ChequeTime],[Cheque_InSummary].[DepartmentID], [Cheque_InDetail].* from [Cheque_InSummary] left join [Cheque_InDetail] on [Cheque_InDetail].[InSummaryID]=[Cheque_InSummary].[ID] where 1=1 " + cmdwhere1 + ")A where 1=1 " + cmdwhere1 + " group by A.[DepartmentID]) as EE";
                string cmdtext6 = "(select [ID],[DepartmentName] from Cheque_Department UNION ALL select 0 as [ID],'无' as [DepartmentName]) as FF";
                cmdtext = "select FF.[DepartmentName] as Name,AA.TotalCount,BB.TotalCost,CC.TotalTaxCost,(BB.TotalCost+CC.TotalTaxCost) as TotalSumCost,(EE.TaxRate/DD.TotalProductCount) as TaxRate from " + cmdtext6 + " left join " + cmdtext1 + " on AA.DepartmentID=FF.ID left join " + cmdtext2 + " on BB.DepartmentID=FF.ID left join " + cmdtext3 + " on CC.DepartmentID=FF.ID left join " + cmdtext4 + " on DD.DepartmentID=FF.ID left join " + cmdtext5 + " on EE.DepartmentID=FF.ID";
            }
            else if (KeyType == 2)
            {
                string cmdtext1 = "(select ProjectID,count(1) as TotalCount from [Cheque_InSummary] where 1=1 " + cmdwhere1 + " group by [ProjectID]) as AA";
                string cmdtext2 = "(select ProjectID,sum(TotalCost) as TotalCost from (select [Cheque_InSummary].[ChequeTime],[Cheque_InSummary].[ProjectID], [Cheque_InDetail].* from [Cheque_InSummary] left join [Cheque_InDetail] on [Cheque_InDetail].[InSummaryID]=[Cheque_InSummary].[ID] where 1=1 " + cmdwhere1 + ")A where 1=1 " + cmdwhere1 + " group by A.[ProjectID]) as BB";
                string cmdtext3 = "(select ProjectID,sum(TotalTaxCost) as TotalTaxCost from (select [Cheque_InSummary].[ChequeTime],[Cheque_InSummary].[ProjectID], [Cheque_InDetail].* from [Cheque_InSummary] left join [Cheque_InDetail] on [Cheque_InDetail].[InSummaryID]=[Cheque_InSummary].[ID] where 1=1 " + cmdwhere1 + ")A where 1=1 " + cmdwhere1 + " group by A.[ProjectID]) as CC";
                string cmdtext4 = "(select ProjectID,count(1) as TotalProductCount from (select [Cheque_InSummary].[ChequeTime],[Cheque_InSummary].[ProjectID], [Cheque_InDetail].* from [Cheque_InSummary] left join [Cheque_InDetail] on [Cheque_InDetail].[InSummaryID]=[Cheque_InSummary].[ID] where 1=1 " + cmdwhere1 + ")A where 1=1 " + cmdwhere1 + " group by A.[ProjectID]) as DD";
                string cmdtext5 = "(select ProjectID,sum(CONVERT (decimal(18,2),TaxRate)) as TaxRate from (select [Cheque_InSummary].[ChequeTime],[Cheque_InSummary].[ProjectID], [Cheque_InDetail].* from [Cheque_InSummary] left join [Cheque_InDetail] on [Cheque_InDetail].[InSummaryID]=[Cheque_InSummary].[ID] where 1=1 " + cmdwhere1 + ")A where 1=1 " + cmdwhere1 + " group by A.[ProjectID]) as EE";
                string cmdtext6 = "(select [ID],[ProjectName] from Cheque_Project UNION ALL select 0 as [ID],'无' as [ProjectName]) as FF";
                cmdtext = "select FF.[ProjectName] as Name,AA.TotalCount,BB.TotalCost,CC.TotalTaxCost,(BB.TotalCost+CC.TotalTaxCost) as TotalSumCost,(EE.TaxRate/DD.TotalProductCount) as TaxRate from " + cmdtext6 + " left join " + cmdtext1 + " on AA.ProjectID=FF.ID left join " + cmdtext2 + " on BB.ProjectID=FF.ID left join " + cmdtext3 + " on CC.ProjectID=FF.ID left join " + cmdtext4 + " on DD.ProjectID=FF.ID left join " + cmdtext5 + " on EE.ProjectID=FF.ID";
            }
            else
            {
                return list;
            }
            list = GetList<Cheque_InOutAnalysis>(cmdtext, parameters).ToArray();
            return list;
        }
    }
}
