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
	/// This object represents the properties and methods of a Mall_OrderRefundRequest.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_OrderRefundRequest 
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
		private int _orderID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _refundTrackNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RefundTrackNo
		{
			[DebuggerStepThrough()]
			get { return this._refundTrackNo; }
			set 
			{
				if (this._refundTrackNo != value) 
				{
					this._refundTrackNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("RefundTrackNo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _refundAmount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal RefundAmount
		{
			[DebuggerStepThrough()]
			get { return this._refundAmount; }
			set 
			{
				if (this._refundAmount != value) 
				{
					this._refundAmount = value;
					this.IsDirty = true;	
					OnPropertyChanged("RefundAmount");
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
		private bool _isSuccess = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsSuccess
		{
			[DebuggerStepThrough()]
			get { return this._isSuccess; }
			set 
			{
				if (this._isSuccess != value) 
				{
					this._isSuccess = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsSuccess");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _result = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Result
		{
			[DebuggerStepThrough()]
			get { return this._result; }
			set 
			{
				if (this._result != value) 
				{
					this._result = value;
					this.IsDirty = true;	
					OnPropertyChanged("Result");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _refundType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RefundType
		{
			[DebuggerStepThrough()]
			get { return this._refundType; }
			set 
			{
				if (this._refundType != value) 
				{
					this._refundType = value;
					this.IsDirty = true;	
					OnPropertyChanged("RefundType");
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
		private string _uploadImages = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string UploadImages
		{
			[DebuggerStepThrough()]
			get { return this._uploadImages; }
			set 
			{
				if (this._uploadImages != value) 
				{
					this._uploadImages = value;
					this.IsDirty = true;	
					OnPropertyChanged("UploadImages");
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
	[OrderID] int,
	[RefundTrackNo] nvarchar(200),
	[RefundAmount] decimal(18, 2),
	[AddTime] datetime,
	[AddUser] nvarchar(100),
	[IsSuccess] bit,
	[Result] ntext,
	[RefundType] nvarchar(100),
	[Remark] ntext,
	[UploadImages] ntext
);

INSERT INTO [dbo].[Mall_OrderRefundRequest] (
	[Mall_OrderRefundRequest].[OrderID],
	[Mall_OrderRefundRequest].[RefundTrackNo],
	[Mall_OrderRefundRequest].[RefundAmount],
	[Mall_OrderRefundRequest].[AddTime],
	[Mall_OrderRefundRequest].[AddUser],
	[Mall_OrderRefundRequest].[IsSuccess],
	[Mall_OrderRefundRequest].[Result],
	[Mall_OrderRefundRequest].[RefundType],
	[Mall_OrderRefundRequest].[Remark],
	[Mall_OrderRefundRequest].[UploadImages]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[RefundTrackNo],
	INSERTED.[RefundAmount],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[IsSuccess],
	INSERTED.[Result],
	INSERTED.[RefundType],
	INSERTED.[Remark],
	INSERTED.[UploadImages]
into @table
VALUES ( 
	@OrderID,
	@RefundTrackNo,
	@RefundAmount,
	@AddTime,
	@AddUser,
	@IsSuccess,
	@Result,
	@RefundType,
	@Remark,
	@UploadImages 
); 

SELECT 
	[ID],
	[OrderID],
	[RefundTrackNo],
	[RefundAmount],
	[AddTime],
	[AddUser],
	[IsSuccess],
	[Result],
	[RefundType],
	[Remark],
	[UploadImages] 
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
	[OrderID] int,
	[RefundTrackNo] nvarchar(200),
	[RefundAmount] decimal(18, 2),
	[AddTime] datetime,
	[AddUser] nvarchar(100),
	[IsSuccess] bit,
	[Result] ntext,
	[RefundType] nvarchar(100),
	[Remark] ntext,
	[UploadImages] ntext
);

UPDATE [dbo].[Mall_OrderRefundRequest] SET 
	[Mall_OrderRefundRequest].[OrderID] = @OrderID,
	[Mall_OrderRefundRequest].[RefundTrackNo] = @RefundTrackNo,
	[Mall_OrderRefundRequest].[RefundAmount] = @RefundAmount,
	[Mall_OrderRefundRequest].[AddTime] = @AddTime,
	[Mall_OrderRefundRequest].[AddUser] = @AddUser,
	[Mall_OrderRefundRequest].[IsSuccess] = @IsSuccess,
	[Mall_OrderRefundRequest].[Result] = @Result,
	[Mall_OrderRefundRequest].[RefundType] = @RefundType,
	[Mall_OrderRefundRequest].[Remark] = @Remark,
	[Mall_OrderRefundRequest].[UploadImages] = @UploadImages 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[RefundTrackNo],
	INSERTED.[RefundAmount],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[IsSuccess],
	INSERTED.[Result],
	INSERTED.[RefundType],
	INSERTED.[Remark],
	INSERTED.[UploadImages]
into @table
WHERE 
	[Mall_OrderRefundRequest].[ID] = @ID

SELECT 
	[ID],
	[OrderID],
	[RefundTrackNo],
	[RefundAmount],
	[AddTime],
	[AddUser],
	[IsSuccess],
	[Result],
	[RefundType],
	[Remark],
	[UploadImages] 
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
DELETE FROM [dbo].[Mall_OrderRefundRequest]
WHERE 
	[Mall_OrderRefundRequest].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_OrderRefundRequest() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_OrderRefundRequest(this.ID));
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
	[Mall_OrderRefundRequest].[ID],
	[Mall_OrderRefundRequest].[OrderID],
	[Mall_OrderRefundRequest].[RefundTrackNo],
	[Mall_OrderRefundRequest].[RefundAmount],
	[Mall_OrderRefundRequest].[AddTime],
	[Mall_OrderRefundRequest].[AddUser],
	[Mall_OrderRefundRequest].[IsSuccess],
	[Mall_OrderRefundRequest].[Result],
	[Mall_OrderRefundRequest].[RefundType],
	[Mall_OrderRefundRequest].[Remark],
	[Mall_OrderRefundRequest].[UploadImages]
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
                return "Mall_OrderRefundRequest";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_OrderRefundRequest into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderID">orderID</param>
		/// <param name="refundTrackNo">refundTrackNo</param>
		/// <param name="refundAmount">refundAmount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="isSuccess">isSuccess</param>
		/// <param name="result">result</param>
		/// <param name="refundType">refundType</param>
		/// <param name="remark">remark</param>
		/// <param name="uploadImages">uploadImages</param>
		public static void InsertMall_OrderRefundRequest(int @orderID, string @refundTrackNo, decimal @refundAmount, DateTime @addTime, string @addUser, bool @isSuccess, string @result, string @refundType, string @remark, string @uploadImages)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_OrderRefundRequest(@orderID, @refundTrackNo, @refundAmount, @addTime, @addUser, @isSuccess, @result, @refundType, @remark, @uploadImages, helper);
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
		/// Insert a Mall_OrderRefundRequest into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderID">orderID</param>
		/// <param name="refundTrackNo">refundTrackNo</param>
		/// <param name="refundAmount">refundAmount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="isSuccess">isSuccess</param>
		/// <param name="result">result</param>
		/// <param name="refundType">refundType</param>
		/// <param name="remark">remark</param>
		/// <param name="uploadImages">uploadImages</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_OrderRefundRequest(int @orderID, string @refundTrackNo, decimal @refundAmount, DateTime @addTime, string @addUser, bool @isSuccess, string @result, string @refundType, string @remark, string @uploadImages, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrderID] int,
	[RefundTrackNo] nvarchar(200),
	[RefundAmount] decimal(18, 2),
	[AddTime] datetime,
	[AddUser] nvarchar(100),
	[IsSuccess] bit,
	[Result] ntext,
	[RefundType] nvarchar(100),
	[Remark] ntext,
	[UploadImages] ntext
);

INSERT INTO [dbo].[Mall_OrderRefundRequest] (
	[Mall_OrderRefundRequest].[OrderID],
	[Mall_OrderRefundRequest].[RefundTrackNo],
	[Mall_OrderRefundRequest].[RefundAmount],
	[Mall_OrderRefundRequest].[AddTime],
	[Mall_OrderRefundRequest].[AddUser],
	[Mall_OrderRefundRequest].[IsSuccess],
	[Mall_OrderRefundRequest].[Result],
	[Mall_OrderRefundRequest].[RefundType],
	[Mall_OrderRefundRequest].[Remark],
	[Mall_OrderRefundRequest].[UploadImages]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[RefundTrackNo],
	INSERTED.[RefundAmount],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[IsSuccess],
	INSERTED.[Result],
	INSERTED.[RefundType],
	INSERTED.[Remark],
	INSERTED.[UploadImages]
into @table
VALUES ( 
	@OrderID,
	@RefundTrackNo,
	@RefundAmount,
	@AddTime,
	@AddUser,
	@IsSuccess,
	@Result,
	@RefundType,
	@Remark,
	@UploadImages 
); 

SELECT 
	[ID],
	[OrderID],
	[RefundTrackNo],
	[RefundAmount],
	[AddTime],
	[AddUser],
	[IsSuccess],
	[Result],
	[RefundType],
	[Remark],
	[UploadImages] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OrderID", EntityBase.GetDatabaseValue(@orderID)));
			parameters.Add(new SqlParameter("@RefundTrackNo", EntityBase.GetDatabaseValue(@refundTrackNo)));
			parameters.Add(new SqlParameter("@RefundAmount", EntityBase.GetDatabaseValue(@refundAmount)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUser", EntityBase.GetDatabaseValue(@addUser)));
			parameters.Add(new SqlParameter("@IsSuccess", @isSuccess));
			parameters.Add(new SqlParameter("@Result", EntityBase.GetDatabaseValue(@result)));
			parameters.Add(new SqlParameter("@RefundType", EntityBase.GetDatabaseValue(@refundType)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@UploadImages", EntityBase.GetDatabaseValue(@uploadImages)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_OrderRefundRequest into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orderID">orderID</param>
		/// <param name="refundTrackNo">refundTrackNo</param>
		/// <param name="refundAmount">refundAmount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="isSuccess">isSuccess</param>
		/// <param name="result">result</param>
		/// <param name="refundType">refundType</param>
		/// <param name="remark">remark</param>
		/// <param name="uploadImages">uploadImages</param>
		public static void UpdateMall_OrderRefundRequest(int @iD, int @orderID, string @refundTrackNo, decimal @refundAmount, DateTime @addTime, string @addUser, bool @isSuccess, string @result, string @refundType, string @remark, string @uploadImages)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_OrderRefundRequest(@iD, @orderID, @refundTrackNo, @refundAmount, @addTime, @addUser, @isSuccess, @result, @refundType, @remark, @uploadImages, helper);
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
		/// Updates a Mall_OrderRefundRequest into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orderID">orderID</param>
		/// <param name="refundTrackNo">refundTrackNo</param>
		/// <param name="refundAmount">refundAmount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="isSuccess">isSuccess</param>
		/// <param name="result">result</param>
		/// <param name="refundType">refundType</param>
		/// <param name="remark">remark</param>
		/// <param name="uploadImages">uploadImages</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_OrderRefundRequest(int @iD, int @orderID, string @refundTrackNo, decimal @refundAmount, DateTime @addTime, string @addUser, bool @isSuccess, string @result, string @refundType, string @remark, string @uploadImages, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrderID] int,
	[RefundTrackNo] nvarchar(200),
	[RefundAmount] decimal(18, 2),
	[AddTime] datetime,
	[AddUser] nvarchar(100),
	[IsSuccess] bit,
	[Result] ntext,
	[RefundType] nvarchar(100),
	[Remark] ntext,
	[UploadImages] ntext
);

UPDATE [dbo].[Mall_OrderRefundRequest] SET 
	[Mall_OrderRefundRequest].[OrderID] = @OrderID,
	[Mall_OrderRefundRequest].[RefundTrackNo] = @RefundTrackNo,
	[Mall_OrderRefundRequest].[RefundAmount] = @RefundAmount,
	[Mall_OrderRefundRequest].[AddTime] = @AddTime,
	[Mall_OrderRefundRequest].[AddUser] = @AddUser,
	[Mall_OrderRefundRequest].[IsSuccess] = @IsSuccess,
	[Mall_OrderRefundRequest].[Result] = @Result,
	[Mall_OrderRefundRequest].[RefundType] = @RefundType,
	[Mall_OrderRefundRequest].[Remark] = @Remark,
	[Mall_OrderRefundRequest].[UploadImages] = @UploadImages 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[RefundTrackNo],
	INSERTED.[RefundAmount],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[IsSuccess],
	INSERTED.[Result],
	INSERTED.[RefundType],
	INSERTED.[Remark],
	INSERTED.[UploadImages]
into @table
WHERE 
	[Mall_OrderRefundRequest].[ID] = @ID

SELECT 
	[ID],
	[OrderID],
	[RefundTrackNo],
	[RefundAmount],
	[AddTime],
	[AddUser],
	[IsSuccess],
	[Result],
	[RefundType],
	[Remark],
	[UploadImages] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OrderID", EntityBase.GetDatabaseValue(@orderID)));
			parameters.Add(new SqlParameter("@RefundTrackNo", EntityBase.GetDatabaseValue(@refundTrackNo)));
			parameters.Add(new SqlParameter("@RefundAmount", EntityBase.GetDatabaseValue(@refundAmount)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUser", EntityBase.GetDatabaseValue(@addUser)));
			parameters.Add(new SqlParameter("@IsSuccess", @isSuccess));
			parameters.Add(new SqlParameter("@Result", EntityBase.GetDatabaseValue(@result)));
			parameters.Add(new SqlParameter("@RefundType", EntityBase.GetDatabaseValue(@refundType)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@UploadImages", EntityBase.GetDatabaseValue(@uploadImages)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_OrderRefundRequest from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_OrderRefundRequest(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_OrderRefundRequest(@iD, helper);
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
		/// Deletes a Mall_OrderRefundRequest from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_OrderRefundRequest(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_OrderRefundRequest]
WHERE 
	[Mall_OrderRefundRequest].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_OrderRefundRequest object.
		/// </summary>
		/// <returns>The newly created Mall_OrderRefundRequest object.</returns>
		public static Mall_OrderRefundRequest CreateMall_OrderRefundRequest()
		{
			return InitializeNew<Mall_OrderRefundRequest>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_OrderRefundRequest by a Mall_OrderRefundRequest's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_OrderRefundRequest</returns>
		public static Mall_OrderRefundRequest GetMall_OrderRefundRequest(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_OrderRefundRequest.SelectFieldList + @"
FROM [dbo].[Mall_OrderRefundRequest] 
WHERE 
	[Mall_OrderRefundRequest].[ID] = @ID " + Mall_OrderRefundRequest.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_OrderRefundRequest>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_OrderRefundRequest by a Mall_OrderRefundRequest's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_OrderRefundRequest</returns>
		public static Mall_OrderRefundRequest GetMall_OrderRefundRequest(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_OrderRefundRequest.SelectFieldList + @"
FROM [dbo].[Mall_OrderRefundRequest] 
WHERE 
	[Mall_OrderRefundRequest].[ID] = @ID " + Mall_OrderRefundRequest.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_OrderRefundRequest>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderRefundRequest objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_OrderRefundRequest objects.</returns>
		public static EntityList<Mall_OrderRefundRequest> GetMall_OrderRefundRequests()
		{
			string commandText = @"
SELECT " + Mall_OrderRefundRequest.SelectFieldList + "FROM [dbo].[Mall_OrderRefundRequest] " + Mall_OrderRefundRequest.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_OrderRefundRequest>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_OrderRefundRequest objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_OrderRefundRequest objects.</returns>
        public static EntityList<Mall_OrderRefundRequest> GetMall_OrderRefundRequests(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_OrderRefundRequest>(SelectFieldList, "FROM [dbo].[Mall_OrderRefundRequest]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_OrderRefundRequest objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_OrderRefundRequest objects.</returns>
        public static EntityList<Mall_OrderRefundRequest> GetMall_OrderRefundRequests(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_OrderRefundRequest>(SelectFieldList, "FROM [dbo].[Mall_OrderRefundRequest]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_OrderRefundRequest objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_OrderRefundRequest objects.</returns>
		protected static EntityList<Mall_OrderRefundRequest> GetMall_OrderRefundRequests(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_OrderRefundRequests(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderRefundRequest objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderRefundRequest objects.</returns>
		protected static EntityList<Mall_OrderRefundRequest> GetMall_OrderRefundRequests(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_OrderRefundRequests(string.Empty, where, parameters, Mall_OrderRefundRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderRefundRequest objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderRefundRequest objects.</returns>
		protected static EntityList<Mall_OrderRefundRequest> GetMall_OrderRefundRequests(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_OrderRefundRequests(prefix, where, parameters, Mall_OrderRefundRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderRefundRequest objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderRefundRequest objects.</returns>
		protected static EntityList<Mall_OrderRefundRequest> GetMall_OrderRefundRequests(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_OrderRefundRequests(string.Empty, where, parameters, Mall_OrderRefundRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderRefundRequest objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderRefundRequest objects.</returns>
		protected static EntityList<Mall_OrderRefundRequest> GetMall_OrderRefundRequests(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_OrderRefundRequests(prefix, where, parameters, Mall_OrderRefundRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderRefundRequest objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_OrderRefundRequest objects.</returns>
		protected static EntityList<Mall_OrderRefundRequest> GetMall_OrderRefundRequests(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_OrderRefundRequest.SelectFieldList + "FROM [dbo].[Mall_OrderRefundRequest] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_OrderRefundRequest>(reader);
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
        protected static EntityList<Mall_OrderRefundRequest> GetMall_OrderRefundRequests(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_OrderRefundRequest>(SelectFieldList, "FROM [dbo].[Mall_OrderRefundRequest] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_OrderRefundRequest objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_OrderRefundRequestCount()
        {
            return GetMall_OrderRefundRequestCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_OrderRefundRequest objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_OrderRefundRequestCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_OrderRefundRequest] " + where;

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
		public static partial class Mall_OrderRefundRequest_Properties
		{
			public const string ID = "ID";
			public const string OrderID = "OrderID";
			public const string RefundTrackNo = "RefundTrackNo";
			public const string RefundAmount = "RefundAmount";
			public const string AddTime = "AddTime";
			public const string AddUser = "AddUser";
			public const string IsSuccess = "IsSuccess";
			public const string Result = "Result";
			public const string RefundType = "RefundType";
			public const string Remark = "Remark";
			public const string UploadImages = "UploadImages";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OrderID" , "int:"},
    			 {"RefundTrackNo" , "string:"},
    			 {"RefundAmount" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUser" , "string:"},
    			 {"IsSuccess" , "bool:"},
    			 {"Result" , "string:"},
    			 {"RefundType" , "string:"},
    			 {"Remark" , "string:"},
    			 {"UploadImages" , "string:"},
            };
		}
		#endregion
	}
}
