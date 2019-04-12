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
	/// This object represents the properties and methods of a Mall_PointCovertRecord.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_PointCovertRecord 
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
		private int _pointValue = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int PointValue
		{
			[DebuggerStepThrough()]
			get { return this._pointValue; }
			set 
			{
				if (this._pointValue != value) 
				{
					this._pointValue = value;
					this.IsDirty = true;	
					OnPropertyChanged("PointValue");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _checkPointValue = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal CheckPointValue
		{
			[DebuggerStepThrough()]
			get { return this._checkPointValue; }
			set 
			{
				if (this._checkPointValue != value) 
				{
					this._checkPointValue = value;
					this.IsDirty = true;	
					OnPropertyChanged("CheckPointValue");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _pointRuleID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PointRuleID
		{
			[DebuggerStepThrough()]
			get { return this._pointRuleID; }
			set 
			{
				if (this._pointRuleID != value) 
				{
					this._pointRuleID = value;
					this.IsDirty = true;	
					OnPropertyChanged("PointRuleID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _status = int.MinValue;
		/// <summary>
		/// 1-已兑换 2-申请中 3-已拒绝
		/// </summary>
        [Description("1-已兑换 2-申请中 3-已拒绝")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int Status
		{
			[DebuggerStepThrough()]
			get { return this._status; }
			set 
			{
				if (this._status != value) 
				{
					this._status = value;
					this.IsDirty = true;	
					OnPropertyChanged("Status");
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
		private string _addUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private string _approveUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
		private int _mall_UserPointID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Mall_UserPointID
		{
			[DebuggerStepThrough()]
			get { return this._mall_UserPointID; }
			set 
			{
				if (this._mall_UserPointID != value) 
				{
					this._mall_UserPointID = value;
					this.IsDirty = true;	
					OnPropertyChanged("Mall_UserPointID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _mall_UserJiXiaoPointID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Mall_UserJiXiaoPointID
		{
			[DebuggerStepThrough()]
			get { return this._mall_UserJiXiaoPointID; }
			set 
			{
				if (this._mall_UserJiXiaoPointID != value) 
				{
					this._mall_UserJiXiaoPointID = value;
					this.IsDirty = true;	
					OnPropertyChanged("Mall_UserJiXiaoPointID");
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
	[PointValue] int,
	[CheckPointValue] decimal(18, 2),
	[PointRuleID] int,
	[Status] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(100),
	[ApproveUserName] nvarchar(100),
	[ApproveTime] datetime,
	[ApproveRemark] ntext,
	[Mall_UserPointID] int,
	[Mall_UserJiXiaoPointID] int
);

INSERT INTO [dbo].[Mall_PointCovertRecord] (
	[Mall_PointCovertRecord].[UserID],
	[Mall_PointCovertRecord].[PointValue],
	[Mall_PointCovertRecord].[CheckPointValue],
	[Mall_PointCovertRecord].[PointRuleID],
	[Mall_PointCovertRecord].[Status],
	[Mall_PointCovertRecord].[AddTime],
	[Mall_PointCovertRecord].[AddUserName],
	[Mall_PointCovertRecord].[ApproveUserName],
	[Mall_PointCovertRecord].[ApproveTime],
	[Mall_PointCovertRecord].[ApproveRemark],
	[Mall_PointCovertRecord].[Mall_UserPointID],
	[Mall_PointCovertRecord].[Mall_UserJiXiaoPointID]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[PointValue],
	INSERTED.[CheckPointValue],
	INSERTED.[PointRuleID],
	INSERTED.[Status],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ApproveUserName],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[Mall_UserPointID],
	INSERTED.[Mall_UserJiXiaoPointID]
into @table
VALUES ( 
	@UserID,
	@PointValue,
	@CheckPointValue,
	@PointRuleID,
	@Status,
	@AddTime,
	@AddUserName,
	@ApproveUserName,
	@ApproveTime,
	@ApproveRemark,
	@Mall_UserPointID,
	@Mall_UserJiXiaoPointID 
); 

SELECT 
	[ID],
	[UserID],
	[PointValue],
	[CheckPointValue],
	[PointRuleID],
	[Status],
	[AddTime],
	[AddUserName],
	[ApproveUserName],
	[ApproveTime],
	[ApproveRemark],
	[Mall_UserPointID],
	[Mall_UserJiXiaoPointID] 
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
	[PointValue] int,
	[CheckPointValue] decimal(18, 2),
	[PointRuleID] int,
	[Status] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(100),
	[ApproveUserName] nvarchar(100),
	[ApproveTime] datetime,
	[ApproveRemark] ntext,
	[Mall_UserPointID] int,
	[Mall_UserJiXiaoPointID] int
);

UPDATE [dbo].[Mall_PointCovertRecord] SET 
	[Mall_PointCovertRecord].[UserID] = @UserID,
	[Mall_PointCovertRecord].[PointValue] = @PointValue,
	[Mall_PointCovertRecord].[CheckPointValue] = @CheckPointValue,
	[Mall_PointCovertRecord].[PointRuleID] = @PointRuleID,
	[Mall_PointCovertRecord].[Status] = @Status,
	[Mall_PointCovertRecord].[AddTime] = @AddTime,
	[Mall_PointCovertRecord].[AddUserName] = @AddUserName,
	[Mall_PointCovertRecord].[ApproveUserName] = @ApproveUserName,
	[Mall_PointCovertRecord].[ApproveTime] = @ApproveTime,
	[Mall_PointCovertRecord].[ApproveRemark] = @ApproveRemark,
	[Mall_PointCovertRecord].[Mall_UserPointID] = @Mall_UserPointID,
	[Mall_PointCovertRecord].[Mall_UserJiXiaoPointID] = @Mall_UserJiXiaoPointID 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[PointValue],
	INSERTED.[CheckPointValue],
	INSERTED.[PointRuleID],
	INSERTED.[Status],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ApproveUserName],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[Mall_UserPointID],
	INSERTED.[Mall_UserJiXiaoPointID]
into @table
WHERE 
	[Mall_PointCovertRecord].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[PointValue],
	[CheckPointValue],
	[PointRuleID],
	[Status],
	[AddTime],
	[AddUserName],
	[ApproveUserName],
	[ApproveTime],
	[ApproveRemark],
	[Mall_UserPointID],
	[Mall_UserJiXiaoPointID] 
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
DELETE FROM [dbo].[Mall_PointCovertRecord]
WHERE 
	[Mall_PointCovertRecord].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_PointCovertRecord() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_PointCovertRecord(this.ID));
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
	[Mall_PointCovertRecord].[ID],
	[Mall_PointCovertRecord].[UserID],
	[Mall_PointCovertRecord].[PointValue],
	[Mall_PointCovertRecord].[CheckPointValue],
	[Mall_PointCovertRecord].[PointRuleID],
	[Mall_PointCovertRecord].[Status],
	[Mall_PointCovertRecord].[AddTime],
	[Mall_PointCovertRecord].[AddUserName],
	[Mall_PointCovertRecord].[ApproveUserName],
	[Mall_PointCovertRecord].[ApproveTime],
	[Mall_PointCovertRecord].[ApproveRemark],
	[Mall_PointCovertRecord].[Mall_UserPointID],
	[Mall_PointCovertRecord].[Mall_UserJiXiaoPointID]
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
                return "Mall_PointCovertRecord";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_PointCovertRecord into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="pointValue">pointValue</param>
		/// <param name="checkPointValue">checkPointValue</param>
		/// <param name="pointRuleID">pointRuleID</param>
		/// <param name="status">status</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="approveUserName">approveUserName</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="mall_UserPointID">mall_UserPointID</param>
		/// <param name="mall_UserJiXiaoPointID">mall_UserJiXiaoPointID</param>
		public static void InsertMall_PointCovertRecord(int @userID, int @pointValue, decimal @checkPointValue, int @pointRuleID, int @status, DateTime @addTime, string @addUserName, string @approveUserName, DateTime @approveTime, string @approveRemark, int @mall_UserPointID, int @mall_UserJiXiaoPointID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_PointCovertRecord(@userID, @pointValue, @checkPointValue, @pointRuleID, @status, @addTime, @addUserName, @approveUserName, @approveTime, @approveRemark, @mall_UserPointID, @mall_UserJiXiaoPointID, helper);
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
		/// Insert a Mall_PointCovertRecord into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="pointValue">pointValue</param>
		/// <param name="checkPointValue">checkPointValue</param>
		/// <param name="pointRuleID">pointRuleID</param>
		/// <param name="status">status</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="approveUserName">approveUserName</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="mall_UserPointID">mall_UserPointID</param>
		/// <param name="mall_UserJiXiaoPointID">mall_UserJiXiaoPointID</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_PointCovertRecord(int @userID, int @pointValue, decimal @checkPointValue, int @pointRuleID, int @status, DateTime @addTime, string @addUserName, string @approveUserName, DateTime @approveTime, string @approveRemark, int @mall_UserPointID, int @mall_UserJiXiaoPointID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[PointValue] int,
	[CheckPointValue] decimal(18, 2),
	[PointRuleID] int,
	[Status] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(100),
	[ApproveUserName] nvarchar(100),
	[ApproveTime] datetime,
	[ApproveRemark] ntext,
	[Mall_UserPointID] int,
	[Mall_UserJiXiaoPointID] int
);

INSERT INTO [dbo].[Mall_PointCovertRecord] (
	[Mall_PointCovertRecord].[UserID],
	[Mall_PointCovertRecord].[PointValue],
	[Mall_PointCovertRecord].[CheckPointValue],
	[Mall_PointCovertRecord].[PointRuleID],
	[Mall_PointCovertRecord].[Status],
	[Mall_PointCovertRecord].[AddTime],
	[Mall_PointCovertRecord].[AddUserName],
	[Mall_PointCovertRecord].[ApproveUserName],
	[Mall_PointCovertRecord].[ApproveTime],
	[Mall_PointCovertRecord].[ApproveRemark],
	[Mall_PointCovertRecord].[Mall_UserPointID],
	[Mall_PointCovertRecord].[Mall_UserJiXiaoPointID]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[PointValue],
	INSERTED.[CheckPointValue],
	INSERTED.[PointRuleID],
	INSERTED.[Status],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ApproveUserName],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[Mall_UserPointID],
	INSERTED.[Mall_UserJiXiaoPointID]
into @table
VALUES ( 
	@UserID,
	@PointValue,
	@CheckPointValue,
	@PointRuleID,
	@Status,
	@AddTime,
	@AddUserName,
	@ApproveUserName,
	@ApproveTime,
	@ApproveRemark,
	@Mall_UserPointID,
	@Mall_UserJiXiaoPointID 
); 

SELECT 
	[ID],
	[UserID],
	[PointValue],
	[CheckPointValue],
	[PointRuleID],
	[Status],
	[AddTime],
	[AddUserName],
	[ApproveUserName],
	[ApproveTime],
	[ApproveRemark],
	[Mall_UserPointID],
	[Mall_UserJiXiaoPointID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@PointValue", EntityBase.GetDatabaseValue(@pointValue)));
			parameters.Add(new SqlParameter("@CheckPointValue", EntityBase.GetDatabaseValue(@checkPointValue)));
			parameters.Add(new SqlParameter("@PointRuleID", EntityBase.GetDatabaseValue(@pointRuleID)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@ApproveUserName", EntityBase.GetDatabaseValue(@approveUserName)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@Mall_UserPointID", EntityBase.GetDatabaseValue(@mall_UserPointID)));
			parameters.Add(new SqlParameter("@Mall_UserJiXiaoPointID", EntityBase.GetDatabaseValue(@mall_UserJiXiaoPointID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_PointCovertRecord into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="pointValue">pointValue</param>
		/// <param name="checkPointValue">checkPointValue</param>
		/// <param name="pointRuleID">pointRuleID</param>
		/// <param name="status">status</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="approveUserName">approveUserName</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="mall_UserPointID">mall_UserPointID</param>
		/// <param name="mall_UserJiXiaoPointID">mall_UserJiXiaoPointID</param>
		public static void UpdateMall_PointCovertRecord(int @iD, int @userID, int @pointValue, decimal @checkPointValue, int @pointRuleID, int @status, DateTime @addTime, string @addUserName, string @approveUserName, DateTime @approveTime, string @approveRemark, int @mall_UserPointID, int @mall_UserJiXiaoPointID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_PointCovertRecord(@iD, @userID, @pointValue, @checkPointValue, @pointRuleID, @status, @addTime, @addUserName, @approveUserName, @approveTime, @approveRemark, @mall_UserPointID, @mall_UserJiXiaoPointID, helper);
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
		/// Updates a Mall_PointCovertRecord into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="pointValue">pointValue</param>
		/// <param name="checkPointValue">checkPointValue</param>
		/// <param name="pointRuleID">pointRuleID</param>
		/// <param name="status">status</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="approveUserName">approveUserName</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="mall_UserPointID">mall_UserPointID</param>
		/// <param name="mall_UserJiXiaoPointID">mall_UserJiXiaoPointID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_PointCovertRecord(int @iD, int @userID, int @pointValue, decimal @checkPointValue, int @pointRuleID, int @status, DateTime @addTime, string @addUserName, string @approveUserName, DateTime @approveTime, string @approveRemark, int @mall_UserPointID, int @mall_UserJiXiaoPointID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[PointValue] int,
	[CheckPointValue] decimal(18, 2),
	[PointRuleID] int,
	[Status] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(100),
	[ApproveUserName] nvarchar(100),
	[ApproveTime] datetime,
	[ApproveRemark] ntext,
	[Mall_UserPointID] int,
	[Mall_UserJiXiaoPointID] int
);

UPDATE [dbo].[Mall_PointCovertRecord] SET 
	[Mall_PointCovertRecord].[UserID] = @UserID,
	[Mall_PointCovertRecord].[PointValue] = @PointValue,
	[Mall_PointCovertRecord].[CheckPointValue] = @CheckPointValue,
	[Mall_PointCovertRecord].[PointRuleID] = @PointRuleID,
	[Mall_PointCovertRecord].[Status] = @Status,
	[Mall_PointCovertRecord].[AddTime] = @AddTime,
	[Mall_PointCovertRecord].[AddUserName] = @AddUserName,
	[Mall_PointCovertRecord].[ApproveUserName] = @ApproveUserName,
	[Mall_PointCovertRecord].[ApproveTime] = @ApproveTime,
	[Mall_PointCovertRecord].[ApproveRemark] = @ApproveRemark,
	[Mall_PointCovertRecord].[Mall_UserPointID] = @Mall_UserPointID,
	[Mall_PointCovertRecord].[Mall_UserJiXiaoPointID] = @Mall_UserJiXiaoPointID 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[PointValue],
	INSERTED.[CheckPointValue],
	INSERTED.[PointRuleID],
	INSERTED.[Status],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ApproveUserName],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[Mall_UserPointID],
	INSERTED.[Mall_UserJiXiaoPointID]
into @table
WHERE 
	[Mall_PointCovertRecord].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[PointValue],
	[CheckPointValue],
	[PointRuleID],
	[Status],
	[AddTime],
	[AddUserName],
	[ApproveUserName],
	[ApproveTime],
	[ApproveRemark],
	[Mall_UserPointID],
	[Mall_UserJiXiaoPointID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@PointValue", EntityBase.GetDatabaseValue(@pointValue)));
			parameters.Add(new SqlParameter("@CheckPointValue", EntityBase.GetDatabaseValue(@checkPointValue)));
			parameters.Add(new SqlParameter("@PointRuleID", EntityBase.GetDatabaseValue(@pointRuleID)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@ApproveUserName", EntityBase.GetDatabaseValue(@approveUserName)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@Mall_UserPointID", EntityBase.GetDatabaseValue(@mall_UserPointID)));
			parameters.Add(new SqlParameter("@Mall_UserJiXiaoPointID", EntityBase.GetDatabaseValue(@mall_UserJiXiaoPointID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_PointCovertRecord from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_PointCovertRecord(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_PointCovertRecord(@iD, helper);
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
		/// Deletes a Mall_PointCovertRecord from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_PointCovertRecord(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_PointCovertRecord]
WHERE 
	[Mall_PointCovertRecord].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_PointCovertRecord object.
		/// </summary>
		/// <returns>The newly created Mall_PointCovertRecord object.</returns>
		public static Mall_PointCovertRecord CreateMall_PointCovertRecord()
		{
			return InitializeNew<Mall_PointCovertRecord>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_PointCovertRecord by a Mall_PointCovertRecord's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_PointCovertRecord</returns>
		public static Mall_PointCovertRecord GetMall_PointCovertRecord(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_PointCovertRecord.SelectFieldList + @"
FROM [dbo].[Mall_PointCovertRecord] 
WHERE 
	[Mall_PointCovertRecord].[ID] = @ID " + Mall_PointCovertRecord.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_PointCovertRecord>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_PointCovertRecord by a Mall_PointCovertRecord's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_PointCovertRecord</returns>
		public static Mall_PointCovertRecord GetMall_PointCovertRecord(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_PointCovertRecord.SelectFieldList + @"
FROM [dbo].[Mall_PointCovertRecord] 
WHERE 
	[Mall_PointCovertRecord].[ID] = @ID " + Mall_PointCovertRecord.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_PointCovertRecord>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_PointCovertRecord objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_PointCovertRecord objects.</returns>
		public static EntityList<Mall_PointCovertRecord> GetMall_PointCovertRecords()
		{
			string commandText = @"
SELECT " + Mall_PointCovertRecord.SelectFieldList + "FROM [dbo].[Mall_PointCovertRecord] " + Mall_PointCovertRecord.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_PointCovertRecord>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_PointCovertRecord objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_PointCovertRecord objects.</returns>
        public static EntityList<Mall_PointCovertRecord> GetMall_PointCovertRecords(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_PointCovertRecord>(SelectFieldList, "FROM [dbo].[Mall_PointCovertRecord]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_PointCovertRecord objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_PointCovertRecord objects.</returns>
        public static EntityList<Mall_PointCovertRecord> GetMall_PointCovertRecords(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_PointCovertRecord>(SelectFieldList, "FROM [dbo].[Mall_PointCovertRecord]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_PointCovertRecord objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_PointCovertRecord objects.</returns>
		protected static EntityList<Mall_PointCovertRecord> GetMall_PointCovertRecords(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_PointCovertRecords(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_PointCovertRecord objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_PointCovertRecord objects.</returns>
		protected static EntityList<Mall_PointCovertRecord> GetMall_PointCovertRecords(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_PointCovertRecords(string.Empty, where, parameters, Mall_PointCovertRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_PointCovertRecord objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_PointCovertRecord objects.</returns>
		protected static EntityList<Mall_PointCovertRecord> GetMall_PointCovertRecords(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_PointCovertRecords(prefix, where, parameters, Mall_PointCovertRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_PointCovertRecord objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_PointCovertRecord objects.</returns>
		protected static EntityList<Mall_PointCovertRecord> GetMall_PointCovertRecords(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_PointCovertRecords(string.Empty, where, parameters, Mall_PointCovertRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_PointCovertRecord objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_PointCovertRecord objects.</returns>
		protected static EntityList<Mall_PointCovertRecord> GetMall_PointCovertRecords(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_PointCovertRecords(prefix, where, parameters, Mall_PointCovertRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_PointCovertRecord objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_PointCovertRecord objects.</returns>
		protected static EntityList<Mall_PointCovertRecord> GetMall_PointCovertRecords(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_PointCovertRecord.SelectFieldList + "FROM [dbo].[Mall_PointCovertRecord] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_PointCovertRecord>(reader);
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
        protected static EntityList<Mall_PointCovertRecord> GetMall_PointCovertRecords(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_PointCovertRecord>(SelectFieldList, "FROM [dbo].[Mall_PointCovertRecord] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_PointCovertRecord objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_PointCovertRecordCount()
        {
            return GetMall_PointCovertRecordCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_PointCovertRecord objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_PointCovertRecordCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_PointCovertRecord] " + where;

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
		public static partial class Mall_PointCovertRecord_Properties
		{
			public const string ID = "ID";
			public const string UserID = "UserID";
			public const string PointValue = "PointValue";
			public const string CheckPointValue = "CheckPointValue";
			public const string PointRuleID = "PointRuleID";
			public const string Status = "Status";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string ApproveUserName = "ApproveUserName";
			public const string ApproveTime = "ApproveTime";
			public const string ApproveRemark = "ApproveRemark";
			public const string Mall_UserPointID = "Mall_UserPointID";
			public const string Mall_UserJiXiaoPointID = "Mall_UserJiXiaoPointID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"PointValue" , "int:"},
    			 {"CheckPointValue" , "decimal:"},
    			 {"PointRuleID" , "int:"},
    			 {"Status" , "int:1-已兑换 2-申请中 3-已拒绝"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"ApproveUserName" , "string:"},
    			 {"ApproveTime" , "DateTime:"},
    			 {"ApproveRemark" , "string:"},
    			 {"Mall_UserPointID" , "int:"},
    			 {"Mall_UserJiXiaoPointID" , "int:"},
            };
		}
		#endregion
	}
}
