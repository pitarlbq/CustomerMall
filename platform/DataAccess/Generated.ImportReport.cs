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
	/// This object represents the properties and methods of a ImportReport.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ImportReport 
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
		private string _path = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Path
		{
			[DebuggerStepThrough()]
			get { return this._path; }
			set 
			{
				if (this._path != value) 
				{
					this._path = value;
					this.IsDirty = true;	
					OnPropertyChanged("Path");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _importTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ImportTime
		{
			[DebuggerStepThrough()]
			get { return this._importTime; }
			set 
			{
				if (this._importTime != value) 
				{
					this._importTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ImportTime");
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
		private string _importResult = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ImportResult
		{
			[DebuggerStepThrough()]
			get { return this._importResult; }
			set 
			{
				if (this._importResult != value) 
				{
					this._importResult = value;
					this.IsDirty = true;	
					OnPropertyChanged("ImportResult");
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
	[Path] nvarchar(500),
	[ImportTime] datetime,
	[AddMan] nvarchar(50),
	[ImportResult] ntext
);

INSERT INTO [dbo].[ImportReport] (
	[ImportReport].[Path],
	[ImportReport].[ImportTime],
	[ImportReport].[AddMan],
	[ImportReport].[ImportResult]
) 
output 
	INSERTED.[ID],
	INSERTED.[Path],
	INSERTED.[ImportTime],
	INSERTED.[AddMan],
	INSERTED.[ImportResult]
into @table
VALUES ( 
	@Path,
	@ImportTime,
	@AddMan,
	@ImportResult 
); 

SELECT 
	[ID],
	[Path],
	[ImportTime],
	[AddMan],
	[ImportResult] 
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
	[Path] nvarchar(500),
	[ImportTime] datetime,
	[AddMan] nvarchar(50),
	[ImportResult] ntext
);

UPDATE [dbo].[ImportReport] SET 
	[ImportReport].[Path] = @Path,
	[ImportReport].[ImportTime] = @ImportTime,
	[ImportReport].[AddMan] = @AddMan,
	[ImportReport].[ImportResult] = @ImportResult 
output 
	INSERTED.[ID],
	INSERTED.[Path],
	INSERTED.[ImportTime],
	INSERTED.[AddMan],
	INSERTED.[ImportResult]
into @table
WHERE 
	[ImportReport].[ID] = @ID

SELECT 
	[ID],
	[Path],
	[ImportTime],
	[AddMan],
	[ImportResult] 
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
DELETE FROM [dbo].[ImportReport]
WHERE 
	[ImportReport].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ImportReport() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetImportReport(this.ID));
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
	[ImportReport].[ID],
	[ImportReport].[Path],
	[ImportReport].[ImportTime],
	[ImportReport].[AddMan],
	[ImportReport].[ImportResult]
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
                return "ImportReport";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ImportReport into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="path">path</param>
		/// <param name="importTime">importTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="importResult">importResult</param>
		public static void InsertImportReport(string @path, DateTime @importTime, string @addMan, string @importResult)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertImportReport(@path, @importTime, @addMan, @importResult, helper);
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
		/// Insert a ImportReport into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="path">path</param>
		/// <param name="importTime">importTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="importResult">importResult</param>
		/// <param name="helper">helper</param>
		internal static void InsertImportReport(string @path, DateTime @importTime, string @addMan, string @importResult, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Path] nvarchar(500),
	[ImportTime] datetime,
	[AddMan] nvarchar(50),
	[ImportResult] ntext
);

INSERT INTO [dbo].[ImportReport] (
	[ImportReport].[Path],
	[ImportReport].[ImportTime],
	[ImportReport].[AddMan],
	[ImportReport].[ImportResult]
) 
output 
	INSERTED.[ID],
	INSERTED.[Path],
	INSERTED.[ImportTime],
	INSERTED.[AddMan],
	INSERTED.[ImportResult]
into @table
VALUES ( 
	@Path,
	@ImportTime,
	@AddMan,
	@ImportResult 
); 

SELECT 
	[ID],
	[Path],
	[ImportTime],
	[AddMan],
	[ImportResult] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Path", EntityBase.GetDatabaseValue(@path)));
			parameters.Add(new SqlParameter("@ImportTime", EntityBase.GetDatabaseValue(@importTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ImportResult", EntityBase.GetDatabaseValue(@importResult)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ImportReport into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="path">path</param>
		/// <param name="importTime">importTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="importResult">importResult</param>
		public static void UpdateImportReport(int @iD, string @path, DateTime @importTime, string @addMan, string @importResult)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateImportReport(@iD, @path, @importTime, @addMan, @importResult, helper);
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
		/// Updates a ImportReport into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="path">path</param>
		/// <param name="importTime">importTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="importResult">importResult</param>
		/// <param name="helper">helper</param>
		internal static void UpdateImportReport(int @iD, string @path, DateTime @importTime, string @addMan, string @importResult, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Path] nvarchar(500),
	[ImportTime] datetime,
	[AddMan] nvarchar(50),
	[ImportResult] ntext
);

UPDATE [dbo].[ImportReport] SET 
	[ImportReport].[Path] = @Path,
	[ImportReport].[ImportTime] = @ImportTime,
	[ImportReport].[AddMan] = @AddMan,
	[ImportReport].[ImportResult] = @ImportResult 
output 
	INSERTED.[ID],
	INSERTED.[Path],
	INSERTED.[ImportTime],
	INSERTED.[AddMan],
	INSERTED.[ImportResult]
into @table
WHERE 
	[ImportReport].[ID] = @ID

SELECT 
	[ID],
	[Path],
	[ImportTime],
	[AddMan],
	[ImportResult] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Path", EntityBase.GetDatabaseValue(@path)));
			parameters.Add(new SqlParameter("@ImportTime", EntityBase.GetDatabaseValue(@importTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ImportResult", EntityBase.GetDatabaseValue(@importResult)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ImportReport from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteImportReport(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteImportReport(@iD, helper);
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
		/// Deletes a ImportReport from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteImportReport(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ImportReport]
WHERE 
	[ImportReport].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ImportReport object.
		/// </summary>
		/// <returns>The newly created ImportReport object.</returns>
		public static ImportReport CreateImportReport()
		{
			return InitializeNew<ImportReport>();
		}
		
		/// <summary>
		/// Retrieve information for a ImportReport by a ImportReport's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ImportReport</returns>
		public static ImportReport GetImportReport(int @iD)
		{
			string commandText = @"
SELECT 
" + ImportReport.SelectFieldList + @"
FROM [dbo].[ImportReport] 
WHERE 
	[ImportReport].[ID] = @ID " + ImportReport.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ImportReport>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ImportReport by a ImportReport's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ImportReport</returns>
		public static ImportReport GetImportReport(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ImportReport.SelectFieldList + @"
FROM [dbo].[ImportReport] 
WHERE 
	[ImportReport].[ID] = @ID " + ImportReport.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ImportReport>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ImportReport objects.
		/// </summary>
		/// <returns>The retrieved collection of ImportReport objects.</returns>
		public static EntityList<ImportReport> GetImportReports()
		{
			string commandText = @"
SELECT " + ImportReport.SelectFieldList + "FROM [dbo].[ImportReport] " + ImportReport.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ImportReport>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ImportReport objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ImportReport objects.</returns>
        public static EntityList<ImportReport> GetImportReports(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ImportReport>(SelectFieldList, "FROM [dbo].[ImportReport]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ImportReport objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ImportReport objects.</returns>
        public static EntityList<ImportReport> GetImportReports(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ImportReport>(SelectFieldList, "FROM [dbo].[ImportReport]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ImportReport objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ImportReport objects.</returns>
		protected static EntityList<ImportReport> GetImportReports(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetImportReports(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ImportReport objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ImportReport objects.</returns>
		protected static EntityList<ImportReport> GetImportReports(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetImportReports(string.Empty, where, parameters, ImportReport.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ImportReport objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ImportReport objects.</returns>
		protected static EntityList<ImportReport> GetImportReports(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetImportReports(prefix, where, parameters, ImportReport.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ImportReport objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ImportReport objects.</returns>
		protected static EntityList<ImportReport> GetImportReports(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetImportReports(string.Empty, where, parameters, ImportReport.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ImportReport objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ImportReport objects.</returns>
		protected static EntityList<ImportReport> GetImportReports(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetImportReports(prefix, where, parameters, ImportReport.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ImportReport objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ImportReport objects.</returns>
		protected static EntityList<ImportReport> GetImportReports(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ImportReport.SelectFieldList + "FROM [dbo].[ImportReport] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ImportReport>(reader);
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
        protected static EntityList<ImportReport> GetImportReports(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ImportReport>(SelectFieldList, "FROM [dbo].[ImportReport] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class ImportReportProperties
		{
			public const string ID = "ID";
			public const string Path = "Path";
			public const string ImportTime = "ImportTime";
			public const string AddMan = "AddMan";
			public const string ImportResult = "ImportResult";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Path" , "string:"},
    			 {"ImportTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"ImportResult" , "string:"},
            };
		}
		#endregion
	}
}
