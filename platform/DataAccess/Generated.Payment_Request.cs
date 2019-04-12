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
	/// This object represents the properties and methods of a Payment_Request.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Payment_Request 
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
		private int _roomFeeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RoomFeeID
		{
			[DebuggerStepThrough()]
			get { return this._roomFeeID; }
			set 
			{
				if (this._roomFeeID != value) 
				{
					this._roomFeeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomFeeID");
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
		private int _paymentID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PaymentID
		{
			[DebuggerStepThrough()]
			get { return this._paymentID; }
			set 
			{
				if (this._paymentID != value) 
				{
					this._paymentID = value;
					this.IsDirty = true;	
					OnPropertyChanged("PaymentID");
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
		private int _orderID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OrderID
		{
			[DebuggerStepThrough()]
			get { return this._orderID; }
			set 
			{
				if (this._orderID != value) 
				{
					this._orderID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderID");
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
	[RoomFeeID] int,
	[EndTime] datetime,
	[PaymentID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(200),
	[TotalCost] decimal(18, 2),
	[OrderID] int
);

INSERT INTO [dbo].[Payment_Request] (
	[Payment_Request].[RoomFeeID],
	[Payment_Request].[EndTime],
	[Payment_Request].[PaymentID],
	[Payment_Request].[AddTime],
	[Payment_Request].[AddMan],
	[Payment_Request].[TotalCost],
	[Payment_Request].[OrderID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomFeeID],
	INSERTED.[EndTime],
	INSERTED.[PaymentID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[TotalCost],
	INSERTED.[OrderID]
into @table
VALUES ( 
	@RoomFeeID,
	@EndTime,
	@PaymentID,
	@AddTime,
	@AddMan,
	@TotalCost,
	@OrderID 
); 

SELECT 
	[ID],
	[RoomFeeID],
	[EndTime],
	[PaymentID],
	[AddTime],
	[AddMan],
	[TotalCost],
	[OrderID] 
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
	[RoomFeeID] int,
	[EndTime] datetime,
	[PaymentID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(200),
	[TotalCost] decimal(18, 2),
	[OrderID] int
);

UPDATE [dbo].[Payment_Request] SET 
	[Payment_Request].[RoomFeeID] = @RoomFeeID,
	[Payment_Request].[EndTime] = @EndTime,
	[Payment_Request].[PaymentID] = @PaymentID,
	[Payment_Request].[AddTime] = @AddTime,
	[Payment_Request].[AddMan] = @AddMan,
	[Payment_Request].[TotalCost] = @TotalCost,
	[Payment_Request].[OrderID] = @OrderID 
output 
	INSERTED.[ID],
	INSERTED.[RoomFeeID],
	INSERTED.[EndTime],
	INSERTED.[PaymentID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[TotalCost],
	INSERTED.[OrderID]
into @table
WHERE 
	[Payment_Request].[ID] = @ID

SELECT 
	[ID],
	[RoomFeeID],
	[EndTime],
	[PaymentID],
	[AddTime],
	[AddMan],
	[TotalCost],
	[OrderID] 
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
DELETE FROM [dbo].[Payment_Request]
WHERE 
	[Payment_Request].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Payment_Request() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetPayment_Request(this.ID));
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
	[Payment_Request].[ID],
	[Payment_Request].[RoomFeeID],
	[Payment_Request].[EndTime],
	[Payment_Request].[PaymentID],
	[Payment_Request].[AddTime],
	[Payment_Request].[AddMan],
	[Payment_Request].[TotalCost],
	[Payment_Request].[OrderID]
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
                return "Payment_Request";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Payment_Request into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomFeeID">roomFeeID</param>
		/// <param name="endTime">endTime</param>
		/// <param name="paymentID">paymentID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="orderID">orderID</param>
		public static void InsertPayment_Request(int @roomFeeID, DateTime @endTime, int @paymentID, DateTime @addTime, string @addMan, decimal @totalCost, int @orderID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertPayment_Request(@roomFeeID, @endTime, @paymentID, @addTime, @addMan, @totalCost, @orderID, helper);
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
		/// Insert a Payment_Request into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomFeeID">roomFeeID</param>
		/// <param name="endTime">endTime</param>
		/// <param name="paymentID">paymentID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="orderID">orderID</param>
		/// <param name="helper">helper</param>
		internal static void InsertPayment_Request(int @roomFeeID, DateTime @endTime, int @paymentID, DateTime @addTime, string @addMan, decimal @totalCost, int @orderID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomFeeID] int,
	[EndTime] datetime,
	[PaymentID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(200),
	[TotalCost] decimal(18, 2),
	[OrderID] int
);

INSERT INTO [dbo].[Payment_Request] (
	[Payment_Request].[RoomFeeID],
	[Payment_Request].[EndTime],
	[Payment_Request].[PaymentID],
	[Payment_Request].[AddTime],
	[Payment_Request].[AddMan],
	[Payment_Request].[TotalCost],
	[Payment_Request].[OrderID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomFeeID],
	INSERTED.[EndTime],
	INSERTED.[PaymentID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[TotalCost],
	INSERTED.[OrderID]
into @table
VALUES ( 
	@RoomFeeID,
	@EndTime,
	@PaymentID,
	@AddTime,
	@AddMan,
	@TotalCost,
	@OrderID 
); 

SELECT 
	[ID],
	[RoomFeeID],
	[EndTime],
	[PaymentID],
	[AddTime],
	[AddMan],
	[TotalCost],
	[OrderID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoomFeeID", EntityBase.GetDatabaseValue(@roomFeeID)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@PaymentID", EntityBase.GetDatabaseValue(@paymentID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@TotalCost", EntityBase.GetDatabaseValue(@totalCost)));
			parameters.Add(new SqlParameter("@OrderID", EntityBase.GetDatabaseValue(@orderID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Payment_Request into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomFeeID">roomFeeID</param>
		/// <param name="endTime">endTime</param>
		/// <param name="paymentID">paymentID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="orderID">orderID</param>
		public static void UpdatePayment_Request(int @iD, int @roomFeeID, DateTime @endTime, int @paymentID, DateTime @addTime, string @addMan, decimal @totalCost, int @orderID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdatePayment_Request(@iD, @roomFeeID, @endTime, @paymentID, @addTime, @addMan, @totalCost, @orderID, helper);
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
		/// Updates a Payment_Request into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomFeeID">roomFeeID</param>
		/// <param name="endTime">endTime</param>
		/// <param name="paymentID">paymentID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="orderID">orderID</param>
		/// <param name="helper">helper</param>
		internal static void UpdatePayment_Request(int @iD, int @roomFeeID, DateTime @endTime, int @paymentID, DateTime @addTime, string @addMan, decimal @totalCost, int @orderID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomFeeID] int,
	[EndTime] datetime,
	[PaymentID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(200),
	[TotalCost] decimal(18, 2),
	[OrderID] int
);

UPDATE [dbo].[Payment_Request] SET 
	[Payment_Request].[RoomFeeID] = @RoomFeeID,
	[Payment_Request].[EndTime] = @EndTime,
	[Payment_Request].[PaymentID] = @PaymentID,
	[Payment_Request].[AddTime] = @AddTime,
	[Payment_Request].[AddMan] = @AddMan,
	[Payment_Request].[TotalCost] = @TotalCost,
	[Payment_Request].[OrderID] = @OrderID 
output 
	INSERTED.[ID],
	INSERTED.[RoomFeeID],
	INSERTED.[EndTime],
	INSERTED.[PaymentID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[TotalCost],
	INSERTED.[OrderID]
into @table
WHERE 
	[Payment_Request].[ID] = @ID

SELECT 
	[ID],
	[RoomFeeID],
	[EndTime],
	[PaymentID],
	[AddTime],
	[AddMan],
	[TotalCost],
	[OrderID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoomFeeID", EntityBase.GetDatabaseValue(@roomFeeID)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@PaymentID", EntityBase.GetDatabaseValue(@paymentID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@TotalCost", EntityBase.GetDatabaseValue(@totalCost)));
			parameters.Add(new SqlParameter("@OrderID", EntityBase.GetDatabaseValue(@orderID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Payment_Request from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeletePayment_Request(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeletePayment_Request(@iD, helper);
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
		/// Deletes a Payment_Request from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeletePayment_Request(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Payment_Request]
WHERE 
	[Payment_Request].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Payment_Request object.
		/// </summary>
		/// <returns>The newly created Payment_Request object.</returns>
		public static Payment_Request CreatePayment_Request()
		{
			return InitializeNew<Payment_Request>();
		}
		
		/// <summary>
		/// Retrieve information for a Payment_Request by a Payment_Request's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Payment_Request</returns>
		public static Payment_Request GetPayment_Request(int @iD)
		{
			string commandText = @"
SELECT 
" + Payment_Request.SelectFieldList + @"
FROM [dbo].[Payment_Request] 
WHERE 
	[Payment_Request].[ID] = @ID " + Payment_Request.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Payment_Request>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Payment_Request by a Payment_Request's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Payment_Request</returns>
		public static Payment_Request GetPayment_Request(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Payment_Request.SelectFieldList + @"
FROM [dbo].[Payment_Request] 
WHERE 
	[Payment_Request].[ID] = @ID " + Payment_Request.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Payment_Request>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Payment_Request objects.
		/// </summary>
		/// <returns>The retrieved collection of Payment_Request objects.</returns>
		public static EntityList<Payment_Request> GetPayment_Requests()
		{
			string commandText = @"
SELECT " + Payment_Request.SelectFieldList + "FROM [dbo].[Payment_Request] " + Payment_Request.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Payment_Request>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Payment_Request objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Payment_Request objects.</returns>
        public static EntityList<Payment_Request> GetPayment_Requests(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Payment_Request>(SelectFieldList, "FROM [dbo].[Payment_Request]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Payment_Request objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Payment_Request objects.</returns>
        public static EntityList<Payment_Request> GetPayment_Requests(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Payment_Request>(SelectFieldList, "FROM [dbo].[Payment_Request]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Payment_Request objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Payment_Request objects.</returns>
		protected static EntityList<Payment_Request> GetPayment_Requests(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPayment_Requests(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Payment_Request objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Payment_Request objects.</returns>
		protected static EntityList<Payment_Request> GetPayment_Requests(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPayment_Requests(string.Empty, where, parameters, Payment_Request.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Payment_Request objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Payment_Request objects.</returns>
		protected static EntityList<Payment_Request> GetPayment_Requests(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPayment_Requests(prefix, where, parameters, Payment_Request.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Payment_Request objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Payment_Request objects.</returns>
		protected static EntityList<Payment_Request> GetPayment_Requests(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetPayment_Requests(string.Empty, where, parameters, Payment_Request.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Payment_Request objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Payment_Request objects.</returns>
		protected static EntityList<Payment_Request> GetPayment_Requests(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetPayment_Requests(prefix, where, parameters, Payment_Request.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Payment_Request objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Payment_Request objects.</returns>
		protected static EntityList<Payment_Request> GetPayment_Requests(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Payment_Request.SelectFieldList + "FROM [dbo].[Payment_Request] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Payment_Request>(reader);
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
        protected static EntityList<Payment_Request> GetPayment_Requests(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Payment_Request>(SelectFieldList, "FROM [dbo].[Payment_Request] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Payment_Request objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetPayment_RequestCount()
        {
            return GetPayment_RequestCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Payment_Request objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetPayment_RequestCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Payment_Request] " + where;

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
		public static partial class Payment_Request_Properties
		{
			public const string ID = "ID";
			public const string RoomFeeID = "RoomFeeID";
			public const string EndTime = "EndTime";
			public const string PaymentID = "PaymentID";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string TotalCost = "TotalCost";
			public const string OrderID = "OrderID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomFeeID" , "int:"},
    			 {"EndTime" , "DateTime:"},
    			 {"PaymentID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"TotalCost" , "decimal:"},
    			 {"OrderID" , "int:"},
            };
		}
		#endregion
	}
}
