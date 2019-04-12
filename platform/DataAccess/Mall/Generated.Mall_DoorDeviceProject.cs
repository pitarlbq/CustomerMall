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
	/// This object represents the properties and methods of a Mall_DoorDeviceProject.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("DoorDeviceID: {DoorDeviceID}, ProjectID: {ProjectID}")]
	public partial class Mall_DoorDeviceProject 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _doorDeviceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
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
		private int _projectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
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
	[DoorDeviceID] int,
	[ProjectID] int
);

INSERT INTO [dbo].[Mall_DoorDeviceProject] (
	[Mall_DoorDeviceProject].[DoorDeviceID],
	[Mall_DoorDeviceProject].[ProjectID]
) 
output 
	INSERTED.[DoorDeviceID],
	INSERTED.[ProjectID]
into @table
VALUES ( 
	@DoorDeviceID,
	@ProjectID 
); 

SELECT 
	[DoorDeviceID],
	[ProjectID] 
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
	[DoorDeviceID] int,
	[ProjectID] int
);

UPDATE [dbo].[Mall_DoorDeviceProject] SET 
 
output 
	INSERTED.[DoorDeviceID],
	INSERTED.[ProjectID]
into @table
WHERE 
	[Mall_DoorDeviceProject].[DoorDeviceID] = @DoorDeviceID
	AND [Mall_DoorDeviceProject].[ProjectID] = @ProjectID

SELECT 
	[DoorDeviceID],
	[ProjectID] 
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
DELETE FROM [dbo].[Mall_DoorDeviceProject]
WHERE 
	[Mall_DoorDeviceProject].[DoorDeviceID] = @DoorDeviceID
	AND [Mall_DoorDeviceProject].[ProjectID] = @ProjectID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_DoorDeviceProject() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_DoorDeviceProject(this.DoorDeviceID, this.ProjectID));
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
	[Mall_DoorDeviceProject].[DoorDeviceID],
	[Mall_DoorDeviceProject].[ProjectID]
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
                return "Mall_DoorDeviceProject";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_DoorDeviceProject into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="doorDeviceID">doorDeviceID</param>
		/// <param name="projectID">projectID</param>
		public static void InsertMall_DoorDeviceProject(int @doorDeviceID, int @projectID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_DoorDeviceProject(@doorDeviceID, @projectID, helper);
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
		/// Insert a Mall_DoorDeviceProject into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="doorDeviceID">doorDeviceID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_DoorDeviceProject(int @doorDeviceID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[DoorDeviceID] int,
	[ProjectID] int
);

INSERT INTO [dbo].[Mall_DoorDeviceProject] (
	[Mall_DoorDeviceProject].[DoorDeviceID],
	[Mall_DoorDeviceProject].[ProjectID]
) 
output 
	INSERTED.[DoorDeviceID],
	INSERTED.[ProjectID]
into @table
VALUES ( 
	@DoorDeviceID,
	@ProjectID 
); 

