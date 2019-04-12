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
	/// This object represents the properties and methods of a CKCategory.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CKCategory 
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
		private string _categoryDesc = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CategoryDesc
		{
			[DebuggerStepThrough()]
			get { return this._categoryDesc; }
			set 
			{
				if (this._categoryDesc != value) 
				{
					this._categoryDesc = value;
					this.IsDirty = true;	
					OnPropertyChanged("CategoryDesc");
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
		private string _addMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddMan
		{
			[DebuggerStepThrough()]
			get { return this._addMan; }
			set 
			{
				if (this._addMan != value) 
				{
					this._addMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _parentID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ParentID
		{
			[DebuggerStepThrough()]
			get { return this._parentID; }
			set 
			{
				if (this._parentID != value) 
				{
					this._parentID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ParentID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _categoryType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CategoryType
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
	[CategoryName] nvarchar(100),
	[CategoryDesc] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ParentID] int,
	[CategoryType] nvarchar(50)
);

INSERT INTO [dbo].[CKCategory] (
	[CKCategory].[CategoryName],
	[CKCategory].[CategoryDesc],
	[CKCategory].[AddTime],
	[CKCategory].[AddMan],
	[CKCategory].[ParentID],
	[CKCategory].[CategoryType]
) 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[CategoryDesc],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ParentID],
	INSERTED.[CategoryType]
into @table
VALUES ( 
	@CategoryName,
	@CategoryDesc,
	@AddTime,
	@AddMan,
	@ParentID,
	@CategoryType 
); 

SELECT 
	[ID],
	[CategoryName],
	[CategoryDesc],
	[AddTime],
	[AddMan],
	[ParentID],
	[CategoryType] 
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
	[CategoryName] nvarchar(100),
	[CategoryDesc] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ParentID] int,
	[CategoryType] nvarchar(50)
);

UPDATE [dbo].[CKCategory] SET 
	[CKCategory].[CategoryName] = @CategoryName,
	[CKCategory].[CategoryDesc] = @CategoryDesc,
	[CKCategory].[AddTime] = @AddTime,
	[CKCategory].[AddMan] = @AddMan,
	[CKCategory].[ParentID] = @ParentID,
	[CKCategory].[CategoryType] = @CategoryType 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[CategoryDesc],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ParentID],
	INSERTED.[CategoryType]
into @table
WHERE 
	[CKCategory].[ID] = @ID

SELECT 
	[ID],
	[CategoryName],
	[CategoryDesc],
	[AddTime],
	[AddMan],
	[ParentID],
	[CategoryType] 
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
DELETE FROM [dbo].[CKCategory]
WHERE 
	[CKCategory].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CKCategory() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCKCategory(this.ID));
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
	[CKCategory].[ID],
	[CKCategory].[CategoryName],
	[CKCategory].[CategoryDesc],
	[CKCategory].[AddTime],
	[CKCategory].[AddMan],
	[CKCategory].[ParentID],
	[CKCategory].[CategoryType]
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
                return "CKCategory";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CKCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="categoryName">categoryName</param>
		/// <param name="categoryDesc">categoryDesc</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="parentID">parentID</param>
		/// <param name="categoryType">categoryType</param>
		public static void InsertCKCategory(string @categoryName, string @categoryDesc, DateTime @addTime, string @addMan, int @parentID, string @categoryType)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCKCategory(@categoryName, @categoryDesc, @addTime, @addMan, @parentID, @categoryType, helper);
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
		/// Insert a CKCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="categoryName">categoryName</param>
		/// <param name="categoryDesc">categoryDesc</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="parentID">parentID</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="helper">helper</param>
		internal static void InsertCKCategory(string @categoryName, string @categoryDesc, DateTime @addTime, string @addMan, int @parentID, string @categoryType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CategoryName] nvarchar(100),
	[CategoryDesc] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ParentID] int,
	[CategoryType] nvarchar(50)
);

INSERT INTO [dbo].[CKCategory] (
	[CKCategory].[CategoryName],
	[CKCategory].[CategoryDesc],
	[CKCategory].[AddTime],
	[CKCategory].[AddMan],
	[CKCategory].[ParentID],
	[CKCategory].[CategoryType]
) 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[CategoryDesc],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ParentID],
	INSERTED.[CategoryType]
into @table
VALUES ( 
	@CategoryName,
	@CategoryDesc,
	@AddTime,
	@AddMan,
	@ParentID,
	@CategoryType 
); 

