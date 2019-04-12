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
	/// This object represents the properties and methods of a Wechat_HouseServiceImg.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_HouseServiceImg 
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
		private int _serviceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ServiceID
		{
			[DebuggerStepThrough()]
			get { return this._serviceID; }
			set 
			{
				if (this._serviceID != value) 
				{
					this._serviceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceID");
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
	[ServiceID] int,
	[AttachedFilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

INSERT INTO [dbo].[Wechat_HouseServiceImg] (
	[Wechat_HouseServiceImg].[ServiceID],
	[Wechat_HouseServiceImg].[AttachedFilePath],
	[Wechat_HouseServiceImg].[AddTime],
	[Wechat_HouseServiceImg].[FileOriName]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[AttachedFilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
VALUES ( 
	@ServiceID,
	@AttachedFilePath,
	@AddTime,
	@FileOriName 
); 

SELECT 
	[ID],
	[ServiceID],
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
	[ServiceID] int,
	[AttachedFilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

UPDATE [dbo].[Wechat_HouseServiceImg] SET 
	[Wechat_HouseServiceImg].[ServiceID] = @ServiceID,
	[Wechat_HouseServiceImg].[AttachedFilePath] = @AttachedFilePath,
	[Wechat_HouseServiceImg].[AddTime] = @AddTime,
	[Wechat_HouseServiceImg].[FileOriName] = @FileOriName 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[AttachedFilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
WHERE 
	[Wechat_HouseServiceImg].[ID] = @ID

SELECT 
	[ID],
	[ServiceID],
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
DELETE FROM [dbo].[Wechat_HouseServiceImg]
WHERE 
	[Wechat_HouseServiceImg].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_HouseServiceImg() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_HouseServiceImg(this.ID));
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
	[Wechat_HouseServiceImg].[ID],
	[Wechat_HouseServiceImg].[ServiceID],
	[Wechat_HouseServiceImg].[AttachedFilePath],
	[Wechat_HouseServiceImg].[AddTime],
	[Wechat_HouseServiceImg].[FileOriName]
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
                return "Wechat_HouseServiceImg";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_HouseServiceImg into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="attachedFilePath">attachedFilePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		public static void InsertWechat_HouseServiceImg(int @serviceID, string @attachedFilePath, DateTime @addTime, string @fileOriName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_HouseServiceImg(@serviceID, @attachedFilePath, @addTime, @fileOriName, helper);
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
		/// Insert a Wechat_HouseServiceImg into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="attachedFilePath">attachedFilePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_HouseServiceImg(int @serviceID, string @attachedFilePath, DateTime @addTime, string @fileOriName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceID] int,
	[AttachedFilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

INSERT INTO [dbo].[Wechat_HouseServiceImg] (
	[Wechat_HouseServiceImg].[ServiceID],
	[Wechat_HouseServiceImg].[AttachedFilePath],
	[Wechat_HouseServiceImg].[AddTime],
	[Wechat_HouseServiceImg].[FileOriName]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[AttachedFilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
VALUES ( 
	@ServiceID,
	@AttachedFilePath,
	@AddTime,
	@FileOriName 
); 

SELECT 
	[ID],
	[ServiceID],
	[AttachedFilePath],
	[AddTime],
	[FileOriName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@AttachedFilePath", EntityBase.GetDatabaseValue(@attachedFilePath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@FileOriName", EntityBase.GetDatabaseValue(@fileOriName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_HouseServiceImg into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="attachedFilePath">attachedFilePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		public static void UpdateWechat_HouseServiceImg(int @iD, int @serviceID, string @attachedFilePath, DateTime @addTime, string @fileOriName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_HouseServiceImg(@iD, @serviceID, @attachedFilePath, @addTime, @fileOriName, helper);
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
		/// Updates a Wechat_HouseServiceImg into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="attachedFilePath">attachedFilePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_HouseServiceImg(int @iD, int @serviceID, string @attachedFilePath, DateTime @addTime, string @fileOriName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceID] int,
	[AttachedFilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

UPDATE [dbo].[Wechat_HouseServiceImg] SET 
	[Wechat_HouseServiceImg].[ServiceID] = @ServiceID,
	[Wechat_HouseServiceImg].[AttachedFilePath] = @AttachedFilePath,
	[Wechat_HouseServiceImg].[AddTime] = @AddTime,
	[Wechat_HouseServiceImg].[FileOriName] = @FileOriName 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[AttachedFilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
WHERE 
	[Wechat_HouseServiceImg].[ID] = @ID

SELECT 
	[ID],
	[ServiceID],
	[AttachedFilePath],
	[AddTime],
	[FileOriName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@AttachedFilePath", EntityBase.GetDatabaseValue(@attachedFilePath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@FileOriName", EntityBase.GetDatabaseValue(@fileOriName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_HouseServiceImg from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_HouseServiceImg(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_HouseServiceImg(@iD, helper);
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
		/// Deletes a Wechat_HouseServiceImg from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_HouseServiceImg(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_HouseServiceImg]
WHERE 
	[Wechat_HouseServiceImg].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_HouseServiceImg object.
		/// </summary>
		/// <returns>The newly created Wechat_HouseServiceImg object.</returns>
		public static Wechat_HouseServiceImg CreateWechat_HouseServiceImg()
		{
			return InitializeNew<Wechat_HouseServiceImg>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_HouseServiceImg by a Wechat_HouseServiceImg's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_HouseServiceImg</returns>
		public static Wechat_HouseServiceImg GetWechat_HouseServiceImg(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_HouseServiceImg.SelectFieldList + @"
FROM [dbo].[Wechat_HouseServiceImg] 
WHERE 
	[Wechat_HouseServiceImg].[ID] = @ID " + Wechat_HouseServiceImg.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_HouseServiceImg>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_HouseServiceImg by a Wechat_HouseServiceImg's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_HouseServiceImg</returns>
		public static Wechat_HouseServiceImg GetWechat_HouseServiceImg(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_HouseServiceImg.SelectFieldList + @"
FROM [dbo].[Wechat_HouseServiceImg] 
WHERE 
	[Wechat_HouseServiceImg].[ID] = @ID " + Wechat_HouseServiceImg.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_HouseServiceImg>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceImg objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_HouseServiceImg objects.</returns>
		public static EntityList<Wechat_HouseServiceImg> GetWechat_HouseServiceImgs()
		{
			string commandText = @"
SELECT " + Wechat_HouseServiceImg.SelectFieldList + "FROM [dbo].[Wechat_HouseServiceImg] " + Wechat_HouseServiceImg.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_HouseServiceImg>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_HouseServiceImg objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_HouseServiceImg objects.</returns>
        public static EntityList<Wechat_HouseServiceImg> GetWechat_HouseServiceImgs(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_HouseServiceImg>(SelectFieldList, "FROM [dbo].[Wechat_HouseServiceImg]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_HouseServiceImg objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_HouseServiceImg objects.</returns>
        public static EntityList<Wechat_HouseServiceImg> GetWechat_HouseServiceImgs(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_HouseServiceImg>(SelectFieldList, "FROM [dbo].[Wechat_HouseServiceImg]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceImg objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceImg objects.</returns>
		protected static EntityList<Wechat_HouseServiceImg> GetWechat_HouseServiceImgs(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_HouseServiceImgs(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceImg objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceImg objects.</returns>
		protected static EntityList<Wechat_HouseServiceImg> GetWechat_HouseServiceImgs(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_HouseServiceImgs(string.Empty, where, parameters, Wechat_HouseServiceImg.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceImg objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceImg objects.</returns>
		protected static EntityList<Wechat_HouseServiceImg> GetWechat_HouseServiceImgs(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_HouseServiceImgs(prefix, where, parameters, Wechat_HouseServiceImg.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceImg objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceImg objects.</returns>
		protected static EntityList<Wechat_HouseServiceImg> GetWechat_HouseServiceImgs(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_HouseServiceImgs(string.Empty, where, parameters, Wechat_HouseServiceImg.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceImg objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceImg objects.</returns>
		protected static EntityList<Wechat_HouseServiceImg> GetWechat_HouseServiceImgs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_HouseServiceImgs(prefix, where, parameters, Wechat_HouseServiceImg.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceImg objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceImg objects.</returns>
		protected static EntityList<Wechat_HouseServiceImg> GetWechat_HouseServiceImgs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_HouseServiceImg.SelectFieldList + "FROM [dbo].[Wechat_HouseServiceImg] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_HouseServiceImg>(reader);
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
        protected static EntityList<Wechat_HouseServiceImg> GetWechat_HouseServiceImgs(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_HouseServiceImg>(SelectFieldList, "FROM [dbo].[Wechat_HouseServiceImg] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_HouseServiceImg objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_HouseServiceImgCount()
        {
            return GetWechat_HouseServiceImgCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_HouseServiceImg objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_HouseServiceImgCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_HouseServiceImg] " + where;

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
		public static partial class Wechat_HouseServiceImg_Properties
		{
			public const string ID = "ID";
			public const string ServiceID = "ServiceID";
			public const string AttachedFilePath = "AttachedFilePath";
			public const string AddTime = "AddTime";
			public const string FileOriName = "FileOriName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ServiceID" , "int:"},
    			 {"AttachedFilePath" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"FileOriName" , "string:"},
            };
		}
		#endregion
	}
}
