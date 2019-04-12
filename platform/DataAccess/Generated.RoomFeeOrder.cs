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
	/// This object represents the properties and methods of a RoomFeeOrder.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class RoomFeeOrder 
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
		private string _orderNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OrderNumber
		{
			[DebuggerStepThrough()]
			get { return this._orderNumber; }
			set 
			{
				if (this._orderNumber != value) 
				{
					this._orderNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _projectID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProjectID
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
		private string _orderUserMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OrderUserMan
		{
			[DebuggerStepThrough()]
			get { return this._orderUserMan; }
			set 
			{
				if (this._orderUserMan != value) 
				{
					this._orderUserMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderUserMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _orderTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime OrderTime
		{
			[DebuggerStepThrough()]
			get { return this._orderTime; }
			set 
			{
				if (this._orderTime != value) 
				{
					this._orderTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _operator = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Operator
		{
			[DebuggerStepThrough()]
			get { return this._operator; }
			set 
			{
				if (this._operator != value) 
				{
					this._operator = value;
					this.IsDirty = true;	
					OnPropertyChanged("Operator");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _orderCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal OrderCost
		{
			[DebuggerStepThrough()]
			get { return this._orderCost; }
			set 
			{
				if (this._orderCost != value) 
				{
					this._orderCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _approveStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
		private DateTime _chargeStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ChargeStartTime
		{
			[DebuggerStepThrough()]
			get { return this._chargeStartTime; }
			set 
			{
				if (this._chargeStartTime != value) 
				{
					this._chargeStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeStartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _chargeEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ChargeEndTime
		{
			[DebuggerStepThrough()]
			get { return this._chargeEndTime; }
			set 
			{
				if (this._chargeEndTime != value) 
				{
					this._chargeEndTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeEndTime");
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
		private int _orderNumberID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OrderNumberID
		{
			[DebuggerStepThrough()]
			get { return this._orderNumberID; }
			set 
			{
				if (this._orderNumberID != value) 
				{
					this._orderNumberID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderNumberID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _orderUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OrderUserID
		{
			[DebuggerStepThrough()]
			get { return this._orderUserID; }
			set 
			{
				if (this._orderUserID != value) 
				{
					this._orderUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _approveManUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ApproveManUserID
		{
			[DebuggerStepThrough()]
			get { return this._approveManUserID; }
			set 
			{
				if (this._approveManUserID != value) 
				{
					this._approveManUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveManUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _totalCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TotalCount
		{
			[DebuggerStepThrough()]
			get { return this._totalCount; }
			set 
			{
				if (this._totalCount != value) 
				{
					this._totalCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _totalPayCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TotalPayCount
		{
			[DebuggerStepThrough()]
			get { return this._totalPayCount; }
			set 
			{
				if (this._totalPayCount != value) 
				{
					this._totalPayCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalPayCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _totalCancelCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TotalCancelCount
		{
			[DebuggerStepThrough()]
			get { return this._totalCancelCount; }
			set 
			{
				if (this._totalCancelCount != value) 
				{
					this._totalCancelCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalCancelCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _totalPayBackCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TotalPayBackCount
		{
			[DebuggerStepThrough()]
			get { return this._totalPayBackCount; }
			set 
			{
				if (this._totalPayBackCount != value) 
				{
					this._totalPayBackCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalPayBackCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _startShouOrderNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string StartShouOrderNumber
		{
			[DebuggerStepThrough()]
			get { return this._startShouOrderNumber; }
			set 
			{
				if (this._startShouOrderNumber != value) 
				{
					this._startShouOrderNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("StartShouOrderNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _endShouOrderNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string EndShouOrderNumber
		{
			[DebuggerStepThrough()]
			get { return this._endShouOrderNumber; }
			set 
			{
				if (this._endShouOrderNumber != value) 
				{
					this._endShouOrderNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndShouOrderNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _startFuOrderNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string StartFuOrderNumber
		{
			[DebuggerStepThrough()]
			get { return this._startFuOrderNumber; }
			set 
			{
				if (this._startFuOrderNumber != value) 
				{
					this._startFuOrderNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("StartFuOrderNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _endFuOrderNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string EndFuOrderNumber
		{
			[DebuggerStepThrough()]
			get { return this._endFuOrderNumber; }
			set 
			{
				if (this._endFuOrderNumber != value) 
				{
					this._endFuOrderNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndFuOrderNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _shouTotalCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ShouTotalCost
		{
			[DebuggerStepThrough()]
			get { return this._shouTotalCost; }
			set 
			{
				if (this._shouTotalCost != value) 
				{
					this._shouTotalCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("ShouTotalCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _fuTotalCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal FuTotalCost
		{
			[DebuggerStepThrough()]
			get { return this._fuTotalCost; }
			set 
			{
				if (this._fuTotalCost != value) 
				{
					this._fuTotalCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("FuTotalCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _weiShuTotalCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal WeiShuTotalCost
		{
			[DebuggerStepThrough()]
			get { return this._weiShuTotalCost; }
			set 
			{
				if (this._weiShuTotalCost != value) 
				{
					this._weiShuTotalCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("WeiShuTotalCost");
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
	[OrderNumber] nvarchar(500),
	[ProjectID] ntext,
	[OrderUserMan] nvarchar(50),
	[OrderTime] datetime,
	[Operator] nvarchar(50),
	[OrderCost] decimal(18, 2),
	[ApproveStatus] int,
	[ApproveMan] nvarchar(50),
	[ApproveTime] datetime,
	[ApproveRemark] ntext,
	[ChargeStartTime] datetime,
	[ChargeEndTime] datetime,
	[AddTime] datetime,
	[OrderNumberID] int,
	[OrderUserID] int,
	[ApproveManUserID] int,
	[TotalCount] int,
	[TotalPayCount] int,
	[TotalCancelCount] int,
	[TotalPayBackCount] int,
	[StartShouOrderNumber] nvarchar(200),
	[EndShouOrderNumber] nvarchar(200),
	[StartFuOrderNumber] nvarchar(200),
	[EndFuOrderNumber] nvarchar(200),
	[ShouTotalCost] decimal(18, 2),
	[FuTotalCost] decimal(18, 2),
	[WeiShuTotalCost] decimal(18, 2)
);

INSERT INTO [dbo].[RoomFeeOrder] (
	[RoomFeeOrder].[OrderNumber],
	[RoomFeeOrder].[ProjectID],
	[RoomFeeOrder].[OrderUserMan],
	[RoomFeeOrder].[OrderTime],
	[RoomFeeOrder].[Operator],
	[RoomFeeOrder].[OrderCost],
	[RoomFeeOrder].[ApproveStatus],
	[RoomFeeOrder].[ApproveMan],
	[RoomFeeOrder].[ApproveTime],
	[RoomFeeOrder].[ApproveRemark],
	[RoomFeeOrder].[ChargeStartTime],
	[RoomFeeOrder].[ChargeEndTime],
	[RoomFeeOrder].[AddTime],
	[RoomFeeOrder].[OrderNumberID],
	[RoomFeeOrder].[OrderUserID],
	[RoomFeeOrder].[ApproveManUserID],
	[RoomFeeOrder].[TotalCount],
	[RoomFeeOrder].[TotalPayCount],
	[RoomFeeOrder].[TotalCancelCount],
	[RoomFeeOrder].[TotalPayBackCount],
	[RoomFeeOrder].[StartShouOrderNumber],
	[RoomFeeOrder].[EndShouOrderNumber],
	[RoomFeeOrder].[StartFuOrderNumber],
	[RoomFeeOrder].[EndFuOrderNumber],
	[RoomFeeOrder].[ShouTotalCost],
	[RoomFeeOrder].[FuTotalCost],
	[RoomFeeOrder].[WeiShuTotalCost]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrderNumber],
	INSERTED.[ProjectID],
	INSERTED.[OrderUserMan],
	INSERTED.[OrderTime],
	INSERTED.[Operator],
	INSERTED.[OrderCost],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[ChargeStartTime],
	INSERTED.[ChargeEndTime],
	INSERTED.[AddTime],
	INSERTED.[OrderNumberID],
	INSERTED.[OrderUserID],
	INSERTED.[ApproveManUserID],
	INSERTED.[TotalCount],
	INSERTED.[TotalPayCount],
	INSERTED.[TotalCancelCount],
	INSERTED.[TotalPayBackCount],
	INSERTED.[StartShouOrderNumber],
	INSERTED.[EndShouOrderNumber],
	INSERTED.[StartFuOrderNumber],
	INSERTED.[EndFuOrderNumber],
	INSERTED.[ShouTotalCost],
	INSERTED.[FuTotalCost],
	INSERTED.[WeiShuTotalCost]
into @table
VALUES ( 
	@OrderNumber,
	@ProjectID,
	@OrderUserMan,
	@OrderTime,
	@Operator,
	@OrderCost,
	@ApproveStatus,
	@ApproveMan,
	@ApproveTime,
	@ApproveRemark,
	@ChargeStartTime,
	@ChargeEndTime,
	@AddTime,
	@OrderNumberID,
	@OrderUserID,
	@ApproveManUserID,
	@TotalCount,
	@TotalPayCount,
	@TotalCancelCount,
	@TotalPayBackCount,
	@StartShouOrderNumber,
	@EndShouOrderNumber,
	@StartFuOrderNumber,
	@EndFuOrderNumber,
	@ShouTotalCost,
	@FuTotalCost,
	@WeiShuTotalCost 
); 

SELECT 
	[ID],
	[OrderNumber],
	[ProjectID],
	[OrderUserMan],
	[OrderTime],
	[Operator],
	[OrderCost],
	[ApproveStatus],
	[ApproveMan],
	[ApproveTime],
	[ApproveRemark],
	[ChargeStartTime],
	[ChargeEndTime],
	[AddTime],
	[OrderNumberID],
	[OrderUserID],
	[ApproveManUserID],
	[TotalCount],
	[TotalPayCount],
	[TotalCancelCount],
	[TotalPayBackCount],
	[StartShouOrderNumber],
	[EndShouOrderNumber],
	[StartFuOrderNumber],
	[EndFuOrderNumber],
	[ShouTotalCost],
	[FuTotalCost],
	[WeiShuTotalCost] 
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
	[OrderNumber] nvarchar(500),
	[ProjectID] ntext,
	[OrderUserMan] nvarchar(50),
	[OrderTime] datetime,
	[Operator] nvarchar(50),
	[OrderCost] decimal(18, 2),
	[ApproveStatus] int,
	[ApproveMan] nvarchar(50),
	[ApproveTime] datetime,
	[ApproveRemark] ntext,
	[ChargeStartTime] datetime,
	[ChargeEndTime] datetime,
	[AddTime] datetime,
	[OrderNumberID] int,
	[OrderUserID] int,
	[ApproveManUserID] int,
	[TotalCount] int,
	[TotalPayCount] int,
	[TotalCancelCount] int,
	[TotalPayBackCount] int,
	[StartShouOrderNumber] nvarchar(200),
	[EndShouOrderNumber] nvarchar(200),
	[StartFuOrderNumber] nvarchar(200),
	[EndFuOrderNumber] nvarchar(200),
	[ShouTotalCost] decimal(18, 2),
	[FuTotalCost] decimal(18, 2),
	[WeiShuTotalCost] decimal(18, 2)
);

UPDATE [dbo].[RoomFeeOrder] SET 
	[RoomFeeOrder].[OrderNumber] = @OrderNumber,
	[RoomFeeOrder].[ProjectID] = @ProjectID,
	[RoomFeeOrder].[OrderUserMan] = @OrderUserMan,
	[RoomFeeOrder].[OrderTime] = @OrderTime,
	[RoomFeeOrder].[Operator] = @Operator,
	[RoomFeeOrder].[OrderCost] = @OrderCost,
	[RoomFeeOrder].[ApproveStatus] = @ApproveStatus,
	[RoomFeeOrder].[ApproveMan] = @ApproveMan,
	[RoomFeeOrder].[ApproveTime] = @ApproveTime,
	[RoomFeeOrder].[ApproveRemark] = @ApproveRemark,
	[RoomFeeOrder].[ChargeStartTime] = @ChargeStartTime,
	[RoomFeeOrder].[ChargeEndTime] = @ChargeEndTime,
	[RoomFeeOrder].[AddTime] = @AddTime,
	[RoomFeeOrder].[OrderNumberID] = @OrderNumberID,
	[RoomFeeOrder].[OrderUserID] = @OrderUserID,
	[RoomFeeOrder].[ApproveManUserID] = @ApproveManUserID,
	[RoomFeeOrder].[TotalCount] = @TotalCount,
	[RoomFeeOrder].[TotalPayCount] = @TotalPayCount,
	[RoomFeeOrder].[TotalCancelCount] = @TotalCancelCount,
	[RoomFeeOrder].[TotalPayBackCount] = @TotalPayBackCount,
	[RoomFeeOrder].[StartShouOrderNumber] = @StartShouOrderNumber,
	[RoomFeeOrder].[EndShouOrderNumber] = @EndShouOrderNumber,
	[RoomFeeOrder].[StartFuOrderNumber] = @StartFuOrderNumber,
	[RoomFeeOrder].[EndFuOrderNumber] = @EndFuOrderNumber,
	[RoomFeeOrder].[ShouTotalCost] = @ShouTotalCost,
	[RoomFeeOrder].[FuTotalCost] = @FuTotalCost,
	[RoomFeeOrder].[WeiShuTotalCost] = @WeiShuTotalCost 
output 
	INSERTED.[ID],
	INSERTED.[OrderNumber],
	INSERTED.[ProjectID],
	INSERTED.[OrderUserMan],
	INSERTED.[OrderTime],
	INSERTED.[Operator],
	INSERTED.[OrderCost],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[ChargeStartTime],
	INSERTED.[ChargeEndTime],
	INSERTED.[AddTime],
	INSERTED.[OrderNumberID],
	INSERTED.[OrderUserID],
	INSERTED.[ApproveManUserID],
	INSERTED.[TotalCount],
	INSERTED.[TotalPayCount],
	INSERTED.[TotalCancelCount],
	INSERTED.[TotalPayBackCount],
	INSERTED.[StartShouOrderNumber],
	INSERTED.[EndShouOrderNumber],
	INSERTED.[StartFuOrderNumber],
	INSERTED.[EndFuOrderNumber],
	INSERTED.[ShouTotalCost],
	INSERTED.[FuTotalCost],
	INSERTED.[WeiShuTotalCost]
into @table
WHERE 
	[RoomFeeOrder].[ID] = @ID

SELECT 
	[ID],
	[OrderNumber],
	[ProjectID],
	[OrderUserMan],
	[OrderTime],
	[Operator],
	[OrderCost],
	[ApproveStatus],
	[ApproveMan],
	[ApproveTime],
	[ApproveRemark],
	[ChargeStartTime],
	[ChargeEndTime],
	[AddTime],
	[OrderNumberID],
	[OrderUserID],
	[ApproveManUserID],
	[TotalCount],
	[TotalPayCount],
	[TotalCancelCount],
	[TotalPayBackCount],
	[StartShouOrderNumber],
	[EndShouOrderNumber],
	[StartFuOrderNumber],
	[EndFuOrderNumber],
	[ShouTotalCost],
	[FuTotalCost],
	[WeiShuTotalCost] 
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
DELETE FROM [dbo].[RoomFeeOrder]
WHERE 
	[RoomFeeOrder].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public RoomFeeOrder() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetRoomFeeOrder(this.ID));
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
	[RoomFeeOrder].[ID],
	[RoomFeeOrder].[OrderNumber],
	[RoomFeeOrder].[ProjectID],
	[RoomFeeOrder].[OrderUserMan],
	[RoomFeeOrder].[OrderTime],
	[RoomFeeOrder].[Operator],
	[RoomFeeOrder].[OrderCost],
	[RoomFeeOrder].[ApproveStatus],
	[RoomFeeOrder].[ApproveMan],
	[RoomFeeOrder].[ApproveTime],
	[RoomFeeOrder].[ApproveRemark],
	[RoomFeeOrder].[ChargeStartTime],
	[RoomFeeOrder].[ChargeEndTime],
	[RoomFeeOrder].[AddTime],
	[RoomFeeOrder].[OrderNumberID],
	[RoomFeeOrder].[OrderUserID],
	[RoomFeeOrder].[ApproveManUserID],
	[RoomFeeOrder].[TotalCount],
	[RoomFeeOrder].[TotalPayCount],
	[RoomFeeOrder].[TotalCancelCount],
	[RoomFeeOrder].[TotalPayBackCount],
	[RoomFeeOrder].[StartShouOrderNumber],
	[RoomFeeOrder].[EndShouOrderNumber],
	[RoomFeeOrder].[StartFuOrderNumber],
	[RoomFeeOrder].[EndFuOrderNumber],
	[RoomFeeOrder].[ShouTotalCost],
	[RoomFeeOrder].[FuTotalCost],
	[RoomFeeOrder].[WeiShuTotalCost]
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
                return "RoomFeeOrder";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a RoomFeeOrder into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="projectID">projectID</param>
		/// <param name="orderUserMan">orderUserMan</param>
		/// <param name="orderTime">orderTime</param>
		/// <param name="operator">operator</param>
		/// <param name="orderCost">orderCost</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="chargeStartTime">chargeStartTime</param>
		/// <param name="chargeEndTime">chargeEndTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="orderUserID">orderUserID</param>
		/// <param name="approveManUserID">approveManUserID</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="totalPayCount">totalPayCount</param>
		/// <param name="totalCancelCount">totalCancelCount</param>
		/// <param name="totalPayBackCount">totalPayBackCount</param>
		/// <param name="startShouOrderNumber">startShouOrderNumber</param>
		/// <param name="endShouOrderNumber">endShouOrderNumber</param>
		/// <param name="startFuOrderNumber">startFuOrderNumber</param>
		/// <param name="endFuOrderNumber">endFuOrderNumber</param>
		/// <param name="shouTotalCost">shouTotalCost</param>
		/// <param name="fuTotalCost">fuTotalCost</param>
		/// <param name="weiShuTotalCost">weiShuTotalCost</param>
		public static void InsertRoomFeeOrder(string @orderNumber, string @projectID, string @orderUserMan, DateTime @orderTime, string @operator, decimal @orderCost, int @approveStatus, string @approveMan, DateTime @approveTime, string @approveRemark, DateTime @chargeStartTime, DateTime @chargeEndTime, DateTime @addTime, int @orderNumberID, int @orderUserID, int @approveManUserID, int @totalCount, int @totalPayCount, int @totalCancelCount, int @totalPayBackCount, string @startShouOrderNumber, string @endShouOrderNumber, string @startFuOrderNumber, string @endFuOrderNumber, decimal @shouTotalCost, decimal @fuTotalCost, decimal @weiShuTotalCost)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertRoomFeeOrder(@orderNumber, @projectID, @orderUserMan, @orderTime, @operator, @orderCost, @approveStatus, @approveMan, @approveTime, @approveRemark, @chargeStartTime, @chargeEndTime, @addTime, @orderNumberID, @orderUserID, @approveManUserID, @totalCount, @totalPayCount, @totalCancelCount, @totalPayBackCount, @startShouOrderNumber, @endShouOrderNumber, @startFuOrderNumber, @endFuOrderNumber, @shouTotalCost, @fuTotalCost, @weiShuTotalCost, helper);
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
		/// Insert a RoomFeeOrder into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="projectID">projectID</param>
		/// <param name="orderUserMan">orderUserMan</param>
		/// <param name="orderTime">orderTime</param>
		/// <param name="operator">operator</param>
		/// <param name="orderCost">orderCost</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="chargeStartTime">chargeStartTime</param>
		/// <param name="chargeEndTime">chargeEndTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="orderUserID">orderUserID</param>
		/// <param name="approveManUserID">approveManUserID</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="totalPayCount">totalPayCount</param>
		/// <param name="totalCancelCount">totalCancelCount</param>
		/// <param name="totalPayBackCount">totalPayBackCount</param>
		/// <param name="startShouOrderNumber">startShouOrderNumber</param>
		/// <param name="endShouOrderNumber">endShouOrderNumber</param>
		/// <param name="startFuOrderNumber">startFuOrderNumber</param>
		/// <param name="endFuOrderNumber">endFuOrderNumber</param>
		/// <param name="shouTotalCost">shouTotalCost</param>
		/// <param name="fuTotalCost">fuTotalCost</param>
		/// <param name="weiShuTotalCost">weiShuTotalCost</param>
		/// <param name="helper">helper</param>
		internal static void InsertRoomFeeOrder(string @orderNumber, string @projectID, string @orderUserMan, DateTime @orderTime, string @operator, decimal @orderCost, int @approveStatus, string @approveMan, DateTime @approveTime, string @approveRemark, DateTime @chargeStartTime, DateTime @chargeEndTime, DateTime @addTime, int @orderNumberID, int @orderUserID, int @approveManUserID, int @totalCount, int @totalPayCount, int @totalCancelCount, int @totalPayBackCount, string @startShouOrderNumber, string @endShouOrderNumber, string @startFuOrderNumber, string @endFuOrderNumber, decimal @shouTotalCost, decimal @fuTotalCost, decimal @weiShuTotalCost, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrderNumber] nvarchar(500),
	[ProjectID] ntext,
	[OrderUserMan] nvarchar(50),
	[OrderTime] datetime,
	[Operator] nvarchar(50),
	[OrderCost] decimal(18, 2),
	[ApproveStatus] int,
	[ApproveMan] nvarchar(50),
	[ApproveTime] datetime,
	[ApproveRemark] ntext,
	[ChargeStartTime] datetime,
	[ChargeEndTime] datetime,
	[AddTime] datetime,
	[OrderNumberID] int,
	[OrderUserID] int,
	[ApproveManUserID] int,
	[TotalCount] int,
	[TotalPayCount] int,
	[TotalCancelCount] int,
	[TotalPayBackCount] int,
	[StartShouOrderNumber] nvarchar(200),
	[EndShouOrderNumber] nvarchar(200),
	[StartFuOrderNumber] nvarchar(200),
	[EndFuOrderNumber] nvarchar(200),
	[ShouTotalCost] decimal(18, 2),
	[FuTotalCost] decimal(18, 2),
	[WeiShuTotalCost] decimal(18, 2)
);

INSERT INTO [dbo].[RoomFeeOrder] (
	[RoomFeeOrder].[OrderNumber],
	[RoomFeeOrder].[ProjectID],
	[RoomFeeOrder].[OrderUserMan],
	[RoomFeeOrder].[OrderTime],
	[RoomFeeOrder].[Operator],
	[RoomFeeOrder].[OrderCost],
	[RoomFeeOrder].[ApproveStatus],
	[RoomFeeOrder].[ApproveMan],
	[RoomFeeOrder].[ApproveTime],
	[RoomFeeOrder].[ApproveRemark],
	[RoomFeeOrder].[ChargeStartTime],
	[RoomFeeOrder].[ChargeEndTime],
	[RoomFeeOrder].[AddTime],
	[RoomFeeOrder].[OrderNumberID],
	[RoomFeeOrder].[OrderUserID],
	[RoomFeeOrder].[ApproveManUserID],
	[RoomFeeOrder].[TotalCount],
	[RoomFeeOrder].[TotalPayCount],
	[RoomFeeOrder].[TotalCancelCount],
	[RoomFeeOrder].[TotalPayBackCount],
	[RoomFeeOrder].[StartShouOrderNumber],
	[RoomFeeOrder].[EndShouOrderNumber],
	[RoomFeeOrder].[StartFuOrderNumber],
	[RoomFeeOrder].[EndFuOrderNumber],
	[RoomFeeOrder].[ShouTotalCost],
	[RoomFeeOrder].[FuTotalCost],
	[RoomFeeOrder].[WeiShuTotalCost]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrderNumber],
	INSERTED.[ProjectID],
	INSERTED.[OrderUserMan],
	INSERTED.[OrderTime],
	INSERTED.[Operator],
	INSERTED.[OrderCost],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[ChargeStartTime],
	INSERTED.[ChargeEndTime],
	INSERTED.[AddTime],
	INSERTED.[OrderNumberID],
	INSERTED.[OrderUserID],
	INSERTED.[ApproveManUserID],
	INSERTED.[TotalCount],
	INSERTED.[TotalPayCount],
	INSERTED.[TotalCancelCount],
	INSERTED.[TotalPayBackCount],
	INSERTED.[StartShouOrderNumber],
	INSERTED.[EndShouOrderNumber],
	INSERTED.[StartFuOrderNumber],
	INSERTED.[EndFuOrderNumber],
	INSERTED.[ShouTotalCost],
	INSERTED.[FuTotalCost],
	INSERTED.[WeiShuTotalCost]
into @table
VALUES ( 
	@OrderNumber,
	@ProjectID,
	@OrderUserMan,
	@OrderTime,
	@Operator,
	@OrderCost,
	@ApproveStatus,
	@ApproveMan,
	@ApproveTime,
	@ApproveRemark,
	@ChargeStartTime,
	@ChargeEndTime,
	@AddTime,
	@OrderNumberID,
	@OrderUserID,
	@ApproveManUserID,
	@TotalCount,
	@TotalPayCount,
	@TotalCancelCount,
	@TotalPayBackCount,
	@StartShouOrderNumber,
	@EndShouOrderNumber,
	@StartFuOrderNumber,
	@EndFuOrderNumber,
	@ShouTotalCost,
	@FuTotalCost,
	@WeiShuTotalCost 
); 

SELECT 
	[ID],
	[OrderNumber],
	[ProjectID],
	[OrderUserMan],
	[OrderTime],
	[Operator],
	[OrderCost],
	[ApproveStatus],
	[ApproveMan],
	[ApproveTime],
	[ApproveRemark],
	[ChargeStartTime],
	[ChargeEndTime],
	[AddTime],
	[OrderNumberID],
	[OrderUserID],
	[ApproveManUserID],
	[TotalCount],
	[TotalPayCount],
	[TotalCancelCount],
	[TotalPayBackCount],
	[StartShouOrderNumber],
	[EndShouOrderNumber],
	[StartFuOrderNumber],
	[EndFuOrderNumber],
	[ShouTotalCost],
	[FuTotalCost],
	[WeiShuTotalCost] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OrderNumber", EntityBase.GetDatabaseValue(@orderNumber)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@OrderUserMan", EntityBase.GetDatabaseValue(@orderUserMan)));
			parameters.Add(new SqlParameter("@OrderTime", EntityBase.GetDatabaseValue(@orderTime)));
			parameters.Add(new SqlParameter("@Operator", EntityBase.GetDatabaseValue(@operator)));
			parameters.Add(new SqlParameter("@OrderCost", EntityBase.GetDatabaseValue(@orderCost)));
			parameters.Add(new SqlParameter("@ApproveStatus", EntityBase.GetDatabaseValue(@approveStatus)));
			parameters.Add(new SqlParameter("@ApproveMan", EntityBase.GetDatabaseValue(@approveMan)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@ChargeStartTime", EntityBase.GetDatabaseValue(@chargeStartTime)));
			parameters.Add(new SqlParameter("@ChargeEndTime", EntityBase.GetDatabaseValue(@chargeEndTime)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@OrderNumberID", EntityBase.GetDatabaseValue(@orderNumberID)));
			parameters.Add(new SqlParameter("@OrderUserID", EntityBase.GetDatabaseValue(@orderUserID)));
			parameters.Add(new SqlParameter("@ApproveManUserID", EntityBase.GetDatabaseValue(@approveManUserID)));
			parameters.Add(new SqlParameter("@TotalCount", EntityBase.GetDatabaseValue(@totalCount)));
			parameters.Add(new SqlParameter("@TotalPayCount", EntityBase.GetDatabaseValue(@totalPayCount)));
			parameters.Add(new SqlParameter("@TotalCancelCount", EntityBase.GetDatabaseValue(@totalCancelCount)));
			parameters.Add(new SqlParameter("@TotalPayBackCount", EntityBase.GetDatabaseValue(@totalPayBackCount)));
			parameters.Add(new SqlParameter("@StartShouOrderNumber", EntityBase.GetDatabaseValue(@startShouOrderNumber)));
			parameters.Add(new SqlParameter("@EndShouOrderNumber", EntityBase.GetDatabaseValue(@endShouOrderNumber)));
			parameters.Add(new SqlParameter("@StartFuOrderNumber", EntityBase.GetDatabaseValue(@startFuOrderNumber)));
			parameters.Add(new SqlParameter("@EndFuOrderNumber", EntityBase.GetDatabaseValue(@endFuOrderNumber)));
			parameters.Add(new SqlParameter("@ShouTotalCost", EntityBase.GetDatabaseValue(@shouTotalCost)));
			parameters.Add(new SqlParameter("@FuTotalCost", EntityBase.GetDatabaseValue(@fuTotalCost)));
			parameters.Add(new SqlParameter("@WeiShuTotalCost", EntityBase.GetDatabaseValue(@weiShuTotalCost)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a RoomFeeOrder into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="projectID">projectID</param>
		/// <param name="orderUserMan">orderUserMan</param>
		/// <param name="orderTime">orderTime</param>
		/// <param name="operator">operator</param>
		/// <param name="orderCost">orderCost</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="chargeStartTime">chargeStartTime</param>
		/// <param name="chargeEndTime">chargeEndTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="orderUserID">orderUserID</param>
		/// <param name="approveManUserID">approveManUserID</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="totalPayCount">totalPayCount</param>
		/// <param name="totalCancelCount">totalCancelCount</param>
		/// <param name="totalPayBackCount">totalPayBackCount</param>
		/// <param name="startShouOrderNumber">startShouOrderNumber</param>
		/// <param name="endShouOrderNumber">endShouOrderNumber</param>
		/// <param name="startFuOrderNumber">startFuOrderNumber</param>
		/// <param name="endFuOrderNumber">endFuOrderNumber</param>
		/// <param name="shouTotalCost">shouTotalCost</param>
		/// <param name="fuTotalCost">fuTotalCost</param>
		/// <param name="weiShuTotalCost">weiShuTotalCost</param>
		public static void UpdateRoomFeeOrder(int @iD, string @orderNumber, string @projectID, string @orderUserMan, DateTime @orderTime, string @operator, decimal @orderCost, int @approveStatus, string @approveMan, DateTime @approveTime, string @approveRemark, DateTime @chargeStartTime, DateTime @chargeEndTime, DateTime @addTime, int @orderNumberID, int @orderUserID, int @approveManUserID, int @totalCount, int @totalPayCount, int @totalCancelCount, int @totalPayBackCount, string @startShouOrderNumber, string @endShouOrderNumber, string @startFuOrderNumber, string @endFuOrderNumber, decimal @shouTotalCost, decimal @fuTotalCost, decimal @weiShuTotalCost)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateRoomFeeOrder(@iD, @orderNumber, @projectID, @orderUserMan, @orderTime, @operator, @orderCost, @approveStatus, @approveMan, @approveTime, @approveRemark, @chargeStartTime, @chargeEndTime, @addTime, @orderNumberID, @orderUserID, @approveManUserID, @totalCount, @totalPayCount, @totalCancelCount, @totalPayBackCount, @startShouOrderNumber, @endShouOrderNumber, @startFuOrderNumber, @endFuOrderNumber, @shouTotalCost, @fuTotalCost, @weiShuTotalCost, helper);
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
		/// Updates a RoomFeeOrder into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="projectID">projectID</param>
		/// <param name="orderUserMan">orderUserMan</param>
		/// <param name="orderTime">orderTime</param>
		/// <param name="operator">operator</param>
		/// <param name="orderCost">orderCost</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="chargeStartTime">chargeStartTime</param>
		/// <param name="chargeEndTime">chargeEndTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="orderUserID">orderUserID</param>
		/// <param name="approveManUserID">approveManUserID</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="totalPayCount">totalPayCount</param>
		/// <param name="totalCancelCount">totalCancelCount</param>
		/// <param name="totalPayBackCount">totalPayBackCount</param>
		/// <param name="startShouOrderNumber">startShouOrderNumber</param>
		/// <param name="endShouOrderNumber">endShouOrderNumber</param>
		/// <param name="startFuOrderNumber">startFuOrderNumber</param>
		/// <param name="endFuOrderNumber">endFuOrderNumber</param>
		/// <param name="shouTotalCost">shouTotalCost</param>
		/// <param name="fuTotalCost">fuTotalCost</param>
		/// <param name="weiShuTotalCost">weiShuTotalCost</param>
		/// <param name="helper">helper</param>
		internal static void UpdateRoomFeeOrder(int @iD, string @orderNumber, string @projectID, string @orderUserMan, DateTime @orderTime, string @operator, decimal @orderCost, int @approveStatus, string @approveMan, DateTime @approveTime, string @approveRemark, DateTime @chargeStartTime, DateTime @chargeEndTime, DateTime @addTime, int @orderNumberID, int @orderUserID, int @approveManUserID, int @totalCount, int @totalPayCount, int @totalCancelCount, int @totalPayBackCount, string @startShouOrderNumber, string @endShouOrderNumber, string @startFuOrderNumber, string @endFuOrderNumber, decimal @shouTotalCost, decimal @fuTotalCost, decimal @weiShuTotalCost, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrderNumber] nvarchar(500),
	[ProjectID] ntext,
	[OrderUserMan] nvarchar(50),
	[OrderTime] datetime,
	[Operator] nvarchar(50),
	[OrderCost] decimal(18, 2),
	[ApproveStatus] int,
	[ApproveMan] nvarchar(50),
	[ApproveTime] datetime,
	[ApproveRemark] ntext,
	[ChargeStartTime] datetime,
	[ChargeEndTime] datetime,
	[AddTime] datetime,
	[OrderNumberID] int,
	[OrderUserID] int,
	[ApproveManUserID] int,
	[TotalCount] int,
	[TotalPayCount] int,
	[TotalCancelCount] int,
	[TotalPayBackCount] int,
	[StartShouOrderNumber] nvarchar(200),
	[EndShouOrderNumber] nvarchar(200),
	[StartFuOrderNumber] nvarchar(200),
	[EndFuOrderNumber] nvarchar(200),
	[ShouTotalCost] decimal(18, 2),
	[FuTotalCost] decimal(18, 2),
	[WeiShuTotalCost] decimal(18, 2)
);

UPDATE [dbo].[RoomFeeOrder] SET 
	[RoomFeeOrder].[OrderNumber] = @OrderNumber,
	[RoomFeeOrder].[ProjectID] = @ProjectID,
	[RoomFeeOrder].[OrderUserMan] = @OrderUserMan,
	[RoomFeeOrder].[OrderTime] = @OrderTime,
	[RoomFeeOrder].[Operator] = @Operator,
	[RoomFeeOrder].[OrderCost] = @OrderCost,
	[RoomFeeOrder].[ApproveStatus] = @ApproveStatus,
	[RoomFeeOrder].[ApproveMan] = @ApproveMan,
	[RoomFeeOrder].[ApproveTime] = @ApproveTime,
	[RoomFeeOrder].[ApproveRemark] = @ApproveRemark,
	[RoomFeeOrder].[ChargeStartTime] = @ChargeStartTime,
	[RoomFeeOrder].[ChargeEndTime] = @ChargeEndTime,
	[RoomFeeOrder].[AddTime] = @AddTime,
	[RoomFeeOrder].[OrderNumberID] = @OrderNumberID,
	[RoomFeeOrder].[OrderUserID] = @OrderUserID,
	[RoomFeeOrder].[ApproveManUserID] = @ApproveManUserID,
	[RoomFeeOrder].[TotalCount] = @TotalCount,
	[RoomFeeOrder].[TotalPayCount] = @TotalPayCount,
	[RoomFeeOrder].[TotalCancelCount] = @TotalCancelCount,
	[RoomFeeOrder].[TotalPayBackCount] = @TotalPayBackCount,
	[RoomFeeOrder].[StartShouOrderNumber] = @StartShouOrderNumber,
	[RoomFeeOrder].[EndShouOrderNumber] = @EndShouOrderNumber,
	[RoomFeeOrder].[StartFuOrderNumber] = @StartFuOrderNumber,
	[RoomFeeOrder].[EndFuOrderNumber] = @EndFuOrderNumber,
	[RoomFeeOrder].[ShouTotalCost] = @ShouTotalCost,
	[RoomFeeOrder].[FuTotalCost] = @FuTotalCost,
	[RoomFeeOrder].[WeiShuTotalCost] = @WeiShuTotalCost 
output 
	INSERTED.[ID],
	INSERTED.[OrderNumber],
	INSERTED.[ProjectID],
	INSERTED.[OrderUserMan],
	INSERTED.[OrderTime],
	INSERTED.[Operator],
	INSERTED.[OrderCost],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark],
	INSERTED.[ChargeStartTime],
	INSERTED.[ChargeEndTime],
	INSERTED.[AddTime],
	INSERTED.[OrderNumberID],
	INSERTED.[OrderUserID],
	INSERTED.[ApproveManUserID],
	INSERTED.[TotalCount],
	INSERTED.[TotalPayCount],
	INSERTED.[TotalCancelCount],
	INSERTED.[TotalPayBackCount],
	INSERTED.[StartShouOrderNumber],
	INSERTED.[EndShouOrderNumber],
	INSERTED.[StartFuOrderNumber],
	INSERTED.[EndFuOrderNumber],
	INSERTED.[ShouTotalCost],
	INSERTED.[FuTotalCost],
	INSERTED.[WeiShuTotalCost]
into @table
WHERE 
	[RoomFeeOrder].[ID] = @ID

SELECT 
	[ID],
	[OrderNumber],
	[ProjectID],
	[OrderUserMan],
	[OrderTime],
	[Operator],
	[OrderCost],
	[ApproveStatus],
	[ApproveMan],
	[ApproveTime],
	[ApproveRemark],
	[ChargeStartTime],
	[ChargeEndTime],
	[AddTime],
	[OrderNumberID],
	[OrderUserID],
	[ApproveManUserID],
	[TotalCount],
	[TotalPayCount],
	[TotalCancelCount],
	[TotalPayBackCount],
	[StartShouOrderNumber],
	[EndShouOrderNumber],
	[StartFuOrderNumber],
	[EndFuOrderNumber],
	[ShouTotalCost],
	[FuTotalCost],
	[WeiShuTotalCost] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OrderNumber", EntityBase.GetDatabaseValue(@orderNumber)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@OrderUserMan", EntityBase.GetDatabaseValue(@orderUserMan)));
			parameters.Add(new SqlParameter("@OrderTime", EntityBase.GetDatabaseValue(@orderTime)));
			parameters.Add(new SqlParameter("@Operator", EntityBase.GetDatabaseValue(@operator)));
			parameters.Add(new SqlParameter("@OrderCost", EntityBase.GetDatabaseValue(@orderCost)));
			parameters.Add(new SqlParameter("@ApproveStatus", EntityBase.GetDatabaseValue(@approveStatus)));
			parameters.Add(new SqlParameter("@ApproveMan", EntityBase.GetDatabaseValue(@approveMan)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@ChargeStartTime", EntityBase.GetDatabaseValue(@chargeStartTime)));
			parameters.Add(new SqlParameter("@ChargeEndTime", EntityBase.GetDatabaseValue(@chargeEndTime)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@OrderNumberID", EntityBase.GetDatabaseValue(@orderNumberID)));
			parameters.Add(new SqlParameter("@OrderUserID", EntityBase.GetDatabaseValue(@orderUserID)));
			parameters.Add(new SqlParameter("@ApproveManUserID", EntityBase.GetDatabaseValue(@approveManUserID)));
			parameters.Add(new SqlParameter("@TotalCount", EntityBase.GetDatabaseValue(@totalCount)));
			parameters.Add(new SqlParameter("@TotalPayCount", EntityBase.GetDatabaseValue(@totalPayCount)));
			parameters.Add(new SqlParameter("@TotalCancelCount", EntityBase.GetDatabaseValue(@totalCancelCount)));
			parameters.Add(new SqlParameter("@TotalPayBackCount", EntityBase.GetDatabaseValue(@totalPayBackCount)));
			parameters.Add(new SqlParameter("@StartShouOrderNumber", EntityBase.GetDatabaseValue(@startShouOrderNumber)));
			parameters.Add(new SqlParameter("@EndShouOrderNumber", EntityBase.GetDatabaseValue(@endShouOrderNumber)));
			parameters.Add(new SqlParameter("@StartFuOrderNumber", EntityBase.GetDatabaseValue(@startFuOrderNumber)));
			parameters.Add(new SqlParameter("@EndFuOrderNumber", EntityBase.GetDatabaseValue(@endFuOrderNumber)));
			parameters.Add(new SqlParameter("@ShouTotalCost", EntityBase.GetDatabaseValue(@shouTotalCost)));
			parameters.Add(new SqlParameter("@FuTotalCost", EntityBase.GetDatabaseValue(@fuTotalCost)));
			parameters.Add(new SqlParameter("@WeiShuTotalCost", EntityBase.GetDatabaseValue(@weiShuTotalCost)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a RoomFeeOrder from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteRoomFeeOrder(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteRoomFeeOrder(@iD, helper);
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
		/// Deletes a RoomFeeOrder from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteRoomFeeOrder(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[RoomFeeOrder]
WHERE 
	[RoomFeeOrder].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new RoomFeeOrder object.
		/// </summary>
		/// <returns>The newly created RoomFeeOrder object.</returns>
		public static RoomFeeOrder CreateRoomFeeOrder()
		{
			return InitializeNew<RoomFeeOrder>();
		}
		
		/// <summary>
		/// Retrieve information for a RoomFeeOrder by a RoomFeeOrder's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>RoomFeeOrder</returns>
		public static RoomFeeOrder GetRoomFeeOrder(int @iD)
		{
			string commandText = @"
SELECT 
" + RoomFeeOrder.SelectFieldList + @"
FROM [dbo].[RoomFeeOrder] 
WHERE 
	[RoomFeeOrder].[ID] = @ID " + RoomFeeOrder.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomFeeOrder>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a RoomFeeOrder by a RoomFeeOrder's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>RoomFeeOrder</returns>
		public static RoomFeeOrder GetRoomFeeOrder(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + RoomFeeOrder.SelectFieldList + @"
FROM [dbo].[RoomFeeOrder] 
WHERE 
	[RoomFeeOrder].[ID] = @ID " + RoomFeeOrder.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomFeeOrder>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection RoomFeeOrder objects.
		/// </summary>
		/// <returns>The retrieved collection of RoomFeeOrder objects.</returns>
		public static EntityList<RoomFeeOrder> GetRoomFeeOrders()
		{
			string commandText = @"
SELECT " + RoomFeeOrder.SelectFieldList + "FROM [dbo].[RoomFeeOrder] " + RoomFeeOrder.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<RoomFeeOrder>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection RoomFeeOrder objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomFeeOrder objects.</returns>
        public static EntityList<RoomFeeOrder> GetRoomFeeOrders(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomFeeOrder>(SelectFieldList, "FROM [dbo].[RoomFeeOrder]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection RoomFeeOrder objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomFeeOrder objects.</returns>
        public static EntityList<RoomFeeOrder> GetRoomFeeOrders(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomFeeOrder>(SelectFieldList, "FROM [dbo].[RoomFeeOrder]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection RoomFeeOrder objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of RoomFeeOrder objects.</returns>
		protected static EntityList<RoomFeeOrder> GetRoomFeeOrders(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomFeeOrders(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection RoomFeeOrder objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomFeeOrder objects.</returns>
		protected static EntityList<RoomFeeOrder> GetRoomFeeOrders(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomFeeOrders(string.Empty, where, parameters, RoomFeeOrder.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomFeeOrder objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomFeeOrder objects.</returns>
		protected static EntityList<RoomFeeOrder> GetRoomFeeOrders(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomFeeOrders(prefix, where, parameters, RoomFeeOrder.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomFeeOrder objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomFeeOrder objects.</returns>
		protected static EntityList<RoomFeeOrder> GetRoomFeeOrders(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomFeeOrders(string.Empty, where, parameters, RoomFeeOrder.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomFeeOrder objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomFeeOrder objects.</returns>
		protected static EntityList<RoomFeeOrder> GetRoomFeeOrders(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomFeeOrders(prefix, where, parameters, RoomFeeOrder.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomFeeOrder objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of RoomFeeOrder objects.</returns>
		protected static EntityList<RoomFeeOrder> GetRoomFeeOrders(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + RoomFeeOrder.SelectFieldList + "FROM [dbo].[RoomFeeOrder] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<RoomFeeOrder>(reader);
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
        protected static EntityList<RoomFeeOrder> GetRoomFeeOrders(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomFeeOrder>(SelectFieldList, "FROM [dbo].[RoomFeeOrder] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of RoomFeeOrder objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomFeeOrderCount()
        {
            return GetRoomFeeOrderCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of RoomFeeOrder objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomFeeOrderCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[RoomFeeOrder] " + where;

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
		public static partial class RoomFeeOrder_Properties
		{
			public const string ID = "ID";
			public const string OrderNumber = "OrderNumber";
			public const string ProjectID = "ProjectID";
			public const string OrderUserMan = "OrderUserMan";
			public const string OrderTime = "OrderTime";
			public const string Operator = "Operator";
			public const string OrderCost = "OrderCost";
			public const string ApproveStatus = "ApproveStatus";
			public const string ApproveMan = "ApproveMan";
			public const string ApproveTime = "ApproveTime";
			public const string ApproveRemark = "ApproveRemark";
			public const string ChargeStartTime = "ChargeStartTime";
			public const string ChargeEndTime = "ChargeEndTime";
			public const string AddTime = "AddTime";
			public const string OrderNumberID = "OrderNumberID";
			public const string OrderUserID = "OrderUserID";
			public const string ApproveManUserID = "ApproveManUserID";
			public const string TotalCount = "TotalCount";
			public const string TotalPayCount = "TotalPayCount";
			public const string TotalCancelCount = "TotalCancelCount";
			public const string TotalPayBackCount = "TotalPayBackCount";
			public const string StartShouOrderNumber = "StartShouOrderNumber";
			public const string EndShouOrderNumber = "EndShouOrderNumber";
			public const string StartFuOrderNumber = "StartFuOrderNumber";
			public const string EndFuOrderNumber = "EndFuOrderNumber";
			public const string ShouTotalCost = "ShouTotalCost";
			public const string FuTotalCost = "FuTotalCost";
			public const string WeiShuTotalCost = "WeiShuTotalCost";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OrderNumber" , "string:"},
    			 {"ProjectID" , "string:"},
    			 {"OrderUserMan" , "string:"},
    			 {"OrderTime" , "DateTime:"},
    			 {"Operator" , "string:"},
    			 {"OrderCost" , "decimal:"},
    			 {"ApproveStatus" , "int:"},
    			 {"ApproveMan" , "string:"},
    			 {"ApproveTime" , "DateTime:"},
    			 {"ApproveRemark" , "string:"},
    			 {"ChargeStartTime" , "DateTime:"},
    			 {"ChargeEndTime" , "DateTime:"},
    			 {"AddTime" , "DateTime:"},
    			 {"OrderNumberID" , "int:"},
    			 {"OrderUserID" , "int:"},
    			 {"ApproveManUserID" , "int:"},
    			 {"TotalCount" , "int:"},
    			 {"TotalPayCount" , "int:"},
    			 {"TotalCancelCount" , "int:"},
    			 {"TotalPayBackCount" , "int:"},
    			 {"StartShouOrderNumber" , "string:"},
    			 {"EndShouOrderNumber" , "string:"},
    			 {"StartFuOrderNumber" , "string:"},
    			 {"EndFuOrderNumber" , "string:"},
    			 {"ShouTotalCost" , "decimal:"},
    			 {"FuTotalCost" , "decimal:"},
    			 {"WeiShuTotalCost" , "decimal:"},
            };
		}
		#endregion
	}
}
