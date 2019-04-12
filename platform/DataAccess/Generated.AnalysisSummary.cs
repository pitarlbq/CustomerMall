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
	/// This object represents the properties and methods of a AnalysisSummary.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class AnalysisSummary 
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
		private int _pID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int PID
		{
			[DebuggerStepThrough()]
			get { return this._pID; }
			set 
			{
				if (this._pID != value) 
				{
					this._pID = value;
					this.IsDirty = true;	
					OnPropertyChanged("PID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _analysisName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AnalysisName
		{
			[DebuggerStepThrough()]
			get { return this._analysisName; }
			set 
			{
				if (this._analysisName != value) 
				{
					this._analysisName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AnalysisName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _analysisCode = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AnalysisCode
		{
			[DebuggerStepThrough()]
			get { return this._analysisCode; }
			set 
			{
				if (this._analysisCode != value) 
				{
					this._analysisCode = value;
					this.IsDirty = true;	
					OnPropertyChanged("AnalysisCode");
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
	[PID] int,
	[AnalysisName] nvarchar(50),
	[AnalysisCode] nvarchar(50)
);

INSERT INTO [dbo].[AnalysisSummary] (
	[AnalysisSummary].[PID],
	[AnalysisSummary].[AnalysisName],
	[AnalysisSummary].[AnalysisCode]
) 
output 
	INSERTED.[ID],
	INSERTED.[PID],
	INSERTED.[AnalysisName],
	INSERTED.[AnalysisCode]
into @table
VALUES ( 
	@PID,
	@AnalysisName,
	@AnalysisCode 
); 

SELECT 
	[ID],
	[PID],
	[AnalysisName],
	[AnalysisCode] 
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
	[PID] int,
	[AnalysisName] nvarchar(50),
	[AnalysisCode] nvarchar(50)
);

UPDATE [dbo].[AnalysisSummary] SET 
	[AnalysisSummary].[PID] = @PID,
	[AnalysisSummary].[AnalysisName] = @AnalysisName,
	[AnalysisSummary].[AnalysisCode] = @AnalysisCode 
output 
	INSERTED.[ID],
	INSERTED.[PID],
	INSERTED.[AnalysisName],
	INSERTED.[AnalysisCode]
into @table
WHERE 
	[AnalysisSummary].[ID] = @ID

SELECT 
	[ID],
	[PID],
	[AnalysisName],
	[AnalysisCode] 
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
DELETE FROM [dbo].[AnalysisSummary]
WHERE 
	[AnalysisSummary].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public AnalysisSummary() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetAnalysisSummary(this.ID));
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
	[AnalysisSummary].[ID],
	[AnalysisSummary].[PID],
	[AnalysisSummary].[AnalysisName],
	[AnalysisSummary].[AnalysisCode]
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
                return "AnalysisSummary";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a AnalysisSummary into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="pID">pID</param>
		/// <param name="analysisName">analysisName</param>
		/// <param name="analysisCode">analysisCode</param>
		public static void InsertAnalysisSummary(int @pID, string @analysisName, string @analysisCode)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertAnalysisSummary(@pID, @analysisName, @analysisCode, helper);
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
		/// Insert a AnalysisSummary into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="pID">pID</param>
		/// <param name="analysisName">analysisName</param>
		/// <param name="analysisCode">analysisCode</param>
		/// <param name="helper">helper</param>
		internal static void InsertAnalysisSummary(int @pID, string @analysisName, string @analysisCode, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[PID] int,
	[AnalysisName] nvarchar(50),
	[AnalysisCode] nvarchar(50)
);

INSERT INTO [dbo].[AnalysisSummary] (
	[AnalysisSummary].[PID],
	[AnalysisSummary].[AnalysisName],
	[AnalysisSummary].[AnalysisCode]
) 
output 
	INSERTED.[ID],
	INSERTED.[PID],
	INSERTED.[AnalysisName],
	INSERTED.[AnalysisCode]
into @table
VALUES ( 
	@PID,
	@AnalysisName,
	@AnalysisCode 
); 

SELECT 
	[ID],
	[PID],
	[AnalysisName],
	[AnalysisCode] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@PID", EntityBase.GetDatabaseValue(@pID)));
			parameters.Add(new SqlParameter("@AnalysisName", EntityBase.GetDatabaseValue(@analysisName)));
			parameters.Add(new SqlParameter("@AnalysisCode", EntityBase.GetDatabaseValue(@analysisCode)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a AnalysisSummary into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="pID">pID</param>
		/// <param name="analysisName">analysisName</param>
		/// <param name="analysisCode">analysisCode</param>
		public static void UpdateAnalysisSummary(int @iD, int @pID, string @analysisName, string @analysisCode)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateAnalysisSummary(@iD, @pID, @analysisName, @analysisCode, helper);
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
		/// Updates a AnalysisSummary into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="pID">pID</param>
		/// <param name="analysisName">analysisName</param>
		/// <param name="analysisCode">analysisCode</param>
		/// <param name="helper">helper</param>
		internal static void UpdateAnalysisSummary(int @iD, int @pID, string @analysisName, string @analysisCode, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[PID] int,
	[AnalysisName] nvarchar(50),
	[AnalysisCode] nvarchar(50)
);

UPDATE [dbo].[AnalysisSummary] SET 
	[AnalysisSummary].[PID] = @PID,
	[AnalysisSummary].[AnalysisName] = @AnalysisName,
	[AnalysisSummary].[AnalysisCode] = @AnalysisCode 
output 
	INSERTED.[ID],
	INSERTED.[PID],
	INSERTED.[AnalysisName],
	INSERTED.[AnalysisCode]
into @table
WHERE 
	[AnalysisSummary].[ID] = @ID

SELECT 
	[ID],
	[PID],
	[AnalysisName],
	[AnalysisCode] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@PID", EntityBase.GetDatabaseValue(@pID)));
			parameters.Add(new SqlParameter("@AnalysisName", EntityBase.GetDatabaseValue(@analysisName)));
			parameters.Add(new SqlParameter("@AnalysisCode", EntityBase.GetDatabaseValue(@analysisCode)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a AnalysisSummary from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteAnalysisSummary(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteAnalysisSummary(@iD, helper);
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
		/// Deletes a AnalysisSummary from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteAnalysisSummary(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[AnalysisSummary]
WHERE 
	[AnalysisSummary].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new AnalysisSummary object.
		/// </summary>
		/// <returns>The newly created AnalysisSummary object.</returns>
		public static AnalysisSummary CreateAnalysisSummary()
		{
			return InitializeNew<AnalysisSummary>();
		}
		
		/// <summary>
		/// Retrieve information for a AnalysisSummary by a AnalysisSummary's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>AnalysisSummary</returns>
		public static AnalysisSummary GetAnalysisSummary(int @iD)
		{
			string commandText = @"
SELECT 
" + AnalysisSummary.SelectFieldList + @"
FROM [dbo].[AnalysisSummary] 
WHERE 
	[AnalysisSummary].[ID] = @ID " + AnalysisSummary.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<AnalysisSummary>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a AnalysisSummary by a AnalysisSummary's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>AnalysisSummary</returns>
		public static AnalysisSummary GetAnalysisSummary(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + AnalysisSummary.SelectFieldList + @"
FROM [dbo].[AnalysisSummary] 
WHERE 
	[AnalysisSummary].[ID] = @ID " + AnalysisSummary.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<AnalysisSummary>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection AnalysisSummary objects.
		/// </summary>
		/// <returns>The retrieved collection of AnalysisSummary objects.</returns>
		public static EntityList<AnalysisSummary> GetAnalysisSummaries()
		{
			string commandText = @"
SELECT " + AnalysisSummary.SelectFieldList + "FROM [dbo].[AnalysisSummary] " + AnalysisSummary.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<AnalysisSummary>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection AnalysisSummary objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of AnalysisSummary objects.</returns>
        public static EntityList<AnalysisSummary> GetAnalysisSummaries(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<AnalysisSummary>(SelectFieldList, "FROM [dbo].[AnalysisSummary]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection AnalysisSummary objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of AnalysisSummary objects.</returns>
        public static EntityList<AnalysisSummary> GetAnalysisSummaries(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<AnalysisSummary>(SelectFieldList, "FROM [dbo].[AnalysisSummary]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection AnalysisSummary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of AnalysisSummary objects.</returns>
		protected static EntityList<AnalysisSummary> GetAnalysisSummaries(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetAnalysisSummaries(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection AnalysisSummary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of AnalysisSummary objects.</returns>
		protected static EntityList<AnalysisSummary> GetAnalysisSummaries(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetAnalysisSummaries(string.Empty, where, parameters, AnalysisSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection AnalysisSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of AnalysisSummary objects.</returns>
		protected static EntityList<AnalysisSummary> GetAnalysisSummaries(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetAnalysisSummaries(prefix, where, parameters, AnalysisSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection AnalysisSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of AnalysisSummary objects.</returns>
		protected static EntityList<AnalysisSummary> GetAnalysisSummaries(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetAnalysisSummaries(string.Empty, where, parameters, AnalysisSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection AnalysisSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of AnalysisSummary objects.</returns>
		protected static EntityList<AnalysisSummary> GetAnalysisSummaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetAnalysisSummaries(prefix, where, parameters, AnalysisSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection AnalysisSummary objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of AnalysisSummary objects.</returns>
		protected static EntityList<AnalysisSummary> GetAnalysisSummaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + AnalysisSummary.SelectFieldList + "FROM [dbo].[AnalysisSummary] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<AnalysisSummary>(reader);
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
        protected static EntityList<AnalysisSummary> GetAnalysisSummaries(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<AnalysisSummary>(SelectFieldList, "FROM [dbo].[AnalysisSummary] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of AnalysisSummary objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetAnalysisSummaryCount()
        {
            return GetAnalysisSummaryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of AnalysisSummary objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetAnalysisSummaryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[AnalysisSummary] " + where;

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
		public static partial class AnalysisSummary_Properties
		{
			public const string ID = "ID";
			public const string PID = "PID";
			public const string AnalysisName = "AnalysisName";
			public const string AnalysisCode = "AnalysisCode";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"PID" , "int:"},
    			 {"AnalysisName" , "string:"},
    			 {"AnalysisCode" , "string:"},
            };
		}
		#endregion
	}
}
