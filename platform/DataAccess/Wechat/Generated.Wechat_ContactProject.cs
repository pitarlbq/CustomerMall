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
	/// This object represents the properties and methods of a Wechat_ContactProject.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("WechatContactID: {WechatContactID}, ProjectID: {ProjectID}")]
	public partial class Wechat_ContactProject 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _wechatContactID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int WechatContactID
		{
			[DebuggerStepThrough()]
			get { return this._wechatContactID; }
			set 
			{
				if (this._wechatContactID != value) 
				{
					this._wechatContactID = value;
					this.IsDirty = true;	
					OnPropertyChanged("WechatContactID");
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
	[WechatContactID] int,
	[ProjectID] int
);

INSERT INTO [dbo].[Wechat_ContactProject] (
	[Wechat_ContactProject].[WechatContactID],
	[Wechat_ContactProject].[ProjectID]
) 
output 
	INSERTED.[WechatContactID],
	INSERTED.[ProjectID]
into @table
VALUES ( 
	@WechatContactID,
	@ProjectID 
); 

SELECT 
	[WechatContactID],
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
	[WechatContactID] int,
	[ProjectID] int
);

UPDATE [dbo].[Wechat_ContactProject] SET 
 
output 
	INSERTED.[WechatContactID],
	INSERTED.[ProjectID]
into @table
WHERE 
	[Wechat_ContactProject].[WechatContactID] = @WechatContactID
	AND [Wechat_ContactProject].[ProjectID] = @ProjectID

SELECT 
	[WechatContactID],
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
DELETE FROM [dbo].[Wechat_ContactProject]
WHERE 
	[Wechat_ContactProject].[WechatContactID] = @WechatContactID
	AND [Wechat_ContactProject].[ProjectID] = @ProjectID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_ContactProject() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_ContactProject(this.WechatContactID, this.ProjectID));
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
	[Wechat_ContactProject].[WechatContactID],
	[Wechat_ContactProject].[ProjectID]
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
                return "Wechat_ContactProject";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_ContactProject into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="wechatContactID">wechatContactID</param>
		/// <param name="projectID">projectID</param>
		public static void InsertWechat_ContactProject(int @wechatContactID, int @projectID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_ContactProject(@wechatContactID, @projectID, helper);
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
		/// Insert a Wechat_ContactProject into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="wechatContactID">wechatContactID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_ContactProject(int @wechatContactID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[WechatContactID] int,
	[ProjectID] int
);

INSERT INTO [dbo].[Wechat_ContactProject] (
	[Wechat_ContactProject].[WechatContactID],
	[Wechat_ContactProject].[ProjectID]
) 
output 
	INSERTED.[WechatContactID],
	INSERTED.[ProjectID]
into @table
VALUES ( 
	@WechatContactID,
	@ProjectID 
); 

