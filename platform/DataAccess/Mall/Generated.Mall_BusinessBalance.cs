using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.Script.Serialization;
using Foresight.DataAccess.Framework;


namespace Foresight.DataAccess
{
	/// <summary>
	/// This object represents the properties and methods of a Mall_BusinessBalance.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_BusinessBalance 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _iD = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, true, false)]
		public int ID
		{
			[DebuggerStepThrough()]
			get { return this._iD; }
			 set 
			{
				if (this._iD != value) 
				{
					this._iD = value;
					this.IsDirty = true;	
					OnPropertyChanged("ID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _balanceNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BalanceNumber
		{
			[DebuggerStepThrough()]
			get { return this._balanceNumber; }
			set 
			{
				if (this._balanceNumber != value) 
				{
					this._balanceNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("BalanceNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _businessID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int BusinessID
		{
			[DebuggerStepThrough()]
			get { return this._businessID; }
			set 
			{
				if (this._businessID != value) 
				{
					this._businessID = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _businessAccount = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BusinessAccount
		{
			[DebuggerStepThrough()]
			get { return this._businessAccount; }
			set 
			{
				if (this._businessAccount != value) 
				{
					this._businessAccount = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessAccount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _balanceRuleID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int BalanceRuleID
		{
			[DebuggerStepThrough()]
			get { return this._balanceRuleID; }
			set 
			{
				if (this._balanceRuleID != value) 
				{
					this._balanceRuleID = value;
					this.IsDirty = true;	
					OnPropertyChanged("BalanceRuleID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _balanceStatus = int.MinValue;
		/// <summary>
		/// 1-待结算 2-已结算 3-审核未通过
		/// </summary>
        [Description("1-待结算 2-已结算 3-审核未通过")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int BalanceStatus
		{
			[DebuggerStepThrough()]
			get { return this._balanceStatus; }
			set 
			{
				if (this._balanceStatus != value) 
				{
					this._balanceStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("BalanceStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _balanceAmount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal BalanceAmount
		{
			[DebuggerStepThrough()]
			get { return this._balanceAmount; }
			set 
			{
				if (this._balanceAmount != value) 
				{
					this._balanceAmount = value;
					this.IsDirty = true;	
					OnPropertyChanged("BalanceAmount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _addTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime AddTime
		{
			[DebuggerStepThrough()]
			get { return this._addTime; }
			set 
			{
				if (this._addTime != value) 
				{
					this._addTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addUserMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string AddUserMan
		{
			[DebuggerStepThrough()]
			get { return this._addUserMan; }
			set 
			{
				if (this._addUserMan != value) 
				{
					this._addUserMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUserMan");
				}
			}
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
			set 
			{
				if (this._approveTime != value) 
				{
					this._approveTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveUserMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveUserMan
		{
			[DebuggerStepThrough()]
			get { return this._approveUserMan; }
			set 
			{
				if (this._approveUserMan != value) 
				{
					this._approveUserMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveUserMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveRemark
		{
			[DebuggerStepThrough()]
			get { return this._approveRemark; }
			set 
			{
				if (this._approveRemark != value) 
				{
					this._approveRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveRemark");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _applicationTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ApplicationTime
		{
			[DebuggerStepThrough()]
			get { return this._applicationTime; }
			set 
			{
				if (this._applicationTime != value) 
				{
					this._applicationTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApplicationTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _applicationUserMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApplicationUserMan
		{
			[DebuggerStepThrough()]
			get { return this._applicationUserMan; }
			set 
			{
				if (this._applicationUserMan != value) 
				{
					this._applicationUserMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApplicationUserMan");
				}
			}
		}
		
		
		
		#endregion
		
		#region Non-Public Properties
		/// <summary>
		/// Gets the SQL statement for an insert
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override string InsertSqlStatement
		{
			[DebuggerStepThrough()]
			get 
			{
				return @"
DECLARE @table TABLE(
	[ID] int,
	[BalanceNumber] nvarchar(200),
	[BusinessID] int,
	[BusinessAccount] nvarchar(100),
	[BalanceRuleID] int,
	[BalanceStatus] int,
	[BalanceAmount] decimal(18, 2),
	[AddTime] datetime,
	[AddUserMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveUserMan] nvarchar(100),
	[ApproveRemark] ntext,
	[ApplicationTime] datetime,
	[ApplicationUserMan] nvarchar(200)
);

INSERT INTO [dbo].[Mall_BusinessBalance] (
	[Mall_BusinessBalance].[BalanceNumber],
	[Mall_BusinessBalance].[BusinessID],
	[Mall_BusinessBalance].[BusinessAccount],
	[Mall_BusinessBalance].[BalanceRuleID],
	[Mall_BusinessBalance].[BalanceStatus],
	[Mall_BusinessBalance].[BalanceAmount],
	[Mall_BusinessBalance].[AddTime],
	[Mall_BusinessBalance].[AddUserMan],
	[Mall_BusinessBalance].[ApproveTime],
	[Mall_BusinessBalance].[ApproveUserMan],
	[Mall_BusinessBalance].[ApproveRemark],
	[Mall_BusinessBalance].[ApplicationTime],
	[Mall_BusinessBalance].[ApplicationUserMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[BalanceNumber],
	INSERTED.[BusinessID],
	INSERTED.[BusinessAccount],
	INSERTED.[BalanceRuleID],
	INSERTED.[BalanceStatus],
	INSERTED.[BalanceAmount],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveUserMan],
	INSERTED.[ApproveRemark],
	INSERTED.[ApplicationTime],
	INSERTED.[ApplicationUserMan]
into @table
VALUES ( 
	@BalanceNumber,
	@BusinessID,
	@BusinessAccount,
	@BalanceRuleID,
	@BalanceStatus,
	@BalanceAmount,
	@AddTime,
	@AddUserMan,
	@ApproveTime,
	@ApproveUserMan,
	@ApproveRemark,
	@ApplicationTime,
	@ApplicationUserMan 
); 

SELECT 
	[ID],
	[BalanceNumber],
	[BusinessID],
	[BusinessAccount],
	[BalanceRuleID],
	[BalanceStatus],
	[BalanceAmount],
	[AddTime],
	[AddUserMan],
	[ApproveTime],
	[ApproveUserMan],
	[ApproveRemark],
	[ApplicationTime],
	[ApplicationUserMan] 
FROM @table;
";
			}
		}
		
		/// <summary>
		/// Gets the SQL statement for an update by key
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override string UpdateSqlStatement
		{
			[DebuggerStepThrough()]
			get
			{
				return @"
DECLARE @table TABLE(
	[ID] int,
	[BalanceNumber] nvarchar(200),
	[BusinessID] int,
	[BusinessAccount] nvarchar(100),
	[BalanceRuleID] int,
	[BalanceStatus] int,
	[BalanceAmount] decimal(18, 2),
	[AddTime] datetime,
	[AddUserMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveUserMan] nvarchar(100),
	[ApproveRemark] ntext,
	[ApplicationTime] datetime,
	[ApplicationUserMan] nvarchar(200)
);

UPDATE [dbo].[Mall_BusinessBalance] SET 
	[Mall_BusinessBalance].[BalanceNumber] = @BalanceNumber,
	[Mall_BusinessBalance].[BusinessID] = @BusinessID,
	[Mall_BusinessBalance].[BusinessAccount] = @BusinessAccount,
	[Mall_BusinessBalance].[BalanceRuleID] = @BalanceRuleID,
	[Mall_BusinessBalance].[BalanceStatus] = @BalanceStatus,
	[Mall_BusinessBalance].[BalanceAmount] = @BalanceAmount,
	[Mall_BusinessBalance].[AddTime] = @AddTime,
	[Mall_BusinessBalance].[AddUserMan] = @AddUserMan,
	[Mall_BusinessBalance].[ApproveTime] = @ApproveTime,
	[Mall_BusinessBalance].[ApproveUserMan] = @ApproveUserMan,
	[Mall_BusinessBalance].[ApproveRemark] = @ApproveRemark,
	[Mall_BusinessBalance].[ApplicationTime] = @ApplicationTime,
	[Mall_BusinessBalance].[ApplicationUserMan] = @ApplicationUserMan 
output 
	INSERTED.[ID],
	INSERTED.[BalanceNumber],
	INSERTED.[BusinessID],
	INSERTED.[BusinessAccount],
	INSERTED.[BalanceRuleID],
	INSERTED.[BalanceStatus],
	INSERTED.[BalanceAmount],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveUserMan],
	INSERTED.[ApproveRemark],
	INSERTED.[ApplicationTime],
	INSERTED.[ApplicationUserMan]
into @table
WHERE 
	[Mall_BusinessBalance].[ID] = @ID

SELECT 
	[ID],
	[BalanceNumber],
	[BusinessID],
	[BusinessAccount],
	[BalanceRuleID],
	[BalanceStatus],
	[BalanceAmount],
	[AddTime],
	[AddUserMan],
	[ApproveTime],
	[ApproveUserMan],
	[ApproveRemark],
	[ApplicationTime],
	[ApplicationUserMan] 
FROM @table;
";
			}
		}
		
		/// <summary>
		/// Gets the SQL statement for a delete by key
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override string DeleteSqlStatement
		{
			[DebuggerStepThrough()]
			get
			{
				return @"
DELETE FROM [dbo].[Mall_BusinessBalance]
WHERE 
	[Mall_BusinessBalance].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_BusinessBalance() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_BusinessBalance(this.ID));
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
	[Mall_BusinessBalance].[ID],
	[Mall_BusinessBalance].[BalanceNumber],
	[Mall_BusinessBalance].[BusinessID],
	[Mall_BusinessBalance].[BusinessAccount],
	[Mall_BusinessBalance].[BalanceRuleID],
	[Mall_BusinessBalance].[BalanceStatus],
	[Mall_BusinessBalance].[BalanceAmount],
	[Mall_BusinessBalance].[AddTime],
	[Mall_BusinessBalance].[AddUserMan],
	[Mall_BusinessBalance].[ApproveTime],
	[Mall_BusinessBalance].[ApproveUserMan],
	[Mall_BusinessBalance].[ApproveRemark],
	[Mall_BusinessBalance].[ApplicationTime],
	[Mall_BusinessBalance].[ApplicationUserMan]
";
			}
		}
		
		
		/// <summary>
        /// Table Name
        /// </summary>
        public new static string TableName
        {
            get
            {
                return "Mall_BusinessBalance";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_BusinessBalance into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="balanceNumber">balanceNumber</param>
		/// <param name="businessID">businessID</param>
		/// <param name="businessAccount">businessAccount</param>
		/// <param name="balanceRuleID">balanceRuleID</param>
		/// <param name="balanceStatus">balanceStatus</param>
		/// <param name="balanceAmount">balanceAmount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveUserMan">approveUserMan</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="applicationTime">applicationTime</param>
		/// <param name="applicationUserMan">applicationUserMan</param>
		public static void InsertMall_BusinessBalance(string @balanceNumber, int @businessID, string @businessAccount, int @balanceRuleID, int @balanceStatus, decimal @balanceAmount, DateTime @addTime, string @addUserMan, DateTime @approveTime, string @approveUserMan, string @approveRemark, DateTime @applicationTime, string @applicationUserMan)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_BusinessBalance(@balanceNumber, @businessID, @businessAccount, @balanceRuleID, @balanceStatus, @balanceAmount, @addTime, @addUserMan, @approveTime, @approveUserMan, @approveRemark, @applicationTime, @applicationUserMan, helper);
                    helper.Commit();
                }
                catch
                {
                    helper.Rollback();
                    throw;
                }
            }
		}

		/// <summary>
		/// Insert a Mall_BusinessBalance into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="balanceNumber">balanceNumber</param>
		/// <param name="businessID">businessID</param>
		/// <param name="businessAccount">businessAccount</param>
		/// <param name="balanceRuleID">balanceRuleID</param>
		/// <param name="balanceStatus">balanceStatus</param>
		/// <param name="balanceAmount">balanceAmount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveUserMan">approveUserMan</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="applicationTime">applicationTime</param>
		/// <param name="applicationUserMan">applicationUserMan</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_BusinessBalance(string @balanceNumber, int @businessID, string @businessAccount, int @balanceRuleID, int @balanceStatus, decimal @balanceAmount, DateTime @addTime, string @addUserMan, DateTime @approveTime, string @approveUserMan, string @approveRemark, DateTime @applicationTime, string @applicationUserMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BalanceNumber] nvarchar(200),
	[BusinessID] int,
	[BusinessAccount] nvarchar(100),
	[BalanceRuleID] int,
	[BalanceStatus] int,
	[BalanceAmount] decimal(18, 2),
	[AddTime] datetime,
	[AddUserMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveUserMan] nvarchar(100),
	[ApproveRemark] ntext,
	[ApplicationTime] datetime,
	[ApplicationUserMan] nvarchar(200)
);

INSERT INTO [dbo].[Mall_BusinessBalance] (
	[Mall_BusinessBalance].[BalanceNumber],
	[Mall_BusinessBalance].[BusinessID],
	[Mall_BusinessBalance].[BusinessAccount],
	[Mall_BusinessBalance].[BalanceRuleID],
	[Mall_BusinessBalance].[BalanceStatus],
	[Mall_BusinessBalance].[BalanceAmount],
	[Mall_BusinessBalance].[AddTime],
	[Mall_BusinessBalance].[AddUserMan],
	[Mall_BusinessBalance].[ApproveTime],
	[Mall_BusinessBalance].[ApproveUserMan],
	[Mall_BusinessBalance].[ApproveRemark],
	[Mall_BusinessBalance].[ApplicationTime],
	[Mall_BusinessBalance].[ApplicationUserMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[BalanceNumber],
	INSERTED.[BusinessID],
	INSERTED.[BusinessAccount],
	INSERTED.[BalanceRuleID],
	INSERTED.[BalanceStatus],
	INSERTED.[BalanceAmount],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveUserMan],
	INSERTED.[ApproveRemark],
	INSERTED.[ApplicationTime],
	INSERTED.[ApplicationUserMan]
into @table
VALUES ( 
	@BalanceNumber,
	@BusinessID,
	@BusinessAccount,
	@BalanceRuleID,
	@BalanceStatus,
	@BalanceAmount,
	@AddTime,
	@AddUserMan,
	@ApproveTime,
	@ApproveUserMan,
	@ApproveRemark,
	@ApplicationTime,
	@ApplicationUserMan 
); 

SELECT 
	[ID],
	[BalanceNumber],
	[BusinessID],
	[BusinessAccount],
	[BalanceRuleID],
	[BalanceStatus],
	[BalanceAmount],
	[AddTime],
	[AddUserMan],
	[ApproveTime],
	[ApproveUserMan],
	[ApproveRemark],
	[ApplicationTime],
	[ApplicationUserMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@BalanceNumber", EntityBase.GetDatabaseValue(@balanceNumber)));
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			parameters.Add(new SqlParameter("@BusinessAccount", EntityBase.GetDatabaseValue(@businessAccount)));
			parameters.Add(new SqlParameter("@BalanceRuleID", EntityBase.GetDatabaseValue(@balanceRuleID)));
			parameters.Add(new SqlParameter("@BalanceStatus", EntityBase.GetDatabaseValue(@balanceStatus)));
			parameters.Add(new SqlParameter("@BalanceAmount", EntityBase.GetDatabaseValue(@balanceAmount)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserMan", EntityBase.GetDatabaseValue(@addUserMan)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveUserMan", EntityBase.GetDatabaseValue(@approveUserMan)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@ApplicationTime", EntityBase.GetDatabaseValue(@applicationTime)));
			parameters.Add(new SqlParameter("@ApplicationUserMan", EntityBase.GetDatabaseValue(@applicationUserMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_BusinessBalance into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="balanceNumber">balanceNumber</param>
		/// <param name="businessID">businessID</param>
		/// <param name="businessAccount">businessAccount</param>
		/// <param name="balanceRuleID">balanceRuleID</param>
		/// <param name="balanceStatus">balanceStatus</param>
		/// <param name="balanceAmount">balanceAmount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveUserMan">approveUserMan</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="applicationTime">applicationTime</param>
		/// <param name="applicationUserMan">applicationUserMan</param>
		public static void UpdateMall_BusinessBalance(int @iD, string @balanceNumber, int @businessID, string @businessAccount, int @balanceRuleID, int @balanceStatus, decimal @balanceAmount, DateTime @addTime, string @addUserMan, DateTime @approveTime, string @approveUserMan, string @approveRemark, DateTime @applicationTime, string @applicationUserMan)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_BusinessBalance(@iD, @balanceNumber, @businessID, @businessAccount, @balanceRuleID, @balanceStatus, @balanceAmount, @addTime, @addUserMan, @approveTime, @approveUserMan, @approveRemark, @applicationTime, @applicationUserMan, helper);
					helper.Commit();
				}
				catch 
				{
					helper.Rollback();	
					throw;
				}
			}
		}
		
		/// <summary>
		/// Updates a Mall_BusinessBalance into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="balanceNumber">balanceNumber</param>
		/// <param name="businessID">businessID</param>
		/// <param name="businessAccount">businessAccount</param>
		/// <param name="balanceRuleID">balanceRuleID</param>
		/// <param name="balanceStatus">balanceStatus</param>
		/// <param name="balanceAmount">balanceAmount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveUserMan">approveUserMan</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="applicationTime">applicationTime</param>
		/// <param name="applicationUserMan">applicationUserMan</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_BusinessBalance(int @iD, string @balanceNumber, int @businessID, string @businessAccount, int @balanceRuleID, int @balanceStatus, decimal @balanceAmount, DateTime @addTime, string @addUserMan, DateTime @approveTime, string @approveUserMan, string @approveRemark, DateTime @applicationTime, string @applicationUserMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BalanceNumber] nvarchar(200),
	[BusinessID] int,
	[BusinessAccount] nvarchar(100),
	[BalanceRuleID] int,
	[BalanceStatus] int,
	[BalanceAmount] decimal(18, 2),
	[AddTime] datetime,
	[AddUserMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveUserMan] nvarchar(100),
	[ApproveRemark] ntext,
	[ApplicationTime] datetime,
	[ApplicationUserMan] nvarchar(200)
);

UPDATE [dbo].[Mall_BusinessBalance] SET 
	[Mall_BusinessBalance].[BalanceNumber] = @BalanceNumber,
	[Mall_BusinessBalance].[BusinessID] = @BusinessID,
	[Mall_BusinessBalance].[BusinessAccount] = @BusinessAccount,
	[Mall_BusinessBalance].[BalanceRuleID] = @BalanceRuleID,
	[Mall_BusinessBalance].[BalanceStatus] = @BalanceStatus,
	[Mall_BusinessBalance].[BalanceAmount] = @BalanceAmount,
	[Mall_BusinessBalance].[AddTime] = @AddTime,
	[Mall_BusinessBalance].[AddUserMan] = @AddUserMan,
	[Mall_BusinessBalance].[ApproveTime] = @ApproveTime,
	[Mall_BusinessBalance].[ApproveUserMan] = @ApproveUserMan,
	[Mall_BusinessBalance].[ApproveRemark] = @ApproveRemark,
	[Mall_BusinessBalance].[ApplicationTime] = @ApplicationTime,
	[Mall_BusinessBalance].[ApplicationUserMan] = @ApplicationUserMan 
output 
	INSERTED.[ID],
	INSERTED.[BalanceNumber],
	INSERTED.[BusinessID],
	INSERTED.[BusinessAccount],
	INSERTED.[BalanceRuleID],
	INSERTED.[BalanceStatus],
	INSERTED.[BalanceAmount],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveUserMan],
	INSERTED.[ApproveRemark],
	INSERTED.[ApplicationTime],
	INSERTED.[ApplicationUserMan]
into @table
WHERE 
	[Mall_BusinessBalance].[ID] = @ID

SELECT 
	[ID],
	[BalanceNumber],
	[BusinessID],
	[BusinessAccount],
	[BalanceRuleID],
	[BalanceStatus],
	[BalanceAmount],
	[AddTime],
	[AddUserMan],
	[ApproveTime],
	[ApproveUserMan],
	[ApproveRemark],
	[ApplicationTime],
	[ApplicationUserMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@BalanceNumber", EntityBase.GetDatabaseValue(@balanceNumber)));
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			parameters.Add(new SqlParameter("@BusinessAccount", EntityBase.GetDatabaseValue(@businessAccount)));
			parameters.Add(new SqlParameter("@BalanceRuleID", EntityBase.GetDatabaseValue(@balanceRuleID)));
			parameters.Add(new SqlParameter("@BalanceStatus", EntityBase.GetDatabaseValue(@balanceStatus)));
			parameters.Add(new SqlParameter("@BalanceAmount", EntityBase.GetDatabaseValue(@balanceAmount)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserMan", EntityBase.GetDatabaseValue(@addUserMan)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveUserMan", EntityBase.GetDatabaseValue(@approveUserMan)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@ApplicationTime", EntityBase.GetDatabaseValue(@applicationTime)));
			parameters.Add(new SqlParameter("@ApplicationUserMan", EntityBase.GetDatabaseValue(@applicationUserMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_BusinessBalance from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_BusinessBalance(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_BusinessBalance(@iD, helper);
					helper.Commit();
				} 
				catch 
				{
					helper.Rollback();
					throw;
				}
			}
		}
		
		/// <summary>
		/// Deletes a Mall_BusinessBalance from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_BusinessBalance(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_BusinessBalance]
WHERE 
	[Mall_BusinessBalance].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_BusinessBalance object.
		/// </summary>
		/// <returns>The newly created Mall_BusinessBalance object.</returns>
		public static Mall_BusinessBalance CreateMall_BusinessBalance()
		{
			return InitializeNew<Mall_BusinessBalance>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_BusinessBalance by a Mall_BusinessBalance's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_BusinessBalance</returns>
		public static Mall_BusinessBalance GetMall_BusinessBalance(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_BusinessBalance.SelectFieldList + @"
FROM [dbo].[Mall_BusinessBalance] 
WHERE 
	[Mall_BusinessBalance].[ID] = @ID " + Mall_BusinessBalance.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_BusinessBalance>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_BusinessBalance by a Mall_BusinessBalance's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_BusinessBalance</returns>
		public static Mall_BusinessBalance GetMall_BusinessBalance(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_BusinessBalance.SelectFieldList + @"
FROM [dbo].[Mall_BusinessBalance] 
WHERE 
	[Mall_BusinessBalance].[ID] = @ID " + Mall_BusinessBalance.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_BusinessBalance>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessBalance objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_BusinessBalance objects.</returns>
		public static EntityList<Mall_BusinessBalance> GetMall_BusinessBalances()
		{
			string commandText = @"
SELECT " + Mall_BusinessBalance.SelectFieldList + "FROM [dbo].[Mall_BusinessBalance] " + Mall_BusinessBalance.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_BusinessBalance>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_BusinessBalance objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_BusinessBalance objects.</returns>
        public static EntityList<Mall_BusinessBalance> GetMall_BusinessBalances(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_BusinessBalance>(SelectFieldList, "FROM [dbo].[Mall_BusinessBalance]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_BusinessBalance objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_BusinessBalance objects.</returns>
        public static EntityList<Mall_BusinessBalance> GetMall_BusinessBalances(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_BusinessBalance>(SelectFieldList, "FROM [dbo].[Mall_BusinessBalance]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_BusinessBalance objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_BusinessBalance objects.</returns>
		protected static EntityList<Mall_BusinessBalance> GetMall_BusinessBalances(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_BusinessBalances(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessBalance objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_BusinessBalance objects.</returns>
		protected static EntityList<Mall_BusinessBalance> GetMall_BusinessBalances(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_BusinessBalances(string.Empty, where, parameters, Mall_BusinessBalance.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessBalance objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_BusinessBalance objects.</returns>
		protected static EntityList<Mall_BusinessBalance> GetMall_BusinessBalances(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_BusinessBalances(prefix, where, parameters, Mall_BusinessBalance.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessBalance objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_BusinessBalance objects.</returns>
		protected static EntityList<Mall_BusinessBalance> GetMall_BusinessBalances(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_BusinessBalances(string.Empty, where, parameters, Mall_BusinessBalance.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessBalance objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_BusinessBalance objects.</returns>
		protected static EntityList<Mall_BusinessBalance> GetMall_BusinessBalances(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_BusinessBalances(prefix, where, parameters, Mall_BusinessBalance.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessBalance objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_BusinessBalance objects.</returns>
		protected static EntityList<Mall_BusinessBalance> GetMall_BusinessBalances(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_BusinessBalance.SelectFieldList + "FROM [dbo].[Mall_BusinessBalance] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_BusinessBalance>(reader);
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
        protected static EntityList<Mall_BusinessBalance> GetMall_BusinessBalances(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_BusinessBalance>(SelectFieldList, "FROM [dbo].[Mall_BusinessBalance] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_BusinessBalance objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_BusinessBalanceCount()
        {
            return GetMall_BusinessBalanceCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_BusinessBalance objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_BusinessBalanceCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_BusinessBalance] " + where;

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
		#endregion
		
		#region Subclasses
		public static partial class Mall_BusinessBalance_Properties
		{
			public const string ID = "ID";
			public const string BalanceNumber = "BalanceNumber";
			public const string BusinessID = "BusinessID";
			public const string BusinessAccount = "BusinessAccount";
			public const string BalanceRuleID = "BalanceRuleID";
			public const string BalanceStatus = "BalanceStatus";
			public const string BalanceAmount = "BalanceAmount";
			public const string AddTime = "AddTime";
			public const string AddUserMan = "AddUserMan";
			public const string ApproveTime = "ApproveTime";
			public const string ApproveUserMan = "ApproveUserMan";
			public const string ApproveRemark = "ApproveRemark";
			public const string ApplicationTime = "ApplicationTime";
			public const string ApplicationUserMan = "ApplicationUserMan";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"BalanceNumber" , "string:"},
    			 {"BusinessID" , "int:"},
    			 {"BusinessAccount" , "string:"},
    			 {"BalanceRuleID" , "int:"},
    			 {"BalanceStatus" , "int:1-待结算 2-已结算 3-审核未通过"},
    			 {"BalanceAmount" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserMan" , "string:"},
    			 {"ApproveTime" , "DateTime:"},
    			 {"ApproveUserMan" , "string:"},
    			 {"ApproveRemark" , "string:"},
    			 {"ApplicationTime" , "DateTime:"},
    			 {"ApplicationUserMan" , "string:"},
            };
		}
		#endregion
	}
}
