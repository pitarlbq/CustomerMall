﻿using System;
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
	/// This object represents the properties and methods of a Mall_CategoryTag.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("TagID: {TagID}, CategoryID: {CategoryID}")]
	public partial class Mall_CategoryTag 
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
	[TagID] int,
	[CategoryID] int
);

INSERT INTO [dbo].[Mall_CategoryTag] (
	[Mall_CategoryTag].[TagID],
	[Mall_CategoryTag].[CategoryID]
) 
output 
	INSERTED.[TagID],
	INSERTED.[CategoryID]
into @table
VALUES ( 
	@TagID,
	@CategoryID 
); 

SELECT 
	[TagID],
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
	[TagID] int,
	[CategoryID] int
);

UPDATE [dbo].[Mall_CategoryTag] SET 
 
output 
	INSERTED.[TagID],
	INSERTED.[CategoryID]
into @table
WHERE 
	[Mall_CategoryTag].[TagID] = @TagID
	AND [Mall_CategoryTag].[CategoryID] = @CategoryID

SELECT 
	[TagID],
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
DELETE FROM [dbo].[Mall_CategoryTag]
WHERE 
	[Mall_CategoryTag].[TagID] = @TagID
	AND [Mall_CategoryTag].[CategoryID] = @CategoryID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_CategoryTag() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_CategoryTag(this.TagID, this.CategoryID));
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
	[Mall_CategoryTag].[TagID],
	[Mall_CategoryTag].[CategoryID]
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
                return "Mall_CategoryTag";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_CategoryTag into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="tagID">tagID</param>
		/// <param name="categoryID">categoryID</param>
		public static void InsertMall_CategoryTag(int @tagID, int @categoryID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_CategoryTag(@tagID, @categoryID, helper);
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
		/// Insert a Mall_CategoryTag into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="tagID">tagID</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_CategoryTag(int @tagID, int @categoryID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[TagID] int,
	[CategoryID] int
);

INSERT INTO [dbo].[Mall_CategoryTag] (
	[Mall_CategoryTag].[TagID],
	[Mall_CategoryTag].[CategoryID]
) 
output 
	INSERTED.[TagID],
	INSERTED.[CategoryID]
into @table
VALUES ( 
	@TagID,
	@CategoryID 
); 

