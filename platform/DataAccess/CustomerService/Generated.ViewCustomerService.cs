﻿using System;
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
	/// This object represents the properties and methods of a ViewCustomerService.
	/// </summary>
	[Serializable()]
	public partial class ViewCustomerService 
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
		private string _serviceFullName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceFullName
		{
			[DebuggerStepThrough()]
			get { return this._serviceFullName; }
            protected set { this._serviceFullName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _serviceAccpetMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceAccpetMan
		{
			[DebuggerStepThrough()]
			get { return this._serviceAccpetMan; }
            protected set { this._serviceAccpetMan = value;}
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
		private int _serviceTypeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ServiceTypeID
		{
			[DebuggerStepThrough()]
			get { return this._serviceTypeID; }
            protected set { this._serviceTypeID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _serviceTypeName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceTypeName
		{
			[DebuggerStepThrough()]
			get { return this._serviceTypeName; }
            protected set { this._serviceTypeName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddUserName
		{
			[DebuggerStepThrough()]
			get { return this._addUserName; }
            protected set { this._addUserName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _startTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime StartTime
		{
			[DebuggerStepThrough()]
			get { return this._startTime; }
            protected set { this._startTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _serviceArea = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceArea
		{
			[DebuggerStepThrough()]
			get { return this._serviceArea; }
            protected set { this._serviceArea = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _serviceNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceNumber
		{
			[DebuggerStepThrough()]
			get { return this._serviceNumber; }
            protected set { this._serviceNumber = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addCustomerName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddCustomerName
		{
			[DebuggerStepThrough()]
			get { return this._addCustomerName; }
            protected set { this._addCustomerName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addCallPhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddCallPhone
		{
			[DebuggerStepThrough()]
			get { return this._addCallPhone; }
            protected set { this._addCallPhone = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _serviceContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceContent
		{
			[DebuggerStepThrough()]
			get { return this._serviceContent; }
            protected set { this._serviceContent = value;}
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
		private int _serviceStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ServiceStatus
		{
			[DebuggerStepThrough()]
			get { return this._serviceStatus; }
            protected set { this._serviceStatus = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _banJieTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime BanJieTime
		{
			[DebuggerStepThrough()]
			get { return this._banJieTime; }
            protected set { this._banJieTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _banJieNote = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BanJieNote
		{
			[DebuggerStepThrough()]
			get { return this._banJieNote; }
            protected set { this._banJieNote = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _serviceAccpetManID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceAccpetManID
		{
			[DebuggerStepThrough()]
			get { return this._serviceAccpetManID; }
            protected set { this._serviceAccpetManID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _serviceAppointTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ServiceAppointTime
		{
			[DebuggerStepThrough()]
			get { return this._serviceAppointTime; }
            protected set { this._serviceAppointTime = value;}
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
		private int _orderNumberID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OrderNumberID
		{
			[DebuggerStepThrough()]
			get { return this._orderNumberID; }
            protected set { this._orderNumberID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chuliNote = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChuliNote
		{
			[DebuggerStepThrough()]
			get { return this._chuliNote; }
            protected set { this._chuliNote = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _chuliDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ChuliDate
		{
			[DebuggerStepThrough()]
			get { return this._chuliDate; }
            protected set { this._chuliDate = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _huiFangNote = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string HuiFangNote
		{
			[DebuggerStepThrough()]
			get { return this._huiFangNote; }
            protected set { this._huiFangNote = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _huiFangTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime HuiFangTime
		{
			[DebuggerStepThrough()]
			get { return this._huiFangTime; }
            protected set { this._huiFangTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _handelFee = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string HandelFee
		{
			[DebuggerStepThrough()]
			get { return this._handelFee; }
            protected set { this._handelFee = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalFee = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalFee
		{
			[DebuggerStepThrough()]
			get { return this._totalFee; }
            protected set { this._totalFee = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _balanceStatus = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BalanceStatus
		{
			[DebuggerStepThrough()]
			get { return this._balanceStatus; }
            protected set { this._balanceStatus = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _cKProductOutSumaryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CKProductOutSumaryID
		{
			[DebuggerStepThrough()]
			get { return this._cKProductOutSumaryID; }
            protected set { this._cKProductOutSumaryID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isRequireCost = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsRequireCost
		{
			[DebuggerStepThrough()]
			get { return this._isRequireCost; }
            protected set { this._isRequireCost = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isRequireProduct = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsRequireProduct
		{
			[DebuggerStepThrough()]
			get { return this._isRequireProduct; }
            protected set { this._isRequireProduct = value;}
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
            protected set { this._isAPPShow = value;}
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
            protected set { this._isAPPSend = value;}
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
            protected set { this._aPPSendTime = value;}
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
            protected set { this._aPPSendResult = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _wechatServiceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int WechatServiceID
		{
			[DebuggerStepThrough()]
			get { return this._wechatServiceID; }
            protected set { this._wechatServiceID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _acceptTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime AcceptTime
		{
			[DebuggerStepThrough()]
			get { return this._acceptTime; }
            protected set { this._acceptTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _taskType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TaskType
		{
			[DebuggerStepThrough()]
			get { return this._taskType; }
            protected set { this._taskType = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _serviceFrom = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceFrom
		{
			[DebuggerStepThrough()]
			get { return this._serviceFrom; }
            protected set { this._serviceFrom = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _openID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OpenID
		{
			[DebuggerStepThrough()]
			get { return this._openID; }
            protected set { this._openID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _wechatAddUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int WechatAddUserID
		{
			[DebuggerStepThrough()]
			get { return this._wechatAddUserID; }
            protected set { this._wechatAddUserID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _project_Name = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Project_Name
		{
			[DebuggerStepThrough()]
			get { return this._project_Name; }
            protected set { this._project_Name = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _departmentID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int DepartmentID
		{
			[DebuggerStepThrough()]
			get { return this._departmentID; }
            protected set { this._departmentID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isSuggestion = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsSuggestion
		{
			[DebuggerStepThrough()]
			get { return this._isSuggestion; }
            protected set { this._isSuggestion = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _publicProjectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PublicProjectID
		{
			[DebuggerStepThrough()]
			get { return this._publicProjectID; }
            protected set { this._publicProjectID = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewCustomerService() { }
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
	[ViewCustomerService].[ID],
	[ViewCustomerService].[ProjectID],
	[ViewCustomerService].[ServiceFullName],
	[ViewCustomerService].[ServiceAccpetMan],
	[ViewCustomerService].[ProjectName],
	[ViewCustomerService].[ServiceTypeID],
	[ViewCustomerService].[ServiceTypeName],
	[ViewCustomerService].[AddUserName],
	[ViewCustomerService].[StartTime],
	[ViewCustomerService].[ServiceArea],
	[ViewCustomerService].[ServiceNumber],
	[ViewCustomerService].[AddCustomerName],
	[ViewCustomerService].[AddCallPhone],
	[ViewCustomerService].[ServiceContent],
	[ViewCustomerService].[AddTime],
	[ViewCustomerService].[ServiceStatus],
	[ViewCustomerService].[BanJieTime],
	[ViewCustomerService].[BanJieNote],
	[ViewCustomerService].[ServiceAccpetManID],
	[ViewCustomerService].[ServiceAppointTime],
	[ViewCustomerService].[AddMan],
	[ViewCustomerService].[OrderNumberID],
	[ViewCustomerService].[ChuliNote],
	[ViewCustomerService].[ChuliDate],
	[ViewCustomerService].[HuiFangNote],
	[ViewCustomerService].[HuiFangTime],
	[ViewCustomerService].[HandelFee],
	[ViewCustomerService].[TotalFee],
	[ViewCustomerService].[BalanceStatus],
	[ViewCustomerService].[CKProductOutSumaryID],
	[ViewCustomerService].[IsRequireCost],
	[ViewCustomerService].[IsRequireProduct],
	[ViewCustomerService].[IsAPPShow],
	[ViewCustomerService].[IsAPPSend],
	[ViewCustomerService].[APPSendTime],
	[ViewCustomerService].[APPSendResult],
	[ViewCustomerService].[WechatServiceID],
	[ViewCustomerService].[AcceptTime],
	[ViewCustomerService].[TaskType],
	[ViewCustomerService].[ServiceFrom],
	[ViewCustomerService].[OpenID],
	[ViewCustomerService].[WechatAddUserID],
	[ViewCustomerService].[Project_Name],
	[ViewCustomerService].[DepartmentID],
	[ViewCustomerService].[IsSuggestion],
	[ViewCustomerService].[PublicProjectID]
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
                return "ViewCustomerService";
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
		/// Gets a collection ViewCustomerService objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewCustomerService objects.</returns>
		public static EntityList<ViewCustomerService> GetViewCustomerServices()
		{
			string commandText = @"
SELECT " + ViewCustomerService.SelectFieldList + "FROM [dbo].[ViewCustomerService] " + ViewCustomerService.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewCustomerService>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewCustomerService objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewCustomerService objects.</returns>
        public static EntityList<ViewCustomerService> GetViewCustomerServices(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCustomerService>(SelectFieldList, "FROM [dbo].[ViewCustomerService]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewCustomerService objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewCustomerService objects.</returns>
        public static EntityList<ViewCustomerService> GetViewCustomerServices(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCustomerService>(SelectFieldList, "FROM [dbo].[ViewCustomerService]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewCustomerService objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewCustomerServiceCount()
        {
            return GetViewCustomerServiceCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewCustomerService objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewCustomerServiceCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewCustomerService] " + where;

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
		/// Gets a collection ViewCustomerService objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewCustomerService objects.</returns>
		protected static EntityList<ViewCustomerService> GetViewCustomerServices(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCustomerServices(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewCustomerService objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewCustomerService objects.</returns>
		protected static EntityList<ViewCustomerService> GetViewCustomerServices(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCustomerServices(string.Empty, where, parameters, ViewCustomerService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCustomerService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewCustomerService objects.</returns>
		protected static EntityList<ViewCustomerService> GetViewCustomerServices(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCustomerServices(prefix, where, parameters, ViewCustomerService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCustomerService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewCustomerService objects.</returns>
		protected static EntityList<ViewCustomerService> GetViewCustomerServices(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewCustomerServices(string.Empty, where, parameters, ViewCustomerService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCustomerService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewCustomerService objects.</returns>
		protected static EntityList<ViewCustomerService> GetViewCustomerServices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewCustomerServices(prefix, where, parameters, ViewCustomerService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCustomerService objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewCustomerService objects.</returns>
		protected static EntityList<ViewCustomerService> GetViewCustomerServices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewCustomerService.SelectFieldList + "FROM [dbo].[ViewCustomerService] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewCustomerService>(reader);
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
        protected static EntityList<ViewCustomerService> GetViewCustomerServices(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCustomerService>(SelectFieldList, "FROM [dbo].[ViewCustomerService] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewCustomerServiceProperties
		{
			public const string ID = "ID";
			public const string ProjectID = "ProjectID";
			public const string ServiceFullName = "ServiceFullName";
			public const string ServiceAccpetMan = "ServiceAccpetMan";
			public const string ProjectName = "ProjectName";
			public const string ServiceTypeID = "ServiceTypeID";
			public const string ServiceTypeName = "ServiceTypeName";
			public const string AddUserName = "AddUserName";
			public const string StartTime = "StartTime";
			public const string ServiceArea = "ServiceArea";
			public const string ServiceNumber = "ServiceNumber";
			public const string AddCustomerName = "AddCustomerName";
			public const string AddCallPhone = "AddCallPhone";
			public const string ServiceContent = "ServiceContent";
			public const string AddTime = "AddTime";
			public const string ServiceStatus = "ServiceStatus";
			public const string BanJieTime = "BanJieTime";
			public const string BanJieNote = "BanJieNote";
			public const string ServiceAccpetManID = "ServiceAccpetManID";
			public const string ServiceAppointTime = "ServiceAppointTime";
			public const string AddMan = "AddMan";
			public const string OrderNumberID = "OrderNumberID";
			public const string ChuliNote = "ChuliNote";
			public const string ChuliDate = "ChuliDate";
			public const string HuiFangNote = "HuiFangNote";
			public const string HuiFangTime = "HuiFangTime";
			public const string HandelFee = "HandelFee";
			public const string TotalFee = "TotalFee";
			public const string BalanceStatus = "BalanceStatus";
			public const string CKProductOutSumaryID = "CKProductOutSumaryID";
			public const string IsRequireCost = "IsRequireCost";
			public const string IsRequireProduct = "IsRequireProduct";
			public const string IsAPPShow = "IsAPPShow";
			public const string IsAPPSend = "IsAPPSend";
			public const string APPSendTime = "APPSendTime";
			public const string APPSendResult = "APPSendResult";
			public const string WechatServiceID = "WechatServiceID";
			public const string AcceptTime = "AcceptTime";
			public const string TaskType = "TaskType";
			public const string ServiceFrom = "ServiceFrom";
			public const string OpenID = "OpenID";
			public const string WechatAddUserID = "WechatAddUserID";
			public const string Project_Name = "Project_Name";
			public const string DepartmentID = "DepartmentID";
			public const string IsSuggestion = "IsSuggestion";
			public const string PublicProjectID = "PublicProjectID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProjectID" , "int:"},
    			 {"ServiceFullName" , "string:"},
    			 {"ServiceAccpetMan" , "string:"},
    			 {"ProjectName" , "string:"},
    			 {"ServiceTypeID" , "int:"},
    			 {"ServiceTypeName" , "string:"},
    			 {"AddUserName" , "string:"},
    			 {"StartTime" , "DateTime:"},
    			 {"ServiceArea" , "string:"},
    			 {"ServiceNumber" , "string:"},
    			 {"AddCustomerName" , "string:"},
    			 {"AddCallPhone" , "string:"},
    			 {"ServiceContent" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"ServiceStatus" , "int:"},
    			 {"BanJieTime" , "DateTime:"},
    			 {"BanJieNote" , "string:"},
    			 {"ServiceAccpetManID" , "string:"},
    			 {"ServiceAppointTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"OrderNumberID" , "int:"},
    			 {"ChuliNote" , "string:"},
    			 {"ChuliDate" , "DateTime:"},
    			 {"HuiFangNote" , "string:"},
    			 {"HuiFangTime" , "DateTime:"},
    			 {"HandelFee" , "string:"},
    			 {"TotalFee" , "decimal:"},
    			 {"BalanceStatus" , "string:"},
    			 {"CKProductOutSumaryID" , "int:"},
    			 {"IsRequireCost" , "bool:"},
    			 {"IsRequireProduct" , "bool:"},
    			 {"IsAPPShow" , "bool:"},
    			 {"IsAPPSend" , "bool:"},
    			 {"APPSendTime" , "DateTime:"},
    			 {"APPSendResult" , "string:"},
    			 {"WechatServiceID" , "int:"},
    			 {"AcceptTime" , "DateTime:"},
    			 {"TaskType" , "int:"},
    			 {"ServiceFrom" , "string:"},
    			 {"OpenID" , "string:"},
    			 {"WechatAddUserID" , "int:"},
    			 {"Project_Name" , "string:"},
    			 {"DepartmentID" , "int:"},
    			 {"IsSuggestion" , "bool:"},
    			 {"PublicProjectID" , "int:"},
            };
		}
		#endregion
	}
}
