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
	/// This object represents the properties and methods of a CKAccpetUser.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("AccpetUserID: {AccpetUserID}")]
	public partial class CKAccpetUser 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _accpetUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, true, false)]
		public int AccpetUserID
		{
			[DebuggerStepThrough()]
			get { return this._accpetUserID; }
			 set 
			{
				if (this._accpetUserID != value) 
				{
					this._accpetUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AccpetUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _accpetUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AccpetUserName
		{
			[DebuggerStepThrough()]
			get { return this._accpetUserName; }
			set 
			{
				if (this._accpetUserName != value) 
				{
					this._accpetUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AccpetUserName");
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
	[AccpetUserID] int,
	[AccpetUserName] nvarchar(200)
);

INSERT INTO [dbo].[CKAccpetUser] (
	[CKAccpetUser].[AccpetUserName]
) 
output 
	INSERTED.[AccpetUserID],
	INSERTED.[AccpetUserName]
into @table
VALUES ( 
	@AccpetUserName 
); 

SELECT 
	[AccpetUserID],
	[AccpetUserName] 
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
	[AccpetUserID] int,
	[AccpetUserName] nvarchar(200)
);

UPDATE [dbo].[CKAccpetUser] SET 
	[CKAccpetUser].[AccpetUserName] = @AccpetUserName 
output 
	INSERTED.[AccpetUserID],
	INSERTED.[AccpetUserName]
into @table
WHERE 
	[CKAccpetUser].[AccpetUserID] = @AccpetUserID

SELECT 
	[AccpetUserID],
	[AccpetUserName] 
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
DELETE FROM [dbo].[CKAccpetUser]
WHERE 
	[CKAccpetUser].[AccpetUserID] = @AccpetUserID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CKAccpetUser() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCKAccpetUser(this.AccpetUserID));
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
	[CKAccpetUser].[AccpetUserID],
	[CKAccpetUser].[AccpetUserName]
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
                return "CKAccpetUser";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CKAccpetUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="accpetUserName">accpetUserName</param>
		public static void InsertCKAccpetUser(string @accpetUserName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCKAccpetUser(@accpetUserName, helper);
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
		/// Insert a CKAccpetUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="accpetUserName">accpetUserName</param>
		/// <param name="helper">helper</param>
		internal static void InsertCKAccpetUser(string @accpetUserName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[AccpetUserID] int,
	[AccpetUserName] nvarchar(200)
);

INSERT INTO [dbo].[CKAccpetUser] (
	[CKAccpetUser].[AccpetUserName]
) 
output 
	INSERTED.[AccpetUserID],
	INSERTED.[AccpetUserName]
into @table
VALUES ( 
	@AccpetUserName 
); 

SELECT 
	[AccpetUserID],
	[AccpetUserName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@AccpetUserName", EntityBase.GetDatabaseValue(@accpetUserName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CKAccpetUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="accpetUserID">accpetUserID</param>
		/// <param name="accpetUserName">accpetUserName</param>
		public static void UpdateCKAccpetUser(int @accpetUserID, string @accpetUserName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCKAccpetUser(@accpetUserID, @accpetUserName, helper);
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
		/// Updates a CKAccpetUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="accpetUserID">accpetUserID</param>
		/// <param name="accpetUserName">accpetUserName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCKAccpetUser(int @accpetUserID, string @accpetUserName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[AccpetUserID] int,
	[AccpetUserName] nvarchar(200)
);

UPDATE [dbo].[CKAccpetUser] SET 
	[CKAccpetUser].[AccpetUserName] = @AccpetUserName 
output 
	INSERTED.[AccpetUserID],
	INSERTED.[AccpetUserName]
into @table
WHERE 
	[CKAccpetUser].[AccpetUserID] = @AccpetUserID

SELECT 
	[AccpetUserID],
	[AccpetUserName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@AccpetUserID", EntityBase.GetDatabaseValue(@accpetUserID)));
			parameters.Add(new SqlParameter("@AccpetUserName", EntityBase.GetDatabaseValue(@accpetUserName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CKAccpetUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="accpetUserID">accpetUserID</param>
		public static void DeleteCKAccpetUser(int @accpetUserID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCKAccpetUser(@accpetUserID, helper);
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
		/// Deletes a CKAccpetUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="accpetUserID">accpetUserID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCKAccpetUser(int @accpetUserID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CKAccpetUser]
WHERE 
	[CKAccpetUser].[AccpetUserID] = @AccpetUserID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@AccpetUserID", @accpetUserID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CKAccpetUser object.
		/// </summary>
		/// <returns>The newly created CKAccpetUser object.</returns>
		public static CKAccpetUser CreateCKAccpetUser()
		{
			return InitializeNew<CKAccpetUser>();
		}
		
		/// <summary>
		/// Retrieve information for a CKAccpetUser by a CKAccpetUser's unique identifier.
		/// </summary>
		/// <param name="accpetUserID">accpetUserID</param>
		/// <returns>CKAccpetUser</returns>
		public static CKAccpetUser GetCKAccpetUser(int @accpetUserID)
		{
			string commandText = @"
SELECT 
" + CKAccpetUser.SelectFieldList + @"
FROM [dbo].[CKAccpetUser] 
WHERE 
	[CKAccpetUser].[AccpetUserID] = @AccpetUserID " + CKAccpetUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@AccpetUserID", @accpetUserID));
			
			return GetOne<CKAccpetUser>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CKAccpetUser by a CKAccpetUser's unique identifier.
		/// </summary>
		/// <param name="accpetUserID">accpetUserID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CKAccpetUser</returns>
		public static CKAccpetUser GetCKAccpetUser(int @accpetUserID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CKAccpetUser.SelectFieldList + @"
FROM [dbo].[CKAccpetUser] 
WHERE 
	[CKAccpetUser].[AccpetUserID] = @AccpetUserID " + CKAccpetUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@AccpetUserID", @accpetUserID));
			
			return GetOne<CKAccpetUser>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CKAccpetUser objects.
		/// </summary>
		/// <returns>The retrieved collection of CKAccpetUser objects.</returns>
		public static EntityList<CKAccpetUser> GetCKAccpetUsers()
		{
			string commandText = @"
SELECT " + CKAccpetUser.SelectFieldList + "FROM [dbo].[CKAccpetUser] " + CKAccpetUser.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CKAccpetUser>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CKAccpetUser objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKAccpetUser objects.</returns>
        public static EntityList<CKAccpetUser> GetCKAccpetUsers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKAccpetUser>(SelectFieldList, "FROM [dbo].[CKAccpetUser]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CKAccpetUser objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKAccpetUser objects.</returns>
        public static EntityList<CKAccpetUser> GetCKAccpetUsers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKAccpetUser>(SelectFieldList, "FROM [dbo].[CKAccpetUser]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CKAccpetUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CKAccpetUser objects.</returns>
		protected static EntityList<CKAccpetUser> GetCKAccpetUsers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKAccpetUsers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CKAccpetUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKAccpetUser objects.</returns>
		protected static EntityList<CKAccpetUser> GetCKAccpetUsers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKAccpetUsers(string.Empty, where, parameters, CKAccpetUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKAccpetUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKAccpetUser objects.</returns>
		protected static EntityList<CKAccpetUser> GetCKAccpetUsers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKAccpetUsers(prefix, where, parameters, CKAccpetUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKAccpetUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKAccpetUser objects.</returns>
		protected static EntityList<CKAccpetUser> GetCKAccpetUsers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKAccpetUsers(string.Empty, where, parameters, CKAccpetUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKAccpetUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKAccpetUser objects.</returns>
		protected static EntityList<CKAccpetUser> GetCKAccpetUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKAccpetUsers(prefix, where, parameters, CKAccpetUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKAccpetUser objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CKAccpetUser objects.</returns>
		protected static EntityList<CKAccpetUser> GetCKAccpetUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CKAccpetUser.SelectFieldList + "FROM [dbo].[CKAccpetUser] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CKAccpetUser>(reader);
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
        protected static EntityList<CKAccpetUser> GetCKAccpetUsers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKAccpetUser>(SelectFieldList, "FROM [dbo].[CKAccpetUser] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CKAccpetUser objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKAccpetUserCount()
        {
            return GetCKAccpetUserCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CKAccpetUser objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKAccpetUserCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CKAccpetUser] " + where;

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
		public static partial class CKAccpetUser_Properties
		{
			public const string AccpetUserID = "AccpetUserID";
			public const string AccpetUserName = "AccpetUserName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"AccpetUserID" , "int:"},
    			 {"AccpetUserName" , "string:"},
            };
		}
		#endregion
	}
}
