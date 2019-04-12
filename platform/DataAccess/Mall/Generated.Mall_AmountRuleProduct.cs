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
	/// This object represents the properties and methods of a Mall_AmountRuleProduct.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_AmountRuleProduct 
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
		private int _amountRuleID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int AmountRuleID
		{
			[DebuggerStepThrough()]
			get { return this._amountRuleID; }
			set 
			{
				if (this._amountRuleID != value) 
				{
					this._amountRuleID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AmountRuleID");
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
		[DataObjectField(false, false, true)]
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
		private int _serviceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ServiceID
		{
			[DebuggerStepThrough()]
			get { return this._serviceID; }
			set 
			{
				if (this._serviceID != value) 
				{
					this._serviceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceID");
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
		private string _addUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
		[DataObjectField(false, false, true)]
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _serviceCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ServiceCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._serviceCategoryID; }
			set 
			{
				if (this._serviceCategoryID != value) 
				{
					this._serviceCategoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceCategoryID");
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
	[AmountRuleID] int,
	[ProductID] int,
	[ServiceID] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(50),
	[BusinessID] int,
	[ProductCategoryID] int,
	[ServiceCategoryID] int
);

INSERT INTO [dbo].[Mall_AmountRuleProduct] (
	[Mall_AmountRuleProduct].[AmountRuleID],
	[Mall_AmountRuleProduct].[ProductID],
	[Mall_AmountRuleProduct].[ServiceID],
	[Mall_AmountRuleProduct].[AddTime],
	[Mall_AmountRuleProduct].[AddUserName],
	[Mall_AmountRuleProduct].[BusinessID],
	[Mall_AmountRuleProduct].[ProductCategoryID],
	[Mall_AmountRuleProduct].[ServiceCategoryID]
) 
output 
	INSERTED.[ID],
	INSERTED.[AmountRuleID],
	INSERTED.[ProductID],
	INSERTED.[ServiceID],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[BusinessID],
	INSERTED.[ProductCategoryID],
	INSERTED.[ServiceCategoryID]
into @table
VALUES ( 
	@AmountRuleID,
	@ProductID,
	@ServiceID,
	@AddTime,
	@AddUserName,
	@BusinessID,
	@ProductCategoryID,
	@ServiceCategoryID 
); 

SELECT 
	[ID],
	[AmountRuleID],
	[ProductID],
	[ServiceID],
	[AddTime],
	[AddUserName],
	[BusinessID],
	[ProductCategoryID],
	[ServiceCategoryID] 
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
	[AmountRuleID] int,
	[ProductID] int,
	[ServiceID] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(50),
	[BusinessID] int,
	[ProductCategoryID] int,
	[ServiceCategoryID] int
);

UPDATE [dbo].[Mall_AmountRuleProduct] SET 
	[Mall_AmountRuleProduct].[AmountRuleID] = @AmountRuleID,
	[Mall_AmountRuleProduct].[ProductID] = @ProductID,
	[Mall_AmountRuleProduct].[ServiceID] = @ServiceID,
	[Mall_AmountRuleProduct].[AddTime] = @AddTime,
	[Mall_AmountRuleProduct].[AddUserName] = @AddUserName,
	[Mall_AmountRuleProduct].[BusinessID] = @BusinessID,
	[Mall_AmountRuleProduct].[ProductCategoryID] = @ProductCategoryID,
	[Mall_AmountRuleProduct].[ServiceCategoryID] = @ServiceCategoryID 
output 
	INSERTED.[ID],
	INSERTED.[AmountRuleID],
	INSERTED.[ProductID],
	INSERTED.[ServiceID],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[BusinessID],
	INSERTED.[ProductCategoryID],
	INSERTED.[ServiceCategoryID]
into @table
WHERE 
	[Mall_AmountRuleProduct].[ID] = @ID

SELECT 
	[ID],
	[AmountRuleID],
	[ProductID],
	[ServiceID],
	[AddTime],
	[AddUserName],
	[BusinessID],
	[ProductCategoryID],
	[ServiceCategoryID] 
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
DELETE FROM [dbo].[Mall_AmountRuleProduct]
WHERE 
	[Mall_AmountRuleProduct].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_AmountRuleProduct() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_AmountRuleProduct(this.ID));
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
	[Mall_AmountRuleProduct].[ID],
	[Mall_AmountRuleProduct].[AmountRuleID],
	[Mall_AmountRuleProduct].[ProductID],
	[Mall_AmountRuleProduct].[ServiceID],
	[Mall_AmountRuleProduct].[AddTime],
	[Mall_AmountRuleProduct].[AddUserName],
	[Mall_AmountRuleProduct].[BusinessID],
	[Mall_AmountRuleProduct].[ProductCategoryID],
	[Mall_AmountRuleProduct].[ServiceCategoryID]
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
                return "Mall_AmountRuleProduct";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_AmountRuleProduct into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="productID">productID</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="businessID">businessID</param>
		/// <param name="productCategoryID">productCategoryID</param>
		/// <param name="serviceCategoryID">serviceCategoryID</param>
		public static void InsertMall_AmountRuleProduct(int @amountRuleID, int @productID, int @serviceID, DateTime @addTime, string @addUserName, int @businessID, int @productCategoryID, int @serviceCategoryID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_AmountRuleProduct(@amountRuleID, @productID, @serviceID, @addTime, @addUserName, @businessID, @productCategoryID, @serviceCategoryID, helper);
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
		/// Insert a Mall_AmountRuleProduct into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="productID">productID</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="businessID">businessID</param>
		/// <param name="productCategoryID">productCategoryID</param>
		/// <param name="serviceCategoryID">serviceCategoryID</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_AmountRuleProduct(int @amountRuleID, int @productID, int @serviceID, DateTime @addTime, string @addUserName, int @businessID, int @productCategoryID, int @serviceCategoryID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AmountRuleID] int,
	[ProductID] int,
	[ServiceID] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(50),
	[BusinessID] int,
	[ProductCategoryID] int,
	[ServiceCategoryID] int
);

INSERT INTO [dbo].[Mall_AmountRuleProduct] (
	[Mall_AmountRuleProduct].[AmountRuleID],
	[Mall_AmountRuleProduct].[ProductID],
	[Mall_AmountRuleProduct].[ServiceID],
	[Mall_AmountRuleProduct].[AddTime],
	[Mall_AmountRuleProduct].[AddUserName],
	[Mall_AmountRuleProduct].[BusinessID],
	[Mall_AmountRuleProduct].[ProductCategoryID],
	[Mall_AmountRuleProduct].[ServiceCategoryID]
) 
output 
	INSERTED.[ID],
	INSERTED.[AmountRuleID],
	INSERTED.[ProductID],
	INSERTED.[ServiceID],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[BusinessID],
	INSERTED.[ProductCategoryID],
	INSERTED.[ServiceCategoryID]
into @table
VALUES ( 
	@AmountRuleID,
	@ProductID,
	@ServiceID,
	@AddTime,
	@AddUserName,
	@BusinessID,
	@ProductCategoryID,
	@ServiceCategoryID 
); 

SELECT 
	[ID],
	[AmountRuleID],
	[ProductID],
	[ServiceID],
	[AddTime],
	[AddUserName],
	[BusinessID],
	[ProductCategoryID],
	[ServiceCategoryID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@AmountRuleID", EntityBase.GetDatabaseValue(@amountRuleID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			parameters.Add(new SqlParameter("@ProductCategoryID", EntityBase.GetDatabaseValue(@productCategoryID)));
			parameters.Add(new SqlParameter("@ServiceCategoryID", EntityBase.GetDatabaseValue(@serviceCategoryID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_AmountRuleProduct into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="productID">productID</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="businessID">businessID</param>
		/// <param name="productCategoryID">productCategoryID</param>
		/// <param name="serviceCategoryID">serviceCategoryID</param>
		public static void UpdateMall_AmountRuleProduct(int @iD, int @amountRuleID, int @productID, int @serviceID, DateTime @addTime, string @addUserName, int @businessID, int @productCategoryID, int @serviceCategoryID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_AmountRuleProduct(@iD, @amountRuleID, @productID, @serviceID, @addTime, @addUserName, @businessID, @productCategoryID, @serviceCategoryID, helper);
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
		/// Updates a Mall_AmountRuleProduct into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="productID">productID</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="businessID">businessID</param>
		/// <param name="productCategoryID">productCategoryID</param>
		/// <param name="serviceCategoryID">serviceCategoryID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_AmountRuleProduct(int @iD, int @amountRuleID, int @productID, int @serviceID, DateTime @addTime, string @addUserName, int @businessID, int @productCategoryID, int @serviceCategoryID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AmountRuleID] int,
	[ProductID] int,
	[ServiceID] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(50),
	[BusinessID] int,
	[ProductCategoryID] int,
	[ServiceCategoryID] int
);

UPDATE [dbo].[Mall_AmountRuleProduct] SET 
	[Mall_AmountRuleProduct].[AmountRuleID] = @AmountRuleID,
	[Mall_AmountRuleProduct].[ProductID] = @ProductID,
	[Mall_AmountRuleProduct].[ServiceID] = @ServiceID,
	[Mall_AmountRuleProduct].[AddTime] = @AddTime,
	[Mall_AmountRuleProduct].[AddUserName] = @AddUserName,
	[Mall_AmountRuleProduct].[BusinessID] = @BusinessID,
	[Mall_AmountRuleProduct].[ProductCategoryID] = @ProductCategoryID,
	[Mall_AmountRuleProduct].[ServiceCategoryID] = @ServiceCategoryID 
output 
	INSERTED.[ID],
	INSERTED.[AmountRuleID],
	INSERTED.[ProductID],
	INSERTED.[ServiceID],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[BusinessID],
	INSERTED.[ProductCategoryID],
	INSERTED.[ServiceCategoryID]
into @table
WHERE 
	[Mall_AmountRuleProduct].[ID] = @ID

SELECT 
	[ID],
	[AmountRuleID],
	[ProductID],
	[ServiceID],
	[AddTime],
	[AddUserName],
	[BusinessID],
	[ProductCategoryID],
	[ServiceCategoryID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@AmountRuleID", EntityBase.GetDatabaseValue(@amountRuleID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			parameters.Add(new SqlParameter("@ProductCategoryID", EntityBase.GetDatabaseValue(@productCategoryID)));
			parameters.Add(new SqlParameter("@ServiceCategoryID", EntityBase.GetDatabaseValue(@serviceCategoryID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_AmountRuleProduct from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_AmountRuleProduct(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_AmountRuleProduct(@iD, helper);
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
		/// Deletes a Mall_AmountRuleProduct from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_AmountRuleProduct(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_AmountRuleProduct]
WHERE 
	[Mall_AmountRuleProduct].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_AmountRuleProduct object.
		/// </summary>
		/// <returns>The newly created Mall_AmountRuleProduct object.</returns>
		public static Mall_AmountRuleProduct CreateMall_AmountRuleProduct()
		{
			return InitializeNew<Mall_AmountRuleProduct>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_AmountRuleProduct by a Mall_AmountRuleProduct's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_AmountRuleProduct</returns>
		public static Mall_AmountRuleProduct GetMall_AmountRuleProduct(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_AmountRuleProduct.SelectFieldList + @"
FROM [dbo].[Mall_AmountRuleProduct] 
WHERE 
	[Mall_AmountRuleProduct].[ID] = @ID " + Mall_AmountRuleProduct.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_AmountRuleProduct>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_AmountRuleProduct by a Mall_AmountRuleProduct's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_AmountRuleProduct</returns>
		public static Mall_AmountRuleProduct GetMall_AmountRuleProduct(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_AmountRuleProduct.SelectFieldList + @"
FROM [dbo].[Mall_AmountRuleProduct] 
WHERE 
	[Mall_AmountRuleProduct].[ID] = @ID " + Mall_AmountRuleProduct.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_AmountRuleProduct>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleProduct objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_AmountRuleProduct objects.</returns>
		public static EntityList<Mall_AmountRuleProduct> GetMall_AmountRuleProducts()
		{
			string commandText = @"
SELECT " + Mall_AmountRuleProduct.SelectFieldList + "FROM [dbo].[Mall_AmountRuleProduct] " + Mall_AmountRuleProduct.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_AmountRuleProduct>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_AmountRuleProduct objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_AmountRuleProduct objects.</returns>
        public static EntityList<Mall_AmountRuleProduct> GetMall_AmountRuleProducts(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_AmountRuleProduct>(SelectFieldList, "FROM [dbo].[Mall_AmountRuleProduct]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_AmountRuleProduct objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_AmountRuleProduct objects.</returns>
        public static EntityList<Mall_AmountRuleProduct> GetMall_AmountRuleProducts(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_AmountRuleProduct>(SelectFieldList, "FROM [dbo].[Mall_AmountRuleProduct]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleProduct objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_AmountRuleProduct objects.</returns>
		protected static EntityList<Mall_AmountRuleProduct> GetMall_AmountRuleProducts(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_AmountRuleProducts(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleProduct objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_AmountRuleProduct objects.</returns>
		protected static EntityList<Mall_AmountRuleProduct> GetMall_AmountRuleProducts(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_AmountRuleProducts(string.Empty, where, parameters, Mall_AmountRuleProduct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleProduct objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_AmountRuleProduct objects.</returns>
		protected static EntityList<Mall_AmountRuleProduct> GetMall_AmountRuleProducts(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_AmountRuleProducts(prefix, where, parameters, Mall_AmountRuleProduct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleProduct objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_AmountRuleProduct objects.</returns>
		protected static EntityList<Mall_AmountRuleProduct> GetMall_AmountRuleProducts(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_AmountRuleProducts(string.Empty, where, parameters, Mall_AmountRuleProduct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleProduct objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_AmountRuleProduct objects.</returns>
		protected static EntityList<Mall_AmountRuleProduct> GetMall_AmountRuleProducts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_AmountRuleProducts(prefix, where, parameters, Mall_AmountRuleProduct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleProduct objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_AmountRuleProduct objects.</returns>
		protected static EntityList<Mall_AmountRuleProduct> GetMall_AmountRuleProducts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_AmountRuleProduct.SelectFieldList + "FROM [dbo].[Mall_AmountRuleProduct] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_AmountRuleProduct>(reader);
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
        protected static EntityList<Mall_AmountRuleProduct> GetMall_AmountRuleProducts(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_AmountRuleProduct>(SelectFieldList, "FROM [dbo].[Mall_AmountRuleProduct] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_AmountRuleProduct objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_AmountRuleProductCount()
        {
            return GetMall_AmountRuleProductCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_AmountRuleProduct objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_AmountRuleProductCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_AmountRuleProduct] " + where;

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
		public static partial class Mall_AmountRuleProduct_Properties
		{
			public const string ID = "ID";
			public const string AmountRuleID = "AmountRuleID";
			public const string ProductID = "ProductID";
			public const string ServiceID = "ServiceID";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string BusinessID = "BusinessID";
			public const string ProductCategoryID = "ProductCategoryID";
			public const string ServiceCategoryID = "ServiceCategoryID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"AmountRuleID" , "int:"},
    			 {"ProductID" , "int:"},
    			 {"ServiceID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"BusinessID" , "int:"},
    			 {"ProductCategoryID" , "int:"},
    			 {"ServiceCategoryID" , "int:"},
            };
		}
		#endregion
	}
}
