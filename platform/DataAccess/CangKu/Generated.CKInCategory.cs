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
	/// This object represents the properties and methods of a CKInCategory.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CKInCategory 
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
		private string _inCategoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string InCategoryName
		{
			[DebuggerStepThrough()]
			get { return this._inCategoryName; }
			set 
			{
				if (this._inCategoryName != value) 
				{
					this._inCategoryName = value;
					this.IsDirty = true;	
					OnPropertyChanged("InCategoryName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _inCategoryDesc = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string InCategoryDesc
		{
			[DebuggerStepThrough()]
			get { return this._inCategoryDesc; }
			set 
			{
				if (this._inCategoryDesc != value) 
				{
					this._inCategoryDesc = value;
					this.IsDirty = true;	
					OnPropertyChanged("InCategoryDesc");
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _printLineCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PrintLineCount
		{
			[DebuggerStepThrough()]
			get { return this._printLineCount; }
			set 
			{
				if (this._printLineCount != value) 
				{
					this._printLineCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintLineCount");
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
	[InCategoryName] nvarchar(50),
	[InCategoryDesc] ntext,
	[AddTime] datetime,
	[CategoryType] nvarchar(100),
	[IsSystemAdd] bit,
	[PrintLineCount] int
);

INSERT INTO [dbo].[CKInCategory] (
	[CKInCategory].[InCategoryName],
	[CKInCategory].[InCategoryDesc],
	[CKInCategory].[AddTime],
	[CKInCategory].[CategoryType],
	[CKInCategory].[IsSystemAdd],
	[CKInCategory].[PrintLineCount]
) 
output 
	INSERTED.[ID],
	INSERTED.[InCategoryName],
	INSERTED.[InCategoryDesc],
	INSERTED.[AddTime],
	INSERTED.[CategoryType],
	INSERTED.[IsSystemAdd],
	INSERTED.[PrintLineCount]
into @table
VALUES ( 
	@InCategoryName,
	@InCategoryDesc,
	@AddTime,
	@CategoryType,
	@IsSystemAdd,
	@PrintLineCount 
); 

SELECT 
	[ID],
	[InCategoryName],
	[InCategoryDesc],
	[AddTime],
	[CategoryType],
	[IsSystemAdd],
	[PrintLineCount] 
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
	[InCategoryName] nvarchar(50),
	[InCategoryDesc] ntext,
	[AddTime] datetime,
	[CategoryType] nvarchar(100),
	[IsSystemAdd] bit,
	[PrintLineCount] int
);

UPDATE [dbo].[CKInCategory] SET 
	[CKInCategory].[InCategoryName] = @InCategoryName,
	[CKInCategory].[InCategoryDesc] = @InCategoryDesc,
	[CKInCategory].[AddTime] = @AddTime,
	[CKInCategory].[CategoryType] = @CategoryType,
	[CKInCategory].[IsSystemAdd] = @IsSystemAdd,
	[CKInCategory].[PrintLineCount] = @PrintLineCount 
output 
	INSERTED.[ID],
	INSERTED.[InCategoryName],
	INSERTED.[InCategoryDesc],
	INSERTED.[AddTime],
	INSERTED.[CategoryType],
	INSERTED.[IsSystemAdd],
	INSERTED.[PrintLineCount]
into @table
WHERE 
	[CKInCategory].[ID] = @ID

SELECT 
	[ID],
	[InCategoryName],
	[InCategoryDesc],
	[AddTime],
	[CategoryType],
	[IsSystemAdd],
	[PrintLineCount] 
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
DELETE FROM [dbo].[CKInCategory]
WHERE 
	[CKInCategory].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CKInCategory() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCKInCategory(this.ID));
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
	[CKInCategory].[ID],
	[CKInCategory].[InCategoryName],
	[CKInCategory].[InCategoryDesc],
	[CKInCategory].[AddTime],
	[CKInCategory].[CategoryType],
	[CKInCategory].[IsSystemAdd],
	[CKInCategory].[PrintLineCount]
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
                return "CKInCategory";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CKInCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="inCategoryName">inCategoryName</param>
		/// <param name="inCategoryDesc">inCategoryDesc</param>
		/// <param name="addTime">addTime</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="isSystemAdd">isSystemAdd</param>
		/// <param name="printLineCount">printLineCount</param>
		public static void InsertCKInCategory(string @inCategoryName, string @inCategoryDesc, DateTime @addTime, string @categoryType, bool @isSystemAdd, int @printLineCount)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCKInCategory(@inCategoryName, @inCategoryDesc, @addTime, @categoryType, @isSystemAdd, @printLineCount, helper);
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
		/// Insert a CKInCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="inCategoryName">inCategoryName</param>
		/// <param name="inCategoryDesc">inCategoryDesc</param>
		/// <param name="addTime">addTime</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="isSystemAdd">isSystemAdd</param>
		/// <param name="printLineCount">printLineCount</param>
		/// <param name="helper">helper</param>
		internal static void InsertCKInCategory(string @inCategoryName, string @inCategoryDesc, DateTime @addTime, string @categoryType, bool @isSystemAdd, int @printLineCount, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[InCategoryName] nvarchar(50),
	[InCategoryDesc] ntext,
	[AddTime] datetime,
	[CategoryType] nvarchar(100),
	[IsSystemAdd] bit,
	[PrintLineCount] int
);

INSERT INTO [dbo].[CKInCategory] (
	[CKInCategory].[InCategoryName],
	[CKInCategory].[InCategoryDesc],
	[CKInCategory].[AddTime],
	[CKInCategory].[CategoryType],
	[CKInCategory].[IsSystemAdd],
	[CKInCategory].[PrintLineCount]
) 
output 
	INSERTED.[ID],
	INSERTED.[InCategoryName],
	INSERTED.[InCategoryDesc],
	INSERTED.[AddTime],
	INSERTED.[CategoryType],
	INSERTED.[IsSystemAdd],
	INSERTED.[PrintLineCount]
into @table
VALUES ( 
	@InCategoryName,
	@InCategoryDesc,
	@AddTime,
	@CategoryType,
	@IsSystemAdd,
	@PrintLineCount 
); 

SELECT 
	[ID],
	[InCategoryName],
	[InCategoryDesc],
	[AddTime],
	[CategoryType],
	[IsSystemAdd],
	[PrintLineCount] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@InCategoryName", EntityBase.GetDatabaseValue(@inCategoryName)));
			parameters.Add(new SqlParameter("@InCategoryDesc", EntityBase.GetDatabaseValue(@inCategoryDesc)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@CategoryType", EntityBase.GetDatabaseValue(@categoryType)));
			parameters.Add(new SqlParameter("@IsSystemAdd", @isSystemAdd));
			parameters.Add(new SqlParameter("@PrintLineCount", EntityBase.GetDatabaseValue(@printLineCount)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CKInCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="inCategoryName">inCategoryName</param>
		/// <param name="inCategoryDesc">inCategoryDesc</param>
		/// <param name="addTime">addTime</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="isSystemAdd">isSystemAdd</param>
		/// <param name="printLineCount">printLineCount</param>
		public static void UpdateCKInCategory(int @iD, string @inCategoryName, string @inCategoryDesc, DateTime @addTime, string @categoryType, bool @isSystemAdd, int @printLineCount)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCKInCategory(@iD, @inCategoryName, @inCategoryDesc, @addTime, @categoryType, @isSystemAdd, @printLineCount, helper);
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
		/// Updates a CKInCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="inCategoryName">inCategoryName</param>
		/// <param name="inCategoryDesc">inCategoryDesc</param>
		/// <param name="addTime">addTime</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="isSystemAdd">isSystemAdd</param>
		/// <param name="printLineCount">printLineCount</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCKInCategory(int @iD, string @inCategoryName, string @inCategoryDesc, DateTime @addTime, string @categoryType, bool @isSystemAdd, int @printLineCount, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[InCategoryName] nvarchar(50),
	[InCategoryDesc] ntext,
	[AddTime] datetime,
	[CategoryType] nvarchar(100),
	[IsSystemAdd] bit,
	[PrintLineCount] int
);

UPDATE [dbo].[CKInCategory] SET 
	[CKInCategory].[InCategoryName] = @InCategoryName,
	[CKInCategory].[InCategoryDesc] = @InCategoryDesc,
	[CKInCategory].[AddTime] = @AddTime,
	[CKInCategory].[CategoryType] = @CategoryType,
	[CKInCategory].[IsSystemAdd] = @IsSystemAdd,
	[CKInCategory].[PrintLineCount] = @PrintLineCount 
output 
	INSERTED.[ID],
	INSERTED.[InCategoryName],
	INSERTED.[InCategoryDesc],
	INSERTED.[AddTime],
	INSERTED.[CategoryType],
	INSERTED.[IsSystemAdd],
	INSERTED.[PrintLineCount]
into @table
WHERE 
	[CKInCategory].[ID] = @ID

SELECT 
	[ID],
	[InCategoryName],
	[InCategoryDesc],
	[AddTime],
	[CategoryType],
	[IsSystemAdd],
	[PrintLineCount] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@InCategoryName", EntityBase.GetDatabaseValue(@inCategoryName)));
			parameters.Add(new SqlParameter("@InCategoryDesc", EntityBase.GetDatabaseValue(@inCategoryDesc)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@CategoryType", EntityBase.GetDatabaseValue(@categoryType)));
			parameters.Add(new SqlParameter("@IsSystemAdd", @isSystemAdd));
			parameters.Add(new SqlParameter("@PrintLineCount", EntityBase.GetDatabaseValue(@printLineCount)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CKInCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCKInCategory(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCKInCategory(@iD, helper);
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
		/// Deletes a CKInCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCKInCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CKInCategory]
WHERE 
	[CKInCategory].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CKInCategory object.
		/// </summary>
		/// <returns>The newly created CKInCategory object.</returns>
		public static CKInCategory CreateCKInCategory()
		{
			return InitializeNew<CKInCategory>();
		}
		
		/// <summary>
		/// Retrieve information for a CKInCategory by a CKInCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CKInCategory</returns>
		public static CKInCategory GetCKInCategory(int @iD)
		{
			string commandText = @"
SELECT 
" + CKInCategory.SelectFieldList + @"
FROM [dbo].[CKInCategory] 
WHERE 
	[CKInCategory].[ID] = @ID " + CKInCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKInCategory>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CKInCategory by a CKInCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CKInCategory</returns>
		public static CKInCategory GetCKInCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CKInCategory.SelectFieldList + @"
FROM [dbo].[CKInCategory] 
WHERE 
	[CKInCategory].[ID] = @ID " + CKInCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKInCategory>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CKInCategory objects.
		/// </summary>
		/// <returns>The retrieved collection of CKInCategory objects.</returns>
		public static EntityList<CKInCategory> GetCKInCategories()
		{
			string commandText = @"
SELECT " + CKInCategory.SelectFieldList + "FROM [dbo].[CKInCategory] " + CKInCategory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CKInCategory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CKInCategory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKInCategory objects.</returns>
        public static EntityList<CKInCategory> GetCKInCategories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKInCategory>(SelectFieldList, "FROM [dbo].[CKInCategory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CKInCategory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKInCategory objects.</returns>
        public static EntityList<CKInCategory> GetCKInCategories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKInCategory>(SelectFieldList, "FROM [dbo].[CKInCategory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CKInCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CKInCategory objects.</returns>
		protected static EntityList<CKInCategory> GetCKInCategories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKInCategories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CKInCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKInCategory objects.</returns>
		protected static EntityList<CKInCategory> GetCKInCategories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKInCategories(string.Empty, where, parameters, CKInCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKInCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKInCategory objects.</returns>
		protected static EntityList<CKInCategory> GetCKInCategories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKInCategories(prefix, where, parameters, CKInCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKInCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKInCategory objects.</returns>
		protected static EntityList<CKInCategory> GetCKInCategories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKInCategories(string.Empty, where, parameters, CKInCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKInCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKInCategory objects.</returns>
		protected static EntityList<CKInCategory> GetCKInCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKInCategories(prefix, where, parameters, CKInCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKInCategory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CKInCategory objects.</returns>
		protected static EntityList<CKInCategory> GetCKInCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CKInCategory.SelectFieldList + "FROM [dbo].[CKInCategory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CKInCategory>(reader);
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
        protected static EntityList<CKInCategory> GetCKInCategories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKInCategory>(SelectFieldList, "FROM [dbo].[CKInCategory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CKInCategory objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKInCategoryCount()
        {
            return GetCKInCategoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CKInCategory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKInCategoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CKInCategory] " + where;

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
		public static partial class CKInCategory_Properties
		{
			public const string ID = "ID";
			public const string InCategoryName = "InCategoryName";
			public const string InCategoryDesc = "InCategoryDesc";
			public const string AddTime = "AddTime";
			public const string CategoryType = "CategoryType";
			public const string IsSystemAdd = "IsSystemAdd";
			public const string PrintLineCount = "PrintLineCount";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"InCategoryName" , "string:"},
    			 {"InCategoryDesc" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"CategoryType" , "string:"},
    			 {"IsSystemAdd" , "bool:"},
    			 {"PrintLineCount" , "int:"},
            };
		}
		#endregion
	}
}
