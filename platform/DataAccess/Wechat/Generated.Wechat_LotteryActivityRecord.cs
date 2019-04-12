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
	/// This object represents the properties and methods of a Wechat_LotteryActivityRecord.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_LotteryActivityRecord 
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
		private string _openID = String.Empty;
		/// <summary>
		/// 参与人OpenID
		/// </summary>
        [Description("参与人OpenID")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string OpenID
		{
			[DebuggerStepThrough()]
			get { return this._openID; }
			set 
			{
				if (this._openID != value) 
				{
					this._openID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OpenID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _activityID = int.MinValue;
		/// <summary>
		/// 活动ID
		/// </summary>
        [Description("活动ID")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ActivityID
		{
			[DebuggerStepThrough()]
			get { return this._activityID; }
			set 
			{
				if (this._activityID != value) 
				{
					this._activityID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ActivityID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _prizeID = int.MinValue;
		/// <summary>
		/// 奖品ID（未中奖的为0）
		/// </summary>
        [Description("奖品ID（未中奖的为0）")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int PrizeID
		{
			[DebuggerStepThrough()]
			get { return this._prizeID; }
			set 
			{
				if (this._prizeID != value) 
				{
					this._prizeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrizeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _recordTime = DateTime.MinValue;
		/// <summary>
		/// 抽奖时间
		/// </summary>
        [Description("抽奖时间")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime RecordTime
		{
			[DebuggerStepThrough()]
			get { return this._recordTime; }
			set 
			{
				if (this._recordTime != value) 
				{
					this._recordTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("RecordTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _billNumber = String.Empty;
		/// <summary>
		/// 奖品发送订单号
		/// </summary>
        [Description("奖品发送订单号")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BillNumber
		{
			[DebuggerStepThrough()]
			get { return this._billNumber; }
			set 
			{
				if (this._billNumber != value) 
				{
					this._billNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("BillNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _sendTime = DateTime.MinValue;
		/// <summary>
		/// 奖品发送时间
		/// </summary>
        [Description("奖品发送时间")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime SendTime
		{
			[DebuggerStepThrough()]
			get { return this._sendTime; }
			set 
			{
				if (this._sendTime != value) 
				{
					this._sendTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("SendTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sendResult = String.Empty;
		/// <summary>
		/// 奖品发送结果
		/// </summary>
        [Description("奖品发送结果")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SendResult
		{
			[DebuggerStepThrough()]
			get { return this._sendResult; }
			set 
			{
				if (this._sendResult != value) 
				{
					this._sendResult = value;
					this.IsDirty = true;	
					OnPropertyChanged("SendResult");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _completeSend = false;
		/// <summary>
		/// 是否已经完成发送（未完成的需要重新发送）
		/// </summary>
        [Description("是否已经完成发送（未完成的需要重新发送）")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool CompleteSend
		{
			[DebuggerStepThrough()]
			get { return this._completeSend; }
			set 
			{
				if (this._completeSend != value) 
				{
					this._completeSend = value;
					this.IsDirty = true;	
					OnPropertyChanged("CompleteSend");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sender = String.Empty;
		/// <summary>
		/// 发送人
		/// </summary>
        [Description("发送人")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Sender
		{
			[DebuggerStepThrough()]
			get { return this._sender; }
			set 
			{
				if (this._sender != value) 
				{
					this._sender = value;
					this.IsDirty = true;	
					OnPropertyChanged("Sender");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _authUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int AuthUserID
		{
			[DebuggerStepThrough()]
			get { return this._authUserID; }
			set 
			{
				if (this._authUserID != value) 
				{
					this._authUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AuthUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _param1 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Param1
		{
			[DebuggerStepThrough()]
			get { return this._param1; }
			set 
			{
				if (this._param1 != value) 
				{
					this._param1 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Param1");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _param2 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Param2
		{
			[DebuggerStepThrough()]
			get { return this._param2; }
			set 
			{
				if (this._param2 != value) 
				{
					this._param2 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Param2");
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
	[OpenID] nvarchar(200),
	[ActivityID] int,
	[PrizeID] int,
	[RecordTime] datetime,
	[BillNumber] nvarchar(50),
	[SendTime] datetime,
	[SendResult] nvarchar(200),
	[CompleteSend] bit,
	[Sender] nvarchar(200),
	[AuthUserID] int,
	[Param1] nvarchar(100),
	[Param2] nvarchar(100)
);

INSERT INTO [dbo].[Wechat_LotteryActivityRecord] (
	[Wechat_LotteryActivityRecord].[OpenID],
	[Wechat_LotteryActivityRecord].[ActivityID],
	[Wechat_LotteryActivityRecord].[PrizeID],
	[Wechat_LotteryActivityRecord].[RecordTime],
	[Wechat_LotteryActivityRecord].[BillNumber],
	[Wechat_LotteryActivityRecord].[SendTime],
	[Wechat_LotteryActivityRecord].[SendResult],
	[Wechat_LotteryActivityRecord].[CompleteSend],
	[Wechat_LotteryActivityRecord].[Sender],
	[Wechat_LotteryActivityRecord].[AuthUserID],
	[Wechat_LotteryActivityRecord].[Param1],
	[Wechat_LotteryActivityRecord].[Param2]
) 
output 
	INSERTED.[ID],
	INSERTED.[OpenID],
	INSERTED.[ActivityID],
	INSERTED.[PrizeID],
	INSERTED.[RecordTime],
	INSERTED.[BillNumber],
	INSERTED.[SendTime],
	INSERTED.[SendResult],
	INSERTED.[CompleteSend],
	INSERTED.[Sender],
	INSERTED.[AuthUserID],
	INSERTED.[Param1],
	INSERTED.[Param2]
into @table
VALUES ( 
	@OpenID,
	@ActivityID,
	@PrizeID,
	@RecordTime,
	@BillNumber,
	@SendTime,
	@SendResult,
	@CompleteSend,
	@Sender,
	@AuthUserID,
	@Param1,
	@Param2 
); 

SELECT 
	[ID],
	[OpenID],
	[ActivityID],
	[PrizeID],
	[RecordTime],
	[BillNumber],
	[SendTime],
	[SendResult],
	[CompleteSend],
	[Sender],
	[AuthUserID],
	[Param1],
	[Param2] 
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
	[OpenID] nvarchar(200),
	[ActivityID] int,
	[PrizeID] int,
	[RecordTime] datetime,
	[BillNumber] nvarchar(50),
	[SendTime] datetime,
	[SendResult] nvarchar(200),
	[CompleteSend] bit,
	[Sender] nvarchar(200),
	[AuthUserID] int,
	[Param1] nvarchar(100),
	[Param2] nvarchar(100)
);

UPDATE [dbo].[Wechat_LotteryActivityRecord] SET 
	[Wechat_LotteryActivityRecord].[OpenID] = @OpenID,
	[Wechat_LotteryActivityRecord].[ActivityID] = @ActivityID,
	[Wechat_LotteryActivityRecord].[PrizeID] = @PrizeID,
	[Wechat_LotteryActivityRecord].[RecordTime] = @RecordTime,
	[Wechat_LotteryActivityRecord].[BillNumber] = @BillNumber,
	[Wechat_LotteryActivityRecord].[SendTime] = @SendTime,
	[Wechat_LotteryActivityRecord].[SendResult] = @SendResult,
	[Wechat_LotteryActivityRecord].[CompleteSend] = @CompleteSend,
	[Wechat_LotteryActivityRecord].[Sender] = @Sender,
	[Wechat_LotteryActivityRecord].[AuthUserID] = @AuthUserID,
	[Wechat_LotteryActivityRecord].[Param1] = @Param1,
	[Wechat_LotteryActivityRecord].[Param2] = @Param2 
output 
	INSERTED.[ID],
	INSERTED.[OpenID],
	INSERTED.[ActivityID],
	INSERTED.[PrizeID],
	INSERTED.[RecordTime],
	INSERTED.[BillNumber],
	INSERTED.[SendTime],
	INSERTED.[SendResult],
	INSERTED.[CompleteSend],
	INSERTED.[Sender],
	INSERTED.[AuthUserID],
	INSERTED.[Param1],
	INSERTED.[Param2]
into @table
WHERE 
	[Wechat_LotteryActivityRecord].[ID] = @ID

SELECT 
	[ID],
	[OpenID],
	[ActivityID],
	[PrizeID],
	[RecordTime],
	[BillNumber],
	[SendTime],
	[SendResult],
	[CompleteSend],
	[Sender],
	[AuthUserID],
	[Param1],
	[Param2] 
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
DELETE FROM [dbo].[Wechat_LotteryActivityRecord]
WHERE 
	[Wechat_LotteryActivityRecord].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_LotteryActivityRecord() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_LotteryActivityRecord(this.ID));
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
	[Wechat_LotteryActivityRecord].[ID],
	[Wechat_LotteryActivityRecord].[OpenID],
	[Wechat_LotteryActivityRecord].[ActivityID],
	[Wechat_LotteryActivityRecord].[PrizeID],
	[Wechat_LotteryActivityRecord].[RecordTime],
	[Wechat_LotteryActivityRecord].[BillNumber],
	[Wechat_LotteryActivityRecord].[SendTime],
	[Wechat_LotteryActivityRecord].[SendResult],
	[Wechat_LotteryActivityRecord].[CompleteSend],
	[Wechat_LotteryActivityRecord].[Sender],
	[Wechat_LotteryActivityRecord].[AuthUserID],
	[Wechat_LotteryActivityRecord].[Param1],
	[Wechat_LotteryActivityRecord].[Param2]
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
                return "Wechat_LotteryActivityRecord";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_LotteryActivityRecord into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="openID">openID</param>
		/// <param name="activityID">activityID</param>
		/// <param name="prizeID">prizeID</param>
		/// <param name="recordTime">recordTime</param>
		/// <param name="billNumber">billNumber</param>
		/// <param name="sendTime">sendTime</param>
		/// <param name="sendResult">sendResult</param>
		/// <param name="completeSend">completeSend</param>
		/// <param name="sender">sender</param>
		/// <param name="authUserID">authUserID</param>
		/// <param name="param1">param1</param>
		/// <param name="param2">param2</param>
		public static void InsertWechat_LotteryActivityRecord(string @openID, int @activityID, int @prizeID, DateTime @recordTime, string @billNumber, DateTime @sendTime, string @sendResult, bool @completeSend, string @sender, int @authUserID, string @param1, string @param2)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_LotteryActivityRecord(@openID, @activityID, @prizeID, @recordTime, @billNumber, @sendTime, @sendResult, @completeSend, @sender, @authUserID, @param1, @param2, helper);
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
		/// Insert a Wechat_LotteryActivityRecord into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="openID">openID</param>
		/// <param name="activityID">activityID</param>
		/// <param name="prizeID">prizeID</param>
		/// <param name="recordTime">recordTime</param>
		/// <param name="billNumber">billNumber</param>
		/// <param name="sendTime">sendTime</param>
		/// <param name="sendResult">sendResult</param>
		/// <param name="completeSend">completeSend</param>
		/// <param name="sender">sender</param>
		/// <param name="authUserID">authUserID</param>
		/// <param name="param1">param1</param>
		/// <param name="param2">param2</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_LotteryActivityRecord(string @openID, int @activityID, int @prizeID, DateTime @recordTime, string @billNumber, DateTime @sendTime, string @sendResult, bool @completeSend, string @sender, int @authUserID, string @param1, string @param2, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OpenID] nvarchar(200),
	[ActivityID] int,
	[PrizeID] int,
	[RecordTime] datetime,
	[BillNumber] nvarchar(50),
	[SendTime] datetime,
	[SendResult] nvarchar(200),
	[CompleteSend] bit,
	[Sender] nvarchar(200),
	[AuthUserID] int,
	[Param1] nvarchar(100),
	[Param2] nvarchar(100)
);

INSERT INTO [dbo].[Wechat_LotteryActivityRecord] (
	[Wechat_LotteryActivityRecord].[OpenID],
	[Wechat_LotteryActivityRecord].[ActivityID],
	[Wechat_LotteryActivityRecord].[PrizeID],
	[Wechat_LotteryActivityRecord].[RecordTime],
	[Wechat_LotteryActivityRecord].[BillNumber],
	[Wechat_LotteryActivityRecord].[SendTime],
	[Wechat_LotteryActivityRecord].[SendResult],
	[Wechat_LotteryActivityRecord].[CompleteSend],
	[Wechat_LotteryActivityRecord].[Sender],
	[Wechat_LotteryActivityRecord].[AuthUserID],
	[Wechat_LotteryActivityRecord].[Param1],
	[Wechat_LotteryActivityRecord].[Param2]
) 
output 
	INSERTED.[ID],
	INSERTED.[OpenID],
	INSERTED.[ActivityID],
	INSERTED.[PrizeID],
	INSERTED.[RecordTime],
	INSERTED.[BillNumber],
	INSERTED.[SendTime],
	INSERTED.[SendResult],
	INSERTED.[CompleteSend],
	INSERTED.[Sender],
	INSERTED.[AuthUserID],
	INSERTED.[Param1],
	INSERTED.[Param2]
into @table
VALUES ( 
	@OpenID,
	@ActivityID,
	@PrizeID,
	@RecordTime,
	@BillNumber,
	@SendTime,
	@SendResult,
	@CompleteSend,
	@Sender,
	@AuthUserID,
	@Param1,
	@Param2 
); 

SELECT 
	[ID],
	[OpenID],
	[ActivityID],
	[PrizeID],
	[RecordTime],
	[BillNumber],
	[SendTime],
	[SendResult],
	[CompleteSend],
	[Sender],
	[AuthUserID],
	[Param1],
	[Param2] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@ActivityID", EntityBase.GetDatabaseValue(@activityID)));
			parameters.Add(new SqlParameter("@PrizeID", EntityBase.GetDatabaseValue(@prizeID)));
			parameters.Add(new SqlParameter("@RecordTime", EntityBase.GetDatabaseValue(@recordTime)));
			parameters.Add(new SqlParameter("@BillNumber", EntityBase.GetDatabaseValue(@billNumber)));
			parameters.Add(new SqlParameter("@SendTime", EntityBase.GetDatabaseValue(@sendTime)));
			parameters.Add(new SqlParameter("@SendResult", EntityBase.GetDatabaseValue(@sendResult)));
			parameters.Add(new SqlParameter("@CompleteSend", @completeSend));
			parameters.Add(new SqlParameter("@Sender", EntityBase.GetDatabaseValue(@sender)));
			parameters.Add(new SqlParameter("@AuthUserID", EntityBase.GetDatabaseValue(@authUserID)));
			parameters.Add(new SqlParameter("@Param1", EntityBase.GetDatabaseValue(@param1)));
			parameters.Add(new SqlParameter("@Param2", EntityBase.GetDatabaseValue(@param2)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_LotteryActivityRecord into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="openID">openID</param>
		/// <param name="activityID">activityID</param>
		/// <param name="prizeID">prizeID</param>
		/// <param name="recordTime">recordTime</param>
		/// <param name="billNumber">billNumber</param>
		/// <param name="sendTime">sendTime</param>
		/// <param name="sendResult">sendResult</param>
		/// <param name="completeSend">completeSend</param>
		/// <param name="sender">sender</param>
		/// <param name="authUserID">authUserID</param>
		/// <param name="param1">param1</param>
		/// <param name="param2">param2</param>
		public static void UpdateWechat_LotteryActivityRecord(int @iD, string @openID, int @activityID, int @prizeID, DateTime @recordTime, string @billNumber, DateTime @sendTime, string @sendResult, bool @completeSend, string @sender, int @authUserID, string @param1, string @param2)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_LotteryActivityRecord(@iD, @openID, @activityID, @prizeID, @recordTime, @billNumber, @sendTime, @sendResult, @completeSend, @sender, @authUserID, @param1, @param2, helper);
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
		/// Updates a Wechat_LotteryActivityRecord into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="openID">openID</param>
		/// <param name="activityID">activityID</param>
		/// <param name="prizeID">prizeID</param>
		/// <param name="recordTime">recordTime</param>
		/// <param name="billNumber">billNumber</param>
		/// <param name="sendTime">sendTime</param>
		/// <param name="sendResult">sendResult</param>
		/// <param name="completeSend">completeSend</param>
		/// <param name="sender">sender</param>
		/// <param name="authUserID">authUserID</param>
		/// <param name="param1">param1</param>
		/// <param name="param2">param2</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_LotteryActivityRecord(int @iD, string @openID, int @activityID, int @prizeID, DateTime @recordTime, string @billNumber, DateTime @sendTime, string @sendResult, bool @completeSend, string @sender, int @authUserID, string @param1, string @param2, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OpenID] nvarchar(200),
	[ActivityID] int,
	[PrizeID] int,
	[RecordTime] datetime,
	[BillNumber] nvarchar(50),
	[SendTime] datetime,
	[SendResult] nvarchar(200),
	[CompleteSend] bit,
	[Sender] nvarchar(200),
	[AuthUserID] int,
	[Param1] nvarchar(100),
	[Param2] nvarchar(100)
);

UPDATE [dbo].[Wechat_LotteryActivityRecord] SET 
	[Wechat_LotteryActivityRecord].[OpenID] = @OpenID,
	[Wechat_LotteryActivityRecord].[ActivityID] = @ActivityID,
	[Wechat_LotteryActivityRecord].[PrizeID] = @PrizeID,
	[Wechat_LotteryActivityRecord].[RecordTime] = @RecordTime,
	[Wechat_LotteryActivityRecord].[BillNumber] = @BillNumber,
	[Wechat_LotteryActivityRecord].[SendTime] = @SendTime,
	[Wechat_LotteryActivityRecord].[SendResult] = @SendResult,
	[Wechat_LotteryActivityRecord].[CompleteSend] = @CompleteSend,
	[Wechat_LotteryActivityRecord].[Sender] = @Sender,
	[Wechat_LotteryActivityRecord].[AuthUserID] = @AuthUserID,
	[Wechat_LotteryActivityRecord].[Param1] = @Param1,
	[Wechat_LotteryActivityRecord].[Param2] = @Param2 
output 
	INSERTED.[ID],
	INSERTED.[OpenID],
	INSERTED.[ActivityID],
	INSERTED.[PrizeID],
	INSERTED.[RecordTime],
	INSERTED.[BillNumber],
	INSERTED.[SendTime],
	INSERTED.[SendResult],
	INSERTED.[CompleteSend],
	INSERTED.[Sender],
	INSERTED.[AuthUserID],
	INSERTED.[Param1],
	INSERTED.[Param2]
into @table
WHERE 
	[Wechat_LotteryActivityRecord].[ID] = @ID

SELECT 
	[ID],
	[OpenID],
	[ActivityID],
	[PrizeID],
	[RecordTime],
	[BillNumber],
	[SendTime],
	[SendResult],
	[CompleteSend],
	[Sender],
	[AuthUserID],
	[Param1],
	[Param2] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@ActivityID", EntityBase.GetDatabaseValue(@activityID)));
			parameters.Add(new SqlParameter("@PrizeID", EntityBase.GetDatabaseValue(@prizeID)));
			parameters.Add(new SqlParameter("@RecordTime", EntityBase.GetDatabaseValue(@recordTime)));
			parameters.Add(new SqlParameter("@BillNumber", EntityBase.GetDatabaseValue(@billNumber)));
			parameters.Add(new SqlParameter("@SendTime", EntityBase.GetDatabaseValue(@sendTime)));
			parameters.Add(new SqlParameter("@SendResult", EntityBase.GetDatabaseValue(@sendResult)));
			parameters.Add(new SqlParameter("@CompleteSend", @completeSend));
			parameters.Add(new SqlParameter("@Sender", EntityBase.GetDatabaseValue(@sender)));
			parameters.Add(new SqlParameter("@AuthUserID", EntityBase.GetDatabaseValue(@authUserID)));
			parameters.Add(new SqlParameter("@Param1", EntityBase.GetDatabaseValue(@param1)));
			parameters.Add(new SqlParameter("@Param2", EntityBase.GetDatabaseValue(@param2)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_LotteryActivityRecord from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_LotteryActivityRecord(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_LotteryActivityRecord(@iD, helper);
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
		/// Deletes a Wechat_LotteryActivityRecord from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_LotteryActivityRecord(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_LotteryActivityRecord]
WHERE 
	[Wechat_LotteryActivityRecord].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_LotteryActivityRecord object.
		/// </summary>
		/// <returns>The newly created Wechat_LotteryActivityRecord object.</returns>
		public static Wechat_LotteryActivityRecord CreateWechat_LotteryActivityRecord()
		{
			return InitializeNew<Wechat_LotteryActivityRecord>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_LotteryActivityRecord by a Wechat_LotteryActivityRecord's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_LotteryActivityRecord</returns>
		public static Wechat_LotteryActivityRecord GetWechat_LotteryActivityRecord(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_LotteryActivityRecord.SelectFieldList + @"
FROM [dbo].[Wechat_LotteryActivityRecord] 
WHERE 
	[Wechat_LotteryActivityRecord].[ID] = @ID " + Wechat_LotteryActivityRecord.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_LotteryActivityRecord>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_LotteryActivityRecord by a Wechat_LotteryActivityRecord's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_LotteryActivityRecord</returns>
		public static Wechat_LotteryActivityRecord GetWechat_LotteryActivityRecord(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_LotteryActivityRecord.SelectFieldList + @"
FROM [dbo].[Wechat_LotteryActivityRecord] 
WHERE 
	[Wechat_LotteryActivityRecord].[ID] = @ID " + Wechat_LotteryActivityRecord.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_LotteryActivityRecord>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityRecord objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_LotteryActivityRecord objects.</returns>
		public static EntityList<Wechat_LotteryActivityRecord> GetWechat_LotteryActivityRecords()
		{
			string commandText = @"
SELECT " + Wechat_LotteryActivityRecord.SelectFieldList + "FROM [dbo].[Wechat_LotteryActivityRecord] " + Wechat_LotteryActivityRecord.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_LotteryActivityRecord>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_LotteryActivityRecord objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_LotteryActivityRecord objects.</returns>
        public static EntityList<Wechat_LotteryActivityRecord> GetWechat_LotteryActivityRecords(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_LotteryActivityRecord>(SelectFieldList, "FROM [dbo].[Wechat_LotteryActivityRecord]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_LotteryActivityRecord objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_LotteryActivityRecord objects.</returns>
        public static EntityList<Wechat_LotteryActivityRecord> GetWechat_LotteryActivityRecords(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_LotteryActivityRecord>(SelectFieldList, "FROM [dbo].[Wechat_LotteryActivityRecord]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityRecord objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivityRecord objects.</returns>
		protected static EntityList<Wechat_LotteryActivityRecord> GetWechat_LotteryActivityRecords(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_LotteryActivityRecords(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityRecord objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivityRecord objects.</returns>
		protected static EntityList<Wechat_LotteryActivityRecord> GetWechat_LotteryActivityRecords(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_LotteryActivityRecords(string.Empty, where, parameters, Wechat_LotteryActivityRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityRecord objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivityRecord objects.</returns>
		protected static EntityList<Wechat_LotteryActivityRecord> GetWechat_LotteryActivityRecords(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_LotteryActivityRecords(prefix, where, parameters, Wechat_LotteryActivityRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityRecord objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivityRecord objects.</returns>
		protected static EntityList<Wechat_LotteryActivityRecord> GetWechat_LotteryActivityRecords(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_LotteryActivityRecords(string.Empty, where, parameters, Wechat_LotteryActivityRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityRecord objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivityRecord objects.</returns>
		protected static EntityList<Wechat_LotteryActivityRecord> GetWechat_LotteryActivityRecords(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_LotteryActivityRecords(prefix, where, parameters, Wechat_LotteryActivityRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityRecord objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivityRecord objects.</returns>
		protected static EntityList<Wechat_LotteryActivityRecord> GetWechat_LotteryActivityRecords(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_LotteryActivityRecord.SelectFieldList + "FROM [dbo].[Wechat_LotteryActivityRecord] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_LotteryActivityRecord>(reader);
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
        protected static EntityList<Wechat_LotteryActivityRecord> GetWechat_LotteryActivityRecords(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_LotteryActivityRecord>(SelectFieldList, "FROM [dbo].[Wechat_LotteryActivityRecord] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_LotteryActivityRecord objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_LotteryActivityRecordCount()
        {
            return GetWechat_LotteryActivityRecordCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_LotteryActivityRecord objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_LotteryActivityRecordCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_LotteryActivityRecord] " + where;

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
		public static partial class Wechat_LotteryActivityRecord_Properties
		{
			public const string ID = "ID";
			public const string OpenID = "OpenID";
			public const string ActivityID = "ActivityID";
			public const string PrizeID = "PrizeID";
			public const string RecordTime = "RecordTime";
			public const string BillNumber = "BillNumber";
			public const string SendTime = "SendTime";
			public const string SendResult = "SendResult";
			public const string CompleteSend = "CompleteSend";
			public const string Sender = "Sender";
			public const string AuthUserID = "AuthUserID";
			public const string Param1 = "Param1";
			public const string Param2 = "Param2";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OpenID" , "string:参与人OpenID"},
    			 {"ActivityID" , "int:活动ID"},
    			 {"PrizeID" , "int:奖品ID（未中奖的为0）"},
    			 {"RecordTime" , "DateTime:抽奖时间"},
    			 {"BillNumber" , "string:奖品发送订单号"},
    			 {"SendTime" , "DateTime:奖品发送时间"},
    			 {"SendResult" , "string:奖品发送结果"},
    			 {"CompleteSend" , "bool:是否已经完成发送（未完成的需要重新发送）"},
    			 {"Sender" , "string:发送人"},
    			 {"AuthUserID" , "int:"},
    			 {"Param1" , "string:"},
    			 {"Param2" , "string:"},
            };
		}
		#endregion
	}
}
