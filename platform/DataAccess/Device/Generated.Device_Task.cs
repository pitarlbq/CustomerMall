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
	/// This object represents the properties and methods of a Device_Task.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Device_Task 
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
		private int _deviceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int DeviceID
		{
			[DebuggerStepThrough()]
			get { return this._deviceID; }
			set 
			{
				if (this._deviceID != value) 
				{
					this._deviceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeviceID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _taskFrom = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TaskFrom
		{
			[DebuggerStepThrough()]
			get { return this._taskFrom; }
			set 
			{
				if (this._taskFrom != value) 
				{
					this._taskFrom = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaskFrom");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _taskType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TaskType
		{
			[DebuggerStepThrough()]
			get { return this._taskType; }
			set 
			{
				if (this._taskType != value) 
				{
					this._taskType = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaskType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _taskLevel = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TaskLevel
		{
			[DebuggerStepThrough()]
			get { return this._taskLevel; }
			set 
			{
				if (this._taskLevel != value) 
				{
					this._taskLevel = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaskLevel");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _taskStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TaskStatus
		{
			[DebuggerStepThrough()]
			get { return this._taskStatus; }
			set 
			{
				if (this._taskStatus != value) 
				{
					this._taskStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaskStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _taskCategory = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TaskCategory
		{
			[DebuggerStepThrough()]
			get { return this._taskCategory; }
			set 
			{
				if (this._taskCategory != value) 
				{
					this._taskCategory = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaskCategory");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _taskChargeManID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TaskChargeManID
		{
			[DebuggerStepThrough()]
			get { return this._taskChargeManID; }
			set 
			{
				if (this._taskChargeManID != value) 
				{
					this._taskChargeManID = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaskChargeManID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _taskChargeManName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TaskChargeManName
		{
			[DebuggerStepThrough()]
			get { return this._taskChargeManName; }
			set 
			{
				if (this._taskChargeManName != value) 
				{
					this._taskChargeManName = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaskChargeManName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _taskChargeManPhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TaskChargeManPhone
		{
			[DebuggerStepThrough()]
			get { return this._taskChargeManPhone; }
			set 
			{
				if (this._taskChargeManPhone != value) 
				{
					this._taskChargeManPhone = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaskChargeManPhone");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _taskTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime TaskTime
		{
			[DebuggerStepThrough()]
			get { return this._taskTime; }
			set 
			{
				if (this._taskTime != value) 
				{
					this._taskTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaskTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _taskCompleteTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime TaskCompleteTime
		{
			[DebuggerStepThrough()]
			get { return this._taskCompleteTime; }
			set 
			{
				if (this._taskCompleteTime != value) 
				{
					this._taskCompleteTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaskCompleteTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _taskCompleteContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TaskCompleteContent
		{
			[DebuggerStepThrough()]
			get { return this._taskCompleteContent; }
			set 
			{
				if (this._taskCompleteContent != value) 
				{
					this._taskCompleteContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaskCompleteContent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _taskAddMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TaskAddMan
		{
			[DebuggerStepThrough()]
			get { return this._taskAddMan; }
			set 
			{
				if (this._taskAddMan != value) 
				{
					this._taskAddMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaskAddMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _taskAddTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime TaskAddTime
		{
			[DebuggerStepThrough()]
			get { return this._taskAddTime; }
			set 
			{
				if (this._taskAddTime != value) 
				{
					this._taskAddTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaskAddTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _taskContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TaskContent
		{
			[DebuggerStepThrough()]
			get { return this._taskContent; }
			set 
			{
				if (this._taskContent != value) 
				{
					this._taskContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaskContent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _taskAcceptTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime TaskAcceptTime
		{
			[DebuggerStepThrough()]
			get { return this._taskAcceptTime; }
			set 
			{
				if (this._taskAcceptTime != value) 
				{
					this._taskAcceptTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaskAcceptTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAPPShow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAPPShow
		{
			[DebuggerStepThrough()]
			get { return this._isAPPShow; }
			set 
			{
				if (this._isAPPShow != value) 
				{
					this._isAPPShow = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAPPShow");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAPPSend = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAPPSend
		{
			[DebuggerStepThrough()]
			get { return this._isAPPSend; }
			set 
			{
				if (this._isAPPSend != value) 
				{
					this._isAPPSend = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAPPSend");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _aPPSendTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime APPSendTime
		{
			[DebuggerStepThrough()]
			get { return this._aPPSendTime; }
			set 
			{
				if (this._aPPSendTime != value) 
				{
					this._aPPSendTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("APPSendTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _aPPSendResult = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string APPSendResult
		{
			[DebuggerStepThrough()]
			get { return this._aPPSendResult; }
			set 
			{
				if (this._aPPSendResult != value) 
				{
					this._aPPSendResult = value;
					this.IsDirty = true;	
					OnPropertyChanged("APPSendResult");
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
	[DeviceID] int,
	[TaskFrom] nvarchar(50),
	[TaskType] nvarchar(50),
	[TaskLevel] nvarchar(50),
	[TaskStatus] int,
	[TaskCategory] int,
	[TaskChargeManID] int,
	[TaskChargeManName] nvarchar(100),
	[TaskChargeManPhone] nvarchar(50),
	[TaskTime] datetime,
	[TaskCompleteTime] datetime,
	[TaskCompleteContent] ntext,
	[TaskAddMan] nvarchar(50),
	[TaskAddTime] datetime,
	[TaskContent] ntext,
	[TaskAcceptTime] datetime,
	[IsAPPShow] bit,
	[IsAPPSend] bit,
	[APPSendTime] datetime,
	[APPSendResult] ntext
);

INSERT INTO [dbo].[Device_Task] (
	[Device_Task].[DeviceID],
	[Device_Task].[TaskFrom],
	[Device_Task].[TaskType],
	[Device_Task].[TaskLevel],
	[Device_Task].[TaskStatus],
	[Device_Task].[TaskCategory],
	[Device_Task].[TaskChargeManID],
	[Device_Task].[TaskChargeManName],
	[Device_Task].[TaskChargeManPhone],
	[Device_Task].[TaskTime],
	[Device_Task].[TaskCompleteTime],
	[Device_Task].[TaskCompleteContent],
	[Device_Task].[TaskAddMan],
	[Device_Task].[TaskAddTime],
	[Device_Task].[TaskContent],
	[Device_Task].[TaskAcceptTime],
	[Device_Task].[IsAPPShow],
	[Device_Task].[IsAPPSend],
	[Device_Task].[APPSendTime],
	[Device_Task].[APPSendResult]
) 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[TaskFrom],
	INSERTED.[TaskType],
	INSERTED.[TaskLevel],
	INSERTED.[TaskStatus],
	INSERTED.[TaskCategory],
	INSERTED.[TaskChargeManID],
	INSERTED.[TaskChargeManName],
	INSERTED.[TaskChargeManPhone],
	INSERTED.[TaskTime],
	INSERTED.[TaskCompleteTime],
	INSERTED.[TaskCompleteContent],
	INSERTED.[TaskAddMan],
	INSERTED.[TaskAddTime],
	INSERTED.[TaskContent],
	INSERTED.[TaskAcceptTime],
	INSERTED.[IsAPPShow],
	INSERTED.[IsAPPSend],
	INSERTED.[APPSendTime],
	INSERTED.[APPSendResult]
into @table
VALUES ( 
	@DeviceID,
	@TaskFrom,
	@TaskType,
	@TaskLevel,
	@TaskStatus,
	@TaskCategory,
	@TaskChargeManID,
	@TaskChargeManName,
	@TaskChargeManPhone,
	@TaskTime,
	@TaskCompleteTime,
	@TaskCompleteContent,
	@TaskAddMan,
	@TaskAddTime,
	@TaskContent,
	@TaskAcceptTime,
	@IsAPPShow,
	@IsAPPSend,
	@APPSendTime,
	@APPSendResult 
); 

SELECT 
	[ID],
	[DeviceID],
	[TaskFrom],
	[TaskType],
	[TaskLevel],
	[TaskStatus],
	[TaskCategory],
	[TaskChargeManID],
	[TaskChargeManName],
	[TaskChargeManPhone],
	[TaskTime],
	[TaskCompleteTime],
	[TaskCompleteContent],
	[TaskAddMan],
	[TaskAddTime],
	[TaskContent],
	[TaskAcceptTime],
	[IsAPPShow],
	[IsAPPSend],
	[APPSendTime],
	[APPSendResult] 
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
	[DeviceID] int,
	[TaskFrom] nvarchar(50),
	[TaskType] nvarchar(50),
	[TaskLevel] nvarchar(50),
	[TaskStatus] int,
	[TaskCategory] int,
	[TaskChargeManID] int,
	[TaskChargeManName] nvarchar(100),
	[TaskChargeManPhone] nvarchar(50),
	[TaskTime] datetime,
	[TaskCompleteTime] datetime,
	[TaskCompleteContent] ntext,
	[TaskAddMan] nvarchar(50),
	[TaskAddTime] datetime,
	[TaskContent] ntext,
	[TaskAcceptTime] datetime,
	[IsAPPShow] bit,
	[IsAPPSend] bit,
	[APPSendTime] datetime,
	[APPSendResult] ntext
);

UPDATE [dbo].[Device_Task] SET 
	[Device_Task].[DeviceID] = @DeviceID,
	[Device_Task].[TaskFrom] = @TaskFrom,
	[Device_Task].[TaskType] = @TaskType,
	[Device_Task].[TaskLevel] = @TaskLevel,
	[Device_Task].[TaskStatus] = @TaskStatus,
	[Device_Task].[TaskCategory] = @TaskCategory,
	[Device_Task].[TaskChargeManID] = @TaskChargeManID,
	[Device_Task].[TaskChargeManName] = @TaskChargeManName,
	[Device_Task].[TaskChargeManPhone] = @TaskChargeManPhone,
	[Device_Task].[TaskTime] = @TaskTime,
	[Device_Task].[TaskCompleteTime] = @TaskCompleteTime,
	[Device_Task].[TaskCompleteContent] = @TaskCompleteContent,
	[Device_Task].[TaskAddMan] = @TaskAddMan,
	[Device_Task].[TaskAddTime] = @TaskAddTime,
	[Device_Task].[TaskContent] = @TaskContent,
	[Device_Task].[TaskAcceptTime] = @TaskAcceptTime,
	[Device_Task].[IsAPPShow] = @IsAPPShow,
	[Device_Task].[IsAPPSend] = @IsAPPSend,
	[Device_Task].[APPSendTime] = @APPSendTime,
	[Device_Task].[APPSendResult] = @APPSendResult 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[TaskFrom],
	INSERTED.[TaskType],
	INSERTED.[TaskLevel],
	INSERTED.[TaskStatus],
	INSERTED.[TaskCategory],
	INSERTED.[TaskChargeManID],
	INSERTED.[TaskChargeManName],
	INSERTED.[TaskChargeManPhone],
	INSERTED.[TaskTime],
	INSERTED.[TaskCompleteTime],
	INSERTED.[TaskCompleteContent],
	INSERTED.[TaskAddMan],
	INSERTED.[TaskAddTime],
	INSERTED.[TaskContent],
	INSERTED.[TaskAcceptTime],
	INSERTED.[IsAPPShow],
	INSERTED.[IsAPPSend],
	INSERTED.[APPSendTime],
	INSERTED.[APPSendResult]
into @table
WHERE 
	[Device_Task].[ID] = @ID

SELECT 
	[ID],
	[DeviceID],
	[TaskFrom],
	[TaskType],
	[TaskLevel],
	[TaskStatus],
	[TaskCategory],
	[TaskChargeManID],
	[TaskChargeManName],
	[TaskChargeManPhone],
	[TaskTime],
	[TaskCompleteTime],
	[TaskCompleteContent],
	[TaskAddMan],
	[TaskAddTime],
	[TaskContent],
	[TaskAcceptTime],
	[IsAPPShow],
	[IsAPPSend],
	[APPSendTime],
	[APPSendResult] 
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
DELETE FROM [dbo].[Device_Task]
WHERE 
	[Device_Task].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Device_Task() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetDevice_Task(this.ID));
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
	[Device_Task].[ID],
	[Device_Task].[DeviceID],
	[Device_Task].[TaskFrom],
	[Device_Task].[TaskType],
	[Device_Task].[TaskLevel],
	[Device_Task].[TaskStatus],
	[Device_Task].[TaskCategory],
	[Device_Task].[TaskChargeManID],
	[Device_Task].[TaskChargeManName],
	[Device_Task].[TaskChargeManPhone],
	[Device_Task].[TaskTime],
	[Device_Task].[TaskCompleteTime],
	[Device_Task].[TaskCompleteContent],
	[Device_Task].[TaskAddMan],
	[Device_Task].[TaskAddTime],
	[Device_Task].[TaskContent],
	[Device_Task].[TaskAcceptTime],
	[Device_Task].[IsAPPShow],
	[Device_Task].[IsAPPSend],
	[Device_Task].[APPSendTime],
	[Device_Task].[APPSendResult]
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
                return "Device_Task";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Device_Task into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="deviceID">deviceID</param>
		/// <param name="taskFrom">taskFrom</param>
		/// <param name="taskType">taskType</param>
		/// <param name="taskLevel">taskLevel</param>
		/// <param name="taskStatus">taskStatus</param>
		/// <param name="taskCategory">taskCategory</param>
		/// <param name="taskChargeManID">taskChargeManID</param>
		/// <param name="taskChargeManName">taskChargeManName</param>
		/// <param name="taskChargeManPhone">taskChargeManPhone</param>
		/// <param name="taskTime">taskTime</param>
		/// <param name="taskCompleteTime">taskCompleteTime</param>
		/// <param name="taskCompleteContent">taskCompleteContent</param>
		/// <param name="taskAddMan">taskAddMan</param>
		/// <param name="taskAddTime">taskAddTime</param>
		/// <param name="taskContent">taskContent</param>
		/// <param name="taskAcceptTime">taskAcceptTime</param>
		/// <param name="isAPPShow">isAPPShow</param>
		/// <param name="isAPPSend">isAPPSend</param>
		/// <param name="aPPSendTime">aPPSendTime</param>
		/// <param name="aPPSendResult">aPPSendResult</param>
		public static void InsertDevice_Task(int @deviceID, string @taskFrom, string @taskType, string @taskLevel, int @taskStatus, int @taskCategory, int @taskChargeManID, string @taskChargeManName, string @taskChargeManPhone, DateTime @taskTime, DateTime @taskCompleteTime, string @taskCompleteContent, string @taskAddMan, DateTime @taskAddTime, string @taskContent, DateTime @taskAcceptTime, bool @isAPPShow, bool @isAPPSend, DateTime @aPPSendTime, string @aPPSendResult)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertDevice_Task(@deviceID, @taskFrom, @taskType, @taskLevel, @taskStatus, @taskCategory, @taskChargeManID, @taskChargeManName, @taskChargeManPhone, @taskTime, @taskCompleteTime, @taskCompleteContent, @taskAddMan, @taskAddTime, @taskContent, @taskAcceptTime, @isAPPShow, @isAPPSend, @aPPSendTime, @aPPSendResult, helper);
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
		/// Insert a Device_Task into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="deviceID">deviceID</param>
		/// <param name="taskFrom">taskFrom</param>
		/// <param name="taskType">taskType</param>
		/// <param name="taskLevel">taskLevel</param>
		/// <param name="taskStatus">taskStatus</param>
		/// <param name="taskCategory">taskCategory</param>
		/// <param name="taskChargeManID">taskChargeManID</param>
		/// <param name="taskChargeManName">taskChargeManName</param>
		/// <param name="taskChargeManPhone">taskChargeManPhone</param>
		/// <param name="taskTime">taskTime</param>
		/// <param name="taskCompleteTime">taskCompleteTime</param>
		/// <param name="taskCompleteContent">taskCompleteContent</param>
		/// <param name="taskAddMan">taskAddMan</param>
		/// <param name="taskAddTime">taskAddTime</param>
		/// <param name="taskContent">taskContent</param>
		/// <param name="taskAcceptTime">taskAcceptTime</param>
		/// <param name="isAPPShow">isAPPShow</param>
		/// <param name="isAPPSend">isAPPSend</param>
		/// <param name="aPPSendTime">aPPSendTime</param>
		/// <param name="aPPSendResult">aPPSendResult</param>
		/// <param name="helper">helper</param>
		internal static void InsertDevice_Task(int @deviceID, string @taskFrom, string @taskType, string @taskLevel, int @taskStatus, int @taskCategory, int @taskChargeManID, string @taskChargeManName, string @taskChargeManPhone, DateTime @taskTime, DateTime @taskCompleteTime, string @taskCompleteContent, string @taskAddMan, DateTime @taskAddTime, string @taskContent, DateTime @taskAcceptTime, bool @isAPPShow, bool @isAPPSend, DateTime @aPPSendTime, string @aPPSendResult, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DeviceID] int,
	[TaskFrom] nvarchar(50),
	[TaskType] nvarchar(50),
	[TaskLevel] nvarchar(50),
	[TaskStatus] int,
	[TaskCategory] int,
	[TaskChargeManID] int,
	[TaskChargeManName] nvarchar(100),
	[TaskChargeManPhone] nvarchar(50),
	[TaskTime] datetime,
	[TaskCompleteTime] datetime,
	[TaskCompleteContent] ntext,
	[TaskAddMan] nvarchar(50),
	[TaskAddTime] datetime,
	[TaskContent] ntext,
	[TaskAcceptTime] datetime,
	[IsAPPShow] bit,
	[IsAPPSend] bit,
	[APPSendTime] datetime,
	[APPSendResult] ntext
);

INSERT INTO [dbo].[Device_Task] (
	[Device_Task].[DeviceID],
	[Device_Task].[TaskFrom],
	[Device_Task].[TaskType],
	[Device_Task].[TaskLevel],
	[Device_Task].[TaskStatus],
	[Device_Task].[TaskCategory],
	[Device_Task].[TaskChargeManID],
	[Device_Task].[TaskChargeManName],
	[Device_Task].[TaskChargeManPhone],
	[Device_Task].[TaskTime],
	[Device_Task].[TaskCompleteTime],
	[Device_Task].[TaskCompleteContent],
	[Device_Task].[TaskAddMan],
	[Device_Task].[TaskAddTime],
	[Device_Task].[TaskContent],
	[Device_Task].[TaskAcceptTime],
	[Device_Task].[IsAPPShow],
	[Device_Task].[IsAPPSend],
	[Device_Task].[APPSendTime],
	[Device_Task].[APPSendResult]
) 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[TaskFrom],
	INSERTED.[TaskType],
	INSERTED.[TaskLevel],
	INSERTED.[TaskStatus],
	INSERTED.[TaskCategory],
	INSERTED.[TaskChargeManID],
	INSERTED.[TaskChargeManName],
	INSERTED.[TaskChargeManPhone],
	INSERTED.[TaskTime],
	INSERTED.[TaskCompleteTime],
	INSERTED.[TaskCompleteContent],
	INSERTED.[TaskAddMan],
	INSERTED.[TaskAddTime],
	INSERTED.[TaskContent],
	INSERTED.[TaskAcceptTime],
	INSERTED.[IsAPPShow],
	INSERTED.[IsAPPSend],
	INSERTED.[APPSendTime],
	INSERTED.[APPSendResult]
into @table
VALUES ( 
	@DeviceID,
	@TaskFrom,
	@TaskType,
	@TaskLevel,
	@TaskStatus,
	@TaskCategory,
	@TaskChargeManID,
	@TaskChargeManName,
	@TaskChargeManPhone,
	@TaskTime,
	@TaskCompleteTime,
	@TaskCompleteContent,
	@TaskAddMan,
	@TaskAddTime,
	@TaskContent,
	@TaskAcceptTime,
	@IsAPPShow,
	@IsAPPSend,
	@APPSendTime,
	@APPSendResult 
); 

SELECT 
	[ID],
	[DeviceID],
	[TaskFrom],
	[TaskType],
	[TaskLevel],
	[TaskStatus],
	[TaskCategory],
	[TaskChargeManID],
	[TaskChargeManName],
	[TaskChargeManPhone],
	[TaskTime],
	[TaskCompleteTime],
	[TaskCompleteContent],
	[TaskAddMan],
	[TaskAddTime],
	[TaskContent],
	[TaskAcceptTime],
	[IsAPPShow],
	[IsAPPSend],
	[APPSendTime],
	[APPSendResult] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DeviceID", EntityBase.GetDatabaseValue(@deviceID)));
			parameters.Add(new SqlParameter("@TaskFrom", EntityBase.GetDatabaseValue(@taskFrom)));
			parameters.Add(new SqlParameter("@TaskType", EntityBase.GetDatabaseValue(@taskType)));
			parameters.Add(new SqlParameter("@TaskLevel", EntityBase.GetDatabaseValue(@taskLevel)));
			parameters.Add(new SqlParameter("@TaskStatus", EntityBase.GetDatabaseValue(@taskStatus)));
			parameters.Add(new SqlParameter("@TaskCategory", EntityBase.GetDatabaseValue(@taskCategory)));
			parameters.Add(new SqlParameter("@TaskChargeManID", EntityBase.GetDatabaseValue(@taskChargeManID)));
			parameters.Add(new SqlParameter("@TaskChargeManName", EntityBase.GetDatabaseValue(@taskChargeManName)));
			parameters.Add(new SqlParameter("@TaskChargeManPhone", EntityBase.GetDatabaseValue(@taskChargeManPhone)));
			parameters.Add(new SqlParameter("@TaskTime", EntityBase.GetDatabaseValue(@taskTime)));
			parameters.Add(new SqlParameter("@TaskCompleteTime", EntityBase.GetDatabaseValue(@taskCompleteTime)));
			parameters.Add(new SqlParameter("@TaskCompleteContent", EntityBase.GetDatabaseValue(@taskCompleteContent)));
			parameters.Add(new SqlParameter("@TaskAddMan", EntityBase.GetDatabaseValue(@taskAddMan)));
			parameters.Add(new SqlParameter("@TaskAddTime", EntityBase.GetDatabaseValue(@taskAddTime)));
			parameters.Add(new SqlParameter("@TaskContent", EntityBase.GetDatabaseValue(@taskContent)));
			parameters.Add(new SqlParameter("@TaskAcceptTime", EntityBase.GetDatabaseValue(@taskAcceptTime)));
			parameters.Add(new SqlParameter("@IsAPPShow", @isAPPShow));
			parameters.Add(new SqlParameter("@IsAPPSend", @isAPPSend));
			parameters.Add(new SqlParameter("@APPSendTime", EntityBase.GetDatabaseValue(@aPPSendTime)));
			parameters.Add(new SqlParameter("@APPSendResult", EntityBase.GetDatabaseValue(@aPPSendResult)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Device_Task into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="deviceID">deviceID</param>
		/// <param name="taskFrom">taskFrom</param>
		/// <param name="taskType">taskType</param>
		/// <param name="taskLevel">taskLevel</param>
		/// <param name="taskStatus">taskStatus</param>
		/// <param name="taskCategory">taskCategory</param>
		/// <param name="taskChargeManID">taskChargeManID</param>
		/// <param name="taskChargeManName">taskChargeManName</param>
		/// <param name="taskChargeManPhone">taskChargeManPhone</param>
		/// <param name="taskTime">taskTime</param>
		/// <param name="taskCompleteTime">taskCompleteTime</param>
		/// <param name="taskCompleteContent">taskCompleteContent</param>
		/// <param name="taskAddMan">taskAddMan</param>
		/// <param name="taskAddTime">taskAddTime</param>
		/// <param name="taskContent">taskContent</param>
		/// <param name="taskAcceptTime">taskAcceptTime</param>
		/// <param name="isAPPShow">isAPPShow</param>
		/// <param name="isAPPSend">isAPPSend</param>
		/// <param name="aPPSendTime">aPPSendTime</param>
		/// <param name="aPPSendResult">aPPSendResult</param>
		public static void UpdateDevice_Task(int @iD, int @deviceID, string @taskFrom, string @taskType, string @taskLevel, int @taskStatus, int @taskCategory, int @taskChargeManID, string @taskChargeManName, string @taskChargeManPhone, DateTime @taskTime, DateTime @taskCompleteTime, string @taskCompleteContent, string @taskAddMan, DateTime @taskAddTime, string @taskContent, DateTime @taskAcceptTime, bool @isAPPShow, bool @isAPPSend, DateTime @aPPSendTime, string @aPPSendResult)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateDevice_Task(@iD, @deviceID, @taskFrom, @taskType, @taskLevel, @taskStatus, @taskCategory, @taskChargeManID, @taskChargeManName, @taskChargeManPhone, @taskTime, @taskCompleteTime, @taskCompleteContent, @taskAddMan, @taskAddTime, @taskContent, @taskAcceptTime, @isAPPShow, @isAPPSend, @aPPSendTime, @aPPSendResult, helper);
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
		/// Updates a Device_Task into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="deviceID">deviceID</param>
		/// <param name="taskFrom">taskFrom</param>
		/// <param name="taskType">taskType</param>
		/// <param name="taskLevel">taskLevel</param>
		/// <param name="taskStatus">taskStatus</param>
		/// <param name="taskCategory">taskCategory</param>
		/// <param name="taskChargeManID">taskChargeManID</param>
		/// <param name="taskChargeManName">taskChargeManName</param>
		/// <param name="taskChargeManPhone">taskChargeManPhone</param>
		/// <param name="taskTime">taskTime</param>
		/// <param name="taskCompleteTime">taskCompleteTime</param>
		/// <param name="taskCompleteContent">taskCompleteContent</param>
		/// <param name="taskAddMan">taskAddMan</param>
		/// <param name="taskAddTime">taskAddTime</param>
		/// <param name="taskContent">taskContent</param>
		/// <param name="taskAcceptTime">taskAcceptTime</param>
		/// <param name="isAPPShow">isAPPShow</param>
		/// <param name="isAPPSend">isAPPSend</param>
		/// <param name="aPPSendTime">aPPSendTime</param>
		/// <param name="aPPSendResult">aPPSendResult</param>
		/// <param name="helper">helper</param>
		internal static void UpdateDevice_Task(int @iD, int @deviceID, string @taskFrom, string @taskType, string @taskLevel, int @taskStatus, int @taskCategory, int @taskChargeManID, string @taskChargeManName, string @taskChargeManPhone, DateTime @taskTime, DateTime @taskCompleteTime, string @taskCompleteContent, string @taskAddMan, DateTime @taskAddTime, string @taskContent, DateTime @taskAcceptTime, bool @isAPPShow, bool @isAPPSend, DateTime @aPPSendTime, string @aPPSendResult, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DeviceID] int,
	[TaskFrom] nvarchar(50),
	[TaskType] nvarchar(50),
	[TaskLevel] nvarchar(50),
	[TaskStatus] int,
	[TaskCategory] int,
	[TaskChargeManID] int,
	[TaskChargeManName] nvarchar(100),
	[TaskChargeManPhone] nvarchar(50),
	[TaskTime] datetime,
	[TaskCompleteTime] datetime,
	[TaskCompleteContent] ntext,
	[TaskAddMan] nvarchar(50),
	[TaskAddTime] datetime,
	[TaskContent] ntext,
	[TaskAcceptTime] datetime,
	[IsAPPShow] bit,
	[IsAPPSend] bit,
	[APPSendTime] datetime,
	[APPSendResult] ntext
);

UPDATE [dbo].[Device_Task] SET 
	[Device_Task].[DeviceID] = @DeviceID,
	[Device_Task].[TaskFrom] = @TaskFrom,
	[Device_Task].[TaskType] = @TaskType,
	[Device_Task].[TaskLevel] = @TaskLevel,
	[Device_Task].[TaskStatus] = @TaskStatus,
	[Device_Task].[TaskCategory] = @TaskCategory,
	[Device_Task].[TaskChargeManID] = @TaskChargeManID,
	[Device_Task].[TaskChargeManName] = @TaskChargeManName,
	[Device_Task].[TaskChargeManPhone] = @TaskChargeManPhone,
	[Device_Task].[TaskTime] = @TaskTime,
	[Device_Task].[TaskCompleteTime] = @TaskCompleteTime,
	[Device_Task].[TaskCompleteContent] = @TaskCompleteContent,
	[Device_Task].[TaskAddMan] = @TaskAddMan,
	[Device_Task].[TaskAddTime] = @TaskAddTime,
	[Device_Task].[TaskContent] = @TaskContent,
	[Device_Task].[TaskAcceptTime] = @TaskAcceptTime,
	[Device_Task].[IsAPPShow] = @IsAPPShow,
	[Device_Task].[IsAPPSend] = @IsAPPSend,
	[Device_Task].[APPSendTime] = @APPSendTime,
	[Device_Task].[APPSendResult] = @APPSendResult 
output 
	INSERTED.[ID],
	INSERTED.[DeviceID],
	INSERTED.[TaskFrom],
	INSERTED.[TaskType],
	INSERTED.[TaskLevel],
	INSERTED.[TaskStatus],
	INSERTED.[TaskCategory],
	INSERTED.[TaskChargeManID],
	INSERTED.[TaskChargeManName],
	INSERTED.[TaskChargeManPhone],
	INSERTED.[TaskTime],
	INSERTED.[TaskCompleteTime],
	INSERTED.[TaskCompleteContent],
	INSERTED.[TaskAddMan],
	INSERTED.[TaskAddTime],
	INSERTED.[TaskContent],
	INSERTED.[TaskAcceptTime],
	INSERTED.[IsAPPShow],
	INSERTED.[IsAPPSend],
	INSERTED.[APPSendTime],
	INSERTED.[APPSendResult]
into @table
WHERE 
	[Device_Task].[ID] = @ID

SELECT 
	[ID],
	[DeviceID],
	[TaskFrom],
	[TaskType],
	[TaskLevel],
	[TaskStatus],
	[TaskCategory],
	[TaskChargeManID],
	[TaskChargeManName],
	[TaskChargeManPhone],
	[TaskTime],
	[TaskCompleteTime],
	[TaskCompleteContent],
	[TaskAddMan],
	[TaskAddTime],
	[TaskContent],
	[TaskAcceptTime],
	[IsAPPShow],
	[IsAPPSend],
	[APPSendTime],
	[APPSendResult] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@DeviceID", EntityBase.GetDatabaseValue(@deviceID)));
			parameters.Add(new SqlParameter("@TaskFrom", EntityBase.GetDatabaseValue(@taskFrom)));
			parameters.Add(new SqlParameter("@TaskType", EntityBase.GetDatabaseValue(@taskType)));
			parameters.Add(new SqlParameter("@TaskLevel", EntityBase.GetDatabaseValue(@taskLevel)));
			parameters.Add(new SqlParameter("@TaskStatus", EntityBase.GetDatabaseValue(@taskStatus)));
			parameters.Add(new SqlParameter("@TaskCategory", EntityBase.GetDatabaseValue(@taskCategory)));
			parameters.Add(new SqlParameter("@TaskChargeManID", EntityBase.GetDatabaseValue(@taskChargeManID)));
			parameters.Add(new SqlParameter("@TaskChargeManName", EntityBase.GetDatabaseValue(@taskChargeManName)));
			parameters.Add(new SqlParameter("@TaskChargeManPhone", EntityBase.GetDatabaseValue(@taskChargeManPhone)));
			parameters.Add(new SqlParameter("@TaskTime", EntityBase.GetDatabaseValue(@taskTime)));
			parameters.Add(new SqlParameter("@TaskCompleteTime", EntityBase.GetDatabaseValue(@taskCompleteTime)));
			parameters.Add(new SqlParameter("@TaskCompleteContent", EntityBase.GetDatabaseValue(@taskCompleteContent)));
			parameters.Add(new SqlParameter("@TaskAddMan", EntityBase.GetDatabaseValue(@taskAddMan)));
			parameters.Add(new SqlParameter("@TaskAddTime", EntityBase.GetDatabaseValue(@taskAddTime)));
			parameters.Add(new SqlParameter("@TaskContent", EntityBase.GetDatabaseValue(@taskContent)));
			parameters.Add(new SqlParameter("@TaskAcceptTime", EntityBase.GetDatabaseValue(@taskAcceptTime)));
			parameters.Add(new SqlParameter("@IsAPPShow", @isAPPShow));
			parameters.Add(new SqlParameter("@IsAPPSend", @isAPPSend));
			parameters.Add(new SqlParameter("@APPSendTime", EntityBase.GetDatabaseValue(@aPPSendTime)));
			parameters.Add(new SqlParameter("@APPSendResult", EntityBase.GetDatabaseValue(@aPPSendResult)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Device_Task from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteDevice_Task(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteDevice_Task(@iD, helper);
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
		/// Deletes a Device_Task from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteDevice_Task(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Device_Task]
WHERE 
	[Device_Task].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Device_Task object.
		/// </summary>
		/// <returns>The newly created Device_Task object.</returns>
		public static Device_Task CreateDevice_Task()
		{
			return InitializeNew<Device_Task>();
		}
		
		/// <summary>
		/// Retrieve information for a Device_Task by a Device_Task's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Device_Task</returns>
		public static Device_Task GetDevice_Task(int @iD)
		{
			string commandText = @"
SELECT 
" + Device_Task.SelectFieldList + @"
FROM [dbo].[Device_Task] 
WHERE 
	[Device_Task].[ID] = @ID " + Device_Task.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Device_Task>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Device_Task by a Device_Task's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Device_Task</returns>
		public static Device_Task GetDevice_Task(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Device_Task.SelectFieldList + @"
FROM [dbo].[Device_Task] 
WHERE 
	[Device_Task].[ID] = @ID " + Device_Task.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Device_Task>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Device_Task objects.
		/// </summary>
		/// <returns>The retrieved collection of Device_Task objects.</returns>
		public static EntityList<Device_Task> GetDevice_Tasks()
		{
			string commandText = @"
SELECT " + Device_Task.SelectFieldList + "FROM [dbo].[Device_Task] " + Device_Task.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Device_Task>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Device_Task objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Device_Task objects.</returns>
        public static EntityList<Device_Task> GetDevice_Tasks(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Device_Task>(SelectFieldList, "FROM [dbo].[Device_Task]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Device_Task objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Device_Task objects.</returns>
        public static EntityList<Device_Task> GetDevice_Tasks(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Device_Task>(SelectFieldList, "FROM [dbo].[Device_Task]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Device_Task objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Device_Task objects.</returns>
		protected static EntityList<Device_Task> GetDevice_Tasks(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDevice_Tasks(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Device_Task objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Device_Task objects.</returns>
		protected static EntityList<Device_Task> GetDevice_Tasks(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDevice_Tasks(string.Empty, where, parameters, Device_Task.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_Task objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Device_Task objects.</returns>
		protected static EntityList<Device_Task> GetDevice_Tasks(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDevice_Tasks(prefix, where, parameters, Device_Task.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_Task objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Device_Task objects.</returns>
		protected static EntityList<Device_Task> GetDevice_Tasks(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetDevice_Tasks(string.Empty, where, parameters, Device_Task.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_Task objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Device_Task objects.</returns>
		protected static EntityList<Device_Task> GetDevice_Tasks(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetDevice_Tasks(prefix, where, parameters, Device_Task.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_Task objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Device_Task objects.</returns>
		protected static EntityList<Device_Task> GetDevice_Tasks(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Device_Task.SelectFieldList + "FROM [dbo].[Device_Task] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Device_Task>(reader);
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
        protected static EntityList<Device_Task> GetDevice_Tasks(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Device_Task>(SelectFieldList, "FROM [dbo].[Device_Task] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Device_Task objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetDevice_TaskCount()
        {
            return GetDevice_TaskCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Device_Task objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetDevice_TaskCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Device_Task] " + where;

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
		public static partial class Device_Task_Properties
		{
			public const string ID = "ID";
			public const string DeviceID = "DeviceID";
			public const string TaskFrom = "TaskFrom";
			public const string TaskType = "TaskType";
			public const string TaskLevel = "TaskLevel";
			public const string TaskStatus = "TaskStatus";
			public const string TaskCategory = "TaskCategory";
			public const string TaskChargeManID = "TaskChargeManID";
			public const string TaskChargeManName = "TaskChargeManName";
			public const string TaskChargeManPhone = "TaskChargeManPhone";
			public const string TaskTime = "TaskTime";
			public const string TaskCompleteTime = "TaskCompleteTime";
			public const string TaskCompleteContent = "TaskCompleteContent";
			public const string TaskAddMan = "TaskAddMan";
			public const string TaskAddTime = "TaskAddTime";
			public const string TaskContent = "TaskContent";
			public const string TaskAcceptTime = "TaskAcceptTime";
			public const string IsAPPShow = "IsAPPShow";
			public const string IsAPPSend = "IsAPPSend";
			public const string APPSendTime = "APPSendTime";
			public const string APPSendResult = "APPSendResult";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"DeviceID" , "int:"},
    			 {"TaskFrom" , "string:"},
    			 {"TaskType" , "string:"},
    			 {"TaskLevel" , "string:"},
    			 {"TaskStatus" , "int:"},
    			 {"TaskCategory" , "int:"},
    			 {"TaskChargeManID" , "int:"},
    			 {"TaskChargeManName" , "string:"},
    			 {"TaskChargeManPhone" , "string:"},
    			 {"TaskTime" , "DateTime:"},
    			 {"TaskCompleteTime" , "DateTime:"},
    			 {"TaskCompleteContent" , "string:"},
    			 {"TaskAddMan" , "string:"},
    			 {"TaskAddTime" , "DateTime:"},
    			 {"TaskContent" , "string:"},
    			 {"TaskAcceptTime" , "DateTime:"},
    			 {"IsAPPShow" , "bool:"},
    			 {"IsAPPSend" , "bool:"},
    			 {"APPSendTime" , "DateTime:"},
    			 {"APPSendResult" , "string:"},
            };
		}
		#endregion
	}
}
