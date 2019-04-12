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
	/// This object represents the properties and methods of a CKPropertyTemp.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("TempID: {TempID}")]
	public partial class CKPropertyTemp 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _tempID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, true, false)]
		public int TempID
		{
			[DebuggerStepThrough()]
			get { return this._tempID; }
			 set 
			{
				if (this._tempID != value) 
				{
					this._tempID = value;
					this.IsDirty = true;	
					OnPropertyChanged("TempID");
				}
			}
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
		private string _propertyName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string PropertyName
		{
			[DebuggerStepThrough()]
			get { return this._propertyName; }
			set 
			{
				if (this._propertyName != value) 
				{
					this._propertyName = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _propertyCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PropertyCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._propertyCategoryID; }
			set 
			{
				if (this._propertyCategoryID != value) 
				{
					this._propertyCategoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyCategoryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _propertyNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string PropertyNo
		{
			[DebuggerStepThrough()]
			get { return this._propertyNo; }
			set 
			{
				if (this._propertyNo != value) 
				{
					this._propertyNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyNo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _propertyModelNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PropertyModelNo
		{
			[DebuggerStepThrough()]
			get { return this._propertyModelNo; }
			set 
			{
				if (this._propertyModelNo != value) 
				{
					this._propertyModelNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyModelNo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _propertyUnit = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PropertyUnit
		{
			[DebuggerStepThrough()]
			get { return this._propertyUnit; }
			set 
			{
				if (this._propertyUnit != value) 
				{
					this._propertyUnit = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyUnit");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _propertyCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PropertyCount
		{
			[DebuggerStepThrough()]
			get { return this._propertyCount; }
			set 
			{
				if (this._propertyCount != value) 
				{
					this._propertyCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _propertyUnitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal PropertyUnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._propertyUnitPrice; }
			set 
			{
				if (this._propertyUnitPrice != value) 
				{
					this._propertyUnitPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyUnitPrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _propertyCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal PropertyCost
		{
			[DebuggerStepThrough()]
			get { return this._propertyCost; }
			set 
			{
				if (this._propertyCost != value) 
				{
					this._propertyCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _propertyPurchaseDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime PropertyPurchaseDate
		{
			[DebuggerStepThrough()]
			get { return this._propertyPurchaseDate; }
			set 
			{
				if (this._propertyPurchaseDate != value) 
				{
					this._propertyPurchaseDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyPurchaseDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _propertyUseYear = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal PropertyUseYear
		{
			[DebuggerStepThrough()]
			get { return this._propertyUseYear; }
			set 
			{
				if (this._propertyUseYear != value) 
				{
					this._propertyUseYear = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyUseYear");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _propertyRealCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal PropertyRealCost
		{
			[DebuggerStepThrough()]
			get { return this._propertyRealCost; }
			set 
			{
				if (this._propertyRealCost != value) 
				{
					this._propertyRealCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyRealCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _propertyChangeType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PropertyChangeType
		{
			[DebuggerStepThrough()]
			get { return this._propertyChangeType; }
			set 
			{
				if (this._propertyChangeType != value) 
				{
					this._propertyChangeType = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyChangeType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _propertyState = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PropertyState
		{
			[DebuggerStepThrough()]
			get { return this._propertyState; }
			set 
			{
				if (this._propertyState != value) 
				{
					this._propertyState = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyState");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _propertyDepartmentID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PropertyDepartmentID
		{
			[DebuggerStepThrough()]
			get { return this._propertyDepartmentID; }
			set 
			{
				if (this._propertyDepartmentID != value) 
				{
					this._propertyDepartmentID = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyDepartmentID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _propertyLocation = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PropertyLocation
		{
			[DebuggerStepThrough()]
			get { return this._propertyLocation; }
			set 
			{
				if (this._propertyLocation != value) 
				{
					this._propertyLocation = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyLocation");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _propertyUseMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PropertyUseMan
		{
			[DebuggerStepThrough()]
			get { return this._propertyUseMan; }
			set 
			{
				if (this._propertyUseMan != value) 
				{
					this._propertyUseMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyUseMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _propertyContractName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PropertyContractName
		{
			[DebuggerStepThrough()]
			get { return this._propertyContractName; }
			set 
			{
				if (this._propertyContractName != value) 
				{
					this._propertyContractName = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyContractName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _propertyContactPhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PropertyContactPhone
		{
			[DebuggerStepThrough()]
			get { return this._propertyContactPhone; }
			set 
			{
				if (this._propertyContactPhone != value) 
				{
					this._propertyContactPhone = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyContactPhone");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _propertyRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PropertyRemark
		{
			[DebuggerStepThrough()]
			get { return this._propertyRemark; }
			set 
			{
				if (this._propertyRemark != value) 
				{
					this._propertyRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyRemark");
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
		private decimal _propertyDiscountCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal PropertyDiscountCost
		{
			[DebuggerStepThrough()]
			get { return this._propertyDiscountCost; }
			set 
			{
				if (this._propertyDiscountCost != value) 
				{
					this._propertyDiscountCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyDiscountCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _updateMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string UpdateMan
		{
			[DebuggerStepThrough()]
			get { return this._updateMan; }
			set 
			{
				if (this._updateMan != value) 
				{
					this._updateMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("UpdateMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _updateTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime UpdateTime
		{
			[DebuggerStepThrough()]
			get { return this._updateTime; }
			set 
			{
				if (this._updateTime != value) 
				{
					this._updateTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("UpdateTime");
				}
			}
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
			set 
			{
				if (this._modifyTime != value) 
				{
					this._modifyTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModifyTime");
				}
			}
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
			set 
			{
				if (this._modifyMan != value) 
				{
					this._modifyMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModifyMan");
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
	[TempID] int,
	[ID] int,
	[PropertyName] nvarchar(200),
	[PropertyCategoryID] int,
	[PropertyNo] nvarchar(200),
	[PropertyModelNo] nvarchar(200),
	[PropertyUnit] nvarchar(50),
	[PropertyCount] int,
	[PropertyUnitPrice] decimal(18, 2),
	[PropertyCost] decimal(18, 2),
	[PropertyPurchaseDate] datetime,
	[PropertyUseYear] decimal(18, 2),
	[PropertyRealCost] decimal(18, 2),
	[PropertyChangeType] nvarchar(50),
	[PropertyState] int,
	[PropertyDepartmentID] int,
	[PropertyLocation] nvarchar(500),
	[PropertyUseMan] nvarchar(100),
	[PropertyContractName] nvarchar(200),
	[PropertyContactPhone] nvarchar(100),
	[PropertyRemark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime,
	[PropertyDiscountCost] decimal(18, 2),
	[UpdateMan] nvarchar(50),
	[UpdateTime] datetime,
	[ModifyTime] datetime,
	[ModifyMan] nvarchar(50)
);

INSERT INTO [dbo].[CKPropertyTemp] (
	[CKPropertyTemp].[ID],
	[CKPropertyTemp].[PropertyName],
	[CKPropertyTemp].[PropertyCategoryID],
	[CKPropertyTemp].[PropertyNo],
	[CKPropertyTemp].[PropertyModelNo],
	[CKPropertyTemp].[PropertyUnit],
	[CKPropertyTemp].[PropertyCount],
	[CKPropertyTemp].[PropertyUnitPrice],
	[CKPropertyTemp].[PropertyCost],
	[CKPropertyTemp].[PropertyPurchaseDate],
	[CKPropertyTemp].[PropertyUseYear],
	[CKPropertyTemp].[PropertyRealCost],
	[CKPropertyTemp].[PropertyChangeType],
	[CKPropertyTemp].[PropertyState],
	[CKPropertyTemp].[PropertyDepartmentID],
	[CKPropertyTemp].[PropertyLocation],
	[CKPropertyTemp].[PropertyUseMan],
	[CKPropertyTemp].[PropertyContractName],
	[CKPropertyTemp].[PropertyContactPhone],
	[CKPropertyTemp].[PropertyRemark],
	[CKPropertyTemp].[AddMan],
	[CKPropertyTemp].[AddTime],
	[CKPropertyTemp].[PropertyDiscountCost],
	[CKPropertyTemp].[UpdateMan],
	[CKPropertyTemp].[UpdateTime],
	[CKPropertyTemp].[ModifyTime],
	[CKPropertyTemp].[ModifyMan]
) 
output 
	INSERTED.[TempID],
	INSERTED.[ID],
	INSERTED.[PropertyName],
	INSERTED.[PropertyCategoryID],
	INSERTED.[PropertyNo],
	INSERTED.[PropertyModelNo],
	INSERTED.[PropertyUnit],
	INSERTED.[PropertyCount],
	INSERTED.[PropertyUnitPrice],
	INSERTED.[PropertyCost],
	INSERTED.[PropertyPurchaseDate],
	INSERTED.[PropertyUseYear],
	INSERTED.[PropertyRealCost],
	INSERTED.[PropertyChangeType],
	INSERTED.[PropertyState],
	INSERTED.[PropertyDepartmentID],
	INSERTED.[PropertyLocation],
	INSERTED.[PropertyUseMan],
	INSERTED.[PropertyContractName],
	INSERTED.[PropertyContactPhone],
	INSERTED.[PropertyRemark],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[PropertyDiscountCost],
	INSERTED.[UpdateMan],
	INSERTED.[UpdateTime],
	INSERTED.[ModifyTime],
	INSERTED.[ModifyMan]
into @table
VALUES ( 
	@ID,
	@PropertyName,
	@PropertyCategoryID,
	@PropertyNo,
	@PropertyModelNo,
	@PropertyUnit,
	@PropertyCount,
	@PropertyUnitPrice,
	@PropertyCost,
	@PropertyPurchaseDate,
	@PropertyUseYear,
	@PropertyRealCost,
	@PropertyChangeType,
	@PropertyState,
	@PropertyDepartmentID,
	@PropertyLocation,
	@PropertyUseMan,
	@PropertyContractName,
	@PropertyContactPhone,
	@PropertyRemark,
	@AddMan,
	@AddTime,
	@PropertyDiscountCost,
	@UpdateMan,
	@UpdateTime,
	@ModifyTime,
	@ModifyMan 
); 

SELECT 
	[TempID],
	[ID],
	[PropertyName],
	[PropertyCategoryID],
	[PropertyNo],
	[PropertyModelNo],
	[PropertyUnit],
	[PropertyCount],
	[PropertyUnitPrice],
	[PropertyCost],
	[PropertyPurchaseDate],
	[PropertyUseYear],
	[PropertyRealCost],
	[PropertyChangeType],
	[PropertyState],
	[PropertyDepartmentID],
	[PropertyLocation],
	[PropertyUseMan],
	[PropertyContractName],
	[PropertyContactPhone],
	[PropertyRemark],
	[AddMan],
	[AddTime],
	[PropertyDiscountCost],
	[UpdateMan],
	[UpdateTime],
	[ModifyTime],
	[ModifyMan] 
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
	[TempID] int,
	[ID] int,
	[PropertyName] nvarchar(200),
	[PropertyCategoryID] int,
	[PropertyNo] nvarchar(200),
	[PropertyModelNo] nvarchar(200),
	[PropertyUnit] nvarchar(50),
	[PropertyCount] int,
	[PropertyUnitPrice] decimal(18, 2),
	[PropertyCost] decimal(18, 2),
	[PropertyPurchaseDate] datetime,
	[PropertyUseYear] decimal(18, 2),
	[PropertyRealCost] decimal(18, 2),
	[PropertyChangeType] nvarchar(50),
	[PropertyState] int,
	[PropertyDepartmentID] int,
	[PropertyLocation] nvarchar(500),
	[PropertyUseMan] nvarchar(100),
	[PropertyContractName] nvarchar(200),
	[PropertyContactPhone] nvarchar(100),
	[PropertyRemark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime,
	[PropertyDiscountCost] decimal(18, 2),
	[UpdateMan] nvarchar(50),
	[UpdateTime] datetime,
	[ModifyTime] datetime,
	[ModifyMan] nvarchar(50)
);

UPDATE [dbo].[CKPropertyTemp] SET 
	[CKPropertyTemp].[ID] = @ID,
	[CKPropertyTemp].[PropertyName] = @PropertyName,
	[CKPropertyTemp].[PropertyCategoryID] = @PropertyCategoryID,
	[CKPropertyTemp].[PropertyNo] = @PropertyNo,
	[CKPropertyTemp].[PropertyModelNo] = @PropertyModelNo,
	[CKPropertyTemp].[PropertyUnit] = @PropertyUnit,
	[CKPropertyTemp].[PropertyCount] = @PropertyCount,
	[CKPropertyTemp].[PropertyUnitPrice] = @PropertyUnitPrice,
	[CKPropertyTemp].[PropertyCost] = @PropertyCost,
	[CKPropertyTemp].[PropertyPurchaseDate] = @PropertyPurchaseDate,
	[CKPropertyTemp].[PropertyUseYear] = @PropertyUseYear,
	[CKPropertyTemp].[PropertyRealCost] = @PropertyRealCost,
	[CKPropertyTemp].[PropertyChangeType] = @PropertyChangeType,
	[CKPropertyTemp].[PropertyState] = @PropertyState,
	[CKPropertyTemp].[PropertyDepartmentID] = @PropertyDepartmentID,
	[CKPropertyTemp].[PropertyLocation] = @PropertyLocation,
	[CKPropertyTemp].[PropertyUseMan] = @PropertyUseMan,
	[CKPropertyTemp].[PropertyContractName] = @PropertyContractName,
	[CKPropertyTemp].[PropertyContactPhone] = @PropertyContactPhone,
	[CKPropertyTemp].[PropertyRemark] = @PropertyRemark,
	[CKPropertyTemp].[AddMan] = @AddMan,
	[CKPropertyTemp].[AddTime] = @AddTime,
	[CKPropertyTemp].[PropertyDiscountCost] = @PropertyDiscountCost,
	[CKPropertyTemp].[UpdateMan] = @UpdateMan,
	[CKPropertyTemp].[UpdateTime] = @UpdateTime,
	[CKPropertyTemp].[ModifyTime] = @ModifyTime,
	[CKPropertyTemp].[ModifyMan] = @ModifyMan 
output 
	INSERTED.[TempID],
	INSERTED.[ID],
	INSERTED.[PropertyName],
	INSERTED.[PropertyCategoryID],
	INSERTED.[PropertyNo],
	INSERTED.[PropertyModelNo],
	INSERTED.[PropertyUnit],
	INSERTED.[PropertyCount],
	INSERTED.[PropertyUnitPrice],
	INSERTED.[PropertyCost],
	INSERTED.[PropertyPurchaseDate],
	INSERTED.[PropertyUseYear],
	INSERTED.[PropertyRealCost],
	INSERTED.[PropertyChangeType],
	INSERTED.[PropertyState],
	INSERTED.[PropertyDepartmentID],
	INSERTED.[PropertyLocation],
	INSERTED.[PropertyUseMan],
	INSERTED.[PropertyContractName],
	INSERTED.[PropertyContactPhone],
	INSERTED.[PropertyRemark],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[PropertyDiscountCost],
	INSERTED.[UpdateMan],
	INSERTED.[UpdateTime],
	INSERTED.[ModifyTime],
	INSERTED.[ModifyMan]
into @table
WHERE 
	[CKPropertyTemp].[TempID] = @TempID

SELECT 
	[TempID],
	[ID],
	[PropertyName],
	[PropertyCategoryID],
	[PropertyNo],
	[PropertyModelNo],
	[PropertyUnit],
	[PropertyCount],
	[PropertyUnitPrice],
	[PropertyCost],
	[PropertyPurchaseDate],
	[PropertyUseYear],
	[PropertyRealCost],
	[PropertyChangeType],
	[PropertyState],
	[PropertyDepartmentID],
	[PropertyLocation],
	[PropertyUseMan],
	[PropertyContractName],
	[PropertyContactPhone],
	[PropertyRemark],
	[AddMan],
	[AddTime],
	[PropertyDiscountCost],
	[UpdateMan],
	[UpdateTime],
	[ModifyTime],
	[ModifyMan] 
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
DELETE FROM [dbo].[CKPropertyTemp]
WHERE 
	[CKPropertyTemp].[TempID] = @TempID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CKPropertyTemp() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCKPropertyTemp(this.TempID));
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
	[CKPropertyTemp].[TempID],
	[CKPropertyTemp].[ID],
	[CKPropertyTemp].[PropertyName],
	[CKPropertyTemp].[PropertyCategoryID],
	[CKPropertyTemp].[PropertyNo],
	[CKPropertyTemp].[PropertyModelNo],
	[CKPropertyTemp].[PropertyUnit],
	[CKPropertyTemp].[PropertyCount],
	[CKPropertyTemp].[PropertyUnitPrice],
	[CKPropertyTemp].[PropertyCost],
	[CKPropertyTemp].[PropertyPurchaseDate],
	[CKPropertyTemp].[PropertyUseYear],
	[CKPropertyTemp].[PropertyRealCost],
	[CKPropertyTemp].[PropertyChangeType],
	[CKPropertyTemp].[PropertyState],
	[CKPropertyTemp].[PropertyDepartmentID],
	[CKPropertyTemp].[PropertyLocation],
	[CKPropertyTemp].[PropertyUseMan],
	[CKPropertyTemp].[PropertyContractName],
	[CKPropertyTemp].[PropertyContactPhone],
	[CKPropertyTemp].[PropertyRemark],
	[CKPropertyTemp].[AddMan],
	[CKPropertyTemp].[AddTime],
	[CKPropertyTemp].[PropertyDiscountCost],
	[CKPropertyTemp].[UpdateMan],
	[CKPropertyTemp].[UpdateTime],
	[CKPropertyTemp].[ModifyTime],
	[CKPropertyTemp].[ModifyMan]
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
                return "CKPropertyTemp";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CKPropertyTemp into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="propertyName">propertyName</param>
		/// <param name="propertyCategoryID">propertyCategoryID</param>
		/// <param name="propertyNo">propertyNo</param>
		/// <param name="propertyModelNo">propertyModelNo</param>
		/// <param name="propertyUnit">propertyUnit</param>
		/// <param name="propertyCount">propertyCount</param>
		/// <param name="propertyUnitPrice">propertyUnitPrice</param>
		/// <param name="propertyCost">propertyCost</param>
		/// <param name="propertyPurchaseDate">propertyPurchaseDate</param>
		/// <param name="propertyUseYear">propertyUseYear</param>
		/// <param name="propertyRealCost">propertyRealCost</param>
		/// <param name="propertyChangeType">propertyChangeType</param>
		/// <param name="propertyState">propertyState</param>
		/// <param name="propertyDepartmentID">propertyDepartmentID</param>
		/// <param name="propertyLocation">propertyLocation</param>
		/// <param name="propertyUseMan">propertyUseMan</param>
		/// <param name="propertyContractName">propertyContractName</param>
		/// <param name="propertyContactPhone">propertyContactPhone</param>
		/// <param name="propertyRemark">propertyRemark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="propertyDiscountCost">propertyDiscountCost</param>
		/// <param name="updateMan">updateMan</param>
		/// <param name="updateTime">updateTime</param>
		/// <param name="modifyTime">modifyTime</param>
		/// <param name="modifyMan">modifyMan</param>
		public static void InsertCKPropertyTemp(int @iD, string @propertyName, int @propertyCategoryID, string @propertyNo, string @propertyModelNo, string @propertyUnit, int @propertyCount, decimal @propertyUnitPrice, decimal @propertyCost, DateTime @propertyPurchaseDate, decimal @propertyUseYear, decimal @propertyRealCost, string @propertyChangeType, int @propertyState, int @propertyDepartmentID, string @propertyLocation, string @propertyUseMan, string @propertyContractName, string @propertyContactPhone, string @propertyRemark, string @addMan, DateTime @addTime, decimal @propertyDiscountCost, string @updateMan, DateTime @updateTime, DateTime @modifyTime, string @modifyMan)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCKPropertyTemp(@iD, @propertyName, @propertyCategoryID, @propertyNo, @propertyModelNo, @propertyUnit, @propertyCount, @propertyUnitPrice, @propertyCost, @propertyPurchaseDate, @propertyUseYear, @propertyRealCost, @propertyChangeType, @propertyState, @propertyDepartmentID, @propertyLocation, @propertyUseMan, @propertyContractName, @propertyContactPhone, @propertyRemark, @addMan, @addTime, @propertyDiscountCost, @updateMan, @updateTime, @modifyTime, @modifyMan, helper);
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
		/// Insert a CKPropertyTemp into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="propertyName">propertyName</param>
		/// <param name="propertyCategoryID">propertyCategoryID</param>
		/// <param name="propertyNo">propertyNo</param>
		/// <param name="propertyModelNo">propertyModelNo</param>
		/// <param name="propertyUnit">propertyUnit</param>
		/// <param name="propertyCount">propertyCount</param>
		/// <param name="propertyUnitPrice">propertyUnitPrice</param>
		/// <param name="propertyCost">propertyCost</param>
		/// <param name="propertyPurchaseDate">propertyPurchaseDate</param>
		/// <param name="propertyUseYear">propertyUseYear</param>
		/// <param name="propertyRealCost">propertyRealCost</param>
		/// <param name="propertyChangeType">propertyChangeType</param>
		/// <param name="propertyState">propertyState</param>
		/// <param name="propertyDepartmentID">propertyDepartmentID</param>
		/// <param name="propertyLocation">propertyLocation</param>
		/// <param name="propertyUseMan">propertyUseMan</param>
		/// <param name="propertyContractName">propertyContractName</param>
		/// <param name="propertyContactPhone">propertyContactPhone</param>
		/// <param name="propertyRemark">propertyRemark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="propertyDiscountCost">propertyDiscountCost</param>
		/// <param name="updateMan">updateMan</param>
		/// <param name="updateTime">updateTime</param>
		/// <param name="modifyTime">modifyTime</param>
		/// <param name="modifyMan">modifyMan</param>
		/// <param name="helper">helper</param>
		internal static void InsertCKPropertyTemp(int @iD, string @propertyName, int @propertyCategoryID, string @propertyNo, string @propertyModelNo, string @propertyUnit, int @propertyCount, decimal @propertyUnitPrice, decimal @propertyCost, DateTime @propertyPurchaseDate, decimal @propertyUseYear, decimal @propertyRealCost, string @propertyChangeType, int @propertyState, int @propertyDepartmentID, string @propertyLocation, string @propertyUseMan, string @propertyContractName, string @propertyContactPhone, string @propertyRemark, string @addMan, DateTime @addTime, decimal @propertyDiscountCost, string @updateMan, DateTime @updateTime, DateTime @modifyTime, string @modifyMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[TempID] int,
	[ID] int,
	[PropertyName] nvarchar(200),
	[PropertyCategoryID] int,
	[PropertyNo] nvarchar(200),
	[PropertyModelNo] nvarchar(200),
	[PropertyUnit] nvarchar(50),
	[PropertyCount] int,
	[PropertyUnitPrice] decimal(18, 2),
	[PropertyCost] decimal(18, 2),
	[PropertyPurchaseDate] datetime,
	[PropertyUseYear] decimal(18, 2),
	[PropertyRealCost] decimal(18, 2),
	[PropertyChangeType] nvarchar(50),
	[PropertyState] int,
	[PropertyDepartmentID] int,
	[PropertyLocation] nvarchar(500),
	[PropertyUseMan] nvarchar(100),
	[PropertyContractName] nvarchar(200),
	[PropertyContactPhone] nvarchar(100),
	[PropertyRemark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime,
	[PropertyDiscountCost] decimal(18, 2),
	[UpdateMan] nvarchar(50),
	[UpdateTime] datetime,
	[ModifyTime] datetime,
	[ModifyMan] nvarchar(50)
);

INSERT INTO [dbo].[CKPropertyTemp] (
	[CKPropertyTemp].[ID],
	[CKPropertyTemp].[PropertyName],
	[CKPropertyTemp].[PropertyCategoryID],
	[CKPropertyTemp].[PropertyNo],
	[CKPropertyTemp].[PropertyModelNo],
	[CKPropertyTemp].[PropertyUnit],
	[CKPropertyTemp].[PropertyCount],
	[CKPropertyTemp].[PropertyUnitPrice],
	[CKPropertyTemp].[PropertyCost],
	[CKPropertyTemp].[PropertyPurchaseDate],
	[CKPropertyTemp].[PropertyUseYear],
	[CKPropertyTemp].[PropertyRealCost],
	[CKPropertyTemp].[PropertyChangeType],
	[CKPropertyTemp].[PropertyState],
	[CKPropertyTemp].[PropertyDepartmentID],
	[CKPropertyTemp].[PropertyLocation],
	[CKPropertyTemp].[PropertyUseMan],
	[CKPropertyTemp].[PropertyContractName],
	[CKPropertyTemp].[PropertyContactPhone],
	[CKPropertyTemp].[PropertyRemark],
	[CKPropertyTemp].[AddMan],
	[CKPropertyTemp].[AddTime],
	[CKPropertyTemp].[PropertyDiscountCost],
	[CKPropertyTemp].[UpdateMan],
	[CKPropertyTemp].[UpdateTime],
	[CKPropertyTemp].[ModifyTime],
	[CKPropertyTemp].[ModifyMan]
) 
output 
	INSERTED.[TempID],
	INSERTED.[ID],
	INSERTED.[PropertyName],
	INSERTED.[PropertyCategoryID],
	INSERTED.[PropertyNo],
	INSERTED.[PropertyModelNo],
	INSERTED.[PropertyUnit],
	INSERTED.[PropertyCount],
	INSERTED.[PropertyUnitPrice],
	INSERTED.[PropertyCost],
	INSERTED.[PropertyPurchaseDate],
	INSERTED.[PropertyUseYear],
	INSERTED.[PropertyRealCost],
	INSERTED.[PropertyChangeType],
	INSERTED.[PropertyState],
	INSERTED.[PropertyDepartmentID],
	INSERTED.[PropertyLocation],
	INSERTED.[PropertyUseMan],
	INSERTED.[PropertyContractName],
	INSERTED.[PropertyContactPhone],
	INSERTED.[PropertyRemark],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[PropertyDiscountCost],
	INSERTED.[UpdateMan],
	INSERTED.[UpdateTime],
	INSERTED.[ModifyTime],
	INSERTED.[ModifyMan]
into @table
VALUES ( 
	@ID,
	@PropertyName,
	@PropertyCategoryID,
	@PropertyNo,
	@PropertyModelNo,
	@PropertyUnit,
	@PropertyCount,
	@PropertyUnitPrice,
	@PropertyCost,
	@PropertyPurchaseDate,
	@PropertyUseYear,
	@PropertyRealCost,
	@PropertyChangeType,
	@PropertyState,
	@PropertyDepartmentID,
	@PropertyLocation,
	@PropertyUseMan,
	@PropertyContractName,
	@PropertyContactPhone,
	@PropertyRemark,
	@AddMan,
	@AddTime,
	@PropertyDiscountCost,
	@UpdateMan,
	@UpdateTime,
	@ModifyTime,
	@ModifyMan 
); 

SELECT 
	[TempID],
	[ID],
	[PropertyName],
	[PropertyCategoryID],
	[PropertyNo],
	[PropertyModelNo],
	[PropertyUnit],
	[PropertyCount],
	[PropertyUnitPrice],
	[PropertyCost],
	[PropertyPurchaseDate],
	[PropertyUseYear],
	[PropertyRealCost],
	[PropertyChangeType],
	[PropertyState],
	[PropertyDepartmentID],
	[PropertyLocation],
	[PropertyUseMan],
	[PropertyContractName],
	[PropertyContactPhone],
	[PropertyRemark],
	[AddMan],
	[AddTime],
	[PropertyDiscountCost],
	[UpdateMan],
	[UpdateTime],
	[ModifyTime],
	[ModifyMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@PropertyName", EntityBase.GetDatabaseValue(@propertyName)));
			parameters.Add(new SqlParameter("@PropertyCategoryID", EntityBase.GetDatabaseValue(@propertyCategoryID)));
			parameters.Add(new SqlParameter("@PropertyNo", EntityBase.GetDatabaseValue(@propertyNo)));
			parameters.Add(new SqlParameter("@PropertyModelNo", EntityBase.GetDatabaseValue(@propertyModelNo)));
			parameters.Add(new SqlParameter("@PropertyUnit", EntityBase.GetDatabaseValue(@propertyUnit)));
			parameters.Add(new SqlParameter("@PropertyCount", EntityBase.GetDatabaseValue(@propertyCount)));
			parameters.Add(new SqlParameter("@PropertyUnitPrice", EntityBase.GetDatabaseValue(@propertyUnitPrice)));
			parameters.Add(new SqlParameter("@PropertyCost", EntityBase.GetDatabaseValue(@propertyCost)));
			parameters.Add(new SqlParameter("@PropertyPurchaseDate", EntityBase.GetDatabaseValue(@propertyPurchaseDate)));
			parameters.Add(new SqlParameter("@PropertyUseYear", EntityBase.GetDatabaseValue(@propertyUseYear)));
			parameters.Add(new SqlParameter("@PropertyRealCost", EntityBase.GetDatabaseValue(@propertyRealCost)));
			parameters.Add(new SqlParameter("@PropertyChangeType", EntityBase.GetDatabaseValue(@propertyChangeType)));
			parameters.Add(new SqlParameter("@PropertyState", EntityBase.GetDatabaseValue(@propertyState)));
			parameters.Add(new SqlParameter("@PropertyDepartmentID", EntityBase.GetDatabaseValue(@propertyDepartmentID)));
			parameters.Add(new SqlParameter("@PropertyLocation", EntityBase.GetDatabaseValue(@propertyLocation)));
			parameters.Add(new SqlParameter("@PropertyUseMan", EntityBase.GetDatabaseValue(@propertyUseMan)));
			parameters.Add(new SqlParameter("@PropertyContractName", EntityBase.GetDatabaseValue(@propertyContractName)));
			parameters.Add(new SqlParameter("@PropertyContactPhone", EntityBase.GetDatabaseValue(@propertyContactPhone)));
			parameters.Add(new SqlParameter("@PropertyRemark", EntityBase.GetDatabaseValue(@propertyRemark)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@PropertyDiscountCost", EntityBase.GetDatabaseValue(@propertyDiscountCost)));
			parameters.Add(new SqlParameter("@UpdateMan", EntityBase.GetDatabaseValue(@updateMan)));
			parameters.Add(new SqlParameter("@UpdateTime", EntityBase.GetDatabaseValue(@updateTime)));
			parameters.Add(new SqlParameter("@ModifyTime", EntityBase.GetDatabaseValue(@modifyTime)));
			parameters.Add(new SqlParameter("@ModifyMan", EntityBase.GetDatabaseValue(@modifyMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CKPropertyTemp into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="tempID">tempID</param>
		/// <param name="iD">iD</param>
		/// <param name="propertyName">propertyName</param>
		/// <param name="propertyCategoryID">propertyCategoryID</param>
		/// <param name="propertyNo">propertyNo</param>
		/// <param name="propertyModelNo">propertyModelNo</param>
		/// <param name="propertyUnit">propertyUnit</param>
		/// <param name="propertyCount">propertyCount</param>
		/// <param name="propertyUnitPrice">propertyUnitPrice</param>
		/// <param name="propertyCost">propertyCost</param>
		/// <param name="propertyPurchaseDate">propertyPurchaseDate</param>
		/// <param name="propertyUseYear">propertyUseYear</param>
		/// <param name="propertyRealCost">propertyRealCost</param>
		/// <param name="propertyChangeType">propertyChangeType</param>
		/// <param name="propertyState">propertyState</param>
		/// <param name="propertyDepartmentID">propertyDepartmentID</param>
		/// <param name="propertyLocation">propertyLocation</param>
		/// <param name="propertyUseMan">propertyUseMan</param>
		/// <param name="propertyContractName">propertyContractName</param>
		/// <param name="propertyContactPhone">propertyContactPhone</param>
		/// <param name="propertyRemark">propertyRemark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="propertyDiscountCost">propertyDiscountCost</param>
		/// <param name="updateMan">updateMan</param>
		/// <param name="updateTime">updateTime</param>
		/// <param name="modifyTime">modifyTime</param>
		/// <param name="modifyMan">modifyMan</param>
		public static void UpdateCKPropertyTemp(int @tempID, int @iD, string @propertyName, int @propertyCategoryID, string @propertyNo, string @propertyModelNo, string @propertyUnit, int @propertyCount, decimal @propertyUnitPrice, decimal @propertyCost, DateTime @propertyPurchaseDate, decimal @propertyUseYear, decimal @propertyRealCost, string @propertyChangeType, int @propertyState, int @propertyDepartmentID, string @propertyLocation, string @propertyUseMan, string @propertyContractName, string @propertyContactPhone, string @propertyRemark, string @addMan, DateTime @addTime, decimal @propertyDiscountCost, string @updateMan, DateTime @updateTime, DateTime @modifyTime, string @modifyMan)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCKPropertyTemp(@tempID, @iD, @propertyName, @propertyCategoryID, @propertyNo, @propertyModelNo, @propertyUnit, @propertyCount, @propertyUnitPrice, @propertyCost, @propertyPurchaseDate, @propertyUseYear, @propertyRealCost, @propertyChangeType, @propertyState, @propertyDepartmentID, @propertyLocation, @propertyUseMan, @propertyContractName, @propertyContactPhone, @propertyRemark, @addMan, @addTime, @propertyDiscountCost, @updateMan, @updateTime, @modifyTime, @modifyMan, helper);
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
		/// Updates a CKPropertyTemp into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="tempID">tempID</param>
		/// <param name="iD">iD</param>
		/// <param name="propertyName">propertyName</param>
		/// <param name="propertyCategoryID">propertyCategoryID</param>
		/// <param name="propertyNo">propertyNo</param>
		/// <param name="propertyModelNo">propertyModelNo</param>
		/// <param name="propertyUnit">propertyUnit</param>
		/// <param name="propertyCount">propertyCount</param>
		/// <param name="propertyUnitPrice">propertyUnitPrice</param>
		/// <param name="propertyCost">propertyCost</param>
		/// <param name="propertyPurchaseDate">propertyPurchaseDate</param>
		/// <param name="propertyUseYear">propertyUseYear</param>
		/// <param name="propertyRealCost">propertyRealCost</param>
		/// <param name="propertyChangeType">propertyChangeType</param>
		/// <param name="propertyState">propertyState</param>
		/// <param name="propertyDepartmentID">propertyDepartmentID</param>
		/// <param name="propertyLocation">propertyLocation</param>
		/// <param name="propertyUseMan">propertyUseMan</param>
		/// <param name="propertyContractName">propertyContractName</param>
		/// <param name="propertyContactPhone">propertyContactPhone</param>
		/// <param name="propertyRemark">propertyRemark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="propertyDiscountCost">propertyDiscountCost</param>
		/// <param name="updateMan">updateMan</param>
		/// <param name="updateTime">updateTime</param>
		/// <param name="modifyTime">modifyTime</param>
		/// <param name="modifyMan">modifyMan</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCKPropertyTemp(int @tempID, int @iD, string @propertyName, int @propertyCategoryID, string @propertyNo, string @propertyModelNo, string @propertyUnit, int @propertyCount, decimal @propertyUnitPrice, decimal @propertyCost, DateTime @propertyPurchaseDate, decimal @propertyUseYear, decimal @propertyRealCost, string @propertyChangeType, int @propertyState, int @propertyDepartmentID, string @propertyLocation, string @propertyUseMan, string @propertyContractName, string @propertyContactPhone, string @propertyRemark, string @addMan, DateTime @addTime, decimal @propertyDiscountCost, string @updateMan, DateTime @updateTime, DateTime @modifyTime, string @modifyMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[TempID] int,
	[ID] int,
	[PropertyName] nvarchar(200),
	[PropertyCategoryID] int,
	[PropertyNo] nvarchar(200),
	[PropertyModelNo] nvarchar(200),
	[PropertyUnit] nvarchar(50),
	[PropertyCount] int,
	[PropertyUnitPrice] decimal(18, 2),
	[PropertyCost] decimal(18, 2),
	[PropertyPurchaseDate] datetime,
	[PropertyUseYear] decimal(18, 2),
	[PropertyRealCost] decimal(18, 2),
	[PropertyChangeType] nvarchar(50),
	[PropertyState] int,
	[PropertyDepartmentID] int,
	[PropertyLocation] nvarchar(500),
	[PropertyUseMan] nvarchar(100),
	[PropertyContractName] nvarchar(200),
	[PropertyContactPhone] nvarchar(100),
	[PropertyRemark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime,
	[PropertyDiscountCost] decimal(18, 2),
	[UpdateMan] nvarchar(50),
	[UpdateTime] datetime,
	[ModifyTime] datetime,
	[ModifyMan] nvarchar(50)
);

UPDATE [dbo].[CKPropertyTemp] SET 
	[CKPropertyTemp].[ID] = @ID,
	[CKPropertyTemp].[PropertyName] = @PropertyName,
	[CKPropertyTemp].[PropertyCategoryID] = @PropertyCategoryID,
	[CKPropertyTemp].[PropertyNo] = @PropertyNo,
	[CKPropertyTemp].[PropertyModelNo] = @PropertyModelNo,
	[CKPropertyTemp].[PropertyUnit] = @PropertyUnit,
	[CKPropertyTemp].[PropertyCount] = @PropertyCount,
	[CKPropertyTemp].[PropertyUnitPrice] = @PropertyUnitPrice,
	[CKPropertyTemp].[PropertyCost] = @PropertyCost,
	[CKPropertyTemp].[PropertyPurchaseDate] = @PropertyPurchaseDate,
	[CKPropertyTemp].[PropertyUseYear] = @PropertyUseYear,
	[CKPropertyTemp].[PropertyRealCost] = @PropertyRealCost,
	[CKPropertyTemp].[PropertyChangeType] = @PropertyChangeType,
	[CKPropertyTemp].[PropertyState] = @PropertyState,
	[CKPropertyTemp].[PropertyDepartmentID] = @PropertyDepartmentID,
	[CKPropertyTemp].[PropertyLocation] = @PropertyLocation,
	[CKPropertyTemp].[PropertyUseMan] = @PropertyUseMan,
	[CKPropertyTemp].[PropertyContractName] = @PropertyContractName,
	[CKPropertyTemp].[PropertyContactPhone] = @PropertyContactPhone,
	[CKPropertyTemp].[PropertyRemark] = @PropertyRemark,
	[CKPropertyTemp].[AddMan] = @AddMan,
	[CKPropertyTemp].[AddTime] = @AddTime,
	[CKPropertyTemp].[PropertyDiscountCost] = @PropertyDiscountCost,
	[CKPropertyTemp].[UpdateMan] = @UpdateMan,
	[CKPropertyTemp].[UpdateTime] = @UpdateTime,
	[CKPropertyTemp].[ModifyTime] = @ModifyTime,
	[CKPropertyTemp].[ModifyMan] = @ModifyMan 
output 
	INSERTED.[TempID],
	INSERTED.[ID],
	INSERTED.[PropertyName],
	INSERTED.[PropertyCategoryID],
	INSERTED.[PropertyNo],
	INSERTED.[PropertyModelNo],
	INSERTED.[PropertyUnit],
	INSERTED.[PropertyCount],
	INSERTED.[PropertyUnitPrice],
	INSERTED.[PropertyCost],
	INSERTED.[PropertyPurchaseDate],
	INSERTED.[PropertyUseYear],
	INSERTED.[PropertyRealCost],
	INSERTED.[PropertyChangeType],
	INSERTED.[PropertyState],
	INSERTED.[PropertyDepartmentID],
	INSERTED.[PropertyLocation],
	INSERTED.[PropertyUseMan],
	INSERTED.[PropertyContractName],
	INSERTED.[PropertyContactPhone],
	INSERTED.[PropertyRemark],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[PropertyDiscountCost],
	INSERTED.[UpdateMan],
	INSERTED.[UpdateTime],
	INSERTED.[ModifyTime],
	INSERTED.[ModifyMan]
into @table
WHERE 
	[CKPropertyTemp].[TempID] = @TempID

SELECT 
	[TempID],
	[ID],
	[PropertyName],
	[PropertyCategoryID],
	[PropertyNo],
	[PropertyModelNo],
	[PropertyUnit],
	[PropertyCount],
	[PropertyUnitPrice],
	[PropertyCost],
	[PropertyPurchaseDate],
	[PropertyUseYear],
	[PropertyRealCost],
	[PropertyChangeType],
	[PropertyState],
	[PropertyDepartmentID],
	[PropertyLocation],
	[PropertyUseMan],
	[PropertyContractName],
	[PropertyContactPhone],
	[PropertyRemark],
	[AddMan],
	[AddTime],
	[PropertyDiscountCost],
	[UpdateMan],
	[UpdateTime],
	[ModifyTime],
	[ModifyMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TempID", EntityBase.GetDatabaseValue(@tempID)));
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@PropertyName", EntityBase.GetDatabaseValue(@propertyName)));
			parameters.Add(new SqlParameter("@PropertyCategoryID", EntityBase.GetDatabaseValue(@propertyCategoryID)));
			parameters.Add(new SqlParameter("@PropertyNo", EntityBase.GetDatabaseValue(@propertyNo)));
			parameters.Add(new SqlParameter("@PropertyModelNo", EntityBase.GetDatabaseValue(@propertyModelNo)));
			parameters.Add(new SqlParameter("@PropertyUnit", EntityBase.GetDatabaseValue(@propertyUnit)));
			parameters.Add(new SqlParameter("@PropertyCount", EntityBase.GetDatabaseValue(@propertyCount)));
			parameters.Add(new SqlParameter("@PropertyUnitPrice", EntityBase.GetDatabaseValue(@propertyUnitPrice)));
			parameters.Add(new SqlParameter("@PropertyCost", EntityBase.GetDatabaseValue(@propertyCost)));
			parameters.Add(new SqlParameter("@PropertyPurchaseDate", EntityBase.GetDatabaseValue(@propertyPurchaseDate)));
			parameters.Add(new SqlParameter("@PropertyUseYear", EntityBase.GetDatabaseValue(@propertyUseYear)));
			parameters.Add(new SqlParameter("@PropertyRealCost", EntityBase.GetDatabaseValue(@propertyRealCost)));
			parameters.Add(new SqlParameter("@PropertyChangeType", EntityBase.GetDatabaseValue(@propertyChangeType)));
			parameters.Add(new SqlParameter("@PropertyState", EntityBase.GetDatabaseValue(@propertyState)));
			parameters.Add(new SqlParameter("@PropertyDepartmentID", EntityBase.GetDatabaseValue(@propertyDepartmentID)));
			parameters.Add(new SqlParameter("@PropertyLocation", EntityBase.GetDatabaseValue(@propertyLocation)));
			parameters.Add(new SqlParameter("@PropertyUseMan", EntityBase.GetDatabaseValue(@propertyUseMan)));
			parameters.Add(new SqlParameter("@PropertyContractName", EntityBase.GetDatabaseValue(@propertyContractName)));
			parameters.Add(new SqlParameter("@PropertyContactPhone", EntityBase.GetDatabaseValue(@propertyContactPhone)));
			parameters.Add(new SqlParameter("@PropertyRemark", EntityBase.GetDatabaseValue(@propertyRemark)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@PropertyDiscountCost", EntityBase.GetDatabaseValue(@propertyDiscountCost)));
			parameters.Add(new SqlParameter("@UpdateMan", EntityBase.GetDatabaseValue(@updateMan)));
			parameters.Add(new SqlParameter("@UpdateTime", EntityBase.GetDatabaseValue(@updateTime)));
			parameters.Add(new SqlParameter("@ModifyTime", EntityBase.GetDatabaseValue(@modifyTime)));
			parameters.Add(new SqlParameter("@ModifyMan", EntityBase.GetDatabaseValue(@modifyMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CKPropertyTemp from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="tempID">tempID</param>
		public static void DeleteCKPropertyTemp(int @tempID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCKPropertyTemp(@tempID, helper);
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
		/// Deletes a CKPropertyTemp from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="tempID">tempID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCKPropertyTemp(int @tempID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CKPropertyTemp]
WHERE 
	[CKPropertyTemp].[TempID] = @TempID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TempID", @tempID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CKPropertyTemp object.
		/// </summary>
		/// <returns>The newly created CKPropertyTemp object.</returns>
		public static CKPropertyTemp CreateCKPropertyTemp()
		{
			return InitializeNew<CKPropertyTemp>();
		}
		
		/// <summary>
		/// Retrieve information for a CKPropertyTemp by a CKPropertyTemp's unique identifier.
		/// </summary>
		/// <param name="tempID">tempID</param>
		/// <returns>CKPropertyTemp</returns>
		public static CKPropertyTemp GetCKPropertyTemp(int @tempID)
		{
			string commandText = @"
SELECT 
" + CKPropertyTemp.SelectFieldList + @"
FROM [dbo].[CKPropertyTemp] 
WHERE 
	[CKPropertyTemp].[TempID] = @TempID " + CKPropertyTemp.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TempID", @tempID));
			
			return GetOne<CKPropertyTemp>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CKPropertyTemp by a CKPropertyTemp's unique identifier.
		/// </summary>
		/// <param name="tempID">tempID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CKPropertyTemp</returns>
		public static CKPropertyTemp GetCKPropertyTemp(int @tempID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CKPropertyTemp.SelectFieldList + @"
FROM [dbo].[CKPropertyTemp] 
WHERE 
	[CKPropertyTemp].[TempID] = @TempID " + CKPropertyTemp.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TempID", @tempID));
			
			return GetOne<CKPropertyTemp>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CKPropertyTemp objects.
		/// </summary>
		/// <returns>The retrieved collection of CKPropertyTemp objects.</returns>
		public static EntityList<CKPropertyTemp> GetCKPropertyTemps()
		{
			string commandText = @"
SELECT " + CKPropertyTemp.SelectFieldList + "FROM [dbo].[CKPropertyTemp] " + CKPropertyTemp.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CKPropertyTemp>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CKPropertyTemp objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKPropertyTemp objects.</returns>
        public static EntityList<CKPropertyTemp> GetCKPropertyTemps(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKPropertyTemp>(SelectFieldList, "FROM [dbo].[CKPropertyTemp]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CKPropertyTemp objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKPropertyTemp objects.</returns>
        public static EntityList<CKPropertyTemp> GetCKPropertyTemps(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKPropertyTemp>(SelectFieldList, "FROM [dbo].[CKPropertyTemp]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CKPropertyTemp objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CKPropertyTemp objects.</returns>
		protected static EntityList<CKPropertyTemp> GetCKPropertyTemps(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKPropertyTemps(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CKPropertyTemp objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKPropertyTemp objects.</returns>
		protected static EntityList<CKPropertyTemp> GetCKPropertyTemps(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKPropertyTemps(string.Empty, where, parameters, CKPropertyTemp.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKPropertyTemp objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKPropertyTemp objects.</returns>
		protected static EntityList<CKPropertyTemp> GetCKPropertyTemps(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKPropertyTemps(prefix, where, parameters, CKPropertyTemp.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKPropertyTemp objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKPropertyTemp objects.</returns>
		protected static EntityList<CKPropertyTemp> GetCKPropertyTemps(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKPropertyTemps(string.Empty, where, parameters, CKPropertyTemp.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKPropertyTemp objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKPropertyTemp objects.</returns>
		protected static EntityList<CKPropertyTemp> GetCKPropertyTemps(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKPropertyTemps(prefix, where, parameters, CKPropertyTemp.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKPropertyTemp objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CKPropertyTemp objects.</returns>
		protected static EntityList<CKPropertyTemp> GetCKPropertyTemps(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CKPropertyTemp.SelectFieldList + "FROM [dbo].[CKPropertyTemp] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CKPropertyTemp>(reader);
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
        protected static EntityList<CKPropertyTemp> GetCKPropertyTemps(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKPropertyTemp>(SelectFieldList, "FROM [dbo].[CKPropertyTemp] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CKPropertyTemp objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKPropertyTempCount()
        {
            return GetCKPropertyTempCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CKPropertyTemp objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKPropertyTempCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CKPropertyTemp] " + where;

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
		public static partial class CKPropertyTemp_Properties
		{
			public const string TempID = "TempID";
			public const string ID = "ID";
			public const string PropertyName = "PropertyName";
			public const string PropertyCategoryID = "PropertyCategoryID";
			public const string PropertyNo = "PropertyNo";
			public const string PropertyModelNo = "PropertyModelNo";
			public const string PropertyUnit = "PropertyUnit";
			public const string PropertyCount = "PropertyCount";
			public const string PropertyUnitPrice = "PropertyUnitPrice";
			public const string PropertyCost = "PropertyCost";
			public const string PropertyPurchaseDate = "PropertyPurchaseDate";
			public const string PropertyUseYear = "PropertyUseYear";
			public const string PropertyRealCost = "PropertyRealCost";
			public const string PropertyChangeType = "PropertyChangeType";
			public const string PropertyState = "PropertyState";
			public const string PropertyDepartmentID = "PropertyDepartmentID";
			public const string PropertyLocation = "PropertyLocation";
			public const string PropertyUseMan = "PropertyUseMan";
			public const string PropertyContractName = "PropertyContractName";
			public const string PropertyContactPhone = "PropertyContactPhone";
			public const string PropertyRemark = "PropertyRemark";
			public const string AddMan = "AddMan";
			public const string AddTime = "AddTime";
			public const string PropertyDiscountCost = "PropertyDiscountCost";
			public const string UpdateMan = "UpdateMan";
			public const string UpdateTime = "UpdateTime";
			public const string ModifyTime = "ModifyTime";
			public const string ModifyMan = "ModifyMan";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"TempID" , "int:"},
    			 {"ID" , "int:"},
    			 {"PropertyName" , "string:"},
    			 {"PropertyCategoryID" , "int:"},
    			 {"PropertyNo" , "string:"},
    			 {"PropertyModelNo" , "string:"},
    			 {"PropertyUnit" , "string:"},
    			 {"PropertyCount" , "int:"},
    			 {"PropertyUnitPrice" , "decimal:"},
    			 {"PropertyCost" , "decimal:"},
    			 {"PropertyPurchaseDate" , "DateTime:"},
    			 {"PropertyUseYear" , "decimal:"},
    			 {"PropertyRealCost" , "decimal:"},
    			 {"PropertyChangeType" , "string:"},
    			 {"PropertyState" , "int:"},
    			 {"PropertyDepartmentID" , "int:"},
    			 {"PropertyLocation" , "string:"},
    			 {"PropertyUseMan" , "string:"},
    			 {"PropertyContractName" , "string:"},
    			 {"PropertyContactPhone" , "string:"},
    			 {"PropertyRemark" , "string:"},
    			 {"AddMan" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"PropertyDiscountCost" , "decimal:"},
    			 {"UpdateMan" , "string:"},
    			 {"UpdateTime" , "DateTime:"},
    			 {"ModifyTime" , "DateTime:"},
    			 {"ModifyMan" , "string:"},
            };
		}
		#endregion
	}
}
