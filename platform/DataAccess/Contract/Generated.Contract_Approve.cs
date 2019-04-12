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
	/// This object represents the properties and methods of a Contract_Approve.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Contract_Approve 
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
		private string _jingShouTeam = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string JingShouTeam
		{
			[DebuggerStepThrough()]
			get { return this._jingShouTeam; }
			set 
			{
				if (this._jingShouTeam != value) 
				{
					this._jingShouTeam = value;
					this.IsDirty = true;	
					OnPropertyChanged("JingShouTeam");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _jingShouPerson = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string JingShouPerson
		{
			[DebuggerStepThrough()]
			get { return this._jingShouPerson; }
			set 
			{
				if (this._jingShouPerson != value) 
				{
					this._jingShouPerson = value;
					this.IsDirty = true;	
					OnPropertyChanged("JingShouPerson");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _shareRole = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ShareRole
		{
			[DebuggerStepThrough()]
			get { return this._shareRole; }
			set 
			{
				if (this._shareRole != value) 
				{
					this._shareRole = value;
					this.IsDirty = true;	
					OnPropertyChanged("ShareRole");
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
		private int _printModuleID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PrintModuleID
		{
			[DebuggerStepThrough()]
			get { return this._printModuleID; }
			set 
			{
				if (this._printModuleID != value) 
				{
					this._printModuleID = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintModuleID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _yunYingModel = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string YunYingModel
		{
			[DebuggerStepThrough()]
			get { return this._yunYingModel; }
			set 
			{
				if (this._yunYingModel != value) 
				{
					this._yunYingModel = value;
					this.IsDirty = true;	
					OnPropertyChanged("YunYingModel");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _businessYeTai = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BusinessYeTai
		{
			[DebuggerStepThrough()]
			get { return this._businessYeTai; }
			set 
			{
				if (this._businessYeTai != value) 
				{
					this._businessYeTai = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessYeTai");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _businessRange = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BusinessRange
		{
			[DebuggerStepThrough()]
			get { return this._businessRange; }
			set 
			{
				if (this._businessRange != value) 
				{
					this._businessRange = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessRange");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveDesc = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveDesc
		{
			[DebuggerStepThrough()]
			get { return this._approveDesc; }
			set 
			{
				if (this._approveDesc != value) 
				{
					this._approveDesc = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveDesc");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveStatus = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveStatus
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
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[JingShouTeam] nvarchar(50),
	[JingShouPerson] nvarchar(50),
	[ShareRole] nvarchar(50),
	[ApproveTime] datetime,
	[ApproveMan] nvarchar(50),
	[PrintModuleID] int,
	[YunYingModel] nvarchar(50),
	[BusinessYeTai] nvarchar(50),
	[BusinessRange] nvarchar(50),
	[ApproveDesc] ntext,
	[ApproveStatus] nvarchar(50)
);

INSERT INTO [dbo].[Contract_Approve] (
	[Contract_Approve].[ContractID],
	[Contract_Approve].[AddTime],
	[Contract_Approve].[AddMan],
	[Contract_Approve].[JingShouTeam],
	[Contract_Approve].[JingShouPerson],
	[Contract_Approve].[ShareRole],
	[Contract_Approve].[ApproveTime],
	[Contract_Approve].[ApproveMan],
	[Contract_Approve].[PrintModuleID],
	[Contract_Approve].[YunYingModel],
	[Contract_Approve].[BusinessYeTai],
	[Contract_Approve].[BusinessRange],
	[Contract_Approve].[ApproveDesc],
	[Contract_Approve].[ApproveStatus]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[JingShouTeam],
	INSERTED.[JingShouPerson],
	INSERTED.[ShareRole],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveMan],
	INSERTED.[PrintModuleID],
	INSERTED.[YunYingModel],
	INSERTED.[BusinessYeTai],
	INSERTED.[BusinessRange],
	INSERTED.[ApproveDesc],
	INSERTED.[ApproveStatus]
into @table
VALUES ( 
	@ContractID,
	@AddTime,
	@AddMan,
	@JingShouTeam,
	@JingShouPerson,
	@ShareRole,
	@ApproveTime,
	@ApproveMan,
	@PrintModuleID,
	@YunYingModel,
	@BusinessYeTai,
	@BusinessRange,
	@ApproveDesc,
	@ApproveStatus 
); 

SELECT 
	[ID],
	[ContractID],
	[AddTime],
	[AddMan],
	[JingShouTeam],
	[JingShouPerson],
	[ShareRole],
	[ApproveTime],
	[ApproveMan],
	[PrintModuleID],
	[YunYingModel],
	[BusinessYeTai],
	[BusinessRange],
	[ApproveDesc],
	[ApproveStatus] 
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
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[JingShouTeam] nvarchar(50),
	[JingShouPerson] nvarchar(50),
	[ShareRole] nvarchar(50),
	[ApproveTime] datetime,
	[ApproveMan] nvarchar(50),
	[PrintModuleID] int,
	[YunYingModel] nvarchar(50),
	[BusinessYeTai] nvarchar(50),
	[BusinessRange] nvarchar(50),
	[ApproveDesc] ntext,
	[ApproveStatus] nvarchar(50)
);

UPDATE [dbo].[Contract_Approve] SET 
	[Contract_Approve].[ContractID] = @ContractID,
	[Contract_Approve].[AddTime] = @AddTime,
	[Contract_Approve].[AddMan] = @AddMan,
	[Contract_Approve].[JingShouTeam] = @JingShouTeam,
	[Contract_Approve].[JingShouPerson] = @JingShouPerson,
	[Contract_Approve].[ShareRole] = @ShareRole,
	[Contract_Approve].[ApproveTime] = @ApproveTime,
	[Contract_Approve].[ApproveMan] = @ApproveMan,
	[Contract_Approve].[PrintModuleID] = @PrintModuleID,
	[Contract_Approve].[YunYingModel] = @YunYingModel,
	[Contract_Approve].[BusinessYeTai] = @BusinessYeTai,
	[Contract_Approve].[BusinessRange] = @BusinessRange,
	[Contract_Approve].[ApproveDesc] = @ApproveDesc,
	[Contract_Approve].[ApproveStatus] = @ApproveStatus 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[JingShouTeam],
	INSERTED.[JingShouPerson],
	INSERTED.[ShareRole],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveMan],
	INSERTED.[PrintModuleID],
	INSERTED.[YunYingModel],
	INSERTED.[BusinessYeTai],
	INSERTED.[BusinessRange],
	INSERTED.[ApproveDesc],
	INSERTED.[ApproveStatus]
into @table
WHERE 
	[Contract_Approve].[ID] = @ID

SELECT 
	[ID],
	[ContractID],
	[AddTime],
	[AddMan],
	[JingShouTeam],
	[JingShouPerson],
	[ShareRole],
	[ApproveTime],
	[ApproveMan],
	[PrintModuleID],
	[YunYingModel],
	[BusinessYeTai],
	[BusinessRange],
	[ApproveDesc],
	[ApproveStatus] 
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
DELETE FROM [dbo].[Contract_Approve]
WHERE 
	[Contract_Approve].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Contract_Approve() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetContract_Approve(this.ID));
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
	[Contract_Approve].[ID],
	[Contract_Approve].[ContractID],
	[Contract_Approve].[AddTime],
	[Contract_Approve].[AddMan],
	[Contract_Approve].[JingShouTeam],
	[Contract_Approve].[JingShouPerson],
	[Contract_Approve].[ShareRole],
	[Contract_Approve].[ApproveTime],
	[Contract_Approve].[ApproveMan],
	[Contract_Approve].[PrintModuleID],
	[Contract_Approve].[YunYingModel],
	[Contract_Approve].[BusinessYeTai],
	[Contract_Approve].[BusinessRange],
	[Contract_Approve].[ApproveDesc],
	[Contract_Approve].[ApproveStatus]
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
                return "Contract_Approve";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Contract_Approve into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractID">contractID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="jingShouTeam">jingShouTeam</param>
		/// <param name="jingShouPerson">jingShouPerson</param>
		/// <param name="shareRole">shareRole</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="printModuleID">printModuleID</param>
		/// <param name="yunYingModel">yunYingModel</param>
		/// <param name="businessYeTai">businessYeTai</param>
		/// <param name="businessRange">businessRange</param>
		/// <param name="approveDesc">approveDesc</param>
		/// <param name="approveStatus">approveStatus</param>
		public static void InsertContract_Approve(int @contractID, DateTime @addTime, string @addMan, string @jingShouTeam, string @jingShouPerson, string @shareRole, DateTime @approveTime, string @approveMan, int @printModuleID, string @yunYingModel, string @businessYeTai, string @businessRange, string @approveDesc, string @approveStatus)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertContract_Approve(@contractID, @addTime, @addMan, @jingShouTeam, @jingShouPerson, @shareRole, @approveTime, @approveMan, @printModuleID, @yunYingModel, @businessYeTai, @businessRange, @approveDesc, @approveStatus, helper);
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
		/// Insert a Contract_Approve into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractID">contractID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="jingShouTeam">jingShouTeam</param>
		/// <param name="jingShouPerson">jingShouPerson</param>
		/// <param name="shareRole">shareRole</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="printModuleID">printModuleID</param>
		/// <param name="yunYingModel">yunYingModel</param>
		/// <param name="businessYeTai">businessYeTai</param>
		/// <param name="businessRange">businessRange</param>
		/// <param name="approveDesc">approveDesc</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="helper">helper</param>
		internal static void InsertContract_Approve(int @contractID, DateTime @addTime, string @addMan, string @jingShouTeam, string @jingShouPerson, string @shareRole, DateTime @approveTime, string @approveMan, int @printModuleID, string @yunYingModel, string @businessYeTai, string @businessRange, string @approveDesc, string @approveStatus, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[JingShouTeam] nvarchar(50),
	[JingShouPerson] nvarchar(50),
	[ShareRole] nvarchar(50),
	[ApproveTime] datetime,
	[ApproveMan] nvarchar(50),
	[PrintModuleID] int,
	[YunYingModel] nvarchar(50),
	[BusinessYeTai] nvarchar(50),
	[BusinessRange] nvarchar(50),
	[ApproveDesc] ntext,
	[ApproveStatus] nvarchar(50)
);

INSERT INTO [dbo].[Contract_Approve] (
	[Contract_Approve].[ContractID],
	[Contract_Approve].[AddTime],
	[Contract_Approve].[AddMan],
	[Contract_Approve].[JingShouTeam],
	[Contract_Approve].[JingShouPerson],
	[Contract_Approve].[ShareRole],
	[Contract_Approve].[ApproveTime],
	[Contract_Approve].[ApproveMan],
	[Contract_Approve].[PrintModuleID],
	[Contract_Approve].[YunYingModel],
	[Contract_Approve].[BusinessYeTai],
	[Contract_Approve].[BusinessRange],
	[Contract_Approve].[ApproveDesc],
	[Contract_Approve].[ApproveStatus]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[JingShouTeam],
	INSERTED.[JingShouPerson],
	INSERTED.[ShareRole],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveMan],
	INSERTED.[PrintModuleID],
	INSERTED.[YunYingModel],
	INSERTED.[BusinessYeTai],
	INSERTED.[BusinessRange],
	INSERTED.[ApproveDesc],
	INSERTED.[ApproveStatus]
into @table
VALUES ( 
	@ContractID,
	@AddTime,
	@AddMan,
	@JingShouTeam,
	@JingShouPerson,
	@ShareRole,
	@ApproveTime,
	@ApproveMan,
	@PrintModuleID,
	@YunYingModel,
	@BusinessYeTai,
	@BusinessRange,
	@ApproveDesc,
	@ApproveStatus 
); 

SELECT 
	[ID],
	[ContractID],
	[AddTime],
	[AddMan],
	[JingShouTeam],
	[JingShouPerson],
	[ShareRole],
	[ApproveTime],
	[ApproveMan],
	[PrintModuleID],
	[YunYingModel],
	[BusinessYeTai],
	[BusinessRange],
	[ApproveDesc],
	[ApproveStatus] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@JingShouTeam", EntityBase.GetDatabaseValue(@jingShouTeam)));
			parameters.Add(new SqlParameter("@JingShouPerson", EntityBase.GetDatabaseValue(@jingShouPerson)));
			parameters.Add(new SqlParameter("@ShareRole", EntityBase.GetDatabaseValue(@shareRole)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveMan", EntityBase.GetDatabaseValue(@approveMan)));
			parameters.Add(new SqlParameter("@PrintModuleID", EntityBase.GetDatabaseValue(@printModuleID)));
			parameters.Add(new SqlParameter("@YunYingModel", EntityBase.GetDatabaseValue(@yunYingModel)));
			parameters.Add(new SqlParameter("@BusinessYeTai", EntityBase.GetDatabaseValue(@businessYeTai)));
			parameters.Add(new SqlParameter("@BusinessRange", EntityBase.GetDatabaseValue(@businessRange)));
			parameters.Add(new SqlParameter("@ApproveDesc", EntityBase.GetDatabaseValue(@approveDesc)));
			parameters.Add(new SqlParameter("@ApproveStatus", EntityBase.GetDatabaseValue(@approveStatus)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Contract_Approve into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractID">contractID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="jingShouTeam">jingShouTeam</param>
		/// <param name="jingShouPerson">jingShouPerson</param>
		/// <param name="shareRole">shareRole</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="printModuleID">printModuleID</param>
		/// <param name="yunYingModel">yunYingModel</param>
		/// <param name="businessYeTai">businessYeTai</param>
		/// <param name="businessRange">businessRange</param>
		/// <param name="approveDesc">approveDesc</param>
		/// <param name="approveStatus">approveStatus</param>
		public static void UpdateContract_Approve(int @iD, int @contractID, DateTime @addTime, string @addMan, string @jingShouTeam, string @jingShouPerson, string @shareRole, DateTime @approveTime, string @approveMan, int @printModuleID, string @yunYingModel, string @businessYeTai, string @businessRange, string @approveDesc, string @approveStatus)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateContract_Approve(@iD, @contractID, @addTime, @addMan, @jingShouTeam, @jingShouPerson, @shareRole, @approveTime, @approveMan, @printModuleID, @yunYingModel, @businessYeTai, @businessRange, @approveDesc, @approveStatus, helper);
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
		/// Updates a Contract_Approve into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractID">contractID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="jingShouTeam">jingShouTeam</param>
		/// <param name="jingShouPerson">jingShouPerson</param>
		/// <param name="shareRole">shareRole</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="printModuleID">printModuleID</param>
		/// <param name="yunYingModel">yunYingModel</param>
		/// <param name="businessYeTai">businessYeTai</param>
		/// <param name="businessRange">businessRange</param>
		/// <param name="approveDesc">approveDesc</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="helper">helper</param>
		internal static void UpdateContract_Approve(int @iD, int @contractID, DateTime @addTime, string @addMan, string @jingShouTeam, string @jingShouPerson, string @shareRole, DateTime @approveTime, string @approveMan, int @printModuleID, string @yunYingModel, string @businessYeTai, string @businessRange, string @approveDesc, string @approveStatus, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[JingShouTeam] nvarchar(50),
	[JingShouPerson] nvarchar(50),
	[ShareRole] nvarchar(50),
	[ApproveTime] datetime,
	[ApproveMan] nvarchar(50),
	[PrintModuleID] int,
	[YunYingModel] nvarchar(50),
	[BusinessYeTai] nvarchar(50),
	[BusinessRange] nvarchar(50),
	[ApproveDesc] ntext,
	[ApproveStatus] nvarchar(50)
);

UPDATE [dbo].[Contract_Approve] SET 
	[Contract_Approve].[ContractID] = @ContractID,
	[Contract_Approve].[AddTime] = @AddTime,
	[Contract_Approve].[AddMan] = @AddMan,
	[Contract_Approve].[JingShouTeam] = @JingShouTeam,
	[Contract_Approve].[JingShouPerson] = @JingShouPerson,
	[Contract_Approve].[ShareRole] = @ShareRole,
	[Contract_Approve].[ApproveTime] = @ApproveTime,
	[Contract_Approve].[ApproveMan] = @ApproveMan,
	[Contract_Approve].[PrintModuleID] = @PrintModuleID,
	[Contract_Approve].[YunYingModel] = @YunYingModel,
	[Contract_Approve].[BusinessYeTai] = @BusinessYeTai,
	[Contract_Approve].[BusinessRange] = @BusinessRange,
	[Contract_Approve].[ApproveDesc] = @ApproveDesc,
	[Contract_Approve].[ApproveStatus] = @ApproveStatus 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[JingShouTeam],
	INSERTED.[JingShouPerson],
	INSERTED.[ShareRole],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveMan],
	INSERTED.[PrintModuleID],
	INSERTED.[YunYingModel],
	INSERTED.[BusinessYeTai],
	INSERTED.[BusinessRange],
	INSERTED.[ApproveDesc],
	INSERTED.[ApproveStatus]
into @table
WHERE 
	[Contract_Approve].[ID] = @ID

SELECT 
	[ID],
	[ContractID],
	[AddTime],
	[AddMan],
	[JingShouTeam],
	[JingShouPerson],
	[ShareRole],
	[ApproveTime],
	[ApproveMan],
	[PrintModuleID],
	[YunYingModel],
	[BusinessYeTai],
	[BusinessRange],
	[ApproveDesc],
	[ApproveStatus] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@JingShouTeam", EntityBase.GetDatabaseValue(@jingShouTeam)));
			parameters.Add(new SqlParameter("@JingShouPerson", EntityBase.GetDatabaseValue(@jingShouPerson)));
			parameters.Add(new SqlParameter("@ShareRole", EntityBase.GetDatabaseValue(@shareRole)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveMan", EntityBase.GetDatabaseValue(@approveMan)));
			parameters.Add(new SqlParameter("@PrintModuleID", EntityBase.GetDatabaseValue(@printModuleID)));
			parameters.Add(new SqlParameter("@YunYingModel", EntityBase.GetDatabaseValue(@yunYingModel)));
			parameters.Add(new SqlParameter("@BusinessYeTai", EntityBase.GetDatabaseValue(@businessYeTai)));
			parameters.Add(new SqlParameter("@BusinessRange", EntityBase.GetDatabaseValue(@businessRange)));
			parameters.Add(new SqlParameter("@ApproveDesc", EntityBase.GetDatabaseValue(@approveDesc)));
			parameters.Add(new SqlParameter("@ApproveStatus", EntityBase.GetDatabaseValue(@approveStatus)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Contract_Approve from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteContract_Approve(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteContract_Approve(@iD, helper);
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
		/// Deletes a Contract_Approve from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteContract_Approve(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Contract_Approve]
WHERE 
	[Contract_Approve].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Contract_Approve object.
		/// </summary>
		/// <returns>The newly created Contract_Approve object.</returns>
		public static Contract_Approve CreateContract_Approve()
		{
			return InitializeNew<Contract_Approve>();
		}
		
		/// <summary>
		/// Retrieve information for a Contract_Approve by a Contract_Approve's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Contract_Approve</returns>
		public static Contract_Approve GetContract_Approve(int @iD)
		{
			string commandText = @"
SELECT 
" + Contract_Approve.SelectFieldList + @"
FROM [dbo].[Contract_Approve] 
WHERE 
	[Contract_Approve].[ID] = @ID " + Contract_Approve.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_Approve>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Contract_Approve by a Contract_Approve's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Contract_Approve</returns>
		public static Contract_Approve GetContract_Approve(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Contract_Approve.SelectFieldList + @"
FROM [dbo].[Contract_Approve] 
WHERE 
	[Contract_Approve].[ID] = @ID " + Contract_Approve.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_Approve>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Contract_Approve objects.
		/// </summary>
		/// <returns>The retrieved collection of Contract_Approve objects.</returns>
		public static EntityList<Contract_Approve> GetContract_Approves()
		{
			string commandText = @"
SELECT " + Contract_Approve.SelectFieldList + "FROM [dbo].[Contract_Approve] " + Contract_Approve.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Contract_Approve>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Contract_Approve objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_Approve objects.</returns>
        public static EntityList<Contract_Approve> GetContract_Approves(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Approve>(SelectFieldList, "FROM [dbo].[Contract_Approve]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Contract_Approve objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_Approve objects.</returns>
        public static EntityList<Contract_Approve> GetContract_Approves(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Approve>(SelectFieldList, "FROM [dbo].[Contract_Approve]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Contract_Approve objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Contract_Approve objects.</returns>
		protected static EntityList<Contract_Approve> GetContract_Approves(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Approves(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Contract_Approve objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_Approve objects.</returns>
		protected static EntityList<Contract_Approve> GetContract_Approves(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Approves(string.Empty, where, parameters, Contract_Approve.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Approve objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_Approve objects.</returns>
		protected static EntityList<Contract_Approve> GetContract_Approves(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Approves(prefix, where, parameters, Contract_Approve.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Approve objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_Approve objects.</returns>
		protected static EntityList<Contract_Approve> GetContract_Approves(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_Approves(string.Empty, where, parameters, Contract_Approve.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Approve objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_Approve objects.</returns>
		protected static EntityList<Contract_Approve> GetContract_Approves(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_Approves(prefix, where, parameters, Contract_Approve.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Approve objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Contract_Approve objects.</returns>
		protected static EntityList<Contract_Approve> GetContract_Approves(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Contract_Approve.SelectFieldList + "FROM [dbo].[Contract_Approve] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Contract_Approve>(reader);
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
        protected static EntityList<Contract_Approve> GetContract_Approves(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Approve>(SelectFieldList, "FROM [dbo].[Contract_Approve] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Contract_Approve objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_ApproveCount()
        {
            return GetContract_ApproveCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Contract_Approve objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_ApproveCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Contract_Approve] " + where;

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
		public static partial class Contract_Approve_Properties
		{
			public const string ID = "ID";
			public const string ContractID = "ContractID";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string JingShouTeam = "JingShouTeam";
			public const string JingShouPerson = "JingShouPerson";
			public const string ShareRole = "ShareRole";
			public const string ApproveTime = "ApproveTime";
			public const string ApproveMan = "ApproveMan";
			public const string PrintModuleID = "PrintModuleID";
			public const string YunYingModel = "YunYingModel";
			public const string BusinessYeTai = "BusinessYeTai";
			public const string BusinessRange = "BusinessRange";
			public const string ApproveDesc = "ApproveDesc";
			public const string ApproveStatus = "ApproveStatus";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ContractID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"JingShouTeam" , "string:"},
    			 {"JingShouPerson" , "string:"},
    			 {"ShareRole" , "string:"},
    			 {"ApproveTime" , "DateTime:"},
    			 {"ApproveMan" , "string:"},
    			 {"PrintModuleID" , "int:"},
    			 {"YunYingModel" , "string:"},
    			 {"BusinessYeTai" , "string:"},
    			 {"BusinessRange" , "string:"},
    			 {"ApproveDesc" , "string:"},
    			 {"ApproveStatus" , "string:"},
            };
		}
		#endregion
	}
}
