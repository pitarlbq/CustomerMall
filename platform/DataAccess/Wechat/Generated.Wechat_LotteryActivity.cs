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
	/// This object represents the properties and methods of a Wechat_LotteryActivity.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_LotteryActivity 
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
		private string _activityName = String.Empty;
		/// <summary>
		/// 活动名称
		/// </summary>
        [Description("活动名称")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string ActivityName
		{
			[DebuggerStepThrough()]
			get { return this._activityName; }
			set 
			{
				if (this._activityName != value) 
				{
					this._activityName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ActivityName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _creationTime = DateTime.MinValue;
		/// <summary>
		/// 创建时间
		/// </summary>
        [Description("创建时间")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime CreationTime
		{
			[DebuggerStepThrough()]
			get { return this._creationTime; }
			set 
			{
				if (this._creationTime != value) 
				{
					this._creationTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("CreationTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _creatorName = String.Empty;
		/// <summary>
		/// 创建人
		/// </summary>
        [Description("创建人")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string CreatorName
		{
			[DebuggerStepThrough()]
			get { return this._creatorName; }
			set 
			{
				if (this._creatorName != value) 
				{
					this._creatorName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CreatorName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _startTime = DateTime.MinValue;
		/// <summary>
		/// 开始时间
		/// </summary>
        [Description("开始时间")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		/// 结束时间
		/// </summary>
        [Description("结束时间")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private int _participantNumber = int.MinValue;
		/// <summary>
		/// 预估参与人数（参与人数达到该数值时奖品会被抽完）
		/// </summary>
        [Description("预估参与人数（参与人数达到该数值时奖品会被抽完）")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ParticipantNumber
		{
			[DebuggerStepThrough()]
			get { return this._participantNumber; }
			set 
			{
				if (this._participantNumber != value) 
				{
					this._participantNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("ParticipantNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _merchantName = String.Empty;
		/// <summary>
		/// 商户名称（举办方）
		/// </summary>
        [Description("商户名称（举办方）")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string MerchantName
		{
			[DebuggerStepThrough()]
			get { return this._merchantName; }
			set 
			{
				if (this._merchantName != value) 
				{
					this._merchantName = value;
					this.IsDirty = true;	
					OnPropertyChanged("MerchantName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _remark = String.Empty;
		/// <summary>
		/// 备注
		/// </summary>
        [Description("备注")]
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
		private string _type = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string Type
		{
			[DebuggerStepThrough()]
			get { return this._type; }
			set 
			{
				if (this._type != value) 
				{
					this._type = value;
					this.IsDirty = true;	
					OnPropertyChanged("Type");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _ruleDescription = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RuleDescription
		{
			[DebuggerStepThrough()]
			get { return this._ruleDescription; }
			set 
			{
				if (this._ruleDescription != value) 
				{
					this._ruleDescription = value;
					this.IsDirty = true;	
					OnPropertyChanged("RuleDescription");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _repeat = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string Repeat
		{
			[DebuggerStepThrough()]
			get { return this._repeat; }
			set 
			{
				if (this._repeat != value) 
				{
					this._repeat = value;
					this.IsDirty = true;	
					OnPropertyChanged("Repeat");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _repeatTime = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RepeatTime
		{
			[DebuggerStepThrough()]
			get { return this._repeatTime; }
			set 
			{
				if (this._repeatTime != value) 
				{
					this._repeatTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("RepeatTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _consumeType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string ConsumeType
		{
			[DebuggerStepThrough()]
			get { return this._consumeType; }
			set 
			{
				if (this._consumeType != value) 
				{
					this._consumeType = value;
					this.IsDirty = true;	
					OnPropertyChanged("ConsumeType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _consumePrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ConsumePrice
		{
			[DebuggerStepThrough()]
			get { return this._consumePrice; }
			set 
			{
				if (this._consumePrice != value) 
				{
					this._consumePrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("ConsumePrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _coverImg = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CoverImg
		{
			[DebuggerStepThrough()]
			get { return this._coverImg; }
			set 
			{
				if (this._coverImg != value) 
				{
					this._coverImg = value;
					this.IsDirty = true;	
					OnPropertyChanged("CoverImg");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _description = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Description
		{
			[DebuggerStepThrough()]
			get { return this._description; }
			set 
			{
				if (this._description != value) 
				{
					this._description = value;
					this.IsDirty = true;	
					OnPropertyChanged("Description");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _userLimit = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool UserLimit
		{
			[DebuggerStepThrough()]
			get { return this._userLimit; }
			set 
			{
				if (this._userLimit != value) 
				{
					this._userLimit = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserLimit");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _noLimitMsg = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string NoLimitMsg
		{
			[DebuggerStepThrough()]
			get { return this._noLimitMsg; }
			set 
			{
				if (this._noLimitMsg != value) 
				{
					this._noLimitMsg = value;
					this.IsDirty = true;	
					OnPropertyChanged("NoLimitMsg");
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
	[ActivityName] nvarchar(50),
	[CreationTime] datetime,
	[CreatorName] nvarchar(50),
	[StartTime] datetime,
	[EndTime] datetime,
	[ParticipantNumber] int,
	[MerchantName] nvarchar(50),
	[Remark] nvarchar(200),
	[Type] nvarchar(50),
	[RuleDescription] ntext,
	[Repeat] nvarchar(50),
	[RepeatTime] int,
	[ConsumeType] nvarchar(50),
	[ConsumePrice] decimal(18, 2),
	[CoverImg] nvarchar(500),
	[Description] nvarchar(500),
	[UserLimit] bit,
	[NoLimitMsg] nvarchar(200)
);

INSERT INTO [dbo].[Wechat_LotteryActivity] (
	[Wechat_LotteryActivity].[ActivityName],
	[Wechat_LotteryActivity].[CreationTime],
	[Wechat_LotteryActivity].[CreatorName],
	[Wechat_LotteryActivity].[StartTime],
	[Wechat_LotteryActivity].[EndTime],
	[Wechat_LotteryActivity].[ParticipantNumber],
	[Wechat_LotteryActivity].[MerchantName],
	[Wechat_LotteryActivity].[Remark],
	[Wechat_LotteryActivity].[Type],
	[Wechat_LotteryActivity].[RuleDescription],
	[Wechat_LotteryActivity].[Repeat],
	[Wechat_LotteryActivity].[RepeatTime],
	[Wechat_LotteryActivity].[ConsumeType],
	[Wechat_LotteryActivity].[ConsumePrice],
	[Wechat_LotteryActivity].[CoverImg],
	[Wechat_LotteryActivity].[Description],
	[Wechat_LotteryActivity].[UserLimit],
	[Wechat_LotteryActivity].[NoLimitMsg]
) 
output 
	INSERTED.[ID],
	INSERTED.[ActivityName],
	INSERTED.[CreationTime],
	INSERTED.[CreatorName],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[ParticipantNumber],
	INSERTED.[MerchantName],
	INSERTED.[Remark],
	INSERTED.[Type],
	INSERTED.[RuleDescription],
	INSERTED.[Repeat],
	INSERTED.[RepeatTime],
	INSERTED.[ConsumeType],
	INSERTED.[ConsumePrice],
	INSERTED.[CoverImg],
	INSERTED.[Description],
	INSERTED.[UserLimit],
	INSERTED.[NoLimitMsg]
into @table
VALUES ( 
	@ActivityName,
	@CreationTime,
	@CreatorName,
	@StartTime,
	@EndTime,
	@ParticipantNumber,
	@MerchantName,
	@Remark,
	@Type,
	@RuleDescription,
	@Repeat,
	@RepeatTime,
	@ConsumeType,
	@ConsumePrice,
	@CoverImg,
	@Description,
	@UserLimit,
	@NoLimitMsg 
); 

SELECT 
	[ID],
	[ActivityName],
	[CreationTime],
	[CreatorName],
	[StartTime],
	[EndTime],
	[ParticipantNumber],
	[MerchantName],
	[Remark],
	[Type],
	[RuleDescription],
	[Repeat],
	[RepeatTime],
	[ConsumeType],
	[ConsumePrice],
	[CoverImg],
	[Description],
	[UserLimit],
	[NoLimitMsg] 
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
	[ActivityName] nvarchar(50),
	[CreationTime] datetime,
	[CreatorName] nvarchar(50),
	[StartTime] datetime,
	[EndTime] datetime,
	[ParticipantNumber] int,
	[MerchantName] nvarchar(50),
	[Remark] nvarchar(200),
	[Type] nvarchar(50),
	[RuleDescription] ntext,
	[Repeat] nvarchar(50),
	[RepeatTime] int,
	[ConsumeType] nvarchar(50),
	[ConsumePrice] decimal(18, 2),
	[CoverImg] nvarchar(500),
	[Description] nvarchar(500),
	[UserLimit] bit,
	[NoLimitMsg] nvarchar(200)
);

UPDATE [dbo].[Wechat_LotteryActivity] SET 
	[Wechat_LotteryActivity].[ActivityName] = @ActivityName,
	[Wechat_LotteryActivity].[CreationTime] = @CreationTime,
	[Wechat_LotteryActivity].[CreatorName] = @CreatorName,
	[Wechat_LotteryActivity].[StartTime] = @StartTime,
	[Wechat_LotteryActivity].[EndTime] = @EndTime,
	[Wechat_LotteryActivity].[ParticipantNumber] = @ParticipantNumber,
	[Wechat_LotteryActivity].[MerchantName] = @MerchantName,
	[Wechat_LotteryActivity].[Remark] = @Remark,
	[Wechat_LotteryActivity].[Type] = @Type,
	[Wechat_LotteryActivity].[RuleDescription] = @RuleDescription,
	[Wechat_LotteryActivity].[Repeat] = @Repeat,
	[Wechat_LotteryActivity].[RepeatTime] = @RepeatTime,
	[Wechat_LotteryActivity].[ConsumeType] = @ConsumeType,
	[Wechat_LotteryActivity].[ConsumePrice] = @ConsumePrice,
	[Wechat_LotteryActivity].[CoverImg] = @CoverImg,
	[Wechat_LotteryActivity].[Description] = @Description,
	[Wechat_LotteryActivity].[UserLimit] = @UserLimit,
	[Wechat_LotteryActivity].[NoLimitMsg] = @NoLimitMsg 
output 
	INSERTED.[ID],
	INSERTED.[ActivityName],
	INSERTED.[CreationTime],
	INSERTED.[CreatorName],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[ParticipantNumber],
	INSERTED.[MerchantName],
	INSERTED.[Remark],
	INSERTED.[Type],
	INSERTED.[RuleDescription],
	INSERTED.[Repeat],
	INSERTED.[RepeatTime],
	INSERTED.[ConsumeType],
	INSERTED.[ConsumePrice],
	INSERTED.[CoverImg],
	INSERTED.[Description],
	INSERTED.[UserLimit],
	INSERTED.[NoLimitMsg]
into @table
WHERE 
	[Wechat_LotteryActivity].[ID] = @ID

SELECT 
	[ID],
	[ActivityName],
	[CreationTime],
	[CreatorName],
	[StartTime],
	[EndTime],
	[ParticipantNumber],
	[MerchantName],
	[Remark],
	[Type],
	[RuleDescription],
	[Repeat],
	[RepeatTime],
	[ConsumeType],
	[ConsumePrice],
	[CoverImg],
	[Description],
	[UserLimit],
	[NoLimitMsg] 
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
DELETE FROM [dbo].[Wechat_LotteryActivity]
WHERE 
	[Wechat_LotteryActivity].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_LotteryActivity() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_LotteryActivity(this.ID));
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
	[Wechat_LotteryActivity].[ID],
	[Wechat_LotteryActivity].[ActivityName],
	[Wechat_LotteryActivity].[CreationTime],
	[Wechat_LotteryActivity].[CreatorName],
	[Wechat_LotteryActivity].[StartTime],
	[Wechat_LotteryActivity].[EndTime],
	[Wechat_LotteryActivity].[ParticipantNumber],
	[Wechat_LotteryActivity].[MerchantName],
	[Wechat_LotteryActivity].[Remark],
	[Wechat_LotteryActivity].[Type],
	[Wechat_LotteryActivity].[RuleDescription],
	[Wechat_LotteryActivity].[Repeat],
	[Wechat_LotteryActivity].[RepeatTime],
	[Wechat_LotteryActivity].[ConsumeType],
	[Wechat_LotteryActivity].[ConsumePrice],
	[Wechat_LotteryActivity].[CoverImg],
	[Wechat_LotteryActivity].[Description],
	[Wechat_LotteryActivity].[UserLimit],
	[Wechat_LotteryActivity].[NoLimitMsg]
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
                return "Wechat_LotteryActivity";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_LotteryActivity into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="activityName">activityName</param>
		/// <param name="creationTime">creationTime</param>
		/// <param name="creatorName">creatorName</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="participantNumber">participantNumber</param>
		/// <param name="merchantName">merchantName</param>
		/// <param name="remark">remark</param>
		/// <param name="type">type</param>
		/// <param name="ruleDescription">ruleDescription</param>
		/// <param name="repeat">repeat</param>
		/// <param name="repeatTime">repeatTime</param>
		/// <param name="consumeType">consumeType</param>
		/// <param name="consumePrice">consumePrice</param>
		/// <param name="coverImg">coverImg</param>
		/// <param name="description">description</param>
		/// <param name="userLimit">userLimit</param>
		/// <param name="noLimitMsg">noLimitMsg</param>
		public static void InsertWechat_LotteryActivity(string @activityName, DateTime @creationTime, string @creatorName, DateTime @startTime, DateTime @endTime, int @participantNumber, string @merchantName, string @remark, string @type, string @ruleDescription, string @repeat, int @repeatTime, string @consumeType, decimal @consumePrice, string @coverImg, string @description, bool @userLimit, string @noLimitMsg)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_LotteryActivity(@activityName, @creationTime, @creatorName, @startTime, @endTime, @participantNumber, @merchantName, @remark, @type, @ruleDescription, @repeat, @repeatTime, @consumeType, @consumePrice, @coverImg, @description, @userLimit, @noLimitMsg, helper);
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
		/// Insert a Wechat_LotteryActivity into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="activityName">activityName</param>
		/// <param name="creationTime">creationTime</param>
		/// <param name="creatorName">creatorName</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="participantNumber">participantNumber</param>
		/// <param name="merchantName">merchantName</param>
		/// <param name="remark">remark</param>
		/// <param name="type">type</param>
		/// <param name="ruleDescription">ruleDescription</param>
		/// <param name="repeat">repeat</param>
		/// <param name="repeatTime">repeatTime</param>
		/// <param name="consumeType">consumeType</param>
		/// <param name="consumePrice">consumePrice</param>
		/// <param name="coverImg">coverImg</param>
		/// <param name="description">description</param>
		/// <param name="userLimit">userLimit</param>
		/// <param name="noLimitMsg">noLimitMsg</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_LotteryActivity(string @activityName, DateTime @creationTime, string @creatorName, DateTime @startTime, DateTime @endTime, int @participantNumber, string @merchantName, string @remark, string @type, string @ruleDescription, string @repeat, int @repeatTime, string @consumeType, decimal @consumePrice, string @coverImg, string @description, bool @userLimit, string @noLimitMsg, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ActivityName] nvarchar(50),
	[CreationTime] datetime,
	[CreatorName] nvarchar(50),
	[StartTime] datetime,
	[EndTime] datetime,
	[ParticipantNumber] int,
	[MerchantName] nvarchar(50),
	[Remark] nvarchar(200),
	[Type] nvarchar(50),
	[RuleDescription] ntext,
	[Repeat] nvarchar(50),
	[RepeatTime] int,
	[ConsumeType] nvarchar(50),
	[ConsumePrice] decimal(18, 2),
	[CoverImg] nvarchar(500),
	[Description] nvarchar(500),
	[UserLimit] bit,
	[NoLimitMsg] nvarchar(200)
);

INSERT INTO [dbo].[Wechat_LotteryActivity] (
	[Wechat_LotteryActivity].[ActivityName],
	[Wechat_LotteryActivity].[CreationTime],
	[Wechat_LotteryActivity].[CreatorName],
	[Wechat_LotteryActivity].[StartTime],
	[Wechat_LotteryActivity].[EndTime],
	[Wechat_LotteryActivity].[ParticipantNumber],
	[Wechat_LotteryActivity].[MerchantName],
	[Wechat_LotteryActivity].[Remark],
	[Wechat_LotteryActivity].[Type],
	[Wechat_LotteryActivity].[RuleDescription],
	[Wechat_LotteryActivity].[Repeat],
	[Wechat_LotteryActivity].[RepeatTime],
	[Wechat_LotteryActivity].[ConsumeType],
	[Wechat_LotteryActivity].[ConsumePrice],
	[Wechat_LotteryActivity].[CoverImg],
	[Wechat_LotteryActivity].[Description],
	[Wechat_LotteryActivity].[UserLimit],
	[Wechat_LotteryActivity].[NoLimitMsg]
) 
output 
	INSERTED.[ID],
	INSERTED.[ActivityName],
	INSERTED.[CreationTime],
	INSERTED.[CreatorName],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[ParticipantNumber],
	INSERTED.[MerchantName],
	INSERTED.[Remark],
	INSERTED.[Type],
	INSERTED.[RuleDescription],
	INSERTED.[Repeat],
	INSERTED.[RepeatTime],
	INSERTED.[ConsumeType],
	INSERTED.[ConsumePrice],
	INSERTED.[CoverImg],
	INSERTED.[Description],
	INSERTED.[UserLimit],
	INSERTED.[NoLimitMsg]
into @table
VALUES ( 
	@ActivityName,
	@CreationTime,
	@CreatorName,
	@StartTime,
	@EndTime,
	@ParticipantNumber,
	@MerchantName,
	@Remark,
	@Type,
	@RuleDescription,
	@Repeat,
	@RepeatTime,
	@ConsumeType,
	@ConsumePrice,
	@CoverImg,
	@Description,
	@UserLimit,
	@NoLimitMsg 
); 

SELECT 
	[ID],
	[ActivityName],
	[CreationTime],
	[CreatorName],
	[StartTime],
	[EndTime],
	[ParticipantNumber],
	[MerchantName],
	[Remark],
	[Type],
	[RuleDescription],
	[Repeat],
	[RepeatTime],
	[ConsumeType],
	[ConsumePrice],
	[CoverImg],
	[Description],
	[UserLimit],
	[NoLimitMsg] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ActivityName", EntityBase.GetDatabaseValue(@activityName)));
			parameters.Add(new SqlParameter("@CreationTime", EntityBase.GetDatabaseValue(@creationTime)));
			parameters.Add(new SqlParameter("@CreatorName", EntityBase.GetDatabaseValue(@creatorName)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@ParticipantNumber", EntityBase.GetDatabaseValue(@participantNumber)));
			parameters.Add(new SqlParameter("@MerchantName", EntityBase.GetDatabaseValue(@merchantName)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@Type", EntityBase.GetDatabaseValue(@type)));
			parameters.Add(new SqlParameter("@RuleDescription", EntityBase.GetDatabaseValue(@ruleDescription)));
			parameters.Add(new SqlParameter("@Repeat", EntityBase.GetDatabaseValue(@repeat)));
			parameters.Add(new SqlParameter("@RepeatTime", EntityBase.GetDatabaseValue(@repeatTime)));
			parameters.Add(new SqlParameter("@ConsumeType", EntityBase.GetDatabaseValue(@consumeType)));
			parameters.Add(new SqlParameter("@ConsumePrice", EntityBase.GetDatabaseValue(@consumePrice)));
			parameters.Add(new SqlParameter("@CoverImg", EntityBase.GetDatabaseValue(@coverImg)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@UserLimit", @userLimit));
			parameters.Add(new SqlParameter("@NoLimitMsg", EntityBase.GetDatabaseValue(@noLimitMsg)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_LotteryActivity into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="activityName">activityName</param>
		/// <param name="creationTime">creationTime</param>
		/// <param name="creatorName">creatorName</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="participantNumber">participantNumber</param>
		/// <param name="merchantName">merchantName</param>
		/// <param name="remark">remark</param>
		/// <param name="type">type</param>
		/// <param name="ruleDescription">ruleDescription</param>
		/// <param name="repeat">repeat</param>
		/// <param name="repeatTime">repeatTime</param>
		/// <param name="consumeType">consumeType</param>
		/// <param name="consumePrice">consumePrice</param>
		/// <param name="coverImg">coverImg</param>
		/// <param name="description">description</param>
		/// <param name="userLimit">userLimit</param>
		/// <param name="noLimitMsg">noLimitMsg</param>
		public static void UpdateWechat_LotteryActivity(int @iD, string @activityName, DateTime @creationTime, string @creatorName, DateTime @startTime, DateTime @endTime, int @participantNumber, string @merchantName, string @remark, string @type, string @ruleDescription, string @repeat, int @repeatTime, string @consumeType, decimal @consumePrice, string @coverImg, string @description, bool @userLimit, string @noLimitMsg)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_LotteryActivity(@iD, @activityName, @creationTime, @creatorName, @startTime, @endTime, @participantNumber, @merchantName, @remark, @type, @ruleDescription, @repeat, @repeatTime, @consumeType, @consumePrice, @coverImg, @description, @userLimit, @noLimitMsg, helper);
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
		/// Updates a Wechat_LotteryActivity into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="activityName">activityName</param>
		/// <param name="creationTime">creationTime</param>
		/// <param name="creatorName">creatorName</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="participantNumber">participantNumber</param>
		/// <param name="merchantName">merchantName</param>
		/// <param name="remark">remark</param>
		/// <param name="type">type</param>
		/// <param name="ruleDescription">ruleDescription</param>
		/// <param name="repeat">repeat</param>
		/// <param name="repeatTime">repeatTime</param>
		/// <param name="consumeType">consumeType</param>
		/// <param name="consumePrice">consumePrice</param>
		/// <param name="coverImg">coverImg</param>
		/// <param name="description">description</param>
		/// <param name="userLimit">userLimit</param>
		/// <param name="noLimitMsg">noLimitMsg</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_LotteryActivity(int @iD, string @activityName, DateTime @creationTime, string @creatorName, DateTime @startTime, DateTime @endTime, int @participantNumber, string @merchantName, string @remark, string @type, string @ruleDescription, string @repeat, int @repeatTime, string @consumeType, decimal @consumePrice, string @coverImg, string @description, bool @userLimit, string @noLimitMsg, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ActivityName] nvarchar(50),
	[CreationTime] datetime,
	[CreatorName] nvarchar(50),
	[StartTime] datetime,
	[EndTime] datetime,
	[ParticipantNumber] int,
	[MerchantName] nvarchar(50),
	[Remark] nvarchar(200),
	[Type] nvarchar(50),
	[RuleDescription] ntext,
	[Repeat] nvarchar(50),
	[RepeatTime] int,
	[ConsumeType] nvarchar(50),
	[ConsumePrice] decimal(18, 2),
	[CoverImg] nvarchar(500),
	[Description] nvarchar(500),
	[UserLimit] bit,
	[NoLimitMsg] nvarchar(200)
);

UPDATE [dbo].[Wechat_LotteryActivity] SET 
	[Wechat_LotteryActivity].[ActivityName] = @ActivityName,
	[Wechat_LotteryActivity].[CreationTime] = @CreationTime,
	[Wechat_LotteryActivity].[CreatorName] = @CreatorName,
	[Wechat_LotteryActivity].[StartTime] = @StartTime,
	[Wechat_LotteryActivity].[EndTime] = @EndTime,
	[Wechat_LotteryActivity].[ParticipantNumber] = @ParticipantNumber,
	[Wechat_LotteryActivity].[MerchantName] = @MerchantName,
	[Wechat_LotteryActivity].[Remark] = @Remark,
	[Wechat_LotteryActivity].[Type] = @Type,
	[Wechat_LotteryActivity].[RuleDescription] = @RuleDescription,
	[Wechat_LotteryActivity].[Repeat] = @Repeat,
	[Wechat_LotteryActivity].[RepeatTime] = @RepeatTime,
	[Wechat_LotteryActivity].[ConsumeType] = @ConsumeType,
	[Wechat_LotteryActivity].[ConsumePrice] = @ConsumePrice,
	[Wechat_LotteryActivity].[CoverImg] = @CoverImg,
	[Wechat_LotteryActivity].[Description] = @Description,
	[Wechat_LotteryActivity].[UserLimit] = @UserLimit,
	[Wechat_LotteryActivity].[NoLimitMsg] = @NoLimitMsg 
output 
	INSERTED.[ID],
	INSERTED.[ActivityName],
	INSERTED.[CreationTime],
	INSERTED.[CreatorName],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[ParticipantNumber],
	INSERTED.[MerchantName],
	INSERTED.[Remark],
	INSERTED.[Type],
	INSERTED.[RuleDescription],
	INSERTED.[Repeat],
	INSERTED.[RepeatTime],
	INSERTED.[ConsumeType],
	INSERTED.[ConsumePrice],
	INSERTED.[CoverImg],
	INSERTED.[Description],
	INSERTED.[UserLimit],
	INSERTED.[NoLimitMsg]
into @table
WHERE 
	[Wechat_LotteryActivity].[ID] = @ID

SELECT 
	[ID],
	[ActivityName],
	[CreationTime],
	[CreatorName],
	[StartTime],
	[EndTime],
	[ParticipantNumber],
	[MerchantName],
	[Remark],
	[Type],
	[RuleDescription],
	[Repeat],
	[RepeatTime],
	[ConsumeType],
	[ConsumePrice],
	[CoverImg],
	[Description],
	[UserLimit],
	[NoLimitMsg] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ActivityName", EntityBase.GetDatabaseValue(@activityName)));
			parameters.Add(new SqlParameter("@CreationTime", EntityBase.GetDatabaseValue(@creationTime)));
			parameters.Add(new SqlParameter("@CreatorName", EntityBase.GetDatabaseValue(@creatorName)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@ParticipantNumber", EntityBase.GetDatabaseValue(@participantNumber)));
			parameters.Add(new SqlParameter("@MerchantName", EntityBase.GetDatabaseValue(@merchantName)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@Type", EntityBase.GetDatabaseValue(@type)));
			parameters.Add(new SqlParameter("@RuleDescription", EntityBase.GetDatabaseValue(@ruleDescription)));
			parameters.Add(new SqlParameter("@Repeat", EntityBase.GetDatabaseValue(@repeat)));
			parameters.Add(new SqlParameter("@RepeatTime", EntityBase.GetDatabaseValue(@repeatTime)));
			parameters.Add(new SqlParameter("@ConsumeType", EntityBase.GetDatabaseValue(@consumeType)));
			parameters.Add(new SqlParameter("@ConsumePrice", EntityBase.GetDatabaseValue(@consumePrice)));
			parameters.Add(new SqlParameter("@CoverImg", EntityBase.GetDatabaseValue(@coverImg)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@UserLimit", @userLimit));
			parameters.Add(new SqlParameter("@NoLimitMsg", EntityBase.GetDatabaseValue(@noLimitMsg)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_LotteryActivity from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_LotteryActivity(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_LotteryActivity(@iD, helper);
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
		/// Deletes a Wechat_LotteryActivity from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_LotteryActivity(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_LotteryActivity]
WHERE 
	[Wechat_LotteryActivity].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_LotteryActivity object.
		/// </summary>
		/// <returns>The newly created Wechat_LotteryActivity object.</returns>
		public static Wechat_LotteryActivity CreateWechat_LotteryActivity()
		{
			return InitializeNew<Wechat_LotteryActivity>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_LotteryActivity by a Wechat_LotteryActivity's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_LotteryActivity</returns>
		public static Wechat_LotteryActivity GetWechat_LotteryActivity(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_LotteryActivity.SelectFieldList + @"
FROM [dbo].[Wechat_LotteryActivity] 
WHERE 
	[Wechat_LotteryActivity].[ID] = @ID " + Wechat_LotteryActivity.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_LotteryActivity>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_LotteryActivity by a Wechat_LotteryActivity's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_LotteryActivity</returns>
		public static Wechat_LotteryActivity GetWechat_LotteryActivity(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_LotteryActivity.SelectFieldList + @"
FROM [dbo].[Wechat_LotteryActivity] 
WHERE 
	[Wechat_LotteryActivity].[ID] = @ID " + Wechat_LotteryActivity.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_LotteryActivity>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivity objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_LotteryActivity objects.</returns>
		public static EntityList<Wechat_LotteryActivity> GetWechat_LotteryActivities()
		{
			string commandText = @"
SELECT " + Wechat_LotteryActivity.SelectFieldList + "FROM [dbo].[Wechat_LotteryActivity] " + Wechat_LotteryActivity.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_LotteryActivity>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_LotteryActivity objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_LotteryActivity objects.</returns>
        public static EntityList<Wechat_LotteryActivity> GetWechat_LotteryActivities(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_LotteryActivity>(SelectFieldList, "FROM [dbo].[Wechat_LotteryActivity]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_LotteryActivity objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_LotteryActivity objects.</returns>
        public static EntityList<Wechat_LotteryActivity> GetWechat_LotteryActivities(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_LotteryActivity>(SelectFieldList, "FROM [dbo].[Wechat_LotteryActivity]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivity objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivity objects.</returns>
		protected static EntityList<Wechat_LotteryActivity> GetWechat_LotteryActivities(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_LotteryActivities(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivity objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivity objects.</returns>
		protected static EntityList<Wechat_LotteryActivity> GetWechat_LotteryActivities(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_LotteryActivities(string.Empty, where, parameters, Wechat_LotteryActivity.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivity objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivity objects.</returns>
		protected static EntityList<Wechat_LotteryActivity> GetWechat_LotteryActivities(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_LotteryActivities(prefix, where, parameters, Wechat_LotteryActivity.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivity objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivity objects.</returns>
		protected static EntityList<Wechat_LotteryActivity> GetWechat_LotteryActivities(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_LotteryActivities(string.Empty, where, parameters, Wechat_LotteryActivity.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivity objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivity objects.</returns>
		protected static EntityList<Wechat_LotteryActivity> GetWechat_LotteryActivities(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_LotteryActivities(prefix, where, parameters, Wechat_LotteryActivity.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivity objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivity objects.</returns>
		protected static EntityList<Wechat_LotteryActivity> GetWechat_LotteryActivities(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_LotteryActivity.SelectFieldList + "FROM [dbo].[Wechat_LotteryActivity] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_LotteryActivity>(reader);
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
        protected static EntityList<Wechat_LotteryActivity> GetWechat_LotteryActivities(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_LotteryActivity>(SelectFieldList, "FROM [dbo].[Wechat_LotteryActivity] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_LotteryActivity objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_LotteryActivityCount()
        {
            return GetWechat_LotteryActivityCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_LotteryActivity objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_LotteryActivityCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_LotteryActivity] " + where;

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
		public static partial class Wechat_LotteryActivity_Properties
		{
			public const string ID = "ID";
			public const string ActivityName = "ActivityName";
			public const string CreationTime = "CreationTime";
			public const string CreatorName = "CreatorName";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string ParticipantNumber = "ParticipantNumber";
			public const string MerchantName = "MerchantName";
			public const string Remark = "Remark";
			public const string Type = "Type";
			public const string RuleDescription = "RuleDescription";
			public const string Repeat = "Repeat";
			public const string RepeatTime = "RepeatTime";
			public const string ConsumeType = "ConsumeType";
			public const string ConsumePrice = "ConsumePrice";
			public const string CoverImg = "CoverImg";
			public const string Description = "Description";
			public const string UserLimit = "UserLimit";
			public const string NoLimitMsg = "NoLimitMsg";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ActivityName" , "string:活动名称"},
    			 {"CreationTime" , "DateTime:创建时间"},
    			 {"CreatorName" , "string:创建人"},
    			 {"StartTime" , "DateTime:开始时间"},
    			 {"EndTime" , "DateTime:结束时间"},
    			 {"ParticipantNumber" , "int:预估参与人数（参与人数达到该数值时奖品会被抽完）"},
    			 {"MerchantName" , "string:商户名称（举办方）"},
    			 {"Remark" , "string:备注"},
    			 {"Type" , "string:"},
    			 {"RuleDescription" , "string:"},
    			 {"Repeat" , "string:"},
    			 {"RepeatTime" , "int:"},
    			 {"ConsumeType" , "string:"},
    			 {"ConsumePrice" , "decimal:"},
    			 {"CoverImg" , "string:"},
    			 {"Description" , "string:"},
    			 {"UserLimit" , "bool:"},
    			 {"NoLimitMsg" , "string:"},
            };
		}
		#endregion
	}
}
