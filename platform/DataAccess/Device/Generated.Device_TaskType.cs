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
	/// This object represents the properties and methods of a Device_TaskType.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Device_TaskType 
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
		private string _taskTypeName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TaskTypeName
		{
			[DebuggerStepThrough()]
			get { return this._taskTypeName; }
			set 
			{
				if (this._taskTypeName != value) 
				{
					this._taskTypeName = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaskTypeName");
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
	[TaskTypeName] nvarchar(50),
	[AddTime] datetime
);

INSERT INTO [dbo].[Device_TaskType] (
	[Device_TaskType].[TaskTypeName],
	[Device_TaskType].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[TaskTypeName],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@TaskTypeName,
	@AddTime 
); 

SELECT 
	[ID],
	[TaskTypeName],
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
	[TaskTypeName] nvarchar(50),
	[AddTime] datetime
);

UPDATE [dbo].[Device_TaskType] SET 
	[Device_TaskType].[TaskTypeName] = @TaskTypeName,
	[Device_TaskType].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[TaskTypeName],
	INSERTED.[AddTime]
into @table
WHERE 
	[Device_TaskType].[ID] = @ID

SELECT 
	[ID],
	[TaskTypeName],
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
DELETE FROM [dbo].[Device_TaskType]
WHERE 
	[Device_TaskType].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Device_TaskType() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetDevice_TaskType(this.ID));
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
	[Device_TaskType].[ID],
	[Device_TaskType].[TaskTypeName],
	[Device_TaskType].[AddTime]
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
                return "Device_TaskType";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Device_TaskType into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="taskTypeName">taskTypeName</param>
		/// <param name="addTime">addTime</param>
		public static void InsertDevice_TaskType(string @taskTypeName, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertDevice_TaskType(@taskTypeName, @addTime, helper);
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
		/// Insert a Device_TaskType into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="taskTypeName">taskTypeName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertDevice_TaskType(string @taskTypeName, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[TaskTypeName] nvarchar(50),
	[AddTime] datetime
);

INSERT INTO [dbo].[Device_TaskType] (
	[Device_TaskType].[TaskTypeName],
	[Device_TaskType].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[TaskTypeName],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@TaskTypeName,
	@AddTime 
); 

SELECT 
	[ID],
	[TaskTypeName],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TaskTypeName", EntityBase.GetDatabaseValue(@taskTypeName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Device_TaskType into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="taskTypeName">taskTypeName</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateDevice_TaskType(int @iD, string @taskTypeName, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateDevice_TaskType(@iD, @taskTypeName, @addTime, helper);
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
		/// Updates a Device_TaskType into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="taskTypeName">taskTypeName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateDevice_TaskType(int @iD, string @taskTypeName, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[TaskTypeName] nvarchar(50),
	[AddTime] datetime
);

UPDATE [dbo].[Device_TaskType] SET 
	[Device_TaskType].[TaskTypeName] = @TaskTypeName,
	[Device_TaskType].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[TaskTypeName],
	INSERTED.[AddTime]
into @table
WHERE 
	[Device_TaskType].[ID] = @ID

SELECT 
	[ID],
	[TaskTypeName],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@TaskTypeName", EntityBase.GetDatabaseValue(@taskTypeName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Device_TaskType from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteDevice_TaskType(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteDevice_TaskType(@iD, helper);
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
		/// Deletes a Device_TaskType from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteDevice_TaskType(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Device_TaskType]
WHERE 
	[Device_TaskType].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Device_TaskType object.
		/// </summary>
		/// <returns>The newly created Device_TaskType object.</returns>
		public static Device_TaskType CreateDevice_TaskType()
		{
			return InitializeNew<Device_TaskType>();
		}
		
		/// <summary>
		/// Retrieve information for a Device_TaskType by a Device_TaskType's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Device_TaskType</returns>
		public static Device_TaskType GetDevice_TaskType(int @iD)
		{
			string commandText = @"
SELECT 
" + Device_TaskType.SelectFieldList + @"
FROM [dbo].[Device_TaskType] 
WHERE 
	[Device_TaskType].[ID] = @ID " + Device_TaskType.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Device_TaskType>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Device_TaskType by a Device_TaskType's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Device_TaskType</returns>
		public static Device_TaskType GetDevice_TaskType(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Device_TaskType.SelectFieldList + @"
FROM [dbo].[Device_TaskType] 
WHERE 
	[Device_TaskType].[ID] = @ID " + Device_TaskType.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Device_TaskType>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Device_TaskType objects.
		/// </summary>
		/// <returns>The retrieved collection of Device_TaskType objects.</returns>
		public static EntityList<Device_TaskType> GetDevice_TaskTypes()
		{
			string commandText = @"
SELECT " + Device_TaskType.SelectFieldList + "FROM [dbo].[Device_TaskType] " + Device_TaskType.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Device_TaskType>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Device_TaskType objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Device_TaskType objects.</returns>
        public static EntityList<Device_TaskType> GetDevice_TaskTypes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Device_TaskType>(SelectFieldList, "FROM [dbo].[Device_TaskType]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Device_TaskType objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Device_TaskType objects.</returns>
        public static EntityList<Device_TaskType> GetDevice_TaskTypes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Device_TaskType>(SelectFieldList, "FROM [dbo].[Device_TaskType]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Device_TaskType objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Device_TaskType objects.</returns>
		protected static EntityList<Device_TaskType> GetDevice_TaskTypes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDevice_TaskTypes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Device_TaskType objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Device_TaskType objects.</returns>
		protected static EntityList<Device_TaskType> GetDevice_TaskTypes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDevice_TaskTypes(string.Empty, where, parameters, Device_TaskType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_TaskType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Device_TaskType objects.</returns>
		protected static EntityList<Device_TaskType> GetDevice_TaskTypes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDevice_TaskTypes(prefix, where, parameters, Device_TaskType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_TaskType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Device_TaskType objects.</returns>
		protected static EntityList<Device_TaskType> GetDevice_TaskTypes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetDevice_TaskTypes(string.Empty, where, parameters, Device_TaskType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_TaskType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Device_TaskType objects.</returns>
		protected static EntityList<Device_TaskType> GetDevice_TaskTypes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetDevice_TaskTypes(prefix, where, parameters, Device_TaskType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_TaskType objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Device_TaskType objects.</returns>
		protected static EntityList<Device_TaskType> GetDevice_TaskTypes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Device_TaskType.SelectFieldList + "FROM [dbo].[Device_TaskType] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Device_TaskType>(reader);
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
        protected static EntityList<Device_TaskType> GetDevice_TaskTypes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Device_TaskType>(SelectFieldList, "FROM [dbo].[Device_TaskType] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Device_TaskType objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetDevice_TaskTypeCount()
        {
            return GetDevice_TaskTypeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Device_TaskType objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetDevice_TaskTypeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Device_TaskType] " + where;

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
		public static partial class Device_TaskType_Properties
		{
			public const string ID = "ID";
			public const string TaskTypeName = "TaskTypeName";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"TaskTypeName" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
