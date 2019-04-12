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
	/// This object represents the properties and methods of a Contract_Divide.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Contract_Divide 
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
			set 
			{
				if (this._rentName != value) 
				{
					this._rentName = value;
					this.IsDirty = true;	
					OnPropertyChanged("RentName");
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
		[DataObjectField(false, false, true)]
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
		private string _divideType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DivideType
		{
			[DebuggerStepThrough()]
			get { return this._divideType; }
			set 
			{
				if (this._divideType != value) 
				{
					this._divideType = value;
					this.IsDirty = true;	
					OnPropertyChanged("DivideType");
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
		private decimal _sellCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal SellCost
		{
			[DebuggerStepThrough()]
			get { return this._sellCost; }
			set 
			{
				if (this._sellCost != value) 
				{
					this._sellCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("SellCost");
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
		private int _chargeStatus = int.MinValue;
		/// <summary>
		/// 0-未收 1-已收 2-草稿
		/// </summary>
        [Description("0-未收 1-已收 2-草稿")]
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
	[RentName] nvarchar(100),
	[WriteDate] datetime,
	[StartTime] datetime,
	[EndTime] datetime,
	[DivideType] nvarchar(100),
	[Remark] ntext,
	[SellCost] decimal(18, 2),
	[AddTime] datetime,
	[ChargeStatus] int,
	[ChargeID] int
);

INSERT INTO [dbo].[Contract_Divide] (
	[Contract_Divide].[ContractID],
	[Contract_Divide].[RentName],
	[Contract_Divide].[WriteDate],
	[Contract_Divide].[StartTime],
	[Contract_Divide].[EndTime],
	[Contract_Divide].[DivideType],
	[Contract_Divide].[Remark],
	[Contract_Divide].[SellCost],
	[Contract_Divide].[AddTime],
	[Contract_Divide].[ChargeStatus],
	[Contract_Divide].[ChargeID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[RentName],
	INSERTED.[WriteDate],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[DivideType],
	INSERTED.[Remark],
	INSERTED.[SellCost],
	INSERTED.[AddTime],
	INSERTED.[ChargeStatus],
	INSERTED.[ChargeID]
into @table
VALUES ( 
	@ContractID,
	@RentName,
	@WriteDate,
	@StartTime,
	@EndTime,
	@DivideType,
	@Remark,
	@SellCost,
	@AddTime,
	@ChargeStatus,
	@ChargeID 
); 

SELECT 
	[ID],
	[ContractID],
	[RentName],
	[WriteDate],
	[StartTime],
	[EndTime],
	[DivideType],
	[Remark],
	[SellCost],
	[AddTime],
	[ChargeStatus],
	[ChargeID] 
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
	[RentName] nvarchar(100),
	[WriteDate] datetime,
	[StartTime] datetime,
	[EndTime] datetime,
	[DivideType] nvarchar(100),
	[Remark] ntext,
	[SellCost] decimal(18, 2),
	[AddTime] datetime,
	[ChargeStatus] int,
	[ChargeID] int
);

UPDATE [dbo].[Contract_Divide] SET 
	[Contract_Divide].[ContractID] = @ContractID,
	[Contract_Divide].[RentName] = @RentName,
	[Contract_Divide].[WriteDate] = @WriteDate,
	[Contract_Divide].[StartTime] = @StartTime,
	[Contract_Divide].[EndTime] = @EndTime,
	[Contract_Divide].[DivideType] = @DivideType,
	[Contract_Divide].[Remark] = @Remark,
	[Contract_Divide].[SellCost] = @SellCost,
	[Contract_Divide].[AddTime] = @AddTime,
	[Contract_Divide].[ChargeStatus] = @ChargeStatus,
	[Contract_Divide].[ChargeID] = @ChargeID 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[RentName],
	INSERTED.[WriteDate],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[DivideType],
	INSERTED.[Remark],
	INSERTED.[SellCost],
	INSERTED.[AddTime],
	INSERTED.[ChargeStatus],
	INSERTED.[ChargeID]
into @table
WHERE 
	[Contract_Divide].[ID] = @ID

SELECT 
	[ID],
	[ContractID],
	[RentName],
	[WriteDate],
	[StartTime],
	[EndTime],
	[DivideType],
	[Remark],
	[SellCost],
	[AddTime],
	[ChargeStatus],
	[ChargeID] 
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
DELETE FROM [dbo].[Contract_Divide]
WHERE 
	[Contract_Divide].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Contract_Divide() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetContract_Divide(this.ID));
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
	[Contract_Divide].[ID],
	[Contract_Divide].[ContractID],
	[Contract_Divide].[RentName],
	[Contract_Divide].[WriteDate],
	[Contract_Divide].[StartTime],
	[Contract_Divide].[EndTime],
	[Contract_Divide].[DivideType],
	[Contract_Divide].[Remark],
	[Contract_Divide].[SellCost],
	[Contract_Divide].[AddTime],
	[Contract_Divide].[ChargeStatus],
	[Contract_Divide].[ChargeID]
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
                return "Contract_Divide";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Contract_Divide into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractID">contractID</param>
		/// <param name="rentName">rentName</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="divideType">divideType</param>
		/// <param name="remark">remark</param>
		/// <param name="sellCost">sellCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="chargeStatus">chargeStatus</param>
		/// <param name="chargeID">chargeID</param>
		public static void InsertContract_Divide(int @contractID, string @rentName, DateTime @writeDate, DateTime @startTime, DateTime @endTime, string @divideType, string @remark, decimal @sellCost, DateTime @addTime, int @chargeStatus, int @chargeID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertContract_Divide(@contractID, @rentName, @writeDate, @startTime, @endTime, @divideType, @remark, @sellCost, @addTime, @chargeStatus, @chargeID, helper);
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
		/// Insert a Contract_Divide into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractID">contractID</param>
		/// <param name="rentName">rentName</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="divideType">divideType</param>
		/// <param name="remark">remark</param>
		/// <param name="sellCost">sellCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="chargeStatus">chargeStatus</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="helper">helper</param>
		internal static void InsertContract_Divide(int @contractID, string @rentName, DateTime @writeDate, DateTime @startTime, DateTime @endTime, string @divideType, string @remark, decimal @sellCost, DateTime @addTime, int @chargeStatus, int @chargeID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractID] int,
	[RentName] nvarchar(100),
	[WriteDate] datetime,
	[StartTime] datetime,
	[EndTime] datetime,
	[DivideType] nvarchar(100),
	[Remark] ntext,
	[SellCost] decimal(18, 2),
	[AddTime] datetime,
	[ChargeStatus] int,
	[ChargeID] int
);

INSERT INTO [dbo].[Contract_Divide] (
	[Contract_Divide].[ContractID],
	[Contract_Divide].[RentName],
	[Contract_Divide].[WriteDate],
	[Contract_Divide].[StartTime],
	[Contract_Divide].[EndTime],
	[Contract_Divide].[DivideType],
	[Contract_Divide].[Remark],
	[Contract_Divide].[SellCost],
	[Contract_Divide].[AddTime],
	[Contract_Divide].[ChargeStatus],
	[Contract_Divide].[ChargeID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[RentName],
	INSERTED.[WriteDate],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[DivideType],
	INSERTED.[Remark],
	INSERTED.[SellCost],
	INSERTED.[AddTime],
	INSERTED.[ChargeStatus],
	INSERTED.[ChargeID]
into @table
VALUES ( 
	@ContractID,
	@RentName,
	@WriteDate,
	@StartTime,
	@EndTime,
	@DivideType,
	@Remark,
	@SellCost,
	@AddTime,
	@ChargeStatus,
	@ChargeID 
); 

SELECT 
	[ID],
	[ContractID],
	[RentName],
	[WriteDate],
	[StartTime],
	[EndTime],
	[DivideType],
	[Remark],
	[SellCost],
	[AddTime],
	[ChargeStatus],
	[ChargeID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@RentName", EntityBase.GetDatabaseValue(@rentName)));
			parameters.Add(new SqlParameter("@WriteDate", EntityBase.GetDatabaseValue(@writeDate)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@DivideType", EntityBase.GetDatabaseValue(@divideType)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@SellCost", EntityBase.GetDatabaseValue(@sellCost)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ChargeStatus", EntityBase.GetDatabaseValue(@chargeStatus)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Contract_Divide into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractID">contractID</param>
		/// <param name="rentName">rentName</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="divideType">divideType</param>
		/// <param name="remark">remark</param>
		/// <param name="sellCost">sellCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="chargeStatus">chargeStatus</param>
		/// <param name="chargeID">chargeID</param>
		public static void UpdateContract_Divide(int @iD, int @contractID, string @rentName, DateTime @writeDate, DateTime @startTime, DateTime @endTime, string @divideType, string @remark, decimal @sellCost, DateTime @addTime, int @chargeStatus, int @chargeID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateContract_Divide(@iD, @contractID, @rentName, @writeDate, @startTime, @endTime, @divideType, @remark, @sellCost, @addTime, @chargeStatus, @chargeID, helper);
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
		/// Updates a Contract_Divide into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractID">contractID</param>
		/// <param name="rentName">rentName</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="divideType">divideType</param>
		/// <param name="remark">remark</param>
		/// <param name="sellCost">sellCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="chargeStatus">chargeStatus</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateContract_Divide(int @iD, int @contractID, string @rentName, DateTime @writeDate, DateTime @startTime, DateTime @endTime, string @divideType, string @remark, decimal @sellCost, DateTime @addTime, int @chargeStatus, int @chargeID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractID] int,
	[RentName] nvarchar(100),
	[WriteDate] datetime,
	[StartTime] datetime,
	[EndTime] datetime,
	[DivideType] nvarchar(100),
	[Remark] ntext,
	[SellCost] decimal(18, 2),
	[AddTime] datetime,
	[ChargeStatus] int,
	[ChargeID] int
);

UPDATE [dbo].[Contract_Divide] SET 
	[Contract_Divide].[ContractID] = @ContractID,
	[Contract_Divide].[RentName] = @RentName,
	[Contract_Divide].[WriteDate] = @WriteDate,
	[Contract_Divide].[StartTime] = @StartTime,
	[Contract_Divide].[EndTime] = @EndTime,
	[Contract_Divide].[DivideType] = @DivideType,
	[Contract_Divide].[Remark] = @Remark,
	[Contract_Divide].[SellCost] = @SellCost,
	[Contract_Divide].[AddTime] = @AddTime,
	[Contract_Divide].[ChargeStatus] = @ChargeStatus,
	[Contract_Divide].[ChargeID] = @ChargeID 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[RentName],
	INSERTED.[WriteDate],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[DivideType],
	INSERTED.[Remark],
	INSERTED.[SellCost],
	INSERTED.[AddTime],
	INSERTED.[ChargeStatus],
	INSERTED.[ChargeID]
into @table
WHERE 
	[Contract_Divide].[ID] = @ID

SELECT 
	[ID],
	[ContractID],
	[RentName],
	[WriteDate],
	[StartTime],
	[EndTime],
	[DivideType],
	[Remark],
	[SellCost],
	[AddTime],
	[ChargeStatus],
	[ChargeID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@RentName", EntityBase.GetDatabaseValue(@rentName)));
			parameters.Add(new SqlParameter("@WriteDate", EntityBase.GetDatabaseValue(@writeDate)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@DivideType", EntityBase.GetDatabaseValue(@divideType)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@SellCost", EntityBase.GetDatabaseValue(@sellCost)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ChargeStatus", EntityBase.GetDatabaseValue(@chargeStatus)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Contract_Divide from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteContract_Divide(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteContract_Divide(@iD, helper);
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
		/// Deletes a Contract_Divide from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteContract_Divide(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Contract_Divide]
WHERE 
	[Contract_Divide].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Contract_Divide object.
		/// </summary>
		/// <returns>The newly created Contract_Divide object.</returns>
		public static Contract_Divide CreateContract_Divide()
		{
			return InitializeNew<Contract_Divide>();
		}
		
		/// <summary>
		/// Retrieve information for a Contract_Divide by a Contract_Divide's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Contract_Divide</returns>
		public static Contract_Divide GetContract_Divide(int @iD)
		{
			string commandText = @"
SELECT 
" + Contract_Divide.SelectFieldList + @"
FROM [dbo].[Contract_Divide] 
WHERE 
	[Contract_Divide].[ID] = @ID " + Contract_Divide.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_Divide>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Contract_Divide by a Contract_Divide's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Contract_Divide</returns>
		public static Contract_Divide GetContract_Divide(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Contract_Divide.SelectFieldList + @"
FROM [dbo].[Contract_Divide] 
WHERE 
	[Contract_Divide].[ID] = @ID " + Contract_Divide.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_Divide>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Contract_Divide objects.
		/// </summary>
		/// <returns>The retrieved collection of Contract_Divide objects.</returns>
		public static EntityList<Contract_Divide> GetContract_Divides()
		{
			string commandText = @"
SELECT " + Contract_Divide.SelectFieldList + "FROM [dbo].[Contract_Divide] " + Contract_Divide.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Contract_Divide>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Contract_Divide objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_Divide objects.</returns>
        public static EntityList<Contract_Divide> GetContract_Divides(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Divide>(SelectFieldList, "FROM [dbo].[Contract_Divide]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Contract_Divide objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_Divide objects.</returns>
        public static EntityList<Contract_Divide> GetContract_Divides(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Divide>(SelectFieldList, "FROM [dbo].[Contract_Divide]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Contract_Divide objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Contract_Divide objects.</returns>
		protected static EntityList<Contract_Divide> GetContract_Divides(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Divides(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Contract_Divide objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_Divide objects.</returns>
		protected static EntityList<Contract_Divide> GetContract_Divides(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Divides(string.Empty, where, parameters, Contract_Divide.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Divide objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_Divide objects.</returns>
		protected static EntityList<Contract_Divide> GetContract_Divides(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Divides(prefix, where, parameters, Contract_Divide.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Divide objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_Divide objects.</returns>
		protected static EntityList<Contract_Divide> GetContract_Divides(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_Divides(string.Empty, where, parameters, Contract_Divide.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Divide objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_Divide objects.</returns>
		protected static EntityList<Contract_Divide> GetContract_Divides(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_Divides(prefix, where, parameters, Contract_Divide.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Divide objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Contract_Divide objects.</returns>
		protected static EntityList<Contract_Divide> GetContract_Divides(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Contract_Divide.SelectFieldList + "FROM [dbo].[Contract_Divide] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Contract_Divide>(reader);
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
        protected static EntityList<Contract_Divide> GetContract_Divides(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Divide>(SelectFieldList, "FROM [dbo].[Contract_Divide] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Contract_Divide objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_DivideCount()
        {
            return GetContract_DivideCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Contract_Divide objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_DivideCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Contract_Divide] " + where;

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
		public static partial class Contract_Divide_Properties
		{
			public const string ID = "ID";
			public const string ContractID = "ContractID";
			public const string RentName = "RentName";
			public const string WriteDate = "WriteDate";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string DivideType = "DivideType";
			public const string Remark = "Remark";
			public const string SellCost = "SellCost";
			public const string AddTime = "AddTime";
			public const string ChargeStatus = "ChargeStatus";
			public const string ChargeID = "ChargeID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ContractID" , "int:"},
    			 {"RentName" , "string:"},
    			 {"WriteDate" , "DateTime:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"DivideType" , "string:"},
    			 {"Remark" , "string:"},
    			 {"SellCost" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"ChargeStatus" , "int:0-未收 1-已收 2-草稿"},
    			 {"ChargeID" , "int:"},
            };
		}
		#endregion
	}
}
