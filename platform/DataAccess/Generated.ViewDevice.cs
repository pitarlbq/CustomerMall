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
	/// This object represents the properties and methods of a ViewDevice.
	/// </summary>
	[Serializable()]
	public partial class ViewDevice 
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
		[DataObjectField(false, false, false)]
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
		[DataObjectField(false, false, false)]
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
		private string _deviceLevel = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DeviceLevel
		{
			[DebuggerStepThrough()]
			get { return this._deviceLevel; }
            protected set { this._deviceLevel = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _repairCompany = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RepairCompany
		{
			[DebuggerStepThrough()]
			get { return this._repairCompany; }
            protected set { this._repairCompany = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _supplier = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Supplier
		{
			[DebuggerStepThrough()]
			get { return this._supplier; }
            protected set { this._supplier = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _repairUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RepairUserID
		{
			[DebuggerStepThrough()]
			get { return this._repairUserID; }
            protected set { this._repairUserID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _checkUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CheckUserID
		{
			[DebuggerStepThrough()]
			get { return this._checkUserID; }
            protected set { this._checkUserID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _firstRepairDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime FirstRepairDate
		{
			[DebuggerStepThrough()]
			get { return this._firstRepairDate; }
            protected set { this._firstRepairDate = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _firstCheckDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime FirstCheckDate
		{
			[DebuggerStepThrough()]
			get { return this._firstCheckDate; }
            protected set { this._firstCheckDate = value;}
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
            protected set { this._addTime = value;}
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
            protected set { this._addMan = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _deviceStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int DeviceStatus
		{
			[DebuggerStepThrough()]
			get { return this._deviceStatus; }
            protected set { this._deviceStatus = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _repairType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RepairType
		{
			[DebuggerStepThrough()]
			get { return this._repairType; }
            protected set { this._repairType = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _supplierMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SupplierMan
		{
			[DebuggerStepThrough()]
			get { return this._supplierMan; }
            protected set { this._supplierMan = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _supplierPhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SupplierPhone
		{
			[DebuggerStepThrough()]
			get { return this._supplierPhone; }
            protected set { this._supplierPhone = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _repairUserPhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RepairUserPhone
		{
			[DebuggerStepThrough()]
			get { return this._repairUserPhone; }
            protected set { this._repairUserPhone = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _repairCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RepairCount
		{
			[DebuggerStepThrough()]
			get { return this._repairCount; }
            protected set { this._repairCount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _repairCycle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RepairCycle
		{
			[DebuggerStepThrough()]
			get { return this._repairCycle; }
            protected set { this._repairCycle = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _lastRepairDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime LastRepairDate
		{
			[DebuggerStepThrough()]
			get { return this._lastRepairDate; }
            protected set { this._lastRepairDate = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _thisRepairDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ThisRepairDate
		{
			[DebuggerStepThrough()]
			get { return this._thisRepairDate; }
            protected set { this._thisRepairDate = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _checkCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CheckCount
		{
			[DebuggerStepThrough()]
			get { return this._checkCount; }
            protected set { this._checkCount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _checkCycle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CheckCycle
		{
			[DebuggerStepThrough()]
			get { return this._checkCycle; }
            protected set { this._checkCycle = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _lastCheckDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime LastCheckDate
		{
			[DebuggerStepThrough()]
			get { return this._lastCheckDate; }
            protected set { this._lastCheckDate = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _thisCheckDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ThisCheckDate
		{
			[DebuggerStepThrough()]
			get { return this._thisCheckDate; }
            protected set { this._thisCheckDate = value;}
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
		private string _loginName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string LoginName
		{
			[DebuggerStepThrough()]
			get { return this._loginName; }
            protected set { this._loginName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _realName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RealName
		{
			[DebuggerStepThrough()]
			get { return this._realName; }
            protected set { this._realName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _remark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Remark
		{
			[DebuggerStepThrough()]
			get { return this._remark; }
            protected set { this._remark = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _repairRealName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RepairRealName
		{
			[DebuggerStepThrough()]
			get { return this._repairRealName; }
            protected set { this._repairRealName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _checkRealName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CheckRealName
		{
			[DebuggerStepThrough()]
			get { return this._checkRealName; }
            protected set { this._checkRealName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _purchaseDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime PurchaseDate
		{
			[DebuggerStepThrough()]
			get { return this._purchaseDate; }
            protected set { this._purchaseDate = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _guaranteeDate = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string GuaranteeDate
		{
			[DebuggerStepThrough()]
			get { return this._guaranteeDate; }
            protected set { this._guaranteeDate = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _guaranteeEndDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime GuaranteeEndDate
		{
			[DebuggerStepThrough()]
			get { return this._guaranteeEndDate; }
            protected set { this._guaranteeEndDate = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _taskTypeName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TaskTypeName
		{
			[DebuggerStepThrough()]
			get { return this._taskTypeName; }
            protected set { this._taskTypeName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _projectName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProjectName
		{
			[DebuggerStepThrough()]
			get { return this._projectName; }
            protected set { this._projectName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _projectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProjectID
		{
			[DebuggerStepThrough()]
			get { return this._projectID; }
            protected set { this._projectID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _locationPlace = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string LocationPlace
		{
			[DebuggerStepThrough()]
			get { return this._locationPlace; }
            protected set { this._locationPlace = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewDevice() { }
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
	[ViewDevice].[ID],
	[ViewDevice].[DeviceNo],
	[ViewDevice].[DeviceTypeID],
	[ViewDevice].[DeviceName],
	[ViewDevice].[DeviceGroupID],
	[ViewDevice].[ModelNo],
	[ViewDevice].[DeviceLevel],
	[ViewDevice].[RepairCompany],
	[ViewDevice].[Supplier],
	[ViewDevice].[RepairUserID],
	[ViewDevice].[CheckUserID],
	[ViewDevice].[FirstRepairDate],
	[ViewDevice].[FirstCheckDate],
	[ViewDevice].[AddTime],
	[ViewDevice].[AddMan],
	[ViewDevice].[DeviceStatus],
	[ViewDevice].[RepairType],
	[ViewDevice].[SupplierMan],
	[ViewDevice].[SupplierPhone],
	[ViewDevice].[RepairUserPhone],
	[ViewDevice].[RepairCount],
	[ViewDevice].[RepairCycle],
	[ViewDevice].[LastRepairDate],
	[ViewDevice].[ThisRepairDate],
	[ViewDevice].[CheckCount],
	[ViewDevice].[CheckCycle],
	[ViewDevice].[LastCheckDate],
	[ViewDevice].[ThisCheckDate],
	[ViewDevice].[DeviceTypeName],
	[ViewDevice].[DeviceGroupName],
	[ViewDevice].[LoginName],
	[ViewDevice].[RealName],
	[ViewDevice].[Remark],
	[ViewDevice].[RepairRealName],
	[ViewDevice].[CheckRealName],
	[ViewDevice].[PurchaseDate],
	[ViewDevice].[GuaranteeDate],
	[ViewDevice].[GuaranteeEndDate],
	[ViewDevice].[TaskTypeName],
	[ViewDevice].[ProjectName],
	[ViewDevice].[ProjectID],
	[ViewDevice].[LocationPlace]
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
                return "ViewDevice";
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
		/// Gets a collection ViewDevice objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewDevice objects.</returns>
		public static EntityList<ViewDevice> GetViewDevices()
		{
			string commandText = @"
SELECT " + ViewDevice.SelectFieldList + "FROM [dbo].[ViewDevice] " + ViewDevice.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewDevice>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewDevice objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewDevice objects.</returns>
        public static EntityList<ViewDevice> GetViewDevices(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewDevice>(SelectFieldList, "FROM [dbo].[ViewDevice]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewDevice objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewDevice objects.</returns>
        public static EntityList<ViewDevice> GetViewDevices(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewDevice>(SelectFieldList, "FROM [dbo].[ViewDevice]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewDevice objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewDeviceCount()
        {
            return GetViewDeviceCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewDevice objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewDeviceCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewDevice] " + where;

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
		/// Gets a collection ViewDevice objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewDevice objects.</returns>
		protected static EntityList<ViewDevice> GetViewDevices(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewDevices(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewDevice objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewDevice objects.</returns>
		protected static EntityList<ViewDevice> GetViewDevices(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewDevices(string.Empty, where, parameters, ViewDevice.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewDevice objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewDevice objects.</returns>
		protected static EntityList<ViewDevice> GetViewDevices(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewDevices(prefix, where, parameters, ViewDevice.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewDevice objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewDevice objects.</returns>
		protected static EntityList<ViewDevice> GetViewDevices(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewDevices(string.Empty, where, parameters, ViewDevice.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewDevice objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewDevice objects.</returns>
		protected static EntityList<ViewDevice> GetViewDevices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewDevices(prefix, where, parameters, ViewDevice.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewDevice objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewDevice objects.</returns>
		protected static EntityList<ViewDevice> GetViewDevices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewDevice.SelectFieldList + "FROM [dbo].[ViewDevice] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewDevice>(reader);
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
        protected static EntityList<ViewDevice> GetViewDevices(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewDevice>(SelectFieldList, "FROM [dbo].[ViewDevice] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewDeviceProperties
		{
			public const string ID = "ID";
			public const string DeviceNo = "DeviceNo";
			public const string DeviceTypeID = "DeviceTypeID";
			public const string DeviceName = "DeviceName";
			public const string DeviceGroupID = "DeviceGroupID";
			public const string ModelNo = "ModelNo";
			public const string DeviceLevel = "DeviceLevel";
			public const string RepairCompany = "RepairCompany";
			public const string Supplier = "Supplier";
			public const string RepairUserID = "RepairUserID";
			public const string CheckUserID = "CheckUserID";
			public const string FirstRepairDate = "FirstRepairDate";
			public const string FirstCheckDate = "FirstCheckDate";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string DeviceStatus = "DeviceStatus";
			public const string RepairType = "RepairType";
			public const string SupplierMan = "SupplierMan";
			public const string SupplierPhone = "SupplierPhone";
			public const string RepairUserPhone = "RepairUserPhone";
			public const string RepairCount = "RepairCount";
			public const string RepairCycle = "RepairCycle";
			public const string LastRepairDate = "LastRepairDate";
			public const string ThisRepairDate = "ThisRepairDate";
			public const string CheckCount = "CheckCount";
			public const string CheckCycle = "CheckCycle";
			public const string LastCheckDate = "LastCheckDate";
			public const string ThisCheckDate = "ThisCheckDate";
			public const string DeviceTypeName = "DeviceTypeName";
			public const string DeviceGroupName = "DeviceGroupName";
			public const string LoginName = "LoginName";
			public const string RealName = "RealName";
			public const string Remark = "Remark";
			public const string RepairRealName = "RepairRealName";
			public const string CheckRealName = "CheckRealName";
			public const string PurchaseDate = "PurchaseDate";
			public const string GuaranteeDate = "GuaranteeDate";
			public const string GuaranteeEndDate = "GuaranteeEndDate";
			public const string TaskTypeName = "TaskTypeName";
			public const string ProjectName = "ProjectName";
			public const string ProjectID = "ProjectID";
			public const string LocationPlace = "LocationPlace";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"DeviceNo" , "string:"},
    			 {"DeviceTypeID" , "int:"},
    			 {"DeviceName" , "string:"},
    			 {"DeviceGroupID" , "int:"},
    			 {"ModelNo" , "string:"},
    			 {"DeviceLevel" , "string:"},
    			 {"RepairCompany" , "string:"},
    			 {"Supplier" , "string:"},
    			 {"RepairUserID" , "int:"},
    			 {"CheckUserID" , "int:"},
    			 {"FirstRepairDate" , "DateTime:"},
    			 {"FirstCheckDate" , "DateTime:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"DeviceStatus" , "int:"},
    			 {"RepairType" , "string:"},
    			 {"SupplierMan" , "string:"},
    			 {"SupplierPhone" , "string:"},
    			 {"RepairUserPhone" , "string:"},
    			 {"RepairCount" , "int:"},
    			 {"RepairCycle" , "string:"},
    			 {"LastRepairDate" , "DateTime:"},
    			 {"ThisRepairDate" , "DateTime:"},
    			 {"CheckCount" , "int:"},
    			 {"CheckCycle" , "string:"},
    			 {"LastCheckDate" , "DateTime:"},
    			 {"ThisCheckDate" , "DateTime:"},
    			 {"DeviceTypeName" , "string:"},
    			 {"DeviceGroupName" , "string:"},
    			 {"LoginName" , "string:"},
    			 {"RealName" , "string:"},
    			 {"Remark" , "string:"},
    			 {"RepairRealName" , "string:"},
    			 {"CheckRealName" , "string:"},
    			 {"PurchaseDate" , "DateTime:"},
    			 {"GuaranteeDate" , "string:"},
    			 {"GuaranteeEndDate" , "DateTime:"},
    			 {"TaskTypeName" , "string:"},
    			 {"ProjectName" , "string:"},
    			 {"ProjectID" , "int:"},
    			 {"LocationPlace" , "string:"},
            };
		}
		#endregion
	}
}
