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
	/// This object represents the properties and methods of a Wechat_HouseServiceCategory.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_HouseServiceCategory 
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
		private int _serviceType = int.MinValue;
		/// <summary>
		/// 1-微信服务 2-APP业主服务
		/// </summary>
        [Description("1-微信服务 2-APP业主服务")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ServiceType
		{
			[DebuggerStepThrough()]
			get { return this._serviceType; }
			set 
			{
				if (this._serviceType != value) 
				{
					this._serviceType = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceType");
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
		private bool _isWechatShow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsWechatShow
		{
			[DebuggerStepThrough()]
			get { return this._isWechatShow; }
			set 
			{
				if (this._isWechatShow != value) 
				{
					this._isWechatShow = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsWechatShow");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAPPUserShow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAPPUserShow
		{
			[DebuggerStepThrough()]
			get { return this._isAPPUserShow; }
			set 
			{
				if (this._isAPPUserShow != value) 
				{
					this._isAPPUserShow = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAPPUserShow");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAPPCustomerShow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAPPCustomerShow
		{
			[DebuggerStepThrough()]
			get { return this._isAPPCustomerShow; }
			set 
			{
				if (this._isAPPCustomerShow != value) 
				{
					this._isAPPCustomerShow = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAPPCustomerShow");
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
		private string _filePath_Active = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FilePath_Active
		{
			[DebuggerStepThrough()]
			get { return this._filePath_Active; }
			set 
			{
				if (this._filePath_Active != value) 
				{
					this._filePath_Active = value;
					this.IsDirty = true;	
					OnPropertyChanged("FilePath_Active");
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
	[CategoryName] nvarchar(50),
	[AddTime] datetime,
	[ServiceType] int,
	[SortOrder] int,
	[IsWechatShow] bit,
	[IsAPPUserShow] bit,
	[IsAPPCustomerShow] bit,
	[FilePath] nvarchar(500),
	[FilePath_Active] nvarchar(500)
);

INSERT INTO [dbo].[Wechat_HouseServiceCategory] (
	[Wechat_HouseServiceCategory].[CategoryName],
	[Wechat_HouseServiceCategory].[AddTime],
	[Wechat_HouseServiceCategory].[ServiceType],
	[Wechat_HouseServiceCategory].[SortOrder],
	[Wechat_HouseServiceCategory].[IsWechatShow],
	[Wechat_HouseServiceCategory].[IsAPPUserShow],
	[Wechat_HouseServiceCategory].[IsAPPCustomerShow],
	[Wechat_HouseServiceCategory].[FilePath],
	[Wechat_HouseServiceCategory].[FilePath_Active]
) 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[AddTime],
	INSERTED.[ServiceType],
	INSERTED.[SortOrder],
	INSERTED.[IsWechatShow],
	INSERTED.[IsAPPUserShow],
	INSERTED.[IsAPPCustomerShow],
	INSERTED.[FilePath],
	INSERTED.[FilePath_Active]
into @table
VALUES ( 
	@CategoryName,
	@AddTime,
	@ServiceType,
	@SortOrder,
	@IsWechatShow,
	@IsAPPUserShow,
	@IsAPPCustomerShow,
	@FilePath,
	@FilePath_Active 
); 

SELECT 
	[ID],
	[CategoryName],
	[AddTime],
	[ServiceType],
	[SortOrder],
	[IsWechatShow],
	[IsAPPUserShow],
	[IsAPPCustomerShow],
	[FilePath],
	[FilePath_Active] 
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
	[CategoryName] nvarchar(50),
	[AddTime] datetime,
	[ServiceType] int,
	[SortOrder] int,
	[IsWechatShow] bit,
	[IsAPPUserShow] bit,
	[IsAPPCustomerShow] bit,
	[FilePath] nvarchar(500),
	[FilePath_Active] nvarchar(500)
);

UPDATE [dbo].[Wechat_HouseServiceCategory] SET 
	[Wechat_HouseServiceCategory].[CategoryName] = @CategoryName,
	[Wechat_HouseServiceCategory].[AddTime] = @AddTime,
	[Wechat_HouseServiceCategory].[ServiceType] = @ServiceType,
	[Wechat_HouseServiceCategory].[SortOrder] = @SortOrder,
	[Wechat_HouseServiceCategory].[IsWechatShow] = @IsWechatShow,
	[Wechat_HouseServiceCategory].[IsAPPUserShow] = @IsAPPUserShow,
	[Wechat_HouseServiceCategory].[IsAPPCustomerShow] = @IsAPPCustomerShow,
	[Wechat_HouseServiceCategory].[FilePath] = @FilePath,
	[Wechat_HouseServiceCategory].[FilePath_Active] = @FilePath_Active 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[AddTime],
	INSERTED.[ServiceType],
	INSERTED.[SortOrder],
	INSERTED.[IsWechatShow],
	INSERTED.[IsAPPUserShow],
	INSERTED.[IsAPPCustomerShow],
	INSERTED.[FilePath],
	INSERTED.[FilePath_Active]
into @table
WHERE 
	[Wechat_HouseServiceCategory].[ID] = @ID

SELECT 
	[ID],
	[CategoryName],
	[AddTime],
	[ServiceType],
	[SortOrder],
	[IsWechatShow],
	[IsAPPUserShow],
	[IsAPPCustomerShow],
	[FilePath],
	[FilePath_Active] 
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
DELETE FROM [dbo].[Wechat_HouseServiceCategory]
WHERE 
	[Wechat_HouseServiceCategory].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_HouseServiceCategory() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_HouseServiceCategory(this.ID));
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
	[Wechat_HouseServiceCategory].[ID],
	[Wechat_HouseServiceCategory].[CategoryName],
	[Wechat_HouseServiceCategory].[AddTime],
	[Wechat_HouseServiceCategory].[ServiceType],
	[Wechat_HouseServiceCategory].[SortOrder],
	[Wechat_HouseServiceCategory].[IsWechatShow],
	[Wechat_HouseServiceCategory].[IsAPPUserShow],
	[Wechat_HouseServiceCategory].[IsAPPCustomerShow],
	[Wechat_HouseServiceCategory].[FilePath],
	[Wechat_HouseServiceCategory].[FilePath_Active]
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
                return "Wechat_HouseServiceCategory";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_HouseServiceCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="categoryName">categoryName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="serviceType">serviceType</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isWechatShow">isWechatShow</param>
		/// <param name="isAPPUserShow">isAPPUserShow</param>
		/// <param name="isAPPCustomerShow">isAPPCustomerShow</param>
		/// <param name="filePath">filePath</param>
		/// <param name="filePath_Active">filePath_Active</param>
		public static void InsertWechat_HouseServiceCategory(string @categoryName, DateTime @addTime, int @serviceType, int @sortOrder, bool @isWechatShow, bool @isAPPUserShow, bool @isAPPCustomerShow, string @filePath, string @filePath_Active)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_HouseServiceCategory(@categoryName, @addTime, @serviceType, @sortOrder, @isWechatShow, @isAPPUserShow, @isAPPCustomerShow, @filePath, @filePath_Active, helper);
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
		/// Insert a Wechat_HouseServiceCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="categoryName">categoryName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="serviceType">serviceType</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isWechatShow">isWechatShow</param>
		/// <param name="isAPPUserShow">isAPPUserShow</param>
		/// <param name="isAPPCustomerShow">isAPPCustomerShow</param>
		/// <param name="filePath">filePath</param>
		/// <param name="filePath_Active">filePath_Active</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_HouseServiceCategory(string @categoryName, DateTime @addTime, int @serviceType, int @sortOrder, bool @isWechatShow, bool @isAPPUserShow, bool @isAPPCustomerShow, string @filePath, string @filePath_Active, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CategoryName] nvarchar(50),
	[AddTime] datetime,
	[ServiceType] int,
	[SortOrder] int,
	[IsWechatShow] bit,
	[IsAPPUserShow] bit,
	[IsAPPCustomerShow] bit,
	[FilePath] nvarchar(500),
	[FilePath_Active] nvarchar(500)
);

INSERT INTO [dbo].[Wechat_HouseServiceCategory] (
	[Wechat_HouseServiceCategory].[CategoryName],
	[Wechat_HouseServiceCategory].[AddTime],
	[Wechat_HouseServiceCategory].[ServiceType],
	[Wechat_HouseServiceCategory].[SortOrder],
	[Wechat_HouseServiceCategory].[IsWechatShow],
	[Wechat_HouseServiceCategory].[IsAPPUserShow],
	[Wechat_HouseServiceCategory].[IsAPPCustomerShow],
	[Wechat_HouseServiceCategory].[FilePath],
	[Wechat_HouseServiceCategory].[FilePath_Active]
) 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[AddTime],
	INSERTED.[ServiceType],
	INSERTED.[SortOrder],
	INSERTED.[IsWechatShow],
	INSERTED.[IsAPPUserShow],
	INSERTED.[IsAPPCustomerShow],
	INSERTED.[FilePath],
	INSERTED.[FilePath_Active]
into @table
VALUES ( 
	@CategoryName,
	@AddTime,
	@ServiceType,
	@SortOrder,
	@IsWechatShow,
	@IsAPPUserShow,
	@IsAPPCustomerShow,
	@FilePath,
	@FilePath_Active 
); 

SELECT 
	[ID],
	[CategoryName],
	[AddTime],
	[ServiceType],
	[SortOrder],
	[IsWechatShow],
	[IsAPPUserShow],
	[IsAPPCustomerShow],
	[FilePath],
	[FilePath_Active] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CategoryName", EntityBase.GetDatabaseValue(@categoryName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ServiceType", EntityBase.GetDatabaseValue(@serviceType)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsWechatShow", @isWechatShow));
			parameters.Add(new SqlParameter("@IsAPPUserShow", @isAPPUserShow));
			parameters.Add(new SqlParameter("@IsAPPCustomerShow", @isAPPCustomerShow));
			parameters.Add(new SqlParameter("@FilePath", EntityBase.GetDatabaseValue(@filePath)));
			parameters.Add(new SqlParameter("@FilePath_Active", EntityBase.GetDatabaseValue(@filePath_Active)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_HouseServiceCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="serviceType">serviceType</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isWechatShow">isWechatShow</param>
		/// <param name="isAPPUserShow">isAPPUserShow</param>
		/// <param name="isAPPCustomerShow">isAPPCustomerShow</param>
		/// <param name="filePath">filePath</param>
		/// <param name="filePath_Active">filePath_Active</param>
		public static void UpdateWechat_HouseServiceCategory(int @iD, string @categoryName, DateTime @addTime, int @serviceType, int @sortOrder, bool @isWechatShow, bool @isAPPUserShow, bool @isAPPCustomerShow, string @filePath, string @filePath_Active)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_HouseServiceCategory(@iD, @categoryName, @addTime, @serviceType, @sortOrder, @isWechatShow, @isAPPUserShow, @isAPPCustomerShow, @filePath, @filePath_Active, helper);
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
		/// Updates a Wechat_HouseServiceCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="serviceType">serviceType</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isWechatShow">isWechatShow</param>
		/// <param name="isAPPUserShow">isAPPUserShow</param>
		/// <param name="isAPPCustomerShow">isAPPCustomerShow</param>
		/// <param name="filePath">filePath</param>
		/// <param name="filePath_Active">filePath_Active</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_HouseServiceCategory(int @iD, string @categoryName, DateTime @addTime, int @serviceType, int @sortOrder, bool @isWechatShow, bool @isAPPUserShow, bool @isAPPCustomerShow, string @filePath, string @filePath_Active, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CategoryName] nvarchar(50),
	[AddTime] datetime,
	[ServiceType] int,
	[SortOrder] int,
	[IsWechatShow] bit,
	[IsAPPUserShow] bit,
	[IsAPPCustomerShow] bit,
	[FilePath] nvarchar(500),
	[FilePath_Active] nvarchar(500)
);

UPDATE [dbo].[Wechat_HouseServiceCategory] SET 
	[Wechat_HouseServiceCategory].[CategoryName] = @CategoryName,
	[Wechat_HouseServiceCategory].[AddTime] = @AddTime,
	[Wechat_HouseServiceCategory].[ServiceType] = @ServiceType,
	[Wechat_HouseServiceCategory].[SortOrder] = @SortOrder,
	[Wechat_HouseServiceCategory].[IsWechatShow] = @IsWechatShow,
	[Wechat_HouseServiceCategory].[IsAPPUserShow] = @IsAPPUserShow,
	[Wechat_HouseServiceCategory].[IsAPPCustomerShow] = @IsAPPCustomerShow,
	[Wechat_HouseServiceCategory].[FilePath] = @FilePath,
	[Wechat_HouseServiceCategory].[FilePath_Active] = @FilePath_Active 
output 
	INSERTED.[ID],
	INSERTED.[CategoryName],
	INSERTED.[AddTime],
	INSERTED.[ServiceType],
	INSERTED.[SortOrder],
	INSERTED.[IsWechatShow],
	INSERTED.[IsAPPUserShow],
	INSERTED.[IsAPPCustomerShow],
	INSERTED.[FilePath],
	INSERTED.[FilePath_Active]
into @table
WHERE 
	[Wechat_HouseServiceCategory].[ID] = @ID

SELECT 
	[ID],
	[CategoryName],
	[AddTime],
	[ServiceType],
	[SortOrder],
	[IsWechatShow],
	[IsAPPUserShow],
	[IsAPPCustomerShow],
	[FilePath],
	[FilePath_Active] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@CategoryName", EntityBase.GetDatabaseValue(@categoryName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ServiceType", EntityBase.GetDatabaseValue(@serviceType)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsWechatShow", @isWechatShow));
			parameters.Add(new SqlParameter("@IsAPPUserShow", @isAPPUserShow));
			parameters.Add(new SqlParameter("@IsAPPCustomerShow", @isAPPCustomerShow));
			parameters.Add(new SqlParameter("@FilePath", EntityBase.GetDatabaseValue(@filePath)));
			parameters.Add(new SqlParameter("@FilePath_Active", EntityBase.GetDatabaseValue(@filePath_Active)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_HouseServiceCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_HouseServiceCategory(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_HouseServiceCategory(@iD, helper);
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
		/// Deletes a Wechat_HouseServiceCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_HouseServiceCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_HouseServiceCategory]
WHERE 
	[Wechat_HouseServiceCategory].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_HouseServiceCategory object.
		/// </summary>
		/// <returns>The newly created Wechat_HouseServiceCategory object.</returns>
		public static Wechat_HouseServiceCategory CreateWechat_HouseServiceCategory()
		{
			return InitializeNew<Wechat_HouseServiceCategory>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_HouseServiceCategory by a Wechat_HouseServiceCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_HouseServiceCategory</returns>
		public static Wechat_HouseServiceCategory GetWechat_HouseServiceCategory(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_HouseServiceCategory.SelectFieldList + @"
FROM [dbo].[Wechat_HouseServiceCategory] 
WHERE 
	[Wechat_HouseServiceCategory].[ID] = @ID " + Wechat_HouseServiceCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_HouseServiceCategory>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_HouseServiceCategory by a Wechat_HouseServiceCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_HouseServiceCategory</returns>
		public static Wechat_HouseServiceCategory GetWechat_HouseServiceCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_HouseServiceCategory.SelectFieldList + @"
FROM [dbo].[Wechat_HouseServiceCategory] 
WHERE 
	[Wechat_HouseServiceCategory].[ID] = @ID " + Wechat_HouseServiceCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_HouseServiceCategory>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceCategory objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_HouseServiceCategory objects.</returns>
		public static EntityList<Wechat_HouseServiceCategory> GetWechat_HouseServiceCategories()
		{
			string commandText = @"
SELECT " + Wechat_HouseServiceCategory.SelectFieldList + "FROM [dbo].[Wechat_HouseServiceCategory] " + Wechat_HouseServiceCategory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_HouseServiceCategory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_HouseServiceCategory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_HouseServiceCategory objects.</returns>
        public static EntityList<Wechat_HouseServiceCategory> GetWechat_HouseServiceCategories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_HouseServiceCategory>(SelectFieldList, "FROM [dbo].[Wechat_HouseServiceCategory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_HouseServiceCategory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_HouseServiceCategory objects.</returns>
        public static EntityList<Wechat_HouseServiceCategory> GetWechat_HouseServiceCategories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_HouseServiceCategory>(SelectFieldList, "FROM [dbo].[Wechat_HouseServiceCategory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceCategory objects.</returns>
		protected static EntityList<Wechat_HouseServiceCategory> GetWechat_HouseServiceCategories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_HouseServiceCategories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceCategory objects.</returns>
		protected static EntityList<Wechat_HouseServiceCategory> GetWechat_HouseServiceCategories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_HouseServiceCategories(string.Empty, where, parameters, Wechat_HouseServiceCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceCategory objects.</returns>
		protected static EntityList<Wechat_HouseServiceCategory> GetWechat_HouseServiceCategories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_HouseServiceCategories(prefix, where, parameters, Wechat_HouseServiceCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceCategory objects.</returns>
		protected static EntityList<Wechat_HouseServiceCategory> GetWechat_HouseServiceCategories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_HouseServiceCategories(string.Empty, where, parameters, Wechat_HouseServiceCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceCategory objects.</returns>
		protected static EntityList<Wechat_HouseServiceCategory> GetWechat_HouseServiceCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_HouseServiceCategories(prefix, where, parameters, Wechat_HouseServiceCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceCategory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceCategory objects.</returns>
		protected static EntityList<Wechat_HouseServiceCategory> GetWechat_HouseServiceCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_HouseServiceCategory.SelectFieldList + "FROM [dbo].[Wechat_HouseServiceCategory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_HouseServiceCategory>(reader);
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
        protected static EntityList<Wechat_HouseServiceCategory> GetWechat_HouseServiceCategories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_HouseServiceCategory>(SelectFieldList, "FROM [dbo].[Wechat_HouseServiceCategory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_HouseServiceCategory objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_HouseServiceCategoryCount()
        {
            return GetWechat_HouseServiceCategoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_HouseServiceCategory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_HouseServiceCategoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_HouseServiceCategory] " + where;

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
		public static partial class Wechat_HouseServiceCategory_Properties
		{
			public const string ID = "ID";
			public const string CategoryName = "CategoryName";
			public const string AddTime = "AddTime";
			public const string ServiceType = "ServiceType";
			public const string SortOrder = "SortOrder";
			public const string IsWechatShow = "IsWechatShow";
			public const string IsAPPUserShow = "IsAPPUserShow";
			public const string IsAPPCustomerShow = "IsAPPCustomerShow";
			public const string FilePath = "FilePath";
			public const string FilePath_Active = "FilePath_Active";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CategoryName" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"ServiceType" , "int:1-微信服务 2-APP业主服务"},
    			 {"SortOrder" , "int:"},
    			 {"IsWechatShow" , "bool:"},
    			 {"IsAPPUserShow" , "bool:"},
    			 {"IsAPPCustomerShow" , "bool:"},
    			 {"FilePath" , "string:"},
    			 {"FilePath_Active" , "string:"},
            };
		}
		#endregion
	}
}
