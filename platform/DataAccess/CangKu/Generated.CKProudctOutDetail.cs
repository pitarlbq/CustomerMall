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
	/// This object represents the properties and methods of a CKProudctOutDetail.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CKProudctOutDetail 
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
		private int _outSummaryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int OutSummaryID
		{
			[DebuggerStepThrough()]
			get { return this._outSummaryID; }
			set 
			{
				if (this._outSummaryID != value) 
				{
					this._outSummaryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OutSummaryID");
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
			set 
			{
				if (this._unitPrice != value) 
				{
					this._unitPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("UnitPrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _outTotalCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OutTotalCount
		{
			[DebuggerStepThrough()]
			get { return this._outTotalCount; }
			set 
			{
				if (this._outTotalCount != value) 
				{
					this._outTotalCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("OutTotalCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _outTotalPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal OutTotalPrice
		{
			[DebuggerStepThrough()]
			get { return this._outTotalPrice; }
			set 
			{
				if (this._outTotalPrice != value) 
				{
					this._outTotalPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("OutTotalPrice");
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
		private decimal _inBasicUnitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal InBasicUnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._inBasicUnitPrice; }
			set 
			{
				if (this._inBasicUnitPrice != value) 
				{
					this._inBasicUnitPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("InBasicUnitPrice");
				}
			}
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
			set 
			{
				if (this._remark != value) 
				{
					this._remark = value;
					this.IsDirty = true;	
					OnPropertyChanged("Remark");
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
	[OutSummaryID] int,
	[ProductID] int,
	[UnitPrice] decimal(18, 2),
	[OutTotalCount] int,
	[OutTotalPrice] decimal(18, 2),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[InBasicUnitPrice] decimal(18, 2),
	[Remark] ntext
);

INSERT INTO [dbo].[CKProudctOutDetail] (
	[CKProudctOutDetail].[OutSummaryID],
	[CKProudctOutDetail].[ProductID],
	[CKProudctOutDetail].[UnitPrice],
	[CKProudctOutDetail].[OutTotalCount],
	[CKProudctOutDetail].[OutTotalPrice],
	[CKProudctOutDetail].[AddTime],
	[CKProudctOutDetail].[AddMan],
	[CKProudctOutDetail].[InBasicUnitPrice],
	[CKProudctOutDetail].[Remark]
) 
output 
	INSERTED.[ID],
	INSERTED.[OutSummaryID],
	INSERTED.[ProductID],
	INSERTED.[UnitPrice],
	INSERTED.[OutTotalCount],
	INSERTED.[OutTotalPrice],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[InBasicUnitPrice],
	INSERTED.[Remark]
into @table
VALUES ( 
	@OutSummaryID,
	@ProductID,
	@UnitPrice,
	@OutTotalCount,
	@OutTotalPrice,
	@AddTime,
	@AddMan,
	@InBasicUnitPrice,
	@Remark 
); 

SELECT 
	[ID],
	[OutSummaryID],
	[ProductID],
	[UnitPrice],
	[OutTotalCount],
	[OutTotalPrice],
	[AddTime],
	[AddMan],
	[InBasicUnitPrice],
	[Remark] 
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
	[OutSummaryID] int,
	[ProductID] int,
	[UnitPrice] decimal(18, 2),
	[OutTotalCount] int,
	[OutTotalPrice] decimal(18, 2),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[InBasicUnitPrice] decimal(18, 2),
	[Remark] ntext
);

UPDATE [dbo].[CKProudctOutDetail] SET 
	[CKProudctOutDetail].[OutSummaryID] = @OutSummaryID,
	[CKProudctOutDetail].[ProductID] = @ProductID,
	[CKProudctOutDetail].[UnitPrice] = @UnitPrice,
	[CKProudctOutDetail].[OutTotalCount] = @OutTotalCount,
	[CKProudctOutDetail].[OutTotalPrice] = @OutTotalPrice,
	[CKProudctOutDetail].[AddTime] = @AddTime,
	[CKProudctOutDetail].[AddMan] = @AddMan,
	[CKProudctOutDetail].[InBasicUnitPrice] = @InBasicUnitPrice,
	[CKProudctOutDetail].[Remark] = @Remark 
output 
	INSERTED.[ID],
	INSERTED.[OutSummaryID],
	INSERTED.[ProductID],
	INSERTED.[UnitPrice],
	INSERTED.[OutTotalCount],
	INSERTED.[OutTotalPrice],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[InBasicUnitPrice],
	INSERTED.[Remark]
into @table
WHERE 
	[CKProudctOutDetail].[ID] = @ID

SELECT 
	[ID],
	[OutSummaryID],
	[ProductID],
	[UnitPrice],
	[OutTotalCount],
	[OutTotalPrice],
	[AddTime],
	[AddMan],
	[InBasicUnitPrice],
	[Remark] 
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
DELETE FROM [dbo].[CKProudctOutDetail]
WHERE 
	[CKProudctOutDetail].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CKProudctOutDetail() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCKProudctOutDetail(this.ID));
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
	[CKProudctOutDetail].[ID],
	[CKProudctOutDetail].[OutSummaryID],
	[CKProudctOutDetail].[ProductID],
	[CKProudctOutDetail].[UnitPrice],
	[CKProudctOutDetail].[OutTotalCount],
	[CKProudctOutDetail].[OutTotalPrice],
	[CKProudctOutDetail].[AddTime],
	[CKProudctOutDetail].[AddMan],
	[CKProudctOutDetail].[InBasicUnitPrice],
	[CKProudctOutDetail].[Remark]
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
                return "CKProudctOutDetail";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CKProudctOutDetail into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="outSummaryID">outSummaryID</param>
		/// <param name="productID">productID</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="outTotalCount">outTotalCount</param>
		/// <param name="outTotalPrice">outTotalPrice</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="inBasicUnitPrice">inBasicUnitPrice</param>
		/// <param name="remark">remark</param>
		public static void InsertCKProudctOutDetail(int @outSummaryID, int @productID, decimal @unitPrice, int @outTotalCount, decimal @outTotalPrice, DateTime @addTime, string @addMan, decimal @inBasicUnitPrice, string @remark)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCKProudctOutDetail(@outSummaryID, @productID, @unitPrice, @outTotalCount, @outTotalPrice, @addTime, @addMan, @inBasicUnitPrice, @remark, helper);
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
		/// Insert a CKProudctOutDetail into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="outSummaryID">outSummaryID</param>
		/// <param name="productID">productID</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="outTotalCount">outTotalCount</param>
		/// <param name="outTotalPrice">outTotalPrice</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="inBasicUnitPrice">inBasicUnitPrice</param>
		/// <param name="remark">remark</param>
		/// <param name="helper">helper</param>
		internal static void InsertCKProudctOutDetail(int @outSummaryID, int @productID, decimal @unitPrice, int @outTotalCount, decimal @outTotalPrice, DateTime @addTime, string @addMan, decimal @inBasicUnitPrice, string @remark, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OutSummaryID] int,
	[ProductID] int,
	[UnitPrice] decimal(18, 2),
	[OutTotalCount] int,
	[OutTotalPrice] decimal(18, 2),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[InBasicUnitPrice] decimal(18, 2),
	[Remark] ntext
);

INSERT INTO [dbo].[CKProudctOutDetail] (
	[CKProudctOutDetail].[OutSummaryID],
	[CKProudctOutDetail].[ProductID],
	[CKProudctOutDetail].[UnitPrice],
	[CKProudctOutDetail].[OutTotalCount],
	[CKProudctOutDetail].[OutTotalPrice],
	[CKProudctOutDetail].[AddTime],
	[CKProudctOutDetail].[AddMan],
	[CKProudctOutDetail].[InBasicUnitPrice],
	[CKProudctOutDetail].[Remark]
) 
output 
	INSERTED.[ID],
	INSERTED.[OutSummaryID],
	INSERTED.[ProductID],
	INSERTED.[UnitPrice],
	INSERTED.[OutTotalCount],
	INSERTED.[OutTotalPrice],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[InBasicUnitPrice],
	INSERTED.[Remark]
into @table
VALUES ( 
	@OutSummaryID,
	@ProductID,
	@UnitPrice,
	@OutTotalCount,
	@OutTotalPrice,
	@AddTime,
	@AddMan,
	@InBasicUnitPrice,
	@Remark 
); 

SELECT 
	[ID],
	[OutSummaryID],
	[ProductID],
	[UnitPrice],
	[OutTotalCount],
	[OutTotalPrice],
	[AddTime],
	[AddMan],
	[InBasicUnitPrice],
	[Remark] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OutSummaryID", EntityBase.GetDatabaseValue(@outSummaryID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@OutTotalCount", EntityBase.GetDatabaseValue(@outTotalCount)));
			parameters.Add(new SqlParameter("@OutTotalPrice", EntityBase.GetDatabaseValue(@outTotalPrice)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@InBasicUnitPrice", EntityBase.GetDatabaseValue(@inBasicUnitPrice)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CKProudctOutDetail into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="outSummaryID">outSummaryID</param>
		/// <param name="productID">productID</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="outTotalCount">outTotalCount</param>
		/// <param name="outTotalPrice">outTotalPrice</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="inBasicUnitPrice">inBasicUnitPrice</param>
		/// <param name="remark">remark</param>
		public static void UpdateCKProudctOutDetail(int @iD, int @outSummaryID, int @productID, decimal @unitPrice, int @outTotalCount, decimal @outTotalPrice, DateTime @addTime, string @addMan, decimal @inBasicUnitPrice, string @remark)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCKProudctOutDetail(@iD, @outSummaryID, @productID, @unitPrice, @outTotalCount, @outTotalPrice, @addTime, @addMan, @inBasicUnitPrice, @remark, helper);
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
		/// Updates a CKProudctOutDetail into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="outSummaryID">outSummaryID</param>
		/// <param name="productID">productID</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="outTotalCount">outTotalCount</param>
		/// <param name="outTotalPrice">outTotalPrice</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="inBasicUnitPrice">inBasicUnitPrice</param>
		/// <param name="remark">remark</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCKProudctOutDetail(int @iD, int @outSummaryID, int @productID, decimal @unitPrice, int @outTotalCount, decimal @outTotalPrice, DateTime @addTime, string @addMan, decimal @inBasicUnitPrice, string @remark, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OutSummaryID] int,
	[ProductID] int,
	[UnitPrice] decimal(18, 2),
	[OutTotalCount] int,
	[OutTotalPrice] decimal(18, 2),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[InBasicUnitPrice] decimal(18, 2),
	[Remark] ntext
);

UPDATE [dbo].[CKProudctOutDetail] SET 
	[CKProudctOutDetail].[OutSummaryID] = @OutSummaryID,
	[CKProudctOutDetail].[ProductID] = @ProductID,
	[CKProudctOutDetail].[UnitPrice] = @UnitPrice,
	[CKProudctOutDetail].[OutTotalCount] = @OutTotalCount,
	[CKProudctOutDetail].[OutTotalPrice] = @OutTotalPrice,
	[CKProudctOutDetail].[AddTime] = @AddTime,
	[CKProudctOutDetail].[AddMan] = @AddMan,
	[CKProudctOutDetail].[InBasicUnitPrice] = @InBasicUnitPrice,
	[CKProudctOutDetail].[Remark] = @Remark 
output 
	INSERTED.[ID],
	INSERTED.[OutSummaryID],
	INSERTED.[ProductID],
	INSERTED.[UnitPrice],
	INSERTED.[OutTotalCount],
	INSERTED.[OutTotalPrice],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[InBasicUnitPrice],
	INSERTED.[Remark]
into @table
WHERE 
	[CKProudctOutDetail].[ID] = @ID

SELECT 
	[ID],
	[OutSummaryID],
	[ProductID],
	[UnitPrice],
	[OutTotalCount],
	[OutTotalPrice],
	[AddTime],
	[AddMan],
	[InBasicUnitPrice],
	[Remark] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OutSummaryID", EntityBase.GetDatabaseValue(@outSummaryID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@OutTotalCount", EntityBase.GetDatabaseValue(@outTotalCount)));
			parameters.Add(new SqlParameter("@OutTotalPrice", EntityBase.GetDatabaseValue(@outTotalPrice)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@InBasicUnitPrice", EntityBase.GetDatabaseValue(@inBasicUnitPrice)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CKProudctOutDetail from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCKProudctOutDetail(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCKProudctOutDetail(@iD, helper);
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
		/// Deletes a CKProudctOutDetail from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCKProudctOutDetail(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CKProudctOutDetail]
WHERE 
	[CKProudctOutDetail].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CKProudctOutDetail object.
		/// </summary>
		/// <returns>The newly created CKProudctOutDetail object.</returns>
		public static CKProudctOutDetail CreateCKProudctOutDetail()
		{
			return InitializeNew<CKProudctOutDetail>();
		}
		
		/// <summary>
		/// Retrieve information for a CKProudctOutDetail by a CKProudctOutDetail's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CKProudctOutDetail</returns>
		public static CKProudctOutDetail GetCKProudctOutDetail(int @iD)
		{
			string commandText = @"
SELECT 
" + CKProudctOutDetail.SelectFieldList + @"
FROM [dbo].[CKProudctOutDetail] 
WHERE 
	[CKProudctOutDetail].[ID] = @ID " + CKProudctOutDetail.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKProudctOutDetail>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CKProudctOutDetail by a CKProudctOutDetail's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CKProudctOutDetail</returns>
		public static CKProudctOutDetail GetCKProudctOutDetail(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CKProudctOutDetail.SelectFieldList + @"
FROM [dbo].[CKProudctOutDetail] 
WHERE 
	[CKProudctOutDetail].[ID] = @ID " + CKProudctOutDetail.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKProudctOutDetail>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CKProudctOutDetail objects.
		/// </summary>
		/// <returns>The retrieved collection of CKProudctOutDetail objects.</returns>
		public static EntityList<CKProudctOutDetail> GetCKProudctOutDetails()
		{
			string commandText = @"
SELECT " + CKProudctOutDetail.SelectFieldList + "FROM [dbo].[CKProudctOutDetail] " + CKProudctOutDetail.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CKProudctOutDetail>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CKProudctOutDetail objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKProudctOutDetail objects.</returns>
        public static EntityList<CKProudctOutDetail> GetCKProudctOutDetails(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKProudctOutDetail>(SelectFieldList, "FROM [dbo].[CKProudctOutDetail]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CKProudctOutDetail objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKProudctOutDetail objects.</returns>
        public static EntityList<CKProudctOutDetail> GetCKProudctOutDetails(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKProudctOutDetail>(SelectFieldList, "FROM [dbo].[CKProudctOutDetail]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CKProudctOutDetail objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CKProudctOutDetail objects.</returns>
		protected static EntityList<CKProudctOutDetail> GetCKProudctOutDetails(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKProudctOutDetails(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CKProudctOutDetail objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKProudctOutDetail objects.</returns>
		protected static EntityList<CKProudctOutDetail> GetCKProudctOutDetails(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKProudctOutDetails(string.Empty, where, parameters, CKProudctOutDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProudctOutDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKProudctOutDetail objects.</returns>
		protected static EntityList<CKProudctOutDetail> GetCKProudctOutDetails(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKProudctOutDetails(prefix, where, parameters, CKProudctOutDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProudctOutDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKProudctOutDetail objects.</returns>
		protected static EntityList<CKProudctOutDetail> GetCKProudctOutDetails(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKProudctOutDetails(string.Empty, where, parameters, CKProudctOutDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProudctOutDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKProudctOutDetail objects.</returns>
		protected static EntityList<CKProudctOutDetail> GetCKProudctOutDetails(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKProudctOutDetails(prefix, where, parameters, CKProudctOutDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProudctOutDetail objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CKProudctOutDetail objects.</returns>
		protected static EntityList<CKProudctOutDetail> GetCKProudctOutDetails(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CKProudctOutDetail.SelectFieldList + "FROM [dbo].[CKProudctOutDetail] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CKProudctOutDetail>(reader);
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
        protected static EntityList<CKProudctOutDetail> GetCKProudctOutDetails(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKProudctOutDetail>(SelectFieldList, "FROM [dbo].[CKProudctOutDetail] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CKProudctOutDetail objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKProudctOutDetailCount()
        {
            return GetCKProudctOutDetailCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CKProudctOutDetail objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKProudctOutDetailCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CKProudctOutDetail] " + where;

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
		public static partial class CKProudctOutDetail_Properties
		{
			public const string ID = "ID";
			public const string OutSummaryID = "OutSummaryID";
			public const string ProductID = "ProductID";
			public const string UnitPrice = "UnitPrice";
			public const string OutTotalCount = "OutTotalCount";
			public const string OutTotalPrice = "OutTotalPrice";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string InBasicUnitPrice = "InBasicUnitPrice";
			public const string Remark = "Remark";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OutSummaryID" , "int:"},
    			 {"ProductID" , "int:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"OutTotalCount" , "int:"},
    			 {"OutTotalPrice" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"InBasicUnitPrice" , "decimal:"},
    			 {"Remark" , "string:"},
            };
		}
		#endregion
	}
}
