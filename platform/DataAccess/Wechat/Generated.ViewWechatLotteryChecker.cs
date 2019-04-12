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
	/// This object represents the properties and methods of a ViewWechatLotteryChecker.
	/// </summary>
	[Serializable()]
	public partial class ViewWechatLotteryChecker 
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
		private int _userID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int UserID
		{
			[DebuggerStepThrough()]
			get { return this._userID; }
            protected set { this._userID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _loginName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string LoginName
		{
			[DebuggerStepThrough()]
			get { return this._loginName; }
            protected set { this._loginName = value;}
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
		private string _headImg = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string HeadImg
		{
			[DebuggerStepThrough()]
			get { return this._headImg; }
            protected set { this._headImg = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _realName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RealName
		{
			[DebuggerStepThrough()]
			get { return this._realName; }
            protected set { this._realName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _openID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OpenID
		{
			[DebuggerStepThrough()]
			get { return this._openID; }
            protected set { this._openID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _gender = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Gender
		{
			[DebuggerStepThrough()]
			get { return this._gender; }
            protected set { this._gender = value;}
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
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewWechatLotteryChecker() { }
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
	[ViewWechatLotteryChecker].[ID],
	[ViewWechatLotteryChecker].[ActivityID],
	[ViewWechatLotteryChecker].[UserID],
	[ViewWechatLotteryChecker].[LoginName],
	[ViewWechatLotteryChecker].[PhoneNumber],
	[ViewWechatLotteryChecker].[HeadImg],
	[ViewWechatLotteryChecker].[RealName],
	[ViewWechatLotteryChecker].[OpenID],
	[ViewWechatLotteryChecker].[Gender],
	[ViewWechatLotteryChecker].[NickName],
	[ViewWechatLotteryChecker].[HeadImgUrl]
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
                return "ViewWechatLotteryChecker";
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
		/// Gets a collection ViewWechatLotteryChecker objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewWechatLotteryChecker objects.</returns>
		public static EntityList<ViewWechatLotteryChecker> GetViewWechatLotteryCheckers()
		{
			string commandText = @"
SELECT " + ViewWechatLotteryChecker.SelectFieldList + "FROM [dbo].[ViewWechatLotteryChecker] " + ViewWechatLotteryChecker.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewWechatLotteryChecker>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewWechatLotteryChecker objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewWechatLotteryChecker objects.</returns>
        public static EntityList<ViewWechatLotteryChecker> GetViewWechatLotteryCheckers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewWechatLotteryChecker>(SelectFieldList, "FROM [dbo].[ViewWechatLotteryChecker]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewWechatLotteryChecker objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewWechatLotteryChecker objects.</returns>
        public static EntityList<ViewWechatLotteryChecker> GetViewWechatLotteryCheckers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewWechatLotteryChecker>(SelectFieldList, "FROM [dbo].[ViewWechatLotteryChecker]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewWechatLotteryChecker objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewWechatLotteryCheckerCount()
        {
            return GetViewWechatLotteryCheckerCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewWechatLotteryChecker objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewWechatLotteryCheckerCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewWechatLotteryChecker] " + where;

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
		/// Gets a collection ViewWechatLotteryChecker objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewWechatLotteryChecker objects.</returns>
		protected static EntityList<ViewWechatLotteryChecker> GetViewWechatLotteryCheckers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewWechatLotteryCheckers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatLotteryChecker objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewWechatLotteryChecker objects.</returns>
		protected static EntityList<ViewWechatLotteryChecker> GetViewWechatLotteryCheckers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewWechatLotteryCheckers(string.Empty, where, parameters, ViewWechatLotteryChecker.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatLotteryChecker objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewWechatLotteryChecker objects.</returns>
		protected static EntityList<ViewWechatLotteryChecker> GetViewWechatLotteryCheckers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewWechatLotteryCheckers(prefix, where, parameters, ViewWechatLotteryChecker.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatLotteryChecker objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewWechatLotteryChecker objects.</returns>
		protected static EntityList<ViewWechatLotteryChecker> GetViewWechatLotteryCheckers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewWechatLotteryCheckers(string.Empty, where, parameters, ViewWechatLotteryChecker.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatLotteryChecker objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewWechatLotteryChecker objects.</returns>
		protected static EntityList<ViewWechatLotteryChecker> GetViewWechatLotteryCheckers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewWechatLotteryCheckers(prefix, where, parameters, ViewWechatLotteryChecker.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatLotteryChecker objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewWechatLotteryChecker objects.</returns>
		protected static EntityList<ViewWechatLotteryChecker> GetViewWechatLotteryCheckers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewWechatLotteryChecker.SelectFieldList + "FROM [dbo].[ViewWechatLotteryChecker] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewWechatLotteryChecker>(reader);
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
        protected static EntityList<ViewWechatLotteryChecker> GetViewWechatLotteryCheckers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewWechatLotteryChecker>(SelectFieldList, "FROM [dbo].[ViewWechatLotteryChecker] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewWechatLotteryCheckerProperties
		{
			public const string ID = "ID";
			public const string ActivityID = "ActivityID";
			public const string UserID = "UserID";
			public const string LoginName = "LoginName";
			public const string PhoneNumber = "PhoneNumber";
			public const string HeadImg = "HeadImg";
			public const string RealName = "RealName";
			public const string OpenID = "OpenID";
			public const string Gender = "Gender";
			public const string NickName = "NickName";
			public const string HeadImgUrl = "HeadImgUrl";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ActivityID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"LoginName" , "string:"},
    			 {"PhoneNumber" , "string:"},
    			 {"HeadImg" , "string:"},
    			 {"RealName" , "string:"},
    			 {"OpenID" , "string:"},
    			 {"Gender" , "string:"},
    			 {"NickName" , "string:"},
    			 {"HeadImgUrl" , "string:"},
            };
		}
		#endregion
	}
}
