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
	/// This object represents the properties and methods of a Contract_File.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Contract_File 
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
		private int _relateID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RelateID
		{
			[DebuggerStepThrough()]
			get { return this._relateID; }
			set 
			{
				if (this._relateID != value) 
				{
					this._relateID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RelateID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _attachedFilePath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AttachedFilePath
		{
			[DebuggerStepThrough()]
			get { return this._attachedFilePath; }
			set 
			{
				if (this._attachedFilePath != value) 
				{
					this._attachedFilePath = value;
					this.IsDirty = true;	
					OnPropertyChanged("AttachedFilePath");
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _fileType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FileType
		{
			[DebuggerStepThrough()]
			get { return this._fileType; }
			set 
			{
				if (this._fileType != value) 
				{
					this._fileType = value;
					this.IsDirty = true;	
					OnPropertyChanged("FileType");
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
	[RelateID] int,
	[AttachedFilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500),
	[FileType] nvarchar(50)
);

INSERT INTO [dbo].[Contract_File] (
	[Contract_File].[RelateID],
	[Contract_File].[AttachedFilePath],
	[Contract_File].[AddTime],
	[Contract_File].[FileOriName],
	[Contract_File].[FileType]
) 
output 
	INSERTED.[ID],
	INSERTED.[RelateID],
	INSERTED.[AttachedFilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName],
	INSERTED.[FileType]
into @table
VALUES ( 
	@RelateID,
	@AttachedFilePath,
	@AddTime,
	@FileOriName,
	@FileType 
); 

SELECT 
	[ID],
	[RelateID],
	[AttachedFilePath],
	[AddTime],
	[FileOriName],
	[FileType] 
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
	[RelateID] int,
	[AttachedFilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500),
	[FileType] nvarchar(50)
);

UPDATE [dbo].[Contract_File] SET 
	[Contract_File].[RelateID] = @RelateID,
	[Contract_File].[AttachedFilePath] = @AttachedFilePath,
	[Contract_File].[AddTime] = @AddTime,
	[Contract_File].[FileOriName] = @FileOriName,
	[Contract_File].[FileType] = @FileType 
output 
	INSERTED.[ID],
	INSERTED.[RelateID],
	INSERTED.[AttachedFilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName],
	INSERTED.[FileType]
into @table
WHERE 
	[Contract_File].[ID] = @ID

SELECT 
	[ID],
	[RelateID],
	[AttachedFilePath],
	[AddTime],
	[FileOriName],
	[FileType] 
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
DELETE FROM [dbo].[Contract_File]
WHERE 
	[Contract_File].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Contract_File() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetContract_File(this.ID));
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
	[Contract_File].[ID],
	[Contract_File].[RelateID],
	[Contract_File].[AttachedFilePath],
	[Contract_File].[AddTime],
	[Contract_File].[FileOriName],
	[Contract_File].[FileType]
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
                return "Contract_File";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Contract_File into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="relateID">relateID</param>
		/// <param name="attachedFilePath">attachedFilePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="fileType">fileType</param>
		public static void InsertContract_File(int @relateID, string @attachedFilePath, DateTime @addTime, string @fileOriName, string @fileType)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertContract_File(@relateID, @attachedFilePath, @addTime, @fileOriName, @fileType, helper);
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
		/// Insert a Contract_File into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="relateID">relateID</param>
		/// <param name="attachedFilePath">attachedFilePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="fileType">fileType</param>
		/// <param name="helper">helper</param>
		internal static void InsertContract_File(int @relateID, string @attachedFilePath, DateTime @addTime, string @fileOriName, string @fileType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RelateID] int,
	[AttachedFilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500),
	[FileType] nvarchar(50)
);

INSERT INTO [dbo].[Contract_File] (
	[Contract_File].[RelateID],
	[Contract_File].[AttachedFilePath],
	[Contract_File].[AddTime],
	[Contract_File].[FileOriName],
	[Contract_File].[FileType]
) 
output 
	INSERTED.[ID],
	INSERTED.[RelateID],
	INSERTED.[AttachedFilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName],
	INSERTED.[FileType]
into @table
VALUES ( 
	@RelateID,
	@AttachedFilePath,
	@AddTime,
	@FileOriName,
	@FileType 
); 

SELECT 
	[ID],
	[RelateID],
	[AttachedFilePath],
	[AddTime],
	[FileOriName],
	[FileType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RelateID", EntityBase.GetDatabaseValue(@relateID)));
			parameters.Add(new SqlParameter("@AttachedFilePath", EntityBase.GetDatabaseValue(@attachedFilePath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@FileOriName", EntityBase.GetDatabaseValue(@fileOriName)));
			parameters.Add(new SqlParameter("@FileType", EntityBase.GetDatabaseValue(@fileType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Contract_File into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="relateID">relateID</param>
		/// <param name="attachedFilePath">attachedFilePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="fileType">fileType</param>
		public static void UpdateContract_File(int @iD, int @relateID, string @attachedFilePath, DateTime @addTime, string @fileOriName, string @fileType)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateContract_File(@iD, @relateID, @attachedFilePath, @addTime, @fileOriName, @fileType, helper);
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
		/// Updates a Contract_File into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="relateID">relateID</param>
		/// <param name="attachedFilePath">attachedFilePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="fileType">fileType</param>
		/// <param name="helper">helper</param>
		internal static void UpdateContract_File(int @iD, int @relateID, string @attachedFilePath, DateTime @addTime, string @fileOriName, string @fileType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RelateID] int,
	[AttachedFilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500),
	[FileType] nvarchar(50)
);

UPDATE [dbo].[Contract_File] SET 
	[Contract_File].[RelateID] = @RelateID,
	[Contract_File].[AttachedFilePath] = @AttachedFilePath,
	[Contract_File].[AddTime] = @AddTime,
	[Contract_File].[FileOriName] = @FileOriName,
	[Contract_File].[FileType] = @FileType 
output 
	INSERTED.[ID],
	INSERTED.[RelateID],
	INSERTED.[AttachedFilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName],
	INSERTED.[FileType]
into @table
WHERE 
	[Contract_File].[ID] = @ID

SELECT 
	[ID],
	[RelateID],
	[AttachedFilePath],
	[AddTime],
	[FileOriName],
	[FileType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RelateID", EntityBase.GetDatabaseValue(@relateID)));
			parameters.Add(new SqlParameter("@AttachedFilePath", EntityBase.GetDatabaseValue(@attachedFilePath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@FileOriName", EntityBase.GetDatabaseValue(@fileOriName)));
			parameters.Add(new SqlParameter("@FileType", EntityBase.GetDatabaseValue(@fileType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Contract_File from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteContract_File(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteContract_File(@iD, helper);
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
		/// Deletes a Contract_File from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteContract_File(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Contract_File]
WHERE 
	[Contract_File].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Contract_File object.
		/// </summary>
		/// <returns>The newly created Contract_File object.</returns>
		public static Contract_File CreateContract_File()
		{
			return InitializeNew<Contract_File>();
		}
		
		/// <summary>
		/// Retrieve information for a Contract_File by a Contract_File's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Contract_File</returns>
		public static Contract_File GetContract_File(int @iD)
		{
			string commandText = @"
SELECT 
" + Contract_File.SelectFieldList + @"
FROM [dbo].[Contract_File] 
WHERE 
	[Contract_File].[ID] = @ID " + Contract_File.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_File>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Contract_File by a Contract_File's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Contract_File</returns>
		public static Contract_File GetContract_File(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Contract_File.SelectFieldList + @"
FROM [dbo].[Contract_File] 
WHERE 
	[Contract_File].[ID] = @ID " + Contract_File.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_File>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Contract_File objects.
		/// </summary>
		/// <returns>The retrieved collection of Contract_File objects.</returns>
		public static EntityList<Contract_File> GetContract_Files()
		{
			string commandText = @"
SELECT " + Contract_File.SelectFieldList + "FROM [dbo].[Contract_File] " + Contract_File.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Contract_File>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Contract_File objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_File objects.</returns>
        public static EntityList<Contract_File> GetContract_Files(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_File>(SelectFieldList, "FROM [dbo].[Contract_File]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Contract_File objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_File objects.</returns>
        public static EntityList<Contract_File> GetContract_Files(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_File>(SelectFieldList, "FROM [dbo].[Contract_File]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Contract_File objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Contract_File objects.</returns>
		protected static EntityList<Contract_File> GetContract_Files(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Files(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Contract_File objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_File objects.</returns>
		protected static EntityList<Contract_File> GetContract_Files(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Files(string.Empty, where, parameters, Contract_File.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_File objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_File objects.</returns>
		protected static EntityList<Contract_File> GetContract_Files(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Files(prefix, where, parameters, Contract_File.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_File objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_File objects.</returns>
		protected static EntityList<Contract_File> GetContract_Files(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_Files(string.Empty, where, parameters, Contract_File.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_File objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_File objects.</returns>
		protected static EntityList<Contract_File> GetContract_Files(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_Files(prefix, where, parameters, Contract_File.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_File objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Contract_File objects.</returns>
		protected static EntityList<Contract_File> GetContract_Files(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Contract_File.SelectFieldList + "FROM [dbo].[Contract_File] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Contract_File>(reader);
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
        protected static EntityList<Contract_File> GetContract_Files(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_File>(SelectFieldList, "FROM [dbo].[Contract_File] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Contract_File objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_FileCount()
        {
            return GetContract_FileCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Contract_File objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_FileCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Contract_File] " + where;

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
		public static partial class Contract_File_Properties
		{
			public const string ID = "ID";
			public const string RelateID = "RelateID";
			public const string AttachedFilePath = "AttachedFilePath";
			public const string AddTime = "AddTime";
			public const string FileOriName = "FileOriName";
			public const string FileType = "FileType";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RelateID" , "int:"},
    			 {"AttachedFilePath" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"FileOriName" , "string:"},
    			 {"FileType" , "string:"},
            };
		}
		#endregion
	}
}
