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
	/// This object represents the properties and methods of a ChargeFeeRoomRelation.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ChargeFeeRoomRelation 
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
		private int _roomID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private int _chargeFeeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ChargeFeeID
		{
			[DebuggerStepThrough()]
			get { return this._chargeFeeID; }
			set 
			{
				if (this._chargeFeeID != value) 
				{
					this._chargeFeeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeFeeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isValid = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsValid
		{
			[DebuggerStepThrough()]
			get { return this._isValid; }
			set 
			{
				if (this._isValid != value) 
				{
					this._isValid = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsValid");
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
	[RoomID] int,
	[ChargeFeeID] int,
	[IsValid] bit,
	[AddTime] datetime
);

INSERT INTO [dbo].[ChargeFeeRoomRelation] (
	[ChargeFeeRoomRelation].[RoomID],
	[ChargeFeeRoomRelation].[ChargeFeeID],
	[ChargeFeeRoomRelation].[IsValid],
	[ChargeFeeRoomRelation].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[ChargeFeeID],
	INSERTED.[IsValid],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@RoomID,
	@ChargeFeeID,
	@IsValid,
	@AddTime 
); 

SELECT 
	[ID],
	[RoomID],
	[ChargeFeeID],
	[IsValid],
	[AddTime] 
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
	[RoomID] int,
	[ChargeFeeID] int,
	[IsValid] bit,
	[AddTime] datetime
);

UPDATE [dbo].[ChargeFeeRoomRelation] SET 
	[ChargeFeeRoomRelation].[RoomID] = @RoomID,
	[ChargeFeeRoomRelation].[ChargeFeeID] = @ChargeFeeID,
	[ChargeFeeRoomRelation].[IsValid] = @IsValid,
	[ChargeFeeRoomRelation].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[ChargeFeeID],
	INSERTED.[IsValid],
	INSERTED.[AddTime]
into @table
WHERE 
	[ChargeFeeRoomRelation].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[ChargeFeeID],
	[IsValid],
	[AddTime] 
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
DELETE FROM [dbo].[ChargeFeeRoomRelation]
WHERE 
	[ChargeFeeRoomRelation].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ChargeFeeRoomRelation() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetChargeFeeRoomRelation(this.ID));
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
	[ChargeFeeRoomRelation].[ID],
	[ChargeFeeRoomRelation].[RoomID],
	[ChargeFeeRoomRelation].[ChargeFeeID],
	[ChargeFeeRoomRelation].[IsValid],
	[ChargeFeeRoomRelation].[AddTime]
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
                return "ChargeFeeRoomRelation";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ChargeFeeRoomRelation into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="chargeFeeID">chargeFeeID</param>
		/// <param name="isValid">isValid</param>
		/// <param name="addTime">addTime</param>
		public static void InsertChargeFeeRoomRelation(int @roomID, int @chargeFeeID, bool @isValid, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertChargeFeeRoomRelation(@roomID, @chargeFeeID, @isValid, @addTime, helper);
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
		/// Insert a ChargeFeeRoomRelation into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="chargeFeeID">chargeFeeID</param>
		/// <param name="isValid">isValid</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertChargeFeeRoomRelation(int @roomID, int @chargeFeeID, bool @isValid, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[ChargeFeeID] int,
	[IsValid] bit,
	[AddTime] datetime
);

INSERT INTO [dbo].[ChargeFeeRoomRelation] (
	[ChargeFeeRoomRelation].[RoomID],
	[ChargeFeeRoomRelation].[ChargeFeeID],
	[ChargeFeeRoomRelation].[IsValid],
	[ChargeFeeRoomRelation].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[ChargeFeeID],
	INSERTED.[IsValid],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@RoomID,
	@ChargeFeeID,
	@IsValid,
	@AddTime 
); 

SELECT 
	[ID],
	[RoomID],
	[ChargeFeeID],
	[IsValid],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@ChargeFeeID", EntityBase.GetDatabaseValue(@chargeFeeID)));
			parameters.Add(new SqlParameter("@IsValid", @isValid));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ChargeFeeRoomRelation into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="chargeFeeID">chargeFeeID</param>
		/// <param name="isValid">isValid</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateChargeFeeRoomRelation(int @iD, int @roomID, int @chargeFeeID, bool @isValid, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateChargeFeeRoomRelation(@iD, @roomID, @chargeFeeID, @isValid, @addTime, helper);
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
		/// Updates a ChargeFeeRoomRelation into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="chargeFeeID">chargeFeeID</param>
		/// <param name="isValid">isValid</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateChargeFeeRoomRelation(int @iD, int @roomID, int @chargeFeeID, bool @isValid, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[ChargeFeeID] int,
	[IsValid] bit,
	[AddTime] datetime
);

UPDATE [dbo].[ChargeFeeRoomRelation] SET 
	[ChargeFeeRoomRelation].[RoomID] = @RoomID,
	[ChargeFeeRoomRelation].[ChargeFeeID] = @ChargeFeeID,
	[ChargeFeeRoomRelation].[IsValid] = @IsValid,
	[ChargeFeeRoomRelation].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[ChargeFeeID],
	INSERTED.[IsValid],
	INSERTED.[AddTime]
into @table
WHERE 
	[ChargeFeeRoomRelation].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[ChargeFeeID],
	[IsValid],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@ChargeFeeID", EntityBase.GetDatabaseValue(@chargeFeeID)));
			parameters.Add(new SqlParameter("@IsValid", @isValid));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ChargeFeeRoomRelation from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteChargeFeeRoomRelation(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteChargeFeeRoomRelation(@iD, helper);
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
		/// Deletes a ChargeFeeRoomRelation from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteChargeFeeRoomRelation(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ChargeFeeRoomRelation]
WHERE 
	[ChargeFeeRoomRelation].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ChargeFeeRoomRelation object.
		/// </summary>
		/// <returns>The newly created ChargeFeeRoomRelation object.</returns>
		public static ChargeFeeRoomRelation CreateChargeFeeRoomRelation()
		{
			return InitializeNew<ChargeFeeRoomRelation>();
		}
		
		/// <summary>
		/// Retrieve information for a ChargeFeeRoomRelation by a ChargeFeeRoomRelation's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ChargeFeeRoomRelation</returns>
		public static ChargeFeeRoomRelation GetChargeFeeRoomRelation(int @iD)
		{
			string commandText = @"
SELECT 
" + ChargeFeeRoomRelation.SelectFieldList + @"
FROM [dbo].[ChargeFeeRoomRelation] 
WHERE 
	[ChargeFeeRoomRelation].[ID] = @ID " + ChargeFeeRoomRelation.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeFeeRoomRelation>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ChargeFeeRoomRelation by a ChargeFeeRoomRelation's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ChargeFeeRoomRelation</returns>
		public static ChargeFeeRoomRelation GetChargeFeeRoomRelation(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ChargeFeeRoomRelation.SelectFieldList + @"
FROM [dbo].[ChargeFeeRoomRelation] 
WHERE 
	[ChargeFeeRoomRelation].[ID] = @ID " + ChargeFeeRoomRelation.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeFeeRoomRelation>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ChargeFeeRoomRelation objects.
		/// </summary>
		/// <returns>The retrieved collection of ChargeFeeRoomRelation objects.</returns>
		public static EntityList<ChargeFeeRoomRelation> GetChargeFeeRoomRelations()
		{
			string commandText = @"
SELECT " + ChargeFeeRoomRelation.SelectFieldList + "FROM [dbo].[ChargeFeeRoomRelation] " + ChargeFeeRoomRelation.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ChargeFeeRoomRelation>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ChargeFeeRoomRelation objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeFeeRoomRelation objects.</returns>
        public static EntityList<ChargeFeeRoomRelation> GetChargeFeeRoomRelations(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeFeeRoomRelation>(SelectFieldList, "FROM [dbo].[ChargeFeeRoomRelation]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ChargeFeeRoomRelation objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeFeeRoomRelation objects.</returns>
        public static EntityList<ChargeFeeRoomRelation> GetChargeFeeRoomRelations(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeFeeRoomRelation>(SelectFieldList, "FROM [dbo].[ChargeFeeRoomRelation]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ChargeFeeRoomRelation objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ChargeFeeRoomRelation objects.</returns>
		protected static EntityList<ChargeFeeRoomRelation> GetChargeFeeRoomRelations(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeFeeRoomRelations(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ChargeFeeRoomRelation objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeFeeRoomRelation objects.</returns>
		protected static EntityList<ChargeFeeRoomRelation> GetChargeFeeRoomRelations(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeFeeRoomRelations(string.Empty, where, parameters, ChargeFeeRoomRelation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeFeeRoomRelation objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeFeeRoomRelation objects.</returns>
		protected static EntityList<ChargeFeeRoomRelation> GetChargeFeeRoomRelations(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeFeeRoomRelations(prefix, where, parameters, ChargeFeeRoomRelation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeFeeRoomRelation objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeFeeRoomRelation objects.</returns>
		protected static EntityList<ChargeFeeRoomRelation> GetChargeFeeRoomRelations(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeFeeRoomRelations(string.Empty, where, parameters, ChargeFeeRoomRelation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeFeeRoomRelation objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeFeeRoomRelation objects.</returns>
		protected static EntityList<ChargeFeeRoomRelation> GetChargeFeeRoomRelations(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeFeeRoomRelations(prefix, where, parameters, ChargeFeeRoomRelation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeFeeRoomRelation objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ChargeFeeRoomRelation objects.</returns>
		protected static EntityList<ChargeFeeRoomRelation> GetChargeFeeRoomRelations(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ChargeFeeRoomRelation.SelectFieldList + "FROM [dbo].[ChargeFeeRoomRelation] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ChargeFeeRoomRelation>(reader);
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
        protected static EntityList<ChargeFeeRoomRelation> GetChargeFeeRoomRelations(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeFeeRoomRelation>(SelectFieldList, "FROM [dbo].[ChargeFeeRoomRelation] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class ChargeFeeRoomRelationProperties
		{
			public const string ID = "ID";
			public const string RoomID = "RoomID";
			public const string ChargeFeeID = "ChargeFeeID";
			public const string IsValid = "IsValid";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"ChargeFeeID" , "int:"},
    			 {"IsValid" , "bool:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
