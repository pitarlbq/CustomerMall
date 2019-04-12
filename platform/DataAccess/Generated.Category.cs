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
	/// This object represents the properties and methods of a Category.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Category 
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
		private string _name = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string Name
		{
			[DebuggerStepThrough()]
			get { return this._name; }
			set 
			{
				if (this._name != value) 
				{
					this._name = value;
					this.IsDirty = true;	
					OnPropertyChanged("Name");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _remark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Remark
		{
			[DebuggerStepThrough()]
			get { return this._remark; }
			set 
			{
				if (this._remark != value) 
				{
					this._remark = value;
					this.IsDirty = true;	
					OnPropertyChanged("Remark");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _sortOrder = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SortOrder
		{
			[DebuggerStepThrough()]
			get { return this._sortOrder; }
			set 
			{
				if (this._sortOrder != value) 
				{
					this._sortOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("SortOrder");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isSystemAdd = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsSystemAdd
		{
			[DebuggerStepThrough()]
			get { return this._isSystemAdd; }
			set 
			{
				if (this._isSystemAdd != value) 
				{
					this._isSystemAdd = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsSystemAdd");
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
	[Name] nvarchar(100),
	[Remark] ntext,
	[SortOrder] int,
	[IsSystemAdd] bit
);

INSERT INTO [dbo].[Category] (
	[Category].[Name],
	[Category].[Remark],
	[Category].[SortOrder],
	[Category].[IsSystemAdd]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Remark],
	INSERTED.[SortOrder],
	INSERTED.[IsSystemAdd]
into @table
VALUES ( 
	@Name,
	@Remark,
	@SortOrder,
	@IsSystemAdd 
); 

SELECT 
	[ID],
	[Name],
	[Remark],
	[SortOrder],
	[IsSystemAdd] 
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
	[Name] nvarchar(100),
	[Remark] ntext,
	[SortOrder] int,
	[IsSystemAdd] bit
);

UPDATE [dbo].[Category] SET 
	[Category].[Name] = @Name,
	[Category].[Remark] = @Remark,
	[Category].[SortOrder] = @SortOrder,
	[Category].[IsSystemAdd] = @IsSystemAdd 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Remark],
	INSERTED.[SortOrder],
	INSERTED.[IsSystemAdd]
into @table
WHERE 
	[Category].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[Remark],
	[SortOrder],
	[IsSystemAdd] 
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
DELETE FROM [dbo].[Category]
WHERE 
	[Category].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Category() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCategory(this.ID));
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
	[Category].[ID],
	[Category].[Name],
	[Category].[Remark],
	[Category].[SortOrder],
	[Category].[IsSystemAdd]
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
                return "Category";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Category into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="remark">remark</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isSystemAdd">isSystemAdd</param>
		public static void InsertCategory(string @name, string @remark, int @sortOrder, bool @isSystemAdd)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCategory(@name, @remark, @sortOrder, @isSystemAdd, helper);
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
		/// Insert a Category into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="remark">remark</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isSystemAdd">isSystemAdd</param>
		/// <param name="helper">helper</param>
		internal static void InsertCategory(string @name, string @remark, int @sortOrder, bool @isSystemAdd, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(100),
	[Remark] ntext,
	[SortOrder] int,
	[IsSystemAdd] bit
);

INSERT INTO [dbo].[Category] (
	[Category].[Name],
	[Category].[Remark],
	[Category].[SortOrder],
	[Category].[IsSystemAdd]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Remark],
	INSERTED.[SortOrder],
	INSERTED.[IsSystemAdd]
into @table
VALUES ( 
	@Name,
	@Remark,
	@SortOrder,
	@IsSystemAdd 
); 

SELECT 
	[ID],
	[Name],
	[Remark],
	[SortOrder],
	[IsSystemAdd] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsSystemAdd", @isSystemAdd));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Category into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="remark">remark</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isSystemAdd">isSystemAdd</param>
		public static void UpdateCategory(int @iD, string @name, string @remark, int @sortOrder, bool @isSystemAdd)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCategory(@iD, @name, @remark, @sortOrder, @isSystemAdd, helper);
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
		/// Updates a Category into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="remark">remark</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isSystemAdd">isSystemAdd</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCategory(int @iD, string @name, string @remark, int @sortOrder, bool @isSystemAdd, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(100),
	[Remark] ntext,
	[SortOrder] int,
	[IsSystemAdd] bit
);

UPDATE [dbo].[Category] SET 
	[Category].[Name] = @Name,
	[Category].[Remark] = @Remark,
	[Category].[SortOrder] = @SortOrder,
	[Category].[IsSystemAdd] = @IsSystemAdd 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Remark],
	INSERTED.[SortOrder],
	INSERTED.[IsSystemAdd]
into @table
WHERE 
	[Category].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[Remark],
	[SortOrder],
	[IsSystemAdd] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsSystemAdd", @isSystemAdd));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Category from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCategory(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCategory(@iD, helper);
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
		/// Deletes a Category from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Category]
WHERE 
	[Category].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Category object.
		/// </summary>
		/// <returns>The newly created Category object.</returns>
		public static Category CreateCategory()
		{
			return InitializeNew<Category>();
		}
		
		/// <summary>
		/// Retrieve information for a Category by a Category's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Category</returns>
		public static Category GetCategory(int @iD)
		{
			string commandText = @"
SELECT 
" + Category.SelectFieldList + @"
FROM [dbo].[Category] 
WHERE 
	[Category].[ID] = @ID " + Category.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Category>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Category by a Category's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Category</returns>
		public static Category GetCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Category.SelectFieldList + @"
FROM [dbo].[Category] 
WHERE 
	[Category].[ID] = @ID " + Category.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Category>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Category objects.
		/// </summary>
		/// <returns>The retrieved collection of Category objects.</returns>
		public static EntityList<Category> GetCategories()
		{
			string commandText = @"
SELECT " + Category.SelectFieldList + "FROM [dbo].[Category] " + Category.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Category>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Category objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Category objects.</returns>
        public static EntityList<Category> GetCategories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Category>(SelectFieldList, "FROM [dbo].[Category]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Category objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Category objects.</returns>
        public static EntityList<Category> GetCategories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Category>(SelectFieldList, "FROM [dbo].[Category]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Category objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Category objects.</returns>
		protected static EntityList<Category> GetCategories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCategories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Category objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Category objects.</returns>
		protected static EntityList<Category> GetCategories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCategories(string.Empty, where, parameters, Category.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Category objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Category objects.</returns>
		protected static EntityList<Category> GetCategories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCategories(prefix, where, parameters, Category.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Category objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Category objects.</returns>
		protected static EntityList<Category> GetCategories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCategories(string.Empty, where, parameters, Category.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Category objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Category objects.</returns>
		protected static EntityList<Category> GetCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCategories(prefix, where, parameters, Category.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Category objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Category objects.</returns>
		protected static EntityList<Category> GetCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Category.SelectFieldList + "FROM [dbo].[Category] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Category>(reader);
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
        protected static EntityList<Category> GetCategories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Category>(SelectFieldList, "FROM [dbo].[Category] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Category objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCategoryCount()
        {
            return GetCategoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Category objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCategoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Category] " + where;

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
		public static partial class Category_Properties
		{
			public const string ID = "ID";
			public const string Name = "Name";
			public const string Remark = "Remark";
			public const string SortOrder = "SortOrder";
			public const string IsSystemAdd = "IsSystemAdd";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Name" , "string:"},
    			 {"Remark" , "string:"},
    			 {"SortOrder" , "int:"},
    			 {"IsSystemAdd" , "bool:"},
            };
		}
		#endregion
	}
}
