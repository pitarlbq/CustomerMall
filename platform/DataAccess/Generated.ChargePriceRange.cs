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
	/// This object represents the properties and methods of a ChargePriceRange.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ChargePriceRange 
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
		private int _summaryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int SummaryID
		{
			[DebuggerStepThrough()]
			get { return this._summaryID; }
			set 
			{
				if (this._summaryID != value) 
				{
					this._summaryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("SummaryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _minValue = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string MinValue
		{
			[DebuggerStepThrough()]
			get { return this._minValue; }
			set 
			{
				if (this._minValue != value) 
				{
					this._minValue = value;
					this.IsDirty = true;	
					OnPropertyChanged("MinValue");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _maxValue = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string MaxValue
		{
			[DebuggerStepThrough()]
			get { return this._maxValue; }
			set 
			{
				if (this._maxValue != value) 
				{
					this._maxValue = value;
					this.IsDirty = true;	
					OnPropertyChanged("MaxValue");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _basePrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal BasePrice
		{
			[DebuggerStepThrough()]
			get { return this._basePrice; }
			set 
			{
				if (this._basePrice != value) 
				{
					this._basePrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("BasePrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _baseType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string BaseType
		{
			[DebuggerStepThrough()]
			get { return this._baseType; }
			set 
			{
				if (this._baseType != value) 
				{
					this._baseType = value;
					this.IsDirty = true;	
					OnPropertyChanged("BaseType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isActive = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsActive
		{
			[DebuggerStepThrough()]
			get { return this._isActive; }
			set 
			{
				if (this._isActive != value) 
				{
					this._isActive = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsActive");
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
	[SummaryID] int,
	[MinValue] nvarchar(100),
	[MaxValue] nvarchar(100),
	[BasePrice] decimal(18, 3),
	[BaseType] nvarchar(50),
	[IsActive] bit,
	[AddTime] datetime
);

INSERT INTO [dbo].[ChargePriceRange] (
	[ChargePriceRange].[SummaryID],
	[ChargePriceRange].[MinValue],
	[ChargePriceRange].[MaxValue],
	[ChargePriceRange].[BasePrice],
	[ChargePriceRange].[BaseType],
	[ChargePriceRange].[IsActive],
	[ChargePriceRange].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[SummaryID],
	INSERTED.[MinValue],
	INSERTED.[MaxValue],
	INSERTED.[BasePrice],
	INSERTED.[BaseType],
	INSERTED.[IsActive],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@SummaryID,
	@MinValue,
	@MaxValue,
	@BasePrice,
	@BaseType,
	@IsActive,
	@AddTime 
); 

SELECT 
	[ID],
	[SummaryID],
	[MinValue],
	[MaxValue],
	[BasePrice],
	[BaseType],
	[IsActive],
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
	[SummaryID] int,
	[MinValue] nvarchar(100),
	[MaxValue] nvarchar(100),
	[BasePrice] decimal(18, 3),
	[BaseType] nvarchar(50),
	[IsActive] bit,
	[AddTime] datetime
);

UPDATE [dbo].[ChargePriceRange] SET 
	[ChargePriceRange].[SummaryID] = @SummaryID,
	[ChargePriceRange].[MinValue] = @MinValue,
	[ChargePriceRange].[MaxValue] = @MaxValue,
	[ChargePriceRange].[BasePrice] = @BasePrice,
	[ChargePriceRange].[BaseType] = @BaseType,
	[ChargePriceRange].[IsActive] = @IsActive,
	[ChargePriceRange].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[SummaryID],
	INSERTED.[MinValue],
	INSERTED.[MaxValue],
	INSERTED.[BasePrice],
	INSERTED.[BaseType],
	INSERTED.[IsActive],
	INSERTED.[AddTime]
into @table
WHERE 
	[ChargePriceRange].[ID] = @ID

SELECT 
	[ID],
	[SummaryID],
	[MinValue],
	[MaxValue],
	[BasePrice],
	[BaseType],
	[IsActive],
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
DELETE FROM [dbo].[ChargePriceRange]
WHERE 
	[ChargePriceRange].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ChargePriceRange() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetChargePriceRange(this.ID));
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
	[ChargePriceRange].[ID],
	[ChargePriceRange].[SummaryID],
	[ChargePriceRange].[MinValue],
	[ChargePriceRange].[MaxValue],
	[ChargePriceRange].[BasePrice],
	[ChargePriceRange].[BaseType],
	[ChargePriceRange].[IsActive],
	[ChargePriceRange].[AddTime]
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
                return "ChargePriceRange";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ChargePriceRange into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="summaryID">summaryID</param>
		/// <param name="minValue">minValue</param>
		/// <param name="maxValue">maxValue</param>
		/// <param name="basePrice">basePrice</param>
		/// <param name="baseType">baseType</param>
		/// <param name="isActive">isActive</param>
		/// <param name="addTime">addTime</param>
		public static void InsertChargePriceRange(int @summaryID, string @minValue, string @maxValue, decimal @basePrice, string @baseType, bool @isActive, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertChargePriceRange(@summaryID, @minValue, @maxValue, @basePrice, @baseType, @isActive, @addTime, helper);
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
		/// Insert a ChargePriceRange into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="summaryID">summaryID</param>
		/// <param name="minValue">minValue</param>
		/// <param name="maxValue">maxValue</param>
		/// <param name="basePrice">basePrice</param>
		/// <param name="baseType">baseType</param>
		/// <param name="isActive">isActive</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertChargePriceRange(int @summaryID, string @minValue, string @maxValue, decimal @basePrice, string @baseType, bool @isActive, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SummaryID] int,
	[MinValue] nvarchar(100),
	[MaxValue] nvarchar(100),
	[BasePrice] decimal(18, 3),
	[BaseType] nvarchar(50),
	[IsActive] bit,
	[AddTime] datetime
);

INSERT INTO [dbo].[ChargePriceRange] (
	[ChargePriceRange].[SummaryID],
	[ChargePriceRange].[MinValue],
	[ChargePriceRange].[MaxValue],
	[ChargePriceRange].[BasePrice],
	[ChargePriceRange].[BaseType],
	[ChargePriceRange].[IsActive],
	[ChargePriceRange].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[SummaryID],
	INSERTED.[MinValue],
	INSERTED.[MaxValue],
	INSERTED.[BasePrice],
	INSERTED.[BaseType],
	INSERTED.[IsActive],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@SummaryID,
	@MinValue,
	@MaxValue,
	@BasePrice,
	@BaseType,
	@IsActive,
	@AddTime 
); 

SELECT 
	[ID],
	[SummaryID],
	[MinValue],
	[MaxValue],
	[BasePrice],
	[BaseType],
	[IsActive],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@SummaryID", EntityBase.GetDatabaseValue(@summaryID)));
			parameters.Add(new SqlParameter("@MinValue", EntityBase.GetDatabaseValue(@minValue)));
			parameters.Add(new SqlParameter("@MaxValue", EntityBase.GetDatabaseValue(@maxValue)));
			parameters.Add(new SqlParameter("@BasePrice", EntityBase.GetDatabaseValue(@basePrice)));
			parameters.Add(new SqlParameter("@BaseType", EntityBase.GetDatabaseValue(@baseType)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ChargePriceRange into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="summaryID">summaryID</param>
		/// <param name="minValue">minValue</param>
		/// <param name="maxValue">maxValue</param>
		/// <param name="basePrice">basePrice</param>
		/// <param name="baseType">baseType</param>
		/// <param name="isActive">isActive</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateChargePriceRange(int @iD, int @summaryID, string @minValue, string @maxValue, decimal @basePrice, string @baseType, bool @isActive, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateChargePriceRange(@iD, @summaryID, @minValue, @maxValue, @basePrice, @baseType, @isActive, @addTime, helper);
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
		/// Updates a ChargePriceRange into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="summaryID">summaryID</param>
		/// <param name="minValue">minValue</param>
		/// <param name="maxValue">maxValue</param>
		/// <param name="basePrice">basePrice</param>
		/// <param name="baseType">baseType</param>
		/// <param name="isActive">isActive</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateChargePriceRange(int @iD, int @summaryID, string @minValue, string @maxValue, decimal @basePrice, string @baseType, bool @isActive, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SummaryID] int,
	[MinValue] nvarchar(100),
	[MaxValue] nvarchar(100),
	[BasePrice] decimal(18, 3),
	[BaseType] nvarchar(50),
	[IsActive] bit,
	[AddTime] datetime
);

UPDATE [dbo].[ChargePriceRange] SET 
	[ChargePriceRange].[SummaryID] = @SummaryID,
	[ChargePriceRange].[MinValue] = @MinValue,
	[ChargePriceRange].[MaxValue] = @MaxValue,
	[ChargePriceRange].[BasePrice] = @BasePrice,
	[ChargePriceRange].[BaseType] = @BaseType,
	[ChargePriceRange].[IsActive] = @IsActive,
	[ChargePriceRange].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[SummaryID],
	INSERTED.[MinValue],
	INSERTED.[MaxValue],
	INSERTED.[BasePrice],
	INSERTED.[BaseType],
	INSERTED.[IsActive],
	INSERTED.[AddTime]
into @table
WHERE 
	[ChargePriceRange].[ID] = @ID

SELECT 
	[ID],
	[SummaryID],
	[MinValue],
	[MaxValue],
	[BasePrice],
	[BaseType],
	[IsActive],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@SummaryID", EntityBase.GetDatabaseValue(@summaryID)));
			parameters.Add(new SqlParameter("@MinValue", EntityBase.GetDatabaseValue(@minValue)));
			parameters.Add(new SqlParameter("@MaxValue", EntityBase.GetDatabaseValue(@maxValue)));
			parameters.Add(new SqlParameter("@BasePrice", EntityBase.GetDatabaseValue(@basePrice)));
			parameters.Add(new SqlParameter("@BaseType", EntityBase.GetDatabaseValue(@baseType)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ChargePriceRange from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteChargePriceRange(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteChargePriceRange(@iD, helper);
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
		/// Deletes a ChargePriceRange from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteChargePriceRange(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ChargePriceRange]
WHERE 
	[ChargePriceRange].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ChargePriceRange object.
		/// </summary>
		/// <returns>The newly created ChargePriceRange object.</returns>
		public static ChargePriceRange CreateChargePriceRange()
		{
			return InitializeNew<ChargePriceRange>();
		}
		
		/// <summary>
		/// Retrieve information for a ChargePriceRange by a ChargePriceRange's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ChargePriceRange</returns>
		public static ChargePriceRange GetChargePriceRange(int @iD)
		{
			string commandText = @"
SELECT 
" + ChargePriceRange.SelectFieldList + @"
FROM [dbo].[ChargePriceRange] 
WHERE 
	[ChargePriceRange].[ID] = @ID " + ChargePriceRange.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargePriceRange>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ChargePriceRange by a ChargePriceRange's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ChargePriceRange</returns>
		public static ChargePriceRange GetChargePriceRange(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ChargePriceRange.SelectFieldList + @"
FROM [dbo].[ChargePriceRange] 
WHERE 
	[ChargePriceRange].[ID] = @ID " + ChargePriceRange.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargePriceRange>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ChargePriceRange objects.
		/// </summary>
		/// <returns>The retrieved collection of ChargePriceRange objects.</returns>
		public static EntityList<ChargePriceRange> GetChargePriceRanges()
		{
			string commandText = @"
SELECT " + ChargePriceRange.SelectFieldList + "FROM [dbo].[ChargePriceRange] " + ChargePriceRange.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ChargePriceRange>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ChargePriceRange objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargePriceRange objects.</returns>
        public static EntityList<ChargePriceRange> GetChargePriceRanges(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargePriceRange>(SelectFieldList, "FROM [dbo].[ChargePriceRange]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ChargePriceRange objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargePriceRange objects.</returns>
        public static EntityList<ChargePriceRange> GetChargePriceRanges(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargePriceRange>(SelectFieldList, "FROM [dbo].[ChargePriceRange]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ChargePriceRange objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ChargePriceRange objects.</returns>
		protected static EntityList<ChargePriceRange> GetChargePriceRanges(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargePriceRanges(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ChargePriceRange objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargePriceRange objects.</returns>
		protected static EntityList<ChargePriceRange> GetChargePriceRanges(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargePriceRanges(string.Empty, where, parameters, ChargePriceRange.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargePriceRange objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargePriceRange objects.</returns>
		protected static EntityList<ChargePriceRange> GetChargePriceRanges(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargePriceRanges(prefix, where, parameters, ChargePriceRange.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargePriceRange objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargePriceRange objects.</returns>
		protected static EntityList<ChargePriceRange> GetChargePriceRanges(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargePriceRanges(string.Empty, where, parameters, ChargePriceRange.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargePriceRange objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargePriceRange objects.</returns>
		protected static EntityList<ChargePriceRange> GetChargePriceRanges(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargePriceRanges(prefix, where, parameters, ChargePriceRange.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargePriceRange objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ChargePriceRange objects.</returns>
		protected static EntityList<ChargePriceRange> GetChargePriceRanges(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ChargePriceRange.SelectFieldList + "FROM [dbo].[ChargePriceRange] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ChargePriceRange>(reader);
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
        protected static EntityList<ChargePriceRange> GetChargePriceRanges(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargePriceRange>(SelectFieldList, "FROM [dbo].[ChargePriceRange] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ChargePriceRange objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargePriceRangeCount()
        {
            return GetChargePriceRangeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ChargePriceRange objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargePriceRangeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ChargePriceRange] " + where;

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
		public static partial class ChargePriceRange_Properties
		{
			public const string ID = "ID";
			public const string SummaryID = "SummaryID";
			public const string MinValue = "MinValue";
			public const string MaxValue = "MaxValue";
			public const string BasePrice = "BasePrice";
			public const string BaseType = "BaseType";
			public const string IsActive = "IsActive";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"SummaryID" , "int:"},
    			 {"MinValue" , "string:"},
    			 {"MaxValue" , "string:"},
    			 {"BasePrice" , "decimal:"},
    			 {"BaseType" , "string:"},
    			 {"IsActive" , "bool:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
