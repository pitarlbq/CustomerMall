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
	/// This object represents the properties and methods of a Cheque_Product.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_Product 
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
		private string _productName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProductName
		{
			[DebuggerStepThrough()]
			get { return this._productName; }
			set 
			{
				if (this._productName != value) 
				{
					this._productName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductName");
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
		private decimal _unitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal UnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._unitPrice; }
			set 
			{
				if (this._unitPrice != value) 
				{
					this._unitPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("UnitPrice");
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
		private string _productNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProductNumber
		{
			[DebuggerStepThrough()]
			get { return this._productNumber; }
			set 
			{
				if (this._productNumber != value) 
				{
					this._productNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _productCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProductCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._productCategoryID; }
			set 
			{
				if (this._productCategoryID != value) 
				{
					this._productCategoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductCategoryID");
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
	[ProductName] nvarchar(200),
	[ModelNumber] nvarchar(200),
	[Unit] nvarchar(20),
	[UnitPrice] decimal(18, 2),
	[AddTime] datetime,
	[ProductNumber] nvarchar(200),
	[ProductCategoryID] int
);

INSERT INTO [dbo].[Cheque_Product] (
	[Cheque_Product].[ProductName],
	[Cheque_Product].[ModelNumber],
	[Cheque_Product].[Unit],
	[Cheque_Product].[UnitPrice],
	[Cheque_Product].[AddTime],
	[Cheque_Product].[ProductNumber],
	[Cheque_Product].[ProductCategoryID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProductName],
	INSERTED.[ModelNumber],
	INSERTED.[Unit],
	INSERTED.[UnitPrice],
	INSERTED.[AddTime],
	INSERTED.[ProductNumber],
	INSERTED.[ProductCategoryID]
into @table
VALUES ( 
	@ProductName,
	@ModelNumber,
	@Unit,
	@UnitPrice,
	@AddTime,
	@ProductNumber,
	@ProductCategoryID 
); 

SELECT 
	[ID],
	[ProductName],
	[ModelNumber],
	[Unit],
	[UnitPrice],
	[AddTime],
	[ProductNumber],
	[ProductCategoryID] 
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
	[ProductName] nvarchar(200),
	[ModelNumber] nvarchar(200),
	[Unit] nvarchar(20),
	[UnitPrice] decimal(18, 2),
	[AddTime] datetime,
	[ProductNumber] nvarchar(200),
	[ProductCategoryID] int
);

UPDATE [dbo].[Cheque_Product] SET 
	[Cheque_Product].[ProductName] = @ProductName,
	[Cheque_Product].[ModelNumber] = @ModelNumber,
	[Cheque_Product].[Unit] = @Unit,
	[Cheque_Product].[UnitPrice] = @UnitPrice,
	[Cheque_Product].[AddTime] = @AddTime,
	[Cheque_Product].[ProductNumber] = @ProductNumber,
	[Cheque_Product].[ProductCategoryID] = @ProductCategoryID 
output 
	INSERTED.[ID],
	INSERTED.[ProductName],
	INSERTED.[ModelNumber],
	INSERTED.[Unit],
	INSERTED.[UnitPrice],
	INSERTED.[AddTime],
	INSERTED.[ProductNumber],
	INSERTED.[ProductCategoryID]
into @table
WHERE 
	[Cheque_Product].[ID] = @ID

SELECT 
	[ID],
	[ProductName],
	[ModelNumber],
	[Unit],
	[UnitPrice],
	[AddTime],
	[ProductNumber],
	[ProductCategoryID] 
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
DELETE FROM [dbo].[Cheque_Product]
WHERE 
	[Cheque_Product].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_Product() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_Product(this.ID));
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
	[Cheque_Product].[ID],
	[Cheque_Product].[ProductName],
	[Cheque_Product].[ModelNumber],
	[Cheque_Product].[Unit],
	[Cheque_Product].[UnitPrice],
	[Cheque_Product].[AddTime],
	[Cheque_Product].[ProductNumber],
	[Cheque_Product].[ProductCategoryID]
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
                return "Cheque_Product";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_Product into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productName">productName</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="unit">unit</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="addTime">addTime</param>
		/// <param name="productNumber">productNumber</param>
		/// <param name="productCategoryID">productCategoryID</param>
		public static void InsertCheque_Product(string @productName, string @modelNumber, string @unit, decimal @unitPrice, DateTime @addTime, string @productNumber, int @productCategoryID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_Product(@productName, @modelNumber, @unit, @unitPrice, @addTime, @productNumber, @productCategoryID, helper);
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
		/// Insert a Cheque_Product into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productName">productName</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="unit">unit</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="addTime">addTime</param>
		/// <param name="productNumber">productNumber</param>
		/// <param name="productCategoryID">productCategoryID</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_Product(string @productName, string @modelNumber, string @unit, decimal @unitPrice, DateTime @addTime, string @productNumber, int @productCategoryID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProductName] nvarchar(200),
	[ModelNumber] nvarchar(200),
	[Unit] nvarchar(20),
	[UnitPrice] decimal(18, 2),
	[AddTime] datetime,
	[ProductNumber] nvarchar(200),
	[ProductCategoryID] int
);

INSERT INTO [dbo].[Cheque_Product] (
	[Cheque_Product].[ProductName],
	[Cheque_Product].[ModelNumber],
	[Cheque_Product].[Unit],
	[Cheque_Product].[UnitPrice],
	[Cheque_Product].[AddTime],
	[Cheque_Product].[ProductNumber],
	[Cheque_Product].[ProductCategoryID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProductName],
	INSERTED.[ModelNumber],
	INSERTED.[Unit],
	INSERTED.[UnitPrice],
	INSERTED.[AddTime],
	INSERTED.[ProductNumber],
	INSERTED.[ProductCategoryID]
into @table
VALUES ( 
	@ProductName,
	@ModelNumber,
	@Unit,
	@UnitPrice,
	@AddTime,
	@ProductNumber,
	@ProductCategoryID 
); 

SELECT 
	[ID],
	[ProductName],
	[ModelNumber],
	[Unit],
	[UnitPrice],
	[AddTime],
	[ProductNumber],
	[ProductCategoryID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProductName", EntityBase.GetDatabaseValue(@productName)));
			parameters.Add(new SqlParameter("@ModelNumber", EntityBase.GetDatabaseValue(@modelNumber)));
			parameters.Add(new SqlParameter("@Unit", EntityBase.GetDatabaseValue(@unit)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ProductNumber", EntityBase.GetDatabaseValue(@productNumber)));
			parameters.Add(new SqlParameter("@ProductCategoryID", EntityBase.GetDatabaseValue(@productCategoryID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_Product into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="productName">productName</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="unit">unit</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="addTime">addTime</param>
		/// <param name="productNumber">productNumber</param>
		/// <param name="productCategoryID">productCategoryID</param>
		public static void UpdateCheque_Product(int @iD, string @productName, string @modelNumber, string @unit, decimal @unitPrice, DateTime @addTime, string @productNumber, int @productCategoryID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_Product(@iD, @productName, @modelNumber, @unit, @unitPrice, @addTime, @productNumber, @productCategoryID, helper);
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
		/// Updates a Cheque_Product into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="productName">productName</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="unit">unit</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="addTime">addTime</param>
		/// <param name="productNumber">productNumber</param>
		/// <param name="productCategoryID">productCategoryID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_Product(int @iD, string @productName, string @modelNumber, string @unit, decimal @unitPrice, DateTime @addTime, string @productNumber, int @productCategoryID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProductName] nvarchar(200),
	[ModelNumber] nvarchar(200),
	[Unit] nvarchar(20),
	[UnitPrice] decimal(18, 2),
	[AddTime] datetime,
	[ProductNumber] nvarchar(200),
	[ProductCategoryID] int
);

UPDATE [dbo].[Cheque_Product] SET 
	[Cheque_Product].[ProductName] = @ProductName,
	[Cheque_Product].[ModelNumber] = @ModelNumber,
	[Cheque_Product].[Unit] = @Unit,
	[Cheque_Product].[UnitPrice] = @UnitPrice,
	[Cheque_Product].[AddTime] = @AddTime,
	[Cheque_Product].[ProductNumber] = @ProductNumber,
	[Cheque_Product].[ProductCategoryID] = @ProductCategoryID 
output 
	INSERTED.[ID],
	INSERTED.[ProductName],
	INSERTED.[ModelNumber],
	INSERTED.[Unit],
	INSERTED.[UnitPrice],
	INSERTED.[AddTime],
	INSERTED.[ProductNumber],
	INSERTED.[ProductCategoryID]
into @table
WHERE 
	[Cheque_Product].[ID] = @ID

SELECT 
	[ID],
	[ProductName],
	[ModelNumber],
	[Unit],
	[UnitPrice],
	[AddTime],
	[ProductNumber],
	[ProductCategoryID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProductName", EntityBase.GetDatabaseValue(@productName)));
			parameters.Add(new SqlParameter("@ModelNumber", EntityBase.GetDatabaseValue(@modelNumber)));
			parameters.Add(new SqlParameter("@Unit", EntityBase.GetDatabaseValue(@unit)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ProductNumber", EntityBase.GetDatabaseValue(@productNumber)));
			parameters.Add(new SqlParameter("@ProductCategoryID", EntityBase.GetDatabaseValue(@productCategoryID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_Product from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_Product(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_Product(@iD, helper);
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
		/// Deletes a Cheque_Product from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_Product(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_Product]
WHERE 
	[Cheque_Product].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_Product object.
		/// </summary>
		/// <returns>The newly created Cheque_Product object.</returns>
		public static Cheque_Product CreateCheque_Product()
		{
			return InitializeNew<Cheque_Product>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_Product by a Cheque_Product's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_Product</returns>
		public static Cheque_Product GetCheque_Product(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_Product.SelectFieldList + @"
FROM [dbo].[Cheque_Product] 
WHERE 
	[Cheque_Product].[ID] = @ID " + Cheque_Product.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_Product>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_Product by a Cheque_Product's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_Product</returns>
		public static Cheque_Product GetCheque_Product(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_Product.SelectFieldList + @"
FROM [dbo].[Cheque_Product] 
WHERE 
	[Cheque_Product].[ID] = @ID " + Cheque_Product.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_Product>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Product objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_Product objects.</returns>
		public static EntityList<Cheque_Product> GetCheque_Products()
		{
			string commandText = @"
SELECT " + Cheque_Product.SelectFieldList + "FROM [dbo].[Cheque_Product] " + Cheque_Product.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_Product>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_Product objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_Product objects.</returns>
        public static EntityList<Cheque_Product> GetCheque_Products(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Product>(SelectFieldList, "FROM [dbo].[Cheque_Product]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_Product objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_Product objects.</returns>
        public static EntityList<Cheque_Product> GetCheque_Products(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Product>(SelectFieldList, "FROM [dbo].[Cheque_Product]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_Product objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_Product objects.</returns>
		protected static EntityList<Cheque_Product> GetCheque_Products(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Products(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Product objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Product objects.</returns>
		protected static EntityList<Cheque_Product> GetCheque_Products(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Products(string.Empty, where, parameters, Cheque_Product.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Product objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Product objects.</returns>
		protected static EntityList<Cheque_Product> GetCheque_Products(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Products(prefix, where, parameters, Cheque_Product.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Product objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Product objects.</returns>
		protected static EntityList<Cheque_Product> GetCheque_Products(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_Products(string.Empty, where, parameters, Cheque_Product.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Product objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Product objects.</returns>
		protected static EntityList<Cheque_Product> GetCheque_Products(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_Products(prefix, where, parameters, Cheque_Product.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Product objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_Product objects.</returns>
		protected static EntityList<Cheque_Product> GetCheque_Products(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_Product.SelectFieldList + "FROM [dbo].[Cheque_Product] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_Product>(reader);
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
        protected static EntityList<Cheque_Product> GetCheque_Products(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Product>(SelectFieldList, "FROM [dbo].[Cheque_Product] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_Product objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_ProductCount()
        {
            return GetCheque_ProductCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_Product objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_ProductCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_Product] " + where;

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
		public static partial class Cheque_Product_Properties
		{
			public const string ID = "ID";
			public const string ProductName = "ProductName";
			public const string ModelNumber = "ModelNumber";
			public const string Unit = "Unit";
			public const string UnitPrice = "UnitPrice";
			public const string AddTime = "AddTime";
			public const string ProductNumber = "ProductNumber";
			public const string ProductCategoryID = "ProductCategoryID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProductName" , "string:"},
    			 {"ModelNumber" , "string:"},
    			 {"Unit" , "string:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"ProductNumber" , "string:"},
    			 {"ProductCategoryID" , "int:"},
            };
		}
		#endregion
	}
}
