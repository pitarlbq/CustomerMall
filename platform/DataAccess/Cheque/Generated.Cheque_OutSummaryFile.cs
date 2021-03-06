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
	/// This object represents the properties and methods of a Cheque_OutSummaryFile.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_OutSummaryFile 
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
		private int _outSummaryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int OutSummaryID
		{
			[DebuggerStepThrough()]
			get { return this._outSummaryID; }
			set 
			{
				if (this._outSummaryID != value) 
				{
					this._outSummaryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OutSummaryID");
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
	[OutSummaryID] int,
	[FilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

INSERT INTO [dbo].[Cheque_OutSummaryFile] (
	[Cheque_OutSummaryFile].[OutSummaryID],
	[Cheque_OutSummaryFile].[FilePath],
	[Cheque_OutSummaryFile].[AddTime],
	[Cheque_OutSummaryFile].[FileOriName]
) 
output 
	INSERTED.[ID],
	INSERTED.[OutSummaryID],
	INSERTED.[FilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
VALUES ( 
	@OutSummaryID,
	@FilePath,
	@AddTime,
	@FileOriName 
); 

SELECT 
	[ID],
	[OutSummaryID],
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
	[OutSummaryID] int,
	[FilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

UPDATE [dbo].[Cheque_OutSummaryFile] SET 
	[Cheque_OutSummaryFile].[OutSummaryID] = @OutSummaryID,
	[Cheque_OutSummaryFile].[FilePath] = @FilePath,
	[Cheque_OutSummaryFile].[AddTime] = @AddTime,
	[Cheque_OutSummaryFile].[FileOriName] = @FileOriName 
output 
	INSERTED.[ID],
	INSERTED.[OutSummaryID],
	INSERTED.[FilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
WHERE 
	[Cheque_OutSummaryFile].[ID] = @ID

SELECT 
	[ID],
	[OutSummaryID],
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
DELETE FROM [dbo].[Cheque_OutSummaryFile]
WHERE 
	[Cheque_OutSummaryFile].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_OutSummaryFile() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_OutSummaryFile(this.ID));
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
	[Cheque_OutSummaryFile].[ID],
	[Cheque_OutSummaryFile].[OutSummaryID],
	[Cheque_OutSummaryFile].[FilePath],
	[Cheque_OutSummaryFile].[AddTime],
	[Cheque_OutSummaryFile].[FileOriName]
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
                return "Cheque_OutSummaryFile";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_OutSummaryFile into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="outSummaryID">outSummaryID</param>
		/// <param name="filePath">filePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		public static void InsertCheque_OutSummaryFile(int @outSummaryID, string @filePath, DateTime @addTime, string @fileOriName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_OutSummaryFile(@outSummaryID, @filePath, @addTime, @fileOriName, helper);
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
		/// Insert a Cheque_OutSummaryFile into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="outSummaryID">outSummaryID</param>
		/// <param name="filePath">filePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_OutSummaryFile(int @outSummaryID, string @filePath, DateTime @addTime, string @fileOriName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OutSummaryID] int,
	[FilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

INSERT INTO [dbo].[Cheque_OutSummaryFile] (
	[Cheque_OutSummaryFile].[OutSummaryID],
	[Cheque_OutSummaryFile].[FilePath],
	[Cheque_OutSummaryFile].[AddTime],
	[Cheque_OutSummaryFile].[FileOriName]
) 
output 
	INSERTED.[ID],
	INSERTED.[OutSummaryID],
	INSERTED.[FilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
VALUES ( 
	@OutSummaryID,
	@FilePath,
	@AddTime,
	@FileOriName 
); 

SELECT 
	[ID],
	[OutSummaryID],
	[FilePath],
	[AddTime],
	[FileOriName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OutSummaryID", EntityBase.GetDatabaseValue(@outSummaryID)));
			parameters.Add(new SqlParameter("@FilePath", EntityBase.GetDatabaseValue(@filePath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@FileOriName", EntityBase.GetDatabaseValue(@fileOriName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_OutSummaryFile into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="outSummaryID">outSummaryID</param>
		/// <param name="filePath">filePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		public static void UpdateCheque_OutSummaryFile(int @iD, int @outSummaryID, string @filePath, DateTime @addTime, string @fileOriName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_OutSummaryFile(@iD, @outSummaryID, @filePath, @addTime, @fileOriName, helper);
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
		/// Updates a Cheque_OutSummaryFile into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="outSummaryID">outSummaryID</param>
		/// <param name="filePath">filePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_OutSummaryFile(int @iD, int @outSummaryID, string @filePath, DateTime @addTime, string @fileOriName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OutSummaryID] int,
	[FilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

UPDATE [dbo].[Cheque_OutSummaryFile] SET 
	[Cheque_OutSummaryFile].[OutSummaryID] = @OutSummaryID,
	[Cheque_OutSummaryFile].[FilePath] = @FilePath,
	[Cheque_OutSummaryFile].[AddTime] = @AddTime,
	[Cheque_OutSummaryFile].[FileOriName] = @FileOriName 
output 
	INSERTED.[ID],
	INSERTED.[OutSummaryID],
	INSERTED.[FilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
WHERE 
	[Cheque_OutSummaryFile].[ID] = @ID

SELECT 
	[ID],
	[OutSummaryID],
	[FilePath],
	[AddTime],
	[FileOriName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OutSummaryID", EntityBase.GetDatabaseValue(@outSummaryID)));
			parameters.Add(new SqlParameter("@FilePath", EntityBase.GetDatabaseValue(@filePath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@FileOriName", EntityBase.GetDatabaseValue(@fileOriName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_OutSummaryFile from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_OutSummaryFile(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_OutSummaryFile(@iD, helper);
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
		/// Deletes a Cheque_OutSummaryFile from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_OutSummaryFile(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_OutSummaryFile]
WHERE 
	[Cheque_OutSummaryFile].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_OutSummaryFile object.
		/// </summary>
		/// <returns>The newly created Cheque_OutSummaryFile object.</returns>
		public static Cheque_OutSummaryFile CreateCheque_OutSummaryFile()
		{
			return InitializeNew<Cheque_OutSummaryFile>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_OutSummaryFile by a Cheque_OutSummaryFile's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_OutSummaryFile</returns>
		public static Cheque_OutSummaryFile GetCheque_OutSummaryFile(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_OutSummaryFile.SelectFieldList + @"
FROM [dbo].[Cheque_OutSummaryFile] 
WHERE 
	[Cheque_OutSummaryFile].[ID] = @ID " + Cheque_OutSummaryFile.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_OutSummaryFile>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_OutSummaryFile by a Cheque_OutSummaryFile's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_OutSummaryFile</returns>
		public static Cheque_OutSummaryFile GetCheque_OutSummaryFile(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_OutSummaryFile.SelectFieldList + @"
FROM [dbo].[Cheque_OutSummaryFile] 
WHERE 
	[Cheque_OutSummaryFile].[ID] = @ID " + Cheque_OutSummaryFile.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_OutSummaryFile>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutSummaryFile objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_OutSummaryFile objects.</returns>
		public static EntityList<Cheque_OutSummaryFile> GetCheque_OutSummaryFiles()
		{
			string commandText = @"
SELECT " + Cheque_OutSummaryFile.SelectFieldList + "FROM [dbo].[Cheque_OutSummaryFile] " + Cheque_OutSummaryFile.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_OutSummaryFile>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_OutSummaryFile objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_OutSummaryFile objects.</returns>
        public static EntityList<Cheque_OutSummaryFile> GetCheque_OutSummaryFiles(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_OutSummaryFile>(SelectFieldList, "FROM [dbo].[Cheque_OutSummaryFile]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_OutSummaryFile objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_OutSummaryFile objects.</returns>
        public static EntityList<Cheque_OutSummaryFile> GetCheque_OutSummaryFiles(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_OutSummaryFile>(SelectFieldList, "FROM [dbo].[Cheque_OutSummaryFile]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_OutSummaryFile objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_OutSummaryFile objects.</returns>
		protected static EntityList<Cheque_OutSummaryFile> GetCheque_OutSummaryFiles(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_OutSummaryFiles(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutSummaryFile objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_OutSummaryFile objects.</returns>
		protected static EntityList<Cheque_OutSummaryFile> GetCheque_OutSummaryFiles(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_OutSummaryFiles(string.Empty, where, parameters, Cheque_OutSummaryFile.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutSummaryFile objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_OutSummaryFile objects.</returns>
		protected static EntityList<Cheque_OutSummaryFile> GetCheque_OutSummaryFiles(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_OutSummaryFiles(prefix, where, parameters, Cheque_OutSummaryFile.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutSummaryFile objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_OutSummaryFile objects.</returns>
		protected static EntityList<Cheque_OutSummaryFile> GetCheque_OutSummaryFiles(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_OutSummaryFiles(string.Empty, where, parameters, Cheque_OutSummaryFile.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutSummaryFile objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_OutSummaryFile objects.</returns>
		protected static EntityList<Cheque_OutSummaryFile> GetCheque_OutSummaryFiles(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_OutSummaryFiles(prefix, where, parameters, Cheque_OutSummaryFile.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutSummaryFile objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_OutSummaryFile objects.</returns>
		protected static EntityList<Cheque_OutSummaryFile> GetCheque_OutSummaryFiles(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_OutSummaryFile.SelectFieldList + "FROM [dbo].[Cheque_OutSummaryFile] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_OutSummaryFile>(reader);
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
        protected static EntityList<Cheque_OutSummaryFile> GetCheque_OutSummaryFiles(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_OutSummaryFile>(SelectFieldList, "FROM [dbo].[Cheque_OutSummaryFile] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_OutSummaryFile objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_OutSummaryFileCount()
        {
            return GetCheque_OutSummaryFileCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_OutSummaryFile objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_OutSummaryFileCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_OutSummaryFile] " + where;

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
		public static partial class Cheque_OutSummaryFile_Properties
		{
			public const string ID = "ID";
			public const string OutSummaryID = "OutSummaryID";
			public const string FilePath = "FilePath";
			public const string AddTime = "AddTime";
			public const string FileOriName = "FileOriName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OutSummaryID" , "int:"},
    			 {"FilePath" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"FileOriName" , "string:"},
            };
		}
		#endregion
	}
}
