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
	/// This object represents the properties and methods of a ViewPayService.
	/// </summary>
	[Serializable()]
	public partial class ViewPayService 
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
		private int _projectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ProjectID
		{
			[DebuggerStepThrough()]
			get { return this._projectID; }
            protected set { this._projectID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _projectName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProjectName
		{
			[DebuggerStepThrough()]
			get { return this._projectName; }
            protected set { this._projectName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _paySummaryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int PaySummaryID
		{
			[DebuggerStepThrough()]
			get { return this._paySummaryID; }
            protected set { this._paySummaryID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _payMoney = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal PayMoney
		{
			[DebuggerStepThrough()]
			get { return this._payMoney; }
            protected set { this._payMoney = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _payTypeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PayTypeID
		{
			[DebuggerStepThrough()]
			get { return this._payTypeID; }
            protected set { this._payTypeID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _payType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PayType
		{
			[DebuggerStepThrough()]
			get { return this._payType; }
            protected set { this._payType = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _accountType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AccountType
		{
			[DebuggerStepThrough()]
			get { return this._accountType; }
            protected set { this._accountType = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _payTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime PayTime
		{
			[DebuggerStepThrough()]
			get { return this._payTime; }
            protected set { this._payTime = value;}
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
		private int _addManID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int AddManID
		{
			[DebuggerStepThrough()]
			get { return this._addManID; }
            protected set { this._addManID = value;}
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
            protected set { this._roomName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _modifyTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ModifyTime
		{
			[DebuggerStepThrough()]
			get { return this._modifyTime; }
            protected set { this._modifyTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _modifyMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ModifyMan
		{
			[DebuggerStepThrough()]
			get { return this._modifyMan; }
            protected set { this._modifyMan = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _modifyManID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ModifyManID
		{
			[DebuggerStepThrough()]
			get { return this._modifyManID; }
            protected set { this._modifyManID = value;}
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _payName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PayName
		{
			[DebuggerStepThrough()]
			get { return this._payName; }
            protected set { this._payName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _status = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Status
		{
			[DebuggerStepThrough()]
			get { return this._status; }
            protected set { this._status = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewPayService() { }
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
	[ViewPayService].[ID],
	[ViewPayService].[ProjectID],
	[ViewPayService].[ProjectName],
	[ViewPayService].[PaySummaryID],
	[ViewPayService].[PayMoney],
	[ViewPayService].[PayTypeID],
	[ViewPayService].[PayType],
	[ViewPayService].[AccountType],
	[ViewPayService].[PayTime],
	[ViewPayService].[AddTime],
	[ViewPayService].[AddMan],
	[ViewPayService].[AddManID],
	[ViewPayService].[RoomName],
	[ViewPayService].[ModifyTime],
	[ViewPayService].[ModifyMan],
	[ViewPayService].[ModifyManID],
	[ViewPayService].[Remark],
	[ViewPayService].[PayName],
	[ViewPayService].[Status]
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
                return "ViewPayService";
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
		/// Gets a collection ViewPayService objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewPayService objects.</returns>
		public static EntityList<ViewPayService> GetViewPayServices()
		{
			string commandText = @"
SELECT " + ViewPayService.SelectFieldList + "FROM [dbo].[ViewPayService] " + ViewPayService.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewPayService>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewPayService objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewPayService objects.</returns>
        public static EntityList<ViewPayService> GetViewPayServices(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewPayService>(SelectFieldList, "FROM [dbo].[ViewPayService]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewPayService objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewPayService objects.</returns>
        public static EntityList<ViewPayService> GetViewPayServices(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewPayService>(SelectFieldList, "FROM [dbo].[ViewPayService]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewPayService objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewPayServiceCount()
        {
            return GetViewPayServiceCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewPayService objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewPayServiceCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewPayService] " + where;

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
		/// Gets a collection ViewPayService objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewPayService objects.</returns>
		protected static EntityList<ViewPayService> GetViewPayServices(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewPayServices(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewPayService objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewPayService objects.</returns>
		protected static EntityList<ViewPayService> GetViewPayServices(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewPayServices(string.Empty, where, parameters, ViewPayService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewPayService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewPayService objects.</returns>
		protected static EntityList<ViewPayService> GetViewPayServices(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewPayServices(prefix, where, parameters, ViewPayService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewPayService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewPayService objects.</returns>
		protected static EntityList<ViewPayService> GetViewPayServices(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewPayServices(string.Empty, where, parameters, ViewPayService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewPayService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewPayService objects.</returns>
		protected static EntityList<ViewPayService> GetViewPayServices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewPayServices(prefix, where, parameters, ViewPayService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewPayService objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewPayService objects.</returns>
		protected static EntityList<ViewPayService> GetViewPayServices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewPayService.SelectFieldList + "FROM [dbo].[ViewPayService] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewPayService>(reader);
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
        protected static EntityList<ViewPayService> GetViewPayServices(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewPayService>(SelectFieldList, "FROM [dbo].[ViewPayService] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewPayServiceProperties
		{
			public const string ID = "ID";
			public const string ProjectID = "ProjectID";
			public const string ProjectName = "ProjectName";
			public const string PaySummaryID = "PaySummaryID";
			public const string PayMoney = "PayMoney";
			public const string PayTypeID = "PayTypeID";
			public const string PayType = "PayType";
			public const string AccountType = "AccountType";
			public const string PayTime = "PayTime";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string AddManID = "AddManID";
			public const string RoomName = "RoomName";
			public const string ModifyTime = "ModifyTime";
			public const string ModifyMan = "ModifyMan";
			public const string ModifyManID = "ModifyManID";
			public const string Remark = "Remark";
			public const string PayName = "PayName";
			public const string Status = "Status";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProjectID" , "int:"},
    			 {"ProjectName" , "string:"},
    			 {"PaySummaryID" , "int:"},
    			 {"PayMoney" , "decimal:"},
    			 {"PayTypeID" , "int:"},
    			 {"PayType" , "string:"},
    			 {"AccountType" , "string:"},
    			 {"PayTime" , "DateTime:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"AddManID" , "int:"},
    			 {"RoomName" , "string:"},
    			 {"ModifyTime" , "DateTime:"},
    			 {"ModifyMan" , "string:"},
    			 {"ModifyManID" , "int:"},
    			 {"Remark" , "string:"},
    			 {"PayName" , "string:"},
    			 {"Status" , "int:"},
            };
		}
		#endregion
	}
}
