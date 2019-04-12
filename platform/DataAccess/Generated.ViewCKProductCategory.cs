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
	/// This object represents the properties and methods of a ViewCKProductCategory.
	/// </summary>
	[Serializable()]
	public partial class ViewCKProductCategory 
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
		private int _categoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int CategoryID
		{
			[DebuggerStepThrough()]
			get { return this._categoryID; }
            protected set { this._categoryID = value;}
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
		private decimal _productUnitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ProductUnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._productUnitPrice; }
            protected set { this._productUnitPrice = value;}
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
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewCKProductCategory() { }
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
	[ViewCKProductCategory].[ID],
	[ViewCKProductCategory].[CategoryID],
	[ViewCKProductCategory].[ProductNumber],
	[ViewCKProductCategory].[ProductName],
	[ViewCKProductCategory].[Unit],
	[ViewCKProductCategory].[ModelNumber],
	[ViewCKProductCategory].[InventoryMin],
	[ViewCKProductCategory].[InventoryMax],
	[ViewCKProductCategory].[AddTime],
	[ViewCKProductCategory].[AddMan],
	[ViewCKProductCategory].[ProductUnitPrice],
	[ViewCKProductCategory].[ProductCategoryName]
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
                return "ViewCKProductCategory";
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
		/// Gets a collection ViewCKProductCategory objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewCKProductCategory objects.</returns>
		public static EntityList<ViewCKProductCategory> GetViewCKProductCategories()
		{
			string commandText = @"
SELECT " + ViewCKProductCategory.SelectFieldList + "FROM [dbo].[ViewCKProductCategory] " + ViewCKProductCategory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewCKProductCategory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewCKProductCategory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewCKProductCategory objects.</returns>
        public static EntityList<ViewCKProductCategory> GetViewCKProductCategories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCKProductCategory>(SelectFieldList, "FROM [dbo].[ViewCKProductCategory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewCKProductCategory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewCKProductCategory objects.</returns>
        public static EntityList<ViewCKProductCategory> GetViewCKProductCategories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCKProductCategory>(SelectFieldList, "FROM [dbo].[ViewCKProductCategory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewCKProductCategory objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewCKProductCategoryCount()
        {
            return GetViewCKProductCategoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewCKProductCategory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewCKProductCategoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewCKProductCategory] " + where;

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
		/// Gets a collection ViewCKProductCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewCKProductCategory objects.</returns>
		protected static EntityList<ViewCKProductCategory> GetViewCKProductCategories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCKProductCategories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProductCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewCKProductCategory objects.</returns>
		protected static EntityList<ViewCKProductCategory> GetViewCKProductCategories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCKProductCategories(string.Empty, where, parameters, ViewCKProductCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProductCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewCKProductCategory objects.</returns>
		protected static EntityList<ViewCKProductCategory> GetViewCKProductCategories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCKProductCategories(prefix, where, parameters, ViewCKProductCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProductCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewCKProductCategory objects.</returns>
		protected static EntityList<ViewCKProductCategory> GetViewCKProductCategories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewCKProductCategories(string.Empty, where, parameters, ViewCKProductCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProductCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewCKProductCategory objects.</returns>
		protected static EntityList<ViewCKProductCategory> GetViewCKProductCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewCKProductCategories(prefix, where, parameters, ViewCKProductCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProductCategory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewCKProductCategory objects.</returns>
		protected static EntityList<ViewCKProductCategory> GetViewCKProductCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewCKProductCategory.SelectFieldList + "FROM [dbo].[ViewCKProductCategory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewCKProductCategory>(reader);
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
        protected static EntityList<ViewCKProductCategory> GetViewCKProductCategories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCKProductCategory>(SelectFieldList, "FROM [dbo].[ViewCKProductCategory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewCKProductCategoryProperties
		{
			public const string ID = "ID";
			public const string CategoryID = "CategoryID";
			public const string ProductNumber = "ProductNumber";
			public const string ProductName = "ProductName";
			public const string Unit = "Unit";
			public const string ModelNumber = "ModelNumber";
			public const string InventoryMin = "InventoryMin";
			public const string InventoryMax = "InventoryMax";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string ProductUnitPrice = "ProductUnitPrice";
			public const string ProductCategoryName = "ProductCategoryName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CategoryID" , "int:"},
    			 {"ProductNumber" , "string:"},
    			 {"ProductName" , "string:"},
    			 {"Unit" , "string:"},
    			 {"ModelNumber" , "string:"},
    			 {"InventoryMin" , "int:"},
    			 {"InventoryMax" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"ProductUnitPrice" , "decimal:"},
    			 {"ProductCategoryName" , "string:"},
            };
		}
		#endregion
	}
}
