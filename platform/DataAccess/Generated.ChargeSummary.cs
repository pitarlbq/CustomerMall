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
	/// This object represents the properties and methods of a ChargeSummary.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ChargeSummary 
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
			set 
			{
				if (this._name != value) 
				{
					this._name = value;
					this.IsDirty = true;	
					OnPropertyChanged("Name");
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
			set 
			{
				if (this._companyID != value) 
				{
					this._companyID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CompanyID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _feeType = int.MinValue;
		/// <summary>
		/// 1-周期费用 4-临时费用 8-违约金
		/// </summary>
        [Description("1-周期费用 4-临时费用 8-违约金")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int FeeType
		{
			[DebuggerStepThrough()]
			get { return this._feeType; }
			set 
			{
				if (this._feeType != value) 
				{
					this._feeType = value;
					this.IsDirty = true;	
					OnPropertyChanged("FeeType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _typeID = int.MinValue;
		/// <summary>
		/// 1-单价*计费面积(月度) 2-定额(月度) 3-单价*计费面积*公摊系数(月度) 4-定额(年度) 5-单价*计费面积(按天) 6-单价*计费面积/用量(一次性) 7-单价*计费面积(月度进位)
		/// </summary>
        [Description("1-单价*计费面积(月度) 2-定额(月度) 3-单价*计费面积*公摊系数(月度) 4-定额(年度) 5-单价*计费面积(按天) 6-单价*计费面积/用量(一次性) 7-单价*计费面积(月度进位)")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int TypeID
		{
			[DebuggerStepThrough()]
			get { return this._typeID; }
			set 
			{
				if (this._typeID != value) 
				{
					this._typeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("TypeID");
				}
			}
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
			set 
			{
				if (this._orderBy != value) 
				{
					this._orderBy = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderBy");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _categoryID = int.MinValue;
		/// <summary>
		/// 1-收入 2-代收 3-押金-4预收
		/// </summary>
        [Description("1-收入 2-代收 3-押金-4预收")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int CategoryID
		{
			[DebuggerStepThrough()]
			get { return this._categoryID; }
			set 
			{
				if (this._categoryID != value) 
				{
					this._categoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CategoryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _ruleID = int.MinValue;
		/// <summary>
		/// 1-预收 2-实收 3-临时收取
		/// </summary>
        [Description("1-预收 2-实收 3-临时收取")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RuleID
		{
			[DebuggerStepThrough()]
			get { return this._ruleID; }
			set 
			{
				if (this._ruleID != value) 
				{
					this._ruleID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RuleID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _endTypeID = int.MinValue;
		/// <summary>
		/// 计费规则 1-按当前自然日期 2-按计费开始日期 3-手动指定
		/// </summary>
        [Description("计费规则 1-按当前自然日期 2-按计费开始日期 3-手动指定")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int EndTypeID
		{
			[DebuggerStepThrough()]
			get { return this._endTypeID; }
			set 
			{
				if (this._endTypeID != value) 
				{
					this._endTypeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndTypeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _endNumber = int.MinValue;
		/// <summary>
		/// 尾数处理  1直接进位、2、直接舍弃 3、四舍五入
		/// </summary>
        [Description("尾数处理  1直接进位、2、直接舍弃 3、四舍五入")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int EndNumber
		{
			[DebuggerStepThrough()]
			get { return this._endNumber; }
			set 
			{
				if (this._endNumber != value) 
				{
					this._endNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _summaryUnitPrice = decimal.MinValue;
		/// <summary>
		/// 单价
		/// </summary>
        [Description("单价")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal SummaryUnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._summaryUnitPrice; }
			set 
			{
				if (this._summaryUnitPrice != value) 
				{
					this._summaryUnitPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("SummaryUnitPrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _unit = String.Empty;
		/// <summary>
		/// 单位
		/// </summary>
        [Description("单位")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Unit
		{
			[DebuggerStepThrough()]
			get { return this._unit; }
			set 
			{
				if (this._unit != value) 
				{
					this._unit = value;
					this.IsDirty = true;	
					OnPropertyChanged("Unit");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _coefficient = decimal.MinValue;
		/// <summary>
		/// 系数
		/// </summary>
        [Description("系数")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal Coefficient
		{
			[DebuggerStepThrough()]
			get { return this._coefficient; }
			set 
			{
				if (this._coefficient != value) 
				{
					this._coefficient = value;
					this.IsDirty = true;	
					OnPropertyChanged("Coefficient");
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
		private bool _isReading = false;
		/// <summary>
		/// 是否抄表
		/// </summary>
        [Description("是否抄表")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsReading
		{
			[DebuggerStepThrough()]
			get { return this._isReading; }
			set 
			{
				if (this._isReading != value) 
				{
					this._isReading = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsReading");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _endNumberCount = int.MinValue;
		/// <summary>
		/// 保存小数位数
		/// </summary>
        [Description("保存小数位数")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int EndNumberCount
		{
			[DebuggerStepThrough()]
			get { return this._endNumberCount; }
			set 
			{
				if (this._endNumberCount != value) 
				{
					this._endNumberCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndNumberCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAllowImport = false;
		/// <summary>
		/// 允许导入
		/// </summary>
        [Description("允许导入")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAllowImport
		{
			[DebuggerStepThrough()]
			get { return this._isAllowImport; }
			set 
			{
				if (this._isAllowImport != value) 
				{
					this._isAllowImport = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAllowImport");
				}
			}
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
			set 
			{
				if (this._summaryStartTime != value) 
				{
					this._summaryStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("SummaryStartTime");
				}
			}
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
			set 
			{
				if (this._summaryEndStartTime != value) 
				{
					this._summaryEndStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("SummaryEndStartTime");
				}
			}
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
			set 
			{
				if (this._summaryChargeTypeCount != value) 
				{
					this._summaryChargeTypeCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("SummaryChargeTypeCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _endNumberType = int.MinValue;
		/// <summary>
		/// 自动取整至月末
		/// </summary>
        [Description("自动取整至月末")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int EndNumberType
		{
			[DebuggerStepThrough()]
			get { return this._endNumberType; }
			set 
			{
				if (this._endNumberType != value) 
				{
					this._endNumberType = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndNumberType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _autoToMonthEnd = false;
		/// <summary>
		/// 顺延规则  1按月、2、按日
		/// </summary>
        [Description("顺延规则  1按月、2、按日")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool AutoToMonthEnd
		{
			[DebuggerStepThrough()]
			get { return this._autoToMonthEnd; }
			set 
			{
				if (this._autoToMonthEnd != value) 
				{
					this._autoToMonthEnd = value;
					this.IsDirty = true;	
					OnPropertyChanged("AutoToMonthEnd");
				}
			}
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
			set 
			{
				if (this._biaoCategory != value) 
				{
					this._biaoCategory = value;
					this.IsDirty = true;	
					OnPropertyChanged("BiaoCategory");
				}
			}
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
			set 
			{
				if (this._biaoName != value) 
				{
					this._biaoName = value;
					this.IsDirty = true;	
					OnPropertyChanged("BiaoName");
				}
			}
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
			set 
			{
				if (this._timeAuto != value) 
				{
					this._timeAuto = value;
					this.IsDirty = true;	
					OnPropertyChanged("TimeAuto");
				}
			}
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
			set 
			{
				if (this._isOrderFeeOn != value) 
				{
					this._isOrderFeeOn = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsOrderFeeOn");
				}
			}
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
			set 
			{
				if (this._weiYuePercent != value) 
				{
					this._weiYuePercent = value;
					this.IsDirty = true;	
					OnPropertyChanged("WeiYuePercent");
				}
			}
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
			set 
			{
				if (this._relateCharges != value) 
				{
					this._relateCharges = value;
					this.IsDirty = true;	
					OnPropertyChanged("RelateCharges");
				}
			}
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
			set 
			{
				if (this._chargeWeiYueType != value) 
				{
					this._chargeWeiYueType = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeWeiYueType");
				}
			}
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
			set 
			{
				if (this._dayGunLi != value) 
				{
					this._dayGunLi = value;
					this.IsDirty = true;	
					OnPropertyChanged("DayGunLi");
				}
			}
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
			set 
			{
				if (this._weiYueStartDate != value) 
				{
					this._weiYueStartDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("WeiYueStartDate");
				}
			}
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
			set 
			{
				if (this._weiYueBefore != value) 
				{
					this._weiYueBefore = value;
					this.IsDirty = true;	
					OnPropertyChanged("WeiYueBefore");
				}
			}
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
			set 
			{
				if (this._weiYueDays != value) 
				{
					this._weiYueDays = value;
					this.IsDirty = true;	
					OnPropertyChanged("WeiYueDays");
				}
			}
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
			set 
			{
				if (this._calculateAreaType != value) 
				{
					this._calculateAreaType = value;
					this.IsDirty = true;	
					OnPropertyChanged("CalculateAreaType");
				}
			}
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
			set 
			{
				if (this._weiYueActiveStartDate != value) 
				{
					this._weiYueActiveStartDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("WeiYueActiveStartDate");
				}
			}
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
			set 
			{
				if (this._weiYueActiveBeforeAfter != value) 
				{
					this._weiYueActiveBeforeAfter = value;
					this.IsDirty = true;	
					OnPropertyChanged("WeiYueActiveBeforeAfter");
				}
			}
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
			set 
			{
				if (this._weiYueActiveCount != value) 
				{
					this._weiYueActiveCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("WeiYueActiveCount");
				}
			}
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
			set 
			{
				if (this._weiYueActiveDayMonth != value) 
				{
					this._weiYueActiveDayMonth = value;
					this.IsDirty = true;	
					OnPropertyChanged("WeiYueActiveDayMonth");
				}
			}
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
			set 
			{
				if (this._weiYueEndDate != value) 
				{
					this._weiYueEndDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("WeiYueEndDate");
				}
			}
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
			set 
			{
				if (this._startPriceRange != value) 
				{
					this._startPriceRange = value;
					this.IsDirty = true;	
					OnPropertyChanged("StartPriceRange");
				}
			}
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
			set 
			{
				if (this._disableDefaultImportFee != value) 
				{
					this._disableDefaultImportFee = value;
					this.IsDirty = true;	
					OnPropertyChanged("DisableDefaultImportFee");
				}
			}
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
			set 
			{
				if (this._priceRangeStartTime != value) 
				{
					this._priceRangeStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("PriceRangeStartTime");
				}
			}
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
			set 
			{
				if (this._chargeFeeType != value) 
				{
					this._chargeFeeType = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeFeeType");
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
	[Name] nvarchar(50),
	[AddTime] datetime,
	[CompanyID] int,
	[FeeType] int,
	[TypeID] int,
	[OrderBy] int,
	[CategoryID] int,
	[RuleID] int,
	[EndTypeID] int,
	[EndNumber] int,
	[SummaryUnitPrice] decimal(18, 4),
	[Unit] nvarchar(10),
	[Coefficient] decimal(18, 4),
	[Remark] ntext,
	[IsReading] bit,
	[EndNumberCount] int,
	[IsAllowImport] bit,
	[SummaryStartTime] datetime,
	[SummaryEndStartTime] datetime,
	[SummaryChargeTypeCount] int,
	[EndNumberType] int,
	[AutoToMonthEnd] bit,
	[BiaoCategory] nvarchar(200),
	[BiaoName] nvarchar(200),
	[TimeAuto] bit,
	[IsOrderFeeOn] bit,
	[WeiYuePercent] decimal(18, 4),
	[RelateCharges] nvarchar(200),
	[ChargeWeiYueType] int,
	[DayGunLi] bit,
	[WeiYueStartDate] nvarchar(50),
	[WeiYueBefore] nvarchar(50),
	[WeiYueDays] int,
	[CalculateAreaType] nvarchar(10),
	[WeiYueActiveStartDate] nvarchar(100),
	[WeiYueActiveBeforeAfter] nvarchar(100),
	[WeiYueActiveCount] int,
	[WeiYueActiveDayMonth] nvarchar(100),
	[WeiYueEndDate] nvarchar(100),
	[StartPriceRange] bit,
	[DisableDefaultImportFee] bit,
	[PriceRangeStartTime] datetime,
	[ChargeFeeType] int
);

INSERT INTO [dbo].[ChargeSummary] (
	[ChargeSummary].[Name],
	[ChargeSummary].[AddTime],
	[ChargeSummary].[CompanyID],
	[ChargeSummary].[FeeType],
	[ChargeSummary].[TypeID],
	[ChargeSummary].[OrderBy],
	[ChargeSummary].[CategoryID],
	[ChargeSummary].[RuleID],
	[ChargeSummary].[EndTypeID],
	[ChargeSummary].[EndNumber],
	[ChargeSummary].[SummaryUnitPrice],
	[ChargeSummary].[Unit],
	[ChargeSummary].[Coefficient],
	[ChargeSummary].[Remark],
	[ChargeSummary].[IsReading],
	[ChargeSummary].[EndNumberCount],
	[ChargeSummary].[IsAllowImport],
	[ChargeSummary].[SummaryStartTime],
	[ChargeSummary].[SummaryEndStartTime],
	[ChargeSummary].[SummaryChargeTypeCount],
	[ChargeSummary].[EndNumberType],
	[ChargeSummary].[AutoToMonthEnd],
	[ChargeSummary].[BiaoCategory],
	[ChargeSummary].[BiaoName],
	[ChargeSummary].[TimeAuto],
	[ChargeSummary].[IsOrderFeeOn],
	[ChargeSummary].[WeiYuePercent],
	[ChargeSummary].[RelateCharges],
	[ChargeSummary].[ChargeWeiYueType],
	[ChargeSummary].[DayGunLi],
	[ChargeSummary].[WeiYueStartDate],
	[ChargeSummary].[WeiYueBefore],
	[ChargeSummary].[WeiYueDays],
	[ChargeSummary].[CalculateAreaType],
	[ChargeSummary].[WeiYueActiveStartDate],
	[ChargeSummary].[WeiYueActiveBeforeAfter],
	[ChargeSummary].[WeiYueActiveCount],
	[ChargeSummary].[WeiYueActiveDayMonth],
	[ChargeSummary].[WeiYueEndDate],
	[ChargeSummary].[StartPriceRange],
	[ChargeSummary].[DisableDefaultImportFee],
	[ChargeSummary].[PriceRangeStartTime],
	[ChargeSummary].[ChargeFeeType]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[AddTime],
	INSERTED.[CompanyID],
	INSERTED.[FeeType],
	INSERTED.[TypeID],
	INSERTED.[OrderBy],
	INSERTED.[CategoryID],
	INSERTED.[RuleID],
	INSERTED.[EndTypeID],
	INSERTED.[EndNumber],
	INSERTED.[SummaryUnitPrice],
	INSERTED.[Unit],
	INSERTED.[Coefficient],
	INSERTED.[Remark],
	INSERTED.[IsReading],
	INSERTED.[EndNumberCount],
	INSERTED.[IsAllowImport],
	INSERTED.[SummaryStartTime],
	INSERTED.[SummaryEndStartTime],
	INSERTED.[SummaryChargeTypeCount],
	INSERTED.[EndNumberType],
	INSERTED.[AutoToMonthEnd],
	INSERTED.[BiaoCategory],
	INSERTED.[BiaoName],
	INSERTED.[TimeAuto],
	INSERTED.[IsOrderFeeOn],
	INSERTED.[WeiYuePercent],
	INSERTED.[RelateCharges],
	INSERTED.[ChargeWeiYueType],
	INSERTED.[DayGunLi],
	INSERTED.[WeiYueStartDate],
	INSERTED.[WeiYueBefore],
	INSERTED.[WeiYueDays],
	INSERTED.[CalculateAreaType],
	INSERTED.[WeiYueActiveStartDate],
	INSERTED.[WeiYueActiveBeforeAfter],
	INSERTED.[WeiYueActiveCount],
	INSERTED.[WeiYueActiveDayMonth],
	INSERTED.[WeiYueEndDate],
	INSERTED.[StartPriceRange],
	INSERTED.[DisableDefaultImportFee],
	INSERTED.[PriceRangeStartTime],
	INSERTED.[ChargeFeeType]
into @table
VALUES ( 
	@Name,
	@AddTime,
	@CompanyID,
	@FeeType,
	@TypeID,
	@OrderBy,
	@CategoryID,
	@RuleID,
	@EndTypeID,
	@EndNumber,
	@SummaryUnitPrice,
	@Unit,
	@Coefficient,
	@Remark,
	@IsReading,
	@EndNumberCount,
	@IsAllowImport,
	@SummaryStartTime,
	@SummaryEndStartTime,
	@SummaryChargeTypeCount,
	@EndNumberType,
	@AutoToMonthEnd,
	@BiaoCategory,
	@BiaoName,
	@TimeAuto,
	@IsOrderFeeOn,
	@WeiYuePercent,
	@RelateCharges,
	@ChargeWeiYueType,
	@DayGunLi,
	@WeiYueStartDate,
	@WeiYueBefore,
	@WeiYueDays,
	@CalculateAreaType,
	@WeiYueActiveStartDate,
	@WeiYueActiveBeforeAfter,
	@WeiYueActiveCount,
	@WeiYueActiveDayMonth,
	@WeiYueEndDate,
	@StartPriceRange,
	@DisableDefaultImportFee,
	@PriceRangeStartTime,
	@ChargeFeeType 
); 

SELECT 
	[ID],
	[Name],
	[AddTime],
	[CompanyID],
	[FeeType],
	[TypeID],
	[OrderBy],
	[CategoryID],
	[RuleID],
	[EndTypeID],
	[EndNumber],
	[SummaryUnitPrice],
	[Unit],
	[Coefficient],
	[Remark],
	[IsReading],
	[EndNumberCount],
	[IsAllowImport],
	[SummaryStartTime],
	[SummaryEndStartTime],
	[SummaryChargeTypeCount],
	[EndNumberType],
	[AutoToMonthEnd],
	[BiaoCategory],
	[BiaoName],
	[TimeAuto],
	[IsOrderFeeOn],
	[WeiYuePercent],
	[RelateCharges],
	[ChargeWeiYueType],
	[DayGunLi],
	[WeiYueStartDate],
	[WeiYueBefore],
	[WeiYueDays],
	[CalculateAreaType],
	[WeiYueActiveStartDate],
	[WeiYueActiveBeforeAfter],
	[WeiYueActiveCount],
	[WeiYueActiveDayMonth],
	[WeiYueEndDate],
	[StartPriceRange],
	[DisableDefaultImportFee],
	[PriceRangeStartTime],
	[ChargeFeeType] 
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
	[Name] nvarchar(50),
	[AddTime] datetime,
	[CompanyID] int,
	[FeeType] int,
	[TypeID] int,
	[OrderBy] int,
	[CategoryID] int,
	[RuleID] int,
	[EndTypeID] int,
	[EndNumber] int,
	[SummaryUnitPrice] decimal(18, 4),
	[Unit] nvarchar(10),
	[Coefficient] decimal(18, 4),
	[Remark] ntext,
	[IsReading] bit,
	[EndNumberCount] int,
	[IsAllowImport] bit,
	[SummaryStartTime] datetime,
	[SummaryEndStartTime] datetime,
	[SummaryChargeTypeCount] int,
	[EndNumberType] int,
	[AutoToMonthEnd] bit,
	[BiaoCategory] nvarchar(200),
	[BiaoName] nvarchar(200),
	[TimeAuto] bit,
	[IsOrderFeeOn] bit,
	[WeiYuePercent] decimal(18, 4),
	[RelateCharges] nvarchar(200),
	[ChargeWeiYueType] int,
	[DayGunLi] bit,
	[WeiYueStartDate] nvarchar(50),
	[WeiYueBefore] nvarchar(50),
	[WeiYueDays] int,
	[CalculateAreaType] nvarchar(10),
	[WeiYueActiveStartDate] nvarchar(100),
	[WeiYueActiveBeforeAfter] nvarchar(100),
	[WeiYueActiveCount] int,
	[WeiYueActiveDayMonth] nvarchar(100),
	[WeiYueEndDate] nvarchar(100),
	[StartPriceRange] bit,
	[DisableDefaultImportFee] bit,
	[PriceRangeStartTime] datetime,
	[ChargeFeeType] int
);

UPDATE [dbo].[ChargeSummary] SET 
	[ChargeSummary].[Name] = @Name,
	[ChargeSummary].[AddTime] = @AddTime,
	[ChargeSummary].[CompanyID] = @CompanyID,
	[ChargeSummary].[FeeType] = @FeeType,
	[ChargeSummary].[TypeID] = @TypeID,
	[ChargeSummary].[OrderBy] = @OrderBy,
	[ChargeSummary].[CategoryID] = @CategoryID,
	[ChargeSummary].[RuleID] = @RuleID,
	[ChargeSummary].[EndTypeID] = @EndTypeID,
	[ChargeSummary].[EndNumber] = @EndNumber,
	[ChargeSummary].[SummaryUnitPrice] = @SummaryUnitPrice,
	[ChargeSummary].[Unit] = @Unit,
	[ChargeSummary].[Coefficient] = @Coefficient,
	[ChargeSummary].[Remark] = @Remark,
	[ChargeSummary].[IsReading] = @IsReading,
	[ChargeSummary].[EndNumberCount] = @EndNumberCount,
	[ChargeSummary].[IsAllowImport] = @IsAllowImport,
	[ChargeSummary].[SummaryStartTime] = @SummaryStartTime,
	[ChargeSummary].[SummaryEndStartTime] = @SummaryEndStartTime,
	[ChargeSummary].[SummaryChargeTypeCount] = @SummaryChargeTypeCount,
	[ChargeSummary].[EndNumberType] = @EndNumberType,
	[ChargeSummary].[AutoToMonthEnd] = @AutoToMonthEnd,
	[ChargeSummary].[BiaoCategory] = @BiaoCategory,
	[ChargeSummary].[BiaoName] = @BiaoName,
	[ChargeSummary].[TimeAuto] = @TimeAuto,
	[ChargeSummary].[IsOrderFeeOn] = @IsOrderFeeOn,
	[ChargeSummary].[WeiYuePercent] = @WeiYuePercent,
	[ChargeSummary].[RelateCharges] = @RelateCharges,
	[ChargeSummary].[ChargeWeiYueType] = @ChargeWeiYueType,
	[ChargeSummary].[DayGunLi] = @DayGunLi,
	[ChargeSummary].[WeiYueStartDate] = @WeiYueStartDate,
	[ChargeSummary].[WeiYueBefore] = @WeiYueBefore,
	[ChargeSummary].[WeiYueDays] = @WeiYueDays,
	[ChargeSummary].[CalculateAreaType] = @CalculateAreaType,
	[ChargeSummary].[WeiYueActiveStartDate] = @WeiYueActiveStartDate,
	[ChargeSummary].[WeiYueActiveBeforeAfter] = @WeiYueActiveBeforeAfter,
	[ChargeSummary].[WeiYueActiveCount] = @WeiYueActiveCount,
	[ChargeSummary].[WeiYueActiveDayMonth] = @WeiYueActiveDayMonth,
	[ChargeSummary].[WeiYueEndDate] = @WeiYueEndDate,
	[ChargeSummary].[StartPriceRange] = @StartPriceRange,
	[ChargeSummary].[DisableDefaultImportFee] = @DisableDefaultImportFee,
	[ChargeSummary].[PriceRangeStartTime] = @PriceRangeStartTime,
	[ChargeSummary].[ChargeFeeType] = @ChargeFeeType 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[AddTime],
	INSERTED.[CompanyID],
	INSERTED.[FeeType],
	INSERTED.[TypeID],
	INSERTED.[OrderBy],
	INSERTED.[CategoryID],
	INSERTED.[RuleID],
	INSERTED.[EndTypeID],
	INSERTED.[EndNumber],
	INSERTED.[SummaryUnitPrice],
	INSERTED.[Unit],
	INSERTED.[Coefficient],
	INSERTED.[Remark],
	INSERTED.[IsReading],
	INSERTED.[EndNumberCount],
	INSERTED.[IsAllowImport],
	INSERTED.[SummaryStartTime],
	INSERTED.[SummaryEndStartTime],
	INSERTED.[SummaryChargeTypeCount],
	INSERTED.[EndNumberType],
	INSERTED.[AutoToMonthEnd],
	INSERTED.[BiaoCategory],
	INSERTED.[BiaoName],
	INSERTED.[TimeAuto],
	INSERTED.[IsOrderFeeOn],
	INSERTED.[WeiYuePercent],
	INSERTED.[RelateCharges],
	INSERTED.[ChargeWeiYueType],
	INSERTED.[DayGunLi],
	INSERTED.[WeiYueStartDate],
	INSERTED.[WeiYueBefore],
	INSERTED.[WeiYueDays],
	INSERTED.[CalculateAreaType],
	INSERTED.[WeiYueActiveStartDate],
	INSERTED.[WeiYueActiveBeforeAfter],
	INSERTED.[WeiYueActiveCount],
	INSERTED.[WeiYueActiveDayMonth],
	INSERTED.[WeiYueEndDate],
	INSERTED.[StartPriceRange],
	INSERTED.[DisableDefaultImportFee],
	INSERTED.[PriceRangeStartTime],
	INSERTED.[ChargeFeeType]
into @table
WHERE 
	[ChargeSummary].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[AddTime],
	[CompanyID],
	[FeeType],
	[TypeID],
	[OrderBy],
	[CategoryID],
	[RuleID],
	[EndTypeID],
	[EndNumber],
	[SummaryUnitPrice],
	[Unit],
	[Coefficient],
	[Remark],
	[IsReading],
	[EndNumberCount],
	[IsAllowImport],
	[SummaryStartTime],
	[SummaryEndStartTime],
	[SummaryChargeTypeCount],
	[EndNumberType],
	[AutoToMonthEnd],
	[BiaoCategory],
	[BiaoName],
	[TimeAuto],
	[IsOrderFeeOn],
	[WeiYuePercent],
	[RelateCharges],
	[ChargeWeiYueType],
	[DayGunLi],
	[WeiYueStartDate],
	[WeiYueBefore],
	[WeiYueDays],
	[CalculateAreaType],
	[WeiYueActiveStartDate],
	[WeiYueActiveBeforeAfter],
	[WeiYueActiveCount],
	[WeiYueActiveDayMonth],
	[WeiYueEndDate],
	[StartPriceRange],
	[DisableDefaultImportFee],
	[PriceRangeStartTime],
	[ChargeFeeType] 
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
DELETE FROM [dbo].[ChargeSummary]
WHERE 
	[ChargeSummary].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ChargeSummary() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetChargeSummary(this.ID));
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
	[ChargeSummary].[ID],
	[ChargeSummary].[Name],
	[ChargeSummary].[AddTime],
	[ChargeSummary].[CompanyID],
	[ChargeSummary].[FeeType],
	[ChargeSummary].[TypeID],
	[ChargeSummary].[OrderBy],
	[ChargeSummary].[CategoryID],
	[ChargeSummary].[RuleID],
	[ChargeSummary].[EndTypeID],
	[ChargeSummary].[EndNumber],
	[ChargeSummary].[SummaryUnitPrice],
	[ChargeSummary].[Unit],
	[ChargeSummary].[Coefficient],
	[ChargeSummary].[Remark],
	[ChargeSummary].[IsReading],
	[ChargeSummary].[EndNumberCount],
	[ChargeSummary].[IsAllowImport],
	[ChargeSummary].[SummaryStartTime],
	[ChargeSummary].[SummaryEndStartTime],
	[ChargeSummary].[SummaryChargeTypeCount],
	[ChargeSummary].[EndNumberType],
	[ChargeSummary].[AutoToMonthEnd],
	[ChargeSummary].[BiaoCategory],
	[ChargeSummary].[BiaoName],
	[ChargeSummary].[TimeAuto],
	[ChargeSummary].[IsOrderFeeOn],
	[ChargeSummary].[WeiYuePercent],
	[ChargeSummary].[RelateCharges],
	[ChargeSummary].[ChargeWeiYueType],
	[ChargeSummary].[DayGunLi],
	[ChargeSummary].[WeiYueStartDate],
	[ChargeSummary].[WeiYueBefore],
	[ChargeSummary].[WeiYueDays],
	[ChargeSummary].[CalculateAreaType],
	[ChargeSummary].[WeiYueActiveStartDate],
	[ChargeSummary].[WeiYueActiveBeforeAfter],
	[ChargeSummary].[WeiYueActiveCount],
	[ChargeSummary].[WeiYueActiveDayMonth],
	[ChargeSummary].[WeiYueEndDate],
	[ChargeSummary].[StartPriceRange],
	[ChargeSummary].[DisableDefaultImportFee],
	[ChargeSummary].[PriceRangeStartTime],
	[ChargeSummary].[ChargeFeeType]
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
                return "ChargeSummary";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ChargeSummary into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="addTime">addTime</param>
		/// <param name="companyID">companyID</param>
		/// <param name="feeType">feeType</param>
		/// <param name="typeID">typeID</param>
		/// <param name="orderBy">orderBy</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="ruleID">ruleID</param>
		/// <param name="endTypeID">endTypeID</param>
		/// <param name="endNumber">endNumber</param>
		/// <param name="summaryUnitPrice">summaryUnitPrice</param>
		/// <param name="unit">unit</param>
		/// <param name="coefficient">coefficient</param>
		/// <param name="remark">remark</param>
		/// <param name="isReading">isReading</param>
		/// <param name="endNumberCount">endNumberCount</param>
		/// <param name="isAllowImport">isAllowImport</param>
		/// <param name="summaryStartTime">summaryStartTime</param>
		/// <param name="summaryEndStartTime">summaryEndStartTime</param>
		/// <param name="summaryChargeTypeCount">summaryChargeTypeCount</param>
		/// <param name="endNumberType">endNumberType</param>
		/// <param name="autoToMonthEnd">autoToMonthEnd</param>
		/// <param name="biaoCategory">biaoCategory</param>
		/// <param name="biaoName">biaoName</param>
		/// <param name="timeAuto">timeAuto</param>
		/// <param name="isOrderFeeOn">isOrderFeeOn</param>
		/// <param name="weiYuePercent">weiYuePercent</param>
		/// <param name="relateCharges">relateCharges</param>
		/// <param name="chargeWeiYueType">chargeWeiYueType</param>
		/// <param name="dayGunLi">dayGunLi</param>
		/// <param name="weiYueStartDate">weiYueStartDate</param>
		/// <param name="weiYueBefore">weiYueBefore</param>
		/// <param name="weiYueDays">weiYueDays</param>
		/// <param name="calculateAreaType">calculateAreaType</param>
		/// <param name="weiYueActiveStartDate">weiYueActiveStartDate</param>
		/// <param name="weiYueActiveBeforeAfter">weiYueActiveBeforeAfter</param>
		/// <param name="weiYueActiveCount">weiYueActiveCount</param>
		/// <param name="weiYueActiveDayMonth">weiYueActiveDayMonth</param>
		/// <param name="weiYueEndDate">weiYueEndDate</param>
		/// <param name="startPriceRange">startPriceRange</param>
		/// <param name="disableDefaultImportFee">disableDefaultImportFee</param>
		/// <param name="priceRangeStartTime">priceRangeStartTime</param>
		/// <param name="chargeFeeType">chargeFeeType</param>
		public static void InsertChargeSummary(string @name, DateTime @addTime, int @companyID, int @feeType, int @typeID, int @orderBy, int @categoryID, int @ruleID, int @endTypeID, int @endNumber, decimal @summaryUnitPrice, string @unit, decimal @coefficient, string @remark, bool @isReading, int @endNumberCount, bool @isAllowImport, DateTime @summaryStartTime, DateTime @summaryEndStartTime, int @summaryChargeTypeCount, int @endNumberType, bool @autoToMonthEnd, string @biaoCategory, string @biaoName, bool @timeAuto, bool @isOrderFeeOn, decimal @weiYuePercent, string @relateCharges, int @chargeWeiYueType, bool @dayGunLi, string @weiYueStartDate, string @weiYueBefore, int @weiYueDays, string @calculateAreaType, string @weiYueActiveStartDate, string @weiYueActiveBeforeAfter, int @weiYueActiveCount, string @weiYueActiveDayMonth, string @weiYueEndDate, bool @startPriceRange, bool @disableDefaultImportFee, DateTime @priceRangeStartTime, int @chargeFeeType)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertChargeSummary(@name, @addTime, @companyID, @feeType, @typeID, @orderBy, @categoryID, @ruleID, @endTypeID, @endNumber, @summaryUnitPrice, @unit, @coefficient, @remark, @isReading, @endNumberCount, @isAllowImport, @summaryStartTime, @summaryEndStartTime, @summaryChargeTypeCount, @endNumberType, @autoToMonthEnd, @biaoCategory, @biaoName, @timeAuto, @isOrderFeeOn, @weiYuePercent, @relateCharges, @chargeWeiYueType, @dayGunLi, @weiYueStartDate, @weiYueBefore, @weiYueDays, @calculateAreaType, @weiYueActiveStartDate, @weiYueActiveBeforeAfter, @weiYueActiveCount, @weiYueActiveDayMonth, @weiYueEndDate, @startPriceRange, @disableDefaultImportFee, @priceRangeStartTime, @chargeFeeType, helper);
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
		/// Insert a ChargeSummary into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="addTime">addTime</param>
		/// <param name="companyID">companyID</param>
		/// <param name="feeType">feeType</param>
		/// <param name="typeID">typeID</param>
		/// <param name="orderBy">orderBy</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="ruleID">ruleID</param>
		/// <param name="endTypeID">endTypeID</param>
		/// <param name="endNumber">endNumber</param>
		/// <param name="summaryUnitPrice">summaryUnitPrice</param>
		/// <param name="unit">unit</param>
		/// <param name="coefficient">coefficient</param>
		/// <param name="remark">remark</param>
		/// <param name="isReading">isReading</param>
		/// <param name="endNumberCount">endNumberCount</param>
		/// <param name="isAllowImport">isAllowImport</param>
		/// <param name="summaryStartTime">summaryStartTime</param>
		/// <param name="summaryEndStartTime">summaryEndStartTime</param>
		/// <param name="summaryChargeTypeCount">summaryChargeTypeCount</param>
		/// <param name="endNumberType">endNumberType</param>
		/// <param name="autoToMonthEnd">autoToMonthEnd</param>
		/// <param name="biaoCategory">biaoCategory</param>
		/// <param name="biaoName">biaoName</param>
		/// <param name="timeAuto">timeAuto</param>
		/// <param name="isOrderFeeOn">isOrderFeeOn</param>
		/// <param name="weiYuePercent">weiYuePercent</param>
		/// <param name="relateCharges">relateCharges</param>
		/// <param name="chargeWeiYueType">chargeWeiYueType</param>
		/// <param name="dayGunLi">dayGunLi</param>
		/// <param name="weiYueStartDate">weiYueStartDate</param>
		/// <param name="weiYueBefore">weiYueBefore</param>
		/// <param name="weiYueDays">weiYueDays</param>
		/// <param name="calculateAreaType">calculateAreaType</param>
		/// <param name="weiYueActiveStartDate">weiYueActiveStartDate</param>
		/// <param name="weiYueActiveBeforeAfter">weiYueActiveBeforeAfter</param>
		/// <param name="weiYueActiveCount">weiYueActiveCount</param>
		/// <param name="weiYueActiveDayMonth">weiYueActiveDayMonth</param>
		/// <param name="weiYueEndDate">weiYueEndDate</param>
		/// <param name="startPriceRange">startPriceRange</param>
		/// <param name="disableDefaultImportFee">disableDefaultImportFee</param>
		/// <param name="priceRangeStartTime">priceRangeStartTime</param>
		/// <param name="chargeFeeType">chargeFeeType</param>
		/// <param name="helper">helper</param>
		internal static void InsertChargeSummary(string @name, DateTime @addTime, int @companyID, int @feeType, int @typeID, int @orderBy, int @categoryID, int @ruleID, int @endTypeID, int @endNumber, decimal @summaryUnitPrice, string @unit, decimal @coefficient, string @remark, bool @isReading, int @endNumberCount, bool @isAllowImport, DateTime @summaryStartTime, DateTime @summaryEndStartTime, int @summaryChargeTypeCount, int @endNumberType, bool @autoToMonthEnd, string @biaoCategory, string @biaoName, bool @timeAuto, bool @isOrderFeeOn, decimal @weiYuePercent, string @relateCharges, int @chargeWeiYueType, bool @dayGunLi, string @weiYueStartDate, string @weiYueBefore, int @weiYueDays, string @calculateAreaType, string @weiYueActiveStartDate, string @weiYueActiveBeforeAfter, int @weiYueActiveCount, string @weiYueActiveDayMonth, string @weiYueEndDate, bool @startPriceRange, bool @disableDefaultImportFee, DateTime @priceRangeStartTime, int @chargeFeeType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(50),
	[AddTime] datetime,
	[CompanyID] int,
	[FeeType] int,
	[TypeID] int,
	[OrderBy] int,
	[CategoryID] int,
	[RuleID] int,
	[EndTypeID] int,
	[EndNumber] int,
	[SummaryUnitPrice] decimal(18, 4),
	[Unit] nvarchar(10),
	[Coefficient] decimal(18, 4),
	[Remark] ntext,
	[IsReading] bit,
	[EndNumberCount] int,
	[IsAllowImport] bit,
	[SummaryStartTime] datetime,
	[SummaryEndStartTime] datetime,
	[SummaryChargeTypeCount] int,
	[EndNumberType] int,
	[AutoToMonthEnd] bit,
	[BiaoCategory] nvarchar(200),
	[BiaoName] nvarchar(200),
	[TimeAuto] bit,
	[IsOrderFeeOn] bit,
	[WeiYuePercent] decimal(18, 4),
	[RelateCharges] nvarchar(200),
	[ChargeWeiYueType] int,
	[DayGunLi] bit,
	[WeiYueStartDate] nvarchar(50),
	[WeiYueBefore] nvarchar(50),
	[WeiYueDays] int,
	[CalculateAreaType] nvarchar(10),
	[WeiYueActiveStartDate] nvarchar(100),
	[WeiYueActiveBeforeAfter] nvarchar(100),
	[WeiYueActiveCount] int,
	[WeiYueActiveDayMonth] nvarchar(100),
	[WeiYueEndDate] nvarchar(100),
	[StartPriceRange] bit,
	[DisableDefaultImportFee] bit,
	[PriceRangeStartTime] datetime,
	[ChargeFeeType] int
);

INSERT INTO [dbo].[ChargeSummary] (
	[ChargeSummary].[Name],
	[ChargeSummary].[AddTime],
	[ChargeSummary].[CompanyID],
	[ChargeSummary].[FeeType],
	[ChargeSummary].[TypeID],
	[ChargeSummary].[OrderBy],
	[ChargeSummary].[CategoryID],
	[ChargeSummary].[RuleID],
	[ChargeSummary].[EndTypeID],
	[ChargeSummary].[EndNumber],
	[ChargeSummary].[SummaryUnitPrice],
	[ChargeSummary].[Unit],
	[ChargeSummary].[Coefficient],
	[ChargeSummary].[Remark],
	[ChargeSummary].[IsReading],
	[ChargeSummary].[EndNumberCount],
	[ChargeSummary].[IsAllowImport],
	[ChargeSummary].[SummaryStartTime],
	[ChargeSummary].[SummaryEndStartTime],
	[ChargeSummary].[SummaryChargeTypeCount],
	[ChargeSummary].[EndNumberType],
	[ChargeSummary].[AutoToMonthEnd],
	[ChargeSummary].[BiaoCategory],
	[ChargeSummary].[BiaoName],
	[ChargeSummary].[TimeAuto],
	[ChargeSummary].[IsOrderFeeOn],
	[ChargeSummary].[WeiYuePercent],
	[ChargeSummary].[RelateCharges],
	[ChargeSummary].[ChargeWeiYueType],
	[ChargeSummary].[DayGunLi],
	[ChargeSummary].[WeiYueStartDate],
	[ChargeSummary].[WeiYueBefore],
	[ChargeSummary].[WeiYueDays],
	[ChargeSummary].[CalculateAreaType],
	[ChargeSummary].[WeiYueActiveStartDate],
	[ChargeSummary].[WeiYueActiveBeforeAfter],
	[ChargeSummary].[WeiYueActiveCount],
	[ChargeSummary].[WeiYueActiveDayMonth],
	[ChargeSummary].[WeiYueEndDate],
	[ChargeSummary].[StartPriceRange],
	[ChargeSummary].[DisableDefaultImportFee],
	[ChargeSummary].[PriceRangeStartTime],
	[ChargeSummary].[ChargeFeeType]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[AddTime],
	INSERTED.[CompanyID],
	INSERTED.[FeeType],
	INSERTED.[TypeID],
	INSERTED.[OrderBy],
	INSERTED.[CategoryID],
	INSERTED.[RuleID],
	INSERTED.[EndTypeID],
	INSERTED.[EndNumber],
	INSERTED.[SummaryUnitPrice],
	INSERTED.[Unit],
	INSERTED.[Coefficient],
	INSERTED.[Remark],
	INSERTED.[IsReading],
	INSERTED.[EndNumberCount],
	INSERTED.[IsAllowImport],
	INSERTED.[SummaryStartTime],
	INSERTED.[SummaryEndStartTime],
	INSERTED.[SummaryChargeTypeCount],
	INSERTED.[EndNumberType],
	INSERTED.[AutoToMonthEnd],
	INSERTED.[BiaoCategory],
	INSERTED.[BiaoName],
	INSERTED.[TimeAuto],
	INSERTED.[IsOrderFeeOn],
	INSERTED.[WeiYuePercent],
	INSERTED.[RelateCharges],
	INSERTED.[ChargeWeiYueType],
	INSERTED.[DayGunLi],
	INSERTED.[WeiYueStartDate],
	INSERTED.[WeiYueBefore],
	INSERTED.[WeiYueDays],
	INSERTED.[CalculateAreaType],
	INSERTED.[WeiYueActiveStartDate],
	INSERTED.[WeiYueActiveBeforeAfter],
	INSERTED.[WeiYueActiveCount],
	INSERTED.[WeiYueActiveDayMonth],
	INSERTED.[WeiYueEndDate],
	INSERTED.[StartPriceRange],
	INSERTED.[DisableDefaultImportFee],
	INSERTED.[PriceRangeStartTime],
	INSERTED.[ChargeFeeType]
into @table
VALUES ( 
	@Name,
	@AddTime,
	@CompanyID,
	@FeeType,
	@TypeID,
	@OrderBy,
	@CategoryID,
	@RuleID,
	@EndTypeID,
	@EndNumber,
	@SummaryUnitPrice,
	@Unit,
	@Coefficient,
	@Remark,
	@IsReading,
	@EndNumberCount,
	@IsAllowImport,
	@SummaryStartTime,
	@SummaryEndStartTime,
	@SummaryChargeTypeCount,
	@EndNumberType,
	@AutoToMonthEnd,
	@BiaoCategory,
	@BiaoName,
	@TimeAuto,
	@IsOrderFeeOn,
	@WeiYuePercent,
	@RelateCharges,
	@ChargeWeiYueType,
	@DayGunLi,
	@WeiYueStartDate,
	@WeiYueBefore,
	@WeiYueDays,
	@CalculateAreaType,
	@WeiYueActiveStartDate,
	@WeiYueActiveBeforeAfter,
	@WeiYueActiveCount,
	@WeiYueActiveDayMonth,
	@WeiYueEndDate,
	@StartPriceRange,
	@DisableDefaultImportFee,
	@PriceRangeStartTime,
	@ChargeFeeType 
); 

SELECT 
	[ID],
	[Name],
	[AddTime],
	[CompanyID],
	[FeeType],
	[TypeID],
	[OrderBy],
	[CategoryID],
	[RuleID],
	[EndTypeID],
	[EndNumber],
	[SummaryUnitPrice],
	[Unit],
	[Coefficient],
	[Remark],
	[IsReading],
	[EndNumberCount],
	[IsAllowImport],
	[SummaryStartTime],
	[SummaryEndStartTime],
	[SummaryChargeTypeCount],
	[EndNumberType],
	[AutoToMonthEnd],
	[BiaoCategory],
	[BiaoName],
	[TimeAuto],
	[IsOrderFeeOn],
	[WeiYuePercent],
	[RelateCharges],
	[ChargeWeiYueType],
	[DayGunLi],
	[WeiYueStartDate],
	[WeiYueBefore],
	[WeiYueDays],
	[CalculateAreaType],
	[WeiYueActiveStartDate],
	[WeiYueActiveBeforeAfter],
	[WeiYueActiveCount],
	[WeiYueActiveDayMonth],
	[WeiYueEndDate],
	[StartPriceRange],
	[DisableDefaultImportFee],
	[PriceRangeStartTime],
	[ChargeFeeType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			parameters.Add(new SqlParameter("@FeeType", EntityBase.GetDatabaseValue(@feeType)));
			parameters.Add(new SqlParameter("@TypeID", EntityBase.GetDatabaseValue(@typeID)));
			parameters.Add(new SqlParameter("@OrderBy", EntityBase.GetDatabaseValue(@orderBy)));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			parameters.Add(new SqlParameter("@RuleID", EntityBase.GetDatabaseValue(@ruleID)));
			parameters.Add(new SqlParameter("@EndTypeID", EntityBase.GetDatabaseValue(@endTypeID)));
			parameters.Add(new SqlParameter("@EndNumber", EntityBase.GetDatabaseValue(@endNumber)));
			parameters.Add(new SqlParameter("@SummaryUnitPrice", EntityBase.GetDatabaseValue(@summaryUnitPrice)));
			parameters.Add(new SqlParameter("@Unit", EntityBase.GetDatabaseValue(@unit)));
			parameters.Add(new SqlParameter("@Coefficient", EntityBase.GetDatabaseValue(@coefficient)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@IsReading", @isReading));
			parameters.Add(new SqlParameter("@EndNumberCount", EntityBase.GetDatabaseValue(@endNumberCount)));
			parameters.Add(new SqlParameter("@IsAllowImport", @isAllowImport));
			parameters.Add(new SqlParameter("@SummaryStartTime", EntityBase.GetDatabaseValue(@summaryStartTime)));
			parameters.Add(new SqlParameter("@SummaryEndStartTime", EntityBase.GetDatabaseValue(@summaryEndStartTime)));
			parameters.Add(new SqlParameter("@SummaryChargeTypeCount", EntityBase.GetDatabaseValue(@summaryChargeTypeCount)));
			parameters.Add(new SqlParameter("@EndNumberType", EntityBase.GetDatabaseValue(@endNumberType)));
			parameters.Add(new SqlParameter("@AutoToMonthEnd", @autoToMonthEnd));
			parameters.Add(new SqlParameter("@BiaoCategory", EntityBase.GetDatabaseValue(@biaoCategory)));
			parameters.Add(new SqlParameter("@BiaoName", EntityBase.GetDatabaseValue(@biaoName)));
			parameters.Add(new SqlParameter("@TimeAuto", @timeAuto));
			parameters.Add(new SqlParameter("@IsOrderFeeOn", @isOrderFeeOn));
			parameters.Add(new SqlParameter("@WeiYuePercent", EntityBase.GetDatabaseValue(@weiYuePercent)));
			parameters.Add(new SqlParameter("@RelateCharges", EntityBase.GetDatabaseValue(@relateCharges)));
			parameters.Add(new SqlParameter("@ChargeWeiYueType", EntityBase.GetDatabaseValue(@chargeWeiYueType)));
			parameters.Add(new SqlParameter("@DayGunLi", @dayGunLi));
			parameters.Add(new SqlParameter("@WeiYueStartDate", EntityBase.GetDatabaseValue(@weiYueStartDate)));
			parameters.Add(new SqlParameter("@WeiYueBefore", EntityBase.GetDatabaseValue(@weiYueBefore)));
			parameters.Add(new SqlParameter("@WeiYueDays", EntityBase.GetDatabaseValue(@weiYueDays)));
			parameters.Add(new SqlParameter("@CalculateAreaType", EntityBase.GetDatabaseValue(@calculateAreaType)));
			parameters.Add(new SqlParameter("@WeiYueActiveStartDate", EntityBase.GetDatabaseValue(@weiYueActiveStartDate)));
			parameters.Add(new SqlParameter("@WeiYueActiveBeforeAfter", EntityBase.GetDatabaseValue(@weiYueActiveBeforeAfter)));
			parameters.Add(new SqlParameter("@WeiYueActiveCount", EntityBase.GetDatabaseValue(@weiYueActiveCount)));
			parameters.Add(new SqlParameter("@WeiYueActiveDayMonth", EntityBase.GetDatabaseValue(@weiYueActiveDayMonth)));
			parameters.Add(new SqlParameter("@WeiYueEndDate", EntityBase.GetDatabaseValue(@weiYueEndDate)));
			parameters.Add(new SqlParameter("@StartPriceRange", @startPriceRange));
			parameters.Add(new SqlParameter("@DisableDefaultImportFee", @disableDefaultImportFee));
			parameters.Add(new SqlParameter("@PriceRangeStartTime", EntityBase.GetDatabaseValue(@priceRangeStartTime)));
			parameters.Add(new SqlParameter("@ChargeFeeType", EntityBase.GetDatabaseValue(@chargeFeeType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ChargeSummary into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="addTime">addTime</param>
		/// <param name="companyID">companyID</param>
		/// <param name="feeType">feeType</param>
		/// <param name="typeID">typeID</param>
		/// <param name="orderBy">orderBy</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="ruleID">ruleID</param>
		/// <param name="endTypeID">endTypeID</param>
		/// <param name="endNumber">endNumber</param>
		/// <param name="summaryUnitPrice">summaryUnitPrice</param>
		/// <param name="unit">unit</param>
		/// <param name="coefficient">coefficient</param>
		/// <param name="remark">remark</param>
		/// <param name="isReading">isReading</param>
		/// <param name="endNumberCount">endNumberCount</param>
		/// <param name="isAllowImport">isAllowImport</param>
		/// <param name="summaryStartTime">summaryStartTime</param>
		/// <param name="summaryEndStartTime">summaryEndStartTime</param>
		/// <param name="summaryChargeTypeCount">summaryChargeTypeCount</param>
		/// <param name="endNumberType">endNumberType</param>
		/// <param name="autoToMonthEnd">autoToMonthEnd</param>
		/// <param name="biaoCategory">biaoCategory</param>
		/// <param name="biaoName">biaoName</param>
		/// <param name="timeAuto">timeAuto</param>
		/// <param name="isOrderFeeOn">isOrderFeeOn</param>
		/// <param name="weiYuePercent">weiYuePercent</param>
		/// <param name="relateCharges">relateCharges</param>
		/// <param name="chargeWeiYueType">chargeWeiYueType</param>
		/// <param name="dayGunLi">dayGunLi</param>
		/// <param name="weiYueStartDate">weiYueStartDate</param>
		/// <param name="weiYueBefore">weiYueBefore</param>
		/// <param name="weiYueDays">weiYueDays</param>
		/// <param name="calculateAreaType">calculateAreaType</param>
		/// <param name="weiYueActiveStartDate">weiYueActiveStartDate</param>
		/// <param name="weiYueActiveBeforeAfter">weiYueActiveBeforeAfter</param>
		/// <param name="weiYueActiveCount">weiYueActiveCount</param>
		/// <param name="weiYueActiveDayMonth">weiYueActiveDayMonth</param>
		/// <param name="weiYueEndDate">weiYueEndDate</param>
		/// <param name="startPriceRange">startPriceRange</param>
		/// <param name="disableDefaultImportFee">disableDefaultImportFee</param>
		/// <param name="priceRangeStartTime">priceRangeStartTime</param>
		/// <param name="chargeFeeType">chargeFeeType</param>
		public static void UpdateChargeSummary(int @iD, string @name, DateTime @addTime, int @companyID, int @feeType, int @typeID, int @orderBy, int @categoryID, int @ruleID, int @endTypeID, int @endNumber, decimal @summaryUnitPrice, string @unit, decimal @coefficient, string @remark, bool @isReading, int @endNumberCount, bool @isAllowImport, DateTime @summaryStartTime, DateTime @summaryEndStartTime, int @summaryChargeTypeCount, int @endNumberType, bool @autoToMonthEnd, string @biaoCategory, string @biaoName, bool @timeAuto, bool @isOrderFeeOn, decimal @weiYuePercent, string @relateCharges, int @chargeWeiYueType, bool @dayGunLi, string @weiYueStartDate, string @weiYueBefore, int @weiYueDays, string @calculateAreaType, string @weiYueActiveStartDate, string @weiYueActiveBeforeAfter, int @weiYueActiveCount, string @weiYueActiveDayMonth, string @weiYueEndDate, bool @startPriceRange, bool @disableDefaultImportFee, DateTime @priceRangeStartTime, int @chargeFeeType)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateChargeSummary(@iD, @name, @addTime, @companyID, @feeType, @typeID, @orderBy, @categoryID, @ruleID, @endTypeID, @endNumber, @summaryUnitPrice, @unit, @coefficient, @remark, @isReading, @endNumberCount, @isAllowImport, @summaryStartTime, @summaryEndStartTime, @summaryChargeTypeCount, @endNumberType, @autoToMonthEnd, @biaoCategory, @biaoName, @timeAuto, @isOrderFeeOn, @weiYuePercent, @relateCharges, @chargeWeiYueType, @dayGunLi, @weiYueStartDate, @weiYueBefore, @weiYueDays, @calculateAreaType, @weiYueActiveStartDate, @weiYueActiveBeforeAfter, @weiYueActiveCount, @weiYueActiveDayMonth, @weiYueEndDate, @startPriceRange, @disableDefaultImportFee, @priceRangeStartTime, @chargeFeeType, helper);
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
		/// Updates a ChargeSummary into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="addTime">addTime</param>
		/// <param name="companyID">companyID</param>
		/// <param name="feeType">feeType</param>
		/// <param name="typeID">typeID</param>
		/// <param name="orderBy">orderBy</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="ruleID">ruleID</param>
		/// <param name="endTypeID">endTypeID</param>
		/// <param name="endNumber">endNumber</param>
		/// <param name="summaryUnitPrice">summaryUnitPrice</param>
		/// <param name="unit">unit</param>
		/// <param name="coefficient">coefficient</param>
		/// <param name="remark">remark</param>
		/// <param name="isReading">isReading</param>
		/// <param name="endNumberCount">endNumberCount</param>
		/// <param name="isAllowImport">isAllowImport</param>
		/// <param name="summaryStartTime">summaryStartTime</param>
		/// <param name="summaryEndStartTime">summaryEndStartTime</param>
		/// <param name="summaryChargeTypeCount">summaryChargeTypeCount</param>
		/// <param name="endNumberType">endNumberType</param>
		/// <param name="autoToMonthEnd">autoToMonthEnd</param>
		/// <param name="biaoCategory">biaoCategory</param>
		/// <param name="biaoName">biaoName</param>
		/// <param name="timeAuto">timeAuto</param>
		/// <param name="isOrderFeeOn">isOrderFeeOn</param>
		/// <param name="weiYuePercent">weiYuePercent</param>
		/// <param name="relateCharges">relateCharges</param>
		/// <param name="chargeWeiYueType">chargeWeiYueType</param>
		/// <param name="dayGunLi">dayGunLi</param>
		/// <param name="weiYueStartDate">weiYueStartDate</param>
		/// <param name="weiYueBefore">weiYueBefore</param>
		/// <param name="weiYueDays">weiYueDays</param>
		/// <param name="calculateAreaType">calculateAreaType</param>
		/// <param name="weiYueActiveStartDate">weiYueActiveStartDate</param>
		/// <param name="weiYueActiveBeforeAfter">weiYueActiveBeforeAfter</param>
		/// <param name="weiYueActiveCount">weiYueActiveCount</param>
		/// <param name="weiYueActiveDayMonth">weiYueActiveDayMonth</param>
		/// <param name="weiYueEndDate">weiYueEndDate</param>
		/// <param name="startPriceRange">startPriceRange</param>
		/// <param name="disableDefaultImportFee">disableDefaultImportFee</param>
		/// <param name="priceRangeStartTime">priceRangeStartTime</param>
		/// <param name="chargeFeeType">chargeFeeType</param>
		/// <param name="helper">helper</param>
		internal static void UpdateChargeSummary(int @iD, string @name, DateTime @addTime, int @companyID, int @feeType, int @typeID, int @orderBy, int @categoryID, int @ruleID, int @endTypeID, int @endNumber, decimal @summaryUnitPrice, string @unit, decimal @coefficient, string @remark, bool @isReading, int @endNumberCount, bool @isAllowImport, DateTime @summaryStartTime, DateTime @summaryEndStartTime, int @summaryChargeTypeCount, int @endNumberType, bool @autoToMonthEnd, string @biaoCategory, string @biaoName, bool @timeAuto, bool @isOrderFeeOn, decimal @weiYuePercent, string @relateCharges, int @chargeWeiYueType, bool @dayGunLi, string @weiYueStartDate, string @weiYueBefore, int @weiYueDays, string @calculateAreaType, string @weiYueActiveStartDate, string @weiYueActiveBeforeAfter, int @weiYueActiveCount, string @weiYueActiveDayMonth, string @weiYueEndDate, bool @startPriceRange, bool @disableDefaultImportFee, DateTime @priceRangeStartTime, int @chargeFeeType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(50),
	[AddTime] datetime,
	[CompanyID] int,
	[FeeType] int,
	[TypeID] int,
	[OrderBy] int,
	[CategoryID] int,
	[RuleID] int,
	[EndTypeID] int,
	[EndNumber] int,
	[SummaryUnitPrice] decimal(18, 4),
	[Unit] nvarchar(10),
	[Coefficient] decimal(18, 4),
	[Remark] ntext,
	[IsReading] bit,
	[EndNumberCount] int,
	[IsAllowImport] bit,
	[SummaryStartTime] datetime,
	[SummaryEndStartTime] datetime,
	[SummaryChargeTypeCount] int,
	[EndNumberType] int,
	[AutoToMonthEnd] bit,
	[BiaoCategory] nvarchar(200),
	[BiaoName] nvarchar(200),
	[TimeAuto] bit,
	[IsOrderFeeOn] bit,
	[WeiYuePercent] decimal(18, 4),
	[RelateCharges] nvarchar(200),
	[ChargeWeiYueType] int,
	[DayGunLi] bit,
	[WeiYueStartDate] nvarchar(50),
	[WeiYueBefore] nvarchar(50),
	[WeiYueDays] int,
	[CalculateAreaType] nvarchar(10),
	[WeiYueActiveStartDate] nvarchar(100),
	[WeiYueActiveBeforeAfter] nvarchar(100),
	[WeiYueActiveCount] int,
	[WeiYueActiveDayMonth] nvarchar(100),
	[WeiYueEndDate] nvarchar(100),
	[StartPriceRange] bit,
	[DisableDefaultImportFee] bit,
	[PriceRangeStartTime] datetime,
	[ChargeFeeType] int
);

UPDATE [dbo].[ChargeSummary] SET 
	[ChargeSummary].[Name] = @Name,
	[ChargeSummary].[AddTime] = @AddTime,
	[ChargeSummary].[CompanyID] = @CompanyID,
	[ChargeSummary].[FeeType] = @FeeType,
	[ChargeSummary].[TypeID] = @TypeID,
	[ChargeSummary].[OrderBy] = @OrderBy,
	[ChargeSummary].[CategoryID] = @CategoryID,
	[ChargeSummary].[RuleID] = @RuleID,
	[ChargeSummary].[EndTypeID] = @EndTypeID,
	[ChargeSummary].[EndNumber] = @EndNumber,
	[ChargeSummary].[SummaryUnitPrice] = @SummaryUnitPrice,
	[ChargeSummary].[Unit] = @Unit,
	[ChargeSummary].[Coefficient] = @Coefficient,
	[ChargeSummary].[Remark] = @Remark,
	[ChargeSummary].[IsReading] = @IsReading,
	[ChargeSummary].[EndNumberCount] = @EndNumberCount,
	[ChargeSummary].[IsAllowImport] = @IsAllowImport,
	[ChargeSummary].[SummaryStartTime] = @SummaryStartTime,
	[ChargeSummary].[SummaryEndStartTime] = @SummaryEndStartTime,
	[ChargeSummary].[SummaryChargeTypeCount] = @SummaryChargeTypeCount,
	[ChargeSummary].[EndNumberType] = @EndNumberType,
	[ChargeSummary].[AutoToMonthEnd] = @AutoToMonthEnd,
	[ChargeSummary].[BiaoCategory] = @BiaoCategory,
	[ChargeSummary].[BiaoName] = @BiaoName,
	[ChargeSummary].[TimeAuto] = @TimeAuto,
	[ChargeSummary].[IsOrderFeeOn] = @IsOrderFeeOn,
	[ChargeSummary].[WeiYuePercent] = @WeiYuePercent,
	[ChargeSummary].[RelateCharges] = @RelateCharges,
	[ChargeSummary].[ChargeWeiYueType] = @ChargeWeiYueType,
	[ChargeSummary].[DayGunLi] = @DayGunLi,
	[ChargeSummary].[WeiYueStartDate] = @WeiYueStartDate,
	[ChargeSummary].[WeiYueBefore] = @WeiYueBefore,
	[ChargeSummary].[WeiYueDays] = @WeiYueDays,
	[ChargeSummary].[CalculateAreaType] = @CalculateAreaType,
	[ChargeSummary].[WeiYueActiveStartDate] = @WeiYueActiveStartDate,
	[ChargeSummary].[WeiYueActiveBeforeAfter] = @WeiYueActiveBeforeAfter,
	[ChargeSummary].[WeiYueActiveCount] = @WeiYueActiveCount,
	[ChargeSummary].[WeiYueActiveDayMonth] = @WeiYueActiveDayMonth,
	[ChargeSummary].[WeiYueEndDate] = @WeiYueEndDate,
	[ChargeSummary].[StartPriceRange] = @StartPriceRange,
	[ChargeSummary].[DisableDefaultImportFee] = @DisableDefaultImportFee,
	[ChargeSummary].[PriceRangeStartTime] = @PriceRangeStartTime,
	[ChargeSummary].[ChargeFeeType] = @ChargeFeeType 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[AddTime],
	INSERTED.[CompanyID],
	INSERTED.[FeeType],
	INSERTED.[TypeID],
	INSERTED.[OrderBy],
	INSERTED.[CategoryID],
	INSERTED.[RuleID],
	INSERTED.[EndTypeID],
	INSERTED.[EndNumber],
	INSERTED.[SummaryUnitPrice],
	INSERTED.[Unit],
	INSERTED.[Coefficient],
	INSERTED.[Remark],
	INSERTED.[IsReading],
	INSERTED.[EndNumberCount],
	INSERTED.[IsAllowImport],
	INSERTED.[SummaryStartTime],
	INSERTED.[SummaryEndStartTime],
	INSERTED.[SummaryChargeTypeCount],
	INSERTED.[EndNumberType],
	INSERTED.[AutoToMonthEnd],
	INSERTED.[BiaoCategory],
	INSERTED.[BiaoName],
	INSERTED.[TimeAuto],
	INSERTED.[IsOrderFeeOn],
	INSERTED.[WeiYuePercent],
	INSERTED.[RelateCharges],
	INSERTED.[ChargeWeiYueType],
	INSERTED.[DayGunLi],
	INSERTED.[WeiYueStartDate],
	INSERTED.[WeiYueBefore],
	INSERTED.[WeiYueDays],
	INSERTED.[CalculateAreaType],
	INSERTED.[WeiYueActiveStartDate],
	INSERTED.[WeiYueActiveBeforeAfter],
	INSERTED.[WeiYueActiveCount],
	INSERTED.[WeiYueActiveDayMonth],
	INSERTED.[WeiYueEndDate],
	INSERTED.[StartPriceRange],
	INSERTED.[DisableDefaultImportFee],
	INSERTED.[PriceRangeStartTime],
	INSERTED.[ChargeFeeType]
into @table
WHERE 
	[ChargeSummary].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[AddTime],
	[CompanyID],
	[FeeType],
	[TypeID],
	[OrderBy],
	[CategoryID],
	[RuleID],
	[EndTypeID],
	[EndNumber],
	[SummaryUnitPrice],
	[Unit],
	[Coefficient],
	[Remark],
	[IsReading],
	[EndNumberCount],
	[IsAllowImport],
	[SummaryStartTime],
	[SummaryEndStartTime],
	[SummaryChargeTypeCount],
	[EndNumberType],
	[AutoToMonthEnd],
	[BiaoCategory],
	[BiaoName],
	[TimeAuto],
	[IsOrderFeeOn],
	[WeiYuePercent],
	[RelateCharges],
	[ChargeWeiYueType],
	[DayGunLi],
	[WeiYueStartDate],
	[WeiYueBefore],
	[WeiYueDays],
	[CalculateAreaType],
	[WeiYueActiveStartDate],
	[WeiYueActiveBeforeAfter],
	[WeiYueActiveCount],
	[WeiYueActiveDayMonth],
	[WeiYueEndDate],
	[StartPriceRange],
	[DisableDefaultImportFee],
	[PriceRangeStartTime],
	[ChargeFeeType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			parameters.Add(new SqlParameter("@FeeType", EntityBase.GetDatabaseValue(@feeType)));
			parameters.Add(new SqlParameter("@TypeID", EntityBase.GetDatabaseValue(@typeID)));
			parameters.Add(new SqlParameter("@OrderBy", EntityBase.GetDatabaseValue(@orderBy)));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			parameters.Add(new SqlParameter("@RuleID", EntityBase.GetDatabaseValue(@ruleID)));
			parameters.Add(new SqlParameter("@EndTypeID", EntityBase.GetDatabaseValue(@endTypeID)));
			parameters.Add(new SqlParameter("@EndNumber", EntityBase.GetDatabaseValue(@endNumber)));
			parameters.Add(new SqlParameter("@SummaryUnitPrice", EntityBase.GetDatabaseValue(@summaryUnitPrice)));
			parameters.Add(new SqlParameter("@Unit", EntityBase.GetDatabaseValue(@unit)));
			parameters.Add(new SqlParameter("@Coefficient", EntityBase.GetDatabaseValue(@coefficient)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@IsReading", @isReading));
			parameters.Add(new SqlParameter("@EndNumberCount", EntityBase.GetDatabaseValue(@endNumberCount)));
			parameters.Add(new SqlParameter("@IsAllowImport", @isAllowImport));
			parameters.Add(new SqlParameter("@SummaryStartTime", EntityBase.GetDatabaseValue(@summaryStartTime)));
			parameters.Add(new SqlParameter("@SummaryEndStartTime", EntityBase.GetDatabaseValue(@summaryEndStartTime)));
			parameters.Add(new SqlParameter("@SummaryChargeTypeCount", EntityBase.GetDatabaseValue(@summaryChargeTypeCount)));
			parameters.Add(new SqlParameter("@EndNumberType", EntityBase.GetDatabaseValue(@endNumberType)));
			parameters.Add(new SqlParameter("@AutoToMonthEnd", @autoToMonthEnd));
			parameters.Add(new SqlParameter("@BiaoCategory", EntityBase.GetDatabaseValue(@biaoCategory)));
			parameters.Add(new SqlParameter("@BiaoName", EntityBase.GetDatabaseValue(@biaoName)));
			parameters.Add(new SqlParameter("@TimeAuto", @timeAuto));
			parameters.Add(new SqlParameter("@IsOrderFeeOn", @isOrderFeeOn));
			parameters.Add(new SqlParameter("@WeiYuePercent", EntityBase.GetDatabaseValue(@weiYuePercent)));
			parameters.Add(new SqlParameter("@RelateCharges", EntityBase.GetDatabaseValue(@relateCharges)));
			parameters.Add(new SqlParameter("@ChargeWeiYueType", EntityBase.GetDatabaseValue(@chargeWeiYueType)));
			parameters.Add(new SqlParameter("@DayGunLi", @dayGunLi));
			parameters.Add(new SqlParameter("@WeiYueStartDate", EntityBase.GetDatabaseValue(@weiYueStartDate)));
			parameters.Add(new SqlParameter("@WeiYueBefore", EntityBase.GetDatabaseValue(@weiYueBefore)));
			parameters.Add(new SqlParameter("@WeiYueDays", EntityBase.GetDatabaseValue(@weiYueDays)));
			parameters.Add(new SqlParameter("@CalculateAreaType", EntityBase.GetDatabaseValue(@calculateAreaType)));
			parameters.Add(new SqlParameter("@WeiYueActiveStartDate", EntityBase.GetDatabaseValue(@weiYueActiveStartDate)));
			parameters.Add(new SqlParameter("@WeiYueActiveBeforeAfter", EntityBase.GetDatabaseValue(@weiYueActiveBeforeAfter)));
			parameters.Add(new SqlParameter("@WeiYueActiveCount", EntityBase.GetDatabaseValue(@weiYueActiveCount)));
			parameters.Add(new SqlParameter("@WeiYueActiveDayMonth", EntityBase.GetDatabaseValue(@weiYueActiveDayMonth)));
			parameters.Add(new SqlParameter("@WeiYueEndDate", EntityBase.GetDatabaseValue(@weiYueEndDate)));
			parameters.Add(new SqlParameter("@StartPriceRange", @startPriceRange));
			parameters.Add(new SqlParameter("@DisableDefaultImportFee", @disableDefaultImportFee));
			parameters.Add(new SqlParameter("@PriceRangeStartTime", EntityBase.GetDatabaseValue(@priceRangeStartTime)));
			parameters.Add(new SqlParameter("@ChargeFeeType", EntityBase.GetDatabaseValue(@chargeFeeType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ChargeSummary from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteChargeSummary(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteChargeSummary(@iD, helper);
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
		/// Deletes a ChargeSummary from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteChargeSummary(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ChargeSummary]
WHERE 
	[ChargeSummary].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ChargeSummary object.
		/// </summary>
		/// <returns>The newly created ChargeSummary object.</returns>
		public static ChargeSummary CreateChargeSummary()
		{
			return InitializeNew<ChargeSummary>();
		}
		
		/// <summary>
		/// Retrieve information for a ChargeSummary by a ChargeSummary's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ChargeSummary</returns>
		public static ChargeSummary GetChargeSummary(int @iD)
		{
			string commandText = @"
SELECT 
" + ChargeSummary.SelectFieldList + @"
FROM [dbo].[ChargeSummary] 
WHERE 
	[ChargeSummary].[ID] = @ID " + ChargeSummary.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeSummary>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ChargeSummary by a ChargeSummary's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ChargeSummary</returns>
		public static ChargeSummary GetChargeSummary(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ChargeSummary.SelectFieldList + @"
FROM [dbo].[ChargeSummary] 
WHERE 
	[ChargeSummary].[ID] = @ID " + ChargeSummary.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeSummary>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ChargeSummary objects.
		/// </summary>
		/// <returns>The retrieved collection of ChargeSummary objects.</returns>
		public static EntityList<ChargeSummary> GetChargeSummaries()
		{
			string commandText = @"
SELECT " + ChargeSummary.SelectFieldList + "FROM [dbo].[ChargeSummary] " + ChargeSummary.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ChargeSummary>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ChargeSummary objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeSummary objects.</returns>
        public static EntityList<ChargeSummary> GetChargeSummaries(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeSummary>(SelectFieldList, "FROM [dbo].[ChargeSummary]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ChargeSummary objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeSummary objects.</returns>
        public static EntityList<ChargeSummary> GetChargeSummaries(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeSummary>(SelectFieldList, "FROM [dbo].[ChargeSummary]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ChargeSummary objects.</returns>
		protected static EntityList<ChargeSummary> GetChargeSummaries(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeSummaries(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeSummary objects.</returns>
		protected static EntityList<ChargeSummary> GetChargeSummaries(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeSummaries(string.Empty, where, parameters, ChargeSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeSummary objects.</returns>
		protected static EntityList<ChargeSummary> GetChargeSummaries(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeSummaries(prefix, where, parameters, ChargeSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeSummary objects.</returns>
		protected static EntityList<ChargeSummary> GetChargeSummaries(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeSummaries(string.Empty, where, parameters, ChargeSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeSummary objects.</returns>
		protected static EntityList<ChargeSummary> GetChargeSummaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeSummaries(prefix, where, parameters, ChargeSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeSummary objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ChargeSummary objects.</returns>
		protected static EntityList<ChargeSummary> GetChargeSummaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ChargeSummary.SelectFieldList + "FROM [dbo].[ChargeSummary] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ChargeSummary>(reader);
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
        protected static EntityList<ChargeSummary> GetChargeSummaries(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeSummary>(SelectFieldList, "FROM [dbo].[ChargeSummary] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ChargeSummary objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargeSummaryCount()
        {
            return GetChargeSummaryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ChargeSummary objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargeSummaryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ChargeSummary] " + where;

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
		public static partial class ChargeSummary_Properties
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
			public const string WeiYueActiveStartDate = "WeiYueActiveStartDate";
			public const string WeiYueActiveBeforeAfter = "WeiYueActiveBeforeAfter";
			public const string WeiYueActiveCount = "WeiYueActiveCount";
			public const string WeiYueActiveDayMonth = "WeiYueActiveDayMonth";
			public const string WeiYueEndDate = "WeiYueEndDate";
			public const string StartPriceRange = "StartPriceRange";
			public const string DisableDefaultImportFee = "DisableDefaultImportFee";
			public const string PriceRangeStartTime = "PriceRangeStartTime";
			public const string ChargeFeeType = "ChargeFeeType";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Name" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"CompanyID" , "int:"},
    			 {"FeeType" , "int:1-周期费用 4-临时费用 8-违约金"},
    			 {"TypeID" , "int:1-单价*计费面积(月度) 2-定额(月度) 3-单价*计费面积*公摊系数(月度) 4-定额(年度) 5-单价*计费面积(按天) 6-单价*计费面积/用量(一次性) 7-单价*计费面积(月度进位)"},
    			 {"OrderBy" , "int:"},
    			 {"CategoryID" , "int:1-收入 2-代收 3-押金-4预收"},
    			 {"RuleID" , "int:1-预收 2-实收 3-临时收取"},
    			 {"EndTypeID" , "int:计费规则 1-按当前自然日期 2-按计费开始日期 3-手动指定"},
    			 {"EndNumber" , "int:尾数处理  1直接进位、2、直接舍弃 3、四舍五入"},
    			 {"SummaryUnitPrice" , "decimal:单价"},
    			 {"Unit" , "string:单位"},
    			 {"Coefficient" , "decimal:系数"},
    			 {"Remark" , "string:"},
    			 {"IsReading" , "bool:是否抄表"},
    			 {"EndNumberCount" , "int:保存小数位数"},
    			 {"IsAllowImport" , "bool:允许导入"},
    			 {"SummaryStartTime" , "DateTime:"},
    			 {"SummaryEndStartTime" , "DateTime:"},
    			 {"SummaryChargeTypeCount" , "int:"},
    			 {"EndNumberType" , "int:自动取整至月末"},
    			 {"AutoToMonthEnd" , "bool:顺延规则  1按月、2、按日"},
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
    			 {"WeiYueActiveStartDate" , "string:"},
    			 {"WeiYueActiveBeforeAfter" , "string:"},
    			 {"WeiYueActiveCount" , "int:"},
    			 {"WeiYueActiveDayMonth" , "string:"},
    			 {"WeiYueEndDate" , "string:"},
    			 {"StartPriceRange" , "bool:"},
    			 {"DisableDefaultImportFee" , "bool:"},
    			 {"PriceRangeStartTime" , "DateTime:"},
    			 {"ChargeFeeType" , "int:"},
            };
		}
		#endregion
	}
}
