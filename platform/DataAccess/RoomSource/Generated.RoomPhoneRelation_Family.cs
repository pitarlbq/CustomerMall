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
	/// This object represents the properties and methods of a RoomPhoneRelation_Family.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class RoomPhoneRelation_Family 
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
		private int _familyUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int FamilyUserID
		{
			[DebuggerStepThrough()]
			get { return this._familyUserID; }
			set 
			{
				if (this._familyUserID != value) 
				{
					this._familyUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("FamilyUserID");
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
	[RoomPhoneRelationID] int,
	[FamilyUserID] int,
	[AddTime] datetime
);

INSERT INTO [dbo].[RoomPhoneRelation_Family] (
	[RoomPhoneRelation_Family].[RoomPhoneRelationID],
	[RoomPhoneRelation_Family].[FamilyUserID],
	[RoomPhoneRelation_Family].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[FamilyUserID],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@RoomPhoneRelationID,
	@FamilyUserID,
	@AddTime 
); 

SELECT 
	[ID],
	[RoomPhoneRelationID],
	[FamilyUserID],
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
	[RoomPhoneRelationID] int,
	[FamilyUserID] int,
	[AddTime] datetime
);

UPDATE [dbo].[RoomPhoneRelation_Family] SET 
	[RoomPhoneRelation_Family].[RoomPhoneRelationID] = @RoomPhoneRelationID,
	[RoomPhoneRelation_Family].[FamilyUserID] = @FamilyUserID,
	[RoomPhoneRelation_Family].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[FamilyUserID],
	INSERTED.[AddTime]
into @table
WHERE 
	[RoomPhoneRelation_Family].[ID] = @ID

SELECT 
	[ID],
	[RoomPhoneRelationID],
	[FamilyUserID],
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
DELETE FROM [dbo].[RoomPhoneRelation_Family]
WHERE 
	[RoomPhoneRelation_Family].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public RoomPhoneRelation_Family() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetRoomPhoneRelation_Family(this.ID));
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
	[RoomPhoneRelation_Family].[ID],
	[RoomPhoneRelation_Family].[RoomPhoneRelationID],
	[RoomPhoneRelation_Family].[FamilyUserID],
	[RoomPhoneRelation_Family].[AddTime]
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
                return "RoomPhoneRelation_Family";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a RoomPhoneRelation_Family into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="familyUserID">familyUserID</param>
		/// <param name="addTime">addTime</param>
		public static void InsertRoomPhoneRelation_Family(int @roomPhoneRelationID, int @familyUserID, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertRoomPhoneRelation_Family(@roomPhoneRelationID, @familyUserID, @addTime, helper);
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
		/// Insert a RoomPhoneRelation_Family into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="familyUserID">familyUserID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertRoomPhoneRelation_Family(int @roomPhoneRelationID, int @familyUserID, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomPhoneRelationID] int,
	[FamilyUserID] int,
	[AddTime] datetime
);

INSERT INTO [dbo].[RoomPhoneRelation_Family] (
	[RoomPhoneRelation_Family].[RoomPhoneRelationID],
	[RoomPhoneRelation_Family].[FamilyUserID],
	[RoomPhoneRelation_Family].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[FamilyUserID],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@RoomPhoneRelationID,
	@FamilyUserID,
	@AddTime 
); 

