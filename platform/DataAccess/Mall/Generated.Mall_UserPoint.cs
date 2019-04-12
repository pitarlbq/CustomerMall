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
	/// This object represents the properties and methods of a Mall_UserPoint.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_UserPoint 
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
		/// 1-充值 2-消费
		/// </summary>
        [Description("1-充值 2-消费")]
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
		/// 1-积分购买消费 2-购买商品赠与 3-积分购买退货返回 4-购买商品退货扣除 5-充值赠与 6-消费赠与 7-退款消费赠与取消 8-积分兑换岗位积分
		/// </summary>
        [Description("1-积分购买消费 2-购买商品赠与 3-积分购买退货返回 4-购买商品退货扣除 5-充值赠与 6-消费赠与 7-退款消费赠与取消 8-积分兑换岗位积分")]
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
	[IsSent] bit,
	[SentTime] datetime,
	[IsReadySendTime] datetime
);

INSERT INTO [dbo].[Mall_UserPoint] (
	[Mall_UserPoint].[UserID],
	[Mall_UserPoint].[PointType],
	[Mall_UserPoint].[PointValue],
	[Mall_UserPoint].[Title],
	[Mall_UserPoint].[Summary],
	[Mall_UserPoint].[CategoryType],
	[Mall_UserPoint].[AddTime],
	[Mall_UserPoint].[AddUserName],
	[Mall_UserPoint].[PointStatus],
	[Mall_UserPoint].[TradeNo],
	[Mall_UserPoint].[RelatedID],
	[Mall_UserPoint].[PointRuleID],
	[Mall_UserPoint].[AmountRuleID],
	[Mall_UserPoint].[IsSent],
	[Mall_UserPoint].[SentTime],
	[Mall_UserPoint].[IsReadySendTime]
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
	INSERTED.[IsSent],
	INSERTED.[SentTime],
	INSERTED.[IsReadySendTime]
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
	@IsSent,
	@SentTime,
	@IsReadySendTime 
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
	[IsSent],
	[SentTime],
	[IsReadySendTime] 
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
	[IsSent] bit,
	[SentTime] datetime,
	[IsReadySendTime] datetime
);

UPDATE [dbo].[Mall_UserPoint] SET 
	[Mall_UserPoint].[UserID] = @UserID,
	[Mall_UserPoint].[PointType] = @PointType,
	[Mall_UserPoint].[PointValue] = @PointValue,
	[Mall_UserPoint].[Title] = @Title,
	[Mall_UserPoint].[Summary] = @Summary,
	[Mall_UserPoint].[CategoryType] = @CategoryType,
	[Mall_UserPoint].[AddTime] = @AddTime,
	[Mall_UserPoint].[AddUserName] = @AddUserName,
	[Mall_UserPoint].[PointStatus] = @PointStatus,
	[Mall_UserPoint].[TradeNo] = @TradeNo,
	[Mall_UserPoint].[RelatedID] = @RelatedID,
	[Mall_UserPoint].[PointRuleID] = @PointRuleID,
	[Mall_UserPoint].[AmountRuleID] = @AmountRuleID,
	[Mall_UserPoint].[IsSent] = @IsSent,
	[Mall_UserPoint].[SentTime] = @SentTime,
	[Mall_UserPoint].[IsReadySendTime] = @IsReadySendTime 
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
	INSERTED.[IsSent],
	INSERTED.[SentTime],
	INSERTED.[IsReadySendTime]
into @table
WHERE 
	[Mall_UserPoint].[ID] = @ID

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
	[IsSent],
	[SentTime],
	[IsReadySendTime] 
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
DELETE FROM [dbo].[Mall_UserPoint]
WHERE 
	[Mall_UserPoint].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_UserPoint() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_UserPoint(this.ID));
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
	[Mall_UserPoint].[ID],
	[Mall_UserPoint].[UserID],
	[Mall_UserPoint].[PointType],
	[Mall_UserPoint].[PointValue],
	[Mall_UserPoint].[Title],
	[Mall_UserPoint].[Summary],
	[Mall_UserPoint].[CategoryType],
	[Mall_UserPoint].[AddTime],
	[Mall_UserPoint].[AddUserName],
	[Mall_UserPoint].[PointStatus],
	[Mall_UserPoint].[TradeNo],
	[Mall_UserPoint].[RelatedID],
	[Mall_UserPoint].[PointRuleID],
	[Mall_UserPoint].[AmountRuleID],
	[Mall_UserPoint].[IsSent],
	[Mall_UserPoint].[SentTime],
	[Mall_UserPoint].[IsReadySendTime]
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
                return "Mall_UserPoint";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_UserPoint into the data store based on the primitive properties. This can be used as the 
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
		/// <param name="isSent">isSent</param>
		/// <param name="sentTime">sentTime</param>
		/// <param name="isReadySendTime">isReadySendTime</param>
		public static void InsertMall_UserPoint(int @userID, int @pointType, int @pointValue, string @title, string @summary, int @categoryType, DateTime @addTime, string @addUserName, int @pointStatus, string @tradeNo, int @relatedID, int @pointRuleID, int @amountRuleID, bool @isSent, DateTime @sentTime, DateTime @isReadySendTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_UserPoint(@userID, @pointType, @pointValue, @title, @summary, @categoryType, @addTime, @addUserName, @pointStatus, @tradeNo, @relatedID, @pointRuleID, @amountRuleID, @isSent, @sentTime, @isReadySendTime, helper);
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
		/// Insert a Mall_UserPoint into the data store based on the primitive properties. This can be used as the 
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
		/// <param name="isSent">isSent</param>
		/// <param name="sentTime">sentTime</param>
		/// <param name="isReadySendTime">isReadySendTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_UserPoint(int @userID, int @pointType, int @pointValue, string @title, string @summary, int @categoryType, DateTime @addTime, string @addUserName, int @pointStatus, string @tradeNo, int @relatedID, int @pointRuleID, int @amountRuleID, bool @isSent, DateTime @sentTime, DateTime @isReadySendTime, SqlHelper @helper)
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
	[IsSent] bit,
	[SentTime] datetime,
	[IsReadySendTime] datetime
);

