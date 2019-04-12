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
	/// This object represents the properties and methods of a Cheque_TaxRate.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_TaxRate 
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
		private string _taxRateName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TaxRateName
		{
			[DebuggerStepThrough()]
			get { return this._taxRateName; }
			set 
			{
				if (this._taxRateName != value) 
				{
					this._taxRateName = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaxRateName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _taxRateValue = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TaxRateValue
		{
			[DebuggerStepThrough()]
			get { return this._taxRateValue; }
			set 
			{
				if (this._taxRateValue != value) 
				{
					this._taxRateValue = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaxRateValue");
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
		private string _gUID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string GUID
		{
			[DebuggerStepThrough()]
			get { return this._gUID; }
			set 
			{
				if (this._gUID != value) 
				{
					this._gUID = value;
					this.IsDirty = true;	
					OnPropertyChanged("GUID");
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
	[TaxRateName] nvarchar(200),
	[TaxRateValue] nvarchar(100),
	[AddTime] datetime,
	[GUID] nvarchar(500)
);

INSERT INTO [dbo].[Cheque_TaxRate] (
	[Cheque_TaxRate].[TaxRateName],
	[Cheque_TaxRate].[TaxRateValue],
	[Cheque_TaxRate].[AddTime],
	[Cheque_TaxRate].[GUID]
) 
output 
	INSERTED.[ID],
	INSERTED.[TaxRateName],
	INSERTED.[TaxRateValue],
	INSERTED.[AddTime],
	INSERTED.[GUID]
into @table
VALUES ( 
	@TaxRateName,
	@TaxRateValue,
	@AddTime,
	@GUID 
); 

SELECT 
	[ID],
	[TaxRateName],
	[TaxRateValue],
	[AddTime],
	[GUID] 
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
	[TaxRateName] nvarchar(200),
	[TaxRateValue] nvarchar(100),
	[AddTime] datetime,
	[GUID] nvarchar(500)
);

UPDATE [dbo].[Cheque_TaxRate] SET 
	[Cheque_TaxRate].[TaxRateName] = @TaxRateName,
	[Cheque_TaxRate].[TaxRateValue] = @TaxRateValue,
	[Cheque_TaxRate].[AddTime] = @AddTime,
	[Cheque_TaxRate].[GUID] = @GUID 
output 
	INSERTED.[ID],
	INSERTED.[TaxRateName],
	INSERTED.[TaxRateValue],
	INSERTED.[AddTime],
	INSERTED.[GUID]
into @table
WHERE 
	[Cheque_TaxRate].[ID] = @ID

SELECT 
	[ID],
	[TaxRateName],
	[TaxRateValue],
	[AddTime],
	[GUID] 
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
DELETE FROM [dbo].[Cheque_TaxRate]
WHERE 
	[Cheque_TaxRate].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_TaxRate() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_TaxRate(this.ID));
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
	[Cheque_TaxRate].[ID],
	[Cheque_TaxRate].[TaxRateName],
	[Cheque_TaxRate].[TaxRateValue],
	[Cheque_TaxRate].[AddTime],
	[Cheque_TaxRate].[GUID]
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
                return "Cheque_TaxRate";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_TaxRate into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="taxRateName">taxRateName</param>
		/// <param name="taxRateValue">taxRateValue</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		public static void InsertCheque_TaxRate(string @taxRateName, string @taxRateValue, DateTime @addTime, string @gUID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_TaxRate(@taxRateName, @taxRateValue, @addTime, @gUID, helper);
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
		/// Insert a Cheque_TaxRate into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="taxRateName">taxRateName</param>
		/// <param name="taxRateValue">taxRateValue</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_TaxRate(string @taxRateName, string @taxRateValue, DateTime @addTime, string @gUID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[TaxRateName] nvarchar(200),
	[TaxRateValue] nvarchar(100),
	[AddTime] datetime,
	[GUID] nvarchar(500)
);

INSERT INTO [dbo].[Cheque_TaxRate] (
	[Cheque_TaxRate].[TaxRateName],
	[Cheque_TaxRate].[TaxRateValue],
	[Cheque_TaxRate].[AddTime],
	[Cheque_TaxRate].[GUID]
) 
output 
	INSERTED.[ID],
	INSERTED.[TaxRateName],
	INSERTED.[TaxRateValue],
	INSERTED.[AddTime],
	INSERTED.[GUID]
into @table
VALUES ( 
	@TaxRateName,
	@TaxRateValue,
	@AddTime,
	@GUID 
); 

SELECT 
	[ID],
	[TaxRateName],
	[TaxRateValue],
	[AddTime],
	[GUID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TaxRateName", EntityBase.GetDatabaseValue(@taxRateName)));
			parameters.Add(new SqlParameter("@TaxRateValue", EntityBase.GetDatabaseValue(@taxRateValue)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_TaxRate into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="taxRateName">taxRateName</param>
		/// <param name="taxRateValue">taxRateValue</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		public static void UpdateCheque_TaxRate(int @iD, string @taxRateName, string @taxRateValue, DateTime @addTime, string @gUID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_TaxRate(@iD, @taxRateName, @taxRateValue, @addTime, @gUID, helper);
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
		/// Updates a Cheque_TaxRate into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="taxRateName">taxRateName</param>
		/// <param name="taxRateValue">taxRateValue</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_TaxRate(int @iD, string @taxRateName, string @taxRateValue, DateTime @addTime, string @gUID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[TaxRateName] nvarchar(200),
	[TaxRateValue] nvarchar(100),
	[AddTime] datetime,
	[GUID] nvarchar(500)
);

UPDATE [dbo].[Cheque_TaxRate] SET 
	[Cheque_TaxRate].[TaxRateName] = @TaxRateName,
	[Cheque_TaxRate].[TaxRateValue] = @TaxRateValue,
	[Cheque_TaxRate].[AddTime] = @AddTime,
	[Cheque_TaxRate].[GUID] = @GUID 
output 
	INSERTED.[ID],
	INSERTED.[TaxRateName],
	INSERTED.[TaxRateValue],
	INSERTED.[AddTime],
	INSERTED.[GUID]
into @table
WHERE 
	[Cheque_TaxRate].[ID] = @ID

SELECT 
	[ID],
	[TaxRateName],
	[TaxRateValue],
	[AddTime],
	[GUID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@TaxRateName", EntityBase.GetDatabaseValue(@taxRateName)));
			parameters.Add(new SqlParameter("@TaxRateValue", EntityBase.GetDatabaseValue(@taxRateValue)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_TaxRate from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_TaxRate(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_TaxRate(@iD, helper);
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
		/// Deletes a Cheque_TaxRate from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_TaxRate(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_TaxRate]
WHERE 
	[Cheque_TaxRate].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_TaxRate object.
		/// </summary>
		/// <returns>The newly created Cheque_TaxRate object.</returns>
		public static Cheque_TaxRate CreateCheque_TaxRate()
		{
			return InitializeNew<Cheque_TaxRate>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_TaxRate by a Cheque_TaxRate's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_TaxRate</returns>
		public static Cheque_TaxRate GetCheque_TaxRate(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_TaxRate.SelectFieldList + @"
FROM [dbo].[Cheque_TaxRate] 
WHERE 
	[Cheque_TaxRate].[ID] = @ID " + Cheque_TaxRate.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_TaxRate>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_TaxRate by a Cheque_TaxRate's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_TaxRate</returns>
		public static Cheque_TaxRate GetCheque_TaxRate(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_TaxRate.SelectFieldList + @"
FROM [dbo].[Cheque_TaxRate] 
WHERE 
	[Cheque_TaxRate].[ID] = @ID " + Cheque_TaxRate.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_TaxRate>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_TaxRate objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_TaxRate objects.</returns>
		public static EntityList<Cheque_TaxRate> GetCheque_TaxRates()
		{
			string commandText = @"
SELECT " + Cheque_TaxRate.SelectFieldList + "FROM [dbo].[Cheque_TaxRate] " + Cheque_TaxRate.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_TaxRate>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_TaxRate objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_TaxRate objects.</returns>
        public static EntityList<Cheque_TaxRate> GetCheque_TaxRates(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_TaxRate>(SelectFieldList, "FROM [dbo].[Cheque_TaxRate]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_TaxRate objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_TaxRate objects.</returns>
        public static EntityList<Cheque_TaxRate> GetCheque_TaxRates(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_TaxRate>(SelectFieldList, "FROM [dbo].[Cheque_TaxRate]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_TaxRate objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_TaxRate objects.</returns>
		protected static EntityList<Cheque_TaxRate> GetCheque_TaxRates(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_TaxRates(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_TaxRate objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_TaxRate objects.</returns>
		protected static EntityList<Cheque_TaxRate> GetCheque_TaxRates(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_TaxRates(string.Empty, where, parameters, Cheque_TaxRate.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_TaxRate objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_TaxRate objects.</returns>
		protected static EntityList<Cheque_TaxRate> GetCheque_TaxRates(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_TaxRates(prefix, where, parameters, Cheque_TaxRate.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_TaxRate objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_TaxRate objects.</returns>
		protected static EntityList<Cheque_TaxRate> GetCheque_TaxRates(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_TaxRates(string.Empty, where, parameters, Cheque_TaxRate.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_TaxRate objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_TaxRate objects.</returns>
		protected static EntityList<Cheque_TaxRate> GetCheque_TaxRates(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_TaxRates(prefix, where, parameters, Cheque_TaxRate.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_TaxRate objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_TaxRate objects.</returns>
		protected static EntityList<Cheque_TaxRate> GetCheque_TaxRates(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_TaxRate.SelectFieldList + "FROM [dbo].[Cheque_TaxRate] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_TaxRate>(reader);
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
        protected static EntityList<Cheque_TaxRate> GetCheque_TaxRates(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_TaxRate>(SelectFieldList, "FROM [dbo].[Cheque_TaxRate] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_TaxRate objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_TaxRateCount()
        {
            return GetCheque_TaxRateCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_TaxRate objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_TaxRateCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_TaxRate] " + where;

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
		public static partial class Cheque_TaxRate_Properties
		{
			public const string ID = "ID";
			public const string TaxRateName = "TaxRateName";
			public const string TaxRateValue = "TaxRateValue";
			public const string AddTime = "AddTime";
			public const string GUID = "GUID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"TaxRateName" , "string:"},
    			 {"TaxRateValue" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"GUID" , "string:"},
            };
		}
		#endregion
	}
}
