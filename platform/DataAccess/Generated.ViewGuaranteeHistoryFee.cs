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
	/// This object represents the properties and methods of a ViewGuaranteeHistoryFee.
	/// </summary>
	[Serializable()]
	public partial class ViewGuaranteeHistoryFee 
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
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _roomID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RoomID
		{
			[DebuggerStepThrough()]
			get { return this._roomID; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _useCount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal UseCount
		{
			[DebuggerStepThrough()]
			get { return this._useCount; }
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
		private decimal _cost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal Cost
		{
			[DebuggerStepThrough()]
			get { return this._cost; }
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
		private DateTime _addTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime AddTime
		{
			[DebuggerStepThrough()]
			get { return this._addTime; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isCharged = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsCharged
		{
			[DebuggerStepThrough()]
			get { return this._isCharged; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargeFeeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChargeFeeID
		{
			[DebuggerStepThrough()]
			get { return this._chargeFeeID; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ChargeID
		{
			[DebuggerStepThrough()]
			get { return this._chargeID; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isStart = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsStart
		{
			[DebuggerStepThrough()]
			get { return this._isStart; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _newStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime NewStartTime
		{
			[DebuggerStepThrough()]
			get { return this._newStartTime; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _importFeeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ImportFeeID
		{
			[DebuggerStepThrough()]
			get { return this._importFeeID; }
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
		private decimal _discount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal Discount
		{
			[DebuggerStepThrough()]
			get { return this._discount; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _outDays = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OutDays
		{
			[DebuggerStepThrough()]
			get { return this._outDays; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _chargeFee = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ChargeFee
		{
			[DebuggerStepThrough()]
			get { return this._chargeFee; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalRealCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalRealCost
		{
			[DebuggerStepThrough()]
			get { return this._totalRealCost; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _restCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RestCost
		{
			[DebuggerStepThrough()]
			get { return this._restCost; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalDiscountCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalDiscountCost
		{
			[DebuggerStepThrough()]
			get { return this._totalDiscountCost; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _onlyOnceCharge = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool OnlyOnceCharge
		{
			[DebuggerStepThrough()]
			get { return this._onlyOnceCharge; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _chargeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime ChargeTime
		{
			[DebuggerStepThrough()]
			get { return this._chargeTime; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeMan
		{
			[DebuggerStepThrough()]
			get { return this._chargeMan; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _printNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PrintNumber
		{
			[DebuggerStepThrough()]
			get { return this._printNumber; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _historyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int HistoryID
		{
			[DebuggerStepThrough()]
			get { return this._historyID; }
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
		private int _chargeState = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ChargeState
		{
			[DebuggerStepThrough()]
			get { return this._chargeState; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _returnGuaranteeFee = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool ReturnGuaranteeFee
		{
			[DebuggerStepThrough()]
			get { return this._returnGuaranteeFee; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _parentRoomFeeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ParentRoomFeeID
		{
			[DebuggerStepThrough()]
			get { return this._parentRoomFeeID; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomName
		{
			[DebuggerStepThrough()]
			get { return this._roomName; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _fullName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FullName
		{
			[DebuggerStepThrough()]
			get { return this._fullName; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeName
		{
			[DebuggerStepThrough()]
			get { return this._chargeName; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _returnCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ReturnCost
		{
			[DebuggerStepThrough()]
			get { return this._returnCost; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _categoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CategoryID
		{
			[DebuggerStepThrough()]
			get { return this._categoryID; }
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewGuaranteeHistoryFee() { }
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
	[ViewGuaranteeHistoryFee].[ID],
	[ViewGuaranteeHistoryFee].[RoomID],
	[ViewGuaranteeHistoryFee].[UseCount],
	[ViewGuaranteeHistoryFee].[StartTime],
	[ViewGuaranteeHistoryFee].[EndTime],
	[ViewGuaranteeHistoryFee].[Cost],
	[ViewGuaranteeHistoryFee].[Remark],
	[ViewGuaranteeHistoryFee].[AddTime],
	[ViewGuaranteeHistoryFee].[IsCharged],
	[ViewGuaranteeHistoryFee].[ChargeFeeID],
	[ViewGuaranteeHistoryFee].[ChargeID],
	[ViewGuaranteeHistoryFee].[IsStart],
	[ViewGuaranteeHistoryFee].[NewStartTime],
	[ViewGuaranteeHistoryFee].[ImportFeeID],
	[ViewGuaranteeHistoryFee].[UnitPrice],
	[ViewGuaranteeHistoryFee].[RealCost],
	[ViewGuaranteeHistoryFee].[Discount],
	[ViewGuaranteeHistoryFee].[OutDays],
	[ViewGuaranteeHistoryFee].[ChargeFee],
	[ViewGuaranteeHistoryFee].[TotalRealCost],
	[ViewGuaranteeHistoryFee].[RestCost],
	[ViewGuaranteeHistoryFee].[TotalDiscountCost],
	[ViewGuaranteeHistoryFee].[OnlyOnceCharge],
	[ViewGuaranteeHistoryFee].[ChargeTime],
	[ViewGuaranteeHistoryFee].[ChargeMan],
	[ViewGuaranteeHistoryFee].[PrintNumber],
	[ViewGuaranteeHistoryFee].[HistoryID],
	[ViewGuaranteeHistoryFee].[PrintID],
	[ViewGuaranteeHistoryFee].[ChargeState],
	[ViewGuaranteeHistoryFee].[ReturnGuaranteeFee],
	[ViewGuaranteeHistoryFee].[ParentRoomFeeID],
	[ViewGuaranteeHistoryFee].[RoomName],
	[ViewGuaranteeHistoryFee].[FullName],
	[ViewGuaranteeHistoryFee].[ChargeName],
	[ViewGuaranteeHistoryFee].[ReturnCost],
	[ViewGuaranteeHistoryFee].[CategoryID]
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
                return "ViewGuaranteeHistoryFee";
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
		/// Gets a collection ViewGuaranteeHistoryFee objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewGuaranteeHistoryFee objects.</returns>
		public static EntityList<ViewGuaranteeHistoryFee> GetViewGuaranteeHistoryFees()
		{
			string commandText = @"
SELECT " + ViewGuaranteeHistoryFee.SelectFieldList + "FROM [dbo].[ViewGuaranteeHistoryFee] " + ViewGuaranteeHistoryFee.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewGuaranteeHistoryFee>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewGuaranteeHistoryFee objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewGuaranteeHistoryFee objects.</returns>
        public static EntityList<ViewGuaranteeHistoryFee> GetViewGuaranteeHistoryFees(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewGuaranteeHistoryFee>(SelectFieldList, "FROM [dbo].[ViewGuaranteeHistoryFee]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewGuaranteeHistoryFee objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewGuaranteeHistoryFee objects.</returns>
        public static EntityList<ViewGuaranteeHistoryFee> GetViewGuaranteeHistoryFees(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewGuaranteeHistoryFee>(SelectFieldList, "FROM [dbo].[ViewGuaranteeHistoryFee]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ViewGuaranteeHistoryFee objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewGuaranteeHistoryFee objects.</returns>
		protected static EntityList<ViewGuaranteeHistoryFee> GetViewGuaranteeHistoryFees(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewGuaranteeHistoryFees(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewGuaranteeHistoryFee objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewGuaranteeHistoryFee objects.</returns>
		protected static EntityList<ViewGuaranteeHistoryFee> GetViewGuaranteeHistoryFees(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewGuaranteeHistoryFees(string.Empty, where, parameters, ViewGuaranteeHistoryFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewGuaranteeHistoryFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewGuaranteeHistoryFee objects.</returns>
		protected static EntityList<ViewGuaranteeHistoryFee> GetViewGuaranteeHistoryFees(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewGuaranteeHistoryFees(prefix, where, parameters, ViewGuaranteeHistoryFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewGuaranteeHistoryFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewGuaranteeHistoryFee objects.</returns>
		protected static EntityList<ViewGuaranteeHistoryFee> GetViewGuaranteeHistoryFees(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewGuaranteeHistoryFees(string.Empty, where, parameters, ViewGuaranteeHistoryFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewGuaranteeHistoryFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewGuaranteeHistoryFee objects.</returns>
		protected static EntityList<ViewGuaranteeHistoryFee> GetViewGuaranteeHistoryFees(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewGuaranteeHistoryFees(prefix, where, parameters, ViewGuaranteeHistoryFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewGuaranteeHistoryFee objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewGuaranteeHistoryFee objects.</returns>
		protected static EntityList<ViewGuaranteeHistoryFee> GetViewGuaranteeHistoryFees(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewGuaranteeHistoryFee.SelectFieldList + "FROM [dbo].[ViewGuaranteeHistoryFee] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewGuaranteeHistoryFee>(reader);
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
        protected static EntityList<ViewGuaranteeHistoryFee> GetViewGuaranteeHistoryFees(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewGuaranteeHistoryFee>(SelectFieldList, "FROM [dbo].[ViewGuaranteeHistoryFee] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewGuaranteeHistoryFeeProperties
		{
			public const string ID = "ID";
			public const string RoomID = "RoomID";
			public const string UseCount = "UseCount";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string Cost = "Cost";
			public const string Remark = "Remark";
			public const string AddTime = "AddTime";
			public const string IsCharged = "IsCharged";
			public const string ChargeFeeID = "ChargeFeeID";
			public const string ChargeID = "ChargeID";
			public const string IsStart = "IsStart";
			public const string NewStartTime = "NewStartTime";
			public const string ImportFeeID = "ImportFeeID";
			public const string UnitPrice = "UnitPrice";
			public const string RealCost = "RealCost";
			public const string Discount = "Discount";
			public const string OutDays = "OutDays";
			public const string ChargeFee = "ChargeFee";
			public const string TotalRealCost = "TotalRealCost";
			public const string RestCost = "RestCost";
			public const string TotalDiscountCost = "TotalDiscountCost";
			public const string OnlyOnceCharge = "OnlyOnceCharge";
			public const string ChargeTime = "ChargeTime";
			public const string ChargeMan = "ChargeMan";
			public const string PrintNumber = "PrintNumber";
			public const string HistoryID = "HistoryID";
			public const string PrintID = "PrintID";
			public const string ChargeState = "ChargeState";
			public const string ReturnGuaranteeFee = "ReturnGuaranteeFee";
			public const string ParentRoomFeeID = "ParentRoomFeeID";
			public const string RoomName = "RoomName";
			public const string FullName = "FullName";
			public const string ChargeName = "ChargeName";
			public const string ReturnCost = "ReturnCost";
			public const string CategoryID = "CategoryID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"UseCount" , "decimal:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"Cost" , "decimal:"},
    			 {"Remark" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"IsCharged" , "bool:"},
    			 {"ChargeFeeID" , "int:"},
    			 {"ChargeID" , "int:"},
    			 {"IsStart" , "bool:"},
    			 {"NewStartTime" , "DateTime:"},
    			 {"ImportFeeID" , "int:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"RealCost" , "decimal:"},
    			 {"Discount" , "decimal:"},
    			 {"OutDays" , "int:"},
    			 {"ChargeFee" , "decimal:"},
    			 {"TotalRealCost" , "decimal:"},
    			 {"RestCost" , "decimal:"},
    			 {"TotalDiscountCost" , "decimal:"},
    			 {"OnlyOnceCharge" , "bool:"},
    			 {"ChargeTime" , "DateTime:"},
    			 {"ChargeMan" , "string:"},
    			 {"PrintNumber" , "string:"},
    			 {"HistoryID" , "int:"},
    			 {"PrintID" , "int:"},
    			 {"ChargeState" , "int:"},
    			 {"ReturnGuaranteeFee" , "bool:"},
    			 {"ParentRoomFeeID" , "int:"},
    			 {"RoomName" , "string:"},
    			 {"FullName" , "string:"},
    			 {"ChargeName" , "string:"},
    			 {"ReturnCost" , "decimal:"},
    			 {"CategoryID" , "int:"},
            };
		}
		#endregion
	}
}
