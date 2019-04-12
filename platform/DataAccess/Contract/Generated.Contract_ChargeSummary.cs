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
	/// This object represents the properties and methods of a Contract_ChargeSummary.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Contract_ChargeSummary 
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
		private int _chargeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private string _roomType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomType
		{
			[DebuggerStepThrough()]
			get { return this._roomType; }
			set 
			{
				if (this._roomType != value) 
				{
					this._roomType = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomType");
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
	[ChargeID] int,
	[GUID] nvarchar(500),
	[RoomType] nvarchar(500)
);

INSERT INTO [dbo].[Contract_ChargeSummary] (
	[Contract_ChargeSummary].[ContractID],
	[Contract_ChargeSummary].[ChargeID],
	[Contract_ChargeSummary].[GUID],
	[Contract_ChargeSummary].[RoomType]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[ChargeID],
	INSERTED.[GUID],
	INSERTED.[RoomType]
into @table
VALUES ( 
	@ContractID,
	@ChargeID,
	@GUID,
	@RoomType 
); 

SELECT 
	[ID],
	[ContractID],
	[ChargeID],
	[GUID],
	[RoomType] 
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
	[ChargeID] int,
	[GUID] nvarchar(500),
	[RoomType] nvarchar(500)
);

UPDATE [dbo].[Contract_ChargeSummary] SET 
	[Contract_ChargeSummary].[ContractID] = @ContractID,
	[Contract_ChargeSummary].[ChargeID] = @ChargeID,
	[Contract_ChargeSummary].[GUID] = @GUID,
	[Contract_ChargeSummary].[RoomType] = @RoomType 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[ChargeID],
	INSERTED.[GUID],
	INSERTED.[RoomType]
into @table
WHERE 
	[Contract_ChargeSummary].[ID] = @ID

SELECT 
	[ID],
	[ContractID],
	[ChargeID],
	[GUID],
	[RoomType] 
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
DELETE FROM [dbo].[Contract_ChargeSummary]
WHERE 
	[Contract_ChargeSummary].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Contract_ChargeSummary() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetContract_ChargeSummary(this.ID));
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
	[Contract_ChargeSummary].[ID],
	[Contract_ChargeSummary].[ContractID],
	[Contract_ChargeSummary].[ChargeID],
	[Contract_ChargeSummary].[GUID],
	[Contract_ChargeSummary].[RoomType]
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
                return "Contract_ChargeSummary";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Contract_ChargeSummary into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractID">contractID</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="gUID">gUID</param>
		/// <param name="roomType">roomType</param>
		public static void InsertContract_ChargeSummary(int @contractID, int @chargeID, string @gUID, string @roomType)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertContract_ChargeSummary(@contractID, @chargeID, @gUID, @roomType, helper);
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
		/// Insert a Contract_ChargeSummary into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractID">contractID</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="gUID">gUID</param>
		/// <param name="roomType">roomType</param>
		/// <param name="helper">helper</param>
		internal static void InsertContract_ChargeSummary(int @contractID, int @chargeID, string @gUID, string @roomType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractID] int,
	[ChargeID] int,
	[GUID] nvarchar(500),
	[RoomType] nvarchar(500)
);

