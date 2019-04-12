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
	/// This object represents the properties and methods of a SpecInfo.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class SpecInfo 
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
		private string _specName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SpecName
		{
			[DebuggerStepThrough()]
			get { return this._specName; }
			set 
			{
				if (this._specName != value) 
				{
					this._specName = value;
					this.IsDirty = true;	
					OnPropertyChanged("SpecName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _coldPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ColdPrice
		{
			[DebuggerStepThrough()]
			get { return this._coldPrice; }
			set 
			{
				if (this._coldPrice != value) 
				{
					this._coldPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("ColdPrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _movePrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal MovePrice
		{
			[DebuggerStepThrough()]
			get { return this._movePrice; }
			set 
			{
				if (this._movePrice != value) 
				{
					this._movePrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("MovePrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _balancePrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal BalancePrice
		{
			[DebuggerStepThrough()]
			get { return this._balancePrice; }
			set 
			{
				if (this._balancePrice != value) 
				{
					this._balancePrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("BalancePrice");
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
	[SpecName] nvarchar(200),
	[ColdPrice] decimal(18, 2),
	[MovePrice] decimal(18, 2),
	[BalancePrice] decimal(18, 2)
);

INSERT INTO [dbo].[SpecInfo] (
	[SpecInfo].[SpecName],
	[SpecInfo].[ColdPrice],
	[SpecInfo].[MovePrice],
	[SpecInfo].[BalancePrice]
) 
output 
	INSERTED.[ID],
	INSERTED.[SpecName],
	INSERTED.[ColdPrice],
	INSERTED.[MovePrice],
	INSERTED.[BalancePrice]
into @table
VALUES ( 
	@SpecName,
	@ColdPrice,
	@MovePrice,
	@BalancePrice 
); 

SELECT 
	[ID],
	[SpecName],
	[ColdPrice],
	[MovePrice],
	[BalancePrice] 
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
	[SpecName] nvarchar(200),
	[ColdPrice] decimal(18, 2),
	[MovePrice] decimal(18, 2),
	[BalancePrice] decimal(18, 2)
);

UPDATE [dbo].[SpecInfo] SET 
	[SpecInfo].[SpecName] = @SpecName,
	[SpecInfo].[ColdPrice] = @ColdPrice,
	[SpecInfo].[MovePrice] = @MovePrice,
	[SpecInfo].[BalancePrice] = @BalancePrice 
output 
	INSERTED.[ID],
	INSERTED.[SpecName],
	INSERTED.[ColdPrice],
	INSERTED.[MovePrice],
	INSERTED.[BalancePrice]
into @table
WHERE 
	[SpecInfo].[ID] = @ID

SELECT 
	[ID],
	[SpecName],
	[ColdPrice],
	[MovePrice],
	[BalancePrice] 
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
DELETE FROM [dbo].[SpecInfo]
WHERE 
	[SpecInfo].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public SpecInfo() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetSpecInfo(this.ID));
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
	[SpecInfo].[ID],
	[SpecInfo].[SpecName],
	[SpecInfo].[ColdPrice],
	[SpecInfo].[MovePrice],
	[SpecInfo].[BalancePrice]
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
                return "SpecInfo";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a SpecInfo into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="specName">specName</param>
		/// <param name="coldPrice">coldPrice</param>
		/// <param name="movePrice">movePrice</param>
		/// <param name="balancePrice">balancePrice</param>
		public static void InsertSpecInfo(string @specName, decimal @coldPrice, decimal @movePrice, decimal @balancePrice)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertSpecInfo(@specName, @coldPrice, @movePrice, @balancePrice, helper);
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
		/// Insert a SpecInfo into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="specName">specName</param>
		/// <param name="coldPrice">coldPrice</param>
		/// <param name="movePrice">movePrice</param>
		/// <param name="balancePrice">balancePrice</param>
		/// <param name="helper">helper</param>
		internal static void InsertSpecInfo(string @specName, decimal @coldPrice, decimal @movePrice, decimal @balancePrice, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SpecName] nvarchar(200),
	[ColdPrice] decimal(18, 2),
	[MovePrice] decimal(18, 2),
	[BalancePrice] decimal(18, 2)
);

INSERT INTO [dbo].[SpecInfo] (
	[SpecInfo].[SpecName],
	[SpecInfo].[ColdPrice],
	[SpecInfo].[MovePrice],
	[SpecInfo].[BalancePrice]
) 
output 
	INSERTED.[ID],
	INSERTED.[SpecName],
	INSERTED.[ColdPrice],
	INSERTED.[MovePrice],
	INSERTED.[BalancePrice]
into @table
VALUES ( 
	@SpecName,
	@ColdPrice,
	@MovePrice,
	@BalancePrice 
); 

SELECT 
	[ID],
	[SpecName],
	[ColdPrice],
	[MovePrice],
	[BalancePrice] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@SpecName", EntityBase.GetDatabaseValue(@specName)));
			parameters.Add(new SqlParameter("@ColdPrice", EntityBase.GetDatabaseValue(@coldPrice)));
			parameters.Add(new SqlParameter("@MovePrice", EntityBase.GetDatabaseValue(@movePrice)));
			parameters.Add(new SqlParameter("@BalancePrice", EntityBase.GetDatabaseValue(@balancePrice)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a SpecInfo into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="specName">specName</param>
		/// <param name="coldPrice">coldPrice</param>
		/// <param name="movePrice">movePrice</param>
		/// <param name="balancePrice">balancePrice</param>
		public static void UpdateSpecInfo(int @iD, string @specName, decimal @coldPrice, decimal @movePrice, decimal @balancePrice)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateSpecInfo(@iD, @specName, @coldPrice, @movePrice, @balancePrice, helper);
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
		/// Updates a SpecInfo into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="specName">specName</param>
		/// <param name="coldPrice">coldPrice</param>
		/// <param name="movePrice">movePrice</param>
		/// <param name="balancePrice">balancePrice</param>
		/// <param name="helper">helper</param>
		internal static void UpdateSpecInfo(int @iD, string @specName, decimal @coldPrice, decimal @movePrice, decimal @balancePrice, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SpecName] nvarchar(200),
	[ColdPrice] decimal(18, 2),
	[MovePrice] decimal(18, 2),
	[BalancePrice] decimal(18, 2)
);

UPDATE [dbo].[SpecInfo] SET 
	[SpecInfo].[SpecName] = @SpecName,
	[SpecInfo].[ColdPrice] = @ColdPrice,
	[SpecInfo].[MovePrice] = @MovePrice,
	[SpecInfo].[BalancePrice] = @BalancePrice 
output 
	INSERTED.[ID],
	INSERTED.[SpecName],
	INSERTED.[ColdPrice],
	INSERTED.[MovePrice],
	INSERTED.[BalancePrice]
into @table
WHERE 
	[SpecInfo].[ID] = @ID

SELECT 
	[ID],
	[SpecName],
	[ColdPrice],
	[MovePrice],
	[BalancePrice] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@SpecName", EntityBase.GetDatabaseValue(@specName)));
			parameters.Add(new SqlParameter("@ColdPrice", EntityBase.GetDatabaseValue(@coldPrice)));
			parameters.Add(new SqlParameter("@MovePrice", EntityBase.GetDatabaseValue(@movePrice)));
			parameters.Add(new SqlParameter("@BalancePrice", EntityBase.GetDatabaseValue(@balancePrice)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a SpecInfo from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteSpecInfo(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteSpecInfo(@iD, helper);
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
		/// Deletes a SpecInfo from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteSpecInfo(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[SpecInfo]
WHERE 
	[SpecInfo].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new SpecInfo object.
		/// </summary>
		/// <returns>The newly created SpecInfo object.</returns>
		public static SpecInfo CreateSpecInfo()
		{
			return InitializeNew<SpecInfo>();
		}
		
		/// <summary>
		/// Retrieve information for a SpecInfo by a SpecInfo's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>SpecInfo</returns>
		public static SpecInfo GetSpecInfo(int @iD)
		{
			string commandText = @"
SELECT 
" + SpecInfo.SelectFieldList + @"
FROM [dbo].[SpecInfo] 
WHERE 
	[SpecInfo].[ID] = @ID " + SpecInfo.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<SpecInfo>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a SpecInfo by a SpecInfo's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>SpecInfo</returns>
		public static SpecInfo GetSpecInfo(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + SpecInfo.SelectFieldList + @"
FROM [dbo].[SpecInfo] 
WHERE 
	[SpecInfo].[ID] = @ID " + SpecInfo.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<SpecInfo>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection SpecInfo objects.
		/// </summary>
		/// <returns>The retrieved collection of SpecInfo objects.</returns>
		public static EntityList<SpecInfo> GetSpecInfos()
		{
			string commandText = @"
SELECT " + SpecInfo.SelectFieldList + "FROM [dbo].[SpecInfo] " + SpecInfo.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<SpecInfo>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection SpecInfo objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of SpecInfo objects.</returns>
        public static EntityList<SpecInfo> GetSpecInfos(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SpecInfo>(SelectFieldList, "FROM [dbo].[SpecInfo]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection SpecInfo objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of SpecInfo objects.</returns>
        public static EntityList<SpecInfo> GetSpecInfos(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SpecInfo>(SelectFieldList, "FROM [dbo].[SpecInfo]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection SpecInfo objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of SpecInfo objects.</returns>
		protected static EntityList<SpecInfo> GetSpecInfos(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSpecInfos(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection SpecInfo objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of SpecInfo objects.</returns>
		protected static EntityList<SpecInfo> GetSpecInfos(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSpecInfos(string.Empty, where, parameters, SpecInfo.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SpecInfo objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of SpecInfo objects.</returns>
		protected static EntityList<SpecInfo> GetSpecInfos(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSpecInfos(prefix, where, parameters, SpecInfo.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SpecInfo objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of SpecInfo objects.</returns>
		protected static EntityList<SpecInfo> GetSpecInfos(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSpecInfos(string.Empty, where, parameters, SpecInfo.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SpecInfo objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of SpecInfo objects.</returns>
		protected static EntityList<SpecInfo> GetSpecInfos(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSpecInfos(prefix, where, parameters, SpecInfo.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SpecInfo objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of SpecInfo objects.</returns>
		protected static EntityList<SpecInfo> GetSpecInfos(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + SpecInfo.SelectFieldList + "FROM [dbo].[SpecInfo] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<SpecInfo>(reader);
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
        protected static EntityList<SpecInfo> GetSpecInfos(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SpecInfo>(SelectFieldList, "FROM [dbo].[SpecInfo] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class SpecInfoProperties
		{
			public const string ID = "ID";
			public const string SpecName = "SpecName";
			public const string ColdPrice = "ColdPrice";
			public const string MovePrice = "MovePrice";
			public const string BalancePrice = "BalancePrice";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"SpecName" , "string:"},
    			 {"ColdPrice" , "decimal:"},
    			 {"MovePrice" , "decimal:"},
    			 {"BalancePrice" , "decimal:"},
            };
		}
		#endregion
	}
}
