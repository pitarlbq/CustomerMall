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
	/// This object represents the properties and methods of a Mall_ThreadImage.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_ThreadImage 
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
		private int _threadID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ThreadID
		{
			[DebuggerStepThrough()]
			get { return this._threadID; }
			set 
			{
				if (this._threadID != value) 
				{
					this._threadID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ThreadID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _imagePath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string ImagePath
		{
			[DebuggerStepThrough()]
			get { return this._imagePath; }
			set 
			{
				if (this._imagePath != value) 
				{
					this._imagePath = value;
					this.IsDirty = true;	
					OnPropertyChanged("ImagePath");
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
		[DataObjectField(false, false, false)]
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
	[ThreadID] int,
	[ImagePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

INSERT INTO [dbo].[Mall_ThreadImage] (
	[Mall_ThreadImage].[ThreadID],
	[Mall_ThreadImage].[ImagePath],
	[Mall_ThreadImage].[AddTime],
	[Mall_ThreadImage].[FileOriName]
) 
output 
	INSERTED.[ID],
	INSERTED.[ThreadID],
	INSERTED.[ImagePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
VALUES ( 
	@ThreadID,
	@ImagePath,
	@AddTime,
	@FileOriName 
); 

SELECT 
	[ID],
	[ThreadID],
	[ImagePath],
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
	[ThreadID] int,
	[ImagePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

UPDATE [dbo].[Mall_ThreadImage] SET 
	[Mall_ThreadImage].[ThreadID] = @ThreadID,
	[Mall_ThreadImage].[ImagePath] = @ImagePath,
	[Mall_ThreadImage].[AddTime] = @AddTime,
	[Mall_ThreadImage].[FileOriName] = @FileOriName 
output 
	INSERTED.[ID],
	INSERTED.[ThreadID],
	INSERTED.[ImagePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
WHERE 
	[Mall_ThreadImage].[ID] = @ID

SELECT 
	[ID],
	[ThreadID],
	[ImagePath],
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
DELETE FROM [dbo].[Mall_ThreadImage]
WHERE 
	[Mall_ThreadImage].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_ThreadImage() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_ThreadImage(this.ID));
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
	[Mall_ThreadImage].[ID],
	[Mall_ThreadImage].[ThreadID],
	[Mall_ThreadImage].[ImagePath],
	[Mall_ThreadImage].[AddTime],
	[Mall_ThreadImage].[FileOriName]
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
                return "Mall_ThreadImage";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_ThreadImage into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="threadID">threadID</param>
		/// <param name="imagePath">imagePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		public static void InsertMall_ThreadImage(int @threadID, string @imagePath, DateTime @addTime, string @fileOriName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_ThreadImage(@threadID, @imagePath, @addTime, @fileOriName, helper);
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
		/// Insert a Mall_ThreadImage into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="threadID">threadID</param>
		/// <param name="imagePath">imagePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_ThreadImage(int @threadID, string @imagePath, DateTime @addTime, string @fileOriName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ThreadID] int,
	[ImagePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

INSERT INTO [dbo].[Mall_ThreadImage] (
	[Mall_ThreadImage].[ThreadID],
	[Mall_ThreadImage].[ImagePath],
	[Mall_ThreadImage].[AddTime],
	[Mall_ThreadImage].[FileOriName]
) 
output 
	INSERTED.[ID],
	INSERTED.[ThreadID],
	INSERTED.[ImagePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
VALUES ( 
	@ThreadID,
	@ImagePath,
	@AddTime,
	@FileOriName 
); 

SELECT 
	[ID],
	[ThreadID],
	[ImagePath],
	[AddTime],
	[FileOriName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ThreadID", EntityBase.GetDatabaseValue(@threadID)));
			parameters.Add(new SqlParameter("@ImagePath", EntityBase.GetDatabaseValue(@imagePath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@FileOriName", EntityBase.GetDatabaseValue(@fileOriName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_ThreadImage into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="threadID">threadID</param>
		/// <param name="imagePath">imagePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		public static void UpdateMall_ThreadImage(int @iD, int @threadID, string @imagePath, DateTime @addTime, string @fileOriName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_ThreadImage(@iD, @threadID, @imagePath, @addTime, @fileOriName, helper);
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
		/// Updates a Mall_ThreadImage into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="threadID">threadID</param>
		/// <param name="imagePath">imagePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_ThreadImage(int @iD, int @threadID, string @imagePath, DateTime @addTime, string @fileOriName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ThreadID] int,
	[ImagePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

UPDATE [dbo].[Mall_ThreadImage] SET 
	[Mall_ThreadImage].[ThreadID] = @ThreadID,
	[Mall_ThreadImage].[ImagePath] = @ImagePath,
	[Mall_ThreadImage].[AddTime] = @AddTime,
	[Mall_ThreadImage].[FileOriName] = @FileOriName 
output 
	INSERTED.[ID],
	INSERTED.[ThreadID],
	INSERTED.[ImagePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
WHERE 
	[Mall_ThreadImage].[ID] = @ID

SELECT 
	[ID],
	[ThreadID],
	[ImagePath],
	[AddTime],
	[FileOriName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ThreadID", EntityBase.GetDatabaseValue(@threadID)));
			parameters.Add(new SqlParameter("@ImagePath", EntityBase.GetDatabaseValue(@imagePath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@FileOriName", EntityBase.GetDatabaseValue(@fileOriName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_ThreadImage from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_ThreadImage(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_ThreadImage(@iD, helper);
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
		/// Deletes a Mall_ThreadImage from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_ThreadImage(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_ThreadImage]
WHERE 
	[Mall_ThreadImage].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_ThreadImage object.
		/// </summary>
		/// <returns>The newly created Mall_ThreadImage object.</returns>
		public static Mall_ThreadImage CreateMall_ThreadImage()
		{
			return InitializeNew<Mall_ThreadImage>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_ThreadImage by a Mall_ThreadImage's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_ThreadImage</returns>
		public static Mall_ThreadImage GetMall_ThreadImage(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_ThreadImage.SelectFieldList + @"
FROM [dbo].[Mall_ThreadImage] 
WHERE 
	[Mall_ThreadImage].[ID] = @ID " + Mall_ThreadImage.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ThreadImage>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_ThreadImage by a Mall_ThreadImage's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_ThreadImage</returns>
		public static Mall_ThreadImage GetMall_ThreadImage(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_ThreadImage.SelectFieldList + @"
FROM [dbo].[Mall_ThreadImage] 
WHERE 
	[Mall_ThreadImage].[ID] = @ID " + Mall_ThreadImage.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ThreadImage>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_ThreadImage objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_ThreadImage objects.</returns>
		public static EntityList<Mall_ThreadImage> GetMall_ThreadImages()
		{
			string commandText = @"
SELECT " + Mall_ThreadImage.SelectFieldList + "FROM [dbo].[Mall_ThreadImage] " + Mall_ThreadImage.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_ThreadImage>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_ThreadImage objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ThreadImage objects.</returns>
        public static EntityList<Mall_ThreadImage> GetMall_ThreadImages(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ThreadImage>(SelectFieldList, "FROM [dbo].[Mall_ThreadImage]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_ThreadImage objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ThreadImage objects.</returns>
        public static EntityList<Mall_ThreadImage> GetMall_ThreadImages(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ThreadImage>(SelectFieldList, "FROM [dbo].[Mall_ThreadImage]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_ThreadImage objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ThreadImage objects.</returns>
		protected static EntityList<Mall_ThreadImage> GetMall_ThreadImages(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ThreadImages(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_ThreadImage objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ThreadImage objects.</returns>
		protected static EntityList<Mall_ThreadImage> GetMall_ThreadImages(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ThreadImages(string.Empty, where, parameters, Mall_ThreadImage.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ThreadImage objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ThreadImage objects.</returns>
		protected static EntityList<Mall_ThreadImage> GetMall_ThreadImages(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ThreadImages(prefix, where, parameters, Mall_ThreadImage.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ThreadImage objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ThreadImage objects.</returns>
		protected static EntityList<Mall_ThreadImage> GetMall_ThreadImages(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ThreadImages(string.Empty, where, parameters, Mall_ThreadImage.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ThreadImage objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ThreadImage objects.</returns>
		protected static EntityList<Mall_ThreadImage> GetMall_ThreadImages(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ThreadImages(prefix, where, parameters, Mall_ThreadImage.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ThreadImage objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ThreadImage objects.</returns>
		protected static EntityList<Mall_ThreadImage> GetMall_ThreadImages(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_ThreadImage.SelectFieldList + "FROM [dbo].[Mall_ThreadImage] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_ThreadImage>(reader);
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
        protected static EntityList<Mall_ThreadImage> GetMall_ThreadImages(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ThreadImage>(SelectFieldList, "FROM [dbo].[Mall_ThreadImage] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_ThreadImage objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ThreadImageCount()
        {
            return GetMall_ThreadImageCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_ThreadImage objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ThreadImageCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_ThreadImage] " + where;

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
		public static partial class Mall_ThreadImage_Properties
		{
			public const string ID = "ID";
			public const string ThreadID = "ThreadID";
			public const string ImagePath = "ImagePath";
			public const string AddTime = "AddTime";
			public const string FileOriName = "FileOriName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ThreadID" , "int:"},
    			 {"ImagePath" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"FileOriName" , "string:"},
            };
		}
		#endregion
	}
}
