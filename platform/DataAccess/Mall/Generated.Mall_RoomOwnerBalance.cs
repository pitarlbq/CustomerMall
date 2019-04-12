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
	/// This object represents the properties and methods of a Mall_RoomOwnerBalance.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_RoomOwnerBalance 
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
		private int _userID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int UserID
		{
			[DebuggerStepThrough()]
			get { return this._userID; }
			set 
			{
				if (this._userID != value) 
				{
					this._userID = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _userAccount = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string UserAccount
		{
			[DebuggerStepThrough()]
			get { return this._userAccount; }
			set 
			{
				if (this._userAccount != value) 
				{
					this._userAccount = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserAccount");
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
		private decimal _totalCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal TotalCost
		{
			[DebuggerStepThrough()]
			get { return this._totalCost; }
			set 
			{
				if (this._totalCost != value) 
				{
					this._totalCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _roomPhoneRelationID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RoomPhoneRelationID
		{
			[DebuggerStepThrough()]
			get { return this._roomPhoneRelationID; }
			set 
			{
				if (this._roomPhoneRelationID != value) 
				{
					this._roomPhoneRelationID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomPhoneRelationID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _memberLevel = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string MemberLevel
		{
			[DebuggerStepThrough()]
			get { return this._memberLevel; }
			set 
			{
				if (this._memberLevel != value) 
				{
					this._memberLevel = value;
					this.IsDirty = true;	
					OnPropertyChanged("MemberLevel");
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
			set 
			{
				if (this._projectID != value) 
				{
					this._projectID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectID");
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
	[UserID] int,
	[UserAccount] nvarchar(100),
	[BalanceRuleID] int,
	[BalanceStatus] int,
	[BalanceAmount] decimal(18, 2),
	[AddTime] datetime,
	[AddUserMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveUserMan] nvarchar(100),
	[ApproveRemark] ntext,
	[TotalCost] decimal(18, 2),
	[RoomPhoneRelationID] int,
	[MemberLevel] nvarchar(200),
	[ApplicationTime] datetime,
	[ApplicationUserMan] nvarchar(200),
	[ProjectID] int
);

INSERT INTO [dbo].[Mall_RoomOwnerBalance] (
	[Mall_RoomOwnerBalance].[BalanceNumber],
	[Mall_RoomOwnerBalance].[UserID],
	[Mall_RoomOwnerBalance].[UserAccount],
	[Mall_RoomOwnerBalance].[BalanceRuleID],
	[Mall_RoomOwnerBalance].[BalanceStatus],
	[Mall_RoomOwnerBalance].[BalanceAmount],
	[Mall_RoomOwnerBalance].[AddTime],
	[Mall_RoomOwnerBalance].[AddUserMan],
	[Mall_RoomOwnerBalance].[ApproveTime],
	[Mall_RoomOwnerBalance].[ApproveUserMan],
	[Mall_RoomOwnerBalance].[ApproveRemark],
	[Mall_RoomOwnerBalance].[TotalCost],
	[Mall_RoomOwnerBalance].[RoomPhoneRelationID],
	[Mall_RoomOwnerBalance].[MemberLevel],
	[Mall_RoomOwnerBalance].[ApplicationTime],
	[Mall_RoomOwnerBalance].[ApplicationUserMan],
	[Mall_RoomOwnerBalance].[ProjectID]
) 
output 
	INSERTED.[ID],
	INSERTED.[BalanceNumber],
	INSERTED.[UserID],
	INSERTED.[UserAccount],
	INSERTED.[BalanceRuleID],
	INSERTED.[BalanceStatus],
	INSERTED.[BalanceAmount],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveUserMan],
	INSERTED.[ApproveRemark],
	INSERTED.[TotalCost],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[MemberLevel],
	INSERTED.[ApplicationTime],
	INSERTED.[ApplicationUserMan],
	INSERTED.[ProjectID]
into @table
VALUES ( 
	@BalanceNumber,
	@UserID,
	@UserAccount,
	@BalanceRuleID,
	@BalanceStatus,
	@BalanceAmount,
	@AddTime,
	@AddUserMan,
	@ApproveTime,
	@ApproveUserMan,
	@ApproveRemark,
	@TotalCost,
	@RoomPhoneRelationID,
	@MemberLevel,
	@ApplicationTime,
	@ApplicationUserMan,
	@ProjectID 
); 

SELECT 
	[ID],
	[BalanceNumber],
	[UserID],
	[UserAccount],
	[BalanceRuleID],
	[BalanceStatus],
	[BalanceAmount],
	[AddTime],
	[AddUserMan],
	[ApproveTime],
	[ApproveUserMan],
	[ApproveRemark],
	[TotalCost],
	[RoomPhoneRelationID],
	[MemberLevel],
	[ApplicationTime],
	[ApplicationUserMan],
	[ProjectID] 
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
	[UserID] int,
	[UserAccount] nvarchar(100),
	[BalanceRuleID] int,
	[BalanceStatus] int,
	[BalanceAmount] decimal(18, 2),
	[AddTime] datetime,
	[AddUserMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveUserMan] nvarchar(100),
	[ApproveRemark] ntext,
	[TotalCost] decimal(18, 2),
	[RoomPhoneRelationID] int,
	[MemberLevel] nvarchar(200),
	[ApplicationTime] datetime,
	[ApplicationUserMan] nvarchar(200),
	[ProjectID] int
);

UPDATE [dbo].[Mall_RoomOwnerBalance] SET 
	[Mall_RoomOwnerBalance].[BalanceNumber] = @BalanceNumber,
	[Mall_RoomOwnerBalance].[UserID] = @UserID,
	[Mall_RoomOwnerBalance].[UserAccount] = @UserAccount,
	[Mall_RoomOwnerBalance].[BalanceRuleID] = @BalanceRuleID,
	[Mall_RoomOwnerBalance].[BalanceStatus] = @BalanceStatus,
	[Mall_RoomOwnerBalance].[BalanceAmount] = @BalanceAmount,
	[Mall_RoomOwnerBalance].[AddTime] = @AddTime,
	[Mall_RoomOwnerBalance].[AddUserMan] = @AddUserMan,
	[Mall_RoomOwnerBalance].[ApproveTime] = @ApproveTime,
	[Mall_RoomOwnerBalance].[ApproveUserMan] = @ApproveUserMan,
	[Mall_RoomOwnerBalance].[ApproveRemark] = @ApproveRemark,
	[Mall_RoomOwnerBalance].[TotalCost] = @TotalCost,
	[Mall_RoomOwnerBalance].[RoomPhoneRelationID] = @RoomPhoneRelationID,
	[Mall_RoomOwnerBalance].[MemberLevel] = @MemberLevel,
	[Mall_RoomOwnerBalance].[ApplicationTime] = @ApplicationTime,
	[Mall_RoomOwnerBalance].[ApplicationUserMan] = @ApplicationUserMan,
	[Mall_RoomOwnerBalance].[ProjectID] = @ProjectID 
output 
	INSERTED.[ID],
	INSERTED.[BalanceNumber],
	INSERTED.[UserID],
	INSERTED.[UserAccount],
	INSERTED.[BalanceRuleID],
	INSERTED.[BalanceStatus],
	INSERTED.[BalanceAmount],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveUserMan],
	INSERTED.[ApproveRemark],
	INSERTED.[TotalCost],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[MemberLevel],
	INSERTED.[ApplicationTime],
	INSERTED.[ApplicationUserMan],
	INSERTED.[ProjectID]
into @table
WHERE 
	[Mall_RoomOwnerBalance].[ID] = @ID

SELECT 
	[ID],
	[BalanceNumber],
	[UserID],
	[UserAccount],
	[BalanceRuleID],
	[BalanceStatus],
	[BalanceAmount],
	[AddTime],
	[AddUserMan],
	[ApproveTime],
	[ApproveUserMan],
	[ApproveRemark],
	[TotalCost],
	[RoomPhoneRelationID],
	[MemberLevel],
	[ApplicationTime],
	[ApplicationUserMan],
	[ProjectID] 
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
DELETE FROM [dbo].[Mall_RoomOwnerBalance]
WHERE 
	[Mall_RoomOwnerBalance].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_RoomOwnerBalance() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_RoomOwnerBalance(this.ID));
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
	[Mall_RoomOwnerBalance].[ID],
	[Mall_RoomOwnerBalance].[BalanceNumber],
	[Mall_RoomOwnerBalance].[UserID],
	[Mall_RoomOwnerBalance].[UserAccount],
	[Mall_RoomOwnerBalance].[BalanceRuleID],
	[Mall_RoomOwnerBalance].[BalanceStatus],
	[Mall_RoomOwnerBalance].[BalanceAmount],
	[Mall_RoomOwnerBalance].[AddTime],
	[Mall_RoomOwnerBalance].[AddUserMan],
	[Mall_RoomOwnerBalance].[ApproveTime],
	[Mall_RoomOwnerBalance].[ApproveUserMan],
	[Mall_RoomOwnerBalance].[ApproveRemark],
	[Mall_RoomOwnerBalance].[TotalCost],
	[Mall_RoomOwnerBalance].[RoomPhoneRelationID],
	[Mall_RoomOwnerBalance].[MemberLevel],
	[Mall_RoomOwnerBalance].[ApplicationTime],
	[Mall_RoomOwnerBalance].[ApplicationUserMan],
	[Mall_RoomOwnerBalance].[ProjectID]
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
                return "Mall_RoomOwnerBalance";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_RoomOwnerBalance into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="balanceNumber">balanceNumber</param>
		/// <param name="userID">userID</param>
		/// <param name="userAccount">userAccount</param>
		/// <param name="balanceRuleID">balanceRuleID</param>
		/// <param name="balanceStatus">balanceStatus</param>
		/// <param name="balanceAmount">balanceAmount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveUserMan">approveUserMan</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="memberLevel">memberLevel</param>
		/// <param name="applicationTime">applicationTime</param>
		/// <param name="applicationUserMan">applicationUserMan</param>
		/// <param name="projectID">projectID</param>
		public static void InsertMall_RoomOwnerBalance(string @balanceNumber, int @userID, string @userAccount, int @balanceRuleID, int @balanceStatus, decimal @balanceAmount, DateTime @addTime, string @addUserMan, DateTime @approveTime, string @approveUserMan, string @approveRemark, decimal @totalCost, int @roomPhoneRelationID, string @memberLevel, DateTime @applicationTime, string @applicationUserMan, int @projectID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_RoomOwnerBalance(@balanceNumber, @userID, @userAccount, @balanceRuleID, @balanceStatus, @balanceAmount, @addTime, @addUserMan, @approveTime, @approveUserMan, @approveRemark, @totalCost, @roomPhoneRelationID, @memberLevel, @applicationTime, @applicationUserMan, @projectID, helper);
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
		/// Insert a Mall_RoomOwnerBalance into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="balanceNumber">balanceNumber</param>
		/// <param name="userID">userID</param>
		/// <param name="userAccount">userAccount</param>
		/// <param name="balanceRuleID">balanceRuleID</param>
		/// <param name="balanceStatus">balanceStatus</param>
		/// <param name="balanceAmount">balanceAmount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveUserMan">approveUserMan</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="memberLevel">memberLevel</param>
		/// <param name="applicationTime">applicationTime</param>
		/// <param name="applicationUserMan">applicationUserMan</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_RoomOwnerBalance(string @balanceNumber, int @userID, string @userAccount, int @balanceRuleID, int @balanceStatus, decimal @balanceAmount, DateTime @addTime, string @addUserMan, DateTime @approveTime, string @approveUserMan, string @approveRemark, decimal @totalCost, int @roomPhoneRelationID, string @memberLevel, DateTime @applicationTime, string @applicationUserMan, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BalanceNumber] nvarchar(200),
	[UserID] int,
	[UserAccount] nvarchar(100),
	[BalanceRuleID] int,
	[BalanceStatus] int,
	[BalanceAmount] decimal(18, 2),
	[AddTime] datetime,
	[AddUserMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveUserMan] nvarchar(100),
	[ApproveRemark] ntext,
	[TotalCost] decimal(18, 2),
	[RoomPhoneRelationID] int,
	[MemberLevel] nvarchar(200),
	[ApplicationTime] datetime,
	[ApplicationUserMan] nvarchar(200),
	[ProjectID] int
);

INSERT INTO [dbo].[Mall_RoomOwnerBalance] (
	[Mall_RoomOwnerBalance].[BalanceNumber],
	[Mall_RoomOwnerBalance].[UserID],
	[Mall_RoomOwnerBalance].[UserAccount],
	[Mall_RoomOwnerBalance].[BalanceRuleID],
	[Mall_RoomOwnerBalance].[BalanceStatus],
	[Mall_RoomOwnerBalance].[BalanceAmount],
	[Mall_RoomOwnerBalance].[AddTime],
	[Mall_RoomOwnerBalance].[AddUserMan],
	[Mall_RoomOwnerBalance].[ApproveTime],
	[Mall_RoomOwnerBalance].[ApproveUserMan],
	[Mall_RoomOwnerBalance].[ApproveRemark],
	[Mall_RoomOwnerBalance].[TotalCost],
	[Mall_RoomOwnerBalance].[RoomPhoneRelationID],
	[Mall_RoomOwnerBalance].[MemberLevel],
	[Mall_RoomOwnerBalance].[ApplicationTime],
	[Mall_RoomOwnerBalance].[ApplicationUserMan],
	[Mall_RoomOwnerBalance].[ProjectID]
) 
output 
	INSERTED.[ID],
	INSERTED.[BalanceNumber],
	INSERTED.[UserID],
	INSERTED.[UserAccount],
	INSERTED.[BalanceRuleID],
	INSERTED.[BalanceStatus],
	INSERTED.[BalanceAmount],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveUserMan],
	INSERTED.[ApproveRemark],
	INSERTED.[TotalCost],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[MemberLevel],
	INSERTED.[ApplicationTime],
	INSERTED.[ApplicationUserMan],
	INSERTED.[ProjectID]
into @table
VALUES ( 
	@BalanceNumber,
	@UserID,
	@UserAccount,
	@BalanceRuleID,
	@BalanceStatus,
	@BalanceAmount,
	@AddTime,
	@AddUserMan,
	@ApproveTime,
	@ApproveUserMan,
	@ApproveRemark,
	@TotalCost,
	@RoomPhoneRelationID,
	@MemberLevel,
	@ApplicationTime,
	@ApplicationUserMan,
	@ProjectID 
); 

SELECT 
	[ID],
	[BalanceNumber],
	[UserID],
	[UserAccount],
	[BalanceRuleID],
	[BalanceStatus],
	[BalanceAmount],
	[AddTime],
	[AddUserMan],
	[ApproveTime],
	[ApproveUserMan],
	[ApproveRemark],
	[TotalCost],
	[RoomPhoneRelationID],
	[MemberLevel],
	[ApplicationTime],
	[ApplicationUserMan],
	[ProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@BalanceNumber", EntityBase.GetDatabaseValue(@balanceNumber)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@UserAccount", EntityBase.GetDatabaseValue(@userAccount)));
			parameters.Add(new SqlParameter("@BalanceRuleID", EntityBase.GetDatabaseValue(@balanceRuleID)));
			parameters.Add(new SqlParameter("@BalanceStatus", EntityBase.GetDatabaseValue(@balanceStatus)));
			parameters.Add(new SqlParameter("@BalanceAmount", EntityBase.GetDatabaseValue(@balanceAmount)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserMan", EntityBase.GetDatabaseValue(@addUserMan)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveUserMan", EntityBase.GetDatabaseValue(@approveUserMan)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@TotalCost", EntityBase.GetDatabaseValue(@totalCost)));
			parameters.Add(new SqlParameter("@RoomPhoneRelationID", EntityBase.GetDatabaseValue(@roomPhoneRelationID)));
			parameters.Add(new SqlParameter("@MemberLevel", EntityBase.GetDatabaseValue(@memberLevel)));
			parameters.Add(new SqlParameter("@ApplicationTime", EntityBase.GetDatabaseValue(@applicationTime)));
			parameters.Add(new SqlParameter("@ApplicationUserMan", EntityBase.GetDatabaseValue(@applicationUserMan)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_RoomOwnerBalance into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="balanceNumber">balanceNumber</param>
		/// <param name="userID">userID</param>
		/// <param name="userAccount">userAccount</param>
		/// <param name="balanceRuleID">balanceRuleID</param>
		/// <param name="balanceStatus">balanceStatus</param>
		/// <param name="balanceAmount">balanceAmount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveUserMan">approveUserMan</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="memberLevel">memberLevel</param>
		/// <param name="applicationTime">applicationTime</param>
		/// <param name="applicationUserMan">applicationUserMan</param>
		/// <param name="projectID">projectID</param>
		public static void UpdateMall_RoomOwnerBalance(int @iD, string @balanceNumber, int @userID, string @userAccount, int @balanceRuleID, int @balanceStatus, decimal @balanceAmount, DateTime @addTime, string @addUserMan, DateTime @approveTime, string @approveUserMan, string @approveRemark, decimal @totalCost, int @roomPhoneRelationID, string @memberLevel, DateTime @applicationTime, string @applicationUserMan, int @projectID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_RoomOwnerBalance(@iD, @balanceNumber, @userID, @userAccount, @balanceRuleID, @balanceStatus, @balanceAmount, @addTime, @addUserMan, @approveTime, @approveUserMan, @approveRemark, @totalCost, @roomPhoneRelationID, @memberLevel, @applicationTime, @applicationUserMan, @projectID, helper);
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
		/// Updates a Mall_RoomOwnerBalance into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="balanceNumber">balanceNumber</param>
		/// <param name="userID">userID</param>
		/// <param name="userAccount">userAccount</param>
		/// <param name="balanceRuleID">balanceRuleID</param>
		/// <param name="balanceStatus">balanceStatus</param>
		/// <param name="balanceAmount">balanceAmount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveUserMan">approveUserMan</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="memberLevel">memberLevel</param>
		/// <param name="applicationTime">applicationTime</param>
		/// <param name="applicationUserMan">applicationUserMan</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_RoomOwnerBalance(int @iD, string @balanceNumber, int @userID, string @userAccount, int @balanceRuleID, int @balanceStatus, decimal @balanceAmount, DateTime @addTime, string @addUserMan, DateTime @approveTime, string @approveUserMan, string @approveRemark, decimal @totalCost, int @roomPhoneRelationID, string @memberLevel, DateTime @applicationTime, string @applicationUserMan, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BalanceNumber] nvarchar(200),
	[UserID] int,
	[UserAccount] nvarchar(100),
	[BalanceRuleID] int,
	[BalanceStatus] int,
	[BalanceAmount] decimal(18, 2),
	[AddTime] datetime,
	[AddUserMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveUserMan] nvarchar(100),
	[ApproveRemark] ntext,
	[TotalCost] decimal(18, 2),
	[RoomPhoneRelationID] int,
	[MemberLevel] nvarchar(200),
	[ApplicationTime] datetime,
	[ApplicationUserMan] nvarchar(200),
	[ProjectID] int
);

UPDATE [dbo].[Mall_RoomOwnerBalance] SET 
	[Mall_RoomOwnerBalance].[BalanceNumber] = @BalanceNumber,
	[Mall_RoomOwnerBalance].[UserID] = @UserID,
	[Mall_RoomOwnerBalance].[UserAccount] = @UserAccount,
	[Mall_RoomOwnerBalance].[BalanceRuleID] = @BalanceRuleID,
	[Mall_RoomOwnerBalance].[BalanceStatus] = @BalanceStatus,
	[Mall_RoomOwnerBalance].[BalanceAmount] = @BalanceAmount,
	[Mall_RoomOwnerBalance].[AddTime] = @AddTime,
	[Mall_RoomOwnerBalance].[AddUserMan] = @AddUserMan,
	[Mall_RoomOwnerBalance].[ApproveTime] = @ApproveTime,
	[Mall_RoomOwnerBalance].[ApproveUserMan] = @ApproveUserMan,
	[Mall_RoomOwnerBalance].[ApproveRemark] = @ApproveRemark,
	[Mall_RoomOwnerBalance].[TotalCost] = @TotalCost,
	[Mall_RoomOwnerBalance].[RoomPhoneRelationID] = @RoomPhoneRelationID,
	[Mall_RoomOwnerBalance].[MemberLevel] = @MemberLevel,
	[Mall_RoomOwnerBalance].[ApplicationTime] = @ApplicationTime,
	[Mall_RoomOwnerBalance].[ApplicationUserMan] = @ApplicationUserMan,
	[Mall_RoomOwnerBalance].[ProjectID] = @ProjectID 
output 
	INSERTED.[ID],
	INSERTED.[BalanceNumber],
	INSERTED.[UserID],
	INSERTED.[UserAccount],
	INSERTED.[BalanceRuleID],
	INSERTED.[BalanceStatus],
	INSERTED.[BalanceAmount],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveUserMan],
	INSERTED.[ApproveRemark],
	INSERTED.[TotalCost],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[MemberLevel],
	INSERTED.[ApplicationTime],
	INSERTED.[ApplicationUserMan],
	INSERTED.[ProjectID]
into @table
WHERE 
	[Mall_RoomOwnerBalance].[ID] = @ID

SELECT 
	[ID],
	[BalanceNumber],
	[UserID],
	[UserAccount],
	[BalanceRuleID],
	[BalanceStatus],
	[BalanceAmount],
	[AddTime],
	[AddUserMan],
	[ApproveTime],
	[ApproveUserMan],
	[ApproveRemark],
	[TotalCost],
	[RoomPhoneRelationID],
	[MemberLevel],
	[ApplicationTime],
	[ApplicationUserMan],
	[ProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@BalanceNumber", EntityBase.GetDatabaseValue(@balanceNumber)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@UserAccount", EntityBase.GetDatabaseValue(@userAccount)));
			parameters.Add(new SqlParameter("@BalanceRuleID", EntityBase.GetDatabaseValue(@balanceRuleID)));
			parameters.Add(new SqlParameter("@BalanceStatus", EntityBase.GetDatabaseValue(@balanceStatus)));
			parameters.Add(new SqlParameter("@BalanceAmount", EntityBase.GetDatabaseValue(@balanceAmount)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserMan", EntityBase.GetDatabaseValue(@addUserMan)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveUserMan", EntityBase.GetDatabaseValue(@approveUserMan)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@TotalCost", EntityBase.GetDatabaseValue(@totalCost)));
			parameters.Add(new SqlParameter("@RoomPhoneRelationID", EntityBase.GetDatabaseValue(@roomPhoneRelationID)));
			parameters.Add(new SqlParameter("@MemberLevel", EntityBase.GetDatabaseValue(@memberLevel)));
			parameters.Add(new SqlParameter("@ApplicationTime", EntityBase.GetDatabaseValue(@applicationTime)));
			parameters.Add(new SqlParameter("@ApplicationUserMan", EntityBase.GetDatabaseValue(@applicationUserMan)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_RoomOwnerBalance from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_RoomOwnerBalance(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_RoomOwnerBalance(@iD, helper);
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
		/// Deletes a Mall_RoomOwnerBalance from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_RoomOwnerBalance(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_RoomOwnerBalance]
WHERE 
	[Mall_RoomOwnerBalance].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_RoomOwnerBalance object.
		/// </summary>
		/// <returns>The newly created Mall_RoomOwnerBalance object.</returns>
		public static Mall_RoomOwnerBalance CreateMall_RoomOwnerBalance()
		{
			return InitializeNew<Mall_RoomOwnerBalance>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_RoomOwnerBalance by a Mall_RoomOwnerBalance's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_RoomOwnerBalance</returns>
		public static Mall_RoomOwnerBalance GetMall_RoomOwnerBalance(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_RoomOwnerBalance.SelectFieldList + @"
FROM [dbo].[Mall_RoomOwnerBalance] 
WHERE 
	[Mall_RoomOwnerBalance].[ID] = @ID " + Mall_RoomOwnerBalance.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_RoomOwnerBalance>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_RoomOwnerBalance by a Mall_RoomOwnerBalance's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_RoomOwnerBalance</returns>
		public static Mall_RoomOwnerBalance GetMall_RoomOwnerBalance(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_RoomOwnerBalance.SelectFieldList + @"
FROM [dbo].[Mall_RoomOwnerBalance] 
WHERE 
	[Mall_RoomOwnerBalance].[ID] = @ID " + Mall_RoomOwnerBalance.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_RoomOwnerBalance>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_RoomOwnerBalance objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_RoomOwnerBalance objects.</returns>
		public static EntityList<Mall_RoomOwnerBalance> GetMall_RoomOwnerBalances()
		{
			string commandText = @"
SELECT " + Mall_RoomOwnerBalance.SelectFieldList + "FROM [dbo].[Mall_RoomOwnerBalance] " + Mall_RoomOwnerBalance.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_RoomOwnerBalance>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_RoomOwnerBalance objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_RoomOwnerBalance objects.</returns>
        public static EntityList<Mall_RoomOwnerBalance> GetMall_RoomOwnerBalances(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_RoomOwnerBalance>(SelectFieldList, "FROM [dbo].[Mall_RoomOwnerBalance]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_RoomOwnerBalance objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_RoomOwnerBalance objects.</returns>
        public static EntityList<Mall_RoomOwnerBalance> GetMall_RoomOwnerBalances(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_RoomOwnerBalance>(SelectFieldList, "FROM [dbo].[Mall_RoomOwnerBalance]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_RoomOwnerBalance objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_RoomOwnerBalance objects.</returns>
		protected static EntityList<Mall_RoomOwnerBalance> GetMall_RoomOwnerBalances(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_RoomOwnerBalances(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_RoomOwnerBalance objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_RoomOwnerBalance objects.</returns>
		protected static EntityList<Mall_RoomOwnerBalance> GetMall_RoomOwnerBalances(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_RoomOwnerBalances(string.Empty, where, parameters, Mall_RoomOwnerBalance.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_RoomOwnerBalance objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_RoomOwnerBalance objects.</returns>
		protected static EntityList<Mall_RoomOwnerBalance> GetMall_RoomOwnerBalances(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_RoomOwnerBalances(prefix, where, parameters, Mall_RoomOwnerBalance.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_RoomOwnerBalance objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_RoomOwnerBalance objects.</returns>
		protected static EntityList<Mall_RoomOwnerBalance> GetMall_RoomOwnerBalances(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_RoomOwnerBalances(string.Empty, where, parameters, Mall_RoomOwnerBalance.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_RoomOwnerBalance objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_RoomOwnerBalance objects.</returns>
		protected static EntityList<Mall_RoomOwnerBalance> GetMall_RoomOwnerBalances(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_RoomOwnerBalances(prefix, where, parameters, Mall_RoomOwnerBalance.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_RoomOwnerBalance objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_RoomOwnerBalance objects.</returns>
		protected static EntityList<Mall_RoomOwnerBalance> GetMall_RoomOwnerBalances(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_RoomOwnerBalance.SelectFieldList + "FROM [dbo].[Mall_RoomOwnerBalance] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_RoomOwnerBalance>(reader);
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
        protected static EntityList<Mall_RoomOwnerBalance> GetMall_RoomOwnerBalances(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_RoomOwnerBalance>(SelectFieldList, "FROM [dbo].[Mall_RoomOwnerBalance] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_RoomOwnerBalance objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_RoomOwnerBalanceCount()
        {
            return GetMall_RoomOwnerBalanceCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_RoomOwnerBalance objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_RoomOwnerBalanceCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_RoomOwnerBalance] " + where;

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
		public static partial class Mall_RoomOwnerBalance_Properties
		{
			public const string ID = "ID";
			public const string BalanceNumber = "BalanceNumber";
			public const string UserID = "UserID";
			public const string UserAccount = "UserAccount";
			public const string BalanceRuleID = "BalanceRuleID";
			public const string BalanceStatus = "BalanceStatus";
			public const string BalanceAmount = "BalanceAmount";
			public const string AddTime = "AddTime";
			public const string AddUserMan = "AddUserMan";
			public const string ApproveTime = "ApproveTime";
			public const string ApproveUserMan = "ApproveUserMan";
			public const string ApproveRemark = "ApproveRemark";
			public const string TotalCost = "TotalCost";
			public const string RoomPhoneRelationID = "RoomPhoneRelationID";
			public const string MemberLevel = "MemberLevel";
			public const string ApplicationTime = "ApplicationTime";
			public const string ApplicationUserMan = "ApplicationUserMan";
			public const string ProjectID = "ProjectID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"BalanceNumber" , "string:"},
    			 {"UserID" , "int:"},
    			 {"UserAccount" , "string:"},
    			 {"BalanceRuleID" , "int:"},
    			 {"BalanceStatus" , "int:1-待结算 2-已结算 3-审核未通过"},
    			 {"BalanceAmount" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserMan" , "string:"},
    			 {"ApproveTime" , "DateTime:"},
    			 {"ApproveUserMan" , "string:"},
    			 {"ApproveRemark" , "string:"},
    			 {"TotalCost" , "decimal:"},
    			 {"RoomPhoneRelationID" , "int:"},
    			 {"MemberLevel" , "string:"},
    			 {"ApplicationTime" , "DateTime:"},
    			 {"ApplicationUserMan" , "string:"},
    			 {"ProjectID" , "int:"},
            };
		}
		#endregion
	}
}
