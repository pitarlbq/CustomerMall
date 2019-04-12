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
	/// This object represents the properties and methods of a Mall_Address.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_Address 
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
		private string _addressProvice = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddressProvice
		{
			[DebuggerStepThrough()]
			get { return this._addressProvice; }
			set 
			{
				if (this._addressProvice != value) 
				{
					this._addressProvice = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressProvice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addressCity = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddressCity
		{
			[DebuggerStepThrough()]
			get { return this._addressCity; }
			set 
			{
				if (this._addressCity != value) 
				{
					this._addressCity = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressCity");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addressDistrict = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddressDistrict
		{
			[DebuggerStepThrough()]
			get { return this._addressDistrict; }
			set 
			{
				if (this._addressDistrict != value) 
				{
					this._addressDistrict = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressDistrict");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addressDetailInfo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddressDetailInfo
		{
			[DebuggerStepThrough()]
			get { return this._addressDetailInfo; }
			set 
			{
				if (this._addressDetailInfo != value) 
				{
					this._addressDetailInfo = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressDetailInfo");
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
		private string _addUser = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string AddUser
		{
			[DebuggerStepThrough()]
			get { return this._addUser; }
			set 
			{
				if (this._addUser != value) 
				{
					this._addUser = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUser");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addressPhoneNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddressPhoneNo
		{
			[DebuggerStepThrough()]
			get { return this._addressPhoneNo; }
			set 
			{
				if (this._addressPhoneNo != value) 
				{
					this._addressPhoneNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressPhoneNo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addressUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddressUserName
		{
			[DebuggerStepThrough()]
			get { return this._addressUserName; }
			set 
			{
				if (this._addressUserName != value) 
				{
					this._addressUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressUserName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDefault = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDefault
		{
			[DebuggerStepThrough()]
			get { return this._isDefault; }
			set 
			{
				if (this._isDefault != value) 
				{
					this._isDefault = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDefault");
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
		[DataObjectField(false, false, false)]
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
		private int _projectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProjectID
		{
			[DebuggerStepThrough()]
			get { return this._projectID; }
			set 
			{
				if (this._projectID != value) 
				{
					this._projectID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectID");
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
		[DataObjectField(false, false, true)]
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
		private string _projectFullName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProjectFullName
		{
			[DebuggerStepThrough()]
			get { return this._projectFullName; }
			set 
			{
				if (this._projectFullName != value) 
				{
					this._projectFullName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectFullName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomName
		{
			[DebuggerStepThrough()]
			get { return this._roomName; }
			set 
			{
				if (this._roomName != value) 
				{
					this._roomName = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _projectName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProjectName
		{
			[DebuggerStepThrough()]
			get { return this._projectName; }
			set 
			{
				if (this._projectName != value) 
				{
					this._projectName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _addressProvinceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int AddressProvinceID
		{
			[DebuggerStepThrough()]
			get { return this._addressProvinceID; }
			set 
			{
				if (this._addressProvinceID != value) 
				{
					this._addressProvinceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressProvinceID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _roomPhoneRelationID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RoomPhoneRelationID
		{
			[DebuggerStepThrough()]
			get { return this._roomPhoneRelationID; }
			set 
			{
				if (this._roomPhoneRelationID != value) 
				{
					this._roomPhoneRelationID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomPhoneRelationID");
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
	[AddressProvice] nvarchar(100),
	[AddressCity] nvarchar(100),
	[AddressDistrict] nvarchar(100),
	[AddressDetailInfo] nvarchar(500),
	[AddTime] datetime,
	[AddUser] nvarchar(200),
	[AddressPhoneNo] nvarchar(50),
	[AddressUserName] nvarchar(100),
	[IsDefault] bit,
	[UserID] int,
	[ProjectID] int,
	[RoomID] int,
	[ProjectFullName] nvarchar(500),
	[RoomName] nvarchar(500),
	[ProjectName] nvarchar(500),
	[AddressProvinceID] int,
	[RoomPhoneRelationID] int
);

INSERT INTO [dbo].[Mall_Address] (
	[Mall_Address].[AddressProvice],
	[Mall_Address].[AddressCity],
	[Mall_Address].[AddressDistrict],
	[Mall_Address].[AddressDetailInfo],
	[Mall_Address].[AddTime],
	[Mall_Address].[AddUser],
	[Mall_Address].[AddressPhoneNo],
	[Mall_Address].[AddressUserName],
	[Mall_Address].[IsDefault],
	[Mall_Address].[UserID],
	[Mall_Address].[ProjectID],
	[Mall_Address].[RoomID],
	[Mall_Address].[ProjectFullName],
	[Mall_Address].[RoomName],
	[Mall_Address].[ProjectName],
	[Mall_Address].[AddressProvinceID],
	[Mall_Address].[RoomPhoneRelationID]
) 
output 
	INSERTED.[ID],
	INSERTED.[AddressProvice],
	INSERTED.[AddressCity],
	INSERTED.[AddressDistrict],
	INSERTED.[AddressDetailInfo],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[AddressPhoneNo],
	INSERTED.[AddressUserName],
	INSERTED.[IsDefault],
	INSERTED.[UserID],
	INSERTED.[ProjectID],
	INSERTED.[RoomID],
	INSERTED.[ProjectFullName],
	INSERTED.[RoomName],
	INSERTED.[ProjectName],
	INSERTED.[AddressProvinceID],
	INSERTED.[RoomPhoneRelationID]
into @table
VALUES ( 
	@AddressProvice,
	@AddressCity,
	@AddressDistrict,
	@AddressDetailInfo,
	@AddTime,
	@AddUser,
	@AddressPhoneNo,
	@AddressUserName,
	@IsDefault,
	@UserID,
	@ProjectID,
	@RoomID,
	@ProjectFullName,
	@RoomName,
	@ProjectName,
	@AddressProvinceID,
	@RoomPhoneRelationID 
); 

SELECT 
	[ID],
	[AddressProvice],
	[AddressCity],
	[AddressDistrict],
	[AddressDetailInfo],
	[AddTime],
	[AddUser],
	[AddressPhoneNo],
	[AddressUserName],
	[IsDefault],
	[UserID],
	[ProjectID],
	[RoomID],
	[ProjectFullName],
	[RoomName],
	[ProjectName],
	[AddressProvinceID],
	[RoomPhoneRelationID] 
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
	[AddressProvice] nvarchar(100),
	[AddressCity] nvarchar(100),
	[AddressDistrict] nvarchar(100),
	[AddressDetailInfo] nvarchar(500),
	[AddTime] datetime,
	[AddUser] nvarchar(200),
	[AddressPhoneNo] nvarchar(50),
	[AddressUserName] nvarchar(100),
	[IsDefault] bit,
	[UserID] int,
	[ProjectID] int,
	[RoomID] int,
	[ProjectFullName] nvarchar(500),
	[RoomName] nvarchar(500),
	[ProjectName] nvarchar(500),
	[AddressProvinceID] int,
	[RoomPhoneRelationID] int
);

UPDATE [dbo].[Mall_Address] SET 
	[Mall_Address].[AddressProvice] = @AddressProvice,
	[Mall_Address].[AddressCity] = @AddressCity,
	[Mall_Address].[AddressDistrict] = @AddressDistrict,
	[Mall_Address].[AddressDetailInfo] = @AddressDetailInfo,
	[Mall_Address].[AddTime] = @AddTime,
	[Mall_Address].[AddUser] = @AddUser,
	[Mall_Address].[AddressPhoneNo] = @AddressPhoneNo,
	[Mall_Address].[AddressUserName] = @AddressUserName,
	[Mall_Address].[IsDefault] = @IsDefault,
	[Mall_Address].[UserID] = @UserID,
	[Mall_Address].[ProjectID] = @ProjectID,
	[Mall_Address].[RoomID] = @RoomID,
	[Mall_Address].[ProjectFullName] = @ProjectFullName,
	[Mall_Address].[RoomName] = @RoomName,
	[Mall_Address].[ProjectName] = @ProjectName,
	[Mall_Address].[AddressProvinceID] = @AddressProvinceID,
	[Mall_Address].[RoomPhoneRelationID] = @RoomPhoneRelationID 
output 
	INSERTED.[ID],
	INSERTED.[AddressProvice],
	INSERTED.[AddressCity],
	INSERTED.[AddressDistrict],
	INSERTED.[AddressDetailInfo],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[AddressPhoneNo],
	INSERTED.[AddressUserName],
	INSERTED.[IsDefault],
	INSERTED.[UserID],
	INSERTED.[ProjectID],
	INSERTED.[RoomID],
	INSERTED.[ProjectFullName],
	INSERTED.[RoomName],
	INSERTED.[ProjectName],
	INSERTED.[AddressProvinceID],
	INSERTED.[RoomPhoneRelationID]
into @table
WHERE 
	[Mall_Address].[ID] = @ID

SELECT 
	[ID],
	[AddressProvice],
	[AddressCity],
	[AddressDistrict],
	[AddressDetailInfo],
	[AddTime],
	[AddUser],
	[AddressPhoneNo],
	[AddressUserName],
	[IsDefault],
	[UserID],
	[ProjectID],
	[RoomID],
	[ProjectFullName],
	[RoomName],
	[ProjectName],
	[AddressProvinceID],
	[RoomPhoneRelationID] 
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
DELETE FROM [dbo].[Mall_Address]
WHERE 
	[Mall_Address].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_Address() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_Address(this.ID));
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
	[Mall_Address].[ID],
	[Mall_Address].[AddressProvice],
	[Mall_Address].[AddressCity],
	[Mall_Address].[AddressDistrict],
	[Mall_Address].[AddressDetailInfo],
	[Mall_Address].[AddTime],
	[Mall_Address].[AddUser],
	[Mall_Address].[AddressPhoneNo],
	[Mall_Address].[AddressUserName],
	[Mall_Address].[IsDefault],
	[Mall_Address].[UserID],
	[Mall_Address].[ProjectID],
	[Mall_Address].[RoomID],
	[Mall_Address].[ProjectFullName],
	[Mall_Address].[RoomName],
	[Mall_Address].[ProjectName],
	[Mall_Address].[AddressProvinceID],
	[Mall_Address].[RoomPhoneRelationID]
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
                return "Mall_Address";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_Address into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="addressProvice">addressProvice</param>
		/// <param name="addressCity">addressCity</param>
		/// <param name="addressDistrict">addressDistrict</param>
		/// <param name="addressDetailInfo">addressDetailInfo</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="addressPhoneNo">addressPhoneNo</param>
		/// <param name="addressUserName">addressUserName</param>
		/// <param name="isDefault">isDefault</param>
		/// <param name="userID">userID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="roomID">roomID</param>
		/// <param name="projectFullName">projectFullName</param>
		/// <param name="roomName">roomName</param>
		/// <param name="projectName">projectName</param>
		/// <param name="addressProvinceID">addressProvinceID</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		public static void InsertMall_Address(string @addressProvice, string @addressCity, string @addressDistrict, string @addressDetailInfo, DateTime @addTime, string @addUser, string @addressPhoneNo, string @addressUserName, bool @isDefault, int @userID, int @projectID, int @roomID, string @projectFullName, string @roomName, string @projectName, int @addressProvinceID, int @roomPhoneRelationID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_Address(@addressProvice, @addressCity, @addressDistrict, @addressDetailInfo, @addTime, @addUser, @addressPhoneNo, @addressUserName, @isDefault, @userID, @projectID, @roomID, @projectFullName, @roomName, @projectName, @addressProvinceID, @roomPhoneRelationID, helper);
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
		/// Insert a Mall_Address into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="addressProvice">addressProvice</param>
		/// <param name="addressCity">addressCity</param>
		/// <param name="addressDistrict">addressDistrict</param>
		/// <param name="addressDetailInfo">addressDetailInfo</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="addressPhoneNo">addressPhoneNo</param>
		/// <param name="addressUserName">addressUserName</param>
		/// <param name="isDefault">isDefault</param>
		/// <param name="userID">userID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="roomID">roomID</param>
		/// <param name="projectFullName">projectFullName</param>
		/// <param name="roomName">roomName</param>
		/// <param name="projectName">projectName</param>
		/// <param name="addressProvinceID">addressProvinceID</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_Address(string @addressProvice, string @addressCity, string @addressDistrict, string @addressDetailInfo, DateTime @addTime, string @addUser, string @addressPhoneNo, string @addressUserName, bool @isDefault, int @userID, int @projectID, int @roomID, string @projectFullName, string @roomName, string @projectName, int @addressProvinceID, int @roomPhoneRelationID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AddressProvice] nvarchar(100),
	[AddressCity] nvarchar(100),
	[AddressDistrict] nvarchar(100),
	[AddressDetailInfo] nvarchar(500),
	[AddTime] datetime,
	[AddUser] nvarchar(200),
	[AddressPhoneNo] nvarchar(50),
	[AddressUserName] nvarchar(100),
	[IsDefault] bit,
	[UserID] int,
	[ProjectID] int,
	[RoomID] int,
	[ProjectFullName] nvarchar(500),
	[RoomName] nvarchar(500),
	[ProjectName] nvarchar(500),
	[AddressProvinceID] int,
	[RoomPhoneRelationID] int
);

INSERT INTO [dbo].[Mall_Address] (
	[Mall_Address].[AddressProvice],
	[Mall_Address].[AddressCity],
	[Mall_Address].[AddressDistrict],
	[Mall_Address].[AddressDetailInfo],
	[Mall_Address].[AddTime],
	[Mall_Address].[AddUser],
	[Mall_Address].[AddressPhoneNo],
	[Mall_Address].[AddressUserName],
	[Mall_Address].[IsDefault],
	[Mall_Address].[UserID],
	[Mall_Address].[ProjectID],
	[Mall_Address].[RoomID],
	[Mall_Address].[ProjectFullName],
	[Mall_Address].[RoomName],
	[Mall_Address].[ProjectName],
	[Mall_Address].[AddressProvinceID],
	[Mall_Address].[RoomPhoneRelationID]
) 
output 
	INSERTED.[ID],
	INSERTED.[AddressProvice],
	INSERTED.[AddressCity],
	INSERTED.[AddressDistrict],
	INSERTED.[AddressDetailInfo],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[AddressPhoneNo],
	INSERTED.[AddressUserName],
	INSERTED.[IsDefault],
	INSERTED.[UserID],
	INSERTED.[ProjectID],
	INSERTED.[RoomID],
	INSERTED.[ProjectFullName],
	INSERTED.[RoomName],
	INSERTED.[ProjectName],
	INSERTED.[AddressProvinceID],
	INSERTED.[RoomPhoneRelationID]
into @table
VALUES ( 
	@AddressProvice,
	@AddressCity,
	@AddressDistrict,
	@AddressDetailInfo,
	@AddTime,
	@AddUser,
	@AddressPhoneNo,
	@AddressUserName,
	@IsDefault,
	@UserID,
	@ProjectID,
	@RoomID,
	@ProjectFullName,
	@RoomName,
	@ProjectName,
	@AddressProvinceID,
	@RoomPhoneRelationID 
); 

SELECT 
	[ID],
	[AddressProvice],
	[AddressCity],
	[AddressDistrict],
	[AddressDetailInfo],
	[AddTime],
	[AddUser],
	[AddressPhoneNo],
	[AddressUserName],
	[IsDefault],
	[UserID],
	[ProjectID],
	[RoomID],
	[ProjectFullName],
	[RoomName],
	[ProjectName],
	[AddressProvinceID],
	[RoomPhoneRelationID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@AddressProvice", EntityBase.GetDatabaseValue(@addressProvice)));
			parameters.Add(new SqlParameter("@AddressCity", EntityBase.GetDatabaseValue(@addressCity)));
			parameters.Add(new SqlParameter("@AddressDistrict", EntityBase.GetDatabaseValue(@addressDistrict)));
			parameters.Add(new SqlParameter("@AddressDetailInfo", EntityBase.GetDatabaseValue(@addressDetailInfo)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUser", EntityBase.GetDatabaseValue(@addUser)));
			parameters.Add(new SqlParameter("@AddressPhoneNo", EntityBase.GetDatabaseValue(@addressPhoneNo)));
			parameters.Add(new SqlParameter("@AddressUserName", EntityBase.GetDatabaseValue(@addressUserName)));
			parameters.Add(new SqlParameter("@IsDefault", @isDefault));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@ProjectFullName", EntityBase.GetDatabaseValue(@projectFullName)));
			parameters.Add(new SqlParameter("@RoomName", EntityBase.GetDatabaseValue(@roomName)));
			parameters.Add(new SqlParameter("@ProjectName", EntityBase.GetDatabaseValue(@projectName)));
			parameters.Add(new SqlParameter("@AddressProvinceID", EntityBase.GetDatabaseValue(@addressProvinceID)));
			parameters.Add(new SqlParameter("@RoomPhoneRelationID", EntityBase.GetDatabaseValue(@roomPhoneRelationID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_Address into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="addressProvice">addressProvice</param>
		/// <param name="addressCity">addressCity</param>
		/// <param name="addressDistrict">addressDistrict</param>
		/// <param name="addressDetailInfo">addressDetailInfo</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="addressPhoneNo">addressPhoneNo</param>
		/// <param name="addressUserName">addressUserName</param>
		/// <param name="isDefault">isDefault</param>
		/// <param name="userID">userID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="roomID">roomID</param>
		/// <param name="projectFullName">projectFullName</param>
		/// <param name="roomName">roomName</param>
		/// <param name="projectName">projectName</param>
		/// <param name="addressProvinceID">addressProvinceID</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		public static void UpdateMall_Address(int @iD, string @addressProvice, string @addressCity, string @addressDistrict, string @addressDetailInfo, DateTime @addTime, string @addUser, string @addressPhoneNo, string @addressUserName, bool @isDefault, int @userID, int @projectID, int @roomID, string @projectFullName, string @roomName, string @projectName, int @addressProvinceID, int @roomPhoneRelationID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_Address(@iD, @addressProvice, @addressCity, @addressDistrict, @addressDetailInfo, @addTime, @addUser, @addressPhoneNo, @addressUserName, @isDefault, @userID, @projectID, @roomID, @projectFullName, @roomName, @projectName, @addressProvinceID, @roomPhoneRelationID, helper);
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
		/// Updates a Mall_Address into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="addressProvice">addressProvice</param>
		/// <param name="addressCity">addressCity</param>
		/// <param name="addressDistrict">addressDistrict</param>
		/// <param name="addressDetailInfo">addressDetailInfo</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="addressPhoneNo">addressPhoneNo</param>
		/// <param name="addressUserName">addressUserName</param>
		/// <param name="isDefault">isDefault</param>
		/// <param name="userID">userID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="roomID">roomID</param>
		/// <param name="projectFullName">projectFullName</param>
		/// <param name="roomName">roomName</param>
		/// <param name="projectName">projectName</param>
		/// <param name="addressProvinceID">addressProvinceID</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_Address(int @iD, string @addressProvice, string @addressCity, string @addressDistrict, string @addressDetailInfo, DateTime @addTime, string @addUser, string @addressPhoneNo, string @addressUserName, bool @isDefault, int @userID, int @projectID, int @roomID, string @projectFullName, string @roomName, string @projectName, int @addressProvinceID, int @roomPhoneRelationID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AddressProvice] nvarchar(100),
	[AddressCity] nvarchar(100),
	[AddressDistrict] nvarchar(100),
	[AddressDetailInfo] nvarchar(500),
	[AddTime] datetime,
	[AddUser] nvarchar(200),
	[AddressPhoneNo] nvarchar(50),
	[AddressUserName] nvarchar(100),
	[IsDefault] bit,
	[UserID] int,
	[ProjectID] int,
	[RoomID] int,
	[ProjectFullName] nvarchar(500),
	[RoomName] nvarchar(500),
	[ProjectName] nvarchar(500),
	[AddressProvinceID] int,
	[RoomPhoneRelationID] int
);

UPDATE [dbo].[Mall_Address] SET 
	[Mall_Address].[AddressProvice] = @AddressProvice,
	[Mall_Address].[AddressCity] = @AddressCity,
	[Mall_Address].[AddressDistrict] = @AddressDistrict,
	[Mall_Address].[AddressDetailInfo] = @AddressDetailInfo,
	[Mall_Address].[AddTime] = @AddTime,
	[Mall_Address].[AddUser] = @AddUser,
	[Mall_Address].[AddressPhoneNo] = @AddressPhoneNo,
	[Mall_Address].[AddressUserName] = @AddressUserName,
	[Mall_Address].[IsDefault] = @IsDefault,
	[Mall_Address].[UserID] = @UserID,
	[Mall_Address].[ProjectID] = @ProjectID,
	[Mall_Address].[RoomID] = @RoomID,
	[Mall_Address].[ProjectFullName] = @ProjectFullName,
	[Mall_Address].[RoomName] = @RoomName,
	[Mall_Address].[ProjectName] = @ProjectName,
	[Mall_Address].[AddressProvinceID] = @AddressProvinceID,
	[Mall_Address].[RoomPhoneRelationID] = @RoomPhoneRelationID 
output 
	INSERTED.[ID],
	INSERTED.[AddressProvice],
	INSERTED.[AddressCity],
	INSERTED.[AddressDistrict],
	INSERTED.[AddressDetailInfo],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[AddressPhoneNo],
	INSERTED.[AddressUserName],
	INSERTED.[IsDefault],
	INSERTED.[UserID],
	INSERTED.[ProjectID],
	INSERTED.[RoomID],
	INSERTED.[ProjectFullName],
	INSERTED.[RoomName],
	INSERTED.[ProjectName],
	INSERTED.[AddressProvinceID],
	INSERTED.[RoomPhoneRelationID]
into @table
WHERE 
	[Mall_Address].[ID] = @ID

SELECT 
	[ID],
	[AddressProvice],
	[AddressCity],
	[AddressDistrict],
	[AddressDetailInfo],
	[AddTime],
	[AddUser],
	[AddressPhoneNo],
	[AddressUserName],
	[IsDefault],
	[UserID],
	[ProjectID],
	[RoomID],
	[ProjectFullName],
	[RoomName],
	[ProjectName],
	[AddressProvinceID],
	[RoomPhoneRelationID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@AddressProvice", EntityBase.GetDatabaseValue(@addressProvice)));
			parameters.Add(new SqlParameter("@AddressCity", EntityBase.GetDatabaseValue(@addressCity)));
			parameters.Add(new SqlParameter("@AddressDistrict", EntityBase.GetDatabaseValue(@addressDistrict)));
			parameters.Add(new SqlParameter("@AddressDetailInfo", EntityBase.GetDatabaseValue(@addressDetailInfo)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUser", EntityBase.GetDatabaseValue(@addUser)));
			parameters.Add(new SqlParameter("@AddressPhoneNo", EntityBase.GetDatabaseValue(@addressPhoneNo)));
			parameters.Add(new SqlParameter("@AddressUserName", EntityBase.GetDatabaseValue(@addressUserName)));
			parameters.Add(new SqlParameter("@IsDefault", @isDefault));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@ProjectFullName", EntityBase.GetDatabaseValue(@projectFullName)));
			parameters.Add(new SqlParameter("@RoomName", EntityBase.GetDatabaseValue(@roomName)));
			parameters.Add(new SqlParameter("@ProjectName", EntityBase.GetDatabaseValue(@projectName)));
			parameters.Add(new SqlParameter("@AddressProvinceID", EntityBase.GetDatabaseValue(@addressProvinceID)));
			parameters.Add(new SqlParameter("@RoomPhoneRelationID", EntityBase.GetDatabaseValue(@roomPhoneRelationID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_Address from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_Address(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_Address(@iD, helper);
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
		/// Deletes a Mall_Address from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_Address(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_Address]
WHERE 
	[Mall_Address].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_Address object.
		/// </summary>
		/// <returns>The newly created Mall_Address object.</returns>
		public static Mall_Address CreateMall_Address()
		{
			return InitializeNew<Mall_Address>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_Address by a Mall_Address's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_Address</returns>
		public static Mall_Address GetMall_Address(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_Address.SelectFieldList + @"
FROM [dbo].[Mall_Address] 
WHERE 
	[Mall_Address].[ID] = @ID " + Mall_Address.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Address>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_Address by a Mall_Address's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_Address</returns>
		public static Mall_Address GetMall_Address(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_Address.SelectFieldList + @"
FROM [dbo].[Mall_Address] 
WHERE 
	[Mall_Address].[ID] = @ID " + Mall_Address.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Address>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_Address objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_Address objects.</returns>
		public static EntityList<Mall_Address> GetMall_Addresses()
		{
			string commandText = @"
SELECT " + Mall_Address.SelectFieldList + "FROM [dbo].[Mall_Address] " + Mall_Address.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_Address>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_Address objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Address objects.</returns>
        public static EntityList<Mall_Address> GetMall_Addresses(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Address>(SelectFieldList, "FROM [dbo].[Mall_Address]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_Address objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Address objects.</returns>
        public static EntityList<Mall_Address> GetMall_Addresses(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Address>(SelectFieldList, "FROM [dbo].[Mall_Address]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_Address objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Address objects.</returns>
		protected static EntityList<Mall_Address> GetMall_Addresses(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Addresses(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_Address objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Address objects.</returns>
		protected static EntityList<Mall_Address> GetMall_Addresses(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Addresses(string.Empty, where, parameters, Mall_Address.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Address objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Address objects.</returns>
		protected static EntityList<Mall_Address> GetMall_Addresses(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Addresses(prefix, where, parameters, Mall_Address.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Address objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Address objects.</returns>
		protected static EntityList<Mall_Address> GetMall_Addresses(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Addresses(string.Empty, where, parameters, Mall_Address.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Address objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Address objects.</returns>
		protected static EntityList<Mall_Address> GetMall_Addresses(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Addresses(prefix, where, parameters, Mall_Address.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Address objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Address objects.</returns>
		protected static EntityList<Mall_Address> GetMall_Addresses(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_Address.SelectFieldList + "FROM [dbo].[Mall_Address] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_Address>(reader);
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
        protected static EntityList<Mall_Address> GetMall_Addresses(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Address>(SelectFieldList, "FROM [dbo].[Mall_Address] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_Address objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_AddressCount()
        {
            return GetMall_AddressCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_Address objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_AddressCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_Address] " + where;

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
		public static partial class Mall_Address_Properties
		{
			public const string ID = "ID";
			public const string AddressProvice = "AddressProvice";
			public const string AddressCity = "AddressCity";
			public const string AddressDistrict = "AddressDistrict";
			public const string AddressDetailInfo = "AddressDetailInfo";
			public const string AddTime = "AddTime";
			public const string AddUser = "AddUser";
			public const string AddressPhoneNo = "AddressPhoneNo";
			public const string AddressUserName = "AddressUserName";
			public const string IsDefault = "IsDefault";
			public const string UserID = "UserID";
			public const string ProjectID = "ProjectID";
			public const string RoomID = "RoomID";
			public const string ProjectFullName = "ProjectFullName";
			public const string RoomName = "RoomName";
			public const string ProjectName = "ProjectName";
			public const string AddressProvinceID = "AddressProvinceID";
			public const string RoomPhoneRelationID = "RoomPhoneRelationID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"AddressProvice" , "string:"},
    			 {"AddressCity" , "string:"},
    			 {"AddressDistrict" , "string:"},
    			 {"AddressDetailInfo" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUser" , "string:"},
    			 {"AddressPhoneNo" , "string:"},
    			 {"AddressUserName" , "string:"},
    			 {"IsDefault" , "bool:"},
    			 {"UserID" , "int:"},
    			 {"ProjectID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"ProjectFullName" , "string:"},
    			 {"RoomName" , "string:"},
    			 {"ProjectName" , "string:"},
    			 {"AddressProvinceID" , "int:"},
    			 {"RoomPhoneRelationID" , "int:"},
            };
		}
		#endregion
	}
}
