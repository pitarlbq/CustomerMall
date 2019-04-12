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
	/// This object represents the properties and methods of a Wechat_ContactCategory.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_ContactCategory 
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
	[AddTime] datetime,
	[SortOrder] int
);

INSERT INTO [dbo].[Wechat_ContactCategory] (
	[Wechat_ContactCategory].[Name],
	[Wechat_ContactCategory].[AddTime],
	[Wechat_ContactCategory].[SortOrder]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[AddTime],
	INSERTED.[SortOrder]
into @table
VALUES ( 
	@Name,
	@AddTime,
	@SortOrder 
); 

SELECT 
	[ID],
	[Name],
	[AddTime],
	[SortOrder] 
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
	[AddTime] datetime,
	[SortOrder] int
);

UPDATE [dbo].[Wechat_ContactCategory] SET 
	[Wechat_ContactCategory].[Name] = @Name,
	[Wechat_ContactCategory].[AddTime] = @AddTime,
	[Wechat_ContactCategory].[SortOrder] = @SortOrder 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[AddTime],
	INSERTED.[SortOrder]
into @table
WHERE 
	[Wechat_ContactCategory].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[AddTime],
	[SortOrder] 
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
DELETE FROM [dbo].[Wechat_ContactCategory]
WHERE 
	[Wechat_ContactCategory].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_ContactCategory() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_ContactCategory(this.ID));
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
	[Wechat_ContactCategory].[ID],
	[Wechat_ContactCategory].[Name],
	[Wechat_ContactCategory].[AddTime],
	[Wechat_ContactCategory].[SortOrder]
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
                return "Wechat_ContactCategory";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_ContactCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortOrder">sortOrder</param>
		public static void InsertWechat_ContactCategory(string @name, DateTime @addTime, int @sortOrder)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_ContactCategory(@name, @addTime, @sortOrder, helper);
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
		/// Insert a Wechat_ContactCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_ContactCategory(string @name, DateTime @addTime, int @sortOrder, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(100),
	[AddTime] datetime,
	[SortOrder] int
);

INSERT INTO [dbo].[Wechat_ContactCategory] (
	[Wechat_ContactCategory].[Name],
	[Wechat_ContactCategory].[AddTime],
	[Wechat_ContactCategory].[SortOrder]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[AddTime],
	INSERTED.[SortOrder]
into @table
VALUES ( 
	@Name,
	@AddTime,
	@SortOrder 
); 

SELECT 
	[ID],
	[Name],
	[AddTime],
	[SortOrder] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_ContactCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortOrder">sortOrder</param>
		public static void UpdateWechat_ContactCategory(int @iD, string @name, DateTime @addTime, int @sortOrder)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_ContactCategory(@iD, @name, @addTime, @sortOrder, helper);
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
		/// Updates a Wechat_ContactCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_ContactCategory(int @iD, string @name, DateTime @addTime, int @sortOrder, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(100),
	[AddTime] datetime,
	[SortOrder] int
);

UPDATE [dbo].[Wechat_ContactCategory] SET 
	[Wechat_ContactCategory].[Name] = @Name,
	[Wechat_ContactCategory].[AddTime] = @AddTime,
	[Wechat_ContactCategory].[SortOrder] = @SortOrder 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[AddTime],
	INSERTED.[SortOrder]
into @table
WHERE 
	[Wechat_ContactCategory].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[AddTime],
	[SortOrder] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_ContactCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_ContactCategory(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_ContactCategory(@iD, helper);
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
		/// Deletes a Wechat_ContactCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_ContactCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_ContactCategory]
WHERE 
	[Wechat_ContactCategory].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_ContactCategory object.
		/// </summary>
		/// <returns>The newly created Wechat_ContactCategory object.</returns>
		public static Wechat_ContactCategory CreateWechat_ContactCategory()
		{
			return InitializeNew<Wechat_ContactCategory>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_ContactCategory by a Wechat_ContactCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_ContactCategory</returns>
		public static Wechat_ContactCategory GetWechat_ContactCategory(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_ContactCategory.SelectFieldList + @"
FROM [dbo].[Wechat_ContactCategory] 
WHERE 
	[Wechat_ContactCategory].[ID] = @ID " + Wechat_ContactCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_ContactCategory>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_ContactCategory by a Wechat_ContactCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_ContactCategory</returns>
		public static Wechat_ContactCategory GetWechat_ContactCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_ContactCategory.SelectFieldList + @"
FROM [dbo].[Wechat_ContactCategory] 
WHERE 
	[Wechat_ContactCategory].[ID] = @ID " + Wechat_ContactCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_ContactCategory>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ContactCategory objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_ContactCategory objects.</returns>
		public static EntityList<Wechat_ContactCategory> GetWechat_ContactCategories()
		{
			string commandText = @"
SELECT " + Wechat_ContactCategory.SelectFieldList + "FROM [dbo].[Wechat_ContactCategory] " + Wechat_ContactCategory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_ContactCategory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_ContactCategory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_ContactCategory objects.</returns>
        public static EntityList<Wechat_ContactCategory> GetWechat_ContactCategories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_ContactCategory>(SelectFieldList, "FROM [dbo].[Wechat_ContactCategory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_ContactCategory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_ContactCategory objects.</returns>
        public static EntityList<Wechat_ContactCategory> GetWechat_ContactCategories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_ContactCategory>(SelectFieldList, "FROM [dbo].[Wechat_ContactCategory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_ContactCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_ContactCategory objects.</returns>
		protected static EntityList<Wechat_ContactCategory> GetWechat_ContactCategories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_ContactCategories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ContactCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ContactCategory objects.</returns>
		protected static EntityList<Wechat_ContactCategory> GetWechat_ContactCategories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_ContactCategories(string.Empty, where, parameters, Wechat_ContactCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ContactCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ContactCategory objects.</returns>
		protected static EntityList<Wechat_ContactCategory> GetWechat_ContactCategories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_ContactCategories(prefix, where, parameters, Wechat_ContactCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ContactCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ContactCategory objects.</returns>
		protected static EntityList<Wechat_ContactCategory> GetWechat_ContactCategories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_ContactCategories(string.Empty, where, parameters, Wechat_ContactCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ContactCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ContactCategory objects.</returns>
		protected static EntityList<Wechat_ContactCategory> GetWechat_ContactCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_ContactCategories(prefix, where, parameters, Wechat_ContactCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ContactCategory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_ContactCategory objects.</returns>
		protected static EntityList<Wechat_ContactCategory> GetWechat_ContactCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_ContactCategory.SelectFieldList + "FROM [dbo].[Wechat_ContactCategory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_ContactCategory>(reader);
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
        protected static EntityList<Wechat_ContactCategory> GetWechat_ContactCategories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_ContactCategory>(SelectFieldList, "FROM [dbo].[Wechat_ContactCategory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_ContactCategory objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_ContactCategoryCount()
        {
            return GetWechat_ContactCategoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_ContactCategory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_ContactCategoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_ContactCategory] " + where;

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
		public static partial class Wechat_ContactCategory_Properties
		{
			public const string ID = "ID";
			public const string Name = "Name";
			public const string AddTime = "AddTime";
			public const string SortOrder = "SortOrder";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Name" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"SortOrder" , "int:"},
            };
		}
		#endregion
	}
}
