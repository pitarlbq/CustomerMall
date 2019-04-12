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
	/// This object represents the properties and methods of a CKProductOutSumary.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CKProductOutSumary 
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
		private DateTime _outTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private string _orderNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private int _acceptUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int AcceptUserID
		{
			[DebuggerStepThrough()]
			get { return this._acceptUserID; }
			set 
			{
				if (this._acceptUserID != value) 
				{
					this._acceptUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AcceptUserID");
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
		private string _acceptUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AcceptUserName
		{
			[DebuggerStepThrough()]
			get { return this._acceptUserName; }
			set 
			{
				if (this._acceptUserName != value) 
				{
					this._acceptUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AcceptUserName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _accpetDepartmentName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AccpetDepartmentName
		{
			[DebuggerStepThrough()]
			get { return this._accpetDepartmentName; }
			set 
			{
				if (this._accpetDepartmentName != value) 
				{
					this._accpetDepartmentName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AccpetDepartmentName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _useFor = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string UseFor
		{
			[DebuggerStepThrough()]
			get { return this._useFor; }
			set 
			{
				if (this._useFor != value) 
				{
					this._useFor = value;
					this.IsDirty = true;	
					OnPropertyChanged("UseFor");
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
	[OutTime] datetime,
	[OrderNumber] nvarchar(100),
	[AcceptUserID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[OrderNumberID] int,
	[AcceptUserName] nvarchar(100),
	[AccpetDepartmentName] nvarchar(100),
	[UseFor] nvarchar(100),
	[InCategoryID] int,
	[BelongTeamName] nvarchar(100),
	[BelongDepartmentID] int,
	[CKCategoryID] int,
	[ApproveStatus] int,
	[ApproveYesTime] datetime,
	[ApproveNoTime] datetime,
	[ApproveMan] nvarchar(100)
);

INSERT INTO [dbo].[CKProductOutSumary] (
	[CKProductOutSumary].[AddUserName],
	[CKProductOutSumary].[OutTime],
	[CKProductOutSumary].[OrderNumber],
	[CKProductOutSumary].[AcceptUserID],
	[CKProductOutSumary].[AddTime],
	[CKProductOutSumary].[AddMan],
	[CKProductOutSumary].[OrderNumberID],
	[CKProductOutSumary].[AcceptUserName],
	[CKProductOutSumary].[AccpetDepartmentName],
	[CKProductOutSumary].[UseFor],
	[CKProductOutSumary].[InCategoryID],
	[CKProductOutSumary].[BelongTeamName],
	[CKProductOutSumary].[BelongDepartmentID],
	[CKProductOutSumary].[CKCategoryID],
	[CKProductOutSumary].[ApproveStatus],
	[CKProductOutSumary].[ApproveYesTime],
	[CKProductOutSumary].[ApproveNoTime],
	[CKProductOutSumary].[ApproveMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[AddUserName],
	INSERTED.[OutTime],
	INSERTED.[OrderNumber],
	INSERTED.[AcceptUserID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[OrderNumberID],
	INSERTED.[AcceptUserName],
	INSERTED.[AccpetDepartmentName],
	INSERTED.[UseFor],
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
	@OutTime,
	@OrderNumber,
	@AcceptUserID,
	@AddTime,
	@AddMan,
	@OrderNumberID,
	@AcceptUserName,
	@AccpetDepartmentName,
	@UseFor,
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
	[OutTime],
	[OrderNumber],
	[AcceptUserID],
	[AddTime],
	[AddMan],
	[OrderNumberID],
	[AcceptUserName],
	[AccpetDepartmentName],
	[UseFor],
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
	[OutTime] datetime,
	[OrderNumber] nvarchar(100),
	[AcceptUserID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[OrderNumberID] int,
	[AcceptUserName] nvarchar(100),
	[AccpetDepartmentName] nvarchar(100),
	[UseFor] nvarchar(100),
	[InCategoryID] int,
	[BelongTeamName] nvarchar(100),
	[BelongDepartmentID] int,
	[CKCategoryID] int,
	[ApproveStatus] int,
	[ApproveYesTime] datetime,
	[ApproveNoTime] datetime,
	[ApproveMan] nvarchar(100)
);

UPDATE [dbo].[CKProductOutSumary] SET 
	[CKProductOutSumary].[AddUserName] = @AddUserName,
	[CKProductOutSumary].[OutTime] = @OutTime,
	[CKProductOutSumary].[OrderNumber] = @OrderNumber,
	[CKProductOutSumary].[AcceptUserID] = @AcceptUserID,
	[CKProductOutSumary].[AddTime] = @AddTime,
	[CKProductOutSumary].[AddMan] = @AddMan,
	[CKProductOutSumary].[OrderNumberID] = @OrderNumberID,
	[CKProductOutSumary].[AcceptUserName] = @AcceptUserName,
	[CKProductOutSumary].[AccpetDepartmentName] = @AccpetDepartmentName,
	[CKProductOutSumary].[UseFor] = @UseFor,
	[CKProductOutSumary].[InCategoryID] = @InCategoryID,
	[CKProductOutSumary].[BelongTeamName] = @BelongTeamName,
	[CKProductOutSumary].[BelongDepartmentID] = @BelongDepartmentID,
	[CKProductOutSumary].[CKCategoryID] = @CKCategoryID,
	[CKProductOutSumary].[ApproveStatus] = @ApproveStatus,
	[CKProductOutSumary].[ApproveYesTime] = @ApproveYesTime,
	[CKProductOutSumary].[ApproveNoTime] = @ApproveNoTime,
	[CKProductOutSumary].[ApproveMan] = @ApproveMan 
output 
	INSERTED.[ID],
	INSERTED.[AddUserName],
	INSERTED.[OutTime],
	INSERTED.[OrderNumber],
	INSERTED.[AcceptUserID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[OrderNumberID],
	INSERTED.[AcceptUserName],
	INSERTED.[AccpetDepartmentName],
	INSERTED.[UseFor],
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
	[CKProductOutSumary].[ID] = @ID

SELECT 
	[ID],
	[AddUserName],
	[OutTime],
	[OrderNumber],
	[AcceptUserID],
	[AddTime],
	[AddMan],
	[OrderNumberID],
	[AcceptUserName],
	[AccpetDepartmentName],
	[UseFor],
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
DELETE FROM [dbo].[CKProductOutSumary]
WHERE 
	[CKProductOutSumary].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CKProductOutSumary() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCKProductOutSumary(this.ID));
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
	[CKProductOutSumary].[ID],
	[CKProductOutSumary].[AddUserName],
	[CKProductOutSumary].[OutTime],
	[CKProductOutSumary].[OrderNumber],
	[CKProductOutSumary].[AcceptUserID],
	[CKProductOutSumary].[AddTime],
	[CKProductOutSumary].[AddMan],
	[CKProductOutSumary].[OrderNumberID],
	[CKProductOutSumary].[AcceptUserName],
	[CKProductOutSumary].[AccpetDepartmentName],
	[CKProductOutSumary].[UseFor],
	[CKProductOutSumary].[InCategoryID],
	[CKProductOutSumary].[BelongTeamName],
	[CKProductOutSumary].[BelongDepartmentID],
	[CKProductOutSumary].[CKCategoryID],
	[CKProductOutSumary].[ApproveStatus],
	[CKProductOutSumary].[ApproveYesTime],
	[CKProductOutSumary].[ApproveNoTime],
	[CKProductOutSumary].[ApproveMan]
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
                return "CKProductOutSumary";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CKProductOutSumary into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="addUserName">addUserName</param>
		/// <param name="outTime">outTime</param>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="acceptUserID">acceptUserID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="acceptUserName">acceptUserName</param>
		/// <param name="accpetDepartmentName">accpetDepartmentName</param>
		/// <param name="useFor">useFor</param>
		/// <param name="inCategoryID">inCategoryID</param>
		/// <param name="belongTeamName">belongTeamName</param>
		/// <param name="belongDepartmentID">belongDepartmentID</param>
		/// <param name="cKCategoryID">cKCategoryID</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveYesTime">approveYesTime</param>
		/// <param name="approveNoTime">approveNoTime</param>
		/// <param name="approveMan">approveMan</param>
		public static void InsertCKProductOutSumary(string @addUserName, DateTime @outTime, string @orderNumber, int @acceptUserID, DateTime @addTime, string @addMan, int @orderNumberID, string @acceptUserName, string @accpetDepartmentName, string @useFor, int @inCategoryID, string @belongTeamName, int @belongDepartmentID, int @cKCategoryID, int @approveStatus, DateTime @approveYesTime, DateTime @approveNoTime, string @approveMan)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCKProductOutSumary(@addUserName, @outTime, @orderNumber, @acceptUserID, @addTime, @addMan, @orderNumberID, @acceptUserName, @accpetDepartmentName, @useFor, @inCategoryID, @belongTeamName, @belongDepartmentID, @cKCategoryID, @approveStatus, @approveYesTime, @approveNoTime, @approveMan, helper);
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
		/// Insert a CKProductOutSumary into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="addUserName">addUserName</param>
		/// <param name="outTime">outTime</param>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="acceptUserID">acceptUserID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="acceptUserName">acceptUserName</param>
		/// <param name="accpetDepartmentName">accpetDepartmentName</param>
		/// <param name="useFor">useFor</param>
		/// <param name="inCategoryID">inCategoryID</param>
		/// <param name="belongTeamName">belongTeamName</param>
		/// <param name="belongDepartmentID">belongDepartmentID</param>
		/// <param name="cKCategoryID">cKCategoryID</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveYesTime">approveYesTime</param>
		/// <param name="approveNoTime">approveNoTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="helper">helper</param>
		internal static void InsertCKProductOutSumary(string @addUserName, DateTime @outTime, string @orderNumber, int @acceptUserID, DateTime @addTime, string @addMan, int @orderNumberID, string @acceptUserName, string @accpetDepartmentName, string @useFor, int @inCategoryID, string @belongTeamName, int @belongDepartmentID, int @cKCategoryID, int @approveStatus, DateTime @approveYesTime, DateTime @approveNoTime, string @approveMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AddUserName] nvarchar(50),
	[OutTime] datetime,
	[OrderNumber] nvarchar(100),
	[AcceptUserID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[OrderNumberID] int,
	[AcceptUserName] nvarchar(100),
	[AccpetDepartmentName] nvarchar(100),
	[UseFor] nvarchar(100),
	[InCategoryID] int,
	[BelongTeamName] nvarchar(100),
	[BelongDepartmentID] int,
	[CKCategoryID] int,
	[ApproveStatus] int,
	[ApproveYesTime] datetime,
	[ApproveNoTime] datetime,
	[ApproveMan] nvarchar(100)
);

INSERT INTO [dbo].[CKProductOutSumary] (
	[CKProductOutSumary].[AddUserName],
	[CKProductOutSumary].[OutTime],
	[CKProductOutSumary].[OrderNumber],
	[CKProductOutSumary].[AcceptUserID],
	[CKProductOutSumary].[AddTime],
	[CKProductOutSumary].[AddMan],
	[CKProductOutSumary].[OrderNumberID],
	[CKProductOutSumary].[AcceptUserName],
	[CKProductOutSumary].[AccpetDepartmentName],
	[CKProductOutSumary].[UseFor],
	[CKProductOutSumary].[InCategoryID],
	[CKProductOutSumary].[BelongTeamName],
	[CKProductOutSumary].[BelongDepartmentID],
	[CKProductOutSumary].[CKCategoryID],
	[CKProductOutSumary].[ApproveStatus],
	[CKProductOutSumary].[ApproveYesTime],
	[CKProductOutSumary].[ApproveNoTime],
	[CKProductOutSumary].[ApproveMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[AddUserName],
	INSERTED.[OutTime],
	INSERTED.[OrderNumber],
	INSERTED.[AcceptUserID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[OrderNumberID],
	INSERTED.[AcceptUserName],
	INSERTED.[AccpetDepartmentName],
	INSERTED.[UseFor],
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
	@OutTime,
	@OrderNumber,
	@AcceptUserID,
	@AddTime,
	@AddMan,
	@OrderNumberID,
	@AcceptUserName,
	@AccpetDepartmentName,
	@UseFor,
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
	[OutTime],
	[OrderNumber],
	[AcceptUserID],
	[AddTime],
	[AddMan],
	[OrderNumberID],
	[AcceptUserName],
	[AccpetDepartmentName],
	[UseFor],
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
			parameters.Add(new SqlParameter("@OutTime", EntityBase.GetDatabaseValue(@outTime)));
			parameters.Add(new SqlParameter("@OrderNumber", EntityBase.GetDatabaseValue(@orderNumber)));
			parameters.Add(new SqlParameter("@AcceptUserID", EntityBase.GetDatabaseValue(@acceptUserID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@OrderNumberID", EntityBase.GetDatabaseValue(@orderNumberID)));
			parameters.Add(new SqlParameter("@AcceptUserName", EntityBase.GetDatabaseValue(@acceptUserName)));
			parameters.Add(new SqlParameter("@AccpetDepartmentName", EntityBase.GetDatabaseValue(@accpetDepartmentName)));
			parameters.Add(new SqlParameter("@UseFor", EntityBase.GetDatabaseValue(@useFor)));
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
		/// Updates a CKProductOutSumary into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="outTime">outTime</param>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="acceptUserID">acceptUserID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="acceptUserName">acceptUserName</param>
		/// <param name="accpetDepartmentName">accpetDepartmentName</param>
		/// <param name="useFor">useFor</param>
		/// <param name="inCategoryID">inCategoryID</param>
		/// <param name="belongTeamName">belongTeamName</param>
		/// <param name="belongDepartmentID">belongDepartmentID</param>
		/// <param name="cKCategoryID">cKCategoryID</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveYesTime">approveYesTime</param>
		/// <param name="approveNoTime">approveNoTime</param>
		/// <param name="approveMan">approveMan</param>
		public static void UpdateCKProductOutSumary(int @iD, string @addUserName, DateTime @outTime, string @orderNumber, int @acceptUserID, DateTime @addTime, string @addMan, int @orderNumberID, string @acceptUserName, string @accpetDepartmentName, string @useFor, int @inCategoryID, string @belongTeamName, int @belongDepartmentID, int @cKCategoryID, int @approveStatus, DateTime @approveYesTime, DateTime @approveNoTime, string @approveMan)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCKProductOutSumary(@iD, @addUserName, @outTime, @orderNumber, @acceptUserID, @addTime, @addMan, @orderNumberID, @acceptUserName, @accpetDepartmentName, @useFor, @inCategoryID, @belongTeamName, @belongDepartmentID, @cKCategoryID, @approveStatus, @approveYesTime, @approveNoTime, @approveMan, helper);
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
		/// Updates a CKProductOutSumary into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="outTime">outTime</param>
		/// <param name="orderNumber">orderNumber</param>
		/// <param name="acceptUserID">acceptUserID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="acceptUserName">acceptUserName</param>
		/// <param name="accpetDepartmentName">accpetDepartmentName</param>
		/// <param name="useFor">useFor</param>
		/// <param name="inCategoryID">inCategoryID</param>
		/// <param name="belongTeamName">belongTeamName</param>
		/// <param name="belongDepartmentID">belongDepartmentID</param>
		/// <param name="cKCategoryID">cKCategoryID</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveYesTime">approveYesTime</param>
		/// <param name="approveNoTime">approveNoTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCKProductOutSumary(int @iD, string @addUserName, DateTime @outTime, string @orderNumber, int @acceptUserID, DateTime @addTime, string @addMan, int @orderNumberID, string @acceptUserName, string @accpetDepartmentName, string @useFor, int @inCategoryID, string @belongTeamName, int @belongDepartmentID, int @cKCategoryID, int @approveStatus, DateTime @approveYesTime, DateTime @approveNoTime, string @approveMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AddUserName] nvarchar(50),
	[OutTime] datetime,
	[OrderNumber] nvarchar(100),
	[AcceptUserID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[OrderNumberID] int,
	[AcceptUserName] nvarchar(100),
	[AccpetDepartmentName] nvarchar(100),
	[UseFor] nvarchar(100),
	[InCategoryID] int,
	[BelongTeamName] nvarchar(100),
	[BelongDepartmentID] int,
	[CKCategoryID] int,
	[ApproveStatus] int,
	[ApproveYesTime] datetime,
	[ApproveNoTime] datetime,
	[ApproveMan] nvarchar(100)
);

UPDATE [dbo].[CKProductOutSumary] SET 
	[CKProductOutSumary].[AddUserName] = @AddUserName,
	[CKProductOutSumary].[OutTime] = @OutTime,
	[CKProductOutSumary].[OrderNumber] = @OrderNumber,
	[CKProductOutSumary].[AcceptUserID] = @AcceptUserID,
	[CKProductOutSumary].[AddTime] = @AddTime,
	[CKProductOutSumary].[AddMan] = @AddMan,
	[CKProductOutSumary].[OrderNumberID] = @OrderNumberID,
	[CKProductOutSumary].[AcceptUserName] = @AcceptUserName,
	[CKProductOutSumary].[AccpetDepartmentName] = @AccpetDepartmentName,
	[CKProductOutSumary].[UseFor] = @UseFor,
	[CKProductOutSumary].[InCategoryID] = @InCategoryID,
	[CKProductOutSumary].[BelongTeamName] = @BelongTeamName,
	[CKProductOutSumary].[BelongDepartmentID] = @BelongDepartmentID,
	[CKProductOutSumary].[CKCategoryID] = @CKCategoryID,
	[CKProductOutSumary].[ApproveStatus] = @ApproveStatus,
	[CKProductOutSumary].[ApproveYesTime] = @ApproveYesTime,
	[CKProductOutSumary].[ApproveNoTime] = @ApproveNoTime,
	[CKProductOutSumary].[ApproveMan] = @ApproveMan 
output 
	INSERTED.[ID],
	INSERTED.[AddUserName],
	INSERTED.[OutTime],
	INSERTED.[OrderNumber],
	INSERTED.[AcceptUserID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[OrderNumberID],
	INSERTED.[AcceptUserName],
	INSERTED.[AccpetDepartmentName],
	INSERTED.[UseFor],
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
	[CKProductOutSumary].[ID] = @ID

SELECT 
	[ID],
	[AddUserName],
	[OutTime],
	[OrderNumber],
	[AcceptUserID],
	[AddTime],
	[AddMan],
	[OrderNumberID],
	[AcceptUserName],
	[AccpetDepartmentName],
	[UseFor],
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
			parameters.Add(new SqlParameter("@OutTime", EntityBase.GetDatabaseValue(@outTime)));
			parameters.Add(new SqlParameter("@OrderNumber", EntityBase.GetDatabaseValue(@orderNumber)));
			parameters.Add(new SqlParameter("@AcceptUserID", EntityBase.GetDatabaseValue(@acceptUserID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@OrderNumberID", EntityBase.GetDatabaseValue(@orderNumberID)));
			parameters.Add(new SqlParameter("@AcceptUserName", EntityBase.GetDatabaseValue(@acceptUserName)));
			parameters.Add(new SqlParameter("@AccpetDepartmentName", EntityBase.GetDatabaseValue(@accpetDepartmentName)));
			parameters.Add(new SqlParameter("@UseFor", EntityBase.GetDatabaseValue(@useFor)));
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
		/// Deletes a CKProductOutSumary from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCKProductOutSumary(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCKProductOutSumary(@iD, helper);
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
		/// Deletes a CKProductOutSumary from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCKProductOutSumary(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CKProductOutSumary]
WHERE 
	[CKProductOutSumary].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CKProductOutSumary object.
		/// </summary>
		/// <returns>The newly created CKProductOutSumary object.</returns>
		public static CKProductOutSumary CreateCKProductOutSumary()
		{
			return InitializeNew<CKProductOutSumary>();
		}
		
		/// <summary>
		/// Retrieve information for a CKProductOutSumary by a CKProductOutSumary's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CKProductOutSumary</returns>
		public static CKProductOutSumary GetCKProductOutSumary(int @iD)
		{
			string commandText = @"
SELECT 
" + CKProductOutSumary.SelectFieldList + @"
FROM [dbo].[CKProductOutSumary] 
WHERE 
	[CKProductOutSumary].[ID] = @ID " + CKProductOutSumary.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKProductOutSumary>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CKProductOutSumary by a CKProductOutSumary's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CKProductOutSumary</returns>
		public static CKProductOutSumary GetCKProductOutSumary(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CKProductOutSumary.SelectFieldList + @"
FROM [dbo].[CKProductOutSumary] 
WHERE 
	[CKProductOutSumary].[ID] = @ID " + CKProductOutSumary.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKProductOutSumary>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CKProductOutSumary objects.
		/// </summary>
		/// <returns>The retrieved collection of CKProductOutSumary objects.</returns>
		public static EntityList<CKProductOutSumary> GetCKProductOutSumaries()
		{
			string commandText = @"
SELECT " + CKProductOutSumary.SelectFieldList + "FROM [dbo].[CKProductOutSumary] " + CKProductOutSumary.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CKProductOutSumary>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CKProductOutSumary objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKProductOutSumary objects.</returns>
        public static EntityList<CKProductOutSumary> GetCKProductOutSumaries(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKProductOutSumary>(SelectFieldList, "FROM [dbo].[CKProductOutSumary]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CKProductOutSumary objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKProductOutSumary objects.</returns>
        public static EntityList<CKProductOutSumary> GetCKProductOutSumaries(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKProductOutSumary>(SelectFieldList, "FROM [dbo].[CKProductOutSumary]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CKProductOutSumary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CKProductOutSumary objects.</returns>
		protected static EntityList<CKProductOutSumary> GetCKProductOutSumaries(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKProductOutSumaries(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CKProductOutSumary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKProductOutSumary objects.</returns>
		protected static EntityList<CKProductOutSumary> GetCKProductOutSumaries(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKProductOutSumaries(string.Empty, where, parameters, CKProductOutSumary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProductOutSumary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKProductOutSumary objects.</returns>
		protected static EntityList<CKProductOutSumary> GetCKProductOutSumaries(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKProductOutSumaries(prefix, where, parameters, CKProductOutSumary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProductOutSumary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKProductOutSumary objects.</returns>
		protected static EntityList<CKProductOutSumary> GetCKProductOutSumaries(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKProductOutSumaries(string.Empty, where, parameters, CKProductOutSumary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProductOutSumary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKProductOutSumary objects.</returns>
		protected static EntityList<CKProductOutSumary> GetCKProductOutSumaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKProductOutSumaries(prefix, where, parameters, CKProductOutSumary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProductOutSumary objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CKProductOutSumary objects.</returns>
		protected static EntityList<CKProductOutSumary> GetCKProductOutSumaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CKProductOutSumary.SelectFieldList + "FROM [dbo].[CKProductOutSumary] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CKProductOutSumary>(reader);
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
        protected static EntityList<CKProductOutSumary> GetCKProductOutSumaries(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKProductOutSumary>(SelectFieldList, "FROM [dbo].[CKProductOutSumary] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CKProductOutSumary objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKProductOutSumaryCount()
        {
            return GetCKProductOutSumaryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CKProductOutSumary objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKProductOutSumaryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CKProductOutSumary] " + where;

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
		public static partial class CKProductOutSumary_Properties
		{
			public const string ID = "ID";
			public const string AddUserName = "AddUserName";
			public const string OutTime = "OutTime";
			public const string OrderNumber = "OrderNumber";
			public const string AcceptUserID = "AcceptUserID";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string OrderNumberID = "OrderNumberID";
			public const string AcceptUserName = "AcceptUserName";
			public const string AccpetDepartmentName = "AccpetDepartmentName";
			public const string UseFor = "UseFor";
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
    			 {"OutTime" , "DateTime:"},
    			 {"OrderNumber" , "string:"},
    			 {"AcceptUserID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"OrderNumberID" , "int:"},
    			 {"AcceptUserName" , "string:"},
    			 {"AccpetDepartmentName" , "string:"},
    			 {"UseFor" , "string:"},
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
