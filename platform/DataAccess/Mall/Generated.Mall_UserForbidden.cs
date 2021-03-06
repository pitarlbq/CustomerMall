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
	/// This object represents the properties and methods of a Mall_UserForbidden.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_UserForbidden 
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
		private DateTime _forbiddenStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ForbiddenStartTime
		{
			[DebuggerStepThrough()]
			get { return this._forbiddenStartTime; }
			set 
			{
				if (this._forbiddenStartTime != value) 
				{
					this._forbiddenStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ForbiddenStartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _forbiddenEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ForbiddenEndTime
		{
			[DebuggerStepThrough()]
			get { return this._forbiddenEndTime; }
			set 
			{
				if (this._forbiddenEndTime != value) 
				{
					this._forbiddenEndTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ForbiddenEndTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _threadID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ThreadID
		{
			[DebuggerStepThrough()]
			get { return this._threadID; }
			set 
			{
				if (this._threadID != value) 
				{
					this._threadID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ThreadID");
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
	[ForbiddenStartTime] datetime,
	[ForbiddenEndTime] datetime,
	[ThreadID] int,
	[AddTime] datetime
);

INSERT INTO [dbo].[Mall_UserForbidden] (
	[Mall_UserForbidden].[UserID],
	[Mall_UserForbidden].[ForbiddenStartTime],
	[Mall_UserForbidden].[ForbiddenEndTime],
	[Mall_UserForbidden].[ThreadID],
	[Mall_UserForbidden].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[ForbiddenStartTime],
	INSERTED.[ForbiddenEndTime],
	INSERTED.[ThreadID],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@UserID,
	@ForbiddenStartTime,
	@ForbiddenEndTime,
	@ThreadID,
	@AddTime 
); 

SELECT 
	[ID],
	[UserID],
	[ForbiddenStartTime],
	[ForbiddenEndTime],
	[ThreadID],
	[AddTime] 
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
	[ForbiddenStartTime] datetime,
	[ForbiddenEndTime] datetime,
	[ThreadID] int,
	[AddTime] datetime
);

UPDATE [dbo].[Mall_UserForbidden] SET 
	[Mall_UserForbidden].[UserID] = @UserID,
	[Mall_UserForbidden].[ForbiddenStartTime] = @ForbiddenStartTime,
	[Mall_UserForbidden].[ForbiddenEndTime] = @ForbiddenEndTime,
	[Mall_UserForbidden].[ThreadID] = @ThreadID,
	[Mall_UserForbidden].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[ForbiddenStartTime],
	INSERTED.[ForbiddenEndTime],
	INSERTED.[ThreadID],
	INSERTED.[AddTime]
into @table
WHERE 
	[Mall_UserForbidden].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[ForbiddenStartTime],
	[ForbiddenEndTime],
	[ThreadID],
	[AddTime] 
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
DELETE FROM [dbo].[Mall_UserForbidden]
WHERE 
	[Mall_UserForbidden].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_UserForbidden() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_UserForbidden(this.ID));
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
	[Mall_UserForbidden].[ID],
	[Mall_UserForbidden].[UserID],
	[Mall_UserForbidden].[ForbiddenStartTime],
	[Mall_UserForbidden].[ForbiddenEndTime],
	[Mall_UserForbidden].[ThreadID],
	[Mall_UserForbidden].[AddTime]
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
                return "Mall_UserForbidden";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_UserForbidden into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="forbiddenStartTime">forbiddenStartTime</param>
		/// <param name="forbiddenEndTime">forbiddenEndTime</param>
		/// <param name="threadID">threadID</param>
		/// <param name="addTime">addTime</param>
		public static void InsertMall_UserForbidden(int @userID, DateTime @forbiddenStartTime, DateTime @forbiddenEndTime, int @threadID, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_UserForbidden(@userID, @forbiddenStartTime, @forbiddenEndTime, @threadID, @addTime, helper);
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
		/// Insert a Mall_UserForbidden into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="forbiddenStartTime">forbiddenStartTime</param>
		/// <param name="forbiddenEndTime">forbiddenEndTime</param>
		/// <param name="threadID">threadID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_UserForbidden(int @userID, DateTime @forbiddenStartTime, DateTime @forbiddenEndTime, int @threadID, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[ForbiddenStartTime] datetime,
	[ForbiddenEndTime] datetime,
	[ThreadID] int,
	[AddTime] datetime
);

INSERT INTO [dbo].[Mall_UserForbidden] (
	[Mall_UserForbidden].[UserID],
	[Mall_UserForbidden].[ForbiddenStartTime],
	[Mall_UserForbidden].[ForbiddenEndTime],
	[Mall_UserForbidden].[ThreadID],
	[Mall_UserForbidden].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[ForbiddenStartTime],
	INSERTED.[ForbiddenEndTime],
	INSERTED.[ThreadID],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@UserID,
	@ForbiddenStartTime,
	@ForbiddenEndTime,
	@ThreadID,
	@AddTime 
); 

SELECT 
	[ID],
	[UserID],
	[ForbiddenStartTime],
	[ForbiddenEndTime],
	[ThreadID],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@ForbiddenStartTime", EntityBase.GetDatabaseValue(@forbiddenStartTime)));
			parameters.Add(new SqlParameter("@ForbiddenEndTime", EntityBase.GetDatabaseValue(@forbiddenEndTime)));
			parameters.Add(new SqlParameter("@ThreadID", EntityBase.GetDatabaseValue(@threadID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_UserForbidden into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="forbiddenStartTime">forbiddenStartTime</param>
		/// <param name="forbiddenEndTime">forbiddenEndTime</param>
		/// <param name="threadID">threadID</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateMall_UserForbidden(int @iD, int @userID, DateTime @forbiddenStartTime, DateTime @forbiddenEndTime, int @threadID, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_UserForbidden(@iD, @userID, @forbiddenStartTime, @forbiddenEndTime, @threadID, @addTime, helper);
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
		/// Updates a Mall_UserForbidden into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="forbiddenStartTime">forbiddenStartTime</param>
		/// <param name="forbiddenEndTime">forbiddenEndTime</param>
		/// <param name="threadID">threadID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_UserForbidden(int @iD, int @userID, DateTime @forbiddenStartTime, DateTime @forbiddenEndTime, int @threadID, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[ForbiddenStartTime] datetime,
	[ForbiddenEndTime] datetime,
	[ThreadID] int,
	[AddTime] datetime
);

UPDATE [dbo].[Mall_UserForbidden] SET 
	[Mall_UserForbidden].[UserID] = @UserID,
	[Mall_UserForbidden].[ForbiddenStartTime] = @ForbiddenStartTime,
	[Mall_UserForbidden].[ForbiddenEndTime] = @ForbiddenEndTime,
	[Mall_UserForbidden].[ThreadID] = @ThreadID,
	[Mall_UserForbidden].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[ForbiddenStartTime],
	INSERTED.[ForbiddenEndTime],
	INSERTED.[ThreadID],
	INSERTED.[AddTime]
into @table
WHERE 
	[Mall_UserForbidden].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[ForbiddenStartTime],
	[ForbiddenEndTime],
	[ThreadID],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@ForbiddenStartTime", EntityBase.GetDatabaseValue(@forbiddenStartTime)));
			parameters.Add(new SqlParameter("@ForbiddenEndTime", EntityBase.GetDatabaseValue(@forbiddenEndTime)));
			parameters.Add(new SqlParameter("@ThreadID", EntityBase.GetDatabaseValue(@threadID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_UserForbidden from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_UserForbidden(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_UserForbidden(@iD, helper);
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
		/// Deletes a Mall_UserForbidden from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_UserForbidden(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_UserForbidden]
WHERE 
	[Mall_UserForbidden].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_UserForbidden object.
		/// </summary>
		/// <returns>The newly created Mall_UserForbidden object.</returns>
		public static Mall_UserForbidden CreateMall_UserForbidden()
		{
			return InitializeNew<Mall_UserForbidden>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_UserForbidden by a Mall_UserForbidden's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_UserForbidden</returns>
		public static Mall_UserForbidden GetMall_UserForbidden(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_UserForbidden.SelectFieldList + @"
FROM [dbo].[Mall_UserForbidden] 
WHERE 
	[Mall_UserForbidden].[ID] = @ID " + Mall_UserForbidden.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_UserForbidden>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_UserForbidden by a Mall_UserForbidden's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_UserForbidden</returns>
		public static Mall_UserForbidden GetMall_UserForbidden(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_UserForbidden.SelectFieldList + @"
FROM [dbo].[Mall_UserForbidden] 
WHERE 
	[Mall_UserForbidden].[ID] = @ID " + Mall_UserForbidden.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_UserForbidden>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserForbidden objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_UserForbidden objects.</returns>
		public static EntityList<Mall_UserForbidden> GetMall_UserForbiddens()
		{
			string commandText = @"
SELECT " + Mall_UserForbidden.SelectFieldList + "FROM [dbo].[Mall_UserForbidden] " + Mall_UserForbidden.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_UserForbidden>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_UserForbidden objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_UserForbidden objects.</returns>
        public static EntityList<Mall_UserForbidden> GetMall_UserForbiddens(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserForbidden>(SelectFieldList, "FROM [dbo].[Mall_UserForbidden]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_UserForbidden objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_UserForbidden objects.</returns>
        public static EntityList<Mall_UserForbidden> GetMall_UserForbiddens(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserForbidden>(SelectFieldList, "FROM [dbo].[Mall_UserForbidden]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_UserForbidden objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_UserForbidden objects.</returns>
		protected static EntityList<Mall_UserForbidden> GetMall_UserForbiddens(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserForbiddens(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserForbidden objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserForbidden objects.</returns>
		protected static EntityList<Mall_UserForbidden> GetMall_UserForbiddens(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserForbiddens(string.Empty, where, parameters, Mall_UserForbidden.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserForbidden objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserForbidden objects.</returns>
		protected static EntityList<Mall_UserForbidden> GetMall_UserForbiddens(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserForbiddens(prefix, where, parameters, Mall_UserForbidden.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserForbidden objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserForbidden objects.</returns>
		protected static EntityList<Mall_UserForbidden> GetMall_UserForbiddens(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_UserForbiddens(string.Empty, where, parameters, Mall_UserForbidden.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserForbidden objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserForbidden objects.</returns>
		protected static EntityList<Mall_UserForbidden> GetMall_UserForbiddens(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_UserForbiddens(prefix, where, parameters, Mall_UserForbidden.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserForbidden objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_UserForbidden objects.</returns>
		protected static EntityList<Mall_UserForbidden> GetMall_UserForbiddens(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_UserForbidden.SelectFieldList + "FROM [dbo].[Mall_UserForbidden] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_UserForbidden>(reader);
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
        protected static EntityList<Mall_UserForbidden> GetMall_UserForbiddens(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserForbidden>(SelectFieldList, "FROM [dbo].[Mall_UserForbidden] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_UserForbidden objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_UserForbiddenCount()
        {
            return GetMall_UserForbiddenCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_UserForbidden objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_UserForbiddenCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_UserForbidden] " + where;

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
		public static partial class Mall_UserForbidden_Properties
		{
			public const string ID = "ID";
			public const string UserID = "UserID";
			public const string ForbiddenStartTime = "ForbiddenStartTime";
			public const string ForbiddenEndTime = "ForbiddenEndTime";
			public const string ThreadID = "ThreadID";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"ForbiddenStartTime" , "DateTime:"},
    			 {"ForbiddenEndTime" , "DateTime:"},
    			 {"ThreadID" , "int:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
