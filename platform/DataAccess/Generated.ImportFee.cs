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
	/// This object represents the properties and methods of a ImportFee.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ImportFee 
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
		private string _chargeDate = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeDate
		{
			[DebuggerStepThrough()]
			get { return this._chargeDate; }
			set 
			{
				if (this._chargeDate != value) 
				{
					this._chargeDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeDate");
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
		[DataObjectField(false, false, false)]
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
		private decimal _startPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal StartPoint
		{
			[DebuggerStepThrough()]
			get { return this._startPoint; }
			set 
			{
				if (this._startPoint != value) 
				{
					this._startPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("StartPoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _endPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal EndPoint
		{
			[DebuggerStepThrough()]
			get { return this._endPoint; }
			set 
			{
				if (this._endPoint != value) 
				{
					this._endPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndPoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalPoint
		{
			[DebuggerStepThrough()]
			get { return this._totalPoint; }
			set 
			{
				if (this._totalPoint != value) 
				{
					this._totalPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalPoint");
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
		private decimal _totalPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private DateTime _writeDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime WriteDate
		{
			[DebuggerStepThrough()]
			get { return this._writeDate; }
			set 
			{
				if (this._writeDate != value) 
				{
					this._writeDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("WriteDate");
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
		private int _chargeStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ChargeStatus
		{
			[DebuggerStepThrough()]
			get { return this._chargeStatus; }
			set 
			{
				if (this._chargeStatus != value) 
				{
					this._chargeStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _importCoefficient = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ImportCoefficient
		{
			[DebuggerStepThrough()]
			get { return this._importCoefficient; }
			set 
			{
				if (this._importCoefficient != value) 
				{
					this._importCoefficient = value;
					this.IsDirty = true;	
					OnPropertyChanged("ImportCoefficient");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _importBiaoCategory = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ImportBiaoCategory
		{
			[DebuggerStepThrough()]
			get { return this._importBiaoCategory; }
			set 
			{
				if (this._importBiaoCategory != value) 
				{
					this._importBiaoCategory = value;
					this.IsDirty = true;	
					OnPropertyChanged("ImportBiaoCategory");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _importBiaoName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ImportBiaoName
		{
			[DebuggerStepThrough()]
			get { return this._importBiaoName; }
			set 
			{
				if (this._importBiaoName != value) 
				{
					this._importBiaoName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ImportBiaoName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargeBiaoID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChargeBiaoID
		{
			[DebuggerStepThrough()]
			get { return this._chargeBiaoID; }
			set 
			{
				if (this._chargeBiaoID != value) 
				{
					this._chargeBiaoID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeBiaoID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _projectBiaoID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProjectBiaoID
		{
			[DebuggerStepThrough()]
			get { return this._projectBiaoID; }
			set 
			{
				if (this._projectBiaoID != value) 
				{
					this._projectBiaoID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectBiaoID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _importBiaoGuiGe = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ImportBiaoGuiGe
		{
			[DebuggerStepThrough()]
			get { return this._importBiaoGuiGe; }
			set 
			{
				if (this._importBiaoGuiGe != value) 
				{
					this._importBiaoGuiGe = value;
					this.IsDirty = true;	
					OnPropertyChanged("ImportBiaoGuiGe");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _importRate = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ImportRate
		{
			[DebuggerStepThrough()]
			get { return this._importRate; }
			set 
			{
				if (this._importRate != value) 
				{
					this._importRate = value;
					this.IsDirty = true;	
					OnPropertyChanged("ImportRate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _importReducePoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ImportReducePoint
		{
			[DebuggerStepThrough()]
			get { return this._importReducePoint; }
			set 
			{
				if (this._importReducePoint != value) 
				{
					this._importReducePoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("ImportReducePoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _importChargeRoomNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ImportChargeRoomNo
		{
			[DebuggerStepThrough()]
			get { return this._importChargeRoomNo; }
			set 
			{
				if (this._importChargeRoomNo != value) 
				{
					this._importChargeRoomNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("ImportChargeRoomNo");
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
	[ChargeDate] nvarchar(50),
	[ChargeID] int,
	[StartPoint] decimal(18, 2),
	[EndPoint] decimal(18, 2),
	[TotalPoint] decimal(18, 2),
	[UnitPrice] decimal(18, 4),
	[TotalPrice] decimal(18, 2),
	[WriteDate] datetime,
	[StartTime] datetime,
	[EndTime] datetime,
	[AddTime] datetime,
	[ChargeStatus] int,
	[ImportCoefficient] decimal(18, 4),
	[ImportBiaoCategory] nvarchar(200),
	[ImportBiaoName] nvarchar(200),
	[ChargeBiaoID] int,
	[ProjectBiaoID] int,
	[ImportBiaoGuiGe] nvarchar(200),
	[ImportRate] decimal(18, 4),
	[ImportReducePoint] decimal(18, 2),
	[ImportChargeRoomNo] nvarchar(200)
);

INSERT INTO [dbo].[ImportFee] (
	[ImportFee].[RoomID],
	[ImportFee].[ChargeDate],
	[ImportFee].[ChargeID],
	[ImportFee].[StartPoint],
	[ImportFee].[EndPoint],
	[ImportFee].[TotalPoint],
	[ImportFee].[UnitPrice],
	[ImportFee].[TotalPrice],
	[ImportFee].[WriteDate],
	[ImportFee].[StartTime],
	[ImportFee].[EndTime],
	[ImportFee].[AddTime],
	[ImportFee].[ChargeStatus],
	[ImportFee].[ImportCoefficient],
	[ImportFee].[ImportBiaoCategory],
	[ImportFee].[ImportBiaoName],
	[ImportFee].[ChargeBiaoID],
	[ImportFee].[ProjectBiaoID],
	[ImportFee].[ImportBiaoGuiGe],
	[ImportFee].[ImportRate],
	[ImportFee].[ImportReducePoint],
	[ImportFee].[ImportChargeRoomNo]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[ChargeDate],
	INSERTED.[ChargeID],
	INSERTED.[StartPoint],
	INSERTED.[EndPoint],
	INSERTED.[TotalPoint],
	INSERTED.[UnitPrice],
	INSERTED.[TotalPrice],
	INSERTED.[WriteDate],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[AddTime],
	INSERTED.[ChargeStatus],
	INSERTED.[ImportCoefficient],
	INSERTED.[ImportBiaoCategory],
	INSERTED.[ImportBiaoName],
	INSERTED.[ChargeBiaoID],
	INSERTED.[ProjectBiaoID],
	INSERTED.[ImportBiaoGuiGe],
	INSERTED.[ImportRate],
	INSERTED.[ImportReducePoint],
	INSERTED.[ImportChargeRoomNo]
into @table
VALUES ( 
	@RoomID,
	@ChargeDate,
	@ChargeID,
	@StartPoint,
	@EndPoint,
	@TotalPoint,
	@UnitPrice,
	@TotalPrice,
	@WriteDate,
	@StartTime,
	@EndTime,
	@AddTime,
	@ChargeStatus,
	@ImportCoefficient,
	@ImportBiaoCategory,
	@ImportBiaoName,
	@ChargeBiaoID,
	@ProjectBiaoID,
	@ImportBiaoGuiGe,
	@ImportRate,
	@ImportReducePoint,
	@ImportChargeRoomNo 
); 

SELECT 
	[ID],
	[RoomID],
	[ChargeDate],
	[ChargeID],
	[StartPoint],
	[EndPoint],
	[TotalPoint],
	[UnitPrice],
	[TotalPrice],
	[WriteDate],
	[StartTime],
	[EndTime],
	[AddTime],
	[ChargeStatus],
	[ImportCoefficient],
	[ImportBiaoCategory],
	[ImportBiaoName],
	[ChargeBiaoID],
	[ProjectBiaoID],
	[ImportBiaoGuiGe],
	[ImportRate],
	[ImportReducePoint],
	[ImportChargeRoomNo] 
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
	[ChargeDate] nvarchar(50),
	[ChargeID] int,
	[StartPoint] decimal(18, 2),
	[EndPoint] decimal(18, 2),
	[TotalPoint] decimal(18, 2),
	[UnitPrice] decimal(18, 4),
	[TotalPrice] decimal(18, 2),
	[WriteDate] datetime,
	[StartTime] datetime,
	[EndTime] datetime,
	[AddTime] datetime,
	[ChargeStatus] int,
	[ImportCoefficient] decimal(18, 4),
	[ImportBiaoCategory] nvarchar(200),
	[ImportBiaoName] nvarchar(200),
	[ChargeBiaoID] int,
	[ProjectBiaoID] int,
	[ImportBiaoGuiGe] nvarchar(200),
	[ImportRate] decimal(18, 4),
	[ImportReducePoint] decimal(18, 2),
	[ImportChargeRoomNo] nvarchar(200)
);

UPDATE [dbo].[ImportFee] SET 
	[ImportFee].[RoomID] = @RoomID,
	[ImportFee].[ChargeDate] = @ChargeDate,
	[ImportFee].[ChargeID] = @ChargeID,
	[ImportFee].[StartPoint] = @StartPoint,
	[ImportFee].[EndPoint] = @EndPoint,
	[ImportFee].[TotalPoint] = @TotalPoint,
	[ImportFee].[UnitPrice] = @UnitPrice,
	[ImportFee].[TotalPrice] = @TotalPrice,
	[ImportFee].[WriteDate] = @WriteDate,
	[ImportFee].[StartTime] = @StartTime,
	[ImportFee].[EndTime] = @EndTime,
	[ImportFee].[AddTime] = @AddTime,
	[ImportFee].[ChargeStatus] = @ChargeStatus,
	[ImportFee].[ImportCoefficient] = @ImportCoefficient,
	[ImportFee].[ImportBiaoCategory] = @ImportBiaoCategory,
	[ImportFee].[ImportBiaoName] = @ImportBiaoName,
	[ImportFee].[ChargeBiaoID] = @ChargeBiaoID,
	[ImportFee].[ProjectBiaoID] = @ProjectBiaoID,
	[ImportFee].[ImportBiaoGuiGe] = @ImportBiaoGuiGe,
	[ImportFee].[ImportRate] = @ImportRate,
	[ImportFee].[ImportReducePoint] = @ImportReducePoint,
	[ImportFee].[ImportChargeRoomNo] = @ImportChargeRoomNo 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[ChargeDate],
	INSERTED.[ChargeID],
	INSERTED.[StartPoint],
	INSERTED.[EndPoint],
	INSERTED.[TotalPoint],
	INSERTED.[UnitPrice],
	INSERTED.[TotalPrice],
	INSERTED.[WriteDate],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[AddTime],
	INSERTED.[ChargeStatus],
	INSERTED.[ImportCoefficient],
	INSERTED.[ImportBiaoCategory],
	INSERTED.[ImportBiaoName],
	INSERTED.[ChargeBiaoID],
	INSERTED.[ProjectBiaoID],
	INSERTED.[ImportBiaoGuiGe],
	INSERTED.[ImportRate],
	INSERTED.[ImportReducePoint],
	INSERTED.[ImportChargeRoomNo]
into @table
WHERE 
	[ImportFee].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[ChargeDate],
	[ChargeID],
	[StartPoint],
	[EndPoint],
	[TotalPoint],
	[UnitPrice],
	[TotalPrice],
	[WriteDate],
	[StartTime],
	[EndTime],
	[AddTime],
	[ChargeStatus],
	[ImportCoefficient],
	[ImportBiaoCategory],
	[ImportBiaoName],
	[ChargeBiaoID],
	[ProjectBiaoID],
	[ImportBiaoGuiGe],
	[ImportRate],
	[ImportReducePoint],
	[ImportChargeRoomNo] 
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
DELETE FROM [dbo].[ImportFee]
WHERE 
	[ImportFee].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ImportFee() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetImportFee(this.ID));
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
	[ImportFee].[ID],
	[ImportFee].[RoomID],
	[ImportFee].[ChargeDate],
	[ImportFee].[ChargeID],
	[ImportFee].[StartPoint],
	[ImportFee].[EndPoint],
	[ImportFee].[TotalPoint],
	[ImportFee].[UnitPrice],
	[ImportFee].[TotalPrice],
	[ImportFee].[WriteDate],
	[ImportFee].[StartTime],
	[ImportFee].[EndTime],
	[ImportFee].[AddTime],
	[ImportFee].[ChargeStatus],
	[ImportFee].[ImportCoefficient],
	[ImportFee].[ImportBiaoCategory],
	[ImportFee].[ImportBiaoName],
	[ImportFee].[ChargeBiaoID],
	[ImportFee].[ProjectBiaoID],
	[ImportFee].[ImportBiaoGuiGe],
	[ImportFee].[ImportRate],
	[ImportFee].[ImportReducePoint],
	[ImportFee].[ImportChargeRoomNo]
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
                return "ImportFee";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ImportFee into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="chargeDate">chargeDate</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="startPoint">startPoint</param>
		/// <param name="endPoint">endPoint</param>
		/// <param name="totalPoint">totalPoint</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="totalPrice">totalPrice</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="chargeStatus">chargeStatus</param>
		/// <param name="importCoefficient">importCoefficient</param>
		/// <param name="importBiaoCategory">importBiaoCategory</param>
		/// <param name="importBiaoName">importBiaoName</param>
		/// <param name="chargeBiaoID">chargeBiaoID</param>
		/// <param name="projectBiaoID">projectBiaoID</param>
		/// <param name="importBiaoGuiGe">importBiaoGuiGe</param>
		/// <param name="importRate">importRate</param>
		/// <param name="importReducePoint">importReducePoint</param>
		/// <param name="importChargeRoomNo">importChargeRoomNo</param>
		public static void InsertImportFee(int @roomID, string @chargeDate, int @chargeID, decimal @startPoint, decimal @endPoint, decimal @totalPoint, decimal @unitPrice, decimal @totalPrice, DateTime @writeDate, DateTime @startTime, DateTime @endTime, DateTime @addTime, int @chargeStatus, decimal @importCoefficient, string @importBiaoCategory, string @importBiaoName, int @chargeBiaoID, int @projectBiaoID, string @importBiaoGuiGe, decimal @importRate, decimal @importReducePoint, string @importChargeRoomNo)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertImportFee(@roomID, @chargeDate, @chargeID, @startPoint, @endPoint, @totalPoint, @unitPrice, @totalPrice, @writeDate, @startTime, @endTime, @addTime, @chargeStatus, @importCoefficient, @importBiaoCategory, @importBiaoName, @chargeBiaoID, @projectBiaoID, @importBiaoGuiGe, @importRate, @importReducePoint, @importChargeRoomNo, helper);
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
		/// Insert a ImportFee into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="chargeDate">chargeDate</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="startPoint">startPoint</param>
		/// <param name="endPoint">endPoint</param>
		/// <param name="totalPoint">totalPoint</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="totalPrice">totalPrice</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="chargeStatus">chargeStatus</param>
		/// <param name="importCoefficient">importCoefficient</param>
		/// <param name="importBiaoCategory">importBiaoCategory</param>
		/// <param name="importBiaoName">importBiaoName</param>
		/// <param name="chargeBiaoID">chargeBiaoID</param>
		/// <param name="projectBiaoID">projectBiaoID</param>
		/// <param name="importBiaoGuiGe">importBiaoGuiGe</param>
		/// <param name="importRate">importRate</param>
		/// <param name="importReducePoint">importReducePoint</param>
		/// <param name="importChargeRoomNo">importChargeRoomNo</param>
		/// <param name="helper">helper</param>
		internal static void InsertImportFee(int @roomID, string @chargeDate, int @chargeID, decimal @startPoint, decimal @endPoint, decimal @totalPoint, decimal @unitPrice, decimal @totalPrice, DateTime @writeDate, DateTime @startTime, DateTime @endTime, DateTime @addTime, int @chargeStatus, decimal @importCoefficient, string @importBiaoCategory, string @importBiaoName, int @chargeBiaoID, int @projectBiaoID, string @importBiaoGuiGe, decimal @importRate, decimal @importReducePoint, string @importChargeRoomNo, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[ChargeDate] nvarchar(50),
	[ChargeID] int,
	[StartPoint] decimal(18, 2),
	[EndPoint] decimal(18, 2),
	[TotalPoint] decimal(18, 2),
	[UnitPrice] decimal(18, 4),
	[TotalPrice] decimal(18, 2),
	[WriteDate] datetime,
	[StartTime] datetime,
	[EndTime] datetime,
	[AddTime] datetime,
	[ChargeStatus] int,
	[ImportCoefficient] decimal(18, 4),
	[ImportBiaoCategory] nvarchar(200),
	[ImportBiaoName] nvarchar(200),
	[ChargeBiaoID] int,
	[ProjectBiaoID] int,
	[ImportBiaoGuiGe] nvarchar(200),
	[ImportRate] decimal(18, 4),
	[ImportReducePoint] decimal(18, 2),
	[ImportChargeRoomNo] nvarchar(200)
);

INSERT INTO [dbo].[ImportFee] (
	[ImportFee].[RoomID],
	[ImportFee].[ChargeDate],
	[ImportFee].[ChargeID],
	[ImportFee].[StartPoint],
	[ImportFee].[EndPoint],
	[ImportFee].[TotalPoint],
	[ImportFee].[UnitPrice],
	[ImportFee].[TotalPrice],
	[ImportFee].[WriteDate],
	[ImportFee].[StartTime],
	[ImportFee].[EndTime],
	[ImportFee].[AddTime],
	[ImportFee].[ChargeStatus],
	[ImportFee].[ImportCoefficient],
	[ImportFee].[ImportBiaoCategory],
	[ImportFee].[ImportBiaoName],
	[ImportFee].[ChargeBiaoID],
	[ImportFee].[ProjectBiaoID],
	[ImportFee].[ImportBiaoGuiGe],
	[ImportFee].[ImportRate],
	[ImportFee].[ImportReducePoint],
	[ImportFee].[ImportChargeRoomNo]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[ChargeDate],
	INSERTED.[ChargeID],
	INSERTED.[StartPoint],
	INSERTED.[EndPoint],
	INSERTED.[TotalPoint],
	INSERTED.[UnitPrice],
	INSERTED.[TotalPrice],
	INSERTED.[WriteDate],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[AddTime],
	INSERTED.[ChargeStatus],
	INSERTED.[ImportCoefficient],
	INSERTED.[ImportBiaoCategory],
	INSERTED.[ImportBiaoName],
	INSERTED.[ChargeBiaoID],
	INSERTED.[ProjectBiaoID],
	INSERTED.[ImportBiaoGuiGe],
	INSERTED.[ImportRate],
	INSERTED.[ImportReducePoint],
	INSERTED.[ImportChargeRoomNo]
into @table
VALUES ( 
	@RoomID,
	@ChargeDate,
	@ChargeID,
	@StartPoint,
	@EndPoint,
	@TotalPoint,
	@UnitPrice,
	@TotalPrice,
	@WriteDate,
	@StartTime,
	@EndTime,
	@AddTime,
	@ChargeStatus,
	@ImportCoefficient,
	@ImportBiaoCategory,
	@ImportBiaoName,
	@ChargeBiaoID,
	@ProjectBiaoID,
	@ImportBiaoGuiGe,
	@ImportRate,
	@ImportReducePoint,
	@ImportChargeRoomNo 
); 

SELECT 
	[ID],
	[RoomID],
	[ChargeDate],
	[ChargeID],
	[StartPoint],
	[EndPoint],
	[TotalPoint],
	[UnitPrice],
	[TotalPrice],
	[WriteDate],
	[StartTime],
	[EndTime],
	[AddTime],
	[ChargeStatus],
	[ImportCoefficient],
	[ImportBiaoCategory],
	[ImportBiaoName],
	[ChargeBiaoID],
	[ProjectBiaoID],
	[ImportBiaoGuiGe],
	[ImportRate],
	[ImportReducePoint],
	[ImportChargeRoomNo] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@ChargeDate", EntityBase.GetDatabaseValue(@chargeDate)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@StartPoint", EntityBase.GetDatabaseValue(@startPoint)));
			parameters.Add(new SqlParameter("@EndPoint", EntityBase.GetDatabaseValue(@endPoint)));
			parameters.Add(new SqlParameter("@TotalPoint", EntityBase.GetDatabaseValue(@totalPoint)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@TotalPrice", EntityBase.GetDatabaseValue(@totalPrice)));
			parameters.Add(new SqlParameter("@WriteDate", EntityBase.GetDatabaseValue(@writeDate)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ChargeStatus", EntityBase.GetDatabaseValue(@chargeStatus)));
			parameters.Add(new SqlParameter("@ImportCoefficient", EntityBase.GetDatabaseValue(@importCoefficient)));
			parameters.Add(new SqlParameter("@ImportBiaoCategory", EntityBase.GetDatabaseValue(@importBiaoCategory)));
			parameters.Add(new SqlParameter("@ImportBiaoName", EntityBase.GetDatabaseValue(@importBiaoName)));
			parameters.Add(new SqlParameter("@ChargeBiaoID", EntityBase.GetDatabaseValue(@chargeBiaoID)));
			parameters.Add(new SqlParameter("@ProjectBiaoID", EntityBase.GetDatabaseValue(@projectBiaoID)));
			parameters.Add(new SqlParameter("@ImportBiaoGuiGe", EntityBase.GetDatabaseValue(@importBiaoGuiGe)));
			parameters.Add(new SqlParameter("@ImportRate", EntityBase.GetDatabaseValue(@importRate)));
			parameters.Add(new SqlParameter("@ImportReducePoint", EntityBase.GetDatabaseValue(@importReducePoint)));
			parameters.Add(new SqlParameter("@ImportChargeRoomNo", EntityBase.GetDatabaseValue(@importChargeRoomNo)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ImportFee into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="chargeDate">chargeDate</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="startPoint">startPoint</param>
		/// <param name="endPoint">endPoint</param>
		/// <param name="totalPoint">totalPoint</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="totalPrice">totalPrice</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="chargeStatus">chargeStatus</param>
		/// <param name="importCoefficient">importCoefficient</param>
		/// <param name="importBiaoCategory">importBiaoCategory</param>
		/// <param name="importBiaoName">importBiaoName</param>
		/// <param name="chargeBiaoID">chargeBiaoID</param>
		/// <param name="projectBiaoID">projectBiaoID</param>
		/// <param name="importBiaoGuiGe">importBiaoGuiGe</param>
		/// <param name="importRate">importRate</param>
		/// <param name="importReducePoint">importReducePoint</param>
		/// <param name="importChargeRoomNo">importChargeRoomNo</param>
		public static void UpdateImportFee(int @iD, int @roomID, string @chargeDate, int @chargeID, decimal @startPoint, decimal @endPoint, decimal @totalPoint, decimal @unitPrice, decimal @totalPrice, DateTime @writeDate, DateTime @startTime, DateTime @endTime, DateTime @addTime, int @chargeStatus, decimal @importCoefficient, string @importBiaoCategory, string @importBiaoName, int @chargeBiaoID, int @projectBiaoID, string @importBiaoGuiGe, decimal @importRate, decimal @importReducePoint, string @importChargeRoomNo)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateImportFee(@iD, @roomID, @chargeDate, @chargeID, @startPoint, @endPoint, @totalPoint, @unitPrice, @totalPrice, @writeDate, @startTime, @endTime, @addTime, @chargeStatus, @importCoefficient, @importBiaoCategory, @importBiaoName, @chargeBiaoID, @projectBiaoID, @importBiaoGuiGe, @importRate, @importReducePoint, @importChargeRoomNo, helper);
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
		/// Updates a ImportFee into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="chargeDate">chargeDate</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="startPoint">startPoint</param>
		/// <param name="endPoint">endPoint</param>
		/// <param name="totalPoint">totalPoint</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="totalPrice">totalPrice</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="chargeStatus">chargeStatus</param>
		/// <param name="importCoefficient">importCoefficient</param>
		/// <param name="importBiaoCategory">importBiaoCategory</param>
		/// <param name="importBiaoName">importBiaoName</param>
		/// <param name="chargeBiaoID">chargeBiaoID</param>
		/// <param name="projectBiaoID">projectBiaoID</param>
		/// <param name="importBiaoGuiGe">importBiaoGuiGe</param>
		/// <param name="importRate">importRate</param>
		/// <param name="importReducePoint">importReducePoint</param>
		/// <param name="importChargeRoomNo">importChargeRoomNo</param>
		/// <param name="helper">helper</param>
		internal static void UpdateImportFee(int @iD, int @roomID, string @chargeDate, int @chargeID, decimal @startPoint, decimal @endPoint, decimal @totalPoint, decimal @unitPrice, decimal @totalPrice, DateTime @writeDate, DateTime @startTime, DateTime @endTime, DateTime @addTime, int @chargeStatus, decimal @importCoefficient, string @importBiaoCategory, string @importBiaoName, int @chargeBiaoID, int @projectBiaoID, string @importBiaoGuiGe, decimal @importRate, decimal @importReducePoint, string @importChargeRoomNo, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[ChargeDate] nvarchar(50),
	[ChargeID] int,
	[StartPoint] decimal(18, 2),
	[EndPoint] decimal(18, 2),
	[TotalPoint] decimal(18, 2),
	[UnitPrice] decimal(18, 4),
	[TotalPrice] decimal(18, 2),
	[WriteDate] datetime,
	[StartTime] datetime,
	[EndTime] datetime,
	[AddTime] datetime,
	[ChargeStatus] int,
	[ImportCoefficient] decimal(18, 4),
	[ImportBiaoCategory] nvarchar(200),
	[ImportBiaoName] nvarchar(200),
	[ChargeBiaoID] int,
	[ProjectBiaoID] int,
	[ImportBiaoGuiGe] nvarchar(200),
	[ImportRate] decimal(18, 4),
	[ImportReducePoint] decimal(18, 2),
	[ImportChargeRoomNo] nvarchar(200)
);

UPDATE [dbo].[ImportFee] SET 
	[ImportFee].[RoomID] = @RoomID,
	[ImportFee].[ChargeDate] = @ChargeDate,
	[ImportFee].[ChargeID] = @ChargeID,
	[ImportFee].[StartPoint] = @StartPoint,
	[ImportFee].[EndPoint] = @EndPoint,
	[ImportFee].[TotalPoint] = @TotalPoint,
	[ImportFee].[UnitPrice] = @UnitPrice,
	[ImportFee].[TotalPrice] = @TotalPrice,
	[ImportFee].[WriteDate] = @WriteDate,
	[ImportFee].[StartTime] = @StartTime,
	[ImportFee].[EndTime] = @EndTime,
	[ImportFee].[AddTime] = @AddTime,
	[ImportFee].[ChargeStatus] = @ChargeStatus,
	[ImportFee].[ImportCoefficient] = @ImportCoefficient,
	[ImportFee].[ImportBiaoCategory] = @ImportBiaoCategory,
	[ImportFee].[ImportBiaoName] = @ImportBiaoName,
	[ImportFee].[ChargeBiaoID] = @ChargeBiaoID,
	[ImportFee].[ProjectBiaoID] = @ProjectBiaoID,
	[ImportFee].[ImportBiaoGuiGe] = @ImportBiaoGuiGe,
	[ImportFee].[ImportRate] = @ImportRate,
	[ImportFee].[ImportReducePoint] = @ImportReducePoint,
	[ImportFee].[ImportChargeRoomNo] = @ImportChargeRoomNo 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[ChargeDate],
	INSERTED.[ChargeID],
	INSERTED.[StartPoint],
	INSERTED.[EndPoint],
	INSERTED.[TotalPoint],
	INSERTED.[UnitPrice],
	INSERTED.[TotalPrice],
	INSERTED.[WriteDate],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[AddTime],
	INSERTED.[ChargeStatus],
	INSERTED.[ImportCoefficient],
	INSERTED.[ImportBiaoCategory],
	INSERTED.[ImportBiaoName],
	INSERTED.[ChargeBiaoID],
	INSERTED.[ProjectBiaoID],
	INSERTED.[ImportBiaoGuiGe],
	INSERTED.[ImportRate],
	INSERTED.[ImportReducePoint],
	INSERTED.[ImportChargeRoomNo]
into @table
WHERE 
	[ImportFee].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[ChargeDate],
	[ChargeID],
	[StartPoint],
	[EndPoint],
	[TotalPoint],
	[UnitPrice],
	[TotalPrice],
	[WriteDate],
	[StartTime],
	[EndTime],
	[AddTime],
	[ChargeStatus],
	[ImportCoefficient],
	[ImportBiaoCategory],
	[ImportBiaoName],
	[ChargeBiaoID],
	[ProjectBiaoID],
	[ImportBiaoGuiGe],
	[ImportRate],
	[ImportReducePoint],
	[ImportChargeRoomNo] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@ChargeDate", EntityBase.GetDatabaseValue(@chargeDate)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@StartPoint", EntityBase.GetDatabaseValue(@startPoint)));
			parameters.Add(new SqlParameter("@EndPoint", EntityBase.GetDatabaseValue(@endPoint)));
			parameters.Add(new SqlParameter("@TotalPoint", EntityBase.GetDatabaseValue(@totalPoint)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@TotalPrice", EntityBase.GetDatabaseValue(@totalPrice)));
			parameters.Add(new SqlParameter("@WriteDate", EntityBase.GetDatabaseValue(@writeDate)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ChargeStatus", EntityBase.GetDatabaseValue(@chargeStatus)));
			parameters.Add(new SqlParameter("@ImportCoefficient", EntityBase.GetDatabaseValue(@importCoefficient)));
			parameters.Add(new SqlParameter("@ImportBiaoCategory", EntityBase.GetDatabaseValue(@importBiaoCategory)));
			parameters.Add(new SqlParameter("@ImportBiaoName", EntityBase.GetDatabaseValue(@importBiaoName)));
			parameters.Add(new SqlParameter("@ChargeBiaoID", EntityBase.GetDatabaseValue(@chargeBiaoID)));
			parameters.Add(new SqlParameter("@ProjectBiaoID", EntityBase.GetDatabaseValue(@projectBiaoID)));
			parameters.Add(new SqlParameter("@ImportBiaoGuiGe", EntityBase.GetDatabaseValue(@importBiaoGuiGe)));
			parameters.Add(new SqlParameter("@ImportRate", EntityBase.GetDatabaseValue(@importRate)));
			parameters.Add(new SqlParameter("@ImportReducePoint", EntityBase.GetDatabaseValue(@importReducePoint)));
			parameters.Add(new SqlParameter("@ImportChargeRoomNo", EntityBase.GetDatabaseValue(@importChargeRoomNo)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ImportFee from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteImportFee(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteImportFee(@iD, helper);
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
		/// Deletes a ImportFee from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteImportFee(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ImportFee]
WHERE 
	[ImportFee].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ImportFee object.
		/// </summary>
		/// <returns>The newly created ImportFee object.</returns>
		public static ImportFee CreateImportFee()
		{
			return InitializeNew<ImportFee>();
		}
		
		/// <summary>
		/// Retrieve information for a ImportFee by a ImportFee's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ImportFee</returns>
		public static ImportFee GetImportFee(int @iD)
		{
			string commandText = @"
SELECT 
" + ImportFee.SelectFieldList + @"
FROM [dbo].[ImportFee] 
WHERE 
	[ImportFee].[ID] = @ID " + ImportFee.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ImportFee>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ImportFee by a ImportFee's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ImportFee</returns>
		public static ImportFee GetImportFee(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ImportFee.SelectFieldList + @"
FROM [dbo].[ImportFee] 
WHERE 
	[ImportFee].[ID] = @ID " + ImportFee.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ImportFee>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ImportFee objects.
		/// </summary>
		/// <returns>The retrieved collection of ImportFee objects.</returns>
		public static EntityList<ImportFee> GetImportFees()
		{
			string commandText = @"
SELECT " + ImportFee.SelectFieldList + "FROM [dbo].[ImportFee] " + ImportFee.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ImportFee>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ImportFee objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ImportFee objects.</returns>
        public static EntityList<ImportFee> GetImportFees(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ImportFee>(SelectFieldList, "FROM [dbo].[ImportFee]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ImportFee objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ImportFee objects.</returns>
        public static EntityList<ImportFee> GetImportFees(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ImportFee>(SelectFieldList, "FROM [dbo].[ImportFee]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ImportFee objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ImportFee objects.</returns>
		protected static EntityList<ImportFee> GetImportFees(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetImportFees(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ImportFee objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ImportFee objects.</returns>
		protected static EntityList<ImportFee> GetImportFees(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetImportFees(string.Empty, where, parameters, ImportFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ImportFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ImportFee objects.</returns>
		protected static EntityList<ImportFee> GetImportFees(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetImportFees(prefix, where, parameters, ImportFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ImportFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ImportFee objects.</returns>
		protected static EntityList<ImportFee> GetImportFees(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetImportFees(string.Empty, where, parameters, ImportFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ImportFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ImportFee objects.</returns>
		protected static EntityList<ImportFee> GetImportFees(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetImportFees(prefix, where, parameters, ImportFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ImportFee objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ImportFee objects.</returns>
		protected static EntityList<ImportFee> GetImportFees(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ImportFee.SelectFieldList + "FROM [dbo].[ImportFee] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ImportFee>(reader);
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
        protected static EntityList<ImportFee> GetImportFees(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ImportFee>(SelectFieldList, "FROM [dbo].[ImportFee] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ImportFee objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetImportFeeCount()
        {
            return GetImportFeeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ImportFee objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetImportFeeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ImportFee] " + where;

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
		public static partial class ImportFee_Properties
		{
			public const string ID = "ID";
			public const string RoomID = "RoomID";
			public const string ChargeDate = "ChargeDate";
			public const string ChargeID = "ChargeID";
			public const string StartPoint = "StartPoint";
			public const string EndPoint = "EndPoint";
			public const string TotalPoint = "TotalPoint";
			public const string UnitPrice = "UnitPrice";
			public const string TotalPrice = "TotalPrice";
			public const string WriteDate = "WriteDate";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string AddTime = "AddTime";
			public const string ChargeStatus = "ChargeStatus";
			public const string ImportCoefficient = "ImportCoefficient";
			public const string ImportBiaoCategory = "ImportBiaoCategory";
			public const string ImportBiaoName = "ImportBiaoName";
			public const string ChargeBiaoID = "ChargeBiaoID";
			public const string ProjectBiaoID = "ProjectBiaoID";
			public const string ImportBiaoGuiGe = "ImportBiaoGuiGe";
			public const string ImportRate = "ImportRate";
			public const string ImportReducePoint = "ImportReducePoint";
			public const string ImportChargeRoomNo = "ImportChargeRoomNo";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"ChargeDate" , "string:"},
    			 {"ChargeID" , "int:"},
    			 {"StartPoint" , "decimal:"},
    			 {"EndPoint" , "decimal:"},
    			 {"TotalPoint" , "decimal:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"TotalPrice" , "decimal:"},
    			 {"WriteDate" , "DateTime:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"AddTime" , "DateTime:"},
    			 {"ChargeStatus" , "int:"},
    			 {"ImportCoefficient" , "decimal:"},
    			 {"ImportBiaoCategory" , "string:"},
    			 {"ImportBiaoName" , "string:"},
    			 {"ChargeBiaoID" , "int:"},
    			 {"ProjectBiaoID" , "int:"},
    			 {"ImportBiaoGuiGe" , "string:"},
    			 {"ImportRate" , "decimal:"},
    			 {"ImportReducePoint" , "decimal:"},
    			 {"ImportChargeRoomNo" , "string:"},
            };
		}
		#endregion
	}
}
