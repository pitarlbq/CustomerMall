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
	/// This object represents the properties and methods of a Mall_ProductPinUser.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_ProductPinUser 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _iD = int.MinValue;
		/// <summary>
		/// 1-进行中 2-待付款 3-已付款 4-已关闭
		/// </summary>
        [Description("1-进行中 2-待付款 3-已付款 4-已关闭")]
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
		private DateTime _startTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime StartTime
		{
			[DebuggerStepThrough()]
			get { return this._startTime; }
			set 
			{
				if (this._startTime != value) 
				{
					this._startTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("StartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _endTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime EndTime
		{
			[DebuggerStepThrough()]
			get { return this._endTime; }
			set 
			{
				if (this._endTime != value) 
				{
					this._endTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _pinSalePrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal PinSalePrice
		{
			[DebuggerStepThrough()]
			get { return this._pinSalePrice; }
			set 
			{
				if (this._pinSalePrice != value) 
				{
					this._pinSalePrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("PinSalePrice");
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
		[DataObjectField(false, false, false)]
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
		private int _organiserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OrganiserID
		{
			[DebuggerStepThrough()]
			get { return this._organiserID; }
			set 
			{
				if (this._organiserID != value) 
				{
					this._organiserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrganiserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _status = int.MinValue;
		/// <summary>
		/// 1-进行中 2-待付款 3-已付款 4-已关闭
		/// </summary>
        [Description("1-进行中 2-待付款 3-已付款 4-已关闭")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Status
		{
			[DebuggerStepThrough()]
			get { return this._status; }
			set 
			{
				if (this._status != value) 
				{
					this._status = value;
					this.IsDirty = true;	
					OnPropertyChanged("Status");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _updateTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime UpdateTime
		{
			[DebuggerStepThrough()]
			get { return this._updateTime; }
			set 
			{
				if (this._updateTime != value) 
				{
					this._updateTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("UpdateTime");
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
	[StartTime] datetime,
	[EndTime] datetime,
	[PinSalePrice] decimal(18, 2),
	[VariantID] int,
	[Quantity] int,
	[UserID] int,
	[AddTime] datetime,
	[OrganiserID] int,
	[Status] int,
	[UpdateTime] datetime
);

INSERT INTO [dbo].[Mall_ProductPinUser] (
	[Mall_ProductPinUser].[ProductID],
	[Mall_ProductPinUser].[StartTime],
	[Mall_ProductPinUser].[EndTime],
	[Mall_ProductPinUser].[PinSalePrice],
	[Mall_ProductPinUser].[VariantID],
	[Mall_ProductPinUser].[Quantity],
	[Mall_ProductPinUser].[UserID],
	[Mall_ProductPinUser].[AddTime],
	[Mall_ProductPinUser].[OrganiserID],
	[Mall_ProductPinUser].[Status],
	[Mall_ProductPinUser].[UpdateTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[PinSalePrice],
	INSERTED.[VariantID],
	INSERTED.[Quantity],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[OrganiserID],
	INSERTED.[Status],
	INSERTED.[UpdateTime]
into @table
VALUES ( 
	@ProductID,
	@StartTime,
	@EndTime,
	@PinSalePrice,
	@VariantID,
	@Quantity,
	@UserID,
	@AddTime,
	@OrganiserID,
	@Status,
	@UpdateTime 
); 

SELECT 
	[ID],
	[ProductID],
	[StartTime],
	[EndTime],
	[PinSalePrice],
	[VariantID],
	[Quantity],
	[UserID],
	[AddTime],
	[OrganiserID],
	[Status],
	[UpdateTime] 
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
	[StartTime] datetime,
	[EndTime] datetime,
	[PinSalePrice] decimal(18, 2),
	[VariantID] int,
	[Quantity] int,
	[UserID] int,
	[AddTime] datetime,
	[OrganiserID] int,
	[Status] int,
	[UpdateTime] datetime
);

UPDATE [dbo].[Mall_ProductPinUser] SET 
	[Mall_ProductPinUser].[ProductID] = @ProductID,
	[Mall_ProductPinUser].[StartTime] = @StartTime,
	[Mall_ProductPinUser].[EndTime] = @EndTime,
	[Mall_ProductPinUser].[PinSalePrice] = @PinSalePrice,
	[Mall_ProductPinUser].[VariantID] = @VariantID,
	[Mall_ProductPinUser].[Quantity] = @Quantity,
	[Mall_ProductPinUser].[UserID] = @UserID,
	[Mall_ProductPinUser].[AddTime] = @AddTime,
	[Mall_ProductPinUser].[OrganiserID] = @OrganiserID,
	[Mall_ProductPinUser].[Status] = @Status,
	[Mall_ProductPinUser].[UpdateTime] = @UpdateTime 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[PinSalePrice],
	INSERTED.[VariantID],
	INSERTED.[Quantity],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[OrganiserID],
	INSERTED.[Status],
	INSERTED.[UpdateTime]
into @table
WHERE 
	[Mall_ProductPinUser].[ID] = @ID

SELECT 
	[ID],
	[ProductID],
	[StartTime],
	[EndTime],
	[PinSalePrice],
	[VariantID],
	[Quantity],
	[UserID],
	[AddTime],
	[OrganiserID],
	[Status],
	[UpdateTime] 
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
DELETE FROM [dbo].[Mall_ProductPinUser]
WHERE 
	[Mall_ProductPinUser].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_ProductPinUser() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_ProductPinUser(this.ID));
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
	[Mall_ProductPinUser].[ID],
	[Mall_ProductPinUser].[ProductID],
	[Mall_ProductPinUser].[StartTime],
	[Mall_ProductPinUser].[EndTime],
	[Mall_ProductPinUser].[PinSalePrice],
	[Mall_ProductPinUser].[VariantID],
	[Mall_ProductPinUser].[Quantity],
	[Mall_ProductPinUser].[UserID],
	[Mall_ProductPinUser].[AddTime],
	[Mall_ProductPinUser].[OrganiserID],
	[Mall_ProductPinUser].[Status],
	[Mall_ProductPinUser].[UpdateTime]
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
                return "Mall_ProductPinUser";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_ProductPinUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productID">productID</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="pinSalePrice">pinSalePrice</param>
		/// <param name="variantID">variantID</param>
		/// <param name="quantity">quantity</param>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="organiserID">organiserID</param>
		/// <param name="status">status</param>
		/// <param name="updateTime">updateTime</param>
		public static void InsertMall_ProductPinUser(int @productID, DateTime @startTime, DateTime @endTime, decimal @pinSalePrice, int @variantID, int @quantity, int @userID, DateTime @addTime, int @organiserID, int @status, DateTime @updateTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_ProductPinUser(@productID, @startTime, @endTime, @pinSalePrice, @variantID, @quantity, @userID, @addTime, @organiserID, @status, @updateTime, helper);
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
		/// Insert a Mall_ProductPinUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productID">productID</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="pinSalePrice">pinSalePrice</param>
		/// <param name="variantID">variantID</param>
		/// <param name="quantity">quantity</param>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="organiserID">organiserID</param>
		/// <param name="status">status</param>
		/// <param name="updateTime">updateTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_ProductPinUser(int @productID, DateTime @startTime, DateTime @endTime, decimal @pinSalePrice, int @variantID, int @quantity, int @userID, DateTime @addTime, int @organiserID, int @status, DateTime @updateTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProductID] int,
	[StartTime] datetime,
	[EndTime] datetime,
	[PinSalePrice] decimal(18, 2),
	[VariantID] int,
	[Quantity] int,
	[UserID] int,
	[AddTime] datetime,
	[OrganiserID] int,
	[Status] int,
	[UpdateTime] datetime
);

INSERT INTO [dbo].[Mall_ProductPinUser] (
	[Mall_ProductPinUser].[ProductID],
	[Mall_ProductPinUser].[StartTime],
	[Mall_ProductPinUser].[EndTime],
	[Mall_ProductPinUser].[PinSalePrice],
	[Mall_ProductPinUser].[VariantID],
	[Mall_ProductPinUser].[Quantity],
	[Mall_ProductPinUser].[UserID],
	[Mall_ProductPinUser].[AddTime],
	[Mall_ProductPinUser].[OrganiserID],
	[Mall_ProductPinUser].[Status],
	[Mall_ProductPinUser].[UpdateTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[PinSalePrice],
	INSERTED.[VariantID],
	INSERTED.[Quantity],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[OrganiserID],
	INSERTED.[Status],
	INSERTED.[UpdateTime]
into @table
VALUES ( 
	@ProductID,
	@StartTime,
	@EndTime,
	@PinSalePrice,
	@VariantID,
	@Quantity,
	@UserID,
	@AddTime,
	@OrganiserID,
	@Status,
	@UpdateTime 
); 

SELECT 
	[ID],
	[ProductID],
	[StartTime],
	[EndTime],
	[PinSalePrice],
	[VariantID],
	[Quantity],
	[UserID],
	[AddTime],
	[OrganiserID],
	[Status],
	[UpdateTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@PinSalePrice", EntityBase.GetDatabaseValue(@pinSalePrice)));
			parameters.Add(new SqlParameter("@VariantID", EntityBase.GetDatabaseValue(@variantID)));
			parameters.Add(new SqlParameter("@Quantity", EntityBase.GetDatabaseValue(@quantity)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@OrganiserID", EntityBase.GetDatabaseValue(@organiserID)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@UpdateTime", EntityBase.GetDatabaseValue(@updateTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_ProductPinUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="productID">productID</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="pinSalePrice">pinSalePrice</param>
		/// <param name="variantID">variantID</param>
		/// <param name="quantity">quantity</param>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="organiserID">organiserID</param>
		/// <param name="status">status</param>
		/// <param name="updateTime">updateTime</param>
		public static void UpdateMall_ProductPinUser(int @iD, int @productID, DateTime @startTime, DateTime @endTime, decimal @pinSalePrice, int @variantID, int @quantity, int @userID, DateTime @addTime, int @organiserID, int @status, DateTime @updateTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_ProductPinUser(@iD, @productID, @startTime, @endTime, @pinSalePrice, @variantID, @quantity, @userID, @addTime, @organiserID, @status, @updateTime, helper);
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
		/// Updates a Mall_ProductPinUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="productID">productID</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="pinSalePrice">pinSalePrice</param>
		/// <param name="variantID">variantID</param>
		/// <param name="quantity">quantity</param>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="organiserID">organiserID</param>
		/// <param name="status">status</param>
		/// <param name="updateTime">updateTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_ProductPinUser(int @iD, int @productID, DateTime @startTime, DateTime @endTime, decimal @pinSalePrice, int @variantID, int @quantity, int @userID, DateTime @addTime, int @organiserID, int @status, DateTime @updateTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProductID] int,
	[StartTime] datetime,
	[EndTime] datetime,
	[PinSalePrice] decimal(18, 2),
	[VariantID] int,
	[Quantity] int,
	[UserID] int,
	[AddTime] datetime,
	[OrganiserID] int,
	[Status] int,
	[UpdateTime] datetime
);

UPDATE [dbo].[Mall_ProductPinUser] SET 
	[Mall_ProductPinUser].[ProductID] = @ProductID,
	[Mall_ProductPinUser].[StartTime] = @StartTime,
	[Mall_ProductPinUser].[EndTime] = @EndTime,
	[Mall_ProductPinUser].[PinSalePrice] = @PinSalePrice,
	[Mall_ProductPinUser].[VariantID] = @VariantID,
	[Mall_ProductPinUser].[Quantity] = @Quantity,
	[Mall_ProductPinUser].[UserID] = @UserID,
	[Mall_ProductPinUser].[AddTime] = @AddTime,
	[Mall_ProductPinUser].[OrganiserID] = @OrganiserID,
	[Mall_ProductPinUser].[Status] = @Status,
	[Mall_ProductPinUser].[UpdateTime] = @UpdateTime 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[PinSalePrice],
	INSERTED.[VariantID],
	INSERTED.[Quantity],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[OrganiserID],
	INSERTED.[Status],
	INSERTED.[UpdateTime]
into @table
WHERE 
	[Mall_ProductPinUser].[ID] = @ID

SELECT 
	[ID],
	[ProductID],
	[StartTime],
	[EndTime],
	[PinSalePrice],
	[VariantID],
	[Quantity],
	[UserID],
	[AddTime],
	[OrganiserID],
	[Status],
	[UpdateTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@PinSalePrice", EntityBase.GetDatabaseValue(@pinSalePrice)));
			parameters.Add(new SqlParameter("@VariantID", EntityBase.GetDatabaseValue(@variantID)));
			parameters.Add(new SqlParameter("@Quantity", EntityBase.GetDatabaseValue(@quantity)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@OrganiserID", EntityBase.GetDatabaseValue(@organiserID)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@UpdateTime", EntityBase.GetDatabaseValue(@updateTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_ProductPinUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_ProductPinUser(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_ProductPinUser(@iD, helper);
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
		/// Deletes a Mall_ProductPinUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_ProductPinUser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_ProductPinUser]
WHERE 
	[Mall_ProductPinUser].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_ProductPinUser object.
		/// </summary>
		/// <returns>The newly created Mall_ProductPinUser object.</returns>
		public static Mall_ProductPinUser CreateMall_ProductPinUser()
		{
			return InitializeNew<Mall_ProductPinUser>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_ProductPinUser by a Mall_ProductPinUser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_ProductPinUser</returns>
		public static Mall_ProductPinUser GetMall_ProductPinUser(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_ProductPinUser.SelectFieldList + @"
FROM [dbo].[Mall_ProductPinUser] 
WHERE 
	[Mall_ProductPinUser].[ID] = @ID " + Mall_ProductPinUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ProductPinUser>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_ProductPinUser by a Mall_ProductPinUser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_ProductPinUser</returns>
		public static Mall_ProductPinUser GetMall_ProductPinUser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_ProductPinUser.SelectFieldList + @"
FROM [dbo].[Mall_ProductPinUser] 
WHERE 
	[Mall_ProductPinUser].[ID] = @ID " + Mall_ProductPinUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ProductPinUser>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductPinUser objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_ProductPinUser objects.</returns>
		public static EntityList<Mall_ProductPinUser> GetMall_ProductPinUsers()
		{
			string commandText = @"
SELECT " + Mall_ProductPinUser.SelectFieldList + "FROM [dbo].[Mall_ProductPinUser] " + Mall_ProductPinUser.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_ProductPinUser>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_ProductPinUser objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ProductPinUser objects.</returns>
        public static EntityList<Mall_ProductPinUser> GetMall_ProductPinUsers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ProductPinUser>(SelectFieldList, "FROM [dbo].[Mall_ProductPinUser]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_ProductPinUser objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ProductPinUser objects.</returns>
        public static EntityList<Mall_ProductPinUser> GetMall_ProductPinUsers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ProductPinUser>(SelectFieldList, "FROM [dbo].[Mall_ProductPinUser]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_ProductPinUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ProductPinUser objects.</returns>
		protected static EntityList<Mall_ProductPinUser> GetMall_ProductPinUsers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ProductPinUsers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductPinUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ProductPinUser objects.</returns>
		protected static EntityList<Mall_ProductPinUser> GetMall_ProductPinUsers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ProductPinUsers(string.Empty, where, parameters, Mall_ProductPinUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductPinUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ProductPinUser objects.</returns>
		protected static EntityList<Mall_ProductPinUser> GetMall_ProductPinUsers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ProductPinUsers(prefix, where, parameters, Mall_ProductPinUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductPinUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ProductPinUser objects.</returns>
		protected static EntityList<Mall_ProductPinUser> GetMall_ProductPinUsers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ProductPinUsers(string.Empty, where, parameters, Mall_ProductPinUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductPinUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ProductPinUser objects.</returns>
		protected static EntityList<Mall_ProductPinUser> GetMall_ProductPinUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ProductPinUsers(prefix, where, parameters, Mall_ProductPinUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductPinUser objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ProductPinUser objects.</returns>
		protected static EntityList<Mall_ProductPinUser> GetMall_ProductPinUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_ProductPinUser.SelectFieldList + "FROM [dbo].[Mall_ProductPinUser] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_ProductPinUser>(reader);
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
        protected static EntityList<Mall_ProductPinUser> GetMall_ProductPinUsers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ProductPinUser>(SelectFieldList, "FROM [dbo].[Mall_ProductPinUser] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_ProductPinUser objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ProductPinUserCount()
        {
            return GetMall_ProductPinUserCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_ProductPinUser objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ProductPinUserCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_ProductPinUser] " + where;

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
		public static partial class Mall_ProductPinUser_Properties
		{
			public const string ID = "ID";
			public const string ProductID = "ProductID";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string PinSalePrice = "PinSalePrice";
			public const string VariantID = "VariantID";
			public const string Quantity = "Quantity";
			public const string UserID = "UserID";
			public const string AddTime = "AddTime";
			public const string OrganiserID = "OrganiserID";
			public const string Status = "Status";
			public const string UpdateTime = "UpdateTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:1-进行中 2-待付款 3-已付款 4-已关闭"},
    			 {"ProductID" , "int:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"PinSalePrice" , "decimal:"},
    			 {"VariantID" , "int:"},
    			 {"Quantity" , "int:"},
    			 {"UserID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"OrganiserID" , "int:"},
    			 {"Status" , "int:1-进行中 2-待付款 3-已付款 4-已关闭"},
    			 {"UpdateTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
