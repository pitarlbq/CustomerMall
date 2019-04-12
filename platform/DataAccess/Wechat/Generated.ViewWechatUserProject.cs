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
	/// This object represents the properties and methods of a ViewWechatUserProject.
	/// </summary>
	[Serializable()]
	public partial class ViewWechatUserProject 
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
		private int _parentID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ParentID
		{
			[DebuggerStepThrough()]
			get { return this._parentID; }
            protected set { this._parentID = value;}
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
		private string _grade = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Grade
		{
			[DebuggerStepThrough()]
			get { return this._grade; }
            protected set { this._grade = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _iconID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int IconID
		{
			[DebuggerStepThrough()]
			get { return this._iconID; }
            protected set { this._iconID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _level = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Level
		{
			[DebuggerStepThrough()]
			get { return this._level; }
            protected set { this._level = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isParent = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool isParent
		{
			[DebuggerStepThrough()]
			get { return this._isParent; }
            protected set { this._isParent = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _pName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PName
		{
			[DebuggerStepThrough()]
			get { return this._pName; }
            protected set { this._pName = value;}
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
            protected set { this._companyID = value;}
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
            protected set { this._orderBy = value;}
		}
		
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
		private string _oriFullName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OriFullName
		{
			[DebuggerStepThrough()]
			get { return this._oriFullName; }
            protected set { this._oriFullName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _allParentID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AllParentID
		{
			[DebuggerStepThrough()]
			get { return this._allParentID; }
            protected set { this._allParentID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _printNote = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PrintNote
		{
			[DebuggerStepThrough()]
			get { return this._printNote; }
            protected set { this._printNote = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _cuiFeiNote = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CuiFeiNote
		{
			[DebuggerStepThrough()]
			get { return this._cuiFeiNote; }
            protected set { this._cuiFeiNote = value;}
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
		private string _printTitle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PrintTitle
		{
			[DebuggerStepThrough()]
			get { return this._printTitle; }
            protected set { this._printTitle = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _printFont = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PrintFont
		{
			[DebuggerStepThrough()]
			get { return this._printFont; }
            protected set { this._printFont = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isPrintNote = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsPrintNote
		{
			[DebuggerStepThrough()]
			get { return this._isPrintNote; }
            protected set { this._isPrintNote = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isPrintCount = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsPrintCount
		{
			[DebuggerStepThrough()]
			get { return this._isPrintCount; }
            protected set { this._isPrintCount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _printWidth = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal PrintWidth
		{
			[DebuggerStepThrough()]
			get { return this._printWidth; }
            protected set { this._printWidth = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _printHeight = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal PrintHeight
		{
			[DebuggerStepThrough()]
			get { return this._printHeight; }
            protected set { this._printHeight = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _printSubTitle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PrintSubTitle
		{
			[DebuggerStepThrough()]
			get { return this._printSubTitle; }
            protected set { this._printSubTitle = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isPrintCost = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsPrintCost
		{
			[DebuggerStepThrough()]
			get { return this._isPrintCost; }
            protected set { this._isPrintCost = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isPrintDiscount = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsPrintDiscount
		{
			[DebuggerStepThrough()]
			get { return this._isPrintDiscount; }
            protected set { this._isPrintDiscount = value;}
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
		private int _sex = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Sex
		{
			[DebuggerStepThrough()]
			get { return this._sex; }
            protected set { this._sex = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _city = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string City
		{
			[DebuggerStepThrough()]
			get { return this._city; }
            protected set { this._city = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _country = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Country
		{
			[DebuggerStepThrough()]
			get { return this._country; }
            protected set { this._country = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _province = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Province
		{
			[DebuggerStepThrough()]
			get { return this._province; }
            protected set { this._province = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _subScribe = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SubScribe
		{
			[DebuggerStepThrough()]
			get { return this._subScribe; }
            protected set { this._subScribe = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _subscribeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime SubscribeTime
		{
			[DebuggerStepThrough()]
			get { return this._subscribeTime; }
            protected set { this._subscribeTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _unSubscribeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime UnSubscribeTime
		{
			[DebuggerStepThrough()]
			get { return this._unSubscribeTime; }
            protected set { this._unSubscribeTime = value;}
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
		private string _language = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Language
		{
			[DebuggerStepThrough()]
			get { return this._language; }
            protected set { this._language = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _lastVisitTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime LastVisitTime
		{
			[DebuggerStepThrough()]
			get { return this._lastVisitTime; }
            protected set { this._lastVisitTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _visitCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int VisitCount
		{
			[DebuggerStepThrough()]
			get { return this._visitCount; }
            protected set { this._visitCount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _fromOpenId = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FromOpenId
		{
			[DebuggerStepThrough()]
			get { return this._fromOpenId; }
            protected set { this._fromOpenId = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _firstSubScribeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime FirstSubScribeTime
		{
			[DebuggerStepThrough()]
			get { return this._firstSubScribeTime; }
            protected set { this._firstSubScribeTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _fromQrID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int FromQrID
		{
			[DebuggerStepThrough()]
			get { return this._fromQrID; }
            protected set { this._fromQrID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _openId = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OpenId
		{
			[DebuggerStepThrough()]
			get { return this._openId; }
            protected set { this._openId = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relateOwnerName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelateOwnerName
		{
			[DebuggerStepThrough()]
			get { return this._relateOwnerName; }
            protected set { this._relateOwnerName = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewWechatUserProject() { }
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
	[ViewWechatUserProject].[ID],
	[ViewWechatUserProject].[ParentID],
	[ViewWechatUserProject].[Name],
	[ViewWechatUserProject].[Description],
	[ViewWechatUserProject].[AddTime],
	[ViewWechatUserProject].[AddMan],
	[ViewWechatUserProject].[TypeDesc],
	[ViewWechatUserProject].[Grade],
	[ViewWechatUserProject].[IconID],
	[ViewWechatUserProject].[Level],
	[ViewWechatUserProject].[isParent],
	[ViewWechatUserProject].[PName],
	[ViewWechatUserProject].[CompanyID],
	[ViewWechatUserProject].[OrderBy],
	[ViewWechatUserProject].[FullName],
	[ViewWechatUserProject].[OriFullName],
	[ViewWechatUserProject].[AllParentID],
	[ViewWechatUserProject].[PrintNote],
	[ViewWechatUserProject].[CuiFeiNote],
	[ViewWechatUserProject].[DefaultOrder],
	[ViewWechatUserProject].[PrintTitle],
	[ViewWechatUserProject].[PrintFont],
	[ViewWechatUserProject].[IsPrintNote],
	[ViewWechatUserProject].[IsPrintCount],
	[ViewWechatUserProject].[PrintWidth],
	[ViewWechatUserProject].[PrintHeight],
	[ViewWechatUserProject].[PrintSubTitle],
	[ViewWechatUserProject].[IsPrintCost],
	[ViewWechatUserProject].[IsPrintDiscount],
	[ViewWechatUserProject].[NickName],
	[ViewWechatUserProject].[Sex],
	[ViewWechatUserProject].[City],
	[ViewWechatUserProject].[Country],
	[ViewWechatUserProject].[Province],
	[ViewWechatUserProject].[SubScribe],
	[ViewWechatUserProject].[SubscribeTime],
	[ViewWechatUserProject].[UnSubscribeTime],
	[ViewWechatUserProject].[HeadImgUrl],
	[ViewWechatUserProject].[Language],
	[ViewWechatUserProject].[LastVisitTime],
	[ViewWechatUserProject].[VisitCount],
	[ViewWechatUserProject].[FromOpenId],
	[ViewWechatUserProject].[FirstSubScribeTime],
	[ViewWechatUserProject].[FromQrID],
	[ViewWechatUserProject].[OpenId],
	[ViewWechatUserProject].[RelateOwnerName]
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
                return "ViewWechatUserProject";
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
		/// Gets a collection ViewWechatUserProject objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewWechatUserProject objects.</returns>
		public static EntityList<ViewWechatUserProject> GetViewWechatUserProjects()
		{
			string commandText = @"
SELECT " + ViewWechatUserProject.SelectFieldList + "FROM [dbo].[ViewWechatUserProject] " + ViewWechatUserProject.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewWechatUserProject>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewWechatUserProject objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewWechatUserProject objects.</returns>
        public static EntityList<ViewWechatUserProject> GetViewWechatUserProjects(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewWechatUserProject>(SelectFieldList, "FROM [dbo].[ViewWechatUserProject]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewWechatUserProject objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewWechatUserProject objects.</returns>
        public static EntityList<ViewWechatUserProject> GetViewWechatUserProjects(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewWechatUserProject>(SelectFieldList, "FROM [dbo].[ViewWechatUserProject]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewWechatUserProject objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewWechatUserProjectCount()
        {
            return GetViewWechatUserProjectCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewWechatUserProject objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewWechatUserProjectCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewWechatUserProject] " + where;

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
		/// Gets a collection ViewWechatUserProject objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewWechatUserProject objects.</returns>
		protected static EntityList<ViewWechatUserProject> GetViewWechatUserProjects(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewWechatUserProjects(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatUserProject objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewWechatUserProject objects.</returns>
		protected static EntityList<ViewWechatUserProject> GetViewWechatUserProjects(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewWechatUserProjects(string.Empty, where, parameters, ViewWechatUserProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatUserProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewWechatUserProject objects.</returns>
		protected static EntityList<ViewWechatUserProject> GetViewWechatUserProjects(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewWechatUserProjects(prefix, where, parameters, ViewWechatUserProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatUserProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewWechatUserProject objects.</returns>
		protected static EntityList<ViewWechatUserProject> GetViewWechatUserProjects(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewWechatUserProjects(string.Empty, where, parameters, ViewWechatUserProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatUserProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewWechatUserProject objects.</returns>
		protected static EntityList<ViewWechatUserProject> GetViewWechatUserProjects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewWechatUserProjects(prefix, where, parameters, ViewWechatUserProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewWechatUserProject objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewWechatUserProject objects.</returns>
		protected static EntityList<ViewWechatUserProject> GetViewWechatUserProjects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewWechatUserProject.SelectFieldList + "FROM [dbo].[ViewWechatUserProject] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewWechatUserProject>(reader);
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
        protected static EntityList<ViewWechatUserProject> GetViewWechatUserProjects(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewWechatUserProject>(SelectFieldList, "FROM [dbo].[ViewWechatUserProject] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewWechatUserProjectProperties
		{
			public const string ID = "ID";
			public const string ParentID = "ParentID";
			public const string Name = "Name";
			public const string Description = "Description";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string TypeDesc = "TypeDesc";
			public const string Grade = "Grade";
			public const string IconID = "IconID";
			public const string Level = "Level";
			public const string isParent = "isParent";
			public const string PName = "PName";
			public const string CompanyID = "CompanyID";
			public const string OrderBy = "OrderBy";
			public const string FullName = "FullName";
			public const string OriFullName = "OriFullName";
			public const string AllParentID = "AllParentID";
			public const string PrintNote = "PrintNote";
			public const string CuiFeiNote = "CuiFeiNote";
			public const string DefaultOrder = "DefaultOrder";
			public const string PrintTitle = "PrintTitle";
			public const string PrintFont = "PrintFont";
			public const string IsPrintNote = "IsPrintNote";
			public const string IsPrintCount = "IsPrintCount";
			public const string PrintWidth = "PrintWidth";
			public const string PrintHeight = "PrintHeight";
			public const string PrintSubTitle = "PrintSubTitle";
			public const string IsPrintCost = "IsPrintCost";
			public const string IsPrintDiscount = "IsPrintDiscount";
			public const string NickName = "NickName";
			public const string Sex = "Sex";
			public const string City = "City";
			public const string Country = "Country";
			public const string Province = "Province";
			public const string SubScribe = "SubScribe";
			public const string SubscribeTime = "SubscribeTime";
			public const string UnSubscribeTime = "UnSubscribeTime";
			public const string HeadImgUrl = "HeadImgUrl";
			public const string Language = "Language";
			public const string LastVisitTime = "LastVisitTime";
			public const string VisitCount = "VisitCount";
			public const string FromOpenId = "FromOpenId";
			public const string FirstSubScribeTime = "FirstSubScribeTime";
			public const string FromQrID = "FromQrID";
			public const string OpenId = "OpenId";
			public const string RelateOwnerName = "RelateOwnerName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ParentID" , "int:"},
    			 {"Name" , "string:"},
    			 {"Description" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"TypeDesc" , "string:"},
    			 {"Grade" , "string:"},
    			 {"IconID" , "int:"},
    			 {"Level" , "int:"},
    			 {"isParent" , "bool:"},
    			 {"PName" , "string:"},
    			 {"CompanyID" , "int:"},
    			 {"OrderBy" , "int:"},
    			 {"FullName" , "string:"},
    			 {"OriFullName" , "string:"},
    			 {"AllParentID" , "string:"},
    			 {"PrintNote" , "string:"},
    			 {"CuiFeiNote" , "string:"},
    			 {"DefaultOrder" , "string:"},
    			 {"PrintTitle" , "string:"},
    			 {"PrintFont" , "string:"},
    			 {"IsPrintNote" , "bool:"},
    			 {"IsPrintCount" , "bool:"},
    			 {"PrintWidth" , "decimal:"},
    			 {"PrintHeight" , "decimal:"},
    			 {"PrintSubTitle" , "string:"},
    			 {"IsPrintCost" , "bool:"},
    			 {"IsPrintDiscount" , "bool:"},
    			 {"NickName" , "string:"},
    			 {"Sex" , "int:"},
    			 {"City" , "string:"},
    			 {"Country" , "string:"},
    			 {"Province" , "string:"},
    			 {"SubScribe" , "int:"},
    			 {"SubscribeTime" , "DateTime:"},
    			 {"UnSubscribeTime" , "DateTime:"},
    			 {"HeadImgUrl" , "string:"},
    			 {"Language" , "string:"},
    			 {"LastVisitTime" , "DateTime:"},
    			 {"VisitCount" , "int:"},
    			 {"FromOpenId" , "string:"},
    			 {"FirstSubScribeTime" , "DateTime:"},
    			 {"FromQrID" , "int:"},
    			 {"OpenId" , "string:"},
    			 {"RelateOwnerName" , "string:"},
            };
		}
		#endregion
	}
}
