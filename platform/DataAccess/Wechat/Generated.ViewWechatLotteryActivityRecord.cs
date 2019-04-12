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
	/// This object represents the properties and methods of a ViewWechatLotteryActivityRecord.
	/// </summary>
	[Serializable()]
	public partial class ViewWechatLotteryActivityRecord 
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
		private string _openID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string OpenID
		{
			[DebuggerStepThrough()]
			get { return this._openID; }
            protected set { this._openID = value;}
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
		private int _prizeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int PrizeID
		{
			[DebuggerStepThrough()]
			get { return this._prizeID; }
            protected set { this._prizeID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _recordTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime RecordTime
		{
			[DebuggerStepThrough()]
			get { return this._recordTime; }
            protected set { this._recordTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _billNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BillNumber
		{
			[DebuggerStepThrough()]
			get { return this._billNumber; }
            protected set { this._billNumber = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _sendTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime SendTime
		{
			[DebuggerStepThrough()]
			get { return this._sendTime; }
            protected set { this._sendTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sendResult = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SendResult
		{
			[DebuggerStepThrough()]
			get { return this._sendResult; }
            protected set { this._sendResult = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _completeSend = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool CompleteSend
		{
			[DebuggerStepThrough()]
			get { return this._completeSend; }
            protected set { this._completeSend = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _levelName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string LevelName
		{
			[DebuggerStepThrough()]
			get { return this._levelName; }
            protected set { this._levelName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _prizeName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
		[DataObjectField(false, false, true)]
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
		[DataObjectField(false, false, true)]
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
		[DataObjectField(false, false, true)]
		public string Type
		{
			[DebuggerStepThrough()]
			get { return this._type; }
            protected set { this._type = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _activityName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string ActivityName
		{
			[DebuggerStepThrough()]
			get { return this._activityName; }
            protected set { this._activityName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _merchantName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string MerchantName
		{
			[DebuggerStepThrough()]
			get { return this._merchantName; }
            protected set { this._merchantName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _headImgUrl = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string HeadImgUrl
		{
			[DebuggerStepThrough()]
			get { return this._headImgUrl; }
            protected set { this._headImgUrl = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _nickName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string NickName
		{
			[DebuggerStepThrough()]
			get { return this._nickName; }
            protected set { this._nickName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sender = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Sender
		{
			[DebuggerStepThrough()]
			get { return this._sender; }
            protected set { this._sender = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewWechatLotteryActivityRecord() { }
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
	[ViewWechatLotteryActivityRecord].[ID],
	[ViewWechatLotteryActivityRecord].[OpenID],
	[ViewWechatLotteryActivityRecord].[ActivityID],
	[ViewWechatLotteryActivityRecord].[PrizeID],
	[ViewWechatLotteryActivityRecord].[RecordTime],
	[ViewWechatLotteryActivityRecord].[BillNumber],
	[ViewWechatLotteryActivityRecord].[SendTime],
	[ViewWechatLotteryActivityRecord].[SendResult],
	[ViewWechatLotteryActivityRecord].[CompleteSend],
	[ViewWechatLotteryActivityRecord].[LevelName],
	[ViewWechatLotteryActivityRecord].[PrizeName],
	[ViewWechatLotteryActivityRecord].[PrizeQuantity],
	[ViewWechatLotteryActivityRecord].[PrizeUnit],
	[ViewWechatLotteryActivityRecord].[Type],
	[ViewWechatLotteryActivityRecord].[ActivityName],
	[ViewWechatLotteryActivityRecord].[MerchantName],
	[ViewWechatLotteryActivityRecord].[HeadImgUrl],
	[ViewWechatLotteryActivityRecord].[NickName],
	[ViewWechatLotteryActivityRecord].[Sender]
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
                return "ViewWechatLotteryActivityRecord";
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
		/// Gets a collection ViewWechatLotteryActivityRecord objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewWechatLotteryActivityRecord objects.</returns>
		public static EntityList<ViewWechatLotteryActivityRecord> GetViewWechatLotteryActivityRecords()
		{
			string commandText = @"
SELECT " + ViewWechatLotteryActivityRecord.SelectFieldList + "FROM [dbo].[ViewWechatLotteryActivityRecord] " + ViewWechatLotteryActivityRecord.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewWechatLotteryActivityRecord>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewWechatLotteryActivityRecord objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewWechatLotteryActivityRecord objects.</returns>
        public static EntityList<ViewWechatLotteryActivityRecord> GetViewWechatLotteryActivityRecords(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewWechatLotteryActivityRecord>(SelectFieldList, "FROM [dbo].[ViewWechatLotteryActivityRecord]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewWechatLotteryActivityRecord objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewWechatLotteryActivityRecord objects.</returns>
        public static EntityList<ViewWechatLotteryActivityRecord> GetViewWechatLotteryActivityRecords(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewWechatLotteryActivityRecord>(SelectFieldList, "FROM [dbo].[ViewWechatLotteryActivityRecord]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewWechatLotteryActivityRecord objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewWechatLotteryActivityRecordCount()
        {
            return GetViewWechatLotteryActivityRecordCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewWechatLotteryActivityRecord objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewWechatLotteryActivityRecordCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewWechatLotteryActivityRecord] " + where;

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
		/// Gets a collection ViewWechatLotteryActivityRecord objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewWechatLotteryActivityRecord objects.</returns>
		protected static EntityList<ViewWechatLotteryActivityRecord> GetViewWechatLotteryActivityRecords(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewWechatLotteryActivityRecords(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatLotteryActivityRecord objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewWechatLotteryActivityRecord objects.</returns>
		protected static EntityList<ViewWechatLotteryActivityRecord> GetViewWechatLotteryActivityRecords(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewWechatLotteryActivityRecords(string.Empty, where, parameters, ViewWechatLotteryActivityRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatLotteryActivityRecord objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewWechatLotteryActivityRecord objects.</returns>
		protected static EntityList<ViewWechatLotteryActivityRecord> GetViewWechatLotteryActivityRecords(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewWechatLotteryActivityRecords(prefix, where, parameters, ViewWechatLotteryActivityRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatLotteryActivityRecord objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewWechatLotteryActivityRecord objects.</returns>
		protected static EntityList<ViewWechatLotteryActivityRecord> GetViewWechatLotteryActivityRecords(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewWechatLotteryActivityRecords(string.Empty, where, parameters, ViewWechatLotteryActivityRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatLotteryActivityRecord objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewWechatLotteryActivityRecord objects.</returns>
		protected static EntityList<ViewWechatLotteryActivityRecord> GetViewWechatLotteryActivityRecords(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewWechatLotteryActivityRecords(prefix, where, parameters, ViewWechatLotteryActivityRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatLotteryActivityRecord objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewWechatLotteryActivityRecord objects.</returns>
		protected static EntityList<ViewWechatLotteryActivityRecord> GetViewWechatLotteryActivityRecords(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewWechatLotteryActivityRecord.SelectFieldList + "FROM [dbo].[ViewWechatLotteryActivityRecord] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewWechatLotteryActivityRecord>(reader);
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
        protected static EntityList<ViewWechatLotteryActivityRecord> GetViewWechatLotteryActivityRecords(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewWechatLotteryActivityRecord>(SelectFieldList, "FROM [dbo].[ViewWechatLotteryActivityRecord] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewWechatLotteryActivityRecordProperties
		{
			public const string ID = "ID";
			public const string OpenID = "OpenID";
			public const string ActivityID = "ActivityID";
			public const string PrizeID = "PrizeID";
			public const string RecordTime = "RecordTime";
			public const string BillNumber = "BillNumber";
			public const string SendTime = "SendTime";
			public const string SendResult = "SendResult";
			public const string CompleteSend = "CompleteSend";
			public const string LevelName = "LevelName";
			public const string PrizeName = "PrizeName";
			public const string PrizeQuantity = "PrizeQuantity";
			public const string PrizeUnit = "PrizeUnit";
			public const string Type = "Type";
			public const string ActivityName = "ActivityName";
			public const string MerchantName = "MerchantName";
			public const string HeadImgUrl = "HeadImgUrl";
			public const string NickName = "NickName";
			public const string Sender = "Sender";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OpenID" , "string:"},
    			 {"ActivityID" , "int:"},
    			 {"PrizeID" , "int:"},
    			 {"RecordTime" , "DateTime:"},
    			 {"BillNumber" , "string:"},
    			 {"SendTime" , "DateTime:"},
    			 {"SendResult" , "string:"},
    			 {"CompleteSend" , "bool:"},
    			 {"LevelName" , "string:"},
    			 {"PrizeName" , "string:"},
    			 {"PrizeQuantity" , "decimal:"},
    			 {"PrizeUnit" , "string:"},
    			 {"Type" , "string:"},
    			 {"ActivityName" , "string:"},
    			 {"MerchantName" , "string:"},
    			 {"HeadImgUrl" , "string:"},
    			 {"NickName" , "string:"},
    			 {"Sender" , "string:"},
            };
		}
		#endregion
	}
}
