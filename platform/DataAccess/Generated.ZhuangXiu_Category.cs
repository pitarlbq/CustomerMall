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
	/// This object represents the properties and methods of a ZhuangXiu_Category.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ZhuangXiu_Category 
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
	[CategoryName] nvarchar(200),
	[AddTime] datetime
);

INSERT INTO [dbo].[ZhuangXiu_Category] (
	[ZhuangXiu_Category].[CategoryName],
	[ZhuangXiu_Category].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@CategoryName,
	@AddTime 
); 

SELECT 
	[ID],
	[CategoryName],
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
	[CategoryName] nvarchar(200),
	[AddTime] datetime
);

UPDATE [dbo].[ZhuangXiu_Category] SET 
	[ZhuangXiu_Category].[CategoryName] = @CategoryName,
	[ZhuangXiu_Category].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[AddTime]
into @table
WHERE 
	[ZhuangXiu_Category].[ID] = @ID

SELECT 
	[ID],
	[CategoryName],
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
DELETE FROM [dbo].[ZhuangXiu_Category]
WHERE 
	[ZhuangXiu_Category].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ZhuangXiu_Category() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetZhuangXiu_Category(this.ID));
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
	[ZhuangXiu_Category].[ID],
	[ZhuangXiu_Category].[CategoryName],
	[ZhuangXiu_Category].[AddTime]
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
                return "ZhuangXiu_Category";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ZhuangXiu_Category into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="categoryName">categoryName</param>
		/// <param name="addTime">addTime</param>
		public static void InsertZhuangXiu_Category(string @categoryName, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertZhuangXiu_Category(@categoryName, @addTime, helper);
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
		/// Insert a ZhuangXiu_Category into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="categoryName">categoryName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertZhuangXiu_Category(string @categoryName, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CategoryName] nvarchar(200),
	[AddTime] datetime
);

INSERT INTO [dbo].[ZhuangXiu_Category] (
	[ZhuangXiu_Category].[CategoryName],
	[ZhuangXiu_Category].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@CategoryName,
	@AddTime 
); 

SELECT 
	[ID],
	[CategoryName],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CategoryName", EntityBase.GetDatabaseValue(@categoryName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ZhuangXiu_Category into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateZhuangXiu_Category(int @iD, string @categoryName, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateZhuangXiu_Category(@iD, @categoryName, @addTime, helper);
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
		/// Updates a ZhuangXiu_Category into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateZhuangXiu_Category(int @iD, string @categoryName, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CategoryName] nvarchar(200),
	[AddTime] datetime
);

UPDATE [dbo].[ZhuangXiu_Category] SET 
	[ZhuangXiu_Category].[CategoryName] = @CategoryName,
	[ZhuangXiu_Category].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[AddTime]
into @table
WHERE 
	[ZhuangXiu_Category].[ID] = @ID

SELECT 
	[ID],
	[CategoryName],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@CategoryName", EntityBase.GetDatabaseValue(@categoryName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ZhuangXiu_Category from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteZhuangXiu_Category(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteZhuangXiu_Category(@iD, helper);
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
		/// Deletes a ZhuangXiu_Category from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteZhuangXiu_Category(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ZhuangXiu_Category]
WHERE 
	[ZhuangXiu_Category].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ZhuangXiu_Category object.
		/// </summary>
		/// <returns>The newly created ZhuangXiu_Category object.</returns>
		public static ZhuangXiu_Category CreateZhuangXiu_Category()
		{
			return InitializeNew<ZhuangXiu_Category>();
		}
		
		/// <summary>
		/// Retrieve information for a ZhuangXiu_Category by a ZhuangXiu_Category's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ZhuangXiu_Category</returns>
		public static ZhuangXiu_Category GetZhuangXiu_Category(int @iD)
		{
			string commandText = @"
SELECT 
" + ZhuangXiu_Category.SelectFieldList + @"
FROM [dbo].[ZhuangXiu_Category] 
WHERE 
	[ZhuangXiu_Category].[ID] = @ID " + ZhuangXiu_Category.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ZhuangXiu_Category>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ZhuangXiu_Category by a ZhuangXiu_Category's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ZhuangXiu_Category</returns>
		public static ZhuangXiu_Category GetZhuangXiu_Category(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ZhuangXiu_Category.SelectFieldList + @"
FROM [dbo].[ZhuangXiu_Category] 
WHERE 
	[ZhuangXiu_Category].[ID] = @ID " + ZhuangXiu_Category.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ZhuangXiu_Category>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Category objects.
		/// </summary>
		/// <returns>The retrieved collection of ZhuangXiu_Category objects.</returns>
		public static EntityList<ZhuangXiu_Category> GetZhuangXiu_Categories()
		{
			string commandText = @"
SELECT " + ZhuangXiu_Category.SelectFieldList + "FROM [dbo].[ZhuangXiu_Category] " + ZhuangXiu_Category.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ZhuangXiu_Category>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ZhuangXiu_Category objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ZhuangXiu_Category objects.</returns>
        public static EntityList<ZhuangXiu_Category> GetZhuangXiu_Categories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ZhuangXiu_Category>(SelectFieldList, "FROM [dbo].[ZhuangXiu_Category]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ZhuangXiu_Category objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ZhuangXiu_Category objects.</returns>
        public static EntityList<ZhuangXiu_Category> GetZhuangXiu_Categories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ZhuangXiu_Category>(SelectFieldList, "FROM [dbo].[ZhuangXiu_Category]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Category objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ZhuangXiu_Category objects.</returns>
		protected static EntityList<ZhuangXiu_Category> GetZhuangXiu_Categories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetZhuangXiu_Categories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Category objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu_Category objects.</returns>
		protected static EntityList<ZhuangXiu_Category> GetZhuangXiu_Categories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetZhuangXiu_Categories(string.Empty, where, parameters, ZhuangXiu_Category.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Category objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu_Category objects.</returns>
		protected static EntityList<ZhuangXiu_Category> GetZhuangXiu_Categories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetZhuangXiu_Categories(prefix, where, parameters, ZhuangXiu_Category.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Category objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu_Category objects.</returns>
		protected static EntityList<ZhuangXiu_Category> GetZhuangXiu_Categories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetZhuangXiu_Categories(string.Empty, where, parameters, ZhuangXiu_Category.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Category objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu_Category objects.</returns>
		protected static EntityList<ZhuangXiu_Category> GetZhuangXiu_Categories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetZhuangXiu_Categories(prefix, where, parameters, ZhuangXiu_Category.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Category objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ZhuangXiu_Category objects.</returns>
		protected static EntityList<ZhuangXiu_Category> GetZhuangXiu_Categories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ZhuangXiu_Category.SelectFieldList + "FROM [dbo].[ZhuangXiu_Category] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ZhuangXiu_Category>(reader);
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
        protected static EntityList<ZhuangXiu_Category> GetZhuangXiu_Categories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ZhuangXiu_Category>(SelectFieldList, "FROM [dbo].[ZhuangXiu_Category] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ZhuangXiu_Category objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetZhuangXiu_CategoryCount()
        {
            return GetZhuangXiu_CategoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ZhuangXiu_Category objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetZhuangXiu_CategoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ZhuangXiu_Category] " + where;

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
		public static partial class ZhuangXiu_Category_Properties
		{
			public const string ID = "ID";
			public const string CategoryName = "CategoryName";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CategoryName" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
