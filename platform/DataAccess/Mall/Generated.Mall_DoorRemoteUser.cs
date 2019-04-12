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
	/// This object represents the properties and methods of a Mall_DoorRemoteUser.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_DoorRemoteUser 
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
		private string _title = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Title
		{
			[DebuggerStepThrough()]
			get { return this._title; }
			set 
			{
				if (this._title != value) 
				{
					this._title = value;
					this.IsDirty = true;	
					OnPropertyChanged("Title");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _description = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Description
		{
			[DebuggerStepThrough()]
			get { return this._description; }
			set 
			{
				if (this._description != value) 
				{
					this._description = value;
					this.IsDirty = true;	
					OnPropertyChanged("Description");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isForever = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsForever
		{
			[DebuggerStepThrough()]
			get { return this._isForever; }
			set 
			{
				if (this._isForever != value) 
				{
					this._isForever = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsForever");
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
		private bool _isActive = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsActive
		{
			[DebuggerStepThrough()]
			get { return this._isActive; }
			set 
			{
				if (this._isActive != value) 
				{
					this._isActive = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsActive");
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
		[DataObjectField(false, false, true)]
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isUseForALLDevice = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsUseForALLDevice
		{
			[DebuggerStepThrough()]
			get { return this._isUseForALLDevice; }
			set 
			{
				if (this._isUseForALLDevice != value) 
				{
					this._isUseForALLDevice = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsUseForALLDevice");
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
	[ProjectID] int,
	[ProjectName] nvarchar(200),
	[UserID] int,
	[Title] nvarchar(200),
	[Description] ntext,
	[IsForever] bit,
	[EndTime] datetime,
	[IsActive] bit,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[RoomPhoneRelationID] int,
	[IsUseForALLDevice] bit
);

INSERT INTO [dbo].[Mall_DoorRemoteUser] (
	[Mall_DoorRemoteUser].[ProjectID],
	[Mall_DoorRemoteUser].[ProjectName],
	[Mall_DoorRemoteUser].[UserID],
	[Mall_DoorRemoteUser].[Title],
	[Mall_DoorRemoteUser].[Description],
	[Mall_DoorRemoteUser].[IsForever],
	[Mall_DoorRemoteUser].[EndTime],
	[Mall_DoorRemoteUser].[IsActive],
	[Mall_DoorRemoteUser].[AddTime],
	[Mall_DoorRemoteUser].[AddUserName],
	[Mall_DoorRemoteUser].[RoomPhoneRelationID],
	[Mall_DoorRemoteUser].[IsUseForALLDevice]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[ProjectName],
	INSERTED.[UserID],
	INSERTED.[Title],
	INSERTED.[Description],
	INSERTED.[IsForever],
	INSERTED.[EndTime],
	INSERTED.[IsActive],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[IsUseForALLDevice]
into @table
VALUES ( 
	@ProjectID,
	@ProjectName,
	@UserID,
	@Title,
	@Description,
	@IsForever,
	@EndTime,
	@IsActive,
	@AddTime,
	@AddUserName,
	@RoomPhoneRelationID,
	@IsUseForALLDevice 
); 

SELECT 
	[ID],
	[ProjectID],
	[ProjectName],
	[UserID],
	[Title],
	[Description],
	[IsForever],
	[EndTime],
	[IsActive],
	[AddTime],
	[AddUserName],
	[RoomPhoneRelationID],
	[IsUseForALLDevice] 
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
	[ProjectID] int,
	[ProjectName] nvarchar(200),
	[UserID] int,
	[Title] nvarchar(200),
	[Description] ntext,
	[IsForever] bit,
	[EndTime] datetime,
	[IsActive] bit,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[RoomPhoneRelationID] int,
	[IsUseForALLDevice] bit
);

UPDATE [dbo].[Mall_DoorRemoteUser] SET 
	[Mall_DoorRemoteUser].[ProjectID] = @ProjectID,
	[Mall_DoorRemoteUser].[ProjectName] = @ProjectName,
	[Mall_DoorRemoteUser].[UserID] = @UserID,
	[Mall_DoorRemoteUser].[Title] = @Title,
	[Mall_DoorRemoteUser].[Description] = @Description,
	[Mall_DoorRemoteUser].[IsForever] = @IsForever,
	[Mall_DoorRemoteUser].[EndTime] = @EndTime,
	[Mall_DoorRemoteUser].[IsActive] = @IsActive,
	[Mall_DoorRemoteUser].[AddTime] = @AddTime,
	[Mall_DoorRemoteUser].[AddUserName] = @AddUserName,
	[Mall_DoorRemoteUser].[RoomPhoneRelationID] = @RoomPhoneRelationID,
	[Mall_DoorRemoteUser].[IsUseForALLDevice] = @IsUseForALLDevice 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[ProjectName],
	INSERTED.[UserID],
	INSERTED.[Title],
	INSERTED.[Description],
	INSERTED.[IsForever],
	INSERTED.[EndTime],
	INSERTED.[IsActive],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[IsUseForALLDevice]
into @table
WHERE 
	[Mall_DoorRemoteUser].[ID] = @ID

SELECT 
	[ID],
	[ProjectID],
	[ProjectName],
	[UserID],
	[Title],
	[Description],
	[IsForever],
	[EndTime],
	[IsActive],
	[AddTime],
	[AddUserName],
	[RoomPhoneRelationID],
	[IsUseForALLDevice] 
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
DELETE FROM [dbo].[Mall_DoorRemoteUser]
WHERE 
	[Mall_DoorRemoteUser].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_DoorRemoteUser() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_DoorRemoteUser(this.ID));
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
	[Mall_DoorRemoteUser].[ID],
	[Mall_DoorRemoteUser].[ProjectID],
	[Mall_DoorRemoteUser].[ProjectName],
	[Mall_DoorRemoteUser].[UserID],
	[Mall_DoorRemoteUser].[Title],
	[Mall_DoorRemoteUser].[Description],
	[Mall_DoorRemoteUser].[IsForever],
	[Mall_DoorRemoteUser].[EndTime],
	[Mall_DoorRemoteUser].[IsActive],
	[Mall_DoorRemoteUser].[AddTime],
	[Mall_DoorRemoteUser].[AddUserName],
	[Mall_DoorRemoteUser].[RoomPhoneRelationID],
	[Mall_DoorRemoteUser].[IsUseForALLDevice]
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
                return "Mall_DoorRemoteUser";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_DoorRemoteUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="projectName">projectName</param>
		/// <param name="userID">userID</param>
		/// <param name="title">title</param>
		/// <param name="description">description</param>
		/// <param name="isForever">isForever</param>
		/// <param name="endTime">endTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="isUseForALLDevice">isUseForALLDevice</param>
		public static void InsertMall_DoorRemoteUser(int @projectID, string @projectName, int @userID, string @title, string @description, bool @isForever, DateTime @endTime, bool @isActive, DateTime @addTime, string @addUserName, int @roomPhoneRelationID, bool @isUseForALLDevice)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_DoorRemoteUser(@projectID, @projectName, @userID, @title, @description, @isForever, @endTime, @isActive, @addTime, @addUserName, @roomPhoneRelationID, @isUseForALLDevice, helper);
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
		/// Insert a Mall_DoorRemoteUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="projectName">projectName</param>
		/// <param name="userID">userID</param>
		/// <param name="title">title</param>
		/// <param name="description">description</param>
		/// <param name="isForever">isForever</param>
		/// <param name="endTime">endTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="isUseForALLDevice">isUseForALLDevice</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_DoorRemoteUser(int @projectID, string @projectName, int @userID, string @title, string @description, bool @isForever, DateTime @endTime, bool @isActive, DateTime @addTime, string @addUserName, int @roomPhoneRelationID, bool @isUseForALLDevice, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectID] int,
	[ProjectName] nvarchar(200),
	[UserID] int,
	[Title] nvarchar(200),
	[Description] ntext,
	[IsForever] bit,
	[EndTime] datetime,
	[IsActive] bit,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[RoomPhoneRelationID] int,
	[IsUseForALLDevice] bit
);

INSERT INTO [dbo].[Mall_DoorRemoteUser] (
	[Mall_DoorRemoteUser].[ProjectID],
	[Mall_DoorRemoteUser].[ProjectName],
	[Mall_DoorRemoteUser].[UserID],
	[Mall_DoorRemoteUser].[Title],
	[Mall_DoorRemoteUser].[Description],
	[Mall_DoorRemoteUser].[IsForever],
	[Mall_DoorRemoteUser].[EndTime],
	[Mall_DoorRemoteUser].[IsActive],
	[Mall_DoorRemoteUser].[AddTime],
	[Mall_DoorRemoteUser].[AddUserName],
	[Mall_DoorRemoteUser].[RoomPhoneRelationID],
	[Mall_DoorRemoteUser].[IsUseForALLDevice]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[ProjectName],
	INSERTED.[UserID],
	INSERTED.[Title],
	INSERTED.[Description],
	INSERTED.[IsForever],
	INSERTED.[EndTime],
	INSERTED.[IsActive],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[IsUseForALLDevice]
into @table
VALUES ( 
	@ProjectID,
	@ProjectName,
	@UserID,
	@Title,
	@Description,
	@IsForever,
	@EndTime,
	@IsActive,
	@AddTime,
	@AddUserName,
	@RoomPhoneRelationID,
	@IsUseForALLDevice 
); 

SELECT 
	[ID],
	[ProjectID],
	[ProjectName],
	[UserID],
	[Title],
	[Description],
	[IsForever],
	[EndTime],
	[IsActive],
	[AddTime],
	[AddUserName],
	[RoomPhoneRelationID],
	[IsUseForALLDevice] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@ProjectName", EntityBase.GetDatabaseValue(@projectName)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@IsForever", @isForever));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@RoomPhoneRelationID", EntityBase.GetDatabaseValue(@roomPhoneRelationID)));
			parameters.Add(new SqlParameter("@IsUseForALLDevice", @isUseForALLDevice));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_DoorRemoteUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectID">projectID</param>
		/// <param name="projectName">projectName</param>
		/// <param name="userID">userID</param>
		/// <param name="title">title</param>
		/// <param name="description">description</param>
		/// <param name="isForever">isForever</param>
		/// <param name="endTime">endTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="isUseForALLDevice">isUseForALLDevice</param>
		public static void UpdateMall_DoorRemoteUser(int @iD, int @projectID, string @projectName, int @userID, string @title, string @description, bool @isForever, DateTime @endTime, bool @isActive, DateTime @addTime, string @addUserName, int @roomPhoneRelationID, bool @isUseForALLDevice)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_DoorRemoteUser(@iD, @projectID, @projectName, @userID, @title, @description, @isForever, @endTime, @isActive, @addTime, @addUserName, @roomPhoneRelationID, @isUseForALLDevice, helper);
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
		/// Updates a Mall_DoorRemoteUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectID">projectID</param>
		/// <param name="projectName">projectName</param>
		/// <param name="userID">userID</param>
		/// <param name="title">title</param>
		/// <param name="description">description</param>
		/// <param name="isForever">isForever</param>
		/// <param name="endTime">endTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="isUseForALLDevice">isUseForALLDevice</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_DoorRemoteUser(int @iD, int @projectID, string @projectName, int @userID, string @title, string @description, bool @isForever, DateTime @endTime, bool @isActive, DateTime @addTime, string @addUserName, int @roomPhoneRelationID, bool @isUseForALLDevice, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectID] int,
	[ProjectName] nvarchar(200),
	[UserID] int,
	[Title] nvarchar(200),
	[Description] ntext,
	[IsForever] bit,
	[EndTime] datetime,
	[IsActive] bit,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[RoomPhoneRelationID] int,
	[IsUseForALLDevice] bit
);

UPDATE [dbo].[Mall_DoorRemoteUser] SET 
	[Mall_DoorRemoteUser].[ProjectID] = @ProjectID,
	[Mall_DoorRemoteUser].[ProjectName] = @ProjectName,
	[Mall_DoorRemoteUser].[UserID] = @UserID,
	[Mall_DoorRemoteUser].[Title] = @Title,
	[Mall_DoorRemoteUser].[Description] = @Description,
	[Mall_DoorRemoteUser].[IsForever] = @IsForever,
	[Mall_DoorRemoteUser].[EndTime] = @EndTime,
	[Mall_DoorRemoteUser].[IsActive] = @IsActive,
	[Mall_DoorRemoteUser].[AddTime] = @AddTime,
	[Mall_DoorRemoteUser].[AddUserName] = @AddUserName,
	[Mall_DoorRemoteUser].[RoomPhoneRelationID] = @RoomPhoneRelationID,
	[Mall_DoorRemoteUser].[IsUseForALLDevice] = @IsUseForALLDevice 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[ProjectName],
	INSERTED.[UserID],
	INSERTED.[Title],
	INSERTED.[Description],
	INSERTED.[IsForever],
	INSERTED.[EndTime],
	INSERTED.[IsActive],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[IsUseForALLDevice]
into @table
WHERE 
	[Mall_DoorRemoteUser].[ID] = @ID

SELECT 
	[ID],
	[ProjectID],
	[ProjectName],
	[UserID],
	[Title],
	[Description],
	[IsForever],
	[EndTime],
	[IsActive],
	[AddTime],
	[AddUserName],
	[RoomPhoneRelationID],
	[IsUseForALLDevice] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@ProjectName", EntityBase.GetDatabaseValue(@projectName)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@IsForever", @isForever));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@RoomPhoneRelationID", EntityBase.GetDatabaseValue(@roomPhoneRelationID)));
			parameters.Add(new SqlParameter("@IsUseForALLDevice", @isUseForALLDevice));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_DoorRemoteUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_DoorRemoteUser(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_DoorRemoteUser(@iD, helper);
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
		/// Deletes a Mall_DoorRemoteUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_DoorRemoteUser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_DoorRemoteUser]
WHERE 
	[Mall_DoorRemoteUser].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_DoorRemoteUser object.
		/// </summary>
		/// <returns>The newly created Mall_DoorRemoteUser object.</returns>
		public static Mall_DoorRemoteUser CreateMall_DoorRemoteUser()
		{
			return InitializeNew<Mall_DoorRemoteUser>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_DoorRemoteUser by a Mall_DoorRemoteUser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_DoorRemoteUser</returns>
		public static Mall_DoorRemoteUser GetMall_DoorRemoteUser(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_DoorRemoteUser.SelectFieldList + @"
FROM [dbo].[Mall_DoorRemoteUser] 
WHERE 
	[Mall_DoorRemoteUser].[ID] = @ID " + Mall_DoorRemoteUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_DoorRemoteUser>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_DoorRemoteUser by a Mall_DoorRemoteUser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_DoorRemoteUser</returns>
		public static Mall_DoorRemoteUser GetMall_DoorRemoteUser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_DoorRemoteUser.SelectFieldList + @"
FROM [dbo].[Mall_DoorRemoteUser] 
WHERE 
	[Mall_DoorRemoteUser].[ID] = @ID " + Mall_DoorRemoteUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_DoorRemoteUser>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteUser objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_DoorRemoteUser objects.</returns>
		public static EntityList<Mall_DoorRemoteUser> GetMall_DoorRemoteUsers()
		{
			string commandText = @"
SELECT " + Mall_DoorRemoteUser.SelectFieldList + "FROM [dbo].[Mall_DoorRemoteUser] " + Mall_DoorRemoteUser.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_DoorRemoteUser>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_DoorRemoteUser objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_DoorRemoteUser objects.</returns>
        public static EntityList<Mall_DoorRemoteUser> GetMall_DoorRemoteUsers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorRemoteUser>(SelectFieldList, "FROM [dbo].[Mall_DoorRemoteUser]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_DoorRemoteUser objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_DoorRemoteUser objects.</returns>
        public static EntityList<Mall_DoorRemoteUser> GetMall_DoorRemoteUsers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorRemoteUser>(SelectFieldList, "FROM [dbo].[Mall_DoorRemoteUser]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteUser objects.</returns>
		protected static EntityList<Mall_DoorRemoteUser> GetMall_DoorRemoteUsers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorRemoteUsers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteUser objects.</returns>
		protected static EntityList<Mall_DoorRemoteUser> GetMall_DoorRemoteUsers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorRemoteUsers(string.Empty, where, parameters, Mall_DoorRemoteUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteUser objects.</returns>
		protected static EntityList<Mall_DoorRemoteUser> GetMall_DoorRemoteUsers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorRemoteUsers(prefix, where, parameters, Mall_DoorRemoteUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteUser objects.</returns>
		protected static EntityList<Mall_DoorRemoteUser> GetMall_DoorRemoteUsers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_DoorRemoteUsers(string.Empty, where, parameters, Mall_DoorRemoteUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteUser objects.</returns>
		protected static EntityList<Mall_DoorRemoteUser> GetMall_DoorRemoteUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_DoorRemoteUsers(prefix, where, parameters, Mall_DoorRemoteUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteUser objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteUser objects.</returns>
		protected static EntityList<Mall_DoorRemoteUser> GetMall_DoorRemoteUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_DoorRemoteUser.SelectFieldList + "FROM [dbo].[Mall_DoorRemoteUser] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_DoorRemoteUser>(reader);
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
        protected static EntityList<Mall_DoorRemoteUser> GetMall_DoorRemoteUsers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorRemoteUser>(SelectFieldList, "FROM [dbo].[Mall_DoorRemoteUser] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_DoorRemoteUser objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_DoorRemoteUserCount()
        {
            return GetMall_DoorRemoteUserCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_DoorRemoteUser objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_DoorRemoteUserCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_DoorRemoteUser] " + where;

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
		public static partial class Mall_DoorRemoteUser_Properties
		{
			public const string ID = "ID";
			public const string ProjectID = "ProjectID";
			public const string ProjectName = "ProjectName";
			public const string UserID = "UserID";
			public const string Title = "Title";
			public const string Description = "Description";
			public const string IsForever = "IsForever";
			public const string EndTime = "EndTime";
			public const string IsActive = "IsActive";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string RoomPhoneRelationID = "RoomPhoneRelationID";
			public const string IsUseForALLDevice = "IsUseForALLDevice";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProjectID" , "int:"},
    			 {"ProjectName" , "string:"},
    			 {"UserID" , "int:"},
    			 {"Title" , "string:"},
    			 {"Description" , "string:"},
    			 {"IsForever" , "bool:"},
    			 {"EndTime" , "DateTime:"},
    			 {"IsActive" , "bool:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"RoomPhoneRelationID" , "int:"},
    			 {"IsUseForALLDevice" , "bool:"},
            };
		}
		#endregion
	}
}
