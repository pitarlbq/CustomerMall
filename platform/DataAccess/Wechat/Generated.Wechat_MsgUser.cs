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
	/// This object represents the properties and methods of a Wechat_MsgUser.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_MsgUser 
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
		private int _wechat_MsgID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int Wechat_MsgID
		{
			[DebuggerStepThrough()]
			get { return this._wechat_MsgID; }
			set 
			{
				if (this._wechat_MsgID != value) 
				{
					this._wechat_MsgID = value;
					this.IsDirty = true;	
					OnPropertyChanged("Wechat_MsgID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _openID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string OpenID
		{
			[DebuggerStepThrough()]
			get { return this._openID; }
			set 
			{
				if (this._openID != value) 
				{
					this._openID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OpenID");
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
	[Wechat_MsgID] int,
	[OpenID] nvarchar(500),
	[AddTime] datetime
);

INSERT INTO [dbo].[Wechat_MsgUser] (
	[Wechat_MsgUser].[Wechat_MsgID],
	[Wechat_MsgUser].[OpenID],
	[Wechat_MsgUser].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[Wechat_MsgID],
	INSERTED.[OpenID],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@Wechat_MsgID,
	@OpenID,
	@AddTime 
); 

SELECT 
	[ID],
	[Wechat_MsgID],
	[OpenID],
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
	[Wechat_MsgID] int,
	[OpenID] nvarchar(500),
	[AddTime] datetime
);

UPDATE [dbo].[Wechat_MsgUser] SET 
	[Wechat_MsgUser].[Wechat_MsgID] = @Wechat_MsgID,
	[Wechat_MsgUser].[OpenID] = @OpenID,
	[Wechat_MsgUser].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[Wechat_MsgID],
	INSERTED.[OpenID],
	INSERTED.[AddTime]
into @table
WHERE 
	[Wechat_MsgUser].[ID] = @ID

SELECT 
	[ID],
	[Wechat_MsgID],
	[OpenID],
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
DELETE FROM [dbo].[Wechat_MsgUser]
WHERE 
	[Wechat_MsgUser].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_MsgUser() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_MsgUser(this.ID));
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
	[Wechat_MsgUser].[ID],
	[Wechat_MsgUser].[Wechat_MsgID],
	[Wechat_MsgUser].[OpenID],
	[Wechat_MsgUser].[AddTime]
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
                return "Wechat_MsgUser";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_MsgUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="wechat_MsgID">wechat_MsgID</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		public static void InsertWechat_MsgUser(int @wechat_MsgID, string @openID, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_MsgUser(@wechat_MsgID, @openID, @addTime, helper);
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
		/// Insert a Wechat_MsgUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="wechat_MsgID">wechat_MsgID</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_MsgUser(int @wechat_MsgID, string @openID, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Wechat_MsgID] int,
	[OpenID] nvarchar(500),
	[AddTime] datetime
);

INSERT INTO [dbo].[Wechat_MsgUser] (
	[Wechat_MsgUser].[Wechat_MsgID],
	[Wechat_MsgUser].[OpenID],
	[Wechat_MsgUser].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[Wechat_MsgID],
	INSERTED.[OpenID],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@Wechat_MsgID,
	@OpenID,
	@AddTime 
); 

SELECT 
	[ID],
	[Wechat_MsgID],
	[OpenID],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Wechat_MsgID", EntityBase.GetDatabaseValue(@wechat_MsgID)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_MsgUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="wechat_MsgID">wechat_MsgID</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateWechat_MsgUser(int @iD, int @wechat_MsgID, string @openID, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_MsgUser(@iD, @wechat_MsgID, @openID, @addTime, helper);
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
		/// Updates a Wechat_MsgUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="wechat_MsgID">wechat_MsgID</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_MsgUser(int @iD, int @wechat_MsgID, string @openID, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Wechat_MsgID] int,
	[OpenID] nvarchar(500),
	[AddTime] datetime
);

UPDATE [dbo].[Wechat_MsgUser] SET 
	[Wechat_MsgUser].[Wechat_MsgID] = @Wechat_MsgID,
	[Wechat_MsgUser].[OpenID] = @OpenID,
	[Wechat_MsgUser].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[Wechat_MsgID],
	INSERTED.[OpenID],
	INSERTED.[AddTime]
into @table
WHERE 
	[Wechat_MsgUser].[ID] = @ID

SELECT 
	[ID],
	[Wechat_MsgID],
	[OpenID],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Wechat_MsgID", EntityBase.GetDatabaseValue(@wechat_MsgID)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_MsgUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_MsgUser(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_MsgUser(@iD, helper);
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
		/// Deletes a Wechat_MsgUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_MsgUser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_MsgUser]
WHERE 
	[Wechat_MsgUser].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_MsgUser object.
		/// </summary>
		/// <returns>The newly created Wechat_MsgUser object.</returns>
		public static Wechat_MsgUser CreateWechat_MsgUser()
		{
			return InitializeNew<Wechat_MsgUser>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_MsgUser by a Wechat_MsgUser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_MsgUser</returns>
		public static Wechat_MsgUser GetWechat_MsgUser(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_MsgUser.SelectFieldList + @"
FROM [dbo].[Wechat_MsgUser] 
WHERE 
	[Wechat_MsgUser].[ID] = @ID " + Wechat_MsgUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_MsgUser>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_MsgUser by a Wechat_MsgUser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_MsgUser</returns>
		public static Wechat_MsgUser GetWechat_MsgUser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_MsgUser.SelectFieldList + @"
FROM [dbo].[Wechat_MsgUser] 
WHERE 
	[Wechat_MsgUser].[ID] = @ID " + Wechat_MsgUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_MsgUser>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_MsgUser objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_MsgUser objects.</returns>
		public static EntityList<Wechat_MsgUser> GetWechat_MsgUsers()
		{
			string commandText = @"
SELECT " + Wechat_MsgUser.SelectFieldList + "FROM [dbo].[Wechat_MsgUser] " + Wechat_MsgUser.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_MsgUser>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_MsgUser objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_MsgUser objects.</returns>
        public static EntityList<Wechat_MsgUser> GetWechat_MsgUsers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_MsgUser>(SelectFieldList, "FROM [dbo].[Wechat_MsgUser]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_MsgUser objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_MsgUser objects.</returns>
        public static EntityList<Wechat_MsgUser> GetWechat_MsgUsers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_MsgUser>(SelectFieldList, "FROM [dbo].[Wechat_MsgUser]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_MsgUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_MsgUser objects.</returns>
		protected static EntityList<Wechat_MsgUser> GetWechat_MsgUsers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_MsgUsers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_MsgUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_MsgUser objects.</returns>
		protected static EntityList<Wechat_MsgUser> GetWechat_MsgUsers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_MsgUsers(string.Empty, where, parameters, Wechat_MsgUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_MsgUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_MsgUser objects.</returns>
		protected static EntityList<Wechat_MsgUser> GetWechat_MsgUsers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_MsgUsers(prefix, where, parameters, Wechat_MsgUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_MsgUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_MsgUser objects.</returns>
		protected static EntityList<Wechat_MsgUser> GetWechat_MsgUsers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_MsgUsers(string.Empty, where, parameters, Wechat_MsgUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_MsgUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_MsgUser objects.</returns>
		protected static EntityList<Wechat_MsgUser> GetWechat_MsgUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_MsgUsers(prefix, where, parameters, Wechat_MsgUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_MsgUser objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_MsgUser objects.</returns>
		protected static EntityList<Wechat_MsgUser> GetWechat_MsgUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_MsgUser.SelectFieldList + "FROM [dbo].[Wechat_MsgUser] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_MsgUser>(reader);
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
        protected static EntityList<Wechat_MsgUser> GetWechat_MsgUsers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_MsgUser>(SelectFieldList, "FROM [dbo].[Wechat_MsgUser] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_MsgUser objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_MsgUserCount()
        {
            return GetWechat_MsgUserCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_MsgUser objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_MsgUserCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_MsgUser] " + where;

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
		public static partial class Wechat_MsgUser_Properties
		{
			public const string ID = "ID";
			public const string Wechat_MsgID = "Wechat_MsgID";
			public const string OpenID = "OpenID";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Wechat_MsgID" , "int:"},
    			 {"OpenID" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
