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
	/// This object represents the properties and methods of a Mall_AmountRuleProject.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("Mall_AmountRuleID: {Mall_AmountRuleID}, ProjectID: {ProjectID}")]
	public partial class Mall_AmountRuleProject 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _mall_AmountRuleID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int Mall_AmountRuleID
		{
			[DebuggerStepThrough()]
			get { return this._mall_AmountRuleID; }
			set 
			{
				if (this._mall_AmountRuleID != value) 
				{
					this._mall_AmountRuleID = value;
					this.IsDirty = true;	
					OnPropertyChanged("Mall_AmountRuleID");
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
	[Mall_AmountRuleID] int,
	[ProjectID] int
);

INSERT INTO [dbo].[Mall_AmountRuleProject] (
	[Mall_AmountRuleProject].[Mall_AmountRuleID],
	[Mall_AmountRuleProject].[ProjectID]
) 
output 
	INSERTED.[Mall_AmountRuleID],
	INSERTED.[ProjectID]
into @table
VALUES ( 
	@Mall_AmountRuleID,
	@ProjectID 
); 

SELECT 
	[Mall_AmountRuleID],
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
	[Mall_AmountRuleID] int,
	[ProjectID] int
);

UPDATE [dbo].[Mall_AmountRuleProject] SET 
 
output 
	INSERTED.[Mall_AmountRuleID],
	INSERTED.[ProjectID]
into @table
WHERE 
	[Mall_AmountRuleProject].[Mall_AmountRuleID] = @Mall_AmountRuleID
	AND [Mall_AmountRuleProject].[ProjectID] = @ProjectID

SELECT 
	[Mall_AmountRuleID],
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
DELETE FROM [dbo].[Mall_AmountRuleProject]
WHERE 
	[Mall_AmountRuleProject].[Mall_AmountRuleID] = @Mall_AmountRuleID
	AND [Mall_AmountRuleProject].[ProjectID] = @ProjectID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_AmountRuleProject() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_AmountRuleProject(this.Mall_AmountRuleID, this.ProjectID));
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
	[Mall_AmountRuleProject].[Mall_AmountRuleID],
	[Mall_AmountRuleProject].[ProjectID]
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
                return "Mall_AmountRuleProject";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_AmountRuleProject into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="mall_AmountRuleID">mall_AmountRuleID</param>
		/// <param name="projectID">projectID</param>
		public static void InsertMall_AmountRuleProject(int @mall_AmountRuleID, int @projectID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_AmountRuleProject(@mall_AmountRuleID, @projectID, helper);
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
		/// Insert a Mall_AmountRuleProject into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="mall_AmountRuleID">mall_AmountRuleID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_AmountRuleProject(int @mall_AmountRuleID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[Mall_AmountRuleID] int,
	[ProjectID] int
);

INSERT INTO [dbo].[Mall_AmountRuleProject] (
	[Mall_AmountRuleProject].[Mall_AmountRuleID],
	[Mall_AmountRuleProject].[ProjectID]
) 
output 
	INSERTED.[Mall_AmountRuleID],
	INSERTED.[ProjectID]
into @table
VALUES ( 
	@Mall_AmountRuleID,
	@ProjectID 
); 

