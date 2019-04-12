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
	/// This object represents the properties and methods of a Mall_UserLevel.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_UserLevel 
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
		private string _name = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string Name
		{
			[DebuggerStepThrough()]
			get { return this._name; }
			set 
			{
				if (this._name != value) 
				{
					this._name = value;
					this.IsDirty = true;	
					OnPropertyChanged("Name");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _remark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Remark
		{
			[DebuggerStepThrough()]
			get { return this._remark; }
			set 
			{
				if (this._remark != value) 
				{
					this._remark = value;
					this.IsDirty = true;	
					OnPropertyChanged("Remark");
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _startAmount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal StartAmount
		{
			[DebuggerStepThrough()]
			get { return this._startAmount; }
			set 
			{
				if (this._startAmount != value) 
				{
					this._startAmount = value;
					this.IsDirty = true;	
					OnPropertyChanged("StartAmount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _endAmount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal EndAmount
		{
			[DebuggerStepThrough()]
			get { return this._endAmount; }
			set 
			{
				if (this._endAmount != value) 
				{
					this._endAmount = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndAmount");
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
	[Name] nvarchar(200),
	[Remark] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[StartAmount] decimal(18, 2),
	[EndAmount] decimal(18, 2)
);

INSERT INTO [dbo].[Mall_UserLevel] (
	[Mall_UserLevel].[Name],
	[Mall_UserLevel].[Remark],
	[Mall_UserLevel].[AddTime],
	[Mall_UserLevel].[AddUserName],
	[Mall_UserLevel].[StartAmount],
	[Mall_UserLevel].[EndAmount]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[StartAmount],
	INSERTED.[EndAmount]
into @table
VALUES ( 
	@Name,
	@Remark,
	@AddTime,
	@AddUserName,
	@StartAmount,
	@EndAmount 
); 

SELECT 
	[ID],
	[Name],
	[Remark],
	[AddTime],
	[AddUserName],
	[StartAmount],
	[EndAmount] 
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
	[Name] nvarchar(200),
	[Remark] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[StartAmount] decimal(18, 2),
	[EndAmount] decimal(18, 2)
);

UPDATE [dbo].[Mall_UserLevel] SET 
	[Mall_UserLevel].[Name] = @Name,
	[Mall_UserLevel].[Remark] = @Remark,
	[Mall_UserLevel].[AddTime] = @AddTime,
	[Mall_UserLevel].[AddUserName] = @AddUserName,
	[Mall_UserLevel].[StartAmount] = @StartAmount,
	[Mall_UserLevel].[EndAmount] = @EndAmount 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[StartAmount],
	INSERTED.[EndAmount]
into @table
WHERE 
	[Mall_UserLevel].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[Remark],
	[AddTime],
	[AddUserName],
	[StartAmount],
	[EndAmount] 
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
DELETE FROM [dbo].[Mall_UserLevel]
WHERE 
	[Mall_UserLevel].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_UserLevel() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_UserLevel(this.ID));
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
	[Mall_UserLevel].[ID],
	[Mall_UserLevel].[Name],
	[Mall_UserLevel].[Remark],
	[Mall_UserLevel].[AddTime],
	[Mall_UserLevel].[AddUserName],
	[Mall_UserLevel].[StartAmount],
	[Mall_UserLevel].[EndAmount]
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
                return "Mall_UserLevel";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_UserLevel into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="startAmount">startAmount</param>
		/// <param name="endAmount">endAmount</param>
		public static void InsertMall_UserLevel(string @name, string @remark, DateTime @addTime, string @addUserName, decimal @startAmount, decimal @endAmount)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_UserLevel(@name, @remark, @addTime, @addUserName, @startAmount, @endAmount, helper);
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
		/// Insert a Mall_UserLevel into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="startAmount">startAmount</param>
		/// <param name="endAmount">endAmount</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_UserLevel(string @name, string @remark, DateTime @addTime, string @addUserName, decimal @startAmount, decimal @endAmount, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(200),
	[Remark] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[StartAmount] decimal(18, 2),
	[EndAmount] decimal(18, 2)
);

INSERT INTO [dbo].[Mall_UserLevel] (
	[Mall_UserLevel].[Name],
	[Mall_UserLevel].[Remark],
	[Mall_UserLevel].[AddTime],
	[Mall_UserLevel].[AddUserName],
	[Mall_UserLevel].[StartAmount],
	[Mall_UserLevel].[EndAmount]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[StartAmount],
	INSERTED.[EndAmount]
into @table
VALUES ( 
	@Name,
	@Remark,
	@AddTime,
	@AddUserName,
	@StartAmount,
	@EndAmount 
); 

SELECT 
	[ID],
	[Name],
	[Remark],
	[AddTime],
	[AddUserName],
	[StartAmount],
	[EndAmount] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@StartAmount", EntityBase.GetDatabaseValue(@startAmount)));
			parameters.Add(new SqlParameter("@EndAmount", EntityBase.GetDatabaseValue(@endAmount)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_UserLevel into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="startAmount">startAmount</param>
		/// <param name="endAmount">endAmount</param>
		public static void UpdateMall_UserLevel(int @iD, string @name, string @remark, DateTime @addTime, string @addUserName, decimal @startAmount, decimal @endAmount)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_UserLevel(@iD, @name, @remark, @addTime, @addUserName, @startAmount, @endAmount, helper);
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
		/// Updates a Mall_UserLevel into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="startAmount">startAmount</param>
		/// <param name="endAmount">endAmount</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_UserLevel(int @iD, string @name, string @remark, DateTime @addTime, string @addUserName, decimal @startAmount, decimal @endAmount, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(200),
	[Remark] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[StartAmount] decimal(18, 2),
	[EndAmount] decimal(18, 2)
);

UPDATE [dbo].[Mall_UserLevel] SET 
	[Mall_UserLevel].[Name] = @Name,
	[Mall_UserLevel].[Remark] = @Remark,
	[Mall_UserLevel].[AddTime] = @AddTime,
	[Mall_UserLevel].[AddUserName] = @AddUserName,
	[Mall_UserLevel].[StartAmount] = @StartAmount,
	[Mall_UserLevel].[EndAmount] = @EndAmount 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[StartAmount],
	INSERTED.[EndAmount]
into @table
WHERE 
	[Mall_UserLevel].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[Remark],
	[AddTime],
	[AddUserName],
	[StartAmount],
	[EndAmount] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@StartAmount", EntityBase.GetDatabaseValue(@startAmount)));
			parameters.Add(new SqlParameter("@EndAmount", EntityBase.GetDatabaseValue(@endAmount)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_UserLevel from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_UserLevel(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_UserLevel(@iD, helper);
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
		/// Deletes a Mall_UserLevel from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_UserLevel(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_UserLevel]
WHERE 
	[Mall_UserLevel].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_UserLevel object.
		/// </summary>
		/// <returns>The newly created Mall_UserLevel object.</returns>
		public static Mall_UserLevel CreateMall_UserLevel()
		{
			return InitializeNew<Mall_UserLevel>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_UserLevel by a Mall_UserLevel's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_UserLevel</returns>
		public static Mall_UserLevel GetMall_UserLevel(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_UserLevel.SelectFieldList + @"
FROM [dbo].[Mall_UserLevel] 
WHERE 
	[Mall_UserLevel].[ID] = @ID " + Mall_UserLevel.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_UserLevel>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_UserLevel by a Mall_UserLevel's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_UserLevel</returns>
		public static Mall_UserLevel GetMall_UserLevel(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_UserLevel.SelectFieldList + @"
FROM [dbo].[Mall_UserLevel] 
WHERE 
	[Mall_UserLevel].[ID] = @ID " + Mall_UserLevel.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_UserLevel>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserLevel objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_UserLevel objects.</returns>
		public static EntityList<Mall_UserLevel> GetMall_UserLevels()
		{
			string commandText = @"
SELECT " + Mall_UserLevel.SelectFieldList + "FROM [dbo].[Mall_UserLevel] " + Mall_UserLevel.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_UserLevel>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_UserLevel objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_UserLevel objects.</returns>
        public static EntityList<Mall_UserLevel> GetMall_UserLevels(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserLevel>(SelectFieldList, "FROM [dbo].[Mall_UserLevel]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_UserLevel objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_UserLevel objects.</returns>
        public static EntityList<Mall_UserLevel> GetMall_UserLevels(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserLevel>(SelectFieldList, "FROM [dbo].[Mall_UserLevel]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_UserLevel objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_UserLevel objects.</returns>
		protected static EntityList<Mall_UserLevel> GetMall_UserLevels(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserLevels(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserLevel objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserLevel objects.</returns>
		protected static EntityList<Mall_UserLevel> GetMall_UserLevels(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserLevels(string.Empty, where, parameters, Mall_UserLevel.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserLevel objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserLevel objects.</returns>
		protected static EntityList<Mall_UserLevel> GetMall_UserLevels(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserLevels(prefix, where, parameters, Mall_UserLevel.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserLevel objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserLevel objects.</returns>
		protected static EntityList<Mall_UserLevel> GetMall_UserLevels(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_UserLevels(string.Empty, where, parameters, Mall_UserLevel.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserLevel objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserLevel objects.</returns>
		protected static EntityList<Mall_UserLevel> GetMall_UserLevels(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_UserLevels(prefix, where, parameters, Mall_UserLevel.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserLevel objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_UserLevel objects.</returns>
		protected static EntityList<Mall_UserLevel> GetMall_UserLevels(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_UserLevel.SelectFieldList + "FROM [dbo].[Mall_UserLevel] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_UserLevel>(reader);
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
        protected static EntityList<Mall_UserLevel> GetMall_UserLevels(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserLevel>(SelectFieldList, "FROM [dbo].[Mall_UserLevel] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_UserLevel objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_UserLevelCount()
        {
            return GetMall_UserLevelCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_UserLevel objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_UserLevelCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_UserLevel] " + where;

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
		public static partial class Mall_UserLevel_Properties
		{
			public const string ID = "ID";
			public const string Name = "Name";
			public const string Remark = "Remark";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string StartAmount = "StartAmount";
			public const string EndAmount = "EndAmount";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Name" , "string:"},
    			 {"Remark" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"StartAmount" , "decimal:"},
    			 {"EndAmount" , "decimal:"},
            };
		}
		#endregion
	}
}
