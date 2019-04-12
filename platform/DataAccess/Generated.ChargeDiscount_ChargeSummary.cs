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
	/// This object represents the properties and methods of a ChargeDiscount_ChargeSummary.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ChargeDiscountID: {ChargeDiscountID}, ChargeID: {ChargeID}")]
	public partial class ChargeDiscount_ChargeSummary 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargeDiscountID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int ChargeDiscountID
		{
			[DebuggerStepThrough()]
			get { return this._chargeDiscountID; }
			set 
			{
				if (this._chargeDiscountID != value) 
				{
					this._chargeDiscountID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeDiscountID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int ChargeID
		{
			[DebuggerStepThrough()]
			get { return this._chargeID; }
			set 
			{
				if (this._chargeID != value) 
				{
					this._chargeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeID");
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
	[ChargeDiscountID] int,
	[ChargeID] int
);

INSERT INTO [dbo].[ChargeDiscount_ChargeSummary] (
	[ChargeDiscount_ChargeSummary].[ChargeDiscountID],
	[ChargeDiscount_ChargeSummary].[ChargeID]
) 
output 
	INSERTED.[ChargeDiscountID],
	INSERTED.[ChargeID]
into @table
VALUES ( 
	@ChargeDiscountID,
	@ChargeID 
); 

SELECT 
	[ChargeDiscountID],
	[ChargeID] 
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
	[ChargeDiscountID] int,
	[ChargeID] int
);

UPDATE [dbo].[ChargeDiscount_ChargeSummary] SET 
 
output 
	INSERTED.[ChargeDiscountID],
	INSERTED.[ChargeID]
into @table
WHERE 
	[ChargeDiscount_ChargeSummary].[ChargeDiscountID] = @ChargeDiscountID
	AND [ChargeDiscount_ChargeSummary].[ChargeID] = @ChargeID

SELECT 
	[ChargeDiscountID],
	[ChargeID] 
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
DELETE FROM [dbo].[ChargeDiscount_ChargeSummary]
WHERE 
	[ChargeDiscount_ChargeSummary].[ChargeDiscountID] = @ChargeDiscountID
	AND [ChargeDiscount_ChargeSummary].[ChargeID] = @ChargeID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ChargeDiscount_ChargeSummary() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetChargeDiscount_ChargeSummary(this.ChargeDiscountID, this.ChargeID));
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
	[ChargeDiscount_ChargeSummary].[ChargeDiscountID],
	[ChargeDiscount_ChargeSummary].[ChargeID]
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
                return "ChargeDiscount_ChargeSummary";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ChargeDiscount_ChargeSummary into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeDiscountID">chargeDiscountID</param>
		/// <param name="chargeID">chargeID</param>
		public static void InsertChargeDiscount_ChargeSummary(int @chargeDiscountID, int @chargeID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertChargeDiscount_ChargeSummary(@chargeDiscountID, @chargeID, helper);
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
		/// Insert a ChargeDiscount_ChargeSummary into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeDiscountID">chargeDiscountID</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="helper">helper</param>
		internal static void InsertChargeDiscount_ChargeSummary(int @chargeDiscountID, int @chargeID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ChargeDiscountID] int,
	[ChargeID] int
);

INSERT INTO [dbo].[ChargeDiscount_ChargeSummary] (
	[ChargeDiscount_ChargeSummary].[ChargeDiscountID],
	[ChargeDiscount_ChargeSummary].[ChargeID]
) 
output 
	INSERTED.[ChargeDiscountID],
	INSERTED.[ChargeID]
into @table
VALUES ( 
	@ChargeDiscountID,
	@ChargeID 
); 

SELECT 
	[ChargeDiscountID],
	[ChargeID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ChargeDiscountID", EntityBase.GetDatabaseValue(@chargeDiscountID)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ChargeDiscount_ChargeSummary into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeDiscountID">chargeDiscountID</param>
		/// <param name="chargeID">chargeID</param>
		public static void UpdateChargeDiscount_ChargeSummary(int @chargeDiscountID, int @chargeID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateChargeDiscount_ChargeSummary(@chargeDiscountID, @chargeID, helper);
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
		/// Updates a ChargeDiscount_ChargeSummary into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeDiscountID">chargeDiscountID</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateChargeDiscount_ChargeSummary(int @chargeDiscountID, int @chargeID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ChargeDiscountID] int,
	[ChargeID] int
);

UPDATE [dbo].[ChargeDiscount_ChargeSummary] SET 
 
output 
	INSERTED.[ChargeDiscountID],
	INSERTED.[ChargeID]
into @table
WHERE 
	[ChargeDiscount_ChargeSummary].[ChargeDiscountID] = @ChargeDiscountID
	AND [ChargeDiscount_ChargeSummary].[ChargeID] = @ChargeID

SELECT 
	[ChargeDiscountID],
	[ChargeID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ChargeDiscountID", EntityBase.GetDatabaseValue(@chargeDiscountID)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ChargeDiscount_ChargeSummary from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeDiscountID">chargeDiscountID</param>
		/// <param name="chargeID">chargeID</param>
		public static void DeleteChargeDiscount_ChargeSummary(int @chargeDiscountID, int @chargeID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteChargeDiscount_ChargeSummary(@chargeDiscountID, @chargeID, helper);
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
		/// Deletes a ChargeDiscount_ChargeSummary from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeDiscountID">chargeDiscountID</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteChargeDiscount_ChargeSummary(int @chargeDiscountID, int @chargeID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ChargeDiscount_ChargeSummary]
WHERE 
	[ChargeDiscount_ChargeSummary].[ChargeDiscountID] = @ChargeDiscountID
	AND [ChargeDiscount_ChargeSummary].[ChargeID] = @ChargeID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ChargeDiscountID", @chargeDiscountID));
			parameters.Add(new SqlParameter("@ChargeID", @chargeID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ChargeDiscount_ChargeSummary object.
		/// </summary>
		/// <returns>The newly created ChargeDiscount_ChargeSummary object.</returns>
		public static ChargeDiscount_ChargeSummary CreateChargeDiscount_ChargeSummary()
		{
			return InitializeNew<ChargeDiscount_ChargeSummary>();
		}
		
		/// <summary>
		/// Retrieve information for a ChargeDiscount_ChargeSummary by a ChargeDiscount_ChargeSummary's unique identifier.
		/// </summary>
		/// <param name="chargeDiscountID">chargeDiscountID</param>
		/// <param name="chargeID">chargeID</param>
		/// <returns>ChargeDiscount_ChargeSummary</returns>
		public static ChargeDiscount_ChargeSummary GetChargeDiscount_ChargeSummary(int @chargeDiscountID, int @chargeID)
		{
			string commandText = @"
SELECT 
" + ChargeDiscount_ChargeSummary.SelectFieldList + @"
FROM [dbo].[ChargeDiscount_ChargeSummary] 
WHERE 
	[ChargeDiscount_ChargeSummary].[ChargeDiscountID] = @ChargeDiscountID
	AND [ChargeDiscount_ChargeSummary].[ChargeID] = @ChargeID " + ChargeDiscount_ChargeSummary.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ChargeDiscountID", @chargeDiscountID));
			parameters.Add(new SqlParameter("@ChargeID", @chargeID));
			
			return GetOne<ChargeDiscount_ChargeSummary>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ChargeDiscount_ChargeSummary by a ChargeDiscount_ChargeSummary's unique identifier.
		/// </summary>
		/// <param name="chargeDiscountID">chargeDiscountID</param>
		/// <param name="chargeID">chargeID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ChargeDiscount_ChargeSummary</returns>
		public static ChargeDiscount_ChargeSummary GetChargeDiscount_ChargeSummary(int @chargeDiscountID, int @chargeID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ChargeDiscount_ChargeSummary.SelectFieldList + @"
FROM [dbo].[ChargeDiscount_ChargeSummary] 
WHERE 
	[ChargeDiscount_ChargeSummary].[ChargeDiscountID] = @ChargeDiscountID
	AND [ChargeDiscount_ChargeSummary].[ChargeID] = @ChargeID " + ChargeDiscount_ChargeSummary.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ChargeDiscountID", @chargeDiscountID));
			parameters.Add(new SqlParameter("@ChargeID", @chargeID));
			
			return GetOne<ChargeDiscount_ChargeSummary>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ChargeDiscount_ChargeSummary objects.
		/// </summary>
		/// <returns>The retrieved collection of ChargeDiscount_ChargeSummary objects.</returns>
		public static EntityList<ChargeDiscount_ChargeSummary> GetChargeDiscount_ChargeSummaries()
		{
			string commandText = @"
SELECT " + ChargeDiscount_ChargeSummary.SelectFieldList + "FROM [dbo].[ChargeDiscount_ChargeSummary] " + ChargeDiscount_ChargeSummary.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ChargeDiscount_ChargeSummary>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ChargeDiscount_ChargeSummary objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeDiscount_ChargeSummary objects.</returns>
        public static EntityList<ChargeDiscount_ChargeSummary> GetChargeDiscount_ChargeSummaries(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeDiscount_ChargeSummary>(SelectFieldList, "FROM [dbo].[ChargeDiscount_ChargeSummary]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ChargeDiscount_ChargeSummary objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeDiscount_ChargeSummary objects.</returns>
        public static EntityList<ChargeDiscount_ChargeSummary> GetChargeDiscount_ChargeSummaries(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeDiscount_ChargeSummary>(SelectFieldList, "FROM [dbo].[ChargeDiscount_ChargeSummary]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ChargeDiscount_ChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ChargeDiscount_ChargeSummary objects.</returns>
		protected static EntityList<ChargeDiscount_ChargeSummary> GetChargeDiscount_ChargeSummaries(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeDiscount_ChargeSummaries(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ChargeDiscount_ChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeDiscount_ChargeSummary objects.</returns>
		protected static EntityList<ChargeDiscount_ChargeSummary> GetChargeDiscount_ChargeSummaries(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeDiscount_ChargeSummaries(string.Empty, where, parameters, ChargeDiscount_ChargeSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeDiscount_ChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeDiscount_ChargeSummary objects.</returns>
		protected static EntityList<ChargeDiscount_ChargeSummary> GetChargeDiscount_ChargeSummaries(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeDiscount_ChargeSummaries(prefix, where, parameters, ChargeDiscount_ChargeSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeDiscount_ChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeDiscount_ChargeSummary objects.</returns>
		protected static EntityList<ChargeDiscount_ChargeSummary> GetChargeDiscount_ChargeSummaries(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeDiscount_ChargeSummaries(string.Empty, where, parameters, ChargeDiscount_ChargeSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeDiscount_ChargeSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeDiscount_ChargeSummary objects.</returns>
		protected static EntityList<ChargeDiscount_ChargeSummary> GetChargeDiscount_ChargeSummaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeDiscount_ChargeSummaries(prefix, where, parameters, ChargeDiscount_ChargeSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeDiscount_ChargeSummary objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ChargeDiscount_ChargeSummary objects.</returns>
		protected static EntityList<ChargeDiscount_ChargeSummary> GetChargeDiscount_ChargeSummaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ChargeDiscount_ChargeSummary.SelectFieldList + "FROM [dbo].[ChargeDiscount_ChargeSummary] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ChargeDiscount_ChargeSummary>(reader);
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
        protected static EntityList<ChargeDiscount_ChargeSummary> GetChargeDiscount_ChargeSummaries(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeDiscount_ChargeSummary>(SelectFieldList, "FROM [dbo].[ChargeDiscount_ChargeSummary] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ChargeDiscount_ChargeSummary objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargeDiscount_ChargeSummaryCount()
        {
            return GetChargeDiscount_ChargeSummaryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ChargeDiscount_ChargeSummary objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargeDiscount_ChargeSummaryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ChargeDiscount_ChargeSummary] " + where;

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
		public static partial class ChargeDiscount_ChargeSummary_Properties
		{
			public const string ChargeDiscountID = "ChargeDiscountID";
			public const string ChargeID = "ChargeID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ChargeDiscountID" , "int:"},
    			 {"ChargeID" , "int:"},
            };
		}
		#endregion
	}
}
