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
	/// This object represents the properties and methods of a SysManualCategory.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class SysManualCategory 
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
		private string _categoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CategoryName
		{
			[DebuggerStepThrough()]
			get { return this._categoryName; }
			set 
			{
				if (this._categoryName != value) 
				{
					this._categoryName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CategoryName");
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
		private int _sortBy = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SortBy
		{
			[DebuggerStepThrough()]
			get { return this._sortBy; }
			set 
			{
				if (this._sortBy != value) 
				{
					this._sortBy = value;
					this.IsDirty = true;	
					OnPropertyChanged("SortBy");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _status = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Status
		{
			[DebuggerStepThrough()]
			get { return this._status; }
			set 
			{
				if (this._status != value) 
				{
					this._status = value;
					this.IsDirty = true;	
					OnPropertyChanged("Status");
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
	[CategoryName] nvarchar(500),
	[AddTime] datetime,
	[SortBy] int,
	[Status] int
);

INSERT INTO [dbo].[SysManualCategory] (
	[SysManualCategory].[CategoryName],
	[SysManualCategory].[AddTime],
	[SysManualCategory].[SortBy],
	[SysManualCategory].[Status]
) 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[AddTime],
	INSERTED.[SortBy],
	INSERTED.[Status]
into @table
VALUES ( 
	@CategoryName,
	@AddTime,
	@SortBy,
	@Status 
); 

SELECT 
	[ID],
	[CategoryName],
	[AddTime],
	[SortBy],
	[Status] 
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
	[CategoryName] nvarchar(500),
	[AddTime] datetime,
	[SortBy] int,
	[Status] int
);

UPDATE [dbo].[SysManualCategory] SET 
	[SysManualCategory].[CategoryName] = @CategoryName,
	[SysManualCategory].[AddTime] = @AddTime,
	[SysManualCategory].[SortBy] = @SortBy,
	[SysManualCategory].[Status] = @Status 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[AddTime],
	INSERTED.[SortBy],
	INSERTED.[Status]
into @table
WHERE 
	[SysManualCategory].[ID] = @ID

SELECT 
	[ID],
	[CategoryName],
	[AddTime],
	[SortBy],
	[Status] 
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
DELETE FROM [dbo].[SysManualCategory]
WHERE 
	[SysManualCategory].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public SysManualCategory() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetSysManualCategory(this.ID));
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
	[SysManualCategory].[ID],
	[SysManualCategory].[CategoryName],
	[SysManualCategory].[AddTime],
	[SysManualCategory].[SortBy],
	[SysManualCategory].[Status]
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
                return "SysManualCategory";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a SysManualCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="categoryName">categoryName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortBy">sortBy</param>
		/// <param name="status">status</param>
		public static void InsertSysManualCategory(string @categoryName, DateTime @addTime, int @sortBy, int @status)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertSysManualCategory(@categoryName, @addTime, @sortBy, @status, helper);
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
		/// Insert a SysManualCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="categoryName">categoryName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortBy">sortBy</param>
		/// <param name="status">status</param>
		/// <param name="helper">helper</param>
		internal static void InsertSysManualCategory(string @categoryName, DateTime @addTime, int @sortBy, int @status, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CategoryName] nvarchar(500),
	[AddTime] datetime,
	[SortBy] int,
	[Status] int
);

INSERT INTO [dbo].[SysManualCategory] (
	[SysManualCategory].[CategoryName],
	[SysManualCategory].[AddTime],
	[SysManualCategory].[SortBy],
	[SysManualCategory].[Status]
) 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[AddTime],
	INSERTED.[SortBy],
	INSERTED.[Status]
into @table
VALUES ( 
	@CategoryName,
	@AddTime,
	@SortBy,
	@Status 
); 

SELECT 
	[ID],
	[CategoryName],
	[AddTime],
	[SortBy],
	[Status] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CategoryName", EntityBase.GetDatabaseValue(@categoryName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@SortBy", EntityBase.GetDatabaseValue(@sortBy)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a SysManualCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortBy">sortBy</param>
		/// <param name="status">status</param>
		public static void UpdateSysManualCategory(int @iD, string @categoryName, DateTime @addTime, int @sortBy, int @status)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateSysManualCategory(@iD, @categoryName, @addTime, @sortBy, @status, helper);
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
		/// Updates a SysManualCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortBy">sortBy</param>
		/// <param name="status">status</param>
		/// <param name="helper">helper</param>
		internal static void UpdateSysManualCategory(int @iD, string @categoryName, DateTime @addTime, int @sortBy, int @status, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CategoryName] nvarchar(500),
	[AddTime] datetime,
	[SortBy] int,
	[Status] int
);

UPDATE [dbo].[SysManualCategory] SET 
	[SysManualCategory].[CategoryName] = @CategoryName,
	[SysManualCategory].[AddTime] = @AddTime,
	[SysManualCategory].[SortBy] = @SortBy,
	[SysManualCategory].[Status] = @Status 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[AddTime],
	INSERTED.[SortBy],
	INSERTED.[Status]
into @table
WHERE 
	[SysManualCategory].[ID] = @ID

SELECT 
	[ID],
	[CategoryName],
	[AddTime],
	[SortBy],
	[Status] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@CategoryName", EntityBase.GetDatabaseValue(@categoryName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@SortBy", EntityBase.GetDatabaseValue(@sortBy)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a SysManualCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteSysManualCategory(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteSysManualCategory(@iD, helper);
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
		/// Deletes a SysManualCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteSysManualCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[SysManualCategory]
WHERE 
	[SysManualCategory].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new SysManualCategory object.
		/// </summary>
		/// <returns>The newly created SysManualCategory object.</returns>
		public static SysManualCategory CreateSysManualCategory()
		{
			return InitializeNew<SysManualCategory>();
		}
		
		/// <summary>
		/// Retrieve information for a SysManualCategory by a SysManualCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>SysManualCategory</returns>
		public static SysManualCategory GetSysManualCategory(int @iD)
		{
			string commandText = @"
SELECT 
" + SysManualCategory.SelectFieldList + @"
FROM [dbo].[SysManualCategory] 
WHERE 
	[SysManualCategory].[ID] = @ID " + SysManualCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<SysManualCategory>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a SysManualCategory by a SysManualCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>SysManualCategory</returns>
		public static SysManualCategory GetSysManualCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + SysManualCategory.SelectFieldList + @"
FROM [dbo].[SysManualCategory] 
WHERE 
	[SysManualCategory].[ID] = @ID " + SysManualCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<SysManualCategory>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection SysManualCategory objects.
		/// </summary>
		/// <returns>The retrieved collection of SysManualCategory objects.</returns>
		public static EntityList<SysManualCategory> GetSysManualCategories()
		{
			string commandText = @"
SELECT " + SysManualCategory.SelectFieldList + "FROM [dbo].[SysManualCategory] " + SysManualCategory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<SysManualCategory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection SysManualCategory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of SysManualCategory objects.</returns>
        public static EntityList<SysManualCategory> GetSysManualCategories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SysManualCategory>(SelectFieldList, "FROM [dbo].[SysManualCategory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection SysManualCategory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of SysManualCategory objects.</returns>
        public static EntityList<SysManualCategory> GetSysManualCategories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SysManualCategory>(SelectFieldList, "FROM [dbo].[SysManualCategory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection SysManualCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of SysManualCategory objects.</returns>
		protected static EntityList<SysManualCategory> GetSysManualCategories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSysManualCategories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection SysManualCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of SysManualCategory objects.</returns>
		protected static EntityList<SysManualCategory> GetSysManualCategories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSysManualCategories(string.Empty, where, parameters, SysManualCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysManualCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of SysManualCategory objects.</returns>
		protected static EntityList<SysManualCategory> GetSysManualCategories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSysManualCategories(prefix, where, parameters, SysManualCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysManualCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of SysManualCategory objects.</returns>
		protected static EntityList<SysManualCategory> GetSysManualCategories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSysManualCategories(string.Empty, where, parameters, SysManualCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysManualCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of SysManualCategory objects.</returns>
		protected static EntityList<SysManualCategory> GetSysManualCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSysManualCategories(prefix, where, parameters, SysManualCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysManualCategory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of SysManualCategory objects.</returns>
		protected static EntityList<SysManualCategory> GetSysManualCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + SysManualCategory.SelectFieldList + "FROM [dbo].[SysManualCategory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<SysManualCategory>(reader);
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
        protected static EntityList<SysManualCategory> GetSysManualCategories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SysManualCategory>(SelectFieldList, "FROM [dbo].[SysManualCategory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of SysManualCategory objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSysManualCategoryCount()
        {
            return GetSysManualCategoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of SysManualCategory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSysManualCategoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[SysManualCategory] " + where;

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
		public static partial class SysManualCategory_Properties
		{
			public const string ID = "ID";
			public const string CategoryName = "CategoryName";
			public const string AddTime = "AddTime";
			public const string SortBy = "SortBy";
			public const string Status = "Status";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CategoryName" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"SortBy" , "int:"},
    			 {"Status" , "int:"},
            };
		}
		#endregion
	}
}
