﻿using System;
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
	/// This object represents the properties and methods of a TempRoomFeeHistory.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("TempHistoryID: {TempHistoryID}")]
	public partial class TempRoomFeeHistory 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _tempHistoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, true, false)]
		public int TempHistoryID
		{
			[DebuggerStepThrough()]
			get { return this._tempHistoryID; }
			 set 
			{
				if (this._tempHistoryID != value) 
				{
					this._tempHistoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("TempHistoryID");
				}
			}
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
			set 
			{
				if (this._tempID != value) 
				{
					this._tempID = value;
					this.IsDirty = true;	
					OnPropertyChanged("TempID");
				}
			}
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
			set 
			{
				if (this._chargeFeeSummaryID != value) 
				{
					this._chargeFeeSummaryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeFeeSummaryID");
				}
			}
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
			set 
			{
				if (this._chargeFeeSummaryName != value) 
				{
					this._chargeFeeSummaryName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeFeeSummaryName");
				}
			}
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
			set 
			{
				if (this._chargeFeeCurrentBalance != value) 
				{
					this._chargeFeeCurrentBalance = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeFeeCurrentBalance");
				}
			}
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
			set 
			{
				if (this._cuiShouStartTime != value) 
				{
					this._cuiShouStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("CuiShouStartTime");
				}
			}
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
			set 
			{
				if (this._cuiShouEndTime != value) 
				{
					this._cuiShouEndTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("CuiShouEndTime");
				}
			}
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
			set 
			{
				if (this._relatedFeeID != value) 
				{
					this._relatedFeeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RelatedFeeID");
				}
			}
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
			set 
			{
				if (this._chongDiChargeID != value) 
				{
					this._chongDiChargeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChongDiChargeID");
				}
			}
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
			set 
			{
				if (this._backGuaranteeChargeTime != value) 
				{
					this._backGuaranteeChargeTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("BackGuaranteeChargeTime");
				}
			}
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
			set 
			{
				if (this._backGuaranteeRemark != value) 
				{
					this._backGuaranteeRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("BackGuaranteeRemark");
				}
			}
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
			set 
			{
				if (this._defaultChargeManID != value) 
				{
					this._defaultChargeManID = value;
					this.IsDirty = true;	
					OnPropertyChanged("DefaultChargeManID");
				}
			}
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
			set 
			{
				if (this._defaultChargeManName != value) 
				{
					this._defaultChargeManName = value;
					this.IsDirty = true;	
					OnPropertyChanged("DefaultChargeManName");
				}
			}
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
			set 
			{
				if (this._contract_RoomChargeID != value) 
				{
					this._contract_RoomChargeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("Contract_RoomChargeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _tradeNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TradeNo
		{
			[DebuggerStepThrough()]
			get { return this._tradeNo; }
			set 
			{
				if (this._tradeNo != value) 
				{
					this._tradeNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("TradeNo");
				}
			}
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
			set 
			{
				if (this._contractDivideID != value) 
				{
					this._contractDivideID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractDivideID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _orderID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OrderID
		{
			[DebuggerStepThrough()]
			get { return this._orderID; }
			set 
			{
				if (this._orderID != value) 
				{
					this._orderID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderID");
				}
			}
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
			set 
			{
				if (this._isTempFee != value) 
				{
					this._isTempFee = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsTempFee");
				}
			}
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
			set 
			{
				if (this._isMeterFee != value) 
				{
					this._isMeterFee = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsMeterFee");
				}
			}
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
			set 
			{
				if (this._isImportFee != value) 
				{
					this._isImportFee = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsImportFee");
				}
			}
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
			set 
			{
				if (this._isCycleFee != value) 
				{
					this._isCycleFee = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsCycleFee");
				}
			}
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
			set 
			{
				if (this._roomFeeCoefficient != value) 
				{
					this._roomFeeCoefficient = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomFeeCoefficient");
				}
			}
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
			set 
			{
				if (this._roomFeeWriteDate != value) 
				{
					this._roomFeeWriteDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomFeeWriteDate");
				}
			}
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
			set 
			{
				if (this._roomFeeStartPoint != value) 
				{
					this._roomFeeStartPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomFeeStartPoint");
				}
			}
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
			set 
			{
				if (this._roomFeeEndPoint != value) 
				{
					this._roomFeeEndPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomFeeEndPoint");
				}
			}
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
			set 
			{
				if (this._chargeMeterProjectFeeID != value) 
				{
					this._chargeMeterProjectFeeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeMeterProjectFeeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddUserName
		{
			[DebuggerStepThrough()]
			get { return this._addUserName; }
			set 
			{
				if (this._addUserName != value) 
				{
					this._addUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUserName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isContractDivideFee = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsContractDivideFee
		{
			[DebuggerStepThrough()]
			get { return this._isContractDivideFee; }
			set 
			{
				if (this._isContractDivideFee != value) 
				{
					this._isContractDivideFee = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsContractDivideFee");
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
	[TempHistoryID] int,
	[TempID] int,
	[ID] int,
	[RoomID] int,
	[UseCount] decimal(18, 3),
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
	[UnitPrice] decimal(18, 4),
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
	[PrintID] int,
	[ChargeState] int,
	[ReturnGuaranteeFee] bit,
	[ParentRoomFeeID] int,
	[ParentHistoryID] int,
	[IsCuiShou] bit,
	[ContractID] int,
	[DiscountID] int,
	[ChargeFeeSummaryID] int,
	[ChargeFeeSummaryName] nvarchar(100),
	[ChargeFeeCurrentBalance] decimal(18, 2),
	[CuiShouStartTime] datetime,
	[CuiShouEndTime] datetime,
	[RelatedFeeID] int,
	[ChongDiChargeID] int,
	[BackGuaranteeChargeTime] datetime,
	[BackGuaranteeRemark] ntext,
	[DefaultChargeManID] int,
	[DefaultChargeManName] nvarchar(100),
	[Contract_RoomChargeID] int,
	[TradeNo] nvarchar(500),
	[ContractDivideID] int,
	[OrderID] int,
	[IsTempFee] bit,
	[IsMeterFee] bit,
	[IsImportFee] bit,
	[IsCycleFee] bit,
	[RoomFeeCoefficient] decimal(18, 4),
	[RoomFeeWriteDate] datetime,
	[RoomFeeStartPoint] decimal(18, 2),
	[RoomFeeEndPoint] decimal(18, 2),
	[ChargeMeterProjectFeeID] int,
	[AddUserName] nvarchar(200),
	[IsContractDivideFee] bit
);

INSERT INTO [dbo].[TempRoomFeeHistory] (
	[TempRoomFeeHistory].[TempID],
	[TempRoomFeeHistory].[ID],
	[TempRoomFeeHistory].[RoomID],
	[TempRoomFeeHistory].[UseCount],
	[TempRoomFeeHistory].[StartTime],
	[TempRoomFeeHistory].[EndTime],
	[TempRoomFeeHistory].[Cost],
	[TempRoomFeeHistory].[Remark],
	[TempRoomFeeHistory].[AddTime],
	[TempRoomFeeHistory].[IsCharged],
	[TempRoomFeeHistory].[ChargeFeeID],
	[TempRoomFeeHistory].[ChargeID],
	[TempRoomFeeHistory].[IsStart],
	[TempRoomFeeHistory].[NewStartTime],
	[TempRoomFeeHistory].[ImportFeeID],
	[TempRoomFeeHistory].[UnitPrice],
	[TempRoomFeeHistory].[RealCost],
	[TempRoomFeeHistory].[Discount],
	[TempRoomFeeHistory].[OutDays],
	[TempRoomFeeHistory].[ChargeFee],
	[TempRoomFeeHistory].[TotalRealCost],
	[TempRoomFeeHistory].[RestCost],
	[TempRoomFeeHistory].[TotalDiscountCost],
	[TempRoomFeeHistory].[OnlyOnceCharge],
	[TempRoomFeeHistory].[NewEndTime],
	[TempRoomFeeHistory].[ChargeTime],
	[TempRoomFeeHistory].[ChargeMan],
	[TempRoomFeeHistory].[PrintNumber],
	[TempRoomFeeHistory].[PrintID],
	[TempRoomFeeHistory].[ChargeState],
	[TempRoomFeeHistory].[ReturnGuaranteeFee],
	[TempRoomFeeHistory].[ParentRoomFeeID],
	[TempRoomFeeHistory].[ParentHistoryID],
	[TempRoomFeeHistory].[IsCuiShou],
	[TempRoomFeeHistory].[ContractID],
	[TempRoomFeeHistory].[DiscountID],
	[TempRoomFeeHistory].[ChargeFeeSummaryID],
	[TempRoomFeeHistory].[ChargeFeeSummaryName],
	[TempRoomFeeHistory].[ChargeFeeCurrentBalance],
	[TempRoomFeeHistory].[CuiShouStartTime],
	[TempRoomFeeHistory].[CuiShouEndTime],
	[TempRoomFeeHistory].[RelatedFeeID],
	[TempRoomFeeHistory].[ChongDiChargeID],
	[TempRoomFeeHistory].[BackGuaranteeChargeTime],
	[TempRoomFeeHistory].[BackGuaranteeRemark],
	[TempRoomFeeHistory].[DefaultChargeManID],
	[TempRoomFeeHistory].[DefaultChargeManName],
	[TempRoomFeeHistory].[Contract_RoomChargeID],
	[TempRoomFeeHistory].[TradeNo],
	[TempRoomFeeHistory].[ContractDivideID],
	[TempRoomFeeHistory].[OrderID],
	[TempRoomFeeHistory].[IsTempFee],
	[TempRoomFeeHistory].[IsMeterFee],
	[TempRoomFeeHistory].[IsImportFee],
	[TempRoomFeeHistory].[IsCycleFee],
	[TempRoomFeeHistory].[RoomFeeCoefficient],
	[TempRoomFeeHistory].[RoomFeeWriteDate],
	[TempRoomFeeHistory].[RoomFeeStartPoint],
	[TempRoomFeeHistory].[RoomFeeEndPoint],
	[TempRoomFeeHistory].[ChargeMeterProjectFeeID],
	[TempRoomFeeHistory].[AddUserName],
	[TempRoomFeeHistory].[IsContractDivideFee]
) 
output 
	INSERTED.[TempHistoryID],
	INSERTED.[TempID],
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
	INSERTED.[PrintID],
	INSERTED.[ChargeState],
	INSERTED.[ReturnGuaranteeFee],
	INSERTED.[ParentRoomFeeID],
	INSERTED.[ParentHistoryID],
	INSERTED.[IsCuiShou],
	INSERTED.[ContractID],
	INSERTED.[DiscountID],
	INSERTED.[ChargeFeeSummaryID],
	INSERTED.[ChargeFeeSummaryName],
	INSERTED.[ChargeFeeCurrentBalance],
	INSERTED.[CuiShouStartTime],
	INSERTED.[CuiShouEndTime],
	INSERTED.[RelatedFeeID],
	INSERTED.[ChongDiChargeID],
	INSERTED.[BackGuaranteeChargeTime],
	INSERTED.[BackGuaranteeRemark],
	INSERTED.[DefaultChargeManID],
	INSERTED.[DefaultChargeManName],
	INSERTED.[Contract_RoomChargeID],
	INSERTED.[TradeNo],
	INSERTED.[ContractDivideID],
	INSERTED.[OrderID],
	INSERTED.[IsTempFee],
	INSERTED.[IsMeterFee],
	INSERTED.[IsImportFee],
	INSERTED.[IsCycleFee],
	INSERTED.[RoomFeeCoefficient],
	INSERTED.[RoomFeeWriteDate],
	INSERTED.[RoomFeeStartPoint],
	INSERTED.[RoomFeeEndPoint],
	INSERTED.[ChargeMeterProjectFeeID],
	INSERTED.[AddUserName],
	INSERTED.[IsContractDivideFee]
into @table
VALUES ( 
	@TempID,
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
	@DiscountID,
	@ChargeFeeSummaryID,
	@ChargeFeeSummaryName,
	@ChargeFeeCurrentBalance,
	@CuiShouStartTime,
	@CuiShouEndTime,
	@RelatedFeeID,
	@ChongDiChargeID,
	@BackGuaranteeChargeTime,
	@BackGuaranteeRemark,
	@DefaultChargeManID,
	@DefaultChargeManName,
	@Contract_RoomChargeID,
	@TradeNo,
	@ContractDivideID,
	@OrderID,
	@IsTempFee,
	@IsMeterFee,
	@IsImportFee,
	@IsCycleFee,
	@RoomFeeCoefficient,
	@RoomFeeWriteDate,
	@RoomFeeStartPoint,
	@RoomFeeEndPoint,
	@ChargeMeterProjectFeeID,
	@AddUserName,
	@IsContractDivideFee 
); 

SELECT 
	[TempHistoryID],
	[TempID],
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
	[PrintID],
	[ChargeState],
	[ReturnGuaranteeFee],
	[ParentRoomFeeID],
	[ParentHistoryID],
	[IsCuiShou],
	[ContractID],
	[DiscountID],
	[ChargeFeeSummaryID],
	[ChargeFeeSummaryName],
	[ChargeFeeCurrentBalance],
	[CuiShouStartTime],
	[CuiShouEndTime],
	[RelatedFeeID],
	[ChongDiChargeID],
	[BackGuaranteeChargeTime],
	[BackGuaranteeRemark],
	[DefaultChargeManID],
	[DefaultChargeManName],
	[Contract_RoomChargeID],
	[TradeNo],
	[ContractDivideID],
	[OrderID],
	[IsTempFee],
	[IsMeterFee],
	[IsImportFee],
	[IsCycleFee],
	[RoomFeeCoefficient],
	[RoomFeeWriteDate],
	[RoomFeeStartPoint],
	[RoomFeeEndPoint],
	[ChargeMeterProjectFeeID],
	[AddUserName],
	[IsContractDivideFee] 
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
	[TempHistoryID] int,
	[TempID] int,
	[ID] int,
	[RoomID] int,
	[UseCount] decimal(18, 3),
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
	[UnitPrice] decimal(18, 4),
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
	[PrintID] int,
	[ChargeState] int,
	[ReturnGuaranteeFee] bit,
	[ParentRoomFeeID] int,
	[ParentHistoryID] int,
	[IsCuiShou] bit,
	[ContractID] int,
	[DiscountID] int,
	[ChargeFeeSummaryID] int,
	[ChargeFeeSummaryName] nvarchar(100),
	[ChargeFeeCurrentBalance] decimal(18, 2),
	[CuiShouStartTime] datetime,
	[CuiShouEndTime] datetime,
	[RelatedFeeID] int,
	[ChongDiChargeID] int,
	[BackGuaranteeChargeTime] datetime,
	[BackGuaranteeRemark] ntext,
	[DefaultChargeManID] int,
	[DefaultChargeManName] nvarchar(100),
	[Contract_RoomChargeID] int,
	[TradeNo] nvarchar(500),
	[ContractDivideID] int,
	[OrderID] int,
	[IsTempFee] bit,
	[IsMeterFee] bit,
	[IsImportFee] bit,
	[IsCycleFee] bit,
	[RoomFeeCoefficient] decimal(18, 4),
	[RoomFeeWriteDate] datetime,
	[RoomFeeStartPoint] decimal(18, 2),
	[RoomFeeEndPoint] decimal(18, 2),
	[ChargeMeterProjectFeeID] int,
	[AddUserName] nvarchar(200),
	[IsContractDivideFee] bit
);

UPDATE [dbo].[TempRoomFeeHistory] SET 
	[TempRoomFeeHistory].[TempID] = @TempID,
	[TempRoomFeeHistory].[ID] = @ID,
	[TempRoomFeeHistory].[RoomID] = @RoomID,
	[TempRoomFeeHistory].[UseCount] = @UseCount,
	[TempRoomFeeHistory].[StartTime] = @StartTime,
	[TempRoomFeeHistory].[EndTime] = @EndTime,
	[TempRoomFeeHistory].[Cost] = @Cost,
	[TempRoomFeeHistory].[Remark] = @Remark,
	[TempRoomFeeHistory].[AddTime] = @AddTime,
	[TempRoomFeeHistory].[IsCharged] = @IsCharged,
	[TempRoomFeeHistory].[ChargeFeeID] = @ChargeFeeID,
	[TempRoomFeeHistory].[ChargeID] = @ChargeID,
	[TempRoomFeeHistory].[IsStart] = @IsStart,
	[TempRoomFeeHistory].[NewStartTime] = @NewStartTime,
	[TempRoomFeeHistory].[ImportFeeID] = @ImportFeeID,
	[TempRoomFeeHistory].[UnitPrice] = @UnitPrice,
	[TempRoomFeeHistory].[RealCost] = @RealCost,
	[TempRoomFeeHistory].[Discount] = @Discount,
	[TempRoomFeeHistory].[OutDays] = @OutDays,
	[TempRoomFeeHistory].[ChargeFee] = @ChargeFee,
	[TempRoomFeeHistory].[TotalRealCost] = @TotalRealCost,
	[TempRoomFeeHistory].[RestCost] = @RestCost,
	[TempRoomFeeHistory].[TotalDiscountCost] = @TotalDiscountCost,
	[TempRoomFeeHistory].[OnlyOnceCharge] = @OnlyOnceCharge,
	[TempRoomFeeHistory].[NewEndTime] = @NewEndTime,
	[TempRoomFeeHistory].[ChargeTime] = @ChargeTime,
	[TempRoomFeeHistory].[ChargeMan] = @ChargeMan,
	[TempRoomFeeHistory].[PrintNumber] = @PrintNumber,
	[TempRoomFeeHistory].[PrintID] = @PrintID,
	[TempRoomFeeHistory].[ChargeState] = @ChargeState,
	[TempRoomFeeHistory].[ReturnGuaranteeFee] = @ReturnGuaranteeFee,
	[TempRoomFeeHistory].[ParentRoomFeeID] = @ParentRoomFeeID,
	[TempRoomFeeHistory].[ParentHistoryID] = @ParentHistoryID,
	[TempRoomFeeHistory].[IsCuiShou] = @IsCuiShou,
	[TempRoomFeeHistory].[ContractID] = @ContractID,
	[TempRoomFeeHistory].[DiscountID] = @DiscountID,
	[TempRoomFeeHistory].[ChargeFeeSummaryID] = @ChargeFeeSummaryID,
	[TempRoomFeeHistory].[ChargeFeeSummaryName] = @ChargeFeeSummaryName,
	[TempRoomFeeHistory].[ChargeFeeCurrentBalance] = @ChargeFeeCurrentBalance,
	[TempRoomFeeHistory].[CuiShouStartTime] = @CuiShouStartTime,
	[TempRoomFeeHistory].[CuiShouEndTime] = @CuiShouEndTime,
	[TempRoomFeeHistory].[RelatedFeeID] = @RelatedFeeID,
	[TempRoomFeeHistory].[ChongDiChargeID] = @ChongDiChargeID,
	[TempRoomFeeHistory].[BackGuaranteeChargeTime] = @BackGuaranteeChargeTime,
	[TempRoomFeeHistory].[BackGuaranteeRemark] = @BackGuaranteeRemark,
	[TempRoomFeeHistory].[DefaultChargeManID] = @DefaultChargeManID,
	[TempRoomFeeHistory].[DefaultChargeManName] = @DefaultChargeManName,
	[TempRoomFeeHistory].[Contract_RoomChargeID] = @Contract_RoomChargeID,
	[TempRoomFeeHistory].[TradeNo] = @TradeNo,
	[TempRoomFeeHistory].[ContractDivideID] = @ContractDivideID,
	[TempRoomFeeHistory].[OrderID] = @OrderID,
	[TempRoomFeeHistory].[IsTempFee] = @IsTempFee,
	[TempRoomFeeHistory].[IsMeterFee] = @IsMeterFee,
	[TempRoomFeeHistory].[IsImportFee] = @IsImportFee,
	[TempRoomFeeHistory].[IsCycleFee] = @IsCycleFee,
	[TempRoomFeeHistory].[RoomFeeCoefficient] = @RoomFeeCoefficient,
	[TempRoomFeeHistory].[RoomFeeWriteDate] = @RoomFeeWriteDate,
	[TempRoomFeeHistory].[RoomFeeStartPoint] = @RoomFeeStartPoint,
	[TempRoomFeeHistory].[RoomFeeEndPoint] = @RoomFeeEndPoint,
	[TempRoomFeeHistory].[ChargeMeterProjectFeeID] = @ChargeMeterProjectFeeID,
	[TempRoomFeeHistory].[AddUserName] = @AddUserName,
	[TempRoomFeeHistory].[IsContractDivideFee] = @IsContractDivideFee 
output 
	INSERTED.[TempHistoryID],
	INSERTED.[TempID],
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
	INSERTED.[PrintID],
	INSERTED.[ChargeState],
	INSERTED.[ReturnGuaranteeFee],
	INSERTED.[ParentRoomFeeID],
	INSERTED.[ParentHistoryID],
	INSERTED.[IsCuiShou],
	INSERTED.[ContractID],
	INSERTED.[DiscountID],
	INSERTED.[ChargeFeeSummaryID],
	INSERTED.[ChargeFeeSummaryName],
	INSERTED.[ChargeFeeCurrentBalance],
	INSERTED.[CuiShouStartTime],
	INSERTED.[CuiShouEndTime],
	INSERTED.[RelatedFeeID],
	INSERTED.[ChongDiChargeID],
	INSERTED.[BackGuaranteeChargeTime],
	INSERTED.[BackGuaranteeRemark],
	INSERTED.[DefaultChargeManID],
	INSERTED.[DefaultChargeManName],
	INSERTED.[Contract_RoomChargeID],
	INSERTED.[TradeNo],
	INSERTED.[ContractDivideID],
	INSERTED.[OrderID],
	INSERTED.[IsTempFee],
	INSERTED.[IsMeterFee],
	INSERTED.[IsImportFee],
	INSERTED.[IsCycleFee],
	INSERTED.[RoomFeeCoefficient],
	INSERTED.[RoomFeeWriteDate],
	INSERTED.[RoomFeeStartPoint],
	INSERTED.[RoomFeeEndPoint],
	INSERTED.[ChargeMeterProjectFeeID],
	INSERTED.[AddUserName],
	INSERTED.[IsContractDivideFee]
into @table
WHERE 
	[TempRoomFeeHistory].[TempHistoryID] = @TempHistoryID

SELECT 
	[TempHistoryID],
	[TempID],
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
	[PrintID],
	[ChargeState],
	[ReturnGuaranteeFee],
	[ParentRoomFeeID],
	[ParentHistoryID],
	[IsCuiShou],
	[ContractID],
	[DiscountID],
	[ChargeFeeSummaryID],
	[ChargeFeeSummaryName],
	[ChargeFeeCurrentBalance],
	[CuiShouStartTime],
	[CuiShouEndTime],
	[RelatedFeeID],
	[ChongDiChargeID],
	[BackGuaranteeChargeTime],
	[BackGuaranteeRemark],
	[DefaultChargeManID],
	[DefaultChargeManName],
	[Contract_RoomChargeID],
	[TradeNo],
	[ContractDivideID],
	[OrderID],
	[IsTempFee],
	[IsMeterFee],
	[IsImportFee],
	[IsCycleFee],
	[RoomFeeCoefficient],
	[RoomFeeWriteDate],
	[RoomFeeStartPoint],
	[RoomFeeEndPoint],
	[ChargeMeterProjectFeeID],
	[AddUserName],
	[IsContractDivideFee] 
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
DELETE FROM [dbo].[TempRoomFeeHistory]
WHERE 
	[TempRoomFeeHistory].[TempHistoryID] = @TempHistoryID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public TempRoomFeeHistory() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetTempRoomFeeHistory(this.TempHistoryID));
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
	[TempRoomFeeHistory].[TempHistoryID],
	[TempRoomFeeHistory].[TempID],
	[TempRoomFeeHistory].[ID],
	[TempRoomFeeHistory].[RoomID],
	[TempRoomFeeHistory].[UseCount],
	[TempRoomFeeHistory].[StartTime],
	[TempRoomFeeHistory].[EndTime],
	[TempRoomFeeHistory].[Cost],
	[TempRoomFeeHistory].[Remark],
	[TempRoomFeeHistory].[AddTime],
	[TempRoomFeeHistory].[IsCharged],
	[TempRoomFeeHistory].[ChargeFeeID],
	[TempRoomFeeHistory].[ChargeID],
	[TempRoomFeeHistory].[IsStart],
	[TempRoomFeeHistory].[NewStartTime],
	[TempRoomFeeHistory].[ImportFeeID],
	[TempRoomFeeHistory].[UnitPrice],
	[TempRoomFeeHistory].[RealCost],
	[TempRoomFeeHistory].[Discount],
	[TempRoomFeeHistory].[OutDays],
	[TempRoomFeeHistory].[ChargeFee],
	[TempRoomFeeHistory].[TotalRealCost],
	[TempRoomFeeHistory].[RestCost],
	[TempRoomFeeHistory].[TotalDiscountCost],
	[TempRoomFeeHistory].[OnlyOnceCharge],
	[TempRoomFeeHistory].[NewEndTime],
	[TempRoomFeeHistory].[ChargeTime],
	[TempRoomFeeHistory].[ChargeMan],
	[TempRoomFeeHistory].[PrintNumber],
	[TempRoomFeeHistory].[PrintID],
	[TempRoomFeeHistory].[ChargeState],
	[TempRoomFeeHistory].[ReturnGuaranteeFee],
	[TempRoomFeeHistory].[ParentRoomFeeID],
	[TempRoomFeeHistory].[ParentHistoryID],
	[TempRoomFeeHistory].[IsCuiShou],
	[TempRoomFeeHistory].[ContractID],
	[TempRoomFeeHistory].[DiscountID],
	[TempRoomFeeHistory].[ChargeFeeSummaryID],
	[TempRoomFeeHistory].[ChargeFeeSummaryName],
	[TempRoomFeeHistory].[ChargeFeeCurrentBalance],
	[TempRoomFeeHistory].[CuiShouStartTime],
	[TempRoomFeeHistory].[CuiShouEndTime],
	[TempRoomFeeHistory].[RelatedFeeID],
	[TempRoomFeeHistory].[ChongDiChargeID],
	[TempRoomFeeHistory].[BackGuaranteeChargeTime],
	[TempRoomFeeHistory].[BackGuaranteeRemark],
	[TempRoomFeeHistory].[DefaultChargeManID],
	[TempRoomFeeHistory].[DefaultChargeManName],
	[TempRoomFeeHistory].[Contract_RoomChargeID],
	[TempRoomFeeHistory].[TradeNo],
	[TempRoomFeeHistory].[ContractDivideID],
	[TempRoomFeeHistory].[OrderID],
	[TempRoomFeeHistory].[IsTempFee],
	[TempRoomFeeHistory].[IsMeterFee],
	[TempRoomFeeHistory].[IsImportFee],
	[TempRoomFeeHistory].[IsCycleFee],
	[TempRoomFeeHistory].[RoomFeeCoefficient],
	[TempRoomFeeHistory].[RoomFeeWriteDate],
	[TempRoomFeeHistory].[RoomFeeStartPoint],
	[TempRoomFeeHistory].[RoomFeeEndPoint],
	[TempRoomFeeHistory].[ChargeMeterProjectFeeID],
	[TempRoomFeeHistory].[AddUserName],
	[TempRoomFeeHistory].[IsContractDivideFee]
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
                return "TempRoomFeeHistory";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a TempRoomFeeHistory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="tempID">tempID</param>
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
		/// <param name="chargeFeeSummaryID">chargeFeeSummaryID</param>
		/// <param name="chargeFeeSummaryName">chargeFeeSummaryName</param>
		/// <param name="chargeFeeCurrentBalance">chargeFeeCurrentBalance</param>
		/// <param name="cuiShouStartTime">cuiShouStartTime</param>
		/// <param name="cuiShouEndTime">cuiShouEndTime</param>
		/// <param name="relatedFeeID">relatedFeeID</param>
		/// <param name="chongDiChargeID">chongDiChargeID</param>
		/// <param name="backGuaranteeChargeTime">backGuaranteeChargeTime</param>
		/// <param name="backGuaranteeRemark">backGuaranteeRemark</param>
		/// <param name="defaultChargeManID">defaultChargeManID</param>
		/// <param name="defaultChargeManName">defaultChargeManName</param>
		/// <param name="contract_RoomChargeID">contract_RoomChargeID</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="contractDivideID">contractDivideID</param>
		/// <param name="orderID">orderID</param>
		/// <param name="isTempFee">isTempFee</param>
		/// <param name="isMeterFee">isMeterFee</param>
		/// <param name="isImportFee">isImportFee</param>
		/// <param name="isCycleFee">isCycleFee</param>
		/// <param name="roomFeeCoefficient">roomFeeCoefficient</param>
		/// <param name="roomFeeWriteDate">roomFeeWriteDate</param>
		/// <param name="roomFeeStartPoint">roomFeeStartPoint</param>
		/// <param name="roomFeeEndPoint">roomFeeEndPoint</param>
		/// <param name="chargeMeterProjectFeeID">chargeMeterProjectFeeID</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="isContractDivideFee">isContractDivideFee</param>
		public static void InsertTempRoomFeeHistory(int @tempID, int @iD, int @roomID, decimal @useCount, DateTime @startTime, DateTime @endTime, decimal @cost, string @remark, DateTime @addTime, bool @isCharged, int @chargeFeeID, int @chargeID, bool @isStart, DateTime @newStartTime, int @importFeeID, decimal @unitPrice, decimal @realCost, decimal @discount, int @outDays, decimal @chargeFee, decimal @totalRealCost, decimal @restCost, decimal @totalDiscountCost, bool @onlyOnceCharge, DateTime @newEndTime, DateTime @chargeTime, string @chargeMan, string @printNumber, int @printID, int @chargeState, bool @returnGuaranteeFee, int @parentRoomFeeID, int @parentHistoryID, bool @isCuiShou, int @contractID, int @discountID, int @chargeFeeSummaryID, string @chargeFeeSummaryName, decimal @chargeFeeCurrentBalance, DateTime @cuiShouStartTime, DateTime @cuiShouEndTime, int @relatedFeeID, int @chongDiChargeID, DateTime @backGuaranteeChargeTime, string @backGuaranteeRemark, int @defaultChargeManID, string @defaultChargeManName, int @contract_RoomChargeID, string @tradeNo, int @contractDivideID, int @orderID, bool @isTempFee, bool @isMeterFee, bool @isImportFee, bool @isCycleFee, decimal @roomFeeCoefficient, DateTime @roomFeeWriteDate, decimal @roomFeeStartPoint, decimal @roomFeeEndPoint, int @chargeMeterProjectFeeID, string @addUserName, bool @isContractDivideFee)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertTempRoomFeeHistory(@tempID, @iD, @roomID, @useCount, @startTime, @endTime, @cost, @remark, @addTime, @isCharged, @chargeFeeID, @chargeID, @isStart, @newStartTime, @importFeeID, @unitPrice, @realCost, @discount, @outDays, @chargeFee, @totalRealCost, @restCost, @totalDiscountCost, @onlyOnceCharge, @newEndTime, @chargeTime, @chargeMan, @printNumber, @printID, @chargeState, @returnGuaranteeFee, @parentRoomFeeID, @parentHistoryID, @isCuiShou, @contractID, @discountID, @chargeFeeSummaryID, @chargeFeeSummaryName, @chargeFeeCurrentBalance, @cuiShouStartTime, @cuiShouEndTime, @relatedFeeID, @chongDiChargeID, @backGuaranteeChargeTime, @backGuaranteeRemark, @defaultChargeManID, @defaultChargeManName, @contract_RoomChargeID, @tradeNo, @contractDivideID, @orderID, @isTempFee, @isMeterFee, @isImportFee, @isCycleFee, @roomFeeCoefficient, @roomFeeWriteDate, @roomFeeStartPoint, @roomFeeEndPoint, @chargeMeterProjectFeeID, @addUserName, @isContractDivideFee, helper);
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
		/// Insert a TempRoomFeeHistory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="tempID">tempID</param>
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
		/// <param name="chargeFeeSummaryID">chargeFeeSummaryID</param>
		/// <param name="chargeFeeSummaryName">chargeFeeSummaryName</param>
		/// <param name="chargeFeeCurrentBalance">chargeFeeCurrentBalance</param>
		/// <param name="cuiShouStartTime">cuiShouStartTime</param>
		/// <param name="cuiShouEndTime">cuiShouEndTime</param>
		/// <param name="relatedFeeID">relatedFeeID</param>
		/// <param name="chongDiChargeID">chongDiChargeID</param>
		/// <param name="backGuaranteeChargeTime">backGuaranteeChargeTime</param>
		/// <param name="backGuaranteeRemark">backGuaranteeRemark</param>
		/// <param name="defaultChargeManID">defaultChargeManID</param>
		/// <param name="defaultChargeManName">defaultChargeManName</param>
		/// <param name="contract_RoomChargeID">contract_RoomChargeID</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="contractDivideID">contractDivideID</param>
		/// <param name="orderID">orderID</param>
		/// <param name="isTempFee">isTempFee</param>
		/// <param name="isMeterFee">isMeterFee</param>
		/// <param name="isImportFee">isImportFee</param>
		/// <param name="isCycleFee">isCycleFee</param>
		/// <param name="roomFeeCoefficient">roomFeeCoefficient</param>
		/// <param name="roomFeeWriteDate">roomFeeWriteDate</param>
		/// <param name="roomFeeStartPoint">roomFeeStartPoint</param>
		/// <param name="roomFeeEndPoint">roomFeeEndPoint</param>
		/// <param name="chargeMeterProjectFeeID">chargeMeterProjectFeeID</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="isContractDivideFee">isContractDivideFee</param>
		/// <param name="helper">helper</param>
		internal static void InsertTempRoomFeeHistory(int @tempID, int @iD, int @roomID, decimal @useCount, DateTime @startTime, DateTime @endTime, decimal @cost, string @remark, DateTime @addTime, bool @isCharged, int @chargeFeeID, int @chargeID, bool @isStart, DateTime @newStartTime, int @importFeeID, decimal @unitPrice, decimal @realCost, decimal @discount, int @outDays, decimal @chargeFee, decimal @totalRealCost, decimal @restCost, decimal @totalDiscountCost, bool @onlyOnceCharge, DateTime @newEndTime, DateTime @chargeTime, string @chargeMan, string @printNumber, int @printID, int @chargeState, bool @returnGuaranteeFee, int @parentRoomFeeID, int @parentHistoryID, bool @isCuiShou, int @contractID, int @discountID, int @chargeFeeSummaryID, string @chargeFeeSummaryName, decimal @chargeFeeCurrentBalance, DateTime @cuiShouStartTime, DateTime @cuiShouEndTime, int @relatedFeeID, int @chongDiChargeID, DateTime @backGuaranteeChargeTime, string @backGuaranteeRemark, int @defaultChargeManID, string @defaultChargeManName, int @contract_RoomChargeID, string @tradeNo, int @contractDivideID, int @orderID, bool @isTempFee, bool @isMeterFee, bool @isImportFee, bool @isCycleFee, decimal @roomFeeCoefficient, DateTime @roomFeeWriteDate, decimal @roomFeeStartPoint, decimal @roomFeeEndPoint, int @chargeMeterProjectFeeID, string @addUserName, bool @isContractDivideFee, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[TempHistoryID] int,
	[TempID] int,
	[ID] int,
	[RoomID] int,
	[UseCount] decimal(18, 3),
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
	[UnitPrice] decimal(18, 4),
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
	[PrintID] int,
	[ChargeState] int,
	[ReturnGuaranteeFee] bit,
	[ParentRoomFeeID] int,
	[ParentHistoryID] int,
	[IsCuiShou] bit,
	[ContractID] int,
	[DiscountID] int,
	[ChargeFeeSummaryID] int,
	[ChargeFeeSummaryName] nvarchar(100),
	[ChargeFeeCurrentBalance] decimal(18, 2),
	[CuiShouStartTime] datetime,
	[CuiShouEndTime] datetime,
	[RelatedFeeID] int,
	[ChongDiChargeID] int,
	[BackGuaranteeChargeTime] datetime,
	[BackGuaranteeRemark] ntext,
	[DefaultChargeManID] int,
	[DefaultChargeManName] nvarchar(100),
	[Contract_RoomChargeID] int,
	[TradeNo] nvarchar(500),
	[ContractDivideID] int,
	[OrderID] int,
	[IsTempFee] bit,
	[IsMeterFee] bit,
	[IsImportFee] bit,
	[IsCycleFee] bit,
	[RoomFeeCoefficient] decimal(18, 4),
	[RoomFeeWriteDate] datetime,
	[RoomFeeStartPoint] decimal(18, 2),
	[RoomFeeEndPoint] decimal(18, 2),
	[ChargeMeterProjectFeeID] int,
	[AddUserName] nvarchar(200),
	[IsContractDivideFee] bit
);

INSERT INTO [dbo].[TempRoomFeeHistory] (
	[TempRoomFeeHistory].[TempID],
	[TempRoomFeeHistory].[ID],
	[TempRoomFeeHistory].[RoomID],
	[TempRoomFeeHistory].[UseCount],
	[TempRoomFeeHistory].[StartTime],
	[TempRoomFeeHistory].[EndTime],
	[TempRoomFeeHistory].[Cost],
	[TempRoomFeeHistory].[Remark],
	[TempRoomFeeHistory].[AddTime],
	[TempRoomFeeHistory].[IsCharged],
	[TempRoomFeeHistory].[ChargeFeeID],
	[TempRoomFeeHistory].[ChargeID],
	[TempRoomFeeHistory].[IsStart],
	[TempRoomFeeHistory].[NewStartTime],
	[TempRoomFeeHistory].[ImportFeeID],
	[TempRoomFeeHistory].[UnitPrice],
	[TempRoomFeeHistory].[RealCost],
	[TempRoomFeeHistory].[Discount],
	[TempRoomFeeHistory].[OutDays],
	[TempRoomFeeHistory].[ChargeFee],
	[TempRoomFeeHistory].[TotalRealCost],
	[TempRoomFeeHistory].[RestCost],
	[TempRoomFeeHistory].[TotalDiscountCost],
	[TempRoomFeeHistory].[OnlyOnceCharge],
	[TempRoomFeeHistory].[NewEndTime],
	[TempRoomFeeHistory].[ChargeTime],
	[TempRoomFeeHistory].[ChargeMan],
	[TempRoomFeeHistory].[PrintNumber],
	[TempRoomFeeHistory].[PrintID],
	[TempRoomFeeHistory].[ChargeState],
	[TempRoomFeeHistory].[ReturnGuaranteeFee],
	[TempRoomFeeHistory].[ParentRoomFeeID],
	[TempRoomFeeHistory].[ParentHistoryID],
	[TempRoomFeeHistory].[IsCuiShou],
	[TempRoomFeeHistory].[ContractID],
	[TempRoomFeeHistory].[DiscountID],
	[TempRoomFeeHistory].[ChargeFeeSummaryID],
	[TempRoomFeeHistory].[ChargeFeeSummaryName],
	[TempRoomFeeHistory].[ChargeFeeCurrentBalance],
	[TempRoomFeeHistory].[CuiShouStartTime],
	[TempRoomFeeHistory].[CuiShouEndTime],
	[TempRoomFeeHistory].[RelatedFeeID],
	[TempRoomFeeHistory].[ChongDiChargeID],
	[TempRoomFeeHistory].[BackGuaranteeChargeTime],
	[TempRoomFeeHistory].[BackGuaranteeRemark],
	[TempRoomFeeHistory].[DefaultChargeManID],
	[TempRoomFeeHistory].[DefaultChargeManName],
	[TempRoomFeeHistory].[Contract_RoomChargeID],
	[TempRoomFeeHistory].[TradeNo],
	[TempRoomFeeHistory].[ContractDivideID],
	[TempRoomFeeHistory].[OrderID],
	[TempRoomFeeHistory].[IsTempFee],
	[TempRoomFeeHistory].[IsMeterFee],
	[TempRoomFeeHistory].[IsImportFee],
	[TempRoomFeeHistory].[IsCycleFee],
	[TempRoomFeeHistory].[RoomFeeCoefficient],
	[TempRoomFeeHistory].[RoomFeeWriteDate],
	[TempRoomFeeHistory].[RoomFeeStartPoint],
	[TempRoomFeeHistory].[RoomFeeEndPoint],
	[TempRoomFeeHistory].[ChargeMeterProjectFeeID],
	[TempRoomFeeHistory].[AddUserName],
	[TempRoomFeeHistory].[IsContractDivideFee]
) 
output 
	INSERTED.[TempHistoryID],
	INSERTED.[TempID],
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
	INSERTED.[PrintID],
	INSERTED.[ChargeState],
	INSERTED.[ReturnGuaranteeFee],
	INSERTED.[ParentRoomFeeID],
	INSERTED.[ParentHistoryID],
	INSERTED.[IsCuiShou],
	INSERTED.[ContractID],
	INSERTED.[DiscountID],
	INSERTED.[ChargeFeeSummaryID],
	INSERTED.[ChargeFeeSummaryName],
	INSERTED.[ChargeFeeCurrentBalance],
	INSERTED.[CuiShouStartTime],
	INSERTED.[CuiShouEndTime],
	INSERTED.[RelatedFeeID],
	INSERTED.[ChongDiChargeID],
	INSERTED.[BackGuaranteeChargeTime],
	INSERTED.[BackGuaranteeRemark],
	INSERTED.[DefaultChargeManID],
	INSERTED.[DefaultChargeManName],
	INSERTED.[Contract_RoomChargeID],
	INSERTED.[TradeNo],
	INSERTED.[ContractDivideID],
	INSERTED.[OrderID],
	INSERTED.[IsTempFee],
	INSERTED.[IsMeterFee],
	INSERTED.[IsImportFee],
	INSERTED.[IsCycleFee],
	INSERTED.[RoomFeeCoefficient],
	INSERTED.[RoomFeeWriteDate],
	INSERTED.[RoomFeeStartPoint],
	INSERTED.[RoomFeeEndPoint],
	INSERTED.[ChargeMeterProjectFeeID],
	INSERTED.[AddUserName],
	INSERTED.[IsContractDivideFee]
into @table
VALUES ( 
	@TempID,
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
	@DiscountID,
	@ChargeFeeSummaryID,
	@ChargeFeeSummaryName,
	@ChargeFeeCurrentBalance,
	@CuiShouStartTime,
	@CuiShouEndTime,
	@RelatedFeeID,
	@ChongDiChargeID,
	@BackGuaranteeChargeTime,
	@BackGuaranteeRemark,
	@DefaultChargeManID,
	@DefaultChargeManName,
	@Contract_RoomChargeID,
	@TradeNo,
	@ContractDivideID,
	@OrderID,
	@IsTempFee,
	@IsMeterFee,
	@IsImportFee,
	@IsCycleFee,
	@RoomFeeCoefficient,
	@RoomFeeWriteDate,
	@RoomFeeStartPoint,
	@RoomFeeEndPoint,
	@ChargeMeterProjectFeeID,
	@AddUserName,
	@IsContractDivideFee 
); 

SELECT 
	[TempHistoryID],
	[TempID],
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
	[PrintID],
	[ChargeState],
	[ReturnGuaranteeFee],
	[ParentRoomFeeID],
	[ParentHistoryID],
	[IsCuiShou],
	[ContractID],
	[DiscountID],
	[ChargeFeeSummaryID],
	[ChargeFeeSummaryName],
	[ChargeFeeCurrentBalance],
	[CuiShouStartTime],
	[CuiShouEndTime],
	[RelatedFeeID],
	[ChongDiChargeID],
	[BackGuaranteeChargeTime],
	[BackGuaranteeRemark],
	[DefaultChargeManID],
	[DefaultChargeManName],
	[Contract_RoomChargeID],
	[TradeNo],
	[ContractDivideID],
	[OrderID],
	[IsTempFee],
	[IsMeterFee],
	[IsImportFee],
	[IsCycleFee],
	[RoomFeeCoefficient],
	[RoomFeeWriteDate],
	[RoomFeeStartPoint],
	[RoomFeeEndPoint],
	[ChargeMeterProjectFeeID],
	[AddUserName],
	[IsContractDivideFee] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TempID", EntityBase.GetDatabaseValue(@tempID)));
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
			parameters.Add(new SqlParameter("@ChargeFeeSummaryID", EntityBase.GetDatabaseValue(@chargeFeeSummaryID)));
			parameters.Add(new SqlParameter("@ChargeFeeSummaryName", EntityBase.GetDatabaseValue(@chargeFeeSummaryName)));
			parameters.Add(new SqlParameter("@ChargeFeeCurrentBalance", EntityBase.GetDatabaseValue(@chargeFeeCurrentBalance)));
			parameters.Add(new SqlParameter("@CuiShouStartTime", EntityBase.GetDatabaseValue(@cuiShouStartTime)));
			parameters.Add(new SqlParameter("@CuiShouEndTime", EntityBase.GetDatabaseValue(@cuiShouEndTime)));
			parameters.Add(new SqlParameter("@RelatedFeeID", EntityBase.GetDatabaseValue(@relatedFeeID)));
			parameters.Add(new SqlParameter("@ChongDiChargeID", EntityBase.GetDatabaseValue(@chongDiChargeID)));
			parameters.Add(new SqlParameter("@BackGuaranteeChargeTime", EntityBase.GetDatabaseValue(@backGuaranteeChargeTime)));
			parameters.Add(new SqlParameter("@BackGuaranteeRemark", EntityBase.GetDatabaseValue(@backGuaranteeRemark)));
			parameters.Add(new SqlParameter("@DefaultChargeManID", EntityBase.GetDatabaseValue(@defaultChargeManID)));
			parameters.Add(new SqlParameter("@DefaultChargeManName", EntityBase.GetDatabaseValue(@defaultChargeManName)));
			parameters.Add(new SqlParameter("@Contract_RoomChargeID", EntityBase.GetDatabaseValue(@contract_RoomChargeID)));
			parameters.Add(new SqlParameter("@TradeNo", EntityBase.GetDatabaseValue(@tradeNo)));
			parameters.Add(new SqlParameter("@ContractDivideID", EntityBase.GetDatabaseValue(@contractDivideID)));
			parameters.Add(new SqlParameter("@OrderID", EntityBase.GetDatabaseValue(@orderID)));
			parameters.Add(new SqlParameter("@IsTempFee", @isTempFee));
			parameters.Add(new SqlParameter("@IsMeterFee", @isMeterFee));
			parameters.Add(new SqlParameter("@IsImportFee", @isImportFee));
			parameters.Add(new SqlParameter("@IsCycleFee", @isCycleFee));
			parameters.Add(new SqlParameter("@RoomFeeCoefficient", EntityBase.GetDatabaseValue(@roomFeeCoefficient)));
			parameters.Add(new SqlParameter("@RoomFeeWriteDate", EntityBase.GetDatabaseValue(@roomFeeWriteDate)));
			parameters.Add(new SqlParameter("@RoomFeeStartPoint", EntityBase.GetDatabaseValue(@roomFeeStartPoint)));
			parameters.Add(new SqlParameter("@RoomFeeEndPoint", EntityBase.GetDatabaseValue(@roomFeeEndPoint)));
			parameters.Add(new SqlParameter("@ChargeMeterProjectFeeID", EntityBase.GetDatabaseValue(@chargeMeterProjectFeeID)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@IsContractDivideFee", @isContractDivideFee));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a TempRoomFeeHistory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="tempHistoryID">tempHistoryID</param>
		/// <param name="tempID">tempID</param>
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
		/// <param name="chargeFeeSummaryID">chargeFeeSummaryID</param>
		/// <param name="chargeFeeSummaryName">chargeFeeSummaryName</param>
		/// <param name="chargeFeeCurrentBalance">chargeFeeCurrentBalance</param>
		/// <param name="cuiShouStartTime">cuiShouStartTime</param>
		/// <param name="cuiShouEndTime">cuiShouEndTime</param>
		/// <param name="relatedFeeID">relatedFeeID</param>
		/// <param name="chongDiChargeID">chongDiChargeID</param>
		/// <param name="backGuaranteeChargeTime">backGuaranteeChargeTime</param>
		/// <param name="backGuaranteeRemark">backGuaranteeRemark</param>
		/// <param name="defaultChargeManID">defaultChargeManID</param>
		/// <param name="defaultChargeManName">defaultChargeManName</param>
		/// <param name="contract_RoomChargeID">contract_RoomChargeID</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="contractDivideID">contractDivideID</param>
		/// <param name="orderID">orderID</param>
		/// <param name="isTempFee">isTempFee</param>
		/// <param name="isMeterFee">isMeterFee</param>
		/// <param name="isImportFee">isImportFee</param>
		/// <param name="isCycleFee">isCycleFee</param>
		/// <param name="roomFeeCoefficient">roomFeeCoefficient</param>
		/// <param name="roomFeeWriteDate">roomFeeWriteDate</param>
		/// <param name="roomFeeStartPoint">roomFeeStartPoint</param>
		/// <param name="roomFeeEndPoint">roomFeeEndPoint</param>
		/// <param name="chargeMeterProjectFeeID">chargeMeterProjectFeeID</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="isContractDivideFee">isContractDivideFee</param>
		public static void UpdateTempRoomFeeHistory(int @tempHistoryID, int @tempID, int @iD, int @roomID, decimal @useCount, DateTime @startTime, DateTime @endTime, decimal @cost, string @remark, DateTime @addTime, bool @isCharged, int @chargeFeeID, int @chargeID, bool @isStart, DateTime @newStartTime, int @importFeeID, decimal @unitPrice, decimal @realCost, decimal @discount, int @outDays, decimal @chargeFee, decimal @totalRealCost, decimal @restCost, decimal @totalDiscountCost, bool @onlyOnceCharge, DateTime @newEndTime, DateTime @chargeTime, string @chargeMan, string @printNumber, int @printID, int @chargeState, bool @returnGuaranteeFee, int @parentRoomFeeID, int @parentHistoryID, bool @isCuiShou, int @contractID, int @discountID, int @chargeFeeSummaryID, string @chargeFeeSummaryName, decimal @chargeFeeCurrentBalance, DateTime @cuiShouStartTime, DateTime @cuiShouEndTime, int @relatedFeeID, int @chongDiChargeID, DateTime @backGuaranteeChargeTime, string @backGuaranteeRemark, int @defaultChargeManID, string @defaultChargeManName, int @contract_RoomChargeID, string @tradeNo, int @contractDivideID, int @orderID, bool @isTempFee, bool @isMeterFee, bool @isImportFee, bool @isCycleFee, decimal @roomFeeCoefficient, DateTime @roomFeeWriteDate, decimal @roomFeeStartPoint, decimal @roomFeeEndPoint, int @chargeMeterProjectFeeID, string @addUserName, bool @isContractDivideFee)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateTempRoomFeeHistory(@tempHistoryID, @tempID, @iD, @roomID, @useCount, @startTime, @endTime, @cost, @remark, @addTime, @isCharged, @chargeFeeID, @chargeID, @isStart, @newStartTime, @importFeeID, @unitPrice, @realCost, @discount, @outDays, @chargeFee, @totalRealCost, @restCost, @totalDiscountCost, @onlyOnceCharge, @newEndTime, @chargeTime, @chargeMan, @printNumber, @printID, @chargeState, @returnGuaranteeFee, @parentRoomFeeID, @parentHistoryID, @isCuiShou, @contractID, @discountID, @chargeFeeSummaryID, @chargeFeeSummaryName, @chargeFeeCurrentBalance, @cuiShouStartTime, @cuiShouEndTime, @relatedFeeID, @chongDiChargeID, @backGuaranteeChargeTime, @backGuaranteeRemark, @defaultChargeManID, @defaultChargeManName, @contract_RoomChargeID, @tradeNo, @contractDivideID, @orderID, @isTempFee, @isMeterFee, @isImportFee, @isCycleFee, @roomFeeCoefficient, @roomFeeWriteDate, @roomFeeStartPoint, @roomFeeEndPoint, @chargeMeterProjectFeeID, @addUserName, @isContractDivideFee, helper);
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
		/// Updates a TempRoomFeeHistory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="tempHistoryID">tempHistoryID</param>
		/// <param name="tempID">tempID</param>
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
		/// <param name="chargeFeeSummaryID">chargeFeeSummaryID</param>
		/// <param name="chargeFeeSummaryName">chargeFeeSummaryName</param>
		/// <param name="chargeFeeCurrentBalance">chargeFeeCurrentBalance</param>
		/// <param name="cuiShouStartTime">cuiShouStartTime</param>
		/// <param name="cuiShouEndTime">cuiShouEndTime</param>
		/// <param name="relatedFeeID">relatedFeeID</param>
		/// <param name="chongDiChargeID">chongDiChargeID</param>
		/// <param name="backGuaranteeChargeTime">backGuaranteeChargeTime</param>
		/// <param name="backGuaranteeRemark">backGuaranteeRemark</param>
		/// <param name="defaultChargeManID">defaultChargeManID</param>
		/// <param name="defaultChargeManName">defaultChargeManName</param>
		/// <param name="contract_RoomChargeID">contract_RoomChargeID</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="contractDivideID">contractDivideID</param>
		/// <param name="orderID">orderID</param>
		/// <param name="isTempFee">isTempFee</param>
		/// <param name="isMeterFee">isMeterFee</param>
		/// <param name="isImportFee">isImportFee</param>
		/// <param name="isCycleFee">isCycleFee</param>
		/// <param name="roomFeeCoefficient">roomFeeCoefficient</param>
		/// <param name="roomFeeWriteDate">roomFeeWriteDate</param>
		/// <param name="roomFeeStartPoint">roomFeeStartPoint</param>
		/// <param name="roomFeeEndPoint">roomFeeEndPoint</param>
		/// <param name="chargeMeterProjectFeeID">chargeMeterProjectFeeID</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="isContractDivideFee">isContractDivideFee</param>
		/// <param name="helper">helper</param>
		internal static void UpdateTempRoomFeeHistory(int @tempHistoryID, int @tempID, int @iD, int @roomID, decimal @useCount, DateTime @startTime, DateTime @endTime, decimal @cost, string @remark, DateTime @addTime, bool @isCharged, int @chargeFeeID, int @chargeID, bool @isStart, DateTime @newStartTime, int @importFeeID, decimal @unitPrice, decimal @realCost, decimal @discount, int @outDays, decimal @chargeFee, decimal @totalRealCost, decimal @restCost, decimal @totalDiscountCost, bool @onlyOnceCharge, DateTime @newEndTime, DateTime @chargeTime, string @chargeMan, string @printNumber, int @printID, int @chargeState, bool @returnGuaranteeFee, int @parentRoomFeeID, int @parentHistoryID, bool @isCuiShou, int @contractID, int @discountID, int @chargeFeeSummaryID, string @chargeFeeSummaryName, decimal @chargeFeeCurrentBalance, DateTime @cuiShouStartTime, DateTime @cuiShouEndTime, int @relatedFeeID, int @chongDiChargeID, DateTime @backGuaranteeChargeTime, string @backGuaranteeRemark, int @defaultChargeManID, string @defaultChargeManName, int @contract_RoomChargeID, string @tradeNo, int @contractDivideID, int @orderID, bool @isTempFee, bool @isMeterFee, bool @isImportFee, bool @isCycleFee, decimal @roomFeeCoefficient, DateTime @roomFeeWriteDate, decimal @roomFeeStartPoint, decimal @roomFeeEndPoint, int @chargeMeterProjectFeeID, string @addUserName, bool @isContractDivideFee, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[TempHistoryID] int,
	[TempID] int,
	[ID] int,
	[RoomID] int,
	[UseCount] decimal(18, 3),
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
	[UnitPrice] decimal(18, 4),
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
	[PrintID] int,
	[ChargeState] int,
	[ReturnGuaranteeFee] bit,
	[ParentRoomFeeID] int,
	[ParentHistoryID] int,
	[IsCuiShou] bit,
	[ContractID] int,
	[DiscountID] int,
	[ChargeFeeSummaryID] int,
	[ChargeFeeSummaryName] nvarchar(100),
	[ChargeFeeCurrentBalance] decimal(18, 2),
	[CuiShouStartTime] datetime,
	[CuiShouEndTime] datetime,
	[RelatedFeeID] int,
	[ChongDiChargeID] int,
	[BackGuaranteeChargeTime] datetime,
	[BackGuaranteeRemark] ntext,
	[DefaultChargeManID] int,
	[DefaultChargeManName] nvarchar(100),
	[Contract_RoomChargeID] int,
	[TradeNo] nvarchar(500),
	[ContractDivideID] int,
	[OrderID] int,
	[IsTempFee] bit,
	[IsMeterFee] bit,
	[IsImportFee] bit,
	[IsCycleFee] bit,
	[RoomFeeCoefficient] decimal(18, 4),
	[RoomFeeWriteDate] datetime,
	[RoomFeeStartPoint] decimal(18, 2),
	[RoomFeeEndPoint] decimal(18, 2),
	[ChargeMeterProjectFeeID] int,
	[AddUserName] nvarchar(200),
	[IsContractDivideFee] bit
);

UPDATE [dbo].[TempRoomFeeHistory] SET 
	[TempRoomFeeHistory].[TempID] = @TempID,
	[TempRoomFeeHistory].[ID] = @ID,
	[TempRoomFeeHistory].[RoomID] = @RoomID,
	[TempRoomFeeHistory].[UseCount] = @UseCount,
	[TempRoomFeeHistory].[StartTime] = @StartTime,
	[TempRoomFeeHistory].[EndTime] = @EndTime,
	[TempRoomFeeHistory].[Cost] = @Cost,
	[TempRoomFeeHistory].[Remark] = @Remark,
	[TempRoomFeeHistory].[AddTime] = @AddTime,
	[TempRoomFeeHistory].[IsCharged] = @IsCharged,
	[TempRoomFeeHistory].[ChargeFeeID] = @ChargeFeeID,
	[TempRoomFeeHistory].[ChargeID] = @ChargeID,
	[TempRoomFeeHistory].[IsStart] = @IsStart,
	[TempRoomFeeHistory].[NewStartTime] = @NewStartTime,
	[TempRoomFeeHistory].[ImportFeeID] = @ImportFeeID,
	[TempRoomFeeHistory].[UnitPrice] = @UnitPrice,
	[TempRoomFeeHistory].[RealCost] = @RealCost,
	[TempRoomFeeHistory].[Discount] = @Discount,
	[TempRoomFeeHistory].[OutDays] = @OutDays,
	[TempRoomFeeHistory].[ChargeFee] = @ChargeFee,
	[TempRoomFeeHistory].[TotalRealCost] = @TotalRealCost,
	[TempRoomFeeHistory].[RestCost] = @RestCost,
	[TempRoomFeeHistory].[TotalDiscountCost] = @TotalDiscountCost,
	[TempRoomFeeHistory].[OnlyOnceCharge] = @OnlyOnceCharge,
	[TempRoomFeeHistory].[NewEndTime] = @NewEndTime,
	[TempRoomFeeHistory].[ChargeTime] = @ChargeTime,
	[TempRoomFeeHistory].[ChargeMan] = @ChargeMan,
	[TempRoomFeeHistory].[PrintNumber] = @PrintNumber,
	[TempRoomFeeHistory].[PrintID] = @PrintID,
	[TempRoomFeeHistory].[ChargeState] = @ChargeState,
	[TempRoomFeeHistory].[ReturnGuaranteeFee] = @ReturnGuaranteeFee,
	[TempRoomFeeHistory].[ParentRoomFeeID] = @ParentRoomFeeID,
	[TempRoomFeeHistory].[ParentHistoryID] = @ParentHistoryID,
	[TempRoomFeeHistory].[IsCuiShou] = @IsCuiShou,
	[TempRoomFeeHistory].[ContractID] = @ContractID,
	[TempRoomFeeHistory].[DiscountID] = @DiscountID,
	[TempRoomFeeHistory].[ChargeFeeSummaryID] = @ChargeFeeSummaryID,
	[TempRoomFeeHistory].[ChargeFeeSummaryName] = @ChargeFeeSummaryName,
	[TempRoomFeeHistory].[ChargeFeeCurrentBalance] = @ChargeFeeCurrentBalance,
	[TempRoomFeeHistory].[CuiShouStartTime] = @CuiShouStartTime,
	[TempRoomFeeHistory].[CuiShouEndTime] = @CuiShouEndTime,
	[TempRoomFeeHistory].[RelatedFeeID] = @RelatedFeeID,
	[TempRoomFeeHistory].[ChongDiChargeID] = @ChongDiChargeID,
	[TempRoomFeeHistory].[BackGuaranteeChargeTime] = @BackGuaranteeChargeTime,
	[TempRoomFeeHistory].[BackGuaranteeRemark] = @BackGuaranteeRemark,
	[TempRoomFeeHistory].[DefaultChargeManID] = @DefaultChargeManID,
	[TempRoomFeeHistory].[DefaultChargeManName] = @DefaultChargeManName,
	[TempRoomFeeHistory].[Contract_RoomChargeID] = @Contract_RoomChargeID,
	[TempRoomFeeHistory].[TradeNo] = @TradeNo,
	[TempRoomFeeHistory].[ContractDivideID] = @ContractDivideID,
	[TempRoomFeeHistory].[OrderID] = @OrderID,
	[TempRoomFeeHistory].[IsTempFee] = @IsTempFee,
	[TempRoomFeeHistory].[IsMeterFee] = @IsMeterFee,
	[TempRoomFeeHistory].[IsImportFee] = @IsImportFee,
	[TempRoomFeeHistory].[IsCycleFee] = @IsCycleFee,
	[TempRoomFeeHistory].[RoomFeeCoefficient] = @RoomFeeCoefficient,
	[TempRoomFeeHistory].[RoomFeeWriteDate] = @RoomFeeWriteDate,
	[TempRoomFeeHistory].[RoomFeeStartPoint] = @RoomFeeStartPoint,
	[TempRoomFeeHistory].[RoomFeeEndPoint] = @RoomFeeEndPoint,
	[TempRoomFeeHistory].[ChargeMeterProjectFeeID] = @ChargeMeterProjectFeeID,
	[TempRoomFeeHistory].[AddUserName] = @AddUserName,
	[TempRoomFeeHistory].[IsContractDivideFee] = @IsContractDivideFee 
output 
	INSERTED.[TempHistoryID],
	INSERTED.[TempID],
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
	INSERTED.[PrintID],
	INSERTED.[ChargeState],
	INSERTED.[ReturnGuaranteeFee],
	INSERTED.[ParentRoomFeeID],
	INSERTED.[ParentHistoryID],
	INSERTED.[IsCuiShou],
	INSERTED.[ContractID],
	INSERTED.[DiscountID],
	INSERTED.[ChargeFeeSummaryID],
	INSERTED.[ChargeFeeSummaryName],
	INSERTED.[ChargeFeeCurrentBalance],
	INSERTED.[CuiShouStartTime],
	INSERTED.[CuiShouEndTime],
	INSERTED.[RelatedFeeID],
	INSERTED.[ChongDiChargeID],
	INSERTED.[BackGuaranteeChargeTime],
	INSERTED.[BackGuaranteeRemark],
	INSERTED.[DefaultChargeManID],
	INSERTED.[DefaultChargeManName],
	INSERTED.[Contract_RoomChargeID],
	INSERTED.[TradeNo],
	INSERTED.[ContractDivideID],
	INSERTED.[OrderID],
	INSERTED.[IsTempFee],
	INSERTED.[IsMeterFee],
	INSERTED.[IsImportFee],
	INSERTED.[IsCycleFee],
	INSERTED.[RoomFeeCoefficient],
	INSERTED.[RoomFeeWriteDate],
	INSERTED.[RoomFeeStartPoint],
	INSERTED.[RoomFeeEndPoint],
	INSERTED.[ChargeMeterProjectFeeID],
	INSERTED.[AddUserName],
	INSERTED.[IsContractDivideFee]
into @table
WHERE 
	[TempRoomFeeHistory].[TempHistoryID] = @TempHistoryID

SELECT 
	[TempHistoryID],
	[TempID],
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
	[PrintID],
	[ChargeState],
	[ReturnGuaranteeFee],
	[ParentRoomFeeID],
	[ParentHistoryID],
	[IsCuiShou],
	[ContractID],
	[DiscountID],
	[ChargeFeeSummaryID],
	[ChargeFeeSummaryName],
	[ChargeFeeCurrentBalance],
	[CuiShouStartTime],
	[CuiShouEndTime],
	[RelatedFeeID],
	[ChongDiChargeID],
	[BackGuaranteeChargeTime],
	[BackGuaranteeRemark],
	[DefaultChargeManID],
	[DefaultChargeManName],
	[Contract_RoomChargeID],
	[TradeNo],
	[ContractDivideID],
	[OrderID],
	[IsTempFee],
	[IsMeterFee],
	[IsImportFee],
	[IsCycleFee],
	[RoomFeeCoefficient],
	[RoomFeeWriteDate],
	[RoomFeeStartPoint],
	[RoomFeeEndPoint],
	[ChargeMeterProjectFeeID],
	[AddUserName],
	[IsContractDivideFee] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TempHistoryID", EntityBase.GetDatabaseValue(@tempHistoryID)));
			parameters.Add(new SqlParameter("@TempID", EntityBase.GetDatabaseValue(@tempID)));
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
			parameters.Add(new SqlParameter("@ChargeFeeSummaryID", EntityBase.GetDatabaseValue(@chargeFeeSummaryID)));
			parameters.Add(new SqlParameter("@ChargeFeeSummaryName", EntityBase.GetDatabaseValue(@chargeFeeSummaryName)));
			parameters.Add(new SqlParameter("@ChargeFeeCurrentBalance", EntityBase.GetDatabaseValue(@chargeFeeCurrentBalance)));
			parameters.Add(new SqlParameter("@CuiShouStartTime", EntityBase.GetDatabaseValue(@cuiShouStartTime)));
			parameters.Add(new SqlParameter("@CuiShouEndTime", EntityBase.GetDatabaseValue(@cuiShouEndTime)));
			parameters.Add(new SqlParameter("@RelatedFeeID", EntityBase.GetDatabaseValue(@relatedFeeID)));
			parameters.Add(new SqlParameter("@ChongDiChargeID", EntityBase.GetDatabaseValue(@chongDiChargeID)));
			parameters.Add(new SqlParameter("@BackGuaranteeChargeTime", EntityBase.GetDatabaseValue(@backGuaranteeChargeTime)));
			parameters.Add(new SqlParameter("@BackGuaranteeRemark", EntityBase.GetDatabaseValue(@backGuaranteeRemark)));
			parameters.Add(new SqlParameter("@DefaultChargeManID", EntityBase.GetDatabaseValue(@defaultChargeManID)));
			parameters.Add(new SqlParameter("@DefaultChargeManName", EntityBase.GetDatabaseValue(@defaultChargeManName)));
			parameters.Add(new SqlParameter("@Contract_RoomChargeID", EntityBase.GetDatabaseValue(@contract_RoomChargeID)));
			parameters.Add(new SqlParameter("@TradeNo", EntityBase.GetDatabaseValue(@tradeNo)));
			parameters.Add(new SqlParameter("@ContractDivideID", EntityBase.GetDatabaseValue(@contractDivideID)));
			parameters.Add(new SqlParameter("@OrderID", EntityBase.GetDatabaseValue(@orderID)));
			parameters.Add(new SqlParameter("@IsTempFee", @isTempFee));
			parameters.Add(new SqlParameter("@IsMeterFee", @isMeterFee));
			parameters.Add(new SqlParameter("@IsImportFee", @isImportFee));
			parameters.Add(new SqlParameter("@IsCycleFee", @isCycleFee));
			parameters.Add(new SqlParameter("@RoomFeeCoefficient", EntityBase.GetDatabaseValue(@roomFeeCoefficient)));
			parameters.Add(new SqlParameter("@RoomFeeWriteDate", EntityBase.GetDatabaseValue(@roomFeeWriteDate)));
			parameters.Add(new SqlParameter("@RoomFeeStartPoint", EntityBase.GetDatabaseValue(@roomFeeStartPoint)));
			parameters.Add(new SqlParameter("@RoomFeeEndPoint", EntityBase.GetDatabaseValue(@roomFeeEndPoint)));
			parameters.Add(new SqlParameter("@ChargeMeterProjectFeeID", EntityBase.GetDatabaseValue(@chargeMeterProjectFeeID)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@IsContractDivideFee", @isContractDivideFee));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a TempRoomFeeHistory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="tempHistoryID">tempHistoryID</param>
		public static void DeleteTempRoomFeeHistory(int @tempHistoryID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteTempRoomFeeHistory(@tempHistoryID, helper);
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
		/// Deletes a TempRoomFeeHistory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="tempHistoryID">tempHistoryID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteTempRoomFeeHistory(int @tempHistoryID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[TempRoomFeeHistory]
WHERE 
	[TempRoomFeeHistory].[TempHistoryID] = @TempHistoryID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TempHistoryID", @tempHistoryID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new TempRoomFeeHistory object.
		/// </summary>
		/// <returns>The newly created TempRoomFeeHistory object.</returns>
		public static TempRoomFeeHistory CreateTempRoomFeeHistory()
		{
			return InitializeNew<TempRoomFeeHistory>();
		}
		
		/// <summary>
		/// Retrieve information for a TempRoomFeeHistory by a TempRoomFeeHistory's unique identifier.
		/// </summary>
		/// <param name="tempHistoryID">tempHistoryID</param>
		/// <returns>TempRoomFeeHistory</returns>
		public static TempRoomFeeHistory GetTempRoomFeeHistory(int @tempHistoryID)
		{
			string commandText = @"
SELECT 
" + TempRoomFeeHistory.SelectFieldList + @"
FROM [dbo].[TempRoomFeeHistory] 
WHERE 
	[TempRoomFeeHistory].[TempHistoryID] = @TempHistoryID " + TempRoomFeeHistory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TempHistoryID", @tempHistoryID));
			
			return GetOne<TempRoomFeeHistory>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a TempRoomFeeHistory by a TempRoomFeeHistory's unique identifier.
		/// </summary>
		/// <param name="tempHistoryID">tempHistoryID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>TempRoomFeeHistory</returns>
		public static TempRoomFeeHistory GetTempRoomFeeHistory(int @tempHistoryID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + TempRoomFeeHistory.SelectFieldList + @"
FROM [dbo].[TempRoomFeeHistory] 
WHERE 
	[TempRoomFeeHistory].[TempHistoryID] = @TempHistoryID " + TempRoomFeeHistory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TempHistoryID", @tempHistoryID));
			
			return GetOne<TempRoomFeeHistory>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection TempRoomFeeHistory objects.
		/// </summary>
		/// <returns>The retrieved collection of TempRoomFeeHistory objects.</returns>
		public static EntityList<TempRoomFeeHistory> GetTempRoomFeeHistories()
		{
			string commandText = @"
SELECT " + TempRoomFeeHistory.SelectFieldList + "FROM [dbo].[TempRoomFeeHistory] " + TempRoomFeeHistory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<TempRoomFeeHistory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection TempRoomFeeHistory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of TempRoomFeeHistory objects.</returns>
        public static EntityList<TempRoomFeeHistory> GetTempRoomFeeHistories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<TempRoomFeeHistory>(SelectFieldList, "FROM [dbo].[TempRoomFeeHistory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection TempRoomFeeHistory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of TempRoomFeeHistory objects.</returns>
        public static EntityList<TempRoomFeeHistory> GetTempRoomFeeHistories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<TempRoomFeeHistory>(SelectFieldList, "FROM [dbo].[TempRoomFeeHistory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection TempRoomFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of TempRoomFeeHistory objects.</returns>
		protected static EntityList<TempRoomFeeHistory> GetTempRoomFeeHistories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetTempRoomFeeHistories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection TempRoomFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of TempRoomFeeHistory objects.</returns>
		protected static EntityList<TempRoomFeeHistory> GetTempRoomFeeHistories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetTempRoomFeeHistories(string.Empty, where, parameters, TempRoomFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection TempRoomFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of TempRoomFeeHistory objects.</returns>
		protected static EntityList<TempRoomFeeHistory> GetTempRoomFeeHistories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetTempRoomFeeHistories(prefix, where, parameters, TempRoomFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection TempRoomFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of TempRoomFeeHistory objects.</returns>
		protected static EntityList<TempRoomFeeHistory> GetTempRoomFeeHistories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetTempRoomFeeHistories(string.Empty, where, parameters, TempRoomFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection TempRoomFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of TempRoomFeeHistory objects.</returns>
		protected static EntityList<TempRoomFeeHistory> GetTempRoomFeeHistories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetTempRoomFeeHistories(prefix, where, parameters, TempRoomFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection TempRoomFeeHistory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of TempRoomFeeHistory objects.</returns>
		protected static EntityList<TempRoomFeeHistory> GetTempRoomFeeHistories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + TempRoomFeeHistory.SelectFieldList + "FROM [dbo].[TempRoomFeeHistory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<TempRoomFeeHistory>(reader);
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
        protected static EntityList<TempRoomFeeHistory> GetTempRoomFeeHistories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<TempRoomFeeHistory>(SelectFieldList, "FROM [dbo].[TempRoomFeeHistory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of TempRoomFeeHistory objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetTempRoomFeeHistoryCount()
        {
            return GetTempRoomFeeHistoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of TempRoomFeeHistory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetTempRoomFeeHistoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[TempRoomFeeHistory] " + where;

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
		public static partial class TempRoomFeeHistory_Properties
		{
			public const string TempHistoryID = "TempHistoryID";
			public const string TempID = "TempID";
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
			public const string PrintID = "PrintID";
			public const string ChargeState = "ChargeState";
			public const string ReturnGuaranteeFee = "ReturnGuaranteeFee";
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
			public const string Contract_RoomChargeID = "Contract_RoomChargeID";
			public const string TradeNo = "TradeNo";
			public const string ContractDivideID = "ContractDivideID";
			public const string OrderID = "OrderID";
			public const string IsTempFee = "IsTempFee";
			public const string IsMeterFee = "IsMeterFee";
			public const string IsImportFee = "IsImportFee";
			public const string IsCycleFee = "IsCycleFee";
			public const string RoomFeeCoefficient = "RoomFeeCoefficient";
			public const string RoomFeeWriteDate = "RoomFeeWriteDate";
			public const string RoomFeeStartPoint = "RoomFeeStartPoint";
			public const string RoomFeeEndPoint = "RoomFeeEndPoint";
			public const string ChargeMeterProjectFeeID = "ChargeMeterProjectFeeID";
			public const string AddUserName = "AddUserName";
			public const string IsContractDivideFee = "IsContractDivideFee";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"TempHistoryID" , "int:"},
    			 {"TempID" , "int:"},
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
    			 {"PrintID" , "int:"},
    			 {"ChargeState" , "int:"},
    			 {"ReturnGuaranteeFee" , "bool:"},
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
    			 {"Contract_RoomChargeID" , "int:"},
    			 {"TradeNo" , "string:"},
    			 {"ContractDivideID" , "int:"},
    			 {"OrderID" , "int:"},
    			 {"IsTempFee" , "bool:"},
    			 {"IsMeterFee" , "bool:"},
    			 {"IsImportFee" , "bool:"},
    			 {"IsCycleFee" , "bool:"},
    			 {"RoomFeeCoefficient" , "decimal:"},
    			 {"RoomFeeWriteDate" , "DateTime:"},
    			 {"RoomFeeStartPoint" , "decimal:"},
    			 {"RoomFeeEndPoint" , "decimal:"},
    			 {"ChargeMeterProjectFeeID" , "int:"},
    			 {"AddUserName" , "string:"},
    			 {"IsContractDivideFee" , "bool:"},
            };
		}
		#endregion
	}
}
