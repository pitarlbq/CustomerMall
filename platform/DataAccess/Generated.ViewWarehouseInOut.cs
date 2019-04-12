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
	/// This object represents the properties and methods of a ViewWarehouseInOut.
	/// </summary>
	[Serializable()]
	public partial class ViewWarehouseInOut 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _inventoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string InventoryName
		{
			[DebuggerStepThrough()]
			get { return this._inventoryName; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contactName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContactName
		{
			[DebuggerStepThrough()]
			get { return this._contactName; }
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
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _specName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SpecName
		{
			[DebuggerStepThrough()]
			get { return this._specName; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _carrierName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CarrierName
		{
			[DebuggerStepThrough()]
			get { return this._carrierName; }
		}
		
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
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _businessID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int BusinessID
		{
			[DebuggerStepThrough()]
			get { return this._businessID; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _inventoryInfoID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int InventoryInfoID
		{
			[DebuggerStepThrough()]
			get { return this._inventoryInfoID; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _productID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProductID
		{
			[DebuggerStepThrough()]
			get { return this._productID; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _specInfoID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SpecInfoID
		{
			[DebuggerStepThrough()]
			get { return this._specInfoID; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _count = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Count
		{
			[DebuggerStepThrough()]
			get { return this._count; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _coldCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ColdCost
		{
			[DebuggerStepThrough()]
			get { return this._coldCost; }
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
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _endTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime EndTime
		{
			[DebuggerStepThrough()]
			get { return this._endTime; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _carrierID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CarrierID
		{
			[DebuggerStepThrough()]
			get { return this._carrierID; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _moveCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal MoveCost
		{
			[DebuggerStepThrough()]
			get { return this._moveCost; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalCost
		{
			[DebuggerStepThrough()]
			get { return this._totalCost; }
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
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _inOutType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int InOutType
		{
			[DebuggerStepThrough()]
			get { return this._inOutType; }
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
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _relateID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RelateID
		{
			[DebuggerStepThrough()]
			get { return this._relateID; }
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
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _coldPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ColdPrice
		{
			[DebuggerStepThrough()]
			get { return this._coldPrice; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _movePrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal MovePrice
		{
			[DebuggerStepThrough()]
			get { return this._movePrice; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _balancePrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal BalancePrice
		{
			[DebuggerStepThrough()]
			get { return this._balancePrice; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _realCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RealCost
		{
			[DebuggerStepThrough()]
			get { return this._realCost; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _discountCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal DiscountCost
		{
			[DebuggerStepThrough()]
			get { return this._discountCost; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _businessChargeStatus = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool BusinessChargeStatus
		{
			[DebuggerStepThrough()]
			get { return this._businessChargeStatus; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _printID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PrintID
		{
			[DebuggerStepThrough()]
			get { return this._printID; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _balanceTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime BalanceTime
		{
			[DebuggerStepThrough()]
			get { return this._balanceTime; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _removeCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RemoveCost
		{
			[DebuggerStepThrough()]
			get { return this._removeCost; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _carrierBalanceCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal CarrierBalanceCost
		{
			[DebuggerStepThrough()]
			get { return this._carrierBalanceCost; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _carrierChargeStatus = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool CarrierChargeStatus
		{
			[DebuggerStepThrough()]
			get { return this._carrierChargeStatus; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _carrierBalanceTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime CarrierBalanceTime
		{
			[DebuggerStepThrough()]
			get { return this._carrierBalanceTime; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _totalCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TotalCount
		{
			[DebuggerStepThrough()]
			get { return this._totalCount; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _carrierMoveCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal CarrierMoveCost
		{
			[DebuggerStepThrough()]
			get { return this._carrierMoveCost; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isToNext = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsToNext
		{
			[DebuggerStepThrough()]
			get { return this._isToNext; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isNextOrder = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsNextOrder
		{
			[DebuggerStepThrough()]
			get { return this._isNextOrder; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _lastPrintTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime LastPrintTime
		{
			[DebuggerStepThrough()]
			get { return this._lastPrintTime; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _printCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PrintCount
		{
			[DebuggerStepThrough()]
			get { return this._printCount; }
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewWarehouseInOut() { }
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
	[ViewWarehouseInOut].[InventoryName],
	[ViewWarehouseInOut].[ContactName],
	[ViewWarehouseInOut].[ProductName],
	[ViewWarehouseInOut].[SpecName],
	[ViewWarehouseInOut].[CarrierName],
	[ViewWarehouseInOut].[ID],
	[ViewWarehouseInOut].[BusinessID],
	[ViewWarehouseInOut].[InventoryInfoID],
	[ViewWarehouseInOut].[ProductID],
	[ViewWarehouseInOut].[SpecInfoID],
	[ViewWarehouseInOut].[Count],
	[ViewWarehouseInOut].[ColdCost],
	[ViewWarehouseInOut].[StartTime],
	[ViewWarehouseInOut].[EndTime],
	[ViewWarehouseInOut].[CarrierID],
	[ViewWarehouseInOut].[MoveCost],
	[ViewWarehouseInOut].[TotalCost],
	[ViewWarehouseInOut].[AddTime],
	[ViewWarehouseInOut].[OrderNumber],
	[ViewWarehouseInOut].[InOutType],
	[ViewWarehouseInOut].[OutTime],
	[ViewWarehouseInOut].[RelateID],
	[ViewWarehouseInOut].[AddMan],
	[ViewWarehouseInOut].[Remark],
	[ViewWarehouseInOut].[ColdPrice],
	[ViewWarehouseInOut].[MovePrice],
	[ViewWarehouseInOut].[BalancePrice],
	[ViewWarehouseInOut].[RealCost],
	[ViewWarehouseInOut].[DiscountCost],
	[ViewWarehouseInOut].[BusinessChargeStatus],
	[ViewWarehouseInOut].[PrintID],
	[ViewWarehouseInOut].[BalanceTime],
	[ViewWarehouseInOut].[RemoveCost],
	[ViewWarehouseInOut].[CarrierBalanceCost],
	[ViewWarehouseInOut].[CarrierChargeStatus],
	[ViewWarehouseInOut].[CarrierBalanceTime],
	[ViewWarehouseInOut].[TotalCount],
	[ViewWarehouseInOut].[CarrierMoveCost],
	[ViewWarehouseInOut].[IsToNext],
	[ViewWarehouseInOut].[IsNextOrder],
	[ViewWarehouseInOut].[LastPrintTime],
	[ViewWarehouseInOut].[PrintCount]
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
                return "ViewWarehouseInOut";
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
		/// Gets a collection ViewWarehouseInOut objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewWarehouseInOut objects.</returns>
		public static EntityList<ViewWarehouseInOut> GetViewWarehouseInOuts()
		{
			string commandText = @"
SELECT " + ViewWarehouseInOut.SelectFieldList + "FROM [dbo].[ViewWarehouseInOut] " + ViewWarehouseInOut.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewWarehouseInOut>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewWarehouseInOut objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewWarehouseInOut objects.</returns>
        public static EntityList<ViewWarehouseInOut> GetViewWarehouseInOuts(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewWarehouseInOut>(SelectFieldList, "FROM [dbo].[ViewWarehouseInOut]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewWarehouseInOut objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewWarehouseInOut objects.</returns>
        public static EntityList<ViewWarehouseInOut> GetViewWarehouseInOuts(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewWarehouseInOut>(SelectFieldList, "FROM [dbo].[ViewWarehouseInOut]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ViewWarehouseInOut objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewWarehouseInOut objects.</returns>
		protected static EntityList<ViewWarehouseInOut> GetViewWarehouseInOuts(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewWarehouseInOuts(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewWarehouseInOut objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewWarehouseInOut objects.</returns>
		protected static EntityList<ViewWarehouseInOut> GetViewWarehouseInOuts(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewWarehouseInOuts(string.Empty, where, parameters, ViewWarehouseInOut.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWarehouseInOut objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewWarehouseInOut objects.</returns>
		protected static EntityList<ViewWarehouseInOut> GetViewWarehouseInOuts(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewWarehouseInOuts(prefix, where, parameters, ViewWarehouseInOut.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWarehouseInOut objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewWarehouseInOut objects.</returns>
		protected static EntityList<ViewWarehouseInOut> GetViewWarehouseInOuts(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewWarehouseInOuts(string.Empty, where, parameters, ViewWarehouseInOut.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWarehouseInOut objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewWarehouseInOut objects.</returns>
		protected static EntityList<ViewWarehouseInOut> GetViewWarehouseInOuts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewWarehouseInOuts(prefix, where, parameters, ViewWarehouseInOut.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWarehouseInOut objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewWarehouseInOut objects.</returns>
		protected static EntityList<ViewWarehouseInOut> GetViewWarehouseInOuts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewWarehouseInOut.SelectFieldList + "FROM [dbo].[ViewWarehouseInOut] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewWarehouseInOut>(reader);
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
        protected static EntityList<ViewWarehouseInOut> GetViewWarehouseInOuts(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewWarehouseInOut>(SelectFieldList, "FROM [dbo].[ViewWarehouseInOut] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewWarehouseInOutProperties
		{
			public const string InventoryName = "InventoryName";
			public const string ContactName = "ContactName";
			public const string ProductName = "ProductName";
			public const string SpecName = "SpecName";
			public const string CarrierName = "CarrierName";
			public const string ID = "ID";
			public const string BusinessID = "BusinessID";
			public const string InventoryInfoID = "InventoryInfoID";
			public const string ProductID = "ProductID";
			public const string SpecInfoID = "SpecInfoID";
			public const string Count = "Count";
			public const string ColdCost = "ColdCost";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string CarrierID = "CarrierID";
			public const string MoveCost = "MoveCost";
			public const string TotalCost = "TotalCost";
			public const string AddTime = "AddTime";
			public const string OrderNumber = "OrderNumber";
			public const string InOutType = "InOutType";
			public const string OutTime = "OutTime";
			public const string RelateID = "RelateID";
			public const string AddMan = "AddMan";
			public const string Remark = "Remark";
			public const string ColdPrice = "ColdPrice";
			public const string MovePrice = "MovePrice";
			public const string BalancePrice = "BalancePrice";
			public const string RealCost = "RealCost";
			public const string DiscountCost = "DiscountCost";
			public const string BusinessChargeStatus = "BusinessChargeStatus";
			public const string PrintID = "PrintID";
			public const string BalanceTime = "BalanceTime";
			public const string RemoveCost = "RemoveCost";
			public const string CarrierBalanceCost = "CarrierBalanceCost";
			public const string CarrierChargeStatus = "CarrierChargeStatus";
			public const string CarrierBalanceTime = "CarrierBalanceTime";
			public const string TotalCount = "TotalCount";
			public const string CarrierMoveCost = "CarrierMoveCost";
			public const string IsToNext = "IsToNext";
			public const string IsNextOrder = "IsNextOrder";
			public const string LastPrintTime = "LastPrintTime";
			public const string PrintCount = "PrintCount";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"InventoryName" , "string:"},
    			 {"ContactName" , "string:"},
    			 {"ProductName" , "string:"},
    			 {"SpecName" , "string:"},
    			 {"CarrierName" , "string:"},
    			 {"ID" , "int:"},
    			 {"BusinessID" , "int:"},
    			 {"InventoryInfoID" , "int:"},
    			 {"ProductID" , "int:"},
    			 {"SpecInfoID" , "int:"},
    			 {"Count" , "int:"},
    			 {"ColdCost" , "decimal:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"CarrierID" , "int:"},
    			 {"MoveCost" , "decimal:"},
    			 {"TotalCost" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"OrderNumber" , "string:"},
    			 {"InOutType" , "int:"},
    			 {"OutTime" , "DateTime:"},
    			 {"RelateID" , "int:"},
    			 {"AddMan" , "string:"},
    			 {"Remark" , "string:"},
    			 {"ColdPrice" , "decimal:"},
    			 {"MovePrice" , "decimal:"},
    			 {"BalancePrice" , "decimal:"},
    			 {"RealCost" , "decimal:"},
    			 {"DiscountCost" , "decimal:"},
    			 {"BusinessChargeStatus" , "bool:"},
    			 {"PrintID" , "int:"},
    			 {"BalanceTime" , "DateTime:"},
    			 {"RemoveCost" , "decimal:"},
    			 {"CarrierBalanceCost" , "decimal:"},
    			 {"CarrierChargeStatus" , "bool:"},
    			 {"CarrierBalanceTime" , "DateTime:"},
    			 {"TotalCount" , "int:"},
    			 {"CarrierMoveCost" , "decimal:"},
    			 {"IsToNext" , "bool:"},
    			 {"IsNextOrder" , "bool:"},
    			 {"LastPrintTime" , "DateTime:"},
    			 {"PrintCount" , "int:"},
            };
		}
		#endregion
	}
}
