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
	/// This object represents the properties and methods of a Mall_Category.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_Category 
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
		private string _categoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string CategoryName
		{
			[DebuggerStepThrough()]
			get { return this._categoryName; }
			set 
			{
				if (this._categoryName != value) 
				{
					this._categoryName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CategoryName");
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
		[DataObjectField(false, false, true)]
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
		private string _picturePath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PicturePath
		{
			[DebuggerStepThrough()]
			get { return this._picturePath; }
			set 
			{
				if (this._picturePath != value) 
				{
					this._picturePath = value;
					this.IsDirty = true;	
					OnPropertyChanged("PicturePath");
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _parentID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ParentID
		{
			[DebuggerStepThrough()]
			get { return this._parentID; }
			set 
			{
				if (this._parentID != value) 
				{
					this._parentID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ParentID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _categoryType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CategoryType
		{
			[DebuggerStepThrough()]
			get { return this._categoryType; }
			set 
			{
				if (this._categoryType != value) 
				{
					this._categoryType = value;
					this.IsDirty = true;	
					OnPropertyChanged("CategoryType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDisabled = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDisabled
		{
			[DebuggerStepThrough()]
			get { return this._isDisabled; }
			set 
			{
				if (this._isDisabled != value) 
				{
					this._isDisabled = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDisabled");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isShowOnMallYouXuan = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsShowOnMallYouXuan
		{
			[DebuggerStepThrough()]
			get { return this._isShowOnMallYouXuan; }
			set 
			{
				if (this._isShowOnMallYouXuan != value) 
				{
					this._isShowOnMallYouXuan = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsShowOnMallYouXuan");
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
	[CategoryName] nvarchar(200),
	[SortOrder] int,
	[PicturePath] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[ParentID] int,
	[CategoryType] nvarchar(100),
	[IsDisabled] bit,
	[IsShowOnMallYouXuan] bit
);

INSERT INTO [dbo].[Mall_Category] (
	[Mall_Category].[CategoryName],
	[Mall_Category].[SortOrder],
	[Mall_Category].[PicturePath],
	[Mall_Category].[AddTime],
	[Mall_Category].[AddMan],
	[Mall_Category].[ParentID],
	[Mall_Category].[CategoryType],
	[Mall_Category].[IsDisabled],
	[Mall_Category].[IsShowOnMallYouXuan]
) 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[SortOrder],
	INSERTED.[PicturePath],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ParentID],
	INSERTED.[CategoryType],
	INSERTED.[IsDisabled],
	INSERTED.[IsShowOnMallYouXuan]
into @table
VALUES ( 
	@CategoryName,
	@SortOrder,
	@PicturePath,
	@AddTime,
	@AddMan,
	@ParentID,
	@CategoryType,
	@IsDisabled,
	@IsShowOnMallYouXuan 
); 

SELECT 
	[ID],
	[CategoryName],
	[SortOrder],
	[PicturePath],
	[AddTime],
	[AddMan],
	[ParentID],
	[CategoryType],
	[IsDisabled],
	[IsShowOnMallYouXuan] 
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
	[CategoryName] nvarchar(200),
	[SortOrder] int,
	[PicturePath] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[ParentID] int,
	[CategoryType] nvarchar(100),
	[IsDisabled] bit,
	[IsShowOnMallYouXuan] bit
);

UPDATE [dbo].[Mall_Category] SET 
	[Mall_Category].[CategoryName] = @CategoryName,
	[Mall_Category].[SortOrder] = @SortOrder,
	[Mall_Category].[PicturePath] = @PicturePath,
	[Mall_Category].[AddTime] = @AddTime,
	[Mall_Category].[AddMan] = @AddMan,
	[Mall_Category].[ParentID] = @ParentID,
	[Mall_Category].[CategoryType] = @CategoryType,
	[Mall_Category].[IsDisabled] = @IsDisabled,
	[Mall_Category].[IsShowOnMallYouXuan] = @IsShowOnMallYouXuan 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[SortOrder],
	INSERTED.[PicturePath],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ParentID],
	INSERTED.[CategoryType],
	INSERTED.[IsDisabled],
	INSERTED.[IsShowOnMallYouXuan]
into @table
WHERE 
	[Mall_Category].[ID] = @ID

SELECT 
	[ID],
	[CategoryName],
	[SortOrder],
	[PicturePath],
	[AddTime],
	[AddMan],
	[ParentID],
	[CategoryType],
	[IsDisabled],
	[IsShowOnMallYouXuan] 
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
DELETE FROM [dbo].[Mall_Category]
WHERE 
	[Mall_Category].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_Category() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_Category(this.ID));
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
	[Mall_Category].[ID],
	[Mall_Category].[CategoryName],
	[Mall_Category].[SortOrder],
	[Mall_Category].[PicturePath],
	[Mall_Category].[AddTime],
	[Mall_Category].[AddMan],
	[Mall_Category].[ParentID],
	[Mall_Category].[CategoryType],
	[Mall_Category].[IsDisabled],
	[Mall_Category].[IsShowOnMallYouXuan]
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
                return "Mall_Category";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_Category into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="categoryName">categoryName</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="picturePath">picturePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="parentID">parentID</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="isDisabled">isDisabled</param>
		/// <param name="isShowOnMallYouXuan">isShowOnMallYouXuan</param>
		public static void InsertMall_Category(string @categoryName, int @sortOrder, string @picturePath, DateTime @addTime, string @addMan, int @parentID, string @categoryType, bool @isDisabled, bool @isShowOnMallYouXuan)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_Category(@categoryName, @sortOrder, @picturePath, @addTime, @addMan, @parentID, @categoryType, @isDisabled, @isShowOnMallYouXuan, helper);
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
		/// Insert a Mall_Category into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="categoryName">categoryName</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="picturePath">picturePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="parentID">parentID</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="isDisabled">isDisabled</param>
		/// <param name="isShowOnMallYouXuan">isShowOnMallYouXuan</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_Category(string @categoryName, int @sortOrder, string @picturePath, DateTime @addTime, string @addMan, int @parentID, string @categoryType, bool @isDisabled, bool @isShowOnMallYouXuan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CategoryName] nvarchar(200),
	[SortOrder] int,
	[PicturePath] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[ParentID] int,
	[CategoryType] nvarchar(100),
	[IsDisabled] bit,
	[IsShowOnMallYouXuan] bit
);

INSERT INTO [dbo].[Mall_Category] (
	[Mall_Category].[CategoryName],
	[Mall_Category].[SortOrder],
	[Mall_Category].[PicturePath],
	[Mall_Category].[AddTime],
	[Mall_Category].[AddMan],
	[Mall_Category].[ParentID],
	[Mall_Category].[CategoryType],
	[Mall_Category].[IsDisabled],
	[Mall_Category].[IsShowOnMallYouXuan]
) 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[SortOrder],
	INSERTED.[PicturePath],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ParentID],
	INSERTED.[CategoryType],
	INSERTED.[IsDisabled],
	INSERTED.[IsShowOnMallYouXuan]
into @table
VALUES ( 
	@CategoryName,
	@SortOrder,
	@PicturePath,
	@AddTime,
	@AddMan,
	@ParentID,
	@CategoryType,
	@IsDisabled,
	@IsShowOnMallYouXuan 
); 

SELECT 
	[ID],
	[CategoryName],
	[SortOrder],
	[PicturePath],
	[AddTime],
	[AddMan],
	[ParentID],
	[CategoryType],
	[IsDisabled],
	[IsShowOnMallYouXuan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CategoryName", EntityBase.GetDatabaseValue(@categoryName)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@PicturePath", EntityBase.GetDatabaseValue(@picturePath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@CategoryType", EntityBase.GetDatabaseValue(@categoryType)));
			parameters.Add(new SqlParameter("@IsDisabled", @isDisabled));
			parameters.Add(new SqlParameter("@IsShowOnMallYouXuan", @isShowOnMallYouXuan));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_Category into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="picturePath">picturePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="parentID">parentID</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="isDisabled">isDisabled</param>
		/// <param name="isShowOnMallYouXuan">isShowOnMallYouXuan</param>
		public static void UpdateMall_Category(int @iD, string @categoryName, int @sortOrder, string @picturePath, DateTime @addTime, string @addMan, int @parentID, string @categoryType, bool @isDisabled, bool @isShowOnMallYouXuan)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_Category(@iD, @categoryName, @sortOrder, @picturePath, @addTime, @addMan, @parentID, @categoryType, @isDisabled, @isShowOnMallYouXuan, helper);
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
		/// Updates a Mall_Category into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="picturePath">picturePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="parentID">parentID</param>
		/// <param name="categoryType">categoryType</param>
		/// <param name="isDisabled">isDisabled</param>
		/// <param name="isShowOnMallYouXuan">isShowOnMallYouXuan</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_Category(int @iD, string @categoryName, int @sortOrder, string @picturePath, DateTime @addTime, string @addMan, int @parentID, string @categoryType, bool @isDisabled, bool @isShowOnMallYouXuan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CategoryName] nvarchar(200),
	[SortOrder] int,
	[PicturePath] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[ParentID] int,
	[CategoryType] nvarchar(100),
	[IsDisabled] bit,
	[IsShowOnMallYouXuan] bit
);

UPDATE [dbo].[Mall_Category] SET 
	[Mall_Category].[CategoryName] = @CategoryName,
	[Mall_Category].[SortOrder] = @SortOrder,
	[Mall_Category].[PicturePath] = @PicturePath,
	[Mall_Category].[AddTime] = @AddTime,
	[Mall_Category].[AddMan] = @AddMan,
	[Mall_Category].[ParentID] = @ParentID,
	[Mall_Category].[CategoryType] = @CategoryType,
	[Mall_Category].[IsDisabled] = @IsDisabled,
	[Mall_Category].[IsShowOnMallYouXuan] = @IsShowOnMallYouXuan 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[SortOrder],
	INSERTED.[PicturePath],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ParentID],
	INSERTED.[CategoryType],
	INSERTED.[IsDisabled],
	INSERTED.[IsShowOnMallYouXuan]
into @table
WHERE 
	[Mall_Category].[ID] = @ID

SELECT 
	[ID],
	[CategoryName],
	[SortOrder],
	[PicturePath],
	[AddTime],
	[AddMan],
	[ParentID],
	[CategoryType],
	[IsDisabled],
	[IsShowOnMallYouXuan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@CategoryName", EntityBase.GetDatabaseValue(@categoryName)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@PicturePath", EntityBase.GetDatabaseValue(@picturePath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@CategoryType", EntityBase.GetDatabaseValue(@categoryType)));
			parameters.Add(new SqlParameter("@IsDisabled", @isDisabled));
			parameters.Add(new SqlParameter("@IsShowOnMallYouXuan", @isShowOnMallYouXuan));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_Category from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_Category(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_Category(@iD, helper);
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
		/// Deletes a Mall_Category from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_Category(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_Category]
WHERE 
	[Mall_Category].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_Category object.
		/// </summary>
		/// <returns>The newly created Mall_Category object.</returns>
		public static Mall_Category CreateMall_Category()
		{
			return InitializeNew<Mall_Category>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_Category by a Mall_Category's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_Category</returns>
		public static Mall_Category GetMall_Category(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_Category.SelectFieldList + @"
FROM [dbo].[Mall_Category] 
WHERE 
	[Mall_Category].[ID] = @ID " + Mall_Category.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Category>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_Category by a Mall_Category's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_Category</returns>
		public static Mall_Category GetMall_Category(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_Category.SelectFieldList + @"
FROM [dbo].[Mall_Category] 
WHERE 
	[Mall_Category].[ID] = @ID " + Mall_Category.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Category>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_Category objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_Category objects.</returns>
		public static EntityList<Mall_Category> GetMall_Categories()
		{
			string commandText = @"
SELECT " + Mall_Category.SelectFieldList + "FROM [dbo].[Mall_Category] " + Mall_Category.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_Category>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_Category objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Category objects.</returns>
        public static EntityList<Mall_Category> GetMall_Categories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Category>(SelectFieldList, "FROM [dbo].[Mall_Category]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_Category objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Category objects.</returns>
        public static EntityList<Mall_Category> GetMall_Categories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Category>(SelectFieldList, "FROM [dbo].[Mall_Category]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_Category objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Category objects.</returns>
		protected static EntityList<Mall_Category> GetMall_Categories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Categories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_Category objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Category objects.</returns>
		protected static EntityList<Mall_Category> GetMall_Categories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Categories(string.Empty, where, parameters, Mall_Category.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Category objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Category objects.</returns>
		protected static EntityList<Mall_Category> GetMall_Categories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Categories(prefix, where, parameters, Mall_Category.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Category objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Category objects.</returns>
		protected static EntityList<Mall_Category> GetMall_Categories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Categories(string.Empty, where, parameters, Mall_Category.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Category objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Category objects.</returns>
		protected static EntityList<Mall_Category> GetMall_Categories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Categories(prefix, where, parameters, Mall_Category.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Category objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Category objects.</returns>
		protected static EntityList<Mall_Category> GetMall_Categories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_Category.SelectFieldList + "FROM [dbo].[Mall_Category] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_Category>(reader);
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
        protected static EntityList<Mall_Category> GetMall_Categories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Category>(SelectFieldList, "FROM [dbo].[Mall_Category] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_Category objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CategoryCount()
        {
            return GetMall_CategoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_Category objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CategoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_Category] " + where;

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
		public static partial class Mall_Category_Properties
		{
			public const string ID = "ID";
			public const string CategoryName = "CategoryName";
			public const string SortOrder = "SortOrder";
			public const string PicturePath = "PicturePath";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string ParentID = "ParentID";
			public const string CategoryType = "CategoryType";
			public const string IsDisabled = "IsDisabled";
			public const string IsShowOnMallYouXuan = "IsShowOnMallYouXuan";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CategoryName" , "string:"},
    			 {"SortOrder" , "int:"},
    			 {"PicturePath" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"ParentID" , "int:"},
    			 {"CategoryType" , "string:"},
    			 {"IsDisabled" , "bool:"},
    			 {"IsShowOnMallYouXuan" , "bool:"},
            };
		}
		#endregion
	}
}
