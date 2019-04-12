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
	/// This object represents the properties and methods of a ViewTempRoomFeeHistory.
	/// </summary>
	[Serializable()]
	public partial class ViewTempRoomFeeHistory 
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
		private int _tempHistoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int TempHistoryID
		{
			[DebuggerStepThrough()]
			get { return this._tempHistoryID; }
            protected set { this._tempHistoryID = value;}
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
		private int _tempID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TempID
		{
			[DebuggerStepThrough()]
			get { return this._tempID; }
            protected set { this._tempID = value;}
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
		private int _chargeFeeSummaryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChargeFeeSummaryID
		{
			[DebuggerStepThrough()]
			get { return this._chargeFeeSummaryID; }
            protected set { this._chargeFeeSummaryID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeFeeSummaryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeFeeSummaryName
		{
			[DebuggerStepThrough()]
			get { return this._chargeFeeSummaryName; }
            protected set { this._chargeFeeSummaryName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _chargeFeeCurrentBalance = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ChargeFeeCurrentBalance
		{
			[DebuggerStepThrough()]
			get { return this._chargeFeeCurrentBalance; }
            protected set { this._chargeFeeCurrentBalance = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _cuiShouStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime CuiShouStartTime
		{
			[DebuggerStepThrough()]
			get { return this._cuiShouStartTime; }
            protected set { this._cuiShouStartTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _cuiShouEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime CuiShouEndTime
		{
			[DebuggerStepThrough()]
			get { return this._cuiShouEndTime; }
            protected set { this._cuiShouEndTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _relatedFeeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RelatedFeeID
		{
			[DebuggerStepThrough()]
			get { return this._relatedFeeID; }
            protected set { this._relatedFeeID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chongDiChargeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChongDiChargeID
		{
			[DebuggerStepThrough()]
			get { return this._chongDiChargeID; }
            protected set { this._chongDiChargeID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _backGuaranteeChargeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime BackGuaranteeChargeTime
		{
			[DebuggerStepThrough()]
			get { return this._backGuaranteeChargeTime; }
            protected set { this._backGuaranteeChargeTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _backGuaranteeRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BackGuaranteeRemark
		{
			[DebuggerStepThrough()]
			get { return this._backGuaranteeRemark; }
            protected set { this._backGuaranteeRemark = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _defaultChargeManID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int DefaultChargeManID
		{
			[DebuggerStepThrough()]
			get { return this._defaultChargeManID; }
            protected set { this._defaultChargeManID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _defaultChargeManName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DefaultChargeManName
		{
			[DebuggerStepThrough()]
			get { return this._defaultChargeManName; }
            protected set { this._defaultChargeManName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _importRate = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ImportRate
		{
			[DebuggerStepThrough()]
			get { return this._importRate; }
            protected set { this._importRate = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _projectBiaoID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProjectBiaoID
		{
			[DebuggerStepThrough()]
			get { return this._projectBiaoID; }
            protected set { this._projectBiaoID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargeBiaoID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChargeBiaoID
		{
			[DebuggerStepThrough()]
			get { return this._chargeBiaoID; }
            protected set { this._chargeBiaoID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _importBiaoName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ImportBiaoName
		{
			[DebuggerStepThrough()]
			get { return this._importBiaoName; }
            protected set { this._importBiaoName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _importBiaoCategory = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ImportBiaoCategory
		{
			[DebuggerStepThrough()]
			get { return this._importBiaoCategory; }
            protected set { this._importBiaoCategory = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _importBiaoGuiGe = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ImportBiaoGuiGe
		{
			[DebuggerStepThrough()]
			get { return this._importBiaoGuiGe; }
            protected set { this._importBiaoGuiGe = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isTempFee = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsTempFee
		{
			[DebuggerStepThrough()]
			get { return this._isTempFee; }
            protected set { this._isTempFee = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isMeterFee = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsMeterFee
		{
			[DebuggerStepThrough()]
			get { return this._isMeterFee; }
            protected set { this._isMeterFee = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isImportFee = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsImportFee
		{
			[DebuggerStepThrough()]
			get { return this._isImportFee; }
            protected set { this._isImportFee = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isCycleFee = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsCycleFee
		{
			[DebuggerStepThrough()]
			get { return this._isCycleFee; }
            protected set { this._isCycleFee = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _roomFeeCoefficient = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RoomFeeCoefficient
		{
			[DebuggerStepThrough()]
			get { return this._roomFeeCoefficient; }
            protected set { this._roomFeeCoefficient = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _roomFeeWriteDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime RoomFeeWriteDate
		{
			[DebuggerStepThrough()]
			get { return this._roomFeeWriteDate; }
            protected set { this._roomFeeWriteDate = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _roomFeeStartPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RoomFeeStartPoint
		{
			[DebuggerStepThrough()]
			get { return this._roomFeeStartPoint; }
            protected set { this._roomFeeStartPoint = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _roomFeeEndPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RoomFeeEndPoint
		{
			[DebuggerStepThrough()]
			get { return this._roomFeeEndPoint; }
            protected set { this._roomFeeEndPoint = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargeMeterProjectFeeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChargeMeterProjectFeeID
		{
			[DebuggerStepThrough()]
			get { return this._chargeMeterProjectFeeID; }
            protected set { this._chargeMeterProjectFeeID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _contractDivideID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ContractDivideID
		{
			[DebuggerStepThrough()]
			get { return this._contractDivideID; }
            protected set { this._contractDivideID = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewTempRoomFeeHistory() { }
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
	[ViewTempRoomFeeHistory].[ID],
	[ViewTempRoomFeeHistory].[RoomID],
	[ViewTempRoomFeeHistory].[UseCount],
	[ViewTempRoomFeeHistory].[StartTime],
	[ViewTempRoomFeeHistory].[EndTime],
	[ViewTempRoomFeeHistory].[Cost],
	[ViewTempRoomFeeHistory].[Remark],
	[ViewTempRoomFeeHistory].[AddTime],
	[ViewTempRoomFeeHistory].[IsCharged],
	[ViewTempRoomFeeHistory].[ChargeFeeID],
	[ViewTempRoomFeeHistory].[RoomName],
	[ViewTempRoomFeeHistory].[UnitPrice],
	[ViewTempRoomFeeHistory].[RealCost],
	[ViewTempRoomFeeHistory].[OutDays],
	[ViewTempRoomFeeHistory].[ChargeTime],
	[ViewTempRoomFeeHistory].[ChargeMan],
	[ViewTempRoomFeeHistory].[TempHistoryID],
	[ViewTempRoomFeeHistory].[ChargeID],
	[ViewTempRoomFeeHistory].[IsStart],
	[ViewTempRoomFeeHistory].[NewStartTime],
	[ViewTempRoomFeeHistory].[ChargeName],
	[ViewTempRoomFeeHistory].[ImportFeeID],
	[ViewTempRoomFeeHistory].[StartPoint],
	[ViewTempRoomFeeHistory].[EndPoint],
	[ViewTempRoomFeeHistory].[PrintID],
	[ViewTempRoomFeeHistory].[Discount],
	[ViewTempRoomFeeHistory].[PrintNumber],
	[ViewTempRoomFeeHistory].[ChargeTypeName1],
	[ViewTempRoomFeeHistory].[ChageType1],
	[ViewTempRoomFeeHistory].[ChargeFee],
	[ViewTempRoomFeeHistory].[ChargeState],
	[ViewTempRoomFeeHistory].[FeeType],
	[ViewTempRoomFeeHistory].[TypeID],
	[ViewTempRoomFeeHistory].[CategoryID],
	[ViewTempRoomFeeHistory].[EndTypeID],
	[ViewTempRoomFeeHistory].[SummaryUnitPrice],
	[ViewTempRoomFeeHistory].[ChargeTypeName2],
	[ViewTempRoomFeeHistory].[TotalRealCost],
	[ViewTempRoomFeeHistory].[RestCost],
	[ViewTempRoomFeeHistory].[TotalDiscountCost],
	[ViewTempRoomFeeHistory].[ReturnGuaranteeFee],
	[ViewTempRoomFeeHistory].[PrintRemark],
	[ViewTempRoomFeeHistory].[LastPrintTime],
	[ViewTempRoomFeeHistory].[PrintCount],
	[ViewTempRoomFeeHistory].[IsRePrint],
	[ViewTempRoomFeeHistory].[TempID],
	[ViewTempRoomFeeHistory].[ParentRoomFeeID],
	[ViewTempRoomFeeHistory].[ParentHistoryID],
	[ViewTempRoomFeeHistory].[IsCuiShou],
	[ViewTempRoomFeeHistory].[ContractID],
	[ViewTempRoomFeeHistory].[DiscountID],
	[ViewTempRoomFeeHistory].[ChargeFeeSummaryID],
	[ViewTempRoomFeeHistory].[ChargeFeeSummaryName],
	[ViewTempRoomFeeHistory].[ChargeFeeCurrentBalance],
	[ViewTempRoomFeeHistory].[CuiShouStartTime],
	[ViewTempRoomFeeHistory].[CuiShouEndTime],
	[ViewTempRoomFeeHistory].[RelatedFeeID],
	[ViewTempRoomFeeHistory].[ChongDiChargeID],
	[ViewTempRoomFeeHistory].[BackGuaranteeChargeTime],
	[ViewTempRoomFeeHistory].[BackGuaranteeRemark],
	[ViewTempRoomFeeHistory].[DefaultChargeManID],
	[ViewTempRoomFeeHistory].[DefaultChargeManName],
	[ViewTempRoomFeeHistory].[ImportRate],
	[ViewTempRoomFeeHistory].[ProjectBiaoID],
	[ViewTempRoomFeeHistory].[ChargeBiaoID],
	[ViewTempRoomFeeHistory].[ImportBiaoName],
	[ViewTempRoomFeeHistory].[ImportBiaoCategory],
	[ViewTempRoomFeeHistory].[ImportBiaoGuiGe],
	[ViewTempRoomFeeHistory].[IsTempFee],
	[ViewTempRoomFeeHistory].[IsMeterFee],
	[ViewTempRoomFeeHistory].[IsImportFee],
	[ViewTempRoomFeeHistory].[IsCycleFee],
	[ViewTempRoomFeeHistory].[RoomFeeCoefficient],
	[ViewTempRoomFeeHistory].[RoomFeeWriteDate],
	[ViewTempRoomFeeHistory].[RoomFeeStartPoint],
	[ViewTempRoomFeeHistory].[RoomFeeEndPoint],
	[ViewTempRoomFeeHistory].[ChargeMeterProjectFeeID],
	[ViewTempRoomFeeHistory].[ContractDivideID]
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
                return "ViewTempRoomFeeHistory";
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
		/// Gets a collection ViewTempRoomFeeHistory objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewTempRoomFeeHistory objects.</returns>
		public static EntityList<ViewTempRoomFeeHistory> GetViewTempRoomFeeHistories()
		{
			string commandText = @"
SELECT " + ViewTempRoomFeeHistory.SelectFieldList + "FROM [dbo].[ViewTempRoomFeeHistory] " + ViewTempRoomFeeHistory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewTempRoomFeeHistory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewTempRoomFeeHistory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewTempRoomFeeHistory objects.</returns>
        public static EntityList<ViewTempRoomFeeHistory> GetViewTempRoomFeeHistories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewTempRoomFeeHistory>(SelectFieldList, "FROM [dbo].[ViewTempRoomFeeHistory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewTempRoomFeeHistory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewTempRoomFeeHistory objects.</returns>
        public static EntityList<ViewTempRoomFeeHistory> GetViewTempRoomFeeHistories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewTempRoomFeeHistory>(SelectFieldList, "FROM [dbo].[ViewTempRoomFeeHistory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewTempRoomFeeHistory objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewTempRoomFeeHistoryCount()
        {
            return GetViewTempRoomFeeHistoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewTempRoomFeeHistory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewTempRoomFeeHistoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewTempRoomFeeHistory] " + where;

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
		/// Gets a collection ViewTempRoomFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewTempRoomFeeHistory objects.</returns>
		protected static EntityList<ViewTempRoomFeeHistory> GetViewTempRoomFeeHistories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewTempRoomFeeHistories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewTempRoomFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewTempRoomFeeHistory objects.</returns>
		protected static EntityList<ViewTempRoomFeeHistory> GetViewTempRoomFeeHistories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewTempRoomFeeHistories(string.Empty, where, parameters, ViewTempRoomFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewTempRoomFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewTempRoomFeeHistory objects.</returns>
		protected static EntityList<ViewTempRoomFeeHistory> GetViewTempRoomFeeHistories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewTempRoomFeeHistories(prefix, where, parameters, ViewTempRoomFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewTempRoomFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewTempRoomFeeHistory objects.</returns>
		protected static EntityList<ViewTempRoomFeeHistory> GetViewTempRoomFeeHistories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewTempRoomFeeHistories(string.Empty, where, parameters, ViewTempRoomFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewTempRoomFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewTempRoomFeeHistory objects.</returns>
		protected static EntityList<ViewTempRoomFeeHistory> GetViewTempRoomFeeHistories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewTempRoomFeeHistories(prefix, where, parameters, ViewTempRoomFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewTempRoomFeeHistory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewTempRoomFeeHistory objects.</returns>
		protected static EntityList<ViewTempRoomFeeHistory> GetViewTempRoomFeeHistories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewTempRoomFeeHistory.SelectFieldList + "FROM [dbo].[ViewTempRoomFeeHistory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewTempRoomFeeHistory>(reader);
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
        protected static EntityList<ViewTempRoomFeeHistory> GetViewTempRoomFeeHistories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewTempRoomFeeHistory>(SelectFieldList, "FROM [dbo].[ViewTempRoomFeeHistory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewTempRoomFeeHistoryProperties
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
			public const string RoomName = "RoomName";
			public const string UnitPrice = "UnitPrice";
			public const string RealCost = "RealCost";
			public const string OutDays = "OutDays";
			public const string ChargeTime = "ChargeTime";
			public const string ChargeMan = "ChargeMan";
			public const string TempHistoryID = "TempHistoryID";
			public const string ChargeID = "ChargeID";
			public const string IsStart = "IsStart";
			public const string NewStartTime = "NewStartTime";
			public const string ChargeName = "ChargeName";
			public const string ImportFeeID = "ImportFeeID";
			public const string StartPoint = "StartPoint";
			public const string EndPoint = "EndPoint";
			public const string PrintID = "PrintID";
			public const string Discount = "Discount";
			public const string PrintNumber = "PrintNumber";
			public const string ChargeTypeName1 = "ChargeTypeName1";
			public const string ChageType1 = "ChageType1";
			public const string ChargeFee = "ChargeFee";
			public const string ChargeState = "ChargeState";
			public const string FeeType = "FeeType";
			public const string TypeID = "TypeID";
			public const string CategoryID = "CategoryID";
			public const string EndTypeID = "EndTypeID";
			public const string SummaryUnitPrice = "SummaryUnitPrice";
			public const string ChargeTypeName2 = "ChargeTypeName2";
			public const string TotalRealCost = "TotalRealCost";
			public const string RestCost = "RestCost";
			public const string TotalDiscountCost = "TotalDiscountCost";
			public const string ReturnGuaranteeFee = "ReturnGuaranteeFee";
			public const string PrintRemark = "PrintRemark";
			public const string LastPrintTime = "LastPrintTime";
			public const string PrintCount = "PrintCount";
			public const string IsRePrint = "IsRePrint";
			public const string TempID = "TempID";
			public const string ParentRoomFeeID = "ParentRoomFeeID";
			public const string ParentHistoryID = "ParentHistoryID";
			public const string IsCuiShou = "IsCuiShou";
			public const string ContractID = "ContractID";
			public const string DiscountID = "DiscountID";
			public const string ChargeFeeSummaryID = "ChargeFeeSummaryID";
			public const string ChargeFeeSummaryName = "ChargeFeeSummaryName";
			public const string ChargeFeeCurrentBalance = "ChargeFeeCurrentBalance";
			public const string CuiShouStartTime = "CuiShouStartTime";
			public const string CuiShouEndTime = "CuiShouEndTime";
			public const string RelatedFeeID = "RelatedFeeID";
			public const string ChongDiChargeID = "ChongDiChargeID";
			public const string BackGuaranteeChargeTime = "BackGuaranteeChargeTime";
			public const string BackGuaranteeRemark = "BackGuaranteeRemark";
			public const string DefaultChargeManID = "DefaultChargeManID";
			public const string DefaultChargeManName = "DefaultChargeManName";
			public const string ImportRate = "ImportRate";
			public const string ProjectBiaoID = "ProjectBiaoID";
			public const string ChargeBiaoID = "ChargeBiaoID";
			public const string ImportBiaoName = "ImportBiaoName";
			public const string ImportBiaoCategory = "ImportBiaoCategory";
			public const string ImportBiaoGuiGe = "ImportBiaoGuiGe";
			public const string IsTempFee = "IsTempFee";
			public const string IsMeterFee = "IsMeterFee";
			public const string IsImportFee = "IsImportFee";
			public const string IsCycleFee = "IsCycleFee";
			public const string RoomFeeCoefficient = "RoomFeeCoefficient";
			public const string RoomFeeWriteDate = "RoomFeeWriteDate";
			public const string RoomFeeStartPoint = "RoomFeeStartPoint";
			public const string RoomFeeEndPoint = "RoomFeeEndPoint";
			public const string ChargeMeterProjectFeeID = "ChargeMeterProjectFeeID";
			public const string ContractDivideID = "ContractDivideID";
            
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
    			 {"RoomName" , "string:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"RealCost" , "decimal:"},
    			 {"OutDays" , "int:"},
    			 {"ChargeTime" , "DateTime:"},
    			 {"ChargeMan" , "string:"},
    			 {"TempHistoryID" , "int:"},
    			 {"ChargeID" , "int:"},
    			 {"IsStart" , "bool:"},
    			 {"NewStartTime" , "DateTime:"},
    			 {"ChargeName" , "string:"},
    			 {"ImportFeeID" , "int:"},
    			 {"StartPoint" , "decimal:"},
    			 {"EndPoint" , "decimal:"},
    			 {"PrintID" , "int:"},
    			 {"Discount" , "decimal:"},
    			 {"PrintNumber" , "string:"},
    			 {"ChargeTypeName1" , "string:"},
    			 {"ChageType1" , "int:"},
    			 {"ChargeFee" , "decimal:"},
    			 {"ChargeState" , "int:"},
    			 {"FeeType" , "int:"},
    			 {"TypeID" , "int:"},
    			 {"CategoryID" , "int:"},
    			 {"EndTypeID" , "int:"},
    			 {"SummaryUnitPrice" , "decimal:"},
    			 {"ChargeTypeName2" , "string:"},
    			 {"TotalRealCost" , "decimal:"},
    			 {"RestCost" , "decimal:"},
    			 {"TotalDiscountCost" , "decimal:"},
    			 {"ReturnGuaranteeFee" , "bool:"},
    			 {"PrintRemark" , "string:"},
    			 {"LastPrintTime" , "DateTime:"},
    			 {"PrintCount" , "int:"},
    			 {"IsRePrint" , "bool:"},
    			 {"TempID" , "int:"},
    			 {"ParentRoomFeeID" , "int:"},
    			 {"ParentHistoryID" , "int:"},
    			 {"IsCuiShou" , "bool:"},
    			 {"ContractID" , "int:"},
    			 {"DiscountID" , "int:"},
    			 {"ChargeFeeSummaryID" , "int:"},
    			 {"ChargeFeeSummaryName" , "string:"},
    			 {"ChargeFeeCurrentBalance" , "decimal:"},
    			 {"CuiShouStartTime" , "DateTime:"},
    			 {"CuiShouEndTime" , "DateTime:"},
    			 {"RelatedFeeID" , "int:"},
    			 {"ChongDiChargeID" , "int:"},
    			 {"BackGuaranteeChargeTime" , "DateTime:"},
    			 {"BackGuaranteeRemark" , "string:"},
    			 {"DefaultChargeManID" , "int:"},
    			 {"DefaultChargeManName" , "string:"},
    			 {"ImportRate" , "decimal:"},
    			 {"ProjectBiaoID" , "int:"},
    			 {"ChargeBiaoID" , "int:"},
    			 {"ImportBiaoName" , "string:"},
    			 {"ImportBiaoCategory" , "string:"},
    			 {"ImportBiaoGuiGe" , "string:"},
    			 {"IsTempFee" , "bool:"},
    			 {"IsMeterFee" , "bool:"},
    			 {"IsImportFee" , "bool:"},
    			 {"IsCycleFee" , "bool:"},
    			 {"RoomFeeCoefficient" , "decimal:"},
    			 {"RoomFeeWriteDate" , "DateTime:"},
    			 {"RoomFeeStartPoint" , "decimal:"},
    			 {"RoomFeeEndPoint" , "decimal:"},
    			 {"ChargeMeterProjectFeeID" , "int:"},
    			 {"ContractDivideID" , "int:"},
            };
		}
		#endregion
	}
}
