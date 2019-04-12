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
	/// This object represents the properties and methods of a ViewCKProudctInDetail.
	/// </summary>
	[Serializable()]
	public partial class ViewCKProudctInDetail 
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
		private int _inSummaryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int InSummaryID
		{
			[DebuggerStepThrough()]
			get { return this._inSummaryID; }
            protected set { this._inSummaryID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _unitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal UnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._unitPrice; }
            protected set { this._unitPrice = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _inTotalCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int InTotalCount
		{
			[DebuggerStepThrough()]
			get { return this._inTotalCount; }
            protected set { this._inTotalCount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _inTotalPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal InTotalPrice
		{
			[DebuggerStepThrough()]
			get { return this._inTotalPrice; }
            protected set { this._inTotalPrice = value;}
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
            protected set { this._productID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _productName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProductName
		{
			[DebuggerStepThrough()]
			get { return this._productName; }
            protected set { this._productName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _productNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProductNumber
		{
			[DebuggerStepThrough()]
			get { return this._productNumber; }
            protected set { this._productNumber = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _unit = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Unit
		{
			[DebuggerStepThrough()]
			get { return this._unit; }
            protected set { this._unit = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _modelNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ModelNumber
		{
			[DebuggerStepThrough()]
			get { return this._modelNumber; }
            protected set { this._modelNumber = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _inventoryMax = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int InventoryMax
		{
			[DebuggerStepThrough()]
			get { return this._inventoryMax; }
            protected set { this._inventoryMax = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _inventoryMin = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int InventoryMin
		{
			[DebuggerStepThrough()]
			get { return this._inventoryMin; }
            protected set { this._inventoryMin = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _serviceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ServiceID
		{
			[DebuggerStepThrough()]
			get { return this._serviceID; }
            protected set { this._serviceID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _orderNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OrderNumber
		{
			[DebuggerStepThrough()]
			get { return this._orderNumber; }
            protected set { this._orderNumber = value;}
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
		private DateTime _inTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime InTime
		{
			[DebuggerStepThrough()]
			get { return this._inTime; }
            protected set { this._inTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _contractID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ContractID
		{
			[DebuggerStepThrough()]
			get { return this._contractID; }
            protected set { this._contractID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _warehouseName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string WarehouseName
		{
			[DebuggerStepThrough()]
			get { return this._warehouseName; }
            protected set { this._warehouseName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _categoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CategoryName
		{
			[DebuggerStepThrough()]
			get { return this._categoryName; }
            protected set { this._categoryName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _inCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int InCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._inCategoryID; }
            protected set { this._inCategoryID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _inCategoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string InCategoryName
		{
			[DebuggerStepThrough()]
			get { return this._inCategoryName; }
            protected set { this._inCategoryName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _belongTeamName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BelongTeamName
		{
			[DebuggerStepThrough()]
			get { return this._belongTeamName; }
            protected set { this._belongTeamName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _belongDepartmentID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int BelongDepartmentID
		{
			[DebuggerStepThrough()]
			get { return this._belongDepartmentID; }
            protected set { this._belongDepartmentID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _departmentName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DepartmentName
		{
			[DebuggerStepThrough()]
			get { return this._departmentName; }
            protected set { this._departmentName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contractName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractName
		{
			[DebuggerStepThrough()]
			get { return this._contractName; }
            protected set { this._contractName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _cKCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CKCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._cKCategoryID; }
            protected set { this._cKCategoryID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _productCategoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProductCategoryName
		{
			[DebuggerStepThrough()]
			get { return this._productCategoryName; }
            protected set { this._productCategoryName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _totalOutCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TotalOutCount
		{
			[DebuggerStepThrough()]
			get { return this._totalOutCount; }
            protected set { this._totalOutCount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _approveStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ApproveStatus
		{
			[DebuggerStepThrough()]
			get { return this._approveStatus; }
            protected set { this._approveStatus = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _approveYesTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ApproveYesTime
		{
			[DebuggerStepThrough()]
			get { return this._approveYesTime; }
            protected set { this._approveYesTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _approveNoTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ApproveNoTime
		{
			[DebuggerStepThrough()]
			get { return this._approveNoTime; }
            protected set { this._approveNoTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveMan
		{
			[DebuggerStepThrough()]
			get { return this._approveMan; }
            protected set { this._approveMan = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sysProductOrderNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SysProductOrderNumber
		{
			[DebuggerStepThrough()]
			get { return this._sysProductOrderNumber; }
            protected set { this._sysProductOrderNumber = value;}
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
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewCKProudctInDetail() { }
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
	[ViewCKProudctInDetail].[ID],
	[ViewCKProudctInDetail].[InSummaryID],
	[ViewCKProudctInDetail].[UnitPrice],
	[ViewCKProudctInDetail].[InTotalCount],
	[ViewCKProudctInDetail].[InTotalPrice],
	[ViewCKProudctInDetail].[AddTime],
	[ViewCKProudctInDetail].[AddMan],
	[ViewCKProudctInDetail].[ProductID],
	[ViewCKProudctInDetail].[ProductName],
	[ViewCKProudctInDetail].[ProductNumber],
	[ViewCKProudctInDetail].[Unit],
	[ViewCKProudctInDetail].[ModelNumber],
	[ViewCKProudctInDetail].[InventoryMax],
	[ViewCKProudctInDetail].[InventoryMin],
	[ViewCKProudctInDetail].[ServiceID],
	[ViewCKProudctInDetail].[OrderNumber],
	[ViewCKProudctInDetail].[AddUserName],
	[ViewCKProudctInDetail].[InTime],
	[ViewCKProudctInDetail].[ContractID],
	[ViewCKProudctInDetail].[WarehouseName],
	[ViewCKProudctInDetail].[CategoryName],
	[ViewCKProudctInDetail].[InCategoryID],
	[ViewCKProudctInDetail].[InCategoryName],
	[ViewCKProudctInDetail].[BelongTeamName],
	[ViewCKProudctInDetail].[BelongDepartmentID],
	[ViewCKProudctInDetail].[DepartmentName],
	[ViewCKProudctInDetail].[ContractName],
	[ViewCKProudctInDetail].[CKCategoryID],
	[ViewCKProudctInDetail].[ProductCategoryName],
	[ViewCKProudctInDetail].[TotalOutCount],
	[ViewCKProudctInDetail].[ApproveStatus],
	[ViewCKProudctInDetail].[ApproveYesTime],
	[ViewCKProudctInDetail].[ApproveNoTime],
	[ViewCKProudctInDetail].[ApproveMan],
	[ViewCKProudctInDetail].[SysProductOrderNumber],
	[ViewCKProudctInDetail].[Remark]
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
                return "ViewCKProudctInDetail";
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
		/// Gets a collection ViewCKProudctInDetail objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewCKProudctInDetail objects.</returns>
		public static EntityList<ViewCKProudctInDetail> GetViewCKProudctInDetails()
		{
			string commandText = @"
SELECT " + ViewCKProudctInDetail.SelectFieldList + "FROM [dbo].[ViewCKProudctInDetail] " + ViewCKProudctInDetail.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewCKProudctInDetail>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewCKProudctInDetail objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewCKProudctInDetail objects.</returns>
        public static EntityList<ViewCKProudctInDetail> GetViewCKProudctInDetails(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCKProudctInDetail>(SelectFieldList, "FROM [dbo].[ViewCKProudctInDetail]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewCKProudctInDetail objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewCKProudctInDetail objects.</returns>
        public static EntityList<ViewCKProudctInDetail> GetViewCKProudctInDetails(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCKProudctInDetail>(SelectFieldList, "FROM [dbo].[ViewCKProudctInDetail]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewCKProudctInDetail objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewCKProudctInDetailCount()
        {
            return GetViewCKProudctInDetailCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewCKProudctInDetail objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewCKProudctInDetailCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewCKProudctInDetail] " + where;

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
		/// Gets a collection ViewCKProudctInDetail objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewCKProudctInDetail objects.</returns>
		protected static EntityList<ViewCKProudctInDetail> GetViewCKProudctInDetails(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCKProudctInDetails(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProudctInDetail objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewCKProudctInDetail objects.</returns>
		protected static EntityList<ViewCKProudctInDetail> GetViewCKProudctInDetails(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCKProudctInDetails(string.Empty, where, parameters, ViewCKProudctInDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProudctInDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewCKProudctInDetail objects.</returns>
		protected static EntityList<ViewCKProudctInDetail> GetViewCKProudctInDetails(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCKProudctInDetails(prefix, where, parameters, ViewCKProudctInDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProudctInDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewCKProudctInDetail objects.</returns>
		protected static EntityList<ViewCKProudctInDetail> GetViewCKProudctInDetails(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewCKProudctInDetails(string.Empty, where, parameters, ViewCKProudctInDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProudctInDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewCKProudctInDetail objects.</returns>
		protected static EntityList<ViewCKProudctInDetail> GetViewCKProudctInDetails(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewCKProudctInDetails(prefix, where, parameters, ViewCKProudctInDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProudctInDetail objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewCKProudctInDetail objects.</returns>
		protected static EntityList<ViewCKProudctInDetail> GetViewCKProudctInDetails(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewCKProudctInDetail.SelectFieldList + "FROM [dbo].[ViewCKProudctInDetail] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewCKProudctInDetail>(reader);
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
        protected static EntityList<ViewCKProudctInDetail> GetViewCKProudctInDetails(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCKProudctInDetail>(SelectFieldList, "FROM [dbo].[ViewCKProudctInDetail] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewCKProudctInDetailProperties
		{
			public const string ID = "ID";
			public const string InSummaryID = "InSummaryID";
			public const string UnitPrice = "UnitPrice";
			public const string InTotalCount = "InTotalCount";
			public const string InTotalPrice = "InTotalPrice";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string ProductID = "ProductID";
			public const string ProductName = "ProductName";
			public const string ProductNumber = "ProductNumber";
			public const string Unit = "Unit";
			public const string ModelNumber = "ModelNumber";
			public const string InventoryMax = "InventoryMax";
			public const string InventoryMin = "InventoryMin";
			public const string ServiceID = "ServiceID";
			public const string OrderNumber = "OrderNumber";
			public const string AddUserName = "AddUserName";
			public const string InTime = "InTime";
			public const string ContractID = "ContractID";
			public const string WarehouseName = "WarehouseName";
			public const string CategoryName = "CategoryName";
			public const string InCategoryID = "InCategoryID";
			public const string InCategoryName = "InCategoryName";
			public const string BelongTeamName = "BelongTeamName";
			public const string BelongDepartmentID = "BelongDepartmentID";
			public const string DepartmentName = "DepartmentName";
			public const string ContractName = "ContractName";
			public const string CKCategoryID = "CKCategoryID";
			public const string ProductCategoryName = "ProductCategoryName";
			public const string TotalOutCount = "TotalOutCount";
			public const string ApproveStatus = "ApproveStatus";
			public const string ApproveYesTime = "ApproveYesTime";
			public const string ApproveNoTime = "ApproveNoTime";
			public const string ApproveMan = "ApproveMan";
			public const string SysProductOrderNumber = "SysProductOrderNumber";
			public const string Remark = "Remark";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"InSummaryID" , "int:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"InTotalCount" , "int:"},
    			 {"InTotalPrice" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"ProductID" , "int:"},
    			 {"ProductName" , "string:"},
    			 {"ProductNumber" , "string:"},
    			 {"Unit" , "string:"},
    			 {"ModelNumber" , "string:"},
    			 {"InventoryMax" , "int:"},
    			 {"InventoryMin" , "int:"},
    			 {"ServiceID" , "int:"},
    			 {"OrderNumber" , "string:"},
    			 {"AddUserName" , "string:"},
    			 {"InTime" , "DateTime:"},
    			 {"ContractID" , "int:"},
    			 {"WarehouseName" , "string:"},
    			 {"CategoryName" , "string:"},
    			 {"InCategoryID" , "int:"},
    			 {"InCategoryName" , "string:"},
    			 {"BelongTeamName" , "string:"},
    			 {"BelongDepartmentID" , "int:"},
    			 {"DepartmentName" , "string:"},
    			 {"ContractName" , "string:"},
    			 {"CKCategoryID" , "int:"},
    			 {"ProductCategoryName" , "string:"},
    			 {"TotalOutCount" , "int:"},
    			 {"ApproveStatus" , "int:"},
    			 {"ApproveYesTime" , "DateTime:"},
    			 {"ApproveNoTime" , "DateTime:"},
    			 {"ApproveMan" , "string:"},
    			 {"SysProductOrderNumber" , "string:"},
    			 {"Remark" , "string:"},
            };
		}
		#endregion
	}
}
