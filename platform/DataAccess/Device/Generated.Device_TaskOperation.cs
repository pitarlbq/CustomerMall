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
	/// This object represents the properties and methods of a Device_TaskOperation.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Device_TaskOperation 
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
		private string _operationType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OperationType
		{
			[DebuggerStepThrough()]
			get { return this._operationType; }
			set 
			{
				if (this._operationType != value) 
				{
					this._operationType = value;
					this.IsDirty = true;	
					OnPropertyChanged("OperationType");
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
		private DateTime _thisOperationTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ThisOperationTime
		{
			[DebuggerStepThrough()]
			get { return this._thisOperationTime; }
			set 
			{
				if (this._thisOperationTime != value) 
				{
					this._thisOperationTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ThisOperationTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _nextOperationTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime NextOperationTime
		{
			[DebuggerStepThrough()]
			get { return this._nextOperationTime; }
			set 
			{
				if (this._nextOperationTime != value) 
				{
					this._nextOperationTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("NextOperationTime");
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
	[OperationType] nvarchar(50),
	[AddTime] datetime,
	[ThisOperationTime] datetime,
	[NextOperationTime] datetime
);

INSERT INTO [dbo].[Device_TaskOperation] (
	[Device_TaskOperation].[DeviceID],
	[Device_TaskOperation].[OperationType],
	[Device_TaskOperation].[AddTime],
	[Device_TaskOperation].[ThisOperationTime],
	[Device_TaskOperation].[NextOperationTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[OperationType],
	INSERTED.[AddTime],
	INSERTED.[ThisOperationTime],
	INSERTED.[NextOperationTime]
into @table
VALUES ( 
	@DeviceID,
	@OperationType,
	@AddTime,
	@ThisOperationTime,
	@NextOperationTime 
); 

SELECT 
	[ID],
	[DeviceID],
	[OperationType],
	[AddTime],
	[ThisOperationTime],
	[NextOperationTime] 
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
	[OperationType] nvarchar(50),
	[AddTime] datetime,
	[ThisOperationTime] datetime,
	[NextOperationTime] datetime
);

UPDATE [dbo].[Device_TaskOperation] SET 
	[Device_TaskOperation].[DeviceID] = @DeviceID,
	[Device_TaskOperation].[OperationType] = @OperationType,
	[Device_TaskOperation].[AddTime] = @AddTime,
	[Device_TaskOperation].[ThisOperationTime] = @ThisOperationTime,
	[Device_TaskOperation].[NextOperationTime] = @NextOperationTime 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[OperationType],
	INSERTED.[AddTime],
	INSERTED.[ThisOperationTime],
	INSERTED.[NextOperationTime]
into @table
WHERE 
	[Device_TaskOperation].[ID] = @ID

SELECT 
	[ID],
	[DeviceID],
	[OperationType],
	[AddTime],
	[ThisOperationTime],
	[NextOperationTime] 
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
DELETE FROM [dbo].[Device_TaskOperation]
WHERE 
	[Device_TaskOperation].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Device_TaskOperation() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetDevice_TaskOperation(this.ID));
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
	[Device_TaskOperation].[ID],
	[Device_TaskOperation].[DeviceID],
	[Device_TaskOperation].[OperationType],
	[Device_TaskOperation].[AddTime],
	[Device_TaskOperation].[ThisOperationTime],
	[Device_TaskOperation].[NextOperationTime]
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
                return "Device_TaskOperation";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Device_TaskOperation into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="deviceID">deviceID</param>
		/// <param name="operationType">operationType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="thisOperationTime">thisOperationTime</param>
		/// <param name="nextOperationTime">nextOperationTime</param>
		public static void InsertDevice_TaskOperation(int @deviceID, string @operationType, DateTime @addTime, DateTime @thisOperationTime, DateTime @nextOperationTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertDevice_TaskOperation(@deviceID, @operationType, @addTime, @thisOperationTime, @nextOperationTime, helper);
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
		/// Insert a Device_TaskOperation into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="deviceID">deviceID</param>
		/// <param name="operationType">operationType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="thisOperationTime">thisOperationTime</param>
		/// <param name="nextOperationTime">nextOperationTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertDevice_TaskOperation(int @deviceID, string @operationType, DateTime @addTime, DateTime @thisOperationTime, DateTime @nextOperationTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DeviceID] int,
	[OperationType] nvarchar(50),
	[AddTime] datetime,
	[ThisOperationTime] datetime,
	[NextOperationTime] datetime
);

INSERT INTO [dbo].[Device_TaskOperation] (
	[Device_TaskOperation].[DeviceID],
	[Device_TaskOperation].[OperationType],
	[Device_TaskOperation].[AddTime],
	[Device_TaskOperation].[ThisOperationTime],
	[Device_TaskOperation].[NextOperationTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[OperationType],
	INSERTED.[AddTime],
	INSERTED.[ThisOperationTime],
	INSERTED.[NextOperationTime]
into @table
VALUES ( 
	@DeviceID,
	@OperationType,
	@AddTime,
	@ThisOperationTime,
	@NextOperationTime 
); 

SELECT 
	[ID],
	[DeviceID],
	[OperationType],
	[AddTime],
	[ThisOperationTime],
	[NextOperationTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DeviceID", EntityBase.GetDatabaseValue(@deviceID)));
			parameters.Add(new SqlParameter("@OperationType", EntityBase.GetDatabaseValue(@operationType)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ThisOperationTime", EntityBase.GetDatabaseValue(@thisOperationTime)));
			parameters.Add(new SqlParameter("@NextOperationTime", EntityBase.GetDatabaseValue(@nextOperationTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Device_TaskOperation into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="deviceID">deviceID</param>
		/// <param name="operationType">operationType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="thisOperationTime">thisOperationTime</param>
		/// <param name="nextOperationTime">nextOperationTime</param>
		public static void UpdateDevice_TaskOperation(int @iD, int @deviceID, string @operationType, DateTime @addTime, DateTime @thisOperationTime, DateTime @nextOperationTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateDevice_TaskOperation(@iD, @deviceID, @operationType, @addTime, @thisOperationTime, @nextOperationTime, helper);
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
		/// Updates a Device_TaskOperation into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="deviceID">deviceID</param>
		/// <param name="operationType">operationType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="thisOperationTime">thisOperationTime</param>
		/// <param name="nextOperationTime">nextOperationTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateDevice_TaskOperation(int @iD, int @deviceID, string @operationType, DateTime @addTime, DateTime @thisOperationTime, DateTime @nextOperationTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DeviceID] int,
	[OperationType] nvarchar(50),
	[AddTime] datetime,
	[ThisOperationTime] datetime,
	[NextOperationTime] datetime
);

UPDATE [dbo].[Device_TaskOperation] SET 
	[Device_TaskOperation].[DeviceID] = @DeviceID,
	[Device_TaskOperation].[OperationType] = @OperationType,
	[Device_TaskOperation].[AddTime] = @AddTime,
	[Device_TaskOperation].[ThisOperationTime] = @ThisOperationTime,
	[Device_TaskOperation].[NextOperationTime] = @NextOperationTime 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[OperationType],
	INSERTED.[AddTime],
	INSERTED.[ThisOperationTime],
	INSERTED.[NextOperationTime]
into @table
WHERE 
	[Device_TaskOperation].[ID] = @ID

SELECT 
	[ID],
	[DeviceID],
	[OperationType],
	[AddTime],
	[ThisOperationTime],
	[NextOperationTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@DeviceID", EntityBase.GetDatabaseValue(@deviceID)));
			parameters.Add(new SqlParameter("@OperationType", EntityBase.GetDatabaseValue(@operationType)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ThisOperationTime", EntityBase.GetDatabaseValue(@thisOperationTime)));
			parameters.Add(new SqlParameter("@NextOperationTime", EntityBase.GetDatabaseValue(@nextOperationTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Device_TaskOperation from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteDevice_TaskOperation(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteDevice_TaskOperation(@iD, helper);
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
		/// Deletes a Device_TaskOperation from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteDevice_TaskOperation(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Device_TaskOperation]
WHERE 
	[Device_TaskOperation].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Device_TaskOperation object.
		/// </summary>
		/// <returns>The newly created Device_TaskOperation object.</returns>
		public static Device_TaskOperation CreateDevice_TaskOperation()
		{
			return InitializeNew<Device_TaskOperation>();
		}
		
		/// <summary>
		/// Retrieve information for a Device_TaskOperation by a Device_TaskOperation's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Device_TaskOperation</returns>
		public static Device_TaskOperation GetDevice_TaskOperation(int @iD)
		{
			string commandText = @"
SELECT 
" + Device_TaskOperation.SelectFieldList + @"
FROM [dbo].[Device_TaskOperation] 
WHERE 
	[Device_TaskOperation].[ID] = @ID " + Device_TaskOperation.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Device_TaskOperation>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Device_TaskOperation by a Device_TaskOperation's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Device_TaskOperation</returns>
		public static Device_TaskOperation GetDevice_TaskOperation(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Device_TaskOperation.SelectFieldList + @"
FROM [dbo].[Device_TaskOperation] 
WHERE 
	[Device_TaskOperation].[ID] = @ID " + Device_TaskOperation.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Device_TaskOperation>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Device_TaskOperation objects.
		/// </summary>
		/// <returns>The retrieved collection of Device_TaskOperation objects.</returns>
		public static EntityList<Device_TaskOperation> GetDevice_TaskOperations()
		{
			string commandText = @"
SELECT " + Device_TaskOperation.SelectFieldList + "FROM [dbo].[Device_TaskOperation] " + Device_TaskOperation.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Device_TaskOperation>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Device_TaskOperation objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Device_TaskOperation objects.</returns>
        public static EntityList<Device_TaskOperation> GetDevice_TaskOperations(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Device_TaskOperation>(SelectFieldList, "FROM [dbo].[Device_TaskOperation]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Device_TaskOperation objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Device_TaskOperation objects.</returns>
        public static EntityList<Device_TaskOperation> GetDevice_TaskOperations(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Device_TaskOperation>(SelectFieldList, "FROM [dbo].[Device_TaskOperation]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Device_TaskOperation objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Device_TaskOperation objects.</returns>
		protected static EntityList<Device_TaskOperation> GetDevice_TaskOperations(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDevice_TaskOperations(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Device_TaskOperation objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Device_TaskOperation objects.</returns>
		protected static EntityList<Device_TaskOperation> GetDevice_TaskOperations(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDevice_TaskOperations(string.Empty, where, parameters, Device_TaskOperation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_TaskOperation objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Device_TaskOperation objects.</returns>
		protected static EntityList<Device_TaskOperation> GetDevice_TaskOperations(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDevice_TaskOperations(prefix, where, parameters, Device_TaskOperation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_TaskOperation objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Device_TaskOperation objects.</returns>
		protected static EntityList<Device_TaskOperation> GetDevice_TaskOperations(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetDevice_TaskOperations(string.Empty, where, parameters, Device_TaskOperation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_TaskOperation objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Device_TaskOperation objects.</returns>
		protected static EntityList<Device_TaskOperation> GetDevice_TaskOperations(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetDevice_TaskOperations(prefix, where, parameters, Device_TaskOperation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_TaskOperation objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Device_TaskOperation objects.</returns>
		protected static EntityList<Device_TaskOperation> GetDevice_TaskOperations(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Device_TaskOperation.SelectFieldList + "FROM [dbo].[Device_TaskOperation] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Device_TaskOperation>(reader);
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
        protected static EntityList<Device_TaskOperation> GetDevice_TaskOperations(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Device_TaskOperation>(SelectFieldList, "FROM [dbo].[Device_TaskOperation] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Device_TaskOperation objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetDevice_TaskOperationCount()
        {
            return GetDevice_TaskOperationCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Device_TaskOperation objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetDevice_TaskOperationCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Device_TaskOperation] " + where;

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
		public static partial class Device_TaskOperation_Properties
		{
			public const string ID = "ID";
			public const string DeviceID = "DeviceID";
			public const string OperationType = "OperationType";
			public const string AddTime = "AddTime";
			public const string ThisOperationTime = "ThisOperationTime";
			public const string NextOperationTime = "NextOperationTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"DeviceID" , "int:"},
    			 {"OperationType" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"ThisOperationTime" , "DateTime:"},
    			 {"NextOperationTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
