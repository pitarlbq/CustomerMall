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
	/// This object represents the properties and methods of a Mall_CheckRequestConfirm.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_CheckRequestConfirm 
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
		private int _confirmStatus = int.MinValue;
		/// <summary>
		/// 1-无异议 2-申诉
		/// </summary>
        [Description("1-无异议 2-申诉")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ConfirmStatus
		{
			[DebuggerStepThrough()]
			get { return this._confirmStatus; }
			set 
			{
				if (this._confirmStatus != value) 
				{
					this._confirmStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("ConfirmStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _confirmTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime ConfirmTime
		{
			[DebuggerStepThrough()]
			get { return this._confirmTime; }
			set 
			{
				if (this._confirmTime != value) 
				{
					this._confirmTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ConfirmTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _confirmMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string ConfirmMan
		{
			[DebuggerStepThrough()]
			get { return this._confirmMan; }
			set 
			{
				if (this._confirmMan != value) 
				{
					this._confirmMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("ConfirmMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _confirmUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ConfirmUserID
		{
			[DebuggerStepThrough()]
			get { return this._confirmUserID; }
			set 
			{
				if (this._confirmUserID != value) 
				{
					this._confirmUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ConfirmUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _confirmRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ConfirmRemark
		{
			[DebuggerStepThrough()]
			get { return this._confirmRemark; }
			set 
			{
				if (this._confirmRemark != value) 
				{
					this._confirmRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("ConfirmRemark");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _processStatus = int.MinValue;
		/// <summary>
		/// 0-未处理 1-维持原考核 2-作废原考核
		/// </summary>
        [Description("0-未处理 1-维持原考核 2-作废原考核")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProcessStatus
		{
			[DebuggerStepThrough()]
			get { return this._processStatus; }
			set 
			{
				if (this._processStatus != value) 
				{
					this._processStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProcessStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _processTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ProcessTime
		{
			[DebuggerStepThrough()]
			get { return this._processTime; }
			set 
			{
				if (this._processTime != value) 
				{
					this._processTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProcessTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _processRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProcessRemark
		{
			[DebuggerStepThrough()]
			get { return this._processRemark; }
			set 
			{
				if (this._processRemark != value) 
				{
					this._processRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProcessRemark");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _processUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProcessUserID
		{
			[DebuggerStepThrough()]
			get { return this._processUserID; }
			set 
			{
				if (this._processUserID != value) 
				{
					this._processUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProcessUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _processUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProcessUserName
		{
			[DebuggerStepThrough()]
			get { return this._processUserName; }
			set 
			{
				if (this._processUserName != value) 
				{
					this._processUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProcessUserName");
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
	[ConfirmStatus] int,
	[ConfirmTime] datetime,
	[ConfirmMan] nvarchar(200),
	[ConfirmUserID] int,
	[ConfirmRemark] ntext,
	[ProcessStatus] int,
	[ProcessTime] datetime,
	[ProcessRemark] ntext,
	[ProcessUserID] int,
	[ProcessUserName] nvarchar(200)
);

INSERT INTO [dbo].[Mall_CheckRequestConfirm] (
	[Mall_CheckRequestConfirm].[RequestID],
	[Mall_CheckRequestConfirm].[ConfirmStatus],
	[Mall_CheckRequestConfirm].[ConfirmTime],
	[Mall_CheckRequestConfirm].[ConfirmMan],
	[Mall_CheckRequestConfirm].[ConfirmUserID],
	[Mall_CheckRequestConfirm].[ConfirmRemark],
	[Mall_CheckRequestConfirm].[ProcessStatus],
	[Mall_CheckRequestConfirm].[ProcessTime],
	[Mall_CheckRequestConfirm].[ProcessRemark],
	[Mall_CheckRequestConfirm].[ProcessUserID],
	[Mall_CheckRequestConfirm].[ProcessUserName]
) 
output 
	INSERTED.[ID],
	INSERTED.[RequestID],
	INSERTED.[ConfirmStatus],
	INSERTED.[ConfirmTime],
	INSERTED.[ConfirmMan],
	INSERTED.[ConfirmUserID],
	INSERTED.[ConfirmRemark],
	INSERTED.[ProcessStatus],
	INSERTED.[ProcessTime],
	INSERTED.[ProcessRemark],
	INSERTED.[ProcessUserID],
	INSERTED.[ProcessUserName]
into @table
VALUES ( 
	@RequestID,
	@ConfirmStatus,
	@ConfirmTime,
	@ConfirmMan,
	@ConfirmUserID,
	@ConfirmRemark,
	@ProcessStatus,
	@ProcessTime,
	@ProcessRemark,
	@ProcessUserID,
	@ProcessUserName 
); 

SELECT 
	[ID],
	[RequestID],
	[ConfirmStatus],
	[ConfirmTime],
	[ConfirmMan],
	[ConfirmUserID],
	[ConfirmRemark],
	[ProcessStatus],
	[ProcessTime],
	[ProcessRemark],
	[ProcessUserID],
	[ProcessUserName] 
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
	[ConfirmStatus] int,
	[ConfirmTime] datetime,
	[ConfirmMan] nvarchar(200),
	[ConfirmUserID] int,
	[ConfirmRemark] ntext,
	[ProcessStatus] int,
	[ProcessTime] datetime,
	[ProcessRemark] ntext,
	[ProcessUserID] int,
	[ProcessUserName] nvarchar(200)
);

UPDATE [dbo].[Mall_CheckRequestConfirm] SET 
	[Mall_CheckRequestConfirm].[RequestID] = @RequestID,
	[Mall_CheckRequestConfirm].[ConfirmStatus] = @ConfirmStatus,
	[Mall_CheckRequestConfirm].[ConfirmTime] = @ConfirmTime,
	[Mall_CheckRequestConfirm].[ConfirmMan] = @ConfirmMan,
	[Mall_CheckRequestConfirm].[ConfirmUserID] = @ConfirmUserID,
	[Mall_CheckRequestConfirm].[ConfirmRemark] = @ConfirmRemark,
	[Mall_CheckRequestConfirm].[ProcessStatus] = @ProcessStatus,
	[Mall_CheckRequestConfirm].[ProcessTime] = @ProcessTime,
	[Mall_CheckRequestConfirm].[ProcessRemark] = @ProcessRemark,
	[Mall_CheckRequestConfirm].[ProcessUserID] = @ProcessUserID,
	[Mall_CheckRequestConfirm].[ProcessUserName] = @ProcessUserName 
output 
	INSERTED.[ID],
	INSERTED.[RequestID],
	INSERTED.[ConfirmStatus],
	INSERTED.[ConfirmTime],
	INSERTED.[ConfirmMan],
	INSERTED.[ConfirmUserID],
	INSERTED.[ConfirmRemark],
	INSERTED.[ProcessStatus],
	INSERTED.[ProcessTime],
	INSERTED.[ProcessRemark],
	INSERTED.[ProcessUserID],
	INSERTED.[ProcessUserName]
into @table
WHERE 
	[Mall_CheckRequestConfirm].[ID] = @ID

SELECT 
	[ID],
	[RequestID],
	[ConfirmStatus],
	[ConfirmTime],
	[ConfirmMan],
	[ConfirmUserID],
	[ConfirmRemark],
	[ProcessStatus],
	[ProcessTime],
	[ProcessRemark],
	[ProcessUserID],
	[ProcessUserName] 
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
DELETE FROM [dbo].[Mall_CheckRequestConfirm]
WHERE 
	[Mall_CheckRequestConfirm].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_CheckRequestConfirm() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_CheckRequestConfirm(this.ID));
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
	[Mall_CheckRequestConfirm].[ID],
	[Mall_CheckRequestConfirm].[RequestID],
	[Mall_CheckRequestConfirm].[ConfirmStatus],
	[Mall_CheckRequestConfirm].[ConfirmTime],
	[Mall_CheckRequestConfirm].[ConfirmMan],
	[Mall_CheckRequestConfirm].[ConfirmUserID],
	[Mall_CheckRequestConfirm].[ConfirmRemark],
	[Mall_CheckRequestConfirm].[ProcessStatus],
	[Mall_CheckRequestConfirm].[ProcessTime],
	[Mall_CheckRequestConfirm].[ProcessRemark],
	[Mall_CheckRequestConfirm].[ProcessUserID],
	[Mall_CheckRequestConfirm].[ProcessUserName]
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
                return "Mall_CheckRequestConfirm";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_CheckRequestConfirm into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="requestID">requestID</param>
		/// <param name="confirmStatus">confirmStatus</param>
		/// <param name="confirmTime">confirmTime</param>
		/// <param name="confirmMan">confirmMan</param>
		/// <param name="confirmUserID">confirmUserID</param>
		/// <param name="confirmRemark">confirmRemark</param>
		/// <param name="processStatus">processStatus</param>
		/// <param name="processTime">processTime</param>
		/// <param name="processRemark">processRemark</param>
		/// <param name="processUserID">processUserID</param>
		/// <param name="processUserName">processUserName</param>
		public static void InsertMall_CheckRequestConfirm(int @requestID, int @confirmStatus, DateTime @confirmTime, string @confirmMan, int @confirmUserID, string @confirmRemark, int @processStatus, DateTime @processTime, string @processRemark, int @processUserID, string @processUserName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_CheckRequestConfirm(@requestID, @confirmStatus, @confirmTime, @confirmMan, @confirmUserID, @confirmRemark, @processStatus, @processTime, @processRemark, @processUserID, @processUserName, helper);
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
		/// Insert a Mall_CheckRequestConfirm into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="requestID">requestID</param>
		/// <param name="confirmStatus">confirmStatus</param>
		/// <param name="confirmTime">confirmTime</param>
		/// <param name="confirmMan">confirmMan</param>
		/// <param name="confirmUserID">confirmUserID</param>
		/// <param name="confirmRemark">confirmRemark</param>
		/// <param name="processStatus">processStatus</param>
		/// <param name="processTime">processTime</param>
		/// <param name="processRemark">processRemark</param>
		/// <param name="processUserID">processUserID</param>
		/// <param name="processUserName">processUserName</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_CheckRequestConfirm(int @requestID, int @confirmStatus, DateTime @confirmTime, string @confirmMan, int @confirmUserID, string @confirmRemark, int @processStatus, DateTime @processTime, string @processRemark, int @processUserID, string @processUserName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RequestID] int,
	[ConfirmStatus] int,
	[ConfirmTime] datetime,
	[ConfirmMan] nvarchar(200),
	[ConfirmUserID] int,
	[ConfirmRemark] ntext,
	[ProcessStatus] int,
	[ProcessTime] datetime,
	[ProcessRemark] ntext,
	[ProcessUserID] int,
	[ProcessUserName] nvarchar(200)
);

INSERT INTO [dbo].[Mall_CheckRequestConfirm] (
	[Mall_CheckRequestConfirm].[RequestID],
	[Mall_CheckRequestConfirm].[ConfirmStatus],
	[Mall_CheckRequestConfirm].[ConfirmTime],
	[Mall_CheckRequestConfirm].[ConfirmMan],
	[Mall_CheckRequestConfirm].[ConfirmUserID],
	[Mall_CheckRequestConfirm].[ConfirmRemark],
	[Mall_CheckRequestConfirm].[ProcessStatus],
	[Mall_CheckRequestConfirm].[ProcessTime],
	[Mall_CheckRequestConfirm].[ProcessRemark],
	[Mall_CheckRequestConfirm].[ProcessUserID],
	[Mall_CheckRequestConfirm].[ProcessUserName]
) 
output 
	INSERTED.[ID],
	INSERTED.[RequestID],
	INSERTED.[ConfirmStatus],
	INSERTED.[ConfirmTime],
	INSERTED.[ConfirmMan],
	INSERTED.[ConfirmUserID],
	INSERTED.[ConfirmRemark],
	INSERTED.[ProcessStatus],
	INSERTED.[ProcessTime],
	INSERTED.[ProcessRemark],
	INSERTED.[ProcessUserID],
	INSERTED.[ProcessUserName]
into @table
VALUES ( 
	@RequestID,
	@ConfirmStatus,
	@ConfirmTime,
	@ConfirmMan,
	@ConfirmUserID,
	@ConfirmRemark,
	@ProcessStatus,
	@ProcessTime,
	@ProcessRemark,
	@ProcessUserID,
	@ProcessUserName 
); 

SELECT 
	[ID],
	[RequestID],
	[ConfirmStatus],
	[ConfirmTime],
	[ConfirmMan],
	[ConfirmUserID],
	[ConfirmRemark],
	[ProcessStatus],
	[ProcessTime],
	[ProcessRemark],
	[ProcessUserID],
	[ProcessUserName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RequestID", EntityBase.GetDatabaseValue(@requestID)));
			parameters.Add(new SqlParameter("@ConfirmStatus", EntityBase.GetDatabaseValue(@confirmStatus)));
			parameters.Add(new SqlParameter("@ConfirmTime", EntityBase.GetDatabaseValue(@confirmTime)));
			parameters.Add(new SqlParameter("@ConfirmMan", EntityBase.GetDatabaseValue(@confirmMan)));
			parameters.Add(new SqlParameter("@ConfirmUserID", EntityBase.GetDatabaseValue(@confirmUserID)));
			parameters.Add(new SqlParameter("@ConfirmRemark", EntityBase.GetDatabaseValue(@confirmRemark)));
			parameters.Add(new SqlParameter("@ProcessStatus", EntityBase.GetDatabaseValue(@processStatus)));
			parameters.Add(new SqlParameter("@ProcessTime", EntityBase.GetDatabaseValue(@processTime)));
			parameters.Add(new SqlParameter("@ProcessRemark", EntityBase.GetDatabaseValue(@processRemark)));
			parameters.Add(new SqlParameter("@ProcessUserID", EntityBase.GetDatabaseValue(@processUserID)));
			parameters.Add(new SqlParameter("@ProcessUserName", EntityBase.GetDatabaseValue(@processUserName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_CheckRequestConfirm into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="requestID">requestID</param>
		/// <param name="confirmStatus">confirmStatus</param>
		/// <param name="confirmTime">confirmTime</param>
		/// <param name="confirmMan">confirmMan</param>
		/// <param name="confirmUserID">confirmUserID</param>
		/// <param name="confirmRemark">confirmRemark</param>
		/// <param name="processStatus">processStatus</param>
		/// <param name="processTime">processTime</param>
		/// <param name="processRemark">processRemark</param>
		/// <param name="processUserID">processUserID</param>
		/// <param name="processUserName">processUserName</param>
		public static void UpdateMall_CheckRequestConfirm(int @iD, int @requestID, int @confirmStatus, DateTime @confirmTime, string @confirmMan, int @confirmUserID, string @confirmRemark, int @processStatus, DateTime @processTime, string @processRemark, int @processUserID, string @processUserName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_CheckRequestConfirm(@iD, @requestID, @confirmStatus, @confirmTime, @confirmMan, @confirmUserID, @confirmRemark, @processStatus, @processTime, @processRemark, @processUserID, @processUserName, helper);
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
		/// Updates a Mall_CheckRequestConfirm into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="requestID">requestID</param>
		/// <param name="confirmStatus">confirmStatus</param>
		/// <param name="confirmTime">confirmTime</param>
		/// <param name="confirmMan">confirmMan</param>
		/// <param name="confirmUserID">confirmUserID</param>
		/// <param name="confirmRemark">confirmRemark</param>
		/// <param name="processStatus">processStatus</param>
		/// <param name="processTime">processTime</param>
		/// <param name="processRemark">processRemark</param>
		/// <param name="processUserID">processUserID</param>
		/// <param name="processUserName">processUserName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_CheckRequestConfirm(int @iD, int @requestID, int @confirmStatus, DateTime @confirmTime, string @confirmMan, int @confirmUserID, string @confirmRemark, int @processStatus, DateTime @processTime, string @processRemark, int @processUserID, string @processUserName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RequestID] int,
	[ConfirmStatus] int,
	[ConfirmTime] datetime,
	[ConfirmMan] nvarchar(200),
	[ConfirmUserID] int,
	[ConfirmRemark] ntext,
	[ProcessStatus] int,
	[ProcessTime] datetime,
	[ProcessRemark] ntext,
	[ProcessUserID] int,
	[ProcessUserName] nvarchar(200)
);

UPDATE [dbo].[Mall_CheckRequestConfirm] SET 
	[Mall_CheckRequestConfirm].[RequestID] = @RequestID,
	[Mall_CheckRequestConfirm].[ConfirmStatus] = @ConfirmStatus,
	[Mall_CheckRequestConfirm].[ConfirmTime] = @ConfirmTime,
	[Mall_CheckRequestConfirm].[ConfirmMan] = @ConfirmMan,
	[Mall_CheckRequestConfirm].[ConfirmUserID] = @ConfirmUserID,
	[Mall_CheckRequestConfirm].[ConfirmRemark] = @ConfirmRemark,
	[Mall_CheckRequestConfirm].[ProcessStatus] = @ProcessStatus,
	[Mall_CheckRequestConfirm].[ProcessTime] = @ProcessTime,
	[Mall_CheckRequestConfirm].[ProcessRemark] = @ProcessRemark,
	[Mall_CheckRequestConfirm].[ProcessUserID] = @ProcessUserID,
	[Mall_CheckRequestConfirm].[ProcessUserName] = @ProcessUserName 
output 
	INSERTED.[ID],
	INSERTED.[RequestID],
	INSERTED.[ConfirmStatus],
	INSERTED.[ConfirmTime],
	INSERTED.[ConfirmMan],
	INSERTED.[ConfirmUserID],
	INSERTED.[ConfirmRemark],
	INSERTED.[ProcessStatus],
	INSERTED.[ProcessTime],
	INSERTED.[ProcessRemark],
	INSERTED.[ProcessUserID],
	INSERTED.[ProcessUserName]
into @table
WHERE 
	[Mall_CheckRequestConfirm].[ID] = @ID

SELECT 
	[ID],
	[RequestID],
	[ConfirmStatus],
	[ConfirmTime],
	[ConfirmMan],
	[ConfirmUserID],
	[ConfirmRemark],
	[ProcessStatus],
	[ProcessTime],
	[ProcessRemark],
	[ProcessUserID],
	[ProcessUserName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RequestID", EntityBase.GetDatabaseValue(@requestID)));
			parameters.Add(new SqlParameter("@ConfirmStatus", EntityBase.GetDatabaseValue(@confirmStatus)));
			parameters.Add(new SqlParameter("@ConfirmTime", EntityBase.GetDatabaseValue(@confirmTime)));
			parameters.Add(new SqlParameter("@ConfirmMan", EntityBase.GetDatabaseValue(@confirmMan)));
			parameters.Add(new SqlParameter("@ConfirmUserID", EntityBase.GetDatabaseValue(@confirmUserID)));
			parameters.Add(new SqlParameter("@ConfirmRemark", EntityBase.GetDatabaseValue(@confirmRemark)));
			parameters.Add(new SqlParameter("@ProcessStatus", EntityBase.GetDatabaseValue(@processStatus)));
			parameters.Add(new SqlParameter("@ProcessTime", EntityBase.GetDatabaseValue(@processTime)));
			parameters.Add(new SqlParameter("@ProcessRemark", EntityBase.GetDatabaseValue(@processRemark)));
			parameters.Add(new SqlParameter("@ProcessUserID", EntityBase.GetDatabaseValue(@processUserID)));
			parameters.Add(new SqlParameter("@ProcessUserName", EntityBase.GetDatabaseValue(@processUserName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_CheckRequestConfirm from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_CheckRequestConfirm(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_CheckRequestConfirm(@iD, helper);
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
		/// Deletes a Mall_CheckRequestConfirm from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_CheckRequestConfirm(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_CheckRequestConfirm]
WHERE 
	[Mall_CheckRequestConfirm].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_CheckRequestConfirm object.
		/// </summary>
		/// <returns>The newly created Mall_CheckRequestConfirm object.</returns>
		public static Mall_CheckRequestConfirm CreateMall_CheckRequestConfirm()
		{
			return InitializeNew<Mall_CheckRequestConfirm>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_CheckRequestConfirm by a Mall_CheckRequestConfirm's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_CheckRequestConfirm</returns>
		public static Mall_CheckRequestConfirm GetMall_CheckRequestConfirm(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_CheckRequestConfirm.SelectFieldList + @"
FROM [dbo].[Mall_CheckRequestConfirm] 
WHERE 
	[Mall_CheckRequestConfirm].[ID] = @ID " + Mall_CheckRequestConfirm.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_CheckRequestConfirm>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_CheckRequestConfirm by a Mall_CheckRequestConfirm's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_CheckRequestConfirm</returns>
		public static Mall_CheckRequestConfirm GetMall_CheckRequestConfirm(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_CheckRequestConfirm.SelectFieldList + @"
FROM [dbo].[Mall_CheckRequestConfirm] 
WHERE 
	[Mall_CheckRequestConfirm].[ID] = @ID " + Mall_CheckRequestConfirm.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_CheckRequestConfirm>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestConfirm objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_CheckRequestConfirm objects.</returns>
		public static EntityList<Mall_CheckRequestConfirm> GetMall_CheckRequestConfirms()
		{
			string commandText = @"
SELECT " + Mall_CheckRequestConfirm.SelectFieldList + "FROM [dbo].[Mall_CheckRequestConfirm] " + Mall_CheckRequestConfirm.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_CheckRequestConfirm>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_CheckRequestConfirm objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_CheckRequestConfirm objects.</returns>
        public static EntityList<Mall_CheckRequestConfirm> GetMall_CheckRequestConfirms(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckRequestConfirm>(SelectFieldList, "FROM [dbo].[Mall_CheckRequestConfirm]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_CheckRequestConfirm objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_CheckRequestConfirm objects.</returns>
        public static EntityList<Mall_CheckRequestConfirm> GetMall_CheckRequestConfirms(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckRequestConfirm>(SelectFieldList, "FROM [dbo].[Mall_CheckRequestConfirm]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestConfirm objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_CheckRequestConfirm objects.</returns>
		protected static EntityList<Mall_CheckRequestConfirm> GetMall_CheckRequestConfirms(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckRequestConfirms(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestConfirm objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequestConfirm objects.</returns>
		protected static EntityList<Mall_CheckRequestConfirm> GetMall_CheckRequestConfirms(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckRequestConfirms(string.Empty, where, parameters, Mall_CheckRequestConfirm.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestConfirm objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequestConfirm objects.</returns>
		protected static EntityList<Mall_CheckRequestConfirm> GetMall_CheckRequestConfirms(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckRequestConfirms(prefix, where, parameters, Mall_CheckRequestConfirm.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestConfirm objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequestConfirm objects.</returns>
		protected static EntityList<Mall_CheckRequestConfirm> GetMall_CheckRequestConfirms(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_CheckRequestConfirms(string.Empty, where, parameters, Mall_CheckRequestConfirm.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestConfirm objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequestConfirm objects.</returns>
		protected static EntityList<Mall_CheckRequestConfirm> GetMall_CheckRequestConfirms(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_CheckRequestConfirms(prefix, where, parameters, Mall_CheckRequestConfirm.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestConfirm objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_CheckRequestConfirm objects.</returns>
		protected static EntityList<Mall_CheckRequestConfirm> GetMall_CheckRequestConfirms(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_CheckRequestConfirm.SelectFieldList + "FROM [dbo].[Mall_CheckRequestConfirm] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_CheckRequestConfirm>(reader);
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
        protected static EntityList<Mall_CheckRequestConfirm> GetMall_CheckRequestConfirms(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckRequestConfirm>(SelectFieldList, "FROM [dbo].[Mall_CheckRequestConfirm] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_CheckRequestConfirm objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CheckRequestConfirmCount()
        {
            return GetMall_CheckRequestConfirmCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_CheckRequestConfirm objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CheckRequestConfirmCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_CheckRequestConfirm] " + where;

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
		public static partial class Mall_CheckRequestConfirm_Properties
		{
			public const string ID = "ID";
			public const string RequestID = "RequestID";
			public const string ConfirmStatus = "ConfirmStatus";
			public const string ConfirmTime = "ConfirmTime";
			public const string ConfirmMan = "ConfirmMan";
			public const string ConfirmUserID = "ConfirmUserID";
			public const string ConfirmRemark = "ConfirmRemark";
			public const string ProcessStatus = "ProcessStatus";
			public const string ProcessTime = "ProcessTime";
			public const string ProcessRemark = "ProcessRemark";
			public const string ProcessUserID = "ProcessUserID";
			public const string ProcessUserName = "ProcessUserName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RequestID" , "int:"},
    			 {"ConfirmStatus" , "int:1-无异议 2-申诉"},
    			 {"ConfirmTime" , "DateTime:"},
    			 {"ConfirmMan" , "string:"},
    			 {"ConfirmUserID" , "int:"},
    			 {"ConfirmRemark" , "string:"},
    			 {"ProcessStatus" , "int:0-未处理 1-维持原考核 2-作废原考核"},
    			 {"ProcessTime" , "DateTime:"},
    			 {"ProcessRemark" , "string:"},
    			 {"ProcessUserID" , "int:"},
    			 {"ProcessUserName" , "string:"},
            };
		}
		#endregion
	}
}
