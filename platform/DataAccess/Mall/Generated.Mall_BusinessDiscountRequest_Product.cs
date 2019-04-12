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
	/// This object represents the properties and methods of a Mall_BusinessDiscountRequest_Product.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_BusinessDiscountRequest_Product 
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
		private int _businessDiscountRequestID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int BusinessDiscountRequestID
		{
			[DebuggerStepThrough()]
			get { return this._businessDiscountRequestID; }
			set 
			{
				if (this._businessDiscountRequestID != value) 
				{
					this._businessDiscountRequestID = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessDiscountRequestID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _productID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ProductID
		{
			[DebuggerStepThrough()]
			get { return this._productID; }
			set 
			{
				if (this._productID != value) 
				{
					this._productID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Guid _guid = Guid.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public Guid Guid
		{
			[DebuggerStepThrough()]
			get { return this._guid; }
			set 
			{
				if (this._guid != value) 
				{
					this._guid = value;
					this.IsDirty = true;	
					OnPropertyChanged("Guid");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _quantity = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int Quantity
		{
			[DebuggerStepThrough()]
			get { return this._quantity; }
			set 
			{
				if (this._quantity != value) 
				{
					this._quantity = value;
					this.IsDirty = true;	
					OnPropertyChanged("Quantity");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _price = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal Price
		{
			[DebuggerStepThrough()]
			get { return this._price; }
			set 
			{
				if (this._price != value) 
				{
					this._price = value;
					this.IsDirty = true;	
					OnPropertyChanged("Price");
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _businessID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int BusinessID
		{
			[DebuggerStepThrough()]
			get { return this._businessID; }
			set 
			{
				if (this._businessID != value) 
				{
					this._businessID = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessID");
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
	[BusinessDiscountRequestID] int,
	[ProductID] int,
	[Guid] uniqueidentifier,
	[Quantity] int,
	[Price] decimal(18, 2),
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[BusinessID] int
);

INSERT INTO [dbo].[Mall_BusinessDiscountRequest_Product] (
	[Mall_BusinessDiscountRequest_Product].[BusinessDiscountRequestID],
	[Mall_BusinessDiscountRequest_Product].[ProductID],
	[Mall_BusinessDiscountRequest_Product].[Guid],
	[Mall_BusinessDiscountRequest_Product].[Quantity],
	[Mall_BusinessDiscountRequest_Product].[Price],
	[Mall_BusinessDiscountRequest_Product].[AddTime],
	[Mall_BusinessDiscountRequest_Product].[AddUserName],
	[Mall_BusinessDiscountRequest_Product].[BusinessID]
) 
output 
	INSERTED.[ID],
	INSERTED.[BusinessDiscountRequestID],
	INSERTED.[ProductID],
	INSERTED.[Guid],
	INSERTED.[Quantity],
	INSERTED.[Price],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[BusinessID]
into @table
VALUES ( 
	@BusinessDiscountRequestID,
	@ProductID,
	@Guid,
	@Quantity,
	@Price,
	@AddTime,
	@AddUserName,
	@BusinessID 
); 

SELECT 
	[ID],
	[BusinessDiscountRequestID],
	[ProductID],
	[Guid],
	[Quantity],
	[Price],
	[AddTime],
	[AddUserName],
	[BusinessID] 
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
	[BusinessDiscountRequestID] int,
	[ProductID] int,
	[Guid] uniqueidentifier,
	[Quantity] int,
	[Price] decimal(18, 2),
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[BusinessID] int
);

UPDATE [dbo].[Mall_BusinessDiscountRequest_Product] SET 
	[Mall_BusinessDiscountRequest_Product].[BusinessDiscountRequestID] = @BusinessDiscountRequestID,
	[Mall_BusinessDiscountRequest_Product].[ProductID] = @ProductID,
	[Mall_BusinessDiscountRequest_Product].[Guid] = @Guid,
	[Mall_BusinessDiscountRequest_Product].[Quantity] = @Quantity,
	[Mall_BusinessDiscountRequest_Product].[Price] = @Price,
	[Mall_BusinessDiscountRequest_Product].[AddTime] = @AddTime,
	[Mall_BusinessDiscountRequest_Product].[AddUserName] = @AddUserName,
	[Mall_BusinessDiscountRequest_Product].[BusinessID] = @BusinessID 
output 
	INSERTED.[ID],
	INSERTED.[BusinessDiscountRequestID],
	INSERTED.[ProductID],
	INSERTED.[Guid],
	INSERTED.[Quantity],
	INSERTED.[Price],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[BusinessID]
into @table
WHERE 
	[Mall_BusinessDiscountRequest_Product].[ID] = @ID

SELECT 
	[ID],
	[BusinessDiscountRequestID],
	[ProductID],
	[Guid],
	[Quantity],
	[Price],
	[AddTime],
	[AddUserName],
	[BusinessID] 
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
DELETE FROM [dbo].[Mall_BusinessDiscountRequest_Product]
WHERE 
	[Mall_BusinessDiscountRequest_Product].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_BusinessDiscountRequest_Product() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_BusinessDiscountRequest_Product(this.ID));
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
	[Mall_BusinessDiscountRequest_Product].[ID],
	[Mall_BusinessDiscountRequest_Product].[BusinessDiscountRequestID],
	[Mall_BusinessDiscountRequest_Product].[ProductID],
	[Mall_BusinessDiscountRequest_Product].[Guid],
	[Mall_BusinessDiscountRequest_Product].[Quantity],
	[Mall_BusinessDiscountRequest_Product].[Price],
	[Mall_BusinessDiscountRequest_Product].[AddTime],
	[Mall_BusinessDiscountRequest_Product].[AddUserName],
	[Mall_BusinessDiscountRequest_Product].[BusinessID]
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
                return "Mall_BusinessDiscountRequest_Product";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_BusinessDiscountRequest_Product into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="businessDiscountRequestID">businessDiscountRequestID</param>
		/// <param name="productID">productID</param>
		/// <param name="guid">guid</param>
		/// <param name="quantity">quantity</param>
		/// <param name="price">price</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="businessID">businessID</param>
		public static void InsertMall_BusinessDiscountRequest_Product(int @businessDiscountRequestID, int @productID, Guid @guid, int @quantity, decimal @price, DateTime @addTime, string @addUserName, int @businessID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_BusinessDiscountRequest_Product(@businessDiscountRequestID, @productID, @guid, @quantity, @price, @addTime, @addUserName, @businessID, helper);
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
		/// Insert a Mall_BusinessDiscountRequest_Product into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="businessDiscountRequestID">businessDiscountRequestID</param>
		/// <param name="productID">productID</param>
		/// <param name="guid">guid</param>
		/// <param name="quantity">quantity</param>
		/// <param name="price">price</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="businessID">businessID</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_BusinessDiscountRequest_Product(int @businessDiscountRequestID, int @productID, Guid @guid, int @quantity, decimal @price, DateTime @addTime, string @addUserName, int @businessID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BusinessDiscountRequestID] int,
	[ProductID] int,
	[Guid] uniqueidentifier,
	[Quantity] int,
	[Price] decimal(18, 2),
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[BusinessID] int
);

INSERT INTO [dbo].[Mall_BusinessDiscountRequest_Product] (
	[Mall_BusinessDiscountRequest_Product].[BusinessDiscountRequestID],
	[Mall_BusinessDiscountRequest_Product].[ProductID],
	[Mall_BusinessDiscountRequest_Product].[Guid],
	[Mall_BusinessDiscountRequest_Product].[Quantity],
	[Mall_BusinessDiscountRequest_Product].[Price],
	[Mall_BusinessDiscountRequest_Product].[AddTime],
	[Mall_BusinessDiscountRequest_Product].[AddUserName],
	[Mall_BusinessDiscountRequest_Product].[BusinessID]
) 
output 
	INSERTED.[ID],
	INSERTED.[BusinessDiscountRequestID],
	INSERTED.[ProductID],
	INSERTED.[Guid],
	INSERTED.[Quantity],
	INSERTED.[Price],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[BusinessID]
into @table
VALUES ( 
	@BusinessDiscountRequestID,
	@ProductID,
	@Guid,
	@Quantity,
	@Price,
	@AddTime,
	@AddUserName,
	@BusinessID 
); 

SELECT 
	[ID],
	[BusinessDiscountRequestID],
	[ProductID],
	[Guid],
	[Quantity],
	[Price],
	[AddTime],
	[AddUserName],
	[BusinessID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@BusinessDiscountRequestID", EntityBase.GetDatabaseValue(@businessDiscountRequestID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@Guid", EntityBase.GetDatabaseValue(@guid)));
			parameters.Add(new SqlParameter("@Quantity", EntityBase.GetDatabaseValue(@quantity)));
			parameters.Add(new SqlParameter("@Price", EntityBase.GetDatabaseValue(@price)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_BusinessDiscountRequest_Product into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="businessDiscountRequestID">businessDiscountRequestID</param>
		/// <param name="productID">productID</param>
		/// <param name="guid">guid</param>
		/// <param name="quantity">quantity</param>
		/// <param name="price">price</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="businessID">businessID</param>
		public static void UpdateMall_BusinessDiscountRequest_Product(int @iD, int @businessDiscountRequestID, int @productID, Guid @guid, int @quantity, decimal @price, DateTime @addTime, string @addUserName, int @businessID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_BusinessDiscountRequest_Product(@iD, @businessDiscountRequestID, @productID, @guid, @quantity, @price, @addTime, @addUserName, @businessID, helper);
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
		/// Updates a Mall_BusinessDiscountRequest_Product into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="businessDiscountRequestID">businessDiscountRequestID</param>
		/// <param name="productID">productID</param>
		/// <param name="guid">guid</param>
		/// <param name="quantity">quantity</param>
		/// <param name="price">price</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="businessID">businessID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_BusinessDiscountRequest_Product(int @iD, int @businessDiscountRequestID, int @productID, Guid @guid, int @quantity, decimal @price, DateTime @addTime, string @addUserName, int @businessID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BusinessDiscountRequestID] int,
	[ProductID] int,
	[Guid] uniqueidentifier,
	[Quantity] int,
	[Price] decimal(18, 2),
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[BusinessID] int
);

UPDATE [dbo].[Mall_BusinessDiscountRequest_Product] SET 
	[Mall_BusinessDiscountRequest_Product].[BusinessDiscountRequestID] = @BusinessDiscountRequestID,
	[Mall_BusinessDiscountRequest_Product].[ProductID] = @ProductID,
	[Mall_BusinessDiscountRequest_Product].[Guid] = @Guid,
	[Mall_BusinessDiscountRequest_Product].[Quantity] = @Quantity,
	[Mall_BusinessDiscountRequest_Product].[Price] = @Price,
	[Mall_BusinessDiscountRequest_Product].[AddTime] = @AddTime,
	[Mall_BusinessDiscountRequest_Product].[AddUserName] = @AddUserName,
	[Mall_BusinessDiscountRequest_Product].[BusinessID] = @BusinessID 
output 
	INSERTED.[ID],
	INSERTED.[BusinessDiscountRequestID],
	INSERTED.[ProductID],
	INSERTED.[Guid],
	INSERTED.[Quantity],
	INSERTED.[Price],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[BusinessID]
into @table
WHERE 
	[Mall_BusinessDiscountRequest_Product].[ID] = @ID

SELECT 
	[ID],
	[BusinessDiscountRequestID],
	[ProductID],
	[Guid],
	[Quantity],
	[Price],
	[AddTime],
	[AddUserName],
	[BusinessID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@BusinessDiscountRequestID", EntityBase.GetDatabaseValue(@businessDiscountRequestID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@Guid", EntityBase.GetDatabaseValue(@guid)));
			parameters.Add(new SqlParameter("@Quantity", EntityBase.GetDatabaseValue(@quantity)));
			parameters.Add(new SqlParameter("@Price", EntityBase.GetDatabaseValue(@price)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_BusinessDiscountRequest_Product from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_BusinessDiscountRequest_Product(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_BusinessDiscountRequest_Product(@iD, helper);
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
		/// Deletes a Mall_BusinessDiscountRequest_Product from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_BusinessDiscountRequest_Product(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_BusinessDiscountRequest_Product]
WHERE 
	[Mall_BusinessDiscountRequest_Product].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_BusinessDiscountRequest_Product object.
		/// </summary>
		/// <returns>The newly created Mall_BusinessDiscountRequest_Product object.</returns>
		public static Mall_BusinessDiscountRequest_Product CreateMall_BusinessDiscountRequest_Product()
		{
			return InitializeNew<Mall_BusinessDiscountRequest_Product>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_BusinessDiscountRequest_Product by a Mall_BusinessDiscountRequest_Product's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_BusinessDiscountRequest_Product</returns>
		public static Mall_BusinessDiscountRequest_Product GetMall_BusinessDiscountRequest_Product(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_BusinessDiscountRequest_Product.SelectFieldList + @"
FROM [dbo].[Mall_BusinessDiscountRequest_Product] 
WHERE 
	[Mall_BusinessDiscountRequest_Product].[ID] = @ID " + Mall_BusinessDiscountRequest_Product.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_BusinessDiscountRequest_Product>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_BusinessDiscountRequest_Product by a Mall_BusinessDiscountRequest_Product's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_BusinessDiscountRequest_Product</returns>
		public static Mall_BusinessDiscountRequest_Product GetMall_BusinessDiscountRequest_Product(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_BusinessDiscountRequest_Product.SelectFieldList + @"
FROM [dbo].[Mall_BusinessDiscountRequest_Product] 
WHERE 
	[Mall_BusinessDiscountRequest_Product].[ID] = @ID " + Mall_BusinessDiscountRequest_Product.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_BusinessDiscountRequest_Product>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessDiscountRequest_Product objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_BusinessDiscountRequest_Product objects.</returns>
		public static EntityList<Mall_BusinessDiscountRequest_Product> GetMall_BusinessDiscountRequest_Products()
		{
			string commandText = @"
SELECT " + Mall_BusinessDiscountRequest_Product.SelectFieldList + "FROM [dbo].[Mall_BusinessDiscountRequest_Product] " + Mall_BusinessDiscountRequest_Product.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_BusinessDiscountRequest_Product>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_BusinessDiscountRequest_Product objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_BusinessDiscountRequest_Product objects.</returns>
        public static EntityList<Mall_BusinessDiscountRequest_Product> GetMall_BusinessDiscountRequest_Products(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_BusinessDiscountRequest_Product>(SelectFieldList, "FROM [dbo].[Mall_BusinessDiscountRequest_Product]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_BusinessDiscountRequest_Product objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_BusinessDiscountRequest_Product objects.</returns>
        public static EntityList<Mall_BusinessDiscountRequest_Product> GetMall_BusinessDiscountRequest_Products(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_BusinessDiscountRequest_Product>(SelectFieldList, "FROM [dbo].[Mall_BusinessDiscountRequest_Product]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_BusinessDiscountRequest_Product objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_BusinessDiscountRequest_Product objects.</returns>
		protected static EntityList<Mall_BusinessDiscountRequest_Product> GetMall_BusinessDiscountRequest_Products(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_BusinessDiscountRequest_Products(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessDiscountRequest_Product objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_BusinessDiscountRequest_Product objects.</returns>
		protected static EntityList<Mall_BusinessDiscountRequest_Product> GetMall_BusinessDiscountRequest_Products(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_BusinessDiscountRequest_Products(string.Empty, where, parameters, Mall_BusinessDiscountRequest_Product.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessDiscountRequest_Product objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_BusinessDiscountRequest_Product objects.</returns>
		protected static EntityList<Mall_BusinessDiscountRequest_Product> GetMall_BusinessDiscountRequest_Products(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_BusinessDiscountRequest_Products(prefix, where, parameters, Mall_BusinessDiscountRequest_Product.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessDiscountRequest_Product objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_BusinessDiscountRequest_Product objects.</returns>
		protected static EntityList<Mall_BusinessDiscountRequest_Product> GetMall_BusinessDiscountRequest_Products(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_BusinessDiscountRequest_Products(string.Empty, where, parameters, Mall_BusinessDiscountRequest_Product.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessDiscountRequest_Product objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_BusinessDiscountRequest_Product objects.</returns>
		protected static EntityList<Mall_BusinessDiscountRequest_Product> GetMall_BusinessDiscountRequest_Products(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_BusinessDiscountRequest_Products(prefix, where, parameters, Mall_BusinessDiscountRequest_Product.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessDiscountRequest_Product objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_BusinessDiscountRequest_Product objects.</returns>
		protected static EntityList<Mall_BusinessDiscountRequest_Product> GetMall_BusinessDiscountRequest_Products(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_BusinessDiscountRequest_Product.SelectFieldList + "FROM [dbo].[Mall_BusinessDiscountRequest_Product] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_BusinessDiscountRequest_Product>(reader);
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
        protected static EntityList<Mall_BusinessDiscountRequest_Product> GetMall_BusinessDiscountRequest_Products(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_BusinessDiscountRequest_Product>(SelectFieldList, "FROM [dbo].[Mall_BusinessDiscountRequest_Product] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_BusinessDiscountRequest_Product objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_BusinessDiscountRequest_ProductCount()
        {
            return GetMall_BusinessDiscountRequest_ProductCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_BusinessDiscountRequest_Product objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_BusinessDiscountRequest_ProductCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_BusinessDiscountRequest_Product] " + where;

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
		public static partial class Mall_BusinessDiscountRequest_Product_Properties
		{
			public const string ID = "ID";
			public const string BusinessDiscountRequestID = "BusinessDiscountRequestID";
			public const string ProductID = "ProductID";
			public const string Guid = "Guid";
			public const string Quantity = "Quantity";
			public const string Price = "Price";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string BusinessID = "BusinessID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"BusinessDiscountRequestID" , "int:"},
    			 {"ProductID" , "int:"},
    			 {"Guid" , "Guid:"},
    			 {"Quantity" , "int:"},
    			 {"Price" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"BusinessID" , "int:"},
            };
		}
		#endregion
	}
}
