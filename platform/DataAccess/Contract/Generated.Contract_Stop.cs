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
	/// This object represents the properties and methods of a Contract_Stop.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Contract_Stop 
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
		private int _contractID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ContractID
		{
			[DebuggerStepThrough()]
			get { return this._contractID; }
			set 
			{
				if (this._contractID != value) 
				{
					this._contractID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractID");
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
		private string _addMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddMan
		{
			[DebuggerStepThrough()]
			get { return this._addMan; }
			set 
			{
				if (this._addMan != value) 
				{
					this._addMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _stopTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime StopTime
		{
			[DebuggerStepThrough()]
			get { return this._stopTime; }
			set 
			{
				if (this._stopTime != value) 
				{
					this._stopTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("StopTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _processMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProcessMan
		{
			[DebuggerStepThrough()]
			get { return this._processMan; }
			set 
			{
				if (this._processMan != value) 
				{
					this._processMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProcessMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _stopReason = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string StopReason
		{
			[DebuggerStepThrough()]
			get { return this._stopReason; }
			set 
			{
				if (this._stopReason != value) 
				{
					this._stopReason = value;
					this.IsDirty = true;	
					OnPropertyChanged("StopReason");
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
	[ContractID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[StopTime] datetime,
	[ProcessMan] nvarchar(50),
	[StopReason] ntext
);

INSERT INTO [dbo].[Contract_Stop] (
	[Contract_Stop].[ContractID],
	[Contract_Stop].[AddTime],
	[Contract_Stop].[AddMan],
	[Contract_Stop].[StopTime],
	[Contract_Stop].[ProcessMan],
	[Contract_Stop].[StopReason]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[StopTime],
	INSERTED.[ProcessMan],
	INSERTED.[StopReason]
into @table
VALUES ( 
	@ContractID,
	@AddTime,
	@AddMan,
	@StopTime,
	@ProcessMan,
	@StopReason 
); 

SELECT 
	[ID],
	[ContractID],
	[AddTime],
	[AddMan],
	[StopTime],
	[ProcessMan],
	[StopReason] 
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
	[ContractID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[StopTime] datetime,
	[ProcessMan] nvarchar(50),
	[StopReason] ntext
);

UPDATE [dbo].[Contract_Stop] SET 
	[Contract_Stop].[ContractID] = @ContractID,
	[Contract_Stop].[AddTime] = @AddTime,
	[Contract_Stop].[AddMan] = @AddMan,
	[Contract_Stop].[StopTime] = @StopTime,
	[Contract_Stop].[ProcessMan] = @ProcessMan,
	[Contract_Stop].[StopReason] = @StopReason 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[StopTime],
	INSERTED.[ProcessMan],
	INSERTED.[StopReason]
into @table
WHERE 
	[Contract_Stop].[ID] = @ID

SELECT 
	[ID],
	[ContractID],
	[AddTime],
	[AddMan],
	[StopTime],
	[ProcessMan],
	[StopReason] 
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
DELETE FROM [dbo].[Contract_Stop]
WHERE 
	[Contract_Stop].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Contract_Stop() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetContract_Stop(this.ID));
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
	[Contract_Stop].[ID],
	[Contract_Stop].[ContractID],
	[Contract_Stop].[AddTime],
	[Contract_Stop].[AddMan],
	[Contract_Stop].[StopTime],
	[Contract_Stop].[ProcessMan],
	[Contract_Stop].[StopReason]
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
                return "Contract_Stop";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Contract_Stop into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractID">contractID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="stopTime">stopTime</param>
		/// <param name="processMan">processMan</param>
		/// <param name="stopReason">stopReason</param>
		public static void InsertContract_Stop(int @contractID, DateTime @addTime, string @addMan, DateTime @stopTime, string @processMan, string @stopReason)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertContract_Stop(@contractID, @addTime, @addMan, @stopTime, @processMan, @stopReason, helper);
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
		/// Insert a Contract_Stop into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractID">contractID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="stopTime">stopTime</param>
		/// <param name="processMan">processMan</param>
		/// <param name="stopReason">stopReason</param>
		/// <param name="helper">helper</param>
		internal static void InsertContract_Stop(int @contractID, DateTime @addTime, string @addMan, DateTime @stopTime, string @processMan, string @stopReason, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[StopTime] datetime,
	[ProcessMan] nvarchar(50),
	[StopReason] ntext
);

INSERT INTO [dbo].[Contract_Stop] (
	[Contract_Stop].[ContractID],
	[Contract_Stop].[AddTime],
	[Contract_Stop].[AddMan],
	[Contract_Stop].[StopTime],
	[Contract_Stop].[ProcessMan],
	[Contract_Stop].[StopReason]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[StopTime],
	INSERTED.[ProcessMan],
	INSERTED.[StopReason]
into @table
VALUES ( 
	@ContractID,
	@AddTime,
	@AddMan,
	@StopTime,
	@ProcessMan,
	@StopReason 
); 

SELECT 
	[ID],
	[ContractID],
	[AddTime],
	[AddMan],
	[StopTime],
	[ProcessMan],
	[StopReason] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@StopTime", EntityBase.GetDatabaseValue(@stopTime)));
			parameters.Add(new SqlParameter("@ProcessMan", EntityBase.GetDatabaseValue(@processMan)));
			parameters.Add(new SqlParameter("@StopReason", EntityBase.GetDatabaseValue(@stopReason)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Contract_Stop into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractID">contractID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="stopTime">stopTime</param>
		/// <param name="processMan">processMan</param>
		/// <param name="stopReason">stopReason</param>
		public static void UpdateContract_Stop(int @iD, int @contractID, DateTime @addTime, string @addMan, DateTime @stopTime, string @processMan, string @stopReason)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateContract_Stop(@iD, @contractID, @addTime, @addMan, @stopTime, @processMan, @stopReason, helper);
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
		/// Updates a Contract_Stop into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractID">contractID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="stopTime">stopTime</param>
		/// <param name="processMan">processMan</param>
		/// <param name="stopReason">stopReason</param>
		/// <param name="helper">helper</param>
		internal static void UpdateContract_Stop(int @iD, int @contractID, DateTime @addTime, string @addMan, DateTime @stopTime, string @processMan, string @stopReason, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[StopTime] datetime,
	[ProcessMan] nvarchar(50),
	[StopReason] ntext
);

UPDATE [dbo].[Contract_Stop] SET 
	[Contract_Stop].[ContractID] = @ContractID,
	[Contract_Stop].[AddTime] = @AddTime,
	[Contract_Stop].[AddMan] = @AddMan,
	[Contract_Stop].[StopTime] = @StopTime,
	[Contract_Stop].[ProcessMan] = @ProcessMan,
	[Contract_Stop].[StopReason] = @StopReason 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[StopTime],
	INSERTED.[ProcessMan],
	INSERTED.[StopReason]
into @table
WHERE 
	[Contract_Stop].[ID] = @ID

SELECT 
	[ID],
	[ContractID],
	[AddTime],
	[AddMan],
	[StopTime],
	[ProcessMan],
	[StopReason] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@StopTime", EntityBase.GetDatabaseValue(@stopTime)));
			parameters.Add(new SqlParameter("@ProcessMan", EntityBase.GetDatabaseValue(@processMan)));
			parameters.Add(new SqlParameter("@StopReason", EntityBase.GetDatabaseValue(@stopReason)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Contract_Stop from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteContract_Stop(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteContract_Stop(@iD, helper);
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
		/// Deletes a Contract_Stop from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteContract_Stop(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Contract_Stop]
WHERE 
	[Contract_Stop].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Contract_Stop object.
		/// </summary>
		/// <returns>The newly created Contract_Stop object.</returns>
		public static Contract_Stop CreateContract_Stop()
		{
			return InitializeNew<Contract_Stop>();
		}
		
		/// <summary>
		/// Retrieve information for a Contract_Stop by a Contract_Stop's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Contract_Stop</returns>
		public static Contract_Stop GetContract_Stop(int @iD)
		{
			string commandText = @"
SELECT 
" + Contract_Stop.SelectFieldList + @"
FROM [dbo].[Contract_Stop] 
WHERE 
	[Contract_Stop].[ID] = @ID " + Contract_Stop.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_Stop>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Contract_Stop by a Contract_Stop's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Contract_Stop</returns>
		public static Contract_Stop GetContract_Stop(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Contract_Stop.SelectFieldList + @"
FROM [dbo].[Contract_Stop] 
WHERE 
	[Contract_Stop].[ID] = @ID " + Contract_Stop.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_Stop>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Contract_Stop objects.
		/// </summary>
		/// <returns>The retrieved collection of Contract_Stop objects.</returns>
		public static EntityList<Contract_Stop> GetContract_Stops()
		{
			string commandText = @"
SELECT " + Contract_Stop.SelectFieldList + "FROM [dbo].[Contract_Stop] " + Contract_Stop.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Contract_Stop>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Contract_Stop objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_Stop objects.</returns>
        public static EntityList<Contract_Stop> GetContract_Stops(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Stop>(SelectFieldList, "FROM [dbo].[Contract_Stop]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Contract_Stop objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_Stop objects.</returns>
        public static EntityList<Contract_Stop> GetContract_Stops(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Stop>(SelectFieldList, "FROM [dbo].[Contract_Stop]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Contract_Stop objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Contract_Stop objects.</returns>
		protected static EntityList<Contract_Stop> GetContract_Stops(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Stops(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Contract_Stop objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_Stop objects.</returns>
		protected static EntityList<Contract_Stop> GetContract_Stops(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Stops(string.Empty, where, parameters, Contract_Stop.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Stop objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_Stop objects.</returns>
		protected static EntityList<Contract_Stop> GetContract_Stops(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Stops(prefix, where, parameters, Contract_Stop.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Stop objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_Stop objects.</returns>
		protected static EntityList<Contract_Stop> GetContract_Stops(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_Stops(string.Empty, where, parameters, Contract_Stop.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Stop objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_Stop objects.</returns>
		protected static EntityList<Contract_Stop> GetContract_Stops(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_Stops(prefix, where, parameters, Contract_Stop.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Stop objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Contract_Stop objects.</returns>
		protected static EntityList<Contract_Stop> GetContract_Stops(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Contract_Stop.SelectFieldList + "FROM [dbo].[Contract_Stop] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Contract_Stop>(reader);
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
        protected static EntityList<Contract_Stop> GetContract_Stops(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Stop>(SelectFieldList, "FROM [dbo].[Contract_Stop] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Contract_Stop objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_StopCount()
        {
            return GetContract_StopCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Contract_Stop objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_StopCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Contract_Stop] " + where;

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
		public static partial class Contract_Stop_Properties
		{
			public const string ID = "ID";
			public const string ContractID = "ContractID";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string StopTime = "StopTime";
			public const string ProcessMan = "ProcessMan";
			public const string StopReason = "StopReason";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ContractID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"StopTime" , "DateTime:"},
    			 {"ProcessMan" , "string:"},
    			 {"StopReason" , "string:"},
            };
		}
		#endregion
	}
}
