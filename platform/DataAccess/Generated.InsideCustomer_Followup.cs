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
	/// This object represents the properties and methods of a InsideCustomer_Followup.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class InsideCustomer_Followup 
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
		private int _insideCustomerID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int InsideCustomerID
		{
			[DebuggerStepThrough()]
			get { return this._insideCustomerID; }
			set 
			{
				if (this._insideCustomerID != value) 
				{
					this._insideCustomerID = value;
					this.IsDirty = true;	
					OnPropertyChanged("InsideCustomerID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _followupContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FollowupContent
		{
			[DebuggerStepThrough()]
			get { return this._followupContent; }
			set 
			{
				if (this._followupContent != value) 
				{
					this._followupContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("FollowupContent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _followupDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime FollowupDate
		{
			[DebuggerStepThrough()]
			get { return this._followupDate; }
			set 
			{
				if (this._followupDate != value) 
				{
					this._followupDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("FollowupDate");
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
	[InsideCustomerID] int,
	[FollowupContent] ntext,
	[FollowupDate] datetime
);

INSERT INTO [dbo].[InsideCustomer_Followup] (
	[InsideCustomer_Followup].[InsideCustomerID],
	[InsideCustomer_Followup].[FollowupContent],
	[InsideCustomer_Followup].[FollowupDate]
) 
output 
	INSERTED.[ID],
	INSERTED.[InsideCustomerID],
	INSERTED.[FollowupContent],
	INSERTED.[FollowupDate]
into @table
VALUES ( 
	@InsideCustomerID,
	@FollowupContent,
	@FollowupDate 
); 

SELECT 
	[ID],
	[InsideCustomerID],
	[FollowupContent],
	[FollowupDate] 
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
	[InsideCustomerID] int,
	[FollowupContent] ntext,
	[FollowupDate] datetime
);

UPDATE [dbo].[InsideCustomer_Followup] SET 
	[InsideCustomer_Followup].[InsideCustomerID] = @InsideCustomerID,
	[InsideCustomer_Followup].[FollowupContent] = @FollowupContent,
	[InsideCustomer_Followup].[FollowupDate] = @FollowupDate 
output 
	INSERTED.[ID],
	INSERTED.[InsideCustomerID],
	INSERTED.[FollowupContent],
	INSERTED.[FollowupDate]
into @table
WHERE 
	[InsideCustomer_Followup].[ID] = @ID

SELECT 
	[ID],
	[InsideCustomerID],
	[FollowupContent],
	[FollowupDate] 
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
DELETE FROM [dbo].[InsideCustomer_Followup]
WHERE 
	[InsideCustomer_Followup].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public InsideCustomer_Followup() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetInsideCustomer_Followup(this.ID));
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
	[InsideCustomer_Followup].[ID],
	[InsideCustomer_Followup].[InsideCustomerID],
	[InsideCustomer_Followup].[FollowupContent],
	[InsideCustomer_Followup].[FollowupDate]
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
                return "InsideCustomer_Followup";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a InsideCustomer_Followup into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="insideCustomerID">insideCustomerID</param>
		/// <param name="followupContent">followupContent</param>
		/// <param name="followupDate">followupDate</param>
		public static void InsertInsideCustomer_Followup(int @insideCustomerID, string @followupContent, DateTime @followupDate)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertInsideCustomer_Followup(@insideCustomerID, @followupContent, @followupDate, helper);
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
		/// Insert a InsideCustomer_Followup into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="insideCustomerID">insideCustomerID</param>
		/// <param name="followupContent">followupContent</param>
		/// <param name="followupDate">followupDate</param>
		/// <param name="helper">helper</param>
		internal static void InsertInsideCustomer_Followup(int @insideCustomerID, string @followupContent, DateTime @followupDate, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[InsideCustomerID] int,
	[FollowupContent] ntext,
	[FollowupDate] datetime
);

INSERT INTO [dbo].[InsideCustomer_Followup] (
	[InsideCustomer_Followup].[InsideCustomerID],
	[InsideCustomer_Followup].[FollowupContent],
	[InsideCustomer_Followup].[FollowupDate]
) 
output 
	INSERTED.[ID],
	INSERTED.[InsideCustomerID],
	INSERTED.[FollowupContent],
	INSERTED.[FollowupDate]
into @table
VALUES ( 
	@InsideCustomerID,
	@FollowupContent,
	@FollowupDate 
); 

SELECT 
	[ID],
	[InsideCustomerID],
	[FollowupContent],
	[FollowupDate] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@InsideCustomerID", EntityBase.GetDatabaseValue(@insideCustomerID)));
			parameters.Add(new SqlParameter("@FollowupContent", EntityBase.GetDatabaseValue(@followupContent)));
			parameters.Add(new SqlParameter("@FollowupDate", EntityBase.GetDatabaseValue(@followupDate)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a InsideCustomer_Followup into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="insideCustomerID">insideCustomerID</param>
		/// <param name="followupContent">followupContent</param>
		/// <param name="followupDate">followupDate</param>
		public static void UpdateInsideCustomer_Followup(int @iD, int @insideCustomerID, string @followupContent, DateTime @followupDate)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateInsideCustomer_Followup(@iD, @insideCustomerID, @followupContent, @followupDate, helper);
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
		/// Updates a InsideCustomer_Followup into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="insideCustomerID">insideCustomerID</param>
		/// <param name="followupContent">followupContent</param>
		/// <param name="followupDate">followupDate</param>
		/// <param name="helper">helper</param>
		internal static void UpdateInsideCustomer_Followup(int @iD, int @insideCustomerID, string @followupContent, DateTime @followupDate, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[InsideCustomerID] int,
	[FollowupContent] ntext,
	[FollowupDate] datetime
);

UPDATE [dbo].[InsideCustomer_Followup] SET 
	[InsideCustomer_Followup].[InsideCustomerID] = @InsideCustomerID,
	[InsideCustomer_Followup].[FollowupContent] = @FollowupContent,
	[InsideCustomer_Followup].[FollowupDate] = @FollowupDate 
output 
	INSERTED.[ID],
	INSERTED.[InsideCustomerID],
	INSERTED.[FollowupContent],
	INSERTED.[FollowupDate]
into @table
WHERE 
	[InsideCustomer_Followup].[ID] = @ID

SELECT 
	[ID],
	[InsideCustomerID],
	[FollowupContent],
	[FollowupDate] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@InsideCustomerID", EntityBase.GetDatabaseValue(@insideCustomerID)));
			parameters.Add(new SqlParameter("@FollowupContent", EntityBase.GetDatabaseValue(@followupContent)));
			parameters.Add(new SqlParameter("@FollowupDate", EntityBase.GetDatabaseValue(@followupDate)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a InsideCustomer_Followup from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteInsideCustomer_Followup(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteInsideCustomer_Followup(@iD, helper);
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
		/// Deletes a InsideCustomer_Followup from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteInsideCustomer_Followup(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[InsideCustomer_Followup]
WHERE 
	[InsideCustomer_Followup].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new InsideCustomer_Followup object.
		/// </summary>
		/// <returns>The newly created InsideCustomer_Followup object.</returns>
		public static InsideCustomer_Followup CreateInsideCustomer_Followup()
		{
			return InitializeNew<InsideCustomer_Followup>();
		}
		
		/// <summary>
		/// Retrieve information for a InsideCustomer_Followup by a InsideCustomer_Followup's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>InsideCustomer_Followup</returns>
		public static InsideCustomer_Followup GetInsideCustomer_Followup(int @iD)
		{
			string commandText = @"
SELECT 
" + InsideCustomer_Followup.SelectFieldList + @"
FROM [dbo].[InsideCustomer_Followup] 
WHERE 
	[InsideCustomer_Followup].[ID] = @ID " + InsideCustomer_Followup.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<InsideCustomer_Followup>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a InsideCustomer_Followup by a InsideCustomer_Followup's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>InsideCustomer_Followup</returns>
		public static InsideCustomer_Followup GetInsideCustomer_Followup(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + InsideCustomer_Followup.SelectFieldList + @"
FROM [dbo].[InsideCustomer_Followup] 
WHERE 
	[InsideCustomer_Followup].[ID] = @ID " + InsideCustomer_Followup.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<InsideCustomer_Followup>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection InsideCustomer_Followup objects.
		/// </summary>
		/// <returns>The retrieved collection of InsideCustomer_Followup objects.</returns>
		public static EntityList<InsideCustomer_Followup> GetInsideCustomer_Followups()
		{
			string commandText = @"
SELECT " + InsideCustomer_Followup.SelectFieldList + "FROM [dbo].[InsideCustomer_Followup] " + InsideCustomer_Followup.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<InsideCustomer_Followup>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection InsideCustomer_Followup objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of InsideCustomer_Followup objects.</returns>
        public static EntityList<InsideCustomer_Followup> GetInsideCustomer_Followups(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<InsideCustomer_Followup>(SelectFieldList, "FROM [dbo].[InsideCustomer_Followup]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection InsideCustomer_Followup objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of InsideCustomer_Followup objects.</returns>
        public static EntityList<InsideCustomer_Followup> GetInsideCustomer_Followups(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<InsideCustomer_Followup>(SelectFieldList, "FROM [dbo].[InsideCustomer_Followup]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection InsideCustomer_Followup objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of InsideCustomer_Followup objects.</returns>
		protected static EntityList<InsideCustomer_Followup> GetInsideCustomer_Followups(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetInsideCustomer_Followups(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection InsideCustomer_Followup objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of InsideCustomer_Followup objects.</returns>
		protected static EntityList<InsideCustomer_Followup> GetInsideCustomer_Followups(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetInsideCustomer_Followups(string.Empty, where, parameters, InsideCustomer_Followup.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection InsideCustomer_Followup objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of InsideCustomer_Followup objects.</returns>
		protected static EntityList<InsideCustomer_Followup> GetInsideCustomer_Followups(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetInsideCustomer_Followups(prefix, where, parameters, InsideCustomer_Followup.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection InsideCustomer_Followup objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of InsideCustomer_Followup objects.</returns>
		protected static EntityList<InsideCustomer_Followup> GetInsideCustomer_Followups(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetInsideCustomer_Followups(string.Empty, where, parameters, InsideCustomer_Followup.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection InsideCustomer_Followup objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of InsideCustomer_Followup objects.</returns>
		protected static EntityList<InsideCustomer_Followup> GetInsideCustomer_Followups(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetInsideCustomer_Followups(prefix, where, parameters, InsideCustomer_Followup.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection InsideCustomer_Followup objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of InsideCustomer_Followup objects.</returns>
		protected static EntityList<InsideCustomer_Followup> GetInsideCustomer_Followups(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + InsideCustomer_Followup.SelectFieldList + "FROM [dbo].[InsideCustomer_Followup] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<InsideCustomer_Followup>(reader);
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
        protected static EntityList<InsideCustomer_Followup> GetInsideCustomer_Followups(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<InsideCustomer_Followup>(SelectFieldList, "FROM [dbo].[InsideCustomer_Followup] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of InsideCustomer_Followup objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetInsideCustomer_FollowupCount()
        {
            return GetInsideCustomer_FollowupCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of InsideCustomer_Followup objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetInsideCustomer_FollowupCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[InsideCustomer_Followup] " + where;

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
		public static partial class InsideCustomer_Followup_Properties
		{
			public const string ID = "ID";
			public const string InsideCustomerID = "InsideCustomerID";
			public const string FollowupContent = "FollowupContent";
			public const string FollowupDate = "FollowupDate";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"InsideCustomerID" , "int:"},
    			 {"FollowupContent" , "string:"},
    			 {"FollowupDate" , "DateTime:"},
            };
		}
		#endregion
	}
}
