using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Foresight.DataAccess.Framework;


namespace Foresight.DataAccess
{
	/// <summary>
	/// This object represents the properties and methods of a ViewDeviceTask.
	/// </summary>
	[Serializable()]
	public partial class ViewDeviceTask 
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
		[DataObjectField(false, false, false)]
		public int ID
		{
			[DebuggerStepThrough()]
			get { return this._iD; }
            protected set { this._iD = value;}
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
            protected set { this._deviceID = value;}
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
            protected set { this._taskFrom = value;}
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
            protected set { this._taskType = value;}
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
            protected set { this._taskLevel = value;}
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
            protected set { this._taskStatus = value;}
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
            protected set { this._taskCategory = value;}
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
            protected set { this._taskChargeManID = value;}
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
            protected set { this._taskChargeManName = value;}
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
            protected set { this._taskChargeManPhone = value;}
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
            protected set { this._taskTime = value;}
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
            protected set { this._taskCompleteTime = value;}
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
            protected set { this._taskCompleteContent = value;}
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
            protected set { this._taskAddMan = value;}
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
            protected set { this._taskAddTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _deviceNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DeviceNo
		{
			[DebuggerStepThrough()]
			get { return this._deviceNo; }
            protected set { this._deviceNo = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _deviceTypeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int DeviceTypeID
		{
			[DebuggerStepThrough()]
			get { return this._deviceTypeID; }
            protected set { this._deviceTypeID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _deviceName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DeviceName
		{
			[DebuggerStepThrough()]
			get { return this._deviceName; }
            protected set { this._deviceName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _deviceGroupID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int DeviceGroupID
		{
			[DebuggerStepThrough()]
			get { return this._deviceGroupID; }
            protected set { this._deviceGroupID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _modelNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ModelNo
		{
			[DebuggerStepThrough()]
			get { return this._modelNo; }
            protected set { this._modelNo = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _deviceTypeName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DeviceTypeName
		{
			[DebuggerStepThrough()]
			get { return this._deviceTypeName; }
            protected set { this._deviceTypeName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _deviceGroupName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DeviceGroupName
		{
			[DebuggerStepThrough()]
			get { return this._deviceGroupName; }
            protected set { this._deviceGroupName = value;}
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
            protected set { this._taskContent = value;}
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
            protected set { this._taskAcceptTime = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewDeviceTask() { }
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
	[ViewDeviceTask].[ID],
	[ViewDeviceTask].[DeviceID],
	[ViewDeviceTask].[TaskFrom],
	[ViewDeviceTask].[TaskType],
	[ViewDeviceTask].[TaskLevel],
	[ViewDeviceTask].[TaskStatus],
	[ViewDeviceTask].[TaskCategory],
	[ViewDeviceTask].[TaskChargeManID],
	[ViewDeviceTask].[TaskChargeManName],
	[ViewDeviceTask].[TaskChargeManPhone],
	[ViewDeviceTask].[TaskTime],
	[ViewDeviceTask].[TaskCompleteTime],
	[ViewDeviceTask].[TaskCompleteContent],
	[ViewDeviceTask].[TaskAddMan],
	[ViewDeviceTask].[TaskAddTime],
	[ViewDeviceTask].[DeviceNo],
	[ViewDeviceTask].[DeviceTypeID],
	[ViewDeviceTask].[DeviceName],
	[ViewDeviceTask].[DeviceGroupID],
	[ViewDeviceTask].[ModelNo],
	[ViewDeviceTask].[DeviceTypeName],
	[ViewDeviceTask].[DeviceGroupName],
	[ViewDeviceTask].[TaskContent],
	[ViewDeviceTask].[TaskAcceptTime]
";
			}
		}
		
		
		/// <summary>
        /// View Name
        /// </summary>
        public static string ViewName
        {
            get
            {
                return "ViewDeviceTask";
            }
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
		
		#region Static Methods
				
		/// <summary>
		/// Gets a collection ViewDeviceTask objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewDeviceTask objects.</returns>
		public static EntityList<ViewDeviceTask> GetViewDeviceTasks()
		{
			string commandText = @"
SELECT " + ViewDeviceTask.SelectFieldList + "FROM [dbo].[ViewDeviceTask] " + ViewDeviceTask.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewDeviceTask>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewDeviceTask objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewDeviceTask objects.</returns>
        public static EntityList<ViewDeviceTask> GetViewDeviceTasks(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewDeviceTask>(SelectFieldList, "FROM [dbo].[ViewDeviceTask]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewDeviceTask objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewDeviceTask objects.</returns>
        public static EntityList<ViewDeviceTask> GetViewDeviceTasks(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewDeviceTask>(SelectFieldList, "FROM [dbo].[ViewDeviceTask]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewDeviceTask objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewDeviceTaskCount()
        {
            return GetViewDeviceTaskCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewDeviceTask objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewDeviceTaskCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewDeviceTask] " + where;

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
		
		/// <summary>
		/// Gets a collection ViewDeviceTask objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewDeviceTask objects.</returns>
		protected static EntityList<ViewDeviceTask> GetViewDeviceTasks(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewDeviceTasks(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewDeviceTask objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewDeviceTask objects.</returns>
		protected static EntityList<ViewDeviceTask> GetViewDeviceTasks(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewDeviceTasks(string.Empty, where, parameters, ViewDeviceTask.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewDeviceTask objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewDeviceTask objects.</returns>
		protected static EntityList<ViewDeviceTask> GetViewDeviceTasks(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewDeviceTasks(prefix, where, parameters, ViewDeviceTask.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewDeviceTask objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewDeviceTask objects.</returns>
		protected static EntityList<ViewDeviceTask> GetViewDeviceTasks(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewDeviceTasks(string.Empty, where, parameters, ViewDeviceTask.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewDeviceTask objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewDeviceTask objects.</returns>
		protected static EntityList<ViewDeviceTask> GetViewDeviceTasks(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewDeviceTasks(prefix, where, parameters, ViewDeviceTask.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewDeviceTask objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewDeviceTask objects.</returns>
		protected static EntityList<ViewDeviceTask> GetViewDeviceTasks(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewDeviceTask.SelectFieldList + "FROM [dbo].[ViewDeviceTask] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewDeviceTask>(reader);
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
        protected static EntityList<ViewDeviceTask> GetViewDeviceTasks(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewDeviceTask>(SelectFieldList, "FROM [dbo].[ViewDeviceTask] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewDeviceTaskProperties
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
			public const string DeviceNo = "DeviceNo";
			public const string DeviceTypeID = "DeviceTypeID";
			public const string DeviceName = "DeviceName";
			public const string DeviceGroupID = "DeviceGroupID";
			public const string ModelNo = "ModelNo";
			public const string DeviceTypeName = "DeviceTypeName";
			public const string DeviceGroupName = "DeviceGroupName";
			public const string TaskContent = "TaskContent";
			public const string TaskAcceptTime = "TaskAcceptTime";
            
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
    			 {"DeviceNo" , "string:"},
    			 {"DeviceTypeID" , "int:"},
    			 {"DeviceName" , "string:"},
    			 {"DeviceGroupID" , "int:"},
    			 {"ModelNo" , "string:"},
    			 {"DeviceTypeName" , "string:"},
    			 {"DeviceGroupName" , "string:"},
    			 {"TaskContent" , "string:"},
    			 {"TaskAcceptTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
