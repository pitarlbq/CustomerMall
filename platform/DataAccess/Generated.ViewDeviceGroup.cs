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
	/// This object represents the properties and methods of a ViewDeviceGroup.
	/// </summary>
	[Serializable()]
	public partial class ViewDeviceGroup 
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
		private string _deviceGroupName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DeviceGroupName
		{
			[DebuggerStepThrough()]
			get { return this._deviceGroupName; }
            protected set { this._deviceGroupName = value;}
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
		private string _code = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Code
		{
			[DebuggerStepThrough()]
			get { return this._code; }
            protected set { this._code = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _repairUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RepairUserID
		{
			[DebuggerStepThrough()]
			get { return this._repairUserID; }
            protected set { this._repairUserID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _checkUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CheckUserID
		{
			[DebuggerStepThrough()]
			get { return this._checkUserID; }
            protected set { this._checkUserID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _description = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Description
		{
			[DebuggerStepThrough()]
			get { return this._description; }
            protected set { this._description = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _repairUserMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RepairUserMan
		{
			[DebuggerStepThrough()]
			get { return this._repairUserMan; }
            protected set { this._repairUserMan = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _checkUserMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CheckUserMan
		{
			[DebuggerStepThrough()]
			get { return this._checkUserMan; }
            protected set { this._checkUserMan = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewDeviceGroup() { }
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
	[ViewDeviceGroup].[ID],
	[ViewDeviceGroup].[DeviceGroupName],
	[ViewDeviceGroup].[AddTime],
	[ViewDeviceGroup].[Code],
	[ViewDeviceGroup].[RepairUserID],
	[ViewDeviceGroup].[CheckUserID],
	[ViewDeviceGroup].[Description],
	[ViewDeviceGroup].[RepairUserMan],
	[ViewDeviceGroup].[CheckUserMan]
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
                return "ViewDeviceGroup";
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
		/// Gets a collection ViewDeviceGroup objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewDeviceGroup objects.</returns>
		public static EntityList<ViewDeviceGroup> GetViewDeviceGroups()
		{
			string commandText = @"
SELECT " + ViewDeviceGroup.SelectFieldList + "FROM [dbo].[ViewDeviceGroup] " + ViewDeviceGroup.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewDeviceGroup>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewDeviceGroup objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewDeviceGroup objects.</returns>
        public static EntityList<ViewDeviceGroup> GetViewDeviceGroups(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewDeviceGroup>(SelectFieldList, "FROM [dbo].[ViewDeviceGroup]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewDeviceGroup objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewDeviceGroup objects.</returns>
        public static EntityList<ViewDeviceGroup> GetViewDeviceGroups(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewDeviceGroup>(SelectFieldList, "FROM [dbo].[ViewDeviceGroup]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewDeviceGroup objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewDeviceGroupCount()
        {
            return GetViewDeviceGroupCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewDeviceGroup objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewDeviceGroupCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewDeviceGroup] " + where;

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
		/// Gets a collection ViewDeviceGroup objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewDeviceGroup objects.</returns>
		protected static EntityList<ViewDeviceGroup> GetViewDeviceGroups(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewDeviceGroups(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewDeviceGroup objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewDeviceGroup objects.</returns>
		protected static EntityList<ViewDeviceGroup> GetViewDeviceGroups(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewDeviceGroups(string.Empty, where, parameters, ViewDeviceGroup.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewDeviceGroup objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewDeviceGroup objects.</returns>
		protected static EntityList<ViewDeviceGroup> GetViewDeviceGroups(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewDeviceGroups(prefix, where, parameters, ViewDeviceGroup.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewDeviceGroup objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewDeviceGroup objects.</returns>
		protected static EntityList<ViewDeviceGroup> GetViewDeviceGroups(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewDeviceGroups(string.Empty, where, parameters, ViewDeviceGroup.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewDeviceGroup objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewDeviceGroup objects.</returns>
		protected static EntityList<ViewDeviceGroup> GetViewDeviceGroups(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewDeviceGroups(prefix, where, parameters, ViewDeviceGroup.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewDeviceGroup objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewDeviceGroup objects.</returns>
		protected static EntityList<ViewDeviceGroup> GetViewDeviceGroups(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewDeviceGroup.SelectFieldList + "FROM [dbo].[ViewDeviceGroup] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewDeviceGroup>(reader);
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
        protected static EntityList<ViewDeviceGroup> GetViewDeviceGroups(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewDeviceGroup>(SelectFieldList, "FROM [dbo].[ViewDeviceGroup] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewDeviceGroupProperties
		{
			public const string ID = "ID";
			public const string DeviceGroupName = "DeviceGroupName";
			public const string AddTime = "AddTime";
			public const string Code = "Code";
			public const string RepairUserID = "RepairUserID";
			public const string CheckUserID = "CheckUserID";
			public const string Description = "Description";
			public const string RepairUserMan = "RepairUserMan";
			public const string CheckUserMan = "CheckUserMan";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"DeviceGroupName" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"Code" , "string:"},
    			 {"RepairUserID" , "int:"},
    			 {"CheckUserID" , "int:"},
    			 {"Description" , "string:"},
    			 {"RepairUserMan" , "string:"},
    			 {"CheckUserMan" , "string:"},
            };
		}
		#endregion
	}
}
