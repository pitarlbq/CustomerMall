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
	/// This object represents the properties and methods of a Mall_Thread.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_Thread 
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
		private int _userID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int UserID
		{
			[DebuggerStepThrough()]
			get { return this._userID; }
			set 
			{
				if (this._userID != value) 
				{
					this._userID = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserID");
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
		private string _description = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Description
		{
			[DebuggerStepThrough()]
			get { return this._description; }
			set 
			{
				if (this._description != value) 
				{
					this._description = value;
					this.IsDirty = true;	
					OnPropertyChanged("Description");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _userName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string UserName
		{
			[DebuggerStepThrough()]
			get { return this._userName; }
			set 
			{
				if (this._userName != value) 
				{
					this._userName = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _categoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int CategoryID
		{
			[DebuggerStepThrough()]
			get { return this._categoryID; }
			set 
			{
				if (this._categoryID != value) 
				{
					this._categoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CategoryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isStopComment = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsStopComment
		{
			[DebuggerStepThrough()]
			get { return this._isStopComment; }
			set 
			{
				if (this._isStopComment != value) 
				{
					this._isStopComment = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsStopComment");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _stopCommentTime = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool StopCommentTime
		{
			[DebuggerStepThrough()]
			get { return this._stopCommentTime; }
			set 
			{
				if (this._stopCommentTime != value) 
				{
					this._stopCommentTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("StopCommentTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _cityName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CityName
		{
			[DebuggerStepThrough()]
			get { return this._cityName; }
			set 
			{
				if (this._cityName != value) 
				{
					this._cityName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CityName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _threadType = int.MinValue;
		/// <summary>
		/// 1-社区帖子 2-员工之声
		/// </summary>
        [Description("1-社区帖子 2-员工之声")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ThreadType
		{
			[DebuggerStepThrough()]
			get { return this._threadType; }
			set 
			{
				if (this._threadType != value) 
				{
					this._threadType = value;
					this.IsDirty = true;	
					OnPropertyChanged("ThreadType");
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
	[UserID] int,
	[AddTime] datetime,
	[Description] ntext,
	[UserName] nvarchar(200),
	[CategoryID] int,
	[IsStopComment] bit,
	[StopCommentTime] bit,
	[CityName] nvarchar(200),
	[ThreadType] int
);

INSERT INTO [dbo].[Mall_Thread] (
	[Mall_Thread].[UserID],
	[Mall_Thread].[AddTime],
	[Mall_Thread].[Description],
	[Mall_Thread].[UserName],
	[Mall_Thread].[CategoryID],
	[Mall_Thread].[IsStopComment],
	[Mall_Thread].[StopCommentTime],
	[Mall_Thread].[CityName],
	[Mall_Thread].[ThreadType]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[Description],
	INSERTED.[UserName],
	INSERTED.[CategoryID],
	INSERTED.[IsStopComment],
	INSERTED.[StopCommentTime],
	INSERTED.[CityName],
	INSERTED.[ThreadType]
into @table
VALUES ( 
	@UserID,
	@AddTime,
	@Description,
	@UserName,
	@CategoryID,
	@IsStopComment,
	@StopCommentTime,
	@CityName,
	@ThreadType 
); 

SELECT 
	[ID],
	[UserID],
	[AddTime],
	[Description],
	[UserName],
	[CategoryID],
	[IsStopComment],
	[StopCommentTime],
	[CityName],
	[ThreadType] 
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
	[UserID] int,
	[AddTime] datetime,
	[Description] ntext,
	[UserName] nvarchar(200),
	[CategoryID] int,
	[IsStopComment] bit,
	[StopCommentTime] bit,
	[CityName] nvarchar(200),
	[ThreadType] int
);

UPDATE [dbo].[Mall_Thread] SET 
	[Mall_Thread].[UserID] = @UserID,
	[Mall_Thread].[AddTime] = @AddTime,
	[Mall_Thread].[Description] = @Description,
	[Mall_Thread].[UserName] = @UserName,
	[Mall_Thread].[CategoryID] = @CategoryID,
	[Mall_Thread].[IsStopComment] = @IsStopComment,
	[Mall_Thread].[StopCommentTime] = @StopCommentTime,
	[Mall_Thread].[CityName] = @CityName,
	[Mall_Thread].[ThreadType] = @ThreadType 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[Description],
	INSERTED.[UserName],
	INSERTED.[CategoryID],
	INSERTED.[IsStopComment],
	INSERTED.[StopCommentTime],
	INSERTED.[CityName],
	INSERTED.[ThreadType]
into @table
WHERE 
	[Mall_Thread].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[AddTime],
	[Description],
	[UserName],
	[CategoryID],
	[IsStopComment],
	[StopCommentTime],
	[CityName],
	[ThreadType] 
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
DELETE FROM [dbo].[Mall_Thread]
WHERE 
	[Mall_Thread].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_Thread() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_Thread(this.ID));
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
	[Mall_Thread].[ID],
	[Mall_Thread].[UserID],
	[Mall_Thread].[AddTime],
	[Mall_Thread].[Description],
	[Mall_Thread].[UserName],
	[Mall_Thread].[CategoryID],
	[Mall_Thread].[IsStopComment],
	[Mall_Thread].[StopCommentTime],
	[Mall_Thread].[CityName],
	[Mall_Thread].[ThreadType]
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
                return "Mall_Thread";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_Thread into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="description">description</param>
		/// <param name="userName">userName</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="isStopComment">isStopComment</param>
		/// <param name="stopCommentTime">stopCommentTime</param>
		/// <param name="cityName">cityName</param>
		/// <param name="threadType">threadType</param>
		public static void InsertMall_Thread(int @userID, DateTime @addTime, string @description, string @userName, int @categoryID, bool @isStopComment, bool @stopCommentTime, string @cityName, int @threadType)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_Thread(@userID, @addTime, @description, @userName, @categoryID, @isStopComment, @stopCommentTime, @cityName, @threadType, helper);
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
		/// Insert a Mall_Thread into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="description">description</param>
		/// <param name="userName">userName</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="isStopComment">isStopComment</param>
		/// <param name="stopCommentTime">stopCommentTime</param>
		/// <param name="cityName">cityName</param>
		/// <param name="threadType">threadType</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_Thread(int @userID, DateTime @addTime, string @description, string @userName, int @categoryID, bool @isStopComment, bool @stopCommentTime, string @cityName, int @threadType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[AddTime] datetime,
	[Description] ntext,
	[UserName] nvarchar(200),
	[CategoryID] int,
	[IsStopComment] bit,
	[StopCommentTime] bit,
	[CityName] nvarchar(200),
	[ThreadType] int
);

INSERT INTO [dbo].[Mall_Thread] (
	[Mall_Thread].[UserID],
	[Mall_Thread].[AddTime],
	[Mall_Thread].[Description],
	[Mall_Thread].[UserName],
	[Mall_Thread].[CategoryID],
	[Mall_Thread].[IsStopComment],
	[Mall_Thread].[StopCommentTime],
	[Mall_Thread].[CityName],
	[Mall_Thread].[ThreadType]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[Description],
	INSERTED.[UserName],
	INSERTED.[CategoryID],
	INSERTED.[IsStopComment],
	INSERTED.[StopCommentTime],
	INSERTED.[CityName],
	INSERTED.[ThreadType]
into @table
VALUES ( 
	@UserID,
	@AddTime,
	@Description,
	@UserName,
	@CategoryID,
	@IsStopComment,
	@StopCommentTime,
	@CityName,
	@ThreadType 
); 

SELECT 
	[ID],
	[UserID],
	[AddTime],
	[Description],
	[UserName],
	[CategoryID],
	[IsStopComment],
	[StopCommentTime],
	[CityName],
	[ThreadType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@UserName", EntityBase.GetDatabaseValue(@userName)));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			parameters.Add(new SqlParameter("@IsStopComment", @isStopComment));
			parameters.Add(new SqlParameter("@StopCommentTime", @stopCommentTime));
			parameters.Add(new SqlParameter("@CityName", EntityBase.GetDatabaseValue(@cityName)));
			parameters.Add(new SqlParameter("@ThreadType", EntityBase.GetDatabaseValue(@threadType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_Thread into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="description">description</param>
		/// <param name="userName">userName</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="isStopComment">isStopComment</param>
		/// <param name="stopCommentTime">stopCommentTime</param>
		/// <param name="cityName">cityName</param>
		/// <param name="threadType">threadType</param>
		public static void UpdateMall_Thread(int @iD, int @userID, DateTime @addTime, string @description, string @userName, int @categoryID, bool @isStopComment, bool @stopCommentTime, string @cityName, int @threadType)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_Thread(@iD, @userID, @addTime, @description, @userName, @categoryID, @isStopComment, @stopCommentTime, @cityName, @threadType, helper);
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
		/// Updates a Mall_Thread into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="description">description</param>
		/// <param name="userName">userName</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="isStopComment">isStopComment</param>
		/// <param name="stopCommentTime">stopCommentTime</param>
		/// <param name="cityName">cityName</param>
		/// <param name="threadType">threadType</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_Thread(int @iD, int @userID, DateTime @addTime, string @description, string @userName, int @categoryID, bool @isStopComment, bool @stopCommentTime, string @cityName, int @threadType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[AddTime] datetime,
	[Description] ntext,
	[UserName] nvarchar(200),
	[CategoryID] int,
	[IsStopComment] bit,
	[StopCommentTime] bit,
	[CityName] nvarchar(200),
	[ThreadType] int
);

UPDATE [dbo].[Mall_Thread] SET 
	[Mall_Thread].[UserID] = @UserID,
	[Mall_Thread].[AddTime] = @AddTime,
	[Mall_Thread].[Description] = @Description,
	[Mall_Thread].[UserName] = @UserName,
	[Mall_Thread].[CategoryID] = @CategoryID,
	[Mall_Thread].[IsStopComment] = @IsStopComment,
	[Mall_Thread].[StopCommentTime] = @StopCommentTime,
	[Mall_Thread].[CityName] = @CityName,
	[Mall_Thread].[ThreadType] = @ThreadType 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[Description],
	INSERTED.[UserName],
	INSERTED.[CategoryID],
	INSERTED.[IsStopComment],
	INSERTED.[StopCommentTime],
	INSERTED.[CityName],
	INSERTED.[ThreadType]
into @table
WHERE 
	[Mall_Thread].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[AddTime],
	[Description],
	[UserName],
	[CategoryID],
	[IsStopComment],
	[StopCommentTime],
	[CityName],
	[ThreadType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@UserName", EntityBase.GetDatabaseValue(@userName)));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			parameters.Add(new SqlParameter("@IsStopComment", @isStopComment));
			parameters.Add(new SqlParameter("@StopCommentTime", @stopCommentTime));
			parameters.Add(new SqlParameter("@CityName", EntityBase.GetDatabaseValue(@cityName)));
			parameters.Add(new SqlParameter("@ThreadType", EntityBase.GetDatabaseValue(@threadType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_Thread from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_Thread(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_Thread(@iD, helper);
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
		/// Deletes a Mall_Thread from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_Thread(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_Thread]
WHERE 
	[Mall_Thread].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_Thread object.
		/// </summary>
		/// <returns>The newly created Mall_Thread object.</returns>
		public static Mall_Thread CreateMall_Thread()
		{
			return InitializeNew<Mall_Thread>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_Thread by a Mall_Thread's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_Thread</returns>
		public static Mall_Thread GetMall_Thread(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_Thread.SelectFieldList + @"
FROM [dbo].[Mall_Thread] 
WHERE 
	[Mall_Thread].[ID] = @ID " + Mall_Thread.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Thread>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_Thread by a Mall_Thread's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_Thread</returns>
		public static Mall_Thread GetMall_Thread(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_Thread.SelectFieldList + @"
FROM [dbo].[Mall_Thread] 
WHERE 
	[Mall_Thread].[ID] = @ID " + Mall_Thread.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Thread>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_Thread objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_Thread objects.</returns>
		public static EntityList<Mall_Thread> GetMall_Threads()
		{
			string commandText = @"
SELECT " + Mall_Thread.SelectFieldList + "FROM [dbo].[Mall_Thread] " + Mall_Thread.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_Thread>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_Thread objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Thread objects.</returns>
        public static EntityList<Mall_Thread> GetMall_Threads(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Thread>(SelectFieldList, "FROM [dbo].[Mall_Thread]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_Thread objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Thread objects.</returns>
        public static EntityList<Mall_Thread> GetMall_Threads(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Thread>(SelectFieldList, "FROM [dbo].[Mall_Thread]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_Thread objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Thread objects.</returns>
		protected static EntityList<Mall_Thread> GetMall_Threads(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Threads(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_Thread objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Thread objects.</returns>
		protected static EntityList<Mall_Thread> GetMall_Threads(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Threads(string.Empty, where, parameters, Mall_Thread.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Thread objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Thread objects.</returns>
		protected static EntityList<Mall_Thread> GetMall_Threads(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Threads(prefix, where, parameters, Mall_Thread.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Thread objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Thread objects.</returns>
		protected static EntityList<Mall_Thread> GetMall_Threads(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Threads(string.Empty, where, parameters, Mall_Thread.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Thread objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Thread objects.</returns>
		protected static EntityList<Mall_Thread> GetMall_Threads(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Threads(prefix, where, parameters, Mall_Thread.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Thread objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Thread objects.</returns>
		protected static EntityList<Mall_Thread> GetMall_Threads(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_Thread.SelectFieldList + "FROM [dbo].[Mall_Thread] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_Thread>(reader);
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
        protected static EntityList<Mall_Thread> GetMall_Threads(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Thread>(SelectFieldList, "FROM [dbo].[Mall_Thread] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_Thread objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ThreadCount()
        {
            return GetMall_ThreadCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_Thread objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ThreadCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_Thread] " + where;

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
		public static partial class Mall_Thread_Properties
		{
			public const string ID = "ID";
			public const string UserID = "UserID";
			public const string AddTime = "AddTime";
			public const string Description = "Description";
			public const string UserName = "UserName";
			public const string CategoryID = "CategoryID";
			public const string IsStopComment = "IsStopComment";
			public const string StopCommentTime = "StopCommentTime";
			public const string CityName = "CityName";
			public const string ThreadType = "ThreadType";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"Description" , "string:"},
    			 {"UserName" , "string:"},
    			 {"CategoryID" , "int:"},
    			 {"IsStopComment" , "bool:"},
    			 {"StopCommentTime" , "bool:"},
    			 {"CityName" , "string:"},
    			 {"ThreadType" , "int:1-社区帖子 2-员工之声"},
            };
		}
		#endregion
	}
}
