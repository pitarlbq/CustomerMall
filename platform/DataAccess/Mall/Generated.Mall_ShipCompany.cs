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
	/// This object represents the properties and methods of a Mall_ShipCompany.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_ShipCompany 
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
		private string _shipCompanyName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string ShipCompanyName
		{
			[DebuggerStepThrough()]
			get { return this._shipCompanyName; }
			set 
			{
				if (this._shipCompanyName != value) 
				{
					this._shipCompanyName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ShipCompanyName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _shipTrakURL = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ShipTrakURL
		{
			[DebuggerStepThrough()]
			get { return this._shipTrakURL; }
			set 
			{
				if (this._shipTrakURL != value) 
				{
					this._shipTrakURL = value;
					this.IsDirty = true;	
					OnPropertyChanged("ShipTrakURL");
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
		private int _sortOrder = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int SortOrder
		{
			[DebuggerStepThrough()]
			get { return this._sortOrder; }
			set 
			{
				if (this._sortOrder != value) 
				{
					this._sortOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("SortOrder");
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
	[ShipCompanyName] nvarchar(200),
	[ShipTrakURL] nvarchar(500),
	[AddTime] datetime,
	[SortOrder] int
);

INSERT INTO [dbo].[Mall_ShipCompany] (
	[Mall_ShipCompany].[ShipCompanyName],
	[Mall_ShipCompany].[ShipTrakURL],
	[Mall_ShipCompany].[AddTime],
	[Mall_ShipCompany].[SortOrder]
) 
output 
	INSERTED.[ID],
	INSERTED.[ShipCompanyName],
	INSERTED.[ShipTrakURL],
	INSERTED.[AddTime],
	INSERTED.[SortOrder]
into @table
VALUES ( 
	@ShipCompanyName,
	@ShipTrakURL,
	@AddTime,
	@SortOrder 
); 

SELECT 
	[ID],
	[ShipCompanyName],
	[ShipTrakURL],
	[AddTime],
	[SortOrder] 
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
	[ShipCompanyName] nvarchar(200),
	[ShipTrakURL] nvarchar(500),
	[AddTime] datetime,
	[SortOrder] int
);

UPDATE [dbo].[Mall_ShipCompany] SET 
	[Mall_ShipCompany].[ShipCompanyName] = @ShipCompanyName,
	[Mall_ShipCompany].[ShipTrakURL] = @ShipTrakURL,
	[Mall_ShipCompany].[AddTime] = @AddTime,
	[Mall_ShipCompany].[SortOrder] = @SortOrder 
output 
	INSERTED.[ID],
	INSERTED.[ShipCompanyName],
	INSERTED.[ShipTrakURL],
	INSERTED.[AddTime],
	INSERTED.[SortOrder]
into @table
WHERE 
	[Mall_ShipCompany].[ID] = @ID

SELECT 
	[ID],
	[ShipCompanyName],
	[ShipTrakURL],
	[AddTime],
	[SortOrder] 
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
DELETE FROM [dbo].[Mall_ShipCompany]
WHERE 
	[Mall_ShipCompany].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_ShipCompany() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_ShipCompany(this.ID));
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
	[Mall_ShipCompany].[ID],
	[Mall_ShipCompany].[ShipCompanyName],
	[Mall_ShipCompany].[ShipTrakURL],
	[Mall_ShipCompany].[AddTime],
	[Mall_ShipCompany].[SortOrder]
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
                return "Mall_ShipCompany";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_ShipCompany into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="shipCompanyName">shipCompanyName</param>
		/// <param name="shipTrakURL">shipTrakURL</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortOrder">sortOrder</param>
		public static void InsertMall_ShipCompany(string @shipCompanyName, string @shipTrakURL, DateTime @addTime, int @sortOrder)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_ShipCompany(@shipCompanyName, @shipTrakURL, @addTime, @sortOrder, helper);
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
		/// Insert a Mall_ShipCompany into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="shipCompanyName">shipCompanyName</param>
		/// <param name="shipTrakURL">shipTrakURL</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_ShipCompany(string @shipCompanyName, string @shipTrakURL, DateTime @addTime, int @sortOrder, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ShipCompanyName] nvarchar(200),
	[ShipTrakURL] nvarchar(500),
	[AddTime] datetime,
	[SortOrder] int
);

INSERT INTO [dbo].[Mall_ShipCompany] (
	[Mall_ShipCompany].[ShipCompanyName],
	[Mall_ShipCompany].[ShipTrakURL],
	[Mall_ShipCompany].[AddTime],
	[Mall_ShipCompany].[SortOrder]
) 
output 
	INSERTED.[ID],
	INSERTED.[ShipCompanyName],
	INSERTED.[ShipTrakURL],
	INSERTED.[AddTime],
	INSERTED.[SortOrder]
into @table
VALUES ( 
	@ShipCompanyName,
	@ShipTrakURL,
	@AddTime,
	@SortOrder 
); 

SELECT 
	[ID],
	[ShipCompanyName],
	[ShipTrakURL],
	[AddTime],
	[SortOrder] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ShipCompanyName", EntityBase.GetDatabaseValue(@shipCompanyName)));
			parameters.Add(new SqlParameter("@ShipTrakURL", EntityBase.GetDatabaseValue(@shipTrakURL)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_ShipCompany into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="shipCompanyName">shipCompanyName</param>
		/// <param name="shipTrakURL">shipTrakURL</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortOrder">sortOrder</param>
		public static void UpdateMall_ShipCompany(int @iD, string @shipCompanyName, string @shipTrakURL, DateTime @addTime, int @sortOrder)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_ShipCompany(@iD, @shipCompanyName, @shipTrakURL, @addTime, @sortOrder, helper);
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
		/// Updates a Mall_ShipCompany into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="shipCompanyName">shipCompanyName</param>
		/// <param name="shipTrakURL">shipTrakURL</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_ShipCompany(int @iD, string @shipCompanyName, string @shipTrakURL, DateTime @addTime, int @sortOrder, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ShipCompanyName] nvarchar(200),
	[ShipTrakURL] nvarchar(500),
	[AddTime] datetime,
	[SortOrder] int
);

UPDATE [dbo].[Mall_ShipCompany] SET 
	[Mall_ShipCompany].[ShipCompanyName] = @ShipCompanyName,
	[Mall_ShipCompany].[ShipTrakURL] = @ShipTrakURL,
	[Mall_ShipCompany].[AddTime] = @AddTime,
	[Mall_ShipCompany].[SortOrder] = @SortOrder 
output 
	INSERTED.[ID],
	INSERTED.[ShipCompanyName],
	INSERTED.[ShipTrakURL],
	INSERTED.[AddTime],
	INSERTED.[SortOrder]
into @table
WHERE 
	[Mall_ShipCompany].[ID] = @ID

SELECT 
	[ID],
	[ShipCompanyName],
	[ShipTrakURL],
	[AddTime],
	[SortOrder] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ShipCompanyName", EntityBase.GetDatabaseValue(@shipCompanyName)));
			parameters.Add(new SqlParameter("@ShipTrakURL", EntityBase.GetDatabaseValue(@shipTrakURL)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_ShipCompany from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_ShipCompany(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_ShipCompany(@iD, helper);
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
		/// Deletes a Mall_ShipCompany from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_ShipCompany(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_ShipCompany]
WHERE 
	[Mall_ShipCompany].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_ShipCompany object.
		/// </summary>
		/// <returns>The newly created Mall_ShipCompany object.</returns>
		public static Mall_ShipCompany CreateMall_ShipCompany()
		{
			return InitializeNew<Mall_ShipCompany>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_ShipCompany by a Mall_ShipCompany's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_ShipCompany</returns>
		public static Mall_ShipCompany GetMall_ShipCompany(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_ShipCompany.SelectFieldList + @"
FROM [dbo].[Mall_ShipCompany] 
WHERE 
	[Mall_ShipCompany].[ID] = @ID " + Mall_ShipCompany.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ShipCompany>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_ShipCompany by a Mall_ShipCompany's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_ShipCompany</returns>
		public static Mall_ShipCompany GetMall_ShipCompany(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_ShipCompany.SelectFieldList + @"
FROM [dbo].[Mall_ShipCompany] 
WHERE 
	[Mall_ShipCompany].[ID] = @ID " + Mall_ShipCompany.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ShipCompany>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipCompany objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_ShipCompany objects.</returns>
		public static EntityList<Mall_ShipCompany> GetMall_ShipCompanies()
		{
			string commandText = @"
SELECT " + Mall_ShipCompany.SelectFieldList + "FROM [dbo].[Mall_ShipCompany] " + Mall_ShipCompany.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_ShipCompany>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_ShipCompany objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ShipCompany objects.</returns>
        public static EntityList<Mall_ShipCompany> GetMall_ShipCompanies(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ShipCompany>(SelectFieldList, "FROM [dbo].[Mall_ShipCompany]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_ShipCompany objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ShipCompany objects.</returns>
        public static EntityList<Mall_ShipCompany> GetMall_ShipCompanies(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ShipCompany>(SelectFieldList, "FROM [dbo].[Mall_ShipCompany]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_ShipCompany objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ShipCompany objects.</returns>
		protected static EntityList<Mall_ShipCompany> GetMall_ShipCompanies(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ShipCompanies(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipCompany objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShipCompany objects.</returns>
		protected static EntityList<Mall_ShipCompany> GetMall_ShipCompanies(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ShipCompanies(string.Empty, where, parameters, Mall_ShipCompany.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipCompany objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShipCompany objects.</returns>
		protected static EntityList<Mall_ShipCompany> GetMall_ShipCompanies(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ShipCompanies(prefix, where, parameters, Mall_ShipCompany.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipCompany objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShipCompany objects.</returns>
		protected static EntityList<Mall_ShipCompany> GetMall_ShipCompanies(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ShipCompanies(string.Empty, where, parameters, Mall_ShipCompany.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipCompany objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShipCompany objects.</returns>
		protected static EntityList<Mall_ShipCompany> GetMall_ShipCompanies(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ShipCompanies(prefix, where, parameters, Mall_ShipCompany.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipCompany objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ShipCompany objects.</returns>
		protected static EntityList<Mall_ShipCompany> GetMall_ShipCompanies(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_ShipCompany.SelectFieldList + "FROM [dbo].[Mall_ShipCompany] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_ShipCompany>(reader);
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
        protected static EntityList<Mall_ShipCompany> GetMall_ShipCompanies(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ShipCompany>(SelectFieldList, "FROM [dbo].[Mall_ShipCompany] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_ShipCompany objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ShipCompanyCount()
        {
            return GetMall_ShipCompanyCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_ShipCompany objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ShipCompanyCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_ShipCompany] " + where;

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
		public static partial class Mall_ShipCompany_Properties
		{
			public const string ID = "ID";
			public const string ShipCompanyName = "ShipCompanyName";
			public const string ShipTrakURL = "ShipTrakURL";
			public const string AddTime = "AddTime";
			public const string SortOrder = "SortOrder";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ShipCompanyName" , "string:"},
    			 {"ShipTrakURL" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"SortOrder" , "int:"},
            };
		}
		#endregion
	}
}