SELECT 
	[DoorDeviceID],
	[ProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DoorDeviceID", EntityBase.GetDatabaseValue(@doorDeviceID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_DoorDeviceProject into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="doorDeviceID">doorDeviceID</param>
		/// <param name="projectID">projectID</param>
		public static void UpdateMall_DoorDeviceProject(int @doorDeviceID, int @projectID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_DoorDeviceProject(@doorDeviceID, @projectID, helper);
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
		/// Updates a Mall_DoorDeviceProject into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="doorDeviceID">doorDeviceID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_DoorDeviceProject(int @doorDeviceID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[DoorDeviceID] int,
	[ProjectID] int
);

UPDATE [dbo].[Mall_DoorDeviceProject] SET 
 
output 
	INSERTED.[DoorDeviceID],
	INSERTED.[ProjectID]
into @table
WHERE 
	[Mall_DoorDeviceProject].[DoorDeviceID] = @DoorDeviceID
	AND [Mall_DoorDeviceProject].[ProjectID] = @ProjectID

SELECT 
	[DoorDeviceID],
	[ProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DoorDeviceID", EntityBase.GetDatabaseValue(@doorDeviceID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_DoorDeviceProject from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="doorDeviceID">doorDeviceID</param>
		/// <param name="projectID">projectID</param>
		public static void DeleteMall_DoorDeviceProject(int @doorDeviceID, int @projectID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_DoorDeviceProject(@doorDeviceID, @projectID, helper);
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
		/// Deletes a Mall_DoorDeviceProject from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="doorDeviceID">doorDeviceID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_DoorDeviceProject(int @doorDeviceID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_DoorDeviceProject]
WHERE 
	[Mall_DoorDeviceProject].[DoorDeviceID] = @DoorDeviceID
	AND [Mall_DoorDeviceProject].[ProjectID] = @ProjectID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DoorDeviceID", @doorDeviceID));
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_DoorDeviceProject object.
		/// </summary>
		/// <returns>The newly created Mall_DoorDeviceProject object.</returns>
		public static Mall_DoorDeviceProject CreateMall_DoorDeviceProject()
		{
			return InitializeNew<Mall_DoorDeviceProject>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_DoorDeviceProject by a Mall_DoorDeviceProject's unique identifier.
		/// </summary>
		/// <param name="doorDeviceID">doorDeviceID</param>
		/// <param name="projectID">projectID</param>
		/// <returns>Mall_DoorDeviceProject</returns>
		public static Mall_DoorDeviceProject GetMall_DoorDeviceProject(int @doorDeviceID, int @projectID)
		{
			string commandText = @"
SELECT 
" + Mall_DoorDeviceProject.SelectFieldList + @"
FROM [dbo].[Mall_DoorDeviceProject] 
WHERE 
	[Mall_DoorDeviceProject].[DoorDeviceID] = @DoorDeviceID
	AND [Mall_DoorDeviceProject].[ProjectID] = @ProjectID " + Mall_DoorDeviceProject.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DoorDeviceID", @doorDeviceID));
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			
			return GetOne<Mall_DoorDeviceProject>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_DoorDeviceProject by a Mall_DoorDeviceProject's unique identifier.
		/// </summary>
		/// <param name="doorDeviceID">doorDeviceID</param>
		/// <param name="projectID">projectID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_DoorDeviceProject</returns>
		public static Mall_DoorDeviceProject GetMall_DoorDeviceProject(int @doorDeviceID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_DoorDeviceProject.SelectFieldList + @"
FROM [dbo].[Mall_DoorDeviceProject] 
WHERE 
	[Mall_DoorDeviceProject].[DoorDeviceID] = @DoorDeviceID
	AND [Mall_DoorDeviceProject].[ProjectID] = @ProjectID " + Mall_DoorDeviceProject.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DoorDeviceID", @doorDeviceID));
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			
			return GetOne<Mall_DoorDeviceProject>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorDeviceProject objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_DoorDeviceProject objects.</returns>
		public static EntityList<Mall_DoorDeviceProject> GetMall_DoorDeviceProjects()
		{
			string commandText = @"
SELECT " + Mall_DoorDeviceProject.SelectFieldList + "FROM [dbo].[Mall_DoorDeviceProject] " + Mall_DoorDeviceProject.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_DoorDeviceProject>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_DoorDeviceProject objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_DoorDeviceProject objects.</returns>
        public static EntityList<Mall_DoorDeviceProject> GetMall_DoorDeviceProjects(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorDeviceProject>(SelectFieldList, "FROM [dbo].[Mall_DoorDeviceProject]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_DoorDeviceProject objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_DoorDeviceProject objects.</returns>
        public static EntityList<Mall_DoorDeviceProject> GetMall_DoorDeviceProjects(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorDeviceProject>(SelectFieldList, "FROM [dbo].[Mall_DoorDeviceProject]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_DoorDeviceProject objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_DoorDeviceProject objects.</returns>
		protected static EntityList<Mall_DoorDeviceProject> GetMall_DoorDeviceProjects(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorDeviceProjects(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorDeviceProject objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorDeviceProject objects.</returns>
		protected static EntityList<Mall_DoorDeviceProject> GetMall_DoorDeviceProjects(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorDeviceProjects(string.Empty, where, parameters, Mall_DoorDeviceProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorDeviceProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorDeviceProject objects.</returns>
		protected static EntityList<Mall_DoorDeviceProject> GetMall_DoorDeviceProjects(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorDeviceProjects(prefix, where, parameters, Mall_DoorDeviceProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorDeviceProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorDeviceProject objects.</returns>
		protected static EntityList<Mall_DoorDeviceProject> GetMall_DoorDeviceProjects(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_DoorDeviceProjects(string.Empty, where, parameters, Mall_DoorDeviceProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorDeviceProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorDeviceProject objects.</returns>
		protected static EntityList<Mall_DoorDeviceProject> GetMall_DoorDeviceProjects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_DoorDeviceProjects(prefix, where, parameters, Mall_DoorDeviceProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorDeviceProject objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_DoorDeviceProject objects.</returns>
		protected static EntityList<Mall_DoorDeviceProject> GetMall_DoorDeviceProjects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_DoorDeviceProject.SelectFieldList + "FROM [dbo].[Mall_DoorDeviceProject] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_DoorDeviceProject>(reader);
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
        protected static EntityList<Mall_DoorDeviceProject> GetMall_DoorDeviceProjects(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorDeviceProject>(SelectFieldList, "FROM [dbo].[Mall_DoorDeviceProject] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_DoorDeviceProject objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_DoorDeviceProjectCount()
        {
            return GetMall_DoorDeviceProjectCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_DoorDeviceProject objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_DoorDeviceProjectCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_DoorDeviceProject] " + where;

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
		public static partial class Mall_DoorDeviceProject_Properties
		{
			public const string DoorDeviceID = "DoorDeviceID";
			public const string ProjectID = "ProjectID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"DoorDeviceID" , "int:"},
    			 {"ProjectID" , "int:"},
            };
		}
		#endregion
	}
}
