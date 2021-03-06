﻿using System;
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
	/// This object represents the properties and methods of a Mall_ChatTitle.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_ChatTitle 
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
		private int _fromUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int FromUserID
		{
			[DebuggerStepThrough()]
			get { return this._fromUserID; }
			set 
			{
				if (this._fromUserID != value) 
				{
					this._fromUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("FromUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _toUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ToUserID
		{
			[DebuggerStepThrough()]
			get { return this._toUserID; }
			set 
			{
				if (this._toUserID != value) 
				{
					this._toUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ToUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _toBusinessID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ToBusinessID
		{
			[DebuggerStepThrough()]
			get { return this._toBusinessID; }
			set 
			{
				if (this._toBusinessID != value) 
				{
					this._toBusinessID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ToBusinessID");
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
		private string _addUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string AddUserName
		{
			[DebuggerStepThrough()]
			get { return this._addUserName; }
			set 
			{
				if (this._addUserName != value) 
				{
					this._addUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUserName");
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
		[DataObjectField(false, false, true)]
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
	[FromUserID] int,
	[ToUserID] int,
	[ToBusinessID] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[ProductID] int
);

INSERT INTO [dbo].[Mall_ChatTitle] (
	[Mall_ChatTitle].[FromUserID],
	[Mall_ChatTitle].[ToUserID],
	[Mall_ChatTitle].[ToBusinessID],
	[Mall_ChatTitle].[AddTime],
	[Mall_ChatTitle].[AddUserName],
	[Mall_ChatTitle].[ProductID]
) 
output 
	INSERTED.[ID],
	INSERTED.[FromUserID],
	INSERTED.[ToUserID],
	INSERTED.[ToBusinessID],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ProductID]
into @table
VALUES ( 
	@FromUserID,
	@ToUserID,
	@ToBusinessID,
	@AddTime,
	@AddUserName,
	@ProductID 
); 

SELECT 
	[ID],
	[FromUserID],
	[ToUserID],
	[ToBusinessID],
	[AddTime],
	[AddUserName],
	[ProductID] 
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
	[FromUserID] int,
	[ToUserID] int,
	[ToBusinessID] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[ProductID] int
);

UPDATE [dbo].[Mall_ChatTitle] SET 
	[Mall_ChatTitle].[FromUserID] = @FromUserID,
	[Mall_ChatTitle].[ToUserID] = @ToUserID,
	[Mall_ChatTitle].[ToBusinessID] = @ToBusinessID,
	[Mall_ChatTitle].[AddTime] = @AddTime,
	[Mall_ChatTitle].[AddUserName] = @AddUserName,
	[Mall_ChatTitle].[ProductID] = @ProductID 
output 
	INSERTED.[ID],
	INSERTED.[FromUserID],
	INSERTED.[ToUserID],
	INSERTED.[ToBusinessID],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ProductID]
into @table
WHERE 
	[Mall_ChatTitle].[ID] = @ID

SELECT 
	[ID],
	[FromUserID],
	[ToUserID],
	[ToBusinessID],
	[AddTime],
	[AddUserName],
	[ProductID] 
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
DELETE FROM [dbo].[Mall_ChatTitle]
WHERE 
	[Mall_ChatTitle].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_ChatTitle() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_ChatTitle(this.ID));
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
	[Mall_ChatTitle].[ID],
	[Mall_ChatTitle].[FromUserID],
	[Mall_ChatTitle].[ToUserID],
	[Mall_ChatTitle].[ToBusinessID],
	[Mall_ChatTitle].[AddTime],
	[Mall_ChatTitle].[AddUserName],
	[Mall_ChatTitle].[ProductID]
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
                return "Mall_ChatTitle";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_ChatTitle into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="fromUserID">fromUserID</param>
		/// <param name="toUserID">toUserID</param>
		/// <param name="toBusinessID">toBusinessID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="productID">productID</param>
		public static void InsertMall_ChatTitle(int @fromUserID, int @toUserID, int @toBusinessID, DateTime @addTime, string @addUserName, int @productID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_ChatTitle(@fromUserID, @toUserID, @toBusinessID, @addTime, @addUserName, @productID, helper);
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
		/// Insert a Mall_ChatTitle into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="fromUserID">fromUserID</param>
		/// <param name="toUserID">toUserID</param>
		/// <param name="toBusinessID">toBusinessID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="productID">productID</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_ChatTitle(int @fromUserID, int @toUserID, int @toBusinessID, DateTime @addTime, string @addUserName, int @productID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[FromUserID] int,
	[ToUserID] int,
	[ToBusinessID] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[ProductID] int
);

INSERT INTO [dbo].[Mall_ChatTitle] (
	[Mall_ChatTitle].[FromUserID],
	[Mall_ChatTitle].[ToUserID],
	[Mall_ChatTitle].[ToBusinessID],
	[Mall_ChatTitle].[AddTime],
	[Mall_ChatTitle].[AddUserName],
	[Mall_ChatTitle].[ProductID]
) 
output 
	INSERTED.[ID],
	INSERTED.[FromUserID],
	INSERTED.[ToUserID],
	INSERTED.[ToBusinessID],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ProductID]
into @table
VALUES ( 
	@FromUserID,
	@ToUserID,
	@ToBusinessID,
	@AddTime,
	@AddUserName,
	@ProductID 
); 

SELECT 
	[ID],
	[FromUserID],
	[ToUserID],
	[ToBusinessID],
	[AddTime],
	[AddUserName],
	[ProductID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@FromUserID", EntityBase.GetDatabaseValue(@fromUserID)));
			parameters.Add(new SqlParameter("@ToUserID", EntityBase.GetDatabaseValue(@toUserID)));
			parameters.Add(new SqlParameter("@ToBusinessID", EntityBase.GetDatabaseValue(@toBusinessID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_ChatTitle into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="fromUserID">fromUserID</param>
		/// <param name="toUserID">toUserID</param>
		/// <param name="toBusinessID">toBusinessID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="productID">productID</param>
		public static void UpdateMall_ChatTitle(int @iD, int @fromUserID, int @toUserID, int @toBusinessID, DateTime @addTime, string @addUserName, int @productID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_ChatTitle(@iD, @fromUserID, @toUserID, @toBusinessID, @addTime, @addUserName, @productID, helper);
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
		/// Updates a Mall_ChatTitle into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="fromUserID">fromUserID</param>
		/// <param name="toUserID">toUserID</param>
		/// <param name="toBusinessID">toBusinessID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="productID">productID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_ChatTitle(int @iD, int @fromUserID, int @toUserID, int @toBusinessID, DateTime @addTime, string @addUserName, int @productID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[FromUserID] int,
	[ToUserID] int,
	[ToBusinessID] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[ProductID] int
);

UPDATE [dbo].[Mall_ChatTitle] SET 
	[Mall_ChatTitle].[FromUserID] = @FromUserID,
	[Mall_ChatTitle].[ToUserID] = @ToUserID,
	[Mall_ChatTitle].[ToBusinessID] = @ToBusinessID,
	[Mall_ChatTitle].[AddTime] = @AddTime,
	[Mall_ChatTitle].[AddUserName] = @AddUserName,
	[Mall_ChatTitle].[ProductID] = @ProductID 
output 
	INSERTED.[ID],
	INSERTED.[FromUserID],
	INSERTED.[ToUserID],
	INSERTED.[ToBusinessID],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ProductID]
into @table
WHERE 
	[Mall_ChatTitle].[ID] = @ID

SELECT 
	[ID],
	[FromUserID],
	[ToUserID],
	[ToBusinessID],
	[AddTime],
	[AddUserName],
	[ProductID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@FromUserID", EntityBase.GetDatabaseValue(@fromUserID)));
			parameters.Add(new SqlParameter("@ToUserID", EntityBase.GetDatabaseValue(@toUserID)));
			parameters.Add(new SqlParameter("@ToBusinessID", EntityBase.GetDatabaseValue(@toBusinessID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_ChatTitle from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_ChatTitle(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_ChatTitle(@iD, helper);
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
		/// Deletes a Mall_ChatTitle from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_ChatTitle(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_ChatTitle]
WHERE 
	[Mall_ChatTitle].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_ChatTitle object.
		/// </summary>
		/// <returns>The newly created Mall_ChatTitle object.</returns>
		public static Mall_ChatTitle CreateMall_ChatTitle()
		{
			return InitializeNew<Mall_ChatTitle>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_ChatTitle by a Mall_ChatTitle's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_ChatTitle</returns>
		public static Mall_ChatTitle GetMall_ChatTitle(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_ChatTitle.SelectFieldList + @"
FROM [dbo].[Mall_ChatTitle] 
WHERE 
	[Mall_ChatTitle].[ID] = @ID " + Mall_ChatTitle.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ChatTitle>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_ChatTitle by a Mall_ChatTitle's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_ChatTitle</returns>
		public static Mall_ChatTitle GetMall_ChatTitle(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_ChatTitle.SelectFieldList + @"
FROM [dbo].[Mall_ChatTitle] 
WHERE 
	[Mall_ChatTitle].[ID] = @ID " + Mall_ChatTitle.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ChatTitle>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_ChatTitle objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_ChatTitle objects.</returns>
		public static EntityList<Mall_ChatTitle> GetMall_ChatTitles()
		{
			string commandText = @"
SELECT " + Mall_ChatTitle.SelectFieldList + "FROM [dbo].[Mall_ChatTitle] " + Mall_ChatTitle.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_ChatTitle>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_ChatTitle objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ChatTitle objects.</returns>
        public static EntityList<Mall_ChatTitle> GetMall_ChatTitles(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ChatTitle>(SelectFieldList, "FROM [dbo].[Mall_ChatTitle]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_ChatTitle objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ChatTitle objects.</returns>
        public static EntityList<Mall_ChatTitle> GetMall_ChatTitles(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ChatTitle>(SelectFieldList, "FROM [dbo].[Mall_ChatTitle]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_ChatTitle objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ChatTitle objects.</returns>
		protected static EntityList<Mall_ChatTitle> GetMall_ChatTitles(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ChatTitles(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_ChatTitle objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ChatTitle objects.</returns>
		protected static EntityList<Mall_ChatTitle> GetMall_ChatTitles(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ChatTitles(string.Empty, where, parameters, Mall_ChatTitle.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ChatTitle objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ChatTitle objects.</returns>
		protected static EntityList<Mall_ChatTitle> GetMall_ChatTitles(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ChatTitles(prefix, where, parameters, Mall_ChatTitle.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ChatTitle objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ChatTitle objects.</returns>
		protected static EntityList<Mall_ChatTitle> GetMall_ChatTitles(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ChatTitles(string.Empty, where, parameters, Mall_ChatTitle.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ChatTitle objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ChatTitle objects.</returns>
		protected static EntityList<Mall_ChatTitle> GetMall_ChatTitles(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ChatTitles(prefix, where, parameters, Mall_ChatTitle.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ChatTitle objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ChatTitle objects.</returns>
		protected static EntityList<Mall_ChatTitle> GetMall_ChatTitles(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_ChatTitle.SelectFieldList + "FROM [dbo].[Mall_ChatTitle] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_ChatTitle>(reader);
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
        protected static EntityList<Mall_ChatTitle> GetMall_ChatTitles(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ChatTitle>(SelectFieldList, "FROM [dbo].[Mall_ChatTitle] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_ChatTitle objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ChatTitleCount()
        {
            return GetMall_ChatTitleCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_ChatTitle objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ChatTitleCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_ChatTitle] " + where;

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
		public static partial class Mall_ChatTitle_Properties
		{
			public const string ID = "ID";
			public const string FromUserID = "FromUserID";
			public const string ToUserID = "ToUserID";
			public const string ToBusinessID = "ToBusinessID";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string ProductID = "ProductID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"FromUserID" , "int:"},
    			 {"ToUserID" , "int:"},
    			 {"ToBusinessID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"ProductID" , "int:"},
            };
		}
		#endregion
	}
}
