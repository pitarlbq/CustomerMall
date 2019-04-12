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
	/// This object represents the properties and methods of a Cheque_ProjectCategory.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_ProjectCategory 
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
		private string _projectCategoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProjectCategoryName
		{
			[DebuggerStepThrough()]
			get { return this._projectCategoryName; }
			set 
			{
				if (this._projectCategoryName != value) 
				{
					this._projectCategoryName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectCategoryName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _projectCategoryNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProjectCategoryNumber
		{
			[DebuggerStepThrough()]
			get { return this._projectCategoryNumber; }
			set 
			{
				if (this._projectCategoryNumber != value) 
				{
					this._projectCategoryNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectCategoryNumber");
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
	[ProjectCategoryName] nvarchar(200),
	[ProjectCategoryNumber] nvarchar(200)
);

INSERT INTO [dbo].[Cheque_ProjectCategory] (
	[Cheque_ProjectCategory].[ProjectCategoryName],
	[Cheque_ProjectCategory].[ProjectCategoryNumber]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectCategoryName],
	INSERTED.[ProjectCategoryNumber]
into @table
VALUES ( 
	@ProjectCategoryName,
	@ProjectCategoryNumber 
); 

SELECT 
	[ID],
	[ProjectCategoryName],
	[ProjectCategoryNumber] 
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
	[ProjectCategoryName] nvarchar(200),
	[ProjectCategoryNumber] nvarchar(200)
);

UPDATE [dbo].[Cheque_ProjectCategory] SET 
	[Cheque_ProjectCategory].[ProjectCategoryName] = @ProjectCategoryName,
	[Cheque_ProjectCategory].[ProjectCategoryNumber] = @ProjectCategoryNumber 
output 
	INSERTED.[ID],
	INSERTED.[ProjectCategoryName],
	INSERTED.[ProjectCategoryNumber]
into @table
WHERE 
	[Cheque_ProjectCategory].[ID] = @ID

SELECT 
	[ID],
	[ProjectCategoryName],
	[ProjectCategoryNumber] 
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
DELETE FROM [dbo].[Cheque_ProjectCategory]
WHERE 
	[Cheque_ProjectCategory].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_ProjectCategory() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_ProjectCategory(this.ID));
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
	[Cheque_ProjectCategory].[ID],
	[Cheque_ProjectCategory].[ProjectCategoryName],
	[Cheque_ProjectCategory].[ProjectCategoryNumber]
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
                return "Cheque_ProjectCategory";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_ProjectCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectCategoryName">projectCategoryName</param>
		/// <param name="projectCategoryNumber">projectCategoryNumber</param>
		public static void InsertCheque_ProjectCategory(string @projectCategoryName, string @projectCategoryNumber)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_ProjectCategory(@projectCategoryName, @projectCategoryNumber, helper);
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
		/// Insert a Cheque_ProjectCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectCategoryName">projectCategoryName</param>
		/// <param name="projectCategoryNumber">projectCategoryNumber</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_ProjectCategory(string @projectCategoryName, string @projectCategoryNumber, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectCategoryName] nvarchar(200),
	[ProjectCategoryNumber] nvarchar(200)
);

INSERT INTO [dbo].[Cheque_ProjectCategory] (
	[Cheque_ProjectCategory].[ProjectCategoryName],
	[Cheque_ProjectCategory].[ProjectCategoryNumber]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectCategoryName],
	INSERTED.[ProjectCategoryNumber]
into @table
VALUES ( 
	@ProjectCategoryName,
	@ProjectCategoryNumber 
); 

SELECT 
	[ID],
	[ProjectCategoryName],
	[ProjectCategoryNumber] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectCategoryName", EntityBase.GetDatabaseValue(@projectCategoryName)));
			parameters.Add(new SqlParameter("@ProjectCategoryNumber", EntityBase.GetDatabaseValue(@projectCategoryNumber)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_ProjectCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectCategoryName">projectCategoryName</param>
		/// <param name="projectCategoryNumber">projectCategoryNumber</param>
		public static void UpdateCheque_ProjectCategory(int @iD, string @projectCategoryName, string @projectCategoryNumber)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_ProjectCategory(@iD, @projectCategoryName, @projectCategoryNumber, helper);
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
		/// Updates a Cheque_ProjectCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectCategoryName">projectCategoryName</param>
		/// <param name="projectCategoryNumber">projectCategoryNumber</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_ProjectCategory(int @iD, string @projectCategoryName, string @projectCategoryNumber, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectCategoryName] nvarchar(200),
	[ProjectCategoryNumber] nvarchar(200)
);

UPDATE [dbo].[Cheque_ProjectCategory] SET 
	[Cheque_ProjectCategory].[ProjectCategoryName] = @ProjectCategoryName,
	[Cheque_ProjectCategory].[ProjectCategoryNumber] = @ProjectCategoryNumber 
output 
	INSERTED.[ID],
	INSERTED.[ProjectCategoryName],
	INSERTED.[ProjectCategoryNumber]
into @table
WHERE 
	[Cheque_ProjectCategory].[ID] = @ID

SELECT 
	[ID],
	[ProjectCategoryName],
	[ProjectCategoryNumber] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProjectCategoryName", EntityBase.GetDatabaseValue(@projectCategoryName)));
			parameters.Add(new SqlParameter("@ProjectCategoryNumber", EntityBase.GetDatabaseValue(@projectCategoryNumber)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_ProjectCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_ProjectCategory(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_ProjectCategory(@iD, helper);
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
		/// Deletes a Cheque_ProjectCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_ProjectCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_ProjectCategory]
WHERE 
	[Cheque_ProjectCategory].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_ProjectCategory object.
		/// </summary>
		/// <returns>The newly created Cheque_ProjectCategory object.</returns>
		public static Cheque_ProjectCategory CreateCheque_ProjectCategory()
		{
			return InitializeNew<Cheque_ProjectCategory>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_ProjectCategory by a Cheque_ProjectCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_ProjectCategory</returns>
		public static Cheque_ProjectCategory GetCheque_ProjectCategory(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_ProjectCategory.SelectFieldList + @"
FROM [dbo].[Cheque_ProjectCategory] 
WHERE 
	[Cheque_ProjectCategory].[ID] = @ID " + Cheque_ProjectCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_ProjectCategory>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_ProjectCategory by a Cheque_ProjectCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_ProjectCategory</returns>
		public static Cheque_ProjectCategory GetCheque_ProjectCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_ProjectCategory.SelectFieldList + @"
FROM [dbo].[Cheque_ProjectCategory] 
WHERE 
	[Cheque_ProjectCategory].[ID] = @ID " + Cheque_ProjectCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_ProjectCategory>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_ProjectCategory objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_ProjectCategory objects.</returns>
		public static EntityList<Cheque_ProjectCategory> GetCheque_ProjectCategories()
		{
			string commandText = @"
SELECT " + Cheque_ProjectCategory.SelectFieldList + "FROM [dbo].[Cheque_ProjectCategory] " + Cheque_ProjectCategory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_ProjectCategory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_ProjectCategory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_ProjectCategory objects.</returns>
        public static EntityList<Cheque_ProjectCategory> GetCheque_ProjectCategories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_ProjectCategory>(SelectFieldList, "FROM [dbo].[Cheque_ProjectCategory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_ProjectCategory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_ProjectCategory objects.</returns>
        public static EntityList<Cheque_ProjectCategory> GetCheque_ProjectCategories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_ProjectCategory>(SelectFieldList, "FROM [dbo].[Cheque_ProjectCategory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_ProjectCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_ProjectCategory objects.</returns>
		protected static EntityList<Cheque_ProjectCategory> GetCheque_ProjectCategories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_ProjectCategories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_ProjectCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_ProjectCategory objects.</returns>
		protected static EntityList<Cheque_ProjectCategory> GetCheque_ProjectCategories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_ProjectCategories(string.Empty, where, parameters, Cheque_ProjectCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_ProjectCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_ProjectCategory objects.</returns>
		protected static EntityList<Cheque_ProjectCategory> GetCheque_ProjectCategories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_ProjectCategories(prefix, where, parameters, Cheque_ProjectCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_ProjectCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_ProjectCategory objects.</returns>
		protected static EntityList<Cheque_ProjectCategory> GetCheque_ProjectCategories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_ProjectCategories(string.Empty, where, parameters, Cheque_ProjectCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_ProjectCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_ProjectCategory objects.</returns>
		protected static EntityList<Cheque_ProjectCategory> GetCheque_ProjectCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_ProjectCategories(prefix, where, parameters, Cheque_ProjectCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_ProjectCategory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_ProjectCategory objects.</returns>
		protected static EntityList<Cheque_ProjectCategory> GetCheque_ProjectCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_ProjectCategory.SelectFieldList + "FROM [dbo].[Cheque_ProjectCategory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_ProjectCategory>(reader);
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
        protected static EntityList<Cheque_ProjectCategory> GetCheque_ProjectCategories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_ProjectCategory>(SelectFieldList, "FROM [dbo].[Cheque_ProjectCategory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_ProjectCategory objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_ProjectCategoryCount()
        {
            return GetCheque_ProjectCategoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_ProjectCategory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_ProjectCategoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_ProjectCategory] " + where;

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
		public static partial class Cheque_ProjectCategory_Properties
		{
			public const string ID = "ID";
			public const string ProjectCategoryName = "ProjectCategoryName";
			public const string ProjectCategoryNumber = "ProjectCategoryNumber";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProjectCategoryName" , "string:"},
    			 {"ProjectCategoryNumber" , "string:"},
            };
		}
		#endregion
	}
}
