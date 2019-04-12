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
	/// This object represents the properties and methods of a Mall_Product.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_Product 
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
		private string _productName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string ProductName
		{
			[DebuggerStepThrough()]
			get { return this._productName; }
			set 
			{
				if (this._productName != value) 
				{
					this._productName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductName");
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
		private int _productTypeID = int.MinValue;
		/// <summary>
		/// 1-购买商品 2-积分兑换 3-拼团 4-秒杀
		/// </summary>
        [Description("1-购买商品 2-积分兑换 3-拼团 4-秒杀")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private decimal _salePrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal SalePrice
		{
			[DebuggerStepThrough()]
			get { return this._salePrice; }
			set 
			{
				if (this._salePrice != value) 
				{
					this._salePrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("SalePrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _modelNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ModelNumber
		{
			[DebuggerStepThrough()]
			get { return this._modelNumber; }
			set 
			{
				if (this._modelNumber != value) 
				{
					this._modelNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModelNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _totalCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int TotalCount
		{
			[DebuggerStepThrough()]
			get { return this._totalCount; }
			set 
			{
				if (this._totalCount != value) 
				{
					this._totalCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _description = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Description
		{
			[DebuggerStepThrough()]
			get { return this._description; }
			set 
			{
				if (this._description != value) 
				{
					this._description = value;
					this.IsDirty = true;	
					OnPropertyChanged("Description");
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
		private int _status = int.MinValue;
		/// <summary>
		/// 10-出售中 2-已下架 3-待审核 4-审核未通过
		/// </summary>
        [Description("10-出售中 2-已下架 3-待审核 4-审核未通过")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int Status
		{
			[DebuggerStepThrough()]
			get { return this._status; }
			set 
			{
				if (this._status != value) 
				{
					this._status = value;
					this.IsDirty = true;	
					OnPropertyChanged("Status");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveRemark
		{
			[DebuggerStepThrough()]
			get { return this._approveRemark; }
			set 
			{
				if (this._approveRemark != value) 
				{
					this._approveRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveRemark");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _approveTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ApproveTime
		{
			[DebuggerStepThrough()]
			get { return this._approveTime; }
			set 
			{
				if (this._approveTime != value) 
				{
					this._approveTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveMan
		{
			[DebuggerStepThrough()]
			get { return this._approveMan; }
			set 
			{
				if (this._approveMan != value) 
				{
					this._approveMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isZiYing = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsZiYing
		{
			[DebuggerStepThrough()]
			get { return this._isZiYing; }
			set 
			{
				if (this._isZiYing != value) 
				{
					this._isZiYing = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsZiYing");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _pinSalePrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal PinSalePrice
		{
			[DebuggerStepThrough()]
			get { return this._pinSalePrice; }
			set 
			{
				if (this._pinSalePrice != value) 
				{
					this._pinSalePrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("PinSalePrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _pinPeopleCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PinPeopleCount
		{
			[DebuggerStepThrough()]
			get { return this._pinPeopleCount; }
			set 
			{
				if (this._pinPeopleCount != value) 
				{
					this._pinPeopleCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("PinPeopleCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _activeTimeRange = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ActiveTimeRange
		{
			[DebuggerStepThrough()]
			get { return this._activeTimeRange; }
			set 
			{
				if (this._activeTimeRange != value) 
				{
					this._activeTimeRange = value;
					this.IsDirty = true;	
					OnPropertyChanged("ActiveTimeRange");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _pinStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime PinStartTime
		{
			[DebuggerStepThrough()]
			get { return this._pinStartTime; }
			set 
			{
				if (this._pinStartTime != value) 
				{
					this._pinStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("PinStartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _pinEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime PinEndTime
		{
			[DebuggerStepThrough()]
			get { return this._pinEndTime; }
			set 
			{
				if (this._pinEndTime != value) 
				{
					this._pinEndTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("PinEndTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _xianShiSalePrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal XianShiSalePrice
		{
			[DebuggerStepThrough()]
			get { return this._xianShiSalePrice; }
			set 
			{
				if (this._xianShiSalePrice != value) 
				{
					this._xianShiSalePrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("XianShiSalePrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _xianShiStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime XianShiStartTime
		{
			[DebuggerStepThrough()]
			get { return this._xianShiStartTime; }
			set 
			{
				if (this._xianShiStartTime != value) 
				{
					this._xianShiStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("XianShiStartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _xianShiEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime XianShiEndTime
		{
			[DebuggerStepThrough()]
			get { return this._xianShiEndTime; }
			set 
			{
				if (this._xianShiEndTime != value) 
				{
					this._xianShiEndTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("XianShiEndTime");
				}
			}
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
		private bool _isShowOnHome = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsShowOnHome
		{
			[DebuggerStepThrough()]
			get { return this._isShowOnHome; }
			set 
			{
				if (this._isShowOnHome != value) 
				{
					this._isShowOnHome = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsShowOnHome");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _productSummary = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProductSummary
		{
			[DebuggerStepThrough()]
			get { return this._productSummary; }
			set 
			{
				if (this._productSummary != value) 
				{
					this._productSummary = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductSummary");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _quantityLimit = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int QuantityLimit
		{
			[DebuggerStepThrough()]
			get { return this._quantityLimit; }
			set 
			{
				if (this._quantityLimit != value) 
				{
					this._quantityLimit = value;
					this.IsDirty = true;	
					OnPropertyChanged("QuantityLimit");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _sortOrder = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SortOrder
		{
			[DebuggerStepThrough()]
			get { return this._sortOrder; }
			set 
			{
				if (this._sortOrder != value) 
				{
					this._sortOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("SortOrder");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isSuggestion = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsSuggestion
		{
			[DebuggerStepThrough()]
			get { return this._isSuggestion; }
			set 
			{
				if (this._isSuggestion != value) 
				{
					this._isSuggestion = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsSuggestion");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _coverImage = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CoverImage
		{
			[DebuggerStepThrough()]
			get { return this._coverImage; }
			set 
			{
				if (this._coverImage != value) 
				{
					this._coverImage = value;
					this.IsDirty = true;	
					OnPropertyChanged("CoverImage");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isYouXuan = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsYouXuan
		{
			[DebuggerStepThrough()]
			get { return this._isYouXuan; }
			set 
			{
				if (this._isYouXuan != value) 
				{
					this._isYouXuan = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsYouXuan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _shipRateType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ShipRateType
		{
			[DebuggerStepThrough()]
			get { return this._shipRateType; }
			set 
			{
				if (this._shipRateType != value) 
				{
					this._shipRateType = value;
					this.IsDirty = true;	
					OnPropertyChanged("ShipRateType");
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
		private bool _isAllowPointBuy = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAllowPointBuy
		{
			[DebuggerStepThrough()]
			get { return this._isAllowPointBuy; }
			set 
			{
				if (this._isAllowPointBuy != value) 
				{
					this._isAllowPointBuy = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAllowPointBuy");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAllowProductBuy = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAllowProductBuy
		{
			[DebuggerStepThrough()]
			get { return this._isAllowProductBuy; }
			set 
			{
				if (this._isAllowProductBuy != value) 
				{
					this._isAllowProductBuy = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAllowProductBuy");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAllowVIPBuy = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAllowVIPBuy
		{
			[DebuggerStepThrough()]
			get { return this._isAllowVIPBuy; }
			set 
			{
				if (this._isAllowVIPBuy != value) 
				{
					this._isAllowVIPBuy = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAllowVIPBuy");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _youXuanSortOrder = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int YouXuanSortOrder
		{
			[DebuggerStepThrough()]
			get { return this._youXuanSortOrder; }
			set 
			{
				if (this._youXuanSortOrder != value) 
				{
					this._youXuanSortOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("YouXuanSortOrder");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _pinTuanSortOrder = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PinTuanSortOrder
		{
			[DebuggerStepThrough()]
			get { return this._pinTuanSortOrder; }
			set 
			{
				if (this._pinTuanSortOrder != value) 
				{
					this._pinTuanSortOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("PinTuanSortOrder");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAllowStaffBuy = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAllowStaffBuy
		{
			[DebuggerStepThrough()]
			get { return this._isAllowStaffBuy; }
			set 
			{
				if (this._isAllowStaffBuy != value) 
				{
					this._isAllowStaffBuy = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAllowStaffBuy");
				}
			}
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
			set 
			{
				if (this._basicPrice != value) 
				{
					this._basicPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("BasicPrice");
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
	[ProductName] nvarchar(200),
	[BusinessID] int,
	[ProductTypeID] int,
	[SalePrice] decimal(18, 2),
	[ModelNumber] nvarchar(200),
	[TotalCount] int,
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(200),
	[Status] int,
	[ApproveRemark] ntext,
	[ApproveTime] datetime,
	[ApproveMan] nvarchar(100),
	[IsZiYing] bit,
	[PinSalePrice] decimal(18, 2),
	[PinPeopleCount] int,
	[ActiveTimeRange] decimal(18, 2),
	[PinStartTime] datetime,
	[PinEndTime] datetime,
	[XianShiSalePrice] decimal(18, 2),
	[XianShiStartTime] datetime,
	[XianShiEndTime] datetime,
	[Unit] nvarchar(100),
	[IsShowOnHome] bit,
	[ProductSummary] nvarchar(500),
	[QuantityLimit] int,
	[SortOrder] int,
	[IsSuggestion] bit,
	[CoverImage] nvarchar(500),
	[IsYouXuan] bit,
	[ShipRateType] int,
	[ShipRateID] int,
	[IsAllowPointBuy] bit,
	[IsAllowProductBuy] bit,
	[IsAllowVIPBuy] bit,
	[YouXuanSortOrder] int,
	[PinTuanSortOrder] int,
	[IsAllowStaffBuy] bit,
	[BasicPrice] decimal(18, 2)
);

INSERT INTO [dbo].[Mall_Product] (
	[Mall_Product].[ProductName],
	[Mall_Product].[BusinessID],
	[Mall_Product].[ProductTypeID],
	[Mall_Product].[SalePrice],
	[Mall_Product].[ModelNumber],
	[Mall_Product].[TotalCount],
	[Mall_Product].[Description],
	[Mall_Product].[AddTime],
	[Mall_Product].[AddMan],
	[Mall_Product].[Status],
	[Mall_Product].[ApproveRemark],
	[Mall_Product].[ApproveTime],
	[Mall_Product].[ApproveMan],
	[Mall_Product].[IsZiYing],
	[Mall_Product].[PinSalePrice],
	[Mall_Product].[PinPeopleCount],
	[Mall_Product].[ActiveTimeRange],
	[Mall_Product].[PinStartTime],
	[Mall_Product].[PinEndTime],
	[Mall_Product].[XianShiSalePrice],
	[Mall_Product].[XianShiStartTime],
	[Mall_Product].[XianShiEndTime],
	[Mall_Product].[Unit],
	[Mall_Product].[IsShowOnHome],
	[Mall_Product].[ProductSummary],
	[Mall_Product].[QuantityLimit],
	[Mall_Product].[SortOrder],
	[Mall_Product].[IsSuggestion],
	[Mall_Product].[CoverImage],
	[Mall_Product].[IsYouXuan],
	[Mall_Product].[ShipRateType],
	[Mall_Product].[ShipRateID],
	[Mall_Product].[IsAllowPointBuy],
	[Mall_Product].[IsAllowProductBuy],
	[Mall_Product].[IsAllowVIPBuy],
	[Mall_Product].[YouXuanSortOrder],
	[Mall_Product].[PinTuanSortOrder],
	[Mall_Product].[IsAllowStaffBuy],
	[Mall_Product].[BasicPrice]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProductName],
	INSERTED.[BusinessID],
	INSERTED.[ProductTypeID],
	INSERTED.[SalePrice],
	INSERTED.[ModelNumber],
	INSERTED.[TotalCount],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[Status],
	INSERTED.[ApproveRemark],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveMan],
	INSERTED.[IsZiYing],
	INSERTED.[PinSalePrice],
	INSERTED.[PinPeopleCount],
	INSERTED.[ActiveTimeRange],
	INSERTED.[PinStartTime],
	INSERTED.[PinEndTime],
	INSERTED.[XianShiSalePrice],
	INSERTED.[XianShiStartTime],
	INSERTED.[XianShiEndTime],
	INSERTED.[Unit],
	INSERTED.[IsShowOnHome],
	INSERTED.[ProductSummary],
	INSERTED.[QuantityLimit],
	INSERTED.[SortOrder],
	INSERTED.[IsSuggestion],
	INSERTED.[CoverImage],
	INSERTED.[IsYouXuan],
	INSERTED.[ShipRateType],
	INSERTED.[ShipRateID],
	INSERTED.[IsAllowPointBuy],
	INSERTED.[IsAllowProductBuy],
	INSERTED.[IsAllowVIPBuy],
	INSERTED.[YouXuanSortOrder],
	INSERTED.[PinTuanSortOrder],
	INSERTED.[IsAllowStaffBuy],
	INSERTED.[BasicPrice]
into @table
VALUES ( 
	@ProductName,
	@BusinessID,
	@ProductTypeID,
	@SalePrice,
	@ModelNumber,
	@TotalCount,
	@Description,
	@AddTime,
	@AddMan,
	@Status,
	@ApproveRemark,
	@ApproveTime,
	@ApproveMan,
	@IsZiYing,
	@PinSalePrice,
	@PinPeopleCount,
	@ActiveTimeRange,
	@PinStartTime,
	@PinEndTime,
	@XianShiSalePrice,
	@XianShiStartTime,
	@XianShiEndTime,
	@Unit,
	@IsShowOnHome,
	@ProductSummary,
	@QuantityLimit,
	@SortOrder,
	@IsSuggestion,
	@CoverImage,
	@IsYouXuan,
	@ShipRateType,
	@ShipRateID,
	@IsAllowPointBuy,
	@IsAllowProductBuy,
	@IsAllowVIPBuy,
	@YouXuanSortOrder,
	@PinTuanSortOrder,
	@IsAllowStaffBuy,
	@BasicPrice 
); 

SELECT 
	[ID],
	[ProductName],
	[BusinessID],
	[ProductTypeID],
	[SalePrice],
	[ModelNumber],
	[TotalCount],
	[Description],
	[AddTime],
	[AddMan],
	[Status],
	[ApproveRemark],
	[ApproveTime],
	[ApproveMan],
	[IsZiYing],
	[PinSalePrice],
	[PinPeopleCount],
	[ActiveTimeRange],
	[PinStartTime],
	[PinEndTime],
	[XianShiSalePrice],
	[XianShiStartTime],
	[XianShiEndTime],
	[Unit],
	[IsShowOnHome],
	[ProductSummary],
	[QuantityLimit],
	[SortOrder],
	[IsSuggestion],
	[CoverImage],
	[IsYouXuan],
	[ShipRateType],
	[ShipRateID],
	[IsAllowPointBuy],
	[IsAllowProductBuy],
	[IsAllowVIPBuy],
	[YouXuanSortOrder],
	[PinTuanSortOrder],
	[IsAllowStaffBuy],
	[BasicPrice] 
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
	[ProductName] nvarchar(200),
	[BusinessID] int,
	[ProductTypeID] int,
	[SalePrice] decimal(18, 2),
	[ModelNumber] nvarchar(200),
	[TotalCount] int,
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(200),
	[Status] int,
	[ApproveRemark] ntext,
	[ApproveTime] datetime,
	[ApproveMan] nvarchar(100),
	[IsZiYing] bit,
	[PinSalePrice] decimal(18, 2),
	[PinPeopleCount] int,
	[ActiveTimeRange] decimal(18, 2),
	[PinStartTime] datetime,
	[PinEndTime] datetime,
	[XianShiSalePrice] decimal(18, 2),
	[XianShiStartTime] datetime,
	[XianShiEndTime] datetime,
	[Unit] nvarchar(100),
	[IsShowOnHome] bit,
	[ProductSummary] nvarchar(500),
	[QuantityLimit] int,
	[SortOrder] int,
	[IsSuggestion] bit,
	[CoverImage] nvarchar(500),
	[IsYouXuan] bit,
	[ShipRateType] int,
	[ShipRateID] int,
	[IsAllowPointBuy] bit,
	[IsAllowProductBuy] bit,
	[IsAllowVIPBuy] bit,
	[YouXuanSortOrder] int,
	[PinTuanSortOrder] int,
	[IsAllowStaffBuy] bit,
	[BasicPrice] decimal(18, 2)
);

UPDATE [dbo].[Mall_Product] SET 
	[Mall_Product].[ProductName] = @ProductName,
	[Mall_Product].[BusinessID] = @BusinessID,
	[Mall_Product].[ProductTypeID] = @ProductTypeID,
	[Mall_Product].[SalePrice] = @SalePrice,
	[Mall_Product].[ModelNumber] = @ModelNumber,
	[Mall_Product].[TotalCount] = @TotalCount,
	[Mall_Product].[Description] = @Description,
	[Mall_Product].[AddTime] = @AddTime,
	[Mall_Product].[AddMan] = @AddMan,
	[Mall_Product].[Status] = @Status,
	[Mall_Product].[ApproveRemark] = @ApproveRemark,
	[Mall_Product].[ApproveTime] = @ApproveTime,
	[Mall_Product].[ApproveMan] = @ApproveMan,
	[Mall_Product].[IsZiYing] = @IsZiYing,
	[Mall_Product].[PinSalePrice] = @PinSalePrice,
	[Mall_Product].[PinPeopleCount] = @PinPeopleCount,
	[Mall_Product].[ActiveTimeRange] = @ActiveTimeRange,
	[Mall_Product].[PinStartTime] = @PinStartTime,
	[Mall_Product].[PinEndTime] = @PinEndTime,
	[Mall_Product].[XianShiSalePrice] = @XianShiSalePrice,
	[Mall_Product].[XianShiStartTime] = @XianShiStartTime,
	[Mall_Product].[XianShiEndTime] = @XianShiEndTime,
	[Mall_Product].[Unit] = @Unit,
	[Mall_Product].[IsShowOnHome] = @IsShowOnHome,
	[Mall_Product].[ProductSummary] = @ProductSummary,
	[Mall_Product].[QuantityLimit] = @QuantityLimit,
	[Mall_Product].[SortOrder] = @SortOrder,
	[Mall_Product].[IsSuggestion] = @IsSuggestion,
	[Mall_Product].[CoverImage] = @CoverImage,
	[Mall_Product].[IsYouXuan] = @IsYouXuan,
	[Mall_Product].[ShipRateType] = @ShipRateType,
	[Mall_Product].[ShipRateID] = @ShipRateID,
	[Mall_Product].[IsAllowPointBuy] = @IsAllowPointBuy,
	[Mall_Product].[IsAllowProductBuy] = @IsAllowProductBuy,
	[Mall_Product].[IsAllowVIPBuy] = @IsAllowVIPBuy,
	[Mall_Product].[YouXuanSortOrder] = @YouXuanSortOrder,
	[Mall_Product].[PinTuanSortOrder] = @PinTuanSortOrder,
	[Mall_Product].[IsAllowStaffBuy] = @IsAllowStaffBuy,
	[Mall_Product].[BasicPrice] = @BasicPrice 
output 
	INSERTED.[ID],
	INSERTED.[ProductName],
	INSERTED.[BusinessID],
	INSERTED.[ProductTypeID],
	INSERTED.[SalePrice],
	INSERTED.[ModelNumber],
	INSERTED.[TotalCount],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[Status],
	INSERTED.[ApproveRemark],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveMan],
	INSERTED.[IsZiYing],
	INSERTED.[PinSalePrice],
	INSERTED.[PinPeopleCount],
	INSERTED.[ActiveTimeRange],
	INSERTED.[PinStartTime],
	INSERTED.[PinEndTime],
	INSERTED.[XianShiSalePrice],
	INSERTED.[XianShiStartTime],
	INSERTED.[XianShiEndTime],
	INSERTED.[Unit],
	INSERTED.[IsShowOnHome],
	INSERTED.[ProductSummary],
	INSERTED.[QuantityLimit],
	INSERTED.[SortOrder],
	INSERTED.[IsSuggestion],
	INSERTED.[CoverImage],
	INSERTED.[IsYouXuan],
	INSERTED.[ShipRateType],
	INSERTED.[ShipRateID],
	INSERTED.[IsAllowPointBuy],
	INSERTED.[IsAllowProductBuy],
	INSERTED.[IsAllowVIPBuy],
	INSERTED.[YouXuanSortOrder],
	INSERTED.[PinTuanSortOrder],
	INSERTED.[IsAllowStaffBuy],
	INSERTED.[BasicPrice]
into @table
WHERE 
	[Mall_Product].[ID] = @ID

SELECT 
	[ID],
	[ProductName],
	[BusinessID],
	[ProductTypeID],
	[SalePrice],
	[ModelNumber],
	[TotalCount],
	[Description],
	[AddTime],
	[AddMan],
	[Status],
	[ApproveRemark],
	[ApproveTime],
	[ApproveMan],
	[IsZiYing],
	[PinSalePrice],
	[PinPeopleCount],
	[ActiveTimeRange],
	[PinStartTime],
	[PinEndTime],
	[XianShiSalePrice],
	[XianShiStartTime],
	[XianShiEndTime],
	[Unit],
	[IsShowOnHome],
	[ProductSummary],
	[QuantityLimit],
	[SortOrder],
	[IsSuggestion],
	[CoverImage],
	[IsYouXuan],
	[ShipRateType],
	[ShipRateID],
	[IsAllowPointBuy],
	[IsAllowProductBuy],
	[IsAllowVIPBuy],
	[YouXuanSortOrder],
	[PinTuanSortOrder],
	[IsAllowStaffBuy],
	[BasicPrice] 
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
DELETE FROM [dbo].[Mall_Product]
WHERE 
	[Mall_Product].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_Product() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_Product(this.ID));
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
	[Mall_Product].[ID],
	[Mall_Product].[ProductName],
	[Mall_Product].[BusinessID],
	[Mall_Product].[ProductTypeID],
	[Mall_Product].[SalePrice],
	[Mall_Product].[ModelNumber],
	[Mall_Product].[TotalCount],
	[Mall_Product].[Description],
	[Mall_Product].[AddTime],
	[Mall_Product].[AddMan],
	[Mall_Product].[Status],
	[Mall_Product].[ApproveRemark],
	[Mall_Product].[ApproveTime],
	[Mall_Product].[ApproveMan],
	[Mall_Product].[IsZiYing],
	[Mall_Product].[PinSalePrice],
	[Mall_Product].[PinPeopleCount],
	[Mall_Product].[ActiveTimeRange],
	[Mall_Product].[PinStartTime],
	[Mall_Product].[PinEndTime],
	[Mall_Product].[XianShiSalePrice],
	[Mall_Product].[XianShiStartTime],
	[Mall_Product].[XianShiEndTime],
	[Mall_Product].[Unit],
	[Mall_Product].[IsShowOnHome],
	[Mall_Product].[ProductSummary],
	[Mall_Product].[QuantityLimit],
	[Mall_Product].[SortOrder],
	[Mall_Product].[IsSuggestion],
	[Mall_Product].[CoverImage],
	[Mall_Product].[IsYouXuan],
	[Mall_Product].[ShipRateType],
	[Mall_Product].[ShipRateID],
	[Mall_Product].[IsAllowPointBuy],
	[Mall_Product].[IsAllowProductBuy],
	[Mall_Product].[IsAllowVIPBuy],
	[Mall_Product].[YouXuanSortOrder],
	[Mall_Product].[PinTuanSortOrder],
	[Mall_Product].[IsAllowStaffBuy],
	[Mall_Product].[BasicPrice]
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
                return "Mall_Product";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_Product into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productName">productName</param>
		/// <param name="businessID">businessID</param>
		/// <param name="productTypeID">productTypeID</param>
		/// <param name="salePrice">salePrice</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="status">status</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="isZiYing">isZiYing</param>
		/// <param name="pinSalePrice">pinSalePrice</param>
		/// <param name="pinPeopleCount">pinPeopleCount</param>
		/// <param name="activeTimeRange">activeTimeRange</param>
		/// <param name="pinStartTime">pinStartTime</param>
		/// <param name="pinEndTime">pinEndTime</param>
		/// <param name="xianShiSalePrice">xianShiSalePrice</param>
		/// <param name="xianShiStartTime">xianShiStartTime</param>
		/// <param name="xianShiEndTime">xianShiEndTime</param>
		/// <param name="unit">unit</param>
		/// <param name="isShowOnHome">isShowOnHome</param>
		/// <param name="productSummary">productSummary</param>
		/// <param name="quantityLimit">quantityLimit</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isSuggestion">isSuggestion</param>
		/// <param name="coverImage">coverImage</param>
		/// <param name="isYouXuan">isYouXuan</param>
		/// <param name="shipRateType">shipRateType</param>
		/// <param name="shipRateID">shipRateID</param>
		/// <param name="isAllowPointBuy">isAllowPointBuy</param>
		/// <param name="isAllowProductBuy">isAllowProductBuy</param>
		/// <param name="isAllowVIPBuy">isAllowVIPBuy</param>
		/// <param name="youXuanSortOrder">youXuanSortOrder</param>
		/// <param name="pinTuanSortOrder">pinTuanSortOrder</param>
		/// <param name="isAllowStaffBuy">isAllowStaffBuy</param>
		/// <param name="basicPrice">basicPrice</param>
		public static void InsertMall_Product(string @productName, int @businessID, int @productTypeID, decimal @salePrice, string @modelNumber, int @totalCount, string @description, DateTime @addTime, string @addMan, int @status, string @approveRemark, DateTime @approveTime, string @approveMan, bool @isZiYing, decimal @pinSalePrice, int @pinPeopleCount, decimal @activeTimeRange, DateTime @pinStartTime, DateTime @pinEndTime, decimal @xianShiSalePrice, DateTime @xianShiStartTime, DateTime @xianShiEndTime, string @unit, bool @isShowOnHome, string @productSummary, int @quantityLimit, int @sortOrder, bool @isSuggestion, string @coverImage, bool @isYouXuan, int @shipRateType, int @shipRateID, bool @isAllowPointBuy, bool @isAllowProductBuy, bool @isAllowVIPBuy, int @youXuanSortOrder, int @pinTuanSortOrder, bool @isAllowStaffBuy, decimal @basicPrice)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_Product(@productName, @businessID, @productTypeID, @salePrice, @modelNumber, @totalCount, @description, @addTime, @addMan, @status, @approveRemark, @approveTime, @approveMan, @isZiYing, @pinSalePrice, @pinPeopleCount, @activeTimeRange, @pinStartTime, @pinEndTime, @xianShiSalePrice, @xianShiStartTime, @xianShiEndTime, @unit, @isShowOnHome, @productSummary, @quantityLimit, @sortOrder, @isSuggestion, @coverImage, @isYouXuan, @shipRateType, @shipRateID, @isAllowPointBuy, @isAllowProductBuy, @isAllowVIPBuy, @youXuanSortOrder, @pinTuanSortOrder, @isAllowStaffBuy, @basicPrice, helper);
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
		/// Insert a Mall_Product into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productName">productName</param>
		/// <param name="businessID">businessID</param>
		/// <param name="productTypeID">productTypeID</param>
		/// <param name="salePrice">salePrice</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="status">status</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="isZiYing">isZiYing</param>
		/// <param name="pinSalePrice">pinSalePrice</param>
		/// <param name="pinPeopleCount">pinPeopleCount</param>
		/// <param name="activeTimeRange">activeTimeRange</param>
		/// <param name="pinStartTime">pinStartTime</param>
		/// <param name="pinEndTime">pinEndTime</param>
		/// <param name="xianShiSalePrice">xianShiSalePrice</param>
		/// <param name="xianShiStartTime">xianShiStartTime</param>
		/// <param name="xianShiEndTime">xianShiEndTime</param>
		/// <param name="unit">unit</param>
		/// <param name="isShowOnHome">isShowOnHome</param>
		/// <param name="productSummary">productSummary</param>
		/// <param name="quantityLimit">quantityLimit</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isSuggestion">isSuggestion</param>
		/// <param name="coverImage">coverImage</param>
		/// <param name="isYouXuan">isYouXuan</param>
		/// <param name="shipRateType">shipRateType</param>
		/// <param name="shipRateID">shipRateID</param>
		/// <param name="isAllowPointBuy">isAllowPointBuy</param>
		/// <param name="isAllowProductBuy">isAllowProductBuy</param>
		/// <param name="isAllowVIPBuy">isAllowVIPBuy</param>
		/// <param name="youXuanSortOrder">youXuanSortOrder</param>
		/// <param name="pinTuanSortOrder">pinTuanSortOrder</param>
		/// <param name="isAllowStaffBuy">isAllowStaffBuy</param>
		/// <param name="basicPrice">basicPrice</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_Product(string @productName, int @businessID, int @productTypeID, decimal @salePrice, string @modelNumber, int @totalCount, string @description, DateTime @addTime, string @addMan, int @status, string @approveRemark, DateTime @approveTime, string @approveMan, bool @isZiYing, decimal @pinSalePrice, int @pinPeopleCount, decimal @activeTimeRange, DateTime @pinStartTime, DateTime @pinEndTime, decimal @xianShiSalePrice, DateTime @xianShiStartTime, DateTime @xianShiEndTime, string @unit, bool @isShowOnHome, string @productSummary, int @quantityLimit, int @sortOrder, bool @isSuggestion, string @coverImage, bool @isYouXuan, int @shipRateType, int @shipRateID, bool @isAllowPointBuy, bool @isAllowProductBuy, bool @isAllowVIPBuy, int @youXuanSortOrder, int @pinTuanSortOrder, bool @isAllowStaffBuy, decimal @basicPrice, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProductName] nvarchar(200),
	[BusinessID] int,
	[ProductTypeID] int,
	[SalePrice] decimal(18, 2),
	[ModelNumber] nvarchar(200),
	[TotalCount] int,
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(200),
	[Status] int,
	[ApproveRemark] ntext,
	[ApproveTime] datetime,
	[ApproveMan] nvarchar(100),
	[IsZiYing] bit,
	[PinSalePrice] decimal(18, 2),
	[PinPeopleCount] int,
	[ActiveTimeRange] decimal(18, 2),
	[PinStartTime] datetime,
	[PinEndTime] datetime,
	[XianShiSalePrice] decimal(18, 2),
	[XianShiStartTime] datetime,
	[XianShiEndTime] datetime,
	[Unit] nvarchar(100),
	[IsShowOnHome] bit,
	[ProductSummary] nvarchar(500),
	[QuantityLimit] int,
	[SortOrder] int,
	[IsSuggestion] bit,
	[CoverImage] nvarchar(500),
	[IsYouXuan] bit,
	[ShipRateType] int,
	[ShipRateID] int,
	[IsAllowPointBuy] bit,
	[IsAllowProductBuy] bit,
	[IsAllowVIPBuy] bit,
	[YouXuanSortOrder] int,
	[PinTuanSortOrder] int,
	[IsAllowStaffBuy] bit,
	[BasicPrice] decimal(18, 2)
);

INSERT INTO [dbo].[Mall_Product] (
	[Mall_Product].[ProductName],
	[Mall_Product].[BusinessID],
	[Mall_Product].[ProductTypeID],
	[Mall_Product].[SalePrice],
	[Mall_Product].[ModelNumber],
	[Mall_Product].[TotalCount],
	[Mall_Product].[Description],
	[Mall_Product].[AddTime],
	[Mall_Product].[AddMan],
	[Mall_Product].[Status],
	[Mall_Product].[ApproveRemark],
	[Mall_Product].[ApproveTime],
	[Mall_Product].[ApproveMan],
	[Mall_Product].[IsZiYing],
	[Mall_Product].[PinSalePrice],
	[Mall_Product].[PinPeopleCount],
	[Mall_Product].[ActiveTimeRange],
	[Mall_Product].[PinStartTime],
	[Mall_Product].[PinEndTime],
	[Mall_Product].[XianShiSalePrice],
	[Mall_Product].[XianShiStartTime],
	[Mall_Product].[XianShiEndTime],
	[Mall_Product].[Unit],
	[Mall_Product].[IsShowOnHome],
	[Mall_Product].[ProductSummary],
	[Mall_Product].[QuantityLimit],
	[Mall_Product].[SortOrder],
	[Mall_Product].[IsSuggestion],
	[Mall_Product].[CoverImage],
	[Mall_Product].[IsYouXuan],
	[Mall_Product].[ShipRateType],
	[Mall_Product].[ShipRateID],
	[Mall_Product].[IsAllowPointBuy],
	[Mall_Product].[IsAllowProductBuy],
	[Mall_Product].[IsAllowVIPBuy],
	[Mall_Product].[YouXuanSortOrder],
	[Mall_Product].[PinTuanSortOrder],
	[Mall_Product].[IsAllowStaffBuy],
	[Mall_Product].[BasicPrice]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProductName],
	INSERTED.[BusinessID],
	INSERTED.[ProductTypeID],
	INSERTED.[SalePrice],
	INSERTED.[ModelNumber],
	INSERTED.[TotalCount],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[Status],
	INSERTED.[ApproveRemark],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveMan],
	INSERTED.[IsZiYing],
	INSERTED.[PinSalePrice],
	INSERTED.[PinPeopleCount],
	INSERTED.[ActiveTimeRange],
	INSERTED.[PinStartTime],
	INSERTED.[PinEndTime],
	INSERTED.[XianShiSalePrice],
	INSERTED.[XianShiStartTime],
	INSERTED.[XianShiEndTime],
	INSERTED.[Unit],
	INSERTED.[IsShowOnHome],
	INSERTED.[ProductSummary],
	INSERTED.[QuantityLimit],
	INSERTED.[SortOrder],
	INSERTED.[IsSuggestion],
	INSERTED.[CoverImage],
	INSERTED.[IsYouXuan],
	INSERTED.[ShipRateType],
	INSERTED.[ShipRateID],
	INSERTED.[IsAllowPointBuy],
	INSERTED.[IsAllowProductBuy],
	INSERTED.[IsAllowVIPBuy],
	INSERTED.[YouXuanSortOrder],
	INSERTED.[PinTuanSortOrder],
	INSERTED.[IsAllowStaffBuy],
	INSERTED.[BasicPrice]
into @table
VALUES ( 
	@ProductName,
	@BusinessID,
	@ProductTypeID,
	@SalePrice,
	@ModelNumber,
	@TotalCount,
	@Description,
	@AddTime,
	@AddMan,
	@Status,
	@ApproveRemark,
	@ApproveTime,
	@ApproveMan,
	@IsZiYing,
	@PinSalePrice,
	@PinPeopleCount,
	@ActiveTimeRange,
	@PinStartTime,
	@PinEndTime,
	@XianShiSalePrice,
	@XianShiStartTime,
	@XianShiEndTime,
	@Unit,
	@IsShowOnHome,
	@ProductSummary,
	@QuantityLimit,
	@SortOrder,
	@IsSuggestion,
	@CoverImage,
	@IsYouXuan,
	@ShipRateType,
	@ShipRateID,
	@IsAllowPointBuy,
	@IsAllowProductBuy,
	@IsAllowVIPBuy,
	@YouXuanSortOrder,
	@PinTuanSortOrder,
	@IsAllowStaffBuy,
	@BasicPrice 
); 

SELECT 
	[ID],
	[ProductName],
	[BusinessID],
	[ProductTypeID],
	[SalePrice],
	[ModelNumber],
	[TotalCount],
	[Description],
	[AddTime],
	[AddMan],
	[Status],
	[ApproveRemark],
	[ApproveTime],
	[ApproveMan],
	[IsZiYing],
	[PinSalePrice],
	[PinPeopleCount],
	[ActiveTimeRange],
	[PinStartTime],
	[PinEndTime],
	[XianShiSalePrice],
	[XianShiStartTime],
	[XianShiEndTime],
	[Unit],
	[IsShowOnHome],
	[ProductSummary],
	[QuantityLimit],
	[SortOrder],
	[IsSuggestion],
	[CoverImage],
	[IsYouXuan],
	[ShipRateType],
	[ShipRateID],
	[IsAllowPointBuy],
	[IsAllowProductBuy],
	[IsAllowVIPBuy],
	[YouXuanSortOrder],
	[PinTuanSortOrder],
	[IsAllowStaffBuy],
	[BasicPrice] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProductName", EntityBase.GetDatabaseValue(@productName)));
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			parameters.Add(new SqlParameter("@ProductTypeID", EntityBase.GetDatabaseValue(@productTypeID)));
			parameters.Add(new SqlParameter("@SalePrice", EntityBase.GetDatabaseValue(@salePrice)));
			parameters.Add(new SqlParameter("@ModelNumber", EntityBase.GetDatabaseValue(@modelNumber)));
			parameters.Add(new SqlParameter("@TotalCount", EntityBase.GetDatabaseValue(@totalCount)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveMan", EntityBase.GetDatabaseValue(@approveMan)));
			parameters.Add(new SqlParameter("@IsZiYing", @isZiYing));
			parameters.Add(new SqlParameter("@PinSalePrice", EntityBase.GetDatabaseValue(@pinSalePrice)));
			parameters.Add(new SqlParameter("@PinPeopleCount", EntityBase.GetDatabaseValue(@pinPeopleCount)));
			parameters.Add(new SqlParameter("@ActiveTimeRange", EntityBase.GetDatabaseValue(@activeTimeRange)));
			parameters.Add(new SqlParameter("@PinStartTime", EntityBase.GetDatabaseValue(@pinStartTime)));
			parameters.Add(new SqlParameter("@PinEndTime", EntityBase.GetDatabaseValue(@pinEndTime)));
			parameters.Add(new SqlParameter("@XianShiSalePrice", EntityBase.GetDatabaseValue(@xianShiSalePrice)));
			parameters.Add(new SqlParameter("@XianShiStartTime", EntityBase.GetDatabaseValue(@xianShiStartTime)));
			parameters.Add(new SqlParameter("@XianShiEndTime", EntityBase.GetDatabaseValue(@xianShiEndTime)));
			parameters.Add(new SqlParameter("@Unit", EntityBase.GetDatabaseValue(@unit)));
			parameters.Add(new SqlParameter("@IsShowOnHome", @isShowOnHome));
			parameters.Add(new SqlParameter("@ProductSummary", EntityBase.GetDatabaseValue(@productSummary)));
			parameters.Add(new SqlParameter("@QuantityLimit", EntityBase.GetDatabaseValue(@quantityLimit)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsSuggestion", @isSuggestion));
			parameters.Add(new SqlParameter("@CoverImage", EntityBase.GetDatabaseValue(@coverImage)));
			parameters.Add(new SqlParameter("@IsYouXuan", @isYouXuan));
			parameters.Add(new SqlParameter("@ShipRateType", EntityBase.GetDatabaseValue(@shipRateType)));
			parameters.Add(new SqlParameter("@ShipRateID", EntityBase.GetDatabaseValue(@shipRateID)));
			parameters.Add(new SqlParameter("@IsAllowPointBuy", @isAllowPointBuy));
			parameters.Add(new SqlParameter("@IsAllowProductBuy", @isAllowProductBuy));
			parameters.Add(new SqlParameter("@IsAllowVIPBuy", @isAllowVIPBuy));
			parameters.Add(new SqlParameter("@YouXuanSortOrder", EntityBase.GetDatabaseValue(@youXuanSortOrder)));
			parameters.Add(new SqlParameter("@PinTuanSortOrder", EntityBase.GetDatabaseValue(@pinTuanSortOrder)));
			parameters.Add(new SqlParameter("@IsAllowStaffBuy", @isAllowStaffBuy));
			parameters.Add(new SqlParameter("@BasicPrice", EntityBase.GetDatabaseValue(@basicPrice)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_Product into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="productName">productName</param>
		/// <param name="businessID">businessID</param>
		/// <param name="productTypeID">productTypeID</param>
		/// <param name="salePrice">salePrice</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="status">status</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="isZiYing">isZiYing</param>
		/// <param name="pinSalePrice">pinSalePrice</param>
		/// <param name="pinPeopleCount">pinPeopleCount</param>
		/// <param name="activeTimeRange">activeTimeRange</param>
		/// <param name="pinStartTime">pinStartTime</param>
		/// <param name="pinEndTime">pinEndTime</param>
		/// <param name="xianShiSalePrice">xianShiSalePrice</param>
		/// <param name="xianShiStartTime">xianShiStartTime</param>
		/// <param name="xianShiEndTime">xianShiEndTime</param>
		/// <param name="unit">unit</param>
		/// <param name="isShowOnHome">isShowOnHome</param>
		/// <param name="productSummary">productSummary</param>
		/// <param name="quantityLimit">quantityLimit</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isSuggestion">isSuggestion</param>
		/// <param name="coverImage">coverImage</param>
		/// <param name="isYouXuan">isYouXuan</param>
		/// <param name="shipRateType">shipRateType</param>
		/// <param name="shipRateID">shipRateID</param>
		/// <param name="isAllowPointBuy">isAllowPointBuy</param>
		/// <param name="isAllowProductBuy">isAllowProductBuy</param>
		/// <param name="isAllowVIPBuy">isAllowVIPBuy</param>
		/// <param name="youXuanSortOrder">youXuanSortOrder</param>
		/// <param name="pinTuanSortOrder">pinTuanSortOrder</param>
		/// <param name="isAllowStaffBuy">isAllowStaffBuy</param>
		/// <param name="basicPrice">basicPrice</param>
		public static void UpdateMall_Product(int @iD, string @productName, int @businessID, int @productTypeID, decimal @salePrice, string @modelNumber, int @totalCount, string @description, DateTime @addTime, string @addMan, int @status, string @approveRemark, DateTime @approveTime, string @approveMan, bool @isZiYing, decimal @pinSalePrice, int @pinPeopleCount, decimal @activeTimeRange, DateTime @pinStartTime, DateTime @pinEndTime, decimal @xianShiSalePrice, DateTime @xianShiStartTime, DateTime @xianShiEndTime, string @unit, bool @isShowOnHome, string @productSummary, int @quantityLimit, int @sortOrder, bool @isSuggestion, string @coverImage, bool @isYouXuan, int @shipRateType, int @shipRateID, bool @isAllowPointBuy, bool @isAllowProductBuy, bool @isAllowVIPBuy, int @youXuanSortOrder, int @pinTuanSortOrder, bool @isAllowStaffBuy, decimal @basicPrice)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_Product(@iD, @productName, @businessID, @productTypeID, @salePrice, @modelNumber, @totalCount, @description, @addTime, @addMan, @status, @approveRemark, @approveTime, @approveMan, @isZiYing, @pinSalePrice, @pinPeopleCount, @activeTimeRange, @pinStartTime, @pinEndTime, @xianShiSalePrice, @xianShiStartTime, @xianShiEndTime, @unit, @isShowOnHome, @productSummary, @quantityLimit, @sortOrder, @isSuggestion, @coverImage, @isYouXuan, @shipRateType, @shipRateID, @isAllowPointBuy, @isAllowProductBuy, @isAllowVIPBuy, @youXuanSortOrder, @pinTuanSortOrder, @isAllowStaffBuy, @basicPrice, helper);
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
		/// Updates a Mall_Product into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="productName">productName</param>
		/// <param name="businessID">businessID</param>
		/// <param name="productTypeID">productTypeID</param>
		/// <param name="salePrice">salePrice</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="status">status</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="isZiYing">isZiYing</param>
		/// <param name="pinSalePrice">pinSalePrice</param>
		/// <param name="pinPeopleCount">pinPeopleCount</param>
		/// <param name="activeTimeRange">activeTimeRange</param>
		/// <param name="pinStartTime">pinStartTime</param>
		/// <param name="pinEndTime">pinEndTime</param>
		/// <param name="xianShiSalePrice">xianShiSalePrice</param>
		/// <param name="xianShiStartTime">xianShiStartTime</param>
		/// <param name="xianShiEndTime">xianShiEndTime</param>
		/// <param name="unit">unit</param>
		/// <param name="isShowOnHome">isShowOnHome</param>
		/// <param name="productSummary">productSummary</param>
		/// <param name="quantityLimit">quantityLimit</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isSuggestion">isSuggestion</param>
		/// <param name="coverImage">coverImage</param>
		/// <param name="isYouXuan">isYouXuan</param>
		/// <param name="shipRateType">shipRateType</param>
		/// <param name="shipRateID">shipRateID</param>
		/// <param name="isAllowPointBuy">isAllowPointBuy</param>
		/// <param name="isAllowProductBuy">isAllowProductBuy</param>
		/// <param name="isAllowVIPBuy">isAllowVIPBuy</param>
		/// <param name="youXuanSortOrder">youXuanSortOrder</param>
		/// <param name="pinTuanSortOrder">pinTuanSortOrder</param>
		/// <param name="isAllowStaffBuy">isAllowStaffBuy</param>
		/// <param name="basicPrice">basicPrice</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_Product(int @iD, string @productName, int @businessID, int @productTypeID, decimal @salePrice, string @modelNumber, int @totalCount, string @description, DateTime @addTime, string @addMan, int @status, string @approveRemark, DateTime @approveTime, string @approveMan, bool @isZiYing, decimal @pinSalePrice, int @pinPeopleCount, decimal @activeTimeRange, DateTime @pinStartTime, DateTime @pinEndTime, decimal @xianShiSalePrice, DateTime @xianShiStartTime, DateTime @xianShiEndTime, string @unit, bool @isShowOnHome, string @productSummary, int @quantityLimit, int @sortOrder, bool @isSuggestion, string @coverImage, bool @isYouXuan, int @shipRateType, int @shipRateID, bool @isAllowPointBuy, bool @isAllowProductBuy, bool @isAllowVIPBuy, int @youXuanSortOrder, int @pinTuanSortOrder, bool @isAllowStaffBuy, decimal @basicPrice, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProductName] nvarchar(200),
	[BusinessID] int,
	[ProductTypeID] int,
	[SalePrice] decimal(18, 2),
	[ModelNumber] nvarchar(200),
	[TotalCount] int,
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(200),
	[Status] int,
	[ApproveRemark] ntext,
	[ApproveTime] datetime,
	[ApproveMan] nvarchar(100),
	[IsZiYing] bit,
	[PinSalePrice] decimal(18, 2),
	[PinPeopleCount] int,
	[ActiveTimeRange] decimal(18, 2),
	[PinStartTime] datetime,
	[PinEndTime] datetime,
	[XianShiSalePrice] decimal(18, 2),
	[XianShiStartTime] datetime,
	[XianShiEndTime] datetime,
	[Unit] nvarchar(100),
	[IsShowOnHome] bit,
	[ProductSummary] nvarchar(500),
	[QuantityLimit] int,
	[SortOrder] int,
	[IsSuggestion] bit,
	[CoverImage] nvarchar(500),
	[IsYouXuan] bit,
	[ShipRateType] int,
	[ShipRateID] int,
	[IsAllowPointBuy] bit,
	[IsAllowProductBuy] bit,
	[IsAllowVIPBuy] bit,
	[YouXuanSortOrder] int,
	[PinTuanSortOrder] int,
	[IsAllowStaffBuy] bit,
	[BasicPrice] decimal(18, 2)
);

UPDATE [dbo].[Mall_Product] SET 
	[Mall_Product].[ProductName] = @ProductName,
	[Mall_Product].[BusinessID] = @BusinessID,
	[Mall_Product].[ProductTypeID] = @ProductTypeID,
	[Mall_Product].[SalePrice] = @SalePrice,
	[Mall_Product].[ModelNumber] = @ModelNumber,
	[Mall_Product].[TotalCount] = @TotalCount,
	[Mall_Product].[Description] = @Description,
	[Mall_Product].[AddTime] = @AddTime,
	[Mall_Product].[AddMan] = @AddMan,
	[Mall_Product].[Status] = @Status,
	[Mall_Product].[ApproveRemark] = @ApproveRemark,
	[Mall_Product].[ApproveTime] = @ApproveTime,
	[Mall_Product].[ApproveMan] = @ApproveMan,
	[Mall_Product].[IsZiYing] = @IsZiYing,
	[Mall_Product].[PinSalePrice] = @PinSalePrice,
	[Mall_Product].[PinPeopleCount] = @PinPeopleCount,
	[Mall_Product].[ActiveTimeRange] = @ActiveTimeRange,
	[Mall_Product].[PinStartTime] = @PinStartTime,
	[Mall_Product].[PinEndTime] = @PinEndTime,
	[Mall_Product].[XianShiSalePrice] = @XianShiSalePrice,
	[Mall_Product].[XianShiStartTime] = @XianShiStartTime,
	[Mall_Product].[XianShiEndTime] = @XianShiEndTime,
	[Mall_Product].[Unit] = @Unit,
	[Mall_Product].[IsShowOnHome] = @IsShowOnHome,
	[Mall_Product].[ProductSummary] = @ProductSummary,
	[Mall_Product].[QuantityLimit] = @QuantityLimit,
	[Mall_Product].[SortOrder] = @SortOrder,
	[Mall_Product].[IsSuggestion] = @IsSuggestion,
	[Mall_Product].[CoverImage] = @CoverImage,
	[Mall_Product].[IsYouXuan] = @IsYouXuan,
	[Mall_Product].[ShipRateType] = @ShipRateType,
	[Mall_Product].[ShipRateID] = @ShipRateID,
	[Mall_Product].[IsAllowPointBuy] = @IsAllowPointBuy,
	[Mall_Product].[IsAllowProductBuy] = @IsAllowProductBuy,
	[Mall_Product].[IsAllowVIPBuy] = @IsAllowVIPBuy,
	[Mall_Product].[YouXuanSortOrder] = @YouXuanSortOrder,
	[Mall_Product].[PinTuanSortOrder] = @PinTuanSortOrder,
	[Mall_Product].[IsAllowStaffBuy] = @IsAllowStaffBuy,
	[Mall_Product].[BasicPrice] = @BasicPrice 
output 
	INSERTED.[ID],
	INSERTED.[ProductName],
	INSERTED.[BusinessID],
	INSERTED.[ProductTypeID],
	INSERTED.[SalePrice],
	INSERTED.[ModelNumber],
	INSERTED.[TotalCount],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[Status],
	INSERTED.[ApproveRemark],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveMan],
	INSERTED.[IsZiYing],
	INSERTED.[PinSalePrice],
	INSERTED.[PinPeopleCount],
	INSERTED.[ActiveTimeRange],
	INSERTED.[PinStartTime],
	INSERTED.[PinEndTime],
	INSERTED.[XianShiSalePrice],
	INSERTED.[XianShiStartTime],
	INSERTED.[XianShiEndTime],
	INSERTED.[Unit],
	INSERTED.[IsShowOnHome],
	INSERTED.[ProductSummary],
	INSERTED.[QuantityLimit],
	INSERTED.[SortOrder],
	INSERTED.[IsSuggestion],
	INSERTED.[CoverImage],
	INSERTED.[IsYouXuan],
	INSERTED.[ShipRateType],
	INSERTED.[ShipRateID],
	INSERTED.[IsAllowPointBuy],
	INSERTED.[IsAllowProductBuy],
	INSERTED.[IsAllowVIPBuy],
	INSERTED.[YouXuanSortOrder],
	INSERTED.[PinTuanSortOrder],
	INSERTED.[IsAllowStaffBuy],
	INSERTED.[BasicPrice]
into @table
WHERE 
	[Mall_Product].[ID] = @ID

SELECT 
	[ID],
	[ProductName],
	[BusinessID],
	[ProductTypeID],
	[SalePrice],
	[ModelNumber],
	[TotalCount],
	[Description],
	[AddTime],
	[AddMan],
	[Status],
	[ApproveRemark],
	[ApproveTime],
	[ApproveMan],
	[IsZiYing],
	[PinSalePrice],
	[PinPeopleCount],
	[ActiveTimeRange],
	[PinStartTime],
	[PinEndTime],
	[XianShiSalePrice],
	[XianShiStartTime],
	[XianShiEndTime],
	[Unit],
	[IsShowOnHome],
	[ProductSummary],
	[QuantityLimit],
	[SortOrder],
	[IsSuggestion],
	[CoverImage],
	[IsYouXuan],
	[ShipRateType],
	[ShipRateID],
	[IsAllowPointBuy],
	[IsAllowProductBuy],
	[IsAllowVIPBuy],
	[YouXuanSortOrder],
	[PinTuanSortOrder],
	[IsAllowStaffBuy],
	[BasicPrice] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProductName", EntityBase.GetDatabaseValue(@productName)));
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			parameters.Add(new SqlParameter("@ProductTypeID", EntityBase.GetDatabaseValue(@productTypeID)));
			parameters.Add(new SqlParameter("@SalePrice", EntityBase.GetDatabaseValue(@salePrice)));
			parameters.Add(new SqlParameter("@ModelNumber", EntityBase.GetDatabaseValue(@modelNumber)));
			parameters.Add(new SqlParameter("@TotalCount", EntityBase.GetDatabaseValue(@totalCount)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveMan", EntityBase.GetDatabaseValue(@approveMan)));
			parameters.Add(new SqlParameter("@IsZiYing", @isZiYing));
			parameters.Add(new SqlParameter("@PinSalePrice", EntityBase.GetDatabaseValue(@pinSalePrice)));
			parameters.Add(new SqlParameter("@PinPeopleCount", EntityBase.GetDatabaseValue(@pinPeopleCount)));
			parameters.Add(new SqlParameter("@ActiveTimeRange", EntityBase.GetDatabaseValue(@activeTimeRange)));
			parameters.Add(new SqlParameter("@PinStartTime", EntityBase.GetDatabaseValue(@pinStartTime)));
			parameters.Add(new SqlParameter("@PinEndTime", EntityBase.GetDatabaseValue(@pinEndTime)));
			parameters.Add(new SqlParameter("@XianShiSalePrice", EntityBase.GetDatabaseValue(@xianShiSalePrice)));
			parameters.Add(new SqlParameter("@XianShiStartTime", EntityBase.GetDatabaseValue(@xianShiStartTime)));
			parameters.Add(new SqlParameter("@XianShiEndTime", EntityBase.GetDatabaseValue(@xianShiEndTime)));
			parameters.Add(new SqlParameter("@Unit", EntityBase.GetDatabaseValue(@unit)));
			parameters.Add(new SqlParameter("@IsShowOnHome", @isShowOnHome));
			parameters.Add(new SqlParameter("@ProductSummary", EntityBase.GetDatabaseValue(@productSummary)));
			parameters.Add(new SqlParameter("@QuantityLimit", EntityBase.GetDatabaseValue(@quantityLimit)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsSuggestion", @isSuggestion));
			parameters.Add(new SqlParameter("@CoverImage", EntityBase.GetDatabaseValue(@coverImage)));
			parameters.Add(new SqlParameter("@IsYouXuan", @isYouXuan));
			parameters.Add(new SqlParameter("@ShipRateType", EntityBase.GetDatabaseValue(@shipRateType)));
			parameters.Add(new SqlParameter("@ShipRateID", EntityBase.GetDatabaseValue(@shipRateID)));
			parameters.Add(new SqlParameter("@IsAllowPointBuy", @isAllowPointBuy));
			parameters.Add(new SqlParameter("@IsAllowProductBuy", @isAllowProductBuy));
			parameters.Add(new SqlParameter("@IsAllowVIPBuy", @isAllowVIPBuy));
			parameters.Add(new SqlParameter("@YouXuanSortOrder", EntityBase.GetDatabaseValue(@youXuanSortOrder)));
			parameters.Add(new SqlParameter("@PinTuanSortOrder", EntityBase.GetDatabaseValue(@pinTuanSortOrder)));
			parameters.Add(new SqlParameter("@IsAllowStaffBuy", @isAllowStaffBuy));
			parameters.Add(new SqlParameter("@BasicPrice", EntityBase.GetDatabaseValue(@basicPrice)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_Product from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_Product(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_Product(@iD, helper);
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
		/// Deletes a Mall_Product from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_Product(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_Product]
WHERE 
	[Mall_Product].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_Product object.
		/// </summary>
		/// <returns>The newly created Mall_Product object.</returns>
		public static Mall_Product CreateMall_Product()
		{
			return InitializeNew<Mall_Product>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_Product by a Mall_Product's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_Product</returns>
		public static Mall_Product GetMall_Product(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_Product.SelectFieldList + @"
FROM [dbo].[Mall_Product] 
WHERE 
	[Mall_Product].[ID] = @ID " + Mall_Product.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Product>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_Product by a Mall_Product's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_Product</returns>
		public static Mall_Product GetMall_Product(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_Product.SelectFieldList + @"
FROM [dbo].[Mall_Product] 
WHERE 
	[Mall_Product].[ID] = @ID " + Mall_Product.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Product>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_Product objects.</returns>
		public static EntityList<Mall_Product> GetMall_Products()
		{
			string commandText = @"
SELECT " + Mall_Product.SelectFieldList + "FROM [dbo].[Mall_Product] " + Mall_Product.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_Product>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_Product objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Product objects.</returns>
        public static EntityList<Mall_Product> GetMall_Products(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Product>(SelectFieldList, "FROM [dbo].[Mall_Product]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_Product objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Product objects.</returns>
        public static EntityList<Mall_Product> GetMall_Products(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Product>(SelectFieldList, "FROM [dbo].[Mall_Product]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_Product objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Product objects.</returns>
		protected static EntityList<Mall_Product> GetMall_Products(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Products(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Product objects.</returns>
		protected static EntityList<Mall_Product> GetMall_Products(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Products(string.Empty, where, parameters, Mall_Product.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Product objects.</returns>
		protected static EntityList<Mall_Product> GetMall_Products(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Products(prefix, where, parameters, Mall_Product.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Product objects.</returns>
		protected static EntityList<Mall_Product> GetMall_Products(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Products(string.Empty, where, parameters, Mall_Product.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Product objects.</returns>
		protected static EntityList<Mall_Product> GetMall_Products(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Products(prefix, where, parameters, Mall_Product.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Product objects.</returns>
		protected static EntityList<Mall_Product> GetMall_Products(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_Product.SelectFieldList + "FROM [dbo].[Mall_Product] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_Product>(reader);
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
        protected static EntityList<Mall_Product> GetMall_Products(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Product>(SelectFieldList, "FROM [dbo].[Mall_Product] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_Product objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ProductCount()
        {
            return GetMall_ProductCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_Product objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ProductCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_Product] " + where;

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
		public static partial class Mall_Product_Properties
		{
			public const string ID = "ID";
			public const string ProductName = "ProductName";
			public const string BusinessID = "BusinessID";
			public const string ProductTypeID = "ProductTypeID";
			public const string SalePrice = "SalePrice";
			public const string ModelNumber = "ModelNumber";
			public const string TotalCount = "TotalCount";
			public const string Description = "Description";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string Status = "Status";
			public const string ApproveRemark = "ApproveRemark";
			public const string ApproveTime = "ApproveTime";
			public const string ApproveMan = "ApproveMan";
			public const string IsZiYing = "IsZiYing";
			public const string PinSalePrice = "PinSalePrice";
			public const string PinPeopleCount = "PinPeopleCount";
			public const string ActiveTimeRange = "ActiveTimeRange";
			public const string PinStartTime = "PinStartTime";
			public const string PinEndTime = "PinEndTime";
			public const string XianShiSalePrice = "XianShiSalePrice";
			public const string XianShiStartTime = "XianShiStartTime";
			public const string XianShiEndTime = "XianShiEndTime";
			public const string Unit = "Unit";
			public const string IsShowOnHome = "IsShowOnHome";
			public const string ProductSummary = "ProductSummary";
			public const string QuantityLimit = "QuantityLimit";
			public const string SortOrder = "SortOrder";
			public const string IsSuggestion = "IsSuggestion";
			public const string CoverImage = "CoverImage";
			public const string IsYouXuan = "IsYouXuan";
			public const string ShipRateType = "ShipRateType";
			public const string ShipRateID = "ShipRateID";
			public const string IsAllowPointBuy = "IsAllowPointBuy";
			public const string IsAllowProductBuy = "IsAllowProductBuy";
			public const string IsAllowVIPBuy = "IsAllowVIPBuy";
			public const string YouXuanSortOrder = "YouXuanSortOrder";
			public const string PinTuanSortOrder = "PinTuanSortOrder";
			public const string IsAllowStaffBuy = "IsAllowStaffBuy";
			public const string BasicPrice = "BasicPrice";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProductName" , "string:"},
    			 {"BusinessID" , "int:"},
    			 {"ProductTypeID" , "int:1-购买商品 2-积分兑换 3-拼团 4-秒杀"},
    			 {"SalePrice" , "decimal:"},
    			 {"ModelNumber" , "string:"},
    			 {"TotalCount" , "int:"},
    			 {"Description" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"Status" , "int:10-出售中 2-已下架 3-待审核 4-审核未通过"},
    			 {"ApproveRemark" , "string:"},
    			 {"ApproveTime" , "DateTime:"},
    			 {"ApproveMan" , "string:"},
    			 {"IsZiYing" , "bool:"},
    			 {"PinSalePrice" , "decimal:"},
    			 {"PinPeopleCount" , "int:"},
    			 {"ActiveTimeRange" , "decimal:"},
    			 {"PinStartTime" , "DateTime:"},
    			 {"PinEndTime" , "DateTime:"},
    			 {"XianShiSalePrice" , "decimal:"},
    			 {"XianShiStartTime" , "DateTime:"},
    			 {"XianShiEndTime" , "DateTime:"},
    			 {"Unit" , "string:"},
    			 {"IsShowOnHome" , "bool:"},
    			 {"ProductSummary" , "string:"},
    			 {"QuantityLimit" , "int:"},
    			 {"SortOrder" , "int:"},
    			 {"IsSuggestion" , "bool:"},
    			 {"CoverImage" , "string:"},
    			 {"IsYouXuan" , "bool:"},
    			 {"ShipRateType" , "int:"},
    			 {"ShipRateID" , "int:"},
    			 {"IsAllowPointBuy" , "bool:"},
    			 {"IsAllowProductBuy" , "bool:"},
    			 {"IsAllowVIPBuy" , "bool:"},
    			 {"YouXuanSortOrder" , "int:"},
    			 {"PinTuanSortOrder" , "int:"},
    			 {"IsAllowStaffBuy" , "bool:"},
    			 {"BasicPrice" , "decimal:"},
            };
		}
		#endregion
	}
}
