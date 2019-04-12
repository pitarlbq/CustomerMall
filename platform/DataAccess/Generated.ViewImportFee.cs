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
	/// This object represents the properties and methods of a ViewImportFee.
	/// </summary>
	[Serializable()]
	public partial class ViewImportFee 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargedHistoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChargedHistoryID
		{
			[DebuggerStepThrough()]
			get { return this._chargedHistoryID; }
            protected set { this._chargedHistoryID = value;}
		}
		
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
		private string _chargeDate = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeDate
		{
			[DebuggerStepThrough()]
			get { return this._chargeDate; }
            protected set { this._chargeDate = value;}
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
		private decimal _totalPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal TotalPrice
		{
			[DebuggerStepThrough()]
			get { return this._totalPrice; }
            protected set { this._totalPrice = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _writeDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime WriteDate
		{
			[DebuggerStepThrough()]
			get { return this._writeDate; }
            protected set { this._writeDate = value;}
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
		private int _chargeStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ChargeStatus
		{
			[DebuggerStepThrough()]
			get { return this._chargeStatus; }
            protected set { this._chargeStatus = value;}
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
		private decimal _importReducePoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ImportReducePoint
		{
			[DebuggerStepThrough()]
			get { return this._importReducePoint; }
            protected set { this._importReducePoint = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _importChargeRoomNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ImportChargeRoomNo
		{
			[DebuggerStepThrough()]
			get { return this._importChargeRoomNo; }
            protected set { this._importChargeRoomNo = value;}
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
		private decimal _coefficient = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal Coefficient
		{
			[DebuggerStepThrough()]
			get { return this._coefficient; }
            protected set { this._coefficient = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _unit = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Unit
		{
			[DebuggerStepThrough()]
			get { return this._unit; }
            protected set { this._unit = value;}
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
		private DateTime _chargeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ChargeTime
		{
			[DebuggerStepThrough()]
			get { return this._chargeTime; }
            protected set { this._chargeTime = value;}
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
		private int _notChargeFee = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int NotChargeFee
		{
			[DebuggerStepThrough()]
			get { return this._notChargeFee; }
            protected set { this._notChargeFee = value;}
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
		private string _biaoCategory = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BiaoCategory
		{
			[DebuggerStepThrough()]
			get { return this._biaoCategory; }
            protected set { this._biaoCategory = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _biaoName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BiaoName
		{
			[DebuggerStepThrough()]
			get { return this._biaoName; }
            protected set { this._biaoName = value;}
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
		private int _priceRangeCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PriceRangeCount
		{
			[DebuggerStepThrough()]
			get { return this._priceRangeCount; }
            protected set { this._priceRangeCount = value;}
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
		private int _roomFeeOrderID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RoomFeeOrderID
		{
			[DebuggerStepThrough()]
			get { return this._roomFeeOrderID; }
            protected set { this._roomFeeOrderID = value;}
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
		private int _historyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int HistoryID
		{
			[DebuggerStepThrough()]
			get { return this._historyID; }
            protected set { this._historyID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _historyUseCount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal HistoryUseCount
		{
			[DebuggerStepThrough()]
			get { return this._historyUseCount; }
            protected set { this._historyUseCount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _historyUnitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal HistoryUnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._historyUnitPrice; }
            protected set { this._historyUnitPrice = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _historyRealCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal HistoryRealCost
		{
			[DebuggerStepThrough()]
			get { return this._historyRealCost; }
            protected set { this._historyRealCost = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewImportFee() { }
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
	[ViewImportFee].[ChargedHistoryID],
	[ViewImportFee].[ID],
	[ViewImportFee].[RoomID],
	[ViewImportFee].[ChargeDate],
	[ViewImportFee].[ChargeID],
	[ViewImportFee].[StartPoint],
	[ViewImportFee].[EndPoint],
	[ViewImportFee].[TotalPoint],
	[ViewImportFee].[UnitPrice],
	[ViewImportFee].[TotalPrice],
	[ViewImportFee].[WriteDate],
	[ViewImportFee].[StartTime],
	[ViewImportFee].[EndTime],
	[ViewImportFee].[AddTime],
	[ViewImportFee].[ChargeStatus],
	[ViewImportFee].[ImportCoefficient],
	[ViewImportFee].[ImportBiaoCategory],
	[ViewImportFee].[ImportBiaoName],
	[ViewImportFee].[ChargeBiaoID],
	[ViewImportFee].[ProjectBiaoID],
	[ViewImportFee].[ImportBiaoGuiGe],
	[ViewImportFee].[ImportRate],
	[ViewImportFee].[ImportReducePoint],
	[ViewImportFee].[ImportChargeRoomNo],
	[ViewImportFee].[ChargeName],
	[ViewImportFee].[Coefficient],
	[ViewImportFee].[Unit],
	[ViewImportFee].[SummaryUnitPrice],
	[ViewImportFee].[Name],
	[ViewImportFee].[FullName],
	[ViewImportFee].[FeeType],
	[ViewImportFee].[IsReading],
	[ViewImportFee].[PrintNumber],
	[ViewImportFee].[ChargeMan],
	[ViewImportFee].[ChargeTime],
	[ViewImportFee].[ChageType1],
	[ViewImportFee].[NotChargeFee],
	[ViewImportFee].[AllParentID],
	[ViewImportFee].[BiaoCategory],
	[ViewImportFee].[BiaoName],
	[ViewImportFee].[DefaultOrder],
	[ViewImportFee].[PriceRangeCount],
	[ViewImportFee].[EndNumberCount],
	[ViewImportFee].[StartPriceRange],
	[ViewImportFee].[PriceRangeStartTime],
	[ViewImportFee].[TotalUseCount],
	[ViewImportFee].[RoomFeeOrderID],
	[ViewImportFee].[RestCost],
	[ViewImportFee].[Remark],
	[ViewImportFee].[PrintID],
	[ViewImportFee].[HistoryID],
	[ViewImportFee].[HistoryUseCount],
	[ViewImportFee].[HistoryUnitPrice],
	[ViewImportFee].[HistoryRealCost]
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
                return "ViewImportFee";
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
		/// Gets a collection ViewImportFee objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewImportFee objects.</returns>
		public static EntityList<ViewImportFee> GetViewImportFees()
		{
			string commandText = @"
SELECT " + ViewImportFee.SelectFieldList + "FROM [dbo].[ViewImportFee] " + ViewImportFee.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewImportFee>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewImportFee objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewImportFee objects.</returns>
        public static EntityList<ViewImportFee> GetViewImportFees(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewImportFee>(SelectFieldList, "FROM [dbo].[ViewImportFee]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewImportFee objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewImportFee objects.</returns>
        public static EntityList<ViewImportFee> GetViewImportFees(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewImportFee>(SelectFieldList, "FROM [dbo].[ViewImportFee]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewImportFee objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewImportFeeCount()
        {
            return GetViewImportFeeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewImportFee objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewImportFeeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewImportFee] " + where;

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
		/// Gets a collection ViewImportFee objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewImportFee objects.</returns>
		protected static EntityList<ViewImportFee> GetViewImportFees(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewImportFees(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewImportFee objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewImportFee objects.</returns>
		protected static EntityList<ViewImportFee> GetViewImportFees(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewImportFees(string.Empty, where, parameters, ViewImportFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewImportFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewImportFee objects.</returns>
		protected static EntityList<ViewImportFee> GetViewImportFees(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewImportFees(prefix, where, parameters, ViewImportFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewImportFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewImportFee objects.</returns>
		protected static EntityList<ViewImportFee> GetViewImportFees(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewImportFees(string.Empty, where, parameters, ViewImportFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewImportFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewImportFee objects.</returns>
		protected static EntityList<ViewImportFee> GetViewImportFees(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewImportFees(prefix, where, parameters, ViewImportFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewImportFee objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewImportFee objects.</returns>
		protected static EntityList<ViewImportFee> GetViewImportFees(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewImportFee.SelectFieldList + "FROM [dbo].[ViewImportFee] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewImportFee>(reader);
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
        protected static EntityList<ViewImportFee> GetViewImportFees(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewImportFee>(SelectFieldList, "FROM [dbo].[ViewImportFee] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewImportFeeProperties
		{
			public const string ChargedHistoryID = "ChargedHistoryID";
			public const string ID = "ID";
			public const string RoomID = "RoomID";
			public const string ChargeDate = "ChargeDate";
			public const string ChargeID = "ChargeID";
			public const string StartPoint = "StartPoint";
			public const string EndPoint = "EndPoint";
			public const string TotalPoint = "TotalPoint";
			public const string UnitPrice = "UnitPrice";
			public const string TotalPrice = "TotalPrice";
			public const string WriteDate = "WriteDate";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string AddTime = "AddTime";
			public const string ChargeStatus = "ChargeStatus";
			public const string ImportCoefficient = "ImportCoefficient";
			public const string ImportBiaoCategory = "ImportBiaoCategory";
			public const string ImportBiaoName = "ImportBiaoName";
			public const string ChargeBiaoID = "ChargeBiaoID";
			public const string ProjectBiaoID = "ProjectBiaoID";
			public const string ImportBiaoGuiGe = "ImportBiaoGuiGe";
			public const string ImportRate = "ImportRate";
			public const string ImportReducePoint = "ImportReducePoint";
			public const string ImportChargeRoomNo = "ImportChargeRoomNo";
			public const string ChargeName = "ChargeName";
			public const string Coefficient = "Coefficient";
			public const string Unit = "Unit";
			public const string SummaryUnitPrice = "SummaryUnitPrice";
			public const string Name = "Name";
			public const string FullName = "FullName";
			public const string FeeType = "FeeType";
			public const string IsReading = "IsReading";
			public const string PrintNumber = "PrintNumber";
			public const string ChargeMan = "ChargeMan";
			public const string ChargeTime = "ChargeTime";
			public const string ChageType1 = "ChageType1";
			public const string NotChargeFee = "NotChargeFee";
			public const string AllParentID = "AllParentID";
			public const string BiaoCategory = "BiaoCategory";
			public const string BiaoName = "BiaoName";
			public const string DefaultOrder = "DefaultOrder";
			public const string PriceRangeCount = "PriceRangeCount";
			public const string EndNumberCount = "EndNumberCount";
			public const string StartPriceRange = "StartPriceRange";
			public const string PriceRangeStartTime = "PriceRangeStartTime";
			public const string TotalUseCount = "TotalUseCount";
			public const string RoomFeeOrderID = "RoomFeeOrderID";
			public const string RestCost = "RestCost";
			public const string Remark = "Remark";
			public const string PrintID = "PrintID";
			public const string HistoryID = "HistoryID";
			public const string HistoryUseCount = "HistoryUseCount";
			public const string HistoryUnitPrice = "HistoryUnitPrice";
			public const string HistoryRealCost = "HistoryRealCost";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ChargedHistoryID" , "int:"},
    			 {"ID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"ChargeDate" , "string:"},
    			 {"ChargeID" , "int:"},
    			 {"StartPoint" , "decimal:"},
    			 {"EndPoint" , "decimal:"},
    			 {"TotalPoint" , "decimal:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"TotalPrice" , "decimal:"},
    			 {"WriteDate" , "DateTime:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"AddTime" , "DateTime:"},
    			 {"ChargeStatus" , "int:"},
    			 {"ImportCoefficient" , "decimal:"},
    			 {"ImportBiaoCategory" , "string:"},
    			 {"ImportBiaoName" , "string:"},
    			 {"ChargeBiaoID" , "int:"},
    			 {"ProjectBiaoID" , "int:"},
    			 {"ImportBiaoGuiGe" , "string:"},
    			 {"ImportRate" , "decimal:"},
    			 {"ImportReducePoint" , "decimal:"},
    			 {"ImportChargeRoomNo" , "string:"},
    			 {"ChargeName" , "string:"},
    			 {"Coefficient" , "decimal:"},
    			 {"Unit" , "string:"},
    			 {"SummaryUnitPrice" , "decimal:"},
    			 {"Name" , "string:"},
    			 {"FullName" , "string:"},
    			 {"FeeType" , "int:"},
    			 {"IsReading" , "bool:"},
    			 {"PrintNumber" , "string:"},
    			 {"ChargeMan" , "string:"},
    			 {"ChargeTime" , "DateTime:"},
    			 {"ChageType1" , "int:"},
    			 {"NotChargeFee" , "int:"},
    			 {"AllParentID" , "string:"},
    			 {"BiaoCategory" , "string:"},
    			 {"BiaoName" , "string:"},
    			 {"DefaultOrder" , "string:"},
    			 {"PriceRangeCount" , "int:"},
    			 {"EndNumberCount" , "int:"},
    			 {"StartPriceRange" , "bool:"},
    			 {"PriceRangeStartTime" , "DateTime:"},
    			 {"TotalUseCount" , "decimal:"},
    			 {"RoomFeeOrderID" , "int:"},
    			 {"RestCost" , "decimal:"},
    			 {"Remark" , "string:"},
    			 {"PrintID" , "int:"},
    			 {"HistoryID" , "int:"},
    			 {"HistoryUseCount" , "decimal:"},
    			 {"HistoryUnitPrice" , "decimal:"},
    			 {"HistoryRealCost" , "decimal:"},
            };
		}
		#endregion
	}
}
