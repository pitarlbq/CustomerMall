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
	/// This object represents the properties and methods of a ViewCKProudctOutDetail.
	/// </summary>
	[Serializable()]
	public partial class ViewCKProudctOutDetail 
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
		private int _outSummaryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int OutSummaryID
		{
			[DebuggerStepThrough()]
			get { return this._outSummaryID; }
            protected set { this._outSummaryID = value;}
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
		private int _outTotalCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OutTotalCount
		{
			[DebuggerStepThrough()]
			get { return this._outTotalCount; }
            protected set { this._outTotalCount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _outTotalPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal OutTotalPrice
		{
			[DebuggerStepThrough()]
			get { return this._outTotalPrice; }
            protected set { this._outTotalPrice = value;}
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
		private int _totalInventory = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TotalInventory
		{
			[DebuggerStepThrough()]
			get { return this._totalInventory; }
            protected set { this._totalInventory = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _outTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime OutTime
		{
			[DebuggerStepThrough()]
			get { return this._outTime; }
            protected set { this._outTime = value;}
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
		private int _acceptUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int AcceptUserID
		{
			[DebuggerStepThrough()]
			get { return this._acceptUserID; }
            protected set { this._acceptUserID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _acceptUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AcceptUserName
		{
			[DebuggerStepThrough()]
			get { return this._acceptUserName; }
            protected set { this._acceptUserName = value;}
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
		private decimal _inBasicUnitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal InBasicUnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._inBasicUnitPrice; }
            protected set { this._inBasicUnitPrice = value;}
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
		public ViewCKProudctOutDetail() { }
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
	[ViewCKProudctOutDetail].[ID],
	[ViewCKProudctOutDetail].[OutSummaryID],
	[ViewCKProudctOutDetail].[ProductID],
	[ViewCKProudctOutDetail].[UnitPrice],
	[ViewCKProudctOutDetail].[OutTotalCount],
	[ViewCKProudctOutDetail].[OutTotalPrice],
	[ViewCKProudctOutDetail].[AddTime],
	[ViewCKProudctOutDetail].[AddMan],
	[ViewCKProudctOutDetail].[ProductNumber],
	[ViewCKProudctOutDetail].[ProductName],
	[ViewCKProudctOutDetail].[Unit],
	[ViewCKProudctOutDetail].[ModelNumber],
	[ViewCKProudctOutDetail].[InventoryMin],
	[ViewCKProudctOutDetail].[InventoryMax],
	[ViewCKProudctOutDetail].[TotalInventory],
	[ViewCKProudctOutDetail].[OutTime],
	[ViewCKProudctOutDetail].[OrderNumber],
	[ViewCKProudctOutDetail].[AddUserName],
	[ViewCKProudctOutDetail].[CategoryName],
	[ViewCKProudctOutDetail].[WarehouseName],
	[ViewCKProudctOutDetail].[InCategoryName],
	[ViewCKProudctOutDetail].[InCategoryID],
	[ViewCKProudctOutDetail].[BelongTeamName],
	[ViewCKProudctOutDetail].[BelongDepartmentID],
	[ViewCKProudctOutDetail].[DepartmentName],
	[ViewCKProudctOutDetail].[AcceptUserID],
	[ViewCKProudctOutDetail].[AcceptUserName],
	[ViewCKProudctOutDetail].[CKCategoryID],
	[ViewCKProudctOutDetail].[ProductCategoryName],
	[ViewCKProudctOutDetail].[ApproveStatus],
	[ViewCKProudctOutDetail].[ApproveYesTime],
	[ViewCKProudctOutDetail].[ApproveNoTime],
	[ViewCKProudctOutDetail].[ApproveMan],
	[ViewCKProudctOutDetail].[InBasicUnitPrice],
	[ViewCKProudctOutDetail].[Remark]
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
                return "ViewCKProudctOutDetail";
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
		/// Gets a collection ViewCKProudctOutDetail objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewCKProudctOutDetail objects.</returns>
		public static EntityList<ViewCKProudctOutDetail> GetViewCKProudctOutDetails()
		{
			string commandText = @"
SELECT " + ViewCKProudctOutDetail.SelectFieldList + "FROM [dbo].[ViewCKProudctOutDetail] " + ViewCKProudctOutDetail.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewCKProudctOutDetail>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewCKProudctOutDetail objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewCKProudctOutDetail objects.</returns>
        public static EntityList<ViewCKProudctOutDetail> GetViewCKProudctOutDetails(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCKProudctOutDetail>(SelectFieldList, "FROM [dbo].[ViewCKProudctOutDetail]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewCKProudctOutDetail objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewCKProudctOutDetail objects.</returns>
        public static EntityList<ViewCKProudctOutDetail> GetViewCKProudctOutDetails(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCKProudctOutDetail>(SelectFieldList, "FROM [dbo].[ViewCKProudctOutDetail]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewCKProudctOutDetail objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewCKProudctOutDetailCount()
        {
            return GetViewCKProudctOutDetailCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewCKProudctOutDetail objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewCKProudctOutDetailCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewCKProudctOutDetail] " + where;

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
		/// Gets a collection ViewCKProudctOutDetail objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewCKProudctOutDetail objects.</returns>
		protected static EntityList<ViewCKProudctOutDetail> GetViewCKProudctOutDetails(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCKProudctOutDetails(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProudctOutDetail objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewCKProudctOutDetail objects.</returns>
		protected static EntityList<ViewCKProudctOutDetail> GetViewCKProudctOutDetails(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCKProudctOutDetails(string.Empty, where, parameters, ViewCKProudctOutDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProudctOutDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewCKProudctOutDetail objects.</returns>
		protected static EntityList<ViewCKProudctOutDetail> GetViewCKProudctOutDetails(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCKProudctOutDetails(prefix, where, parameters, ViewCKProudctOutDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProudctOutDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewCKProudctOutDetail objects.</returns>
		protected static EntityList<ViewCKProudctOutDetail> GetViewCKProudctOutDetails(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewCKProudctOutDetails(string.Empty, where, parameters, ViewCKProudctOutDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProudctOutDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewCKProudctOutDetail objects.</returns>
		protected static EntityList<ViewCKProudctOutDetail> GetViewCKProudctOutDetails(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewCKProudctOutDetails(prefix, where, parameters, ViewCKProudctOutDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProudctOutDetail objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewCKProudctOutDetail objects.</returns>
		protected static EntityList<ViewCKProudctOutDetail> GetViewCKProudctOutDetails(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewCKProudctOutDetail.SelectFieldList + "FROM [dbo].[ViewCKProudctOutDetail] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewCKProudctOutDetail>(reader);
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
        protected static EntityList<ViewCKProudctOutDetail> GetViewCKProudctOutDetails(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCKProudctOutDetail>(SelectFieldList, "FROM [dbo].[ViewCKProudctOutDetail] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewCKProudctOutDetailProperties
		{
			public const string ID = "ID";
			public const string OutSummaryID = "OutSummaryID";
			public const string ProductID = "ProductID";
			public const string UnitPrice = "UnitPrice";
			public const string OutTotalCount = "OutTotalCount";
			public const string OutTotalPrice = "OutTotalPrice";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string ProductNumber = "ProductNumber";
			public const string ProductName = "ProductName";
			public const string Unit = "Unit";
			public const string ModelNumber = "ModelNumber";
			public const string InventoryMin = "InventoryMin";
			public const string InventoryMax = "InventoryMax";
			public const string TotalInventory = "TotalInventory";
			public const string OutTime = "OutTime";
			public const string OrderNumber = "OrderNumber";
			public const string AddUserName = "AddUserName";
			public const string CategoryName = "CategoryName";
			public const string WarehouseName = "WarehouseName";
			public const string InCategoryName = "InCategoryName";
			public const string InCategoryID = "InCategoryID";
			public const string BelongTeamName = "BelongTeamName";
			public const string BelongDepartmentID = "BelongDepartmentID";
			public const string DepartmentName = "DepartmentName";
			public const string AcceptUserID = "AcceptUserID";
			public const string AcceptUserName = "AcceptUserName";
			public const string CKCategoryID = "CKCategoryID";
			public const string ProductCategoryName = "ProductCategoryName";
			public const string ApproveStatus = "ApproveStatus";
			public const string ApproveYesTime = "ApproveYesTime";
			public const string ApproveNoTime = "ApproveNoTime";
			public const string ApproveMan = "ApproveMan";
			public const string InBasicUnitPrice = "InBasicUnitPrice";
			public const string Remark = "Remark";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OutSummaryID" , "int:"},
    			 {"ProductID" , "int:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"OutTotalCount" , "int:"},
    			 {"OutTotalPrice" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"ProductNumber" , "string:"},
    			 {"ProductName" , "string:"},
    			 {"Unit" , "string:"},
    			 {"ModelNumber" , "string:"},
    			 {"InventoryMin" , "int:"},
    			 {"InventoryMax" , "int:"},
    			 {"TotalInventory" , "int:"},
    			 {"OutTime" , "DateTime:"},
    			 {"OrderNumber" , "string:"},
    			 {"AddUserName" , "string:"},
    			 {"CategoryName" , "string:"},
    			 {"WarehouseName" , "string:"},
    			 {"InCategoryName" , "string:"},
    			 {"InCategoryID" , "int:"},
    			 {"BelongTeamName" , "string:"},
    			 {"BelongDepartmentID" , "int:"},
    			 {"DepartmentName" , "string:"},
    			 {"AcceptUserID" , "int:"},
    			 {"AcceptUserName" , "string:"},
    			 {"CKCategoryID" , "int:"},
    			 {"ProductCategoryName" , "string:"},
    			 {"ApproveStatus" , "int:"},
    			 {"ApproveYesTime" , "DateTime:"},
    			 {"ApproveNoTime" , "DateTime:"},
    			 {"ApproveMan" , "string:"},
    			 {"InBasicUnitPrice" , "decimal:"},
    			 {"Remark" , "string:"},
            };
		}
		#endregion
	}
}
