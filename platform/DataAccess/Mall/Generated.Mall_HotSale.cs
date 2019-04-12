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
	/// This object represents the properties and methods of a Mall_HotSale.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_HotSale 
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
		private int _relatedID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RelatedID
		{
			[DebuggerStepThrough()]
			get { return this._relatedID; }
			set 
			{
				if (this._relatedID != value) 
				{
					this._relatedID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RelatedID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _type = int.MinValue;
		/// <summary>
		/// 1-商品 2-商家
		/// </summary>
        [Description("1-商品 2-商家")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int Type
		{
			[DebuggerStepThrough()]
			get { return this._type; }
			set 
			{
				if (this._type != value) 
				{
					this._type = value;
					this.IsDirty = true;	
					OnPropertyChanged("Type");
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
		private DateTime _startTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime StartTime
		{
			[DebuggerStepThrough()]
			get { return this._startTime; }
			set 
			{
				if (this._startTime != value) 
				{
					this._startTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("StartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _endTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime EndTime
		{
			[DebuggerStepThrough()]
			get { return this._endTime; }
			set 
			{
				if (this._endTime != value) 
				{
					this._endTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndTime");
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
	[RelatedID] int,
	[Type] int,
	[AddTime] datetime,
	[StartTime] datetime,
	[EndTime] datetime,
	[SortOrder] int
);

INSERT INTO [dbo].[Mall_HotSale] (
	[Mall_HotSale].[RelatedID],
	[Mall_HotSale].[Type],
	[Mall_HotSale].[AddTime],
	[Mall_HotSale].[StartTime],
	[Mall_HotSale].[EndTime],
	[Mall_HotSale].[SortOrder]
) 
output 
	INSERTED.[ID],
	INSERTED.[RelatedID],
	INSERTED.[Type],
	INSERTED.[AddTime],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[SortOrder]
into @table
VALUES ( 
	@RelatedID,
	@Type,
	@AddTime,
	@StartTime,
	@EndTime,
	@SortOrder 
); 

SELECT 
	[ID],
	[RelatedID],
	[Type],
	[AddTime],
	[StartTime],
	[EndTime],
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
	[RelatedID] int,
	[Type] int,
	[AddTime] datetime,
	[StartTime] datetime,
	[EndTime] datetime,
	[SortOrder] int
);

UPDATE [dbo].[Mall_HotSale] SET 
	[Mall_HotSale].[RelatedID] = @RelatedID,
	[Mall_HotSale].[Type] = @Type,
	[Mall_HotSale].[AddTime] = @AddTime,
	[Mall_HotSale].[StartTime] = @StartTime,
	[Mall_HotSale].[EndTime] = @EndTime,
	[Mall_HotSale].[SortOrder] = @SortOrder 
output 
	INSERTED.[ID],
	INSERTED.[RelatedID],
	INSERTED.[Type],
	INSERTED.[AddTime],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[SortOrder]
into @table
WHERE 
	[Mall_HotSale].[ID] = @ID

SELECT 
	[ID],
	[RelatedID],
	[Type],
	[AddTime],
	[StartTime],
	[EndTime],
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
DELETE FROM [dbo].[Mall_HotSale]
WHERE 
	[Mall_HotSale].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_HotSale() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_HotSale(this.ID));
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
	[Mall_HotSale].[ID],
	[Mall_HotSale].[RelatedID],
	[Mall_HotSale].[Type],
	[Mall_HotSale].[AddTime],
	[Mall_HotSale].[StartTime],
	[Mall_HotSale].[EndTime],
	[Mall_HotSale].[SortOrder]
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
                return "Mall_HotSale";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_HotSale into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="relatedID">relatedID</param>
		/// <param name="type">type</param>
		/// <param name="addTime">addTime</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="sortOrder">sortOrder</param>
		public static void InsertMall_HotSale(int @relatedID, int @type, DateTime @addTime, DateTime @startTime, DateTime @endTime, int @sortOrder)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_HotSale(@relatedID, @type, @addTime, @startTime, @endTime, @sortOrder, helper);
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
		/// Insert a Mall_HotSale into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="relatedID">relatedID</param>
		/// <param name="type">type</param>
		/// <param name="addTime">addTime</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_HotSale(int @relatedID, int @type, DateTime @addTime, DateTime @startTime, DateTime @endTime, int @sortOrder, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RelatedID] int,
	[Type] int,
	[AddTime] datetime,
	[StartTime] datetime,
	[EndTime] datetime,
	[SortOrder] int
);

INSERT INTO [dbo].[Mall_HotSale] (
	[Mall_HotSale].[RelatedID],
	[Mall_HotSale].[Type],
	[Mall_HotSale].[AddTime],
	[Mall_HotSale].[StartTime],
	[Mall_HotSale].[EndTime],
	[Mall_HotSale].[SortOrder]
) 
output 
	INSERTED.[ID],
	INSERTED.[RelatedID],
	INSERTED.[Type],
	INSERTED.[AddTime],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[SortOrder]
into @table
VALUES ( 
	@RelatedID,
	@Type,
	@AddTime,
	@StartTime,
	@EndTime,
	@SortOrder 
); 

SELECT 
	[ID],
	[RelatedID],
	[Type],
	[AddTime],
	[StartTime],
	[EndTime],
	[SortOrder] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RelatedID", EntityBase.GetDatabaseValue(@relatedID)));
			parameters.Add(new SqlParameter("@Type", EntityBase.GetDatabaseValue(@type)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_HotSale into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="relatedID">relatedID</param>
		/// <param name="type">type</param>
		/// <param name="addTime">addTime</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="sortOrder">sortOrder</param>
		public static void UpdateMall_HotSale(int @iD, int @relatedID, int @type, DateTime @addTime, DateTime @startTime, DateTime @endTime, int @sortOrder)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_HotSale(@iD, @relatedID, @type, @addTime, @startTime, @endTime, @sortOrder, helper);
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
		/// Updates a Mall_HotSale into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="relatedID">relatedID</param>
		/// <param name="type">type</param>
		/// <param name="addTime">addTime</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_HotSale(int @iD, int @relatedID, int @type, DateTime @addTime, DateTime @startTime, DateTime @endTime, int @sortOrder, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RelatedID] int,
	[Type] int,
	[AddTime] datetime,
	[StartTime] datetime,
	[EndTime] datetime,
	[SortOrder] int
);

UPDATE [dbo].[Mall_HotSale] SET 
	[Mall_HotSale].[RelatedID] = @RelatedID,
	[Mall_HotSale].[Type] = @Type,
	[Mall_HotSale].[AddTime] = @AddTime,
	[Mall_HotSale].[StartTime] = @StartTime,
	[Mall_HotSale].[EndTime] = @EndTime,
	[Mall_HotSale].[SortOrder] = @SortOrder 
output 
	INSERTED.[ID],
	INSERTED.[RelatedID],
	INSERTED.[Type],
	INSERTED.[AddTime],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[SortOrder]
into @table
WHERE 
	[Mall_HotSale].[ID] = @ID

SELECT 
	[ID],
	[RelatedID],
	[Type],
	[AddTime],
	[StartTime],
	[EndTime],
	[SortOrder] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RelatedID", EntityBase.GetDatabaseValue(@relatedID)));
			parameters.Add(new SqlParameter("@Type", EntityBase.GetDatabaseValue(@type)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_HotSale from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_HotSale(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_HotSale(@iD, helper);
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
		/// Deletes a Mall_HotSale from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_HotSale(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_HotSale]
WHERE 
	[Mall_HotSale].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_HotSale object.
		/// </summary>
		/// <returns>The newly created Mall_HotSale object.</returns>
		public static Mall_HotSale CreateMall_HotSale()
		{
			return InitializeNew<Mall_HotSale>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_HotSale by a Mall_HotSale's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_HotSale</returns>
		public static Mall_HotSale GetMall_HotSale(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_HotSale.SelectFieldList + @"
FROM [dbo].[Mall_HotSale] 
WHERE 
	[Mall_HotSale].[ID] = @ID " + Mall_HotSale.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_HotSale>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_HotSale by a Mall_HotSale's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_HotSale</returns>
		public static Mall_HotSale GetMall_HotSale(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_HotSale.SelectFieldList + @"
FROM [dbo].[Mall_HotSale] 
WHERE 
	[Mall_HotSale].[ID] = @ID " + Mall_HotSale.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_HotSale>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_HotSale objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_HotSale objects.</returns>
		public static EntityList<Mall_HotSale> GetMall_HotSales()
		{
			string commandText = @"
SELECT " + Mall_HotSale.SelectFieldList + "FROM [dbo].[Mall_HotSale] " + Mall_HotSale.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_HotSale>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_HotSale objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_HotSale objects.</returns>
        public static EntityList<Mall_HotSale> GetMall_HotSales(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_HotSale>(SelectFieldList, "FROM [dbo].[Mall_HotSale]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_HotSale objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_HotSale objects.</returns>
        public static EntityList<Mall_HotSale> GetMall_HotSales(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_HotSale>(SelectFieldList, "FROM [dbo].[Mall_HotSale]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_HotSale objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_HotSale objects.</returns>
		protected static EntityList<Mall_HotSale> GetMall_HotSales(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_HotSales(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_HotSale objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_HotSale objects.</returns>
		protected static EntityList<Mall_HotSale> GetMall_HotSales(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_HotSales(string.Empty, where, parameters, Mall_HotSale.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_HotSale objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_HotSale objects.</returns>
		protected static EntityList<Mall_HotSale> GetMall_HotSales(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_HotSales(prefix, where, parameters, Mall_HotSale.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_HotSale objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_HotSale objects.</returns>
		protected static EntityList<Mall_HotSale> GetMall_HotSales(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_HotSales(string.Empty, where, parameters, Mall_HotSale.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_HotSale objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_HotSale objects.</returns>
		protected static EntityList<Mall_HotSale> GetMall_HotSales(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_HotSales(prefix, where, parameters, Mall_HotSale.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_HotSale objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_HotSale objects.</returns>
		protected static EntityList<Mall_HotSale> GetMall_HotSales(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_HotSale.SelectFieldList + "FROM [dbo].[Mall_HotSale] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_HotSale>(reader);
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
        protected static EntityList<Mall_HotSale> GetMall_HotSales(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_HotSale>(SelectFieldList, "FROM [dbo].[Mall_HotSale] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_HotSale objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_HotSaleCount()
        {
            return GetMall_HotSaleCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_HotSale objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_HotSaleCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_HotSale] " + where;

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
		public static partial class Mall_HotSale_Properties
		{
			public const string ID = "ID";
			public const string RelatedID = "RelatedID";
			public const string Type = "Type";
			public const string AddTime = "AddTime";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string SortOrder = "SortOrder";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RelatedID" , "int:"},
    			 {"Type" , "int:1-商品 2-商家"},
    			 {"AddTime" , "DateTime:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"SortOrder" , "int:"},
            };
		}
		#endregion
	}
}
