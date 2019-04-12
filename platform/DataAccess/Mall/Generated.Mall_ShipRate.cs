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
	/// This object represents the properties and methods of a Mall_ShipRate.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_ShipRate 
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
		private string _rateTile = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string RateTile
		{
			[DebuggerStepThrough()]
			get { return this._rateTile; }
			set 
			{
				if (this._rateTile != value) 
				{
					this._rateTile = value;
					this.IsDirty = true;	
					OnPropertyChanged("RateTile");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _rateType = int.MinValue;
		/// <summary>
		/// 1-快递 2-自提
		/// </summary>
        [Description("1-快递 2-自提")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RateType
		{
			[DebuggerStepThrough()]
			get { return this._rateType; }
			set 
			{
				if (this._rateType != value) 
				{
					this._rateType = value;
					this.IsDirty = true;	
					OnPropertyChanged("RateType");
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _rateSummary = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RateSummary
		{
			[DebuggerStepThrough()]
			get { return this._rateSummary; }
			set 
			{
				if (this._rateSummary != value) 
				{
					this._rateSummary = value;
					this.IsDirty = true;	
					OnPropertyChanged("RateSummary");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDefault = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDefault
		{
			[DebuggerStepThrough()]
			get { return this._isDefault; }
			set 
			{
				if (this._isDefault != value) 
				{
					this._isDefault = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDefault");
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
	[RateTile] nvarchar(200),
	[RateType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[RateSummary] ntext,
	[IsDefault] bit
);

INSERT INTO [dbo].[Mall_ShipRate] (
	[Mall_ShipRate].[RateTile],
	[Mall_ShipRate].[RateType],
	[Mall_ShipRate].[AddTime],
	[Mall_ShipRate].[AddUserName],
	[Mall_ShipRate].[RateSummary],
	[Mall_ShipRate].[IsDefault]
) 
output 
	INSERTED.[ID],
	INSERTED.[RateTile],
	INSERTED.[RateType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[RateSummary],
	INSERTED.[IsDefault]
into @table
VALUES ( 
	@RateTile,
	@RateType,
	@AddTime,
	@AddUserName,
	@RateSummary,
	@IsDefault 
); 

SELECT 
	[ID],
	[RateTile],
	[RateType],
	[AddTime],
	[AddUserName],
	[RateSummary],
	[IsDefault] 
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
	[RateTile] nvarchar(200),
	[RateType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[RateSummary] ntext,
	[IsDefault] bit
);

UPDATE [dbo].[Mall_ShipRate] SET 
	[Mall_ShipRate].[RateTile] = @RateTile,
	[Mall_ShipRate].[RateType] = @RateType,
	[Mall_ShipRate].[AddTime] = @AddTime,
	[Mall_ShipRate].[AddUserName] = @AddUserName,
	[Mall_ShipRate].[RateSummary] = @RateSummary,
	[Mall_ShipRate].[IsDefault] = @IsDefault 
output 
	INSERTED.[ID],
	INSERTED.[RateTile],
	INSERTED.[RateType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[RateSummary],
	INSERTED.[IsDefault]
into @table
WHERE 
	[Mall_ShipRate].[ID] = @ID

SELECT 
	[ID],
	[RateTile],
	[RateType],
	[AddTime],
	[AddUserName],
	[RateSummary],
	[IsDefault] 
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
DELETE FROM [dbo].[Mall_ShipRate]
WHERE 
	[Mall_ShipRate].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_ShipRate() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_ShipRate(this.ID));
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
	[Mall_ShipRate].[ID],
	[Mall_ShipRate].[RateTile],
	[Mall_ShipRate].[RateType],
	[Mall_ShipRate].[AddTime],
	[Mall_ShipRate].[AddUserName],
	[Mall_ShipRate].[RateSummary],
	[Mall_ShipRate].[IsDefault]
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
                return "Mall_ShipRate";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_ShipRate into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="rateTile">rateTile</param>
		/// <param name="rateType">rateType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="rateSummary">rateSummary</param>
		/// <param name="isDefault">isDefault</param>
		public static void InsertMall_ShipRate(string @rateTile, int @rateType, DateTime @addTime, string @addUserName, string @rateSummary, bool @isDefault)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_ShipRate(@rateTile, @rateType, @addTime, @addUserName, @rateSummary, @isDefault, helper);
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
		/// Insert a Mall_ShipRate into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="rateTile">rateTile</param>
		/// <param name="rateType">rateType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="rateSummary">rateSummary</param>
		/// <param name="isDefault">isDefault</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_ShipRate(string @rateTile, int @rateType, DateTime @addTime, string @addUserName, string @rateSummary, bool @isDefault, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RateTile] nvarchar(200),
	[RateType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[RateSummary] ntext,
	[IsDefault] bit
);

INSERT INTO [dbo].[Mall_ShipRate] (
	[Mall_ShipRate].[RateTile],
	[Mall_ShipRate].[RateType],
	[Mall_ShipRate].[AddTime],
	[Mall_ShipRate].[AddUserName],
	[Mall_ShipRate].[RateSummary],
	[Mall_ShipRate].[IsDefault]
) 
output 
	INSERTED.[ID],
	INSERTED.[RateTile],
	INSERTED.[RateType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[RateSummary],
	INSERTED.[IsDefault]
into @table
VALUES ( 
	@RateTile,
	@RateType,
	@AddTime,
	@AddUserName,
	@RateSummary,
	@IsDefault 
); 

SELECT 
	[ID],
	[RateTile],
	[RateType],
	[AddTime],
	[AddUserName],
	[RateSummary],
	[IsDefault] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RateTile", EntityBase.GetDatabaseValue(@rateTile)));
			parameters.Add(new SqlParameter("@RateType", EntityBase.GetDatabaseValue(@rateType)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@RateSummary", EntityBase.GetDatabaseValue(@rateSummary)));
			parameters.Add(new SqlParameter("@IsDefault", @isDefault));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_ShipRate into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="rateTile">rateTile</param>
		/// <param name="rateType">rateType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="rateSummary">rateSummary</param>
		/// <param name="isDefault">isDefault</param>
		public static void UpdateMall_ShipRate(int @iD, string @rateTile, int @rateType, DateTime @addTime, string @addUserName, string @rateSummary, bool @isDefault)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_ShipRate(@iD, @rateTile, @rateType, @addTime, @addUserName, @rateSummary, @isDefault, helper);
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
		/// Updates a Mall_ShipRate into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="rateTile">rateTile</param>
		/// <param name="rateType">rateType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="rateSummary">rateSummary</param>
		/// <param name="isDefault">isDefault</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_ShipRate(int @iD, string @rateTile, int @rateType, DateTime @addTime, string @addUserName, string @rateSummary, bool @isDefault, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RateTile] nvarchar(200),
	[RateType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[RateSummary] ntext,
	[IsDefault] bit
);

UPDATE [dbo].[Mall_ShipRate] SET 
	[Mall_ShipRate].[RateTile] = @RateTile,
	[Mall_ShipRate].[RateType] = @RateType,
	[Mall_ShipRate].[AddTime] = @AddTime,
	[Mall_ShipRate].[AddUserName] = @AddUserName,
	[Mall_ShipRate].[RateSummary] = @RateSummary,
	[Mall_ShipRate].[IsDefault] = @IsDefault 
output 
	INSERTED.[ID],
	INSERTED.[RateTile],
	INSERTED.[RateType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[RateSummary],
	INSERTED.[IsDefault]
into @table
WHERE 
	[Mall_ShipRate].[ID] = @ID

SELECT 
	[ID],
	[RateTile],
	[RateType],
	[AddTime],
	[AddUserName],
	[RateSummary],
	[IsDefault] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RateTile", EntityBase.GetDatabaseValue(@rateTile)));
			parameters.Add(new SqlParameter("@RateType", EntityBase.GetDatabaseValue(@rateType)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@RateSummary", EntityBase.GetDatabaseValue(@rateSummary)));
			parameters.Add(new SqlParameter("@IsDefault", @isDefault));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_ShipRate from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_ShipRate(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_ShipRate(@iD, helper);
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
		/// Deletes a Mall_ShipRate from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_ShipRate(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_ShipRate]
WHERE 
	[Mall_ShipRate].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_ShipRate object.
		/// </summary>
		/// <returns>The newly created Mall_ShipRate object.</returns>
		public static Mall_ShipRate CreateMall_ShipRate()
		{
			return InitializeNew<Mall_ShipRate>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_ShipRate by a Mall_ShipRate's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_ShipRate</returns>
		public static Mall_ShipRate GetMall_ShipRate(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_ShipRate.SelectFieldList + @"
FROM [dbo].[Mall_ShipRate] 
WHERE 
	[Mall_ShipRate].[ID] = @ID " + Mall_ShipRate.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ShipRate>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_ShipRate by a Mall_ShipRate's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_ShipRate</returns>
		public static Mall_ShipRate GetMall_ShipRate(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_ShipRate.SelectFieldList + @"
FROM [dbo].[Mall_ShipRate] 
WHERE 
	[Mall_ShipRate].[ID] = @ID " + Mall_ShipRate.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ShipRate>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipRate objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_ShipRate objects.</returns>
		public static EntityList<Mall_ShipRate> GetMall_ShipRates()
		{
			string commandText = @"
SELECT " + Mall_ShipRate.SelectFieldList + "FROM [dbo].[Mall_ShipRate] " + Mall_ShipRate.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_ShipRate>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_ShipRate objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ShipRate objects.</returns>
        public static EntityList<Mall_ShipRate> GetMall_ShipRates(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ShipRate>(SelectFieldList, "FROM [dbo].[Mall_ShipRate]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_ShipRate objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ShipRate objects.</returns>
        public static EntityList<Mall_ShipRate> GetMall_ShipRates(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ShipRate>(SelectFieldList, "FROM [dbo].[Mall_ShipRate]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_ShipRate objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ShipRate objects.</returns>
		protected static EntityList<Mall_ShipRate> GetMall_ShipRates(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ShipRates(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipRate objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShipRate objects.</returns>
		protected static EntityList<Mall_ShipRate> GetMall_ShipRates(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ShipRates(string.Empty, where, parameters, Mall_ShipRate.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipRate objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShipRate objects.</returns>
		protected static EntityList<Mall_ShipRate> GetMall_ShipRates(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ShipRates(prefix, where, parameters, Mall_ShipRate.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipRate objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShipRate objects.</returns>
		protected static EntityList<Mall_ShipRate> GetMall_ShipRates(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ShipRates(string.Empty, where, parameters, Mall_ShipRate.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipRate objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShipRate objects.</returns>
		protected static EntityList<Mall_ShipRate> GetMall_ShipRates(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ShipRates(prefix, where, parameters, Mall_ShipRate.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipRate objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ShipRate objects.</returns>
		protected static EntityList<Mall_ShipRate> GetMall_ShipRates(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_ShipRate.SelectFieldList + "FROM [dbo].[Mall_ShipRate] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_ShipRate>(reader);
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
        protected static EntityList<Mall_ShipRate> GetMall_ShipRates(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ShipRate>(SelectFieldList, "FROM [dbo].[Mall_ShipRate] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_ShipRate objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ShipRateCount()
        {
            return GetMall_ShipRateCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_ShipRate objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ShipRateCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_ShipRate] " + where;

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
		public static partial class Mall_ShipRate_Properties
		{
			public const string ID = "ID";
			public const string RateTile = "RateTile";
			public const string RateType = "RateType";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string RateSummary = "RateSummary";
			public const string IsDefault = "IsDefault";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RateTile" , "string:"},
    			 {"RateType" , "int:1-快递 2-自提"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"RateSummary" , "string:"},
    			 {"IsDefault" , "bool:"},
            };
		}
		#endregion
	}
}
