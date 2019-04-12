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
	/// This object represents the properties and methods of a RoleCKCategory.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class RoleCKCategory 
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
		private int _cKCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CKCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._cKCategoryID; }
			set 
			{
				if (this._cKCategoryID != value) 
				{
					this._cKCategoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CKCategoryID");
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
	[RoleID] int,
	[CKCategoryID] int,
	[UserID] int
);

INSERT INTO [dbo].[RoleCKCategory] (
	[RoleCKCategory].[RoleID],
	[RoleCKCategory].[CKCategoryID],
	[RoleCKCategory].[UserID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoleID],
	INSERTED.[CKCategoryID],
	INSERTED.[UserID]
into @table
VALUES ( 
	@RoleID,
	@CKCategoryID,
	@UserID 
); 

SELECT 
	[ID],
	[RoleID],
	[CKCategoryID],
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
	[RoleID] int,
	[CKCategoryID] int,
	[UserID] int
);

UPDATE [dbo].[RoleCKCategory] SET 
	[RoleCKCategory].[RoleID] = @RoleID,
	[RoleCKCategory].[CKCategoryID] = @CKCategoryID,
	[RoleCKCategory].[UserID] = @UserID 
output 
	INSERTED.[ID],
	INSERTED.[RoleID],
	INSERTED.[CKCategoryID],
	INSERTED.[UserID]
into @table
WHERE 
	[RoleCKCategory].[ID] = @ID

SELECT 
	[ID],
	[RoleID],
	[CKCategoryID],
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
DELETE FROM [dbo].[RoleCKCategory]
WHERE 
	[RoleCKCategory].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public RoleCKCategory() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetRoleCKCategory(this.ID));
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
	[RoleCKCategory].[ID],
	[RoleCKCategory].[RoleID],
	[RoleCKCategory].[CKCategoryID],
	[RoleCKCategory].[UserID]
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
                return "RoleCKCategory";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a RoleCKCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleID">roleID</param>
		/// <param name="cKCategoryID">cKCategoryID</param>
		/// <param name="userID">userID</param>
		public static void InsertRoleCKCategory(int @roleID, int @cKCategoryID, int @userID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertRoleCKCategory(@roleID, @cKCategoryID, @userID, helper);
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
		/// Insert a RoleCKCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleID">roleID</param>
		/// <param name="cKCategoryID">cKCategoryID</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void InsertRoleCKCategory(int @roleID, int @cKCategoryID, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoleID] int,
	[CKCategoryID] int,
	[UserID] int
);

