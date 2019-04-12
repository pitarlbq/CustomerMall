using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Foresight.DataAccess.Framework;


namespace Foresight.DataAccess
{
	/// <summary>
	/// This object represents the properties and methods of a ViewContractFeeHistory.
	/// </summary>
	[Serializable()]
	public partial class ViewContractFeeHistory 
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
            protected set { this._iD = value;}
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
            protected set { this._roomID = value;}
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
            protected set { this._useCount = value;}
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
            protected set { this._startTime = value;}
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
            protected set { this._endTime = value;}
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
            protected set { this._cost = value;}
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
            protected set { this._remark = value;}
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
            protected set { this._addTime = value;}
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
            protected set { this._isCharged = value;}
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
            protected set { this._chargeFeeID = value;}
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
            protected set { this._chargeID = value;}
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
            protected set { this._isStart = value;}
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
            protected set { this._newStartTime = value;}
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
            protected set { this._importFeeID = value;}
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
            protected set { this._unitPrice = value;}
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
            protected set { this._realCost = value;}
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
            protected set { this._discount = value;}
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
            protected set { this._outDays = value;}
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
            protected set { this._chargeFee = value;}
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
            protected set { this._totalRealCost = value;}
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
            protected set { this._restCost = value;}
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
            protected set { this._totalDiscountCost = value;}
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
            protected set { this._onlyOnceCharge = value;}
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
            protected set { this._newEndTime = value;}
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
            protected set { this._chargeTime = value;}
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
            protected set { this._chargeMan = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _historyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int HistoryID
		{
			[DebuggerStepThrough()]
			get { return this._historyID; }
            protected set { this._historyID = value;}
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
            protected set { this._printID = value;}
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
            protected set { this._chargeState = value;}
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
            protected set { this._returnGuaranteeFee = value;}
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
            protected set { this._parentRoomFeeID = value;}
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
            protected set { this._parentHistoryID = value;}
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
            protected set { this._isCuiShou = value;}
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
            protected set { this._contractID = value;}
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
            protected set { this._discountID = value;}
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
            protected set { this._roomName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeName
		{
			[DebuggerStepThrough()]
			get { return this._chargeName; }
            protected set { this._chargeName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _startPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal StartPoint
		{
			[DebuggerStepThrough()]
			get { return this._startPoint; }
            protected set { this._startPoint = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _endPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal EndPoint
		{
			[DebuggerStepThrough()]
			get { return this._endPoint; }
            protected set { this._endPoint = value;}
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
            protected set { this._printNumber = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeTypeName1 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeTypeName1
		{
			[DebuggerStepThrough()]
			get { return this._chargeTypeName1; }
            protected set { this._chargeTypeName1 = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chageType1 = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChageType1
		{
			[DebuggerStepThrough()]
			get { return this._chageType1; }
            protected set { this._chageType1 = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _feeType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int FeeType
		{
			[DebuggerStepThrough()]
			get { return this._feeType; }
            protected set { this._feeType = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _typeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TypeID
		{
			[DebuggerStepThrough()]
			get { return this._typeID; }
            protected set { this._typeID = value;}
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
            protected set { this._categoryID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _endTypeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int EndTypeID
		{
			[DebuggerStepThrough()]
			get { return this._endTypeID; }
            protected set { this._endTypeID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _summaryUnitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal SummaryUnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._summaryUnitPrice; }
            protected set { this._summaryUnitPrice = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeTypeName2 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeTypeName2
		{
			[DebuggerStepThrough()]
			get { return this._chargeTypeName2; }
            protected set { this._chargeTypeName2 = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _printRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PrintRemark
		{
			[DebuggerStepThrough()]
			get { return this._printRemark; }
            protected set { this._printRemark = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _lastPrintTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime LastPrintTime
		{
			[DebuggerStepThrough()]
			get { return this._lastPrintTime; }
            protected set { this._lastPrintTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _printCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PrintCount
		{
			[DebuggerStepThrough()]
			get { return this._printCount; }
            protected set { this._printCount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isRePrint = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsRePrint
		{
			[DebuggerStepThrough()]
			get { return this._isRePrint; }
            protected set { this._isRePrint = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chageType2 = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChageType2
		{
			[DebuggerStepThrough()]
			get { return this._chageType2; }
            protected set { this._chageType2 = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _realMoneyCost1 = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RealMoneyCost1
		{
			[DebuggerStepThrough()]
			get { return this._realMoneyCost1; }
            protected set { this._realMoneyCost1 = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _realMoneyCost2 = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RealMoneyCost2
		{
			[DebuggerStepThrough()]
			get { return this._realMoneyCost2; }
            protected set { this._realMoneyCost2 = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalPoint
		{
			[DebuggerStepThrough()]
			get { return this._totalPoint; }
            protected set { this._totalPoint = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _printRealCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal PrintRealCost
		{
			[DebuggerStepThrough()]
			get { return this._printRealCost; }
            protected set { this._printRealCost = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relatePhoneNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelatePhoneNumber
		{
			[DebuggerStepThrough()]
			get { return this._relatePhoneNumber; }
            protected set { this._relatePhoneNumber = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relationName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelationName
		{
			[DebuggerStepThrough()]
			get { return this._relationName; }
            protected set { this._relationName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeTypeName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeTypeName
		{
			[DebuggerStepThrough()]
			get { return this._chargeTypeName; }
            protected set { this._chargeTypeName = value;}
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
            protected set { this._approveStatus = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _fullName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FullName
		{
			[DebuggerStepThrough()]
			get { return this._fullName; }
            protected set { this._fullName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _defaultOrder = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DefaultOrder
		{
			[DebuggerStepThrough()]
			get { return this._defaultOrder; }
            protected set { this._defaultOrder = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewContractFeeHistory() { }
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
	[ViewContractFeeHistory].[ID],
	[ViewContractFeeHistory].[RoomID],
	[ViewContractFeeHistory].[UseCount],
	[ViewContractFeeHistory].[StartTime],
	[ViewContractFeeHistory].[EndTime],
	[ViewContractFeeHistory].[Cost],
	[ViewContractFeeHistory].[Remark],
	[ViewContractFeeHistory].[AddTime],
	[ViewContractFeeHistory].[IsCharged],
	[ViewContractFeeHistory].[ChargeFeeID],
	[ViewContractFeeHistory].[ChargeID],
	[ViewContractFeeHistory].[IsStart],
	[ViewContractFeeHistory].[NewStartTime],
	[ViewContractFeeHistory].[ImportFeeID],
	[ViewContractFeeHistory].[UnitPrice],
	[ViewContractFeeHistory].[RealCost],
	[ViewContractFeeHistory].[Discount],
	[ViewContractFeeHistory].[OutDays],
	[ViewContractFeeHistory].[ChargeFee],
	[ViewContractFeeHistory].[TotalRealCost],
	[ViewContractFeeHistory].[RestCost],
	[ViewContractFeeHistory].[TotalDiscountCost],
	[ViewContractFeeHistory].[OnlyOnceCharge],
	[ViewContractFeeHistory].[NewEndTime],
	[ViewContractFeeHistory].[ChargeTime],
	[ViewContractFeeHistory].[ChargeMan],
	[ViewContractFeeHistory].[HistoryID],
	[ViewContractFeeHistory].[PrintID],
	[ViewContractFeeHistory].[ChargeState],
	[ViewContractFeeHistory].[ReturnGuaranteeFee],
	[ViewContractFeeHistory].[ParentRoomFeeID],
	[ViewContractFeeHistory].[ParentHistoryID],
	[ViewContractFeeHistory].[IsCuiShou],
	[ViewContractFeeHistory].[ContractID],
	[ViewContractFeeHistory].[DiscountID],
	[ViewContractFeeHistory].[RoomName],
	[ViewContractFeeHistory].[ChargeName],
	[ViewContractFeeHistory].[StartPoint],
	[ViewContractFeeHistory].[EndPoint],
	[ViewContractFeeHistory].[PrintNumber],
	[ViewContractFeeHistory].[ChargeTypeName1],
	[ViewContractFeeHistory].[ChageType1],
	[ViewContractFeeHistory].[FeeType],
	[ViewContractFeeHistory].[TypeID],
	[ViewContractFeeHistory].[CategoryID],
	[ViewContractFeeHistory].[EndTypeID],
	[ViewContractFeeHistory].[SummaryUnitPrice],
	[ViewContractFeeHistory].[ChargeTypeName2],
	[ViewContractFeeHistory].[PrintRemark],
	[ViewContractFeeHistory].[LastPrintTime],
	[ViewContractFeeHistory].[PrintCount],
	[ViewContractFeeHistory].[IsRePrint],
	[ViewContractFeeHistory].[ChageType2],
	[ViewContractFeeHistory].[RealMoneyCost1],
	[ViewContractFeeHistory].[RealMoneyCost2],
	[ViewContractFeeHistory].[TotalPoint],
	[ViewContractFeeHistory].[PrintRealCost],
	[ViewContractFeeHistory].[RelatePhoneNumber],
	[ViewContractFeeHistory].[RelationName],
	[ViewContractFeeHistory].[ChargeTypeName],
	[ViewContractFeeHistory].[ApproveStatus],
	[ViewContractFeeHistory].[FullName],
	[ViewContractFeeHistory].[DefaultOrder]
";
			}
		}
		
		
		/// <summary>
        /// View Name
        /// </summary>
        public static string ViewName
        {
            get
            {
                return "ViewContractFeeHistory";
            }
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
		
		#region Static Methods
				
		/// <summary>
		/// Gets a collection ViewContractFeeHistory objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewContractFeeHistory objects.</returns>
		public static EntityList<ViewContractFeeHistory> GetViewContractFeeHistories()
		{
			string commandText = @"
SELECT " + ViewContractFeeHistory.SelectFieldList + "FROM [dbo].[ViewContractFeeHistory] " + ViewContractFeeHistory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewContractFeeHistory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewContractFeeHistory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewContractFeeHistory objects.</returns>
        public static EntityList<ViewContractFeeHistory> GetViewContractFeeHistories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewContractFeeHistory>(SelectFieldList, "FROM [dbo].[ViewContractFeeHistory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewContractFeeHistory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewContractFeeHistory objects.</returns>
        public static EntityList<ViewContractFeeHistory> GetViewContractFeeHistories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewContractFeeHistory>(SelectFieldList, "FROM [dbo].[ViewContractFeeHistory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewContractFeeHistory objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewContractFeeHistoryCount()
        {
            return GetViewContractFeeHistoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewContractFeeHistory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewContractFeeHistoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewContractFeeHistory] " + where;

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
		
		/// <summary>
		/// Gets a collection ViewContractFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewContractFeeHistory objects.</returns>
		protected static EntityList<ViewContractFeeHistory> GetViewContractFeeHistories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewContractFeeHistories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewContractFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewContractFeeHistory objects.</returns>
		protected static EntityList<ViewContractFeeHistory> GetViewContractFeeHistories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewContractFeeHistories(string.Empty, where, parameters, ViewContractFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewContractFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewContractFeeHistory objects.</returns>
		protected static EntityList<ViewContractFeeHistory> GetViewContractFeeHistories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewContractFeeHistories(prefix, where, parameters, ViewContractFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewContractFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewContractFeeHistory objects.</returns>
		protected static EntityList<ViewContractFeeHistory> GetViewContractFeeHistories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewContractFeeHistories(string.Empty, where, parameters, ViewContractFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewContractFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewContractFeeHistory objects.</returns>
		protected static EntityList<ViewContractFeeHistory> GetViewContractFeeHistories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewContractFeeHistories(prefix, where, parameters, ViewContractFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewContractFeeHistory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewContractFeeHistory objects.</returns>
		protected static EntityList<ViewContractFeeHistory> GetViewContractFeeHistories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewContractFeeHistory.SelectFieldList + "FROM [dbo].[ViewContractFeeHistory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewContractFeeHistory>(reader);
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
        protected static EntityList<ViewContractFeeHistory> GetViewContractFeeHistories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewContractFeeHistory>(SelectFieldList, "FROM [dbo].[ViewContractFeeHistory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewContractFeeHistoryProperties
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
			public const string HistoryID = "HistoryID";
			public const string PrintID = "PrintID";
			public const string ChargeState = "ChargeState";
			public const string ReturnGuaranteeFee = "ReturnGuaranteeFee";
			public const string ParentRoomFeeID = "ParentRoomFeeID";
			public const string ParentHistoryID = "ParentHistoryID";
			public const string IsCuiShou = "IsCuiShou";
			public const string ContractID = "ContractID";
			public const string DiscountID = "DiscountID";
			public const string RoomName = "RoomName";
			public const string ChargeName = "ChargeName";
			public const string StartPoint = "StartPoint";
			public const string EndPoint = "EndPoint";
			public const string PrintNumber = "PrintNumber";
			public const string ChargeTypeName1 = "ChargeTypeName1";
			public const string ChageType1 = "ChageType1";
			public const string FeeType = "FeeType";
			public const string TypeID = "TypeID";
			public const string CategoryID = "CategoryID";
			public const string EndTypeID = "EndTypeID";
			public const string SummaryUnitPrice = "SummaryUnitPrice";
			public const string ChargeTypeName2 = "ChargeTypeName2";
			public const string PrintRemark = "PrintRemark";
			public const string LastPrintTime = "LastPrintTime";
			public const string PrintCount = "PrintCount";
			public const string IsRePrint = "IsRePrint";
			public const string ChageType2 = "ChageType2";
			public const string RealMoneyCost1 = "RealMoneyCost1";
			public const string RealMoneyCost2 = "RealMoneyCost2";
			public const string TotalPoint = "TotalPoint";
			public const string PrintRealCost = "PrintRealCost";
			public const string RelatePhoneNumber = "RelatePhoneNumber";
			public const string RelationName = "RelationName";
			public const string ChargeTypeName = "ChargeTypeName";
			public const string ApproveStatus = "ApproveStatus";
			public const string FullName = "FullName";
			public const string DefaultOrder = "DefaultOrder";
            
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
    			 {"HistoryID" , "int:"},
    			 {"PrintID" , "int:"},
    			 {"ChargeState" , "int:"},
    			 {"ReturnGuaranteeFee" , "bool:"},
    			 {"ParentRoomFeeID" , "int:"},
    			 {"ParentHistoryID" , "int:"},
    			 {"IsCuiShou" , "bool:"},
    			 {"ContractID" , "int:"},
    			 {"DiscountID" , "int:"},
    			 {"RoomName" , "string:"},
    			 {"ChargeName" , "string:"},
    			 {"StartPoint" , "decimal:"},
    			 {"EndPoint" , "decimal:"},
    			 {"PrintNumber" , "string:"},
    			 {"ChargeTypeName1" , "string:"},
    			 {"ChageType1" , "int:"},
    			 {"FeeType" , "int:"},
    			 {"TypeID" , "int:"},
    			 {"CategoryID" , "int:"},
    			 {"EndTypeID" , "int:"},
    			 {"SummaryUnitPrice" , "decimal:"},
    			 {"ChargeTypeName2" , "string:"},
    			 {"PrintRemark" , "string:"},
    			 {"LastPrintTime" , "DateTime:"},
    			 {"PrintCount" , "int:"},
    			 {"IsRePrint" , "bool:"},
    			 {"ChageType2" , "int:"},
    			 {"RealMoneyCost1" , "decimal:"},
    			 {"RealMoneyCost2" , "decimal:"},
    			 {"TotalPoint" , "decimal:"},
    			 {"PrintRealCost" , "decimal:"},
    			 {"RelatePhoneNumber" , "string:"},
    			 {"RelationName" , "string:"},
    			 {"ChargeTypeName" , "string:"},
    			 {"ApproveStatus" , "int:"},
    			 {"FullName" , "string:"},
    			 {"DefaultOrder" , "string:"},
            };
		}
		#endregion
	}
}
