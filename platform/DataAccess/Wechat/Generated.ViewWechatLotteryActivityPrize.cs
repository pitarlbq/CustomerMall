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
	/// This object represents the properties and methods of a ViewWechatLotteryActivityPrize.
	/// </summary>
	[Serializable()]
	public partial class ViewWechatLotteryActivityPrize 
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
		private int _activityID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ActivityID
		{
			[DebuggerStepThrough()]
			get { return this._activityID; }
            protected set { this._activityID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _levelName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string LevelName
		{
			[DebuggerStepThrough()]
			get { return this._levelName; }
            protected set { this._levelName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _quota = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int Quota
		{
			[DebuggerStepThrough()]
			get { return this._quota; }
            protected set { this._quota = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _prizeName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string PrizeName
		{
			[DebuggerStepThrough()]
			get { return this._prizeName; }
            protected set { this._prizeName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _prizeQuantity = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal PrizeQuantity
		{
			[DebuggerStepThrough()]
			get { return this._prizeQuantity; }
            protected set { this._prizeQuantity = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _prizeUnit = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string PrizeUnit
		{
			[DebuggerStepThrough()]
			get { return this._prizeUnit; }
            protected set { this._prizeUnit = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _type = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string Type
		{
			[DebuggerStepThrough()]
			get { return this._type; }
            protected set { this._type = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _sortOrder = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SortOrder
		{
			[DebuggerStepThrough()]
			get { return this._sortOrder; }
            protected set { this._sortOrder = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _recordCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RecordCount
		{
			[DebuggerStepThrough()]
			get { return this._recordCount; }
            protected set { this._recordCount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _repeatTime = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RepeatTime
		{
			[DebuggerStepThrough()]
			get { return this._repeatTime; }
            protected set { this._repeatTime = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewWechatLotteryActivityPrize() { }
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
	[ViewWechatLotteryActivityPrize].[ID],
	[ViewWechatLotteryActivityPrize].[ActivityID],
	[ViewWechatLotteryActivityPrize].[LevelName],
	[ViewWechatLotteryActivityPrize].[Quota],
	[ViewWechatLotteryActivityPrize].[PrizeName],
	[ViewWechatLotteryActivityPrize].[PrizeQuantity],
	[ViewWechatLotteryActivityPrize].[PrizeUnit],
	[ViewWechatLotteryActivityPrize].[Type],
	[ViewWechatLotteryActivityPrize].[SortOrder],
	[ViewWechatLotteryActivityPrize].[RecordCount],
	[ViewWechatLotteryActivityPrize].[RepeatTime]
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
                return "ViewWechatLotteryActivityPrize";
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
		/// Gets a collection ViewWechatLotteryActivityPrize objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewWechatLotteryActivityPrize objects.</returns>
		public static EntityList<ViewWechatLotteryActivityPrize> GetViewWechatLotteryActivityPrizes()
		{
			string commandText = @"
SELECT " + ViewWechatLotteryActivityPrize.SelectFieldList + "FROM [dbo].[ViewWechatLotteryActivityPrize] " + ViewWechatLotteryActivityPrize.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewWechatLotteryActivityPrize>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewWechatLotteryActivityPrize objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewWechatLotteryActivityPrize objects.</returns>
        public static EntityList<ViewWechatLotteryActivityPrize> GetViewWechatLotteryActivityPrizes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewWechatLotteryActivityPrize>(SelectFieldList, "FROM [dbo].[ViewWechatLotteryActivityPrize]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewWechatLotteryActivityPrize objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewWechatLotteryActivityPrize objects.</returns>
        public static EntityList<ViewWechatLotteryActivityPrize> GetViewWechatLotteryActivityPrizes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewWechatLotteryActivityPrize>(SelectFieldList, "FROM [dbo].[ViewWechatLotteryActivityPrize]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewWechatLotteryActivityPrize objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewWechatLotteryActivityPrizeCount()
        {
            return GetViewWechatLotteryActivityPrizeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewWechatLotteryActivityPrize objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewWechatLotteryActivityPrizeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewWechatLotteryActivityPrize] " + where;

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
		/// Gets a collection ViewWechatLotteryActivityPrize objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewWechatLotteryActivityPrize objects.</returns>
		protected static EntityList<ViewWechatLotteryActivityPrize> GetViewWechatLotteryActivityPrizes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewWechatLotteryActivityPrizes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatLotteryActivityPrize objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewWechatLotteryActivityPrize objects.</returns>
		protected static EntityList<ViewWechatLotteryActivityPrize> GetViewWechatLotteryActivityPrizes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewWechatLotteryActivityPrizes(string.Empty, where, parameters, ViewWechatLotteryActivityPrize.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatLotteryActivityPrize objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewWechatLotteryActivityPrize objects.</returns>
		protected static EntityList<ViewWechatLotteryActivityPrize> GetViewWechatLotteryActivityPrizes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewWechatLotteryActivityPrizes(prefix, where, parameters, ViewWechatLotteryActivityPrize.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatLotteryActivityPrize objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewWechatLotteryActivityPrize objects.</returns>
		protected static EntityList<ViewWechatLotteryActivityPrize> GetViewWechatLotteryActivityPrizes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewWechatLotteryActivityPrizes(string.Empty, where, parameters, ViewWechatLotteryActivityPrize.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatLotteryActivityPrize objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewWechatLotteryActivityPrize objects.</returns>
		protected static EntityList<ViewWechatLotteryActivityPrize> GetViewWechatLotteryActivityPrizes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewWechatLotteryActivityPrizes(prefix, where, parameters, ViewWechatLotteryActivityPrize.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatLotteryActivityPrize objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewWechatLotteryActivityPrize objects.</returns>
		protected static EntityList<ViewWechatLotteryActivityPrize> GetViewWechatLotteryActivityPrizes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewWechatLotteryActivityPrize.SelectFieldList + "FROM [dbo].[ViewWechatLotteryActivityPrize] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewWechatLotteryActivityPrize>(reader);
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
        protected static EntityList<ViewWechatLotteryActivityPrize> GetViewWechatLotteryActivityPrizes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewWechatLotteryActivityPrize>(SelectFieldList, "FROM [dbo].[ViewWechatLotteryActivityPrize] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewWechatLotteryActivityPrizeProperties
		{
			public const string ID = "ID";
			public const string ActivityID = "ActivityID";
			public const string LevelName = "LevelName";
			public const string Quota = "Quota";
			public const string PrizeName = "PrizeName";
			public const string PrizeQuantity = "PrizeQuantity";
			public const string PrizeUnit = "PrizeUnit";
			public const string Type = "Type";
			public const string SortOrder = "SortOrder";
			public const string RecordCount = "RecordCount";
			public const string RepeatTime = "RepeatTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ActivityID" , "int:"},
    			 {"LevelName" , "string:"},
    			 {"Quota" , "int:"},
    			 {"PrizeName" , "string:"},
    			 {"PrizeQuantity" , "decimal:"},
    			 {"PrizeUnit" , "string:"},
    			 {"Type" , "string:"},
    			 {"SortOrder" , "int:"},
    			 {"RecordCount" , "int:"},
    			 {"RepeatTime" , "int:"},
            };
		}
		#endregion
	}
}