SELECT 
	[ID],
	[RoomPhoneRelationID],
	[FamilyUserID],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoomPhoneRelationID", EntityBase.GetDatabaseValue(@roomPhoneRelationID)));
			parameters.Add(new SqlParameter("@FamilyUserID", EntityBase.GetDatabaseValue(@familyUserID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a RoomPhoneRelation_Family into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="familyUserID">familyUserID</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateRoomPhoneRelation_Family(int @iD, int @roomPhoneRelationID, int @familyUserID, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateRoomPhoneRelation_Family(@iD, @roomPhoneRelationID, @familyUserID, @addTime, helper);
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
		/// Updates a RoomPhoneRelation_Family into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="familyUserID">familyUserID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateRoomPhoneRelation_Family(int @iD, int @roomPhoneRelationID, int @familyUserID, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomPhoneRelationID] int,
	[FamilyUserID] int,
	[AddTime] datetime
);

UPDATE [dbo].[RoomPhoneRelation_Family] SET 
	[RoomPhoneRelation_Family].[RoomPhoneRelationID] = @RoomPhoneRelationID,
	[RoomPhoneRelation_Family].[FamilyUserID] = @FamilyUserID,
	[RoomPhoneRelation_Family].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[FamilyUserID],
	INSERTED.[AddTime]
into @table
WHERE 
	[RoomPhoneRelation_Family].[ID] = @ID

SELECT 
	[ID],
	[RoomPhoneRelationID],
	[FamilyUserID],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoomPhoneRelationID", EntityBase.GetDatabaseValue(@roomPhoneRelationID)));
			parameters.Add(new SqlParameter("@FamilyUserID", EntityBase.GetDatabaseValue(@familyUserID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a RoomPhoneRelation_Family from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteRoomPhoneRelation_Family(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteRoomPhoneRelation_Family(@iD, helper);
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
		/// Deletes a RoomPhoneRelation_Family from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteRoomPhoneRelation_Family(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[RoomPhoneRelation_Family]
WHERE 
	[RoomPhoneRelation_Family].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new RoomPhoneRelation_Family object.
		/// </summary>
		/// <returns>The newly created RoomPhoneRelation_Family object.</returns>
		public static RoomPhoneRelation_Family CreateRoomPhoneRelation_Family()
		{
			return InitializeNew<RoomPhoneRelation_Family>();
		}
		
		/// <summary>
		/// Retrieve information for a RoomPhoneRelation_Family by a RoomPhoneRelation_Family's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>RoomPhoneRelation_Family</returns>
		public static RoomPhoneRelation_Family GetRoomPhoneRelation_Family(int @iD)
		{
			string commandText = @"
SELECT 
" + RoomPhoneRelation_Family.SelectFieldList + @"
FROM [dbo].[RoomPhoneRelation_Family] 
WHERE 
	[RoomPhoneRelation_Family].[ID] = @ID " + RoomPhoneRelation_Family.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomPhoneRelation_Family>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a RoomPhoneRelation_Family by a RoomPhoneRelation_Family's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>RoomPhoneRelation_Family</returns>
		public static RoomPhoneRelation_Family GetRoomPhoneRelation_Family(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + RoomPhoneRelation_Family.SelectFieldList + @"
FROM [dbo].[RoomPhoneRelation_Family] 
WHERE 
	[RoomPhoneRelation_Family].[ID] = @ID " + RoomPhoneRelation_Family.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomPhoneRelation_Family>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation_Family objects.
		/// </summary>
		/// <returns>The retrieved collection of RoomPhoneRelation_Family objects.</returns>
		public static EntityList<RoomPhoneRelation_Family> GetRoomPhoneRelation_Families()
		{
			string commandText = @"
SELECT " + RoomPhoneRelation_Family.SelectFieldList + "FROM [dbo].[RoomPhoneRelation_Family] " + RoomPhoneRelation_Family.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<RoomPhoneRelation_Family>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection RoomPhoneRelation_Family objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomPhoneRelation_Family objects.</returns>
        public static EntityList<RoomPhoneRelation_Family> GetRoomPhoneRelation_Families(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomPhoneRelation_Family>(SelectFieldList, "FROM [dbo].[RoomPhoneRelation_Family]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection RoomPhoneRelation_Family objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomPhoneRelation_Family objects.</returns>
        public static EntityList<RoomPhoneRelation_Family> GetRoomPhoneRelation_Families(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomPhoneRelation_Family>(SelectFieldList, "FROM [dbo].[RoomPhoneRelation_Family]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation_Family objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of RoomPhoneRelation_Family objects.</returns>
		protected static EntityList<RoomPhoneRelation_Family> GetRoomPhoneRelation_Families(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomPhoneRelation_Families(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation_Family objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomPhoneRelation_Family objects.</returns>
		protected static EntityList<RoomPhoneRelation_Family> GetRoomPhoneRelation_Families(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomPhoneRelation_Families(string.Empty, where, parameters, RoomPhoneRelation_Family.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation_Family objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomPhoneRelation_Family objects.</returns>
		protected static EntityList<RoomPhoneRelation_Family> GetRoomPhoneRelation_Families(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomPhoneRelation_Families(prefix, where, parameters, RoomPhoneRelation_Family.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation_Family objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomPhoneRelation_Family objects.</returns>
		protected static EntityList<RoomPhoneRelation_Family> GetRoomPhoneRelation_Families(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomPhoneRelation_Families(string.Empty, where, parameters, RoomPhoneRelation_Family.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation_Family objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomPhoneRelation_Family objects.</returns>
		protected static EntityList<RoomPhoneRelation_Family> GetRoomPhoneRelation_Families(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomPhoneRelation_Families(prefix, where, parameters, RoomPhoneRelation_Family.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation_Family objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of RoomPhoneRelation_Family objects.</returns>
		protected static EntityList<RoomPhoneRelation_Family> GetRoomPhoneRelation_Families(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + RoomPhoneRelation_Family.SelectFieldList + "FROM [dbo].[RoomPhoneRelation_Family] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<RoomPhoneRelation_Family>(reader);
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
        protected static EntityList<RoomPhoneRelation_Family> GetRoomPhoneRelation_Families(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomPhoneRelation_Family>(SelectFieldList, "FROM [dbo].[RoomPhoneRelation_Family] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of RoomPhoneRelation_Family objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomPhoneRelation_FamilyCount()
        {
            return GetRoomPhoneRelation_FamilyCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of RoomPhoneRelation_Family objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomPhoneRelation_FamilyCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[RoomPhoneRelation_Family] " + where;

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
		public static partial class RoomPhoneRelation_Family_Properties
		{
			public const string ID = "ID";
			public const string RoomPhoneRelationID = "RoomPhoneRelationID";
			public const string FamilyUserID = "FamilyUserID";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomPhoneRelationID" , "int:"},
    			 {"FamilyUserID" , "int:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
