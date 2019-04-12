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
	/// This object represents the properties and methods of a Mall_UserJiXiaoPoint.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_UserJiXiaoPoint 
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
		private int _pointType = int.MinValue;
		/// <summary>
		/// 1-充值 2-消费 3-积分兑换
		/// </summary>
        [Description("1-充值 2-消费 3-积分兑换")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int PointType
		{
			[DebuggerStepThrough()]
			get { return this._pointType; }
			set 
			{
				if (this._pointType != value) 
				{
					this._pointType = value;
					this.IsDirty = true;	
					OnPropertyChanged("PointType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _pointValue = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int PointValue
		{
			[DebuggerStepThrough()]
			get { return this._pointValue; }
			set 
			{
				if (this._pointValue != value) 
				{
					this._pointValue = value;
					this.IsDirty = true;	
					OnPropertyChanged("PointValue");
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
		/// 1-业绩考核奖励 2-业绩考核扣除 3-积分兑换获取 4-积分提现
		/// </summary>
        [Description("1-业绩考核奖励 2-业绩考核扣除 3-积分兑换获取 4-积分提现")]
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
		private int _pointStatus = int.MinValue;
		/// <summary>
		/// 0-未入账 1-已入账
		/// </summary>
        [Description("0-未入账 1-已入账")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int PointStatus
		{
			[DebuggerStepThrough()]
			get { return this._pointStatus; }
			set 
			{
				if (this._pointStatus != value) 
				{
					this._pointStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("PointStatus");
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
		private int _pointRuleID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PointRuleID
		{
			[DebuggerStepThrough()]
			get { return this._pointRuleID; }
			set 
			{
				if (this._pointRuleID != value) 
				{
					this._pointRuleID = value;
					this.IsDirty = true;	
					OnPropertyChanged("PointRuleID");
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
		private int _fixedPointMonth = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int FixedPointMonth
		{
			[DebuggerStepThrough()]
			get { return this._fixedPointMonth; }
			set 
			{
				if (this._fixedPointMonth != value) 
				{
					this._fixedPointMonth = value;
					this.IsDirty = true;	
					OnPropertyChanged("FixedPointMonth");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _fixedPointDateTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime FixedPointDateTime
		{
			[DebuggerStepThrough()]
			get { return this._fixedPointDateTime; }
			set 
			{
				if (this._fixedPointDateTime != value) 
				{
					this._fixedPointDateTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("FixedPointDateTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _ruleID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RuleID
		{
			[DebuggerStepThrough()]
			get { return this._ruleID; }
			set 
			{
				if (this._ruleID != value) 
				{
					this._ruleID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RuleID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _infoID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int InfoID
		{
			[DebuggerStepThrough()]
			get { return this._infoID; }
			set 
			{
				if (this._infoID != value) 
				{
					this._infoID = value;
					this.IsDirty = true;	
					OnPropertyChanged("InfoID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _infoName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string InfoName
		{
			[DebuggerStepThrough()]
			get { return this._infoName; }
			set 
			{
				if (this._infoName != value) 
				{
					this._infoName = value;
					this.IsDirty = true;	
					OnPropertyChanged("InfoName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _categoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CategoryName
		{
			[DebuggerStepThrough()]
			get { return this._categoryName; }
			set 
			{
				if (this._categoryName != value) 
				{
					this._categoryName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CategoryName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _earnType = int.MinValue;
		/// <summary>
		/// 1-公司发放 2-积分兑换 3-积分提现
		/// </summary>
        [Description("1-公司发放 2-积分兑换 3-积分提现")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int EarnType
		{
			[DebuggerStepThrough()]
			get { return this._earnType; }
			set 
			{
				if (this._earnType != value) 
				{
					this._earnType = value;
					this.IsDirty = true;	
					OnPropertyChanged("EarnType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveUserName
		{
			[DebuggerStepThrough()]
			get { return this._approveUserName; }
			set 
			{
				if (this._approveUserName != value) 
				{
					this._approveUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveUserName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _approveTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ApproveTime
		{
			[DebuggerStepThrough()]
			get { return this._approveTime; }
			set 
			{
				if (this._approveTime != value) 
				{
					this._approveTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveRemark
		{
			[DebuggerStepThrough()]
			get { return this._approveRemark; }
			set 
			{
				if (this._approveRemark != value) 
				{
					this._approveRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveRemark");
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
	[PointType] int,
	[PointValue] int,
	[Title] nvarchar(200),
	[Summary] ntext,
	[CategoryType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(100),
	[PointStatus] int,
	[TradeNo] nvarchar(200),
	[RelatedID] int,
	[PointRuleID] int,
	[AmountRuleID] int,
	[FixedPointMonth] int,
	[FixedPointDateTime] datetime,
	[RuleID] int,
	[InfoID] int,
	[InfoName] nvarchar(200),
	[CategoryName] nvarchar(200),
	[EarnType] int,
	[ApproveUserName] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveRemark] ntext,
	[Remark] ntext
);

INSERT INTO [dbo].[Mall_UserJiXiaoPoint] (
	[Mall_UserJiXiaoPoint].[UserID],
	[Mall_UserJiXiaoPoint].[PointType],
	[Mall_UserJiXiaoPoint].[PointValue],
	[Mall_UserJiXiaoPoint].[Title],
	[Mall_UserJiXiaoPoint].[Summary],
	[Mall_UserJiXiaoPoint].[CategoryType],
	[Mall_UserJiXiaoPoint].[AddTime],
	[Mall_UserJiXiaoPoint].[AddUserName],
	[Mall_UserJiXiaoPoint].[PointStatus],
	[Mall_UserJiXiaoPoint].[TradeNo],
	[Mall_UserJiXiaoPoint].[RelatedID],
	[Mall_UserJiXiaoPoint].[PointRuleID],
	[Mall_UserJiXiaoPoint].[AmountRuleID],
	[Mall_UserJiXiaoPoint].[FixedPointMonth],
	[Mall_UserJiXiaoPoint].[FixedPointDateTime],
	[Mall_UserJiXiaoPoint].[RuleID],
	[Mall_UserJiXiaoPoint].[InfoID],
	[Mall_UserJiXiaoPoint].[InfoName],
	[Mall_UserJiXiaoPoint].[CategoryName],
	[Mall_UserJiXiaoPoint].[EarnType],
	[Mall_UserJiXiaoPoint].[ApproveUserName],
	[Mall_UserJiXiaoPoint].[ApproveTime],
	[Mall_UserJiXiaoPoint].[ApproveRemark],
	[Mall_UserJiXiaoPoint].[Remark]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[PointType],
	INSERTED.[PointValue],
	INSERTED.[Title],
	INSERTED.[Summary],
	INSERTED.[CategoryType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[PointStatus],
	INSERTED.[TradeNo],
	INSERTED.[RelatedID],
	INSERTED.[PointRuleID],
	INSERTED.[AmountRuleID],
	INSERTED.[FixedPointMonth],
	INSERTED.[FixedPointDateTime],
	INSERTED.[RuleID],
	INSERTED.[InfoID],
	INSERTED.[InfoName],
	INSERTED.[CategoryName],
	INSERTED.[EarnType],
	INSERTED.[ApproveUserName],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[Remark]
into @table
VALUES ( 
	@UserID,
	@PointType,
	@PointValue,
	@Title,
	@Summary,
	@CategoryType,
	@AddTime,
	@AddUserName,
	@PointStatus,
	@TradeNo,
	@RelatedID,
	@PointRuleID,
	@AmountRuleID,
	@FixedPointMonth,
	@FixedPointDateTime,
	@RuleID,
	@InfoID,
	@InfoName,
	@CategoryName,
	@EarnType,
	@ApproveUserName,
	@ApproveTime,
	@ApproveRemark,
	@Remark 
); 

SELECT 
	[ID],
	[UserID],
	[PointType],
	[PointValue],
	[Title],
	[Summary],
	[CategoryType],
	[AddTime],
	[AddUserName],
	[PointStatus],
	[TradeNo],
	[RelatedID],
	[PointRuleID],
	[AmountRuleID],
	[FixedPointMonth],
	[FixedPointDateTime],
	[RuleID],
	[InfoID],
	[InfoName],
	[CategoryName],
	[EarnType],
	[ApproveUserName],
	[ApproveTime],
	[ApproveRemark],
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
	[PointType] int,
	[PointValue] int,
	[Title] nvarchar(200),
	[Summary] ntext,
	[CategoryType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(100),
	[PointStatus] int,
	[TradeNo] nvarchar(200),
	[RelatedID] int,
	[PointRuleID] int,
	[AmountRuleID] int,
	[FixedPointMonth] int,
	[FixedPointDateTime] datetime,
	[RuleID] int,
	[InfoID] int,
	[InfoName] nvarchar(200),
	[CategoryName] nvarchar(200),
	[EarnType] int,
	[ApproveUserName] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveRemark] ntext,
	[Remark] ntext
);

UPDATE [dbo].[Mall_UserJiXiaoPoint] SET 
	[Mall_UserJiXiaoPoint].[UserID] = @UserID,
	[Mall_UserJiXiaoPoint].[PointType] = @PointType,
	[Mall_UserJiXiaoPoint].[PointValue] = @PointValue,
	[Mall_UserJiXiaoPoint].[Title] = @Title,
	[Mall_UserJiXiaoPoint].[Summary] = @Summary,
	[Mall_UserJiXiaoPoint].[CategoryType] = @CategoryType,
	[Mall_UserJiXiaoPoint].[AddTime] = @AddTime,
	[Mall_UserJiXiaoPoint].[AddUserName] = @AddUserName,
	[Mall_UserJiXiaoPoint].[PointStatus] = @PointStatus,
	[Mall_UserJiXiaoPoint].[TradeNo] = @TradeNo,
	[Mall_UserJiXiaoPoint].[RelatedID] = @RelatedID,
	[Mall_UserJiXiaoPoint].[PointRuleID] = @PointRuleID,
	[Mall_UserJiXiaoPoint].[AmountRuleID] = @AmountRuleID,
	[Mall_UserJiXiaoPoint].[FixedPointMonth] = @FixedPointMonth,
	[Mall_UserJiXiaoPoint].[FixedPointDateTime] = @FixedPointDateTime,
	[Mall_UserJiXiaoPoint].[RuleID] = @RuleID,
	[Mall_UserJiXiaoPoint].[InfoID] = @InfoID,
	[Mall_UserJiXiaoPoint].[InfoName] = @InfoName,
	[Mall_UserJiXiaoPoint].[CategoryName] = @CategoryName,
	[Mall_UserJiXiaoPoint].[EarnType] = @EarnType,
	[Mall_UserJiXiaoPoint].[ApproveUserName] = @ApproveUserName,
	[Mall_UserJiXiaoPoint].[ApproveTime] = @ApproveTime,
	[Mall_UserJiXiaoPoint].[ApproveRemark] = @ApproveRemark,
	[Mall_UserJiXiaoPoint].[Remark] = @Remark 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[PointType],
	INSERTED.[PointValue],
	INSERTED.[Title],
	INSERTED.[Summary],
	INSERTED.[CategoryType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[PointStatus],
	INSERTED.[TradeNo],
	INSERTED.[RelatedID],
	INSERTED.[PointRuleID],
	INSERTED.[AmountRuleID],
	INSERTED.[FixedPointMonth],
	INSERTED.[FixedPointDateTime],
	INSERTED.[RuleID],
	INSERTED.[InfoID],
	INSERTED.[InfoName],
	INSERTED.[CategoryName],
	INSERTED.[EarnType],
	INSERTED.[ApproveUserName],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[Remark]
into @table
WHERE 
	[Mall_UserJiXiaoPoint].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[PointType],
	[PointValue],
	[Title],
	[Summary],
	[CategoryType],
	[AddTime],
	[AddUserName],
	[PointStatus],
	[TradeNo],
	[RelatedID],
	[PointRuleID],
	[AmountRuleID],
	[FixedPointMonth],
	[FixedPointDateTime],
	[RuleID],
	[InfoID],
	[InfoName],
	[CategoryName],
	[EarnType],
	[ApproveUserName],
	[ApproveTime],
	[ApproveRemark],
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
DELETE FROM [dbo].[Mall_UserJiXiaoPoint]
WHERE 
	[Mall_UserJiXiaoPoint].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_UserJiXiaoPoint() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_UserJiXiaoPoint(this.ID));
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
	[Mall_UserJiXiaoPoint].[ID],
	[Mall_UserJiXiaoPoint].[UserID],
	[Mall_UserJiXiaoPoint].[PointType],
	[Mall_UserJiXiaoPoint].[PointValue],
	[Mall_UserJiXiaoPoint].[Title],
	[Mall_UserJiXiaoPoint].[Summary],
	[Mall_UserJiXiaoPoint].[CategoryType],
	[Mall_UserJiXiaoPoint].[AddTime],
	[Mall_UserJiXiaoPoint].[AddUserName],
	[Mall_UserJiXiaoPoint].[PointStatus],
	[Mall_UserJiXiaoPoint].[TradeNo],
	[Mall_UserJiXiaoPoint].[RelatedID],
	[Mall_UserJiXiaoPoint].[PointRuleID],
	[Mall_UserJiXiaoPoint].[AmountRuleID],
	[Mall_UserJiXiaoPoint].[FixedPointMonth],
	[Mall_UserJiXiaoPoint].[FixedPointDateTime],
	[Mall_UserJiXiaoPoint].[RuleID],
	[Mall_UserJiXiaoPoint].[InfoID],
	[Mall_UserJiXiaoPoint].[InfoName],
	[Mall_UserJiXiaoPoint].[CategoryName],
	[Mall_UserJiXiaoPoint].[EarnType],
	[Mall_UserJiXiaoPoint].[ApproveUserName],
	[Mall_UserJiXiaoPoint].[ApproveTime],
	[Mall_UserJiXiaoPoint].[ApproveRemark],
	[Mall_UserJiXiaoPoint].[Remark]
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
                return "Mall_UserJiXiaoPoint";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_UserJiXiaoPoint into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="pointType">pointType</param>
		/// <param name="pointValue">pointValue</param>
		/// <param name="title">title</param>
		/// <param name="summary">summary</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="pointStatus">pointStatus</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="relatedID">relatedID</param>
		/// <param name="pointRuleID">pointRuleID</param>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="fixedPointMonth">fixedPointMonth</param>
		/// <param name="fixedPointDateTime">fixedPointDateTime</param>
		/// <param name="ruleID">ruleID</param>
		/// <param name="infoID">infoID</param>
		/// <param name="infoName">infoName</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="earnType">earnType</param>
		/// <param name="approveUserName">approveUserName</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="remark">remark</param>
		public static void InsertMall_UserJiXiaoPoint(int @userID, int @pointType, int @pointValue, string @title, string @summary, int @categoryType, DateTime @addTime, string @addUserName, int @pointStatus, string @tradeNo, int @relatedID, int @pointRuleID, int @amountRuleID, int @fixedPointMonth, DateTime @fixedPointDateTime, int @ruleID, int @infoID, string @infoName, string @categoryName, int @earnType, string @approveUserName, DateTime @approveTime, string @approveRemark, string @remark)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_UserJiXiaoPoint(@userID, @pointType, @pointValue, @title, @summary, @categoryType, @addTime, @addUserName, @pointStatus, @tradeNo, @relatedID, @pointRuleID, @amountRuleID, @fixedPointMonth, @fixedPointDateTime, @ruleID, @infoID, @infoName, @categoryName, @earnType, @approveUserName, @approveTime, @approveRemark, @remark, helper);
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
		/// Insert a Mall_UserJiXiaoPoint into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="pointType">pointType</param>
		/// <param name="pointValue">pointValue</param>
		/// <param name="title">title</param>
		/// <param name="summary">summary</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="pointStatus">pointStatus</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="relatedID">relatedID</param>
		/// <param name="pointRuleID">pointRuleID</param>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="fixedPointMonth">fixedPointMonth</param>
		/// <param name="fixedPointDateTime">fixedPointDateTime</param>
		/// <param name="ruleID">ruleID</param>
		/// <param name="infoID">infoID</param>
		/// <param name="infoName">infoName</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="earnType">earnType</param>
		/// <param name="approveUserName">approveUserName</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="remark">remark</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_UserJiXiaoPoint(int @userID, int @pointType, int @pointValue, string @title, string @summary, int @categoryType, DateTime @addTime, string @addUserName, int @pointStatus, string @tradeNo, int @relatedID, int @pointRuleID, int @amountRuleID, int @fixedPointMonth, DateTime @fixedPointDateTime, int @ruleID, int @infoID, string @infoName, string @categoryName, int @earnType, string @approveUserName, DateTime @approveTime, string @approveRemark, string @remark, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[PointType] int,
	[PointValue] int,
	[Title] nvarchar(200),
	[Summary] ntext,
	[CategoryType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(100),
	[PointStatus] int,
	[TradeNo] nvarchar(200),
	[RelatedID] int,
	[PointRuleID] int,
	[AmountRuleID] int,
	[FixedPointMonth] int,
	[FixedPointDateTime] datetime,
	[RuleID] int,
	[InfoID] int,
	[InfoName] nvarchar(200),
	[CategoryName] nvarchar(200),
	[EarnType] int,
	[ApproveUserName] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveRemark] ntext,
	[Remark] ntext
);

INSERT INTO [dbo].[Mall_UserJiXiaoPoint] (
	[Mall_UserJiXiaoPoint].[UserID],
	[Mall_UserJiXiaoPoint].[PointType],
	[Mall_UserJiXiaoPoint].[PointValue],
	[Mall_UserJiXiaoPoint].[Title],
	[Mall_UserJiXiaoPoint].[Summary],
	[Mall_UserJiXiaoPoint].[CategoryType],
	[Mall_UserJiXiaoPoint].[AddTime],
	[Mall_UserJiXiaoPoint].[AddUserName],
	[Mall_UserJiXiaoPoint].[PointStatus],
	[Mall_UserJiXiaoPoint].[TradeNo],
	[Mall_UserJiXiaoPoint].[RelatedID],
	[Mall_UserJiXiaoPoint].[PointRuleID],
	[Mall_UserJiXiaoPoint].[AmountRuleID],
	[Mall_UserJiXiaoPoint].[FixedPointMonth],
	[Mall_UserJiXiaoPoint].[FixedPointDateTime],
	[Mall_UserJiXiaoPoint].[RuleID],
	[Mall_UserJiXiaoPoint].[InfoID],
	[Mall_UserJiXiaoPoint].[InfoName],
	[Mall_UserJiXiaoPoint].[CategoryName],
	[Mall_UserJiXiaoPoint].[EarnType],
	[Mall_UserJiXiaoPoint].[ApproveUserName],
	[Mall_UserJiXiaoPoint].[ApproveTime],
	[Mall_UserJiXiaoPoint].[ApproveRemark],
	[Mall_UserJiXiaoPoint].[Remark]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[PointType],
	INSERTED.[PointValue],
	INSERTED.[Title],
	INSERTED.[Summary],
	INSERTED.[CategoryType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[PointStatus],
	INSERTED.[TradeNo],
	INSERTED.[RelatedID],
	INSERTED.[PointRuleID],
	INSERTED.[AmountRuleID],
	INSERTED.[FixedPointMonth],
	INSERTED.[FixedPointDateTime],
	INSERTED.[RuleID],
	INSERTED.[InfoID],
	INSERTED.[InfoName],
	INSERTED.[CategoryName],
	INSERTED.[EarnType],
	INSERTED.[ApproveUserName],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[Remark]
into @table
VALUES ( 
	@UserID,
	@PointType,
	@PointValue,
	@Title,
	@Summary,
	@CategoryType,
	@AddTime,
	@AddUserName,
	@PointStatus,
	@TradeNo,
	@RelatedID,
	@PointRuleID,
	@AmountRuleID,
	@FixedPointMonth,
	@FixedPointDateTime,
	@RuleID,
	@InfoID,
	@InfoName,
	@CategoryName,
	@EarnType,
	@ApproveUserName,
	@ApproveTime,
	@ApproveRemark,
	@Remark 
); 

SELECT 
	[ID],
	[UserID],
	[PointType],
	[PointValue],
	[Title],
	[Summary],
	[CategoryType],
	[AddTime],
	[AddUserName],
	[PointStatus],
	[TradeNo],
	[RelatedID],
	[PointRuleID],
	[AmountRuleID],
	[FixedPointMonth],
	[FixedPointDateTime],
	[RuleID],
	[InfoID],
	[InfoName],
	[CategoryName],
	[EarnType],
	[ApproveUserName],
	[ApproveTime],
	[ApproveRemark],
	[Remark] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@PointType", EntityBase.GetDatabaseValue(@pointType)));
			parameters.Add(new SqlParameter("@PointValue", EntityBase.GetDatabaseValue(@pointValue)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@Summary", EntityBase.GetDatabaseValue(@summary)));
			parameters.Add(new SqlParameter("@CategoryType", EntityBase.GetDatabaseValue(@categoryType)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@PointStatus", EntityBase.GetDatabaseValue(@pointStatus)));
			parameters.Add(new SqlParameter("@TradeNo", EntityBase.GetDatabaseValue(@tradeNo)));
			parameters.Add(new SqlParameter("@RelatedID", EntityBase.GetDatabaseValue(@relatedID)));
			parameters.Add(new SqlParameter("@PointRuleID", EntityBase.GetDatabaseValue(@pointRuleID)));
			parameters.Add(new SqlParameter("@AmountRuleID", EntityBase.GetDatabaseValue(@amountRuleID)));
			parameters.Add(new SqlParameter("@FixedPointMonth", EntityBase.GetDatabaseValue(@fixedPointMonth)));
			parameters.Add(new SqlParameter("@FixedPointDateTime", EntityBase.GetDatabaseValue(@fixedPointDateTime)));
			parameters.Add(new SqlParameter("@RuleID", EntityBase.GetDatabaseValue(@ruleID)));
			parameters.Add(new SqlParameter("@InfoID", EntityBase.GetDatabaseValue(@infoID)));
			parameters.Add(new SqlParameter("@InfoName", EntityBase.GetDatabaseValue(@infoName)));
			parameters.Add(new SqlParameter("@CategoryName", EntityBase.GetDatabaseValue(@categoryName)));
			parameters.Add(new SqlParameter("@EarnType", EntityBase.GetDatabaseValue(@earnType)));
			parameters.Add(new SqlParameter("@ApproveUserName", EntityBase.GetDatabaseValue(@approveUserName)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_UserJiXiaoPoint into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="pointType">pointType</param>
		/// <param name="pointValue">pointValue</param>
		/// <param name="title">title</param>
		/// <param name="summary">summary</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="pointStatus">pointStatus</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="relatedID">relatedID</param>
		/// <param name="pointRuleID">pointRuleID</param>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="fixedPointMonth">fixedPointMonth</param>
		/// <param name="fixedPointDateTime">fixedPointDateTime</param>
		/// <param name="ruleID">ruleID</param>
		/// <param name="infoID">infoID</param>
		/// <param name="infoName">infoName</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="earnType">earnType</param>
		/// <param name="approveUserName">approveUserName</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="remark">remark</param>
		public static void UpdateMall_UserJiXiaoPoint(int @iD, int @userID, int @pointType, int @pointValue, string @title, string @summary, int @categoryType, DateTime @addTime, string @addUserName, int @pointStatus, string @tradeNo, int @relatedID, int @pointRuleID, int @amountRuleID, int @fixedPointMonth, DateTime @fixedPointDateTime, int @ruleID, int @infoID, string @infoName, string @categoryName, int @earnType, string @approveUserName, DateTime @approveTime, string @approveRemark, string @remark)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_UserJiXiaoPoint(@iD, @userID, @pointType, @pointValue, @title, @summary, @categoryType, @addTime, @addUserName, @pointStatus, @tradeNo, @relatedID, @pointRuleID, @amountRuleID, @fixedPointMonth, @fixedPointDateTime, @ruleID, @infoID, @infoName, @categoryName, @earnType, @approveUserName, @approveTime, @approveRemark, @remark, helper);
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
		/// Updates a Mall_UserJiXiaoPoint into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="pointType">pointType</param>
		/// <param name="pointValue">pointValue</param>
		/// <param name="title">title</param>
		/// <param name="summary">summary</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="pointStatus">pointStatus</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="relatedID">relatedID</param>
		/// <param name="pointRuleID">pointRuleID</param>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="fixedPointMonth">fixedPointMonth</param>
		/// <param name="fixedPointDateTime">fixedPointDateTime</param>
		/// <param name="ruleID">ruleID</param>
		/// <param name="infoID">infoID</param>
		/// <param name="infoName">infoName</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="earnType">earnType</param>
		/// <param name="approveUserName">approveUserName</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="remark">remark</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_UserJiXiaoPoint(int @iD, int @userID, int @pointType, int @pointValue, string @title, string @summary, int @categoryType, DateTime @addTime, string @addUserName, int @pointStatus, string @tradeNo, int @relatedID, int @pointRuleID, int @amountRuleID, int @fixedPointMonth, DateTime @fixedPointDateTime, int @ruleID, int @infoID, string @infoName, string @categoryName, int @earnType, string @approveUserName, DateTime @approveTime, string @approveRemark, string @remark, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[PointType] int,
	[PointValue] int,
	[Title] nvarchar(200),
	[Summary] ntext,
	[CategoryType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(100),
	[PointStatus] int,
	[TradeNo] nvarchar(200),
	[RelatedID] int,
	[PointRuleID] int,
	[AmountRuleID] int,
	[FixedPointMonth] int,
	[FixedPointDateTime] datetime,
	[RuleID] int,
	[InfoID] int,
	[InfoName] nvarchar(200),
	[CategoryName] nvarchar(200),
	[EarnType] int,
	[ApproveUserName] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveRemark] ntext,
	[Remark] ntext
);

UPDATE [dbo].[Mall_UserJiXiaoPoint] SET 
	[Mall_UserJiXiaoPoint].[UserID] = @UserID,
	[Mall_UserJiXiaoPoint].[PointType] = @PointType,
	[Mall_UserJiXiaoPoint].[PointValue] = @PointValue,
	[Mall_UserJiXiaoPoint].[Title] = @Title,
	[Mall_UserJiXiaoPoint].[Summary] = @Summary,
	[Mall_UserJiXiaoPoint].[CategoryType] = @CategoryType,
	[Mall_UserJiXiaoPoint].[AddTime] = @AddTime,
	[Mall_UserJiXiaoPoint].[AddUserName] = @AddUserName,
	[Mall_UserJiXiaoPoint].[PointStatus] = @PointStatus,
	[Mall_UserJiXiaoPoint].[TradeNo] = @TradeNo,
	[Mall_UserJiXiaoPoint].[RelatedID] = @RelatedID,
	[Mall_UserJiXiaoPoint].[PointRuleID] = @PointRuleID,
	[Mall_UserJiXiaoPoint].[AmountRuleID] = @AmountRuleID,
	[Mall_UserJiXiaoPoint].[FixedPointMonth] = @FixedPointMonth,
	[Mall_UserJiXiaoPoint].[FixedPointDateTime] = @FixedPointDateTime,
	[Mall_UserJiXiaoPoint].[RuleID] = @RuleID,
	[Mall_UserJiXiaoPoint].[InfoID] = @InfoID,
	[Mall_UserJiXiaoPoint].[InfoName] = @InfoName,
	[Mall_UserJiXiaoPoint].[CategoryName] = @CategoryName,
	[Mall_UserJiXiaoPoint].[EarnType] = @EarnType,
	[Mall_UserJiXiaoPoint].[ApproveUserName] = @ApproveUserName,
	[Mall_UserJiXiaoPoint].[ApproveTime] = @ApproveTime,
	[Mall_UserJiXiaoPoint].[ApproveRemark] = @ApproveRemark,
	[Mall_UserJiXiaoPoint].[Remark] = @Remark 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[PointType],
	INSERTED.[PointValue],
	INSERTED.[Title],
	INSERTED.[Summary],
	INSERTED.[CategoryType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[PointStatus],
	INSERTED.[TradeNo],
	INSERTED.[RelatedID],
	INSERTED.[PointRuleID],
	INSERTED.[AmountRuleID],
	INSERTED.[FixedPointMonth],
	INSERTED.[FixedPointDateTime],
	INSERTED.[RuleID],
	INSERTED.[InfoID],
	INSERTED.[InfoName],
	INSERTED.[CategoryName],
	INSERTED.[EarnType],
	INSERTED.[ApproveUserName],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[Remark]
into @table
WHERE 
	[Mall_UserJiXiaoPoint].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[PointType],
	[PointValue],
	[Title],
	[Summary],
	[CategoryType],
	[AddTime],
	[AddUserName],
	[PointStatus],
	[TradeNo],
	[RelatedID],
	[PointRuleID],
	[AmountRuleID],
	[FixedPointMonth],
	[FixedPointDateTime],
	[RuleID],
	[InfoID],
	[InfoName],
	[CategoryName],
	[EarnType],
	[ApproveUserName],
	[ApproveTime],
	[ApproveRemark],
	[Remark] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@PointType", EntityBase.GetDatabaseValue(@pointType)));
			parameters.Add(new SqlParameter("@PointValue", EntityBase.GetDatabaseValue(@pointValue)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@Summary", EntityBase.GetDatabaseValue(@summary)));
			parameters.Add(new SqlParameter("@CategoryType", EntityBase.GetDatabaseValue(@categoryType)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@PointStatus", EntityBase.GetDatabaseValue(@pointStatus)));
			parameters.Add(new SqlParameter("@TradeNo", EntityBase.GetDatabaseValue(@tradeNo)));
			parameters.Add(new SqlParameter("@RelatedID", EntityBase.GetDatabaseValue(@relatedID)));
			parameters.Add(new SqlParameter("@PointRuleID", EntityBase.GetDatabaseValue(@pointRuleID)));
			parameters.Add(new SqlParameter("@AmountRuleID", EntityBase.GetDatabaseValue(@amountRuleID)));
			parameters.Add(new SqlParameter("@FixedPointMonth", EntityBase.GetDatabaseValue(@fixedPointMonth)));
			parameters.Add(new SqlParameter("@FixedPointDateTime", EntityBase.GetDatabaseValue(@fixedPointDateTime)));
			parameters.Add(new SqlParameter("@RuleID", EntityBase.GetDatabaseValue(@ruleID)));
			parameters.Add(new SqlParameter("@InfoID", EntityBase.GetDatabaseValue(@infoID)));
			parameters.Add(new SqlParameter("@InfoName", EntityBase.GetDatabaseValue(@infoName)));
			parameters.Add(new SqlParameter("@CategoryName", EntityBase.GetDatabaseValue(@categoryName)));
			parameters.Add(new SqlParameter("@EarnType", EntityBase.GetDatabaseValue(@earnType)));
			parameters.Add(new SqlParameter("@ApproveUserName", EntityBase.GetDatabaseValue(@approveUserName)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_UserJiXiaoPoint from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_UserJiXiaoPoint(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_UserJiXiaoPoint(@iD, helper);
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
		/// Deletes a Mall_UserJiXiaoPoint from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_UserJiXiaoPoint(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_UserJiXiaoPoint]
WHERE 
	[Mall_UserJiXiaoPoint].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_UserJiXiaoPoint object.
		/// </summary>
		/// <returns>The newly created Mall_UserJiXiaoPoint object.</returns>
		public static Mall_UserJiXiaoPoint CreateMall_UserJiXiaoPoint()
		{
			return InitializeNew<Mall_UserJiXiaoPoint>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_UserJiXiaoPoint by a Mall_UserJiXiaoPoint's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_UserJiXiaoPoint</returns>
		public static Mall_UserJiXiaoPoint GetMall_UserJiXiaoPoint(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_UserJiXiaoPoint.SelectFieldList + @"
FROM [dbo].[Mall_UserJiXiaoPoint] 
WHERE 
	[Mall_UserJiXiaoPoint].[ID] = @ID " + Mall_UserJiXiaoPoint.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_UserJiXiaoPoint>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_UserJiXiaoPoint by a Mall_UserJiXiaoPoint's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_UserJiXiaoPoint</returns>
		public static Mall_UserJiXiaoPoint GetMall_UserJiXiaoPoint(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_UserJiXiaoPoint.SelectFieldList + @"
FROM [dbo].[Mall_UserJiXiaoPoint] 
WHERE 
	[Mall_UserJiXiaoPoint].[ID] = @ID " + Mall_UserJiXiaoPoint.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_UserJiXiaoPoint>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserJiXiaoPoint objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_UserJiXiaoPoint objects.</returns>
		public static EntityList<Mall_UserJiXiaoPoint> GetMall_UserJiXiaoPoints()
		{
			string commandText = @"
SELECT " + Mall_UserJiXiaoPoint.SelectFieldList + "FROM [dbo].[Mall_UserJiXiaoPoint] " + Mall_UserJiXiaoPoint.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_UserJiXiaoPoint>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_UserJiXiaoPoint objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_UserJiXiaoPoint objects.</returns>
        public static EntityList<Mall_UserJiXiaoPoint> GetMall_UserJiXiaoPoints(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserJiXiaoPoint>(SelectFieldList, "FROM [dbo].[Mall_UserJiXiaoPoint]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_UserJiXiaoPoint objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_UserJiXiaoPoint objects.</returns>
        public static EntityList<Mall_UserJiXiaoPoint> GetMall_UserJiXiaoPoints(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserJiXiaoPoint>(SelectFieldList, "FROM [dbo].[Mall_UserJiXiaoPoint]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_UserJiXiaoPoint objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_UserJiXiaoPoint objects.</returns>
		protected static EntityList<Mall_UserJiXiaoPoint> GetMall_UserJiXiaoPoints(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserJiXiaoPoints(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserJiXiaoPoint objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserJiXiaoPoint objects.</returns>
		protected static EntityList<Mall_UserJiXiaoPoint> GetMall_UserJiXiaoPoints(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserJiXiaoPoints(string.Empty, where, parameters, Mall_UserJiXiaoPoint.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserJiXiaoPoint objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserJiXiaoPoint objects.</returns>
		protected static EntityList<Mall_UserJiXiaoPoint> GetMall_UserJiXiaoPoints(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserJiXiaoPoints(prefix, where, parameters, Mall_UserJiXiaoPoint.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserJiXiaoPoint objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserJiXiaoPoint objects.</returns>
		protected static EntityList<Mall_UserJiXiaoPoint> GetMall_UserJiXiaoPoints(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_UserJiXiaoPoints(string.Empty, where, parameters, Mall_UserJiXiaoPoint.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserJiXiaoPoint objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserJiXiaoPoint objects.</returns>
		protected static EntityList<Mall_UserJiXiaoPoint> GetMall_UserJiXiaoPoints(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_UserJiXiaoPoints(prefix, where, parameters, Mall_UserJiXiaoPoint.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserJiXiaoPoint objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_UserJiXiaoPoint objects.</returns>
		protected static EntityList<Mall_UserJiXiaoPoint> GetMall_UserJiXiaoPoints(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_UserJiXiaoPoint.SelectFieldList + "FROM [dbo].[Mall_UserJiXiaoPoint] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_UserJiXiaoPoint>(reader);
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
        protected static EntityList<Mall_UserJiXiaoPoint> GetMall_UserJiXiaoPoints(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserJiXiaoPoint>(SelectFieldList, "FROM [dbo].[Mall_UserJiXiaoPoint] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_UserJiXiaoPoint objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_UserJiXiaoPointCount()
        {
            return GetMall_UserJiXiaoPointCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_UserJiXiaoPoint objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_UserJiXiaoPointCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_UserJiXiaoPoint] " + where;

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
		public static partial class Mall_UserJiXiaoPoint_Properties
		{
			public const string ID = "ID";
			public const string UserID = "UserID";
			public const string PointType = "PointType";
			public const string PointValue = "PointValue";
			public const string Title = "Title";
			public const string Summary = "Summary";
			public const string CategoryType = "CategoryType";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string PointStatus = "PointStatus";
			public const string TradeNo = "TradeNo";
			public const string RelatedID = "RelatedID";
			public const string PointRuleID = "PointRuleID";
			public const string AmountRuleID = "AmountRuleID";
			public const string FixedPointMonth = "FixedPointMonth";
			public const string FixedPointDateTime = "FixedPointDateTime";
			public const string RuleID = "RuleID";
			public const string InfoID = "InfoID";
			public const string InfoName = "InfoName";
			public const string CategoryName = "CategoryName";
			public const string EarnType = "EarnType";
			public const string ApproveUserName = "ApproveUserName";
			public const string ApproveTime = "ApproveTime";
			public const string ApproveRemark = "ApproveRemark";
			public const string Remark = "Remark";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"PointType" , "int:1-充值 2-消费 3-积分兑换"},
    			 {"PointValue" , "int:"},
    			 {"Title" , "string:"},
    			 {"Summary" , "string:"},
    			 {"CategoryType" , "int:1-业绩考核奖励 2-业绩考核扣除 3-积分兑换获取 4-积分提现"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"PointStatus" , "int:0-未入账 1-已入账"},
    			 {"TradeNo" , "string:"},
    			 {"RelatedID" , "int:"},
    			 {"PointRuleID" , "int:"},
    			 {"AmountRuleID" , "int:"},
    			 {"FixedPointMonth" , "int:"},
    			 {"FixedPointDateTime" , "DateTime:"},
    			 {"RuleID" , "int:"},
    			 {"InfoID" , "int:"},
    			 {"InfoName" , "string:"},
    			 {"CategoryName" , "string:"},
    			 {"EarnType" , "int:1-公司发放 2-积分兑换 3-积分提现"},
    			 {"ApproveUserName" , "string:"},
    			 {"ApproveTime" , "DateTime:"},
    			 {"ApproveRemark" , "string:"},
    			 {"Remark" , "string:"},
            };
		}
		#endregion
	}
}
