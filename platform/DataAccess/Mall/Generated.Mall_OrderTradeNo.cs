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
	/// This object represents the properties and methods of a Mall_OrderTradeNo.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_OrderTradeNo 
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
		private int _orderID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int OrderID
		{
			[DebuggerStepThrough()]
			get { return this._orderID; }
			set 
			{
				if (this._orderID != value) 
				{
					this._orderID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _tradeNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string TradeNo
		{
			[DebuggerStepThrough()]
			get { return this._tradeNo; }
			set 
			{
				if (this._tradeNo != value) 
				{
					this._tradeNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("TradeNo");
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
	[OrderID] int,
	[TradeNo] nvarchar(100),
	[AddTime] datetime
);

INSERT INTO [dbo].[Mall_OrderTradeNo] (
	[Mall_OrderTradeNo].[OrderID],
	[Mall_OrderTradeNo].[TradeNo],
	[Mall_OrderTradeNo].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[TradeNo],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@OrderID,
	@TradeNo,
	@AddTime 
); 

SELECT 
	[ID],
	[OrderID],
	[TradeNo],
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
	[OrderID] int,
	[TradeNo] nvarchar(100),
	[AddTime] datetime
);

UPDATE [dbo].[Mall_OrderTradeNo] SET 
	[Mall_OrderTradeNo].[OrderID] = @OrderID,
	[Mall_OrderTradeNo].[TradeNo] = @TradeNo,
	[Mall_OrderTradeNo].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[TradeNo],
	INSERTED.[AddTime]
into @table
WHERE 
	[Mall_OrderTradeNo].[ID] = @ID

SELECT 
	[ID],
	[OrderID],
	[TradeNo],
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
DELETE FROM [dbo].[Mall_OrderTradeNo]
WHERE 
	[Mall_OrderTradeNo].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_OrderTradeNo() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_OrderTradeNo(this.ID));
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
	[Mall_OrderTradeNo].[ID],
	[Mall_OrderTradeNo].[OrderID],
	[Mall_OrderTradeNo].[TradeNo],
	[Mall_OrderTradeNo].[AddTime]
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
                return "Mall_OrderTradeNo";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_OrderTradeNo into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderID">orderID</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="addTime">addTime</param>
		public static void InsertMall_OrderTradeNo(int @orderID, string @tradeNo, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_OrderTradeNo(@orderID, @tradeNo, @addTime, helper);
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
		/// Insert a Mall_OrderTradeNo into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderID">orderID</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_OrderTradeNo(int @orderID, string @tradeNo, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrderID] int,
	[TradeNo] nvarchar(100),
	[AddTime] datetime
);

INSERT INTO [dbo].[Mall_OrderTradeNo] (
	[Mall_OrderTradeNo].[OrderID],
	[Mall_OrderTradeNo].[TradeNo],
	[Mall_OrderTradeNo].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[TradeNo],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@OrderID,
	@TradeNo,
	@AddTime 
); 

SELECT 
	[ID],
	[OrderID],
	[TradeNo],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OrderID", EntityBase.GetDatabaseValue(@orderID)));
			parameters.Add(new SqlParameter("@TradeNo", EntityBase.GetDatabaseValue(@tradeNo)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_OrderTradeNo into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orderID">orderID</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateMall_OrderTradeNo(int @iD, int @orderID, string @tradeNo, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_OrderTradeNo(@iD, @orderID, @tradeNo, @addTime, helper);
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
		/// Updates a Mall_OrderTradeNo into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orderID">orderID</param>
		/// <param name="tradeNo">tradeNo</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_OrderTradeNo(int @iD, int @orderID, string @tradeNo, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrderID] int,
	[TradeNo] nvarchar(100),
	[AddTime] datetime
);

UPDATE [dbo].[Mall_OrderTradeNo] SET 
	[Mall_OrderTradeNo].[OrderID] = @OrderID,
	[Mall_OrderTradeNo].[TradeNo] = @TradeNo,
	[Mall_OrderTradeNo].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[TradeNo],
	INSERTED.[AddTime]
into @table
WHERE 
	[Mall_OrderTradeNo].[ID] = @ID

SELECT 
	[ID],
	[OrderID],
	[TradeNo],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OrderID", EntityBase.GetDatabaseValue(@orderID)));
			parameters.Add(new SqlParameter("@TradeNo", EntityBase.GetDatabaseValue(@tradeNo)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_OrderTradeNo from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_OrderTradeNo(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_OrderTradeNo(@iD, helper);
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
		/// Deletes a Mall_OrderTradeNo from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_OrderTradeNo(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_OrderTradeNo]
WHERE 
	[Mall_OrderTradeNo].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_OrderTradeNo object.
		/// </summary>
		/// <returns>The newly created Mall_OrderTradeNo object.</returns>
		public static Mall_OrderTradeNo CreateMall_OrderTradeNo()
		{
			return InitializeNew<Mall_OrderTradeNo>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_OrderTradeNo by a Mall_OrderTradeNo's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_OrderTradeNo</returns>
		public static Mall_OrderTradeNo GetMall_OrderTradeNo(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_OrderTradeNo.SelectFieldList + @"
FROM [dbo].[Mall_OrderTradeNo] 
WHERE 
	[Mall_OrderTradeNo].[ID] = @ID " + Mall_OrderTradeNo.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_OrderTradeNo>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_OrderTradeNo by a Mall_OrderTradeNo's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_OrderTradeNo</returns>
		public static Mall_OrderTradeNo GetMall_OrderTradeNo(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_OrderTradeNo.SelectFieldList + @"
FROM [dbo].[Mall_OrderTradeNo] 
WHERE 
	[Mall_OrderTradeNo].[ID] = @ID " + Mall_OrderTradeNo.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_OrderTradeNo>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderTradeNo objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_OrderTradeNo objects.</returns>
		public static EntityList<Mall_OrderTradeNo> GetMall_OrderTradeNos()
		{
			string commandText = @"
SELECT " + Mall_OrderTradeNo.SelectFieldList + "FROM [dbo].[Mall_OrderTradeNo] " + Mall_OrderTradeNo.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_OrderTradeNo>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_OrderTradeNo objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_OrderTradeNo objects.</returns>
        public static EntityList<Mall_OrderTradeNo> GetMall_OrderTradeNos(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_OrderTradeNo>(SelectFieldList, "FROM [dbo].[Mall_OrderTradeNo]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_OrderTradeNo objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_OrderTradeNo objects.</returns>
        public static EntityList<Mall_OrderTradeNo> GetMall_OrderTradeNos(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_OrderTradeNo>(SelectFieldList, "FROM [dbo].[Mall_OrderTradeNo]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_OrderTradeNo objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_OrderTradeNo objects.</returns>
		protected static EntityList<Mall_OrderTradeNo> GetMall_OrderTradeNos(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_OrderTradeNos(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderTradeNo objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderTradeNo objects.</returns>
		protected static EntityList<Mall_OrderTradeNo> GetMall_OrderTradeNos(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_OrderTradeNos(string.Empty, where, parameters, Mall_OrderTradeNo.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderTradeNo objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderTradeNo objects.</returns>
		protected static EntityList<Mall_OrderTradeNo> GetMall_OrderTradeNos(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_OrderTradeNos(prefix, where, parameters, Mall_OrderTradeNo.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderTradeNo objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderTradeNo objects.</returns>
		protected static EntityList<Mall_OrderTradeNo> GetMall_OrderTradeNos(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_OrderTradeNos(string.Empty, where, parameters, Mall_OrderTradeNo.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderTradeNo objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderTradeNo objects.</returns>
		protected static EntityList<Mall_OrderTradeNo> GetMall_OrderTradeNos(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_OrderTradeNos(prefix, where, parameters, Mall_OrderTradeNo.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderTradeNo objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_OrderTradeNo objects.</returns>
		protected static EntityList<Mall_OrderTradeNo> GetMall_OrderTradeNos(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_OrderTradeNo.SelectFieldList + "FROM [dbo].[Mall_OrderTradeNo] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_OrderTradeNo>(reader);
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
        protected static EntityList<Mall_OrderTradeNo> GetMall_OrderTradeNos(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_OrderTradeNo>(SelectFieldList, "FROM [dbo].[Mall_OrderTradeNo] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_OrderTradeNo objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_OrderTradeNoCount()
        {
            return GetMall_OrderTradeNoCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_OrderTradeNo objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_OrderTradeNoCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_OrderTradeNo] " + where;

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
		public static partial class Mall_OrderTradeNo_Properties
		{
			public const string ID = "ID";
			public const string OrderID = "OrderID";
			public const string TradeNo = "TradeNo";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OrderID" , "int:"},
    			 {"TradeNo" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
