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
	/// This object represents the properties and methods of a Payment.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Payment 
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
		private decimal _amount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal Amount
		{
			[DebuggerStepThrough()]
			get { return this._amount; }
			set 
			{
				if (this._amount != value) 
				{
					this._amount = value;
					this.IsDirty = true;	
					OnPropertyChanged("Amount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _paymentType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string PaymentType
		{
			[DebuggerStepThrough()]
			get { return this._paymentType; }
			set 
			{
				if (this._paymentType != value) 
				{
					this._paymentType = value;
					this.IsDirty = true;	
					OnPropertyChanged("PaymentType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _tradeNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string TradeNo
		{
			[DebuggerStepThrough()]
			get { return this._tradeNo; }
			set 
			{
				if (this._tradeNo != value) 
				{
					this._tradeNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("TradeNo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _status = int.MinValue;
		/// <summary>
		/// 1-待付款 2-已完成 3-已关闭
		/// </summary>
        [Description("1-待付款 2-已完成 3-已关闭")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private DateTime _payRequestTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime PayRequestTime
		{
			[DebuggerStepThrough()]
			get { return this._payRequestTime; }
			set 
			{
				if (this._payRequestTime != value) 
				{
					this._payRequestTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("PayRequestTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _payCompleteTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime PayCompleteTime
		{
			[DebuggerStepThrough()]
			get { return this._payCompleteTime; }
			set 
			{
				if (this._payCompleteTime != value) 
				{
					this._payCompleteTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("PayCompleteTime");
				}
			}
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _payResult = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PayResult
		{
			[DebuggerStepThrough()]
			get { return this._payResult; }
			set 
			{
				if (this._payResult != value) 
				{
					this._payResult = value;
					this.IsDirty = true;	
					OnPropertyChanged("PayResult");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _remark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Remark
		{
			[DebuggerStepThrough()]
			get { return this._remark; }
			set 
			{
				if (this._remark != value) 
				{
					this._remark = value;
					this.IsDirty = true;	
					OnPropertyChanged("Remark");
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
		private string _addUser = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string AddUser
		{
			[DebuggerStepThrough()]
			get { return this._addUser; }
			set 
			{
				if (this._addUser != value) 
				{
					this._addUser = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUser");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _responseContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ResponseContent
		{
			[DebuggerStepThrough()]
			get { return this._responseContent; }
			set 
			{
				if (this._responseContent != value) 
				{
					this._responseContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("ResponseContent");
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
	[Amount] decimal(18, 2),
	[PaymentType] nvarchar(100),
	[TradeNo] nvarchar(500),
	[Status] int,
	[PayRequestTime] datetime,
	[PayCompleteTime] datetime,
	[PayResult] nvarchar(500),
	[Remark] ntext,
	[AddTime] datetime,
	[AddUser] nvarchar(500),
	[ResponseContent] ntext,
	[OrderID] int
);

INSERT INTO [dbo].[Payment] (
	[Payment].[Amount],
	[Payment].[PaymentType],
	[Payment].[TradeNo],
	[Payment].[Status],
	[Payment].[PayRequestTime],
	[Payment].[PayCompleteTime],
	[Payment].[PayResult],
	[Payment].[Remark],
	[Payment].[AddTime],
	[Payment].[AddUser],
	[Payment].[ResponseContent],
	[Payment].[OrderID]
) 
output 
	INSERTED.[ID],
	INSERTED.[Amount],
	INSERTED.[PaymentType],
	INSERTED.[TradeNo],
	INSERTED.[Status],
	INSERTED.[PayRequestTime],
	INSERTED.[PayCompleteTime],
	INSERTED.[PayResult],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[ResponseContent],
	INSERTED.[OrderID]
into @table
VALUES ( 
	@Amount,
	@PaymentType,
	@TradeNo,
	@Status,
	@PayRequestTime,
	@PayCompleteTime,
	@PayResult,
	@Remark,
	@AddTime,
	@AddUser,
	@ResponseContent,
	@OrderID 
); 

SELECT 
	[ID],
	[Amount],
	[PaymentType],
	[TradeNo],
	[Status],
	[PayRequestTime],
	[PayCompleteTime],
	[PayResult],
	[Remark],
	[AddTime],
	[AddUser],
	[ResponseContent],
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
	[Amount] decimal(18, 2),
	[PaymentType] nvarchar(100),
	[TradeNo] nvarchar(500),
	[Status] int,
	[PayRequestTime] datetime,
	[PayCompleteTime] datetime,
	[PayResult] nvarchar(500),
	[Remark] ntext,
	[AddTime] datetime,
	[AddUser] nvarchar(500),
	[ResponseContent] ntext,
	[OrderID] int
);

UPDATE [dbo].[Payment] SET 
	[Payment].[Amount] = @Amount,
	[Payment].[PaymentType] = @PaymentType,
	[Payment].[TradeNo] = @TradeNo,
	[Payment].[Status] = @Status,
	[Payment].[PayRequestTime] = @PayRequestTime,
	[Payment].[PayCompleteTime] = @PayCompleteTime,
	[Payment].[PayResult] = @PayResult,
	[Payment].[Remark] = @Remark,
	[Payment].[AddTime] = @AddTime,
	[Payment].[AddUser] = @AddUser,
	[Payment].[ResponseContent] = @ResponseContent,
	[Payment].[OrderID] = @OrderID 
output 
	INSERTED.[ID],
	INSERTED.[Amount],
	INSERTED.[PaymentType],
	INSERTED.[TradeNo],
	INSERTED.[Status],
	INSERTED.[PayRequestTime],
	INSERTED.[PayCompleteTime],
	INSERTED.[PayResult],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[ResponseContent],
	INSERTED.[OrderID]
into @table
WHERE 
	[Payment].[ID] = @ID

SELECT 
	[ID],
	[Amount],
	[PaymentType],
	[TradeNo],
	[Status],
	[PayRequestTime],
	[PayCompleteTime],
	[PayResult],
	[Remark],
	[AddTime],
	[AddUser],
	[ResponseContent],
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
DELETE FROM [dbo].[Payment]
WHERE 
	[Payment].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Payment() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetPayment(this.ID));
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
	[Payment].[ID],
	[Payment].[Amount],
	[Payment].[PaymentType],
	[Payment].[TradeNo],
	[Payment].[Status],
	[Payment].[PayRequestTime],
	[Payment].[PayCompleteTime],
	[Payment].[PayResult],
	[Payment].[Remark],
	[Payment].[AddTime],
	[Payment].[AddUser],
	[Payment].[ResponseContent],
	[Payment].[OrderID]
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
                return "Payment";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Payment into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="amount">amount</param>
		/// <param name="paymentType">paymentType</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="status">status</param>
		/// <param name="payRequestTime">payRequestTime</param>
		/// <param name="payCompleteTime">payCompleteTime</param>
		/// <param name="payResult">payResult</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="responseContent">responseContent</param>
		/// <param name="orderID">orderID</param>
		public static void InsertPayment(decimal @amount, string @paymentType, string @tradeNo, int @status, DateTime @payRequestTime, DateTime @payCompleteTime, string @payResult, string @remark, DateTime @addTime, string @addUser, string @responseContent, int @orderID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertPayment(@amount, @paymentType, @tradeNo, @status, @payRequestTime, @payCompleteTime, @payResult, @remark, @addTime, @addUser, @responseContent, @orderID, helper);
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
		/// Insert a Payment into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="amount">amount</param>
		/// <param name="paymentType">paymentType</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="status">status</param>
		/// <param name="payRequestTime">payRequestTime</param>
		/// <param name="payCompleteTime">payCompleteTime</param>
		/// <param name="payResult">payResult</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="responseContent">responseContent</param>
		/// <param name="orderID">orderID</param>
		/// <param name="helper">helper</param>
		internal static void InsertPayment(decimal @amount, string @paymentType, string @tradeNo, int @status, DateTime @payRequestTime, DateTime @payCompleteTime, string @payResult, string @remark, DateTime @addTime, string @addUser, string @responseContent, int @orderID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Amount] decimal(18, 2),
	[PaymentType] nvarchar(100),
	[TradeNo] nvarchar(500),
	[Status] int,
	[PayRequestTime] datetime,
	[PayCompleteTime] datetime,
	[PayResult] nvarchar(500),
	[Remark] ntext,
	[AddTime] datetime,
	[AddUser] nvarchar(500),
	[ResponseContent] ntext,
	[OrderID] int
);

INSERT INTO [dbo].[Payment] (
	[Payment].[Amount],
	[Payment].[PaymentType],
	[Payment].[TradeNo],
	[Payment].[Status],
	[Payment].[PayRequestTime],
	[Payment].[PayCompleteTime],
	[Payment].[PayResult],
	[Payment].[Remark],
	[Payment].[AddTime],
	[Payment].[AddUser],
	[Payment].[ResponseContent],
	[Payment].[OrderID]
) 
output 
	INSERTED.[ID],
	INSERTED.[Amount],
	INSERTED.[PaymentType],
	INSERTED.[TradeNo],
	INSERTED.[Status],
	INSERTED.[PayRequestTime],
	INSERTED.[PayCompleteTime],
	INSERTED.[PayResult],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[ResponseContent],
	INSERTED.[OrderID]
into @table
VALUES ( 
	@Amount,
	@PaymentType,
	@TradeNo,
	@Status,
	@PayRequestTime,
	@PayCompleteTime,
	@PayResult,
	@Remark,
	@AddTime,
	@AddUser,
	@ResponseContent,
	@OrderID 
); 

SELECT 
	[ID],
	[Amount],
	[PaymentType],
	[TradeNo],
	[Status],
	[PayRequestTime],
	[PayCompleteTime],
	[PayResult],
	[Remark],
	[AddTime],
	[AddUser],
	[ResponseContent],
	[OrderID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Amount", EntityBase.GetDatabaseValue(@amount)));
			parameters.Add(new SqlParameter("@PaymentType", EntityBase.GetDatabaseValue(@paymentType)));
			parameters.Add(new SqlParameter("@TradeNo", EntityBase.GetDatabaseValue(@tradeNo)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@PayRequestTime", EntityBase.GetDatabaseValue(@payRequestTime)));
			parameters.Add(new SqlParameter("@PayCompleteTime", EntityBase.GetDatabaseValue(@payCompleteTime)));
			parameters.Add(new SqlParameter("@PayResult", EntityBase.GetDatabaseValue(@payResult)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUser", EntityBase.GetDatabaseValue(@addUser)));
			parameters.Add(new SqlParameter("@ResponseContent", EntityBase.GetDatabaseValue(@responseContent)));
			parameters.Add(new SqlParameter("@OrderID", EntityBase.GetDatabaseValue(@orderID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Payment into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="amount">amount</param>
		/// <param name="paymentType">paymentType</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="status">status</param>
		/// <param name="payRequestTime">payRequestTime</param>
		/// <param name="payCompleteTime">payCompleteTime</param>
		/// <param name="payResult">payResult</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="responseContent">responseContent</param>
		/// <param name="orderID">orderID</param>
		public static void UpdatePayment(int @iD, decimal @amount, string @paymentType, string @tradeNo, int @status, DateTime @payRequestTime, DateTime @payCompleteTime, string @payResult, string @remark, DateTime @addTime, string @addUser, string @responseContent, int @orderID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdatePayment(@iD, @amount, @paymentType, @tradeNo, @status, @payRequestTime, @payCompleteTime, @payResult, @remark, @addTime, @addUser, @responseContent, @orderID, helper);
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
		/// Updates a Payment into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="amount">amount</param>
		/// <param name="paymentType">paymentType</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="status">status</param>
		/// <param name="payRequestTime">payRequestTime</param>
		/// <param name="payCompleteTime">payCompleteTime</param>
		/// <param name="payResult">payResult</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="responseContent">responseContent</param>
		/// <param name="orderID">orderID</param>
		/// <param name="helper">helper</param>
		internal static void UpdatePayment(int @iD, decimal @amount, string @paymentType, string @tradeNo, int @status, DateTime @payRequestTime, DateTime @payCompleteTime, string @payResult, string @remark, DateTime @addTime, string @addUser, string @responseContent, int @orderID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Amount] decimal(18, 2),
	[PaymentType] nvarchar(100),
	[TradeNo] nvarchar(500),
	[Status] int,
	[PayRequestTime] datetime,
	[PayCompleteTime] datetime,
	[PayResult] nvarchar(500),
	[Remark] ntext,
	[AddTime] datetime,
	[AddUser] nvarchar(500),
	[ResponseContent] ntext,
	[OrderID] int
);

UPDATE [dbo].[Payment] SET 
	[Payment].[Amount] = @Amount,
	[Payment].[PaymentType] = @PaymentType,
	[Payment].[TradeNo] = @TradeNo,
	[Payment].[Status] = @Status,
	[Payment].[PayRequestTime] = @PayRequestTime,
	[Payment].[PayCompleteTime] = @PayCompleteTime,
	[Payment].[PayResult] = @PayResult,
	[Payment].[Remark] = @Remark,
	[Payment].[AddTime] = @AddTime,
	[Payment].[AddUser] = @AddUser,
	[Payment].[ResponseContent] = @ResponseContent,
	[Payment].[OrderID] = @OrderID 
output 
	INSERTED.[ID],
	INSERTED.[Amount],
	INSERTED.[PaymentType],
	INSERTED.[TradeNo],
	INSERTED.[Status],
	INSERTED.[PayRequestTime],
	INSERTED.[PayCompleteTime],
	INSERTED.[PayResult],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[ResponseContent],
	INSERTED.[OrderID]
into @table
WHERE 
	[Payment].[ID] = @ID

SELECT 
	[ID],
	[Amount],
	[PaymentType],
	[TradeNo],
	[Status],
	[PayRequestTime],
	[PayCompleteTime],
	[PayResult],
	[Remark],
	[AddTime],
	[AddUser],
	[ResponseContent],
	[OrderID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Amount", EntityBase.GetDatabaseValue(@amount)));
			parameters.Add(new SqlParameter("@PaymentType", EntityBase.GetDatabaseValue(@paymentType)));
			parameters.Add(new SqlParameter("@TradeNo", EntityBase.GetDatabaseValue(@tradeNo)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@PayRequestTime", EntityBase.GetDatabaseValue(@payRequestTime)));
			parameters.Add(new SqlParameter("@PayCompleteTime", EntityBase.GetDatabaseValue(@payCompleteTime)));
			parameters.Add(new SqlParameter("@PayResult", EntityBase.GetDatabaseValue(@payResult)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUser", EntityBase.GetDatabaseValue(@addUser)));
			parameters.Add(new SqlParameter("@ResponseContent", EntityBase.GetDatabaseValue(@responseContent)));
			parameters.Add(new SqlParameter("@OrderID", EntityBase.GetDatabaseValue(@orderID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Payment from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeletePayment(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeletePayment(@iD, helper);
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
		/// Deletes a Payment from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeletePayment(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Payment]
WHERE 
	[Payment].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Payment object.
		/// </summary>
		/// <returns>The newly created Payment object.</returns>
		public static Payment CreatePayment()
		{
			return InitializeNew<Payment>();
		}
		
		/// <summary>
		/// Retrieve information for a Payment by a Payment's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Payment</returns>
		public static Payment GetPayment(int @iD)
		{
			string commandText = @"
SELECT 
" + Payment.SelectFieldList + @"
FROM [dbo].[Payment] 
WHERE 
	[Payment].[ID] = @ID " + Payment.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Payment>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Payment by a Payment's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Payment</returns>
		public static Payment GetPayment(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Payment.SelectFieldList + @"
FROM [dbo].[Payment] 
WHERE 
	[Payment].[ID] = @ID " + Payment.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Payment>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Payment objects.
		/// </summary>
		/// <returns>The retrieved collection of Payment objects.</returns>
		public static EntityList<Payment> GetPayments()
		{
			string commandText = @"
SELECT " + Payment.SelectFieldList + "FROM [dbo].[Payment] " + Payment.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Payment>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Payment objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Payment objects.</returns>
        public static EntityList<Payment> GetPayments(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Payment>(SelectFieldList, "FROM [dbo].[Payment]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Payment objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Payment objects.</returns>
        public static EntityList<Payment> GetPayments(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Payment>(SelectFieldList, "FROM [dbo].[Payment]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Payment objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Payment objects.</returns>
		protected static EntityList<Payment> GetPayments(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPayments(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Payment objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Payment objects.</returns>
		protected static EntityList<Payment> GetPayments(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPayments(string.Empty, where, parameters, Payment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Payment objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Payment objects.</returns>
		protected static EntityList<Payment> GetPayments(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPayments(prefix, where, parameters, Payment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Payment objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Payment objects.</returns>
		protected static EntityList<Payment> GetPayments(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetPayments(string.Empty, where, parameters, Payment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Payment objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Payment objects.</returns>
		protected static EntityList<Payment> GetPayments(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetPayments(prefix, where, parameters, Payment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Payment objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Payment objects.</returns>
		protected static EntityList<Payment> GetPayments(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Payment.SelectFieldList + "FROM [dbo].[Payment] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Payment>(reader);
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
        protected static EntityList<Payment> GetPayments(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Payment>(SelectFieldList, "FROM [dbo].[Payment] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Payment objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetPaymentCount()
        {
            return GetPaymentCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Payment objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetPaymentCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Payment] " + where;

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
		public static partial class Payment_Properties
		{
			public const string ID = "ID";
			public const string Amount = "Amount";
			public const string PaymentType = "PaymentType";
			public const string TradeNo = "TradeNo";
			public const string Status = "Status";
			public const string PayRequestTime = "PayRequestTime";
			public const string PayCompleteTime = "PayCompleteTime";
			public const string PayResult = "PayResult";
			public const string Remark = "Remark";
			public const string AddTime = "AddTime";
			public const string AddUser = "AddUser";
			public const string ResponseContent = "ResponseContent";
			public const string OrderID = "OrderID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Amount" , "decimal:"},
    			 {"PaymentType" , "string:"},
    			 {"TradeNo" , "string:"},
    			 {"Status" , "int:1-待付款 2-已完成 3-已关闭"},
    			 {"PayRequestTime" , "DateTime:"},
    			 {"PayCompleteTime" , "DateTime:"},
    			 {"PayResult" , "string:"},
    			 {"Remark" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUser" , "string:"},
    			 {"ResponseContent" , "string:"},
    			 {"OrderID" , "int:"},
            };
		}
		#endregion
	}
}
