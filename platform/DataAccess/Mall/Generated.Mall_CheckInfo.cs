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
	/// This object represents the properties and methods of a Mall_CheckInfo.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_CheckInfo 
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
		private int _checkCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int CheckCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._checkCategoryID; }
			set 
			{
				if (this._checkCategoryID != value) 
				{
					this._checkCategoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CheckCategoryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _checkName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string CheckName
		{
			[DebuggerStepThrough()]
			get { return this._checkName; }
			set 
			{
				if (this._checkName != value) 
				{
					this._checkName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CheckName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _checkSummary = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CheckSummary
		{
			[DebuggerStepThrough()]
			get { return this._checkSummary; }
			set 
			{
				if (this._checkSummary != value) 
				{
					this._checkSummary = value;
					this.IsDirty = true;	
					OnPropertyChanged("CheckSummary");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _startPoint = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int StartPoint
		{
			[DebuggerStepThrough()]
			get { return this._startPoint; }
			set 
			{
				if (this._startPoint != value) 
				{
					this._startPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("StartPoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _endPoint = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int EndPoint
		{
			[DebuggerStepThrough()]
			get { return this._endPoint; }
			set 
			{
				if (this._endPoint != value) 
				{
					this._endPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndPoint");
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
		private string _addUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string AddUserName
		{
			[DebuggerStepThrough()]
			get { return this._addUserName; }
			set 
			{
				if (this._addUserName != value) 
				{
					this._addUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUserName");
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
	[CheckCategoryID] int,
	[CheckName] nvarchar(200),
	[CheckSummary] ntext,
	[StartPoint] int,
	[EndPoint] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200)
);

INSERT INTO [dbo].[Mall_CheckInfo] (
	[Mall_CheckInfo].[CheckCategoryID],
	[Mall_CheckInfo].[CheckName],
	[Mall_CheckInfo].[CheckSummary],
	[Mall_CheckInfo].[StartPoint],
	[Mall_CheckInfo].[EndPoint],
	[Mall_CheckInfo].[AddTime],
	[Mall_CheckInfo].[AddUserName]
) 
output 
	INSERTED.[ID],
	INSERTED.[CheckCategoryID],
	INSERTED.[CheckName],
	INSERTED.[CheckSummary],
	INSERTED.[StartPoint],
	INSERTED.[EndPoint],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
VALUES ( 
	@CheckCategoryID,
	@CheckName,
	@CheckSummary,
	@StartPoint,
	@EndPoint,
	@AddTime,
	@AddUserName 
); 

SELECT 
	[ID],
	[CheckCategoryID],
	[CheckName],
	[CheckSummary],
	[StartPoint],
	[EndPoint],
	[AddTime],
	[AddUserName] 
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
	[CheckCategoryID] int,
	[CheckName] nvarchar(200),
	[CheckSummary] ntext,
	[StartPoint] int,
	[EndPoint] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200)
);

UPDATE [dbo].[Mall_CheckInfo] SET 
	[Mall_CheckInfo].[CheckCategoryID] = @CheckCategoryID,
	[Mall_CheckInfo].[CheckName] = @CheckName,
	[Mall_CheckInfo].[CheckSummary] = @CheckSummary,
	[Mall_CheckInfo].[StartPoint] = @StartPoint,
	[Mall_CheckInfo].[EndPoint] = @EndPoint,
	[Mall_CheckInfo].[AddTime] = @AddTime,
	[Mall_CheckInfo].[AddUserName] = @AddUserName 
output 
	INSERTED.[ID],
	INSERTED.[CheckCategoryID],
	INSERTED.[CheckName],
	INSERTED.[CheckSummary],
	INSERTED.[StartPoint],
	INSERTED.[EndPoint],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
WHERE 
	[Mall_CheckInfo].[ID] = @ID

SELECT 
	[ID],
	[CheckCategoryID],
	[CheckName],
	[CheckSummary],
	[StartPoint],
	[EndPoint],
	[AddTime],
	[AddUserName] 
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
DELETE FROM [dbo].[Mall_CheckInfo]
WHERE 
	[Mall_CheckInfo].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_CheckInfo() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_CheckInfo(this.ID));
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
	[Mall_CheckInfo].[ID],
	[Mall_CheckInfo].[CheckCategoryID],
	[Mall_CheckInfo].[CheckName],
	[Mall_CheckInfo].[CheckSummary],
	[Mall_CheckInfo].[StartPoint],
	[Mall_CheckInfo].[EndPoint],
	[Mall_CheckInfo].[AddTime],
	[Mall_CheckInfo].[AddUserName]
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
                return "Mall_CheckInfo";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_CheckInfo into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="checkCategoryID">checkCategoryID</param>
		/// <param name="checkName">checkName</param>
		/// <param name="checkSummary">checkSummary</param>
		/// <param name="startPoint">startPoint</param>
		/// <param name="endPoint">endPoint</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		public static void InsertMall_CheckInfo(int @checkCategoryID, string @checkName, string @checkSummary, int @startPoint, int @endPoint, DateTime @addTime, string @addUserName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_CheckInfo(@checkCategoryID, @checkName, @checkSummary, @startPoint, @endPoint, @addTime, @addUserName, helper);
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
		/// Insert a Mall_CheckInfo into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="checkCategoryID">checkCategoryID</param>
		/// <param name="checkName">checkName</param>
		/// <param name="checkSummary">checkSummary</param>
		/// <param name="startPoint">startPoint</param>
		/// <param name="endPoint">endPoint</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_CheckInfo(int @checkCategoryID, string @checkName, string @checkSummary, int @startPoint, int @endPoint, DateTime @addTime, string @addUserName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CheckCategoryID] int,
	[CheckName] nvarchar(200),
	[CheckSummary] ntext,
	[StartPoint] int,
	[EndPoint] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200)
);

INSERT INTO [dbo].[Mall_CheckInfo] (
	[Mall_CheckInfo].[CheckCategoryID],
	[Mall_CheckInfo].[CheckName],
	[Mall_CheckInfo].[CheckSummary],
	[Mall_CheckInfo].[StartPoint],
	[Mall_CheckInfo].[EndPoint],
	[Mall_CheckInfo].[AddTime],
	[Mall_CheckInfo].[AddUserName]
) 
output 
	INSERTED.[ID],
	INSERTED.[CheckCategoryID],
	INSERTED.[CheckName],
	INSERTED.[CheckSummary],
	INSERTED.[StartPoint],
	INSERTED.[EndPoint],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
VALUES ( 
	@CheckCategoryID,
	@CheckName,
	@CheckSummary,
	@StartPoint,
	@EndPoint,
	@AddTime,
	@AddUserName 
); 

SELECT 
	[ID],
	[CheckCategoryID],
	[CheckName],
	[CheckSummary],
	[StartPoint],
	[EndPoint],
	[AddTime],
	[AddUserName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CheckCategoryID", EntityBase.GetDatabaseValue(@checkCategoryID)));
			parameters.Add(new SqlParameter("@CheckName", EntityBase.GetDatabaseValue(@checkName)));
			parameters.Add(new SqlParameter("@CheckSummary", EntityBase.GetDatabaseValue(@checkSummary)));
			parameters.Add(new SqlParameter("@StartPoint", EntityBase.GetDatabaseValue(@startPoint)));
			parameters.Add(new SqlParameter("@EndPoint", EntityBase.GetDatabaseValue(@endPoint)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_CheckInfo into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="checkCategoryID">checkCategoryID</param>
		/// <param name="checkName">checkName</param>
		/// <param name="checkSummary">checkSummary</param>
		/// <param name="startPoint">startPoint</param>
		/// <param name="endPoint">endPoint</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		public static void UpdateMall_CheckInfo(int @iD, int @checkCategoryID, string @checkName, string @checkSummary, int @startPoint, int @endPoint, DateTime @addTime, string @addUserName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_CheckInfo(@iD, @checkCategoryID, @checkName, @checkSummary, @startPoint, @endPoint, @addTime, @addUserName, helper);
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
		/// Updates a Mall_CheckInfo into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="checkCategoryID">checkCategoryID</param>
		/// <param name="checkName">checkName</param>
		/// <param name="checkSummary">checkSummary</param>
		/// <param name="startPoint">startPoint</param>
		/// <param name="endPoint">endPoint</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_CheckInfo(int @iD, int @checkCategoryID, string @checkName, string @checkSummary, int @startPoint, int @endPoint, DateTime @addTime, string @addUserName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CheckCategoryID] int,
	[CheckName] nvarchar(200),
	[CheckSummary] ntext,
	[StartPoint] int,
	[EndPoint] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200)
);

UPDATE [dbo].[Mall_CheckInfo] SET 
	[Mall_CheckInfo].[CheckCategoryID] = @CheckCategoryID,
	[Mall_CheckInfo].[CheckName] = @CheckName,
	[Mall_CheckInfo].[CheckSummary] = @CheckSummary,
	[Mall_CheckInfo].[StartPoint] = @StartPoint,
	[Mall_CheckInfo].[EndPoint] = @EndPoint,
	[Mall_CheckInfo].[AddTime] = @AddTime,
	[Mall_CheckInfo].[AddUserName] = @AddUserName 
output 
	INSERTED.[ID],
	INSERTED.[CheckCategoryID],
	INSERTED.[CheckName],
	INSERTED.[CheckSummary],
	INSERTED.[StartPoint],
	INSERTED.[EndPoint],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
WHERE 
	[Mall_CheckInfo].[ID] = @ID

SELECT 
	[ID],
	[CheckCategoryID],
	[CheckName],
	[CheckSummary],
	[StartPoint],
	[EndPoint],
	[AddTime],
	[AddUserName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@CheckCategoryID", EntityBase.GetDatabaseValue(@checkCategoryID)));
			parameters.Add(new SqlParameter("@CheckName", EntityBase.GetDatabaseValue(@checkName)));
			parameters.Add(new SqlParameter("@CheckSummary", EntityBase.GetDatabaseValue(@checkSummary)));
			parameters.Add(new SqlParameter("@StartPoint", EntityBase.GetDatabaseValue(@startPoint)));
			parameters.Add(new SqlParameter("@EndPoint", EntityBase.GetDatabaseValue(@endPoint)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_CheckInfo from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_CheckInfo(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_CheckInfo(@iD, helper);
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
		/// Deletes a Mall_CheckInfo from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_CheckInfo(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_CheckInfo]
WHERE 
	[Mall_CheckInfo].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_CheckInfo object.
		/// </summary>
		/// <returns>The newly created Mall_CheckInfo object.</returns>
		public static Mall_CheckInfo CreateMall_CheckInfo()
		{
			return InitializeNew<Mall_CheckInfo>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_CheckInfo by a Mall_CheckInfo's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_CheckInfo</returns>
		public static Mall_CheckInfo GetMall_CheckInfo(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_CheckInfo.SelectFieldList + @"
FROM [dbo].[Mall_CheckInfo] 
WHERE 
	[Mall_CheckInfo].[ID] = @ID " + Mall_CheckInfo.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_CheckInfo>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_CheckInfo by a Mall_CheckInfo's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_CheckInfo</returns>
		public static Mall_CheckInfo GetMall_CheckInfo(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_CheckInfo.SelectFieldList + @"
FROM [dbo].[Mall_CheckInfo] 
WHERE 
	[Mall_CheckInfo].[ID] = @ID " + Mall_CheckInfo.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_CheckInfo>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckInfo objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_CheckInfo objects.</returns>
		public static EntityList<Mall_CheckInfo> GetMall_CheckInfos()
		{
			string commandText = @"
SELECT " + Mall_CheckInfo.SelectFieldList + "FROM [dbo].[Mall_CheckInfo] " + Mall_CheckInfo.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_CheckInfo>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_CheckInfo objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_CheckInfo objects.</returns>
        public static EntityList<Mall_CheckInfo> GetMall_CheckInfos(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckInfo>(SelectFieldList, "FROM [dbo].[Mall_CheckInfo]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_CheckInfo objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_CheckInfo objects.</returns>
        public static EntityList<Mall_CheckInfo> GetMall_CheckInfos(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckInfo>(SelectFieldList, "FROM [dbo].[Mall_CheckInfo]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_CheckInfo objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_CheckInfo objects.</returns>
		protected static EntityList<Mall_CheckInfo> GetMall_CheckInfos(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckInfos(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckInfo objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckInfo objects.</returns>
		protected static EntityList<Mall_CheckInfo> GetMall_CheckInfos(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckInfos(string.Empty, where, parameters, Mall_CheckInfo.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckInfo objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckInfo objects.</returns>
		protected static EntityList<Mall_CheckInfo> GetMall_CheckInfos(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckInfos(prefix, where, parameters, Mall_CheckInfo.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckInfo objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckInfo objects.</returns>
		protected static EntityList<Mall_CheckInfo> GetMall_CheckInfos(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_CheckInfos(string.Empty, where, parameters, Mall_CheckInfo.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckInfo objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckInfo objects.</returns>
		protected static EntityList<Mall_CheckInfo> GetMall_CheckInfos(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_CheckInfos(prefix, where, parameters, Mall_CheckInfo.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckInfo objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_CheckInfo objects.</returns>
		protected static EntityList<Mall_CheckInfo> GetMall_CheckInfos(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_CheckInfo.SelectFieldList + "FROM [dbo].[Mall_CheckInfo] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_CheckInfo>(reader);
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
        protected static EntityList<Mall_CheckInfo> GetMall_CheckInfos(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckInfo>(SelectFieldList, "FROM [dbo].[Mall_CheckInfo] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_CheckInfo objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CheckInfoCount()
        {
            return GetMall_CheckInfoCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_CheckInfo objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CheckInfoCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_CheckInfo] " + where;

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
		public static partial class Mall_CheckInfo_Properties
		{
			public const string ID = "ID";
			public const string CheckCategoryID = "CheckCategoryID";
			public const string CheckName = "CheckName";
			public const string CheckSummary = "CheckSummary";
			public const string StartPoint = "StartPoint";
			public const string EndPoint = "EndPoint";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CheckCategoryID" , "int:"},
    			 {"CheckName" , "string:"},
    			 {"CheckSummary" , "string:"},
    			 {"StartPoint" , "int:"},
    			 {"EndPoint" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
            };
		}
		#endregion
	}
}
