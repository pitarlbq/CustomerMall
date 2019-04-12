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
	/// This object represents the properties and methods of a SysManual.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class SysManual 
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
		private string _updateMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string UpdateMan
		{
			[DebuggerStepThrough()]
			get { return this._updateMan; }
			set 
			{
				if (this._updateMan != value) 
				{
					this._updateMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("UpdateMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _sortBy = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SortBy
		{
			[DebuggerStepThrough()]
			get { return this._sortBy; }
			set 
			{
				if (this._sortBy != value) 
				{
					this._sortBy = value;
					this.IsDirty = true;	
					OnPropertyChanged("SortBy");
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
		[DataObjectField(false, false, true)]
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
		private int _status = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Status
		{
			[DebuggerStepThrough()]
			get { return this._status; }
			set 
			{
				if (this._status != value) 
				{
					this._status = value;
					this.IsDirty = true;	
					OnPropertyChanged("Status");
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
	[Title] nvarchar(500),
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[UpdateMan] nvarchar(50),
	[SortBy] int,
	[CategoryID] int,
	[Status] int
);

INSERT INTO [dbo].[SysManual] (
	[SysManual].[Title],
	[SysManual].[Description],
	[SysManual].[AddTime],
	[SysManual].[AddMan],
	[SysManual].[UpdateMan],
	[SysManual].[SortBy],
	[SysManual].[CategoryID],
	[SysManual].[Status]
) 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[UpdateMan],
	INSERTED.[SortBy],
	INSERTED.[CategoryID],
	INSERTED.[Status]
into @table
VALUES ( 
	@Title,
	@Description,
	@AddTime,
	@AddMan,
	@UpdateMan,
	@SortBy,
	@CategoryID,
	@Status 
); 

SELECT 
	[ID],
	[Title],
	[Description],
	[AddTime],
	[AddMan],
	[UpdateMan],
	[SortBy],
	[CategoryID],
	[Status] 
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
	[Title] nvarchar(500),
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[UpdateMan] nvarchar(50),
	[SortBy] int,
	[CategoryID] int,
	[Status] int
);

UPDATE [dbo].[SysManual] SET 
	[SysManual].[Title] = @Title,
	[SysManual].[Description] = @Description,
	[SysManual].[AddTime] = @AddTime,
	[SysManual].[AddMan] = @AddMan,
	[SysManual].[UpdateMan] = @UpdateMan,
	[SysManual].[SortBy] = @SortBy,
	[SysManual].[CategoryID] = @CategoryID,
	[SysManual].[Status] = @Status 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[UpdateMan],
	INSERTED.[SortBy],
	INSERTED.[CategoryID],
	INSERTED.[Status]
into @table
WHERE 
	[SysManual].[ID] = @ID

SELECT 
	[ID],
	[Title],
	[Description],
	[AddTime],
	[AddMan],
	[UpdateMan],
	[SortBy],
	[CategoryID],
	[Status] 
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
DELETE FROM [dbo].[SysManual]
WHERE 
	[SysManual].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public SysManual() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetSysManual(this.ID));
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
	[SysManual].[ID],
	[SysManual].[Title],
	[SysManual].[Description],
	[SysManual].[AddTime],
	[SysManual].[AddMan],
	[SysManual].[UpdateMan],
	[SysManual].[SortBy],
	[SysManual].[CategoryID],
	[SysManual].[Status]
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
                return "SysManual";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a SysManual into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="title">title</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="updateMan">updateMan</param>
		/// <param name="sortBy">sortBy</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="status">status</param>
		public static void InsertSysManual(string @title, string @description, DateTime @addTime, string @addMan, string @updateMan, int @sortBy, int @categoryID, int @status)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertSysManual(@title, @description, @addTime, @addMan, @updateMan, @sortBy, @categoryID, @status, helper);
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
		/// Insert a SysManual into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="title">title</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="updateMan">updateMan</param>
		/// <param name="sortBy">sortBy</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="status">status</param>
		/// <param name="helper">helper</param>
		internal static void InsertSysManual(string @title, string @description, DateTime @addTime, string @addMan, string @updateMan, int @sortBy, int @categoryID, int @status, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Title] nvarchar(500),
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[UpdateMan] nvarchar(50),
	[SortBy] int,
	[CategoryID] int,
	[Status] int
);

INSERT INTO [dbo].[SysManual] (
	[SysManual].[Title],
	[SysManual].[Description],
	[SysManual].[AddTime],
	[SysManual].[AddMan],
	[SysManual].[UpdateMan],
	[SysManual].[SortBy],
	[SysManual].[CategoryID],
	[SysManual].[Status]
) 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[UpdateMan],
	INSERTED.[SortBy],
	INSERTED.[CategoryID],
	INSERTED.[Status]
into @table
VALUES ( 
	@Title,
	@Description,
	@AddTime,
	@AddMan,
	@UpdateMan,
	@SortBy,
	@CategoryID,
	@Status 
); 

SELECT 
	[ID],
	[Title],
	[Description],
	[AddTime],
	[AddMan],
	[UpdateMan],
	[SortBy],
	[CategoryID],
	[Status] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@UpdateMan", EntityBase.GetDatabaseValue(@updateMan)));
			parameters.Add(new SqlParameter("@SortBy", EntityBase.GetDatabaseValue(@sortBy)));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a SysManual into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="title">title</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="updateMan">updateMan</param>
		/// <param name="sortBy">sortBy</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="status">status</param>
		public static void UpdateSysManual(int @iD, string @title, string @description, DateTime @addTime, string @addMan, string @updateMan, int @sortBy, int @categoryID, int @status)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateSysManual(@iD, @title, @description, @addTime, @addMan, @updateMan, @sortBy, @categoryID, @status, helper);
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
		/// Updates a SysManual into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="title">title</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="updateMan">updateMan</param>
		/// <param name="sortBy">sortBy</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="status">status</param>
		/// <param name="helper">helper</param>
		internal static void UpdateSysManual(int @iD, string @title, string @description, DateTime @addTime, string @addMan, string @updateMan, int @sortBy, int @categoryID, int @status, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Title] nvarchar(500),
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[UpdateMan] nvarchar(50),
	[SortBy] int,
	[CategoryID] int,
	[Status] int
);

UPDATE [dbo].[SysManual] SET 
	[SysManual].[Title] = @Title,
	[SysManual].[Description] = @Description,
	[SysManual].[AddTime] = @AddTime,
	[SysManual].[AddMan] = @AddMan,
	[SysManual].[UpdateMan] = @UpdateMan,
	[SysManual].[SortBy] = @SortBy,
	[SysManual].[CategoryID] = @CategoryID,
	[SysManual].[Status] = @Status 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[UpdateMan],
	INSERTED.[SortBy],
	INSERTED.[CategoryID],
	INSERTED.[Status]
into @table
WHERE 
	[SysManual].[ID] = @ID

SELECT 
	[ID],
	[Title],
	[Description],
	[AddTime],
	[AddMan],
	[UpdateMan],
	[SortBy],
	[CategoryID],
	[Status] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@UpdateMan", EntityBase.GetDatabaseValue(@updateMan)));
			parameters.Add(new SqlParameter("@SortBy", EntityBase.GetDatabaseValue(@sortBy)));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a SysManual from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteSysManual(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteSysManual(@iD, helper);
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
		/// Deletes a SysManual from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteSysManual(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[SysManual]
WHERE 
	[SysManual].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new SysManual object.
		/// </summary>
		/// <returns>The newly created SysManual object.</returns>
		public static SysManual CreateSysManual()
		{
			return InitializeNew<SysManual>();
		}
		
		/// <summary>
		/// Retrieve information for a SysManual by a SysManual's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>SysManual</returns>
		public static SysManual GetSysManual(int @iD)
		{
			string commandText = @"
SELECT 
" + SysManual.SelectFieldList + @"
FROM [dbo].[SysManual] 
WHERE 
	[SysManual].[ID] = @ID " + SysManual.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<SysManual>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a SysManual by a SysManual's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>SysManual</returns>
		public static SysManual GetSysManual(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + SysManual.SelectFieldList + @"
FROM [dbo].[SysManual] 
WHERE 
	[SysManual].[ID] = @ID " + SysManual.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<SysManual>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection SysManual objects.
		/// </summary>
		/// <returns>The retrieved collection of SysManual objects.</returns>
		public static EntityList<SysManual> GetSysManuals()
		{
			string commandText = @"
SELECT " + SysManual.SelectFieldList + "FROM [dbo].[SysManual] " + SysManual.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<SysManual>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection SysManual objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of SysManual objects.</returns>
        public static EntityList<SysManual> GetSysManuals(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SysManual>(SelectFieldList, "FROM [dbo].[SysManual]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection SysManual objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of SysManual objects.</returns>
        public static EntityList<SysManual> GetSysManuals(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SysManual>(SelectFieldList, "FROM [dbo].[SysManual]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection SysManual objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of SysManual objects.</returns>
		protected static EntityList<SysManual> GetSysManuals(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSysManuals(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection SysManual objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of SysManual objects.</returns>
		protected static EntityList<SysManual> GetSysManuals(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSysManuals(string.Empty, where, parameters, SysManual.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysManual objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of SysManual objects.</returns>
		protected static EntityList<SysManual> GetSysManuals(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSysManuals(prefix, where, parameters, SysManual.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysManual objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of SysManual objects.</returns>
		protected static EntityList<SysManual> GetSysManuals(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSysManuals(string.Empty, where, parameters, SysManual.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysManual objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of SysManual objects.</returns>
		protected static EntityList<SysManual> GetSysManuals(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSysManuals(prefix, where, parameters, SysManual.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysManual objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of SysManual objects.</returns>
		protected static EntityList<SysManual> GetSysManuals(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + SysManual.SelectFieldList + "FROM [dbo].[SysManual] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<SysManual>(reader);
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
        protected static EntityList<SysManual> GetSysManuals(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SysManual>(SelectFieldList, "FROM [dbo].[SysManual] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of SysManual objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSysManualCount()
        {
            return GetSysManualCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of SysManual objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSysManualCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[SysManual] " + where;

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
		public static partial class SysManual_Properties
		{
			public const string ID = "ID";
			public const string Title = "Title";
			public const string Description = "Description";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string UpdateMan = "UpdateMan";
			public const string SortBy = "SortBy";
			public const string CategoryID = "CategoryID";
			public const string Status = "Status";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Title" , "string:"},
    			 {"Description" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"UpdateMan" , "string:"},
    			 {"SortBy" , "int:"},
    			 {"CategoryID" , "int:"},
    			 {"Status" , "int:"},
            };
		}
		#endregion
	}
}
