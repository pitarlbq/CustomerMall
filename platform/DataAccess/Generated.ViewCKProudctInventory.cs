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
	/// This object represents the properties and methods of a ViewCKProudctInventory.
	/// </summary>
	[Serializable()]
	public partial class ViewCKProudctInventory 
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
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewCKProudctInventory() { }
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
	[ViewCKProudctInventory].[ID],
	[ViewCKProudctInventory].[CategoryID],
	[ViewCKProudctInventory].[ProductNumber],
	[ViewCKProudctInventory].[ProductName],
	[ViewCKProudctInventory].[Unit],
	[ViewCKProudctInventory].[ModelNumber],
	[ViewCKProudctInventory].[CategoryName],
	[ViewCKProudctInventory].[InTotalCount],
	[ViewCKProudctInventory].[InTotalPrice],
	[ViewCKProudctInventory].[OutTotalCount],
	[ViewCKProudctInventory].[OutTotalPrice]
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
                return "ViewCKProudctInventory";
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
		/// Gets a collection ViewCKProudctInventory objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewCKProudctInventory objects.</returns>
		public static EntityList<ViewCKProudctInventory> GetViewCKProudctInventories()
		{
			string commandText = @"
SELECT " + ViewCKProudctInventory.SelectFieldList + "FROM [dbo].[ViewCKProudctInventory] " + ViewCKProudctInventory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewCKProudctInventory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewCKProudctInventory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewCKProudctInventory objects.</returns>
        public static EntityList<ViewCKProudctInventory> GetViewCKProudctInventories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCKProudctInventory>(SelectFieldList, "FROM [dbo].[ViewCKProudctInventory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewCKProudctInventory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewCKProudctInventory objects.</returns>
        public static EntityList<ViewCKProudctInventory> GetViewCKProudctInventories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCKProudctInventory>(SelectFieldList, "FROM [dbo].[ViewCKProudctInventory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewCKProudctInventory objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewCKProudctInventoryCount()
        {
            return GetViewCKProudctInventoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewCKProudctInventory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewCKProudctInventoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewCKProudctInventory] " + where;

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
		/// Gets a collection ViewCKProudctInventory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewCKProudctInventory objects.</returns>
		protected static EntityList<ViewCKProudctInventory> GetViewCKProudctInventories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCKProudctInventories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProudctInventory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewCKProudctInventory objects.</returns>
		protected static EntityList<ViewCKProudctInventory> GetViewCKProudctInventories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCKProudctInventories(string.Empty, where, parameters, ViewCKProudctInventory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProudctInventory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewCKProudctInventory objects.</returns>
		protected static EntityList<ViewCKProudctInventory> GetViewCKProudctInventories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCKProudctInventories(prefix, where, parameters, ViewCKProudctInventory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProudctInventory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewCKProudctInventory objects.</returns>
		protected static EntityList<ViewCKProudctInventory> GetViewCKProudctInventories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewCKProudctInventories(string.Empty, where, parameters, ViewCKProudctInventory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProudctInventory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewCKProudctInventory objects.</returns>
		protected static EntityList<ViewCKProudctInventory> GetViewCKProudctInventories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewCKProudctInventories(prefix, where, parameters, ViewCKProudctInventory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCKProudctInventory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewCKProudctInventory objects.</returns>
		protected static EntityList<ViewCKProudctInventory> GetViewCKProudctInventories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewCKProudctInventory.SelectFieldList + "FROM [dbo].[ViewCKProudctInventory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewCKProudctInventory>(reader);
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
        protected static EntityList<ViewCKProudctInventory> GetViewCKProudctInventories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCKProudctInventory>(SelectFieldList, "FROM [dbo].[ViewCKProudctInventory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewCKProudctInventoryProperties
		{
			public const string ID = "ID";
			public const string CategoryID = "CategoryID";
			public const string ProductNumber = "ProductNumber";
			public const string ProductName = "ProductName";
			public const string Unit = "Unit";
			public const string ModelNumber = "ModelNumber";
			public const string CategoryName = "CategoryName";
			public const string InTotalCount = "InTotalCount";
			public const string InTotalPrice = "InTotalPrice";
			public const string OutTotalCount = "OutTotalCount";
			public const string OutTotalPrice = "OutTotalPrice";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CategoryID" , "int:"},
    			 {"ProductNumber" , "string:"},
    			 {"ProductName" , "string:"},
    			 {"Unit" , "string:"},
    			 {"ModelNumber" , "string:"},
    			 {"CategoryName" , "string:"},
    			 {"InTotalCount" , "int:"},
    			 {"InTotalPrice" , "decimal:"},
    			 {"OutTotalCount" , "int:"},
    			 {"OutTotalPrice" , "decimal:"},
            };
		}
		#endregion
	}
}
