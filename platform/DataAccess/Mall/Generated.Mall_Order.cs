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
	/// This object represents the properties and methods of a Mall_Order.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_Order 
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
			set 
			{
				if (this._orderNumber != value) 
				{
					this._orderNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderNumber");
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
		private int _orderType = int.MinValue;
		/// <summary>
		/// 1-商品购买 2-物业缴费
		/// </summary>
        [Description("1-商品购买 2-物业缴费")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int OrderType
		{
			[DebuggerStepThrough()]
			get { return this._orderType; }
			set 
			{
				if (this._orderType != value) 
				{
					this._orderType = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal TotalCost
		{
			[DebuggerStepThrough()]
			get { return this._totalCost; }
			set 
			{
				if (this._totalCost != value) 
				{
					this._totalCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _orderStatus = int.MinValue;
		/// <summary>
		/// 1-待付款 2-已发货 3-已完成 4-已关闭 5-待发货 6-退款中 7-已退款
		/// </summary>
        [Description("1-待付款 2-已发货 3-已完成 4-已关闭 5-待发货 6-退款中 7-已退款")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int OrderStatus
		{
			[DebuggerStepThrough()]
			get { return this._orderStatus; }
			set 
			{
				if (this._orderStatus != value) 
				{
					this._orderStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _userID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int UserID
		{
			[DebuggerStepThrough()]
			get { return this._userID; }
			set 
			{
				if (this._userID != value) 
				{
					this._userID = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _userName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string UserName
		{
			[DebuggerStepThrough()]
			get { return this._userName; }
			set 
			{
				if (this._userName != value) 
				{
					this._userName = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserName");
				}
			}
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
			set 
			{
				if (this._addressID != value) 
				{
					this._addressID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressID");
				}
			}
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
			set 
			{
				if (this._addressProvince != value) 
				{
					this._addressProvince = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressProvince");
				}
			}
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
			set 
			{
				if (this._addressCity != value) 
				{
					this._addressCity = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressCity");
				}
			}
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
			set 
			{
				if (this._addressDistrict != value) 
				{
					this._addressDistrict = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressDistrict");
				}
			}
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
			set 
			{
				if (this._addressDetailInfo != value) 
				{
					this._addressDetailInfo = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressDetailInfo");
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
		private string _addUser = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string AddUser
		{
			[DebuggerStepThrough()]
			get { return this._addUser; }
			set 
			{
				if (this._addUser != value) 
				{
					this._addUser = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUser");
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
			set 
			{
				if (this._payTime != value) 
				{
					this._payTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("PayTime");
				}
			}
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
			set 
			{
				if (this._shipTime != value) 
				{
					this._shipTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ShipTime");
				}
			}
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
			set 
			{
				if (this._completeTime != value) 
				{
					this._completeTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("CompleteTime");
				}
			}
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
			set 
			{
				if (this._closeTime != value) 
				{
					this._closeTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("CloseTime");
				}
			}
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
			set 
			{
				if (this._userNote != value) 
				{
					this._userNote = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserNote");
				}
			}
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
			set 
			{
				if (this._addressUserName != value) 
				{
					this._addressUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressUserName");
				}
			}
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
			set 
			{
				if (this._addressPhoneNumber != value) 
				{
					this._addressPhoneNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressPhoneNumber");
				}
			}
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
			set 
			{
				if (this._productTypeID != value) 
				{
					this._productTypeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductTypeID");
				}
			}
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
			set 
			{
				if (this._pin_OrganiserID != value) 
				{
					this._pin_OrganiserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("Pin_OrganiserID");
				}
			}
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
			set 
			{
				if (this._pin_UserID != value) 
				{
					this._pin_UserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("Pin_UserID");
				}
			}
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
			set 
			{
				if (this._payUserName != value) 
				{
					this._payUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("PayUserName");
				}
			}
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
			set 
			{
				if (this._shipTrackNo != value) 
				{
					this._shipTrackNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("ShipTrackNo");
				}
			}
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
			set 
			{
				if (this._shipCompanyName != value) 
				{
					this._shipCompanyName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ShipCompanyName");
				}
			}
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
			set 
			{
				if (this._shipUserName != value) 
				{
					this._shipUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ShipUserName");
				}
			}
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
			set 
			{
				if (this._completeUserName != value) 
				{
					this._completeUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CompleteUserName");
				}
			}
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
			set 
			{
				if (this._closeUserName != value) 
				{
					this._closeUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CloseUserName");
				}
			}
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
			set 
			{
				if (this._paymentMethod != value) 
				{
					this._paymentMethod = value;
					this.IsDirty = true;	
					OnPropertyChanged("PaymentMethod");
				}
			}
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
			set 
			{
				if (this._couponID != value) 
				{
					this._couponID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CouponID");
				}
			}
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
			set 
			{
				if (this._couponAmount != value) 
				{
					this._couponAmount = value;
					this.IsDirty = true;	
					OnPropertyChanged("CouponAmount");
				}
			}
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
			set 
			{
				if (this._productAmount != value) 
				{
					this._productAmount = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductAmount");
				}
			}
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
			set 
			{
				if (this._isDeleted != value) 
				{
					this._isDeleted = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDeleted");
				}
			}
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
			set 
			{
				if (this._deleteTime != value) 
				{
					this._deleteTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeleteTime");
				}
			}
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
			set 
			{
				if (this._deleteUserName != value) 
				{
					this._deleteUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeleteUserName");
				}
			}
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
			set 
			{
				if (this._isClosed != value) 
				{
					this._isClosed = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsClosed");
				}
			}
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
			set 
			{
				if (this._refundTrackNo != value) 
				{
					this._refundTrackNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("RefundTrackNo");
				}
			}
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
			set 
			{
				if (this._refundRequestTime != value) 
				{
					this._refundRequestTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("RefundRequestTime");
				}
			}
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
			set 
			{
				if (this._refundTime != value) 
				{
					this._refundTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("RefundTime");
				}
			}
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
			set 
			{
				if (this._addressRoomID != value) 
				{
					this._addressRoomID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressRoomID");
				}
			}
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
			set 
			{
				if (this._addressProjectID != value) 
				{
					this._addressProjectID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressProjectID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _originalTotalCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal OriginalTotalCost
		{
			[DebuggerStepThrough()]
			get { return this._originalTotalCost; }
			set 
			{
				if (this._originalTotalCost != value) 
				{
					this._originalTotalCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("OriginalTotalCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _lastTotalCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal LastTotalCost
		{
			[DebuggerStepThrough()]
			get { return this._lastTotalCost; }
			set 
			{
				if (this._lastTotalCost != value) 
				{
					this._lastTotalCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("LastTotalCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sellerNote = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SellerNote
		{
			[DebuggerStepThrough()]
			get { return this._sellerNote; }
			set 
			{
				if (this._sellerNote != value) 
				{
					this._sellerNote = value;
					this.IsDirty = true;	
					OnPropertyChanged("SellerNote");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isShareOrder = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsShareOrder
		{
			[DebuggerStepThrough()]
			get { return this._isShareOrder; }
			set 
			{
				if (this._isShareOrder != value) 
				{
					this._isShareOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsShareOrder");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _addressProvinceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int AddressProvinceID
		{
			[DebuggerStepThrough()]
			get { return this._addressProvinceID; }
			set 
			{
				if (this._addressProvinceID != value) 
				{
					this._addressProvinceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressProvinceID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _shipRateAmount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ShipRateAmount
		{
			[DebuggerStepThrough()]
			get { return this._shipRateAmount; }
			set 
			{
				if (this._shipRateAmount != value) 
				{
					this._shipRateAmount = value;
					this.IsDirty = true;	
					OnPropertyChanged("ShipRateAmount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isReadNewOrder = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsReadNewOrder
		{
			[DebuggerStepThrough()]
			get { return this._isReadNewOrder; }
			set 
			{
				if (this._isReadNewOrder != value) 
				{
					this._isReadNewOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsReadNewOrder");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isReadRefundOrder = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsReadRefundOrder
		{
			[DebuggerStepThrough()]
			get { return this._isReadRefundOrder; }
			set 
			{
				if (this._isReadRefundOrder != value) 
				{
					this._isReadRefundOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsReadRefundOrder");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _shareUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ShareUserID
		{
			[DebuggerStepThrough()]
			get { return this._shareUserID; }
			set 
			{
				if (this._shareUserID != value) 
				{
					this._shareUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ShareUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _couponUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CouponUserID
		{
			[DebuggerStepThrough()]
			get { return this._couponUserID; }
			set 
			{
				if (this._couponUserID != value) 
				{
					this._couponUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CouponUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _shipRateID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ShipRateID
		{
			[DebuggerStepThrough()]
			get { return this._shipRateID; }
			set 
			{
				if (this._shipRateID != value) 
				{
					this._shipRateID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ShipRateID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _shipRateName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ShipRateName
		{
			[DebuggerStepThrough()]
			get { return this._shipRateName; }
			set 
			{
				if (this._shipRateName != value) 
				{
					this._shipRateName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ShipRateName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _totalSalePoint = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TotalSalePoint
		{
			[DebuggerStepThrough()]
			get { return this._totalSalePoint; }
			set 
			{
				if (this._totalSalePoint != value) 
				{
					this._totalSalePoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalSalePoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _totalVIPSalePoint = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TotalVIPSalePoint
		{
			[DebuggerStepThrough()]
			get { return this._totalVIPSalePoint; }
			set 
			{
				if (this._totalVIPSalePoint != value) 
				{
					this._totalVIPSalePoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalVIPSalePoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAPPUserSent = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAPPUserSent
		{
			[DebuggerStepThrough()]
			get { return this._isAPPUserSent; }
			set 
			{
				if (this._isAPPUserSent != value) 
				{
					this._isAPPUserSent = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAPPUserSent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isCanGrab = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsCanGrab
		{
			[DebuggerStepThrough()]
			get { return this._isCanGrab; }
			set 
			{
				if (this._isCanGrab != value) 
				{
					this._isCanGrab = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsCanGrab");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _grabSendTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime GrabSendTime
		{
			[DebuggerStepThrough()]
			get { return this._grabSendTime; }
			set 
			{
				if (this._grabSendTime != value) 
				{
					this._grabSendTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("GrabSendTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _grabStatus = int.MinValue;
		/// <summary>
        /// 0-不允许抢单 1-待抢单 2-派单成功 4-订单已接收，抢单结束
		/// </summary>
        [Description("0-不允许抢单 1-待抢单 2-派单成功 4-订单已接收，抢单结束")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int GrabStatus
		{
			[DebuggerStepThrough()]
			get { return this._grabStatus; }
			set 
			{
				if (this._grabStatus != value) 
				{
					this._grabStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("GrabStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _completeRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CompleteRemark
		{
			[DebuggerStepThrough()]
			get { return this._completeRemark; }
			set 
			{
				if (this._completeRemark != value) 
				{
					this._completeRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("CompleteRemark");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _purchaseType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PurchaseType
		{
			[DebuggerStepThrough()]
			get { return this._purchaseType; }
			set 
			{
				if (this._purchaseType != value) 
				{
					this._purchaseType = value;
					this.IsDirty = true;	
					OnPropertyChanged("PurchaseType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _totalSaleStaffPoint = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TotalSaleStaffPoint
		{
			[DebuggerStepThrough()]
			get { return this._totalSaleStaffPoint; }
			set 
			{
				if (this._totalSaleStaffPoint != value) 
				{
					this._totalSaleStaffPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalSaleStaffPoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _shipRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ShipRemark
		{
			[DebuggerStepThrough()]
			get { return this._shipRemark; }
			set 
			{
				if (this._shipRemark != value) 
				{
					this._shipRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("ShipRemark");
				}
			}
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
			set 
			{
				if (this._businessID != value) 
				{
					this._businessID = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isPaied = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsPaied
		{
			[DebuggerStepThrough()]
			get { return this._isPaied; }
			set 
			{
				if (this._isPaied != value) 
				{
					this._isPaied = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsPaied");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _businessCompleteTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime BusinessCompleteTime
		{
			[DebuggerStepThrough()]
			get { return this._businessCompleteTime; }
			set 
			{
				if (this._businessCompleteTime != value) 
				{
					this._businessCompleteTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessCompleteTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _shipDelivererName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ShipDelivererName
		{
			[DebuggerStepThrough()]
			get { return this._shipDelivererName; }
			set 
			{
				if (this._shipDelivererName != value) 
				{
					this._shipDelivererName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ShipDelivererName");
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
	[OrderNumber] nvarchar(100),
	[TradeNo] nvarchar(100),
	[OrderType] int,
	[TotalCost] decimal(18, 2),
	[OrderStatus] int,
	[UserID] int,
	[UserName] nvarchar(100),
	[AddressID] int,
	[AddressProvince] nvarchar(100),
	[AddressCity] nvarchar(100),
	[AddressDistrict] nvarchar(100),
	[AddressDetailInfo] nvarchar(500),
	[AddTime] datetime,
	[AddUser] nvarchar(100),
	[PrintID] int,
	[PayTime] datetime,
	[ShipTime] datetime,
	[CompleteTime] datetime,
	[CloseTime] datetime,
	[UserNote] nvarchar(500),
	[AddressUserName] nvarchar(100),
	[AddressPhoneNumber] nvarchar(100),
	[ProductTypeID] int,
	[Pin_OrganiserID] int,
	[Pin_UserID] int,
	[PayUserName] nvarchar(200),
	[ShipTrackNo] nvarchar(500),
	[ShipCompanyName] nvarchar(500),
	[ShipUserName] nvarchar(500),
	[CompleteUserName] nvarchar(500),
	[CloseUserName] nvarchar(500),
	[PaymentMethod] nvarchar(500),
	[CouponID] int,
	[CouponAmount] decimal(18, 2),
	[ProductAmount] decimal(18, 2),
	[IsDeleted] bit,
	[DeleteTime] datetime,
	[DeleteUserName] nvarchar(200),
	[IsClosed] bit,
	[RefundTrackNo] nvarchar(200),
	[RefundRequestTime] datetime,
	[RefundTime] datetime,
	[AddressRoomID] int,
	[AddressProjectID] int,
	[OriginalTotalCost] decimal(18, 2),
	[LastTotalCost] decimal(18, 2),
	[SellerNote] ntext,
	[IsShareOrder] bit,
	[AddressProvinceID] int,
	[ShipRateAmount] decimal(18, 2),
	[IsReadNewOrder] bit,
	[IsReadRefundOrder] bit,
	[ShareUserID] int,
	[CouponUserID] int,
	[ShipRateID] int,
	[ShipRateName] nvarchar(200),
	[TotalSalePoint] int,
	[TotalVIPSalePoint] int,
	[IsAPPUserSent] bit,
	[IsCanGrab] bit,
	[GrabSendTime] datetime,
	[GrabStatus] int,
	[CompleteRemark] ntext,
	[PurchaseType] int,
	[TotalSaleStaffPoint] int,
	[ShipRemark] ntext,
	[BusinessID] int,
	[IsPaied] bit,
	[BusinessCompleteTime] datetime,
	[ShipDelivererName] nvarchar(100)
);

INSERT INTO [dbo].[Mall_Order] (
	[Mall_Order].[OrderNumber],
	[Mall_Order].[TradeNo],
	[Mall_Order].[OrderType],
	[Mall_Order].[TotalCost],
	[Mall_Order].[OrderStatus],
	[Mall_Order].[UserID],
	[Mall_Order].[UserName],
	[Mall_Order].[AddressID],
	[Mall_Order].[AddressProvince],
	[Mall_Order].[AddressCity],
	[Mall_Order].[AddressDistrict],
	[Mall_Order].[AddressDetailInfo],
	[Mall_Order].[AddTime],
	[Mall_Order].[AddUser],
	[Mall_Order].[PrintID],
	[Mall_Order].[PayTime],
	[Mall_Order].[ShipTime],
	[Mall_Order].[CompleteTime],
	[Mall_Order].[CloseTime],
	[Mall_Order].[UserNote],
	[Mall_Order].[AddressUserName],
	[Mall_Order].[AddressPhoneNumber],
	[Mall_Order].[ProductTypeID],
	[Mall_Order].[Pin_OrganiserID],
	[Mall_Order].[Pin_UserID],
	[Mall_Order].[PayUserName],
	[Mall_Order].[ShipTrackNo],
	[Mall_Order].[ShipCompanyName],
	[Mall_Order].[ShipUserName],
	[Mall_Order].[CompleteUserName],
	[Mall_Order].[CloseUserName],
	[Mall_Order].[PaymentMethod],
	[Mall_Order].[CouponID],
	[Mall_Order].[CouponAmount],
	[Mall_Order].[ProductAmount],
	[Mall_Order].[IsDeleted],
	[Mall_Order].[DeleteTime],
	[Mall_Order].[DeleteUserName],
	[Mall_Order].[IsClosed],
	[Mall_Order].[RefundTrackNo],
	[Mall_Order].[RefundRequestTime],
	[Mall_Order].[RefundTime],
	[Mall_Order].[AddressRoomID],
	[Mall_Order].[AddressProjectID],
	[Mall_Order].[OriginalTotalCost],
	[Mall_Order].[LastTotalCost],
	[Mall_Order].[SellerNote],
	[Mall_Order].[IsShareOrder],
	[Mall_Order].[AddressProvinceID],
	[Mall_Order].[ShipRateAmount],
	[Mall_Order].[IsReadNewOrder],
	[Mall_Order].[IsReadRefundOrder],
	[Mall_Order].[ShareUserID],
	[Mall_Order].[CouponUserID],
	[Mall_Order].[ShipRateID],
	[Mall_Order].[ShipRateName],
	[Mall_Order].[TotalSalePoint],
	[Mall_Order].[TotalVIPSalePoint],
	[Mall_Order].[IsAPPUserSent],
	[Mall_Order].[IsCanGrab],
	[Mall_Order].[GrabSendTime],
	[Mall_Order].[GrabStatus],
	[Mall_Order].[CompleteRemark],
	[Mall_Order].[PurchaseType],
	[Mall_Order].[TotalSaleStaffPoint],
	[Mall_Order].[ShipRemark],
	[Mall_Order].[BusinessID],
	[Mall_Order].[IsPaied],
	[Mall_Order].[BusinessCompleteTime],
	[Mall_Order].[ShipDelivererName]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrderNumber],
	INSERTED.[TradeNo],
	INSERTED.[OrderType],
	INSERTED.[TotalCost],
	INSERTED.[OrderStatus],
	INSERTED.[UserID],
	INSERTED.[UserName],
	INSERTED.[AddressID],
	INSERTED.[AddressProvince],
	INSERTED.[AddressCity],
	INSERTED.[AddressDistrict],
	INSERTED.[AddressDetailInfo],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[PrintID],
	INSERTED.[PayTime],
	INSERTED.[ShipTime],
	INSERTED.[CompleteTime],
	INSERTED.[CloseTime],
	INSERTED.[UserNote],
	INSERTED.[AddressUserName],
	INSERTED.[AddressPhoneNumber],
	INSERTED.[ProductTypeID],
	INSERTED.[Pin_OrganiserID],
	INSERTED.[Pin_UserID],
	INSERTED.[PayUserName],
	INSERTED.[ShipTrackNo],
	INSERTED.[ShipCompanyName],
	INSERTED.[ShipUserName],
	INSERTED.[CompleteUserName],
	INSERTED.[CloseUserName],
	INSERTED.[PaymentMethod],
	INSERTED.[CouponID],
	INSERTED.[CouponAmount],
	INSERTED.[ProductAmount],
	INSERTED.[IsDeleted],
	INSERTED.[DeleteTime],
	INSERTED.[DeleteUserName],
	INSERTED.[IsClosed],
	INSERTED.[RefundTrackNo],
	INSERTED.[RefundRequestTime],
	INSERTED.[RefundTime],
	INSERTED.[AddressRoomID],
	INSERTED.[AddressProjectID],
	INSERTED.[OriginalTotalCost],
	INSERTED.[LastTotalCost],
	INSERTED.[SellerNote],
	INSERTED.[IsShareOrder],
	INSERTED.[AddressProvinceID],
	INSERTED.[ShipRateAmount],
	INSERTED.[IsReadNewOrder],
	INSERTED.[IsReadRefundOrder],
	INSERTED.[ShareUserID],
	INSERTED.[CouponUserID],
	INSERTED.[ShipRateID],
	INSERTED.[ShipRateName],
	INSERTED.[TotalSalePoint],
	INSERTED.[TotalVIPSalePoint],
	INSERTED.[IsAPPUserSent],
	INSERTED.[IsCanGrab],
	INSERTED.[GrabSendTime],
	INSERTED.[GrabStatus],
	INSERTED.[CompleteRemark],
	INSERTED.[PurchaseType],
	INSERTED.[TotalSaleStaffPoint],
	INSERTED.[ShipRemark],
	INSERTED.[BusinessID],
	INSERTED.[IsPaied],
	INSERTED.[BusinessCompleteTime],
	INSERTED.[ShipDelivererName]
into @table
VALUES ( 
	@OrderNumber,
	@TradeNo,
	@OrderType,
	@TotalCost,
	@OrderStatus,
	@UserID,
	@UserName,
	@AddressID,
	@AddressProvince,
	@AddressCity,
	@AddressDistrict,
	@AddressDetailInfo,
	@AddTime,
	@AddUser,
	@PrintID,
	@PayTime,
	@ShipTime,
	@CompleteTime,
	@CloseTime,
	@UserNote,
	@AddressUserName,
	@AddressPhoneNumber,
	@ProductTypeID,
	@Pin_OrganiserID,
	@Pin_UserID,
	@PayUserName,
	@ShipTrackNo,
	@ShipCompanyName,
	@ShipUserName,
	@CompleteUserName,
	@CloseUserName,
	@PaymentMethod,
	@CouponID,
	@CouponAmount,
	@ProductAmount,
	@IsDeleted,
	@DeleteTime,
	@DeleteUserName,
	@IsClosed,
	@RefundTrackNo,
	@RefundRequestTime,
	@RefundTime,
	@AddressRoomID,
	@AddressProjectID,
	@OriginalTotalCost,
	@LastTotalCost,
	@SellerNote,
	@IsShareOrder,
	@AddressProvinceID,
	@ShipRateAmount,
	@IsReadNewOrder,
	@IsReadRefundOrder,
	@ShareUserID,
	@CouponUserID,
	@ShipRateID,
	@ShipRateName,
	@TotalSalePoint,
	@TotalVIPSalePoint,
	@IsAPPUserSent,
	@IsCanGrab,
	@GrabSendTime,
	@GrabStatus,
	@CompleteRemark,
	@PurchaseType,
	@TotalSaleStaffPoint,
	@ShipRemark,
	@BusinessID,
	@IsPaied,
	@BusinessCompleteTime,
	@ShipDelivererName 
); 

SELECT 
	[ID],
	[OrderNumber],
	[TradeNo],
	[OrderType],
	[TotalCost],
	[OrderStatus],
	[UserID],
	[UserName],
	[AddressID],
	[AddressProvince],
	[AddressCity],
	[AddressDistrict],
	[AddressDetailInfo],
	[AddTime],
	[AddUser],
	[PrintID],
	[PayTime],
	[ShipTime],
	[CompleteTime],
	[CloseTime],
	[UserNote],
	[AddressUserName],
	[AddressPhoneNumber],
	[ProductTypeID],
	[Pin_OrganiserID],
	[Pin_UserID],
	[PayUserName],
	[ShipTrackNo],
	[ShipCompanyName],
	[ShipUserName],
	[CompleteUserName],
	[CloseUserName],
	[PaymentMethod],
	[CouponID],
	[CouponAmount],
	[ProductAmount],
	[IsDeleted],
	[DeleteTime],
	[DeleteUserName],
	[IsClosed],
	[RefundTrackNo],
	[RefundRequestTime],
	[RefundTime],
	[AddressRoomID],
	[AddressProjectID],
	[OriginalTotalCost],
	[LastTotalCost],
	[SellerNote],
	[IsShareOrder],
	[AddressProvinceID],
	[ShipRateAmount],
	[IsReadNewOrder],
	[IsReadRefundOrder],
	[ShareUserID],
	[CouponUserID],
	[ShipRateID],
	[ShipRateName],
	[TotalSalePoint],
	[TotalVIPSalePoint],
	[IsAPPUserSent],
	[IsCanGrab],
	[GrabSendTime],
	[GrabStatus],
	[CompleteRemark],
	[PurchaseType],
	[TotalSaleStaffPoint],
	[ShipRemark],
	[BusinessID],
	[IsPaied],
	[BusinessCompleteTime],
	[ShipDelivererName] 
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
	[OrderNumber] nvarchar(100),
	[TradeNo] nvarchar(100),
	[OrderType] int,
	[TotalCost] decimal(18, 2),
	[OrderStatus] int,
	[UserID] int,
	[UserName] nvarchar(100),
	[AddressID] int,
	[AddressProvince] nvarchar(100),
	[AddressCity] nvarchar(100),
	[AddressDistrict] nvarchar(100),
	[AddressDetailInfo] nvarchar(500),
	[AddTime] datetime,
	[AddUser] nvarchar(100),
	[PrintID] int,
	[PayTime] datetime,
	[ShipTime] datetime,
	[CompleteTime] datetime,
	[CloseTime] datetime,
	[UserNote] nvarchar(500),
	[AddressUserName] nvarchar(100),
	[AddressPhoneNumber] nvarchar(100),
	[ProductTypeID] int,
	[Pin_OrganiserID] int,
	[Pin_UserID] int,
	[PayUserName] nvarchar(200),
	[ShipTrackNo] nvarchar(500),
	[ShipCompanyName] nvarchar(500),
	[ShipUserName] nvarchar(500),
	[CompleteUserName] nvarchar(500),
	[CloseUserName] nvarchar(500),
	[PaymentMethod] nvarchar(500),
	[CouponID] int,
	[CouponAmount] decimal(18, 2),
	[ProductAmount] decimal(18, 2),
	[IsDeleted] bit,
	[DeleteTime] datetime,
	[DeleteUserName] nvarchar(200),
	[IsClosed] bit,
	[RefundTrackNo] nvarchar(200),
	[RefundRequestTime] datetime,
	[RefundTime] datetime,
	[AddressRoomID] int,
	[AddressProjectID] int,
	[OriginalTotalCost] decimal(18, 2),
	[LastTotalCost] decimal(18, 2),
	[SellerNote] ntext,
	[IsShareOrder] bit,
	[AddressProvinceID] int,
	[ShipRateAmount] decimal(18, 2),
	[IsReadNewOrder] bit,
	[IsReadRefundOrder] bit,
	[ShareUserID] int,
	[CouponUserID] int,
	[ShipRateID] int,
	[ShipRateName] nvarchar(200),
	[TotalSalePoint] int,
	[TotalVIPSalePoint] int,
	[IsAPPUserSent] bit,
	[IsCanGrab] bit,
	[GrabSendTime] datetime,
	[GrabStatus] int,
	[CompleteRemark] ntext,
	[PurchaseType] int,
	[TotalSaleStaffPoint] int,
	[ShipRemark] ntext,
	[BusinessID] int,
	[IsPaied] bit,
	[BusinessCompleteTime] datetime,
	[ShipDelivererName] nvarchar(100)
);

UPDATE [dbo].[Mall_Order] SET 
	[Mall_Order].[OrderNumber] = @OrderNumber,
	[Mall_Order].[TradeNo] = @TradeNo,
	[Mall_Order].[OrderType] = @OrderType,
	[Mall_Order].[TotalCost] = @TotalCost,
	[Mall_Order].[OrderStatus] = @OrderStatus,
	[Mall_Order].[UserID] = @UserID,
	[Mall_Order].[UserName] = @UserName,
	[Mall_Order].[AddressID] = @AddressID,
	[Mall_Order].[AddressProvince] = @AddressProvince,
	[Mall_Order].[AddressCity] = @AddressCity,
	[Mall_Order].[AddressDistrict] = @AddressDistrict,
	[Mall_Order].[AddressDetailInfo] = @AddressDetailInfo,
	[Mall_Order].[AddTime] = @AddTime,
	[Mall_Order].[AddUser] = @AddUser,
	[Mall_Order].[PrintID] = @PrintID,
	[Mall_Order].[PayTime] = @PayTime,
	[Mall_Order].[ShipTime] = @ShipTime,
	[Mall_Order].[CompleteTime] = @CompleteTime,
	[Mall_Order].[CloseTime] = @CloseTime,
	[Mall_Order].[UserNote] = @UserNote,
	[Mall_Order].[AddressUserName] = @AddressUserName,
	[Mall_Order].[AddressPhoneNumber] = @AddressPhoneNumber,
	[Mall_Order].[ProductTypeID] = @ProductTypeID,
	[Mall_Order].[Pin_OrganiserID] = @Pin_OrganiserID,
	[Mall_Order].[Pin_UserID] = @Pin_UserID,
	[Mall_Order].[PayUserName] = @PayUserName,
	[Mall_Order].[ShipTrackNo] = @ShipTrackNo,
	[Mall_Order].[ShipCompanyName] = @ShipCompanyName,
	[Mall_Order].[ShipUserName] = @ShipUserName,
	[Mall_Order].[CompleteUserName] = @CompleteUserName,
	[Mall_Order].[CloseUserName] = @CloseUserName,
	[Mall_Order].[PaymentMethod] = @PaymentMethod,
	[Mall_Order].[CouponID] = @CouponID,
	[Mall_Order].[CouponAmount] = @CouponAmount,
	[Mall_Order].[ProductAmount] = @ProductAmount,
	[Mall_Order].[IsDeleted] = @IsDeleted,
	[Mall_Order].[DeleteTime] = @DeleteTime,
	[Mall_Order].[DeleteUserName] = @DeleteUserName,
	[Mall_Order].[IsClosed] = @IsClosed,
	[Mall_Order].[RefundTrackNo] = @RefundTrackNo,
	[Mall_Order].[RefundRequestTime] = @RefundRequestTime,
	[Mall_Order].[RefundTime] = @RefundTime,
	[Mall_Order].[AddressRoomID] = @AddressRoomID,
	[Mall_Order].[AddressProjectID] = @AddressProjectID,
	[Mall_Order].[OriginalTotalCost] = @OriginalTotalCost,
	[Mall_Order].[LastTotalCost] = @LastTotalCost,
	[Mall_Order].[SellerNote] = @SellerNote,
	[Mall_Order].[IsShareOrder] = @IsShareOrder,
	[Mall_Order].[AddressProvinceID] = @AddressProvinceID,
	[Mall_Order].[ShipRateAmount] = @ShipRateAmount,
	[Mall_Order].[IsReadNewOrder] = @IsReadNewOrder,
	[Mall_Order].[IsReadRefundOrder] = @IsReadRefundOrder,
	[Mall_Order].[ShareUserID] = @ShareUserID,
	[Mall_Order].[CouponUserID] = @CouponUserID,
	[Mall_Order].[ShipRateID] = @ShipRateID,
	[Mall_Order].[ShipRateName] = @ShipRateName,
	[Mall_Order].[TotalSalePoint] = @TotalSalePoint,
	[Mall_Order].[TotalVIPSalePoint] = @TotalVIPSalePoint,
	[Mall_Order].[IsAPPUserSent] = @IsAPPUserSent,
	[Mall_Order].[IsCanGrab] = @IsCanGrab,
	[Mall_Order].[GrabSendTime] = @GrabSendTime,
	[Mall_Order].[GrabStatus] = @GrabStatus,
	[Mall_Order].[CompleteRemark] = @CompleteRemark,
	[Mall_Order].[PurchaseType] = @PurchaseType,
	[Mall_Order].[TotalSaleStaffPoint] = @TotalSaleStaffPoint,
	[Mall_Order].[ShipRemark] = @ShipRemark,
	[Mall_Order].[BusinessID] = @BusinessID,
	[Mall_Order].[IsPaied] = @IsPaied,
	[Mall_Order].[BusinessCompleteTime] = @BusinessCompleteTime,
	[Mall_Order].[ShipDelivererName] = @ShipDelivererName 
output 
	INSERTED.[ID],
	INSERTED.[OrderNumber],
	INSERTED.[TradeNo],
	INSERTED.[OrderType],
	INSERTED.[TotalCost],
	INSERTED.[OrderStatus],
	INSERTED.[UserID],
	INSERTED.[UserName],
	INSERTED.[AddressID],
	INSERTED.[AddressProvince],
	INSERTED.[AddressCity],
	INSERTED.[AddressDistrict],
	INSERTED.[AddressDetailInfo],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[PrintID],
	INSERTED.[PayTime],
	INSERTED.[ShipTime],
	INSERTED.[CompleteTime],
	INSERTED.[CloseTime],
	INSERTED.[UserNote],
	INSERTED.[AddressUserName],
	INSERTED.[AddressPhoneNumber],
	INSERTED.[ProductTypeID],
	INSERTED.[Pin_OrganiserID],
	INSERTED.[Pin_UserID],
	INSERTED.[PayUserName],
	INSERTED.[ShipTrackNo],
	INSERTED.[ShipCompanyName],
	INSERTED.[ShipUserName],
	INSERTED.[CompleteUserName],
	INSERTED.[CloseUserName],
	INSERTED.[PaymentMethod],
	INSERTED.[CouponID],
	INSERTED.[CouponAmount],
	INSERTED.[ProductAmount],
	INSERTED.[IsDeleted],
	INSERTED.[DeleteTime],
	INSERTED.[DeleteUserName],
	INSERTED.[IsClosed],
	INSERTED.[RefundTrackNo],
	INSERTED.[RefundRequestTime],
	INSERTED.[RefundTime],
	INSERTED.[AddressRoomID],
	INSERTED.[AddressProjectID],
	INSERTED.[OriginalTotalCost],
	INSERTED.[LastTotalCost],
	INSERTED.[SellerNote],
	INSERTED.[IsShareOrder],
	INSERTED.[AddressProvinceID],
	INSERTED.[ShipRateAmount],
	INSERTED.[IsReadNewOrder],
	INSERTED.[IsReadRefundOrder],
	INSERTED.[ShareUserID],
	INSERTED.[CouponUserID],
	INSERTED.[ShipRateID],
	INSERTED.[ShipRateName],
	INSERTED.[TotalSalePoint],
	INSERTED.[TotalVIPSalePoint],
	INSERTED.[IsAPPUserSent],
	INSERTED.[IsCanGrab],
	INSERTED.[GrabSendTime],
	INSERTED.[GrabStatus],
	INSERTED.[CompleteRemark],
	INSERTED.[PurchaseType],
	INSERTED.[TotalSaleStaffPoint],
	INSERTED.[ShipRemark],
	INSERTED.[BusinessID],
	INSERTED.[IsPaied],
	INSERTED.[BusinessCompleteTime],
	INSERTED.[ShipDelivererName]
into @table
WHERE 
	[Mall_Order].[ID] = @ID

SELECT 
	[ID],
	[OrderNumber],
	[TradeNo],
	[OrderType],
	[TotalCost],
	[OrderStatus],
	[UserID],
	[UserName],
	[AddressID],
	[AddressProvince],
	[AddressCity],
	[AddressDistrict],
	[AddressDetailInfo],
	[AddTime],
	[AddUser],
	[PrintID],
	[PayTime],
	[ShipTime],
	[CompleteTime],
	[CloseTime],
	[UserNote],
	[AddressUserName],
	[AddressPhoneNumber],
	[ProductTypeID],
	[Pin_OrganiserID],
	[Pin_UserID],
	[PayUserName],
	[ShipTrackNo],
	[ShipCompanyName],
	[ShipUserName],
	[CompleteUserName],
	[CloseUserName],
	[PaymentMethod],
	[CouponID],
	[CouponAmount],
	[ProductAmount],
	[IsDeleted],
	[DeleteTime],
	[DeleteUserName],
	[IsClosed],
	[RefundTrackNo],
	[RefundRequestTime],
	[RefundTime],
	[AddressRoomID],
	[AddressProjectID],
	[OriginalTotalCost],
	[LastTotalCost],
	[SellerNote],
	[IsShareOrder],
	[AddressProvinceID],
	[ShipRateAmount],
	[IsReadNewOrder],
	[IsReadRefundOrder],
	[ShareUserID],
	[CouponUserID],
	[ShipRateID],
	[ShipRateName],
	[TotalSalePoint],
	[TotalVIPSalePoint],
	[IsAPPUserSent],
	[IsCanGrab],
	[GrabSendTime],
	[GrabStatus],
	[CompleteRemark],
	[PurchaseType],
	[TotalSaleStaffPoint],
	[ShipRemark],
	[BusinessID],
	[IsPaied],
	[BusinessCompleteTime],
	[ShipDelivererName] 
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
DELETE FROM [dbo].[Mall_Order]
WHERE 
	[Mall_Order].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_Order() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_Order(this.ID));
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
	[Mall_Order].[ID],
	[Mall_Order].[OrderNumber],
	[Mall_Order].[TradeNo],
	[Mall_Order].[OrderType],
	[Mall_Order].[TotalCost],
	[Mall_Order].[OrderStatus],
	[Mall_Order].[UserID],
	[Mall_Order].[UserName],
	[Mall_Order].[AddressID],
	[Mall_Order].[AddressProvince],
	[Mall_Order].[AddressCity],
	[Mall_Order].[AddressDistrict],
	[Mall_Order].[AddressDetailInfo],
	[Mall_Order].[AddTime],
	[Mall_Order].[AddUser],
	[Mall_Order].[PrintID],
	[Mall_Order].[PayTime],
	[Mall_Order].[ShipTime],
	[Mall_Order].[CompleteTime],
	[Mall_Order].[CloseTime],
	[Mall_Order].[UserNote],
	[Mall_Order].[AddressUserName],
	[Mall_Order].[AddressPhoneNumber],
	[Mall_Order].[ProductTypeID],
	[Mall_Order].[Pin_OrganiserID],
	[Mall_Order].[Pin_UserID],
	[Mall_Order].[PayUserName],
	[Mall_Order].[ShipTrackNo],
	[Mall_Order].[ShipCompanyName],
	[Mall_Order].[ShipUserName],
	[Mall_Order].[CompleteUserName],
	[Mall_Order].[CloseUserName],
	[Mall_Order].[PaymentMethod],
	[Mall_Order].[CouponID],
	[Mall_Order].[CouponAmount],
	[Mall_Order].[ProductAmount],
	[Mall_Order].[IsDeleted],
	[Mall_Order].[DeleteTime],
	[Mall_Order].[DeleteUserName],
	[Mall_Order].[IsClosed],
	[Mall_Order].[RefundTrackNo],
	[Mall_Order].[RefundRequestTime],
	[Mall_Order].[RefundTime],
	[Mall_Order].[AddressRoomID],
	[Mall_Order].[AddressProjectID],
	[Mall_Order].[OriginalTotalCost],
	[Mall_Order].[LastTotalCost],
	[Mall_Order].[SellerNote],
	[Mall_Order].[IsShareOrder],
	[Mall_Order].[AddressProvinceID],
	[Mall_Order].[ShipRateAmount],
	[Mall_Order].[IsReadNewOrder],
	[Mall_Order].[IsReadRefundOrder],
	[Mall_Order].[ShareUserID],
	[Mall_Order].[CouponUserID],
	[Mall_Order].[ShipRateID],
	[Mall_Order].[ShipRateName],
	[Mall_Order].[TotalSalePoint],
	[Mall_Order].[TotalVIPSalePoint],
	[Mall_Order].[IsAPPUserSent],
	[Mall_Order].[IsCanGrab],
	[Mall_Order].[GrabSendTime],
	[Mall_Order].[GrabStatus],
	[Mall_Order].[CompleteRemark],
	[Mall_Order].[PurchaseType],
	[Mall_Order].[TotalSaleStaffPoint],
	[Mall_Order].[ShipRemark],
	[Mall_Order].[BusinessID],
	[Mall_Order].[IsPaied],
	[Mall_Order].[BusinessCompleteTime],
	[Mall_Order].[ShipDelivererName]
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
                return "Mall_Order";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_Order into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="orderType">orderType</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="orderStatus">orderStatus</param>
		/// <param name="userID">userID</param>
		/// <param name="userName">userName</param>
		/// <param name="addressID">addressID</param>
		/// <param name="addressProvince">addressProvince</param>
		/// <param name="addressCity">addressCity</param>
		/// <param name="addressDistrict">addressDistrict</param>
		/// <param name="addressDetailInfo">addressDetailInfo</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="printID">printID</param>
		/// <param name="payTime">payTime</param>
		/// <param name="shipTime">shipTime</param>
		/// <param name="completeTime">completeTime</param>
		/// <param name="closeTime">closeTime</param>
		/// <param name="userNote">userNote</param>
		/// <param name="addressUserName">addressUserName</param>
		/// <param name="addressPhoneNumber">addressPhoneNumber</param>
		/// <param name="productTypeID">productTypeID</param>
		/// <param name="pin_OrganiserID">pin_OrganiserID</param>
		/// <param name="pin_UserID">pin_UserID</param>
		/// <param name="payUserName">payUserName</param>
		/// <param name="shipTrackNo">shipTrackNo</param>
		/// <param name="shipCompanyName">shipCompanyName</param>
		/// <param name="shipUserName">shipUserName</param>
		/// <param name="completeUserName">completeUserName</param>
		/// <param name="closeUserName">closeUserName</param>
		/// <param name="paymentMethod">paymentMethod</param>
		/// <param name="couponID">couponID</param>
		/// <param name="couponAmount">couponAmount</param>
		/// <param name="productAmount">productAmount</param>
		/// <param name="isDeleted">isDeleted</param>
		/// <param name="deleteTime">deleteTime</param>
		/// <param name="deleteUserName">deleteUserName</param>
		/// <param name="isClosed">isClosed</param>
		/// <param name="refundTrackNo">refundTrackNo</param>
		/// <param name="refundRequestTime">refundRequestTime</param>
		/// <param name="refundTime">refundTime</param>
		/// <param name="addressRoomID">addressRoomID</param>
		/// <param name="addressProjectID">addressProjectID</param>
		/// <param name="originalTotalCost">originalTotalCost</param>
		/// <param name="lastTotalCost">lastTotalCost</param>
		/// <param name="sellerNote">sellerNote</param>
		/// <param name="isShareOrder">isShareOrder</param>
		/// <param name="addressProvinceID">addressProvinceID</param>
		/// <param name="shipRateAmount">shipRateAmount</param>
		/// <param name="isReadNewOrder">isReadNewOrder</param>
		/// <param name="isReadRefundOrder">isReadRefundOrder</param>
		/// <param name="shareUserID">shareUserID</param>
		/// <param name="couponUserID">couponUserID</param>
		/// <param name="shipRateID">shipRateID</param>
		/// <param name="shipRateName">shipRateName</param>
		/// <param name="totalSalePoint">totalSalePoint</param>
		/// <param name="totalVIPSalePoint">totalVIPSalePoint</param>
		/// <param name="isAPPUserSent">isAPPUserSent</param>
		/// <param name="isCanGrab">isCanGrab</param>
		/// <param name="grabSendTime">grabSendTime</param>
		/// <param name="grabStatus">grabStatus</param>
		/// <param name="completeRemark">completeRemark</param>
		/// <param name="purchaseType">purchaseType</param>
		/// <param name="totalSaleStaffPoint">totalSaleStaffPoint</param>
		/// <param name="shipRemark">shipRemark</param>
		/// <param name="businessID">businessID</param>
		/// <param name="isPaied">isPaied</param>
		/// <param name="businessCompleteTime">businessCompleteTime</param>
		/// <param name="shipDelivererName">shipDelivererName</param>
		public static void InsertMall_Order(string @orderNumber, string @tradeNo, int @orderType, decimal @totalCost, int @orderStatus, int @userID, string @userName, int @addressID, string @addressProvince, string @addressCity, string @addressDistrict, string @addressDetailInfo, DateTime @addTime, string @addUser, int @printID, DateTime @payTime, DateTime @shipTime, DateTime @completeTime, DateTime @closeTime, string @userNote, string @addressUserName, string @addressPhoneNumber, int @productTypeID, int @pin_OrganiserID, int @pin_UserID, string @payUserName, string @shipTrackNo, string @shipCompanyName, string @shipUserName, string @completeUserName, string @closeUserName, string @paymentMethod, int @couponID, decimal @couponAmount, decimal @productAmount, bool @isDeleted, DateTime @deleteTime, string @deleteUserName, bool @isClosed, string @refundTrackNo, DateTime @refundRequestTime, DateTime @refundTime, int @addressRoomID, int @addressProjectID, decimal @originalTotalCost, decimal @lastTotalCost, string @sellerNote, bool @isShareOrder, int @addressProvinceID, decimal @shipRateAmount, bool @isReadNewOrder, bool @isReadRefundOrder, int @shareUserID, int @couponUserID, int @shipRateID, string @shipRateName, int @totalSalePoint, int @totalVIPSalePoint, bool @isAPPUserSent, bool @isCanGrab, DateTime @grabSendTime, int @grabStatus, string @completeRemark, int @purchaseType, int @totalSaleStaffPoint, string @shipRemark, int @businessID, bool @isPaied, DateTime @businessCompleteTime, string @shipDelivererName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_Order(@orderNumber, @tradeNo, @orderType, @totalCost, @orderStatus, @userID, @userName, @addressID, @addressProvince, @addressCity, @addressDistrict, @addressDetailInfo, @addTime, @addUser, @printID, @payTime, @shipTime, @completeTime, @closeTime, @userNote, @addressUserName, @addressPhoneNumber, @productTypeID, @pin_OrganiserID, @pin_UserID, @payUserName, @shipTrackNo, @shipCompanyName, @shipUserName, @completeUserName, @closeUserName, @paymentMethod, @couponID, @couponAmount, @productAmount, @isDeleted, @deleteTime, @deleteUserName, @isClosed, @refundTrackNo, @refundRequestTime, @refundTime, @addressRoomID, @addressProjectID, @originalTotalCost, @lastTotalCost, @sellerNote, @isShareOrder, @addressProvinceID, @shipRateAmount, @isReadNewOrder, @isReadRefundOrder, @shareUserID, @couponUserID, @shipRateID, @shipRateName, @totalSalePoint, @totalVIPSalePoint, @isAPPUserSent, @isCanGrab, @grabSendTime, @grabStatus, @completeRemark, @purchaseType, @totalSaleStaffPoint, @shipRemark, @businessID, @isPaied, @businessCompleteTime, @shipDelivererName, helper);
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
		/// Insert a Mall_Order into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="orderType">orderType</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="orderStatus">orderStatus</param>
		/// <param name="userID">userID</param>
		/// <param name="userName">userName</param>
		/// <param name="addressID">addressID</param>
		/// <param name="addressProvince">addressProvince</param>
		/// <param name="addressCity">addressCity</param>
		/// <param name="addressDistrict">addressDistrict</param>
		/// <param name="addressDetailInfo">addressDetailInfo</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="printID">printID</param>
		/// <param name="payTime">payTime</param>
		/// <param name="shipTime">shipTime</param>
		/// <param name="completeTime">completeTime</param>
		/// <param name="closeTime">closeTime</param>
		/// <param name="userNote">userNote</param>
		/// <param name="addressUserName">addressUserName</param>
		/// <param name="addressPhoneNumber">addressPhoneNumber</param>
		/// <param name="productTypeID">productTypeID</param>
		/// <param name="pin_OrganiserID">pin_OrganiserID</param>
		/// <param name="pin_UserID">pin_UserID</param>
		/// <param name="payUserName">payUserName</param>
		/// <param name="shipTrackNo">shipTrackNo</param>
		/// <param name="shipCompanyName">shipCompanyName</param>
		/// <param name="shipUserName">shipUserName</param>
		/// <param name="completeUserName">completeUserName</param>
		/// <param name="closeUserName">closeUserName</param>
		/// <param name="paymentMethod">paymentMethod</param>
		/// <param name="couponID">couponID</param>
		/// <param name="couponAmount">couponAmount</param>
		/// <param name="productAmount">productAmount</param>
		/// <param name="isDeleted">isDeleted</param>
		/// <param name="deleteTime">deleteTime</param>
		/// <param name="deleteUserName">deleteUserName</param>
		/// <param name="isClosed">isClosed</param>
		/// <param name="refundTrackNo">refundTrackNo</param>
		/// <param name="refundRequestTime">refundRequestTime</param>
		/// <param name="refundTime">refundTime</param>
		/// <param name="addressRoomID">addressRoomID</param>
		/// <param name="addressProjectID">addressProjectID</param>
		/// <param name="originalTotalCost">originalTotalCost</param>
		/// <param name="lastTotalCost">lastTotalCost</param>
		/// <param name="sellerNote">sellerNote</param>
		/// <param name="isShareOrder">isShareOrder</param>
		/// <param name="addressProvinceID">addressProvinceID</param>
		/// <param name="shipRateAmount">shipRateAmount</param>
		/// <param name="isReadNewOrder">isReadNewOrder</param>
		/// <param name="isReadRefundOrder">isReadRefundOrder</param>
		/// <param name="shareUserID">shareUserID</param>
		/// <param name="couponUserID">couponUserID</param>
		/// <param name="shipRateID">shipRateID</param>
		/// <param name="shipRateName">shipRateName</param>
		/// <param name="totalSalePoint">totalSalePoint</param>
		/// <param name="totalVIPSalePoint">totalVIPSalePoint</param>
		/// <param name="isAPPUserSent">isAPPUserSent</param>
		/// <param name="isCanGrab">isCanGrab</param>
		/// <param name="grabSendTime">grabSendTime</param>
		/// <param name="grabStatus">grabStatus</param>
		/// <param name="completeRemark">completeRemark</param>
		/// <param name="purchaseType">purchaseType</param>
		/// <param name="totalSaleStaffPoint">totalSaleStaffPoint</param>
		/// <param name="shipRemark">shipRemark</param>
		/// <param name="businessID">businessID</param>
		/// <param name="isPaied">isPaied</param>
		/// <param name="businessCompleteTime">businessCompleteTime</param>
		/// <param name="shipDelivererName">shipDelivererName</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_Order(string @orderNumber, string @tradeNo, int @orderType, decimal @totalCost, int @orderStatus, int @userID, string @userName, int @addressID, string @addressProvince, string @addressCity, string @addressDistrict, string @addressDetailInfo, DateTime @addTime, string @addUser, int @printID, DateTime @payTime, DateTime @shipTime, DateTime @completeTime, DateTime @closeTime, string @userNote, string @addressUserName, string @addressPhoneNumber, int @productTypeID, int @pin_OrganiserID, int @pin_UserID, string @payUserName, string @shipTrackNo, string @shipCompanyName, string @shipUserName, string @completeUserName, string @closeUserName, string @paymentMethod, int @couponID, decimal @couponAmount, decimal @productAmount, bool @isDeleted, DateTime @deleteTime, string @deleteUserName, bool @isClosed, string @refundTrackNo, DateTime @refundRequestTime, DateTime @refundTime, int @addressRoomID, int @addressProjectID, decimal @originalTotalCost, decimal @lastTotalCost, string @sellerNote, bool @isShareOrder, int @addressProvinceID, decimal @shipRateAmount, bool @isReadNewOrder, bool @isReadRefundOrder, int @shareUserID, int @couponUserID, int @shipRateID, string @shipRateName, int @totalSalePoint, int @totalVIPSalePoint, bool @isAPPUserSent, bool @isCanGrab, DateTime @grabSendTime, int @grabStatus, string @completeRemark, int @purchaseType, int @totalSaleStaffPoint, string @shipRemark, int @businessID, bool @isPaied, DateTime @businessCompleteTime, string @shipDelivererName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrderNumber] nvarchar(100),
	[TradeNo] nvarchar(100),
	[OrderType] int,
	[TotalCost] decimal(18, 2),
	[OrderStatus] int,
	[UserID] int,
	[UserName] nvarchar(100),
	[AddressID] int,
	[AddressProvince] nvarchar(100),
	[AddressCity] nvarchar(100),
	[AddressDistrict] nvarchar(100),
	[AddressDetailInfo] nvarchar(500),
	[AddTime] datetime,
	[AddUser] nvarchar(100),
	[PrintID] int,
	[PayTime] datetime,
	[ShipTime] datetime,
	[CompleteTime] datetime,
	[CloseTime] datetime,
	[UserNote] nvarchar(500),
	[AddressUserName] nvarchar(100),
	[AddressPhoneNumber] nvarchar(100),
	[ProductTypeID] int,
	[Pin_OrganiserID] int,
	[Pin_UserID] int,
	[PayUserName] nvarchar(200),
	[ShipTrackNo] nvarchar(500),
	[ShipCompanyName] nvarchar(500),
	[ShipUserName] nvarchar(500),
	[CompleteUserName] nvarchar(500),
	[CloseUserName] nvarchar(500),
	[PaymentMethod] nvarchar(500),
	[CouponID] int,
	[CouponAmount] decimal(18, 2),
	[ProductAmount] decimal(18, 2),
	[IsDeleted] bit,
	[DeleteTime] datetime,
	[DeleteUserName] nvarchar(200),
	[IsClosed] bit,
	[RefundTrackNo] nvarchar(200),
	[RefundRequestTime] datetime,
	[RefundTime] datetime,
	[AddressRoomID] int,
	[AddressProjectID] int,
	[OriginalTotalCost] decimal(18, 2),
	[LastTotalCost] decimal(18, 2),
	[SellerNote] ntext,
	[IsShareOrder] bit,
	[AddressProvinceID] int,
	[ShipRateAmount] decimal(18, 2),
	[IsReadNewOrder] bit,
	[IsReadRefundOrder] bit,
	[ShareUserID] int,
	[CouponUserID] int,
	[ShipRateID] int,
	[ShipRateName] nvarchar(200),
	[TotalSalePoint] int,
	[TotalVIPSalePoint] int,
	[IsAPPUserSent] bit,
	[IsCanGrab] bit,
	[GrabSendTime] datetime,
	[GrabStatus] int,
	[CompleteRemark] ntext,
	[PurchaseType] int,
	[TotalSaleStaffPoint] int,
	[ShipRemark] ntext,
	[BusinessID] int,
	[IsPaied] bit,
	[BusinessCompleteTime] datetime,
	[ShipDelivererName] nvarchar(100)
);

INSERT INTO [dbo].[Mall_Order] (
	[Mall_Order].[OrderNumber],
	[Mall_Order].[TradeNo],
	[Mall_Order].[OrderType],
	[Mall_Order].[TotalCost],
	[Mall_Order].[OrderStatus],
	[Mall_Order].[UserID],
	[Mall_Order].[UserName],
	[Mall_Order].[AddressID],
	[Mall_Order].[AddressProvince],
	[Mall_Order].[AddressCity],
	[Mall_Order].[AddressDistrict],
	[Mall_Order].[AddressDetailInfo],
	[Mall_Order].[AddTime],
	[Mall_Order].[AddUser],
	[Mall_Order].[PrintID],
	[Mall_Order].[PayTime],
	[Mall_Order].[ShipTime],
	[Mall_Order].[CompleteTime],
	[Mall_Order].[CloseTime],
	[Mall_Order].[UserNote],
	[Mall_Order].[AddressUserName],
	[Mall_Order].[AddressPhoneNumber],
	[Mall_Order].[ProductTypeID],
	[Mall_Order].[Pin_OrganiserID],
	[Mall_Order].[Pin_UserID],
	[Mall_Order].[PayUserName],
	[Mall_Order].[ShipTrackNo],
	[Mall_Order].[ShipCompanyName],
	[Mall_Order].[ShipUserName],
	[Mall_Order].[CompleteUserName],
	[Mall_Order].[CloseUserName],
	[Mall_Order].[PaymentMethod],
	[Mall_Order].[CouponID],
	[Mall_Order].[CouponAmount],
	[Mall_Order].[ProductAmount],
	[Mall_Order].[IsDeleted],
	[Mall_Order].[DeleteTime],
	[Mall_Order].[DeleteUserName],
	[Mall_Order].[IsClosed],
	[Mall_Order].[RefundTrackNo],
	[Mall_Order].[RefundRequestTime],
	[Mall_Order].[RefundTime],
	[Mall_Order].[AddressRoomID],
	[Mall_Order].[AddressProjectID],
	[Mall_Order].[OriginalTotalCost],
	[Mall_Order].[LastTotalCost],
	[Mall_Order].[SellerNote],
	[Mall_Order].[IsShareOrder],
	[Mall_Order].[AddressProvinceID],
	[Mall_Order].[ShipRateAmount],
	[Mall_Order].[IsReadNewOrder],
	[Mall_Order].[IsReadRefundOrder],
	[Mall_Order].[ShareUserID],
	[Mall_Order].[CouponUserID],
	[Mall_Order].[ShipRateID],
	[Mall_Order].[ShipRateName],
	[Mall_Order].[TotalSalePoint],
	[Mall_Order].[TotalVIPSalePoint],
	[Mall_Order].[IsAPPUserSent],
	[Mall_Order].[IsCanGrab],
	[Mall_Order].[GrabSendTime],
	[Mall_Order].[GrabStatus],
	[Mall_Order].[CompleteRemark],
	[Mall_Order].[PurchaseType],
	[Mall_Order].[TotalSaleStaffPoint],
	[Mall_Order].[ShipRemark],
	[Mall_Order].[BusinessID],
	[Mall_Order].[IsPaied],
	[Mall_Order].[BusinessCompleteTime],
	[Mall_Order].[ShipDelivererName]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrderNumber],
	INSERTED.[TradeNo],
	INSERTED.[OrderType],
	INSERTED.[TotalCost],
	INSERTED.[OrderStatus],
	INSERTED.[UserID],
	INSERTED.[UserName],
	INSERTED.[AddressID],
	INSERTED.[AddressProvince],
	INSERTED.[AddressCity],
	INSERTED.[AddressDistrict],
	INSERTED.[AddressDetailInfo],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[PrintID],
	INSERTED.[PayTime],
	INSERTED.[ShipTime],
	INSERTED.[CompleteTime],
	INSERTED.[CloseTime],
	INSERTED.[UserNote],
	INSERTED.[AddressUserName],
	INSERTED.[AddressPhoneNumber],
	INSERTED.[ProductTypeID],
	INSERTED.[Pin_OrganiserID],
	INSERTED.[Pin_UserID],
	INSERTED.[PayUserName],
	INSERTED.[ShipTrackNo],
	INSERTED.[ShipCompanyName],
	INSERTED.[ShipUserName],
	INSERTED.[CompleteUserName],
	INSERTED.[CloseUserName],
	INSERTED.[PaymentMethod],
	INSERTED.[CouponID],
	INSERTED.[CouponAmount],
	INSERTED.[ProductAmount],
	INSERTED.[IsDeleted],
	INSERTED.[DeleteTime],
	INSERTED.[DeleteUserName],
	INSERTED.[IsClosed],
	INSERTED.[RefundTrackNo],
	INSERTED.[RefundRequestTime],
	INSERTED.[RefundTime],
	INSERTED.[AddressRoomID],
	INSERTED.[AddressProjectID],
	INSERTED.[OriginalTotalCost],
	INSERTED.[LastTotalCost],
	INSERTED.[SellerNote],
	INSERTED.[IsShareOrder],
	INSERTED.[AddressProvinceID],
	INSERTED.[ShipRateAmount],
	INSERTED.[IsReadNewOrder],
	INSERTED.[IsReadRefundOrder],
	INSERTED.[ShareUserID],
	INSERTED.[CouponUserID],
	INSERTED.[ShipRateID],
	INSERTED.[ShipRateName],
	INSERTED.[TotalSalePoint],
	INSERTED.[TotalVIPSalePoint],
	INSERTED.[IsAPPUserSent],
	INSERTED.[IsCanGrab],
	INSERTED.[GrabSendTime],
	INSERTED.[GrabStatus],
	INSERTED.[CompleteRemark],
	INSERTED.[PurchaseType],
	INSERTED.[TotalSaleStaffPoint],
	INSERTED.[ShipRemark],
	INSERTED.[BusinessID],
	INSERTED.[IsPaied],
	INSERTED.[BusinessCompleteTime],
	INSERTED.[ShipDelivererName]
into @table
VALUES ( 
	@OrderNumber,
	@TradeNo,
	@OrderType,
	@TotalCost,
	@OrderStatus,
	@UserID,
	@UserName,
	@AddressID,
	@AddressProvince,
	@AddressCity,
	@AddressDistrict,
	@AddressDetailInfo,
	@AddTime,
	@AddUser,
	@PrintID,
	@PayTime,
	@ShipTime,
	@CompleteTime,
	@CloseTime,
	@UserNote,
	@AddressUserName,
	@AddressPhoneNumber,
	@ProductTypeID,
	@Pin_OrganiserID,
	@Pin_UserID,
	@PayUserName,
	@ShipTrackNo,
	@ShipCompanyName,
	@ShipUserName,
	@CompleteUserName,
	@CloseUserName,
	@PaymentMethod,
	@CouponID,
	@CouponAmount,
	@ProductAmount,
	@IsDeleted,
	@DeleteTime,
	@DeleteUserName,
	@IsClosed,
	@RefundTrackNo,
	@RefundRequestTime,
	@RefundTime,
	@AddressRoomID,
	@AddressProjectID,
	@OriginalTotalCost,
	@LastTotalCost,
	@SellerNote,
	@IsShareOrder,
	@AddressProvinceID,
	@ShipRateAmount,
	@IsReadNewOrder,
	@IsReadRefundOrder,
	@ShareUserID,
	@CouponUserID,
	@ShipRateID,
	@ShipRateName,
	@TotalSalePoint,
	@TotalVIPSalePoint,
	@IsAPPUserSent,
	@IsCanGrab,
	@GrabSendTime,
	@GrabStatus,
	@CompleteRemark,
	@PurchaseType,
	@TotalSaleStaffPoint,
	@ShipRemark,
	@BusinessID,
	@IsPaied,
	@BusinessCompleteTime,
	@ShipDelivererName 
); 

SELECT 
	[ID],
	[OrderNumber],
	[TradeNo],
	[OrderType],
	[TotalCost],
	[OrderStatus],
	[UserID],
	[UserName],
	[AddressID],
	[AddressProvince],
	[AddressCity],
	[AddressDistrict],
	[AddressDetailInfo],
	[AddTime],
	[AddUser],
	[PrintID],
	[PayTime],
	[ShipTime],
	[CompleteTime],
	[CloseTime],
	[UserNote],
	[AddressUserName],
	[AddressPhoneNumber],
	[ProductTypeID],
	[Pin_OrganiserID],
	[Pin_UserID],
	[PayUserName],
	[ShipTrackNo],
	[ShipCompanyName],
	[ShipUserName],
	[CompleteUserName],
	[CloseUserName],
	[PaymentMethod],
	[CouponID],
	[CouponAmount],
	[ProductAmount],
	[IsDeleted],
	[DeleteTime],
	[DeleteUserName],
	[IsClosed],
	[RefundTrackNo],
	[RefundRequestTime],
	[RefundTime],
	[AddressRoomID],
	[AddressProjectID],
	[OriginalTotalCost],
	[LastTotalCost],
	[SellerNote],
	[IsShareOrder],
	[AddressProvinceID],
	[ShipRateAmount],
	[IsReadNewOrder],
	[IsReadRefundOrder],
	[ShareUserID],
	[CouponUserID],
	[ShipRateID],
	[ShipRateName],
	[TotalSalePoint],
	[TotalVIPSalePoint],
	[IsAPPUserSent],
	[IsCanGrab],
	[GrabSendTime],
	[GrabStatus],
	[CompleteRemark],
	[PurchaseType],
	[TotalSaleStaffPoint],
	[ShipRemark],
	[BusinessID],
	[IsPaied],
	[BusinessCompleteTime],
	[ShipDelivererName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OrderNumber", EntityBase.GetDatabaseValue(@orderNumber)));
			parameters.Add(new SqlParameter("@TradeNo", EntityBase.GetDatabaseValue(@tradeNo)));
			parameters.Add(new SqlParameter("@OrderType", EntityBase.GetDatabaseValue(@orderType)));
			parameters.Add(new SqlParameter("@TotalCost", EntityBase.GetDatabaseValue(@totalCost)));
			parameters.Add(new SqlParameter("@OrderStatus", EntityBase.GetDatabaseValue(@orderStatus)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@UserName", EntityBase.GetDatabaseValue(@userName)));
			parameters.Add(new SqlParameter("@AddressID", EntityBase.GetDatabaseValue(@addressID)));
			parameters.Add(new SqlParameter("@AddressProvince", EntityBase.GetDatabaseValue(@addressProvince)));
			parameters.Add(new SqlParameter("@AddressCity", EntityBase.GetDatabaseValue(@addressCity)));
			parameters.Add(new SqlParameter("@AddressDistrict", EntityBase.GetDatabaseValue(@addressDistrict)));
			parameters.Add(new SqlParameter("@AddressDetailInfo", EntityBase.GetDatabaseValue(@addressDetailInfo)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUser", EntityBase.GetDatabaseValue(@addUser)));
			parameters.Add(new SqlParameter("@PrintID", EntityBase.GetDatabaseValue(@printID)));
			parameters.Add(new SqlParameter("@PayTime", EntityBase.GetDatabaseValue(@payTime)));
			parameters.Add(new SqlParameter("@ShipTime", EntityBase.GetDatabaseValue(@shipTime)));
			parameters.Add(new SqlParameter("@CompleteTime", EntityBase.GetDatabaseValue(@completeTime)));
			parameters.Add(new SqlParameter("@CloseTime", EntityBase.GetDatabaseValue(@closeTime)));
			parameters.Add(new SqlParameter("@UserNote", EntityBase.GetDatabaseValue(@userNote)));
			parameters.Add(new SqlParameter("@AddressUserName", EntityBase.GetDatabaseValue(@addressUserName)));
			parameters.Add(new SqlParameter("@AddressPhoneNumber", EntityBase.GetDatabaseValue(@addressPhoneNumber)));
			parameters.Add(new SqlParameter("@ProductTypeID", EntityBase.GetDatabaseValue(@productTypeID)));
			parameters.Add(new SqlParameter("@Pin_OrganiserID", EntityBase.GetDatabaseValue(@pin_OrganiserID)));
			parameters.Add(new SqlParameter("@Pin_UserID", EntityBase.GetDatabaseValue(@pin_UserID)));
			parameters.Add(new SqlParameter("@PayUserName", EntityBase.GetDatabaseValue(@payUserName)));
			parameters.Add(new SqlParameter("@ShipTrackNo", EntityBase.GetDatabaseValue(@shipTrackNo)));
			parameters.Add(new SqlParameter("@ShipCompanyName", EntityBase.GetDatabaseValue(@shipCompanyName)));
			parameters.Add(new SqlParameter("@ShipUserName", EntityBase.GetDatabaseValue(@shipUserName)));
			parameters.Add(new SqlParameter("@CompleteUserName", EntityBase.GetDatabaseValue(@completeUserName)));
			parameters.Add(new SqlParameter("@CloseUserName", EntityBase.GetDatabaseValue(@closeUserName)));
			parameters.Add(new SqlParameter("@PaymentMethod", EntityBase.GetDatabaseValue(@paymentMethod)));
			parameters.Add(new SqlParameter("@CouponID", EntityBase.GetDatabaseValue(@couponID)));
			parameters.Add(new SqlParameter("@CouponAmount", EntityBase.GetDatabaseValue(@couponAmount)));
			parameters.Add(new SqlParameter("@ProductAmount", EntityBase.GetDatabaseValue(@productAmount)));
			parameters.Add(new SqlParameter("@IsDeleted", @isDeleted));
			parameters.Add(new SqlParameter("@DeleteTime", EntityBase.GetDatabaseValue(@deleteTime)));
			parameters.Add(new SqlParameter("@DeleteUserName", EntityBase.GetDatabaseValue(@deleteUserName)));
			parameters.Add(new SqlParameter("@IsClosed", @isClosed));
			parameters.Add(new SqlParameter("@RefundTrackNo", EntityBase.GetDatabaseValue(@refundTrackNo)));
			parameters.Add(new SqlParameter("@RefundRequestTime", EntityBase.GetDatabaseValue(@refundRequestTime)));
			parameters.Add(new SqlParameter("@RefundTime", EntityBase.GetDatabaseValue(@refundTime)));
			parameters.Add(new SqlParameter("@AddressRoomID", EntityBase.GetDatabaseValue(@addressRoomID)));
			parameters.Add(new SqlParameter("@AddressProjectID", EntityBase.GetDatabaseValue(@addressProjectID)));
			parameters.Add(new SqlParameter("@OriginalTotalCost", EntityBase.GetDatabaseValue(@originalTotalCost)));
			parameters.Add(new SqlParameter("@LastTotalCost", EntityBase.GetDatabaseValue(@lastTotalCost)));
			parameters.Add(new SqlParameter("@SellerNote", EntityBase.GetDatabaseValue(@sellerNote)));
			parameters.Add(new SqlParameter("@IsShareOrder", @isShareOrder));
			parameters.Add(new SqlParameter("@AddressProvinceID", EntityBase.GetDatabaseValue(@addressProvinceID)));
			parameters.Add(new SqlParameter("@ShipRateAmount", EntityBase.GetDatabaseValue(@shipRateAmount)));
			parameters.Add(new SqlParameter("@IsReadNewOrder", @isReadNewOrder));
			parameters.Add(new SqlParameter("@IsReadRefundOrder", @isReadRefundOrder));
			parameters.Add(new SqlParameter("@ShareUserID", EntityBase.GetDatabaseValue(@shareUserID)));
			parameters.Add(new SqlParameter("@CouponUserID", EntityBase.GetDatabaseValue(@couponUserID)));
			parameters.Add(new SqlParameter("@ShipRateID", EntityBase.GetDatabaseValue(@shipRateID)));
			parameters.Add(new SqlParameter("@ShipRateName", EntityBase.GetDatabaseValue(@shipRateName)));
			parameters.Add(new SqlParameter("@TotalSalePoint", EntityBase.GetDatabaseValue(@totalSalePoint)));
			parameters.Add(new SqlParameter("@TotalVIPSalePoint", EntityBase.GetDatabaseValue(@totalVIPSalePoint)));
			parameters.Add(new SqlParameter("@IsAPPUserSent", @isAPPUserSent));
			parameters.Add(new SqlParameter("@IsCanGrab", @isCanGrab));
			parameters.Add(new SqlParameter("@GrabSendTime", EntityBase.GetDatabaseValue(@grabSendTime)));
			parameters.Add(new SqlParameter("@GrabStatus", EntityBase.GetDatabaseValue(@grabStatus)));
			parameters.Add(new SqlParameter("@CompleteRemark", EntityBase.GetDatabaseValue(@completeRemark)));
			parameters.Add(new SqlParameter("@PurchaseType", EntityBase.GetDatabaseValue(@purchaseType)));
			parameters.Add(new SqlParameter("@TotalSaleStaffPoint", EntityBase.GetDatabaseValue(@totalSaleStaffPoint)));
			parameters.Add(new SqlParameter("@ShipRemark", EntityBase.GetDatabaseValue(@shipRemark)));
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			parameters.Add(new SqlParameter("@IsPaied", @isPaied));
			parameters.Add(new SqlParameter("@BusinessCompleteTime", EntityBase.GetDatabaseValue(@businessCompleteTime)));
			parameters.Add(new SqlParameter("@ShipDelivererName", EntityBase.GetDatabaseValue(@shipDelivererName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_Order into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="orderType">orderType</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="orderStatus">orderStatus</param>
		/// <param name="userID">userID</param>
		/// <param name="userName">userName</param>
		/// <param name="addressID">addressID</param>
		/// <param name="addressProvince">addressProvince</param>
		/// <param name="addressCity">addressCity</param>
		/// <param name="addressDistrict">addressDistrict</param>
		/// <param name="addressDetailInfo">addressDetailInfo</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="printID">printID</param>
		/// <param name="payTime">payTime</param>
		/// <param name="shipTime">shipTime</param>
		/// <param name="completeTime">completeTime</param>
		/// <param name="closeTime">closeTime</param>
		/// <param name="userNote">userNote</param>
		/// <param name="addressUserName">addressUserName</param>
		/// <param name="addressPhoneNumber">addressPhoneNumber</param>
		/// <param name="productTypeID">productTypeID</param>
		/// <param name="pin_OrganiserID">pin_OrganiserID</param>
		/// <param name="pin_UserID">pin_UserID</param>
		/// <param name="payUserName">payUserName</param>
		/// <param name="shipTrackNo">shipTrackNo</param>
		/// <param name="shipCompanyName">shipCompanyName</param>
		/// <param name="shipUserName">shipUserName</param>
		/// <param name="completeUserName">completeUserName</param>
		/// <param name="closeUserName">closeUserName</param>
		/// <param name="paymentMethod">paymentMethod</param>
		/// <param name="couponID">couponID</param>
		/// <param name="couponAmount">couponAmount</param>
		/// <param name="productAmount">productAmount</param>
		/// <param name="isDeleted">isDeleted</param>
		/// <param name="deleteTime">deleteTime</param>
		/// <param name="deleteUserName">deleteUserName</param>
		/// <param name="isClosed">isClosed</param>
		/// <param name="refundTrackNo">refundTrackNo</param>
		/// <param name="refundRequestTime">refundRequestTime</param>
		/// <param name="refundTime">refundTime</param>
		/// <param name="addressRoomID">addressRoomID</param>
		/// <param name="addressProjectID">addressProjectID</param>
		/// <param name="originalTotalCost">originalTotalCost</param>
		/// <param name="lastTotalCost">lastTotalCost</param>
		/// <param name="sellerNote">sellerNote</param>
		/// <param name="isShareOrder">isShareOrder</param>
		/// <param name="addressProvinceID">addressProvinceID</param>
		/// <param name="shipRateAmount">shipRateAmount</param>
		/// <param name="isReadNewOrder">isReadNewOrder</param>
		/// <param name="isReadRefundOrder">isReadRefundOrder</param>
		/// <param name="shareUserID">shareUserID</param>
		/// <param name="couponUserID">couponUserID</param>
		/// <param name="shipRateID">shipRateID</param>
		/// <param name="shipRateName">shipRateName</param>
		/// <param name="totalSalePoint">totalSalePoint</param>
		/// <param name="totalVIPSalePoint">totalVIPSalePoint</param>
		/// <param name="isAPPUserSent">isAPPUserSent</param>
		/// <param name="isCanGrab">isCanGrab</param>
		/// <param name="grabSendTime">grabSendTime</param>
		/// <param name="grabStatus">grabStatus</param>
		/// <param name="completeRemark">completeRemark</param>
		/// <param name="purchaseType">purchaseType</param>
		/// <param name="totalSaleStaffPoint">totalSaleStaffPoint</param>
		/// <param name="shipRemark">shipRemark</param>
		/// <param name="businessID">businessID</param>
		/// <param name="isPaied">isPaied</param>
		/// <param name="businessCompleteTime">businessCompleteTime</param>
		/// <param name="shipDelivererName">shipDelivererName</param>
		public static void UpdateMall_Order(int @iD, string @orderNumber, string @tradeNo, int @orderType, decimal @totalCost, int @orderStatus, int @userID, string @userName, int @addressID, string @addressProvince, string @addressCity, string @addressDistrict, string @addressDetailInfo, DateTime @addTime, string @addUser, int @printID, DateTime @payTime, DateTime @shipTime, DateTime @completeTime, DateTime @closeTime, string @userNote, string @addressUserName, string @addressPhoneNumber, int @productTypeID, int @pin_OrganiserID, int @pin_UserID, string @payUserName, string @shipTrackNo, string @shipCompanyName, string @shipUserName, string @completeUserName, string @closeUserName, string @paymentMethod, int @couponID, decimal @couponAmount, decimal @productAmount, bool @isDeleted, DateTime @deleteTime, string @deleteUserName, bool @isClosed, string @refundTrackNo, DateTime @refundRequestTime, DateTime @refundTime, int @addressRoomID, int @addressProjectID, decimal @originalTotalCost, decimal @lastTotalCost, string @sellerNote, bool @isShareOrder, int @addressProvinceID, decimal @shipRateAmount, bool @isReadNewOrder, bool @isReadRefundOrder, int @shareUserID, int @couponUserID, int @shipRateID, string @shipRateName, int @totalSalePoint, int @totalVIPSalePoint, bool @isAPPUserSent, bool @isCanGrab, DateTime @grabSendTime, int @grabStatus, string @completeRemark, int @purchaseType, int @totalSaleStaffPoint, string @shipRemark, int @businessID, bool @isPaied, DateTime @businessCompleteTime, string @shipDelivererName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_Order(@iD, @orderNumber, @tradeNo, @orderType, @totalCost, @orderStatus, @userID, @userName, @addressID, @addressProvince, @addressCity, @addressDistrict, @addressDetailInfo, @addTime, @addUser, @printID, @payTime, @shipTime, @completeTime, @closeTime, @userNote, @addressUserName, @addressPhoneNumber, @productTypeID, @pin_OrganiserID, @pin_UserID, @payUserName, @shipTrackNo, @shipCompanyName, @shipUserName, @completeUserName, @closeUserName, @paymentMethod, @couponID, @couponAmount, @productAmount, @isDeleted, @deleteTime, @deleteUserName, @isClosed, @refundTrackNo, @refundRequestTime, @refundTime, @addressRoomID, @addressProjectID, @originalTotalCost, @lastTotalCost, @sellerNote, @isShareOrder, @addressProvinceID, @shipRateAmount, @isReadNewOrder, @isReadRefundOrder, @shareUserID, @couponUserID, @shipRateID, @shipRateName, @totalSalePoint, @totalVIPSalePoint, @isAPPUserSent, @isCanGrab, @grabSendTime, @grabStatus, @completeRemark, @purchaseType, @totalSaleStaffPoint, @shipRemark, @businessID, @isPaied, @businessCompleteTime, @shipDelivererName, helper);
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
		/// Updates a Mall_Order into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="orderType">orderType</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="orderStatus">orderStatus</param>
		/// <param name="userID">userID</param>
		/// <param name="userName">userName</param>
		/// <param name="addressID">addressID</param>
		/// <param name="addressProvince">addressProvince</param>
		/// <param name="addressCity">addressCity</param>
		/// <param name="addressDistrict">addressDistrict</param>
		/// <param name="addressDetailInfo">addressDetailInfo</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="printID">printID</param>
		/// <param name="payTime">payTime</param>
		/// <param name="shipTime">shipTime</param>
		/// <param name="completeTime">completeTime</param>
		/// <param name="closeTime">closeTime</param>
		/// <param name="userNote">userNote</param>
		/// <param name="addressUserName">addressUserName</param>
		/// <param name="addressPhoneNumber">addressPhoneNumber</param>
		/// <param name="productTypeID">productTypeID</param>
		/// <param name="pin_OrganiserID">pin_OrganiserID</param>
		/// <param name="pin_UserID">pin_UserID</param>
		/// <param name="payUserName">payUserName</param>
		/// <param name="shipTrackNo">shipTrackNo</param>
		/// <param name="shipCompanyName">shipCompanyName</param>
		/// <param name="shipUserName">shipUserName</param>
		/// <param name="completeUserName">completeUserName</param>
		/// <param name="closeUserName">closeUserName</param>
		/// <param name="paymentMethod">paymentMethod</param>
		/// <param name="couponID">couponID</param>
		/// <param name="couponAmount">couponAmount</param>
		/// <param name="productAmount">productAmount</param>
		/// <param name="isDeleted">isDeleted</param>
		/// <param name="deleteTime">deleteTime</param>
		/// <param name="deleteUserName">deleteUserName</param>
		/// <param name="isClosed">isClosed</param>
		/// <param name="refundTrackNo">refundTrackNo</param>
		/// <param name="refundRequestTime">refundRequestTime</param>
		/// <param name="refundTime">refundTime</param>
		/// <param name="addressRoomID">addressRoomID</param>
		/// <param name="addressProjectID">addressProjectID</param>
		/// <param name="originalTotalCost">originalTotalCost</param>
		/// <param name="lastTotalCost">lastTotalCost</param>
		/// <param name="sellerNote">sellerNote</param>
		/// <param name="isShareOrder">isShareOrder</param>
		/// <param name="addressProvinceID">addressProvinceID</param>
		/// <param name="shipRateAmount">shipRateAmount</param>
		/// <param name="isReadNewOrder">isReadNewOrder</param>
		/// <param name="isReadRefundOrder">isReadRefundOrder</param>
		/// <param name="shareUserID">shareUserID</param>
		/// <param name="couponUserID">couponUserID</param>
		/// <param name="shipRateID">shipRateID</param>
		/// <param name="shipRateName">shipRateName</param>
		/// <param name="totalSalePoint">totalSalePoint</param>
		/// <param name="totalVIPSalePoint">totalVIPSalePoint</param>
		/// <param name="isAPPUserSent">isAPPUserSent</param>
		/// <param name="isCanGrab">isCanGrab</param>
		/// <param name="grabSendTime">grabSendTime</param>
		/// <param name="grabStatus">grabStatus</param>
		/// <param name="completeRemark">completeRemark</param>
		/// <param name="purchaseType">purchaseType</param>
		/// <param name="totalSaleStaffPoint">totalSaleStaffPoint</param>
		/// <param name="shipRemark">shipRemark</param>
		/// <param name="businessID">businessID</param>
		/// <param name="isPaied">isPaied</param>
		/// <param name="businessCompleteTime">businessCompleteTime</param>
		/// <param name="shipDelivererName">shipDelivererName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_Order(int @iD, string @orderNumber, string @tradeNo, int @orderType, decimal @totalCost, int @orderStatus, int @userID, string @userName, int @addressID, string @addressProvince, string @addressCity, string @addressDistrict, string @addressDetailInfo, DateTime @addTime, string @addUser, int @printID, DateTime @payTime, DateTime @shipTime, DateTime @completeTime, DateTime @closeTime, string @userNote, string @addressUserName, string @addressPhoneNumber, int @productTypeID, int @pin_OrganiserID, int @pin_UserID, string @payUserName, string @shipTrackNo, string @shipCompanyName, string @shipUserName, string @completeUserName, string @closeUserName, string @paymentMethod, int @couponID, decimal @couponAmount, decimal @productAmount, bool @isDeleted, DateTime @deleteTime, string @deleteUserName, bool @isClosed, string @refundTrackNo, DateTime @refundRequestTime, DateTime @refundTime, int @addressRoomID, int @addressProjectID, decimal @originalTotalCost, decimal @lastTotalCost, string @sellerNote, bool @isShareOrder, int @addressProvinceID, decimal @shipRateAmount, bool @isReadNewOrder, bool @isReadRefundOrder, int @shareUserID, int @couponUserID, int @shipRateID, string @shipRateName, int @totalSalePoint, int @totalVIPSalePoint, bool @isAPPUserSent, bool @isCanGrab, DateTime @grabSendTime, int @grabStatus, string @completeRemark, int @purchaseType, int @totalSaleStaffPoint, string @shipRemark, int @businessID, bool @isPaied, DateTime @businessCompleteTime, string @shipDelivererName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrderNumber] nvarchar(100),
	[TradeNo] nvarchar(100),
	[OrderType] int,
	[TotalCost] decimal(18, 2),
	[OrderStatus] int,
	[UserID] int,
	[UserName] nvarchar(100),
	[AddressID] int,
	[AddressProvince] nvarchar(100),
	[AddressCity] nvarchar(100),
	[AddressDistrict] nvarchar(100),
	[AddressDetailInfo] nvarchar(500),
	[AddTime] datetime,
	[AddUser] nvarchar(100),
	[PrintID] int,
	[PayTime] datetime,
	[ShipTime] datetime,
	[CompleteTime] datetime,
	[CloseTime] datetime,
	[UserNote] nvarchar(500),
	[AddressUserName] nvarchar(100),
	[AddressPhoneNumber] nvarchar(100),
	[ProductTypeID] int,
	[Pin_OrganiserID] int,
	[Pin_UserID] int,
	[PayUserName] nvarchar(200),
	[ShipTrackNo] nvarchar(500),
	[ShipCompanyName] nvarchar(500),
	[ShipUserName] nvarchar(500),
	[CompleteUserName] nvarchar(500),
	[CloseUserName] nvarchar(500),
	[PaymentMethod] nvarchar(500),
	[CouponID] int,
	[CouponAmount] decimal(18, 2),
	[ProductAmount] decimal(18, 2),
	[IsDeleted] bit,
	[DeleteTime] datetime,
	[DeleteUserName] nvarchar(200),
	[IsClosed] bit,
	[RefundTrackNo] nvarchar(200),
	[RefundRequestTime] datetime,
	[RefundTime] datetime,
	[AddressRoomID] int,
	[AddressProjectID] int,
	[OriginalTotalCost] decimal(18, 2),
	[LastTotalCost] decimal(18, 2),
	[SellerNote] ntext,
	[IsShareOrder] bit,
	[AddressProvinceID] int,
	[ShipRateAmount] decimal(18, 2),
	[IsReadNewOrder] bit,
	[IsReadRefundOrder] bit,
	[ShareUserID] int,
	[CouponUserID] int,
	[ShipRateID] int,
	[ShipRateName] nvarchar(200),
	[TotalSalePoint] int,
	[TotalVIPSalePoint] int,
	[IsAPPUserSent] bit,
	[IsCanGrab] bit,
	[GrabSendTime] datetime,
	[GrabStatus] int,
	[CompleteRemark] ntext,
	[PurchaseType] int,
	[TotalSaleStaffPoint] int,
	[ShipRemark] ntext,
	[BusinessID] int,
	[IsPaied] bit,
	[BusinessCompleteTime] datetime,
	[ShipDelivererName] nvarchar(100)
);

UPDATE [dbo].[Mall_Order] SET 
	[Mall_Order].[OrderNumber] = @OrderNumber,
	[Mall_Order].[TradeNo] = @TradeNo,
	[Mall_Order].[OrderType] = @OrderType,
	[Mall_Order].[TotalCost] = @TotalCost,
	[Mall_Order].[OrderStatus] = @OrderStatus,
	[Mall_Order].[UserID] = @UserID,
	[Mall_Order].[UserName] = @UserName,
	[Mall_Order].[AddressID] = @AddressID,
	[Mall_Order].[AddressProvince] = @AddressProvince,
	[Mall_Order].[AddressCity] = @AddressCity,
	[Mall_Order].[AddressDistrict] = @AddressDistrict,
	[Mall_Order].[AddressDetailInfo] = @AddressDetailInfo,
	[Mall_Order].[AddTime] = @AddTime,
	[Mall_Order].[AddUser] = @AddUser,
	[Mall_Order].[PrintID] = @PrintID,
	[Mall_Order].[PayTime] = @PayTime,
	[Mall_Order].[ShipTime] = @ShipTime,
	[Mall_Order].[CompleteTime] = @CompleteTime,
	[Mall_Order].[CloseTime] = @CloseTime,
	[Mall_Order].[UserNote] = @UserNote,
	[Mall_Order].[AddressUserName] = @AddressUserName,
	[Mall_Order].[AddressPhoneNumber] = @AddressPhoneNumber,
	[Mall_Order].[ProductTypeID] = @ProductTypeID,
	[Mall_Order].[Pin_OrganiserID] = @Pin_OrganiserID,
	[Mall_Order].[Pin_UserID] = @Pin_UserID,
	[Mall_Order].[PayUserName] = @PayUserName,
	[Mall_Order].[ShipTrackNo] = @ShipTrackNo,
	[Mall_Order].[ShipCompanyName] = @ShipCompanyName,
	[Mall_Order].[ShipUserName] = @ShipUserName,
	[Mall_Order].[CompleteUserName] = @CompleteUserName,
	[Mall_Order].[CloseUserName] = @CloseUserName,
	[Mall_Order].[PaymentMethod] = @PaymentMethod,
	[Mall_Order].[CouponID] = @CouponID,
	[Mall_Order].[CouponAmount] = @CouponAmount,
	[Mall_Order].[ProductAmount] = @ProductAmount,
	[Mall_Order].[IsDeleted] = @IsDeleted,
	[Mall_Order].[DeleteTime] = @DeleteTime,
	[Mall_Order].[DeleteUserName] = @DeleteUserName,
	[Mall_Order].[IsClosed] = @IsClosed,
	[Mall_Order].[RefundTrackNo] = @RefundTrackNo,
	[Mall_Order].[RefundRequestTime] = @RefundRequestTime,
	[Mall_Order].[RefundTime] = @RefundTime,
	[Mall_Order].[AddressRoomID] = @AddressRoomID,
	[Mall_Order].[AddressProjectID] = @AddressProjectID,
	[Mall_Order].[OriginalTotalCost] = @OriginalTotalCost,
	[Mall_Order].[LastTotalCost] = @LastTotalCost,
	[Mall_Order].[SellerNote] = @SellerNote,
	[Mall_Order].[IsShareOrder] = @IsShareOrder,
	[Mall_Order].[AddressProvinceID] = @AddressProvinceID,
	[Mall_Order].[ShipRateAmount] = @ShipRateAmount,
	[Mall_Order].[IsReadNewOrder] = @IsReadNewOrder,
	[Mall_Order].[IsReadRefundOrder] = @IsReadRefundOrder,
	[Mall_Order].[ShareUserID] = @ShareUserID,
	[Mall_Order].[CouponUserID] = @CouponUserID,
	[Mall_Order].[ShipRateID] = @ShipRateID,
	[Mall_Order].[ShipRateName] = @ShipRateName,
	[Mall_Order].[TotalSalePoint] = @TotalSalePoint,
	[Mall_Order].[TotalVIPSalePoint] = @TotalVIPSalePoint,
	[Mall_Order].[IsAPPUserSent] = @IsAPPUserSent,
	[Mall_Order].[IsCanGrab] = @IsCanGrab,
	[Mall_Order].[GrabSendTime] = @GrabSendTime,
	[Mall_Order].[GrabStatus] = @GrabStatus,
	[Mall_Order].[CompleteRemark] = @CompleteRemark,
	[Mall_Order].[PurchaseType] = @PurchaseType,
	[Mall_Order].[TotalSaleStaffPoint] = @TotalSaleStaffPoint,
	[Mall_Order].[ShipRemark] = @ShipRemark,
	[Mall_Order].[BusinessID] = @BusinessID,
	[Mall_Order].[IsPaied] = @IsPaied,
	[Mall_Order].[BusinessCompleteTime] = @BusinessCompleteTime,
	[Mall_Order].[ShipDelivererName] = @ShipDelivererName 
output 
	INSERTED.[ID],
	INSERTED.[OrderNumber],
	INSERTED.[TradeNo],
	INSERTED.[OrderType],
	INSERTED.[TotalCost],
	INSERTED.[OrderStatus],
	INSERTED.[UserID],
	INSERTED.[UserName],
	INSERTED.[AddressID],
	INSERTED.[AddressProvince],
	INSERTED.[AddressCity],
	INSERTED.[AddressDistrict],
	INSERTED.[AddressDetailInfo],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[PrintID],
	INSERTED.[PayTime],
	INSERTED.[ShipTime],
	INSERTED.[CompleteTime],
	INSERTED.[CloseTime],
	INSERTED.[UserNote],
	INSERTED.[AddressUserName],
	INSERTED.[AddressPhoneNumber],
	INSERTED.[ProductTypeID],
	INSERTED.[Pin_OrganiserID],
	INSERTED.[Pin_UserID],
	INSERTED.[PayUserName],
	INSERTED.[ShipTrackNo],
	INSERTED.[ShipCompanyName],
	INSERTED.[ShipUserName],
	INSERTED.[CompleteUserName],
	INSERTED.[CloseUserName],
	INSERTED.[PaymentMethod],
	INSERTED.[CouponID],
	INSERTED.[CouponAmount],
	INSERTED.[ProductAmount],
	INSERTED.[IsDeleted],
	INSERTED.[DeleteTime],
	INSERTED.[DeleteUserName],
	INSERTED.[IsClosed],
	INSERTED.[RefundTrackNo],
	INSERTED.[RefundRequestTime],
	INSERTED.[RefundTime],
	INSERTED.[AddressRoomID],
	INSERTED.[AddressProjectID],
	INSERTED.[OriginalTotalCost],
	INSERTED.[LastTotalCost],
	INSERTED.[SellerNote],
	INSERTED.[IsShareOrder],
	INSERTED.[AddressProvinceID],
	INSERTED.[ShipRateAmount],
	INSERTED.[IsReadNewOrder],
	INSERTED.[IsReadRefundOrder],
	INSERTED.[ShareUserID],
	INSERTED.[CouponUserID],
	INSERTED.[ShipRateID],
	INSERTED.[ShipRateName],
	INSERTED.[TotalSalePoint],
	INSERTED.[TotalVIPSalePoint],
	INSERTED.[IsAPPUserSent],
	INSERTED.[IsCanGrab],
	INSERTED.[GrabSendTime],
	INSERTED.[GrabStatus],
	INSERTED.[CompleteRemark],
	INSERTED.[PurchaseType],
	INSERTED.[TotalSaleStaffPoint],
	INSERTED.[ShipRemark],
	INSERTED.[BusinessID],
	INSERTED.[IsPaied],
	INSERTED.[BusinessCompleteTime],
	INSERTED.[ShipDelivererName]
into @table
WHERE 
	[Mall_Order].[ID] = @ID

SELECT 
	[ID],
	[OrderNumber],
	[TradeNo],
	[OrderType],
	[TotalCost],
	[OrderStatus],
	[UserID],
	[UserName],
	[AddressID],
	[AddressProvince],
	[AddressCity],
	[AddressDistrict],
	[AddressDetailInfo],
	[AddTime],
	[AddUser],
	[PrintID],
	[PayTime],
	[ShipTime],
	[CompleteTime],
	[CloseTime],
	[UserNote],
	[AddressUserName],
	[AddressPhoneNumber],
	[ProductTypeID],
	[Pin_OrganiserID],
	[Pin_UserID],
	[PayUserName],
	[ShipTrackNo],
	[ShipCompanyName],
	[ShipUserName],
	[CompleteUserName],
	[CloseUserName],
	[PaymentMethod],
	[CouponID],
	[CouponAmount],
	[ProductAmount],
	[IsDeleted],
	[DeleteTime],
	[DeleteUserName],
	[IsClosed],
	[RefundTrackNo],
	[RefundRequestTime],
	[RefundTime],
	[AddressRoomID],
	[AddressProjectID],
	[OriginalTotalCost],
	[LastTotalCost],
	[SellerNote],
	[IsShareOrder],
	[AddressProvinceID],
	[ShipRateAmount],
	[IsReadNewOrder],
	[IsReadRefundOrder],
	[ShareUserID],
	[CouponUserID],
	[ShipRateID],
	[ShipRateName],
	[TotalSalePoint],
	[TotalVIPSalePoint],
	[IsAPPUserSent],
	[IsCanGrab],
	[GrabSendTime],
	[GrabStatus],
	[CompleteRemark],
	[PurchaseType],
	[TotalSaleStaffPoint],
	[ShipRemark],
	[BusinessID],
	[IsPaied],
	[BusinessCompleteTime],
	[ShipDelivererName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OrderNumber", EntityBase.GetDatabaseValue(@orderNumber)));
			parameters.Add(new SqlParameter("@TradeNo", EntityBase.GetDatabaseValue(@tradeNo)));
			parameters.Add(new SqlParameter("@OrderType", EntityBase.GetDatabaseValue(@orderType)));
			parameters.Add(new SqlParameter("@TotalCost", EntityBase.GetDatabaseValue(@totalCost)));
			parameters.Add(new SqlParameter("@OrderStatus", EntityBase.GetDatabaseValue(@orderStatus)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@UserName", EntityBase.GetDatabaseValue(@userName)));
			parameters.Add(new SqlParameter("@AddressID", EntityBase.GetDatabaseValue(@addressID)));
			parameters.Add(new SqlParameter("@AddressProvince", EntityBase.GetDatabaseValue(@addressProvince)));
			parameters.Add(new SqlParameter("@AddressCity", EntityBase.GetDatabaseValue(@addressCity)));
			parameters.Add(new SqlParameter("@AddressDistrict", EntityBase.GetDatabaseValue(@addressDistrict)));
			parameters.Add(new SqlParameter("@AddressDetailInfo", EntityBase.GetDatabaseValue(@addressDetailInfo)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUser", EntityBase.GetDatabaseValue(@addUser)));
			parameters.Add(new SqlParameter("@PrintID", EntityBase.GetDatabaseValue(@printID)));
			parameters.Add(new SqlParameter("@PayTime", EntityBase.GetDatabaseValue(@payTime)));
			parameters.Add(new SqlParameter("@ShipTime", EntityBase.GetDatabaseValue(@shipTime)));
			parameters.Add(new SqlParameter("@CompleteTime", EntityBase.GetDatabaseValue(@completeTime)));
			parameters.Add(new SqlParameter("@CloseTime", EntityBase.GetDatabaseValue(@closeTime)));
			parameters.Add(new SqlParameter("@UserNote", EntityBase.GetDatabaseValue(@userNote)));
			parameters.Add(new SqlParameter("@AddressUserName", EntityBase.GetDatabaseValue(@addressUserName)));
			parameters.Add(new SqlParameter("@AddressPhoneNumber", EntityBase.GetDatabaseValue(@addressPhoneNumber)));
			parameters.Add(new SqlParameter("@ProductTypeID", EntityBase.GetDatabaseValue(@productTypeID)));
			parameters.Add(new SqlParameter("@Pin_OrganiserID", EntityBase.GetDatabaseValue(@pin_OrganiserID)));
			parameters.Add(new SqlParameter("@Pin_UserID", EntityBase.GetDatabaseValue(@pin_UserID)));
			parameters.Add(new SqlParameter("@PayUserName", EntityBase.GetDatabaseValue(@payUserName)));
			parameters.Add(new SqlParameter("@ShipTrackNo", EntityBase.GetDatabaseValue(@shipTrackNo)));
			parameters.Add(new SqlParameter("@ShipCompanyName", EntityBase.GetDatabaseValue(@shipCompanyName)));
			parameters.Add(new SqlParameter("@ShipUserName", EntityBase.GetDatabaseValue(@shipUserName)));
			parameters.Add(new SqlParameter("@CompleteUserName", EntityBase.GetDatabaseValue(@completeUserName)));
			parameters.Add(new SqlParameter("@CloseUserName", EntityBase.GetDatabaseValue(@closeUserName)));
			parameters.Add(new SqlParameter("@PaymentMethod", EntityBase.GetDatabaseValue(@paymentMethod)));
			parameters.Add(new SqlParameter("@CouponID", EntityBase.GetDatabaseValue(@couponID)));
			parameters.Add(new SqlParameter("@CouponAmount", EntityBase.GetDatabaseValue(@couponAmount)));
			parameters.Add(new SqlParameter("@ProductAmount", EntityBase.GetDatabaseValue(@productAmount)));
			parameters.Add(new SqlParameter("@IsDeleted", @isDeleted));
			parameters.Add(new SqlParameter("@DeleteTime", EntityBase.GetDatabaseValue(@deleteTime)));
			parameters.Add(new SqlParameter("@DeleteUserName", EntityBase.GetDatabaseValue(@deleteUserName)));
			parameters.Add(new SqlParameter("@IsClosed", @isClosed));
			parameters.Add(new SqlParameter("@RefundTrackNo", EntityBase.GetDatabaseValue(@refundTrackNo)));
			parameters.Add(new SqlParameter("@RefundRequestTime", EntityBase.GetDatabaseValue(@refundRequestTime)));
			parameters.Add(new SqlParameter("@RefundTime", EntityBase.GetDatabaseValue(@refundTime)));
			parameters.Add(new SqlParameter("@AddressRoomID", EntityBase.GetDatabaseValue(@addressRoomID)));
			parameters.Add(new SqlParameter("@AddressProjectID", EntityBase.GetDatabaseValue(@addressProjectID)));
			parameters.Add(new SqlParameter("@OriginalTotalCost", EntityBase.GetDatabaseValue(@originalTotalCost)));
			parameters.Add(new SqlParameter("@LastTotalCost", EntityBase.GetDatabaseValue(@lastTotalCost)));
			parameters.Add(new SqlParameter("@SellerNote", EntityBase.GetDatabaseValue(@sellerNote)));
			parameters.Add(new SqlParameter("@IsShareOrder", @isShareOrder));
			parameters.Add(new SqlParameter("@AddressProvinceID", EntityBase.GetDatabaseValue(@addressProvinceID)));
			parameters.Add(new SqlParameter("@ShipRateAmount", EntityBase.GetDatabaseValue(@shipRateAmount)));
			parameters.Add(new SqlParameter("@IsReadNewOrder", @isReadNewOrder));
			parameters.Add(new SqlParameter("@IsReadRefundOrder", @isReadRefundOrder));
			parameters.Add(new SqlParameter("@ShareUserID", EntityBase.GetDatabaseValue(@shareUserID)));
			parameters.Add(new SqlParameter("@CouponUserID", EntityBase.GetDatabaseValue(@couponUserID)));
			parameters.Add(new SqlParameter("@ShipRateID", EntityBase.GetDatabaseValue(@shipRateID)));
			parameters.Add(new SqlParameter("@ShipRateName", EntityBase.GetDatabaseValue(@shipRateName)));
			parameters.Add(new SqlParameter("@TotalSalePoint", EntityBase.GetDatabaseValue(@totalSalePoint)));
			parameters.Add(new SqlParameter("@TotalVIPSalePoint", EntityBase.GetDatabaseValue(@totalVIPSalePoint)));
			parameters.Add(new SqlParameter("@IsAPPUserSent", @isAPPUserSent));
			parameters.Add(new SqlParameter("@IsCanGrab", @isCanGrab));
			parameters.Add(new SqlParameter("@GrabSendTime", EntityBase.GetDatabaseValue(@grabSendTime)));
			parameters.Add(new SqlParameter("@GrabStatus", EntityBase.GetDatabaseValue(@grabStatus)));
			parameters.Add(new SqlParameter("@CompleteRemark", EntityBase.GetDatabaseValue(@completeRemark)));
			parameters.Add(new SqlParameter("@PurchaseType", EntityBase.GetDatabaseValue(@purchaseType)));
			parameters.Add(new SqlParameter("@TotalSaleStaffPoint", EntityBase.GetDatabaseValue(@totalSaleStaffPoint)));
			parameters.Add(new SqlParameter("@ShipRemark", EntityBase.GetDatabaseValue(@shipRemark)));
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			parameters.Add(new SqlParameter("@IsPaied", @isPaied));
			parameters.Add(new SqlParameter("@BusinessCompleteTime", EntityBase.GetDatabaseValue(@businessCompleteTime)));
			parameters.Add(new SqlParameter("@ShipDelivererName", EntityBase.GetDatabaseValue(@shipDelivererName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_Order from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_Order(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_Order(@iD, helper);
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
		/// Deletes a Mall_Order from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_Order(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_Order]
WHERE 
	[Mall_Order].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_Order object.
		/// </summary>
		/// <returns>The newly created Mall_Order object.</returns>
		public static Mall_Order CreateMall_Order()
		{
			return InitializeNew<Mall_Order>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_Order by a Mall_Order's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_Order</returns>
		public static Mall_Order GetMall_Order(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_Order.SelectFieldList + @"
FROM [dbo].[Mall_Order] 
WHERE 
	[Mall_Order].[ID] = @ID " + Mall_Order.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Order>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_Order by a Mall_Order's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_Order</returns>
		public static Mall_Order GetMall_Order(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_Order.SelectFieldList + @"
FROM [dbo].[Mall_Order] 
WHERE 
	[Mall_Order].[ID] = @ID " + Mall_Order.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Order>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_Order objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_Order objects.</returns>
		public static EntityList<Mall_Order> GetMall_Orders()
		{
			string commandText = @"
SELECT " + Mall_Order.SelectFieldList + "FROM [dbo].[Mall_Order] " + Mall_Order.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_Order>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_Order objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Order objects.</returns>
        public static EntityList<Mall_Order> GetMall_Orders(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Order>(SelectFieldList, "FROM [dbo].[Mall_Order]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_Order objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Order objects.</returns>
        public static EntityList<Mall_Order> GetMall_Orders(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Order>(SelectFieldList, "FROM [dbo].[Mall_Order]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_Order objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Order objects.</returns>
		protected static EntityList<Mall_Order> GetMall_Orders(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Orders(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_Order objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Order objects.</returns>
		protected static EntityList<Mall_Order> GetMall_Orders(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Orders(string.Empty, where, parameters, Mall_Order.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Order objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Order objects.</returns>
		protected static EntityList<Mall_Order> GetMall_Orders(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Orders(prefix, where, parameters, Mall_Order.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Order objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Order objects.</returns>
		protected static EntityList<Mall_Order> GetMall_Orders(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Orders(string.Empty, where, parameters, Mall_Order.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Order objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Order objects.</returns>
		protected static EntityList<Mall_Order> GetMall_Orders(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Orders(prefix, where, parameters, Mall_Order.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Order objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Order objects.</returns>
		protected static EntityList<Mall_Order> GetMall_Orders(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_Order.SelectFieldList + "FROM [dbo].[Mall_Order] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_Order>(reader);
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
        protected static EntityList<Mall_Order> GetMall_Orders(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Order>(SelectFieldList, "FROM [dbo].[Mall_Order] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_Order objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_OrderCount()
        {
            return GetMall_OrderCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_Order objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_OrderCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_Order] " + where;

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
		public static partial class Mall_Order_Properties
		{
			public const string ID = "ID";
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
			public const string AddTime = "AddTime";
			public const string AddUser = "AddUser";
			public const string PrintID = "PrintID";
			public const string PayTime = "PayTime";
			public const string ShipTime = "ShipTime";
			public const string CompleteTime = "CompleteTime";
			public const string CloseTime = "CloseTime";
			public const string UserNote = "UserNote";
			public const string AddressUserName = "AddressUserName";
			public const string AddressPhoneNumber = "AddressPhoneNumber";
			public const string ProductTypeID = "ProductTypeID";
			public const string Pin_OrganiserID = "Pin_OrganiserID";
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
			public const string AddressRoomID = "AddressRoomID";
			public const string AddressProjectID = "AddressProjectID";
			public const string OriginalTotalCost = "OriginalTotalCost";
			public const string LastTotalCost = "LastTotalCost";
			public const string SellerNote = "SellerNote";
			public const string IsShareOrder = "IsShareOrder";
			public const string AddressProvinceID = "AddressProvinceID";
			public const string ShipRateAmount = "ShipRateAmount";
			public const string IsReadNewOrder = "IsReadNewOrder";
			public const string IsReadRefundOrder = "IsReadRefundOrder";
			public const string ShareUserID = "ShareUserID";
			public const string CouponUserID = "CouponUserID";
			public const string ShipRateID = "ShipRateID";
			public const string ShipRateName = "ShipRateName";
			public const string TotalSalePoint = "TotalSalePoint";
			public const string TotalVIPSalePoint = "TotalVIPSalePoint";
			public const string IsAPPUserSent = "IsAPPUserSent";
			public const string IsCanGrab = "IsCanGrab";
			public const string GrabSendTime = "GrabSendTime";
			public const string GrabStatus = "GrabStatus";
			public const string CompleteRemark = "CompleteRemark";
			public const string PurchaseType = "PurchaseType";
			public const string TotalSaleStaffPoint = "TotalSaleStaffPoint";
			public const string ShipRemark = "ShipRemark";
			public const string BusinessID = "BusinessID";
			public const string IsPaied = "IsPaied";
			public const string BusinessCompleteTime = "BusinessCompleteTime";
			public const string ShipDelivererName = "ShipDelivererName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OrderNumber" , "string:"},
    			 {"TradeNo" , "string:"},
    			 {"OrderType" , "int:1-商品购买 2-物业缴费"},
    			 {"TotalCost" , "decimal:"},
    			 {"OrderStatus" , "int:1-待付款 2-已发货 3-已完成 4-已关闭 5-待发货 6-退款中 7-已退款"},
    			 {"UserID" , "int:"},
    			 {"UserName" , "string:"},
    			 {"AddressID" , "int:"},
    			 {"AddressProvince" , "string:"},
    			 {"AddressCity" , "string:"},
    			 {"AddressDistrict" , "string:"},
    			 {"AddressDetailInfo" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUser" , "string:"},
    			 {"PrintID" , "int:"},
    			 {"PayTime" , "DateTime:"},
    			 {"ShipTime" , "DateTime:"},
    			 {"CompleteTime" , "DateTime:"},
    			 {"CloseTime" , "DateTime:"},
    			 {"UserNote" , "string:"},
    			 {"AddressUserName" , "string:"},
    			 {"AddressPhoneNumber" , "string:"},
    			 {"ProductTypeID" , "int:"},
    			 {"Pin_OrganiserID" , "int:"},
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
    			 {"AddressRoomID" , "int:"},
    			 {"AddressProjectID" , "int:"},
    			 {"OriginalTotalCost" , "decimal:"},
    			 {"LastTotalCost" , "decimal:"},
    			 {"SellerNote" , "string:"},
    			 {"IsShareOrder" , "bool:"},
    			 {"AddressProvinceID" , "int:"},
    			 {"ShipRateAmount" , "decimal:"},
    			 {"IsReadNewOrder" , "bool:"},
    			 {"IsReadRefundOrder" , "bool:"},
    			 {"ShareUserID" , "int:"},
    			 {"CouponUserID" , "int:"},
    			 {"ShipRateID" , "int:"},
    			 {"ShipRateName" , "string:"},
    			 {"TotalSalePoint" , "int:"},
    			 {"TotalVIPSalePoint" , "int:"},
    			 {"IsAPPUserSent" , "bool:"},
    			 {"IsCanGrab" , "bool:"},
    			 {"GrabSendTime" , "DateTime:"},
    			 {"GrabStatus" , "int:"},
    			 {"CompleteRemark" , "string:"},
    			 {"PurchaseType" , "int:"},
    			 {"TotalSaleStaffPoint" , "int:"},
    			 {"ShipRemark" , "string:"},
    			 {"BusinessID" , "int:"},
    			 {"IsPaied" , "bool:"},
    			 {"BusinessCompleteTime" , "DateTime:"},
    			 {"ShipDelivererName" , "string:"},
            };
		}
		#endregion
	}
}
