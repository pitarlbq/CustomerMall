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
	/// This object represents the properties and methods of a Mall_ThreadComment.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_ThreadComment 
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
		private int _threadID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ThreadID
		{
			[DebuggerStepThrough()]
			get { return this._threadID; }
			set 
			{
				if (this._threadID != value) 
				{
					this._threadID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ThreadID");
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
		[DataObjectField(false, false, false)]
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
		private string _comment = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Comment
		{
			[DebuggerStepThrough()]
			get { return this._comment; }
			set 
			{
				if (this._comment != value) 
				{
					this._comment = value;
					this.IsDirty = true;	
					OnPropertyChanged("Comment");
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
		private int _responseUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ResponseUserID
		{
			[DebuggerStepThrough()]
			get { return this._responseUserID; }
			set 
			{
				if (this._responseUserID != value) 
				{
					this._responseUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ResponseUserID");
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
	[ThreadID] int,
	[UserID] int,
	[Comment] ntext,
	[AddTime] datetime,
	[ResponseUserID] int
);

INSERT INTO [dbo].[Mall_ThreadComment] (
	[Mall_ThreadComment].[ThreadID],
	[Mall_ThreadComment].[UserID],
	[Mall_ThreadComment].[Comment],
	[Mall_ThreadComment].[AddTime],
	[Mall_ThreadComment].[ResponseUserID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ThreadID],
	INSERTED.[UserID],
	INSERTED.[Comment],
	INSERTED.[AddTime],
	INSERTED.[ResponseUserID]
into @table
VALUES ( 
	@ThreadID,
	@UserID,
	@Comment,
	@AddTime,
	@ResponseUserID 
); 

SELECT 
	[ID],
	[ThreadID],
	[UserID],
	[Comment],
	[AddTime],
	[ResponseUserID] 
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
	[ThreadID] int,
	[UserID] int,
	[Comment] ntext,
	[AddTime] datetime,
	[ResponseUserID] int
);

UPDATE [dbo].[Mall_ThreadComment] SET 
	[Mall_ThreadComment].[ThreadID] = @ThreadID,
	[Mall_ThreadComment].[UserID] = @UserID,
	[Mall_ThreadComment].[Comment] = @Comment,
	[Mall_ThreadComment].[AddTime] = @AddTime,
	[Mall_ThreadComment].[ResponseUserID] = @ResponseUserID 
output 
	INSERTED.[ID],
	INSERTED.[ThreadID],
	INSERTED.[UserID],
	INSERTED.[Comment],
	INSERTED.[AddTime],
	INSERTED.[ResponseUserID]
into @table
WHERE 
	[Mall_ThreadComment].[ID] = @ID

SELECT 
	[ID],
	[ThreadID],
	[UserID],
	[Comment],
	[AddTime],
	[ResponseUserID] 
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
DELETE FROM [dbo].[Mall_ThreadComment]
WHERE 
	[Mall_ThreadComment].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_ThreadComment() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_ThreadComment(this.ID));
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
	[Mall_ThreadComment].[ID],
	[Mall_ThreadComment].[ThreadID],
	[Mall_ThreadComment].[UserID],
	[Mall_ThreadComment].[Comment],
	[Mall_ThreadComment].[AddTime],
	[Mall_ThreadComment].[ResponseUserID]
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
                return "Mall_ThreadComment";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_ThreadComment into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="threadID">threadID</param>
		/// <param name="userID">userID</param>
		/// <param name="comment">comment</param>
		/// <param name="addTime">addTime</param>
		/// <param name="responseUserID">responseUserID</param>
		public static void InsertMall_ThreadComment(int @threadID, int @userID, string @comment, DateTime @addTime, int @responseUserID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_ThreadComment(@threadID, @userID, @comment, @addTime, @responseUserID, helper);
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
		/// Insert a Mall_ThreadComment into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="threadID">threadID</param>
		/// <param name="userID">userID</param>
		/// <param name="comment">comment</param>
		/// <param name="addTime">addTime</param>
		/// <param name="responseUserID">responseUserID</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_ThreadComment(int @threadID, int @userID, string @comment, DateTime @addTime, int @responseUserID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ThreadID] int,
	[UserID] int,
	[Comment] ntext,
	[AddTime] datetime,
	[ResponseUserID] int
);

INSERT INTO [dbo].[Mall_ThreadComment] (
	[Mall_ThreadComment].[ThreadID],
	[Mall_ThreadComment].[UserID],
	[Mall_ThreadComment].[Comment],
	[Mall_ThreadComment].[AddTime],
	[Mall_ThreadComment].[ResponseUserID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ThreadID],
	INSERTED.[UserID],
	INSERTED.[Comment],
	INSERTED.[AddTime],
	INSERTED.[ResponseUserID]
into @table
VALUES ( 
	@ThreadID,
	@UserID,
	@Comment,
	@AddTime,
	@ResponseUserID 
); 

SELECT 
	[ID],
	[ThreadID],
	[UserID],
	[Comment],
	[AddTime],
	[ResponseUserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ThreadID", EntityBase.GetDatabaseValue(@threadID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@Comment", EntityBase.GetDatabaseValue(@comment)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ResponseUserID", EntityBase.GetDatabaseValue(@responseUserID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_ThreadComment into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="threadID">threadID</param>
		/// <param name="userID">userID</param>
		/// <param name="comment">comment</param>
		/// <param name="addTime">addTime</param>
		/// <param name="responseUserID">responseUserID</param>
		public static void UpdateMall_ThreadComment(int @iD, int @threadID, int @userID, string @comment, DateTime @addTime, int @responseUserID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_ThreadComment(@iD, @threadID, @userID, @comment, @addTime, @responseUserID, helper);
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
		/// Updates a Mall_ThreadComment into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="threadID">threadID</param>
		/// <param name="userID">userID</param>
		/// <param name="comment">comment</param>
		/// <param name="addTime">addTime</param>
		/// <param name="responseUserID">responseUserID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_ThreadComment(int @iD, int @threadID, int @userID, string @comment, DateTime @addTime, int @responseUserID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ThreadID] int,
	[UserID] int,
	[Comment] ntext,
	[AddTime] datetime,
	[ResponseUserID] int
);

UPDATE [dbo].[Mall_ThreadComment] SET 
	[Mall_ThreadComment].[ThreadID] = @ThreadID,
	[Mall_ThreadComment].[UserID] = @UserID,
	[Mall_ThreadComment].[Comment] = @Comment,
	[Mall_ThreadComment].[AddTime] = @AddTime,
	[Mall_ThreadComment].[ResponseUserID] = @ResponseUserID 
output 
	INSERTED.[ID],
	INSERTED.[ThreadID],
	INSERTED.[UserID],
	INSERTED.[Comment],
	INSERTED.[AddTime],
	INSERTED.[ResponseUserID]
into @table
WHERE 
	[Mall_ThreadComment].[ID] = @ID

SELECT 
	[ID],
	[ThreadID],
	[UserID],
	[Comment],
	[AddTime],
	[ResponseUserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ThreadID", EntityBase.GetDatabaseValue(@threadID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@Comment", EntityBase.GetDatabaseValue(@comment)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ResponseUserID", EntityBase.GetDatabaseValue(@responseUserID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_ThreadComment from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_ThreadComment(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_ThreadComment(@iD, helper);
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
		/// Deletes a Mall_ThreadComment from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_ThreadComment(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_ThreadComment]
WHERE 
	[Mall_ThreadComment].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_ThreadComment object.
		/// </summary>
		/// <returns>The newly created Mall_ThreadComment object.</returns>
		public static Mall_ThreadComment CreateMall_ThreadComment()
		{
			return InitializeNew<Mall_ThreadComment>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_ThreadComment by a Mall_ThreadComment's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_ThreadComment</returns>
		public static Mall_ThreadComment GetMall_ThreadComment(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_ThreadComment.SelectFieldList + @"
FROM [dbo].[Mall_ThreadComment] 
WHERE 
	[Mall_ThreadComment].[ID] = @ID " + Mall_ThreadComment.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ThreadComment>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_ThreadComment by a Mall_ThreadComment's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_ThreadComment</returns>
		public static Mall_ThreadComment GetMall_ThreadComment(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_ThreadComment.SelectFieldList + @"
FROM [dbo].[Mall_ThreadComment] 
WHERE 
	[Mall_ThreadComment].[ID] = @ID " + Mall_ThreadComment.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ThreadComment>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_ThreadComment objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_ThreadComment objects.</returns>
		public static EntityList<Mall_ThreadComment> GetMall_ThreadComments()
		{
			string commandText = @"
SELECT " + Mall_ThreadComment.SelectFieldList + "FROM [dbo].[Mall_ThreadComment] " + Mall_ThreadComment.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_ThreadComment>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_ThreadComment objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ThreadComment objects.</returns>
        public static EntityList<Mall_ThreadComment> GetMall_ThreadComments(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ThreadComment>(SelectFieldList, "FROM [dbo].[Mall_ThreadComment]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_ThreadComment objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ThreadComment objects.</returns>
        public static EntityList<Mall_ThreadComment> GetMall_ThreadComments(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ThreadComment>(SelectFieldList, "FROM [dbo].[Mall_ThreadComment]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_ThreadComment objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ThreadComment objects.</returns>
		protected static EntityList<Mall_ThreadComment> GetMall_ThreadComments(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ThreadComments(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_ThreadComment objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ThreadComment objects.</returns>
		protected static EntityList<Mall_ThreadComment> GetMall_ThreadComments(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ThreadComments(string.Empty, where, parameters, Mall_ThreadComment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ThreadComment objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ThreadComment objects.</returns>
		protected static EntityList<Mall_ThreadComment> GetMall_ThreadComments(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ThreadComments(prefix, where, parameters, Mall_ThreadComment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ThreadComment objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ThreadComment objects.</returns>
		protected static EntityList<Mall_ThreadComment> GetMall_ThreadComments(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ThreadComments(string.Empty, where, parameters, Mall_ThreadComment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ThreadComment objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ThreadComment objects.</returns>
		protected static EntityList<Mall_ThreadComment> GetMall_ThreadComments(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ThreadComments(prefix, where, parameters, Mall_ThreadComment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ThreadComment objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ThreadComment objects.</returns>
		protected static EntityList<Mall_ThreadComment> GetMall_ThreadComments(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_ThreadComment.SelectFieldList + "FROM [dbo].[Mall_ThreadComment] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_ThreadComment>(reader);
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
        protected static EntityList<Mall_ThreadComment> GetMall_ThreadComments(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ThreadComment>(SelectFieldList, "FROM [dbo].[Mall_ThreadComment] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_ThreadComment objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ThreadCommentCount()
        {
            return GetMall_ThreadCommentCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_ThreadComment objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ThreadCommentCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_ThreadComment] " + where;

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
		public static partial class Mall_ThreadComment_Properties
		{
			public const string ID = "ID";
			public const string ThreadID = "ThreadID";
			public const string UserID = "UserID";
			public const string Comment = "Comment";
			public const string AddTime = "AddTime";
			public const string ResponseUserID = "ResponseUserID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ThreadID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"Comment" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"ResponseUserID" , "int:"},
            };
		}
		#endregion
	}
}
