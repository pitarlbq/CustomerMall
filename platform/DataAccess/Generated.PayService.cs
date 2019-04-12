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
	/// This object represents the properties and methods of a PayService.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class PayService 
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
		private int _projectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ProjectID
		{
			[DebuggerStepThrough()]
			get { return this._projectID; }
			set 
			{
				if (this._projectID != value) 
				{
					this._projectID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _projectName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProjectName
		{
			[DebuggerStepThrough()]
			get { return this._projectName; }
			set 
			{
				if (this._projectName != value) 
				{
					this._projectName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _paySummaryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int PaySummaryID
		{
			[DebuggerStepThrough()]
			get { return this._paySummaryID; }
			set 
			{
				if (this._paySummaryID != value) 
				{
					this._paySummaryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("PaySummaryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _payMoney = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal PayMoney
		{
			[DebuggerStepThrough()]
			get { return this._payMoney; }
			set 
			{
				if (this._payMoney != value) 
				{
					this._payMoney = value;
					this.IsDirty = true;	
					OnPropertyChanged("PayMoney");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _payTypeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PayTypeID
		{
			[DebuggerStepThrough()]
			get { return this._payTypeID; }
			set 
			{
				if (this._payTypeID != value) 
				{
					this._payTypeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("PayTypeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _payType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PayType
		{
			[DebuggerStepThrough()]
			get { return this._payType; }
			set 
			{
				if (this._payType != value) 
				{
					this._payType = value;
					this.IsDirty = true;	
					OnPropertyChanged("PayType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _accountType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AccountType
		{
			[DebuggerStepThrough()]
			get { return this._accountType; }
			set 
			{
				if (this._accountType != value) 
				{
					this._accountType = value;
					this.IsDirty = true;	
					OnPropertyChanged("AccountType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _payTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime PayTime
		{
			[DebuggerStepThrough()]
			get { return this._payTime; }
			set 
			{
				if (this._payTime != value) 
				{
					this._payTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("PayTime");
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
		private int _addManID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int AddManID
		{
			[DebuggerStepThrough()]
			get { return this._addManID; }
			set 
			{
				if (this._addManID != value) 
				{
					this._addManID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddManID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomName
		{
			[DebuggerStepThrough()]
			get { return this._roomName; }
			set 
			{
				if (this._roomName != value) 
				{
					this._roomName = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _modifyTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ModifyTime
		{
			[DebuggerStepThrough()]
			get { return this._modifyTime; }
			set 
			{
				if (this._modifyTime != value) 
				{
					this._modifyTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModifyTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _modifyMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ModifyMan
		{
			[DebuggerStepThrough()]
			get { return this._modifyMan; }
			set 
			{
				if (this._modifyMan != value) 
				{
					this._modifyMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModifyMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _modifyManID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ModifyManID
		{
			[DebuggerStepThrough()]
			get { return this._modifyManID; }
			set 
			{
				if (this._modifyManID != value) 
				{
					this._modifyManID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModifyManID");
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
		private int _printID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PrintID
		{
			[DebuggerStepThrough()]
			get { return this._printID; }
			set 
			{
				if (this._printID != value) 
				{
					this._printID = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _status = int.MinValue;
		/// <summary>
		/// 1-待申请 2-待审核 3-审核通过 4-审核未通过
		/// </summary>
        [Description("1-待申请 2-待审核 3-审核通过 4-审核未通过")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
	[ProjectID] int,
	[ProjectName] nvarchar(200),
	[PaySummaryID] int,
	[PayMoney] decimal(18, 2),
	[PayTypeID] int,
	[PayType] nvarchar(50),
	[AccountType] nvarchar(50),
	[PayTime] datetime,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[AddManID] int,
	[RoomName] nvarchar(100),
	[ModifyTime] datetime,
	[ModifyMan] nvarchar(50),
	[ModifyManID] int,
	[Remark] ntext,
	[PrintID] int,
	[Status] int
);

INSERT INTO [dbo].[PayService] (
	[PayService].[ProjectID],
	[PayService].[ProjectName],
	[PayService].[PaySummaryID],
	[PayService].[PayMoney],
	[PayService].[PayTypeID],
	[PayService].[PayType],
	[PayService].[AccountType],
	[PayService].[PayTime],
	[PayService].[AddTime],
	[PayService].[AddMan],
	[PayService].[AddManID],
	[PayService].[RoomName],
	[PayService].[ModifyTime],
	[PayService].[ModifyMan],
	[PayService].[ModifyManID],
	[PayService].[Remark],
	[PayService].[PrintID],
	[PayService].[Status]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[ProjectName],
	INSERTED.[PaySummaryID],
	INSERTED.[PayMoney],
	INSERTED.[PayTypeID],
	INSERTED.[PayType],
	INSERTED.[AccountType],
	INSERTED.[PayTime],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[AddManID],
	INSERTED.[RoomName],
	INSERTED.[ModifyTime],
	INSERTED.[ModifyMan],
	INSERTED.[ModifyManID],
	INSERTED.[Remark],
	INSERTED.[PrintID],
	INSERTED.[Status]
into @table
VALUES ( 
	@ProjectID,
	@ProjectName,
	@PaySummaryID,
	@PayMoney,
	@PayTypeID,
	@PayType,
	@AccountType,
	@PayTime,
	@AddTime,
	@AddMan,
	@AddManID,
	@RoomName,
	@ModifyTime,
	@ModifyMan,
	@ModifyManID,
	@Remark,
	@PrintID,
	@Status 
); 

SELECT 
	[ID],
	[ProjectID],
	[ProjectName],
	[PaySummaryID],
	[PayMoney],
	[PayTypeID],
	[PayType],
	[AccountType],
	[PayTime],
	[AddTime],
	[AddMan],
	[AddManID],
	[RoomName],
	[ModifyTime],
	[ModifyMan],
	[ModifyManID],
	[Remark],
	[PrintID],
	[Status] 
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
	[ProjectID] int,
	[ProjectName] nvarchar(200),
	[PaySummaryID] int,
	[PayMoney] decimal(18, 2),
	[PayTypeID] int,
	[PayType] nvarchar(50),
	[AccountType] nvarchar(50),
	[PayTime] datetime,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[AddManID] int,
	[RoomName] nvarchar(100),
	[ModifyTime] datetime,
	[ModifyMan] nvarchar(50),
	[ModifyManID] int,
	[Remark] ntext,
	[PrintID] int,
	[Status] int
);

UPDATE [dbo].[PayService] SET 
	[PayService].[ProjectID] = @ProjectID,
	[PayService].[ProjectName] = @ProjectName,
	[PayService].[PaySummaryID] = @PaySummaryID,
	[PayService].[PayMoney] = @PayMoney,
	[PayService].[PayTypeID] = @PayTypeID,
	[PayService].[PayType] = @PayType,
	[PayService].[AccountType] = @AccountType,
	[PayService].[PayTime] = @PayTime,
	[PayService].[AddTime] = @AddTime,
	[PayService].[AddMan] = @AddMan,
	[PayService].[AddManID] = @AddManID,
	[PayService].[RoomName] = @RoomName,
	[PayService].[ModifyTime] = @ModifyTime,
	[PayService].[ModifyMan] = @ModifyMan,
	[PayService].[ModifyManID] = @ModifyManID,
	[PayService].[Remark] = @Remark,
	[PayService].[PrintID] = @PrintID,
	[PayService].[Status] = @Status 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[ProjectName],
	INSERTED.[PaySummaryID],
	INSERTED.[PayMoney],
	INSERTED.[PayTypeID],
	INSERTED.[PayType],
	INSERTED.[AccountType],
	INSERTED.[PayTime],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[AddManID],
	INSERTED.[RoomName],
	INSERTED.[ModifyTime],
	INSERTED.[ModifyMan],
	INSERTED.[ModifyManID],
	INSERTED.[Remark],
	INSERTED.[PrintID],
	INSERTED.[Status]
into @table
WHERE 
	[PayService].[ID] = @ID

SELECT 
	[ID],
	[ProjectID],
	[ProjectName],
	[PaySummaryID],
	[PayMoney],
	[PayTypeID],
	[PayType],
	[AccountType],
	[PayTime],
	[AddTime],
	[AddMan],
	[AddManID],
	[RoomName],
	[ModifyTime],
	[ModifyMan],
	[ModifyManID],
	[Remark],
	[PrintID],
	[Status] 
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
DELETE FROM [dbo].[PayService]
WHERE 
	[PayService].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public PayService() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetPayService(this.ID));
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
	[PayService].[ID],
	[PayService].[ProjectID],
	[PayService].[ProjectName],
	[PayService].[PaySummaryID],
	[PayService].[PayMoney],
	[PayService].[PayTypeID],
	[PayService].[PayType],
	[PayService].[AccountType],
	[PayService].[PayTime],
	[PayService].[AddTime],
	[PayService].[AddMan],
	[PayService].[AddManID],
	[PayService].[RoomName],
	[PayService].[ModifyTime],
	[PayService].[ModifyMan],
	[PayService].[ModifyManID],
	[PayService].[Remark],
	[PayService].[PrintID],
	[PayService].[Status]
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
                return "PayService";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a PayService into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="projectName">projectName</param>
		/// <param name="paySummaryID">paySummaryID</param>
		/// <param name="payMoney">payMoney</param>
		/// <param name="payTypeID">payTypeID</param>
		/// <param name="payType">payType</param>
		/// <param name="accountType">accountType</param>
		/// <param name="payTime">payTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addManID">addManID</param>
		/// <param name="roomName">roomName</param>
		/// <param name="modifyTime">modifyTime</param>
		/// <param name="modifyMan">modifyMan</param>
		/// <param name="modifyManID">modifyManID</param>
		/// <param name="remark">remark</param>
		/// <param name="printID">printID</param>
		/// <param name="status">status</param>
		public static void InsertPayService(int @projectID, string @projectName, int @paySummaryID, decimal @payMoney, int @payTypeID, string @payType, string @accountType, DateTime @payTime, DateTime @addTime, string @addMan, int @addManID, string @roomName, DateTime @modifyTime, string @modifyMan, int @modifyManID, string @remark, int @printID, int @status)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertPayService(@projectID, @projectName, @paySummaryID, @payMoney, @payTypeID, @payType, @accountType, @payTime, @addTime, @addMan, @addManID, @roomName, @modifyTime, @modifyMan, @modifyManID, @remark, @printID, @status, helper);
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
		/// Insert a PayService into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="projectName">projectName</param>
		/// <param name="paySummaryID">paySummaryID</param>
		/// <param name="payMoney">payMoney</param>
		/// <param name="payTypeID">payTypeID</param>
		/// <param name="payType">payType</param>
		/// <param name="accountType">accountType</param>
		/// <param name="payTime">payTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addManID">addManID</param>
		/// <param name="roomName">roomName</param>
		/// <param name="modifyTime">modifyTime</param>
		/// <param name="modifyMan">modifyMan</param>
		/// <param name="modifyManID">modifyManID</param>
		/// <param name="remark">remark</param>
		/// <param name="printID">printID</param>
		/// <param name="status">status</param>
		/// <param name="helper">helper</param>
		internal static void InsertPayService(int @projectID, string @projectName, int @paySummaryID, decimal @payMoney, int @payTypeID, string @payType, string @accountType, DateTime @payTime, DateTime @addTime, string @addMan, int @addManID, string @roomName, DateTime @modifyTime, string @modifyMan, int @modifyManID, string @remark, int @printID, int @status, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectID] int,
	[ProjectName] nvarchar(200),
	[PaySummaryID] int,
	[PayMoney] decimal(18, 2),
	[PayTypeID] int,
	[PayType] nvarchar(50),
	[AccountType] nvarchar(50),
	[PayTime] datetime,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[AddManID] int,
	[RoomName] nvarchar(100),
	[ModifyTime] datetime,
	[ModifyMan] nvarchar(50),
	[ModifyManID] int,
	[Remark] ntext,
	[PrintID] int,
	[Status] int
);

INSERT INTO [dbo].[PayService] (
	[PayService].[ProjectID],
	[PayService].[ProjectName],
	[PayService].[PaySummaryID],
	[PayService].[PayMoney],
	[PayService].[PayTypeID],
	[PayService].[PayType],
	[PayService].[AccountType],
	[PayService].[PayTime],
	[PayService].[AddTime],
	[PayService].[AddMan],
	[PayService].[AddManID],
	[PayService].[RoomName],
	[PayService].[ModifyTime],
	[PayService].[ModifyMan],
	[PayService].[ModifyManID],
	[PayService].[Remark],
	[PayService].[PrintID],
	[PayService].[Status]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[ProjectName],
	INSERTED.[PaySummaryID],
	INSERTED.[PayMoney],
	INSERTED.[PayTypeID],
	INSERTED.[PayType],
	INSERTED.[AccountType],
	INSERTED.[PayTime],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[AddManID],
	INSERTED.[RoomName],
	INSERTED.[ModifyTime],
	INSERTED.[ModifyMan],
	INSERTED.[ModifyManID],
	INSERTED.[Remark],
	INSERTED.[PrintID],
	INSERTED.[Status]
into @table
VALUES ( 
	@ProjectID,
	@ProjectName,
	@PaySummaryID,
	@PayMoney,
	@PayTypeID,
	@PayType,
	@AccountType,
	@PayTime,
	@AddTime,
	@AddMan,
	@AddManID,
	@RoomName,
	@ModifyTime,
	@ModifyMan,
	@ModifyManID,
	@Remark,
	@PrintID,
	@Status 
); 

SELECT 
	[ID],
	[ProjectID],
	[ProjectName],
	[PaySummaryID],
	[PayMoney],
	[PayTypeID],
	[PayType],
	[AccountType],
	[PayTime],
	[AddTime],
	[AddMan],
	[AddManID],
	[RoomName],
	[ModifyTime],
	[ModifyMan],
	[ModifyManID],
	[Remark],
	[PrintID],
	[Status] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@ProjectName", EntityBase.GetDatabaseValue(@projectName)));
			parameters.Add(new SqlParameter("@PaySummaryID", EntityBase.GetDatabaseValue(@paySummaryID)));
			parameters.Add(new SqlParameter("@PayMoney", EntityBase.GetDatabaseValue(@payMoney)));
			parameters.Add(new SqlParameter("@PayTypeID", EntityBase.GetDatabaseValue(@payTypeID)));
			parameters.Add(new SqlParameter("@PayType", EntityBase.GetDatabaseValue(@payType)));
			parameters.Add(new SqlParameter("@AccountType", EntityBase.GetDatabaseValue(@accountType)));
			parameters.Add(new SqlParameter("@PayTime", EntityBase.GetDatabaseValue(@payTime)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AddManID", EntityBase.GetDatabaseValue(@addManID)));
			parameters.Add(new SqlParameter("@RoomName", EntityBase.GetDatabaseValue(@roomName)));
			parameters.Add(new SqlParameter("@ModifyTime", EntityBase.GetDatabaseValue(@modifyTime)));
			parameters.Add(new SqlParameter("@ModifyMan", EntityBase.GetDatabaseValue(@modifyMan)));
			parameters.Add(new SqlParameter("@ModifyManID", EntityBase.GetDatabaseValue(@modifyManID)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@PrintID", EntityBase.GetDatabaseValue(@printID)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a PayService into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectID">projectID</param>
		/// <param name="projectName">projectName</param>
		/// <param name="paySummaryID">paySummaryID</param>
		/// <param name="payMoney">payMoney</param>
		/// <param name="payTypeID">payTypeID</param>
		/// <param name="payType">payType</param>
		/// <param name="accountType">accountType</param>
		/// <param name="payTime">payTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addManID">addManID</param>
		/// <param name="roomName">roomName</param>
		/// <param name="modifyTime">modifyTime</param>
		/// <param name="modifyMan">modifyMan</param>
		/// <param name="modifyManID">modifyManID</param>
		/// <param name="remark">remark</param>
		/// <param name="printID">printID</param>
		/// <param name="status">status</param>
		public static void UpdatePayService(int @iD, int @projectID, string @projectName, int @paySummaryID, decimal @payMoney, int @payTypeID, string @payType, string @accountType, DateTime @payTime, DateTime @addTime, string @addMan, int @addManID, string @roomName, DateTime @modifyTime, string @modifyMan, int @modifyManID, string @remark, int @printID, int @status)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdatePayService(@iD, @projectID, @projectName, @paySummaryID, @payMoney, @payTypeID, @payType, @accountType, @payTime, @addTime, @addMan, @addManID, @roomName, @modifyTime, @modifyMan, @modifyManID, @remark, @printID, @status, helper);
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
		/// Updates a PayService into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectID">projectID</param>
		/// <param name="projectName">projectName</param>
		/// <param name="paySummaryID">paySummaryID</param>
		/// <param name="payMoney">payMoney</param>
		/// <param name="payTypeID">payTypeID</param>
		/// <param name="payType">payType</param>
		/// <param name="accountType">accountType</param>
		/// <param name="payTime">payTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addManID">addManID</param>
		/// <param name="roomName">roomName</param>
		/// <param name="modifyTime">modifyTime</param>
		/// <param name="modifyMan">modifyMan</param>
		/// <param name="modifyManID">modifyManID</param>
		/// <param name="remark">remark</param>
		/// <param name="printID">printID</param>
		/// <param name="status">status</param>
		/// <param name="helper">helper</param>
		internal static void UpdatePayService(int @iD, int @projectID, string @projectName, int @paySummaryID, decimal @payMoney, int @payTypeID, string @payType, string @accountType, DateTime @payTime, DateTime @addTime, string @addMan, int @addManID, string @roomName, DateTime @modifyTime, string @modifyMan, int @modifyManID, string @remark, int @printID, int @status, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectID] int,
	[ProjectName] nvarchar(200),
	[PaySummaryID] int,
	[PayMoney] decimal(18, 2),
	[PayTypeID] int,
	[PayType] nvarchar(50),
	[AccountType] nvarchar(50),
	[PayTime] datetime,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[AddManID] int,
	[RoomName] nvarchar(100),
	[ModifyTime] datetime,
	[ModifyMan] nvarchar(50),
	[ModifyManID] int,
	[Remark] ntext,
	[PrintID] int,
	[Status] int
);

UPDATE [dbo].[PayService] SET 
	[PayService].[ProjectID] = @ProjectID,
	[PayService].[ProjectName] = @ProjectName,
	[PayService].[PaySummaryID] = @PaySummaryID,
	[PayService].[PayMoney] = @PayMoney,
	[PayService].[PayTypeID] = @PayTypeID,
	[PayService].[PayType] = @PayType,
	[PayService].[AccountType] = @AccountType,
	[PayService].[PayTime] = @PayTime,
	[PayService].[AddTime] = @AddTime,
	[PayService].[AddMan] = @AddMan,
	[PayService].[AddManID] = @AddManID,
	[PayService].[RoomName] = @RoomName,
	[PayService].[ModifyTime] = @ModifyTime,
	[PayService].[ModifyMan] = @ModifyMan,
	[PayService].[ModifyManID] = @ModifyManID,
	[PayService].[Remark] = @Remark,
	[PayService].[PrintID] = @PrintID,
	[PayService].[Status] = @Status 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[ProjectName],
	INSERTED.[PaySummaryID],
	INSERTED.[PayMoney],
	INSERTED.[PayTypeID],
	INSERTED.[PayType],
	INSERTED.[AccountType],
	INSERTED.[PayTime],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[AddManID],
	INSERTED.[RoomName],
	INSERTED.[ModifyTime],
	INSERTED.[ModifyMan],
	INSERTED.[ModifyManID],
	INSERTED.[Remark],
	INSERTED.[PrintID],
	INSERTED.[Status]
into @table
WHERE 
	[PayService].[ID] = @ID

SELECT 
	[ID],
	[ProjectID],
	[ProjectName],
	[PaySummaryID],
	[PayMoney],
	[PayTypeID],
	[PayType],
	[AccountType],
	[PayTime],
	[AddTime],
	[AddMan],
	[AddManID],
	[RoomName],
	[ModifyTime],
	[ModifyMan],
	[ModifyManID],
	[Remark],
	[PrintID],
	[Status] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@ProjectName", EntityBase.GetDatabaseValue(@projectName)));
			parameters.Add(new SqlParameter("@PaySummaryID", EntityBase.GetDatabaseValue(@paySummaryID)));
			parameters.Add(new SqlParameter("@PayMoney", EntityBase.GetDatabaseValue(@payMoney)));
			parameters.Add(new SqlParameter("@PayTypeID", EntityBase.GetDatabaseValue(@payTypeID)));
			parameters.Add(new SqlParameter("@PayType", EntityBase.GetDatabaseValue(@payType)));
			parameters.Add(new SqlParameter("@AccountType", EntityBase.GetDatabaseValue(@accountType)));
			parameters.Add(new SqlParameter("@PayTime", EntityBase.GetDatabaseValue(@payTime)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AddManID", EntityBase.GetDatabaseValue(@addManID)));
			parameters.Add(new SqlParameter("@RoomName", EntityBase.GetDatabaseValue(@roomName)));
			parameters.Add(new SqlParameter("@ModifyTime", EntityBase.GetDatabaseValue(@modifyTime)));
			parameters.Add(new SqlParameter("@ModifyMan", EntityBase.GetDatabaseValue(@modifyMan)));
			parameters.Add(new SqlParameter("@ModifyManID", EntityBase.GetDatabaseValue(@modifyManID)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@PrintID", EntityBase.GetDatabaseValue(@printID)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a PayService from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeletePayService(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeletePayService(@iD, helper);
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
		/// Deletes a PayService from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeletePayService(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[PayService]
WHERE 
	[PayService].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new PayService object.
		/// </summary>
		/// <returns>The newly created PayService object.</returns>
		public static PayService CreatePayService()
		{
			return InitializeNew<PayService>();
		}
		
		/// <summary>
		/// Retrieve information for a PayService by a PayService's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>PayService</returns>
		public static PayService GetPayService(int @iD)
		{
			string commandText = @"
SELECT 
" + PayService.SelectFieldList + @"
FROM [dbo].[PayService] 
WHERE 
	[PayService].[ID] = @ID " + PayService.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<PayService>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a PayService by a PayService's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>PayService</returns>
		public static PayService GetPayService(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + PayService.SelectFieldList + @"
FROM [dbo].[PayService] 
WHERE 
	[PayService].[ID] = @ID " + PayService.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<PayService>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection PayService objects.
		/// </summary>
		/// <returns>The retrieved collection of PayService objects.</returns>
		public static EntityList<PayService> GetPayServices()
		{
			string commandText = @"
SELECT " + PayService.SelectFieldList + "FROM [dbo].[PayService] " + PayService.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<PayService>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection PayService objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of PayService objects.</returns>
        public static EntityList<PayService> GetPayServices(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PayService>(SelectFieldList, "FROM [dbo].[PayService]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection PayService objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of PayService objects.</returns>
        public static EntityList<PayService> GetPayServices(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PayService>(SelectFieldList, "FROM [dbo].[PayService]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection PayService objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of PayService objects.</returns>
		protected static EntityList<PayService> GetPayServices(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPayServices(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection PayService objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of PayService objects.</returns>
		protected static EntityList<PayService> GetPayServices(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPayServices(string.Empty, where, parameters, PayService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PayService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of PayService objects.</returns>
		protected static EntityList<PayService> GetPayServices(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPayServices(prefix, where, parameters, PayService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PayService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of PayService objects.</returns>
		protected static EntityList<PayService> GetPayServices(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetPayServices(string.Empty, where, parameters, PayService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PayService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of PayService objects.</returns>
		protected static EntityList<PayService> GetPayServices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetPayServices(prefix, where, parameters, PayService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PayService objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of PayService objects.</returns>
		protected static EntityList<PayService> GetPayServices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + PayService.SelectFieldList + "FROM [dbo].[PayService] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<PayService>(reader);
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
        protected static EntityList<PayService> GetPayServices(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PayService>(SelectFieldList, "FROM [dbo].[PayService] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of PayService objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetPayServiceCount()
        {
            return GetPayServiceCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of PayService objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetPayServiceCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[PayService] " + where;

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
		public static partial class PayService_Properties
		{
			public const string ID = "ID";
			public const string ProjectID = "ProjectID";
			public const string ProjectName = "ProjectName";
			public const string PaySummaryID = "PaySummaryID";
			public const string PayMoney = "PayMoney";
			public const string PayTypeID = "PayTypeID";
			public const string PayType = "PayType";
			public const string AccountType = "AccountType";
			public const string PayTime = "PayTime";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string AddManID = "AddManID";
			public const string RoomName = "RoomName";
			public const string ModifyTime = "ModifyTime";
			public const string ModifyMan = "ModifyMan";
			public const string ModifyManID = "ModifyManID";
			public const string Remark = "Remark";
			public const string PrintID = "PrintID";
			public const string Status = "Status";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProjectID" , "int:"},
    			 {"ProjectName" , "string:"},
    			 {"PaySummaryID" , "int:"},
    			 {"PayMoney" , "decimal:"},
    			 {"PayTypeID" , "int:"},
    			 {"PayType" , "string:"},
    			 {"AccountType" , "string:"},
    			 {"PayTime" , "DateTime:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"AddManID" , "int:"},
    			 {"RoomName" , "string:"},
    			 {"ModifyTime" , "DateTime:"},
    			 {"ModifyMan" , "string:"},
    			 {"ModifyManID" , "int:"},
    			 {"Remark" , "string:"},
    			 {"PrintID" , "int:"},
    			 {"Status" , "int:1-待申请 2-待审核 3-审核通过 4-审核未通过"},
            };
		}
		#endregion
	}
}
