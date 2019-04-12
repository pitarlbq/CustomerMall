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
	/// This object represents the properties and methods of a Mall_UserLevelApprove.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_UserLevelApprove 
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
		private string _requestTitle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RequestTitle
		{
			[DebuggerStepThrough()]
			get { return this._requestTitle; }
			set 
			{
				if (this._requestTitle != value) 
				{
					this._requestTitle = value;
					this.IsDirty = true;	
					OnPropertyChanged("RequestTitle");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _requestTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime RequestTime
		{
			[DebuggerStepThrough()]
			get { return this._requestTime; }
			set 
			{
				if (this._requestTime != value) 
				{
					this._requestTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("RequestTime");
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
		[DataObjectField(false, false, false)]
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
		private int _approveStatus = int.MinValue;
		/// <summary>
		/// 0-待审核 1-通过 2-未通过 3-待申请
		/// </summary>
        [Description("0-待审核 1-通过 2-未通过 3-待申请")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ApproveStatus
		{
			[DebuggerStepThrough()]
			get { return this._approveStatus; }
			set 
			{
				if (this._approveStatus != value) 
				{
					this._approveStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveStatus");
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
		private string _approveUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string ApproveUserName
		{
			[DebuggerStepThrough()]
			get { return this._approveUserName; }
			set 
			{
				if (this._approveUserName != value) 
				{
					this._approveUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveUserName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _approveUserLevelID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ApproveUserLevelID
		{
			[DebuggerStepThrough()]
			get { return this._approveUserLevelID; }
			set 
			{
				if (this._approveUserLevelID != value) 
				{
					this._approveUserLevelID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveUserLevelID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddUserName
		{
			[DebuggerStepThrough()]
			get { return this._addUserName; }
			set 
			{
				if (this._addUserName != value) 
				{
					this._addUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUserName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _incomingAmount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal IncomingAmount
		{
			[DebuggerStepThrough()]
			get { return this._incomingAmount; }
			set 
			{
				if (this._incomingAmount != value) 
				{
					this._incomingAmount = value;
					this.IsDirty = true;	
					OnPropertyChanged("IncomingAmount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _incomingTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime IncomingTime
		{
			[DebuggerStepThrough()]
			get { return this._incomingTime; }
			set 
			{
				if (this._incomingTime != value) 
				{
					this._incomingTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("IncomingTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _incomingType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string IncomingType
		{
			[DebuggerStepThrough()]
			get { return this._incomingType; }
			set 
			{
				if (this._incomingType != value) 
				{
					this._incomingType = value;
					this.IsDirty = true;	
					OnPropertyChanged("IncomingType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _dealManName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DealManName
		{
			[DebuggerStepThrough()]
			get { return this._dealManName; }
			set 
			{
				if (this._dealManName != value) 
				{
					this._dealManName = value;
					this.IsDirty = true;	
					OnPropertyChanged("DealManName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _filePath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FilePath
		{
			[DebuggerStepThrough()]
			get { return this._filePath; }
			set 
			{
				if (this._filePath != value) 
				{
					this._filePath = value;
					this.IsDirty = true;	
					OnPropertyChanged("FilePath");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _userBalanceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int UserBalanceID
		{
			[DebuggerStepThrough()]
			get { return this._userBalanceID; }
			set 
			{
				if (this._userBalanceID != value) 
				{
					this._userBalanceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserBalanceID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isManualIncoming = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsManualIncoming
		{
			[DebuggerStepThrough()]
			get { return this._isManualIncoming; }
			set 
			{
				if (this._isManualIncoming != value) 
				{
					this._isManualIncoming = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsManualIncoming");
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
		[DataObjectField(false, false, true)]
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
	[UserID] int,
	[RequestTitle] nvarchar(500),
	[RequestTime] datetime,
	[ApproveTime] datetime,
	[ApproveStatus] int,
	[ApproveRemark] ntext,
	[ApproveUserName] nvarchar(200),
	[ApproveUserLevelID] int,
	[AddUserName] nvarchar(200),
	[IncomingAmount] decimal(18, 2),
	[IncomingTime] datetime,
	[IncomingType] nvarchar(50),
	[DealManName] nvarchar(50),
	[FilePath] ntext,
	[UserBalanceID] int,
	[IsManualIncoming] bit,
	[RoomPhoneRelationID] int
);

INSERT INTO [dbo].[Mall_UserLevelApprove] (
	[Mall_UserLevelApprove].[UserID],
	[Mall_UserLevelApprove].[RequestTitle],
	[Mall_UserLevelApprove].[RequestTime],
	[Mall_UserLevelApprove].[ApproveTime],
	[Mall_UserLevelApprove].[ApproveStatus],
	[Mall_UserLevelApprove].[ApproveRemark],
	[Mall_UserLevelApprove].[ApproveUserName],
	[Mall_UserLevelApprove].[ApproveUserLevelID],
	[Mall_UserLevelApprove].[AddUserName],
	[Mall_UserLevelApprove].[IncomingAmount],
	[Mall_UserLevelApprove].[IncomingTime],
	[Mall_UserLevelApprove].[IncomingType],
	[Mall_UserLevelApprove].[DealManName],
	[Mall_UserLevelApprove].[FilePath],
	[Mall_UserLevelApprove].[UserBalanceID],
	[Mall_UserLevelApprove].[IsManualIncoming],
	[Mall_UserLevelApprove].[RoomPhoneRelationID]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[RequestTitle],
	INSERTED.[RequestTime],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveRemark],
	INSERTED.[ApproveUserName],
	INSERTED.[ApproveUserLevelID],
	INSERTED.[AddUserName],
	INSERTED.[IncomingAmount],
	INSERTED.[IncomingTime],
	INSERTED.[IncomingType],
	INSERTED.[DealManName],
	INSERTED.[FilePath],
	INSERTED.[UserBalanceID],
	INSERTED.[IsManualIncoming],
	INSERTED.[RoomPhoneRelationID]
into @table
VALUES ( 
	@UserID,
	@RequestTitle,
	@RequestTime,
	@ApproveTime,
	@ApproveStatus,
	@ApproveRemark,
	@ApproveUserName,
	@ApproveUserLevelID,
	@AddUserName,
	@IncomingAmount,
	@IncomingTime,
	@IncomingType,
	@DealManName,
	@FilePath,
	@UserBalanceID,
	@IsManualIncoming,
	@RoomPhoneRelationID 
); 

SELECT 
	[ID],
	[UserID],
	[RequestTitle],
	[RequestTime],
	[ApproveTime],
	[ApproveStatus],
	[ApproveRemark],
	[ApproveUserName],
	[ApproveUserLevelID],
	[AddUserName],
	[IncomingAmount],
	[IncomingTime],
	[IncomingType],
	[DealManName],
	[FilePath],
	[UserBalanceID],
	[IsManualIncoming],
	[RoomPhoneRelationID] 
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
	[UserID] int,
	[RequestTitle] nvarchar(500),
	[RequestTime] datetime,
	[ApproveTime] datetime,
	[ApproveStatus] int,
	[ApproveRemark] ntext,
	[ApproveUserName] nvarchar(200),
	[ApproveUserLevelID] int,
	[AddUserName] nvarchar(200),
	[IncomingAmount] decimal(18, 2),
	[IncomingTime] datetime,
	[IncomingType] nvarchar(50),
	[DealManName] nvarchar(50),
	[FilePath] ntext,
	[UserBalanceID] int,
	[IsManualIncoming] bit,
	[RoomPhoneRelationID] int
);

UPDATE [dbo].[Mall_UserLevelApprove] SET 
	[Mall_UserLevelApprove].[UserID] = @UserID,
	[Mall_UserLevelApprove].[RequestTitle] = @RequestTitle,
	[Mall_UserLevelApprove].[RequestTime] = @RequestTime,
	[Mall_UserLevelApprove].[ApproveTime] = @ApproveTime,
	[Mall_UserLevelApprove].[ApproveStatus] = @ApproveStatus,
	[Mall_UserLevelApprove].[ApproveRemark] = @ApproveRemark,
	[Mall_UserLevelApprove].[ApproveUserName] = @ApproveUserName,
	[Mall_UserLevelApprove].[ApproveUserLevelID] = @ApproveUserLevelID,
	[Mall_UserLevelApprove].[AddUserName] = @AddUserName,
	[Mall_UserLevelApprove].[IncomingAmount] = @IncomingAmount,
	[Mall_UserLevelApprove].[IncomingTime] = @IncomingTime,
	[Mall_UserLevelApprove].[IncomingType] = @IncomingType,
	[Mall_UserLevelApprove].[DealManName] = @DealManName,
	[Mall_UserLevelApprove].[FilePath] = @FilePath,
	[Mall_UserLevelApprove].[UserBalanceID] = @UserBalanceID,
	[Mall_UserLevelApprove].[IsManualIncoming] = @IsManualIncoming,
	[Mall_UserLevelApprove].[RoomPhoneRelationID] = @RoomPhoneRelationID 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[RequestTitle],
	INSERTED.[RequestTime],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveRemark],
	INSERTED.[ApproveUserName],
	INSERTED.[ApproveUserLevelID],
	INSERTED.[AddUserName],
	INSERTED.[IncomingAmount],
	INSERTED.[IncomingTime],
	INSERTED.[IncomingType],
	INSERTED.[DealManName],
	INSERTED.[FilePath],
	INSERTED.[UserBalanceID],
	INSERTED.[IsManualIncoming],
	INSERTED.[RoomPhoneRelationID]
into @table
WHERE 
	[Mall_UserLevelApprove].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[RequestTitle],
	[RequestTime],
	[ApproveTime],
	[ApproveStatus],
	[ApproveRemark],
	[ApproveUserName],
	[ApproveUserLevelID],
	[AddUserName],
	[IncomingAmount],
	[IncomingTime],
	[IncomingType],
	[DealManName],
	[FilePath],
	[UserBalanceID],
	[IsManualIncoming],
	[RoomPhoneRelationID] 
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
DELETE FROM [dbo].[Mall_UserLevelApprove]
WHERE 
	[Mall_UserLevelApprove].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_UserLevelApprove() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_UserLevelApprove(this.ID));
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
	[Mall_UserLevelApprove].[ID],
	[Mall_UserLevelApprove].[UserID],
	[Mall_UserLevelApprove].[RequestTitle],
	[Mall_UserLevelApprove].[RequestTime],
	[Mall_UserLevelApprove].[ApproveTime],
	[Mall_UserLevelApprove].[ApproveStatus],
	[Mall_UserLevelApprove].[ApproveRemark],
	[Mall_UserLevelApprove].[ApproveUserName],
	[Mall_UserLevelApprove].[ApproveUserLevelID],
	[Mall_UserLevelApprove].[AddUserName],
	[Mall_UserLevelApprove].[IncomingAmount],
	[Mall_UserLevelApprove].[IncomingTime],
	[Mall_UserLevelApprove].[IncomingType],
	[Mall_UserLevelApprove].[DealManName],
	[Mall_UserLevelApprove].[FilePath],
	[Mall_UserLevelApprove].[UserBalanceID],
	[Mall_UserLevelApprove].[IsManualIncoming],
	[Mall_UserLevelApprove].[RoomPhoneRelationID]
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
                return "Mall_UserLevelApprove";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_UserLevelApprove into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="requestTitle">requestTitle</param>
		/// <param name="requestTime">requestTime</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="approveUserName">approveUserName</param>
		/// <param name="approveUserLevelID">approveUserLevelID</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="incomingAmount">incomingAmount</param>
		/// <param name="incomingTime">incomingTime</param>
		/// <param name="incomingType">incomingType</param>
		/// <param name="dealManName">dealManName</param>
		/// <param name="filePath">filePath</param>
		/// <param name="userBalanceID">userBalanceID</param>
		/// <param name="isManualIncoming">isManualIncoming</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		public static void InsertMall_UserLevelApprove(int @userID, string @requestTitle, DateTime @requestTime, DateTime @approveTime, int @approveStatus, string @approveRemark, string @approveUserName, int @approveUserLevelID, string @addUserName, decimal @incomingAmount, DateTime @incomingTime, string @incomingType, string @dealManName, string @filePath, int @userBalanceID, bool @isManualIncoming, int @roomPhoneRelationID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_UserLevelApprove(@userID, @requestTitle, @requestTime, @approveTime, @approveStatus, @approveRemark, @approveUserName, @approveUserLevelID, @addUserName, @incomingAmount, @incomingTime, @incomingType, @dealManName, @filePath, @userBalanceID, @isManualIncoming, @roomPhoneRelationID, helper);
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
		/// Insert a Mall_UserLevelApprove into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="requestTitle">requestTitle</param>
		/// <param name="requestTime">requestTime</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="approveUserName">approveUserName</param>
		/// <param name="approveUserLevelID">approveUserLevelID</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="incomingAmount">incomingAmount</param>
		/// <param name="incomingTime">incomingTime</param>
		/// <param name="incomingType">incomingType</param>
		/// <param name="dealManName">dealManName</param>
		/// <param name="filePath">filePath</param>
		/// <param name="userBalanceID">userBalanceID</param>
		/// <param name="isManualIncoming">isManualIncoming</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_UserLevelApprove(int @userID, string @requestTitle, DateTime @requestTime, DateTime @approveTime, int @approveStatus, string @approveRemark, string @approveUserName, int @approveUserLevelID, string @addUserName, decimal @incomingAmount, DateTime @incomingTime, string @incomingType, string @dealManName, string @filePath, int @userBalanceID, bool @isManualIncoming, int @roomPhoneRelationID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[RequestTitle] nvarchar(500),
	[RequestTime] datetime,
	[ApproveTime] datetime,
	[ApproveStatus] int,
	[ApproveRemark] ntext,
	[ApproveUserName] nvarchar(200),
	[ApproveUserLevelID] int,
	[AddUserName] nvarchar(200),
	[IncomingAmount] decimal(18, 2),
	[IncomingTime] datetime,
	[IncomingType] nvarchar(50),
	[DealManName] nvarchar(50),
	[FilePath] ntext,
	[UserBalanceID] int,
	[IsManualIncoming] bit,
	[RoomPhoneRelationID] int
);

INSERT INTO [dbo].[Mall_UserLevelApprove] (
	[Mall_UserLevelApprove].[UserID],
	[Mall_UserLevelApprove].[RequestTitle],
	[Mall_UserLevelApprove].[RequestTime],
	[Mall_UserLevelApprove].[ApproveTime],
	[Mall_UserLevelApprove].[ApproveStatus],
	[Mall_UserLevelApprove].[ApproveRemark],
	[Mall_UserLevelApprove].[ApproveUserName],
	[Mall_UserLevelApprove].[ApproveUserLevelID],
	[Mall_UserLevelApprove].[AddUserName],
	[Mall_UserLevelApprove].[IncomingAmount],
	[Mall_UserLevelApprove].[IncomingTime],
	[Mall_UserLevelApprove].[IncomingType],
	[Mall_UserLevelApprove].[DealManName],
	[Mall_UserLevelApprove].[FilePath],
	[Mall_UserLevelApprove].[UserBalanceID],
	[Mall_UserLevelApprove].[IsManualIncoming],
	[Mall_UserLevelApprove].[RoomPhoneRelationID]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[RequestTitle],
	INSERTED.[RequestTime],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveRemark],
	INSERTED.[ApproveUserName],
	INSERTED.[ApproveUserLevelID],
	INSERTED.[AddUserName],
	INSERTED.[IncomingAmount],
	INSERTED.[IncomingTime],
	INSERTED.[IncomingType],
	INSERTED.[DealManName],
	INSERTED.[FilePath],
	INSERTED.[UserBalanceID],
	INSERTED.[IsManualIncoming],
	INSERTED.[RoomPhoneRelationID]
into @table
VALUES ( 
	@UserID,
	@RequestTitle,
	@RequestTime,
	@ApproveTime,
	@ApproveStatus,
	@ApproveRemark,
	@ApproveUserName,
	@ApproveUserLevelID,
	@AddUserName,
	@IncomingAmount,
	@IncomingTime,
	@IncomingType,
	@DealManName,
	@FilePath,
	@UserBalanceID,
	@IsManualIncoming,
	@RoomPhoneRelationID 
); 

SELECT 
	[ID],
	[UserID],
	[RequestTitle],
	[RequestTime],
	[ApproveTime],
	[ApproveStatus],
	[ApproveRemark],
	[ApproveUserName],
	[ApproveUserLevelID],
	[AddUserName],
	[IncomingAmount],
	[IncomingTime],
	[IncomingType],
	[DealManName],
	[FilePath],
	[UserBalanceID],
	[IsManualIncoming],
	[RoomPhoneRelationID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@RequestTitle", EntityBase.GetDatabaseValue(@requestTitle)));
			parameters.Add(new SqlParameter("@RequestTime", EntityBase.GetDatabaseValue(@requestTime)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveStatus", EntityBase.GetDatabaseValue(@approveStatus)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@ApproveUserName", EntityBase.GetDatabaseValue(@approveUserName)));
			parameters.Add(new SqlParameter("@ApproveUserLevelID", EntityBase.GetDatabaseValue(@approveUserLevelID)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@IncomingAmount", EntityBase.GetDatabaseValue(@incomingAmount)));
			parameters.Add(new SqlParameter("@IncomingTime", EntityBase.GetDatabaseValue(@incomingTime)));
			parameters.Add(new SqlParameter("@IncomingType", EntityBase.GetDatabaseValue(@incomingType)));
			parameters.Add(new SqlParameter("@DealManName", EntityBase.GetDatabaseValue(@dealManName)));
			parameters.Add(new SqlParameter("@FilePath", EntityBase.GetDatabaseValue(@filePath)));
			parameters.Add(new SqlParameter("@UserBalanceID", EntityBase.GetDatabaseValue(@userBalanceID)));
			parameters.Add(new SqlParameter("@IsManualIncoming", @isManualIncoming));
			parameters.Add(new SqlParameter("@RoomPhoneRelationID", EntityBase.GetDatabaseValue(@roomPhoneRelationID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_UserLevelApprove into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="requestTitle">requestTitle</param>
		/// <param name="requestTime">requestTime</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="approveUserName">approveUserName</param>
		/// <param name="approveUserLevelID">approveUserLevelID</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="incomingAmount">incomingAmount</param>
		/// <param name="incomingTime">incomingTime</param>
		/// <param name="incomingType">incomingType</param>
		/// <param name="dealManName">dealManName</param>
		/// <param name="filePath">filePath</param>
		/// <param name="userBalanceID">userBalanceID</param>
		/// <param name="isManualIncoming">isManualIncoming</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		public static void UpdateMall_UserLevelApprove(int @iD, int @userID, string @requestTitle, DateTime @requestTime, DateTime @approveTime, int @approveStatus, string @approveRemark, string @approveUserName, int @approveUserLevelID, string @addUserName, decimal @incomingAmount, DateTime @incomingTime, string @incomingType, string @dealManName, string @filePath, int @userBalanceID, bool @isManualIncoming, int @roomPhoneRelationID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_UserLevelApprove(@iD, @userID, @requestTitle, @requestTime, @approveTime, @approveStatus, @approveRemark, @approveUserName, @approveUserLevelID, @addUserName, @incomingAmount, @incomingTime, @incomingType, @dealManName, @filePath, @userBalanceID, @isManualIncoming, @roomPhoneRelationID, helper);
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
		/// Updates a Mall_UserLevelApprove into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="requestTitle">requestTitle</param>
		/// <param name="requestTime">requestTime</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="approveUserName">approveUserName</param>
		/// <param name="approveUserLevelID">approveUserLevelID</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="incomingAmount">incomingAmount</param>
		/// <param name="incomingTime">incomingTime</param>
		/// <param name="incomingType">incomingType</param>
		/// <param name="dealManName">dealManName</param>
		/// <param name="filePath">filePath</param>
		/// <param name="userBalanceID">userBalanceID</param>
		/// <param name="isManualIncoming">isManualIncoming</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_UserLevelApprove(int @iD, int @userID, string @requestTitle, DateTime @requestTime, DateTime @approveTime, int @approveStatus, string @approveRemark, string @approveUserName, int @approveUserLevelID, string @addUserName, decimal @incomingAmount, DateTime @incomingTime, string @incomingType, string @dealManName, string @filePath, int @userBalanceID, bool @isManualIncoming, int @roomPhoneRelationID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[RequestTitle] nvarchar(500),
	[RequestTime] datetime,
	[ApproveTime] datetime,
	[ApproveStatus] int,
	[ApproveRemark] ntext,
	[ApproveUserName] nvarchar(200),
	[ApproveUserLevelID] int,
	[AddUserName] nvarchar(200),
	[IncomingAmount] decimal(18, 2),
	[IncomingTime] datetime,
	[IncomingType] nvarchar(50),
	[DealManName] nvarchar(50),
	[FilePath] ntext,
	[UserBalanceID] int,
	[IsManualIncoming] bit,
	[RoomPhoneRelationID] int
);

UPDATE [dbo].[Mall_UserLevelApprove] SET 
	[Mall_UserLevelApprove].[UserID] = @UserID,
	[Mall_UserLevelApprove].[RequestTitle] = @RequestTitle,
	[Mall_UserLevelApprove].[RequestTime] = @RequestTime,
	[Mall_UserLevelApprove].[ApproveTime] = @ApproveTime,
	[Mall_UserLevelApprove].[ApproveStatus] = @ApproveStatus,
	[Mall_UserLevelApprove].[ApproveRemark] = @ApproveRemark,
	[Mall_UserLevelApprove].[ApproveUserName] = @ApproveUserName,
	[Mall_UserLevelApprove].[ApproveUserLevelID] = @ApproveUserLevelID,
	[Mall_UserLevelApprove].[AddUserName] = @AddUserName,
	[Mall_UserLevelApprove].[IncomingAmount] = @IncomingAmount,
	[Mall_UserLevelApprove].[IncomingTime] = @IncomingTime,
	[Mall_UserLevelApprove].[IncomingType] = @IncomingType,
	[Mall_UserLevelApprove].[DealManName] = @DealManName,
	[Mall_UserLevelApprove].[FilePath] = @FilePath,
	[Mall_UserLevelApprove].[UserBalanceID] = @UserBalanceID,
	[Mall_UserLevelApprove].[IsManualIncoming] = @IsManualIncoming,
	[Mall_UserLevelApprove].[RoomPhoneRelationID] = @RoomPhoneRelationID 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[RequestTitle],
	INSERTED.[RequestTime],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveRemark],
	INSERTED.[ApproveUserName],
	INSERTED.[ApproveUserLevelID],
	INSERTED.[AddUserName],
	INSERTED.[IncomingAmount],
	INSERTED.[IncomingTime],
	INSERTED.[IncomingType],
	INSERTED.[DealManName],
	INSERTED.[FilePath],
	INSERTED.[UserBalanceID],
	INSERTED.[IsManualIncoming],
	INSERTED.[RoomPhoneRelationID]
into @table
WHERE 
	[Mall_UserLevelApprove].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[RequestTitle],
	[RequestTime],
	[ApproveTime],
	[ApproveStatus],
	[ApproveRemark],
	[ApproveUserName],
	[ApproveUserLevelID],
	[AddUserName],
	[IncomingAmount],
	[IncomingTime],
	[IncomingType],
	[DealManName],
	[FilePath],
	[UserBalanceID],
	[IsManualIncoming],
	[RoomPhoneRelationID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@RequestTitle", EntityBase.GetDatabaseValue(@requestTitle)));
			parameters.Add(new SqlParameter("@RequestTime", EntityBase.GetDatabaseValue(@requestTime)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveStatus", EntityBase.GetDatabaseValue(@approveStatus)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@ApproveUserName", EntityBase.GetDatabaseValue(@approveUserName)));
			parameters.Add(new SqlParameter("@ApproveUserLevelID", EntityBase.GetDatabaseValue(@approveUserLevelID)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@IncomingAmount", EntityBase.GetDatabaseValue(@incomingAmount)));
			parameters.Add(new SqlParameter("@IncomingTime", EntityBase.GetDatabaseValue(@incomingTime)));
			parameters.Add(new SqlParameter("@IncomingType", EntityBase.GetDatabaseValue(@incomingType)));
			parameters.Add(new SqlParameter("@DealManName", EntityBase.GetDatabaseValue(@dealManName)));
			parameters.Add(new SqlParameter("@FilePath", EntityBase.GetDatabaseValue(@filePath)));
			parameters.Add(new SqlParameter("@UserBalanceID", EntityBase.GetDatabaseValue(@userBalanceID)));
			parameters.Add(new SqlParameter("@IsManualIncoming", @isManualIncoming));
			parameters.Add(new SqlParameter("@RoomPhoneRelationID", EntityBase.GetDatabaseValue(@roomPhoneRelationID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_UserLevelApprove from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_UserLevelApprove(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_UserLevelApprove(@iD, helper);
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
		/// Deletes a Mall_UserLevelApprove from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_UserLevelApprove(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_UserLevelApprove]
WHERE 
	[Mall_UserLevelApprove].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_UserLevelApprove object.
		/// </summary>
		/// <returns>The newly created Mall_UserLevelApprove object.</returns>
		public static Mall_UserLevelApprove CreateMall_UserLevelApprove()
		{
			return InitializeNew<Mall_UserLevelApprove>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_UserLevelApprove by a Mall_UserLevelApprove's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_UserLevelApprove</returns>
		public static Mall_UserLevelApprove GetMall_UserLevelApprove(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_UserLevelApprove.SelectFieldList + @"
FROM [dbo].[Mall_UserLevelApprove] 
WHERE 
	[Mall_UserLevelApprove].[ID] = @ID " + Mall_UserLevelApprove.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_UserLevelApprove>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_UserLevelApprove by a Mall_UserLevelApprove's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_UserLevelApprove</returns>
		public static Mall_UserLevelApprove GetMall_UserLevelApprove(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_UserLevelApprove.SelectFieldList + @"
FROM [dbo].[Mall_UserLevelApprove] 
WHERE 
	[Mall_UserLevelApprove].[ID] = @ID " + Mall_UserLevelApprove.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_UserLevelApprove>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserLevelApprove objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_UserLevelApprove objects.</returns>
		public static EntityList<Mall_UserLevelApprove> GetMall_UserLevelApproves()
		{
			string commandText = @"
SELECT " + Mall_UserLevelApprove.SelectFieldList + "FROM [dbo].[Mall_UserLevelApprove] " + Mall_UserLevelApprove.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_UserLevelApprove>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_UserLevelApprove objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_UserLevelApprove objects.</returns>
        public static EntityList<Mall_UserLevelApprove> GetMall_UserLevelApproves(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserLevelApprove>(SelectFieldList, "FROM [dbo].[Mall_UserLevelApprove]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_UserLevelApprove objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_UserLevelApprove objects.</returns>
        public static EntityList<Mall_UserLevelApprove> GetMall_UserLevelApproves(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserLevelApprove>(SelectFieldList, "FROM [dbo].[Mall_UserLevelApprove]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_UserLevelApprove objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_UserLevelApprove objects.</returns>
		protected static EntityList<Mall_UserLevelApprove> GetMall_UserLevelApproves(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserLevelApproves(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserLevelApprove objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserLevelApprove objects.</returns>
		protected static EntityList<Mall_UserLevelApprove> GetMall_UserLevelApproves(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserLevelApproves(string.Empty, where, parameters, Mall_UserLevelApprove.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserLevelApprove objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserLevelApprove objects.</returns>
		protected static EntityList<Mall_UserLevelApprove> GetMall_UserLevelApproves(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserLevelApproves(prefix, where, parameters, Mall_UserLevelApprove.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserLevelApprove objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserLevelApprove objects.</returns>
		protected static EntityList<Mall_UserLevelApprove> GetMall_UserLevelApproves(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_UserLevelApproves(string.Empty, where, parameters, Mall_UserLevelApprove.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserLevelApprove objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserLevelApprove objects.</returns>
		protected static EntityList<Mall_UserLevelApprove> GetMall_UserLevelApproves(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_UserLevelApproves(prefix, where, parameters, Mall_UserLevelApprove.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserLevelApprove objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_UserLevelApprove objects.</returns>
		protected static EntityList<Mall_UserLevelApprove> GetMall_UserLevelApproves(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_UserLevelApprove.SelectFieldList + "FROM [dbo].[Mall_UserLevelApprove] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_UserLevelApprove>(reader);
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
        protected static EntityList<Mall_UserLevelApprove> GetMall_UserLevelApproves(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserLevelApprove>(SelectFieldList, "FROM [dbo].[Mall_UserLevelApprove] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_UserLevelApprove objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_UserLevelApproveCount()
        {
            return GetMall_UserLevelApproveCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_UserLevelApprove objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_UserLevelApproveCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_UserLevelApprove] " + where;

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
		public static partial class Mall_UserLevelApprove_Properties
		{
			public const string ID = "ID";
			public const string UserID = "UserID";
			public const string RequestTitle = "RequestTitle";
			public const string RequestTime = "RequestTime";
			public const string ApproveTime = "ApproveTime";
			public const string ApproveStatus = "ApproveStatus";
			public const string ApproveRemark = "ApproveRemark";
			public const string ApproveUserName = "ApproveUserName";
			public const string ApproveUserLevelID = "ApproveUserLevelID";
			public const string AddUserName = "AddUserName";
			public const string IncomingAmount = "IncomingAmount";
			public const string IncomingTime = "IncomingTime";
			public const string IncomingType = "IncomingType";
			public const string DealManName = "DealManName";
			public const string FilePath = "FilePath";
			public const string UserBalanceID = "UserBalanceID";
			public const string IsManualIncoming = "IsManualIncoming";
			public const string RoomPhoneRelationID = "RoomPhoneRelationID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"RequestTitle" , "string:"},
    			 {"RequestTime" , "DateTime:"},
    			 {"ApproveTime" , "DateTime:"},
    			 {"ApproveStatus" , "int:0-待审核 1-通过 2-未通过 3-待申请"},
    			 {"ApproveRemark" , "string:"},
    			 {"ApproveUserName" , "string:"},
    			 {"ApproveUserLevelID" , "int:"},
    			 {"AddUserName" , "string:"},
    			 {"IncomingAmount" , "decimal:"},
    			 {"IncomingTime" , "DateTime:"},
    			 {"IncomingType" , "string:"},
    			 {"DealManName" , "string:"},
    			 {"FilePath" , "string:"},
    			 {"UserBalanceID" , "int:"},
    			 {"IsManualIncoming" , "bool:"},
    			 {"RoomPhoneRelationID" , "int:"},
            };
		}
		#endregion
	}
}
