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
	/// This object represents the properties and methods of a Mall_DoorRemoteQrCodeLog.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_DoorRemoteQrCodeLog 
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
		private int _doorDeviceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int DoorDeviceID
		{
			[DebuggerStepThrough()]
			get { return this._doorDeviceID; }
			set 
			{
				if (this._doorDeviceID != value) 
				{
					this._doorDeviceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("DoorDeviceID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _openTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime OpenTime
		{
			[DebuggerStepThrough()]
			get { return this._openTime; }
			set 
			{
				if (this._openTime != value) 
				{
					this._openTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("OpenTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _openType = String.Empty;
		/// <summary>
		/// 2-为业主二维码开门 3-为门禁访客二维 4-为梯控访客二维码，5-远程开门 6-NFC开门
		/// </summary>
        [Description("2-为业主二维码开门 3-为门禁访客二维 4-为梯控访客二维码，5-远程开门 6-NFC开门")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string OpenType
		{
			[DebuggerStepThrough()]
			get { return this._openType; }
			set 
			{
				if (this._openType != value) 
				{
					this._openType = value;
					this.IsDirty = true;	
					OnPropertyChanged("OpenType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _lingLingID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string LingLingID
		{
			[DebuggerStepThrough()]
			get { return this._lingLingID; }
			set 
			{
				if (this._lingLingID != value) 
				{
					this._lingLingID = value;
					this.IsDirty = true;	
					OnPropertyChanged("LingLingID");
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
		[DataObjectField(false, false, true)]
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
	[DoorDeviceID] int,
	[OpenTime] datetime,
	[OpenType] nchar(10),
	[LingLingID] nvarchar(100),
	[AddTime] datetime
);

INSERT INTO [dbo].[Mall_DoorRemoteQrCodeLog] (
	[Mall_DoorRemoteQrCodeLog].[DoorDeviceID],
	[Mall_DoorRemoteQrCodeLog].[OpenTime],
	[Mall_DoorRemoteQrCodeLog].[OpenType],
	[Mall_DoorRemoteQrCodeLog].[LingLingID],
	[Mall_DoorRemoteQrCodeLog].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[DoorDeviceID],
	INSERTED.[OpenTime],
	INSERTED.[OpenType],
	INSERTED.[LingLingID],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@DoorDeviceID,
	@OpenTime,
	@OpenType,
	@LingLingID,
	@AddTime 
); 

SELECT 
	[ID],
	[DoorDeviceID],
	[OpenTime],
	[OpenType],
	[LingLingID],
	[AddTime] 
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
	[DoorDeviceID] int,
	[OpenTime] datetime,
	[OpenType] nchar(10),
	[LingLingID] nvarchar(100),
	[AddTime] datetime
);

UPDATE [dbo].[Mall_DoorRemoteQrCodeLog] SET 
	[Mall_DoorRemoteQrCodeLog].[DoorDeviceID] = @DoorDeviceID,
	[Mall_DoorRemoteQrCodeLog].[OpenTime] = @OpenTime,
	[Mall_DoorRemoteQrCodeLog].[OpenType] = @OpenType,
	[Mall_DoorRemoteQrCodeLog].[LingLingID] = @LingLingID,
	[Mall_DoorRemoteQrCodeLog].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[DoorDeviceID],
	INSERTED.[OpenTime],
	INSERTED.[OpenType],
	INSERTED.[LingLingID],
	INSERTED.[AddTime]
into @table
WHERE 
	[Mall_DoorRemoteQrCodeLog].[ID] = @ID

SELECT 
	[ID],
	[DoorDeviceID],
	[OpenTime],
	[OpenType],
	[LingLingID],
	[AddTime] 
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
DELETE FROM [dbo].[Mall_DoorRemoteQrCodeLog]
WHERE 
	[Mall_DoorRemoteQrCodeLog].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_DoorRemoteQrCodeLog() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_DoorRemoteQrCodeLog(this.ID));
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
	[Mall_DoorRemoteQrCodeLog].[ID],
	[Mall_DoorRemoteQrCodeLog].[DoorDeviceID],
	[Mall_DoorRemoteQrCodeLog].[OpenTime],
	[Mall_DoorRemoteQrCodeLog].[OpenType],
	[Mall_DoorRemoteQrCodeLog].[LingLingID],
	[Mall_DoorRemoteQrCodeLog].[AddTime]
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
                return "Mall_DoorRemoteQrCodeLog";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_DoorRemoteQrCodeLog into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="doorDeviceID">doorDeviceID</param>
		/// <param name="openTime">openTime</param>
		/// <param name="openType">openType</param>
		/// <param name="lingLingID">lingLingID</param>
		/// <param name="addTime">addTime</param>
		public static void InsertMall_DoorRemoteQrCodeLog(int @doorDeviceID, DateTime @openTime, string @openType, string @lingLingID, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_DoorRemoteQrCodeLog(@doorDeviceID, @openTime, @openType, @lingLingID, @addTime, helper);
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
		/// Insert a Mall_DoorRemoteQrCodeLog into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="doorDeviceID">doorDeviceID</param>
		/// <param name="openTime">openTime</param>
		/// <param name="openType">openType</param>
		/// <param name="lingLingID">lingLingID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_DoorRemoteQrCodeLog(int @doorDeviceID, DateTime @openTime, string @openType, string @lingLingID, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DoorDeviceID] int,
	[OpenTime] datetime,
	[OpenType] nchar(10),
	[LingLingID] nvarchar(100),
	[AddTime] datetime
);

INSERT INTO [dbo].[Mall_DoorRemoteQrCodeLog] (
	[Mall_DoorRemoteQrCodeLog].[DoorDeviceID],
	[Mall_DoorRemoteQrCodeLog].[OpenTime],
	[Mall_DoorRemoteQrCodeLog].[OpenType],
	[Mall_DoorRemoteQrCodeLog].[LingLingID],
	[Mall_DoorRemoteQrCodeLog].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[DoorDeviceID],
	INSERTED.[OpenTime],
	INSERTED.[OpenType],
	INSERTED.[LingLingID],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@DoorDeviceID,
	@OpenTime,
	@OpenType,
	@LingLingID,
	@AddTime 
); 

SELECT 
	[ID],
	[DoorDeviceID],
	[OpenTime],
	[OpenType],
	[LingLingID],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DoorDeviceID", EntityBase.GetDatabaseValue(@doorDeviceID)));
			parameters.Add(new SqlParameter("@OpenTime", EntityBase.GetDatabaseValue(@openTime)));
			parameters.Add(new SqlParameter("@OpenType", EntityBase.GetDatabaseValue(@openType)));
			parameters.Add(new SqlParameter("@LingLingID", EntityBase.GetDatabaseValue(@lingLingID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_DoorRemoteQrCodeLog into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="doorDeviceID">doorDeviceID</param>
		/// <param name="openTime">openTime</param>
		/// <param name="openType">openType</param>
		/// <param name="lingLingID">lingLingID</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateMall_DoorRemoteQrCodeLog(int @iD, int @doorDeviceID, DateTime @openTime, string @openType, string @lingLingID, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_DoorRemoteQrCodeLog(@iD, @doorDeviceID, @openTime, @openType, @lingLingID, @addTime, helper);
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
		/// Updates a Mall_DoorRemoteQrCodeLog into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="doorDeviceID">doorDeviceID</param>
		/// <param name="openTime">openTime</param>
		/// <param name="openType">openType</param>
		/// <param name="lingLingID">lingLingID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_DoorRemoteQrCodeLog(int @iD, int @doorDeviceID, DateTime @openTime, string @openType, string @lingLingID, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DoorDeviceID] int,
	[OpenTime] datetime,
	[OpenType] nchar(10),
	[LingLingID] nvarchar(100),
	[AddTime] datetime
);

UPDATE [dbo].[Mall_DoorRemoteQrCodeLog] SET 
	[Mall_DoorRemoteQrCodeLog].[DoorDeviceID] = @DoorDeviceID,
	[Mall_DoorRemoteQrCodeLog].[OpenTime] = @OpenTime,
	[Mall_DoorRemoteQrCodeLog].[OpenType] = @OpenType,
	[Mall_DoorRemoteQrCodeLog].[LingLingID] = @LingLingID,
	[Mall_DoorRemoteQrCodeLog].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[DoorDeviceID],
	INSERTED.[OpenTime],
	INSERTED.[OpenType],
	INSERTED.[LingLingID],
	INSERTED.[AddTime]
into @table
WHERE 
	[Mall_DoorRemoteQrCodeLog].[ID] = @ID

SELECT 
	[ID],
	[DoorDeviceID],
	[OpenTime],
	[OpenType],
	[LingLingID],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@DoorDeviceID", EntityBase.GetDatabaseValue(@doorDeviceID)));
			parameters.Add(new SqlParameter("@OpenTime", EntityBase.GetDatabaseValue(@openTime)));
			parameters.Add(new SqlParameter("@OpenType", EntityBase.GetDatabaseValue(@openType)));
			parameters.Add(new SqlParameter("@LingLingID", EntityBase.GetDatabaseValue(@lingLingID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_DoorRemoteQrCodeLog from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_DoorRemoteQrCodeLog(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_DoorRemoteQrCodeLog(@iD, helper);
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
		/// Deletes a Mall_DoorRemoteQrCodeLog from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_DoorRemoteQrCodeLog(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_DoorRemoteQrCodeLog]
WHERE 
	[Mall_DoorRemoteQrCodeLog].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_DoorRemoteQrCodeLog object.
		/// </summary>
		/// <returns>The newly created Mall_DoorRemoteQrCodeLog object.</returns>
		public static Mall_DoorRemoteQrCodeLog CreateMall_DoorRemoteQrCodeLog()
		{
			return InitializeNew<Mall_DoorRemoteQrCodeLog>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_DoorRemoteQrCodeLog by a Mall_DoorRemoteQrCodeLog's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_DoorRemoteQrCodeLog</returns>
		public static Mall_DoorRemoteQrCodeLog GetMall_DoorRemoteQrCodeLog(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_DoorRemoteQrCodeLog.SelectFieldList + @"
FROM [dbo].[Mall_DoorRemoteQrCodeLog] 
WHERE 
	[Mall_DoorRemoteQrCodeLog].[ID] = @ID " + Mall_DoorRemoteQrCodeLog.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_DoorRemoteQrCodeLog>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_DoorRemoteQrCodeLog by a Mall_DoorRemoteQrCodeLog's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_DoorRemoteQrCodeLog</returns>
		public static Mall_DoorRemoteQrCodeLog GetMall_DoorRemoteQrCodeLog(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_DoorRemoteQrCodeLog.SelectFieldList + @"
FROM [dbo].[Mall_DoorRemoteQrCodeLog] 
WHERE 
	[Mall_DoorRemoteQrCodeLog].[ID] = @ID " + Mall_DoorRemoteQrCodeLog.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_DoorRemoteQrCodeLog>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteQrCodeLog objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_DoorRemoteQrCodeLog objects.</returns>
		public static EntityList<Mall_DoorRemoteQrCodeLog> GetMall_DoorRemoteQrCodeLogs()
		{
			string commandText = @"
SELECT " + Mall_DoorRemoteQrCodeLog.SelectFieldList + "FROM [dbo].[Mall_DoorRemoteQrCodeLog] " + Mall_DoorRemoteQrCodeLog.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_DoorRemoteQrCodeLog>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_DoorRemoteQrCodeLog objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_DoorRemoteQrCodeLog objects.</returns>
        public static EntityList<Mall_DoorRemoteQrCodeLog> GetMall_DoorRemoteQrCodeLogs(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorRemoteQrCodeLog>(SelectFieldList, "FROM [dbo].[Mall_DoorRemoteQrCodeLog]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_DoorRemoteQrCodeLog objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_DoorRemoteQrCodeLog objects.</returns>
        public static EntityList<Mall_DoorRemoteQrCodeLog> GetMall_DoorRemoteQrCodeLogs(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorRemoteQrCodeLog>(SelectFieldList, "FROM [dbo].[Mall_DoorRemoteQrCodeLog]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteQrCodeLog objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteQrCodeLog objects.</returns>
		protected static EntityList<Mall_DoorRemoteQrCodeLog> GetMall_DoorRemoteQrCodeLogs(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorRemoteQrCodeLogs(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteQrCodeLog objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteQrCodeLog objects.</returns>
		protected static EntityList<Mall_DoorRemoteQrCodeLog> GetMall_DoorRemoteQrCodeLogs(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorRemoteQrCodeLogs(string.Empty, where, parameters, Mall_DoorRemoteQrCodeLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteQrCodeLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteQrCodeLog objects.</returns>
		protected static EntityList<Mall_DoorRemoteQrCodeLog> GetMall_DoorRemoteQrCodeLogs(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorRemoteQrCodeLogs(prefix, where, parameters, Mall_DoorRemoteQrCodeLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteQrCodeLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteQrCodeLog objects.</returns>
		protected static EntityList<Mall_DoorRemoteQrCodeLog> GetMall_DoorRemoteQrCodeLogs(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_DoorRemoteQrCodeLogs(string.Empty, where, parameters, Mall_DoorRemoteQrCodeLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteQrCodeLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteQrCodeLog objects.</returns>
		protected static EntityList<Mall_DoorRemoteQrCodeLog> GetMall_DoorRemoteQrCodeLogs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_DoorRemoteQrCodeLogs(prefix, where, parameters, Mall_DoorRemoteQrCodeLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteQrCodeLog objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteQrCodeLog objects.</returns>
		protected static EntityList<Mall_DoorRemoteQrCodeLog> GetMall_DoorRemoteQrCodeLogs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_DoorRemoteQrCodeLog.SelectFieldList + "FROM [dbo].[Mall_DoorRemoteQrCodeLog] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_DoorRemoteQrCodeLog>(reader);
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
        protected static EntityList<Mall_DoorRemoteQrCodeLog> GetMall_DoorRemoteQrCodeLogs(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorRemoteQrCodeLog>(SelectFieldList, "FROM [dbo].[Mall_DoorRemoteQrCodeLog] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_DoorRemoteQrCodeLog objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_DoorRemoteQrCodeLogCount()
        {
            return GetMall_DoorRemoteQrCodeLogCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_DoorRemoteQrCodeLog objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_DoorRemoteQrCodeLogCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_DoorRemoteQrCodeLog] " + where;

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
		public static partial class Mall_DoorRemoteQrCodeLog_Properties
		{
			public const string ID = "ID";
			public const string DoorDeviceID = "DoorDeviceID";
			public const string OpenTime = "OpenTime";
			public const string OpenType = "OpenType";
			public const string LingLingID = "LingLingID";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"DoorDeviceID" , "int:"},
    			 {"OpenTime" , "DateTime:"},
    			 {"OpenType" , "string:2-为业主二维码开门 3-为门禁访客二维 4-为梯控访客二维码，5-远程开门 6-NFC开门"},
    			 {"LingLingID" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
