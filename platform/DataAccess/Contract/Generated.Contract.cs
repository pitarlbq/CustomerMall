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
	/// This object represents the properties and methods of a Contract.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Contract 
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
			set 
			{
				if (this._rentName != value) 
				{
					this._rentName = value;
					this.IsDirty = true;	
					OnPropertyChanged("RentName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contractStatus = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractStatus
		{
			[DebuggerStepThrough()]
			get { return this._contractStatus; }
			set 
			{
				if (this._contractStatus != value) 
				{
					this._contractStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomLocation = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomLocation
		{
			[DebuggerStepThrough()]
			get { return this._roomLocation; }
			set 
			{
				if (this._roomLocation != value) 
				{
					this._roomLocation = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomLocation");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _roomArea = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RoomArea
		{
			[DebuggerStepThrough()]
			get { return this._roomArea; }
			set 
			{
				if (this._roomArea != value) 
				{
					this._roomArea = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomArea");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomUseFor = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomUseFor
		{
			[DebuggerStepThrough()]
			get { return this._roomUseFor; }
			set 
			{
				if (this._roomUseFor != value) 
				{
					this._roomUseFor = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomUseFor");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomStatus = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomStatus
		{
			[DebuggerStepThrough()]
			get { return this._roomStatus; }
			set 
			{
				if (this._roomStatus != value) 
				{
					this._roomStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomStatus");
				}
			}
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
			set 
			{
				if (this._contractNo != value) 
				{
					this._contractNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractNo");
				}
			}
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
			set 
			{
				if (this._contractName != value) 
				{
					this._contractName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _contractDeposit = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ContractDeposit
		{
			[DebuggerStepThrough()]
			get { return this._contractDeposit; }
			set 
			{
				if (this._contractDeposit != value) 
				{
					this._contractDeposit = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractDeposit");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _timeLimit = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TimeLimit
		{
			[DebuggerStepThrough()]
			get { return this._timeLimit; }
			set 
			{
				if (this._timeLimit != value) 
				{
					this._timeLimit = value;
					this.IsDirty = true;	
					OnPropertyChanged("TimeLimit");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _signTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime SignTime
		{
			[DebuggerStepThrough()]
			get { return this._signTime; }
			set 
			{
				if (this._signTime != value) 
				{
					this._signTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("SignTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _rentStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime RentStartTime
		{
			[DebuggerStepThrough()]
			get { return this._rentStartTime; }
			set 
			{
				if (this._rentStartTime != value) 
				{
					this._rentStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("RentStartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _rentEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime RentEndTime
		{
			[DebuggerStepThrough()]
			get { return this._rentEndTime; }
			set 
			{
				if (this._rentEndTime != value) 
				{
					this._rentEndTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("RentEndTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _freeDays = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int FreeDays
		{
			[DebuggerStepThrough()]
			get { return this._freeDays; }
			set 
			{
				if (this._freeDays != value) 
				{
					this._freeDays = value;
					this.IsDirty = true;	
					OnPropertyChanged("FreeDays");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _freeStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime FreeStartTime
		{
			[DebuggerStepThrough()]
			get { return this._freeStartTime; }
			set 
			{
				if (this._freeStartTime != value) 
				{
					this._freeStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("FreeStartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _freeEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime FreeEndTime
		{
			[DebuggerStepThrough()]
			get { return this._freeEndTime; }
			set 
			{
				if (this._freeEndTime != value) 
				{
					this._freeEndTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("FreeEndTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _openTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime OpenTime
		{
			[DebuggerStepThrough()]
			get { return this._openTime; }
			set 
			{
				if (this._openTime != value) 
				{
					this._openTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("OpenTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _inTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime InTime
		{
			[DebuggerStepThrough()]
			get { return this._inTime; }
			set 
			{
				if (this._inTime != value) 
				{
					this._inTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("InTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _outTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime OutTime
		{
			[DebuggerStepThrough()]
			get { return this._outTime; }
			set 
			{
				if (this._outTime != value) 
				{
					this._outTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("OutTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _rentPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RentPrice
		{
			[DebuggerStepThrough()]
			get { return this._rentPrice; }
			set 
			{
				if (this._rentPrice != value) 
				{
					this._rentPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("RentPrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _rentRange = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RentRange
		{
			[DebuggerStepThrough()]
			get { return this._rentRange; }
			set 
			{
				if (this._rentRange != value) 
				{
					this._rentRange = value;
					this.IsDirty = true;	
					OnPropertyChanged("RentRange");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeRange = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeRange
		{
			[DebuggerStepThrough()]
			get { return this._chargeRange; }
			set 
			{
				if (this._chargeRange != value) 
				{
					this._chargeRange = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeRange");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sellerProduct = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SellerProduct
		{
			[DebuggerStepThrough()]
			get { return this._sellerProduct; }
			set 
			{
				if (this._sellerProduct != value) 
				{
					this._sellerProduct = value;
					this.IsDirty = true;	
					OnPropertyChanged("SellerProduct");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _everyYearUp = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal EveryYearUp
		{
			[DebuggerStepThrough()]
			get { return this._everyYearUp; }
			set 
			{
				if (this._everyYearUp != value) 
				{
					this._everyYearUp = value;
					this.IsDirty = true;	
					OnPropertyChanged("EveryYearUp");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _brandModel = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BrandModel
		{
			[DebuggerStepThrough()]
			get { return this._brandModel; }
			set 
			{
				if (this._brandModel != value) 
				{
					this._brandModel = value;
					this.IsDirty = true;	
					OnPropertyChanged("BrandModel");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contractSummary = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractSummary
		{
			[DebuggerStepThrough()]
			get { return this._contractSummary; }
			set 
			{
				if (this._contractSummary != value) 
				{
					this._contractSummary = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractSummary");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _phoneNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PhoneNumber
		{
			[DebuggerStepThrough()]
			get { return this._phoneNumber; }
			set 
			{
				if (this._phoneNumber != value) 
				{
					this._phoneNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("PhoneNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _address = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Address
		{
			[DebuggerStepThrough()]
			get { return this._address; }
			set 
			{
				if (this._address != value) 
				{
					this._address = value;
					this.IsDirty = true;	
					OnPropertyChanged("Address");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _customerName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CustomerName
		{
			[DebuggerStepThrough()]
			get { return this._customerName; }
			set 
			{
				if (this._customerName != value) 
				{
					this._customerName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CustomerName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _iDCardNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string IDCardNo
		{
			[DebuggerStepThrough()]
			get { return this._iDCardNo; }
			set 
			{
				if (this._iDCardNo != value) 
				{
					this._iDCardNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("IDCardNo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _deliverTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime DeliverTime
		{
			[DebuggerStepThrough()]
			get { return this._deliverTime; }
			set 
			{
				if (this._deliverTime != value) 
				{
					this._deliverTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeliverTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _iDCardAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string IDCardAddress
		{
			[DebuggerStepThrough()]
			get { return this._iDCardAddress; }
			set 
			{
				if (this._iDCardAddress != value) 
				{
					this._iDCardAddress = value;
					this.IsDirty = true;	
					OnPropertyChanged("IDCardAddress");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _rentUseFor = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RentUseFor
		{
			[DebuggerStepThrough()]
			get { return this._rentUseFor; }
			set 
			{
				if (this._rentUseFor != value) 
				{
					this._rentUseFor = value;
					this.IsDirty = true;	
					OnPropertyChanged("RentUseFor");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _businessLicense = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BusinessLicense
		{
			[DebuggerStepThrough()]
			get { return this._businessLicense; }
			set 
			{
				if (this._businessLicense != value) 
				{
					this._businessLicense = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessLicense");
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
			set 
			{
				if (this._contractPhone != value) 
				{
					this._contractPhone = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractPhone");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _warningTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime WarningTime
		{
			[DebuggerStepThrough()]
			get { return this._warningTime; }
			set 
			{
				if (this._warningTime != value) 
				{
					this._warningTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("WarningTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _inChargeMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string InChargeMan
		{
			[DebuggerStepThrough()]
			get { return this._inChargeMan; }
			set 
			{
				if (this._inChargeMan != value) 
				{
					this._inChargeMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("InChargeMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _topContractID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TopContractID
		{
			[DebuggerStepThrough()]
			get { return this._topContractID; }
			set 
			{
				if (this._topContractID != value) 
				{
					this._topContractID = value;
					this.IsDirty = true;	
					OnPropertyChanged("TopContractID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _parentContractID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ParentContractID
		{
			[DebuggerStepThrough()]
			get { return this._parentContractID; }
			set 
			{
				if (this._parentContractID != value) 
				{
					this._parentContractID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ParentContractID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDivideOn = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDivideOn
		{
			[DebuggerStepThrough()]
			get { return this._isDivideOn; }
			set 
			{
				if (this._isDivideOn != value) 
				{
					this._isDivideOn = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDivideOn");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _contractDevicePercent = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ContractDevicePercent
		{
			[DebuggerStepThrough()]
			get { return this._contractDevicePercent; }
			set 
			{
				if (this._contractDevicePercent != value) 
				{
					this._contractDevicePercent = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractDevicePercent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _contractBasicRentCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ContractBasicRentCost
		{
			[DebuggerStepThrough()]
			get { return this._contractBasicRentCost; }
			set 
			{
				if (this._contractBasicRentCost != value) 
				{
					this._contractBasicRentCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractBasicRentCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _contractDivideSellCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ContractDivideSellCost
		{
			[DebuggerStepThrough()]
			get { return this._contractDivideSellCost; }
			set 
			{
				if (this._contractDivideSellCost != value) 
				{
					this._contractDivideSellCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractDivideSellCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _contractType = int.MinValue;
		/// <summary>
		/// 1-租赁合同 2-物业合同 3-多方合同
		/// </summary>
        [Description("1-租赁合同 2-物业合同 3-多方合同")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ContractType
		{
			[DebuggerStepThrough()]
			get { return this._contractType; }
			set 
			{
				if (this._contractType != value) 
				{
					this._contractType = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractType");
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
		private int _contractRelateType = int.MinValue;
		/// <summary>
		/// 1-续租 2-转租
		/// </summary>
        [Description("1-续租 2-转租")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ContractRelateType
		{
			[DebuggerStepThrough()]
			get { return this._contractRelateType; }
			set 
			{
				if (this._contractRelateType != value) 
				{
					this._contractRelateType = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractRelateType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _relationPhoneID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RelationPhoneID
		{
			[DebuggerStepThrough()]
			get { return this._relationPhoneID; }
			set 
			{
				if (this._relationPhoneID != value) 
				{
					this._relationPhoneID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RelationPhoneID");
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
	[RentName] nvarchar(50),
	[ContractStatus] nvarchar(50),
	[RoomLocation] nvarchar(500),
	[RoomArea] decimal(18, 2),
	[RoomUseFor] nvarchar(50),
	[RoomStatus] nvarchar(50),
	[ContractNo] nvarchar(200),
	[ContractName] nvarchar(200),
	[ContractDeposit] decimal(18, 2),
	[TimeLimit] int,
	[SignTime] datetime,
	[RentStartTime] datetime,
	[RentEndTime] datetime,
	[FreeDays] int,
	[FreeStartTime] datetime,
	[FreeEndTime] datetime,
	[OpenTime] datetime,
	[InTime] datetime,
	[OutTime] datetime,
	[RentPrice] decimal(18, 2),
	[RentRange] nvarchar(50),
	[ChargeRange] nvarchar(50),
	[SellerProduct] nvarchar(500),
	[EveryYearUp] decimal(18, 2),
	[BrandModel] nvarchar(200),
	[ContractSummary] ntext,
	[PhoneNumber] nvarchar(50),
	[Address] nvarchar(200),
	[CustomerName] nvarchar(50),
	[IDCardNo] nvarchar(50),
	[DeliverTime] datetime,
	[IDCardAddress] nchar(10),
	[RentUseFor] nvarchar(100),
	[BusinessLicense] nvarchar(100),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ContractPhone] nvarchar(100),
	[WarningTime] datetime,
	[InChargeMan] nvarchar(100),
	[TopContractID] int,
	[ParentContractID] int,
	[IsDivideOn] bit,
	[ContractDevicePercent] decimal(18, 4),
	[ContractBasicRentCost] decimal(18, 2),
	[ContractDivideSellCost] decimal(18, 2),
	[ContractType] int,
	[OrderNumberID] int,
	[ContractRelateType] int,
	[RelationPhoneID] int
);

INSERT INTO [dbo].[Contract] (
	[Contract].[RoomID],
	[Contract].[RentName],
	[Contract].[ContractStatus],
	[Contract].[RoomLocation],
	[Contract].[RoomArea],
	[Contract].[RoomUseFor],
	[Contract].[RoomStatus],
	[Contract].[ContractNo],
	[Contract].[ContractName],
	[Contract].[ContractDeposit],
	[Contract].[TimeLimit],
	[Contract].[SignTime],
	[Contract].[RentStartTime],
	[Contract].[RentEndTime],
	[Contract].[FreeDays],
	[Contract].[FreeStartTime],
	[Contract].[FreeEndTime],
	[Contract].[OpenTime],
	[Contract].[InTime],
	[Contract].[OutTime],
	[Contract].[RentPrice],
	[Contract].[RentRange],
	[Contract].[ChargeRange],
	[Contract].[SellerProduct],
	[Contract].[EveryYearUp],
	[Contract].[BrandModel],
	[Contract].[ContractSummary],
	[Contract].[PhoneNumber],
	[Contract].[Address],
	[Contract].[CustomerName],
	[Contract].[IDCardNo],
	[Contract].[DeliverTime],
	[Contract].[IDCardAddress],
	[Contract].[RentUseFor],
	[Contract].[BusinessLicense],
	[Contract].[AddTime],
	[Contract].[AddMan],
	[Contract].[ContractPhone],
	[Contract].[WarningTime],
	[Contract].[InChargeMan],
	[Contract].[TopContractID],
	[Contract].[ParentContractID],
	[Contract].[IsDivideOn],
	[Contract].[ContractDevicePercent],
	[Contract].[ContractBasicRentCost],
	[Contract].[ContractDivideSellCost],
	[Contract].[ContractType],
	[Contract].[OrderNumberID],
	[Contract].[ContractRelateType],
	[Contract].[RelationPhoneID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[RentName],
	INSERTED.[ContractStatus],
	INSERTED.[RoomLocation],
	INSERTED.[RoomArea],
	INSERTED.[RoomUseFor],
	INSERTED.[RoomStatus],
	INSERTED.[ContractNo],
	INSERTED.[ContractName],
	INSERTED.[ContractDeposit],
	INSERTED.[TimeLimit],
	INSERTED.[SignTime],
	INSERTED.[RentStartTime],
	INSERTED.[RentEndTime],
	INSERTED.[FreeDays],
	INSERTED.[FreeStartTime],
	INSERTED.[FreeEndTime],
	INSERTED.[OpenTime],
	INSERTED.[InTime],
	INSERTED.[OutTime],
	INSERTED.[RentPrice],
	INSERTED.[RentRange],
	INSERTED.[ChargeRange],
	INSERTED.[SellerProduct],
	INSERTED.[EveryYearUp],
	INSERTED.[BrandModel],
	INSERTED.[ContractSummary],
	INSERTED.[PhoneNumber],
	INSERTED.[Address],
	INSERTED.[CustomerName],
	INSERTED.[IDCardNo],
	INSERTED.[DeliverTime],
	INSERTED.[IDCardAddress],
	INSERTED.[RentUseFor],
	INSERTED.[BusinessLicense],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ContractPhone],
	INSERTED.[WarningTime],
	INSERTED.[InChargeMan],
	INSERTED.[TopContractID],
	INSERTED.[ParentContractID],
	INSERTED.[IsDivideOn],
	INSERTED.[ContractDevicePercent],
	INSERTED.[ContractBasicRentCost],
	INSERTED.[ContractDivideSellCost],
	INSERTED.[ContractType],
	INSERTED.[OrderNumberID],
	INSERTED.[ContractRelateType],
	INSERTED.[RelationPhoneID]
into @table
VALUES ( 
	@RoomID,
	@RentName,
	@ContractStatus,
	@RoomLocation,
	@RoomArea,
	@RoomUseFor,
	@RoomStatus,
	@ContractNo,
	@ContractName,
	@ContractDeposit,
	@TimeLimit,
	@SignTime,
	@RentStartTime,
	@RentEndTime,
	@FreeDays,
	@FreeStartTime,
	@FreeEndTime,
	@OpenTime,
	@InTime,
	@OutTime,
	@RentPrice,
	@RentRange,
	@ChargeRange,
	@SellerProduct,
	@EveryYearUp,
	@BrandModel,
	@ContractSummary,
	@PhoneNumber,
	@Address,
	@CustomerName,
	@IDCardNo,
	@DeliverTime,
	@IDCardAddress,
	@RentUseFor,
	@BusinessLicense,
	@AddTime,
	@AddMan,
	@ContractPhone,
	@WarningTime,
	@InChargeMan,
	@TopContractID,
	@ParentContractID,
	@IsDivideOn,
	@ContractDevicePercent,
	@ContractBasicRentCost,
	@ContractDivideSellCost,
	@ContractType,
	@OrderNumberID,
	@ContractRelateType,
	@RelationPhoneID 
); 

SELECT 
	[ID],
	[RoomID],
	[RentName],
	[ContractStatus],
	[RoomLocation],
	[RoomArea],
	[RoomUseFor],
	[RoomStatus],
	[ContractNo],
	[ContractName],
	[ContractDeposit],
	[TimeLimit],
	[SignTime],
	[RentStartTime],
	[RentEndTime],
	[FreeDays],
	[FreeStartTime],
	[FreeEndTime],
	[OpenTime],
	[InTime],
	[OutTime],
	[RentPrice],
	[RentRange],
	[ChargeRange],
	[SellerProduct],
	[EveryYearUp],
	[BrandModel],
	[ContractSummary],
	[PhoneNumber],
	[Address],
	[CustomerName],
	[IDCardNo],
	[DeliverTime],
	[IDCardAddress],
	[RentUseFor],
	[BusinessLicense],
	[AddTime],
	[AddMan],
	[ContractPhone],
	[WarningTime],
	[InChargeMan],
	[TopContractID],
	[ParentContractID],
	[IsDivideOn],
	[ContractDevicePercent],
	[ContractBasicRentCost],
	[ContractDivideSellCost],
	[ContractType],
	[OrderNumberID],
	[ContractRelateType],
	[RelationPhoneID] 
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
	[RentName] nvarchar(50),
	[ContractStatus] nvarchar(50),
	[RoomLocation] nvarchar(500),
	[RoomArea] decimal(18, 2),
	[RoomUseFor] nvarchar(50),
	[RoomStatus] nvarchar(50),
	[ContractNo] nvarchar(200),
	[ContractName] nvarchar(200),
	[ContractDeposit] decimal(18, 2),
	[TimeLimit] int,
	[SignTime] datetime,
	[RentStartTime] datetime,
	[RentEndTime] datetime,
	[FreeDays] int,
	[FreeStartTime] datetime,
	[FreeEndTime] datetime,
	[OpenTime] datetime,
	[InTime] datetime,
	[OutTime] datetime,
	[RentPrice] decimal(18, 2),
	[RentRange] nvarchar(50),
	[ChargeRange] nvarchar(50),
	[SellerProduct] nvarchar(500),
	[EveryYearUp] decimal(18, 2),
	[BrandModel] nvarchar(200),
	[ContractSummary] ntext,
	[PhoneNumber] nvarchar(50),
	[Address] nvarchar(200),
	[CustomerName] nvarchar(50),
	[IDCardNo] nvarchar(50),
	[DeliverTime] datetime,
	[IDCardAddress] nchar(10),
	[RentUseFor] nvarchar(100),
	[BusinessLicense] nvarchar(100),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ContractPhone] nvarchar(100),
	[WarningTime] datetime,
	[InChargeMan] nvarchar(100),
	[TopContractID] int,
	[ParentContractID] int,
	[IsDivideOn] bit,
	[ContractDevicePercent] decimal(18, 4),
	[ContractBasicRentCost] decimal(18, 2),
	[ContractDivideSellCost] decimal(18, 2),
	[ContractType] int,
	[OrderNumberID] int,
	[ContractRelateType] int,
	[RelationPhoneID] int
);

UPDATE [dbo].[Contract] SET 
	[Contract].[RoomID] = @RoomID,
	[Contract].[RentName] = @RentName,
	[Contract].[ContractStatus] = @ContractStatus,
	[Contract].[RoomLocation] = @RoomLocation,
	[Contract].[RoomArea] = @RoomArea,
	[Contract].[RoomUseFor] = @RoomUseFor,
	[Contract].[RoomStatus] = @RoomStatus,
	[Contract].[ContractNo] = @ContractNo,
	[Contract].[ContractName] = @ContractName,
	[Contract].[ContractDeposit] = @ContractDeposit,
	[Contract].[TimeLimit] = @TimeLimit,
	[Contract].[SignTime] = @SignTime,
	[Contract].[RentStartTime] = @RentStartTime,
	[Contract].[RentEndTime] = @RentEndTime,
	[Contract].[FreeDays] = @FreeDays,
	[Contract].[FreeStartTime] = @FreeStartTime,
	[Contract].[FreeEndTime] = @FreeEndTime,
	[Contract].[OpenTime] = @OpenTime,
	[Contract].[InTime] = @InTime,
	[Contract].[OutTime] = @OutTime,
	[Contract].[RentPrice] = @RentPrice,
	[Contract].[RentRange] = @RentRange,
	[Contract].[ChargeRange] = @ChargeRange,
	[Contract].[SellerProduct] = @SellerProduct,
	[Contract].[EveryYearUp] = @EveryYearUp,
	[Contract].[BrandModel] = @BrandModel,
	[Contract].[ContractSummary] = @ContractSummary,
	[Contract].[PhoneNumber] = @PhoneNumber,
	[Contract].[Address] = @Address,
	[Contract].[CustomerName] = @CustomerName,
	[Contract].[IDCardNo] = @IDCardNo,
	[Contract].[DeliverTime] = @DeliverTime,
	[Contract].[IDCardAddress] = @IDCardAddress,
	[Contract].[RentUseFor] = @RentUseFor,
	[Contract].[BusinessLicense] = @BusinessLicense,
	[Contract].[AddTime] = @AddTime,
	[Contract].[AddMan] = @AddMan,
	[Contract].[ContractPhone] = @ContractPhone,
	[Contract].[WarningTime] = @WarningTime,
	[Contract].[InChargeMan] = @InChargeMan,
	[Contract].[TopContractID] = @TopContractID,
	[Contract].[ParentContractID] = @ParentContractID,
	[Contract].[IsDivideOn] = @IsDivideOn,
	[Contract].[ContractDevicePercent] = @ContractDevicePercent,
	[Contract].[ContractBasicRentCost] = @ContractBasicRentCost,
	[Contract].[ContractDivideSellCost] = @ContractDivideSellCost,
	[Contract].[ContractType] = @ContractType,
	[Contract].[OrderNumberID] = @OrderNumberID,
	[Contract].[ContractRelateType] = @ContractRelateType,
	[Contract].[RelationPhoneID] = @RelationPhoneID 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[RentName],
	INSERTED.[ContractStatus],
	INSERTED.[RoomLocation],
	INSERTED.[RoomArea],
	INSERTED.[RoomUseFor],
	INSERTED.[RoomStatus],
	INSERTED.[ContractNo],
	INSERTED.[ContractName],
	INSERTED.[ContractDeposit],
	INSERTED.[TimeLimit],
	INSERTED.[SignTime],
	INSERTED.[RentStartTime],
	INSERTED.[RentEndTime],
	INSERTED.[FreeDays],
	INSERTED.[FreeStartTime],
	INSERTED.[FreeEndTime],
	INSERTED.[OpenTime],
	INSERTED.[InTime],
	INSERTED.[OutTime],
	INSERTED.[RentPrice],
	INSERTED.[RentRange],
	INSERTED.[ChargeRange],
	INSERTED.[SellerProduct],
	INSERTED.[EveryYearUp],
	INSERTED.[BrandModel],
	INSERTED.[ContractSummary],
	INSERTED.[PhoneNumber],
	INSERTED.[Address],
	INSERTED.[CustomerName],
	INSERTED.[IDCardNo],
	INSERTED.[DeliverTime],
	INSERTED.[IDCardAddress],
	INSERTED.[RentUseFor],
	INSERTED.[BusinessLicense],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ContractPhone],
	INSERTED.[WarningTime],
	INSERTED.[InChargeMan],
	INSERTED.[TopContractID],
	INSERTED.[ParentContractID],
	INSERTED.[IsDivideOn],
	INSERTED.[ContractDevicePercent],
	INSERTED.[ContractBasicRentCost],
	INSERTED.[ContractDivideSellCost],
	INSERTED.[ContractType],
	INSERTED.[OrderNumberID],
	INSERTED.[ContractRelateType],
	INSERTED.[RelationPhoneID]
into @table
WHERE 
	[Contract].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[RentName],
	[ContractStatus],
	[RoomLocation],
	[RoomArea],
	[RoomUseFor],
	[RoomStatus],
	[ContractNo],
	[ContractName],
	[ContractDeposit],
	[TimeLimit],
	[SignTime],
	[RentStartTime],
	[RentEndTime],
	[FreeDays],
	[FreeStartTime],
	[FreeEndTime],
	[OpenTime],
	[InTime],
	[OutTime],
	[RentPrice],
	[RentRange],
	[ChargeRange],
	[SellerProduct],
	[EveryYearUp],
	[BrandModel],
	[ContractSummary],
	[PhoneNumber],
	[Address],
	[CustomerName],
	[IDCardNo],
	[DeliverTime],
	[IDCardAddress],
	[RentUseFor],
	[BusinessLicense],
	[AddTime],
	[AddMan],
	[ContractPhone],
	[WarningTime],
	[InChargeMan],
	[TopContractID],
	[ParentContractID],
	[IsDivideOn],
	[ContractDevicePercent],
	[ContractBasicRentCost],
	[ContractDivideSellCost],
	[ContractType],
	[OrderNumberID],
	[ContractRelateType],
	[RelationPhoneID] 
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
DELETE FROM [dbo].[Contract]
WHERE 
	[Contract].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Contract() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetContract(this.ID));
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
	[Contract].[ID],
	[Contract].[RoomID],
	[Contract].[RentName],
	[Contract].[ContractStatus],
	[Contract].[RoomLocation],
	[Contract].[RoomArea],
	[Contract].[RoomUseFor],
	[Contract].[RoomStatus],
	[Contract].[ContractNo],
	[Contract].[ContractName],
	[Contract].[ContractDeposit],
	[Contract].[TimeLimit],
	[Contract].[SignTime],
	[Contract].[RentStartTime],
	[Contract].[RentEndTime],
	[Contract].[FreeDays],
	[Contract].[FreeStartTime],
	[Contract].[FreeEndTime],
	[Contract].[OpenTime],
	[Contract].[InTime],
	[Contract].[OutTime],
	[Contract].[RentPrice],
	[Contract].[RentRange],
	[Contract].[ChargeRange],
	[Contract].[SellerProduct],
	[Contract].[EveryYearUp],
	[Contract].[BrandModel],
	[Contract].[ContractSummary],
	[Contract].[PhoneNumber],
	[Contract].[Address],
	[Contract].[CustomerName],
	[Contract].[IDCardNo],
	[Contract].[DeliverTime],
	[Contract].[IDCardAddress],
	[Contract].[RentUseFor],
	[Contract].[BusinessLicense],
	[Contract].[AddTime],
	[Contract].[AddMan],
	[Contract].[ContractPhone],
	[Contract].[WarningTime],
	[Contract].[InChargeMan],
	[Contract].[TopContractID],
	[Contract].[ParentContractID],
	[Contract].[IsDivideOn],
	[Contract].[ContractDevicePercent],
	[Contract].[ContractBasicRentCost],
	[Contract].[ContractDivideSellCost],
	[Contract].[ContractType],
	[Contract].[OrderNumberID],
	[Contract].[ContractRelateType],
	[Contract].[RelationPhoneID]
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
                return "Contract";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Contract into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="rentName">rentName</param>
		/// <param name="contractStatus">contractStatus</param>
		/// <param name="roomLocation">roomLocation</param>
		/// <param name="roomArea">roomArea</param>
		/// <param name="roomUseFor">roomUseFor</param>
		/// <param name="roomStatus">roomStatus</param>
		/// <param name="contractNo">contractNo</param>
		/// <param name="contractName">contractName</param>
		/// <param name="contractDeposit">contractDeposit</param>
		/// <param name="timeLimit">timeLimit</param>
		/// <param name="signTime">signTime</param>
		/// <param name="rentStartTime">rentStartTime</param>
		/// <param name="rentEndTime">rentEndTime</param>
		/// <param name="freeDays">freeDays</param>
		/// <param name="freeStartTime">freeStartTime</param>
		/// <param name="freeEndTime">freeEndTime</param>
		/// <param name="openTime">openTime</param>
		/// <param name="inTime">inTime</param>
		/// <param name="outTime">outTime</param>
		/// <param name="rentPrice">rentPrice</param>
		/// <param name="rentRange">rentRange</param>
		/// <param name="chargeRange">chargeRange</param>
		/// <param name="sellerProduct">sellerProduct</param>
		/// <param name="everyYearUp">everyYearUp</param>
		/// <param name="brandModel">brandModel</param>
		/// <param name="contractSummary">contractSummary</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="address">address</param>
		/// <param name="customerName">customerName</param>
		/// <param name="iDCardNo">iDCardNo</param>
		/// <param name="deliverTime">deliverTime</param>
		/// <param name="iDCardAddress">iDCardAddress</param>
		/// <param name="rentUseFor">rentUseFor</param>
		/// <param name="businessLicense">businessLicense</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="contractPhone">contractPhone</param>
		/// <param name="warningTime">warningTime</param>
		/// <param name="inChargeMan">inChargeMan</param>
		/// <param name="topContractID">topContractID</param>
		/// <param name="parentContractID">parentContractID</param>
		/// <param name="isDivideOn">isDivideOn</param>
		/// <param name="contractDevicePercent">contractDevicePercent</param>
		/// <param name="contractBasicRentCost">contractBasicRentCost</param>
		/// <param name="contractDivideSellCost">contractDivideSellCost</param>
		/// <param name="contractType">contractType</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="contractRelateType">contractRelateType</param>
		/// <param name="relationPhoneID">relationPhoneID</param>
		public static void InsertContract(int @roomID, string @rentName, string @contractStatus, string @roomLocation, decimal @roomArea, string @roomUseFor, string @roomStatus, string @contractNo, string @contractName, decimal @contractDeposit, int @timeLimit, DateTime @signTime, DateTime @rentStartTime, DateTime @rentEndTime, int @freeDays, DateTime @freeStartTime, DateTime @freeEndTime, DateTime @openTime, DateTime @inTime, DateTime @outTime, decimal @rentPrice, string @rentRange, string @chargeRange, string @sellerProduct, decimal @everyYearUp, string @brandModel, string @contractSummary, string @phoneNumber, string @address, string @customerName, string @iDCardNo, DateTime @deliverTime, string @iDCardAddress, string @rentUseFor, string @businessLicense, DateTime @addTime, string @addMan, string @contractPhone, DateTime @warningTime, string @inChargeMan, int @topContractID, int @parentContractID, bool @isDivideOn, decimal @contractDevicePercent, decimal @contractBasicRentCost, decimal @contractDivideSellCost, int @contractType, int @orderNumberID, int @contractRelateType, int @relationPhoneID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertContract(@roomID, @rentName, @contractStatus, @roomLocation, @roomArea, @roomUseFor, @roomStatus, @contractNo, @contractName, @contractDeposit, @timeLimit, @signTime, @rentStartTime, @rentEndTime, @freeDays, @freeStartTime, @freeEndTime, @openTime, @inTime, @outTime, @rentPrice, @rentRange, @chargeRange, @sellerProduct, @everyYearUp, @brandModel, @contractSummary, @phoneNumber, @address, @customerName, @iDCardNo, @deliverTime, @iDCardAddress, @rentUseFor, @businessLicense, @addTime, @addMan, @contractPhone, @warningTime, @inChargeMan, @topContractID, @parentContractID, @isDivideOn, @contractDevicePercent, @contractBasicRentCost, @contractDivideSellCost, @contractType, @orderNumberID, @contractRelateType, @relationPhoneID, helper);
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
		/// Insert a Contract into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="rentName">rentName</param>
		/// <param name="contractStatus">contractStatus</param>
		/// <param name="roomLocation">roomLocation</param>
		/// <param name="roomArea">roomArea</param>
		/// <param name="roomUseFor">roomUseFor</param>
		/// <param name="roomStatus">roomStatus</param>
		/// <param name="contractNo">contractNo</param>
		/// <param name="contractName">contractName</param>
		/// <param name="contractDeposit">contractDeposit</param>
		/// <param name="timeLimit">timeLimit</param>
		/// <param name="signTime">signTime</param>
		/// <param name="rentStartTime">rentStartTime</param>
		/// <param name="rentEndTime">rentEndTime</param>
		/// <param name="freeDays">freeDays</param>
		/// <param name="freeStartTime">freeStartTime</param>
		/// <param name="freeEndTime">freeEndTime</param>
		/// <param name="openTime">openTime</param>
		/// <param name="inTime">inTime</param>
		/// <param name="outTime">outTime</param>
		/// <param name="rentPrice">rentPrice</param>
		/// <param name="rentRange">rentRange</param>
		/// <param name="chargeRange">chargeRange</param>
		/// <param name="sellerProduct">sellerProduct</param>
		/// <param name="everyYearUp">everyYearUp</param>
		/// <param name="brandModel">brandModel</param>
		/// <param name="contractSummary">contractSummary</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="address">address</param>
		/// <param name="customerName">customerName</param>
		/// <param name="iDCardNo">iDCardNo</param>
		/// <param name="deliverTime">deliverTime</param>
		/// <param name="iDCardAddress">iDCardAddress</param>
		/// <param name="rentUseFor">rentUseFor</param>
		/// <param name="businessLicense">businessLicense</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="contractPhone">contractPhone</param>
		/// <param name="warningTime">warningTime</param>
		/// <param name="inChargeMan">inChargeMan</param>
		/// <param name="topContractID">topContractID</param>
		/// <param name="parentContractID">parentContractID</param>
		/// <param name="isDivideOn">isDivideOn</param>
		/// <param name="contractDevicePercent">contractDevicePercent</param>
		/// <param name="contractBasicRentCost">contractBasicRentCost</param>
		/// <param name="contractDivideSellCost">contractDivideSellCost</param>
		/// <param name="contractType">contractType</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="contractRelateType">contractRelateType</param>
		/// <param name="relationPhoneID">relationPhoneID</param>
		/// <param name="helper">helper</param>
		internal static void InsertContract(int @roomID, string @rentName, string @contractStatus, string @roomLocation, decimal @roomArea, string @roomUseFor, string @roomStatus, string @contractNo, string @contractName, decimal @contractDeposit, int @timeLimit, DateTime @signTime, DateTime @rentStartTime, DateTime @rentEndTime, int @freeDays, DateTime @freeStartTime, DateTime @freeEndTime, DateTime @openTime, DateTime @inTime, DateTime @outTime, decimal @rentPrice, string @rentRange, string @chargeRange, string @sellerProduct, decimal @everyYearUp, string @brandModel, string @contractSummary, string @phoneNumber, string @address, string @customerName, string @iDCardNo, DateTime @deliverTime, string @iDCardAddress, string @rentUseFor, string @businessLicense, DateTime @addTime, string @addMan, string @contractPhone, DateTime @warningTime, string @inChargeMan, int @topContractID, int @parentContractID, bool @isDivideOn, decimal @contractDevicePercent, decimal @contractBasicRentCost, decimal @contractDivideSellCost, int @contractType, int @orderNumberID, int @contractRelateType, int @relationPhoneID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[RentName] nvarchar(50),
	[ContractStatus] nvarchar(50),
	[RoomLocation] nvarchar(500),
	[RoomArea] decimal(18, 2),
	[RoomUseFor] nvarchar(50),
	[RoomStatus] nvarchar(50),
	[ContractNo] nvarchar(200),
	[ContractName] nvarchar(200),
	[ContractDeposit] decimal(18, 2),
	[TimeLimit] int,
	[SignTime] datetime,
	[RentStartTime] datetime,
	[RentEndTime] datetime,
	[FreeDays] int,
	[FreeStartTime] datetime,
	[FreeEndTime] datetime,
	[OpenTime] datetime,
	[InTime] datetime,
	[OutTime] datetime,
	[RentPrice] decimal(18, 2),
	[RentRange] nvarchar(50),
	[ChargeRange] nvarchar(50),
	[SellerProduct] nvarchar(500),
	[EveryYearUp] decimal(18, 2),
	[BrandModel] nvarchar(200),
	[ContractSummary] ntext,
	[PhoneNumber] nvarchar(50),
	[Address] nvarchar(200),
	[CustomerName] nvarchar(50),
	[IDCardNo] nvarchar(50),
	[DeliverTime] datetime,
	[IDCardAddress] nchar(10),
	[RentUseFor] nvarchar(100),
	[BusinessLicense] nvarchar(100),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ContractPhone] nvarchar(100),
	[WarningTime] datetime,
	[InChargeMan] nvarchar(100),
	[TopContractID] int,
	[ParentContractID] int,
	[IsDivideOn] bit,
	[ContractDevicePercent] decimal(18, 4),
	[ContractBasicRentCost] decimal(18, 2),
	[ContractDivideSellCost] decimal(18, 2),
	[ContractType] int,
	[OrderNumberID] int,
	[ContractRelateType] int,
	[RelationPhoneID] int
);

INSERT INTO [dbo].[Contract] (
	[Contract].[RoomID],
	[Contract].[RentName],
	[Contract].[ContractStatus],
	[Contract].[RoomLocation],
	[Contract].[RoomArea],
	[Contract].[RoomUseFor],
	[Contract].[RoomStatus],
	[Contract].[ContractNo],
	[Contract].[ContractName],
	[Contract].[ContractDeposit],
	[Contract].[TimeLimit],
	[Contract].[SignTime],
	[Contract].[RentStartTime],
	[Contract].[RentEndTime],
	[Contract].[FreeDays],
	[Contract].[FreeStartTime],
	[Contract].[FreeEndTime],
	[Contract].[OpenTime],
	[Contract].[InTime],
	[Contract].[OutTime],
	[Contract].[RentPrice],
	[Contract].[RentRange],
	[Contract].[ChargeRange],
	[Contract].[SellerProduct],
	[Contract].[EveryYearUp],
	[Contract].[BrandModel],
	[Contract].[ContractSummary],
	[Contract].[PhoneNumber],
	[Contract].[Address],
	[Contract].[CustomerName],
	[Contract].[IDCardNo],
	[Contract].[DeliverTime],
	[Contract].[IDCardAddress],
	[Contract].[RentUseFor],
	[Contract].[BusinessLicense],
	[Contract].[AddTime],
	[Contract].[AddMan],
	[Contract].[ContractPhone],
	[Contract].[WarningTime],
	[Contract].[InChargeMan],
	[Contract].[TopContractID],
	[Contract].[ParentContractID],
	[Contract].[IsDivideOn],
	[Contract].[ContractDevicePercent],
	[Contract].[ContractBasicRentCost],
	[Contract].[ContractDivideSellCost],
	[Contract].[ContractType],
	[Contract].[OrderNumberID],
	[Contract].[ContractRelateType],
	[Contract].[RelationPhoneID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[RentName],
	INSERTED.[ContractStatus],
	INSERTED.[RoomLocation],
	INSERTED.[RoomArea],
	INSERTED.[RoomUseFor],
	INSERTED.[RoomStatus],
	INSERTED.[ContractNo],
	INSERTED.[ContractName],
	INSERTED.[ContractDeposit],
	INSERTED.[TimeLimit],
	INSERTED.[SignTime],
	INSERTED.[RentStartTime],
	INSERTED.[RentEndTime],
	INSERTED.[FreeDays],
	INSERTED.[FreeStartTime],
	INSERTED.[FreeEndTime],
	INSERTED.[OpenTime],
	INSERTED.[InTime],
	INSERTED.[OutTime],
	INSERTED.[RentPrice],
	INSERTED.[RentRange],
	INSERTED.[ChargeRange],
	INSERTED.[SellerProduct],
	INSERTED.[EveryYearUp],
	INSERTED.[BrandModel],
	INSERTED.[ContractSummary],
	INSERTED.[PhoneNumber],
	INSERTED.[Address],
	INSERTED.[CustomerName],
	INSERTED.[IDCardNo],
	INSERTED.[DeliverTime],
	INSERTED.[IDCardAddress],
	INSERTED.[RentUseFor],
	INSERTED.[BusinessLicense],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ContractPhone],
	INSERTED.[WarningTime],
	INSERTED.[InChargeMan],
	INSERTED.[TopContractID],
	INSERTED.[ParentContractID],
	INSERTED.[IsDivideOn],
	INSERTED.[ContractDevicePercent],
	INSERTED.[ContractBasicRentCost],
	INSERTED.[ContractDivideSellCost],
	INSERTED.[ContractType],
	INSERTED.[OrderNumberID],
	INSERTED.[ContractRelateType],
	INSERTED.[RelationPhoneID]
into @table
VALUES ( 
	@RoomID,
	@RentName,
	@ContractStatus,
	@RoomLocation,
	@RoomArea,
	@RoomUseFor,
	@RoomStatus,
	@ContractNo,
	@ContractName,
	@ContractDeposit,
	@TimeLimit,
	@SignTime,
	@RentStartTime,
	@RentEndTime,
	@FreeDays,
	@FreeStartTime,
	@FreeEndTime,
	@OpenTime,
	@InTime,
	@OutTime,
	@RentPrice,
	@RentRange,
	@ChargeRange,
	@SellerProduct,
	@EveryYearUp,
	@BrandModel,
	@ContractSummary,
	@PhoneNumber,
	@Address,
	@CustomerName,
	@IDCardNo,
	@DeliverTime,
	@IDCardAddress,
	@RentUseFor,
	@BusinessLicense,
	@AddTime,
	@AddMan,
	@ContractPhone,
	@WarningTime,
	@InChargeMan,
	@TopContractID,
	@ParentContractID,
	@IsDivideOn,
	@ContractDevicePercent,
	@ContractBasicRentCost,
	@ContractDivideSellCost,
	@ContractType,
	@OrderNumberID,
	@ContractRelateType,
	@RelationPhoneID 
); 

SELECT 
	[ID],
	[RoomID],
	[RentName],
	[ContractStatus],
	[RoomLocation],
	[RoomArea],
	[RoomUseFor],
	[RoomStatus],
	[ContractNo],
	[ContractName],
	[ContractDeposit],
	[TimeLimit],
	[SignTime],
	[RentStartTime],
	[RentEndTime],
	[FreeDays],
	[FreeStartTime],
	[FreeEndTime],
	[OpenTime],
	[InTime],
	[OutTime],
	[RentPrice],
	[RentRange],
	[ChargeRange],
	[SellerProduct],
	[EveryYearUp],
	[BrandModel],
	[ContractSummary],
	[PhoneNumber],
	[Address],
	[CustomerName],
	[IDCardNo],
	[DeliverTime],
	[IDCardAddress],
	[RentUseFor],
	[BusinessLicense],
	[AddTime],
	[AddMan],
	[ContractPhone],
	[WarningTime],
	[InChargeMan],
	[TopContractID],
	[ParentContractID],
	[IsDivideOn],
	[ContractDevicePercent],
	[ContractBasicRentCost],
	[ContractDivideSellCost],
	[ContractType],
	[OrderNumberID],
	[ContractRelateType],
	[RelationPhoneID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@RentName", EntityBase.GetDatabaseValue(@rentName)));
			parameters.Add(new SqlParameter("@ContractStatus", EntityBase.GetDatabaseValue(@contractStatus)));
			parameters.Add(new SqlParameter("@RoomLocation", EntityBase.GetDatabaseValue(@roomLocation)));
			parameters.Add(new SqlParameter("@RoomArea", EntityBase.GetDatabaseValue(@roomArea)));
			parameters.Add(new SqlParameter("@RoomUseFor", EntityBase.GetDatabaseValue(@roomUseFor)));
			parameters.Add(new SqlParameter("@RoomStatus", EntityBase.GetDatabaseValue(@roomStatus)));
			parameters.Add(new SqlParameter("@ContractNo", EntityBase.GetDatabaseValue(@contractNo)));
			parameters.Add(new SqlParameter("@ContractName", EntityBase.GetDatabaseValue(@contractName)));
			parameters.Add(new SqlParameter("@ContractDeposit", EntityBase.GetDatabaseValue(@contractDeposit)));
			parameters.Add(new SqlParameter("@TimeLimit", EntityBase.GetDatabaseValue(@timeLimit)));
			parameters.Add(new SqlParameter("@SignTime", EntityBase.GetDatabaseValue(@signTime)));
			parameters.Add(new SqlParameter("@RentStartTime", EntityBase.GetDatabaseValue(@rentStartTime)));
			parameters.Add(new SqlParameter("@RentEndTime", EntityBase.GetDatabaseValue(@rentEndTime)));
			parameters.Add(new SqlParameter("@FreeDays", EntityBase.GetDatabaseValue(@freeDays)));
			parameters.Add(new SqlParameter("@FreeStartTime", EntityBase.GetDatabaseValue(@freeStartTime)));
			parameters.Add(new SqlParameter("@FreeEndTime", EntityBase.GetDatabaseValue(@freeEndTime)));
			parameters.Add(new SqlParameter("@OpenTime", EntityBase.GetDatabaseValue(@openTime)));
			parameters.Add(new SqlParameter("@InTime", EntityBase.GetDatabaseValue(@inTime)));
			parameters.Add(new SqlParameter("@OutTime", EntityBase.GetDatabaseValue(@outTime)));
			parameters.Add(new SqlParameter("@RentPrice", EntityBase.GetDatabaseValue(@rentPrice)));
			parameters.Add(new SqlParameter("@RentRange", EntityBase.GetDatabaseValue(@rentRange)));
			parameters.Add(new SqlParameter("@ChargeRange", EntityBase.GetDatabaseValue(@chargeRange)));
			parameters.Add(new SqlParameter("@SellerProduct", EntityBase.GetDatabaseValue(@sellerProduct)));
			parameters.Add(new SqlParameter("@EveryYearUp", EntityBase.GetDatabaseValue(@everyYearUp)));
			parameters.Add(new SqlParameter("@BrandModel", EntityBase.GetDatabaseValue(@brandModel)));
			parameters.Add(new SqlParameter("@ContractSummary", EntityBase.GetDatabaseValue(@contractSummary)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@Address", EntityBase.GetDatabaseValue(@address)));
			parameters.Add(new SqlParameter("@CustomerName", EntityBase.GetDatabaseValue(@customerName)));
			parameters.Add(new SqlParameter("@IDCardNo", EntityBase.GetDatabaseValue(@iDCardNo)));
			parameters.Add(new SqlParameter("@DeliverTime", EntityBase.GetDatabaseValue(@deliverTime)));
			parameters.Add(new SqlParameter("@IDCardAddress", EntityBase.GetDatabaseValue(@iDCardAddress)));
			parameters.Add(new SqlParameter("@RentUseFor", EntityBase.GetDatabaseValue(@rentUseFor)));
			parameters.Add(new SqlParameter("@BusinessLicense", EntityBase.GetDatabaseValue(@businessLicense)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ContractPhone", EntityBase.GetDatabaseValue(@contractPhone)));
			parameters.Add(new SqlParameter("@WarningTime", EntityBase.GetDatabaseValue(@warningTime)));
			parameters.Add(new SqlParameter("@InChargeMan", EntityBase.GetDatabaseValue(@inChargeMan)));
			parameters.Add(new SqlParameter("@TopContractID", EntityBase.GetDatabaseValue(@topContractID)));
			parameters.Add(new SqlParameter("@ParentContractID", EntityBase.GetDatabaseValue(@parentContractID)));
			parameters.Add(new SqlParameter("@IsDivideOn", @isDivideOn));
			parameters.Add(new SqlParameter("@ContractDevicePercent", EntityBase.GetDatabaseValue(@contractDevicePercent)));
			parameters.Add(new SqlParameter("@ContractBasicRentCost", EntityBase.GetDatabaseValue(@contractBasicRentCost)));
			parameters.Add(new SqlParameter("@ContractDivideSellCost", EntityBase.GetDatabaseValue(@contractDivideSellCost)));
			parameters.Add(new SqlParameter("@ContractType", EntityBase.GetDatabaseValue(@contractType)));
			parameters.Add(new SqlParameter("@OrderNumberID", EntityBase.GetDatabaseValue(@orderNumberID)));
			parameters.Add(new SqlParameter("@ContractRelateType", EntityBase.GetDatabaseValue(@contractRelateType)));
			parameters.Add(new SqlParameter("@RelationPhoneID", EntityBase.GetDatabaseValue(@relationPhoneID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Contract into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="rentName">rentName</param>
		/// <param name="contractStatus">contractStatus</param>
		/// <param name="roomLocation">roomLocation</param>
		/// <param name="roomArea">roomArea</param>
		/// <param name="roomUseFor">roomUseFor</param>
		/// <param name="roomStatus">roomStatus</param>
		/// <param name="contractNo">contractNo</param>
		/// <param name="contractName">contractName</param>
		/// <param name="contractDeposit">contractDeposit</param>
		/// <param name="timeLimit">timeLimit</param>
		/// <param name="signTime">signTime</param>
		/// <param name="rentStartTime">rentStartTime</param>
		/// <param name="rentEndTime">rentEndTime</param>
		/// <param name="freeDays">freeDays</param>
		/// <param name="freeStartTime">freeStartTime</param>
		/// <param name="freeEndTime">freeEndTime</param>
		/// <param name="openTime">openTime</param>
		/// <param name="inTime">inTime</param>
		/// <param name="outTime">outTime</param>
		/// <param name="rentPrice">rentPrice</param>
		/// <param name="rentRange">rentRange</param>
		/// <param name="chargeRange">chargeRange</param>
		/// <param name="sellerProduct">sellerProduct</param>
		/// <param name="everyYearUp">everyYearUp</param>
		/// <param name="brandModel">brandModel</param>
		/// <param name="contractSummary">contractSummary</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="address">address</param>
		/// <param name="customerName">customerName</param>
		/// <param name="iDCardNo">iDCardNo</param>
		/// <param name="deliverTime">deliverTime</param>
		/// <param name="iDCardAddress">iDCardAddress</param>
		/// <param name="rentUseFor">rentUseFor</param>
		/// <param name="businessLicense">businessLicense</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="contractPhone">contractPhone</param>
		/// <param name="warningTime">warningTime</param>
		/// <param name="inChargeMan">inChargeMan</param>
		/// <param name="topContractID">topContractID</param>
		/// <param name="parentContractID">parentContractID</param>
		/// <param name="isDivideOn">isDivideOn</param>
		/// <param name="contractDevicePercent">contractDevicePercent</param>
		/// <param name="contractBasicRentCost">contractBasicRentCost</param>
		/// <param name="contractDivideSellCost">contractDivideSellCost</param>
		/// <param name="contractType">contractType</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="contractRelateType">contractRelateType</param>
		/// <param name="relationPhoneID">relationPhoneID</param>
		public static void UpdateContract(int @iD, int @roomID, string @rentName, string @contractStatus, string @roomLocation, decimal @roomArea, string @roomUseFor, string @roomStatus, string @contractNo, string @contractName, decimal @contractDeposit, int @timeLimit, DateTime @signTime, DateTime @rentStartTime, DateTime @rentEndTime, int @freeDays, DateTime @freeStartTime, DateTime @freeEndTime, DateTime @openTime, DateTime @inTime, DateTime @outTime, decimal @rentPrice, string @rentRange, string @chargeRange, string @sellerProduct, decimal @everyYearUp, string @brandModel, string @contractSummary, string @phoneNumber, string @address, string @customerName, string @iDCardNo, DateTime @deliverTime, string @iDCardAddress, string @rentUseFor, string @businessLicense, DateTime @addTime, string @addMan, string @contractPhone, DateTime @warningTime, string @inChargeMan, int @topContractID, int @parentContractID, bool @isDivideOn, decimal @contractDevicePercent, decimal @contractBasicRentCost, decimal @contractDivideSellCost, int @contractType, int @orderNumberID, int @contractRelateType, int @relationPhoneID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateContract(@iD, @roomID, @rentName, @contractStatus, @roomLocation, @roomArea, @roomUseFor, @roomStatus, @contractNo, @contractName, @contractDeposit, @timeLimit, @signTime, @rentStartTime, @rentEndTime, @freeDays, @freeStartTime, @freeEndTime, @openTime, @inTime, @outTime, @rentPrice, @rentRange, @chargeRange, @sellerProduct, @everyYearUp, @brandModel, @contractSummary, @phoneNumber, @address, @customerName, @iDCardNo, @deliverTime, @iDCardAddress, @rentUseFor, @businessLicense, @addTime, @addMan, @contractPhone, @warningTime, @inChargeMan, @topContractID, @parentContractID, @isDivideOn, @contractDevicePercent, @contractBasicRentCost, @contractDivideSellCost, @contractType, @orderNumberID, @contractRelateType, @relationPhoneID, helper);
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
		/// Updates a Contract into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="rentName">rentName</param>
		/// <param name="contractStatus">contractStatus</param>
		/// <param name="roomLocation">roomLocation</param>
		/// <param name="roomArea">roomArea</param>
		/// <param name="roomUseFor">roomUseFor</param>
		/// <param name="roomStatus">roomStatus</param>
		/// <param name="contractNo">contractNo</param>
		/// <param name="contractName">contractName</param>
		/// <param name="contractDeposit">contractDeposit</param>
		/// <param name="timeLimit">timeLimit</param>
		/// <param name="signTime">signTime</param>
		/// <param name="rentStartTime">rentStartTime</param>
		/// <param name="rentEndTime">rentEndTime</param>
		/// <param name="freeDays">freeDays</param>
		/// <param name="freeStartTime">freeStartTime</param>
		/// <param name="freeEndTime">freeEndTime</param>
		/// <param name="openTime">openTime</param>
		/// <param name="inTime">inTime</param>
		/// <param name="outTime">outTime</param>
		/// <param name="rentPrice">rentPrice</param>
		/// <param name="rentRange">rentRange</param>
		/// <param name="chargeRange">chargeRange</param>
		/// <param name="sellerProduct">sellerProduct</param>
		/// <param name="everyYearUp">everyYearUp</param>
		/// <param name="brandModel">brandModel</param>
		/// <param name="contractSummary">contractSummary</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="address">address</param>
		/// <param name="customerName">customerName</param>
		/// <param name="iDCardNo">iDCardNo</param>
		/// <param name="deliverTime">deliverTime</param>
		/// <param name="iDCardAddress">iDCardAddress</param>
		/// <param name="rentUseFor">rentUseFor</param>
		/// <param name="businessLicense">businessLicense</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="contractPhone">contractPhone</param>
		/// <param name="warningTime">warningTime</param>
		/// <param name="inChargeMan">inChargeMan</param>
		/// <param name="topContractID">topContractID</param>
		/// <param name="parentContractID">parentContractID</param>
		/// <param name="isDivideOn">isDivideOn</param>
		/// <param name="contractDevicePercent">contractDevicePercent</param>
		/// <param name="contractBasicRentCost">contractBasicRentCost</param>
		/// <param name="contractDivideSellCost">contractDivideSellCost</param>
		/// <param name="contractType">contractType</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="contractRelateType">contractRelateType</param>
		/// <param name="relationPhoneID">relationPhoneID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateContract(int @iD, int @roomID, string @rentName, string @contractStatus, string @roomLocation, decimal @roomArea, string @roomUseFor, string @roomStatus, string @contractNo, string @contractName, decimal @contractDeposit, int @timeLimit, DateTime @signTime, DateTime @rentStartTime, DateTime @rentEndTime, int @freeDays, DateTime @freeStartTime, DateTime @freeEndTime, DateTime @openTime, DateTime @inTime, DateTime @outTime, decimal @rentPrice, string @rentRange, string @chargeRange, string @sellerProduct, decimal @everyYearUp, string @brandModel, string @contractSummary, string @phoneNumber, string @address, string @customerName, string @iDCardNo, DateTime @deliverTime, string @iDCardAddress, string @rentUseFor, string @businessLicense, DateTime @addTime, string @addMan, string @contractPhone, DateTime @warningTime, string @inChargeMan, int @topContractID, int @parentContractID, bool @isDivideOn, decimal @contractDevicePercent, decimal @contractBasicRentCost, decimal @contractDivideSellCost, int @contractType, int @orderNumberID, int @contractRelateType, int @relationPhoneID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[RentName] nvarchar(50),
	[ContractStatus] nvarchar(50),
	[RoomLocation] nvarchar(500),
	[RoomArea] decimal(18, 2),
	[RoomUseFor] nvarchar(50),
	[RoomStatus] nvarchar(50),
	[ContractNo] nvarchar(200),
	[ContractName] nvarchar(200),
	[ContractDeposit] decimal(18, 2),
	[TimeLimit] int,
	[SignTime] datetime,
	[RentStartTime] datetime,
	[RentEndTime] datetime,
	[FreeDays] int,
	[FreeStartTime] datetime,
	[FreeEndTime] datetime,
	[OpenTime] datetime,
	[InTime] datetime,
	[OutTime] datetime,
	[RentPrice] decimal(18, 2),
	[RentRange] nvarchar(50),
	[ChargeRange] nvarchar(50),
	[SellerProduct] nvarchar(500),
	[EveryYearUp] decimal(18, 2),
	[BrandModel] nvarchar(200),
	[ContractSummary] ntext,
	[PhoneNumber] nvarchar(50),
	[Address] nvarchar(200),
	[CustomerName] nvarchar(50),
	[IDCardNo] nvarchar(50),
	[DeliverTime] datetime,
	[IDCardAddress] nchar(10),
	[RentUseFor] nvarchar(100),
	[BusinessLicense] nvarchar(100),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ContractPhone] nvarchar(100),
	[WarningTime] datetime,
	[InChargeMan] nvarchar(100),
	[TopContractID] int,
	[ParentContractID] int,
	[IsDivideOn] bit,
	[ContractDevicePercent] decimal(18, 4),
	[ContractBasicRentCost] decimal(18, 2),
	[ContractDivideSellCost] decimal(18, 2),
	[ContractType] int,
	[OrderNumberID] int,
	[ContractRelateType] int,
	[RelationPhoneID] int
);

UPDATE [dbo].[Contract] SET 
	[Contract].[RoomID] = @RoomID,
	[Contract].[RentName] = @RentName,
	[Contract].[ContractStatus] = @ContractStatus,
	[Contract].[RoomLocation] = @RoomLocation,
	[Contract].[RoomArea] = @RoomArea,
	[Contract].[RoomUseFor] = @RoomUseFor,
	[Contract].[RoomStatus] = @RoomStatus,
	[Contract].[ContractNo] = @ContractNo,
	[Contract].[ContractName] = @ContractName,
	[Contract].[ContractDeposit] = @ContractDeposit,
	[Contract].[TimeLimit] = @TimeLimit,
	[Contract].[SignTime] = @SignTime,
	[Contract].[RentStartTime] = @RentStartTime,
	[Contract].[RentEndTime] = @RentEndTime,
	[Contract].[FreeDays] = @FreeDays,
	[Contract].[FreeStartTime] = @FreeStartTime,
	[Contract].[FreeEndTime] = @FreeEndTime,
	[Contract].[OpenTime] = @OpenTime,
	[Contract].[InTime] = @InTime,
	[Contract].[OutTime] = @OutTime,
	[Contract].[RentPrice] = @RentPrice,
	[Contract].[RentRange] = @RentRange,
	[Contract].[ChargeRange] = @ChargeRange,
	[Contract].[SellerProduct] = @SellerProduct,
	[Contract].[EveryYearUp] = @EveryYearUp,
	[Contract].[BrandModel] = @BrandModel,
	[Contract].[ContractSummary] = @ContractSummary,
	[Contract].[PhoneNumber] = @PhoneNumber,
	[Contract].[Address] = @Address,
	[Contract].[CustomerName] = @CustomerName,
	[Contract].[IDCardNo] = @IDCardNo,
	[Contract].[DeliverTime] = @DeliverTime,
	[Contract].[IDCardAddress] = @IDCardAddress,
	[Contract].[RentUseFor] = @RentUseFor,
	[Contract].[BusinessLicense] = @BusinessLicense,
	[Contract].[AddTime] = @AddTime,
	[Contract].[AddMan] = @AddMan,
	[Contract].[ContractPhone] = @ContractPhone,
	[Contract].[WarningTime] = @WarningTime,
	[Contract].[InChargeMan] = @InChargeMan,
	[Contract].[TopContractID] = @TopContractID,
	[Contract].[ParentContractID] = @ParentContractID,
	[Contract].[IsDivideOn] = @IsDivideOn,
	[Contract].[ContractDevicePercent] = @ContractDevicePercent,
	[Contract].[ContractBasicRentCost] = @ContractBasicRentCost,
	[Contract].[ContractDivideSellCost] = @ContractDivideSellCost,
	[Contract].[ContractType] = @ContractType,
	[Contract].[OrderNumberID] = @OrderNumberID,
	[Contract].[ContractRelateType] = @ContractRelateType,
	[Contract].[RelationPhoneID] = @RelationPhoneID 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[RentName],
	INSERTED.[ContractStatus],
	INSERTED.[RoomLocation],
	INSERTED.[RoomArea],
	INSERTED.[RoomUseFor],
	INSERTED.[RoomStatus],
	INSERTED.[ContractNo],
	INSERTED.[ContractName],
	INSERTED.[ContractDeposit],
	INSERTED.[TimeLimit],
	INSERTED.[SignTime],
	INSERTED.[RentStartTime],
	INSERTED.[RentEndTime],
	INSERTED.[FreeDays],
	INSERTED.[FreeStartTime],
	INSERTED.[FreeEndTime],
	INSERTED.[OpenTime],
	INSERTED.[InTime],
	INSERTED.[OutTime],
	INSERTED.[RentPrice],
	INSERTED.[RentRange],
	INSERTED.[ChargeRange],
	INSERTED.[SellerProduct],
	INSERTED.[EveryYearUp],
	INSERTED.[BrandModel],
	INSERTED.[ContractSummary],
	INSERTED.[PhoneNumber],
	INSERTED.[Address],
	INSERTED.[CustomerName],
	INSERTED.[IDCardNo],
	INSERTED.[DeliverTime],
	INSERTED.[IDCardAddress],
	INSERTED.[RentUseFor],
	INSERTED.[BusinessLicense],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ContractPhone],
	INSERTED.[WarningTime],
	INSERTED.[InChargeMan],
	INSERTED.[TopContractID],
	INSERTED.[ParentContractID],
	INSERTED.[IsDivideOn],
	INSERTED.[ContractDevicePercent],
	INSERTED.[ContractBasicRentCost],
	INSERTED.[ContractDivideSellCost],
	INSERTED.[ContractType],
	INSERTED.[OrderNumberID],
	INSERTED.[ContractRelateType],
	INSERTED.[RelationPhoneID]
into @table
WHERE 
	[Contract].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[RentName],
	[ContractStatus],
	[RoomLocation],
	[RoomArea],
	[RoomUseFor],
	[RoomStatus],
	[ContractNo],
	[ContractName],
	[ContractDeposit],
	[TimeLimit],
	[SignTime],
	[RentStartTime],
	[RentEndTime],
	[FreeDays],
	[FreeStartTime],
	[FreeEndTime],
	[OpenTime],
	[InTime],
	[OutTime],
	[RentPrice],
	[RentRange],
	[ChargeRange],
	[SellerProduct],
	[EveryYearUp],
	[BrandModel],
	[ContractSummary],
	[PhoneNumber],
	[Address],
	[CustomerName],
	[IDCardNo],
	[DeliverTime],
	[IDCardAddress],
	[RentUseFor],
	[BusinessLicense],
	[AddTime],
	[AddMan],
	[ContractPhone],
	[WarningTime],
	[InChargeMan],
	[TopContractID],
	[ParentContractID],
	[IsDivideOn],
	[ContractDevicePercent],
	[ContractBasicRentCost],
	[ContractDivideSellCost],
	[ContractType],
	[OrderNumberID],
	[ContractRelateType],
	[RelationPhoneID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@RentName", EntityBase.GetDatabaseValue(@rentName)));
			parameters.Add(new SqlParameter("@ContractStatus", EntityBase.GetDatabaseValue(@contractStatus)));
			parameters.Add(new SqlParameter("@RoomLocation", EntityBase.GetDatabaseValue(@roomLocation)));
			parameters.Add(new SqlParameter("@RoomArea", EntityBase.GetDatabaseValue(@roomArea)));
			parameters.Add(new SqlParameter("@RoomUseFor", EntityBase.GetDatabaseValue(@roomUseFor)));
			parameters.Add(new SqlParameter("@RoomStatus", EntityBase.GetDatabaseValue(@roomStatus)));
			parameters.Add(new SqlParameter("@ContractNo", EntityBase.GetDatabaseValue(@contractNo)));
			parameters.Add(new SqlParameter("@ContractName", EntityBase.GetDatabaseValue(@contractName)));
			parameters.Add(new SqlParameter("@ContractDeposit", EntityBase.GetDatabaseValue(@contractDeposit)));
			parameters.Add(new SqlParameter("@TimeLimit", EntityBase.GetDatabaseValue(@timeLimit)));
			parameters.Add(new SqlParameter("@SignTime", EntityBase.GetDatabaseValue(@signTime)));
			parameters.Add(new SqlParameter("@RentStartTime", EntityBase.GetDatabaseValue(@rentStartTime)));
			parameters.Add(new SqlParameter("@RentEndTime", EntityBase.GetDatabaseValue(@rentEndTime)));
			parameters.Add(new SqlParameter("@FreeDays", EntityBase.GetDatabaseValue(@freeDays)));
			parameters.Add(new SqlParameter("@FreeStartTime", EntityBase.GetDatabaseValue(@freeStartTime)));
			parameters.Add(new SqlParameter("@FreeEndTime", EntityBase.GetDatabaseValue(@freeEndTime)));
			parameters.Add(new SqlParameter("@OpenTime", EntityBase.GetDatabaseValue(@openTime)));
			parameters.Add(new SqlParameter("@InTime", EntityBase.GetDatabaseValue(@inTime)));
			parameters.Add(new SqlParameter("@OutTime", EntityBase.GetDatabaseValue(@outTime)));
			parameters.Add(new SqlParameter("@RentPrice", EntityBase.GetDatabaseValue(@rentPrice)));
			parameters.Add(new SqlParameter("@RentRange", EntityBase.GetDatabaseValue(@rentRange)));
			parameters.Add(new SqlParameter("@ChargeRange", EntityBase.GetDatabaseValue(@chargeRange)));
			parameters.Add(new SqlParameter("@SellerProduct", EntityBase.GetDatabaseValue(@sellerProduct)));
			parameters.Add(new SqlParameter("@EveryYearUp", EntityBase.GetDatabaseValue(@everyYearUp)));
			parameters.Add(new SqlParameter("@BrandModel", EntityBase.GetDatabaseValue(@brandModel)));
			parameters.Add(new SqlParameter("@ContractSummary", EntityBase.GetDatabaseValue(@contractSummary)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@Address", EntityBase.GetDatabaseValue(@address)));
			parameters.Add(new SqlParameter("@CustomerName", EntityBase.GetDatabaseValue(@customerName)));
			parameters.Add(new SqlParameter("@IDCardNo", EntityBase.GetDatabaseValue(@iDCardNo)));
			parameters.Add(new SqlParameter("@DeliverTime", EntityBase.GetDatabaseValue(@deliverTime)));
			parameters.Add(new SqlParameter("@IDCardAddress", EntityBase.GetDatabaseValue(@iDCardAddress)));
			parameters.Add(new SqlParameter("@RentUseFor", EntityBase.GetDatabaseValue(@rentUseFor)));
			parameters.Add(new SqlParameter("@BusinessLicense", EntityBase.GetDatabaseValue(@businessLicense)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ContractPhone", EntityBase.GetDatabaseValue(@contractPhone)));
			parameters.Add(new SqlParameter("@WarningTime", EntityBase.GetDatabaseValue(@warningTime)));
			parameters.Add(new SqlParameter("@InChargeMan", EntityBase.GetDatabaseValue(@inChargeMan)));
			parameters.Add(new SqlParameter("@TopContractID", EntityBase.GetDatabaseValue(@topContractID)));
			parameters.Add(new SqlParameter("@ParentContractID", EntityBase.GetDatabaseValue(@parentContractID)));
			parameters.Add(new SqlParameter("@IsDivideOn", @isDivideOn));
			parameters.Add(new SqlParameter("@ContractDevicePercent", EntityBase.GetDatabaseValue(@contractDevicePercent)));
			parameters.Add(new SqlParameter("@ContractBasicRentCost", EntityBase.GetDatabaseValue(@contractBasicRentCost)));
			parameters.Add(new SqlParameter("@ContractDivideSellCost", EntityBase.GetDatabaseValue(@contractDivideSellCost)));
			parameters.Add(new SqlParameter("@ContractType", EntityBase.GetDatabaseValue(@contractType)));
			parameters.Add(new SqlParameter("@OrderNumberID", EntityBase.GetDatabaseValue(@orderNumberID)));
			parameters.Add(new SqlParameter("@ContractRelateType", EntityBase.GetDatabaseValue(@contractRelateType)));
			parameters.Add(new SqlParameter("@RelationPhoneID", EntityBase.GetDatabaseValue(@relationPhoneID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Contract from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteContract(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteContract(@iD, helper);
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
		/// Deletes a Contract from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteContract(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Contract]
WHERE 
	[Contract].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Contract object.
		/// </summary>
		/// <returns>The newly created Contract object.</returns>
		public static Contract CreateContract()
		{
			return InitializeNew<Contract>();
		}
		
		/// <summary>
		/// Retrieve information for a Contract by a Contract's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Contract</returns>
		public static Contract GetContract(int @iD)
		{
			string commandText = @"
SELECT 
" + Contract.SelectFieldList + @"
FROM [dbo].[Contract] 
WHERE 
	[Contract].[ID] = @ID " + Contract.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Contract by a Contract's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Contract</returns>
		public static Contract GetContract(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Contract.SelectFieldList + @"
FROM [dbo].[Contract] 
WHERE 
	[Contract].[ID] = @ID " + Contract.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Contract objects.
		/// </summary>
		/// <returns>The retrieved collection of Contract objects.</returns>
		public static EntityList<Contract> GetContracts()
		{
			string commandText = @"
SELECT " + Contract.SelectFieldList + "FROM [dbo].[Contract] " + Contract.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Contract>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Contract objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract objects.</returns>
        public static EntityList<Contract> GetContracts(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract>(SelectFieldList, "FROM [dbo].[Contract]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Contract objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract objects.</returns>
        public static EntityList<Contract> GetContracts(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract>(SelectFieldList, "FROM [dbo].[Contract]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Contract objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Contract objects.</returns>
		protected static EntityList<Contract> GetContracts(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContracts(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Contract objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract objects.</returns>
		protected static EntityList<Contract> GetContracts(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContracts(string.Empty, where, parameters, Contract.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract objects.</returns>
		protected static EntityList<Contract> GetContracts(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContracts(prefix, where, parameters, Contract.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract objects.</returns>
		protected static EntityList<Contract> GetContracts(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContracts(string.Empty, where, parameters, Contract.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract objects.</returns>
		protected static EntityList<Contract> GetContracts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContracts(prefix, where, parameters, Contract.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Contract objects.</returns>
		protected static EntityList<Contract> GetContracts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Contract.SelectFieldList + "FROM [dbo].[Contract] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Contract>(reader);
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
        protected static EntityList<Contract> GetContracts(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract>(SelectFieldList, "FROM [dbo].[Contract] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Contract objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContractCount()
        {
            return GetContractCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Contract objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContractCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Contract] " + where;

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
		public static partial class Contract_Properties
		{
			public const string ID = "ID";
			public const string RoomID = "RoomID";
			public const string RentName = "RentName";
			public const string ContractStatus = "ContractStatus";
			public const string RoomLocation = "RoomLocation";
			public const string RoomArea = "RoomArea";
			public const string RoomUseFor = "RoomUseFor";
			public const string RoomStatus = "RoomStatus";
			public const string ContractNo = "ContractNo";
			public const string ContractName = "ContractName";
			public const string ContractDeposit = "ContractDeposit";
			public const string TimeLimit = "TimeLimit";
			public const string SignTime = "SignTime";
			public const string RentStartTime = "RentStartTime";
			public const string RentEndTime = "RentEndTime";
			public const string FreeDays = "FreeDays";
			public const string FreeStartTime = "FreeStartTime";
			public const string FreeEndTime = "FreeEndTime";
			public const string OpenTime = "OpenTime";
			public const string InTime = "InTime";
			public const string OutTime = "OutTime";
			public const string RentPrice = "RentPrice";
			public const string RentRange = "RentRange";
			public const string ChargeRange = "ChargeRange";
			public const string SellerProduct = "SellerProduct";
			public const string EveryYearUp = "EveryYearUp";
			public const string BrandModel = "BrandModel";
			public const string ContractSummary = "ContractSummary";
			public const string PhoneNumber = "PhoneNumber";
			public const string Address = "Address";
			public const string CustomerName = "CustomerName";
			public const string IDCardNo = "IDCardNo";
			public const string DeliverTime = "DeliverTime";
			public const string IDCardAddress = "IDCardAddress";
			public const string RentUseFor = "RentUseFor";
			public const string BusinessLicense = "BusinessLicense";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string ContractPhone = "ContractPhone";
			public const string WarningTime = "WarningTime";
			public const string InChargeMan = "InChargeMan";
			public const string TopContractID = "TopContractID";
			public const string ParentContractID = "ParentContractID";
			public const string IsDivideOn = "IsDivideOn";
			public const string ContractDevicePercent = "ContractDevicePercent";
			public const string ContractBasicRentCost = "ContractBasicRentCost";
			public const string ContractDivideSellCost = "ContractDivideSellCost";
			public const string ContractType = "ContractType";
			public const string OrderNumberID = "OrderNumberID";
			public const string ContractRelateType = "ContractRelateType";
			public const string RelationPhoneID = "RelationPhoneID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"RentName" , "string:"},
    			 {"ContractStatus" , "string:"},
    			 {"RoomLocation" , "string:"},
    			 {"RoomArea" , "decimal:"},
    			 {"RoomUseFor" , "string:"},
    			 {"RoomStatus" , "string:"},
    			 {"ContractNo" , "string:"},
    			 {"ContractName" , "string:"},
    			 {"ContractDeposit" , "decimal:"},
    			 {"TimeLimit" , "int:"},
    			 {"SignTime" , "DateTime:"},
    			 {"RentStartTime" , "DateTime:"},
    			 {"RentEndTime" , "DateTime:"},
    			 {"FreeDays" , "int:"},
    			 {"FreeStartTime" , "DateTime:"},
    			 {"FreeEndTime" , "DateTime:"},
    			 {"OpenTime" , "DateTime:"},
    			 {"InTime" , "DateTime:"},
    			 {"OutTime" , "DateTime:"},
    			 {"RentPrice" , "decimal:"},
    			 {"RentRange" , "string:"},
    			 {"ChargeRange" , "string:"},
    			 {"SellerProduct" , "string:"},
    			 {"EveryYearUp" , "decimal:"},
    			 {"BrandModel" , "string:"},
    			 {"ContractSummary" , "string:"},
    			 {"PhoneNumber" , "string:"},
    			 {"Address" , "string:"},
    			 {"CustomerName" , "string:"},
    			 {"IDCardNo" , "string:"},
    			 {"DeliverTime" , "DateTime:"},
    			 {"IDCardAddress" , "string:"},
    			 {"RentUseFor" , "string:"},
    			 {"BusinessLicense" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"ContractPhone" , "string:"},
    			 {"WarningTime" , "DateTime:"},
    			 {"InChargeMan" , "string:"},
    			 {"TopContractID" , "int:"},
    			 {"ParentContractID" , "int:"},
    			 {"IsDivideOn" , "bool:"},
    			 {"ContractDevicePercent" , "decimal:"},
    			 {"ContractBasicRentCost" , "decimal:"},
    			 {"ContractDivideSellCost" , "decimal:"},
    			 {"ContractType" , "int:1-租赁合同 2-物业合同 3-多方合同"},
    			 {"OrderNumberID" , "int:"},
    			 {"ContractRelateType" , "int:1-续租 2-转租"},
    			 {"RelationPhoneID" , "int:"},
            };
		}
		#endregion
	}
}
