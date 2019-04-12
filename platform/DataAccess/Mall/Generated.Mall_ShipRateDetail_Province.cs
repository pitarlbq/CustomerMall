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
	/// This object represents the properties and methods of a Mall_ShipRateDetail_Province.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_ShipRateDetail_Province 
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
		private int _rateDetailID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RateDetailID
		{
			[DebuggerStepThrough()]
			get { return this._rateDetailID; }
			set 
			{
				if (this._rateDetailID != value) 
				{
					this._rateDetailID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RateDetailID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _provinceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ProvinceID
		{
			[DebuggerStepThrough()]
			get { return this._provinceID; }
			set 
			{
				if (this._provinceID != value) 
				{
					this._provinceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProvinceID");
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
		private int _rateID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RateID
		{
			[DebuggerStepThrough()]
			get { return this._rateID; }
			set 
			{
				if (this._rateID != value) 
				{
					this._rateID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RateID");
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
	[RateDetailID] int,
	[ProvinceID] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[RateID] int
);

INSERT INTO [dbo].[Mall_ShipRateDetail_Province] (
	[Mall_ShipRateDetail_Province].[RateDetailID],
	[Mall_ShipRateDetail_Province].[ProvinceID],
	[Mall_ShipRateDetail_Province].[AddTime],
	[Mall_ShipRateDetail_Province].[AddUserName],
	[Mall_ShipRateDetail_Province].[RateID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RateDetailID],
	INSERTED.[ProvinceID],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[RateID]
into @table
VALUES ( 
	@RateDetailID,
	@ProvinceID,
	@AddTime,
	@AddUserName,
	@RateID 
); 

SELECT 
	[ID],
	[RateDetailID],
	[ProvinceID],
	[AddTime],
	[AddUserName],
	[RateID] 
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
	[RateDetailID] int,
	[ProvinceID] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[RateID] int
);

UPDATE [dbo].[Mall_ShipRateDetail_Province] SET 
	[Mall_ShipRateDetail_Province].[RateDetailID] = @RateDetailID,
	[Mall_ShipRateDetail_Province].[ProvinceID] = @ProvinceID,
	[Mall_ShipRateDetail_Province].[AddTime] = @AddTime,
	[Mall_ShipRateDetail_Province].[AddUserName] = @AddUserName,
	[Mall_ShipRateDetail_Province].[RateID] = @RateID 
output 
	INSERTED.[ID],
	INSERTED.[RateDetailID],
	INSERTED.[ProvinceID],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[RateID]
into @table
WHERE 
	[Mall_ShipRateDetail_Province].[ID] = @ID

SELECT 
	[ID],
	[RateDetailID],
	[ProvinceID],
	[AddTime],
	[AddUserName],
	[RateID] 
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
DELETE FROM [dbo].[Mall_ShipRateDetail_Province]
WHERE 
	[Mall_ShipRateDetail_Province].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_ShipRateDetail_Province() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_ShipRateDetail_Province(this.ID));
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
	[Mall_ShipRateDetail_Province].[ID],
	[Mall_ShipRateDetail_Province].[RateDetailID],
	[Mall_ShipRateDetail_Province].[ProvinceID],
	[Mall_ShipRateDetail_Province].[AddTime],
	[Mall_ShipRateDetail_Province].[AddUserName],
	[Mall_ShipRateDetail_Province].[RateID]
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
                return "Mall_ShipRateDetail_Province";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_ShipRateDetail_Province into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="rateDetailID">rateDetailID</param>
		/// <param name="provinceID">provinceID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="rateID">rateID</param>
		public static void InsertMall_ShipRateDetail_Province(int @rateDetailID, int @provinceID, DateTime @addTime, string @addUserName, int @rateID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_ShipRateDetail_Province(@rateDetailID, @provinceID, @addTime, @addUserName, @rateID, helper);
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
		/// Insert a Mall_ShipRateDetail_Province into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="rateDetailID">rateDetailID</param>
		/// <param name="provinceID">provinceID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="rateID">rateID</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_ShipRateDetail_Province(int @rateDetailID, int @provinceID, DateTime @addTime, string @addUserName, int @rateID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RateDetailID] int,
	[ProvinceID] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[RateID] int
);

INSERT INTO [dbo].[Mall_ShipRateDetail_Province] (
	[Mall_ShipRateDetail_Province].[RateDetailID],
	[Mall_ShipRateDetail_Province].[ProvinceID],
	[Mall_ShipRateDetail_Province].[AddTime],
	[Mall_ShipRateDetail_Province].[AddUserName],
	[Mall_ShipRateDetail_Province].[RateID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RateDetailID],
	INSERTED.[ProvinceID],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[RateID]
into @table
VALUES ( 
	@RateDetailID,
	@ProvinceID,
	@AddTime,
	@AddUserName,
	@RateID 
); 

SELECT 
	[ID],
	[RateDetailID],
	[ProvinceID],
	[AddTime],
	[AddUserName],
	[RateID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RateDetailID", EntityBase.GetDatabaseValue(@rateDetailID)));
			parameters.Add(new SqlParameter("@ProvinceID", EntityBase.GetDatabaseValue(@provinceID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@RateID", EntityBase.GetDatabaseValue(@rateID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_ShipRateDetail_Province into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="rateDetailID">rateDetailID</param>
		/// <param name="provinceID">provinceID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="rateID">rateID</param>
		public static void UpdateMall_ShipRateDetail_Province(int @iD, int @rateDetailID, int @provinceID, DateTime @addTime, string @addUserName, int @rateID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_ShipRateDetail_Province(@iD, @rateDetailID, @provinceID, @addTime, @addUserName, @rateID, helper);
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
		/// Updates a Mall_ShipRateDetail_Province into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="rateDetailID">rateDetailID</param>
		/// <param name="provinceID">provinceID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="rateID">rateID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_ShipRateDetail_Province(int @iD, int @rateDetailID, int @provinceID, DateTime @addTime, string @addUserName, int @rateID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RateDetailID] int,
	[ProvinceID] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[RateID] int
);

UPDATE [dbo].[Mall_ShipRateDetail_Province] SET 
	[Mall_ShipRateDetail_Province].[RateDetailID] = @RateDetailID,
	[Mall_ShipRateDetail_Province].[ProvinceID] = @ProvinceID,
	[Mall_ShipRateDetail_Province].[AddTime] = @AddTime,
	[Mall_ShipRateDetail_Province].[AddUserName] = @AddUserName,
	[Mall_ShipRateDetail_Province].[RateID] = @RateID 
output 
	INSERTED.[ID],
	INSERTED.[RateDetailID],
	INSERTED.[ProvinceID],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[RateID]
into @table
WHERE 
	[Mall_ShipRateDetail_Province].[ID] = @ID

SELECT 
	[ID],
	[RateDetailID],
	[ProvinceID],
	[AddTime],
	[AddUserName],
	[RateID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RateDetailID", EntityBase.GetDatabaseValue(@rateDetailID)));
			parameters.Add(new SqlParameter("@ProvinceID", EntityBase.GetDatabaseValue(@provinceID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@RateID", EntityBase.GetDatabaseValue(@rateID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_ShipRateDetail_Province from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_ShipRateDetail_Province(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_ShipRateDetail_Province(@iD, helper);
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
		/// Deletes a Mall_ShipRateDetail_Province from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_ShipRateDetail_Province(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_ShipRateDetail_Province]
WHERE 
	[Mall_ShipRateDetail_Province].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_ShipRateDetail_Province object.
		/// </summary>
		/// <returns>The newly created Mall_ShipRateDetail_Province object.</returns>
		public static Mall_ShipRateDetail_Province CreateMall_ShipRateDetail_Province()
		{
			return InitializeNew<Mall_ShipRateDetail_Province>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_ShipRateDetail_Province by a Mall_ShipRateDetail_Province's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_ShipRateDetail_Province</returns>
		public static Mall_ShipRateDetail_Province GetMall_ShipRateDetail_Province(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_ShipRateDetail_Province.SelectFieldList + @"
FROM [dbo].[Mall_ShipRateDetail_Province] 
WHERE 
	[Mall_ShipRateDetail_Province].[ID] = @ID " + Mall_ShipRateDetail_Province.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ShipRateDetail_Province>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_ShipRateDetail_Province by a Mall_ShipRateDetail_Province's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_ShipRateDetail_Province</returns>
		public static Mall_ShipRateDetail_Province GetMall_ShipRateDetail_Province(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_ShipRateDetail_Province.SelectFieldList + @"
FROM [dbo].[Mall_ShipRateDetail_Province] 
WHERE 
	[Mall_ShipRateDetail_Province].[ID] = @ID " + Mall_ShipRateDetail_Province.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ShipRateDetail_Province>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipRateDetail_Province objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_ShipRateDetail_Province objects.</returns>
		public static EntityList<Mall_ShipRateDetail_Province> GetMall_ShipRateDetail_Provinces()
		{
			string commandText = @"
SELECT " + Mall_ShipRateDetail_Province.SelectFieldList + "FROM [dbo].[Mall_ShipRateDetail_Province] " + Mall_ShipRateDetail_Province.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_ShipRateDetail_Province>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_ShipRateDetail_Province objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ShipRateDetail_Province objects.</returns>
        public static EntityList<Mall_ShipRateDetail_Province> GetMall_ShipRateDetail_Provinces(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ShipRateDetail_Province>(SelectFieldList, "FROM [dbo].[Mall_ShipRateDetail_Province]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_ShipRateDetail_Province objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ShipRateDetail_Province objects.</returns>
        public static EntityList<Mall_ShipRateDetail_Province> GetMall_ShipRateDetail_Provinces(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ShipRateDetail_Province>(SelectFieldList, "FROM [dbo].[Mall_ShipRateDetail_Province]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_ShipRateDetail_Province objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ShipRateDetail_Province objects.</returns>
		protected static EntityList<Mall_ShipRateDetail_Province> GetMall_ShipRateDetail_Provinces(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ShipRateDetail_Provinces(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipRateDetail_Province objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShipRateDetail_Province objects.</returns>
		protected static EntityList<Mall_ShipRateDetail_Province> GetMall_ShipRateDetail_Provinces(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ShipRateDetail_Provinces(string.Empty, where, parameters, Mall_ShipRateDetail_Province.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipRateDetail_Province objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShipRateDetail_Province objects.</returns>
		protected static EntityList<Mall_ShipRateDetail_Province> GetMall_ShipRateDetail_Provinces(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ShipRateDetail_Provinces(prefix, where, parameters, Mall_ShipRateDetail_Province.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipRateDetail_Province objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShipRateDetail_Province objects.</returns>
		protected static EntityList<Mall_ShipRateDetail_Province> GetMall_ShipRateDetail_Provinces(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ShipRateDetail_Provinces(string.Empty, where, parameters, Mall_ShipRateDetail_Province.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipRateDetail_Province objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShipRateDetail_Province objects.</returns>
		protected static EntityList<Mall_ShipRateDetail_Province> GetMall_ShipRateDetail_Provinces(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ShipRateDetail_Provinces(prefix, where, parameters, Mall_ShipRateDetail_Province.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipRateDetail_Province objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ShipRateDetail_Province objects.</returns>
		protected static EntityList<Mall_ShipRateDetail_Province> GetMall_ShipRateDetail_Provinces(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_ShipRateDetail_Province.SelectFieldList + "FROM [dbo].[Mall_ShipRateDetail_Province] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_ShipRateDetail_Province>(reader);
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
        protected static EntityList<Mall_ShipRateDetail_Province> GetMall_ShipRateDetail_Provinces(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ShipRateDetail_Province>(SelectFieldList, "FROM [dbo].[Mall_ShipRateDetail_Province] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_ShipRateDetail_Province objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ShipRateDetail_ProvinceCount()
        {
            return GetMall_ShipRateDetail_ProvinceCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_ShipRateDetail_Province objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ShipRateDetail_ProvinceCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_ShipRateDetail_Province] " + where;

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
		public static partial class Mall_ShipRateDetail_Province_Properties
		{
			public const string ID = "ID";
			public const string RateDetailID = "RateDetailID";
			public const string ProvinceID = "ProvinceID";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string RateID = "RateID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RateDetailID" , "int:"},
    			 {"ProvinceID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"RateID" , "int:"},
            };
		}
		#endregion
	}
}
