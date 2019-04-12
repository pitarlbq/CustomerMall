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
	/// This object represents the properties and methods of a Mall_CheckRequest.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_CheckRequest 
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
		private string _imagePath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ImagePath
		{
			[DebuggerStepThrough()]
			get { return this._imagePath; }
			set 
			{
				if (this._imagePath != value) 
				{
					this._imagePath = value;
					this.IsDirty = true;	
					OnPropertyChanged("ImagePath");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _approveStatus = int.MinValue;
		/// <summary>
		/// 0-待申请 1-审批通过 2-审批未通过 3-待审批
		/// </summary>
        [Description("0-待申请 1-审批通过 2-审批未通过 3-待审批")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ApproveStatus
		{
			[DebuggerStepThrough()]
			get { return this._approveStatus; }
			set 
			{
				if (this._approveStatus != value) 
				{
					this._approveStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveMan
		{
			[DebuggerStepThrough()]
			get { return this._approveMan; }
			set 
			{
				if (this._approveMan != value) 
				{
					this._approveMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveMan");
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
		private int _confirmStatus = int.MinValue;
		/// <summary>
		/// 0-未申诉 1-无意义 2-有异议
		/// </summary>
        [Description("0-未申诉 1-无意义 2-有异议")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ConfirmStatus
		{
			[DebuggerStepThrough()]
			get { return this._confirmStatus; }
			set 
			{
				if (this._confirmStatus != value) 
				{
					this._confirmStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("ConfirmStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _confirmTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ConfirmTime
		{
			[DebuggerStepThrough()]
			get { return this._confirmTime; }
			set 
			{
				if (this._confirmTime != value) 
				{
					this._confirmTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ConfirmTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _confirmRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ConfirmRemark
		{
			[DebuggerStepThrough()]
			get { return this._confirmRemark; }
			set 
			{
				if (this._confirmRemark != value) 
				{
					this._confirmRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("ConfirmRemark");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _checkApproveID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CheckApproveID
		{
			[DebuggerStepThrough()]
			get { return this._checkApproveID; }
			set 
			{
				if (this._checkApproveID != value) 
				{
					this._checkApproveID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CheckApproveID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _checkConfirmID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CheckConfirmID
		{
			[DebuggerStepThrough()]
			get { return this._checkConfirmID; }
			set 
			{
				if (this._checkConfirmID != value) 
				{
					this._checkConfirmID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CheckConfirmID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _processStatus = int.MinValue;
		/// <summary>
		/// 0-未处理 1-维持原考核 2-作废原考核
		/// </summary>
        [Description("0-未处理 1-维持原考核 2-作废原考核")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProcessStatus
		{
			[DebuggerStepThrough()]
			get { return this._processStatus; }
			set 
			{
				if (this._processStatus != value) 
				{
					this._processStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProcessStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _processTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ProcessTime
		{
			[DebuggerStepThrough()]
			get { return this._processTime; }
			set 
			{
				if (this._processTime != value) 
				{
					this._processTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProcessTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _processRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProcessRemark
		{
			[DebuggerStepThrough()]
			get { return this._processRemark; }
			set 
			{
				if (this._processRemark != value) 
				{
					this._processRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProcessRemark");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _processUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProcessUserName
		{
			[DebuggerStepThrough()]
			get { return this._processUserName; }
			set 
			{
				if (this._processUserName != value) 
				{
					this._processUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProcessUserName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _confirmUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ConfirmUserName
		{
			[DebuggerStepThrough()]
			get { return this._confirmUserName; }
			set 
			{
				if (this._confirmUserName != value) 
				{
					this._confirmUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ConfirmUserName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isJieXiaoPointSent = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsJieXiaoPointSent
		{
			[DebuggerStepThrough()]
			get { return this._isJieXiaoPointSent; }
			set 
			{
				if (this._isJieXiaoPointSent != value) 
				{
					this._isJieXiaoPointSent = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsJieXiaoPointSent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _jieXiaoPointSentTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime JieXiaoPointSentTime
		{
			[DebuggerStepThrough()]
			get { return this._jieXiaoPointSentTime; }
			set 
			{
				if (this._jieXiaoPointSentTime != value) 
				{
					this._jieXiaoPointSentTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("JieXiaoPointSentTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _requestType = int.MinValue;
		/// <summary>
		/// 1-行为考核 2-固定积分
		/// </summary>
        [Description("1-行为考核 2-固定积分")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RequestType
		{
			[DebuggerStepThrough()]
			get { return this._requestType; }
			set 
			{
				if (this._requestType != value) 
				{
					this._requestType = value;
					this.IsDirty = true;	
					OnPropertyChanged("RequestType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _fixedPointUpdateDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime FixedPointUpdateDate
		{
			[DebuggerStepThrough()]
			get { return this._fixedPointUpdateDate; }
			set 
			{
				if (this._fixedPointUpdateDate != value) 
				{
					this._fixedPointUpdateDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("FixedPointUpdateDate");
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
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[Remark] ntext,
	[ImagePath] ntext,
	[ApproveStatus] int,
	[ApproveMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveRemark] ntext,
	[ConfirmStatus] int,
	[ConfirmTime] datetime,
	[ConfirmRemark] ntext,
	[CheckApproveID] int,
	[CheckConfirmID] int,
	[ProcessStatus] int,
	[ProcessTime] datetime,
	[ProcessRemark] ntext,
	[ProcessUserName] nvarchar(200),
	[ConfirmUserName] nvarchar(200),
	[IsJieXiaoPointSent] bit,
	[JieXiaoPointSentTime] datetime,
	[RequestType] int,
	[FixedPointUpdateDate] datetime
);

INSERT INTO [dbo].[Mall_CheckRequest] (
	[Mall_CheckRequest].[Title],
	[Mall_CheckRequest].[AddTime],
	[Mall_CheckRequest].[AddUserName],
	[Mall_CheckRequest].[Remark],
	[Mall_CheckRequest].[ImagePath],
	[Mall_CheckRequest].[ApproveStatus],
	[Mall_CheckRequest].[ApproveMan],
	[Mall_CheckRequest].[ApproveTime],
	[Mall_CheckRequest].[ApproveRemark],
	[Mall_CheckRequest].[ConfirmStatus],
	[Mall_CheckRequest].[ConfirmTime],
	[Mall_CheckRequest].[ConfirmRemark],
	[Mall_CheckRequest].[CheckApproveID],
	[Mall_CheckRequest].[CheckConfirmID],
	[Mall_CheckRequest].[ProcessStatus],
	[Mall_CheckRequest].[ProcessTime],
	[Mall_CheckRequest].[ProcessRemark],
	[Mall_CheckRequest].[ProcessUserName],
	[Mall_CheckRequest].[ConfirmUserName],
	[Mall_CheckRequest].[IsJieXiaoPointSent],
	[Mall_CheckRequest].[JieXiaoPointSentTime],
	[Mall_CheckRequest].[RequestType],
	[Mall_CheckRequest].[FixedPointUpdateDate]
) 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[Remark],
	INSERTED.[ImagePath],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[ConfirmStatus],
	INSERTED.[ConfirmTime],
	INSERTED.[ConfirmRemark],
	INSERTED.[CheckApproveID],
	INSERTED.[CheckConfirmID],
	INSERTED.[ProcessStatus],
	INSERTED.[ProcessTime],
	INSERTED.[ProcessRemark],
	INSERTED.[ProcessUserName],
	INSERTED.[ConfirmUserName],
	INSERTED.[IsJieXiaoPointSent],
	INSERTED.[JieXiaoPointSentTime],
	INSERTED.[RequestType],
	INSERTED.[FixedPointUpdateDate]
into @table
VALUES ( 
	@Title,
	@AddTime,
	@AddUserName,
	@Remark,
	@ImagePath,
	@ApproveStatus,
	@ApproveMan,
	@ApproveTime,
	@ApproveRemark,
	@ConfirmStatus,
	@ConfirmTime,
	@ConfirmRemark,
	@CheckApproveID,
	@CheckConfirmID,
	@ProcessStatus,
	@ProcessTime,
	@ProcessRemark,
	@ProcessUserName,
	@ConfirmUserName,
	@IsJieXiaoPointSent,
	@JieXiaoPointSentTime,
	@RequestType,
	@FixedPointUpdateDate 
); 

SELECT 
	[ID],
	[Title],
	[AddTime],
	[AddUserName],
	[Remark],
	[ImagePath],
	[ApproveStatus],
	[ApproveMan],
	[ApproveTime],
	[ApproveRemark],
	[ConfirmStatus],
	[ConfirmTime],
	[ConfirmRemark],
	[CheckApproveID],
	[CheckConfirmID],
	[ProcessStatus],
	[ProcessTime],
	[ProcessRemark],
	[ProcessUserName],
	[ConfirmUserName],
	[IsJieXiaoPointSent],
	[JieXiaoPointSentTime],
	[RequestType],
	[FixedPointUpdateDate] 
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
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[Remark] ntext,
	[ImagePath] ntext,
	[ApproveStatus] int,
	[ApproveMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveRemark] ntext,
	[ConfirmStatus] int,
	[ConfirmTime] datetime,
	[ConfirmRemark] ntext,
	[CheckApproveID] int,
	[CheckConfirmID] int,
	[ProcessStatus] int,
	[ProcessTime] datetime,
	[ProcessRemark] ntext,
	[ProcessUserName] nvarchar(200),
	[ConfirmUserName] nvarchar(200),
	[IsJieXiaoPointSent] bit,
	[JieXiaoPointSentTime] datetime,
	[RequestType] int,
	[FixedPointUpdateDate] datetime
);

UPDATE [dbo].[Mall_CheckRequest] SET 
	[Mall_CheckRequest].[Title] = @Title,
	[Mall_CheckRequest].[AddTime] = @AddTime,
	[Mall_CheckRequest].[AddUserName] = @AddUserName,
	[Mall_CheckRequest].[Remark] = @Remark,
	[Mall_CheckRequest].[ImagePath] = @ImagePath,
	[Mall_CheckRequest].[ApproveStatus] = @ApproveStatus,
	[Mall_CheckRequest].[ApproveMan] = @ApproveMan,
	[Mall_CheckRequest].[ApproveTime] = @ApproveTime,
	[Mall_CheckRequest].[ApproveRemark] = @ApproveRemark,
	[Mall_CheckRequest].[ConfirmStatus] = @ConfirmStatus,
	[Mall_CheckRequest].[ConfirmTime] = @ConfirmTime,
	[Mall_CheckRequest].[ConfirmRemark] = @ConfirmRemark,
	[Mall_CheckRequest].[CheckApproveID] = @CheckApproveID,
	[Mall_CheckRequest].[CheckConfirmID] = @CheckConfirmID,
	[Mall_CheckRequest].[ProcessStatus] = @ProcessStatus,
	[Mall_CheckRequest].[ProcessTime] = @ProcessTime,
	[Mall_CheckRequest].[ProcessRemark] = @ProcessRemark,
	[Mall_CheckRequest].[ProcessUserName] = @ProcessUserName,
	[Mall_CheckRequest].[ConfirmUserName] = @ConfirmUserName,
	[Mall_CheckRequest].[IsJieXiaoPointSent] = @IsJieXiaoPointSent,
	[Mall_CheckRequest].[JieXiaoPointSentTime] = @JieXiaoPointSentTime,
	[Mall_CheckRequest].[RequestType] = @RequestType,
	[Mall_CheckRequest].[FixedPointUpdateDate] = @FixedPointUpdateDate 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[Remark],
	INSERTED.[ImagePath],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[ConfirmStatus],
	INSERTED.[ConfirmTime],
	INSERTED.[ConfirmRemark],
	INSERTED.[CheckApproveID],
	INSERTED.[CheckConfirmID],
	INSERTED.[ProcessStatus],
	INSERTED.[ProcessTime],
	INSERTED.[ProcessRemark],
	INSERTED.[ProcessUserName],
	INSERTED.[ConfirmUserName],
	INSERTED.[IsJieXiaoPointSent],
	INSERTED.[JieXiaoPointSentTime],
	INSERTED.[RequestType],
	INSERTED.[FixedPointUpdateDate]
into @table
WHERE 
	[Mall_CheckRequest].[ID] = @ID

SELECT 
	[ID],
	[Title],
	[AddTime],
	[AddUserName],
	[Remark],
	[ImagePath],
	[ApproveStatus],
	[ApproveMan],
	[ApproveTime],
	[ApproveRemark],
	[ConfirmStatus],
	[ConfirmTime],
	[ConfirmRemark],
	[CheckApproveID],
	[CheckConfirmID],
	[ProcessStatus],
	[ProcessTime],
	[ProcessRemark],
	[ProcessUserName],
	[ConfirmUserName],
	[IsJieXiaoPointSent],
	[JieXiaoPointSentTime],
	[RequestType],
	[FixedPointUpdateDate] 
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
DELETE FROM [dbo].[Mall_CheckRequest]
WHERE 
	[Mall_CheckRequest].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_CheckRequest() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_CheckRequest(this.ID));
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
	[Mall_CheckRequest].[ID],
	[Mall_CheckRequest].[Title],
	[Mall_CheckRequest].[AddTime],
	[Mall_CheckRequest].[AddUserName],
	[Mall_CheckRequest].[Remark],
	[Mall_CheckRequest].[ImagePath],
	[Mall_CheckRequest].[ApproveStatus],
	[Mall_CheckRequest].[ApproveMan],
	[Mall_CheckRequest].[ApproveTime],
	[Mall_CheckRequest].[ApproveRemark],
	[Mall_CheckRequest].[ConfirmStatus],
	[Mall_CheckRequest].[ConfirmTime],
	[Mall_CheckRequest].[ConfirmRemark],
	[Mall_CheckRequest].[CheckApproveID],
	[Mall_CheckRequest].[CheckConfirmID],
	[Mall_CheckRequest].[ProcessStatus],
	[Mall_CheckRequest].[ProcessTime],
	[Mall_CheckRequest].[ProcessRemark],
	[Mall_CheckRequest].[ProcessUserName],
	[Mall_CheckRequest].[ConfirmUserName],
	[Mall_CheckRequest].[IsJieXiaoPointSent],
	[Mall_CheckRequest].[JieXiaoPointSentTime],
	[Mall_CheckRequest].[RequestType],
	[Mall_CheckRequest].[FixedPointUpdateDate]
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
                return "Mall_CheckRequest";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_CheckRequest into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="title">title</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="remark">remark</param>
		/// <param name="imagePath">imagePath</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="confirmStatus">confirmStatus</param>
		/// <param name="confirmTime">confirmTime</param>
		/// <param name="confirmRemark">confirmRemark</param>
		/// <param name="checkApproveID">checkApproveID</param>
		/// <param name="checkConfirmID">checkConfirmID</param>
		/// <param name="processStatus">processStatus</param>
		/// <param name="processTime">processTime</param>
		/// <param name="processRemark">processRemark</param>
		/// <param name="processUserName">processUserName</param>
		/// <param name="confirmUserName">confirmUserName</param>
		/// <param name="isJieXiaoPointSent">isJieXiaoPointSent</param>
		/// <param name="jieXiaoPointSentTime">jieXiaoPointSentTime</param>
		/// <param name="requestType">requestType</param>
		/// <param name="fixedPointUpdateDate">fixedPointUpdateDate</param>
		public static void InsertMall_CheckRequest(string @title, DateTime @addTime, string @addUserName, string @remark, string @imagePath, int @approveStatus, string @approveMan, DateTime @approveTime, string @approveRemark, int @confirmStatus, DateTime @confirmTime, string @confirmRemark, int @checkApproveID, int @checkConfirmID, int @processStatus, DateTime @processTime, string @processRemark, string @processUserName, string @confirmUserName, bool @isJieXiaoPointSent, DateTime @jieXiaoPointSentTime, int @requestType, DateTime @fixedPointUpdateDate)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_CheckRequest(@title, @addTime, @addUserName, @remark, @imagePath, @approveStatus, @approveMan, @approveTime, @approveRemark, @confirmStatus, @confirmTime, @confirmRemark, @checkApproveID, @checkConfirmID, @processStatus, @processTime, @processRemark, @processUserName, @confirmUserName, @isJieXiaoPointSent, @jieXiaoPointSentTime, @requestType, @fixedPointUpdateDate, helper);
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
		/// Insert a Mall_CheckRequest into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="title">title</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="remark">remark</param>
		/// <param name="imagePath">imagePath</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="confirmStatus">confirmStatus</param>
		/// <param name="confirmTime">confirmTime</param>
		/// <param name="confirmRemark">confirmRemark</param>
		/// <param name="checkApproveID">checkApproveID</param>
		/// <param name="checkConfirmID">checkConfirmID</param>
		/// <param name="processStatus">processStatus</param>
		/// <param name="processTime">processTime</param>
		/// <param name="processRemark">processRemark</param>
		/// <param name="processUserName">processUserName</param>
		/// <param name="confirmUserName">confirmUserName</param>
		/// <param name="isJieXiaoPointSent">isJieXiaoPointSent</param>
		/// <param name="jieXiaoPointSentTime">jieXiaoPointSentTime</param>
		/// <param name="requestType">requestType</param>
		/// <param name="fixedPointUpdateDate">fixedPointUpdateDate</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_CheckRequest(string @title, DateTime @addTime, string @addUserName, string @remark, string @imagePath, int @approveStatus, string @approveMan, DateTime @approveTime, string @approveRemark, int @confirmStatus, DateTime @confirmTime, string @confirmRemark, int @checkApproveID, int @checkConfirmID, int @processStatus, DateTime @processTime, string @processRemark, string @processUserName, string @confirmUserName, bool @isJieXiaoPointSent, DateTime @jieXiaoPointSentTime, int @requestType, DateTime @fixedPointUpdateDate, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Title] nvarchar(200),
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[Remark] ntext,
	[ImagePath] ntext,
	[ApproveStatus] int,
	[ApproveMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveRemark] ntext,
	[ConfirmStatus] int,
	[ConfirmTime] datetime,
	[ConfirmRemark] ntext,
	[CheckApproveID] int,
	[CheckConfirmID] int,
	[ProcessStatus] int,
	[ProcessTime] datetime,
	[ProcessRemark] ntext,
	[ProcessUserName] nvarchar(200),
	[ConfirmUserName] nvarchar(200),
	[IsJieXiaoPointSent] bit,
	[JieXiaoPointSentTime] datetime,
	[RequestType] int,
	[FixedPointUpdateDate] datetime
);

INSERT INTO [dbo].[Mall_CheckRequest] (
	[Mall_CheckRequest].[Title],
	[Mall_CheckRequest].[AddTime],
	[Mall_CheckRequest].[AddUserName],
	[Mall_CheckRequest].[Remark],
	[Mall_CheckRequest].[ImagePath],
	[Mall_CheckRequest].[ApproveStatus],
	[Mall_CheckRequest].[ApproveMan],
	[Mall_CheckRequest].[ApproveTime],
	[Mall_CheckRequest].[ApproveRemark],
	[Mall_CheckRequest].[ConfirmStatus],
	[Mall_CheckRequest].[ConfirmTime],
	[Mall_CheckRequest].[ConfirmRemark],
	[Mall_CheckRequest].[CheckApproveID],
	[Mall_CheckRequest].[CheckConfirmID],
	[Mall_CheckRequest].[ProcessStatus],
	[Mall_CheckRequest].[ProcessTime],
	[Mall_CheckRequest].[ProcessRemark],
	[Mall_CheckRequest].[ProcessUserName],
	[Mall_CheckRequest].[ConfirmUserName],
	[Mall_CheckRequest].[IsJieXiaoPointSent],
	[Mall_CheckRequest].[JieXiaoPointSentTime],
	[Mall_CheckRequest].[RequestType],
	[Mall_CheckRequest].[FixedPointUpdateDate]
) 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[Remark],
	INSERTED.[ImagePath],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[ConfirmStatus],
	INSERTED.[ConfirmTime],
	INSERTED.[ConfirmRemark],
	INSERTED.[CheckApproveID],
	INSERTED.[CheckConfirmID],
	INSERTED.[ProcessStatus],
	INSERTED.[ProcessTime],
	INSERTED.[ProcessRemark],
	INSERTED.[ProcessUserName],
	INSERTED.[ConfirmUserName],
	INSERTED.[IsJieXiaoPointSent],
	INSERTED.[JieXiaoPointSentTime],
	INSERTED.[RequestType],
	INSERTED.[FixedPointUpdateDate]
into @table
VALUES ( 
	@Title,
	@AddTime,
	@AddUserName,
	@Remark,
	@ImagePath,
	@ApproveStatus,
	@ApproveMan,
	@ApproveTime,
	@ApproveRemark,
	@ConfirmStatus,
	@ConfirmTime,
	@ConfirmRemark,
	@CheckApproveID,
	@CheckConfirmID,
	@ProcessStatus,
	@ProcessTime,
	@ProcessRemark,
	@ProcessUserName,
	@ConfirmUserName,
	@IsJieXiaoPointSent,
	@JieXiaoPointSentTime,
	@RequestType,
	@FixedPointUpdateDate 
); 

SELECT 
	[ID],
	[Title],
	[AddTime],
	[AddUserName],
	[Remark],
	[ImagePath],
	[ApproveStatus],
	[ApproveMan],
	[ApproveTime],
	[ApproveRemark],
	[ConfirmStatus],
	[ConfirmTime],
	[ConfirmRemark],
	[CheckApproveID],
	[CheckConfirmID],
	[ProcessStatus],
	[ProcessTime],
	[ProcessRemark],
	[ProcessUserName],
	[ConfirmUserName],
	[IsJieXiaoPointSent],
	[JieXiaoPointSentTime],
	[RequestType],
	[FixedPointUpdateDate] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@ImagePath", EntityBase.GetDatabaseValue(@imagePath)));
			parameters.Add(new SqlParameter("@ApproveStatus", EntityBase.GetDatabaseValue(@approveStatus)));
			parameters.Add(new SqlParameter("@ApproveMan", EntityBase.GetDatabaseValue(@approveMan)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@ConfirmStatus", EntityBase.GetDatabaseValue(@confirmStatus)));
			parameters.Add(new SqlParameter("@ConfirmTime", EntityBase.GetDatabaseValue(@confirmTime)));
			parameters.Add(new SqlParameter("@ConfirmRemark", EntityBase.GetDatabaseValue(@confirmRemark)));
			parameters.Add(new SqlParameter("@CheckApproveID", EntityBase.GetDatabaseValue(@checkApproveID)));
			parameters.Add(new SqlParameter("@CheckConfirmID", EntityBase.GetDatabaseValue(@checkConfirmID)));
			parameters.Add(new SqlParameter("@ProcessStatus", EntityBase.GetDatabaseValue(@processStatus)));
			parameters.Add(new SqlParameter("@ProcessTime", EntityBase.GetDatabaseValue(@processTime)));
			parameters.Add(new SqlParameter("@ProcessRemark", EntityBase.GetDatabaseValue(@processRemark)));
			parameters.Add(new SqlParameter("@ProcessUserName", EntityBase.GetDatabaseValue(@processUserName)));
			parameters.Add(new SqlParameter("@ConfirmUserName", EntityBase.GetDatabaseValue(@confirmUserName)));
			parameters.Add(new SqlParameter("@IsJieXiaoPointSent", @isJieXiaoPointSent));
			parameters.Add(new SqlParameter("@JieXiaoPointSentTime", EntityBase.GetDatabaseValue(@jieXiaoPointSentTime)));
			parameters.Add(new SqlParameter("@RequestType", EntityBase.GetDatabaseValue(@requestType)));
			parameters.Add(new SqlParameter("@FixedPointUpdateDate", EntityBase.GetDatabaseValue(@fixedPointUpdateDate)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_CheckRequest into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="title">title</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="remark">remark</param>
		/// <param name="imagePath">imagePath</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="confirmStatus">confirmStatus</param>
		/// <param name="confirmTime">confirmTime</param>
		/// <param name="confirmRemark">confirmRemark</param>
		/// <param name="checkApproveID">checkApproveID</param>
		/// <param name="checkConfirmID">checkConfirmID</param>
		/// <param name="processStatus">processStatus</param>
		/// <param name="processTime">processTime</param>
		/// <param name="processRemark">processRemark</param>
		/// <param name="processUserName">processUserName</param>
		/// <param name="confirmUserName">confirmUserName</param>
		/// <param name="isJieXiaoPointSent">isJieXiaoPointSent</param>
		/// <param name="jieXiaoPointSentTime">jieXiaoPointSentTime</param>
		/// <param name="requestType">requestType</param>
		/// <param name="fixedPointUpdateDate">fixedPointUpdateDate</param>
		public static void UpdateMall_CheckRequest(int @iD, string @title, DateTime @addTime, string @addUserName, string @remark, string @imagePath, int @approveStatus, string @approveMan, DateTime @approveTime, string @approveRemark, int @confirmStatus, DateTime @confirmTime, string @confirmRemark, int @checkApproveID, int @checkConfirmID, int @processStatus, DateTime @processTime, string @processRemark, string @processUserName, string @confirmUserName, bool @isJieXiaoPointSent, DateTime @jieXiaoPointSentTime, int @requestType, DateTime @fixedPointUpdateDate)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_CheckRequest(@iD, @title, @addTime, @addUserName, @remark, @imagePath, @approveStatus, @approveMan, @approveTime, @approveRemark, @confirmStatus, @confirmTime, @confirmRemark, @checkApproveID, @checkConfirmID, @processStatus, @processTime, @processRemark, @processUserName, @confirmUserName, @isJieXiaoPointSent, @jieXiaoPointSentTime, @requestType, @fixedPointUpdateDate, helper);
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
		/// Updates a Mall_CheckRequest into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="title">title</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="remark">remark</param>
		/// <param name="imagePath">imagePath</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="confirmStatus">confirmStatus</param>
		/// <param name="confirmTime">confirmTime</param>
		/// <param name="confirmRemark">confirmRemark</param>
		/// <param name="checkApproveID">checkApproveID</param>
		/// <param name="checkConfirmID">checkConfirmID</param>
		/// <param name="processStatus">processStatus</param>
		/// <param name="processTime">processTime</param>
		/// <param name="processRemark">processRemark</param>
		/// <param name="processUserName">processUserName</param>
		/// <param name="confirmUserName">confirmUserName</param>
		/// <param name="isJieXiaoPointSent">isJieXiaoPointSent</param>
		/// <param name="jieXiaoPointSentTime">jieXiaoPointSentTime</param>
		/// <param name="requestType">requestType</param>
		/// <param name="fixedPointUpdateDate">fixedPointUpdateDate</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_CheckRequest(int @iD, string @title, DateTime @addTime, string @addUserName, string @remark, string @imagePath, int @approveStatus, string @approveMan, DateTime @approveTime, string @approveRemark, int @confirmStatus, DateTime @confirmTime, string @confirmRemark, int @checkApproveID, int @checkConfirmID, int @processStatus, DateTime @processTime, string @processRemark, string @processUserName, string @confirmUserName, bool @isJieXiaoPointSent, DateTime @jieXiaoPointSentTime, int @requestType, DateTime @fixedPointUpdateDate, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Title] nvarchar(200),
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[Remark] ntext,
	[ImagePath] ntext,
	[ApproveStatus] int,
	[ApproveMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveRemark] ntext,
	[ConfirmStatus] int,
	[ConfirmTime] datetime,
	[ConfirmRemark] ntext,
	[CheckApproveID] int,
	[CheckConfirmID] int,
	[ProcessStatus] int,
	[ProcessTime] datetime,
	[ProcessRemark] ntext,
	[ProcessUserName] nvarchar(200),
	[ConfirmUserName] nvarchar(200),
	[IsJieXiaoPointSent] bit,
	[JieXiaoPointSentTime] datetime,
	[RequestType] int,
	[FixedPointUpdateDate] datetime
);

UPDATE [dbo].[Mall_CheckRequest] SET 
	[Mall_CheckRequest].[Title] = @Title,
	[Mall_CheckRequest].[AddTime] = @AddTime,
	[Mall_CheckRequest].[AddUserName] = @AddUserName,
	[Mall_CheckRequest].[Remark] = @Remark,
	[Mall_CheckRequest].[ImagePath] = @ImagePath,
	[Mall_CheckRequest].[ApproveStatus] = @ApproveStatus,
	[Mall_CheckRequest].[ApproveMan] = @ApproveMan,
	[Mall_CheckRequest].[ApproveTime] = @ApproveTime,
	[Mall_CheckRequest].[ApproveRemark] = @ApproveRemark,
	[Mall_CheckRequest].[ConfirmStatus] = @ConfirmStatus,
	[Mall_CheckRequest].[ConfirmTime] = @ConfirmTime,
	[Mall_CheckRequest].[ConfirmRemark] = @ConfirmRemark,
	[Mall_CheckRequest].[CheckApproveID] = @CheckApproveID,
	[Mall_CheckRequest].[CheckConfirmID] = @CheckConfirmID,
	[Mall_CheckRequest].[ProcessStatus] = @ProcessStatus,
	[Mall_CheckRequest].[ProcessTime] = @ProcessTime,
	[Mall_CheckRequest].[ProcessRemark] = @ProcessRemark,
	[Mall_CheckRequest].[ProcessUserName] = @ProcessUserName,
	[Mall_CheckRequest].[ConfirmUserName] = @ConfirmUserName,
	[Mall_CheckRequest].[IsJieXiaoPointSent] = @IsJieXiaoPointSent,
	[Mall_CheckRequest].[JieXiaoPointSentTime] = @JieXiaoPointSentTime,
	[Mall_CheckRequest].[RequestType] = @RequestType,
	[Mall_CheckRequest].[FixedPointUpdateDate] = @FixedPointUpdateDate 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[Remark],
	INSERTED.[ImagePath],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[ConfirmStatus],
	INSERTED.[ConfirmTime],
	INSERTED.[ConfirmRemark],
	INSERTED.[CheckApproveID],
	INSERTED.[CheckConfirmID],
	INSERTED.[ProcessStatus],
	INSERTED.[ProcessTime],
	INSERTED.[ProcessRemark],
	INSERTED.[ProcessUserName],
	INSERTED.[ConfirmUserName],
	INSERTED.[IsJieXiaoPointSent],
	INSERTED.[JieXiaoPointSentTime],
	INSERTED.[RequestType],
	INSERTED.[FixedPointUpdateDate]
into @table
WHERE 
	[Mall_CheckRequest].[ID] = @ID

SELECT 
	[ID],
	[Title],
	[AddTime],
	[AddUserName],
	[Remark],
	[ImagePath],
	[ApproveStatus],
	[ApproveMan],
	[ApproveTime],
	[ApproveRemark],
	[ConfirmStatus],
	[ConfirmTime],
	[ConfirmRemark],
	[CheckApproveID],
	[CheckConfirmID],
	[ProcessStatus],
	[ProcessTime],
	[ProcessRemark],
	[ProcessUserName],
	[ConfirmUserName],
	[IsJieXiaoPointSent],
	[JieXiaoPointSentTime],
	[RequestType],
	[FixedPointUpdateDate] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@ImagePath", EntityBase.GetDatabaseValue(@imagePath)));
			parameters.Add(new SqlParameter("@ApproveStatus", EntityBase.GetDatabaseValue(@approveStatus)));
			parameters.Add(new SqlParameter("@ApproveMan", EntityBase.GetDatabaseValue(@approveMan)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@ConfirmStatus", EntityBase.GetDatabaseValue(@confirmStatus)));
			parameters.Add(new SqlParameter("@ConfirmTime", EntityBase.GetDatabaseValue(@confirmTime)));
			parameters.Add(new SqlParameter("@ConfirmRemark", EntityBase.GetDatabaseValue(@confirmRemark)));
			parameters.Add(new SqlParameter("@CheckApproveID", EntityBase.GetDatabaseValue(@checkApproveID)));
			parameters.Add(new SqlParameter("@CheckConfirmID", EntityBase.GetDatabaseValue(@checkConfirmID)));
			parameters.Add(new SqlParameter("@ProcessStatus", EntityBase.GetDatabaseValue(@processStatus)));
			parameters.Add(new SqlParameter("@ProcessTime", EntityBase.GetDatabaseValue(@processTime)));
			parameters.Add(new SqlParameter("@ProcessRemark", EntityBase.GetDatabaseValue(@processRemark)));
			parameters.Add(new SqlParameter("@ProcessUserName", EntityBase.GetDatabaseValue(@processUserName)));
			parameters.Add(new SqlParameter("@ConfirmUserName", EntityBase.GetDatabaseValue(@confirmUserName)));
			parameters.Add(new SqlParameter("@IsJieXiaoPointSent", @isJieXiaoPointSent));
			parameters.Add(new SqlParameter("@JieXiaoPointSentTime", EntityBase.GetDatabaseValue(@jieXiaoPointSentTime)));
			parameters.Add(new SqlParameter("@RequestType", EntityBase.GetDatabaseValue(@requestType)));
			parameters.Add(new SqlParameter("@FixedPointUpdateDate", EntityBase.GetDatabaseValue(@fixedPointUpdateDate)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_CheckRequest from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_CheckRequest(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_CheckRequest(@iD, helper);
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
		/// Deletes a Mall_CheckRequest from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_CheckRequest(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_CheckRequest]
WHERE 
	[Mall_CheckRequest].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_CheckRequest object.
		/// </summary>
		/// <returns>The newly created Mall_CheckRequest object.</returns>
		public static Mall_CheckRequest CreateMall_CheckRequest()
		{
			return InitializeNew<Mall_CheckRequest>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_CheckRequest by a Mall_CheckRequest's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_CheckRequest</returns>
		public static Mall_CheckRequest GetMall_CheckRequest(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_CheckRequest.SelectFieldList + @"
FROM [dbo].[Mall_CheckRequest] 
WHERE 
	[Mall_CheckRequest].[ID] = @ID " + Mall_CheckRequest.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_CheckRequest>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_CheckRequest by a Mall_CheckRequest's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_CheckRequest</returns>
		public static Mall_CheckRequest GetMall_CheckRequest(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_CheckRequest.SelectFieldList + @"
FROM [dbo].[Mall_CheckRequest] 
WHERE 
	[Mall_CheckRequest].[ID] = @ID " + Mall_CheckRequest.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_CheckRequest>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequest objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_CheckRequest objects.</returns>
		public static EntityList<Mall_CheckRequest> GetMall_CheckRequests()
		{
			string commandText = @"
SELECT " + Mall_CheckRequest.SelectFieldList + "FROM [dbo].[Mall_CheckRequest] " + Mall_CheckRequest.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_CheckRequest>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_CheckRequest objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_CheckRequest objects.</returns>
        public static EntityList<Mall_CheckRequest> GetMall_CheckRequests(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckRequest>(SelectFieldList, "FROM [dbo].[Mall_CheckRequest]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_CheckRequest objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_CheckRequest objects.</returns>
        public static EntityList<Mall_CheckRequest> GetMall_CheckRequests(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckRequest>(SelectFieldList, "FROM [dbo].[Mall_CheckRequest]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_CheckRequest objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_CheckRequest objects.</returns>
		protected static EntityList<Mall_CheckRequest> GetMall_CheckRequests(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckRequests(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequest objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequest objects.</returns>
		protected static EntityList<Mall_CheckRequest> GetMall_CheckRequests(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckRequests(string.Empty, where, parameters, Mall_CheckRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequest objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequest objects.</returns>
		protected static EntityList<Mall_CheckRequest> GetMall_CheckRequests(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckRequests(prefix, where, parameters, Mall_CheckRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequest objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequest objects.</returns>
		protected static EntityList<Mall_CheckRequest> GetMall_CheckRequests(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_CheckRequests(string.Empty, where, parameters, Mall_CheckRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequest objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequest objects.</returns>
		protected static EntityList<Mall_CheckRequest> GetMall_CheckRequests(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_CheckRequests(prefix, where, parameters, Mall_CheckRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequest objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_CheckRequest objects.</returns>
		protected static EntityList<Mall_CheckRequest> GetMall_CheckRequests(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_CheckRequest.SelectFieldList + "FROM [dbo].[Mall_CheckRequest] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_CheckRequest>(reader);
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
        protected static EntityList<Mall_CheckRequest> GetMall_CheckRequests(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckRequest>(SelectFieldList, "FROM [dbo].[Mall_CheckRequest] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_CheckRequest objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CheckRequestCount()
        {
            return GetMall_CheckRequestCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_CheckRequest objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CheckRequestCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_CheckRequest] " + where;

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
		public static partial class Mall_CheckRequest_Properties
		{
			public const string ID = "ID";
			public const string Title = "Title";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string Remark = "Remark";
			public const string ImagePath = "ImagePath";
			public const string ApproveStatus = "ApproveStatus";
			public const string ApproveMan = "ApproveMan";
			public const string ApproveTime = "ApproveTime";
			public const string ApproveRemark = "ApproveRemark";
			public const string ConfirmStatus = "ConfirmStatus";
			public const string ConfirmTime = "ConfirmTime";
			public const string ConfirmRemark = "ConfirmRemark";
			public const string CheckApproveID = "CheckApproveID";
			public const string CheckConfirmID = "CheckConfirmID";
			public const string ProcessStatus = "ProcessStatus";
			public const string ProcessTime = "ProcessTime";
			public const string ProcessRemark = "ProcessRemark";
			public const string ProcessUserName = "ProcessUserName";
			public const string ConfirmUserName = "ConfirmUserName";
			public const string IsJieXiaoPointSent = "IsJieXiaoPointSent";
			public const string JieXiaoPointSentTime = "JieXiaoPointSentTime";
			public const string RequestType = "RequestType";
			public const string FixedPointUpdateDate = "FixedPointUpdateDate";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Title" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"Remark" , "string:"},
    			 {"ImagePath" , "string:"},
    			 {"ApproveStatus" , "int:0-待申请 1-审批通过 2-审批未通过 3-待审批"},
    			 {"ApproveMan" , "string:"},
    			 {"ApproveTime" , "DateTime:"},
    			 {"ApproveRemark" , "string:"},
    			 {"ConfirmStatus" , "int:0-未申诉 1-无意义 2-有异议"},
    			 {"ConfirmTime" , "DateTime:"},
    			 {"ConfirmRemark" , "string:"},
    			 {"CheckApproveID" , "int:"},
    			 {"CheckConfirmID" , "int:"},
    			 {"ProcessStatus" , "int:0-未处理 1-维持原考核 2-作废原考核"},
    			 {"ProcessTime" , "DateTime:"},
    			 {"ProcessRemark" , "string:"},
    			 {"ProcessUserName" , "string:"},
    			 {"ConfirmUserName" , "string:"},
    			 {"IsJieXiaoPointSent" , "bool:"},
    			 {"JieXiaoPointSentTime" , "DateTime:"},
    			 {"RequestType" , "int:1-行为考核 2-固定积分"},
    			 {"FixedPointUpdateDate" , "DateTime:"},
            };
		}
		#endregion
	}
}
