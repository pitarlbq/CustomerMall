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
	/// This object represents the properties and methods of a Wechat_ChatRequest.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_ChatRequest 
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
		private DateTime _acceptTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime AcceptTime
		{
			[DebuggerStepThrough()]
			get { return this._acceptTime; }
			set 
			{
				if (this._acceptTime != value) 
				{
					this._acceptTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("AcceptTime");
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
	[OpenID] nvarchar(500),
	[UserID] int,
	[AddTime] datetime,
	[AcceptTime] datetime
);

INSERT INTO [dbo].[Wechat_ChatRequest] (
	[Wechat_ChatRequest].[OpenID],
	[Wechat_ChatRequest].[UserID],
	[Wechat_ChatRequest].[AddTime],
	[Wechat_ChatRequest].[AcceptTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[OpenID],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[AcceptTime]
into @table
VALUES ( 
	@OpenID,
	@UserID,
	@AddTime,
	@AcceptTime 
); 

SELECT 
	[ID],
	[OpenID],
	[UserID],
	[AddTime],
	[AcceptTime] 
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
	[OpenID] nvarchar(500),
	[UserID] int,
	[AddTime] datetime,
	[AcceptTime] datetime
);

UPDATE [dbo].[Wechat_ChatRequest] SET 
	[Wechat_ChatRequest].[OpenID] = @OpenID,
	[Wechat_ChatRequest].[UserID] = @UserID,
	[Wechat_ChatRequest].[AddTime] = @AddTime,
	[Wechat_ChatRequest].[AcceptTime] = @AcceptTime 
output 
	INSERTED.[ID],
	INSERTED.[OpenID],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[AcceptTime]
into @table
WHERE 
	[Wechat_ChatRequest].[ID] = @ID

SELECT 
	[ID],
	[OpenID],
	[UserID],
	[AddTime],
	[AcceptTime] 
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
DELETE FROM [dbo].[Wechat_ChatRequest]
WHERE 
	[Wechat_ChatRequest].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_ChatRequest() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_ChatRequest(this.ID));
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
	[Wechat_ChatRequest].[ID],
	[Wechat_ChatRequest].[OpenID],
	[Wechat_ChatRequest].[UserID],
	[Wechat_ChatRequest].[AddTime],
	[Wechat_ChatRequest].[AcceptTime]
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
                return "Wechat_ChatRequest";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_ChatRequest into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="openID">openID</param>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="acceptTime">acceptTime</param>
		public static void InsertWechat_ChatRequest(string @openID, int @userID, DateTime @addTime, DateTime @acceptTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_ChatRequest(@openID, @userID, @addTime, @acceptTime, helper);
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
		/// Insert a Wechat_ChatRequest into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="openID">openID</param>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="acceptTime">acceptTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_ChatRequest(string @openID, int @userID, DateTime @addTime, DateTime @acceptTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OpenID] nvarchar(500),
	[UserID] int,
	[AddTime] datetime,
	[AcceptTime] datetime
);

INSERT INTO [dbo].[Wechat_ChatRequest] (
	[Wechat_ChatRequest].[OpenID],
	[Wechat_ChatRequest].[UserID],
	[Wechat_ChatRequest].[AddTime],
	[Wechat_ChatRequest].[AcceptTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[OpenID],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[AcceptTime]
into @table
VALUES ( 
	@OpenID,
	@UserID,
	@AddTime,
	@AcceptTime 
); 

SELECT 
	[ID],
	[OpenID],
	[UserID],
	[AddTime],
	[AcceptTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AcceptTime", EntityBase.GetDatabaseValue(@acceptTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_ChatRequest into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="openID">openID</param>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="acceptTime">acceptTime</param>
		public static void UpdateWechat_ChatRequest(int @iD, string @openID, int @userID, DateTime @addTime, DateTime @acceptTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_ChatRequest(@iD, @openID, @userID, @addTime, @acceptTime, helper);
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
		/// Updates a Wechat_ChatRequest into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="openID">openID</param>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="acceptTime">acceptTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_ChatRequest(int @iD, string @openID, int @userID, DateTime @addTime, DateTime @acceptTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OpenID] nvarchar(500),
	[UserID] int,
	[AddTime] datetime,
	[AcceptTime] datetime
);

UPDATE [dbo].[Wechat_ChatRequest] SET 
	[Wechat_ChatRequest].[OpenID] = @OpenID,
	[Wechat_ChatRequest].[UserID] = @UserID,
	[Wechat_ChatRequest].[AddTime] = @AddTime,
	[Wechat_ChatRequest].[AcceptTime] = @AcceptTime 
output 
	INSERTED.[ID],
	INSERTED.[OpenID],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[AcceptTime]
into @table
WHERE 
	[Wechat_ChatRequest].[ID] = @ID

SELECT 
	[ID],
	[OpenID],
	[UserID],
	[AddTime],
	[AcceptTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AcceptTime", EntityBase.GetDatabaseValue(@acceptTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_ChatRequest from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_ChatRequest(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_ChatRequest(@iD, helper);
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
		/// Deletes a Wechat_ChatRequest from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_ChatRequest(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_ChatRequest]
WHERE 
	[Wechat_ChatRequest].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_ChatRequest object.
		/// </summary>
		/// <returns>The newly created Wechat_ChatRequest object.</returns>
		public static Wechat_ChatRequest CreateWechat_ChatRequest()
		{
			return InitializeNew<Wechat_ChatRequest>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_ChatRequest by a Wechat_ChatRequest's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_ChatRequest</returns>
		public static Wechat_ChatRequest GetWechat_ChatRequest(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_ChatRequest.SelectFieldList + @"
FROM [dbo].[Wechat_ChatRequest] 
WHERE 
	[Wechat_ChatRequest].[ID] = @ID " + Wechat_ChatRequest.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_ChatRequest>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_ChatRequest by a Wechat_ChatRequest's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_ChatRequest</returns>
		public static Wechat_ChatRequest GetWechat_ChatRequest(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_ChatRequest.SelectFieldList + @"
FROM [dbo].[Wechat_ChatRequest] 
WHERE 
	[Wechat_ChatRequest].[ID] = @ID " + Wechat_ChatRequest.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_ChatRequest>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ChatRequest objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_ChatRequest objects.</returns>
		public static EntityList<Wechat_ChatRequest> GetWechat_ChatRequests()
		{
			string commandText = @"
SELECT " + Wechat_ChatRequest.SelectFieldList + "FROM [dbo].[Wechat_ChatRequest] " + Wechat_ChatRequest.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_ChatRequest>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_ChatRequest objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_ChatRequest objects.</returns>
        public static EntityList<Wechat_ChatRequest> GetWechat_ChatRequests(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_ChatRequest>(SelectFieldList, "FROM [dbo].[Wechat_ChatRequest]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_ChatRequest objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_ChatRequest objects.</returns>
        public static EntityList<Wechat_ChatRequest> GetWechat_ChatRequests(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_ChatRequest>(SelectFieldList, "FROM [dbo].[Wechat_ChatRequest]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_ChatRequest objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_ChatRequest objects.</returns>
		protected static EntityList<Wechat_ChatRequest> GetWechat_ChatRequests(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_ChatRequests(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ChatRequest objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ChatRequest objects.</returns>
		protected static EntityList<Wechat_ChatRequest> GetWechat_ChatRequests(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_ChatRequests(string.Empty, where, parameters, Wechat_ChatRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ChatRequest objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ChatRequest objects.</returns>
		protected static EntityList<Wechat_ChatRequest> GetWechat_ChatRequests(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_ChatRequests(prefix, where, parameters, Wechat_ChatRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ChatRequest objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ChatRequest objects.</returns>
		protected static EntityList<Wechat_ChatRequest> GetWechat_ChatRequests(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_ChatRequests(string.Empty, where, parameters, Wechat_ChatRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ChatRequest objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ChatRequest objects.</returns>
		protected static EntityList<Wechat_ChatRequest> GetWechat_ChatRequests(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_ChatRequests(prefix, where, parameters, Wechat_ChatRequest.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ChatRequest objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_ChatRequest objects.</returns>
		protected static EntityList<Wechat_ChatRequest> GetWechat_ChatRequests(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_ChatRequest.SelectFieldList + "FROM [dbo].[Wechat_ChatRequest] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_ChatRequest>(reader);
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
        protected static EntityList<Wechat_ChatRequest> GetWechat_ChatRequests(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_ChatRequest>(SelectFieldList, "FROM [dbo].[Wechat_ChatRequest] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_ChatRequest objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_ChatRequestCount()
        {
            return GetWechat_ChatRequestCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_ChatRequest objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_ChatRequestCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_ChatRequest] " + where;

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
		public static partial class Wechat_ChatRequest_Properties
		{
			public const string ID = "ID";
			public const string OpenID = "OpenID";
			public const string UserID = "UserID";
			public const string AddTime = "AddTime";
			public const string AcceptTime = "AcceptTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OpenID" , "string:"},
    			 {"UserID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AcceptTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
