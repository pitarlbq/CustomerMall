﻿using System;
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
	/// This object represents the properties and methods of a Mall_ChatSensitive.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_ChatSensitive 
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
		private string _keywords = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string Keywords
		{
			[DebuggerStepThrough()]
			get { return this._keywords; }
			set 
			{
				if (this._keywords != value) 
				{
					this._keywords = value;
					this.IsDirty = true;	
					OnPropertyChanged("Keywords");
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
	[Keywords] nvarchar(500),
	[AddTime] datetime
);

INSERT INTO [dbo].[Mall_ChatSensitive] (
	[Mall_ChatSensitive].[Keywords],
	[Mall_ChatSensitive].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[Keywords],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@Keywords,
	@AddTime 
); 

SELECT 
	[ID],
	[Keywords],
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
	[Keywords] nvarchar(500),
	[AddTime] datetime
);

UPDATE [dbo].[Mall_ChatSensitive] SET 
	[Mall_ChatSensitive].[Keywords] = @Keywords,
	[Mall_ChatSensitive].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[Keywords],
	INSERTED.[AddTime]
into @table
WHERE 
	[Mall_ChatSensitive].[ID] = @ID

SELECT 
	[ID],
	[Keywords],
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
DELETE FROM [dbo].[Mall_ChatSensitive]
WHERE 
	[Mall_ChatSensitive].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_ChatSensitive() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_ChatSensitive(this.ID));
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
	[Mall_ChatSensitive].[ID],
	[Mall_ChatSensitive].[Keywords],
	[Mall_ChatSensitive].[AddTime]
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
                return "Mall_ChatSensitive";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_ChatSensitive into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="keywords">keywords</param>
		/// <param name="addTime">addTime</param>
		public static void InsertMall_ChatSensitive(string @keywords, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_ChatSensitive(@keywords, @addTime, helper);
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
		/// Insert a Mall_ChatSensitive into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="keywords">keywords</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_ChatSensitive(string @keywords, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Keywords] nvarchar(500),
	[AddTime] datetime
);

INSERT INTO [dbo].[Mall_ChatSensitive] (
	[Mall_ChatSensitive].[Keywords],
	[Mall_ChatSensitive].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[Keywords],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@Keywords,
	@AddTime 
); 

SELECT 
	[ID],
	[Keywords],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Keywords", EntityBase.GetDatabaseValue(@keywords)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_ChatSensitive into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="keywords">keywords</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateMall_ChatSensitive(int @iD, string @keywords, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_ChatSensitive(@iD, @keywords, @addTime, helper);
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
		/// Updates a Mall_ChatSensitive into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="keywords">keywords</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_ChatSensitive(int @iD, string @keywords, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Keywords] nvarchar(500),
	[AddTime] datetime
);

UPDATE [dbo].[Mall_ChatSensitive] SET 
	[Mall_ChatSensitive].[Keywords] = @Keywords,
	[Mall_ChatSensitive].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[Keywords],
	INSERTED.[AddTime]
into @table
WHERE 
	[Mall_ChatSensitive].[ID] = @ID

SELECT 
	[ID],
	[Keywords],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Keywords", EntityBase.GetDatabaseValue(@keywords)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_ChatSensitive from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_ChatSensitive(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_ChatSensitive(@iD, helper);
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
		/// Deletes a Mall_ChatSensitive from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_ChatSensitive(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_ChatSensitive]
WHERE 
	[Mall_ChatSensitive].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_ChatSensitive object.
		/// </summary>
		/// <returns>The newly created Mall_ChatSensitive object.</returns>
		public static Mall_ChatSensitive CreateMall_ChatSensitive()
		{
			return InitializeNew<Mall_ChatSensitive>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_ChatSensitive by a Mall_ChatSensitive's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_ChatSensitive</returns>
		public static Mall_ChatSensitive GetMall_ChatSensitive(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_ChatSensitive.SelectFieldList + @"
FROM [dbo].[Mall_ChatSensitive] 
WHERE 
	[Mall_ChatSensitive].[ID] = @ID " + Mall_ChatSensitive.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ChatSensitive>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_ChatSensitive by a Mall_ChatSensitive's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_ChatSensitive</returns>
		public static Mall_ChatSensitive GetMall_ChatSensitive(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_ChatSensitive.SelectFieldList + @"
FROM [dbo].[Mall_ChatSensitive] 
WHERE 
	[Mall_ChatSensitive].[ID] = @ID " + Mall_ChatSensitive.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ChatSensitive>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_ChatSensitive objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_ChatSensitive objects.</returns>
		public static EntityList<Mall_ChatSensitive> GetMall_ChatSensitives()
		{
			string commandText = @"
SELECT " + Mall_ChatSensitive.SelectFieldList + "FROM [dbo].[Mall_ChatSensitive] " + Mall_ChatSensitive.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_ChatSensitive>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_ChatSensitive objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ChatSensitive objects.</returns>
        public static EntityList<Mall_ChatSensitive> GetMall_ChatSensitives(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ChatSensitive>(SelectFieldList, "FROM [dbo].[Mall_ChatSensitive]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_ChatSensitive objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ChatSensitive objects.</returns>
        public static EntityList<Mall_ChatSensitive> GetMall_ChatSensitives(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ChatSensitive>(SelectFieldList, "FROM [dbo].[Mall_ChatSensitive]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_ChatSensitive objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ChatSensitive objects.</returns>
		protected static EntityList<Mall_ChatSensitive> GetMall_ChatSensitives(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ChatSensitives(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_ChatSensitive objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ChatSensitive objects.</returns>
		protected static EntityList<Mall_ChatSensitive> GetMall_ChatSensitives(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ChatSensitives(string.Empty, where, parameters, Mall_ChatSensitive.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ChatSensitive objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ChatSensitive objects.</returns>
		protected static EntityList<Mall_ChatSensitive> GetMall_ChatSensitives(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ChatSensitives(prefix, where, parameters, Mall_ChatSensitive.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ChatSensitive objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ChatSensitive objects.</returns>
		protected static EntityList<Mall_ChatSensitive> GetMall_ChatSensitives(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ChatSensitives(string.Empty, where, parameters, Mall_ChatSensitive.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ChatSensitive objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ChatSensitive objects.</returns>
		protected static EntityList<Mall_ChatSensitive> GetMall_ChatSensitives(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ChatSensitives(prefix, where, parameters, Mall_ChatSensitive.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ChatSensitive objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ChatSensitive objects.</returns>
		protected static EntityList<Mall_ChatSensitive> GetMall_ChatSensitives(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_ChatSensitive.SelectFieldList + "FROM [dbo].[Mall_ChatSensitive] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_ChatSensitive>(reader);
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
        protected static EntityList<Mall_ChatSensitive> GetMall_ChatSensitives(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ChatSensitive>(SelectFieldList, "FROM [dbo].[Mall_ChatSensitive] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_ChatSensitive objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ChatSensitiveCount()
        {
            return GetMall_ChatSensitiveCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_ChatSensitive objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ChatSensitiveCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_ChatSensitive] " + where;

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
		public static partial class Mall_ChatSensitive_Properties
		{
			public const string ID = "ID";
			public const string Keywords = "Keywords";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Keywords" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
