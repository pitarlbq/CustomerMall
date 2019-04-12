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
	/// This object represents the properties and methods of a ViewTaiZhang.
	/// </summary>
	[Serializable()]
	public partial class ViewTaiZhang 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _fullName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FullName
		{
			[DebuggerStepThrough()]
			get { return this._fullName; }
            protected set { this._fullName = value;}
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
		private int _biaoID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int BiaoID
		{
			[DebuggerStepThrough()]
			get { return this._biaoID; }
            protected set { this._biaoID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isActive = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsActive
		{
			[DebuggerStepThrough()]
			get { return this._isActive; }
            protected set { this._isActive = value;}
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
            protected set { this._name = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _defaultOrder = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DefaultOrder
		{
			[DebuggerStepThrough()]
			get { return this._defaultOrder; }
            protected set { this._defaultOrder = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _biaoGuiGe = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BiaoGuiGe
		{
			[DebuggerStepThrough()]
			get { return this._biaoGuiGe; }
            protected set { this._biaoGuiGe = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _biaoName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BiaoName
		{
			[DebuggerStepThrough()]
			get { return this._biaoName; }
            protected set { this._biaoName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _biaoCategory = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BiaoCategory
		{
			[DebuggerStepThrough()]
			get { return this._biaoCategory; }
            protected set { this._biaoCategory = value;}
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
		private decimal _importStartPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ImportStartPoint
		{
			[DebuggerStepThrough()]
			get { return this._importStartPoint; }
            protected set { this._importStartPoint = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _importEndPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ImportEndPoint
		{
			[DebuggerStepThrough()]
			get { return this._importEndPoint; }
            protected set { this._importEndPoint = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _lastTotalPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal LastTotalPoint
		{
			[DebuggerStepThrough()]
			get { return this._lastTotalPoint; }
            protected set { this._lastTotalPoint = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _importWriteDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ImportWriteDate
		{
			[DebuggerStepThrough()]
			get { return this._importWriteDate; }
            protected set { this._importWriteDate = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _importUnitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ImportUnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._importUnitPrice; }
            protected set { this._importUnitPrice = value;}
		}
		
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
		private decimal _rate = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal Rate
		{
			[DebuggerStepThrough()]
			get { return this._rate; }
            protected set { this._rate = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _reducePoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ReducePoint
		{
			[DebuggerStepThrough()]
			get { return this._reducePoint; }
            protected set { this._reducePoint = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _startPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal StartPoint
		{
			[DebuggerStepThrough()]
			get { return this._startPoint; }
            protected set { this._startPoint = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _endPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal EndPoint
		{
			[DebuggerStepThrough()]
			get { return this._endPoint; }
            protected set { this._endPoint = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalPoint
		{
			[DebuggerStepThrough()]
			get { return this._totalPoint; }
            protected set { this._totalPoint = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChargeID
		{
			[DebuggerStepThrough()]
			get { return this._chargeID; }
            protected set { this._chargeID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeName
		{
			[DebuggerStepThrough()]
			get { return this._chargeName; }
            protected set { this._chargeName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _summaryUnitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal SummaryUnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._summaryUnitPrice; }
            protected set { this._summaryUnitPrice = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _coefficient = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal Coefficient
		{
			[DebuggerStepThrough()]
			get { return this._coefficient; }
            protected set { this._coefficient = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _endNumberCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int EndNumberCount
		{
			[DebuggerStepThrough()]
			get { return this._endNumberCount; }
            protected set { this._endNumberCount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _unitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal UnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._unitPrice; }
            protected set { this._unitPrice = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _writeDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime WriteDate
		{
			[DebuggerStepThrough()]
			get { return this._writeDate; }
            protected set { this._writeDate = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _biaoCoefficient = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal BiaoCoefficient
		{
			[DebuggerStepThrough()]
			get { return this._biaoCoefficient; }
            protected set { this._biaoCoefficient = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeRoomNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeRoomNo
		{
			[DebuggerStepThrough()]
			get { return this._chargeRoomNo; }
            protected set { this._chargeRoomNo = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewTaiZhang() { }
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
	[ViewTaiZhang].[FullName],
	[ViewTaiZhang].[ProjectID],
	[ViewTaiZhang].[BiaoID],
	[ViewTaiZhang].[IsActive],
	[ViewTaiZhang].[Name],
	[ViewTaiZhang].[DefaultOrder],
	[ViewTaiZhang].[BiaoGuiGe],
	[ViewTaiZhang].[BiaoName],
	[ViewTaiZhang].[BiaoCategory],
	[ViewTaiZhang].[Remark],
	[ViewTaiZhang].[ImportStartPoint],
	[ViewTaiZhang].[ImportEndPoint],
	[ViewTaiZhang].[LastTotalPoint],
	[ViewTaiZhang].[ImportWriteDate],
	[ViewTaiZhang].[ImportUnitPrice],
	[ViewTaiZhang].[ID],
	[ViewTaiZhang].[Rate],
	[ViewTaiZhang].[ReducePoint],
	[ViewTaiZhang].[StartPoint],
	[ViewTaiZhang].[EndPoint],
	[ViewTaiZhang].[TotalPoint],
	[ViewTaiZhang].[ChargeID],
	[ViewTaiZhang].[ChargeName],
	[ViewTaiZhang].[SummaryUnitPrice],
	[ViewTaiZhang].[Coefficient],
	[ViewTaiZhang].[EndNumberCount],
	[ViewTaiZhang].[UnitPrice],
	[ViewTaiZhang].[WriteDate],
	[ViewTaiZhang].[BiaoCoefficient],
	[ViewTaiZhang].[ChargeRoomNo]
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
                return "ViewTaiZhang";
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
		/// Gets a collection ViewTaiZhang objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewTaiZhang objects.</returns>
		public static EntityList<ViewTaiZhang> GetViewTaiZhangs()
		{
			string commandText = @"
SELECT " + ViewTaiZhang.SelectFieldList + "FROM [dbo].[ViewTaiZhang] " + ViewTaiZhang.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewTaiZhang>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewTaiZhang objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewTaiZhang objects.</returns>
        public static EntityList<ViewTaiZhang> GetViewTaiZhangs(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewTaiZhang>(SelectFieldList, "FROM [dbo].[ViewTaiZhang]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewTaiZhang objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewTaiZhang objects.</returns>
        public static EntityList<ViewTaiZhang> GetViewTaiZhangs(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewTaiZhang>(SelectFieldList, "FROM [dbo].[ViewTaiZhang]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewTaiZhang objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewTaiZhangCount()
        {
            return GetViewTaiZhangCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewTaiZhang objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewTaiZhangCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewTaiZhang] " + where;

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
		/// Gets a collection ViewTaiZhang objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewTaiZhang objects.</returns>
		protected static EntityList<ViewTaiZhang> GetViewTaiZhangs(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewTaiZhangs(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewTaiZhang objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewTaiZhang objects.</returns>
		protected static EntityList<ViewTaiZhang> GetViewTaiZhangs(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewTaiZhangs(string.Empty, where, parameters, ViewTaiZhang.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewTaiZhang objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewTaiZhang objects.</returns>
		protected static EntityList<ViewTaiZhang> GetViewTaiZhangs(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewTaiZhangs(prefix, where, parameters, ViewTaiZhang.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewTaiZhang objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewTaiZhang objects.</returns>
		protected static EntityList<ViewTaiZhang> GetViewTaiZhangs(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewTaiZhangs(string.Empty, where, parameters, ViewTaiZhang.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewTaiZhang objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewTaiZhang objects.</returns>
		protected static EntityList<ViewTaiZhang> GetViewTaiZhangs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewTaiZhangs(prefix, where, parameters, ViewTaiZhang.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewTaiZhang objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewTaiZhang objects.</returns>
		protected static EntityList<ViewTaiZhang> GetViewTaiZhangs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewTaiZhang.SelectFieldList + "FROM [dbo].[ViewTaiZhang] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewTaiZhang>(reader);
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
        protected static EntityList<ViewTaiZhang> GetViewTaiZhangs(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewTaiZhang>(SelectFieldList, "FROM [dbo].[ViewTaiZhang] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewTaiZhangProperties
		{
			public const string FullName = "FullName";
			public const string ProjectID = "ProjectID";
			public const string BiaoID = "BiaoID";
			public const string IsActive = "IsActive";
			public const string Name = "Name";
			public const string DefaultOrder = "DefaultOrder";
			public const string BiaoGuiGe = "BiaoGuiGe";
			public const string BiaoName = "BiaoName";
			public const string BiaoCategory = "BiaoCategory";
			public const string Remark = "Remark";
			public const string ImportStartPoint = "ImportStartPoint";
			public const string ImportEndPoint = "ImportEndPoint";
			public const string LastTotalPoint = "LastTotalPoint";
			public const string ImportWriteDate = "ImportWriteDate";
			public const string ImportUnitPrice = "ImportUnitPrice";
			public const string ID = "ID";
			public const string Rate = "Rate";
			public const string ReducePoint = "ReducePoint";
			public const string StartPoint = "StartPoint";
			public const string EndPoint = "EndPoint";
			public const string TotalPoint = "TotalPoint";
			public const string ChargeID = "ChargeID";
			public const string ChargeName = "ChargeName";
			public const string SummaryUnitPrice = "SummaryUnitPrice";
			public const string Coefficient = "Coefficient";
			public const string EndNumberCount = "EndNumberCount";
			public const string UnitPrice = "UnitPrice";
			public const string WriteDate = "WriteDate";
			public const string BiaoCoefficient = "BiaoCoefficient";
			public const string ChargeRoomNo = "ChargeRoomNo";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"FullName" , "string:"},
    			 {"ProjectID" , "int:"},
    			 {"BiaoID" , "int:"},
    			 {"IsActive" , "bool:"},
    			 {"Name" , "string:"},
    			 {"DefaultOrder" , "string:"},
    			 {"BiaoGuiGe" , "string:"},
    			 {"BiaoName" , "string:"},
    			 {"BiaoCategory" , "string:"},
    			 {"Remark" , "string:"},
    			 {"ImportStartPoint" , "decimal:"},
    			 {"ImportEndPoint" , "decimal:"},
    			 {"LastTotalPoint" , "decimal:"},
    			 {"ImportWriteDate" , "DateTime:"},
    			 {"ImportUnitPrice" , "decimal:"},
    			 {"ID" , "int:"},
    			 {"Rate" , "decimal:"},
    			 {"ReducePoint" , "decimal:"},
    			 {"StartPoint" , "decimal:"},
    			 {"EndPoint" , "decimal:"},
    			 {"TotalPoint" , "decimal:"},
    			 {"ChargeID" , "int:"},
    			 {"ChargeName" , "string:"},
    			 {"SummaryUnitPrice" , "decimal:"},
    			 {"Coefficient" , "decimal:"},
    			 {"EndNumberCount" , "int:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"WriteDate" , "DateTime:"},
    			 {"BiaoCoefficient" , "decimal:"},
    			 {"ChargeRoomNo" , "string:"},
            };
		}
		#endregion
	}
}
