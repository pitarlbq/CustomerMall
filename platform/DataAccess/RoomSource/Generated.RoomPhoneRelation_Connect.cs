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
	/// This object represents the properties and methods of a RoomPhoneRelation_Connect.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class RoomPhoneRelation_Connect 
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
		private int _roomPhoneRelationID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private int _contractID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
	[RoomPhoneRelationID] int,
	[ContractID] int,
	[RoomID] int
);

INSERT INTO [dbo].[RoomPhoneRelation_Connect] (
	[RoomPhoneRelation_Connect].[RoomPhoneRelationID],
	[RoomPhoneRelation_Connect].[ContractID],
	[RoomPhoneRelation_Connect].[RoomID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[ContractID],
	INSERTED.[RoomID]
into @table
VALUES ( 
	@RoomPhoneRelationID,
	@ContractID,
	@RoomID 
); 

SELECT 
	[ID],
	[RoomPhoneRelationID],
	[ContractID],
	[RoomID] 
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
	[RoomPhoneRelationID] int,
	[ContractID] int,
	[RoomID] int
);

UPDATE [dbo].[RoomPhoneRelation_Connect] SET 
	[RoomPhoneRelation_Connect].[RoomPhoneRelationID] = @RoomPhoneRelationID,
	[RoomPhoneRelation_Connect].[ContractID] = @ContractID,
	[RoomPhoneRelation_Connect].[RoomID] = @RoomID 
output 
	INSERTED.[ID],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[ContractID],
	INSERTED.[RoomID]
into @table
WHERE 
	[RoomPhoneRelation_Connect].[ID] = @ID

SELECT 
	[ID],
	[RoomPhoneRelationID],
	[ContractID],
	[RoomID] 
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
DELETE FROM [dbo].[RoomPhoneRelation_Connect]
WHERE 
	[RoomPhoneRelation_Connect].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public RoomPhoneRelation_Connect() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetRoomPhoneRelation_Connect(this.ID));
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
	[RoomPhoneRelation_Connect].[ID],
	[RoomPhoneRelation_Connect].[RoomPhoneRelationID],
	[RoomPhoneRelation_Connect].[ContractID],
	[RoomPhoneRelation_Connect].[RoomID]
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
                return "RoomPhoneRelation_Connect";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a RoomPhoneRelation_Connect into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="contractID">contractID</param>
		/// <param name="roomID">roomID</param>
		public static void InsertRoomPhoneRelation_Connect(int @roomPhoneRelationID, int @contractID, int @roomID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertRoomPhoneRelation_Connect(@roomPhoneRelationID, @contractID, @roomID, helper);
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
		/// Insert a RoomPhoneRelation_Connect into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="contractID">contractID</param>
		/// <param name="roomID">roomID</param>
		/// <param name="helper">helper</param>
		internal static void InsertRoomPhoneRelation_Connect(int @roomPhoneRelationID, int @contractID, int @roomID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomPhoneRelationID] int,
	[ContractID] int,
	[RoomID] int
);