SELECT 
	[Mall_AmountRuleID],
	[ProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Mall_AmountRuleID", EntityBase.GetDatabaseValue(@mall_AmountRuleID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_AmountRuleProject into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="mall_AmountRuleID">mall_AmountRuleID</param>
		/// <param name="projectID">projectID</param>
		public static void UpdateMall_AmountRuleProject(int @mall_AmountRuleID, int @projectID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_AmountRuleProject(@mall_AmountRuleID, @projectID, helper);
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
		/// Updates a Mall_AmountRuleProject into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="mall_AmountRuleID">mall_AmountRuleID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_AmountRuleProject(int @mall_AmountRuleID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[Mall_AmountRuleID] int,
	[ProjectID] int
);

UPDATE [dbo].[Mall_AmountRuleProject] SET 
 
output 
	INSERTED.[Mall_AmountRuleID],
	INSERTED.[ProjectID]
into @table
WHERE 
	[Mall_AmountRuleProject].[Mall_AmountRuleID] = @Mall_AmountRuleID
	AND [Mall_AmountRuleProject].[ProjectID] = @ProjectID

SELECT 
	[Mall_AmountRuleID],
	[ProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Mall_AmountRuleID", EntityBase.GetDatabaseValue(@mall_AmountRuleID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_AmountRuleProject from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="mall_AmountRuleID">mall_AmountRuleID</param>
		/// <param name="projectID">projectID</param>
		public static void DeleteMall_AmountRuleProject(int @mall_AmountRuleID, int @projectID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_AmountRuleProject(@mall_AmountRuleID, @projectID, helper);
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
		/// Deletes a Mall_AmountRuleProject from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="mall_AmountRuleID">mall_AmountRuleID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_AmountRuleProject(int @mall_AmountRuleID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_AmountRuleProject]
WHERE 
	[Mall_AmountRuleProject].[Mall_AmountRuleID] = @Mall_AmountRuleID
	AND [Mall_AmountRuleProject].[ProjectID] = @ProjectID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Mall_AmountRuleID", @mall_AmountRuleID));
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_AmountRuleProject object.
		/// </summary>
		/// <returns>The newly created Mall_AmountRuleProject object.</returns>
		public static Mall_AmountRuleProject CreateMall_AmountRuleProject()
		{
			return InitializeNew<Mall_AmountRuleProject>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_AmountRuleProject by a Mall_AmountRuleProject's unique identifier.
		/// </summary>
		/// <param name="mall_AmountRuleID">mall_AmountRuleID</param>
		/// <param name="projectID">projectID</param>
		/// <returns>Mall_AmountRuleProject</returns>
		public static Mall_AmountRuleProject GetMall_AmountRuleProject(int @mall_AmountRuleID, int @projectID)
		{
			string commandText = @"
SELECT 
" + Mall_AmountRuleProject.SelectFieldList + @"
FROM [dbo].[Mall_AmountRuleProject] 
WHERE 
	[Mall_AmountRuleProject].[Mall_AmountRuleID] = @Mall_AmountRuleID
	AND [Mall_AmountRuleProject].[ProjectID] = @ProjectID " + Mall_AmountRuleProject.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Mall_AmountRuleID", @mall_AmountRuleID));
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			
			return GetOne<Mall_AmountRuleProject>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_AmountRuleProject by a Mall_AmountRuleProject's unique identifier.
		/// </summary>
		/// <param name="mall_AmountRuleID">mall_AmountRuleID</param>
		/// <param name="projectID">projectID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_AmountRuleProject</returns>
		public static Mall_AmountRuleProject GetMall_AmountRuleProject(int @mall_AmountRuleID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_AmountRuleProject.SelectFieldList + @"
FROM [dbo].[Mall_AmountRuleProject] 
WHERE 
	[Mall_AmountRuleProject].[Mall_AmountRuleID] = @Mall_AmountRuleID
	AND [Mall_AmountRuleProject].[ProjectID] = @ProjectID " + Mall_AmountRuleProject.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Mall_AmountRuleID", @mall_AmountRuleID));
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			
			return GetOne<Mall_AmountRuleProject>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleProject objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_AmountRuleProject objects.</returns>
		public static EntityList<Mall_AmountRuleProject> GetMall_AmountRuleProjects()
		{
			string commandText = @"
SELECT " + Mall_AmountRuleProject.SelectFieldList + "FROM [dbo].[Mall_AmountRuleProject] " + Mall_AmountRuleProject.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_AmountRuleProject>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_AmountRuleProject objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_AmountRuleProject objects.</returns>
        public static EntityList<Mall_AmountRuleProject> GetMall_AmountRuleProjects(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_AmountRuleProject>(SelectFieldList, "FROM [dbo].[Mall_AmountRuleProject]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_AmountRuleProject objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_AmountRuleProject objects.</returns>
        public static EntityList<Mall_AmountRuleProject> GetMall_AmountRuleProjects(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_AmountRuleProject>(SelectFieldList, "FROM [dbo].[Mall_AmountRuleProject]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleProject objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_AmountRuleProject objects.</returns>
		protected static EntityList<Mall_AmountRuleProject> GetMall_AmountRuleProjects(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_AmountRuleProjects(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleProject objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_AmountRuleProject objects.</returns>
		protected static EntityList<Mall_AmountRuleProject> GetMall_AmountRuleProjects(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_AmountRuleProjects(string.Empty, where, parameters, Mall_AmountRuleProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_AmountRuleProject objects.</returns>
		protected static EntityList<Mall_AmountRuleProject> GetMall_AmountRuleProjects(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_AmountRuleProjects(prefix, where, parameters, Mall_AmountRuleProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_AmountRuleProject objects.</returns>
		protected static EntityList<Mall_AmountRuleProject> GetMall_AmountRuleProjects(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_AmountRuleProjects(string.Empty, where, parameters, Mall_AmountRuleProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_AmountRuleProject objects.</returns>
		protected static EntityList<Mall_AmountRuleProject> GetMall_AmountRuleProjects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_AmountRuleProjects(prefix, where, parameters, Mall_AmountRuleProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleProject objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_AmountRuleProject objects.</returns>
		protected static EntityList<Mall_AmountRuleProject> GetMall_AmountRuleProjects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_AmountRuleProject.SelectFieldList + "FROM [dbo].[Mall_AmountRuleProject] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_AmountRuleProject>(reader);
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
        protected static EntityList<Mall_AmountRuleProject> GetMall_AmountRuleProjects(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_AmountRuleProject>(SelectFieldList, "FROM [dbo].[Mall_AmountRuleProject] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_AmountRuleProject objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_AmountRuleProjectCount()
        {
            return GetMall_AmountRuleProjectCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_AmountRuleProject objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_AmountRuleProjectCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_AmountRuleProject] " + where;

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
		public static partial class Mall_AmountRuleProject_Properties
		{
			public const string Mall_AmountRuleID = "Mall_AmountRuleID";
			public const string ProjectID = "ProjectID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"Mall_AmountRuleID" , "int:"},
    			 {"ProjectID" , "int:"},
            };
		}
		#endregion
	}
}
