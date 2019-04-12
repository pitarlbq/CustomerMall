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
	/// This object represents the properties and methods of a ViewWarehouseInOutSummary.
	/// </summary>
	[Serializable()]
	public partial class ViewWarehouseInOutSummary 
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
		[DataObjectField(false, false, true)]
		public int ID
		{
			[DebuggerStepThrough()]
			get { return this._iD; }
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
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _inventory = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Inventory
		{
			[DebuggerStepThrough()]
			get { return this._inventory; }
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
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewWarehouseInOutSummary() { }
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
	[ViewWarehouseInOutSummary].[ID],
	[ViewWarehouseInOutSummary].[InTotalCount],
	[ViewWarehouseInOutSummary].[StartTime],
	[ViewWarehouseInOutSummary].[OutTime],
	[ViewWarehouseInOutSummary].[OutTotalCount],
	[ViewWarehouseInOutSummary].[Inventory],
	[ViewWarehouseInOutSummary].[OrderNumber],
	[ViewWarehouseInOutSummary].[AddMan],
	[ViewWarehouseInOutSummary].[Remark],
	[ViewWarehouseInOutSummary].[InOutType],
	[ViewWarehouseInOutSummary].[BusinessID],
	[ViewWarehouseInOutSummary].[InventoryInfoID],
	[ViewWarehouseInOutSummary].[ProductID],
	[ViewWarehouseInOutSummary].[SpecInfoID],
	[ViewWarehouseInOutSummary].[CarrierID],
	[ViewWarehouseInOutSummary].[ContactName]
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
                return "ViewWarehouseInOutSummary";
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
		/// Gets a collection ViewWarehouseInOutSummary objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewWarehouseInOutSummary objects.</returns>
		public static EntityList<ViewWarehouseInOutSummary> GetViewWarehouseInOutSummaries()
		{
			string commandText = @"
SELECT " + ViewWarehouseInOutSummary.SelectFieldList + "FROM [dbo].[ViewWarehouseInOutSummary] " + ViewWarehouseInOutSummary.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewWarehouseInOutSummary>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewWarehouseInOutSummary objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewWarehouseInOutSummary objects.</returns>
        public static EntityList<ViewWarehouseInOutSummary> GetViewWarehouseInOutSummaries(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewWarehouseInOutSummary>(SelectFieldList, "FROM [dbo].[ViewWarehouseInOutSummary]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewWarehouseInOutSummary objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewWarehouseInOutSummary objects.</returns>
        public static EntityList<ViewWarehouseInOutSummary> GetViewWarehouseInOutSummaries(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewWarehouseInOutSummary>(SelectFieldList, "FROM [dbo].[ViewWarehouseInOutSummary]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ViewWarehouseInOutSummary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewWarehouseInOutSummary objects.</returns>
		protected static EntityList<ViewWarehouseInOutSummary> GetViewWarehouseInOutSummaries(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewWarehouseInOutSummaries(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewWarehouseInOutSummary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewWarehouseInOutSummary objects.</returns>
		protected static EntityList<ViewWarehouseInOutSummary> GetViewWarehouseInOutSummaries(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewWarehouseInOutSummaries(string.Empty, where, parameters, ViewWarehouseInOutSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWarehouseInOutSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewWarehouseInOutSummary objects.</returns>
		protected static EntityList<ViewWarehouseInOutSummary> GetViewWarehouseInOutSummaries(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewWarehouseInOutSummaries(prefix, where, parameters, ViewWarehouseInOutSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWarehouseInOutSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewWarehouseInOutSummary objects.</returns>
		protected static EntityList<ViewWarehouseInOutSummary> GetViewWarehouseInOutSummaries(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewWarehouseInOutSummaries(string.Empty, where, parameters, ViewWarehouseInOutSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWarehouseInOutSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewWarehouseInOutSummary objects.</returns>
		protected static EntityList<ViewWarehouseInOutSummary> GetViewWarehouseInOutSummaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewWarehouseInOutSummaries(prefix, where, parameters, ViewWarehouseInOutSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWarehouseInOutSummary objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewWarehouseInOutSummary objects.</returns>
		protected static EntityList<ViewWarehouseInOutSummary> GetViewWarehouseInOutSummaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewWarehouseInOutSummary.SelectFieldList + "FROM [dbo].[ViewWarehouseInOutSummary] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewWarehouseInOutSummary>(reader);
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
        protected static EntityList<ViewWarehouseInOutSummary> GetViewWarehouseInOutSummaries(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewWarehouseInOutSummary>(SelectFieldList, "FROM [dbo].[ViewWarehouseInOutSummary] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewWarehouseInOutSummaryProperties
		{
			public const string ID = "ID";
			public const string InTotalCount = "InTotalCount";
			public const string StartTime = "StartTime";
			public const string OutTime = "OutTime";
			public const string OutTotalCount = "OutTotalCount";
			public const string Inventory = "Inventory";
			public const string OrderNumber = "OrderNumber";
			public const string AddMan = "AddMan";
			public const string Remark = "Remark";
			public const string InOutType = "InOutType";
			public const string BusinessID = "BusinessID";
			public const string InventoryInfoID = "InventoryInfoID";
			public const string ProductID = "ProductID";
			public const string SpecInfoID = "SpecInfoID";
			public const string CarrierID = "CarrierID";
			public const string ContactName = "ContactName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"InTotalCount" , "int:"},
    			 {"StartTime" , "DateTime:"},
    			 {"OutTime" , "DateTime:"},
    			 {"OutTotalCount" , "int:"},
    			 {"Inventory" , "int:"},
    			 {"OrderNumber" , "string:"},
    			 {"AddMan" , "string:"},
    			 {"Remark" , "string:"},
    			 {"InOutType" , "int:"},
    			 {"BusinessID" , "int:"},
    			 {"InventoryInfoID" , "int:"},
    			 {"ProductID" , "int:"},
    			 {"SpecInfoID" , "int:"},
    			 {"CarrierID" , "int:"},
    			 {"ContactName" , "string:"},
            };
		}
		#endregion
	}
}
