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
	/// This object represents the properties and methods of a Mall_ProductPinOrganiser.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_ProductPinOrganiser 
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
		private int _productID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private int _variantID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int VariantID
		{
			[DebuggerStepThrough()]
			get { return this._variantID; }
			set 
			{
				if (this._variantID != value) 
				{
					this._variantID = value;
					this.IsDirty = true;	
					OnPropertyChanged("VariantID");
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
		private int _status = int.MinValue;
		/// <summary>
		/// 1-进行中 2-待付款 3-已付款 4-已关闭
		/// </summary>
        [Description("1-进行中 2-待付款 3-已付款 4-已关闭")]
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _updateTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime UpdateTime
		{
			[DebuggerStepThrough()]
			get { return this._updateTime; }
			set 
			{
				if (this._updateTime != value) 
				{
					this._updateTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("UpdateTime");
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
	[ProductID] int,
	[VariantID] int,
	[AddTime] datetime,
	[Status] int,
	[UpdateTime] datetime
);

INSERT INTO [dbo].[Mall_ProductPinOrganiser] (
	[Mall_ProductPinOrganiser].[UserID],
	[Mall_ProductPinOrganiser].[ProductID],
	[Mall_ProductPinOrganiser].[VariantID],
	[Mall_ProductPinOrganiser].[AddTime],
	[Mall_ProductPinOrganiser].[Status],
	[Mall_ProductPinOrganiser].[UpdateTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[ProductID],
	INSERTED.[VariantID],
	INSERTED.[AddTime],
	INSERTED.[Status],
	INSERTED.[UpdateTime]
into @table
VALUES ( 
	@UserID,
	@ProductID,
	@VariantID,
	@AddTime,
	@Status,
	@UpdateTime 
); 

SELECT 
	[ID],
	[UserID],
	[ProductID],
	[VariantID],
	[AddTime],
	[Status],
	[UpdateTime] 
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
	[ProductID] int,
	[VariantID] int,
	[AddTime] datetime,
	[Status] int,
	[UpdateTime] datetime
);

UPDATE [dbo].[Mall_ProductPinOrganiser] SET 
	[Mall_ProductPinOrganiser].[UserID] = @UserID,
	[Mall_ProductPinOrganiser].[ProductID] = @ProductID,
	[Mall_ProductPinOrganiser].[VariantID] = @VariantID,
	[Mall_ProductPinOrganiser].[AddTime] = @AddTime,
	[Mall_ProductPinOrganiser].[Status] = @Status,
	[Mall_ProductPinOrganiser].[UpdateTime] = @UpdateTime 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[ProductID],
	INSERTED.[VariantID],
	INSERTED.[AddTime],
	INSERTED.[Status],
	INSERTED.[UpdateTime]
into @table
WHERE 
	[Mall_ProductPinOrganiser].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[ProductID],
	[VariantID],
	[AddTime],
	[Status],
	[UpdateTime] 
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
DELETE FROM [dbo].[Mall_ProductPinOrganiser]
WHERE 
	[Mall_ProductPinOrganiser].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_ProductPinOrganiser() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_ProductPinOrganiser(this.ID));
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
	[Mall_ProductPinOrganiser].[ID],
	[Mall_ProductPinOrganiser].[UserID],
	[Mall_ProductPinOrganiser].[ProductID],
	[Mall_ProductPinOrganiser].[VariantID],
	[Mall_ProductPinOrganiser].[AddTime],
	[Mall_ProductPinOrganiser].[Status],
	[Mall_ProductPinOrganiser].[UpdateTime]
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
                return "Mall_ProductPinOrganiser";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_ProductPinOrganiser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="productID">productID</param>
		/// <param name="variantID">variantID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="status">status</param>
		/// <param name="updateTime">updateTime</param>
		public static void InsertMall_ProductPinOrganiser(int @userID, int @productID, int @variantID, DateTime @addTime, int @status, DateTime @updateTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_ProductPinOrganiser(@userID, @productID, @variantID, @addTime, @status, @updateTime, helper);
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
		/// Insert a Mall_ProductPinOrganiser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="productID">productID</param>
		/// <param name="variantID">variantID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="status">status</param>
		/// <param name="updateTime">updateTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_ProductPinOrganiser(int @userID, int @productID, int @variantID, DateTime @addTime, int @status, DateTime @updateTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[ProductID] int,
	[VariantID] int,
	[AddTime] datetime,
	[Status] int,
	[UpdateTime] datetime
);

INSERT INTO [dbo].[Mall_ProductPinOrganiser] (
	[Mall_ProductPinOrganiser].[UserID],
	[Mall_ProductPinOrganiser].[ProductID],
	[Mall_ProductPinOrganiser].[VariantID],
	[Mall_ProductPinOrganiser].[AddTime],
	[Mall_ProductPinOrganiser].[Status],
	[Mall_ProductPinOrganiser].[UpdateTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[ProductID],
	INSERTED.[VariantID],
	INSERTED.[AddTime],
	INSERTED.[Status],
	INSERTED.[UpdateTime]
into @table
VALUES ( 
	@UserID,
	@ProductID,
	@VariantID,
	@AddTime,
	@Status,
	@UpdateTime 
); 

SELECT 
	[ID],
	[UserID],
	[ProductID],
	[VariantID],
	[AddTime],
	[Status],
	[UpdateTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@VariantID", EntityBase.GetDatabaseValue(@variantID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@UpdateTime", EntityBase.GetDatabaseValue(@updateTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_ProductPinOrganiser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="productID">productID</param>
		/// <param name="variantID">variantID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="status">status</param>
		/// <param name="updateTime">updateTime</param>
		public static void UpdateMall_ProductPinOrganiser(int @iD, int @userID, int @productID, int @variantID, DateTime @addTime, int @status, DateTime @updateTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_ProductPinOrganiser(@iD, @userID, @productID, @variantID, @addTime, @status, @updateTime, helper);
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
		/// Updates a Mall_ProductPinOrganiser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="productID">productID</param>
		/// <param name="variantID">variantID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="status">status</param>
		/// <param name="updateTime">updateTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_ProductPinOrganiser(int @iD, int @userID, int @productID, int @variantID, DateTime @addTime, int @status, DateTime @updateTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[ProductID] int,
	[VariantID] int,
	[AddTime] datetime,
	[Status] int,
	[UpdateTime] datetime
);

UPDATE [dbo].[Mall_ProductPinOrganiser] SET 
	[Mall_ProductPinOrganiser].[UserID] = @UserID,
	[Mall_ProductPinOrganiser].[ProductID] = @ProductID,
	[Mall_ProductPinOrganiser].[VariantID] = @VariantID,
	[Mall_ProductPinOrganiser].[AddTime] = @AddTime,
	[Mall_ProductPinOrganiser].[Status] = @Status,
	[Mall_ProductPinOrganiser].[UpdateTime] = @UpdateTime 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[ProductID],
	INSERTED.[VariantID],
	INSERTED.[AddTime],
	INSERTED.[Status],
	INSERTED.[UpdateTime]
into @table
WHERE 
	[Mall_ProductPinOrganiser].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[ProductID],
	[VariantID],
	[AddTime],
	[Status],
	[UpdateTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@VariantID", EntityBase.GetDatabaseValue(@variantID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Status", EntityBase.GetDatabaseValue(@status)));
			parameters.Add(new SqlParameter("@UpdateTime", EntityBase.GetDatabaseValue(@updateTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_ProductPinOrganiser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_ProductPinOrganiser(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_ProductPinOrganiser(@iD, helper);
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
		/// Deletes a Mall_ProductPinOrganiser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_ProductPinOrganiser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_ProductPinOrganiser]
WHERE 
	[Mall_ProductPinOrganiser].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_ProductPinOrganiser object.
		/// </summary>
		/// <returns>The newly created Mall_ProductPinOrganiser object.</returns>
		public static Mall_ProductPinOrganiser CreateMall_ProductPinOrganiser()
		{
			return InitializeNew<Mall_ProductPinOrganiser>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_ProductPinOrganiser by a Mall_ProductPinOrganiser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_ProductPinOrganiser</returns>
		public static Mall_ProductPinOrganiser GetMall_ProductPinOrganiser(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_ProductPinOrganiser.SelectFieldList + @"
FROM [dbo].[Mall_ProductPinOrganiser] 
WHERE 
	[Mall_ProductPinOrganiser].[ID] = @ID " + Mall_ProductPinOrganiser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ProductPinOrganiser>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_ProductPinOrganiser by a Mall_ProductPinOrganiser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_ProductPinOrganiser</returns>
		public static Mall_ProductPinOrganiser GetMall_ProductPinOrganiser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_ProductPinOrganiser.SelectFieldList + @"
FROM [dbo].[Mall_ProductPinOrganiser] 
WHERE 
	[Mall_ProductPinOrganiser].[ID] = @ID " + Mall_ProductPinOrganiser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ProductPinOrganiser>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductPinOrganiser objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_ProductPinOrganiser objects.</returns>
		public static EntityList<Mall_ProductPinOrganiser> GetMall_ProductPinOrganisers()
		{
			string commandText = @"
SELECT " + Mall_ProductPinOrganiser.SelectFieldList + "FROM [dbo].[Mall_ProductPinOrganiser] " + Mall_ProductPinOrganiser.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_ProductPinOrganiser>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_ProductPinOrganiser objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ProductPinOrganiser objects.</returns>
        public static EntityList<Mall_ProductPinOrganiser> GetMall_ProductPinOrganisers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ProductPinOrganiser>(SelectFieldList, "FROM [dbo].[Mall_ProductPinOrganiser]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_ProductPinOrganiser objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ProductPinOrganiser objects.</returns>
        public static EntityList<Mall_ProductPinOrganiser> GetMall_ProductPinOrganisers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ProductPinOrganiser>(SelectFieldList, "FROM [dbo].[Mall_ProductPinOrganiser]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_ProductPinOrganiser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ProductPinOrganiser objects.</returns>
		protected static EntityList<Mall_ProductPinOrganiser> GetMall_ProductPinOrganisers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ProductPinOrganisers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductPinOrganiser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ProductPinOrganiser objects.</returns>
		protected static EntityList<Mall_ProductPinOrganiser> GetMall_ProductPinOrganisers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ProductPinOrganisers(string.Empty, where, parameters, Mall_ProductPinOrganiser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductPinOrganiser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ProductPinOrganiser objects.</returns>
		protected static EntityList<Mall_ProductPinOrganiser> GetMall_ProductPinOrganisers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ProductPinOrganisers(prefix, where, parameters, Mall_ProductPinOrganiser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductPinOrganiser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ProductPinOrganiser objects.</returns>
		protected static EntityList<Mall_ProductPinOrganiser> GetMall_ProductPinOrganisers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ProductPinOrganisers(string.Empty, where, parameters, Mall_ProductPinOrganiser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductPinOrganiser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ProductPinOrganiser objects.</returns>
		protected static EntityList<Mall_ProductPinOrganiser> GetMall_ProductPinOrganisers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ProductPinOrganisers(prefix, where, parameters, Mall_ProductPinOrganiser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ProductPinOrganiser objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ProductPinOrganiser objects.</returns>
		protected static EntityList<Mall_ProductPinOrganiser> GetMall_ProductPinOrganisers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_ProductPinOrganiser.SelectFieldList + "FROM [dbo].[Mall_ProductPinOrganiser] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_ProductPinOrganiser>(reader);
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
        protected static EntityList<Mall_ProductPinOrganiser> GetMall_ProductPinOrganisers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ProductPinOrganiser>(SelectFieldList, "FROM [dbo].[Mall_ProductPinOrganiser] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_ProductPinOrganiser objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ProductPinOrganiserCount()
        {
            return GetMall_ProductPinOrganiserCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_ProductPinOrganiser objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ProductPinOrganiserCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_ProductPinOrganiser] " + where;

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
		public static partial class Mall_ProductPinOrganiser_Properties
		{
			public const string ID = "ID";
			public const string UserID = "UserID";
			public const string ProductID = "ProductID";
			public const string VariantID = "VariantID";
			public const string AddTime = "AddTime";
			public const string Status = "Status";
			public const string UpdateTime = "UpdateTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"ProductID" , "int:"},
    			 {"VariantID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"Status" , "int:1-进行中 2-待付款 3-已付款 4-已关闭"},
    			 {"UpdateTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
