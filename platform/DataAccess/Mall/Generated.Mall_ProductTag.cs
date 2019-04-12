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
	/// This object represents the properties and methods of a Mall_ProductTag.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("TagID: {TagID}, ProductID: {ProductID}")]
	public partial class Mall_ProductTag 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _tagID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int TagID
		{
			[DebuggerStepThrough()]
			get { return this._tagID; }
			set 
			{
				if (this._tagID != value) 
				{
					this._tagID = value;
					this.IsDirty = true;	
					OnPropertyChanged("TagID");
				}
			}
		}
		
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
	[TagID] int,
	[ProductID] int
);

INSERT INTO [dbo].[Mall_ProductTag] (
	[Mall_ProductTag].[TagID],
	[Mall_ProductTag].[ProductID]
) 
output 
	INSERTED.[TagID],
	INSERTED.[ProductID]
into @table
VALUES ( 
	@TagID,
	@ProductID 
); 

SELECT 
	[TagID],
	[ProductID] 
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
	[TagID] int,
	[ProductID] int
);

UPDATE [dbo].[Mall_ProductTag] SET 
 
output 
	INSERTED.[TagID],
	INSERTED.[ProductID]
into @table
WHERE 
	[Mall_ProductTag].[TagID] = @TagID
	AND [Mall_ProductTag].[ProductID] = @ProductID

SELECT 
	[TagID],
	[ProductID] 
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
DELETE FROM [dbo].[Mall_ProductTag]
WHERE 
	[Mall_ProductTag].[TagID] = @TagID
	AND [Mall_ProductTag].[ProductID] = @ProductID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_ProductTag() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_ProductTag(this.TagID, this.ProductID));
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
	[Mall_ProductTag].[TagID],
	[Mall_ProductTag].[ProductID]
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
                return "Mall_ProductTag";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_ProductTag into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="tagID">tagID</param>
		/// <param name="productID">productID</param>
		public static void InsertMall_ProductTag(int @tagID, int @productID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_ProductTag(@tagID, @productID, helper);
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
		/// Insert a Mall_ProductTag into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="tagID">tagID</param>
		/// <param name="productID">productID</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_ProductTag(int @tagID, int @productID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[TagID] int,
	[ProductID] int
);

INSERT INTO [dbo].[Mall_ProductTag] (
	[Mall_ProductTag].[TagID],
	[Mall_ProductTag].[ProductID]
) 
output 
	INSERTED.[TagID],
	INSERTED.[ProductID]
into @table
VALUES ( 
	@TagID,
	@ProductID 
); 

