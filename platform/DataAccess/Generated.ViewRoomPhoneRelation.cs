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
	/// This object represents the properties and methods of a ViewRoomPhoneRelation.
	/// </summary>
	[Serializable()]
	public partial class ViewRoomPhoneRelation 
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
		private string _relatePhoneNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelatePhoneNumber
		{
			[DebuggerStepThrough()]
			get { return this._relatePhoneNumber; }
            protected set { this._relatePhoneNumber = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relationName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelationName
		{
			[DebuggerStepThrough()]
			get { return this._relationName; }
            protected set { this._relationName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relationIDCard = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelationIDCard
		{
			[DebuggerStepThrough()]
			get { return this._relationIDCard; }
            protected set { this._relationIDCard = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDefault = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDefault
		{
			[DebuggerStepThrough()]
			get { return this._isDefault; }
            protected set { this._isDefault = value;}
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
		private string _relationType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelationType
		{
			[DebuggerStepThrough()]
			get { return this._relationType; }
            protected set { this._relationType = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _iDCardType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int IDCardType
		{
			[DebuggerStepThrough()]
			get { return this._iDCardType; }
            protected set { this._iDCardType = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _birthday = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime Birthday
		{
			[DebuggerStepThrough()]
			get { return this._birthday; }
            protected set { this._birthday = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _emailAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string EmailAddress
		{
			[DebuggerStepThrough()]
			get { return this._emailAddress; }
            protected set { this._emailAddress = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _homeAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string HomeAddress
		{
			[DebuggerStepThrough()]
			get { return this._homeAddress; }
            protected set { this._homeAddress = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _officeAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OfficeAddress
		{
			[DebuggerStepThrough()]
			get { return this._officeAddress; }
            protected set { this._officeAddress = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _bankName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BankName
		{
			[DebuggerStepThrough()]
			get { return this._bankName; }
            protected set { this._bankName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _bankAccountName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BankAccountName
		{
			[DebuggerStepThrough()]
			get { return this._bankAccountName; }
            protected set { this._bankAccountName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _bankAccountNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BankAccountNo
		{
			[DebuggerStepThrough()]
			get { return this._bankAccountNo; }
            protected set { this._bankAccountNo = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _customOne = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CustomOne
		{
			[DebuggerStepThrough()]
			get { return this._customOne; }
            protected set { this._customOne = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _customTwo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CustomTwo
		{
			[DebuggerStepThrough()]
			get { return this._customTwo; }
            protected set { this._customTwo = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _customThree = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CustomThree
		{
			[DebuggerStepThrough()]
			get { return this._customThree; }
            protected set { this._customThree = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _customFour = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CustomFour
		{
			[DebuggerStepThrough()]
			get { return this._customFour; }
            protected set { this._customFour = value;}
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
		private DateTime _contractStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ContractStartTime
		{
			[DebuggerStepThrough()]
			get { return this._contractStartTime; }
            protected set { this._contractStartTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _contractEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ContractEndTime
		{
			[DebuggerStepThrough()]
			get { return this._contractEndTime; }
            protected set { this._contractEndTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _brandInfo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BrandInfo
		{
			[DebuggerStepThrough()]
			get { return this._brandInfo; }
            protected set { this._brandInfo = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contractNote = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractNote
		{
			[DebuggerStepThrough()]
			get { return this._contractNote; }
            protected set { this._contractNote = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relationProperty = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelationProperty
		{
			[DebuggerStepThrough()]
			get { return this._relationProperty; }
            protected set { this._relationProperty = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isChargeFee = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsChargeFee
		{
			[DebuggerStepThrough()]
			get { return this._isChargeFee; }
            protected set { this._isChargeFee = value;}
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
		private string _interesting = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Interesting
		{
			[DebuggerStepThrough()]
			get { return this._interesting; }
            protected set { this._interesting = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _consumeMore = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ConsumeMore
		{
			[DebuggerStepThrough()]
			get { return this._consumeMore; }
            protected set { this._consumeMore = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _belongTeam = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BelongTeam
		{
			[DebuggerStepThrough()]
			get { return this._belongTeam; }
            protected set { this._belongTeam = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _oneCardNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OneCardNumber
		{
			[DebuggerStepThrough()]
			get { return this._oneCardNumber; }
            protected set { this._oneCardNumber = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeForMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeForMan
		{
			[DebuggerStepThrough()]
			get { return this._chargeForMan; }
            protected set { this._chargeForMan = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isChargeMan = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsChargeMan
		{
			[DebuggerStepThrough()]
			get { return this._isChargeMan; }
            protected set { this._isChargeMan = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _companyName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CompanyName
		{
			[DebuggerStepThrough()]
			get { return this._companyName; }
            protected set { this._companyName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _contractID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ContractID
		{
			[DebuggerStepThrough()]
			get { return this._contractID; }
            protected set { this._contractID = value;}
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
		private int _userID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int UserID
		{
			[DebuggerStepThrough()]
			get { return this._userID; }
            protected set { this._userID = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewRoomPhoneRelation() { }
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
	[ViewRoomPhoneRelation].[ID],
	[ViewRoomPhoneRelation].[RoomID],
	[ViewRoomPhoneRelation].[RelatePhoneNumber],
	[ViewRoomPhoneRelation].[RelationName],
	[ViewRoomPhoneRelation].[RelationIDCard],
	[ViewRoomPhoneRelation].[IsDefault],
	[ViewRoomPhoneRelation].[AddTime],
	[ViewRoomPhoneRelation].[RelationType],
	[ViewRoomPhoneRelation].[IDCardType],
	[ViewRoomPhoneRelation].[Birthday],
	[ViewRoomPhoneRelation].[EmailAddress],
	[ViewRoomPhoneRelation].[HomeAddress],
	[ViewRoomPhoneRelation].[OfficeAddress],
	[ViewRoomPhoneRelation].[BankName],
	[ViewRoomPhoneRelation].[BankAccountName],
	[ViewRoomPhoneRelation].[BankAccountNo],
	[ViewRoomPhoneRelation].[CustomOne],
	[ViewRoomPhoneRelation].[CustomTwo],
	[ViewRoomPhoneRelation].[CustomThree],
	[ViewRoomPhoneRelation].[CustomFour],
	[ViewRoomPhoneRelation].[Remark],
	[ViewRoomPhoneRelation].[ContractStartTime],
	[ViewRoomPhoneRelation].[ContractEndTime],
	[ViewRoomPhoneRelation].[BrandInfo],
	[ViewRoomPhoneRelation].[ContractNote],
	[ViewRoomPhoneRelation].[RelationProperty],
	[ViewRoomPhoneRelation].[IsChargeFee],
	[ViewRoomPhoneRelation].[HeadImg],
	[ViewRoomPhoneRelation].[Interesting],
	[ViewRoomPhoneRelation].[ConsumeMore],
	[ViewRoomPhoneRelation].[BelongTeam],
	[ViewRoomPhoneRelation].[OneCardNumber],
	[ViewRoomPhoneRelation].[ChargeForMan],
	[ViewRoomPhoneRelation].[IsChargeMan],
	[ViewRoomPhoneRelation].[CompanyName],
	[ViewRoomPhoneRelation].[ContractID],
	[ViewRoomPhoneRelation].[RoomName],
	[ViewRoomPhoneRelation].[FullName],
	[ViewRoomPhoneRelation].[AllParentID],
	[ViewRoomPhoneRelation].[DefaultOrder],
	[ViewRoomPhoneRelation].[UserID]
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
                return "ViewRoomPhoneRelation";
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
		/// Gets a collection ViewRoomPhoneRelation objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewRoomPhoneRelation objects.</returns>
		public static EntityList<ViewRoomPhoneRelation> GetViewRoomPhoneRelations()
		{
			string commandText = @"
SELECT " + ViewRoomPhoneRelation.SelectFieldList + "FROM [dbo].[ViewRoomPhoneRelation] " + ViewRoomPhoneRelation.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewRoomPhoneRelation>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewRoomPhoneRelation objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewRoomPhoneRelation objects.</returns>
        public static EntityList<ViewRoomPhoneRelation> GetViewRoomPhoneRelations(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewRoomPhoneRelation>(SelectFieldList, "FROM [dbo].[ViewRoomPhoneRelation]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewRoomPhoneRelation objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewRoomPhoneRelation objects.</returns>
        public static EntityList<ViewRoomPhoneRelation> GetViewRoomPhoneRelations(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewRoomPhoneRelation>(SelectFieldList, "FROM [dbo].[ViewRoomPhoneRelation]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewRoomPhoneRelation objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewRoomPhoneRelationCount()
        {
            return GetViewRoomPhoneRelationCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewRoomPhoneRelation objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewRoomPhoneRelationCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewRoomPhoneRelation] " + where;

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
		/// Gets a collection ViewRoomPhoneRelation objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewRoomPhoneRelation objects.</returns>
		protected static EntityList<ViewRoomPhoneRelation> GetViewRoomPhoneRelations(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewRoomPhoneRelations(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomPhoneRelation objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomPhoneRelation objects.</returns>
		protected static EntityList<ViewRoomPhoneRelation> GetViewRoomPhoneRelations(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewRoomPhoneRelations(string.Empty, where, parameters, ViewRoomPhoneRelation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomPhoneRelation objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomPhoneRelation objects.</returns>
		protected static EntityList<ViewRoomPhoneRelation> GetViewRoomPhoneRelations(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewRoomPhoneRelations(prefix, where, parameters, ViewRoomPhoneRelation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomPhoneRelation objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomPhoneRelation objects.</returns>
		protected static EntityList<ViewRoomPhoneRelation> GetViewRoomPhoneRelations(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewRoomPhoneRelations(string.Empty, where, parameters, ViewRoomPhoneRelation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomPhoneRelation objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomPhoneRelation objects.</returns>
		protected static EntityList<ViewRoomPhoneRelation> GetViewRoomPhoneRelations(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewRoomPhoneRelations(prefix, where, parameters, ViewRoomPhoneRelation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomPhoneRelation objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewRoomPhoneRelation objects.</returns>
		protected static EntityList<ViewRoomPhoneRelation> GetViewRoomPhoneRelations(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewRoomPhoneRelation.SelectFieldList + "FROM [dbo].[ViewRoomPhoneRelation] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewRoomPhoneRelation>(reader);
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
        protected static EntityList<ViewRoomPhoneRelation> GetViewRoomPhoneRelations(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewRoomPhoneRelation>(SelectFieldList, "FROM [dbo].[ViewRoomPhoneRelation] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewRoomPhoneRelationProperties
		{
			public const string ID = "ID";
			public const string RoomID = "RoomID";
			public const string RelatePhoneNumber = "RelatePhoneNumber";
			public const string RelationName = "RelationName";
			public const string RelationIDCard = "RelationIDCard";
			public const string IsDefault = "IsDefault";
			public const string AddTime = "AddTime";
			public const string RelationType = "RelationType";
			public const string IDCardType = "IDCardType";
			public const string Birthday = "Birthday";
			public const string EmailAddress = "EmailAddress";
			public const string HomeAddress = "HomeAddress";
			public const string OfficeAddress = "OfficeAddress";
			public const string BankName = "BankName";
			public const string BankAccountName = "BankAccountName";
			public const string BankAccountNo = "BankAccountNo";
			public const string CustomOne = "CustomOne";
			public const string CustomTwo = "CustomTwo";
			public const string CustomThree = "CustomThree";
			public const string CustomFour = "CustomFour";
			public const string Remark = "Remark";
			public const string ContractStartTime = "ContractStartTime";
			public const string ContractEndTime = "ContractEndTime";
			public const string BrandInfo = "BrandInfo";
			public const string ContractNote = "ContractNote";
			public const string RelationProperty = "RelationProperty";
			public const string IsChargeFee = "IsChargeFee";
			public const string HeadImg = "HeadImg";
			public const string Interesting = "Interesting";
			public const string ConsumeMore = "ConsumeMore";
			public const string BelongTeam = "BelongTeam";
			public const string OneCardNumber = "OneCardNumber";
			public const string ChargeForMan = "ChargeForMan";
			public const string IsChargeMan = "IsChargeMan";
			public const string CompanyName = "CompanyName";
			public const string ContractID = "ContractID";
			public const string RoomName = "RoomName";
			public const string FullName = "FullName";
			public const string AllParentID = "AllParentID";
			public const string DefaultOrder = "DefaultOrder";
			public const string UserID = "UserID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"RelatePhoneNumber" , "string:"},
    			 {"RelationName" , "string:"},
    			 {"RelationIDCard" , "string:"},
    			 {"IsDefault" , "bool:"},
    			 {"AddTime" , "DateTime:"},
    			 {"RelationType" , "string:"},
    			 {"IDCardType" , "int:"},
    			 {"Birthday" , "DateTime:"},
    			 {"EmailAddress" , "string:"},
    			 {"HomeAddress" , "string:"},
    			 {"OfficeAddress" , "string:"},
    			 {"BankName" , "string:"},
    			 {"BankAccountName" , "string:"},
    			 {"BankAccountNo" , "string:"},
    			 {"CustomOne" , "string:"},
    			 {"CustomTwo" , "string:"},
    			 {"CustomThree" , "string:"},
    			 {"CustomFour" , "string:"},
    			 {"Remark" , "string:"},
    			 {"ContractStartTime" , "DateTime:"},
    			 {"ContractEndTime" , "DateTime:"},
    			 {"BrandInfo" , "string:"},
    			 {"ContractNote" , "string:"},
    			 {"RelationProperty" , "string:"},
    			 {"IsChargeFee" , "bool:"},
    			 {"HeadImg" , "string:"},
    			 {"Interesting" , "string:"},
    			 {"ConsumeMore" , "string:"},
    			 {"BelongTeam" , "string:"},
    			 {"OneCardNumber" , "string:"},
    			 {"ChargeForMan" , "string:"},
    			 {"IsChargeMan" , "bool:"},
    			 {"CompanyName" , "string:"},
    			 {"ContractID" , "int:"},
    			 {"RoomName" , "string:"},
    			 {"FullName" , "string:"},
    			 {"AllParentID" , "string:"},
    			 {"DefaultOrder" , "string:"},
    			 {"UserID" , "int:"},
            };
		}
		#endregion
	}
}
