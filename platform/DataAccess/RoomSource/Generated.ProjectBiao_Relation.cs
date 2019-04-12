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
	/// This object represents the properties and methods of a ProjectBiao_Relation.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ProjectBiao_Relation 
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
		private int _projectBiaoID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ProjectBiaoID
		{
			[DebuggerStepThrough()]
			get { return this._projectBiaoID; }
			set 
			{
				if (this._projectBiaoID != value) 
				{
					this._projectBiaoID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectBiaoID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _reationID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ReationID
		{
			[DebuggerStepThrough()]
			get { return this._reationID; }
			set 
			{
				if (this._reationID != value) 
				{
					this._reationID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ReationID");
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
	[ProjectBiaoID] int,
	[ReationID] int,
	[AddTime] datetime
);

INSERT INTO [dbo].[ProjectBiao_Relation] (
	[ProjectBiao_Relation].[ProjectBiaoID],
	[ProjectBiao_Relation].[ReationID],
	[ProjectBiao_Relation].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectBiaoID],
	INSERTED.[ReationID],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@ProjectBiaoID,
	@ReationID,
	@AddTime 
); 

SELECT 
	[ID],
	[ProjectBiaoID],
	[ReationID],
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
	[ProjectBiaoID] int,
	[ReationID] int,
	[AddTime] datetime
);

UPDATE [dbo].[ProjectBiao_Relation] SET 
	[ProjectBiao_Relation].[ProjectBiaoID] = @ProjectBiaoID,
	[ProjectBiao_Relation].[ReationID] = @ReationID,
	[ProjectBiao_Relation].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[ProjectBiaoID],
	INSERTED.[ReationID],
	INSERTED.[AddTime]
into @table
WHERE 
	[ProjectBiao_Relation].[ID] = @ID

SELECT 
	[ID],
	[ProjectBiaoID],
	[ReationID],
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
DELETE FROM [dbo].[ProjectBiao_Relation]
WHERE 
	[ProjectBiao_Relation].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ProjectBiao_Relation() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetProjectBiao_Relation(this.ID));
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
	[ProjectBiao_Relation].[ID],
	[ProjectBiao_Relation].[ProjectBiaoID],
	[ProjectBiao_Relation].[ReationID],
	[ProjectBiao_Relation].[AddTime]
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
                return "ProjectBiao_Relation";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ProjectBiao_Relation into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectBiaoID">projectBiaoID</param>
		/// <param name="reationID">reationID</param>
		/// <param name="addTime">addTime</param>
		public static void InsertProjectBiao_Relation(int @projectBiaoID, int @reationID, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertProjectBiao_Relation(@projectBiaoID, @reationID, @addTime, helper);
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
		/// Insert a ProjectBiao_Relation into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectBiaoID">projectBiaoID</param>
		/// <param name="reationID">reationID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertProjectBiao_Relation(int @projectBiaoID, int @reationID, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectBiaoID] int,
	[ReationID] int,
	[AddTime] datetime
);

INSERT INTO [dbo].[ProjectBiao_Relation] (
	[ProjectBiao_Relation].[ProjectBiaoID],
	[ProjectBiao_Relation].[ReationID],
	[ProjectBiao_Relation].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectBiaoID],
	INSERTED.[ReationID],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@ProjectBiaoID,
	@ReationID,
	@AddTime 
); 

SELECT 
	[ID],
	[ProjectBiaoID],
	[ReationID],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectBiaoID", EntityBase.GetDatabaseValue(@projectBiaoID)));
			parameters.Add(new SqlParameter("@ReationID", EntityBase.GetDatabaseValue(@reationID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ProjectBiao_Relation into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectBiaoID">projectBiaoID</param>
		/// <param name="reationID">reationID</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateProjectBiao_Relation(int @iD, int @projectBiaoID, int @reationID, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateProjectBiao_Relation(@iD, @projectBiaoID, @reationID, @addTime, helper);
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
		/// Updates a ProjectBiao_Relation into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectBiaoID">projectBiaoID</param>
		/// <param name="reationID">reationID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateProjectBiao_Relation(int @iD, int @projectBiaoID, int @reationID, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectBiaoID] int,
	[ReationID] int,
	[AddTime] datetime
);

UPDATE [dbo].[ProjectBiao_Relation] SET 
	[ProjectBiao_Relation].[ProjectBiaoID] = @ProjectBiaoID,
	[ProjectBiao_Relation].[ReationID] = @ReationID,
	[ProjectBiao_Relation].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[ProjectBiaoID],
	INSERTED.[ReationID],
	INSERTED.[AddTime]
into @table
WHERE 
	[ProjectBiao_Relation].[ID] = @ID

SELECT 
	[ID],
	[ProjectBiaoID],
	[ReationID],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProjectBiaoID", EntityBase.GetDatabaseValue(@projectBiaoID)));
			parameters.Add(new SqlParameter("@ReationID", EntityBase.GetDatabaseValue(@reationID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ProjectBiao_Relation from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteProjectBiao_Relation(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteProjectBiao_Relation(@iD, helper);
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
		/// Deletes a ProjectBiao_Relation from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteProjectBiao_Relation(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ProjectBiao_Relation]
WHERE 
	[ProjectBiao_Relation].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ProjectBiao_Relation object.
		/// </summary>
		/// <returns>The newly created ProjectBiao_Relation object.</returns>
		public static ProjectBiao_Relation CreateProjectBiao_Relation()
		{
			return InitializeNew<ProjectBiao_Relation>();
		}
		
		/// <summary>
		/// Retrieve information for a ProjectBiao_Relation by a ProjectBiao_Relation's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ProjectBiao_Relation</returns>
		public static ProjectBiao_Relation GetProjectBiao_Relation(int @iD)
		{
			string commandText = @"
SELECT 
" + ProjectBiao_Relation.SelectFieldList + @"
FROM [dbo].[ProjectBiao_Relation] 
WHERE 
	[ProjectBiao_Relation].[ID] = @ID " + ProjectBiao_Relation.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ProjectBiao_Relation>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ProjectBiao_Relation by a ProjectBiao_Relation's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ProjectBiao_Relation</returns>
		public static ProjectBiao_Relation GetProjectBiao_Relation(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ProjectBiao_Relation.SelectFieldList + @"
FROM [dbo].[ProjectBiao_Relation] 
WHERE 
	[ProjectBiao_Relation].[ID] = @ID " + ProjectBiao_Relation.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ProjectBiao_Relation>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ProjectBiao_Relation objects.
		/// </summary>
		/// <returns>The retrieved collection of ProjectBiao_Relation objects.</returns>
		public static EntityList<ProjectBiao_Relation> GetProjectBiao_Relations()
		{
			string commandText = @"
SELECT " + ProjectBiao_Relation.SelectFieldList + "FROM [dbo].[ProjectBiao_Relation] " + ProjectBiao_Relation.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ProjectBiao_Relation>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ProjectBiao_Relation objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ProjectBiao_Relation objects.</returns>
        public static EntityList<ProjectBiao_Relation> GetProjectBiao_Relations(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectBiao_Relation>(SelectFieldList, "FROM [dbo].[ProjectBiao_Relation]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ProjectBiao_Relation objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ProjectBiao_Relation objects.</returns>
        public static EntityList<ProjectBiao_Relation> GetProjectBiao_Relations(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectBiao_Relation>(SelectFieldList, "FROM [dbo].[ProjectBiao_Relation]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ProjectBiao_Relation objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ProjectBiao_Relation objects.</returns>
		protected static EntityList<ProjectBiao_Relation> GetProjectBiao_Relations(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectBiao_Relations(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ProjectBiao_Relation objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ProjectBiao_Relation objects.</returns>
		protected static EntityList<ProjectBiao_Relation> GetProjectBiao_Relations(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectBiao_Relations(string.Empty, where, parameters, ProjectBiao_Relation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectBiao_Relation objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ProjectBiao_Relation objects.</returns>
		protected static EntityList<ProjectBiao_Relation> GetProjectBiao_Relations(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectBiao_Relations(prefix, where, parameters, ProjectBiao_Relation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectBiao_Relation objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ProjectBiao_Relation objects.</returns>
		protected static EntityList<ProjectBiao_Relation> GetProjectBiao_Relations(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjectBiao_Relations(string.Empty, where, parameters, ProjectBiao_Relation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectBiao_Relation objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ProjectBiao_Relation objects.</returns>
		protected static EntityList<ProjectBiao_Relation> GetProjectBiao_Relations(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjectBiao_Relations(prefix, where, parameters, ProjectBiao_Relation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectBiao_Relation objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ProjectBiao_Relation objects.</returns>
		protected static EntityList<ProjectBiao_Relation> GetProjectBiao_Relations(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ProjectBiao_Relation.SelectFieldList + "FROM [dbo].[ProjectBiao_Relation] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ProjectBiao_Relation>(reader);
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
        protected static EntityList<ProjectBiao_Relation> GetProjectBiao_Relations(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectBiao_Relation>(SelectFieldList, "FROM [dbo].[ProjectBiao_Relation] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ProjectBiao_Relation objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetProjectBiao_RelationCount()
        {
            return GetProjectBiao_RelationCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ProjectBiao_Relation objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetProjectBiao_RelationCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ProjectBiao_Relation] " + where;

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
		public static partial class ProjectBiao_Relation_Properties
		{
			public const string ID = "ID";
			public const string ProjectBiaoID = "ProjectBiaoID";
			public const string ReationID = "ReationID";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProjectBiaoID" , "int:"},
    			 {"ReationID" , "int:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
