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
	/// This object represents the properties and methods of a DeviceTask_Image.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class DeviceTask_Image 
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
		private int _deviceTaskID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int DeviceTaskID
		{
			[DebuggerStepThrough()]
			get { return this._deviceTaskID; }
			set 
			{
				if (this._deviceTaskID != value) 
				{
					this._deviceTaskID = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeviceTaskID");
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
	[DeviceTaskID] int,
	[AttachedFilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

INSERT INTO [dbo].[DeviceTask_Image] (
	[DeviceTask_Image].[DeviceTaskID],
	[DeviceTask_Image].[AttachedFilePath],
	[DeviceTask_Image].[AddTime],
	[DeviceTask_Image].[FileOriName]
) 
output 
	INSERTED.[ID],
	INSERTED.[DeviceTaskID],
	INSERTED.[AttachedFilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
VALUES ( 
	@DeviceTaskID,
	@AttachedFilePath,
	@AddTime,
	@FileOriName 
); 

SELECT 
	[ID],
	[DeviceTaskID],
	[AttachedFilePath],
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
	[DeviceTaskID] int,
	[AttachedFilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

UPDATE [dbo].[DeviceTask_Image] SET 
	[DeviceTask_Image].[DeviceTaskID] = @DeviceTaskID,
	[DeviceTask_Image].[AttachedFilePath] = @AttachedFilePath,
	[DeviceTask_Image].[AddTime] = @AddTime,
	[DeviceTask_Image].[FileOriName] = @FileOriName 
output 
	INSERTED.[ID],
	INSERTED.[DeviceTaskID],
	INSERTED.[AttachedFilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
WHERE 
	[DeviceTask_Image].[ID] = @ID

SELECT 
	[ID],
	[DeviceTaskID],
	[AttachedFilePath],
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
DELETE FROM [dbo].[DeviceTask_Image]
WHERE 
	[DeviceTask_Image].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public DeviceTask_Image() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetDeviceTask_Image(this.ID));
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
	[DeviceTask_Image].[ID],
	[DeviceTask_Image].[DeviceTaskID],
	[DeviceTask_Image].[AttachedFilePath],
	[DeviceTask_Image].[AddTime],
	[DeviceTask_Image].[FileOriName]
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
                return "DeviceTask_Image";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a DeviceTask_Image into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="deviceTaskID">deviceTaskID</param>
		/// <param name="attachedFilePath">attachedFilePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		public static void InsertDeviceTask_Image(int @deviceTaskID, string @attachedFilePath, DateTime @addTime, string @fileOriName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertDeviceTask_Image(@deviceTaskID, @attachedFilePath, @addTime, @fileOriName, helper);
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
		/// Insert a DeviceTask_Image into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="deviceTaskID">deviceTaskID</param>
		/// <param name="attachedFilePath">attachedFilePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="helper">helper</param>
		internal static void InsertDeviceTask_Image(int @deviceTaskID, string @attachedFilePath, DateTime @addTime, string @fileOriName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DeviceTaskID] int,
	[AttachedFilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

INSERT INTO [dbo].[DeviceTask_Image] (
	[DeviceTask_Image].[DeviceTaskID],
	[DeviceTask_Image].[AttachedFilePath],
	[DeviceTask_Image].[AddTime],
	[DeviceTask_Image].[FileOriName]
) 
output 
	INSERTED.[ID],
	INSERTED.[DeviceTaskID],
	INSERTED.[AttachedFilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
VALUES ( 
	@DeviceTaskID,
	@AttachedFilePath,
	@AddTime,
	@FileOriName 
); 

SELECT 
	[ID],
	[DeviceTaskID],
	[AttachedFilePath],
	[AddTime],
	[FileOriName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DeviceTaskID", EntityBase.GetDatabaseValue(@deviceTaskID)));
			parameters.Add(new SqlParameter("@AttachedFilePath", EntityBase.GetDatabaseValue(@attachedFilePath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@FileOriName", EntityBase.GetDatabaseValue(@fileOriName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a DeviceTask_Image into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="deviceTaskID">deviceTaskID</param>
		/// <param name="attachedFilePath">attachedFilePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		public static void UpdateDeviceTask_Image(int @iD, int @deviceTaskID, string @attachedFilePath, DateTime @addTime, string @fileOriName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateDeviceTask_Image(@iD, @deviceTaskID, @attachedFilePath, @addTime, @fileOriName, helper);
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
		/// Updates a DeviceTask_Image into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="deviceTaskID">deviceTaskID</param>
		/// <param name="attachedFilePath">attachedFilePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateDeviceTask_Image(int @iD, int @deviceTaskID, string @attachedFilePath, DateTime @addTime, string @fileOriName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DeviceTaskID] int,
	[AttachedFilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

UPDATE [dbo].[DeviceTask_Image] SET 
	[DeviceTask_Image].[DeviceTaskID] = @DeviceTaskID,
	[DeviceTask_Image].[AttachedFilePath] = @AttachedFilePath,
	[DeviceTask_Image].[AddTime] = @AddTime,
	[DeviceTask_Image].[FileOriName] = @FileOriName 
output 
	INSERTED.[ID],
	INSERTED.[DeviceTaskID],
	INSERTED.[AttachedFilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
WHERE 
	[DeviceTask_Image].[ID] = @ID

SELECT 
	[ID],
	[DeviceTaskID],
	[AttachedFilePath],
	[AddTime],
	[FileOriName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@DeviceTaskID", EntityBase.GetDatabaseValue(@deviceTaskID)));
			parameters.Add(new SqlParameter("@AttachedFilePath", EntityBase.GetDatabaseValue(@attachedFilePath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@FileOriName", EntityBase.GetDatabaseValue(@fileOriName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a DeviceTask_Image from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteDeviceTask_Image(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteDeviceTask_Image(@iD, helper);
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
		/// Deletes a DeviceTask_Image from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteDeviceTask_Image(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[DeviceTask_Image]
WHERE 
	[DeviceTask_Image].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new DeviceTask_Image object.
		/// </summary>
		/// <returns>The newly created DeviceTask_Image object.</returns>
		public static DeviceTask_Image CreateDeviceTask_Image()
		{
			return InitializeNew<DeviceTask_Image>();
		}
		
		/// <summary>
		/// Retrieve information for a DeviceTask_Image by a DeviceTask_Image's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>DeviceTask_Image</returns>
		public static DeviceTask_Image GetDeviceTask_Image(int @iD)
		{
			string commandText = @"
SELECT 
" + DeviceTask_Image.SelectFieldList + @"
FROM [dbo].[DeviceTask_Image] 
WHERE 
	[DeviceTask_Image].[ID] = @ID " + DeviceTask_Image.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<DeviceTask_Image>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a DeviceTask_Image by a DeviceTask_Image's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>DeviceTask_Image</returns>
		public static DeviceTask_Image GetDeviceTask_Image(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + DeviceTask_Image.SelectFieldList + @"
FROM [dbo].[DeviceTask_Image] 
WHERE 
	[DeviceTask_Image].[ID] = @ID " + DeviceTask_Image.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<DeviceTask_Image>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection DeviceTask_Image objects.
		/// </summary>
		/// <returns>The retrieved collection of DeviceTask_Image objects.</returns>
		public static EntityList<DeviceTask_Image> GetDeviceTask_Images()
		{
			string commandText = @"
SELECT " + DeviceTask_Image.SelectFieldList + "FROM [dbo].[DeviceTask_Image] " + DeviceTask_Image.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<DeviceTask_Image>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection DeviceTask_Image objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of DeviceTask_Image objects.</returns>
        public static EntityList<DeviceTask_Image> GetDeviceTask_Images(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<DeviceTask_Image>(SelectFieldList, "FROM [dbo].[DeviceTask_Image]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection DeviceTask_Image objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of DeviceTask_Image objects.</returns>
        public static EntityList<DeviceTask_Image> GetDeviceTask_Images(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<DeviceTask_Image>(SelectFieldList, "FROM [dbo].[DeviceTask_Image]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection DeviceTask_Image objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of DeviceTask_Image objects.</returns>
		protected static EntityList<DeviceTask_Image> GetDeviceTask_Images(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDeviceTask_Images(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection DeviceTask_Image objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of DeviceTask_Image objects.</returns>
		protected static EntityList<DeviceTask_Image> GetDeviceTask_Images(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDeviceTask_Images(string.Empty, where, parameters, DeviceTask_Image.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection DeviceTask_Image objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of DeviceTask_Image objects.</returns>
		protected static EntityList<DeviceTask_Image> GetDeviceTask_Images(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDeviceTask_Images(prefix, where, parameters, DeviceTask_Image.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection DeviceTask_Image objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of DeviceTask_Image objects.</returns>
		protected static EntityList<DeviceTask_Image> GetDeviceTask_Images(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetDeviceTask_Images(string.Empty, where, parameters, DeviceTask_Image.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection DeviceTask_Image objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of DeviceTask_Image objects.</returns>
		protected static EntityList<DeviceTask_Image> GetDeviceTask_Images(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetDeviceTask_Images(prefix, where, parameters, DeviceTask_Image.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection DeviceTask_Image objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of DeviceTask_Image objects.</returns>
		protected static EntityList<DeviceTask_Image> GetDeviceTask_Images(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + DeviceTask_Image.SelectFieldList + "FROM [dbo].[DeviceTask_Image] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<DeviceTask_Image>(reader);
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
        protected static EntityList<DeviceTask_Image> GetDeviceTask_Images(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<DeviceTask_Image>(SelectFieldList, "FROM [dbo].[DeviceTask_Image] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of DeviceTask_Image objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetDeviceTask_ImageCount()
        {
            return GetDeviceTask_ImageCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of DeviceTask_Image objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetDeviceTask_ImageCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[DeviceTask_Image] " + where;

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
		public static partial class DeviceTask_Image_Properties
		{
			public const string ID = "ID";
			public const string DeviceTaskID = "DeviceTaskID";
			public const string AttachedFilePath = "AttachedFilePath";
			public const string AddTime = "AddTime";
			public const string FileOriName = "FileOriName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"DeviceTaskID" , "int:"},
    			 {"AttachedFilePath" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"FileOriName" , "string:"},
            };
		}
		#endregion
	}
}
