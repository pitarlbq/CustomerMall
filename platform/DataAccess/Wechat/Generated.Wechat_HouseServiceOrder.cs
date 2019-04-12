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
	/// This object represents the properties and methods of a Wechat_HouseServiceOrder.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_HouseServiceOrder 
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
		private int _serviceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private int _typeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int TypeID
		{
			[DebuggerStepThrough()]
			get { return this._typeID; }
			set 
			{
				if (this._typeID != value) 
				{
					this._typeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("TypeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _addressID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int AddressID
		{
			[DebuggerStepThrough()]
			get { return this._addressID; }
			set 
			{
				if (this._addressID != value) 
				{
					this._addressID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _serviceTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime ServiceTime
		{
			[DebuggerStepThrough()]
			get { return this._serviceTime; }
			set 
			{
				if (this._serviceTime != value) 
				{
					this._serviceTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceTime");
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
		[DataObjectField(false, false, true)]
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
		private decimal _totalCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalCost
		{
			[DebuggerStepThrough()]
			get { return this._totalCost; }
			set 
			{
				if (this._totalCost != value) 
				{
					this._totalCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalCost");
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
		private string _openID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OpenID
		{
			[DebuggerStepThrough()]
			get { return this._openID; }
			set 
			{
				if (this._openID != value) 
				{
					this._openID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OpenID");
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
	[ServiceID] int,
	[TypeID] int,
	[AddressID] int,
	[ServiceTime] datetime,
	[Quantity] int,
	[TotalCost] decimal(18, 2),
	[AddTime] datetime,
	[OpenID] nvarchar(500)
);

INSERT INTO [dbo].[Wechat_HouseServiceOrder] (
	[Wechat_HouseServiceOrder].[ServiceID],
	[Wechat_HouseServiceOrder].[TypeID],
	[Wechat_HouseServiceOrder].[AddressID],
	[Wechat_HouseServiceOrder].[ServiceTime],
	[Wechat_HouseServiceOrder].[Quantity],
	[Wechat_HouseServiceOrder].[TotalCost],
	[Wechat_HouseServiceOrder].[AddTime],
	[Wechat_HouseServiceOrder].[OpenID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[TypeID],
	INSERTED.[AddressID],
	INSERTED.[ServiceTime],
	INSERTED.[Quantity],
	INSERTED.[TotalCost],
	INSERTED.[AddTime],
	INSERTED.[OpenID]
into @table
VALUES ( 
	@ServiceID,
	@TypeID,
	@AddressID,
	@ServiceTime,
	@Quantity,
	@TotalCost,
	@AddTime,
	@OpenID 
); 

SELECT 
	[ID],
	[ServiceID],
	[TypeID],
	[AddressID],
	[ServiceTime],
	[Quantity],
	[TotalCost],
	[AddTime],
	[OpenID] 
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
	[ServiceID] int,
	[TypeID] int,
	[AddressID] int,
	[ServiceTime] datetime,
	[Quantity] int,
	[TotalCost] decimal(18, 2),
	[AddTime] datetime,
	[OpenID] nvarchar(500)
);

UPDATE [dbo].[Wechat_HouseServiceOrder] SET 
	[Wechat_HouseServiceOrder].[ServiceID] = @ServiceID,
	[Wechat_HouseServiceOrder].[TypeID] = @TypeID,
	[Wechat_HouseServiceOrder].[AddressID] = @AddressID,
	[Wechat_HouseServiceOrder].[ServiceTime] = @ServiceTime,
	[Wechat_HouseServiceOrder].[Quantity] = @Quantity,
	[Wechat_HouseServiceOrder].[TotalCost] = @TotalCost,
	[Wechat_HouseServiceOrder].[AddTime] = @AddTime,
	[Wechat_HouseServiceOrder].[OpenID] = @OpenID 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[TypeID],
	INSERTED.[AddressID],
	INSERTED.[ServiceTime],
	INSERTED.[Quantity],
	INSERTED.[TotalCost],
	INSERTED.[AddTime],
	INSERTED.[OpenID]
into @table
WHERE 
	[Wechat_HouseServiceOrder].[ID] = @ID

SELECT 
	[ID],
	[ServiceID],
	[TypeID],
	[AddressID],
	[ServiceTime],
	[Quantity],
	[TotalCost],
	[AddTime],
	[OpenID] 
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
DELETE FROM [dbo].[Wechat_HouseServiceOrder]
WHERE 
	[Wechat_HouseServiceOrder].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_HouseServiceOrder() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_HouseServiceOrder(this.ID));
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
	[Wechat_HouseServiceOrder].[ID],
	[Wechat_HouseServiceOrder].[ServiceID],
	[Wechat_HouseServiceOrder].[TypeID],
	[Wechat_HouseServiceOrder].[AddressID],
	[Wechat_HouseServiceOrder].[ServiceTime],
	[Wechat_HouseServiceOrder].[Quantity],
	[Wechat_HouseServiceOrder].[TotalCost],
	[Wechat_HouseServiceOrder].[AddTime],
	[Wechat_HouseServiceOrder].[OpenID]
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
                return "Wechat_HouseServiceOrder";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_HouseServiceOrder into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="typeID">typeID</param>
		/// <param name="addressID">addressID</param>
		/// <param name="serviceTime">serviceTime</param>
		/// <param name="quantity">quantity</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="openID">openID</param>
		public static void InsertWechat_HouseServiceOrder(int @serviceID, int @typeID, int @addressID, DateTime @serviceTime, int @quantity, decimal @totalCost, DateTime @addTime, string @openID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_HouseServiceOrder(@serviceID, @typeID, @addressID, @serviceTime, @quantity, @totalCost, @addTime, @openID, helper);
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
		/// Insert a Wechat_HouseServiceOrder into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="typeID">typeID</param>
		/// <param name="addressID">addressID</param>
		/// <param name="serviceTime">serviceTime</param>
		/// <param name="quantity">quantity</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="openID">openID</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_HouseServiceOrder(int @serviceID, int @typeID, int @addressID, DateTime @serviceTime, int @quantity, decimal @totalCost, DateTime @addTime, string @openID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceID] int,
	[TypeID] int,
	[AddressID] int,
	[ServiceTime] datetime,
	[Quantity] int,
	[TotalCost] decimal(18, 2),
	[AddTime] datetime,
	[OpenID] nvarchar(500)
);

INSERT INTO [dbo].[Wechat_HouseServiceOrder] (
	[Wechat_HouseServiceOrder].[ServiceID],
	[Wechat_HouseServiceOrder].[TypeID],
	[Wechat_HouseServiceOrder].[AddressID],
	[Wechat_HouseServiceOrder].[ServiceTime],
	[Wechat_HouseServiceOrder].[Quantity],
	[Wechat_HouseServiceOrder].[TotalCost],
	[Wechat_HouseServiceOrder].[AddTime],
	[Wechat_HouseServiceOrder].[OpenID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[TypeID],
	INSERTED.[AddressID],
	INSERTED.[ServiceTime],
	INSERTED.[Quantity],
	INSERTED.[TotalCost],
	INSERTED.[AddTime],
	INSERTED.[OpenID]
into @table
VALUES ( 
	@ServiceID,
	@TypeID,
	@AddressID,
	@ServiceTime,
	@Quantity,
	@TotalCost,
	@AddTime,
	@OpenID 
); 

SELECT 
	[ID],
	[ServiceID],
	[TypeID],
	[AddressID],
	[ServiceTime],
	[Quantity],
	[TotalCost],
	[AddTime],
	[OpenID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@TypeID", EntityBase.GetDatabaseValue(@typeID)));
			parameters.Add(new SqlParameter("@AddressID", EntityBase.GetDatabaseValue(@addressID)));
			parameters.Add(new SqlParameter("@ServiceTime", EntityBase.GetDatabaseValue(@serviceTime)));
			parameters.Add(new SqlParameter("@Quantity", EntityBase.GetDatabaseValue(@quantity)));
			parameters.Add(new SqlParameter("@TotalCost", EntityBase.GetDatabaseValue(@totalCost)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_HouseServiceOrder into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="typeID">typeID</param>
		/// <param name="addressID">addressID</param>
		/// <param name="serviceTime">serviceTime</param>
		/// <param name="quantity">quantity</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="openID">openID</param>
		public static void UpdateWechat_HouseServiceOrder(int @iD, int @serviceID, int @typeID, int @addressID, DateTime @serviceTime, int @quantity, decimal @totalCost, DateTime @addTime, string @openID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_HouseServiceOrder(@iD, @serviceID, @typeID, @addressID, @serviceTime, @quantity, @totalCost, @addTime, @openID, helper);
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
		/// Updates a Wechat_HouseServiceOrder into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="typeID">typeID</param>
		/// <param name="addressID">addressID</param>
		/// <param name="serviceTime">serviceTime</param>
		/// <param name="quantity">quantity</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="openID">openID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_HouseServiceOrder(int @iD, int @serviceID, int @typeID, int @addressID, DateTime @serviceTime, int @quantity, decimal @totalCost, DateTime @addTime, string @openID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceID] int,
	[TypeID] int,
	[AddressID] int,
	[ServiceTime] datetime,
	[Quantity] int,
	[TotalCost] decimal(18, 2),
	[AddTime] datetime,
	[OpenID] nvarchar(500)
);

UPDATE [dbo].[Wechat_HouseServiceOrder] SET 
	[Wechat_HouseServiceOrder].[ServiceID] = @ServiceID,
	[Wechat_HouseServiceOrder].[TypeID] = @TypeID,
	[Wechat_HouseServiceOrder].[AddressID] = @AddressID,
	[Wechat_HouseServiceOrder].[ServiceTime] = @ServiceTime,
	[Wechat_HouseServiceOrder].[Quantity] = @Quantity,
	[Wechat_HouseServiceOrder].[TotalCost] = @TotalCost,
	[Wechat_HouseServiceOrder].[AddTime] = @AddTime,
	[Wechat_HouseServiceOrder].[OpenID] = @OpenID 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[TypeID],
	INSERTED.[AddressID],
	INSERTED.[ServiceTime],
	INSERTED.[Quantity],
	INSERTED.[TotalCost],
	INSERTED.[AddTime],
	INSERTED.[OpenID]
into @table
WHERE 
	[Wechat_HouseServiceOrder].[ID] = @ID

SELECT 
	[ID],
	[ServiceID],
	[TypeID],
	[AddressID],
	[ServiceTime],
	[Quantity],
	[TotalCost],
	[AddTime],
	[OpenID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@TypeID", EntityBase.GetDatabaseValue(@typeID)));
			parameters.Add(new SqlParameter("@AddressID", EntityBase.GetDatabaseValue(@addressID)));
			parameters.Add(new SqlParameter("@ServiceTime", EntityBase.GetDatabaseValue(@serviceTime)));
			parameters.Add(new SqlParameter("@Quantity", EntityBase.GetDatabaseValue(@quantity)));
			parameters.Add(new SqlParameter("@TotalCost", EntityBase.GetDatabaseValue(@totalCost)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_HouseServiceOrder from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_HouseServiceOrder(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_HouseServiceOrder(@iD, helper);
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
		/// Deletes a Wechat_HouseServiceOrder from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_HouseServiceOrder(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_HouseServiceOrder]
WHERE 
	[Wechat_HouseServiceOrder].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_HouseServiceOrder object.
		/// </summary>
		/// <returns>The newly created Wechat_HouseServiceOrder object.</returns>
		public static Wechat_HouseServiceOrder CreateWechat_HouseServiceOrder()
		{
			return InitializeNew<Wechat_HouseServiceOrder>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_HouseServiceOrder by a Wechat_HouseServiceOrder's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_HouseServiceOrder</returns>
		public static Wechat_HouseServiceOrder GetWechat_HouseServiceOrder(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_HouseServiceOrder.SelectFieldList + @"
FROM [dbo].[Wechat_HouseServiceOrder] 
WHERE 
	[Wechat_HouseServiceOrder].[ID] = @ID " + Wechat_HouseServiceOrder.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_HouseServiceOrder>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_HouseServiceOrder by a Wechat_HouseServiceOrder's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_HouseServiceOrder</returns>
		public static Wechat_HouseServiceOrder GetWechat_HouseServiceOrder(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_HouseServiceOrder.SelectFieldList + @"
FROM [dbo].[Wechat_HouseServiceOrder] 
WHERE 
	[Wechat_HouseServiceOrder].[ID] = @ID " + Wechat_HouseServiceOrder.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_HouseServiceOrder>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceOrder objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_HouseServiceOrder objects.</returns>
		public static EntityList<Wechat_HouseServiceOrder> GetWechat_HouseServiceOrders()
		{
			string commandText = @"
SELECT " + Wechat_HouseServiceOrder.SelectFieldList + "FROM [dbo].[Wechat_HouseServiceOrder] " + Wechat_HouseServiceOrder.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_HouseServiceOrder>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_HouseServiceOrder objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_HouseServiceOrder objects.</returns>
        public static EntityList<Wechat_HouseServiceOrder> GetWechat_HouseServiceOrders(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_HouseServiceOrder>(SelectFieldList, "FROM [dbo].[Wechat_HouseServiceOrder]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_HouseServiceOrder objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_HouseServiceOrder objects.</returns>
        public static EntityList<Wechat_HouseServiceOrder> GetWechat_HouseServiceOrders(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_HouseServiceOrder>(SelectFieldList, "FROM [dbo].[Wechat_HouseServiceOrder]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceOrder objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceOrder objects.</returns>
		protected static EntityList<Wechat_HouseServiceOrder> GetWechat_HouseServiceOrders(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_HouseServiceOrders(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceOrder objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceOrder objects.</returns>
		protected static EntityList<Wechat_HouseServiceOrder> GetWechat_HouseServiceOrders(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_HouseServiceOrders(string.Empty, where, parameters, Wechat_HouseServiceOrder.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceOrder objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceOrder objects.</returns>
		protected static EntityList<Wechat_HouseServiceOrder> GetWechat_HouseServiceOrders(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_HouseServiceOrders(prefix, where, parameters, Wechat_HouseServiceOrder.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceOrder objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceOrder objects.</returns>
		protected static EntityList<Wechat_HouseServiceOrder> GetWechat_HouseServiceOrders(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_HouseServiceOrders(string.Empty, where, parameters, Wechat_HouseServiceOrder.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceOrder objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceOrder objects.</returns>
		protected static EntityList<Wechat_HouseServiceOrder> GetWechat_HouseServiceOrders(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_HouseServiceOrders(prefix, where, parameters, Wechat_HouseServiceOrder.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceOrder objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceOrder objects.</returns>
		protected static EntityList<Wechat_HouseServiceOrder> GetWechat_HouseServiceOrders(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_HouseServiceOrder.SelectFieldList + "FROM [dbo].[Wechat_HouseServiceOrder] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_HouseServiceOrder>(reader);
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
        protected static EntityList<Wechat_HouseServiceOrder> GetWechat_HouseServiceOrders(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_HouseServiceOrder>(SelectFieldList, "FROM [dbo].[Wechat_HouseServiceOrder] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_HouseServiceOrder objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_HouseServiceOrderCount()
        {
            return GetWechat_HouseServiceOrderCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_HouseServiceOrder objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_HouseServiceOrderCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_HouseServiceOrder] " + where;

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
		public static partial class Wechat_HouseServiceOrder_Properties
		{
			public const string ID = "ID";
			public const string ServiceID = "ServiceID";
			public const string TypeID = "TypeID";
			public const string AddressID = "AddressID";
			public const string ServiceTime = "ServiceTime";
			public const string Quantity = "Quantity";
			public const string TotalCost = "TotalCost";
			public const string AddTime = "AddTime";
			public const string OpenID = "OpenID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ServiceID" , "int:"},
    			 {"TypeID" , "int:"},
    			 {"AddressID" , "int:"},
    			 {"ServiceTime" , "DateTime:"},
    			 {"Quantity" , "int:"},
    			 {"TotalCost" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"OpenID" , "string:"},
            };
		}
		#endregion
	}
}
