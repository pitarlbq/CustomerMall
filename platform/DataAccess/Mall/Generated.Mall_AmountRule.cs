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
	/// This object represents the properties and methods of a Mall_AmountRule.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_AmountRule 
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
		private string _title = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private decimal _startAmount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal StartAmount
		{
			[DebuggerStepThrough()]
			get { return this._startAmount; }
			set 
			{
				if (this._startAmount != value) 
				{
					this._startAmount = value;
					this.IsDirty = true;	
					OnPropertyChanged("StartAmount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _endAmount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal EndAmount
		{
			[DebuggerStepThrough()]
			get { return this._endAmount; }
			set 
			{
				if (this._endAmount != value) 
				{
					this._endAmount = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndAmount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _backAmount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal BackAmount
		{
			[DebuggerStepThrough()]
			get { return this._backAmount; }
			set 
			{
				if (this._backAmount != value) 
				{
					this._backAmount = value;
					this.IsDirty = true;	
					OnPropertyChanged("BackAmount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _backPoint = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int BackPoint
		{
			[DebuggerStepThrough()]
			get { return this._backPoint; }
			set 
			{
				if (this._backPoint != value) 
				{
					this._backPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("BackPoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _userLevelID = int.MinValue;
		/// <summary>
		/// 会员等级
		/// </summary>
        [Description("会员等级")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int UserLevelID
		{
			[DebuggerStepThrough()]
			get { return this._userLevelID; }
			set 
			{
				if (this._userLevelID != value) 
				{
					this._userLevelID = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserLevelID");
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
		private bool _isUserLevelActive = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsUserLevelActive
		{
			[DebuggerStepThrough()]
			get { return this._isUserLevelActive; }
			set 
			{
				if (this._isUserLevelActive != value) 
				{
					this._isUserLevelActive = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsUserLevelActive");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isActive = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsActive
		{
			[DebuggerStepThrough()]
			get { return this._isActive; }
			set 
			{
				if (this._isActive != value) 
				{
					this._isActive = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsActive");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _backAmountType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int BackAmountType
		{
			[DebuggerStepThrough()]
			get { return this._backAmountType; }
			set 
			{
				if (this._backAmountType != value) 
				{
					this._backAmountType = value;
					this.IsDirty = true;	
					OnPropertyChanged("BackAmountType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _backPointType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int BackPointType
		{
			[DebuggerStepThrough()]
			get { return this._backPointType; }
			set 
			{
				if (this._backPointType != value) 
				{
					this._backPointType = value;
					this.IsDirty = true;	
					OnPropertyChanged("BackPointType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _amountType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int AmountType
		{
			[DebuggerStepThrough()]
			get { return this._amountType; }
			set 
			{
				if (this._amountType != value) 
				{
					this._amountType = value;
					this.IsDirty = true;	
					OnPropertyChanged("AmountType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _additionalEarnService = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool AdditionalEarnService
		{
			[DebuggerStepThrough()]
			get { return this._additionalEarnService; }
			set 
			{
				if (this._additionalEarnService != value) 
				{
					this._additionalEarnService = value;
					this.IsDirty = true;	
					OnPropertyChanged("AdditionalEarnService");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _ruleType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RuleType
		{
			[DebuggerStepThrough()]
			get { return this._ruleType; }
			set 
			{
				if (this._ruleType != value) 
				{
					this._ruleType = value;
					this.IsDirty = true;	
					OnPropertyChanged("RuleType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isSendNow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsSendNow
		{
			[DebuggerStepThrough()]
			get { return this._isSendNow; }
			set 
			{
				if (this._isSendNow != value) 
				{
					this._isSendNow = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsSendNow");
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
		private int _sendCouponCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SendCouponCount
		{
			[DebuggerStepThrough()]
			get { return this._sendCouponCount; }
			set 
			{
				if (this._sendCouponCount != value) 
				{
					this._sendCouponCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("SendCouponCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isUseForALLProject = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsUseForALLProject
		{
			[DebuggerStepThrough()]
			get { return this._isUseForALLProject; }
			set 
			{
				if (this._isUseForALLProject != value) 
				{
					this._isUseForALLProject = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsUseForALLProject");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _popupUnTakeDay = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PopupUnTakeDay
		{
			[DebuggerStepThrough()]
			get { return this._popupUnTakeDay; }
			set 
			{
				if (this._popupUnTakeDay != value) 
				{
					this._popupUnTakeDay = value;
					this.IsDirty = true;	
					OnPropertyChanged("PopupUnTakeDay");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _popupBeforeExpireDay = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PopupBeforeExpireDay
		{
			[DebuggerStepThrough()]
			get { return this._popupBeforeExpireDay; }
			set 
			{
				if (this._popupBeforeExpireDay != value) 
				{
					this._popupBeforeExpireDay = value;
					this.IsDirty = true;	
					OnPropertyChanged("PopupBeforeExpireDay");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isUseForALLProduct = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsUseForALLProduct
		{
			[DebuggerStepThrough()]
			get { return this._isUseForALLProduct; }
			set 
			{
				if (this._isUseForALLProduct != value) 
				{
					this._isUseForALLProduct = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsUseForALLProduct");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isUseForALLService = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsUseForALLService
		{
			[DebuggerStepThrough()]
			get { return this._isUseForALLService; }
			set 
			{
				if (this._isUseForALLService != value) 
				{
					this._isUseForALLService = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsUseForALLService");
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
	[Title] nvarchar(200),
	[StartAmount] decimal(18, 2),
	[EndAmount] decimal(18, 2),
	[BackAmount] decimal(18, 2),
	[BackPoint] int,
	[UserLevelID] int,
	[Remark] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[IsUserLevelActive] bit,
	[IsActive] bit,
	[BackAmountType] int,
	[BackPointType] int,
	[AmountType] int,
	[AdditionalEarnService] bit,
	[RuleType] int,
	[IsSendNow] bit,
	[IsReadySendTime] datetime,
	[SendCouponCount] int,
	[IsUseForALLProject] bit,
	[PopupUnTakeDay] int,
	[PopupBeforeExpireDay] int,
	[IsUseForALLProduct] bit,
	[IsUseForALLService] bit
);

INSERT INTO [dbo].[Mall_AmountRule] (
	[Mall_AmountRule].[Title],
	[Mall_AmountRule].[StartAmount],
	[Mall_AmountRule].[EndAmount],
	[Mall_AmountRule].[BackAmount],
	[Mall_AmountRule].[BackPoint],
	[Mall_AmountRule].[UserLevelID],
	[Mall_AmountRule].[Remark],
	[Mall_AmountRule].[AddTime],
	[Mall_AmountRule].[AddUserName],
	[Mall_AmountRule].[IsUserLevelActive],
	[Mall_AmountRule].[IsActive],
	[Mall_AmountRule].[BackAmountType],
	[Mall_AmountRule].[BackPointType],
	[Mall_AmountRule].[AmountType],
	[Mall_AmountRule].[AdditionalEarnService],
	[Mall_AmountRule].[RuleType],
	[Mall_AmountRule].[IsSendNow],
	[Mall_AmountRule].[IsReadySendTime],
	[Mall_AmountRule].[SendCouponCount],
	[Mall_AmountRule].[IsUseForALLProject],
	[Mall_AmountRule].[PopupUnTakeDay],
	[Mall_AmountRule].[PopupBeforeExpireDay],
	[Mall_AmountRule].[IsUseForALLProduct],
	[Mall_AmountRule].[IsUseForALLService]
) 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[StartAmount],
	INSERTED.[EndAmount],
	INSERTED.[BackAmount],
	INSERTED.[BackPoint],
	INSERTED.[UserLevelID],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[IsUserLevelActive],
	INSERTED.[IsActive],
	INSERTED.[BackAmountType],
	INSERTED.[BackPointType],
	INSERTED.[AmountType],
	INSERTED.[AdditionalEarnService],
	INSERTED.[RuleType],
	INSERTED.[IsSendNow],
	INSERTED.[IsReadySendTime],
	INSERTED.[SendCouponCount],
	INSERTED.[IsUseForALLProject],
	INSERTED.[PopupUnTakeDay],
	INSERTED.[PopupBeforeExpireDay],
	INSERTED.[IsUseForALLProduct],
	INSERTED.[IsUseForALLService]
into @table
VALUES ( 
	@Title,
	@StartAmount,
	@EndAmount,
	@BackAmount,
	@BackPoint,
	@UserLevelID,
	@Remark,
	@AddTime,
	@AddUserName,
	@IsUserLevelActive,
	@IsActive,
	@BackAmountType,
	@BackPointType,
	@AmountType,
	@AdditionalEarnService,
	@RuleType,
	@IsSendNow,
	@IsReadySendTime,
	@SendCouponCount,
	@IsUseForALLProject,
	@PopupUnTakeDay,
	@PopupBeforeExpireDay,
	@IsUseForALLProduct,
	@IsUseForALLService 
); 

SELECT 
	[ID],
	[Title],
	[StartAmount],
	[EndAmount],
	[BackAmount],
	[BackPoint],
	[UserLevelID],
	[Remark],
	[AddTime],
	[AddUserName],
	[IsUserLevelActive],
	[IsActive],
	[BackAmountType],
	[BackPointType],
	[AmountType],
	[AdditionalEarnService],
	[RuleType],
	[IsSendNow],
	[IsReadySendTime],
	[SendCouponCount],
	[IsUseForALLProject],
	[PopupUnTakeDay],
	[PopupBeforeExpireDay],
	[IsUseForALLProduct],
	[IsUseForALLService] 
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
	[Title] nvarchar(200),
	[StartAmount] decimal(18, 2),
	[EndAmount] decimal(18, 2),
	[BackAmount] decimal(18, 2),
	[BackPoint] int,
	[UserLevelID] int,
	[Remark] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[IsUserLevelActive] bit,
	[IsActive] bit,
	[BackAmountType] int,
	[BackPointType] int,
	[AmountType] int,
	[AdditionalEarnService] bit,
	[RuleType] int,
	[IsSendNow] bit,
	[IsReadySendTime] datetime,
	[SendCouponCount] int,
	[IsUseForALLProject] bit,
	[PopupUnTakeDay] int,
	[PopupBeforeExpireDay] int,
	[IsUseForALLProduct] bit,
	[IsUseForALLService] bit
);

UPDATE [dbo].[Mall_AmountRule] SET 
	[Mall_AmountRule].[Title] = @Title,
	[Mall_AmountRule].[StartAmount] = @StartAmount,
	[Mall_AmountRule].[EndAmount] = @EndAmount,
	[Mall_AmountRule].[BackAmount] = @BackAmount,
	[Mall_AmountRule].[BackPoint] = @BackPoint,
	[Mall_AmountRule].[UserLevelID] = @UserLevelID,
	[Mall_AmountRule].[Remark] = @Remark,
	[Mall_AmountRule].[AddTime] = @AddTime,
	[Mall_AmountRule].[AddUserName] = @AddUserName,
	[Mall_AmountRule].[IsUserLevelActive] = @IsUserLevelActive,
	[Mall_AmountRule].[IsActive] = @IsActive,
	[Mall_AmountRule].[BackAmountType] = @BackAmountType,
	[Mall_AmountRule].[BackPointType] = @BackPointType,
	[Mall_AmountRule].[AmountType] = @AmountType,
	[Mall_AmountRule].[AdditionalEarnService] = @AdditionalEarnService,
	[Mall_AmountRule].[RuleType] = @RuleType,
	[Mall_AmountRule].[IsSendNow] = @IsSendNow,
	[Mall_AmountRule].[IsReadySendTime] = @IsReadySendTime,
	[Mall_AmountRule].[SendCouponCount] = @SendCouponCount,
	[Mall_AmountRule].[IsUseForALLProject] = @IsUseForALLProject,
	[Mall_AmountRule].[PopupUnTakeDay] = @PopupUnTakeDay,
	[Mall_AmountRule].[PopupBeforeExpireDay] = @PopupBeforeExpireDay,
	[Mall_AmountRule].[IsUseForALLProduct] = @IsUseForALLProduct,
	[Mall_AmountRule].[IsUseForALLService] = @IsUseForALLService 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[StartAmount],
	INSERTED.[EndAmount],
	INSERTED.[BackAmount],
	INSERTED.[BackPoint],
	INSERTED.[UserLevelID],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[IsUserLevelActive],
	INSERTED.[IsActive],
	INSERTED.[BackAmountType],
	INSERTED.[BackPointType],
	INSERTED.[AmountType],
	INSERTED.[AdditionalEarnService],
	INSERTED.[RuleType],
	INSERTED.[IsSendNow],
	INSERTED.[IsReadySendTime],
	INSERTED.[SendCouponCount],
	INSERTED.[IsUseForALLProject],
	INSERTED.[PopupUnTakeDay],
	INSERTED.[PopupBeforeExpireDay],
	INSERTED.[IsUseForALLProduct],
	INSERTED.[IsUseForALLService]
into @table
WHERE 
	[Mall_AmountRule].[ID] = @ID

SELECT 
	[ID],
	[Title],
	[StartAmount],
	[EndAmount],
	[BackAmount],
	[BackPoint],
	[UserLevelID],
	[Remark],
	[AddTime],
	[AddUserName],
	[IsUserLevelActive],
	[IsActive],
	[BackAmountType],
	[BackPointType],
	[AmountType],
	[AdditionalEarnService],
	[RuleType],
	[IsSendNow],
	[IsReadySendTime],
	[SendCouponCount],
	[IsUseForALLProject],
	[PopupUnTakeDay],
	[PopupBeforeExpireDay],
	[IsUseForALLProduct],
	[IsUseForALLService] 
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
DELETE FROM [dbo].[Mall_AmountRule]
WHERE 
	[Mall_AmountRule].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_AmountRule() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_AmountRule(this.ID));
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
	[Mall_AmountRule].[ID],
	[Mall_AmountRule].[Title],
	[Mall_AmountRule].[StartAmount],
	[Mall_AmountRule].[EndAmount],
	[Mall_AmountRule].[BackAmount],
	[Mall_AmountRule].[BackPoint],
	[Mall_AmountRule].[UserLevelID],
	[Mall_AmountRule].[Remark],
	[Mall_AmountRule].[AddTime],
	[Mall_AmountRule].[AddUserName],
	[Mall_AmountRule].[IsUserLevelActive],
	[Mall_AmountRule].[IsActive],
	[Mall_AmountRule].[BackAmountType],
	[Mall_AmountRule].[BackPointType],
	[Mall_AmountRule].[AmountType],
	[Mall_AmountRule].[AdditionalEarnService],
	[Mall_AmountRule].[RuleType],
	[Mall_AmountRule].[IsSendNow],
	[Mall_AmountRule].[IsReadySendTime],
	[Mall_AmountRule].[SendCouponCount],
	[Mall_AmountRule].[IsUseForALLProject],
	[Mall_AmountRule].[PopupUnTakeDay],
	[Mall_AmountRule].[PopupBeforeExpireDay],
	[Mall_AmountRule].[IsUseForALLProduct],
	[Mall_AmountRule].[IsUseForALLService]
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
                return "Mall_AmountRule";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_AmountRule into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="title">title</param>
		/// <param name="startAmount">startAmount</param>
		/// <param name="endAmount">endAmount</param>
		/// <param name="backAmount">backAmount</param>
		/// <param name="backPoint">backPoint</param>
		/// <param name="userLevelID">userLevelID</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="isUserLevelActive">isUserLevelActive</param>
		/// <param name="isActive">isActive</param>
		/// <param name="backAmountType">backAmountType</param>
		/// <param name="backPointType">backPointType</param>
		/// <param name="amountType">amountType</param>
		/// <param name="additionalEarnService">additionalEarnService</param>
		/// <param name="ruleType">ruleType</param>
		/// <param name="isSendNow">isSendNow</param>
		/// <param name="isReadySendTime">isReadySendTime</param>
		/// <param name="sendCouponCount">sendCouponCount</param>
		/// <param name="isUseForALLProject">isUseForALLProject</param>
		/// <param name="popupUnTakeDay">popupUnTakeDay</param>
		/// <param name="popupBeforeExpireDay">popupBeforeExpireDay</param>
		/// <param name="isUseForALLProduct">isUseForALLProduct</param>
		/// <param name="isUseForALLService">isUseForALLService</param>
		public static void InsertMall_AmountRule(string @title, decimal @startAmount, decimal @endAmount, decimal @backAmount, int @backPoint, int @userLevelID, string @remark, DateTime @addTime, string @addUserName, bool @isUserLevelActive, bool @isActive, int @backAmountType, int @backPointType, int @amountType, bool @additionalEarnService, int @ruleType, bool @isSendNow, DateTime @isReadySendTime, int @sendCouponCount, bool @isUseForALLProject, int @popupUnTakeDay, int @popupBeforeExpireDay, bool @isUseForALLProduct, bool @isUseForALLService)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_AmountRule(@title, @startAmount, @endAmount, @backAmount, @backPoint, @userLevelID, @remark, @addTime, @addUserName, @isUserLevelActive, @isActive, @backAmountType, @backPointType, @amountType, @additionalEarnService, @ruleType, @isSendNow, @isReadySendTime, @sendCouponCount, @isUseForALLProject, @popupUnTakeDay, @popupBeforeExpireDay, @isUseForALLProduct, @isUseForALLService, helper);
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
		/// Insert a Mall_AmountRule into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="title">title</param>
		/// <param name="startAmount">startAmount</param>
		/// <param name="endAmount">endAmount</param>
		/// <param name="backAmount">backAmount</param>
		/// <param name="backPoint">backPoint</param>
		/// <param name="userLevelID">userLevelID</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="isUserLevelActive">isUserLevelActive</param>
		/// <param name="isActive">isActive</param>
		/// <param name="backAmountType">backAmountType</param>
		/// <param name="backPointType">backPointType</param>
		/// <param name="amountType">amountType</param>
		/// <param name="additionalEarnService">additionalEarnService</param>
		/// <param name="ruleType">ruleType</param>
		/// <param name="isSendNow">isSendNow</param>
		/// <param name="isReadySendTime">isReadySendTime</param>
		/// <param name="sendCouponCount">sendCouponCount</param>
		/// <param name="isUseForALLProject">isUseForALLProject</param>
		/// <param name="popupUnTakeDay">popupUnTakeDay</param>
		/// <param name="popupBeforeExpireDay">popupBeforeExpireDay</param>
		/// <param name="isUseForALLProduct">isUseForALLProduct</param>
		/// <param name="isUseForALLService">isUseForALLService</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_AmountRule(string @title, decimal @startAmount, decimal @endAmount, decimal @backAmount, int @backPoint, int @userLevelID, string @remark, DateTime @addTime, string @addUserName, bool @isUserLevelActive, bool @isActive, int @backAmountType, int @backPointType, int @amountType, bool @additionalEarnService, int @ruleType, bool @isSendNow, DateTime @isReadySendTime, int @sendCouponCount, bool @isUseForALLProject, int @popupUnTakeDay, int @popupBeforeExpireDay, bool @isUseForALLProduct, bool @isUseForALLService, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Title] nvarchar(200),
	[StartAmount] decimal(18, 2),
	[EndAmount] decimal(18, 2),
	[BackAmount] decimal(18, 2),
	[BackPoint] int,
	[UserLevelID] int,
	[Remark] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[IsUserLevelActive] bit,
	[IsActive] bit,
	[BackAmountType] int,
	[BackPointType] int,
	[AmountType] int,
	[AdditionalEarnService] bit,
	[RuleType] int,
	[IsSendNow] bit,
	[IsReadySendTime] datetime,
	[SendCouponCount] int,
	[IsUseForALLProject] bit,
	[PopupUnTakeDay] int,
	[PopupBeforeExpireDay] int,
	[IsUseForALLProduct] bit,
	[IsUseForALLService] bit
);

INSERT INTO [dbo].[Mall_AmountRule] (
	[Mall_AmountRule].[Title],
	[Mall_AmountRule].[StartAmount],
	[Mall_AmountRule].[EndAmount],
	[Mall_AmountRule].[BackAmount],
	[Mall_AmountRule].[BackPoint],
	[Mall_AmountRule].[UserLevelID],
	[Mall_AmountRule].[Remark],
	[Mall_AmountRule].[AddTime],
	[Mall_AmountRule].[AddUserName],
	[Mall_AmountRule].[IsUserLevelActive],
	[Mall_AmountRule].[IsActive],
	[Mall_AmountRule].[BackAmountType],
	[Mall_AmountRule].[BackPointType],
	[Mall_AmountRule].[AmountType],
	[Mall_AmountRule].[AdditionalEarnService],
	[Mall_AmountRule].[RuleType],
	[Mall_AmountRule].[IsSendNow],
	[Mall_AmountRule].[IsReadySendTime],
	[Mall_AmountRule].[SendCouponCount],
	[Mall_AmountRule].[IsUseForALLProject],
	[Mall_AmountRule].[PopupUnTakeDay],
	[Mall_AmountRule].[PopupBeforeExpireDay],
	[Mall_AmountRule].[IsUseForALLProduct],
	[Mall_AmountRule].[IsUseForALLService]
) 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[StartAmount],
	INSERTED.[EndAmount],
	INSERTED.[BackAmount],
	INSERTED.[BackPoint],
	INSERTED.[UserLevelID],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[IsUserLevelActive],
	INSERTED.[IsActive],
	INSERTED.[BackAmountType],
	INSERTED.[BackPointType],
	INSERTED.[AmountType],
	INSERTED.[AdditionalEarnService],
	INSERTED.[RuleType],
	INSERTED.[IsSendNow],
	INSERTED.[IsReadySendTime],
	INSERTED.[SendCouponCount],
	INSERTED.[IsUseForALLProject],
	INSERTED.[PopupUnTakeDay],
	INSERTED.[PopupBeforeExpireDay],
	INSERTED.[IsUseForALLProduct],
	INSERTED.[IsUseForALLService]
into @table
VALUES ( 
	@Title,
	@StartAmount,
	@EndAmount,
	@BackAmount,
	@BackPoint,
	@UserLevelID,
	@Remark,
	@AddTime,
	@AddUserName,
	@IsUserLevelActive,
	@IsActive,
	@BackAmountType,
	@BackPointType,
	@AmountType,
	@AdditionalEarnService,
	@RuleType,
	@IsSendNow,
	@IsReadySendTime,
	@SendCouponCount,
	@IsUseForALLProject,
	@PopupUnTakeDay,
	@PopupBeforeExpireDay,
	@IsUseForALLProduct,
	@IsUseForALLService 
); 

SELECT 
	[ID],
	[Title],
	[StartAmount],
	[EndAmount],
	[BackAmount],
	[BackPoint],
	[UserLevelID],
	[Remark],
	[AddTime],
	[AddUserName],
	[IsUserLevelActive],
	[IsActive],
	[BackAmountType],
	[BackPointType],
	[AmountType],
	[AdditionalEarnService],
	[RuleType],
	[IsSendNow],
	[IsReadySendTime],
	[SendCouponCount],
	[IsUseForALLProject],
	[PopupUnTakeDay],
	[PopupBeforeExpireDay],
	[IsUseForALLProduct],
	[IsUseForALLService] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@StartAmount", EntityBase.GetDatabaseValue(@startAmount)));
			parameters.Add(new SqlParameter("@EndAmount", EntityBase.GetDatabaseValue(@endAmount)));
			parameters.Add(new SqlParameter("@BackAmount", EntityBase.GetDatabaseValue(@backAmount)));
			parameters.Add(new SqlParameter("@BackPoint", EntityBase.GetDatabaseValue(@backPoint)));
			parameters.Add(new SqlParameter("@UserLevelID", EntityBase.GetDatabaseValue(@userLevelID)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@IsUserLevelActive", @isUserLevelActive));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@BackAmountType", EntityBase.GetDatabaseValue(@backAmountType)));
			parameters.Add(new SqlParameter("@BackPointType", EntityBase.GetDatabaseValue(@backPointType)));
			parameters.Add(new SqlParameter("@AmountType", EntityBase.GetDatabaseValue(@amountType)));
			parameters.Add(new SqlParameter("@AdditionalEarnService", @additionalEarnService));
			parameters.Add(new SqlParameter("@RuleType", EntityBase.GetDatabaseValue(@ruleType)));
			parameters.Add(new SqlParameter("@IsSendNow", @isSendNow));
			parameters.Add(new SqlParameter("@IsReadySendTime", EntityBase.GetDatabaseValue(@isReadySendTime)));
			parameters.Add(new SqlParameter("@SendCouponCount", EntityBase.GetDatabaseValue(@sendCouponCount)));
			parameters.Add(new SqlParameter("@IsUseForALLProject", @isUseForALLProject));
			parameters.Add(new SqlParameter("@PopupUnTakeDay", EntityBase.GetDatabaseValue(@popupUnTakeDay)));
			parameters.Add(new SqlParameter("@PopupBeforeExpireDay", EntityBase.GetDatabaseValue(@popupBeforeExpireDay)));
			parameters.Add(new SqlParameter("@IsUseForALLProduct", @isUseForALLProduct));
			parameters.Add(new SqlParameter("@IsUseForALLService", @isUseForALLService));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_AmountRule into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="title">title</param>
		/// <param name="startAmount">startAmount</param>
		/// <param name="endAmount">endAmount</param>
		/// <param name="backAmount">backAmount</param>
		/// <param name="backPoint">backPoint</param>
		/// <param name="userLevelID">userLevelID</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="isUserLevelActive">isUserLevelActive</param>
		/// <param name="isActive">isActive</param>
		/// <param name="backAmountType">backAmountType</param>
		/// <param name="backPointType">backPointType</param>
		/// <param name="amountType">amountType</param>
		/// <param name="additionalEarnService">additionalEarnService</param>
		/// <param name="ruleType">ruleType</param>
		/// <param name="isSendNow">isSendNow</param>
		/// <param name="isReadySendTime">isReadySendTime</param>
		/// <param name="sendCouponCount">sendCouponCount</param>
		/// <param name="isUseForALLProject">isUseForALLProject</param>
		/// <param name="popupUnTakeDay">popupUnTakeDay</param>
		/// <param name="popupBeforeExpireDay">popupBeforeExpireDay</param>
		/// <param name="isUseForALLProduct">isUseForALLProduct</param>
		/// <param name="isUseForALLService">isUseForALLService</param>
		public static void UpdateMall_AmountRule(int @iD, string @title, decimal @startAmount, decimal @endAmount, decimal @backAmount, int @backPoint, int @userLevelID, string @remark, DateTime @addTime, string @addUserName, bool @isUserLevelActive, bool @isActive, int @backAmountType, int @backPointType, int @amountType, bool @additionalEarnService, int @ruleType, bool @isSendNow, DateTime @isReadySendTime, int @sendCouponCount, bool @isUseForALLProject, int @popupUnTakeDay, int @popupBeforeExpireDay, bool @isUseForALLProduct, bool @isUseForALLService)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_AmountRule(@iD, @title, @startAmount, @endAmount, @backAmount, @backPoint, @userLevelID, @remark, @addTime, @addUserName, @isUserLevelActive, @isActive, @backAmountType, @backPointType, @amountType, @additionalEarnService, @ruleType, @isSendNow, @isReadySendTime, @sendCouponCount, @isUseForALLProject, @popupUnTakeDay, @popupBeforeExpireDay, @isUseForALLProduct, @isUseForALLService, helper);
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
		/// Updates a Mall_AmountRule into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="title">title</param>
		/// <param name="startAmount">startAmount</param>
		/// <param name="endAmount">endAmount</param>
		/// <param name="backAmount">backAmount</param>
		/// <param name="backPoint">backPoint</param>
		/// <param name="userLevelID">userLevelID</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="isUserLevelActive">isUserLevelActive</param>
		/// <param name="isActive">isActive</param>
		/// <param name="backAmountType">backAmountType</param>
		/// <param name="backPointType">backPointType</param>
		/// <param name="amountType">amountType</param>
		/// <param name="additionalEarnService">additionalEarnService</param>
		/// <param name="ruleType">ruleType</param>
		/// <param name="isSendNow">isSendNow</param>
		/// <param name="isReadySendTime">isReadySendTime</param>
		/// <param name="sendCouponCount">sendCouponCount</param>
		/// <param name="isUseForALLProject">isUseForALLProject</param>
		/// <param name="popupUnTakeDay">popupUnTakeDay</param>
		/// <param name="popupBeforeExpireDay">popupBeforeExpireDay</param>
		/// <param name="isUseForALLProduct">isUseForALLProduct</param>
		/// <param name="isUseForALLService">isUseForALLService</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_AmountRule(int @iD, string @title, decimal @startAmount, decimal @endAmount, decimal @backAmount, int @backPoint, int @userLevelID, string @remark, DateTime @addTime, string @addUserName, bool @isUserLevelActive, bool @isActive, int @backAmountType, int @backPointType, int @amountType, bool @additionalEarnService, int @ruleType, bool @isSendNow, DateTime @isReadySendTime, int @sendCouponCount, bool @isUseForALLProject, int @popupUnTakeDay, int @popupBeforeExpireDay, bool @isUseForALLProduct, bool @isUseForALLService, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Title] nvarchar(200),
	[StartAmount] decimal(18, 2),
	[EndAmount] decimal(18, 2),
	[BackAmount] decimal(18, 2),
	[BackPoint] int,
	[UserLevelID] int,
	[Remark] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[IsUserLevelActive] bit,
	[IsActive] bit,
	[BackAmountType] int,
	[BackPointType] int,
	[AmountType] int,
	[AdditionalEarnService] bit,
	[RuleType] int,
	[IsSendNow] bit,
	[IsReadySendTime] datetime,
	[SendCouponCount] int,
	[IsUseForALLProject] bit,
	[PopupUnTakeDay] int,
	[PopupBeforeExpireDay] int,
	[IsUseForALLProduct] bit,
	[IsUseForALLService] bit
);

UPDATE [dbo].[Mall_AmountRule] SET 
	[Mall_AmountRule].[Title] = @Title,
	[Mall_AmountRule].[StartAmount] = @StartAmount,
	[Mall_AmountRule].[EndAmount] = @EndAmount,
	[Mall_AmountRule].[BackAmount] = @BackAmount,
	[Mall_AmountRule].[BackPoint] = @BackPoint,
	[Mall_AmountRule].[UserLevelID] = @UserLevelID,
	[Mall_AmountRule].[Remark] = @Remark,
	[Mall_AmountRule].[AddTime] = @AddTime,
	[Mall_AmountRule].[AddUserName] = @AddUserName,
	[Mall_AmountRule].[IsUserLevelActive] = @IsUserLevelActive,
	[Mall_AmountRule].[IsActive] = @IsActive,
	[Mall_AmountRule].[BackAmountType] = @BackAmountType,
	[Mall_AmountRule].[BackPointType] = @BackPointType,
	[Mall_AmountRule].[AmountType] = @AmountType,
	[Mall_AmountRule].[AdditionalEarnService] = @AdditionalEarnService,
	[Mall_AmountRule].[RuleType] = @RuleType,
	[Mall_AmountRule].[IsSendNow] = @IsSendNow,
	[Mall_AmountRule].[IsReadySendTime] = @IsReadySendTime,
	[Mall_AmountRule].[SendCouponCount] = @SendCouponCount,
	[Mall_AmountRule].[IsUseForALLProject] = @IsUseForALLProject,
	[Mall_AmountRule].[PopupUnTakeDay] = @PopupUnTakeDay,
	[Mall_AmountRule].[PopupBeforeExpireDay] = @PopupBeforeExpireDay,
	[Mall_AmountRule].[IsUseForALLProduct] = @IsUseForALLProduct,
	[Mall_AmountRule].[IsUseForALLService] = @IsUseForALLService 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[StartAmount],
	INSERTED.[EndAmount],
	INSERTED.[BackAmount],
	INSERTED.[BackPoint],
	INSERTED.[UserLevelID],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[IsUserLevelActive],
	INSERTED.[IsActive],
	INSERTED.[BackAmountType],
	INSERTED.[BackPointType],
	INSERTED.[AmountType],
	INSERTED.[AdditionalEarnService],
	INSERTED.[RuleType],
	INSERTED.[IsSendNow],
	INSERTED.[IsReadySendTime],
	INSERTED.[SendCouponCount],
	INSERTED.[IsUseForALLProject],
	INSERTED.[PopupUnTakeDay],
	INSERTED.[PopupBeforeExpireDay],
	INSERTED.[IsUseForALLProduct],
	INSERTED.[IsUseForALLService]
into @table
WHERE 
	[Mall_AmountRule].[ID] = @ID

SELECT 
	[ID],
	[Title],
	[StartAmount],
	[EndAmount],
	[BackAmount],
	[BackPoint],
	[UserLevelID],
	[Remark],
	[AddTime],
	[AddUserName],
	[IsUserLevelActive],
	[IsActive],
	[BackAmountType],
	[BackPointType],
	[AmountType],
	[AdditionalEarnService],
	[RuleType],
	[IsSendNow],
	[IsReadySendTime],
	[SendCouponCount],
	[IsUseForALLProject],
	[PopupUnTakeDay],
	[PopupBeforeExpireDay],
	[IsUseForALLProduct],
	[IsUseForALLService] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@StartAmount", EntityBase.GetDatabaseValue(@startAmount)));
			parameters.Add(new SqlParameter("@EndAmount", EntityBase.GetDatabaseValue(@endAmount)));
			parameters.Add(new SqlParameter("@BackAmount", EntityBase.GetDatabaseValue(@backAmount)));
			parameters.Add(new SqlParameter("@BackPoint", EntityBase.GetDatabaseValue(@backPoint)));
			parameters.Add(new SqlParameter("@UserLevelID", EntityBase.GetDatabaseValue(@userLevelID)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@IsUserLevelActive", @isUserLevelActive));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@BackAmountType", EntityBase.GetDatabaseValue(@backAmountType)));
			parameters.Add(new SqlParameter("@BackPointType", EntityBase.GetDatabaseValue(@backPointType)));
			parameters.Add(new SqlParameter("@AmountType", EntityBase.GetDatabaseValue(@amountType)));
			parameters.Add(new SqlParameter("@AdditionalEarnService", @additionalEarnService));
			parameters.Add(new SqlParameter("@RuleType", EntityBase.GetDatabaseValue(@ruleType)));
			parameters.Add(new SqlParameter("@IsSendNow", @isSendNow));
			parameters.Add(new SqlParameter("@IsReadySendTime", EntityBase.GetDatabaseValue(@isReadySendTime)));
			parameters.Add(new SqlParameter("@SendCouponCount", EntityBase.GetDatabaseValue(@sendCouponCount)));
			parameters.Add(new SqlParameter("@IsUseForALLProject", @isUseForALLProject));
			parameters.Add(new SqlParameter("@PopupUnTakeDay", EntityBase.GetDatabaseValue(@popupUnTakeDay)));
			parameters.Add(new SqlParameter("@PopupBeforeExpireDay", EntityBase.GetDatabaseValue(@popupBeforeExpireDay)));
			parameters.Add(new SqlParameter("@IsUseForALLProduct", @isUseForALLProduct));
			parameters.Add(new SqlParameter("@IsUseForALLService", @isUseForALLService));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_AmountRule from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_AmountRule(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_AmountRule(@iD, helper);
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
		/// Deletes a Mall_AmountRule from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_AmountRule(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_AmountRule]
WHERE 
	[Mall_AmountRule].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_AmountRule object.
		/// </summary>
		/// <returns>The newly created Mall_AmountRule object.</returns>
		public static Mall_AmountRule CreateMall_AmountRule()
		{
			return InitializeNew<Mall_AmountRule>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_AmountRule by a Mall_AmountRule's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_AmountRule</returns>
		public static Mall_AmountRule GetMall_AmountRule(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_AmountRule.SelectFieldList + @"
FROM [dbo].[Mall_AmountRule] 
WHERE 
	[Mall_AmountRule].[ID] = @ID " + Mall_AmountRule.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_AmountRule>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_AmountRule by a Mall_AmountRule's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_AmountRule</returns>
		public static Mall_AmountRule GetMall_AmountRule(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_AmountRule.SelectFieldList + @"
FROM [dbo].[Mall_AmountRule] 
WHERE 
	[Mall_AmountRule].[ID] = @ID " + Mall_AmountRule.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_AmountRule>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRule objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_AmountRule objects.</returns>
		public static EntityList<Mall_AmountRule> GetMall_AmountRules()
		{
			string commandText = @"
SELECT " + Mall_AmountRule.SelectFieldList + "FROM [dbo].[Mall_AmountRule] " + Mall_AmountRule.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_AmountRule>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_AmountRule objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_AmountRule objects.</returns>
        public static EntityList<Mall_AmountRule> GetMall_AmountRules(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_AmountRule>(SelectFieldList, "FROM [dbo].[Mall_AmountRule]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_AmountRule objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_AmountRule objects.</returns>
        public static EntityList<Mall_AmountRule> GetMall_AmountRules(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_AmountRule>(SelectFieldList, "FROM [dbo].[Mall_AmountRule]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_AmountRule objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_AmountRule objects.</returns>
		protected static EntityList<Mall_AmountRule> GetMall_AmountRules(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_AmountRules(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRule objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_AmountRule objects.</returns>
		protected static EntityList<Mall_AmountRule> GetMall_AmountRules(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_AmountRules(string.Empty, where, parameters, Mall_AmountRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_AmountRule objects.</returns>
		protected static EntityList<Mall_AmountRule> GetMall_AmountRules(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_AmountRules(prefix, where, parameters, Mall_AmountRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_AmountRule objects.</returns>
		protected static EntityList<Mall_AmountRule> GetMall_AmountRules(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_AmountRules(string.Empty, where, parameters, Mall_AmountRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_AmountRule objects.</returns>
		protected static EntityList<Mall_AmountRule> GetMall_AmountRules(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_AmountRules(prefix, where, parameters, Mall_AmountRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRule objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_AmountRule objects.</returns>
		protected static EntityList<Mall_AmountRule> GetMall_AmountRules(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_AmountRule.SelectFieldList + "FROM [dbo].[Mall_AmountRule] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_AmountRule>(reader);
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
        protected static EntityList<Mall_AmountRule> GetMall_AmountRules(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_AmountRule>(SelectFieldList, "FROM [dbo].[Mall_AmountRule] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_AmountRule objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_AmountRuleCount()
        {
            return GetMall_AmountRuleCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_AmountRule objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_AmountRuleCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_AmountRule] " + where;

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
		public static partial class Mall_AmountRule_Properties
		{
			public const string ID = "ID";
			public const string Title = "Title";
			public const string StartAmount = "StartAmount";
			public const string EndAmount = "EndAmount";
			public const string BackAmount = "BackAmount";
			public const string BackPoint = "BackPoint";
			public const string UserLevelID = "UserLevelID";
			public const string Remark = "Remark";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string IsUserLevelActive = "IsUserLevelActive";
			public const string IsActive = "IsActive";
			public const string BackAmountType = "BackAmountType";
			public const string BackPointType = "BackPointType";
			public const string AmountType = "AmountType";
			public const string AdditionalEarnService = "AdditionalEarnService";
			public const string RuleType = "RuleType";
			public const string IsSendNow = "IsSendNow";
			public const string IsReadySendTime = "IsReadySendTime";
			public const string SendCouponCount = "SendCouponCount";
			public const string IsUseForALLProject = "IsUseForALLProject";
			public const string PopupUnTakeDay = "PopupUnTakeDay";
			public const string PopupBeforeExpireDay = "PopupBeforeExpireDay";
			public const string IsUseForALLProduct = "IsUseForALLProduct";
			public const string IsUseForALLService = "IsUseForALLService";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Title" , "string:"},
    			 {"StartAmount" , "decimal:"},
    			 {"EndAmount" , "decimal:"},
    			 {"BackAmount" , "decimal:"},
    			 {"BackPoint" , "int:"},
    			 {"UserLevelID" , "int:会员等级"},
    			 {"Remark" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"IsUserLevelActive" , "bool:"},
    			 {"IsActive" , "bool:"},
    			 {"BackAmountType" , "int:"},
    			 {"BackPointType" , "int:"},
    			 {"AmountType" , "int:"},
    			 {"AdditionalEarnService" , "bool:"},
    			 {"RuleType" , "int:"},
    			 {"IsSendNow" , "bool:"},
    			 {"IsReadySendTime" , "DateTime:"},
    			 {"SendCouponCount" , "int:"},
    			 {"IsUseForALLProject" , "bool:"},
    			 {"PopupUnTakeDay" , "int:"},
    			 {"PopupBeforeExpireDay" , "int:"},
    			 {"IsUseForALLProduct" , "bool:"},
    			 {"IsUseForALLService" , "bool:"},
            };
		}
		#endregion
	}
}
