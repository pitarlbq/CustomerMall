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
	/// This object represents the properties and methods of a Mall_Business.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_Business 
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
		private string _businessName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string BusinessName
		{
			[DebuggerStepThrough()]
			get { return this._businessName; }
			set 
			{
				if (this._businessName != value) 
				{
					this._businessName = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _businessAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BusinessAddress
		{
			[DebuggerStepThrough()]
			get { return this._businessAddress; }
			set 
			{
				if (this._businessAddress != value) 
				{
					this._businessAddress = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessAddress");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contactName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContactName
		{
			[DebuggerStepThrough()]
			get { return this._contactName; }
			set 
			{
				if (this._contactName != value) 
				{
					this._contactName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContactName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contactPhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContactPhone
		{
			[DebuggerStepThrough()]
			get { return this._contactPhone; }
			set 
			{
				if (this._contactPhone != value) 
				{
					this._contactPhone = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContactPhone");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _licenseNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string LicenseNumber
		{
			[DebuggerStepThrough()]
			get { return this._licenseNumber; }
			set 
			{
				if (this._licenseNumber != value) 
				{
					this._licenseNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("LicenseNumber");
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
		private int _status = int.MinValue;
		/// <summary>
		/// 10-待审核 1-审核通过 2-审核未通过
		/// </summary>
        [Description("10-待审核 1-审核通过 2-审核未通过")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int Status
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
		private bool _isShowOnHome = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsShowOnHome
		{
			[DebuggerStepThrough()]
			get { return this._isShowOnHome; }
			set 
			{
				if (this._isShowOnHome != value) 
				{
					this._isShowOnHome = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsShowOnHome");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _coverImage = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CoverImage
		{
			[DebuggerStepThrough()]
			get { return this._coverImage; }
			set 
			{
				if (this._coverImage != value) 
				{
					this._coverImage = value;
					this.IsDirty = true;	
					OnPropertyChanged("CoverImage");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isSuggestion = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsSuggestion
		{
			[DebuggerStepThrough()]
			get { return this._isSuggestion; }
			set 
			{
				if (this._isSuggestion != value) 
				{
					this._isSuggestion = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsSuggestion");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _mapLocation = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string MapLocation
		{
			[DebuggerStepThrough()]
			get { return this._mapLocation; }
			set 
			{
				if (this._mapLocation != value) 
				{
					this._mapLocation = value;
					this.IsDirty = true;	
					OnPropertyChanged("MapLocation");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _userID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int UserID
		{
			[DebuggerStepThrough()]
			get { return this._userID; }
			set 
			{
				if (this._userID != value) 
				{
					this._userID = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _deviceID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DeviceID
		{
			[DebuggerStepThrough()]
			get { return this._deviceID; }
			set 
			{
				if (this._deviceID != value) 
				{
					this._deviceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeviceID");
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
		private int _sortOrder = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SortOrder
		{
			[DebuggerStepThrough()]
			get { return this._sortOrder; }
			set 
			{
				if (this._sortOrder != value) 
				{
					this._sortOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("SortOrder");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _shortAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ShortAddress
		{
			[DebuggerStepThrough()]
			get { return this._shortAddress; }
			set 
			{
				if (this._shortAddress != value) 
				{
					this._shortAddress = value;
					this.IsDirty = true;	
					OnPropertyChanged("ShortAddress");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isTopShow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsTopShow
		{
			[DebuggerStepThrough()]
			get { return this._isTopShow; }
			set 
			{
				if (this._isTopShow != value) 
				{
					this._isTopShow = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsTopShow");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _balanceAccount = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BalanceAccount
		{
			[DebuggerStepThrough()]
			get { return this._balanceAccount; }
			set 
			{
				if (this._balanceAccount != value) 
				{
					this._balanceAccount = value;
					this.IsDirty = true;	
					OnPropertyChanged("BalanceAccount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _businessDesc = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BusinessDesc
		{
			[DebuggerStepThrough()]
			get { return this._businessDesc; }
			set 
			{
				if (this._businessDesc != value) 
				{
					this._businessDesc = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessDesc");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isWaiMai = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsWaiMai
		{
			[DebuggerStepThrough()]
			get { return this._isWaiMai; }
			set 
			{
				if (this._isWaiMai != value) 
				{
					this._isWaiMai = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsWaiMai");
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
	[BusinessName] nvarchar(200),
	[BusinessAddress] nvarchar(500),
	[ContactName] nvarchar(200),
	[ContactPhone] nvarchar(100),
	[LicenseNumber] nvarchar(200),
	[AddMan] nvarchar(100),
	[AddTime] datetime,
	[Status] int,
	[ApproveRemark] ntext,
	[ApproveTime] datetime,
	[ApproveMan] nvarchar(100),
	[IsShowOnHome] bit,
	[CoverImage] nvarchar(500),
	[IsSuggestion] bit,
	[MapLocation] nvarchar(500),
	[UserID] int,
	[DeviceID] nvarchar(500),
	[Remark] ntext,
	[SortOrder] int,
	[ShortAddress] nvarchar(200),
	[IsTopShow] bit,
	[BalanceAccount] nvarchar(100),
	[BusinessDesc] ntext,
	[IsWaiMai] bit
);

INSERT INTO [dbo].[Mall_Business] (
	[Mall_Business].[BusinessName],
	[Mall_Business].[BusinessAddress],
	[Mall_Business].[ContactName],
	[Mall_Business].[ContactPhone],
	[Mall_Business].[LicenseNumber],
	[Mall_Business].[AddMan],
	[Mall_Business].[AddTime],
	[Mall_Business].[Status],
	[Mall_Business].[ApproveRemark],
	[Mall_Business].[ApproveTime],
	[Mall_Business].[ApproveMan],
	[Mall_Business].[IsShowOnHome],
	[Mall_Business].[CoverImage],
	[Mall_Business].[IsSuggestion],
	[Mall_Business].[MapLocation],
	[Mall_Business].[UserID],
	[Mall_Business].[DeviceID],
	[Mall_Business].[Remark],
	[Mall_Business].[SortOrder],
	[Mall_Business].[ShortAddress],
	[Mall_Business].[IsTopShow],
	[Mall_Business].[BalanceAccount],
	[Mall_Business].[BusinessDesc],
	[Mall_Business].[IsWaiMai]
) 
output 
	INSERTED.[ID],
	INSERTED.[BusinessName],
	INSERTED.[BusinessAddress],
	INSERTED.[ContactName],
	INSERTED.[ContactPhone],
	INSERTED.[LicenseNumber],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[Status],
	INSERTED.[ApproveRemark],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveMan],
	INSERTED.[IsShowOnHome],
	INSERTED.[CoverImage],
	INSERTED.[IsSuggestion],
	INSERTED.[MapLocation],
	INSERTED.[UserID],
	INSERTED.[DeviceID],
	INSERTED.[Remark],
	INSERTED.[SortOrder],
	INSERTED.[ShortAddress],
	INSERTED.[IsTopShow],
	INSERTED.[BalanceAccount],
	INSERTED.[BusinessDesc],
	INSERTED.[IsWaiMai]
into @table
VALUES ( 
	@BusinessName,
	@BusinessAddress,
	@ContactName,
	@ContactPhone,
	@LicenseNumber,
	@AddMan,
	@AddTime,
	@Status,
	@ApproveRemark,
	@ApproveTime,
	@ApproveMan,
	@IsShowOnHome,
	@CoverImage,
	@IsSuggestion,
	@MapLocation,
	@UserID,
	@DeviceID,
	@Remark,
	@SortOrder,
	@ShortAddress,
	@IsTopShow,
	@BalanceAccount,
	@BusinessDesc,
	@IsWaiMai 
); 

SELECT 
	[ID],
	[BusinessName],
	[BusinessAddress],
	[ContactName],
	[ContactPhone],
	[LicenseNumber],
	[AddMan],
	[AddTime],
	[Status],
	[ApproveRemark],
	[ApproveTime],
	[ApproveMan],
	[IsShowOnHome],
	[CoverImage],
	[IsSuggestion],
	[MapLocation],
	[UserID],
	[DeviceID],
	[Remark],
	[SortOrder],
	[ShortAddress],
	[IsTopShow],
	[BalanceAccount],
	[BusinessDesc],
	[IsWaiMai] 
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
	[BusinessName] nvarchar(200),
	[BusinessAddress] nvarchar(500),
	[ContactName] nvarchar(200),
	[ContactPhone] nvarchar(100),
	[LicenseNumber] nvarchar(200),
	[AddMan] nvarchar(100),
	[AddTime] datetime,
	[Status] int,
	[ApproveRemark] ntext,
	[ApproveTime] datetime,
	[ApproveMan] nvarchar(100),
	[IsShowOnHome] bit,
	[CoverImage] nvarchar(500),
	[IsSuggestion] bit,
	[MapLocation] nvarchar(500),
	[UserID] int,
	[DeviceID] nvarchar(500),
	[Remark] ntext,
	[SortOrder] int,
	[ShortAddress] nvarchar(200),
	[IsTopShow] bit,
	[BalanceAccount] nvarchar(100),
	[BusinessDesc] ntext,
	[IsWaiMai] bit
);

UPDATE [dbo].[Mall_Business] SET 
	[Mall_Business].[BusinessName] = @BusinessName,
	[Mall_Business].[BusinessAddress] = @BusinessAddress,
	[Mall_Business].[ContactName] = @ContactName,
	[Mall_Business].[ContactPhone] = @ContactPhone,
	[Mall_Business].[LicenseNumber] = @LicenseNumber,
	[Mall_Business].[AddMan] = @AddMan,
	[Mall_Business].[AddTime] = @AddTime,
	[Mall_Business].[Status] = @Status,
	[Mall_Business].[ApproveRemark] = @ApproveRemark,
	[Mall_Business].[ApproveTime] = @ApproveTime,
	[Mall_Business].[ApproveMan] = @ApproveMan,
	[Mall_Business].[IsShowOnHome] = @IsShowOnHome,
	[Mall_Business].[CoverImage] = @CoverImage,
	[Mall_Business].[IsSuggestion] = @IsSuggestion,
	[Mall_Business].[MapLocation] = @MapLocation,
	[Mall_Business].[UserID] = @UserID,
	[Mall_Business].[DeviceID] = @DeviceID,
	[Mall_Business].[Remark] = @Remark,
	[Mall_Business].[SortOrder] = @SortOrder,
	[Mall_Business].[ShortAddress] = @ShortAddress,
	[Mall_Business].[IsTopShow] = @IsTopShow,
	[Mall_Business].[BalanceAccount] = @BalanceAccount,
	[Mall_Business].[BusinessDesc] = @BusinessDesc,
	[Mall_Business].[IsWaiMai] = @IsWaiMai 
output 
	INSERTED.[ID],
	INSERTED.[BusinessName],
	INSERTED.[BusinessAddress],
	INSERTED.[ContactName],
	INSERTED.[ContactPhone],
	INSERTED.[LicenseNumber],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[Status],
	INSERTED.[ApproveRemark],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveMan],
	INSERTED.[IsShowOnHome],
	INSERTED.[CoverImage],
	INSERTED.[IsSuggestion],
	INSERTED.[MapLocation],
	INSERTED.[UserID],
	INSERTED.[DeviceID],
	INSERTED.[Remark],
	INSERTED.[SortOrder],
	INSERTED.[ShortAddress],
	INSERTED.[IsTopShow],
	INSERTED.[BalanceAccount],
	INSERTED.[BusinessDesc],
	INSERTED.[IsWaiMai]
into @table
WHERE 
	[Mall_Business].[ID] = @ID

SELECT 
	[ID],
	[BusinessName],
	[BusinessAddress],
	[ContactName],
	[ContactPhone],
	[LicenseNumber],
	[AddMan],
	[AddTime],
	[Status],
	[ApproveRemark],
	[ApproveTime],
	[ApproveMan],
	[IsShowOnHome],
	[CoverImage],
	[IsSuggestion],
	[MapLocation],
	[UserID],
	[DeviceID],
	[Remark],
	[SortOrder],
	[ShortAddress],
	[IsTopShow],
	[BalanceAccount],
	[BusinessDesc],
	[IsWaiMai] 
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
DELETE FROM [dbo].[Mall_Business]
WHERE 
	[Mall_Business].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_Business() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_Business(this.ID));
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
	[Mall_Business].[ID],
	[Mall_Business].[BusinessName],
	[Mall_Business].[BusinessAddress],
	[Mall_Business].[ContactName],
	[Mall_Business].[ContactPhone],
	[Mall_Business].[LicenseNumber],
	[Mall_Business].[AddMan],
	[Mall_Business].[AddTime],
	[Mall_Business].[Status],
	[Mall_Business].[ApproveRemark],
	[Mall_Business].[ApproveTime],
	[Mall_Business].[ApproveMan],
	[Mall_Business].[IsShowOnHome],
	[Mall_Business].[CoverImage],
	[Mall_Business].[IsSuggestion],
	[Mall_Business].[MapLocation],
	[Mall_Business].[UserID],
	[Mall_Business].[DeviceID],
	[Mall_Business].[Remark],
	[Mall_Business].[SortOrder],
	[Mall_Business].[ShortAddress],
	[Mall_Business].[IsTopShow],
	[Mall_Business].[BalanceAccount],
	[Mall_Business].[BusinessDesc],
	[Mall_Business].[IsWaiMai]
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
                return "Mall_Business";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_Business into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="businessName">businessName</param>
		/// <param name="businessAddress">businessAddress</param>
		/// <param name="contactName">contactName</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="licenseNumber">licenseNumber</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="status">status</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="isShowOnHome">isShowOnHome</param>
		/// <param name="coverImage">coverImage</param>
		/// <param name="isSuggestion">isSuggestion</param>
		/// <param name="mapLocation">mapLocation</param>
		/// <param name="userID">userID</param>
		/// <param name="deviceID">deviceID</param>
		/// <param name="remark">remark</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="shortAddress">shortAddress</param>
		/// <param name="isTopShow">isTopShow</param>
		/// <param name="balanceAccount">balanceAccount</param>
		/// <param name="businessDesc">businessDesc</param>
		/// <param name="isWaiMai">isWaiMai</param>
		public static void InsertMall_Business(string @businessName, string @businessAddress, string @contactName, string @contactPhone, string @licenseNumber, string @addMan, DateTime @addTime, int @status, string @approveRemark, DateTime @approveTime, string @approveMan, bool @isShowOnHome, string @coverImage, bool @isSuggestion, string @mapLocation, int @userID, string @deviceID, string @remark, int @sortOrder, string @shortAddress, bool @isTopShow, string @balanceAccount, string @businessDesc, bool @isWaiMai)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_Business(@businessName, @businessAddress, @contactName, @contactPhone, @licenseNumber, @addMan, @addTime, @status, @approveRemark, @approveTime, @approveMan, @isShowOnHome, @coverImage, @isSuggestion, @mapLocation, @userID, @deviceID, @remark, @sortOrder, @shortAddress, @isTopShow, @balanceAccount, @businessDesc, @isWaiMai, helper);
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
		/// Insert a Mall_Business into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="businessName">businessName</param>
		/// <param name="businessAddress">businessAddress</param>
		/// <param name="contactName">contactName</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="licenseNumber">licenseNumber</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="status">status</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="isShowOnHome">isShowOnHome</param>
		/// <param name="coverImage">coverImage</param>
		/// <param name="isSuggestion">isSuggestion</param>
		/// <param name="mapLocation">mapLocation</param>
		/// <param name="userID">userID</param>
		/// <param name="deviceID">deviceID</param>
		/// <param name="remark">remark</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="shortAddress">shortAddress</param>
		/// <param name="isTopShow">isTopShow</param>
		/// <param name="balanceAccount">balanceAccount</param>
		/// <param name="businessDesc">businessDesc</param>
		/// <param name="isWaiMai">isWaiMai</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_Business(string @businessName, string @businessAddress, string @contactName, string @contactPhone, string @licenseNumber, string @addMan, DateTime @addTime, int @status, string @approveRemark, DateTime @approveTime, string @approveMan, bool @isShowOnHome, string @coverImage, bool @isSuggestion, string @mapLocation, int @userID, string @deviceID, string @remark, int @sortOrder, string @shortAddress, bool @isTopShow, string @balanceAccount, string @businessDesc, bool @isWaiMai, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BusinessName] nvarchar(200),
	[BusinessAddress] nvarchar(500),
	[ContactName] nvarchar(200),
	[ContactPhone] nvarchar(100),
	[LicenseNumber] nvarchar(200),
	[AddMan] nvarchar(100),
	[AddTime] datetime,
	[Status] int,
	[ApproveRemark] ntext,
	[ApproveTime] datetime,
	[ApproveMan] nvarchar(100),
	[IsShowOnHome] bit,
	[CoverImage] nvarchar(500),
	[IsSuggestion] bit,
	[MapLocation] nvarchar(500),
	[UserID] int,
	[DeviceID] nvarchar(500),
	[Remark] ntext,
	[SortOrder] int,
	[ShortAddress] nvarchar(200),
	[IsTopShow] bit,
	[BalanceAccount] nvarchar(100),
	[BusinessDesc] ntext,
	[IsWaiMai] bit
);

INSERT INTO [dbo].[Mall_Business] (
	[Mall_Business].[BusinessName],
	[Mall_Business].[BusinessAddress],
	[Mall_Business].[ContactName],
	[Mall_Business].[ContactPhone],
	[Mall_Business].[LicenseNumber],
	[Mall_Business].[AddMan],
	[Mall_Business].[AddTime],
	[Mall_Business].[Status],
	[Mall_Business].[ApproveRemark],
	[Mall_Business].[ApproveTime],
	[Mall_Business].[ApproveMan],
	[Mall_Business].[IsShowOnHome],
	[Mall_Business].[CoverImage],
	[Mall_Business].[IsSuggestion],
	[Mall_Business].[MapLocation],
	[Mall_Business].[UserID],
	[Mall_Business].[DeviceID],
	[Mall_Business].[Remark],
	[Mall_Business].[SortOrder],
	[Mall_Business].[ShortAddress],
	[Mall_Business].[IsTopShow],
	[Mall_Business].[BalanceAccount],
	[Mall_Business].[BusinessDesc],
	[Mall_Business].[IsWaiMai]
) 
output 
	INSERTED.[ID],
	INSERTED.[BusinessName],
	INSERTED.[BusinessAddress],
	INSERTED.[ContactName],
	INSERTED.[ContactPhone],
	INSERTED.[LicenseNumber],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[Status],
	INSERTED.[ApproveRemark],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveMan],
	INSERTED.[IsShowOnHome],
	INSERTED.[CoverImage],
	INSERTED.[IsSuggestion],
	INSERTED.[MapLocation],
	INSERTED.[UserID],
	INSERTED.[DeviceID],
	INSERTED.[Remark],
	INSERTED.[SortOrder],
	INSERTED.[ShortAddress],
	INSERTED.[IsTopShow],
	INSERTED.[BalanceAccount],
	INSERTED.[BusinessDesc],
	INSERTED.[IsWaiMai]
into @table
VALUES ( 
	@BusinessName,
	@BusinessAddress,
	@ContactName,
	@ContactPhone,
	@LicenseNumber,
	@AddMan,
	@AddTime,
	@Status,
	@ApproveRemark,
	@ApproveTime,
	@ApproveMan,
	@IsShowOnHome,
	@CoverImage,
	@IsSuggestion,
	@MapLocation,
	@UserID,
	@DeviceID,
	@Remark,
	@SortOrder,
	@ShortAddress,
	@IsTopShow,
	@BalanceAccount,
	@BusinessDesc,
	@IsWaiMai 
); 

SELECT 
	[ID],
	[BusinessName],
	[BusinessAddress],
	[ContactName],
	[ContactPhone],
	[LicenseNumber],
	[AddMan],
	[AddTime],
	[Status],
	[ApproveRemark],
	[ApproveTime],
	[ApproveMan],
	[IsShowOnHome],
	[CoverImage],
	[IsSuggestion],
	[MapLocation],
	[UserID],
	[DeviceID],
	[Remark],
	[SortOrder],
	[ShortAddress],
	[IsTopShow],
	[BalanceAccount],
	[BusinessDesc],
	[IsWaiMai] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@BusinessName", EntityBase.GetDatabaseValue(@businessName)));
			parameters.Add(new SqlParameter("@BusinessAddress", EntityBase.GetDatabaseValue(@businessAddress)));
			parameters.Add(new SqlParameter("@ContactName", EntityBase.GetDatabaseValue(@contactName)));
			parameters.Add(new SqlParameter("@ContactPhone", EntityBase.GetDatabaseValue(@contactPhone)));
			parameters.Add(new SqlParameter("@LicenseNumber", EntityBase.GetDatabaseValue(@licenseNumber)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveMan", EntityBase.GetDatabaseValue(@approveMan)));
			parameters.Add(new SqlParameter("@IsShowOnHome", @isShowOnHome));
			parameters.Add(new SqlParameter("@CoverImage", EntityBase.GetDatabaseValue(@coverImage)));
			parameters.Add(new SqlParameter("@IsSuggestion", @isSuggestion));
			parameters.Add(new SqlParameter("@MapLocation", EntityBase.GetDatabaseValue(@mapLocation)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@DeviceID", EntityBase.GetDatabaseValue(@deviceID)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@ShortAddress", EntityBase.GetDatabaseValue(@shortAddress)));
			parameters.Add(new SqlParameter("@IsTopShow", @isTopShow));
			parameters.Add(new SqlParameter("@BalanceAccount", EntityBase.GetDatabaseValue(@balanceAccount)));
			parameters.Add(new SqlParameter("@BusinessDesc", EntityBase.GetDatabaseValue(@businessDesc)));
			parameters.Add(new SqlParameter("@IsWaiMai", @isWaiMai));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_Business into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="businessName">businessName</param>
		/// <param name="businessAddress">businessAddress</param>
		/// <param name="contactName">contactName</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="licenseNumber">licenseNumber</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="status">status</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="isShowOnHome">isShowOnHome</param>
		/// <param name="coverImage">coverImage</param>
		/// <param name="isSuggestion">isSuggestion</param>
		/// <param name="mapLocation">mapLocation</param>
		/// <param name="userID">userID</param>
		/// <param name="deviceID">deviceID</param>
		/// <param name="remark">remark</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="shortAddress">shortAddress</param>
		/// <param name="isTopShow">isTopShow</param>
		/// <param name="balanceAccount">balanceAccount</param>
		/// <param name="businessDesc">businessDesc</param>
		/// <param name="isWaiMai">isWaiMai</param>
		public static void UpdateMall_Business(int @iD, string @businessName, string @businessAddress, string @contactName, string @contactPhone, string @licenseNumber, string @addMan, DateTime @addTime, int @status, string @approveRemark, DateTime @approveTime, string @approveMan, bool @isShowOnHome, string @coverImage, bool @isSuggestion, string @mapLocation, int @userID, string @deviceID, string @remark, int @sortOrder, string @shortAddress, bool @isTopShow, string @balanceAccount, string @businessDesc, bool @isWaiMai)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_Business(@iD, @businessName, @businessAddress, @contactName, @contactPhone, @licenseNumber, @addMan, @addTime, @status, @approveRemark, @approveTime, @approveMan, @isShowOnHome, @coverImage, @isSuggestion, @mapLocation, @userID, @deviceID, @remark, @sortOrder, @shortAddress, @isTopShow, @balanceAccount, @businessDesc, @isWaiMai, helper);
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
		/// Updates a Mall_Business into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="businessName">businessName</param>
		/// <param name="businessAddress">businessAddress</param>
		/// <param name="contactName">contactName</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="licenseNumber">licenseNumber</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="status">status</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="isShowOnHome">isShowOnHome</param>
		/// <param name="coverImage">coverImage</param>
		/// <param name="isSuggestion">isSuggestion</param>
		/// <param name="mapLocation">mapLocation</param>
		/// <param name="userID">userID</param>
		/// <param name="deviceID">deviceID</param>
		/// <param name="remark">remark</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="shortAddress">shortAddress</param>
		/// <param name="isTopShow">isTopShow</param>
		/// <param name="balanceAccount">balanceAccount</param>
		/// <param name="businessDesc">businessDesc</param>
		/// <param name="isWaiMai">isWaiMai</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_Business(int @iD, string @businessName, string @businessAddress, string @contactName, string @contactPhone, string @licenseNumber, string @addMan, DateTime @addTime, int @status, string @approveRemark, DateTime @approveTime, string @approveMan, bool @isShowOnHome, string @coverImage, bool @isSuggestion, string @mapLocation, int @userID, string @deviceID, string @remark, int @sortOrder, string @shortAddress, bool @isTopShow, string @balanceAccount, string @businessDesc, bool @isWaiMai, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BusinessName] nvarchar(200),
	[BusinessAddress] nvarchar(500),
	[ContactName] nvarchar(200),
	[ContactPhone] nvarchar(100),
	[LicenseNumber] nvarchar(200),
	[AddMan] nvarchar(100),
	[AddTime] datetime,
	[Status] int,
	[ApproveRemark] ntext,
	[ApproveTime] datetime,
	[ApproveMan] nvarchar(100),
	[IsShowOnHome] bit,
	[CoverImage] nvarchar(500),
	[IsSuggestion] bit,
	[MapLocation] nvarchar(500),
	[UserID] int,
	[DeviceID] nvarchar(500),
	[Remark] ntext,
	[SortOrder] int,
	[ShortAddress] nvarchar(200),
	[IsTopShow] bit,
	[BalanceAccount] nvarchar(100),
	[BusinessDesc] ntext,
	[IsWaiMai] bit
);

UPDATE [dbo].[Mall_Business] SET 
	[Mall_Business].[BusinessName] = @BusinessName,
	[Mall_Business].[BusinessAddress] = @BusinessAddress,
	[Mall_Business].[ContactName] = @ContactName,
	[Mall_Business].[ContactPhone] = @ContactPhone,
	[Mall_Business].[LicenseNumber] = @LicenseNumber,
	[Mall_Business].[AddMan] = @AddMan,
	[Mall_Business].[AddTime] = @AddTime,
	[Mall_Business].[Status] = @Status,
	[Mall_Business].[ApproveRemark] = @ApproveRemark,
	[Mall_Business].[ApproveTime] = @ApproveTime,
	[Mall_Business].[ApproveMan] = @ApproveMan,
	[Mall_Business].[IsShowOnHome] = @IsShowOnHome,
	[Mall_Business].[CoverImage] = @CoverImage,
	[Mall_Business].[IsSuggestion] = @IsSuggestion,
	[Mall_Business].[MapLocation] = @MapLocation,
	[Mall_Business].[UserID] = @UserID,
	[Mall_Business].[DeviceID] = @DeviceID,
	[Mall_Business].[Remark] = @Remark,
	[Mall_Business].[SortOrder] = @SortOrder,
	[Mall_Business].[ShortAddress] = @ShortAddress,
	[Mall_Business].[IsTopShow] = @IsTopShow,
	[Mall_Business].[BalanceAccount] = @BalanceAccount,
	[Mall_Business].[BusinessDesc] = @BusinessDesc,
	[Mall_Business].[IsWaiMai] = @IsWaiMai 
output 
	INSERTED.[ID],
	INSERTED.[BusinessName],
	INSERTED.[BusinessAddress],
	INSERTED.[ContactName],
	INSERTED.[ContactPhone],
	INSERTED.[LicenseNumber],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[Status],
	INSERTED.[ApproveRemark],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveMan],
	INSERTED.[IsShowOnHome],
	INSERTED.[CoverImage],
	INSERTED.[IsSuggestion],
	INSERTED.[MapLocation],
	INSERTED.[UserID],
	INSERTED.[DeviceID],
	INSERTED.[Remark],
	INSERTED.[SortOrder],
	INSERTED.[ShortAddress],
	INSERTED.[IsTopShow],
	INSERTED.[BalanceAccount],
	INSERTED.[BusinessDesc],
	INSERTED.[IsWaiMai]
into @table
WHERE 
	[Mall_Business].[ID] = @ID

SELECT 
	[ID],
	[BusinessName],
	[BusinessAddress],
	[ContactName],
	[ContactPhone],
	[LicenseNumber],
	[AddMan],
	[AddTime],
	[Status],
	[ApproveRemark],
	[ApproveTime],
	[ApproveMan],
	[IsShowOnHome],
	[CoverImage],
	[IsSuggestion],
	[MapLocation],
	[UserID],
	[DeviceID],
	[Remark],
	[SortOrder],
	[ShortAddress],
	[IsTopShow],
	[BalanceAccount],
	[BusinessDesc],
	[IsWaiMai] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@BusinessName", EntityBase.GetDatabaseValue(@businessName)));
			parameters.Add(new SqlParameter("@BusinessAddress", EntityBase.GetDatabaseValue(@businessAddress)));
			parameters.Add(new SqlParameter("@ContactName", EntityBase.GetDatabaseValue(@contactName)));
			parameters.Add(new SqlParameter("@ContactPhone", EntityBase.GetDatabaseValue(@contactPhone)));
			parameters.Add(new SqlParameter("@LicenseNumber", EntityBase.GetDatabaseValue(@licenseNumber)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveMan", EntityBase.GetDatabaseValue(@approveMan)));
			parameters.Add(new SqlParameter("@IsShowOnHome", @isShowOnHome));
			parameters.Add(new SqlParameter("@CoverImage", EntityBase.GetDatabaseValue(@coverImage)));
			parameters.Add(new SqlParameter("@IsSuggestion", @isSuggestion));
			parameters.Add(new SqlParameter("@MapLocation", EntityBase.GetDatabaseValue(@mapLocation)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@DeviceID", EntityBase.GetDatabaseValue(@deviceID)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@ShortAddress", EntityBase.GetDatabaseValue(@shortAddress)));
			parameters.Add(new SqlParameter("@IsTopShow", @isTopShow));
			parameters.Add(new SqlParameter("@BalanceAccount", EntityBase.GetDatabaseValue(@balanceAccount)));
			parameters.Add(new SqlParameter("@BusinessDesc", EntityBase.GetDatabaseValue(@businessDesc)));
			parameters.Add(new SqlParameter("@IsWaiMai", @isWaiMai));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_Business from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_Business(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_Business(@iD, helper);
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
		/// Deletes a Mall_Business from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_Business(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_Business]
WHERE 
	[Mall_Business].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_Business object.
		/// </summary>
		/// <returns>The newly created Mall_Business object.</returns>
		public static Mall_Business CreateMall_Business()
		{
			return InitializeNew<Mall_Business>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_Business by a Mall_Business's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_Business</returns>
		public static Mall_Business GetMall_Business(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_Business.SelectFieldList + @"
FROM [dbo].[Mall_Business] 
WHERE 
	[Mall_Business].[ID] = @ID " + Mall_Business.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Business>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_Business by a Mall_Business's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_Business</returns>
		public static Mall_Business GetMall_Business(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_Business.SelectFieldList + @"
FROM [dbo].[Mall_Business] 
WHERE 
	[Mall_Business].[ID] = @ID " + Mall_Business.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Business>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_Business objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_Business objects.</returns>
		public static EntityList<Mall_Business> GetMall_Businesses()
		{
			string commandText = @"
SELECT " + Mall_Business.SelectFieldList + "FROM [dbo].[Mall_Business] " + Mall_Business.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_Business>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_Business objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Business objects.</returns>
        public static EntityList<Mall_Business> GetMall_Businesses(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Business>(SelectFieldList, "FROM [dbo].[Mall_Business]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_Business objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Business objects.</returns>
        public static EntityList<Mall_Business> GetMall_Businesses(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Business>(SelectFieldList, "FROM [dbo].[Mall_Business]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_Business objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Business objects.</returns>
		protected static EntityList<Mall_Business> GetMall_Businesses(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Businesses(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_Business objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Business objects.</returns>
		protected static EntityList<Mall_Business> GetMall_Businesses(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Businesses(string.Empty, where, parameters, Mall_Business.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Business objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Business objects.</returns>
		protected static EntityList<Mall_Business> GetMall_Businesses(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Businesses(prefix, where, parameters, Mall_Business.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Business objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Business objects.</returns>
		protected static EntityList<Mall_Business> GetMall_Businesses(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Businesses(string.Empty, where, parameters, Mall_Business.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Business objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Business objects.</returns>
		protected static EntityList<Mall_Business> GetMall_Businesses(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Businesses(prefix, where, parameters, Mall_Business.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Business objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Business objects.</returns>
		protected static EntityList<Mall_Business> GetMall_Businesses(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_Business.SelectFieldList + "FROM [dbo].[Mall_Business] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_Business>(reader);
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
        protected static EntityList<Mall_Business> GetMall_Businesses(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Business>(SelectFieldList, "FROM [dbo].[Mall_Business] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_Business objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_BusinessCount()
        {
            return GetMall_BusinessCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_Business objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_BusinessCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_Business] " + where;

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
		public static partial class Mall_Business_Properties
		{
			public const string ID = "ID";
			public const string BusinessName = "BusinessName";
			public const string BusinessAddress = "BusinessAddress";
			public const string ContactName = "ContactName";
			public const string ContactPhone = "ContactPhone";
			public const string LicenseNumber = "LicenseNumber";
			public const string AddMan = "AddMan";
			public const string AddTime = "AddTime";
			public const string Status = "Status";
			public const string ApproveRemark = "ApproveRemark";
			public const string ApproveTime = "ApproveTime";
			public const string ApproveMan = "ApproveMan";
			public const string IsShowOnHome = "IsShowOnHome";
			public const string CoverImage = "CoverImage";
			public const string IsSuggestion = "IsSuggestion";
			public const string MapLocation = "MapLocation";
			public const string UserID = "UserID";
			public const string DeviceID = "DeviceID";
			public const string Remark = "Remark";
			public const string SortOrder = "SortOrder";
			public const string ShortAddress = "ShortAddress";
			public const string IsTopShow = "IsTopShow";
			public const string BalanceAccount = "BalanceAccount";
			public const string BusinessDesc = "BusinessDesc";
			public const string IsWaiMai = "IsWaiMai";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"BusinessName" , "string:"},
    			 {"BusinessAddress" , "string:"},
    			 {"ContactName" , "string:"},
    			 {"ContactPhone" , "string:"},
    			 {"LicenseNumber" , "string:"},
    			 {"AddMan" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"Status" , "int:10-待审核 1-审核通过 2-审核未通过"},
    			 {"ApproveRemark" , "string:"},
    			 {"ApproveTime" , "DateTime:"},
    			 {"ApproveMan" , "string:"},
    			 {"IsShowOnHome" , "bool:"},
    			 {"CoverImage" , "string:"},
    			 {"IsSuggestion" , "bool:"},
    			 {"MapLocation" , "string:"},
    			 {"UserID" , "int:"},
    			 {"DeviceID" , "string:"},
    			 {"Remark" , "string:"},
    			 {"SortOrder" , "int:"},
    			 {"ShortAddress" , "string:"},
    			 {"IsTopShow" , "bool:"},
    			 {"BalanceAccount" , "string:"},
    			 {"BusinessDesc" , "string:"},
    			 {"IsWaiMai" , "bool:"},
            };
		}
		#endregion
	}
}
