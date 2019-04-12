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
	/// This object represents the properties and methods of a ViewMall_OrderItem.
	/// </summary>
	[Serializable()]
	public partial class ViewMall_OrderItem 
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
		private int _orderID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int OrderID
		{
			[DebuggerStepThrough()]
			get { return this._orderID; }
            protected set { this._orderID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _productID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ProductID
		{
			[DebuggerStepThrough()]
			get { return this._productID; }
            protected set { this._productID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _productName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProductName
		{
			[DebuggerStepThrough()]
			get { return this._productName; }
            protected set { this._productName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _quantity = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int Quantity
		{
			[DebuggerStepThrough()]
			get { return this._quantity; }
            protected set { this._quantity = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _price = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal Price
		{
			[DebuggerStepThrough()]
			get { return this._price; }
            protected set { this._price = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _businessID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int BusinessID
		{
			[DebuggerStepThrough()]
			get { return this._businessID; }
            protected set { this._businessID = value;}
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
		private string _addMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string AddMan
		{
			[DebuggerStepThrough()]
			get { return this._addMan; }
            protected set { this._addMan = value;}
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
		private int _variantID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int VariantID
		{
			[DebuggerStepThrough()]
			get { return this._variantID; }
            protected set { this._variantID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _variantTitle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string VariantTitle
		{
			[DebuggerStepThrough()]
			get { return this._variantTitle; }
            protected set { this._variantTitle = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _variantName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string VariantName
		{
			[DebuggerStepThrough()]
			get { return this._variantName; }
            protected set { this._variantName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalPrice
		{
			[DebuggerStepThrough()]
			get { return this._totalPrice; }
            protected set { this._totalPrice = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _businessName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BusinessName
		{
			[DebuggerStepThrough()]
			get { return this._businessName; }
            protected set { this._businessName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _productTypeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProductTypeID
		{
			[DebuggerStepThrough()]
			get { return this._productTypeID; }
            protected set { this._productTypeID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _orderNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OrderNumber
		{
			[DebuggerStepThrough()]
			get { return this._orderNumber; }
            protected set { this._orderNumber = value;}
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
            protected set { this._tradeNo = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _orderType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OrderType
		{
			[DebuggerStepThrough()]
			get { return this._orderType; }
            protected set { this._orderType = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalCost
		{
			[DebuggerStepThrough()]
			get { return this._totalCost; }
            protected set { this._totalCost = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _orderStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OrderStatus
		{
			[DebuggerStepThrough()]
			get { return this._orderStatus; }
            protected set { this._orderStatus = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _userID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int UserID
		{
			[DebuggerStepThrough()]
			get { return this._userID; }
            protected set { this._userID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _userName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string UserName
		{
			[DebuggerStepThrough()]
			get { return this._userName; }
            protected set { this._userName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _addressID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int AddressID
		{
			[DebuggerStepThrough()]
			get { return this._addressID; }
            protected set { this._addressID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addressProvince = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddressProvince
		{
			[DebuggerStepThrough()]
			get { return this._addressProvince; }
            protected set { this._addressProvince = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addressCity = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddressCity
		{
			[DebuggerStepThrough()]
			get { return this._addressCity; }
            protected set { this._addressCity = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addressDistrict = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddressDistrict
		{
			[DebuggerStepThrough()]
			get { return this._addressDistrict; }
            protected set { this._addressDistrict = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addressDetailInfo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddressDetailInfo
		{
			[DebuggerStepThrough()]
			get { return this._addressDetailInfo; }
            protected set { this._addressDetailInfo = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _orderAddTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime OrderAddTime
		{
			[DebuggerStepThrough()]
			get { return this._orderAddTime; }
            protected set { this._orderAddTime = value;}
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
		private DateTime _payTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime PayTime
		{
			[DebuggerStepThrough()]
			get { return this._payTime; }
            protected set { this._payTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _shipTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ShipTime
		{
			[DebuggerStepThrough()]
			get { return this._shipTime; }
            protected set { this._shipTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _completeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime CompleteTime
		{
			[DebuggerStepThrough()]
			get { return this._completeTime; }
            protected set { this._completeTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _closeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime CloseTime
		{
			[DebuggerStepThrough()]
			get { return this._closeTime; }
            protected set { this._closeTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _userNote = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string UserNote
		{
			[DebuggerStepThrough()]
			get { return this._userNote; }
            protected set { this._userNote = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addressUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddressUserName
		{
			[DebuggerStepThrough()]
			get { return this._addressUserName; }
            protected set { this._addressUserName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addressPhoneNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddressPhoneNumber
		{
			[DebuggerStepThrough()]
			get { return this._addressPhoneNumber; }
            protected set { this._addressPhoneNumber = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _pin_OrganiserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Pin_OrganiserID
		{
			[DebuggerStepThrough()]
			get { return this._pin_OrganiserID; }
            protected set { this._pin_OrganiserID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _orderProductTypeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OrderProductTypeID
		{
			[DebuggerStepThrough()]
			get { return this._orderProductTypeID; }
            protected set { this._orderProductTypeID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _pin_UserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Pin_UserID
		{
			[DebuggerStepThrough()]
			get { return this._pin_UserID; }
            protected set { this._pin_UserID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _payUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PayUserName
		{
			[DebuggerStepThrough()]
			get { return this._payUserName; }
            protected set { this._payUserName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _shipTrackNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ShipTrackNo
		{
			[DebuggerStepThrough()]
			get { return this._shipTrackNo; }
            protected set { this._shipTrackNo = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _shipCompanyName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ShipCompanyName
		{
			[DebuggerStepThrough()]
			get { return this._shipCompanyName; }
            protected set { this._shipCompanyName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _shipUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ShipUserName
		{
			[DebuggerStepThrough()]
			get { return this._shipUserName; }
            protected set { this._shipUserName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _completeUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CompleteUserName
		{
			[DebuggerStepThrough()]
			get { return this._completeUserName; }
            protected set { this._completeUserName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _closeUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CloseUserName
		{
			[DebuggerStepThrough()]
			get { return this._closeUserName; }
            protected set { this._closeUserName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _paymentMethod = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PaymentMethod
		{
			[DebuggerStepThrough()]
			get { return this._paymentMethod; }
            protected set { this._paymentMethod = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _couponID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CouponID
		{
			[DebuggerStepThrough()]
			get { return this._couponID; }
            protected set { this._couponID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _couponAmount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal CouponAmount
		{
			[DebuggerStepThrough()]
			get { return this._couponAmount; }
            protected set { this._couponAmount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _productAmount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ProductAmount
		{
			[DebuggerStepThrough()]
			get { return this._productAmount; }
            protected set { this._productAmount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDeleted = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDeleted
		{
			[DebuggerStepThrough()]
			get { return this._isDeleted; }
            protected set { this._isDeleted = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _deleteTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime DeleteTime
		{
			[DebuggerStepThrough()]
			get { return this._deleteTime; }
            protected set { this._deleteTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _deleteUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DeleteUserName
		{
			[DebuggerStepThrough()]
			get { return this._deleteUserName; }
            protected set { this._deleteUserName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isClosed = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsClosed
		{
			[DebuggerStepThrough()]
			get { return this._isClosed; }
            protected set { this._isClosed = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _refundTrackNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RefundTrackNo
		{
			[DebuggerStepThrough()]
			get { return this._refundTrackNo; }
            protected set { this._refundTrackNo = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _refundRequestTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime RefundRequestTime
		{
			[DebuggerStepThrough()]
			get { return this._refundRequestTime; }
            protected set { this._refundRequestTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _refundTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime RefundTime
		{
			[DebuggerStepThrough()]
			get { return this._refundTime; }
            protected set { this._refundTime = value;}
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
		private int _addressProjectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int AddressProjectID
		{
			[DebuggerStepThrough()]
			get { return this._addressProjectID; }
            protected set { this._addressProjectID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _addressRoomID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int AddressRoomID
		{
			[DebuggerStepThrough()]
			get { return this._addressRoomID; }
            protected set { this._addressRoomID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _refundReason = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RefundReason
		{
			[DebuggerStepThrough()]
			get { return this._refundReason; }
            protected set { this._refundReason = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewMall_OrderItem() { }
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
	[ViewMall_OrderItem].[ID],
	[ViewMall_OrderItem].[OrderID],
	[ViewMall_OrderItem].[ProductID],
	[ViewMall_OrderItem].[ProductName],
	[ViewMall_OrderItem].[Quantity],
	[ViewMall_OrderItem].[Price],
	[ViewMall_OrderItem].[BusinessID],
	[ViewMall_OrderItem].[AddTime],
	[ViewMall_OrderItem].[AddMan],
	[ViewMall_OrderItem].[RoomID],
	[ViewMall_OrderItem].[HistoryID],
	[ViewMall_OrderItem].[RoomName],
	[ViewMall_OrderItem].[ChargeID],
	[ViewMall_OrderItem].[ChargeName],
	[ViewMall_OrderItem].[StartTime],
	[ViewMall_OrderItem].[EndTime],
	[ViewMall_OrderItem].[VariantID],
	[ViewMall_OrderItem].[VariantTitle],
	[ViewMall_OrderItem].[VariantName],
	[ViewMall_OrderItem].[TotalPrice],
	[ViewMall_OrderItem].[BusinessName],
	[ViewMall_OrderItem].[ProductTypeID],
	[ViewMall_OrderItem].[OrderNumber],
	[ViewMall_OrderItem].[TradeNo],
	[ViewMall_OrderItem].[OrderType],
	[ViewMall_OrderItem].[TotalCost],
	[ViewMall_OrderItem].[OrderStatus],
	[ViewMall_OrderItem].[UserID],
	[ViewMall_OrderItem].[UserName],
	[ViewMall_OrderItem].[AddressID],
	[ViewMall_OrderItem].[AddressProvince],
	[ViewMall_OrderItem].[AddressCity],
	[ViewMall_OrderItem].[AddressDistrict],
	[ViewMall_OrderItem].[AddressDetailInfo],
	[ViewMall_OrderItem].[OrderAddTime],
	[ViewMall_OrderItem].[PrintID],
	[ViewMall_OrderItem].[PayTime],
	[ViewMall_OrderItem].[ShipTime],
	[ViewMall_OrderItem].[CompleteTime],
	[ViewMall_OrderItem].[CloseTime],
	[ViewMall_OrderItem].[UserNote],
	[ViewMall_OrderItem].[AddressUserName],
	[ViewMall_OrderItem].[AddressPhoneNumber],
	[ViewMall_OrderItem].[Pin_OrganiserID],
	[ViewMall_OrderItem].[OrderProductTypeID],
	[ViewMall_OrderItem].[Pin_UserID],
	[ViewMall_OrderItem].[PayUserName],
	[ViewMall_OrderItem].[ShipTrackNo],
	[ViewMall_OrderItem].[ShipCompanyName],
	[ViewMall_OrderItem].[ShipUserName],
	[ViewMall_OrderItem].[CompleteUserName],
	[ViewMall_OrderItem].[CloseUserName],
	[ViewMall_OrderItem].[PaymentMethod],
	[ViewMall_OrderItem].[CouponID],
	[ViewMall_OrderItem].[CouponAmount],
	[ViewMall_OrderItem].[ProductAmount],
	[ViewMall_OrderItem].[IsDeleted],
	[ViewMall_OrderItem].[DeleteTime],
	[ViewMall_OrderItem].[DeleteUserName],
	[ViewMall_OrderItem].[IsClosed],
	[ViewMall_OrderItem].[RefundTrackNo],
	[ViewMall_OrderItem].[RefundRequestTime],
	[ViewMall_OrderItem].[RefundTime],
	[ViewMall_OrderItem].[CategoryName],
	[ViewMall_OrderItem].[CategoryID],
	[ViewMall_OrderItem].[AddressProjectID],
	[ViewMall_OrderItem].[AddressRoomID],
	[ViewMall_OrderItem].[RefundReason]
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
                return "ViewMall_OrderItem";
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
		/// Gets a collection ViewMall_OrderItem objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewMall_OrderItem objects.</returns>
		public static EntityList<ViewMall_OrderItem> GetViewMall_OrderItems()
		{
			string commandText = @"
SELECT " + ViewMall_OrderItem.SelectFieldList + "FROM [dbo].[ViewMall_OrderItem] " + ViewMall_OrderItem.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewMall_OrderItem>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewMall_OrderItem objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewMall_OrderItem objects.</returns>
        public static EntityList<ViewMall_OrderItem> GetViewMall_OrderItems(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewMall_OrderItem>(SelectFieldList, "FROM [dbo].[ViewMall_OrderItem]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewMall_OrderItem objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewMall_OrderItem objects.</returns>
        public static EntityList<ViewMall_OrderItem> GetViewMall_OrderItems(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewMall_OrderItem>(SelectFieldList, "FROM [dbo].[ViewMall_OrderItem]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewMall_OrderItem objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewMall_OrderItemCount()
        {
            return GetViewMall_OrderItemCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewMall_OrderItem objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewMall_OrderItemCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewMall_OrderItem] " + where;

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
		/// Gets a collection ViewMall_OrderItem objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewMall_OrderItem objects.</returns>
		protected static EntityList<ViewMall_OrderItem> GetViewMall_OrderItems(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewMall_OrderItems(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewMall_OrderItem objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewMall_OrderItem objects.</returns>
		protected static EntityList<ViewMall_OrderItem> GetViewMall_OrderItems(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewMall_OrderItems(string.Empty, where, parameters, ViewMall_OrderItem.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewMall_OrderItem objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewMall_OrderItem objects.</returns>
		protected static EntityList<ViewMall_OrderItem> GetViewMall_OrderItems(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewMall_OrderItems(prefix, where, parameters, ViewMall_OrderItem.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewMall_OrderItem objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewMall_OrderItem objects.</returns>
		protected static EntityList<ViewMall_OrderItem> GetViewMall_OrderItems(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewMall_OrderItems(string.Empty, where, parameters, ViewMall_OrderItem.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewMall_OrderItem objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewMall_OrderItem objects.</returns>
		protected static EntityList<ViewMall_OrderItem> GetViewMall_OrderItems(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewMall_OrderItems(prefix, where, parameters, ViewMall_OrderItem.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewMall_OrderItem objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewMall_OrderItem objects.</returns>
		protected static EntityList<ViewMall_OrderItem> GetViewMall_OrderItems(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewMall_OrderItem.SelectFieldList + "FROM [dbo].[ViewMall_OrderItem] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewMall_OrderItem>(reader);
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
        protected static EntityList<ViewMall_OrderItem> GetViewMall_OrderItems(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewMall_OrderItem>(SelectFieldList, "FROM [dbo].[ViewMall_OrderItem] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewMall_OrderItemProperties
		{
			public const string ID = "ID";
			public const string OrderID = "OrderID";
			public const string ProductID = "ProductID";
			public const string ProductName = "ProductName";
			public const string Quantity = "Quantity";
			public const string Price = "Price";
			public const string BusinessID = "BusinessID";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string RoomID = "RoomID";
			public const string HistoryID = "HistoryID";
			public const string RoomName = "RoomName";
			public const string ChargeID = "ChargeID";
			public const string ChargeName = "ChargeName";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string VariantID = "VariantID";
			public const string VariantTitle = "VariantTitle";
			public const string VariantName = "VariantName";
			public const string TotalPrice = "TotalPrice";
			public const string BusinessName = "BusinessName";
			public const string ProductTypeID = "ProductTypeID";
			public const string OrderNumber = "OrderNumber";
			public const string TradeNo = "TradeNo";
			public const string OrderType = "OrderType";
			public const string TotalCost = "TotalCost";
			public const string OrderStatus = "OrderStatus";
			public const string UserID = "UserID";
			public const string UserName = "UserName";
			public const string AddressID = "AddressID";
			public const string AddressProvince = "AddressProvince";
			public const string AddressCity = "AddressCity";
			public const string AddressDistrict = "AddressDistrict";
			public const string AddressDetailInfo = "AddressDetailInfo";
			public const string OrderAddTime = "OrderAddTime";
			public const string PrintID = "PrintID";
			public const string PayTime = "PayTime";
			public const string ShipTime = "ShipTime";
			public const string CompleteTime = "CompleteTime";
			public const string CloseTime = "CloseTime";
			public const string UserNote = "UserNote";
			public const string AddressUserName = "AddressUserName";
			public const string AddressPhoneNumber = "AddressPhoneNumber";
			public const string Pin_OrganiserID = "Pin_OrganiserID";
			public const string OrderProductTypeID = "OrderProductTypeID";
			public const string Pin_UserID = "Pin_UserID";
			public const string PayUserName = "PayUserName";
			public const string ShipTrackNo = "ShipTrackNo";
			public const string ShipCompanyName = "ShipCompanyName";
			public const string ShipUserName = "ShipUserName";
			public const string CompleteUserName = "CompleteUserName";
			public const string CloseUserName = "CloseUserName";
			public const string PaymentMethod = "PaymentMethod";
			public const string CouponID = "CouponID";
			public const string CouponAmount = "CouponAmount";
			public const string ProductAmount = "ProductAmount";
			public const string IsDeleted = "IsDeleted";
			public const string DeleteTime = "DeleteTime";
			public const string DeleteUserName = "DeleteUserName";
			public const string IsClosed = "IsClosed";
			public const string RefundTrackNo = "RefundTrackNo";
			public const string RefundRequestTime = "RefundRequestTime";
			public const string RefundTime = "RefundTime";
			public const string CategoryName = "CategoryName";
			public const string CategoryID = "CategoryID";
			public const string AddressProjectID = "AddressProjectID";
			public const string AddressRoomID = "AddressRoomID";
			public const string RefundReason = "RefundReason";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OrderID" , "int:"},
    			 {"ProductID" , "int:"},
    			 {"ProductName" , "string:"},
    			 {"Quantity" , "int:"},
    			 {"Price" , "decimal:"},
    			 {"BusinessID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"RoomID" , "int:"},
    			 {"HistoryID" , "int:"},
    			 {"RoomName" , "string:"},
    			 {"ChargeID" , "int:"},
    			 {"ChargeName" , "string:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"VariantID" , "int:"},
    			 {"VariantTitle" , "string:"},
    			 {"VariantName" , "string:"},
    			 {"TotalPrice" , "decimal:"},
    			 {"BusinessName" , "string:"},
    			 {"ProductTypeID" , "int:"},
    			 {"OrderNumber" , "string:"},
    			 {"TradeNo" , "string:"},
    			 {"OrderType" , "int:"},
    			 {"TotalCost" , "decimal:"},
    			 {"OrderStatus" , "int:"},
    			 {"UserID" , "int:"},
    			 {"UserName" , "string:"},
    			 {"AddressID" , "int:"},
    			 {"AddressProvince" , "string:"},
    			 {"AddressCity" , "string:"},
    			 {"AddressDistrict" , "string:"},
    			 {"AddressDetailInfo" , "string:"},
    			 {"OrderAddTime" , "DateTime:"},
    			 {"PrintID" , "int:"},
    			 {"PayTime" , "DateTime:"},
    			 {"ShipTime" , "DateTime:"},
    			 {"CompleteTime" , "DateTime:"},
    			 {"CloseTime" , "DateTime:"},
    			 {"UserNote" , "string:"},
    			 {"AddressUserName" , "string:"},
    			 {"AddressPhoneNumber" , "string:"},
    			 {"Pin_OrganiserID" , "int:"},
    			 {"OrderProductTypeID" , "int:"},
    			 {"Pin_UserID" , "int:"},
    			 {"PayUserName" , "string:"},
    			 {"ShipTrackNo" , "string:"},
    			 {"ShipCompanyName" , "string:"},
    			 {"ShipUserName" , "string:"},
    			 {"CompleteUserName" , "string:"},
    			 {"CloseUserName" , "string:"},
    			 {"PaymentMethod" , "string:"},
    			 {"CouponID" , "int:"},
    			 {"CouponAmount" , "decimal:"},
    			 {"ProductAmount" , "decimal:"},
    			 {"IsDeleted" , "bool:"},
    			 {"DeleteTime" , "DateTime:"},
    			 {"DeleteUserName" , "string:"},
    			 {"IsClosed" , "bool:"},
    			 {"RefundTrackNo" , "string:"},
    			 {"RefundRequestTime" , "DateTime:"},
    			 {"RefundTime" , "DateTime:"},
    			 {"CategoryName" , "string:"},
    			 {"CategoryID" , "int:"},
    			 {"AddressProjectID" , "int:"},
    			 {"AddressRoomID" , "int:"},
    			 {"RefundReason" , "string:"},
            };
		}
		#endregion
	}
}
