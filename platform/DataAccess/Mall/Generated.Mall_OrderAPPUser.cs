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
	/// This object represents the properties and methods of a Mall_OrderAPPUser.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_OrderAPPUser 
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
		private int _orderID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int OrderID
		{
			[DebuggerStepThrough()]
			get { return this._orderID; }
			set 
			{
				if (this._orderID != value) 
				{
					this._orderID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderID");
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
		private DateTime _sendTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime SendTime
		{
			[DebuggerStepThrough()]
			get { return this._sendTime; }
			set 
			{
				if (this._sendTime != value) 
				{
					this._sendTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("SendTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAPPShow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsAPPShow
		{
			[DebuggerStepThrough()]
			get { return this._isAPPShow; }
			set 
			{
				if (this._isAPPShow != value) 
				{
					this._isAPPShow = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAPPShow");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAPPSend = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsAPPSend
		{
			[DebuggerStepThrough()]
			get { return this._isAPPSend; }
			set 
			{
				if (this._isAPPSend != value) 
				{
					this._isAPPSend = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAPPSend");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _appSendTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime AppSendTime
		{
			[DebuggerStepThrough()]
			get { return this._appSendTime; }
			set 
			{
				if (this._appSendTime != value) 
				{
					this._appSendTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("AppSendTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _aPPSendResult = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string APPSendResult
		{
			[DebuggerStepThrough()]
			get { return this._aPPSendResult; }
			set 
			{
				if (this._aPPSendResult != value) 
				{
					this._aPPSendResult = value;
					this.IsDirty = true;	
					OnPropertyChanged("APPSendResult");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _accpetStatus = int.MinValue;
		/// <summary>
        /// 0-未发送 1-已接收 2-拒绝接受 3-重新派发 4-待接收
		/// </summary>
        [Description("0-未发送 1-已接收 2-拒绝接受 3-重新派发 4-待接收")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int AccpetStatus
		{
			[DebuggerStepThrough()]
			get { return this._accpetStatus; }
			set 
			{
				if (this._accpetStatus != value) 
				{
					this._accpetStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("AccpetStatus");
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
		private DateTime _accpetTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime AccpetTime
		{
			[DebuggerStepThrough()]
			get { return this._accpetTime; }
			set 
			{
				if (this._accpetTime != value) 
				{
					this._accpetTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("AccpetTime");
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
	[OrderID] int,
	[UserID] int,
	[SendTime] datetime,
	[IsAPPShow] bit,
	[IsAPPSend] bit,
	[AppSendTime] datetime,
	[APPSendResult] ntext,
	[AccpetStatus] int,
	[AddTime] datetime,
	[AddUserMan] nvarchar(200),
	[AccpetTime] datetime
);

INSERT INTO [dbo].[Mall_OrderAPPUser] (
	[Mall_OrderAPPUser].[OrderID],
	[Mall_OrderAPPUser].[UserID],
	[Mall_OrderAPPUser].[SendTime],
	[Mall_OrderAPPUser].[IsAPPShow],
	[Mall_OrderAPPUser].[IsAPPSend],
	[Mall_OrderAPPUser].[AppSendTime],
	[Mall_OrderAPPUser].[APPSendResult],
	[Mall_OrderAPPUser].[AccpetStatus],
	[Mall_OrderAPPUser].[AddTime],
	[Mall_OrderAPPUser].[AddUserMan],
	[Mall_OrderAPPUser].[AccpetTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[UserID],
	INSERTED.[SendTime],
	INSERTED.[IsAPPShow],
	INSERTED.[IsAPPSend],
	INSERTED.[AppSendTime],
	INSERTED.[APPSendResult],
	INSERTED.[AccpetStatus],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[AccpetTime]
into @table
VALUES ( 
	@OrderID,
	@UserID,
	@SendTime,
	@IsAPPShow,
	@IsAPPSend,
	@AppSendTime,
	@APPSendResult,
	@AccpetStatus,
	@AddTime,
	@AddUserMan,
	@AccpetTime 
); 

SELECT 
	[ID],
	[OrderID],
	[UserID],
	[SendTime],
	[IsAPPShow],
	[IsAPPSend],
	[AppSendTime],
	[APPSendResult],
	[AccpetStatus],
	[AddTime],
	[AddUserMan],
	[AccpetTime] 
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
	[OrderID] int,
	[UserID] int,
	[SendTime] datetime,
	[IsAPPShow] bit,
	[IsAPPSend] bit,
	[AppSendTime] datetime,
	[APPSendResult] ntext,
	[AccpetStatus] int,
	[AddTime] datetime,
	[AddUserMan] nvarchar(200),
	[AccpetTime] datetime
);

UPDATE [dbo].[Mall_OrderAPPUser] SET 
	[Mall_OrderAPPUser].[OrderID] = @OrderID,
	[Mall_OrderAPPUser].[UserID] = @UserID,
	[Mall_OrderAPPUser].[SendTime] = @SendTime,
	[Mall_OrderAPPUser].[IsAPPShow] = @IsAPPShow,
	[Mall_OrderAPPUser].[IsAPPSend] = @IsAPPSend,
	[Mall_OrderAPPUser].[AppSendTime] = @AppSendTime,
	[Mall_OrderAPPUser].[APPSendResult] = @APPSendResult,
	[Mall_OrderAPPUser].[AccpetStatus] = @AccpetStatus,
	[Mall_OrderAPPUser].[AddTime] = @AddTime,
	[Mall_OrderAPPUser].[AddUserMan] = @AddUserMan,
	[Mall_OrderAPPUser].[AccpetTime] = @AccpetTime 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[UserID],
	INSERTED.[SendTime],
	INSERTED.[IsAPPShow],
	INSERTED.[IsAPPSend],
	INSERTED.[AppSendTime],
	INSERTED.[APPSendResult],
	INSERTED.[AccpetStatus],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[AccpetTime]
into @table
WHERE 
	[Mall_OrderAPPUser].[ID] = @ID

SELECT 
	[ID],
	[OrderID],
	[UserID],
	[SendTime],
	[IsAPPShow],
	[IsAPPSend],
	[AppSendTime],
	[APPSendResult],
	[AccpetStatus],
	[AddTime],
	[AddUserMan],
	[AccpetTime] 
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
DELETE FROM [dbo].[Mall_OrderAPPUser]
WHERE 
	[Mall_OrderAPPUser].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_OrderAPPUser() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_OrderAPPUser(this.ID));
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
	[Mall_OrderAPPUser].[ID],
	[Mall_OrderAPPUser].[OrderID],
	[Mall_OrderAPPUser].[UserID],
	[Mall_OrderAPPUser].[SendTime],
	[Mall_OrderAPPUser].[IsAPPShow],
	[Mall_OrderAPPUser].[IsAPPSend],
	[Mall_OrderAPPUser].[AppSendTime],
	[Mall_OrderAPPUser].[APPSendResult],
	[Mall_OrderAPPUser].[AccpetStatus],
	[Mall_OrderAPPUser].[AddTime],
	[Mall_OrderAPPUser].[AddUserMan],
	[Mall_OrderAPPUser].[AccpetTime]
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
                return "Mall_OrderAPPUser";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_OrderAPPUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderID">orderID</param>
		/// <param name="userID">userID</param>
		/// <param name="sendTime">sendTime</param>
		/// <param name="isAPPShow">isAPPShow</param>
		/// <param name="isAPPSend">isAPPSend</param>
		/// <param name="appSendTime">appSendTime</param>
		/// <param name="aPPSendResult">aPPSendResult</param>
		/// <param name="accpetStatus">accpetStatus</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="accpetTime">accpetTime</param>
		public static void InsertMall_OrderAPPUser(int @orderID, int @userID, DateTime @sendTime, bool @isAPPShow, bool @isAPPSend, DateTime @appSendTime, string @aPPSendResult, int @accpetStatus, DateTime @addTime, string @addUserMan, DateTime @accpetTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_OrderAPPUser(@orderID, @userID, @sendTime, @isAPPShow, @isAPPSend, @appSendTime, @aPPSendResult, @accpetStatus, @addTime, @addUserMan, @accpetTime, helper);
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
		/// Insert a Mall_OrderAPPUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderID">orderID</param>
		/// <param name="userID">userID</param>
		/// <param name="sendTime">sendTime</param>
		/// <param name="isAPPShow">isAPPShow</param>
		/// <param name="isAPPSend">isAPPSend</param>
		/// <param name="appSendTime">appSendTime</param>
		/// <param name="aPPSendResult">aPPSendResult</param>
		/// <param name="accpetStatus">accpetStatus</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="accpetTime">accpetTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_OrderAPPUser(int @orderID, int @userID, DateTime @sendTime, bool @isAPPShow, bool @isAPPSend, DateTime @appSendTime, string @aPPSendResult, int @accpetStatus, DateTime @addTime, string @addUserMan, DateTime @accpetTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrderID] int,
	[UserID] int,
	[SendTime] datetime,
	[IsAPPShow] bit,
	[IsAPPSend] bit,
	[AppSendTime] datetime,
	[APPSendResult] ntext,
	[AccpetStatus] int,
	[AddTime] datetime,
	[AddUserMan] nvarchar(200),
	[AccpetTime] datetime
);

INSERT INTO [dbo].[Mall_OrderAPPUser] (
	[Mall_OrderAPPUser].[OrderID],
	[Mall_OrderAPPUser].[UserID],
	[Mall_OrderAPPUser].[SendTime],
	[Mall_OrderAPPUser].[IsAPPShow],
	[Mall_OrderAPPUser].[IsAPPSend],
	[Mall_OrderAPPUser].[AppSendTime],
	[Mall_OrderAPPUser].[APPSendResult],
	[Mall_OrderAPPUser].[AccpetStatus],
	[Mall_OrderAPPUser].[AddTime],
	[Mall_OrderAPPUser].[AddUserMan],
	[Mall_OrderAPPUser].[AccpetTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[UserID],
	INSERTED.[SendTime],
	INSERTED.[IsAPPShow],
	INSERTED.[IsAPPSend],
	INSERTED.[AppSendTime],
	INSERTED.[APPSendResult],
	INSERTED.[AccpetStatus],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[AccpetTime]
into @table
VALUES ( 
	@OrderID,
	@UserID,
	@SendTime,
	@IsAPPShow,
	@IsAPPSend,
	@AppSendTime,
	@APPSendResult,
	@AccpetStatus,
	@AddTime,
	@AddUserMan,
	@AccpetTime 
); 

SELECT 
	[ID],
	[OrderID],
	[UserID],
	[SendTime],
	[IsAPPShow],
	[IsAPPSend],
	[AppSendTime],
	[APPSendResult],
	[AccpetStatus],
	[AddTime],
	[AddUserMan],
	[AccpetTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OrderID", EntityBase.GetDatabaseValue(@orderID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@SendTime", EntityBase.GetDatabaseValue(@sendTime)));
			parameters.Add(new SqlParameter("@IsAPPShow", @isAPPShow));
			parameters.Add(new SqlParameter("@IsAPPSend", @isAPPSend));
			parameters.Add(new SqlParameter("@AppSendTime", EntityBase.GetDatabaseValue(@appSendTime)));
			parameters.Add(new SqlParameter("@APPSendResult", EntityBase.GetDatabaseValue(@aPPSendResult)));
			parameters.Add(new SqlParameter("@AccpetStatus", EntityBase.GetDatabaseValue(@accpetStatus)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserMan", EntityBase.GetDatabaseValue(@addUserMan)));
			parameters.Add(new SqlParameter("@AccpetTime", EntityBase.GetDatabaseValue(@accpetTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_OrderAPPUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orderID">orderID</param>
		/// <param name="userID">userID</param>
		/// <param name="sendTime">sendTime</param>
		/// <param name="isAPPShow">isAPPShow</param>
		/// <param name="isAPPSend">isAPPSend</param>
		/// <param name="appSendTime">appSendTime</param>
		/// <param name="aPPSendResult">aPPSendResult</param>
		/// <param name="accpetStatus">accpetStatus</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="accpetTime">accpetTime</param>
		public static void UpdateMall_OrderAPPUser(int @iD, int @orderID, int @userID, DateTime @sendTime, bool @isAPPShow, bool @isAPPSend, DateTime @appSendTime, string @aPPSendResult, int @accpetStatus, DateTime @addTime, string @addUserMan, DateTime @accpetTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_OrderAPPUser(@iD, @orderID, @userID, @sendTime, @isAPPShow, @isAPPSend, @appSendTime, @aPPSendResult, @accpetStatus, @addTime, @addUserMan, @accpetTime, helper);
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
		/// Updates a Mall_OrderAPPUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orderID">orderID</param>
		/// <param name="userID">userID</param>
		/// <param name="sendTime">sendTime</param>
		/// <param name="isAPPShow">isAPPShow</param>
		/// <param name="isAPPSend">isAPPSend</param>
		/// <param name="appSendTime">appSendTime</param>
		/// <param name="aPPSendResult">aPPSendResult</param>
		/// <param name="accpetStatus">accpetStatus</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="accpetTime">accpetTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_OrderAPPUser(int @iD, int @orderID, int @userID, DateTime @sendTime, bool @isAPPShow, bool @isAPPSend, DateTime @appSendTime, string @aPPSendResult, int @accpetStatus, DateTime @addTime, string @addUserMan, DateTime @accpetTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrderID] int,
	[UserID] int,
	[SendTime] datetime,
	[IsAPPShow] bit,
	[IsAPPSend] bit,
	[AppSendTime] datetime,
	[APPSendResult] ntext,
	[AccpetStatus] int,
	[AddTime] datetime,
	[AddUserMan] nvarchar(200),
	[AccpetTime] datetime
);

UPDATE [dbo].[Mall_OrderAPPUser] SET 
	[Mall_OrderAPPUser].[OrderID] = @OrderID,
	[Mall_OrderAPPUser].[UserID] = @UserID,
	[Mall_OrderAPPUser].[SendTime] = @SendTime,
	[Mall_OrderAPPUser].[IsAPPShow] = @IsAPPShow,
	[Mall_OrderAPPUser].[IsAPPSend] = @IsAPPSend,
	[Mall_OrderAPPUser].[AppSendTime] = @AppSendTime,
	[Mall_OrderAPPUser].[APPSendResult] = @APPSendResult,
	[Mall_OrderAPPUser].[AccpetStatus] = @AccpetStatus,
	[Mall_OrderAPPUser].[AddTime] = @AddTime,
	[Mall_OrderAPPUser].[AddUserMan] = @AddUserMan,
	[Mall_OrderAPPUser].[AccpetTime] = @AccpetTime 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[UserID],
	INSERTED.[SendTime],
	INSERTED.[IsAPPShow],
	INSERTED.[IsAPPSend],
	INSERTED.[AppSendTime],
	INSERTED.[APPSendResult],
	INSERTED.[AccpetStatus],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[AccpetTime]
into @table
WHERE 
	[Mall_OrderAPPUser].[ID] = @ID

SELECT 
	[ID],
	[OrderID],
	[UserID],
	[SendTime],
	[IsAPPShow],
	[IsAPPSend],
	[AppSendTime],
	[APPSendResult],
	[AccpetStatus],
	[AddTime],
	[AddUserMan],
	[AccpetTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OrderID", EntityBase.GetDatabaseValue(@orderID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@SendTime", EntityBase.GetDatabaseValue(@sendTime)));
			parameters.Add(new SqlParameter("@IsAPPShow", @isAPPShow));
			parameters.Add(new SqlParameter("@IsAPPSend", @isAPPSend));
			parameters.Add(new SqlParameter("@AppSendTime", EntityBase.GetDatabaseValue(@appSendTime)));
			parameters.Add(new SqlParameter("@APPSendResult", EntityBase.GetDatabaseValue(@aPPSendResult)));
			parameters.Add(new SqlParameter("@AccpetStatus", EntityBase.GetDatabaseValue(@accpetStatus)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserMan", EntityBase.GetDatabaseValue(@addUserMan)));
			parameters.Add(new SqlParameter("@AccpetTime", EntityBase.GetDatabaseValue(@accpetTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_OrderAPPUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_OrderAPPUser(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_OrderAPPUser(@iD, helper);
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
		/// Deletes a Mall_OrderAPPUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_OrderAPPUser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_OrderAPPUser]
WHERE 
	[Mall_OrderAPPUser].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_OrderAPPUser object.
		/// </summary>
		/// <returns>The newly created Mall_OrderAPPUser object.</returns>
		public static Mall_OrderAPPUser CreateMall_OrderAPPUser()
		{
			return InitializeNew<Mall_OrderAPPUser>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_OrderAPPUser by a Mall_OrderAPPUser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_OrderAPPUser</returns>
		public static Mall_OrderAPPUser GetMall_OrderAPPUser(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_OrderAPPUser.SelectFieldList + @"
FROM [dbo].[Mall_OrderAPPUser] 
WHERE 
	[Mall_OrderAPPUser].[ID] = @ID " + Mall_OrderAPPUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_OrderAPPUser>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_OrderAPPUser by a Mall_OrderAPPUser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_OrderAPPUser</returns>
		public static Mall_OrderAPPUser GetMall_OrderAPPUser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_OrderAPPUser.SelectFieldList + @"
FROM [dbo].[Mall_OrderAPPUser] 
WHERE 
	[Mall_OrderAPPUser].[ID] = @ID " + Mall_OrderAPPUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_OrderAPPUser>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderAPPUser objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_OrderAPPUser objects.</returns>
		public static EntityList<Mall_OrderAPPUser> GetMall_OrderAPPUsers()
		{
			string commandText = @"
SELECT " + Mall_OrderAPPUser.SelectFieldList + "FROM [dbo].[Mall_OrderAPPUser] " + Mall_OrderAPPUser.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_OrderAPPUser>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_OrderAPPUser objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_OrderAPPUser objects.</returns>
        public static EntityList<Mall_OrderAPPUser> GetMall_OrderAPPUsers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_OrderAPPUser>(SelectFieldList, "FROM [dbo].[Mall_OrderAPPUser]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_OrderAPPUser objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_OrderAPPUser objects.</returns>
        public static EntityList<Mall_OrderAPPUser> GetMall_OrderAPPUsers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_OrderAPPUser>(SelectFieldList, "FROM [dbo].[Mall_OrderAPPUser]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_OrderAPPUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_OrderAPPUser objects.</returns>
		protected static EntityList<Mall_OrderAPPUser> GetMall_OrderAPPUsers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_OrderAPPUsers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderAPPUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderAPPUser objects.</returns>
		protected static EntityList<Mall_OrderAPPUser> GetMall_OrderAPPUsers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_OrderAPPUsers(string.Empty, where, parameters, Mall_OrderAPPUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderAPPUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderAPPUser objects.</returns>
		protected static EntityList<Mall_OrderAPPUser> GetMall_OrderAPPUsers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_OrderAPPUsers(prefix, where, parameters, Mall_OrderAPPUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderAPPUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderAPPUser objects.</returns>
		protected static EntityList<Mall_OrderAPPUser> GetMall_OrderAPPUsers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_OrderAPPUsers(string.Empty, where, parameters, Mall_OrderAPPUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderAPPUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderAPPUser objects.</returns>
		protected static EntityList<Mall_OrderAPPUser> GetMall_OrderAPPUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_OrderAPPUsers(prefix, where, parameters, Mall_OrderAPPUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderAPPUser objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_OrderAPPUser objects.</returns>
		protected static EntityList<Mall_OrderAPPUser> GetMall_OrderAPPUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_OrderAPPUser.SelectFieldList + "FROM [dbo].[Mall_OrderAPPUser] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_OrderAPPUser>(reader);
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
        protected static EntityList<Mall_OrderAPPUser> GetMall_OrderAPPUsers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_OrderAPPUser>(SelectFieldList, "FROM [dbo].[Mall_OrderAPPUser] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_OrderAPPUser objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_OrderAPPUserCount()
        {
            return GetMall_OrderAPPUserCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_OrderAPPUser objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_OrderAPPUserCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_OrderAPPUser] " + where;

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
		public static partial class Mall_OrderAPPUser_Properties
		{
			public const string ID = "ID";
			public const string OrderID = "OrderID";
			public const string UserID = "UserID";
			public const string SendTime = "SendTime";
			public const string IsAPPShow = "IsAPPShow";
			public const string IsAPPSend = "IsAPPSend";
			public const string AppSendTime = "AppSendTime";
			public const string APPSendResult = "APPSendResult";
			public const string AccpetStatus = "AccpetStatus";
			public const string AddTime = "AddTime";
			public const string AddUserMan = "AddUserMan";
			public const string AccpetTime = "AccpetTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OrderID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"SendTime" , "DateTime:"},
    			 {"IsAPPShow" , "bool:"},
    			 {"IsAPPSend" , "bool:"},
    			 {"AppSendTime" , "DateTime:"},
    			 {"APPSendResult" , "string:"},
    			 {"AccpetStatus" , "int:0-未接收 1-已接收 2-拒绝接受 3-重新派发"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserMan" , "string:"},
    			 {"AccpetTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
