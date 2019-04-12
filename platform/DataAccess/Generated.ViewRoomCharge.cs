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
	/// This object represents the properties and methods of a ViewRoomCharge.
	/// </summary>
	[Serializable()]
	public partial class ViewRoomCharge 
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
		private string _name = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Name
		{
			[DebuggerStepThrough()]
			get { return this._name; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _companyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CompanyID
		{
			[DebuggerStepThrough()]
			get { return this._companyID; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _orderBy = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OrderBy
		{
			[DebuggerStepThrough()]
			get { return this._orderBy; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isStart = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsStart
		{
			[DebuggerStepThrough()]
			get { return this._isStart; }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _feeType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int FeeType
		{
			[DebuggerStepThrough()]
			get { return this._feeType; }
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewRoomCharge() { }
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
	[ViewRoomCharge].[ID],
	[ViewRoomCharge].[RoomID],
	[ViewRoomCharge].[Name],
	[ViewRoomCharge].[CompanyID],
	[ViewRoomCharge].[OrderBy],
	[ViewRoomCharge].[IsStart],
	[ViewRoomCharge].[FeeType]
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
                return "ViewRoomCharge";
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
		/// Gets a collection ViewRoomCharge objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewRoomCharge objects.</returns>
		public static EntityList<ViewRoomCharge> GetViewRoomCharges()
		{
			string commandText = @"
SELECT " + ViewRoomCharge.SelectFieldList + "FROM [dbo].[ViewRoomCharge] " + ViewRoomCharge.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewRoomCharge>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewRoomCharge objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewRoomCharge objects.</returns>
        public static EntityList<ViewRoomCharge> GetViewRoomCharges(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewRoomCharge>(SelectFieldList, "FROM [dbo].[ViewRoomCharge]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewRoomCharge objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewRoomCharge objects.</returns>
        public static EntityList<ViewRoomCharge> GetViewRoomCharges(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewRoomCharge>(SelectFieldList, "FROM [dbo].[ViewRoomCharge]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ViewRoomCharge objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewRoomCharge objects.</returns>
		protected static EntityList<ViewRoomCharge> GetViewRoomCharges(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewRoomCharges(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomCharge objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomCharge objects.</returns>
		protected static EntityList<ViewRoomCharge> GetViewRoomCharges(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewRoomCharges(string.Empty, where, parameters, ViewRoomCharge.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomCharge objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomCharge objects.</returns>
		protected static EntityList<ViewRoomCharge> GetViewRoomCharges(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewRoomCharges(prefix, where, parameters, ViewRoomCharge.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomCharge objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomCharge objects.</returns>
		protected static EntityList<ViewRoomCharge> GetViewRoomCharges(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewRoomCharges(string.Empty, where, parameters, ViewRoomCharge.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomCharge objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomCharge objects.</returns>
		protected static EntityList<ViewRoomCharge> GetViewRoomCharges(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewRoomCharges(prefix, where, parameters, ViewRoomCharge.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomCharge objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewRoomCharge objects.</returns>
		protected static EntityList<ViewRoomCharge> GetViewRoomCharges(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewRoomCharge.SelectFieldList + "FROM [dbo].[ViewRoomCharge] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewRoomCharge>(reader);
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
        protected static EntityList<ViewRoomCharge> GetViewRoomCharges(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewRoomCharge>(SelectFieldList, "FROM [dbo].[ViewRoomCharge] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewRoomChargeProperties
		{
			public const string ID = "ID";
			public const string RoomID = "RoomID";
			public const string Name = "Name";
			public const string CompanyID = "CompanyID";
			public const string OrderBy = "OrderBy";
			public const string IsStart = "IsStart";
			public const string FeeType = "FeeType";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"Name" , "string:"},
    			 {"CompanyID" , "int:"},
    			 {"OrderBy" , "int:"},
    			 {"IsStart" , "bool:"},
    			 {"FeeType" , "int:"},
            };
		}
		#endregion
	}
}
