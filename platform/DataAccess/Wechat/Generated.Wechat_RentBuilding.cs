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
	/// This object represents the properties and methods of a Wechat_RentBuilding.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_RentBuilding 
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
		private string _buildingName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BuildingName
		{
			[DebuggerStepThrough()]
			get { return this._buildingName; }
			set 
			{
				if (this._buildingName != value) 
				{
					this._buildingName = value;
					this.IsDirty = true;	
					OnPropertyChanged("BuildingName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _buildingLocation = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BuildingLocation
		{
			[DebuggerStepThrough()]
			get { return this._buildingLocation; }
			set 
			{
				if (this._buildingLocation != value) 
				{
					this._buildingLocation = value;
					this.IsDirty = true;	
					OnPropertyChanged("BuildingLocation");
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
		private string _addUser = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
	[BuildingName] nvarchar(200),
	[BuildingLocation] nvarchar(500),
	[AddTime] datetime,
	[AddUser] nvarchar(50)
);

INSERT INTO [dbo].[Wechat_RentBuilding] (
	[Wechat_RentBuilding].[AreaID],
	[Wechat_RentBuilding].[BuildingName],
	[Wechat_RentBuilding].[BuildingLocation],
	[Wechat_RentBuilding].[AddTime],
	[Wechat_RentBuilding].[AddUser]
) 
output 
	INSERTED.[ID],
	INSERTED.[AreaID],
	INSERTED.[BuildingName],
	INSERTED.[BuildingLocation],
	INSERTED.[AddTime],
	INSERTED.[AddUser]
into @table
VALUES ( 
	@AreaID,
	@BuildingName,
	@BuildingLocation,
	@AddTime,
	@AddUser 
); 

SELECT 
	[ID],
	[AreaID],
	[BuildingName],
	[BuildingLocation],
	[AddTime],
	[AddUser] 
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
	[BuildingName] nvarchar(200),
	[BuildingLocation] nvarchar(500),
	[AddTime] datetime,
	[AddUser] nvarchar(50)
);

UPDATE [dbo].[Wechat_RentBuilding] SET 
	[Wechat_RentBuilding].[AreaID] = @AreaID,
	[Wechat_RentBuilding].[BuildingName] = @BuildingName,
	[Wechat_RentBuilding].[BuildingLocation] = @BuildingLocation,
	[Wechat_RentBuilding].[AddTime] = @AddTime,
	[Wechat_RentBuilding].[AddUser] = @AddUser 
output 
	INSERTED.[ID],
	INSERTED.[AreaID],
	INSERTED.[BuildingName],
	INSERTED.[BuildingLocation],
	INSERTED.[AddTime],
	INSERTED.[AddUser]
into @table
WHERE 
	[Wechat_RentBuilding].[ID] = @ID

SELECT 
	[ID],
	[AreaID],
	[BuildingName],
	[BuildingLocation],
	[AddTime],
	[AddUser] 
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
DELETE FROM [dbo].[Wechat_RentBuilding]
WHERE 
	[Wechat_RentBuilding].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_RentBuilding() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_RentBuilding(this.ID));
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
	[Wechat_RentBuilding].[ID],
	[Wechat_RentBuilding].[AreaID],
	[Wechat_RentBuilding].[BuildingName],
	[Wechat_RentBuilding].[BuildingLocation],
	[Wechat_RentBuilding].[AddTime],
	[Wechat_RentBuilding].[AddUser]
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
                return "Wechat_RentBuilding";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_RentBuilding into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="areaID">areaID</param>
		/// <param name="buildingName">buildingName</param>
		/// <param name="buildingLocation">buildingLocation</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		public static void InsertWechat_RentBuilding(int @areaID, string @buildingName, string @buildingLocation, DateTime @addTime, string @addUser)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_RentBuilding(@areaID, @buildingName, @buildingLocation, @addTime, @addUser, helper);
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
		/// Insert a Wechat_RentBuilding into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="areaID">areaID</param>
		/// <param name="buildingName">buildingName</param>
		/// <param name="buildingLocation">buildingLocation</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_RentBuilding(int @areaID, string @buildingName, string @buildingLocation, DateTime @addTime, string @addUser, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AreaID] int,
	[BuildingName] nvarchar(200),
	[BuildingLocation] nvarchar(500),
	[AddTime] datetime,
	[AddUser] nvarchar(50)
);

INSERT INTO [dbo].[Wechat_RentBuilding] (
	[Wechat_RentBuilding].[AreaID],
	[Wechat_RentBuilding].[BuildingName],
	[Wechat_RentBuilding].[BuildingLocation],
	[Wechat_RentBuilding].[AddTime],
	[Wechat_RentBuilding].[AddUser]
) 
output 
	INSERTED.[ID],
	INSERTED.[AreaID],
	INSERTED.[BuildingName],
	INSERTED.[BuildingLocation],
	INSERTED.[AddTime],
	INSERTED.[AddUser]
into @table
VALUES ( 
	@AreaID,
	@BuildingName,
	@BuildingLocation,
	@AddTime,
	@AddUser 
); 

SELECT 
	[ID],
	[AreaID],
	[BuildingName],
	[BuildingLocation],
	[AddTime],
	[AddUser] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@AreaID", EntityBase.GetDatabaseValue(@areaID)));
			parameters.Add(new SqlParameter("@BuildingName", EntityBase.GetDatabaseValue(@buildingName)));
			parameters.Add(new SqlParameter("@BuildingLocation", EntityBase.GetDatabaseValue(@buildingLocation)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUser", EntityBase.GetDatabaseValue(@addUser)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_RentBuilding into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="areaID">areaID</param>
		/// <param name="buildingName">buildingName</param>
		/// <param name="buildingLocation">buildingLocation</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		public static void UpdateWechat_RentBuilding(int @iD, int @areaID, string @buildingName, string @buildingLocation, DateTime @addTime, string @addUser)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_RentBuilding(@iD, @areaID, @buildingName, @buildingLocation, @addTime, @addUser, helper);
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
		/// Updates a Wechat_RentBuilding into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="areaID">areaID</param>
		/// <param name="buildingName">buildingName</param>
		/// <param name="buildingLocation">buildingLocation</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_RentBuilding(int @iD, int @areaID, string @buildingName, string @buildingLocation, DateTime @addTime, string @addUser, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AreaID] int,
	[BuildingName] nvarchar(200),
	[BuildingLocation] nvarchar(500),
	[AddTime] datetime,
	[AddUser] nvarchar(50)
);

UPDATE [dbo].[Wechat_RentBuilding] SET 
	[Wechat_RentBuilding].[AreaID] = @AreaID,
	[Wechat_RentBuilding].[BuildingName] = @BuildingName,
	[Wechat_RentBuilding].[BuildingLocation] = @BuildingLocation,
	[Wechat_RentBuilding].[AddTime] = @AddTime,
	[Wechat_RentBuilding].[AddUser] = @AddUser 
output 
	INSERTED.[ID],
	INSERTED.[AreaID],
	INSERTED.[BuildingName],
	INSERTED.[BuildingLocation],
	INSERTED.[AddTime],
	INSERTED.[AddUser]
into @table
WHERE 
	[Wechat_RentBuilding].[ID] = @ID

SELECT 
	[ID],
	[AreaID],
	[BuildingName],
	[BuildingLocation],
	[AddTime],
	[AddUser] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@AreaID", EntityBase.GetDatabaseValue(@areaID)));
			parameters.Add(new SqlParameter("@BuildingName", EntityBase.GetDatabaseValue(@buildingName)));
			parameters.Add(new SqlParameter("@BuildingLocation", EntityBase.GetDatabaseValue(@buildingLocation)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUser", EntityBase.GetDatabaseValue(@addUser)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_RentBuilding from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_RentBuilding(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_RentBuilding(@iD, helper);
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
		/// Deletes a Wechat_RentBuilding from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_RentBuilding(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_RentBuilding]
WHERE 
	[Wechat_RentBuilding].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_RentBuilding object.
		/// </summary>
		/// <returns>The newly created Wechat_RentBuilding object.</returns>
		public static Wechat_RentBuilding CreateWechat_RentBuilding()
		{
			return InitializeNew<Wechat_RentBuilding>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_RentBuilding by a Wechat_RentBuilding's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_RentBuilding</returns>
		public static Wechat_RentBuilding GetWechat_RentBuilding(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_RentBuilding.SelectFieldList + @"
FROM [dbo].[Wechat_RentBuilding] 
WHERE 
	[Wechat_RentBuilding].[ID] = @ID " + Wechat_RentBuilding.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_RentBuilding>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_RentBuilding by a Wechat_RentBuilding's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_RentBuilding</returns>
		public static Wechat_RentBuilding GetWechat_RentBuilding(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_RentBuilding.SelectFieldList + @"
FROM [dbo].[Wechat_RentBuilding] 
WHERE 
	[Wechat_RentBuilding].[ID] = @ID " + Wechat_RentBuilding.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_RentBuilding>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentBuilding objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_RentBuilding objects.</returns>
		public static EntityList<Wechat_RentBuilding> GetWechat_RentBuildings()
		{
			string commandText = @"
SELECT " + Wechat_RentBuilding.SelectFieldList + "FROM [dbo].[Wechat_RentBuilding] " + Wechat_RentBuilding.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_RentBuilding>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_RentBuilding objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_RentBuilding objects.</returns>
        public static EntityList<Wechat_RentBuilding> GetWechat_RentBuildings(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_RentBuilding>(SelectFieldList, "FROM [dbo].[Wechat_RentBuilding]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_RentBuilding objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_RentBuilding objects.</returns>
        public static EntityList<Wechat_RentBuilding> GetWechat_RentBuildings(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_RentBuilding>(SelectFieldList, "FROM [dbo].[Wechat_RentBuilding]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_RentBuilding objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_RentBuilding objects.</returns>
		protected static EntityList<Wechat_RentBuilding> GetWechat_RentBuildings(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_RentBuildings(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentBuilding objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentBuilding objects.</returns>
		protected static EntityList<Wechat_RentBuilding> GetWechat_RentBuildings(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_RentBuildings(string.Empty, where, parameters, Wechat_RentBuilding.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentBuilding objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentBuilding objects.</returns>
		protected static EntityList<Wechat_RentBuilding> GetWechat_RentBuildings(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_RentBuildings(prefix, where, parameters, Wechat_RentBuilding.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentBuilding objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentBuilding objects.</returns>
		protected static EntityList<Wechat_RentBuilding> GetWechat_RentBuildings(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_RentBuildings(string.Empty, where, parameters, Wechat_RentBuilding.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentBuilding objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentBuilding objects.</returns>
		protected static EntityList<Wechat_RentBuilding> GetWechat_RentBuildings(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_RentBuildings(prefix, where, parameters, Wechat_RentBuilding.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentBuilding objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_RentBuilding objects.</returns>
		protected static EntityList<Wechat_RentBuilding> GetWechat_RentBuildings(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_RentBuilding.SelectFieldList + "FROM [dbo].[Wechat_RentBuilding] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_RentBuilding>(reader);
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
        protected static EntityList<Wechat_RentBuilding> GetWechat_RentBuildings(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_RentBuilding>(SelectFieldList, "FROM [dbo].[Wechat_RentBuilding] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_RentBuilding objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_RentBuildingCount()
        {
            return GetWechat_RentBuildingCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_RentBuilding objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_RentBuildingCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_RentBuilding] " + where;

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
		public static partial class Wechat_RentBuilding_Properties
		{
			public const string ID = "ID";
			public const string AreaID = "AreaID";
			public const string BuildingName = "BuildingName";
			public const string BuildingLocation = "BuildingLocation";
			public const string AddTime = "AddTime";
			public const string AddUser = "AddUser";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"AreaID" , "int:"},
    			 {"BuildingName" , "string:"},
    			 {"BuildingLocation" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUser" , "string:"},
            };
		}
		#endregion
	}
}
