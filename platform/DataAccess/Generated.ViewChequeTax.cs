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
	/// This object represents the properties and methods of a ViewChequeTax.
	/// </summary>
	[Serializable()]
	public partial class ViewChequeTax 
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
		private string _contractNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractNumber
		{
			[DebuggerStepThrough()]
			get { return this._contractNumber; }
            protected set { this._contractNumber = value;}
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
		private int _contractCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ContractCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._contractCategoryID; }
            protected set { this._contractCategoryID = value;}
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
            protected set { this._totalCount = value;}
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
            protected set { this._totalCost = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalTaxCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalTaxCost
		{
			[DebuggerStepThrough()]
			get { return this._totalTaxCost; }
            protected set { this._totalTaxCost = value;}
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
		private string _contractCategoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractCategoryName
		{
			[DebuggerStepThrough()]
			get { return this._contractCategoryName; }
            protected set { this._contractCategoryName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _taxRateID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TaxRateID
		{
			[DebuggerStepThrough()]
			get { return this._taxRateID; }
            protected set { this._taxRateID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _taxRateName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TaxRateName
		{
			[DebuggerStepThrough()]
			get { return this._taxRateName; }
            protected set { this._taxRateName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _taxRateValue = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TaxRateValue
		{
			[DebuggerStepThrough()]
			get { return this._taxRateValue; }
            protected set { this._taxRateValue = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewChequeTax() { }
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
	[ViewChequeTax].[ID],
	[ViewChequeTax].[ContractNumber],
	[ViewChequeTax].[DepartmentID],
	[ViewChequeTax].[ContractCategoryID],
	[ViewChequeTax].[ContractName],
	[ViewChequeTax].[UnitPrice],
	[ViewChequeTax].[TotalCount],
	[ViewChequeTax].[TotalCost],
	[ViewChequeTax].[TotalTaxCost],
	[ViewChequeTax].[AddMan],
	[ViewChequeTax].[AddTime],
	[ViewChequeTax].[DepartmentName],
	[ViewChequeTax].[ContractCategoryName],
	[ViewChequeTax].[TaxRateID],
	[ViewChequeTax].[TaxRateName],
	[ViewChequeTax].[TaxRateValue]
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
                return "ViewChequeTax";
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
		/// Gets a collection ViewChequeTax objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewChequeTax objects.</returns>
		public static EntityList<ViewChequeTax> GetViewChequeTaxes()
		{
			string commandText = @"
SELECT " + ViewChequeTax.SelectFieldList + "FROM [dbo].[ViewChequeTax] " + ViewChequeTax.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewChequeTax>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewChequeTax objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewChequeTax objects.</returns>
        public static EntityList<ViewChequeTax> GetViewChequeTaxes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewChequeTax>(SelectFieldList, "FROM [dbo].[ViewChequeTax]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewChequeTax objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewChequeTax objects.</returns>
        public static EntityList<ViewChequeTax> GetViewChequeTaxes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewChequeTax>(SelectFieldList, "FROM [dbo].[ViewChequeTax]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewChequeTax objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewChequeTaxCount()
        {
            return GetViewChequeTaxCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewChequeTax objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewChequeTaxCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewChequeTax] " + where;

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
		/// Gets a collection ViewChequeTax objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewChequeTax objects.</returns>
		protected static EntityList<ViewChequeTax> GetViewChequeTaxes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewChequeTaxes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewChequeTax objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewChequeTax objects.</returns>
		protected static EntityList<ViewChequeTax> GetViewChequeTaxes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewChequeTaxes(string.Empty, where, parameters, ViewChequeTax.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewChequeTax objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewChequeTax objects.</returns>
		protected static EntityList<ViewChequeTax> GetViewChequeTaxes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewChequeTaxes(prefix, where, parameters, ViewChequeTax.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewChequeTax objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewChequeTax objects.</returns>
		protected static EntityList<ViewChequeTax> GetViewChequeTaxes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewChequeTaxes(string.Empty, where, parameters, ViewChequeTax.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewChequeTax objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewChequeTax objects.</returns>
		protected static EntityList<ViewChequeTax> GetViewChequeTaxes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewChequeTaxes(prefix, where, parameters, ViewChequeTax.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewChequeTax objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewChequeTax objects.</returns>
		protected static EntityList<ViewChequeTax> GetViewChequeTaxes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewChequeTax.SelectFieldList + "FROM [dbo].[ViewChequeTax] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewChequeTax>(reader);
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
        protected static EntityList<ViewChequeTax> GetViewChequeTaxes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewChequeTax>(SelectFieldList, "FROM [dbo].[ViewChequeTax] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewChequeTaxProperties
		{
			public const string ID = "ID";
			public const string ContractNumber = "ContractNumber";
			public const string DepartmentID = "DepartmentID";
			public const string ContractCategoryID = "ContractCategoryID";
			public const string ContractName = "ContractName";
			public const string UnitPrice = "UnitPrice";
			public const string TotalCount = "TotalCount";
			public const string TotalCost = "TotalCost";
			public const string TotalTaxCost = "TotalTaxCost";
			public const string AddMan = "AddMan";
			public const string AddTime = "AddTime";
			public const string DepartmentName = "DepartmentName";
			public const string ContractCategoryName = "ContractCategoryName";
			public const string TaxRateID = "TaxRateID";
			public const string TaxRateName = "TaxRateName";
			public const string TaxRateValue = "TaxRateValue";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ContractNumber" , "string:"},
    			 {"DepartmentID" , "int:"},
    			 {"ContractCategoryID" , "int:"},
    			 {"ContractName" , "string:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"TotalCount" , "int:"},
    			 {"TotalCost" , "decimal:"},
    			 {"TotalTaxCost" , "decimal:"},
    			 {"AddMan" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"DepartmentName" , "string:"},
    			 {"ContractCategoryName" , "string:"},
    			 {"TaxRateID" , "int:"},
    			 {"TaxRateName" , "string:"},
    			 {"TaxRateValue" , "string:"},
            };
		}
		#endregion
	}
}
