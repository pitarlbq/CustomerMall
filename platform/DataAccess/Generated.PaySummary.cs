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
	/// This object represents the properties and methods of a PaySummary.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class PaySummary 
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
		private string _payName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PayName
		{
			[DebuggerStepThrough()]
			get { return this._payName; }
			set 
			{
				if (this._payName != value) 
				{
					this._payName = value;
					this.IsDirty = true;	
					OnPropertyChanged("PayName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _pID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PID
		{
			[DebuggerStepThrough()]
			get { return this._pID; }
			set 
			{
				if (this._pID != value) 
				{
					this._pID = value;
					this.IsDirty = true;	
					OnPropertyChanged("PID");
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
		private bool _relateFeeType_Pay = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool RelateFeeType_Pay
		{
			[DebuggerStepThrough()]
			get { return this._relateFeeType_Pay; }
			set 
			{
				if (this._relateFeeType_Pay != value) 
				{
					this._relateFeeType_Pay = value;
					this.IsDirty = true;	
					OnPropertyChanged("RelateFeeType_Pay");
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
	[PayName] nvarchar(100),
	[PID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[Remark] ntext,
	[RelateFeeType_Pay] bit
);

INSERT INTO [dbo].[PaySummary] (
	[PaySummary].[PayName],
	[PaySummary].[PID],
	[PaySummary].[AddTime],
	[PaySummary].[AddMan],
	[PaySummary].[Remark],
	[PaySummary].[RelateFeeType_Pay]
) 
output 
	INSERTED.[ID],
	INSERTED.[PayName],
	INSERTED.[PID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[Remark],
	INSERTED.[RelateFeeType_Pay]
into @table
VALUES ( 
	@PayName,
	@PID,
	@AddTime,
	@AddMan,
	@Remark,
	@RelateFeeType_Pay 
); 

SELECT 
	[ID],
	[PayName],
	[PID],
	[AddTime],
	[AddMan],
	[Remark],
	[RelateFeeType_Pay] 
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
	[PayName] nvarchar(100),
	[PID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[Remark] ntext,
	[RelateFeeType_Pay] bit
);

UPDATE [dbo].[PaySummary] SET 
	[PaySummary].[PayName] = @PayName,
	[PaySummary].[PID] = @PID,
	[PaySummary].[AddTime] = @AddTime,
	[PaySummary].[AddMan] = @AddMan,
	[PaySummary].[Remark] = @Remark,
	[PaySummary].[RelateFeeType_Pay] = @RelateFeeType_Pay 
output 
	INSERTED.[ID],
	INSERTED.[PayName],
	INSERTED.[PID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[Remark],
	INSERTED.[RelateFeeType_Pay]
into @table
WHERE 
	[PaySummary].[ID] = @ID

SELECT 
	[ID],
	[PayName],
	[PID],
	[AddTime],
	[AddMan],
	[Remark],
	[RelateFeeType_Pay] 
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
DELETE FROM [dbo].[PaySummary]
WHERE 
	[PaySummary].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public PaySummary() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetPaySummary(this.ID));
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
	[PaySummary].[ID],
	[PaySummary].[PayName],
	[PaySummary].[PID],
	[PaySummary].[AddTime],
	[PaySummary].[AddMan],
	[PaySummary].[Remark],
	[PaySummary].[RelateFeeType_Pay]
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
                return "PaySummary";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a PaySummary into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="payName">payName</param>
		/// <param name="pID">pID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="remark">remark</param>
		/// <param name="relateFeeType_Pay">relateFeeType_Pay</param>
		public static void InsertPaySummary(string @payName, int @pID, DateTime @addTime, string @addMan, string @remark, bool @relateFeeType_Pay)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertPaySummary(@payName, @pID, @addTime, @addMan, @remark, @relateFeeType_Pay, helper);
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
		/// Insert a PaySummary into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="payName">payName</param>
		/// <param name="pID">pID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="remark">remark</param>
		/// <param name="relateFeeType_Pay">relateFeeType_Pay</param>
		/// <param name="helper">helper</param>
		internal static void InsertPaySummary(string @payName, int @pID, DateTime @addTime, string @addMan, string @remark, bool @relateFeeType_Pay, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[PayName] nvarchar(100),
	[PID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[Remark] ntext,
	[RelateFeeType_Pay] bit
);

INSERT INTO [dbo].[PaySummary] (
	[PaySummary].[PayName],
	[PaySummary].[PID],
	[PaySummary].[AddTime],
	[PaySummary].[AddMan],
	[PaySummary].[Remark],
	[PaySummary].[RelateFeeType_Pay]
) 
output 
	INSERTED.[ID],
	INSERTED.[PayName],
	INSERTED.[PID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[Remark],
	INSERTED.[RelateFeeType_Pay]
into @table
VALUES ( 
	@PayName,
	@PID,
	@AddTime,
	@AddMan,
	@Remark,
	@RelateFeeType_Pay 
); 

SELECT 
	[ID],
	[PayName],
	[PID],
	[AddTime],
	[AddMan],
	[Remark],
	[RelateFeeType_Pay] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@PayName", EntityBase.GetDatabaseValue(@payName)));
			parameters.Add(new SqlParameter("@PID", EntityBase.GetDatabaseValue(@pID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@RelateFeeType_Pay", @relateFeeType_Pay));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a PaySummary into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="payName">payName</param>
		/// <param name="pID">pID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="remark">remark</param>
		/// <param name="relateFeeType_Pay">relateFeeType_Pay</param>
		public static void UpdatePaySummary(int @iD, string @payName, int @pID, DateTime @addTime, string @addMan, string @remark, bool @relateFeeType_Pay)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdatePaySummary(@iD, @payName, @pID, @addTime, @addMan, @remark, @relateFeeType_Pay, helper);
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
		/// Updates a PaySummary into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="payName">payName</param>
		/// <param name="pID">pID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="remark">remark</param>
		/// <param name="relateFeeType_Pay">relateFeeType_Pay</param>
		/// <param name="helper">helper</param>
		internal static void UpdatePaySummary(int @iD, string @payName, int @pID, DateTime @addTime, string @addMan, string @remark, bool @relateFeeType_Pay, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[PayName] nvarchar(100),
	[PID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[Remark] ntext,
	[RelateFeeType_Pay] bit
);

UPDATE [dbo].[PaySummary] SET 
	[PaySummary].[PayName] = @PayName,
	[PaySummary].[PID] = @PID,
	[PaySummary].[AddTime] = @AddTime,
	[PaySummary].[AddMan] = @AddMan,
	[PaySummary].[Remark] = @Remark,
	[PaySummary].[RelateFeeType_Pay] = @RelateFeeType_Pay 
output 
	INSERTED.[ID],
	INSERTED.[PayName],
	INSERTED.[PID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[Remark],
	INSERTED.[RelateFeeType_Pay]
into @table
WHERE 
	[PaySummary].[ID] = @ID

SELECT 
	[ID],
	[PayName],
	[PID],
	[AddTime],
	[AddMan],
	[Remark],
	[RelateFeeType_Pay] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@PayName", EntityBase.GetDatabaseValue(@payName)));
			parameters.Add(new SqlParameter("@PID", EntityBase.GetDatabaseValue(@pID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@RelateFeeType_Pay", @relateFeeType_Pay));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a PaySummary from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeletePaySummary(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeletePaySummary(@iD, helper);
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
		/// Deletes a PaySummary from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeletePaySummary(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[PaySummary]
WHERE 
	[PaySummary].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new PaySummary object.
		/// </summary>
		/// <returns>The newly created PaySummary object.</returns>
		public static PaySummary CreatePaySummary()
		{
			return InitializeNew<PaySummary>();
		}
		
		/// <summary>
		/// Retrieve information for a PaySummary by a PaySummary's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>PaySummary</returns>
		public static PaySummary GetPaySummary(int @iD)
		{
			string commandText = @"
SELECT 
" + PaySummary.SelectFieldList + @"
FROM [dbo].[PaySummary] 
WHERE 
	[PaySummary].[ID] = @ID " + PaySummary.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<PaySummary>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a PaySummary by a PaySummary's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>PaySummary</returns>
		public static PaySummary GetPaySummary(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + PaySummary.SelectFieldList + @"
FROM [dbo].[PaySummary] 
WHERE 
	[PaySummary].[ID] = @ID " + PaySummary.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<PaySummary>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection PaySummary objects.
		/// </summary>
		/// <returns>The retrieved collection of PaySummary objects.</returns>
		public static EntityList<PaySummary> GetPaySummaries()
		{
			string commandText = @"
SELECT " + PaySummary.SelectFieldList + "FROM [dbo].[PaySummary] " + PaySummary.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<PaySummary>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection PaySummary objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of PaySummary objects.</returns>
        public static EntityList<PaySummary> GetPaySummaries(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PaySummary>(SelectFieldList, "FROM [dbo].[PaySummary]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection PaySummary objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of PaySummary objects.</returns>
        public static EntityList<PaySummary> GetPaySummaries(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PaySummary>(SelectFieldList, "FROM [dbo].[PaySummary]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection PaySummary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of PaySummary objects.</returns>
		protected static EntityList<PaySummary> GetPaySummaries(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPaySummaries(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection PaySummary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of PaySummary objects.</returns>
		protected static EntityList<PaySummary> GetPaySummaries(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPaySummaries(string.Empty, where, parameters, PaySummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PaySummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of PaySummary objects.</returns>
		protected static EntityList<PaySummary> GetPaySummaries(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPaySummaries(prefix, where, parameters, PaySummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PaySummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of PaySummary objects.</returns>
		protected static EntityList<PaySummary> GetPaySummaries(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetPaySummaries(string.Empty, where, parameters, PaySummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PaySummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of PaySummary objects.</returns>
		protected static EntityList<PaySummary> GetPaySummaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetPaySummaries(prefix, where, parameters, PaySummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PaySummary objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of PaySummary objects.</returns>
		protected static EntityList<PaySummary> GetPaySummaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + PaySummary.SelectFieldList + "FROM [dbo].[PaySummary] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<PaySummary>(reader);
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
        protected static EntityList<PaySummary> GetPaySummaries(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PaySummary>(SelectFieldList, "FROM [dbo].[PaySummary] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of PaySummary objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetPaySummaryCount()
        {
            return GetPaySummaryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of PaySummary objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetPaySummaryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[PaySummary] " + where;

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
		public static partial class PaySummary_Properties
		{
			public const string ID = "ID";
			public const string PayName = "PayName";
			public const string PID = "PID";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string Remark = "Remark";
			public const string RelateFeeType_Pay = "RelateFeeType_Pay";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"PayName" , "string:"},
    			 {"PID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"Remark" , "string:"},
    			 {"RelateFeeType_Pay" , "bool:"},
            };
		}
		#endregion
	}
}
