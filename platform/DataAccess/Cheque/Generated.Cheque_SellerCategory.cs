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
	/// This object represents the properties and methods of a Cheque_SellerCategory.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_SellerCategory 
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
		private string _sellerCategoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SellerCategoryName
		{
			[DebuggerStepThrough()]
			get { return this._sellerCategoryName; }
			set 
			{
				if (this._sellerCategoryName != value) 
				{
					this._sellerCategoryName = value;
					this.IsDirty = true;	
					OnPropertyChanged("SellerCategoryName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sellerCategoryNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SellerCategoryNumber
		{
			[DebuggerStepThrough()]
			get { return this._sellerCategoryNumber; }
			set 
			{
				if (this._sellerCategoryNumber != value) 
				{
					this._sellerCategoryNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("SellerCategoryNumber");
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
	[SellerCategoryName] nvarchar(200),
	[SellerCategoryNumber] nvarchar(200)
);

INSERT INTO [dbo].[Cheque_SellerCategory] (
	[Cheque_SellerCategory].[SellerCategoryName],
	[Cheque_SellerCategory].[SellerCategoryNumber]
) 
output 
	INSERTED.[ID],
	INSERTED.[SellerCategoryName],
	INSERTED.[SellerCategoryNumber]
into @table
VALUES ( 
	@SellerCategoryName,
	@SellerCategoryNumber 
); 

SELECT 
	[ID],
	[SellerCategoryName],
	[SellerCategoryNumber] 
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
	[SellerCategoryName] nvarchar(200),
	[SellerCategoryNumber] nvarchar(200)
);

UPDATE [dbo].[Cheque_SellerCategory] SET 
	[Cheque_SellerCategory].[SellerCategoryName] = @SellerCategoryName,
	[Cheque_SellerCategory].[SellerCategoryNumber] = @SellerCategoryNumber 
output 
	INSERTED.[ID],
	INSERTED.[SellerCategoryName],
	INSERTED.[SellerCategoryNumber]
into @table
WHERE 
	[Cheque_SellerCategory].[ID] = @ID

SELECT 
	[ID],
	[SellerCategoryName],
	[SellerCategoryNumber] 
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
DELETE FROM [dbo].[Cheque_SellerCategory]
WHERE 
	[Cheque_SellerCategory].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_SellerCategory() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_SellerCategory(this.ID));
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
	[Cheque_SellerCategory].[ID],
	[Cheque_SellerCategory].[SellerCategoryName],
	[Cheque_SellerCategory].[SellerCategoryNumber]
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
                return "Cheque_SellerCategory";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_SellerCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="sellerCategoryName">sellerCategoryName</param>
		/// <param name="sellerCategoryNumber">sellerCategoryNumber</param>
		public static void InsertCheque_SellerCategory(string @sellerCategoryName, string @sellerCategoryNumber)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_SellerCategory(@sellerCategoryName, @sellerCategoryNumber, helper);
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
		/// Insert a Cheque_SellerCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="sellerCategoryName">sellerCategoryName</param>
		/// <param name="sellerCategoryNumber">sellerCategoryNumber</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_SellerCategory(string @sellerCategoryName, string @sellerCategoryNumber, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SellerCategoryName] nvarchar(200),
	[SellerCategoryNumber] nvarchar(200)
);

INSERT INTO [dbo].[Cheque_SellerCategory] (
	[Cheque_SellerCategory].[SellerCategoryName],
	[Cheque_SellerCategory].[SellerCategoryNumber]
) 
output 
	INSERTED.[ID],
	INSERTED.[SellerCategoryName],
	INSERTED.[SellerCategoryNumber]
into @table
VALUES ( 
	@SellerCategoryName,
	@SellerCategoryNumber 
); 

SELECT 
	[ID],
	[SellerCategoryName],
	[SellerCategoryNumber] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@SellerCategoryName", EntityBase.GetDatabaseValue(@sellerCategoryName)));
			parameters.Add(new SqlParameter("@SellerCategoryNumber", EntityBase.GetDatabaseValue(@sellerCategoryNumber)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_SellerCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="sellerCategoryName">sellerCategoryName</param>
		/// <param name="sellerCategoryNumber">sellerCategoryNumber</param>
		public static void UpdateCheque_SellerCategory(int @iD, string @sellerCategoryName, string @sellerCategoryNumber)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_SellerCategory(@iD, @sellerCategoryName, @sellerCategoryNumber, helper);
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
		/// Updates a Cheque_SellerCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="sellerCategoryName">sellerCategoryName</param>
		/// <param name="sellerCategoryNumber">sellerCategoryNumber</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_SellerCategory(int @iD, string @sellerCategoryName, string @sellerCategoryNumber, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SellerCategoryName] nvarchar(200),
	[SellerCategoryNumber] nvarchar(200)
);

UPDATE [dbo].[Cheque_SellerCategory] SET 
	[Cheque_SellerCategory].[SellerCategoryName] = @SellerCategoryName,
	[Cheque_SellerCategory].[SellerCategoryNumber] = @SellerCategoryNumber 
output 
	INSERTED.[ID],
	INSERTED.[SellerCategoryName],
	INSERTED.[SellerCategoryNumber]
into @table
WHERE 
	[Cheque_SellerCategory].[ID] = @ID

SELECT 
	[ID],
	[SellerCategoryName],
	[SellerCategoryNumber] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@SellerCategoryName", EntityBase.GetDatabaseValue(@sellerCategoryName)));
			parameters.Add(new SqlParameter("@SellerCategoryNumber", EntityBase.GetDatabaseValue(@sellerCategoryNumber)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_SellerCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_SellerCategory(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_SellerCategory(@iD, helper);
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
		/// Deletes a Cheque_SellerCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_SellerCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_SellerCategory]
WHERE 
	[Cheque_SellerCategory].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_SellerCategory object.
		/// </summary>
		/// <returns>The newly created Cheque_SellerCategory object.</returns>
		public static Cheque_SellerCategory CreateCheque_SellerCategory()
		{
			return InitializeNew<Cheque_SellerCategory>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_SellerCategory by a Cheque_SellerCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_SellerCategory</returns>
		public static Cheque_SellerCategory GetCheque_SellerCategory(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_SellerCategory.SelectFieldList + @"
FROM [dbo].[Cheque_SellerCategory] 
WHERE 
	[Cheque_SellerCategory].[ID] = @ID " + Cheque_SellerCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_SellerCategory>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_SellerCategory by a Cheque_SellerCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_SellerCategory</returns>
		public static Cheque_SellerCategory GetCheque_SellerCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_SellerCategory.SelectFieldList + @"
FROM [dbo].[Cheque_SellerCategory] 
WHERE 
	[Cheque_SellerCategory].[ID] = @ID " + Cheque_SellerCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_SellerCategory>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_SellerCategory objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_SellerCategory objects.</returns>
		public static EntityList<Cheque_SellerCategory> GetCheque_SellerCategories()
		{
			string commandText = @"
SELECT " + Cheque_SellerCategory.SelectFieldList + "FROM [dbo].[Cheque_SellerCategory] " + Cheque_SellerCategory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_SellerCategory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_SellerCategory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_SellerCategory objects.</returns>
        public static EntityList<Cheque_SellerCategory> GetCheque_SellerCategories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_SellerCategory>(SelectFieldList, "FROM [dbo].[Cheque_SellerCategory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_SellerCategory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_SellerCategory objects.</returns>
        public static EntityList<Cheque_SellerCategory> GetCheque_SellerCategories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_SellerCategory>(SelectFieldList, "FROM [dbo].[Cheque_SellerCategory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_SellerCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_SellerCategory objects.</returns>
		protected static EntityList<Cheque_SellerCategory> GetCheque_SellerCategories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_SellerCategories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_SellerCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_SellerCategory objects.</returns>
		protected static EntityList<Cheque_SellerCategory> GetCheque_SellerCategories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_SellerCategories(string.Empty, where, parameters, Cheque_SellerCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_SellerCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_SellerCategory objects.</returns>
		protected static EntityList<Cheque_SellerCategory> GetCheque_SellerCategories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_SellerCategories(prefix, where, parameters, Cheque_SellerCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_SellerCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_SellerCategory objects.</returns>
		protected static EntityList<Cheque_SellerCategory> GetCheque_SellerCategories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_SellerCategories(string.Empty, where, parameters, Cheque_SellerCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_SellerCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_SellerCategory objects.</returns>
		protected static EntityList<Cheque_SellerCategory> GetCheque_SellerCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_SellerCategories(prefix, where, parameters, Cheque_SellerCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_SellerCategory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_SellerCategory objects.</returns>
		protected static EntityList<Cheque_SellerCategory> GetCheque_SellerCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_SellerCategory.SelectFieldList + "FROM [dbo].[Cheque_SellerCategory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_SellerCategory>(reader);
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
        protected static EntityList<Cheque_SellerCategory> GetCheque_SellerCategories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_SellerCategory>(SelectFieldList, "FROM [dbo].[Cheque_SellerCategory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_SellerCategory objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_SellerCategoryCount()
        {
            return GetCheque_SellerCategoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_SellerCategory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_SellerCategoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_SellerCategory] " + where;

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
		public static partial class Cheque_SellerCategory_Properties
		{
			public const string ID = "ID";
			public const string SellerCategoryName = "SellerCategoryName";
			public const string SellerCategoryNumber = "SellerCategoryNumber";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"SellerCategoryName" , "string:"},
    			 {"SellerCategoryNumber" , "string:"},
            };
		}
		#endregion
	}
}
