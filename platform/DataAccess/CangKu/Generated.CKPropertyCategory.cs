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
	/// This object represents the properties and methods of a CKPropertyCategory.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CKPropertyCategory 
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
		private string _propertyCategoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PropertyCategoryName
		{
			[DebuggerStepThrough()]
			get { return this._propertyCategoryName; }
			set 
			{
				if (this._propertyCategoryName != value) 
				{
					this._propertyCategoryName = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyCategoryName");
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
		private string _addUser = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddUser
		{
			[DebuggerStepThrough()]
			get { return this._addUser; }
			set 
			{
				if (this._addUser != value) 
				{
					this._addUser = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUser");
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
	[PropertyCategoryName] nvarchar(100),
	[AddTime] datetime,
	[AddUser] nvarchar(50)
);

INSERT INTO [dbo].[CKPropertyCategory] (
	[CKPropertyCategory].[PropertyCategoryName],
	[CKPropertyCategory].[AddTime],
	[CKPropertyCategory].[AddUser]
) 
output 
	INSERTED.[ID],
	INSERTED.[PropertyCategoryName],
	INSERTED.[AddTime],
	INSERTED.[AddUser]
into @table
VALUES ( 
	@PropertyCategoryName,
	@AddTime,
	@AddUser 
); 

SELECT 
	[ID],
	[PropertyCategoryName],
	[AddTime],
	[AddUser] 
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
	[PropertyCategoryName] nvarchar(100),
	[AddTime] datetime,
	[AddUser] nvarchar(50)
);

UPDATE [dbo].[CKPropertyCategory] SET 
	[CKPropertyCategory].[PropertyCategoryName] = @PropertyCategoryName,
	[CKPropertyCategory].[AddTime] = @AddTime,
	[CKPropertyCategory].[AddUser] = @AddUser 
output 
	INSERTED.[ID],
	INSERTED.[PropertyCategoryName],
	INSERTED.[AddTime],
	INSERTED.[AddUser]
into @table
WHERE 
	[CKPropertyCategory].[ID] = @ID

SELECT 
	[ID],
	[PropertyCategoryName],
	[AddTime],
	[AddUser] 
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
DELETE FROM [dbo].[CKPropertyCategory]
WHERE 
	[CKPropertyCategory].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CKPropertyCategory() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCKPropertyCategory(this.ID));
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
	[CKPropertyCategory].[ID],
	[CKPropertyCategory].[PropertyCategoryName],
	[CKPropertyCategory].[AddTime],
	[CKPropertyCategory].[AddUser]
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
                return "CKPropertyCategory";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CKPropertyCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="propertyCategoryName">propertyCategoryName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		public static void InsertCKPropertyCategory(string @propertyCategoryName, DateTime @addTime, string @addUser)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCKPropertyCategory(@propertyCategoryName, @addTime, @addUser, helper);
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
		/// Insert a CKPropertyCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="propertyCategoryName">propertyCategoryName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="helper">helper</param>
		internal static void InsertCKPropertyCategory(string @propertyCategoryName, DateTime @addTime, string @addUser, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[PropertyCategoryName] nvarchar(100),
	[AddTime] datetime,
	[AddUser] nvarchar(50)
);

INSERT INTO [dbo].[CKPropertyCategory] (
	[CKPropertyCategory].[PropertyCategoryName],
	[CKPropertyCategory].[AddTime],
	[CKPropertyCategory].[AddUser]
) 
output 
	INSERTED.[ID],
	INSERTED.[PropertyCategoryName],
	INSERTED.[AddTime],
	INSERTED.[AddUser]
into @table
VALUES ( 
	@PropertyCategoryName,
	@AddTime,
	@AddUser 
); 

SELECT 
	[ID],
	[PropertyCategoryName],
	[AddTime],
	[AddUser] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@PropertyCategoryName", EntityBase.GetDatabaseValue(@propertyCategoryName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUser", EntityBase.GetDatabaseValue(@addUser)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CKPropertyCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="propertyCategoryName">propertyCategoryName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		public static void UpdateCKPropertyCategory(int @iD, string @propertyCategoryName, DateTime @addTime, string @addUser)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCKPropertyCategory(@iD, @propertyCategoryName, @addTime, @addUser, helper);
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
		/// Updates a CKPropertyCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="propertyCategoryName">propertyCategoryName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCKPropertyCategory(int @iD, string @propertyCategoryName, DateTime @addTime, string @addUser, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[PropertyCategoryName] nvarchar(100),
	[AddTime] datetime,
	[AddUser] nvarchar(50)
);

UPDATE [dbo].[CKPropertyCategory] SET 
	[CKPropertyCategory].[PropertyCategoryName] = @PropertyCategoryName,
	[CKPropertyCategory].[AddTime] = @AddTime,
	[CKPropertyCategory].[AddUser] = @AddUser 
output 
	INSERTED.[ID],
	INSERTED.[PropertyCategoryName],
	INSERTED.[AddTime],
	INSERTED.[AddUser]
into @table
WHERE 
	[CKPropertyCategory].[ID] = @ID

SELECT 
	[ID],
	[PropertyCategoryName],
	[AddTime],
	[AddUser] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@PropertyCategoryName", EntityBase.GetDatabaseValue(@propertyCategoryName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUser", EntityBase.GetDatabaseValue(@addUser)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CKPropertyCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCKPropertyCategory(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCKPropertyCategory(@iD, helper);
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
		/// Deletes a CKPropertyCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCKPropertyCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CKPropertyCategory]
WHERE 
	[CKPropertyCategory].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CKPropertyCategory object.
		/// </summary>
		/// <returns>The newly created CKPropertyCategory object.</returns>
		public static CKPropertyCategory CreateCKPropertyCategory()
		{
			return InitializeNew<CKPropertyCategory>();
		}
		
		/// <summary>
		/// Retrieve information for a CKPropertyCategory by a CKPropertyCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CKPropertyCategory</returns>
		public static CKPropertyCategory GetCKPropertyCategory(int @iD)
		{
			string commandText = @"
SELECT 
" + CKPropertyCategory.SelectFieldList + @"
FROM [dbo].[CKPropertyCategory] 
WHERE 
	[CKPropertyCategory].[ID] = @ID " + CKPropertyCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKPropertyCategory>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CKPropertyCategory by a CKPropertyCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CKPropertyCategory</returns>
		public static CKPropertyCategory GetCKPropertyCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CKPropertyCategory.SelectFieldList + @"
FROM [dbo].[CKPropertyCategory] 
WHERE 
	[CKPropertyCategory].[ID] = @ID " + CKPropertyCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKPropertyCategory>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CKPropertyCategory objects.
		/// </summary>
		/// <returns>The retrieved collection of CKPropertyCategory objects.</returns>
		public static EntityList<CKPropertyCategory> GetCKPropertyCategories()
		{
			string commandText = @"
SELECT " + CKPropertyCategory.SelectFieldList + "FROM [dbo].[CKPropertyCategory] " + CKPropertyCategory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CKPropertyCategory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CKPropertyCategory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKPropertyCategory objects.</returns>
        public static EntityList<CKPropertyCategory> GetCKPropertyCategories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKPropertyCategory>(SelectFieldList, "FROM [dbo].[CKPropertyCategory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CKPropertyCategory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKPropertyCategory objects.</returns>
        public static EntityList<CKPropertyCategory> GetCKPropertyCategories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKPropertyCategory>(SelectFieldList, "FROM [dbo].[CKPropertyCategory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CKPropertyCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CKPropertyCategory objects.</returns>
		protected static EntityList<CKPropertyCategory> GetCKPropertyCategories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKPropertyCategories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CKPropertyCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKPropertyCategory objects.</returns>
		protected static EntityList<CKPropertyCategory> GetCKPropertyCategories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKPropertyCategories(string.Empty, where, parameters, CKPropertyCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKPropertyCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKPropertyCategory objects.</returns>
		protected static EntityList<CKPropertyCategory> GetCKPropertyCategories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKPropertyCategories(prefix, where, parameters, CKPropertyCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKPropertyCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKPropertyCategory objects.</returns>
		protected static EntityList<CKPropertyCategory> GetCKPropertyCategories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKPropertyCategories(string.Empty, where, parameters, CKPropertyCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKPropertyCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKPropertyCategory objects.</returns>
		protected static EntityList<CKPropertyCategory> GetCKPropertyCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKPropertyCategories(prefix, where, parameters, CKPropertyCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKPropertyCategory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CKPropertyCategory objects.</returns>
		protected static EntityList<CKPropertyCategory> GetCKPropertyCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CKPropertyCategory.SelectFieldList + "FROM [dbo].[CKPropertyCategory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CKPropertyCategory>(reader);
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
        protected static EntityList<CKPropertyCategory> GetCKPropertyCategories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKPropertyCategory>(SelectFieldList, "FROM [dbo].[CKPropertyCategory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CKPropertyCategory objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKPropertyCategoryCount()
        {
            return GetCKPropertyCategoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CKPropertyCategory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKPropertyCategoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CKPropertyCategory] " + where;

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
		public static partial class CKPropertyCategory_Properties
		{
			public const string ID = "ID";
			public const string PropertyCategoryName = "PropertyCategoryName";
			public const string AddTime = "AddTime";
			public const string AddUser = "AddUser";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"PropertyCategoryName" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUser" , "string:"},
            };
		}
		#endregion
	}
}