SELECT 
	[WechatContactID],
	[ProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@WechatContactID", EntityBase.GetDatabaseValue(@wechatContactID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_ContactProject into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="wechatContactID">wechatContactID</param>
		/// <param name="projectID">projectID</param>
		public static void UpdateWechat_ContactProject(int @wechatContactID, int @projectID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_ContactProject(@wechatContactID, @projectID, helper);
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
		/// Updates a Wechat_ContactProject into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="wechatContactID">wechatContactID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_ContactProject(int @wechatContactID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[WechatContactID] int,
	[ProjectID] int
);

UPDATE [dbo].[Wechat_ContactProject] SET 
 
output 
	INSERTED.[WechatContactID],
	INSERTED.[ProjectID]
into @table
WHERE 
	[Wechat_ContactProject].[WechatContactID] = @WechatContactID
	AND [Wechat_ContactProject].[ProjectID] = @ProjectID

SELECT 
	[WechatContactID],
	[ProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@WechatContactID", EntityBase.GetDatabaseValue(@wechatContactID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_ContactProject from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="wechatContactID">wechatContactID</param>
		/// <param name="projectID">projectID</param>
		public static void DeleteWechat_ContactProject(int @wechatContactID, int @projectID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_ContactProject(@wechatContactID, @projectID, helper);
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
		/// Deletes a Wechat_ContactProject from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="wechatContactID">wechatContactID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_ContactProject(int @wechatContactID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_ContactProject]
WHERE 
	[Wechat_ContactProject].[WechatContactID] = @WechatContactID
	AND [Wechat_ContactProject].[ProjectID] = @ProjectID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@WechatContactID", @wechatContactID));
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_ContactProject object.
		/// </summary>
		/// <returns>The newly created Wechat_ContactProject object.</returns>
		public static Wechat_ContactProject CreateWechat_ContactProject()
		{
			return InitializeNew<Wechat_ContactProject>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_ContactProject by a Wechat_ContactProject's unique identifier.
		/// </summary>
		/// <param name="wechatContactID">wechatContactID</param>
		/// <param name="projectID">projectID</param>
		/// <returns>Wechat_ContactProject</returns>
		public static Wechat_ContactProject GetWechat_ContactProject(int @wechatContactID, int @projectID)
		{
			string commandText = @"
SELECT 
" + Wechat_ContactProject.SelectFieldList + @"
FROM [dbo].[Wechat_ContactProject] 
WHERE 
	[Wechat_ContactProject].[WechatContactID] = @WechatContactID
	AND [Wechat_ContactProject].[ProjectID] = @ProjectID " + Wechat_ContactProject.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@WechatContactID", @wechatContactID));
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			
			return GetOne<Wechat_ContactProject>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_ContactProject by a Wechat_ContactProject's unique identifier.
		/// </summary>
		/// <param name="wechatContactID">wechatContactID</param>
		/// <param name="projectID">projectID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_ContactProject</returns>
		public static Wechat_ContactProject GetWechat_ContactProject(int @wechatContactID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_ContactProject.SelectFieldList + @"
FROM [dbo].[Wechat_ContactProject] 
WHERE 
	[Wechat_ContactProject].[WechatContactID] = @WechatContactID
	AND [Wechat_ContactProject].[ProjectID] = @ProjectID " + Wechat_ContactProject.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@WechatContactID", @wechatContactID));
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			
			return GetOne<Wechat_ContactProject>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ContactProject objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_ContactProject objects.</returns>
		public static EntityList<Wechat_ContactProject> GetWechat_ContactProjects()
		{
			string commandText = @"
SELECT " + Wechat_ContactProject.SelectFieldList + "FROM [dbo].[Wechat_ContactProject] " + Wechat_ContactProject.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_ContactProject>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_ContactProject objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_ContactProject objects.</returns>
        public static EntityList<Wechat_ContactProject> GetWechat_ContactProjects(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_ContactProject>(SelectFieldList, "FROM [dbo].[Wechat_ContactProject]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_ContactProject objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_ContactProject objects.</returns>
        public static EntityList<Wechat_ContactProject> GetWechat_ContactProjects(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_ContactProject>(SelectFieldList, "FROM [dbo].[Wechat_ContactProject]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_ContactProject objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_ContactProject objects.</returns>
		protected static EntityList<Wechat_ContactProject> GetWechat_ContactProjects(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_ContactProjects(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ContactProject objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ContactProject objects.</returns>
		protected static EntityList<Wechat_ContactProject> GetWechat_ContactProjects(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_ContactProjects(string.Empty, where, parameters, Wechat_ContactProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ContactProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ContactProject objects.</returns>
		protected static EntityList<Wechat_ContactProject> GetWechat_ContactProjects(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_ContactProjects(prefix, where, parameters, Wechat_ContactProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ContactProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ContactProject objects.</returns>
		protected static EntityList<Wechat_ContactProject> GetWechat_ContactProjects(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_ContactProjects(string.Empty, where, parameters, Wechat_ContactProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ContactProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ContactProject objects.</returns>
		protected static EntityList<Wechat_ContactProject> GetWechat_ContactProjects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_ContactProjects(prefix, where, parameters, Wechat_ContactProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ContactProject objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_ContactProject objects.</returns>
		protected static EntityList<Wechat_ContactProject> GetWechat_ContactProjects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_ContactProject.SelectFieldList + "FROM [dbo].[Wechat_ContactProject] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_ContactProject>(reader);
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
        protected static EntityList<Wechat_ContactProject> GetWechat_ContactProjects(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_ContactProject>(SelectFieldList, "FROM [dbo].[Wechat_ContactProject] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_ContactProject objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_ContactProjectCount()
        {
            return GetWechat_ContactProjectCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_ContactProject objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_ContactProjectCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_ContactProject] " + where;

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
		public static partial class Wechat_ContactProject_Properties
		{
			public const string WechatContactID = "WechatContactID";
			public const string ProjectID = "ProjectID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"WechatContactID" , "int:"},
    			 {"ProjectID" , "int:"},
            };
		}
		#endregion
	}
}
