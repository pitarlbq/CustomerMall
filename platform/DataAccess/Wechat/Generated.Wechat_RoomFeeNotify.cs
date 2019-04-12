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
	/// This object represents the properties and methods of a Wechat_RoomFeeNotify.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_RoomFeeNotify 
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
		private string _sendDate = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SendDate
		{
			[DebuggerStepThrough()]
			get { return this._sendDate; }
			set 
			{
				if (this._sendDate != value) 
				{
					this._sendDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("SendDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalCost
		{
			[DebuggerStepThrough()]
			get { return this._totalCost; }
			set 
			{
				if (this._totalCost != value) 
				{
					this._totalCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalCost");
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
		private string _notifyRoomIDs = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string NotifyRoomIDs
		{
			[DebuggerStepThrough()]
			get { return this._notifyRoomIDs; }
			set 
			{
				if (this._notifyRoomIDs != value) 
				{
					this._notifyRoomIDs = value;
					this.IsDirty = true;	
					OnPropertyChanged("NotifyRoomIDs");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _feeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int FeeID
		{
			[DebuggerStepThrough()]
			get { return this._feeID; }
			set 
			{
				if (this._feeID != value) 
				{
					this._feeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("FeeID");
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
	[SendDate] nvarchar(50),
	[TotalCost] decimal(18, 4),
	[AddTime] datetime,
	[NotifyRoomIDs] ntext,
	[FeeID] int
);

INSERT INTO [dbo].[Wechat_RoomFeeNotify] (
	[Wechat_RoomFeeNotify].[SendDate],
	[Wechat_RoomFeeNotify].[TotalCost],
	[Wechat_RoomFeeNotify].[AddTime],
	[Wechat_RoomFeeNotify].[NotifyRoomIDs],
	[Wechat_RoomFeeNotify].[FeeID]
) 
output 
	INSERTED.[ID],
	INSERTED.[SendDate],
	INSERTED.[TotalCost],
	INSERTED.[AddTime],
	INSERTED.[NotifyRoomIDs],
	INSERTED.[FeeID]
into @table
VALUES ( 
	@SendDate,
	@TotalCost,
	@AddTime,
	@NotifyRoomIDs,
	@FeeID 
); 

SELECT 
	[ID],
	[SendDate],
	[TotalCost],
	[AddTime],
	[NotifyRoomIDs],
	[FeeID] 
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
	[SendDate] nvarchar(50),
	[TotalCost] decimal(18, 4),
	[AddTime] datetime,
	[NotifyRoomIDs] ntext,
	[FeeID] int
);

UPDATE [dbo].[Wechat_RoomFeeNotify] SET 
	[Wechat_RoomFeeNotify].[SendDate] = @SendDate,
	[Wechat_RoomFeeNotify].[TotalCost] = @TotalCost,
	[Wechat_RoomFeeNotify].[AddTime] = @AddTime,
	[Wechat_RoomFeeNotify].[NotifyRoomIDs] = @NotifyRoomIDs,
	[Wechat_RoomFeeNotify].[FeeID] = @FeeID 
output 
	INSERTED.[ID],
	INSERTED.[SendDate],
	INSERTED.[TotalCost],
	INSERTED.[AddTime],
	INSERTED.[NotifyRoomIDs],
	INSERTED.[FeeID]
into @table
WHERE 
	[Wechat_RoomFeeNotify].[ID] = @ID

SELECT 
	[ID],
	[SendDate],
	[TotalCost],
	[AddTime],
	[NotifyRoomIDs],
	[FeeID] 
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
DELETE FROM [dbo].[Wechat_RoomFeeNotify]
WHERE 
	[Wechat_RoomFeeNotify].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_RoomFeeNotify() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_RoomFeeNotify(this.ID));
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
	[Wechat_RoomFeeNotify].[ID],
	[Wechat_RoomFeeNotify].[SendDate],
	[Wechat_RoomFeeNotify].[TotalCost],
	[Wechat_RoomFeeNotify].[AddTime],
	[Wechat_RoomFeeNotify].[NotifyRoomIDs],
	[Wechat_RoomFeeNotify].[FeeID]
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
                return "Wechat_RoomFeeNotify";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_RoomFeeNotify into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="sendDate">sendDate</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="notifyRoomIDs">notifyRoomIDs</param>
		/// <param name="feeID">feeID</param>
		public static void InsertWechat_RoomFeeNotify(string @sendDate, decimal @totalCost, DateTime @addTime, string @notifyRoomIDs, int @feeID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_RoomFeeNotify(@sendDate, @totalCost, @addTime, @notifyRoomIDs, @feeID, helper);
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
		/// Insert a Wechat_RoomFeeNotify into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="sendDate">sendDate</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="notifyRoomIDs">notifyRoomIDs</param>
		/// <param name="feeID">feeID</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_RoomFeeNotify(string @sendDate, decimal @totalCost, DateTime @addTime, string @notifyRoomIDs, int @feeID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SendDate] nvarchar(50),
	[TotalCost] decimal(18, 4),
	[AddTime] datetime,
	[NotifyRoomIDs] ntext,
	[FeeID] int
);

INSERT INTO [dbo].[Wechat_RoomFeeNotify] (
	[Wechat_RoomFeeNotify].[SendDate],
	[Wechat_RoomFeeNotify].[TotalCost],
	[Wechat_RoomFeeNotify].[AddTime],
	[Wechat_RoomFeeNotify].[NotifyRoomIDs],
	[Wechat_RoomFeeNotify].[FeeID]
) 
output 
	INSERTED.[ID],
	INSERTED.[SendDate],
	INSERTED.[TotalCost],
	INSERTED.[AddTime],
	INSERTED.[NotifyRoomIDs],
	INSERTED.[FeeID]
into @table
VALUES ( 
	@SendDate,
	@TotalCost,
	@AddTime,
	@NotifyRoomIDs,
	@FeeID 
); 

SELECT 
	[ID],
	[SendDate],
	[TotalCost],
	[AddTime],
	[NotifyRoomIDs],
	[FeeID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@SendDate", EntityBase.GetDatabaseValue(@sendDate)));
			parameters.Add(new SqlParameter("@TotalCost", EntityBase.GetDatabaseValue(@totalCost)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@NotifyRoomIDs", EntityBase.GetDatabaseValue(@notifyRoomIDs)));
			parameters.Add(new SqlParameter("@FeeID", EntityBase.GetDatabaseValue(@feeID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_RoomFeeNotify into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="sendDate">sendDate</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="notifyRoomIDs">notifyRoomIDs</param>
		/// <param name="feeID">feeID</param>
		public static void UpdateWechat_RoomFeeNotify(int @iD, string @sendDate, decimal @totalCost, DateTime @addTime, string @notifyRoomIDs, int @feeID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_RoomFeeNotify(@iD, @sendDate, @totalCost, @addTime, @notifyRoomIDs, @feeID, helper);
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
		/// Updates a Wechat_RoomFeeNotify into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="sendDate">sendDate</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="addTime">addTime</param>
		/// <param name="notifyRoomIDs">notifyRoomIDs</param>
		/// <param name="feeID">feeID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_RoomFeeNotify(int @iD, string @sendDate, decimal @totalCost, DateTime @addTime, string @notifyRoomIDs, int @feeID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SendDate] nvarchar(50),
	[TotalCost] decimal(18, 4),
	[AddTime] datetime,
	[NotifyRoomIDs] ntext,
	[FeeID] int
);

UPDATE [dbo].[Wechat_RoomFeeNotify] SET 
	[Wechat_RoomFeeNotify].[SendDate] = @SendDate,
	[Wechat_RoomFeeNotify].[TotalCost] = @TotalCost,
	[Wechat_RoomFeeNotify].[AddTime] = @AddTime,
	[Wechat_RoomFeeNotify].[NotifyRoomIDs] = @NotifyRoomIDs,
	[Wechat_RoomFeeNotify].[FeeID] = @FeeID 
output 
	INSERTED.[ID],
	INSERTED.[SendDate],
	INSERTED.[TotalCost],
	INSERTED.[AddTime],
	INSERTED.[NotifyRoomIDs],
	INSERTED.[FeeID]
into @table
WHERE 
	[Wechat_RoomFeeNotify].[ID] = @ID

SELECT 
	[ID],
	[SendDate],
	[TotalCost],
	[AddTime],
	[NotifyRoomIDs],
	[FeeID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@SendDate", EntityBase.GetDatabaseValue(@sendDate)));
			parameters.Add(new SqlParameter("@TotalCost", EntityBase.GetDatabaseValue(@totalCost)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@NotifyRoomIDs", EntityBase.GetDatabaseValue(@notifyRoomIDs)));
			parameters.Add(new SqlParameter("@FeeID", EntityBase.GetDatabaseValue(@feeID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_RoomFeeNotify from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_RoomFeeNotify(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_RoomFeeNotify(@iD, helper);
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
		/// Deletes a Wechat_RoomFeeNotify from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_RoomFeeNotify(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_RoomFeeNotify]
WHERE 
	[Wechat_RoomFeeNotify].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_RoomFeeNotify object.
		/// </summary>
		/// <returns>The newly created Wechat_RoomFeeNotify object.</returns>
		public static Wechat_RoomFeeNotify CreateWechat_RoomFeeNotify()
		{
			return InitializeNew<Wechat_RoomFeeNotify>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_RoomFeeNotify by a Wechat_RoomFeeNotify's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_RoomFeeNotify</returns>
		public static Wechat_RoomFeeNotify GetWechat_RoomFeeNotify(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_RoomFeeNotify.SelectFieldList + @"
FROM [dbo].[Wechat_RoomFeeNotify] 
WHERE 
	[Wechat_RoomFeeNotify].[ID] = @ID " + Wechat_RoomFeeNotify.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_RoomFeeNotify>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_RoomFeeNotify by a Wechat_RoomFeeNotify's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_RoomFeeNotify</returns>
		public static Wechat_RoomFeeNotify GetWechat_RoomFeeNotify(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_RoomFeeNotify.SelectFieldList + @"
FROM [dbo].[Wechat_RoomFeeNotify] 
WHERE 
	[Wechat_RoomFeeNotify].[ID] = @ID " + Wechat_RoomFeeNotify.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_RoomFeeNotify>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RoomFeeNotify objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_RoomFeeNotify objects.</returns>
		public static EntityList<Wechat_RoomFeeNotify> GetWechat_RoomFeeNotifies()
		{
			string commandText = @"
SELECT " + Wechat_RoomFeeNotify.SelectFieldList + "FROM [dbo].[Wechat_RoomFeeNotify] " + Wechat_RoomFeeNotify.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_RoomFeeNotify>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_RoomFeeNotify objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_RoomFeeNotify objects.</returns>
        public static EntityList<Wechat_RoomFeeNotify> GetWechat_RoomFeeNotifies(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_RoomFeeNotify>(SelectFieldList, "FROM [dbo].[Wechat_RoomFeeNotify]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_RoomFeeNotify objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_RoomFeeNotify objects.</returns>
        public static EntityList<Wechat_RoomFeeNotify> GetWechat_RoomFeeNotifies(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_RoomFeeNotify>(SelectFieldList, "FROM [dbo].[Wechat_RoomFeeNotify]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_RoomFeeNotify objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_RoomFeeNotify objects.</returns>
		protected static EntityList<Wechat_RoomFeeNotify> GetWechat_RoomFeeNotifies(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_RoomFeeNotifies(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RoomFeeNotify objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RoomFeeNotify objects.</returns>
		protected static EntityList<Wechat_RoomFeeNotify> GetWechat_RoomFeeNotifies(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_RoomFeeNotifies(string.Empty, where, parameters, Wechat_RoomFeeNotify.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RoomFeeNotify objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RoomFeeNotify objects.</returns>
		protected static EntityList<Wechat_RoomFeeNotify> GetWechat_RoomFeeNotifies(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_RoomFeeNotifies(prefix, where, parameters, Wechat_RoomFeeNotify.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RoomFeeNotify objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RoomFeeNotify objects.</returns>
		protected static EntityList<Wechat_RoomFeeNotify> GetWechat_RoomFeeNotifies(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_RoomFeeNotifies(string.Empty, where, parameters, Wechat_RoomFeeNotify.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RoomFeeNotify objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RoomFeeNotify objects.</returns>
		protected static EntityList<Wechat_RoomFeeNotify> GetWechat_RoomFeeNotifies(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_RoomFeeNotifies(prefix, where, parameters, Wechat_RoomFeeNotify.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RoomFeeNotify objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_RoomFeeNotify objects.</returns>
		protected static EntityList<Wechat_RoomFeeNotify> GetWechat_RoomFeeNotifies(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_RoomFeeNotify.SelectFieldList + "FROM [dbo].[Wechat_RoomFeeNotify] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_RoomFeeNotify>(reader);
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
        protected static EntityList<Wechat_RoomFeeNotify> GetWechat_RoomFeeNotifies(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_RoomFeeNotify>(SelectFieldList, "FROM [dbo].[Wechat_RoomFeeNotify] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_RoomFeeNotify objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_RoomFeeNotifyCount()
        {
            return GetWechat_RoomFeeNotifyCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_RoomFeeNotify objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_RoomFeeNotifyCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_RoomFeeNotify] " + where;

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
		public static partial class Wechat_RoomFeeNotify_Properties
		{
			public const string ID = "ID";
			public const string SendDate = "SendDate";
			public const string TotalCost = "TotalCost";
			public const string AddTime = "AddTime";
			public const string NotifyRoomIDs = "NotifyRoomIDs";
			public const string FeeID = "FeeID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"SendDate" , "string:"},
    			 {"TotalCost" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"NotifyRoomIDs" , "string:"},
    			 {"FeeID" , "int:"},
            };
		}
		#endregion
	}
}
