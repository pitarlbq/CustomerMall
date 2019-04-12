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
	/// This object represents the properties and methods of a ChargeMoneyType.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ChargeTypeID: {ChargeTypeID}")]
	public partial class ChargeMoneyType 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargeTypeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, true, false)]
		public int ChargeTypeID
		{
			[DebuggerStepThrough()]
			get { return this._chargeTypeID; }
			 set 
			{
				if (this._chargeTypeID != value) 
				{
					this._chargeTypeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeTypeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeTypeName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string ChargeTypeName
		{
			[DebuggerStepThrough()]
			get { return this._chargeTypeName; }
			set 
			{
				if (this._chargeTypeName != value) 
				{
					this._chargeTypeName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeTypeName");
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
		[DataObjectField(false, false, true)]
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
	[ChargeTypeID] int,
	[ChargeTypeName] nvarchar(100),
	[SortOrder] int
);

INSERT INTO [dbo].[ChargeMoneyType] (
	[ChargeMoneyType].[ChargeTypeName],
	[ChargeMoneyType].[SortOrder]
) 
output 
	INSERTED.[ChargeTypeID],
	INSERTED.[ChargeTypeName],
	INSERTED.[SortOrder]
into @table
VALUES ( 
	@ChargeTypeName,
	@SortOrder 
); 

SELECT 
	[ChargeTypeID],
	[ChargeTypeName],
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
	[ChargeTypeID] int,
	[ChargeTypeName] nvarchar(100),
	[SortOrder] int
);

UPDATE [dbo].[ChargeMoneyType] SET 
	[ChargeMoneyType].[ChargeTypeName] = @ChargeTypeName,
	[ChargeMoneyType].[SortOrder] = @SortOrder 
output 
	INSERTED.[ChargeTypeID],
	INSERTED.[ChargeTypeName],
	INSERTED.[SortOrder]
into @table
WHERE 
	[ChargeMoneyType].[ChargeTypeID] = @ChargeTypeID

SELECT 
	[ChargeTypeID],
	[ChargeTypeName],
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
DELETE FROM [dbo].[ChargeMoneyType]
WHERE 
	[ChargeMoneyType].[ChargeTypeID] = @ChargeTypeID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ChargeMoneyType() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetChargeMoneyType(this.ChargeTypeID));
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
	[ChargeMoneyType].[ChargeTypeID],
	[ChargeMoneyType].[ChargeTypeName],
	[ChargeMoneyType].[SortOrder]
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
                return "ChargeMoneyType";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ChargeMoneyType into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeTypeName">chargeTypeName</param>
		/// <param name="sortOrder">sortOrder</param>
		public static void InsertChargeMoneyType(string @chargeTypeName, int @sortOrder)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertChargeMoneyType(@chargeTypeName, @sortOrder, helper);
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
		/// Insert a ChargeMoneyType into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeTypeName">chargeTypeName</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="helper">helper</param>
		internal static void InsertChargeMoneyType(string @chargeTypeName, int @sortOrder, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ChargeTypeID] int,
	[ChargeTypeName] nvarchar(100),
	[SortOrder] int
);

INSERT INTO [dbo].[ChargeMoneyType] (
	[ChargeMoneyType].[ChargeTypeName],
	[ChargeMoneyType].[SortOrder]
) 
output 
	INSERTED.[ChargeTypeID],
	INSERTED.[ChargeTypeName],
	INSERTED.[SortOrder]
into @table
VALUES ( 
	@ChargeTypeName,
	@SortOrder 
); 

SELECT 
	[ChargeTypeID],
	[ChargeTypeName],
	[SortOrder] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ChargeTypeName", EntityBase.GetDatabaseValue(@chargeTypeName)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ChargeMoneyType into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeTypeID">chargeTypeID</param>
		/// <param name="chargeTypeName">chargeTypeName</param>
		/// <param name="sortOrder">sortOrder</param>
		public static void UpdateChargeMoneyType(int @chargeTypeID, string @chargeTypeName, int @sortOrder)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateChargeMoneyType(@chargeTypeID, @chargeTypeName, @sortOrder, helper);
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
		/// Updates a ChargeMoneyType into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeTypeID">chargeTypeID</param>
		/// <param name="chargeTypeName">chargeTypeName</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="helper">helper</param>
		internal static void UpdateChargeMoneyType(int @chargeTypeID, string @chargeTypeName, int @sortOrder, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ChargeTypeID] int,
	[ChargeTypeName] nvarchar(100),
	[SortOrder] int
);

UPDATE [dbo].[ChargeMoneyType] SET 
	[ChargeMoneyType].[ChargeTypeName] = @ChargeTypeName,
	[ChargeMoneyType].[SortOrder] = @SortOrder 
output 
	INSERTED.[ChargeTypeID],
	INSERTED.[ChargeTypeName],
	INSERTED.[SortOrder]
into @table
WHERE 
	[ChargeMoneyType].[ChargeTypeID] = @ChargeTypeID

SELECT 
	[ChargeTypeID],
	[ChargeTypeName],
	[SortOrder] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ChargeTypeID", EntityBase.GetDatabaseValue(@chargeTypeID)));
			parameters.Add(new SqlParameter("@ChargeTypeName", EntityBase.GetDatabaseValue(@chargeTypeName)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ChargeMoneyType from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeTypeID">chargeTypeID</param>
		public static void DeleteChargeMoneyType(int @chargeTypeID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteChargeMoneyType(@chargeTypeID, helper);
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
		/// Deletes a ChargeMoneyType from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeTypeID">chargeTypeID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteChargeMoneyType(int @chargeTypeID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ChargeMoneyType]
WHERE 
	[ChargeMoneyType].[ChargeTypeID] = @ChargeTypeID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ChargeTypeID", @chargeTypeID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ChargeMoneyType object.
		/// </summary>
		/// <returns>The newly created ChargeMoneyType object.</returns>
		public static ChargeMoneyType CreateChargeMoneyType()
		{
			return InitializeNew<ChargeMoneyType>();
		}
		
		/// <summary>
		/// Retrieve information for a ChargeMoneyType by a ChargeMoneyType's unique identifier.
		/// </summary>
		/// <param name="chargeTypeID">chargeTypeID</param>
		/// <returns>ChargeMoneyType</returns>
		public static ChargeMoneyType GetChargeMoneyType(int @chargeTypeID)
		{
			string commandText = @"
SELECT 
" + ChargeMoneyType.SelectFieldList + @"
FROM [dbo].[ChargeMoneyType] 
WHERE 
	[ChargeMoneyType].[ChargeTypeID] = @ChargeTypeID " + ChargeMoneyType.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ChargeTypeID", @chargeTypeID));
			
			return GetOne<ChargeMoneyType>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ChargeMoneyType by a ChargeMoneyType's unique identifier.
		/// </summary>
		/// <param name="chargeTypeID">chargeTypeID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ChargeMoneyType</returns>
		public static ChargeMoneyType GetChargeMoneyType(int @chargeTypeID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ChargeMoneyType.SelectFieldList + @"
FROM [dbo].[ChargeMoneyType] 
WHERE 
	[ChargeMoneyType].[ChargeTypeID] = @ChargeTypeID " + ChargeMoneyType.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ChargeTypeID", @chargeTypeID));
			
			return GetOne<ChargeMoneyType>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ChargeMoneyType objects.
		/// </summary>
		/// <returns>The retrieved collection of ChargeMoneyType objects.</returns>
		public static EntityList<ChargeMoneyType> GetChargeMoneyTypes()
		{
			string commandText = @"
SELECT " + ChargeMoneyType.SelectFieldList + "FROM [dbo].[ChargeMoneyType] " + ChargeMoneyType.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ChargeMoneyType>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ChargeMoneyType objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeMoneyType objects.</returns>
        public static EntityList<ChargeMoneyType> GetChargeMoneyTypes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeMoneyType>(SelectFieldList, "FROM [dbo].[ChargeMoneyType]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ChargeMoneyType objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeMoneyType objects.</returns>
        public static EntityList<ChargeMoneyType> GetChargeMoneyTypes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeMoneyType>(SelectFieldList, "FROM [dbo].[ChargeMoneyType]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ChargeMoneyType objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ChargeMoneyType objects.</returns>
		protected static EntityList<ChargeMoneyType> GetChargeMoneyTypes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeMoneyTypes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ChargeMoneyType objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeMoneyType objects.</returns>
		protected static EntityList<ChargeMoneyType> GetChargeMoneyTypes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeMoneyTypes(string.Empty, where, parameters, ChargeMoneyType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeMoneyType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeMoneyType objects.</returns>
		protected static EntityList<ChargeMoneyType> GetChargeMoneyTypes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeMoneyTypes(prefix, where, parameters, ChargeMoneyType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeMoneyType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeMoneyType objects.</returns>
		protected static EntityList<ChargeMoneyType> GetChargeMoneyTypes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeMoneyTypes(string.Empty, where, parameters, ChargeMoneyType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeMoneyType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeMoneyType objects.</returns>
		protected static EntityList<ChargeMoneyType> GetChargeMoneyTypes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeMoneyTypes(prefix, where, parameters, ChargeMoneyType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeMoneyType objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ChargeMoneyType objects.</returns>
		protected static EntityList<ChargeMoneyType> GetChargeMoneyTypes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ChargeMoneyType.SelectFieldList + "FROM [dbo].[ChargeMoneyType] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ChargeMoneyType>(reader);
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
        protected static EntityList<ChargeMoneyType> GetChargeMoneyTypes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeMoneyType>(SelectFieldList, "FROM [dbo].[ChargeMoneyType] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class ChargeMoneyTypeProperties
		{
			public const string ChargeTypeID = "ChargeTypeID";
			public const string ChargeTypeName = "ChargeTypeName";
			public const string SortOrder = "SortOrder";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ChargeTypeID" , "int:"},
    			 {"ChargeTypeName" , "string:"},
    			 {"SortOrder" , "int:"},
            };
		}
		#endregion
	}
}
