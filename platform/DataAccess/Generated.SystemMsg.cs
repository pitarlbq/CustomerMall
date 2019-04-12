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
	/// This object represents the properties and methods of a SystemMsg.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class SystemMsg 
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
		private int _fromID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int FromID
		{
			[DebuggerStepThrough()]
			get { return this._fromID; }
			set 
			{
				if (this._fromID != value) 
				{
					this._fromID = value;
					this.IsDirty = true;	
					OnPropertyChanged("FromID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _title = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Title
		{
			[DebuggerStepThrough()]
			get { return this._title; }
			set 
			{
				if (this._title != value) 
				{
					this._title = value;
					this.IsDirty = true;	
					OnPropertyChanged("Title");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contentSummary = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContentSummary
		{
			[DebuggerStepThrough()]
			get { return this._contentSummary; }
			set 
			{
				if (this._contentSummary != value) 
				{
					this._contentSummary = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContentSummary");
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
		private bool _isTopShow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsTopShow
		{
			[DebuggerStepThrough()]
			get { return this._isTopShow; }
			set 
			{
				if (this._isTopShow != value) 
				{
					this._isTopShow = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsTopShow");
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
		private bool _isReading = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsReading
		{
			[DebuggerStepThrough()]
			get { return this._isReading; }
			set 
			{
				if (this._isReading != value) 
				{
					this._isReading = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsReading");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _readingTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ReadingTime
		{
			[DebuggerStepThrough()]
			get { return this._readingTime; }
			set 
			{
				if (this._readingTime != value) 
				{
					this._readingTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ReadingTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _disableNotify = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool DisableNotify
		{
			[DebuggerStepThrough()]
			get { return this._disableNotify; }
			set 
			{
				if (this._disableNotify != value) 
				{
					this._disableNotify = value;
					this.IsDirty = true;	
					OnPropertyChanged("DisableNotify");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isNotifyALL = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsNotifyALL
		{
			[DebuggerStepThrough()]
			get { return this._isNotifyALL; }
			set 
			{
				if (this._isNotifyALL != value) 
				{
					this._isNotifyALL = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsNotifyALL");
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
	[FromID] int,
	[Title] nvarchar(200),
	[ContentSummary] ntext,
	[SortOrder] int,
	[IsTopShow] bit,
	[AddTime] datetime,
	[IsReading] bit,
	[ReadingTime] datetime,
	[DisableNotify] bit,
	[IsNotifyALL] bit
);

INSERT INTO [dbo].[SystemMsg] (
	[SystemMsg].[FromID],
	[SystemMsg].[Title],
	[SystemMsg].[ContentSummary],
	[SystemMsg].[SortOrder],
	[SystemMsg].[IsTopShow],
	[SystemMsg].[AddTime],
	[SystemMsg].[IsReading],
	[SystemMsg].[ReadingTime],
	[SystemMsg].[DisableNotify],
	[SystemMsg].[IsNotifyALL]
) 
output 
	INSERTED.[ID],
	INSERTED.[FromID],
	INSERTED.[Title],
	INSERTED.[ContentSummary],
	INSERTED.[SortOrder],
	INSERTED.[IsTopShow],
	INSERTED.[AddTime],
	INSERTED.[IsReading],
	INSERTED.[ReadingTime],
	INSERTED.[DisableNotify],
	INSERTED.[IsNotifyALL]
into @table
VALUES ( 
	@FromID,
	@Title,
	@ContentSummary,
	@SortOrder,
	@IsTopShow,
	@AddTime,
	@IsReading,
	@ReadingTime,
	@DisableNotify,
	@IsNotifyALL 
); 

SELECT 
	[ID],
	[FromID],
	[Title],
	[ContentSummary],
	[SortOrder],
	[IsTopShow],
	[AddTime],
	[IsReading],
	[ReadingTime],
	[DisableNotify],
	[IsNotifyALL] 
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
	[FromID] int,
	[Title] nvarchar(200),
	[ContentSummary] ntext,
	[SortOrder] int,
	[IsTopShow] bit,
	[AddTime] datetime,
	[IsReading] bit,
	[ReadingTime] datetime,
	[DisableNotify] bit,
	[IsNotifyALL] bit
);

UPDATE [dbo].[SystemMsg] SET 
	[SystemMsg].[FromID] = @FromID,
	[SystemMsg].[Title] = @Title,
	[SystemMsg].[ContentSummary] = @ContentSummary,
	[SystemMsg].[SortOrder] = @SortOrder,
	[SystemMsg].[IsTopShow] = @IsTopShow,
	[SystemMsg].[AddTime] = @AddTime,
	[SystemMsg].[IsReading] = @IsReading,
	[SystemMsg].[ReadingTime] = @ReadingTime,
	[SystemMsg].[DisableNotify] = @DisableNotify,
	[SystemMsg].[IsNotifyALL] = @IsNotifyALL 
output 
	INSERTED.[ID],
	INSERTED.[FromID],
	INSERTED.[Title],
	INSERTED.[ContentSummary],
	INSERTED.[SortOrder],
	INSERTED.[IsTopShow],
	INSERTED.[AddTime],
	INSERTED.[IsReading],
	INSERTED.[ReadingTime],
	INSERTED.[DisableNotify],
	INSERTED.[IsNotifyALL]
into @table
WHERE 
	[SystemMsg].[ID] = @ID

SELECT 
	[ID],
	[FromID],
	[Title],
	[ContentSummary],
	[SortOrder],
	[IsTopShow],
	[AddTime],
	[IsReading],
	[ReadingTime],
	[DisableNotify],
	[IsNotifyALL] 
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
DELETE FROM [dbo].[SystemMsg]
WHERE 
	[SystemMsg].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public SystemMsg() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetSystemMsg(this.ID));
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
	[SystemMsg].[ID],
	[SystemMsg].[FromID],
	[SystemMsg].[Title],
	[SystemMsg].[ContentSummary],
	[SystemMsg].[SortOrder],
	[SystemMsg].[IsTopShow],
	[SystemMsg].[AddTime],
	[SystemMsg].[IsReading],
	[SystemMsg].[ReadingTime],
	[SystemMsg].[DisableNotify],
	[SystemMsg].[IsNotifyALL]
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
                return "SystemMsg";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a SystemMsg into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="fromID">fromID</param>
		/// <param name="title">title</param>
		/// <param name="contentSummary">contentSummary</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isTopShow">isTopShow</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isReading">isReading</param>
		/// <param name="readingTime">readingTime</param>
		/// <param name="disableNotify">disableNotify</param>
		/// <param name="isNotifyALL">isNotifyALL</param>
		public static void InsertSystemMsg(int @fromID, string @title, string @contentSummary, int @sortOrder, bool @isTopShow, DateTime @addTime, bool @isReading, DateTime @readingTime, bool @disableNotify, bool @isNotifyALL)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertSystemMsg(@fromID, @title, @contentSummary, @sortOrder, @isTopShow, @addTime, @isReading, @readingTime, @disableNotify, @isNotifyALL, helper);
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
		/// Insert a SystemMsg into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="fromID">fromID</param>
		/// <param name="title">title</param>
		/// <param name="contentSummary">contentSummary</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isTopShow">isTopShow</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isReading">isReading</param>
		/// <param name="readingTime">readingTime</param>
		/// <param name="disableNotify">disableNotify</param>
		/// <param name="isNotifyALL">isNotifyALL</param>
		/// <param name="helper">helper</param>
		internal static void InsertSystemMsg(int @fromID, string @title, string @contentSummary, int @sortOrder, bool @isTopShow, DateTime @addTime, bool @isReading, DateTime @readingTime, bool @disableNotify, bool @isNotifyALL, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[FromID] int,
	[Title] nvarchar(200),
	[ContentSummary] ntext,
	[SortOrder] int,
	[IsTopShow] bit,
	[AddTime] datetime,
	[IsReading] bit,
	[ReadingTime] datetime,
	[DisableNotify] bit,
	[IsNotifyALL] bit
);

INSERT INTO [dbo].[SystemMsg] (
	[SystemMsg].[FromID],
	[SystemMsg].[Title],
	[SystemMsg].[ContentSummary],
	[SystemMsg].[SortOrder],
	[SystemMsg].[IsTopShow],
	[SystemMsg].[AddTime],
	[SystemMsg].[IsReading],
	[SystemMsg].[ReadingTime],
	[SystemMsg].[DisableNotify],
	[SystemMsg].[IsNotifyALL]
) 
output 
	INSERTED.[ID],
	INSERTED.[FromID],
	INSERTED.[Title],
	INSERTED.[ContentSummary],
	INSERTED.[SortOrder],
	INSERTED.[IsTopShow],
	INSERTED.[AddTime],
	INSERTED.[IsReading],
	INSERTED.[ReadingTime],
	INSERTED.[DisableNotify],
	INSERTED.[IsNotifyALL]
into @table
VALUES ( 
	@FromID,
	@Title,
	@ContentSummary,
	@SortOrder,
	@IsTopShow,
	@AddTime,
	@IsReading,
	@ReadingTime,
	@DisableNotify,
	@IsNotifyALL 
); 

SELECT 
	[ID],
	[FromID],
	[Title],
	[ContentSummary],
	[SortOrder],
	[IsTopShow],
	[AddTime],
	[IsReading],
	[ReadingTime],
	[DisableNotify],
	[IsNotifyALL] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@FromID", EntityBase.GetDatabaseValue(@fromID)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@ContentSummary", EntityBase.GetDatabaseValue(@contentSummary)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsTopShow", @isTopShow));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@IsReading", @isReading));
			parameters.Add(new SqlParameter("@ReadingTime", EntityBase.GetDatabaseValue(@readingTime)));
			parameters.Add(new SqlParameter("@DisableNotify", @disableNotify));
			parameters.Add(new SqlParameter("@IsNotifyALL", @isNotifyALL));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a SystemMsg into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="fromID">fromID</param>
		/// <param name="title">title</param>
		/// <param name="contentSummary">contentSummary</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isTopShow">isTopShow</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isReading">isReading</param>
		/// <param name="readingTime">readingTime</param>
		/// <param name="disableNotify">disableNotify</param>
		/// <param name="isNotifyALL">isNotifyALL</param>
		public static void UpdateSystemMsg(int @iD, int @fromID, string @title, string @contentSummary, int @sortOrder, bool @isTopShow, DateTime @addTime, bool @isReading, DateTime @readingTime, bool @disableNotify, bool @isNotifyALL)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateSystemMsg(@iD, @fromID, @title, @contentSummary, @sortOrder, @isTopShow, @addTime, @isReading, @readingTime, @disableNotify, @isNotifyALL, helper);
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
		/// Updates a SystemMsg into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="fromID">fromID</param>
		/// <param name="title">title</param>
		/// <param name="contentSummary">contentSummary</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isTopShow">isTopShow</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isReading">isReading</param>
		/// <param name="readingTime">readingTime</param>
		/// <param name="disableNotify">disableNotify</param>
		/// <param name="isNotifyALL">isNotifyALL</param>
		/// <param name="helper">helper</param>
		internal static void UpdateSystemMsg(int @iD, int @fromID, string @title, string @contentSummary, int @sortOrder, bool @isTopShow, DateTime @addTime, bool @isReading, DateTime @readingTime, bool @disableNotify, bool @isNotifyALL, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[FromID] int,
	[Title] nvarchar(200),
	[ContentSummary] ntext,
	[SortOrder] int,
	[IsTopShow] bit,
	[AddTime] datetime,
	[IsReading] bit,
	[ReadingTime] datetime,
	[DisableNotify] bit,
	[IsNotifyALL] bit
);

UPDATE [dbo].[SystemMsg] SET 
	[SystemMsg].[FromID] = @FromID,
	[SystemMsg].[Title] = @Title,
	[SystemMsg].[ContentSummary] = @ContentSummary,
	[SystemMsg].[SortOrder] = @SortOrder,
	[SystemMsg].[IsTopShow] = @IsTopShow,
	[SystemMsg].[AddTime] = @AddTime,
	[SystemMsg].[IsReading] = @IsReading,
	[SystemMsg].[ReadingTime] = @ReadingTime,
	[SystemMsg].[DisableNotify] = @DisableNotify,
	[SystemMsg].[IsNotifyALL] = @IsNotifyALL 
output 
	INSERTED.[ID],
	INSERTED.[FromID],
	INSERTED.[Title],
	INSERTED.[ContentSummary],
	INSERTED.[SortOrder],
	INSERTED.[IsTopShow],
	INSERTED.[AddTime],
	INSERTED.[IsReading],
	INSERTED.[ReadingTime],
	INSERTED.[DisableNotify],
	INSERTED.[IsNotifyALL]
into @table
WHERE 
	[SystemMsg].[ID] = @ID

SELECT 
	[ID],
	[FromID],
	[Title],
	[ContentSummary],
	[SortOrder],
	[IsTopShow],
	[AddTime],
	[IsReading],
	[ReadingTime],
	[DisableNotify],
	[IsNotifyALL] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@FromID", EntityBase.GetDatabaseValue(@fromID)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@ContentSummary", EntityBase.GetDatabaseValue(@contentSummary)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsTopShow", @isTopShow));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@IsReading", @isReading));
			parameters.Add(new SqlParameter("@ReadingTime", EntityBase.GetDatabaseValue(@readingTime)));
			parameters.Add(new SqlParameter("@DisableNotify", @disableNotify));
			parameters.Add(new SqlParameter("@IsNotifyALL", @isNotifyALL));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a SystemMsg from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteSystemMsg(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteSystemMsg(@iD, helper);
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
		/// Deletes a SystemMsg from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteSystemMsg(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[SystemMsg]
WHERE 
	[SystemMsg].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new SystemMsg object.
		/// </summary>
		/// <returns>The newly created SystemMsg object.</returns>
		public static SystemMsg CreateSystemMsg()
		{
			return InitializeNew<SystemMsg>();
		}
		
		/// <summary>
		/// Retrieve information for a SystemMsg by a SystemMsg's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>SystemMsg</returns>
		public static SystemMsg GetSystemMsg(int @iD)
		{
			string commandText = @"
SELECT 
" + SystemMsg.SelectFieldList + @"
FROM [dbo].[SystemMsg] 
WHERE 
	[SystemMsg].[ID] = @ID " + SystemMsg.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<SystemMsg>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a SystemMsg by a SystemMsg's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>SystemMsg</returns>
		public static SystemMsg GetSystemMsg(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + SystemMsg.SelectFieldList + @"
FROM [dbo].[SystemMsg] 
WHERE 
	[SystemMsg].[ID] = @ID " + SystemMsg.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<SystemMsg>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection SystemMsg objects.
		/// </summary>
		/// <returns>The retrieved collection of SystemMsg objects.</returns>
		public static EntityList<SystemMsg> GetSystemMsgs()
		{
			string commandText = @"
SELECT " + SystemMsg.SelectFieldList + "FROM [dbo].[SystemMsg] " + SystemMsg.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<SystemMsg>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection SystemMsg objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of SystemMsg objects.</returns>
        public static EntityList<SystemMsg> GetSystemMsgs(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SystemMsg>(SelectFieldList, "FROM [dbo].[SystemMsg]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection SystemMsg objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of SystemMsg objects.</returns>
        public static EntityList<SystemMsg> GetSystemMsgs(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SystemMsg>(SelectFieldList, "FROM [dbo].[SystemMsg]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection SystemMsg objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of SystemMsg objects.</returns>
		protected static EntityList<SystemMsg> GetSystemMsgs(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSystemMsgs(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection SystemMsg objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of SystemMsg objects.</returns>
		protected static EntityList<SystemMsg> GetSystemMsgs(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSystemMsgs(string.Empty, where, parameters, SystemMsg.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SystemMsg objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of SystemMsg objects.</returns>
		protected static EntityList<SystemMsg> GetSystemMsgs(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSystemMsgs(prefix, where, parameters, SystemMsg.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SystemMsg objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of SystemMsg objects.</returns>
		protected static EntityList<SystemMsg> GetSystemMsgs(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSystemMsgs(string.Empty, where, parameters, SystemMsg.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SystemMsg objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of SystemMsg objects.</returns>
		protected static EntityList<SystemMsg> GetSystemMsgs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSystemMsgs(prefix, where, parameters, SystemMsg.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SystemMsg objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of SystemMsg objects.</returns>
		protected static EntityList<SystemMsg> GetSystemMsgs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + SystemMsg.SelectFieldList + "FROM [dbo].[SystemMsg] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<SystemMsg>(reader);
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
        protected static EntityList<SystemMsg> GetSystemMsgs(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SystemMsg>(SelectFieldList, "FROM [dbo].[SystemMsg] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of SystemMsg objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSystemMsgCount()
        {
            return GetSystemMsgCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of SystemMsg objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSystemMsgCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[SystemMsg] " + where;

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
		public static partial class SystemMsg_Properties
		{
			public const string ID = "ID";
			public const string FromID = "FromID";
			public const string Title = "Title";
			public const string ContentSummary = "ContentSummary";
			public const string SortOrder = "SortOrder";
			public const string IsTopShow = "IsTopShow";
			public const string AddTime = "AddTime";
			public const string IsReading = "IsReading";
			public const string ReadingTime = "ReadingTime";
			public const string DisableNotify = "DisableNotify";
			public const string IsNotifyALL = "IsNotifyALL";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"FromID" , "int:"},
    			 {"Title" , "string:"},
    			 {"ContentSummary" , "string:"},
    			 {"SortOrder" , "int:"},
    			 {"IsTopShow" , "bool:"},
    			 {"AddTime" , "DateTime:"},
    			 {"IsReading" , "bool:"},
    			 {"ReadingTime" , "DateTime:"},
    			 {"DisableNotify" , "bool:"},
    			 {"IsNotifyALL" , "bool:"},
            };
		}
		#endregion
	}
}
