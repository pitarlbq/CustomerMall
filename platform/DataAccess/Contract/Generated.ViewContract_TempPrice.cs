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
	/// This object represents the properties and methods of a ViewContract_TempPrice.
	/// </summary>
	[Serializable()]
	public partial class ViewContract_TempPrice 
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
		private decimal _basicPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal BasicPrice
		{
			[DebuggerStepThrough()]
			get { return this._basicPrice; }
            protected set { this._basicPrice = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _basicStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime BasicStartTime
		{
			[DebuggerStepThrough()]
			get { return this._basicStartTime; }
            protected set { this._basicStartTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _basicEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime BasicEndTime
		{
			[DebuggerStepThrough()]
			get { return this._basicEndTime; }
            protected set { this._basicEndTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _calculateType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CalculateType
		{
			[DebuggerStepThrough()]
			get { return this._calculateType; }
            protected set { this._calculateType = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _calculatePercent = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal CalculatePercent
		{
			[DebuggerStepThrough()]
			get { return this._calculatePercent; }
            protected set { this._calculatePercent = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _calculateAmount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal CalculateAmount
		{
			[DebuggerStepThrough()]
			get { return this._calculateAmount; }
            protected set { this._calculateAmount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _calculatePrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal CalculatePrice
		{
			[DebuggerStepThrough()]
			get { return this._calculatePrice; }
            protected set { this._calculatePrice = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _calculateStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime CalculateStartTime
		{
			[DebuggerStepThrough()]
			get { return this._calculateStartTime; }
            protected set { this._calculateStartTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _calculateEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime CalculateEndTime
		{
			[DebuggerStepThrough()]
			get { return this._calculateEndTime; }
            protected set { this._calculateEndTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _gUID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string GUID
		{
			[DebuggerStepThrough()]
			get { return this._gUID; }
            protected set { this._gUID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _calculateCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal CalculateCost
		{
			[DebuggerStepThrough()]
			get { return this._calculateCost; }
            protected set { this._calculateCost = value;}
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
            protected set { this._addTime = value;}
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
		private decimal _roomUseCount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RoomUseCount
		{
			[DebuggerStepThrough()]
			get { return this._roomUseCount; }
            protected set { this._roomUseCount = value;}
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
		private int _roomID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RoomID
		{
			[DebuggerStepThrough()]
			get { return this._roomID; }
            protected set { this._roomID = value;}
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
		private int _ruleID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RuleID
		{
			[DebuggerStepThrough()]
			get { return this._ruleID; }
            protected set { this._ruleID = value;}
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
		private int _endNumber = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int EndNumber
		{
			[DebuggerStepThrough()]
			get { return this._endNumber; }
            protected set { this._endNumber = value;}
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
		private DateTime _summaryStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime SummaryStartTime
		{
			[DebuggerStepThrough()]
			get { return this._summaryStartTime; }
            protected set { this._summaryStartTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _summaryEndStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime SummaryEndStartTime
		{
			[DebuggerStepThrough()]
			get { return this._summaryEndStartTime; }
            protected set { this._summaryEndStartTime = value;}
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
		private bool _isOrderFeeOn = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsOrderFeeOn
		{
			[DebuggerStepThrough()]
			get { return this._isOrderFeeOn; }
            protected set { this._isOrderFeeOn = value;}
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
		private string _relateCharges = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelateCharges
		{
			[DebuggerStepThrough()]
			get { return this._relateCharges; }
            protected set { this._relateCharges = value;}
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
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewContract_TempPrice() { }
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
	[ViewContract_TempPrice].[ID],
	[ViewContract_TempPrice].[BasicPrice],
	[ViewContract_TempPrice].[BasicStartTime],
	[ViewContract_TempPrice].[BasicEndTime],
	[ViewContract_TempPrice].[CalculateType],
	[ViewContract_TempPrice].[CalculatePercent],
	[ViewContract_TempPrice].[CalculateAmount],
	[ViewContract_TempPrice].[CalculatePrice],
	[ViewContract_TempPrice].[CalculateStartTime],
	[ViewContract_TempPrice].[CalculateEndTime],
	[ViewContract_TempPrice].[GUID],
	[ViewContract_TempPrice].[CalculateCost],
	[ViewContract_TempPrice].[AddTime],
	[ViewContract_TempPrice].[ReadyChargeTime],
	[ViewContract_TempPrice].[RoomUseCount],
	[ViewContract_TempPrice].[ChargeID],
	[ViewContract_TempPrice].[RoomID],
	[ViewContract_TempPrice].[ChargeName],
	[ViewContract_TempPrice].[TypeID],
	[ViewContract_TempPrice].[OrderBy],
	[ViewContract_TempPrice].[CategoryID],
	[ViewContract_TempPrice].[RuleID],
	[ViewContract_TempPrice].[EndTypeID],
	[ViewContract_TempPrice].[EndNumber],
	[ViewContract_TempPrice].[SummaryUnitPrice],
	[ViewContract_TempPrice].[Unit],
	[ViewContract_TempPrice].[Coefficient],
	[ViewContract_TempPrice].[IsReading],
	[ViewContract_TempPrice].[EndNumberCount],
	[ViewContract_TempPrice].[IsAllowImport],
	[ViewContract_TempPrice].[SummaryStartTime],
	[ViewContract_TempPrice].[SummaryEndStartTime],
	[ViewContract_TempPrice].[SummaryChargeTypeCount],
	[ViewContract_TempPrice].[EndNumberType],
	[ViewContract_TempPrice].[AutoToMonthEnd],
	[ViewContract_TempPrice].[BiaoCategory],
	[ViewContract_TempPrice].[BiaoName],
	[ViewContract_TempPrice].[TimeAuto],
	[ViewContract_TempPrice].[IsOrderFeeOn],
	[ViewContract_TempPrice].[WeiYuePercent],
	[ViewContract_TempPrice].[RelateCharges],
	[ViewContract_TempPrice].[ChargeWeiYueType],
	[ViewContract_TempPrice].[DayGunLi],
	[ViewContract_TempPrice].[WeiYueStartDate],
	[ViewContract_TempPrice].[WeiYueBefore],
	[ViewContract_TempPrice].[WeiYueDays],
	[ViewContract_TempPrice].[CalculateAreaType],
	[ViewContract_TempPrice].[Name],
	[ViewContract_TempPrice].[FullName],
	[ViewContract_TempPrice].[BuildOutArea],
	[ViewContract_TempPrice].[GonTanArea],
	[ViewContract_TempPrice].[FeeType],
	[ViewContract_TempPrice].[FenTanCoefficient],
	[ViewContract_TempPrice].[BuildingArea],
	[ViewContract_TempPrice].[ContractArea],
	[ViewContract_TempPrice].[ChanQuanArea],
	[ViewContract_TempPrice].[BuildInArea],
	[ViewContract_TempPrice].[UseArea],
	[ViewContract_TempPrice].[PeiTaoArea]
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
                return "ViewContract_TempPrice";
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
		/// Gets a collection ViewContract_TempPrice objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewContract_TempPrice objects.</returns>
		public static EntityList<ViewContract_TempPrice> GetViewContract_TempPrices()
		{
			string commandText = @"
SELECT " + ViewContract_TempPrice.SelectFieldList + "FROM [dbo].[ViewContract_TempPrice] " + ViewContract_TempPrice.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewContract_TempPrice>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewContract_TempPrice objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewContract_TempPrice objects.</returns>
        public static EntityList<ViewContract_TempPrice> GetViewContract_TempPrices(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewContract_TempPrice>(SelectFieldList, "FROM [dbo].[ViewContract_TempPrice]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewContract_TempPrice objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewContract_TempPrice objects.</returns>
        public static EntityList<ViewContract_TempPrice> GetViewContract_TempPrices(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewContract_TempPrice>(SelectFieldList, "FROM [dbo].[ViewContract_TempPrice]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewContract_TempPrice objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewContract_TempPriceCount()
        {
            return GetViewContract_TempPriceCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewContract_TempPrice objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewContract_TempPriceCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewContract_TempPrice] " + where;

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
		/// Gets a collection ViewContract_TempPrice objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewContract_TempPrice objects.</returns>
		protected static EntityList<ViewContract_TempPrice> GetViewContract_TempPrices(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewContract_TempPrices(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewContract_TempPrice objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewContract_TempPrice objects.</returns>
		protected static EntityList<ViewContract_TempPrice> GetViewContract_TempPrices(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewContract_TempPrices(string.Empty, where, parameters, ViewContract_TempPrice.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewContract_TempPrice objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewContract_TempPrice objects.</returns>
		protected static EntityList<ViewContract_TempPrice> GetViewContract_TempPrices(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewContract_TempPrices(prefix, where, parameters, ViewContract_TempPrice.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewContract_TempPrice objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewContract_TempPrice objects.</returns>
		protected static EntityList<ViewContract_TempPrice> GetViewContract_TempPrices(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewContract_TempPrices(string.Empty, where, parameters, ViewContract_TempPrice.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewContract_TempPrice objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewContract_TempPrice objects.</returns>
		protected static EntityList<ViewContract_TempPrice> GetViewContract_TempPrices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewContract_TempPrices(prefix, where, parameters, ViewContract_TempPrice.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewContract_TempPrice objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewContract_TempPrice objects.</returns>
		protected static EntityList<ViewContract_TempPrice> GetViewContract_TempPrices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewContract_TempPrice.SelectFieldList + "FROM [dbo].[ViewContract_TempPrice] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewContract_TempPrice>(reader);
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
        protected static EntityList<ViewContract_TempPrice> GetViewContract_TempPrices(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewContract_TempPrice>(SelectFieldList, "FROM [dbo].[ViewContract_TempPrice] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewContract_TempPriceProperties
		{
			public const string ID = "ID";
			public const string BasicPrice = "BasicPrice";
			public const string BasicStartTime = "BasicStartTime";
			public const string BasicEndTime = "BasicEndTime";
			public const string CalculateType = "CalculateType";
			public const string CalculatePercent = "CalculatePercent";
			public const string CalculateAmount = "CalculateAmount";
			public const string CalculatePrice = "CalculatePrice";
			public const string CalculateStartTime = "CalculateStartTime";
			public const string CalculateEndTime = "CalculateEndTime";
			public const string GUID = "GUID";
			public const string CalculateCost = "CalculateCost";
			public const string AddTime = "AddTime";
			public const string ReadyChargeTime = "ReadyChargeTime";
			public const string RoomUseCount = "RoomUseCount";
			public const string ChargeID = "ChargeID";
			public const string RoomID = "RoomID";
			public const string ChargeName = "ChargeName";
			public const string TypeID = "TypeID";
			public const string OrderBy = "OrderBy";
			public const string CategoryID = "CategoryID";
			public const string RuleID = "RuleID";
			public const string EndTypeID = "EndTypeID";
			public const string EndNumber = "EndNumber";
			public const string SummaryUnitPrice = "SummaryUnitPrice";
			public const string Unit = "Unit";
			public const string Coefficient = "Coefficient";
			public const string IsReading = "IsReading";
			public const string EndNumberCount = "EndNumberCount";
			public const string IsAllowImport = "IsAllowImport";
			public const string SummaryStartTime = "SummaryStartTime";
			public const string SummaryEndStartTime = "SummaryEndStartTime";
			public const string SummaryChargeTypeCount = "SummaryChargeTypeCount";
			public const string EndNumberType = "EndNumberType";
			public const string AutoToMonthEnd = "AutoToMonthEnd";
			public const string BiaoCategory = "BiaoCategory";
			public const string BiaoName = "BiaoName";
			public const string TimeAuto = "TimeAuto";
			public const string IsOrderFeeOn = "IsOrderFeeOn";
			public const string WeiYuePercent = "WeiYuePercent";
			public const string RelateCharges = "RelateCharges";
			public const string ChargeWeiYueType = "ChargeWeiYueType";
			public const string DayGunLi = "DayGunLi";
			public const string WeiYueStartDate = "WeiYueStartDate";
			public const string WeiYueBefore = "WeiYueBefore";
			public const string WeiYueDays = "WeiYueDays";
			public const string CalculateAreaType = "CalculateAreaType";
			public const string Name = "Name";
			public const string FullName = "FullName";
			public const string BuildOutArea = "BuildOutArea";
			public const string GonTanArea = "GonTanArea";
			public const string FeeType = "FeeType";
			public const string FenTanCoefficient = "FenTanCoefficient";
			public const string BuildingArea = "BuildingArea";
			public const string ContractArea = "ContractArea";
			public const string ChanQuanArea = "ChanQuanArea";
			public const string BuildInArea = "BuildInArea";
			public const string UseArea = "UseArea";
			public const string PeiTaoArea = "PeiTaoArea";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"BasicPrice" , "decimal:"},
    			 {"BasicStartTime" , "DateTime:"},
    			 {"BasicEndTime" , "DateTime:"},
    			 {"CalculateType" , "string:"},
    			 {"CalculatePercent" , "decimal:"},
    			 {"CalculateAmount" , "decimal:"},
    			 {"CalculatePrice" , "decimal:"},
    			 {"CalculateStartTime" , "DateTime:"},
    			 {"CalculateEndTime" , "DateTime:"},
    			 {"GUID" , "string:"},
    			 {"CalculateCost" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"ReadyChargeTime" , "DateTime:"},
    			 {"RoomUseCount" , "decimal:"},
    			 {"ChargeID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"ChargeName" , "string:"},
    			 {"TypeID" , "int:"},
    			 {"OrderBy" , "int:"},
    			 {"CategoryID" , "int:"},
    			 {"RuleID" , "int:"},
    			 {"EndTypeID" , "int:"},
    			 {"EndNumber" , "int:"},
    			 {"SummaryUnitPrice" , "decimal:"},
    			 {"Unit" , "string:"},
    			 {"Coefficient" , "decimal:"},
    			 {"IsReading" , "bool:"},
    			 {"EndNumberCount" , "int:"},
    			 {"IsAllowImport" , "bool:"},
    			 {"SummaryStartTime" , "DateTime:"},
    			 {"SummaryEndStartTime" , "DateTime:"},
    			 {"SummaryChargeTypeCount" , "int:"},
    			 {"EndNumberType" , "int:"},
    			 {"AutoToMonthEnd" , "bool:"},
    			 {"BiaoCategory" , "string:"},
    			 {"BiaoName" , "string:"},
    			 {"TimeAuto" , "bool:"},
    			 {"IsOrderFeeOn" , "bool:"},
    			 {"WeiYuePercent" , "decimal:"},
    			 {"RelateCharges" , "string:"},
    			 {"ChargeWeiYueType" , "int:"},
    			 {"DayGunLi" , "bool:"},
    			 {"WeiYueStartDate" , "string:"},
    			 {"WeiYueBefore" , "string:"},
    			 {"WeiYueDays" , "int:"},
    			 {"CalculateAreaType" , "string:"},
    			 {"Name" , "string:"},
    			 {"FullName" , "string:"},
    			 {"BuildOutArea" , "decimal:"},
    			 {"GonTanArea" , "decimal:"},
    			 {"FeeType" , "int:"},
    			 {"FenTanCoefficient" , "decimal:"},
    			 {"BuildingArea" , "decimal:"},
    			 {"ContractArea" , "decimal:"},
    			 {"ChanQuanArea" , "decimal:"},
    			 {"BuildInArea" , "decimal:"},
    			 {"UseArea" , "decimal:"},
    			 {"PeiTaoArea" , "decimal:"},
            };
		}
		#endregion
	}
}
