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
	/// This object represents the properties and methods of a Contract_ZuKong.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Contract_ZuKong 
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
		private int _roomID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private string _roomName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomName
		{
			[DebuggerStepThrough()]
			get { return this._roomName; }
			set 
			{
				if (this._roomName != value) 
				{
					this._roomName = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomState = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomState
		{
			[DebuggerStepThrough()]
			get { return this._roomState; }
			set 
			{
				if (this._roomState != value) 
				{
					this._roomState = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomState");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomOwner = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomOwner
		{
			[DebuggerStepThrough()]
			get { return this._roomOwner; }
			set 
			{
				if (this._roomOwner != value) 
				{
					this._roomOwner = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomOwner");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _roomFee = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RoomFee
		{
			[DebuggerStepThrough()]
			get { return this._roomFee; }
			set 
			{
				if (this._roomFee != value) 
				{
					this._roomFee = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomFee");
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
		private int _roomStateID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RoomStateID
		{
			[DebuggerStepThrough()]
			get { return this._roomStateID; }
			set 
			{
				if (this._roomStateID != value) 
				{
					this._roomStateID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomStateID");
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
	[RoomID] int,
	[RoomName] nvarchar(200),
	[RoomState] nvarchar(100),
	[RoomOwner] nvarchar(100),
	[RoomFee] decimal(18, 2),
	[AddTime] datetime,
	[RoomStateID] int
);

INSERT INTO [dbo].[Contract_ZuKong] (
	[Contract_ZuKong].[RoomID],
	[Contract_ZuKong].[RoomName],
	[Contract_ZuKong].[RoomState],
	[Contract_ZuKong].[RoomOwner],
	[Contract_ZuKong].[RoomFee],
	[Contract_ZuKong].[AddTime],
	[Contract_ZuKong].[RoomStateID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[RoomName],
	INSERTED.[RoomState],
	INSERTED.[RoomOwner],
	INSERTED.[RoomFee],
	INSERTED.[AddTime],
	INSERTED.[RoomStateID]
into @table
VALUES ( 
	@RoomID,
	@RoomName,
	@RoomState,
	@RoomOwner,
	@RoomFee,
	@AddTime,
	@RoomStateID 
); 

SELECT 
	[ID],
	[RoomID],
	[RoomName],
	[RoomState],
	[RoomOwner],
	[RoomFee],
	[AddTime],
	[RoomStateID] 
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
	[RoomID] int,
	[RoomName] nvarchar(200),
	[RoomState] nvarchar(100),
	[RoomOwner] nvarchar(100),
	[RoomFee] decimal(18, 2),
	[AddTime] datetime,
	[RoomStateID] int
);

UPDATE [dbo].[Contract_ZuKong] SET 
	[Contract_ZuKong].[RoomID] = @RoomID,
	[Contract_ZuKong].[RoomName] = @RoomName,
	[Contract_ZuKong].[RoomState] = @RoomState,
	[Contract_ZuKong].[RoomOwner] = @RoomOwner,
	[Contract_ZuKong].[RoomFee] = @RoomFee,
	[Contract_ZuKong].[AddTime] = @AddTime,
	[Contract_ZuKong].[RoomStateID] = @RoomStateID 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[RoomName],
	INSERTED.[RoomState],
	INSERTED.[RoomOwner],
	INSERTED.[RoomFee],
	INSERTED.[AddTime],
	INSERTED.[RoomStateID]
into @table
WHERE 
	[Contract_ZuKong].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[RoomName],
	[RoomState],
	[RoomOwner],
	[RoomFee],
	[AddTime],
	[RoomStateID] 
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
DELETE FROM [dbo].[Contract_ZuKong]
WHERE 
	[Contract_ZuKong].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Contract_ZuKong() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetContract_ZuKong(this.ID));
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
	[Contract_ZuKong].[ID],
	[Contract_ZuKong].[RoomID],
	[Contract_ZuKong].[RoomName],
	[Contract_ZuKong].[RoomState],
	[Contract_ZuKong].[RoomOwner],
	[Contract_ZuKong].[RoomFee],
	[Contract_ZuKong].[AddTime],
	[Contract_ZuKong].[RoomStateID]
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
                return "Contract_ZuKong";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Contract_ZuKong into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="roomName">roomName</param>
		/// <param name="roomState">roomState</param>
		/// <param name="roomOwner">roomOwner</param>
		/// <param name="roomFee">roomFee</param>
		/// <param name="addTime">addTime</param>
		/// <param name="roomStateID">roomStateID</param>
		public static void InsertContract_ZuKong(int @roomID, string @roomName, string @roomState, string @roomOwner, decimal @roomFee, DateTime @addTime, int @roomStateID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertContract_ZuKong(@roomID, @roomName, @roomState, @roomOwner, @roomFee, @addTime, @roomStateID, helper);
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
		/// Insert a Contract_ZuKong into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="roomName">roomName</param>
		/// <param name="roomState">roomState</param>
		/// <param name="roomOwner">roomOwner</param>
		/// <param name="roomFee">roomFee</param>
		/// <param name="addTime">addTime</param>
		/// <param name="roomStateID">roomStateID</param>
		/// <param name="helper">helper</param>
		internal static void InsertContract_ZuKong(int @roomID, string @roomName, string @roomState, string @roomOwner, decimal @roomFee, DateTime @addTime, int @roomStateID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[RoomName] nvarchar(200),
	[RoomState] nvarchar(100),
	[RoomOwner] nvarchar(100),
	[RoomFee] decimal(18, 2),
	[AddTime] datetime,
	[RoomStateID] int
);

INSERT INTO [dbo].[Contract_ZuKong] (
	[Contract_ZuKong].[RoomID],
	[Contract_ZuKong].[RoomName],
	[Contract_ZuKong].[RoomState],
	[Contract_ZuKong].[RoomOwner],
	[Contract_ZuKong].[RoomFee],
	[Contract_ZuKong].[AddTime],
	[Contract_ZuKong].[RoomStateID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[RoomName],
	INSERTED.[RoomState],
	INSERTED.[RoomOwner],
	INSERTED.[RoomFee],
	INSERTED.[AddTime],
	INSERTED.[RoomStateID]
into @table
VALUES ( 
	@RoomID,
	@RoomName,
	@RoomState,
	@RoomOwner,
	@RoomFee,
	@AddTime,
	@RoomStateID 
); 

SELECT 
	[ID],
	[RoomID],
	[RoomName],
	[RoomState],
	[RoomOwner],
	[RoomFee],
	[AddTime],
	[RoomStateID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@RoomName", EntityBase.GetDatabaseValue(@roomName)));
			parameters.Add(new SqlParameter("@RoomState", EntityBase.GetDatabaseValue(@roomState)));
			parameters.Add(new SqlParameter("@RoomOwner", EntityBase.GetDatabaseValue(@roomOwner)));
			parameters.Add(new SqlParameter("@RoomFee", EntityBase.GetDatabaseValue(@roomFee)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@RoomStateID", EntityBase.GetDatabaseValue(@roomStateID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Contract_ZuKong into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="roomName">roomName</param>
		/// <param name="roomState">roomState</param>
		/// <param name="roomOwner">roomOwner</param>
		/// <param name="roomFee">roomFee</param>
		/// <param name="addTime">addTime</param>
		/// <param name="roomStateID">roomStateID</param>
		public static void UpdateContract_ZuKong(int @iD, int @roomID, string @roomName, string @roomState, string @roomOwner, decimal @roomFee, DateTime @addTime, int @roomStateID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateContract_ZuKong(@iD, @roomID, @roomName, @roomState, @roomOwner, @roomFee, @addTime, @roomStateID, helper);
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
		/// Updates a Contract_ZuKong into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="roomName">roomName</param>
		/// <param name="roomState">roomState</param>
		/// <param name="roomOwner">roomOwner</param>
		/// <param name="roomFee">roomFee</param>
		/// <param name="addTime">addTime</param>
		/// <param name="roomStateID">roomStateID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateContract_ZuKong(int @iD, int @roomID, string @roomName, string @roomState, string @roomOwner, decimal @roomFee, DateTime @addTime, int @roomStateID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[RoomName] nvarchar(200),
	[RoomState] nvarchar(100),
	[RoomOwner] nvarchar(100),
	[RoomFee] decimal(18, 2),
	[AddTime] datetime,
	[RoomStateID] int
);

UPDATE [dbo].[Contract_ZuKong] SET 
	[Contract_ZuKong].[RoomID] = @RoomID,
	[Contract_ZuKong].[RoomName] = @RoomName,
	[Contract_ZuKong].[RoomState] = @RoomState,
	[Contract_ZuKong].[RoomOwner] = @RoomOwner,
	[Contract_ZuKong].[RoomFee] = @RoomFee,
	[Contract_ZuKong].[AddTime] = @AddTime,
	[Contract_ZuKong].[RoomStateID] = @RoomStateID 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[RoomName],
	INSERTED.[RoomState],
	INSERTED.[RoomOwner],
	INSERTED.[RoomFee],
	INSERTED.[AddTime],
	INSERTED.[RoomStateID]
into @table
WHERE 
	[Contract_ZuKong].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[RoomName],
	[RoomState],
	[RoomOwner],
	[RoomFee],
	[AddTime],
	[RoomStateID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@RoomName", EntityBase.GetDatabaseValue(@roomName)));
			parameters.Add(new SqlParameter("@RoomState", EntityBase.GetDatabaseValue(@roomState)));
			parameters.Add(new SqlParameter("@RoomOwner", EntityBase.GetDatabaseValue(@roomOwner)));
			parameters.Add(new SqlParameter("@RoomFee", EntityBase.GetDatabaseValue(@roomFee)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@RoomStateID", EntityBase.GetDatabaseValue(@roomStateID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Contract_ZuKong from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteContract_ZuKong(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteContract_ZuKong(@iD, helper);
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
		/// Deletes a Contract_ZuKong from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteContract_ZuKong(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Contract_ZuKong]
WHERE 
	[Contract_ZuKong].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Contract_ZuKong object.
		/// </summary>
		/// <returns>The newly created Contract_ZuKong object.</returns>
		public static Contract_ZuKong CreateContract_ZuKong()
		{
			return InitializeNew<Contract_ZuKong>();
		}
		
		/// <summary>
		/// Retrieve information for a Contract_ZuKong by a Contract_ZuKong's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Contract_ZuKong</returns>
		public static Contract_ZuKong GetContract_ZuKong(int @iD)
		{
			string commandText = @"
SELECT 
" + Contract_ZuKong.SelectFieldList + @"
FROM [dbo].[Contract_ZuKong] 
WHERE 
	[Contract_ZuKong].[ID] = @ID " + Contract_ZuKong.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_ZuKong>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Contract_ZuKong by a Contract_ZuKong's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Contract_ZuKong</returns>
		public static Contract_ZuKong GetContract_ZuKong(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Contract_ZuKong.SelectFieldList + @"
FROM [dbo].[Contract_ZuKong] 
WHERE 
	[Contract_ZuKong].[ID] = @ID " + Contract_ZuKong.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_ZuKong>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Contract_ZuKong objects.
		/// </summary>
		/// <returns>The retrieved collection of Contract_ZuKong objects.</returns>
		public static EntityList<Contract_ZuKong> GetContract_ZuKongs()
		{
			string commandText = @"
SELECT " + Contract_ZuKong.SelectFieldList + "FROM [dbo].[Contract_ZuKong] " + Contract_ZuKong.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Contract_ZuKong>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Contract_ZuKong objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_ZuKong objects.</returns>
        public static EntityList<Contract_ZuKong> GetContract_ZuKongs(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_ZuKong>(SelectFieldList, "FROM [dbo].[Contract_ZuKong]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Contract_ZuKong objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_ZuKong objects.</returns>
        public static EntityList<Contract_ZuKong> GetContract_ZuKongs(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_ZuKong>(SelectFieldList, "FROM [dbo].[Contract_ZuKong]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Contract_ZuKong objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Contract_ZuKong objects.</returns>
		protected static EntityList<Contract_ZuKong> GetContract_ZuKongs(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_ZuKongs(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Contract_ZuKong objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_ZuKong objects.</returns>
		protected static EntityList<Contract_ZuKong> GetContract_ZuKongs(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_ZuKongs(string.Empty, where, parameters, Contract_ZuKong.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_ZuKong objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_ZuKong objects.</returns>
		protected static EntityList<Contract_ZuKong> GetContract_ZuKongs(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_ZuKongs(prefix, where, parameters, Contract_ZuKong.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_ZuKong objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_ZuKong objects.</returns>
		protected static EntityList<Contract_ZuKong> GetContract_ZuKongs(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_ZuKongs(string.Empty, where, parameters, Contract_ZuKong.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_ZuKong objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_ZuKong objects.</returns>
		protected static EntityList<Contract_ZuKong> GetContract_ZuKongs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_ZuKongs(prefix, where, parameters, Contract_ZuKong.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_ZuKong objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Contract_ZuKong objects.</returns>
		protected static EntityList<Contract_ZuKong> GetContract_ZuKongs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Contract_ZuKong.SelectFieldList + "FROM [dbo].[Contract_ZuKong] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Contract_ZuKong>(reader);
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
        protected static EntityList<Contract_ZuKong> GetContract_ZuKongs(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_ZuKong>(SelectFieldList, "FROM [dbo].[Contract_ZuKong] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Contract_ZuKong objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_ZuKongCount()
        {
            return GetContract_ZuKongCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Contract_ZuKong objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_ZuKongCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Contract_ZuKong] " + where;

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
		public static partial class Contract_ZuKong_Properties
		{
			public const string ID = "ID";
			public const string RoomID = "RoomID";
			public const string RoomName = "RoomName";
			public const string RoomState = "RoomState";
			public const string RoomOwner = "RoomOwner";
			public const string RoomFee = "RoomFee";
			public const string AddTime = "AddTime";
			public const string RoomStateID = "RoomStateID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"RoomName" , "string:"},
    			 {"RoomState" , "string:"},
    			 {"RoomOwner" , "string:"},
    			 {"RoomFee" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"RoomStateID" , "int:"},
            };
		}
		#endregion
	}
}
