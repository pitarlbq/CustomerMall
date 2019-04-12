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
	/// This object represents the properties and methods of a ViewRoomBalance.
	/// </summary>
	[Serializable()]
	public partial class ViewRoomBalance 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalBalance = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalBalance
		{
			[DebuggerStepThrough()]
			get { return this._totalBalance; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _consumeBalance = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ConsumeBalance
		{
			[DebuggerStepThrough()]
			get { return this._consumeBalance; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalGuaranteeFee = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalGuaranteeFee
		{
			[DebuggerStepThrough()]
			get { return this._totalGuaranteeFee; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _consumeGuaranteeFee = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ConsumeGuaranteeFee
		{
			[DebuggerStepThrough()]
			get { return this._consumeGuaranteeFee; }
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewRoomBalance() { }
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
	[ViewRoomBalance].[TotalBalance],
	[ViewRoomBalance].[ConsumeBalance],
	[ViewRoomBalance].[TotalGuaranteeFee],
	[ViewRoomBalance].[ConsumeGuaranteeFee]
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
                return "ViewRoomBalance";
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
		/// Gets a collection ViewRoomBalance objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewRoomBalance objects.</returns>
		public static EntityList<ViewRoomBalance> GetViewRoomBalances()
		{
			string commandText = @"
SELECT " + ViewRoomBalance.SelectFieldList + "FROM [dbo].[ViewRoomBalance] " + ViewRoomBalance.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewRoomBalance>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewRoomBalance objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewRoomBalance objects.</returns>
        public static EntityList<ViewRoomBalance> GetViewRoomBalances(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewRoomBalance>(SelectFieldList, "FROM [dbo].[ViewRoomBalance]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewRoomBalance objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewRoomBalance objects.</returns>
        public static EntityList<ViewRoomBalance> GetViewRoomBalances(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewRoomBalance>(SelectFieldList, "FROM [dbo].[ViewRoomBalance]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ViewRoomBalance objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewRoomBalance objects.</returns>
		protected static EntityList<ViewRoomBalance> GetViewRoomBalances(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewRoomBalances(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomBalance objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomBalance objects.</returns>
		protected static EntityList<ViewRoomBalance> GetViewRoomBalances(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewRoomBalances(string.Empty, where, parameters, ViewRoomBalance.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomBalance objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomBalance objects.</returns>
		protected static EntityList<ViewRoomBalance> GetViewRoomBalances(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewRoomBalances(prefix, where, parameters, ViewRoomBalance.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomBalance objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomBalance objects.</returns>
		protected static EntityList<ViewRoomBalance> GetViewRoomBalances(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewRoomBalances(string.Empty, where, parameters, ViewRoomBalance.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomBalance objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomBalance objects.</returns>
		protected static EntityList<ViewRoomBalance> GetViewRoomBalances(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewRoomBalances(prefix, where, parameters, ViewRoomBalance.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomBalance objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewRoomBalance objects.</returns>
		protected static EntityList<ViewRoomBalance> GetViewRoomBalances(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewRoomBalance.SelectFieldList + "FROM [dbo].[ViewRoomBalance] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewRoomBalance>(reader);
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
        protected static EntityList<ViewRoomBalance> GetViewRoomBalances(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewRoomBalance>(SelectFieldList, "FROM [dbo].[ViewRoomBalance] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewRoomBalanceProperties
		{
			public const string TotalBalance = "TotalBalance";
			public const string ConsumeBalance = "ConsumeBalance";
			public const string TotalGuaranteeFee = "TotalGuaranteeFee";
			public const string ConsumeGuaranteeFee = "ConsumeGuaranteeFee";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"TotalBalance" , "decimal:"},
    			 {"ConsumeBalance" , "decimal:"},
    			 {"TotalGuaranteeFee" , "decimal:"},
    			 {"ConsumeGuaranteeFee" , "decimal:"},
            };
		}
		#endregion
	}
}
