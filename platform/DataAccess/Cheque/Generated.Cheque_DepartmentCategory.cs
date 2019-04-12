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
	/// This object represents the properties and methods of a Cheque_DepartmentCategory.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_DepartmentCategory 
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
		private string _departmentCategoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DepartmentCategoryName
		{
			[DebuggerStepThrough()]
			get { return this._departmentCategoryName; }
			set 
			{
				if (this._departmentCategoryName != value) 
				{
					this._departmentCategoryName = value;
					this.IsDirty = true;	
					OnPropertyChanged("DepartmentCategoryName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _departmentCategoryNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DepartmentCategoryNumber
		{
			[DebuggerStepThrough()]
			get { return this._departmentCategoryNumber; }
			set 
			{
				if (this._departmentCategoryNumber != value) 
				{
					this._departmentCategoryNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("DepartmentCategoryNumber");
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
	[DepartmentCategoryName] nvarchar(200),
	[DepartmentCategoryNumber] nvarchar(200)
);

INSERT INTO [dbo].[Cheque_DepartmentCategory] (
	[Cheque_DepartmentCategory].[DepartmentCategoryName],
	[Cheque_DepartmentCategory].[DepartmentCategoryNumber]
) 
output 
	INSERTED.[ID],
	INSERTED.[DepartmentCategoryName],
	INSERTED.[DepartmentCategoryNumber]
into @table
VALUES ( 
	@DepartmentCategoryName,
	@DepartmentCategoryNumber 
); 

SELECT 
	[ID],
	[DepartmentCategoryName],
	[DepartmentCategoryNumber] 
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
	[DepartmentCategoryName] nvarchar(200),
	[DepartmentCategoryNumber] nvarchar(200)
);

UPDATE [dbo].[Cheque_DepartmentCategory] SET 
	[Cheque_DepartmentCategory].[DepartmentCategoryName] = @DepartmentCategoryName,
	[Cheque_DepartmentCategory].[DepartmentCategoryNumber] = @DepartmentCategoryNumber 
output 
	INSERTED.[ID],
	INSERTED.[DepartmentCategoryName],
	INSERTED.[DepartmentCategoryNumber]
into @table
WHERE 
	[Cheque_DepartmentCategory].[ID] = @ID

SELECT 
	[ID],
	[DepartmentCategoryName],
	[DepartmentCategoryNumber] 
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
DELETE FROM [dbo].[Cheque_DepartmentCategory]
WHERE 
	[Cheque_DepartmentCategory].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_DepartmentCategory() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_DepartmentCategory(this.ID));
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
	[Cheque_DepartmentCategory].[ID],
	[Cheque_DepartmentCategory].[DepartmentCategoryName],
	[Cheque_DepartmentCategory].[DepartmentCategoryNumber]
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
                return "Cheque_DepartmentCategory";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_DepartmentCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="departmentCategoryName">departmentCategoryName</param>
		/// <param name="departmentCategoryNumber">departmentCategoryNumber</param>
		public static void InsertCheque_DepartmentCategory(string @departmentCategoryName, string @departmentCategoryNumber)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_DepartmentCategory(@departmentCategoryName, @departmentCategoryNumber, helper);
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
		/// Insert a Cheque_DepartmentCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="departmentCategoryName">departmentCategoryName</param>
		/// <param name="departmentCategoryNumber">departmentCategoryNumber</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_DepartmentCategory(string @departmentCategoryName, string @departmentCategoryNumber, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DepartmentCategoryName] nvarchar(200),
	[DepartmentCategoryNumber] nvarchar(200)
);

INSERT INTO [dbo].[Cheque_DepartmentCategory] (
	[Cheque_DepartmentCategory].[DepartmentCategoryName],
	[Cheque_DepartmentCategory].[DepartmentCategoryNumber]
) 
output 
	INSERTED.[ID],
	INSERTED.[DepartmentCategoryName],
	INSERTED.[DepartmentCategoryNumber]
into @table
VALUES ( 
	@DepartmentCategoryName,
	@DepartmentCategoryNumber 
); 

SELECT 
	[ID],
	[DepartmentCategoryName],
	[DepartmentCategoryNumber] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DepartmentCategoryName", EntityBase.GetDatabaseValue(@departmentCategoryName)));
			parameters.Add(new SqlParameter("@DepartmentCategoryNumber", EntityBase.GetDatabaseValue(@departmentCategoryNumber)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_DepartmentCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="departmentCategoryName">departmentCategoryName</param>
		/// <param name="departmentCategoryNumber">departmentCategoryNumber</param>
		public static void UpdateCheque_DepartmentCategory(int @iD, string @departmentCategoryName, string @departmentCategoryNumber)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_DepartmentCategory(@iD, @departmentCategoryName, @departmentCategoryNumber, helper);
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
		/// Updates a Cheque_DepartmentCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="departmentCategoryName">departmentCategoryName</param>
		/// <param name="departmentCategoryNumber">departmentCategoryNumber</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_DepartmentCategory(int @iD, string @departmentCategoryName, string @departmentCategoryNumber, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DepartmentCategoryName] nvarchar(200),
	[DepartmentCategoryNumber] nvarchar(200)
);

UPDATE [dbo].[Cheque_DepartmentCategory] SET 
	[Cheque_DepartmentCategory].[DepartmentCategoryName] = @DepartmentCategoryName,
	[Cheque_DepartmentCategory].[DepartmentCategoryNumber] = @DepartmentCategoryNumber 
output 
	INSERTED.[ID],
	INSERTED.[DepartmentCategoryName],
	INSERTED.[DepartmentCategoryNumber]
into @table
WHERE 
	[Cheque_DepartmentCategory].[ID] = @ID

SELECT 
	[ID],
	[DepartmentCategoryName],
	[DepartmentCategoryNumber] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@DepartmentCategoryName", EntityBase.GetDatabaseValue(@departmentCategoryName)));
			parameters.Add(new SqlParameter("@DepartmentCategoryNumber", EntityBase.GetDatabaseValue(@departmentCategoryNumber)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_DepartmentCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_DepartmentCategory(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_DepartmentCategory(@iD, helper);
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
		/// Deletes a Cheque_DepartmentCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_DepartmentCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_DepartmentCategory]
WHERE 
	[Cheque_DepartmentCategory].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_DepartmentCategory object.
		/// </summary>
		/// <returns>The newly created Cheque_DepartmentCategory object.</returns>
		public static Cheque_DepartmentCategory CreateCheque_DepartmentCategory()
		{
			return InitializeNew<Cheque_DepartmentCategory>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_DepartmentCategory by a Cheque_DepartmentCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_DepartmentCategory</returns>
		public static Cheque_DepartmentCategory GetCheque_DepartmentCategory(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_DepartmentCategory.SelectFieldList + @"
FROM [dbo].[Cheque_DepartmentCategory] 
WHERE 
	[Cheque_DepartmentCategory].[ID] = @ID " + Cheque_DepartmentCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_DepartmentCategory>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_DepartmentCategory by a Cheque_DepartmentCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_DepartmentCategory</returns>
		public static Cheque_DepartmentCategory GetCheque_DepartmentCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_DepartmentCategory.SelectFieldList + @"
FROM [dbo].[Cheque_DepartmentCategory] 
WHERE 
	[Cheque_DepartmentCategory].[ID] = @ID " + Cheque_DepartmentCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_DepartmentCategory>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_DepartmentCategory objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_DepartmentCategory objects.</returns>
		public static EntityList<Cheque_DepartmentCategory> GetCheque_DepartmentCategories()
		{
			string commandText = @"
SELECT " + Cheque_DepartmentCategory.SelectFieldList + "FROM [dbo].[Cheque_DepartmentCategory] " + Cheque_DepartmentCategory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_DepartmentCategory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_DepartmentCategory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_DepartmentCategory objects.</returns>
        public static EntityList<Cheque_DepartmentCategory> GetCheque_DepartmentCategories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_DepartmentCategory>(SelectFieldList, "FROM [dbo].[Cheque_DepartmentCategory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_DepartmentCategory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_DepartmentCategory objects.</returns>
        public static EntityList<Cheque_DepartmentCategory> GetCheque_DepartmentCategories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_DepartmentCategory>(SelectFieldList, "FROM [dbo].[Cheque_DepartmentCategory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_DepartmentCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_DepartmentCategory objects.</returns>
		protected static EntityList<Cheque_DepartmentCategory> GetCheque_DepartmentCategories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_DepartmentCategories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_DepartmentCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_DepartmentCategory objects.</returns>
		protected static EntityList<Cheque_DepartmentCategory> GetCheque_DepartmentCategories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_DepartmentCategories(string.Empty, where, parameters, Cheque_DepartmentCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_DepartmentCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_DepartmentCategory objects.</returns>
		protected static EntityList<Cheque_DepartmentCategory> GetCheque_DepartmentCategories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_DepartmentCategories(prefix, where, parameters, Cheque_DepartmentCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_DepartmentCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_DepartmentCategory objects.</returns>
		protected static EntityList<Cheque_DepartmentCategory> GetCheque_DepartmentCategories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_DepartmentCategories(string.Empty, where, parameters, Cheque_DepartmentCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_DepartmentCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_DepartmentCategory objects.</returns>
		protected static EntityList<Cheque_DepartmentCategory> GetCheque_DepartmentCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_DepartmentCategories(prefix, where, parameters, Cheque_DepartmentCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_DepartmentCategory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_DepartmentCategory objects.</returns>
		protected static EntityList<Cheque_DepartmentCategory> GetCheque_DepartmentCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_DepartmentCategory.SelectFieldList + "FROM [dbo].[Cheque_DepartmentCategory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_DepartmentCategory>(reader);
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
        protected static EntityList<Cheque_DepartmentCategory> GetCheque_DepartmentCategories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_DepartmentCategory>(SelectFieldList, "FROM [dbo].[Cheque_DepartmentCategory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_DepartmentCategory objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_DepartmentCategoryCount()
        {
            return GetCheque_DepartmentCategoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_DepartmentCategory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_DepartmentCategoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_DepartmentCategory] " + where;

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
		public static partial class Cheque_DepartmentCategory_Properties
		{
			public const string ID = "ID";
			public const string DepartmentCategoryName = "DepartmentCategoryName";
			public const string DepartmentCategoryNumber = "DepartmentCategoryNumber";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"DepartmentCategoryName" , "string:"},
    			 {"DepartmentCategoryNumber" , "string:"},
            };
		}
		#endregion
	}
}
