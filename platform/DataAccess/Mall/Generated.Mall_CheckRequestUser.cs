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
	/// This object represents the properties and methods of a Mall_CheckRequestUser.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("RequestID: {RequestID}, UserID: {UserID}")]
	public partial class Mall_CheckRequestUser 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _requestID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int RequestID
		{
			[DebuggerStepThrough()]
			get { return this._requestID; }
			set 
			{
				if (this._requestID != value) 
				{
					this._requestID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RequestID");
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
		[DataObjectField(true, false, false)]
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
	[RequestID] int,
	[UserID] int
);

INSERT INTO [dbo].[Mall_CheckRequestUser] (
	[Mall_CheckRequestUser].[RequestID],
	[Mall_CheckRequestUser].[UserID]
) 
output 
	INSERTED.[RequestID],
	INSERTED.[UserID]
into @table
VALUES ( 
	@RequestID,
	@UserID 
); 

SELECT 
	[RequestID],
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
	[RequestID] int,
	[UserID] int
);

UPDATE [dbo].[Mall_CheckRequestUser] SET 
 
output 
	INSERTED.[RequestID],
	INSERTED.[UserID]
into @table
WHERE 
	[Mall_CheckRequestUser].[RequestID] = @RequestID
	AND [Mall_CheckRequestUser].[UserID] = @UserID

SELECT 
	[RequestID],
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
DELETE FROM [dbo].[Mall_CheckRequestUser]
WHERE 
	[Mall_CheckRequestUser].[RequestID] = @RequestID
	AND [Mall_CheckRequestUser].[UserID] = @UserID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_CheckRequestUser() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_CheckRequestUser(this.RequestID, this.UserID));
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
	[Mall_CheckRequestUser].[RequestID],
	[Mall_CheckRequestUser].[UserID]
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
                return "Mall_CheckRequestUser";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_CheckRequestUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="requestID">requestID</param>
		/// <param name="userID">userID</param>
		public static void InsertMall_CheckRequestUser(int @requestID, int @userID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_CheckRequestUser(@requestID, @userID, helper);
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
		/// Insert a Mall_CheckRequestUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="requestID">requestID</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_CheckRequestUser(int @requestID, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[RequestID] int,
	[UserID] int
);

INSERT INTO [dbo].[Mall_CheckRequestUser] (
	[Mall_CheckRequestUser].[RequestID],
	[Mall_CheckRequestUser].[UserID]
) 
output 
	INSERTED.[RequestID],
	INSERTED.[UserID]
into @table
VALUES ( 
	@RequestID,
	@UserID 
); 

