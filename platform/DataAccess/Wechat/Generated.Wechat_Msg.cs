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
	/// This object represents the properties and methods of a Wechat_Msg.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_Msg 
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
		private string _msgTitle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string MsgTitle
		{
			[DebuggerStepThrough()]
			get { return this._msgTitle; }
			set 
			{
				if (this._msgTitle != value) 
				{
					this._msgTitle = value;
					this.IsDirty = true;	
					OnPropertyChanged("MsgTitle");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _msgSummary = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string MsgSummary
		{
			[DebuggerStepThrough()]
			get { return this._msgSummary; }
			set 
			{
				if (this._msgSummary != value) 
				{
					this._msgSummary = value;
					this.IsDirty = true;	
					OnPropertyChanged("MsgSummary");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _msgContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string MsgContent
		{
			[DebuggerStepThrough()]
			get { return this._msgContent; }
			set 
			{
				if (this._msgContent != value) 
				{
					this._msgContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("MsgContent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _publishTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime PublishTime
		{
			[DebuggerStepThrough()]
			get { return this._publishTime; }
			set 
			{
				if (this._publishTime != value) 
				{
					this._publishTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("PublishTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _sortOrder = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SortOrder
		{
			[DebuggerStepThrough()]
			get { return this._sortOrder; }
			set 
			{
				if (this._sortOrder != value) 
				{
					this._sortOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("SortOrder");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isShow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsShow
		{
			[DebuggerStepThrough()]
			get { return this._isShow; }
			set 
			{
				if (this._isShow != value) 
				{
					this._isShow = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsShow");
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
		private string _picPath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PicPath
		{
			[DebuggerStepThrough()]
			get { return this._picPath; }
			set 
			{
				if (this._picPath != value) 
				{
					this._picPath = value;
					this.IsDirty = true;	
					OnPropertyChanged("PicPath");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _msgType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string MsgType
		{
			[DebuggerStepThrough()]
			get { return this._msgType; }
			set 
			{
				if (this._msgType != value) 
				{
					this._msgType = value;
					this.IsDirty = true;	
					OnPropertyChanged("MsgType");
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
		private bool _isTopShow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsTopShow
		{
			[DebuggerStepThrough()]
			get { return this._isTopShow; }
			set 
			{
				if (this._isTopShow != value) 
				{
					this._isTopShow = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsTopShow");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isSending = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsSending
		{
			[DebuggerStepThrough()]
			get { return this._isSending; }
			set 
			{
				if (this._isSending != value) 
				{
					this._isSending = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsSending");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sendingMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SendingMan
		{
			[DebuggerStepThrough()]
			get { return this._sendingMan; }
			set 
			{
				if (this._sendingMan != value) 
				{
					this._sendingMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("SendingMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isWechatSend = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsWechatSend
		{
			[DebuggerStepThrough()]
			get { return this._isWechatSend; }
			set 
			{
				if (this._isWechatSend != value) 
				{
					this._isWechatSend = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsWechatSend");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _hTMLContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string HTMLContent
		{
			[DebuggerStepThrough()]
			get { return this._hTMLContent; }
			set 
			{
				if (this._hTMLContent != value) 
				{
					this._hTMLContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("HTMLContent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _mobileSendTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime MobileSendTime
		{
			[DebuggerStepThrough()]
			get { return this._mobileSendTime; }
			set 
			{
				if (this._mobileSendTime != value) 
				{
					this._mobileSendTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("MobileSendTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _mobileSendResult = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string MobileSendResult
		{
			[DebuggerStepThrough()]
			get { return this._mobileSendResult; }
			set 
			{
				if (this._mobileSendResult != value) 
				{
					this._mobileSendResult = value;
					this.IsDirty = true;	
					OnPropertyChanged("MobileSendResult");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isUserAPPSend = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsUserAPPSend
		{
			[DebuggerStepThrough()]
			get { return this._isUserAPPSend; }
			set 
			{
				if (this._isUserAPPSend != value) 
				{
					this._isUserAPPSend = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsUserAPPSend");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isCustomerAPPSend = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsCustomerAPPSend
		{
			[DebuggerStepThrough()]
			get { return this._isCustomerAPPSend; }
			set 
			{
				if (this._isCustomerAPPSend != value) 
				{
					this._isCustomerAPPSend = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsCustomerAPPSend");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _categoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CategoryID
		{
			[DebuggerStepThrough()]
			get { return this._categoryID; }
			set 
			{
				if (this._categoryID != value) 
				{
					this._categoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CategoryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _aPPCustomerReadCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int APPCustomerReadCount
		{
			[DebuggerStepThrough()]
			get { return this._aPPCustomerReadCount; }
			set 
			{
				if (this._aPPCustomerReadCount != value) 
				{
					this._aPPCustomerReadCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("APPCustomerReadCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isBusinessAPPSend = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsBusinessAPPSend
		{
			[DebuggerStepThrough()]
			get { return this._isBusinessAPPSend; }
			set 
			{
				if (this._isBusinessAPPSend != value) 
				{
					this._isBusinessAPPSend = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsBusinessAPPSend");
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
	[MsgTitle] nvarchar(200),
	[MsgSummary] nvarchar(500),
	[MsgContent] ntext,
	[PublishTime] datetime,
	[SortOrder] int,
	[IsShow] bit,
	[AddTime] datetime,
	[PicPath] nvarchar(2000),
	[MsgType] nvarchar(50),
	[StartTime] datetime,
	[EndTime] datetime,
	[IsTopShow] bit,
	[IsSending] bit,
	[SendingMan] nvarchar(100),
	[IsWechatSend] bit,
	[HTMLContent] ntext,
	[MobileSendTime] datetime,
	[MobileSendResult] ntext,
	[IsUserAPPSend] bit,
	[IsCustomerAPPSend] bit,
	[CategoryID] int,
	[APPCustomerReadCount] int,
	[IsBusinessAPPSend] bit
);

INSERT INTO [dbo].[Wechat_Msg] (
	[Wechat_Msg].[MsgTitle],
	[Wechat_Msg].[MsgSummary],
	[Wechat_Msg].[MsgContent],
	[Wechat_Msg].[PublishTime],
	[Wechat_Msg].[SortOrder],
	[Wechat_Msg].[IsShow],
	[Wechat_Msg].[AddTime],
	[Wechat_Msg].[PicPath],
	[Wechat_Msg].[MsgType],
	[Wechat_Msg].[StartTime],
	[Wechat_Msg].[EndTime],
	[Wechat_Msg].[IsTopShow],
	[Wechat_Msg].[IsSending],
	[Wechat_Msg].[SendingMan],
	[Wechat_Msg].[IsWechatSend],
	[Wechat_Msg].[HTMLContent],
	[Wechat_Msg].[MobileSendTime],
	[Wechat_Msg].[MobileSendResult],
	[Wechat_Msg].[IsUserAPPSend],
	[Wechat_Msg].[IsCustomerAPPSend],
	[Wechat_Msg].[CategoryID],
	[Wechat_Msg].[APPCustomerReadCount],
	[Wechat_Msg].[IsBusinessAPPSend]
) 
output 
	INSERTED.[ID],
	INSERTED.[MsgTitle],
	INSERTED.[MsgSummary],
	INSERTED.[MsgContent],
	INSERTED.[PublishTime],
	INSERTED.[SortOrder],
	INSERTED.[IsShow],
	INSERTED.[AddTime],
	INSERTED.[PicPath],
	INSERTED.[MsgType],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[IsTopShow],
	INSERTED.[IsSending],
	INSERTED.[SendingMan],
	INSERTED.[IsWechatSend],
	INSERTED.[HTMLContent],
	INSERTED.[MobileSendTime],
	INSERTED.[MobileSendResult],
	INSERTED.[IsUserAPPSend],
	INSERTED.[IsCustomerAPPSend],
	INSERTED.[CategoryID],
	INSERTED.[APPCustomerReadCount],
	INSERTED.[IsBusinessAPPSend]
into @table
VALUES ( 
	@MsgTitle,
	@MsgSummary,
	@MsgContent,
	@PublishTime,
	@SortOrder,
	@IsShow,
	@AddTime,
	@PicPath,
	@MsgType,
	@StartTime,
	@EndTime,
	@IsTopShow,
	@IsSending,
	@SendingMan,
	@IsWechatSend,
	@HTMLContent,
	@MobileSendTime,
	@MobileSendResult,
	@IsUserAPPSend,
	@IsCustomerAPPSend,
	@CategoryID,
	@APPCustomerReadCount,
	@IsBusinessAPPSend 
); 

SELECT 
	[ID],
	[MsgTitle],
	[MsgSummary],
	[MsgContent],
	[PublishTime],
	[SortOrder],
	[IsShow],
	[AddTime],
	[PicPath],
	[MsgType],
	[StartTime],
	[EndTime],
	[IsTopShow],
	[IsSending],
	[SendingMan],
	[IsWechatSend],
	[HTMLContent],
	[MobileSendTime],
	[MobileSendResult],
	[IsUserAPPSend],
	[IsCustomerAPPSend],
	[CategoryID],
	[APPCustomerReadCount],
	[IsBusinessAPPSend] 
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
	[MsgTitle] nvarchar(200),
	[MsgSummary] nvarchar(500),
	[MsgContent] ntext,
	[PublishTime] datetime,
	[SortOrder] int,
	[IsShow] bit,
	[AddTime] datetime,
	[PicPath] nvarchar(2000),
	[MsgType] nvarchar(50),
	[StartTime] datetime,
	[EndTime] datetime,
	[IsTopShow] bit,
	[IsSending] bit,
	[SendingMan] nvarchar(100),
	[IsWechatSend] bit,
	[HTMLContent] ntext,
	[MobileSendTime] datetime,
	[MobileSendResult] ntext,
	[IsUserAPPSend] bit,
	[IsCustomerAPPSend] bit,
	[CategoryID] int,
	[APPCustomerReadCount] int,
	[IsBusinessAPPSend] bit
);

UPDATE [dbo].[Wechat_Msg] SET 
	[Wechat_Msg].[MsgTitle] = @MsgTitle,
	[Wechat_Msg].[MsgSummary] = @MsgSummary,
	[Wechat_Msg].[MsgContent] = @MsgContent,
	[Wechat_Msg].[PublishTime] = @PublishTime,
	[Wechat_Msg].[SortOrder] = @SortOrder,
	[Wechat_Msg].[IsShow] = @IsShow,
	[Wechat_Msg].[AddTime] = @AddTime,
	[Wechat_Msg].[PicPath] = @PicPath,
	[Wechat_Msg].[MsgType] = @MsgType,
	[Wechat_Msg].[StartTime] = @StartTime,
	[Wechat_Msg].[EndTime] = @EndTime,
	[Wechat_Msg].[IsTopShow] = @IsTopShow,
	[Wechat_Msg].[IsSending] = @IsSending,
	[Wechat_Msg].[SendingMan] = @SendingMan,
	[Wechat_Msg].[IsWechatSend] = @IsWechatSend,
	[Wechat_Msg].[HTMLContent] = @HTMLContent,
	[Wechat_Msg].[MobileSendTime] = @MobileSendTime,
	[Wechat_Msg].[MobileSendResult] = @MobileSendResult,
	[Wechat_Msg].[IsUserAPPSend] = @IsUserAPPSend,
	[Wechat_Msg].[IsCustomerAPPSend] = @IsCustomerAPPSend,
	[Wechat_Msg].[CategoryID] = @CategoryID,
	[Wechat_Msg].[APPCustomerReadCount] = @APPCustomerReadCount,
	[Wechat_Msg].[IsBusinessAPPSend] = @IsBusinessAPPSend 
output 
	INSERTED.[ID],
	INSERTED.[MsgTitle],
	INSERTED.[MsgSummary],
	INSERTED.[MsgContent],
	INSERTED.[PublishTime],
	INSERTED.[SortOrder],
	INSERTED.[IsShow],
	INSERTED.[AddTime],
	INSERTED.[PicPath],
	INSERTED.[MsgType],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[IsTopShow],
	INSERTED.[IsSending],
	INSERTED.[SendingMan],
	INSERTED.[IsWechatSend],
	INSERTED.[HTMLContent],
	INSERTED.[MobileSendTime],
	INSERTED.[MobileSendResult],
	INSERTED.[IsUserAPPSend],
	INSERTED.[IsCustomerAPPSend],
	INSERTED.[CategoryID],
	INSERTED.[APPCustomerReadCount],
	INSERTED.[IsBusinessAPPSend]
into @table
WHERE 
	[Wechat_Msg].[ID] = @ID

SELECT 
	[ID],
	[MsgTitle],
	[MsgSummary],
	[MsgContent],
	[PublishTime],
	[SortOrder],
	[IsShow],
	[AddTime],
	[PicPath],
	[MsgType],
	[StartTime],
	[EndTime],
	[IsTopShow],
	[IsSending],
	[SendingMan],
	[IsWechatSend],
	[HTMLContent],
	[MobileSendTime],
	[MobileSendResult],
	[IsUserAPPSend],
	[IsCustomerAPPSend],
	[CategoryID],
	[APPCustomerReadCount],
	[IsBusinessAPPSend] 
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
DELETE FROM [dbo].[Wechat_Msg]
WHERE 
	[Wechat_Msg].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_Msg() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_Msg(this.ID));
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
	[Wechat_Msg].[ID],
	[Wechat_Msg].[MsgTitle],
	[Wechat_Msg].[MsgSummary],
	[Wechat_Msg].[MsgContent],
	[Wechat_Msg].[PublishTime],
	[Wechat_Msg].[SortOrder],
	[Wechat_Msg].[IsShow],
	[Wechat_Msg].[AddTime],
	[Wechat_Msg].[PicPath],
	[Wechat_Msg].[MsgType],
	[Wechat_Msg].[StartTime],
	[Wechat_Msg].[EndTime],
	[Wechat_Msg].[IsTopShow],
	[Wechat_Msg].[IsSending],
	[Wechat_Msg].[SendingMan],
	[Wechat_Msg].[IsWechatSend],
	[Wechat_Msg].[HTMLContent],
	[Wechat_Msg].[MobileSendTime],
	[Wechat_Msg].[MobileSendResult],
	[Wechat_Msg].[IsUserAPPSend],
	[Wechat_Msg].[IsCustomerAPPSend],
	[Wechat_Msg].[CategoryID],
	[Wechat_Msg].[APPCustomerReadCount],
	[Wechat_Msg].[IsBusinessAPPSend]
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
                return "Wechat_Msg";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_Msg into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="msgTitle">msgTitle</param>
		/// <param name="msgSummary">msgSummary</param>
		/// <param name="msgContent">msgContent</param>
		/// <param name="publishTime">publishTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isShow">isShow</param>
		/// <param name="addTime">addTime</param>
		/// <param name="picPath">picPath</param>
		/// <param name="msgType">msgType</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="isTopShow">isTopShow</param>
		/// <param name="isSending">isSending</param>
		/// <param name="sendingMan">sendingMan</param>
		/// <param name="isWechatSend">isWechatSend</param>
		/// <param name="hTMLContent">hTMLContent</param>
		/// <param name="mobileSendTime">mobileSendTime</param>
		/// <param name="mobileSendResult">mobileSendResult</param>
		/// <param name="isUserAPPSend">isUserAPPSend</param>
		/// <param name="isCustomerAPPSend">isCustomerAPPSend</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="aPPCustomerReadCount">aPPCustomerReadCount</param>
		/// <param name="isBusinessAPPSend">isBusinessAPPSend</param>
		public static void InsertWechat_Msg(string @msgTitle, string @msgSummary, string @msgContent, DateTime @publishTime, int @sortOrder, bool @isShow, DateTime @addTime, string @picPath, string @msgType, DateTime @startTime, DateTime @endTime, bool @isTopShow, bool @isSending, string @sendingMan, bool @isWechatSend, string @hTMLContent, DateTime @mobileSendTime, string @mobileSendResult, bool @isUserAPPSend, bool @isCustomerAPPSend, int @categoryID, int @aPPCustomerReadCount, bool @isBusinessAPPSend)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_Msg(@msgTitle, @msgSummary, @msgContent, @publishTime, @sortOrder, @isShow, @addTime, @picPath, @msgType, @startTime, @endTime, @isTopShow, @isSending, @sendingMan, @isWechatSend, @hTMLContent, @mobileSendTime, @mobileSendResult, @isUserAPPSend, @isCustomerAPPSend, @categoryID, @aPPCustomerReadCount, @isBusinessAPPSend, helper);
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
		/// Insert a Wechat_Msg into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="msgTitle">msgTitle</param>
		/// <param name="msgSummary">msgSummary</param>
		/// <param name="msgContent">msgContent</param>
		/// <param name="publishTime">publishTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isShow">isShow</param>
		/// <param name="addTime">addTime</param>
		/// <param name="picPath">picPath</param>
		/// <param name="msgType">msgType</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="isTopShow">isTopShow</param>
		/// <param name="isSending">isSending</param>
		/// <param name="sendingMan">sendingMan</param>
		/// <param name="isWechatSend">isWechatSend</param>
		/// <param name="hTMLContent">hTMLContent</param>
		/// <param name="mobileSendTime">mobileSendTime</param>
		/// <param name="mobileSendResult">mobileSendResult</param>
		/// <param name="isUserAPPSend">isUserAPPSend</param>
		/// <param name="isCustomerAPPSend">isCustomerAPPSend</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="aPPCustomerReadCount">aPPCustomerReadCount</param>
		/// <param name="isBusinessAPPSend">isBusinessAPPSend</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_Msg(string @msgTitle, string @msgSummary, string @msgContent, DateTime @publishTime, int @sortOrder, bool @isShow, DateTime @addTime, string @picPath, string @msgType, DateTime @startTime, DateTime @endTime, bool @isTopShow, bool @isSending, string @sendingMan, bool @isWechatSend, string @hTMLContent, DateTime @mobileSendTime, string @mobileSendResult, bool @isUserAPPSend, bool @isCustomerAPPSend, int @categoryID, int @aPPCustomerReadCount, bool @isBusinessAPPSend, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[MsgTitle] nvarchar(200),
	[MsgSummary] nvarchar(500),
	[MsgContent] ntext,
	[PublishTime] datetime,
	[SortOrder] int,
	[IsShow] bit,
	[AddTime] datetime,
	[PicPath] nvarchar(2000),
	[MsgType] nvarchar(50),
	[StartTime] datetime,
	[EndTime] datetime,
	[IsTopShow] bit,
	[IsSending] bit,
	[SendingMan] nvarchar(100),
	[IsWechatSend] bit,
	[HTMLContent] ntext,
	[MobileSendTime] datetime,
	[MobileSendResult] ntext,
	[IsUserAPPSend] bit,
	[IsCustomerAPPSend] bit,
	[CategoryID] int,
	[APPCustomerReadCount] int,
	[IsBusinessAPPSend] bit
);

INSERT INTO [dbo].[Wechat_Msg] (
	[Wechat_Msg].[MsgTitle],
	[Wechat_Msg].[MsgSummary],
	[Wechat_Msg].[MsgContent],
	[Wechat_Msg].[PublishTime],
	[Wechat_Msg].[SortOrder],
	[Wechat_Msg].[IsShow],
	[Wechat_Msg].[AddTime],
	[Wechat_Msg].[PicPath],
	[Wechat_Msg].[MsgType],
	[Wechat_Msg].[StartTime],
	[Wechat_Msg].[EndTime],
	[Wechat_Msg].[IsTopShow],
	[Wechat_Msg].[IsSending],
	[Wechat_Msg].[SendingMan],
	[Wechat_Msg].[IsWechatSend],
	[Wechat_Msg].[HTMLContent],
	[Wechat_Msg].[MobileSendTime],
	[Wechat_Msg].[MobileSendResult],
	[Wechat_Msg].[IsUserAPPSend],
	[Wechat_Msg].[IsCustomerAPPSend],
	[Wechat_Msg].[CategoryID],
	[Wechat_Msg].[APPCustomerReadCount],
	[Wechat_Msg].[IsBusinessAPPSend]
) 
output 
	INSERTED.[ID],
	INSERTED.[MsgTitle],
	INSERTED.[MsgSummary],
	INSERTED.[MsgContent],
	INSERTED.[PublishTime],
	INSERTED.[SortOrder],
	INSERTED.[IsShow],
	INSERTED.[AddTime],
	INSERTED.[PicPath],
	INSERTED.[MsgType],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[IsTopShow],
	INSERTED.[IsSending],
	INSERTED.[SendingMan],
	INSERTED.[IsWechatSend],
	INSERTED.[HTMLContent],
	INSERTED.[MobileSendTime],
	INSERTED.[MobileSendResult],
	INSERTED.[IsUserAPPSend],
	INSERTED.[IsCustomerAPPSend],
	INSERTED.[CategoryID],
	INSERTED.[APPCustomerReadCount],
	INSERTED.[IsBusinessAPPSend]
into @table
VALUES ( 
	@MsgTitle,
	@MsgSummary,
	@MsgContent,
	@PublishTime,
	@SortOrder,
	@IsShow,
	@AddTime,
	@PicPath,
	@MsgType,
	@StartTime,
	@EndTime,
	@IsTopShow,
	@IsSending,
	@SendingMan,
	@IsWechatSend,
	@HTMLContent,
	@MobileSendTime,
	@MobileSendResult,
	@IsUserAPPSend,
	@IsCustomerAPPSend,
	@CategoryID,
	@APPCustomerReadCount,
	@IsBusinessAPPSend 
); 

SELECT 
	[ID],
	[MsgTitle],
	[MsgSummary],
	[MsgContent],
	[PublishTime],
	[SortOrder],
	[IsShow],
	[AddTime],
	[PicPath],
	[MsgType],
	[StartTime],
	[EndTime],
	[IsTopShow],
	[IsSending],
	[SendingMan],
	[IsWechatSend],
	[HTMLContent],
	[MobileSendTime],
	[MobileSendResult],
	[IsUserAPPSend],
	[IsCustomerAPPSend],
	[CategoryID],
	[APPCustomerReadCount],
	[IsBusinessAPPSend] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@MsgTitle", EntityBase.GetDatabaseValue(@msgTitle)));
			parameters.Add(new SqlParameter("@MsgSummary", EntityBase.GetDatabaseValue(@msgSummary)));
			parameters.Add(new SqlParameter("@MsgContent", EntityBase.GetDatabaseValue(@msgContent)));
			parameters.Add(new SqlParameter("@PublishTime", EntityBase.GetDatabaseValue(@publishTime)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsShow", @isShow));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@PicPath", EntityBase.GetDatabaseValue(@picPath)));
			parameters.Add(new SqlParameter("@MsgType", EntityBase.GetDatabaseValue(@msgType)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@IsTopShow", @isTopShow));
			parameters.Add(new SqlParameter("@IsSending", @isSending));
			parameters.Add(new SqlParameter("@SendingMan", EntityBase.GetDatabaseValue(@sendingMan)));
			parameters.Add(new SqlParameter("@IsWechatSend", @isWechatSend));
			parameters.Add(new SqlParameter("@HTMLContent", EntityBase.GetDatabaseValue(@hTMLContent)));
			parameters.Add(new SqlParameter("@MobileSendTime", EntityBase.GetDatabaseValue(@mobileSendTime)));
			parameters.Add(new SqlParameter("@MobileSendResult", EntityBase.GetDatabaseValue(@mobileSendResult)));
			parameters.Add(new SqlParameter("@IsUserAPPSend", @isUserAPPSend));
			parameters.Add(new SqlParameter("@IsCustomerAPPSend", @isCustomerAPPSend));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			parameters.Add(new SqlParameter("@APPCustomerReadCount", EntityBase.GetDatabaseValue(@aPPCustomerReadCount)));
			parameters.Add(new SqlParameter("@IsBusinessAPPSend", @isBusinessAPPSend));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_Msg into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="msgTitle">msgTitle</param>
		/// <param name="msgSummary">msgSummary</param>
		/// <param name="msgContent">msgContent</param>
		/// <param name="publishTime">publishTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isShow">isShow</param>
		/// <param name="addTime">addTime</param>
		/// <param name="picPath">picPath</param>
		/// <param name="msgType">msgType</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="isTopShow">isTopShow</param>
		/// <param name="isSending">isSending</param>
		/// <param name="sendingMan">sendingMan</param>
		/// <param name="isWechatSend">isWechatSend</param>
		/// <param name="hTMLContent">hTMLContent</param>
		/// <param name="mobileSendTime">mobileSendTime</param>
		/// <param name="mobileSendResult">mobileSendResult</param>
		/// <param name="isUserAPPSend">isUserAPPSend</param>
		/// <param name="isCustomerAPPSend">isCustomerAPPSend</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="aPPCustomerReadCount">aPPCustomerReadCount</param>
		/// <param name="isBusinessAPPSend">isBusinessAPPSend</param>
		public static void UpdateWechat_Msg(int @iD, string @msgTitle, string @msgSummary, string @msgContent, DateTime @publishTime, int @sortOrder, bool @isShow, DateTime @addTime, string @picPath, string @msgType, DateTime @startTime, DateTime @endTime, bool @isTopShow, bool @isSending, string @sendingMan, bool @isWechatSend, string @hTMLContent, DateTime @mobileSendTime, string @mobileSendResult, bool @isUserAPPSend, bool @isCustomerAPPSend, int @categoryID, int @aPPCustomerReadCount, bool @isBusinessAPPSend)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_Msg(@iD, @msgTitle, @msgSummary, @msgContent, @publishTime, @sortOrder, @isShow, @addTime, @picPath, @msgType, @startTime, @endTime, @isTopShow, @isSending, @sendingMan, @isWechatSend, @hTMLContent, @mobileSendTime, @mobileSendResult, @isUserAPPSend, @isCustomerAPPSend, @categoryID, @aPPCustomerReadCount, @isBusinessAPPSend, helper);
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
		/// Updates a Wechat_Msg into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="msgTitle">msgTitle</param>
		/// <param name="msgSummary">msgSummary</param>
		/// <param name="msgContent">msgContent</param>
		/// <param name="publishTime">publishTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isShow">isShow</param>
		/// <param name="addTime">addTime</param>
		/// <param name="picPath">picPath</param>
		/// <param name="msgType">msgType</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="isTopShow">isTopShow</param>
		/// <param name="isSending">isSending</param>
		/// <param name="sendingMan">sendingMan</param>
		/// <param name="isWechatSend">isWechatSend</param>
		/// <param name="hTMLContent">hTMLContent</param>
		/// <param name="mobileSendTime">mobileSendTime</param>
		/// <param name="mobileSendResult">mobileSendResult</param>
		/// <param name="isUserAPPSend">isUserAPPSend</param>
		/// <param name="isCustomerAPPSend">isCustomerAPPSend</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="aPPCustomerReadCount">aPPCustomerReadCount</param>
		/// <param name="isBusinessAPPSend">isBusinessAPPSend</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_Msg(int @iD, string @msgTitle, string @msgSummary, string @msgContent, DateTime @publishTime, int @sortOrder, bool @isShow, DateTime @addTime, string @picPath, string @msgType, DateTime @startTime, DateTime @endTime, bool @isTopShow, bool @isSending, string @sendingMan, bool @isWechatSend, string @hTMLContent, DateTime @mobileSendTime, string @mobileSendResult, bool @isUserAPPSend, bool @isCustomerAPPSend, int @categoryID, int @aPPCustomerReadCount, bool @isBusinessAPPSend, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[MsgTitle] nvarchar(200),
	[MsgSummary] nvarchar(500),
	[MsgContent] ntext,
	[PublishTime] datetime,
	[SortOrder] int,
	[IsShow] bit,
	[AddTime] datetime,
	[PicPath] nvarchar(2000),
	[MsgType] nvarchar(50),
	[StartTime] datetime,
	[EndTime] datetime,
	[IsTopShow] bit,
	[IsSending] bit,
	[SendingMan] nvarchar(100),
	[IsWechatSend] bit,
	[HTMLContent] ntext,
	[MobileSendTime] datetime,
	[MobileSendResult] ntext,
	[IsUserAPPSend] bit,
	[IsCustomerAPPSend] bit,
	[CategoryID] int,
	[APPCustomerReadCount] int,
	[IsBusinessAPPSend] bit
);

UPDATE [dbo].[Wechat_Msg] SET 
	[Wechat_Msg].[MsgTitle] = @MsgTitle,
	[Wechat_Msg].[MsgSummary] = @MsgSummary,
	[Wechat_Msg].[MsgContent] = @MsgContent,
	[Wechat_Msg].[PublishTime] = @PublishTime,
	[Wechat_Msg].[SortOrder] = @SortOrder,
	[Wechat_Msg].[IsShow] = @IsShow,
	[Wechat_Msg].[AddTime] = @AddTime,
	[Wechat_Msg].[PicPath] = @PicPath,
	[Wechat_Msg].[MsgType] = @MsgType,
	[Wechat_Msg].[StartTime] = @StartTime,
	[Wechat_Msg].[EndTime] = @EndTime,
	[Wechat_Msg].[IsTopShow] = @IsTopShow,
	[Wechat_Msg].[IsSending] = @IsSending,
	[Wechat_Msg].[SendingMan] = @SendingMan,
	[Wechat_Msg].[IsWechatSend] = @IsWechatSend,
	[Wechat_Msg].[HTMLContent] = @HTMLContent,
	[Wechat_Msg].[MobileSendTime] = @MobileSendTime,
	[Wechat_Msg].[MobileSendResult] = @MobileSendResult,
	[Wechat_Msg].[IsUserAPPSend] = @IsUserAPPSend,
	[Wechat_Msg].[IsCustomerAPPSend] = @IsCustomerAPPSend,
	[Wechat_Msg].[CategoryID] = @CategoryID,
	[Wechat_Msg].[APPCustomerReadCount] = @APPCustomerReadCount,
	[Wechat_Msg].[IsBusinessAPPSend] = @IsBusinessAPPSend 
output 
	INSERTED.[ID],
	INSERTED.[MsgTitle],
	INSERTED.[MsgSummary],
	INSERTED.[MsgContent],
	INSERTED.[PublishTime],
	INSERTED.[SortOrder],
	INSERTED.[IsShow],
	INSERTED.[AddTime],
	INSERTED.[PicPath],
	INSERTED.[MsgType],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[IsTopShow],
	INSERTED.[IsSending],
	INSERTED.[SendingMan],
	INSERTED.[IsWechatSend],
	INSERTED.[HTMLContent],
	INSERTED.[MobileSendTime],
	INSERTED.[MobileSendResult],
	INSERTED.[IsUserAPPSend],
	INSERTED.[IsCustomerAPPSend],
	INSERTED.[CategoryID],
	INSERTED.[APPCustomerReadCount],
	INSERTED.[IsBusinessAPPSend]
into @table
WHERE 
	[Wechat_Msg].[ID] = @ID

SELECT 
	[ID],
	[MsgTitle],
	[MsgSummary],
	[MsgContent],
	[PublishTime],
	[SortOrder],
	[IsShow],
	[AddTime],
	[PicPath],
	[MsgType],
	[StartTime],
	[EndTime],
	[IsTopShow],
	[IsSending],
	[SendingMan],
	[IsWechatSend],
	[HTMLContent],
	[MobileSendTime],
	[MobileSendResult],
	[IsUserAPPSend],
	[IsCustomerAPPSend],
	[CategoryID],
	[APPCustomerReadCount],
	[IsBusinessAPPSend] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@MsgTitle", EntityBase.GetDatabaseValue(@msgTitle)));
			parameters.Add(new SqlParameter("@MsgSummary", EntityBase.GetDatabaseValue(@msgSummary)));
			parameters.Add(new SqlParameter("@MsgContent", EntityBase.GetDatabaseValue(@msgContent)));
			parameters.Add(new SqlParameter("@PublishTime", EntityBase.GetDatabaseValue(@publishTime)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsShow", @isShow));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@PicPath", EntityBase.GetDatabaseValue(@picPath)));
			parameters.Add(new SqlParameter("@MsgType", EntityBase.GetDatabaseValue(@msgType)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@IsTopShow", @isTopShow));
			parameters.Add(new SqlParameter("@IsSending", @isSending));
			parameters.Add(new SqlParameter("@SendingMan", EntityBase.GetDatabaseValue(@sendingMan)));
			parameters.Add(new SqlParameter("@IsWechatSend", @isWechatSend));
			parameters.Add(new SqlParameter("@HTMLContent", EntityBase.GetDatabaseValue(@hTMLContent)));
			parameters.Add(new SqlParameter("@MobileSendTime", EntityBase.GetDatabaseValue(@mobileSendTime)));
			parameters.Add(new SqlParameter("@MobileSendResult", EntityBase.GetDatabaseValue(@mobileSendResult)));
			parameters.Add(new SqlParameter("@IsUserAPPSend", @isUserAPPSend));
			parameters.Add(new SqlParameter("@IsCustomerAPPSend", @isCustomerAPPSend));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			parameters.Add(new SqlParameter("@APPCustomerReadCount", EntityBase.GetDatabaseValue(@aPPCustomerReadCount)));
			parameters.Add(new SqlParameter("@IsBusinessAPPSend", @isBusinessAPPSend));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_Msg from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_Msg(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_Msg(@iD, helper);
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
		/// Deletes a Wechat_Msg from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_Msg(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_Msg]
WHERE 
	[Wechat_Msg].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_Msg object.
		/// </summary>
		/// <returns>The newly created Wechat_Msg object.</returns>
		public static Wechat_Msg CreateWechat_Msg()
		{
			return InitializeNew<Wechat_Msg>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_Msg by a Wechat_Msg's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_Msg</returns>
		public static Wechat_Msg GetWechat_Msg(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_Msg.SelectFieldList + @"
FROM [dbo].[Wechat_Msg] 
WHERE 
	[Wechat_Msg].[ID] = @ID " + Wechat_Msg.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_Msg>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_Msg by a Wechat_Msg's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_Msg</returns>
		public static Wechat_Msg GetWechat_Msg(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_Msg.SelectFieldList + @"
FROM [dbo].[Wechat_Msg] 
WHERE 
	[Wechat_Msg].[ID] = @ID " + Wechat_Msg.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_Msg>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Msg objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_Msg objects.</returns>
		public static EntityList<Wechat_Msg> GetWechat_Msgs()
		{
			string commandText = @"
SELECT " + Wechat_Msg.SelectFieldList + "FROM [dbo].[Wechat_Msg] " + Wechat_Msg.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_Msg>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_Msg objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_Msg objects.</returns>
        public static EntityList<Wechat_Msg> GetWechat_Msgs(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Msg>(SelectFieldList, "FROM [dbo].[Wechat_Msg]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_Msg objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_Msg objects.</returns>
        public static EntityList<Wechat_Msg> GetWechat_Msgs(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Msg>(SelectFieldList, "FROM [dbo].[Wechat_Msg]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_Msg objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_Msg objects.</returns>
		protected static EntityList<Wechat_Msg> GetWechat_Msgs(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Msgs(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Msg objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Msg objects.</returns>
		protected static EntityList<Wechat_Msg> GetWechat_Msgs(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Msgs(string.Empty, where, parameters, Wechat_Msg.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Msg objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Msg objects.</returns>
		protected static EntityList<Wechat_Msg> GetWechat_Msgs(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Msgs(prefix, where, parameters, Wechat_Msg.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Msg objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Msg objects.</returns>
		protected static EntityList<Wechat_Msg> GetWechat_Msgs(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_Msgs(string.Empty, where, parameters, Wechat_Msg.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Msg objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Msg objects.</returns>
		protected static EntityList<Wechat_Msg> GetWechat_Msgs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_Msgs(prefix, where, parameters, Wechat_Msg.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Msg objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_Msg objects.</returns>
		protected static EntityList<Wechat_Msg> GetWechat_Msgs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_Msg.SelectFieldList + "FROM [dbo].[Wechat_Msg] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_Msg>(reader);
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
        protected static EntityList<Wechat_Msg> GetWechat_Msgs(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Msg>(SelectFieldList, "FROM [dbo].[Wechat_Msg] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_Msg objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_MsgCount()
        {
            return GetWechat_MsgCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_Msg objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_MsgCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_Msg] " + where;

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
		public static partial class Wechat_Msg_Properties
		{
			public const string ID = "ID";
			public const string MsgTitle = "MsgTitle";
			public const string MsgSummary = "MsgSummary";
			public const string MsgContent = "MsgContent";
			public const string PublishTime = "PublishTime";
			public const string SortOrder = "SortOrder";
			public const string IsShow = "IsShow";
			public const string AddTime = "AddTime";
			public const string PicPath = "PicPath";
			public const string MsgType = "MsgType";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string IsTopShow = "IsTopShow";
			public const string IsSending = "IsSending";
			public const string SendingMan = "SendingMan";
			public const string IsWechatSend = "IsWechatSend";
			public const string HTMLContent = "HTMLContent";
			public const string MobileSendTime = "MobileSendTime";
			public const string MobileSendResult = "MobileSendResult";
			public const string IsUserAPPSend = "IsUserAPPSend";
			public const string IsCustomerAPPSend = "IsCustomerAPPSend";
			public const string CategoryID = "CategoryID";
			public const string APPCustomerReadCount = "APPCustomerReadCount";
			public const string IsBusinessAPPSend = "IsBusinessAPPSend";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"MsgTitle" , "string:"},
    			 {"MsgSummary" , "string:"},
    			 {"MsgContent" , "string:"},
    			 {"PublishTime" , "DateTime:"},
    			 {"SortOrder" , "int:"},
    			 {"IsShow" , "bool:"},
    			 {"AddTime" , "DateTime:"},
    			 {"PicPath" , "string:"},
    			 {"MsgType" , "string:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"IsTopShow" , "bool:"},
    			 {"IsSending" , "bool:"},
    			 {"SendingMan" , "string:"},
    			 {"IsWechatSend" , "bool:"},
    			 {"HTMLContent" , "string:"},
    			 {"MobileSendTime" , "DateTime:"},
    			 {"MobileSendResult" , "string:"},
    			 {"IsUserAPPSend" , "bool:"},
    			 {"IsCustomerAPPSend" , "bool:"},
    			 {"CategoryID" , "int:"},
    			 {"APPCustomerReadCount" , "int:"},
    			 {"IsBusinessAPPSend" , "bool:"},
            };
		}
		#endregion
	}
}
