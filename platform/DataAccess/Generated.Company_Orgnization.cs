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
	/// This object represents the properties and methods of a Company_Orgnization.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Company_Orgnization 
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
		private string _orgnizationName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string OrgnizationName
		{
			[DebuggerStepThrough()]
			get { return this._orgnizationName; }
			set 
			{
				if (this._orgnizationName != value) 
				{
					this._orgnizationName = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrgnizationName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _parentID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ParentID
		{
			[DebuggerStepThrough()]
			get { return this._parentID; }
			set 
			{
				if (this._parentID != value) 
				{
					this._parentID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ParentID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _addTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime AddTime
		{
			[DebuggerStepThrough()]
			get { return this._addTime; }
			set 
			{
				if (this._addTime != value) 
				{
					this._addTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddMan
		{
			[DebuggerStepThrough()]
			get { return this._addMan; }
			set 
			{
				if (this._addMan != value) 
				{
					this._addMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddMan");
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
		[DataObjectField(false, false, true)]
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
	[OrgnizationName] nvarchar(200),
	[ParentID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[CompanyID] int
);

INSERT INTO [dbo].[Company_Orgnization] (
	[Company_Orgnization].[OrgnizationName],
	[Company_Orgnization].[ParentID],
	[Company_Orgnization].[AddTime],
	[Company_Orgnization].[AddMan],
	[Company_Orgnization].[CompanyID]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrgnizationName],
	INSERTED.[ParentID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[CompanyID]
into @table
VALUES ( 
	@OrgnizationName,
	@ParentID,
	@AddTime,
	@AddMan,
	@CompanyID 
); 

SELECT 
	[ID],
	[OrgnizationName],
	[ParentID],
	[AddTime],
	[AddMan],
	[CompanyID] 
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
	[OrgnizationName] nvarchar(200),
	[ParentID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[CompanyID] int
);

UPDATE [dbo].[Company_Orgnization] SET 
	[Company_Orgnization].[OrgnizationName] = @OrgnizationName,
	[Company_Orgnization].[ParentID] = @ParentID,
	[Company_Orgnization].[AddTime] = @AddTime,
	[Company_Orgnization].[AddMan] = @AddMan,
	[Company_Orgnization].[CompanyID] = @CompanyID 
output 
	INSERTED.[ID],
	INSERTED.[OrgnizationName],
	INSERTED.[ParentID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[CompanyID]
into @table
WHERE 
	[Company_Orgnization].[ID] = @ID

SELECT 
	[ID],
	[OrgnizationName],
	[ParentID],
	[AddTime],
	[AddMan],
	[CompanyID] 
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
DELETE FROM [dbo].[Company_Orgnization]
WHERE 
	[Company_Orgnization].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Company_Orgnization() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCompany_Orgnization(this.ID));
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
	[Company_Orgnization].[ID],
	[Company_Orgnization].[OrgnizationName],
	[Company_Orgnization].[ParentID],
	[Company_Orgnization].[AddTime],
	[Company_Orgnization].[AddMan],
	[Company_Orgnization].[CompanyID]
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
                return "Company_Orgnization";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Company_Orgnization into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orgnizationName">orgnizationName</param>
		/// <param name="parentID">parentID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="companyID">companyID</param>
		public static void InsertCompany_Orgnization(string @orgnizationName, int @parentID, DateTime @addTime, string @addMan, int @companyID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCompany_Orgnization(@orgnizationName, @parentID, @addTime, @addMan, @companyID, helper);
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
		/// Insert a Company_Orgnization into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orgnizationName">orgnizationName</param>
		/// <param name="parentID">parentID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="companyID">companyID</param>
		/// <param name="helper">helper</param>
		internal static void InsertCompany_Orgnization(string @orgnizationName, int @parentID, DateTime @addTime, string @addMan, int @companyID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrgnizationName] nvarchar(200),
	[ParentID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[CompanyID] int
);

INSERT INTO [dbo].[Company_Orgnization] (
	[Company_Orgnization].[OrgnizationName],
	[Company_Orgnization].[ParentID],
	[Company_Orgnization].[AddTime],
	[Company_Orgnization].[AddMan],
	[Company_Orgnization].[CompanyID]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrgnizationName],
	INSERTED.[ParentID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[CompanyID]
into @table
VALUES ( 
	@OrgnizationName,
	@ParentID,
	@AddTime,
	@AddMan,
	@CompanyID 
); 

SELECT 
	[ID],
	[OrgnizationName],
	[ParentID],
	[AddTime],
	[AddMan],
	[CompanyID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OrgnizationName", EntityBase.GetDatabaseValue(@orgnizationName)));
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Company_Orgnization into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orgnizationName">orgnizationName</param>
		/// <param name="parentID">parentID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="companyID">companyID</param>
		public static void UpdateCompany_Orgnization(int @iD, string @orgnizationName, int @parentID, DateTime @addTime, string @addMan, int @companyID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCompany_Orgnization(@iD, @orgnizationName, @parentID, @addTime, @addMan, @companyID, helper);
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
		/// Updates a Company_Orgnization into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orgnizationName">orgnizationName</param>
		/// <param name="parentID">parentID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="companyID">companyID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCompany_Orgnization(int @iD, string @orgnizationName, int @parentID, DateTime @addTime, string @addMan, int @companyID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrgnizationName] nvarchar(200),
	[ParentID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[CompanyID] int
);

UPDATE [dbo].[Company_Orgnization] SET 
	[Company_Orgnization].[OrgnizationName] = @OrgnizationName,
	[Company_Orgnization].[ParentID] = @ParentID,
	[Company_Orgnization].[AddTime] = @AddTime,
	[Company_Orgnization].[AddMan] = @AddMan,
	[Company_Orgnization].[CompanyID] = @CompanyID 
output 
	INSERTED.[ID],
	INSERTED.[OrgnizationName],
	INSERTED.[ParentID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[CompanyID]
into @table
WHERE 
	[Company_Orgnization].[ID] = @ID

SELECT 
	[ID],
	[OrgnizationName],
	[ParentID],
	[AddTime],
	[AddMan],
	[CompanyID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OrgnizationName", EntityBase.GetDatabaseValue(@orgnizationName)));
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Company_Orgnization from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCompany_Orgnization(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCompany_Orgnization(@iD, helper);
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
		/// Deletes a Company_Orgnization from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCompany_Orgnization(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Company_Orgnization]
WHERE 
	[Company_Orgnization].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Company_Orgnization object.
		/// </summary>
		/// <returns>The newly created Company_Orgnization object.</returns>
		public static Company_Orgnization CreateCompany_Orgnization()
		{
			return InitializeNew<Company_Orgnization>();
		}
		
		/// <summary>
		/// Retrieve information for a Company_Orgnization by a Company_Orgnization's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Company_Orgnization</returns>
		public static Company_Orgnization GetCompany_Orgnization(int @iD)
		{
			string commandText = @"
SELECT 
" + Company_Orgnization.SelectFieldList + @"
FROM [dbo].[Company_Orgnization] 
WHERE 
	[Company_Orgnization].[ID] = @ID " + Company_Orgnization.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Company_Orgnization>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Company_Orgnization by a Company_Orgnization's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Company_Orgnization</returns>
		public static Company_Orgnization GetCompany_Orgnization(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Company_Orgnization.SelectFieldList + @"
FROM [dbo].[Company_Orgnization] 
WHERE 
	[Company_Orgnization].[ID] = @ID " + Company_Orgnization.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Company_Orgnization>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Company_Orgnization objects.
		/// </summary>
		/// <returns>The retrieved collection of Company_Orgnization objects.</returns>
		public static EntityList<Company_Orgnization> GetCompany_Orgnizations()
		{
			string commandText = @"
SELECT " + Company_Orgnization.SelectFieldList + "FROM [dbo].[Company_Orgnization] " + Company_Orgnization.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Company_Orgnization>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Company_Orgnization objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Company_Orgnization objects.</returns>
        public static EntityList<Company_Orgnization> GetCompany_Orgnizations(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Company_Orgnization>(SelectFieldList, "FROM [dbo].[Company_Orgnization]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Company_Orgnization objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Company_Orgnization objects.</returns>
        public static EntityList<Company_Orgnization> GetCompany_Orgnizations(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Company_Orgnization>(SelectFieldList, "FROM [dbo].[Company_Orgnization]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Company_Orgnization objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Company_Orgnization objects.</returns>
		protected static EntityList<Company_Orgnization> GetCompany_Orgnizations(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCompany_Orgnizations(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Company_Orgnization objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Company_Orgnization objects.</returns>
		protected static EntityList<Company_Orgnization> GetCompany_Orgnizations(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCompany_Orgnizations(string.Empty, where, parameters, Company_Orgnization.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Company_Orgnization objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Company_Orgnization objects.</returns>
		protected static EntityList<Company_Orgnization> GetCompany_Orgnizations(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCompany_Orgnizations(prefix, where, parameters, Company_Orgnization.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Company_Orgnization objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Company_Orgnization objects.</returns>
		protected static EntityList<Company_Orgnization> GetCompany_Orgnizations(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCompany_Orgnizations(string.Empty, where, parameters, Company_Orgnization.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Company_Orgnization objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Company_Orgnization objects.</returns>
		protected static EntityList<Company_Orgnization> GetCompany_Orgnizations(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCompany_Orgnizations(prefix, where, parameters, Company_Orgnization.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Company_Orgnization objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Company_Orgnization objects.</returns>
		protected static EntityList<Company_Orgnization> GetCompany_Orgnizations(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Company_Orgnization.SelectFieldList + "FROM [dbo].[Company_Orgnization] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Company_Orgnization>(reader);
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
        protected static EntityList<Company_Orgnization> GetCompany_Orgnizations(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Company_Orgnization>(SelectFieldList, "FROM [dbo].[Company_Orgnization] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Company_Orgnization objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCompany_OrgnizationCount()
        {
            return GetCompany_OrgnizationCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Company_Orgnization objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCompany_OrgnizationCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Company_Orgnization] " + where;

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
		public static partial class Company_Orgnization_Properties
		{
			public const string ID = "ID";
			public const string OrgnizationName = "OrgnizationName";
			public const string ParentID = "ParentID";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string CompanyID = "CompanyID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OrgnizationName" , "string:"},
    			 {"ParentID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"CompanyID" , "int:"},
            };
		}
		#endregion
	}
}
