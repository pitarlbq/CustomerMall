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
	/// This object represents the properties and methods of a Mall_CheckRequestApprove.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_CheckRequestApprove 
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
		private int _requestID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RequestID
		{
			[DebuggerStepThrough()]
			get { return this._requestID; }
			set 
			{
				if (this._requestID != value) 
				{
					this._requestID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RequestID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _approveStatus = int.MinValue;
		/// <summary>
		/// 1-审批通过 2-审批未通过
		/// </summary>
        [Description("1-审批通过 2-审批未通过")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ApproveStatus
		{
			[DebuggerStepThrough()]
			get { return this._approveStatus; }
			set 
			{
				if (this._approveStatus != value) 
				{
					this._approveStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string ApproveMan
		{
			[DebuggerStepThrough()]
			get { return this._approveMan; }
			set 
			{
				if (this._approveMan != value) 
				{
					this._approveMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _approveUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ApproveUserID
		{
			[DebuggerStepThrough()]
			get { return this._approveUserID; }
			set 
			{
				if (this._approveUserID != value) 
				{
					this._approveUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _approveTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime ApproveTime
		{
			[DebuggerStepThrough()]
			get { return this._approveTime; }
			set 
			{
				if (this._approveTime != value) 
				{
					this._approveTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveRemark
		{
			[DebuggerStepThrough()]
			get { return this._approveRemark; }
			set 
			{
				if (this._approveRemark != value) 
				{
					this._approveRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveRemark");
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
	[RequestID] int,
	[ApproveStatus] int,
	[ApproveMan] nvarchar(200),
	[ApproveUserID] int,
	[ApproveTime] datetime,
	[ApproveRemark] ntext
);

INSERT INTO [dbo].[Mall_CheckRequestApprove] (
	[Mall_CheckRequestApprove].[RequestID],
	[Mall_CheckRequestApprove].[ApproveStatus],
	[Mall_CheckRequestApprove].[ApproveMan],
	[Mall_CheckRequestApprove].[ApproveUserID],
	[Mall_CheckRequestApprove].[ApproveTime],
	[Mall_CheckRequestApprove].[ApproveRemark]
) 
output 
	INSERTED.[ID],
	INSERTED.[RequestID],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveUserID],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark]
into @table
VALUES ( 
	@RequestID,
	@ApproveStatus,
	@ApproveMan,
	@ApproveUserID,
	@ApproveTime,
	@ApproveRemark 
); 

SELECT 
	[ID],
	[RequestID],
	[ApproveStatus],
	[ApproveMan],
	[ApproveUserID],
	[ApproveTime],
	[ApproveRemark] 
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
	[RequestID] int,
	[ApproveStatus] int,
	[ApproveMan] nvarchar(200),
	[ApproveUserID] int,
	[ApproveTime] datetime,
	[ApproveRemark] ntext
);

UPDATE [dbo].[Mall_CheckRequestApprove] SET 
	[Mall_CheckRequestApprove].[RequestID] = @RequestID,
	[Mall_CheckRequestApprove].[ApproveStatus] = @ApproveStatus,
	[Mall_CheckRequestApprove].[ApproveMan] = @ApproveMan,
	[Mall_CheckRequestApprove].[ApproveUserID] = @ApproveUserID,
	[Mall_CheckRequestApprove].[ApproveTime] = @ApproveTime,
	[Mall_CheckRequestApprove].[ApproveRemark] = @ApproveRemark 
output 
	INSERTED.[ID],
	INSERTED.[RequestID],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveUserID],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark]
into @table
WHERE 
	[Mall_CheckRequestApprove].[ID] = @ID

SELECT 
	[ID],
	[RequestID],
	[ApproveStatus],
	[ApproveMan],
	[ApproveUserID],
	[ApproveTime],
	[ApproveRemark] 
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
DELETE FROM [dbo].[Mall_CheckRequestApprove]
WHERE 
	[Mall_CheckRequestApprove].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_CheckRequestApprove() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_CheckRequestApprove(this.ID));
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
	[Mall_CheckRequestApprove].[ID],
	[Mall_CheckRequestApprove].[RequestID],
	[Mall_CheckRequestApprove].[ApproveStatus],
	[Mall_CheckRequestApprove].[ApproveMan],
	[Mall_CheckRequestApprove].[ApproveUserID],
	[Mall_CheckRequestApprove].[ApproveTime],
	[Mall_CheckRequestApprove].[ApproveRemark]
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
                return "Mall_CheckRequestApprove";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_CheckRequestApprove into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="requestID">requestID</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveUserID">approveUserID</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		public static void InsertMall_CheckRequestApprove(int @requestID, int @approveStatus, string @approveMan, int @approveUserID, DateTime @approveTime, string @approveRemark)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_CheckRequestApprove(@requestID, @approveStatus, @approveMan, @approveUserID, @approveTime, @approveRemark, helper);
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
		/// Insert a Mall_CheckRequestApprove into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="requestID">requestID</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveUserID">approveUserID</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_CheckRequestApprove(int @requestID, int @approveStatus, string @approveMan, int @approveUserID, DateTime @approveTime, string @approveRemark, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RequestID] int,
	[ApproveStatus] int,
	[ApproveMan] nvarchar(200),
	[ApproveUserID] int,
	[ApproveTime] datetime,
	[ApproveRemark] ntext
);

INSERT INTO [dbo].[Mall_CheckRequestApprove] (
	[Mall_CheckRequestApprove].[RequestID],
	[Mall_CheckRequestApprove].[ApproveStatus],
	[Mall_CheckRequestApprove].[ApproveMan],
	[Mall_CheckRequestApprove].[ApproveUserID],
	[Mall_CheckRequestApprove].[ApproveTime],
	[Mall_CheckRequestApprove].[ApproveRemark]
) 
output 
	INSERTED.[ID],
	INSERTED.[RequestID],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveUserID],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark]
into @table
VALUES ( 
	@RequestID,
	@ApproveStatus,
	@ApproveMan,
	@ApproveUserID,
	@ApproveTime,
	@ApproveRemark 
); 

SELECT 
	[ID],
	[RequestID],
	[ApproveStatus],
	[ApproveMan],
	[ApproveUserID],
	[ApproveTime],
	[ApproveRemark] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RequestID", EntityBase.GetDatabaseValue(@requestID)));
			parameters.Add(new SqlParameter("@ApproveStatus", EntityBase.GetDatabaseValue(@approveStatus)));
			parameters.Add(new SqlParameter("@ApproveMan", EntityBase.GetDatabaseValue(@approveMan)));
			parameters.Add(new SqlParameter("@ApproveUserID", EntityBase.GetDatabaseValue(@approveUserID)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_CheckRequestApprove into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="requestID">requestID</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveUserID">approveUserID</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		public static void UpdateMall_CheckRequestApprove(int @iD, int @requestID, int @approveStatus, string @approveMan, int @approveUserID, DateTime @approveTime, string @approveRemark)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_CheckRequestApprove(@iD, @requestID, @approveStatus, @approveMan, @approveUserID, @approveTime, @approveRemark, helper);
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
		/// Updates a Mall_CheckRequestApprove into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="requestID">requestID</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveUserID">approveUserID</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_CheckRequestApprove(int @iD, int @requestID, int @approveStatus, string @approveMan, int @approveUserID, DateTime @approveTime, string @approveRemark, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RequestID] int,
	[ApproveStatus] int,
	[ApproveMan] nvarchar(200),
	[ApproveUserID] int,
	[ApproveTime] datetime,
	[ApproveRemark] ntext
);

UPDATE [dbo].[Mall_CheckRequestApprove] SET 
	[Mall_CheckRequestApprove].[RequestID] = @RequestID,
	[Mall_CheckRequestApprove].[ApproveStatus] = @ApproveStatus,
	[Mall_CheckRequestApprove].[ApproveMan] = @ApproveMan,
	[Mall_CheckRequestApprove].[ApproveUserID] = @ApproveUserID,
	[Mall_CheckRequestApprove].[ApproveTime] = @ApproveTime,
	[Mall_CheckRequestApprove].[ApproveRemark] = @ApproveRemark 
output 
	INSERTED.[ID],
	INSERTED.[RequestID],
	INSERTED.[ApproveStatus],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveUserID],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveRemark]
into @table
WHERE 
	[Mall_CheckRequestApprove].[ID] = @ID

SELECT 
	[ID],
	[RequestID],
	[ApproveStatus],
	[ApproveMan],
	[ApproveUserID],
	[ApproveTime],
	[ApproveRemark] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RequestID", EntityBase.GetDatabaseValue(@requestID)));
			parameters.Add(new SqlParameter("@ApproveStatus", EntityBase.GetDatabaseValue(@approveStatus)));
			parameters.Add(new SqlParameter("@ApproveMan", EntityBase.GetDatabaseValue(@approveMan)));
			parameters.Add(new SqlParameter("@ApproveUserID", EntityBase.GetDatabaseValue(@approveUserID)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_CheckRequestApprove from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_CheckRequestApprove(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_CheckRequestApprove(@iD, helper);
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
		/// Deletes a Mall_CheckRequestApprove from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_CheckRequestApprove(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_CheckRequestApprove]
WHERE 
	[Mall_CheckRequestApprove].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_CheckRequestApprove object.
		/// </summary>
		/// <returns>The newly created Mall_CheckRequestApprove object.</returns>
		public static Mall_CheckRequestApprove CreateMall_CheckRequestApprove()
		{
			return InitializeNew<Mall_CheckRequestApprove>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_CheckRequestApprove by a Mall_CheckRequestApprove's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_CheckRequestApprove</returns>
		public static Mall_CheckRequestApprove GetMall_CheckRequestApprove(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_CheckRequestApprove.SelectFieldList + @"
FROM [dbo].[Mall_CheckRequestApprove] 
WHERE 
	[Mall_CheckRequestApprove].[ID] = @ID " + Mall_CheckRequestApprove.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_CheckRequestApprove>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_CheckRequestApprove by a Mall_CheckRequestApprove's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_CheckRequestApprove</returns>
		public static Mall_CheckRequestApprove GetMall_CheckRequestApprove(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_CheckRequestApprove.SelectFieldList + @"
FROM [dbo].[Mall_CheckRequestApprove] 
WHERE 
	[Mall_CheckRequestApprove].[ID] = @ID " + Mall_CheckRequestApprove.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_CheckRequestApprove>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestApprove objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_CheckRequestApprove objects.</returns>
		public static EntityList<Mall_CheckRequestApprove> GetMall_CheckRequestApproves()
		{
			string commandText = @"
SELECT " + Mall_CheckRequestApprove.SelectFieldList + "FROM [dbo].[Mall_CheckRequestApprove] " + Mall_CheckRequestApprove.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_CheckRequestApprove>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_CheckRequestApprove objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_CheckRequestApprove objects.</returns>
        public static EntityList<Mall_CheckRequestApprove> GetMall_CheckRequestApproves(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckRequestApprove>(SelectFieldList, "FROM [dbo].[Mall_CheckRequestApprove]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_CheckRequestApprove objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_CheckRequestApprove objects.</returns>
        public static EntityList<Mall_CheckRequestApprove> GetMall_CheckRequestApproves(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckRequestApprove>(SelectFieldList, "FROM [dbo].[Mall_CheckRequestApprove]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestApprove objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_CheckRequestApprove objects.</returns>
		protected static EntityList<Mall_CheckRequestApprove> GetMall_CheckRequestApproves(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckRequestApproves(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestApprove objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequestApprove objects.</returns>
		protected static EntityList<Mall_CheckRequestApprove> GetMall_CheckRequestApproves(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckRequestApproves(string.Empty, where, parameters, Mall_CheckRequestApprove.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestApprove objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequestApprove objects.</returns>
		protected static EntityList<Mall_CheckRequestApprove> GetMall_CheckRequestApproves(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckRequestApproves(prefix, where, parameters, Mall_CheckRequestApprove.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestApprove objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequestApprove objects.</returns>
		protected static EntityList<Mall_CheckRequestApprove> GetMall_CheckRequestApproves(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_CheckRequestApproves(string.Empty, where, parameters, Mall_CheckRequestApprove.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestApprove objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequestApprove objects.</returns>
		protected static EntityList<Mall_CheckRequestApprove> GetMall_CheckRequestApproves(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_CheckRequestApproves(prefix, where, parameters, Mall_CheckRequestApprove.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestApprove objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_CheckRequestApprove objects.</returns>
		protected static EntityList<Mall_CheckRequestApprove> GetMall_CheckRequestApproves(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_CheckRequestApprove.SelectFieldList + "FROM [dbo].[Mall_CheckRequestApprove] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_CheckRequestApprove>(reader);
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
        protected static EntityList<Mall_CheckRequestApprove> GetMall_CheckRequestApproves(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckRequestApprove>(SelectFieldList, "FROM [dbo].[Mall_CheckRequestApprove] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_CheckRequestApprove objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CheckRequestApproveCount()
        {
            return GetMall_CheckRequestApproveCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_CheckRequestApprove objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CheckRequestApproveCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_CheckRequestApprove] " + where;

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
		public static partial class Mall_CheckRequestApprove_Properties
		{
			public const string ID = "ID";
			public const string RequestID = "RequestID";
			public const string ApproveStatus = "ApproveStatus";
			public const string ApproveMan = "ApproveMan";
			public const string ApproveUserID = "ApproveUserID";
			public const string ApproveTime = "ApproveTime";
			public const string ApproveRemark = "ApproveRemark";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RequestID" , "int:"},
    			 {"ApproveStatus" , "int:1-审批通过 2-审批未通过"},
    			 {"ApproveMan" , "string:"},
    			 {"ApproveUserID" , "int:"},
    			 {"ApproveTime" , "DateTime:"},
    			 {"ApproveRemark" , "string:"},
            };
		}
		#endregion
	}
}
