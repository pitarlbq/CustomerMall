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
	/// This object represents the properties and methods of a PrintRoomFeeHistory.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class PrintRoomFeeHistory 
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
		private decimal _cost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
		private string _costCapital = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CostCapital
		{
			[DebuggerStepThrough()]
			get { return this._costCapital; }
			set 
			{
				if (this._costCapital != value) 
				{
					this._costCapital = value;
					this.IsDirty = true;	
					OnPropertyChanged("CostCapital");
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
		private decimal _preChargeMoney = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal PreChargeMoney
		{
			[DebuggerStepThrough()]
			get { return this._preChargeMoney; }
			set 
			{
				if (this._preChargeMoney != value) 
				{
					this._preChargeMoney = value;
					this.IsDirty = true;	
					OnPropertyChanged("PreChargeMoney");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _discountMoney = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal DiscountMoney
		{
			[DebuggerStepThrough()]
			get { return this._discountMoney; }
			set 
			{
				if (this._discountMoney != value) 
				{
					this._discountMoney = value;
					this.IsDirty = true;	
					OnPropertyChanged("DiscountMoney");
				}
			}
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
			set 
			{
				if (this._realMoneyCost1 != value) 
				{
					this._realMoneyCost1 = value;
					this.IsDirty = true;	
					OnPropertyChanged("RealMoneyCost1");
				}
			}
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
			set 
			{
				if (this._realMoneyCost2 != value) 
				{
					this._realMoneyCost2 = value;
					this.IsDirty = true;	
					OnPropertyChanged("RealMoneyCost2");
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
		private string _addMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddMan
		{
			[DebuggerStepThrough()]
			get { return this._addMan; }
			set 
			{
				if (this._addMan != value) 
				{
					this._addMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddMan");
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
		private decimal _chargeBackMoney = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ChargeBackMoney
		{
			[DebuggerStepThrough()]
			get { return this._chargeBackMoney; }
			set 
			{
				if (this._chargeBackMoney != value) 
				{
					this._chargeBackMoney = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeBackMoney");
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
		[DataObjectField(false, false, true)]
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
			set 
			{
				if (this._chageType1 != value) 
				{
					this._chageType1 = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChageType1");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isCancel = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsCancel
		{
			[DebuggerStepThrough()]
			get { return this._isCancel; }
			set 
			{
				if (this._isCancel != value) 
				{
					this._isCancel = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsCancel");
				}
			}
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
			set 
			{
				if (this._fullName != value) 
				{
					this._fullName = value;
					this.IsDirty = true;	
					OnPropertyChanged("FullName");
				}
			}
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
			set 
			{
				if (this._chageType2 != value) 
				{
					this._chageType2 = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChageType2");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _cancelMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CancelMan
		{
			[DebuggerStepThrough()]
			get { return this._cancelMan; }
			set 
			{
				if (this._cancelMan != value) 
				{
					this._cancelMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("CancelMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _cancelTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime CancelTime
		{
			[DebuggerStepThrough()]
			get { return this._cancelTime; }
			set 
			{
				if (this._cancelTime != value) 
				{
					this._cancelTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("CancelTime");
				}
			}
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
			set 
			{
				if (this._printCount != value) 
				{
					this._printCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintCount");
				}
			}
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
			set 
			{
				if (this._lastPrintTime != value) 
				{
					this._lastPrintTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("LastPrintTime");
				}
			}
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
			set 
			{
				if (this._printRemark != value) 
				{
					this._printRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintRemark");
				}
			}
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
			set 
			{
				if (this._isRePrint != value) 
				{
					this._isRePrint = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsRePrint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _weiShuMore = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal WeiShuMore
		{
			[DebuggerStepThrough()]
			get { return this._weiShuMore; }
			set 
			{
				if (this._weiShuMore != value) 
				{
					this._weiShuMore = value;
					this.IsDirty = true;	
					OnPropertyChanged("WeiShuMore");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _weiShuConsume = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal WeiShuConsume
		{
			[DebuggerStepThrough()]
			get { return this._weiShuConsume; }
			set 
			{
				if (this._weiShuConsume != value) 
				{
					this._weiShuConsume = value;
					this.IsDirty = true;	
					OnPropertyChanged("WeiShuConsume");
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
			set 
			{
				if (this._roomFeeOrderID != value) 
				{
					this._roomFeeOrderID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomFeeOrderID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomFullName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomFullName
		{
			[DebuggerStepThrough()]
			get { return this._roomFullName; }
			set 
			{
				if (this._roomFullName != value) 
				{
					this._roomFullName = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomFullName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomOwnerName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomOwnerName
		{
			[DebuggerStepThrough()]
			get { return this._roomOwnerName; }
			set 
			{
				if (this._roomOwnerName != value) 
				{
					this._roomOwnerName = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomOwnerName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeForSummary = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeForSummary
		{
			[DebuggerStepThrough()]
			get { return this._chargeForSummary; }
			set 
			{
				if (this._chargeForSummary != value) 
				{
					this._chargeForSummary = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeForSummary");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeMethods = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeMethods
		{
			[DebuggerStepThrough()]
			get { return this._chargeMethods; }
			set 
			{
				if (this._chargeMethods != value) 
				{
					this._chargeMethods = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeMethods");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _weiShuBalance = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal WeiShuBalance
		{
			[DebuggerStepThrough()]
			get { return this._weiShuBalance; }
			set 
			{
				if (this._weiShuBalance != value) 
				{
					this._weiShuBalance = value;
					this.IsDirty = true;	
					OnPropertyChanged("WeiShuBalance");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _orderNumberType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OrderNumberType
		{
			[DebuggerStepThrough()]
			get { return this._orderNumberType; }
			set 
			{
				if (this._orderNumberType != value) 
				{
					this._orderNumberType = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderNumberType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _printTitle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PrintTitle
		{
			[DebuggerStepThrough()]
			get { return this._printTitle; }
			set 
			{
				if (this._printTitle != value) 
				{
					this._printTitle = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintTitle");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _printSubTitle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PrintSubTitle
		{
			[DebuggerStepThrough()]
			get { return this._printSubTitle; }
			set 
			{
				if (this._printSubTitle != value) 
				{
					this._printSubTitle = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintSubTitle");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isChequePrint = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsChequePrint
		{
			[DebuggerStepThrough()]
			get { return this._isChequePrint; }
			set 
			{
				if (this._isChequePrint != value) 
				{
					this._isChequePrint = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsChequePrint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chequeNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChequeNumber
		{
			[DebuggerStepThrough()]
			get { return this._chequeNumber; }
			set 
			{
				if (this._chequeNumber != value) 
				{
					this._chequeNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChequeNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chequePDFPath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChequePDFPath
		{
			[DebuggerStepThrough()]
			get { return this._chequePDFPath; }
			set 
			{
				if (this._chequePDFPath != value) 
				{
					this._chequePDFPath = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChequePDFPath");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chequeInvoiceStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChequeInvoiceStatus
		{
			[DebuggerStepThrough()]
			get { return this._chequeInvoiceStatus; }
			set 
			{
				if (this._chequeInvoiceStatus != value) 
				{
					this._chequeInvoiceStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChequeInvoiceStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chequeInvoiceNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChequeInvoiceNo
		{
			[DebuggerStepThrough()]
			get { return this._chequeInvoiceNo; }
			set 
			{
				if (this._chequeInvoiceNo != value) 
				{
					this._chequeInvoiceNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChequeInvoiceNo");
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
	[Cost] decimal(18, 2),
	[CostCapital] nvarchar(100),
	[RealCost] decimal(18, 2),
	[PreChargeMoney] decimal(18, 2),
	[DiscountMoney] decimal(18, 2),
	[RealMoneyCost1] decimal(18, 2),
	[RealMoneyCost2] decimal(18, 2),
	[Remark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime,
	[PrintNumber] nvarchar(100),
	[ChargeMan] nvarchar(50),
	[ChargeBackMoney] decimal(18, 2),
	[ChargeTime] datetime,
	[ChageType1] int,
	[IsCancel] bit,
	[FullName] nvarchar(500),
	[ChageType2] int,
	[CancelMan] nvarchar(50),
	[CancelTime] datetime,
	[PrintCount] int,
	[LastPrintTime] datetime,
	[PrintRemark] ntext,
	[IsRePrint] bit,
	[WeiShuMore] decimal(18, 2),
	[WeiShuConsume] decimal(18, 2),
	[OrderNumberID] int,
	[RoomFeeOrderID] int,
	[RoomFullName] nvarchar(500),
	[RoomOwnerName] nvarchar(50),
	[ChargeForSummary] nvarchar(100),
	[ChargeMethods] nvarchar(100),
	[WeiShuBalance] decimal(18, 2),
	[OrderNumberType] int,
	[PrintTitle] nvarchar(200),
	[PrintSubTitle] nvarchar(200),
	[IsChequePrint] bit,
	[ChequeNumber] nvarchar(200),
	[ChequePDFPath] nvarchar(500),
	[ChequeInvoiceStatus] int,
	[ChequeInvoiceNo] nvarchar(200)
);

INSERT INTO [dbo].[PrintRoomFeeHistory] (
	[PrintRoomFeeHistory].[Cost],
	[PrintRoomFeeHistory].[CostCapital],
	[PrintRoomFeeHistory].[RealCost],
	[PrintRoomFeeHistory].[PreChargeMoney],
	[PrintRoomFeeHistory].[DiscountMoney],
	[PrintRoomFeeHistory].[RealMoneyCost1],
	[PrintRoomFeeHistory].[RealMoneyCost2],
	[PrintRoomFeeHistory].[Remark],
	[PrintRoomFeeHistory].[AddMan],
	[PrintRoomFeeHistory].[AddTime],
	[PrintRoomFeeHistory].[PrintNumber],
	[PrintRoomFeeHistory].[ChargeMan],
	[PrintRoomFeeHistory].[ChargeBackMoney],
	[PrintRoomFeeHistory].[ChargeTime],
	[PrintRoomFeeHistory].[ChageType1],
	[PrintRoomFeeHistory].[IsCancel],
	[PrintRoomFeeHistory].[FullName],
	[PrintRoomFeeHistory].[ChageType2],
	[PrintRoomFeeHistory].[CancelMan],
	[PrintRoomFeeHistory].[CancelTime],
	[PrintRoomFeeHistory].[PrintCount],
	[PrintRoomFeeHistory].[LastPrintTime],
	[PrintRoomFeeHistory].[PrintRemark],
	[PrintRoomFeeHistory].[IsRePrint],
	[PrintRoomFeeHistory].[WeiShuMore],
	[PrintRoomFeeHistory].[WeiShuConsume],
	[PrintRoomFeeHistory].[OrderNumberID],
	[PrintRoomFeeHistory].[RoomFeeOrderID],
	[PrintRoomFeeHistory].[RoomFullName],
	[PrintRoomFeeHistory].[RoomOwnerName],
	[PrintRoomFeeHistory].[ChargeForSummary],
	[PrintRoomFeeHistory].[ChargeMethods],
	[PrintRoomFeeHistory].[WeiShuBalance],
	[PrintRoomFeeHistory].[OrderNumberType],
	[PrintRoomFeeHistory].[PrintTitle],
	[PrintRoomFeeHistory].[PrintSubTitle],
	[PrintRoomFeeHistory].[IsChequePrint],
	[PrintRoomFeeHistory].[ChequeNumber],
	[PrintRoomFeeHistory].[ChequePDFPath],
	[PrintRoomFeeHistory].[ChequeInvoiceStatus],
	[PrintRoomFeeHistory].[ChequeInvoiceNo]
) 
output 
	INSERTED.[ID],
	INSERTED.[Cost],
	INSERTED.[CostCapital],
	INSERTED.[RealCost],
	INSERTED.[PreChargeMoney],
	INSERTED.[DiscountMoney],
	INSERTED.[RealMoneyCost1],
	INSERTED.[RealMoneyCost2],
	INSERTED.[Remark],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[PrintNumber],
	INSERTED.[ChargeMan],
	INSERTED.[ChargeBackMoney],
	INSERTED.[ChargeTime],
	INSERTED.[ChageType1],
	INSERTED.[IsCancel],
	INSERTED.[FullName],
	INSERTED.[ChageType2],
	INSERTED.[CancelMan],
	INSERTED.[CancelTime],
	INSERTED.[PrintCount],
	INSERTED.[LastPrintTime],
	INSERTED.[PrintRemark],
	INSERTED.[IsRePrint],
	INSERTED.[WeiShuMore],
	INSERTED.[WeiShuConsume],
	INSERTED.[OrderNumberID],
	INSERTED.[RoomFeeOrderID],
	INSERTED.[RoomFullName],
	INSERTED.[RoomOwnerName],
	INSERTED.[ChargeForSummary],
	INSERTED.[ChargeMethods],
	INSERTED.[WeiShuBalance],
	INSERTED.[OrderNumberType],
	INSERTED.[PrintTitle],
	INSERTED.[PrintSubTitle],
	INSERTED.[IsChequePrint],
	INSERTED.[ChequeNumber],
	INSERTED.[ChequePDFPath],
	INSERTED.[ChequeInvoiceStatus],
	INSERTED.[ChequeInvoiceNo]
into @table
VALUES ( 
	@Cost,
	@CostCapital,
	@RealCost,
	@PreChargeMoney,
	@DiscountMoney,
	@RealMoneyCost1,
	@RealMoneyCost2,
	@Remark,
	@AddMan,
	@AddTime,
	@PrintNumber,
	@ChargeMan,
	@ChargeBackMoney,
	@ChargeTime,
	@ChageType1,
	@IsCancel,
	@FullName,
	@ChageType2,
	@CancelMan,
	@CancelTime,
	@PrintCount,
	@LastPrintTime,
	@PrintRemark,
	@IsRePrint,
	@WeiShuMore,
	@WeiShuConsume,
	@OrderNumberID,
	@RoomFeeOrderID,
	@RoomFullName,
	@RoomOwnerName,
	@ChargeForSummary,
	@ChargeMethods,
	@WeiShuBalance,
	@OrderNumberType,
	@PrintTitle,
	@PrintSubTitle,
	@IsChequePrint,
	@ChequeNumber,
	@ChequePDFPath,
	@ChequeInvoiceStatus,
	@ChequeInvoiceNo 
); 

SELECT 
	[ID],
	[Cost],
	[CostCapital],
	[RealCost],
	[PreChargeMoney],
	[DiscountMoney],
	[RealMoneyCost1],
	[RealMoneyCost2],
	[Remark],
	[AddMan],
	[AddTime],
	[PrintNumber],
	[ChargeMan],
	[ChargeBackMoney],
	[ChargeTime],
	[ChageType1],
	[IsCancel],
	[FullName],
	[ChageType2],
	[CancelMan],
	[CancelTime],
	[PrintCount],
	[LastPrintTime],
	[PrintRemark],
	[IsRePrint],
	[WeiShuMore],
	[WeiShuConsume],
	[OrderNumberID],
	[RoomFeeOrderID],
	[RoomFullName],
	[RoomOwnerName],
	[ChargeForSummary],
	[ChargeMethods],
	[WeiShuBalance],
	[OrderNumberType],
	[PrintTitle],
	[PrintSubTitle],
	[IsChequePrint],
	[ChequeNumber],
	[ChequePDFPath],
	[ChequeInvoiceStatus],
	[ChequeInvoiceNo] 
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
	[Cost] decimal(18, 2),
	[CostCapital] nvarchar(100),
	[RealCost] decimal(18, 2),
	[PreChargeMoney] decimal(18, 2),
	[DiscountMoney] decimal(18, 2),
	[RealMoneyCost1] decimal(18, 2),
	[RealMoneyCost2] decimal(18, 2),
	[Remark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime,
	[PrintNumber] nvarchar(100),
	[ChargeMan] nvarchar(50),
	[ChargeBackMoney] decimal(18, 2),
	[ChargeTime] datetime,
	[ChageType1] int,
	[IsCancel] bit,
	[FullName] nvarchar(500),
	[ChageType2] int,
	[CancelMan] nvarchar(50),
	[CancelTime] datetime,
	[PrintCount] int,
	[LastPrintTime] datetime,
	[PrintRemark] ntext,
	[IsRePrint] bit,
	[WeiShuMore] decimal(18, 2),
	[WeiShuConsume] decimal(18, 2),
	[OrderNumberID] int,
	[RoomFeeOrderID] int,
	[RoomFullName] nvarchar(500),
	[RoomOwnerName] nvarchar(50),
	[ChargeForSummary] nvarchar(100),
	[ChargeMethods] nvarchar(100),
	[WeiShuBalance] decimal(18, 2),
	[OrderNumberType] int,
	[PrintTitle] nvarchar(200),
	[PrintSubTitle] nvarchar(200),
	[IsChequePrint] bit,
	[ChequeNumber] nvarchar(200),
	[ChequePDFPath] nvarchar(500),
	[ChequeInvoiceStatus] int,
	[ChequeInvoiceNo] nvarchar(200)
);

UPDATE [dbo].[PrintRoomFeeHistory] SET 
	[PrintRoomFeeHistory].[Cost] = @Cost,
	[PrintRoomFeeHistory].[CostCapital] = @CostCapital,
	[PrintRoomFeeHistory].[RealCost] = @RealCost,
	[PrintRoomFeeHistory].[PreChargeMoney] = @PreChargeMoney,
	[PrintRoomFeeHistory].[DiscountMoney] = @DiscountMoney,
	[PrintRoomFeeHistory].[RealMoneyCost1] = @RealMoneyCost1,
	[PrintRoomFeeHistory].[RealMoneyCost2] = @RealMoneyCost2,
	[PrintRoomFeeHistory].[Remark] = @Remark,
	[PrintRoomFeeHistory].[AddMan] = @AddMan,
	[PrintRoomFeeHistory].[AddTime] = @AddTime,
	[PrintRoomFeeHistory].[PrintNumber] = @PrintNumber,
	[PrintRoomFeeHistory].[ChargeMan] = @ChargeMan,
	[PrintRoomFeeHistory].[ChargeBackMoney] = @ChargeBackMoney,
	[PrintRoomFeeHistory].[ChargeTime] = @ChargeTime,
	[PrintRoomFeeHistory].[ChageType1] = @ChageType1,
	[PrintRoomFeeHistory].[IsCancel] = @IsCancel,
	[PrintRoomFeeHistory].[FullName] = @FullName,
	[PrintRoomFeeHistory].[ChageType2] = @ChageType2,
	[PrintRoomFeeHistory].[CancelMan] = @CancelMan,
	[PrintRoomFeeHistory].[CancelTime] = @CancelTime,
	[PrintRoomFeeHistory].[PrintCount] = @PrintCount,
	[PrintRoomFeeHistory].[LastPrintTime] = @LastPrintTime,
	[PrintRoomFeeHistory].[PrintRemark] = @PrintRemark,
	[PrintRoomFeeHistory].[IsRePrint] = @IsRePrint,
	[PrintRoomFeeHistory].[WeiShuMore] = @WeiShuMore,
	[PrintRoomFeeHistory].[WeiShuConsume] = @WeiShuConsume,
	[PrintRoomFeeHistory].[OrderNumberID] = @OrderNumberID,
	[PrintRoomFeeHistory].[RoomFeeOrderID] = @RoomFeeOrderID,
	[PrintRoomFeeHistory].[RoomFullName] = @RoomFullName,
	[PrintRoomFeeHistory].[RoomOwnerName] = @RoomOwnerName,
	[PrintRoomFeeHistory].[ChargeForSummary] = @ChargeForSummary,
	[PrintRoomFeeHistory].[ChargeMethods] = @ChargeMethods,
	[PrintRoomFeeHistory].[WeiShuBalance] = @WeiShuBalance,
	[PrintRoomFeeHistory].[OrderNumberType] = @OrderNumberType,
	[PrintRoomFeeHistory].[PrintTitle] = @PrintTitle,
	[PrintRoomFeeHistory].[PrintSubTitle] = @PrintSubTitle,
	[PrintRoomFeeHistory].[IsChequePrint] = @IsChequePrint,
	[PrintRoomFeeHistory].[ChequeNumber] = @ChequeNumber,
	[PrintRoomFeeHistory].[ChequePDFPath] = @ChequePDFPath,
	[PrintRoomFeeHistory].[ChequeInvoiceStatus] = @ChequeInvoiceStatus,
	[PrintRoomFeeHistory].[ChequeInvoiceNo] = @ChequeInvoiceNo 
output 
	INSERTED.[ID],
	INSERTED.[Cost],
	INSERTED.[CostCapital],
	INSERTED.[RealCost],
	INSERTED.[PreChargeMoney],
	INSERTED.[DiscountMoney],
	INSERTED.[RealMoneyCost1],
	INSERTED.[RealMoneyCost2],
	INSERTED.[Remark],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[PrintNumber],
	INSERTED.[ChargeMan],
	INSERTED.[ChargeBackMoney],
	INSERTED.[ChargeTime],
	INSERTED.[ChageType1],
	INSERTED.[IsCancel],
	INSERTED.[FullName],
	INSERTED.[ChageType2],
	INSERTED.[CancelMan],
	INSERTED.[CancelTime],
	INSERTED.[PrintCount],
	INSERTED.[LastPrintTime],
	INSERTED.[PrintRemark],
	INSERTED.[IsRePrint],
	INSERTED.[WeiShuMore],
	INSERTED.[WeiShuConsume],
	INSERTED.[OrderNumberID],
	INSERTED.[RoomFeeOrderID],
	INSERTED.[RoomFullName],
	INSERTED.[RoomOwnerName],
	INSERTED.[ChargeForSummary],
	INSERTED.[ChargeMethods],
	INSERTED.[WeiShuBalance],
	INSERTED.[OrderNumberType],
	INSERTED.[PrintTitle],
	INSERTED.[PrintSubTitle],
	INSERTED.[IsChequePrint],
	INSERTED.[ChequeNumber],
	INSERTED.[ChequePDFPath],
	INSERTED.[ChequeInvoiceStatus],
	INSERTED.[ChequeInvoiceNo]
into @table
WHERE 
	[PrintRoomFeeHistory].[ID] = @ID

SELECT 
	[ID],
	[Cost],
	[CostCapital],
	[RealCost],
	[PreChargeMoney],
	[DiscountMoney],
	[RealMoneyCost1],
	[RealMoneyCost2],
	[Remark],
	[AddMan],
	[AddTime],
	[PrintNumber],
	[ChargeMan],
	[ChargeBackMoney],
	[ChargeTime],
	[ChageType1],
	[IsCancel],
	[FullName],
	[ChageType2],
	[CancelMan],
	[CancelTime],
	[PrintCount],
	[LastPrintTime],
	[PrintRemark],
	[IsRePrint],
	[WeiShuMore],
	[WeiShuConsume],
	[OrderNumberID],
	[RoomFeeOrderID],
	[RoomFullName],
	[RoomOwnerName],
	[ChargeForSummary],
	[ChargeMethods],
	[WeiShuBalance],
	[OrderNumberType],
	[PrintTitle],
	[PrintSubTitle],
	[IsChequePrint],
	[ChequeNumber],
	[ChequePDFPath],
	[ChequeInvoiceStatus],
	[ChequeInvoiceNo] 
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
DELETE FROM [dbo].[PrintRoomFeeHistory]
WHERE 
	[PrintRoomFeeHistory].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public PrintRoomFeeHistory() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetPrintRoomFeeHistory(this.ID));
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
	[PrintRoomFeeHistory].[ID],
	[PrintRoomFeeHistory].[Cost],
	[PrintRoomFeeHistory].[CostCapital],
	[PrintRoomFeeHistory].[RealCost],
	[PrintRoomFeeHistory].[PreChargeMoney],
	[PrintRoomFeeHistory].[DiscountMoney],
	[PrintRoomFeeHistory].[RealMoneyCost1],
	[PrintRoomFeeHistory].[RealMoneyCost2],
	[PrintRoomFeeHistory].[Remark],
	[PrintRoomFeeHistory].[AddMan],
	[PrintRoomFeeHistory].[AddTime],
	[PrintRoomFeeHistory].[PrintNumber],
	[PrintRoomFeeHistory].[ChargeMan],
	[PrintRoomFeeHistory].[ChargeBackMoney],
	[PrintRoomFeeHistory].[ChargeTime],
	[PrintRoomFeeHistory].[ChageType1],
	[PrintRoomFeeHistory].[IsCancel],
	[PrintRoomFeeHistory].[FullName],
	[PrintRoomFeeHistory].[ChageType2],
	[PrintRoomFeeHistory].[CancelMan],
	[PrintRoomFeeHistory].[CancelTime],
	[PrintRoomFeeHistory].[PrintCount],
	[PrintRoomFeeHistory].[LastPrintTime],
	[PrintRoomFeeHistory].[PrintRemark],
	[PrintRoomFeeHistory].[IsRePrint],
	[PrintRoomFeeHistory].[WeiShuMore],
	[PrintRoomFeeHistory].[WeiShuConsume],
	[PrintRoomFeeHistory].[OrderNumberID],
	[PrintRoomFeeHistory].[RoomFeeOrderID],
	[PrintRoomFeeHistory].[RoomFullName],
	[PrintRoomFeeHistory].[RoomOwnerName],
	[PrintRoomFeeHistory].[ChargeForSummary],
	[PrintRoomFeeHistory].[ChargeMethods],
	[PrintRoomFeeHistory].[WeiShuBalance],
	[PrintRoomFeeHistory].[OrderNumberType],
	[PrintRoomFeeHistory].[PrintTitle],
	[PrintRoomFeeHistory].[PrintSubTitle],
	[PrintRoomFeeHistory].[IsChequePrint],
	[PrintRoomFeeHistory].[ChequeNumber],
	[PrintRoomFeeHistory].[ChequePDFPath],
	[PrintRoomFeeHistory].[ChequeInvoiceStatus],
	[PrintRoomFeeHistory].[ChequeInvoiceNo]
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
                return "PrintRoomFeeHistory";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a PrintRoomFeeHistory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="cost">cost</param>
		/// <param name="costCapital">costCapital</param>
		/// <param name="realCost">realCost</param>
		/// <param name="preChargeMoney">preChargeMoney</param>
		/// <param name="discountMoney">discountMoney</param>
		/// <param name="realMoneyCost1">realMoneyCost1</param>
		/// <param name="realMoneyCost2">realMoneyCost2</param>
		/// <param name="remark">remark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="printNumber">printNumber</param>
		/// <param name="chargeMan">chargeMan</param>
		/// <param name="chargeBackMoney">chargeBackMoney</param>
		/// <param name="chargeTime">chargeTime</param>
		/// <param name="chageType1">chageType1</param>
		/// <param name="isCancel">isCancel</param>
		/// <param name="fullName">fullName</param>
		/// <param name="chageType2">chageType2</param>
		/// <param name="cancelMan">cancelMan</param>
		/// <param name="cancelTime">cancelTime</param>
		/// <param name="printCount">printCount</param>
		/// <param name="lastPrintTime">lastPrintTime</param>
		/// <param name="printRemark">printRemark</param>
		/// <param name="isRePrint">isRePrint</param>
		/// <param name="weiShuMore">weiShuMore</param>
		/// <param name="weiShuConsume">weiShuConsume</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="roomFeeOrderID">roomFeeOrderID</param>
		/// <param name="roomFullName">roomFullName</param>
		/// <param name="roomOwnerName">roomOwnerName</param>
		/// <param name="chargeForSummary">chargeForSummary</param>
		/// <param name="chargeMethods">chargeMethods</param>
		/// <param name="weiShuBalance">weiShuBalance</param>
		/// <param name="orderNumberType">orderNumberType</param>
		/// <param name="printTitle">printTitle</param>
		/// <param name="printSubTitle">printSubTitle</param>
		/// <param name="isChequePrint">isChequePrint</param>
		/// <param name="chequeNumber">chequeNumber</param>
		/// <param name="chequePDFPath">chequePDFPath</param>
		/// <param name="chequeInvoiceStatus">chequeInvoiceStatus</param>
		/// <param name="chequeInvoiceNo">chequeInvoiceNo</param>
		public static void InsertPrintRoomFeeHistory(decimal @cost, string @costCapital, decimal @realCost, decimal @preChargeMoney, decimal @discountMoney, decimal @realMoneyCost1, decimal @realMoneyCost2, string @remark, string @addMan, DateTime @addTime, string @printNumber, string @chargeMan, decimal @chargeBackMoney, DateTime @chargeTime, int @chageType1, bool @isCancel, string @fullName, int @chageType2, string @cancelMan, DateTime @cancelTime, int @printCount, DateTime @lastPrintTime, string @printRemark, bool @isRePrint, decimal @weiShuMore, decimal @weiShuConsume, int @orderNumberID, int @roomFeeOrderID, string @roomFullName, string @roomOwnerName, string @chargeForSummary, string @chargeMethods, decimal @weiShuBalance, int @orderNumberType, string @printTitle, string @printSubTitle, bool @isChequePrint, string @chequeNumber, string @chequePDFPath, int @chequeInvoiceStatus, string @chequeInvoiceNo)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertPrintRoomFeeHistory(@cost, @costCapital, @realCost, @preChargeMoney, @discountMoney, @realMoneyCost1, @realMoneyCost2, @remark, @addMan, @addTime, @printNumber, @chargeMan, @chargeBackMoney, @chargeTime, @chageType1, @isCancel, @fullName, @chageType2, @cancelMan, @cancelTime, @printCount, @lastPrintTime, @printRemark, @isRePrint, @weiShuMore, @weiShuConsume, @orderNumberID, @roomFeeOrderID, @roomFullName, @roomOwnerName, @chargeForSummary, @chargeMethods, @weiShuBalance, @orderNumberType, @printTitle, @printSubTitle, @isChequePrint, @chequeNumber, @chequePDFPath, @chequeInvoiceStatus, @chequeInvoiceNo, helper);
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
		/// Insert a PrintRoomFeeHistory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="cost">cost</param>
		/// <param name="costCapital">costCapital</param>
		/// <param name="realCost">realCost</param>
		/// <param name="preChargeMoney">preChargeMoney</param>
		/// <param name="discountMoney">discountMoney</param>
		/// <param name="realMoneyCost1">realMoneyCost1</param>
		/// <param name="realMoneyCost2">realMoneyCost2</param>
		/// <param name="remark">remark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="printNumber">printNumber</param>
		/// <param name="chargeMan">chargeMan</param>
		/// <param name="chargeBackMoney">chargeBackMoney</param>
		/// <param name="chargeTime">chargeTime</param>
		/// <param name="chageType1">chageType1</param>
		/// <param name="isCancel">isCancel</param>
		/// <param name="fullName">fullName</param>
		/// <param name="chageType2">chageType2</param>
		/// <param name="cancelMan">cancelMan</param>
		/// <param name="cancelTime">cancelTime</param>
		/// <param name="printCount">printCount</param>
		/// <param name="lastPrintTime">lastPrintTime</param>
		/// <param name="printRemark">printRemark</param>
		/// <param name="isRePrint">isRePrint</param>
		/// <param name="weiShuMore">weiShuMore</param>
		/// <param name="weiShuConsume">weiShuConsume</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="roomFeeOrderID">roomFeeOrderID</param>
		/// <param name="roomFullName">roomFullName</param>
		/// <param name="roomOwnerName">roomOwnerName</param>
		/// <param name="chargeForSummary">chargeForSummary</param>
		/// <param name="chargeMethods">chargeMethods</param>
		/// <param name="weiShuBalance">weiShuBalance</param>
		/// <param name="orderNumberType">orderNumberType</param>
		/// <param name="printTitle">printTitle</param>
		/// <param name="printSubTitle">printSubTitle</param>
		/// <param name="isChequePrint">isChequePrint</param>
		/// <param name="chequeNumber">chequeNumber</param>
		/// <param name="chequePDFPath">chequePDFPath</param>
		/// <param name="chequeInvoiceStatus">chequeInvoiceStatus</param>
		/// <param name="chequeInvoiceNo">chequeInvoiceNo</param>
		/// <param name="helper">helper</param>
		internal static void InsertPrintRoomFeeHistory(decimal @cost, string @costCapital, decimal @realCost, decimal @preChargeMoney, decimal @discountMoney, decimal @realMoneyCost1, decimal @realMoneyCost2, string @remark, string @addMan, DateTime @addTime, string @printNumber, string @chargeMan, decimal @chargeBackMoney, DateTime @chargeTime, int @chageType1, bool @isCancel, string @fullName, int @chageType2, string @cancelMan, DateTime @cancelTime, int @printCount, DateTime @lastPrintTime, string @printRemark, bool @isRePrint, decimal @weiShuMore, decimal @weiShuConsume, int @orderNumberID, int @roomFeeOrderID, string @roomFullName, string @roomOwnerName, string @chargeForSummary, string @chargeMethods, decimal @weiShuBalance, int @orderNumberType, string @printTitle, string @printSubTitle, bool @isChequePrint, string @chequeNumber, string @chequePDFPath, int @chequeInvoiceStatus, string @chequeInvoiceNo, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Cost] decimal(18, 2),
	[CostCapital] nvarchar(100),
	[RealCost] decimal(18, 2),
	[PreChargeMoney] decimal(18, 2),
	[DiscountMoney] decimal(18, 2),
	[RealMoneyCost1] decimal(18, 2),
	[RealMoneyCost2] decimal(18, 2),
	[Remark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime,
	[PrintNumber] nvarchar(100),
	[ChargeMan] nvarchar(50),
	[ChargeBackMoney] decimal(18, 2),
	[ChargeTime] datetime,
	[ChageType1] int,
	[IsCancel] bit,
	[FullName] nvarchar(500),
	[ChageType2] int,
	[CancelMan] nvarchar(50),
	[CancelTime] datetime,
	[PrintCount] int,
	[LastPrintTime] datetime,
	[PrintRemark] ntext,
	[IsRePrint] bit,
	[WeiShuMore] decimal(18, 2),
	[WeiShuConsume] decimal(18, 2),
	[OrderNumberID] int,
	[RoomFeeOrderID] int,
	[RoomFullName] nvarchar(500),
	[RoomOwnerName] nvarchar(50),
	[ChargeForSummary] nvarchar(100),
	[ChargeMethods] nvarchar(100),
	[WeiShuBalance] decimal(18, 2),
	[OrderNumberType] int,
	[PrintTitle] nvarchar(200),
	[PrintSubTitle] nvarchar(200),
	[IsChequePrint] bit,
	[ChequeNumber] nvarchar(200),
	[ChequePDFPath] nvarchar(500),
	[ChequeInvoiceStatus] int,
	[ChequeInvoiceNo] nvarchar(200)
);

INSERT INTO [dbo].[PrintRoomFeeHistory] (
	[PrintRoomFeeHistory].[Cost],
	[PrintRoomFeeHistory].[CostCapital],
	[PrintRoomFeeHistory].[RealCost],
	[PrintRoomFeeHistory].[PreChargeMoney],
	[PrintRoomFeeHistory].[DiscountMoney],
	[PrintRoomFeeHistory].[RealMoneyCost1],
	[PrintRoomFeeHistory].[RealMoneyCost2],
	[PrintRoomFeeHistory].[Remark],
	[PrintRoomFeeHistory].[AddMan],
	[PrintRoomFeeHistory].[AddTime],
	[PrintRoomFeeHistory].[PrintNumber],
	[PrintRoomFeeHistory].[ChargeMan],
	[PrintRoomFeeHistory].[ChargeBackMoney],
	[PrintRoomFeeHistory].[ChargeTime],
	[PrintRoomFeeHistory].[ChageType1],
	[PrintRoomFeeHistory].[IsCancel],
	[PrintRoomFeeHistory].[FullName],
	[PrintRoomFeeHistory].[ChageType2],
	[PrintRoomFeeHistory].[CancelMan],
	[PrintRoomFeeHistory].[CancelTime],
	[PrintRoomFeeHistory].[PrintCount],
	[PrintRoomFeeHistory].[LastPrintTime],
	[PrintRoomFeeHistory].[PrintRemark],
	[PrintRoomFeeHistory].[IsRePrint],
	[PrintRoomFeeHistory].[WeiShuMore],
	[PrintRoomFeeHistory].[WeiShuConsume],
	[PrintRoomFeeHistory].[OrderNumberID],
	[PrintRoomFeeHistory].[RoomFeeOrderID],
	[PrintRoomFeeHistory].[RoomFullName],
	[PrintRoomFeeHistory].[RoomOwnerName],
	[PrintRoomFeeHistory].[ChargeForSummary],
	[PrintRoomFeeHistory].[ChargeMethods],
	[PrintRoomFeeHistory].[WeiShuBalance],
	[PrintRoomFeeHistory].[OrderNumberType],
	[PrintRoomFeeHistory].[PrintTitle],
	[PrintRoomFeeHistory].[PrintSubTitle],
	[PrintRoomFeeHistory].[IsChequePrint],
	[PrintRoomFeeHistory].[ChequeNumber],
	[PrintRoomFeeHistory].[ChequePDFPath],
	[PrintRoomFeeHistory].[ChequeInvoiceStatus],
	[PrintRoomFeeHistory].[ChequeInvoiceNo]
) 
output 
	INSERTED.[ID],
	INSERTED.[Cost],
	INSERTED.[CostCapital],
	INSERTED.[RealCost],
	INSERTED.[PreChargeMoney],
	INSERTED.[DiscountMoney],
	INSERTED.[RealMoneyCost1],
	INSERTED.[RealMoneyCost2],
	INSERTED.[Remark],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[PrintNumber],
	INSERTED.[ChargeMan],
	INSERTED.[ChargeBackMoney],
	INSERTED.[ChargeTime],
	INSERTED.[ChageType1],
	INSERTED.[IsCancel],
	INSERTED.[FullName],
	INSERTED.[ChageType2],
	INSERTED.[CancelMan],
	INSERTED.[CancelTime],
	INSERTED.[PrintCount],
	INSERTED.[LastPrintTime],
	INSERTED.[PrintRemark],
	INSERTED.[IsRePrint],
	INSERTED.[WeiShuMore],
	INSERTED.[WeiShuConsume],
	INSERTED.[OrderNumberID],
	INSERTED.[RoomFeeOrderID],
	INSERTED.[RoomFullName],
	INSERTED.[RoomOwnerName],
	INSERTED.[ChargeForSummary],
	INSERTED.[ChargeMethods],
	INSERTED.[WeiShuBalance],
	INSERTED.[OrderNumberType],
	INSERTED.[PrintTitle],
	INSERTED.[PrintSubTitle],
	INSERTED.[IsChequePrint],
	INSERTED.[ChequeNumber],
	INSERTED.[ChequePDFPath],
	INSERTED.[ChequeInvoiceStatus],
	INSERTED.[ChequeInvoiceNo]
into @table
VALUES ( 
	@Cost,
	@CostCapital,
	@RealCost,
	@PreChargeMoney,
	@DiscountMoney,
	@RealMoneyCost1,
	@RealMoneyCost2,
	@Remark,
	@AddMan,
	@AddTime,
	@PrintNumber,
	@ChargeMan,
	@ChargeBackMoney,
	@ChargeTime,
	@ChageType1,
	@IsCancel,
	@FullName,
	@ChageType2,
	@CancelMan,
	@CancelTime,
	@PrintCount,
	@LastPrintTime,
	@PrintRemark,
	@IsRePrint,
	@WeiShuMore,
	@WeiShuConsume,
	@OrderNumberID,
	@RoomFeeOrderID,
	@RoomFullName,
	@RoomOwnerName,
	@ChargeForSummary,
	@ChargeMethods,
	@WeiShuBalance,
	@OrderNumberType,
	@PrintTitle,
	@PrintSubTitle,
	@IsChequePrint,
	@ChequeNumber,
	@ChequePDFPath,
	@ChequeInvoiceStatus,
	@ChequeInvoiceNo 
); 

SELECT 
	[ID],
	[Cost],
	[CostCapital],
	[RealCost],
	[PreChargeMoney],
	[DiscountMoney],
	[RealMoneyCost1],
	[RealMoneyCost2],
	[Remark],
	[AddMan],
	[AddTime],
	[PrintNumber],
	[ChargeMan],
	[ChargeBackMoney],
	[ChargeTime],
	[ChageType1],
	[IsCancel],
	[FullName],
	[ChageType2],
	[CancelMan],
	[CancelTime],
	[PrintCount],
	[LastPrintTime],
	[PrintRemark],
	[IsRePrint],
	[WeiShuMore],
	[WeiShuConsume],
	[OrderNumberID],
	[RoomFeeOrderID],
	[RoomFullName],
	[RoomOwnerName],
	[ChargeForSummary],
	[ChargeMethods],
	[WeiShuBalance],
	[OrderNumberType],
	[PrintTitle],
	[PrintSubTitle],
	[IsChequePrint],
	[ChequeNumber],
	[ChequePDFPath],
	[ChequeInvoiceStatus],
	[ChequeInvoiceNo] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Cost", EntityBase.GetDatabaseValue(@cost)));
			parameters.Add(new SqlParameter("@CostCapital", EntityBase.GetDatabaseValue(@costCapital)));
			parameters.Add(new SqlParameter("@RealCost", EntityBase.GetDatabaseValue(@realCost)));
			parameters.Add(new SqlParameter("@PreChargeMoney", EntityBase.GetDatabaseValue(@preChargeMoney)));
			parameters.Add(new SqlParameter("@DiscountMoney", EntityBase.GetDatabaseValue(@discountMoney)));
			parameters.Add(new SqlParameter("@RealMoneyCost1", EntityBase.GetDatabaseValue(@realMoneyCost1)));
			parameters.Add(new SqlParameter("@RealMoneyCost2", EntityBase.GetDatabaseValue(@realMoneyCost2)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@PrintNumber", EntityBase.GetDatabaseValue(@printNumber)));
			parameters.Add(new SqlParameter("@ChargeMan", EntityBase.GetDatabaseValue(@chargeMan)));
			parameters.Add(new SqlParameter("@ChargeBackMoney", EntityBase.GetDatabaseValue(@chargeBackMoney)));
			parameters.Add(new SqlParameter("@ChargeTime", EntityBase.GetDatabaseValue(@chargeTime)));
			parameters.Add(new SqlParameter("@ChageType1", EntityBase.GetDatabaseValue(@chageType1)));
			parameters.Add(new SqlParameter("@IsCancel", @isCancel));
			parameters.Add(new SqlParameter("@FullName", EntityBase.GetDatabaseValue(@fullName)));
			parameters.Add(new SqlParameter("@ChageType2", EntityBase.GetDatabaseValue(@chageType2)));
			parameters.Add(new SqlParameter("@CancelMan", EntityBase.GetDatabaseValue(@cancelMan)));
			parameters.Add(new SqlParameter("@CancelTime", EntityBase.GetDatabaseValue(@cancelTime)));
			parameters.Add(new SqlParameter("@PrintCount", EntityBase.GetDatabaseValue(@printCount)));
			parameters.Add(new SqlParameter("@LastPrintTime", EntityBase.GetDatabaseValue(@lastPrintTime)));
			parameters.Add(new SqlParameter("@PrintRemark", EntityBase.GetDatabaseValue(@printRemark)));
			parameters.Add(new SqlParameter("@IsRePrint", @isRePrint));
			parameters.Add(new SqlParameter("@WeiShuMore", EntityBase.GetDatabaseValue(@weiShuMore)));
			parameters.Add(new SqlParameter("@WeiShuConsume", EntityBase.GetDatabaseValue(@weiShuConsume)));
			parameters.Add(new SqlParameter("@OrderNumberID", EntityBase.GetDatabaseValue(@orderNumberID)));
			parameters.Add(new SqlParameter("@RoomFeeOrderID", EntityBase.GetDatabaseValue(@roomFeeOrderID)));
			parameters.Add(new SqlParameter("@RoomFullName", EntityBase.GetDatabaseValue(@roomFullName)));
			parameters.Add(new SqlParameter("@RoomOwnerName", EntityBase.GetDatabaseValue(@roomOwnerName)));
			parameters.Add(new SqlParameter("@ChargeForSummary", EntityBase.GetDatabaseValue(@chargeForSummary)));
			parameters.Add(new SqlParameter("@ChargeMethods", EntityBase.GetDatabaseValue(@chargeMethods)));
			parameters.Add(new SqlParameter("@WeiShuBalance", EntityBase.GetDatabaseValue(@weiShuBalance)));
			parameters.Add(new SqlParameter("@OrderNumberType", EntityBase.GetDatabaseValue(@orderNumberType)));
			parameters.Add(new SqlParameter("@PrintTitle", EntityBase.GetDatabaseValue(@printTitle)));
			parameters.Add(new SqlParameter("@PrintSubTitle", EntityBase.GetDatabaseValue(@printSubTitle)));
			parameters.Add(new SqlParameter("@IsChequePrint", @isChequePrint));
			parameters.Add(new SqlParameter("@ChequeNumber", EntityBase.GetDatabaseValue(@chequeNumber)));
			parameters.Add(new SqlParameter("@ChequePDFPath", EntityBase.GetDatabaseValue(@chequePDFPath)));
			parameters.Add(new SqlParameter("@ChequeInvoiceStatus", EntityBase.GetDatabaseValue(@chequeInvoiceStatus)));
			parameters.Add(new SqlParameter("@ChequeInvoiceNo", EntityBase.GetDatabaseValue(@chequeInvoiceNo)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a PrintRoomFeeHistory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="cost">cost</param>
		/// <param name="costCapital">costCapital</param>
		/// <param name="realCost">realCost</param>
		/// <param name="preChargeMoney">preChargeMoney</param>
		/// <param name="discountMoney">discountMoney</param>
		/// <param name="realMoneyCost1">realMoneyCost1</param>
		/// <param name="realMoneyCost2">realMoneyCost2</param>
		/// <param name="remark">remark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="printNumber">printNumber</param>
		/// <param name="chargeMan">chargeMan</param>
		/// <param name="chargeBackMoney">chargeBackMoney</param>
		/// <param name="chargeTime">chargeTime</param>
		/// <param name="chageType1">chageType1</param>
		/// <param name="isCancel">isCancel</param>
		/// <param name="fullName">fullName</param>
		/// <param name="chageType2">chageType2</param>
		/// <param name="cancelMan">cancelMan</param>
		/// <param name="cancelTime">cancelTime</param>
		/// <param name="printCount">printCount</param>
		/// <param name="lastPrintTime">lastPrintTime</param>
		/// <param name="printRemark">printRemark</param>
		/// <param name="isRePrint">isRePrint</param>
		/// <param name="weiShuMore">weiShuMore</param>
		/// <param name="weiShuConsume">weiShuConsume</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="roomFeeOrderID">roomFeeOrderID</param>
		/// <param name="roomFullName">roomFullName</param>
		/// <param name="roomOwnerName">roomOwnerName</param>
		/// <param name="chargeForSummary">chargeForSummary</param>
		/// <param name="chargeMethods">chargeMethods</param>
		/// <param name="weiShuBalance">weiShuBalance</param>
		/// <param name="orderNumberType">orderNumberType</param>
		/// <param name="printTitle">printTitle</param>
		/// <param name="printSubTitle">printSubTitle</param>
		/// <param name="isChequePrint">isChequePrint</param>
		/// <param name="chequeNumber">chequeNumber</param>
		/// <param name="chequePDFPath">chequePDFPath</param>
		/// <param name="chequeInvoiceStatus">chequeInvoiceStatus</param>
		/// <param name="chequeInvoiceNo">chequeInvoiceNo</param>
		public static void UpdatePrintRoomFeeHistory(int @iD, decimal @cost, string @costCapital, decimal @realCost, decimal @preChargeMoney, decimal @discountMoney, decimal @realMoneyCost1, decimal @realMoneyCost2, string @remark, string @addMan, DateTime @addTime, string @printNumber, string @chargeMan, decimal @chargeBackMoney, DateTime @chargeTime, int @chageType1, bool @isCancel, string @fullName, int @chageType2, string @cancelMan, DateTime @cancelTime, int @printCount, DateTime @lastPrintTime, string @printRemark, bool @isRePrint, decimal @weiShuMore, decimal @weiShuConsume, int @orderNumberID, int @roomFeeOrderID, string @roomFullName, string @roomOwnerName, string @chargeForSummary, string @chargeMethods, decimal @weiShuBalance, int @orderNumberType, string @printTitle, string @printSubTitle, bool @isChequePrint, string @chequeNumber, string @chequePDFPath, int @chequeInvoiceStatus, string @chequeInvoiceNo)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdatePrintRoomFeeHistory(@iD, @cost, @costCapital, @realCost, @preChargeMoney, @discountMoney, @realMoneyCost1, @realMoneyCost2, @remark, @addMan, @addTime, @printNumber, @chargeMan, @chargeBackMoney, @chargeTime, @chageType1, @isCancel, @fullName, @chageType2, @cancelMan, @cancelTime, @printCount, @lastPrintTime, @printRemark, @isRePrint, @weiShuMore, @weiShuConsume, @orderNumberID, @roomFeeOrderID, @roomFullName, @roomOwnerName, @chargeForSummary, @chargeMethods, @weiShuBalance, @orderNumberType, @printTitle, @printSubTitle, @isChequePrint, @chequeNumber, @chequePDFPath, @chequeInvoiceStatus, @chequeInvoiceNo, helper);
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
		/// Updates a PrintRoomFeeHistory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="cost">cost</param>
		/// <param name="costCapital">costCapital</param>
		/// <param name="realCost">realCost</param>
		/// <param name="preChargeMoney">preChargeMoney</param>
		/// <param name="discountMoney">discountMoney</param>
		/// <param name="realMoneyCost1">realMoneyCost1</param>
		/// <param name="realMoneyCost2">realMoneyCost2</param>
		/// <param name="remark">remark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="printNumber">printNumber</param>
		/// <param name="chargeMan">chargeMan</param>
		/// <param name="chargeBackMoney">chargeBackMoney</param>
		/// <param name="chargeTime">chargeTime</param>
		/// <param name="chageType1">chageType1</param>
		/// <param name="isCancel">isCancel</param>
		/// <param name="fullName">fullName</param>
		/// <param name="chageType2">chageType2</param>
		/// <param name="cancelMan">cancelMan</param>
		/// <param name="cancelTime">cancelTime</param>
		/// <param name="printCount">printCount</param>
		/// <param name="lastPrintTime">lastPrintTime</param>
		/// <param name="printRemark">printRemark</param>
		/// <param name="isRePrint">isRePrint</param>
		/// <param name="weiShuMore">weiShuMore</param>
		/// <param name="weiShuConsume">weiShuConsume</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="roomFeeOrderID">roomFeeOrderID</param>
		/// <param name="roomFullName">roomFullName</param>
		/// <param name="roomOwnerName">roomOwnerName</param>
		/// <param name="chargeForSummary">chargeForSummary</param>
		/// <param name="chargeMethods">chargeMethods</param>
		/// <param name="weiShuBalance">weiShuBalance</param>
		/// <param name="orderNumberType">orderNumberType</param>
		/// <param name="printTitle">printTitle</param>
		/// <param name="printSubTitle">printSubTitle</param>
		/// <param name="isChequePrint">isChequePrint</param>
		/// <param name="chequeNumber">chequeNumber</param>
		/// <param name="chequePDFPath">chequePDFPath</param>
		/// <param name="chequeInvoiceStatus">chequeInvoiceStatus</param>
		/// <param name="chequeInvoiceNo">chequeInvoiceNo</param>
		/// <param name="helper">helper</param>
		internal static void UpdatePrintRoomFeeHistory(int @iD, decimal @cost, string @costCapital, decimal @realCost, decimal @preChargeMoney, decimal @discountMoney, decimal @realMoneyCost1, decimal @realMoneyCost2, string @remark, string @addMan, DateTime @addTime, string @printNumber, string @chargeMan, decimal @chargeBackMoney, DateTime @chargeTime, int @chageType1, bool @isCancel, string @fullName, int @chageType2, string @cancelMan, DateTime @cancelTime, int @printCount, DateTime @lastPrintTime, string @printRemark, bool @isRePrint, decimal @weiShuMore, decimal @weiShuConsume, int @orderNumberID, int @roomFeeOrderID, string @roomFullName, string @roomOwnerName, string @chargeForSummary, string @chargeMethods, decimal @weiShuBalance, int @orderNumberType, string @printTitle, string @printSubTitle, bool @isChequePrint, string @chequeNumber, string @chequePDFPath, int @chequeInvoiceStatus, string @chequeInvoiceNo, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Cost] decimal(18, 2),
	[CostCapital] nvarchar(100),
	[RealCost] decimal(18, 2),
	[PreChargeMoney] decimal(18, 2),
	[DiscountMoney] decimal(18, 2),
	[RealMoneyCost1] decimal(18, 2),
	[RealMoneyCost2] decimal(18, 2),
	[Remark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime,
	[PrintNumber] nvarchar(100),
	[ChargeMan] nvarchar(50),
	[ChargeBackMoney] decimal(18, 2),
	[ChargeTime] datetime,
	[ChageType1] int,
	[IsCancel] bit,
	[FullName] nvarchar(500),
	[ChageType2] int,
	[CancelMan] nvarchar(50),
	[CancelTime] datetime,
	[PrintCount] int,
	[LastPrintTime] datetime,
	[PrintRemark] ntext,
	[IsRePrint] bit,
	[WeiShuMore] decimal(18, 2),
	[WeiShuConsume] decimal(18, 2),
	[OrderNumberID] int,
	[RoomFeeOrderID] int,
	[RoomFullName] nvarchar(500),
	[RoomOwnerName] nvarchar(50),
	[ChargeForSummary] nvarchar(100),
	[ChargeMethods] nvarchar(100),
	[WeiShuBalance] decimal(18, 2),
	[OrderNumberType] int,
	[PrintTitle] nvarchar(200),
	[PrintSubTitle] nvarchar(200),
	[IsChequePrint] bit,
	[ChequeNumber] nvarchar(200),
	[ChequePDFPath] nvarchar(500),
	[ChequeInvoiceStatus] int,
	[ChequeInvoiceNo] nvarchar(200)
);

UPDATE [dbo].[PrintRoomFeeHistory] SET 
	[PrintRoomFeeHistory].[Cost] = @Cost,
	[PrintRoomFeeHistory].[CostCapital] = @CostCapital,
	[PrintRoomFeeHistory].[RealCost] = @RealCost,
	[PrintRoomFeeHistory].[PreChargeMoney] = @PreChargeMoney,
	[PrintRoomFeeHistory].[DiscountMoney] = @DiscountMoney,
	[PrintRoomFeeHistory].[RealMoneyCost1] = @RealMoneyCost1,
	[PrintRoomFeeHistory].[RealMoneyCost2] = @RealMoneyCost2,
	[PrintRoomFeeHistory].[Remark] = @Remark,
	[PrintRoomFeeHistory].[AddMan] = @AddMan,
	[PrintRoomFeeHistory].[AddTime] = @AddTime,
	[PrintRoomFeeHistory].[PrintNumber] = @PrintNumber,
	[PrintRoomFeeHistory].[ChargeMan] = @ChargeMan,
	[PrintRoomFeeHistory].[ChargeBackMoney] = @ChargeBackMoney,
	[PrintRoomFeeHistory].[ChargeTime] = @ChargeTime,
	[PrintRoomFeeHistory].[ChageType1] = @ChageType1,
	[PrintRoomFeeHistory].[IsCancel] = @IsCancel,
	[PrintRoomFeeHistory].[FullName] = @FullName,
	[PrintRoomFeeHistory].[ChageType2] = @ChageType2,
	[PrintRoomFeeHistory].[CancelMan] = @CancelMan,
	[PrintRoomFeeHistory].[CancelTime] = @CancelTime,
	[PrintRoomFeeHistory].[PrintCount] = @PrintCount,
	[PrintRoomFeeHistory].[LastPrintTime] = @LastPrintTime,
	[PrintRoomFeeHistory].[PrintRemark] = @PrintRemark,
	[PrintRoomFeeHistory].[IsRePrint] = @IsRePrint,
	[PrintRoomFeeHistory].[WeiShuMore] = @WeiShuMore,
	[PrintRoomFeeHistory].[WeiShuConsume] = @WeiShuConsume,
	[PrintRoomFeeHistory].[OrderNumberID] = @OrderNumberID,
	[PrintRoomFeeHistory].[RoomFeeOrderID] = @RoomFeeOrderID,
	[PrintRoomFeeHistory].[RoomFullName] = @RoomFullName,
	[PrintRoomFeeHistory].[RoomOwnerName] = @RoomOwnerName,
	[PrintRoomFeeHistory].[ChargeForSummary] = @ChargeForSummary,
	[PrintRoomFeeHistory].[ChargeMethods] = @ChargeMethods,
	[PrintRoomFeeHistory].[WeiShuBalance] = @WeiShuBalance,
	[PrintRoomFeeHistory].[OrderNumberType] = @OrderNumberType,
	[PrintRoomFeeHistory].[PrintTitle] = @PrintTitle,
	[PrintRoomFeeHistory].[PrintSubTitle] = @PrintSubTitle,
	[PrintRoomFeeHistory].[IsChequePrint] = @IsChequePrint,
	[PrintRoomFeeHistory].[ChequeNumber] = @ChequeNumber,
	[PrintRoomFeeHistory].[ChequePDFPath] = @ChequePDFPath,
	[PrintRoomFeeHistory].[ChequeInvoiceStatus] = @ChequeInvoiceStatus,
	[PrintRoomFeeHistory].[ChequeInvoiceNo] = @ChequeInvoiceNo 
output 
	INSERTED.[ID],
	INSERTED.[Cost],
	INSERTED.[CostCapital],
	INSERTED.[RealCost],
	INSERTED.[PreChargeMoney],
	INSERTED.[DiscountMoney],
	INSERTED.[RealMoneyCost1],
	INSERTED.[RealMoneyCost2],
	INSERTED.[Remark],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[PrintNumber],
	INSERTED.[ChargeMan],
	INSERTED.[ChargeBackMoney],
	INSERTED.[ChargeTime],
	INSERTED.[ChageType1],
	INSERTED.[IsCancel],
	INSERTED.[FullName],
	INSERTED.[ChageType2],
	INSERTED.[CancelMan],
	INSERTED.[CancelTime],
	INSERTED.[PrintCount],
	INSERTED.[LastPrintTime],
	INSERTED.[PrintRemark],
	INSERTED.[IsRePrint],
	INSERTED.[WeiShuMore],
	INSERTED.[WeiShuConsume],
	INSERTED.[OrderNumberID],
	INSERTED.[RoomFeeOrderID],
	INSERTED.[RoomFullName],
	INSERTED.[RoomOwnerName],
	INSERTED.[ChargeForSummary],
	INSERTED.[ChargeMethods],
	INSERTED.[WeiShuBalance],
	INSERTED.[OrderNumberType],
	INSERTED.[PrintTitle],
	INSERTED.[PrintSubTitle],
	INSERTED.[IsChequePrint],
	INSERTED.[ChequeNumber],
	INSERTED.[ChequePDFPath],
	INSERTED.[ChequeInvoiceStatus],
	INSERTED.[ChequeInvoiceNo]
into @table
WHERE 
	[PrintRoomFeeHistory].[ID] = @ID

SELECT 
	[ID],
	[Cost],
	[CostCapital],
	[RealCost],
	[PreChargeMoney],
	[DiscountMoney],
	[RealMoneyCost1],
	[RealMoneyCost2],
	[Remark],
	[AddMan],
	[AddTime],
	[PrintNumber],
	[ChargeMan],
	[ChargeBackMoney],
	[ChargeTime],
	[ChageType1],
	[IsCancel],
	[FullName],
	[ChageType2],
	[CancelMan],
	[CancelTime],
	[PrintCount],
	[LastPrintTime],
	[PrintRemark],
	[IsRePrint],
	[WeiShuMore],
	[WeiShuConsume],
	[OrderNumberID],
	[RoomFeeOrderID],
	[RoomFullName],
	[RoomOwnerName],
	[ChargeForSummary],
	[ChargeMethods],
	[WeiShuBalance],
	[OrderNumberType],
	[PrintTitle],
	[PrintSubTitle],
	[IsChequePrint],
	[ChequeNumber],
	[ChequePDFPath],
	[ChequeInvoiceStatus],
	[ChequeInvoiceNo] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Cost", EntityBase.GetDatabaseValue(@cost)));
			parameters.Add(new SqlParameter("@CostCapital", EntityBase.GetDatabaseValue(@costCapital)));
			parameters.Add(new SqlParameter("@RealCost", EntityBase.GetDatabaseValue(@realCost)));
			parameters.Add(new SqlParameter("@PreChargeMoney", EntityBase.GetDatabaseValue(@preChargeMoney)));
			parameters.Add(new SqlParameter("@DiscountMoney", EntityBase.GetDatabaseValue(@discountMoney)));
			parameters.Add(new SqlParameter("@RealMoneyCost1", EntityBase.GetDatabaseValue(@realMoneyCost1)));
			parameters.Add(new SqlParameter("@RealMoneyCost2", EntityBase.GetDatabaseValue(@realMoneyCost2)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@PrintNumber", EntityBase.GetDatabaseValue(@printNumber)));
			parameters.Add(new SqlParameter("@ChargeMan", EntityBase.GetDatabaseValue(@chargeMan)));
			parameters.Add(new SqlParameter("@ChargeBackMoney", EntityBase.GetDatabaseValue(@chargeBackMoney)));
			parameters.Add(new SqlParameter("@ChargeTime", EntityBase.GetDatabaseValue(@chargeTime)));
			parameters.Add(new SqlParameter("@ChageType1", EntityBase.GetDatabaseValue(@chageType1)));
			parameters.Add(new SqlParameter("@IsCancel", @isCancel));
			parameters.Add(new SqlParameter("@FullName", EntityBase.GetDatabaseValue(@fullName)));
			parameters.Add(new SqlParameter("@ChageType2", EntityBase.GetDatabaseValue(@chageType2)));
			parameters.Add(new SqlParameter("@CancelMan", EntityBase.GetDatabaseValue(@cancelMan)));
			parameters.Add(new SqlParameter("@CancelTime", EntityBase.GetDatabaseValue(@cancelTime)));
			parameters.Add(new SqlParameter("@PrintCount", EntityBase.GetDatabaseValue(@printCount)));
			parameters.Add(new SqlParameter("@LastPrintTime", EntityBase.GetDatabaseValue(@lastPrintTime)));
			parameters.Add(new SqlParameter("@PrintRemark", EntityBase.GetDatabaseValue(@printRemark)));
			parameters.Add(new SqlParameter("@IsRePrint", @isRePrint));
			parameters.Add(new SqlParameter("@WeiShuMore", EntityBase.GetDatabaseValue(@weiShuMore)));
			parameters.Add(new SqlParameter("@WeiShuConsume", EntityBase.GetDatabaseValue(@weiShuConsume)));
			parameters.Add(new SqlParameter("@OrderNumberID", EntityBase.GetDatabaseValue(@orderNumberID)));
			parameters.Add(new SqlParameter("@RoomFeeOrderID", EntityBase.GetDatabaseValue(@roomFeeOrderID)));
			parameters.Add(new SqlParameter("@RoomFullName", EntityBase.GetDatabaseValue(@roomFullName)));
			parameters.Add(new SqlParameter("@RoomOwnerName", EntityBase.GetDatabaseValue(@roomOwnerName)));
			parameters.Add(new SqlParameter("@ChargeForSummary", EntityBase.GetDatabaseValue(@chargeForSummary)));
			parameters.Add(new SqlParameter("@ChargeMethods", EntityBase.GetDatabaseValue(@chargeMethods)));
			parameters.Add(new SqlParameter("@WeiShuBalance", EntityBase.GetDatabaseValue(@weiShuBalance)));
			parameters.Add(new SqlParameter("@OrderNumberType", EntityBase.GetDatabaseValue(@orderNumberType)));
			parameters.Add(new SqlParameter("@PrintTitle", EntityBase.GetDatabaseValue(@printTitle)));
			parameters.Add(new SqlParameter("@PrintSubTitle", EntityBase.GetDatabaseValue(@printSubTitle)));
			parameters.Add(new SqlParameter("@IsChequePrint", @isChequePrint));
			parameters.Add(new SqlParameter("@ChequeNumber", EntityBase.GetDatabaseValue(@chequeNumber)));
			parameters.Add(new SqlParameter("@ChequePDFPath", EntityBase.GetDatabaseValue(@chequePDFPath)));
			parameters.Add(new SqlParameter("@ChequeInvoiceStatus", EntityBase.GetDatabaseValue(@chequeInvoiceStatus)));
			parameters.Add(new SqlParameter("@ChequeInvoiceNo", EntityBase.GetDatabaseValue(@chequeInvoiceNo)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a PrintRoomFeeHistory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeletePrintRoomFeeHistory(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeletePrintRoomFeeHistory(@iD, helper);
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
		/// Deletes a PrintRoomFeeHistory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeletePrintRoomFeeHistory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[PrintRoomFeeHistory]
WHERE 
	[PrintRoomFeeHistory].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new PrintRoomFeeHistory object.
		/// </summary>
		/// <returns>The newly created PrintRoomFeeHistory object.</returns>
		public static PrintRoomFeeHistory CreatePrintRoomFeeHistory()
		{
			return InitializeNew<PrintRoomFeeHistory>();
		}
		
		/// <summary>
		/// Retrieve information for a PrintRoomFeeHistory by a PrintRoomFeeHistory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>PrintRoomFeeHistory</returns>
		public static PrintRoomFeeHistory GetPrintRoomFeeHistory(int @iD)
		{
			string commandText = @"
SELECT 
" + PrintRoomFeeHistory.SelectFieldList + @"
FROM [dbo].[PrintRoomFeeHistory] 
WHERE 
	[PrintRoomFeeHistory].[ID] = @ID " + PrintRoomFeeHistory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<PrintRoomFeeHistory>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a PrintRoomFeeHistory by a PrintRoomFeeHistory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>PrintRoomFeeHistory</returns>
		public static PrintRoomFeeHistory GetPrintRoomFeeHistory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + PrintRoomFeeHistory.SelectFieldList + @"
FROM [dbo].[PrintRoomFeeHistory] 
WHERE 
	[PrintRoomFeeHistory].[ID] = @ID " + PrintRoomFeeHistory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<PrintRoomFeeHistory>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection PrintRoomFeeHistory objects.
		/// </summary>
		/// <returns>The retrieved collection of PrintRoomFeeHistory objects.</returns>
		public static EntityList<PrintRoomFeeHistory> GetPrintRoomFeeHistories()
		{
			string commandText = @"
SELECT " + PrintRoomFeeHistory.SelectFieldList + "FROM [dbo].[PrintRoomFeeHistory] " + PrintRoomFeeHistory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<PrintRoomFeeHistory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection PrintRoomFeeHistory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of PrintRoomFeeHistory objects.</returns>
        public static EntityList<PrintRoomFeeHistory> GetPrintRoomFeeHistories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PrintRoomFeeHistory>(SelectFieldList, "FROM [dbo].[PrintRoomFeeHistory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection PrintRoomFeeHistory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of PrintRoomFeeHistory objects.</returns>
        public static EntityList<PrintRoomFeeHistory> GetPrintRoomFeeHistories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PrintRoomFeeHistory>(SelectFieldList, "FROM [dbo].[PrintRoomFeeHistory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection PrintRoomFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of PrintRoomFeeHistory objects.</returns>
		protected static EntityList<PrintRoomFeeHistory> GetPrintRoomFeeHistories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPrintRoomFeeHistories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection PrintRoomFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of PrintRoomFeeHistory objects.</returns>
		protected static EntityList<PrintRoomFeeHistory> GetPrintRoomFeeHistories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPrintRoomFeeHistories(string.Empty, where, parameters, PrintRoomFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PrintRoomFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of PrintRoomFeeHistory objects.</returns>
		protected static EntityList<PrintRoomFeeHistory> GetPrintRoomFeeHistories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPrintRoomFeeHistories(prefix, where, parameters, PrintRoomFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PrintRoomFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of PrintRoomFeeHistory objects.</returns>
		protected static EntityList<PrintRoomFeeHistory> GetPrintRoomFeeHistories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetPrintRoomFeeHistories(string.Empty, where, parameters, PrintRoomFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PrintRoomFeeHistory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of PrintRoomFeeHistory objects.</returns>
		protected static EntityList<PrintRoomFeeHistory> GetPrintRoomFeeHistories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetPrintRoomFeeHistories(prefix, where, parameters, PrintRoomFeeHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PrintRoomFeeHistory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of PrintRoomFeeHistory objects.</returns>
		protected static EntityList<PrintRoomFeeHistory> GetPrintRoomFeeHistories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + PrintRoomFeeHistory.SelectFieldList + "FROM [dbo].[PrintRoomFeeHistory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<PrintRoomFeeHistory>(reader);
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
        protected static EntityList<PrintRoomFeeHistory> GetPrintRoomFeeHistories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PrintRoomFeeHistory>(SelectFieldList, "FROM [dbo].[PrintRoomFeeHistory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of PrintRoomFeeHistory objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetPrintRoomFeeHistoryCount()
        {
            return GetPrintRoomFeeHistoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of PrintRoomFeeHistory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetPrintRoomFeeHistoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[PrintRoomFeeHistory] " + where;

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
		public static partial class PrintRoomFeeHistory_Properties
		{
			public const string ID = "ID";
			public const string Cost = "Cost";
			public const string CostCapital = "CostCapital";
			public const string RealCost = "RealCost";
			public const string PreChargeMoney = "PreChargeMoney";
			public const string DiscountMoney = "DiscountMoney";
			public const string RealMoneyCost1 = "RealMoneyCost1";
			public const string RealMoneyCost2 = "RealMoneyCost2";
			public const string Remark = "Remark";
			public const string AddMan = "AddMan";
			public const string AddTime = "AddTime";
			public const string PrintNumber = "PrintNumber";
			public const string ChargeMan = "ChargeMan";
			public const string ChargeBackMoney = "ChargeBackMoney";
			public const string ChargeTime = "ChargeTime";
			public const string ChageType1 = "ChageType1";
			public const string IsCancel = "IsCancel";
			public const string FullName = "FullName";
			public const string ChageType2 = "ChageType2";
			public const string CancelMan = "CancelMan";
			public const string CancelTime = "CancelTime";
			public const string PrintCount = "PrintCount";
			public const string LastPrintTime = "LastPrintTime";
			public const string PrintRemark = "PrintRemark";
			public const string IsRePrint = "IsRePrint";
			public const string WeiShuMore = "WeiShuMore";
			public const string WeiShuConsume = "WeiShuConsume";
			public const string OrderNumberID = "OrderNumberID";
			public const string RoomFeeOrderID = "RoomFeeOrderID";
			public const string RoomFullName = "RoomFullName";
			public const string RoomOwnerName = "RoomOwnerName";
			public const string ChargeForSummary = "ChargeForSummary";
			public const string ChargeMethods = "ChargeMethods";
			public const string WeiShuBalance = "WeiShuBalance";
			public const string OrderNumberType = "OrderNumberType";
			public const string PrintTitle = "PrintTitle";
			public const string PrintSubTitle = "PrintSubTitle";
			public const string IsChequePrint = "IsChequePrint";
			public const string ChequeNumber = "ChequeNumber";
			public const string ChequePDFPath = "ChequePDFPath";
			public const string ChequeInvoiceStatus = "ChequeInvoiceStatus";
			public const string ChequeInvoiceNo = "ChequeInvoiceNo";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Cost" , "decimal:"},
    			 {"CostCapital" , "string:"},
    			 {"RealCost" , "decimal:"},
    			 {"PreChargeMoney" , "decimal:"},
    			 {"DiscountMoney" , "decimal:"},
    			 {"RealMoneyCost1" , "decimal:"},
    			 {"RealMoneyCost2" , "decimal:"},
    			 {"Remark" , "string:"},
    			 {"AddMan" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"PrintNumber" , "string:"},
    			 {"ChargeMan" , "string:"},
    			 {"ChargeBackMoney" , "decimal:"},
    			 {"ChargeTime" , "DateTime:"},
    			 {"ChageType1" , "int:"},
    			 {"IsCancel" , "bool:"},
    			 {"FullName" , "string:"},
    			 {"ChageType2" , "int:"},
    			 {"CancelMan" , "string:"},
    			 {"CancelTime" , "DateTime:"},
    			 {"PrintCount" , "int:"},
    			 {"LastPrintTime" , "DateTime:"},
    			 {"PrintRemark" , "string:"},
    			 {"IsRePrint" , "bool:"},
    			 {"WeiShuMore" , "decimal:"},
    			 {"WeiShuConsume" , "decimal:"},
    			 {"OrderNumberID" , "int:"},
    			 {"RoomFeeOrderID" , "int:"},
    			 {"RoomFullName" , "string:"},
    			 {"RoomOwnerName" , "string:"},
    			 {"ChargeForSummary" , "string:"},
    			 {"ChargeMethods" , "string:"},
    			 {"WeiShuBalance" , "decimal:"},
    			 {"OrderNumberType" , "int:"},
    			 {"PrintTitle" , "string:"},
    			 {"PrintSubTitle" , "string:"},
    			 {"IsChequePrint" , "bool:"},
    			 {"ChequeNumber" , "string:"},
    			 {"ChequePDFPath" , "string:"},
    			 {"ChequeInvoiceStatus" , "int:"},
    			 {"ChequeInvoiceNo" , "string:"},
            };
		}
		#endregion
	}
}