SELECT 
	[TagID],
	[ProductID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TagID", EntityBase.GetDatabaseValue(@tagID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_ProductTag into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="tagID">tagID</param>
		/// <param name="productID">productID</param>
		public static void UpdateMall_ProductTag(int @tagID, int @productID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_ProductTag(@tagID, @productID, helper);
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
		/// Updates a Mall_ProductTag into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="tagID">tagID</param>
		/// <param name="productID">productID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_ProductTag(int @tagID, int @productID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[TagID] int,
	[ProductID] int
);

UPDATE [dbo].[Mall_ProductTag] SET 
 
output 
	INSERTED.[TagID],
	INSERTED.[ProductID]
into @table
WHERE 
	[Mall_ProductTag].[TagID] = @TagID
	AND [Mall_ProductTag].[ProductID] = @ProductID

SELECT 
	[TagID],
	[ProductID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TagID", EntityBase.GetDatabaseValue(@tagID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_ProductTag from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="tagID">tagID</param>
		/// <param name="productID">productID</param>
		public static void DeleteMall_ProductTag(int @tagID, int @productID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_ProductTag(@tagID, @productID, helper);
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
		/// Deletes a Mall_ProductTag from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="tagID">tagID</param>
		/// <param name="productID">productID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_ProductTag(int @tagID, int @productID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_ProductTag]
WHERE 
	[Mall_ProductTag].[TagID] = @TagID
	AND [Mall_ProductTag].[ProductID] = @ProductID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TagID", @tagID));
			parameters.Add(new SqlParameter("@ProductID", @productID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_ProductTag object.
		/// </summary>
		/// <returns>The newly created Mall_ProductTag object.</returns>
		public static Mall_ProductTag CreateMall_ProductTag()
		{
			return InitializeNew<Mall_ProductTag>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_ProductTag by a Mall_ProductTag's unique identifier.
		/// </summary>
		/// <param name="tagID">tagID</param>
		/// <param name="productID">productID</param>
		/// <returns>Mall_ProductTag</returns>
		public static Mall_ProductTag GetMall_ProductTag(int @tagID, int @productID)
		{
			string commandText = @"
SELECT 
" + Mall_ProductTag.SelectFieldList + @"
FROM [dbo].[Mall_ProductTag] 
WHERE 
	[Mall_ProductTag].[TagID] = @TagID
	AND [Mall_ProductTag].[ProductID] = @ProductID " + Mall_ProductTag.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TagID", @tagID));
			parameters.Add(new SqlParameter("@ProductID", @productID));
			
			return GetOne<Mall_ProductTag>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_ProductTag by a Mall_ProductTag's unique identifier.
		/// </summary>
		/// <param name="tagID">tagID</param>
		/// <param name="productID">productID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_ProductTag</returns>
		public static Mall_ProductTag GetMall_ProductTag(int @tagID, int @productID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_ProductTag.SelectFieldList + @"
FROM [dbo].[Mall_ProductTag] 
WHERE 
	[Mall_ProductTag].[TagID] = @TagID
	AND [Mall_ProductTag].[ProductID] = @ProductID " + Mall_ProductTag.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TagID", @tagID));
			parameters.Add(new SqlParameter("@ProductID", @productID));
			
			return GetOne<Mall_ProductTag>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductTag objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_ProductTag objects.</returns>
		public static EntityList<Mall_ProductTag> GetMall_ProductTags()
		{
			string commandText = @"
SELECT " + Mall_ProductTag.SelectFieldList + "FROM [dbo].[Mall_ProductTag] " + Mall_ProductTag.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_ProductTag>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_ProductTag objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ProductTag objects.</returns>
        public static EntityList<Mall_ProductTag> GetMall_ProductTags(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ProductTag>(SelectFieldList, "FROM [dbo].[Mall_ProductTag]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_ProductTag objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ProductTag objects.</returns>
        public static EntityList<Mall_ProductTag> GetMall_ProductTags(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ProductTag>(SelectFieldList, "FROM [dbo].[Mall_ProductTag]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_ProductTag objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ProductTag objects.</returns>
		protected static EntityList<Mall_ProductTag> GetMall_ProductTags(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ProductTags(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductTag objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ProductTag objects.</returns>
		protected static EntityList<Mall_ProductTag> GetMall_ProductTags(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ProductTags(string.Empty, where, parameters, Mall_ProductTag.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductTag objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ProductTag objects.</returns>
		protected static EntityList<Mall_ProductTag> GetMall_ProductTags(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ProductTags(prefix, where, parameters, Mall_ProductTag.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductTag objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ProductTag objects.</returns>
		protected static EntityList<Mall_ProductTag> GetMall_ProductTags(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ProductTags(string.Empty, where, parameters, Mall_ProductTag.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductTag objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ProductTag objects.</returns>
		protected static EntityList<Mall_ProductTag> GetMall_ProductTags(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ProductTags(prefix, where, parameters, Mall_ProductTag.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductTag objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ProductTag objects.</returns>
		protected static EntityList<Mall_ProductTag> GetMall_ProductTags(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_ProductTag.SelectFieldList + "FROM [dbo].[Mall_ProductTag] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_ProductTag>(reader);
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
        protected static EntityList<Mall_ProductTag> GetMall_ProductTags(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ProductTag>(SelectFieldList, "FROM [dbo].[Mall_ProductTag] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_ProductTag objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ProductTagCount()
        {
            return GetMall_ProductTagCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_ProductTag objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ProductTagCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_ProductTag] " + where;

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
		public static partial class Mall_ProductTag_Properties
		{
			public const string TagID = "TagID";
			public const string ProductID = "ProductID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"TagID" , "int:"},
    			 {"ProductID" , "int:"},
            };
		}
		#endregion
	}
}
