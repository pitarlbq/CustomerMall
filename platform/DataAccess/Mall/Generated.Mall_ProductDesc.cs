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
	/// This object represents the properties and methods of a Mall_ProductDesc.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_ProductDesc 
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
		private int _productID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ProductID
		{
			[DebuggerStepThrough()]
			get { return this._productID; }
			set 
			{
				if (this._productID != value) 
				{
					this._productID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _gUID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string GUID
		{
			[DebuggerStepThrough()]
			get { return this._gUID; }
			set 
			{
				if (this._gUID != value) 
				{
					this._gUID = value;
					this.IsDirty = true;	
					OnPropertyChanged("GUID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _sortOrder = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int SortOrder
		{
			[DebuggerStepThrough()]
			get { return this._sortOrder; }
			set 
			{
				if (this._sortOrder != value) 
				{
					this._sortOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("SortOrder");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _type = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string Type
		{
			[DebuggerStepThrough()]
			get { return this._type; }
			set 
			{
				if (this._type != value) 
				{
					this._type = value;
					this.IsDirty = true;	
					OnPropertyChanged("Type");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _textContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TextContent
		{
			[DebuggerStepThrough()]
			get { return this._textContent; }
			set 
			{
				if (this._textContent != value) 
				{
					this._textContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("TextContent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _imageUrl = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ImageUrl
		{
			[DebuggerStepThrough()]
			get { return this._imageUrl; }
			set 
			{
				if (this._imageUrl != value) 
				{
					this._imageUrl = value;
					this.IsDirty = true;	
					OnPropertyChanged("ImageUrl");
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
		private string _addMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
	[ProductID] int,
	[GUID] nvarchar(500),
	[SortOrder] int,
	[Type] nvarchar(50),
	[TextContent] ntext,
	[ImageUrl] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

INSERT INTO [dbo].[Mall_ProductDesc] (
	[Mall_ProductDesc].[ProductID],
	[Mall_ProductDesc].[GUID],
	[Mall_ProductDesc].[SortOrder],
	[Mall_ProductDesc].[Type],
	[Mall_ProductDesc].[TextContent],
	[Mall_ProductDesc].[ImageUrl],
	[Mall_ProductDesc].[AddTime],
	[Mall_ProductDesc].[AddMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[GUID],
	INSERTED.[SortOrder],
	INSERTED.[Type],
	INSERTED.[TextContent],
	INSERTED.[ImageUrl],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
VALUES ( 
	@ProductID,
	@GUID,
	@SortOrder,
	@Type,
	@TextContent,
	@ImageUrl,
	@AddTime,
	@AddMan 
); 

SELECT 
	[ID],
	[ProductID],
	[GUID],
	[SortOrder],
	[Type],
	[TextContent],
	[ImageUrl],
	[AddTime],
	[AddMan] 
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
	[ProductID] int,
	[GUID] nvarchar(500),
	[SortOrder] int,
	[Type] nvarchar(50),
	[TextContent] ntext,
	[ImageUrl] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

UPDATE [dbo].[Mall_ProductDesc] SET 
	[Mall_ProductDesc].[ProductID] = @ProductID,
	[Mall_ProductDesc].[GUID] = @GUID,
	[Mall_ProductDesc].[SortOrder] = @SortOrder,
	[Mall_ProductDesc].[Type] = @Type,
	[Mall_ProductDesc].[TextContent] = @TextContent,
	[Mall_ProductDesc].[ImageUrl] = @ImageUrl,
	[Mall_ProductDesc].[AddTime] = @AddTime,
	[Mall_ProductDesc].[AddMan] = @AddMan 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[GUID],
	INSERTED.[SortOrder],
	INSERTED.[Type],
	INSERTED.[TextContent],
	INSERTED.[ImageUrl],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
WHERE 
	[Mall_ProductDesc].[ID] = @ID

SELECT 
	[ID],
	[ProductID],
	[GUID],
	[SortOrder],
	[Type],
	[TextContent],
	[ImageUrl],
	[AddTime],
	[AddMan] 
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
DELETE FROM [dbo].[Mall_ProductDesc]
WHERE 
	[Mall_ProductDesc].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_ProductDesc() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_ProductDesc(this.ID));
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
	[Mall_ProductDesc].[ID],
	[Mall_ProductDesc].[ProductID],
	[Mall_ProductDesc].[GUID],
	[Mall_ProductDesc].[SortOrder],
	[Mall_ProductDesc].[Type],
	[Mall_ProductDesc].[TextContent],
	[Mall_ProductDesc].[ImageUrl],
	[Mall_ProductDesc].[AddTime],
	[Mall_ProductDesc].[AddMan]
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
                return "Mall_ProductDesc";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_ProductDesc into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productID">productID</param>
		/// <param name="gUID">gUID</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="type">type</param>
		/// <param name="textContent">textContent</param>
		/// <param name="imageUrl">imageUrl</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		public static void InsertMall_ProductDesc(int @productID, string @gUID, int @sortOrder, string @type, string @textContent, string @imageUrl, DateTime @addTime, string @addMan)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_ProductDesc(@productID, @gUID, @sortOrder, @type, @textContent, @imageUrl, @addTime, @addMan, helper);
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
		/// Insert a Mall_ProductDesc into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productID">productID</param>
		/// <param name="gUID">gUID</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="type">type</param>
		/// <param name="textContent">textContent</param>
		/// <param name="imageUrl">imageUrl</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_ProductDesc(int @productID, string @gUID, int @sortOrder, string @type, string @textContent, string @imageUrl, DateTime @addTime, string @addMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProductID] int,
	[GUID] nvarchar(500),
	[SortOrder] int,
	[Type] nvarchar(50),
	[TextContent] ntext,
	[ImageUrl] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

INSERT INTO [dbo].[Mall_ProductDesc] (
	[Mall_ProductDesc].[ProductID],
	[Mall_ProductDesc].[GUID],
	[Mall_ProductDesc].[SortOrder],
	[Mall_ProductDesc].[Type],
	[Mall_ProductDesc].[TextContent],
	[Mall_ProductDesc].[ImageUrl],
	[Mall_ProductDesc].[AddTime],
	[Mall_ProductDesc].[AddMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[GUID],
	INSERTED.[SortOrder],
	INSERTED.[Type],
	INSERTED.[TextContent],
	INSERTED.[ImageUrl],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
VALUES ( 
	@ProductID,
	@GUID,
	@SortOrder,
	@Type,
	@TextContent,
	@ImageUrl,
	@AddTime,
	@AddMan 
); 

SELECT 
	[ID],
	[ProductID],
	[GUID],
	[SortOrder],
	[Type],
	[TextContent],
	[ImageUrl],
	[AddTime],
	[AddMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@Type", EntityBase.GetDatabaseValue(@type)));
			parameters.Add(new SqlParameter("@TextContent", EntityBase.GetDatabaseValue(@textContent)));
			parameters.Add(new SqlParameter("@ImageUrl", EntityBase.GetDatabaseValue(@imageUrl)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_ProductDesc into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="productID">productID</param>
		/// <param name="gUID">gUID</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="type">type</param>
		/// <param name="textContent">textContent</param>
		/// <param name="imageUrl">imageUrl</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		public static void UpdateMall_ProductDesc(int @iD, int @productID, string @gUID, int @sortOrder, string @type, string @textContent, string @imageUrl, DateTime @addTime, string @addMan)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_ProductDesc(@iD, @productID, @gUID, @sortOrder, @type, @textContent, @imageUrl, @addTime, @addMan, helper);
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
		/// Updates a Mall_ProductDesc into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="productID">productID</param>
		/// <param name="gUID">gUID</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="type">type</param>
		/// <param name="textContent">textContent</param>
		/// <param name="imageUrl">imageUrl</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_ProductDesc(int @iD, int @productID, string @gUID, int @sortOrder, string @type, string @textContent, string @imageUrl, DateTime @addTime, string @addMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProductID] int,
	[GUID] nvarchar(500),
	[SortOrder] int,
	[Type] nvarchar(50),
	[TextContent] ntext,
	[ImageUrl] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

UPDATE [dbo].[Mall_ProductDesc] SET 
	[Mall_ProductDesc].[ProductID] = @ProductID,
	[Mall_ProductDesc].[GUID] = @GUID,
	[Mall_ProductDesc].[SortOrder] = @SortOrder,
	[Mall_ProductDesc].[Type] = @Type,
	[Mall_ProductDesc].[TextContent] = @TextContent,
	[Mall_ProductDesc].[ImageUrl] = @ImageUrl,
	[Mall_ProductDesc].[AddTime] = @AddTime,
	[Mall_ProductDesc].[AddMan] = @AddMan 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[GUID],
	INSERTED.[SortOrder],
	INSERTED.[Type],
	INSERTED.[TextContent],
	INSERTED.[ImageUrl],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
WHERE 
	[Mall_ProductDesc].[ID] = @ID

SELECT 
	[ID],
	[ProductID],
	[GUID],
	[SortOrder],
	[Type],
	[TextContent],
	[ImageUrl],
	[AddTime],
	[AddMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@Type", EntityBase.GetDatabaseValue(@type)));
			parameters.Add(new SqlParameter("@TextContent", EntityBase.GetDatabaseValue(@textContent)));
			parameters.Add(new SqlParameter("@ImageUrl", EntityBase.GetDatabaseValue(@imageUrl)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_ProductDesc from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_ProductDesc(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_ProductDesc(@iD, helper);
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
		/// Deletes a Mall_ProductDesc from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_ProductDesc(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_ProductDesc]
WHERE 
	[Mall_ProductDesc].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_ProductDesc object.
		/// </summary>
		/// <returns>The newly created Mall_ProductDesc object.</returns>
		public static Mall_ProductDesc CreateMall_ProductDesc()
		{
			return InitializeNew<Mall_ProductDesc>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_ProductDesc by a Mall_ProductDesc's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_ProductDesc</returns>
		public static Mall_ProductDesc GetMall_ProductDesc(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_ProductDesc.SelectFieldList + @"
FROM [dbo].[Mall_ProductDesc] 
WHERE 
	[Mall_ProductDesc].[ID] = @ID " + Mall_ProductDesc.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ProductDesc>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_ProductDesc by a Mall_ProductDesc's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_ProductDesc</returns>
		public static Mall_ProductDesc GetMall_ProductDesc(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_ProductDesc.SelectFieldList + @"
FROM [dbo].[Mall_ProductDesc] 
WHERE 
	[Mall_ProductDesc].[ID] = @ID " + Mall_ProductDesc.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ProductDesc>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductDesc objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_ProductDesc objects.</returns>
		public static EntityList<Mall_ProductDesc> GetMall_ProductDescs()
		{
			string commandText = @"
SELECT " + Mall_ProductDesc.SelectFieldList + "FROM [dbo].[Mall_ProductDesc] " + Mall_ProductDesc.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_ProductDesc>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_ProductDesc objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ProductDesc objects.</returns>
        public static EntityList<Mall_ProductDesc> GetMall_ProductDescs(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ProductDesc>(SelectFieldList, "FROM [dbo].[Mall_ProductDesc]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_ProductDesc objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ProductDesc objects.</returns>
        public static EntityList<Mall_ProductDesc> GetMall_ProductDescs(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ProductDesc>(SelectFieldList, "FROM [dbo].[Mall_ProductDesc]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_ProductDesc objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ProductDesc objects.</returns>
		protected static EntityList<Mall_ProductDesc> GetMall_ProductDescs(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ProductDescs(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductDesc objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ProductDesc objects.</returns>
		protected static EntityList<Mall_ProductDesc> GetMall_ProductDescs(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ProductDescs(string.Empty, where, parameters, Mall_ProductDesc.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductDesc objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ProductDesc objects.</returns>
		protected static EntityList<Mall_ProductDesc> GetMall_ProductDescs(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ProductDescs(prefix, where, parameters, Mall_ProductDesc.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductDesc objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ProductDesc objects.</returns>
		protected static EntityList<Mall_ProductDesc> GetMall_ProductDescs(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ProductDescs(string.Empty, where, parameters, Mall_ProductDesc.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductDesc objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ProductDesc objects.</returns>
		protected static EntityList<Mall_ProductDesc> GetMall_ProductDescs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ProductDescs(prefix, where, parameters, Mall_ProductDesc.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductDesc objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ProductDesc objects.</returns>
		protected static EntityList<Mall_ProductDesc> GetMall_ProductDescs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_ProductDesc.SelectFieldList + "FROM [dbo].[Mall_ProductDesc] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_ProductDesc>(reader);
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
        protected static EntityList<Mall_ProductDesc> GetMall_ProductDescs(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ProductDesc>(SelectFieldList, "FROM [dbo].[Mall_ProductDesc] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_ProductDesc objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ProductDescCount()
        {
            return GetMall_ProductDescCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_ProductDesc objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ProductDescCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_ProductDesc] " + where;

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
		public static partial class Mall_ProductDesc_Properties
		{
			public const string ID = "ID";
			public const string ProductID = "ProductID";
			public const string GUID = "GUID";
			public const string SortOrder = "SortOrder";
			public const string Type = "Type";
			public const string TextContent = "TextContent";
			public const string ImageUrl = "ImageUrl";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProductID" , "int:"},
    			 {"GUID" , "string:"},
    			 {"SortOrder" , "int:"},
    			 {"Type" , "string:"},
    			 {"TextContent" , "string:"},
    			 {"ImageUrl" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
            };
		}
		#endregion
	}
}
