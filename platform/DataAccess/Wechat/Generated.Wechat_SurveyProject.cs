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
	/// This object represents the properties and methods of a Wechat_SurveyProject.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("Wechat_SurveyID: {Wechat_SurveyID}, ProjectID: {ProjectID}")]
	public partial class Wechat_SurveyProject 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _wechat_SurveyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int Wechat_SurveyID
		{
			[DebuggerStepThrough()]
			get { return this._wechat_SurveyID; }
			set 
			{
				if (this._wechat_SurveyID != value) 
				{
					this._wechat_SurveyID = value;
					this.IsDirty = true;	
					OnPropertyChanged("Wechat_SurveyID");
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
	[Wechat_SurveyID] int,
	[ProjectID] int
);

INSERT INTO [dbo].[Wechat_SurveyProject] (
	[Wechat_SurveyProject].[Wechat_SurveyID],
	[Wechat_SurveyProject].[ProjectID]
) 
output 
	INSERTED.[Wechat_SurveyID],
	INSERTED.[ProjectID]
into @table
VALUES ( 
	@Wechat_SurveyID,
	@ProjectID 
); 

SELECT 
	[Wechat_SurveyID],
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
	[Wechat_SurveyID] int,
	[ProjectID] int
);

UPDATE [dbo].[Wechat_SurveyProject] SET 
 
output 
	INSERTED.[Wechat_SurveyID],
	INSERTED.[ProjectID]
into @table
WHERE 
	[Wechat_SurveyProject].[Wechat_SurveyID] = @Wechat_SurveyID
	AND [Wechat_SurveyProject].[ProjectID] = @ProjectID

SELECT 
	[Wechat_SurveyID],
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
DELETE FROM [dbo].[Wechat_SurveyProject]
WHERE 
	[Wechat_SurveyProject].[Wechat_SurveyID] = @Wechat_SurveyID
	AND [Wechat_SurveyProject].[ProjectID] = @ProjectID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_SurveyProject() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_SurveyProject(this.Wechat_SurveyID, this.ProjectID));
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
	[Wechat_SurveyProject].[Wechat_SurveyID],
	[Wechat_SurveyProject].[ProjectID]
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
                return "Wechat_SurveyProject";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_SurveyProject into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="wechat_SurveyID">wechat_SurveyID</param>
		/// <param name="projectID">projectID</param>
		public static void InsertWechat_SurveyProject(int @wechat_SurveyID, int @projectID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_SurveyProject(@wechat_SurveyID, @projectID, helper);
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
		/// Insert a Wechat_SurveyProject into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="wechat_SurveyID">wechat_SurveyID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_SurveyProject(int @wechat_SurveyID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[Wechat_SurveyID] int,
	[ProjectID] int
);

INSERT INTO [dbo].[Wechat_SurveyProject] (
	[Wechat_SurveyProject].[Wechat_SurveyID],
	[Wechat_SurveyProject].[ProjectID]
) 
output 
	INSERTED.[Wechat_SurveyID],
	INSERTED.[ProjectID]
into @table
VALUES ( 
	@Wechat_SurveyID,
	@ProjectID 
); 

