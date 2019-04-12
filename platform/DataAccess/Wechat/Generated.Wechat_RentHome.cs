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
	/// This object represents the properties and methods of a Wechat_RentHome.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_RentHome 
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
		private int _areaID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int AreaID
		{
			[DebuggerStepThrough()]
			get { return this._areaID; }
			set 
			{
				if (this._areaID != value) 
				{
					this._areaID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AreaID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _subways = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Subways
		{
			[DebuggerStepThrough()]
			get { return this._subways; }
			set 
			{
				if (this._subways != value) 
				{
					this._subways = value;
					this.IsDirty = true;	
					OnPropertyChanged("Subways");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _traffics = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Traffics
		{
			[DebuggerStepThrough()]
			get { return this._traffics; }
			set 
			{
				if (this._traffics != value) 
				{
					this._traffics = value;
					this.IsDirty = true;	
					OnPropertyChanged("Traffics");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _homeName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string HomeName
		{
			[DebuggerStepThrough()]
			get { return this._homeName; }
			set 
			{
				if (this._homeName != value) 
				{
					this._homeName = value;
					this.IsDirty = true;	
					OnPropertyChanged("HomeName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _homeLocation = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string HomeLocation
		{
			[DebuggerStepThrough()]
			get { return this._homeLocation; }
			set 
			{
				if (this._homeLocation != value) 
				{
					this._homeLocation = value;
					this.IsDirty = true;	
					OnPropertyChanged("HomeLocation");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _superMarkets = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SuperMarkets
		{
			[DebuggerStepThrough()]
			get { return this._superMarkets; }
			set 
			{
				if (this._superMarkets != value) 
				{
					this._superMarkets = value;
					this.IsDirty = true;	
					OnPropertyChanged("SuperMarkets");
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
		private string _roomOwners = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomOwners
		{
			[DebuggerStepThrough()]
			get { return this._roomOwners; }
			set 
			{
				if (this._roomOwners != value) 
				{
					this._roomOwners = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomOwners");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _publicOwners = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PublicOwners
		{
			[DebuggerStepThrough()]
			get { return this._publicOwners; }
			set 
			{
				if (this._publicOwners != value) 
				{
					this._publicOwners = value;
					this.IsDirty = true;	
					OnPropertyChanged("PublicOwners");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomDescription = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomDescription
		{
			[DebuggerStepThrough()]
			get { return this._roomDescription; }
			set 
			{
				if (this._roomDescription != value) 
				{
					this._roomDescription = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomDescription");
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
		private string _homeType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string HomeType
		{
			[DebuggerStepThrough()]
			get { return this._homeType; }
			set 
			{
				if (this._homeType != value) 
				{
					this._homeType = value;
					this.IsDirty = true;	
					OnPropertyChanged("HomeType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _buildingID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int BuildingID
		{
			[DebuggerStepThrough()]
			get { return this._buildingID; }
			set 
			{
				if (this._buildingID != value) 
				{
					this._buildingID = value;
					this.IsDirty = true;	
					OnPropertyChanged("BuildingID");
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
	[AreaID] int,
	[Subways] nvarchar(500),
	[Traffics] nvarchar(500),
	[HomeName] nvarchar(500),
	[HomeLocation] nvarchar(200),
	[SuperMarkets] nvarchar(500),
	[PhoneNumber] nvarchar(100),
	[RoomOwners] nvarchar(500),
	[PublicOwners] nvarchar(500),
	[RoomDescription] ntext,
	[MapLocation] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200),
	[HomeType] nvarchar(100),
	[BuildingID] int
);

INSERT INTO [dbo].[Wechat_RentHome] (
	[Wechat_RentHome].[AreaID],
	[Wechat_RentHome].[Subways],
	[Wechat_RentHome].[Traffics],
	[Wechat_RentHome].[HomeName],
	[Wechat_RentHome].[HomeLocation],
	[Wechat_RentHome].[SuperMarkets],
	[Wechat_RentHome].[PhoneNumber],
	[Wechat_RentHome].[RoomOwners],
	[Wechat_RentHome].[PublicOwners],
	[Wechat_RentHome].[RoomDescription],
	[Wechat_RentHome].[MapLocation],
	[Wechat_RentHome].[AddTime],
	[Wechat_RentHome].[AddMan],
	[Wechat_RentHome].[HomeType],
	[Wechat_RentHome].[BuildingID]
) 
output 
	INSERTED.[ID],
	INSERTED.[AreaID],
	INSERTED.[Subways],
	INSERTED.[Traffics],
	INSERTED.[HomeName],
	INSERTED.[HomeLocation],
	INSERTED.[SuperMarkets],
	INSERTED.[PhoneNumber],
	INSERTED.[RoomOwners],
	INSERTED.[PublicOwners],
	INSERTED.[RoomDescription],
	INSERTED.[MapLocation],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[HomeType],
	INSERTED.[BuildingID]
into @table
VALUES ( 
	@AreaID,
	@Subways,
	@Traffics,
	@HomeName,
	@HomeLocation,
	@SuperMarkets,
	@PhoneNumber,
	@RoomOwners,
	@PublicOwners,
	@RoomDescription,
	@MapLocation,
	@AddTime,
	@AddMan,
	@HomeType,
	@BuildingID 
); 

SELECT 
	[ID],
	[AreaID],
	[Subways],
	[Traffics],
	[HomeName],
	[HomeLocation],
	[SuperMarkets],
	[PhoneNumber],
	[RoomOwners],
	[PublicOwners],
	[RoomDescription],
	[MapLocation],
	[AddTime],
	[AddMan],
	[HomeType],
	[BuildingID] 
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
	[AreaID] int,
	[Subways] nvarchar(500),
	[Traffics] nvarchar(500),
	[HomeName] nvarchar(500),
	[HomeLocation] nvarchar(200),
	[SuperMarkets] nvarchar(500),
	[PhoneNumber] nvarchar(100),
	[RoomOwners] nvarchar(500),
	[PublicOwners] nvarchar(500),
	[RoomDescription] ntext,
	[MapLocation] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200),
	[HomeType] nvarchar(100),
	[BuildingID] int
);

UPDATE [dbo].[Wechat_RentHome] SET 
	[Wechat_RentHome].[AreaID] = @AreaID,
	[Wechat_RentHome].[Subways] = @Subways,
	[Wechat_RentHome].[Traffics] = @Traffics,
	[Wechat_RentHome].[HomeName] = @HomeName,
	[Wechat_RentHome].[HomeLocation] = @HomeLocation,
	[Wechat_RentHome].[SuperMarkets] = @SuperMarkets,
	[Wechat_RentHome].[PhoneNumber] = @PhoneNumber,
	[Wechat_RentHome].[RoomOwners] = @RoomOwners,
	[Wechat_RentHome].[PublicOwners] = @PublicOwners,
	[Wechat_RentHome].[RoomDescription] = @RoomDescription,
	[Wechat_RentHome].[MapLocation] = @MapLocation,
	[Wechat_RentHome].[AddTime] = @AddTime,
	[Wechat_RentHome].[AddMan] = @AddMan,
	[Wechat_RentHome].[HomeType] = @HomeType,
	[Wechat_RentHome].[BuildingID] = @BuildingID 
output 
	INSERTED.[ID],
	INSERTED.[AreaID],
	INSERTED.[Subways],
	INSERTED.[Traffics],
	INSERTED.[HomeName],
	INSERTED.[HomeLocation],
	INSERTED.[SuperMarkets],
	INSERTED.[PhoneNumber],
	INSERTED.[RoomOwners],
	INSERTED.[PublicOwners],
	INSERTED.[RoomDescription],
	INSERTED.[MapLocation],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[HomeType],
	INSERTED.[BuildingID]
into @table
WHERE 
	[Wechat_RentHome].[ID] = @ID

SELECT 
	[ID],
	[AreaID],
	[Subways],
	[Traffics],
	[HomeName],
	[HomeLocation],
	[SuperMarkets],
	[PhoneNumber],
	[RoomOwners],
	[PublicOwners],
	[RoomDescription],
	[MapLocation],
	[AddTime],
	[AddMan],
	[HomeType],
	[BuildingID] 
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
DELETE FROM [dbo].[Wechat_RentHome]
WHERE 
	[Wechat_RentHome].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_RentHome() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_RentHome(this.ID));
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
	[Wechat_RentHome].[ID],
	[Wechat_RentHome].[AreaID],
	[Wechat_RentHome].[Subways],
	[Wechat_RentHome].[Traffics],
	[Wechat_RentHome].[HomeName],
	[Wechat_RentHome].[HomeLocation],
	[Wechat_RentHome].[SuperMarkets],
	[Wechat_RentHome].[PhoneNumber],
	[Wechat_RentHome].[RoomOwners],
	[Wechat_RentHome].[PublicOwners],
	[Wechat_RentHome].[RoomDescription],
	[Wechat_RentHome].[MapLocation],
	[Wechat_RentHome].[AddTime],
	[Wechat_RentHome].[AddMan],
	[Wechat_RentHome].[HomeType],
	[Wechat_RentHome].[BuildingID]
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
                return "Wechat_RentHome";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_RentHome into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="areaID">areaID</param>
		/// <param name="subways">subways</param>
		/// <param name="traffics">traffics</param>
		/// <param name="homeName">homeName</param>
		/// <param name="homeLocation">homeLocation</param>
		/// <param name="superMarkets">superMarkets</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="roomOwners">roomOwners</param>
		/// <param name="publicOwners">publicOwners</param>
		/// <param name="roomDescription">roomDescription</param>
		/// <param name="mapLocation">mapLocation</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="homeType">homeType</param>
		/// <param name="buildingID">buildingID</param>
		public static void InsertWechat_RentHome(int @areaID, string @subways, string @traffics, string @homeName, string @homeLocation, string @superMarkets, string @phoneNumber, string @roomOwners, string @publicOwners, string @roomDescription, string @mapLocation, DateTime @addTime, string @addMan, string @homeType, int @buildingID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_RentHome(@areaID, @subways, @traffics, @homeName, @homeLocation, @superMarkets, @phoneNumber, @roomOwners, @publicOwners, @roomDescription, @mapLocation, @addTime, @addMan, @homeType, @buildingID, helper);
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
		/// Insert a Wechat_RentHome into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="areaID">areaID</param>
		/// <param name="subways">subways</param>
		/// <param name="traffics">traffics</param>
		/// <param name="homeName">homeName</param>
		/// <param name="homeLocation">homeLocation</param>
		/// <param name="superMarkets">superMarkets</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="roomOwners">roomOwners</param>
		/// <param name="publicOwners">publicOwners</param>
		/// <param name="roomDescription">roomDescription</param>
		/// <param name="mapLocation">mapLocation</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="homeType">homeType</param>
		/// <param name="buildingID">buildingID</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_RentHome(int @areaID, string @subways, string @traffics, string @homeName, string @homeLocation, string @superMarkets, string @phoneNumber, string @roomOwners, string @publicOwners, string @roomDescription, string @mapLocation, DateTime @addTime, string @addMan, string @homeType, int @buildingID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AreaID] int,
	[Subways] nvarchar(500),
	[Traffics] nvarchar(500),
	[HomeName] nvarchar(500),
	[HomeLocation] nvarchar(200),
	[SuperMarkets] nvarchar(500),
	[PhoneNumber] nvarchar(100),
	[RoomOwners] nvarchar(500),
	[PublicOwners] nvarchar(500),
	[RoomDescription] ntext,
	[MapLocation] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200),
	[HomeType] nvarchar(100),
	[BuildingID] int
);

INSERT INTO [dbo].[Wechat_RentHome] (
	[Wechat_RentHome].[AreaID],
	[Wechat_RentHome].[Subways],
	[Wechat_RentHome].[Traffics],
	[Wechat_RentHome].[HomeName],
	[Wechat_RentHome].[HomeLocation],
	[Wechat_RentHome].[SuperMarkets],
	[Wechat_RentHome].[PhoneNumber],
	[Wechat_RentHome].[RoomOwners],
	[Wechat_RentHome].[PublicOwners],
	[Wechat_RentHome].[RoomDescription],
	[Wechat_RentHome].[MapLocation],
	[Wechat_RentHome].[AddTime],
	[Wechat_RentHome].[AddMan],
	[Wechat_RentHome].[HomeType],
	[Wechat_RentHome].[BuildingID]
) 
output 
	INSERTED.[ID],
	INSERTED.[AreaID],
	INSERTED.[Subways],
	INSERTED.[Traffics],
	INSERTED.[HomeName],
	INSERTED.[HomeLocation],
	INSERTED.[SuperMarkets],
	INSERTED.[PhoneNumber],
	INSERTED.[RoomOwners],
	INSERTED.[PublicOwners],
	INSERTED.[RoomDescription],
	INSERTED.[MapLocation],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[HomeType],
	INSERTED.[BuildingID]
into @table
VALUES ( 
	@AreaID,
	@Subways,
	@Traffics,
	@HomeName,
	@HomeLocation,
	@SuperMarkets,
	@PhoneNumber,
	@RoomOwners,
	@PublicOwners,
	@RoomDescription,
	@MapLocation,
	@AddTime,
	@AddMan,
	@HomeType,
	@BuildingID 
); 

SELECT 
	[ID],
	[AreaID],
	[Subways],
	[Traffics],
	[HomeName],
	[HomeLocation],
	[SuperMarkets],
	[PhoneNumber],
	[RoomOwners],
	[PublicOwners],
	[RoomDescription],
	[MapLocation],
	[AddTime],
	[AddMan],
	[HomeType],
	[BuildingID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@AreaID", EntityBase.GetDatabaseValue(@areaID)));
			parameters.Add(new SqlParameter("@Subways", EntityBase.GetDatabaseValue(@subways)));
			parameters.Add(new SqlParameter("@Traffics", EntityBase.GetDatabaseValue(@traffics)));
			parameters.Add(new SqlParameter("@HomeName", EntityBase.GetDatabaseValue(@homeName)));
			parameters.Add(new SqlParameter("@HomeLocation", EntityBase.GetDatabaseValue(@homeLocation)));
			parameters.Add(new SqlParameter("@SuperMarkets", EntityBase.GetDatabaseValue(@superMarkets)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@RoomOwners", EntityBase.GetDatabaseValue(@roomOwners)));
			parameters.Add(new SqlParameter("@PublicOwners", EntityBase.GetDatabaseValue(@publicOwners)));
			parameters.Add(new SqlParameter("@RoomDescription", EntityBase.GetDatabaseValue(@roomDescription)));
			parameters.Add(new SqlParameter("@MapLocation", EntityBase.GetDatabaseValue(@mapLocation)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@HomeType", EntityBase.GetDatabaseValue(@homeType)));
			parameters.Add(new SqlParameter("@BuildingID", EntityBase.GetDatabaseValue(@buildingID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_RentHome into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="areaID">areaID</param>
		/// <param name="subways">subways</param>
		/// <param name="traffics">traffics</param>
		/// <param name="homeName">homeName</param>
		/// <param name="homeLocation">homeLocation</param>
		/// <param name="superMarkets">superMarkets</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="roomOwners">roomOwners</param>
		/// <param name="publicOwners">publicOwners</param>
		/// <param name="roomDescription">roomDescription</param>
		/// <param name="mapLocation">mapLocation</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="homeType">homeType</param>
		/// <param name="buildingID">buildingID</param>
		public static void UpdateWechat_RentHome(int @iD, int @areaID, string @subways, string @traffics, string @homeName, string @homeLocation, string @superMarkets, string @phoneNumber, string @roomOwners, string @publicOwners, string @roomDescription, string @mapLocation, DateTime @addTime, string @addMan, string @homeType, int @buildingID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_RentHome(@iD, @areaID, @subways, @traffics, @homeName, @homeLocation, @superMarkets, @phoneNumber, @roomOwners, @publicOwners, @roomDescription, @mapLocation, @addTime, @addMan, @homeType, @buildingID, helper);
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
		/// Updates a Wechat_RentHome into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="areaID">areaID</param>
		/// <param name="subways">subways</param>
		/// <param name="traffics">traffics</param>
		/// <param name="homeName">homeName</param>
		/// <param name="homeLocation">homeLocation</param>
		/// <param name="superMarkets">superMarkets</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="roomOwners">roomOwners</param>
		/// <param name="publicOwners">publicOwners</param>
		/// <param name="roomDescription">roomDescription</param>
		/// <param name="mapLocation">mapLocation</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="homeType">homeType</param>
		/// <param name="buildingID">buildingID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_RentHome(int @iD, int @areaID, string @subways, string @traffics, string @homeName, string @homeLocation, string @superMarkets, string @phoneNumber, string @roomOwners, string @publicOwners, string @roomDescription, string @mapLocation, DateTime @addTime, string @addMan, string @homeType, int @buildingID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AreaID] int,
	[Subways] nvarchar(500),
	[Traffics] nvarchar(500),
	[HomeName] nvarchar(500),
	[HomeLocation] nvarchar(200),
	[SuperMarkets] nvarchar(500),
	[PhoneNumber] nvarchar(100),
	[RoomOwners] nvarchar(500),
	[PublicOwners] nvarchar(500),
	[RoomDescription] ntext,
	[MapLocation] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200),
	[HomeType] nvarchar(100),
	[BuildingID] int
);

UPDATE [dbo].[Wechat_RentHome] SET 
	[Wechat_RentHome].[AreaID] = @AreaID,
	[Wechat_RentHome].[Subways] = @Subways,
	[Wechat_RentHome].[Traffics] = @Traffics,
	[Wechat_RentHome].[HomeName] = @HomeName,
	[Wechat_RentHome].[HomeLocation] = @HomeLocation,
	[Wechat_RentHome].[SuperMarkets] = @SuperMarkets,
	[Wechat_RentHome].[PhoneNumber] = @PhoneNumber,
	[Wechat_RentHome].[RoomOwners] = @RoomOwners,
	[Wechat_RentHome].[PublicOwners] = @PublicOwners,
	[Wechat_RentHome].[RoomDescription] = @RoomDescription,
	[Wechat_RentHome].[MapLocation] = @MapLocation,
	[Wechat_RentHome].[AddTime] = @AddTime,
	[Wechat_RentHome].[AddMan] = @AddMan,
	[Wechat_RentHome].[HomeType] = @HomeType,
	[Wechat_RentHome].[BuildingID] = @BuildingID 
output 
	INSERTED.[ID],
	INSERTED.[AreaID],
	INSERTED.[Subways],
	INSERTED.[Traffics],
	INSERTED.[HomeName],
	INSERTED.[HomeLocation],
	INSERTED.[SuperMarkets],
	INSERTED.[PhoneNumber],
	INSERTED.[RoomOwners],
	INSERTED.[PublicOwners],
	INSERTED.[RoomDescription],
	INSERTED.[MapLocation],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[HomeType],
	INSERTED.[BuildingID]
into @table
WHERE 
	[Wechat_RentHome].[ID] = @ID

SELECT 
	[ID],
	[AreaID],
	[Subways],
	[Traffics],
	[HomeName],
	[HomeLocation],
	[SuperMarkets],
	[PhoneNumber],
	[RoomOwners],
	[PublicOwners],
	[RoomDescription],
	[MapLocation],
	[AddTime],
	[AddMan],
	[HomeType],
	[BuildingID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@AreaID", EntityBase.GetDatabaseValue(@areaID)));
			parameters.Add(new SqlParameter("@Subways", EntityBase.GetDatabaseValue(@subways)));
			parameters.Add(new SqlParameter("@Traffics", EntityBase.GetDatabaseValue(@traffics)));
			parameters.Add(new SqlParameter("@HomeName", EntityBase.GetDatabaseValue(@homeName)));
			parameters.Add(new SqlParameter("@HomeLocation", EntityBase.GetDatabaseValue(@homeLocation)));
			parameters.Add(new SqlParameter("@SuperMarkets", EntityBase.GetDatabaseValue(@superMarkets)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@RoomOwners", EntityBase.GetDatabaseValue(@roomOwners)));
			parameters.Add(new SqlParameter("@PublicOwners", EntityBase.GetDatabaseValue(@publicOwners)));
			parameters.Add(new SqlParameter("@RoomDescription", EntityBase.GetDatabaseValue(@roomDescription)));
			parameters.Add(new SqlParameter("@MapLocation", EntityBase.GetDatabaseValue(@mapLocation)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@HomeType", EntityBase.GetDatabaseValue(@homeType)));
			parameters.Add(new SqlParameter("@BuildingID", EntityBase.GetDatabaseValue(@buildingID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_RentHome from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_RentHome(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_RentHome(@iD, helper);
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
		/// Deletes a Wechat_RentHome from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_RentHome(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_RentHome]
WHERE 
	[Wechat_RentHome].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_RentHome object.
		/// </summary>
		/// <returns>The newly created Wechat_RentHome object.</returns>
		public static Wechat_RentHome CreateWechat_RentHome()
		{
			return InitializeNew<Wechat_RentHome>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_RentHome by a Wechat_RentHome's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_RentHome</returns>
		public static Wechat_RentHome GetWechat_RentHome(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_RentHome.SelectFieldList + @"
FROM [dbo].[Wechat_RentHome] 
WHERE 
	[Wechat_RentHome].[ID] = @ID " + Wechat_RentHome.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_RentHome>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_RentHome by a Wechat_RentHome's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_RentHome</returns>
		public static Wechat_RentHome GetWechat_RentHome(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_RentHome.SelectFieldList + @"
FROM [dbo].[Wechat_RentHome] 
WHERE 
	[Wechat_RentHome].[ID] = @ID " + Wechat_RentHome.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_RentHome>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentHome objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_RentHome objects.</returns>
		public static EntityList<Wechat_RentHome> GetWechat_RentHomes()
		{
			string commandText = @"
SELECT " + Wechat_RentHome.SelectFieldList + "FROM [dbo].[Wechat_RentHome] " + Wechat_RentHome.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_RentHome>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_RentHome objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_RentHome objects.</returns>
        public static EntityList<Wechat_RentHome> GetWechat_RentHomes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_RentHome>(SelectFieldList, "FROM [dbo].[Wechat_RentHome]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_RentHome objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_RentHome objects.</returns>
        public static EntityList<Wechat_RentHome> GetWechat_RentHomes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_RentHome>(SelectFieldList, "FROM [dbo].[Wechat_RentHome]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_RentHome objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_RentHome objects.</returns>
		protected static EntityList<Wechat_RentHome> GetWechat_RentHomes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_RentHomes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentHome objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentHome objects.</returns>
		protected static EntityList<Wechat_RentHome> GetWechat_RentHomes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_RentHomes(string.Empty, where, parameters, Wechat_RentHome.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentHome objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentHome objects.</returns>
		protected static EntityList<Wechat_RentHome> GetWechat_RentHomes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_RentHomes(prefix, where, parameters, Wechat_RentHome.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentHome objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentHome objects.</returns>
		protected static EntityList<Wechat_RentHome> GetWechat_RentHomes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_RentHomes(string.Empty, where, parameters, Wechat_RentHome.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentHome objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentHome objects.</returns>
		protected static EntityList<Wechat_RentHome> GetWechat_RentHomes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_RentHomes(prefix, where, parameters, Wechat_RentHome.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentHome objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_RentHome objects.</returns>
		protected static EntityList<Wechat_RentHome> GetWechat_RentHomes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_RentHome.SelectFieldList + "FROM [dbo].[Wechat_RentHome] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_RentHome>(reader);
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
        protected static EntityList<Wechat_RentHome> GetWechat_RentHomes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_RentHome>(SelectFieldList, "FROM [dbo].[Wechat_RentHome] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_RentHome objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_RentHomeCount()
        {
            return GetWechat_RentHomeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_RentHome objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_RentHomeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_RentHome] " + where;

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
		public static partial class Wechat_RentHome_Properties
		{
			public const string ID = "ID";
			public const string AreaID = "AreaID";
			public const string Subways = "Subways";
			public const string Traffics = "Traffics";
			public const string HomeName = "HomeName";
			public const string HomeLocation = "HomeLocation";
			public const string SuperMarkets = "SuperMarkets";
			public const string PhoneNumber = "PhoneNumber";
			public const string RoomOwners = "RoomOwners";
			public const string PublicOwners = "PublicOwners";
			public const string RoomDescription = "RoomDescription";
			public const string MapLocation = "MapLocation";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string HomeType = "HomeType";
			public const string BuildingID = "BuildingID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"AreaID" , "int:"},
    			 {"Subways" , "string:"},
    			 {"Traffics" , "string:"},
    			 {"HomeName" , "string:"},
    			 {"HomeLocation" , "string:"},
    			 {"SuperMarkets" , "string:"},
    			 {"PhoneNumber" , "string:"},
    			 {"RoomOwners" , "string:"},
    			 {"PublicOwners" , "string:"},
    			 {"RoomDescription" , "string:"},
    			 {"MapLocation" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"HomeType" , "string:"},
    			 {"BuildingID" , "int:"},
            };
		}
		#endregion
	}
}
