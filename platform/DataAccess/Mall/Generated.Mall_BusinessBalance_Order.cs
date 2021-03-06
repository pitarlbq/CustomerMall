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
	/// This object represents the properties and methods of a Mall_BusinessBalance_Order.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("OrderID: {OrderID}, BusinessBalanceID: {BusinessBalanceID}")]
	public partial class Mall_BusinessBalance_Order 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _orderID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
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
		private int _businessBalanceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int BusinessBalanceID
		{
			[DebuggerStepThrough()]
			get { return this._businessBalanceID; }
			set 
			{
				if (this._businessBalanceID != value) 
				{
					this._businessBalanceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessBalanceID");
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
	[OrderID] int,
	[BusinessBalanceID] int
);

INSERT INTO [dbo].[Mall_BusinessBalance_Order] (
	[Mall_BusinessBalance_Order].[OrderID],
	[Mall_BusinessBalance_Order].[BusinessBalanceID]
) 
output 
	INSERTED.[OrderID],
	INSERTED.[BusinessBalanceID]
into @table
VALUES ( 
	@OrderID,
	@BusinessBalanceID 
); 

SELECT 
	[OrderID],
	[BusinessBalanceID] 
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
	[OrderID] int,
	[BusinessBalanceID] int
);

UPDATE [dbo].[Mall_BusinessBalance_Order] SET 
 
output 
	INSERTED.[OrderID],
	INSERTED.[BusinessBalanceID]
into @table
WHERE 
	[Mall_BusinessBalance_Order].[OrderID] = @OrderID
	AND [Mall_BusinessBalance_Order].[BusinessBalanceID] = @BusinessBalanceID

SELECT 
	[OrderID],
	[BusinessBalanceID] 
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
DELETE FROM [dbo].[Mall_BusinessBalance_Order]
WHERE 
	[Mall_BusinessBalance_Order].[OrderID] = @OrderID
	AND [Mall_BusinessBalance_Order].[BusinessBalanceID] = @BusinessBalanceID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_BusinessBalance_Order() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_BusinessBalance_Order(this.OrderID, this.BusinessBalanceID));
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
	[Mall_BusinessBalance_Order].[OrderID],
	[Mall_BusinessBalance_Order].[BusinessBalanceID]
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
                return "Mall_BusinessBalance_Order";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_BusinessBalance_Order into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderID">orderID</param>
		/// <param name="businessBalanceID">businessBalanceID</param>
		public static void InsertMall_BusinessBalance_Order(int @orderID, int @businessBalanceID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_BusinessBalance_Order(@orderID, @businessBalanceID, helper);
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
		/// Insert a Mall_BusinessBalance_Order into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderID">orderID</param>
		/// <param name="businessBalanceID">businessBalanceID</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_BusinessBalance_Order(int @orderID, int @businessBalanceID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[OrderID] int,
	[BusinessBalanceID] int
);

INSERT INTO [dbo].[Mall_BusinessBalance_Order] (
	[Mall_BusinessBalance_Order].[OrderID],
	[Mall_BusinessBalance_Order].[BusinessBalanceID]
) 
output 
	INSERTED.[OrderID],
	INSERTED.[BusinessBalanceID]
into @table
VALUES ( 
	@OrderID,
	@BusinessBalanceID 
); 

