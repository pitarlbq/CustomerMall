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
	/// This object represents the properties and methods of a CKProductInSumary.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CKProductInSumary 
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
		private string _addUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string AddUserName
		{
			[DebuggerStepThrough()]
			get { return this._addUserName; }
			set 
			{
				if (this._addUserName != value) 
				{
					this._addUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUserName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _inTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime InTime
		{
			[DebuggerStepThrough()]
			get { return this._inTime; }
			set 
			{
				if (this._inTime != value) 
				{
					this._inTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("InTime");
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
		private string _contractUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractUserName
		{
			[DebuggerStepThrough()]
			get { return this._contractUserName; }
			set 
			{
				if (this._contractUserName != value) 
				{
					this._contractUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractUserName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contractPhoneNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractPhoneNumber
		{
			[DebuggerStepThrough()]
			get { return this._contractPhoneNumber; }
			set 
			{
				if (this._contractPhoneNumber != value) 
				{
					this._contractPhoneNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractPhoneNumber");
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
		private string _contractName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractName
		{
			[DebuggerStepThrough()]
			get { return this._contractName; }
			set 
			{
				if (this._contractName != value) 
				{
					this._contractName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _orderNumberID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OrderNumberID
		{
			[DebuggerStepThrough()]
			get { return this._orderNumberID; }
			set 
			{
				if (this._orderNumberID != value) 
				{
					this._orderNumberID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderNumberID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _inCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int InCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._inCategoryID; }
			set 
			{
				if (this._inCategoryID != value) 
				{
					this._inCategoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("InCategoryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _belongTeamName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BelongTeamName
		{
			[DebuggerStepThrough()]
			get { return this._belongTeamName; }
			set 
			{
				if (this._belongTeamName != value) 
				{
					this._belongTeamName = value;
					this.IsDirty = true;	
					OnPropertyChanged("BelongTeamName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _belongDepartmentID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int BelongDepartmentID
		{
			[DebuggerStepThrough()]
			get { return this._belongDepartmentID; }
			set 
			{
				if (this._belongDepartmentID != value) 
				{
					this._belongDepartmentID = value;
					this.IsDirty = true;	
					OnPropertyChanged("BelongDepartmentID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _cKCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CKCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._cKCategoryID; }
			set 
			{
				if (this._cKCategoryID != value) 
				{
					this._cKCategoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CKCategoryID");
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
		private DateTime _approveYesTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ApproveYesTime
		{
			[DebuggerStepThrough()]
			get { return this._approveYesTime; }
			set 
			{
				if (this._approveYesTime != value) 
				{
					this._approveYesTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveYesTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _approveNoTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ApproveNoTime
		{
			[DebuggerStepThrough()]
			get { return this._approveNoTime; }
			set 
			{
				if (this._approveNoTime != value) 
				{
					this._approveNoTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveNoTime");
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
	[AddUserName] nvarchar(50),
	[InTime] datetime,
	[OrderNumber] nvarchar(100),
	[ContractID] int,
	[ContractUserName] nvarchar(50),
	[ContractPhoneNumber] nvarchar(50),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ContractName] nvarchar(50),
	[OrderNumberID] int,
	[InCategoryID] int,
	[BelongTeamName] nvarchar(100),
	[BelongDepartmentID] int,
	[CKCategoryID] int,
	[ApproveStatus] int,
	[ApproveYesTime] datetime,
	[ApproveNoTime] datetime,
	[ApproveMan] nvarchar(100)
);

INSERT INTO [dbo].[CKProductInSumary] (
	[CKProductInSumary].[AddUserName],
	[CKProductInSumary].[InTime],
	[CKProductInSumary].[OrderNumber],
	[CKProductInSumary].[ContractID],
	[CKProductInSumary].[ContractUserName],
	[CKProductInSumary].[ContractPhoneNumber],
	[CKProductInSumary].[AddTime],
	[CKProductInSumary].[AddMan],
	[CKProductInSumary].[ContractName],
	[CKProductInSumary].[OrderNumberID],
	[CKProductInSumary].[InCategoryID],
	[CKProductInSumary].[BelongTeamName],
	[CKProductInSumary].[BelongDepartmentID],
	[CKProductInSumary].[CKCategoryID],
	[CKProductInSumary].[ApproveStatus],
	[CKProductInSumary].[ApproveYesTime],
	[CKProductInSumary].[ApproveNoTime],
	[CKProductInSumary].[ApproveMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[AddUserName],
	INSERTED.[InTime],
	INSERTED.[OrderNumber],
	INSERTED.[ContractID],
	INSERTED.[ContractUserName],
	INSERTED.[ContractPhoneNumber],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ContractName],
	INSERTED.[OrderNumberID],
	INSERTED.[InCategoryID],
	INSERTED.[BelongTeamName],
	INSERTED.[BelongDepartmentID],
	INSERTED.[CKCategoryID],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveYesTime],
	INSERTED.[ApproveNoTime],
	INSERTED.[ApproveMan]
into @table
VALUES ( 
	@AddUserName,
	@InTime,
	@OrderNumber,
	@ContractID,
	@ContractUserName,
	@ContractPhoneNumber,
	@AddTime,
	@AddMan,
	@ContractName,
	@OrderNumberID,
	@InCategoryID,
	@BelongTeamName,
	@BelongDepartmentID,
	@CKCategoryID,
	@ApproveStatus,
	@ApproveYesTime,
	@ApproveNoTime,
	@ApproveMan 
); 

SELECT 
	[ID],
	[AddUserName],
	[InTime],
	[OrderNumber],
	[ContractID],
	[ContractUserName],
	[ContractPhoneNumber],
	[AddTime],
	[AddMan],
	[ContractName],
	[OrderNumberID],
	[InCategoryID],
	[BelongTeamName],
	[BelongDepartmentID],
	[CKCategoryID],
	[ApproveStatus],
	[ApproveYesTime],
	[ApproveNoTime],
	[ApproveMan] 
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
	[AddUserName] nvarchar(50),
	[InTime] datetime,
	[OrderNumber] nvarchar(100),
	[ContractID] int,
	[ContractUserName] nvarchar(50),
	[ContractPhoneNumber] nvarchar(50),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ContractName] nvarchar(50),
	[OrderNumberID] int,
	[InCategoryID] int,
	[BelongTeamName] nvarchar(100),
	[BelongDepartmentID] int,
	[CKCategoryID] int,
	[ApproveStatus] int,
	[ApproveYesTime] datetime,
	[ApproveNoTime] datetime,
	[ApproveMan] nvarchar(100)
);

UPDATE [dbo].[CKProductInSumary] SET 
	[CKProductInSumary].[AddUserName] = @AddUserName,
	[CKProductInSumary].[InTime] = @InTime,
	[CKProductInSumary].[OrderNumber] = @OrderNumber,
	[CKProductInSumary].[ContractID] = @ContractID,
	[CKProductInSumary].[ContractUserName] = @ContractUserName,
	[CKProductInSumary].[ContractPhoneNumber] = @ContractPhoneNumber,
	[CKProductInSumary].[AddTime] = @AddTime,
	[CKProductInSumary].[AddMan] = @AddMan,
	[CKProductInSumary].[ContractName] = @ContractName,
	[CKProductInSumary].[OrderNumberID] = @OrderNumberID,
	[CKProductInSumary].[InCategoryID] = @InCategoryID,
	[CKProductInSumary].[BelongTeamName] = @BelongTeamName,
	[CKProductInSumary].[BelongDepartmentID] = @BelongDepartmentID,
	[CKProductInSumary].[CKCategoryID] = @CKCategoryID,
	[CKProductInSumary].[ApproveStatus] = @ApproveStatus,
	[CKProductInSumary].[ApproveYesTime] = @ApproveYesTime,
	[CKProductInSumary].[ApproveNoTime] = @ApproveNoTime,
	[CKProductInSumary].[ApproveMan] = @ApproveMan 
output 
	INSERTED.[ID],
	INSERTED.[AddUserName],
	INSERTED.[InTime],
	INSERTED.[OrderNumber],
	INSERTED.[ContractID],
	INSERTED.[ContractUserName],
	INSERTED.[ContractPhoneNumber],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ContractName],
	INSERTED.[OrderNumberID],
	INSERTED.[InCategoryID],
	INSERTED.[BelongTeamName],
	INSERTED.[BelongDepartmentID],
	INSERTED.[CKCategoryID],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveYesTime],
	INSERTED.[ApproveNoTime],
	INSERTED.[ApproveMan]
into @table
WHERE 
	[CKProductInSumary].[ID] = @ID

SELECT 
	[ID],
	[AddUserName],
	[InTime],
	[OrderNumber],
	[ContractID],
	[ContractUserName],
	[ContractPhoneNumber],
	[AddTime],
	[AddMan],
	[ContractName],
	[OrderNumberID],
	[InCategoryID],
	[BelongTeamName],
	[BelongDepartmentID],
	[CKCategoryID],
	[ApproveStatus],
	[ApproveYesTime],
	[ApproveNoTime],
	[ApproveMan] 
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
DELETE FROM [dbo].[CKProductInSumary]
WHERE 
	[CKProductInSumary].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CKProductInSumary() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCKProductInSumary(this.ID));
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
	[CKProductInSumary].[ID],
	[CKProductInSumary].[AddUserName],
	[CKProductInSumary].[InTime],
	[CKProductInSumary].[OrderNumber],
	[CKProductInSumary].[ContractID],
	[CKProductInSumary].[ContractUserName],
	[CKProductInSumary].[ContractPhoneNumber],
	[CKProductInSumary].[AddTime],
	[CKProductInSumary].[AddMan],
	[CKProductInSumary].[ContractName],
	[CKProductInSumary].[OrderNumberID],
	[CKProductInSumary].[InCategoryID],
	[CKProductInSumary].[BelongTeamName],
	[CKProductInSumary].[BelongDepartmentID],
	[CKProductInSumary].[CKCategoryID],
	[CKProductInSumary].[ApproveStatus],
	[CKProductInSumary].[ApproveYesTime],
	[CKProductInSumary].[ApproveNoTime],
	[CKProductInSumary].[ApproveMan]
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
                return "CKProductInSumary";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CKProductInSumary into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="addUserName">addUserName</param>
		/// <param name="inTime">inTime</param>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="contractID">contractID</param>
		/// <param name="contractUserName">contractUserName</param>
		/// <param name="contractPhoneNumber">contractPhoneNumber</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="contractName">contractName</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="inCategoryID">inCategoryID</param>
		/// <param name="belongTeamName">belongTeamName</param>
		/// <param name="belongDepartmentID">belongDepartmentID</param>
		/// <param name="cKCategoryID">cKCategoryID</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveYesTime">approveYesTime</param>
		/// <param name="approveNoTime">approveNoTime</param>
		/// <param name="approveMan">approveMan</param>
		public static void InsertCKProductInSumary(string @addUserName, DateTime @inTime, string @orderNumber, int @contractID, string @contractUserName, string @contractPhoneNumber, DateTime @addTime, string @addMan, string @contractName, int @orderNumberID, int @inCategoryID, string @belongTeamName, int @belongDepartmentID, int @cKCategoryID, int @approveStatus, DateTime @approveYesTime, DateTime @approveNoTime, string @approveMan)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCKProductInSumary(@addUserName, @inTime, @orderNumber, @contractID, @contractUserName, @contractPhoneNumber, @addTime, @addMan, @contractName, @orderNumberID, @inCategoryID, @belongTeamName, @belongDepartmentID, @cKCategoryID, @approveStatus, @approveYesTime, @approveNoTime, @approveMan, helper);
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
		/// Insert a CKProductInSumary into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="addUserName">addUserName</param>
		/// <param name="inTime">inTime</param>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="contractID">contractID</param>
		/// <param name="contractUserName">contractUserName</param>
		/// <param name="contractPhoneNumber">contractPhoneNumber</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="contractName">contractName</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="inCategoryID">inCategoryID</param>
		/// <param name="belongTeamName">belongTeamName</param>
		/// <param name="belongDepartmentID">belongDepartmentID</param>
		/// <param name="cKCategoryID">cKCategoryID</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveYesTime">approveYesTime</param>
		/// <param name="approveNoTime">approveNoTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="helper">helper</param>
		internal static void InsertCKProductInSumary(string @addUserName, DateTime @inTime, string @orderNumber, int @contractID, string @contractUserName, string @contractPhoneNumber, DateTime @addTime, string @addMan, string @contractName, int @orderNumberID, int @inCategoryID, string @belongTeamName, int @belongDepartmentID, int @cKCategoryID, int @approveStatus, DateTime @approveYesTime, DateTime @approveNoTime, string @approveMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AddUserName] nvarchar(50),
	[InTime] datetime,
	[OrderNumber] nvarchar(100),
	[ContractID] int,
	[ContractUserName] nvarchar(50),
	[ContractPhoneNumber] nvarchar(50),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ContractName] nvarchar(50),
	[OrderNumberID] int,
	[InCategoryID] int,
	[BelongTeamName] nvarchar(100),
	[BelongDepartmentID] int,
	[CKCategoryID] int,
	[ApproveStatus] int,
	[ApproveYesTime] datetime,
	[ApproveNoTime] datetime,
	[ApproveMan] nvarchar(100)
);

INSERT INTO [dbo].[CKProductInSumary] (
	[CKProductInSumary].[AddUserName],
	[CKProductInSumary].[InTime],
	[CKProductInSumary].[OrderNumber],
	[CKProductInSumary].[ContractID],
	[CKProductInSumary].[ContractUserName],
	[CKProductInSumary].[ContractPhoneNumber],
	[CKProductInSumary].[AddTime],
	[CKProductInSumary].[AddMan],
	[CKProductInSumary].[ContractName],
	[CKProductInSumary].[OrderNumberID],
	[CKProductInSumary].[InCategoryID],
	[CKProductInSumary].[BelongTeamName],
	[CKProductInSumary].[BelongDepartmentID],
	[CKProductInSumary].[CKCategoryID],
	[CKProductInSumary].[ApproveStatus],
	[CKProductInSumary].[ApproveYesTime],
	[CKProductInSumary].[ApproveNoTime],
	[CKProductInSumary].[ApproveMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[AddUserName],
	INSERTED.[InTime],
	INSERTED.[OrderNumber],
	INSERTED.[ContractID],
	INSERTED.[ContractUserName],
	INSERTED.[ContractPhoneNumber],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ContractName],
	INSERTED.[OrderNumberID],
	INSERTED.[InCategoryID],
	INSERTED.[BelongTeamName],
	INSERTED.[BelongDepartmentID],
	INSERTED.[CKCategoryID],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveYesTime],
	INSERTED.[ApproveNoTime],
	INSERTED.[ApproveMan]
into @table
VALUES ( 
	@AddUserName,
	@InTime,
	@OrderNumber,
	@ContractID,
	@ContractUserName,
	@ContractPhoneNumber,
	@AddTime,
	@AddMan,
	@ContractName,
	@OrderNumberID,
	@InCategoryID,
	@BelongTeamName,
	@BelongDepartmentID,
	@CKCategoryID,
	@ApproveStatus,
	@ApproveYesTime,
	@ApproveNoTime,
	@ApproveMan 
); 

SELECT 
	[ID],
	[AddUserName],
	[InTime],
	[OrderNumber],
	[ContractID],
	[ContractUserName],
	[ContractPhoneNumber],
	[AddTime],
	[AddMan],
	[ContractName],
	[OrderNumberID],
	[InCategoryID],
	[BelongTeamName],
	[BelongDepartmentID],
	[CKCategoryID],
	[ApproveStatus],
	[ApproveYesTime],
	[ApproveNoTime],
	[ApproveMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@InTime", EntityBase.GetDatabaseValue(@inTime)));
			parameters.Add(new SqlParameter("@OrderNumber", EntityBase.GetDatabaseValue(@orderNumber)));
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@ContractUserName", EntityBase.GetDatabaseValue(@contractUserName)));
			parameters.Add(new SqlParameter("@ContractPhoneNumber", EntityBase.GetDatabaseValue(@contractPhoneNumber)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ContractName", EntityBase.GetDatabaseValue(@contractName)));
			parameters.Add(new SqlParameter("@OrderNumberID", EntityBase.GetDatabaseValue(@orderNumberID)));
			parameters.Add(new SqlParameter("@InCategoryID", EntityBase.GetDatabaseValue(@inCategoryID)));
			parameters.Add(new SqlParameter("@BelongTeamName", EntityBase.GetDatabaseValue(@belongTeamName)));
			parameters.Add(new SqlParameter("@BelongDepartmentID", EntityBase.GetDatabaseValue(@belongDepartmentID)));
			parameters.Add(new SqlParameter("@CKCategoryID", EntityBase.GetDatabaseValue(@cKCategoryID)));
			parameters.Add(new SqlParameter("@ApproveStatus", EntityBase.GetDatabaseValue(@approveStatus)));
			parameters.Add(new SqlParameter("@ApproveYesTime", EntityBase.GetDatabaseValue(@approveYesTime)));
			parameters.Add(new SqlParameter("@ApproveNoTime", EntityBase.GetDatabaseValue(@approveNoTime)));
			parameters.Add(new SqlParameter("@ApproveMan", EntityBase.GetDatabaseValue(@approveMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CKProductInSumary into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="inTime">inTime</param>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="contractID">contractID</param>
		/// <param name="contractUserName">contractUserName</param>
		/// <param name="contractPhoneNumber">contractPhoneNumber</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="contractName">contractName</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="inCategoryID">inCategoryID</param>
		/// <param name="belongTeamName">belongTeamName</param>
		/// <param name="belongDepartmentID">belongDepartmentID</param>
		/// <param name="cKCategoryID">cKCategoryID</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveYesTime">approveYesTime</param>
		/// <param name="approveNoTime">approveNoTime</param>
		/// <param name="approveMan">approveMan</param>
		public static void UpdateCKProductInSumary(int @iD, string @addUserName, DateTime @inTime, string @orderNumber, int @contractID, string @contractUserName, string @contractPhoneNumber, DateTime @addTime, string @addMan, string @contractName, int @orderNumberID, int @inCategoryID, string @belongTeamName, int @belongDepartmentID, int @cKCategoryID, int @approveStatus, DateTime @approveYesTime, DateTime @approveNoTime, string @approveMan)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCKProductInSumary(@iD, @addUserName, @inTime, @orderNumber, @contractID, @contractUserName, @contractPhoneNumber, @addTime, @addMan, @contractName, @orderNumberID, @inCategoryID, @belongTeamName, @belongDepartmentID, @cKCategoryID, @approveStatus, @approveYesTime, @approveNoTime, @approveMan, helper);
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
		/// Updates a CKProductInSumary into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="inTime">inTime</param>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="contractID">contractID</param>
		/// <param name="contractUserName">contractUserName</param>
		/// <param name="contractPhoneNumber">contractPhoneNumber</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="contractName">contractName</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="inCategoryID">inCategoryID</param>
		/// <param name="belongTeamName">belongTeamName</param>
		/// <param name="belongDepartmentID">belongDepartmentID</param>
		/// <param name="cKCategoryID">cKCategoryID</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveYesTime">approveYesTime</param>
		/// <param name="approveNoTime">approveNoTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCKProductInSumary(int @iD, string @addUserName, DateTime @inTime, string @orderNumber, int @contractID, string @contractUserName, string @contractPhoneNumber, DateTime @addTime, string @addMan, string @contractName, int @orderNumberID, int @inCategoryID, string @belongTeamName, int @belongDepartmentID, int @cKCategoryID, int @approveStatus, DateTime @approveYesTime, DateTime @approveNoTime, string @approveMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AddUserName] nvarchar(50),
	[InTime] datetime,
	[OrderNumber] nvarchar(100),
	[ContractID] int,
	[ContractUserName] nvarchar(50),
	[ContractPhoneNumber] nvarchar(50),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ContractName] nvarchar(50),
	[OrderNumberID] int,
	[InCategoryID] int,
	[BelongTeamName] nvarchar(100),
	[BelongDepartmentID] int,
	[CKCategoryID] int,
	[ApproveStatus] int,
	[ApproveYesTime] datetime,
	[ApproveNoTime] datetime,
	[ApproveMan] nvarchar(100)
);

UPDATE [dbo].[CKProductInSumary] SET 
	[CKProductInSumary].[AddUserName] = @AddUserName,
	[CKProductInSumary].[InTime] = @InTime,
	[CKProductInSumary].[OrderNumber] = @OrderNumber,
	[CKProductInSumary].[ContractID] = @ContractID,
	[CKProductInSumary].[ContractUserName] = @ContractUserName,
	[CKProductInSumary].[ContractPhoneNumber] = @ContractPhoneNumber,
	[CKProductInSumary].[AddTime] = @AddTime,
	[CKProductInSumary].[AddMan] = @AddMan,
	[CKProductInSumary].[ContractName] = @ContractName,
	[CKProductInSumary].[OrderNumberID] = @OrderNumberID,
	[CKProductInSumary].[InCategoryID] = @InCategoryID,
	[CKProductInSumary].[BelongTeamName] = @BelongTeamName,
	[CKProductInSumary].[BelongDepartmentID] = @BelongDepartmentID,
	[CKProductInSumary].[CKCategoryID] = @CKCategoryID,
	[CKProductInSumary].[ApproveStatus] = @ApproveStatus,
	[CKProductInSumary].[ApproveYesTime] = @ApproveYesTime,
	[CKProductInSumary].[ApproveNoTime] = @ApproveNoTime,
	[CKProductInSumary].[ApproveMan] = @ApproveMan 
output 
	INSERTED.[ID],
	INSERTED.[AddUserName],
	INSERTED.[InTime],
	INSERTED.[OrderNumber],
	INSERTED.[ContractID],
	INSERTED.[ContractUserName],
	INSERTED.[ContractPhoneNumber],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ContractName],
	INSERTED.[OrderNumberID],
	INSERTED.[InCategoryID],
	INSERTED.[BelongTeamName],
	INSERTED.[BelongDepartmentID],
	INSERTED.[CKCategoryID],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveYesTime],
	INSERTED.[ApproveNoTime],
	INSERTED.[ApproveMan]
into @table
WHERE 
	[CKProductInSumary].[ID] = @ID

SELECT 
	[ID],
	[AddUserName],
	[InTime],
	[OrderNumber],
	[ContractID],
	[ContractUserName],
	[ContractPhoneNumber],
	[AddTime],
	[AddMan],
	[ContractName],
	[OrderNumberID],
	[InCategoryID],
	[BelongTeamName],
	[BelongDepartmentID],
	[CKCategoryID],
	[ApproveStatus],
	[ApproveYesTime],
	[ApproveNoTime],
	[ApproveMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@InTime", EntityBase.GetDatabaseValue(@inTime)));
			parameters.Add(new SqlParameter("@OrderNumber", EntityBase.GetDatabaseValue(@orderNumber)));
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@ContractUserName", EntityBase.GetDatabaseValue(@contractUserName)));
			parameters.Add(new SqlParameter("@ContractPhoneNumber", EntityBase.GetDatabaseValue(@contractPhoneNumber)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ContractName", EntityBase.GetDatabaseValue(@contractName)));
			parameters.Add(new SqlParameter("@OrderNumberID", EntityBase.GetDatabaseValue(@orderNumberID)));
			parameters.Add(new SqlParameter("@InCategoryID", EntityBase.GetDatabaseValue(@inCategoryID)));
			parameters.Add(new SqlParameter("@BelongTeamName", EntityBase.GetDatabaseValue(@belongTeamName)));
			parameters.Add(new SqlParameter("@BelongDepartmentID", EntityBase.GetDatabaseValue(@belongDepartmentID)));
			parameters.Add(new SqlParameter("@CKCategoryID", EntityBase.GetDatabaseValue(@cKCategoryID)));
			parameters.Add(new SqlParameter("@ApproveStatus", EntityBase.GetDatabaseValue(@approveStatus)));
			parameters.Add(new SqlParameter("@ApproveYesTime", EntityBase.GetDatabaseValue(@approveYesTime)));
			parameters.Add(new SqlParameter("@ApproveNoTime", EntityBase.GetDatabaseValue(@approveNoTime)));
			parameters.Add(new SqlParameter("@ApproveMan", EntityBase.GetDatabaseValue(@approveMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CKProductInSumary from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCKProductInSumary(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCKProductInSumary(@iD, helper);
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
		/// Deletes a CKProductInSumary from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCKProductInSumary(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CKProductInSumary]
WHERE 
	[CKProductInSumary].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CKProductInSumary object.
		/// </summary>
		/// <returns>The newly created CKProductInSumary object.</returns>
		public static CKProductInSumary CreateCKProductInSumary()
		{
			return InitializeNew<CKProductInSumary>();
		}
		
		/// <summary>
		/// Retrieve information for a CKProductInSumary by a CKProductInSumary's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CKProductInSumary</returns>
		public static CKProductInSumary GetCKProductInSumary(int @iD)
		{
			string commandText = @"
SELECT 
" + CKProductInSumary.SelectFieldList + @"
FROM [dbo].[CKProductInSumary] 
WHERE 
	[CKProductInSumary].[ID] = @ID " + CKProductInSumary.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKProductInSumary>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CKProductInSumary by a CKProductInSumary's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CKProductInSumary</returns>
		public static CKProductInSumary GetCKProductInSumary(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CKProductInSumary.SelectFieldList + @"
FROM [dbo].[CKProductInSumary] 
WHERE 
	[CKProductInSumary].[ID] = @ID " + CKProductInSumary.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKProductInSumary>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CKProductInSumary objects.
		/// </summary>
		/// <returns>The retrieved collection of CKProductInSumary objects.</returns>
		public static EntityList<CKProductInSumary> GetCKProductInSumaries()
		{
			string commandText = @"
SELECT " + CKProductInSumary.SelectFieldList + "FROM [dbo].[CKProductInSumary] " + CKProductInSumary.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CKProductInSumary>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CKProductInSumary objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKProductInSumary objects.</returns>
        public static EntityList<CKProductInSumary> GetCKProductInSumaries(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKProductInSumary>(SelectFieldList, "FROM [dbo].[CKProductInSumary]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CKProductInSumary objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKProductInSumary objects.</returns>
        public static EntityList<CKProductInSumary> GetCKProductInSumaries(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKProductInSumary>(SelectFieldList, "FROM [dbo].[CKProductInSumary]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CKProductInSumary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CKProductInSumary objects.</returns>
		protected static EntityList<CKProductInSumary> GetCKProductInSumaries(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKProductInSumaries(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CKProductInSumary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKProductInSumary objects.</returns>
		protected static EntityList<CKProductInSumary> GetCKProductInSumaries(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKProductInSumaries(string.Empty, where, parameters, CKProductInSumary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProductInSumary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKProductInSumary objects.</returns>
		protected static EntityList<CKProductInSumary> GetCKProductInSumaries(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKProductInSumaries(prefix, where, parameters, CKProductInSumary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProductInSumary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKProductInSumary objects.</returns>
		protected static EntityList<CKProductInSumary> GetCKProductInSumaries(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKProductInSumaries(string.Empty, where, parameters, CKProductInSumary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProductInSumary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKProductInSumary objects.</returns>
		protected static EntityList<CKProductInSumary> GetCKProductInSumaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKProductInSumaries(prefix, where, parameters, CKProductInSumary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProductInSumary objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CKProductInSumary objects.</returns>
		protected static EntityList<CKProductInSumary> GetCKProductInSumaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CKProductInSumary.SelectFieldList + "FROM [dbo].[CKProductInSumary] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CKProductInSumary>(reader);
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
        protected static EntityList<CKProductInSumary> GetCKProductInSumaries(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKProductInSumary>(SelectFieldList, "FROM [dbo].[CKProductInSumary] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CKProductInSumary objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKProductInSumaryCount()
        {
            return GetCKProductInSumaryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CKProductInSumary objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKProductInSumaryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CKProductInSumary] " + where;

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
		public static partial class CKProductInSumary_Properties
		{
			public const string ID = "ID";
			public const string AddUserName = "AddUserName";
			public const string InTime = "InTime";
			public const string OrderNumber = "OrderNumber";
			public const string ContractID = "ContractID";
			public const string ContractUserName = "ContractUserName";
			public const string ContractPhoneNumber = "ContractPhoneNumber";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string ContractName = "ContractName";
			public const string OrderNumberID = "OrderNumberID";
			public const string InCategoryID = "InCategoryID";
			public const string BelongTeamName = "BelongTeamName";
			public const string BelongDepartmentID = "BelongDepartmentID";
			public const string CKCategoryID = "CKCategoryID";
			public const string ApproveStatus = "ApproveStatus";
			public const string ApproveYesTime = "ApproveYesTime";
			public const string ApproveNoTime = "ApproveNoTime";
			public const string ApproveMan = "ApproveMan";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"AddUserName" , "string:"},
    			 {"InTime" , "DateTime:"},
    			 {"OrderNumber" , "string:"},
    			 {"ContractID" , "int:"},
    			 {"ContractUserName" , "string:"},
    			 {"ContractPhoneNumber" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"ContractName" , "string:"},
    			 {"OrderNumberID" , "int:"},
    			 {"InCategoryID" , "int:"},
    			 {"BelongTeamName" , "string:"},
    			 {"BelongDepartmentID" , "int:"},
    			 {"CKCategoryID" , "int:"},
    			 {"ApproveStatus" , "int:"},
    			 {"ApproveYesTime" , "DateTime:"},
    			 {"ApproveNoTime" , "DateTime:"},
    			 {"ApproveMan" , "string:"},
            };
		}
		#endregion
	}
}