SELECT 
	[Wechat_SurveyID],
	[ProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Wechat_SurveyID", EntityBase.GetDatabaseValue(@wechat_SurveyID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_SurveyProject into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="wechat_SurveyID">wechat_SurveyID</param>
		/// <param name="projectID">projectID</param>
		public static void UpdateWechat_SurveyProject(int @wechat_SurveyID, int @projectID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_SurveyProject(@wechat_SurveyID, @projectID, helper);
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
		/// Updates a Wechat_SurveyProject into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="wechat_SurveyID">wechat_SurveyID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_SurveyProject(int @wechat_SurveyID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[Wechat_SurveyID] int,
	[ProjectID] int
);

UPDATE [dbo].[Wechat_SurveyProject] SET 
 
output 
	INSERTED.[Wechat_SurveyID],
	INSERTED.[ProjectID]
into @table
WHERE 
	[Wechat_SurveyProject].[Wechat_SurveyID] = @Wechat_SurveyID
	AND [Wechat_SurveyProject].[ProjectID] = @ProjectID

SELECT 
	[Wechat_SurveyID],
	[ProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Wechat_SurveyID", EntityBase.GetDatabaseValue(@wechat_SurveyID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_SurveyProject from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="wechat_SurveyID">wechat_SurveyID</param>
		/// <param name="projectID">projectID</param>
		public static void DeleteWechat_SurveyProject(int @wechat_SurveyID, int @projectID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_SurveyProject(@wechat_SurveyID, @projectID, helper);
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
		/// Deletes a Wechat_SurveyProject from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="wechat_SurveyID">wechat_SurveyID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_SurveyProject(int @wechat_SurveyID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_SurveyProject]
WHERE 
	[Wechat_SurveyProject].[Wechat_SurveyID] = @Wechat_SurveyID
	AND [Wechat_SurveyProject].[ProjectID] = @ProjectID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Wechat_SurveyID", @wechat_SurveyID));
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_SurveyProject object.
		/// </summary>
		/// <returns>The newly created Wechat_SurveyProject object.</returns>
		public static Wechat_SurveyProject CreateWechat_SurveyProject()
		{
			return InitializeNew<Wechat_SurveyProject>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_SurveyProject by a Wechat_SurveyProject's unique identifier.
		/// </summary>
		/// <param name="wechat_SurveyID">wechat_SurveyID</param>
		/// <param name="projectID">projectID</param>
		/// <returns>Wechat_SurveyProject</returns>
		public static Wechat_SurveyProject GetWechat_SurveyProject(int @wechat_SurveyID, int @projectID)
		{
			string commandText = @"
SELECT 
" + Wechat_SurveyProject.SelectFieldList + @"
FROM [dbo].[Wechat_SurveyProject] 
WHERE 
	[Wechat_SurveyProject].[Wechat_SurveyID] = @Wechat_SurveyID
	AND [Wechat_SurveyProject].[ProjectID] = @ProjectID " + Wechat_SurveyProject.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Wechat_SurveyID", @wechat_SurveyID));
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			
			return GetOne<Wechat_SurveyProject>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_SurveyProject by a Wechat_SurveyProject's unique identifier.
		/// </summary>
		/// <param name="wechat_SurveyID">wechat_SurveyID</param>
		/// <param name="projectID">projectID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_SurveyProject</returns>
		public static Wechat_SurveyProject GetWechat_SurveyProject(int @wechat_SurveyID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_SurveyProject.SelectFieldList + @"
FROM [dbo].[Wechat_SurveyProject] 
WHERE 
	[Wechat_SurveyProject].[Wechat_SurveyID] = @Wechat_SurveyID
	AND [Wechat_SurveyProject].[ProjectID] = @ProjectID " + Wechat_SurveyProject.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Wechat_SurveyID", @wechat_SurveyID));
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			
			return GetOne<Wechat_SurveyProject>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyProject objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_SurveyProject objects.</returns>
		public static EntityList<Wechat_SurveyProject> GetWechat_SurveyProjects()
		{
			string commandText = @"
SELECT " + Wechat_SurveyProject.SelectFieldList + "FROM [dbo].[Wechat_SurveyProject] " + Wechat_SurveyProject.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_SurveyProject>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_SurveyProject objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_SurveyProject objects.</returns>
        public static EntityList<Wechat_SurveyProject> GetWechat_SurveyProjects(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_SurveyProject>(SelectFieldList, "FROM [dbo].[Wechat_SurveyProject]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_SurveyProject objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_SurveyProject objects.</returns>
        public static EntityList<Wechat_SurveyProject> GetWechat_SurveyProjects(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_SurveyProject>(SelectFieldList, "FROM [dbo].[Wechat_SurveyProject]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_SurveyProject objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_SurveyProject objects.</returns>
		protected static EntityList<Wechat_SurveyProject> GetWechat_SurveyProjects(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_SurveyProjects(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyProject objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_SurveyProject objects.</returns>
		protected static EntityList<Wechat_SurveyProject> GetWechat_SurveyProjects(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_SurveyProjects(string.Empty, where, parameters, Wechat_SurveyProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_SurveyProject objects.</returns>
		protected static EntityList<Wechat_SurveyProject> GetWechat_SurveyProjects(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_SurveyProjects(prefix, where, parameters, Wechat_SurveyProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_SurveyProject objects.</returns>
		protected static EntityList<Wechat_SurveyProject> GetWechat_SurveyProjects(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_SurveyProjects(string.Empty, where, parameters, Wechat_SurveyProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_SurveyProject objects.</returns>
		protected static EntityList<Wechat_SurveyProject> GetWechat_SurveyProjects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_SurveyProjects(prefix, where, parameters, Wechat_SurveyProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_SurveyProject objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_SurveyProject objects.</returns>
		protected static EntityList<Wechat_SurveyProject> GetWechat_SurveyProjects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_SurveyProject.SelectFieldList + "FROM [dbo].[Wechat_SurveyProject] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_SurveyProject>(reader);
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
        protected static EntityList<Wechat_SurveyProject> GetWechat_SurveyProjects(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_SurveyProject>(SelectFieldList, "FROM [dbo].[Wechat_SurveyProject] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_SurveyProject objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_SurveyProjectCount()
        {
            return GetWechat_SurveyProjectCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_SurveyProject objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_SurveyProjectCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_SurveyProject] " + where;

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
		public static partial class Wechat_SurveyProject_Properties
		{
			public const string Wechat_SurveyID = "Wechat_SurveyID";
			public const string ProjectID = "ProjectID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"Wechat_SurveyID" , "int:"},
    			 {"ProjectID" , "int:"},
            };
		}
		#endregion
	}
}
