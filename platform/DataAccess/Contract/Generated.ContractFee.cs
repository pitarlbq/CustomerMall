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
	/// This object represents the properties and methods of a ContractFee.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ContractFee 
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
		private decimal _useCount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private bool _isStart = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		[DataObjectField(false, false, false)]
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
	[UseCount] decimal(18, 2),
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
	[UnitPrice] decimal(18, 3),
	[RealCost] decimal(18, 2),
	[Discount] decimal(18, 2),
	[OutDays] int,
	[ChargeFee] decimal(18, 2),
	[TotalRealCost] decimal(18, 2),
	[RestCost] decimal(18, 2),
	[TotalDiscountCost] decimal(18, 2),
	[OnlyOnceCharge] bit,
	[NewEndTime] datetime,
	[ContractID] int,
	[DiscountID] int
);

INSERT INTO [dbo].[ContractFee] (
	[ContractFee].[RoomID],
	[ContractFee].[UseCount],
	[ContractFee].[StartTime],
	[ContractFee].[EndTime],
	[ContractFee].[Cost],
	[ContractFee].[Remark],
	[ContractFee].[AddTime],
	[ContractFee].[IsCharged],
	[ContractFee].[ChargeFeeID],
	[ContractFee].[ChargeID],
	[ContractFee].[IsStart],
	[ContractFee].[NewStartTime],
	[ContractFee].[ImportFeeID],
	[ContractFee].[UnitPrice],
	[ContractFee].[RealCost],
	[ContractFee].[Discount],
	[ContractFee].[OutDays],
	[ContractFee].[ChargeFee],
	[ContractFee].[TotalRealCost],
	[ContractFee].[RestCost],
	[ContractFee].[TotalDiscountCost],
	[ContractFee].[OnlyOnceCharge],
	[ContractFee].[NewEndTime],
	[ContractFee].[ContractID],
	[ContractFee].[DiscountID]
) 
output 
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
	INSERTED.[ContractID],
	INSERTED.[DiscountID]
into @table
VALUES ( 
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
	@ContractID,
	@DiscountID 
); 

SELECT 
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
	[ContractID],
	[DiscountID] 
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
	[UseCount] decimal(18, 2),
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
	[UnitPrice] decimal(18, 3),
	[RealCost] decimal(18, 2),
	[Discount] decimal(18, 2),
	[OutDays] int,
	[ChargeFee] decimal(18, 2),
	[TotalRealCost] decimal(18, 2),
	[RestCost] decimal(18, 2),
	[TotalDiscountCost] decimal(18, 2),
	[OnlyOnceCharge] bit,
	[NewEndTime] datetime,
	[ContractID] int,
	[DiscountID] int
);

UPDATE [dbo].[ContractFee] SET 
	[ContractFee].[RoomID] = @RoomID,
	[ContractFee].[UseCount] = @UseCount,
	[ContractFee].[StartTime] = @StartTime,
	[ContractFee].[EndTime] = @EndTime,
	[ContractFee].[Cost] = @Cost,
	[ContractFee].[Remark] = @Remark,
	[ContractFee].[AddTime] = @AddTime,
	[ContractFee].[IsCharged] = @IsCharged,
	[ContractFee].[ChargeFeeID] = @ChargeFeeID,
	[ContractFee].[ChargeID] = @ChargeID,
	[ContractFee].[IsStart] = @IsStart,
	[ContractFee].[NewStartTime] = @NewStartTime,
	[ContractFee].[ImportFeeID] = @ImportFeeID,
	[ContractFee].[UnitPrice] = @UnitPrice,
	[ContractFee].[RealCost] = @RealCost,
	[ContractFee].[Discount] = @Discount,
	[ContractFee].[OutDays] = @OutDays,
	[ContractFee].[ChargeFee] = @ChargeFee,
	[ContractFee].[TotalRealCost] = @TotalRealCost,
	[ContractFee].[RestCost] = @RestCost,
	[ContractFee].[TotalDiscountCost] = @TotalDiscountCost,
	[ContractFee].[OnlyOnceCharge] = @OnlyOnceCharge,
	[ContractFee].[NewEndTime] = @NewEndTime,
	[ContractFee].[ContractID] = @ContractID,
	[ContractFee].[DiscountID] = @DiscountID 
