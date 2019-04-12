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
	/// This object represents the properties and methods of a Cheque_InSummaryFile.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_InSummaryFile 
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
		private int _inSummaryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int InSummaryID
		{
			[DebuggerStepThrough()]
			get { return this._inSummaryID; }
			set 
			{
				if (this._inSummaryID != value) 
				{
					this._inSummaryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("InSummaryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _filePath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FilePath
		{
			[DebuggerStepThrough()]
			get { return this._filePath; }
			set 
			{
				if (this._filePath != value) 
				{
					this._filePath = value;
					this.IsDirty = true;	
					OnPropertyChanged("FilePath");
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
		private string _fileOriName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FileOriName
		{
			[DebuggerStepThrough()]
			get { return this._fileOriName; }
			set 
			{
				if (this._fileOriName != value) 
				{
					this._fileOriName = value;
					this.IsDirty = true;	
					OnPropertyChanged("FileOriName");
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
	[InSummaryID] int,
	[FilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

INSERT INTO [dbo].[Cheque_InSummaryFile] (
	[Cheque_InSummaryFile].[InSummaryID],
	[Cheque_InSummaryFile].[FilePath],
	[Cheque_InSummaryFile].[AddTime],
	[Cheque_InSummaryFile].[FileOriName]
) 
output 
	INSERTED.[ID],
	INSERTED.[InSummaryID],
	INSERTED.[FilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
VALUES ( 
	@InSummaryID,
	@FilePath,
	@AddTime,
	@FileOriName 
); 

SELECT 
	[ID],
	[InSummaryID],
	[FilePath],
	[AddTime],
	[FileOriName] 
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
	[InSummaryID] int,
	[FilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

UPDATE [dbo].[Cheque_InSummaryFile] SET 
	[Cheque_InSummaryFile].[InSummaryID] = @InSummaryID,
	[Cheque_InSummaryFile].[FilePath] = @FilePath,
	[Cheque_InSummaryFile].[AddTime] = @AddTime,
	[Cheque_InSummaryFile].[FileOriName] = @FileOriName 
output 
	INSERTED.[ID],
	INSERTED.[InSummaryID],
	INSERTED.[FilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
WHERE 
	[Cheque_InSummaryFile].[ID] = @ID

SELECT 
	[ID],
	[InSummaryID],
	[FilePath],
	[AddTime],
	[FileOriName] 
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
DELETE FROM [dbo].[Cheque_InSummaryFile]
WHERE 
	[Cheque_InSummaryFile].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_InSummaryFile() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_InSummaryFile(this.ID));
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
	[Cheque_InSummaryFile].[ID],
	[Cheque_InSummaryFile].[InSummaryID],
	[Cheque_InSummaryFile].[FilePath],
	[Cheque_InSummaryFile].[AddTime],
	[Cheque_InSummaryFile].[FileOriName]
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
                return "Cheque_InSummaryFile";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_InSummaryFile into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="inSummaryID">inSummaryID</param>
		/// <param name="filePath">filePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		public static void InsertCheque_InSummaryFile(int @inSummaryID, string @filePath, DateTime @addTime, string @fileOriName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_InSummaryFile(@inSummaryID, @filePath, @addTime, @fileOriName, helper);
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
		/// Insert a Cheque_InSummaryFile into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="inSummaryID">inSummaryID</param>
		/// <param name="filePath">filePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_InSummaryFile(int @inSummaryID, string @filePath, DateTime @addTime, string @fileOriName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[InSummaryID] int,
	[FilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

INSERT INTO [dbo].[Cheque_InSummaryFile] (
	[Cheque_InSummaryFile].[InSummaryID],
	[Cheque_InSummaryFile].[FilePath],
	[Cheque_InSummaryFile].[AddTime],
	[Cheque_InSummaryFile].[FileOriName]
) 
output 
	INSERTED.[ID],
	INSERTED.[InSummaryID],
	INSERTED.[FilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
VALUES ( 
	@InSummaryID,
	@FilePath,
	@AddTime,
	@FileOriName 
); 

SELECT 
	[ID],
	[InSummaryID],
	[FilePath],
	[AddTime],
	[FileOriName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@InSummaryID", EntityBase.GetDatabaseValue(@inSummaryID)));
			parameters.Add(new SqlParameter("@FilePath", EntityBase.GetDatabaseValue(@filePath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@FileOriName", EntityBase.GetDatabaseValue(@fileOriName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_InSummaryFile into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="inSummaryID">inSummaryID</param>
		/// <param name="filePath">filePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		public static void UpdateCheque_InSummaryFile(int @iD, int @inSummaryID, string @filePath, DateTime @addTime, string @fileOriName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_InSummaryFile(@iD, @inSummaryID, @filePath, @addTime, @fileOriName, helper);
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
		/// Updates a Cheque_InSummaryFile into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="inSummaryID">inSummaryID</param>
		/// <param name="filePath">filePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_InSummaryFile(int @iD, int @inSummaryID, string @filePath, DateTime @addTime, string @fileOriName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[InSummaryID] int,
	[FilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

UPDATE [dbo].[Cheque_InSummaryFile] SET 
	[Cheque_InSummaryFile].[InSummaryID] = @InSummaryID,
	[Cheque_InSummaryFile].[FilePath] = @FilePath,
	[Cheque_InSummaryFile].[AddTime] = @AddTime,
	[Cheque_InSummaryFile].[FileOriName] = @FileOriName 
output 
	INSERTED.[ID],
	INSERTED.[InSummaryID],
	INSERTED.[FilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
WHERE 
	[Cheque_InSummaryFile].[ID] = @ID

SELECT 
	[ID],
	[InSummaryID],
	[FilePath],
	[AddTime],
	[FileOriName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@InSummaryID", EntityBase.GetDatabaseValue(@inSummaryID)));
			parameters.Add(new SqlParameter("@FilePath", EntityBase.GetDatabaseValue(@filePath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@FileOriName", EntityBase.GetDatabaseValue(@fileOriName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_InSummaryFile from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_InSummaryFile(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_InSummaryFile(@iD, helper);
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
		/// Deletes a Cheque_InSummaryFile from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_InSummaryFile(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_InSummaryFile]
WHERE 
	[Cheque_InSummaryFile].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_InSummaryFile object.
		/// </summary>
		/// <returns>The newly created Cheque_InSummaryFile object.</returns>
		public static Cheque_InSummaryFile CreateCheque_InSummaryFile()
		{
			return InitializeNew<Cheque_InSummaryFile>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_InSummaryFile by a Cheque_InSummaryFile's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_InSummaryFile</returns>
		public static Cheque_InSummaryFile GetCheque_InSummaryFile(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_InSummaryFile.SelectFieldList + @"
FROM [dbo].[Cheque_InSummaryFile] 
WHERE 
	[Cheque_InSummaryFile].[ID] = @ID " + Cheque_InSummaryFile.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_InSummaryFile>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_InSummaryFile by a Cheque_InSummaryFile's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_InSummaryFile</returns>
		public static Cheque_InSummaryFile GetCheque_InSummaryFile(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_InSummaryFile.SelectFieldList + @"
FROM [dbo].[Cheque_InSummaryFile] 
WHERE 
	[Cheque_InSummaryFile].[ID] = @ID " + Cheque_InSummaryFile.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_InSummaryFile>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_InSummaryFile objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_InSummaryFile objects.</returns>
		public static EntityList<Cheque_InSummaryFile> GetCheque_InSummaryFiles()
		{
			string commandText = @"
SELECT " + Cheque_InSummaryFile.SelectFieldList + "FROM [dbo].[Cheque_InSummaryFile] " + Cheque_InSummaryFile.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_InSummaryFile>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_InSummaryFile objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_InSummaryFile objects.</returns>
        public static EntityList<Cheque_InSummaryFile> GetCheque_InSummaryFiles(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_InSummaryFile>(SelectFieldList, "FROM [dbo].[Cheque_InSummaryFile]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_InSummaryFile objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_InSummaryFile objects.</returns>
        public static EntityList<Cheque_InSummaryFile> GetCheque_InSummaryFiles(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_InSummaryFile>(SelectFieldList, "FROM [dbo].[Cheque_InSummaryFile]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_InSummaryFile objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_InSummaryFile objects.</returns>
		protected static EntityList<Cheque_InSummaryFile> GetCheque_InSummaryFiles(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_InSummaryFiles(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_InSummaryFile objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_InSummaryFile objects.</returns>
		protected static EntityList<Cheque_InSummaryFile> GetCheque_InSummaryFiles(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_InSummaryFiles(string.Empty, where, parameters, Cheque_InSummaryFile.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_InSummaryFile objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_InSummaryFile objects.</returns>
		protected static EntityList<Cheque_InSummaryFile> GetCheque_InSummaryFiles(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_InSummaryFiles(prefix, where, parameters, Cheque_InSummaryFile.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_InSummaryFile objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_InSummaryFile objects.</returns>
		protected static EntityList<Cheque_InSummaryFile> GetCheque_InSummaryFiles(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_InSummaryFiles(string.Empty, where, parameters, Cheque_InSummaryFile.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_InSummaryFile objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_InSummaryFile objects.</returns>
		protected static EntityList<Cheque_InSummaryFile> GetCheque_InSummaryFiles(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_InSummaryFiles(prefix, where, parameters, Cheque_InSummaryFile.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_InSummaryFile objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_InSummaryFile objects.</returns>
		protected static EntityList<Cheque_InSummaryFile> GetCheque_InSummaryFiles(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_InSummaryFile.SelectFieldList + "FROM [dbo].[Cheque_InSummaryFile] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_InSummaryFile>(reader);
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
        protected static EntityList<Cheque_InSummaryFile> GetCheque_InSummaryFiles(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_InSummaryFile>(SelectFieldList, "FROM [dbo].[Cheque_InSummaryFile] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_InSummaryFile objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_InSummaryFileCount()
        {
            return GetCheque_InSummaryFileCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_InSummaryFile objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_InSummaryFileCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_InSummaryFile] " + where;

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
		public static partial class Cheque_InSummaryFile_Properties
		{
			public const string ID = "ID";
			public const string InSummaryID = "InSummaryID";
			public const string FilePath = "FilePath";
			public const string AddTime = "AddTime";
			public const string FileOriName = "FileOriName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"InSummaryID" , "int:"},
    			 {"FilePath" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"FileOriName" , "string:"},
            };
		}
		#endregion
	}
}
