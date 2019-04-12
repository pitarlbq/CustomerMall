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
	/// This object represents the properties and methods of a AnalysisSummaryUser.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class AnalysisSummaryUser 
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
		private int _summaryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SummaryID
		{
			[DebuggerStepThrough()]
			get { return this._summaryID; }
			set 
			{
				if (this._summaryID != value) 
				{
					this._summaryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("SummaryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _roleID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RoleID
		{
			[DebuggerStepThrough()]
			get { return this._roleID; }
			set 
			{
				if (this._roleID != value) 
				{
					this._roleID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoleID");
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
		[DataObjectField(false, false, true)]
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
	[SummaryID] int,
	[RoleID] int,
	[UserID] int
);

INSERT INTO [dbo].[AnalysisSummaryUser] (
	[AnalysisSummaryUser].[SummaryID],
	[AnalysisSummaryUser].[RoleID],
	[AnalysisSummaryUser].[UserID]
) 
output 
	INSERTED.[ID],
	INSERTED.[SummaryID],
	INSERTED.[RoleID],
	INSERTED.[UserID]
into @table
VALUES ( 
	@SummaryID,
	@RoleID,
	@UserID 
); 

SELECT 
	[ID],
	[SummaryID],
	[RoleID],
	[UserID] 
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
	[SummaryID] int,
	[RoleID] int,
	[UserID] int
);

UPDATE [dbo].[AnalysisSummaryUser] SET 
	[AnalysisSummaryUser].[SummaryID] = @SummaryID,
	[AnalysisSummaryUser].[RoleID] = @RoleID,
	[AnalysisSummaryUser].[UserID] = @UserID 
output 
	INSERTED.[ID],
	INSERTED.[SummaryID],
	INSERTED.[RoleID],
	INSERTED.[UserID]
into @table
WHERE 
	[AnalysisSummaryUser].[ID] = @ID

SELECT 
	[ID],
	[SummaryID],
	[RoleID],
	[UserID] 
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
DELETE FROM [dbo].[AnalysisSummaryUser]
WHERE 
	[AnalysisSummaryUser].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public AnalysisSummaryUser() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetAnalysisSummaryUser(this.ID));
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
	[AnalysisSummaryUser].[ID],
	[AnalysisSummaryUser].[SummaryID],
	[AnalysisSummaryUser].[RoleID],
	[AnalysisSummaryUser].[UserID]
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
                return "AnalysisSummaryUser";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a AnalysisSummaryUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="summaryID">summaryID</param>
		/// <param name="roleID">roleID</param>
		/// <param name="userID">userID</param>
		public static void InsertAnalysisSummaryUser(int @summaryID, int @roleID, int @userID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertAnalysisSummaryUser(@summaryID, @roleID, @userID, helper);
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
		/// Insert a AnalysisSummaryUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="summaryID">summaryID</param>
		/// <param name="roleID">roleID</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void InsertAnalysisSummaryUser(int @summaryID, int @roleID, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SummaryID] int,
	[RoleID] int,
	[UserID] int
);

INSERT INTO [dbo].[AnalysisSummaryUser] (
	[AnalysisSummaryUser].[SummaryID],
	[AnalysisSummaryUser].[RoleID],
	[AnalysisSummaryUser].[UserID]
) 
output 
	INSERTED.[ID],
	INSERTED.[SummaryID],
	INSERTED.[RoleID],
	INSERTED.[UserID]
into @table
VALUES ( 
	@SummaryID,
	@RoleID,
	@UserID 
); 

SELECT 
	[ID],
	[SummaryID],
	[RoleID],
	[UserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@SummaryID", EntityBase.GetDatabaseValue(@summaryID)));
			parameters.Add(new SqlParameter("@RoleID", EntityBase.GetDatabaseValue(@roleID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a AnalysisSummaryUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="summaryID">summaryID</param>
		/// <param name="roleID">roleID</param>
		/// <param name="userID">userID</param>
		public static void UpdateAnalysisSummaryUser(int @iD, int @summaryID, int @roleID, int @userID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateAnalysisSummaryUser(@iD, @summaryID, @roleID, @userID, helper);
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
		/// Updates a AnalysisSummaryUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="summaryID">summaryID</param>
		/// <param name="roleID">roleID</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateAnalysisSummaryUser(int @iD, int @summaryID, int @roleID, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SummaryID] int,
	[RoleID] int,
	[UserID] int
);

UPDATE [dbo].[AnalysisSummaryUser] SET 
	[AnalysisSummaryUser].[SummaryID] = @SummaryID,
	[AnalysisSummaryUser].[RoleID] = @RoleID,
	[AnalysisSummaryUser].[UserID] = @UserID 
output 
	INSERTED.[ID],
	INSERTED.[SummaryID],
	INSERTED.[RoleID],
	INSERTED.[UserID]
into @table
WHERE 
	[AnalysisSummaryUser].[ID] = @ID

SELECT 
	[ID],
	[SummaryID],
	[RoleID],
	[UserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@SummaryID", EntityBase.GetDatabaseValue(@summaryID)));
			parameters.Add(new SqlParameter("@RoleID", EntityBase.GetDatabaseValue(@roleID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a AnalysisSummaryUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteAnalysisSummaryUser(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteAnalysisSummaryUser(@iD, helper);
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
		/// Deletes a AnalysisSummaryUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteAnalysisSummaryUser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[AnalysisSummaryUser]
WHERE 
	[AnalysisSummaryUser].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new AnalysisSummaryUser object.
		/// </summary>
		/// <returns>The newly created AnalysisSummaryUser object.</returns>
		public static AnalysisSummaryUser CreateAnalysisSummaryUser()
		{
			return InitializeNew<AnalysisSummaryUser>();
		}
		
		/// <summary>
		/// Retrieve information for a AnalysisSummaryUser by a AnalysisSummaryUser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>AnalysisSummaryUser</returns>
		public static AnalysisSummaryUser GetAnalysisSummaryUser(int @iD)
		{
			string commandText = @"
SELECT 
" + AnalysisSummaryUser.SelectFieldList + @"
FROM [dbo].[AnalysisSummaryUser] 
WHERE 
	[AnalysisSummaryUser].[ID] = @ID " + AnalysisSummaryUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<AnalysisSummaryUser>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a AnalysisSummaryUser by a AnalysisSummaryUser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>AnalysisSummaryUser</returns>
		public static AnalysisSummaryUser GetAnalysisSummaryUser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + AnalysisSummaryUser.SelectFieldList + @"
FROM [dbo].[AnalysisSummaryUser] 
WHERE 
	[AnalysisSummaryUser].[ID] = @ID " + AnalysisSummaryUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<AnalysisSummaryUser>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection AnalysisSummaryUser objects.
		/// </summary>
		/// <returns>The retrieved collection of AnalysisSummaryUser objects.</returns>
		public static EntityList<AnalysisSummaryUser> GetAnalysisSummaryUsers()
		{
			string commandText = @"
SELECT " + AnalysisSummaryUser.SelectFieldList + "FROM [dbo].[AnalysisSummaryUser] " + AnalysisSummaryUser.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<AnalysisSummaryUser>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection AnalysisSummaryUser objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of AnalysisSummaryUser objects.</returns>
        public static EntityList<AnalysisSummaryUser> GetAnalysisSummaryUsers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<AnalysisSummaryUser>(SelectFieldList, "FROM [dbo].[AnalysisSummaryUser]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection AnalysisSummaryUser objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of AnalysisSummaryUser objects.</returns>
        public static EntityList<AnalysisSummaryUser> GetAnalysisSummaryUsers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<AnalysisSummaryUser>(SelectFieldList, "FROM [dbo].[AnalysisSummaryUser]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection AnalysisSummaryUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of AnalysisSummaryUser objects.</returns>
		protected static EntityList<AnalysisSummaryUser> GetAnalysisSummaryUsers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetAnalysisSummaryUsers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection AnalysisSummaryUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of AnalysisSummaryUser objects.</returns>
		protected static EntityList<AnalysisSummaryUser> GetAnalysisSummaryUsers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetAnalysisSummaryUsers(string.Empty, where, parameters, AnalysisSummaryUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection AnalysisSummaryUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of AnalysisSummaryUser objects.</returns>
		protected static EntityList<AnalysisSummaryUser> GetAnalysisSummaryUsers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetAnalysisSummaryUsers(prefix, where, parameters, AnalysisSummaryUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection AnalysisSummaryUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of AnalysisSummaryUser objects.</returns>
		protected static EntityList<AnalysisSummaryUser> GetAnalysisSummaryUsers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetAnalysisSummaryUsers(string.Empty, where, parameters, AnalysisSummaryUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection AnalysisSummaryUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of AnalysisSummaryUser objects.</returns>
		protected static EntityList<AnalysisSummaryUser> GetAnalysisSummaryUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetAnalysisSummaryUsers(prefix, where, parameters, AnalysisSummaryUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection AnalysisSummaryUser objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of AnalysisSummaryUser objects.</returns>
		protected static EntityList<AnalysisSummaryUser> GetAnalysisSummaryUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + AnalysisSummaryUser.SelectFieldList + "FROM [dbo].[AnalysisSummaryUser] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<AnalysisSummaryUser>(reader);
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
        protected static EntityList<AnalysisSummaryUser> GetAnalysisSummaryUsers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<AnalysisSummaryUser>(SelectFieldList, "FROM [dbo].[AnalysisSummaryUser] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of AnalysisSummaryUser objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetAnalysisSummaryUserCount()
        {
            return GetAnalysisSummaryUserCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of AnalysisSummaryUser objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetAnalysisSummaryUserCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[AnalysisSummaryUser] " + where;

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
		public static partial class AnalysisSummaryUser_Properties
		{
			public const string ID = "ID";
			public const string SummaryID = "SummaryID";
			public const string RoleID = "RoleID";
			public const string UserID = "UserID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"SummaryID" , "int:"},
    			 {"RoleID" , "int:"},
    			 {"UserID" , "int:"},
            };
		}
		#endregion
	}
}
