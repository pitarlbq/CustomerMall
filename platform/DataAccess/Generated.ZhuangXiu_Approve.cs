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
	/// This object represents the properties and methods of a ZhuangXiu_Approve.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ZhuangXiu_Approve 
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
		private int _zhuangXiuID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ZhuangXiuID
		{
			[DebuggerStepThrough()]
			get { return this._zhuangXiuID; }
			set 
			{
				if (this._zhuangXiuID != value) 
				{
					this._zhuangXiuID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ZhuangXiuID");
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
		private string _approveDesc = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveDesc
		{
			[DebuggerStepThrough()]
			get { return this._approveDesc; }
			set 
			{
				if (this._approveDesc != value) 
				{
					this._approveDesc = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveDesc");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveStatus = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveStatus
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
	[ZhuangXiuID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ApproveDesc] ntext,
	[ApproveStatus] nvarchar(50)
);

INSERT INTO [dbo].[ZhuangXiu_Approve] (
	[ZhuangXiu_Approve].[ZhuangXiuID],
	[ZhuangXiu_Approve].[AddTime],
	[ZhuangXiu_Approve].[AddMan],
	[ZhuangXiu_Approve].[ApproveDesc],
	[ZhuangXiu_Approve].[ApproveStatus]
) 
output 
	INSERTED.[ID],
	INSERTED.[ZhuangXiuID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ApproveDesc],
	INSERTED.[ApproveStatus]
into @table
VALUES ( 
	@ZhuangXiuID,
	@AddTime,
	@AddMan,
	@ApproveDesc,
	@ApproveStatus 
); 

SELECT 
	[ID],
	[ZhuangXiuID],
	[AddTime],
	[AddMan],
	[ApproveDesc],
	[ApproveStatus] 
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
	[ZhuangXiuID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ApproveDesc] ntext,
	[ApproveStatus] nvarchar(50)
);

UPDATE [dbo].[ZhuangXiu_Approve] SET 
	[ZhuangXiu_Approve].[ZhuangXiuID] = @ZhuangXiuID,
	[ZhuangXiu_Approve].[AddTime] = @AddTime,
	[ZhuangXiu_Approve].[AddMan] = @AddMan,
	[ZhuangXiu_Approve].[ApproveDesc] = @ApproveDesc,
	[ZhuangXiu_Approve].[ApproveStatus] = @ApproveStatus 
output 
	INSERTED.[ID],
	INSERTED.[ZhuangXiuID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ApproveDesc],
	INSERTED.[ApproveStatus]
into @table
WHERE 
	[ZhuangXiu_Approve].[ID] = @ID

SELECT 
	[ID],
	[ZhuangXiuID],
	[AddTime],
	[AddMan],
	[ApproveDesc],
	[ApproveStatus] 
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
DELETE FROM [dbo].[ZhuangXiu_Approve]
WHERE 
	[ZhuangXiu_Approve].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ZhuangXiu_Approve() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetZhuangXiu_Approve(this.ID));
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
	[ZhuangXiu_Approve].[ID],
	[ZhuangXiu_Approve].[ZhuangXiuID],
	[ZhuangXiu_Approve].[AddTime],
	[ZhuangXiu_Approve].[AddMan],
	[ZhuangXiu_Approve].[ApproveDesc],
	[ZhuangXiu_Approve].[ApproveStatus]
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
                return "ZhuangXiu_Approve";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ZhuangXiu_Approve into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="zhuangXiuID">zhuangXiuID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="approveDesc">approveDesc</param>
		/// <param name="approveStatus">approveStatus</param>
		public static void InsertZhuangXiu_Approve(int @zhuangXiuID, DateTime @addTime, string @addMan, string @approveDesc, string @approveStatus)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertZhuangXiu_Approve(@zhuangXiuID, @addTime, @addMan, @approveDesc, @approveStatus, helper);
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
		/// Insert a ZhuangXiu_Approve into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="zhuangXiuID">zhuangXiuID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="approveDesc">approveDesc</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="helper">helper</param>
		internal static void InsertZhuangXiu_Approve(int @zhuangXiuID, DateTime @addTime, string @addMan, string @approveDesc, string @approveStatus, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ZhuangXiuID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ApproveDesc] ntext,
	[ApproveStatus] nvarchar(50)
);

INSERT INTO [dbo].[ZhuangXiu_Approve] (
	[ZhuangXiu_Approve].[ZhuangXiuID],
	[ZhuangXiu_Approve].[AddTime],
	[ZhuangXiu_Approve].[AddMan],
	[ZhuangXiu_Approve].[ApproveDesc],
	[ZhuangXiu_Approve].[ApproveStatus]
) 
output 
	INSERTED.[ID],
	INSERTED.[ZhuangXiuID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ApproveDesc],
	INSERTED.[ApproveStatus]
into @table
VALUES ( 
	@ZhuangXiuID,
	@AddTime,
	@AddMan,
	@ApproveDesc,
	@ApproveStatus 
); 

SELECT 
	[ID],
	[ZhuangXiuID],
	[AddTime],
	[AddMan],
	[ApproveDesc],
	[ApproveStatus] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ZhuangXiuID", EntityBase.GetDatabaseValue(@zhuangXiuID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ApproveDesc", EntityBase.GetDatabaseValue(@approveDesc)));
			parameters.Add(new SqlParameter("@ApproveStatus", EntityBase.GetDatabaseValue(@approveStatus)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ZhuangXiu_Approve into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="zhuangXiuID">zhuangXiuID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="approveDesc">approveDesc</param>
		/// <param name="approveStatus">approveStatus</param>
		public static void UpdateZhuangXiu_Approve(int @iD, int @zhuangXiuID, DateTime @addTime, string @addMan, string @approveDesc, string @approveStatus)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateZhuangXiu_Approve(@iD, @zhuangXiuID, @addTime, @addMan, @approveDesc, @approveStatus, helper);
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
		/// Updates a ZhuangXiu_Approve into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="zhuangXiuID">zhuangXiuID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="approveDesc">approveDesc</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="helper">helper</param>
		internal static void UpdateZhuangXiu_Approve(int @iD, int @zhuangXiuID, DateTime @addTime, string @addMan, string @approveDesc, string @approveStatus, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ZhuangXiuID] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ApproveDesc] ntext,
	[ApproveStatus] nvarchar(50)
);

