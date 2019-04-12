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
	/// This object represents the properties and methods of a Cheque_Confirm.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_Confirm 
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
		private int _summaryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int SummaryID
		{
			[DebuggerStepThrough()]
			get { return this._summaryID; }
			set 
			{
				if (this._summaryID != value) 
				{
					this._summaryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("SummaryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _takeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime TakeTime
		{
			[DebuggerStepThrough()]
			get { return this._takeTime; }
			set 
			{
				if (this._takeTime != value) 
				{
					this._takeTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("TakeTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _takeUser = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TakeUser
		{
			[DebuggerStepThrough()]
			get { return this._takeUser; }
			set 
			{
				if (this._takeUser != value) 
				{
					this._takeUser = value;
					this.IsDirty = true;	
					OnPropertyChanged("TakeUser");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _takeStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TakeStatus
		{
			[DebuggerStepThrough()]
			get { return this._takeStatus; }
			set 
			{
				if (this._takeStatus != value) 
				{
					this._takeStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("TakeStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _takeRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TakeRemark
		{
			[DebuggerStepThrough()]
			get { return this._takeRemark; }
			set 
			{
				if (this._takeRemark != value) 
				{
					this._takeRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("TakeRemark");
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
		private int _approveStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ApproveStatus
		{
			[DebuggerStepThrough()]
			get { return this._approveStatus; }
			set 
			{
				if (this._approveStatus != value) 
				{
					this._approveStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveStatus");
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
		private string _approveMethod = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveMethod
		{
			[DebuggerStepThrough()]
			get { return this._approveMethod; }
			set 
			{
				if (this._approveMethod != value) 
				{
					this._approveMethod = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveMethod");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveMonth = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveMonth
		{
			[DebuggerStepThrough()]
			get { return this._approveMonth; }
			set 
			{
				if (this._approveMonth != value) 
				{
					this._approveMonth = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveMonth");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _transferTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime TransferTime
		{
			[DebuggerStepThrough()]
			get { return this._transferTime; }
			set 
			{
				if (this._transferTime != value) 
				{
					this._transferTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("TransferTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _transferMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TransferMan
		{
			[DebuggerStepThrough()]
			get { return this._transferMan; }
			set 
			{
				if (this._transferMan != value) 
				{
					this._transferMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("TransferMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _transferRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TransferRemark
		{
			[DebuggerStepThrough()]
			get { return this._transferRemark; }
			set 
			{
				if (this._transferRemark != value) 
				{
					this._transferRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("TransferRemark");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _transferStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TransferStatus
		{
			[DebuggerStepThrough()]
			get { return this._transferStatus; }
			set 
			{
				if (this._transferStatus != value) 
				{
					this._transferStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("TransferStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _transferMoney = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TransferMoney
		{
			[DebuggerStepThrough()]
			get { return this._transferMoney; }
			set 
			{
				if (this._transferMoney != value) 
				{
					this._transferMoney = value;
					this.IsDirty = true;	
					OnPropertyChanged("TransferMoney");
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
	[SummaryID] int,
	[TakeTime] datetime,
	[TakeUser] nvarchar(100),
	[TakeStatus] int,
	[TakeRemark] ntext,
	[ApproveTime] datetime,
	[ApproveMan] nvarchar(100),
	[ApproveStatus] int,
	[ApproveRemark] ntext,
	[ApproveMethod] nvarchar(200),
	[ApproveMonth] nvarchar(100),
	[TransferTime] datetime,
	[TransferMan] nvarchar(100),
	[TransferRemark] ntext,
	[TransferStatus] int,
	[TransferMoney] decimal(18, 2),
	[AddTime] datetime
);

INSERT INTO [dbo].[Cheque_Confirm] (
	[Cheque_Confirm].[SummaryID],
	[Cheque_Confirm].[TakeTime],
	[Cheque_Confirm].[TakeUser],
	[Cheque_Confirm].[TakeStatus],
	[Cheque_Confirm].[TakeRemark],
	[Cheque_Confirm].[ApproveTime],
	[Cheque_Confirm].[ApproveMan],
	[Cheque_Confirm].[ApproveStatus],
	[Cheque_Confirm].[ApproveRemark],
	[Cheque_Confirm].[ApproveMethod],
	[Cheque_Confirm].[ApproveMonth],
	[Cheque_Confirm].[TransferTime],
	[Cheque_Confirm].[TransferMan],
	[Cheque_Confirm].[TransferRemark],
	[Cheque_Confirm].[TransferStatus],
	[Cheque_Confirm].[TransferMoney],
	[Cheque_Confirm].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[SummaryID],
	INSERTED.[TakeTime],
	INSERTED.[TakeUser],
	INSERTED.[TakeStatus],
	INSERTED.[TakeRemark],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveRemark],
	INSERTED.[ApproveMethod],
	INSERTED.[ApproveMonth],
	INSERTED.[TransferTime],
	INSERTED.[TransferMan],
	INSERTED.[TransferRemark],
	INSERTED.[TransferStatus],
	INSERTED.[TransferMoney],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@SummaryID,
	@TakeTime,
	@TakeUser,
	@TakeStatus,
	@TakeRemark,
	@ApproveTime,
	@ApproveMan,
	@ApproveStatus,
	@ApproveRemark,
	@ApproveMethod,
	@ApproveMonth,
	@TransferTime,
	@TransferMan,
	@TransferRemark,
	@TransferStatus,
	@TransferMoney,
	@AddTime 
); 

SELECT 
	[ID],
	[SummaryID],
	[TakeTime],
	[TakeUser],
	[TakeStatus],
	[TakeRemark],
	[ApproveTime],
	[ApproveMan],
	[ApproveStatus],
	[ApproveRemark],
	[ApproveMethod],
	[ApproveMonth],
	[TransferTime],
	[TransferMan],
	[TransferRemark],
	[TransferStatus],
	[TransferMoney],
	[AddTime] 
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
	[SummaryID] int,
	[TakeTime] datetime,
	[TakeUser] nvarchar(100),
	[TakeStatus] int,
	[TakeRemark] ntext,
	[ApproveTime] datetime,
	[ApproveMan] nvarchar(100),
	[ApproveStatus] int,
	[ApproveRemark] ntext,
	[ApproveMethod] nvarchar(200),
	[ApproveMonth] nvarchar(100),
	[TransferTime] datetime,
	[TransferMan] nvarchar(100),
	[TransferRemark] ntext,
	[TransferStatus] int,
	[TransferMoney] decimal(18, 2),
	[AddTime] datetime
);

UPDATE [dbo].[Cheque_Confirm] SET 
	[Cheque_Confirm].[SummaryID] = @SummaryID,
	[Cheque_Confirm].[TakeTime] = @TakeTime,
	[Cheque_Confirm].[TakeUser] = @TakeUser,
	[Cheque_Confirm].[TakeStatus] = @TakeStatus,
	[Cheque_Confirm].[TakeRemark] = @TakeRemark,
	[Cheque_Confirm].[ApproveTime] = @ApproveTime,
	[Cheque_Confirm].[ApproveMan] = @ApproveMan,
	[Cheque_Confirm].[ApproveStatus] = @ApproveStatus,
	[Cheque_Confirm].[ApproveRemark] = @ApproveRemark,
	[Cheque_Confirm].[ApproveMethod] = @ApproveMethod,
	[Cheque_Confirm].[ApproveMonth] = @ApproveMonth,
	[Cheque_Confirm].[TransferTime] = @TransferTime,
	[Cheque_Confirm].[TransferMan] = @TransferMan,
	[Cheque_Confirm].[TransferRemark] = @TransferRemark,
	[Cheque_Confirm].[TransferStatus] = @TransferStatus,
	[Cheque_Confirm].[TransferMoney] = @TransferMoney,
	[Cheque_Confirm].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[SummaryID],
	INSERTED.[TakeTime],
	INSERTED.[TakeUser],
	INSERTED.[TakeStatus],
	INSERTED.[TakeRemark],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveRemark],
	INSERTED.[ApproveMethod],
	INSERTED.[ApproveMonth],
	INSERTED.[TransferTime],
	INSERTED.[TransferMan],
	INSERTED.[TransferRemark],
	INSERTED.[TransferStatus],
	INSERTED.[TransferMoney],
	INSERTED.[AddTime]
into @table
WHERE 
	[Cheque_Confirm].[ID] = @ID

SELECT 
	[ID],
	[SummaryID],
	[TakeTime],
	[TakeUser],
	[TakeStatus],
	[TakeRemark],
	[ApproveTime],
	[ApproveMan],
	[ApproveStatus],
	[ApproveRemark],
	[ApproveMethod],
	[ApproveMonth],
	[TransferTime],
	[TransferMan],
	[TransferRemark],
	[TransferStatus],
	[TransferMoney],
	[AddTime] 
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
DELETE FROM [dbo].[Cheque_Confirm]
WHERE 
	[Cheque_Confirm].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_Confirm() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_Confirm(this.ID));
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
	[Cheque_Confirm].[ID],
	[Cheque_Confirm].[SummaryID],
	[Cheque_Confirm].[TakeTime],
	[Cheque_Confirm].[TakeUser],
	[Cheque_Confirm].[TakeStatus],
	[Cheque_Confirm].[TakeRemark],
	[Cheque_Confirm].[ApproveTime],
	[Cheque_Confirm].[ApproveMan],
	[Cheque_Confirm].[ApproveStatus],
	[Cheque_Confirm].[ApproveRemark],
	[Cheque_Confirm].[ApproveMethod],
	[Cheque_Confirm].[ApproveMonth],
	[Cheque_Confirm].[TransferTime],
	[Cheque_Confirm].[TransferMan],
	[Cheque_Confirm].[TransferRemark],
	[Cheque_Confirm].[TransferStatus],
	[Cheque_Confirm].[TransferMoney],
	[Cheque_Confirm].[AddTime]
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
                return "Cheque_Confirm";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_Confirm into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="summaryID">summaryID</param>
		/// <param name="takeTime">takeTime</param>
		/// <param name="takeUser">takeUser</param>
		/// <param name="takeStatus">takeStatus</param>
		/// <param name="takeRemark">takeRemark</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="approveMethod">approveMethod</param>
		/// <param name="approveMonth">approveMonth</param>
		/// <param name="transferTime">transferTime</param>
		/// <param name="transferMan">transferMan</param>
		/// <param name="transferRemark">transferRemark</param>
		/// <param name="transferStatus">transferStatus</param>
		/// <param name="transferMoney">transferMoney</param>
		/// <param name="addTime">addTime</param>
		public static void InsertCheque_Confirm(int @summaryID, DateTime @takeTime, string @takeUser, int @takeStatus, string @takeRemark, DateTime @approveTime, string @approveMan, int @approveStatus, string @approveRemark, string @approveMethod, string @approveMonth, DateTime @transferTime, string @transferMan, string @transferRemark, int @transferStatus, decimal @transferMoney, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_Confirm(@summaryID, @takeTime, @takeUser, @takeStatus, @takeRemark, @approveTime, @approveMan, @approveStatus, @approveRemark, @approveMethod, @approveMonth, @transferTime, @transferMan, @transferRemark, @transferStatus, @transferMoney, @addTime, helper);
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
		/// Insert a Cheque_Confirm into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="summaryID">summaryID</param>
		/// <param name="takeTime">takeTime</param>
		/// <param name="takeUser">takeUser</param>
		/// <param name="takeStatus">takeStatus</param>
		/// <param name="takeRemark">takeRemark</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="approveMethod">approveMethod</param>
		/// <param name="approveMonth">approveMonth</param>
		/// <param name="transferTime">transferTime</param>
		/// <param name="transferMan">transferMan</param>
		/// <param name="transferRemark">transferRemark</param>
		/// <param name="transferStatus">transferStatus</param>
		/// <param name="transferMoney">transferMoney</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_Confirm(int @summaryID, DateTime @takeTime, string @takeUser, int @takeStatus, string @takeRemark, DateTime @approveTime, string @approveMan, int @approveStatus, string @approveRemark, string @approveMethod, string @approveMonth, DateTime @transferTime, string @transferMan, string @transferRemark, int @transferStatus, decimal @transferMoney, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SummaryID] int,
	[TakeTime] datetime,
	[TakeUser] nvarchar(100),
	[TakeStatus] int,
	[TakeRemark] ntext,
	[ApproveTime] datetime,
	[ApproveMan] nvarchar(100),
	[ApproveStatus] int,
	[ApproveRemark] ntext,
	[ApproveMethod] nvarchar(200),
	[ApproveMonth] nvarchar(100),
	[TransferTime] datetime,
	[TransferMan] nvarchar(100),
	[TransferRemark] ntext,
	[TransferStatus] int,
	[TransferMoney] decimal(18, 2),
	[AddTime] datetime
);

INSERT INTO [dbo].[Cheque_Confirm] (
	[Cheque_Confirm].[SummaryID],
	[Cheque_Confirm].[TakeTime],
	[Cheque_Confirm].[TakeUser],
	[Cheque_Confirm].[TakeStatus],
	[Cheque_Confirm].[TakeRemark],
	[Cheque_Confirm].[ApproveTime],
	[Cheque_Confirm].[ApproveMan],
	[Cheque_Confirm].[ApproveStatus],
	[Cheque_Confirm].[ApproveRemark],
	[Cheque_Confirm].[ApproveMethod],
	[Cheque_Confirm].[ApproveMonth],
	[Cheque_Confirm].[TransferTime],
	[Cheque_Confirm].[TransferMan],
	[Cheque_Confirm].[TransferRemark],
	[Cheque_Confirm].[TransferStatus],
	[Cheque_Confirm].[TransferMoney],
	[Cheque_Confirm].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[SummaryID],
	INSERTED.[TakeTime],
	INSERTED.[TakeUser],
	INSERTED.[TakeStatus],
	INSERTED.[TakeRemark],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveRemark],
	INSERTED.[ApproveMethod],
	INSERTED.[ApproveMonth],
	INSERTED.[TransferTime],
	INSERTED.[TransferMan],
	INSERTED.[TransferRemark],
	INSERTED.[TransferStatus],
	INSERTED.[TransferMoney],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@SummaryID,
	@TakeTime,
	@TakeUser,
	@TakeStatus,
	@TakeRemark,
	@ApproveTime,
	@ApproveMan,
	@ApproveStatus,
	@ApproveRemark,
	@ApproveMethod,
	@ApproveMonth,
	@TransferTime,
	@TransferMan,
	@TransferRemark,
	@TransferStatus,
	@TransferMoney,
	@AddTime 
); 

SELECT 
	[ID],
	[SummaryID],
	[TakeTime],
	[TakeUser],
	[TakeStatus],
	[TakeRemark],
	[ApproveTime],
	[ApproveMan],
	[ApproveStatus],
	[ApproveRemark],
	[ApproveMethod],
	[ApproveMonth],
	[TransferTime],
	[TransferMan],
	[TransferRemark],
	[TransferStatus],
	[TransferMoney],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@SummaryID", EntityBase.GetDatabaseValue(@summaryID)));
			parameters.Add(new SqlParameter("@TakeTime", EntityBase.GetDatabaseValue(@takeTime)));
			parameters.Add(new SqlParameter("@TakeUser", EntityBase.GetDatabaseValue(@takeUser)));
			parameters.Add(new SqlParameter("@TakeStatus", EntityBase.GetDatabaseValue(@takeStatus)));
			parameters.Add(new SqlParameter("@TakeRemark", EntityBase.GetDatabaseValue(@takeRemark)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveMan", EntityBase.GetDatabaseValue(@approveMan)));
			parameters.Add(new SqlParameter("@ApproveStatus", EntityBase.GetDatabaseValue(@approveStatus)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@ApproveMethod", EntityBase.GetDatabaseValue(@approveMethod)));
			parameters.Add(new SqlParameter("@ApproveMonth", EntityBase.GetDatabaseValue(@approveMonth)));
			parameters.Add(new SqlParameter("@TransferTime", EntityBase.GetDatabaseValue(@transferTime)));
			parameters.Add(new SqlParameter("@TransferMan", EntityBase.GetDatabaseValue(@transferMan)));
			parameters.Add(new SqlParameter("@TransferRemark", EntityBase.GetDatabaseValue(@transferRemark)));
			parameters.Add(new SqlParameter("@TransferStatus", EntityBase.GetDatabaseValue(@transferStatus)));
			parameters.Add(new SqlParameter("@TransferMoney", EntityBase.GetDatabaseValue(@transferMoney)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_Confirm into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="summaryID">summaryID</param>
		/// <param name="takeTime">takeTime</param>
		/// <param name="takeUser">takeUser</param>
		/// <param name="takeStatus">takeStatus</param>
		/// <param name="takeRemark">takeRemark</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="approveMethod">approveMethod</param>
		/// <param name="approveMonth">approveMonth</param>
		/// <param name="transferTime">transferTime</param>
		/// <param name="transferMan">transferMan</param>
		/// <param name="transferRemark">transferRemark</param>
		/// <param name="transferStatus">transferStatus</param>
		/// <param name="transferMoney">transferMoney</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateCheque_Confirm(int @iD, int @summaryID, DateTime @takeTime, string @takeUser, int @takeStatus, string @takeRemark, DateTime @approveTime, string @approveMan, int @approveStatus, string @approveRemark, string @approveMethod, string @approveMonth, DateTime @transferTime, string @transferMan, string @transferRemark, int @transferStatus, decimal @transferMoney, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_Confirm(@iD, @summaryID, @takeTime, @takeUser, @takeStatus, @takeRemark, @approveTime, @approveMan, @approveStatus, @approveRemark, @approveMethod, @approveMonth, @transferTime, @transferMan, @transferRemark, @transferStatus, @transferMoney, @addTime, helper);
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
		/// Updates a Cheque_Confirm into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="summaryID">summaryID</param>
		/// <param name="takeTime">takeTime</param>
		/// <param name="takeUser">takeUser</param>
		/// <param name="takeStatus">takeStatus</param>
		/// <param name="takeRemark">takeRemark</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="approveMethod">approveMethod</param>
		/// <param name="approveMonth">approveMonth</param>
		/// <param name="transferTime">transferTime</param>
		/// <param name="transferMan">transferMan</param>
		/// <param name="transferRemark">transferRemark</param>
		/// <param name="transferStatus">transferStatus</param>
		/// <param name="transferMoney">transferMoney</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_Confirm(int @iD, int @summaryID, DateTime @takeTime, string @takeUser, int @takeStatus, string @takeRemark, DateTime @approveTime, string @approveMan, int @approveStatus, string @approveRemark, string @approveMethod, string @approveMonth, DateTime @transferTime, string @transferMan, string @transferRemark, int @transferStatus, decimal @transferMoney, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SummaryID] int,
	[TakeTime] datetime,
	[TakeUser] nvarchar(100),
	[TakeStatus] int,
	[TakeRemark] ntext,
	[ApproveTime] datetime,
	[ApproveMan] nvarchar(100),
	[ApproveStatus] int,
	[ApproveRemark] ntext,
	[ApproveMethod] nvarchar(200),
	[ApproveMonth] nvarchar(100),
	[TransferTime] datetime,
	[TransferMan] nvarchar(100),
	[TransferRemark] ntext,
	[TransferStatus] int,
	[TransferMoney] decimal(18, 2),
	[AddTime] datetime
);

UPDATE [dbo].[Cheque_Confirm] SET 
	[Cheque_Confirm].[SummaryID] = @SummaryID,
	[Cheque_Confirm].[TakeTime] = @TakeTime,
	[Cheque_Confirm].[TakeUser] = @TakeUser,
	[Cheque_Confirm].[TakeStatus] = @TakeStatus,
	[Cheque_Confirm].[TakeRemark] = @TakeRemark,
	[Cheque_Confirm].[ApproveTime] = @ApproveTime,
	[Cheque_Confirm].[ApproveMan] = @ApproveMan,
	[Cheque_Confirm].[ApproveStatus] = @ApproveStatus,
	[Cheque_Confirm].[ApproveRemark] = @ApproveRemark,
	[Cheque_Confirm].[ApproveMethod] = @ApproveMethod,
	[Cheque_Confirm].[ApproveMonth] = @ApproveMonth,
	[Cheque_Confirm].[TransferTime] = @TransferTime,
	[Cheque_Confirm].[TransferMan] = @TransferMan,
	[Cheque_Confirm].[TransferRemark] = @TransferRemark,
	[Cheque_Confirm].[TransferStatus] = @TransferStatus,
	[Cheque_Confirm].[TransferMoney] = @TransferMoney,
	[Cheque_Confirm].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[SummaryID],
	INSERTED.[TakeTime],
	INSERTED.[TakeUser],
	INSERTED.[TakeStatus],
	INSERTED.[TakeRemark],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveRemark],
	INSERTED.[ApproveMethod],
	INSERTED.[ApproveMonth],
	INSERTED.[TransferTime],
	INSERTED.[TransferMan],
	INSERTED.[TransferRemark],
	INSERTED.[TransferStatus],
	INSERTED.[TransferMoney],
	INSERTED.[AddTime]
into @table
WHERE 
	[Cheque_Confirm].[ID] = @ID

SELECT 
	[ID],
	[SummaryID],
	[TakeTime],
	[TakeUser],
	[TakeStatus],
	[TakeRemark],
	[ApproveTime],
	[ApproveMan],
	[ApproveStatus],
	[ApproveRemark],
	[ApproveMethod],
	[ApproveMonth],
	[TransferTime],
	[TransferMan],
	[TransferRemark],
	[TransferStatus],
	[TransferMoney],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@SummaryID", EntityBase.GetDatabaseValue(@summaryID)));
			parameters.Add(new SqlParameter("@TakeTime", EntityBase.GetDatabaseValue(@takeTime)));
			parameters.Add(new SqlParameter("@TakeUser", EntityBase.GetDatabaseValue(@takeUser)));
			parameters.Add(new SqlParameter("@TakeStatus", EntityBase.GetDatabaseValue(@takeStatus)));
			parameters.Add(new SqlParameter("@TakeRemark", EntityBase.GetDatabaseValue(@takeRemark)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveMan", EntityBase.GetDatabaseValue(@approveMan)));
			parameters.Add(new SqlParameter("@ApproveStatus", EntityBase.GetDatabaseValue(@approveStatus)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@ApproveMethod", EntityBase.GetDatabaseValue(@approveMethod)));
			parameters.Add(new SqlParameter("@ApproveMonth", EntityBase.GetDatabaseValue(@approveMonth)));
			parameters.Add(new SqlParameter("@TransferTime", EntityBase.GetDatabaseValue(@transferTime)));
			parameters.Add(new SqlParameter("@TransferMan", EntityBase.GetDatabaseValue(@transferMan)));
			parameters.Add(new SqlParameter("@TransferRemark", EntityBase.GetDatabaseValue(@transferRemark)));
			parameters.Add(new SqlParameter("@TransferStatus", EntityBase.GetDatabaseValue(@transferStatus)));
			parameters.Add(new SqlParameter("@TransferMoney", EntityBase.GetDatabaseValue(@transferMoney)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_Confirm from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_Confirm(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_Confirm(@iD, helper);
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
		/// Deletes a Cheque_Confirm from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_Confirm(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_Confirm]
WHERE 
	[Cheque_Confirm].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_Confirm object.
		/// </summary>
		/// <returns>The newly created Cheque_Confirm object.</returns>
		public static Cheque_Confirm CreateCheque_Confirm()
		{
			return InitializeNew<Cheque_Confirm>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_Confirm by a Cheque_Confirm's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_Confirm</returns>
		public static Cheque_Confirm GetCheque_Confirm(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_Confirm.SelectFieldList + @"
FROM [dbo].[Cheque_Confirm] 
WHERE 
	[Cheque_Confirm].[ID] = @ID " + Cheque_Confirm.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_Confirm>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_Confirm by a Cheque_Confirm's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_Confirm</returns>
		public static Cheque_Confirm GetCheque_Confirm(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_Confirm.SelectFieldList + @"
FROM [dbo].[Cheque_Confirm] 
WHERE 
	[Cheque_Confirm].[ID] = @ID " + Cheque_Confirm.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_Confirm>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Confirm objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_Confirm objects.</returns>
		public static EntityList<Cheque_Confirm> GetCheque_Confirms()
		{
			string commandText = @"
SELECT " + Cheque_Confirm.SelectFieldList + "FROM [dbo].[Cheque_Confirm] " + Cheque_Confirm.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_Confirm>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_Confirm objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_Confirm objects.</returns>
        public static EntityList<Cheque_Confirm> GetCheque_Confirms(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Confirm>(SelectFieldList, "FROM [dbo].[Cheque_Confirm]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_Confirm objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_Confirm objects.</returns>
        public static EntityList<Cheque_Confirm> GetCheque_Confirms(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Confirm>(SelectFieldList, "FROM [dbo].[Cheque_Confirm]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_Confirm objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_Confirm objects.</returns>
		protected static EntityList<Cheque_Confirm> GetCheque_Confirms(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Confirms(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Confirm objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Confirm objects.</returns>
		protected static EntityList<Cheque_Confirm> GetCheque_Confirms(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Confirms(string.Empty, where, parameters, Cheque_Confirm.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Confirm objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Confirm objects.</returns>
		protected static EntityList<Cheque_Confirm> GetCheque_Confirms(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Confirms(prefix, where, parameters, Cheque_Confirm.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Confirm objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Confirm objects.</returns>
		protected static EntityList<Cheque_Confirm> GetCheque_Confirms(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_Confirms(string.Empty, where, parameters, Cheque_Confirm.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Confirm objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Confirm objects.</returns>
		protected static EntityList<Cheque_Confirm> GetCheque_Confirms(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_Confirms(prefix, where, parameters, Cheque_Confirm.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Confirm objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_Confirm objects.</returns>
		protected static EntityList<Cheque_Confirm> GetCheque_Confirms(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_Confirm.SelectFieldList + "FROM [dbo].[Cheque_Confirm] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_Confirm>(reader);
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
        protected static EntityList<Cheque_Confirm> GetCheque_Confirms(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Confirm>(SelectFieldList, "FROM [dbo].[Cheque_Confirm] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_Confirm objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_ConfirmCount()
        {
            return GetCheque_ConfirmCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_Confirm objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_ConfirmCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_Confirm] " + where;

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
		public static partial class Cheque_Confirm_Properties
		{
			public const string ID = "ID";
			public const string SummaryID = "SummaryID";
			public const string TakeTime = "TakeTime";
			public const string TakeUser = "TakeUser";
			public const string TakeStatus = "TakeStatus";
			public const string TakeRemark = "TakeRemark";
			public const string ApproveTime = "ApproveTime";
			public const string ApproveMan = "ApproveMan";
			public const string ApproveStatus = "ApproveStatus";
			public const string ApproveRemark = "ApproveRemark";
			public const string ApproveMethod = "ApproveMethod";
			public const string ApproveMonth = "ApproveMonth";
			public const string TransferTime = "TransferTime";
			public const string TransferMan = "TransferMan";
			public const string TransferRemark = "TransferRemark";
			public const string TransferStatus = "TransferStatus";
			public const string TransferMoney = "TransferMoney";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"SummaryID" , "int:"},
    			 {"TakeTime" , "DateTime:"},
    			 {"TakeUser" , "string:"},
    			 {"TakeStatus" , "int:"},
    			 {"TakeRemark" , "string:"},
    			 {"ApproveTime" , "DateTime:"},
    			 {"ApproveMan" , "string:"},
    			 {"ApproveStatus" , "int:"},
    			 {"ApproveRemark" , "string:"},
    			 {"ApproveMethod" , "string:"},
    			 {"ApproveMonth" , "string:"},
    			 {"TransferTime" , "DateTime:"},
    			 {"TransferMan" , "string:"},
    			 {"TransferRemark" , "string:"},
    			 {"TransferStatus" , "int:"},
    			 {"TransferMoney" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
