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
	/// This object represents the properties and methods of a ViewRoomBasic.
	/// </summary>
	[Serializable()]
	public partial class ViewRoomBasic 
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
		[DataObjectField(false, false, true)]
		public int ID
		{
			[DebuggerStepThrough()]
			get { return this._iD; }
            protected set { this._iD = value;}
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
            protected set { this._roomOwner = value;}
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
            protected set { this._ownerPhone = value;}
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
            protected set { this._roomState = value;}
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
            protected set { this._paymentTime = value;}
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
            protected set { this._buildingNumber = value;}
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
            protected set { this._roomType = value;}
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
            protected set { this._roomLayout = value;}
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
            protected set { this._ownerIDCard = value;}
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
            protected set { this._rentPhoneNumber = value;}
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
            protected set { this._rentIDCard = value;}
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
            protected set { this._historyBill = value;}
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
		private bool _isParent = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool isParent
		{
			[DebuggerStepThrough()]
			get { return this._isParent; }
            protected set { this._isParent = value;}
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
		private string _pName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PName
		{
			[DebuggerStepThrough()]
			get { return this._pName; }
            protected set { this._pName = value;}
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
            protected set { this._customFour = value;}
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
            protected set { this._customThree = value;}
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
            protected set { this._customTwo = value;}
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
            protected set { this._customOne = value;}
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
            protected set { this._certificateTime = value;}
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
            protected set { this._chanQuanNo = value;}
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
            protected set { this._zxEndTime = value;}
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
            protected set { this._zxStartTime = value;}
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
            protected set { this._moveInTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relatePhoneNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelatePhoneNumber
		{
			[DebuggerStepThrough()]
			get { return this._relatePhoneNumber; }
            protected set { this._relatePhoneNumber = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relationName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelationName
		{
			[DebuggerStepThrough()]
			get { return this._relationName; }
            protected set { this._relationName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relationIDCard = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelationIDCard
		{
			[DebuggerStepThrough()]
			get { return this._relationIDCard; }
            protected set { this._relationIDCard = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relationType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelationType
		{
			[DebuggerStepThrough()]
			get { return this._relationType; }
            protected set { this._relationType = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _contractStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ContractStartTime
		{
			[DebuggerStepThrough()]
			get { return this._contractStartTime; }
            protected set { this._contractStartTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _contractEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ContractEndTime
		{
			[DebuggerStepThrough()]
			get { return this._contractEndTime; }
            protected set { this._contractEndTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _brandInfo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BrandInfo
		{
			[DebuggerStepThrough()]
			get { return this._brandInfo; }
            protected set { this._brandInfo = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contractNote = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractNote
		{
			[DebuggerStepThrough()]
			get { return this._contractNote; }
            protected set { this._contractNote = value;}
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
            protected set { this._isLocked = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _iDCardType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int IDCardType
		{
			[DebuggerStepThrough()]
			get { return this._iDCardType; }
            protected set { this._iDCardType = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _birthday = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime Birthday
		{
			[DebuggerStepThrough()]
			get { return this._birthday; }
            protected set { this._birthday = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _emailAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string EmailAddress
		{
			[DebuggerStepThrough()]
			get { return this._emailAddress; }
            protected set { this._emailAddress = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _homeAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string HomeAddress
		{
			[DebuggerStepThrough()]
			get { return this._homeAddress; }
            protected set { this._homeAddress = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _officeAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OfficeAddress
		{
			[DebuggerStepThrough()]
			get { return this._officeAddress; }
            protected set { this._officeAddress = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _bankName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BankName
		{
			[DebuggerStepThrough()]
			get { return this._bankName; }
            protected set { this._bankName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _bankAccountName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BankAccountName
		{
			[DebuggerStepThrough()]
			get { return this._bankAccountName; }
            protected set { this._bankAccountName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _bankAccountNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BankAccountNo
		{
			[DebuggerStepThrough()]
			get { return this._bankAccountNo; }
            protected set { this._bankAccountNo = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relateCustomOne = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelateCustomOne
		{
			[DebuggerStepThrough()]
			get { return this._relateCustomOne; }
            protected set { this._relateCustomOne = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relateCustomTwo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelateCustomTwo
		{
			[DebuggerStepThrough()]
			get { return this._relateCustomTwo; }
            protected set { this._relateCustomTwo = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relateCustomThree = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelateCustomThree
		{
			[DebuggerStepThrough()]
			get { return this._relateCustomThree; }
            protected set { this._relateCustomThree = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relateCustomFour = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelateCustomFour
		{
			[DebuggerStepThrough()]
			get { return this._relateCustomFour; }
            protected set { this._relateCustomFour = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relationProperty = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelationProperty
		{
			[DebuggerStepThrough()]
			get { return this._relationProperty; }
            protected set { this._relationProperty = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isChargeFee = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsChargeFee
		{
			[DebuggerStepThrough()]
			get { return this._isChargeFee; }
            protected set { this._isChargeFee = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _headImg = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string HeadImg
		{
			[DebuggerStepThrough()]
			get { return this._headImg; }
            protected set { this._headImg = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _interesting = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Interesting
		{
			[DebuggerStepThrough()]
			get { return this._interesting; }
            protected set { this._interesting = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _consumeMore = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ConsumeMore
		{
			[DebuggerStepThrough()]
			get { return this._consumeMore; }
            protected set { this._consumeMore = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _belongTeam = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BelongTeam
		{
			[DebuggerStepThrough()]
			get { return this._belongTeam; }
            protected set { this._belongTeam = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _oneCardNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OneCardNumber
		{
			[DebuggerStepThrough()]
			get { return this._oneCardNumber; }
            protected set { this._oneCardNumber = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeForMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeForMan
		{
			[DebuggerStepThrough()]
			get { return this._chargeForMan; }
            protected set { this._chargeForMan = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDefault = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDefault
		{
			[DebuggerStepThrough()]
			get { return this._isDefault; }
            protected set { this._isDefault = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomTypeName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomTypeName
		{
			[DebuggerStepThrough()]
			get { return this._roomTypeName; }
            protected set { this._roomTypeName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomStateName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomStateName
		{
			[DebuggerStepThrough()]
			get { return this._roomStateName; }
            protected set { this._roomStateName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomPropertyName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomPropertyName
		{
			[DebuggerStepThrough()]
			get { return this._roomPropertyName; }
            protected set { this._roomPropertyName = value;}
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
            protected set { this._roomStateID = value;}
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
            protected set { this._roomTypeID = value;}
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
            protected set { this._roomPropertyID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _companyName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CompanyName
		{
			[DebuggerStepThrough()]
			get { return this._companyName; }
            protected set { this._companyName = value;}
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
		private bool _isChargeMan = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsChargeMan
		{
			[DebuggerStepThrough()]
			get { return this._isChargeMan; }
            protected set { this._isChargeMan = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relateID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelateID
		{
			[DebuggerStepThrough()]
			get { return this._relateID; }
            protected set { this._relateID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomBasicRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomBasicRemark
		{
			[DebuggerStepThrough()]
			get { return this._roomBasicRemark; }
            protected set { this._roomBasicRemark = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomPhoneRelationRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomPhoneRelationRemark
		{
			[DebuggerStepThrough()]
			get { return this._roomPhoneRelationRemark; }
            protected set { this._roomPhoneRelationRemark = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewRoomBasic() { }
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
	[ViewRoomBasic].[ID],
	[ViewRoomBasic].[RoomOwner],
	[ViewRoomBasic].[OwnerPhone],
	[ViewRoomBasic].[BuildingArea],
	[ViewRoomBasic].[RoomState],
	[ViewRoomBasic].[AddTime],
	[ViewRoomBasic].[PaymentTime],
	[ViewRoomBasic].[BuildingNumber],
	[ViewRoomBasic].[RoomType],
	[ViewRoomBasic].[RoomLayout],
	[ViewRoomBasic].[OwnerIDCard],
	[ViewRoomBasic].[RentName],
	[ViewRoomBasic].[RentPhoneNumber],
	[ViewRoomBasic].[RentIDCard],
	[ViewRoomBasic].[HistoryBill],
	[ViewRoomBasic].[EndTime],
	[ViewRoomBasic].[isParent],
	[ViewRoomBasic].[FullName],
	[ViewRoomBasic].[RoomID],
	[ViewRoomBasic].[Name],
	[ViewRoomBasic].[RoomProperty],
	[ViewRoomBasic].[PName],
	[ViewRoomBasic].[AllParentID],
	[ViewRoomBasic].[Remark],
	[ViewRoomBasic].[CustomFour],
	[ViewRoomBasic].[CustomThree],
	[ViewRoomBasic].[CustomTwo],
	[ViewRoomBasic].[CustomOne],
	[ViewRoomBasic].[CertificateTime],
	[ViewRoomBasic].[ChanQuanNo],
	[ViewRoomBasic].[FenTanCoefficient],
	[ViewRoomBasic].[FunctionCoefficient],
	[ViewRoomBasic].[PeiTaoArea],
	[ViewRoomBasic].[UseArea],
	[ViewRoomBasic].[ChanQuanArea],
	[ViewRoomBasic].[GonTanArea],
	[ViewRoomBasic].[BuildInArea],
	[ViewRoomBasic].[BuildOutArea],
	[ViewRoomBasic].[ZxEndTime],
	[ViewRoomBasic].[ZxStartTime],
	[ViewRoomBasic].[ContractArea],
	[ViewRoomBasic].[MoveInTime],
	[ViewRoomBasic].[RelatePhoneNumber],
	[ViewRoomBasic].[RelationName],
	[ViewRoomBasic].[RelationIDCard],
	[ViewRoomBasic].[RelationType],
	[ViewRoomBasic].[ContractStartTime],
	[ViewRoomBasic].[ContractEndTime],
	[ViewRoomBasic].[BrandInfo],
	[ViewRoomBasic].[ContractNote],
	[ViewRoomBasic].[DefaultOrder],
	[ViewRoomBasic].[IsLocked],
	[ViewRoomBasic].[IDCardType],
	[ViewRoomBasic].[Birthday],
	[ViewRoomBasic].[EmailAddress],
	[ViewRoomBasic].[HomeAddress],
	[ViewRoomBasic].[OfficeAddress],
	[ViewRoomBasic].[BankName],
	[ViewRoomBasic].[BankAccountName],
	[ViewRoomBasic].[BankAccountNo],
	[ViewRoomBasic].[RelateCustomOne],
	[ViewRoomBasic].[RelateCustomTwo],
	[ViewRoomBasic].[RelateCustomThree],
	[ViewRoomBasic].[RelateCustomFour],
	[ViewRoomBasic].[RelationProperty],
	[ViewRoomBasic].[IsChargeFee],
	[ViewRoomBasic].[HeadImg],
	[ViewRoomBasic].[Interesting],
	[ViewRoomBasic].[ConsumeMore],
	[ViewRoomBasic].[BelongTeam],
	[ViewRoomBasic].[OneCardNumber],
	[ViewRoomBasic].[ChargeForMan],
	[ViewRoomBasic].[IsDefault],
	[ViewRoomBasic].[RoomTypeName],
	[ViewRoomBasic].[RoomStateName],
	[ViewRoomBasic].[RoomPropertyName],
	[ViewRoomBasic].[RoomStateID],
	[ViewRoomBasic].[RoomTypeID],
	[ViewRoomBasic].[RoomPropertyID],
	[ViewRoomBasic].[CompanyName],
	[ViewRoomBasic].[ContractID],
	[ViewRoomBasic].[IsChargeMan],
	[ViewRoomBasic].[RelateID],
	[ViewRoomBasic].[RoomBasicRemark],
	[ViewRoomBasic].[RoomPhoneRelationRemark]
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
                return "ViewRoomBasic";
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
		/// Gets a collection ViewRoomBasic objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewRoomBasic objects.</returns>
		public static EntityList<ViewRoomBasic> GetViewRoomBasics()
		{
			string commandText = @"
SELECT " + ViewRoomBasic.SelectFieldList + "FROM [dbo].[ViewRoomBasic] " + ViewRoomBasic.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewRoomBasic>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewRoomBasic objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewRoomBasic objects.</returns>
        public static EntityList<ViewRoomBasic> GetViewRoomBasics(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewRoomBasic>(SelectFieldList, "FROM [dbo].[ViewRoomBasic]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewRoomBasic objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewRoomBasic objects.</returns>
        public static EntityList<ViewRoomBasic> GetViewRoomBasics(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewRoomBasic>(SelectFieldList, "FROM [dbo].[ViewRoomBasic]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewRoomBasic objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewRoomBasicCount()
        {
            return GetViewRoomBasicCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewRoomBasic objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewRoomBasicCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewRoomBasic] " + where;

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
		/// Gets a collection ViewRoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewRoomBasic objects.</returns>
		protected static EntityList<ViewRoomBasic> GetViewRoomBasics(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewRoomBasics(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomBasic objects.</returns>
		protected static EntityList<ViewRoomBasic> GetViewRoomBasics(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewRoomBasics(string.Empty, where, parameters, ViewRoomBasic.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomBasic objects.</returns>
		protected static EntityList<ViewRoomBasic> GetViewRoomBasics(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewRoomBasics(prefix, where, parameters, ViewRoomBasic.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomBasic objects.</returns>
		protected static EntityList<ViewRoomBasic> GetViewRoomBasics(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewRoomBasics(string.Empty, where, parameters, ViewRoomBasic.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomBasic objects.</returns>
		protected static EntityList<ViewRoomBasic> GetViewRoomBasics(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewRoomBasics(prefix, where, parameters, ViewRoomBasic.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomBasic objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewRoomBasic objects.</returns>
		protected static EntityList<ViewRoomBasic> GetViewRoomBasics(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewRoomBasic.SelectFieldList + "FROM [dbo].[ViewRoomBasic] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewRoomBasic>(reader);
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
        protected static EntityList<ViewRoomBasic> GetViewRoomBasics(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewRoomBasic>(SelectFieldList, "FROM [dbo].[ViewRoomBasic] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewRoomBasicProperties
		{
			public const string ID = "ID";
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
			public const string isParent = "isParent";
			public const string FullName = "FullName";
			public const string RoomID = "RoomID";
			public const string Name = "Name";
			public const string RoomProperty = "RoomProperty";
			public const string PName = "PName";
			public const string AllParentID = "AllParentID";
			public const string Remark = "Remark";
			public const string CustomFour = "CustomFour";
			public const string CustomThree = "CustomThree";
			public const string CustomTwo = "CustomTwo";
			public const string CustomOne = "CustomOne";
			public const string CertificateTime = "CertificateTime";
			public const string ChanQuanNo = "ChanQuanNo";
			public const string FenTanCoefficient = "FenTanCoefficient";
			public const string FunctionCoefficient = "FunctionCoefficient";
			public const string PeiTaoArea = "PeiTaoArea";
			public const string UseArea = "UseArea";
			public const string ChanQuanArea = "ChanQuanArea";
			public const string GonTanArea = "GonTanArea";
			public const string BuildInArea = "BuildInArea";
			public const string BuildOutArea = "BuildOutArea";
			public const string ZxEndTime = "ZxEndTime";
			public const string ZxStartTime = "ZxStartTime";
			public const string ContractArea = "ContractArea";
			public const string MoveInTime = "MoveInTime";
			public const string RelatePhoneNumber = "RelatePhoneNumber";
			public const string RelationName = "RelationName";
			public const string RelationIDCard = "RelationIDCard";
			public const string RelationType = "RelationType";
			public const string ContractStartTime = "ContractStartTime";
			public const string ContractEndTime = "ContractEndTime";
			public const string BrandInfo = "BrandInfo";
			public const string ContractNote = "ContractNote";
			public const string DefaultOrder = "DefaultOrder";
			public const string IsLocked = "IsLocked";
			public const string IDCardType = "IDCardType";
			public const string Birthday = "Birthday";
			public const string EmailAddress = "EmailAddress";
			public const string HomeAddress = "HomeAddress";
			public const string OfficeAddress = "OfficeAddress";
			public const string BankName = "BankName";
			public const string BankAccountName = "BankAccountName";
			public const string BankAccountNo = "BankAccountNo";
			public const string RelateCustomOne = "RelateCustomOne";
			public const string RelateCustomTwo = "RelateCustomTwo";
			public const string RelateCustomThree = "RelateCustomThree";
			public const string RelateCustomFour = "RelateCustomFour";
			public const string RelationProperty = "RelationProperty";
			public const string IsChargeFee = "IsChargeFee";
			public const string HeadImg = "HeadImg";
			public const string Interesting = "Interesting";
			public const string ConsumeMore = "ConsumeMore";
			public const string BelongTeam = "BelongTeam";
			public const string OneCardNumber = "OneCardNumber";
			public const string ChargeForMan = "ChargeForMan";
			public const string IsDefault = "IsDefault";
			public const string RoomTypeName = "RoomTypeName";
			public const string RoomStateName = "RoomStateName";
			public const string RoomPropertyName = "RoomPropertyName";
			public const string RoomStateID = "RoomStateID";
			public const string RoomTypeID = "RoomTypeID";
			public const string RoomPropertyID = "RoomPropertyID";
			public const string CompanyName = "CompanyName";
			public const string ContractID = "ContractID";
			public const string IsChargeMan = "IsChargeMan";
			public const string RelateID = "RelateID";
			public const string RoomBasicRemark = "RoomBasicRemark";
			public const string RoomPhoneRelationRemark = "RoomPhoneRelationRemark";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
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
    			 {"isParent" , "bool:"},
    			 {"FullName" , "string:"},
    			 {"RoomID" , "int:"},
    			 {"Name" , "string:"},
    			 {"RoomProperty" , "string:"},
    			 {"PName" , "string:"},
    			 {"AllParentID" , "string:"},
    			 {"Remark" , "string:"},
    			 {"CustomFour" , "string:"},
    			 {"CustomThree" , "string:"},
    			 {"CustomTwo" , "string:"},
    			 {"CustomOne" , "string:"},
    			 {"CertificateTime" , "DateTime:"},
    			 {"ChanQuanNo" , "string:"},
    			 {"FenTanCoefficient" , "decimal:"},
    			 {"FunctionCoefficient" , "decimal:"},
    			 {"PeiTaoArea" , "decimal:"},
    			 {"UseArea" , "decimal:"},
    			 {"ChanQuanArea" , "decimal:"},
    			 {"GonTanArea" , "decimal:"},
    			 {"BuildInArea" , "decimal:"},
    			 {"BuildOutArea" , "decimal:"},
    			 {"ZxEndTime" , "DateTime:"},
    			 {"ZxStartTime" , "DateTime:"},
    			 {"ContractArea" , "decimal:"},
    			 {"MoveInTime" , "DateTime:"},
    			 {"RelatePhoneNumber" , "string:"},
    			 {"RelationName" , "string:"},
    			 {"RelationIDCard" , "string:"},
    			 {"RelationType" , "string:"},
    			 {"ContractStartTime" , "DateTime:"},
    			 {"ContractEndTime" , "DateTime:"},
    			 {"BrandInfo" , "string:"},
    			 {"ContractNote" , "string:"},
    			 {"DefaultOrder" , "string:"},
    			 {"IsLocked" , "bool:"},
    			 {"IDCardType" , "int:"},
    			 {"Birthday" , "DateTime:"},
    			 {"EmailAddress" , "string:"},
    			 {"HomeAddress" , "string:"},
    			 {"OfficeAddress" , "string:"},
    			 {"BankName" , "string:"},
    			 {"BankAccountName" , "string:"},
    			 {"BankAccountNo" , "string:"},
    			 {"RelateCustomOne" , "string:"},
    			 {"RelateCustomTwo" , "string:"},
    			 {"RelateCustomThree" , "string:"},
    			 {"RelateCustomFour" , "string:"},
    			 {"RelationProperty" , "string:"},
    			 {"IsChargeFee" , "bool:"},
    			 {"HeadImg" , "string:"},
    			 {"Interesting" , "string:"},
    			 {"ConsumeMore" , "string:"},
    			 {"BelongTeam" , "string:"},
    			 {"OneCardNumber" , "string:"},
    			 {"ChargeForMan" , "string:"},
    			 {"IsDefault" , "bool:"},
    			 {"RoomTypeName" , "string:"},
    			 {"RoomStateName" , "string:"},
    			 {"RoomPropertyName" , "string:"},
    			 {"RoomStateID" , "int:"},
    			 {"RoomTypeID" , "int:"},
    			 {"RoomPropertyID" , "int:"},
    			 {"CompanyName" , "string:"},
    			 {"ContractID" , "int:"},
    			 {"IsChargeMan" , "bool:"},
    			 {"RelateID" , "string:"},
    			 {"RoomBasicRemark" , "string:"},
    			 {"RoomPhoneRelationRemark" , "string:"},
            };
		}
		#endregion
	}
}