output 
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
	INSERTED.[ContractID],
	INSERTED.[DiscountID]
into @table
WHERE 
	[ContractFee].[ID] = @ID

SELECT 
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
	[ContractID],
	[DiscountID] 
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
DELETE FROM [dbo].[ContractFee]
WHERE 
	[ContractFee].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ContractFee() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetContractFee(this.ID));
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
	[ContractFee].[ID],
	[ContractFee].[RoomID],
	[ContractFee].[UseCount],
	[ContractFee].[StartTime],
	[ContractFee].[EndTime],
	[ContractFee].[Cost],
	[ContractFee].[Remark],
	[ContractFee].[AddTime],
	[ContractFee].[IsCharged],
	[ContractFee].[ChargeFeeID],
	[ContractFee].[ChargeID],
	[ContractFee].[IsStart],
	[ContractFee].[NewStartTime],
	[ContractFee].[ImportFeeID],
	[ContractFee].[UnitPrice],
	[ContractFee].[RealCost],
	[ContractFee].[Discount],
	[ContractFee].[OutDays],
	[ContractFee].[ChargeFee],
	[ContractFee].[TotalRealCost],
	[ContractFee].[RestCost],
	[ContractFee].[TotalDiscountCost],
	[ContractFee].[OnlyOnceCharge],
	[ContractFee].[NewEndTime],
	[ContractFee].[ContractID],
	[ContractFee].[DiscountID]
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
                return "ContractFee";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ContractFee into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
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
		/// <param name="contractID">contractID</param>
		/// <param name="discountID">discountID</param>
		public static void InsertContractFee(int @roomID, decimal @useCount, DateTime @startTime, DateTime @endTime, decimal @cost, string @remark, DateTime @addTime, bool @isCharged, int @chargeFeeID, int @chargeID, bool @isStart, DateTime @newStartTime, int @importFeeID, decimal @unitPrice, decimal @realCost, decimal @discount, int @outDays, decimal @chargeFee, decimal @totalRealCost, decimal @restCost, decimal @totalDiscountCost, bool @onlyOnceCharge, DateTime @newEndTime, int @contractID, int @discountID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertContractFee(@roomID, @useCount, @startTime, @endTime, @cost, @remark, @addTime, @isCharged, @chargeFeeID, @chargeID, @isStart, @newStartTime, @importFeeID, @unitPrice, @realCost, @discount, @outDays, @chargeFee, @totalRealCost, @restCost, @totalDiscountCost, @onlyOnceCharge, @newEndTime, @contractID, @discountID, helper);
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
		/// Insert a ContractFee into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
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
		/// <param name="contractID">contractID</param>
		/// <param name="discountID">discountID</param>
		/// <param name="helper">helper</param>
		internal static void InsertContractFee(int @roomID, decimal @useCount, DateTime @startTime, DateTime @endTime, decimal @cost, string @remark, DateTime @addTime, bool @isCharged, int @chargeFeeID, int @chargeID, bool @isStart, DateTime @newStartTime, int @importFeeID, decimal @unitPrice, decimal @realCost, decimal @discount, int @outDays, decimal @chargeFee, decimal @totalRealCost, decimal @restCost, decimal @totalDiscountCost, bool @onlyOnceCharge, DateTime @newEndTime, int @contractID, int @discountID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[UseCount] decimal(18, 2),
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
	[UnitPrice] decimal(18, 3),
	[RealCost] decimal(18, 2),
	[Discount] decimal(18, 2),
	[OutDays] int,
	[ChargeFee] decimal(18, 2),
	[TotalRealCost] decimal(18, 2),
	[RestCost] decimal(18, 2),
	[TotalDiscountCost] decimal(18, 2),
	[OnlyOnceCharge] bit,
	[NewEndTime] datetime,
	[ContractID] int,
	[DiscountID] int
);

INSERT INTO [dbo].[ContractFee] (
	[ContractFee].[RoomID],
	[ContractFee].[UseCount],
	[ContractFee].[StartTime],
	[ContractFee].[EndTime],
	[ContractFee].[Cost],
	[ContractFee].[Remark],
	[ContractFee].[AddTime],
	[ContractFee].[IsCharged],
	[ContractFee].[ChargeFeeID],
	[ContractFee].[ChargeID],
	[ContractFee].[IsStart],
	[ContractFee].[NewStartTime],
	[ContractFee].[ImportFeeID],
	[ContractFee].[UnitPrice],
	[ContractFee].[RealCost],
	[ContractFee].[Discount],
	[ContractFee].[OutDays],
	[ContractFee].[ChargeFee],
	[ContractFee].[TotalRealCost],
	[ContractFee].[RestCost],
	[ContractFee].[TotalDiscountCost],
	[ContractFee].[OnlyOnceCharge],
	[ContractFee].[NewEndTime],
	[ContractFee].[ContractID],
	[ContractFee].[DiscountID]
) 
output 
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
	INSERTED.[ContractID],
	INSERTED.[DiscountID]
into @table
VALUES ( 
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
	@ContractID,
	@DiscountID 
); 

SELECT 
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
	[ContractID],
	[DiscountID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
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
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@DiscountID", EntityBase.GetDatabaseValue(@discountID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ContractFee into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
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
		/// <param name="contractID">contractID</param>
		/// <param name="discountID">discountID</param>
		public static void UpdateContractFee(int @iD, int @roomID, decimal @useCount, DateTime @startTime, DateTime @endTime, decimal @cost, string @remark, DateTime @addTime, bool @isCharged, int @chargeFeeID, int @chargeID, bool @isStart, DateTime @newStartTime, int @importFeeID, decimal @unitPrice, decimal @realCost, decimal @discount, int @outDays, decimal @chargeFee, decimal @totalRealCost, decimal @restCost, decimal @totalDiscountCost, bool @onlyOnceCharge, DateTime @newEndTime, int @contractID, int @discountID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateContractFee(@iD, @roomID, @useCount, @startTime, @endTime, @cost, @remark, @addTime, @isCharged, @chargeFeeID, @chargeID, @isStart, @newStartTime, @importFeeID, @unitPrice, @realCost, @discount, @outDays, @chargeFee, @totalRealCost, @restCost, @totalDiscountCost, @onlyOnceCharge, @newEndTime, @contractID, @discountID, helper);
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
		/// Updates a ContractFee into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
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
		/// <param name="contractID">contractID</param>
		/// <param name="discountID">discountID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateContractFee(int @iD, int @roomID, decimal @useCount, DateTime @startTime, DateTime @endTime, decimal @cost, string @remark, DateTime @addTime, bool @isCharged, int @chargeFeeID, int @chargeID, bool @isStart, DateTime @newStartTime, int @importFeeID, decimal @unitPrice, decimal @realCost, decimal @discount, int @outDays, decimal @chargeFee, decimal @totalRealCost, decimal @restCost, decimal @totalDiscountCost, bool @onlyOnceCharge, DateTime @newEndTime, int @contractID, int @discountID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[UseCount] decimal(18, 2),
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
	[UnitPrice] decimal(18, 3),
	[RealCost] decimal(18, 2),
	[Discount] decimal(18, 2),
	[OutDays] int,
	[ChargeFee] decimal(18, 2),
	[TotalRealCost] decimal(18, 2),
	[RestCost] decimal(18, 2),
	[TotalDiscountCost] decimal(18, 2),
	[OnlyOnceCharge] bit,
	[NewEndTime] datetime,
	[ContractID] int,
	[DiscountID] int
);

UPDATE [dbo].[ContractFee] SET 
	[ContractFee].[RoomID] = @RoomID,
	[ContractFee].[UseCount] = @UseCount,
	[ContractFee].[StartTime] = @StartTime,
	[ContractFee].[EndTime] = @EndTime,
	[ContractFee].[Cost] = @Cost,
	[ContractFee].[Remark] = @Remark,
	[ContractFee].[AddTime] = @AddTime,
	[ContractFee].[IsCharged] = @IsCharged,
	[ContractFee].[ChargeFeeID] = @ChargeFeeID,
	[ContractFee].[ChargeID] = @ChargeID,
	[ContractFee].[IsStart] = @IsStart,
	[ContractFee].[NewStartTime] = @NewStartTime,
	[ContractFee].[ImportFeeID] = @ImportFeeID,
	[ContractFee].[UnitPrice] = @UnitPrice,
	[ContractFee].[RealCost] = @RealCost,
	[ContractFee].[Discount] = @Discount,
	[ContractFee].[OutDays] = @OutDays,
	[ContractFee].[ChargeFee] = @ChargeFee,
	[ContractFee].[TotalRealCost] = @TotalRealCost,
	[ContractFee].[RestCost] = @RestCost,
	[ContractFee].[TotalDiscountCost] = @TotalDiscountCost,
	[ContractFee].[OnlyOnceCharge] = @OnlyOnceCharge,
	[ContractFee].[NewEndTime] = @NewEndTime,
	[ContractFee].[ContractID] = @ContractID,
	[ContractFee].[DiscountID] = @DiscountID 
output 
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
	INSERTED.[ContractID],
	INSERTED.[DiscountID]
into @table
WHERE 
	[ContractFee].[ID] = @ID

SELECT 
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
	[ContractID],
	[DiscountID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
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
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@DiscountID", EntityBase.GetDatabaseValue(@discountID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ContractFee from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteContractFee(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteContractFee(@iD, helper);
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
		/// Deletes a ContractFee from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteContractFee(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ContractFee]
WHERE 
	[ContractFee].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ContractFee object.
		/// </summary>
		/// <returns>The newly created ContractFee object.</returns>
		public static ContractFee CreateContractFee()
		{
			return InitializeNew<ContractFee>();
		}
		
		/// <summary>
		/// Retrieve information for a ContractFee by a ContractFee's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ContractFee</returns>
		public static ContractFee GetContractFee(int @iD)
		{
			string commandText = @"
SELECT 
" + ContractFee.SelectFieldList + @"
FROM [dbo].[ContractFee] 
WHERE 
	[ContractFee].[ID] = @ID " + ContractFee.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ContractFee>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ContractFee by a ContractFee's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ContractFee</returns>
		public static ContractFee GetContractFee(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ContractFee.SelectFieldList + @"
FROM [dbo].[ContractFee] 
WHERE 
	[ContractFee].[ID] = @ID " + ContractFee.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ContractFee>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ContractFee objects.
		/// </summary>
		/// <returns>The retrieved collection of ContractFee objects.</returns>
		public static EntityList<ContractFee> GetContractFees()
		{
			string commandText = @"
SELECT " + ContractFee.SelectFieldList + "FROM [dbo].[ContractFee] " + ContractFee.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ContractFee>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ContractFee objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ContractFee objects.</returns>
        public static EntityList<ContractFee> GetContractFees(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ContractFee>(SelectFieldList, "FROM [dbo].[ContractFee]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ContractFee objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ContractFee objects.</returns>
        public static EntityList<ContractFee> GetContractFees(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ContractFee>(SelectFieldList, "FROM [dbo].[ContractFee]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ContractFee objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ContractFee objects.</returns>
		protected static EntityList<ContractFee> GetContractFees(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContractFees(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ContractFee objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ContractFee objects.</returns>
		protected static EntityList<ContractFee> GetContractFees(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContractFees(string.Empty, where, parameters, ContractFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ContractFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ContractFee objects.</returns>
		protected static EntityList<ContractFee> GetContractFees(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContractFees(prefix, where, parameters, ContractFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ContractFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ContractFee objects.</returns>
		protected static EntityList<ContractFee> GetContractFees(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContractFees(string.Empty, where, parameters, ContractFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ContractFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ContractFee objects.</returns>
		protected static EntityList<ContractFee> GetContractFees(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContractFees(prefix, where, parameters, ContractFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ContractFee objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ContractFee objects.</returns>
		protected static EntityList<ContractFee> GetContractFees(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ContractFee.SelectFieldList + "FROM [dbo].[ContractFee] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ContractFee>(reader);
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
        protected static EntityList<ContractFee> GetContractFees(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ContractFee>(SelectFieldList, "FROM [dbo].[ContractFee] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ContractFee objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContractFeeCount()
        {
            return GetContractFeeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ContractFee objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContractFeeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ContractFee] " + where;

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
		public static partial class ContractFee_Properties
		{
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
			public const string ContractID = "ContractID";
			public const string DiscountID = "DiscountID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
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
    			 {"ContractID" , "int:"},
    			 {"DiscountID" , "int:"},
            };
		}
		#endregion
	}
}
