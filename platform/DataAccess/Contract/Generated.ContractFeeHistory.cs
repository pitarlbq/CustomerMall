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
	/// This object represents the properties and methods of a ContractFeeHistory.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("HistoryID: {HistoryID}")]
	public partial class ContractFeeHistory 
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
		[DataObjectField(false, false, false)]
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
		private int _roomID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RoomID
		{
			[DebuggerStepThrough()]
			get { return this._roomID; }
			set 
			{
				if (this._roomID != value) 
				{
					this._roomID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _useCount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal UseCount
		{
			[DebuggerStepThrough()]
			get { return this._useCount; }
			set 
			{
				if (this._useCount != value) 
				{
					this._useCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("UseCount");
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
		private decimal _cost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal Cost
		{
			[DebuggerStepThrough()]
			get { return this._cost; }
			set 
			{
				if (this._cost != value) 
				{
					this._cost = value;
					this.IsDirty = true;	
					OnPropertyChanged("Cost");
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
		private bool _isCharged = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsCharged
		{
			[DebuggerStepThrough()]
			get { return this._isCharged; }
			set 
			{
				if (this._isCharged != value) 
				{
					this._isCharged = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsCharged");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargeFeeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChargeFeeID
		{
			[DebuggerStepThrough()]
			get { return this._chargeFeeID; }
			set 
			{
				if (this._chargeFeeID != value) 
				{
					this._chargeFeeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeFeeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ChargeID
		{
			[DebuggerStepThrough()]
			get { return this._chargeID; }
			set 
			{
				if (this._chargeID != value) 
				{
					this._chargeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isStart = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsStart
		{
			[DebuggerStepThrough()]
			get { return this._isStart; }
			set 
			{
				if (this._isStart != value) 
				{
					this._isStart = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsStart");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _newStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime NewStartTime
		{
			[DebuggerStepThrough()]
			get { return this._newStartTime; }
			set 
			{
				if (this._newStartTime != value) 
				{
					this._newStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("NewStartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _importFeeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ImportFeeID
		{
			[DebuggerStepThrough()]
			get { return this._importFeeID; }
			set 
			{
				if (this._importFeeID != value) 
				{
					this._importFeeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ImportFeeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _unitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal UnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._unitPrice; }
			set 
			{
				if (this._unitPrice != value) 
				{
					this._unitPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("UnitPrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _realCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RealCost
		{
			[DebuggerStepThrough()]
			get { return this._realCost; }
			set 
			{
				if (this._realCost != value) 
				{
					this._realCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("RealCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _discount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal Discount
		{
			[DebuggerStepThrough()]
			get { return this._discount; }
			set 
			{
				if (this._discount != value) 
				{
					this._discount = value;
					this.IsDirty = true;	
					OnPropertyChanged("Discount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _outDays = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OutDays
		{
			[DebuggerStepThrough()]
			get { return this._outDays; }
			set 
			{
				if (this._outDays != value) 
				{
					this._outDays = value;
					this.IsDirty = true;	
					OnPropertyChanged("OutDays");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _chargeFee = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ChargeFee
		{
			[DebuggerStepThrough()]
			get { return this._chargeFee; }
			set 
			{
				if (this._chargeFee != value) 
				{
					this._chargeFee = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeFee");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalRealCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalRealCost
		{
			[DebuggerStepThrough()]
			get { return this._totalRealCost; }
			set 
			{
				if (this._totalRealCost != value) 
				{
					this._totalRealCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalRealCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _restCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RestCost
		{
			[DebuggerStepThrough()]
			get { return this._restCost; }
			set 
			{
				if (this._restCost != value) 
				{
					this._restCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("RestCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalDiscountCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalDiscountCost
		{
			[DebuggerStepThrough()]
			get { return this._totalDiscountCost; }
			set 
			{
				if (this._totalDiscountCost != value) 
				{
					this._totalDiscountCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalDiscountCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _onlyOnceCharge = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool OnlyOnceCharge
		{
			[DebuggerStepThrough()]
			get { return this._onlyOnceCharge; }
			set 
			{
				if (this._onlyOnceCharge != value) 
				{
					this._onlyOnceCharge = value;
					this.IsDirty = true;	
					OnPropertyChanged("OnlyOnceCharge");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _newEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime NewEndTime
		{
			[DebuggerStepThrough()]
			get { return this._newEndTime; }
			set 
			{
				if (this._newEndTime != value) 
				{
					this._newEndTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("NewEndTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _chargeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime ChargeTime
		{
			[DebuggerStepThrough()]
			get { return this._chargeTime; }
			set 
			{
				if (this._chargeTime != value) 
				{
					this._chargeTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeMan
		{
			[DebuggerStepThrough()]
			get { return this._chargeMan; }
			set 
			{
				if (this._chargeMan != value) 
				{
					this._chargeMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _printNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PrintNumber
		{
			[DebuggerStepThrough()]
			get { return this._printNumber; }
			set 
			{
				if (this._printNumber != value) 
				{
					this._printNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _historyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, true, false)]
		public int HistoryID
		{
			[DebuggerStepThrough()]
			get { return this._historyID; }
			 set 
			{
				if (this._historyID != value) 
				{
					this._historyID = value;
					this.IsDirty = true;	
					OnPropertyChanged("HistoryID");
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
		private int _chargeState = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ChargeState
		{
			[DebuggerStepThrough()]
			get { return this._chargeState; }
			set 
			{
				if (this._chargeState != value) 
				{
					this._chargeState = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeState");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _returnGuaranteeFee = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool ReturnGuaranteeFee
		{
			[DebuggerStepThrough()]
			get { return this._returnGuaranteeFee; }
			set 
			{
				if (this._returnGuaranteeFee != value) 
				{
					this._returnGuaranteeFee = value;
					this.IsDirty = true;	
					OnPropertyChanged("ReturnGuaranteeFee");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _parentRoomFeeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ParentRoomFeeID
		{
			[DebuggerStepThrough()]
			get { return this._parentRoomFeeID; }
			set 
			{
				if (this._parentRoomFeeID != value) 
				{
					this._parentRoomFeeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ParentRoomFeeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _parentHistoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ParentHistoryID
		{
			[DebuggerStepThrough()]
			get { return this._parentHistoryID; }
			set 
			{
				if (this._parentHistoryID != value) 
				{
					this._parentHistoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ParentHistoryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isCuiShou = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsCuiShou
		{
			[DebuggerStepThrough()]
			get { return this._isCuiShou; }
			set 
			{
				if (this._isCuiShou != value) 
				{
					this._isCuiShou = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsCuiShou");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _contractID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ContractID
		{
			[DebuggerStepThrough()]
			get { return this._contractID; }
			set 
			{
				if (this._contractID != value) 
				{
					this._contractID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _discountID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int DiscountID
		{
			[DebuggerStepThrough()]
			get { return this._discountID; }
			set 
			{
				if (this._discountID != value) 
				{
					this._discountID = value;
					this.IsDirty = true;	
					OnPropertyChanged("DiscountID");
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
	[RoomID] int,
	[UseCount] decimal(18, 2),
	[StartTime] datetime,
	[EndTime] datetime,
	[Cost] decimal(18, 2),
	[Remark] ntext,
	[AddTime] datetime,
	[IsCharged] bit,
	[ChargeFeeID] int,
	[ChargeID] int,
	[IsStart] bit,
	[NewStartTime] datetime,
	[ImportFeeID] int,
	[UnitPrice] decimal(18, 3),
	[RealCost] decimal(18, 2),
	[Discount] decimal(18, 2),
	[OutDays] int,
	[ChargeFee] decimal(18, 2),
	[TotalRealCost] decimal(18, 2),
	[RestCost] decimal(18, 2),
	[TotalDiscountCost] decimal(18, 2),
	[OnlyOnceCharge] bit,
	[NewEndTime] datetime,
	[ChargeTime] datetime,
	[ChargeMan] nvarchar(100),
	[PrintNumber] nvarchar(200),
	[HistoryID] int,
	[PrintID] int,
	[ChargeState] int,
	[ReturnGuaranteeFee] bit,
	[ParentRoomFeeID] int,
	[ParentHistoryID] int,
	[IsCuiShou] bit,
	[ContractID] int,
	[DiscountID] int
);

INSERT INTO [dbo].[ContractFeeHistory] (
	[ContractFeeHistory].[ID],
	[ContractFeeHistory].[RoomID],
	[ContractFeeHistory].[UseCount],
	[ContractFeeHistory].[StartTime],
	[ContractFeeHistory].[EndTime],
	[ContractFeeHistory].[Cost],
	[ContractFeeHistory].[Remark],
	[ContractFeeHistory].[AddTime],
	[ContractFeeHistory].[IsCharged],
	[ContractFeeHistory].[ChargeFeeID],
	[ContractFeeHistory].[ChargeID],
	[ContractFeeHistory].[IsStart],
	[ContractFeeHistory].[NewStartTime],
	[ContractFeeHistory].[ImportFeeID],
	[ContractFeeHistory].[UnitPrice],
	[ContractFeeHistory].[RealCost],
	[ContractFeeHistory].[Discount],
	[ContractFeeHistory].[OutDays],
	[ContractFeeHistory].[ChargeFee],
	[ContractFeeHistory].[TotalRealCost],
	[ContractFeeHistory].[RestCost],
	[ContractFeeHistory].[TotalDiscountCost],
	[ContractFeeHistory].[OnlyOnceCharge],
	[ContractFeeHistory].[NewEndTime],
	[ContractFeeHistory].[ChargeTime],
	[ContractFeeHistory].[ChargeMan],
	[ContractFeeHistory].[PrintNumber],
	[ContractFeeHistory].[PrintID],
	[ContractFeeHistory].[ChargeState],
	[ContractFeeHistory].[ReturnGuaranteeFee],
	[ContractFeeHistory].[ParentRoomFeeID],
	[ContractFeeHistory].[ParentHistoryID],
	[ContractFeeHistory].[IsCuiShou],
	[ContractFeeHistory].[ContractID],
	[ContractFeeHistory].[DiscountID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[UseCount],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[Cost],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[IsCharged],
	INSERTED.[ChargeFeeID],
	INSERTED.[ChargeID],
	INSERTED.[IsStart],
	INSERTED.[NewStartTime],
	INSERTED.[ImportFeeID],
	INSERTED.[UnitPrice],
	INSERTED.[RealCost],
	INSERTED.[Discount],
	INSERTED.[OutDays],
	INSERTED.[ChargeFee],
	INSERTED.[TotalRealCost],
	INSERTED.[RestCost],
	INSERTED.[TotalDiscountCost],
	INSERTED.[OnlyOnceCharge],
	INSERTED.[NewEndTime],
	INSERTED.[ChargeTime],
	INSERTED.[ChargeMan],
	INSERTED.[PrintNumber],
	INSERTED.[HistoryID],
	INSERTED.[PrintID],
	INSERTED.[ChargeState],
	INSERTED.[ReturnGuaranteeFee],
	INSERTED.[ParentRoomFeeID],
	INSERTED.[ParentHistoryID],
	INSERTED.[IsCuiShou],
	INSERTED.[ContractID],
	INSERTED.[DiscountID]
into @table
VALUES ( 
	@ID,
	@RoomID,
	@UseCount,
	@StartTime,
	@EndTime,
	@Cost,
	@Remark,
	@AddTime,
	@IsCharged,
	@ChargeFeeID,
	@ChargeID,
	@IsStart,
	@NewStartTime,
	@ImportFeeID,
	@UnitPrice,
	@RealCost,
	@Discount,
	@OutDays,
	@ChargeFee,
	@TotalRealCost,
	@RestCost,
	@TotalDiscountCost,
	@OnlyOnceCharge,
	@NewEndTime,
	@ChargeTime,
	@ChargeMan,
	@PrintNumber,
	@PrintID,
	@ChargeState,
	@ReturnGuaranteeFee,
	@ParentRoomFeeID,
	@ParentHistoryID,
	@IsCuiShou,
	@ContractID,
	@DiscountID 
); 

SELECT 
	[ID],
	[RoomID],
	[UseCount],
	[StartTime],
	[EndTime],
	[Cost],
	[Remark],
	[AddTime],
	[IsCharged],
	[ChargeFeeID],
	[ChargeID],
	[IsStart],
	[NewStartTime],
	[ImportFeeID],
	[UnitPrice],
	[RealCost],
	[Discount],
	[OutDays],
	[ChargeFee],
	[TotalRealCost],
	[RestCost],
	[TotalDiscountCost],
	[OnlyOnceCharge],
	[NewEndTime],
	[ChargeTime],
	[ChargeMan],
	[PrintNumber],
	[HistoryID],
	[PrintID],
	[ChargeState],
	[ReturnGuaranteeFee],
	[ParentRoomFeeID],
	[ParentHistoryID],
	[IsCuiShou],
	[ContractID],
	[DiscountID] 
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
	[RoomID] int,
	[UseCount] decimal(18, 2),
	[StartTime] datetime,
	[EndTime] datetime,
	[Cost] decimal(18, 2),
	[Remark] ntext,
	[AddTime] datetime,
	[IsCharged] bit,
	[ChargeFeeID] int,
	[ChargeID] int,
	[IsStart] bit,
	[NewStartTime] datetime,
	[ImportFeeID] int,
	[UnitPrice] decimal(18, 3),
	[RealCost] decimal(18, 2),
	[Discount] decimal(18, 2),
	[OutDays] int,
	[ChargeFee] decimal(18, 2),
	[TotalRealCost] decimal(18, 2),
	[RestCost] decimal(18, 2),
	[TotalDiscountCost] decimal(18, 2),
	[OnlyOnceCharge] bit,
	[NewEndTime] datetime,
	[ChargeTime] datetime,
	[ChargeMan] nvarchar(100),
	[PrintNumber] nvarchar(200),
	[HistoryID] int,
	[PrintID] int,
	[ChargeState] int,
	[ReturnGuaranteeFee] bit,
	[ParentRoomFeeID] int,
	[ParentHistoryID] int,
	[IsCuiShou] bit,
	[ContractID] int,
	[DiscountID] int
);

UPDATE [dbo].[ContractFeeHistory] SET 
	[ContractFeeHistory].[ID] = @ID,
	[ContractFeeHistory].[RoomID] = @RoomID,
	[ContractFeeHistory].[UseCount] = @UseCount,
	[ContractFeeHistory].[StartTime] = @StartTime,
	[ContractFeeHistory].[EndTime] = @EndTime,
	[ContractFeeHistory].[Cost] = @Cost,
	[ContractFeeHistory].[Remark] = @Remark,
	[ContractFeeHistory].[AddTime] = @AddTime,
	[ContractFeeHistory].[IsCharged] = @IsCharged,
	[ContractFeeHistory].[ChargeFeeID] = @ChargeFeeID,
	[ContractFeeHistory].[ChargeID] = @ChargeID,
	[ContractFeeHistory].[IsStart] = @IsStart,
	[ContractFeeHistory].[NewStartTime] = @NewStartTime,
	[ContractFeeHistory].[ImportFeeID] = @ImportFeeID,
	[ContractFeeHistory].[UnitPrice] = @UnitPrice,
	[ContractFeeHistory].[RealCost] = @RealCost,
	[ContractFeeHistory].[Discount] = @Discount,
	[ContractFeeHistory].[OutDays] = @OutDays,
	[ContractFeeHistory].[ChargeFee] = @ChargeFee,
	[ContractFeeHistory].[TotalRealCost] = @TotalRealCost,
	[ContractFeeHistory].[RestCost] = @RestCost,
	[ContractFeeHistory].[TotalDiscountCost] = @TotalDiscountCost,
	[ContractFeeHistory].[OnlyOnceCharge] = @OnlyOnceCharge,
	[ContractFeeHistory].[NewEndTime] = @NewEndTime,
	[ContractFeeHistory].[ChargeTime] = @ChargeTime,
	[ContractFeeHistory].[ChargeMan] = @ChargeMan,
	[ContractFeeHistory].[PrintNumber] = @PrintNumber,
	[ContractFeeHistory].[PrintID] = @PrintID,
	[ContractFeeHistory].[ChargeState] = @ChargeState,
	[ContractFeeHistory].[ReturnGuaranteeFee] = @ReturnGuaranteeFee,
	[ContractFeeHistory].[ParentRoomFeeID] = @ParentRoomFeeID,
	[ContractFeeHistory].[ParentHistoryID] = @ParentHistoryID,
	[ContractFeeHistory].[IsCuiShou] = @IsCuiShou,
	[ContractFeeHistory].[ContractID] = @ContractID,
	[ContractFeeHistory].[DiscountID] = @DiscountID 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[UseCount],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[Cost],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[IsCharged],
	INSERTED.[ChargeFeeID],
	INSERTED.[ChargeID],
	INSERTED.[IsStart],
	INSERTED.[NewStartTime],
	INSERTED.[ImportFeeID],
	INSERTED.[UnitPrice],
	INSERTED.[RealCost],
	INSERTED.[Discount],
	INSERTED.[OutDays],
	INSERTED.[ChargeFee],
	INSERTED.[TotalRealCost],
	INSERTED.[RestCost],
	INSERTED.[TotalDiscountCost],
	INSERTED.[OnlyOnceCharge],
	INSERTED.[NewEndTime],
	INSERTED.[ChargeTime],
	INSERTED.[ChargeMan],
	INSERTED.[PrintNumber],
	INSERTED.[HistoryID],
	INSERTED.[PrintID],
	INSERTED.[ChargeState],
	INSERTED.[ReturnGuaranteeFee],
	INSERTED.[ParentRoomFeeID],
	INSERTED.[ParentHistoryID],
	INSERTED.[IsCuiShou],
	INSERTED.[ContractID],
	INSERTED.[DiscountID]
into @table
WHERE 
	[ContractFeeHistory].[HistoryID] = @HistoryID

SELECT 
	[ID],
	[RoomID],
	[UseCount],
	[StartTime],
	[EndTime],
	[Cost],
	[Remark],
	[AddTime],
	[IsCharged],
	[ChargeFeeID],
	[ChargeID],
	[IsStart],
	[NewStartTime],
	[ImportFeeID],
	[UnitPrice],
	[RealCost],
	[Discount],
	[OutDays],
	[ChargeFee],
	[TotalRealCost],
	[RestCost],
	[TotalDiscountCost],
	[OnlyOnceCharge],
	[NewEndTime],
	[ChargeTime],
	[ChargeMan],
	[PrintNumber],
	[HistoryID],
	[PrintID],
	[ChargeState],
	[ReturnGuaranteeFee],
	[ParentRoomFeeID],
	[ParentHistoryID],
	[IsCuiShou],
	[ContractID],
	[DiscountID] 
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
DELETE FROM [dbo].[ContractFeeHistory]
WHERE 
	[ContractFeeHistory].[HistoryID] = @HistoryID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ContractFeeHistory() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetContractFeeHistory(this.HistoryID));
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
	[ContractFeeHistory].[ID],
	[ContractFeeHistory].[RoomID],
	[ContractFeeHistory].[UseCount],
	[ContractFeeHistory].[StartTime],
	[ContractFeeHistory].[EndTime],
	[ContractFeeHistory].[Cost],
	[ContractFeeHistory].[Remark],
	[ContractFeeHistory].[AddTime],
	[ContractFeeHistory].[IsCharged],
	[ContractFeeHistory].[ChargeFeeID],
	[ContractFeeHistory].[ChargeID],
	[ContractFeeHistory].[IsStart],
	[ContractFeeHistory].[NewStartTime],
	[ContractFeeHistory].[ImportFeeID],
	[ContractFeeHistory].[UnitPrice],
	[ContractFeeHistory].[RealCost],
	[ContractFeeHistory].[Discount],
	[ContractFeeHistory].[OutDays],
	[ContractFeeHistory].[ChargeFee],
	[ContractFeeHistory].[TotalRealCost],
	[ContractFeeHistory].[RestCost],
	[ContractFeeHistory].[TotalDiscountCost],
	[ContractFeeHistory].[OnlyOnceCharge],
	[ContractFeeHistory].[NewEndTime],
	[ContractFeeHistory].[ChargeTime],
	[ContractFeeHistory].[ChargeMan],
	[ContractFeeHistory].[PrintNumber],
	[ContractFeeHistory].[HistoryID],
	[ContractFeeHistory].[PrintID],
	[ContractFeeHistory].[ChargeState],
	[ContractFeeHistory].[ReturnGuaranteeFee],
	[ContractFeeHistory].[ParentRoomFeeID],
	[ContractFeeHistory].[ParentHistoryID],
	[ContractFeeHistory].[IsCuiShou],
	[ContractFeeHistory].[ContractID],
	[ContractFeeHistory].[DiscountID]
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
                return "ContractFeeHistory";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ContractFeeHistory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="useCount">useCount</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="cost">cost</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isCharged">isCharged</param>
		/// <param name="chargeFeeID">chargeFeeID</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="isStart">isStart</param>
		/// <param name="newStartTime">newStartTime</param>
		/// <param name="importFeeID">importFeeID</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="realCost">realCost</param>
		/// <param name="discount">discount</param>
		/// <param name="outDays">outDays</param>
		/// <param name="chargeFee">chargeFee</param>
		/// <param name="totalRealCost">totalRealCost</param>
		/// <param name="restCost">restCost</param>
		/// <param name="totalDiscountCost">totalDiscountCost</param>
		/// <param name="onlyOnceCharge">onlyOnceCharge</param>
		/// <param name="newEndTime">newEndTime</param>
		/// <param name="chargeTime">chargeTime</param>
		/// <param name="chargeMan">chargeMan</param>
		/// <param name="printNumber">printNumber</param>
		/// <param name="printID">printID</param>
		/// <param name="chargeState">chargeState</param>
		/// <param name="returnGuaranteeFee">returnGuaranteeFee</param>
		/// <param name="parentRoomFeeID">parentRoomFeeID</param>
		/// <param name="parentHistoryID">parentHistoryID</param>
		/// <param name="isCuiShou">isCuiShou</param>
		/// <param name="contractID">contractID</param>
		/// <param name="discountID">discountID</param>
		public static void InsertContractFeeHistory(int @iD, int @roomID, decimal @useCount, DateTime @startTime, DateTime @endTime, decimal @cost, string @remark, DateTime @addTime, bool @isCharged, int @chargeFeeID, int @chargeID, bool @isStart, DateTime @newStartTime, int @importFeeID, decimal @unitPrice, decimal @realCost, decimal @discount, int @outDays, decimal @chargeFee, decimal @totalRealCost, decimal @restCost, decimal @totalDiscountCost, bool @onlyOnceCharge, DateTime @newEndTime, DateTime @chargeTime, string @chargeMan, string @printNumber, int @printID, int @chargeState, bool @returnGuaranteeFee, int @parentRoomFeeID, int @parentHistoryID, bool @isCuiShou, int @contractID, int @discountID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertContractFeeHistory(@iD, @roomID, @useCount, @startTime, @endTime, @cost, @remark, @addTime, @isCharged, @chargeFeeID, @chargeID, @isStart, @newStartTime, @importFeeID, @unitPrice, @realCost, @discount, @outDays, @chargeFee, @totalRealCost, @restCost, @totalDiscountCost, @onlyOnceCharge, @newEndTime, @chargeTime, @chargeMan, @printNumber, @printID, @chargeState, @returnGuaranteeFee, @parentRoomFeeID, @parentHistoryID, @isCuiShou, @contractID, @discountID, helper);
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
		/// Insert a ContractFeeHistory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="useCount">useCount</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="cost">cost</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isCharged">isCharged</param>
		/// <param name="chargeFeeID">chargeFeeID</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="isStart">isStart</param>
		/// <param name="newStartTime">newStartTime</param>
		/// <param name="importFeeID">importFeeID</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="realCost">realCost</param>
		/// <param name="discount">discount</param>
		/// <param name="outDays">outDays</param>
		/// <param name="chargeFee">chargeFee</param>
		/// <param name="totalRealCost">totalRealCost</param>
		/// <param name="restCost">restCost</param>
		/// <param name="totalDiscountCost">totalDiscountCost</param>
		/// <param name="onlyOnceCharge">onlyOnceCharge</param>
		/// <param name="newEndTime">newEndTime</param>
		/// <param name="chargeTime">chargeTime</param>
		/// <param name="chargeMan">chargeMan</param>
		/// <param name="printNumber">printNumber</param>
		/// <param name="printID">printID</param>
		/// <param name="chargeState">chargeState</param>
		/// <param name="returnGuaranteeFee">returnGuaranteeFee</param>
		/// <param name="parentRoomFeeID">parentRoomFeeID</param>
		/// <param name="parentHistoryID">parentHistoryID</param>
		/// <param name="isCuiShou">isCuiShou</param>
		/// <param name="contractID">contractID</param>
		/// <param name="discountID">discountID</param>
		/// <param name="helper">helper</param>
		internal static void InsertContractFeeHistory(int @iD, int @roomID, decimal @useCount, DateTime @startTime, DateTime @endTime, decimal @cost, string @remark, DateTime @addTime, bool @isCharged, int @chargeFeeID, int @chargeID, bool @isStart, DateTime @newStartTime, int @importFeeID, decimal @unitPrice, decimal @realCost, decimal @discount, int @outDays, decimal @chargeFee, decimal @totalRealCost, decimal @restCost, decimal @totalDiscountCost, bool @onlyOnceCharge, DateTime @newEndTime, DateTime @chargeTime, string @chargeMan, string @printNumber, int @printID, int @chargeState, bool @returnGuaranteeFee, int @parentRoomFeeID, int @parentHistoryID, bool @isCuiShou, int @contractID, int @discountID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[UseCount] decimal(18, 2),
	[StartTime] datetime,
	[EndTime] datetime,
	[Cost] decimal(18, 2),
	[Remark] ntext,
	[AddTime] datetime,
	[IsCharged] bit,
	[ChargeFeeID] int,
	[ChargeID] int,
	[IsStart] bit,
	[NewStartTime] datetime,
	[ImportFeeID] int,
	[UnitPrice] decimal(18, 3),
	[RealCost] decimal(18, 2),
	[Discount] decimal(18, 2),
	[OutDays] int,
	[ChargeFee] decimal(18, 2),
	[TotalRealCost] decimal(18, 2),
	[RestCost] decimal(18, 2),
	[TotalDiscountCost] decimal(18, 2),
	[OnlyOnceCharge] bit,
	[NewEndTime] datetime,
	[ChargeTime] datetime,
	[ChargeMan] nvarchar(100),
	[PrintNumber] nvarchar(200),
	[HistoryID] int,
	[PrintID] int,
	[ChargeState] int,
	[ReturnGuaranteeFee] bit,
	[ParentRoomFeeID] int,
	[ParentHistoryID] int,
	[IsCuiShou] bit,
	[ContractID] int,
	[DiscountID] int
);

INSERT INTO [dbo].[ContractFeeHistory] (
	[ContractFeeHistory].[ID],
	[ContractFeeHistory].[RoomID],
	[ContractFeeHistory].[UseCount],
	[ContractFeeHistory].[StartTime],
	[ContractFeeHistory].[EndTime],
	[ContractFeeHistory].[Cost],
	[ContractFeeHistory].[Remark],
	[ContractFeeHistory].[AddTime],
	[ContractFeeHistory].[IsCharged],
	[ContractFeeHistory].[ChargeFeeID],
	[ContractFeeHistory].[ChargeID],
	[ContractFeeHistory].[IsStart],
	[ContractFeeHistory].[NewStartTime],
	[ContractFeeHistory].[ImportFeeID],
	[ContractFeeHistory].[UnitPrice],
	[ContractFeeHistory].[RealCost],
	[ContractFeeHistory].[Discount],
	[ContractFeeHistory].[OutDays],
	[ContractFeeHistory].[ChargeFee],
	[ContractFeeHistory].[TotalRealCost],
	[ContractFeeHistory].[RestCost],
	[ContractFeeHistory].[TotalDiscountCost],
	[ContractFeeHistory].[OnlyOnceCharge],
	[ContractFeeHistory].[NewEndTime],
	[ContractFeeHistory].[ChargeTime],
	[ContractFeeHistory].[ChargeMan],
	[ContractFeeHistory].[PrintNumber],
	[ContractFeeHistory].[PrintID],
	[ContractFeeHistory].[ChargeState],
	[ContractFeeHistory].[ReturnGuaranteeFee],
	[ContractFeeHistory].[ParentRoomFeeID],
	[ContractFeeHistory].[ParentHistoryID],
	[ContractFeeHistory].[IsCuiShou],
	[ContractFeeHistory].[ContractID],
	[ContractFeeHistory].[DiscountID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[UseCount],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[Cost],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[IsCharged],
	INSERTED.[ChargeFeeID],
	INSERTED.[ChargeID],
	INSERTED.[IsStart],
	INSERTED.[NewStartTime],
	INSERTED.[ImportFeeID],
	INSERTED.[UnitPrice],
	INSERTED.[RealCost],
	INSERTED.[Discount],
	INSERTED.[OutDays],
	INSERTED.[ChargeFee],
	INSERTED.[TotalRealCost],
	INSERTED.[RestCost],
	INSERTED.[TotalDiscountCost],
	INSERTED.[OnlyOnceCharge],
	INSERTED.[NewEndTime],
	INSERTED.[ChargeTime],
	INSERTED.[ChargeMan],
	INSERTED.[PrintNumber],
	INSERTED.[HistoryID],
	INSERTED.[PrintID],
	INSERTED.[ChargeState],
	INSERTED.[ReturnGuaranteeFee],
	INSERTED.[ParentRoomFeeID],
	INSERTED.[ParentHistoryID],
	INSERTED.[IsCuiShou],
	INSERTED.[ContractID],
	INSERTED.[DiscountID]
into @table
VALUES ( 
	@ID,
	@RoomID,
	@UseCount,
	@StartTime,
	@EndTime,
	@Cost,
	@Remark,
	@AddTime,
	@IsCharged,
	@ChargeFeeID,
	@ChargeID,
	@IsStart,
	@NewStartTime,
	@ImportFeeID,
	@UnitPrice,
	@RealCost,
	@Discount,
	@OutDays,
	@ChargeFee,
	@TotalRealCost,
	@RestCost,
	@TotalDiscountCost,
	@OnlyOnceCharge,
	@NewEndTime,
	@ChargeTime,
	@ChargeMan,
	@PrintNumber,
	@PrintID,
	@ChargeState,
	@ReturnGuaranteeFee,
	@ParentRoomFeeID,
	@ParentHistoryID,
	@IsCuiShou,
	@ContractID,
	@DiscountID 
); 

SELECT 
	[ID],
	[RoomID],
	[UseCount],
	[StartTime],
	[EndTime],
	[Cost],
	[Remark],
	[AddTime],
	[IsCharged],
	[ChargeFeeID],
	[ChargeID],
	[IsStart],
	[NewStartTime],
	[ImportFeeID],
	[UnitPrice],
	[RealCost],
	[Discount],
	[OutDays],
	[ChargeFee],
	[TotalRealCost],
	[RestCost],
	[TotalDiscountCost],
	[OnlyOnceCharge],
	[NewEndTime],
	[ChargeTime],
	[ChargeMan],
	[PrintNumber],
	[HistoryID],
	[PrintID],
	[ChargeState],
	[ReturnGuaranteeFee],
	[ParentRoomFeeID],
	[ParentHistoryID],
	[IsCuiShou],
	[ContractID],
	[DiscountID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@UseCount", EntityBase.GetDatabaseValue(@useCount)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@Cost", EntityBase.GetDatabaseValue(@cost)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@IsCharged", @isCharged));
			parameters.Add(new SqlParameter("@ChargeFeeID", EntityBase.GetDatabaseValue(@chargeFeeID)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@IsStart", @isStart));
			parameters.Add(new SqlParameter("@NewStartTime", EntityBase.GetDatabaseValue(@newStartTime)));
			parameters.Add(new SqlParameter("@ImportFeeID", EntityBase.GetDatabaseValue(@importFeeID)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@RealCost", EntityBase.GetDatabaseValue(@realCost)));
			parameters.Add(new SqlParameter("@Discount", EntityBase.GetDatabaseValue(@discount)));
			parameters.Add(new SqlParameter("@OutDays", EntityBase.GetDatabaseValue(@outDays)));
			parameters.Add(new SqlParameter("@ChargeFee", EntityBase.GetDatabaseValue(@chargeFee)));
			parameters.Add(new SqlParameter("@TotalRealCost", EntityBase.GetDatabaseValue(@totalRealCost)));
			parameters.Add(new SqlParameter("@RestCost", EntityBase.GetDatabaseValue(@restCost)));
			parameters.Add(new SqlParameter("@TotalDiscountCost", EntityBase.GetDatabaseValue(@totalDiscountCost)));
			parameters.Add(new SqlParameter("@OnlyOnceCharge", @onlyOnceCharge));
			parameters.Add(new SqlParameter("@NewEndTime", EntityBase.GetDatabaseValue(@newEndTime)));
			parameters.Add(new SqlParameter("@ChargeTime", EntityBase.GetDatabaseValue(@chargeTime)));
			parameters.Add(new SqlParameter("@ChargeMan", EntityBase.GetDatabaseValue(@chargeMan)));
			parameters.Add(new SqlParameter("@PrintNumber", EntityBase.GetDatabaseValue(@printNumber)));
			parameters.Add(new SqlParameter("@PrintID", EntityBase.GetDatabaseValue(@printID)));
			parameters.Add(new SqlParameter("@ChargeState", EntityBase.GetDatabaseValue(@chargeState)));
			parameters.Add(new SqlParameter("@ReturnGuaranteeFee", @returnGuaranteeFee));
			parameters.Add(new SqlParameter("@ParentRoomFeeID", EntityBase.GetDatabaseValue(@parentRoomFeeID)));
			parameters.Add(new SqlParameter("@ParentHistoryID", EntityBase.GetDatabaseValue(@parentHistoryID)));
			parameters.Add(new SqlParameter("@IsCuiShou", @isCuiShou));
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@DiscountID", EntityBase.GetDatabaseValue(@discountID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ContractFeeHistory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="useCount">useCount</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="cost">cost</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isCharged">isCharged</param>
		/// <param name="chargeFeeID">chargeFeeID</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="isStart">isStart</param>
		/// <param name="newStartTime">newStartTime</param>
		/// <param name="importFeeID">importFeeID</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="realCost">realCost</param>
		/// <param name="discount">discount</param>
		/// <param name="outDays">outDays</param>
		/// <param name="chargeFee">chargeFee</param>
		/// <param name="totalRealCost">totalRealCost</param>
		/// <param name="restCost">restCost</param>
		/// <param name="totalDiscountCost">totalDiscountCost</param>
		/// <param name="onlyOnceCharge">onlyOnceCharge</param>
		/// <param name="newEndTime">newEndTime</param>
		/// <param name="chargeTime">chargeTime</param>
		/// <param name="chargeMan">chargeMan</param>
		/// <param name="printNumber">printNumber</param>
		/// <param name="historyID">historyID</param>
		/// <param name="printID">printID</param>
		/// <param name="chargeState">chargeState</param>
		/// <param name="returnGuaranteeFee">returnGuaranteeFee</param>
		/// <param name="parentRoomFeeID">parentRoomFeeID</param>
		/// <param name="parentHistoryID">parentHistoryID</param>
		/// <param name="isCuiShou">isCuiShou</param>
		/// <param name="contractID">contractID</param>
		/// <param name="discountID">discountID</param>
		public static void UpdateContractFeeHistory(int @iD, int @roomID, decimal @useCount, DateTime @startTime, DateTime @endTime, decimal @cost, string @remark, DateTime @addTime, bool @isCharged, int @chargeFeeID, int @chargeID, bool @isStart, DateTime @newStartTime, int @importFeeID, decimal @unitPrice, decimal @realCost, decimal @discount, int @outDays, decimal @chargeFee, decimal @totalRealCost, decimal @restCost, decimal @totalDiscountCost, bool @onlyOnceCharge, DateTime @newEndTime, DateTime @chargeTime, string @chargeMan, string @printNumber, int @historyID, int @printID, int @chargeState, bool @returnGuaranteeFee, int @parentRoomFeeID, int @parentHistoryID, bool @isCuiShou, int @contractID, int @discountID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateContractFeeHistory(@iD, @roomID, @useCount, @startTime, @endTime, @cost, @remark, @addTime, @isCharged, @chargeFeeID, @chargeID, @isStart, @newStartTime, @importFeeID, @unitPrice, @realCost, @discount, @outDays, @chargeFee, @totalRealCost, @restCost, @totalDiscountCost, @onlyOnceCharge, @newEndTime, @chargeTime, @chargeMan, @printNumber, @historyID, @printID, @chargeState, @returnGuaranteeFee, @parentRoomFeeID, @parentHistoryID, @isCuiShou, @contractID, @discountID, helper);
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
		/// Updates a ContractFeeHistory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="useCount">useCount</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="cost">cost</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isCharged">isCharged</param>
		/// <param name="chargeFeeID">chargeFeeID</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="isStart">isStart</param>
		/// <param name="newStartTime">newStartTime</param>
		/// <param name="importFeeID">importFeeID</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="realCost">realCost</param>
		/// <param name="discount">discount</param>
		/// <param name="outDays">outDays</param>
		/// <param name="chargeFee">chargeFee</param>
		/// <param name="totalRealCost">totalRealCost</param>
		/// <param name="restCost">restCost</param>
		/// <param name="totalDiscountCost">totalDiscountCost</param>
		/// <param name="onlyOnceCharge">onlyOnceCharge</param>
		/// <param name="newEndTime">newEndTime</param>
		/// <param name="chargeTime">chargeTime</param>
		/// <param name="chargeMan">chargeMan</param>
		/// <param name="printNumber">printNumber</param>
		/// <param name="historyID">historyID</param>
		/// <param name="printID">printID</param>
		/// <param name="chargeState">chargeState</param>
		/// <param name="returnGuaranteeFee">returnGuaranteeFee</param>
		/// <param name="parentRoomFeeID">parentRoomFeeID</param>
		/// <param name="parentHistoryID">parentHistoryID</param>
		/// <param name="isCuiShou">isCuiShou</param>
		/// <param name="contractID">contractID</param>
		/// <param name="discountID">discountID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateContractFeeHistory(int @iD, int @roomID, decimal @useCount, DateTime @startTime, DateTime @endTime, decimal @cost, string @remark, DateTime @addTime, bool @isCharged, int @chargeFeeID, int @chargeID, bool @isStart, DateTime @newStartTime, int @importFeeID, decimal @unitPrice, decimal @realCost, decimal @discount, int @outDays, decimal @chargeFee, decimal @totalRealCost, decimal @restCost, decimal @totalDiscountCost, bool @onlyOnceCharge, DateTime @newEndTime, DateTime @chargeTime, string @chargeMan, string @printNumber, int @historyID, int @printID, int @chargeState, bool @returnGuaranteeFee, int @parentRoomFeeID, int @parentHistoryID, bool @isCuiShou, int @contractID, int @discountID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[UseCount] decimal(18, 2),
	[StartTime] datetime,
	[EndTime] datetime,
	[Cost] decimal(18, 2),
	[Remark] ntext,
	[AddTime] datetime,
	[IsCharged] bit,
	[ChargeFeeID] int,
	[ChargeID] int,
	[IsStart] bit,
	[NewStartTime] datetime,
	[ImportFeeID] int,
	[UnitPrice] decimal(18, 3),
	[RealCost] decimal(18, 2),
	[Discount] decimal(18, 2),
	[OutDays] int,
	[ChargeFee] decimal(18, 2),
	[TotalRealCost] decimal(18, 2),
	[RestCost] decimal(18, 2),
	[TotalDiscountCost] decimal(18, 2),
	[OnlyOnceCharge] bit,
	[NewEndTime] datetime,
	[ChargeTime] datetime,
	[ChargeMan] nvarchar(100),
	[PrintNumber] nvarchar(200),
	[HistoryID] int,
	[PrintID] int,
	[ChargeState] int,
	[ReturnGuaranteeFee] bit,
	[ParentRoomFeeID] int,
	[ParentHistoryID] int,
	[IsCuiShou] bit,
	[ContractID] int,
	[DiscountID] int
);

UPDATE [dbo].[ContractFeeHistory] SET 
	[ContractFeeHistory].[ID] = @ID,
	[ContractFeeHistory].[RoomID] = @RoomID,
	[ContractFeeHistory].[UseCount] = @UseCount,
	[ContractFeeHistory].[StartTime] = @StartTime,
	[ContractFeeHistory].[EndTime] = @EndTime,
	[ContractFeeHistory].[Cost] = @Cost,
	[ContractFeeHistory].[Remark] = @Remark,
	[ContractFeeHistory].[AddTime] = @AddTime,
	[ContractFeeHistory].[IsCharged] = @IsCharged,
	[ContractFeeHistory].[ChargeFeeID] = @ChargeFeeID,
	[ContractFeeHistory].[ChargeID] = @ChargeID,
	[ContractFeeHistory].[IsStart] = @IsStart,
	[ContractFeeHistory].[NewStartTime] = @NewStartTime,
	[ContractFeeHistory].[ImportFeeID] = @ImportFeeID,
	[ContractFeeHistory].[UnitPrice] = @UnitPrice,
	[ContractFeeHistory].[RealCost] = @RealCost,
	[ContractFeeHistory].[Discount] = @Discount,
	[ContractFeeHistory].[OutDays] = @OutDays,
	[ContractFeeHistory].[ChargeFee] = @ChargeFee,
	[ContractFeeHistory].[TotalRealCost] = @TotalRealCost,
	[ContractFeeHistory].[RestCost] = @RestCost,
	[ContractFeeHistory].[TotalDiscountCost] = @TotalDiscountCost,
	[ContractFeeHistory].[OnlyOnceCharge] = @OnlyOnceCharge,
	[ContractFeeHistory].[NewEndTime] = @NewEndTime,
	[ContractFeeHistory].[ChargeTime] = @ChargeTime,
	[ContractFeeHistory].[ChargeMan] = @ChargeMan,
	[ContractFeeHistory].[PrintNumber] = @PrintNumber,
	[ContractFeeHistory].[PrintID] = @PrintID,
	[ContractFeeHistory].[ChargeState] = @ChargeState,
	[ContractFeeHistory].[ReturnGuaranteeFee] = @ReturnGuaranteeFee,
	[ContractFeeHistory].[ParentRoomFeeID] = @ParentRoomFeeID,
	[ContractFeeHistory].[ParentHistoryID] = @ParentHistoryID,
	[ContractFeeHistory].[IsCuiShou] = @IsCuiShou,
	[ContractFeeHistory].[ContractID] = @ContractID,
	[ContractFeeHistory].[DiscountID] = @DiscountID 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[UseCount],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[Cost],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[IsCharged],
	INSERTED.[ChargeFeeID],
	INSERTED.[ChargeID],
	INSERTED.[IsStart],
	INSERTED.[NewStartTime],
	INSERTED.[ImportFeeID],
	INSERTED.[UnitPrice],
	INSERTED.[RealCost],
	INSERTED.[Discount],
	INSERTED.[OutDays],
	INSERTED.[ChargeFee],
	INSERTED.[TotalRealCost],
	INSERTED.[RestCost],
	INSERTED.[TotalDiscountCost],
	INSERTED.[OnlyOnceCharge],
	INSERTED.[NewEndTime],
	INSERTED.[ChargeTime],
	INSERTED.[ChargeMan],
	INSERTED.[PrintNumber],
	INSERTED.[HistoryID],
	INSERTED.[PrintID],
	INSERTED.[ChargeState],
	INSERTED.[ReturnGuaranteeFee],
	INSERTED.[ParentRoomFeeID],
	INSERTED.[ParentHistoryID],
	INSERTED.[IsCuiShou],
	INSERTED.[ContractID],
	INSERTED.[DiscountID]
into @table
WHERE 
	[ContractFeeHistory].[HistoryID] = @HistoryID

SELECT 
	[ID],
	[RoomID],
	[UseCount],
	[StartTime],
	[EndTime],
	[Cost],
	[Remark],
	[AddTime],
	[IsCharged],
	[ChargeFeeID],
	[ChargeID],
	[IsStart],
	[NewStartTime],
	[ImportFeeID],
	[UnitPrice],
	[RealCost],
	[Discount],
	[OutDays],
	[ChargeFee],
	[TotalRealCost],
	[RestCost],
	[TotalDiscountCost],
	[OnlyOnceCharge],
	[NewEndTime],
	[ChargeTime],
	[ChargeMan],
	[PrintNumber],
	[HistoryID],
	[PrintID],
	[ChargeState],
	[ReturnGuaranteeFee],
	[ParentRoomFeeID],
	[ParentHistoryID],
	[IsCuiShou],
	[ContractID],
	[DiscountID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@UseCount", EntityBase.GetDatabaseValue(@useCount)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@Cost", EntityBase.GetDatabaseValue(@cost)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@IsCharged", @isCharged));
			parameters.Add(new SqlParameter("@ChargeFeeID", EntityBase.GetDatabaseValue(@chargeFeeID)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@IsStart", @isStart));
			parameters.Add(new SqlParameter("@NewStartTime", EntityBase.GetDatabaseValue(@newStartTime)));
			parameters.Add(new SqlParameter("@ImportFeeID", EntityBase.GetDatabaseValue(@importFeeID)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@RealCost", EntityBase.GetDatabaseValue(@realCost)));
			parameters.Add(new SqlParameter("@Discount", EntityBase.GetDatabaseValue(@discount)));
			parameters.Add(new SqlParameter("@OutDays", EntityBase.GetDatabaseValue(@outDays)));
			parameters.Add(new SqlParameter("@ChargeFee", EntityBase.GetDatabaseValue(@chargeFee)));
			parameters.Add(new SqlParameter("@TotalRealCost", EntityBase.GetDatabaseValue(@totalRealCost)));
			parameters.Add(new SqlParameter("@RestCost", EntityBase.GetDatabaseValue(@restCost)));
			parameters.Add(new SqlParameter("@TotalDiscountCost", EntityBase.GetDatabaseValue(@totalDiscountCost)));
			parameters.Add(new SqlParameter("@OnlyOnceCharge", @onlyOnceCharge));
			parameters.Add(new SqlParameter("@NewEndTime", EntityBase.GetDatabaseValue(@newEndTime)));
			parameters.Add(new SqlParameter("@ChargeTime", EntityBase.GetDatabaseValue(@chargeTime)));
			parameters.Add(new SqlParameter("@ChargeMan", EntityBase.GetDatabaseValue(@chargeMan)));
			parameters.Add(new SqlParameter("@PrintNumber", EntityBase.GetDatabaseValue(@printNumber)));
			parameters.Add(new SqlParameter("@HistoryID", EntityBase.GetDatabaseValue(@historyID)));
			parameters.Add(new SqlParameter("@PrintID", EntityBase.GetDatabaseValue(@printID)));
			parameters.Add(new SqlParameter("@ChargeState", EntityBase.GetDatabaseValue(@chargeState)));
			parameters.Add(new SqlParameter("@ReturnGuaranteeFee", @returnGuaranteeFee));
			parameters.Add(new SqlParameter("@ParentRoomFeeID", EntityBase.GetDatabaseValue(@parentRoomFeeID)));
			parameters.Add(new SqlParameter("@ParentHistoryID", EntityBase.GetDatabaseValue(@parentHistoryID)));
			parameters.Add(new SqlParameter("@IsCuiShou", @isCuiShou));
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@DiscountID", EntityBase.GetDatabaseValue(@discountID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ContractFeeHistory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="historyID">historyID</param>
		public static void DeleteContractFeeHistory(int @historyID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteContractFeeHistory(@historyID, helper);
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
		/// Deletes a ContractFeeHistory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="historyID">historyID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteContractFeeHistory(int @historyID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ContractFeeHistory]
WHERE 
	[ContractFeeHistory].[HistoryID] = @HistoryID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@HistoryID", @historyID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ContractFeeHistory object.
		/// </summary>
		/// <returns>The newly created ContractFeeHistory object.</returns>
		public static ContractFeeHistory CreateContractFeeHistory()
		{
			return InitializeNew<ContractFeeHistory>();
		}
		
		/// <summary>
		/// Retrieve information for a ContractFeeHistory by a ContractFeeHistory's unique identifier.
		/// </summary>
		/// <param name="historyID">historyID</param>
		/// <returns>ContractFeeHistory</returns>
		public static ContractFeeHistory GetContractFeeHistory(int @historyID)
		{
			string commandText = @"
SELECT 
" + ContractFeeHistory.SelectFieldList + @"
FROM [dbo].[ContractFeeHistory] 
WHERE 
	[ContractFeeHistory].[HistoryID] = @HistoryID " + ContractFeeHistory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@HistoryID", @historyID));
			
			return GetOne<ContractFeeHistory>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ContractFeeHistory by a ContractFeeHistory's unique identifier.
		/// </summary>
		/// <param name="historyID">historyID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ContractFeeHistory</returns>
		public static ContractFeeHistory GetContractFeeHistory(int @historyID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ContractFeeHistory.SelectFieldList + @"
FROM [dbo].[ContractFeeHistory] 
WHERE 
	[ContractFeeHistory].[HistoryID] = @HistoryID " + ContractFeeHistory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@HistoryID", @historyID));
			
			return GetOne<ContractFeeHistory>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ContractFeeHistory objects.
		/// </summary>
		/// <returns>The retrieved collection of ContractFeeHistory objects.</returns>
		public static EntityList<ContractFeeHistory> GetContractFeeHistories()
		{
			string commandText = @"
SELECT " + ContractFeeHistory.SelectFieldList + "FROM [dbo].[ContractFeeHistory] " + ContractFeeHistory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ContractFeeHistory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ContractFeeHistory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ContractFeeHistory objects.</returns>
        public static EntityList<ContractFeeHistory> GetContractFeeHistories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ContractFeeHistory>(SelectFieldList, "FROM [dbo].[ContractFeeHistory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ContractFeeHistory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ContractFeeHistory objects.</returns>
        public static EntityList<ContractFeeHistory> GetContractFeeHistories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ContractFeeHistory>(SelectFieldList, "FROM [dbo].[ContractFeeHistory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ContractFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ContractFeeHistory objects.</returns>
		protected static EntityList<ContractFeeHistory> GetContractFeeHistories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContractFeeHistories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ContractFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ContractFeeHistory objects.</returns>
		protected static EntityList<ContractFeeHistory> GetContractFeeHistories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContractFeeHistories(string.Empty, where, parameters, ContractFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ContractFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ContractFeeHistory objects.</returns>
		protected static EntityList<ContractFeeHistory> GetContractFeeHistories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContractFeeHistories(prefix, where, parameters, ContractFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ContractFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ContractFeeHistory objects.</returns>
		protected static EntityList<ContractFeeHistory> GetContractFeeHistories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContractFeeHistories(string.Empty, where, parameters, ContractFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ContractFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ContractFeeHistory objects.</returns>
		protected static EntityList<ContractFeeHistory> GetContractFeeHistories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContractFeeHistories(prefix, where, parameters, ContractFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ContractFeeHistory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ContractFeeHistory objects.</returns>
		protected static EntityList<ContractFeeHistory> GetContractFeeHistories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ContractFeeHistory.SelectFieldList + "FROM [dbo].[ContractFeeHistory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ContractFeeHistory>(reader);
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
        protected static EntityList<ContractFeeHistory> GetContractFeeHistories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ContractFeeHistory>(SelectFieldList, "FROM [dbo].[ContractFeeHistory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ContractFeeHistory objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContractFeeHistoryCount()
        {
            return GetContractFeeHistoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ContractFeeHistory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContractFeeHistoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ContractFeeHistory] " + where;

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
		public static partial class ContractFeeHistory_Properties
		{
			public const string ID = "ID";
			public const string RoomID = "RoomID";
			public const string UseCount = "UseCount";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string Cost = "Cost";
			public const string Remark = "Remark";
			public const string AddTime = "AddTime";
			public const string IsCharged = "IsCharged";
			public const string ChargeFeeID = "ChargeFeeID";
			public const string ChargeID = "ChargeID";
			public const string IsStart = "IsStart";
			public const string NewStartTime = "NewStartTime";
			public const string ImportFeeID = "ImportFeeID";
			public const string UnitPrice = "UnitPrice";
			public const string RealCost = "RealCost";
			public const string Discount = "Discount";
			public const string OutDays = "OutDays";
			public const string ChargeFee = "ChargeFee";
			public const string TotalRealCost = "TotalRealCost";
			public const string RestCost = "RestCost";
			public const string TotalDiscountCost = "TotalDiscountCost";
			public const string OnlyOnceCharge = "OnlyOnceCharge";
			public const string NewEndTime = "NewEndTime";
			public const string ChargeTime = "ChargeTime";
			public const string ChargeMan = "ChargeMan";
			public const string PrintNumber = "PrintNumber";
			public const string HistoryID = "HistoryID";
			public const string PrintID = "PrintID";
			public const string ChargeState = "ChargeState";
			public const string ReturnGuaranteeFee = "ReturnGuaranteeFee";
			public const string ParentRoomFeeID = "ParentRoomFeeID";
			public const string ParentHistoryID = "ParentHistoryID";
			public const string IsCuiShou = "IsCuiShou";
			public const string ContractID = "ContractID";
			public const string DiscountID = "DiscountID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"UseCount" , "decimal:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"Cost" , "decimal:"},
    			 {"Remark" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"IsCharged" , "bool:"},
    			 {"ChargeFeeID" , "int:"},
    			 {"ChargeID" , "int:"},
    			 {"IsStart" , "bool:"},
    			 {"NewStartTime" , "DateTime:"},
    			 {"ImportFeeID" , "int:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"RealCost" , "decimal:"},
    			 {"Discount" , "decimal:"},
    			 {"OutDays" , "int:"},
    			 {"ChargeFee" , "decimal:"},
    			 {"TotalRealCost" , "decimal:"},
    			 {"RestCost" , "decimal:"},
    			 {"TotalDiscountCost" , "decimal:"},
    			 {"OnlyOnceCharge" , "bool:"},
    			 {"NewEndTime" , "DateTime:"},
    			 {"ChargeTime" , "DateTime:"},
    			 {"ChargeMan" , "string:"},
    			 {"PrintNumber" , "string:"},
    			 {"HistoryID" , "int:"},
    			 {"PrintID" , "int:"},
    			 {"ChargeState" , "int:"},
    			 {"ReturnGuaranteeFee" , "bool:"},
    			 {"ParentRoomFeeID" , "int:"},
    			 {"ParentHistoryID" , "int:"},
    			 {"IsCuiShou" , "bool:"},
    			 {"ContractID" , "int:"},
    			 {"DiscountID" , "int:"},
            };
		}
		#endregion
	}
}
