﻿using System;
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
	/// This object represents the properties and methods of a Cheque_InDetail.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_InDetail 
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
		private int _inSummaryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int InSummaryID
		{
			[DebuggerStepThrough()]
			get { return this._inSummaryID; }
			set 
			{
				if (this._inSummaryID != value) 
				{
					this._inSummaryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("InSummaryID");
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
		private string _productName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProductName
		{
			[DebuggerStepThrough()]
			get { return this._productName; }
			set 
			{
				if (this._productName != value) 
				{
					this._productName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _modelNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ModelNumber
		{
			[DebuggerStepThrough()]
			get { return this._modelNumber; }
			set 
			{
				if (this._modelNumber != value) 
				{
					this._modelNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModelNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _unit = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Unit
		{
			[DebuggerStepThrough()]
			get { return this._unit; }
			set 
			{
				if (this._unit != value) 
				{
					this._unit = value;
					this.IsDirty = true;	
					OnPropertyChanged("Unit");
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
		private int _totalCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TotalCount
		{
			[DebuggerStepThrough()]
			get { return this._totalCount; }
			set 
			{
				if (this._totalCount != value) 
				{
					this._totalCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalCost
		{
			[DebuggerStepThrough()]
			get { return this._totalCost; }
			set 
			{
				if (this._totalCost != value) 
				{
					this._totalCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _taxRate = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TaxRate
		{
			[DebuggerStepThrough()]
			get { return this._taxRate; }
			set 
			{
				if (this._taxRate != value) 
				{
					this._taxRate = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaxRate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalTaxCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalTaxCost
		{
			[DebuggerStepThrough()]
			get { return this._totalTaxCost; }
			set 
			{
				if (this._totalTaxCost != value) 
				{
					this._totalTaxCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalTaxCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalSummaryCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalSummaryCost
		{
			[DebuggerStepThrough()]
			get { return this._totalSummaryCost; }
			set 
			{
				if (this._totalSummaryCost != value) 
				{
					this._totalSummaryCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalSummaryCost");
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
	[InSummaryID] int,
	[ProductID] int,
	[ProductName] nvarchar(200),
	[ModelNumber] nvarchar(200),
	[Unit] nvarchar(200),
	[UnitPrice] decimal(18, 2),
	[TotalCount] int,
	[TotalCost] decimal(18, 2),
	[TaxRate] nvarchar(50),
	[TotalTaxCost] decimal(18, 2),
	[TotalSummaryCost] decimal(18, 2),
	[GUID] nvarchar(200)
);

INSERT INTO [dbo].[Cheque_InDetail] (
	[Cheque_InDetail].[InSummaryID],
	[Cheque_InDetail].[ProductID],
	[Cheque_InDetail].[ProductName],
	[Cheque_InDetail].[ModelNumber],
	[Cheque_InDetail].[Unit],
	[Cheque_InDetail].[UnitPrice],
	[Cheque_InDetail].[TotalCount],
	[Cheque_InDetail].[TotalCost],
	[Cheque_InDetail].[TaxRate],
	[Cheque_InDetail].[TotalTaxCost],
	[Cheque_InDetail].[TotalSummaryCost],
	[Cheque_InDetail].[GUID]
) 
output 
	INSERTED.[ID],
	INSERTED.[InSummaryID],
	INSERTED.[ProductID],
	INSERTED.[ProductName],
	INSERTED.[ModelNumber],
	INSERTED.[Unit],
	INSERTED.[UnitPrice],
	INSERTED.[TotalCount],
	INSERTED.[TotalCost],
	INSERTED.[TaxRate],
	INSERTED.[TotalTaxCost],
	INSERTED.[TotalSummaryCost],
	INSERTED.[GUID]
into @table
VALUES ( 
	@InSummaryID,
	@ProductID,
	@ProductName,
	@ModelNumber,
	@Unit,
	@UnitPrice,
	@TotalCount,
	@TotalCost,
	@TaxRate,
	@TotalTaxCost,
	@TotalSummaryCost,
	@GUID 
); 

SELECT 
	[ID],
	[InSummaryID],
	[ProductID],
	[ProductName],
	[ModelNumber],
	[Unit],
	[UnitPrice],
	[TotalCount],
	[TotalCost],
	[TaxRate],
	[TotalTaxCost],
	[TotalSummaryCost],
	[GUID] 
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
	[InSummaryID] int,
	[ProductID] int,
	[ProductName] nvarchar(200),
	[ModelNumber] nvarchar(200),
	[Unit] nvarchar(200),
	[UnitPrice] decimal(18, 2),
	[TotalCount] int,
	[TotalCost] decimal(18, 2),
	[TaxRate] nvarchar(50),
	[TotalTaxCost] decimal(18, 2),
	[TotalSummaryCost] decimal(18, 2),
	[GUID] nvarchar(200)
);

UPDATE [dbo].[Cheque_InDetail] SET 
	[Cheque_InDetail].[InSummaryID] = @InSummaryID,
	[Cheque_InDetail].[ProductID] = @ProductID,
	[Cheque_InDetail].[ProductName] = @ProductName,
	[Cheque_InDetail].[ModelNumber] = @ModelNumber,
	[Cheque_InDetail].[Unit] = @Unit,
	[Cheque_InDetail].[UnitPrice] = @UnitPrice,
	[Cheque_InDetail].[TotalCount] = @TotalCount,
	[Cheque_InDetail].[TotalCost] = @TotalCost,
	[Cheque_InDetail].[TaxRate] = @TaxRate,
	[Cheque_InDetail].[TotalTaxCost] = @TotalTaxCost,
	[Cheque_InDetail].[TotalSummaryCost] = @TotalSummaryCost,
	[Cheque_InDetail].[GUID] = @GUID 
output 
	INSERTED.[ID],
	INSERTED.[InSummaryID],
	INSERTED.[ProductID],
	INSERTED.[ProductName],
	INSERTED.[ModelNumber],
	INSERTED.[Unit],
	INSERTED.[UnitPrice],
	INSERTED.[TotalCount],
	INSERTED.[TotalCost],
	INSERTED.[TaxRate],
	INSERTED.[TotalTaxCost],
	INSERTED.[TotalSummaryCost],
	INSERTED.[GUID]
into @table
WHERE 
	[Cheque_InDetail].[ID] = @ID

SELECT 
	[ID],
	[InSummaryID],
	[ProductID],
	[ProductName],
	[ModelNumber],
	[Unit],
	[UnitPrice],
	[TotalCount],
	[TotalCost],
	[TaxRate],
	[TotalTaxCost],
	[TotalSummaryCost],
	[GUID] 
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
DELETE FROM [dbo].[Cheque_InDetail]
WHERE 
	[Cheque_InDetail].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_InDetail() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_InDetail(this.ID));
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
	[Cheque_InDetail].[ID],
	[Cheque_InDetail].[InSummaryID],
	[Cheque_InDetail].[ProductID],
	[Cheque_InDetail].[ProductName],
	[Cheque_InDetail].[ModelNumber],
	[Cheque_InDetail].[Unit],
	[Cheque_InDetail].[UnitPrice],
	[Cheque_InDetail].[TotalCount],
	[Cheque_InDetail].[TotalCost],
	[Cheque_InDetail].[TaxRate],
	[Cheque_InDetail].[TotalTaxCost],
	[Cheque_InDetail].[TotalSummaryCost],
	[Cheque_InDetail].[GUID]
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
                return "Cheque_InDetail";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_InDetail into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="inSummaryID">inSummaryID</param>
		/// <param name="productID">productID</param>
		/// <param name="productName">productName</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="unit">unit</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="taxRate">taxRate</param>
		/// <param name="totalTaxCost">totalTaxCost</param>
		/// <param name="totalSummaryCost">totalSummaryCost</param>
		/// <param name="gUID">gUID</param>
		public static void InsertCheque_InDetail(int @inSummaryID, int @productID, string @productName, string @modelNumber, string @unit, decimal @unitPrice, int @totalCount, decimal @totalCost, string @taxRate, decimal @totalTaxCost, decimal @totalSummaryCost, string @gUID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_InDetail(@inSummaryID, @productID, @productName, @modelNumber, @unit, @unitPrice, @totalCount, @totalCost, @taxRate, @totalTaxCost, @totalSummaryCost, @gUID, helper);
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
		/// Insert a Cheque_InDetail into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="inSummaryID">inSummaryID</param>
		/// <param name="productID">productID</param>
		/// <param name="productName">productName</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="unit">unit</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="taxRate">taxRate</param>
		/// <param name="totalTaxCost">totalTaxCost</param>
		/// <param name="totalSummaryCost">totalSummaryCost</param>
		/// <param name="gUID">gUID</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_InDetail(int @inSummaryID, int @productID, string @productName, string @modelNumber, string @unit, decimal @unitPrice, int @totalCount, decimal @totalCost, string @taxRate, decimal @totalTaxCost, decimal @totalSummaryCost, string @gUID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[InSummaryID] int,
	[ProductID] int,
	[ProductName] nvarchar(200),
	[ModelNumber] nvarchar(200),
	[Unit] nvarchar(200),
	[UnitPrice] decimal(18, 2),
	[TotalCount] int,
	[TotalCost] decimal(18, 2),
	[TaxRate] nvarchar(50),
	[TotalTaxCost] decimal(18, 2),
	[TotalSummaryCost] decimal(18, 2),
	[GUID] nvarchar(200)
);

INSERT INTO [dbo].[Cheque_InDetail] (
	[Cheque_InDetail].[InSummaryID],
	[Cheque_InDetail].[ProductID],
	[Cheque_InDetail].[ProductName],
	[Cheque_InDetail].[ModelNumber],
	[Cheque_InDetail].[Unit],
	[Cheque_InDetail].[UnitPrice],
	[Cheque_InDetail].[TotalCount],
	[Cheque_InDetail].[TotalCost],
	[Cheque_InDetail].[TaxRate],
	[Cheque_InDetail].[TotalTaxCost],
	[Cheque_InDetail].[TotalSummaryCost],
	[Cheque_InDetail].[GUID]
) 
output 
	INSERTED.[ID],
	INSERTED.[InSummaryID],
	INSERTED.[ProductID],
	INSERTED.[ProductName],
	INSERTED.[ModelNumber],
	INSERTED.[Unit],
	INSERTED.[UnitPrice],
	INSERTED.[TotalCount],
	INSERTED.[TotalCost],
	INSERTED.[TaxRate],
	INSERTED.[TotalTaxCost],
	INSERTED.[TotalSummaryCost],
	INSERTED.[GUID]
into @table
VALUES ( 
	@InSummaryID,
	@ProductID,
	@ProductName,
	@ModelNumber,
	@Unit,
	@UnitPrice,
	@TotalCount,
	@TotalCost,
	@TaxRate,
	@TotalTaxCost,
	@TotalSummaryCost,
	@GUID 
); 

SELECT 
	[ID],
	[InSummaryID],
	[ProductID],
	[ProductName],
	[ModelNumber],
	[Unit],
	[UnitPrice],
	[TotalCount],
	[TotalCost],
	[TaxRate],
	[TotalTaxCost],
	[TotalSummaryCost],
	[GUID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@InSummaryID", EntityBase.GetDatabaseValue(@inSummaryID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@ProductName", EntityBase.GetDatabaseValue(@productName)));
			parameters.Add(new SqlParameter("@ModelNumber", EntityBase.GetDatabaseValue(@modelNumber)));
			parameters.Add(new SqlParameter("@Unit", EntityBase.GetDatabaseValue(@unit)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@TotalCount", EntityBase.GetDatabaseValue(@totalCount)));
			parameters.Add(new SqlParameter("@TotalCost", EntityBase.GetDatabaseValue(@totalCost)));
			parameters.Add(new SqlParameter("@TaxRate", EntityBase.GetDatabaseValue(@taxRate)));
			parameters.Add(new SqlParameter("@TotalTaxCost", EntityBase.GetDatabaseValue(@totalTaxCost)));
			parameters.Add(new SqlParameter("@TotalSummaryCost", EntityBase.GetDatabaseValue(@totalSummaryCost)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_InDetail into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="inSummaryID">inSummaryID</param>
		/// <param name="productID">productID</param>
		/// <param name="productName">productName</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="unit">unit</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="taxRate">taxRate</param>
		/// <param name="totalTaxCost">totalTaxCost</param>
		/// <param name="totalSummaryCost">totalSummaryCost</param>
		/// <param name="gUID">gUID</param>
		public static void UpdateCheque_InDetail(int @iD, int @inSummaryID, int @productID, string @productName, string @modelNumber, string @unit, decimal @unitPrice, int @totalCount, decimal @totalCost, string @taxRate, decimal @totalTaxCost, decimal @totalSummaryCost, string @gUID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_InDetail(@iD, @inSummaryID, @productID, @productName, @modelNumber, @unit, @unitPrice, @totalCount, @totalCost, @taxRate, @totalTaxCost, @totalSummaryCost, @gUID, helper);
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
		/// Updates a Cheque_InDetail into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="inSummaryID">inSummaryID</param>
		/// <param name="productID">productID</param>
		/// <param name="productName">productName</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="unit">unit</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="taxRate">taxRate</param>
		/// <param name="totalTaxCost">totalTaxCost</param>
		/// <param name="totalSummaryCost">totalSummaryCost</param>
		/// <param name="gUID">gUID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_InDetail(int @iD, int @inSummaryID, int @productID, string @productName, string @modelNumber, string @unit, decimal @unitPrice, int @totalCount, decimal @totalCost, string @taxRate, decimal @totalTaxCost, decimal @totalSummaryCost, string @gUID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[InSummaryID] int,
	[ProductID] int,
	[ProductName] nvarchar(200),
	[ModelNumber] nvarchar(200),
	[Unit] nvarchar(200),
	[UnitPrice] decimal(18, 2),
	[TotalCount] int,
	[TotalCost] decimal(18, 2),
	[TaxRate] nvarchar(50),
	[TotalTaxCost] decimal(18, 2),
	[TotalSummaryCost] decimal(18, 2),
	[GUID] nvarchar(200)
);

UPDATE [dbo].[Cheque_InDetail] SET 
	[Cheque_InDetail].[InSummaryID] = @InSummaryID,
	[Cheque_InDetail].[ProductID] = @ProductID,
	[Cheque_InDetail].[ProductName] = @ProductName,
	[Cheque_InDetail].[ModelNumber] = @ModelNumber,
	[Cheque_InDetail].[Unit] = @Unit,
	[Cheque_InDetail].[UnitPrice] = @UnitPrice,
	[Cheque_InDetail].[TotalCount] = @TotalCount,
	[Cheque_InDetail].[TotalCost] = @TotalCost,
	[Cheque_InDetail].[TaxRate] = @TaxRate,
	[Cheque_InDetail].[TotalTaxCost] = @TotalTaxCost,
	[Cheque_InDetail].[TotalSummaryCost] = @TotalSummaryCost,
	[Cheque_InDetail].[GUID] = @GUID 
output 
	INSERTED.[ID],
	INSERTED.[InSummaryID],
	INSERTED.[ProductID],
	INSERTED.[ProductName],
	INSERTED.[ModelNumber],
	INSERTED.[Unit],
	INSERTED.[UnitPrice],
	INSERTED.[TotalCount],
	INSERTED.[TotalCost],
	INSERTED.[TaxRate],
	INSERTED.[TotalTaxCost],
	INSERTED.[TotalSummaryCost],
	INSERTED.[GUID]
into @table
WHERE 
	[Cheque_InDetail].[ID] = @ID

SELECT 
	[ID],
	[InSummaryID],
	[ProductID],
	[ProductName],
	[ModelNumber],
	[Unit],
	[UnitPrice],
	[TotalCount],
	[TotalCost],
	[TaxRate],
	[TotalTaxCost],
	[TotalSummaryCost],
	[GUID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@InSummaryID", EntityBase.GetDatabaseValue(@inSummaryID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@ProductName", EntityBase.GetDatabaseValue(@productName)));
			parameters.Add(new SqlParameter("@ModelNumber", EntityBase.GetDatabaseValue(@modelNumber)));
			parameters.Add(new SqlParameter("@Unit", EntityBase.GetDatabaseValue(@unit)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@TotalCount", EntityBase.GetDatabaseValue(@totalCount)));
			parameters.Add(new SqlParameter("@TotalCost", EntityBase.GetDatabaseValue(@totalCost)));
			parameters.Add(new SqlParameter("@TaxRate", EntityBase.GetDatabaseValue(@taxRate)));
			parameters.Add(new SqlParameter("@TotalTaxCost", EntityBase.GetDatabaseValue(@totalTaxCost)));
			parameters.Add(new SqlParameter("@TotalSummaryCost", EntityBase.GetDatabaseValue(@totalSummaryCost)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_InDetail from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_InDetail(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_InDetail(@iD, helper);
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
		/// Deletes a Cheque_InDetail from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_InDetail(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_InDetail]
WHERE 
	[Cheque_InDetail].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_InDetail object.
		/// </summary>
		/// <returns>The newly created Cheque_InDetail object.</returns>
		public static Cheque_InDetail CreateCheque_InDetail()
		{
			return InitializeNew<Cheque_InDetail>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_InDetail by a Cheque_InDetail's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_InDetail</returns>
		public static Cheque_InDetail GetCheque_InDetail(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_InDetail.SelectFieldList + @"
FROM [dbo].[Cheque_InDetail] 
WHERE 
	[Cheque_InDetail].[ID] = @ID " + Cheque_InDetail.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_InDetail>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_InDetail by a Cheque_InDetail's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_InDetail</returns>
		public static Cheque_InDetail GetCheque_InDetail(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_InDetail.SelectFieldList + @"
FROM [dbo].[Cheque_InDetail] 
WHERE 
	[Cheque_InDetail].[ID] = @ID " + Cheque_InDetail.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_InDetail>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_InDetail objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_InDetail objects.</returns>
		public static EntityList<Cheque_InDetail> GetCheque_InDetails()
		{
			string commandText = @"
SELECT " + Cheque_InDetail.SelectFieldList + "FROM [dbo].[Cheque_InDetail] " + Cheque_InDetail.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_InDetail>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_InDetail objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_InDetail objects.</returns>
        public static EntityList<Cheque_InDetail> GetCheque_InDetails(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_InDetail>(SelectFieldList, "FROM [dbo].[Cheque_InDetail]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_InDetail objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_InDetail objects.</returns>
        public static EntityList<Cheque_InDetail> GetCheque_InDetails(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_InDetail>(SelectFieldList, "FROM [dbo].[Cheque_InDetail]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_InDetail objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_InDetail objects.</returns>
		protected static EntityList<Cheque_InDetail> GetCheque_InDetails(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_InDetails(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_InDetail objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_InDetail objects.</returns>
		protected static EntityList<Cheque_InDetail> GetCheque_InDetails(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_InDetails(string.Empty, where, parameters, Cheque_InDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_InDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_InDetail objects.</returns>
		protected static EntityList<Cheque_InDetail> GetCheque_InDetails(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_InDetails(prefix, where, parameters, Cheque_InDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_InDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_InDetail objects.</returns>
		protected static EntityList<Cheque_InDetail> GetCheque_InDetails(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_InDetails(string.Empty, where, parameters, Cheque_InDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_InDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_InDetail objects.</returns>
		protected static EntityList<Cheque_InDetail> GetCheque_InDetails(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_InDetails(prefix, where, parameters, Cheque_InDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_InDetail objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_InDetail objects.</returns>
		protected static EntityList<Cheque_InDetail> GetCheque_InDetails(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_InDetail.SelectFieldList + "FROM [dbo].[Cheque_InDetail] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_InDetail>(reader);
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
        protected static EntityList<Cheque_InDetail> GetCheque_InDetails(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_InDetail>(SelectFieldList, "FROM [dbo].[Cheque_InDetail] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_InDetail objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_InDetailCount()
        {
            return GetCheque_InDetailCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_InDetail objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_InDetailCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_InDetail] " + where;

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
		public static partial class Cheque_InDetail_Properties
		{
			public const string ID = "ID";
			public const string InSummaryID = "InSummaryID";
			public const string ProductID = "ProductID";
			public const string ProductName = "ProductName";
			public const string ModelNumber = "ModelNumber";
			public const string Unit = "Unit";
			public const string UnitPrice = "UnitPrice";
			public const string TotalCount = "TotalCount";
			public const string TotalCost = "TotalCost";
			public const string TaxRate = "TaxRate";
			public const string TotalTaxCost = "TotalTaxCost";
			public const string TotalSummaryCost = "TotalSummaryCost";
			public const string GUID = "GUID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"InSummaryID" , "int:"},
    			 {"ProductID" , "int:"},
    			 {"ProductName" , "string:"},
    			 {"ModelNumber" , "string:"},
    			 {"Unit" , "string:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"TotalCount" , "int:"},
    			 {"TotalCost" , "decimal:"},
    			 {"TaxRate" , "string:"},
    			 {"TotalTaxCost" , "decimal:"},
    			 {"TotalSummaryCost" , "decimal:"},
    			 {"GUID" , "string:"},
            };
		}
		#endregion
	}
}