SELECT 
	[ID],
	[CategoryName],
	[CategoryDesc],
	[AddTime],
	[AddMan],
	[ParentID],
	[CategoryType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CategoryName", EntityBase.GetDatabaseValue(@categoryName)));
			parameters.Add(new SqlParameter("@CategoryDesc", EntityBase.GetDatabaseValue(@categoryDesc)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@CategoryType", EntityBase.GetDatabaseValue(@categoryType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CKCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="categoryDesc">categoryDesc</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="parentID">parentID</param>
		/// <param name="categoryType">categoryType</param>
		public static void UpdateCKCategory(int @iD, string @categoryName, string @categoryDesc, DateTime @addTime, string @addMan, int @parentID, string @categoryType)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCKCategory(@iD, @categoryName, @categoryDesc, @addTime, @addMan, @parentID, @categoryType, helper);
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
		/// Updates a CKCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="categoryDesc">categoryDesc</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="parentID">parentID</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCKCategory(int @iD, string @categoryName, string @categoryDesc, DateTime @addTime, string @addMan, int @parentID, string @categoryType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CategoryName] nvarchar(100),
	[CategoryDesc] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ParentID] int,
	[CategoryType] nvarchar(50)
);

UPDATE [dbo].[CKCategory] SET 
	[CKCategory].[CategoryName] = @CategoryName,
	[CKCategory].[CategoryDesc] = @CategoryDesc,
	[CKCategory].[AddTime] = @AddTime,
	[CKCategory].[AddMan] = @AddMan,
	[CKCategory].[ParentID] = @ParentID,
	[CKCategory].[CategoryType] = @CategoryType 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[CategoryDesc],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ParentID],
	INSERTED.[CategoryType]
into @table
WHERE 
	[CKCategory].[ID] = @ID

SELECT 
	[ID],
	[CategoryName],
	[CategoryDesc],
	[AddTime],
	[AddMan],
	[ParentID],
	[CategoryType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@CategoryName", EntityBase.GetDatabaseValue(@categoryName)));
			parameters.Add(new SqlParameter("@CategoryDesc", EntityBase.GetDatabaseValue(@categoryDesc)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@CategoryType", EntityBase.GetDatabaseValue(@categoryType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CKCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCKCategory(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCKCategory(@iD, helper);
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
		/// Deletes a CKCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCKCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CKCategory]
WHERE 
	[CKCategory].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CKCategory object.
		/// </summary>
		/// <returns>The newly created CKCategory object.</returns>
		public static CKCategory CreateCKCategory()
		{
			return InitializeNew<CKCategory>();
		}
		
		/// <summary>
		/// Retrieve information for a CKCategory by a CKCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CKCategory</returns>
		public static CKCategory GetCKCategory(int @iD)
		{
			string commandText = @"
SELECT 
" + CKCategory.SelectFieldList + @"
FROM [dbo].[CKCategory] 
WHERE 
	[CKCategory].[ID] = @ID " + CKCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKCategory>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CKCategory by a CKCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CKCategory</returns>
		public static CKCategory GetCKCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CKCategory.SelectFieldList + @"
FROM [dbo].[CKCategory] 
WHERE 
	[CKCategory].[ID] = @ID " + CKCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKCategory>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CKCategory objects.
		/// </summary>
		/// <returns>The retrieved collection of CKCategory objects.</returns>
		public static EntityList<CKCategory> GetCKCategories()
		{
			string commandText = @"
SELECT " + CKCategory.SelectFieldList + "FROM [dbo].[CKCategory] " + CKCategory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CKCategory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CKCategory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKCategory objects.</returns>
        public static EntityList<CKCategory> GetCKCategories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKCategory>(SelectFieldList, "FROM [dbo].[CKCategory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CKCategory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKCategory objects.</returns>
        public static EntityList<CKCategory> GetCKCategories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKCategory>(SelectFieldList, "FROM [dbo].[CKCategory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CKCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CKCategory objects.</returns>
		protected static EntityList<CKCategory> GetCKCategories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKCategories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CKCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKCategory objects.</returns>
		protected static EntityList<CKCategory> GetCKCategories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKCategories(string.Empty, where, parameters, CKCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKCategory objects.</returns>
		protected static EntityList<CKCategory> GetCKCategories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKCategories(prefix, where, parameters, CKCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKCategory objects.</returns>
		protected static EntityList<CKCategory> GetCKCategories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKCategories(string.Empty, where, parameters, CKCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKCategory objects.</returns>
		protected static EntityList<CKCategory> GetCKCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKCategories(prefix, where, parameters, CKCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKCategory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CKCategory objects.</returns>
		protected static EntityList<CKCategory> GetCKCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CKCategory.SelectFieldList + "FROM [dbo].[CKCategory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CKCategory>(reader);
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
        protected static EntityList<CKCategory> GetCKCategories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKCategory>(SelectFieldList, "FROM [dbo].[CKCategory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CKCategory objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKCategoryCount()
        {
            return GetCKCategoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CKCategory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKCategoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CKCategory] " + where;

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
		public static partial class CKCategory_Properties
		{
			public const string ID = "ID";
			public const string CategoryName = "CategoryName";
			public const string CategoryDesc = "CategoryDesc";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string ParentID = "ParentID";
			public const string CategoryType = "CategoryType";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CategoryName" , "string:"},
    			 {"CategoryDesc" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"ParentID" , "int:"},
    			 {"CategoryType" , "string:"},
            };
		}
		#endregion
	}
}
