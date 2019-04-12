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
	/// This object represents the properties and methods of a WechatUser_Project.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ProjectID: {ProjectID}, OpenID: {OpenID}")]
	public partial class WechatUser_Project 
	{
		#region Public Properties
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _openID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public string OpenID
		{
			[DebuggerStepThrough()]
			get { return this._openID; }
			set 
			{
				if (this._openID != value) 
				{
					this._openID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OpenID");
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
	[ProjectID] int,
	[OpenID] nvarchar(255)
);

INSERT INTO [dbo].[WechatUser_Project] (
	[WechatUser_Project].[ProjectID],
	[WechatUser_Project].[OpenID]
) 
output 
	INSERTED.[ProjectID],
	INSERTED.[OpenID]
into @table
VALUES ( 
	@ProjectID,
	@OpenID 
); 

SELECT 
	[ProjectID],
	[OpenID] 
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
	[ProjectID] int,
	[OpenID] nvarchar(255)
);

UPDATE [dbo].[WechatUser_Project] SET 
 
output 
	INSERTED.[ProjectID],
	INSERTED.[OpenID]
into @table
WHERE 
	[WechatUser_Project].[ProjectID] = @ProjectID
	AND [WechatUser_Project].[OpenID] = @OpenID

SELECT 
	[ProjectID],
	[OpenID] 
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
DELETE FROM [dbo].[WechatUser_Project]
WHERE 
	[WechatUser_Project].[ProjectID] = @ProjectID
	AND [WechatUser_Project].[OpenID] = @OpenID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public WechatUser_Project() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechatUser_Project(this.ProjectID, this.OpenID));
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
	[WechatUser_Project].[ProjectID],
	[WechatUser_Project].[OpenID]
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
                return "WechatUser_Project";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a WechatUser_Project into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="openID">openID</param>
		public static void InsertWechatUser_Project(int @projectID, string @openID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechatUser_Project(@projectID, @openID, helper);
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
		/// Insert a WechatUser_Project into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="openID">openID</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechatUser_Project(int @projectID, string @openID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ProjectID] int,
	[OpenID] nvarchar(255)
);

INSERT INTO [dbo].[WechatUser_Project] (
	[WechatUser_Project].[ProjectID],
	[WechatUser_Project].[OpenID]
) 
output 
	INSERTED.[ProjectID],
	INSERTED.[OpenID]
into @table
VALUES ( 
	@ProjectID,
	@OpenID 
); 

SELECT 
	[ProjectID],
	[OpenID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a WechatUser_Project into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="openID">openID</param>
		public static void UpdateWechatUser_Project(int @projectID, string @openID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechatUser_Project(@projectID, @openID, helper);
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
		/// Updates a WechatUser_Project into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="openID">openID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechatUser_Project(int @projectID, string @openID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ProjectID] int,
	[OpenID] nvarchar(255)
);

UPDATE [dbo].[WechatUser_Project] SET 
 
output 
	INSERTED.[ProjectID],
	INSERTED.[OpenID]
into @table
WHERE 
	[WechatUser_Project].[ProjectID] = @ProjectID
	AND [WechatUser_Project].[OpenID] = @OpenID

SELECT 
	[ProjectID],
	[OpenID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a WechatUser_Project from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="openID">openID</param>
		public static void DeleteWechatUser_Project(int @projectID, string @openID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechatUser_Project(@projectID, @openID, helper);
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
		/// Deletes a WechatUser_Project from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="openID">openID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechatUser_Project(int @projectID, string @openID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[WechatUser_Project]
WHERE 
	[WechatUser_Project].[ProjectID] = @ProjectID
	AND [WechatUser_Project].[OpenID] = @OpenID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			parameters.Add(new SqlParameter("@OpenID", @openID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new WechatUser_Project object.
		/// </summary>
		/// <returns>The newly created WechatUser_Project object.</returns>
		public static WechatUser_Project CreateWechatUser_Project()
		{
			return InitializeNew<WechatUser_Project>();
		}
		
		/// <summary>
		/// Retrieve information for a WechatUser_Project by a WechatUser_Project's unique identifier.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="openID">openID</param>
		/// <returns>WechatUser_Project</returns>
		public static WechatUser_Project GetWechatUser_Project(int @projectID, string @openID)
		{
			string commandText = @"
SELECT 
" + WechatUser_Project.SelectFieldList + @"
FROM [dbo].[WechatUser_Project] 
WHERE 
	[WechatUser_Project].[ProjectID] = @ProjectID
	AND [WechatUser_Project].[OpenID] = @OpenID " + WechatUser_Project.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			parameters.Add(new SqlParameter("@OpenID", @openID));
			
			return GetOne<WechatUser_Project>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a WechatUser_Project by a WechatUser_Project's unique identifier.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="openID">openID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>WechatUser_Project</returns>
		public static WechatUser_Project GetWechatUser_Project(int @projectID, string @openID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + WechatUser_Project.SelectFieldList + @"
FROM [dbo].[WechatUser_Project] 
WHERE 
	[WechatUser_Project].[ProjectID] = @ProjectID
	AND [WechatUser_Project].[OpenID] = @OpenID " + WechatUser_Project.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			parameters.Add(new SqlParameter("@OpenID", @openID));
			
			return GetOne<WechatUser_Project>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection WechatUser_Project objects.
		/// </summary>
		/// <returns>The retrieved collection of WechatUser_Project objects.</returns>
		public static EntityList<WechatUser_Project> GetWechatUser_Projects()
		{
			string commandText = @"
SELECT " + WechatUser_Project.SelectFieldList + "FROM [dbo].[WechatUser_Project] " + WechatUser_Project.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<WechatUser_Project>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection WechatUser_Project objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of WechatUser_Project objects.</returns>
        public static EntityList<WechatUser_Project> GetWechatUser_Projects(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<WechatUser_Project>(SelectFieldList, "FROM [dbo].[WechatUser_Project]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection WechatUser_Project objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of WechatUser_Project objects.</returns>
        public static EntityList<WechatUser_Project> GetWechatUser_Projects(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<WechatUser_Project>(SelectFieldList, "FROM [dbo].[WechatUser_Project]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection WechatUser_Project objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of WechatUser_Project objects.</returns>
		protected static EntityList<WechatUser_Project> GetWechatUser_Projects(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechatUser_Projects(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection WechatUser_Project objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of WechatUser_Project objects.</returns>
		protected static EntityList<WechatUser_Project> GetWechatUser_Projects(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechatUser_Projects(string.Empty, where, parameters, WechatUser_Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection WechatUser_Project objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of WechatUser_Project objects.</returns>
		protected static EntityList<WechatUser_Project> GetWechatUser_Projects(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechatUser_Projects(prefix, where, parameters, WechatUser_Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection WechatUser_Project objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of WechatUser_Project objects.</returns>
		protected static EntityList<WechatUser_Project> GetWechatUser_Projects(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechatUser_Projects(string.Empty, where, parameters, WechatUser_Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection WechatUser_Project objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of WechatUser_Project objects.</returns>
		protected static EntityList<WechatUser_Project> GetWechatUser_Projects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechatUser_Projects(prefix, where, parameters, WechatUser_Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection WechatUser_Project objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of WechatUser_Project objects.</returns>
		protected static EntityList<WechatUser_Project> GetWechatUser_Projects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + WechatUser_Project.SelectFieldList + "FROM [dbo].[WechatUser_Project] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<WechatUser_Project>(reader);
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
        protected static EntityList<WechatUser_Project> GetWechatUser_Projects(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<WechatUser_Project>(SelectFieldList, "FROM [dbo].[WechatUser_Project] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of WechatUser_Project objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechatUser_ProjectCount()
        {
            return GetWechatUser_ProjectCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of WechatUser_Project objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechatUser_ProjectCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[WechatUser_Project] " + where;

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
		public static partial class WechatUser_Project_Properties
		{
			public const string ProjectID = "ProjectID";
			public const string OpenID = "OpenID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ProjectID" , "int:"},
    			 {"OpenID" , "string:"},
            };
		}
		#endregion
	}
}
