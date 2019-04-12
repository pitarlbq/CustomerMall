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
	/// This object represents the properties and methods of a Mall_CheckCategory.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_CheckCategory 
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
		private int _categoryType = int.MinValue;
		/// <summary>
		/// 1-奖励 2-惩罚
		/// </summary>
        [Description("1-奖励 2-惩罚")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int CategoryType
		{
			[DebuggerStepThrough()]
			get { return this._categoryType; }
			set 
			{
				if (this._categoryType != value) 
				{
					this._categoryType = value;
					this.IsDirty = true;	
					OnPropertyChanged("CategoryType");
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
		[DataObjectField(false, false, false)]
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string AddUserName
		{
			[DebuggerStepThrough()]
			get { return this._addUserName; }
			set 
			{
				if (this._addUserName != value) 
				{
					this._addUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUserName");
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
	[CategoryType] int,
	[CategoryName] nvarchar(200),
	[AddTime] datetime,
	[AddUserName] nvarchar(200)
);

INSERT INTO [dbo].[Mall_CheckCategory] (
	[Mall_CheckCategory].[CategoryType],
	[Mall_CheckCategory].[CategoryName],
	[Mall_CheckCategory].[AddTime],
	[Mall_CheckCategory].[AddUserName]
) 
output 
	INSERTED.[ID],
	INSERTED.[CategoryType],
	INSERTED.[CategoryName],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
VALUES ( 
	@CategoryType,
	@CategoryName,
	@AddTime,
	@AddUserName 
); 

SELECT 
	[ID],
	[CategoryType],
	[CategoryName],
	[AddTime],
	[AddUserName] 
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
	[CategoryType] int,
	[CategoryName] nvarchar(200),
	[AddTime] datetime,
	[AddUserName] nvarchar(200)
);

UPDATE [dbo].[Mall_CheckCategory] SET 
	[Mall_CheckCategory].[CategoryType] = @CategoryType,
	[Mall_CheckCategory].[CategoryName] = @CategoryName,
	[Mall_CheckCategory].[AddTime] = @AddTime,
	[Mall_CheckCategory].[AddUserName] = @AddUserName 
output 
	INSERTED.[ID],
	INSERTED.[CategoryType],
	INSERTED.[CategoryName],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
WHERE 
	[Mall_CheckCategory].[ID] = @ID

SELECT 
	[ID],
	[CategoryType],
	[CategoryName],
	[AddTime],
	[AddUserName] 
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
DELETE FROM [dbo].[Mall_CheckCategory]
WHERE 
	[Mall_CheckCategory].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_CheckCategory() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_CheckCategory(this.ID));
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
	[Mall_CheckCategory].[ID],
	[Mall_CheckCategory].[CategoryType],
	[Mall_CheckCategory].[CategoryName],
	[Mall_CheckCategory].[AddTime],
	[Mall_CheckCategory].[AddUserName]
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
                return "Mall_CheckCategory";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_CheckCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="categoryType">categoryType</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		public static void InsertMall_CheckCategory(int @categoryType, string @categoryName, DateTime @addTime, string @addUserName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_CheckCategory(@categoryType, @categoryName, @addTime, @addUserName, helper);
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
		/// Insert a Mall_CheckCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="categoryType">categoryType</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_CheckCategory(int @categoryType, string @categoryName, DateTime @addTime, string @addUserName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CategoryType] int,
	[CategoryName] nvarchar(200),
	[AddTime] datetime,
	[AddUserName] nvarchar(200)
);

INSERT INTO [dbo].[Mall_CheckCategory] (
	[Mall_CheckCategory].[CategoryType],
	[Mall_CheckCategory].[CategoryName],
	[Mall_CheckCategory].[AddTime],
	[Mall_CheckCategory].[AddUserName]
) 
output 
	INSERTED.[ID],
	INSERTED.[CategoryType],
	INSERTED.[CategoryName],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
VALUES ( 
	@CategoryType,
	@CategoryName,
	@AddTime,
	@AddUserName 
); 

SELECT 
	[ID],
	[CategoryType],
	[CategoryName],
	[AddTime],
	[AddUserName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CategoryType", EntityBase.GetDatabaseValue(@categoryType)));
			parameters.Add(new SqlParameter("@CategoryName", EntityBase.GetDatabaseValue(@categoryName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_CheckCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		public static void UpdateMall_CheckCategory(int @iD, int @categoryType, string @categoryName, DateTime @addTime, string @addUserName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_CheckCategory(@iD, @categoryType, @categoryName, @addTime, @addUserName, helper);
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
		/// Updates a Mall_CheckCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_CheckCategory(int @iD, int @categoryType, string @categoryName, DateTime @addTime, string @addUserName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CategoryType] int,
	[CategoryName] nvarchar(200),
	[AddTime] datetime,
	[AddUserName] nvarchar(200)
);

UPDATE [dbo].[Mall_CheckCategory] SET 
	[Mall_CheckCategory].[CategoryType] = @CategoryType,
	[Mall_CheckCategory].[CategoryName] = @CategoryName,
	[Mall_CheckCategory].[AddTime] = @AddTime,
	[Mall_CheckCategory].[AddUserName] = @AddUserName 
output 
	INSERTED.[ID],
	INSERTED.[CategoryType],
	INSERTED.[CategoryName],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
WHERE 
	[Mall_CheckCategory].[ID] = @ID

SELECT 
	[ID],
	[CategoryType],
	[CategoryName],
	[AddTime],
	[AddUserName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@CategoryType", EntityBase.GetDatabaseValue(@categoryType)));
			parameters.Add(new SqlParameter("@CategoryName", EntityBase.GetDatabaseValue(@categoryName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_CheckCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_CheckCategory(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_CheckCategory(@iD, helper);
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
		/// Deletes a Mall_CheckCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_CheckCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_CheckCategory]
WHERE 
	[Mall_CheckCategory].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_CheckCategory object.
		/// </summary>
		/// <returns>The newly created Mall_CheckCategory object.</returns>
		public static Mall_CheckCategory CreateMall_CheckCategory()
		{
			return InitializeNew<Mall_CheckCategory>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_CheckCategory by a Mall_CheckCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_CheckCategory</returns>
		public static Mall_CheckCategory GetMall_CheckCategory(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_CheckCategory.SelectFieldList + @"
FROM [dbo].[Mall_CheckCategory] 
WHERE 
	[Mall_CheckCategory].[ID] = @ID " + Mall_CheckCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_CheckCategory>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_CheckCategory by a Mall_CheckCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_CheckCategory</returns>
		public static Mall_CheckCategory GetMall_CheckCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_CheckCategory.SelectFieldList + @"
FROM [dbo].[Mall_CheckCategory] 
WHERE 
	[Mall_CheckCategory].[ID] = @ID " + Mall_CheckCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_CheckCategory>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckCategory objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_CheckCategory objects.</returns>
		public static EntityList<Mall_CheckCategory> GetMall_CheckCategories()
		{
			string commandText = @"
SELECT " + Mall_CheckCategory.SelectFieldList + "FROM [dbo].[Mall_CheckCategory] " + Mall_CheckCategory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_CheckCategory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_CheckCategory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_CheckCategory objects.</returns>
        public static EntityList<Mall_CheckCategory> GetMall_CheckCategories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckCategory>(SelectFieldList, "FROM [dbo].[Mall_CheckCategory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_CheckCategory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_CheckCategory objects.</returns>
        public static EntityList<Mall_CheckCategory> GetMall_CheckCategories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckCategory>(SelectFieldList, "FROM [dbo].[Mall_CheckCategory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_CheckCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_CheckCategory objects.</returns>
		protected static EntityList<Mall_CheckCategory> GetMall_CheckCategories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckCategories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckCategory objects.</returns>
		protected static EntityList<Mall_CheckCategory> GetMall_CheckCategories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckCategories(string.Empty, where, parameters, Mall_CheckCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckCategory objects.</returns>
		protected static EntityList<Mall_CheckCategory> GetMall_CheckCategories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckCategories(prefix, where, parameters, Mall_CheckCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckCategory objects.</returns>
		protected static EntityList<Mall_CheckCategory> GetMall_CheckCategories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_CheckCategories(string.Empty, where, parameters, Mall_CheckCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckCategory objects.</returns>
		protected static EntityList<Mall_CheckCategory> GetMall_CheckCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_CheckCategories(prefix, where, parameters, Mall_CheckCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckCategory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_CheckCategory objects.</returns>
		protected static EntityList<Mall_CheckCategory> GetMall_CheckCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_CheckCategory.SelectFieldList + "FROM [dbo].[Mall_CheckCategory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_CheckCategory>(reader);
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
        protected static EntityList<Mall_CheckCategory> GetMall_CheckCategories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckCategory>(SelectFieldList, "FROM [dbo].[Mall_CheckCategory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_CheckCategory objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CheckCategoryCount()
        {
            return GetMall_CheckCategoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_CheckCategory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CheckCategoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_CheckCategory] " + where;

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
		public static partial class Mall_CheckCategory_Properties
		{
			public const string ID = "ID";
			public const string CategoryType = "CategoryType";
			public const string CategoryName = "CategoryName";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CategoryType" , "int:1-奖励 2-惩罚"},
    			 {"CategoryName" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
            };
		}
		#endregion
	}
}
