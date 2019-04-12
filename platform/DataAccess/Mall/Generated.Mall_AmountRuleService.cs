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
	/// This object represents the properties and methods of a Mall_AmountRuleService.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_AmountRuleService 
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
		private int _amountRuleID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int AmountRuleID
		{
			[DebuggerStepThrough()]
			get { return this._amountRuleID; }
			set 
			{
				if (this._amountRuleID != value) 
				{
					this._amountRuleID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AmountRuleID");
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
		private int _quantity = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Quantity
		{
			[DebuggerStepThrough()]
			get { return this._quantity; }
			set 
			{
				if (this._quantity != value) 
				{
					this._quantity = value;
					this.IsDirty = true;	
					OnPropertyChanged("Quantity");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _couponCodeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CouponCodeID
		{
			[DebuggerStepThrough()]
			get { return this._couponCodeID; }
			set 
			{
				if (this._couponCodeID != value) 
				{
					this._couponCodeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CouponCodeID");
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
	[AmountRuleID] int,
	[AddTime] datetime,
	[Quantity] int,
	[CouponCodeID] int
);

INSERT INTO [dbo].[Mall_AmountRuleService] (
	[Mall_AmountRuleService].[AmountRuleID],
	[Mall_AmountRuleService].[AddTime],
	[Mall_AmountRuleService].[Quantity],
	[Mall_AmountRuleService].[CouponCodeID]
) 
output 
	INSERTED.[ID],
	INSERTED.[AmountRuleID],
	INSERTED.[AddTime],
	INSERTED.[Quantity],
	INSERTED.[CouponCodeID]
into @table
VALUES ( 
	@AmountRuleID,
	@AddTime,
	@Quantity,
	@CouponCodeID 
); 

SELECT 
	[ID],
	[AmountRuleID],
	[AddTime],
	[Quantity],
	[CouponCodeID] 
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
	[AmountRuleID] int,
	[AddTime] datetime,
	[Quantity] int,
	[CouponCodeID] int
);

UPDATE [dbo].[Mall_AmountRuleService] SET 
	[Mall_AmountRuleService].[AmountRuleID] = @AmountRuleID,
	[Mall_AmountRuleService].[AddTime] = @AddTime,
	[Mall_AmountRuleService].[Quantity] = @Quantity,
	[Mall_AmountRuleService].[CouponCodeID] = @CouponCodeID 
output 
	INSERTED.[ID],
	INSERTED.[AmountRuleID],
	INSERTED.[AddTime],
	INSERTED.[Quantity],
	INSERTED.[CouponCodeID]
into @table
WHERE 
	[Mall_AmountRuleService].[ID] = @ID

SELECT 
	[ID],
	[AmountRuleID],
	[AddTime],
	[Quantity],
	[CouponCodeID] 
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
DELETE FROM [dbo].[Mall_AmountRuleService]
WHERE 
	[Mall_AmountRuleService].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_AmountRuleService() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_AmountRuleService(this.ID));
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
	[Mall_AmountRuleService].[ID],
	[Mall_AmountRuleService].[AmountRuleID],
	[Mall_AmountRuleService].[AddTime],
	[Mall_AmountRuleService].[Quantity],
	[Mall_AmountRuleService].[CouponCodeID]
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
                return "Mall_AmountRuleService";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_AmountRuleService into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="quantity">quantity</param>
		/// <param name="couponCodeID">couponCodeID</param>
		public static void InsertMall_AmountRuleService(int @amountRuleID, DateTime @addTime, int @quantity, int @couponCodeID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_AmountRuleService(@amountRuleID, @addTime, @quantity, @couponCodeID, helper);
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
		/// Insert a Mall_AmountRuleService into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="quantity">quantity</param>
		/// <param name="couponCodeID">couponCodeID</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_AmountRuleService(int @amountRuleID, DateTime @addTime, int @quantity, int @couponCodeID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AmountRuleID] int,
	[AddTime] datetime,
	[Quantity] int,
	[CouponCodeID] int
);

INSERT INTO [dbo].[Mall_AmountRuleService] (
	[Mall_AmountRuleService].[AmountRuleID],
	[Mall_AmountRuleService].[AddTime],
	[Mall_AmountRuleService].[Quantity],
	[Mall_AmountRuleService].[CouponCodeID]
) 
output 
	INSERTED.[ID],
	INSERTED.[AmountRuleID],
	INSERTED.[AddTime],
	INSERTED.[Quantity],
	INSERTED.[CouponCodeID]
into @table
VALUES ( 
	@AmountRuleID,
	@AddTime,
	@Quantity,
	@CouponCodeID 
); 

SELECT 
	[ID],
	[AmountRuleID],
	[AddTime],
	[Quantity],
	[CouponCodeID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@AmountRuleID", EntityBase.GetDatabaseValue(@amountRuleID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Quantity", EntityBase.GetDatabaseValue(@quantity)));
			parameters.Add(new SqlParameter("@CouponCodeID", EntityBase.GetDatabaseValue(@couponCodeID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_AmountRuleService into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="quantity">quantity</param>
		/// <param name="couponCodeID">couponCodeID</param>
		public static void UpdateMall_AmountRuleService(int @iD, int @amountRuleID, DateTime @addTime, int @quantity, int @couponCodeID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_AmountRuleService(@iD, @amountRuleID, @addTime, @quantity, @couponCodeID, helper);
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
		/// Updates a Mall_AmountRuleService into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="quantity">quantity</param>
		/// <param name="couponCodeID">couponCodeID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_AmountRuleService(int @iD, int @amountRuleID, DateTime @addTime, int @quantity, int @couponCodeID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AmountRuleID] int,
	[AddTime] datetime,
	[Quantity] int,
	[CouponCodeID] int
);

UPDATE [dbo].[Mall_AmountRuleService] SET 
	[Mall_AmountRuleService].[AmountRuleID] = @AmountRuleID,
	[Mall_AmountRuleService].[AddTime] = @AddTime,
	[Mall_AmountRuleService].[Quantity] = @Quantity,
	[Mall_AmountRuleService].[CouponCodeID] = @CouponCodeID 
output 
	INSERTED.[ID],
	INSERTED.[AmountRuleID],
	INSERTED.[AddTime],
	INSERTED.[Quantity],
	INSERTED.[CouponCodeID]
into @table
WHERE 
	[Mall_AmountRuleService].[ID] = @ID

SELECT 
	[ID],
	[AmountRuleID],
	[AddTime],
	[Quantity],
	[CouponCodeID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@AmountRuleID", EntityBase.GetDatabaseValue(@amountRuleID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Quantity", EntityBase.GetDatabaseValue(@quantity)));
			parameters.Add(new SqlParameter("@CouponCodeID", EntityBase.GetDatabaseValue(@couponCodeID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_AmountRuleService from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_AmountRuleService(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_AmountRuleService(@iD, helper);
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
		/// Deletes a Mall_AmountRuleService from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_AmountRuleService(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_AmountRuleService]
WHERE 
	[Mall_AmountRuleService].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_AmountRuleService object.
		/// </summary>
		/// <returns>The newly created Mall_AmountRuleService object.</returns>
		public static Mall_AmountRuleService CreateMall_AmountRuleService()
		{
			return InitializeNew<Mall_AmountRuleService>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_AmountRuleService by a Mall_AmountRuleService's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_AmountRuleService</returns>
		public static Mall_AmountRuleService GetMall_AmountRuleService(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_AmountRuleService.SelectFieldList + @"
FROM [dbo].[Mall_AmountRuleService] 
WHERE 
	[Mall_AmountRuleService].[ID] = @ID " + Mall_AmountRuleService.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_AmountRuleService>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_AmountRuleService by a Mall_AmountRuleService's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_AmountRuleService</returns>
		public static Mall_AmountRuleService GetMall_AmountRuleService(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_AmountRuleService.SelectFieldList + @"
FROM [dbo].[Mall_AmountRuleService] 
WHERE 
	[Mall_AmountRuleService].[ID] = @ID " + Mall_AmountRuleService.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_AmountRuleService>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleService objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_AmountRuleService objects.</returns>
		public static EntityList<Mall_AmountRuleService> GetMall_AmountRuleServices()
		{
			string commandText = @"
SELECT " + Mall_AmountRuleService.SelectFieldList + "FROM [dbo].[Mall_AmountRuleService] " + Mall_AmountRuleService.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_AmountRuleService>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_AmountRuleService objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_AmountRuleService objects.</returns>
        public static EntityList<Mall_AmountRuleService> GetMall_AmountRuleServices(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_AmountRuleService>(SelectFieldList, "FROM [dbo].[Mall_AmountRuleService]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_AmountRuleService objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_AmountRuleService objects.</returns>
        public static EntityList<Mall_AmountRuleService> GetMall_AmountRuleServices(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_AmountRuleService>(SelectFieldList, "FROM [dbo].[Mall_AmountRuleService]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleService objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_AmountRuleService objects.</returns>
		protected static EntityList<Mall_AmountRuleService> GetMall_AmountRuleServices(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_AmountRuleServices(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleService objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_AmountRuleService objects.</returns>
		protected static EntityList<Mall_AmountRuleService> GetMall_AmountRuleServices(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_AmountRuleServices(string.Empty, where, parameters, Mall_AmountRuleService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_AmountRuleService objects.</returns>
		protected static EntityList<Mall_AmountRuleService> GetMall_AmountRuleServices(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_AmountRuleServices(prefix, where, parameters, Mall_AmountRuleService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_AmountRuleService objects.</returns>
		protected static EntityList<Mall_AmountRuleService> GetMall_AmountRuleServices(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_AmountRuleServices(string.Empty, where, parameters, Mall_AmountRuleService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_AmountRuleService objects.</returns>
		protected static EntityList<Mall_AmountRuleService> GetMall_AmountRuleServices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_AmountRuleServices(prefix, where, parameters, Mall_AmountRuleService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_AmountRuleService objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_AmountRuleService objects.</returns>
		protected static EntityList<Mall_AmountRuleService> GetMall_AmountRuleServices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_AmountRuleService.SelectFieldList + "FROM [dbo].[Mall_AmountRuleService] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_AmountRuleService>(reader);
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
        protected static EntityList<Mall_AmountRuleService> GetMall_AmountRuleServices(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_AmountRuleService>(SelectFieldList, "FROM [dbo].[Mall_AmountRuleService] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_AmountRuleService objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_AmountRuleServiceCount()
        {
            return GetMall_AmountRuleServiceCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_AmountRuleService objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_AmountRuleServiceCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_AmountRuleService] " + where;

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
		public static partial class Mall_AmountRuleService_Properties
		{
			public const string ID = "ID";
			public const string AmountRuleID = "AmountRuleID";
			public const string AddTime = "AddTime";
			public const string Quantity = "Quantity";
			public const string CouponCodeID = "CouponCodeID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"AmountRuleID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"Quantity" , "int:"},
    			 {"CouponCodeID" , "int:"},
            };
		}
		#endregion
	}
}
