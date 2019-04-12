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
	/// This object represents the properties and methods of a ZhuangXiu.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ZhuangXiu 
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
		private string _applicationMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApplicationMan
		{
			[DebuggerStepThrough()]
			get { return this._applicationMan; }
			set 
			{
				if (this._applicationMan != value) 
				{
					this._applicationMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApplicationMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _phoneNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PhoneNumber
		{
			[DebuggerStepThrough()]
			get { return this._phoneNumber; }
			set 
			{
				if (this._phoneNumber != value) 
				{
					this._phoneNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("PhoneNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _depositPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal DepositPrice
		{
			[DebuggerStepThrough()]
			get { return this._depositPrice; }
			set 
			{
				if (this._depositPrice != value) 
				{
					this._depositPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("DepositPrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _zhuangXiuType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ZhuangXiuType
		{
			[DebuggerStepThrough()]
			get { return this._zhuangXiuType; }
			set 
			{
				if (this._zhuangXiuType != value) 
				{
					this._zhuangXiuType = value;
					this.IsDirty = true;	
					OnPropertyChanged("ZhuangXiuType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _typeDesc = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TypeDesc
		{
			[DebuggerStepThrough()]
			get { return this._typeDesc; }
			set 
			{
				if (this._typeDesc != value) 
				{
					this._typeDesc = value;
					this.IsDirty = true;	
					OnPropertyChanged("TypeDesc");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _status = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Status
		{
			[DebuggerStepThrough()]
			get { return this._status; }
			set 
			{
				if (this._status != value) 
				{
					this._status = value;
					this.IsDirty = true;	
					OnPropertyChanged("Status");
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
		private int _approveID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ApproveID
		{
			[DebuggerStepThrough()]
			get { return this._approveID; }
			set 
			{
				if (this._approveID != value) 
				{
					this._approveID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _yanShouTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime YanShouTime
		{
			[DebuggerStepThrough()]
			get { return this._yanShouTime; }
			set 
			{
				if (this._yanShouTime != value) 
				{
					this._yanShouTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("YanShouTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _yanShouMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string YanShouMan
		{
			[DebuggerStepThrough()]
			get { return this._yanShouMan; }
			set 
			{
				if (this._yanShouMan != value) 
				{
					this._yanShouMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("YanShouMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _yanShouRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string YanShouRemark
		{
			[DebuggerStepThrough()]
			get { return this._yanShouRemark; }
			set 
			{
				if (this._yanShouRemark != value) 
				{
					this._yanShouRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("YanShouRemark");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _confirmZXTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ConfirmZXTime
		{
			[DebuggerStepThrough()]
			get { return this._confirmZXTime; }
			set 
			{
				if (this._confirmZXTime != value) 
				{
					this._confirmZXTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ConfirmZXTime");
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
		private int _roomFeeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RoomFeeID
		{
			[DebuggerStepThrough()]
			get { return this._roomFeeID; }
			set 
			{
				if (this._roomFeeID != value) 
				{
					this._roomFeeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomFeeID");
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
	[ApplicationMan] nvarchar(50),
	[PhoneNumber] nvarchar(50),
	[DepositPrice] decimal(18, 2),
	[ZhuangXiuType] nvarchar(50),
	[TypeDesc] nchar(10),
	[Status] nvarchar(50),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ApproveID] int,
	[YanShouTime] datetime,
	[YanShouMan] nvarchar(50),
	[YanShouRemark] ntext,
	[ConfirmZXTime] datetime,
	[ChargeID] int,
	[RoomFeeID] int
);

INSERT INTO [dbo].[ZhuangXiu] (
	[ZhuangXiu].[RoomID],
	[ZhuangXiu].[ApplicationMan],
	[ZhuangXiu].[PhoneNumber],
	[ZhuangXiu].[DepositPrice],
	[ZhuangXiu].[ZhuangXiuType],
	[ZhuangXiu].[TypeDesc],
	[ZhuangXiu].[Status],
	[ZhuangXiu].[AddTime],
	[ZhuangXiu].[AddMan],
	[ZhuangXiu].[ApproveID],
	[ZhuangXiu].[YanShouTime],
	[ZhuangXiu].[YanShouMan],
	[ZhuangXiu].[YanShouRemark],
	[ZhuangXiu].[ConfirmZXTime],
	[ZhuangXiu].[ChargeID],
	[ZhuangXiu].[RoomFeeID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[ApplicationMan],
	INSERTED.[PhoneNumber],
	INSERTED.[DepositPrice],
	INSERTED.[ZhuangXiuType],
	INSERTED.[TypeDesc],
	INSERTED.[Status],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ApproveID],
	INSERTED.[YanShouTime],
	INSERTED.[YanShouMan],
	INSERTED.[YanShouRemark],
	INSERTED.[ConfirmZXTime],
	INSERTED.[ChargeID],
	INSERTED.[RoomFeeID]
into @table
VALUES ( 
	@RoomID,
	@ApplicationMan,
	@PhoneNumber,
	@DepositPrice,
	@ZhuangXiuType,
	@TypeDesc,
	@Status,
	@AddTime,
	@AddMan,
	@ApproveID,
	@YanShouTime,
	@YanShouMan,
	@YanShouRemark,
	@ConfirmZXTime,
	@ChargeID,
	@RoomFeeID 
); 

SELECT 
	[ID],
	[RoomID],
	[ApplicationMan],
	[PhoneNumber],
	[DepositPrice],
	[ZhuangXiuType],
	[TypeDesc],
	[Status],
	[AddTime],
	[AddMan],
	[ApproveID],
	[YanShouTime],
	[YanShouMan],
	[YanShouRemark],
	[ConfirmZXTime],
	[ChargeID],
	[RoomFeeID] 
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
	[ApplicationMan] nvarchar(50),
	[PhoneNumber] nvarchar(50),
	[DepositPrice] decimal(18, 2),
	[ZhuangXiuType] nvarchar(50),
	[TypeDesc] nchar(10),
	[Status] nvarchar(50),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ApproveID] int,
	[YanShouTime] datetime,
	[YanShouMan] nvarchar(50),
	[YanShouRemark] ntext,
	[ConfirmZXTime] datetime,
	[ChargeID] int,
	[RoomFeeID] int
);

UPDATE [dbo].[ZhuangXiu] SET 
	[ZhuangXiu].[RoomID] = @RoomID,
	[ZhuangXiu].[ApplicationMan] = @ApplicationMan,
	[ZhuangXiu].[PhoneNumber] = @PhoneNumber,
	[ZhuangXiu].[DepositPrice] = @DepositPrice,
	[ZhuangXiu].[ZhuangXiuType] = @ZhuangXiuType,
	[ZhuangXiu].[TypeDesc] = @TypeDesc,
	[ZhuangXiu].[Status] = @Status,
	[ZhuangXiu].[AddTime] = @AddTime,
	[ZhuangXiu].[AddMan] = @AddMan,
	[ZhuangXiu].[ApproveID] = @ApproveID,
	[ZhuangXiu].[YanShouTime] = @YanShouTime,
	[ZhuangXiu].[YanShouMan] = @YanShouMan,
	[ZhuangXiu].[YanShouRemark] = @YanShouRemark,
	[ZhuangXiu].[ConfirmZXTime] = @ConfirmZXTime,
	[ZhuangXiu].[ChargeID] = @ChargeID,
	[ZhuangXiu].[RoomFeeID] = @RoomFeeID 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[ApplicationMan],
	INSERTED.[PhoneNumber],
	INSERTED.[DepositPrice],
	INSERTED.[ZhuangXiuType],
	INSERTED.[TypeDesc],
	INSERTED.[Status],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ApproveID],
	INSERTED.[YanShouTime],
	INSERTED.[YanShouMan],
	INSERTED.[YanShouRemark],
	INSERTED.[ConfirmZXTime],
	INSERTED.[ChargeID],
	INSERTED.[RoomFeeID]
into @table
WHERE 
	[ZhuangXiu].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[ApplicationMan],
	[PhoneNumber],
	[DepositPrice],
	[ZhuangXiuType],
	[TypeDesc],
	[Status],
	[AddTime],
	[AddMan],
	[ApproveID],
	[YanShouTime],
	[YanShouMan],
	[YanShouRemark],
	[ConfirmZXTime],
	[ChargeID],
	[RoomFeeID] 
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
DELETE FROM [dbo].[ZhuangXiu]
WHERE 
	[ZhuangXiu].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ZhuangXiu() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetZhuangXiu(this.ID));
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
	[ZhuangXiu].[ID],
	[ZhuangXiu].[RoomID],
	[ZhuangXiu].[ApplicationMan],
	[ZhuangXiu].[PhoneNumber],
	[ZhuangXiu].[DepositPrice],
	[ZhuangXiu].[ZhuangXiuType],
	[ZhuangXiu].[TypeDesc],
	[ZhuangXiu].[Status],
	[ZhuangXiu].[AddTime],
	[ZhuangXiu].[AddMan],
	[ZhuangXiu].[ApproveID],
	[ZhuangXiu].[YanShouTime],
	[ZhuangXiu].[YanShouMan],
	[ZhuangXiu].[YanShouRemark],
	[ZhuangXiu].[ConfirmZXTime],
	[ZhuangXiu].[ChargeID],
	[ZhuangXiu].[RoomFeeID]
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
                return "ZhuangXiu";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ZhuangXiu into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="applicationMan">applicationMan</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="depositPrice">depositPrice</param>
		/// <param name="zhuangXiuType">zhuangXiuType</param>
		/// <param name="typeDesc">typeDesc</param>
		/// <param name="status">status</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="approveID">approveID</param>
		/// <param name="yanShouTime">yanShouTime</param>
		/// <param name="yanShouMan">yanShouMan</param>
		/// <param name="yanShouRemark">yanShouRemark</param>
		/// <param name="confirmZXTime">confirmZXTime</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="roomFeeID">roomFeeID</param>
		public static void InsertZhuangXiu(int @roomID, string @applicationMan, string @phoneNumber, decimal @depositPrice, string @zhuangXiuType, string @typeDesc, string @status, DateTime @addTime, string @addMan, int @approveID, DateTime @yanShouTime, string @yanShouMan, string @yanShouRemark, DateTime @confirmZXTime, int @chargeID, int @roomFeeID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertZhuangXiu(@roomID, @applicationMan, @phoneNumber, @depositPrice, @zhuangXiuType, @typeDesc, @status, @addTime, @addMan, @approveID, @yanShouTime, @yanShouMan, @yanShouRemark, @confirmZXTime, @chargeID, @roomFeeID, helper);
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
		/// Insert a ZhuangXiu into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="applicationMan">applicationMan</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="depositPrice">depositPrice</param>
		/// <param name="zhuangXiuType">zhuangXiuType</param>
		/// <param name="typeDesc">typeDesc</param>
		/// <param name="status">status</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="approveID">approveID</param>
		/// <param name="yanShouTime">yanShouTime</param>
		/// <param name="yanShouMan">yanShouMan</param>
		/// <param name="yanShouRemark">yanShouRemark</param>
		/// <param name="confirmZXTime">confirmZXTime</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="roomFeeID">roomFeeID</param>
		/// <param name="helper">helper</param>
		internal static void InsertZhuangXiu(int @roomID, string @applicationMan, string @phoneNumber, decimal @depositPrice, string @zhuangXiuType, string @typeDesc, string @status, DateTime @addTime, string @addMan, int @approveID, DateTime @yanShouTime, string @yanShouMan, string @yanShouRemark, DateTime @confirmZXTime, int @chargeID, int @roomFeeID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[ApplicationMan] nvarchar(50),
	[PhoneNumber] nvarchar(50),
	[DepositPrice] decimal(18, 2),
	[ZhuangXiuType] nvarchar(50),
	[TypeDesc] nchar(10),
	[Status] nvarchar(50),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ApproveID] int,
	[YanShouTime] datetime,
	[YanShouMan] nvarchar(50),
	[YanShouRemark] ntext,
	[ConfirmZXTime] datetime,
	[ChargeID] int,
	[RoomFeeID] int
);

INSERT INTO [dbo].[ZhuangXiu] (
	[ZhuangXiu].[RoomID],
	[ZhuangXiu].[ApplicationMan],
	[ZhuangXiu].[PhoneNumber],
	[ZhuangXiu].[DepositPrice],
	[ZhuangXiu].[ZhuangXiuType],
	[ZhuangXiu].[TypeDesc],
	[ZhuangXiu].[Status],
	[ZhuangXiu].[AddTime],
	[ZhuangXiu].[AddMan],
	[ZhuangXiu].[ApproveID],
	[ZhuangXiu].[YanShouTime],
	[ZhuangXiu].[YanShouMan],
	[ZhuangXiu].[YanShouRemark],
	[ZhuangXiu].[ConfirmZXTime],
	[ZhuangXiu].[ChargeID],
	[ZhuangXiu].[RoomFeeID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[ApplicationMan],
	INSERTED.[PhoneNumber],
	INSERTED.[DepositPrice],
	INSERTED.[ZhuangXiuType],
	INSERTED.[TypeDesc],
	INSERTED.[Status],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ApproveID],
	INSERTED.[YanShouTime],
	INSERTED.[YanShouMan],
	INSERTED.[YanShouRemark],
	INSERTED.[ConfirmZXTime],
	INSERTED.[ChargeID],
	INSERTED.[RoomFeeID]
into @table
VALUES ( 
	@RoomID,
	@ApplicationMan,
	@PhoneNumber,
	@DepositPrice,
	@ZhuangXiuType,
	@TypeDesc,
	@Status,
	@AddTime,
	@AddMan,
	@ApproveID,
	@YanShouTime,
	@YanShouMan,
	@YanShouRemark,
	@ConfirmZXTime,
	@ChargeID,
	@RoomFeeID 
); 

SELECT 
	[ID],
	[RoomID],
	[ApplicationMan],
	[PhoneNumber],
	[DepositPrice],
	[ZhuangXiuType],
	[TypeDesc],
	[Status],
	[AddTime],
	[AddMan],
	[ApproveID],
	[YanShouTime],
	[YanShouMan],
	[YanShouRemark],
	[ConfirmZXTime],
	[ChargeID],
	[RoomFeeID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@ApplicationMan", EntityBase.GetDatabaseValue(@applicationMan)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@DepositPrice", EntityBase.GetDatabaseValue(@depositPrice)));
			parameters.Add(new SqlParameter("@ZhuangXiuType", EntityBase.GetDatabaseValue(@zhuangXiuType)));
			parameters.Add(new SqlParameter("@TypeDesc", EntityBase.GetDatabaseValue(@typeDesc)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ApproveID", EntityBase.GetDatabaseValue(@approveID)));
			parameters.Add(new SqlParameter("@YanShouTime", EntityBase.GetDatabaseValue(@yanShouTime)));
			parameters.Add(new SqlParameter("@YanShouMan", EntityBase.GetDatabaseValue(@yanShouMan)));
			parameters.Add(new SqlParameter("@YanShouRemark", EntityBase.GetDatabaseValue(@yanShouRemark)));
			parameters.Add(new SqlParameter("@ConfirmZXTime", EntityBase.GetDatabaseValue(@confirmZXTime)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@RoomFeeID", EntityBase.GetDatabaseValue(@roomFeeID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ZhuangXiu into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="applicationMan">applicationMan</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="depositPrice">depositPrice</param>
		/// <param name="zhuangXiuType">zhuangXiuType</param>
		/// <param name="typeDesc">typeDesc</param>
		/// <param name="status">status</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="approveID">approveID</param>
		/// <param name="yanShouTime">yanShouTime</param>
		/// <param name="yanShouMan">yanShouMan</param>
		/// <param name="yanShouRemark">yanShouRemark</param>
		/// <param name="confirmZXTime">confirmZXTime</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="roomFeeID">roomFeeID</param>
		public static void UpdateZhuangXiu(int @iD, int @roomID, string @applicationMan, string @phoneNumber, decimal @depositPrice, string @zhuangXiuType, string @typeDesc, string @status, DateTime @addTime, string @addMan, int @approveID, DateTime @yanShouTime, string @yanShouMan, string @yanShouRemark, DateTime @confirmZXTime, int @chargeID, int @roomFeeID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateZhuangXiu(@iD, @roomID, @applicationMan, @phoneNumber, @depositPrice, @zhuangXiuType, @typeDesc, @status, @addTime, @addMan, @approveID, @yanShouTime, @yanShouMan, @yanShouRemark, @confirmZXTime, @chargeID, @roomFeeID, helper);
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
		/// Updates a ZhuangXiu into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="applicationMan">applicationMan</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="depositPrice">depositPrice</param>
		/// <param name="zhuangXiuType">zhuangXiuType</param>
		/// <param name="typeDesc">typeDesc</param>
		/// <param name="status">status</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="approveID">approveID</param>
		/// <param name="yanShouTime">yanShouTime</param>
		/// <param name="yanShouMan">yanShouMan</param>
		/// <param name="yanShouRemark">yanShouRemark</param>
		/// <param name="confirmZXTime">confirmZXTime</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="roomFeeID">roomFeeID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateZhuangXiu(int @iD, int @roomID, string @applicationMan, string @phoneNumber, decimal @depositPrice, string @zhuangXiuType, string @typeDesc, string @status, DateTime @addTime, string @addMan, int @approveID, DateTime @yanShouTime, string @yanShouMan, string @yanShouRemark, DateTime @confirmZXTime, int @chargeID, int @roomFeeID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[ApplicationMan] nvarchar(50),
	[PhoneNumber] nvarchar(50),
	[DepositPrice] decimal(18, 2),
	[ZhuangXiuType] nvarchar(50),
	[TypeDesc] nchar(10),
	[Status] nvarchar(50),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ApproveID] int,
	[YanShouTime] datetime,
	[YanShouMan] nvarchar(50),
	[YanShouRemark] ntext,
	[ConfirmZXTime] datetime,
	[ChargeID] int,
	[RoomFeeID] int
);

UPDATE [dbo].[ZhuangXiu] SET 
	[ZhuangXiu].[RoomID] = @RoomID,
	[ZhuangXiu].[ApplicationMan] = @ApplicationMan,
	[ZhuangXiu].[PhoneNumber] = @PhoneNumber,
	[ZhuangXiu].[DepositPrice] = @DepositPrice,
	[ZhuangXiu].[ZhuangXiuType] = @ZhuangXiuType,
	[ZhuangXiu].[TypeDesc] = @TypeDesc,
	[ZhuangXiu].[Status] = @Status,
	[ZhuangXiu].[AddTime] = @AddTime,
	[ZhuangXiu].[AddMan] = @AddMan,
	[ZhuangXiu].[ApproveID] = @ApproveID,
	[ZhuangXiu].[YanShouTime] = @YanShouTime,
	[ZhuangXiu].[YanShouMan] = @YanShouMan,
	[ZhuangXiu].[YanShouRemark] = @YanShouRemark,
	[ZhuangXiu].[ConfirmZXTime] = @ConfirmZXTime,
	[ZhuangXiu].[ChargeID] = @ChargeID,
	[ZhuangXiu].[RoomFeeID] = @RoomFeeID 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[ApplicationMan],
	INSERTED.[PhoneNumber],
	INSERTED.[DepositPrice],
	INSERTED.[ZhuangXiuType],
	INSERTED.[TypeDesc],
	INSERTED.[Status],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ApproveID],
	INSERTED.[YanShouTime],
	INSERTED.[YanShouMan],
	INSERTED.[YanShouRemark],
	INSERTED.[ConfirmZXTime],
	INSERTED.[ChargeID],
	INSERTED.[RoomFeeID]
into @table
WHERE 
	[ZhuangXiu].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[ApplicationMan],
	[PhoneNumber],
	[DepositPrice],
	[ZhuangXiuType],
	[TypeDesc],
	[Status],
	[AddTime],
	[AddMan],
	[ApproveID],
	[YanShouTime],
	[YanShouMan],
	[YanShouRemark],
	[ConfirmZXTime],
	[ChargeID],
	[RoomFeeID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@ApplicationMan", EntityBase.GetDatabaseValue(@applicationMan)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@DepositPrice", EntityBase.GetDatabaseValue(@depositPrice)));
			parameters.Add(new SqlParameter("@ZhuangXiuType", EntityBase.GetDatabaseValue(@zhuangXiuType)));
			parameters.Add(new SqlParameter("@TypeDesc", EntityBase.GetDatabaseValue(@typeDesc)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ApproveID", EntityBase.GetDatabaseValue(@approveID)));
			parameters.Add(new SqlParameter("@YanShouTime", EntityBase.GetDatabaseValue(@yanShouTime)));
			parameters.Add(new SqlParameter("@YanShouMan", EntityBase.GetDatabaseValue(@yanShouMan)));
			parameters.Add(new SqlParameter("@YanShouRemark", EntityBase.GetDatabaseValue(@yanShouRemark)));
			parameters.Add(new SqlParameter("@ConfirmZXTime", EntityBase.GetDatabaseValue(@confirmZXTime)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@RoomFeeID", EntityBase.GetDatabaseValue(@roomFeeID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ZhuangXiu from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteZhuangXiu(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteZhuangXiu(@iD, helper);
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
		/// Deletes a ZhuangXiu from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteZhuangXiu(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ZhuangXiu]
WHERE 
	[ZhuangXiu].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ZhuangXiu object.
		/// </summary>
		/// <returns>The newly created ZhuangXiu object.</returns>
		public static ZhuangXiu CreateZhuangXiu()
		{
			return InitializeNew<ZhuangXiu>();
		}
		
		/// <summary>
		/// Retrieve information for a ZhuangXiu by a ZhuangXiu's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ZhuangXiu</returns>
		public static ZhuangXiu GetZhuangXiu(int @iD)
		{
			string commandText = @"
SELECT 
" + ZhuangXiu.SelectFieldList + @"
FROM [dbo].[ZhuangXiu] 
WHERE 
	[ZhuangXiu].[ID] = @ID " + ZhuangXiu.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ZhuangXiu>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ZhuangXiu by a ZhuangXiu's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ZhuangXiu</returns>
		public static ZhuangXiu GetZhuangXiu(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ZhuangXiu.SelectFieldList + @"
FROM [dbo].[ZhuangXiu] 
WHERE 
	[ZhuangXiu].[ID] = @ID " + ZhuangXiu.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ZhuangXiu>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu objects.
		/// </summary>
		/// <returns>The retrieved collection of ZhuangXiu objects.</returns>
		public static EntityList<ZhuangXiu> GetZhuangXius()
		{
			string commandText = @"
SELECT " + ZhuangXiu.SelectFieldList + "FROM [dbo].[ZhuangXiu] " + ZhuangXiu.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ZhuangXiu>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ZhuangXiu objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ZhuangXiu objects.</returns>
        public static EntityList<ZhuangXiu> GetZhuangXius(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ZhuangXiu>(SelectFieldList, "FROM [dbo].[ZhuangXiu]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ZhuangXiu objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ZhuangXiu objects.</returns>
        public static EntityList<ZhuangXiu> GetZhuangXius(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ZhuangXiu>(SelectFieldList, "FROM [dbo].[ZhuangXiu]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ZhuangXiu objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ZhuangXiu objects.</returns>
		protected static EntityList<ZhuangXiu> GetZhuangXius(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetZhuangXius(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu objects.</returns>
		protected static EntityList<ZhuangXiu> GetZhuangXius(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetZhuangXius(string.Empty, where, parameters, ZhuangXiu.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu objects.</returns>
		protected static EntityList<ZhuangXiu> GetZhuangXius(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetZhuangXius(prefix, where, parameters, ZhuangXiu.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu objects.</returns>
		protected static EntityList<ZhuangXiu> GetZhuangXius(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetZhuangXius(string.Empty, where, parameters, ZhuangXiu.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu objects.</returns>
		protected static EntityList<ZhuangXiu> GetZhuangXius(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetZhuangXius(prefix, where, parameters, ZhuangXiu.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ZhuangXiu objects.</returns>
		protected static EntityList<ZhuangXiu> GetZhuangXius(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ZhuangXiu.SelectFieldList + "FROM [dbo].[ZhuangXiu] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ZhuangXiu>(reader);
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
        protected static EntityList<ZhuangXiu> GetZhuangXius(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ZhuangXiu>(SelectFieldList, "FROM [dbo].[ZhuangXiu] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ZhuangXiu objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetZhuangXiuCount()
        {
            return GetZhuangXiuCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ZhuangXiu objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetZhuangXiuCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ZhuangXiu] " + where;

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
		public static partial class ZhuangXiu_Properties
		{
			public const string ID = "ID";
			public const string RoomID = "RoomID";
			public const string ApplicationMan = "ApplicationMan";
			public const string PhoneNumber = "PhoneNumber";
			public const string DepositPrice = "DepositPrice";
			public const string ZhuangXiuType = "ZhuangXiuType";
			public const string TypeDesc = "TypeDesc";
			public const string Status = "Status";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string ApproveID = "ApproveID";
			public const string YanShouTime = "YanShouTime";
			public const string YanShouMan = "YanShouMan";
			public const string YanShouRemark = "YanShouRemark";
			public const string ConfirmZXTime = "ConfirmZXTime";
			public const string ChargeID = "ChargeID";
			public const string RoomFeeID = "RoomFeeID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"ApplicationMan" , "string:"},
    			 {"PhoneNumber" , "string:"},
    			 {"DepositPrice" , "decimal:"},
    			 {"ZhuangXiuType" , "string:"},
    			 {"TypeDesc" , "string:"},
    			 {"Status" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"ApproveID" , "int:"},
    			 {"YanShouTime" , "DateTime:"},
    			 {"YanShouMan" , "string:"},
    			 {"YanShouRemark" , "string:"},
    			 {"ConfirmZXTime" , "DateTime:"},
    			 {"ChargeID" , "int:"},
    			 {"RoomFeeID" , "int:"},
            };
		}
		#endregion
	}
}
