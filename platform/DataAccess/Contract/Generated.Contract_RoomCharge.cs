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
	/// This object represents the properties and methods of a Contract_RoomCharge.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Contract_RoomCharge 
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
		private int _contractID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private decimal _roomUnitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RoomUnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._roomUnitPrice; }
			set 
			{
				if (this._roomUnitPrice != value) 
				{
					this._roomUnitPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomUnitPrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _roomStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime RoomStartTime
		{
			[DebuggerStepThrough()]
			get { return this._roomStartTime; }
			set 
			{
				if (this._roomStartTime != value) 
				{
					this._roomStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomStartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _roomEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime RoomEndTime
		{
			[DebuggerStepThrough()]
			get { return this._roomEndTime; }
			set 
			{
				if (this._roomEndTime != value) 
				{
					this._roomEndTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomEndTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _roomNewEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime RoomNewEndTime
		{
			[DebuggerStepThrough()]
			get { return this._roomNewEndTime; }
			set 
			{
				if (this._roomNewEndTime != value) 
				{
					this._roomNewEndTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomNewEndTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _roomCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RoomCost
		{
			[DebuggerStepThrough()]
			get { return this._roomCost; }
			set 
			{
				if (this._roomCost != value) 
				{
					this._roomCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomCost");
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
		private int _contract_TempPriceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Contract_TempPriceID
		{
			[DebuggerStepThrough()]
			get { return this._contract_TempPriceID; }
			set 
			{
				if (this._contract_TempPriceID != value) 
				{
					this._contract_TempPriceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("Contract_TempPriceID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isReRent = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsReRent
		{
			[DebuggerStepThrough()]
			get { return this._isReRent; }
			set 
			{
				if (this._isReRent != value) 
				{
					this._isReRent = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsReRent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isContractDivideFee = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsContractDivideFee
		{
			[DebuggerStepThrough()]
			get { return this._isContractDivideFee; }
			set 
			{
				if (this._isContractDivideFee != value) 
				{
					this._isContractDivideFee = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsContractDivideFee");
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
	[ContractID] int,
	[RoomID] int,
	[ChargeID] int,
	[RoomUnitPrice] decimal(18, 4),
	[RoomStartTime] datetime,
	[RoomEndTime] datetime,
	[RoomNewEndTime] datetime,
	[RoomCost] decimal(18, 2),
	[Remark] ntext,
	[AddTime] datetime,
	[GUID] nvarchar(500),
	[RoomUseCount] decimal(18, 3),
	[ReadyChargeTime] datetime,
	[Contract_TempPriceID] int,
	[IsReRent] bit,
	[IsContractDivideFee] bit
);

INSERT INTO [dbo].[Contract_RoomCharge] (
	[Contract_RoomCharge].[ContractID],
	[Contract_RoomCharge].[RoomID],
	[Contract_RoomCharge].[ChargeID],
	[Contract_RoomCharge].[RoomUnitPrice],
	[Contract_RoomCharge].[RoomStartTime],
	[Contract_RoomCharge].[RoomEndTime],
	[Contract_RoomCharge].[RoomNewEndTime],
	[Contract_RoomCharge].[RoomCost],
	[Contract_RoomCharge].[Remark],
	[Contract_RoomCharge].[AddTime],
	[Contract_RoomCharge].[GUID],
	[Contract_RoomCharge].[RoomUseCount],
	[Contract_RoomCharge].[ReadyChargeTime],
	[Contract_RoomCharge].[Contract_TempPriceID],
	[Contract_RoomCharge].[IsReRent],
	[Contract_RoomCharge].[IsContractDivideFee]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[RoomID],
	INSERTED.[ChargeID],
	INSERTED.[RoomUnitPrice],
	INSERTED.[RoomStartTime],
	INSERTED.[RoomEndTime],
	INSERTED.[RoomNewEndTime],
	INSERTED.[RoomCost],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[RoomUseCount],
	INSERTED.[ReadyChargeTime],
	INSERTED.[Contract_TempPriceID],
	INSERTED.[IsReRent],
	INSERTED.[IsContractDivideFee]
into @table
VALUES ( 
	@ContractID,
	@RoomID,
	@ChargeID,
	@RoomUnitPrice,
	@RoomStartTime,
	@RoomEndTime,
	@RoomNewEndTime,
	@RoomCost,
	@Remark,
	@AddTime,
	@GUID,
	@RoomUseCount,
	@ReadyChargeTime,
	@Contract_TempPriceID,
	@IsReRent,
	@IsContractDivideFee 
); 

SELECT 
	[ID],
	[ContractID],
	[RoomID],
	[ChargeID],
	[RoomUnitPrice],
	[RoomStartTime],
	[RoomEndTime],
	[RoomNewEndTime],
	[RoomCost],
	[Remark],
	[AddTime],
	[GUID],
	[RoomUseCount],
	[ReadyChargeTime],
	[Contract_TempPriceID],
	[IsReRent],
	[IsContractDivideFee] 
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
	[ContractID] int,
	[RoomID] int,
	[ChargeID] int,
	[RoomUnitPrice] decimal(18, 4),
	[RoomStartTime] datetime,
	[RoomEndTime] datetime,
	[RoomNewEndTime] datetime,
	[RoomCost] decimal(18, 2),
	[Remark] ntext,
	[AddTime] datetime,
	[GUID] nvarchar(500),
	[RoomUseCount] decimal(18, 3),
	[ReadyChargeTime] datetime,
	[Contract_TempPriceID] int,
	[IsReRent] bit,
	[IsContractDivideFee] bit
);

UPDATE [dbo].[Contract_RoomCharge] SET 
	[Contract_RoomCharge].[ContractID] = @ContractID,
	[Contract_RoomCharge].[RoomID] = @RoomID,
	[Contract_RoomCharge].[ChargeID] = @ChargeID,
	[Contract_RoomCharge].[RoomUnitPrice] = @RoomUnitPrice,
	[Contract_RoomCharge].[RoomStartTime] = @RoomStartTime,
	[Contract_RoomCharge].[RoomEndTime] = @RoomEndTime,
	[Contract_RoomCharge].[RoomNewEndTime] = @RoomNewEndTime,
	[Contract_RoomCharge].[RoomCost] = @RoomCost,
	[Contract_RoomCharge].[Remark] = @Remark,
	[Contract_RoomCharge].[AddTime] = @AddTime,
	[Contract_RoomCharge].[GUID] = @GUID,
	[Contract_RoomCharge].[RoomUseCount] = @RoomUseCount,
	[Contract_RoomCharge].[ReadyChargeTime] = @ReadyChargeTime,
	[Contract_RoomCharge].[Contract_TempPriceID] = @Contract_TempPriceID,
	[Contract_RoomCharge].[IsReRent] = @IsReRent,
	[Contract_RoomCharge].[IsContractDivideFee] = @IsContractDivideFee 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[RoomID],
	INSERTED.[ChargeID],
	INSERTED.[RoomUnitPrice],
	INSERTED.[RoomStartTime],
	INSERTED.[RoomEndTime],
	INSERTED.[RoomNewEndTime],
	INSERTED.[RoomCost],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[RoomUseCount],
	INSERTED.[ReadyChargeTime],
	INSERTED.[Contract_TempPriceID],
	INSERTED.[IsReRent],
	INSERTED.[IsContractDivideFee]
into @table
WHERE 
	[Contract_RoomCharge].[ID] = @ID

SELECT 
	[ID],
	[ContractID],
	[RoomID],
	[ChargeID],
	[RoomUnitPrice],
	[RoomStartTime],
	[RoomEndTime],
	[RoomNewEndTime],
	[RoomCost],
	[Remark],
	[AddTime],
	[GUID],
	[RoomUseCount],
	[ReadyChargeTime],
	[Contract_TempPriceID],
	[IsReRent],
	[IsContractDivideFee] 
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
DELETE FROM [dbo].[Contract_RoomCharge]
WHERE 
	[Contract_RoomCharge].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Contract_RoomCharge() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetContract_RoomCharge(this.ID));
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
	[Contract_RoomCharge].[ID],
	[Contract_RoomCharge].[ContractID],
	[Contract_RoomCharge].[RoomID],
	[Contract_RoomCharge].[ChargeID],
	[Contract_RoomCharge].[RoomUnitPrice],
	[Contract_RoomCharge].[RoomStartTime],
	[Contract_RoomCharge].[RoomEndTime],
	[Contract_RoomCharge].[RoomNewEndTime],
	[Contract_RoomCharge].[RoomCost],
	[Contract_RoomCharge].[Remark],
	[Contract_RoomCharge].[AddTime],
	[Contract_RoomCharge].[GUID],
	[Contract_RoomCharge].[RoomUseCount],
	[Contract_RoomCharge].[ReadyChargeTime],
	[Contract_RoomCharge].[Contract_TempPriceID],
	[Contract_RoomCharge].[IsReRent],
	[Contract_RoomCharge].[IsContractDivideFee]
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
                return "Contract_RoomCharge";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Contract_RoomCharge into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractID">contractID</param>
		/// <param name="roomID">roomID</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="roomUnitPrice">roomUnitPrice</param>
		/// <param name="roomStartTime">roomStartTime</param>
		/// <param name="roomEndTime">roomEndTime</param>
		/// <param name="roomNewEndTime">roomNewEndTime</param>
		/// <param name="roomCost">roomCost</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="roomUseCount">roomUseCount</param>
		/// <param name="readyChargeTime">readyChargeTime</param>
		/// <param name="contract_TempPriceID">contract_TempPriceID</param>
		/// <param name="isReRent">isReRent</param>
		/// <param name="isContractDivideFee">isContractDivideFee</param>
		public static void InsertContract_RoomCharge(int @contractID, int @roomID, int @chargeID, decimal @roomUnitPrice, DateTime @roomStartTime, DateTime @roomEndTime, DateTime @roomNewEndTime, decimal @roomCost, string @remark, DateTime @addTime, string @gUID, decimal @roomUseCount, DateTime @readyChargeTime, int @contract_TempPriceID, bool @isReRent, bool @isContractDivideFee)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertContract_RoomCharge(@contractID, @roomID, @chargeID, @roomUnitPrice, @roomStartTime, @roomEndTime, @roomNewEndTime, @roomCost, @remark, @addTime, @gUID, @roomUseCount, @readyChargeTime, @contract_TempPriceID, @isReRent, @isContractDivideFee, helper);
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
		/// Insert a Contract_RoomCharge into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractID">contractID</param>
		/// <param name="roomID">roomID</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="roomUnitPrice">roomUnitPrice</param>
		/// <param name="roomStartTime">roomStartTime</param>
		/// <param name="roomEndTime">roomEndTime</param>
		/// <param name="roomNewEndTime">roomNewEndTime</param>
		/// <param name="roomCost">roomCost</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="roomUseCount">roomUseCount</param>
		/// <param name="readyChargeTime">readyChargeTime</param>
		/// <param name="contract_TempPriceID">contract_TempPriceID</param>
		/// <param name="isReRent">isReRent</param>
		/// <param name="isContractDivideFee">isContractDivideFee</param>
		/// <param name="helper">helper</param>
		internal static void InsertContract_RoomCharge(int @contractID, int @roomID, int @chargeID, decimal @roomUnitPrice, DateTime @roomStartTime, DateTime @roomEndTime, DateTime @roomNewEndTime, decimal @roomCost, string @remark, DateTime @addTime, string @gUID, decimal @roomUseCount, DateTime @readyChargeTime, int @contract_TempPriceID, bool @isReRent, bool @isContractDivideFee, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractID] int,
	[RoomID] int,
	[ChargeID] int,
	[RoomUnitPrice] decimal(18, 4),
	[RoomStartTime] datetime,
	[RoomEndTime] datetime,
	[RoomNewEndTime] datetime,
	[RoomCost] decimal(18, 2),
	[Remark] ntext,
	[AddTime] datetime,
	[GUID] nvarchar(500),
	[RoomUseCount] decimal(18, 3),
	[ReadyChargeTime] datetime,
	[Contract_TempPriceID] int,
	[IsReRent] bit,
	[IsContractDivideFee] bit
);

INSERT INTO [dbo].[Contract_RoomCharge] (
	[Contract_RoomCharge].[ContractID],
	[Contract_RoomCharge].[RoomID],
	[Contract_RoomCharge].[ChargeID],
	[Contract_RoomCharge].[RoomUnitPrice],
	[Contract_RoomCharge].[RoomStartTime],
	[Contract_RoomCharge].[RoomEndTime],
	[Contract_RoomCharge].[RoomNewEndTime],
	[Contract_RoomCharge].[RoomCost],
	[Contract_RoomCharge].[Remark],
	[Contract_RoomCharge].[AddTime],
	[Contract_RoomCharge].[GUID],
	[Contract_RoomCharge].[RoomUseCount],
	[Contract_RoomCharge].[ReadyChargeTime],
	[Contract_RoomCharge].[Contract_TempPriceID],
	[Contract_RoomCharge].[IsReRent],
	[Contract_RoomCharge].[IsContractDivideFee]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[RoomID],
	INSERTED.[ChargeID],
	INSERTED.[RoomUnitPrice],
	INSERTED.[RoomStartTime],
	INSERTED.[RoomEndTime],
	INSERTED.[RoomNewEndTime],
	INSERTED.[RoomCost],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[RoomUseCount],
	INSERTED.[ReadyChargeTime],
	INSERTED.[Contract_TempPriceID],
	INSERTED.[IsReRent],
	INSERTED.[IsContractDivideFee]
into @table
VALUES ( 
	@ContractID,
	@RoomID,
	@ChargeID,
	@RoomUnitPrice,
	@RoomStartTime,
	@RoomEndTime,
	@RoomNewEndTime,
	@RoomCost,
	@Remark,
	@AddTime,
	@GUID,
	@RoomUseCount,
	@ReadyChargeTime,
	@Contract_TempPriceID,
	@IsReRent,
	@IsContractDivideFee 
); 

SELECT 
	[ID],
	[ContractID],
	[RoomID],
	[ChargeID],
	[RoomUnitPrice],
	[RoomStartTime],
	[RoomEndTime],
	[RoomNewEndTime],
	[RoomCost],
	[Remark],
	[AddTime],
	[GUID],
	[RoomUseCount],
	[ReadyChargeTime],
	[Contract_TempPriceID],
	[IsReRent],
	[IsContractDivideFee] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@RoomUnitPrice", EntityBase.GetDatabaseValue(@roomUnitPrice)));
			parameters.Add(new SqlParameter("@RoomStartTime", EntityBase.GetDatabaseValue(@roomStartTime)));
			parameters.Add(new SqlParameter("@RoomEndTime", EntityBase.GetDatabaseValue(@roomEndTime)));
			parameters.Add(new SqlParameter("@RoomNewEndTime", EntityBase.GetDatabaseValue(@roomNewEndTime)));
			parameters.Add(new SqlParameter("@RoomCost", EntityBase.GetDatabaseValue(@roomCost)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@RoomUseCount", EntityBase.GetDatabaseValue(@roomUseCount)));
			parameters.Add(new SqlParameter("@ReadyChargeTime", EntityBase.GetDatabaseValue(@readyChargeTime)));
			parameters.Add(new SqlParameter("@Contract_TempPriceID", EntityBase.GetDatabaseValue(@contract_TempPriceID)));
			parameters.Add(new SqlParameter("@IsReRent", @isReRent));
			parameters.Add(new SqlParameter("@IsContractDivideFee", @isContractDivideFee));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Contract_RoomCharge into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractID">contractID</param>
		/// <param name="roomID">roomID</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="roomUnitPrice">roomUnitPrice</param>
		/// <param name="roomStartTime">roomStartTime</param>
		/// <param name="roomEndTime">roomEndTime</param>
		/// <param name="roomNewEndTime">roomNewEndTime</param>
		/// <param name="roomCost">roomCost</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="roomUseCount">roomUseCount</param>
		/// <param name="readyChargeTime">readyChargeTime</param>
		/// <param name="contract_TempPriceID">contract_TempPriceID</param>
		/// <param name="isReRent">isReRent</param>
		/// <param name="isContractDivideFee">isContractDivideFee</param>
		public static void UpdateContract_RoomCharge(int @iD, int @contractID, int @roomID, int @chargeID, decimal @roomUnitPrice, DateTime @roomStartTime, DateTime @roomEndTime, DateTime @roomNewEndTime, decimal @roomCost, string @remark, DateTime @addTime, string @gUID, decimal @roomUseCount, DateTime @readyChargeTime, int @contract_TempPriceID, bool @isReRent, bool @isContractDivideFee)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateContract_RoomCharge(@iD, @contractID, @roomID, @chargeID, @roomUnitPrice, @roomStartTime, @roomEndTime, @roomNewEndTime, @roomCost, @remark, @addTime, @gUID, @roomUseCount, @readyChargeTime, @contract_TempPriceID, @isReRent, @isContractDivideFee, helper);
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
		/// Updates a Contract_RoomCharge into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractID">contractID</param>
		/// <param name="roomID">roomID</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="roomUnitPrice">roomUnitPrice</param>
		/// <param name="roomStartTime">roomStartTime</param>
		/// <param name="roomEndTime">roomEndTime</param>
		/// <param name="roomNewEndTime">roomNewEndTime</param>
		/// <param name="roomCost">roomCost</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="roomUseCount">roomUseCount</param>
		/// <param name="readyChargeTime">readyChargeTime</param>
		/// <param name="contract_TempPriceID">contract_TempPriceID</param>
		/// <param name="isReRent">isReRent</param>
		/// <param name="isContractDivideFee">isContractDivideFee</param>
		/// <param name="helper">helper</param>
		internal static void UpdateContract_RoomCharge(int @iD, int @contractID, int @roomID, int @chargeID, decimal @roomUnitPrice, DateTime @roomStartTime, DateTime @roomEndTime, DateTime @roomNewEndTime, decimal @roomCost, string @remark, DateTime @addTime, string @gUID, decimal @roomUseCount, DateTime @readyChargeTime, int @contract_TempPriceID, bool @isReRent, bool @isContractDivideFee, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractID] int,
	[RoomID] int,
	[ChargeID] int,
	[RoomUnitPrice] decimal(18, 4),
	[RoomStartTime] datetime,
	[RoomEndTime] datetime,
	[RoomNewEndTime] datetime,
	[RoomCost] decimal(18, 2),
	[Remark] ntext,
	[AddTime] datetime,
	[GUID] nvarchar(500),
	[RoomUseCount] decimal(18, 3),
	[ReadyChargeTime] datetime,
	[Contract_TempPriceID] int,
	[IsReRent] bit,
	[IsContractDivideFee] bit
);

UPDATE [dbo].[Contract_RoomCharge] SET 
	[Contract_RoomCharge].[ContractID] = @ContractID,
	[Contract_RoomCharge].[RoomID] = @RoomID,
	[Contract_RoomCharge].[ChargeID] = @ChargeID,
	[Contract_RoomCharge].[RoomUnitPrice] = @RoomUnitPrice,
	[Contract_RoomCharge].[RoomStartTime] = @RoomStartTime,
	[Contract_RoomCharge].[RoomEndTime] = @RoomEndTime,
	[Contract_RoomCharge].[RoomNewEndTime] = @RoomNewEndTime,
	[Contract_RoomCharge].[RoomCost] = @RoomCost,
	[Contract_RoomCharge].[Remark] = @Remark,
	[Contract_RoomCharge].[AddTime] = @AddTime,
	[Contract_RoomCharge].[GUID] = @GUID,
	[Contract_RoomCharge].[RoomUseCount] = @RoomUseCount,
	[Contract_RoomCharge].[ReadyChargeTime] = @ReadyChargeTime,
	[Contract_RoomCharge].[Contract_TempPriceID] = @Contract_TempPriceID,
	[Contract_RoomCharge].[IsReRent] = @IsReRent,
	[Contract_RoomCharge].[IsContractDivideFee] = @IsContractDivideFee 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[RoomID],
	INSERTED.[ChargeID],
	INSERTED.[RoomUnitPrice],
	INSERTED.[RoomStartTime],
	INSERTED.[RoomEndTime],
	INSERTED.[RoomNewEndTime],
	INSERTED.[RoomCost],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[RoomUseCount],
	INSERTED.[ReadyChargeTime],
	INSERTED.[Contract_TempPriceID],
	INSERTED.[IsReRent],
	INSERTED.[IsContractDivideFee]
into @table
WHERE 
	[Contract_RoomCharge].[ID] = @ID

SELECT 
	[ID],
	[ContractID],
	[RoomID],
	[ChargeID],
	[RoomUnitPrice],
	[RoomStartTime],
	[RoomEndTime],
	[RoomNewEndTime],
	[RoomCost],
	[Remark],
	[AddTime],
	[GUID],
	[RoomUseCount],
	[ReadyChargeTime],
	[Contract_TempPriceID],
	[IsReRent],
	[IsContractDivideFee] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@RoomUnitPrice", EntityBase.GetDatabaseValue(@roomUnitPrice)));
			parameters.Add(new SqlParameter("@RoomStartTime", EntityBase.GetDatabaseValue(@roomStartTime)));
			parameters.Add(new SqlParameter("@RoomEndTime", EntityBase.GetDatabaseValue(@roomEndTime)));
			parameters.Add(new SqlParameter("@RoomNewEndTime", EntityBase.GetDatabaseValue(@roomNewEndTime)));
			parameters.Add(new SqlParameter("@RoomCost", EntityBase.GetDatabaseValue(@roomCost)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@RoomUseCount", EntityBase.GetDatabaseValue(@roomUseCount)));
			parameters.Add(new SqlParameter("@ReadyChargeTime", EntityBase.GetDatabaseValue(@readyChargeTime)));
			parameters.Add(new SqlParameter("@Contract_TempPriceID", EntityBase.GetDatabaseValue(@contract_TempPriceID)));
			parameters.Add(new SqlParameter("@IsReRent", @isReRent));
			parameters.Add(new SqlParameter("@IsContractDivideFee", @isContractDivideFee));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Contract_RoomCharge from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteContract_RoomCharge(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteContract_RoomCharge(@iD, helper);
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
		/// Deletes a Contract_RoomCharge from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteContract_RoomCharge(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Contract_RoomCharge]
WHERE 
	[Contract_RoomCharge].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Contract_RoomCharge object.
		/// </summary>
		/// <returns>The newly created Contract_RoomCharge object.</returns>
		public static Contract_RoomCharge CreateContract_RoomCharge()
		{
			return InitializeNew<Contract_RoomCharge>();
		}
		
		/// <summary>
		/// Retrieve information for a Contract_RoomCharge by a Contract_RoomCharge's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Contract_RoomCharge</returns>
		public static Contract_RoomCharge GetContract_RoomCharge(int @iD)
		{
			string commandText = @"
SELECT 
" + Contract_RoomCharge.SelectFieldList + @"
FROM [dbo].[Contract_RoomCharge] 
WHERE 
	[Contract_RoomCharge].[ID] = @ID " + Contract_RoomCharge.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_RoomCharge>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Contract_RoomCharge by a Contract_RoomCharge's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Contract_RoomCharge</returns>
		public static Contract_RoomCharge GetContract_RoomCharge(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Contract_RoomCharge.SelectFieldList + @"
FROM [dbo].[Contract_RoomCharge] 
WHERE 
	[Contract_RoomCharge].[ID] = @ID " + Contract_RoomCharge.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_RoomCharge>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Contract_RoomCharge objects.
		/// </summary>
		/// <returns>The retrieved collection of Contract_RoomCharge objects.</returns>
		public static EntityList<Contract_RoomCharge> GetContract_RoomCharges()
		{
			string commandText = @"
SELECT " + Contract_RoomCharge.SelectFieldList + "FROM [dbo].[Contract_RoomCharge] " + Contract_RoomCharge.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Contract_RoomCharge>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Contract_RoomCharge objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_RoomCharge objects.</returns>
        public static EntityList<Contract_RoomCharge> GetContract_RoomCharges(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_RoomCharge>(SelectFieldList, "FROM [dbo].[Contract_RoomCharge]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Contract_RoomCharge objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_RoomCharge objects.</returns>
        public static EntityList<Contract_RoomCharge> GetContract_RoomCharges(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_RoomCharge>(SelectFieldList, "FROM [dbo].[Contract_RoomCharge]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Contract_RoomCharge objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Contract_RoomCharge objects.</returns>
		protected static EntityList<Contract_RoomCharge> GetContract_RoomCharges(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_RoomCharges(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Contract_RoomCharge objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_RoomCharge objects.</returns>
		protected static EntityList<Contract_RoomCharge> GetContract_RoomCharges(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_RoomCharges(string.Empty, where, parameters, Contract_RoomCharge.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_RoomCharge objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_RoomCharge objects.</returns>
		protected static EntityList<Contract_RoomCharge> GetContract_RoomCharges(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_RoomCharges(prefix, where, parameters, Contract_RoomCharge.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_RoomCharge objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_RoomCharge objects.</returns>
		protected static EntityList<Contract_RoomCharge> GetContract_RoomCharges(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_RoomCharges(string.Empty, where, parameters, Contract_RoomCharge.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_RoomCharge objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_RoomCharge objects.</returns>
		protected static EntityList<Contract_RoomCharge> GetContract_RoomCharges(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_RoomCharges(prefix, where, parameters, Contract_RoomCharge.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_RoomCharge objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Contract_RoomCharge objects.</returns>
		protected static EntityList<Contract_RoomCharge> GetContract_RoomCharges(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Contract_RoomCharge.SelectFieldList + "FROM [dbo].[Contract_RoomCharge] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Contract_RoomCharge>(reader);
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
        protected static EntityList<Contract_RoomCharge> GetContract_RoomCharges(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_RoomCharge>(SelectFieldList, "FROM [dbo].[Contract_RoomCharge] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Contract_RoomCharge objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_RoomChargeCount()
        {
            return GetContract_RoomChargeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Contract_RoomCharge objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_RoomChargeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Contract_RoomCharge] " + where;

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
		public static partial class Contract_RoomCharge_Properties
		{
			public const string ID = "ID";
			public const string ContractID = "ContractID";
			public const string RoomID = "RoomID";
			public const string ChargeID = "ChargeID";
			public const string RoomUnitPrice = "RoomUnitPrice";
			public const string RoomStartTime = "RoomStartTime";
			public const string RoomEndTime = "RoomEndTime";
			public const string RoomNewEndTime = "RoomNewEndTime";
			public const string RoomCost = "RoomCost";
			public const string Remark = "Remark";
			public const string AddTime = "AddTime";
			public const string GUID = "GUID";
			public const string RoomUseCount = "RoomUseCount";
			public const string ReadyChargeTime = "ReadyChargeTime";
			public const string Contract_TempPriceID = "Contract_TempPriceID";
			public const string IsReRent = "IsReRent";
			public const string IsContractDivideFee = "IsContractDivideFee";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ContractID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"ChargeID" , "int:"},
    			 {"RoomUnitPrice" , "decimal:"},
    			 {"RoomStartTime" , "DateTime:"},
    			 {"RoomEndTime" , "DateTime:"},
    			 {"RoomNewEndTime" , "DateTime:"},
    			 {"RoomCost" , "decimal:"},
    			 {"Remark" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"GUID" , "string:"},
    			 {"RoomUseCount" , "decimal:"},
    			 {"ReadyChargeTime" , "DateTime:"},
    			 {"Contract_TempPriceID" , "int:"},
    			 {"IsReRent" , "bool:"},
    			 {"IsContractDivideFee" , "bool:"},
            };
		}
		#endregion
	}
}
