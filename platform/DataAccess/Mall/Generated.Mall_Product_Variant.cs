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
	/// This object represents the properties and methods of a Mall_Product_Variant.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_Product_Variant 
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
		private int _productID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ProductID
		{
			[DebuggerStepThrough()]
			get { return this._productID; }
			set 
			{
				if (this._productID != value) 
				{
					this._productID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _variantName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string VariantName
		{
			[DebuggerStepThrough()]
			get { return this._variantName; }
			set 
			{
				if (this._variantName != value) 
				{
					this._variantName = value;
					this.IsDirty = true;	
					OnPropertyChanged("VariantName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _variantPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal VariantPrice
		{
			[DebuggerStepThrough()]
			get { return this._variantPrice; }
			set 
			{
				if (this._variantPrice != value) 
				{
					this._variantPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("VariantPrice");
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
		private string _variantTitle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string VariantTitle
		{
			[DebuggerStepThrough()]
			get { return this._variantTitle; }
			set 
			{
				if (this._variantTitle != value) 
				{
					this._variantTitle = value;
					this.IsDirty = true;	
					OnPropertyChanged("VariantTitle");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _gUID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string GUID
		{
			[DebuggerStepThrough()]
			get { return this._gUID; }
			set 
			{
				if (this._gUID != value) 
				{
					this._gUID = value;
					this.IsDirty = true;	
					OnPropertyChanged("GUID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _inventory = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Inventory
		{
			[DebuggerStepThrough()]
			get { return this._inventory; }
			set 
			{
				if (this._inventory != value) 
				{
					this._inventory = value;
					this.IsDirty = true;	
					OnPropertyChanged("Inventory");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _variantPoint = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int VariantPoint
		{
			[DebuggerStepThrough()]
			get { return this._variantPoint; }
			set 
			{
				if (this._variantPoint != value) 
				{
					this._variantPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("VariantPoint");
				}
			}
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
			set 
			{
				if (this._isDefault != value) 
				{
					this._isDefault = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDefault");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _variantPointPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal VariantPointPrice
		{
			[DebuggerStepThrough()]
			get { return this._variantPointPrice; }
			set 
			{
				if (this._variantPointPrice != value) 
				{
					this._variantPointPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("VariantPointPrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _variantVIPPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal VariantVIPPrice
		{
			[DebuggerStepThrough()]
			get { return this._variantVIPPrice; }
			set 
			{
				if (this._variantVIPPrice != value) 
				{
					this._variantVIPPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("VariantVIPPrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _variantVIPPoint = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int VariantVIPPoint
		{
			[DebuggerStepThrough()]
			get { return this._variantVIPPoint; }
			set 
			{
				if (this._variantVIPPoint != value) 
				{
					this._variantVIPPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("VariantVIPPoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _variantStaffPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal VariantStaffPrice
		{
			[DebuggerStepThrough()]
			get { return this._variantStaffPrice; }
			set 
			{
				if (this._variantStaffPrice != value) 
				{
					this._variantStaffPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("VariantStaffPrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _variantStaffPoint = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int VariantStaffPoint
		{
			[DebuggerStepThrough()]
			get { return this._variantStaffPoint; }
			set 
			{
				if (this._variantStaffPoint != value) 
				{
					this._variantStaffPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("VariantStaffPoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _variantBasicPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal VariantBasicPrice
		{
			[DebuggerStepThrough()]
			get { return this._variantBasicPrice; }
			set 
			{
				if (this._variantBasicPrice != value) 
				{
					this._variantBasicPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("VariantBasicPrice");
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
	[ProductID] int,
	[VariantName] nvarchar(200),
	[VariantPrice] decimal(18, 2),
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[VariantTitle] nvarchar(200),
	[GUID] nvarchar(500),
	[Inventory] int,
	[VariantPoint] int,
	[IsDefault] bit,
	[VariantPointPrice] decimal(18, 2),
	[VariantVIPPrice] decimal(18, 2),
	[VariantVIPPoint] int,
	[VariantStaffPrice] decimal(18, 2),
	[VariantStaffPoint] int,
	[VariantBasicPrice] decimal(18, 2)
);

INSERT INTO [dbo].[Mall_Product_Variant] (
	[Mall_Product_Variant].[ProductID],
	[Mall_Product_Variant].[VariantName],
	[Mall_Product_Variant].[VariantPrice],
	[Mall_Product_Variant].[AddTime],
	[Mall_Product_Variant].[AddMan],
	[Mall_Product_Variant].[VariantTitle],
	[Mall_Product_Variant].[GUID],
	[Mall_Product_Variant].[Inventory],
	[Mall_Product_Variant].[VariantPoint],
	[Mall_Product_Variant].[IsDefault],
	[Mall_Product_Variant].[VariantPointPrice],
	[Mall_Product_Variant].[VariantVIPPrice],
	[Mall_Product_Variant].[VariantVIPPoint],
	[Mall_Product_Variant].[VariantStaffPrice],
	[Mall_Product_Variant].[VariantStaffPoint],
	[Mall_Product_Variant].[VariantBasicPrice]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[VariantName],
	INSERTED.[VariantPrice],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[VariantTitle],
	INSERTED.[GUID],
	INSERTED.[Inventory],
	INSERTED.[VariantPoint],
	INSERTED.[IsDefault],
	INSERTED.[VariantPointPrice],
	INSERTED.[VariantVIPPrice],
	INSERTED.[VariantVIPPoint],
	INSERTED.[VariantStaffPrice],
	INSERTED.[VariantStaffPoint],
	INSERTED.[VariantBasicPrice]
into @table
VALUES ( 
	@ProductID,
	@VariantName,
	@VariantPrice,
	@AddTime,
	@AddMan,
	@VariantTitle,
	@GUID,
	@Inventory,
	@VariantPoint,
	@IsDefault,
	@VariantPointPrice,
	@VariantVIPPrice,
	@VariantVIPPoint,
	@VariantStaffPrice,
	@VariantStaffPoint,
	@VariantBasicPrice 
); 

SELECT 
	[ID],
	[ProductID],
	[VariantName],
	[VariantPrice],
	[AddTime],
	[AddMan],
	[VariantTitle],
	[GUID],
	[Inventory],
	[VariantPoint],
	[IsDefault],
	[VariantPointPrice],
	[VariantVIPPrice],
	[VariantVIPPoint],
	[VariantStaffPrice],
	[VariantStaffPoint],
	[VariantBasicPrice] 
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
	[ProductID] int,
	[VariantName] nvarchar(200),
	[VariantPrice] decimal(18, 2),
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[VariantTitle] nvarchar(200),
	[GUID] nvarchar(500),
	[Inventory] int,
	[VariantPoint] int,
	[IsDefault] bit,
	[VariantPointPrice] decimal(18, 2),
	[VariantVIPPrice] decimal(18, 2),
	[VariantVIPPoint] int,
	[VariantStaffPrice] decimal(18, 2),
	[VariantStaffPoint] int,
	[VariantBasicPrice] decimal(18, 2)
);

UPDATE [dbo].[Mall_Product_Variant] SET 
	[Mall_Product_Variant].[ProductID] = @ProductID,
	[Mall_Product_Variant].[VariantName] = @VariantName,
	[Mall_Product_Variant].[VariantPrice] = @VariantPrice,
	[Mall_Product_Variant].[AddTime] = @AddTime,
	[Mall_Product_Variant].[AddMan] = @AddMan,
	[Mall_Product_Variant].[VariantTitle] = @VariantTitle,
	[Mall_Product_Variant].[GUID] = @GUID,
	[Mall_Product_Variant].[Inventory] = @Inventory,
	[Mall_Product_Variant].[VariantPoint] = @VariantPoint,
	[Mall_Product_Variant].[IsDefault] = @IsDefault,
	[Mall_Product_Variant].[VariantPointPrice] = @VariantPointPrice,
	[Mall_Product_Variant].[VariantVIPPrice] = @VariantVIPPrice,
	[Mall_Product_Variant].[VariantVIPPoint] = @VariantVIPPoint,
	[Mall_Product_Variant].[VariantStaffPrice] = @VariantStaffPrice,
	[Mall_Product_Variant].[VariantStaffPoint] = @VariantStaffPoint,
	[Mall_Product_Variant].[VariantBasicPrice] = @VariantBasicPrice 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[VariantName],
	INSERTED.[VariantPrice],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[VariantTitle],
	INSERTED.[GUID],
	INSERTED.[Inventory],
	INSERTED.[VariantPoint],
	INSERTED.[IsDefault],
	INSERTED.[VariantPointPrice],
	INSERTED.[VariantVIPPrice],
	INSERTED.[VariantVIPPoint],
	INSERTED.[VariantStaffPrice],
	INSERTED.[VariantStaffPoint],
	INSERTED.[VariantBasicPrice]
into @table
WHERE 
	[Mall_Product_Variant].[ID] = @ID

SELECT 
	[ID],
	[ProductID],
	[VariantName],
	[VariantPrice],
	[AddTime],
	[AddMan],
	[VariantTitle],
	[GUID],
	[Inventory],
	[VariantPoint],
	[IsDefault],
	[VariantPointPrice],
	[VariantVIPPrice],
	[VariantVIPPoint],
	[VariantStaffPrice],
	[VariantStaffPoint],
	[VariantBasicPrice] 
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
DELETE FROM [dbo].[Mall_Product_Variant]
WHERE 
	[Mall_Product_Variant].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_Product_Variant() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_Product_Variant(this.ID));
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
	[Mall_Product_Variant].[ID],
	[Mall_Product_Variant].[ProductID],
	[Mall_Product_Variant].[VariantName],
	[Mall_Product_Variant].[VariantPrice],
	[Mall_Product_Variant].[AddTime],
	[Mall_Product_Variant].[AddMan],
	[Mall_Product_Variant].[VariantTitle],
	[Mall_Product_Variant].[GUID],
	[Mall_Product_Variant].[Inventory],
	[Mall_Product_Variant].[VariantPoint],
	[Mall_Product_Variant].[IsDefault],
	[Mall_Product_Variant].[VariantPointPrice],
	[Mall_Product_Variant].[VariantVIPPrice],
	[Mall_Product_Variant].[VariantVIPPoint],
	[Mall_Product_Variant].[VariantStaffPrice],
	[Mall_Product_Variant].[VariantStaffPoint],
	[Mall_Product_Variant].[VariantBasicPrice]
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
                return "Mall_Product_Variant";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_Product_Variant into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productID">productID</param>
		/// <param name="variantName">variantName</param>
		/// <param name="variantPrice">variantPrice</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="variantTitle">variantTitle</param>
		/// <param name="gUID">gUID</param>
		/// <param name="inventory">inventory</param>
		/// <param name="variantPoint">variantPoint</param>
		/// <param name="isDefault">isDefault</param>
		/// <param name="variantPointPrice">variantPointPrice</param>
		/// <param name="variantVIPPrice">variantVIPPrice</param>
		/// <param name="variantVIPPoint">variantVIPPoint</param>
		/// <param name="variantStaffPrice">variantStaffPrice</param>
		/// <param name="variantStaffPoint">variantStaffPoint</param>
		/// <param name="variantBasicPrice">variantBasicPrice</param>
		public static void InsertMall_Product_Variant(int @productID, string @variantName, decimal @variantPrice, DateTime @addTime, string @addMan, string @variantTitle, string @gUID, int @inventory, int @variantPoint, bool @isDefault, decimal @variantPointPrice, decimal @variantVIPPrice, int @variantVIPPoint, decimal @variantStaffPrice, int @variantStaffPoint, decimal @variantBasicPrice)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_Product_Variant(@productID, @variantName, @variantPrice, @addTime, @addMan, @variantTitle, @gUID, @inventory, @variantPoint, @isDefault, @variantPointPrice, @variantVIPPrice, @variantVIPPoint, @variantStaffPrice, @variantStaffPoint, @variantBasicPrice, helper);
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
		/// Insert a Mall_Product_Variant into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productID">productID</param>
		/// <param name="variantName">variantName</param>
		/// <param name="variantPrice">variantPrice</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="variantTitle">variantTitle</param>
		/// <param name="gUID">gUID</param>
		/// <param name="inventory">inventory</param>
		/// <param name="variantPoint">variantPoint</param>
		/// <param name="isDefault">isDefault</param>
		/// <param name="variantPointPrice">variantPointPrice</param>
		/// <param name="variantVIPPrice">variantVIPPrice</param>
		/// <param name="variantVIPPoint">variantVIPPoint</param>
		/// <param name="variantStaffPrice">variantStaffPrice</param>
		/// <param name="variantStaffPoint">variantStaffPoint</param>
		/// <param name="variantBasicPrice">variantBasicPrice</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_Product_Variant(int @productID, string @variantName, decimal @variantPrice, DateTime @addTime, string @addMan, string @variantTitle, string @gUID, int @inventory, int @variantPoint, bool @isDefault, decimal @variantPointPrice, decimal @variantVIPPrice, int @variantVIPPoint, decimal @variantStaffPrice, int @variantStaffPoint, decimal @variantBasicPrice, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProductID] int,
	[VariantName] nvarchar(200),
	[VariantPrice] decimal(18, 2),
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[VariantTitle] nvarchar(200),
	[GUID] nvarchar(500),
	[Inventory] int,
	[VariantPoint] int,
	[IsDefault] bit,
	[VariantPointPrice] decimal(18, 2),
	[VariantVIPPrice] decimal(18, 2),
	[VariantVIPPoint] int,
	[VariantStaffPrice] decimal(18, 2),
	[VariantStaffPoint] int,
	[VariantBasicPrice] decimal(18, 2)
);

INSERT INTO [dbo].[Mall_Product_Variant] (
	[Mall_Product_Variant].[ProductID],
	[Mall_Product_Variant].[VariantName],
	[Mall_Product_Variant].[VariantPrice],
	[Mall_Product_Variant].[AddTime],
	[Mall_Product_Variant].[AddMan],
	[Mall_Product_Variant].[VariantTitle],
	[Mall_Product_Variant].[GUID],
	[Mall_Product_Variant].[Inventory],
	[Mall_Product_Variant].[VariantPoint],
	[Mall_Product_Variant].[IsDefault],
	[Mall_Product_Variant].[VariantPointPrice],
	[Mall_Product_Variant].[VariantVIPPrice],
	[Mall_Product_Variant].[VariantVIPPoint],
	[Mall_Product_Variant].[VariantStaffPrice],
	[Mall_Product_Variant].[VariantStaffPoint],
	[Mall_Product_Variant].[VariantBasicPrice]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[VariantName],
	INSERTED.[VariantPrice],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[VariantTitle],
	INSERTED.[GUID],
	INSERTED.[Inventory],
	INSERTED.[VariantPoint],
	INSERTED.[IsDefault],
	INSERTED.[VariantPointPrice],
	INSERTED.[VariantVIPPrice],
	INSERTED.[VariantVIPPoint],
	INSERTED.[VariantStaffPrice],
	INSERTED.[VariantStaffPoint],
	INSERTED.[VariantBasicPrice]
into @table
VALUES ( 
	@ProductID,
	@VariantName,
	@VariantPrice,
	@AddTime,
	@AddMan,
	@VariantTitle,
	@GUID,
	@Inventory,
	@VariantPoint,
	@IsDefault,
	@VariantPointPrice,
	@VariantVIPPrice,
	@VariantVIPPoint,
	@VariantStaffPrice,
	@VariantStaffPoint,
	@VariantBasicPrice 
); 

SELECT 
	[ID],
	[ProductID],
	[VariantName],
	[VariantPrice],
	[AddTime],
	[AddMan],
	[VariantTitle],
	[GUID],
	[Inventory],
	[VariantPoint],
	[IsDefault],
	[VariantPointPrice],
	[VariantVIPPrice],
	[VariantVIPPoint],
	[VariantStaffPrice],
	[VariantStaffPoint],
	[VariantBasicPrice] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@VariantName", EntityBase.GetDatabaseValue(@variantName)));
			parameters.Add(new SqlParameter("@VariantPrice", EntityBase.GetDatabaseValue(@variantPrice)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@VariantTitle", EntityBase.GetDatabaseValue(@variantTitle)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@Inventory", EntityBase.GetDatabaseValue(@inventory)));
			parameters.Add(new SqlParameter("@VariantPoint", EntityBase.GetDatabaseValue(@variantPoint)));
			parameters.Add(new SqlParameter("@IsDefault", @isDefault));
			parameters.Add(new SqlParameter("@VariantPointPrice", EntityBase.GetDatabaseValue(@variantPointPrice)));
			parameters.Add(new SqlParameter("@VariantVIPPrice", EntityBase.GetDatabaseValue(@variantVIPPrice)));
			parameters.Add(new SqlParameter("@VariantVIPPoint", EntityBase.GetDatabaseValue(@variantVIPPoint)));
			parameters.Add(new SqlParameter("@VariantStaffPrice", EntityBase.GetDatabaseValue(@variantStaffPrice)));
			parameters.Add(new SqlParameter("@VariantStaffPoint", EntityBase.GetDatabaseValue(@variantStaffPoint)));
			parameters.Add(new SqlParameter("@VariantBasicPrice", EntityBase.GetDatabaseValue(@variantBasicPrice)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_Product_Variant into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="productID">productID</param>
		/// <param name="variantName">variantName</param>
		/// <param name="variantPrice">variantPrice</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="variantTitle">variantTitle</param>
		/// <param name="gUID">gUID</param>
		/// <param name="inventory">inventory</param>
		/// <param name="variantPoint">variantPoint</param>
		/// <param name="isDefault">isDefault</param>
		/// <param name="variantPointPrice">variantPointPrice</param>
		/// <param name="variantVIPPrice">variantVIPPrice</param>
		/// <param name="variantVIPPoint">variantVIPPoint</param>
		/// <param name="variantStaffPrice">variantStaffPrice</param>
		/// <param name="variantStaffPoint">variantStaffPoint</param>
		/// <param name="variantBasicPrice">variantBasicPrice</param>
		public static void UpdateMall_Product_Variant(int @iD, int @productID, string @variantName, decimal @variantPrice, DateTime @addTime, string @addMan, string @variantTitle, string @gUID, int @inventory, int @variantPoint, bool @isDefault, decimal @variantPointPrice, decimal @variantVIPPrice, int @variantVIPPoint, decimal @variantStaffPrice, int @variantStaffPoint, decimal @variantBasicPrice)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_Product_Variant(@iD, @productID, @variantName, @variantPrice, @addTime, @addMan, @variantTitle, @gUID, @inventory, @variantPoint, @isDefault, @variantPointPrice, @variantVIPPrice, @variantVIPPoint, @variantStaffPrice, @variantStaffPoint, @variantBasicPrice, helper);
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
		/// Updates a Mall_Product_Variant into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="productID">productID</param>
		/// <param name="variantName">variantName</param>
		/// <param name="variantPrice">variantPrice</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="variantTitle">variantTitle</param>
		/// <param name="gUID">gUID</param>
		/// <param name="inventory">inventory</param>
		/// <param name="variantPoint">variantPoint</param>
		/// <param name="isDefault">isDefault</param>
		/// <param name="variantPointPrice">variantPointPrice</param>
		/// <param name="variantVIPPrice">variantVIPPrice</param>
		/// <param name="variantVIPPoint">variantVIPPoint</param>
		/// <param name="variantStaffPrice">variantStaffPrice</param>
		/// <param name="variantStaffPoint">variantStaffPoint</param>
		/// <param name="variantBasicPrice">variantBasicPrice</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_Product_Variant(int @iD, int @productID, string @variantName, decimal @variantPrice, DateTime @addTime, string @addMan, string @variantTitle, string @gUID, int @inventory, int @variantPoint, bool @isDefault, decimal @variantPointPrice, decimal @variantVIPPrice, int @variantVIPPoint, decimal @variantStaffPrice, int @variantStaffPoint, decimal @variantBasicPrice, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProductID] int,
	[VariantName] nvarchar(200),
	[VariantPrice] decimal(18, 2),
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[VariantTitle] nvarchar(200),
	[GUID] nvarchar(500),
	[Inventory] int,
	[VariantPoint] int,
	[IsDefault] bit,
	[VariantPointPrice] decimal(18, 2),
	[VariantVIPPrice] decimal(18, 2),
	[VariantVIPPoint] int,
	[VariantStaffPrice] decimal(18, 2),
	[VariantStaffPoint] int,
	[VariantBasicPrice] decimal(18, 2)
);

UPDATE [dbo].[Mall_Product_Variant] SET 
	[Mall_Product_Variant].[ProductID] = @ProductID,
	[Mall_Product_Variant].[VariantName] = @VariantName,
	[Mall_Product_Variant].[VariantPrice] = @VariantPrice,
	[Mall_Product_Variant].[AddTime] = @AddTime,
	[Mall_Product_Variant].[AddMan] = @AddMan,
	[Mall_Product_Variant].[VariantTitle] = @VariantTitle,
	[Mall_Product_Variant].[GUID] = @GUID,
	[Mall_Product_Variant].[Inventory] = @Inventory,
	[Mall_Product_Variant].[VariantPoint] = @VariantPoint,
	[Mall_Product_Variant].[IsDefault] = @IsDefault,
	[Mall_Product_Variant].[VariantPointPrice] = @VariantPointPrice,
	[Mall_Product_Variant].[VariantVIPPrice] = @VariantVIPPrice,
	[Mall_Product_Variant].[VariantVIPPoint] = @VariantVIPPoint,
	[Mall_Product_Variant].[VariantStaffPrice] = @VariantStaffPrice,
	[Mall_Product_Variant].[VariantStaffPoint] = @VariantStaffPoint,
	[Mall_Product_Variant].[VariantBasicPrice] = @VariantBasicPrice 
output 
	INSERTED.[ID],
	INSERTED.[ProductID],
	INSERTED.[VariantName],
	INSERTED.[VariantPrice],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[VariantTitle],
	INSERTED.[GUID],
	INSERTED.[Inventory],
	INSERTED.[VariantPoint],
	INSERTED.[IsDefault],
	INSERTED.[VariantPointPrice],
	INSERTED.[VariantVIPPrice],
	INSERTED.[VariantVIPPoint],
	INSERTED.[VariantStaffPrice],
	INSERTED.[VariantStaffPoint],
	INSERTED.[VariantBasicPrice]
into @table
WHERE 
	[Mall_Product_Variant].[ID] = @ID

SELECT 
	[ID],
	[ProductID],
	[VariantName],
	[VariantPrice],
	[AddTime],
	[AddMan],
	[VariantTitle],
	[GUID],
	[Inventory],
	[VariantPoint],
	[IsDefault],
	[VariantPointPrice],
	[VariantVIPPrice],
	[VariantVIPPoint],
	[VariantStaffPrice],
	[VariantStaffPoint],
	[VariantBasicPrice] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@VariantName", EntityBase.GetDatabaseValue(@variantName)));
			parameters.Add(new SqlParameter("@VariantPrice", EntityBase.GetDatabaseValue(@variantPrice)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@VariantTitle", EntityBase.GetDatabaseValue(@variantTitle)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@Inventory", EntityBase.GetDatabaseValue(@inventory)));
			parameters.Add(new SqlParameter("@VariantPoint", EntityBase.GetDatabaseValue(@variantPoint)));
			parameters.Add(new SqlParameter("@IsDefault", @isDefault));
			parameters.Add(new SqlParameter("@VariantPointPrice", EntityBase.GetDatabaseValue(@variantPointPrice)));
			parameters.Add(new SqlParameter("@VariantVIPPrice", EntityBase.GetDatabaseValue(@variantVIPPrice)));
			parameters.Add(new SqlParameter("@VariantVIPPoint", EntityBase.GetDatabaseValue(@variantVIPPoint)));
			parameters.Add(new SqlParameter("@VariantStaffPrice", EntityBase.GetDatabaseValue(@variantStaffPrice)));
			parameters.Add(new SqlParameter("@VariantStaffPoint", EntityBase.GetDatabaseValue(@variantStaffPoint)));
			parameters.Add(new SqlParameter("@VariantBasicPrice", EntityBase.GetDatabaseValue(@variantBasicPrice)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_Product_Variant from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_Product_Variant(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_Product_Variant(@iD, helper);
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
		/// Deletes a Mall_Product_Variant from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_Product_Variant(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_Product_Variant]
WHERE 
	[Mall_Product_Variant].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_Product_Variant object.
		/// </summary>
		/// <returns>The newly created Mall_Product_Variant object.</returns>
		public static Mall_Product_Variant CreateMall_Product_Variant()
		{
			return InitializeNew<Mall_Product_Variant>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_Product_Variant by a Mall_Product_Variant's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_Product_Variant</returns>
		public static Mall_Product_Variant GetMall_Product_Variant(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_Product_Variant.SelectFieldList + @"
FROM [dbo].[Mall_Product_Variant] 
WHERE 
	[Mall_Product_Variant].[ID] = @ID " + Mall_Product_Variant.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Product_Variant>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_Product_Variant by a Mall_Product_Variant's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_Product_Variant</returns>
		public static Mall_Product_Variant GetMall_Product_Variant(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_Product_Variant.SelectFieldList + @"
FROM [dbo].[Mall_Product_Variant] 
WHERE 
	[Mall_Product_Variant].[ID] = @ID " + Mall_Product_Variant.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Product_Variant>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product_Variant objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_Product_Variant objects.</returns>
		public static EntityList<Mall_Product_Variant> GetMall_Product_Variants()
		{
			string commandText = @"
SELECT " + Mall_Product_Variant.SelectFieldList + "FROM [dbo].[Mall_Product_Variant] " + Mall_Product_Variant.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_Product_Variant>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_Product_Variant objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Product_Variant objects.</returns>
        public static EntityList<Mall_Product_Variant> GetMall_Product_Variants(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Product_Variant>(SelectFieldList, "FROM [dbo].[Mall_Product_Variant]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_Product_Variant objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Product_Variant objects.</returns>
        public static EntityList<Mall_Product_Variant> GetMall_Product_Variants(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Product_Variant>(SelectFieldList, "FROM [dbo].[Mall_Product_Variant]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_Product_Variant objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Product_Variant objects.</returns>
		protected static EntityList<Mall_Product_Variant> GetMall_Product_Variants(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Product_Variants(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product_Variant objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Product_Variant objects.</returns>
		protected static EntityList<Mall_Product_Variant> GetMall_Product_Variants(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Product_Variants(string.Empty, where, parameters, Mall_Product_Variant.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product_Variant objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Product_Variant objects.</returns>
		protected static EntityList<Mall_Product_Variant> GetMall_Product_Variants(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Product_Variants(prefix, where, parameters, Mall_Product_Variant.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product_Variant objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Product_Variant objects.</returns>
		protected static EntityList<Mall_Product_Variant> GetMall_Product_Variants(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Product_Variants(string.Empty, where, parameters, Mall_Product_Variant.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product_Variant objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Product_Variant objects.</returns>
		protected static EntityList<Mall_Product_Variant> GetMall_Product_Variants(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Product_Variants(prefix, where, parameters, Mall_Product_Variant.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Product_Variant objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Product_Variant objects.</returns>
		protected static EntityList<Mall_Product_Variant> GetMall_Product_Variants(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_Product_Variant.SelectFieldList + "FROM [dbo].[Mall_Product_Variant] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_Product_Variant>(reader);
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
        protected static EntityList<Mall_Product_Variant> GetMall_Product_Variants(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Product_Variant>(SelectFieldList, "FROM [dbo].[Mall_Product_Variant] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_Product_Variant objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_Product_VariantCount()
        {
            return GetMall_Product_VariantCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_Product_Variant objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_Product_VariantCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_Product_Variant] " + where;

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
		public static partial class Mall_Product_Variant_Properties
		{
			public const string ID = "ID";
			public const string ProductID = "ProductID";
			public const string VariantName = "VariantName";
			public const string VariantPrice = "VariantPrice";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string VariantTitle = "VariantTitle";
			public const string GUID = "GUID";
			public const string Inventory = "Inventory";
			public const string VariantPoint = "VariantPoint";
			public const string IsDefault = "IsDefault";
			public const string VariantPointPrice = "VariantPointPrice";
			public const string VariantVIPPrice = "VariantVIPPrice";
			public const string VariantVIPPoint = "VariantVIPPoint";
			public const string VariantStaffPrice = "VariantStaffPrice";
			public const string VariantStaffPoint = "VariantStaffPoint";
			public const string VariantBasicPrice = "VariantBasicPrice";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProductID" , "int:"},
    			 {"VariantName" , "string:"},
    			 {"VariantPrice" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"VariantTitle" , "string:"},
    			 {"GUID" , "string:"},
    			 {"Inventory" , "int:"},
    			 {"VariantPoint" , "int:"},
    			 {"IsDefault" , "bool:"},
    			 {"VariantPointPrice" , "decimal:"},
    			 {"VariantVIPPrice" , "decimal:"},
    			 {"VariantVIPPoint" , "int:"},
    			 {"VariantStaffPrice" , "decimal:"},
    			 {"VariantStaffPoint" , "int:"},
    			 {"VariantBasicPrice" , "decimal:"},
            };
		}
		#endregion
	}
}
