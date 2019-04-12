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
	/// This object represents the properties and methods of a ViewChargeSummary.
	/// </summary>
	[Serializable()]
	public partial class ViewChargeSummary 
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
		private string _name = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string Name
		{
			[DebuggerStepThrough()]
			get { return this._name; }
            protected set { this._name = value;}
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
		private int _companyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int CompanyID
		{
			[DebuggerStepThrough()]
			get { return this._companyID; }
            protected set { this._companyID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _feeType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		[DataObjectField(false, false, false)]
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
		[DataObjectField(false, false, false)]
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
		[DataObjectField(false, false, false)]
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
		private decimal _feeUnitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal FeeUnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._feeUnitPrice; }
            protected set { this._feeUnitPrice = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _feeStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime FeeStartTime
		{
			[DebuggerStepThrough()]
			get { return this._feeStartTime; }
            protected set { this._feeStartTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _feeEndTypeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int FeeEndTypeID
		{
			[DebuggerStepThrough()]
			get { return this._feeEndTypeID; }
            protected set { this._feeEndTypeID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _feeEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime FeeEndTime
		{
			[DebuggerStepThrough()]
			get { return this._feeEndTime; }
            protected set { this._feeEndTime = value;}
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
		private int _feeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int FeeID
		{
			[DebuggerStepThrough()]
			get { return this._feeID; }
            protected set { this._feeID = value;}
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
		private string _categoryDesc = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CategoryDesc
		{
			[DebuggerStepThrough()]
			get { return this._categoryDesc; }
            protected set { this._categoryDesc = value;}
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
		private bool _disableDefaultImportFee = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool DisableDefaultImportFee
		{
			[DebuggerStepThrough()]
			get { return this._disableDefaultImportFee; }
            protected set { this._disableDefaultImportFee = value;}
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
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewChargeSummary() { }
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
	[ViewChargeSummary].[ID],
	[ViewChargeSummary].[Name],
	[ViewChargeSummary].[AddTime],
	[ViewChargeSummary].[CompanyID],
	[ViewChargeSummary].[FeeType],
	[ViewChargeSummary].[TypeID],
	[ViewChargeSummary].[OrderBy],
	[ViewChargeSummary].[CategoryID],
	[ViewChargeSummary].[RuleID],
	[ViewChargeSummary].[EndTypeID],
	[ViewChargeSummary].[EndNumber],
	[ViewChargeSummary].[SummaryUnitPrice],
	[ViewChargeSummary].[Unit],
	[ViewChargeSummary].[Coefficient],
	[ViewChargeSummary].[Remark],
	[ViewChargeSummary].[IsReading],
	[ViewChargeSummary].[EndNumberCount],
	[ViewChargeSummary].[IsAllowImport],
	[ViewChargeSummary].[SummaryStartTime],
	[ViewChargeSummary].[SummaryEndStartTime],
	[ViewChargeSummary].[SummaryChargeTypeCount],
	[ViewChargeSummary].[FeeUnitPrice],
	[ViewChargeSummary].[FeeStartTime],
	[ViewChargeSummary].[FeeEndTypeID],
	[ViewChargeSummary].[FeeEndTime],
	[ViewChargeSummary].[ChargeTypeCount],
	[ViewChargeSummary].[FeeID],
	[ViewChargeSummary].[EndNumberType],
	[ViewChargeSummary].[AutoToMonthEnd],
	[ViewChargeSummary].[BiaoCategory],
	[ViewChargeSummary].[BiaoName],
	[ViewChargeSummary].[TimeAuto],
	[ViewChargeSummary].[CategoryDesc],
	[ViewChargeSummary].[IsOrderFeeOn],
	[ViewChargeSummary].[WeiYuePercent],
	[ViewChargeSummary].[RelateCharges],
	[ViewChargeSummary].[ChargeWeiYueType],
	[ViewChargeSummary].[DayGunLi],
	[ViewChargeSummary].[WeiYueStartDate],
	[ViewChargeSummary].[WeiYueBefore],
	[ViewChargeSummary].[WeiYueDays],
	[ViewChargeSummary].[CalculateAreaType],
	[ViewChargeSummary].[WeiYueEndDate],
	[ViewChargeSummary].[WeiYueActiveDayMonth],
	[ViewChargeSummary].[WeiYueActiveCount],
	[ViewChargeSummary].[WeiYueActiveBeforeAfter],
	[ViewChargeSummary].[WeiYueActiveStartDate],
	[ViewChargeSummary].[StartPriceRange],
	[ViewChargeSummary].[DisableDefaultImportFee],
	[ViewChargeSummary].[PriceRangeStartTime],
	[ViewChargeSummary].[ChargeFeeType]
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
                return "ViewChargeSummary";
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
		/// Gets a collection ViewChargeSummary objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewChargeSummary objects.</returns>
		public static EntityList<ViewChargeSummary> GetViewChargeSummaries()
		{
			string commandText = @"
SELECT " + ViewChargeSummary.SelectFieldList + "FROM [dbo].[ViewChargeSummary] " + ViewChargeSummary.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewChargeSummary>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewChargeSummary objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewChargeSummary objects.</returns>
        public static EntityList<ViewChargeSummary> GetViewChargeSummaries(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewChargeSummary>(SelectFieldList, "FROM [dbo].[ViewChargeSummary]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewChargeSummary objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewChargeSummary objects.</returns>
        public static EntityList<ViewChargeSummary> GetViewChargeSummaries(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewChargeSummary>(SelectFieldList, "FROM [dbo].[ViewChargeSummary]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewChargeSummary objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewChargeSummaryCount()
        {
            return GetViewChargeSummaryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewChargeSummary objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewChargeSummaryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewChargeSummary] " + where;

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
		/// Gets a collection ViewChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewChargeSummary objects.</returns>
		protected static EntityList<ViewChargeSummary> GetViewChargeSummaries(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewChargeSummaries(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewChargeSummary objects.</returns>
		protected static EntityList<ViewChargeSummary> GetViewChargeSummaries(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewChargeSummaries(string.Empty, where, parameters, ViewChargeSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewChargeSummary objects.</returns>
		protected static EntityList<ViewChargeSummary> GetViewChargeSummaries(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewChargeSummaries(prefix, where, parameters, ViewChargeSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewChargeSummary objects.</returns>
		protected static EntityList<ViewChargeSummary> GetViewChargeSummaries(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewChargeSummaries(string.Empty, where, parameters, ViewChargeSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewChargeSummary objects.</returns>
		protected static EntityList<ViewChargeSummary> GetViewChargeSummaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewChargeSummaries(prefix, where, parameters, ViewChargeSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewChargeSummary objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewChargeSummary objects.</returns>
		protected static EntityList<ViewChargeSummary> GetViewChargeSummaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewChargeSummary.SelectFieldList + "FROM [dbo].[ViewChargeSummary] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewChargeSummary>(reader);
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
        protected static EntityList<ViewChargeSummary> GetViewChargeSummaries(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewChargeSummary>(SelectFieldList, "FROM [dbo].[ViewChargeSummary] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewChargeSummaryProperties
		{
			public const string ID = "ID";
			public const string Name = "Name";
			public const string AddTime = "AddTime";
			public const string CompanyID = "CompanyID";
			public const string FeeType = "FeeType";
			public const string TypeID = "TypeID";
			public const string OrderBy = "OrderBy";
			public const string CategoryID = "CategoryID";
			public const string RuleID = "RuleID";
			public const string EndTypeID = "EndTypeID";
			public const string EndNumber = "EndNumber";
			public const string SummaryUnitPrice = "SummaryUnitPrice";
			public const string Unit = "Unit";
			public const string Coefficient = "Coefficient";
			public const string Remark = "Remark";
			public const string IsReading = "IsReading";
			public const string EndNumberCount = "EndNumberCount";
			public const string IsAllowImport = "IsAllowImport";
			public const string SummaryStartTime = "SummaryStartTime";
			public const string SummaryEndStartTime = "SummaryEndStartTime";
			public const string SummaryChargeTypeCount = "SummaryChargeTypeCount";
			public const string FeeUnitPrice = "FeeUnitPrice";
			public const string FeeStartTime = "FeeStartTime";
			public const string FeeEndTypeID = "FeeEndTypeID";
			public const string FeeEndTime = "FeeEndTime";
			public const string ChargeTypeCount = "ChargeTypeCount";
			public const string FeeID = "FeeID";
			public const string EndNumberType = "EndNumberType";
			public const string AutoToMonthEnd = "AutoToMonthEnd";
			public const string BiaoCategory = "BiaoCategory";
			public const string BiaoName = "BiaoName";
			public const string TimeAuto = "TimeAuto";
			public const string CategoryDesc = "CategoryDesc";
			public const string IsOrderFeeOn = "IsOrderFeeOn";
			public const string WeiYuePercent = "WeiYuePercent";
			public const string RelateCharges = "RelateCharges";
			public const string ChargeWeiYueType = "ChargeWeiYueType";
			public const string DayGunLi = "DayGunLi";
			public const string WeiYueStartDate = "WeiYueStartDate";
			public const string WeiYueBefore = "WeiYueBefore";
			public const string WeiYueDays = "WeiYueDays";
			public const string CalculateAreaType = "CalculateAreaType";
			public const string WeiYueEndDate = "WeiYueEndDate";
			public const string WeiYueActiveDayMonth = "WeiYueActiveDayMonth";
			public const string WeiYueActiveCount = "WeiYueActiveCount";
			public const string WeiYueActiveBeforeAfter = "WeiYueActiveBeforeAfter";
			public const string WeiYueActiveStartDate = "WeiYueActiveStartDate";
			public const string StartPriceRange = "StartPriceRange";
			public const string DisableDefaultImportFee = "DisableDefaultImportFee";
			public const string PriceRangeStartTime = "PriceRangeStartTime";
			public const string ChargeFeeType = "ChargeFeeType";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Name" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"CompanyID" , "int:"},
    			 {"FeeType" , "int:"},
    			 {"TypeID" , "int:"},
    			 {"OrderBy" , "int:"},
    			 {"CategoryID" , "int:"},
    			 {"RuleID" , "int:"},
    			 {"EndTypeID" , "int:"},
    			 {"EndNumber" , "int:"},
    			 {"SummaryUnitPrice" , "decimal:"},
    			 {"Unit" , "string:"},
    			 {"Coefficient" , "decimal:"},
    			 {"Remark" , "string:"},
    			 {"IsReading" , "bool:"},
    			 {"EndNumberCount" , "int:"},
    			 {"IsAllowImport" , "bool:"},
    			 {"SummaryStartTime" , "DateTime:"},
    			 {"SummaryEndStartTime" , "DateTime:"},
    			 {"SummaryChargeTypeCount" , "int:"},
    			 {"FeeUnitPrice" , "decimal:"},
    			 {"FeeStartTime" , "DateTime:"},
    			 {"FeeEndTypeID" , "int:"},
    			 {"FeeEndTime" , "DateTime:"},
    			 {"ChargeTypeCount" , "int:"},
    			 {"FeeID" , "int:"},
    			 {"EndNumberType" , "int:"},
    			 {"AutoToMonthEnd" , "bool:"},
    			 {"BiaoCategory" , "string:"},
    			 {"BiaoName" , "string:"},
    			 {"TimeAuto" , "bool:"},
    			 {"CategoryDesc" , "string:"},
    			 {"IsOrderFeeOn" , "bool:"},
    			 {"WeiYuePercent" , "decimal:"},
    			 {"RelateCharges" , "string:"},
    			 {"ChargeWeiYueType" , "int:"},
    			 {"DayGunLi" , "bool:"},
    			 {"WeiYueStartDate" , "string:"},
    			 {"WeiYueBefore" , "string:"},
    			 {"WeiYueDays" , "int:"},
    			 {"CalculateAreaType" , "string:"},
    			 {"WeiYueEndDate" , "string:"},
    			 {"WeiYueActiveDayMonth" , "string:"},
    			 {"WeiYueActiveCount" , "int:"},
    			 {"WeiYueActiveBeforeAfter" , "string:"},
    			 {"WeiYueActiveStartDate" , "string:"},
    			 {"StartPriceRange" , "bool:"},
    			 {"DisableDefaultImportFee" , "bool:"},
    			 {"PriceRangeStartTime" , "DateTime:"},
    			 {"ChargeFeeType" , "int:"},
            };
		}
		#endregion
	}
}
