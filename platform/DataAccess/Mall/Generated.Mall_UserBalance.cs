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
	/// This object represents the properties and methods of a Mall_UserBalance.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_UserBalance 
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
		private int _balanceType = int.MinValue;
		/// <summary>
		/// 1-充值 2-消费
		/// </summary>
        [Description("1-充值 2-消费")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int BalanceType
		{
			[DebuggerStepThrough()]
			get { return this._balanceType; }
			set 
			{
				if (this._balanceType != value) 
				{
					this._balanceType = value;
					this.IsDirty = true;	
					OnPropertyChanged("BalanceType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _balanceValue = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal BalanceValue
		{
			[DebuggerStepThrough()]
			get { return this._balanceValue; }
			set 
			{
				if (this._balanceValue != value) 
				{
					this._balanceValue = value;
					this.IsDirty = true;	
					OnPropertyChanged("BalanceValue");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _title = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Title
		{
			[DebuggerStepThrough()]
			get { return this._title; }
			set 
			{
				if (this._title != value) 
				{
					this._title = value;
					this.IsDirty = true;	
					OnPropertyChanged("Title");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _summary = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Summary
		{
			[DebuggerStepThrough()]
			get { return this._summary; }
			set 
			{
				if (this._summary != value) 
				{
					this._summary = value;
					this.IsDirty = true;	
					OnPropertyChanged("Summary");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _categoryType = int.MinValue;
		/// <summary>
		/// 1-购买商品消费 2-微信充值 3-支付宝充值 4-订单退款返还 5-充值赠与 6-消费赠与 7-退款消费赠与取消 8-线下充值 9-业主结算 10-线下扣除
		/// </summary>
        [Description("1-购买商品消费 2-微信充值 3-支付宝充值 4-订单退款返还 5-充值赠与 6-消费赠与 7-退款消费赠与取消 8-线下充值 9-业主结算 10-线下扣除")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int CategoryType
		{
			[DebuggerStepThrough()]
			get { return this._categoryType; }
			set 
			{
				if (this._categoryType != value) 
				{
					this._categoryType = value;
					this.IsDirty = true;	
					OnPropertyChanged("CategoryType");
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
		private int _balanceStatus = int.MinValue;
		/// <summary>
		/// 0-未入账 1-已入账
		/// </summary>
        [Description("0-未入账 1-已入账")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int BalanceStatus
		{
			[DebuggerStepThrough()]
			get { return this._balanceStatus; }
			set 
			{
				if (this._balanceStatus != value) 
				{
					this._balanceStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("BalanceStatus");
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
		[DataObjectField(false, false, true)]
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
		private int _relatedID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RelatedID
		{
			[DebuggerStepThrough()]
			get { return this._relatedID; }
			set 
			{
				if (this._relatedID != value) 
				{
					this._relatedID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RelatedID");
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
		[DataObjectField(false, false, true)]
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
		private string _paymentMethod = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PaymentMethod
		{
			[DebuggerStepThrough()]
			get { return this._paymentMethod; }
			set 
			{
				if (this._paymentMethod != value) 
				{
					this._paymentMethod = value;
					this.IsDirty = true;	
					OnPropertyChanged("PaymentMethod");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isSent = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsSent
		{
			[DebuggerStepThrough()]
			get { return this._isSent; }
			set 
			{
				if (this._isSent != value) 
				{
					this._isSent = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsSent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _sentTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime SentTime
		{
			[DebuggerStepThrough()]
			get { return this._sentTime; }
			set 
			{
				if (this._sentTime != value) 
				{
					this._sentTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("SentTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _isReadySendTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime IsReadySendTime
		{
			[DebuggerStepThrough()]
			get { return this._isReadySendTime; }
			set 
			{
				if (this._isReadySendTime != value) 
				{
					this._isReadySendTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsReadySendTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isManualIncoming = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsManualIncoming
		{
			[DebuggerStepThrough()]
			get { return this._isManualIncoming; }
			set 
			{
				if (this._isManualIncoming != value) 
				{
					this._isManualIncoming = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsManualIncoming");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _userLevelApproveID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int UserLevelApproveID
		{
			[DebuggerStepThrough()]
			get { return this._userLevelApproveID; }
			set 
			{
				if (this._userLevelApproveID != value) 
				{
					this._userLevelApproveID = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserLevelApproveID");
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
	[UserID] int,
	[BalanceType] int,
	[BalanceValue] decimal(18, 2),
	[Title] nvarchar(200),
	[Summary] ntext,
	[CategoryType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(100),
	[BalanceStatus] int,
	[TradeNo] nvarchar(200),
	[RelatedID] int,
	[AmountRuleID] int,
	[PaymentMethod] nvarchar(200),
	[IsSent] bit,
	[SentTime] datetime,
	[IsReadySendTime] datetime,
	[IsManualIncoming] bit,
	[UserLevelApproveID] int,
	[Remark] ntext
);

INSERT INTO [dbo].[Mall_UserBalance] (
	[Mall_UserBalance].[UserID],
	[Mall_UserBalance].[BalanceType],
	[Mall_UserBalance].[BalanceValue],
	[Mall_UserBalance].[Title],
	[Mall_UserBalance].[Summary],
	[Mall_UserBalance].[CategoryType],
	[Mall_UserBalance].[AddTime],
	[Mall_UserBalance].[AddUserName],
	[Mall_UserBalance].[BalanceStatus],
	[Mall_UserBalance].[TradeNo],
	[Mall_UserBalance].[RelatedID],
	[Mall_UserBalance].[AmountRuleID],
	[Mall_UserBalance].[PaymentMethod],
	[Mall_UserBalance].[IsSent],
	[Mall_UserBalance].[SentTime],
	[Mall_UserBalance].[IsReadySendTime],
	[Mall_UserBalance].[IsManualIncoming],
	[Mall_UserBalance].[UserLevelApproveID],
	[Mall_UserBalance].[Remark]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[BalanceType],
	INSERTED.[BalanceValue],
	INSERTED.[Title],
	INSERTED.[Summary],
	INSERTED.[CategoryType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[BalanceStatus],
	INSERTED.[TradeNo],
	INSERTED.[RelatedID],
	INSERTED.[AmountRuleID],
	INSERTED.[PaymentMethod],
	INSERTED.[IsSent],
	INSERTED.[SentTime],
	INSERTED.[IsReadySendTime],
	INSERTED.[IsManualIncoming],
	INSERTED.[UserLevelApproveID],
	INSERTED.[Remark]
into @table
VALUES ( 
	@UserID,
	@BalanceType,
	@BalanceValue,
	@Title,
	@Summary,
	@CategoryType,
	@AddTime,
	@AddUserName,
	@BalanceStatus,
	@TradeNo,
	@RelatedID,
	@AmountRuleID,
	@PaymentMethod,
	@IsSent,
	@SentTime,
	@IsReadySendTime,
	@IsManualIncoming,
	@UserLevelApproveID,
	@Remark 
); 

SELECT 
	[ID],
	[UserID],
	[BalanceType],
	[BalanceValue],
	[Title],
	[Summary],
	[CategoryType],
	[AddTime],
	[AddUserName],
	[BalanceStatus],
	[TradeNo],
	[RelatedID],
	[AmountRuleID],
	[PaymentMethod],
	[IsSent],
	[SentTime],
	[IsReadySendTime],
	[IsManualIncoming],
	[UserLevelApproveID],
	[Remark] 
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
	[UserID] int,
	[BalanceType] int,
	[BalanceValue] decimal(18, 2),
	[Title] nvarchar(200),
	[Summary] ntext,
	[CategoryType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(100),
	[BalanceStatus] int,
	[TradeNo] nvarchar(200),
	[RelatedID] int,
	[AmountRuleID] int,
	[PaymentMethod] nvarchar(200),
	[IsSent] bit,
	[SentTime] datetime,
	[IsReadySendTime] datetime,
	[IsManualIncoming] bit,
	[UserLevelApproveID] int,
	[Remark] ntext
);

UPDATE [dbo].[Mall_UserBalance] SET 
	[Mall_UserBalance].[UserID] = @UserID,
	[Mall_UserBalance].[BalanceType] = @BalanceType,
	[Mall_UserBalance].[BalanceValue] = @BalanceValue,
	[Mall_UserBalance].[Title] = @Title,
	[Mall_UserBalance].[Summary] = @Summary,
	[Mall_UserBalance].[CategoryType] = @CategoryType,
	[Mall_UserBalance].[AddTime] = @AddTime,
	[Mall_UserBalance].[AddUserName] = @AddUserName,
	[Mall_UserBalance].[BalanceStatus] = @BalanceStatus,
	[Mall_UserBalance].[TradeNo] = @TradeNo,
	[Mall_UserBalance].[RelatedID] = @RelatedID,
	[Mall_UserBalance].[AmountRuleID] = @AmountRuleID,
	[Mall_UserBalance].[PaymentMethod] = @PaymentMethod,
	[Mall_UserBalance].[IsSent] = @IsSent,
	[Mall_UserBalance].[SentTime] = @SentTime,
	[Mall_UserBalance].[IsReadySendTime] = @IsReadySendTime,
	[Mall_UserBalance].[IsManualIncoming] = @IsManualIncoming,
	[Mall_UserBalance].[UserLevelApproveID] = @UserLevelApproveID,
	[Mall_UserBalance].[Remark] = @Remark 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[BalanceType],
	INSERTED.[BalanceValue],
	INSERTED.[Title],
	INSERTED.[Summary],
	INSERTED.[CategoryType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[BalanceStatus],
	INSERTED.[TradeNo],
	INSERTED.[RelatedID],
	INSERTED.[AmountRuleID],
	INSERTED.[PaymentMethod],
	INSERTED.[IsSent],
	INSERTED.[SentTime],
	INSERTED.[IsReadySendTime],
	INSERTED.[IsManualIncoming],
	INSERTED.[UserLevelApproveID],
	INSERTED.[Remark]
into @table
WHERE 
	[Mall_UserBalance].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[BalanceType],
	[BalanceValue],
	[Title],
	[Summary],
	[CategoryType],
	[AddTime],
	[AddUserName],
	[BalanceStatus],
	[TradeNo],
	[RelatedID],
	[AmountRuleID],
	[PaymentMethod],
	[IsSent],
	[SentTime],
	[IsReadySendTime],
	[IsManualIncoming],
	[UserLevelApproveID],
	[Remark] 
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
DELETE FROM [dbo].[Mall_UserBalance]
WHERE 
	[Mall_UserBalance].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_UserBalance() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_UserBalance(this.ID));
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
	[Mall_UserBalance].[ID],
	[Mall_UserBalance].[UserID],
	[Mall_UserBalance].[BalanceType],
	[Mall_UserBalance].[BalanceValue],
	[Mall_UserBalance].[Title],
	[Mall_UserBalance].[Summary],
	[Mall_UserBalance].[CategoryType],
	[Mall_UserBalance].[AddTime],
	[Mall_UserBalance].[AddUserName],
	[Mall_UserBalance].[BalanceStatus],
	[Mall_UserBalance].[TradeNo],
	[Mall_UserBalance].[RelatedID],
	[Mall_UserBalance].[AmountRuleID],
	[Mall_UserBalance].[PaymentMethod],
	[Mall_UserBalance].[IsSent],
	[Mall_UserBalance].[SentTime],
	[Mall_UserBalance].[IsReadySendTime],
	[Mall_UserBalance].[IsManualIncoming],
	[Mall_UserBalance].[UserLevelApproveID],
	[Mall_UserBalance].[Remark]
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
                return "Mall_UserBalance";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_UserBalance into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="balanceType">balanceType</param>
		/// <param name="balanceValue">balanceValue</param>
		/// <param name="title">title</param>
		/// <param name="summary">summary</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="balanceStatus">balanceStatus</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="relatedID">relatedID</param>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="paymentMethod">paymentMethod</param>
		/// <param name="isSent">isSent</param>
		/// <param name="sentTime">sentTime</param>
		/// <param name="isReadySendTime">isReadySendTime</param>
		/// <param name="isManualIncoming">isManualIncoming</param>
		/// <param name="userLevelApproveID">userLevelApproveID</param>
		/// <param name="remark">remark</param>
		public static void InsertMall_UserBalance(int @userID, int @balanceType, decimal @balanceValue, string @title, string @summary, int @categoryType, DateTime @addTime, string @addUserName, int @balanceStatus, string @tradeNo, int @relatedID, int @amountRuleID, string @paymentMethod, bool @isSent, DateTime @sentTime, DateTime @isReadySendTime, bool @isManualIncoming, int @userLevelApproveID, string @remark)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_UserBalance(@userID, @balanceType, @balanceValue, @title, @summary, @categoryType, @addTime, @addUserName, @balanceStatus, @tradeNo, @relatedID, @amountRuleID, @paymentMethod, @isSent, @sentTime, @isReadySendTime, @isManualIncoming, @userLevelApproveID, @remark, helper);
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
		/// Insert a Mall_UserBalance into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="balanceType">balanceType</param>
		/// <param name="balanceValue">balanceValue</param>
		/// <param name="title">title</param>
		/// <param name="summary">summary</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="balanceStatus">balanceStatus</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="relatedID">relatedID</param>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="paymentMethod">paymentMethod</param>
		/// <param name="isSent">isSent</param>
		/// <param name="sentTime">sentTime</param>
		/// <param name="isReadySendTime">isReadySendTime</param>
		/// <param name="isManualIncoming">isManualIncoming</param>
		/// <param name="userLevelApproveID">userLevelApproveID</param>
		/// <param name="remark">remark</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_UserBalance(int @userID, int @balanceType, decimal @balanceValue, string @title, string @summary, int @categoryType, DateTime @addTime, string @addUserName, int @balanceStatus, string @tradeNo, int @relatedID, int @amountRuleID, string @paymentMethod, bool @isSent, DateTime @sentTime, DateTime @isReadySendTime, bool @isManualIncoming, int @userLevelApproveID, string @remark, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[BalanceType] int,
	[BalanceValue] decimal(18, 2),
	[Title] nvarchar(200),
	[Summary] ntext,
	[CategoryType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(100),
	[BalanceStatus] int,
	[TradeNo] nvarchar(200),
	[RelatedID] int,
	[AmountRuleID] int,
	[PaymentMethod] nvarchar(200),
	[IsSent] bit,
	[SentTime] datetime,
	[IsReadySendTime] datetime,
	[IsManualIncoming] bit,
	[UserLevelApproveID] int,
	[Remark] ntext
);

INSERT INTO [dbo].[Mall_UserBalance] (
	[Mall_UserBalance].[UserID],
	[Mall_UserBalance].[BalanceType],
	[Mall_UserBalance].[BalanceValue],
	[Mall_UserBalance].[Title],
	[Mall_UserBalance].[Summary],
	[Mall_UserBalance].[CategoryType],
	[Mall_UserBalance].[AddTime],
	[Mall_UserBalance].[AddUserName],
	[Mall_UserBalance].[BalanceStatus],
	[Mall_UserBalance].[TradeNo],
	[Mall_UserBalance].[RelatedID],
	[Mall_UserBalance].[AmountRuleID],
	[Mall_UserBalance].[PaymentMethod],
	[Mall_UserBalance].[IsSent],
	[Mall_UserBalance].[SentTime],
	[Mall_UserBalance].[IsReadySendTime],
	[Mall_UserBalance].[IsManualIncoming],
	[Mall_UserBalance].[UserLevelApproveID],
	[Mall_UserBalance].[Remark]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[BalanceType],
	INSERTED.[BalanceValue],
	INSERTED.[Title],
	INSERTED.[Summary],
	INSERTED.[CategoryType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[BalanceStatus],
	INSERTED.[TradeNo],
	INSERTED.[RelatedID],
	INSERTED.[AmountRuleID],
	INSERTED.[PaymentMethod],
	INSERTED.[IsSent],
	INSERTED.[SentTime],
	INSERTED.[IsReadySendTime],
	INSERTED.[IsManualIncoming],
	INSERTED.[UserLevelApproveID],
	INSERTED.[Remark]
into @table
VALUES ( 
	@UserID,
	@BalanceType,
	@BalanceValue,
	@Title,
	@Summary,
	@CategoryType,
	@AddTime,
	@AddUserName,
	@BalanceStatus,
	@TradeNo,
	@RelatedID,
	@AmountRuleID,
	@PaymentMethod,
	@IsSent,
	@SentTime,
	@IsReadySendTime,
	@IsManualIncoming,
	@UserLevelApproveID,
	@Remark 
); 

SELECT 
	[ID],
	[UserID],
	[BalanceType],
	[BalanceValue],
	[Title],
	[Summary],
	[CategoryType],
	[AddTime],
	[AddUserName],
	[BalanceStatus],
	[TradeNo],
	[RelatedID],
	[AmountRuleID],
	[PaymentMethod],
	[IsSent],
	[SentTime],
	[IsReadySendTime],
	[IsManualIncoming],
	[UserLevelApproveID],
	[Remark] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@BalanceType", EntityBase.GetDatabaseValue(@balanceType)));
			parameters.Add(new SqlParameter("@BalanceValue", EntityBase.GetDatabaseValue(@balanceValue)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@Summary", EntityBase.GetDatabaseValue(@summary)));
			parameters.Add(new SqlParameter("@CategoryType", EntityBase.GetDatabaseValue(@categoryType)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@BalanceStatus", EntityBase.GetDatabaseValue(@balanceStatus)));
			parameters.Add(new SqlParameter("@TradeNo", EntityBase.GetDatabaseValue(@tradeNo)));
			parameters.Add(new SqlParameter("@RelatedID", EntityBase.GetDatabaseValue(@relatedID)));
			parameters.Add(new SqlParameter("@AmountRuleID", EntityBase.GetDatabaseValue(@amountRuleID)));
			parameters.Add(new SqlParameter("@PaymentMethod", EntityBase.GetDatabaseValue(@paymentMethod)));
			parameters.Add(new SqlParameter("@IsSent", @isSent));
			parameters.Add(new SqlParameter("@SentTime", EntityBase.GetDatabaseValue(@sentTime)));
			parameters.Add(new SqlParameter("@IsReadySendTime", EntityBase.GetDatabaseValue(@isReadySendTime)));
			parameters.Add(new SqlParameter("@IsManualIncoming", @isManualIncoming));
			parameters.Add(new SqlParameter("@UserLevelApproveID", EntityBase.GetDatabaseValue(@userLevelApproveID)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_UserBalance into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="balanceType">balanceType</param>
		/// <param name="balanceValue">balanceValue</param>
		/// <param name="title">title</param>
		/// <param name="summary">summary</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="balanceStatus">balanceStatus</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="relatedID">relatedID</param>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="paymentMethod">paymentMethod</param>
		/// <param name="isSent">isSent</param>
		/// <param name="sentTime">sentTime</param>
		/// <param name="isReadySendTime">isReadySendTime</param>
		/// <param name="isManualIncoming">isManualIncoming</param>
		/// <param name="userLevelApproveID">userLevelApproveID</param>
		/// <param name="remark">remark</param>
		public static void UpdateMall_UserBalance(int @iD, int @userID, int @balanceType, decimal @balanceValue, string @title, string @summary, int @categoryType, DateTime @addTime, string @addUserName, int @balanceStatus, string @tradeNo, int @relatedID, int @amountRuleID, string @paymentMethod, bool @isSent, DateTime @sentTime, DateTime @isReadySendTime, bool @isManualIncoming, int @userLevelApproveID, string @remark)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_UserBalance(@iD, @userID, @balanceType, @balanceValue, @title, @summary, @categoryType, @addTime, @addUserName, @balanceStatus, @tradeNo, @relatedID, @amountRuleID, @paymentMethod, @isSent, @sentTime, @isReadySendTime, @isManualIncoming, @userLevelApproveID, @remark, helper);
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
		/// Updates a Mall_UserBalance into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="balanceType">balanceType</param>
		/// <param name="balanceValue">balanceValue</param>
		/// <param name="title">title</param>
		/// <param name="summary">summary</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="balanceStatus">balanceStatus</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="relatedID">relatedID</param>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="paymentMethod">paymentMethod</param>
		/// <param name="isSent">isSent</param>
		/// <param name="sentTime">sentTime</param>
		/// <param name="isReadySendTime">isReadySendTime</param>
		/// <param name="isManualIncoming">isManualIncoming</param>
		/// <param name="userLevelApproveID">userLevelApproveID</param>
		/// <param name="remark">remark</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_UserBalance(int @iD, int @userID, int @balanceType, decimal @balanceValue, string @title, string @summary, int @categoryType, DateTime @addTime, string @addUserName, int @balanceStatus, string @tradeNo, int @relatedID, int @amountRuleID, string @paymentMethod, bool @isSent, DateTime @sentTime, DateTime @isReadySendTime, bool @isManualIncoming, int @userLevelApproveID, string @remark, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[BalanceType] int,
	[BalanceValue] decimal(18, 2),
	[Title] nvarchar(200),
	[Summary] ntext,
	[CategoryType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(100),
	[BalanceStatus] int,
	[TradeNo] nvarchar(200),
	[RelatedID] int,
	[AmountRuleID] int,
	[PaymentMethod] nvarchar(200),
	[IsSent] bit,
	[SentTime] datetime,
	[IsReadySendTime] datetime,
	[IsManualIncoming] bit,
	[UserLevelApproveID] int,
	[Remark] ntext
);

UPDATE [dbo].[Mall_UserBalance] SET 
	[Mall_UserBalance].[UserID] = @UserID,
	[Mall_UserBalance].[BalanceType] = @BalanceType,
	[Mall_UserBalance].[BalanceValue] = @BalanceValue,
	[Mall_UserBalance].[Title] = @Title,
	[Mall_UserBalance].[Summary] = @Summary,
	[Mall_UserBalance].[CategoryType] = @CategoryType,
	[Mall_UserBalance].[AddTime] = @AddTime,
	[Mall_UserBalance].[AddUserName] = @AddUserName,
	[Mall_UserBalance].[BalanceStatus] = @BalanceStatus,
	[Mall_UserBalance].[TradeNo] = @TradeNo,
	[Mall_UserBalance].[RelatedID] = @RelatedID,
	[Mall_UserBalance].[AmountRuleID] = @AmountRuleID,
	[Mall_UserBalance].[PaymentMethod] = @PaymentMethod,
	[Mall_UserBalance].[IsSent] = @IsSent,
	[Mall_UserBalance].[SentTime] = @SentTime,
	[Mall_UserBalance].[IsReadySendTime] = @IsReadySendTime,
	[Mall_UserBalance].[IsManualIncoming] = @IsManualIncoming,
	[Mall_UserBalance].[UserLevelApproveID] = @UserLevelApproveID,
	[Mall_UserBalance].[Remark] = @Remark 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[BalanceType],
	INSERTED.[BalanceValue],
	INSERTED.[Title],
	INSERTED.[Summary],
	INSERTED.[CategoryType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[BalanceStatus],
	INSERTED.[TradeNo],
	INSERTED.[RelatedID],
	INSERTED.[AmountRuleID],
	INSERTED.[PaymentMethod],
	INSERTED.[IsSent],
	INSERTED.[SentTime],
	INSERTED.[IsReadySendTime],
	INSERTED.[IsManualIncoming],
	INSERTED.[UserLevelApproveID],
	INSERTED.[Remark]
into @table
WHERE 
	[Mall_UserBalance].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[BalanceType],
	[BalanceValue],
	[Title],
	[Summary],
	[CategoryType],
	[AddTime],
	[AddUserName],
	[BalanceStatus],
	[TradeNo],
	[RelatedID],
	[AmountRuleID],
	[PaymentMethod],
	[IsSent],
	[SentTime],
	[IsReadySendTime],
	[IsManualIncoming],
	[UserLevelApproveID],
	[Remark] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@BalanceType", EntityBase.GetDatabaseValue(@balanceType)));
			parameters.Add(new SqlParameter("@BalanceValue", EntityBase.GetDatabaseValue(@balanceValue)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@Summary", EntityBase.GetDatabaseValue(@summary)));
			parameters.Add(new SqlParameter("@CategoryType", EntityBase.GetDatabaseValue(@categoryType)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@BalanceStatus", EntityBase.GetDatabaseValue(@balanceStatus)));
			parameters.Add(new SqlParameter("@TradeNo", EntityBase.GetDatabaseValue(@tradeNo)));
			parameters.Add(new SqlParameter("@RelatedID", EntityBase.GetDatabaseValue(@relatedID)));
			parameters.Add(new SqlParameter("@AmountRuleID", EntityBase.GetDatabaseValue(@amountRuleID)));
			parameters.Add(new SqlParameter("@PaymentMethod", EntityBase.GetDatabaseValue(@paymentMethod)));
			parameters.Add(new SqlParameter("@IsSent", @isSent));
			parameters.Add(new SqlParameter("@SentTime", EntityBase.GetDatabaseValue(@sentTime)));
			parameters.Add(new SqlParameter("@IsReadySendTime", EntityBase.GetDatabaseValue(@isReadySendTime)));
			parameters.Add(new SqlParameter("@IsManualIncoming", @isManualIncoming));
			parameters.Add(new SqlParameter("@UserLevelApproveID", EntityBase.GetDatabaseValue(@userLevelApproveID)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_UserBalance from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_UserBalance(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_UserBalance(@iD, helper);
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
		/// Deletes a Mall_UserBalance from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_UserBalance(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_UserBalance]
WHERE 
	[Mall_UserBalance].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_UserBalance object.
		/// </summary>
		/// <returns>The newly created Mall_UserBalance object.</returns>
		public static Mall_UserBalance CreateMall_UserBalance()
		{
			return InitializeNew<Mall_UserBalance>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_UserBalance by a Mall_UserBalance's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_UserBalance</returns>
		public static Mall_UserBalance GetMall_UserBalance(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_UserBalance.SelectFieldList + @"
FROM [dbo].[Mall_UserBalance] 
WHERE 
	[Mall_UserBalance].[ID] = @ID " + Mall_UserBalance.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_UserBalance>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_UserBalance by a Mall_UserBalance's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_UserBalance</returns>
		public static Mall_UserBalance GetMall_UserBalance(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_UserBalance.SelectFieldList + @"
FROM [dbo].[Mall_UserBalance] 
WHERE 
	[Mall_UserBalance].[ID] = @ID " + Mall_UserBalance.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_UserBalance>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserBalance objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_UserBalance objects.</returns>
		public static EntityList<Mall_UserBalance> GetMall_UserBalances()
		{
			string commandText = @"
SELECT " + Mall_UserBalance.SelectFieldList + "FROM [dbo].[Mall_UserBalance] " + Mall_UserBalance.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_UserBalance>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_UserBalance objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_UserBalance objects.</returns>
        public static EntityList<Mall_UserBalance> GetMall_UserBalances(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserBalance>(SelectFieldList, "FROM [dbo].[Mall_UserBalance]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_UserBalance objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_UserBalance objects.</returns>
        public static EntityList<Mall_UserBalance> GetMall_UserBalances(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserBalance>(SelectFieldList, "FROM [dbo].[Mall_UserBalance]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_UserBalance objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_UserBalance objects.</returns>
		protected static EntityList<Mall_UserBalance> GetMall_UserBalances(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserBalances(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserBalance objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserBalance objects.</returns>
		protected static EntityList<Mall_UserBalance> GetMall_UserBalances(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserBalances(string.Empty, where, parameters, Mall_UserBalance.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserBalance objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserBalance objects.</returns>
		protected static EntityList<Mall_UserBalance> GetMall_UserBalances(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserBalances(prefix, where, parameters, Mall_UserBalance.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserBalance objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserBalance objects.</returns>
		protected static EntityList<Mall_UserBalance> GetMall_UserBalances(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_UserBalances(string.Empty, where, parameters, Mall_UserBalance.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserBalance objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserBalance objects.</returns>
		protected static EntityList<Mall_UserBalance> GetMall_UserBalances(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_UserBalances(prefix, where, parameters, Mall_UserBalance.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserBalance objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_UserBalance objects.</returns>
		protected static EntityList<Mall_UserBalance> GetMall_UserBalances(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_UserBalance.SelectFieldList + "FROM [dbo].[Mall_UserBalance] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_UserBalance>(reader);
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
        protected static EntityList<Mall_UserBalance> GetMall_UserBalances(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserBalance>(SelectFieldList, "FROM [dbo].[Mall_UserBalance] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_UserBalance objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_UserBalanceCount()
        {
            return GetMall_UserBalanceCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_UserBalance objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_UserBalanceCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_UserBalance] " + where;

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
		public static partial class Mall_UserBalance_Properties
		{
			public const string ID = "ID";
			public const string UserID = "UserID";
			public const string BalanceType = "BalanceType";
			public const string BalanceValue = "BalanceValue";
			public const string Title = "Title";
			public const string Summary = "Summary";
			public const string CategoryType = "CategoryType";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string BalanceStatus = "BalanceStatus";
			public const string TradeNo = "TradeNo";
			public const string RelatedID = "RelatedID";
			public const string AmountRuleID = "AmountRuleID";
			public const string PaymentMethod = "PaymentMethod";
			public const string IsSent = "IsSent";
			public const string SentTime = "SentTime";
			public const string IsReadySendTime = "IsReadySendTime";
			public const string IsManualIncoming = "IsManualIncoming";
			public const string UserLevelApproveID = "UserLevelApproveID";
			public const string Remark = "Remark";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"BalanceType" , "int:1-充值 2-消费"},
    			 {"BalanceValue" , "decimal:"},
    			 {"Title" , "string:"},
    			 {"Summary" , "string:"},
    			 {"CategoryType" , "int:1-购买商品消费 2-微信充值 3-支付宝充值 4-订单退款返还 5-充值赠与 6-消费赠与 7-退款消费赠与取消 8-线下充值 9-业主结算 10-线下扣除"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"BalanceStatus" , "int:0-未入账 1-已入账"},
    			 {"TradeNo" , "string:"},
    			 {"RelatedID" , "int:"},
    			 {"AmountRuleID" , "int:"},
    			 {"PaymentMethod" , "string:"},
    			 {"IsSent" , "bool:"},
    			 {"SentTime" , "DateTime:"},
    			 {"IsReadySendTime" , "DateTime:"},
    			 {"IsManualIncoming" , "bool:"},
    			 {"UserLevelApproveID" , "int:"},
    			 {"Remark" , "string:"},
            };
		}
		#endregion
	}
}
