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
	/// This object represents the properties and methods of a WarehouseInOut.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class WarehouseInOut 
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
		private int _inventoryInfoID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int InventoryInfoID
		{
			[DebuggerStepThrough()]
			get { return this._inventoryInfoID; }
			set 
			{
				if (this._inventoryInfoID != value) 
				{
					this._inventoryInfoID = value;
					this.IsDirty = true;	
					OnPropertyChanged("InventoryInfoID");
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
		[DataObjectField(false, false, true)]
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
		private int _specInfoID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SpecInfoID
		{
			[DebuggerStepThrough()]
			get { return this._specInfoID; }
			set 
			{
				if (this._specInfoID != value) 
				{
					this._specInfoID = value;
					this.IsDirty = true;	
					OnPropertyChanged("SpecInfoID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _count = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Count
		{
			[DebuggerStepThrough()]
			get { return this._count; }
			set 
			{
				if (this._count != value) 
				{
					this._count = value;
					this.IsDirty = true;	
					OnPropertyChanged("Count");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _coldCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ColdCost
		{
			[DebuggerStepThrough()]
			get { return this._coldCost; }
			set 
			{
				if (this._coldCost != value) 
				{
					this._coldCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("ColdCost");
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
		private int _carrierID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CarrierID
		{
			[DebuggerStepThrough()]
			get { return this._carrierID; }
			set 
			{
				if (this._carrierID != value) 
				{
					this._carrierID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CarrierID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _moveCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal MoveCost
		{
			[DebuggerStepThrough()]
			get { return this._moveCost; }
			set 
			{
				if (this._moveCost != value) 
				{
					this._moveCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("MoveCost");
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
		[DataObjectField(false, false, true)]
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
		private int _inOutType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int InOutType
		{
			[DebuggerStepThrough()]
			get { return this._inOutType; }
			set 
			{
				if (this._inOutType != value) 
				{
					this._inOutType = value;
					this.IsDirty = true;	
					OnPropertyChanged("InOutType");
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
		private int _relateID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RelateID
		{
			[DebuggerStepThrough()]
			get { return this._relateID; }
			set 
			{
				if (this._relateID != value) 
				{
					this._relateID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RelateID");
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
		private decimal _discountCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal DiscountCost
		{
			[DebuggerStepThrough()]
			get { return this._discountCost; }
			set 
			{
				if (this._discountCost != value) 
				{
					this._discountCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("DiscountCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _businessChargeStatus = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool BusinessChargeStatus
		{
			[DebuggerStepThrough()]
			get { return this._businessChargeStatus; }
			set 
			{
				if (this._businessChargeStatus != value) 
				{
					this._businessChargeStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessChargeStatus");
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
		private DateTime _balanceTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime BalanceTime
		{
			[DebuggerStepThrough()]
			get { return this._balanceTime; }
			set 
			{
				if (this._balanceTime != value) 
				{
					this._balanceTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("BalanceTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _removeCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RemoveCost
		{
			[DebuggerStepThrough()]
			get { return this._removeCost; }
			set 
			{
				if (this._removeCost != value) 
				{
					this._removeCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("RemoveCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _carrierBalanceCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal CarrierBalanceCost
		{
			[DebuggerStepThrough()]
			get { return this._carrierBalanceCost; }
			set 
			{
				if (this._carrierBalanceCost != value) 
				{
					this._carrierBalanceCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("CarrierBalanceCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _carrierChargeStatus = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool CarrierChargeStatus
		{
			[DebuggerStepThrough()]
			get { return this._carrierChargeStatus; }
			set 
			{
				if (this._carrierChargeStatus != value) 
				{
					this._carrierChargeStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("CarrierChargeStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _carrierBalanceTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime CarrierBalanceTime
		{
			[DebuggerStepThrough()]
			get { return this._carrierBalanceTime; }
			set 
			{
				if (this._carrierBalanceTime != value) 
				{
					this._carrierBalanceTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("CarrierBalanceTime");
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
		[DataObjectField(false, false, true)]
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
		private decimal _carrierMoveCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal CarrierMoveCost
		{
			[DebuggerStepThrough()]
			get { return this._carrierMoveCost; }
			set 
			{
				if (this._carrierMoveCost != value) 
				{
					this._carrierMoveCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("CarrierMoveCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isToNext = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsToNext
		{
			[DebuggerStepThrough()]
			get { return this._isToNext; }
			set 
			{
				if (this._isToNext != value) 
				{
					this._isToNext = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsToNext");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isNextOrder = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsNextOrder
		{
			[DebuggerStepThrough()]
			get { return this._isNextOrder; }
			set 
			{
				if (this._isNextOrder != value) 
				{
					this._isNextOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsNextOrder");
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
	[BusinessID] int,
	[InventoryInfoID] int,
	[ProductID] int,
	[SpecInfoID] int,
	[Count] int,
	[ColdCost] decimal(18, 2),
	[StartTime] datetime,
	[EndTime] datetime,
	[CarrierID] int,
	[MoveCost] decimal(18, 2),
	[TotalCost] decimal(18, 2),
	[AddTime] datetime,
	[OrderNumber] nvarchar(100),
	[InOutType] int,
	[OutTime] datetime,
	[RelateID] int,
	[AddMan] nvarchar(50),
	[Remark] ntext,
	[RealCost] decimal(18, 2),
	[DiscountCost] decimal(18, 2),
	[BusinessChargeStatus] bit,
	[PrintID] int,
	[BalanceTime] datetime,
	[RemoveCost] decimal(18, 2),
	[CarrierBalanceCost] decimal(18, 2),
	[CarrierChargeStatus] bit,
	[CarrierBalanceTime] datetime,
	[TotalCount] int,
	[CarrierMoveCost] decimal(18, 2),
	[IsToNext] bit,
	[IsNextOrder] bit,
	[LastPrintTime] datetime,
	[PrintCount] int
);

INSERT INTO [dbo].[WarehouseInOut] (
	[WarehouseInOut].[BusinessID],
	[WarehouseInOut].[InventoryInfoID],
	[WarehouseInOut].[ProductID],
	[WarehouseInOut].[SpecInfoID],
	[WarehouseInOut].[Count],
	[WarehouseInOut].[ColdCost],
	[WarehouseInOut].[StartTime],
	[WarehouseInOut].[EndTime],
	[WarehouseInOut].[CarrierID],
	[WarehouseInOut].[MoveCost],
	[WarehouseInOut].[TotalCost],
	[WarehouseInOut].[AddTime],
	[WarehouseInOut].[OrderNumber],
	[WarehouseInOut].[InOutType],
	[WarehouseInOut].[OutTime],
	[WarehouseInOut].[RelateID],
	[WarehouseInOut].[AddMan],
	[WarehouseInOut].[Remark],
	[WarehouseInOut].[RealCost],
	[WarehouseInOut].[DiscountCost],
	[WarehouseInOut].[BusinessChargeStatus],
	[WarehouseInOut].[PrintID],
	[WarehouseInOut].[BalanceTime],
	[WarehouseInOut].[RemoveCost],
	[WarehouseInOut].[CarrierBalanceCost],
	[WarehouseInOut].[CarrierChargeStatus],
	[WarehouseInOut].[CarrierBalanceTime],
	[WarehouseInOut].[TotalCount],
	[WarehouseInOut].[CarrierMoveCost],
	[WarehouseInOut].[IsToNext],
	[WarehouseInOut].[IsNextOrder],
	[WarehouseInOut].[LastPrintTime],
	[WarehouseInOut].[PrintCount]
) 
output 
	INSERTED.[ID],
	INSERTED.[BusinessID],
	INSERTED.[InventoryInfoID],
	INSERTED.[ProductID],
	INSERTED.[SpecInfoID],
	INSERTED.[Count],
	INSERTED.[ColdCost],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[CarrierID],
	INSERTED.[MoveCost],
	INSERTED.[TotalCost],
	INSERTED.[AddTime],
	INSERTED.[OrderNumber],
	INSERTED.[InOutType],
	INSERTED.[OutTime],
	INSERTED.[RelateID],
	INSERTED.[AddMan],
	INSERTED.[Remark],
	INSERTED.[RealCost],
	INSERTED.[DiscountCost],
	INSERTED.[BusinessChargeStatus],
	INSERTED.[PrintID],
	INSERTED.[BalanceTime],
	INSERTED.[RemoveCost],
	INSERTED.[CarrierBalanceCost],
	INSERTED.[CarrierChargeStatus],
	INSERTED.[CarrierBalanceTime],
	INSERTED.[TotalCount],
	INSERTED.[CarrierMoveCost],
	INSERTED.[IsToNext],
	INSERTED.[IsNextOrder],
	INSERTED.[LastPrintTime],
	INSERTED.[PrintCount]
into @table
VALUES ( 
	@BusinessID,
	@InventoryInfoID,
	@ProductID,
	@SpecInfoID,
	@Count,
	@ColdCost,
	@StartTime,
	@EndTime,
	@CarrierID,
	@MoveCost,
	@TotalCost,
	@AddTime,
	@OrderNumber,
	@InOutType,
	@OutTime,
	@RelateID,
	@AddMan,
	@Remark,
	@RealCost,
	@DiscountCost,
	@BusinessChargeStatus,
	@PrintID,
	@BalanceTime,
	@RemoveCost,
	@CarrierBalanceCost,
	@CarrierChargeStatus,
	@CarrierBalanceTime,
	@TotalCount,
	@CarrierMoveCost,
	@IsToNext,
	@IsNextOrder,
	@LastPrintTime,
	@PrintCount 
); 

SELECT 
	[ID],
	[BusinessID],
	[InventoryInfoID],
	[ProductID],
	[SpecInfoID],
	[Count],
	[ColdCost],
	[StartTime],
	[EndTime],
	[CarrierID],
	[MoveCost],
	[TotalCost],
	[AddTime],
	[OrderNumber],
	[InOutType],
	[OutTime],
	[RelateID],
	[AddMan],
	[Remark],
	[RealCost],
	[DiscountCost],
	[BusinessChargeStatus],
	[PrintID],
	[BalanceTime],
	[RemoveCost],
	[CarrierBalanceCost],
	[CarrierChargeStatus],
	[CarrierBalanceTime],
	[TotalCount],
	[CarrierMoveCost],
	[IsToNext],
	[IsNextOrder],
	[LastPrintTime],
	[PrintCount] 
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
	[BusinessID] int,
	[InventoryInfoID] int,
	[ProductID] int,
	[SpecInfoID] int,
	[Count] int,
	[ColdCost] decimal(18, 2),
	[StartTime] datetime,
	[EndTime] datetime,
	[CarrierID] int,
	[MoveCost] decimal(18, 2),
	[TotalCost] decimal(18, 2),
	[AddTime] datetime,
	[OrderNumber] nvarchar(100),
	[InOutType] int,
	[OutTime] datetime,
	[RelateID] int,
	[AddMan] nvarchar(50),
	[Remark] ntext,
	[RealCost] decimal(18, 2),
	[DiscountCost] decimal(18, 2),
	[BusinessChargeStatus] bit,
	[PrintID] int,
	[BalanceTime] datetime,
	[RemoveCost] decimal(18, 2),
	[CarrierBalanceCost] decimal(18, 2),
	[CarrierChargeStatus] bit,
	[CarrierBalanceTime] datetime,
	[TotalCount] int,
	[CarrierMoveCost] decimal(18, 2),
	[IsToNext] bit,
	[IsNextOrder] bit,
	[LastPrintTime] datetime,
	[PrintCount] int
);

UPDATE [dbo].[WarehouseInOut] SET 
	[WarehouseInOut].[BusinessID] = @BusinessID,
	[WarehouseInOut].[InventoryInfoID] = @InventoryInfoID,
	[WarehouseInOut].[ProductID] = @ProductID,
	[WarehouseInOut].[SpecInfoID] = @SpecInfoID,
	[WarehouseInOut].[Count] = @Count,
	[WarehouseInOut].[ColdCost] = @ColdCost,
	[WarehouseInOut].[StartTime] = @StartTime,
	[WarehouseInOut].[EndTime] = @EndTime,
	[WarehouseInOut].[CarrierID] = @CarrierID,
	[WarehouseInOut].[MoveCost] = @MoveCost,
	[WarehouseInOut].[TotalCost] = @TotalCost,
	[WarehouseInOut].[AddTime] = @AddTime,
	[WarehouseInOut].[OrderNumber] = @OrderNumber,
	[WarehouseInOut].[InOutType] = @InOutType,
	[WarehouseInOut].[OutTime] = @OutTime,
	[WarehouseInOut].[RelateID] = @RelateID,
	[WarehouseInOut].[AddMan] = @AddMan,
	[WarehouseInOut].[Remark] = @Remark,
	[WarehouseInOut].[RealCost] = @RealCost,
	[WarehouseInOut].[DiscountCost] = @DiscountCost,
	[WarehouseInOut].[BusinessChargeStatus] = @BusinessChargeStatus,
	[WarehouseInOut].[PrintID] = @PrintID,
	[WarehouseInOut].[BalanceTime] = @BalanceTime,
	[WarehouseInOut].[RemoveCost] = @RemoveCost,
	[WarehouseInOut].[CarrierBalanceCost] = @CarrierBalanceCost,
	[WarehouseInOut].[CarrierChargeStatus] = @CarrierChargeStatus,
	[WarehouseInOut].[CarrierBalanceTime] = @CarrierBalanceTime,
	[WarehouseInOut].[TotalCount] = @TotalCount,
	[WarehouseInOut].[CarrierMoveCost] = @CarrierMoveCost,
	[WarehouseInOut].[IsToNext] = @IsToNext,
	[WarehouseInOut].[IsNextOrder] = @IsNextOrder,
	[WarehouseInOut].[LastPrintTime] = @LastPrintTime,
	[WarehouseInOut].[PrintCount] = @PrintCount 
output 
	INSERTED.[ID],
	INSERTED.[BusinessID],
	INSERTED.[InventoryInfoID],
	INSERTED.[ProductID],
	INSERTED.[SpecInfoID],
	INSERTED.[Count],
	INSERTED.[ColdCost],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[CarrierID],
	INSERTED.[MoveCost],
	INSERTED.[TotalCost],
	INSERTED.[AddTime],
	INSERTED.[OrderNumber],
	INSERTED.[InOutType],
	INSERTED.[OutTime],
	INSERTED.[RelateID],
	INSERTED.[AddMan],
	INSERTED.[Remark],
	INSERTED.[RealCost],
	INSERTED.[DiscountCost],
	INSERTED.[BusinessChargeStatus],
	INSERTED.[PrintID],
	INSERTED.[BalanceTime],
	INSERTED.[RemoveCost],
	INSERTED.[CarrierBalanceCost],
	INSERTED.[CarrierChargeStatus],
	INSERTED.[CarrierBalanceTime],
	INSERTED.[TotalCount],
	INSERTED.[CarrierMoveCost],
	INSERTED.[IsToNext],
	INSERTED.[IsNextOrder],
	INSERTED.[LastPrintTime],
	INSERTED.[PrintCount]
into @table
WHERE 
	[WarehouseInOut].[ID] = @ID

SELECT 
	[ID],
	[BusinessID],
	[InventoryInfoID],
	[ProductID],
	[SpecInfoID],
	[Count],
	[ColdCost],
	[StartTime],
	[EndTime],
	[CarrierID],
	[MoveCost],
	[TotalCost],
	[AddTime],
	[OrderNumber],
	[InOutType],
	[OutTime],
	[RelateID],
	[AddMan],
	[Remark],
	[RealCost],
	[DiscountCost],
	[BusinessChargeStatus],
	[PrintID],
	[BalanceTime],
	[RemoveCost],
	[CarrierBalanceCost],
	[CarrierChargeStatus],
	[CarrierBalanceTime],
	[TotalCount],
	[CarrierMoveCost],
	[IsToNext],
	[IsNextOrder],
	[LastPrintTime],
	[PrintCount] 
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
DELETE FROM [dbo].[WarehouseInOut]
WHERE 
	[WarehouseInOut].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public WarehouseInOut() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWarehouseInOut(this.ID));
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
	[WarehouseInOut].[ID],
	[WarehouseInOut].[BusinessID],
	[WarehouseInOut].[InventoryInfoID],
	[WarehouseInOut].[ProductID],
	[WarehouseInOut].[SpecInfoID],
	[WarehouseInOut].[Count],
	[WarehouseInOut].[ColdCost],
	[WarehouseInOut].[StartTime],
	[WarehouseInOut].[EndTime],
	[WarehouseInOut].[CarrierID],
	[WarehouseInOut].[MoveCost],
	[WarehouseInOut].[TotalCost],
	[WarehouseInOut].[AddTime],
	[WarehouseInOut].[OrderNumber],
	[WarehouseInOut].[InOutType],
	[WarehouseInOut].[OutTime],
	[WarehouseInOut].[RelateID],
	[WarehouseInOut].[AddMan],
	[WarehouseInOut].[Remark],
	[WarehouseInOut].[RealCost],
	[WarehouseInOut].[DiscountCost],
	[WarehouseInOut].[BusinessChargeStatus],
	[WarehouseInOut].[PrintID],
	[WarehouseInOut].[BalanceTime],
	[WarehouseInOut].[RemoveCost],
	[WarehouseInOut].[CarrierBalanceCost],
	[WarehouseInOut].[CarrierChargeStatus],
	[WarehouseInOut].[CarrierBalanceTime],
	[WarehouseInOut].[TotalCount],
	[WarehouseInOut].[CarrierMoveCost],
	[WarehouseInOut].[IsToNext],
	[WarehouseInOut].[IsNextOrder],
	[WarehouseInOut].[LastPrintTime],
	[WarehouseInOut].[PrintCount]
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
                return "WarehouseInOut";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a WarehouseInOut into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="businessID">businessID</param>
		/// <param name="inventoryInfoID">inventoryInfoID</param>
		/// <param name="productID">productID</param>
		/// <param name="specInfoID">specInfoID</param>
		/// <param name="count">count</param>
		/// <param name="coldCost">coldCost</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="carrierID">carrierID</param>
		/// <param name="moveCost">moveCost</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="inOutType">inOutType</param>
		/// <param name="outTime">outTime</param>
		/// <param name="relateID">relateID</param>
		/// <param name="addMan">addMan</param>
		/// <param name="remark">remark</param>
		/// <param name="realCost">realCost</param>
		/// <param name="discountCost">discountCost</param>
		/// <param name="businessChargeStatus">businessChargeStatus</param>
		/// <param name="printID">printID</param>
		/// <param name="balanceTime">balanceTime</param>
		/// <param name="removeCost">removeCost</param>
		/// <param name="carrierBalanceCost">carrierBalanceCost</param>
		/// <param name="carrierChargeStatus">carrierChargeStatus</param>
		/// <param name="carrierBalanceTime">carrierBalanceTime</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="carrierMoveCost">carrierMoveCost</param>
		/// <param name="isToNext">isToNext</param>
		/// <param name="isNextOrder">isNextOrder</param>
		/// <param name="lastPrintTime">lastPrintTime</param>
		/// <param name="printCount">printCount</param>
		public static void InsertWarehouseInOut(int @businessID, int @inventoryInfoID, int @productID, int @specInfoID, int @count, decimal @coldCost, DateTime @startTime, DateTime @endTime, int @carrierID, decimal @moveCost, decimal @totalCost, DateTime @addTime, string @orderNumber, int @inOutType, DateTime @outTime, int @relateID, string @addMan, string @remark, decimal @realCost, decimal @discountCost, bool @businessChargeStatus, int @printID, DateTime @balanceTime, decimal @removeCost, decimal @carrierBalanceCost, bool @carrierChargeStatus, DateTime @carrierBalanceTime, int @totalCount, decimal @carrierMoveCost, bool @isToNext, bool @isNextOrder, DateTime @lastPrintTime, int @printCount)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWarehouseInOut(@businessID, @inventoryInfoID, @productID, @specInfoID, @count, @coldCost, @startTime, @endTime, @carrierID, @moveCost, @totalCost, @addTime, @orderNumber, @inOutType, @outTime, @relateID, @addMan, @remark, @realCost, @discountCost, @businessChargeStatus, @printID, @balanceTime, @removeCost, @carrierBalanceCost, @carrierChargeStatus, @carrierBalanceTime, @totalCount, @carrierMoveCost, @isToNext, @isNextOrder, @lastPrintTime, @printCount, helper);
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
		/// Insert a WarehouseInOut into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="businessID">businessID</param>
		/// <param name="inventoryInfoID">inventoryInfoID</param>
		/// <param name="productID">productID</param>
		/// <param name="specInfoID">specInfoID</param>
		/// <param name="count">count</param>
		/// <param name="coldCost">coldCost</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="carrierID">carrierID</param>
		/// <param name="moveCost">moveCost</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="inOutType">inOutType</param>
		/// <param name="outTime">outTime</param>
		/// <param name="relateID">relateID</param>
		/// <param name="addMan">addMan</param>
		/// <param name="remark">remark</param>
		/// <param name="realCost">realCost</param>
		/// <param name="discountCost">discountCost</param>
		/// <param name="businessChargeStatus">businessChargeStatus</param>
		/// <param name="printID">printID</param>
		/// <param name="balanceTime">balanceTime</param>
		/// <param name="removeCost">removeCost</param>
		/// <param name="carrierBalanceCost">carrierBalanceCost</param>
		/// <param name="carrierChargeStatus">carrierChargeStatus</param>
		/// <param name="carrierBalanceTime">carrierBalanceTime</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="carrierMoveCost">carrierMoveCost</param>
		/// <param name="isToNext">isToNext</param>
		/// <param name="isNextOrder">isNextOrder</param>
		/// <param name="lastPrintTime">lastPrintTime</param>
		/// <param name="printCount">printCount</param>
		/// <param name="helper">helper</param>
		internal static void InsertWarehouseInOut(int @businessID, int @inventoryInfoID, int @productID, int @specInfoID, int @count, decimal @coldCost, DateTime @startTime, DateTime @endTime, int @carrierID, decimal @moveCost, decimal @totalCost, DateTime @addTime, string @orderNumber, int @inOutType, DateTime @outTime, int @relateID, string @addMan, string @remark, decimal @realCost, decimal @discountCost, bool @businessChargeStatus, int @printID, DateTime @balanceTime, decimal @removeCost, decimal @carrierBalanceCost, bool @carrierChargeStatus, DateTime @carrierBalanceTime, int @totalCount, decimal @carrierMoveCost, bool @isToNext, bool @isNextOrder, DateTime @lastPrintTime, int @printCount, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BusinessID] int,
	[InventoryInfoID] int,
	[ProductID] int,
	[SpecInfoID] int,
	[Count] int,
	[ColdCost] decimal(18, 2),
	[StartTime] datetime,
	[EndTime] datetime,
	[CarrierID] int,
	[MoveCost] decimal(18, 2),
	[TotalCost] decimal(18, 2),
	[AddTime] datetime,
	[OrderNumber] nvarchar(100),
	[InOutType] int,
	[OutTime] datetime,
	[RelateID] int,
	[AddMan] nvarchar(50),
	[Remark] ntext,
	[RealCost] decimal(18, 2),
	[DiscountCost] decimal(18, 2),
	[BusinessChargeStatus] bit,
	[PrintID] int,
	[BalanceTime] datetime,
	[RemoveCost] decimal(18, 2),
	[CarrierBalanceCost] decimal(18, 2),
	[CarrierChargeStatus] bit,
	[CarrierBalanceTime] datetime,
	[TotalCount] int,
	[CarrierMoveCost] decimal(18, 2),
	[IsToNext] bit,
	[IsNextOrder] bit,
	[LastPrintTime] datetime,
	[PrintCount] int
);

INSERT INTO [dbo].[WarehouseInOut] (
	[WarehouseInOut].[BusinessID],
	[WarehouseInOut].[InventoryInfoID],
	[WarehouseInOut].[ProductID],
	[WarehouseInOut].[SpecInfoID],
	[WarehouseInOut].[Count],
	[WarehouseInOut].[ColdCost],
	[WarehouseInOut].[StartTime],
	[WarehouseInOut].[EndTime],
	[WarehouseInOut].[CarrierID],
	[WarehouseInOut].[MoveCost],
	[WarehouseInOut].[TotalCost],
	[WarehouseInOut].[AddTime],
	[WarehouseInOut].[OrderNumber],
	[WarehouseInOut].[InOutType],
	[WarehouseInOut].[OutTime],
	[WarehouseInOut].[RelateID],
	[WarehouseInOut].[AddMan],
	[WarehouseInOut].[Remark],
	[WarehouseInOut].[RealCost],
	[WarehouseInOut].[DiscountCost],
	[WarehouseInOut].[BusinessChargeStatus],
	[WarehouseInOut].[PrintID],
	[WarehouseInOut].[BalanceTime],
	[WarehouseInOut].[RemoveCost],
	[WarehouseInOut].[CarrierBalanceCost],
	[WarehouseInOut].[CarrierChargeStatus],
	[WarehouseInOut].[CarrierBalanceTime],
	[WarehouseInOut].[TotalCount],
	[WarehouseInOut].[CarrierMoveCost],
	[WarehouseInOut].[IsToNext],
	[WarehouseInOut].[IsNextOrder],
	[WarehouseInOut].[LastPrintTime],
	[WarehouseInOut].[PrintCount]
) 
output 
	INSERTED.[ID],
	INSERTED.[BusinessID],
	INSERTED.[InventoryInfoID],
	INSERTED.[ProductID],
	INSERTED.[SpecInfoID],
	INSERTED.[Count],
	INSERTED.[ColdCost],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[CarrierID],
	INSERTED.[MoveCost],
	INSERTED.[TotalCost],
	INSERTED.[AddTime],
	INSERTED.[OrderNumber],
	INSERTED.[InOutType],
	INSERTED.[OutTime],
	INSERTED.[RelateID],
	INSERTED.[AddMan],
	INSERTED.[Remark],
	INSERTED.[RealCost],
	INSERTED.[DiscountCost],
	INSERTED.[BusinessChargeStatus],
	INSERTED.[PrintID],
	INSERTED.[BalanceTime],
	INSERTED.[RemoveCost],
	INSERTED.[CarrierBalanceCost],
	INSERTED.[CarrierChargeStatus],
	INSERTED.[CarrierBalanceTime],
	INSERTED.[TotalCount],
	INSERTED.[CarrierMoveCost],
	INSERTED.[IsToNext],
	INSERTED.[IsNextOrder],
	INSERTED.[LastPrintTime],
	INSERTED.[PrintCount]
into @table
VALUES ( 
	@BusinessID,
	@InventoryInfoID,
	@ProductID,
	@SpecInfoID,
	@Count,
	@ColdCost,
	@StartTime,
	@EndTime,
	@CarrierID,
	@MoveCost,
	@TotalCost,
	@AddTime,
	@OrderNumber,
	@InOutType,
	@OutTime,
	@RelateID,
	@AddMan,
	@Remark,
	@RealCost,
	@DiscountCost,
	@BusinessChargeStatus,
	@PrintID,
	@BalanceTime,
	@RemoveCost,
	@CarrierBalanceCost,
	@CarrierChargeStatus,
	@CarrierBalanceTime,
	@TotalCount,
	@CarrierMoveCost,
	@IsToNext,
	@IsNextOrder,
	@LastPrintTime,
	@PrintCount 
); 

SELECT 
	[ID],
	[BusinessID],
	[InventoryInfoID],
	[ProductID],
	[SpecInfoID],
	[Count],
	[ColdCost],
	[StartTime],
	[EndTime],
	[CarrierID],
	[MoveCost],
	[TotalCost],
	[AddTime],
	[OrderNumber],
	[InOutType],
	[OutTime],
	[RelateID],
	[AddMan],
	[Remark],
	[RealCost],
	[DiscountCost],
	[BusinessChargeStatus],
	[PrintID],
	[BalanceTime],
	[RemoveCost],
	[CarrierBalanceCost],
	[CarrierChargeStatus],
	[CarrierBalanceTime],
	[TotalCount],
	[CarrierMoveCost],
	[IsToNext],
	[IsNextOrder],
	[LastPrintTime],
	[PrintCount] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			parameters.Add(new SqlParameter("@InventoryInfoID", EntityBase.GetDatabaseValue(@inventoryInfoID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@SpecInfoID", EntityBase.GetDatabaseValue(@specInfoID)));
			parameters.Add(new SqlParameter("@Count", EntityBase.GetDatabaseValue(@count)));
			parameters.Add(new SqlParameter("@ColdCost", EntityBase.GetDatabaseValue(@coldCost)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@CarrierID", EntityBase.GetDatabaseValue(@carrierID)));
			parameters.Add(new SqlParameter("@MoveCost", EntityBase.GetDatabaseValue(@moveCost)));
			parameters.Add(new SqlParameter("@TotalCost", EntityBase.GetDatabaseValue(@totalCost)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@OrderNumber", EntityBase.GetDatabaseValue(@orderNumber)));
			parameters.Add(new SqlParameter("@InOutType", EntityBase.GetDatabaseValue(@inOutType)));
			parameters.Add(new SqlParameter("@OutTime", EntityBase.GetDatabaseValue(@outTime)));
			parameters.Add(new SqlParameter("@RelateID", EntityBase.GetDatabaseValue(@relateID)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@RealCost", EntityBase.GetDatabaseValue(@realCost)));
			parameters.Add(new SqlParameter("@DiscountCost", EntityBase.GetDatabaseValue(@discountCost)));
			parameters.Add(new SqlParameter("@BusinessChargeStatus", @businessChargeStatus));
			parameters.Add(new SqlParameter("@PrintID", EntityBase.GetDatabaseValue(@printID)));
			parameters.Add(new SqlParameter("@BalanceTime", EntityBase.GetDatabaseValue(@balanceTime)));
			parameters.Add(new SqlParameter("@RemoveCost", EntityBase.GetDatabaseValue(@removeCost)));
			parameters.Add(new SqlParameter("@CarrierBalanceCost", EntityBase.GetDatabaseValue(@carrierBalanceCost)));
			parameters.Add(new SqlParameter("@CarrierChargeStatus", @carrierChargeStatus));
			parameters.Add(new SqlParameter("@CarrierBalanceTime", EntityBase.GetDatabaseValue(@carrierBalanceTime)));
			parameters.Add(new SqlParameter("@TotalCount", EntityBase.GetDatabaseValue(@totalCount)));
			parameters.Add(new SqlParameter("@CarrierMoveCost", EntityBase.GetDatabaseValue(@carrierMoveCost)));
			parameters.Add(new SqlParameter("@IsToNext", @isToNext));
			parameters.Add(new SqlParameter("@IsNextOrder", @isNextOrder));
			parameters.Add(new SqlParameter("@LastPrintTime", EntityBase.GetDatabaseValue(@lastPrintTime)));
			parameters.Add(new SqlParameter("@PrintCount", EntityBase.GetDatabaseValue(@printCount)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a WarehouseInOut into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="businessID">businessID</param>
		/// <param name="inventoryInfoID">inventoryInfoID</param>
		/// <param name="productID">productID</param>
		/// <param name="specInfoID">specInfoID</param>
		/// <param name="count">count</param>
		/// <param name="coldCost">coldCost</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="carrierID">carrierID</param>
		/// <param name="moveCost">moveCost</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="inOutType">inOutType</param>
		/// <param name="outTime">outTime</param>
		/// <param name="relateID">relateID</param>
		/// <param name="addMan">addMan</param>
		/// <param name="remark">remark</param>
		/// <param name="realCost">realCost</param>
		/// <param name="discountCost">discountCost</param>
		/// <param name="businessChargeStatus">businessChargeStatus</param>
		/// <param name="printID">printID</param>
		/// <param name="balanceTime">balanceTime</param>
		/// <param name="removeCost">removeCost</param>
		/// <param name="carrierBalanceCost">carrierBalanceCost</param>
		/// <param name="carrierChargeStatus">carrierChargeStatus</param>
		/// <param name="carrierBalanceTime">carrierBalanceTime</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="carrierMoveCost">carrierMoveCost</param>
		/// <param name="isToNext">isToNext</param>
		/// <param name="isNextOrder">isNextOrder</param>
		/// <param name="lastPrintTime">lastPrintTime</param>
		/// <param name="printCount">printCount</param>
		public static void UpdateWarehouseInOut(int @iD, int @businessID, int @inventoryInfoID, int @productID, int @specInfoID, int @count, decimal @coldCost, DateTime @startTime, DateTime @endTime, int @carrierID, decimal @moveCost, decimal @totalCost, DateTime @addTime, string @orderNumber, int @inOutType, DateTime @outTime, int @relateID, string @addMan, string @remark, decimal @realCost, decimal @discountCost, bool @businessChargeStatus, int @printID, DateTime @balanceTime, decimal @removeCost, decimal @carrierBalanceCost, bool @carrierChargeStatus, DateTime @carrierBalanceTime, int @totalCount, decimal @carrierMoveCost, bool @isToNext, bool @isNextOrder, DateTime @lastPrintTime, int @printCount)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWarehouseInOut(@iD, @businessID, @inventoryInfoID, @productID, @specInfoID, @count, @coldCost, @startTime, @endTime, @carrierID, @moveCost, @totalCost, @addTime, @orderNumber, @inOutType, @outTime, @relateID, @addMan, @remark, @realCost, @discountCost, @businessChargeStatus, @printID, @balanceTime, @removeCost, @carrierBalanceCost, @carrierChargeStatus, @carrierBalanceTime, @totalCount, @carrierMoveCost, @isToNext, @isNextOrder, @lastPrintTime, @printCount, helper);
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
		/// Updates a WarehouseInOut into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="businessID">businessID</param>
		/// <param name="inventoryInfoID">inventoryInfoID</param>
		/// <param name="productID">productID</param>
		/// <param name="specInfoID">specInfoID</param>
		/// <param name="count">count</param>
		/// <param name="coldCost">coldCost</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="carrierID">carrierID</param>
		/// <param name="moveCost">moveCost</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="inOutType">inOutType</param>
		/// <param name="outTime">outTime</param>
		/// <param name="relateID">relateID</param>
		/// <param name="addMan">addMan</param>
		/// <param name="remark">remark</param>
		/// <param name="realCost">realCost</param>
		/// <param name="discountCost">discountCost</param>
		/// <param name="businessChargeStatus">businessChargeStatus</param>
		/// <param name="printID">printID</param>
		/// <param name="balanceTime">balanceTime</param>
		/// <param name="removeCost">removeCost</param>
		/// <param name="carrierBalanceCost">carrierBalanceCost</param>
		/// <param name="carrierChargeStatus">carrierChargeStatus</param>
		/// <param name="carrierBalanceTime">carrierBalanceTime</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="carrierMoveCost">carrierMoveCost</param>
		/// <param name="isToNext">isToNext</param>
		/// <param name="isNextOrder">isNextOrder</param>
		/// <param name="lastPrintTime">lastPrintTime</param>
		/// <param name="printCount">printCount</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWarehouseInOut(int @iD, int @businessID, int @inventoryInfoID, int @productID, int @specInfoID, int @count, decimal @coldCost, DateTime @startTime, DateTime @endTime, int @carrierID, decimal @moveCost, decimal @totalCost, DateTime @addTime, string @orderNumber, int @inOutType, DateTime @outTime, int @relateID, string @addMan, string @remark, decimal @realCost, decimal @discountCost, bool @businessChargeStatus, int @printID, DateTime @balanceTime, decimal @removeCost, decimal @carrierBalanceCost, bool @carrierChargeStatus, DateTime @carrierBalanceTime, int @totalCount, decimal @carrierMoveCost, bool @isToNext, bool @isNextOrder, DateTime @lastPrintTime, int @printCount, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BusinessID] int,
	[InventoryInfoID] int,
	[ProductID] int,
	[SpecInfoID] int,
	[Count] int,
	[ColdCost] decimal(18, 2),
	[StartTime] datetime,
	[EndTime] datetime,
	[CarrierID] int,
	[MoveCost] decimal(18, 2),
	[TotalCost] decimal(18, 2),
	[AddTime] datetime,
	[OrderNumber] nvarchar(100),
	[InOutType] int,
	[OutTime] datetime,
	[RelateID] int,
	[AddMan] nvarchar(50),
	[Remark] ntext,
	[RealCost] decimal(18, 2),
	[DiscountCost] decimal(18, 2),
	[BusinessChargeStatus] bit,
	[PrintID] int,
	[BalanceTime] datetime,
	[RemoveCost] decimal(18, 2),
	[CarrierBalanceCost] decimal(18, 2),
	[CarrierChargeStatus] bit,
	[CarrierBalanceTime] datetime,
	[TotalCount] int,
	[CarrierMoveCost] decimal(18, 2),
	[IsToNext] bit,
	[IsNextOrder] bit,
	[LastPrintTime] datetime,
	[PrintCount] int
);

UPDATE [dbo].[WarehouseInOut] SET 
	[WarehouseInOut].[BusinessID] = @BusinessID,
	[WarehouseInOut].[InventoryInfoID] = @InventoryInfoID,
	[WarehouseInOut].[ProductID] = @ProductID,
	[WarehouseInOut].[SpecInfoID] = @SpecInfoID,
	[WarehouseInOut].[Count] = @Count,
	[WarehouseInOut].[ColdCost] = @ColdCost,
	[WarehouseInOut].[StartTime] = @StartTime,
	[WarehouseInOut].[EndTime] = @EndTime,
	[WarehouseInOut].[CarrierID] = @CarrierID,
	[WarehouseInOut].[MoveCost] = @MoveCost,
	[WarehouseInOut].[TotalCost] = @TotalCost,
	[WarehouseInOut].[AddTime] = @AddTime,
	[WarehouseInOut].[OrderNumber] = @OrderNumber,
	[WarehouseInOut].[InOutType] = @InOutType,
	[WarehouseInOut].[OutTime] = @OutTime,
	[WarehouseInOut].[RelateID] = @RelateID,
	[WarehouseInOut].[AddMan] = @AddMan,
	[WarehouseInOut].[Remark] = @Remark,
	[WarehouseInOut].[RealCost] = @RealCost,
	[WarehouseInOut].[DiscountCost] = @DiscountCost,
	[WarehouseInOut].[BusinessChargeStatus] = @BusinessChargeStatus,
	[WarehouseInOut].[PrintID] = @PrintID,
	[WarehouseInOut].[BalanceTime] = @BalanceTime,
	[WarehouseInOut].[RemoveCost] = @RemoveCost,
	[WarehouseInOut].[CarrierBalanceCost] = @CarrierBalanceCost,
	[WarehouseInOut].[CarrierChargeStatus] = @CarrierChargeStatus,
	[WarehouseInOut].[CarrierBalanceTime] = @CarrierBalanceTime,
	[WarehouseInOut].[TotalCount] = @TotalCount,
	[WarehouseInOut].[CarrierMoveCost] = @CarrierMoveCost,
	[WarehouseInOut].[IsToNext] = @IsToNext,
	[WarehouseInOut].[IsNextOrder] = @IsNextOrder,
	[WarehouseInOut].[LastPrintTime] = @LastPrintTime,
	[WarehouseInOut].[PrintCount] = @PrintCount 
output 
	INSERTED.[ID],
	INSERTED.[BusinessID],
	INSERTED.[InventoryInfoID],
	INSERTED.[ProductID],
	INSERTED.[SpecInfoID],
	INSERTED.[Count],
	INSERTED.[ColdCost],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[CarrierID],
	INSERTED.[MoveCost],
	INSERTED.[TotalCost],
	INSERTED.[AddTime],
	INSERTED.[OrderNumber],
	INSERTED.[InOutType],
	INSERTED.[OutTime],
	INSERTED.[RelateID],
	INSERTED.[AddMan],
	INSERTED.[Remark],
	INSERTED.[RealCost],
	INSERTED.[DiscountCost],
	INSERTED.[BusinessChargeStatus],
	INSERTED.[PrintID],
	INSERTED.[BalanceTime],
	INSERTED.[RemoveCost],
	INSERTED.[CarrierBalanceCost],
	INSERTED.[CarrierChargeStatus],
	INSERTED.[CarrierBalanceTime],
	INSERTED.[TotalCount],
	INSERTED.[CarrierMoveCost],
	INSERTED.[IsToNext],
	INSERTED.[IsNextOrder],
	INSERTED.[LastPrintTime],
	INSERTED.[PrintCount]
into @table
WHERE 
	[WarehouseInOut].[ID] = @ID

SELECT 
	[ID],
	[BusinessID],
	[InventoryInfoID],
	[ProductID],
	[SpecInfoID],
	[Count],
	[ColdCost],
	[StartTime],
	[EndTime],
	[CarrierID],
	[MoveCost],
	[TotalCost],
	[AddTime],
	[OrderNumber],
	[InOutType],
	[OutTime],
	[RelateID],
	[AddMan],
	[Remark],
	[RealCost],
	[DiscountCost],
	[BusinessChargeStatus],
	[PrintID],
	[BalanceTime],
	[RemoveCost],
	[CarrierBalanceCost],
	[CarrierChargeStatus],
	[CarrierBalanceTime],
	[TotalCount],
	[CarrierMoveCost],
	[IsToNext],
	[IsNextOrder],
	[LastPrintTime],
	[PrintCount] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			parameters.Add(new SqlParameter("@InventoryInfoID", EntityBase.GetDatabaseValue(@inventoryInfoID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@SpecInfoID", EntityBase.GetDatabaseValue(@specInfoID)));
			parameters.Add(new SqlParameter("@Count", EntityBase.GetDatabaseValue(@count)));
			parameters.Add(new SqlParameter("@ColdCost", EntityBase.GetDatabaseValue(@coldCost)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@CarrierID", EntityBase.GetDatabaseValue(@carrierID)));
			parameters.Add(new SqlParameter("@MoveCost", EntityBase.GetDatabaseValue(@moveCost)));
			parameters.Add(new SqlParameter("@TotalCost", EntityBase.GetDatabaseValue(@totalCost)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@OrderNumber", EntityBase.GetDatabaseValue(@orderNumber)));
			parameters.Add(new SqlParameter("@InOutType", EntityBase.GetDatabaseValue(@inOutType)));
			parameters.Add(new SqlParameter("@OutTime", EntityBase.GetDatabaseValue(@outTime)));
			parameters.Add(new SqlParameter("@RelateID", EntityBase.GetDatabaseValue(@relateID)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@RealCost", EntityBase.GetDatabaseValue(@realCost)));
			parameters.Add(new SqlParameter("@DiscountCost", EntityBase.GetDatabaseValue(@discountCost)));
			parameters.Add(new SqlParameter("@BusinessChargeStatus", @businessChargeStatus));
			parameters.Add(new SqlParameter("@PrintID", EntityBase.GetDatabaseValue(@printID)));
			parameters.Add(new SqlParameter("@BalanceTime", EntityBase.GetDatabaseValue(@balanceTime)));
			parameters.Add(new SqlParameter("@RemoveCost", EntityBase.GetDatabaseValue(@removeCost)));
			parameters.Add(new SqlParameter("@CarrierBalanceCost", EntityBase.GetDatabaseValue(@carrierBalanceCost)));
			parameters.Add(new SqlParameter("@CarrierChargeStatus", @carrierChargeStatus));
			parameters.Add(new SqlParameter("@CarrierBalanceTime", EntityBase.GetDatabaseValue(@carrierBalanceTime)));
			parameters.Add(new SqlParameter("@TotalCount", EntityBase.GetDatabaseValue(@totalCount)));
			parameters.Add(new SqlParameter("@CarrierMoveCost", EntityBase.GetDatabaseValue(@carrierMoveCost)));
			parameters.Add(new SqlParameter("@IsToNext", @isToNext));
			parameters.Add(new SqlParameter("@IsNextOrder", @isNextOrder));
			parameters.Add(new SqlParameter("@LastPrintTime", EntityBase.GetDatabaseValue(@lastPrintTime)));
			parameters.Add(new SqlParameter("@PrintCount", EntityBase.GetDatabaseValue(@printCount)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a WarehouseInOut from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWarehouseInOut(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWarehouseInOut(@iD, helper);
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
		/// Deletes a WarehouseInOut from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWarehouseInOut(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[WarehouseInOut]
WHERE 
	[WarehouseInOut].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new WarehouseInOut object.
		/// </summary>
		/// <returns>The newly created WarehouseInOut object.</returns>
		public static WarehouseInOut CreateWarehouseInOut()
		{
			return InitializeNew<WarehouseInOut>();
		}
		
		/// <summary>
		/// Retrieve information for a WarehouseInOut by a WarehouseInOut's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>WarehouseInOut</returns>
		public static WarehouseInOut GetWarehouseInOut(int @iD)
		{
			string commandText = @"
SELECT 
" + WarehouseInOut.SelectFieldList + @"
FROM [dbo].[WarehouseInOut] 
WHERE 
	[WarehouseInOut].[ID] = @ID " + WarehouseInOut.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<WarehouseInOut>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a WarehouseInOut by a WarehouseInOut's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>WarehouseInOut</returns>
		public static WarehouseInOut GetWarehouseInOut(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + WarehouseInOut.SelectFieldList + @"
FROM [dbo].[WarehouseInOut] 
WHERE 
	[WarehouseInOut].[ID] = @ID " + WarehouseInOut.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<WarehouseInOut>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection WarehouseInOut objects.
		/// </summary>
		/// <returns>The retrieved collection of WarehouseInOut objects.</returns>
		public static EntityList<WarehouseInOut> GetWarehouseInOuts()
		{
			string commandText = @"
SELECT " + WarehouseInOut.SelectFieldList + "FROM [dbo].[WarehouseInOut] " + WarehouseInOut.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<WarehouseInOut>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection WarehouseInOut objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of WarehouseInOut objects.</returns>
        public static EntityList<WarehouseInOut> GetWarehouseInOuts(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<WarehouseInOut>(SelectFieldList, "FROM [dbo].[WarehouseInOut]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection WarehouseInOut objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of WarehouseInOut objects.</returns>
        public static EntityList<WarehouseInOut> GetWarehouseInOuts(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<WarehouseInOut>(SelectFieldList, "FROM [dbo].[WarehouseInOut]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection WarehouseInOut objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of WarehouseInOut objects.</returns>
		protected static EntityList<WarehouseInOut> GetWarehouseInOuts(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWarehouseInOuts(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection WarehouseInOut objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of WarehouseInOut objects.</returns>
		protected static EntityList<WarehouseInOut> GetWarehouseInOuts(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWarehouseInOuts(string.Empty, where, parameters, WarehouseInOut.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection WarehouseInOut objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of WarehouseInOut objects.</returns>
		protected static EntityList<WarehouseInOut> GetWarehouseInOuts(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWarehouseInOuts(prefix, where, parameters, WarehouseInOut.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection WarehouseInOut objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of WarehouseInOut objects.</returns>
		protected static EntityList<WarehouseInOut> GetWarehouseInOuts(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWarehouseInOuts(string.Empty, where, parameters, WarehouseInOut.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection WarehouseInOut objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of WarehouseInOut objects.</returns>
		protected static EntityList<WarehouseInOut> GetWarehouseInOuts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWarehouseInOuts(prefix, where, parameters, WarehouseInOut.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection WarehouseInOut objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of WarehouseInOut objects.</returns>
		protected static EntityList<WarehouseInOut> GetWarehouseInOuts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + WarehouseInOut.SelectFieldList + "FROM [dbo].[WarehouseInOut] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<WarehouseInOut>(reader);
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
        protected static EntityList<WarehouseInOut> GetWarehouseInOuts(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<WarehouseInOut>(SelectFieldList, "FROM [dbo].[WarehouseInOut] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class WarehouseInOutProperties
		{
			public const string ID = "ID";
			public const string BusinessID = "BusinessID";
			public const string InventoryInfoID = "InventoryInfoID";
			public const string ProductID = "ProductID";
			public const string SpecInfoID = "SpecInfoID";
			public const string Count = "Count";
			public const string ColdCost = "ColdCost";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string CarrierID = "CarrierID";
			public const string MoveCost = "MoveCost";
			public const string TotalCost = "TotalCost";
			public const string AddTime = "AddTime";
			public const string OrderNumber = "OrderNumber";
			public const string InOutType = "InOutType";
			public const string OutTime = "OutTime";
			public const string RelateID = "RelateID";
			public const string AddMan = "AddMan";
			public const string Remark = "Remark";
			public const string RealCost = "RealCost";
			public const string DiscountCost = "DiscountCost";
			public const string BusinessChargeStatus = "BusinessChargeStatus";
			public const string PrintID = "PrintID";
			public const string BalanceTime = "BalanceTime";
			public const string RemoveCost = "RemoveCost";
			public const string CarrierBalanceCost = "CarrierBalanceCost";
			public const string CarrierChargeStatus = "CarrierChargeStatus";
			public const string CarrierBalanceTime = "CarrierBalanceTime";
			public const string TotalCount = "TotalCount";
			public const string CarrierMoveCost = "CarrierMoveCost";
			public const string IsToNext = "IsToNext";
			public const string IsNextOrder = "IsNextOrder";
			public const string LastPrintTime = "LastPrintTime";
			public const string PrintCount = "PrintCount";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"BusinessID" , "int:"},
    			 {"InventoryInfoID" , "int:"},
    			 {"ProductID" , "int:"},
    			 {"SpecInfoID" , "int:"},
    			 {"Count" , "int:"},
    			 {"ColdCost" , "decimal:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"CarrierID" , "int:"},
    			 {"MoveCost" , "decimal:"},
    			 {"TotalCost" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"OrderNumber" , "string:"},
    			 {"InOutType" , "int:"},
    			 {"OutTime" , "DateTime:"},
    			 {"RelateID" , "int:"},
    			 {"AddMan" , "string:"},
    			 {"Remark" , "string:"},
    			 {"RealCost" , "decimal:"},
    			 {"DiscountCost" , "decimal:"},
    			 {"BusinessChargeStatus" , "bool:"},
    			 {"PrintID" , "int:"},
    			 {"BalanceTime" , "DateTime:"},
    			 {"RemoveCost" , "decimal:"},
    			 {"CarrierBalanceCost" , "decimal:"},
    			 {"CarrierChargeStatus" , "bool:"},
    			 {"CarrierBalanceTime" , "DateTime:"},
    			 {"TotalCount" , "int:"},
    			 {"CarrierMoveCost" , "decimal:"},
    			 {"IsToNext" , "bool:"},
    			 {"IsNextOrder" , "bool:"},
    			 {"LastPrintTime" , "DateTime:"},
    			 {"PrintCount" , "int:"},
            };
		}
		#endregion
	}
}
