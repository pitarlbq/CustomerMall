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
	/// This object represents the properties and methods of a Mall_OrderItem.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_OrderItem 
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
			set 
			{
				if (this._productID != value) 
				{
					this._productID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductID");
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
		[DataObjectField(false, false, true)]
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
			set 
			{
				if (this._quantity != value) 
				{
					this._quantity = value;
					this.IsDirty = true;	
					OnPropertyChanged("Quantity");
				}
			}
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
			set 
			{
				if (this._price != value) 
				{
					this._price = value;
					this.IsDirty = true;	
					OnPropertyChanged("Price");
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
			set 
			{
				if (this._historyID != value) 
				{
					this._historyID = value;
					this.IsDirty = true;	
					OnPropertyChanged("HistoryID");
				}
			}
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
			set 
			{
				if (this._roomName != value) 
				{
					this._roomName = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomName");
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
		[DataObjectField(false, false, true)]
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
			set 
			{
				if (this._chargeName != value) 
				{
					this._chargeName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeName");
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
			set 
			{
				if (this._variantID != value) 
				{
					this._variantID = value;
					this.IsDirty = true;	
					OnPropertyChanged("VariantID");
				}
			}
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
			set 
			{
				if (this._totalPrice != value) 
				{
					this._totalPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalPrice");
				}
			}
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
			set 
			{
				if (this._variantTitle != value) 
				{
					this._variantTitle = value;
					this.IsDirty = true;	
					OnPropertyChanged("VariantTitle");
				}
			}
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
			set 
			{
				if (this._variantName != value) 
				{
					this._variantName = value;
					this.IsDirty = true;	
					OnPropertyChanged("VariantName");
				}
			}
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
			set 
			{
				if (this._businessName != value) 
				{
					this._businessName = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _productTypeID = int.MinValue;
		/// <summary>
		/// 1-购买商品 2-积分兑换 3-拼团抢购 4-限时秒杀 5-生活服务 10-物业收费
		/// </summary>
        [Description("1-购买商品 2-积分兑换 3-拼团抢购 4-限时秒杀 5-生活服务 10-物业收费")]
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
		private string _shipRateTitle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ShipRateTitle
		{
			[DebuggerStepThrough()]
			get { return this._shipRateTitle; }
			set 
			{
				if (this._shipRateTitle != value) 
				{
					this._shipRateTitle = value;
					this.IsDirty = true;	
					OnPropertyChanged("ShipRateTitle");
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
		private int _salePoint = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SalePoint
		{
			[DebuggerStepThrough()]
			get { return this._salePoint; }
			set 
			{
				if (this._salePoint != value) 
				{
					this._salePoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("SalePoint");
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
		private int _productBuyType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProductBuyType
		{
			[DebuggerStepThrough()]
			get { return this._productBuyType; }
			set 
			{
				if (this._productBuyType != value) 
				{
					this._productBuyType = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductBuyType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _vIPSalePoint = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int VIPSalePoint
		{
			[DebuggerStepThrough()]
			get { return this._vIPSalePoint; }
			set 
			{
				if (this._vIPSalePoint != value) 
				{
					this._vIPSalePoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("VIPSalePoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _vIPTotalSalePoint = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int VIPTotalSalePoint
		{
			[DebuggerStepThrough()]
			get { return this._vIPTotalSalePoint; }
			set 
			{
				if (this._vIPTotalSalePoint != value) 
				{
					this._vIPTotalSalePoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("VIPTotalSalePoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _staffPoint = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int StaffPoint
		{
			[DebuggerStepThrough()]
			get { return this._staffPoint; }
			set 
			{
				if (this._staffPoint != value) 
				{
					this._staffPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("StaffPoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _totalStaffPoint = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TotalStaffPoint
		{
			[DebuggerStepThrough()]
			get { return this._totalStaffPoint; }
			set 
			{
				if (this._totalStaffPoint != value) 
				{
					this._totalStaffPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalStaffPoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDiscountPrice = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDiscountPrice
		{
			[DebuggerStepThrough()]
			get { return this._isDiscountPrice; }
			set 
			{
				if (this._isDiscountPrice != value) 
				{
					this._isDiscountPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDiscountPrice");
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
	[OrderID] int,
	[ProductID] int,
	[ProductName] nvarchar(200),
	[Quantity] int,
	[Price] decimal(18, 2),
	[BusinessID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[RoomID] int,
	[HistoryID] int,
	[RoomName] nvarchar(500),
	[ChargeID] int,
	[ChargeName] nvarchar(200),
	[StartTime] datetime,
	[EndTime] datetime,
	[VariantID] int,
	[TotalPrice] decimal(18, 2),
	[VariantTitle] nvarchar(100),
	[VariantName] nvarchar(100),
	[BusinessName] nvarchar(200),
	[ProductTypeID] int,
	[ShipRateTitle] nvarchar(200),
	[ShipRateID] int,
	[ShipRateType] int,
	[ShipRateAmount] decimal(18, 2),
	[SalePoint] int,
	[TotalSalePoint] int,
	[ProductBuyType] int,
	[VIPSalePoint] int,
	[VIPTotalSalePoint] int,
	[StaffPoint] int,
	[TotalStaffPoint] int,
	[IsDiscountPrice] bit
);

INSERT INTO [dbo].[Mall_OrderItem] (
	[Mall_OrderItem].[OrderID],
	[Mall_OrderItem].[ProductID],
	[Mall_OrderItem].[ProductName],
	[Mall_OrderItem].[Quantity],
	[Mall_OrderItem].[Price],
	[Mall_OrderItem].[BusinessID],
	[Mall_OrderItem].[AddTime],
	[Mall_OrderItem].[AddMan],
	[Mall_OrderItem].[RoomID],
	[Mall_OrderItem].[HistoryID],
	[Mall_OrderItem].[RoomName],
	[Mall_OrderItem].[ChargeID],
	[Mall_OrderItem].[ChargeName],
	[Mall_OrderItem].[StartTime],
	[Mall_OrderItem].[EndTime],
	[Mall_OrderItem].[VariantID],
	[Mall_OrderItem].[TotalPrice],
	[Mall_OrderItem].[VariantTitle],
	[Mall_OrderItem].[VariantName],
	[Mall_OrderItem].[BusinessName],
	[Mall_OrderItem].[ProductTypeID],
	[Mall_OrderItem].[ShipRateTitle],
	[Mall_OrderItem].[ShipRateID],
	[Mall_OrderItem].[ShipRateType],
	[Mall_OrderItem].[ShipRateAmount],
	[Mall_OrderItem].[SalePoint],
	[Mall_OrderItem].[TotalSalePoint],
	[Mall_OrderItem].[ProductBuyType],
	[Mall_OrderItem].[VIPSalePoint],
	[Mall_OrderItem].[VIPTotalSalePoint],
	[Mall_OrderItem].[StaffPoint],
	[Mall_OrderItem].[TotalStaffPoint],
	[Mall_OrderItem].[IsDiscountPrice]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[ProductID],
	INSERTED.[ProductName],
	INSERTED.[Quantity],
	INSERTED.[Price],
	INSERTED.[BusinessID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[RoomID],
	INSERTED.[HistoryID],
	INSERTED.[RoomName],
	INSERTED.[ChargeID],
	INSERTED.[ChargeName],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[VariantID],
	INSERTED.[TotalPrice],
	INSERTED.[VariantTitle],
	INSERTED.[VariantName],
	INSERTED.[BusinessName],
	INSERTED.[ProductTypeID],
	INSERTED.[ShipRateTitle],
	INSERTED.[ShipRateID],
	INSERTED.[ShipRateType],
	INSERTED.[ShipRateAmount],
	INSERTED.[SalePoint],
	INSERTED.[TotalSalePoint],
	INSERTED.[ProductBuyType],
	INSERTED.[VIPSalePoint],
	INSERTED.[VIPTotalSalePoint],
	INSERTED.[StaffPoint],
	INSERTED.[TotalStaffPoint],
	INSERTED.[IsDiscountPrice]
into @table
VALUES ( 
	@OrderID,
	@ProductID,
	@ProductName,
	@Quantity,
	@Price,
	@BusinessID,
	@AddTime,
	@AddMan,
	@RoomID,
	@HistoryID,
	@RoomName,
	@ChargeID,
	@ChargeName,
	@StartTime,
	@EndTime,
	@VariantID,
	@TotalPrice,
	@VariantTitle,
	@VariantName,
	@BusinessName,
	@ProductTypeID,
	@ShipRateTitle,
	@ShipRateID,
	@ShipRateType,
	@ShipRateAmount,
	@SalePoint,
	@TotalSalePoint,
	@ProductBuyType,
	@VIPSalePoint,
	@VIPTotalSalePoint,
	@StaffPoint,
	@TotalStaffPoint,
	@IsDiscountPrice 
); 

SELECT 
	[ID],
	[OrderID],
	[ProductID],
	[ProductName],
	[Quantity],
	[Price],
	[BusinessID],
	[AddTime],
	[AddMan],
	[RoomID],
	[HistoryID],
	[RoomName],
	[ChargeID],
	[ChargeName],
	[StartTime],
	[EndTime],
	[VariantID],
	[TotalPrice],
	[VariantTitle],
	[VariantName],
	[BusinessName],
	[ProductTypeID],
	[ShipRateTitle],
	[ShipRateID],
	[ShipRateType],
	[ShipRateAmount],
	[SalePoint],
	[TotalSalePoint],
	[ProductBuyType],
	[VIPSalePoint],
	[VIPTotalSalePoint],
	[StaffPoint],
	[TotalStaffPoint],
	[IsDiscountPrice] 
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
	[OrderID] int,
	[ProductID] int,
	[ProductName] nvarchar(200),
	[Quantity] int,
	[Price] decimal(18, 2),
	[BusinessID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[RoomID] int,
	[HistoryID] int,
	[RoomName] nvarchar(500),
	[ChargeID] int,
	[ChargeName] nvarchar(200),
	[StartTime] datetime,
	[EndTime] datetime,
	[VariantID] int,
	[TotalPrice] decimal(18, 2),
	[VariantTitle] nvarchar(100),
	[VariantName] nvarchar(100),
	[BusinessName] nvarchar(200),
	[ProductTypeID] int,
	[ShipRateTitle] nvarchar(200),
	[ShipRateID] int,
	[ShipRateType] int,
	[ShipRateAmount] decimal(18, 2),
	[SalePoint] int,
	[TotalSalePoint] int,
	[ProductBuyType] int,
	[VIPSalePoint] int,
	[VIPTotalSalePoint] int,
	[StaffPoint] int,
	[TotalStaffPoint] int,
	[IsDiscountPrice] bit
);

UPDATE [dbo].[Mall_OrderItem] SET 
	[Mall_OrderItem].[OrderID] = @OrderID,
	[Mall_OrderItem].[ProductID] = @ProductID,
	[Mall_OrderItem].[ProductName] = @ProductName,
	[Mall_OrderItem].[Quantity] = @Quantity,
	[Mall_OrderItem].[Price] = @Price,
	[Mall_OrderItem].[BusinessID] = @BusinessID,
	[Mall_OrderItem].[AddTime] = @AddTime,
	[Mall_OrderItem].[AddMan] = @AddMan,
	[Mall_OrderItem].[RoomID] = @RoomID,
	[Mall_OrderItem].[HistoryID] = @HistoryID,
	[Mall_OrderItem].[RoomName] = @RoomName,
	[Mall_OrderItem].[ChargeID] = @ChargeID,
	[Mall_OrderItem].[ChargeName] = @ChargeName,
	[Mall_OrderItem].[StartTime] = @StartTime,
	[Mall_OrderItem].[EndTime] = @EndTime,
	[Mall_OrderItem].[VariantID] = @VariantID,
	[Mall_OrderItem].[TotalPrice] = @TotalPrice,
	[Mall_OrderItem].[VariantTitle] = @VariantTitle,
	[Mall_OrderItem].[VariantName] = @VariantName,
	[Mall_OrderItem].[BusinessName] = @BusinessName,
	[Mall_OrderItem].[ProductTypeID] = @ProductTypeID,
	[Mall_OrderItem].[ShipRateTitle] = @ShipRateTitle,
	[Mall_OrderItem].[ShipRateID] = @ShipRateID,
	[Mall_OrderItem].[ShipRateType] = @ShipRateType,
	[Mall_OrderItem].[ShipRateAmount] = @ShipRateAmount,
	[Mall_OrderItem].[SalePoint] = @SalePoint,
	[Mall_OrderItem].[TotalSalePoint] = @TotalSalePoint,
	[Mall_OrderItem].[ProductBuyType] = @ProductBuyType,
	[Mall_OrderItem].[VIPSalePoint] = @VIPSalePoint,
	[Mall_OrderItem].[VIPTotalSalePoint] = @VIPTotalSalePoint,
	[Mall_OrderItem].[StaffPoint] = @StaffPoint,
	[Mall_OrderItem].[TotalStaffPoint] = @TotalStaffPoint,
	[Mall_OrderItem].[IsDiscountPrice] = @IsDiscountPrice 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[ProductID],
	INSERTED.[ProductName],
	INSERTED.[Quantity],
	INSERTED.[Price],
	INSERTED.[BusinessID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[RoomID],
	INSERTED.[HistoryID],
	INSERTED.[RoomName],
	INSERTED.[ChargeID],
	INSERTED.[ChargeName],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[VariantID],
	INSERTED.[TotalPrice],
	INSERTED.[VariantTitle],
	INSERTED.[VariantName],
	INSERTED.[BusinessName],
	INSERTED.[ProductTypeID],
	INSERTED.[ShipRateTitle],
	INSERTED.[ShipRateID],
	INSERTED.[ShipRateType],
	INSERTED.[ShipRateAmount],
	INSERTED.[SalePoint],
	INSERTED.[TotalSalePoint],
	INSERTED.[ProductBuyType],
	INSERTED.[VIPSalePoint],
	INSERTED.[VIPTotalSalePoint],
	INSERTED.[StaffPoint],
	INSERTED.[TotalStaffPoint],
	INSERTED.[IsDiscountPrice]
into @table
WHERE 
	[Mall_OrderItem].[ID] = @ID

SELECT 
	[ID],
	[OrderID],
	[ProductID],
	[ProductName],
	[Quantity],
	[Price],
	[BusinessID],
	[AddTime],
	[AddMan],
	[RoomID],
	[HistoryID],
	[RoomName],
	[ChargeID],
	[ChargeName],
	[StartTime],
	[EndTime],
	[VariantID],
	[TotalPrice],
	[VariantTitle],
	[VariantName],
	[BusinessName],
	[ProductTypeID],
	[ShipRateTitle],
	[ShipRateID],
	[ShipRateType],
	[ShipRateAmount],
	[SalePoint],
	[TotalSalePoint],
	[ProductBuyType],
	[VIPSalePoint],
	[VIPTotalSalePoint],
	[StaffPoint],
	[TotalStaffPoint],
	[IsDiscountPrice] 
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
DELETE FROM [dbo].[Mall_OrderItem]
WHERE 
	[Mall_OrderItem].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_OrderItem() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_OrderItem(this.ID));
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
	[Mall_OrderItem].[ID],
	[Mall_OrderItem].[OrderID],
	[Mall_OrderItem].[ProductID],
	[Mall_OrderItem].[ProductName],
	[Mall_OrderItem].[Quantity],
	[Mall_OrderItem].[Price],
	[Mall_OrderItem].[BusinessID],
	[Mall_OrderItem].[AddTime],
	[Mall_OrderItem].[AddMan],
	[Mall_OrderItem].[RoomID],
	[Mall_OrderItem].[HistoryID],
	[Mall_OrderItem].[RoomName],
	[Mall_OrderItem].[ChargeID],
	[Mall_OrderItem].[ChargeName],
	[Mall_OrderItem].[StartTime],
	[Mall_OrderItem].[EndTime],
	[Mall_OrderItem].[VariantID],
	[Mall_OrderItem].[TotalPrice],
	[Mall_OrderItem].[VariantTitle],
	[Mall_OrderItem].[VariantName],
	[Mall_OrderItem].[BusinessName],
	[Mall_OrderItem].[ProductTypeID],
	[Mall_OrderItem].[ShipRateTitle],
	[Mall_OrderItem].[ShipRateID],
	[Mall_OrderItem].[ShipRateType],
	[Mall_OrderItem].[ShipRateAmount],
	[Mall_OrderItem].[SalePoint],
	[Mall_OrderItem].[TotalSalePoint],
	[Mall_OrderItem].[ProductBuyType],
	[Mall_OrderItem].[VIPSalePoint],
	[Mall_OrderItem].[VIPTotalSalePoint],
	[Mall_OrderItem].[StaffPoint],
	[Mall_OrderItem].[TotalStaffPoint],
	[Mall_OrderItem].[IsDiscountPrice]
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
                return "Mall_OrderItem";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_OrderItem into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderID">orderID</param>
		/// <param name="productID">productID</param>
		/// <param name="productName">productName</param>
		/// <param name="quantity">quantity</param>
		/// <param name="price">price</param>
		/// <param name="businessID">businessID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="roomID">roomID</param>
		/// <param name="historyID">historyID</param>
		/// <param name="roomName">roomName</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="chargeName">chargeName</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="variantID">variantID</param>
		/// <param name="totalPrice">totalPrice</param>
		/// <param name="variantTitle">variantTitle</param>
		/// <param name="variantName">variantName</param>
		/// <param name="businessName">businessName</param>
		/// <param name="productTypeID">productTypeID</param>
		/// <param name="shipRateTitle">shipRateTitle</param>
		/// <param name="shipRateID">shipRateID</param>
		/// <param name="shipRateType">shipRateType</param>
		/// <param name="shipRateAmount">shipRateAmount</param>
		/// <param name="salePoint">salePoint</param>
		/// <param name="totalSalePoint">totalSalePoint</param>
		/// <param name="productBuyType">productBuyType</param>
		/// <param name="vIPSalePoint">vIPSalePoint</param>
		/// <param name="vIPTotalSalePoint">vIPTotalSalePoint</param>
		/// <param name="staffPoint">staffPoint</param>
		/// <param name="totalStaffPoint">totalStaffPoint</param>
		/// <param name="isDiscountPrice">isDiscountPrice</param>
		public static void InsertMall_OrderItem(int @orderID, int @productID, string @productName, int @quantity, decimal @price, int @businessID, DateTime @addTime, string @addMan, int @roomID, int @historyID, string @roomName, int @chargeID, string @chargeName, DateTime @startTime, DateTime @endTime, int @variantID, decimal @totalPrice, string @variantTitle, string @variantName, string @businessName, int @productTypeID, string @shipRateTitle, int @shipRateID, int @shipRateType, decimal @shipRateAmount, int @salePoint, int @totalSalePoint, int @productBuyType, int @vIPSalePoint, int @vIPTotalSalePoint, int @staffPoint, int @totalStaffPoint, bool @isDiscountPrice)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_OrderItem(@orderID, @productID, @productName, @quantity, @price, @businessID, @addTime, @addMan, @roomID, @historyID, @roomName, @chargeID, @chargeName, @startTime, @endTime, @variantID, @totalPrice, @variantTitle, @variantName, @businessName, @productTypeID, @shipRateTitle, @shipRateID, @shipRateType, @shipRateAmount, @salePoint, @totalSalePoint, @productBuyType, @vIPSalePoint, @vIPTotalSalePoint, @staffPoint, @totalStaffPoint, @isDiscountPrice, helper);
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
		/// Insert a Mall_OrderItem into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderID">orderID</param>
		/// <param name="productID">productID</param>
		/// <param name="productName">productName</param>
		/// <param name="quantity">quantity</param>
		/// <param name="price">price</param>
		/// <param name="businessID">businessID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="roomID">roomID</param>
		/// <param name="historyID">historyID</param>
		/// <param name="roomName">roomName</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="chargeName">chargeName</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="variantID">variantID</param>
		/// <param name="totalPrice">totalPrice</param>
		/// <param name="variantTitle">variantTitle</param>
		/// <param name="variantName">variantName</param>
		/// <param name="businessName">businessName</param>
		/// <param name="productTypeID">productTypeID</param>
		/// <param name="shipRateTitle">shipRateTitle</param>
		/// <param name="shipRateID">shipRateID</param>
		/// <param name="shipRateType">shipRateType</param>
		/// <param name="shipRateAmount">shipRateAmount</param>
		/// <param name="salePoint">salePoint</param>
		/// <param name="totalSalePoint">totalSalePoint</param>
		/// <param name="productBuyType">productBuyType</param>
		/// <param name="vIPSalePoint">vIPSalePoint</param>
		/// <param name="vIPTotalSalePoint">vIPTotalSalePoint</param>
		/// <param name="staffPoint">staffPoint</param>
		/// <param name="totalStaffPoint">totalStaffPoint</param>
		/// <param name="isDiscountPrice">isDiscountPrice</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_OrderItem(int @orderID, int @productID, string @productName, int @quantity, decimal @price, int @businessID, DateTime @addTime, string @addMan, int @roomID, int @historyID, string @roomName, int @chargeID, string @chargeName, DateTime @startTime, DateTime @endTime, int @variantID, decimal @totalPrice, string @variantTitle, string @variantName, string @businessName, int @productTypeID, string @shipRateTitle, int @shipRateID, int @shipRateType, decimal @shipRateAmount, int @salePoint, int @totalSalePoint, int @productBuyType, int @vIPSalePoint, int @vIPTotalSalePoint, int @staffPoint, int @totalStaffPoint, bool @isDiscountPrice, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrderID] int,
	[ProductID] int,
	[ProductName] nvarchar(200),
	[Quantity] int,
	[Price] decimal(18, 2),
	[BusinessID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[RoomID] int,
	[HistoryID] int,
	[RoomName] nvarchar(500),
	[ChargeID] int,
	[ChargeName] nvarchar(200),
	[StartTime] datetime,
	[EndTime] datetime,
	[VariantID] int,
	[TotalPrice] decimal(18, 2),
	[VariantTitle] nvarchar(100),
	[VariantName] nvarchar(100),
	[BusinessName] nvarchar(200),
	[ProductTypeID] int,
	[ShipRateTitle] nvarchar(200),
	[ShipRateID] int,
	[ShipRateType] int,
	[ShipRateAmount] decimal(18, 2),
	[SalePoint] int,
	[TotalSalePoint] int,
	[ProductBuyType] int,
	[VIPSalePoint] int,
	[VIPTotalSalePoint] int,
	[StaffPoint] int,
	[TotalStaffPoint] int,
	[IsDiscountPrice] bit
);

INSERT INTO [dbo].[Mall_OrderItem] (
	[Mall_OrderItem].[OrderID],
	[Mall_OrderItem].[ProductID],
	[Mall_OrderItem].[ProductName],
	[Mall_OrderItem].[Quantity],
	[Mall_OrderItem].[Price],
	[Mall_OrderItem].[BusinessID],
	[Mall_OrderItem].[AddTime],
	[Mall_OrderItem].[AddMan],
	[Mall_OrderItem].[RoomID],
	[Mall_OrderItem].[HistoryID],
	[Mall_OrderItem].[RoomName],
	[Mall_OrderItem].[ChargeID],
	[Mall_OrderItem].[ChargeName],
	[Mall_OrderItem].[StartTime],
	[Mall_OrderItem].[EndTime],
	[Mall_OrderItem].[VariantID],
	[Mall_OrderItem].[TotalPrice],
	[Mall_OrderItem].[VariantTitle],
	[Mall_OrderItem].[VariantName],
	[Mall_OrderItem].[BusinessName],
	[Mall_OrderItem].[ProductTypeID],
	[Mall_OrderItem].[ShipRateTitle],
	[Mall_OrderItem].[ShipRateID],
	[Mall_OrderItem].[ShipRateType],
	[Mall_OrderItem].[ShipRateAmount],
	[Mall_OrderItem].[SalePoint],
	[Mall_OrderItem].[TotalSalePoint],
	[Mall_OrderItem].[ProductBuyType],
	[Mall_OrderItem].[VIPSalePoint],
	[Mall_OrderItem].[VIPTotalSalePoint],
	[Mall_OrderItem].[StaffPoint],
	[Mall_OrderItem].[TotalStaffPoint],
	[Mall_OrderItem].[IsDiscountPrice]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[ProductID],
	INSERTED.[ProductName],
	INSERTED.[Quantity],
	INSERTED.[Price],
	INSERTED.[BusinessID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[RoomID],
	INSERTED.[HistoryID],
	INSERTED.[RoomName],
	INSERTED.[ChargeID],
	INSERTED.[ChargeName],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[VariantID],
	INSERTED.[TotalPrice],
	INSERTED.[VariantTitle],
	INSERTED.[VariantName],
	INSERTED.[BusinessName],
	INSERTED.[ProductTypeID],
	INSERTED.[ShipRateTitle],
	INSERTED.[ShipRateID],
	INSERTED.[ShipRateType],
	INSERTED.[ShipRateAmount],
	INSERTED.[SalePoint],
	INSERTED.[TotalSalePoint],
	INSERTED.[ProductBuyType],
	INSERTED.[VIPSalePoint],
	INSERTED.[VIPTotalSalePoint],
	INSERTED.[StaffPoint],
	INSERTED.[TotalStaffPoint],
	INSERTED.[IsDiscountPrice]
into @table
VALUES ( 
	@OrderID,
	@ProductID,
	@ProductName,
	@Quantity,
	@Price,
	@BusinessID,
	@AddTime,
	@AddMan,
	@RoomID,
	@HistoryID,
	@RoomName,
	@ChargeID,
	@ChargeName,
	@StartTime,
	@EndTime,
	@VariantID,
	@TotalPrice,
	@VariantTitle,
	@VariantName,
	@BusinessName,
	@ProductTypeID,
	@ShipRateTitle,
	@ShipRateID,
	@ShipRateType,
	@ShipRateAmount,
	@SalePoint,
	@TotalSalePoint,
	@ProductBuyType,
	@VIPSalePoint,
	@VIPTotalSalePoint,
	@StaffPoint,
	@TotalStaffPoint,
	@IsDiscountPrice 
); 

SELECT 
	[ID],
	[OrderID],
	[ProductID],
	[ProductName],
	[Quantity],
	[Price],
	[BusinessID],
	[AddTime],
	[AddMan],
	[RoomID],
	[HistoryID],
	[RoomName],
	[ChargeID],
	[ChargeName],
	[StartTime],
	[EndTime],
	[VariantID],
	[TotalPrice],
	[VariantTitle],
	[VariantName],
	[BusinessName],
	[ProductTypeID],
	[ShipRateTitle],
	[ShipRateID],
	[ShipRateType],
	[ShipRateAmount],
	[SalePoint],
	[TotalSalePoint],
	[ProductBuyType],
	[VIPSalePoint],
	[VIPTotalSalePoint],
	[StaffPoint],
	[TotalStaffPoint],
	[IsDiscountPrice] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OrderID", EntityBase.GetDatabaseValue(@orderID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@ProductName", EntityBase.GetDatabaseValue(@productName)));
			parameters.Add(new SqlParameter("@Quantity", EntityBase.GetDatabaseValue(@quantity)));
			parameters.Add(new SqlParameter("@Price", EntityBase.GetDatabaseValue(@price)));
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@HistoryID", EntityBase.GetDatabaseValue(@historyID)));
			parameters.Add(new SqlParameter("@RoomName", EntityBase.GetDatabaseValue(@roomName)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@ChargeName", EntityBase.GetDatabaseValue(@chargeName)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@VariantID", EntityBase.GetDatabaseValue(@variantID)));
			parameters.Add(new SqlParameter("@TotalPrice", EntityBase.GetDatabaseValue(@totalPrice)));
			parameters.Add(new SqlParameter("@VariantTitle", EntityBase.GetDatabaseValue(@variantTitle)));
			parameters.Add(new SqlParameter("@VariantName", EntityBase.GetDatabaseValue(@variantName)));
			parameters.Add(new SqlParameter("@BusinessName", EntityBase.GetDatabaseValue(@businessName)));
			parameters.Add(new SqlParameter("@ProductTypeID", EntityBase.GetDatabaseValue(@productTypeID)));
			parameters.Add(new SqlParameter("@ShipRateTitle", EntityBase.GetDatabaseValue(@shipRateTitle)));
			parameters.Add(new SqlParameter("@ShipRateID", EntityBase.GetDatabaseValue(@shipRateID)));
			parameters.Add(new SqlParameter("@ShipRateType", EntityBase.GetDatabaseValue(@shipRateType)));
			parameters.Add(new SqlParameter("@ShipRateAmount", EntityBase.GetDatabaseValue(@shipRateAmount)));
			parameters.Add(new SqlParameter("@SalePoint", EntityBase.GetDatabaseValue(@salePoint)));
			parameters.Add(new SqlParameter("@TotalSalePoint", EntityBase.GetDatabaseValue(@totalSalePoint)));
			parameters.Add(new SqlParameter("@ProductBuyType", EntityBase.GetDatabaseValue(@productBuyType)));
			parameters.Add(new SqlParameter("@VIPSalePoint", EntityBase.GetDatabaseValue(@vIPSalePoint)));
			parameters.Add(new SqlParameter("@VIPTotalSalePoint", EntityBase.GetDatabaseValue(@vIPTotalSalePoint)));
			parameters.Add(new SqlParameter("@StaffPoint", EntityBase.GetDatabaseValue(@staffPoint)));
			parameters.Add(new SqlParameter("@TotalStaffPoint", EntityBase.GetDatabaseValue(@totalStaffPoint)));
			parameters.Add(new SqlParameter("@IsDiscountPrice", @isDiscountPrice));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_OrderItem into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orderID">orderID</param>
		/// <param name="productID">productID</param>
		/// <param name="productName">productName</param>
		/// <param name="quantity">quantity</param>
		/// <param name="price">price</param>
		/// <param name="businessID">businessID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="roomID">roomID</param>
		/// <param name="historyID">historyID</param>
		/// <param name="roomName">roomName</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="chargeName">chargeName</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="variantID">variantID</param>
		/// <param name="totalPrice">totalPrice</param>
		/// <param name="variantTitle">variantTitle</param>
		/// <param name="variantName">variantName</param>
		/// <param name="businessName">businessName</param>
		/// <param name="productTypeID">productTypeID</param>
		/// <param name="shipRateTitle">shipRateTitle</param>
		/// <param name="shipRateID">shipRateID</param>
		/// <param name="shipRateType">shipRateType</param>
		/// <param name="shipRateAmount">shipRateAmount</param>
		/// <param name="salePoint">salePoint</param>
		/// <param name="totalSalePoint">totalSalePoint</param>
		/// <param name="productBuyType">productBuyType</param>
		/// <param name="vIPSalePoint">vIPSalePoint</param>
		/// <param name="vIPTotalSalePoint">vIPTotalSalePoint</param>
		/// <param name="staffPoint">staffPoint</param>
		/// <param name="totalStaffPoint">totalStaffPoint</param>
		/// <param name="isDiscountPrice">isDiscountPrice</param>
		public static void UpdateMall_OrderItem(int @iD, int @orderID, int @productID, string @productName, int @quantity, decimal @price, int @businessID, DateTime @addTime, string @addMan, int @roomID, int @historyID, string @roomName, int @chargeID, string @chargeName, DateTime @startTime, DateTime @endTime, int @variantID, decimal @totalPrice, string @variantTitle, string @variantName, string @businessName, int @productTypeID, string @shipRateTitle, int @shipRateID, int @shipRateType, decimal @shipRateAmount, int @salePoint, int @totalSalePoint, int @productBuyType, int @vIPSalePoint, int @vIPTotalSalePoint, int @staffPoint, int @totalStaffPoint, bool @isDiscountPrice)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_OrderItem(@iD, @orderID, @productID, @productName, @quantity, @price, @businessID, @addTime, @addMan, @roomID, @historyID, @roomName, @chargeID, @chargeName, @startTime, @endTime, @variantID, @totalPrice, @variantTitle, @variantName, @businessName, @productTypeID, @shipRateTitle, @shipRateID, @shipRateType, @shipRateAmount, @salePoint, @totalSalePoint, @productBuyType, @vIPSalePoint, @vIPTotalSalePoint, @staffPoint, @totalStaffPoint, @isDiscountPrice, helper);
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
		/// Updates a Mall_OrderItem into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orderID">orderID</param>
		/// <param name="productID">productID</param>
		/// <param name="productName">productName</param>
		/// <param name="quantity">quantity</param>
		/// <param name="price">price</param>
		/// <param name="businessID">businessID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="roomID">roomID</param>
		/// <param name="historyID">historyID</param>
		/// <param name="roomName">roomName</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="chargeName">chargeName</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="variantID">variantID</param>
		/// <param name="totalPrice">totalPrice</param>
		/// <param name="variantTitle">variantTitle</param>
		/// <param name="variantName">variantName</param>
		/// <param name="businessName">businessName</param>
		/// <param name="productTypeID">productTypeID</param>
		/// <param name="shipRateTitle">shipRateTitle</param>
		/// <param name="shipRateID">shipRateID</param>
		/// <param name="shipRateType">shipRateType</param>
		/// <param name="shipRateAmount">shipRateAmount</param>
		/// <param name="salePoint">salePoint</param>
		/// <param name="totalSalePoint">totalSalePoint</param>
		/// <param name="productBuyType">productBuyType</param>
		/// <param name="vIPSalePoint">vIPSalePoint</param>
		/// <param name="vIPTotalSalePoint">vIPTotalSalePoint</param>
		/// <param name="staffPoint">staffPoint</param>
		/// <param name="totalStaffPoint">totalStaffPoint</param>
		/// <param name="isDiscountPrice">isDiscountPrice</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_OrderItem(int @iD, int @orderID, int @productID, string @productName, int @quantity, decimal @price, int @businessID, DateTime @addTime, string @addMan, int @roomID, int @historyID, string @roomName, int @chargeID, string @chargeName, DateTime @startTime, DateTime @endTime, int @variantID, decimal @totalPrice, string @variantTitle, string @variantName, string @businessName, int @productTypeID, string @shipRateTitle, int @shipRateID, int @shipRateType, decimal @shipRateAmount, int @salePoint, int @totalSalePoint, int @productBuyType, int @vIPSalePoint, int @vIPTotalSalePoint, int @staffPoint, int @totalStaffPoint, bool @isDiscountPrice, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrderID] int,
	[ProductID] int,
	[ProductName] nvarchar(200),
	[Quantity] int,
	[Price] decimal(18, 2),
	[BusinessID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[RoomID] int,
	[HistoryID] int,
	[RoomName] nvarchar(500),
	[ChargeID] int,
	[ChargeName] nvarchar(200),
	[StartTime] datetime,
	[EndTime] datetime,
	[VariantID] int,
	[TotalPrice] decimal(18, 2),
	[VariantTitle] nvarchar(100),
	[VariantName] nvarchar(100),
	[BusinessName] nvarchar(200),
	[ProductTypeID] int,
	[ShipRateTitle] nvarchar(200),
	[ShipRateID] int,
	[ShipRateType] int,
	[ShipRateAmount] decimal(18, 2),
	[SalePoint] int,
	[TotalSalePoint] int,
	[ProductBuyType] int,
	[VIPSalePoint] int,
	[VIPTotalSalePoint] int,
	[StaffPoint] int,
	[TotalStaffPoint] int,
	[IsDiscountPrice] bit
);

UPDATE [dbo].[Mall_OrderItem] SET 
	[Mall_OrderItem].[OrderID] = @OrderID,
	[Mall_OrderItem].[ProductID] = @ProductID,
	[Mall_OrderItem].[ProductName] = @ProductName,
	[Mall_OrderItem].[Quantity] = @Quantity,
	[Mall_OrderItem].[Price] = @Price,
	[Mall_OrderItem].[BusinessID] = @BusinessID,
	[Mall_OrderItem].[AddTime] = @AddTime,
	[Mall_OrderItem].[AddMan] = @AddMan,
	[Mall_OrderItem].[RoomID] = @RoomID,
	[Mall_OrderItem].[HistoryID] = @HistoryID,
	[Mall_OrderItem].[RoomName] = @RoomName,
	[Mall_OrderItem].[ChargeID] = @ChargeID,
	[Mall_OrderItem].[ChargeName] = @ChargeName,
	[Mall_OrderItem].[StartTime] = @StartTime,
	[Mall_OrderItem].[EndTime] = @EndTime,
	[Mall_OrderItem].[VariantID] = @VariantID,
	[Mall_OrderItem].[TotalPrice] = @TotalPrice,
	[Mall_OrderItem].[VariantTitle] = @VariantTitle,
	[Mall_OrderItem].[VariantName] = @VariantName,
	[Mall_OrderItem].[BusinessName] = @BusinessName,
	[Mall_OrderItem].[ProductTypeID] = @ProductTypeID,
	[Mall_OrderItem].[ShipRateTitle] = @ShipRateTitle,
	[Mall_OrderItem].[ShipRateID] = @ShipRateID,
	[Mall_OrderItem].[ShipRateType] = @ShipRateType,
	[Mall_OrderItem].[ShipRateAmount] = @ShipRateAmount,
	[Mall_OrderItem].[SalePoint] = @SalePoint,
	[Mall_OrderItem].[TotalSalePoint] = @TotalSalePoint,
	[Mall_OrderItem].[ProductBuyType] = @ProductBuyType,
	[Mall_OrderItem].[VIPSalePoint] = @VIPSalePoint,
	[Mall_OrderItem].[VIPTotalSalePoint] = @VIPTotalSalePoint,
	[Mall_OrderItem].[StaffPoint] = @StaffPoint,
	[Mall_OrderItem].[TotalStaffPoint] = @TotalStaffPoint,
	[Mall_OrderItem].[IsDiscountPrice] = @IsDiscountPrice 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[ProductID],
	INSERTED.[ProductName],
	INSERTED.[Quantity],
	INSERTED.[Price],
	INSERTED.[BusinessID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[RoomID],
	INSERTED.[HistoryID],
	INSERTED.[RoomName],
	INSERTED.[ChargeID],
	INSERTED.[ChargeName],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[VariantID],
	INSERTED.[TotalPrice],
	INSERTED.[VariantTitle],
	INSERTED.[VariantName],
	INSERTED.[BusinessName],
	INSERTED.[ProductTypeID],
	INSERTED.[ShipRateTitle],
	INSERTED.[ShipRateID],
	INSERTED.[ShipRateType],
	INSERTED.[ShipRateAmount],
	INSERTED.[SalePoint],
	INSERTED.[TotalSalePoint],
	INSERTED.[ProductBuyType],
	INSERTED.[VIPSalePoint],
	INSERTED.[VIPTotalSalePoint],
	INSERTED.[StaffPoint],
	INSERTED.[TotalStaffPoint],
	INSERTED.[IsDiscountPrice]
into @table
WHERE 
	[Mall_OrderItem].[ID] = @ID

SELECT 
	[ID],
	[OrderID],
	[ProductID],
	[ProductName],
	[Quantity],
	[Price],
	[BusinessID],
	[AddTime],
	[AddMan],
	[RoomID],
	[HistoryID],
	[RoomName],
	[ChargeID],
	[ChargeName],
	[StartTime],
	[EndTime],
	[VariantID],
	[TotalPrice],
	[VariantTitle],
	[VariantName],
	[BusinessName],
	[ProductTypeID],
	[ShipRateTitle],
	[ShipRateID],
	[ShipRateType],
	[ShipRateAmount],
	[SalePoint],
	[TotalSalePoint],
	[ProductBuyType],
	[VIPSalePoint],
	[VIPTotalSalePoint],
	[StaffPoint],
	[TotalStaffPoint],
	[IsDiscountPrice] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OrderID", EntityBase.GetDatabaseValue(@orderID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@ProductName", EntityBase.GetDatabaseValue(@productName)));
			parameters.Add(new SqlParameter("@Quantity", EntityBase.GetDatabaseValue(@quantity)));
			parameters.Add(new SqlParameter("@Price", EntityBase.GetDatabaseValue(@price)));
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@HistoryID", EntityBase.GetDatabaseValue(@historyID)));
			parameters.Add(new SqlParameter("@RoomName", EntityBase.GetDatabaseValue(@roomName)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@ChargeName", EntityBase.GetDatabaseValue(@chargeName)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@VariantID", EntityBase.GetDatabaseValue(@variantID)));
			parameters.Add(new SqlParameter("@TotalPrice", EntityBase.GetDatabaseValue(@totalPrice)));
			parameters.Add(new SqlParameter("@VariantTitle", EntityBase.GetDatabaseValue(@variantTitle)));
			parameters.Add(new SqlParameter("@VariantName", EntityBase.GetDatabaseValue(@variantName)));
			parameters.Add(new SqlParameter("@BusinessName", EntityBase.GetDatabaseValue(@businessName)));
			parameters.Add(new SqlParameter("@ProductTypeID", EntityBase.GetDatabaseValue(@productTypeID)));
			parameters.Add(new SqlParameter("@ShipRateTitle", EntityBase.GetDatabaseValue(@shipRateTitle)));
			parameters.Add(new SqlParameter("@ShipRateID", EntityBase.GetDatabaseValue(@shipRateID)));
			parameters.Add(new SqlParameter("@ShipRateType", EntityBase.GetDatabaseValue(@shipRateType)));
			parameters.Add(new SqlParameter("@ShipRateAmount", EntityBase.GetDatabaseValue(@shipRateAmount)));
			parameters.Add(new SqlParameter("@SalePoint", EntityBase.GetDatabaseValue(@salePoint)));
			parameters.Add(new SqlParameter("@TotalSalePoint", EntityBase.GetDatabaseValue(@totalSalePoint)));
			parameters.Add(new SqlParameter("@ProductBuyType", EntityBase.GetDatabaseValue(@productBuyType)));
			parameters.Add(new SqlParameter("@VIPSalePoint", EntityBase.GetDatabaseValue(@vIPSalePoint)));
			parameters.Add(new SqlParameter("@VIPTotalSalePoint", EntityBase.GetDatabaseValue(@vIPTotalSalePoint)));
			parameters.Add(new SqlParameter("@StaffPoint", EntityBase.GetDatabaseValue(@staffPoint)));
			parameters.Add(new SqlParameter("@TotalStaffPoint", EntityBase.GetDatabaseValue(@totalStaffPoint)));
			parameters.Add(new SqlParameter("@IsDiscountPrice", @isDiscountPrice));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_OrderItem from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_OrderItem(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_OrderItem(@iD, helper);
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
		/// Deletes a Mall_OrderItem from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_OrderItem(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_OrderItem]
WHERE 
	[Mall_OrderItem].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_OrderItem object.
		/// </summary>
		/// <returns>The newly created Mall_OrderItem object.</returns>
		public static Mall_OrderItem CreateMall_OrderItem()
		{
			return InitializeNew<Mall_OrderItem>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_OrderItem by a Mall_OrderItem's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_OrderItem</returns>
		public static Mall_OrderItem GetMall_OrderItem(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_OrderItem.SelectFieldList + @"
FROM [dbo].[Mall_OrderItem] 
WHERE 
	[Mall_OrderItem].[ID] = @ID " + Mall_OrderItem.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_OrderItem>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_OrderItem by a Mall_OrderItem's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_OrderItem</returns>
		public static Mall_OrderItem GetMall_OrderItem(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_OrderItem.SelectFieldList + @"
FROM [dbo].[Mall_OrderItem] 
WHERE 
	[Mall_OrderItem].[ID] = @ID " + Mall_OrderItem.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_OrderItem>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderItem objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_OrderItem objects.</returns>
		public static EntityList<Mall_OrderItem> GetMall_OrderItems()
		{
			string commandText = @"
SELECT " + Mall_OrderItem.SelectFieldList + "FROM [dbo].[Mall_OrderItem] " + Mall_OrderItem.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_OrderItem>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_OrderItem objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_OrderItem objects.</returns>
        public static EntityList<Mall_OrderItem> GetMall_OrderItems(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_OrderItem>(SelectFieldList, "FROM [dbo].[Mall_OrderItem]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_OrderItem objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_OrderItem objects.</returns>
        public static EntityList<Mall_OrderItem> GetMall_OrderItems(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_OrderItem>(SelectFieldList, "FROM [dbo].[Mall_OrderItem]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_OrderItem objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_OrderItem objects.</returns>
		protected static EntityList<Mall_OrderItem> GetMall_OrderItems(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_OrderItems(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderItem objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderItem objects.</returns>
		protected static EntityList<Mall_OrderItem> GetMall_OrderItems(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_OrderItems(string.Empty, where, parameters, Mall_OrderItem.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderItem objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderItem objects.</returns>
		protected static EntityList<Mall_OrderItem> GetMall_OrderItems(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_OrderItems(prefix, where, parameters, Mall_OrderItem.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderItem objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderItem objects.</returns>
		protected static EntityList<Mall_OrderItem> GetMall_OrderItems(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_OrderItems(string.Empty, where, parameters, Mall_OrderItem.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderItem objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderItem objects.</returns>
		protected static EntityList<Mall_OrderItem> GetMall_OrderItems(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_OrderItems(prefix, where, parameters, Mall_OrderItem.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderItem objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_OrderItem objects.</returns>
		protected static EntityList<Mall_OrderItem> GetMall_OrderItems(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_OrderItem.SelectFieldList + "FROM [dbo].[Mall_OrderItem] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_OrderItem>(reader);
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
        protected static EntityList<Mall_OrderItem> GetMall_OrderItems(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_OrderItem>(SelectFieldList, "FROM [dbo].[Mall_OrderItem] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_OrderItem objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_OrderItemCount()
        {
            return GetMall_OrderItemCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_OrderItem objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_OrderItemCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_OrderItem] " + where;

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
		public static partial class Mall_OrderItem_Properties
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
			public const string TotalPrice = "TotalPrice";
			public const string VariantTitle = "VariantTitle";
			public const string VariantName = "VariantName";
			public const string BusinessName = "BusinessName";
			public const string ProductTypeID = "ProductTypeID";
			public const string ShipRateTitle = "ShipRateTitle";
			public const string ShipRateID = "ShipRateID";
			public const string ShipRateType = "ShipRateType";
			public const string ShipRateAmount = "ShipRateAmount";
			public const string SalePoint = "SalePoint";
			public const string TotalSalePoint = "TotalSalePoint";
			public const string ProductBuyType = "ProductBuyType";
			public const string VIPSalePoint = "VIPSalePoint";
			public const string VIPTotalSalePoint = "VIPTotalSalePoint";
			public const string StaffPoint = "StaffPoint";
			public const string TotalStaffPoint = "TotalStaffPoint";
			public const string IsDiscountPrice = "IsDiscountPrice";
            
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
    			 {"TotalPrice" , "decimal:"},
    			 {"VariantTitle" , "string:"},
    			 {"VariantName" , "string:"},
    			 {"BusinessName" , "string:"},
    			 {"ProductTypeID" , "int:1-购买商品 2-积分兑换 3-拼团抢购 4-限时秒杀 5-生活服务 10-物业收费"},
    			 {"ShipRateTitle" , "string:"},
    			 {"ShipRateID" , "int:"},
    			 {"ShipRateType" , "int:"},
    			 {"ShipRateAmount" , "decimal:"},
    			 {"SalePoint" , "int:"},
    			 {"TotalSalePoint" , "int:"},
    			 {"ProductBuyType" , "int:"},
    			 {"VIPSalePoint" , "int:"},
    			 {"VIPTotalSalePoint" , "int:"},
    			 {"StaffPoint" , "int:"},
    			 {"TotalStaffPoint" , "int:"},
    			 {"IsDiscountPrice" , "bool:"},
            };
		}
		#endregion
	}
}
