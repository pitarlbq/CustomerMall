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
	/// This object represents the properties and methods of a Cheque_ProductCategory.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_ProductCategory 
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
		private string _productCategoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProductCategoryName
		{
			[DebuggerStepThrough()]
			get { return this._productCategoryName; }
			set 
			{
				if (this._productCategoryName != value) 
				{
					this._productCategoryName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductCategoryName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _productCategoryNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProductCategoryNumber
		{
			[DebuggerStepThrough()]
			get { return this._productCategoryNumber; }
			set 
			{
				if (this._productCategoryNumber != value) 
				{
					this._productCategoryNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductCategoryNumber");
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
	[ProductCategoryName] nvarchar(200),
	[ProductCategoryNumber] nvarchar(200)
);

INSERT INTO [dbo].[Cheque_ProductCategory] (
	[Cheque_ProductCategory].[ProductCategoryName],
	[Cheque_ProductCategory].[ProductCategoryNumber]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProductCategoryName],
	INSERTED.[ProductCategoryNumber]
into @table
VALUES ( 
	@ProductCategoryName,
	@ProductCategoryNumber 
); 

SELECT 
	[ID],
	[ProductCategoryName],
	[ProductCategoryNumber] 
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
	[ProductCategoryName] nvarchar(200),
	[ProductCategoryNumber] nvarchar(200)
);

UPDATE [dbo].[Cheque_ProductCategory] SET 
	[Cheque_ProductCategory].[ProductCategoryName] = @ProductCategoryName,
	[Cheque_ProductCategory].[ProductCategoryNumber] = @ProductCategoryNumber 
output 
	INSERTED.[ID],
	INSERTED.[ProductCategoryName],
	INSERTED.[ProductCategoryNumber]
into @table
WHERE 
	[Cheque_ProductCategory].[ID] = @ID

SELECT 
	[ID],
	[ProductCategoryName],
	[ProductCategoryNumber] 
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
DELETE FROM [dbo].[Cheque_ProductCategory]
WHERE 
	[Cheque_ProductCategory].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_ProductCategory() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_ProductCategory(this.ID));
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
	[Cheque_ProductCategory].[ID],
	[Cheque_ProductCategory].[ProductCategoryName],
	[Cheque_ProductCategory].[ProductCategoryNumber]
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
                return "Cheque_ProductCategory";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_ProductCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productCategoryName">productCategoryName</param>
		/// <param name="productCategoryNumber">productCategoryNumber</param>
		public static void InsertCheque_ProductCategory(string @productCategoryName, string @productCategoryNumber)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_ProductCategory(@productCategoryName, @productCategoryNumber, helper);
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
		/// Insert a Cheque_ProductCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productCategoryName">productCategoryName</param>
		/// <param name="productCategoryNumber">productCategoryNumber</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_ProductCategory(string @productCategoryName, string @productCategoryNumber, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProductCategoryName] nvarchar(200),
	[ProductCategoryNumber] nvarchar(200)
);

INSERT INTO [dbo].[Cheque_ProductCategory] (
	[Cheque_ProductCategory].[ProductCategoryName],
	[Cheque_ProductCategory].[ProductCategoryNumber]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProductCategoryName],
	INSERTED.[ProductCategoryNumber]
into @table
VALUES ( 
	@ProductCategoryName,
	@ProductCategoryNumber 
); 

SELECT 
	[ID],
	[ProductCategoryName],
	[ProductCategoryNumber] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProductCategoryName", EntityBase.GetDatabaseValue(@productCategoryName)));
			parameters.Add(new SqlParameter("@ProductCategoryNumber", EntityBase.GetDatabaseValue(@productCategoryNumber)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_ProductCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="productCategoryName">productCategoryName</param>
		/// <param name="productCategoryNumber">productCategoryNumber</param>
		public static void UpdateCheque_ProductCategory(int @iD, string @productCategoryName, string @productCategoryNumber)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_ProductCategory(@iD, @productCategoryName, @productCategoryNumber, helper);
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
		/// Updates a Cheque_ProductCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="productCategoryName">productCategoryName</param>
		/// <param name="productCategoryNumber">productCategoryNumber</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_ProductCategory(int @iD, string @productCategoryName, string @productCategoryNumber, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProductCategoryName] nvarchar(200),
	[ProductCategoryNumber] nvarchar(200)
);

UPDATE [dbo].[Cheque_ProductCategory] SET 
	[Cheque_ProductCategory].[ProductCategoryName] = @ProductCategoryName,
	[Cheque_ProductCategory].[ProductCategoryNumber] = @ProductCategoryNumber 
output 
	INSERTED.[ID],
	INSERTED.[ProductCategoryName],
	INSERTED.[ProductCategoryNumber]
into @table
WHERE 
	[Cheque_ProductCategory].[ID] = @ID

SELECT 
	[ID],
	[ProductCategoryName],
	[ProductCategoryNumber] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProductCategoryName", EntityBase.GetDatabaseValue(@productCategoryName)));
			parameters.Add(new SqlParameter("@ProductCategoryNumber", EntityBase.GetDatabaseValue(@productCategoryNumber)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_ProductCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_ProductCategory(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_ProductCategory(@iD, helper);
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
		/// Deletes a Cheque_ProductCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_ProductCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_ProductCategory]
WHERE 
	[Cheque_ProductCategory].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_ProductCategory object.
		/// </summary>
		/// <returns>The newly created Cheque_ProductCategory object.</returns>
		public static Cheque_ProductCategory CreateCheque_ProductCategory()
		{
			return InitializeNew<Cheque_ProductCategory>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_ProductCategory by a Cheque_ProductCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_ProductCategory</returns>
		public static Cheque_ProductCategory GetCheque_ProductCategory(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_ProductCategory.SelectFieldList + @"
FROM [dbo].[Cheque_ProductCategory] 
WHERE 
	[Cheque_ProductCategory].[ID] = @ID " + Cheque_ProductCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_ProductCategory>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_ProductCategory by a Cheque_ProductCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_ProductCategory</returns>
		public static Cheque_ProductCategory GetCheque_ProductCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_ProductCategory.SelectFieldList + @"
FROM [dbo].[Cheque_ProductCategory] 
WHERE 
	[Cheque_ProductCategory].[ID] = @ID " + Cheque_ProductCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_ProductCategory>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_ProductCategory objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_ProductCategory objects.</returns>
		public static EntityList<Cheque_ProductCategory> GetCheque_ProductCategories()
		{
			string commandText = @"
SELECT " + Cheque_ProductCategory.SelectFieldList + "FROM [dbo].[Cheque_ProductCategory] " + Cheque_ProductCategory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_ProductCategory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_ProductCategory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_ProductCategory objects.</returns>
        public static EntityList<Cheque_ProductCategory> GetCheque_ProductCategories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_ProductCategory>(SelectFieldList, "FROM [dbo].[Cheque_ProductCategory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_ProductCategory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_ProductCategory objects.</returns>
        public static EntityList<Cheque_ProductCategory> GetCheque_ProductCategories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_ProductCategory>(SelectFieldList, "FROM [dbo].[Cheque_ProductCategory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_ProductCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_ProductCategory objects.</returns>
		protected static EntityList<Cheque_ProductCategory> GetCheque_ProductCategories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_ProductCategories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_ProductCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_ProductCategory objects.</returns>
		protected static EntityList<Cheque_ProductCategory> GetCheque_ProductCategories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_ProductCategories(string.Empty, where, parameters, Cheque_ProductCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_ProductCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_ProductCategory objects.</returns>
		protected static EntityList<Cheque_ProductCategory> GetCheque_ProductCategories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_ProductCategories(prefix, where, parameters, Cheque_ProductCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_ProductCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_ProductCategory objects.</returns>
		protected static EntityList<Cheque_ProductCategory> GetCheque_ProductCategories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_ProductCategories(string.Empty, where, parameters, Cheque_ProductCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_ProductCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_ProductCategory objects.</returns>
		protected static EntityList<Cheque_ProductCategory> GetCheque_ProductCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_ProductCategories(prefix, where, parameters, Cheque_ProductCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_ProductCategory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_ProductCategory objects.</returns>
		protected static EntityList<Cheque_ProductCategory> GetCheque_ProductCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_ProductCategory.SelectFieldList + "FROM [dbo].[Cheque_ProductCategory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_ProductCategory>(reader);
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
        protected static EntityList<Cheque_ProductCategory> GetCheque_ProductCategories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_ProductCategory>(SelectFieldList, "FROM [dbo].[Cheque_ProductCategory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_ProductCategory objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_ProductCategoryCount()
        {
            return GetCheque_ProductCategoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_ProductCategory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_ProductCategoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_ProductCategory] " + where;

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
		public static partial class Cheque_ProductCategory_Properties
		{
			public const string ID = "ID";
			public const string ProductCategoryName = "ProductCategoryName";
			public const string ProductCategoryNumber = "ProductCategoryNumber";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProductCategoryName" , "string:"},
    			 {"ProductCategoryNumber" , "string:"},
            };
		}
		#endregion
	}
}
