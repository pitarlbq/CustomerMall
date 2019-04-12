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
	/// This object represents the properties and methods of a SysConfig_Project.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class SysConfig_Project 
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
		private int _configID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ConfigID
		{
			[DebuggerStepThrough()]
			get { return this._configID; }
			set 
			{
				if (this._configID != value) 
				{
					this._configID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ConfigID");
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
		[DataObjectField(false, false, false)]
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _configValue = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ConfigValue
		{
			[DebuggerStepThrough()]
			get { return this._configValue; }
			set 
			{
				if (this._configValue != value) 
				{
					this._configValue = value;
					this.IsDirty = true;	
					OnPropertyChanged("ConfigValue");
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
	[ConfigID] int,
	[ProjectID] int,
	[ConfigValue] nvarchar(500),
	[AddTime] datetime
);

INSERT INTO [dbo].[SysConfig_Project] (
	[SysConfig_Project].[ConfigID],
	[SysConfig_Project].[ProjectID],
	[SysConfig_Project].[ConfigValue],
	[SysConfig_Project].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ConfigID],
	INSERTED.[ProjectID],
	INSERTED.[ConfigValue],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@ConfigID,
	@ProjectID,
	@ConfigValue,
	@AddTime 
); 

SELECT 
	[ID],
	[ConfigID],
	[ProjectID],
	[ConfigValue],
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
	[ConfigID] int,
	[ProjectID] int,
	[ConfigValue] nvarchar(500),
	[AddTime] datetime
);

UPDATE [dbo].[SysConfig_Project] SET 
	[SysConfig_Project].[ConfigID] = @ConfigID,
	[SysConfig_Project].[ProjectID] = @ProjectID,
	[SysConfig_Project].[ConfigValue] = @ConfigValue,
	[SysConfig_Project].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[ConfigID],
	INSERTED.[ProjectID],
	INSERTED.[ConfigValue],
	INSERTED.[AddTime]
into @table
WHERE 
	[SysConfig_Project].[ID] = @ID

SELECT 
	[ID],
	[ConfigID],
	[ProjectID],
	[ConfigValue],
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
DELETE FROM [dbo].[SysConfig_Project]
WHERE 
	[SysConfig_Project].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public SysConfig_Project() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetSysConfig_Project(this.ID));
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
	[SysConfig_Project].[ID],
	[SysConfig_Project].[ConfigID],
	[SysConfig_Project].[ProjectID],
	[SysConfig_Project].[ConfigValue],
	[SysConfig_Project].[AddTime]
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
                return "SysConfig_Project";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a SysConfig_Project into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="configID">configID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="configValue">configValue</param>
		/// <param name="addTime">addTime</param>
		public static void InsertSysConfig_Project(int @configID, int @projectID, string @configValue, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertSysConfig_Project(@configID, @projectID, @configValue, @addTime, helper);
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
		/// Insert a SysConfig_Project into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="configID">configID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="configValue">configValue</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertSysConfig_Project(int @configID, int @projectID, string @configValue, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ConfigID] int,
	[ProjectID] int,
	[ConfigValue] nvarchar(500),
	[AddTime] datetime
);

INSERT INTO [dbo].[SysConfig_Project] (
	[SysConfig_Project].[ConfigID],
	[SysConfig_Project].[ProjectID],
	[SysConfig_Project].[ConfigValue],
	[SysConfig_Project].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ConfigID],
	INSERTED.[ProjectID],
	INSERTED.[ConfigValue],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@ConfigID,
	@ProjectID,
	@ConfigValue,
	@AddTime 
); 

SELECT 
	[ID],
	[ConfigID],
	[ProjectID],
	[ConfigValue],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ConfigID", EntityBase.GetDatabaseValue(@configID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@ConfigValue", EntityBase.GetDatabaseValue(@configValue)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a SysConfig_Project into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="configID">configID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="configValue">configValue</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateSysConfig_Project(int @iD, int @configID, int @projectID, string @configValue, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateSysConfig_Project(@iD, @configID, @projectID, @configValue, @addTime, helper);
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
		/// Updates a SysConfig_Project into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="configID">configID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="configValue">configValue</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateSysConfig_Project(int @iD, int @configID, int @projectID, string @configValue, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ConfigID] int,
	[ProjectID] int,
	[ConfigValue] nvarchar(500),
	[AddTime] datetime
);

UPDATE [dbo].[SysConfig_Project] SET 
	[SysConfig_Project].[ConfigID] = @ConfigID,
	[SysConfig_Project].[ProjectID] = @ProjectID,
	[SysConfig_Project].[ConfigValue] = @ConfigValue,
	[SysConfig_Project].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[ConfigID],
	INSERTED.[ProjectID],
	INSERTED.[ConfigValue],
	INSERTED.[AddTime]
into @table
WHERE 
	[SysConfig_Project].[ID] = @ID

SELECT 
	[ID],
	[ConfigID],
	[ProjectID],
	[ConfigValue],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ConfigID", EntityBase.GetDatabaseValue(@configID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@ConfigValue", EntityBase.GetDatabaseValue(@configValue)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a SysConfig_Project from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteSysConfig_Project(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteSysConfig_Project(@iD, helper);
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
		/// Deletes a SysConfig_Project from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteSysConfig_Project(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[SysConfig_Project]
WHERE 
	[SysConfig_Project].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new SysConfig_Project object.
		/// </summary>
		/// <returns>The newly created SysConfig_Project object.</returns>
		public static SysConfig_Project CreateSysConfig_Project()
		{
			return InitializeNew<SysConfig_Project>();
		}
		
		/// <summary>
		/// Retrieve information for a SysConfig_Project by a SysConfig_Project's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>SysConfig_Project</returns>
		public static SysConfig_Project GetSysConfig_Project(int @iD)
		{
			string commandText = @"
SELECT 
" + SysConfig_Project.SelectFieldList + @"
FROM [dbo].[SysConfig_Project] 
WHERE 
	[SysConfig_Project].[ID] = @ID " + SysConfig_Project.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<SysConfig_Project>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a SysConfig_Project by a SysConfig_Project's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>SysConfig_Project</returns>
		public static SysConfig_Project GetSysConfig_Project(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + SysConfig_Project.SelectFieldList + @"
FROM [dbo].[SysConfig_Project] 
WHERE 
	[SysConfig_Project].[ID] = @ID " + SysConfig_Project.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<SysConfig_Project>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection SysConfig_Project objects.
		/// </summary>
		/// <returns>The retrieved collection of SysConfig_Project objects.</returns>
		public static EntityList<SysConfig_Project> GetSysConfig_Projects()
		{
			string commandText = @"
SELECT " + SysConfig_Project.SelectFieldList + "FROM [dbo].[SysConfig_Project] " + SysConfig_Project.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<SysConfig_Project>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection SysConfig_Project objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of SysConfig_Project objects.</returns>
        public static EntityList<SysConfig_Project> GetSysConfig_Projects(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SysConfig_Project>(SelectFieldList, "FROM [dbo].[SysConfig_Project]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection SysConfig_Project objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of SysConfig_Project objects.</returns>
        public static EntityList<SysConfig_Project> GetSysConfig_Projects(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SysConfig_Project>(SelectFieldList, "FROM [dbo].[SysConfig_Project]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection SysConfig_Project objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of SysConfig_Project objects.</returns>
		protected static EntityList<SysConfig_Project> GetSysConfig_Projects(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSysConfig_Projects(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection SysConfig_Project objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of SysConfig_Project objects.</returns>
		protected static EntityList<SysConfig_Project> GetSysConfig_Projects(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSysConfig_Projects(string.Empty, where, parameters, SysConfig_Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysConfig_Project objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of SysConfig_Project objects.</returns>
		protected static EntityList<SysConfig_Project> GetSysConfig_Projects(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSysConfig_Projects(prefix, where, parameters, SysConfig_Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysConfig_Project objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of SysConfig_Project objects.</returns>
		protected static EntityList<SysConfig_Project> GetSysConfig_Projects(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSysConfig_Projects(string.Empty, where, parameters, SysConfig_Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysConfig_Project objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of SysConfig_Project objects.</returns>
		protected static EntityList<SysConfig_Project> GetSysConfig_Projects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSysConfig_Projects(prefix, where, parameters, SysConfig_Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysConfig_Project objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of SysConfig_Project objects.</returns>
		protected static EntityList<SysConfig_Project> GetSysConfig_Projects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + SysConfig_Project.SelectFieldList + "FROM [dbo].[SysConfig_Project] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<SysConfig_Project>(reader);
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
        protected static EntityList<SysConfig_Project> GetSysConfig_Projects(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SysConfig_Project>(SelectFieldList, "FROM [dbo].[SysConfig_Project] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of SysConfig_Project objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSysConfig_ProjectCount()
        {
            return GetSysConfig_ProjectCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of SysConfig_Project objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSysConfig_ProjectCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[SysConfig_Project] " + where;

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
		public static partial class SysConfig_Project_Properties
		{
			public const string ID = "ID";
			public const string ConfigID = "ConfigID";
			public const string ProjectID = "ProjectID";
			public const string ConfigValue = "ConfigValue";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ConfigID" , "int:"},
    			 {"ProjectID" , "int:"},
    			 {"ConfigValue" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
