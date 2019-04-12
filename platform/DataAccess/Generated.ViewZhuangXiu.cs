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
	/// This object represents the properties and methods of a ViewZhuangXiu.
	/// </summary>
	[Serializable()]
	public partial class ViewZhuangXiu 
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
            protected set { this._roomID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _applicationMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApplicationMan
		{
			[DebuggerStepThrough()]
			get { return this._applicationMan; }
            protected set { this._applicationMan = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _phoneNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PhoneNumber
		{
			[DebuggerStepThrough()]
			get { return this._phoneNumber; }
            protected set { this._phoneNumber = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _depositPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal DepositPrice
		{
			[DebuggerStepThrough()]
			get { return this._depositPrice; }
            protected set { this._depositPrice = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _zhuangXiuType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ZhuangXiuType
		{
			[DebuggerStepThrough()]
			get { return this._zhuangXiuType; }
            protected set { this._zhuangXiuType = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _typeDesc = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TypeDesc
		{
			[DebuggerStepThrough()]
			get { return this._typeDesc; }
            protected set { this._typeDesc = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _status = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Status
		{
			[DebuggerStepThrough()]
			get { return this._status; }
            protected set { this._status = value;}
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
		private int _approveID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ApproveID
		{
			[DebuggerStepThrough()]
			get { return this._approveID; }
            protected set { this._approveID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _yanShouTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime YanShouTime
		{
			[DebuggerStepThrough()]
			get { return this._yanShouTime; }
            protected set { this._yanShouTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _yanShouMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string YanShouMan
		{
			[DebuggerStepThrough()]
			get { return this._yanShouMan; }
            protected set { this._yanShouMan = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _yanShouRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string YanShouRemark
		{
			[DebuggerStepThrough()]
			get { return this._yanShouRemark; }
            protected set { this._yanShouRemark = value;}
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
		private DateTime _confirmZXTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ConfirmZXTime
		{
			[DebuggerStepThrough()]
			get { return this._confirmZXTime; }
            protected set { this._confirmZXTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _xunJianCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int XunJianCount
		{
			[DebuggerStepThrough()]
			get { return this._xunJianCount; }
            protected set { this._xunJianCount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _approveTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ApproveTime
		{
			[DebuggerStepThrough()]
			get { return this._approveTime; }
            protected set { this._approveTime = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewZhuangXiu() { }
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
	[ViewZhuangXiu].[ID],
	[ViewZhuangXiu].[RoomID],
	[ViewZhuangXiu].[ApplicationMan],
	[ViewZhuangXiu].[PhoneNumber],
	[ViewZhuangXiu].[DepositPrice],
	[ViewZhuangXiu].[ZhuangXiuType],
	[ViewZhuangXiu].[TypeDesc],
	[ViewZhuangXiu].[Status],
	[ViewZhuangXiu].[AddTime],
	[ViewZhuangXiu].[AddMan],
	[ViewZhuangXiu].[ApproveID],
	[ViewZhuangXiu].[YanShouTime],
	[ViewZhuangXiu].[YanShouMan],
	[ViewZhuangXiu].[YanShouRemark],
	[ViewZhuangXiu].[RoomName],
	[ViewZhuangXiu].[ConfirmZXTime],
	[ViewZhuangXiu].[XunJianCount],
	[ViewZhuangXiu].[ApproveTime]
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
                return "ViewZhuangXiu";
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
		/// Gets a collection ViewZhuangXiu objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewZhuangXiu objects.</returns>
		public static EntityList<ViewZhuangXiu> GetViewZhuangXius()
		{
			string commandText = @"
SELECT " + ViewZhuangXiu.SelectFieldList + "FROM [dbo].[ViewZhuangXiu] " + ViewZhuangXiu.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewZhuangXiu>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewZhuangXiu objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewZhuangXiu objects.</returns>
        public static EntityList<ViewZhuangXiu> GetViewZhuangXius(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewZhuangXiu>(SelectFieldList, "FROM [dbo].[ViewZhuangXiu]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewZhuangXiu objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewZhuangXiu objects.</returns>
        public static EntityList<ViewZhuangXiu> GetViewZhuangXius(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewZhuangXiu>(SelectFieldList, "FROM [dbo].[ViewZhuangXiu]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewZhuangXiu objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewZhuangXiuCount()
        {
            return GetViewZhuangXiuCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewZhuangXiu objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewZhuangXiuCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewZhuangXiu] " + where;

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
		/// Gets a collection ViewZhuangXiu objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewZhuangXiu objects.</returns>
		protected static EntityList<ViewZhuangXiu> GetViewZhuangXius(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewZhuangXius(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewZhuangXiu objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewZhuangXiu objects.</returns>
		protected static EntityList<ViewZhuangXiu> GetViewZhuangXius(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewZhuangXius(string.Empty, where, parameters, ViewZhuangXiu.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewZhuangXiu objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewZhuangXiu objects.</returns>
		protected static EntityList<ViewZhuangXiu> GetViewZhuangXius(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewZhuangXius(prefix, where, parameters, ViewZhuangXiu.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewZhuangXiu objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewZhuangXiu objects.</returns>
		protected static EntityList<ViewZhuangXiu> GetViewZhuangXius(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewZhuangXius(string.Empty, where, parameters, ViewZhuangXiu.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewZhuangXiu objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewZhuangXiu objects.</returns>
		protected static EntityList<ViewZhuangXiu> GetViewZhuangXius(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewZhuangXius(prefix, where, parameters, ViewZhuangXiu.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewZhuangXiu objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewZhuangXiu objects.</returns>
		protected static EntityList<ViewZhuangXiu> GetViewZhuangXius(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewZhuangXiu.SelectFieldList + "FROM [dbo].[ViewZhuangXiu] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewZhuangXiu>(reader);
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
        protected static EntityList<ViewZhuangXiu> GetViewZhuangXius(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewZhuangXiu>(SelectFieldList, "FROM [dbo].[ViewZhuangXiu] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewZhuangXiuProperties
		{
			public const string ID = "ID";
			public const string RoomID = "RoomID";
			public const string ApplicationMan = "ApplicationMan";
			public const string PhoneNumber = "PhoneNumber";
			public const string DepositPrice = "DepositPrice";
			public const string ZhuangXiuType = "ZhuangXiuType";
			public const string TypeDesc = "TypeDesc";
			public const string Status = "Status";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string ApproveID = "ApproveID";
			public const string YanShouTime = "YanShouTime";
			public const string YanShouMan = "YanShouMan";
			public const string YanShouRemark = "YanShouRemark";
			public const string RoomName = "RoomName";
			public const string ConfirmZXTime = "ConfirmZXTime";
			public const string XunJianCount = "XunJianCount";
			public const string ApproveTime = "ApproveTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"ApplicationMan" , "string:"},
    			 {"PhoneNumber" , "string:"},
    			 {"DepositPrice" , "decimal:"},
    			 {"ZhuangXiuType" , "string:"},
    			 {"TypeDesc" , "string:"},
    			 {"Status" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"ApproveID" , "int:"},
    			 {"YanShouTime" , "DateTime:"},
    			 {"YanShouMan" , "string:"},
    			 {"YanShouRemark" , "string:"},
    			 {"RoomName" , "string:"},
    			 {"ConfirmZXTime" , "DateTime:"},
    			 {"XunJianCount" , "int:"},
    			 {"ApproveTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
