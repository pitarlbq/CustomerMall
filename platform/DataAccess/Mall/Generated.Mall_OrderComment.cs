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
	/// This object represents the properties and methods of a Mall_OrderComment.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_OrderComment 
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
		private int _orderID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int OrderID
		{
			[DebuggerStepThrough()]
			get { return this._orderID; }
			set 
			{
				if (this._orderID != value) 
				{
					this._orderID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderID");
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
		private int _businessID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int BusinessID
		{
			[DebuggerStepThrough()]
			get { return this._businessID; }
			set 
			{
				if (this._businessID != value) 
				{
					this._businessID = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessID");
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
	[OrderID] int,
	[UserID] int,
	[RateStar] decimal(18, 2),
	[RateComment] ntext,
	[AddTime] datetime,
	[BusinessID] int,
	[ProductID] int,
	[IsZhuiJia] bit
);

INSERT INTO [dbo].[Mall_OrderComment] (
	[Mall_OrderComment].[OrderID],
	[Mall_OrderComment].[UserID],
	[Mall_OrderComment].[RateStar],
	[Mall_OrderComment].[RateComment],
	[Mall_OrderComment].[AddTime],
	[Mall_OrderComment].[BusinessID],
	[Mall_OrderComment].[ProductID],
	[Mall_OrderComment].[IsZhuiJia]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[UserID],
	INSERTED.[RateStar],
	INSERTED.[RateComment],
	INSERTED.[AddTime],
	INSERTED.[BusinessID],
	INSERTED.[ProductID],
	INSERTED.[IsZhuiJia]
into @table
VALUES ( 
	@OrderID,
	@UserID,
	@RateStar,
	@RateComment,
	@AddTime,
	@BusinessID,
	@ProductID,
	@IsZhuiJia 
); 

SELECT 
	[ID],
	[OrderID],
	[UserID],
	[RateStar],
	[RateComment],
	[AddTime],
	[BusinessID],
	[ProductID],
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
	[OrderID] int,
	[UserID] int,
	[RateStar] decimal(18, 2),
	[RateComment] ntext,
	[AddTime] datetime,
	[BusinessID] int,
	[ProductID] int,
	[IsZhuiJia] bit
);

UPDATE [dbo].[Mall_OrderComment] SET 
	[Mall_OrderComment].[OrderID] = @OrderID,
	[Mall_OrderComment].[UserID] = @UserID,
	[Mall_OrderComment].[RateStar] = @RateStar,
	[Mall_OrderComment].[RateComment] = @RateComment,
	[Mall_OrderComment].[AddTime] = @AddTime,
	[Mall_OrderComment].[BusinessID] = @BusinessID,
	[Mall_OrderComment].[ProductID] = @ProductID,
	[Mall_OrderComment].[IsZhuiJia] = @IsZhuiJia 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[UserID],
	INSERTED.[RateStar],
	INSERTED.[RateComment],
	INSERTED.[AddTime],
	INSERTED.[BusinessID],
	INSERTED.[ProductID],
	INSERTED.[IsZhuiJia]
into @table
WHERE 
	[Mall_OrderComment].[ID] = @ID

SELECT 
	[ID],
	[OrderID],
	[UserID],
	[RateStar],
	[RateComment],
	[AddTime],
	[BusinessID],
	[ProductID],
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
DELETE FROM [dbo].[Mall_OrderComment]
WHERE 
	[Mall_OrderComment].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_OrderComment() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_OrderComment(this.ID));
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
	[Mall_OrderComment].[ID],
	[Mall_OrderComment].[OrderID],
	[Mall_OrderComment].[UserID],
	[Mall_OrderComment].[RateStar],
	[Mall_OrderComment].[RateComment],
	[Mall_OrderComment].[AddTime],
	[Mall_OrderComment].[BusinessID],
	[Mall_OrderComment].[ProductID],
	[Mall_OrderComment].[IsZhuiJia]
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
                return "Mall_OrderComment";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_OrderComment into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderID">orderID</param>
		/// <param name="userID">userID</param>
		/// <param name="rateStar">rateStar</param>
		/// <param name="rateComment">rateComment</param>
		/// <param name="addTime">addTime</param>
		/// <param name="businessID">businessID</param>
		/// <param name="productID">productID</param>
		/// <param name="isZhuiJia">isZhuiJia</param>
		public static void InsertMall_OrderComment(int @orderID, int @userID, decimal @rateStar, string @rateComment, DateTime @addTime, int @businessID, int @productID, bool @isZhuiJia)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_OrderComment(@orderID, @userID, @rateStar, @rateComment, @addTime, @businessID, @productID, @isZhuiJia, helper);
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
		/// Insert a Mall_OrderComment into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderID">orderID</param>
		/// <param name="userID">userID</param>
		/// <param name="rateStar">rateStar</param>
		/// <param name="rateComment">rateComment</param>
		/// <param name="addTime">addTime</param>
		/// <param name="businessID">businessID</param>
		/// <param name="productID">productID</param>
		/// <param name="isZhuiJia">isZhuiJia</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_OrderComment(int @orderID, int @userID, decimal @rateStar, string @rateComment, DateTime @addTime, int @businessID, int @productID, bool @isZhuiJia, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrderID] int,
	[UserID] int,
	[RateStar] decimal(18, 2),
	[RateComment] ntext,
	[AddTime] datetime,
	[BusinessID] int,
	[ProductID] int,
	[IsZhuiJia] bit
);

INSERT INTO [dbo].[Mall_OrderComment] (
	[Mall_OrderComment].[OrderID],
	[Mall_OrderComment].[UserID],
	[Mall_OrderComment].[RateStar],
	[Mall_OrderComment].[RateComment],
	[Mall_OrderComment].[AddTime],
	[Mall_OrderComment].[BusinessID],
	[Mall_OrderComment].[ProductID],
	[Mall_OrderComment].[IsZhuiJia]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[UserID],
	INSERTED.[RateStar],
	INSERTED.[RateComment],
	INSERTED.[AddTime],
	INSERTED.[BusinessID],
	INSERTED.[ProductID],
	INSERTED.[IsZhuiJia]
into @table
VALUES ( 
	@OrderID,
	@UserID,
	@RateStar,
	@RateComment,
	@AddTime,
	@BusinessID,
	@ProductID,
	@IsZhuiJia 
); 

SELECT 
	[ID],
	[OrderID],
	[UserID],
	[RateStar],
	[RateComment],
	[AddTime],
	[BusinessID],
	[ProductID],
	[IsZhuiJia] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OrderID", EntityBase.GetDatabaseValue(@orderID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@RateStar", EntityBase.GetDatabaseValue(@rateStar)));
			parameters.Add(new SqlParameter("@RateComment", EntityBase.GetDatabaseValue(@rateComment)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@IsZhuiJia", @isZhuiJia));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_OrderComment into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orderID">orderID</param>
		/// <param name="userID">userID</param>
		/// <param name="rateStar">rateStar</param>
		/// <param name="rateComment">rateComment</param>
		/// <param name="addTime">addTime</param>
		/// <param name="businessID">businessID</param>
		/// <param name="productID">productID</param>
		/// <param name="isZhuiJia">isZhuiJia</param>
		public static void UpdateMall_OrderComment(int @iD, int @orderID, int @userID, decimal @rateStar, string @rateComment, DateTime @addTime, int @businessID, int @productID, bool @isZhuiJia)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_OrderComment(@iD, @orderID, @userID, @rateStar, @rateComment, @addTime, @businessID, @productID, @isZhuiJia, helper);
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
		/// Updates a Mall_OrderComment into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orderID">orderID</param>
		/// <param name="userID">userID</param>
		/// <param name="rateStar">rateStar</param>
		/// <param name="rateComment">rateComment</param>
		/// <param name="addTime">addTime</param>
		/// <param name="businessID">businessID</param>
		/// <param name="productID">productID</param>
		/// <param name="isZhuiJia">isZhuiJia</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_OrderComment(int @iD, int @orderID, int @userID, decimal @rateStar, string @rateComment, DateTime @addTime, int @businessID, int @productID, bool @isZhuiJia, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrderID] int,
	[UserID] int,
	[RateStar] decimal(18, 2),
	[RateComment] ntext,
	[AddTime] datetime,
	[BusinessID] int,
	[ProductID] int,
	[IsZhuiJia] bit
);

UPDATE [dbo].[Mall_OrderComment] SET 
	[Mall_OrderComment].[OrderID] = @OrderID,
	[Mall_OrderComment].[UserID] = @UserID,
	[Mall_OrderComment].[RateStar] = @RateStar,
	[Mall_OrderComment].[RateComment] = @RateComment,
	[Mall_OrderComment].[AddTime] = @AddTime,
	[Mall_OrderComment].[BusinessID] = @BusinessID,
	[Mall_OrderComment].[ProductID] = @ProductID,
	[Mall_OrderComment].[IsZhuiJia] = @IsZhuiJia 
output 
	INSERTED.[ID],
	INSERTED.[OrderID],
	INSERTED.[UserID],
	INSERTED.[RateStar],
	INSERTED.[RateComment],
	INSERTED.[AddTime],
	INSERTED.[BusinessID],
	INSERTED.[ProductID],
	INSERTED.[IsZhuiJia]
into @table
WHERE 
	[Mall_OrderComment].[ID] = @ID

SELECT 
	[ID],
	[OrderID],
	[UserID],
	[RateStar],
	[RateComment],
	[AddTime],
	[BusinessID],
	[ProductID],
	[IsZhuiJia] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OrderID", EntityBase.GetDatabaseValue(@orderID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@RateStar", EntityBase.GetDatabaseValue(@rateStar)));
			parameters.Add(new SqlParameter("@RateComment", EntityBase.GetDatabaseValue(@rateComment)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@BusinessID", EntityBase.GetDatabaseValue(@businessID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@IsZhuiJia", @isZhuiJia));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_OrderComment from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_OrderComment(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_OrderComment(@iD, helper);
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
		/// Deletes a Mall_OrderComment from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_OrderComment(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_OrderComment]
WHERE 
	[Mall_OrderComment].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_OrderComment object.
		/// </summary>
		/// <returns>The newly created Mall_OrderComment object.</returns>
		public static Mall_OrderComment CreateMall_OrderComment()
		{
			return InitializeNew<Mall_OrderComment>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_OrderComment by a Mall_OrderComment's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_OrderComment</returns>
		public static Mall_OrderComment GetMall_OrderComment(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_OrderComment.SelectFieldList + @"
FROM [dbo].[Mall_OrderComment] 
WHERE 
	[Mall_OrderComment].[ID] = @ID " + Mall_OrderComment.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_OrderComment>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_OrderComment by a Mall_OrderComment's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_OrderComment</returns>
		public static Mall_OrderComment GetMall_OrderComment(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_OrderComment.SelectFieldList + @"
FROM [dbo].[Mall_OrderComment] 
WHERE 
	[Mall_OrderComment].[ID] = @ID " + Mall_OrderComment.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_OrderComment>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderComment objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_OrderComment objects.</returns>
		public static EntityList<Mall_OrderComment> GetMall_OrderComments()
		{
			string commandText = @"
SELECT " + Mall_OrderComment.SelectFieldList + "FROM [dbo].[Mall_OrderComment] " + Mall_OrderComment.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_OrderComment>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_OrderComment objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_OrderComment objects.</returns>
        public static EntityList<Mall_OrderComment> GetMall_OrderComments(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_OrderComment>(SelectFieldList, "FROM [dbo].[Mall_OrderComment]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_OrderComment objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_OrderComment objects.</returns>
        public static EntityList<Mall_OrderComment> GetMall_OrderComments(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_OrderComment>(SelectFieldList, "FROM [dbo].[Mall_OrderComment]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_OrderComment objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_OrderComment objects.</returns>
		protected static EntityList<Mall_OrderComment> GetMall_OrderComments(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_OrderComments(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderComment objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderComment objects.</returns>
		protected static EntityList<Mall_OrderComment> GetMall_OrderComments(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_OrderComments(string.Empty, where, parameters, Mall_OrderComment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderComment objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderComment objects.</returns>
		protected static EntityList<Mall_OrderComment> GetMall_OrderComments(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_OrderComments(prefix, where, parameters, Mall_OrderComment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderComment objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderComment objects.</returns>
		protected static EntityList<Mall_OrderComment> GetMall_OrderComments(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_OrderComments(string.Empty, where, parameters, Mall_OrderComment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderComment objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_OrderComment objects.</returns>
		protected static EntityList<Mall_OrderComment> GetMall_OrderComments(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_OrderComments(prefix, where, parameters, Mall_OrderComment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_OrderComment objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_OrderComment objects.</returns>
		protected static EntityList<Mall_OrderComment> GetMall_OrderComments(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_OrderComment.SelectFieldList + "FROM [dbo].[Mall_OrderComment] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_OrderComment>(reader);
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
        protected static EntityList<Mall_OrderComment> GetMall_OrderComments(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_OrderComment>(SelectFieldList, "FROM [dbo].[Mall_OrderComment] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_OrderComment objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_OrderCommentCount()
        {
            return GetMall_OrderCommentCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_OrderComment objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_OrderCommentCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_OrderComment] " + where;

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
		public static partial class Mall_OrderComment_Properties
		{
			public const string ID = "ID";
			public const string OrderID = "OrderID";
			public const string UserID = "UserID";
			public const string RateStar = "RateStar";
			public const string RateComment = "RateComment";
			public const string AddTime = "AddTime";
			public const string BusinessID = "BusinessID";
			public const string ProductID = "ProductID";
			public const string IsZhuiJia = "IsZhuiJia";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OrderID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"RateStar" , "decimal:"},
    			 {"RateComment" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"BusinessID" , "int:"},
    			 {"ProductID" , "int:"},
    			 {"IsZhuiJia" , "bool:"},
            };
		}
		#endregion
	}
}
