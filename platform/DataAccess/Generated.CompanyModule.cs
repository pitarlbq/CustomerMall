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
	/// This object represents the properties and methods of a CompanyModule.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CompanyModule 
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
		private int _companyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int CompanyID
		{
			[DebuggerStepThrough()]
			get { return this._companyID; }
			set 
			{
				if (this._companyID != value) 
				{
					this._companyID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CompanyID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _moduleId = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ModuleId
		{
			[DebuggerStepThrough()]
			get { return this._moduleId; }
			set 
			{
				if (this._moduleId != value) 
				{
					this._moduleId = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModuleId");
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
	[CompanyID] int,
	[ModuleId] int
);

INSERT INTO [dbo].[CompanyModule] (
	[CompanyModule].[CompanyID],
	[CompanyModule].[ModuleId]
) 
output 
	INSERTED.[ID],
	INSERTED.[CompanyID],
	INSERTED.[ModuleId]
into @table
VALUES ( 
	@CompanyID,
	@ModuleId 
); 

SELECT 
	[ID],
	[CompanyID],
	[ModuleId] 
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
	[CompanyID] int,
	[ModuleId] int
);

UPDATE [dbo].[CompanyModule] SET 
	[CompanyModule].[CompanyID] = @CompanyID,
	[CompanyModule].[ModuleId] = @ModuleId 
output 
	INSERTED.[ID],
	INSERTED.[CompanyID],
	INSERTED.[ModuleId]
into @table
WHERE 
	[CompanyModule].[ID] = @ID

SELECT 
	[ID],
	[CompanyID],
	[ModuleId] 
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
DELETE FROM [dbo].[CompanyModule]
WHERE 
	[CompanyModule].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CompanyModule() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCompanyModule(this.ID));
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
	[CompanyModule].[ID],
	[CompanyModule].[CompanyID],
	[CompanyModule].[ModuleId]
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
                return "CompanyModule";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CompanyModule into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="moduleId">moduleId</param>
		public static void InsertCompanyModule(int @companyID, int @moduleId)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCompanyModule(@companyID, @moduleId, helper);
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
		/// Insert a CompanyModule into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="moduleId">moduleId</param>
		/// <param name="helper">helper</param>
		internal static void InsertCompanyModule(int @companyID, int @moduleId, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CompanyID] int,
	[ModuleId] int
);

INSERT INTO [dbo].[CompanyModule] (
	[CompanyModule].[CompanyID],
	[CompanyModule].[ModuleId]
) 
output 
	INSERTED.[ID],
	INSERTED.[CompanyID],
	INSERTED.[ModuleId]
into @table
VALUES ( 
	@CompanyID,
	@ModuleId 
); 

SELECT 
	[ID],
	[CompanyID],
	[ModuleId] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			parameters.Add(new SqlParameter("@ModuleId", EntityBase.GetDatabaseValue(@moduleId)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CompanyModule into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="companyID">companyID</param>
		/// <param name="moduleId">moduleId</param>
		public static void UpdateCompanyModule(int @iD, int @companyID, int @moduleId)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCompanyModule(@iD, @companyID, @moduleId, helper);
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
		/// Updates a CompanyModule into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="companyID">companyID</param>
		/// <param name="moduleId">moduleId</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCompanyModule(int @iD, int @companyID, int @moduleId, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CompanyID] int,
	[ModuleId] int
);

UPDATE [dbo].[CompanyModule] SET 
	[CompanyModule].[CompanyID] = @CompanyID,
	[CompanyModule].[ModuleId] = @ModuleId 
output 
	INSERTED.[ID],
	INSERTED.[CompanyID],
	INSERTED.[ModuleId]
into @table
WHERE 
	[CompanyModule].[ID] = @ID

SELECT 
	[ID],
	[CompanyID],
	[ModuleId] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			parameters.Add(new SqlParameter("@ModuleId", EntityBase.GetDatabaseValue(@moduleId)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CompanyModule from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCompanyModule(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCompanyModule(@iD, helper);
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
		/// Deletes a CompanyModule from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCompanyModule(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CompanyModule]
WHERE 
	[CompanyModule].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CompanyModule object.
		/// </summary>
		/// <returns>The newly created CompanyModule object.</returns>
		public static CompanyModule CreateCompanyModule()
		{
			return InitializeNew<CompanyModule>();
		}
		
		/// <summary>
		/// Retrieve information for a CompanyModule by a CompanyModule's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CompanyModule</returns>
		public static CompanyModule GetCompanyModule(int @iD)
		{
			string commandText = @"
SELECT 
" + CompanyModule.SelectFieldList + @"
FROM [dbo].[CompanyModule] 
WHERE 
	[CompanyModule].[ID] = @ID " + CompanyModule.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CompanyModule>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CompanyModule by a CompanyModule's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CompanyModule</returns>
		public static CompanyModule GetCompanyModule(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CompanyModule.SelectFieldList + @"
FROM [dbo].[CompanyModule] 
WHERE 
	[CompanyModule].[ID] = @ID " + CompanyModule.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CompanyModule>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CompanyModule objects.
		/// </summary>
		/// <returns>The retrieved collection of CompanyModule objects.</returns>
		public static EntityList<CompanyModule> GetCompanyModules()
		{
			string commandText = @"
SELECT " + CompanyModule.SelectFieldList + "FROM [dbo].[CompanyModule] " + CompanyModule.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CompanyModule>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CompanyModule objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CompanyModule objects.</returns>
        public static EntityList<CompanyModule> GetCompanyModules(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CompanyModule>(SelectFieldList, "FROM [dbo].[CompanyModule]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CompanyModule objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CompanyModule objects.</returns>
        public static EntityList<CompanyModule> GetCompanyModules(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CompanyModule>(SelectFieldList, "FROM [dbo].[CompanyModule]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CompanyModule objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CompanyModule objects.</returns>
		protected static EntityList<CompanyModule> GetCompanyModules(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCompanyModules(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CompanyModule objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CompanyModule objects.</returns>
		protected static EntityList<CompanyModule> GetCompanyModules(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCompanyModules(string.Empty, where, parameters, CompanyModule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CompanyModule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CompanyModule objects.</returns>
		protected static EntityList<CompanyModule> GetCompanyModules(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCompanyModules(prefix, where, parameters, CompanyModule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CompanyModule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CompanyModule objects.</returns>
		protected static EntityList<CompanyModule> GetCompanyModules(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCompanyModules(string.Empty, where, parameters, CompanyModule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CompanyModule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CompanyModule objects.</returns>
		protected static EntityList<CompanyModule> GetCompanyModules(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCompanyModules(prefix, where, parameters, CompanyModule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CompanyModule objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CompanyModule objects.</returns>
		protected static EntityList<CompanyModule> GetCompanyModules(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CompanyModule.SelectFieldList + "FROM [dbo].[CompanyModule] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CompanyModule>(reader);
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
        protected static EntityList<CompanyModule> GetCompanyModules(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CompanyModule>(SelectFieldList, "FROM [dbo].[CompanyModule] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CompanyModule objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCompanyModuleCount()
        {
            return GetCompanyModuleCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CompanyModule objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCompanyModuleCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CompanyModule] " + where;

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
		public static partial class CompanyModule_Properties
		{
			public const string ID = "ID";
			public const string CompanyID = "CompanyID";
			public const string ModuleId = "ModuleId";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CompanyID" , "int:"},
    			 {"ModuleId" , "int:"},
            };
		}
		#endregion
	}
}
