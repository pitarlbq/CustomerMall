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
	/// This object represents the properties and methods of a Mall_ShoppingCart.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_ShoppingCart 
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
		private int _variantID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int VariantID
		{
			[DebuggerStepThrough()]
			get { return this._variantID; }
			set 
			{
				if (this._variantID != value) 
				{
					this._variantID = value;
					this.IsDirty = true;	
					OnPropertyChanged("VariantID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _variantTitle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string VariantTitle
		{
			[DebuggerStepThrough()]
			get { return this._variantTitle; }
			set 
			{
				if (this._variantTitle != value) 
				{
					this._variantTitle = value;
					this.IsDirty = true;	
					OnPropertyChanged("VariantTitle");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _variantName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string VariantName
		{
			[DebuggerStepThrough()]
			get { return this._variantName; }
			set 
			{
				if (this._variantName != value) 
				{
					this._variantName = value;
					this.IsDirty = true;	
					OnPropertyChanged("VariantName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _salePrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal SalePrice
		{
			[DebuggerStepThrough()]
			get { return this._salePrice; }
			set 
			{
				if (this._salePrice != value) 
				{
					this._salePrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("SalePrice");
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
		private decimal _totalPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalPrice
		{
			[DebuggerStepThrough()]
			get { return this._totalPrice; }
			set 
			{
				if (this._totalPrice != value) 
				{
					this._totalPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalPrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _userID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int UserID
		{
			[DebuggerStepThrough()]
			get { return this._userID; }
			set 
			{
				if (this._userID != value) 
				{
					this._userID = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserID");
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
		private string _addMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private int _productOrderType = int.MinValue;
		/// <summary>
		/// 16-普通商品 17-积分购买商品 18-合伙人购买商品
		/// </summary>
        [Description("16-普通商品 17-积分购买商品 18-合伙人购买商品")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProductOrderType
		{
			[DebuggerStepThrough()]
			get { return this._productOrderType; }
			set 
			{
				if (this._productOrderType != value) 
				{
					this._productOrderType = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductOrderType");
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
	[ProductID] int,
	[ProductName] nvarchar(200),
	[VariantID] int,
	[VariantTitle] nvarchar(200),
	[VariantName] nvarchar(200),
	[SalePrice] decimal(18, 2),
	[Quantity] int,
	[TotalPrice] decimal(18, 2),
	[UserID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[ProductOrderType] int
);

INSERT INTO [dbo].[Mall_ShoppingCart] (
	[Mall_ShoppingCart].[ProductID],
	[Mall_ShoppingCart].[ProductName],
	[Mall_ShoppingCart].[VariantID],
	[Mall_ShoppingCart].[VariantTitle],
	[Mall_ShoppingCart].[VariantName],
	[Mall_ShoppingCart].[SalePrice],
	[Mall_ShoppingCart].[Quantity],
	[Mall_ShoppingCart].[TotalPrice],
	[Mall_ShoppingCart].[UserID],
	[Mall_ShoppingCart].[AddTime],
	[Mall_ShoppingCart].[AddMan],
	[Mall_ShoppingCart].[ProductOrderType]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[ProductName],
	INSERTED.[VariantID],
	INSERTED.[VariantTitle],
	INSERTED.[VariantName],
	INSERTED.[SalePrice],
	INSERTED.[Quantity],
	INSERTED.[TotalPrice],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ProductOrderType]
into @table
VALUES ( 
	@ProductID,
	@ProductName,
	@VariantID,
	@VariantTitle,
	@VariantName,
	@SalePrice,
	@Quantity,
	@TotalPrice,
	@UserID,
	@AddTime,
	@AddMan,
	@ProductOrderType 
); 

SELECT 
	[ID],
	[ProductID],
	[ProductName],
	[VariantID],
	[VariantTitle],
	[VariantName],
	[SalePrice],
	[Quantity],
	[TotalPrice],
	[UserID],
	[AddTime],
	[AddMan],
	[ProductOrderType] 
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
	[ProductID] int,
	[ProductName] nvarchar(200),
	[VariantID] int,
	[VariantTitle] nvarchar(200),
	[VariantName] nvarchar(200),
	[SalePrice] decimal(18, 2),
	[Quantity] int,
	[TotalPrice] decimal(18, 2),
	[UserID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[ProductOrderType] int
);

UPDATE [dbo].[Mall_ShoppingCart] SET 
	[Mall_ShoppingCart].[ProductID] = @ProductID,
	[Mall_ShoppingCart].[ProductName] = @ProductName,
	[Mall_ShoppingCart].[VariantID] = @VariantID,
	[Mall_ShoppingCart].[VariantTitle] = @VariantTitle,
	[Mall_ShoppingCart].[VariantName] = @VariantName,
	[Mall_ShoppingCart].[SalePrice] = @SalePrice,
	[Mall_ShoppingCart].[Quantity] = @Quantity,
	[Mall_ShoppingCart].[TotalPrice] = @TotalPrice,
	[Mall_ShoppingCart].[UserID] = @UserID,
	[Mall_ShoppingCart].[AddTime] = @AddTime,
	[Mall_ShoppingCart].[AddMan] = @AddMan,
	[Mall_ShoppingCart].[ProductOrderType] = @ProductOrderType 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[ProductName],
	INSERTED.[VariantID],
	INSERTED.[VariantTitle],
	INSERTED.[VariantName],
	INSERTED.[SalePrice],
	INSERTED.[Quantity],
	INSERTED.[TotalPrice],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ProductOrderType]
into @table
WHERE 
	[Mall_ShoppingCart].[ID] = @ID

SELECT 
	[ID],
	[ProductID],
	[ProductName],
	[VariantID],
	[VariantTitle],
	[VariantName],
	[SalePrice],
	[Quantity],
	[TotalPrice],
	[UserID],
	[AddTime],
	[AddMan],
	[ProductOrderType] 
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
DELETE FROM [dbo].[Mall_ShoppingCart]
WHERE 
	[Mall_ShoppingCart].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_ShoppingCart() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_ShoppingCart(this.ID));
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
	[Mall_ShoppingCart].[ID],
	[Mall_ShoppingCart].[ProductID],
	[Mall_ShoppingCart].[ProductName],
	[Mall_ShoppingCart].[VariantID],
	[Mall_ShoppingCart].[VariantTitle],
	[Mall_ShoppingCart].[VariantName],
	[Mall_ShoppingCart].[SalePrice],
	[Mall_ShoppingCart].[Quantity],
	[Mall_ShoppingCart].[TotalPrice],
	[Mall_ShoppingCart].[UserID],
	[Mall_ShoppingCart].[AddTime],
	[Mall_ShoppingCart].[AddMan],
	[Mall_ShoppingCart].[ProductOrderType]
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
                return "Mall_ShoppingCart";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_ShoppingCart into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productID">productID</param>
		/// <param name="productName">productName</param>
		/// <param name="variantID">variantID</param>
		/// <param name="variantTitle">variantTitle</param>
		/// <param name="variantName">variantName</param>
		/// <param name="salePrice">salePrice</param>
		/// <param name="quantity">quantity</param>
		/// <param name="totalPrice">totalPrice</param>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="productOrderType">productOrderType</param>
		public static void InsertMall_ShoppingCart(int @productID, string @productName, int @variantID, string @variantTitle, string @variantName, decimal @salePrice, int @quantity, decimal @totalPrice, int @userID, DateTime @addTime, string @addMan, int @productOrderType)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_ShoppingCart(@productID, @productName, @variantID, @variantTitle, @variantName, @salePrice, @quantity, @totalPrice, @userID, @addTime, @addMan, @productOrderType, helper);
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
		/// Insert a Mall_ShoppingCart into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productID">productID</param>
		/// <param name="productName">productName</param>
		/// <param name="variantID">variantID</param>
		/// <param name="variantTitle">variantTitle</param>
		/// <param name="variantName">variantName</param>
		/// <param name="salePrice">salePrice</param>
		/// <param name="quantity">quantity</param>
		/// <param name="totalPrice">totalPrice</param>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="productOrderType">productOrderType</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_ShoppingCart(int @productID, string @productName, int @variantID, string @variantTitle, string @variantName, decimal @salePrice, int @quantity, decimal @totalPrice, int @userID, DateTime @addTime, string @addMan, int @productOrderType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProductID] int,
	[ProductName] nvarchar(200),
	[VariantID] int,
	[VariantTitle] nvarchar(200),
	[VariantName] nvarchar(200),
	[SalePrice] decimal(18, 2),
	[Quantity] int,
	[TotalPrice] decimal(18, 2),
	[UserID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[ProductOrderType] int
);

INSERT INTO [dbo].[Mall_ShoppingCart] (
	[Mall_ShoppingCart].[ProductID],
	[Mall_ShoppingCart].[ProductName],
	[Mall_ShoppingCart].[VariantID],
	[Mall_ShoppingCart].[VariantTitle],
	[Mall_ShoppingCart].[VariantName],
	[Mall_ShoppingCart].[SalePrice],
	[Mall_ShoppingCart].[Quantity],
	[Mall_ShoppingCart].[TotalPrice],
	[Mall_ShoppingCart].[UserID],
	[Mall_ShoppingCart].[AddTime],
	[Mall_ShoppingCart].[AddMan],
	[Mall_ShoppingCart].[ProductOrderType]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[ProductName],
	INSERTED.[VariantID],
	INSERTED.[VariantTitle],
	INSERTED.[VariantName],
	INSERTED.[SalePrice],
	INSERTED.[Quantity],
	INSERTED.[TotalPrice],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ProductOrderType]
into @table
VALUES ( 
	@ProductID,
	@ProductName,
	@VariantID,
	@VariantTitle,
	@VariantName,
	@SalePrice,
	@Quantity,
	@TotalPrice,
	@UserID,
	@AddTime,
	@AddMan,
	@ProductOrderType 
); 

SELECT 
	[ID],
	[ProductID],
	[ProductName],
	[VariantID],
	[VariantTitle],
	[VariantName],
	[SalePrice],
	[Quantity],
	[TotalPrice],
	[UserID],
	[AddTime],
	[AddMan],
	[ProductOrderType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@ProductName", EntityBase.GetDatabaseValue(@productName)));
			parameters.Add(new SqlParameter("@VariantID", EntityBase.GetDatabaseValue(@variantID)));
			parameters.Add(new SqlParameter("@VariantTitle", EntityBase.GetDatabaseValue(@variantTitle)));
			parameters.Add(new SqlParameter("@VariantName", EntityBase.GetDatabaseValue(@variantName)));
			parameters.Add(new SqlParameter("@SalePrice", EntityBase.GetDatabaseValue(@salePrice)));
			parameters.Add(new SqlParameter("@Quantity", EntityBase.GetDatabaseValue(@quantity)));
			parameters.Add(new SqlParameter("@TotalPrice", EntityBase.GetDatabaseValue(@totalPrice)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ProductOrderType", EntityBase.GetDatabaseValue(@productOrderType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_ShoppingCart into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="productID">productID</param>
		/// <param name="productName">productName</param>
		/// <param name="variantID">variantID</param>
		/// <param name="variantTitle">variantTitle</param>
		/// <param name="variantName">variantName</param>
		/// <param name="salePrice">salePrice</param>
		/// <param name="quantity">quantity</param>
		/// <param name="totalPrice">totalPrice</param>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="productOrderType">productOrderType</param>
		public static void UpdateMall_ShoppingCart(int @iD, int @productID, string @productName, int @variantID, string @variantTitle, string @variantName, decimal @salePrice, int @quantity, decimal @totalPrice, int @userID, DateTime @addTime, string @addMan, int @productOrderType)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_ShoppingCart(@iD, @productID, @productName, @variantID, @variantTitle, @variantName, @salePrice, @quantity, @totalPrice, @userID, @addTime, @addMan, @productOrderType, helper);
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
		/// Updates a Mall_ShoppingCart into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="productID">productID</param>
		/// <param name="productName">productName</param>
		/// <param name="variantID">variantID</param>
		/// <param name="variantTitle">variantTitle</param>
		/// <param name="variantName">variantName</param>
		/// <param name="salePrice">salePrice</param>
		/// <param name="quantity">quantity</param>
		/// <param name="totalPrice">totalPrice</param>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="productOrderType">productOrderType</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_ShoppingCart(int @iD, int @productID, string @productName, int @variantID, string @variantTitle, string @variantName, decimal @salePrice, int @quantity, decimal @totalPrice, int @userID, DateTime @addTime, string @addMan, int @productOrderType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProductID] int,
	[ProductName] nvarchar(200),
	[VariantID] int,
	[VariantTitle] nvarchar(200),
	[VariantName] nvarchar(200),
	[SalePrice] decimal(18, 2),
	[Quantity] int,
	[TotalPrice] decimal(18, 2),
	[UserID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[ProductOrderType] int
);

UPDATE [dbo].[Mall_ShoppingCart] SET 
	[Mall_ShoppingCart].[ProductID] = @ProductID,
	[Mall_ShoppingCart].[ProductName] = @ProductName,
	[Mall_ShoppingCart].[VariantID] = @VariantID,
	[Mall_ShoppingCart].[VariantTitle] = @VariantTitle,
	[Mall_ShoppingCart].[VariantName] = @VariantName,
	[Mall_ShoppingCart].[SalePrice] = @SalePrice,
	[Mall_ShoppingCart].[Quantity] = @Quantity,
	[Mall_ShoppingCart].[TotalPrice] = @TotalPrice,
	[Mall_ShoppingCart].[UserID] = @UserID,
	[Mall_ShoppingCart].[AddTime] = @AddTime,
	[Mall_ShoppingCart].[AddMan] = @AddMan,
	[Mall_ShoppingCart].[ProductOrderType] = @ProductOrderType 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[ProductName],
	INSERTED.[VariantID],
	INSERTED.[VariantTitle],
	INSERTED.[VariantName],
	INSERTED.[SalePrice],
	INSERTED.[Quantity],
	INSERTED.[TotalPrice],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ProductOrderType]
into @table
WHERE 
	[Mall_ShoppingCart].[ID] = @ID

SELECT 
	[ID],
	[ProductID],
	[ProductName],
	[VariantID],
	[VariantTitle],
	[VariantName],
	[SalePrice],
	[Quantity],
	[TotalPrice],
	[UserID],
	[AddTime],
	[AddMan],
	[ProductOrderType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@ProductName", EntityBase.GetDatabaseValue(@productName)));
			parameters.Add(new SqlParameter("@VariantID", EntityBase.GetDatabaseValue(@variantID)));
			parameters.Add(new SqlParameter("@VariantTitle", EntityBase.GetDatabaseValue(@variantTitle)));
			parameters.Add(new SqlParameter("@VariantName", EntityBase.GetDatabaseValue(@variantName)));
			parameters.Add(new SqlParameter("@SalePrice", EntityBase.GetDatabaseValue(@salePrice)));
			parameters.Add(new SqlParameter("@Quantity", EntityBase.GetDatabaseValue(@quantity)));
			parameters.Add(new SqlParameter("@TotalPrice", EntityBase.GetDatabaseValue(@totalPrice)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ProductOrderType", EntityBase.GetDatabaseValue(@productOrderType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_ShoppingCart from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_ShoppingCart(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_ShoppingCart(@iD, helper);
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
		/// Deletes a Mall_ShoppingCart from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_ShoppingCart(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_ShoppingCart]
WHERE 
	[Mall_ShoppingCart].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_ShoppingCart object.
		/// </summary>
		/// <returns>The newly created Mall_ShoppingCart object.</returns>
		public static Mall_ShoppingCart CreateMall_ShoppingCart()
		{
			return InitializeNew<Mall_ShoppingCart>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_ShoppingCart by a Mall_ShoppingCart's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_ShoppingCart</returns>
		public static Mall_ShoppingCart GetMall_ShoppingCart(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_ShoppingCart.SelectFieldList + @"
FROM [dbo].[Mall_ShoppingCart] 
WHERE 
	[Mall_ShoppingCart].[ID] = @ID " + Mall_ShoppingCart.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ShoppingCart>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_ShoppingCart by a Mall_ShoppingCart's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_ShoppingCart</returns>
		public static Mall_ShoppingCart GetMall_ShoppingCart(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_ShoppingCart.SelectFieldList + @"
FROM [dbo].[Mall_ShoppingCart] 
WHERE 
	[Mall_ShoppingCart].[ID] = @ID " + Mall_ShoppingCart.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ShoppingCart>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShoppingCart objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_ShoppingCart objects.</returns>
		public static EntityList<Mall_ShoppingCart> GetMall_ShoppingCarts()
		{
			string commandText = @"
SELECT " + Mall_ShoppingCart.SelectFieldList + "FROM [dbo].[Mall_ShoppingCart] " + Mall_ShoppingCart.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_ShoppingCart>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_ShoppingCart objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ShoppingCart objects.</returns>
        public static EntityList<Mall_ShoppingCart> GetMall_ShoppingCarts(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ShoppingCart>(SelectFieldList, "FROM [dbo].[Mall_ShoppingCart]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_ShoppingCart objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ShoppingCart objects.</returns>
        public static EntityList<Mall_ShoppingCart> GetMall_ShoppingCarts(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ShoppingCart>(SelectFieldList, "FROM [dbo].[Mall_ShoppingCart]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_ShoppingCart objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ShoppingCart objects.</returns>
		protected static EntityList<Mall_ShoppingCart> GetMall_ShoppingCarts(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ShoppingCarts(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShoppingCart objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShoppingCart objects.</returns>
		protected static EntityList<Mall_ShoppingCart> GetMall_ShoppingCarts(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ShoppingCarts(string.Empty, where, parameters, Mall_ShoppingCart.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShoppingCart objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShoppingCart objects.</returns>
		protected static EntityList<Mall_ShoppingCart> GetMall_ShoppingCarts(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ShoppingCarts(prefix, where, parameters, Mall_ShoppingCart.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShoppingCart objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShoppingCart objects.</returns>
		protected static EntityList<Mall_ShoppingCart> GetMall_ShoppingCarts(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ShoppingCarts(string.Empty, where, parameters, Mall_ShoppingCart.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShoppingCart objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShoppingCart objects.</returns>
		protected static EntityList<Mall_ShoppingCart> GetMall_ShoppingCarts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ShoppingCarts(prefix, where, parameters, Mall_ShoppingCart.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShoppingCart objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ShoppingCart objects.</returns>
		protected static EntityList<Mall_ShoppingCart> GetMall_ShoppingCarts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_ShoppingCart.SelectFieldList + "FROM [dbo].[Mall_ShoppingCart] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_ShoppingCart>(reader);
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
        protected static EntityList<Mall_ShoppingCart> GetMall_ShoppingCarts(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ShoppingCart>(SelectFieldList, "FROM [dbo].[Mall_ShoppingCart] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_ShoppingCart objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ShoppingCartCount()
        {
            return GetMall_ShoppingCartCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_ShoppingCart objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ShoppingCartCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_ShoppingCart] " + where;

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
		public static partial class Mall_ShoppingCart_Properties
		{
			public const string ID = "ID";
			public const string ProductID = "ProductID";
			public const string ProductName = "ProductName";
			public const string VariantID = "VariantID";
			public const string VariantTitle = "VariantTitle";
			public const string VariantName = "VariantName";
			public const string SalePrice = "SalePrice";
			public const string Quantity = "Quantity";
			public const string TotalPrice = "TotalPrice";
			public const string UserID = "UserID";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string ProductOrderType = "ProductOrderType";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProductID" , "int:"},
    			 {"ProductName" , "string:"},
    			 {"VariantID" , "int:"},
    			 {"VariantTitle" , "string:"},
    			 {"VariantName" , "string:"},
    			 {"SalePrice" , "decimal:"},
    			 {"Quantity" , "int:"},
    			 {"TotalPrice" , "decimal:"},
    			 {"UserID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"ProductOrderType" , "int:16-普通商品 17-积分购买商品 18-合伙人购买商品"},
            };
		}
		#endregion
	}
}
