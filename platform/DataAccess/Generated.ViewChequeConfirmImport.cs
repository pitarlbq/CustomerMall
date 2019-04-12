using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Foresight.DataAccess.Framework;


namespace Foresight.DataAccess
{
	/// <summary>
	/// This object represents the properties and methods of a ViewChequeConfirmImport.
	/// </summary>
	[Serializable()]
	public partial class ViewChequeConfirmImport 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _inSummaryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int InSummaryID
		{
			[DebuggerStepThrough()]
			get { return this._inSummaryID; }
            protected set { this._inSummaryID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _writeDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime WriteDate
		{
			[DebuggerStepThrough()]
			get { return this._writeDate; }
            protected set { this._writeDate = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _writeMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string WriteMan
		{
			[DebuggerStepThrough()]
			get { return this._writeMan; }
            protected set { this._writeMan = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _departmentID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int DepartmentID
		{
			[DebuggerStepThrough()]
			get { return this._departmentID; }
            protected set { this._departmentID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _projectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProjectID
		{
			[DebuggerStepThrough()]
			get { return this._projectID; }
            protected set { this._projectID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _sellerID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SellerID
		{
			[DebuggerStepThrough()]
			get { return this._sellerID; }
            protected set { this._sellerID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chequeNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChequeNumber
		{
			[DebuggerStepThrough()]
			get { return this._chequeNumber; }
            protected set { this._chequeNumber = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _chequeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ChequeTime
		{
			[DebuggerStepThrough()]
			get { return this._chequeTime; }
            protected set { this._chequeTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _buyerID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int BuyerID
		{
			[DebuggerStepThrough()]
			get { return this._buyerID; }
            protected set { this._buyerID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chequeCode = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChequeCode
		{
			[DebuggerStepThrough()]
			get { return this._chequeCode; }
            protected set { this._chequeCode = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _iD = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ID
		{
			[DebuggerStepThrough()]
			get { return this._iD; }
            protected set { this._iD = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _summaryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SummaryID
		{
			[DebuggerStepThrough()]
			get { return this._summaryID; }
            protected set { this._summaryID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _takeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime TakeTime
		{
			[DebuggerStepThrough()]
			get { return this._takeTime; }
            protected set { this._takeTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _takeUser = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TakeUser
		{
			[DebuggerStepThrough()]
			get { return this._takeUser; }
            protected set { this._takeUser = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _takeStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TakeStatus
		{
			[DebuggerStepThrough()]
			get { return this._takeStatus; }
            protected set { this._takeStatus = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _takeRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TakeRemark
		{
			[DebuggerStepThrough()]
			get { return this._takeRemark; }
            protected set { this._takeRemark = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _approveTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ApproveTime
		{
			[DebuggerStepThrough()]
			get { return this._approveTime; }
            protected set { this._approveTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveMan
		{
			[DebuggerStepThrough()]
			get { return this._approveMan; }
            protected set { this._approveMan = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _approveStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ApproveStatus
		{
			[DebuggerStepThrough()]
			get { return this._approveStatus; }
            protected set { this._approveStatus = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _checkApproveRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CheckApproveRemark
		{
			[DebuggerStepThrough()]
			get { return this._checkApproveRemark; }
            protected set { this._checkApproveRemark = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveMethod = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveMethod
		{
			[DebuggerStepThrough()]
			get { return this._approveMethod; }
            protected set { this._approveMethod = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveMonth = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveMonth
		{
			[DebuggerStepThrough()]
			get { return this._approveMonth; }
            protected set { this._approveMonth = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _transferTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime TransferTime
		{
			[DebuggerStepThrough()]
			get { return this._transferTime; }
            protected set { this._transferTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _transferMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TransferMan
		{
			[DebuggerStepThrough()]
			get { return this._transferMan; }
            protected set { this._transferMan = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _transferRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TransferRemark
		{
			[DebuggerStepThrough()]
			get { return this._transferRemark; }
            protected set { this._transferRemark = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _transferStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TransferStatus
		{
			[DebuggerStepThrough()]
			get { return this._transferStatus; }
            protected set { this._transferStatus = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _transferMoney = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TransferMoney
		{
			[DebuggerStepThrough()]
			get { return this._transferMoney; }
            protected set { this._transferMoney = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _addTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime AddTime
		{
			[DebuggerStepThrough()]
			get { return this._addTime; }
            protected set { this._addTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _departmentName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DepartmentName
		{
			[DebuggerStepThrough()]
			get { return this._departmentName; }
            protected set { this._departmentName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _projectName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProjectName
		{
			[DebuggerStepThrough()]
			get { return this._projectName; }
            protected set { this._projectName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sellerName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SellerName
		{
			[DebuggerStepThrough()]
			get { return this._sellerName; }
            protected set { this._sellerName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sellerTaxNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SellerTaxNumber
		{
			[DebuggerStepThrough()]
			get { return this._sellerTaxNumber; }
            protected set { this._sellerTaxNumber = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sellerAddressPhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SellerAddressPhone
		{
			[DebuggerStepThrough()]
			get { return this._sellerAddressPhone; }
            protected set { this._sellerAddressPhone = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sellerBankAccount = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SellerBankAccount
		{
			[DebuggerStepThrough()]
			get { return this._sellerBankAccount; }
            protected set { this._sellerBankAccount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sellerSocialCreditCode = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SellerSocialCreditCode
		{
			[DebuggerStepThrough()]
			get { return this._sellerSocialCreditCode; }
            protected set { this._sellerSocialCreditCode = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewChequeConfirmImport() { }
		#endregion
		
		#region Static Properties
		/// <summary>
		/// A list of all fields for this entity in the database. It does not include the 
		/// select keyword, or the table information - just the fields. This can be used
		/// for new dynamic methods.
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static string SelectFieldList 
		{
			get 
			{
				return @"
	[ViewChequeConfirmImport].[InSummaryID],
	[ViewChequeConfirmImport].[WriteDate],
	[ViewChequeConfirmImport].[WriteMan],
	[ViewChequeConfirmImport].[DepartmentID],
	[ViewChequeConfirmImport].[ProjectID],
	[ViewChequeConfirmImport].[SellerID],
	[ViewChequeConfirmImport].[ChequeNumber],
	[ViewChequeConfirmImport].[ChequeTime],
	[ViewChequeConfirmImport].[BuyerID],
	[ViewChequeConfirmImport].[ChequeCode],
	[ViewChequeConfirmImport].[ID],
	[ViewChequeConfirmImport].[SummaryID],
	[ViewChequeConfirmImport].[TakeTime],
	[ViewChequeConfirmImport].[TakeUser],
	[ViewChequeConfirmImport].[TakeStatus],
	[ViewChequeConfirmImport].[TakeRemark],
	[ViewChequeConfirmImport].[ApproveTime],
	[ViewChequeConfirmImport].[ApproveMan],
	[ViewChequeConfirmImport].[ApproveStatus],
	[ViewChequeConfirmImport].[CheckApproveRemark],
	[ViewChequeConfirmImport].[ApproveMethod],
	[ViewChequeConfirmImport].[ApproveMonth],
	[ViewChequeConfirmImport].[TransferTime],
	[ViewChequeConfirmImport].[TransferMan],
	[ViewChequeConfirmImport].[TransferRemark],
	[ViewChequeConfirmImport].[TransferStatus],
	[ViewChequeConfirmImport].[TransferMoney],
	[ViewChequeConfirmImport].[AddTime],
	[ViewChequeConfirmImport].[DepartmentName],
	[ViewChequeConfirmImport].[ProjectName],
	[ViewChequeConfirmImport].[SellerName],
	[ViewChequeConfirmImport].[SellerTaxNumber],
	[ViewChequeConfirmImport].[SellerAddressPhone],
	[ViewChequeConfirmImport].[SellerBankAccount],
	[ViewChequeConfirmImport].[SellerSocialCreditCode]
";
			}
		}
		
		
		/// <summary>
        /// View Name
        /// </summary>
        public static string ViewName
        {
            get
            {
                return "ViewChequeConfirmImport";
            }
        }

		#endregion
        
		#region Non-Public Methods
		/// <summary>
		/// This is called before an entity is saved to ensure that any parent entities keys are set properly
		/// </summary>
		protected override void EnsureParentProperties()
		{
			
		}
		#endregion
		
		#region Static Methods
				
		/// <summary>
		/// Gets a collection ViewChequeConfirmImport objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewChequeConfirmImport objects.</returns>
		public static EntityList<ViewChequeConfirmImport> GetViewChequeConfirmImports()
		{
			string commandText = @"
SELECT " + ViewChequeConfirmImport.SelectFieldList + "FROM [dbo].[ViewChequeConfirmImport] " + ViewChequeConfirmImport.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewChequeConfirmImport>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewChequeConfirmImport objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewChequeConfirmImport objects.</returns>
        public static EntityList<ViewChequeConfirmImport> GetViewChequeConfirmImports(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewChequeConfirmImport>(SelectFieldList, "FROM [dbo].[ViewChequeConfirmImport]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewChequeConfirmImport objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewChequeConfirmImport objects.</returns>
        public static EntityList<ViewChequeConfirmImport> GetViewChequeConfirmImports(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewChequeConfirmImport>(SelectFieldList, "FROM [dbo].[ViewChequeConfirmImport]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewChequeConfirmImport objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewChequeConfirmImportCount()
        {
            return GetViewChequeConfirmImportCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewChequeConfirmImport objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewChequeConfirmImportCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewChequeConfirmImport] " + where;

            using (SqlHelper helper = new SqlHelper())
            {
                var obj = helper.ExecuteScalar(commandText, CommandType.Text, parameters);
                if (obj != null && obj != DBNull.Value)
                {
                    return Convert.ToInt64(obj);
                }
            }
            return 0;
        }
		
		/// <summary>
		/// Gets a collection ViewChequeConfirmImport objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewChequeConfirmImport objects.</returns>
		protected static EntityList<ViewChequeConfirmImport> GetViewChequeConfirmImports(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewChequeConfirmImports(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewChequeConfirmImport objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewChequeConfirmImport objects.</returns>
		protected static EntityList<ViewChequeConfirmImport> GetViewChequeConfirmImports(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewChequeConfirmImports(string.Empty, where, parameters, ViewChequeConfirmImport.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewChequeConfirmImport objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewChequeConfirmImport objects.</returns>
		protected static EntityList<ViewChequeConfirmImport> GetViewChequeConfirmImports(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewChequeConfirmImports(prefix, where, parameters, ViewChequeConfirmImport.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewChequeConfirmImport objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewChequeConfirmImport objects.</returns>
		protected static EntityList<ViewChequeConfirmImport> GetViewChequeConfirmImports(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewChequeConfirmImports(string.Empty, where, parameters, ViewChequeConfirmImport.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewChequeConfirmImport objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewChequeConfirmImport objects.</returns>
		protected static EntityList<ViewChequeConfirmImport> GetViewChequeConfirmImports(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewChequeConfirmImports(prefix, where, parameters, ViewChequeConfirmImport.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewChequeConfirmImport objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewChequeConfirmImport objects.</returns>
		protected static EntityList<ViewChequeConfirmImport> GetViewChequeConfirmImports(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewChequeConfirmImport.SelectFieldList + "FROM [dbo].[ViewChequeConfirmImport] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewChequeConfirmImport>(reader);
				}
			}
		}		
		
		/// <summary>
        /// Gets a collection Address objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="where">where</param>
		/// <param name=parameters">parameters</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Address objects.</returns>
        protected static EntityList<ViewChequeConfirmImport> GetViewChequeConfirmImports(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewChequeConfirmImport>(SelectFieldList, "FROM [dbo].[ViewChequeConfirmImport] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewChequeConfirmImportProperties
		{
			public const string InSummaryID = "InSummaryID";
			public const string WriteDate = "WriteDate";
			public const string WriteMan = "WriteMan";
			public const string DepartmentID = "DepartmentID";
			public const string ProjectID = "ProjectID";
			public const string SellerID = "SellerID";
			public const string ChequeNumber = "ChequeNumber";
			public const string ChequeTime = "ChequeTime";
			public const string BuyerID = "BuyerID";
			public const string ChequeCode = "ChequeCode";
			public const string ID = "ID";
			public const string SummaryID = "SummaryID";
			public const string TakeTime = "TakeTime";
			public const string TakeUser = "TakeUser";
			public const string TakeStatus = "TakeStatus";
			public const string TakeRemark = "TakeRemark";
			public const string ApproveTime = "ApproveTime";
			public const string ApproveMan = "ApproveMan";
			public const string ApproveStatus = "ApproveStatus";
			public const string CheckApproveRemark = "CheckApproveRemark";
			public const string ApproveMethod = "ApproveMethod";
			public const string ApproveMonth = "ApproveMonth";
			public const string TransferTime = "TransferTime";
			public const string TransferMan = "TransferMan";
			public const string TransferRemark = "TransferRemark";
			public const string TransferStatus = "TransferStatus";
			public const string TransferMoney = "TransferMoney";
			public const string AddTime = "AddTime";
			public const string DepartmentName = "DepartmentName";
			public const string ProjectName = "ProjectName";
			public const string SellerName = "SellerName";
			public const string SellerTaxNumber = "SellerTaxNumber";
			public const string SellerAddressPhone = "SellerAddressPhone";
			public const string SellerBankAccount = "SellerBankAccount";
			public const string SellerSocialCreditCode = "SellerSocialCreditCode";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"InSummaryID" , "int:"},
    			 {"WriteDate" , "DateTime:"},
    			 {"WriteMan" , "string:"},
    			 {"DepartmentID" , "int:"},
    			 {"ProjectID" , "int:"},
    			 {"SellerID" , "int:"},
    			 {"ChequeNumber" , "string:"},
    			 {"ChequeTime" , "DateTime:"},
    			 {"BuyerID" , "int:"},
    			 {"ChequeCode" , "string:"},
    			 {"ID" , "int:"},
    			 {"SummaryID" , "int:"},
    			 {"TakeTime" , "DateTime:"},
    			 {"TakeUser" , "string:"},
    			 {"TakeStatus" , "int:"},
    			 {"TakeRemark" , "string:"},
    			 {"ApproveTime" , "DateTime:"},
    			 {"ApproveMan" , "string:"},
    			 {"ApproveStatus" , "int:"},
    			 {"CheckApproveRemark" , "string:"},
    			 {"ApproveMethod" , "string:"},
    			 {"ApproveMonth" , "string:"},
    			 {"TransferTime" , "DateTime:"},
    			 {"TransferMan" , "string:"},
    			 {"TransferRemark" , "string:"},
    			 {"TransferStatus" , "int:"},
    			 {"TransferMoney" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"DepartmentName" , "string:"},
    			 {"ProjectName" , "string:"},
    			 {"SellerName" , "string:"},
    			 {"SellerTaxNumber" , "string:"},
    			 {"SellerAddressPhone" , "string:"},
    			 {"SellerBankAccount" , "string:"},
    			 {"SellerSocialCreditCode" , "string:"},
            };
		}
		#endregion
	}
}
