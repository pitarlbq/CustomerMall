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
	/// This object represents the properties and methods of a ViewRoomFee.
	/// </summary>
	[Serializable()]
	public partial class ViewRoomFee 
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
		private decimal _chargeFeeUnitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ChargeFeeUnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._chargeFeeUnitPrice; }
            protected set { this._chargeFeeUnitPrice = value;}
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
		private int _chargeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
		[DataObjectField(false, false, false)]
		public bool IsStart
		{
			[DebuggerStepThrough()]
			get { return this._isStart; }
            protected set { this._isStart = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _name = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Name
		{
			[DebuggerStepThrough()]
			get { return this._name; }
            protected set { this._name = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _setStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime SetStartTime
		{
			[DebuggerStepThrough()]
			get { return this._setStartTime; }
            protected set { this._setStartTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _changeUnitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ChangeUnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._changeUnitPrice; }
            protected set { this._changeUnitPrice = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _changeStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ChangeStartTime
		{
			[DebuggerStepThrough()]
			get { return this._changeStartTime; }
            protected set { this._changeStartTime = value;}
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
		private decimal _buildingArea = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal BuildingArea
		{
			[DebuggerStepThrough()]
			get { return this._buildingArea; }
            protected set { this._buildingArea = value;}
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
		private decimal _chargeFee = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal ChargeFee
		{
			[DebuggerStepThrough()]
			get { return this._chargeFee; }
            protected set { this._chargeFee = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _balance = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal Balance
		{
			[DebuggerStepThrough()]
			get { return this._balance; }
            protected set { this._balance = value;}
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
		private bool _isReading = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsReading
		{
			[DebuggerStepThrough()]
			get { return this._isReading; }
            protected set { this._isReading = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargeTypeCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChargeTypeCount
		{
			[DebuggerStepThrough()]
			get { return this._chargeTypeCount; }
            protected set { this._chargeTypeCount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _importCoefficient = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ImportCoefficient
		{
			[DebuggerStepThrough()]
			get { return this._importCoefficient; }
            protected set { this._importCoefficient = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAllowImport = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAllowImport
		{
			[DebuggerStepThrough()]
			get { return this._isAllowImport; }
            protected set { this._isAllowImport = value;}
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
		private decimal _fenTanCoefficient = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal FenTanCoefficient
		{
			[DebuggerStepThrough()]
			get { return this._fenTanCoefficient; }
            protected set { this._fenTanCoefficient = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _functionCoefficient = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal FunctionCoefficient
		{
			[DebuggerStepThrough()]
			get { return this._functionCoefficient; }
            protected set { this._functionCoefficient = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _categoryNote = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CategoryNote
		{
			[DebuggerStepThrough()]
			get { return this._categoryNote; }
            protected set { this._categoryNote = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _remarkNote = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RemarkNote
		{
			[DebuggerStepThrough()]
			get { return this._remarkNote; }
            protected set { this._remarkNote = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _writeDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime WriteDate
		{
			[DebuggerStepThrough()]
			get { return this._writeDate; }
            protected set { this._writeDate = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _timeAuto = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool TimeAuto
		{
			[DebuggerStepThrough()]
			get { return this._timeAuto; }
            protected set { this._timeAuto = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _orderBy = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OrderBy
		{
			[DebuggerStepThrough()]
			get { return this._orderBy; }
            protected set { this._orderBy = value;}
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
		private int _endNumberCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int EndNumberCount
		{
			[DebuggerStepThrough()]
			get { return this._endNumberCount; }
            protected set { this._endNumberCount = value;}
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
		private string _calculateAreaType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CalculateAreaType
		{
			[DebuggerStepThrough()]
			get { return this._calculateAreaType; }
            protected set { this._calculateAreaType = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _buildOutArea = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal BuildOutArea
		{
			[DebuggerStepThrough()]
			get { return this._buildOutArea; }
            protected set { this._buildOutArea = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _gonTanArea = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal GonTanArea
		{
			[DebuggerStepThrough()]
			get { return this._gonTanArea; }
            protected set { this._gonTanArea = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _feeCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int FeeCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._feeCategoryID; }
            protected set { this._feeCategoryID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _categoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CategoryName
		{
			[DebuggerStepThrough()]
			get { return this._categoryName; }
            protected set { this._categoryName = value;}
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
		private string _discountName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DiscountName
		{
			[DebuggerStepThrough()]
			get { return this._discountName; }
            protected set { this._discountName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _weiYueActiveStartDate = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string WeiYueActiveStartDate
		{
			[DebuggerStepThrough()]
			get { return this._weiYueActiveStartDate; }
            protected set { this._weiYueActiveStartDate = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _weiYueActiveBeforeAfter = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string WeiYueActiveBeforeAfter
		{
			[DebuggerStepThrough()]
			get { return this._weiYueActiveBeforeAfter; }
            protected set { this._weiYueActiveBeforeAfter = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _weiYueActiveCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int WeiYueActiveCount
		{
			[DebuggerStepThrough()]
			get { return this._weiYueActiveCount; }
            protected set { this._weiYueActiveCount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _weiYueActiveDayMonth = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string WeiYueActiveDayMonth
		{
			[DebuggerStepThrough()]
			get { return this._weiYueActiveDayMonth; }
            protected set { this._weiYueActiveDayMonth = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _weiYueEndDate = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string WeiYueEndDate
		{
			[DebuggerStepThrough()]
			get { return this._weiYueEndDate; }
            protected set { this._weiYueEndDate = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _weiYueStartDate = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string WeiYueStartDate
		{
			[DebuggerStepThrough()]
			get { return this._weiYueStartDate; }
            protected set { this._weiYueStartDate = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _weiYueBefore = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string WeiYueBefore
		{
			[DebuggerStepThrough()]
			get { return this._weiYueBefore; }
            protected set { this._weiYueBefore = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _weiYueDays = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int WeiYueDays
		{
			[DebuggerStepThrough()]
			get { return this._weiYueDays; }
            protected set { this._weiYueDays = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _dayGunLi = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool DayGunLi
		{
			[DebuggerStepThrough()]
			get { return this._dayGunLi; }
            protected set { this._dayGunLi = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargeWeiYueType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChargeWeiYueType
		{
			[DebuggerStepThrough()]
			get { return this._chargeWeiYueType; }
            protected set { this._chargeWeiYueType = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _weiYuePercent = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal WeiYuePercent
		{
			[DebuggerStepThrough()]
			get { return this._weiYuePercent; }
            protected set { this._weiYuePercent = value;}
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _buildInArea = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal BuildInArea
		{
			[DebuggerStepThrough()]
			get { return this._buildInArea; }
            protected set { this._buildInArea = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _chanQuanArea = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ChanQuanArea
		{
			[DebuggerStepThrough()]
			get { return this._chanQuanArea; }
            protected set { this._chanQuanArea = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _useArea = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal UseArea
		{
			[DebuggerStepThrough()]
			get { return this._useArea; }
            protected set { this._useArea = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _peiTaoArea = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal PeiTaoArea
		{
			[DebuggerStepThrough()]
			get { return this._peiTaoArea; }
            protected set { this._peiTaoArea = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _contractArea = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ContractArea
		{
			[DebuggerStepThrough()]
			get { return this._contractArea; }
            protected set { this._contractArea = value;}
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
		private bool _startPriceRange = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool StartPriceRange
		{
			[DebuggerStepThrough()]
			get { return this._startPriceRange; }
            protected set { this._startPriceRange = value;}
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
		private decimal _weiYueTotalCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal WeiYueTotalCost
		{
			[DebuggerStepThrough()]
			get { return this._weiYueTotalCost; }
            protected set { this._weiYueTotalCost = value;}
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
		private int _summaryChargeTypeCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SummaryChargeTypeCount
		{
			[DebuggerStepThrough()]
			get { return this._summaryChargeTypeCount; }
            protected set { this._summaryChargeTypeCount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _endNumberType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int EndNumberType
		{
			[DebuggerStepThrough()]
			get { return this._endNumberType; }
            protected set { this._endNumberType = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _autoToMonthEnd = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool AutoToMonthEnd
		{
			[DebuggerStepThrough()]
			get { return this._autoToMonthEnd; }
            protected set { this._autoToMonthEnd = value;}
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
		private string _contractNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractNo
		{
			[DebuggerStepThrough()]
			get { return this._contractNo; }
            protected set { this._contractNo = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _rentName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RentName
		{
			[DebuggerStepThrough()]
			get { return this._rentName; }
            protected set { this._rentName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomProperty = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomProperty
		{
			[DebuggerStepThrough()]
			get { return this._roomProperty; }
            protected set { this._roomProperty = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contractPhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractPhone
		{
			[DebuggerStepThrough()]
			get { return this._contractPhone; }
            protected set { this._contractPhone = value;}
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _priceRangeStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime PriceRangeStartTime
		{
			[DebuggerStepThrough()]
			get { return this._priceRangeStartTime; }
            protected set { this._priceRangeStartTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalUseCount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalUseCount
		{
			[DebuggerStepThrough()]
			get { return this._totalUseCount; }
            protected set { this._totalUseCount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalUseChaoBiaoCount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalUseChaoBiaoCount
		{
			[DebuggerStepThrough()]
			get { return this._totalUseChaoBiaoCount; }
            protected set { this._totalUseChaoBiaoCount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargeFeeType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChargeFeeType
		{
			[DebuggerStepThrough()]
			get { return this._chargeFeeType; }
            protected set { this._chargeFeeType = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _allParentID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AllParentID
		{
			[DebuggerStepThrough()]
			get { return this._allParentID; }
            protected set { this._allParentID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contractName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractName
		{
			[DebuggerStepThrough()]
			get { return this._contractName; }
            protected set { this._contractName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _readyChargeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ReadyChargeTime
		{
			[DebuggerStepThrough()]
			get { return this._readyChargeTime; }
            protected set { this._readyChargeTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _contract_RoomChargeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Contract_RoomChargeID
		{
			[DebuggerStepThrough()]
			get { return this._contract_RoomChargeID; }
            protected set { this._contract_RoomChargeID = value;}
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
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewRoomFee() { }
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
	[ViewRoomFee].[ID],
	[ViewRoomFee].[RoomID],
	[ViewRoomFee].[ChargeFeeUnitPrice],
	[ViewRoomFee].[UseCount],
	[ViewRoomFee].[StartTime],
	[ViewRoomFee].[EndTime],
	[ViewRoomFee].[Cost],
	[ViewRoomFee].[Remark],
	[ViewRoomFee].[AddTime],
	[ViewRoomFee].[IsCharged],
	[ViewRoomFee].[ChargeFeeID],
	[ViewRoomFee].[RoomName],
	[ViewRoomFee].[ChargeID],
	[ViewRoomFee].[IsStart],
	[ViewRoomFee].[Name],
	[ViewRoomFee].[SetStartTime],
	[ViewRoomFee].[ChangeUnitPrice],
	[ViewRoomFee].[ChangeStartTime],
	[ViewRoomFee].[NewStartTime],
	[ViewRoomFee].[BuildingArea],
	[ViewRoomFee].[EndTypeID],
	[ViewRoomFee].[TypeID],
	[ViewRoomFee].[ImportFeeID],
	[ViewRoomFee].[RealCost],
	[ViewRoomFee].[Discount],
	[ViewRoomFee].[OutDays],
	[ViewRoomFee].[FeeType],
	[ViewRoomFee].[SummaryUnitPrice],
	[ViewRoomFee].[CategoryID],
	[ViewRoomFee].[ChargeFee],
	[ViewRoomFee].[Balance],
	[ViewRoomFee].[TotalRealCost],
	[ViewRoomFee].[RestCost],
	[ViewRoomFee].[TotalDiscountCost],
	[ViewRoomFee].[TotalPoint],
	[ViewRoomFee].[IsReading],
	[ViewRoomFee].[ChargeTypeCount],
	[ViewRoomFee].[ImportCoefficient],
	[ViewRoomFee].[IsAllowImport],
	[ViewRoomFee].[OnlyOnceCharge],
	[ViewRoomFee].[NewEndTime],
	[ViewRoomFee].[StartPoint],
	[ViewRoomFee].[EndPoint],
	[ViewRoomFee].[FenTanCoefficient],
	[ViewRoomFee].[FunctionCoefficient],
	[ViewRoomFee].[CategoryNote],
	[ViewRoomFee].[RemarkNote],
	[ViewRoomFee].[WriteDate],
	[ViewRoomFee].[TimeAuto],
	[ViewRoomFee].[OrderBy],
	[ViewRoomFee].[FullName],
	[ViewRoomFee].[EndNumberCount],
	[ViewRoomFee].[ChargeBiaoID],
	[ViewRoomFee].[CalculateAreaType],
	[ViewRoomFee].[BuildOutArea],
	[ViewRoomFee].[GonTanArea],
	[ViewRoomFee].[FeeCategoryID],
	[ViewRoomFee].[CategoryName],
	[ViewRoomFee].[ContractID],
	[ViewRoomFee].[DiscountID],
	[ViewRoomFee].[DiscountName],
	[ViewRoomFee].[WeiYueActiveStartDate],
	[ViewRoomFee].[WeiYueActiveBeforeAfter],
	[ViewRoomFee].[WeiYueActiveCount],
	[ViewRoomFee].[WeiYueActiveDayMonth],
	[ViewRoomFee].[WeiYueEndDate],
	[ViewRoomFee].[WeiYueStartDate],
	[ViewRoomFee].[WeiYueBefore],
	[ViewRoomFee].[WeiYueDays],
	[ViewRoomFee].[DayGunLi],
	[ViewRoomFee].[ChargeWeiYueType],
	[ViewRoomFee].[WeiYuePercent],
	[ViewRoomFee].[DefaultOrder],
	[ViewRoomFee].[BuildInArea],
	[ViewRoomFee].[ChanQuanArea],
	[ViewRoomFee].[UseArea],
	[ViewRoomFee].[PeiTaoArea],
	[ViewRoomFee].[ContractArea],
	[ViewRoomFee].[CuiShouStartTime],
	[ViewRoomFee].[CuiShouEndTime],
	[ViewRoomFee].[UnitPrice],
	[ViewRoomFee].[StartPriceRange],
	[ViewRoomFee].[RelatedFeeID],
	[ViewRoomFee].[WeiYueTotalCost],
	[ViewRoomFee].[ChongDiChargeID],
	[ViewRoomFee].[SummaryChargeTypeCount],
	[ViewRoomFee].[EndNumberType],
	[ViewRoomFee].[AutoToMonthEnd],
	[ViewRoomFee].[DefaultChargeManID],
	[ViewRoomFee].[DefaultChargeManName],
	[ViewRoomFee].[ContractNo],
	[ViewRoomFee].[RentName],
	[ViewRoomFee].[RoomProperty],
	[ViewRoomFee].[ContractPhone],
	[ViewRoomFee].[ProjectBiaoID],
	[ViewRoomFee].[ImportRate],
	[ViewRoomFee].[ImportBiaoName],
	[ViewRoomFee].[ImportBiaoCategory],
	[ViewRoomFee].[ImportBiaoGuiGe],
	[ViewRoomFee].[ContractDivideID],
	[ViewRoomFee].[PriceRangeStartTime],
	[ViewRoomFee].[TotalUseCount],
	[ViewRoomFee].[TotalUseChaoBiaoCount],
	[ViewRoomFee].[ChargeFeeType],
	[ViewRoomFee].[AllParentID],
	[ViewRoomFee].[ContractName],
	[ViewRoomFee].[ReadyChargeTime],
	[ViewRoomFee].[Contract_RoomChargeID],
	[ViewRoomFee].[IsTempFee],
	[ViewRoomFee].[IsMeterFee],
	[ViewRoomFee].[IsImportFee],
	[ViewRoomFee].[IsCycleFee],
	[ViewRoomFee].[RoomFeeCoefficient],
	[ViewRoomFee].[RoomFeeWriteDate],
	[ViewRoomFee].[RoomFeeStartPoint],
	[ViewRoomFee].[RoomFeeEndPoint],
	[ViewRoomFee].[ChargeMeterProjectFeeID]
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
                return "ViewRoomFee";
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
		/// Gets a collection ViewRoomFee objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewRoomFee objects.</returns>
		public static EntityList<ViewRoomFee> GetViewRoomFees()
		{
			string commandText = @"
SELECT " + ViewRoomFee.SelectFieldList + "FROM [dbo].[ViewRoomFee] " + ViewRoomFee.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewRoomFee>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewRoomFee objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewRoomFee objects.</returns>
        public static EntityList<ViewRoomFee> GetViewRoomFees(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewRoomFee>(SelectFieldList, "FROM [dbo].[ViewRoomFee]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewRoomFee objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewRoomFee objects.</returns>
        public static EntityList<ViewRoomFee> GetViewRoomFees(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewRoomFee>(SelectFieldList, "FROM [dbo].[ViewRoomFee]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewRoomFee objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewRoomFeeCount()
        {
            return GetViewRoomFeeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewRoomFee objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewRoomFeeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewRoomFee] " + where;

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
		/// Gets a collection ViewRoomFee objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewRoomFee objects.</returns>
		protected static EntityList<ViewRoomFee> GetViewRoomFees(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewRoomFees(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomFee objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomFee objects.</returns>
		protected static EntityList<ViewRoomFee> GetViewRoomFees(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewRoomFees(string.Empty, where, parameters, ViewRoomFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomFee objects.</returns>
		protected static EntityList<ViewRoomFee> GetViewRoomFees(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewRoomFees(prefix, where, parameters, ViewRoomFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomFee objects.</returns>
		protected static EntityList<ViewRoomFee> GetViewRoomFees(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewRoomFees(string.Empty, where, parameters, ViewRoomFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomFee objects.</returns>
		protected static EntityList<ViewRoomFee> GetViewRoomFees(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewRoomFees(prefix, where, parameters, ViewRoomFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomFee objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewRoomFee objects.</returns>
		protected static EntityList<ViewRoomFee> GetViewRoomFees(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewRoomFee.SelectFieldList + "FROM [dbo].[ViewRoomFee] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewRoomFee>(reader);
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
        protected static EntityList<ViewRoomFee> GetViewRoomFees(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewRoomFee>(SelectFieldList, "FROM [dbo].[ViewRoomFee] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewRoomFeeProperties
		{
			public const string ID = "ID";
			public const string RoomID = "RoomID";
			public const string ChargeFeeUnitPrice = "ChargeFeeUnitPrice";
			public const string UseCount = "UseCount";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string Cost = "Cost";
			public const string Remark = "Remark";
			public const string AddTime = "AddTime";
			public const string IsCharged = "IsCharged";
			public const string ChargeFeeID = "ChargeFeeID";
			public const string RoomName = "RoomName";
			public const string ChargeID = "ChargeID";
			public const string IsStart = "IsStart";
			public const string Name = "Name";
			public const string SetStartTime = "SetStartTime";
			public const string ChangeUnitPrice = "ChangeUnitPrice";
			public const string ChangeStartTime = "ChangeStartTime";
			public const string NewStartTime = "NewStartTime";
			public const string BuildingArea = "BuildingArea";
			public const string EndTypeID = "EndTypeID";
			public const string TypeID = "TypeID";
			public const string ImportFeeID = "ImportFeeID";
			public const string RealCost = "RealCost";
			public const string Discount = "Discount";
			public const string OutDays = "OutDays";
			public const string FeeType = "FeeType";
			public const string SummaryUnitPrice = "SummaryUnitPrice";
			public const string CategoryID = "CategoryID";
			public const string ChargeFee = "ChargeFee";
			public const string Balance = "Balance";
			public const string TotalRealCost = "TotalRealCost";
			public const string RestCost = "RestCost";
			public const string TotalDiscountCost = "TotalDiscountCost";
			public const string TotalPoint = "TotalPoint";
			public const string IsReading = "IsReading";
			public const string ChargeTypeCount = "ChargeTypeCount";
			public const string ImportCoefficient = "ImportCoefficient";
			public const string IsAllowImport = "IsAllowImport";
			public const string OnlyOnceCharge = "OnlyOnceCharge";
			public const string NewEndTime = "NewEndTime";
			public const string StartPoint = "StartPoint";
			public const string EndPoint = "EndPoint";
			public const string FenTanCoefficient = "FenTanCoefficient";
			public const string FunctionCoefficient = "FunctionCoefficient";
			public const string CategoryNote = "CategoryNote";
			public const string RemarkNote = "RemarkNote";
			public const string WriteDate = "WriteDate";
			public const string TimeAuto = "TimeAuto";
			public const string OrderBy = "OrderBy";
			public const string FullName = "FullName";
			public const string EndNumberCount = "EndNumberCount";
			public const string ChargeBiaoID = "ChargeBiaoID";
			public const string CalculateAreaType = "CalculateAreaType";
			public const string BuildOutArea = "BuildOutArea";
			public const string GonTanArea = "GonTanArea";
			public const string FeeCategoryID = "FeeCategoryID";
			public const string CategoryName = "CategoryName";
			public const string ContractID = "ContractID";
			public const string DiscountID = "DiscountID";
			public const string DiscountName = "DiscountName";
			public const string WeiYueActiveStartDate = "WeiYueActiveStartDate";
			public const string WeiYueActiveBeforeAfter = "WeiYueActiveBeforeAfter";
			public const string WeiYueActiveCount = "WeiYueActiveCount";
			public const string WeiYueActiveDayMonth = "WeiYueActiveDayMonth";
			public const string WeiYueEndDate = "WeiYueEndDate";
			public const string WeiYueStartDate = "WeiYueStartDate";
			public const string WeiYueBefore = "WeiYueBefore";
			public const string WeiYueDays = "WeiYueDays";
			public const string DayGunLi = "DayGunLi";
			public const string ChargeWeiYueType = "ChargeWeiYueType";
			public const string WeiYuePercent = "WeiYuePercent";
			public const string DefaultOrder = "DefaultOrder";
			public const string BuildInArea = "BuildInArea";
			public const string ChanQuanArea = "ChanQuanArea";
			public const string UseArea = "UseArea";
			public const string PeiTaoArea = "PeiTaoArea";
			public const string ContractArea = "ContractArea";
			public const string CuiShouStartTime = "CuiShouStartTime";
			public const string CuiShouEndTime = "CuiShouEndTime";
			public const string UnitPrice = "UnitPrice";
			public const string StartPriceRange = "StartPriceRange";
			public const string RelatedFeeID = "RelatedFeeID";
			public const string WeiYueTotalCost = "WeiYueTotalCost";
			public const string ChongDiChargeID = "ChongDiChargeID";
			public const string SummaryChargeTypeCount = "SummaryChargeTypeCount";
			public const string EndNumberType = "EndNumberType";
			public const string AutoToMonthEnd = "AutoToMonthEnd";
			public const string DefaultChargeManID = "DefaultChargeManID";
			public const string DefaultChargeManName = "DefaultChargeManName";
			public const string ContractNo = "ContractNo";
			public const string RentName = "RentName";
			public const string RoomProperty = "RoomProperty";
			public const string ContractPhone = "ContractPhone";
			public const string ProjectBiaoID = "ProjectBiaoID";
			public const string ImportRate = "ImportRate";
			public const string ImportBiaoName = "ImportBiaoName";
			public const string ImportBiaoCategory = "ImportBiaoCategory";
			public const string ImportBiaoGuiGe = "ImportBiaoGuiGe";
			public const string ContractDivideID = "ContractDivideID";
			public const string PriceRangeStartTime = "PriceRangeStartTime";
			public const string TotalUseCount = "TotalUseCount";
			public const string TotalUseChaoBiaoCount = "TotalUseChaoBiaoCount";
			public const string ChargeFeeType = "ChargeFeeType";
			public const string AllParentID = "AllParentID";
			public const string ContractName = "ContractName";
			public const string ReadyChargeTime = "ReadyChargeTime";
			public const string Contract_RoomChargeID = "Contract_RoomChargeID";
			public const string IsTempFee = "IsTempFee";
			public const string IsMeterFee = "IsMeterFee";
			public const string IsImportFee = "IsImportFee";
			public const string IsCycleFee = "IsCycleFee";
			public const string RoomFeeCoefficient = "RoomFeeCoefficient";
			public const string RoomFeeWriteDate = "RoomFeeWriteDate";
			public const string RoomFeeStartPoint = "RoomFeeStartPoint";
			public const string RoomFeeEndPoint = "RoomFeeEndPoint";
			public const string ChargeMeterProjectFeeID = "ChargeMeterProjectFeeID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"ChargeFeeUnitPrice" , "decimal:"},
    			 {"UseCount" , "decimal:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"Cost" , "decimal:"},
    			 {"Remark" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"IsCharged" , "bool:"},
    			 {"ChargeFeeID" , "int:"},
    			 {"RoomName" , "string:"},
    			 {"ChargeID" , "int:"},
    			 {"IsStart" , "bool:"},
    			 {"Name" , "string:"},
    			 {"SetStartTime" , "DateTime:"},
    			 {"ChangeUnitPrice" , "decimal:"},
    			 {"ChangeStartTime" , "DateTime:"},
    			 {"NewStartTime" , "DateTime:"},
    			 {"BuildingArea" , "decimal:"},
    			 {"EndTypeID" , "int:"},
    			 {"TypeID" , "int:"},
    			 {"ImportFeeID" , "int:"},
    			 {"RealCost" , "decimal:"},
    			 {"Discount" , "decimal:"},
    			 {"OutDays" , "int:"},
    			 {"FeeType" , "int:"},
    			 {"SummaryUnitPrice" , "decimal:"},
    			 {"CategoryID" , "int:"},
    			 {"ChargeFee" , "decimal:"},
    			 {"Balance" , "decimal:"},
    			 {"TotalRealCost" , "decimal:"},
    			 {"RestCost" , "decimal:"},
    			 {"TotalDiscountCost" , "decimal:"},
    			 {"TotalPoint" , "decimal:"},
    			 {"IsReading" , "bool:"},
    			 {"ChargeTypeCount" , "int:"},
    			 {"ImportCoefficient" , "decimal:"},
    			 {"IsAllowImport" , "bool:"},
    			 {"OnlyOnceCharge" , "bool:"},
    			 {"NewEndTime" , "DateTime:"},
    			 {"StartPoint" , "decimal:"},
    			 {"EndPoint" , "decimal:"},
    			 {"FenTanCoefficient" , "decimal:"},
    			 {"FunctionCoefficient" , "decimal:"},
    			 {"CategoryNote" , "string:"},
    			 {"RemarkNote" , "string:"},
    			 {"WriteDate" , "DateTime:"},
    			 {"TimeAuto" , "bool:"},
    			 {"OrderBy" , "int:"},
    			 {"FullName" , "string:"},
    			 {"EndNumberCount" , "int:"},
    			 {"ChargeBiaoID" , "int:"},
    			 {"CalculateAreaType" , "string:"},
    			 {"BuildOutArea" , "decimal:"},
    			 {"GonTanArea" , "decimal:"},
    			 {"FeeCategoryID" , "int:"},
    			 {"CategoryName" , "string:"},
    			 {"ContractID" , "int:"},
    			 {"DiscountID" , "int:"},
    			 {"DiscountName" , "string:"},
    			 {"WeiYueActiveStartDate" , "string:"},
    			 {"WeiYueActiveBeforeAfter" , "string:"},
    			 {"WeiYueActiveCount" , "int:"},
    			 {"WeiYueActiveDayMonth" , "string:"},
    			 {"WeiYueEndDate" , "string:"},
    			 {"WeiYueStartDate" , "string:"},
    			 {"WeiYueBefore" , "string:"},
    			 {"WeiYueDays" , "int:"},
    			 {"DayGunLi" , "bool:"},
    			 {"ChargeWeiYueType" , "int:"},
    			 {"WeiYuePercent" , "decimal:"},
    			 {"DefaultOrder" , "string:"},
    			 {"BuildInArea" , "decimal:"},
    			 {"ChanQuanArea" , "decimal:"},
    			 {"UseArea" , "decimal:"},
    			 {"PeiTaoArea" , "decimal:"},
    			 {"ContractArea" , "decimal:"},
    			 {"CuiShouStartTime" , "DateTime:"},
    			 {"CuiShouEndTime" , "DateTime:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"StartPriceRange" , "bool:"},
    			 {"RelatedFeeID" , "int:"},
    			 {"WeiYueTotalCost" , "decimal:"},
    			 {"ChongDiChargeID" , "int:"},
    			 {"SummaryChargeTypeCount" , "int:"},
    			 {"EndNumberType" , "int:"},
    			 {"AutoToMonthEnd" , "bool:"},
    			 {"DefaultChargeManID" , "int:"},
    			 {"DefaultChargeManName" , "string:"},
    			 {"ContractNo" , "string:"},
    			 {"RentName" , "string:"},
    			 {"RoomProperty" , "string:"},
    			 {"ContractPhone" , "string:"},
    			 {"ProjectBiaoID" , "int:"},
    			 {"ImportRate" , "decimal:"},
    			 {"ImportBiaoName" , "string:"},
    			 {"ImportBiaoCategory" , "string:"},
    			 {"ImportBiaoGuiGe" , "string:"},
    			 {"ContractDivideID" , "int:"},
    			 {"PriceRangeStartTime" , "DateTime:"},
    			 {"TotalUseCount" , "decimal:"},
    			 {"TotalUseChaoBiaoCount" , "decimal:"},
    			 {"ChargeFeeType" , "int:"},
    			 {"AllParentID" , "string:"},
    			 {"ContractName" , "string:"},
    			 {"ReadyChargeTime" , "DateTime:"},
    			 {"Contract_RoomChargeID" , "int:"},
    			 {"IsTempFee" , "bool:"},
    			 {"IsMeterFee" , "bool:"},
    			 {"IsImportFee" , "bool:"},
    			 {"IsCycleFee" , "bool:"},
    			 {"RoomFeeCoefficient" , "decimal:"},
    			 {"RoomFeeWriteDate" , "DateTime:"},
    			 {"RoomFeeStartPoint" , "decimal:"},
    			 {"RoomFeeEndPoint" , "decimal:"},
    			 {"ChargeMeterProjectFeeID" , "int:"},
            };
		}
		#endregion
	}
}