INSERT INTO [dbo].[RoomPhoneRelation_Connect] (
	[RoomPhoneRelation_Connect].[RoomPhoneRelationID],
	[RoomPhoneRelation_Connect].[ContractID],
	[RoomPhoneRelation_Connect].[RoomID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[ContractID],
	INSERTED.[RoomID]
into @table
VALUES ( 
	@RoomPhoneRelationID,
	@ContractID,
	@RoomID 
); 

SELECT 
	[ID],
	[RoomPhoneRelationID],
	[ContractID],
	[RoomID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoomPhoneRelationID", EntityBase.GetDatabaseValue(@roomPhoneRelationID)));
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a RoomPhoneRelation_Connect into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="contractID">contractID</param>
		/// <param name="roomID">roomID</param>
		public static void UpdateRoomPhoneRelation_Connect(int @iD, int @roomPhoneRelationID, int @contractID, int @roomID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateRoomPhoneRelation_Connect(@iD, @roomPhoneRelationID, @contractID, @roomID, helper);
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
		/// Updates a RoomPhoneRelation_Connect into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="contractID">contractID</param>
		/// <param name="roomID">roomID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateRoomPhoneRelation_Connect(int @iD, int @roomPhoneRelationID, int @contractID, int @roomID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomPhoneRelationID] int,
	[ContractID] int,
	[RoomID] int
);

UPDATE [dbo].[RoomPhoneRelation_Connect] SET 
	[RoomPhoneRelation_Connect].[RoomPhoneRelationID] = @RoomPhoneRelationID,
	[RoomPhoneRelation_Connect].[ContractID] = @ContractID,
	[RoomPhoneRelation_Connect].[RoomID] = @RoomID 
output 
	INSERTED.[ID],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[ContractID],
	INSERTED.[RoomID]
into @table
WHERE 
	[RoomPhoneRelation_Connect].[ID] = @ID

SELECT 
	[ID],
	[RoomPhoneRelationID],
	[ContractID],
	[RoomID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoomPhoneRelationID", EntityBase.GetDatabaseValue(@roomPhoneRelationID)));
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a RoomPhoneRelation_Connect from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteRoomPhoneRelation_Connect(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteRoomPhoneRelation_Connect(@iD, helper);
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
		/// Deletes a RoomPhoneRelation_Connect from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteRoomPhoneRelation_Connect(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[RoomPhoneRelation_Connect]
WHERE 
	[RoomPhoneRelation_Connect].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new RoomPhoneRelation_Connect object.
		/// </summary>
		/// <returns>The newly created RoomPhoneRelation_Connect object.</returns>
		public static RoomPhoneRelation_Connect CreateRoomPhoneRelation_Connect()
		{
			return InitializeNew<RoomPhoneRelation_Connect>();
		}
		
		/// <summary>
		/// Retrieve information for a RoomPhoneRelation_Connect by a RoomPhoneRelation_Connect's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>RoomPhoneRelation_Connect</returns>
		public static RoomPhoneRelation_Connect GetRoomPhoneRelation_Connect(int @iD)
		{
			string commandText = @"
SELECT 
" + RoomPhoneRelation_Connect.SelectFieldList + @"
FROM [dbo].[RoomPhoneRelation_Connect] 
WHERE 
	[RoomPhoneRelation_Connect].[ID] = @ID " + RoomPhoneRelation_Connect.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomPhoneRelation_Connect>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a RoomPhoneRelation_Connect by a RoomPhoneRelation_Connect's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>RoomPhoneRelation_Connect</returns>
		public static RoomPhoneRelation_Connect GetRoomPhoneRelation_Connect(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + RoomPhoneRelation_Connect.SelectFieldList + @"
FROM [dbo].[RoomPhoneRelation_Connect] 
WHERE 
	[RoomPhoneRelation_Connect].[ID] = @ID " + RoomPhoneRelation_Connect.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomPhoneRelation_Connect>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation_Connect objects.
		/// </summary>
		/// <returns>The retrieved collection of RoomPhoneRelation_Connect objects.</returns>
		public static EntityList<RoomPhoneRelation_Connect> GetRoomPhoneRelation_Connects()
		{
			string commandText = @"
SELECT " + RoomPhoneRelation_Connect.SelectFieldList + "FROM [dbo].[RoomPhoneRelation_Connect] " + RoomPhoneRelation_Connect.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<RoomPhoneRelation_Connect>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection RoomPhoneRelation_Connect objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomPhoneRelation_Connect objects.</returns>
        public static EntityList<RoomPhoneRelation_Connect> GetRoomPhoneRelation_Connects(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomPhoneRelation_Connect>(SelectFieldList, "FROM [dbo].[RoomPhoneRelation_Connect]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection RoomPhoneRelation_Connect objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomPhoneRelation_Connect objects.</returns>
        public static EntityList<RoomPhoneRelation_Connect> GetRoomPhoneRelation_Connects(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomPhoneRelation_Connect>(SelectFieldList, "FROM [dbo].[RoomPhoneRelation_Connect]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation_Connect objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of RoomPhoneRelation_Connect objects.</returns>
		protected static EntityList<RoomPhoneRelation_Connect> GetRoomPhoneRelation_Connects(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomPhoneRelation_Connects(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation_Connect objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomPhoneRelation_Connect objects.</returns>
		protected static EntityList<RoomPhoneRelation_Connect> GetRoomPhoneRelation_Connects(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomPhoneRelation_Connects(string.Empty, where, parameters, RoomPhoneRelation_Connect.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation_Connect objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomPhoneRelation_Connect objects.</returns>
		protected static EntityList<RoomPhoneRelation_Connect> GetRoomPhoneRelation_Connects(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomPhoneRelation_Connects(prefix, where, parameters, RoomPhoneRelation_Connect.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation_Connect objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomPhoneRelation_Connect objects.</returns>
		protected static EntityList<RoomPhoneRelation_Connect> GetRoomPhoneRelation_Connects(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomPhoneRelation_Connects(string.Empty, where, parameters, RoomPhoneRelation_Connect.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation_Connect objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomPhoneRelation_Connect objects.</returns>
		protected static EntityList<RoomPhoneRelation_Connect> GetRoomPhoneRelation_Connects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomPhoneRelation_Connects(prefix, where, parameters, RoomPhoneRelation_Connect.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation_Connect objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of RoomPhoneRelation_Connect objects.</returns>
		protected static EntityList<RoomPhoneRelation_Connect> GetRoomPhoneRelation_Connects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + RoomPhoneRelation_Connect.SelectFieldList + "FROM [dbo].[RoomPhoneRelation_Connect] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<RoomPhoneRelation_Connect>(reader);
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
        protected static EntityList<RoomPhoneRelation_Connect> GetRoomPhoneRelation_Connects(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomPhoneRelation_Connect>(SelectFieldList, "FROM [dbo].[RoomPhoneRelation_Connect] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of RoomPhoneRelation_Connect objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomPhoneRelation_ConnectCount()
        {
            return GetRoomPhoneRelation_ConnectCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of RoomPhoneRelation_Connect objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomPhoneRelation_ConnectCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[RoomPhoneRelation_Connect] " + where;

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
		public static partial class RoomPhoneRelation_Connect_Properties
		{
			public const string ID = "ID";
			public const string RoomPhoneRelationID = "RoomPhoneRelationID";
			public const string ContractID = "ContractID";
			public const string RoomID = "RoomID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomPhoneRelationID" , "int:"},
    			 {"ContractID" , "int:"},
    			 {"RoomID" , "int:"},
            };
		}
		#endregion
	}
}