INSERT INTO [dbo].[Mall_UserPoint] (
	[Mall_UserPoint].[UserID],
	[Mall_UserPoint].[PointType],
	[Mall_UserPoint].[PointValue],
	[Mall_UserPoint].[Title],
	[Mall_UserPoint].[Summary],
	[Mall_UserPoint].[CategoryType],
	[Mall_UserPoint].[AddTime],
	[Mall_UserPoint].[AddUserName],
	[Mall_UserPoint].[PointStatus],
	[Mall_UserPoint].[TradeNo],
	[Mall_UserPoint].[RelatedID],
	[Mall_UserPoint].[PointRuleID],
	[Mall_UserPoint].[AmountRuleID],
	[Mall_UserPoint].[IsSent],
	[Mall_UserPoint].[SentTime],
	[Mall_UserPoint].[IsReadySendTime]
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
	INSERTED.[IsSent],
	INSERTED.[SentTime],
	INSERTED.[IsReadySendTime]
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
	@IsSent,
	@SentTime,
	@IsReadySendTime 
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
	[IsSent],
	[SentTime],
	[IsReadySendTime] 
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
			parameters.Add(new SqlParameter("@IsSent", @isSent));
			parameters.Add(new SqlParameter("@SentTime", EntityBase.GetDatabaseValue(@sentTime)));
			parameters.Add(new SqlParameter("@IsReadySendTime", EntityBase.GetDatabaseValue(@isReadySendTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_UserPoint into the data store based on the primitive properties. This can be used as the 
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
		/// <param name="isSent">isSent</param>
		/// <param name="sentTime">sentTime</param>
		/// <param name="isReadySendTime">isReadySendTime</param>
		public static void UpdateMall_UserPoint(int @iD, int @userID, int @pointType, int @pointValue, string @title, string @summary, int @categoryType, DateTime @addTime, string @addUserName, int @pointStatus, string @tradeNo, int @relatedID, int @pointRuleID, int @amountRuleID, bool @isSent, DateTime @sentTime, DateTime @isReadySendTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_UserPoint(@iD, @userID, @pointType, @pointValue, @title, @summary, @categoryType, @addTime, @addUserName, @pointStatus, @tradeNo, @relatedID, @pointRuleID, @amountRuleID, @isSent, @sentTime, @isReadySendTime, helper);
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
		/// Updates a Mall_UserPoint into the data store based on the primitive properties. This can be used as the 
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
		/// <param name="isSent">isSent</param>
		/// <param name="sentTime">sentTime</param>
		/// <param name="isReadySendTime">isReadySendTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_UserPoint(int @iD, int @userID, int @pointType, int @pointValue, string @title, string @summary, int @categoryType, DateTime @addTime, string @addUserName, int @pointStatus, string @tradeNo, int @relatedID, int @pointRuleID, int @amountRuleID, bool @isSent, DateTime @sentTime, DateTime @isReadySendTime, SqlHelper @helper)
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
	[IsSent] bit,
	[SentTime] datetime,
	[IsReadySendTime] datetime
);

UPDATE [dbo].[Mall_UserPoint] SET 
	[Mall_UserPoint].[UserID] = @UserID,
	[Mall_UserPoint].[PointType] = @PointType,
	[Mall_UserPoint].[PointValue] = @PointValue,
	[Mall_UserPoint].[Title] = @Title,
	[Mall_UserPoint].[Summary] = @Summary,
	[Mall_UserPoint].[CategoryType] = @CategoryType,
	[Mall_UserPoint].[AddTime] = @AddTime,
	[Mall_UserPoint].[AddUserName] = @AddUserName,
	[Mall_UserPoint].[PointStatus] = @PointStatus,
	[Mall_UserPoint].[TradeNo] = @TradeNo,
	[Mall_UserPoint].[RelatedID] = @RelatedID,
	[Mall_UserPoint].[PointRuleID] = @PointRuleID,
	[Mall_UserPoint].[AmountRuleID] = @AmountRuleID,
	[Mall_UserPoint].[IsSent] = @IsSent,
	[Mall_UserPoint].[SentTime] = @SentTime,
	[Mall_UserPoint].[IsReadySendTime] = @IsReadySendTime 
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
	INSERTED.[IsSent],
	INSERTED.[SentTime],
	INSERTED.[IsReadySendTime]
into @table
WHERE 
	[Mall_UserPoint].[ID] = @ID

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
	[IsSent],
	[SentTime],
	[IsReadySendTime] 
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
			parameters.Add(new SqlParameter("@IsSent", @isSent));
			parameters.Add(new SqlParameter("@SentTime", EntityBase.GetDatabaseValue(@sentTime)));
			parameters.Add(new SqlParameter("@IsReadySendTime", EntityBase.GetDatabaseValue(@isReadySendTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_UserPoint from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_UserPoint(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_UserPoint(@iD, helper);
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
		/// Deletes a Mall_UserPoint from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_UserPoint(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_UserPoint]
WHERE 
	[Mall_UserPoint].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_UserPoint object.
		/// </summary>
		/// <returns>The newly created Mall_UserPoint object.</returns>
		public static Mall_UserPoint CreateMall_UserPoint()
		{
			return InitializeNew<Mall_UserPoint>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_UserPoint by a Mall_UserPoint's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_UserPoint</returns>
		public static Mall_UserPoint GetMall_UserPoint(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_UserPoint.SelectFieldList + @"
FROM [dbo].[Mall_UserPoint] 
WHERE 
	[Mall_UserPoint].[ID] = @ID " + Mall_UserPoint.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_UserPoint>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_UserPoint by a Mall_UserPoint's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_UserPoint</returns>
		public static Mall_UserPoint GetMall_UserPoint(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_UserPoint.SelectFieldList + @"
FROM [dbo].[Mall_UserPoint] 
WHERE 
	[Mall_UserPoint].[ID] = @ID " + Mall_UserPoint.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_UserPoint>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserPoint objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_UserPoint objects.</returns>
		public static EntityList<Mall_UserPoint> GetMall_UserPoints()
		{
			string commandText = @"
SELECT " + Mall_UserPoint.SelectFieldList + "FROM [dbo].[Mall_UserPoint] " + Mall_UserPoint.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_UserPoint>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_UserPoint objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_UserPoint objects.</returns>
        public static EntityList<Mall_UserPoint> GetMall_UserPoints(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserPoint>(SelectFieldList, "FROM [dbo].[Mall_UserPoint]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_UserPoint objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_UserPoint objects.</returns>
        public static EntityList<Mall_UserPoint> GetMall_UserPoints(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserPoint>(SelectFieldList, "FROM [dbo].[Mall_UserPoint]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_UserPoint objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_UserPoint objects.</returns>
		protected static EntityList<Mall_UserPoint> GetMall_UserPoints(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserPoints(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserPoint objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserPoint objects.</returns>
		protected static EntityList<Mall_UserPoint> GetMall_UserPoints(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserPoints(string.Empty, where, parameters, Mall_UserPoint.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserPoint objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserPoint objects.</returns>
		protected static EntityList<Mall_UserPoint> GetMall_UserPoints(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserPoints(prefix, where, parameters, Mall_UserPoint.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserPoint objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserPoint objects.</returns>
		protected static EntityList<Mall_UserPoint> GetMall_UserPoints(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_UserPoints(string.Empty, where, parameters, Mall_UserPoint.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserPoint objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserPoint objects.</returns>
		protected static EntityList<Mall_UserPoint> GetMall_UserPoints(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_UserPoints(prefix, where, parameters, Mall_UserPoint.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserPoint objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_UserPoint objects.</returns>
		protected static EntityList<Mall_UserPoint> GetMall_UserPoints(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_UserPoint.SelectFieldList + "FROM [dbo].[Mall_UserPoint] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_UserPoint>(reader);
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
        protected static EntityList<Mall_UserPoint> GetMall_UserPoints(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserPoint>(SelectFieldList, "FROM [dbo].[Mall_UserPoint] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_UserPoint objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_UserPointCount()
        {
            return GetMall_UserPointCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_UserPoint objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_UserPointCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_UserPoint] " + where;

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
		public static partial class Mall_UserPoint_Properties
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
			public const string IsSent = "IsSent";
			public const string SentTime = "SentTime";
			public const string IsReadySendTime = "IsReadySendTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"PointType" , "int:1-充值 2-消费"},
    			 {"PointValue" , "int:"},
    			 {"Title" , "string:"},
    			 {"Summary" , "string:"},
    			 {"CategoryType" , "int:1-积分购买消费 2-购买商品赠与 3-积分购买退货返回 4-购买商品退货扣除 5-充值赠与 6-消费赠与 7-退款消费赠与取消 8-积分兑换岗位积分"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"PointStatus" , "int:0-未入账 1-已入账"},
    			 {"TradeNo" , "string:"},
    			 {"RelatedID" , "int:"},
    			 {"PointRuleID" , "int:"},
    			 {"AmountRuleID" , "int:"},
    			 {"IsSent" , "bool:"},
    			 {"SentTime" , "DateTime:"},
    			 {"IsReadySendTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
