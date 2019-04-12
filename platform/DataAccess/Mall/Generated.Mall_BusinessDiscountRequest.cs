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
	/// This object represents the properties and methods of a Mall_BusinessDiscountRequest.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_BusinessDiscountRequest 
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
		private string _requestContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string RequestContent
		{
			[DebuggerStepThrough()]
			get { return this._requestContent; }
			set 
			{
				if (this._requestContent != value) 
				{
					this._requestContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("RequestContent");
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
		private int _status = int.MinValue;
		/// <summary>
		/// 1-申请中 2-已生效 3-无效
		/// </summary>
        [Description("1-申请中 2-已生效 3-无效")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
		private DateTime _startTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime StartTime
		{
			[DebuggerStepThrough()]
			get { return this._startTime; }
			set 
			{
				if (this._startTime != value) 
				{
					this._startTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("StartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _endTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime EndTime
		{
			[DebuggerStepThrough()]
			get { return this._endTime; }
			set 
			{
				if (this._endTime != value) 
				{
					this._endTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isActive = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsActive
		{
			[DebuggerStepThrough()]
			get { return this._isActive; }
			set 
			{
				if (this._isActive != value) 
				{
					this._isActive = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsActive");
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
	[BusinessID] int,
	[UserID] int,
	[RequestContent] nvarchar(1000),
	[AddTime] datetime,
	[AddUserMan] nvarchar(100),
	[Status] int,
	[ApproveUserMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveRemark] nvarchar(1000),
	[StartTime] datetime,
	[EndTime] datetime,
	[IsActive] bit
);

INSERT INTO [dbo].[Mall_BusinessDiscountRequest] (
	[Mall_BusinessDiscountRequest].[BusinessID],
	[Mall_BusinessDiscountRequest].[UserID],
	[Mall_BusinessDiscountRequest].[RequestContent],
	[Mall_BusinessDiscountRequest].[AddTime],
	[Mall_BusinessDiscountRequest].[AddUserMan],
	[Mall_BusinessDiscountRequest].[Status],
	[Mall_BusinessDiscountRequest].[ApproveUserMan],
	[Mall_BusinessDiscountRequest].[ApproveTime],
	[Mall_BusinessDiscountRequest].[ApproveRemark],
	[Mall_BusinessDiscountRequest].[StartTime],
	[Mall_BusinessDiscountRequest].[EndTime],
	[Mall_BusinessDiscountRequest].[IsActive]
) 
output 
	INSERTED.[ID],
	INSERTED.[BusinessID],
	INSERTED.[UserID],
	INSERTED.[RequestContent],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[Status],
	INSERTED.[ApproveUserMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[IsActive]
into @table
VALUES ( 
	@BusinessID,
	@UserID,
	@RequestContent,
	@AddTime,
	@AddUserMan,
	@Status,
	@ApproveUserMan,
	@ApproveTime,
	@ApproveRemark,
	@StartTime,
	@EndTime,
	@IsActive 
); 

SELECT 
	[ID],
	[BusinessID],
	[UserID],
	[RequestContent],
	[AddTime],
	[AddUserMan],
	[Status],
	[ApproveUserMan],
	[ApproveTime],
	[ApproveRemark],
	[StartTime],
	[EndTime],
	[IsActive] 
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
	[BusinessID] int,
	[UserID] int,
	[RequestContent] nvarchar(1000),
	[AddTime] datetime,
	[AddUserMan] nvarchar(100),
	[Status] int,
	[ApproveUserMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveRemark] nvarchar(1000),
	[StartTime] datetime,
	[EndTime] datetime,
	[IsActive] bit
);

UPDATE [dbo].[Mall_BusinessDiscountRequest] SET 
	[Mall_BusinessDiscountRequest].[BusinessID] = @BusinessID,
	[Mall_BusinessDiscountRequest].[UserID] = @UserID,
	[Mall_BusinessDiscountRequest].[RequestContent] = @RequestContent,
	[Mall_BusinessDiscountRequest].[AddTime] = @AddTime,
	[Mall_BusinessDiscountRequest].[AddUserMan] = @AddUserMan,
	[Mall_BusinessDiscountRequest].[Status] = @Status,
	[Mall_BusinessDiscountRequest].[ApproveUserMan] = @ApproveUserMan,
	[Mall_BusinessDiscountRequest].[ApproveTime] = @ApproveTime,
	[Mall_BusinessDiscountRequest].[ApproveRemark] = @ApproveRemark,
	[Mall_BusinessDiscountRequest].[StartTime] = @StartTime,
	[Mall_BusinessDiscountRequest].[EndTime] = @EndTime,
	[Mall_BusinessDiscountRequest].[IsActive] = @IsActive 
output 
	INSERTED.[ID],
	INSERTED.[BusinessID],
	INSERTED.[UserID],
	INSERTED.[RequestContent],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[Status],
	INSERTED.[ApproveUserMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[IsActive]
into @table
WHERE 
	[Mall_BusinessDiscountRequest].[ID] = @ID

SELECT 
	[ID],
	[BusinessID],
	[UserID],
	[RequestContent],
	[AddTime],
	[AddUserMan],
	[Status],
	[ApproveUserMan],
	[ApproveTime],
	[ApproveRemark],
	[StartTime],
	[EndTime],
	[IsActive] 
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
DELETE FROM [dbo].[Mall_BusinessDiscountRequest]
WHERE 
	[Mall_BusinessDiscountRequest].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_BusinessDiscountRequest() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_BusinessDiscountRequest(this.ID));
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
	[Mall_BusinessDiscountRequest].[ID],
	[Mall_BusinessDiscountRequest].[BusinessID],
	[Mall_BusinessDiscountRequest].[UserID],
	[Mall_BusinessDiscountRequest].[RequestContent],
	[Mall_BusinessDiscountRequest].[AddTime],
	[Mall_BusinessDiscountRequest].[AddUserMan],
	[Mall_BusinessDiscountRequest].[Status],
	[Mall_BusinessDiscountRequest].[ApproveUserMan],
	[Mall_BusinessDiscountRequest].[ApproveTime],
	[Mall_BusinessDiscountRequest].[ApproveRemark],
	[Mall_BusinessDiscountRequest].[StartTime],
	[Mall_BusinessDiscountRequest].[EndTime],
	[Mall_BusinessDiscountRequest].[IsActive]
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
                return "Mall_BusinessDiscountRequest";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_BusinessDiscountRequest into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="businessID">businessID</param>
		/// <param name="userID">userID</param>
		/// <param name="requestContent">requestContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="status">status</param>
		/// <param name="approveUserMan">approveUserMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="isActive">isActive</param>
		public static void InsertMall_BusinessDiscountRequest(int @businessID, int @userID, string @requestContent, DateTime @addTime, string @addUserMan, int @status, string @approveUserMan, DateTime @approveTime, string @approveRemark, DateTime @startTime, DateTime @endTime, bool @isActive)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_BusinessDiscountRequest(@businessID, @userID, @requestContent, @addTime, @addUserMan, @status, @approveUserMan, @approveTime, @approveRemark, @startTime, @endTime, @isActive, helper);
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
		/// Insert a Mall_BusinessDiscountRequest into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="businessID">businessID</param>
		/// <param name="userID">userID</param>
		/// <param name="requestContent">requestContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="status">status</param>
		/// <param name="approveUserMan">approveUserMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_BusinessDiscountRequest(int @businessID, int @userID, string @requestContent, DateTime @addTime, string @addUserMan, int @status, string @approveUserMan, DateTime @approveTime, string @approveRemark, DateTime @startTime, DateTime @endTime, bool @isActive, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BusinessID] int,
	[UserID] int,
	[RequestContent] nvarchar(1000),
	[AddTime] datetime,
	[AddUserMan] nvarchar(100),
	[Status] int,
	[ApproveUserMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveRemark] nvarchar(1000),
	[StartTime] datetime,
	[EndTime] datetime,
	[IsActive] bit
);

INSERT INTO [dbo].[Mall_BusinessDiscountRequest] (
	[Mall_BusinessDiscountRequest].[BusinessID],
	[Mall_BusinessDiscountRequest].[UserID],
	[Mall_BusinessDiscountRequest].[RequestContent],
	[Mall_BusinessDiscountRequest].[AddTime],
	[Mall_BusinessDiscountRequest].[AddUserMan],
	[Mall_BusinessDiscountRequest].[Status],
	[Mall_BusinessDiscountRequest].[ApproveUserMan],
	[Mall_BusinessDiscountRequest].[ApproveTime],
	[Mall_BusinessDiscountRequest].[ApproveRemark],
	[Mall_BusinessDiscountRequest].[StartTime],
	[Mall_BusinessDiscountRequest].[EndTime],
	[Mall_BusinessDiscountRequest].[IsActive]
) 
output 
	INSERTED.[ID],
	INSERTED.[BusinessID],
	INSERTED.[UserID],
	INSERTED.[RequestContent],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[Status],
	INSERTED.[ApproveUserMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[IsActive]
into @table
VALUES ( 
	@BusinessID,
	@UserID,
	@RequestContent,
	@AddTime,
	@AddUserMan,
	@Status,
	@ApproveUserMan,
	@ApproveTime,
	@ApproveRemark,
	@StartTime,
	@EndTime,
	@IsActive 
); 

SELECT 
	[ID],
	[BusinessID],
	[UserID],
	[RequestContent],
	[AddTime],
	[AddUserMan],
	[Status],
	[ApproveUserMan],
	[ApproveTime],
	[ApproveRemark],
	[StartTime],
	[EndTime],
	[IsActive] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@RequestContent", EntityBase.GetDatabaseValue(@requestContent)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserMan", EntityBase.GetDatabaseValue(@addUserMan)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@ApproveUserMan", EntityBase.GetDatabaseValue(@approveUserMan)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_BusinessDiscountRequest into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="businessID">businessID</param>
		/// <param name="userID">userID</param>
		/// <param name="requestContent">requestContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="status">status</param>
		/// <param name="approveUserMan">approveUserMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="isActive">isActive</param>
		public static void UpdateMall_BusinessDiscountRequest(int @iD, int @businessID, int @userID, string @requestContent, DateTime @addTime, string @addUserMan, int @status, string @approveUserMan, DateTime @approveTime, string @approveRemark, DateTime @startTime, DateTime @endTime, bool @isActive)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_BusinessDiscountRequest(@iD, @businessID, @userID, @requestContent, @addTime, @addUserMan, @status, @approveUserMan, @approveTime, @approveRemark, @startTime, @endTime, @isActive, helper);
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
		/// Updates a Mall_BusinessDiscountRequest into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="businessID">businessID</param>
		/// <param name="userID">userID</param>
		/// <param name="requestContent">requestContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="status">status</param>
		/// <param name="approveUserMan">approveUserMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_BusinessDiscountRequest(int @iD, int @businessID, int @userID, string @requestContent, DateTime @addTime, string @addUserMan, int @status, string @approveUserMan, DateTime @approveTime, string @approveRemark, DateTime @startTime, DateTime @endTime, bool @isActive, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BusinessID] int,
	[UserID] int,
	[RequestContent] nvarchar(1000),
	[AddTime] datetime,
	[AddUserMan] nvarchar(100),
	[Status] int,
	[ApproveUserMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveRemark] nvarchar(1000),
	[StartTime] datetime,
	[EndTime] datetime,
	[IsActive] bit
);

UPDATE [dbo].[Mall_BusinessDiscountRequest] SET 
	[Mall_BusinessDiscountRequest].[BusinessID] = @BusinessID,
	[Mall_BusinessDiscountRequest].[UserID] = @UserID,
	[Mall_BusinessDiscountRequest].[RequestContent] = @RequestContent,
	[Mall_BusinessDiscountRequest].[AddTime] = @AddTime,
	[Mall_BusinessDiscountRequest].[AddUserMan] = @AddUserMan,
	[Mall_BusinessDiscountRequest].[Status] = @Status,
	[Mall_BusinessDiscountRequest].[ApproveUserMan] = @ApproveUserMan,
	[Mall_BusinessDiscountRequest].[ApproveTime] = @ApproveTime,
	[Mall_BusinessDiscountRequest].[ApproveRemark] = @ApproveRemark,
	[Mall_BusinessDiscountRequest].[StartTime] = @StartTime,
	[Mall_BusinessDiscountRequest].[EndTime] = @EndTime,
	[Mall_BusinessDiscountRequest].[IsActive] = @IsActive 
output 
	INSERTED.[ID],
	INSERTED.[BusinessID],
	INSERTED.[UserID],
	INSERTED.[RequestContent],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[Status],
	INSERTED.[ApproveUserMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[IsActive]
into @table
WHERE 
	[Mall_BusinessDiscountRequest].[ID] = @ID

SELECT 
	[ID],
	[BusinessID],
	[UserID],
	[RequestContent],
	[AddTime],
	[AddUserMan],
	[Status],
	[ApproveUserMan],
	[ApproveTime],
	[ApproveRemark],
	[StartTime],
	[EndTime],
	[IsActive] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@RequestContent", EntityBase.GetDatabaseValue(@requestContent)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserMan", EntityBase.GetDatabaseValue(@addUserMan)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@ApproveUserMan", EntityBase.GetDatabaseValue(@approveUserMan)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_BusinessDiscountRequest from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_BusinessDiscountRequest(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_BusinessDiscountRequest(@iD, helper);
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
		/// Deletes a Mall_BusinessDiscountRequest from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_BusinessDiscountRequest(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_BusinessDiscountRequest]
WHERE 
	[Mall_BusinessDiscountRequest].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_BusinessDiscountRequest object.
		/// </summary>
		/// <returns>The newly created Mall_BusinessDiscountRequest object.</returns>
		public static Mall_BusinessDiscountRequest CreateMall_BusinessDiscountRequest()
		{
			return InitializeNew<Mall_BusinessDiscountRequest>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_BusinessDiscountRequest by a Mall_BusinessDiscountRequest's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_BusinessDiscountRequest</returns>
		public static Mall_BusinessDiscountRequest GetMall_BusinessDiscountRequest(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_BusinessDiscountRequest.SelectFieldList + @"
FROM [dbo].[Mall_BusinessDiscountRequest] 
WHERE 
	[Mall_BusinessDiscountRequest].[ID] = @ID " + Mall_BusinessDiscountRequest.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_BusinessDiscountRequest>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_BusinessDiscountRequest by a Mall_BusinessDiscountRequest's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_BusinessDiscountRequest</returns>
		public static Mall_BusinessDiscountRequest GetMall_BusinessDiscountRequest(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_BusinessDiscountRequest.SelectFieldList + @"
FROM [dbo].[Mall_BusinessDiscountRequest] 
WHERE 
	[Mall_BusinessDiscountRequest].[ID] = @ID " + Mall_BusinessDiscountRequest.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_BusinessDiscountRequest>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessDiscountRequest objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_BusinessDiscountRequest objects.</returns>
		public static EntityList<Mall_BusinessDiscountRequest> GetMall_BusinessDiscountRequests()
		{
			string commandText = @"
SELECT " + Mall_BusinessDiscountRequest.SelectFieldList + "FROM [dbo].[Mall_BusinessDiscountRequest] " + Mall_BusinessDiscountRequest.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_BusinessDiscountRequest>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_BusinessDiscountRequest objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_BusinessDiscountRequest objects.</returns>
        public static EntityList<Mall_BusinessDiscountRequest> GetMall_BusinessDiscountRequests(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_BusinessDiscountRequest>(SelectFieldList, "FROM [dbo].[Mall_BusinessDiscountRequest]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_BusinessDiscountRequest objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_BusinessDiscountRequest objects.</returns>
        public static EntityList<Mall_BusinessDiscountRequest> GetMall_BusinessDiscountRequests(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_BusinessDiscountRequest>(SelectFieldList, "FROM [dbo].[Mall_BusinessDiscountRequest]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_BusinessDiscountRequest objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_BusinessDiscountRequest objects.</returns>
		protected static EntityList<Mall_BusinessDiscountRequest> GetMall_BusinessDiscountRequests(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_BusinessDiscountRequests(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessDiscountRequest objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_BusinessDiscountRequest objects.</returns>
		protected static EntityList<Mall_BusinessDiscountRequest> GetMall_BusinessDiscountRequests(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_BusinessDiscountRequests(string.Empty, where, parameters, Mall_BusinessDiscountRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessDiscountRequest objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_BusinessDiscountRequest objects.</returns>
		protected static EntityList<Mall_BusinessDiscountRequest> GetMall_BusinessDiscountRequests(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_BusinessDiscountRequests(prefix, where, parameters, Mall_BusinessDiscountRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessDiscountRequest objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_BusinessDiscountRequest objects.</returns>
		protected static EntityList<Mall_BusinessDiscountRequest> GetMall_BusinessDiscountRequests(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_BusinessDiscountRequests(string.Empty, where, parameters, Mall_BusinessDiscountRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessDiscountRequest objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_BusinessDiscountRequest objects.</returns>
		protected static EntityList<Mall_BusinessDiscountRequest> GetMall_BusinessDiscountRequests(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_BusinessDiscountRequests(prefix, where, parameters, Mall_BusinessDiscountRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessDiscountRequest objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_BusinessDiscountRequest objects.</returns>
		protected static EntityList<Mall_BusinessDiscountRequest> GetMall_BusinessDiscountRequests(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_BusinessDiscountRequest.SelectFieldList + "FROM [dbo].[Mall_BusinessDiscountRequest] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_BusinessDiscountRequest>(reader);
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
        protected static EntityList<Mall_BusinessDiscountRequest> GetMall_BusinessDiscountRequests(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_BusinessDiscountRequest>(SelectFieldList, "FROM [dbo].[Mall_BusinessDiscountRequest] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_BusinessDiscountRequest objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_BusinessDiscountRequestCount()
        {
            return GetMall_BusinessDiscountRequestCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_BusinessDiscountRequest objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_BusinessDiscountRequestCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_BusinessDiscountRequest] " + where;

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
		public static partial class Mall_BusinessDiscountRequest_Properties
		{
			public const string ID = "ID";
			public const string BusinessID = "BusinessID";
			public const string UserID = "UserID";
			public const string RequestContent = "RequestContent";
			public const string AddTime = "AddTime";
			public const string AddUserMan = "AddUserMan";
			public const string Status = "Status";
			public const string ApproveUserMan = "ApproveUserMan";
			public const string ApproveTime = "ApproveTime";
			public const string ApproveRemark = "ApproveRemark";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string IsActive = "IsActive";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"BusinessID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"RequestContent" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserMan" , "string:"},
    			 {"Status" , "int:1-申请中 2-已生效 3-无效"},
    			 {"ApproveUserMan" , "string:"},
    			 {"ApproveTime" , "DateTime:"},
    			 {"ApproveRemark" , "string:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"IsActive" , "bool:"},
            };
		}
		#endregion
	}
}
