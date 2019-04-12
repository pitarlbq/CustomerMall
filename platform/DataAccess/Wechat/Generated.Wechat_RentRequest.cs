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
	/// This object represents the properties and methods of a Wechat_RentRequest.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_RentRequest 
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
		[DataObjectField(false, false, false)]
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
		private int _buildingID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private string _rentType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RentType
		{
			[DebuggerStepThrough()]
			get { return this._rentType; }
			set 
			{
				if (this._rentType != value) 
				{
					this._rentType = value;
					this.IsDirty = true;	
					OnPropertyChanged("RentType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _buildingProperty = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BuildingProperty
		{
			[DebuggerStepThrough()]
			get { return this._buildingProperty; }
			set 
			{
				if (this._buildingProperty != value) 
				{
					this._buildingProperty = value;
					this.IsDirty = true;	
					OnPropertyChanged("BuildingProperty");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _openID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OpenID
		{
			[DebuggerStepThrough()]
			get { return this._openID; }
			set 
			{
				if (this._openID != value) 
				{
					this._openID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OpenID");
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
	[BuildingID] int,
	[ContactName] nvarchar(100),
	[ContactPhone] nvarchar(50),
	[RentType] nvarchar(50),
	[BuildingProperty] nvarchar(50),
	[OpenID] nvarchar(500),
	[AddTime] datetime,
	[Remark] ntext
);

INSERT INTO [dbo].[Wechat_RentRequest] (
	[Wechat_RentRequest].[AreaID],
	[Wechat_RentRequest].[BuildingID],
	[Wechat_RentRequest].[ContactName],
	[Wechat_RentRequest].[ContactPhone],
	[Wechat_RentRequest].[RentType],
	[Wechat_RentRequest].[BuildingProperty],
	[Wechat_RentRequest].[OpenID],
	[Wechat_RentRequest].[AddTime],
	[Wechat_RentRequest].[Remark]
) 
output 
	INSERTED.[ID],
	INSERTED.[AreaID],
	INSERTED.[BuildingID],
	INSERTED.[ContactName],
	INSERTED.[ContactPhone],
	INSERTED.[RentType],
	INSERTED.[BuildingProperty],
	INSERTED.[OpenID],
	INSERTED.[AddTime],
	INSERTED.[Remark]
into @table
VALUES ( 
	@AreaID,
	@BuildingID,
	@ContactName,
	@ContactPhone,
	@RentType,
	@BuildingProperty,
	@OpenID,
	@AddTime,
	@Remark 
); 

SELECT 
	[ID],
	[AreaID],
	[BuildingID],
	[ContactName],
	[ContactPhone],
	[RentType],
	[BuildingProperty],
	[OpenID],
	[AddTime],
	[Remark] 
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
	[BuildingID] int,
	[ContactName] nvarchar(100),
	[ContactPhone] nvarchar(50),
	[RentType] nvarchar(50),
	[BuildingProperty] nvarchar(50),
	[OpenID] nvarchar(500),
	[AddTime] datetime,
	[Remark] ntext
);

UPDATE [dbo].[Wechat_RentRequest] SET 
	[Wechat_RentRequest].[AreaID] = @AreaID,
	[Wechat_RentRequest].[BuildingID] = @BuildingID,
	[Wechat_RentRequest].[ContactName] = @ContactName,
	[Wechat_RentRequest].[ContactPhone] = @ContactPhone,
	[Wechat_RentRequest].[RentType] = @RentType,
	[Wechat_RentRequest].[BuildingProperty] = @BuildingProperty,
	[Wechat_RentRequest].[OpenID] = @OpenID,
	[Wechat_RentRequest].[AddTime] = @AddTime,
	[Wechat_RentRequest].[Remark] = @Remark 
output 
	INSERTED.[ID],
	INSERTED.[AreaID],
	INSERTED.[BuildingID],
	INSERTED.[ContactName],
	INSERTED.[ContactPhone],
	INSERTED.[RentType],
	INSERTED.[BuildingProperty],
	INSERTED.[OpenID],
	INSERTED.[AddTime],
	INSERTED.[Remark]
into @table
WHERE 
	[Wechat_RentRequest].[ID] = @ID

SELECT 
	[ID],
	[AreaID],
	[BuildingID],
	[ContactName],
	[ContactPhone],
	[RentType],
	[BuildingProperty],
	[OpenID],
	[AddTime],
	[Remark] 
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
DELETE FROM [dbo].[Wechat_RentRequest]
WHERE 
	[Wechat_RentRequest].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_RentRequest() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_RentRequest(this.ID));
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
	[Wechat_RentRequest].[ID],
	[Wechat_RentRequest].[AreaID],
	[Wechat_RentRequest].[BuildingID],
	[Wechat_RentRequest].[ContactName],
	[Wechat_RentRequest].[ContactPhone],
	[Wechat_RentRequest].[RentType],
	[Wechat_RentRequest].[BuildingProperty],
	[Wechat_RentRequest].[OpenID],
	[Wechat_RentRequest].[AddTime],
	[Wechat_RentRequest].[Remark]
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
                return "Wechat_RentRequest";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_RentRequest into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="areaID">areaID</param>
		/// <param name="buildingID">buildingID</param>
		/// <param name="contactName">contactName</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="rentType">rentType</param>
		/// <param name="buildingProperty">buildingProperty</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="remark">remark</param>
		public static void InsertWechat_RentRequest(int @areaID, int @buildingID, string @contactName, string @contactPhone, string @rentType, string @buildingProperty, string @openID, DateTime @addTime, string @remark)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_RentRequest(@areaID, @buildingID, @contactName, @contactPhone, @rentType, @buildingProperty, @openID, @addTime, @remark, helper);
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
		/// Insert a Wechat_RentRequest into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="areaID">areaID</param>
		/// <param name="buildingID">buildingID</param>
		/// <param name="contactName">contactName</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="rentType">rentType</param>
		/// <param name="buildingProperty">buildingProperty</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="remark">remark</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_RentRequest(int @areaID, int @buildingID, string @contactName, string @contactPhone, string @rentType, string @buildingProperty, string @openID, DateTime @addTime, string @remark, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AreaID] int,
	[BuildingID] int,
	[ContactName] nvarchar(100),
	[ContactPhone] nvarchar(50),
	[RentType] nvarchar(50),
	[BuildingProperty] nvarchar(50),
	[OpenID] nvarchar(500),
	[AddTime] datetime,
	[Remark] ntext
);

INSERT INTO [dbo].[Wechat_RentRequest] (
	[Wechat_RentRequest].[AreaID],
	[Wechat_RentRequest].[BuildingID],
	[Wechat_RentRequest].[ContactName],
	[Wechat_RentRequest].[ContactPhone],
	[Wechat_RentRequest].[RentType],
	[Wechat_RentRequest].[BuildingProperty],
	[Wechat_RentRequest].[OpenID],
	[Wechat_RentRequest].[AddTime],
	[Wechat_RentRequest].[Remark]
) 
output 
	INSERTED.[ID],
	INSERTED.[AreaID],
	INSERTED.[BuildingID],
	INSERTED.[ContactName],
	INSERTED.[ContactPhone],
	INSERTED.[RentType],
	INSERTED.[BuildingProperty],
	INSERTED.[OpenID],
	INSERTED.[AddTime],
	INSERTED.[Remark]
into @table
VALUES ( 
	@AreaID,
	@BuildingID,
	@ContactName,
	@ContactPhone,
	@RentType,
	@BuildingProperty,
	@OpenID,
	@AddTime,
	@Remark 
); 

SELECT 
	[ID],
	[AreaID],
	[BuildingID],
	[ContactName],
	[ContactPhone],
	[RentType],
	[BuildingProperty],
	[OpenID],
	[AddTime],
	[Remark] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@AreaID", EntityBase.GetDatabaseValue(@areaID)));
			parameters.Add(new SqlParameter("@BuildingID", EntityBase.GetDatabaseValue(@buildingID)));
			parameters.Add(new SqlParameter("@ContactName", EntityBase.GetDatabaseValue(@contactName)));
			parameters.Add(new SqlParameter("@ContactPhone", EntityBase.GetDatabaseValue(@contactPhone)));
			parameters.Add(new SqlParameter("@RentType", EntityBase.GetDatabaseValue(@rentType)));
			parameters.Add(new SqlParameter("@BuildingProperty", EntityBase.GetDatabaseValue(@buildingProperty)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_RentRequest into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="areaID">areaID</param>
		/// <param name="buildingID">buildingID</param>
		/// <param name="contactName">contactName</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="rentType">rentType</param>
		/// <param name="buildingProperty">buildingProperty</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="remark">remark</param>
		public static void UpdateWechat_RentRequest(int @iD, int @areaID, int @buildingID, string @contactName, string @contactPhone, string @rentType, string @buildingProperty, string @openID, DateTime @addTime, string @remark)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_RentRequest(@iD, @areaID, @buildingID, @contactName, @contactPhone, @rentType, @buildingProperty, @openID, @addTime, @remark, helper);
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
		/// Updates a Wechat_RentRequest into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="areaID">areaID</param>
		/// <param name="buildingID">buildingID</param>
		/// <param name="contactName">contactName</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="rentType">rentType</param>
		/// <param name="buildingProperty">buildingProperty</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="remark">remark</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_RentRequest(int @iD, int @areaID, int @buildingID, string @contactName, string @contactPhone, string @rentType, string @buildingProperty, string @openID, DateTime @addTime, string @remark, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AreaID] int,
	[BuildingID] int,
	[ContactName] nvarchar(100),
	[ContactPhone] nvarchar(50),
	[RentType] nvarchar(50),
	[BuildingProperty] nvarchar(50),
	[OpenID] nvarchar(500),
	[AddTime] datetime,
	[Remark] ntext
);

UPDATE [dbo].[Wechat_RentRequest] SET 
	[Wechat_RentRequest].[AreaID] = @AreaID,
	[Wechat_RentRequest].[BuildingID] = @BuildingID,
	[Wechat_RentRequest].[ContactName] = @ContactName,
	[Wechat_RentRequest].[ContactPhone] = @ContactPhone,
	[Wechat_RentRequest].[RentType] = @RentType,
	[Wechat_RentRequest].[BuildingProperty] = @BuildingProperty,
	[Wechat_RentRequest].[OpenID] = @OpenID,
	[Wechat_RentRequest].[AddTime] = @AddTime,
	[Wechat_RentRequest].[Remark] = @Remark 
output 
	INSERTED.[ID],
	INSERTED.[AreaID],
	INSERTED.[BuildingID],
	INSERTED.[ContactName],
	INSERTED.[ContactPhone],
	INSERTED.[RentType],
	INSERTED.[BuildingProperty],
	INSERTED.[OpenID],
	INSERTED.[AddTime],
	INSERTED.[Remark]
into @table
WHERE 
	[Wechat_RentRequest].[ID] = @ID

SELECT 
	[ID],
	[AreaID],
	[BuildingID],
	[ContactName],
	[ContactPhone],
	[RentType],
	[BuildingProperty],
	[OpenID],
	[AddTime],
	[Remark] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@AreaID", EntityBase.GetDatabaseValue(@areaID)));
			parameters.Add(new SqlParameter("@BuildingID", EntityBase.GetDatabaseValue(@buildingID)));
			parameters.Add(new SqlParameter("@ContactName", EntityBase.GetDatabaseValue(@contactName)));
			parameters.Add(new SqlParameter("@ContactPhone", EntityBase.GetDatabaseValue(@contactPhone)));
			parameters.Add(new SqlParameter("@RentType", EntityBase.GetDatabaseValue(@rentType)));
			parameters.Add(new SqlParameter("@BuildingProperty", EntityBase.GetDatabaseValue(@buildingProperty)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_RentRequest from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_RentRequest(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_RentRequest(@iD, helper);
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
		/// Deletes a Wechat_RentRequest from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_RentRequest(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_RentRequest]
WHERE 
	[Wechat_RentRequest].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_RentRequest object.
		/// </summary>
		/// <returns>The newly created Wechat_RentRequest object.</returns>
		public static Wechat_RentRequest CreateWechat_RentRequest()
		{
			return InitializeNew<Wechat_RentRequest>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_RentRequest by a Wechat_RentRequest's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_RentRequest</returns>
		public static Wechat_RentRequest GetWechat_RentRequest(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_RentRequest.SelectFieldList + @"
FROM [dbo].[Wechat_RentRequest] 
WHERE 
	[Wechat_RentRequest].[ID] = @ID " + Wechat_RentRequest.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_RentRequest>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_RentRequest by a Wechat_RentRequest's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_RentRequest</returns>
		public static Wechat_RentRequest GetWechat_RentRequest(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_RentRequest.SelectFieldList + @"
FROM [dbo].[Wechat_RentRequest] 
WHERE 
	[Wechat_RentRequest].[ID] = @ID " + Wechat_RentRequest.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_RentRequest>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentRequest objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_RentRequest objects.</returns>
		public static EntityList<Wechat_RentRequest> GetWechat_RentRequests()
		{
			string commandText = @"
SELECT " + Wechat_RentRequest.SelectFieldList + "FROM [dbo].[Wechat_RentRequest] " + Wechat_RentRequest.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_RentRequest>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_RentRequest objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_RentRequest objects.</returns>
        public static EntityList<Wechat_RentRequest> GetWechat_RentRequests(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_RentRequest>(SelectFieldList, "FROM [dbo].[Wechat_RentRequest]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_RentRequest objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_RentRequest objects.</returns>
        public static EntityList<Wechat_RentRequest> GetWechat_RentRequests(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_RentRequest>(SelectFieldList, "FROM [dbo].[Wechat_RentRequest]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_RentRequest objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_RentRequest objects.</returns>
		protected static EntityList<Wechat_RentRequest> GetWechat_RentRequests(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_RentRequests(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentRequest objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentRequest objects.</returns>
		protected static EntityList<Wechat_RentRequest> GetWechat_RentRequests(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_RentRequests(string.Empty, where, parameters, Wechat_RentRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentRequest objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentRequest objects.</returns>
		protected static EntityList<Wechat_RentRequest> GetWechat_RentRequests(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_RentRequests(prefix, where, parameters, Wechat_RentRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentRequest objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentRequest objects.</returns>
		protected static EntityList<Wechat_RentRequest> GetWechat_RentRequests(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_RentRequests(string.Empty, where, parameters, Wechat_RentRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentRequest objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentRequest objects.</returns>
		protected static EntityList<Wechat_RentRequest> GetWechat_RentRequests(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_RentRequests(prefix, where, parameters, Wechat_RentRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentRequest objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_RentRequest objects.</returns>
		protected static EntityList<Wechat_RentRequest> GetWechat_RentRequests(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_RentRequest.SelectFieldList + "FROM [dbo].[Wechat_RentRequest] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_RentRequest>(reader);
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
        protected static EntityList<Wechat_RentRequest> GetWechat_RentRequests(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_RentRequest>(SelectFieldList, "FROM [dbo].[Wechat_RentRequest] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_RentRequest objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_RentRequestCount()
        {
            return GetWechat_RentRequestCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_RentRequest objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_RentRequestCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_RentRequest] " + where;

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
		public static partial class Wechat_RentRequest_Properties
		{
			public const string ID = "ID";
			public const string AreaID = "AreaID";
			public const string BuildingID = "BuildingID";
			public const string ContactName = "ContactName";
			public const string ContactPhone = "ContactPhone";
			public const string RentType = "RentType";
			public const string BuildingProperty = "BuildingProperty";
			public const string OpenID = "OpenID";
			public const string AddTime = "AddTime";
			public const string Remark = "Remark";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"AreaID" , "int:"},
    			 {"BuildingID" , "int:"},
    			 {"ContactName" , "string:"},
    			 {"ContactPhone" , "string:"},
    			 {"RentType" , "string:"},
    			 {"BuildingProperty" , "string:"},
    			 {"OpenID" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"Remark" , "string:"},
            };
		}
		#endregion
	}
}