SELECT 
	[OrderID],
	[BusinessBalanceID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OrderID", EntityBase.GetDatabaseValue(@orderID)));
			parameters.Add(new SqlParameter("@BusinessBalanceID", EntityBase.GetDatabaseValue(@businessBalanceID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_BusinessBalance_Order into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderID">orderID</param>
		/// <param name="businessBalanceID">businessBalanceID</param>
		public static void UpdateMall_BusinessBalance_Order(int @orderID, int @businessBalanceID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_BusinessBalance_Order(@orderID, @businessBalanceID, helper);
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
		/// Updates a Mall_BusinessBalance_Order into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderID">orderID</param>
		/// <param name="businessBalanceID">businessBalanceID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_BusinessBalance_Order(int @orderID, int @businessBalanceID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[OrderID] int,
	[BusinessBalanceID] int
);

UPDATE [dbo].[Mall_BusinessBalance_Order] SET 
 
output 
	INSERTED.[OrderID],
	INSERTED.[BusinessBalanceID]
into @table
WHERE 
	[Mall_BusinessBalance_Order].[OrderID] = @OrderID
	AND [Mall_BusinessBalance_Order].[BusinessBalanceID] = @BusinessBalanceID

SELECT 
	[OrderID],
	[BusinessBalanceID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OrderID", EntityBase.GetDatabaseValue(@orderID)));
			parameters.Add(new SqlParameter("@BusinessBalanceID", EntityBase.GetDatabaseValue(@businessBalanceID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_BusinessBalance_Order from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderID">orderID</param>
		/// <param name="businessBalanceID">businessBalanceID</param>
		public static void DeleteMall_BusinessBalance_Order(int @orderID, int @businessBalanceID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_BusinessBalance_Order(@orderID, @businessBalanceID, helper);
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
		/// Deletes a Mall_BusinessBalance_Order from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderID">orderID</param>
		/// <param name="businessBalanceID">businessBalanceID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_BusinessBalance_Order(int @orderID, int @businessBalanceID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_BusinessBalance_Order]
WHERE 
	[Mall_BusinessBalance_Order].[OrderID] = @OrderID
	AND [Mall_BusinessBalance_Order].[BusinessBalanceID] = @BusinessBalanceID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OrderID", @orderID));
			parameters.Add(new SqlParameter("@BusinessBalanceID", @businessBalanceID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_BusinessBalance_Order object.
		/// </summary>
		/// <returns>The newly created Mall_BusinessBalance_Order object.</returns>
		public static Mall_BusinessBalance_Order CreateMall_BusinessBalance_Order()
		{
			return InitializeNew<Mall_BusinessBalance_Order>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_BusinessBalance_Order by a Mall_BusinessBalance_Order's unique identifier.
		/// </summary>
		/// <param name="orderID">orderID</param>
		/// <param name="businessBalanceID">businessBalanceID</param>
		/// <returns>Mall_BusinessBalance_Order</returns>
		public static Mall_BusinessBalance_Order GetMall_BusinessBalance_Order(int @orderID, int @businessBalanceID)
		{
			string commandText = @"
SELECT 
" + Mall_BusinessBalance_Order.SelectFieldList + @"
FROM [dbo].[Mall_BusinessBalance_Order] 
WHERE 
	[Mall_BusinessBalance_Order].[OrderID] = @OrderID
	AND [Mall_BusinessBalance_Order].[BusinessBalanceID] = @BusinessBalanceID " + Mall_BusinessBalance_Order.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OrderID", @orderID));
			parameters.Add(new SqlParameter("@BusinessBalanceID", @businessBalanceID));
			
			return GetOne<Mall_BusinessBalance_Order>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_BusinessBalance_Order by a Mall_BusinessBalance_Order's unique identifier.
		/// </summary>
		/// <param name="orderID">orderID</param>
		/// <param name="businessBalanceID">businessBalanceID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_BusinessBalance_Order</returns>
		public static Mall_BusinessBalance_Order GetMall_BusinessBalance_Order(int @orderID, int @businessBalanceID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_BusinessBalance_Order.SelectFieldList + @"
FROM [dbo].[Mall_BusinessBalance_Order] 
WHERE 
	[Mall_BusinessBalance_Order].[OrderID] = @OrderID
	AND [Mall_BusinessBalance_Order].[BusinessBalanceID] = @BusinessBalanceID " + Mall_BusinessBalance_Order.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OrderID", @orderID));
			parameters.Add(new SqlParameter("@BusinessBalanceID", @businessBalanceID));
			
			return GetOne<Mall_BusinessBalance_Order>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessBalance_Order objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_BusinessBalance_Order objects.</returns>
		public static EntityList<Mall_BusinessBalance_Order> GetMall_BusinessBalance_Orders()
		{
			string commandText = @"
SELECT " + Mall_BusinessBalance_Order.SelectFieldList + "FROM [dbo].[Mall_BusinessBalance_Order] " + Mall_BusinessBalance_Order.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_BusinessBalance_Order>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_BusinessBalance_Order objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_BusinessBalance_Order objects.</returns>
        public static EntityList<Mall_BusinessBalance_Order> GetMall_BusinessBalance_Orders(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_BusinessBalance_Order>(SelectFieldList, "FROM [dbo].[Mall_BusinessBalance_Order]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_BusinessBalance_Order objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_BusinessBalance_Order objects.</returns>
        public static EntityList<Mall_BusinessBalance_Order> GetMall_BusinessBalance_Orders(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_BusinessBalance_Order>(SelectFieldList, "FROM [dbo].[Mall_BusinessBalance_Order]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_BusinessBalance_Order objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_BusinessBalance_Order objects.</returns>
		protected static EntityList<Mall_BusinessBalance_Order> GetMall_BusinessBalance_Orders(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_BusinessBalance_Orders(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessBalance_Order objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_BusinessBalance_Order objects.</returns>
		protected static EntityList<Mall_BusinessBalance_Order> GetMall_BusinessBalance_Orders(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_BusinessBalance_Orders(string.Empty, where, parameters, Mall_BusinessBalance_Order.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessBalance_Order objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_BusinessBalance_Order objects.</returns>
		protected static EntityList<Mall_BusinessBalance_Order> GetMall_BusinessBalance_Orders(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_BusinessBalance_Orders(prefix, where, parameters, Mall_BusinessBalance_Order.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessBalance_Order objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_BusinessBalance_Order objects.</returns>
		protected static EntityList<Mall_BusinessBalance_Order> GetMall_BusinessBalance_Orders(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_BusinessBalance_Orders(string.Empty, where, parameters, Mall_BusinessBalance_Order.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessBalance_Order objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_BusinessBalance_Order objects.</returns>
		protected static EntityList<Mall_BusinessBalance_Order> GetMall_BusinessBalance_Orders(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_BusinessBalance_Orders(prefix, where, parameters, Mall_BusinessBalance_Order.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BusinessBalance_Order objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_BusinessBalance_Order objects.</returns>
		protected static EntityList<Mall_BusinessBalance_Order> GetMall_BusinessBalance_Orders(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_BusinessBalance_Order.SelectFieldList + "FROM [dbo].[Mall_BusinessBalance_Order] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_BusinessBalance_Order>(reader);
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
        protected static EntityList<Mall_BusinessBalance_Order> GetMall_BusinessBalance_Orders(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_BusinessBalance_Order>(SelectFieldList, "FROM [dbo].[Mall_BusinessBalance_Order] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_BusinessBalance_Order objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_BusinessBalance_OrderCount()
        {
            return GetMall_BusinessBalance_OrderCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_BusinessBalance_Order objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_BusinessBalance_OrderCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_BusinessBalance_Order] " + where;

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
		public static partial class Mall_BusinessBalance_Order_Properties
		{
			public const string OrderID = "OrderID";
			public const string BusinessBalanceID = "BusinessBalanceID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"OrderID" , "int:"},
    			 {"BusinessBalanceID" , "int:"},
            };
		}
		#endregion
	}
}