SELECT 
	[RequestID],
	[UserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RequestID", EntityBase.GetDatabaseValue(@requestID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_CheckRequestUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="requestID">requestID</param>
		/// <param name="userID">userID</param>
		public static void UpdateMall_CheckRequestUser(int @requestID, int @userID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_CheckRequestUser(@requestID, @userID, helper);
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
		/// Updates a Mall_CheckRequestUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="requestID">requestID</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_CheckRequestUser(int @requestID, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[RequestID] int,
	[UserID] int
);

UPDATE [dbo].[Mall_CheckRequestUser] SET 
 
output 
	INSERTED.[RequestID],
	INSERTED.[UserID]
into @table
WHERE 
	[Mall_CheckRequestUser].[RequestID] = @RequestID
	AND [Mall_CheckRequestUser].[UserID] = @UserID

SELECT 
	[RequestID],
	[UserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RequestID", EntityBase.GetDatabaseValue(@requestID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_CheckRequestUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="requestID">requestID</param>
		/// <param name="userID">userID</param>
		public static void DeleteMall_CheckRequestUser(int @requestID, int @userID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_CheckRequestUser(@requestID, @userID, helper);
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
		/// Deletes a Mall_CheckRequestUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="requestID">requestID</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_CheckRequestUser(int @requestID, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_CheckRequestUser]
WHERE 
	[Mall_CheckRequestUser].[RequestID] = @RequestID
	AND [Mall_CheckRequestUser].[UserID] = @UserID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RequestID", @requestID));
			parameters.Add(new SqlParameter("@UserID", @userID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_CheckRequestUser object.
		/// </summary>
		/// <returns>The newly created Mall_CheckRequestUser object.</returns>
		public static Mall_CheckRequestUser CreateMall_CheckRequestUser()
		{
			return InitializeNew<Mall_CheckRequestUser>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_CheckRequestUser by a Mall_CheckRequestUser's unique identifier.
		/// </summary>
		/// <param name="requestID">requestID</param>
		/// <param name="userID">userID</param>
		/// <returns>Mall_CheckRequestUser</returns>
		public static Mall_CheckRequestUser GetMall_CheckRequestUser(int @requestID, int @userID)
		{
			string commandText = @"
SELECT 
" + Mall_CheckRequestUser.SelectFieldList + @"
FROM [dbo].[Mall_CheckRequestUser] 
WHERE 
	[Mall_CheckRequestUser].[RequestID] = @RequestID
	AND [Mall_CheckRequestUser].[UserID] = @UserID " + Mall_CheckRequestUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RequestID", @requestID));
			parameters.Add(new SqlParameter("@UserID", @userID));
			
			return GetOne<Mall_CheckRequestUser>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_CheckRequestUser by a Mall_CheckRequestUser's unique identifier.
		/// </summary>
		/// <param name="requestID">requestID</param>
		/// <param name="userID">userID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_CheckRequestUser</returns>
		public static Mall_CheckRequestUser GetMall_CheckRequestUser(int @requestID, int @userID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_CheckRequestUser.SelectFieldList + @"
FROM [dbo].[Mall_CheckRequestUser] 
WHERE 
	[Mall_CheckRequestUser].[RequestID] = @RequestID
	AND [Mall_CheckRequestUser].[UserID] = @UserID " + Mall_CheckRequestUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RequestID", @requestID));
			parameters.Add(new SqlParameter("@UserID", @userID));
			
			return GetOne<Mall_CheckRequestUser>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestUser objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_CheckRequestUser objects.</returns>
		public static EntityList<Mall_CheckRequestUser> GetMall_CheckRequestUsers()
		{
			string commandText = @"
SELECT " + Mall_CheckRequestUser.SelectFieldList + "FROM [dbo].[Mall_CheckRequestUser] " + Mall_CheckRequestUser.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_CheckRequestUser>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_CheckRequestUser objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_CheckRequestUser objects.</returns>
        public static EntityList<Mall_CheckRequestUser> GetMall_CheckRequestUsers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckRequestUser>(SelectFieldList, "FROM [dbo].[Mall_CheckRequestUser]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_CheckRequestUser objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_CheckRequestUser objects.</returns>
        public static EntityList<Mall_CheckRequestUser> GetMall_CheckRequestUsers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckRequestUser>(SelectFieldList, "FROM [dbo].[Mall_CheckRequestUser]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_CheckRequestUser objects.</returns>
		protected static EntityList<Mall_CheckRequestUser> GetMall_CheckRequestUsers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckRequestUsers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequestUser objects.</returns>
		protected static EntityList<Mall_CheckRequestUser> GetMall_CheckRequestUsers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckRequestUsers(string.Empty, where, parameters, Mall_CheckRequestUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequestUser objects.</returns>
		protected static EntityList<Mall_CheckRequestUser> GetMall_CheckRequestUsers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckRequestUsers(prefix, where, parameters, Mall_CheckRequestUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequestUser objects.</returns>
		protected static EntityList<Mall_CheckRequestUser> GetMall_CheckRequestUsers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_CheckRequestUsers(string.Empty, where, parameters, Mall_CheckRequestUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequestUser objects.</returns>
		protected static EntityList<Mall_CheckRequestUser> GetMall_CheckRequestUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_CheckRequestUsers(prefix, where, parameters, Mall_CheckRequestUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestUser objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_CheckRequestUser objects.</returns>
		protected static EntityList<Mall_CheckRequestUser> GetMall_CheckRequestUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_CheckRequestUser.SelectFieldList + "FROM [dbo].[Mall_CheckRequestUser] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_CheckRequestUser>(reader);
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
        protected static EntityList<Mall_CheckRequestUser> GetMall_CheckRequestUsers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckRequestUser>(SelectFieldList, "FROM [dbo].[Mall_CheckRequestUser] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_CheckRequestUser objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CheckRequestUserCount()
        {
            return GetMall_CheckRequestUserCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_CheckRequestUser objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CheckRequestUserCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_CheckRequestUser] " + where;

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
		public static partial class Mall_CheckRequestUser_Properties
		{
			public const string RequestID = "RequestID";
			public const string UserID = "UserID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"RequestID" , "int:"},
    			 {"UserID" , "int:"},
            };
		}
		#endregion
	}
}
