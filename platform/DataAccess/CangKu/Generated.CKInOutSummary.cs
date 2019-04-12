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
	/// This object represents the properties and methods of a CKInOutSummary.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CKInOutSummary 
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
		private int _cKProudctInDetailID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int CKProudctInDetailID
		{
			[DebuggerStepThrough()]
			get { return this._cKProudctInDetailID; }
			set 
			{
				if (this._cKProudctInDetailID != value) 
				{
					this._cKProudctInDetailID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CKProudctInDetailID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _cKProudctOutDetailID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int CKProudctOutDetailID
		{
			[DebuggerStepThrough()]
			get { return this._cKProudctOutDetailID; }
			set 
			{
				if (this._cKProudctOutDetailID != value) 
				{
					this._cKProudctOutDetailID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CKProudctOutDetailID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _inventory = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Inventory
		{
			[DebuggerStepThrough()]
			get { return this._inventory; }
			set 
			{
				if (this._inventory != value) 
				{
					this._inventory = value;
					this.IsDirty = true;	
					OnPropertyChanged("Inventory");
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
	[CKProudctInDetailID] int,
	[CKProudctOutDetailID] int,
	[Inventory] int,
	[AddTime] datetime
);

INSERT INTO [dbo].[CKInOutSummary] (
	[CKInOutSummary].[CKProudctInDetailID],
	[CKInOutSummary].[CKProudctOutDetailID],
	[CKInOutSummary].[Inventory],
	[CKInOutSummary].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[CKProudctInDetailID],
	INSERTED.[CKProudctOutDetailID],
	INSERTED.[Inventory],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@CKProudctInDetailID,
	@CKProudctOutDetailID,
	@Inventory,
	@AddTime 
); 

SELECT 
	[ID],
	[CKProudctInDetailID],
	[CKProudctOutDetailID],
	[Inventory],
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
	[CKProudctInDetailID] int,
	[CKProudctOutDetailID] int,
	[Inventory] int,
	[AddTime] datetime
);

UPDATE [dbo].[CKInOutSummary] SET 
	[CKInOutSummary].[CKProudctInDetailID] = @CKProudctInDetailID,
	[CKInOutSummary].[CKProudctOutDetailID] = @CKProudctOutDetailID,
	[CKInOutSummary].[Inventory] = @Inventory,
	[CKInOutSummary].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[CKProudctInDetailID],
	INSERTED.[CKProudctOutDetailID],
	INSERTED.[Inventory],
	INSERTED.[AddTime]
into @table
WHERE 
	[CKInOutSummary].[ID] = @ID

SELECT 
	[ID],
	[CKProudctInDetailID],
	[CKProudctOutDetailID],
	[Inventory],
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
DELETE FROM [dbo].[CKInOutSummary]
WHERE 
	[CKInOutSummary].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CKInOutSummary() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCKInOutSummary(this.ID));
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
	[CKInOutSummary].[ID],
	[CKInOutSummary].[CKProudctInDetailID],
	[CKInOutSummary].[CKProudctOutDetailID],
	[CKInOutSummary].[Inventory],
	[CKInOutSummary].[AddTime]
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
                return "CKInOutSummary";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CKInOutSummary into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="cKProudctInDetailID">cKProudctInDetailID</param>
		/// <param name="cKProudctOutDetailID">cKProudctOutDetailID</param>
		/// <param name="inventory">inventory</param>
		/// <param name="addTime">addTime</param>
		public static void InsertCKInOutSummary(int @cKProudctInDetailID, int @cKProudctOutDetailID, int @inventory, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCKInOutSummary(@cKProudctInDetailID, @cKProudctOutDetailID, @inventory, @addTime, helper);
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
		/// Insert a CKInOutSummary into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="cKProudctInDetailID">cKProudctInDetailID</param>
		/// <param name="cKProudctOutDetailID">cKProudctOutDetailID</param>
		/// <param name="inventory">inventory</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertCKInOutSummary(int @cKProudctInDetailID, int @cKProudctOutDetailID, int @inventory, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CKProudctInDetailID] int,
	[CKProudctOutDetailID] int,
	[Inventory] int,
	[AddTime] datetime
);

INSERT INTO [dbo].[CKInOutSummary] (
	[CKInOutSummary].[CKProudctInDetailID],
	[CKInOutSummary].[CKProudctOutDetailID],
	[CKInOutSummary].[Inventory],
	[CKInOutSummary].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[CKProudctInDetailID],
	INSERTED.[CKProudctOutDetailID],
	INSERTED.[Inventory],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@CKProudctInDetailID,
	@CKProudctOutDetailID,
	@Inventory,
	@AddTime 
); 

SELECT 
	[ID],
	[CKProudctInDetailID],
	[CKProudctOutDetailID],
	[Inventory],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CKProudctInDetailID", EntityBase.GetDatabaseValue(@cKProudctInDetailID)));
			parameters.Add(new SqlParameter("@CKProudctOutDetailID", EntityBase.GetDatabaseValue(@cKProudctOutDetailID)));
			parameters.Add(new SqlParameter("@Inventory", EntityBase.GetDatabaseValue(@inventory)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CKInOutSummary into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="cKProudctInDetailID">cKProudctInDetailID</param>
		/// <param name="cKProudctOutDetailID">cKProudctOutDetailID</param>
		/// <param name="inventory">inventory</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateCKInOutSummary(int @iD, int @cKProudctInDetailID, int @cKProudctOutDetailID, int @inventory, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCKInOutSummary(@iD, @cKProudctInDetailID, @cKProudctOutDetailID, @inventory, @addTime, helper);
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
		/// Updates a CKInOutSummary into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="cKProudctInDetailID">cKProudctInDetailID</param>
		/// <param name="cKProudctOutDetailID">cKProudctOutDetailID</param>
		/// <param name="inventory">inventory</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCKInOutSummary(int @iD, int @cKProudctInDetailID, int @cKProudctOutDetailID, int @inventory, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CKProudctInDetailID] int,
	[CKProudctOutDetailID] int,
	[Inventory] int,
	[AddTime] datetime
);

UPDATE [dbo].[CKInOutSummary] SET 
	[CKInOutSummary].[CKProudctInDetailID] = @CKProudctInDetailID,
	[CKInOutSummary].[CKProudctOutDetailID] = @CKProudctOutDetailID,
	[CKInOutSummary].[Inventory] = @Inventory,
	[CKInOutSummary].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[CKProudctInDetailID],
	INSERTED.[CKProudctOutDetailID],
	INSERTED.[Inventory],
	INSERTED.[AddTime]
into @table
WHERE 
	[CKInOutSummary].[ID] = @ID

SELECT 
	[ID],
	[CKProudctInDetailID],
	[CKProudctOutDetailID],
	[Inventory],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@CKProudctInDetailID", EntityBase.GetDatabaseValue(@cKProudctInDetailID)));
			parameters.Add(new SqlParameter("@CKProudctOutDetailID", EntityBase.GetDatabaseValue(@cKProudctOutDetailID)));
			parameters.Add(new SqlParameter("@Inventory", EntityBase.GetDatabaseValue(@inventory)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CKInOutSummary from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCKInOutSummary(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCKInOutSummary(@iD, helper);
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
		/// Deletes a CKInOutSummary from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCKInOutSummary(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CKInOutSummary]
WHERE 
	[CKInOutSummary].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CKInOutSummary object.
		/// </summary>
		/// <returns>The newly created CKInOutSummary object.</returns>
		public static CKInOutSummary CreateCKInOutSummary()
		{
			return InitializeNew<CKInOutSummary>();
		}
		
		/// <summary>
		/// Retrieve information for a CKInOutSummary by a CKInOutSummary's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CKInOutSummary</returns>
		public static CKInOutSummary GetCKInOutSummary(int @iD)
		{
			string commandText = @"
SELECT 
" + CKInOutSummary.SelectFieldList + @"
FROM [dbo].[CKInOutSummary] 
WHERE 
	[CKInOutSummary].[ID] = @ID " + CKInOutSummary.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKInOutSummary>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CKInOutSummary by a CKInOutSummary's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CKInOutSummary</returns>
		public static CKInOutSummary GetCKInOutSummary(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CKInOutSummary.SelectFieldList + @"
FROM [dbo].[CKInOutSummary] 
WHERE 
	[CKInOutSummary].[ID] = @ID " + CKInOutSummary.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKInOutSummary>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CKInOutSummary objects.
		/// </summary>
		/// <returns>The retrieved collection of CKInOutSummary objects.</returns>
		public static EntityList<CKInOutSummary> GetCKInOutSummaries()
		{
			string commandText = @"
SELECT " + CKInOutSummary.SelectFieldList + "FROM [dbo].[CKInOutSummary] " + CKInOutSummary.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CKInOutSummary>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CKInOutSummary objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKInOutSummary objects.</returns>
        public static EntityList<CKInOutSummary> GetCKInOutSummaries(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKInOutSummary>(SelectFieldList, "FROM [dbo].[CKInOutSummary]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CKInOutSummary objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKInOutSummary objects.</returns>
        public static EntityList<CKInOutSummary> GetCKInOutSummaries(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKInOutSummary>(SelectFieldList, "FROM [dbo].[CKInOutSummary]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CKInOutSummary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CKInOutSummary objects.</returns>
		protected static EntityList<CKInOutSummary> GetCKInOutSummaries(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKInOutSummaries(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CKInOutSummary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKInOutSummary objects.</returns>
		protected static EntityList<CKInOutSummary> GetCKInOutSummaries(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKInOutSummaries(string.Empty, where, parameters, CKInOutSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKInOutSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKInOutSummary objects.</returns>
		protected static EntityList<CKInOutSummary> GetCKInOutSummaries(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKInOutSummaries(prefix, where, parameters, CKInOutSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKInOutSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKInOutSummary objects.</returns>
		protected static EntityList<CKInOutSummary> GetCKInOutSummaries(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKInOutSummaries(string.Empty, where, parameters, CKInOutSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKInOutSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKInOutSummary objects.</returns>
		protected static EntityList<CKInOutSummary> GetCKInOutSummaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKInOutSummaries(prefix, where, parameters, CKInOutSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKInOutSummary objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CKInOutSummary objects.</returns>
		protected static EntityList<CKInOutSummary> GetCKInOutSummaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CKInOutSummary.SelectFieldList + "FROM [dbo].[CKInOutSummary] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CKInOutSummary>(reader);
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
        protected static EntityList<CKInOutSummary> GetCKInOutSummaries(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKInOutSummary>(SelectFieldList, "FROM [dbo].[CKInOutSummary] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CKInOutSummary objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKInOutSummaryCount()
        {
            return GetCKInOutSummaryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CKInOutSummary objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKInOutSummaryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CKInOutSummary] " + where;

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
		public static partial class CKInOutSummary_Properties
		{
			public const string ID = "ID";
			public const string CKProudctInDetailID = "CKProudctInDetailID";
			public const string CKProudctOutDetailID = "CKProudctOutDetailID";
			public const string Inventory = "Inventory";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CKProudctInDetailID" , "int:"},
    			 {"CKProudctOutDetailID" , "int:"},
    			 {"Inventory" , "int:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
