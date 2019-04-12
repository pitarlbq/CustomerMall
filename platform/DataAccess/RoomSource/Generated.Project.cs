using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.Script.Serialization;
using Foresight.DataAccess.Framework;


namespace Foresight.DataAccess
{
	/// <summary>
	/// This object represents the properties and methods of a Project.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Project 
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
		[DataObjectField(true, true, false)]
		public int ID
		{
			[DebuggerStepThrough()]
			get { return this._iD; }
			 set 
			{
				if (this._iD != value) 
				{
					this._iD = value;
					this.IsDirty = true;	
					OnPropertyChanged("ID");
				}
			}
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
			set 
			{
				if (this._parentID != value) 
				{
					this._parentID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ParentID");
				}
			}
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
			set 
			{
				if (this._name != value) 
				{
					this._name = value;
					this.IsDirty = true;	
					OnPropertyChanged("Name");
				}
			}
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
			set 
			{
				if (this._description != value) 
				{
					this._description = value;
					this.IsDirty = true;	
					OnPropertyChanged("Description");
				}
			}
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
			set 
			{
				if (this._addTime != value) 
				{
					this._addTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddTime");
				}
			}
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
			set 
			{
				if (this._addMan != value) 
				{
					this._addMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddMan");
				}
			}
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
			set 
			{
				if (this._typeDesc != value) 
				{
					this._typeDesc = value;
					this.IsDirty = true;	
					OnPropertyChanged("TypeDesc");
				}
			}
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
			set 
			{
				if (this._grade != value) 
				{
					this._grade = value;
					this.IsDirty = true;	
					OnPropertyChanged("Grade");
				}
			}
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
			set 
			{
				if (this._iconID != value) 
				{
					this._iconID = value;
					this.IsDirty = true;	
					OnPropertyChanged("IconID");
				}
			}
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
			set 
			{
				if (this._level != value) 
				{
					this._level = value;
					this.IsDirty = true;	
					OnPropertyChanged("Level");
				}
			}
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
			set 
			{
				if (this._isParent != value) 
				{
					this._isParent = value;
					this.IsDirty = true;	
					OnPropertyChanged("isParent");
				}
			}
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
			set 
			{
				if (this._pName != value) 
				{
					this._pName = value;
					this.IsDirty = true;	
					OnPropertyChanged("PName");
				}
			}
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
			set 
			{
				if (this._companyID != value) 
				{
					this._companyID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CompanyID");
				}
			}
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
			set 
			{
				if (this._orderBy != value) 
				{
					this._orderBy = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderBy");
				}
			}
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
			set 
			{
				if (this._fullName != value) 
				{
					this._fullName = value;
					this.IsDirty = true;	
					OnPropertyChanged("FullName");
				}
			}
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
			set 
			{
				if (this._oriFullName != value) 
				{
					this._oriFullName = value;
					this.IsDirty = true;	
					OnPropertyChanged("OriFullName");
				}
			}
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
			set 
			{
				if (this._allParentID != value) 
				{
					this._allParentID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AllParentID");
				}
			}
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
			set 
			{
				if (this._printNote != value) 
				{
					this._printNote = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintNote");
				}
			}
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
			set 
			{
				if (this._cuiFeiNote != value) 
				{
					this._cuiFeiNote = value;
					this.IsDirty = true;	
					OnPropertyChanged("CuiFeiNote");
				}
			}
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
			set 
			{
				if (this._defaultOrder != value) 
				{
					this._defaultOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("DefaultOrder");
				}
			}
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
			set 
			{
				if (this._printTitle != value) 
				{
					this._printTitle = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintTitle");
				}
			}
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
			set 
			{
				if (this._printFont != value) 
				{
					this._printFont = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintFont");
				}
			}
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
			set 
			{
				if (this._isPrintNote != value) 
				{
					this._isPrintNote = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsPrintNote");
				}
			}
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
			set 
			{
				if (this._isPrintCount != value) 
				{
					this._isPrintCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsPrintCount");
				}
			}
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
			set 
			{
				if (this._printWidth != value) 
				{
					this._printWidth = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintWidth");
				}
			}
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
			set 
			{
				if (this._printHeight != value) 
				{
					this._printHeight = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintHeight");
				}
			}
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
			set 
			{
				if (this._printSubTitle != value) 
				{
					this._printSubTitle = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintSubTitle");
				}
			}
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
			set 
			{
				if (this._isPrintCost != value) 
				{
					this._isPrintCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsPrintCost");
				}
			}
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
			set 
			{
				if (this._isPrintDiscount != value) 
				{
					this._isPrintDiscount = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsPrintDiscount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _propertyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PropertyID
		{
			[DebuggerStepThrough()]
			get { return this._propertyID; }
			set 
			{
				if (this._propertyID != value) 
				{
					this._propertyID = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _logoPath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string LogoPath
		{
			[DebuggerStepThrough()]
			get { return this._logoPath; }
			set 
			{
				if (this._logoPath != value) 
				{
					this._logoPath = value;
					this.IsDirty = true;	
					OnPropertyChanged("LogoPath");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _printCancelNote = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PrintCancelNote
		{
			[DebuggerStepThrough()]
			get { return this._printCancelNote; }
			set 
			{
				if (this._printCancelNote != value) 
				{
					this._printCancelNote = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintCancelNote");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _cuiShouPrintTitle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CuiShouPrintTitle
		{
			[DebuggerStepThrough()]
			get { return this._cuiShouPrintTitle; }
			set 
			{
				if (this._cuiShouPrintTitle != value) 
				{
					this._cuiShouPrintTitle = value;
					this.IsDirty = true;	
					OnPropertyChanged("CuiShouPrintTitle");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _cuiShouPrintSubTitle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CuiShouPrintSubTitle
		{
			[DebuggerStepThrough()]
			get { return this._cuiShouPrintSubTitle; }
			set 
			{
				if (this._cuiShouPrintSubTitle != value) 
				{
					this._cuiShouPrintSubTitle = value;
					this.IsDirty = true;	
					OnPropertyChanged("CuiShouPrintSubTitle");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isPrintRoomNo = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsPrintRoomNo
		{
			[DebuggerStepThrough()]
			get { return this._isPrintRoomNo; }
			set 
			{
				if (this._isPrintRoomNo != value) 
				{
					this._isPrintRoomNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsPrintRoomNo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _printType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PrintType
		{
			[DebuggerStepThrough()]
			get { return this._printType; }
			set 
			{
				if (this._printType != value) 
				{
					this._printType = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isPrintTotalRealCost = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsPrintTotalRealCost
		{
			[DebuggerStepThrough()]
			get { return this._isPrintTotalRealCost; }
			set 
			{
				if (this._isPrintTotalRealCost != value) 
				{
					this._isPrintTotalRealCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsPrintTotalRealCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isPrintRealCost = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsPrintRealCost
		{
			[DebuggerStepThrough()]
			get { return this._isPrintRealCost; }
			set 
			{
				if (this._isPrintRealCost != value) 
				{
					this._isPrintRealCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsPrintRealCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDefinePrintSize = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDefinePrintSize
		{
			[DebuggerStepThrough()]
			get { return this._isDefinePrintSize; }
			set 
			{
				if (this._isDefinePrintSize != value) 
				{
					this._isDefinePrintSize = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDefinePrintSize");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _printTopMargin = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal PrintTopMargin
		{
			[DebuggerStepThrough()]
			get { return this._printTopMargin; }
			set 
			{
				if (this._printTopMargin != value) 
				{
					this._printTopMargin = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintTopMargin");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _printBottomMargin = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal PrintBottomMargin
		{
			[DebuggerStepThrough()]
			get { return this._printBottomMargin; }
			set 
			{
				if (this._printBottomMargin != value) 
				{
					this._printBottomMargin = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintBottomMargin");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _printTotalLines = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PrintTotalLines
		{
			[DebuggerStepThrough()]
			get { return this._printTotalLines; }
			set 
			{
				if (this._printTotalLines != value) 
				{
					this._printTotalLines = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintTotalLines");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isPrintMonthCount = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsPrintMonthCount
		{
			[DebuggerStepThrough()]
			get { return this._isPrintMonthCount; }
			set 
			{
				if (this._isPrintMonthCount != value) 
				{
					this._isPrintMonthCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsPrintMonthCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _orgnizationID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OrgnizationID
		{
			[DebuggerStepThrough()]
			get { return this._orgnizationID; }
			set 
			{
				if (this._orgnizationID != value) 
				{
					this._orgnizationID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrgnizationID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addressProvice = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddressProvice
		{
			[DebuggerStepThrough()]
			get { return this._addressProvice; }
			set 
			{
				if (this._addressProvice != value) 
				{
					this._addressProvice = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressProvice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addressCity = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddressCity
		{
			[DebuggerStepThrough()]
			get { return this._addressCity; }
			set 
			{
				if (this._addressCity != value) 
				{
					this._addressCity = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressCity");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addressDistrict = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddressDistrict
		{
			[DebuggerStepThrough()]
			get { return this._addressDistrict; }
			set 
			{
				if (this._addressDistrict != value) 
				{
					this._addressDistrict = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressDistrict");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _payPrintTitle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PayPrintTitle
		{
			[DebuggerStepThrough()]
			get { return this._payPrintTitle; }
			set 
			{
				if (this._payPrintTitle != value) 
				{
					this._payPrintTitle = value;
					this.IsDirty = true;	
					OnPropertyChanged("PayPrintTitle");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _payPrintSubTitle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PayPrintSubTitle
		{
			[DebuggerStepThrough()]
			get { return this._payPrintSubTitle; }
			set 
			{
				if (this._payPrintSubTitle != value) 
				{
					this._payPrintSubTitle = value;
					this.IsDirty = true;	
					OnPropertyChanged("PayPrintSubTitle");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _addressProvinceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int AddressProvinceID
		{
			[DebuggerStepThrough()]
			get { return this._addressProvinceID; }
			set 
			{
				if (this._addressProvinceID != value) 
				{
					this._addressProvinceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddressProvinceID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _logoWidth = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int LogoWidth
		{
			[DebuggerStepThrough()]
			get { return this._logoWidth; }
			set 
			{
				if (this._logoWidth != value) 
				{
					this._logoWidth = value;
					this.IsDirty = true;	
					OnPropertyChanged("LogoWidth");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _logoHeight = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int LogoHeight
		{
			[DebuggerStepThrough()]
			get { return this._logoHeight; }
			set 
			{
				if (this._logoHeight != value) 
				{
					this._logoHeight = value;
					this.IsDirty = true;	
					OnPropertyChanged("LogoHeight");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isPrintUnitPrice = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsPrintUnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._isPrintUnitPrice; }
			set 
			{
				if (this._isPrintUnitPrice != value) 
				{
					this._isPrintUnitPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsPrintUnitPrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _printChargeTypeCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PrintChargeTypeCount
		{
			[DebuggerStepThrough()]
			get { return this._printChargeTypeCount; }
			set 
			{
				if (this._printChargeTypeCount != value) 
				{
					this._printChargeTypeCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintChargeTypeCount");
				}
			}
		}
		
		
		
		#endregion
		
		#region Non-Public Properties
		/// <summary>
		/// Gets the SQL statement for an insert
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override string InsertSqlStatement
		{
			[DebuggerStepThrough()]
			get 
			{
				return @"
DECLARE @table TABLE(
	[ID] int,
	[ParentID] int,
	[Name] nvarchar(100),
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[TypeDesc] nvarchar(50),
	[Grade] nvarchar(20),
	[IconID] int,
	[Level] int,
	[isParent] bit,
	[PName] nvarchar(100),
	[CompanyID] int,
	[OrderBy] int,
	[FullName] nvarchar(500),
	[OriFullName] nvarchar(500),
	[AllParentID] nvarchar(500),
	[PrintNote] nvarchar(500),
	[CuiFeiNote] nvarchar(500),
	[DefaultOrder] nvarchar(200),
	[PrintTitle] nvarchar(200),
	[PrintFont] nvarchar(10),
	[IsPrintNote] bit,
	[IsPrintCount] bit,
	[PrintWidth] decimal(18, 2),
	[PrintHeight] decimal(18, 2),
	[PrintSubTitle] nvarchar(200),
	[IsPrintCost] bit,
	[IsPrintDiscount] bit,
	[PropertyID] int,
	[LogoPath] nvarchar(500),
	[PrintCancelNote] nvarchar(500),
	[CuiShouPrintTitle] nvarchar(200),
	[CuiShouPrintSubTitle] nvarchar(200),
	[IsPrintRoomNo] bit,
	[PrintType] nvarchar(100),
	[IsPrintTotalRealCost] bit,
	[IsPrintRealCost] bit,
	[IsDefinePrintSize] bit,
	[PrintTopMargin] decimal(18, 2),
	[PrintBottomMargin] decimal(18, 2),
	[PrintTotalLines] int,
	[IsPrintMonthCount] bit,
	[OrgnizationID] int,
	[AddressProvice] nvarchar(100),
	[AddressCity] nvarchar(100),
	[AddressDistrict] nvarchar(100),
	[PayPrintTitle] nvarchar(500),
	[PayPrintSubTitle] nvarchar(500),
	[AddressProvinceID] int,
	[LogoWidth] int,
	[LogoHeight] int,
	[IsPrintUnitPrice] bit,
	[PrintChargeTypeCount] int
);

INSERT INTO [dbo].[Project] (
	[Project].[ParentID],
	[Project].[Name],
	[Project].[Description],
	[Project].[AddTime],
	[Project].[AddMan],
	[Project].[TypeDesc],
	[Project].[Grade],
	[Project].[IconID],
	[Project].[Level],
	[Project].[isParent],
	[Project].[PName],
	[Project].[CompanyID],
	[Project].[OrderBy],
	[Project].[FullName],
	[Project].[OriFullName],
	[Project].[AllParentID],
	[Project].[PrintNote],
	[Project].[CuiFeiNote],
	[Project].[DefaultOrder],
	[Project].[PrintTitle],
	[Project].[PrintFont],
	[Project].[IsPrintNote],
	[Project].[IsPrintCount],
	[Project].[PrintWidth],
	[Project].[PrintHeight],
	[Project].[PrintSubTitle],
	[Project].[IsPrintCost],
	[Project].[IsPrintDiscount],
	[Project].[PropertyID],
	[Project].[LogoPath],
	[Project].[PrintCancelNote],
	[Project].[CuiShouPrintTitle],
	[Project].[CuiShouPrintSubTitle],
	[Project].[IsPrintRoomNo],
	[Project].[PrintType],
	[Project].[IsPrintTotalRealCost],
	[Project].[IsPrintRealCost],
	[Project].[IsDefinePrintSize],
	[Project].[PrintTopMargin],
	[Project].[PrintBottomMargin],
	[Project].[PrintTotalLines],
	[Project].[IsPrintMonthCount],
	[Project].[OrgnizationID],
	[Project].[AddressProvice],
	[Project].[AddressCity],
	[Project].[AddressDistrict],
	[Project].[PayPrintTitle],
	[Project].[PayPrintSubTitle],
	[Project].[AddressProvinceID],
	[Project].[LogoWidth],
	[Project].[LogoHeight],
	[Project].[IsPrintUnitPrice],
	[Project].[PrintChargeTypeCount]
) 
output 
	INSERTED.[ID],
	INSERTED.[ParentID],
	INSERTED.[Name],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[TypeDesc],
	INSERTED.[Grade],
	INSERTED.[IconID],
	INSERTED.[Level],
	INSERTED.[isParent],
	INSERTED.[PName],
	INSERTED.[CompanyID],
	INSERTED.[OrderBy],
	INSERTED.[FullName],
	INSERTED.[OriFullName],
	INSERTED.[AllParentID],
	INSERTED.[PrintNote],
	INSERTED.[CuiFeiNote],
	INSERTED.[DefaultOrder],
	INSERTED.[PrintTitle],
	INSERTED.[PrintFont],
	INSERTED.[IsPrintNote],
	INSERTED.[IsPrintCount],
	INSERTED.[PrintWidth],
	INSERTED.[PrintHeight],
	INSERTED.[PrintSubTitle],
	INSERTED.[IsPrintCost],
	INSERTED.[IsPrintDiscount],
	INSERTED.[PropertyID],
	INSERTED.[LogoPath],
	INSERTED.[PrintCancelNote],
	INSERTED.[CuiShouPrintTitle],
	INSERTED.[CuiShouPrintSubTitle],
	INSERTED.[IsPrintRoomNo],
	INSERTED.[PrintType],
	INSERTED.[IsPrintTotalRealCost],
	INSERTED.[IsPrintRealCost],
	INSERTED.[IsDefinePrintSize],
	INSERTED.[PrintTopMargin],
	INSERTED.[PrintBottomMargin],
	INSERTED.[PrintTotalLines],
	INSERTED.[IsPrintMonthCount],
	INSERTED.[OrgnizationID],
	INSERTED.[AddressProvice],
	INSERTED.[AddressCity],
	INSERTED.[AddressDistrict],
	INSERTED.[PayPrintTitle],
	INSERTED.[PayPrintSubTitle],
	INSERTED.[AddressProvinceID],
	INSERTED.[LogoWidth],
	INSERTED.[LogoHeight],
	INSERTED.[IsPrintUnitPrice],
	INSERTED.[PrintChargeTypeCount]
into @table
VALUES ( 
	@ParentID,
	@Name,
	@Description,
	@AddTime,
	@AddMan,
	@TypeDesc,
	@Grade,
	@IconID,
	@Level,
	@isParent,
	@PName,
	@CompanyID,
	@OrderBy,
	@FullName,
	@OriFullName,
	@AllParentID,
	@PrintNote,
	@CuiFeiNote,
	@DefaultOrder,
	@PrintTitle,
	@PrintFont,
	@IsPrintNote,
	@IsPrintCount,
	@PrintWidth,
	@PrintHeight,
	@PrintSubTitle,
	@IsPrintCost,
	@IsPrintDiscount,
	@PropertyID,
	@LogoPath,
	@PrintCancelNote,
	@CuiShouPrintTitle,
	@CuiShouPrintSubTitle,
	@IsPrintRoomNo,
	@PrintType,
	@IsPrintTotalRealCost,
	@IsPrintRealCost,
	@IsDefinePrintSize,
	@PrintTopMargin,
	@PrintBottomMargin,
	@PrintTotalLines,
	@IsPrintMonthCount,
	@OrgnizationID,
	@AddressProvice,
	@AddressCity,
	@AddressDistrict,
	@PayPrintTitle,
	@PayPrintSubTitle,
	@AddressProvinceID,
	@LogoWidth,
	@LogoHeight,
	@IsPrintUnitPrice,
	@PrintChargeTypeCount 
); 

SELECT 
	[ID],
	[ParentID],
	[Name],
	[Description],
	[AddTime],
	[AddMan],
	[TypeDesc],
	[Grade],
	[IconID],
	[Level],
	[isParent],
	[PName],
	[CompanyID],
	[OrderBy],
	[FullName],
	[OriFullName],
	[AllParentID],
	[PrintNote],
	[CuiFeiNote],
	[DefaultOrder],
	[PrintTitle],
	[PrintFont],
	[IsPrintNote],
	[IsPrintCount],
	[PrintWidth],
	[PrintHeight],
	[PrintSubTitle],
	[IsPrintCost],
	[IsPrintDiscount],
	[PropertyID],
	[LogoPath],
	[PrintCancelNote],
	[CuiShouPrintTitle],
	[CuiShouPrintSubTitle],
	[IsPrintRoomNo],
	[PrintType],
	[IsPrintTotalRealCost],
	[IsPrintRealCost],
	[IsDefinePrintSize],
	[PrintTopMargin],
	[PrintBottomMargin],
	[PrintTotalLines],
	[IsPrintMonthCount],
	[OrgnizationID],
	[AddressProvice],
	[AddressCity],
	[AddressDistrict],
	[PayPrintTitle],
	[PayPrintSubTitle],
	[AddressProvinceID],
	[LogoWidth],
	[LogoHeight],
	[IsPrintUnitPrice],
	[PrintChargeTypeCount] 
FROM @table;
";
			}
		}
		
		/// <summary>
		/// Gets the SQL statement for an update by key
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override string UpdateSqlStatement
		{
			[DebuggerStepThrough()]
			get
			{
				return @"
DECLARE @table TABLE(
	[ID] int,
	[ParentID] int,
	[Name] nvarchar(100),
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[TypeDesc] nvarchar(50),
	[Grade] nvarchar(20),
	[IconID] int,
	[Level] int,
	[isParent] bit,
	[PName] nvarchar(100),
	[CompanyID] int,
	[OrderBy] int,
	[FullName] nvarchar(500),
	[OriFullName] nvarchar(500),
	[AllParentID] nvarchar(500),
	[PrintNote] nvarchar(500),
	[CuiFeiNote] nvarchar(500),
	[DefaultOrder] nvarchar(200),
	[PrintTitle] nvarchar(200),
	[PrintFont] nvarchar(10),
	[IsPrintNote] bit,
	[IsPrintCount] bit,
	[PrintWidth] decimal(18, 2),
	[PrintHeight] decimal(18, 2),
	[PrintSubTitle] nvarchar(200),
	[IsPrintCost] bit,
	[IsPrintDiscount] bit,
	[PropertyID] int,
	[LogoPath] nvarchar(500),
	[PrintCancelNote] nvarchar(500),
	[CuiShouPrintTitle] nvarchar(200),
	[CuiShouPrintSubTitle] nvarchar(200),
	[IsPrintRoomNo] bit,
	[PrintType] nvarchar(100),
	[IsPrintTotalRealCost] bit,
	[IsPrintRealCost] bit,
	[IsDefinePrintSize] bit,
	[PrintTopMargin] decimal(18, 2),
	[PrintBottomMargin] decimal(18, 2),
	[PrintTotalLines] int,
	[IsPrintMonthCount] bit,
	[OrgnizationID] int,
	[AddressProvice] nvarchar(100),
	[AddressCity] nvarchar(100),
	[AddressDistrict] nvarchar(100),
	[PayPrintTitle] nvarchar(500),
	[PayPrintSubTitle] nvarchar(500),
	[AddressProvinceID] int,
	[LogoWidth] int,
	[LogoHeight] int,
	[IsPrintUnitPrice] bit,
	[PrintChargeTypeCount] int
);

UPDATE [dbo].[Project] SET 
	[Project].[ParentID] = @ParentID,
	[Project].[Name] = @Name,
	[Project].[Description] = @Description,
	[Project].[AddTime] = @AddTime,
	[Project].[AddMan] = @AddMan,
	[Project].[TypeDesc] = @TypeDesc,
	[Project].[Grade] = @Grade,
	[Project].[IconID] = @IconID,
	[Project].[Level] = @Level,
	[Project].[isParent] = @isParent,
	[Project].[PName] = @PName,
	[Project].[CompanyID] = @CompanyID,
	[Project].[OrderBy] = @OrderBy,
	[Project].[FullName] = @FullName,
	[Project].[OriFullName] = @OriFullName,
	[Project].[AllParentID] = @AllParentID,
	[Project].[PrintNote] = @PrintNote,
	[Project].[CuiFeiNote] = @CuiFeiNote,
	[Project].[DefaultOrder] = @DefaultOrder,
	[Project].[PrintTitle] = @PrintTitle,
	[Project].[PrintFont] = @PrintFont,
	[Project].[IsPrintNote] = @IsPrintNote,
	[Project].[IsPrintCount] = @IsPrintCount,
	[Project].[PrintWidth] = @PrintWidth,
	[Project].[PrintHeight] = @PrintHeight,
	[Project].[PrintSubTitle] = @PrintSubTitle,
	[Project].[IsPrintCost] = @IsPrintCost,
	[Project].[IsPrintDiscount] = @IsPrintDiscount,
	[Project].[PropertyID] = @PropertyID,
	[Project].[LogoPath] = @LogoPath,
	[Project].[PrintCancelNote] = @PrintCancelNote,
	[Project].[CuiShouPrintTitle] = @CuiShouPrintTitle,
	[Project].[CuiShouPrintSubTitle] = @CuiShouPrintSubTitle,
	[Project].[IsPrintRoomNo] = @IsPrintRoomNo,
	[Project].[PrintType] = @PrintType,
	[Project].[IsPrintTotalRealCost] = @IsPrintTotalRealCost,
	[Project].[IsPrintRealCost] = @IsPrintRealCost,
	[Project].[IsDefinePrintSize] = @IsDefinePrintSize,
	[Project].[PrintTopMargin] = @PrintTopMargin,
	[Project].[PrintBottomMargin] = @PrintBottomMargin,
	[Project].[PrintTotalLines] = @PrintTotalLines,
	[Project].[IsPrintMonthCount] = @IsPrintMonthCount,
	[Project].[OrgnizationID] = @OrgnizationID,
	[Project].[AddressProvice] = @AddressProvice,
	[Project].[AddressCity] = @AddressCity,
	[Project].[AddressDistrict] = @AddressDistrict,
	[Project].[PayPrintTitle] = @PayPrintTitle,
	[Project].[PayPrintSubTitle] = @PayPrintSubTitle,
	[Project].[AddressProvinceID] = @AddressProvinceID,
	[Project].[LogoWidth] = @LogoWidth,
	[Project].[LogoHeight] = @LogoHeight,
	[Project].[IsPrintUnitPrice] = @IsPrintUnitPrice,
	[Project].[PrintChargeTypeCount] = @PrintChargeTypeCount 
output 
	INSERTED.[ID],
	INSERTED.[ParentID],
	INSERTED.[Name],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[TypeDesc],
	INSERTED.[Grade],
	INSERTED.[IconID],
	INSERTED.[Level],
	INSERTED.[isParent],
	INSERTED.[PName],
	INSERTED.[CompanyID],
	INSERTED.[OrderBy],
	INSERTED.[FullName],
	INSERTED.[OriFullName],
	INSERTED.[AllParentID],
	INSERTED.[PrintNote],
	INSERTED.[CuiFeiNote],
	INSERTED.[DefaultOrder],
	INSERTED.[PrintTitle],
	INSERTED.[PrintFont],
	INSERTED.[IsPrintNote],
	INSERTED.[IsPrintCount],
	INSERTED.[PrintWidth],
	INSERTED.[PrintHeight],
	INSERTED.[PrintSubTitle],
	INSERTED.[IsPrintCost],
	INSERTED.[IsPrintDiscount],
	INSERTED.[PropertyID],
	INSERTED.[LogoPath],
	INSERTED.[PrintCancelNote],
	INSERTED.[CuiShouPrintTitle],
	INSERTED.[CuiShouPrintSubTitle],
	INSERTED.[IsPrintRoomNo],
	INSERTED.[PrintType],
	INSERTED.[IsPrintTotalRealCost],
	INSERTED.[IsPrintRealCost],
	INSERTED.[IsDefinePrintSize],
	INSERTED.[PrintTopMargin],
	INSERTED.[PrintBottomMargin],
	INSERTED.[PrintTotalLines],
	INSERTED.[IsPrintMonthCount],
	INSERTED.[OrgnizationID],
	INSERTED.[AddressProvice],
	INSERTED.[AddressCity],
	INSERTED.[AddressDistrict],
	INSERTED.[PayPrintTitle],
	INSERTED.[PayPrintSubTitle],
	INSERTED.[AddressProvinceID],
	INSERTED.[LogoWidth],
	INSERTED.[LogoHeight],
	INSERTED.[IsPrintUnitPrice],
	INSERTED.[PrintChargeTypeCount]
into @table
WHERE 
	[Project].[ID] = @ID

SELECT 
	[ID],
	[ParentID],
	[Name],
	[Description],
	[AddTime],
	[AddMan],
	[TypeDesc],
	[Grade],
	[IconID],
	[Level],
	[isParent],
	[PName],
	[CompanyID],
	[OrderBy],
	[FullName],
	[OriFullName],
	[AllParentID],
	[PrintNote],
	[CuiFeiNote],
	[DefaultOrder],
	[PrintTitle],
	[PrintFont],
	[IsPrintNote],
	[IsPrintCount],
	[PrintWidth],
	[PrintHeight],
	[PrintSubTitle],
	[IsPrintCost],
	[IsPrintDiscount],
	[PropertyID],
	[LogoPath],
	[PrintCancelNote],
	[CuiShouPrintTitle],
	[CuiShouPrintSubTitle],
	[IsPrintRoomNo],
	[PrintType],
	[IsPrintTotalRealCost],
	[IsPrintRealCost],
	[IsDefinePrintSize],
	[PrintTopMargin],
	[PrintBottomMargin],
	[PrintTotalLines],
	[IsPrintMonthCount],
	[OrgnizationID],
	[AddressProvice],
	[AddressCity],
	[AddressDistrict],
	[PayPrintTitle],
	[PayPrintSubTitle],
	[AddressProvinceID],
	[LogoWidth],
	[LogoHeight],
	[IsPrintUnitPrice],
	[PrintChargeTypeCount] 
FROM @table;
";
			}
		}
		
		/// <summary>
		/// Gets the SQL statement for a delete by key
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override string DeleteSqlStatement
		{
			[DebuggerStepThrough()]
			get
			{
				return @"
DELETE FROM [dbo].[Project]
WHERE 
	[Project].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Project() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetProject(this.ID));
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
	[Project].[ID],
	[Project].[ParentID],
	[Project].[Name],
	[Project].[Description],
	[Project].[AddTime],
	[Project].[AddMan],
	[Project].[TypeDesc],
	[Project].[Grade],
	[Project].[IconID],
	[Project].[Level],
	[Project].[isParent],
	[Project].[PName],
	[Project].[CompanyID],
	[Project].[OrderBy],
	[Project].[FullName],
	[Project].[OriFullName],
	[Project].[AllParentID],
	[Project].[PrintNote],
	[Project].[CuiFeiNote],
	[Project].[DefaultOrder],
	[Project].[PrintTitle],
	[Project].[PrintFont],
	[Project].[IsPrintNote],
	[Project].[IsPrintCount],
	[Project].[PrintWidth],
	[Project].[PrintHeight],
	[Project].[PrintSubTitle],
	[Project].[IsPrintCost],
	[Project].[IsPrintDiscount],
	[Project].[PropertyID],
	[Project].[LogoPath],
	[Project].[PrintCancelNote],
	[Project].[CuiShouPrintTitle],
	[Project].[CuiShouPrintSubTitle],
	[Project].[IsPrintRoomNo],
	[Project].[PrintType],
	[Project].[IsPrintTotalRealCost],
	[Project].[IsPrintRealCost],
	[Project].[IsDefinePrintSize],
	[Project].[PrintTopMargin],
	[Project].[PrintBottomMargin],
	[Project].[PrintTotalLines],
	[Project].[IsPrintMonthCount],
	[Project].[OrgnizationID],
	[Project].[AddressProvice],
	[Project].[AddressCity],
	[Project].[AddressDistrict],
	[Project].[PayPrintTitle],
	[Project].[PayPrintSubTitle],
	[Project].[AddressProvinceID],
	[Project].[LogoWidth],
	[Project].[LogoHeight],
	[Project].[IsPrintUnitPrice],
	[Project].[PrintChargeTypeCount]
";
			}
		}
		
		
		/// <summary>
        /// Table Name
        /// </summary>
        public new static string TableName
        {
            get
            {
                return "Project";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Project into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="parentID">parentID</param>
		/// <param name="name">name</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="typeDesc">typeDesc</param>
		/// <param name="grade">grade</param>
		/// <param name="iconID">iconID</param>
		/// <param name="level">level</param>
		/// <param name="isParent">isParent</param>
		/// <param name="pName">pName</param>
		/// <param name="companyID">companyID</param>
		/// <param name="orderBy">orderBy</param>
		/// <param name="fullName">fullName</param>
		/// <param name="oriFullName">oriFullName</param>
		/// <param name="allParentID">allParentID</param>
		/// <param name="printNote">printNote</param>
		/// <param name="cuiFeiNote">cuiFeiNote</param>
		/// <param name="defaultOrder">defaultOrder</param>
		/// <param name="printTitle">printTitle</param>
		/// <param name="printFont">printFont</param>
		/// <param name="isPrintNote">isPrintNote</param>
		/// <param name="isPrintCount">isPrintCount</param>
		/// <param name="printWidth">printWidth</param>
		/// <param name="printHeight">printHeight</param>
		/// <param name="printSubTitle">printSubTitle</param>
		/// <param name="isPrintCost">isPrintCost</param>
		/// <param name="isPrintDiscount">isPrintDiscount</param>
		/// <param name="propertyID">propertyID</param>
		/// <param name="logoPath">logoPath</param>
		/// <param name="printCancelNote">printCancelNote</param>
		/// <param name="cuiShouPrintTitle">cuiShouPrintTitle</param>
		/// <param name="cuiShouPrintSubTitle">cuiShouPrintSubTitle</param>
		/// <param name="isPrintRoomNo">isPrintRoomNo</param>
		/// <param name="printType">printType</param>
		/// <param name="isPrintTotalRealCost">isPrintTotalRealCost</param>
		/// <param name="isPrintRealCost">isPrintRealCost</param>
		/// <param name="isDefinePrintSize">isDefinePrintSize</param>
		/// <param name="printTopMargin">printTopMargin</param>
		/// <param name="printBottomMargin">printBottomMargin</param>
		/// <param name="printTotalLines">printTotalLines</param>
		/// <param name="isPrintMonthCount">isPrintMonthCount</param>
		/// <param name="orgnizationID">orgnizationID</param>
		/// <param name="addressProvice">addressProvice</param>
		/// <param name="addressCity">addressCity</param>
		/// <param name="addressDistrict">addressDistrict</param>
		/// <param name="payPrintTitle">payPrintTitle</param>
		/// <param name="payPrintSubTitle">payPrintSubTitle</param>
		/// <param name="addressProvinceID">addressProvinceID</param>
		/// <param name="logoWidth">logoWidth</param>
		/// <param name="logoHeight">logoHeight</param>
		/// <param name="isPrintUnitPrice">isPrintUnitPrice</param>
		/// <param name="printChargeTypeCount">printChargeTypeCount</param>
		public static void InsertProject(int @parentID, string @name, string @description, DateTime @addTime, string @addMan, string @typeDesc, string @grade, int @iconID, int @level, bool @isParent, string @pName, int @companyID, int @orderBy, string @fullName, string @oriFullName, string @allParentID, string @printNote, string @cuiFeiNote, string @defaultOrder, string @printTitle, string @printFont, bool @isPrintNote, bool @isPrintCount, decimal @printWidth, decimal @printHeight, string @printSubTitle, bool @isPrintCost, bool @isPrintDiscount, int @propertyID, string @logoPath, string @printCancelNote, string @cuiShouPrintTitle, string @cuiShouPrintSubTitle, bool @isPrintRoomNo, string @printType, bool @isPrintTotalRealCost, bool @isPrintRealCost, bool @isDefinePrintSize, decimal @printTopMargin, decimal @printBottomMargin, int @printTotalLines, bool @isPrintMonthCount, int @orgnizationID, string @addressProvice, string @addressCity, string @addressDistrict, string @payPrintTitle, string @payPrintSubTitle, int @addressProvinceID, int @logoWidth, int @logoHeight, bool @isPrintUnitPrice, int @printChargeTypeCount)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertProject(@parentID, @name, @description, @addTime, @addMan, @typeDesc, @grade, @iconID, @level, @isParent, @pName, @companyID, @orderBy, @fullName, @oriFullName, @allParentID, @printNote, @cuiFeiNote, @defaultOrder, @printTitle, @printFont, @isPrintNote, @isPrintCount, @printWidth, @printHeight, @printSubTitle, @isPrintCost, @isPrintDiscount, @propertyID, @logoPath, @printCancelNote, @cuiShouPrintTitle, @cuiShouPrintSubTitle, @isPrintRoomNo, @printType, @isPrintTotalRealCost, @isPrintRealCost, @isDefinePrintSize, @printTopMargin, @printBottomMargin, @printTotalLines, @isPrintMonthCount, @orgnizationID, @addressProvice, @addressCity, @addressDistrict, @payPrintTitle, @payPrintSubTitle, @addressProvinceID, @logoWidth, @logoHeight, @isPrintUnitPrice, @printChargeTypeCount, helper);
                    helper.Commit();
                }
                catch
                {
                    helper.Rollback();
                    throw;
                }
            }
		}

		/// <summary>
		/// Insert a Project into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="parentID">parentID</param>
		/// <param name="name">name</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="typeDesc">typeDesc</param>
		/// <param name="grade">grade</param>
		/// <param name="iconID">iconID</param>
		/// <param name="level">level</param>
		/// <param name="isParent">isParent</param>
		/// <param name="pName">pName</param>
		/// <param name="companyID">companyID</param>
		/// <param name="orderBy">orderBy</param>
		/// <param name="fullName">fullName</param>
		/// <param name="oriFullName">oriFullName</param>
		/// <param name="allParentID">allParentID</param>
		/// <param name="printNote">printNote</param>
		/// <param name="cuiFeiNote">cuiFeiNote</param>
		/// <param name="defaultOrder">defaultOrder</param>
		/// <param name="printTitle">printTitle</param>
		/// <param name="printFont">printFont</param>
		/// <param name="isPrintNote">isPrintNote</param>
		/// <param name="isPrintCount">isPrintCount</param>
		/// <param name="printWidth">printWidth</param>
		/// <param name="printHeight">printHeight</param>
		/// <param name="printSubTitle">printSubTitle</param>
		/// <param name="isPrintCost">isPrintCost</param>
		/// <param name="isPrintDiscount">isPrintDiscount</param>
		/// <param name="propertyID">propertyID</param>
		/// <param name="logoPath">logoPath</param>
		/// <param name="printCancelNote">printCancelNote</param>
		/// <param name="cuiShouPrintTitle">cuiShouPrintTitle</param>
		/// <param name="cuiShouPrintSubTitle">cuiShouPrintSubTitle</param>
		/// <param name="isPrintRoomNo">isPrintRoomNo</param>
		/// <param name="printType">printType</param>
		/// <param name="isPrintTotalRealCost">isPrintTotalRealCost</param>
		/// <param name="isPrintRealCost">isPrintRealCost</param>
		/// <param name="isDefinePrintSize">isDefinePrintSize</param>
		/// <param name="printTopMargin">printTopMargin</param>
		/// <param name="printBottomMargin">printBottomMargin</param>
		/// <param name="printTotalLines">printTotalLines</param>
		/// <param name="isPrintMonthCount">isPrintMonthCount</param>
		/// <param name="orgnizationID">orgnizationID</param>
		/// <param name="addressProvice">addressProvice</param>
		/// <param name="addressCity">addressCity</param>
		/// <param name="addressDistrict">addressDistrict</param>
		/// <param name="payPrintTitle">payPrintTitle</param>
		/// <param name="payPrintSubTitle">payPrintSubTitle</param>
		/// <param name="addressProvinceID">addressProvinceID</param>
		/// <param name="logoWidth">logoWidth</param>
		/// <param name="logoHeight">logoHeight</param>
		/// <param name="isPrintUnitPrice">isPrintUnitPrice</param>
		/// <param name="printChargeTypeCount">printChargeTypeCount</param>
		/// <param name="helper">helper</param>
		internal static void InsertProject(int @parentID, string @name, string @description, DateTime @addTime, string @addMan, string @typeDesc, string @grade, int @iconID, int @level, bool @isParent, string @pName, int @companyID, int @orderBy, string @fullName, string @oriFullName, string @allParentID, string @printNote, string @cuiFeiNote, string @defaultOrder, string @printTitle, string @printFont, bool @isPrintNote, bool @isPrintCount, decimal @printWidth, decimal @printHeight, string @printSubTitle, bool @isPrintCost, bool @isPrintDiscount, int @propertyID, string @logoPath, string @printCancelNote, string @cuiShouPrintTitle, string @cuiShouPrintSubTitle, bool @isPrintRoomNo, string @printType, bool @isPrintTotalRealCost, bool @isPrintRealCost, bool @isDefinePrintSize, decimal @printTopMargin, decimal @printBottomMargin, int @printTotalLines, bool @isPrintMonthCount, int @orgnizationID, string @addressProvice, string @addressCity, string @addressDistrict, string @payPrintTitle, string @payPrintSubTitle, int @addressProvinceID, int @logoWidth, int @logoHeight, bool @isPrintUnitPrice, int @printChargeTypeCount, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ParentID] int,
	[Name] nvarchar(100),
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[TypeDesc] nvarchar(50),
	[Grade] nvarchar(20),
	[IconID] int,
	[Level] int,
	[isParent] bit,
	[PName] nvarchar(100),
	[CompanyID] int,
	[OrderBy] int,
	[FullName] nvarchar(500),
	[OriFullName] nvarchar(500),
	[AllParentID] nvarchar(500),
	[PrintNote] nvarchar(500),
	[CuiFeiNote] nvarchar(500),
	[DefaultOrder] nvarchar(200),
	[PrintTitle] nvarchar(200),
	[PrintFont] nvarchar(10),
	[IsPrintNote] bit,
	[IsPrintCount] bit,
	[PrintWidth] decimal(18, 2),
	[PrintHeight] decimal(18, 2),
	[PrintSubTitle] nvarchar(200),
	[IsPrintCost] bit,
	[IsPrintDiscount] bit,
	[PropertyID] int,
	[LogoPath] nvarchar(500),
	[PrintCancelNote] nvarchar(500),
	[CuiShouPrintTitle] nvarchar(200),
	[CuiShouPrintSubTitle] nvarchar(200),
	[IsPrintRoomNo] bit,
	[PrintType] nvarchar(100),
	[IsPrintTotalRealCost] bit,
	[IsPrintRealCost] bit,
	[IsDefinePrintSize] bit,
	[PrintTopMargin] decimal(18, 2),
	[PrintBottomMargin] decimal(18, 2),
	[PrintTotalLines] int,
	[IsPrintMonthCount] bit,
	[OrgnizationID] int,
	[AddressProvice] nvarchar(100),
	[AddressCity] nvarchar(100),
	[AddressDistrict] nvarchar(100),
	[PayPrintTitle] nvarchar(500),
	[PayPrintSubTitle] nvarchar(500),
	[AddressProvinceID] int,
	[LogoWidth] int,
	[LogoHeight] int,
	[IsPrintUnitPrice] bit,
	[PrintChargeTypeCount] int
);

INSERT INTO [dbo].[Project] (
	[Project].[ParentID],
	[Project].[Name],
	[Project].[Description],
	[Project].[AddTime],
	[Project].[AddMan],
	[Project].[TypeDesc],
	[Project].[Grade],
	[Project].[IconID],
	[Project].[Level],
	[Project].[isParent],
	[Project].[PName],
	[Project].[CompanyID],
	[Project].[OrderBy],
	[Project].[FullName],
	[Project].[OriFullName],
	[Project].[AllParentID],
	[Project].[PrintNote],
	[Project].[CuiFeiNote],
	[Project].[DefaultOrder],
	[Project].[PrintTitle],
	[Project].[PrintFont],
	[Project].[IsPrintNote],
	[Project].[IsPrintCount],
	[Project].[PrintWidth],
	[Project].[PrintHeight],
	[Project].[PrintSubTitle],
	[Project].[IsPrintCost],
	[Project].[IsPrintDiscount],
	[Project].[PropertyID],
	[Project].[LogoPath],
	[Project].[PrintCancelNote],
	[Project].[CuiShouPrintTitle],
	[Project].[CuiShouPrintSubTitle],
	[Project].[IsPrintRoomNo],
	[Project].[PrintType],
	[Project].[IsPrintTotalRealCost],
	[Project].[IsPrintRealCost],
	[Project].[IsDefinePrintSize],
	[Project].[PrintTopMargin],
	[Project].[PrintBottomMargin],
	[Project].[PrintTotalLines],
	[Project].[IsPrintMonthCount],
	[Project].[OrgnizationID],
	[Project].[AddressProvice],
	[Project].[AddressCity],
	[Project].[AddressDistrict],
	[Project].[PayPrintTitle],
	[Project].[PayPrintSubTitle],
	[Project].[AddressProvinceID],
	[Project].[LogoWidth],
	[Project].[LogoHeight],
	[Project].[IsPrintUnitPrice],
	[Project].[PrintChargeTypeCount]
) 
output 
	INSERTED.[ID],
	INSERTED.[ParentID],
	INSERTED.[Name],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[TypeDesc],
	INSERTED.[Grade],
	INSERTED.[IconID],
	INSERTED.[Level],
	INSERTED.[isParent],
	INSERTED.[PName],
	INSERTED.[CompanyID],
	INSERTED.[OrderBy],
	INSERTED.[FullName],
	INSERTED.[OriFullName],
	INSERTED.[AllParentID],
	INSERTED.[PrintNote],
	INSERTED.[CuiFeiNote],
	INSERTED.[DefaultOrder],
	INSERTED.[PrintTitle],
	INSERTED.[PrintFont],
	INSERTED.[IsPrintNote],
	INSERTED.[IsPrintCount],
	INSERTED.[PrintWidth],
	INSERTED.[PrintHeight],
	INSERTED.[PrintSubTitle],
	INSERTED.[IsPrintCost],
	INSERTED.[IsPrintDiscount],
	INSERTED.[PropertyID],
	INSERTED.[LogoPath],
	INSERTED.[PrintCancelNote],
	INSERTED.[CuiShouPrintTitle],
	INSERTED.[CuiShouPrintSubTitle],
	INSERTED.[IsPrintRoomNo],
	INSERTED.[PrintType],
	INSERTED.[IsPrintTotalRealCost],
	INSERTED.[IsPrintRealCost],
	INSERTED.[IsDefinePrintSize],
	INSERTED.[PrintTopMargin],
	INSERTED.[PrintBottomMargin],
	INSERTED.[PrintTotalLines],
	INSERTED.[IsPrintMonthCount],
	INSERTED.[OrgnizationID],
	INSERTED.[AddressProvice],
	INSERTED.[AddressCity],
	INSERTED.[AddressDistrict],
	INSERTED.[PayPrintTitle],
	INSERTED.[PayPrintSubTitle],
	INSERTED.[AddressProvinceID],
	INSERTED.[LogoWidth],
	INSERTED.[LogoHeight],
	INSERTED.[IsPrintUnitPrice],
	INSERTED.[PrintChargeTypeCount]
into @table
VALUES ( 
	@ParentID,
	@Name,
	@Description,
	@AddTime,
	@AddMan,
	@TypeDesc,
	@Grade,
	@IconID,
	@Level,
	@isParent,
	@PName,
	@CompanyID,
	@OrderBy,
	@FullName,
	@OriFullName,
	@AllParentID,
	@PrintNote,
	@CuiFeiNote,
	@DefaultOrder,
	@PrintTitle,
	@PrintFont,
	@IsPrintNote,
	@IsPrintCount,
	@PrintWidth,
	@PrintHeight,
	@PrintSubTitle,
	@IsPrintCost,
	@IsPrintDiscount,
	@PropertyID,
	@LogoPath,
	@PrintCancelNote,
	@CuiShouPrintTitle,
	@CuiShouPrintSubTitle,
	@IsPrintRoomNo,
	@PrintType,
	@IsPrintTotalRealCost,
	@IsPrintRealCost,
	@IsDefinePrintSize,
	@PrintTopMargin,
	@PrintBottomMargin,
	@PrintTotalLines,
	@IsPrintMonthCount,
	@OrgnizationID,
	@AddressProvice,
	@AddressCity,
	@AddressDistrict,
	@PayPrintTitle,
	@PayPrintSubTitle,
	@AddressProvinceID,
	@LogoWidth,
	@LogoHeight,
	@IsPrintUnitPrice,
	@PrintChargeTypeCount 
); 

SELECT 
	[ID],
	[ParentID],
	[Name],
	[Description],
	[AddTime],
	[AddMan],
	[TypeDesc],
	[Grade],
	[IconID],
	[Level],
	[isParent],
	[PName],
	[CompanyID],
	[OrderBy],
	[FullName],
	[OriFullName],
	[AllParentID],
	[PrintNote],
	[CuiFeiNote],
	[DefaultOrder],
	[PrintTitle],
	[PrintFont],
	[IsPrintNote],
	[IsPrintCount],
	[PrintWidth],
	[PrintHeight],
	[PrintSubTitle],
	[IsPrintCost],
	[IsPrintDiscount],
	[PropertyID],
	[LogoPath],
	[PrintCancelNote],
	[CuiShouPrintTitle],
	[CuiShouPrintSubTitle],
	[IsPrintRoomNo],
	[PrintType],
	[IsPrintTotalRealCost],
	[IsPrintRealCost],
	[IsDefinePrintSize],
	[PrintTopMargin],
	[PrintBottomMargin],
	[PrintTotalLines],
	[IsPrintMonthCount],
	[OrgnizationID],
	[AddressProvice],
	[AddressCity],
	[AddressDistrict],
	[PayPrintTitle],
	[PayPrintSubTitle],
	[AddressProvinceID],
	[LogoWidth],
	[LogoHeight],
	[IsPrintUnitPrice],
	[PrintChargeTypeCount] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@TypeDesc", EntityBase.GetDatabaseValue(@typeDesc)));
			parameters.Add(new SqlParameter("@Grade", EntityBase.GetDatabaseValue(@grade)));
			parameters.Add(new SqlParameter("@IconID", EntityBase.GetDatabaseValue(@iconID)));
			parameters.Add(new SqlParameter("@Level", EntityBase.GetDatabaseValue(@level)));
			parameters.Add(new SqlParameter("@isParent", @isParent));
			parameters.Add(new SqlParameter("@PName", EntityBase.GetDatabaseValue(@pName)));
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			parameters.Add(new SqlParameter("@OrderBy", EntityBase.GetDatabaseValue(@orderBy)));
			parameters.Add(new SqlParameter("@FullName", EntityBase.GetDatabaseValue(@fullName)));
			parameters.Add(new SqlParameter("@OriFullName", EntityBase.GetDatabaseValue(@oriFullName)));
			parameters.Add(new SqlParameter("@AllParentID", EntityBase.GetDatabaseValue(@allParentID)));
			parameters.Add(new SqlParameter("@PrintNote", EntityBase.GetDatabaseValue(@printNote)));
			parameters.Add(new SqlParameter("@CuiFeiNote", EntityBase.GetDatabaseValue(@cuiFeiNote)));
			parameters.Add(new SqlParameter("@DefaultOrder", EntityBase.GetDatabaseValue(@defaultOrder)));
			parameters.Add(new SqlParameter("@PrintTitle", EntityBase.GetDatabaseValue(@printTitle)));
			parameters.Add(new SqlParameter("@PrintFont", EntityBase.GetDatabaseValue(@printFont)));
			parameters.Add(new SqlParameter("@IsPrintNote", @isPrintNote));
			parameters.Add(new SqlParameter("@IsPrintCount", @isPrintCount));
			parameters.Add(new SqlParameter("@PrintWidth", EntityBase.GetDatabaseValue(@printWidth)));
			parameters.Add(new SqlParameter("@PrintHeight", EntityBase.GetDatabaseValue(@printHeight)));
			parameters.Add(new SqlParameter("@PrintSubTitle", EntityBase.GetDatabaseValue(@printSubTitle)));
			parameters.Add(new SqlParameter("@IsPrintCost", @isPrintCost));
			parameters.Add(new SqlParameter("@IsPrintDiscount", @isPrintDiscount));
			parameters.Add(new SqlParameter("@PropertyID", EntityBase.GetDatabaseValue(@propertyID)));
			parameters.Add(new SqlParameter("@LogoPath", EntityBase.GetDatabaseValue(@logoPath)));
			parameters.Add(new SqlParameter("@PrintCancelNote", EntityBase.GetDatabaseValue(@printCancelNote)));
			parameters.Add(new SqlParameter("@CuiShouPrintTitle", EntityBase.GetDatabaseValue(@cuiShouPrintTitle)));
			parameters.Add(new SqlParameter("@CuiShouPrintSubTitle", EntityBase.GetDatabaseValue(@cuiShouPrintSubTitle)));
			parameters.Add(new SqlParameter("@IsPrintRoomNo", @isPrintRoomNo));
			parameters.Add(new SqlParameter("@PrintType", EntityBase.GetDatabaseValue(@printType)));
			parameters.Add(new SqlParameter("@IsPrintTotalRealCost", @isPrintTotalRealCost));
			parameters.Add(new SqlParameter("@IsPrintRealCost", @isPrintRealCost));
			parameters.Add(new SqlParameter("@IsDefinePrintSize", @isDefinePrintSize));
			parameters.Add(new SqlParameter("@PrintTopMargin", EntityBase.GetDatabaseValue(@printTopMargin)));
			parameters.Add(new SqlParameter("@PrintBottomMargin", EntityBase.GetDatabaseValue(@printBottomMargin)));
			parameters.Add(new SqlParameter("@PrintTotalLines", EntityBase.GetDatabaseValue(@printTotalLines)));
			parameters.Add(new SqlParameter("@IsPrintMonthCount", @isPrintMonthCount));
			parameters.Add(new SqlParameter("@OrgnizationID", EntityBase.GetDatabaseValue(@orgnizationID)));
			parameters.Add(new SqlParameter("@AddressProvice", EntityBase.GetDatabaseValue(@addressProvice)));
			parameters.Add(new SqlParameter("@AddressCity", EntityBase.GetDatabaseValue(@addressCity)));
			parameters.Add(new SqlParameter("@AddressDistrict", EntityBase.GetDatabaseValue(@addressDistrict)));
			parameters.Add(new SqlParameter("@PayPrintTitle", EntityBase.GetDatabaseValue(@payPrintTitle)));
			parameters.Add(new SqlParameter("@PayPrintSubTitle", EntityBase.GetDatabaseValue(@payPrintSubTitle)));
			parameters.Add(new SqlParameter("@AddressProvinceID", EntityBase.GetDatabaseValue(@addressProvinceID)));
			parameters.Add(new SqlParameter("@LogoWidth", EntityBase.GetDatabaseValue(@logoWidth)));
			parameters.Add(new SqlParameter("@LogoHeight", EntityBase.GetDatabaseValue(@logoHeight)));
			parameters.Add(new SqlParameter("@IsPrintUnitPrice", @isPrintUnitPrice));
			parameters.Add(new SqlParameter("@PrintChargeTypeCount", EntityBase.GetDatabaseValue(@printChargeTypeCount)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Project into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="parentID">parentID</param>
		/// <param name="name">name</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="typeDesc">typeDesc</param>
		/// <param name="grade">grade</param>
		/// <param name="iconID">iconID</param>
		/// <param name="level">level</param>
		/// <param name="isParent">isParent</param>
		/// <param name="pName">pName</param>
		/// <param name="companyID">companyID</param>
		/// <param name="orderBy">orderBy</param>
		/// <param name="fullName">fullName</param>
		/// <param name="oriFullName">oriFullName</param>
		/// <param name="allParentID">allParentID</param>
		/// <param name="printNote">printNote</param>
		/// <param name="cuiFeiNote">cuiFeiNote</param>
		/// <param name="defaultOrder">defaultOrder</param>
		/// <param name="printTitle">printTitle</param>
		/// <param name="printFont">printFont</param>
		/// <param name="isPrintNote">isPrintNote</param>
		/// <param name="isPrintCount">isPrintCount</param>
		/// <param name="printWidth">printWidth</param>
		/// <param name="printHeight">printHeight</param>
		/// <param name="printSubTitle">printSubTitle</param>
		/// <param name="isPrintCost">isPrintCost</param>
		/// <param name="isPrintDiscount">isPrintDiscount</param>
		/// <param name="propertyID">propertyID</param>
		/// <param name="logoPath">logoPath</param>
		/// <param name="printCancelNote">printCancelNote</param>
		/// <param name="cuiShouPrintTitle">cuiShouPrintTitle</param>
		/// <param name="cuiShouPrintSubTitle">cuiShouPrintSubTitle</param>
		/// <param name="isPrintRoomNo">isPrintRoomNo</param>
		/// <param name="printType">printType</param>
		/// <param name="isPrintTotalRealCost">isPrintTotalRealCost</param>
		/// <param name="isPrintRealCost">isPrintRealCost</param>
		/// <param name="isDefinePrintSize">isDefinePrintSize</param>
		/// <param name="printTopMargin">printTopMargin</param>
		/// <param name="printBottomMargin">printBottomMargin</param>
		/// <param name="printTotalLines">printTotalLines</param>
		/// <param name="isPrintMonthCount">isPrintMonthCount</param>
		/// <param name="orgnizationID">orgnizationID</param>
		/// <param name="addressProvice">addressProvice</param>
		/// <param name="addressCity">addressCity</param>
		/// <param name="addressDistrict">addressDistrict</param>
		/// <param name="payPrintTitle">payPrintTitle</param>
		/// <param name="payPrintSubTitle">payPrintSubTitle</param>
		/// <param name="addressProvinceID">addressProvinceID</param>
		/// <param name="logoWidth">logoWidth</param>
		/// <param name="logoHeight">logoHeight</param>
		/// <param name="isPrintUnitPrice">isPrintUnitPrice</param>
		/// <param name="printChargeTypeCount">printChargeTypeCount</param>
		public static void UpdateProject(int @iD, int @parentID, string @name, string @description, DateTime @addTime, string @addMan, string @typeDesc, string @grade, int @iconID, int @level, bool @isParent, string @pName, int @companyID, int @orderBy, string @fullName, string @oriFullName, string @allParentID, string @printNote, string @cuiFeiNote, string @defaultOrder, string @printTitle, string @printFont, bool @isPrintNote, bool @isPrintCount, decimal @printWidth, decimal @printHeight, string @printSubTitle, bool @isPrintCost, bool @isPrintDiscount, int @propertyID, string @logoPath, string @printCancelNote, string @cuiShouPrintTitle, string @cuiShouPrintSubTitle, bool @isPrintRoomNo, string @printType, bool @isPrintTotalRealCost, bool @isPrintRealCost, bool @isDefinePrintSize, decimal @printTopMargin, decimal @printBottomMargin, int @printTotalLines, bool @isPrintMonthCount, int @orgnizationID, string @addressProvice, string @addressCity, string @addressDistrict, string @payPrintTitle, string @payPrintSubTitle, int @addressProvinceID, int @logoWidth, int @logoHeight, bool @isPrintUnitPrice, int @printChargeTypeCount)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateProject(@iD, @parentID, @name, @description, @addTime, @addMan, @typeDesc, @grade, @iconID, @level, @isParent, @pName, @companyID, @orderBy, @fullName, @oriFullName, @allParentID, @printNote, @cuiFeiNote, @defaultOrder, @printTitle, @printFont, @isPrintNote, @isPrintCount, @printWidth, @printHeight, @printSubTitle, @isPrintCost, @isPrintDiscount, @propertyID, @logoPath, @printCancelNote, @cuiShouPrintTitle, @cuiShouPrintSubTitle, @isPrintRoomNo, @printType, @isPrintTotalRealCost, @isPrintRealCost, @isDefinePrintSize, @printTopMargin, @printBottomMargin, @printTotalLines, @isPrintMonthCount, @orgnizationID, @addressProvice, @addressCity, @addressDistrict, @payPrintTitle, @payPrintSubTitle, @addressProvinceID, @logoWidth, @logoHeight, @isPrintUnitPrice, @printChargeTypeCount, helper);
					helper.Commit();
				}
				catch 
				{
					helper.Rollback();	
					throw;
				}
			}
		}
		
		/// <summary>
		/// Updates a Project into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="parentID">parentID</param>
		/// <param name="name">name</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="typeDesc">typeDesc</param>
		/// <param name="grade">grade</param>
		/// <param name="iconID">iconID</param>
		/// <param name="level">level</param>
		/// <param name="isParent">isParent</param>
		/// <param name="pName">pName</param>
		/// <param name="companyID">companyID</param>
		/// <param name="orderBy">orderBy</param>
		/// <param name="fullName">fullName</param>
		/// <param name="oriFullName">oriFullName</param>
		/// <param name="allParentID">allParentID</param>
		/// <param name="printNote">printNote</param>
		/// <param name="cuiFeiNote">cuiFeiNote</param>
		/// <param name="defaultOrder">defaultOrder</param>
		/// <param name="printTitle">printTitle</param>
		/// <param name="printFont">printFont</param>
		/// <param name="isPrintNote">isPrintNote</param>
		/// <param name="isPrintCount">isPrintCount</param>
		/// <param name="printWidth">printWidth</param>
		/// <param name="printHeight">printHeight</param>
		/// <param name="printSubTitle">printSubTitle</param>
		/// <param name="isPrintCost">isPrintCost</param>
		/// <param name="isPrintDiscount">isPrintDiscount</param>
		/// <param name="propertyID">propertyID</param>
		/// <param name="logoPath">logoPath</param>
		/// <param name="printCancelNote">printCancelNote</param>
		/// <param name="cuiShouPrintTitle">cuiShouPrintTitle</param>
		/// <param name="cuiShouPrintSubTitle">cuiShouPrintSubTitle</param>
		/// <param name="isPrintRoomNo">isPrintRoomNo</param>
		/// <param name="printType">printType</param>
		/// <param name="isPrintTotalRealCost">isPrintTotalRealCost</param>
		/// <param name="isPrintRealCost">isPrintRealCost</param>
		/// <param name="isDefinePrintSize">isDefinePrintSize</param>
		/// <param name="printTopMargin">printTopMargin</param>
		/// <param name="printBottomMargin">printBottomMargin</param>
		/// <param name="printTotalLines">printTotalLines</param>
		/// <param name="isPrintMonthCount">isPrintMonthCount</param>
		/// <param name="orgnizationID">orgnizationID</param>
		/// <param name="addressProvice">addressProvice</param>
		/// <param name="addressCity">addressCity</param>
		/// <param name="addressDistrict">addressDistrict</param>
		/// <param name="payPrintTitle">payPrintTitle</param>
		/// <param name="payPrintSubTitle">payPrintSubTitle</param>
		/// <param name="addressProvinceID">addressProvinceID</param>
		/// <param name="logoWidth">logoWidth</param>
		/// <param name="logoHeight">logoHeight</param>
		/// <param name="isPrintUnitPrice">isPrintUnitPrice</param>
		/// <param name="printChargeTypeCount">printChargeTypeCount</param>
		/// <param name="helper">helper</param>
		internal static void UpdateProject(int @iD, int @parentID, string @name, string @description, DateTime @addTime, string @addMan, string @typeDesc, string @grade, int @iconID, int @level, bool @isParent, string @pName, int @companyID, int @orderBy, string @fullName, string @oriFullName, string @allParentID, string @printNote, string @cuiFeiNote, string @defaultOrder, string @printTitle, string @printFont, bool @isPrintNote, bool @isPrintCount, decimal @printWidth, decimal @printHeight, string @printSubTitle, bool @isPrintCost, bool @isPrintDiscount, int @propertyID, string @logoPath, string @printCancelNote, string @cuiShouPrintTitle, string @cuiShouPrintSubTitle, bool @isPrintRoomNo, string @printType, bool @isPrintTotalRealCost, bool @isPrintRealCost, bool @isDefinePrintSize, decimal @printTopMargin, decimal @printBottomMargin, int @printTotalLines, bool @isPrintMonthCount, int @orgnizationID, string @addressProvice, string @addressCity, string @addressDistrict, string @payPrintTitle, string @payPrintSubTitle, int @addressProvinceID, int @logoWidth, int @logoHeight, bool @isPrintUnitPrice, int @printChargeTypeCount, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ParentID] int,
	[Name] nvarchar(100),
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[TypeDesc] nvarchar(50),
	[Grade] nvarchar(20),
	[IconID] int,
	[Level] int,
	[isParent] bit,
	[PName] nvarchar(100),
	[CompanyID] int,
	[OrderBy] int,
	[FullName] nvarchar(500),
	[OriFullName] nvarchar(500),
	[AllParentID] nvarchar(500),
	[PrintNote] nvarchar(500),
	[CuiFeiNote] nvarchar(500),
	[DefaultOrder] nvarchar(200),
	[PrintTitle] nvarchar(200),
	[PrintFont] nvarchar(10),
	[IsPrintNote] bit,
	[IsPrintCount] bit,
	[PrintWidth] decimal(18, 2),
	[PrintHeight] decimal(18, 2),
	[PrintSubTitle] nvarchar(200),
	[IsPrintCost] bit,
	[IsPrintDiscount] bit,
	[PropertyID] int,
	[LogoPath] nvarchar(500),
	[PrintCancelNote] nvarchar(500),
	[CuiShouPrintTitle] nvarchar(200),
	[CuiShouPrintSubTitle] nvarchar(200),
	[IsPrintRoomNo] bit,
	[PrintType] nvarchar(100),
	[IsPrintTotalRealCost] bit,
	[IsPrintRealCost] bit,
	[IsDefinePrintSize] bit,
	[PrintTopMargin] decimal(18, 2),
	[PrintBottomMargin] decimal(18, 2),
	[PrintTotalLines] int,
	[IsPrintMonthCount] bit,
	[OrgnizationID] int,
	[AddressProvice] nvarchar(100),
	[AddressCity] nvarchar(100),
	[AddressDistrict] nvarchar(100),
	[PayPrintTitle] nvarchar(500),
	[PayPrintSubTitle] nvarchar(500),
	[AddressProvinceID] int,
	[LogoWidth] int,
	[LogoHeight] int,
	[IsPrintUnitPrice] bit,
	[PrintChargeTypeCount] int
);

UPDATE [dbo].[Project] SET 
	[Project].[ParentID] = @ParentID,
	[Project].[Name] = @Name,
	[Project].[Description] = @Description,
	[Project].[AddTime] = @AddTime,
	[Project].[AddMan] = @AddMan,
	[Project].[TypeDesc] = @TypeDesc,
	[Project].[Grade] = @Grade,
	[Project].[IconID] = @IconID,
	[Project].[Level] = @Level,
	[Project].[isParent] = @isParent,
	[Project].[PName] = @PName,
	[Project].[CompanyID] = @CompanyID,
	[Project].[OrderBy] = @OrderBy,
	[Project].[FullName] = @FullName,
	[Project].[OriFullName] = @OriFullName,
	[Project].[AllParentID] = @AllParentID,
	[Project].[PrintNote] = @PrintNote,
	[Project].[CuiFeiNote] = @CuiFeiNote,
	[Project].[DefaultOrder] = @DefaultOrder,
	[Project].[PrintTitle] = @PrintTitle,
	[Project].[PrintFont] = @PrintFont,
	[Project].[IsPrintNote] = @IsPrintNote,
	[Project].[IsPrintCount] = @IsPrintCount,
	[Project].[PrintWidth] = @PrintWidth,
	[Project].[PrintHeight] = @PrintHeight,
	[Project].[PrintSubTitle] = @PrintSubTitle,
	[Project].[IsPrintCost] = @IsPrintCost,
	[Project].[IsPrintDiscount] = @IsPrintDiscount,
	[Project].[PropertyID] = @PropertyID,
	[Project].[LogoPath] = @LogoPath,
	[Project].[PrintCancelNote] = @PrintCancelNote,
	[Project].[CuiShouPrintTitle] = @CuiShouPrintTitle,
	[Project].[CuiShouPrintSubTitle] = @CuiShouPrintSubTitle,
	[Project].[IsPrintRoomNo] = @IsPrintRoomNo,
	[Project].[PrintType] = @PrintType,
	[Project].[IsPrintTotalRealCost] = @IsPrintTotalRealCost,
	[Project].[IsPrintRealCost] = @IsPrintRealCost,
	[Project].[IsDefinePrintSize] = @IsDefinePrintSize,
	[Project].[PrintTopMargin] = @PrintTopMargin,
	[Project].[PrintBottomMargin] = @PrintBottomMargin,
	[Project].[PrintTotalLines] = @PrintTotalLines,
	[Project].[IsPrintMonthCount] = @IsPrintMonthCount,
	[Project].[OrgnizationID] = @OrgnizationID,
	[Project].[AddressProvice] = @AddressProvice,
	[Project].[AddressCity] = @AddressCity,
	[Project].[AddressDistrict] = @AddressDistrict,
	[Project].[PayPrintTitle] = @PayPrintTitle,
	[Project].[PayPrintSubTitle] = @PayPrintSubTitle,
	[Project].[AddressProvinceID] = @AddressProvinceID,
	[Project].[LogoWidth] = @LogoWidth,
	[Project].[LogoHeight] = @LogoHeight,
	[Project].[IsPrintUnitPrice] = @IsPrintUnitPrice,
	[Project].[PrintChargeTypeCount] = @PrintChargeTypeCount 
output 
	INSERTED.[ID],
	INSERTED.[ParentID],
	INSERTED.[Name],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[TypeDesc],
	INSERTED.[Grade],
	INSERTED.[IconID],
	INSERTED.[Level],
	INSERTED.[isParent],
	INSERTED.[PName],
	INSERTED.[CompanyID],
	INSERTED.[OrderBy],
	INSERTED.[FullName],
	INSERTED.[OriFullName],
	INSERTED.[AllParentID],
	INSERTED.[PrintNote],
	INSERTED.[CuiFeiNote],
	INSERTED.[DefaultOrder],
	INSERTED.[PrintTitle],
	INSERTED.[PrintFont],
	INSERTED.[IsPrintNote],
	INSERTED.[IsPrintCount],
	INSERTED.[PrintWidth],
	INSERTED.[PrintHeight],
	INSERTED.[PrintSubTitle],
	INSERTED.[IsPrintCost],
	INSERTED.[IsPrintDiscount],
	INSERTED.[PropertyID],
	INSERTED.[LogoPath],
	INSERTED.[PrintCancelNote],
	INSERTED.[CuiShouPrintTitle],
	INSERTED.[CuiShouPrintSubTitle],
	INSERTED.[IsPrintRoomNo],
	INSERTED.[PrintType],
	INSERTED.[IsPrintTotalRealCost],
	INSERTED.[IsPrintRealCost],
	INSERTED.[IsDefinePrintSize],
	INSERTED.[PrintTopMargin],
	INSERTED.[PrintBottomMargin],
	INSERTED.[PrintTotalLines],
	INSERTED.[IsPrintMonthCount],
	INSERTED.[OrgnizationID],
	INSERTED.[AddressProvice],
	INSERTED.[AddressCity],
	INSERTED.[AddressDistrict],
	INSERTED.[PayPrintTitle],
	INSERTED.[PayPrintSubTitle],
	INSERTED.[AddressProvinceID],
	INSERTED.[LogoWidth],
	INSERTED.[LogoHeight],
	INSERTED.[IsPrintUnitPrice],
	INSERTED.[PrintChargeTypeCount]
into @table
WHERE 
	[Project].[ID] = @ID

SELECT 
	[ID],
	[ParentID],
	[Name],
	[Description],
	[AddTime],
	[AddMan],
	[TypeDesc],
	[Grade],
	[IconID],
	[Level],
	[isParent],
	[PName],
	[CompanyID],
	[OrderBy],
	[FullName],
	[OriFullName],
	[AllParentID],
	[PrintNote],
	[CuiFeiNote],
	[DefaultOrder],
	[PrintTitle],
	[PrintFont],
	[IsPrintNote],
	[IsPrintCount],
	[PrintWidth],
	[PrintHeight],
	[PrintSubTitle],
	[IsPrintCost],
	[IsPrintDiscount],
	[PropertyID],
	[LogoPath],
	[PrintCancelNote],
	[CuiShouPrintTitle],
	[CuiShouPrintSubTitle],
	[IsPrintRoomNo],
	[PrintType],
	[IsPrintTotalRealCost],
	[IsPrintRealCost],
	[IsDefinePrintSize],
	[PrintTopMargin],
	[PrintBottomMargin],
	[PrintTotalLines],
	[IsPrintMonthCount],
	[OrgnizationID],
	[AddressProvice],
	[AddressCity],
	[AddressDistrict],
	[PayPrintTitle],
	[PayPrintSubTitle],
	[AddressProvinceID],
	[LogoWidth],
	[LogoHeight],
	[IsPrintUnitPrice],
	[PrintChargeTypeCount] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@TypeDesc", EntityBase.GetDatabaseValue(@typeDesc)));
			parameters.Add(new SqlParameter("@Grade", EntityBase.GetDatabaseValue(@grade)));
			parameters.Add(new SqlParameter("@IconID", EntityBase.GetDatabaseValue(@iconID)));
			parameters.Add(new SqlParameter("@Level", EntityBase.GetDatabaseValue(@level)));
			parameters.Add(new SqlParameter("@isParent", @isParent));
			parameters.Add(new SqlParameter("@PName", EntityBase.GetDatabaseValue(@pName)));
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			parameters.Add(new SqlParameter("@OrderBy", EntityBase.GetDatabaseValue(@orderBy)));
			parameters.Add(new SqlParameter("@FullName", EntityBase.GetDatabaseValue(@fullName)));
			parameters.Add(new SqlParameter("@OriFullName", EntityBase.GetDatabaseValue(@oriFullName)));
			parameters.Add(new SqlParameter("@AllParentID", EntityBase.GetDatabaseValue(@allParentID)));
			parameters.Add(new SqlParameter("@PrintNote", EntityBase.GetDatabaseValue(@printNote)));
			parameters.Add(new SqlParameter("@CuiFeiNote", EntityBase.GetDatabaseValue(@cuiFeiNote)));
			parameters.Add(new SqlParameter("@DefaultOrder", EntityBase.GetDatabaseValue(@defaultOrder)));
			parameters.Add(new SqlParameter("@PrintTitle", EntityBase.GetDatabaseValue(@printTitle)));
			parameters.Add(new SqlParameter("@PrintFont", EntityBase.GetDatabaseValue(@printFont)));
			parameters.Add(new SqlParameter("@IsPrintNote", @isPrintNote));
			parameters.Add(new SqlParameter("@IsPrintCount", @isPrintCount));
			parameters.Add(new SqlParameter("@PrintWidth", EntityBase.GetDatabaseValue(@printWidth)));
			parameters.Add(new SqlParameter("@PrintHeight", EntityBase.GetDatabaseValue(@printHeight)));
			parameters.Add(new SqlParameter("@PrintSubTitle", EntityBase.GetDatabaseValue(@printSubTitle)));
			parameters.Add(new SqlParameter("@IsPrintCost", @isPrintCost));
			parameters.Add(new SqlParameter("@IsPrintDiscount", @isPrintDiscount));
			parameters.Add(new SqlParameter("@PropertyID", EntityBase.GetDatabaseValue(@propertyID)));
			parameters.Add(new SqlParameter("@LogoPath", EntityBase.GetDatabaseValue(@logoPath)));
			parameters.Add(new SqlParameter("@PrintCancelNote", EntityBase.GetDatabaseValue(@printCancelNote)));
			parameters.Add(new SqlParameter("@CuiShouPrintTitle", EntityBase.GetDatabaseValue(@cuiShouPrintTitle)));
			parameters.Add(new SqlParameter("@CuiShouPrintSubTitle", EntityBase.GetDatabaseValue(@cuiShouPrintSubTitle)));
			parameters.Add(new SqlParameter("@IsPrintRoomNo", @isPrintRoomNo));
			parameters.Add(new SqlParameter("@PrintType", EntityBase.GetDatabaseValue(@printType)));
			parameters.Add(new SqlParameter("@IsPrintTotalRealCost", @isPrintTotalRealCost));
			parameters.Add(new SqlParameter("@IsPrintRealCost", @isPrintRealCost));
			parameters.Add(new SqlParameter("@IsDefinePrintSize", @isDefinePrintSize));
			parameters.Add(new SqlParameter("@PrintTopMargin", EntityBase.GetDatabaseValue(@printTopMargin)));
			parameters.Add(new SqlParameter("@PrintBottomMargin", EntityBase.GetDatabaseValue(@printBottomMargin)));
			parameters.Add(new SqlParameter("@PrintTotalLines", EntityBase.GetDatabaseValue(@printTotalLines)));
			parameters.Add(new SqlParameter("@IsPrintMonthCount", @isPrintMonthCount));
			parameters.Add(new SqlParameter("@OrgnizationID", EntityBase.GetDatabaseValue(@orgnizationID)));
			parameters.Add(new SqlParameter("@AddressProvice", EntityBase.GetDatabaseValue(@addressProvice)));
			parameters.Add(new SqlParameter("@AddressCity", EntityBase.GetDatabaseValue(@addressCity)));
			parameters.Add(new SqlParameter("@AddressDistrict", EntityBase.GetDatabaseValue(@addressDistrict)));
			parameters.Add(new SqlParameter("@PayPrintTitle", EntityBase.GetDatabaseValue(@payPrintTitle)));
			parameters.Add(new SqlParameter("@PayPrintSubTitle", EntityBase.GetDatabaseValue(@payPrintSubTitle)));
			parameters.Add(new SqlParameter("@AddressProvinceID", EntityBase.GetDatabaseValue(@addressProvinceID)));
			parameters.Add(new SqlParameter("@LogoWidth", EntityBase.GetDatabaseValue(@logoWidth)));
			parameters.Add(new SqlParameter("@LogoHeight", EntityBase.GetDatabaseValue(@logoHeight)));
			parameters.Add(new SqlParameter("@IsPrintUnitPrice", @isPrintUnitPrice));
			parameters.Add(new SqlParameter("@PrintChargeTypeCount", EntityBase.GetDatabaseValue(@printChargeTypeCount)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Project from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteProject(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteProject(@iD, helper);
					helper.Commit();
				} 
				catch 
				{
					helper.Rollback();
					throw;
				}
			}
		}
		
		/// <summary>
		/// Deletes a Project from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteProject(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Project]
WHERE 
	[Project].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Project object.
		/// </summary>
		/// <returns>The newly created Project object.</returns>
		public static Project CreateProject()
		{
			return InitializeNew<Project>();
		}
		
		/// <summary>
		/// Retrieve information for a Project by a Project's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Project</returns>
		public static Project GetProject(int @iD)
		{
			string commandText = @"
SELECT 
" + Project.SelectFieldList + @"
FROM [dbo].[Project] 
WHERE 
	[Project].[ID] = @ID " + Project.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Project>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Project by a Project's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Project</returns>
		public static Project GetProject(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Project.SelectFieldList + @"
FROM [dbo].[Project] 
WHERE 
	[Project].[ID] = @ID " + Project.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Project>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Project objects.
		/// </summary>
		/// <returns>The retrieved collection of Project objects.</returns>
		public static EntityList<Project> GetProjects()
		{
			string commandText = @"
SELECT " + Project.SelectFieldList + "FROM [dbo].[Project] " + Project.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Project>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Project objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Project objects.</returns>
        public static EntityList<Project> GetProjects(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Project>(SelectFieldList, "FROM [dbo].[Project]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Project objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Project objects.</returns>
        public static EntityList<Project> GetProjects(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Project>(SelectFieldList, "FROM [dbo].[Project]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Project objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Project objects.</returns>
		protected static EntityList<Project> GetProjects(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjects(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Project objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Project objects.</returns>
		protected static EntityList<Project> GetProjects(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjects(string.Empty, where, parameters, Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Project objects.</returns>
		protected static EntityList<Project> GetProjects(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjects(prefix, where, parameters, Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Project objects.</returns>
		protected static EntityList<Project> GetProjects(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjects(string.Empty, where, parameters, Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Project objects.</returns>
		protected static EntityList<Project> GetProjects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjects(prefix, where, parameters, Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Project objects.</returns>
		protected static EntityList<Project> GetProjects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Project.SelectFieldList + "FROM [dbo].[Project] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Project>(reader);
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
        protected static EntityList<Project> GetProjects(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Project>(SelectFieldList, "FROM [dbo].[Project] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Project objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetProjectCount()
        {
            return GetProjectCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Project objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetProjectCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Project] " + where;

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
		#endregion
		
		#region Subclasses
		public static partial class Project_Properties
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
			public const string PropertyID = "PropertyID";
			public const string LogoPath = "LogoPath";
			public const string PrintCancelNote = "PrintCancelNote";
			public const string CuiShouPrintTitle = "CuiShouPrintTitle";
			public const string CuiShouPrintSubTitle = "CuiShouPrintSubTitle";
			public const string IsPrintRoomNo = "IsPrintRoomNo";
			public const string PrintType = "PrintType";
			public const string IsPrintTotalRealCost = "IsPrintTotalRealCost";
			public const string IsPrintRealCost = "IsPrintRealCost";
			public const string IsDefinePrintSize = "IsDefinePrintSize";
			public const string PrintTopMargin = "PrintTopMargin";
			public const string PrintBottomMargin = "PrintBottomMargin";
			public const string PrintTotalLines = "PrintTotalLines";
			public const string IsPrintMonthCount = "IsPrintMonthCount";
			public const string OrgnizationID = "OrgnizationID";
			public const string AddressProvice = "AddressProvice";
			public const string AddressCity = "AddressCity";
			public const string AddressDistrict = "AddressDistrict";
			public const string PayPrintTitle = "PayPrintTitle";
			public const string PayPrintSubTitle = "PayPrintSubTitle";
			public const string AddressProvinceID = "AddressProvinceID";
			public const string LogoWidth = "LogoWidth";
			public const string LogoHeight = "LogoHeight";
			public const string IsPrintUnitPrice = "IsPrintUnitPrice";
			public const string PrintChargeTypeCount = "PrintChargeTypeCount";
            
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
    			 {"PropertyID" , "int:"},
    			 {"LogoPath" , "string:"},
    			 {"PrintCancelNote" , "string:"},
    			 {"CuiShouPrintTitle" , "string:"},
    			 {"CuiShouPrintSubTitle" , "string:"},
    			 {"IsPrintRoomNo" , "bool:"},
    			 {"PrintType" , "string:"},
    			 {"IsPrintTotalRealCost" , "bool:"},
    			 {"IsPrintRealCost" , "bool:"},
    			 {"IsDefinePrintSize" , "bool:"},
    			 {"PrintTopMargin" , "decimal:"},
    			 {"PrintBottomMargin" , "decimal:"},
    			 {"PrintTotalLines" , "int:"},
    			 {"IsPrintMonthCount" , "bool:"},
    			 {"OrgnizationID" , "int:"},
    			 {"AddressProvice" , "string:"},
    			 {"AddressCity" , "string:"},
    			 {"AddressDistrict" , "string:"},
    			 {"PayPrintTitle" , "string:"},
    			 {"PayPrintSubTitle" , "string:"},
    			 {"AddressProvinceID" , "int:"},
    			 {"LogoWidth" , "int:"},
    			 {"LogoHeight" , "int:"},
    			 {"IsPrintUnitPrice" , "bool:"},
    			 {"PrintChargeTypeCount" , "int:"},
            };
		}
		#endregion
	}
}
