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
	/// This object represents the properties and methods of a Mall_DoorDevice.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_DoorDevice 
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
		private int _deviceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int DeviceID
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
		private int _projectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private string _deviceName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string DeviceName
		{
			[DebuggerStepThrough()]
			get { return this._deviceName; }
			set 
			{
				if (this._deviceName != value) 
				{
					this._deviceName = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeviceName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _deviceCode = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string DeviceCode
		{
			[DebuggerStepThrough()]
			get { return this._deviceCode; }
			set 
			{
				if (this._deviceCode != value) 
				{
					this._deviceCode = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeviceCode");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _status = int.MinValue;
		/// <summary>
		/// 0-离线 1-在线
		/// </summary>
        [Description("0-离线 1-在线")]
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
		private string _sDKKey = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SDKKey
		{
			[DebuggerStepThrough()]
			get { return this._sDKKey; }
			set 
			{
				if (this._sDKKey != value) 
				{
					this._sDKKey = value;
					this.IsDirty = true;	
					OnPropertyChanged("SDKKey");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _sDKKeyExpireDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime SDKKeyExpireDate
		{
			[DebuggerStepThrough()]
			get { return this._sDKKeyExpireDate; }
			set 
			{
				if (this._sDKKeyExpireDate != value) 
				{
					this._sDKKeyExpireDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("SDKKeyExpireDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isUseAll = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsUseAll
		{
			[DebuggerStepThrough()]
			get { return this._isUseAll; }
			set 
			{
				if (this._isUseAll != value) 
				{
					this._isUseAll = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsUseAll");
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
		private bool _isDelete = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDelete
		{
			[DebuggerStepThrough()]
			get { return this._isDelete; }
			set 
			{
				if (this._isDelete != value) 
				{
					this._isDelete = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDelete");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _disableQrCodeOpen = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool DisableQrCodeOpen
		{
			[DebuggerStepThrough()]
			get { return this._disableQrCodeOpen; }
			set 
			{
				if (this._disableQrCodeOpen != value) 
				{
					this._disableQrCodeOpen = value;
					this.IsDirty = true;	
					OnPropertyChanged("DisableQrCodeOpen");
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
	[DeviceID] int,
	[ProjectID] int,
	[ProjectName] nvarchar(200),
	[DeviceName] nvarchar(200),
	[DeviceCode] nvarchar(200),
	[Status] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[SDKKey] nvarchar(500),
	[SDKKeyExpireDate] datetime,
	[IsUseAll] bit,
	[SortOrder] int,
	[IsDelete] bit,
	[DisableQrCodeOpen] bit
);

INSERT INTO [dbo].[Mall_DoorDevice] (
	[Mall_DoorDevice].[DeviceID],
	[Mall_DoorDevice].[ProjectID],
	[Mall_DoorDevice].[ProjectName],
	[Mall_DoorDevice].[DeviceName],
	[Mall_DoorDevice].[DeviceCode],
	[Mall_DoorDevice].[Status],
	[Mall_DoorDevice].[AddTime],
	[Mall_DoorDevice].[AddUserName],
	[Mall_DoorDevice].[SDKKey],
	[Mall_DoorDevice].[SDKKeyExpireDate],
	[Mall_DoorDevice].[IsUseAll],
	[Mall_DoorDevice].[SortOrder],
	[Mall_DoorDevice].[IsDelete],
	[Mall_DoorDevice].[DisableQrCodeOpen]
) 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[ProjectID],
	INSERTED.[ProjectName],
	INSERTED.[DeviceName],
	INSERTED.[DeviceCode],
	INSERTED.[Status],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[SDKKey],
	INSERTED.[SDKKeyExpireDate],
	INSERTED.[IsUseAll],
	INSERTED.[SortOrder],
	INSERTED.[IsDelete],
	INSERTED.[DisableQrCodeOpen]
into @table
VALUES ( 
	@DeviceID,
	@ProjectID,
	@ProjectName,
	@DeviceName,
	@DeviceCode,
	@Status,
	@AddTime,
	@AddUserName,
	@SDKKey,
	@SDKKeyExpireDate,
	@IsUseAll,
	@SortOrder,
	@IsDelete,
	@DisableQrCodeOpen 
); 

SELECT 
	[ID],
	[DeviceID],
	[ProjectID],
	[ProjectName],
	[DeviceName],
	[DeviceCode],
	[Status],
	[AddTime],
	[AddUserName],
	[SDKKey],
	[SDKKeyExpireDate],
	[IsUseAll],
	[SortOrder],
	[IsDelete],
	[DisableQrCodeOpen] 
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
	[DeviceID] int,
	[ProjectID] int,
	[ProjectName] nvarchar(200),
	[DeviceName] nvarchar(200),
	[DeviceCode] nvarchar(200),
	[Status] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[SDKKey] nvarchar(500),
	[SDKKeyExpireDate] datetime,
	[IsUseAll] bit,
	[SortOrder] int,
	[IsDelete] bit,
	[DisableQrCodeOpen] bit
);

UPDATE [dbo].[Mall_DoorDevice] SET 
	[Mall_DoorDevice].[DeviceID] = @DeviceID,
	[Mall_DoorDevice].[ProjectID] = @ProjectID,
	[Mall_DoorDevice].[ProjectName] = @ProjectName,
	[Mall_DoorDevice].[DeviceName] = @DeviceName,
	[Mall_DoorDevice].[DeviceCode] = @DeviceCode,
	[Mall_DoorDevice].[Status] = @Status,
	[Mall_DoorDevice].[AddTime] = @AddTime,
	[Mall_DoorDevice].[AddUserName] = @AddUserName,
	[Mall_DoorDevice].[SDKKey] = @SDKKey,
	[Mall_DoorDevice].[SDKKeyExpireDate] = @SDKKeyExpireDate,
	[Mall_DoorDevice].[IsUseAll] = @IsUseAll,
	[Mall_DoorDevice].[SortOrder] = @SortOrder,
	[Mall_DoorDevice].[IsDelete] = @IsDelete,
	[Mall_DoorDevice].[DisableQrCodeOpen] = @DisableQrCodeOpen 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[ProjectID],
	INSERTED.[ProjectName],
	INSERTED.[DeviceName],
	INSERTED.[DeviceCode],
	INSERTED.[Status],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[SDKKey],
	INSERTED.[SDKKeyExpireDate],
	INSERTED.[IsUseAll],
	INSERTED.[SortOrder],
	INSERTED.[IsDelete],
	INSERTED.[DisableQrCodeOpen]
into @table
WHERE 
	[Mall_DoorDevice].[ID] = @ID

SELECT 
	[ID],
	[DeviceID],
	[ProjectID],
	[ProjectName],
	[DeviceName],
	[DeviceCode],
	[Status],
	[AddTime],
	[AddUserName],
	[SDKKey],
	[SDKKeyExpireDate],
	[IsUseAll],
	[SortOrder],
	[IsDelete],
	[DisableQrCodeOpen] 
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
DELETE FROM [dbo].[Mall_DoorDevice]
WHERE 
	[Mall_DoorDevice].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_DoorDevice() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_DoorDevice(this.ID));
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
	[Mall_DoorDevice].[ID],
	[Mall_DoorDevice].[DeviceID],
	[Mall_DoorDevice].[ProjectID],
	[Mall_DoorDevice].[ProjectName],
	[Mall_DoorDevice].[DeviceName],
	[Mall_DoorDevice].[DeviceCode],
	[Mall_DoorDevice].[Status],
	[Mall_DoorDevice].[AddTime],
	[Mall_DoorDevice].[AddUserName],
	[Mall_DoorDevice].[SDKKey],
	[Mall_DoorDevice].[SDKKeyExpireDate],
	[Mall_DoorDevice].[IsUseAll],
	[Mall_DoorDevice].[SortOrder],
	[Mall_DoorDevice].[IsDelete],
	[Mall_DoorDevice].[DisableQrCodeOpen]
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
                return "Mall_DoorDevice";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_DoorDevice into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="deviceID">deviceID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="projectName">projectName</param>
		/// <param name="deviceName">deviceName</param>
		/// <param name="deviceCode">deviceCode</param>
		/// <param name="status">status</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="sDKKey">sDKKey</param>
		/// <param name="sDKKeyExpireDate">sDKKeyExpireDate</param>
		/// <param name="isUseAll">isUseAll</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isDelete">isDelete</param>
		/// <param name="disableQrCodeOpen">disableQrCodeOpen</param>
		public static void InsertMall_DoorDevice(int @deviceID, int @projectID, string @projectName, string @deviceName, string @deviceCode, int @status, DateTime @addTime, string @addUserName, string @sDKKey, DateTime @sDKKeyExpireDate, bool @isUseAll, int @sortOrder, bool @isDelete, bool @disableQrCodeOpen)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_DoorDevice(@deviceID, @projectID, @projectName, @deviceName, @deviceCode, @status, @addTime, @addUserName, @sDKKey, @sDKKeyExpireDate, @isUseAll, @sortOrder, @isDelete, @disableQrCodeOpen, helper);
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
		/// Insert a Mall_DoorDevice into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="deviceID">deviceID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="projectName">projectName</param>
		/// <param name="deviceName">deviceName</param>
		/// <param name="deviceCode">deviceCode</param>
		/// <param name="status">status</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="sDKKey">sDKKey</param>
		/// <param name="sDKKeyExpireDate">sDKKeyExpireDate</param>
		/// <param name="isUseAll">isUseAll</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isDelete">isDelete</param>
		/// <param name="disableQrCodeOpen">disableQrCodeOpen</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_DoorDevice(int @deviceID, int @projectID, string @projectName, string @deviceName, string @deviceCode, int @status, DateTime @addTime, string @addUserName, string @sDKKey, DateTime @sDKKeyExpireDate, bool @isUseAll, int @sortOrder, bool @isDelete, bool @disableQrCodeOpen, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DeviceID] int,
	[ProjectID] int,
	[ProjectName] nvarchar(200),
	[DeviceName] nvarchar(200),
	[DeviceCode] nvarchar(200),
	[Status] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[SDKKey] nvarchar(500),
	[SDKKeyExpireDate] datetime,
	[IsUseAll] bit,
	[SortOrder] int,
	[IsDelete] bit,
	[DisableQrCodeOpen] bit
);

INSERT INTO [dbo].[Mall_DoorDevice] (
	[Mall_DoorDevice].[DeviceID],
	[Mall_DoorDevice].[ProjectID],
	[Mall_DoorDevice].[ProjectName],
	[Mall_DoorDevice].[DeviceName],
	[Mall_DoorDevice].[DeviceCode],
	[Mall_DoorDevice].[Status],
	[Mall_DoorDevice].[AddTime],
	[Mall_DoorDevice].[AddUserName],
	[Mall_DoorDevice].[SDKKey],
	[Mall_DoorDevice].[SDKKeyExpireDate],
	[Mall_DoorDevice].[IsUseAll],
	[Mall_DoorDevice].[SortOrder],
	[Mall_DoorDevice].[IsDelete],
	[Mall_DoorDevice].[DisableQrCodeOpen]
) 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[ProjectID],
	INSERTED.[ProjectName],
	INSERTED.[DeviceName],
	INSERTED.[DeviceCode],
	INSERTED.[Status],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[SDKKey],
	INSERTED.[SDKKeyExpireDate],
	INSERTED.[IsUseAll],
	INSERTED.[SortOrder],
	INSERTED.[IsDelete],
	INSERTED.[DisableQrCodeOpen]
into @table
VALUES ( 
	@DeviceID,
	@ProjectID,
	@ProjectName,
	@DeviceName,
	@DeviceCode,
	@Status,
	@AddTime,
	@AddUserName,
	@SDKKey,
	@SDKKeyExpireDate,
	@IsUseAll,
	@SortOrder,
	@IsDelete,
	@DisableQrCodeOpen 
); 

SELECT 
	[ID],
	[DeviceID],
	[ProjectID],
	[ProjectName],
	[DeviceName],
	[DeviceCode],
	[Status],
	[AddTime],
	[AddUserName],
	[SDKKey],
	[SDKKeyExpireDate],
	[IsUseAll],
	[SortOrder],
	[IsDelete],
	[DisableQrCodeOpen] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DeviceID", EntityBase.GetDatabaseValue(@deviceID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@ProjectName", EntityBase.GetDatabaseValue(@projectName)));
			parameters.Add(new SqlParameter("@DeviceName", EntityBase.GetDatabaseValue(@deviceName)));
			parameters.Add(new SqlParameter("@DeviceCode", EntityBase.GetDatabaseValue(@deviceCode)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@SDKKey", EntityBase.GetDatabaseValue(@sDKKey)));
			parameters.Add(new SqlParameter("@SDKKeyExpireDate", EntityBase.GetDatabaseValue(@sDKKeyExpireDate)));
			parameters.Add(new SqlParameter("@IsUseAll", @isUseAll));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsDelete", @isDelete));
			parameters.Add(new SqlParameter("@DisableQrCodeOpen", @disableQrCodeOpen));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_DoorDevice into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="deviceID">deviceID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="projectName">projectName</param>
		/// <param name="deviceName">deviceName</param>
		/// <param name="deviceCode">deviceCode</param>
		/// <param name="status">status</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="sDKKey">sDKKey</param>
		/// <param name="sDKKeyExpireDate">sDKKeyExpireDate</param>
		/// <param name="isUseAll">isUseAll</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isDelete">isDelete</param>
		/// <param name="disableQrCodeOpen">disableQrCodeOpen</param>
		public static void UpdateMall_DoorDevice(int @iD, int @deviceID, int @projectID, string @projectName, string @deviceName, string @deviceCode, int @status, DateTime @addTime, string @addUserName, string @sDKKey, DateTime @sDKKeyExpireDate, bool @isUseAll, int @sortOrder, bool @isDelete, bool @disableQrCodeOpen)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_DoorDevice(@iD, @deviceID, @projectID, @projectName, @deviceName, @deviceCode, @status, @addTime, @addUserName, @sDKKey, @sDKKeyExpireDate, @isUseAll, @sortOrder, @isDelete, @disableQrCodeOpen, helper);
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
		/// Updates a Mall_DoorDevice into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="deviceID">deviceID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="projectName">projectName</param>
		/// <param name="deviceName">deviceName</param>
		/// <param name="deviceCode">deviceCode</param>
		/// <param name="status">status</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="sDKKey">sDKKey</param>
		/// <param name="sDKKeyExpireDate">sDKKeyExpireDate</param>
		/// <param name="isUseAll">isUseAll</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isDelete">isDelete</param>
		/// <param name="disableQrCodeOpen">disableQrCodeOpen</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_DoorDevice(int @iD, int @deviceID, int @projectID, string @projectName, string @deviceName, string @deviceCode, int @status, DateTime @addTime, string @addUserName, string @sDKKey, DateTime @sDKKeyExpireDate, bool @isUseAll, int @sortOrder, bool @isDelete, bool @disableQrCodeOpen, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DeviceID] int,
	[ProjectID] int,
	[ProjectName] nvarchar(200),
	[DeviceName] nvarchar(200),
	[DeviceCode] nvarchar(200),
	[Status] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[SDKKey] nvarchar(500),
	[SDKKeyExpireDate] datetime,
	[IsUseAll] bit,
	[SortOrder] int,
	[IsDelete] bit,
	[DisableQrCodeOpen] bit
);

UPDATE [dbo].[Mall_DoorDevice] SET 
	[Mall_DoorDevice].[DeviceID] = @DeviceID,
	[Mall_DoorDevice].[ProjectID] = @ProjectID,
	[Mall_DoorDevice].[ProjectName] = @ProjectName,
	[Mall_DoorDevice].[DeviceName] = @DeviceName,
	[Mall_DoorDevice].[DeviceCode] = @DeviceCode,
	[Mall_DoorDevice].[Status] = @Status,
	[Mall_DoorDevice].[AddTime] = @AddTime,
	[Mall_DoorDevice].[AddUserName] = @AddUserName,
	[Mall_DoorDevice].[SDKKey] = @SDKKey,
	[Mall_DoorDevice].[SDKKeyExpireDate] = @SDKKeyExpireDate,
	[Mall_DoorDevice].[IsUseAll] = @IsUseAll,
	[Mall_DoorDevice].[SortOrder] = @SortOrder,
	[Mall_DoorDevice].[IsDelete] = @IsDelete,
	[Mall_DoorDevice].[DisableQrCodeOpen] = @DisableQrCodeOpen 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[ProjectID],
	INSERTED.[ProjectName],
	INSERTED.[DeviceName],
	INSERTED.[DeviceCode],
	INSERTED.[Status],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[SDKKey],
	INSERTED.[SDKKeyExpireDate],
	INSERTED.[IsUseAll],
	INSERTED.[SortOrder],
	INSERTED.[IsDelete],
	INSERTED.[DisableQrCodeOpen]
into @table
WHERE 
	[Mall_DoorDevice].[ID] = @ID

SELECT 
	[ID],
	[DeviceID],
	[ProjectID],
	[ProjectName],
	[DeviceName],
	[DeviceCode],
	[Status],
	[AddTime],
	[AddUserName],
	[SDKKey],
	[SDKKeyExpireDate],
	[IsUseAll],
	[SortOrder],
	[IsDelete],
	[DisableQrCodeOpen] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@DeviceID", EntityBase.GetDatabaseValue(@deviceID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@ProjectName", EntityBase.GetDatabaseValue(@projectName)));
			parameters.Add(new SqlParameter("@DeviceName", EntityBase.GetDatabaseValue(@deviceName)));
			parameters.Add(new SqlParameter("@DeviceCode", EntityBase.GetDatabaseValue(@deviceCode)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@SDKKey", EntityBase.GetDatabaseValue(@sDKKey)));
			parameters.Add(new SqlParameter("@SDKKeyExpireDate", EntityBase.GetDatabaseValue(@sDKKeyExpireDate)));
			parameters.Add(new SqlParameter("@IsUseAll", @isUseAll));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsDelete", @isDelete));
			parameters.Add(new SqlParameter("@DisableQrCodeOpen", @disableQrCodeOpen));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_DoorDevice from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_DoorDevice(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_DoorDevice(@iD, helper);
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
		/// Deletes a Mall_DoorDevice from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_DoorDevice(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_DoorDevice]
WHERE 
	[Mall_DoorDevice].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_DoorDevice object.
		/// </summary>
		/// <returns>The newly created Mall_DoorDevice object.</returns>
		public static Mall_DoorDevice CreateMall_DoorDevice()
		{
			return InitializeNew<Mall_DoorDevice>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_DoorDevice by a Mall_DoorDevice's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_DoorDevice</returns>
		public static Mall_DoorDevice GetMall_DoorDevice(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_DoorDevice.SelectFieldList + @"
FROM [dbo].[Mall_DoorDevice] 
WHERE 
	[Mall_DoorDevice].[ID] = @ID " + Mall_DoorDevice.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_DoorDevice>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_DoorDevice by a Mall_DoorDevice's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_DoorDevice</returns>
		public static Mall_DoorDevice GetMall_DoorDevice(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_DoorDevice.SelectFieldList + @"
FROM [dbo].[Mall_DoorDevice] 
WHERE 
	[Mall_DoorDevice].[ID] = @ID " + Mall_DoorDevice.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_DoorDevice>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorDevice objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_DoorDevice objects.</returns>
		public static EntityList<Mall_DoorDevice> GetMall_DoorDevices()
		{
			string commandText = @"
SELECT " + Mall_DoorDevice.SelectFieldList + "FROM [dbo].[Mall_DoorDevice] " + Mall_DoorDevice.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_DoorDevice>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_DoorDevice objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_DoorDevice objects.</returns>
        public static EntityList<Mall_DoorDevice> GetMall_DoorDevices(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorDevice>(SelectFieldList, "FROM [dbo].[Mall_DoorDevice]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_DoorDevice objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_DoorDevice objects.</returns>
        public static EntityList<Mall_DoorDevice> GetMall_DoorDevices(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorDevice>(SelectFieldList, "FROM [dbo].[Mall_DoorDevice]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_DoorDevice objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_DoorDevice objects.</returns>
		protected static EntityList<Mall_DoorDevice> GetMall_DoorDevices(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorDevices(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorDevice objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorDevice objects.</returns>
		protected static EntityList<Mall_DoorDevice> GetMall_DoorDevices(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorDevices(string.Empty, where, parameters, Mall_DoorDevice.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorDevice objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorDevice objects.</returns>
		protected static EntityList<Mall_DoorDevice> GetMall_DoorDevices(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorDevices(prefix, where, parameters, Mall_DoorDevice.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorDevice objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorDevice objects.</returns>
		protected static EntityList<Mall_DoorDevice> GetMall_DoorDevices(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_DoorDevices(string.Empty, where, parameters, Mall_DoorDevice.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorDevice objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorDevice objects.</returns>
		protected static EntityList<Mall_DoorDevice> GetMall_DoorDevices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_DoorDevices(prefix, where, parameters, Mall_DoorDevice.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorDevice objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_DoorDevice objects.</returns>
		protected static EntityList<Mall_DoorDevice> GetMall_DoorDevices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_DoorDevice.SelectFieldList + "FROM [dbo].[Mall_DoorDevice] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_DoorDevice>(reader);
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
        protected static EntityList<Mall_DoorDevice> GetMall_DoorDevices(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorDevice>(SelectFieldList, "FROM [dbo].[Mall_DoorDevice] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_DoorDevice objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_DoorDeviceCount()
        {
            return GetMall_DoorDeviceCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_DoorDevice objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_DoorDeviceCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_DoorDevice] " + where;

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
		public static partial class Mall_DoorDevice_Properties
		{
			public const string ID = "ID";
			public const string DeviceID = "DeviceID";
			public const string ProjectID = "ProjectID";
			public const string ProjectName = "ProjectName";
			public const string DeviceName = "DeviceName";
			public const string DeviceCode = "DeviceCode";
			public const string Status = "Status";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string SDKKey = "SDKKey";
			public const string SDKKeyExpireDate = "SDKKeyExpireDate";
			public const string IsUseAll = "IsUseAll";
			public const string SortOrder = "SortOrder";
			public const string IsDelete = "IsDelete";
			public const string DisableQrCodeOpen = "DisableQrCodeOpen";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"DeviceID" , "int:"},
    			 {"ProjectID" , "int:"},
    			 {"ProjectName" , "string:"},
    			 {"DeviceName" , "string:"},
    			 {"DeviceCode" , "string:"},
    			 {"Status" , "int:0-离线 1-在线"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"SDKKey" , "string:"},
    			 {"SDKKeyExpireDate" , "DateTime:"},
    			 {"IsUseAll" , "bool:"},
    			 {"SortOrder" , "int:"},
    			 {"IsDelete" , "bool:"},
    			 {"DisableQrCodeOpen" , "bool:"},
            };
		}
		#endregion
	}
}
