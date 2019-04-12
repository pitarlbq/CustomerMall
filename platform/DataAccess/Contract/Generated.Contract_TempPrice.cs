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
	/// This object represents the properties and methods of a Contract_TempPrice.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Contract_TempPrice 
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _basicStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime BasicStartTime
		{
			[DebuggerStepThrough()]
			get { return this._basicStartTime; }
			set 
			{
				if (this._basicStartTime != value) 
				{
					this._basicStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("BasicStartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _basicEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime BasicEndTime
		{
			[DebuggerStepThrough()]
			get { return this._basicEndTime; }
			set 
			{
				if (this._basicEndTime != value) 
				{
					this._basicEndTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("BasicEndTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _calculateType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CalculateType
		{
			[DebuggerStepThrough()]
			get { return this._calculateType; }
			set 
			{
				if (this._calculateType != value) 
				{
					this._calculateType = value;
					this.IsDirty = true;	
					OnPropertyChanged("CalculateType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _calculatePercent = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal CalculatePercent
		{
			[DebuggerStepThrough()]
			get { return this._calculatePercent; }
			set 
			{
				if (this._calculatePercent != value) 
				{
					this._calculatePercent = value;
					this.IsDirty = true;	
					OnPropertyChanged("CalculatePercent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _calculateAmount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal CalculateAmount
		{
			[DebuggerStepThrough()]
			get { return this._calculateAmount; }
			set 
			{
				if (this._calculateAmount != value) 
				{
					this._calculateAmount = value;
					this.IsDirty = true;	
					OnPropertyChanged("CalculateAmount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _calculatePrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal CalculatePrice
		{
			[DebuggerStepThrough()]
			get { return this._calculatePrice; }
			set 
			{
				if (this._calculatePrice != value) 
				{
					this._calculatePrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("CalculatePrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _calculateStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime CalculateStartTime
		{
			[DebuggerStepThrough()]
			get { return this._calculateStartTime; }
			set 
			{
				if (this._calculateStartTime != value) 
				{
					this._calculateStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("CalculateStartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _calculateEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime CalculateEndTime
		{
			[DebuggerStepThrough()]
			get { return this._calculateEndTime; }
			set 
			{
				if (this._calculateEndTime != value) 
				{
					this._calculateEndTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("CalculateEndTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _gUID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string GUID
		{
			[DebuggerStepThrough()]
			get { return this._gUID; }
			set 
			{
				if (this._gUID != value) 
				{
					this._gUID = value;
					this.IsDirty = true;	
					OnPropertyChanged("GUID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _calculateCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal CalculateCost
		{
			[DebuggerStepThrough()]
			get { return this._calculateCost; }
			set 
			{
				if (this._calculateCost != value) 
				{
					this._calculateCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("CalculateCost");
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
		private DateTime _readyChargeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ReadyChargeTime
		{
			[DebuggerStepThrough()]
			get { return this._readyChargeTime; }
			set 
			{
				if (this._readyChargeTime != value) 
				{
					this._readyChargeTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ReadyChargeTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _roomUseCount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RoomUseCount
		{
			[DebuggerStepThrough()]
			get { return this._roomUseCount; }
			set 
			{
				if (this._roomUseCount != value) 
				{
					this._roomUseCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomUseCount");
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
	[BasicPrice] decimal(18, 4),
	[BasicStartTime] datetime,
	[BasicEndTime] datetime,
	[CalculateType] nvarchar(50),
	[CalculatePercent] decimal(18, 4),
	[CalculateAmount] decimal(18, 2),
	[CalculatePrice] decimal(18, 4),
	[CalculateStartTime] datetime,
	[CalculateEndTime] datetime,
	[GUID] nvarchar(500),
	[CalculateCost] decimal(18, 2),
	[AddTime] datetime,
	[ReadyChargeTime] datetime,
	[RoomUseCount] decimal(18, 2),
	[ChargeID] int,
	[RoomID] int
);

INSERT INTO [dbo].[Contract_TempPrice] (
	[Contract_TempPrice].[BasicPrice],
	[Contract_TempPrice].[BasicStartTime],
	[Contract_TempPrice].[BasicEndTime],
	[Contract_TempPrice].[CalculateType],
	[Contract_TempPrice].[CalculatePercent],
	[Contract_TempPrice].[CalculateAmount],
	[Contract_TempPrice].[CalculatePrice],
	[Contract_TempPrice].[CalculateStartTime],
	[Contract_TempPrice].[CalculateEndTime],
	[Contract_TempPrice].[GUID],
	[Contract_TempPrice].[CalculateCost],
	[Contract_TempPrice].[AddTime],
	[Contract_TempPrice].[ReadyChargeTime],
	[Contract_TempPrice].[RoomUseCount],
	[Contract_TempPrice].[ChargeID],
	[Contract_TempPrice].[RoomID]
) 
output 
	INSERTED.[ID],
	INSERTED.[BasicPrice],
	INSERTED.[BasicStartTime],
	INSERTED.[BasicEndTime],
	INSERTED.[CalculateType],
	INSERTED.[CalculatePercent],
	INSERTED.[CalculateAmount],
	INSERTED.[CalculatePrice],
	INSERTED.[CalculateStartTime],
	INSERTED.[CalculateEndTime],
	INSERTED.[GUID],
	INSERTED.[CalculateCost],
	INSERTED.[AddTime],
	INSERTED.[ReadyChargeTime],
	INSERTED.[RoomUseCount],
	INSERTED.[ChargeID],
	INSERTED.[RoomID]
into @table
VALUES ( 
	@BasicPrice,
	@BasicStartTime,
	@BasicEndTime,
	@CalculateType,
	@CalculatePercent,
	@CalculateAmount,
	@CalculatePrice,
	@CalculateStartTime,
	@CalculateEndTime,
	@GUID,
	@CalculateCost,
	@AddTime,
	@ReadyChargeTime,
	@RoomUseCount,
	@ChargeID,
	@RoomID 
); 

SELECT 
	[ID],
	[BasicPrice],
	[BasicStartTime],
	[BasicEndTime],
	[CalculateType],
	[CalculatePercent],
	[CalculateAmount],
	[CalculatePrice],
	[CalculateStartTime],
	[CalculateEndTime],
	[GUID],
	[CalculateCost],
	[AddTime],
	[ReadyChargeTime],
	[RoomUseCount],
	[ChargeID],
	[RoomID] 
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
	[BasicPrice] decimal(18, 4),
	[BasicStartTime] datetime,
	[BasicEndTime] datetime,
	[CalculateType] nvarchar(50),
	[CalculatePercent] decimal(18, 4),
	[CalculateAmount] decimal(18, 2),
	[CalculatePrice] decimal(18, 4),
	[CalculateStartTime] datetime,
	[CalculateEndTime] datetime,
	[GUID] nvarchar(500),
	[CalculateCost] decimal(18, 2),
	[AddTime] datetime,
	[ReadyChargeTime] datetime,
	[RoomUseCount] decimal(18, 2),
	[ChargeID] int,
	[RoomID] int
);

UPDATE [dbo].[Contract_TempPrice] SET 
	[Contract_TempPrice].[BasicPrice] = @BasicPrice,
	[Contract_TempPrice].[BasicStartTime] = @BasicStartTime,
	[Contract_TempPrice].[BasicEndTime] = @BasicEndTime,
	[Contract_TempPrice].[CalculateType] = @CalculateType,
	[Contract_TempPrice].[CalculatePercent] = @CalculatePercent,
	[Contract_TempPrice].[CalculateAmount] = @CalculateAmount,
	[Contract_TempPrice].[CalculatePrice] = @CalculatePrice,
	[Contract_TempPrice].[CalculateStartTime] = @CalculateStartTime,
	[Contract_TempPrice].[CalculateEndTime] = @CalculateEndTime,
	[Contract_TempPrice].[GUID] = @GUID,
	[Contract_TempPrice].[CalculateCost] = @CalculateCost,
	[Contract_TempPrice].[AddTime] = @AddTime,
	[Contract_TempPrice].[ReadyChargeTime] = @ReadyChargeTime,
	[Contract_TempPrice].[RoomUseCount] = @RoomUseCount,
	[Contract_TempPrice].[ChargeID] = @ChargeID,
	[Contract_TempPrice].[RoomID] = @RoomID 
output 
	INSERTED.[ID],
	INSERTED.[BasicPrice],
	INSERTED.[BasicStartTime],
	INSERTED.[BasicEndTime],
	INSERTED.[CalculateType],
	INSERTED.[CalculatePercent],
	INSERTED.[CalculateAmount],
	INSERTED.[CalculatePrice],
	INSERTED.[CalculateStartTime],
	INSERTED.[CalculateEndTime],
	INSERTED.[GUID],
	INSERTED.[CalculateCost],
	INSERTED.[AddTime],
	INSERTED.[ReadyChargeTime],
	INSERTED.[RoomUseCount],
	INSERTED.[ChargeID],
	INSERTED.[RoomID]
into @table
WHERE 
	[Contract_TempPrice].[ID] = @ID

SELECT 
	[ID],
	[BasicPrice],
	[BasicStartTime],
	[BasicEndTime],
	[CalculateType],
	[CalculatePercent],
	[CalculateAmount],
	[CalculatePrice],
	[CalculateStartTime],
	[CalculateEndTime],
	[GUID],
	[CalculateCost],
	[AddTime],
	[ReadyChargeTime],
	[RoomUseCount],
	[ChargeID],
	[RoomID] 
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
DELETE FROM [dbo].[Contract_TempPrice]
WHERE 
	[Contract_TempPrice].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Contract_TempPrice() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetContract_TempPrice(this.ID));
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
	[Contract_TempPrice].[ID],
	[Contract_TempPrice].[BasicPrice],
	[Contract_TempPrice].[BasicStartTime],
	[Contract_TempPrice].[BasicEndTime],
	[Contract_TempPrice].[CalculateType],
	[Contract_TempPrice].[CalculatePercent],
	[Contract_TempPrice].[CalculateAmount],
	[Contract_TempPrice].[CalculatePrice],
	[Contract_TempPrice].[CalculateStartTime],
	[Contract_TempPrice].[CalculateEndTime],
	[Contract_TempPrice].[GUID],
	[Contract_TempPrice].[CalculateCost],
	[Contract_TempPrice].[AddTime],
	[Contract_TempPrice].[ReadyChargeTime],
	[Contract_TempPrice].[RoomUseCount],
	[Contract_TempPrice].[ChargeID],
	[Contract_TempPrice].[RoomID]
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
                return "Contract_TempPrice";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Contract_TempPrice into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="basicPrice">basicPrice</param>
		/// <param name="basicStartTime">basicStartTime</param>
		/// <param name="basicEndTime">basicEndTime</param>
		/// <param name="calculateType">calculateType</param>
		/// <param name="calculatePercent">calculatePercent</param>
		/// <param name="calculateAmount">calculateAmount</param>
		/// <param name="calculatePrice">calculatePrice</param>
		/// <param name="calculateStartTime">calculateStartTime</param>
		/// <param name="calculateEndTime">calculateEndTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="calculateCost">calculateCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="readyChargeTime">readyChargeTime</param>
		/// <param name="roomUseCount">roomUseCount</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="roomID">roomID</param>
		public static void InsertContract_TempPrice(decimal @basicPrice, DateTime @basicStartTime, DateTime @basicEndTime, string @calculateType, decimal @calculatePercent, decimal @calculateAmount, decimal @calculatePrice, DateTime @calculateStartTime, DateTime @calculateEndTime, string @gUID, decimal @calculateCost, DateTime @addTime, DateTime @readyChargeTime, decimal @roomUseCount, int @chargeID, int @roomID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertContract_TempPrice(@basicPrice, @basicStartTime, @basicEndTime, @calculateType, @calculatePercent, @calculateAmount, @calculatePrice, @calculateStartTime, @calculateEndTime, @gUID, @calculateCost, @addTime, @readyChargeTime, @roomUseCount, @chargeID, @roomID, helper);
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
		/// Insert a Contract_TempPrice into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="basicPrice">basicPrice</param>
		/// <param name="basicStartTime">basicStartTime</param>
		/// <param name="basicEndTime">basicEndTime</param>
		/// <param name="calculateType">calculateType</param>
		/// <param name="calculatePercent">calculatePercent</param>
		/// <param name="calculateAmount">calculateAmount</param>
		/// <param name="calculatePrice">calculatePrice</param>
		/// <param name="calculateStartTime">calculateStartTime</param>
		/// <param name="calculateEndTime">calculateEndTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="calculateCost">calculateCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="readyChargeTime">readyChargeTime</param>
		/// <param name="roomUseCount">roomUseCount</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="roomID">roomID</param>
		/// <param name="helper">helper</param>
		internal static void InsertContract_TempPrice(decimal @basicPrice, DateTime @basicStartTime, DateTime @basicEndTime, string @calculateType, decimal @calculatePercent, decimal @calculateAmount, decimal @calculatePrice, DateTime @calculateStartTime, DateTime @calculateEndTime, string @gUID, decimal @calculateCost, DateTime @addTime, DateTime @readyChargeTime, decimal @roomUseCount, int @chargeID, int @roomID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BasicPrice] decimal(18, 4),
	[BasicStartTime] datetime,
	[BasicEndTime] datetime,
	[CalculateType] nvarchar(50),
	[CalculatePercent] decimal(18, 4),
	[CalculateAmount] decimal(18, 2),
	[CalculatePrice] decimal(18, 4),
	[CalculateStartTime] datetime,
	[CalculateEndTime] datetime,
	[GUID] nvarchar(500),
	[CalculateCost] decimal(18, 2),
	[AddTime] datetime,
	[ReadyChargeTime] datetime,
	[RoomUseCount] decimal(18, 2),
	[ChargeID] int,
	[RoomID] int
);

INSERT INTO [dbo].[Contract_TempPrice] (
	[Contract_TempPrice].[BasicPrice],
	[Contract_TempPrice].[BasicStartTime],
	[Contract_TempPrice].[BasicEndTime],
	[Contract_TempPrice].[CalculateType],
	[Contract_TempPrice].[CalculatePercent],
	[Contract_TempPrice].[CalculateAmount],
	[Contract_TempPrice].[CalculatePrice],
	[Contract_TempPrice].[CalculateStartTime],
	[Contract_TempPrice].[CalculateEndTime],
	[Contract_TempPrice].[GUID],
	[Contract_TempPrice].[CalculateCost],
	[Contract_TempPrice].[AddTime],
	[Contract_TempPrice].[ReadyChargeTime],
	[Contract_TempPrice].[RoomUseCount],
	[Contract_TempPrice].[ChargeID],
	[Contract_TempPrice].[RoomID]
) 
output 
	INSERTED.[ID],
	INSERTED.[BasicPrice],
	INSERTED.[BasicStartTime],
	INSERTED.[BasicEndTime],
	INSERTED.[CalculateType],
	INSERTED.[CalculatePercent],
	INSERTED.[CalculateAmount],
	INSERTED.[CalculatePrice],
	INSERTED.[CalculateStartTime],
	INSERTED.[CalculateEndTime],
	INSERTED.[GUID],
	INSERTED.[CalculateCost],
	INSERTED.[AddTime],
	INSERTED.[ReadyChargeTime],
	INSERTED.[RoomUseCount],
	INSERTED.[ChargeID],
	INSERTED.[RoomID]
into @table
VALUES ( 
	@BasicPrice,
	@BasicStartTime,
	@BasicEndTime,
	@CalculateType,
	@CalculatePercent,
	@CalculateAmount,
	@CalculatePrice,
	@CalculateStartTime,
	@CalculateEndTime,
	@GUID,
	@CalculateCost,
	@AddTime,
	@ReadyChargeTime,
	@RoomUseCount,
	@ChargeID,
	@RoomID 
); 

SELECT 
	[ID],
	[BasicPrice],
	[BasicStartTime],
	[BasicEndTime],
	[CalculateType],
	[CalculatePercent],
	[CalculateAmount],
	[CalculatePrice],
	[CalculateStartTime],
	[CalculateEndTime],
	[GUID],
	[CalculateCost],
	[AddTime],
	[ReadyChargeTime],
	[RoomUseCount],
	[ChargeID],
	[RoomID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@BasicPrice", EntityBase.GetDatabaseValue(@basicPrice)));
			parameters.Add(new SqlParameter("@BasicStartTime", EntityBase.GetDatabaseValue(@basicStartTime)));
			parameters.Add(new SqlParameter("@BasicEndTime", EntityBase.GetDatabaseValue(@basicEndTime)));
			parameters.Add(new SqlParameter("@CalculateType", EntityBase.GetDatabaseValue(@calculateType)));
			parameters.Add(new SqlParameter("@CalculatePercent", EntityBase.GetDatabaseValue(@calculatePercent)));
			parameters.Add(new SqlParameter("@CalculateAmount", EntityBase.GetDatabaseValue(@calculateAmount)));
			parameters.Add(new SqlParameter("@CalculatePrice", EntityBase.GetDatabaseValue(@calculatePrice)));
			parameters.Add(new SqlParameter("@CalculateStartTime", EntityBase.GetDatabaseValue(@calculateStartTime)));
			parameters.Add(new SqlParameter("@CalculateEndTime", EntityBase.GetDatabaseValue(@calculateEndTime)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@CalculateCost", EntityBase.GetDatabaseValue(@calculateCost)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ReadyChargeTime", EntityBase.GetDatabaseValue(@readyChargeTime)));
			parameters.Add(new SqlParameter("@RoomUseCount", EntityBase.GetDatabaseValue(@roomUseCount)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Contract_TempPrice into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="basicPrice">basicPrice</param>
		/// <param name="basicStartTime">basicStartTime</param>
		/// <param name="basicEndTime">basicEndTime</param>
		/// <param name="calculateType">calculateType</param>
		/// <param name="calculatePercent">calculatePercent</param>
		/// <param name="calculateAmount">calculateAmount</param>
		/// <param name="calculatePrice">calculatePrice</param>
		/// <param name="calculateStartTime">calculateStartTime</param>
		/// <param name="calculateEndTime">calculateEndTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="calculateCost">calculateCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="readyChargeTime">readyChargeTime</param>
		/// <param name="roomUseCount">roomUseCount</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="roomID">roomID</param>
		public static void UpdateContract_TempPrice(int @iD, decimal @basicPrice, DateTime @basicStartTime, DateTime @basicEndTime, string @calculateType, decimal @calculatePercent, decimal @calculateAmount, decimal @calculatePrice, DateTime @calculateStartTime, DateTime @calculateEndTime, string @gUID, decimal @calculateCost, DateTime @addTime, DateTime @readyChargeTime, decimal @roomUseCount, int @chargeID, int @roomID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateContract_TempPrice(@iD, @basicPrice, @basicStartTime, @basicEndTime, @calculateType, @calculatePercent, @calculateAmount, @calculatePrice, @calculateStartTime, @calculateEndTime, @gUID, @calculateCost, @addTime, @readyChargeTime, @roomUseCount, @chargeID, @roomID, helper);
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
		/// Updates a Contract_TempPrice into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="basicPrice">basicPrice</param>
		/// <param name="basicStartTime">basicStartTime</param>
		/// <param name="basicEndTime">basicEndTime</param>
		/// <param name="calculateType">calculateType</param>
		/// <param name="calculatePercent">calculatePercent</param>
		/// <param name="calculateAmount">calculateAmount</param>
		/// <param name="calculatePrice">calculatePrice</param>
		/// <param name="calculateStartTime">calculateStartTime</param>
		/// <param name="calculateEndTime">calculateEndTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="calculateCost">calculateCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="readyChargeTime">readyChargeTime</param>
		/// <param name="roomUseCount">roomUseCount</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="roomID">roomID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateContract_TempPrice(int @iD, decimal @basicPrice, DateTime @basicStartTime, DateTime @basicEndTime, string @calculateType, decimal @calculatePercent, decimal @calculateAmount, decimal @calculatePrice, DateTime @calculateStartTime, DateTime @calculateEndTime, string @gUID, decimal @calculateCost, DateTime @addTime, DateTime @readyChargeTime, decimal @roomUseCount, int @chargeID, int @roomID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BasicPrice] decimal(18, 4),
	[BasicStartTime] datetime,
	[BasicEndTime] datetime,
	[CalculateType] nvarchar(50),
	[CalculatePercent] decimal(18, 4),
	[CalculateAmount] decimal(18, 2),
	[CalculatePrice] decimal(18, 4),
	[CalculateStartTime] datetime,
	[CalculateEndTime] datetime,
	[GUID] nvarchar(500),
	[CalculateCost] decimal(18, 2),
	[AddTime] datetime,
	[ReadyChargeTime] datetime,
	[RoomUseCount] decimal(18, 2),
	[ChargeID] int,
	[RoomID] int
);

UPDATE [dbo].[Contract_TempPrice] SET 
	[Contract_TempPrice].[BasicPrice] = @BasicPrice,
	[Contract_TempPrice].[BasicStartTime] = @BasicStartTime,
	[Contract_TempPrice].[BasicEndTime] = @BasicEndTime,
	[Contract_TempPrice].[CalculateType] = @CalculateType,
	[Contract_TempPrice].[CalculatePercent] = @CalculatePercent,
	[Contract_TempPrice].[CalculateAmount] = @CalculateAmount,
	[Contract_TempPrice].[CalculatePrice] = @CalculatePrice,
	[Contract_TempPrice].[CalculateStartTime] = @CalculateStartTime,
	[Contract_TempPrice].[CalculateEndTime] = @CalculateEndTime,
	[Contract_TempPrice].[GUID] = @GUID,
	[Contract_TempPrice].[CalculateCost] = @CalculateCost,
	[Contract_TempPrice].[AddTime] = @AddTime,
	[Contract_TempPrice].[ReadyChargeTime] = @ReadyChargeTime,
	[Contract_TempPrice].[RoomUseCount] = @RoomUseCount,
	[Contract_TempPrice].[ChargeID] = @ChargeID,
	[Contract_TempPrice].[RoomID] = @RoomID 
output 
	INSERTED.[ID],
	INSERTED.[BasicPrice],
	INSERTED.[BasicStartTime],
	INSERTED.[BasicEndTime],
	INSERTED.[CalculateType],
	INSERTED.[CalculatePercent],
	INSERTED.[CalculateAmount],
	INSERTED.[CalculatePrice],
	INSERTED.[CalculateStartTime],
	INSERTED.[CalculateEndTime],
	INSERTED.[GUID],
	INSERTED.[CalculateCost],
	INSERTED.[AddTime],
	INSERTED.[ReadyChargeTime],
	INSERTED.[RoomUseCount],
	INSERTED.[ChargeID],
	INSERTED.[RoomID]
into @table
WHERE 
	[Contract_TempPrice].[ID] = @ID

SELECT 
	[ID],
	[BasicPrice],
	[BasicStartTime],
	[BasicEndTime],
	[CalculateType],
	[CalculatePercent],
	[CalculateAmount],
	[CalculatePrice],
	[CalculateStartTime],
	[CalculateEndTime],
	[GUID],
	[CalculateCost],
	[AddTime],
	[ReadyChargeTime],
	[RoomUseCount],
	[ChargeID],
	[RoomID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@BasicPrice", EntityBase.GetDatabaseValue(@basicPrice)));
			parameters.Add(new SqlParameter("@BasicStartTime", EntityBase.GetDatabaseValue(@basicStartTime)));
			parameters.Add(new SqlParameter("@BasicEndTime", EntityBase.GetDatabaseValue(@basicEndTime)));
			parameters.Add(new SqlParameter("@CalculateType", EntityBase.GetDatabaseValue(@calculateType)));
			parameters.Add(new SqlParameter("@CalculatePercent", EntityBase.GetDatabaseValue(@calculatePercent)));
			parameters.Add(new SqlParameter("@CalculateAmount", EntityBase.GetDatabaseValue(@calculateAmount)));
			parameters.Add(new SqlParameter("@CalculatePrice", EntityBase.GetDatabaseValue(@calculatePrice)));
			parameters.Add(new SqlParameter("@CalculateStartTime", EntityBase.GetDatabaseValue(@calculateStartTime)));
			parameters.Add(new SqlParameter("@CalculateEndTime", EntityBase.GetDatabaseValue(@calculateEndTime)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@CalculateCost", EntityBase.GetDatabaseValue(@calculateCost)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ReadyChargeTime", EntityBase.GetDatabaseValue(@readyChargeTime)));
			parameters.Add(new SqlParameter("@RoomUseCount", EntityBase.GetDatabaseValue(@roomUseCount)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Contract_TempPrice from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteContract_TempPrice(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteContract_TempPrice(@iD, helper);
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
		/// Deletes a Contract_TempPrice from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteContract_TempPrice(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Contract_TempPrice]
WHERE 
	[Contract_TempPrice].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Contract_TempPrice object.
		/// </summary>
		/// <returns>The newly created Contract_TempPrice object.</returns>
		public static Contract_TempPrice CreateContract_TempPrice()
		{
			return InitializeNew<Contract_TempPrice>();
		}
		
		/// <summary>
		/// Retrieve information for a Contract_TempPrice by a Contract_TempPrice's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Contract_TempPrice</returns>
		public static Contract_TempPrice GetContract_TempPrice(int @iD)
		{
			string commandText = @"
SELECT 
" + Contract_TempPrice.SelectFieldList + @"
FROM [dbo].[Contract_TempPrice] 
WHERE 
	[Contract_TempPrice].[ID] = @ID " + Contract_TempPrice.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_TempPrice>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Contract_TempPrice by a Contract_TempPrice's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Contract_TempPrice</returns>
		public static Contract_TempPrice GetContract_TempPrice(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Contract_TempPrice.SelectFieldList + @"
FROM [dbo].[Contract_TempPrice] 
WHERE 
	[Contract_TempPrice].[ID] = @ID " + Contract_TempPrice.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_TempPrice>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Contract_TempPrice objects.
		/// </summary>
		/// <returns>The retrieved collection of Contract_TempPrice objects.</returns>
		public static EntityList<Contract_TempPrice> GetContract_TempPrices()
		{
			string commandText = @"
SELECT " + Contract_TempPrice.SelectFieldList + "FROM [dbo].[Contract_TempPrice] " + Contract_TempPrice.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Contract_TempPrice>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Contract_TempPrice objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_TempPrice objects.</returns>
        public static EntityList<Contract_TempPrice> GetContract_TempPrices(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_TempPrice>(SelectFieldList, "FROM [dbo].[Contract_TempPrice]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Contract_TempPrice objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_TempPrice objects.</returns>
        public static EntityList<Contract_TempPrice> GetContract_TempPrices(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_TempPrice>(SelectFieldList, "FROM [dbo].[Contract_TempPrice]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Contract_TempPrice objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Contract_TempPrice objects.</returns>
		protected static EntityList<Contract_TempPrice> GetContract_TempPrices(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_TempPrices(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Contract_TempPrice objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_TempPrice objects.</returns>
		protected static EntityList<Contract_TempPrice> GetContract_TempPrices(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_TempPrices(string.Empty, where, parameters, Contract_TempPrice.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_TempPrice objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_TempPrice objects.</returns>
		protected static EntityList<Contract_TempPrice> GetContract_TempPrices(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_TempPrices(prefix, where, parameters, Contract_TempPrice.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_TempPrice objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_TempPrice objects.</returns>
		protected static EntityList<Contract_TempPrice> GetContract_TempPrices(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_TempPrices(string.Empty, where, parameters, Contract_TempPrice.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_TempPrice objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_TempPrice objects.</returns>
		protected static EntityList<Contract_TempPrice> GetContract_TempPrices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_TempPrices(prefix, where, parameters, Contract_TempPrice.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_TempPrice objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Contract_TempPrice objects.</returns>
		protected static EntityList<Contract_TempPrice> GetContract_TempPrices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Contract_TempPrice.SelectFieldList + "FROM [dbo].[Contract_TempPrice] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Contract_TempPrice>(reader);
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
        protected static EntityList<Contract_TempPrice> GetContract_TempPrices(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_TempPrice>(SelectFieldList, "FROM [dbo].[Contract_TempPrice] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Contract_TempPrice objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_TempPriceCount()
        {
            return GetContract_TempPriceCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Contract_TempPrice objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_TempPriceCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Contract_TempPrice] " + where;

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
		public static partial class Contract_TempPrice_Properties
		{
			public const string ID = "ID";
			public const string BasicPrice = "BasicPrice";
			public const string BasicStartTime = "BasicStartTime";
			public const string BasicEndTime = "BasicEndTime";
			public const string CalculateType = "CalculateType";
			public const string CalculatePercent = "CalculatePercent";
			public const string CalculateAmount = "CalculateAmount";
			public const string CalculatePrice = "CalculatePrice";
			public const string CalculateStartTime = "CalculateStartTime";
			public const string CalculateEndTime = "CalculateEndTime";
			public const string GUID = "GUID";
			public const string CalculateCost = "CalculateCost";
			public const string AddTime = "AddTime";
			public const string ReadyChargeTime = "ReadyChargeTime";
			public const string RoomUseCount = "RoomUseCount";
			public const string ChargeID = "ChargeID";
			public const string RoomID = "RoomID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"BasicPrice" , "decimal:"},
    			 {"BasicStartTime" , "DateTime:"},
    			 {"BasicEndTime" , "DateTime:"},
    			 {"CalculateType" , "string:"},
    			 {"CalculatePercent" , "decimal:"},
    			 {"CalculateAmount" , "decimal:"},
    			 {"CalculatePrice" , "decimal:"},
    			 {"CalculateStartTime" , "DateTime:"},
    			 {"CalculateEndTime" , "DateTime:"},
    			 {"GUID" , "string:"},
    			 {"CalculateCost" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"ReadyChargeTime" , "DateTime:"},
    			 {"RoomUseCount" , "decimal:"},
    			 {"ChargeID" , "int:"},
    			 {"RoomID" , "int:"},
            };
		}
		#endregion
	}
}
