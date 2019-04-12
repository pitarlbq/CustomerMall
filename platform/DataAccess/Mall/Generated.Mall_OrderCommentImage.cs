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
	/// This object represents the properties and methods of a Mall_OrderCommentImage.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_OrderCommentImage 
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
		private int _orderCommentID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int OrderCommentID
		{
			[DebuggerStepThrough()]
			get { return this._orderCommentID; }
			set 
			{
				if (this._orderCommentID != value) 
				{
					this._orderCommentID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderCommentID");
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
	[OrderCommentID] int,
	[ImagePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] ntext
);

INSERT INTO [dbo].[Mall_OrderCommentImage] (
	[Mall_OrderCommentImage].[OrderCommentID],
	[Mall_OrderCommentImage].[ImagePath],
	[Mall_OrderCommentImage].[AddTime],
	[Mall_OrderCommentImage].[FileOriName]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrderCommentID],
	INSERTED.[ImagePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
VALUES ( 
	@OrderCommentID,
	@ImagePath,
	@AddTime,
	@FileOriName 
); 

SELECT 
	[ID],
	[OrderCommentID],
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
	[OrderCommentID] int,
	[ImagePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] ntext
);

UPDATE [dbo].[Mall_OrderCommentImage] SET 
	[Mall_OrderCommentImage].[OrderCommentID] = @OrderCommentID,
	[Mall_OrderCommentImage].[ImagePath] = @ImagePath,
	[Mall_OrderCommentImage].[AddTime] = @AddTime,
	[Mall_OrderCommentImage].[FileOriName] = @FileOriName 
output 
	INSERTED.[ID],
	INSERTED.[OrderCommentID],
	INSERTED.[ImagePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
WHERE 
	[Mall_OrderCommentImage].[ID] = @ID

SELECT 
	[ID],
	[OrderCommentID],
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
DELETE FROM [dbo].[Mall_OrderCommentImage]
WHERE 
	[Mall_OrderCommentImage].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_OrderCommentImage() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_OrderCommentImage(this.ID));
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
	[Mall_OrderCommentImage].[ID],
	[Mall_OrderCommentImage].[OrderCommentID],
	[Mall_OrderCommentImage].[ImagePath],
	[Mall_OrderCommentImage].[AddTime],
	[Mall_OrderCommentImage].[FileOriName]
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
                return "Mall_OrderCommentImage";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_OrderCommentImage into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderCommentID">orderCommentID</param>
		/// <param name="imagePath">imagePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		public static void InsertMall_OrderCommentImage(int @orderCommentID, string @imagePath, DateTime @addTime, string @fileOriName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_OrderCommentImage(@orderCommentID, @imagePath, @addTime, @fileOriName, helper);
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
		/// Insert a Mall_OrderCommentImage into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderCommentID">orderCommentID</param>
		/// <param name="imagePath">imagePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_OrderCommentImage(int @orderCommentID, string @imagePath, DateTime @addTime, string @fileOriName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrderCommentID] int,
	[ImagePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] ntext
);

INSERT INTO [dbo].[Mall_OrderCommentImage] (
	[Mall_OrderCommentImage].[OrderCommentID],
	[Mall_OrderCommentImage].[ImagePath],
	[Mall_OrderCommentImage].[AddTime],
	[Mall_OrderCommentImage].[FileOriName]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrderCommentID],
	INSERTED.[ImagePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
VALUES ( 
	@OrderCommentID,
	@ImagePath,
	@AddTime,
	@FileOriName 
); 

SELECT 
	[ID],
	[OrderCommentID],
	[ImagePath],
	[AddTime],
	[FileOriName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OrderCommentID", EntityBase.GetDatabaseValue(@orderCommentID)));
			parameters.Add(new SqlParameter("@ImagePath", EntityBase.GetDatabaseValue(@imagePath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@FileOriName", EntityBase.GetDatabaseValue(@fileOriName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_OrderCommentImage into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orderCommentID">orderCommentID</param>
		/// <param name="imagePath">imagePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		public static void UpdateMall_OrderCommentImage(int @iD, int @orderCommentID, string @imagePath, DateTime @addTime, string @fileOriName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_OrderCommentImage(@iD, @orderCommentID, @imagePath, @addTime, @fileOriName, helper);
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
		/// Updates a Mall_OrderCommentImage into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orderCommentID">orderCommentID</param>
		/// <param name="imagePath">imagePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_OrderCommentImage(int @iD, int @orderCommentID, string @imagePath, DateTime @addTime, string @fileOriName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrderCommentID] int,
	[ImagePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] ntext
);

UPDATE [dbo].[Mall_OrderCommentImage] SET 
	[Mall_OrderCommentImage].[OrderCommentID] = @OrderCommentID,
	[Mall_OrderCommentImage].[ImagePath] = @ImagePath,
	[Mall_OrderCommentImage].[AddTime] = @AddTime,
	[Mall_OrderCommentImage].[FileOriName] = @FileOriName 
output 
	INSERTED.[ID],
	INSERTED.[OrderCommentID],
	INSERTED.[ImagePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
WHERE 
	[Mall_OrderCommentImage].[ID] = @ID

SELECT 
	[ID],
	[OrderCommentID],
	[ImagePath],
	[AddTime],
	[FileOriName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OrderCommentID", EntityBase.GetDatabaseValue(@orderCommentID)));
			parameters.Add(new SqlParameter("@ImagePath", EntityBase.GetDatabaseValue(@imagePath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@FileOriName", EntityBase.GetDatabaseValue(@fileOriName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_OrderCommentImage from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_OrderCommentImage(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_OrderCommentImage(@iD, helper);
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
		/// Deletes a Mall_OrderCommentImage from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_OrderCommentImage(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_OrderCommentImage]
WHERE 
	[Mall_OrderCommentImage].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_OrderCommentImage object.
		/// </summary>
		/// <returns>The newly created Mall_OrderCommentImage object.</returns>
		public static Mall_OrderCommentImage CreateMall_OrderCommentImage()
		{
			return InitializeNew<Mall_OrderCommentImage>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_OrderCommentImage by a Mall_OrderCommentImage's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_OrderCommentImage</returns>
		public static Mall_OrderCommentImage GetMall_OrderCommentImage(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_OrderCommentImage.SelectFieldList + @"
FROM [dbo].[Mall_OrderCommentImage] 
WHERE 
	[Mall_OrderCommentImage].[ID] = @ID " + Mall_OrderCommentImage.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_OrderCommentImage>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_OrderCommentImage by a Mall_OrderCommentImage's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_OrderCommentImage</returns>
		public static Mall_OrderCommentImage GetMall_OrderCommentImage(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_OrderCommentImage.SelectFieldList + @"
FROM [dbo].[Mall_OrderCommentImage] 
WHERE 
	[Mall_OrderCommentImage].[ID] = @ID " + Mall_OrderCommentImage.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_OrderCommentImage>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderCommentImage objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_OrderCommentImage objects.</returns>
		public static EntityList<Mall_OrderCommentImage> GetMall_OrderCommentImages()
		{
			string commandText = @"
SELECT " + Mall_OrderCommentImage.SelectFieldList + "FROM [dbo].[Mall_OrderCommentImage] " + Mall_OrderCommentImage.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_OrderCommentImage>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_OrderCommentImage objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_OrderCommentImage objects.</returns>
        public static EntityList<Mall_OrderCommentImage> GetMall_OrderCommentImages(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_OrderCommentImage>(SelectFieldList, "FROM [dbo].[Mall_OrderCommentImage]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_OrderCommentImage objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_OrderCommentImage objects.</returns>
        public static EntityList<Mall_OrderCommentImage> GetMall_OrderCommentImages(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_OrderCommentImage>(SelectFieldList, "FROM [dbo].[Mall_OrderCommentImage]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_OrderCommentImage objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_OrderCommentImage objects.</returns>
		protected static EntityList<Mall_OrderCommentImage> GetMall_OrderCommentImages(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_OrderCommentImages(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderCommentImage objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderCommentImage objects.</returns>
		protected static EntityList<Mall_OrderCommentImage> GetMall_OrderCommentImages(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_OrderCommentImages(string.Empty, where, parameters, Mall_OrderCommentImage.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderCommentImage objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderCommentImage objects.</returns>
		protected static EntityList<Mall_OrderCommentImage> GetMall_OrderCommentImages(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_OrderCommentImages(prefix, where, parameters, Mall_OrderCommentImage.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderCommentImage objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderCommentImage objects.</returns>
		protected static EntityList<Mall_OrderCommentImage> GetMall_OrderCommentImages(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_OrderCommentImages(string.Empty, where, parameters, Mall_OrderCommentImage.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderCommentImage objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderCommentImage objects.</returns>
		protected static EntityList<Mall_OrderCommentImage> GetMall_OrderCommentImages(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_OrderCommentImages(prefix, where, parameters, Mall_OrderCommentImage.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderCommentImage objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_OrderCommentImage objects.</returns>
		protected static EntityList<Mall_OrderCommentImage> GetMall_OrderCommentImages(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_OrderCommentImage.SelectFieldList + "FROM [dbo].[Mall_OrderCommentImage] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_OrderCommentImage>(reader);
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
        protected static EntityList<Mall_OrderCommentImage> GetMall_OrderCommentImages(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_OrderCommentImage>(SelectFieldList, "FROM [dbo].[Mall_OrderCommentImage] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_OrderCommentImage objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_OrderCommentImageCount()
        {
            return GetMall_OrderCommentImageCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_OrderCommentImage objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_OrderCommentImageCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_OrderCommentImage] " + where;

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
		public static partial class Mall_OrderCommentImage_Properties
		{
			public const string ID = "ID";
			public const string OrderCommentID = "OrderCommentID";
			public const string ImagePath = "ImagePath";
			public const string AddTime = "AddTime";
			public const string FileOriName = "FileOriName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OrderCommentID" , "int:"},
    			 {"ImagePath" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"FileOriName" , "string:"},
            };
		}
		#endregion
	}
}
