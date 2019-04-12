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
	/// This object represents the properties and methods of a Mall_ReadPageLog.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_ReadPageLog 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _iD = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, true, false)]
		public decimal ID
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
		private string _deviceID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DeviceID
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _pageType = int.MinValue;
		/// <summary>
		/// 1-物业公告 2-商品详情
		/// </summary>
        [Description("1-物业公告 2-商品详情")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int PageType
		{
			[DebuggerStepThrough()]
			get { return this._pageType; }
			set 
			{
				if (this._pageType != value) 
				{
					this._pageType = value;
					this.IsDirty = true;	
					OnPropertyChanged("PageType");
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
		private int _table_Key = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Table_Key
		{
			[DebuggerStepThrough()]
			get { return this._table_Key; }
			set 
			{
				if (this._table_Key != value) 
				{
					this._table_Key = value;
					this.IsDirty = true;	
					OnPropertyChanged("Table_Key");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _table_Name = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Table_Name
		{
			[DebuggerStepThrough()]
			get { return this._table_Name; }
			set 
			{
				if (this._table_Name != value) 
				{
					this._table_Name = value;
					this.IsDirty = true;	
					OnPropertyChanged("Table_Name");
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
	[ID] decimal(36, 0),
	[DeviceID] nvarchar(500),
	[AddTime] datetime,
	[PageType] int,
	[UserID] int,
	[Table_Key] int,
	[Table_Name] nvarchar(200)
);

INSERT INTO [dbo].[Mall_ReadPageLog] (
	[Mall_ReadPageLog].[DeviceID],
	[Mall_ReadPageLog].[AddTime],
	[Mall_ReadPageLog].[PageType],
	[Mall_ReadPageLog].[UserID],
	[Mall_ReadPageLog].[Table_Key],
	[Mall_ReadPageLog].[Table_Name]
) 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[AddTime],
	INSERTED.[PageType],
	INSERTED.[UserID],
	INSERTED.[Table_Key],
	INSERTED.[Table_Name]
into @table
VALUES ( 
	@DeviceID,
	@AddTime,
	@PageType,
	@UserID,
	@Table_Key,
	@Table_Name 
); 

SELECT 
	[ID],
	[DeviceID],
	[AddTime],
	[PageType],
	[UserID],
	[Table_Key],
	[Table_Name] 
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
	[ID] decimal(36, 0),
	[DeviceID] nvarchar(500),
	[AddTime] datetime,
	[PageType] int,
	[UserID] int,
	[Table_Key] int,
	[Table_Name] nvarchar(200)
);

UPDATE [dbo].[Mall_ReadPageLog] SET 
	[Mall_ReadPageLog].[DeviceID] = @DeviceID,
	[Mall_ReadPageLog].[AddTime] = @AddTime,
	[Mall_ReadPageLog].[PageType] = @PageType,
	[Mall_ReadPageLog].[UserID] = @UserID,
	[Mall_ReadPageLog].[Table_Key] = @Table_Key,
	[Mall_ReadPageLog].[Table_Name] = @Table_Name 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[AddTime],
	INSERTED.[PageType],
	INSERTED.[UserID],
	INSERTED.[Table_Key],
	INSERTED.[Table_Name]
into @table
WHERE 
	[Mall_ReadPageLog].[ID] = @ID

SELECT 
	[ID],
	[DeviceID],
	[AddTime],
	[PageType],
	[UserID],
	[Table_Key],
	[Table_Name] 
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
DELETE FROM [dbo].[Mall_ReadPageLog]
WHERE 
	[Mall_ReadPageLog].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_ReadPageLog() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_ReadPageLog(this.ID));
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
	[Mall_ReadPageLog].[ID],
	[Mall_ReadPageLog].[DeviceID],
	[Mall_ReadPageLog].[AddTime],
	[Mall_ReadPageLog].[PageType],
	[Mall_ReadPageLog].[UserID],
	[Mall_ReadPageLog].[Table_Key],
	[Mall_ReadPageLog].[Table_Name]
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
                return "Mall_ReadPageLog";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_ReadPageLog into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="deviceID">deviceID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="pageType">pageType</param>
		/// <param name="userID">userID</param>
		/// <param name="table_Key">table_Key</param>
		/// <param name="table_Name">table_Name</param>
		public static void InsertMall_ReadPageLog(string @deviceID, DateTime @addTime, int @pageType, int @userID, int @table_Key, string @table_Name)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_ReadPageLog(@deviceID, @addTime, @pageType, @userID, @table_Key, @table_Name, helper);
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
		/// Insert a Mall_ReadPageLog into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="deviceID">deviceID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="pageType">pageType</param>
		/// <param name="userID">userID</param>
		/// <param name="table_Key">table_Key</param>
		/// <param name="table_Name">table_Name</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_ReadPageLog(string @deviceID, DateTime @addTime, int @pageType, int @userID, int @table_Key, string @table_Name, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] decimal(36, 0),
	[DeviceID] nvarchar(500),
	[AddTime] datetime,
	[PageType] int,
	[UserID] int,
	[Table_Key] int,
	[Table_Name] nvarchar(200)
);

INSERT INTO [dbo].[Mall_ReadPageLog] (
	[Mall_ReadPageLog].[DeviceID],
	[Mall_ReadPageLog].[AddTime],
	[Mall_ReadPageLog].[PageType],
	[Mall_ReadPageLog].[UserID],
	[Mall_ReadPageLog].[Table_Key],
	[Mall_ReadPageLog].[Table_Name]
) 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[AddTime],
	INSERTED.[PageType],
	INSERTED.[UserID],
	INSERTED.[Table_Key],
	INSERTED.[Table_Name]
into @table
VALUES ( 
	@DeviceID,
	@AddTime,
	@PageType,
	@UserID,
	@Table_Key,
	@Table_Name 
); 

SELECT 
	[ID],
	[DeviceID],
	[AddTime],
	[PageType],
	[UserID],
	[Table_Key],
	[Table_Name] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DeviceID", EntityBase.GetDatabaseValue(@deviceID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@PageType", EntityBase.GetDatabaseValue(@pageType)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@Table_Key", EntityBase.GetDatabaseValue(@table_Key)));
			parameters.Add(new SqlParameter("@Table_Name", EntityBase.GetDatabaseValue(@table_Name)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_ReadPageLog into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="deviceID">deviceID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="pageType">pageType</param>
		/// <param name="userID">userID</param>
		/// <param name="table_Key">table_Key</param>
		/// <param name="table_Name">table_Name</param>
		public static void UpdateMall_ReadPageLog(decimal @iD, string @deviceID, DateTime @addTime, int @pageType, int @userID, int @table_Key, string @table_Name)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_ReadPageLog(@iD, @deviceID, @addTime, @pageType, @userID, @table_Key, @table_Name, helper);
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
		/// Updates a Mall_ReadPageLog into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="deviceID">deviceID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="pageType">pageType</param>
		/// <param name="userID">userID</param>
		/// <param name="table_Key">table_Key</param>
		/// <param name="table_Name">table_Name</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_ReadPageLog(decimal @iD, string @deviceID, DateTime @addTime, int @pageType, int @userID, int @table_Key, string @table_Name, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] decimal(36, 0),
	[DeviceID] nvarchar(500),
	[AddTime] datetime,
	[PageType] int,
	[UserID] int,
	[Table_Key] int,
	[Table_Name] nvarchar(200)
);

UPDATE [dbo].[Mall_ReadPageLog] SET 
	[Mall_ReadPageLog].[DeviceID] = @DeviceID,
	[Mall_ReadPageLog].[AddTime] = @AddTime,
	[Mall_ReadPageLog].[PageType] = @PageType,
	[Mall_ReadPageLog].[UserID] = @UserID,
	[Mall_ReadPageLog].[Table_Key] = @Table_Key,
	[Mall_ReadPageLog].[Table_Name] = @Table_Name 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[AddTime],
	INSERTED.[PageType],
	INSERTED.[UserID],
	INSERTED.[Table_Key],
	INSERTED.[Table_Name]
into @table
WHERE 
	[Mall_ReadPageLog].[ID] = @ID

SELECT 
	[ID],
	[DeviceID],
	[AddTime],
	[PageType],
	[UserID],
	[Table_Key],
	[Table_Name] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@DeviceID", EntityBase.GetDatabaseValue(@deviceID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@PageType", EntityBase.GetDatabaseValue(@pageType)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@Table_Key", EntityBase.GetDatabaseValue(@table_Key)));
			parameters.Add(new SqlParameter("@Table_Name", EntityBase.GetDatabaseValue(@table_Name)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_ReadPageLog from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_ReadPageLog(decimal @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_ReadPageLog(@iD, helper);
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
		/// Deletes a Mall_ReadPageLog from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_ReadPageLog(decimal @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_ReadPageLog]
WHERE 
	[Mall_ReadPageLog].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_ReadPageLog object.
		/// </summary>
		/// <returns>The newly created Mall_ReadPageLog object.</returns>
		public static Mall_ReadPageLog CreateMall_ReadPageLog()
		{
			return InitializeNew<Mall_ReadPageLog>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_ReadPageLog by a Mall_ReadPageLog's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_ReadPageLog</returns>
		public static Mall_ReadPageLog GetMall_ReadPageLog(decimal @iD)
		{
			string commandText = @"
SELECT 
" + Mall_ReadPageLog.SelectFieldList + @"
FROM [dbo].[Mall_ReadPageLog] 
WHERE 
	[Mall_ReadPageLog].[ID] = @ID " + Mall_ReadPageLog.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ReadPageLog>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_ReadPageLog by a Mall_ReadPageLog's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_ReadPageLog</returns>
		public static Mall_ReadPageLog GetMall_ReadPageLog(decimal @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_ReadPageLog.SelectFieldList + @"
FROM [dbo].[Mall_ReadPageLog] 
WHERE 
	[Mall_ReadPageLog].[ID] = @ID " + Mall_ReadPageLog.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ReadPageLog>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_ReadPageLog objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_ReadPageLog objects.</returns>
		public static EntityList<Mall_ReadPageLog> GetMall_ReadPageLogs()
		{
			string commandText = @"
SELECT " + Mall_ReadPageLog.SelectFieldList + "FROM [dbo].[Mall_ReadPageLog] " + Mall_ReadPageLog.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_ReadPageLog>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_ReadPageLog objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ReadPageLog objects.</returns>
        public static EntityList<Mall_ReadPageLog> GetMall_ReadPageLogs(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ReadPageLog>(SelectFieldList, "FROM [dbo].[Mall_ReadPageLog]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_ReadPageLog objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ReadPageLog objects.</returns>
        public static EntityList<Mall_ReadPageLog> GetMall_ReadPageLogs(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ReadPageLog>(SelectFieldList, "FROM [dbo].[Mall_ReadPageLog]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_ReadPageLog objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ReadPageLog objects.</returns>
		protected static EntityList<Mall_ReadPageLog> GetMall_ReadPageLogs(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ReadPageLogs(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_ReadPageLog objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ReadPageLog objects.</returns>
		protected static EntityList<Mall_ReadPageLog> GetMall_ReadPageLogs(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ReadPageLogs(string.Empty, where, parameters, Mall_ReadPageLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ReadPageLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ReadPageLog objects.</returns>
		protected static EntityList<Mall_ReadPageLog> GetMall_ReadPageLogs(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ReadPageLogs(prefix, where, parameters, Mall_ReadPageLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ReadPageLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ReadPageLog objects.</returns>
		protected static EntityList<Mall_ReadPageLog> GetMall_ReadPageLogs(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ReadPageLogs(string.Empty, where, parameters, Mall_ReadPageLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ReadPageLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ReadPageLog objects.</returns>
		protected static EntityList<Mall_ReadPageLog> GetMall_ReadPageLogs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ReadPageLogs(prefix, where, parameters, Mall_ReadPageLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ReadPageLog objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ReadPageLog objects.</returns>
		protected static EntityList<Mall_ReadPageLog> GetMall_ReadPageLogs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_ReadPageLog.SelectFieldList + "FROM [dbo].[Mall_ReadPageLog] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_ReadPageLog>(reader);
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
        protected static EntityList<Mall_ReadPageLog> GetMall_ReadPageLogs(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ReadPageLog>(SelectFieldList, "FROM [dbo].[Mall_ReadPageLog] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_ReadPageLog objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ReadPageLogCount()
        {
            return GetMall_ReadPageLogCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_ReadPageLog objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ReadPageLogCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_ReadPageLog] " + where;

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
		public static partial class Mall_ReadPageLog_Properties
		{
			public const string ID = "ID";
			public const string DeviceID = "DeviceID";
			public const string AddTime = "AddTime";
			public const string PageType = "PageType";
			public const string UserID = "UserID";
			public const string Table_Key = "Table_Key";
			public const string Table_Name = "Table_Name";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "decimal:"},
    			 {"DeviceID" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"PageType" , "int:1-物业公告 2-商品详情"},
    			 {"UserID" , "int:"},
    			 {"Table_Key" , "int:"},
    			 {"Table_Name" , "string:"},
            };
		}
		#endregion
	}
}
