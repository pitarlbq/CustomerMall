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
	/// This object represents the properties and methods of a Contract_Template.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Contract_Template 
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
		private string _templateContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TemplateContent
		{
			[DebuggerStepThrough()]
			get { return this._templateContent; }
			set 
			{
				if (this._templateContent != value) 
				{
					this._templateContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("TemplateContent");
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
		private string _templateNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TemplateNo
		{
			[DebuggerStepThrough()]
			get { return this._templateNo; }
			set 
			{
				if (this._templateNo != value) 
				{
					this._templateNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("TemplateNo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _templateName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TemplateName
		{
			[DebuggerStepThrough()]
			get { return this._templateName; }
			set 
			{
				if (this._templateName != value) 
				{
					this._templateName = value;
					this.IsDirty = true;	
					OnPropertyChanged("TemplateName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _templateSummary = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TemplateSummary
		{
			[DebuggerStepThrough()]
			get { return this._templateSummary; }
			set 
			{
				if (this._templateSummary != value) 
				{
					this._templateSummary = value;
					this.IsDirty = true;	
					OnPropertyChanged("TemplateSummary");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _templateStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TemplateStatus
		{
			[DebuggerStepThrough()]
			get { return this._templateStatus; }
			set 
			{
				if (this._templateStatus != value) 
				{
					this._templateStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("TemplateStatus");
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
	[TemplateContent] ntext,
	[AddTime] datetime,
	[TemplateNo] nvarchar(100),
	[TemplateName] nvarchar(100),
	[TemplateSummary] nvarchar(500),
	[TemplateStatus] int
);

INSERT INTO [dbo].[Contract_Template] (
	[Contract_Template].[TemplateContent],
	[Contract_Template].[AddTime],
	[Contract_Template].[TemplateNo],
	[Contract_Template].[TemplateName],
	[Contract_Template].[TemplateSummary],
	[Contract_Template].[TemplateStatus]
) 
output 
	INSERTED.[ID],
	INSERTED.[TemplateContent],
	INSERTED.[AddTime],
	INSERTED.[TemplateNo],
	INSERTED.[TemplateName],
	INSERTED.[TemplateSummary],
	INSERTED.[TemplateStatus]
into @table
VALUES ( 
	@TemplateContent,
	@AddTime,
	@TemplateNo,
	@TemplateName,
	@TemplateSummary,
	@TemplateStatus 
); 

SELECT 
	[ID],
	[TemplateContent],
	[AddTime],
	[TemplateNo],
	[TemplateName],
	[TemplateSummary],
	[TemplateStatus] 
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
	[TemplateContent] ntext,
	[AddTime] datetime,
	[TemplateNo] nvarchar(100),
	[TemplateName] nvarchar(100),
	[TemplateSummary] nvarchar(500),
	[TemplateStatus] int
);

UPDATE [dbo].[Contract_Template] SET 
	[Contract_Template].[TemplateContent] = @TemplateContent,
	[Contract_Template].[AddTime] = @AddTime,
	[Contract_Template].[TemplateNo] = @TemplateNo,
	[Contract_Template].[TemplateName] = @TemplateName,
	[Contract_Template].[TemplateSummary] = @TemplateSummary,
	[Contract_Template].[TemplateStatus] = @TemplateStatus 
output 
	INSERTED.[ID],
	INSERTED.[TemplateContent],
	INSERTED.[AddTime],
	INSERTED.[TemplateNo],
	INSERTED.[TemplateName],
	INSERTED.[TemplateSummary],
	INSERTED.[TemplateStatus]
into @table
WHERE 
	[Contract_Template].[ID] = @ID

SELECT 
	[ID],
	[TemplateContent],
	[AddTime],
	[TemplateNo],
	[TemplateName],
	[TemplateSummary],
	[TemplateStatus] 
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
DELETE FROM [dbo].[Contract_Template]
WHERE 
	[Contract_Template].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Contract_Template() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetContract_Template(this.ID));
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
	[Contract_Template].[ID],
	[Contract_Template].[TemplateContent],
	[Contract_Template].[AddTime],
	[Contract_Template].[TemplateNo],
	[Contract_Template].[TemplateName],
	[Contract_Template].[TemplateSummary],
	[Contract_Template].[TemplateStatus]
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
                return "Contract_Template";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Contract_Template into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="templateContent">templateContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="templateNo">templateNo</param>
		/// <param name="templateName">templateName</param>
		/// <param name="templateSummary">templateSummary</param>
		/// <param name="templateStatus">templateStatus</param>
		public static void InsertContract_Template(string @templateContent, DateTime @addTime, string @templateNo, string @templateName, string @templateSummary, int @templateStatus)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertContract_Template(@templateContent, @addTime, @templateNo, @templateName, @templateSummary, @templateStatus, helper);
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
		/// Insert a Contract_Template into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="templateContent">templateContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="templateNo">templateNo</param>
		/// <param name="templateName">templateName</param>
		/// <param name="templateSummary">templateSummary</param>
		/// <param name="templateStatus">templateStatus</param>
		/// <param name="helper">helper</param>
		internal static void InsertContract_Template(string @templateContent, DateTime @addTime, string @templateNo, string @templateName, string @templateSummary, int @templateStatus, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[TemplateContent] ntext,
	[AddTime] datetime,
	[TemplateNo] nvarchar(100),
	[TemplateName] nvarchar(100),
	[TemplateSummary] nvarchar(500),
	[TemplateStatus] int
);

INSERT INTO [dbo].[Contract_Template] (
	[Contract_Template].[TemplateContent],
	[Contract_Template].[AddTime],
	[Contract_Template].[TemplateNo],
	[Contract_Template].[TemplateName],
	[Contract_Template].[TemplateSummary],
	[Contract_Template].[TemplateStatus]
) 
output 
	INSERTED.[ID],
	INSERTED.[TemplateContent],
	INSERTED.[AddTime],
	INSERTED.[TemplateNo],
	INSERTED.[TemplateName],
	INSERTED.[TemplateSummary],
	INSERTED.[TemplateStatus]
into @table
VALUES ( 
	@TemplateContent,
	@AddTime,
	@TemplateNo,
	@TemplateName,
	@TemplateSummary,
	@TemplateStatus 
); 

SELECT 
	[ID],
	[TemplateContent],
	[AddTime],
	[TemplateNo],
	[TemplateName],
	[TemplateSummary],
	[TemplateStatus] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TemplateContent", EntityBase.GetDatabaseValue(@templateContent)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@TemplateNo", EntityBase.GetDatabaseValue(@templateNo)));
			parameters.Add(new SqlParameter("@TemplateName", EntityBase.GetDatabaseValue(@templateName)));
			parameters.Add(new SqlParameter("@TemplateSummary", EntityBase.GetDatabaseValue(@templateSummary)));
			parameters.Add(new SqlParameter("@TemplateStatus", EntityBase.GetDatabaseValue(@templateStatus)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Contract_Template into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="templateContent">templateContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="templateNo">templateNo</param>
		/// <param name="templateName">templateName</param>
		/// <param name="templateSummary">templateSummary</param>
		/// <param name="templateStatus">templateStatus</param>
		public static void UpdateContract_Template(int @iD, string @templateContent, DateTime @addTime, string @templateNo, string @templateName, string @templateSummary, int @templateStatus)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateContract_Template(@iD, @templateContent, @addTime, @templateNo, @templateName, @templateSummary, @templateStatus, helper);
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
		/// Updates a Contract_Template into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="templateContent">templateContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="templateNo">templateNo</param>
		/// <param name="templateName">templateName</param>
		/// <param name="templateSummary">templateSummary</param>
		/// <param name="templateStatus">templateStatus</param>
		/// <param name="helper">helper</param>
		internal static void UpdateContract_Template(int @iD, string @templateContent, DateTime @addTime, string @templateNo, string @templateName, string @templateSummary, int @templateStatus, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[TemplateContent] ntext,
	[AddTime] datetime,
	[TemplateNo] nvarchar(100),
	[TemplateName] nvarchar(100),
	[TemplateSummary] nvarchar(500),
	[TemplateStatus] int
);

UPDATE [dbo].[Contract_Template] SET 
	[Contract_Template].[TemplateContent] = @TemplateContent,
	[Contract_Template].[AddTime] = @AddTime,
	[Contract_Template].[TemplateNo] = @TemplateNo,
	[Contract_Template].[TemplateName] = @TemplateName,
	[Contract_Template].[TemplateSummary] = @TemplateSummary,
	[Contract_Template].[TemplateStatus] = @TemplateStatus 
output 
	INSERTED.[ID],
	INSERTED.[TemplateContent],
	INSERTED.[AddTime],
	INSERTED.[TemplateNo],
	INSERTED.[TemplateName],
	INSERTED.[TemplateSummary],
	INSERTED.[TemplateStatus]
into @table
WHERE 
	[Contract_Template].[ID] = @ID

SELECT 
	[ID],
	[TemplateContent],
	[AddTime],
	[TemplateNo],
	[TemplateName],
	[TemplateSummary],
	[TemplateStatus] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@TemplateContent", EntityBase.GetDatabaseValue(@templateContent)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@TemplateNo", EntityBase.GetDatabaseValue(@templateNo)));
			parameters.Add(new SqlParameter("@TemplateName", EntityBase.GetDatabaseValue(@templateName)));
			parameters.Add(new SqlParameter("@TemplateSummary", EntityBase.GetDatabaseValue(@templateSummary)));
			parameters.Add(new SqlParameter("@TemplateStatus", EntityBase.GetDatabaseValue(@templateStatus)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Contract_Template from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteContract_Template(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteContract_Template(@iD, helper);
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
		/// Deletes a Contract_Template from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteContract_Template(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Contract_Template]
WHERE 
	[Contract_Template].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Contract_Template object.
		/// </summary>
		/// <returns>The newly created Contract_Template object.</returns>
		public static Contract_Template CreateContract_Template()
		{
			return InitializeNew<Contract_Template>();
		}
		
		/// <summary>
		/// Retrieve information for a Contract_Template by a Contract_Template's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Contract_Template</returns>
		public static Contract_Template GetContract_Template(int @iD)
		{
			string commandText = @"
SELECT 
" + Contract_Template.SelectFieldList + @"
FROM [dbo].[Contract_Template] 
WHERE 
	[Contract_Template].[ID] = @ID " + Contract_Template.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_Template>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Contract_Template by a Contract_Template's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Contract_Template</returns>
		public static Contract_Template GetContract_Template(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Contract_Template.SelectFieldList + @"
FROM [dbo].[Contract_Template] 
WHERE 
	[Contract_Template].[ID] = @ID " + Contract_Template.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_Template>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Contract_Template objects.
		/// </summary>
		/// <returns>The retrieved collection of Contract_Template objects.</returns>
		public static EntityList<Contract_Template> GetContract_Templates()
		{
			string commandText = @"
SELECT " + Contract_Template.SelectFieldList + "FROM [dbo].[Contract_Template] " + Contract_Template.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Contract_Template>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Contract_Template objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_Template objects.</returns>
        public static EntityList<Contract_Template> GetContract_Templates(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Template>(SelectFieldList, "FROM [dbo].[Contract_Template]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Contract_Template objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_Template objects.</returns>
        public static EntityList<Contract_Template> GetContract_Templates(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Template>(SelectFieldList, "FROM [dbo].[Contract_Template]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Contract_Template objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Contract_Template objects.</returns>
		protected static EntityList<Contract_Template> GetContract_Templates(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Templates(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Contract_Template objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_Template objects.</returns>
		protected static EntityList<Contract_Template> GetContract_Templates(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Templates(string.Empty, where, parameters, Contract_Template.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Template objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_Template objects.</returns>
		protected static EntityList<Contract_Template> GetContract_Templates(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Templates(prefix, where, parameters, Contract_Template.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Template objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_Template objects.</returns>
		protected static EntityList<Contract_Template> GetContract_Templates(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_Templates(string.Empty, where, parameters, Contract_Template.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Template objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_Template objects.</returns>
		protected static EntityList<Contract_Template> GetContract_Templates(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_Templates(prefix, where, parameters, Contract_Template.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Template objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Contract_Template objects.</returns>
		protected static EntityList<Contract_Template> GetContract_Templates(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Contract_Template.SelectFieldList + "FROM [dbo].[Contract_Template] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Contract_Template>(reader);
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
        protected static EntityList<Contract_Template> GetContract_Templates(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Template>(SelectFieldList, "FROM [dbo].[Contract_Template] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Contract_Template objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_TemplateCount()
        {
            return GetContract_TemplateCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Contract_Template objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_TemplateCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Contract_Template] " + where;

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
		public static partial class Contract_Template_Properties
		{
			public const string ID = "ID";
			public const string TemplateContent = "TemplateContent";
			public const string AddTime = "AddTime";
			public const string TemplateNo = "TemplateNo";
			public const string TemplateName = "TemplateName";
			public const string TemplateSummary = "TemplateSummary";
			public const string TemplateStatus = "TemplateStatus";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"TemplateContent" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"TemplateNo" , "string:"},
    			 {"TemplateName" , "string:"},
    			 {"TemplateSummary" , "string:"},
    			 {"TemplateStatus" , "int:"},
            };
		}
		#endregion
	}
}
