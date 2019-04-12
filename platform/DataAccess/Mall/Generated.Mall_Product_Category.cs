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
	/// This object represents the properties and methods of a Mall_Product_Category.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ProductID: {ProductID}, CategoryID: {CategoryID}")]
	public partial class Mall_Product_Category 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _productID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int ProductID
		{
			[DebuggerStepThrough()]
			get { return this._productID; }
			set 
			{
				if (this._productID != value) 
				{
					this._productID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _categoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int CategoryID
		{
			[DebuggerStepThrough()]
			get { return this._categoryID; }
			set 
			{
				if (this._categoryID != value) 
				{
					this._categoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CategoryID");
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
	[ProductID] int,
	[CategoryID] int
);

INSERT INTO [dbo].[Mall_Product_Category] (
	[Mall_Product_Category].[ProductID],
	[Mall_Product_Category].[CategoryID]
) 
output 
	INSERTED.[ProductID],
	INSERTED.[CategoryID]
into @table
VALUES ( 
	@ProductID,
	@CategoryID 
); 

SELECT 
	[ProductID],
	[CategoryID] 
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
	[ProductID] int,
	[CategoryID] int
);

UPDATE [dbo].[Mall_Product_Category] SET 
 
output 
	INSERTED.[ProductID],
	INSERTED.[CategoryID]
into @table
WHERE 
	[Mall_Product_Category].[ProductID] = @ProductID
	AND [Mall_Product_Category].[CategoryID] = @CategoryID

SELECT 
	[ProductID],
	[CategoryID] 
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
DELETE FROM [dbo].[Mall_Product_Category]
WHERE 
	[Mall_Product_Category].[ProductID] = @ProductID
	AND [Mall_Product_Category].[CategoryID] = @CategoryID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_Product_Category() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_Product_Category(this.ProductID, this.CategoryID));
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
	[Mall_Product_Category].[ProductID],
	[Mall_Product_Category].[CategoryID]
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
                return "Mall_Product_Category";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_Product_Category into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productID">productID</param>
		/// <param name="categoryID">categoryID</param>
		public static void InsertMall_Product_Category(int @productID, int @categoryID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_Product_Category(@productID, @categoryID, helper);
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
		/// Insert a Mall_Product_Category into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productID">productID</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_Product_Category(int @productID, int @categoryID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ProductID] int,
	[CategoryID] int
);

INSERT INTO [dbo].[Mall_Product_Category] (
	[Mall_Product_Category].[ProductID],
	[Mall_Product_Category].[CategoryID]
) 
output 
	INSERTED.[ProductID],
	INSERTED.[CategoryID]
into @table
VALUES ( 
	@ProductID,
	@CategoryID 
); 

SELECT 
	[ProductID],
	[CategoryID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_Product_Category into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="productID">productID</param>
		/// <param name="categoryID">categoryID</param>
		public static void UpdateMall_Product_Category(int @productID, int @categoryID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_Product_Category(@productID, @categoryID, helper);
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
		/// Updates a Mall_Product_Category into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="productID">productID</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_Product_Category(int @productID, int @categoryID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ProductID] int,
	[CategoryID] int
);

UPDATE [dbo].[Mall_Product_Category] SET 
 
output 
	INSERTED.[ProductID],
	INSERTED.[CategoryID]
into @table
WHERE 
	[Mall_Product_Category].[ProductID] = @ProductID
	AND [Mall_Product_Category].[CategoryID] = @CategoryID

SELECT 
	[ProductID],
	[CategoryID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_Product_Category from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="productID">productID</param>
		/// <param name="categoryID">categoryID</param>
		public static void DeleteMall_Product_Category(int @productID, int @categoryID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_Product_Category(@productID, @categoryID, helper);
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
		/// Deletes a Mall_Product_Category from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="productID">productID</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_Product_Category(int @productID, int @categoryID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_Product_Category]
WHERE 
	[Mall_Product_Category].[ProductID] = @ProductID
	AND [Mall_Product_Category].[CategoryID] = @CategoryID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProductID", @productID));
			parameters.Add(new SqlParameter("@CategoryID", @categoryID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_Product_Category object.
		/// </summary>
		/// <returns>The newly created Mall_Product_Category object.</returns>
		public static Mall_Product_Category CreateMall_Product_Category()
		{
			return InitializeNew<Mall_Product_Category>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_Product_Category by a Mall_Product_Category's unique identifier.
		/// </summary>
		/// <param name="productID">productID</param>
		/// <param name="categoryID">categoryID</param>
		/// <returns>Mall_Product_Category</returns>
		public static Mall_Product_Category GetMall_Product_Category(int @productID, int @categoryID)
		{
			string commandText = @"
SELECT 
" + Mall_Product_Category.SelectFieldList + @"
FROM [dbo].[Mall_Product_Category] 
WHERE 
	[Mall_Product_Category].[ProductID] = @ProductID
	AND [Mall_Product_Category].[CategoryID] = @CategoryID " + Mall_Product_Category.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProductID", @productID));
			parameters.Add(new SqlParameter("@CategoryID", @categoryID));
			
			return GetOne<Mall_Product_Category>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_Product_Category by a Mall_Product_Category's unique identifier.
		/// </summary>
		/// <param name="productID">productID</param>
		/// <param name="categoryID">categoryID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_Product_Category</returns>
		public static Mall_Product_Category GetMall_Product_Category(int @productID, int @categoryID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_Product_Category.SelectFieldList + @"
FROM [dbo].[Mall_Product_Category] 
WHERE 
	[Mall_Product_Category].[ProductID] = @ProductID
	AND [Mall_Product_Category].[CategoryID] = @CategoryID " + Mall_Product_Category.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProductID", @productID));
			parameters.Add(new SqlParameter("@CategoryID", @categoryID));
			
			return GetOne<Mall_Product_Category>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product_Category objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_Product_Category objects.</returns>
		public static EntityList<Mall_Product_Category> GetMall_Product_Categories()
		{
			string commandText = @"
SELECT " + Mall_Product_Category.SelectFieldList + "FROM [dbo].[Mall_Product_Category] " + Mall_Product_Category.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_Product_Category>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_Product_Category objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Product_Category objects.</returns>
        public static EntityList<Mall_Product_Category> GetMall_Product_Categories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Product_Category>(SelectFieldList, "FROM [dbo].[Mall_Product_Category]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_Product_Category objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Product_Category objects.</returns>
        public static EntityList<Mall_Product_Category> GetMall_Product_Categories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Product_Category>(SelectFieldList, "FROM [dbo].[Mall_Product_Category]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_Product_Category objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Product_Category objects.</returns>
		protected static EntityList<Mall_Product_Category> GetMall_Product_Categories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Product_Categories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product_Category objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Product_Category objects.</returns>
		protected static EntityList<Mall_Product_Category> GetMall_Product_Categories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Product_Categories(string.Empty, where, parameters, Mall_Product_Category.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product_Category objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Product_Category objects.</returns>
		protected static EntityList<Mall_Product_Category> GetMall_Product_Categories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Product_Categories(prefix, where, parameters, Mall_Product_Category.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product_Category objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Product_Category objects.</returns>
		protected static EntityList<Mall_Product_Category> GetMall_Product_Categories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Product_Categories(string.Empty, where, parameters, Mall_Product_Category.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product_Category objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Product_Category objects.</returns>
		protected static EntityList<Mall_Product_Category> GetMall_Product_Categories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Product_Categories(prefix, where, parameters, Mall_Product_Category.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product_Category objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Product_Category objects.</returns>
		protected static EntityList<Mall_Product_Category> GetMall_Product_Categories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_Product_Category.SelectFieldList + "FROM [dbo].[Mall_Product_Category] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_Product_Category>(reader);
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
        protected static EntityList<Mall_Product_Category> GetMall_Product_Categories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Product_Category>(SelectFieldList, "FROM [dbo].[Mall_Product_Category] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_Product_Category objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_Product_CategoryCount()
        {
            return GetMall_Product_CategoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_Product_Category objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_Product_CategoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_Product_Category] " + where;

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
		public static partial class Mall_Product_Category_Properties
		{
			public const string ProductID = "ProductID";
			public const string CategoryID = "CategoryID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ProductID" , "int:"},
    			 {"CategoryID" , "int:"},
            };
		}
		#endregion
	}
}
