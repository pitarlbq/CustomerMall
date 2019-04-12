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
	/// This object represents the properties and methods of a Mall_DoorOpenLog.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_DoorOpenLog 
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
		private int _deviceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int DeviceID
		{
			[DebuggerStepThrough()]
			get { return this._deviceID; }
			set 
			{
				if (this._deviceID != value) 
				{
					this._deviceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeviceID");
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
		private int _openType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OpenType
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
		private string _lingLingId = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string LingLingId
		{
			[DebuggerStepThrough()]
			get { return this._lingLingId; }
			set 
			{
				if (this._lingLingId != value) 
				{
					this._lingLingId = value;
					this.IsDirty = true;	
					OnPropertyChanged("LingLingId");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _openTimeSpan = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal OpenTimeSpan
		{
			[DebuggerStepThrough()]
			get { return this._openTimeSpan; }
			set 
			{
				if (this._openTimeSpan != value) 
				{
					this._openTimeSpan = value;
					this.IsDirty = true;	
					OnPropertyChanged("OpenTimeSpan");
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
	[DeviceID] int,
	[OpenTime] datetime,
	[OpenType] int,
	[LingLingId] nvarchar(200),
	[OpenTimeSpan] decimal(30, 0)
);

INSERT INTO [dbo].[Mall_DoorOpenLog] (
	[Mall_DoorOpenLog].[DeviceID],
	[Mall_DoorOpenLog].[OpenTime],
	[Mall_DoorOpenLog].[OpenType],
	[Mall_DoorOpenLog].[LingLingId],
	[Mall_DoorOpenLog].[OpenTimeSpan]
) 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[OpenTime],
	INSERTED.[OpenType],
	INSERTED.[LingLingId],
	INSERTED.[OpenTimeSpan]
into @table
VALUES ( 
	@DeviceID,
	@OpenTime,
	@OpenType,
	@LingLingId,
	@OpenTimeSpan 
); 

SELECT 
	[ID],
	[DeviceID],
	[OpenTime],
	[OpenType],
	[LingLingId],
	[OpenTimeSpan] 
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
	[DeviceID] int,
	[OpenTime] datetime,
	[OpenType] int,
	[LingLingId] nvarchar(200),
	[OpenTimeSpan] decimal(30, 0)
);

UPDATE [dbo].[Mall_DoorOpenLog] SET 
	[Mall_DoorOpenLog].[DeviceID] = @DeviceID,
	[Mall_DoorOpenLog].[OpenTime] = @OpenTime,
	[Mall_DoorOpenLog].[OpenType] = @OpenType,
	[Mall_DoorOpenLog].[LingLingId] = @LingLingId,
	[Mall_DoorOpenLog].[OpenTimeSpan] = @OpenTimeSpan 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[OpenTime],
	INSERTED.[OpenType],
	INSERTED.[LingLingId],
	INSERTED.[OpenTimeSpan]
into @table
WHERE 
	[Mall_DoorOpenLog].[ID] = @ID

SELECT 
	[ID],
	[DeviceID],
	[OpenTime],
	[OpenType],
	[LingLingId],
	[OpenTimeSpan] 
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
DELETE FROM [dbo].[Mall_DoorOpenLog]
WHERE 
	[Mall_DoorOpenLog].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_DoorOpenLog() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_DoorOpenLog(this.ID));
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
	[Mall_DoorOpenLog].[ID],
	[Mall_DoorOpenLog].[DeviceID],
	[Mall_DoorOpenLog].[OpenTime],
	[Mall_DoorOpenLog].[OpenType],
	[Mall_DoorOpenLog].[LingLingId],
	[Mall_DoorOpenLog].[OpenTimeSpan]
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
                return "Mall_DoorOpenLog";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_DoorOpenLog into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="deviceID">deviceID</param>
		/// <param name="openTime">openTime</param>
		/// <param name="openType">openType</param>
		/// <param name="lingLingId">lingLingId</param>
		/// <param name="openTimeSpan">openTimeSpan</param>
		public static void InsertMall_DoorOpenLog(int @deviceID, DateTime @openTime, int @openType, string @lingLingId, decimal @openTimeSpan)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_DoorOpenLog(@deviceID, @openTime, @openType, @lingLingId, @openTimeSpan, helper);
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
		/// Insert a Mall_DoorOpenLog into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="deviceID">deviceID</param>
		/// <param name="openTime">openTime</param>
		/// <param name="openType">openType</param>
		/// <param name="lingLingId">lingLingId</param>
		/// <param name="openTimeSpan">openTimeSpan</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_DoorOpenLog(int @deviceID, DateTime @openTime, int @openType, string @lingLingId, decimal @openTimeSpan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DeviceID] int,
	[OpenTime] datetime,
	[OpenType] int,
	[LingLingId] nvarchar(200),
	[OpenTimeSpan] decimal(30, 0)
);

INSERT INTO [dbo].[Mall_DoorOpenLog] (
	[Mall_DoorOpenLog].[DeviceID],
	[Mall_DoorOpenLog].[OpenTime],
	[Mall_DoorOpenLog].[OpenType],
	[Mall_DoorOpenLog].[LingLingId],
	[Mall_DoorOpenLog].[OpenTimeSpan]
) 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[OpenTime],
	INSERTED.[OpenType],
	INSERTED.[LingLingId],
	INSERTED.[OpenTimeSpan]
into @table
VALUES ( 
	@DeviceID,
	@OpenTime,
	@OpenType,
	@LingLingId,
	@OpenTimeSpan 
); 

SELECT 
	[ID],
	[DeviceID],
	[OpenTime],
	[OpenType],
	[LingLingId],
	[OpenTimeSpan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DeviceID", EntityBase.GetDatabaseValue(@deviceID)));
			parameters.Add(new SqlParameter("@OpenTime", EntityBase.GetDatabaseValue(@openTime)));
			parameters.Add(new SqlParameter("@OpenType", EntityBase.GetDatabaseValue(@openType)));
			parameters.Add(new SqlParameter("@LingLingId", EntityBase.GetDatabaseValue(@lingLingId)));
			parameters.Add(new SqlParameter("@OpenTimeSpan", EntityBase.GetDatabaseValue(@openTimeSpan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_DoorOpenLog into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="deviceID">deviceID</param>
		/// <param name="openTime">openTime</param>
		/// <param name="openType">openType</param>
		/// <param name="lingLingId">lingLingId</param>
		/// <param name="openTimeSpan">openTimeSpan</param>
		public static void UpdateMall_DoorOpenLog(int @iD, int @deviceID, DateTime @openTime, int @openType, string @lingLingId, decimal @openTimeSpan)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_DoorOpenLog(@iD, @deviceID, @openTime, @openType, @lingLingId, @openTimeSpan, helper);
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
		/// Updates a Mall_DoorOpenLog into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="deviceID">deviceID</param>
		/// <param name="openTime">openTime</param>
		/// <param name="openType">openType</param>
		/// <param name="lingLingId">lingLingId</param>
		/// <param name="openTimeSpan">openTimeSpan</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_DoorOpenLog(int @iD, int @deviceID, DateTime @openTime, int @openType, string @lingLingId, decimal @openTimeSpan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DeviceID] int,
	[OpenTime] datetime,
	[OpenType] int,
	[LingLingId] nvarchar(200),
	[OpenTimeSpan] decimal(30, 0)
);

UPDATE [dbo].[Mall_DoorOpenLog] SET 
	[Mall_DoorOpenLog].[DeviceID] = @DeviceID,
	[Mall_DoorOpenLog].[OpenTime] = @OpenTime,
	[Mall_DoorOpenLog].[OpenType] = @OpenType,
	[Mall_DoorOpenLog].[LingLingId] = @LingLingId,
	[Mall_DoorOpenLog].[OpenTimeSpan] = @OpenTimeSpan 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[OpenTime],
	INSERTED.[OpenType],
	INSERTED.[LingLingId],
	INSERTED.[OpenTimeSpan]
into @table
WHERE 
	[Mall_DoorOpenLog].[ID] = @ID

SELECT 
	[ID],
	[DeviceID],
	[OpenTime],
	[OpenType],
	[LingLingId],
	[OpenTimeSpan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@DeviceID", EntityBase.GetDatabaseValue(@deviceID)));
			parameters.Add(new SqlParameter("@OpenTime", EntityBase.GetDatabaseValue(@openTime)));
			parameters.Add(new SqlParameter("@OpenType", EntityBase.GetDatabaseValue(@openType)));
			parameters.Add(new SqlParameter("@LingLingId", EntityBase.GetDatabaseValue(@lingLingId)));
			parameters.Add(new SqlParameter("@OpenTimeSpan", EntityBase.GetDatabaseValue(@openTimeSpan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_DoorOpenLog from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_DoorOpenLog(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_DoorOpenLog(@iD, helper);
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
		/// Deletes a Mall_DoorOpenLog from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_DoorOpenLog(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_DoorOpenLog]
WHERE 
	[Mall_DoorOpenLog].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_DoorOpenLog object.
		/// </summary>
		/// <returns>The newly created Mall_DoorOpenLog object.</returns>
		public static Mall_DoorOpenLog CreateMall_DoorOpenLog()
		{
			return InitializeNew<Mall_DoorOpenLog>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_DoorOpenLog by a Mall_DoorOpenLog's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_DoorOpenLog</returns>
		public static Mall_DoorOpenLog GetMall_DoorOpenLog(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_DoorOpenLog.SelectFieldList + @"
FROM [dbo].[Mall_DoorOpenLog] 
WHERE 
	[Mall_DoorOpenLog].[ID] = @ID " + Mall_DoorOpenLog.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_DoorOpenLog>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_DoorOpenLog by a Mall_DoorOpenLog's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_DoorOpenLog</returns>
		public static Mall_DoorOpenLog GetMall_DoorOpenLog(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_DoorOpenLog.SelectFieldList + @"
FROM [dbo].[Mall_DoorOpenLog] 
WHERE 
	[Mall_DoorOpenLog].[ID] = @ID " + Mall_DoorOpenLog.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_DoorOpenLog>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorOpenLog objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_DoorOpenLog objects.</returns>
		public static EntityList<Mall_DoorOpenLog> GetMall_DoorOpenLogs()
		{
			string commandText = @"
SELECT " + Mall_DoorOpenLog.SelectFieldList + "FROM [dbo].[Mall_DoorOpenLog] " + Mall_DoorOpenLog.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_DoorOpenLog>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_DoorOpenLog objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_DoorOpenLog objects.</returns>
        public static EntityList<Mall_DoorOpenLog> GetMall_DoorOpenLogs(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorOpenLog>(SelectFieldList, "FROM [dbo].[Mall_DoorOpenLog]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_DoorOpenLog objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_DoorOpenLog objects.</returns>
        public static EntityList<Mall_DoorOpenLog> GetMall_DoorOpenLogs(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorOpenLog>(SelectFieldList, "FROM [dbo].[Mall_DoorOpenLog]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_DoorOpenLog objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_DoorOpenLog objects.</returns>
		protected static EntityList<Mall_DoorOpenLog> GetMall_DoorOpenLogs(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorOpenLogs(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorOpenLog objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorOpenLog objects.</returns>
		protected static EntityList<Mall_DoorOpenLog> GetMall_DoorOpenLogs(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorOpenLogs(string.Empty, where, parameters, Mall_DoorOpenLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorOpenLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorOpenLog objects.</returns>
		protected static EntityList<Mall_DoorOpenLog> GetMall_DoorOpenLogs(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorOpenLogs(prefix, where, parameters, Mall_DoorOpenLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorOpenLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorOpenLog objects.</returns>
		protected static EntityList<Mall_DoorOpenLog> GetMall_DoorOpenLogs(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_DoorOpenLogs(string.Empty, where, parameters, Mall_DoorOpenLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorOpenLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorOpenLog objects.</returns>
		protected static EntityList<Mall_DoorOpenLog> GetMall_DoorOpenLogs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_DoorOpenLogs(prefix, where, parameters, Mall_DoorOpenLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorOpenLog objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_DoorOpenLog objects.</returns>
		protected static EntityList<Mall_DoorOpenLog> GetMall_DoorOpenLogs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_DoorOpenLog.SelectFieldList + "FROM [dbo].[Mall_DoorOpenLog] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_DoorOpenLog>(reader);
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
        protected static EntityList<Mall_DoorOpenLog> GetMall_DoorOpenLogs(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorOpenLog>(SelectFieldList, "FROM [dbo].[Mall_DoorOpenLog] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_DoorOpenLog objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_DoorOpenLogCount()
        {
            return GetMall_DoorOpenLogCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_DoorOpenLog objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_DoorOpenLogCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_DoorOpenLog] " + where;

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
		public static partial class Mall_DoorOpenLog_Properties
		{
			public const string ID = "ID";
			public const string DeviceID = "DeviceID";
			public const string OpenTime = "OpenTime";
			public const string OpenType = "OpenType";
			public const string LingLingId = "LingLingId";
			public const string OpenTimeSpan = "OpenTimeSpan";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"DeviceID" , "int:"},
    			 {"OpenTime" , "DateTime:"},
    			 {"OpenType" , "int:"},
    			 {"LingLingId" , "string:"},
    			 {"OpenTimeSpan" , "decimal:"},
            };
		}
		#endregion
	}
}
