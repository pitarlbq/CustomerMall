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
	/// This object represents the properties and methods of a Wechat_Survey.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_Survey 
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
		private int _status = int.MinValue;
		/// <summary>
		/// 1-发布 0-未发布
		/// </summary>
        [Description("1-发布 0-未发布")]
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
		private int _surveyType = int.MinValue;
		/// <summary>
		/// 1-调查问卷 2-社区投票 3-点赞物业
		/// </summary>
        [Description("1-调查问卷 2-社区投票 3-点赞物业")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SurveyType
		{
			[DebuggerStepThrough()]
			get { return this._surveyType; }
			set 
			{
				if (this._surveyType != value) 
				{
					this._surveyType = value;
					this.IsDirty = true;	
					OnPropertyChanged("SurveyType");
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
		private bool _isWechatShow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsWechatShow
		{
			[DebuggerStepThrough()]
			get { return this._isWechatShow; }
			set 
			{
				if (this._isWechatShow != value) 
				{
					this._isWechatShow = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsWechatShow");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAPPUserShow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAPPUserShow
		{
			[DebuggerStepThrough()]
			get { return this._isAPPUserShow; }
			set 
			{
				if (this._isAPPUserShow != value) 
				{
					this._isAPPUserShow = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAPPUserShow");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAPPCustomerShow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAPPCustomerShow
		{
			[DebuggerStepThrough()]
			get { return this._isAPPCustomerShow; }
			set 
			{
				if (this._isAPPCustomerShow != value) 
				{
					this._isAPPCustomerShow = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAPPCustomerShow");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _dayVoteLimitCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int DayVoteLimitCount
		{
			[DebuggerStepThrough()]
			get { return this._dayVoteLimitCount; }
			set 
			{
				if (this._dayVoteLimitCount != value) 
				{
					this._dayVoteLimitCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("DayVoteLimitCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _aLLVoteLimitCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ALLVoteLimitCount
		{
			[DebuggerStepThrough()]
			get { return this._aLLVoteLimitCount; }
			set 
			{
				if (this._aLLVoteLimitCount != value) 
				{
					this._aLLVoteLimitCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("ALLVoteLimitCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAllowRepeatVote = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAllowRepeatVote
		{
			[DebuggerStepThrough()]
			get { return this._isAllowRepeatVote; }
			set 
			{
				if (this._isAllowRepeatVote != value) 
				{
					this._isAllowRepeatVote = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAllowRepeatVote");
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
	[Title] nvarchar(500),
	[Description] ntext,
	[Status] int,
	[StartTime] datetime,
	[EndTime] datetime,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[SurveyType] int,
	[CoverImg] nvarchar(500),
	[IsWechatShow] bit,
	[IsAPPUserShow] bit,
	[IsAPPCustomerShow] bit,
	[DayVoteLimitCount] int,
	[ALLVoteLimitCount] int,
	[IsAllowRepeatVote] bit
);

INSERT INTO [dbo].[Wechat_Survey] (
	[Wechat_Survey].[Title],
	[Wechat_Survey].[Description],
	[Wechat_Survey].[Status],
	[Wechat_Survey].[StartTime],
	[Wechat_Survey].[EndTime],
	[Wechat_Survey].[AddTime],
	[Wechat_Survey].[AddMan],
	[Wechat_Survey].[SurveyType],
	[Wechat_Survey].[CoverImg],
	[Wechat_Survey].[IsWechatShow],
	[Wechat_Survey].[IsAPPUserShow],
	[Wechat_Survey].[IsAPPCustomerShow],
	[Wechat_Survey].[DayVoteLimitCount],
	[Wechat_Survey].[ALLVoteLimitCount],
	[Wechat_Survey].[IsAllowRepeatVote]
) 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[Description],
	INSERTED.[Status],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[SurveyType],
	INSERTED.[CoverImg],
	INSERTED.[IsWechatShow],
	INSERTED.[IsAPPUserShow],
	INSERTED.[IsAPPCustomerShow],
	INSERTED.[DayVoteLimitCount],
	INSERTED.[ALLVoteLimitCount],
	INSERTED.[IsAllowRepeatVote]
into @table
VALUES ( 
	@Title,
	@Description,
	@Status,
	@StartTime,
	@EndTime,
	@AddTime,
	@AddMan,
	@SurveyType,
	@CoverImg,
	@IsWechatShow,
	@IsAPPUserShow,
	@IsAPPCustomerShow,
	@DayVoteLimitCount,
	@ALLVoteLimitCount,
	@IsAllowRepeatVote 
); 

SELECT 
	[ID],
	[Title],
	[Description],
	[Status],
	[StartTime],
	[EndTime],
	[AddTime],
	[AddMan],
	[SurveyType],
	[CoverImg],
	[IsWechatShow],
	[IsAPPUserShow],
	[IsAPPCustomerShow],
	[DayVoteLimitCount],
	[ALLVoteLimitCount],
	[IsAllowRepeatVote] 
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
	[Title] nvarchar(500),
	[Description] ntext,
	[Status] int,
	[StartTime] datetime,
	[EndTime] datetime,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[SurveyType] int,
	[CoverImg] nvarchar(500),
	[IsWechatShow] bit,
	[IsAPPUserShow] bit,
	[IsAPPCustomerShow] bit,
	[DayVoteLimitCount] int,
	[ALLVoteLimitCount] int,
	[IsAllowRepeatVote] bit
);

UPDATE [dbo].[Wechat_Survey] SET 
	[Wechat_Survey].[Title] = @Title,
	[Wechat_Survey].[Description] = @Description,
	[Wechat_Survey].[Status] = @Status,
	[Wechat_Survey].[StartTime] = @StartTime,
	[Wechat_Survey].[EndTime] = @EndTime,
	[Wechat_Survey].[AddTime] = @AddTime,
	[Wechat_Survey].[AddMan] = @AddMan,
	[Wechat_Survey].[SurveyType] = @SurveyType,
	[Wechat_Survey].[CoverImg] = @CoverImg,
	[Wechat_Survey].[IsWechatShow] = @IsWechatShow,
	[Wechat_Survey].[IsAPPUserShow] = @IsAPPUserShow,
	[Wechat_Survey].[IsAPPCustomerShow] = @IsAPPCustomerShow,
	[Wechat_Survey].[DayVoteLimitCount] = @DayVoteLimitCount,
	[Wechat_Survey].[ALLVoteLimitCount] = @ALLVoteLimitCount,
	[Wechat_Survey].[IsAllowRepeatVote] = @IsAllowRepeatVote 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[Description],
	INSERTED.[Status],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[SurveyType],
	INSERTED.[CoverImg],
	INSERTED.[IsWechatShow],
	INSERTED.[IsAPPUserShow],
	INSERTED.[IsAPPCustomerShow],
	INSERTED.[DayVoteLimitCount],
	INSERTED.[ALLVoteLimitCount],
	INSERTED.[IsAllowRepeatVote]
into @table
WHERE 
	[Wechat_Survey].[ID] = @ID

SELECT 
	[ID],
	[Title],
	[Description],
	[Status],
	[StartTime],
	[EndTime],
	[AddTime],
	[AddMan],
	[SurveyType],
	[CoverImg],
	[IsWechatShow],
	[IsAPPUserShow],
	[IsAPPCustomerShow],
	[DayVoteLimitCount],
	[ALLVoteLimitCount],
	[IsAllowRepeatVote] 
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
DELETE FROM [dbo].[Wechat_Survey]
WHERE 
	[Wechat_Survey].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_Survey() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_Survey(this.ID));
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
	[Wechat_Survey].[ID],
	[Wechat_Survey].[Title],
	[Wechat_Survey].[Description],
	[Wechat_Survey].[Status],
	[Wechat_Survey].[StartTime],
	[Wechat_Survey].[EndTime],
	[Wechat_Survey].[AddTime],
	[Wechat_Survey].[AddMan],
	[Wechat_Survey].[SurveyType],
	[Wechat_Survey].[CoverImg],
	[Wechat_Survey].[IsWechatShow],
	[Wechat_Survey].[IsAPPUserShow],
	[Wechat_Survey].[IsAPPCustomerShow],
	[Wechat_Survey].[DayVoteLimitCount],
	[Wechat_Survey].[ALLVoteLimitCount],
	[Wechat_Survey].[IsAllowRepeatVote]
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
                return "Wechat_Survey";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_Survey into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="title">title</param>
		/// <param name="description">description</param>
		/// <param name="status">status</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="surveyType">surveyType</param>
		/// <param name="coverImg">coverImg</param>
		/// <param name="isWechatShow">isWechatShow</param>
		/// <param name="isAPPUserShow">isAPPUserShow</param>
		/// <param name="isAPPCustomerShow">isAPPCustomerShow</param>
		/// <param name="dayVoteLimitCount">dayVoteLimitCount</param>
		/// <param name="aLLVoteLimitCount">aLLVoteLimitCount</param>
		/// <param name="isAllowRepeatVote">isAllowRepeatVote</param>
		public static void InsertWechat_Survey(string @title, string @description, int @status, DateTime @startTime, DateTime @endTime, DateTime @addTime, string @addMan, int @surveyType, string @coverImg, bool @isWechatShow, bool @isAPPUserShow, bool @isAPPCustomerShow, int @dayVoteLimitCount, int @aLLVoteLimitCount, bool @isAllowRepeatVote)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_Survey(@title, @description, @status, @startTime, @endTime, @addTime, @addMan, @surveyType, @coverImg, @isWechatShow, @isAPPUserShow, @isAPPCustomerShow, @dayVoteLimitCount, @aLLVoteLimitCount, @isAllowRepeatVote, helper);
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
		/// Insert a Wechat_Survey into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="title">title</param>
		/// <param name="description">description</param>
		/// <param name="status">status</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="surveyType">surveyType</param>
		/// <param name="coverImg">coverImg</param>
		/// <param name="isWechatShow">isWechatShow</param>
		/// <param name="isAPPUserShow">isAPPUserShow</param>
		/// <param name="isAPPCustomerShow">isAPPCustomerShow</param>
		/// <param name="dayVoteLimitCount">dayVoteLimitCount</param>
		/// <param name="aLLVoteLimitCount">aLLVoteLimitCount</param>
		/// <param name="isAllowRepeatVote">isAllowRepeatVote</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_Survey(string @title, string @description, int @status, DateTime @startTime, DateTime @endTime, DateTime @addTime, string @addMan, int @surveyType, string @coverImg, bool @isWechatShow, bool @isAPPUserShow, bool @isAPPCustomerShow, int @dayVoteLimitCount, int @aLLVoteLimitCount, bool @isAllowRepeatVote, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Title] nvarchar(500),
	[Description] ntext,
	[Status] int,
	[StartTime] datetime,
	[EndTime] datetime,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[SurveyType] int,
	[CoverImg] nvarchar(500),
	[IsWechatShow] bit,
	[IsAPPUserShow] bit,
	[IsAPPCustomerShow] bit,
	[DayVoteLimitCount] int,
	[ALLVoteLimitCount] int,
	[IsAllowRepeatVote] bit
);

INSERT INTO [dbo].[Wechat_Survey] (
	[Wechat_Survey].[Title],
	[Wechat_Survey].[Description],
	[Wechat_Survey].[Status],
	[Wechat_Survey].[StartTime],
	[Wechat_Survey].[EndTime],
	[Wechat_Survey].[AddTime],
	[Wechat_Survey].[AddMan],
	[Wechat_Survey].[SurveyType],
	[Wechat_Survey].[CoverImg],
	[Wechat_Survey].[IsWechatShow],
	[Wechat_Survey].[IsAPPUserShow],
	[Wechat_Survey].[IsAPPCustomerShow],
	[Wechat_Survey].[DayVoteLimitCount],
	[Wechat_Survey].[ALLVoteLimitCount],
	[Wechat_Survey].[IsAllowRepeatVote]
) 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[Description],
	INSERTED.[Status],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[SurveyType],
	INSERTED.[CoverImg],
	INSERTED.[IsWechatShow],
	INSERTED.[IsAPPUserShow],
	INSERTED.[IsAPPCustomerShow],
	INSERTED.[DayVoteLimitCount],
	INSERTED.[ALLVoteLimitCount],
	INSERTED.[IsAllowRepeatVote]
into @table
VALUES ( 
	@Title,
	@Description,
	@Status,
	@StartTime,
	@EndTime,
	@AddTime,
	@AddMan,
	@SurveyType,
	@CoverImg,
	@IsWechatShow,
	@IsAPPUserShow,
	@IsAPPCustomerShow,
	@DayVoteLimitCount,
	@ALLVoteLimitCount,
	@IsAllowRepeatVote 
); 

SELECT 
	[ID],
	[Title],
	[Description],
	[Status],
	[StartTime],
	[EndTime],
	[AddTime],
	[AddMan],
	[SurveyType],
	[CoverImg],
	[IsWechatShow],
	[IsAPPUserShow],
	[IsAPPCustomerShow],
	[DayVoteLimitCount],
	[ALLVoteLimitCount],
	[IsAllowRepeatVote] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@SurveyType", EntityBase.GetDatabaseValue(@surveyType)));
			parameters.Add(new SqlParameter("@CoverImg", EntityBase.GetDatabaseValue(@coverImg)));
			parameters.Add(new SqlParameter("@IsWechatShow", @isWechatShow));
			parameters.Add(new SqlParameter("@IsAPPUserShow", @isAPPUserShow));
			parameters.Add(new SqlParameter("@IsAPPCustomerShow", @isAPPCustomerShow));
			parameters.Add(new SqlParameter("@DayVoteLimitCount", EntityBase.GetDatabaseValue(@dayVoteLimitCount)));
			parameters.Add(new SqlParameter("@ALLVoteLimitCount", EntityBase.GetDatabaseValue(@aLLVoteLimitCount)));
			parameters.Add(new SqlParameter("@IsAllowRepeatVote", @isAllowRepeatVote));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_Survey into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="title">title</param>
		/// <param name="description">description</param>
		/// <param name="status">status</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="surveyType">surveyType</param>
		/// <param name="coverImg">coverImg</param>
		/// <param name="isWechatShow">isWechatShow</param>
		/// <param name="isAPPUserShow">isAPPUserShow</param>
		/// <param name="isAPPCustomerShow">isAPPCustomerShow</param>
		/// <param name="dayVoteLimitCount">dayVoteLimitCount</param>
		/// <param name="aLLVoteLimitCount">aLLVoteLimitCount</param>
		/// <param name="isAllowRepeatVote">isAllowRepeatVote</param>
		public static void UpdateWechat_Survey(int @iD, string @title, string @description, int @status, DateTime @startTime, DateTime @endTime, DateTime @addTime, string @addMan, int @surveyType, string @coverImg, bool @isWechatShow, bool @isAPPUserShow, bool @isAPPCustomerShow, int @dayVoteLimitCount, int @aLLVoteLimitCount, bool @isAllowRepeatVote)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_Survey(@iD, @title, @description, @status, @startTime, @endTime, @addTime, @addMan, @surveyType, @coverImg, @isWechatShow, @isAPPUserShow, @isAPPCustomerShow, @dayVoteLimitCount, @aLLVoteLimitCount, @isAllowRepeatVote, helper);
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
		/// Updates a Wechat_Survey into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="title">title</param>
		/// <param name="description">description</param>
		/// <param name="status">status</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="surveyType">surveyType</param>
		/// <param name="coverImg">coverImg</param>
		/// <param name="isWechatShow">isWechatShow</param>
		/// <param name="isAPPUserShow">isAPPUserShow</param>
		/// <param name="isAPPCustomerShow">isAPPCustomerShow</param>
		/// <param name="dayVoteLimitCount">dayVoteLimitCount</param>
		/// <param name="aLLVoteLimitCount">aLLVoteLimitCount</param>
		/// <param name="isAllowRepeatVote">isAllowRepeatVote</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_Survey(int @iD, string @title, string @description, int @status, DateTime @startTime, DateTime @endTime, DateTime @addTime, string @addMan, int @surveyType, string @coverImg, bool @isWechatShow, bool @isAPPUserShow, bool @isAPPCustomerShow, int @dayVoteLimitCount, int @aLLVoteLimitCount, bool @isAllowRepeatVote, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Title] nvarchar(500),
	[Description] ntext,
	[Status] int,
	[StartTime] datetime,
	[EndTime] datetime,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[SurveyType] int,
	[CoverImg] nvarchar(500),
	[IsWechatShow] bit,
	[IsAPPUserShow] bit,
	[IsAPPCustomerShow] bit,
	[DayVoteLimitCount] int,
	[ALLVoteLimitCount] int,
	[IsAllowRepeatVote] bit
);

UPDATE [dbo].[Wechat_Survey] SET 
	[Wechat_Survey].[Title] = @Title,
	[Wechat_Survey].[Description] = @Description,
	[Wechat_Survey].[Status] = @Status,
	[Wechat_Survey].[StartTime] = @StartTime,
	[Wechat_Survey].[EndTime] = @EndTime,
	[Wechat_Survey].[AddTime] = @AddTime,
	[Wechat_Survey].[AddMan] = @AddMan,
	[Wechat_Survey].[SurveyType] = @SurveyType,
	[Wechat_Survey].[CoverImg] = @CoverImg,
	[Wechat_Survey].[IsWechatShow] = @IsWechatShow,
	[Wechat_Survey].[IsAPPUserShow] = @IsAPPUserShow,
	[Wechat_Survey].[IsAPPCustomerShow] = @IsAPPCustomerShow,
	[Wechat_Survey].[DayVoteLimitCount] = @DayVoteLimitCount,
	[Wechat_Survey].[ALLVoteLimitCount] = @ALLVoteLimitCount,
	[Wechat_Survey].[IsAllowRepeatVote] = @IsAllowRepeatVote 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[Description],
	INSERTED.[Status],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[SurveyType],
	INSERTED.[CoverImg],
	INSERTED.[IsWechatShow],
	INSERTED.[IsAPPUserShow],
	INSERTED.[IsAPPCustomerShow],
	INSERTED.[DayVoteLimitCount],
	INSERTED.[ALLVoteLimitCount],
	INSERTED.[IsAllowRepeatVote]
into @table
WHERE 
	[Wechat_Survey].[ID] = @ID

SELECT 
	[ID],
	[Title],
	[Description],
	[Status],
	[StartTime],
	[EndTime],
	[AddTime],
	[AddMan],
	[SurveyType],
	[CoverImg],
	[IsWechatShow],
	[IsAPPUserShow],
	[IsAPPCustomerShow],
	[DayVoteLimitCount],
	[ALLVoteLimitCount],
	[IsAllowRepeatVote] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@SurveyType", EntityBase.GetDatabaseValue(@surveyType)));
			parameters.Add(new SqlParameter("@CoverImg", EntityBase.GetDatabaseValue(@coverImg)));
			parameters.Add(new SqlParameter("@IsWechatShow", @isWechatShow));
			parameters.Add(new SqlParameter("@IsAPPUserShow", @isAPPUserShow));
			parameters.Add(new SqlParameter("@IsAPPCustomerShow", @isAPPCustomerShow));
			parameters.Add(new SqlParameter("@DayVoteLimitCount", EntityBase.GetDatabaseValue(@dayVoteLimitCount)));
			parameters.Add(new SqlParameter("@ALLVoteLimitCount", EntityBase.GetDatabaseValue(@aLLVoteLimitCount)));
			parameters.Add(new SqlParameter("@IsAllowRepeatVote", @isAllowRepeatVote));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_Survey from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_Survey(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_Survey(@iD, helper);
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
		/// Deletes a Wechat_Survey from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_Survey(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_Survey]
WHERE 
	[Wechat_Survey].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_Survey object.
		/// </summary>
		/// <returns>The newly created Wechat_Survey object.</returns>
		public static Wechat_Survey CreateWechat_Survey()
		{
			return InitializeNew<Wechat_Survey>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_Survey by a Wechat_Survey's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_Survey</returns>
		public static Wechat_Survey GetWechat_Survey(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_Survey.SelectFieldList + @"
FROM [dbo].[Wechat_Survey] 
WHERE 
	[Wechat_Survey].[ID] = @ID " + Wechat_Survey.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_Survey>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_Survey by a Wechat_Survey's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_Survey</returns>
		public static Wechat_Survey GetWechat_Survey(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_Survey.SelectFieldList + @"
FROM [dbo].[Wechat_Survey] 
WHERE 
	[Wechat_Survey].[ID] = @ID " + Wechat_Survey.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_Survey>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Survey objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_Survey objects.</returns>
		public static EntityList<Wechat_Survey> GetWechat_Surveys()
		{
			string commandText = @"
SELECT " + Wechat_Survey.SelectFieldList + "FROM [dbo].[Wechat_Survey] " + Wechat_Survey.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_Survey>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_Survey objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_Survey objects.</returns>
        public static EntityList<Wechat_Survey> GetWechat_Surveys(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Survey>(SelectFieldList, "FROM [dbo].[Wechat_Survey]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_Survey objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_Survey objects.</returns>
        public static EntityList<Wechat_Survey> GetWechat_Surveys(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Survey>(SelectFieldList, "FROM [dbo].[Wechat_Survey]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_Survey objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_Survey objects.</returns>
		protected static EntityList<Wechat_Survey> GetWechat_Surveys(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Surveys(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Survey objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Survey objects.</returns>
		protected static EntityList<Wechat_Survey> GetWechat_Surveys(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Surveys(string.Empty, where, parameters, Wechat_Survey.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Survey objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Survey objects.</returns>
		protected static EntityList<Wechat_Survey> GetWechat_Surveys(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Surveys(prefix, where, parameters, Wechat_Survey.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Survey objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Survey objects.</returns>
		protected static EntityList<Wechat_Survey> GetWechat_Surveys(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_Surveys(string.Empty, where, parameters, Wechat_Survey.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Survey objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Survey objects.</returns>
		protected static EntityList<Wechat_Survey> GetWechat_Surveys(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_Surveys(prefix, where, parameters, Wechat_Survey.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Survey objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_Survey objects.</returns>
		protected static EntityList<Wechat_Survey> GetWechat_Surveys(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_Survey.SelectFieldList + "FROM [dbo].[Wechat_Survey] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_Survey>(reader);
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
        protected static EntityList<Wechat_Survey> GetWechat_Surveys(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Survey>(SelectFieldList, "FROM [dbo].[Wechat_Survey] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_Survey objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_SurveyCount()
        {
            return GetWechat_SurveyCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_Survey objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_SurveyCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_Survey] " + where;

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
		public static partial class Wechat_Survey_Properties
		{
			public const string ID = "ID";
			public const string Title = "Title";
			public const string Description = "Description";
			public const string Status = "Status";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string SurveyType = "SurveyType";
			public const string CoverImg = "CoverImg";
			public const string IsWechatShow = "IsWechatShow";
			public const string IsAPPUserShow = "IsAPPUserShow";
			public const string IsAPPCustomerShow = "IsAPPCustomerShow";
			public const string DayVoteLimitCount = "DayVoteLimitCount";
			public const string ALLVoteLimitCount = "ALLVoteLimitCount";
			public const string IsAllowRepeatVote = "IsAllowRepeatVote";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Title" , "string:"},
    			 {"Description" , "string:"},
    			 {"Status" , "int:1-发布 0-未发布"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"SurveyType" , "int:1-调查问卷 2-社区投票 3-点赞物业"},
    			 {"CoverImg" , "string:"},
    			 {"IsWechatShow" , "bool:"},
    			 {"IsAPPUserShow" , "bool:"},
    			 {"IsAPPCustomerShow" , "bool:"},
    			 {"DayVoteLimitCount" , "int:"},
    			 {"ALLVoteLimitCount" , "int:"},
    			 {"IsAllowRepeatVote" , "bool:"},
            };
		}
		#endregion
	}
}
