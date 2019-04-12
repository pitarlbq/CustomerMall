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
	/// This object represents the properties and methods of a RoomBasic.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class RoomBasic 
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
		private string _roomOwner = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomOwner
		{
			[DebuggerStepThrough()]
			get { return this._roomOwner; }
			set 
			{
				if (this._roomOwner != value) 
				{
					this._roomOwner = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomOwner");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _ownerPhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OwnerPhone
		{
			[DebuggerStepThrough()]
			get { return this._ownerPhone; }
			set 
			{
				if (this._ownerPhone != value) 
				{
					this._ownerPhone = value;
					this.IsDirty = true;	
					OnPropertyChanged("OwnerPhone");
				}
			}
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
			set 
			{
				if (this._buildingArea != value) 
				{
					this._buildingArea = value;
					this.IsDirty = true;	
					OnPropertyChanged("BuildingArea");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomState = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomState
		{
			[DebuggerStepThrough()]
			get { return this._roomState; }
			set 
			{
				if (this._roomState != value) 
				{
					this._roomState = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomState");
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
		private DateTime _paymentTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime PaymentTime
		{
			[DebuggerStepThrough()]
			get { return this._paymentTime; }
			set 
			{
				if (this._paymentTime != value) 
				{
					this._paymentTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("PaymentTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _buildingNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BuildingNumber
		{
			[DebuggerStepThrough()]
			get { return this._buildingNumber; }
			set 
			{
				if (this._buildingNumber != value) 
				{
					this._buildingNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("BuildingNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomType
		{
			[DebuggerStepThrough()]
			get { return this._roomType; }
			set 
			{
				if (this._roomType != value) 
				{
					this._roomType = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomLayout = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomLayout
		{
			[DebuggerStepThrough()]
			get { return this._roomLayout; }
			set 
			{
				if (this._roomLayout != value) 
				{
					this._roomLayout = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomLayout");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _ownerIDCard = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OwnerIDCard
		{
			[DebuggerStepThrough()]
			get { return this._ownerIDCard; }
			set 
			{
				if (this._ownerIDCard != value) 
				{
					this._ownerIDCard = value;
					this.IsDirty = true;	
					OnPropertyChanged("OwnerIDCard");
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
		private string _rentPhoneNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RentPhoneNumber
		{
			[DebuggerStepThrough()]
			get { return this._rentPhoneNumber; }
			set 
			{
				if (this._rentPhoneNumber != value) 
				{
					this._rentPhoneNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("RentPhoneNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _rentIDCard = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RentIDCard
		{
			[DebuggerStepThrough()]
			get { return this._rentIDCard; }
			set 
			{
				if (this._rentIDCard != value) 
				{
					this._rentIDCard = value;
					this.IsDirty = true;	
					OnPropertyChanged("RentIDCard");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _historyBill = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal HistoryBill
		{
			[DebuggerStepThrough()]
			get { return this._historyBill; }
			set 
			{
				if (this._historyBill != value) 
				{
					this._historyBill = value;
					this.IsDirty = true;	
					OnPropertyChanged("HistoryBill");
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
			set 
			{
				if (this._roomProperty != value) 
				{
					this._roomProperty = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomProperty");
				}
			}
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
			set 
			{
				if (this._contractArea != value) 
				{
					this._contractArea = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractArea");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _moveInTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime MoveInTime
		{
			[DebuggerStepThrough()]
			get { return this._moveInTime; }
			set 
			{
				if (this._moveInTime != value) 
				{
					this._moveInTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("MoveInTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _zxStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ZxStartTime
		{
			[DebuggerStepThrough()]
			get { return this._zxStartTime; }
			set 
			{
				if (this._zxStartTime != value) 
				{
					this._zxStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ZxStartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _zxEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ZxEndTime
		{
			[DebuggerStepThrough()]
			get { return this._zxEndTime; }
			set 
			{
				if (this._zxEndTime != value) 
				{
					this._zxEndTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ZxEndTime");
				}
			}
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
			set 
			{
				if (this._buildOutArea != value) 
				{
					this._buildOutArea = value;
					this.IsDirty = true;	
					OnPropertyChanged("BuildOutArea");
				}
			}
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
			set 
			{
				if (this._buildInArea != value) 
				{
					this._buildInArea = value;
					this.IsDirty = true;	
					OnPropertyChanged("BuildInArea");
				}
			}
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
			set 
			{
				if (this._gonTanArea != value) 
				{
					this._gonTanArea = value;
					this.IsDirty = true;	
					OnPropertyChanged("GonTanArea");
				}
			}
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
			set 
			{
				if (this._chanQuanArea != value) 
				{
					this._chanQuanArea = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChanQuanArea");
				}
			}
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
			set 
			{
				if (this._useArea != value) 
				{
					this._useArea = value;
					this.IsDirty = true;	
					OnPropertyChanged("UseArea");
				}
			}
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
			set 
			{
				if (this._peiTaoArea != value) 
				{
					this._peiTaoArea = value;
					this.IsDirty = true;	
					OnPropertyChanged("PeiTaoArea");
				}
			}
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
			set 
			{
				if (this._functionCoefficient != value) 
				{
					this._functionCoefficient = value;
					this.IsDirty = true;	
					OnPropertyChanged("FunctionCoefficient");
				}
			}
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
			set 
			{
				if (this._fenTanCoefficient != value) 
				{
					this._fenTanCoefficient = value;
					this.IsDirty = true;	
					OnPropertyChanged("FenTanCoefficient");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chanQuanNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChanQuanNo
		{
			[DebuggerStepThrough()]
			get { return this._chanQuanNo; }
			set 
			{
				if (this._chanQuanNo != value) 
				{
					this._chanQuanNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChanQuanNo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _certificateTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime CertificateTime
		{
			[DebuggerStepThrough()]
			get { return this._certificateTime; }
			set 
			{
				if (this._certificateTime != value) 
				{
					this._certificateTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("CertificateTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _customOne = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CustomOne
		{
			[DebuggerStepThrough()]
			get { return this._customOne; }
			set 
			{
				if (this._customOne != value) 
				{
					this._customOne = value;
					this.IsDirty = true;	
					OnPropertyChanged("CustomOne");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _customTwo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CustomTwo
		{
			[DebuggerStepThrough()]
			get { return this._customTwo; }
			set 
			{
				if (this._customTwo != value) 
				{
					this._customTwo = value;
					this.IsDirty = true;	
					OnPropertyChanged("CustomTwo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _customThree = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CustomThree
		{
			[DebuggerStepThrough()]
			get { return this._customThree; }
			set 
			{
				if (this._customThree != value) 
				{
					this._customThree = value;
					this.IsDirty = true;	
					OnPropertyChanged("CustomThree");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _customFour = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CustomFour
		{
			[DebuggerStepThrough()]
			get { return this._customFour; }
			set 
			{
				if (this._customFour != value) 
				{
					this._customFour = value;
					this.IsDirty = true;	
					OnPropertyChanged("CustomFour");
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
		private bool _isLocked = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsLocked
		{
			[DebuggerStepThrough()]
			get { return this._isLocked; }
			set 
			{
				if (this._isLocked != value) 
				{
					this._isLocked = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsLocked");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _roomStateID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RoomStateID
		{
			[DebuggerStepThrough()]
			get { return this._roomStateID; }
			set 
			{
				if (this._roomStateID != value) 
				{
					this._roomStateID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomStateID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _roomTypeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RoomTypeID
		{
			[DebuggerStepThrough()]
			get { return this._roomTypeID; }
			set 
			{
				if (this._roomTypeID != value) 
				{
					this._roomTypeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomTypeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _roomPropertyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RoomPropertyID
		{
			[DebuggerStepThrough()]
			get { return this._roomPropertyID; }
			set 
			{
				if (this._roomPropertyID != value) 
				{
					this._roomPropertyID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomPropertyID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chequeTaxpayerNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChequeTaxpayerNumber
		{
			[DebuggerStepThrough()]
			get { return this._chequeTaxpayerNumber; }
			set 
			{
				if (this._chequeTaxpayerNumber != value) 
				{
					this._chequeTaxpayerNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChequeTaxpayerNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chequeBankNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChequeBankNo
		{
			[DebuggerStepThrough()]
			get { return this._chequeBankNo; }
			set 
			{
				if (this._chequeBankNo != value) 
				{
					this._chequeBankNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChequeBankNo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chequeBankName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChequeBankName
		{
			[DebuggerStepThrough()]
			get { return this._chequeBankName; }
			set 
			{
				if (this._chequeBankName != value) 
				{
					this._chequeBankName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChequeBankName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chequeEmailAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChequeEmailAddress
		{
			[DebuggerStepThrough()]
			get { return this._chequeEmailAddress; }
			set 
			{
				if (this._chequeEmailAddress != value) 
				{
					this._chequeEmailAddress = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChequeEmailAddress");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chequeCompanyName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChequeCompanyName
		{
			[DebuggerStepThrough()]
			get { return this._chequeCompanyName; }
			set 
			{
				if (this._chequeCompanyName != value) 
				{
					this._chequeCompanyName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChequeCompanyName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chequeAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChequeAddress
		{
			[DebuggerStepThrough()]
			get { return this._chequeAddress; }
			set 
			{
				if (this._chequeAddress != value) 
				{
					this._chequeAddress = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChequeAddress");
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
	[RoomOwner] nvarchar(50),
	[OwnerPhone] nvarchar(50),
	[BuildingArea] decimal(18, 3),
	[RoomState] nvarchar(100),
	[AddTime] datetime,
	[PaymentTime] datetime,
	[BuildingNumber] nvarchar(50),
	[RoomType] nvarchar(50),
	[RoomLayout] nvarchar(50),
	[OwnerIDCard] nvarchar(50),
	[RentName] nvarchar(50),
	[RentPhoneNumber] nvarchar(50),
	[RentIDCard] nvarchar(50),
	[HistoryBill] decimal(18, 2),
	[EndTime] datetime,
	[RoomProperty] nvarchar(100),
	[ContractArea] decimal(18, 3),
	[MoveInTime] datetime,
	[ZxStartTime] datetime,
	[ZxEndTime] datetime,
	[BuildOutArea] decimal(18, 3),
	[BuildInArea] decimal(18, 3),
	[GonTanArea] decimal(18, 3),
	[ChanQuanArea] decimal(18, 3),
	[UseArea] decimal(18, 3),
	[PeiTaoArea] decimal(18, 3),
	[FunctionCoefficient] decimal(18, 2),
	[FenTanCoefficient] decimal(18, 2),
	[ChanQuanNo] nvarchar(200),
	[CertificateTime] datetime,
	[CustomOne] nvarchar(100),
	[CustomTwo] nvarchar(100),
	[CustomThree] nvarchar(100),
	[CustomFour] nvarchar(100),
	[Remark] nvarchar(100),
	[IsLocked] bit,
	[RoomStateID] int,
	[RoomTypeID] int,
	[RoomPropertyID] int,
	[ChequeTaxpayerNumber] nvarchar(200),
	[ChequeBankNo] nvarchar(200),
	[ChequeBankName] nvarchar(200),
	[ChequeEmailAddress] nvarchar(200),
	[ChequeCompanyName] nvarchar(200),
	[ChequeAddress] nvarchar(200)
);

INSERT INTO [dbo].[RoomBasic] (
	[RoomBasic].[RoomID],
	[RoomBasic].[RoomOwner],
	[RoomBasic].[OwnerPhone],
	[RoomBasic].[BuildingArea],
	[RoomBasic].[RoomState],
	[RoomBasic].[AddTime],
	[RoomBasic].[PaymentTime],
	[RoomBasic].[BuildingNumber],
	[RoomBasic].[RoomType],
	[RoomBasic].[RoomLayout],
	[RoomBasic].[OwnerIDCard],
	[RoomBasic].[RentName],
	[RoomBasic].[RentPhoneNumber],
	[RoomBasic].[RentIDCard],
	[RoomBasic].[HistoryBill],
	[RoomBasic].[EndTime],
	[RoomBasic].[RoomProperty],
	[RoomBasic].[ContractArea],
	[RoomBasic].[MoveInTime],
	[RoomBasic].[ZxStartTime],
	[RoomBasic].[ZxEndTime],
	[RoomBasic].[BuildOutArea],
	[RoomBasic].[BuildInArea],
	[RoomBasic].[GonTanArea],
	[RoomBasic].[ChanQuanArea],
	[RoomBasic].[UseArea],
	[RoomBasic].[PeiTaoArea],
	[RoomBasic].[FunctionCoefficient],
	[RoomBasic].[FenTanCoefficient],
	[RoomBasic].[ChanQuanNo],
	[RoomBasic].[CertificateTime],
	[RoomBasic].[CustomOne],
	[RoomBasic].[CustomTwo],
	[RoomBasic].[CustomThree],
	[RoomBasic].[CustomFour],
	[RoomBasic].[Remark],
	[RoomBasic].[IsLocked],
	[RoomBasic].[RoomStateID],
	[RoomBasic].[RoomTypeID],
	[RoomBasic].[RoomPropertyID],
	[RoomBasic].[ChequeTaxpayerNumber],
	[RoomBasic].[ChequeBankNo],
	[RoomBasic].[ChequeBankName],
	[RoomBasic].[ChequeEmailAddress],
	[RoomBasic].[ChequeCompanyName],
	[RoomBasic].[ChequeAddress]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[RoomOwner],
	INSERTED.[OwnerPhone],
	INSERTED.[BuildingArea],
	INSERTED.[RoomState],
	INSERTED.[AddTime],
	INSERTED.[PaymentTime],
	INSERTED.[BuildingNumber],
	INSERTED.[RoomType],
	INSERTED.[RoomLayout],
	INSERTED.[OwnerIDCard],
	INSERTED.[RentName],
	INSERTED.[RentPhoneNumber],
	INSERTED.[RentIDCard],
	INSERTED.[HistoryBill],
	INSERTED.[EndTime],
	INSERTED.[RoomProperty],
	INSERTED.[ContractArea],
	INSERTED.[MoveInTime],
	INSERTED.[ZxStartTime],
	INSERTED.[ZxEndTime],
	INSERTED.[BuildOutArea],
	INSERTED.[BuildInArea],
	INSERTED.[GonTanArea],
	INSERTED.[ChanQuanArea],
	INSERTED.[UseArea],
	INSERTED.[PeiTaoArea],
	INSERTED.[FunctionCoefficient],
	INSERTED.[FenTanCoefficient],
	INSERTED.[ChanQuanNo],
	INSERTED.[CertificateTime],
	INSERTED.[CustomOne],
	INSERTED.[CustomTwo],
	INSERTED.[CustomThree],
	INSERTED.[CustomFour],
	INSERTED.[Remark],
	INSERTED.[IsLocked],
	INSERTED.[RoomStateID],
	INSERTED.[RoomTypeID],
	INSERTED.[RoomPropertyID],
	INSERTED.[ChequeTaxpayerNumber],
	INSERTED.[ChequeBankNo],
	INSERTED.[ChequeBankName],
	INSERTED.[ChequeEmailAddress],
	INSERTED.[ChequeCompanyName],
	INSERTED.[ChequeAddress]
into @table
VALUES ( 
	@RoomID,
	@RoomOwner,
	@OwnerPhone,
	@BuildingArea,
	@RoomState,
	@AddTime,
	@PaymentTime,
	@BuildingNumber,
	@RoomType,
	@RoomLayout,
	@OwnerIDCard,
	@RentName,
	@RentPhoneNumber,
	@RentIDCard,
	@HistoryBill,
	@EndTime,
	@RoomProperty,
	@ContractArea,
	@MoveInTime,
	@ZxStartTime,
	@ZxEndTime,
	@BuildOutArea,
	@BuildInArea,
	@GonTanArea,
	@ChanQuanArea,
	@UseArea,
	@PeiTaoArea,
	@FunctionCoefficient,
	@FenTanCoefficient,
	@ChanQuanNo,
	@CertificateTime,
	@CustomOne,
	@CustomTwo,
	@CustomThree,
	@CustomFour,
	@Remark,
	@IsLocked,
	@RoomStateID,
	@RoomTypeID,
	@RoomPropertyID,
	@ChequeTaxpayerNumber,
	@ChequeBankNo,
	@ChequeBankName,
	@ChequeEmailAddress,
	@ChequeCompanyName,
	@ChequeAddress 
); 

SELECT 
	[ID],
	[RoomID],
	[RoomOwner],
	[OwnerPhone],
	[BuildingArea],
	[RoomState],
	[AddTime],
	[PaymentTime],
	[BuildingNumber],
	[RoomType],
	[RoomLayout],
	[OwnerIDCard],
	[RentName],
	[RentPhoneNumber],
	[RentIDCard],
	[HistoryBill],
	[EndTime],
	[RoomProperty],
	[ContractArea],
	[MoveInTime],
	[ZxStartTime],
	[ZxEndTime],
	[BuildOutArea],
	[BuildInArea],
	[GonTanArea],
	[ChanQuanArea],
	[UseArea],
	[PeiTaoArea],
	[FunctionCoefficient],
	[FenTanCoefficient],
	[ChanQuanNo],
	[CertificateTime],
	[CustomOne],
	[CustomTwo],
	[CustomThree],
	[CustomFour],
	[Remark],
	[IsLocked],
	[RoomStateID],
	[RoomTypeID],
	[RoomPropertyID],
	[ChequeTaxpayerNumber],
	[ChequeBankNo],
	[ChequeBankName],
	[ChequeEmailAddress],
	[ChequeCompanyName],
	[ChequeAddress] 
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
	[RoomOwner] nvarchar(50),
	[OwnerPhone] nvarchar(50),
	[BuildingArea] decimal(18, 3),
	[RoomState] nvarchar(100),
	[AddTime] datetime,
	[PaymentTime] datetime,
	[BuildingNumber] nvarchar(50),
	[RoomType] nvarchar(50),
	[RoomLayout] nvarchar(50),
	[OwnerIDCard] nvarchar(50),
	[RentName] nvarchar(50),
	[RentPhoneNumber] nvarchar(50),
	[RentIDCard] nvarchar(50),
	[HistoryBill] decimal(18, 2),
	[EndTime] datetime,
	[RoomProperty] nvarchar(100),
	[ContractArea] decimal(18, 3),
	[MoveInTime] datetime,
	[ZxStartTime] datetime,
	[ZxEndTime] datetime,
	[BuildOutArea] decimal(18, 3),
	[BuildInArea] decimal(18, 3),
	[GonTanArea] decimal(18, 3),
	[ChanQuanArea] decimal(18, 3),
	[UseArea] decimal(18, 3),
	[PeiTaoArea] decimal(18, 3),
	[FunctionCoefficient] decimal(18, 2),
	[FenTanCoefficient] decimal(18, 2),
	[ChanQuanNo] nvarchar(200),
	[CertificateTime] datetime,
	[CustomOne] nvarchar(100),
	[CustomTwo] nvarchar(100),
	[CustomThree] nvarchar(100),
	[CustomFour] nvarchar(100),
	[Remark] nvarchar(100),
	[IsLocked] bit,
	[RoomStateID] int,
	[RoomTypeID] int,
	[RoomPropertyID] int,
	[ChequeTaxpayerNumber] nvarchar(200),
	[ChequeBankNo] nvarchar(200),
	[ChequeBankName] nvarchar(200),
	[ChequeEmailAddress] nvarchar(200),
	[ChequeCompanyName] nvarchar(200),
	[ChequeAddress] nvarchar(200)
);

UPDATE [dbo].[RoomBasic] SET 
	[RoomBasic].[RoomID] = @RoomID,
	[RoomBasic].[RoomOwner] = @RoomOwner,
	[RoomBasic].[OwnerPhone] = @OwnerPhone,
	[RoomBasic].[BuildingArea] = @BuildingArea,
	[RoomBasic].[RoomState] = @RoomState,
	[RoomBasic].[AddTime] = @AddTime,
	[RoomBasic].[PaymentTime] = @PaymentTime,
	[RoomBasic].[BuildingNumber] = @BuildingNumber,
	[RoomBasic].[RoomType] = @RoomType,
	[RoomBasic].[RoomLayout] = @RoomLayout,
	[RoomBasic].[OwnerIDCard] = @OwnerIDCard,
	[RoomBasic].[RentName] = @RentName,
	[RoomBasic].[RentPhoneNumber] = @RentPhoneNumber,
	[RoomBasic].[RentIDCard] = @RentIDCard,
	[RoomBasic].[HistoryBill] = @HistoryBill,
	[RoomBasic].[EndTime] = @EndTime,
	[RoomBasic].[RoomProperty] = @RoomProperty,
	[RoomBasic].[ContractArea] = @ContractArea,
	[RoomBasic].[MoveInTime] = @MoveInTime,
	[RoomBasic].[ZxStartTime] = @ZxStartTime,
	[RoomBasic].[ZxEndTime] = @ZxEndTime,
	[RoomBasic].[BuildOutArea] = @BuildOutArea,
	[RoomBasic].[BuildInArea] = @BuildInArea,
	[RoomBasic].[GonTanArea] = @GonTanArea,
	[RoomBasic].[ChanQuanArea] = @ChanQuanArea,
	[RoomBasic].[UseArea] = @UseArea,
	[RoomBasic].[PeiTaoArea] = @PeiTaoArea,
	[RoomBasic].[FunctionCoefficient] = @FunctionCoefficient,
	[RoomBasic].[FenTanCoefficient] = @FenTanCoefficient,
	[RoomBasic].[ChanQuanNo] = @ChanQuanNo,
	[RoomBasic].[CertificateTime] = @CertificateTime,
	[RoomBasic].[CustomOne] = @CustomOne,
	[RoomBasic].[CustomTwo] = @CustomTwo,
	[RoomBasic].[CustomThree] = @CustomThree,
	[RoomBasic].[CustomFour] = @CustomFour,
	[RoomBasic].[Remark] = @Remark,
	[RoomBasic].[IsLocked] = @IsLocked,
	[RoomBasic].[RoomStateID] = @RoomStateID,
	[RoomBasic].[RoomTypeID] = @RoomTypeID,
	[RoomBasic].[RoomPropertyID] = @RoomPropertyID,
	[RoomBasic].[ChequeTaxpayerNumber] = @ChequeTaxpayerNumber,
	[RoomBasic].[ChequeBankNo] = @ChequeBankNo,
	[RoomBasic].[ChequeBankName] = @ChequeBankName,
	[RoomBasic].[ChequeEmailAddress] = @ChequeEmailAddress,
	[RoomBasic].[ChequeCompanyName] = @ChequeCompanyName,
	[RoomBasic].[ChequeAddress] = @ChequeAddress 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[RoomOwner],
	INSERTED.[OwnerPhone],
	INSERTED.[BuildingArea],
	INSERTED.[RoomState],
	INSERTED.[AddTime],
	INSERTED.[PaymentTime],
	INSERTED.[BuildingNumber],
	INSERTED.[RoomType],
	INSERTED.[RoomLayout],
	INSERTED.[OwnerIDCard],
	INSERTED.[RentName],
	INSERTED.[RentPhoneNumber],
	INSERTED.[RentIDCard],
	INSERTED.[HistoryBill],
	INSERTED.[EndTime],
	INSERTED.[RoomProperty],
	INSERTED.[ContractArea],
	INSERTED.[MoveInTime],
	INSERTED.[ZxStartTime],
	INSERTED.[ZxEndTime],
	INSERTED.[BuildOutArea],
	INSERTED.[BuildInArea],
	INSERTED.[GonTanArea],
	INSERTED.[ChanQuanArea],
	INSERTED.[UseArea],
	INSERTED.[PeiTaoArea],
	INSERTED.[FunctionCoefficient],
	INSERTED.[FenTanCoefficient],
	INSERTED.[ChanQuanNo],
	INSERTED.[CertificateTime],
	INSERTED.[CustomOne],
	INSERTED.[CustomTwo],
	INSERTED.[CustomThree],
	INSERTED.[CustomFour],
	INSERTED.[Remark],
	INSERTED.[IsLocked],
	INSERTED.[RoomStateID],
	INSERTED.[RoomTypeID],
	INSERTED.[RoomPropertyID],
	INSERTED.[ChequeTaxpayerNumber],
	INSERTED.[ChequeBankNo],
	INSERTED.[ChequeBankName],
	INSERTED.[ChequeEmailAddress],
	INSERTED.[ChequeCompanyName],
	INSERTED.[ChequeAddress]
into @table
WHERE 
	[RoomBasic].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[RoomOwner],
	[OwnerPhone],
	[BuildingArea],
	[RoomState],
	[AddTime],
	[PaymentTime],
	[BuildingNumber],
	[RoomType],
	[RoomLayout],
	[OwnerIDCard],
	[RentName],
	[RentPhoneNumber],
	[RentIDCard],
	[HistoryBill],
	[EndTime],
	[RoomProperty],
	[ContractArea],
	[MoveInTime],
	[ZxStartTime],
	[ZxEndTime],
	[BuildOutArea],
	[BuildInArea],
	[GonTanArea],
	[ChanQuanArea],
	[UseArea],
	[PeiTaoArea],
	[FunctionCoefficient],
	[FenTanCoefficient],
	[ChanQuanNo],
	[CertificateTime],
	[CustomOne],
	[CustomTwo],
	[CustomThree],
	[CustomFour],
	[Remark],
	[IsLocked],
	[RoomStateID],
	[RoomTypeID],
	[RoomPropertyID],
	[ChequeTaxpayerNumber],
	[ChequeBankNo],
	[ChequeBankName],
	[ChequeEmailAddress],
	[ChequeCompanyName],
	[ChequeAddress] 
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
DELETE FROM [dbo].[RoomBasic]
WHERE 
	[RoomBasic].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public RoomBasic() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetRoomBasic(this.ID));
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
	[RoomBasic].[ID],
	[RoomBasic].[RoomID],
	[RoomBasic].[RoomOwner],
	[RoomBasic].[OwnerPhone],
	[RoomBasic].[BuildingArea],
	[RoomBasic].[RoomState],
	[RoomBasic].[AddTime],
	[RoomBasic].[PaymentTime],
	[RoomBasic].[BuildingNumber],
	[RoomBasic].[RoomType],
	[RoomBasic].[RoomLayout],
	[RoomBasic].[OwnerIDCard],
	[RoomBasic].[RentName],
	[RoomBasic].[RentPhoneNumber],
	[RoomBasic].[RentIDCard],
	[RoomBasic].[HistoryBill],
	[RoomBasic].[EndTime],
	[RoomBasic].[RoomProperty],
	[RoomBasic].[ContractArea],
	[RoomBasic].[MoveInTime],
	[RoomBasic].[ZxStartTime],
	[RoomBasic].[ZxEndTime],
	[RoomBasic].[BuildOutArea],
	[RoomBasic].[BuildInArea],
	[RoomBasic].[GonTanArea],
	[RoomBasic].[ChanQuanArea],
	[RoomBasic].[UseArea],
	[RoomBasic].[PeiTaoArea],
	[RoomBasic].[FunctionCoefficient],
	[RoomBasic].[FenTanCoefficient],
	[RoomBasic].[ChanQuanNo],
	[RoomBasic].[CertificateTime],
	[RoomBasic].[CustomOne],
	[RoomBasic].[CustomTwo],
	[RoomBasic].[CustomThree],
	[RoomBasic].[CustomFour],
	[RoomBasic].[Remark],
	[RoomBasic].[IsLocked],
	[RoomBasic].[RoomStateID],
	[RoomBasic].[RoomTypeID],
	[RoomBasic].[RoomPropertyID],
	[RoomBasic].[ChequeTaxpayerNumber],
	[RoomBasic].[ChequeBankNo],
	[RoomBasic].[ChequeBankName],
	[RoomBasic].[ChequeEmailAddress],
	[RoomBasic].[ChequeCompanyName],
	[RoomBasic].[ChequeAddress]
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
                return "RoomBasic";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a RoomBasic into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="roomOwner">roomOwner</param>
		/// <param name="ownerPhone">ownerPhone</param>
		/// <param name="buildingArea">buildingArea</param>
		/// <param name="roomState">roomState</param>
		/// <param name="addTime">addTime</param>
		/// <param name="paymentTime">paymentTime</param>
		/// <param name="buildingNumber">buildingNumber</param>
		/// <param name="roomType">roomType</param>
		/// <param name="roomLayout">roomLayout</param>
		/// <param name="ownerIDCard">ownerIDCard</param>
		/// <param name="rentName">rentName</param>
		/// <param name="rentPhoneNumber">rentPhoneNumber</param>
		/// <param name="rentIDCard">rentIDCard</param>
		/// <param name="historyBill">historyBill</param>
		/// <param name="endTime">endTime</param>
		/// <param name="roomProperty">roomProperty</param>
		/// <param name="contractArea">contractArea</param>
		/// <param name="moveInTime">moveInTime</param>
		/// <param name="zxStartTime">zxStartTime</param>
		/// <param name="zxEndTime">zxEndTime</param>
		/// <param name="buildOutArea">buildOutArea</param>
		/// <param name="buildInArea">buildInArea</param>
		/// <param name="gonTanArea">gonTanArea</param>
		/// <param name="chanQuanArea">chanQuanArea</param>
		/// <param name="useArea">useArea</param>
		/// <param name="peiTaoArea">peiTaoArea</param>
		/// <param name="functionCoefficient">functionCoefficient</param>
		/// <param name="fenTanCoefficient">fenTanCoefficient</param>
		/// <param name="chanQuanNo">chanQuanNo</param>
		/// <param name="certificateTime">certificateTime</param>
		/// <param name="customOne">customOne</param>
		/// <param name="customTwo">customTwo</param>
		/// <param name="customThree">customThree</param>
		/// <param name="customFour">customFour</param>
		/// <param name="remark">remark</param>
		/// <param name="isLocked">isLocked</param>
		/// <param name="roomStateID">roomStateID</param>
		/// <param name="roomTypeID">roomTypeID</param>
		/// <param name="roomPropertyID">roomPropertyID</param>
		/// <param name="chequeTaxpayerNumber">chequeTaxpayerNumber</param>
		/// <param name="chequeBankNo">chequeBankNo</param>
		/// <param name="chequeBankName">chequeBankName</param>
		/// <param name="chequeEmailAddress">chequeEmailAddress</param>
		/// <param name="chequeCompanyName">chequeCompanyName</param>
		/// <param name="chequeAddress">chequeAddress</param>
		public static void InsertRoomBasic(int @roomID, string @roomOwner, string @ownerPhone, decimal @buildingArea, string @roomState, DateTime @addTime, DateTime @paymentTime, string @buildingNumber, string @roomType, string @roomLayout, string @ownerIDCard, string @rentName, string @rentPhoneNumber, string @rentIDCard, decimal @historyBill, DateTime @endTime, string @roomProperty, decimal @contractArea, DateTime @moveInTime, DateTime @zxStartTime, DateTime @zxEndTime, decimal @buildOutArea, decimal @buildInArea, decimal @gonTanArea, decimal @chanQuanArea, decimal @useArea, decimal @peiTaoArea, decimal @functionCoefficient, decimal @fenTanCoefficient, string @chanQuanNo, DateTime @certificateTime, string @customOne, string @customTwo, string @customThree, string @customFour, string @remark, bool @isLocked, int @roomStateID, int @roomTypeID, int @roomPropertyID, string @chequeTaxpayerNumber, string @chequeBankNo, string @chequeBankName, string @chequeEmailAddress, string @chequeCompanyName, string @chequeAddress)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertRoomBasic(@roomID, @roomOwner, @ownerPhone, @buildingArea, @roomState, @addTime, @paymentTime, @buildingNumber, @roomType, @roomLayout, @ownerIDCard, @rentName, @rentPhoneNumber, @rentIDCard, @historyBill, @endTime, @roomProperty, @contractArea, @moveInTime, @zxStartTime, @zxEndTime, @buildOutArea, @buildInArea, @gonTanArea, @chanQuanArea, @useArea, @peiTaoArea, @functionCoefficient, @fenTanCoefficient, @chanQuanNo, @certificateTime, @customOne, @customTwo, @customThree, @customFour, @remark, @isLocked, @roomStateID, @roomTypeID, @roomPropertyID, @chequeTaxpayerNumber, @chequeBankNo, @chequeBankName, @chequeEmailAddress, @chequeCompanyName, @chequeAddress, helper);
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
		/// Insert a RoomBasic into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="roomOwner">roomOwner</param>
		/// <param name="ownerPhone">ownerPhone</param>
		/// <param name="buildingArea">buildingArea</param>
		/// <param name="roomState">roomState</param>
		/// <param name="addTime">addTime</param>
		/// <param name="paymentTime">paymentTime</param>
		/// <param name="buildingNumber">buildingNumber</param>
		/// <param name="roomType">roomType</param>
		/// <param name="roomLayout">roomLayout</param>
		/// <param name="ownerIDCard">ownerIDCard</param>
		/// <param name="rentName">rentName</param>
		/// <param name="rentPhoneNumber">rentPhoneNumber</param>
		/// <param name="rentIDCard">rentIDCard</param>
		/// <param name="historyBill">historyBill</param>
		/// <param name="endTime">endTime</param>
		/// <param name="roomProperty">roomProperty</param>
		/// <param name="contractArea">contractArea</param>
		/// <param name="moveInTime">moveInTime</param>
		/// <param name="zxStartTime">zxStartTime</param>
		/// <param name="zxEndTime">zxEndTime</param>
		/// <param name="buildOutArea">buildOutArea</param>
		/// <param name="buildInArea">buildInArea</param>
		/// <param name="gonTanArea">gonTanArea</param>
		/// <param name="chanQuanArea">chanQuanArea</param>
		/// <param name="useArea">useArea</param>
		/// <param name="peiTaoArea">peiTaoArea</param>
		/// <param name="functionCoefficient">functionCoefficient</param>
		/// <param name="fenTanCoefficient">fenTanCoefficient</param>
		/// <param name="chanQuanNo">chanQuanNo</param>
		/// <param name="certificateTime">certificateTime</param>
		/// <param name="customOne">customOne</param>
		/// <param name="customTwo">customTwo</param>
		/// <param name="customThree">customThree</param>
		/// <param name="customFour">customFour</param>
		/// <param name="remark">remark</param>
		/// <param name="isLocked">isLocked</param>
		/// <param name="roomStateID">roomStateID</param>
		/// <param name="roomTypeID">roomTypeID</param>
		/// <param name="roomPropertyID">roomPropertyID</param>
		/// <param name="chequeTaxpayerNumber">chequeTaxpayerNumber</param>
		/// <param name="chequeBankNo">chequeBankNo</param>
		/// <param name="chequeBankName">chequeBankName</param>
		/// <param name="chequeEmailAddress">chequeEmailAddress</param>
		/// <param name="chequeCompanyName">chequeCompanyName</param>
		/// <param name="chequeAddress">chequeAddress</param>
		/// <param name="helper">helper</param>
		internal static void InsertRoomBasic(int @roomID, string @roomOwner, string @ownerPhone, decimal @buildingArea, string @roomState, DateTime @addTime, DateTime @paymentTime, string @buildingNumber, string @roomType, string @roomLayout, string @ownerIDCard, string @rentName, string @rentPhoneNumber, string @rentIDCard, decimal @historyBill, DateTime @endTime, string @roomProperty, decimal @contractArea, DateTime @moveInTime, DateTime @zxStartTime, DateTime @zxEndTime, decimal @buildOutArea, decimal @buildInArea, decimal @gonTanArea, decimal @chanQuanArea, decimal @useArea, decimal @peiTaoArea, decimal @functionCoefficient, decimal @fenTanCoefficient, string @chanQuanNo, DateTime @certificateTime, string @customOne, string @customTwo, string @customThree, string @customFour, string @remark, bool @isLocked, int @roomStateID, int @roomTypeID, int @roomPropertyID, string @chequeTaxpayerNumber, string @chequeBankNo, string @chequeBankName, string @chequeEmailAddress, string @chequeCompanyName, string @chequeAddress, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[RoomOwner] nvarchar(50),
	[OwnerPhone] nvarchar(50),
	[BuildingArea] decimal(18, 3),
	[RoomState] nvarchar(100),
	[AddTime] datetime,
	[PaymentTime] datetime,
	[BuildingNumber] nvarchar(50),
	[RoomType] nvarchar(50),
	[RoomLayout] nvarchar(50),
	[OwnerIDCard] nvarchar(50),
	[RentName] nvarchar(50),
	[RentPhoneNumber] nvarchar(50),
	[RentIDCard] nvarchar(50),
	[HistoryBill] decimal(18, 2),
	[EndTime] datetime,
	[RoomProperty] nvarchar(100),
	[ContractArea] decimal(18, 3),
	[MoveInTime] datetime,
	[ZxStartTime] datetime,
	[ZxEndTime] datetime,
	[BuildOutArea] decimal(18, 3),
	[BuildInArea] decimal(18, 3),
	[GonTanArea] decimal(18, 3),
	[ChanQuanArea] decimal(18, 3),
	[UseArea] decimal(18, 3),
	[PeiTaoArea] decimal(18, 3),
	[FunctionCoefficient] decimal(18, 2),
	[FenTanCoefficient] decimal(18, 2),
	[ChanQuanNo] nvarchar(200),
	[CertificateTime] datetime,
	[CustomOne] nvarchar(100),
	[CustomTwo] nvarchar(100),
	[CustomThree] nvarchar(100),
	[CustomFour] nvarchar(100),
	[Remark] nvarchar(100),
	[IsLocked] bit,
	[RoomStateID] int,
	[RoomTypeID] int,
	[RoomPropertyID] int,
	[ChequeTaxpayerNumber] nvarchar(200),
	[ChequeBankNo] nvarchar(200),
	[ChequeBankName] nvarchar(200),
	[ChequeEmailAddress] nvarchar(200),
	[ChequeCompanyName] nvarchar(200),
	[ChequeAddress] nvarchar(200)
);

INSERT INTO [dbo].[RoomBasic] (
	[RoomBasic].[RoomID],
	[RoomBasic].[RoomOwner],
	[RoomBasic].[OwnerPhone],
	[RoomBasic].[BuildingArea],
	[RoomBasic].[RoomState],
	[RoomBasic].[AddTime],
	[RoomBasic].[PaymentTime],
	[RoomBasic].[BuildingNumber],
	[RoomBasic].[RoomType],
	[RoomBasic].[RoomLayout],
	[RoomBasic].[OwnerIDCard],
	[RoomBasic].[RentName],
	[RoomBasic].[RentPhoneNumber],
	[RoomBasic].[RentIDCard],
	[RoomBasic].[HistoryBill],
	[RoomBasic].[EndTime],
	[RoomBasic].[RoomProperty],
	[RoomBasic].[ContractArea],
	[RoomBasic].[MoveInTime],
	[RoomBasic].[ZxStartTime],
	[RoomBasic].[ZxEndTime],
	[RoomBasic].[BuildOutArea],
	[RoomBasic].[BuildInArea],
	[RoomBasic].[GonTanArea],
	[RoomBasic].[ChanQuanArea],
	[RoomBasic].[UseArea],
	[RoomBasic].[PeiTaoArea],
	[RoomBasic].[FunctionCoefficient],
	[RoomBasic].[FenTanCoefficient],
	[RoomBasic].[ChanQuanNo],
	[RoomBasic].[CertificateTime],
	[RoomBasic].[CustomOne],
	[RoomBasic].[CustomTwo],
	[RoomBasic].[CustomThree],
	[RoomBasic].[CustomFour],
	[RoomBasic].[Remark],
	[RoomBasic].[IsLocked],
	[RoomBasic].[RoomStateID],
	[RoomBasic].[RoomTypeID],
	[RoomBasic].[RoomPropertyID],
	[RoomBasic].[ChequeTaxpayerNumber],
	[RoomBasic].[ChequeBankNo],
	[RoomBasic].[ChequeBankName],
	[RoomBasic].[ChequeEmailAddress],
	[RoomBasic].[ChequeCompanyName],
	[RoomBasic].[ChequeAddress]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[RoomOwner],
	INSERTED.[OwnerPhone],
	INSERTED.[BuildingArea],
	INSERTED.[RoomState],
	INSERTED.[AddTime],
	INSERTED.[PaymentTime],
	INSERTED.[BuildingNumber],
	INSERTED.[RoomType],
	INSERTED.[RoomLayout],
	INSERTED.[OwnerIDCard],
	INSERTED.[RentName],
	INSERTED.[RentPhoneNumber],
	INSERTED.[RentIDCard],
	INSERTED.[HistoryBill],
	INSERTED.[EndTime],
	INSERTED.[RoomProperty],
	INSERTED.[ContractArea],
	INSERTED.[MoveInTime],
	INSERTED.[ZxStartTime],
	INSERTED.[ZxEndTime],
	INSERTED.[BuildOutArea],
	INSERTED.[BuildInArea],
	INSERTED.[GonTanArea],
	INSERTED.[ChanQuanArea],
	INSERTED.[UseArea],
	INSERTED.[PeiTaoArea],
	INSERTED.[FunctionCoefficient],
	INSERTED.[FenTanCoefficient],
	INSERTED.[ChanQuanNo],
	INSERTED.[CertificateTime],
	INSERTED.[CustomOne],
	INSERTED.[CustomTwo],
	INSERTED.[CustomThree],
	INSERTED.[CustomFour],
	INSERTED.[Remark],
	INSERTED.[IsLocked],
	INSERTED.[RoomStateID],
	INSERTED.[RoomTypeID],
	INSERTED.[RoomPropertyID],
	INSERTED.[ChequeTaxpayerNumber],
	INSERTED.[ChequeBankNo],
	INSERTED.[ChequeBankName],
	INSERTED.[ChequeEmailAddress],
	INSERTED.[ChequeCompanyName],
	INSERTED.[ChequeAddress]
into @table
VALUES ( 
	@RoomID,
	@RoomOwner,
	@OwnerPhone,
	@BuildingArea,
	@RoomState,
	@AddTime,
	@PaymentTime,
	@BuildingNumber,
	@RoomType,
	@RoomLayout,
	@OwnerIDCard,
	@RentName,
	@RentPhoneNumber,
	@RentIDCard,
	@HistoryBill,
	@EndTime,
	@RoomProperty,
	@ContractArea,
	@MoveInTime,
	@ZxStartTime,
	@ZxEndTime,
	@BuildOutArea,
	@BuildInArea,
	@GonTanArea,
	@ChanQuanArea,
	@UseArea,
	@PeiTaoArea,
	@FunctionCoefficient,
	@FenTanCoefficient,
	@ChanQuanNo,
	@CertificateTime,
	@CustomOne,
	@CustomTwo,
	@CustomThree,
	@CustomFour,
	@Remark,
	@IsLocked,
	@RoomStateID,
	@RoomTypeID,
	@RoomPropertyID,
	@ChequeTaxpayerNumber,
	@ChequeBankNo,
	@ChequeBankName,
	@ChequeEmailAddress,
	@ChequeCompanyName,
	@ChequeAddress 
); 

SELECT 
	[ID],
	[RoomID],
	[RoomOwner],
	[OwnerPhone],
	[BuildingArea],
	[RoomState],
	[AddTime],
	[PaymentTime],
	[BuildingNumber],
	[RoomType],
	[RoomLayout],
	[OwnerIDCard],
	[RentName],
	[RentPhoneNumber],
	[RentIDCard],
	[HistoryBill],
	[EndTime],
	[RoomProperty],
	[ContractArea],
	[MoveInTime],
	[ZxStartTime],
	[ZxEndTime],
	[BuildOutArea],
	[BuildInArea],
	[GonTanArea],
	[ChanQuanArea],
	[UseArea],
	[PeiTaoArea],
	[FunctionCoefficient],
	[FenTanCoefficient],
	[ChanQuanNo],
	[CertificateTime],
	[CustomOne],
	[CustomTwo],
	[CustomThree],
	[CustomFour],
	[Remark],
	[IsLocked],
	[RoomStateID],
	[RoomTypeID],
	[RoomPropertyID],
	[ChequeTaxpayerNumber],
	[ChequeBankNo],
	[ChequeBankName],
	[ChequeEmailAddress],
	[ChequeCompanyName],
	[ChequeAddress] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@RoomOwner", EntityBase.GetDatabaseValue(@roomOwner)));
			parameters.Add(new SqlParameter("@OwnerPhone", EntityBase.GetDatabaseValue(@ownerPhone)));
			parameters.Add(new SqlParameter("@BuildingArea", EntityBase.GetDatabaseValue(@buildingArea)));
			parameters.Add(new SqlParameter("@RoomState", EntityBase.GetDatabaseValue(@roomState)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@PaymentTime", EntityBase.GetDatabaseValue(@paymentTime)));
			parameters.Add(new SqlParameter("@BuildingNumber", EntityBase.GetDatabaseValue(@buildingNumber)));
			parameters.Add(new SqlParameter("@RoomType", EntityBase.GetDatabaseValue(@roomType)));
			parameters.Add(new SqlParameter("@RoomLayout", EntityBase.GetDatabaseValue(@roomLayout)));
			parameters.Add(new SqlParameter("@OwnerIDCard", EntityBase.GetDatabaseValue(@ownerIDCard)));
			parameters.Add(new SqlParameter("@RentName", EntityBase.GetDatabaseValue(@rentName)));
			parameters.Add(new SqlParameter("@RentPhoneNumber", EntityBase.GetDatabaseValue(@rentPhoneNumber)));
			parameters.Add(new SqlParameter("@RentIDCard", EntityBase.GetDatabaseValue(@rentIDCard)));
			parameters.Add(new SqlParameter("@HistoryBill", EntityBase.GetDatabaseValue(@historyBill)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@RoomProperty", EntityBase.GetDatabaseValue(@roomProperty)));
			parameters.Add(new SqlParameter("@ContractArea", EntityBase.GetDatabaseValue(@contractArea)));
			parameters.Add(new SqlParameter("@MoveInTime", EntityBase.GetDatabaseValue(@moveInTime)));
			parameters.Add(new SqlParameter("@ZxStartTime", EntityBase.GetDatabaseValue(@zxStartTime)));
			parameters.Add(new SqlParameter("@ZxEndTime", EntityBase.GetDatabaseValue(@zxEndTime)));
			parameters.Add(new SqlParameter("@BuildOutArea", EntityBase.GetDatabaseValue(@buildOutArea)));
			parameters.Add(new SqlParameter("@BuildInArea", EntityBase.GetDatabaseValue(@buildInArea)));
			parameters.Add(new SqlParameter("@GonTanArea", EntityBase.GetDatabaseValue(@gonTanArea)));
			parameters.Add(new SqlParameter("@ChanQuanArea", EntityBase.GetDatabaseValue(@chanQuanArea)));
			parameters.Add(new SqlParameter("@UseArea", EntityBase.GetDatabaseValue(@useArea)));
			parameters.Add(new SqlParameter("@PeiTaoArea", EntityBase.GetDatabaseValue(@peiTaoArea)));
			parameters.Add(new SqlParameter("@FunctionCoefficient", EntityBase.GetDatabaseValue(@functionCoefficient)));
			parameters.Add(new SqlParameter("@FenTanCoefficient", EntityBase.GetDatabaseValue(@fenTanCoefficient)));
			parameters.Add(new SqlParameter("@ChanQuanNo", EntityBase.GetDatabaseValue(@chanQuanNo)));
			parameters.Add(new SqlParameter("@CertificateTime", EntityBase.GetDatabaseValue(@certificateTime)));
			parameters.Add(new SqlParameter("@CustomOne", EntityBase.GetDatabaseValue(@customOne)));
			parameters.Add(new SqlParameter("@CustomTwo", EntityBase.GetDatabaseValue(@customTwo)));
			parameters.Add(new SqlParameter("@CustomThree", EntityBase.GetDatabaseValue(@customThree)));
			parameters.Add(new SqlParameter("@CustomFour", EntityBase.GetDatabaseValue(@customFour)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@IsLocked", @isLocked));
			parameters.Add(new SqlParameter("@RoomStateID", EntityBase.GetDatabaseValue(@roomStateID)));
			parameters.Add(new SqlParameter("@RoomTypeID", EntityBase.GetDatabaseValue(@roomTypeID)));
			parameters.Add(new SqlParameter("@RoomPropertyID", EntityBase.GetDatabaseValue(@roomPropertyID)));
			parameters.Add(new SqlParameter("@ChequeTaxpayerNumber", EntityBase.GetDatabaseValue(@chequeTaxpayerNumber)));
			parameters.Add(new SqlParameter("@ChequeBankNo", EntityBase.GetDatabaseValue(@chequeBankNo)));
			parameters.Add(new SqlParameter("@ChequeBankName", EntityBase.GetDatabaseValue(@chequeBankName)));
			parameters.Add(new SqlParameter("@ChequeEmailAddress", EntityBase.GetDatabaseValue(@chequeEmailAddress)));
			parameters.Add(new SqlParameter("@ChequeCompanyName", EntityBase.GetDatabaseValue(@chequeCompanyName)));
			parameters.Add(new SqlParameter("@ChequeAddress", EntityBase.GetDatabaseValue(@chequeAddress)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a RoomBasic into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="roomOwner">roomOwner</param>
		/// <param name="ownerPhone">ownerPhone</param>
		/// <param name="buildingArea">buildingArea</param>
		/// <param name="roomState">roomState</param>
		/// <param name="addTime">addTime</param>
		/// <param name="paymentTime">paymentTime</param>
		/// <param name="buildingNumber">buildingNumber</param>
		/// <param name="roomType">roomType</param>
		/// <param name="roomLayout">roomLayout</param>
		/// <param name="ownerIDCard">ownerIDCard</param>
		/// <param name="rentName">rentName</param>
		/// <param name="rentPhoneNumber">rentPhoneNumber</param>
		/// <param name="rentIDCard">rentIDCard</param>
		/// <param name="historyBill">historyBill</param>
		/// <param name="endTime">endTime</param>
		/// <param name="roomProperty">roomProperty</param>
		/// <param name="contractArea">contractArea</param>
		/// <param name="moveInTime">moveInTime</param>
		/// <param name="zxStartTime">zxStartTime</param>
		/// <param name="zxEndTime">zxEndTime</param>
		/// <param name="buildOutArea">buildOutArea</param>
		/// <param name="buildInArea">buildInArea</param>
		/// <param name="gonTanArea">gonTanArea</param>
		/// <param name="chanQuanArea">chanQuanArea</param>
		/// <param name="useArea">useArea</param>
		/// <param name="peiTaoArea">peiTaoArea</param>
		/// <param name="functionCoefficient">functionCoefficient</param>
		/// <param name="fenTanCoefficient">fenTanCoefficient</param>
		/// <param name="chanQuanNo">chanQuanNo</param>
		/// <param name="certificateTime">certificateTime</param>
		/// <param name="customOne">customOne</param>
		/// <param name="customTwo">customTwo</param>
		/// <param name="customThree">customThree</param>
		/// <param name="customFour">customFour</param>
		/// <param name="remark">remark</param>
		/// <param name="isLocked">isLocked</param>
		/// <param name="roomStateID">roomStateID</param>
		/// <param name="roomTypeID">roomTypeID</param>
		/// <param name="roomPropertyID">roomPropertyID</param>
		/// <param name="chequeTaxpayerNumber">chequeTaxpayerNumber</param>
		/// <param name="chequeBankNo">chequeBankNo</param>
		/// <param name="chequeBankName">chequeBankName</param>
		/// <param name="chequeEmailAddress">chequeEmailAddress</param>
		/// <param name="chequeCompanyName">chequeCompanyName</param>
		/// <param name="chequeAddress">chequeAddress</param>
		public static void UpdateRoomBasic(int @iD, int @roomID, string @roomOwner, string @ownerPhone, decimal @buildingArea, string @roomState, DateTime @addTime, DateTime @paymentTime, string @buildingNumber, string @roomType, string @roomLayout, string @ownerIDCard, string @rentName, string @rentPhoneNumber, string @rentIDCard, decimal @historyBill, DateTime @endTime, string @roomProperty, decimal @contractArea, DateTime @moveInTime, DateTime @zxStartTime, DateTime @zxEndTime, decimal @buildOutArea, decimal @buildInArea, decimal @gonTanArea, decimal @chanQuanArea, decimal @useArea, decimal @peiTaoArea, decimal @functionCoefficient, decimal @fenTanCoefficient, string @chanQuanNo, DateTime @certificateTime, string @customOne, string @customTwo, string @customThree, string @customFour, string @remark, bool @isLocked, int @roomStateID, int @roomTypeID, int @roomPropertyID, string @chequeTaxpayerNumber, string @chequeBankNo, string @chequeBankName, string @chequeEmailAddress, string @chequeCompanyName, string @chequeAddress)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateRoomBasic(@iD, @roomID, @roomOwner, @ownerPhone, @buildingArea, @roomState, @addTime, @paymentTime, @buildingNumber, @roomType, @roomLayout, @ownerIDCard, @rentName, @rentPhoneNumber, @rentIDCard, @historyBill, @endTime, @roomProperty, @contractArea, @moveInTime, @zxStartTime, @zxEndTime, @buildOutArea, @buildInArea, @gonTanArea, @chanQuanArea, @useArea, @peiTaoArea, @functionCoefficient, @fenTanCoefficient, @chanQuanNo, @certificateTime, @customOne, @customTwo, @customThree, @customFour, @remark, @isLocked, @roomStateID, @roomTypeID, @roomPropertyID, @chequeTaxpayerNumber, @chequeBankNo, @chequeBankName, @chequeEmailAddress, @chequeCompanyName, @chequeAddress, helper);
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
		/// Updates a RoomBasic into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="roomOwner">roomOwner</param>
		/// <param name="ownerPhone">ownerPhone</param>
		/// <param name="buildingArea">buildingArea</param>
		/// <param name="roomState">roomState</param>
		/// <param name="addTime">addTime</param>
		/// <param name="paymentTime">paymentTime</param>
		/// <param name="buildingNumber">buildingNumber</param>
		/// <param name="roomType">roomType</param>
		/// <param name="roomLayout">roomLayout</param>
		/// <param name="ownerIDCard">ownerIDCard</param>
		/// <param name="rentName">rentName</param>
		/// <param name="rentPhoneNumber">rentPhoneNumber</param>
		/// <param name="rentIDCard">rentIDCard</param>
		/// <param name="historyBill">historyBill</param>
		/// <param name="endTime">endTime</param>
		/// <param name="roomProperty">roomProperty</param>
		/// <param name="contractArea">contractArea</param>
		/// <param name="moveInTime">moveInTime</param>
		/// <param name="zxStartTime">zxStartTime</param>
		/// <param name="zxEndTime">zxEndTime</param>
		/// <param name="buildOutArea">buildOutArea</param>
		/// <param name="buildInArea">buildInArea</param>
		/// <param name="gonTanArea">gonTanArea</param>
		/// <param name="chanQuanArea">chanQuanArea</param>
		/// <param name="useArea">useArea</param>
		/// <param name="peiTaoArea">peiTaoArea</param>
		/// <param name="functionCoefficient">functionCoefficient</param>
		/// <param name="fenTanCoefficient">fenTanCoefficient</param>
		/// <param name="chanQuanNo">chanQuanNo</param>
		/// <param name="certificateTime">certificateTime</param>
		/// <param name="customOne">customOne</param>
		/// <param name="customTwo">customTwo</param>
		/// <param name="customThree">customThree</param>
		/// <param name="customFour">customFour</param>
		/// <param name="remark">remark</param>
		/// <param name="isLocked">isLocked</param>
		/// <param name="roomStateID">roomStateID</param>
		/// <param name="roomTypeID">roomTypeID</param>
		/// <param name="roomPropertyID">roomPropertyID</param>
		/// <param name="chequeTaxpayerNumber">chequeTaxpayerNumber</param>
		/// <param name="chequeBankNo">chequeBankNo</param>
		/// <param name="chequeBankName">chequeBankName</param>
		/// <param name="chequeEmailAddress">chequeEmailAddress</param>
		/// <param name="chequeCompanyName">chequeCompanyName</param>
		/// <param name="chequeAddress">chequeAddress</param>
		/// <param name="helper">helper</param>
		internal static void UpdateRoomBasic(int @iD, int @roomID, string @roomOwner, string @ownerPhone, decimal @buildingArea, string @roomState, DateTime @addTime, DateTime @paymentTime, string @buildingNumber, string @roomType, string @roomLayout, string @ownerIDCard, string @rentName, string @rentPhoneNumber, string @rentIDCard, decimal @historyBill, DateTime @endTime, string @roomProperty, decimal @contractArea, DateTime @moveInTime, DateTime @zxStartTime, DateTime @zxEndTime, decimal @buildOutArea, decimal @buildInArea, decimal @gonTanArea, decimal @chanQuanArea, decimal @useArea, decimal @peiTaoArea, decimal @functionCoefficient, decimal @fenTanCoefficient, string @chanQuanNo, DateTime @certificateTime, string @customOne, string @customTwo, string @customThree, string @customFour, string @remark, bool @isLocked, int @roomStateID, int @roomTypeID, int @roomPropertyID, string @chequeTaxpayerNumber, string @chequeBankNo, string @chequeBankName, string @chequeEmailAddress, string @chequeCompanyName, string @chequeAddress, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[RoomOwner] nvarchar(50),
	[OwnerPhone] nvarchar(50),
	[BuildingArea] decimal(18, 3),
	[RoomState] nvarchar(100),
	[AddTime] datetime,
	[PaymentTime] datetime,
	[BuildingNumber] nvarchar(50),
	[RoomType] nvarchar(50),
	[RoomLayout] nvarchar(50),
	[OwnerIDCard] nvarchar(50),
	[RentName] nvarchar(50),
	[RentPhoneNumber] nvarchar(50),
	[RentIDCard] nvarchar(50),
	[HistoryBill] decimal(18, 2),
	[EndTime] datetime,
	[RoomProperty] nvarchar(100),
	[ContractArea] decimal(18, 3),
	[MoveInTime] datetime,
	[ZxStartTime] datetime,
	[ZxEndTime] datetime,
	[BuildOutArea] decimal(18, 3),
	[BuildInArea] decimal(18, 3),
	[GonTanArea] decimal(18, 3),
	[ChanQuanArea] decimal(18, 3),
	[UseArea] decimal(18, 3),
	[PeiTaoArea] decimal(18, 3),
	[FunctionCoefficient] decimal(18, 2),
	[FenTanCoefficient] decimal(18, 2),
	[ChanQuanNo] nvarchar(200),
	[CertificateTime] datetime,
	[CustomOne] nvarchar(100),
	[CustomTwo] nvarchar(100),
	[CustomThree] nvarchar(100),
	[CustomFour] nvarchar(100),
	[Remark] nvarchar(100),
	[IsLocked] bit,
	[RoomStateID] int,
	[RoomTypeID] int,
	[RoomPropertyID] int,
	[ChequeTaxpayerNumber] nvarchar(200),
	[ChequeBankNo] nvarchar(200),
	[ChequeBankName] nvarchar(200),
	[ChequeEmailAddress] nvarchar(200),
	[ChequeCompanyName] nvarchar(200),
	[ChequeAddress] nvarchar(200)
);

UPDATE [dbo].[RoomBasic] SET 
	[RoomBasic].[RoomID] = @RoomID,
	[RoomBasic].[RoomOwner] = @RoomOwner,
	[RoomBasic].[OwnerPhone] = @OwnerPhone,
	[RoomBasic].[BuildingArea] = @BuildingArea,
	[RoomBasic].[RoomState] = @RoomState,
	[RoomBasic].[AddTime] = @AddTime,
	[RoomBasic].[PaymentTime] = @PaymentTime,
	[RoomBasic].[BuildingNumber] = @BuildingNumber,
	[RoomBasic].[RoomType] = @RoomType,
	[RoomBasic].[RoomLayout] = @RoomLayout,
	[RoomBasic].[OwnerIDCard] = @OwnerIDCard,
	[RoomBasic].[RentName] = @RentName,
	[RoomBasic].[RentPhoneNumber] = @RentPhoneNumber,
	[RoomBasic].[RentIDCard] = @RentIDCard,
	[RoomBasic].[HistoryBill] = @HistoryBill,
	[RoomBasic].[EndTime] = @EndTime,
	[RoomBasic].[RoomProperty] = @RoomProperty,
	[RoomBasic].[ContractArea] = @ContractArea,
	[RoomBasic].[MoveInTime] = @MoveInTime,
	[RoomBasic].[ZxStartTime] = @ZxStartTime,
	[RoomBasic].[ZxEndTime] = @ZxEndTime,
	[RoomBasic].[BuildOutArea] = @BuildOutArea,
	[RoomBasic].[BuildInArea] = @BuildInArea,
	[RoomBasic].[GonTanArea] = @GonTanArea,
	[RoomBasic].[ChanQuanArea] = @ChanQuanArea,
	[RoomBasic].[UseArea] = @UseArea,
	[RoomBasic].[PeiTaoArea] = @PeiTaoArea,
	[RoomBasic].[FunctionCoefficient] = @FunctionCoefficient,
	[RoomBasic].[FenTanCoefficient] = @FenTanCoefficient,
	[RoomBasic].[ChanQuanNo] = @ChanQuanNo,
	[RoomBasic].[CertificateTime] = @CertificateTime,
	[RoomBasic].[CustomOne] = @CustomOne,
	[RoomBasic].[CustomTwo] = @CustomTwo,
	[RoomBasic].[CustomThree] = @CustomThree,
	[RoomBasic].[CustomFour] = @CustomFour,
	[RoomBasic].[Remark] = @Remark,
	[RoomBasic].[IsLocked] = @IsLocked,
	[RoomBasic].[RoomStateID] = @RoomStateID,
	[RoomBasic].[RoomTypeID] = @RoomTypeID,
	[RoomBasic].[RoomPropertyID] = @RoomPropertyID,
	[RoomBasic].[ChequeTaxpayerNumber] = @ChequeTaxpayerNumber,
	[RoomBasic].[ChequeBankNo] = @ChequeBankNo,
	[RoomBasic].[ChequeBankName] = @ChequeBankName,
	[RoomBasic].[ChequeEmailAddress] = @ChequeEmailAddress,
	[RoomBasic].[ChequeCompanyName] = @ChequeCompanyName,
	[RoomBasic].[ChequeAddress] = @ChequeAddress 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[RoomOwner],
	INSERTED.[OwnerPhone],
	INSERTED.[BuildingArea],
	INSERTED.[RoomState],
	INSERTED.[AddTime],
	INSERTED.[PaymentTime],
	INSERTED.[BuildingNumber],
	INSERTED.[RoomType],
	INSERTED.[RoomLayout],
	INSERTED.[OwnerIDCard],
	INSERTED.[RentName],
	INSERTED.[RentPhoneNumber],
	INSERTED.[RentIDCard],
	INSERTED.[HistoryBill],
	INSERTED.[EndTime],
	INSERTED.[RoomProperty],
	INSERTED.[ContractArea],
	INSERTED.[MoveInTime],
	INSERTED.[ZxStartTime],
	INSERTED.[ZxEndTime],
	INSERTED.[BuildOutArea],
	INSERTED.[BuildInArea],
	INSERTED.[GonTanArea],
	INSERTED.[ChanQuanArea],
	INSERTED.[UseArea],
	INSERTED.[PeiTaoArea],
	INSERTED.[FunctionCoefficient],
	INSERTED.[FenTanCoefficient],
	INSERTED.[ChanQuanNo],
	INSERTED.[CertificateTime],
	INSERTED.[CustomOne],
	INSERTED.[CustomTwo],
	INSERTED.[CustomThree],
	INSERTED.[CustomFour],
	INSERTED.[Remark],
	INSERTED.[IsLocked],
	INSERTED.[RoomStateID],
	INSERTED.[RoomTypeID],
	INSERTED.[RoomPropertyID],
	INSERTED.[ChequeTaxpayerNumber],
	INSERTED.[ChequeBankNo],
	INSERTED.[ChequeBankName],
	INSERTED.[ChequeEmailAddress],
	INSERTED.[ChequeCompanyName],
	INSERTED.[ChequeAddress]
into @table
WHERE 
	[RoomBasic].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[RoomOwner],
	[OwnerPhone],
	[BuildingArea],
	[RoomState],
	[AddTime],
	[PaymentTime],
	[BuildingNumber],
	[RoomType],
	[RoomLayout],
	[OwnerIDCard],
	[RentName],
	[RentPhoneNumber],
	[RentIDCard],
	[HistoryBill],
	[EndTime],
	[RoomProperty],
	[ContractArea],
	[MoveInTime],
	[ZxStartTime],
	[ZxEndTime],
	[BuildOutArea],
	[BuildInArea],
	[GonTanArea],
	[ChanQuanArea],
	[UseArea],
	[PeiTaoArea],
	[FunctionCoefficient],
	[FenTanCoefficient],
	[ChanQuanNo],
	[CertificateTime],
	[CustomOne],
	[CustomTwo],
	[CustomThree],
	[CustomFour],
	[Remark],
	[IsLocked],
	[RoomStateID],
	[RoomTypeID],
	[RoomPropertyID],
	[ChequeTaxpayerNumber],
	[ChequeBankNo],
	[ChequeBankName],
	[ChequeEmailAddress],
	[ChequeCompanyName],
	[ChequeAddress] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@RoomOwner", EntityBase.GetDatabaseValue(@roomOwner)));
			parameters.Add(new SqlParameter("@OwnerPhone", EntityBase.GetDatabaseValue(@ownerPhone)));
			parameters.Add(new SqlParameter("@BuildingArea", EntityBase.GetDatabaseValue(@buildingArea)));
			parameters.Add(new SqlParameter("@RoomState", EntityBase.GetDatabaseValue(@roomState)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@PaymentTime", EntityBase.GetDatabaseValue(@paymentTime)));
			parameters.Add(new SqlParameter("@BuildingNumber", EntityBase.GetDatabaseValue(@buildingNumber)));
			parameters.Add(new SqlParameter("@RoomType", EntityBase.GetDatabaseValue(@roomType)));
			parameters.Add(new SqlParameter("@RoomLayout", EntityBase.GetDatabaseValue(@roomLayout)));
			parameters.Add(new SqlParameter("@OwnerIDCard", EntityBase.GetDatabaseValue(@ownerIDCard)));
			parameters.Add(new SqlParameter("@RentName", EntityBase.GetDatabaseValue(@rentName)));
			parameters.Add(new SqlParameter("@RentPhoneNumber", EntityBase.GetDatabaseValue(@rentPhoneNumber)));
			parameters.Add(new SqlParameter("@RentIDCard", EntityBase.GetDatabaseValue(@rentIDCard)));
			parameters.Add(new SqlParameter("@HistoryBill", EntityBase.GetDatabaseValue(@historyBill)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@RoomProperty", EntityBase.GetDatabaseValue(@roomProperty)));
			parameters.Add(new SqlParameter("@ContractArea", EntityBase.GetDatabaseValue(@contractArea)));
			parameters.Add(new SqlParameter("@MoveInTime", EntityBase.GetDatabaseValue(@moveInTime)));
			parameters.Add(new SqlParameter("@ZxStartTime", EntityBase.GetDatabaseValue(@zxStartTime)));
			parameters.Add(new SqlParameter("@ZxEndTime", EntityBase.GetDatabaseValue(@zxEndTime)));
			parameters.Add(new SqlParameter("@BuildOutArea", EntityBase.GetDatabaseValue(@buildOutArea)));
			parameters.Add(new SqlParameter("@BuildInArea", EntityBase.GetDatabaseValue(@buildInArea)));
			parameters.Add(new SqlParameter("@GonTanArea", EntityBase.GetDatabaseValue(@gonTanArea)));
			parameters.Add(new SqlParameter("@ChanQuanArea", EntityBase.GetDatabaseValue(@chanQuanArea)));
			parameters.Add(new SqlParameter("@UseArea", EntityBase.GetDatabaseValue(@useArea)));
			parameters.Add(new SqlParameter("@PeiTaoArea", EntityBase.GetDatabaseValue(@peiTaoArea)));
			parameters.Add(new SqlParameter("@FunctionCoefficient", EntityBase.GetDatabaseValue(@functionCoefficient)));
			parameters.Add(new SqlParameter("@FenTanCoefficient", EntityBase.GetDatabaseValue(@fenTanCoefficient)));
			parameters.Add(new SqlParameter("@ChanQuanNo", EntityBase.GetDatabaseValue(@chanQuanNo)));
			parameters.Add(new SqlParameter("@CertificateTime", EntityBase.GetDatabaseValue(@certificateTime)));
			parameters.Add(new SqlParameter("@CustomOne", EntityBase.GetDatabaseValue(@customOne)));
			parameters.Add(new SqlParameter("@CustomTwo", EntityBase.GetDatabaseValue(@customTwo)));
			parameters.Add(new SqlParameter("@CustomThree", EntityBase.GetDatabaseValue(@customThree)));
			parameters.Add(new SqlParameter("@CustomFour", EntityBase.GetDatabaseValue(@customFour)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@IsLocked", @isLocked));
			parameters.Add(new SqlParameter("@RoomStateID", EntityBase.GetDatabaseValue(@roomStateID)));
			parameters.Add(new SqlParameter("@RoomTypeID", EntityBase.GetDatabaseValue(@roomTypeID)));
			parameters.Add(new SqlParameter("@RoomPropertyID", EntityBase.GetDatabaseValue(@roomPropertyID)));
			parameters.Add(new SqlParameter("@ChequeTaxpayerNumber", EntityBase.GetDatabaseValue(@chequeTaxpayerNumber)));
			parameters.Add(new SqlParameter("@ChequeBankNo", EntityBase.GetDatabaseValue(@chequeBankNo)));
			parameters.Add(new SqlParameter("@ChequeBankName", EntityBase.GetDatabaseValue(@chequeBankName)));
			parameters.Add(new SqlParameter("@ChequeEmailAddress", EntityBase.GetDatabaseValue(@chequeEmailAddress)));
			parameters.Add(new SqlParameter("@ChequeCompanyName", EntityBase.GetDatabaseValue(@chequeCompanyName)));
			parameters.Add(new SqlParameter("@ChequeAddress", EntityBase.GetDatabaseValue(@chequeAddress)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a RoomBasic from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteRoomBasic(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteRoomBasic(@iD, helper);
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
		/// Deletes a RoomBasic from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteRoomBasic(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[RoomBasic]
WHERE 
	[RoomBasic].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new RoomBasic object.
		/// </summary>
		/// <returns>The newly created RoomBasic object.</returns>
		public static RoomBasic CreateRoomBasic()
		{
			return InitializeNew<RoomBasic>();
		}
		
		/// <summary>
		/// Retrieve information for a RoomBasic by a RoomBasic's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>RoomBasic</returns>
		public static RoomBasic GetRoomBasic(int @iD)
		{
			string commandText = @"
SELECT 
" + RoomBasic.SelectFieldList + @"
FROM [dbo].[RoomBasic] 
WHERE 
	[RoomBasic].[ID] = @ID " + RoomBasic.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomBasic>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a RoomBasic by a RoomBasic's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>RoomBasic</returns>
		public static RoomBasic GetRoomBasic(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + RoomBasic.SelectFieldList + @"
FROM [dbo].[RoomBasic] 
WHERE 
	[RoomBasic].[ID] = @ID " + RoomBasic.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomBasic>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection RoomBasic objects.
		/// </summary>
		/// <returns>The retrieved collection of RoomBasic objects.</returns>
		public static EntityList<RoomBasic> GetRoomBasics()
		{
			string commandText = @"
SELECT " + RoomBasic.SelectFieldList + "FROM [dbo].[RoomBasic] " + RoomBasic.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<RoomBasic>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection RoomBasic objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomBasic objects.</returns>
        public static EntityList<RoomBasic> GetRoomBasics(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomBasic>(SelectFieldList, "FROM [dbo].[RoomBasic]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection RoomBasic objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomBasic objects.</returns>
        public static EntityList<RoomBasic> GetRoomBasics(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomBasic>(SelectFieldList, "FROM [dbo].[RoomBasic]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection RoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of RoomBasic objects.</returns>
		protected static EntityList<RoomBasic> GetRoomBasics(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomBasics(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection RoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomBasic objects.</returns>
		protected static EntityList<RoomBasic> GetRoomBasics(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomBasics(string.Empty, where, parameters, RoomBasic.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomBasic objects.</returns>
		protected static EntityList<RoomBasic> GetRoomBasics(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomBasics(prefix, where, parameters, RoomBasic.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomBasic objects.</returns>
		protected static EntityList<RoomBasic> GetRoomBasics(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomBasics(string.Empty, where, parameters, RoomBasic.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomBasic objects.</returns>
		protected static EntityList<RoomBasic> GetRoomBasics(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomBasics(prefix, where, parameters, RoomBasic.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomBasic objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of RoomBasic objects.</returns>
		protected static EntityList<RoomBasic> GetRoomBasics(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + RoomBasic.SelectFieldList + "FROM [dbo].[RoomBasic] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<RoomBasic>(reader);
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
        protected static EntityList<RoomBasic> GetRoomBasics(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomBasic>(SelectFieldList, "FROM [dbo].[RoomBasic] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of RoomBasic objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomBasicCount()
        {
            return GetRoomBasicCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of RoomBasic objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomBasicCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[RoomBasic] " + where;

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
		public static partial class RoomBasic_Properties
		{
			public const string ID = "ID";
			public const string RoomID = "RoomID";
			public const string RoomOwner = "RoomOwner";
			public const string OwnerPhone = "OwnerPhone";
			public const string BuildingArea = "BuildingArea";
			public const string RoomState = "RoomState";
			public const string AddTime = "AddTime";
			public const string PaymentTime = "PaymentTime";
			public const string BuildingNumber = "BuildingNumber";
			public const string RoomType = "RoomType";
			public const string RoomLayout = "RoomLayout";
			public const string OwnerIDCard = "OwnerIDCard";
			public const string RentName = "RentName";
			public const string RentPhoneNumber = "RentPhoneNumber";
			public const string RentIDCard = "RentIDCard";
			public const string HistoryBill = "HistoryBill";
			public const string EndTime = "EndTime";
			public const string RoomProperty = "RoomProperty";
			public const string ContractArea = "ContractArea";
			public const string MoveInTime = "MoveInTime";
			public const string ZxStartTime = "ZxStartTime";
			public const string ZxEndTime = "ZxEndTime";
			public const string BuildOutArea = "BuildOutArea";
			public const string BuildInArea = "BuildInArea";
			public const string GonTanArea = "GonTanArea";
			public const string ChanQuanArea = "ChanQuanArea";
			public const string UseArea = "UseArea";
			public const string PeiTaoArea = "PeiTaoArea";
			public const string FunctionCoefficient = "FunctionCoefficient";
			public const string FenTanCoefficient = "FenTanCoefficient";
			public const string ChanQuanNo = "ChanQuanNo";
			public const string CertificateTime = "CertificateTime";
			public const string CustomOne = "CustomOne";
			public const string CustomTwo = "CustomTwo";
			public const string CustomThree = "CustomThree";
			public const string CustomFour = "CustomFour";
			public const string Remark = "Remark";
			public const string IsLocked = "IsLocked";
			public const string RoomStateID = "RoomStateID";
			public const string RoomTypeID = "RoomTypeID";
			public const string RoomPropertyID = "RoomPropertyID";
			public const string ChequeTaxpayerNumber = "ChequeTaxpayerNumber";
			public const string ChequeBankNo = "ChequeBankNo";
			public const string ChequeBankName = "ChequeBankName";
			public const string ChequeEmailAddress = "ChequeEmailAddress";
			public const string ChequeCompanyName = "ChequeCompanyName";
			public const string ChequeAddress = "ChequeAddress";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"RoomOwner" , "string:"},
    			 {"OwnerPhone" , "string:"},
    			 {"BuildingArea" , "decimal:"},
    			 {"RoomState" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"PaymentTime" , "DateTime:"},
    			 {"BuildingNumber" , "string:"},
    			 {"RoomType" , "string:"},
    			 {"RoomLayout" , "string:"},
    			 {"OwnerIDCard" , "string:"},
    			 {"RentName" , "string:"},
    			 {"RentPhoneNumber" , "string:"},
    			 {"RentIDCard" , "string:"},
    			 {"HistoryBill" , "decimal:"},
    			 {"EndTime" , "DateTime:"},
    			 {"RoomProperty" , "string:"},
    			 {"ContractArea" , "decimal:"},
    			 {"MoveInTime" , "DateTime:"},
    			 {"ZxStartTime" , "DateTime:"},
    			 {"ZxEndTime" , "DateTime:"},
    			 {"BuildOutArea" , "decimal:"},
    			 {"BuildInArea" , "decimal:"},
    			 {"GonTanArea" , "decimal:"},
    			 {"ChanQuanArea" , "decimal:"},
    			 {"UseArea" , "decimal:"},
    			 {"PeiTaoArea" , "decimal:"},
    			 {"FunctionCoefficient" , "decimal:"},
    			 {"FenTanCoefficient" , "decimal:"},
    			 {"ChanQuanNo" , "string:"},
    			 {"CertificateTime" , "DateTime:"},
    			 {"CustomOne" , "string:"},
    			 {"CustomTwo" , "string:"},
    			 {"CustomThree" , "string:"},
    			 {"CustomFour" , "string:"},
    			 {"Remark" , "string:"},
    			 {"IsLocked" , "bool:"},
    			 {"RoomStateID" , "int:"},
    			 {"RoomTypeID" , "int:"},
    			 {"RoomPropertyID" , "int:"},
    			 {"ChequeTaxpayerNumber" , "string:"},
    			 {"ChequeBankNo" , "string:"},
    			 {"ChequeBankName" , "string:"},
    			 {"ChequeEmailAddress" , "string:"},
    			 {"ChequeCompanyName" , "string:"},
    			 {"ChequeAddress" , "string:"},
            };
		}
		#endregion
	}
}
