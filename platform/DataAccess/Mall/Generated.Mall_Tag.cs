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
	/// This object represents the properties and methods of a Mall_Tag.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_Tag 
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
		private string _tagName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string TagName
		{
			[DebuggerStepThrough()]
			get { return this._tagName; }
			set 
			{
				if (this._tagName != value) 
				{
					this._tagName = value;
					this.IsDirty = true;	
					OnPropertyChanged("TagName");
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
	[TagName] nvarchar(200),
	[AddTime] datetime,
	[SortOrder] int
);

INSERT INTO [dbo].[Mall_Tag] (
	[Mall_Tag].[TagName],
	[Mall_Tag].[AddTime],
	[Mall_Tag].[SortOrder]
) 
output 
	INSERTED.[ID],
	INSERTED.[TagName],
	INSERTED.[AddTime],
	INSERTED.[SortOrder]
into @table
VALUES ( 
	@TagName,
	@AddTime,
	@SortOrder 
); 

SELECT 
	[ID],
	[TagName],
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
	[TagName] nvarchar(200),
	[AddTime] datetime,
	[SortOrder] int
);

UPDATE [dbo].[Mall_Tag] SET 
	[Mall_Tag].[TagName] = @TagName,
	[Mall_Tag].[AddTime] = @AddTime,
	[Mall_Tag].[SortOrder] = @SortOrder 
output 
	INSERTED.[ID],
	INSERTED.[TagName],
	INSERTED.[AddTime],
	INSERTED.[SortOrder]
into @table
WHERE 
	[Mall_Tag].[ID] = @ID

SELECT 
	[ID],
	[TagName],
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
DELETE FROM [dbo].[Mall_Tag]
WHERE 
	[Mall_Tag].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_Tag() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_Tag(this.ID));
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
	[Mall_Tag].[ID],
	[Mall_Tag].[TagName],
	[Mall_Tag].[AddTime],
	[Mall_Tag].[SortOrder]
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
                return "Mall_Tag";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_Tag into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="tagName">tagName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortOrder">sortOrder</param>
		public static void InsertMall_Tag(string @tagName, DateTime @addTime, int @sortOrder)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_Tag(@tagName, @addTime, @sortOrder, helper);
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
		/// Insert a Mall_Tag into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="tagName">tagName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_Tag(string @tagName, DateTime @addTime, int @sortOrder, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[TagName] nvarchar(200),
	[AddTime] datetime,
	[SortOrder] int
);

INSERT INTO [dbo].[Mall_Tag] (
	[Mall_Tag].[TagName],
	[Mall_Tag].[AddTime],
	[Mall_Tag].[SortOrder]
) 
output 
	INSERTED.[ID],
	INSERTED.[TagName],
	INSERTED.[AddTime],
	INSERTED.[SortOrder]
into @table
VALUES ( 
	@TagName,
	@AddTime,
	@SortOrder 
); 

SELECT 
	[ID],
	[TagName],
	[AddTime],
	[SortOrder] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TagName", EntityBase.GetDatabaseValue(@tagName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_Tag into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="tagName">tagName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortOrder">sortOrder</param>
		public static void UpdateMall_Tag(int @iD, string @tagName, DateTime @addTime, int @sortOrder)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_Tag(@iD, @tagName, @addTime, @sortOrder, helper);
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
		/// Updates a Mall_Tag into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="tagName">tagName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_Tag(int @iD, string @tagName, DateTime @addTime, int @sortOrder, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[TagName] nvarchar(200),
	[AddTime] datetime,
	[SortOrder] int
);

UPDATE [dbo].[Mall_Tag] SET 
	[Mall_Tag].[TagName] = @TagName,
	[Mall_Tag].[AddTime] = @AddTime,
	[Mall_Tag].[SortOrder] = @SortOrder 
output 
	INSERTED.[ID],
	INSERTED.[TagName],
	INSERTED.[AddTime],
	INSERTED.[SortOrder]
into @table
WHERE 
	[Mall_Tag].[ID] = @ID

SELECT 
	[ID],
	[TagName],
	[AddTime],
	[SortOrder] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@TagName", EntityBase.GetDatabaseValue(@tagName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_Tag from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_Tag(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_Tag(@iD, helper);
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
		/// Deletes a Mall_Tag from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_Tag(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_Tag]
WHERE 
	[Mall_Tag].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_Tag object.
		/// </summary>
		/// <returns>The newly created Mall_Tag object.</returns>
		public static Mall_Tag CreateMall_Tag()
		{
			return InitializeNew<Mall_Tag>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_Tag by a Mall_Tag's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_Tag</returns>
		public static Mall_Tag GetMall_Tag(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_Tag.SelectFieldList + @"
FROM [dbo].[Mall_Tag] 
WHERE 
	[Mall_Tag].[ID] = @ID " + Mall_Tag.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Tag>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_Tag by a Mall_Tag's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_Tag</returns>
		public static Mall_Tag GetMall_Tag(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_Tag.SelectFieldList + @"
FROM [dbo].[Mall_Tag] 
WHERE 
	[Mall_Tag].[ID] = @ID " + Mall_Tag.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Tag>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_Tag objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_Tag objects.</returns>
		public static EntityList<Mall_Tag> GetMall_Tags()
		{
			string commandText = @"
SELECT " + Mall_Tag.SelectFieldList + "FROM [dbo].[Mall_Tag] " + Mall_Tag.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_Tag>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_Tag objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Tag objects.</returns>
        public static EntityList<Mall_Tag> GetMall_Tags(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Tag>(SelectFieldList, "FROM [dbo].[Mall_Tag]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_Tag objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Tag objects.</returns>
        public static EntityList<Mall_Tag> GetMall_Tags(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Tag>(SelectFieldList, "FROM [dbo].[Mall_Tag]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_Tag objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Tag objects.</returns>
		protected static EntityList<Mall_Tag> GetMall_Tags(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Tags(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_Tag objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Tag objects.</returns>
		protected static EntityList<Mall_Tag> GetMall_Tags(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Tags(string.Empty, where, parameters, Mall_Tag.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Tag objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Tag objects.</returns>
		protected static EntityList<Mall_Tag> GetMall_Tags(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Tags(prefix, where, parameters, Mall_Tag.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Tag objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Tag objects.</returns>
		protected static EntityList<Mall_Tag> GetMall_Tags(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Tags(string.Empty, where, parameters, Mall_Tag.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Tag objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Tag objects.</returns>
		protected static EntityList<Mall_Tag> GetMall_Tags(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Tags(prefix, where, parameters, Mall_Tag.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Tag objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Tag objects.</returns>
		protected static EntityList<Mall_Tag> GetMall_Tags(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_Tag.SelectFieldList + "FROM [dbo].[Mall_Tag] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_Tag>(reader);
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
        protected static EntityList<Mall_Tag> GetMall_Tags(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Tag>(SelectFieldList, "FROM [dbo].[Mall_Tag] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_Tag objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_TagCount()
        {
            return GetMall_TagCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_Tag objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_TagCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_Tag] " + where;

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
		public static partial class Mall_Tag_Properties
		{
			public const string ID = "ID";
			public const string TagName = "TagName";
			public const string AddTime = "AddTime";
			public const string SortOrder = "SortOrder";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"TagName" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"SortOrder" , "int:"},
            };
		}
		#endregion
	}
}