SELECT 
	[TagID],
	[CategoryID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TagID", EntityBase.GetDatabaseValue(@tagID)));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_CategoryTag into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="tagID">tagID</param>
		/// <param name="categoryID">categoryID</param>
		public static void UpdateMall_CategoryTag(int @tagID, int @categoryID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_CategoryTag(@tagID, @categoryID, helper);
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
		/// Updates a Mall_CategoryTag into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="tagID">tagID</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_CategoryTag(int @tagID, int @categoryID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[TagID] int,
	[CategoryID] int
);

UPDATE [dbo].[Mall_CategoryTag] SET 
 
output 
	INSERTED.[TagID],
	INSERTED.[CategoryID]
into @table
WHERE 
	[Mall_CategoryTag].[TagID] = @TagID
	AND [Mall_CategoryTag].[CategoryID] = @CategoryID

SELECT 
	[TagID],
	[CategoryID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TagID", EntityBase.GetDatabaseValue(@tagID)));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_CategoryTag from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="tagID">tagID</param>
		/// <param name="categoryID">categoryID</param>
		public static void DeleteMall_CategoryTag(int @tagID, int @categoryID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_CategoryTag(@tagID, @categoryID, helper);
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
		/// Deletes a Mall_CategoryTag from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="tagID">tagID</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_CategoryTag(int @tagID, int @categoryID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_CategoryTag]
WHERE 
	[Mall_CategoryTag].[TagID] = @TagID
	AND [Mall_CategoryTag].[CategoryID] = @CategoryID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TagID", @tagID));
			parameters.Add(new SqlParameter("@CategoryID", @categoryID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_CategoryTag object.
		/// </summary>
		/// <returns>The newly created Mall_CategoryTag object.</returns>
		public static Mall_CategoryTag CreateMall_CategoryTag()
		{
			return InitializeNew<Mall_CategoryTag>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_CategoryTag by a Mall_CategoryTag's unique identifier.
		/// </summary>
		/// <param name="tagID">tagID</param>
		/// <param name="categoryID">categoryID</param>
		/// <returns>Mall_CategoryTag</returns>
		public static Mall_CategoryTag GetMall_CategoryTag(int @tagID, int @categoryID)
		{
			string commandText = @"
SELECT 
" + Mall_CategoryTag.SelectFieldList + @"
FROM [dbo].[Mall_CategoryTag] 
WHERE 
	[Mall_CategoryTag].[TagID] = @TagID
	AND [Mall_CategoryTag].[CategoryID] = @CategoryID " + Mall_CategoryTag.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TagID", @tagID));
			parameters.Add(new SqlParameter("@CategoryID", @categoryID));
			
			return GetOne<Mall_CategoryTag>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_CategoryTag by a Mall_CategoryTag's unique identifier.
		/// </summary>
		/// <param name="tagID">tagID</param>
		/// <param name="categoryID">categoryID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_CategoryTag</returns>
		public static Mall_CategoryTag GetMall_CategoryTag(int @tagID, int @categoryID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_CategoryTag.SelectFieldList + @"
FROM [dbo].[Mall_CategoryTag] 
WHERE 
	[Mall_CategoryTag].[TagID] = @TagID
	AND [Mall_CategoryTag].[CategoryID] = @CategoryID " + Mall_CategoryTag.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TagID", @tagID));
			parameters.Add(new SqlParameter("@CategoryID", @categoryID));
			
			return GetOne<Mall_CategoryTag>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_CategoryTag objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_CategoryTag objects.</returns>
		public static EntityList<Mall_CategoryTag> GetMall_CategoryTags()
		{
			string commandText = @"
SELECT " + Mall_CategoryTag.SelectFieldList + "FROM [dbo].[Mall_CategoryTag] " + Mall_CategoryTag.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_CategoryTag>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_CategoryTag objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_CategoryTag objects.</returns>
        public static EntityList<Mall_CategoryTag> GetMall_CategoryTags(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CategoryTag>(SelectFieldList, "FROM [dbo].[Mall_CategoryTag]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_CategoryTag objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_CategoryTag objects.</returns>
        public static EntityList<Mall_CategoryTag> GetMall_CategoryTags(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CategoryTag>(SelectFieldList, "FROM [dbo].[Mall_CategoryTag]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_CategoryTag objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_CategoryTag objects.</returns>
		protected static EntityList<Mall_CategoryTag> GetMall_CategoryTags(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CategoryTags(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_CategoryTag objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_CategoryTag objects.</returns>
		protected static EntityList<Mall_CategoryTag> GetMall_CategoryTags(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CategoryTags(string.Empty, where, parameters, Mall_CategoryTag.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CategoryTag objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_CategoryTag objects.</returns>
		protected static EntityList<Mall_CategoryTag> GetMall_CategoryTags(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CategoryTags(prefix, where, parameters, Mall_CategoryTag.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CategoryTag objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_CategoryTag objects.</returns>
		protected static EntityList<Mall_CategoryTag> GetMall_CategoryTags(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_CategoryTags(string.Empty, where, parameters, Mall_CategoryTag.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CategoryTag objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_CategoryTag objects.</returns>
		protected static EntityList<Mall_CategoryTag> GetMall_CategoryTags(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_CategoryTags(prefix, where, parameters, Mall_CategoryTag.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CategoryTag objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_CategoryTag objects.</returns>
		protected static EntityList<Mall_CategoryTag> GetMall_CategoryTags(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_CategoryTag.SelectFieldList + "FROM [dbo].[Mall_CategoryTag] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_CategoryTag>(reader);
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
        protected static EntityList<Mall_CategoryTag> GetMall_CategoryTags(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CategoryTag>(SelectFieldList, "FROM [dbo].[Mall_CategoryTag] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_CategoryTag objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CategoryTagCount()
        {
            return GetMall_CategoryTagCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_CategoryTag objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CategoryTagCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_CategoryTag] " + where;

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
		public static partial class Mall_CategoryTag_Properties
		{
			public const string TagID = "TagID";
			public const string CategoryID = "CategoryID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"TagID" , "int:"},
    			 {"CategoryID" , "int:"},
            };
		}
		#endregion
	}
}
