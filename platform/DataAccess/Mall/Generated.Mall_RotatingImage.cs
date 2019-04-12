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
	/// This object represents the properties and methods of a Mall_RotatingImage.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_RotatingImage 
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
		private int _type = int.MinValue;
		/// <summary>
		/// 1-业主APP首页 2-业主APP商城 3-业主APP登录 4-商家APP首页 5-商家APP登录 6-业主APP社区 7-业主APP引导页 8-福顺券领取背景图片 9-业主APP引导页底部图片 10-福顺券过期背景图片
		/// </summary>
        [Description("1-业主APP首页 2-业主APP商城 3-业主APP登录 4-商家APP首页 5-商家APP登录 6-业主APP社区 7-业主APP引导页 8-福顺券领取背景图片 9-业主APP引导页底部图片 10-福顺券过期背景图片")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int Type
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
		private string _uRLLinkContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string URLLinkContent
		{
			[DebuggerStepThrough()]
			get { return this._uRLLinkContent; }
			set 
			{
				if (this._uRLLinkContent != value) 
				{
					this._uRLLinkContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("URLLinkContent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _uRLLinkType = int.MinValue;
		/// <summary>
		/// 1-商品 2-店铺 3-物业公告 4-小区新闻
		/// </summary>
        [Description("1-商品 2-店铺 3-物业公告 4-小区新闻")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int URLLinkType
		{
			[DebuggerStepThrough()]
			get { return this._uRLLinkType; }
			set 
			{
				if (this._uRLLinkType != value) 
				{
					this._uRLLinkType = value;
					this.IsDirty = true;	
					OnPropertyChanged("URLLinkType");
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
		private int _uRLLinkID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int URLLinkID
		{
			[DebuggerStepThrough()]
			get { return this._uRLLinkID; }
			set 
			{
				if (this._uRLLinkID != value) 
				{
					this._uRLLinkID = value;
					this.IsDirty = true;	
					OnPropertyChanged("URLLinkID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _waitSecond = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int WaitSecond
		{
			[DebuggerStepThrough()]
			get { return this._waitSecond; }
			set 
			{
				if (this._waitSecond != value) 
				{
					this._waitSecond = value;
					this.IsDirty = true;	
					OnPropertyChanged("WaitSecond");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isActive = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsActive
		{
			[DebuggerStepThrough()]
			get { return this._isActive; }
			set 
			{
				if (this._isActive != value) 
				{
					this._isActive = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsActive");
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
	[Type] int,
	[SortOrder] int,
	[ImagePath] nvarchar(500),
	[URLLinkContent] nvarchar(500),
	[URLLinkType] int,
	[AddTime] datetime,
	[URLLinkID] int,
	[WaitSecond] int,
	[IsActive] bit
);

INSERT INTO [dbo].[Mall_RotatingImage] (
	[Mall_RotatingImage].[Type],
	[Mall_RotatingImage].[SortOrder],
	[Mall_RotatingImage].[ImagePath],
	[Mall_RotatingImage].[URLLinkContent],
	[Mall_RotatingImage].[URLLinkType],
	[Mall_RotatingImage].[AddTime],
	[Mall_RotatingImage].[URLLinkID],
	[Mall_RotatingImage].[WaitSecond],
	[Mall_RotatingImage].[IsActive]
) 
output 
	INSERTED.[ID],
	INSERTED.[Type],
	INSERTED.[SortOrder],
	INSERTED.[ImagePath],
	INSERTED.[URLLinkContent],
	INSERTED.[URLLinkType],
	INSERTED.[AddTime],
	INSERTED.[URLLinkID],
	INSERTED.[WaitSecond],
	INSERTED.[IsActive]
into @table
VALUES ( 
	@Type,
	@SortOrder,
	@ImagePath,
	@URLLinkContent,
	@URLLinkType,
	@AddTime,
	@URLLinkID,
	@WaitSecond,
	@IsActive 
); 

SELECT 
	[ID],
	[Type],
	[SortOrder],
	[ImagePath],
	[URLLinkContent],
	[URLLinkType],
	[AddTime],
	[URLLinkID],
	[WaitSecond],
	[IsActive] 
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
	[Type] int,
	[SortOrder] int,
	[ImagePath] nvarchar(500),
	[URLLinkContent] nvarchar(500),
	[URLLinkType] int,
	[AddTime] datetime,
	[URLLinkID] int,
	[WaitSecond] int,
	[IsActive] bit
);

UPDATE [dbo].[Mall_RotatingImage] SET 
	[Mall_RotatingImage].[Type] = @Type,
	[Mall_RotatingImage].[SortOrder] = @SortOrder,
	[Mall_RotatingImage].[ImagePath] = @ImagePath,
	[Mall_RotatingImage].[URLLinkContent] = @URLLinkContent,
	[Mall_RotatingImage].[URLLinkType] = @URLLinkType,
	[Mall_RotatingImage].[AddTime] = @AddTime,
	[Mall_RotatingImage].[URLLinkID] = @URLLinkID,
	[Mall_RotatingImage].[WaitSecond] = @WaitSecond,
	[Mall_RotatingImage].[IsActive] = @IsActive 
output 
	INSERTED.[ID],
	INSERTED.[Type],
	INSERTED.[SortOrder],
	INSERTED.[ImagePath],
	INSERTED.[URLLinkContent],
	INSERTED.[URLLinkType],
	INSERTED.[AddTime],
	INSERTED.[URLLinkID],
	INSERTED.[WaitSecond],
	INSERTED.[IsActive]
into @table
WHERE 
	[Mall_RotatingImage].[ID] = @ID

SELECT 
	[ID],
	[Type],
	[SortOrder],
	[ImagePath],
	[URLLinkContent],
	[URLLinkType],
	[AddTime],
	[URLLinkID],
	[WaitSecond],
	[IsActive] 
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
DELETE FROM [dbo].[Mall_RotatingImage]
WHERE 
	[Mall_RotatingImage].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_RotatingImage() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_RotatingImage(this.ID));
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
	[Mall_RotatingImage].[ID],
	[Mall_RotatingImage].[Type],
	[Mall_RotatingImage].[SortOrder],
	[Mall_RotatingImage].[ImagePath],
	[Mall_RotatingImage].[URLLinkContent],
	[Mall_RotatingImage].[URLLinkType],
	[Mall_RotatingImage].[AddTime],
	[Mall_RotatingImage].[URLLinkID],
	[Mall_RotatingImage].[WaitSecond],
	[Mall_RotatingImage].[IsActive]
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
                return "Mall_RotatingImage";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_RotatingImage into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="type">type</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="imagePath">imagePath</param>
		/// <param name="uRLLinkContent">uRLLinkContent</param>
		/// <param name="uRLLinkType">uRLLinkType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="uRLLinkID">uRLLinkID</param>
		/// <param name="waitSecond">waitSecond</param>
		/// <param name="isActive">isActive</param>
		public static void InsertMall_RotatingImage(int @type, int @sortOrder, string @imagePath, string @uRLLinkContent, int @uRLLinkType, DateTime @addTime, int @uRLLinkID, int @waitSecond, bool @isActive)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_RotatingImage(@type, @sortOrder, @imagePath, @uRLLinkContent, @uRLLinkType, @addTime, @uRLLinkID, @waitSecond, @isActive, helper);
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
		/// Insert a Mall_RotatingImage into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="type">type</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="imagePath">imagePath</param>
		/// <param name="uRLLinkContent">uRLLinkContent</param>
		/// <param name="uRLLinkType">uRLLinkType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="uRLLinkID">uRLLinkID</param>
		/// <param name="waitSecond">waitSecond</param>
		/// <param name="isActive">isActive</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_RotatingImage(int @type, int @sortOrder, string @imagePath, string @uRLLinkContent, int @uRLLinkType, DateTime @addTime, int @uRLLinkID, int @waitSecond, bool @isActive, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Type] int,
	[SortOrder] int,
	[ImagePath] nvarchar(500),
	[URLLinkContent] nvarchar(500),
	[URLLinkType] int,
	[AddTime] datetime,
	[URLLinkID] int,
	[WaitSecond] int,
	[IsActive] bit
);

INSERT INTO [dbo].[Mall_RotatingImage] (
	[Mall_RotatingImage].[Type],
	[Mall_RotatingImage].[SortOrder],
	[Mall_RotatingImage].[ImagePath],
	[Mall_RotatingImage].[URLLinkContent],
	[Mall_RotatingImage].[URLLinkType],
	[Mall_RotatingImage].[AddTime],
	[Mall_RotatingImage].[URLLinkID],
	[Mall_RotatingImage].[WaitSecond],
	[Mall_RotatingImage].[IsActive]
) 
output 
	INSERTED.[ID],
	INSERTED.[Type],
	INSERTED.[SortOrder],
	INSERTED.[ImagePath],
	INSERTED.[URLLinkContent],
	INSERTED.[URLLinkType],
	INSERTED.[AddTime],
	INSERTED.[URLLinkID],
	INSERTED.[WaitSecond],
	INSERTED.[IsActive]
into @table
VALUES ( 
	@Type,
	@SortOrder,
	@ImagePath,
	@URLLinkContent,
	@URLLinkType,
	@AddTime,
	@URLLinkID,
	@WaitSecond,
	@IsActive 
); 

SELECT 
	[ID],
	[Type],
	[SortOrder],
	[ImagePath],
	[URLLinkContent],
	[URLLinkType],
	[AddTime],
	[URLLinkID],
	[WaitSecond],
	[IsActive] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Type", EntityBase.GetDatabaseValue(@type)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@ImagePath", EntityBase.GetDatabaseValue(@imagePath)));
			parameters.Add(new SqlParameter("@URLLinkContent", EntityBase.GetDatabaseValue(@uRLLinkContent)));
			parameters.Add(new SqlParameter("@URLLinkType", EntityBase.GetDatabaseValue(@uRLLinkType)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@URLLinkID", EntityBase.GetDatabaseValue(@uRLLinkID)));
			parameters.Add(new SqlParameter("@WaitSecond", EntityBase.GetDatabaseValue(@waitSecond)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_RotatingImage into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="type">type</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="imagePath">imagePath</param>
		/// <param name="uRLLinkContent">uRLLinkContent</param>
		/// <param name="uRLLinkType">uRLLinkType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="uRLLinkID">uRLLinkID</param>
		/// <param name="waitSecond">waitSecond</param>
		/// <param name="isActive">isActive</param>
		public static void UpdateMall_RotatingImage(int @iD, int @type, int @sortOrder, string @imagePath, string @uRLLinkContent, int @uRLLinkType, DateTime @addTime, int @uRLLinkID, int @waitSecond, bool @isActive)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_RotatingImage(@iD, @type, @sortOrder, @imagePath, @uRLLinkContent, @uRLLinkType, @addTime, @uRLLinkID, @waitSecond, @isActive, helper);
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
		/// Updates a Mall_RotatingImage into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="type">type</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="imagePath">imagePath</param>
		/// <param name="uRLLinkContent">uRLLinkContent</param>
		/// <param name="uRLLinkType">uRLLinkType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="uRLLinkID">uRLLinkID</param>
		/// <param name="waitSecond">waitSecond</param>
		/// <param name="isActive">isActive</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_RotatingImage(int @iD, int @type, int @sortOrder, string @imagePath, string @uRLLinkContent, int @uRLLinkType, DateTime @addTime, int @uRLLinkID, int @waitSecond, bool @isActive, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Type] int,
	[SortOrder] int,
	[ImagePath] nvarchar(500),
	[URLLinkContent] nvarchar(500),
	[URLLinkType] int,
	[AddTime] datetime,
	[URLLinkID] int,
	[WaitSecond] int,
	[IsActive] bit
);

UPDATE [dbo].[Mall_RotatingImage] SET 
	[Mall_RotatingImage].[Type] = @Type,
	[Mall_RotatingImage].[SortOrder] = @SortOrder,
	[Mall_RotatingImage].[ImagePath] = @ImagePath,
	[Mall_RotatingImage].[URLLinkContent] = @URLLinkContent,
	[Mall_RotatingImage].[URLLinkType] = @URLLinkType,
	[Mall_RotatingImage].[AddTime] = @AddTime,
	[Mall_RotatingImage].[URLLinkID] = @URLLinkID,
	[Mall_RotatingImage].[WaitSecond] = @WaitSecond,
	[Mall_RotatingImage].[IsActive] = @IsActive 
output 
	INSERTED.[ID],
	INSERTED.[Type],
	INSERTED.[SortOrder],
	INSERTED.[ImagePath],
	INSERTED.[URLLinkContent],
	INSERTED.[URLLinkType],
	INSERTED.[AddTime],
	INSERTED.[URLLinkID],
	INSERTED.[WaitSecond],
	INSERTED.[IsActive]
into @table
WHERE 
	[Mall_RotatingImage].[ID] = @ID

SELECT 
	[ID],
	[Type],
	[SortOrder],
	[ImagePath],
	[URLLinkContent],
	[URLLinkType],
	[AddTime],
	[URLLinkID],
	[WaitSecond],
	[IsActive] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Type", EntityBase.GetDatabaseValue(@type)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@ImagePath", EntityBase.GetDatabaseValue(@imagePath)));
			parameters.Add(new SqlParameter("@URLLinkContent", EntityBase.GetDatabaseValue(@uRLLinkContent)));
			parameters.Add(new SqlParameter("@URLLinkType", EntityBase.GetDatabaseValue(@uRLLinkType)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@URLLinkID", EntityBase.GetDatabaseValue(@uRLLinkID)));
			parameters.Add(new SqlParameter("@WaitSecond", EntityBase.GetDatabaseValue(@waitSecond)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_RotatingImage from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_RotatingImage(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_RotatingImage(@iD, helper);
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
		/// Deletes a Mall_RotatingImage from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_RotatingImage(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_RotatingImage]
WHERE 
	[Mall_RotatingImage].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_RotatingImage object.
		/// </summary>
		/// <returns>The newly created Mall_RotatingImage object.</returns>
		public static Mall_RotatingImage CreateMall_RotatingImage()
		{
			return InitializeNew<Mall_RotatingImage>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_RotatingImage by a Mall_RotatingImage's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_RotatingImage</returns>
		public static Mall_RotatingImage GetMall_RotatingImage(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_RotatingImage.SelectFieldList + @"
FROM [dbo].[Mall_RotatingImage] 
WHERE 
	[Mall_RotatingImage].[ID] = @ID " + Mall_RotatingImage.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_RotatingImage>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_RotatingImage by a Mall_RotatingImage's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_RotatingImage</returns>
		public static Mall_RotatingImage GetMall_RotatingImage(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_RotatingImage.SelectFieldList + @"
FROM [dbo].[Mall_RotatingImage] 
WHERE 
	[Mall_RotatingImage].[ID] = @ID " + Mall_RotatingImage.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_RotatingImage>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_RotatingImage objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_RotatingImage objects.</returns>
		public static EntityList<Mall_RotatingImage> GetMall_RotatingImages()
		{
			string commandText = @"
SELECT " + Mall_RotatingImage.SelectFieldList + "FROM [dbo].[Mall_RotatingImage] " + Mall_RotatingImage.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_RotatingImage>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_RotatingImage objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_RotatingImage objects.</returns>
        public static EntityList<Mall_RotatingImage> GetMall_RotatingImages(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_RotatingImage>(SelectFieldList, "FROM [dbo].[Mall_RotatingImage]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_RotatingImage objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_RotatingImage objects.</returns>
        public static EntityList<Mall_RotatingImage> GetMall_RotatingImages(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_RotatingImage>(SelectFieldList, "FROM [dbo].[Mall_RotatingImage]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_RotatingImage objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_RotatingImage objects.</returns>
		protected static EntityList<Mall_RotatingImage> GetMall_RotatingImages(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_RotatingImages(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_RotatingImage objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_RotatingImage objects.</returns>
		protected static EntityList<Mall_RotatingImage> GetMall_RotatingImages(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_RotatingImages(string.Empty, where, parameters, Mall_RotatingImage.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_RotatingImage objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_RotatingImage objects.</returns>
		protected static EntityList<Mall_RotatingImage> GetMall_RotatingImages(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_RotatingImages(prefix, where, parameters, Mall_RotatingImage.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_RotatingImage objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_RotatingImage objects.</returns>
		protected static EntityList<Mall_RotatingImage> GetMall_RotatingImages(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_RotatingImages(string.Empty, where, parameters, Mall_RotatingImage.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_RotatingImage objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_RotatingImage objects.</returns>
		protected static EntityList<Mall_RotatingImage> GetMall_RotatingImages(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_RotatingImages(prefix, where, parameters, Mall_RotatingImage.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_RotatingImage objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_RotatingImage objects.</returns>
		protected static EntityList<Mall_RotatingImage> GetMall_RotatingImages(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_RotatingImage.SelectFieldList + "FROM [dbo].[Mall_RotatingImage] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_RotatingImage>(reader);
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
        protected static EntityList<Mall_RotatingImage> GetMall_RotatingImages(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_RotatingImage>(SelectFieldList, "FROM [dbo].[Mall_RotatingImage] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_RotatingImage objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_RotatingImageCount()
        {
            return GetMall_RotatingImageCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_RotatingImage objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_RotatingImageCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_RotatingImage] " + where;

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
		public static partial class Mall_RotatingImage_Properties
		{
			public const string ID = "ID";
			public const string Type = "Type";
			public const string SortOrder = "SortOrder";
			public const string ImagePath = "ImagePath";
			public const string URLLinkContent = "URLLinkContent";
			public const string URLLinkType = "URLLinkType";
			public const string AddTime = "AddTime";
			public const string URLLinkID = "URLLinkID";
			public const string WaitSecond = "WaitSecond";
			public const string IsActive = "IsActive";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Type" , "int:1-业主APP首页 2-业主APP商城 3-业主APP登录 4-商家APP首页 5-商家APP登录 6-业主APP社区 7-业主APP引导页 8-福顺券领取背景图片 9-业主APP引导页底部图片 10-福顺券过期背景图片"},
    			 {"SortOrder" , "int:"},
    			 {"ImagePath" , "string:"},
    			 {"URLLinkContent" , "string:"},
    			 {"URLLinkType" , "int:1-商品 2-店铺 3-物业公告 4-小区新闻"},
    			 {"AddTime" , "DateTime:"},
    			 {"URLLinkID" , "int:"},
    			 {"WaitSecond" , "int:"},
    			 {"IsActive" , "bool:"},
            };
		}
		#endregion
	}
}