INSERT INTO [dbo].[RoleCKCategory] (
	[RoleCKCategory].[RoleID],
	[RoleCKCategory].[CKCategoryID],
	[RoleCKCategory].[UserID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoleID],
	INSERTED.[CKCategoryID],
	INSERTED.[UserID]
into @table
VALUES ( 
	@RoleID,
	@CKCategoryID,
	@UserID 
); 

SELECT 
	[ID],
	[RoleID],
	[CKCategoryID],
	[UserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoleID", EntityBase.GetDatabaseValue(@roleID)));
			parameters.Add(new SqlParameter("@CKCategoryID", EntityBase.GetDatabaseValue(@cKCategoryID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a RoleCKCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roleID">roleID</param>
		/// <param name="cKCategoryID">cKCategoryID</param>
		/// <param name="userID">userID</param>
		public static void UpdateRoleCKCategory(int @iD, int @roleID, int @cKCategoryID, int @userID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateRoleCKCategory(@iD, @roleID, @cKCategoryID, @userID, helper);
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
		/// Updates a RoleCKCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roleID">roleID</param>
		/// <param name="cKCategoryID">cKCategoryID</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateRoleCKCategory(int @iD, int @roleID, int @cKCategoryID, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoleID] int,
	[CKCategoryID] int,
	[UserID] int
);

UPDATE [dbo].[RoleCKCategory] SET 
	[RoleCKCategory].[RoleID] = @RoleID,
	[RoleCKCategory].[CKCategoryID] = @CKCategoryID,
	[RoleCKCategory].[UserID] = @UserID 
output 
	INSERTED.[ID],
	INSERTED.[RoleID],
	INSERTED.[CKCategoryID],
	INSERTED.[UserID]
into @table
WHERE 
	[RoleCKCategory].[ID] = @ID

SELECT 
	[ID],
	[RoleID],
	[CKCategoryID],
	[UserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoleID", EntityBase.GetDatabaseValue(@roleID)));
			parameters.Add(new SqlParameter("@CKCategoryID", EntityBase.GetDatabaseValue(@cKCategoryID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a RoleCKCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteRoleCKCategory(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteRoleCKCategory(@iD, helper);
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
		/// Deletes a RoleCKCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteRoleCKCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[RoleCKCategory]
WHERE 
	[RoleCKCategory].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new RoleCKCategory object.
		/// </summary>
		/// <returns>The newly created RoleCKCategory object.</returns>
		public static RoleCKCategory CreateRoleCKCategory()
		{
			return InitializeNew<RoleCKCategory>();
		}
		
		/// <summary>
		/// Retrieve information for a RoleCKCategory by a RoleCKCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>RoleCKCategory</returns>
		public static RoleCKCategory GetRoleCKCategory(int @iD)
		{
			string commandText = @"
SELECT 
" + RoleCKCategory.SelectFieldList + @"
FROM [dbo].[RoleCKCategory] 
WHERE 
	[RoleCKCategory].[ID] = @ID " + RoleCKCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoleCKCategory>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a RoleCKCategory by a RoleCKCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>RoleCKCategory</returns>
		public static RoleCKCategory GetRoleCKCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + RoleCKCategory.SelectFieldList + @"
FROM [dbo].[RoleCKCategory] 
WHERE 
	[RoleCKCategory].[ID] = @ID " + RoleCKCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoleCKCategory>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection RoleCKCategory objects.
		/// </summary>
		/// <returns>The retrieved collection of RoleCKCategory objects.</returns>
		public static EntityList<RoleCKCategory> GetRoleCKCategories()
		{
			string commandText = @"
SELECT " + RoleCKCategory.SelectFieldList + "FROM [dbo].[RoleCKCategory] " + RoleCKCategory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<RoleCKCategory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection RoleCKCategory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoleCKCategory objects.</returns>
        public static EntityList<RoleCKCategory> GetRoleCKCategories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoleCKCategory>(SelectFieldList, "FROM [dbo].[RoleCKCategory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection RoleCKCategory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoleCKCategory objects.</returns>
        public static EntityList<RoleCKCategory> GetRoleCKCategories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoleCKCategory>(SelectFieldList, "FROM [dbo].[RoleCKCategory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection RoleCKCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of RoleCKCategory objects.</returns>
		protected static EntityList<RoleCKCategory> GetRoleCKCategories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoleCKCategories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection RoleCKCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoleCKCategory objects.</returns>
		protected static EntityList<RoleCKCategory> GetRoleCKCategories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoleCKCategories(string.Empty, where, parameters, RoleCKCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoleCKCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoleCKCategory objects.</returns>
		protected static EntityList<RoleCKCategory> GetRoleCKCategories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoleCKCategories(prefix, where, parameters, RoleCKCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoleCKCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoleCKCategory objects.</returns>
		protected static EntityList<RoleCKCategory> GetRoleCKCategories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoleCKCategories(string.Empty, where, parameters, RoleCKCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoleCKCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoleCKCategory objects.</returns>
		protected static EntityList<RoleCKCategory> GetRoleCKCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoleCKCategories(prefix, where, parameters, RoleCKCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoleCKCategory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of RoleCKCategory objects.</returns>
		protected static EntityList<RoleCKCategory> GetRoleCKCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + RoleCKCategory.SelectFieldList + "FROM [dbo].[RoleCKCategory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<RoleCKCategory>(reader);
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
        protected static EntityList<RoleCKCategory> GetRoleCKCategories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoleCKCategory>(SelectFieldList, "FROM [dbo].[RoleCKCategory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of RoleCKCategory objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoleCKCategoryCount()
        {
            return GetRoleCKCategoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of RoleCKCategory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoleCKCategoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[RoleCKCategory] " + where;

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
		public static partial class RoleCKCategory_Properties
		{
			public const string ID = "ID";
			public const string RoleID = "RoleID";
			public const string CKCategoryID = "CKCategoryID";
			public const string UserID = "UserID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoleID" , "int:"},
    			 {"CKCategoryID" , "int:"},
    			 {"UserID" , "int:"},
            };
		}
		#endregion
	}
}
