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
	/// This object represents the properties and methods of a Mall_ServiceComment.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_ServiceComment 
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
		private decimal _rateStar = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RateStar
		{
			[DebuggerStepThrough()]
			get { return this._rateStar; }
			set 
			{
				if (this._rateStar != value) 
				{
					this._rateStar = value;
					this.IsDirty = true;	
					OnPropertyChanged("RateStar");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _rateComment = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RateComment
		{
			[DebuggerStepThrough()]
			get { return this._rateComment; }
			set 
			{
				if (this._rateComment != value) 
				{
					this._rateComment = value;
					this.IsDirty = true;	
					OnPropertyChanged("RateComment");
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
		private bool _isZhuiJia = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsZhuiJia
		{
			[DebuggerStepThrough()]
			get { return this._isZhuiJia; }
			set 
			{
				if (this._isZhuiJia != value) 
				{
					this._isZhuiJia = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsZhuiJia");
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
	[UserID] int,
	[RateStar] decimal(18, 2),
	[RateComment] ntext,
	[AddTime] datetime,
	[IsZhuiJia] bit
);

INSERT INTO [dbo].[Mall_ServiceComment] (
	[Mall_ServiceComment].[ServiceID],
	[Mall_ServiceComment].[UserID],
	[Mall_ServiceComment].[RateStar],
	[Mall_ServiceComment].[RateComment],
	[Mall_ServiceComment].[AddTime],
	[Mall_ServiceComment].[IsZhuiJia]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[UserID],
	INSERTED.[RateStar],
	INSERTED.[RateComment],
	INSERTED.[AddTime],
	INSERTED.[IsZhuiJia]
into @table
VALUES ( 
	@ServiceID,
	@UserID,
	@RateStar,
	@RateComment,
	@AddTime,
	@IsZhuiJia 
); 

SELECT 
	[ID],
	[ServiceID],
	[UserID],
	[RateStar],
	[RateComment],
	[AddTime],
	[IsZhuiJia] 
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
	[UserID] int,
	[RateStar] decimal(18, 2),
	[RateComment] ntext,
	[AddTime] datetime,
	[IsZhuiJia] bit
);

UPDATE [dbo].[Mall_ServiceComment] SET 
	[Mall_ServiceComment].[ServiceID] = @ServiceID,
	[Mall_ServiceComment].[UserID] = @UserID,
	[Mall_ServiceComment].[RateStar] = @RateStar,
	[Mall_ServiceComment].[RateComment] = @RateComment,
	[Mall_ServiceComment].[AddTime] = @AddTime,
	[Mall_ServiceComment].[IsZhuiJia] = @IsZhuiJia 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[UserID],
	INSERTED.[RateStar],
	INSERTED.[RateComment],
	INSERTED.[AddTime],
	INSERTED.[IsZhuiJia]
into @table
WHERE 
	[Mall_ServiceComment].[ID] = @ID

SELECT 
	[ID],
	[ServiceID],
	[UserID],
	[RateStar],
	[RateComment],
	[AddTime],
	[IsZhuiJia] 
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
DELETE FROM [dbo].[Mall_ServiceComment]
WHERE 
	[Mall_ServiceComment].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_ServiceComment() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_ServiceComment(this.ID));
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
	[Mall_ServiceComment].[ID],
	[Mall_ServiceComment].[ServiceID],
	[Mall_ServiceComment].[UserID],
	[Mall_ServiceComment].[RateStar],
	[Mall_ServiceComment].[RateComment],
	[Mall_ServiceComment].[AddTime],
	[Mall_ServiceComment].[IsZhuiJia]
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
                return "Mall_ServiceComment";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_ServiceComment into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="userID">userID</param>
		/// <param name="rateStar">rateStar</param>
		/// <param name="rateComment">rateComment</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isZhuiJia">isZhuiJia</param>
		public static void InsertMall_ServiceComment(int @serviceID, int @userID, decimal @rateStar, string @rateComment, DateTime @addTime, bool @isZhuiJia)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_ServiceComment(@serviceID, @userID, @rateStar, @rateComment, @addTime, @isZhuiJia, helper);
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
		/// Insert a Mall_ServiceComment into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="userID">userID</param>
		/// <param name="rateStar">rateStar</param>
		/// <param name="rateComment">rateComment</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isZhuiJia">isZhuiJia</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_ServiceComment(int @serviceID, int @userID, decimal @rateStar, string @rateComment, DateTime @addTime, bool @isZhuiJia, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceID] int,
	[UserID] int,
	[RateStar] decimal(18, 2),
	[RateComment] ntext,
	[AddTime] datetime,
	[IsZhuiJia] bit
);

INSERT INTO [dbo].[Mall_ServiceComment] (
	[Mall_ServiceComment].[ServiceID],
	[Mall_ServiceComment].[UserID],
	[Mall_ServiceComment].[RateStar],
	[Mall_ServiceComment].[RateComment],
	[Mall_ServiceComment].[AddTime],
	[Mall_ServiceComment].[IsZhuiJia]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[UserID],
	INSERTED.[RateStar],
	INSERTED.[RateComment],
	INSERTED.[AddTime],
	INSERTED.[IsZhuiJia]
into @table
VALUES ( 
	@ServiceID,
	@UserID,
	@RateStar,
	@RateComment,
	@AddTime,
	@IsZhuiJia 
); 

SELECT 
	[ID],
	[ServiceID],
	[UserID],
	[RateStar],
	[RateComment],
	[AddTime],
	[IsZhuiJia] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@RateStar", EntityBase.GetDatabaseValue(@rateStar)));
			parameters.Add(new SqlParameter("@RateComment", EntityBase.GetDatabaseValue(@rateComment)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@IsZhuiJia", @isZhuiJia));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_ServiceComment into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="userID">userID</param>
		/// <param name="rateStar">rateStar</param>
		/// <param name="rateComment">rateComment</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isZhuiJia">isZhuiJia</param>
		public static void UpdateMall_ServiceComment(int @iD, int @serviceID, int @userID, decimal @rateStar, string @rateComment, DateTime @addTime, bool @isZhuiJia)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_ServiceComment(@iD, @serviceID, @userID, @rateStar, @rateComment, @addTime, @isZhuiJia, helper);
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
		/// Updates a Mall_ServiceComment into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="userID">userID</param>
		/// <param name="rateStar">rateStar</param>
		/// <param name="rateComment">rateComment</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isZhuiJia">isZhuiJia</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_ServiceComment(int @iD, int @serviceID, int @userID, decimal @rateStar, string @rateComment, DateTime @addTime, bool @isZhuiJia, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceID] int,
	[UserID] int,
	[RateStar] decimal(18, 2),
	[RateComment] ntext,
	[AddTime] datetime,
	[IsZhuiJia] bit
);

UPDATE [dbo].[Mall_ServiceComment] SET 
	[Mall_ServiceComment].[ServiceID] = @ServiceID,
	[Mall_ServiceComment].[UserID] = @UserID,
	[Mall_ServiceComment].[RateStar] = @RateStar,
	[Mall_ServiceComment].[RateComment] = @RateComment,
	[Mall_ServiceComment].[AddTime] = @AddTime,
	[Mall_ServiceComment].[IsZhuiJia] = @IsZhuiJia 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[UserID],
	INSERTED.[RateStar],
	INSERTED.[RateComment],
	INSERTED.[AddTime],
	INSERTED.[IsZhuiJia]
into @table
WHERE 
	[Mall_ServiceComment].[ID] = @ID

SELECT 
	[ID],
	[ServiceID],
	[UserID],
	[RateStar],
	[RateComment],
	[AddTime],
	[IsZhuiJia] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@RateStar", EntityBase.GetDatabaseValue(@rateStar)));
			parameters.Add(new SqlParameter("@RateComment", EntityBase.GetDatabaseValue(@rateComment)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@IsZhuiJia", @isZhuiJia));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_ServiceComment from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_ServiceComment(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_ServiceComment(@iD, helper);
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
		/// Deletes a Mall_ServiceComment from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_ServiceComment(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_ServiceComment]
WHERE 
	[Mall_ServiceComment].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_ServiceComment object.
		/// </summary>
		/// <returns>The newly created Mall_ServiceComment object.</returns>
		public static Mall_ServiceComment CreateMall_ServiceComment()
		{
			return InitializeNew<Mall_ServiceComment>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_ServiceComment by a Mall_ServiceComment's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_ServiceComment</returns>
		public static Mall_ServiceComment GetMall_ServiceComment(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_ServiceComment.SelectFieldList + @"
FROM [dbo].[Mall_ServiceComment] 
WHERE 
	[Mall_ServiceComment].[ID] = @ID " + Mall_ServiceComment.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ServiceComment>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_ServiceComment by a Mall_ServiceComment's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_ServiceComment</returns>
		public static Mall_ServiceComment GetMall_ServiceComment(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_ServiceComment.SelectFieldList + @"
FROM [dbo].[Mall_ServiceComment] 
WHERE 
	[Mall_ServiceComment].[ID] = @ID " + Mall_ServiceComment.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ServiceComment>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_ServiceComment objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_ServiceComment objects.</returns>
		public static EntityList<Mall_ServiceComment> GetMall_ServiceComments()
		{
			string commandText = @"
SELECT " + Mall_ServiceComment.SelectFieldList + "FROM [dbo].[Mall_ServiceComment] " + Mall_ServiceComment.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_ServiceComment>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_ServiceComment objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ServiceComment objects.</returns>
        public static EntityList<Mall_ServiceComment> GetMall_ServiceComments(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ServiceComment>(SelectFieldList, "FROM [dbo].[Mall_ServiceComment]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_ServiceComment objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ServiceComment objects.</returns>
        public static EntityList<Mall_ServiceComment> GetMall_ServiceComments(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ServiceComment>(SelectFieldList, "FROM [dbo].[Mall_ServiceComment]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_ServiceComment objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ServiceComment objects.</returns>
		protected static EntityList<Mall_ServiceComment> GetMall_ServiceComments(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ServiceComments(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_ServiceComment objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ServiceComment objects.</returns>
		protected static EntityList<Mall_ServiceComment> GetMall_ServiceComments(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ServiceComments(string.Empty, where, parameters, Mall_ServiceComment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ServiceComment objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ServiceComment objects.</returns>
		protected static EntityList<Mall_ServiceComment> GetMall_ServiceComments(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ServiceComments(prefix, where, parameters, Mall_ServiceComment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ServiceComment objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ServiceComment objects.</returns>
		protected static EntityList<Mall_ServiceComment> GetMall_ServiceComments(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ServiceComments(string.Empty, where, parameters, Mall_ServiceComment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ServiceComment objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ServiceComment objects.</returns>
		protected static EntityList<Mall_ServiceComment> GetMall_ServiceComments(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ServiceComments(prefix, where, parameters, Mall_ServiceComment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ServiceComment objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ServiceComment objects.</returns>
		protected static EntityList<Mall_ServiceComment> GetMall_ServiceComments(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_ServiceComment.SelectFieldList + "FROM [dbo].[Mall_ServiceComment] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_ServiceComment>(reader);
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
        protected static EntityList<Mall_ServiceComment> GetMall_ServiceComments(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ServiceComment>(SelectFieldList, "FROM [dbo].[Mall_ServiceComment] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_ServiceComment objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ServiceCommentCount()
        {
            return GetMall_ServiceCommentCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_ServiceComment objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ServiceCommentCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_ServiceComment] " + where;

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
		public static partial class Mall_ServiceComment_Properties
		{
			public const string ID = "ID";
			public const string ServiceID = "ServiceID";
			public const string UserID = "UserID";
			public const string RateStar = "RateStar";
			public const string RateComment = "RateComment";
			public const string AddTime = "AddTime";
			public const string IsZhuiJia = "IsZhuiJia";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ServiceID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"RateStar" , "decimal:"},
    			 {"RateComment" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"IsZhuiJia" , "bool:"},
            };
		}
		#endregion
	}
}
