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
	/// This object represents the properties and methods of a Cheque_OutingProduct.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_OutingProduct 
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
		private int _outingID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int OutingID
		{
			[DebuggerStepThrough()]
			get { return this._outingID; }
			set 
			{
				if (this._outingID != value) 
				{
					this._outingID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OutingID");
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
		private int _totalCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
		private string _sellerAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SellerAddress
		{
			[DebuggerStepThrough()]
			get { return this._sellerAddress; }
			set 
			{
				if (this._sellerAddress != value) 
				{
					this._sellerAddress = value;
					this.IsDirty = true;	
					OnPropertyChanged("SellerAddress");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _productStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ProductStartTime
		{
			[DebuggerStepThrough()]
			get { return this._productStartTime; }
			set 
			{
				if (this._productStartTime != value) 
				{
					this._productStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductStartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _productEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ProductEndTime
		{
			[DebuggerStepThrough()]
			get { return this._productEndTime; }
			set 
			{
				if (this._productEndTime != value) 
				{
					this._productEndTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductEndTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _productTotalCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ProductTotalCost
		{
			[DebuggerStepThrough()]
			get { return this._productTotalCost; }
			set 
			{
				if (this._productTotalCost != value) 
				{
					this._productTotalCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductTotalCost");
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
		private string _gUID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string GUID
		{
			[DebuggerStepThrough()]
			get { return this._gUID; }
			set 
			{
				if (this._gUID != value) 
				{
					this._gUID = value;
					this.IsDirty = true;	
					OnPropertyChanged("GUID");
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
	[OutingID] int,
	[ProductName] nvarchar(500),
	[TotalCount] int,
	[SellerAddress] nvarchar(500),
	[ProductStartTime] datetime,
	[ProductEndTime] datetime,
	[ProductTotalCost] decimal(18, 2),
	[AddTime] datetime,
	[GUID] nvarchar(500)
);

INSERT INTO [dbo].[Cheque_OutingProduct] (
	[Cheque_OutingProduct].[OutingID],
	[Cheque_OutingProduct].[ProductName],
	[Cheque_OutingProduct].[TotalCount],
	[Cheque_OutingProduct].[SellerAddress],
	[Cheque_OutingProduct].[ProductStartTime],
	[Cheque_OutingProduct].[ProductEndTime],
	[Cheque_OutingProduct].[ProductTotalCost],
	[Cheque_OutingProduct].[AddTime],
	[Cheque_OutingProduct].[GUID]
) 
output 
	INSERTED.[ID],
	INSERTED.[OutingID],
	INSERTED.[ProductName],
	INSERTED.[TotalCount],
	INSERTED.[SellerAddress],
	INSERTED.[ProductStartTime],
	INSERTED.[ProductEndTime],
	INSERTED.[ProductTotalCost],
	INSERTED.[AddTime],
	INSERTED.[GUID]
into @table
VALUES ( 
	@OutingID,
	@ProductName,
	@TotalCount,
	@SellerAddress,
	@ProductStartTime,
	@ProductEndTime,
	@ProductTotalCost,
	@AddTime,
	@GUID 
); 

SELECT 
	[ID],
	[OutingID],
	[ProductName],
	[TotalCount],
	[SellerAddress],
	[ProductStartTime],
	[ProductEndTime],
	[ProductTotalCost],
	[AddTime],
	[GUID] 
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
	[OutingID] int,
	[ProductName] nvarchar(500),
	[TotalCount] int,
	[SellerAddress] nvarchar(500),
	[ProductStartTime] datetime,
	[ProductEndTime] datetime,
	[ProductTotalCost] decimal(18, 2),
	[AddTime] datetime,
	[GUID] nvarchar(500)
);

UPDATE [dbo].[Cheque_OutingProduct] SET 
	[Cheque_OutingProduct].[OutingID] = @OutingID,
	[Cheque_OutingProduct].[ProductName] = @ProductName,
	[Cheque_OutingProduct].[TotalCount] = @TotalCount,
	[Cheque_OutingProduct].[SellerAddress] = @SellerAddress,
	[Cheque_OutingProduct].[ProductStartTime] = @ProductStartTime,
	[Cheque_OutingProduct].[ProductEndTime] = @ProductEndTime,
	[Cheque_OutingProduct].[ProductTotalCost] = @ProductTotalCost,
	[Cheque_OutingProduct].[AddTime] = @AddTime,
	[Cheque_OutingProduct].[GUID] = @GUID 
output 
	INSERTED.[ID],
	INSERTED.[OutingID],
	INSERTED.[ProductName],
	INSERTED.[TotalCount],
	INSERTED.[SellerAddress],
	INSERTED.[ProductStartTime],
	INSERTED.[ProductEndTime],
	INSERTED.[ProductTotalCost],
	INSERTED.[AddTime],
	INSERTED.[GUID]
into @table
WHERE 
	[Cheque_OutingProduct].[ID] = @ID

SELECT 
	[ID],
	[OutingID],
	[ProductName],
	[TotalCount],
	[SellerAddress],
	[ProductStartTime],
	[ProductEndTime],
	[ProductTotalCost],
	[AddTime],
	[GUID] 
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
DELETE FROM [dbo].[Cheque_OutingProduct]
WHERE 
	[Cheque_OutingProduct].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_OutingProduct() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_OutingProduct(this.ID));
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
	[Cheque_OutingProduct].[ID],
	[Cheque_OutingProduct].[OutingID],
	[Cheque_OutingProduct].[ProductName],
	[Cheque_OutingProduct].[TotalCount],
	[Cheque_OutingProduct].[SellerAddress],
	[Cheque_OutingProduct].[ProductStartTime],
	[Cheque_OutingProduct].[ProductEndTime],
	[Cheque_OutingProduct].[ProductTotalCost],
	[Cheque_OutingProduct].[AddTime],
	[Cheque_OutingProduct].[GUID]
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
                return "Cheque_OutingProduct";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_OutingProduct into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="outingID">outingID</param>
		/// <param name="productName">productName</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="sellerAddress">sellerAddress</param>
		/// <param name="productStartTime">productStartTime</param>
		/// <param name="productEndTime">productEndTime</param>
		/// <param name="productTotalCost">productTotalCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		public static void InsertCheque_OutingProduct(int @outingID, string @productName, int @totalCount, string @sellerAddress, DateTime @productStartTime, DateTime @productEndTime, decimal @productTotalCost, DateTime @addTime, string @gUID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_OutingProduct(@outingID, @productName, @totalCount, @sellerAddress, @productStartTime, @productEndTime, @productTotalCost, @addTime, @gUID, helper);
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
		/// Insert a Cheque_OutingProduct into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="outingID">outingID</param>
		/// <param name="productName">productName</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="sellerAddress">sellerAddress</param>
		/// <param name="productStartTime">productStartTime</param>
		/// <param name="productEndTime">productEndTime</param>
		/// <param name="productTotalCost">productTotalCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_OutingProduct(int @outingID, string @productName, int @totalCount, string @sellerAddress, DateTime @productStartTime, DateTime @productEndTime, decimal @productTotalCost, DateTime @addTime, string @gUID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OutingID] int,
	[ProductName] nvarchar(500),
	[TotalCount] int,
	[SellerAddress] nvarchar(500),
	[ProductStartTime] datetime,
	[ProductEndTime] datetime,
	[ProductTotalCost] decimal(18, 2),
	[AddTime] datetime,
	[GUID] nvarchar(500)
);

INSERT INTO [dbo].[Cheque_OutingProduct] (
	[Cheque_OutingProduct].[OutingID],
	[Cheque_OutingProduct].[ProductName],
	[Cheque_OutingProduct].[TotalCount],
	[Cheque_OutingProduct].[SellerAddress],
	[Cheque_OutingProduct].[ProductStartTime],
	[Cheque_OutingProduct].[ProductEndTime],
	[Cheque_OutingProduct].[ProductTotalCost],
	[Cheque_OutingProduct].[AddTime],
	[Cheque_OutingProduct].[GUID]
) 
output 
	INSERTED.[ID],
	INSERTED.[OutingID],
	INSERTED.[ProductName],
	INSERTED.[TotalCount],
	INSERTED.[SellerAddress],
	INSERTED.[ProductStartTime],
	INSERTED.[ProductEndTime],
	INSERTED.[ProductTotalCost],
	INSERTED.[AddTime],
	INSERTED.[GUID]
into @table
VALUES ( 
	@OutingID,
	@ProductName,
	@TotalCount,
	@SellerAddress,
	@ProductStartTime,
	@ProductEndTime,
	@ProductTotalCost,
	@AddTime,
	@GUID 
); 

SELECT 
	[ID],
	[OutingID],
	[ProductName],
	[TotalCount],
	[SellerAddress],
	[ProductStartTime],
	[ProductEndTime],
	[ProductTotalCost],
	[AddTime],
	[GUID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OutingID", EntityBase.GetDatabaseValue(@outingID)));
			parameters.Add(new SqlParameter("@ProductName", EntityBase.GetDatabaseValue(@productName)));
			parameters.Add(new SqlParameter("@TotalCount", EntityBase.GetDatabaseValue(@totalCount)));
			parameters.Add(new SqlParameter("@SellerAddress", EntityBase.GetDatabaseValue(@sellerAddress)));
			parameters.Add(new SqlParameter("@ProductStartTime", EntityBase.GetDatabaseValue(@productStartTime)));
			parameters.Add(new SqlParameter("@ProductEndTime", EntityBase.GetDatabaseValue(@productEndTime)));
			parameters.Add(new SqlParameter("@ProductTotalCost", EntityBase.GetDatabaseValue(@productTotalCost)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_OutingProduct into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="outingID">outingID</param>
		/// <param name="productName">productName</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="sellerAddress">sellerAddress</param>
		/// <param name="productStartTime">productStartTime</param>
		/// <param name="productEndTime">productEndTime</param>
		/// <param name="productTotalCost">productTotalCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		public static void UpdateCheque_OutingProduct(int @iD, int @outingID, string @productName, int @totalCount, string @sellerAddress, DateTime @productStartTime, DateTime @productEndTime, decimal @productTotalCost, DateTime @addTime, string @gUID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_OutingProduct(@iD, @outingID, @productName, @totalCount, @sellerAddress, @productStartTime, @productEndTime, @productTotalCost, @addTime, @gUID, helper);
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
		/// Updates a Cheque_OutingProduct into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="outingID">outingID</param>
		/// <param name="productName">productName</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="sellerAddress">sellerAddress</param>
		/// <param name="productStartTime">productStartTime</param>
		/// <param name="productEndTime">productEndTime</param>
		/// <param name="productTotalCost">productTotalCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_OutingProduct(int @iD, int @outingID, string @productName, int @totalCount, string @sellerAddress, DateTime @productStartTime, DateTime @productEndTime, decimal @productTotalCost, DateTime @addTime, string @gUID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OutingID] int,
	[ProductName] nvarchar(500),
	[TotalCount] int,
	[SellerAddress] nvarchar(500),
	[ProductStartTime] datetime,
	[ProductEndTime] datetime,
	[ProductTotalCost] decimal(18, 2),
	[AddTime] datetime,
	[GUID] nvarchar(500)
);

UPDATE [dbo].[Cheque_OutingProduct] SET 
	[Cheque_OutingProduct].[OutingID] = @OutingID,
	[Cheque_OutingProduct].[ProductName] = @ProductName,
	[Cheque_OutingProduct].[TotalCount] = @TotalCount,
	[Cheque_OutingProduct].[SellerAddress] = @SellerAddress,
	[Cheque_OutingProduct].[ProductStartTime] = @ProductStartTime,
	[Cheque_OutingProduct].[ProductEndTime] = @ProductEndTime,
	[Cheque_OutingProduct].[ProductTotalCost] = @ProductTotalCost,
	[Cheque_OutingProduct].[AddTime] = @AddTime,
	[Cheque_OutingProduct].[GUID] = @GUID 
output 
	INSERTED.[ID],
	INSERTED.[OutingID],
	INSERTED.[ProductName],
	INSERTED.[TotalCount],
	INSERTED.[SellerAddress],
	INSERTED.[ProductStartTime],
	INSERTED.[ProductEndTime],
	INSERTED.[ProductTotalCost],
	INSERTED.[AddTime],
	INSERTED.[GUID]
into @table
WHERE 
	[Cheque_OutingProduct].[ID] = @ID

SELECT 
	[ID],
	[OutingID],
	[ProductName],
	[TotalCount],
	[SellerAddress],
	[ProductStartTime],
	[ProductEndTime],
	[ProductTotalCost],
	[AddTime],
	[GUID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OutingID", EntityBase.GetDatabaseValue(@outingID)));
			parameters.Add(new SqlParameter("@ProductName", EntityBase.GetDatabaseValue(@productName)));
			parameters.Add(new SqlParameter("@TotalCount", EntityBase.GetDatabaseValue(@totalCount)));
			parameters.Add(new SqlParameter("@SellerAddress", EntityBase.GetDatabaseValue(@sellerAddress)));
			parameters.Add(new SqlParameter("@ProductStartTime", EntityBase.GetDatabaseValue(@productStartTime)));
			parameters.Add(new SqlParameter("@ProductEndTime", EntityBase.GetDatabaseValue(@productEndTime)));
			parameters.Add(new SqlParameter("@ProductTotalCost", EntityBase.GetDatabaseValue(@productTotalCost)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_OutingProduct from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_OutingProduct(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_OutingProduct(@iD, helper);
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
		/// Deletes a Cheque_OutingProduct from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_OutingProduct(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_OutingProduct]
WHERE 
	[Cheque_OutingProduct].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_OutingProduct object.
		/// </summary>
		/// <returns>The newly created Cheque_OutingProduct object.</returns>
		public static Cheque_OutingProduct CreateCheque_OutingProduct()
		{
			return InitializeNew<Cheque_OutingProduct>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_OutingProduct by a Cheque_OutingProduct's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_OutingProduct</returns>
		public static Cheque_OutingProduct GetCheque_OutingProduct(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_OutingProduct.SelectFieldList + @"
FROM [dbo].[Cheque_OutingProduct] 
WHERE 
	[Cheque_OutingProduct].[ID] = @ID " + Cheque_OutingProduct.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_OutingProduct>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_OutingProduct by a Cheque_OutingProduct's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_OutingProduct</returns>
		public static Cheque_OutingProduct GetCheque_OutingProduct(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_OutingProduct.SelectFieldList + @"
FROM [dbo].[Cheque_OutingProduct] 
WHERE 
	[Cheque_OutingProduct].[ID] = @ID " + Cheque_OutingProduct.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_OutingProduct>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutingProduct objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_OutingProduct objects.</returns>
		public static EntityList<Cheque_OutingProduct> GetCheque_OutingProducts()
		{
			string commandText = @"
SELECT " + Cheque_OutingProduct.SelectFieldList + "FROM [dbo].[Cheque_OutingProduct] " + Cheque_OutingProduct.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_OutingProduct>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_OutingProduct objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_OutingProduct objects.</returns>
        public static EntityList<Cheque_OutingProduct> GetCheque_OutingProducts(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_OutingProduct>(SelectFieldList, "FROM [dbo].[Cheque_OutingProduct]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_OutingProduct objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_OutingProduct objects.</returns>
        public static EntityList<Cheque_OutingProduct> GetCheque_OutingProducts(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_OutingProduct>(SelectFieldList, "FROM [dbo].[Cheque_OutingProduct]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_OutingProduct objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_OutingProduct objects.</returns>
		protected static EntityList<Cheque_OutingProduct> GetCheque_OutingProducts(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_OutingProducts(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutingProduct objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_OutingProduct objects.</returns>
		protected static EntityList<Cheque_OutingProduct> GetCheque_OutingProducts(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_OutingProducts(string.Empty, where, parameters, Cheque_OutingProduct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutingProduct objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_OutingProduct objects.</returns>
		protected static EntityList<Cheque_OutingProduct> GetCheque_OutingProducts(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_OutingProducts(prefix, where, parameters, Cheque_OutingProduct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutingProduct objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_OutingProduct objects.</returns>
		protected static EntityList<Cheque_OutingProduct> GetCheque_OutingProducts(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_OutingProducts(string.Empty, where, parameters, Cheque_OutingProduct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutingProduct objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_OutingProduct objects.</returns>
		protected static EntityList<Cheque_OutingProduct> GetCheque_OutingProducts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_OutingProducts(prefix, where, parameters, Cheque_OutingProduct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutingProduct objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_OutingProduct objects.</returns>
		protected static EntityList<Cheque_OutingProduct> GetCheque_OutingProducts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_OutingProduct.SelectFieldList + "FROM [dbo].[Cheque_OutingProduct] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_OutingProduct>(reader);
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
        protected static EntityList<Cheque_OutingProduct> GetCheque_OutingProducts(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_OutingProduct>(SelectFieldList, "FROM [dbo].[Cheque_OutingProduct] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_OutingProduct objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_OutingProductCount()
        {
            return GetCheque_OutingProductCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_OutingProduct objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_OutingProductCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_OutingProduct] " + where;

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
		public static partial class Cheque_OutingProduct_Properties
		{
			public const string ID = "ID";
			public const string OutingID = "OutingID";
			public const string ProductName = "ProductName";
			public const string TotalCount = "TotalCount";
			public const string SellerAddress = "SellerAddress";
			public const string ProductStartTime = "ProductStartTime";
			public const string ProductEndTime = "ProductEndTime";
			public const string ProductTotalCost = "ProductTotalCost";
			public const string AddTime = "AddTime";
			public const string GUID = "GUID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OutingID" , "int:"},
    			 {"ProductName" , "string:"},
    			 {"TotalCount" , "int:"},
    			 {"SellerAddress" , "string:"},
    			 {"ProductStartTime" , "DateTime:"},
    			 {"ProductEndTime" , "DateTime:"},
    			 {"ProductTotalCost" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"GUID" , "string:"},
            };
		}
		#endregion
	}
}
