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
	/// This object represents the properties and methods of a Contract_Room.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Contract_Room 
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
		private string _rentName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RentName
		{
			[DebuggerStepThrough()]
			get { return this._rentName; }
			set 
			{
				if (this._rentName != value) 
				{
					this._rentName = value;
					this.IsDirty = true;	
					OnPropertyChanged("RentName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomLocation = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomLocation
		{
			[DebuggerStepThrough()]
			get { return this._roomLocation; }
			set 
			{
				if (this._roomLocation != value) 
				{
					this._roomLocation = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomLocation");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _roomArea = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RoomArea
		{
			[DebuggerStepThrough()]
			get { return this._roomArea; }
			set 
			{
				if (this._roomArea != value) 
				{
					this._roomArea = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomArea");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _gUID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string GUID
		{
			[DebuggerStepThrough()]
			get { return this._gUID; }
			set 
			{
				if (this._gUID != value) 
				{
					this._gUID = value;
					this.IsDirty = true;	
					OnPropertyChanged("GUID");
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
	[RoomID] int,
	[RentName] nvarchar(50),
	[RoomLocation] nvarchar(500),
	[RoomArea] decimal(18, 2),
	[GUID] nvarchar(500),
	[ChargeID] int
);

INSERT INTO [dbo].[Contract_Room] (
	[Contract_Room].[ContractID],
	[Contract_Room].[RoomID],
	[Contract_Room].[RentName],
	[Contract_Room].[RoomLocation],
	[Contract_Room].[RoomArea],
	[Contract_Room].[GUID],
	[Contract_Room].[ChargeID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[RoomID],
	INSERTED.[RentName],
	INSERTED.[RoomLocation],
	INSERTED.[RoomArea],
	INSERTED.[GUID],
	INSERTED.[ChargeID]
into @table
VALUES ( 
	@ContractID,
	@RoomID,
	@RentName,
	@RoomLocation,
	@RoomArea,
	@GUID,
	@ChargeID 
); 

SELECT 
	[ID],
	[ContractID],
	[RoomID],
	[RentName],
	[RoomLocation],
	[RoomArea],
	[GUID],
	[ChargeID] 
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
	[RoomID] int,
	[RentName] nvarchar(50),
	[RoomLocation] nvarchar(500),
	[RoomArea] decimal(18, 2),
	[GUID] nvarchar(500),
	[ChargeID] int
);

UPDATE [dbo].[Contract_Room] SET 
	[Contract_Room].[ContractID] = @ContractID,
	[Contract_Room].[RoomID] = @RoomID,
	[Contract_Room].[RentName] = @RentName,
	[Contract_Room].[RoomLocation] = @RoomLocation,
	[Contract_Room].[RoomArea] = @RoomArea,
	[Contract_Room].[GUID] = @GUID,
	[Contract_Room].[ChargeID] = @ChargeID 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[RoomID],
	INSERTED.[RentName],
	INSERTED.[RoomLocation],
	INSERTED.[RoomArea],
	INSERTED.[GUID],
	INSERTED.[ChargeID]
into @table
WHERE 
	[Contract_Room].[ID] = @ID

SELECT 
	[ID],
	[ContractID],
	[RoomID],
	[RentName],
	[RoomLocation],
	[RoomArea],
	[GUID],
	[ChargeID] 
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
DELETE FROM [dbo].[Contract_Room]
WHERE 
	[Contract_Room].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Contract_Room() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetContract_Room(this.ID));
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
	[Contract_Room].[ID],
	[Contract_Room].[ContractID],
	[Contract_Room].[RoomID],
	[Contract_Room].[RentName],
	[Contract_Room].[RoomLocation],
	[Contract_Room].[RoomArea],
	[Contract_Room].[GUID],
	[Contract_Room].[ChargeID]
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
                return "Contract_Room";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Contract_Room into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractID">contractID</param>
		/// <param name="roomID">roomID</param>
		/// <param name="rentName">rentName</param>
		/// <param name="roomLocation">roomLocation</param>
		/// <param name="roomArea">roomArea</param>
		/// <param name="gUID">gUID</param>
		/// <param name="chargeID">chargeID</param>
		public static void InsertContract_Room(int @contractID, int @roomID, string @rentName, string @roomLocation, decimal @roomArea, string @gUID, int @chargeID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertContract_Room(@contractID, @roomID, @rentName, @roomLocation, @roomArea, @gUID, @chargeID, helper);
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
		/// Insert a Contract_Room into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractID">contractID</param>
		/// <param name="roomID">roomID</param>
		/// <param name="rentName">rentName</param>
		/// <param name="roomLocation">roomLocation</param>
		/// <param name="roomArea">roomArea</param>
		/// <param name="gUID">gUID</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="helper">helper</param>
		internal static void InsertContract_Room(int @contractID, int @roomID, string @rentName, string @roomLocation, decimal @roomArea, string @gUID, int @chargeID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractID] int,
	[RoomID] int,
	[RentName] nvarchar(50),
	[RoomLocation] nvarchar(500),
	[RoomArea] decimal(18, 2),
	[GUID] nvarchar(500),
	[ChargeID] int
);

INSERT INTO [dbo].[Contract_Room] (
	[Contract_Room].[ContractID],
	[Contract_Room].[RoomID],
	[Contract_Room].[RentName],
	[Contract_Room].[RoomLocation],
	[Contract_Room].[RoomArea],
	[Contract_Room].[GUID],
	[Contract_Room].[ChargeID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[RoomID],
	INSERTED.[RentName],
	INSERTED.[RoomLocation],
	INSERTED.[RoomArea],
	INSERTED.[GUID],
	INSERTED.[ChargeID]
into @table
VALUES ( 
	@ContractID,
	@RoomID,
	@RentName,
	@RoomLocation,
	@RoomArea,
	@GUID,
	@ChargeID 
); 

SELECT 
	[ID],
	[ContractID],
	[RoomID],
	[RentName],
	[RoomLocation],
	[RoomArea],
	[GUID],
	[ChargeID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@RentName", EntityBase.GetDatabaseValue(@rentName)));
			parameters.Add(new SqlParameter("@RoomLocation", EntityBase.GetDatabaseValue(@roomLocation)));
			parameters.Add(new SqlParameter("@RoomArea", EntityBase.GetDatabaseValue(@roomArea)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Contract_Room into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractID">contractID</param>
		/// <param name="roomID">roomID</param>
		/// <param name="rentName">rentName</param>
		/// <param name="roomLocation">roomLocation</param>
		/// <param name="roomArea">roomArea</param>
		/// <param name="gUID">gUID</param>
		/// <param name="chargeID">chargeID</param>
		public static void UpdateContract_Room(int @iD, int @contractID, int @roomID, string @rentName, string @roomLocation, decimal @roomArea, string @gUID, int @chargeID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateContract_Room(@iD, @contractID, @roomID, @rentName, @roomLocation, @roomArea, @gUID, @chargeID, helper);
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
		/// Updates a Contract_Room into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractID">contractID</param>
		/// <param name="roomID">roomID</param>
		/// <param name="rentName">rentName</param>
		/// <param name="roomLocation">roomLocation</param>
		/// <param name="roomArea">roomArea</param>
		/// <param name="gUID">gUID</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateContract_Room(int @iD, int @contractID, int @roomID, string @rentName, string @roomLocation, decimal @roomArea, string @gUID, int @chargeID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractID] int,
	[RoomID] int,
	[RentName] nvarchar(50),
	[RoomLocation] nvarchar(500),
	[RoomArea] decimal(18, 2),
	[GUID] nvarchar(500),
	[ChargeID] int
);

UPDATE [dbo].[Contract_Room] SET 
	[Contract_Room].[ContractID] = @ContractID,
	[Contract_Room].[RoomID] = @RoomID,
	[Contract_Room].[RentName] = @RentName,
	[Contract_Room].[RoomLocation] = @RoomLocation,
	[Contract_Room].[RoomArea] = @RoomArea,
	[Contract_Room].[GUID] = @GUID,
	[Contract_Room].[ChargeID] = @ChargeID 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[RoomID],
	INSERTED.[RentName],
	INSERTED.[RoomLocation],
	INSERTED.[RoomArea],
	INSERTED.[GUID],
	INSERTED.[ChargeID]
into @table
WHERE 
	[Contract_Room].[ID] = @ID

SELECT 
	[ID],
	[ContractID],
	[RoomID],
	[RentName],
	[RoomLocation],
	[RoomArea],
	[GUID],
	[ChargeID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@RentName", EntityBase.GetDatabaseValue(@rentName)));
			parameters.Add(new SqlParameter("@RoomLocation", EntityBase.GetDatabaseValue(@roomLocation)));
			parameters.Add(new SqlParameter("@RoomArea", EntityBase.GetDatabaseValue(@roomArea)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Contract_Room from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteContract_Room(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteContract_Room(@iD, helper);
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
		/// Deletes a Contract_Room from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteContract_Room(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Contract_Room]
WHERE 
	[Contract_Room].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Contract_Room object.
		/// </summary>
		/// <returns>The newly created Contract_Room object.</returns>
		public static Contract_Room CreateContract_Room()
		{
			return InitializeNew<Contract_Room>();
		}
		
		/// <summary>
		/// Retrieve information for a Contract_Room by a Contract_Room's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Contract_Room</returns>
		public static Contract_Room GetContract_Room(int @iD)
		{
			string commandText = @"
SELECT 
" + Contract_Room.SelectFieldList + @"
FROM [dbo].[Contract_Room] 
WHERE 
	[Contract_Room].[ID] = @ID " + Contract_Room.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_Room>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Contract_Room by a Contract_Room's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Contract_Room</returns>
		public static Contract_Room GetContract_Room(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Contract_Room.SelectFieldList + @"
FROM [dbo].[Contract_Room] 
WHERE 
	[Contract_Room].[ID] = @ID " + Contract_Room.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_Room>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Contract_Room objects.
		/// </summary>
		/// <returns>The retrieved collection of Contract_Room objects.</returns>
		public static EntityList<Contract_Room> GetContract_Rooms()
		{
			string commandText = @"
SELECT " + Contract_Room.SelectFieldList + "FROM [dbo].[Contract_Room] " + Contract_Room.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Contract_Room>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Contract_Room objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_Room objects.</returns>
        public static EntityList<Contract_Room> GetContract_Rooms(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Room>(SelectFieldList, "FROM [dbo].[Contract_Room]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Contract_Room objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_Room objects.</returns>
        public static EntityList<Contract_Room> GetContract_Rooms(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Room>(SelectFieldList, "FROM [dbo].[Contract_Room]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Contract_Room objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Contract_Room objects.</returns>
		protected static EntityList<Contract_Room> GetContract_Rooms(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Rooms(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Contract_Room objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_Room objects.</returns>
		protected static EntityList<Contract_Room> GetContract_Rooms(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Rooms(string.Empty, where, parameters, Contract_Room.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Room objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_Room objects.</returns>
		protected static EntityList<Contract_Room> GetContract_Rooms(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Rooms(prefix, where, parameters, Contract_Room.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Room objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_Room objects.</returns>
		protected static EntityList<Contract_Room> GetContract_Rooms(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_Rooms(string.Empty, where, parameters, Contract_Room.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Room objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_Room objects.</returns>
		protected static EntityList<Contract_Room> GetContract_Rooms(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_Rooms(prefix, where, parameters, Contract_Room.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Room objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Contract_Room objects.</returns>
		protected static EntityList<Contract_Room> GetContract_Rooms(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Contract_Room.SelectFieldList + "FROM [dbo].[Contract_Room] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Contract_Room>(reader);
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
        protected static EntityList<Contract_Room> GetContract_Rooms(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Room>(SelectFieldList, "FROM [dbo].[Contract_Room] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Contract_Room objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_RoomCount()
        {
            return GetContract_RoomCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Contract_Room objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_RoomCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Contract_Room] " + where;

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
		public static partial class Contract_Room_Properties
		{
			public const string ID = "ID";
			public const string ContractID = "ContractID";
			public const string RoomID = "RoomID";
			public const string RentName = "RentName";
			public const string RoomLocation = "RoomLocation";
			public const string RoomArea = "RoomArea";
			public const string GUID = "GUID";
			public const string ChargeID = "ChargeID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ContractID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"RentName" , "string:"},
    			 {"RoomLocation" , "string:"},
    			 {"RoomArea" , "decimal:"},
    			 {"GUID" , "string:"},
    			 {"ChargeID" , "int:"},
            };
		}
		#endregion
	}
}
