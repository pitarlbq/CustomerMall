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
	/// This object represents the properties and methods of a Test_Product.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Test_Product 
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
		private string _title = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string Title
		{
			[DebuggerStepThrough()]
			get { return this._title; }
			set 
			{
				if (this._title != value) 
				{
					this._title = value;
					this.IsDirty = true;	
					OnPropertyChanged("Title");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _summary = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Summary
		{
			[DebuggerStepThrough()]
			get { return this._summary; }
			set 
			{
				if (this._summary != value) 
				{
					this._summary = value;
					this.IsDirty = true;	
					OnPropertyChanged("Summary");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _salPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal SalPrice
		{
			[DebuggerStepThrough()]
			get { return this._salPrice; }
			set 
			{
				if (this._salPrice != value) 
				{
					this._salPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("SalPrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _modelNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ModelNumber
		{
			[DebuggerStepThrough()]
			get { return this._modelNumber; }
			set 
			{
				if (this._modelNumber != value) 
				{
					this._modelNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModelNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _totalCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int TotalCount
		{
			[DebuggerStepThrough()]
			get { return this._totalCount; }
			set 
			{
				if (this._totalCount != value) 
				{
					this._totalCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _categoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int CategoryID
		{
			[DebuggerStepThrough()]
			get { return this._categoryID; }
			set 
			{
				if (this._categoryID != value) 
				{
					this._categoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CategoryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _unit = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Unit
		{
			[DebuggerStepThrough()]
			get { return this._unit; }
			set 
			{
				if (this._unit != value) 
				{
					this._unit = value;
					this.IsDirty = true;	
					OnPropertyChanged("Unit");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _coverImage = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CoverImage
		{
			[DebuggerStepThrough()]
			get { return this._coverImage; }
			set 
			{
				if (this._coverImage != value) 
				{
					this._coverImage = value;
					this.IsDirty = true;	
					OnPropertyChanged("CoverImage");
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
	[Title] nvarchar(100),
	[Summary] nvarchar(500),
	[SalPrice] decimal(18, 2),
	[ModelNumber] nvarchar(50),
	[TotalCount] int,
	[CategoryID] int,
	[Unit] nvarchar(50),
	[CoverImage] nvarchar(500),
	[AddTime] datetime
);

INSERT INTO [dbo].[Test_Product] (
	[Test_Product].[Title],
	[Test_Product].[Summary],
	[Test_Product].[SalPrice],
	[Test_Product].[ModelNumber],
	[Test_Product].[TotalCount],
	[Test_Product].[CategoryID],
	[Test_Product].[Unit],
	[Test_Product].[CoverImage],
	[Test_Product].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[Summary],
	INSERTED.[SalPrice],
	INSERTED.[ModelNumber],
	INSERTED.[TotalCount],
	INSERTED.[CategoryID],
	INSERTED.[Unit],
	INSERTED.[CoverImage],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@Title,
	@Summary,
	@SalPrice,
	@ModelNumber,
	@TotalCount,
	@CategoryID,
	@Unit,
	@CoverImage,
	@AddTime 
); 

SELECT 
	[ID],
	[Title],
	[Summary],
	[SalPrice],
	[ModelNumber],
	[TotalCount],
	[CategoryID],
	[Unit],
	[CoverImage],
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
	[Title] nvarchar(100),
	[Summary] nvarchar(500),
	[SalPrice] decimal(18, 2),
	[ModelNumber] nvarchar(50),
	[TotalCount] int,
	[CategoryID] int,
	[Unit] nvarchar(50),
	[CoverImage] nvarchar(500),
	[AddTime] datetime
);

UPDATE [dbo].[Test_Product] SET 
	[Test_Product].[Title] = @Title,
	[Test_Product].[Summary] = @Summary,
	[Test_Product].[SalPrice] = @SalPrice,
	[Test_Product].[ModelNumber] = @ModelNumber,
	[Test_Product].[TotalCount] = @TotalCount,
	[Test_Product].[CategoryID] = @CategoryID,
	[Test_Product].[Unit] = @Unit,
	[Test_Product].[CoverImage] = @CoverImage,
	[Test_Product].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[Summary],
	INSERTED.[SalPrice],
	INSERTED.[ModelNumber],
	INSERTED.[TotalCount],
	INSERTED.[CategoryID],
	INSERTED.[Unit],
	INSERTED.[CoverImage],
	INSERTED.[AddTime]
into @table
WHERE 
	[Test_Product].[ID] = @ID

SELECT 
	[ID],
	[Title],
	[Summary],
	[SalPrice],
	[ModelNumber],
	[TotalCount],
	[CategoryID],
	[Unit],
	[CoverImage],
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
DELETE FROM [dbo].[Test_Product]
WHERE 
	[Test_Product].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Test_Product() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetTest_Product(this.ID));
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
	[Test_Product].[ID],
	[Test_Product].[Title],
	[Test_Product].[Summary],
	[Test_Product].[SalPrice],
	[Test_Product].[ModelNumber],
	[Test_Product].[TotalCount],
	[Test_Product].[CategoryID],
	[Test_Product].[Unit],
	[Test_Product].[CoverImage],
	[Test_Product].[AddTime]
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
                return "Test_Product";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Test_Product into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="title">title</param>
		/// <param name="summary">summary</param>
		/// <param name="salPrice">salPrice</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="unit">unit</param>
		/// <param name="coverImage">coverImage</param>
		/// <param name="addTime">addTime</param>
		public static void InsertTest_Product(string @title, string @summary, decimal @salPrice, string @modelNumber, int @totalCount, int @categoryID, string @unit, string @coverImage, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertTest_Product(@title, @summary, @salPrice, @modelNumber, @totalCount, @categoryID, @unit, @coverImage, @addTime, helper);
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
		/// Insert a Test_Product into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="title">title</param>
		/// <param name="summary">summary</param>
		/// <param name="salPrice">salPrice</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="unit">unit</param>
		/// <param name="coverImage">coverImage</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertTest_Product(string @title, string @summary, decimal @salPrice, string @modelNumber, int @totalCount, int @categoryID, string @unit, string @coverImage, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Title] nvarchar(100),
	[Summary] nvarchar(500),
	[SalPrice] decimal(18, 2),
	[ModelNumber] nvarchar(50),
	[TotalCount] int,
	[CategoryID] int,
	[Unit] nvarchar(50),
	[CoverImage] nvarchar(500),
	[AddTime] datetime
);

INSERT INTO [dbo].[Test_Product] (
	[Test_Product].[Title],
	[Test_Product].[Summary],
	[Test_Product].[SalPrice],
	[Test_Product].[ModelNumber],
	[Test_Product].[TotalCount],
	[Test_Product].[CategoryID],
	[Test_Product].[Unit],
	[Test_Product].[CoverImage],
	[Test_Product].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[Summary],
	INSERTED.[SalPrice],
	INSERTED.[ModelNumber],
	INSERTED.[TotalCount],
	INSERTED.[CategoryID],
	INSERTED.[Unit],
	INSERTED.[CoverImage],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@Title,
	@Summary,
	@SalPrice,
	@ModelNumber,
	@TotalCount,
	@CategoryID,
	@Unit,
	@CoverImage,
	@AddTime 
); 

SELECT 
	[ID],
	[Title],
	[Summary],
	[SalPrice],
	[ModelNumber],
	[TotalCount],
	[CategoryID],
	[Unit],
	[CoverImage],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@Summary", EntityBase.GetDatabaseValue(@summary)));
			parameters.Add(new SqlParameter("@SalPrice", EntityBase.GetDatabaseValue(@salPrice)));
			parameters.Add(new SqlParameter("@ModelNumber", EntityBase.GetDatabaseValue(@modelNumber)));
			parameters.Add(new SqlParameter("@TotalCount", EntityBase.GetDatabaseValue(@totalCount)));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			parameters.Add(new SqlParameter("@Unit", EntityBase.GetDatabaseValue(@unit)));
			parameters.Add(new SqlParameter("@CoverImage", EntityBase.GetDatabaseValue(@coverImage)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Test_Product into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="title">title</param>
		/// <param name="summary">summary</param>
		/// <param name="salPrice">salPrice</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="unit">unit</param>
		/// <param name="coverImage">coverImage</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateTest_Product(int @iD, string @title, string @summary, decimal @salPrice, string @modelNumber, int @totalCount, int @categoryID, string @unit, string @coverImage, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateTest_Product(@iD, @title, @summary, @salPrice, @modelNumber, @totalCount, @categoryID, @unit, @coverImage, @addTime, helper);
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
		/// Updates a Test_Product into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="title">title</param>
		/// <param name="summary">summary</param>
		/// <param name="salPrice">salPrice</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="unit">unit</param>
		/// <param name="coverImage">coverImage</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateTest_Product(int @iD, string @title, string @summary, decimal @salPrice, string @modelNumber, int @totalCount, int @categoryID, string @unit, string @coverImage, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Title] nvarchar(100),
	[Summary] nvarchar(500),
	[SalPrice] decimal(18, 2),
	[ModelNumber] nvarchar(50),
	[TotalCount] int,
	[CategoryID] int,
	[Unit] nvarchar(50),
	[CoverImage] nvarchar(500),
	[AddTime] datetime
);

UPDATE [dbo].[Test_Product] SET 
	[Test_Product].[Title] = @Title,
	[Test_Product].[Summary] = @Summary,
	[Test_Product].[SalPrice] = @SalPrice,
	[Test_Product].[ModelNumber] = @ModelNumber,
	[Test_Product].[TotalCount] = @TotalCount,
	[Test_Product].[CategoryID] = @CategoryID,
	[Test_Product].[Unit] = @Unit,
	[Test_Product].[CoverImage] = @CoverImage,
	[Test_Product].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[Summary],
	INSERTED.[SalPrice],
	INSERTED.[ModelNumber],
	INSERTED.[TotalCount],
	INSERTED.[CategoryID],
	INSERTED.[Unit],
	INSERTED.[CoverImage],
	INSERTED.[AddTime]
into @table
WHERE 
	[Test_Product].[ID] = @ID

SELECT 
	[ID],
	[Title],
	[Summary],
	[SalPrice],
	[ModelNumber],
	[TotalCount],
	[CategoryID],
	[Unit],
	[CoverImage],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@Summary", EntityBase.GetDatabaseValue(@summary)));
			parameters.Add(new SqlParameter("@SalPrice", EntityBase.GetDatabaseValue(@salPrice)));
			parameters.Add(new SqlParameter("@ModelNumber", EntityBase.GetDatabaseValue(@modelNumber)));
			parameters.Add(new SqlParameter("@TotalCount", EntityBase.GetDatabaseValue(@totalCount)));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			parameters.Add(new SqlParameter("@Unit", EntityBase.GetDatabaseValue(@unit)));
			parameters.Add(new SqlParameter("@CoverImage", EntityBase.GetDatabaseValue(@coverImage)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Test_Product from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteTest_Product(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteTest_Product(@iD, helper);
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
		/// Deletes a Test_Product from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteTest_Product(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Test_Product]
WHERE 
	[Test_Product].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Test_Product object.
		/// </summary>
		/// <returns>The newly created Test_Product object.</returns>
		public static Test_Product CreateTest_Product()
		{
			return InitializeNew<Test_Product>();
		}
		
		/// <summary>
		/// Retrieve information for a Test_Product by a Test_Product's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Test_Product</returns>
		public static Test_Product GetTest_Product(int @iD)
		{
			string commandText = @"
SELECT 
" + Test_Product.SelectFieldList + @"
FROM [dbo].[Test_Product] 
WHERE 
	[Test_Product].[ID] = @ID " + Test_Product.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Test_Product>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Test_Product by a Test_Product's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Test_Product</returns>
		public static Test_Product GetTest_Product(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Test_Product.SelectFieldList + @"
FROM [dbo].[Test_Product] 
WHERE 
	[Test_Product].[ID] = @ID " + Test_Product.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Test_Product>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Test_Product objects.
		/// </summary>
		/// <returns>The retrieved collection of Test_Product objects.</returns>
		public static EntityList<Test_Product> GetTest_Products()
		{
			string commandText = @"
SELECT " + Test_Product.SelectFieldList + "FROM [dbo].[Test_Product] " + Test_Product.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Test_Product>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Test_Product objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Test_Product objects.</returns>
        public static EntityList<Test_Product> GetTest_Products(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Test_Product>(SelectFieldList, "FROM [dbo].[Test_Product]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Test_Product objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Test_Product objects.</returns>
        public static EntityList<Test_Product> GetTest_Products(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Test_Product>(SelectFieldList, "FROM [dbo].[Test_Product]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Test_Product objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Test_Product objects.</returns>
		protected static EntityList<Test_Product> GetTest_Products(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetTest_Products(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Test_Product objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Test_Product objects.</returns>
		protected static EntityList<Test_Product> GetTest_Products(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetTest_Products(string.Empty, where, parameters, Test_Product.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Test_Product objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Test_Product objects.</returns>
		protected static EntityList<Test_Product> GetTest_Products(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetTest_Products(prefix, where, parameters, Test_Product.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Test_Product objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Test_Product objects.</returns>
		protected static EntityList<Test_Product> GetTest_Products(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetTest_Products(string.Empty, where, parameters, Test_Product.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Test_Product objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Test_Product objects.</returns>
		protected static EntityList<Test_Product> GetTest_Products(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetTest_Products(prefix, where, parameters, Test_Product.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Test_Product objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Test_Product objects.</returns>
		protected static EntityList<Test_Product> GetTest_Products(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Test_Product.SelectFieldList + "FROM [dbo].[Test_Product] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Test_Product>(reader);
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
        protected static EntityList<Test_Product> GetTest_Products(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Test_Product>(SelectFieldList, "FROM [dbo].[Test_Product] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Test_Product objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetTest_ProductCount()
        {
            return GetTest_ProductCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Test_Product objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetTest_ProductCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Test_Product] " + where;

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
		public static partial class Test_Product_Properties
		{
			public const string ID = "ID";
			public const string Title = "Title";
			public const string Summary = "Summary";
			public const string SalPrice = "SalPrice";
			public const string ModelNumber = "ModelNumber";
			public const string TotalCount = "TotalCount";
			public const string CategoryID = "CategoryID";
			public const string Unit = "Unit";
			public const string CoverImage = "CoverImage";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Title" , "string:"},
    			 {"Summary" , "string:"},
    			 {"SalPrice" , "decimal:"},
    			 {"ModelNumber" , "string:"},
    			 {"TotalCount" , "int:"},
    			 {"CategoryID" , "int:"},
    			 {"Unit" , "string:"},
    			 {"CoverImage" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
