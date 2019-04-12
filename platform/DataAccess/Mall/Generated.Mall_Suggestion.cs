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
	/// This object represents the properties and methods of a Mall_Suggestion.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_Suggestion 
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
		private string _summaryContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SummaryContent
		{
			[DebuggerStepThrough()]
			get { return this._summaryContent; }
			set 
			{
				if (this._summaryContent != value) 
				{
					this._summaryContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("SummaryContent");
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
	[UserID] int,
	[SummaryContent] ntext,
	[AddTime] datetime
);

INSERT INTO [dbo].[Mall_Suggestion] (
	[Mall_Suggestion].[UserID],
	[Mall_Suggestion].[SummaryContent],
	[Mall_Suggestion].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[SummaryContent],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@UserID,
	@SummaryContent,
	@AddTime 
); 

SELECT 
	[ID],
	[UserID],
	[SummaryContent],
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
	[UserID] int,
	[SummaryContent] ntext,
	[AddTime] datetime
);

UPDATE [dbo].[Mall_Suggestion] SET 
	[Mall_Suggestion].[UserID] = @UserID,
	[Mall_Suggestion].[SummaryContent] = @SummaryContent,
	[Mall_Suggestion].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[SummaryContent],
	INSERTED.[AddTime]
into @table
WHERE 
	[Mall_Suggestion].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[SummaryContent],
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
DELETE FROM [dbo].[Mall_Suggestion]
WHERE 
	[Mall_Suggestion].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_Suggestion() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_Suggestion(this.ID));
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
	[Mall_Suggestion].[ID],
	[Mall_Suggestion].[UserID],
	[Mall_Suggestion].[SummaryContent],
	[Mall_Suggestion].[AddTime]
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
                return "Mall_Suggestion";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_Suggestion into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="summaryContent">summaryContent</param>
		/// <param name="addTime">addTime</param>
		public static void InsertMall_Suggestion(int @userID, string @summaryContent, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_Suggestion(@userID, @summaryContent, @addTime, helper);
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
		/// Insert a Mall_Suggestion into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="summaryContent">summaryContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_Suggestion(int @userID, string @summaryContent, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[SummaryContent] ntext,
	[AddTime] datetime
);

INSERT INTO [dbo].[Mall_Suggestion] (
	[Mall_Suggestion].[UserID],
	[Mall_Suggestion].[SummaryContent],
	[Mall_Suggestion].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[SummaryContent],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@UserID,
	@SummaryContent,
	@AddTime 
); 

SELECT 
	[ID],
	[UserID],
	[SummaryContent],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@SummaryContent", EntityBase.GetDatabaseValue(@summaryContent)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_Suggestion into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="summaryContent">summaryContent</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateMall_Suggestion(int @iD, int @userID, string @summaryContent, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_Suggestion(@iD, @userID, @summaryContent, @addTime, helper);
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
		/// Updates a Mall_Suggestion into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="summaryContent">summaryContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_Suggestion(int @iD, int @userID, string @summaryContent, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[SummaryContent] ntext,
	[AddTime] datetime
);

UPDATE [dbo].[Mall_Suggestion] SET 
	[Mall_Suggestion].[UserID] = @UserID,
	[Mall_Suggestion].[SummaryContent] = @SummaryContent,
	[Mall_Suggestion].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[SummaryContent],
	INSERTED.[AddTime]
into @table
WHERE 
	[Mall_Suggestion].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[SummaryContent],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@SummaryContent", EntityBase.GetDatabaseValue(@summaryContent)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_Suggestion from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_Suggestion(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_Suggestion(@iD, helper);
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
		/// Deletes a Mall_Suggestion from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_Suggestion(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_Suggestion]
WHERE 
	[Mall_Suggestion].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_Suggestion object.
		/// </summary>
		/// <returns>The newly created Mall_Suggestion object.</returns>
		public static Mall_Suggestion CreateMall_Suggestion()
		{
			return InitializeNew<Mall_Suggestion>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_Suggestion by a Mall_Suggestion's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_Suggestion</returns>
		public static Mall_Suggestion GetMall_Suggestion(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_Suggestion.SelectFieldList + @"
FROM [dbo].[Mall_Suggestion] 
WHERE 
	[Mall_Suggestion].[ID] = @ID " + Mall_Suggestion.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Suggestion>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_Suggestion by a Mall_Suggestion's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_Suggestion</returns>
		public static Mall_Suggestion GetMall_Suggestion(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_Suggestion.SelectFieldList + @"
FROM [dbo].[Mall_Suggestion] 
WHERE 
	[Mall_Suggestion].[ID] = @ID " + Mall_Suggestion.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Suggestion>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_Suggestion objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_Suggestion objects.</returns>
		public static EntityList<Mall_Suggestion> GetMall_Suggestions()
		{
			string commandText = @"
SELECT " + Mall_Suggestion.SelectFieldList + "FROM [dbo].[Mall_Suggestion] " + Mall_Suggestion.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_Suggestion>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_Suggestion objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Suggestion objects.</returns>
        public static EntityList<Mall_Suggestion> GetMall_Suggestions(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Suggestion>(SelectFieldList, "FROM [dbo].[Mall_Suggestion]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_Suggestion objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Suggestion objects.</returns>
        public static EntityList<Mall_Suggestion> GetMall_Suggestions(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Suggestion>(SelectFieldList, "FROM [dbo].[Mall_Suggestion]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_Suggestion objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Suggestion objects.</returns>
		protected static EntityList<Mall_Suggestion> GetMall_Suggestions(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Suggestions(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_Suggestion objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Suggestion objects.</returns>
		protected static EntityList<Mall_Suggestion> GetMall_Suggestions(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Suggestions(string.Empty, where, parameters, Mall_Suggestion.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Suggestion objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Suggestion objects.</returns>
		protected static EntityList<Mall_Suggestion> GetMall_Suggestions(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Suggestions(prefix, where, parameters, Mall_Suggestion.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Suggestion objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Suggestion objects.</returns>
		protected static EntityList<Mall_Suggestion> GetMall_Suggestions(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Suggestions(string.Empty, where, parameters, Mall_Suggestion.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Suggestion objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Suggestion objects.</returns>
		protected static EntityList<Mall_Suggestion> GetMall_Suggestions(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Suggestions(prefix, where, parameters, Mall_Suggestion.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Suggestion objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Suggestion objects.</returns>
		protected static EntityList<Mall_Suggestion> GetMall_Suggestions(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_Suggestion.SelectFieldList + "FROM [dbo].[Mall_Suggestion] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_Suggestion>(reader);
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
        protected static EntityList<Mall_Suggestion> GetMall_Suggestions(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Suggestion>(SelectFieldList, "FROM [dbo].[Mall_Suggestion] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_Suggestion objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_SuggestionCount()
        {
            return GetMall_SuggestionCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_Suggestion objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_SuggestionCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_Suggestion] " + where;

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
		public static partial class Mall_Suggestion_Properties
		{
			public const string ID = "ID";
			public const string UserID = "UserID";
			public const string SummaryContent = "SummaryContent";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"SummaryContent" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