UPDATE [dbo].[ZhuangXiu_Approve] SET 
	[ZhuangXiu_Approve].[ZhuangXiuID] = @ZhuangXiuID,
	[ZhuangXiu_Approve].[AddTime] = @AddTime,
	[ZhuangXiu_Approve].[AddMan] = @AddMan,
	[ZhuangXiu_Approve].[ApproveDesc] = @ApproveDesc,
	[ZhuangXiu_Approve].[ApproveStatus] = @ApproveStatus 
output 
	INSERTED.[ID],
	INSERTED.[ZhuangXiuID],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ApproveDesc],
	INSERTED.[ApproveStatus]
into @table
WHERE 
	[ZhuangXiu_Approve].[ID] = @ID

SELECT 
	[ID],
	[ZhuangXiuID],
	[AddTime],
	[AddMan],
	[ApproveDesc],
	[ApproveStatus] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ZhuangXiuID", EntityBase.GetDatabaseValue(@zhuangXiuID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ApproveDesc", EntityBase.GetDatabaseValue(@approveDesc)));
			parameters.Add(new SqlParameter("@ApproveStatus", EntityBase.GetDatabaseValue(@approveStatus)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ZhuangXiu_Approve from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteZhuangXiu_Approve(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteZhuangXiu_Approve(@iD, helper);
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
		/// Deletes a ZhuangXiu_Approve from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteZhuangXiu_Approve(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ZhuangXiu_Approve]
WHERE 
	[ZhuangXiu_Approve].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ZhuangXiu_Approve object.
		/// </summary>
		/// <returns>The newly created ZhuangXiu_Approve object.</returns>
		public static ZhuangXiu_Approve CreateZhuangXiu_Approve()
		{
			return InitializeNew<ZhuangXiu_Approve>();
		}
		
		/// <summary>
		/// Retrieve information for a ZhuangXiu_Approve by a ZhuangXiu_Approve's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ZhuangXiu_Approve</returns>
		public static ZhuangXiu_Approve GetZhuangXiu_Approve(int @iD)
		{
			string commandText = @"
SELECT 
" + ZhuangXiu_Approve.SelectFieldList + @"
FROM [dbo].[ZhuangXiu_Approve] 
WHERE 
	[ZhuangXiu_Approve].[ID] = @ID " + ZhuangXiu_Approve.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ZhuangXiu_Approve>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ZhuangXiu_Approve by a ZhuangXiu_Approve's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ZhuangXiu_Approve</returns>
		public static ZhuangXiu_Approve GetZhuangXiu_Approve(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ZhuangXiu_Approve.SelectFieldList + @"
FROM [dbo].[ZhuangXiu_Approve] 
WHERE 
	[ZhuangXiu_Approve].[ID] = @ID " + ZhuangXiu_Approve.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ZhuangXiu_Approve>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Approve objects.
		/// </summary>
		/// <returns>The retrieved collection of ZhuangXiu_Approve objects.</returns>
		public static EntityList<ZhuangXiu_Approve> GetZhuangXiu_Approves()
		{
			string commandText = @"
SELECT " + ZhuangXiu_Approve.SelectFieldList + "FROM [dbo].[ZhuangXiu_Approve] " + ZhuangXiu_Approve.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ZhuangXiu_Approve>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ZhuangXiu_Approve objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ZhuangXiu_Approve objects.</returns>
        public static EntityList<ZhuangXiu_Approve> GetZhuangXiu_Approves(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ZhuangXiu_Approve>(SelectFieldList, "FROM [dbo].[ZhuangXiu_Approve]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ZhuangXiu_Approve objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ZhuangXiu_Approve objects.</returns>
        public static EntityList<ZhuangXiu_Approve> GetZhuangXiu_Approves(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ZhuangXiu_Approve>(SelectFieldList, "FROM [dbo].[ZhuangXiu_Approve]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Approve objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ZhuangXiu_Approve objects.</returns>
		protected static EntityList<ZhuangXiu_Approve> GetZhuangXiu_Approves(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetZhuangXiu_Approves(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Approve objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu_Approve objects.</returns>
		protected static EntityList<ZhuangXiu_Approve> GetZhuangXiu_Approves(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetZhuangXiu_Approves(string.Empty, where, parameters, ZhuangXiu_Approve.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Approve objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu_Approve objects.</returns>
		protected static EntityList<ZhuangXiu_Approve> GetZhuangXiu_Approves(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetZhuangXiu_Approves(prefix, where, parameters, ZhuangXiu_Approve.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Approve objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu_Approve objects.</returns>
		protected static EntityList<ZhuangXiu_Approve> GetZhuangXiu_Approves(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetZhuangXiu_Approves(string.Empty, where, parameters, ZhuangXiu_Approve.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Approve objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu_Approve objects.</returns>
		protected static EntityList<ZhuangXiu_Approve> GetZhuangXiu_Approves(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetZhuangXiu_Approves(prefix, where, parameters, ZhuangXiu_Approve.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Approve objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ZhuangXiu_Approve objects.</returns>
		protected static EntityList<ZhuangXiu_Approve> GetZhuangXiu_Approves(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ZhuangXiu_Approve.SelectFieldList + "FROM [dbo].[ZhuangXiu_Approve] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ZhuangXiu_Approve>(reader);
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
        protected static EntityList<ZhuangXiu_Approve> GetZhuangXiu_Approves(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ZhuangXiu_Approve>(SelectFieldList, "FROM [dbo].[ZhuangXiu_Approve] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ZhuangXiu_Approve objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetZhuangXiu_ApproveCount()
        {
            return GetZhuangXiu_ApproveCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ZhuangXiu_Approve objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetZhuangXiu_ApproveCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ZhuangXiu_Approve] " + where;

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
		public static partial class ZhuangXiu_Approve_Properties
		{
			public const string ID = "ID";
			public const string ZhuangXiuID = "ZhuangXiuID";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string ApproveDesc = "ApproveDesc";
			public const string ApproveStatus = "ApproveStatus";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ZhuangXiuID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"ApproveDesc" , "string:"},
    			 {"ApproveStatus" , "string:"},
            };
		}
		#endregion
	}
}
