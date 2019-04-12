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
	/// This object represents the properties and methods of a PrintHistory.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class PrintHistory 
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
		private decimal _cost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
		private string _costCapital = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CostCapital
		{
			[DebuggerStepThrough()]
			get { return this._costCapital; }
			set 
			{
				if (this._costCapital != value) 
				{
					this._costCapital = value;
					this.IsDirty = true;	
					OnPropertyChanged("CostCapital");
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
		private string _printNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PrintNumber
		{
			[DebuggerStepThrough()]
			get { return this._printNumber; }
			set 
			{
				if (this._printNumber != value) 
				{
					this._printNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeMan
		{
			[DebuggerStepThrough()]
			get { return this._chargeMan; }
			set 
			{
				if (this._chargeMan != value) 
				{
					this._chargeMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _chargeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ChargeTime
		{
			[DebuggerStepThrough()]
			get { return this._chargeTime; }
			set 
			{
				if (this._chargeTime != value) 
				{
					this._chargeTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chageType1 = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChageType1
		{
			[DebuggerStepThrough()]
			get { return this._chageType1; }
			set 
			{
				if (this._chageType1 != value) 
				{
					this._chageType1 = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChageType1");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isCancel = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsCancel
		{
			[DebuggerStepThrough()]
			get { return this._isCancel; }
			set 
			{
				if (this._isCancel != value) 
				{
					this._isCancel = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsCancel");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chageType2 = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChageType2
		{
			[DebuggerStepThrough()]
			get { return this._chageType2; }
			set 
			{
				if (this._chageType2 != value) 
				{
					this._chageType2 = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChageType2");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _cancelMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CancelMan
		{
			[DebuggerStepThrough()]
			get { return this._cancelMan; }
			set 
			{
				if (this._cancelMan != value) 
				{
					this._cancelMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("CancelMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _cancelTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime CancelTime
		{
			[DebuggerStepThrough()]
			get { return this._cancelTime; }
			set 
			{
				if (this._cancelTime != value) 
				{
					this._cancelTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("CancelTime");
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
	[Cost] decimal(18, 2),
	[CostCapital] nvarchar(100),
	[Remark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime,
	[PrintNumber] nvarchar(100),
	[ChargeMan] nvarchar(50),
	[ChargeTime] datetime,
	[ChageType1] int,
	[IsCancel] bit,
	[ChageType2] int,
	[CancelMan] nvarchar(50),
	[CancelTime] datetime,
	[TradeNo] nvarchar(500)
);

INSERT INTO [dbo].[PrintHistory] (
	[PrintHistory].[Cost],
	[PrintHistory].[CostCapital],
	[PrintHistory].[Remark],
	[PrintHistory].[AddMan],
	[PrintHistory].[AddTime],
	[PrintHistory].[PrintNumber],
	[PrintHistory].[ChargeMan],
	[PrintHistory].[ChargeTime],
	[PrintHistory].[ChageType1],
	[PrintHistory].[IsCancel],
	[PrintHistory].[ChageType2],
	[PrintHistory].[CancelMan],
	[PrintHistory].[CancelTime],
	[PrintHistory].[TradeNo]
) 
output 
	INSERTED.[ID],
	INSERTED.[Cost],
	INSERTED.[CostCapital],
	INSERTED.[Remark],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[PrintNumber],
	INSERTED.[ChargeMan],
	INSERTED.[ChargeTime],
	INSERTED.[ChageType1],
	INSERTED.[IsCancel],
	INSERTED.[ChageType2],
	INSERTED.[CancelMan],
	INSERTED.[CancelTime],
	INSERTED.[TradeNo]
into @table
VALUES ( 
	@Cost,
	@CostCapital,
	@Remark,
	@AddMan,
	@AddTime,
	@PrintNumber,
	@ChargeMan,
	@ChargeTime,
	@ChageType1,
	@IsCancel,
	@ChageType2,
	@CancelMan,
	@CancelTime,
	@TradeNo 
); 

SELECT 
	[ID],
	[Cost],
	[CostCapital],
	[Remark],
	[AddMan],
	[AddTime],
	[PrintNumber],
	[ChargeMan],
	[ChargeTime],
	[ChageType1],
	[IsCancel],
	[ChageType2],
	[CancelMan],
	[CancelTime],
	[TradeNo] 
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
	[Cost] decimal(18, 2),
	[CostCapital] nvarchar(100),
	[Remark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime,
	[PrintNumber] nvarchar(100),
	[ChargeMan] nvarchar(50),
	[ChargeTime] datetime,
	[ChageType1] int,
	[IsCancel] bit,
	[ChageType2] int,
	[CancelMan] nvarchar(50),
	[CancelTime] datetime,
	[TradeNo] nvarchar(500)
);

UPDATE [dbo].[PrintHistory] SET 
	[PrintHistory].[Cost] = @Cost,
	[PrintHistory].[CostCapital] = @CostCapital,
	[PrintHistory].[Remark] = @Remark,
	[PrintHistory].[AddMan] = @AddMan,
	[PrintHistory].[AddTime] = @AddTime,
	[PrintHistory].[PrintNumber] = @PrintNumber,
	[PrintHistory].[ChargeMan] = @ChargeMan,
	[PrintHistory].[ChargeTime] = @ChargeTime,
	[PrintHistory].[ChageType1] = @ChageType1,
	[PrintHistory].[IsCancel] = @IsCancel,
	[PrintHistory].[ChageType2] = @ChageType2,
	[PrintHistory].[CancelMan] = @CancelMan,
	[PrintHistory].[CancelTime] = @CancelTime,
	[PrintHistory].[TradeNo] = @TradeNo 
output 
	INSERTED.[ID],
	INSERTED.[Cost],
	INSERTED.[CostCapital],
	INSERTED.[Remark],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[PrintNumber],
	INSERTED.[ChargeMan],
	INSERTED.[ChargeTime],
	INSERTED.[ChageType1],
	INSERTED.[IsCancel],
	INSERTED.[ChageType2],
	INSERTED.[CancelMan],
	INSERTED.[CancelTime],
	INSERTED.[TradeNo]
into @table
WHERE 
	[PrintHistory].[ID] = @ID

SELECT 
	[ID],
	[Cost],
	[CostCapital],
	[Remark],
	[AddMan],
	[AddTime],
	[PrintNumber],
	[ChargeMan],
	[ChargeTime],
	[ChageType1],
	[IsCancel],
	[ChageType2],
	[CancelMan],
	[CancelTime],
	[TradeNo] 
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
DELETE FROM [dbo].[PrintHistory]
WHERE 
	[PrintHistory].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public PrintHistory() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetPrintHistory(this.ID));
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
	[PrintHistory].[ID],
	[PrintHistory].[Cost],
	[PrintHistory].[CostCapital],
	[PrintHistory].[Remark],
	[PrintHistory].[AddMan],
	[PrintHistory].[AddTime],
	[PrintHistory].[PrintNumber],
	[PrintHistory].[ChargeMan],
	[PrintHistory].[ChargeTime],
	[PrintHistory].[ChageType1],
	[PrintHistory].[IsCancel],
	[PrintHistory].[ChageType2],
	[PrintHistory].[CancelMan],
	[PrintHistory].[CancelTime],
	[PrintHistory].[TradeNo]
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
                return "PrintHistory";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a PrintHistory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="cost">cost</param>
		/// <param name="costCapital">costCapital</param>
		/// <param name="remark">remark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="printNumber">printNumber</param>
		/// <param name="chargeMan">chargeMan</param>
		/// <param name="chargeTime">chargeTime</param>
		/// <param name="chageType1">chageType1</param>
		/// <param name="isCancel">isCancel</param>
		/// <param name="chageType2">chageType2</param>
		/// <param name="cancelMan">cancelMan</param>
		/// <param name="cancelTime">cancelTime</param>
		/// <param name="tradeNo">tradeNo</param>
		public static void InsertPrintHistory(decimal @cost, string @costCapital, string @remark, string @addMan, DateTime @addTime, string @printNumber, string @chargeMan, DateTime @chargeTime, int @chageType1, bool @isCancel, int @chageType2, string @cancelMan, DateTime @cancelTime, string @tradeNo)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertPrintHistory(@cost, @costCapital, @remark, @addMan, @addTime, @printNumber, @chargeMan, @chargeTime, @chageType1, @isCancel, @chageType2, @cancelMan, @cancelTime, @tradeNo, helper);
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
		/// Insert a PrintHistory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="cost">cost</param>
		/// <param name="costCapital">costCapital</param>
		/// <param name="remark">remark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="printNumber">printNumber</param>
		/// <param name="chargeMan">chargeMan</param>
		/// <param name="chargeTime">chargeTime</param>
		/// <param name="chageType1">chageType1</param>
		/// <param name="isCancel">isCancel</param>
		/// <param name="chageType2">chageType2</param>
		/// <param name="cancelMan">cancelMan</param>
		/// <param name="cancelTime">cancelTime</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="helper">helper</param>
		internal static void InsertPrintHistory(decimal @cost, string @costCapital, string @remark, string @addMan, DateTime @addTime, string @printNumber, string @chargeMan, DateTime @chargeTime, int @chageType1, bool @isCancel, int @chageType2, string @cancelMan, DateTime @cancelTime, string @tradeNo, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Cost] decimal(18, 2),
	[CostCapital] nvarchar(100),
	[Remark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime,
	[PrintNumber] nvarchar(100),
	[ChargeMan] nvarchar(50),
	[ChargeTime] datetime,
	[ChageType1] int,
	[IsCancel] bit,
	[ChageType2] int,
	[CancelMan] nvarchar(50),
	[CancelTime] datetime,
	[TradeNo] nvarchar(500)
);

INSERT INTO [dbo].[PrintHistory] (
	[PrintHistory].[Cost],
	[PrintHistory].[CostCapital],
	[PrintHistory].[Remark],
	[PrintHistory].[AddMan],
	[PrintHistory].[AddTime],
	[PrintHistory].[PrintNumber],
	[PrintHistory].[ChargeMan],
	[PrintHistory].[ChargeTime],
	[PrintHistory].[ChageType1],
	[PrintHistory].[IsCancel],
	[PrintHistory].[ChageType2],
	[PrintHistory].[CancelMan],
	[PrintHistory].[CancelTime],
	[PrintHistory].[TradeNo]
) 
output 
	INSERTED.[ID],
	INSERTED.[Cost],
	INSERTED.[CostCapital],
	INSERTED.[Remark],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[PrintNumber],
	INSERTED.[ChargeMan],
	INSERTED.[ChargeTime],
	INSERTED.[ChageType1],
	INSERTED.[IsCancel],
	INSERTED.[ChageType2],
	INSERTED.[CancelMan],
	INSERTED.[CancelTime],
	INSERTED.[TradeNo]
into @table
VALUES ( 
	@Cost,
	@CostCapital,
	@Remark,
	@AddMan,
	@AddTime,
	@PrintNumber,
	@ChargeMan,
	@ChargeTime,
	@ChageType1,
	@IsCancel,
	@ChageType2,
	@CancelMan,
	@CancelTime,
	@TradeNo 
); 

SELECT 
	[ID],
	[Cost],
	[CostCapital],
	[Remark],
	[AddMan],
	[AddTime],
	[PrintNumber],
	[ChargeMan],
	[ChargeTime],
	[ChageType1],
	[IsCancel],
	[ChageType2],
	[CancelMan],
	[CancelTime],
	[TradeNo] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Cost", EntityBase.GetDatabaseValue(@cost)));
			parameters.Add(new SqlParameter("@CostCapital", EntityBase.GetDatabaseValue(@costCapital)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@PrintNumber", EntityBase.GetDatabaseValue(@printNumber)));
			parameters.Add(new SqlParameter("@ChargeMan", EntityBase.GetDatabaseValue(@chargeMan)));
			parameters.Add(new SqlParameter("@ChargeTime", EntityBase.GetDatabaseValue(@chargeTime)));
			parameters.Add(new SqlParameter("@ChageType1", EntityBase.GetDatabaseValue(@chageType1)));
			parameters.Add(new SqlParameter("@IsCancel", @isCancel));
			parameters.Add(new SqlParameter("@ChageType2", EntityBase.GetDatabaseValue(@chageType2)));
			parameters.Add(new SqlParameter("@CancelMan", EntityBase.GetDatabaseValue(@cancelMan)));
			parameters.Add(new SqlParameter("@CancelTime", EntityBase.GetDatabaseValue(@cancelTime)));
			parameters.Add(new SqlParameter("@TradeNo", EntityBase.GetDatabaseValue(@tradeNo)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a PrintHistory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="cost">cost</param>
		/// <param name="costCapital">costCapital</param>
		/// <param name="remark">remark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="printNumber">printNumber</param>
		/// <param name="chargeMan">chargeMan</param>
		/// <param name="chargeTime">chargeTime</param>
		/// <param name="chageType1">chageType1</param>
		/// <param name="isCancel">isCancel</param>
		/// <param name="chageType2">chageType2</param>
		/// <param name="cancelMan">cancelMan</param>
		/// <param name="cancelTime">cancelTime</param>
		/// <param name="tradeNo">tradeNo</param>
		public static void UpdatePrintHistory(int @iD, decimal @cost, string @costCapital, string @remark, string @addMan, DateTime @addTime, string @printNumber, string @chargeMan, DateTime @chargeTime, int @chageType1, bool @isCancel, int @chageType2, string @cancelMan, DateTime @cancelTime, string @tradeNo)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdatePrintHistory(@iD, @cost, @costCapital, @remark, @addMan, @addTime, @printNumber, @chargeMan, @chargeTime, @chageType1, @isCancel, @chageType2, @cancelMan, @cancelTime, @tradeNo, helper);
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
		/// Updates a PrintHistory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="cost">cost</param>
		/// <param name="costCapital">costCapital</param>
		/// <param name="remark">remark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="printNumber">printNumber</param>
		/// <param name="chargeMan">chargeMan</param>
		/// <param name="chargeTime">chargeTime</param>
		/// <param name="chageType1">chageType1</param>
		/// <param name="isCancel">isCancel</param>
		/// <param name="chageType2">chageType2</param>
		/// <param name="cancelMan">cancelMan</param>
		/// <param name="cancelTime">cancelTime</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="helper">helper</param>
		internal static void UpdatePrintHistory(int @iD, decimal @cost, string @costCapital, string @remark, string @addMan, DateTime @addTime, string @printNumber, string @chargeMan, DateTime @chargeTime, int @chageType1, bool @isCancel, int @chageType2, string @cancelMan, DateTime @cancelTime, string @tradeNo, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Cost] decimal(18, 2),
	[CostCapital] nvarchar(100),
	[Remark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime,
	[PrintNumber] nvarchar(100),
	[ChargeMan] nvarchar(50),
	[ChargeTime] datetime,
	[ChageType1] int,
	[IsCancel] bit,
	[ChageType2] int,
	[CancelMan] nvarchar(50),
	[CancelTime] datetime,
	[TradeNo] nvarchar(500)
);

UPDATE [dbo].[PrintHistory] SET 
	[PrintHistory].[Cost] = @Cost,
	[PrintHistory].[CostCapital] = @CostCapital,
	[PrintHistory].[Remark] = @Remark,
	[PrintHistory].[AddMan] = @AddMan,
	[PrintHistory].[AddTime] = @AddTime,
	[PrintHistory].[PrintNumber] = @PrintNumber,
	[PrintHistory].[ChargeMan] = @ChargeMan,
	[PrintHistory].[ChargeTime] = @ChargeTime,
	[PrintHistory].[ChageType1] = @ChageType1,
	[PrintHistory].[IsCancel] = @IsCancel,
	[PrintHistory].[ChageType2] = @ChageType2,
	[PrintHistory].[CancelMan] = @CancelMan,
	[PrintHistory].[CancelTime] = @CancelTime,
	[PrintHistory].[TradeNo] = @TradeNo 
output 
	INSERTED.[ID],
	INSERTED.[Cost],
	INSERTED.[CostCapital],
	INSERTED.[Remark],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[PrintNumber],
	INSERTED.[ChargeMan],
	INSERTED.[ChargeTime],
	INSERTED.[ChageType1],
	INSERTED.[IsCancel],
	INSERTED.[ChageType2],
	INSERTED.[CancelMan],
	INSERTED.[CancelTime],
	INSERTED.[TradeNo]
into @table
WHERE 
	[PrintHistory].[ID] = @ID

SELECT 
	[ID],
	[Cost],
	[CostCapital],
	[Remark],
	[AddMan],
	[AddTime],
	[PrintNumber],
	[ChargeMan],
	[ChargeTime],
	[ChageType1],
	[IsCancel],
	[ChageType2],
	[CancelMan],
	[CancelTime],
	[TradeNo] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Cost", EntityBase.GetDatabaseValue(@cost)));
			parameters.Add(new SqlParameter("@CostCapital", EntityBase.GetDatabaseValue(@costCapital)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@PrintNumber", EntityBase.GetDatabaseValue(@printNumber)));
			parameters.Add(new SqlParameter("@ChargeMan", EntityBase.GetDatabaseValue(@chargeMan)));
			parameters.Add(new SqlParameter("@ChargeTime", EntityBase.GetDatabaseValue(@chargeTime)));
			parameters.Add(new SqlParameter("@ChageType1", EntityBase.GetDatabaseValue(@chageType1)));
			parameters.Add(new SqlParameter("@IsCancel", @isCancel));
			parameters.Add(new SqlParameter("@ChageType2", EntityBase.GetDatabaseValue(@chageType2)));
			parameters.Add(new SqlParameter("@CancelMan", EntityBase.GetDatabaseValue(@cancelMan)));
			parameters.Add(new SqlParameter("@CancelTime", EntityBase.GetDatabaseValue(@cancelTime)));
			parameters.Add(new SqlParameter("@TradeNo", EntityBase.GetDatabaseValue(@tradeNo)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a PrintHistory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeletePrintHistory(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeletePrintHistory(@iD, helper);
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
		/// Deletes a PrintHistory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeletePrintHistory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[PrintHistory]
WHERE 
	[PrintHistory].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new PrintHistory object.
		/// </summary>
		/// <returns>The newly created PrintHistory object.</returns>
		public static PrintHistory CreatePrintHistory()
		{
			return InitializeNew<PrintHistory>();
		}
		
		/// <summary>
		/// Retrieve information for a PrintHistory by a PrintHistory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>PrintHistory</returns>
		public static PrintHistory GetPrintHistory(int @iD)
		{
			string commandText = @"
SELECT 
" + PrintHistory.SelectFieldList + @"
FROM [dbo].[PrintHistory] 
WHERE 
	[PrintHistory].[ID] = @ID " + PrintHistory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<PrintHistory>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a PrintHistory by a PrintHistory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>PrintHistory</returns>
		public static PrintHistory GetPrintHistory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + PrintHistory.SelectFieldList + @"
FROM [dbo].[PrintHistory] 
WHERE 
	[PrintHistory].[ID] = @ID " + PrintHistory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<PrintHistory>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection PrintHistory objects.
		/// </summary>
		/// <returns>The retrieved collection of PrintHistory objects.</returns>
		public static EntityList<PrintHistory> GetPrintHistories()
		{
			string commandText = @"
SELECT " + PrintHistory.SelectFieldList + "FROM [dbo].[PrintHistory] " + PrintHistory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<PrintHistory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection PrintHistory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of PrintHistory objects.</returns>
        public static EntityList<PrintHistory> GetPrintHistories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PrintHistory>(SelectFieldList, "FROM [dbo].[PrintHistory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection PrintHistory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of PrintHistory objects.</returns>
        public static EntityList<PrintHistory> GetPrintHistories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PrintHistory>(SelectFieldList, "FROM [dbo].[PrintHistory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection PrintHistory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of PrintHistory objects.</returns>
		protected static EntityList<PrintHistory> GetPrintHistories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPrintHistories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection PrintHistory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of PrintHistory objects.</returns>
		protected static EntityList<PrintHistory> GetPrintHistories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPrintHistories(string.Empty, where, parameters, PrintHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PrintHistory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of PrintHistory objects.</returns>
		protected static EntityList<PrintHistory> GetPrintHistories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPrintHistories(prefix, where, parameters, PrintHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PrintHistory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of PrintHistory objects.</returns>
		protected static EntityList<PrintHistory> GetPrintHistories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetPrintHistories(string.Empty, where, parameters, PrintHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PrintHistory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of PrintHistory objects.</returns>
		protected static EntityList<PrintHistory> GetPrintHistories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetPrintHistories(prefix, where, parameters, PrintHistory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PrintHistory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of PrintHistory objects.</returns>
		protected static EntityList<PrintHistory> GetPrintHistories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + PrintHistory.SelectFieldList + "FROM [dbo].[PrintHistory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<PrintHistory>(reader);
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
        protected static EntityList<PrintHistory> GetPrintHistories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PrintHistory>(SelectFieldList, "FROM [dbo].[PrintHistory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of PrintHistory objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetPrintHistoryCount()
        {
            return GetPrintHistoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of PrintHistory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetPrintHistoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[PrintHistory] " + where;

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
		public static partial class PrintHistory_Properties
		{
			public const string ID = "ID";
			public const string Cost = "Cost";
			public const string CostCapital = "CostCapital";
			public const string Remark = "Remark";
			public const string AddMan = "AddMan";
			public const string AddTime = "AddTime";
			public const string PrintNumber = "PrintNumber";
			public const string ChargeMan = "ChargeMan";
			public const string ChargeTime = "ChargeTime";
			public const string ChageType1 = "ChageType1";
			public const string IsCancel = "IsCancel";
			public const string ChageType2 = "ChageType2";
			public const string CancelMan = "CancelMan";
			public const string CancelTime = "CancelTime";
			public const string TradeNo = "TradeNo";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Cost" , "decimal:"},
    			 {"CostCapital" , "string:"},
    			 {"Remark" , "string:"},
    			 {"AddMan" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"PrintNumber" , "string:"},
    			 {"ChargeMan" , "string:"},
    			 {"ChargeTime" , "DateTime:"},
    			 {"ChageType1" , "int:"},
    			 {"IsCancel" , "bool:"},
    			 {"ChageType2" , "int:"},
    			 {"CancelMan" , "string:"},
    			 {"CancelTime" , "DateTime:"},
    			 {"TradeNo" , "string:"},
            };
		}
		#endregion
	}
}
