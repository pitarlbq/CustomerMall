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
	/// This object represents the properties and methods of a RoomFee_Note.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class RoomFee_Note 
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
		private string _addMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
		private int _addManID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int AddManID
		{
			[DebuggerStepThrough()]
			get { return this._addManID; }
			set 
			{
				if (this._addManID != value) 
				{
					this._addManID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddManID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _remark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Remark
		{
			[DebuggerStepThrough()]
			get { return this._remark; }
			set 
			{
				if (this._remark != value) 
				{
					this._remark = value;
					this.IsDirty = true;	
					OnPropertyChanged("Remark");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _roomID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RoomID
		{
			[DebuggerStepThrough()]
			get { return this._roomID; }
			set 
			{
				if (this._roomID != value) 
				{
					this._roomID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomID");
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
		private string _oriFileName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OriFileName
		{
			[DebuggerStepThrough()]
			get { return this._oriFileName; }
			set 
			{
				if (this._oriFileName != value) 
				{
					this._oriFileName = value;
					this.IsDirty = true;	
					OnPropertyChanged("OriFileName");
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
	[AddTime] datetime,
	[Title] nvarchar(50),
	[AddMan] nvarchar(100),
	[AddManID] int,
	[Remark] ntext,
	[RoomID] int,
	[FilePath] nvarchar(500),
	[OriFileName] nvarchar(200)
);

INSERT INTO [dbo].[RoomFee_Note] (
	[RoomFee_Note].[AddTime],
	[RoomFee_Note].[Title],
	[RoomFee_Note].[AddMan],
	[RoomFee_Note].[AddManID],
	[RoomFee_Note].[Remark],
	[RoomFee_Note].[RoomID],
	[RoomFee_Note].[FilePath],
	[RoomFee_Note].[OriFileName]
) 
output 
	INSERTED.[ID],
	INSERTED.[AddTime],
	INSERTED.[Title],
	INSERTED.[AddMan],
	INSERTED.[AddManID],
	INSERTED.[Remark],
	INSERTED.[RoomID],
	INSERTED.[FilePath],
	INSERTED.[OriFileName]
into @table
VALUES ( 
	@AddTime,
	@Title,
	@AddMan,
	@AddManID,
	@Remark,
	@RoomID,
	@FilePath,
	@OriFileName 
); 

SELECT 
	[ID],
	[AddTime],
	[Title],
	[AddMan],
	[AddManID],
	[Remark],
	[RoomID],
	[FilePath],
	[OriFileName] 
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
	[AddTime] datetime,
	[Title] nvarchar(50),
	[AddMan] nvarchar(100),
	[AddManID] int,
	[Remark] ntext,
	[RoomID] int,
	[FilePath] nvarchar(500),
	[OriFileName] nvarchar(200)
);

UPDATE [dbo].[RoomFee_Note] SET 
	[RoomFee_Note].[AddTime] = @AddTime,
	[RoomFee_Note].[Title] = @Title,
	[RoomFee_Note].[AddMan] = @AddMan,
	[RoomFee_Note].[AddManID] = @AddManID,
	[RoomFee_Note].[Remark] = @Remark,
	[RoomFee_Note].[RoomID] = @RoomID,
	[RoomFee_Note].[FilePath] = @FilePath,
	[RoomFee_Note].[OriFileName] = @OriFileName 
output 
	INSERTED.[ID],
	INSERTED.[AddTime],
	INSERTED.[Title],
	INSERTED.[AddMan],
	INSERTED.[AddManID],
	INSERTED.[Remark],
	INSERTED.[RoomID],
	INSERTED.[FilePath],
	INSERTED.[OriFileName]
into @table
WHERE 
	[RoomFee_Note].[ID] = @ID

SELECT 
	[ID],
	[AddTime],
	[Title],
	[AddMan],
	[AddManID],
	[Remark],
	[RoomID],
	[FilePath],
	[OriFileName] 
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
DELETE FROM [dbo].[RoomFee_Note]
WHERE 
	[RoomFee_Note].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public RoomFee_Note() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetRoomFee_Note(this.ID));
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
	[RoomFee_Note].[ID],
	[RoomFee_Note].[AddTime],
	[RoomFee_Note].[Title],
	[RoomFee_Note].[AddMan],
	[RoomFee_Note].[AddManID],
	[RoomFee_Note].[Remark],
	[RoomFee_Note].[RoomID],
	[RoomFee_Note].[FilePath],
	[RoomFee_Note].[OriFileName]
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
                return "RoomFee_Note";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a RoomFee_Note into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="addTime">addTime</param>
		/// <param name="title">title</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addManID">addManID</param>
		/// <param name="remark">remark</param>
		/// <param name="roomID">roomID</param>
		/// <param name="filePath">filePath</param>
		/// <param name="oriFileName">oriFileName</param>
		public static void InsertRoomFee_Note(DateTime @addTime, string @title, string @addMan, int @addManID, string @remark, int @roomID, string @filePath, string @oriFileName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertRoomFee_Note(@addTime, @title, @addMan, @addManID, @remark, @roomID, @filePath, @oriFileName, helper);
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
		/// Insert a RoomFee_Note into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="addTime">addTime</param>
		/// <param name="title">title</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addManID">addManID</param>
		/// <param name="remark">remark</param>
		/// <param name="roomID">roomID</param>
		/// <param name="filePath">filePath</param>
		/// <param name="oriFileName">oriFileName</param>
		/// <param name="helper">helper</param>
		internal static void InsertRoomFee_Note(DateTime @addTime, string @title, string @addMan, int @addManID, string @remark, int @roomID, string @filePath, string @oriFileName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AddTime] datetime,
	[Title] nvarchar(50),
	[AddMan] nvarchar(100),
	[AddManID] int,
	[Remark] ntext,
	[RoomID] int,
	[FilePath] nvarchar(500),
	[OriFileName] nvarchar(200)
);

INSERT INTO [dbo].[RoomFee_Note] (
	[RoomFee_Note].[AddTime],
	[RoomFee_Note].[Title],
	[RoomFee_Note].[AddMan],
	[RoomFee_Note].[AddManID],
	[RoomFee_Note].[Remark],
	[RoomFee_Note].[RoomID],
	[RoomFee_Note].[FilePath],
	[RoomFee_Note].[OriFileName]
) 
output 
	INSERTED.[ID],
	INSERTED.[AddTime],
	INSERTED.[Title],
	INSERTED.[AddMan],
	INSERTED.[AddManID],
	INSERTED.[Remark],
	INSERTED.[RoomID],
	INSERTED.[FilePath],
	INSERTED.[OriFileName]
into @table
VALUES ( 
	@AddTime,
	@Title,
	@AddMan,
	@AddManID,
	@Remark,
	@RoomID,
	@FilePath,
	@OriFileName 
); 

SELECT 
	[ID],
	[AddTime],
	[Title],
	[AddMan],
	[AddManID],
	[Remark],
	[RoomID],
	[FilePath],
	[OriFileName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AddManID", EntityBase.GetDatabaseValue(@addManID)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@FilePath", EntityBase.GetDatabaseValue(@filePath)));
			parameters.Add(new SqlParameter("@OriFileName", EntityBase.GetDatabaseValue(@oriFileName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a RoomFee_Note into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="addTime">addTime</param>
		/// <param name="title">title</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addManID">addManID</param>
		/// <param name="remark">remark</param>
		/// <param name="roomID">roomID</param>
		/// <param name="filePath">filePath</param>
		/// <param name="oriFileName">oriFileName</param>
		public static void UpdateRoomFee_Note(int @iD, DateTime @addTime, string @title, string @addMan, int @addManID, string @remark, int @roomID, string @filePath, string @oriFileName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateRoomFee_Note(@iD, @addTime, @title, @addMan, @addManID, @remark, @roomID, @filePath, @oriFileName, helper);
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
		/// Updates a RoomFee_Note into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="addTime">addTime</param>
		/// <param name="title">title</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addManID">addManID</param>
		/// <param name="remark">remark</param>
		/// <param name="roomID">roomID</param>
		/// <param name="filePath">filePath</param>
		/// <param name="oriFileName">oriFileName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateRoomFee_Note(int @iD, DateTime @addTime, string @title, string @addMan, int @addManID, string @remark, int @roomID, string @filePath, string @oriFileName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AddTime] datetime,
	[Title] nvarchar(50),
	[AddMan] nvarchar(100),
	[AddManID] int,
	[Remark] ntext,
	[RoomID] int,
	[FilePath] nvarchar(500),
	[OriFileName] nvarchar(200)
);

UPDATE [dbo].[RoomFee_Note] SET 
	[RoomFee_Note].[AddTime] = @AddTime,
	[RoomFee_Note].[Title] = @Title,
	[RoomFee_Note].[AddMan] = @AddMan,
	[RoomFee_Note].[AddManID] = @AddManID,
	[RoomFee_Note].[Remark] = @Remark,
	[RoomFee_Note].[RoomID] = @RoomID,
	[RoomFee_Note].[FilePath] = @FilePath,
	[RoomFee_Note].[OriFileName] = @OriFileName 
output 
	INSERTED.[ID],
	INSERTED.[AddTime],
	INSERTED.[Title],
	INSERTED.[AddMan],
	INSERTED.[AddManID],
	INSERTED.[Remark],
	INSERTED.[RoomID],
	INSERTED.[FilePath],
	INSERTED.[OriFileName]
into @table
WHERE 
	[RoomFee_Note].[ID] = @ID

SELECT 
	[ID],
	[AddTime],
	[Title],
	[AddMan],
	[AddManID],
	[Remark],
	[RoomID],
	[FilePath],
	[OriFileName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AddManID", EntityBase.GetDatabaseValue(@addManID)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@FilePath", EntityBase.GetDatabaseValue(@filePath)));
			parameters.Add(new SqlParameter("@OriFileName", EntityBase.GetDatabaseValue(@oriFileName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a RoomFee_Note from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteRoomFee_Note(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteRoomFee_Note(@iD, helper);
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
		/// Deletes a RoomFee_Note from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteRoomFee_Note(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[RoomFee_Note]
WHERE 
	[RoomFee_Note].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new RoomFee_Note object.
		/// </summary>
		/// <returns>The newly created RoomFee_Note object.</returns>
		public static RoomFee_Note CreateRoomFee_Note()
		{
			return InitializeNew<RoomFee_Note>();
		}
		
		/// <summary>
		/// Retrieve information for a RoomFee_Note by a RoomFee_Note's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>RoomFee_Note</returns>
		public static RoomFee_Note GetRoomFee_Note(int @iD)
		{
			string commandText = @"
SELECT 
" + RoomFee_Note.SelectFieldList + @"
FROM [dbo].[RoomFee_Note] 
WHERE 
	[RoomFee_Note].[ID] = @ID " + RoomFee_Note.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomFee_Note>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a RoomFee_Note by a RoomFee_Note's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>RoomFee_Note</returns>
		public static RoomFee_Note GetRoomFee_Note(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + RoomFee_Note.SelectFieldList + @"
FROM [dbo].[RoomFee_Note] 
WHERE 
	[RoomFee_Note].[ID] = @ID " + RoomFee_Note.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomFee_Note>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection RoomFee_Note objects.
		/// </summary>
		/// <returns>The retrieved collection of RoomFee_Note objects.</returns>
		public static EntityList<RoomFee_Note> GetRoomFee_Notes()
		{
			string commandText = @"
SELECT " + RoomFee_Note.SelectFieldList + "FROM [dbo].[RoomFee_Note] " + RoomFee_Note.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<RoomFee_Note>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection RoomFee_Note objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomFee_Note objects.</returns>
        public static EntityList<RoomFee_Note> GetRoomFee_Notes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomFee_Note>(SelectFieldList, "FROM [dbo].[RoomFee_Note]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection RoomFee_Note objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomFee_Note objects.</returns>
        public static EntityList<RoomFee_Note> GetRoomFee_Notes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomFee_Note>(SelectFieldList, "FROM [dbo].[RoomFee_Note]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection RoomFee_Note objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of RoomFee_Note objects.</returns>
		protected static EntityList<RoomFee_Note> GetRoomFee_Notes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomFee_Notes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection RoomFee_Note objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomFee_Note objects.</returns>
		protected static EntityList<RoomFee_Note> GetRoomFee_Notes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomFee_Notes(string.Empty, where, parameters, RoomFee_Note.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomFee_Note objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomFee_Note objects.</returns>
		protected static EntityList<RoomFee_Note> GetRoomFee_Notes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomFee_Notes(prefix, where, parameters, RoomFee_Note.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomFee_Note objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomFee_Note objects.</returns>
		protected static EntityList<RoomFee_Note> GetRoomFee_Notes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomFee_Notes(string.Empty, where, parameters, RoomFee_Note.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomFee_Note objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomFee_Note objects.</returns>
		protected static EntityList<RoomFee_Note> GetRoomFee_Notes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomFee_Notes(prefix, where, parameters, RoomFee_Note.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomFee_Note objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of RoomFee_Note objects.</returns>
		protected static EntityList<RoomFee_Note> GetRoomFee_Notes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + RoomFee_Note.SelectFieldList + "FROM [dbo].[RoomFee_Note] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<RoomFee_Note>(reader);
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
        protected static EntityList<RoomFee_Note> GetRoomFee_Notes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomFee_Note>(SelectFieldList, "FROM [dbo].[RoomFee_Note] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of RoomFee_Note objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomFee_NoteCount()
        {
            return GetRoomFee_NoteCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of RoomFee_Note objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomFee_NoteCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[RoomFee_Note] " + where;

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
		public static partial class RoomFee_Note_Properties
		{
			public const string ID = "ID";
			public const string AddTime = "AddTime";
			public const string Title = "Title";
			public const string AddMan = "AddMan";
			public const string AddManID = "AddManID";
			public const string Remark = "Remark";
			public const string RoomID = "RoomID";
			public const string FilePath = "FilePath";
			public const string OriFileName = "OriFileName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"Title" , "string:"},
    			 {"AddMan" , "string:"},
    			 {"AddManID" , "int:"},
    			 {"Remark" , "string:"},
    			 {"RoomID" , "int:"},
    			 {"FilePath" , "string:"},
    			 {"OriFileName" , "string:"},
            };
		}
		#endregion
	}
}