INSERT INTO [dbo].[Contract_ChargeSummary] (
	[Contract_ChargeSummary].[ContractID],
	[Contract_ChargeSummary].[ChargeID],
	[Contract_ChargeSummary].[GUID],
	[Contract_ChargeSummary].[RoomType]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[ChargeID],
	INSERTED.[GUID],
	INSERTED.[RoomType]
into @table
VALUES ( 
	@ContractID,
	@ChargeID,
	@GUID,
	@RoomType 
); 

SELECT 
	[ID],
	[ContractID],
	[ChargeID],
	[GUID],
	[RoomType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@RoomType", EntityBase.GetDatabaseValue(@roomType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Contract_ChargeSummary into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractID">contractID</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="gUID">gUID</param>
		/// <param name="roomType">roomType</param>
		public static void UpdateContract_ChargeSummary(int @iD, int @contractID, int @chargeID, string @gUID, string @roomType)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateContract_ChargeSummary(@iD, @contractID, @chargeID, @gUID, @roomType, helper);
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
		/// Updates a Contract_ChargeSummary into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractID">contractID</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="gUID">gUID</param>
		/// <param name="roomType">roomType</param>
		/// <param name="helper">helper</param>
		internal static void UpdateContract_ChargeSummary(int @iD, int @contractID, int @chargeID, string @gUID, string @roomType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractID] int,
	[ChargeID] int,
	[GUID] nvarchar(500),
	[RoomType] nvarchar(500)
);

UPDATE [dbo].[Contract_ChargeSummary] SET 
	[Contract_ChargeSummary].[ContractID] = @ContractID,
	[Contract_ChargeSummary].[ChargeID] = @ChargeID,
	[Contract_ChargeSummary].[GUID] = @GUID,
	[Contract_ChargeSummary].[RoomType] = @RoomType 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[ChargeID],
	INSERTED.[GUID],
	INSERTED.[RoomType]
into @table
WHERE 
	[Contract_ChargeSummary].[ID] = @ID

SELECT 
	[ID],
	[ContractID],
	[ChargeID],
	[GUID],
	[RoomType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@RoomType", EntityBase.GetDatabaseValue(@roomType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Contract_ChargeSummary from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteContract_ChargeSummary(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteContract_ChargeSummary(@iD, helper);
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
		/// Deletes a Contract_ChargeSummary from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteContract_ChargeSummary(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Contract_ChargeSummary]
WHERE 
	[Contract_ChargeSummary].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Contract_ChargeSummary object.
		/// </summary>
		/// <returns>The newly created Contract_ChargeSummary object.</returns>
		public static Contract_ChargeSummary CreateContract_ChargeSummary()
		{
			return InitializeNew<Contract_ChargeSummary>();
		}
		
		/// <summary>
		/// Retrieve information for a Contract_ChargeSummary by a Contract_ChargeSummary's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Contract_ChargeSummary</returns>
		public static Contract_ChargeSummary GetContract_ChargeSummary(int @iD)
		{
			string commandText = @"
SELECT 
" + Contract_ChargeSummary.SelectFieldList + @"
FROM [dbo].[Contract_ChargeSummary] 
WHERE 
	[Contract_ChargeSummary].[ID] = @ID " + Contract_ChargeSummary.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_ChargeSummary>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Contract_ChargeSummary by a Contract_ChargeSummary's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Contract_ChargeSummary</returns>
		public static Contract_ChargeSummary GetContract_ChargeSummary(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Contract_ChargeSummary.SelectFieldList + @"
FROM [dbo].[Contract_ChargeSummary] 
WHERE 
	[Contract_ChargeSummary].[ID] = @ID " + Contract_ChargeSummary.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_ChargeSummary>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Contract_ChargeSummary objects.
		/// </summary>
		/// <returns>The retrieved collection of Contract_ChargeSummary objects.</returns>
		public static EntityList<Contract_ChargeSummary> GetContract_ChargeSummaries()
		{
			string commandText = @"
SELECT " + Contract_ChargeSummary.SelectFieldList + "FROM [dbo].[Contract_ChargeSummary] " + Contract_ChargeSummary.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Contract_ChargeSummary>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Contract_ChargeSummary objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_ChargeSummary objects.</returns>
        public static EntityList<Contract_ChargeSummary> GetContract_ChargeSummaries(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_ChargeSummary>(SelectFieldList, "FROM [dbo].[Contract_ChargeSummary]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Contract_ChargeSummary objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_ChargeSummary objects.</returns>
        public static EntityList<Contract_ChargeSummary> GetContract_ChargeSummaries(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_ChargeSummary>(SelectFieldList, "FROM [dbo].[Contract_ChargeSummary]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Contract_ChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Contract_ChargeSummary objects.</returns>
		protected static EntityList<Contract_ChargeSummary> GetContract_ChargeSummaries(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_ChargeSummaries(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Contract_ChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_ChargeSummary objects.</returns>
		protected static EntityList<Contract_ChargeSummary> GetContract_ChargeSummaries(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_ChargeSummaries(string.Empty, where, parameters, Contract_ChargeSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_ChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_ChargeSummary objects.</returns>
		protected static EntityList<Contract_ChargeSummary> GetContract_ChargeSummaries(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_ChargeSummaries(prefix, where, parameters, Contract_ChargeSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_ChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_ChargeSummary objects.</returns>
		protected static EntityList<Contract_ChargeSummary> GetContract_ChargeSummaries(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_ChargeSummaries(string.Empty, where, parameters, Contract_ChargeSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_ChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_ChargeSummary objects.</returns>
		protected static EntityList<Contract_ChargeSummary> GetContract_ChargeSummaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_ChargeSummaries(prefix, where, parameters, Contract_ChargeSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_ChargeSummary objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Contract_ChargeSummary objects.</returns>
		protected static EntityList<Contract_ChargeSummary> GetContract_ChargeSummaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Contract_ChargeSummary.SelectFieldList + "FROM [dbo].[Contract_ChargeSummary] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Contract_ChargeSummary>(reader);
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
        protected static EntityList<Contract_ChargeSummary> GetContract_ChargeSummaries(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_ChargeSummary>(SelectFieldList, "FROM [dbo].[Contract_ChargeSummary] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Contract_ChargeSummary objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_ChargeSummaryCount()
        {
            return GetContract_ChargeSummaryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Contract_ChargeSummary objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_ChargeSummaryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Contract_ChargeSummary] " + where;

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
		public static partial class Contract_ChargeSummary_Properties
		{
			public const string ID = "ID";
			public const string ContractID = "ContractID";
			public const string ChargeID = "ChargeID";
			public const string GUID = "GUID";
			public const string RoomType = "RoomType";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ContractID" , "int:"},
    			 {"ChargeID" , "int:"},
    			 {"GUID" , "string:"},
    			 {"RoomType" , "string:"},
            };
		}
		#endregion
	}
}
