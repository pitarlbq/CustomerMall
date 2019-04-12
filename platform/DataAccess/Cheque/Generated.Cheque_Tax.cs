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
	/// This object represents the properties and methods of a Cheque_Tax.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_Tax 
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
		private string _contractNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractNumber
		{
			[DebuggerStepThrough()]
			get { return this._contractNumber; }
			set 
			{
				if (this._contractNumber != value) 
				{
					this._contractNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _departmentID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int DepartmentID
		{
			[DebuggerStepThrough()]
			get { return this._departmentID; }
			set 
			{
				if (this._departmentID != value) 
				{
					this._departmentID = value;
					this.IsDirty = true;	
					OnPropertyChanged("DepartmentID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _contractCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ContractCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._contractCategoryID; }
			set 
			{
				if (this._contractCategoryID != value) 
				{
					this._contractCategoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractCategoryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _taxRateID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TaxRateID
		{
			[DebuggerStepThrough()]
			get { return this._taxRateID; }
			set 
			{
				if (this._taxRateID != value) 
				{
					this._taxRateID = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaxRateID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contractName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractName
		{
			[DebuggerStepThrough()]
			get { return this._contractName; }
			set 
			{
				if (this._contractName != value) 
				{
					this._contractName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractName");
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
		private string _currentDepartmentName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CurrentDepartmentName
		{
			[DebuggerStepThrough()]
			get { return this._currentDepartmentName; }
			set 
			{
				if (this._currentDepartmentName != value) 
				{
					this._currentDepartmentName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CurrentDepartmentName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _currentContractCategoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CurrentContractCategoryName
		{
			[DebuggerStepThrough()]
			get { return this._currentContractCategoryName; }
			set 
			{
				if (this._currentContractCategoryName != value) 
				{
					this._currentContractCategoryName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CurrentContractCategoryName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _currentTaxRateName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CurrentTaxRateName
		{
			[DebuggerStepThrough()]
			get { return this._currentTaxRateName; }
			set 
			{
				if (this._currentTaxRateName != value) 
				{
					this._currentTaxRateName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CurrentTaxRateName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _currentTaxRateValue = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CurrentTaxRateValue
		{
			[DebuggerStepThrough()]
			get { return this._currentTaxRateValue; }
			set 
			{
				if (this._currentTaxRateValue != value) 
				{
					this._currentTaxRateValue = value;
					this.IsDirty = true;	
					OnPropertyChanged("CurrentTaxRateValue");
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
	[ContractNumber] nvarchar(200),
	[DepartmentID] int,
	[ContractCategoryID] int,
	[TaxRateID] int,
	[ContractName] nvarchar(100),
	[UnitPrice] decimal(18, 2),
	[TotalCount] int,
	[TotalCost] decimal(18, 2),
	[TotalTaxCost] decimal(18, 2),
	[AddMan] nvarchar(100),
	[AddTime] datetime,
	[CurrentDepartmentName] nvarchar(200),
	[CurrentContractCategoryName] nvarchar(200),
	[CurrentTaxRateName] nvarchar(200),
	[CurrentTaxRateValue] nvarchar(100)
);

INSERT INTO [dbo].[Cheque_Tax] (
	[Cheque_Tax].[ContractNumber],
	[Cheque_Tax].[DepartmentID],
	[Cheque_Tax].[ContractCategoryID],
	[Cheque_Tax].[TaxRateID],
	[Cheque_Tax].[ContractName],
	[Cheque_Tax].[UnitPrice],
	[Cheque_Tax].[TotalCount],
	[Cheque_Tax].[TotalCost],
	[Cheque_Tax].[TotalTaxCost],
	[Cheque_Tax].[AddMan],
	[Cheque_Tax].[AddTime],
	[Cheque_Tax].[CurrentDepartmentName],
	[Cheque_Tax].[CurrentContractCategoryName],
	[Cheque_Tax].[CurrentTaxRateName],
	[Cheque_Tax].[CurrentTaxRateValue]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractNumber],
	INSERTED.[DepartmentID],
	INSERTED.[ContractCategoryID],
	INSERTED.[TaxRateID],
	INSERTED.[ContractName],
	INSERTED.[UnitPrice],
	INSERTED.[TotalCount],
	INSERTED.[TotalCost],
	INSERTED.[TotalTaxCost],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[CurrentDepartmentName],
	INSERTED.[CurrentContractCategoryName],
	INSERTED.[CurrentTaxRateName],
	INSERTED.[CurrentTaxRateValue]
into @table
VALUES ( 
	@ContractNumber,
	@DepartmentID,
	@ContractCategoryID,
	@TaxRateID,
	@ContractName,
	@UnitPrice,
	@TotalCount,
	@TotalCost,
	@TotalTaxCost,
	@AddMan,
	@AddTime,
	@CurrentDepartmentName,
	@CurrentContractCategoryName,
	@CurrentTaxRateName,
	@CurrentTaxRateValue 
); 

SELECT 
	[ID],
	[ContractNumber],
	[DepartmentID],
	[ContractCategoryID],
	[TaxRateID],
	[ContractName],
	[UnitPrice],
	[TotalCount],
	[TotalCost],
	[TotalTaxCost],
	[AddMan],
	[AddTime],
	[CurrentDepartmentName],
	[CurrentContractCategoryName],
	[CurrentTaxRateName],
	[CurrentTaxRateValue] 
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
	[ContractNumber] nvarchar(200),
	[DepartmentID] int,
	[ContractCategoryID] int,
	[TaxRateID] int,
	[ContractName] nvarchar(100),
	[UnitPrice] decimal(18, 2),
	[TotalCount] int,
	[TotalCost] decimal(18, 2),
	[TotalTaxCost] decimal(18, 2),
	[AddMan] nvarchar(100),
	[AddTime] datetime,
	[CurrentDepartmentName] nvarchar(200),
	[CurrentContractCategoryName] nvarchar(200),
	[CurrentTaxRateName] nvarchar(200),
	[CurrentTaxRateValue] nvarchar(100)
);

UPDATE [dbo].[Cheque_Tax] SET 
	[Cheque_Tax].[ContractNumber] = @ContractNumber,
	[Cheque_Tax].[DepartmentID] = @DepartmentID,
	[Cheque_Tax].[ContractCategoryID] = @ContractCategoryID,
	[Cheque_Tax].[TaxRateID] = @TaxRateID,
	[Cheque_Tax].[ContractName] = @ContractName,
	[Cheque_Tax].[UnitPrice] = @UnitPrice,
	[Cheque_Tax].[TotalCount] = @TotalCount,
	[Cheque_Tax].[TotalCost] = @TotalCost,
	[Cheque_Tax].[TotalTaxCost] = @TotalTaxCost,
	[Cheque_Tax].[AddMan] = @AddMan,
	[Cheque_Tax].[AddTime] = @AddTime,
	[Cheque_Tax].[CurrentDepartmentName] = @CurrentDepartmentName,
	[Cheque_Tax].[CurrentContractCategoryName] = @CurrentContractCategoryName,
	[Cheque_Tax].[CurrentTaxRateName] = @CurrentTaxRateName,
	[Cheque_Tax].[CurrentTaxRateValue] = @CurrentTaxRateValue 
output 
	INSERTED.[ID],
	INSERTED.[ContractNumber],
	INSERTED.[DepartmentID],
	INSERTED.[ContractCategoryID],
	INSERTED.[TaxRateID],
	INSERTED.[ContractName],
	INSERTED.[UnitPrice],
	INSERTED.[TotalCount],
	INSERTED.[TotalCost],
	INSERTED.[TotalTaxCost],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[CurrentDepartmentName],
	INSERTED.[CurrentContractCategoryName],
	INSERTED.[CurrentTaxRateName],
	INSERTED.[CurrentTaxRateValue]
into @table
WHERE 
	[Cheque_Tax].[ID] = @ID

SELECT 
	[ID],
	[ContractNumber],
	[DepartmentID],
	[ContractCategoryID],
	[TaxRateID],
	[ContractName],
	[UnitPrice],
	[TotalCount],
	[TotalCost],
	[TotalTaxCost],
	[AddMan],
	[AddTime],
	[CurrentDepartmentName],
	[CurrentContractCategoryName],
	[CurrentTaxRateName],
	[CurrentTaxRateValue] 
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
DELETE FROM [dbo].[Cheque_Tax]
WHERE 
	[Cheque_Tax].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_Tax() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_Tax(this.ID));
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
	[Cheque_Tax].[ID],
	[Cheque_Tax].[ContractNumber],
	[Cheque_Tax].[DepartmentID],
	[Cheque_Tax].[ContractCategoryID],
	[Cheque_Tax].[TaxRateID],
	[Cheque_Tax].[ContractName],
	[Cheque_Tax].[UnitPrice],
	[Cheque_Tax].[TotalCount],
	[Cheque_Tax].[TotalCost],
	[Cheque_Tax].[TotalTaxCost],
	[Cheque_Tax].[AddMan],
	[Cheque_Tax].[AddTime],
	[Cheque_Tax].[CurrentDepartmentName],
	[Cheque_Tax].[CurrentContractCategoryName],
	[Cheque_Tax].[CurrentTaxRateName],
	[Cheque_Tax].[CurrentTaxRateValue]
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
                return "Cheque_Tax";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_Tax into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractNumber">contractNumber</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="contractCategoryID">contractCategoryID</param>
		/// <param name="taxRateID">taxRateID</param>
		/// <param name="contractName">contractName</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="totalTaxCost">totalTaxCost</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="currentDepartmentName">currentDepartmentName</param>
		/// <param name="currentContractCategoryName">currentContractCategoryName</param>
		/// <param name="currentTaxRateName">currentTaxRateName</param>
		/// <param name="currentTaxRateValue">currentTaxRateValue</param>
		public static void InsertCheque_Tax(string @contractNumber, int @departmentID, int @contractCategoryID, int @taxRateID, string @contractName, decimal @unitPrice, int @totalCount, decimal @totalCost, decimal @totalTaxCost, string @addMan, DateTime @addTime, string @currentDepartmentName, string @currentContractCategoryName, string @currentTaxRateName, string @currentTaxRateValue)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_Tax(@contractNumber, @departmentID, @contractCategoryID, @taxRateID, @contractName, @unitPrice, @totalCount, @totalCost, @totalTaxCost, @addMan, @addTime, @currentDepartmentName, @currentContractCategoryName, @currentTaxRateName, @currentTaxRateValue, helper);
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
		/// Insert a Cheque_Tax into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractNumber">contractNumber</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="contractCategoryID">contractCategoryID</param>
		/// <param name="taxRateID">taxRateID</param>
		/// <param name="contractName">contractName</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="totalTaxCost">totalTaxCost</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="currentDepartmentName">currentDepartmentName</param>
		/// <param name="currentContractCategoryName">currentContractCategoryName</param>
		/// <param name="currentTaxRateName">currentTaxRateName</param>
		/// <param name="currentTaxRateValue">currentTaxRateValue</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_Tax(string @contractNumber, int @departmentID, int @contractCategoryID, int @taxRateID, string @contractName, decimal @unitPrice, int @totalCount, decimal @totalCost, decimal @totalTaxCost, string @addMan, DateTime @addTime, string @currentDepartmentName, string @currentContractCategoryName, string @currentTaxRateName, string @currentTaxRateValue, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractNumber] nvarchar(200),
	[DepartmentID] int,
	[ContractCategoryID] int,
	[TaxRateID] int,
	[ContractName] nvarchar(100),
	[UnitPrice] decimal(18, 2),
	[TotalCount] int,
	[TotalCost] decimal(18, 2),
	[TotalTaxCost] decimal(18, 2),
	[AddMan] nvarchar(100),
	[AddTime] datetime,
	[CurrentDepartmentName] nvarchar(200),
	[CurrentContractCategoryName] nvarchar(200),
	[CurrentTaxRateName] nvarchar(200),
	[CurrentTaxRateValue] nvarchar(100)
);

INSERT INTO [dbo].[Cheque_Tax] (
	[Cheque_Tax].[ContractNumber],
	[Cheque_Tax].[DepartmentID],
	[Cheque_Tax].[ContractCategoryID],
	[Cheque_Tax].[TaxRateID],
	[Cheque_Tax].[ContractName],
	[Cheque_Tax].[UnitPrice],
	[Cheque_Tax].[TotalCount],
	[Cheque_Tax].[TotalCost],
	[Cheque_Tax].[TotalTaxCost],
	[Cheque_Tax].[AddMan],
	[Cheque_Tax].[AddTime],
	[Cheque_Tax].[CurrentDepartmentName],
	[Cheque_Tax].[CurrentContractCategoryName],
	[Cheque_Tax].[CurrentTaxRateName],
	[Cheque_Tax].[CurrentTaxRateValue]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractNumber],
	INSERTED.[DepartmentID],
	INSERTED.[ContractCategoryID],
	INSERTED.[TaxRateID],
	INSERTED.[ContractName],
	INSERTED.[UnitPrice],
	INSERTED.[TotalCount],
	INSERTED.[TotalCost],
	INSERTED.[TotalTaxCost],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[CurrentDepartmentName],
	INSERTED.[CurrentContractCategoryName],
	INSERTED.[CurrentTaxRateName],
	INSERTED.[CurrentTaxRateValue]
into @table
VALUES ( 
	@ContractNumber,
	@DepartmentID,
	@ContractCategoryID,
	@TaxRateID,
	@ContractName,
	@UnitPrice,
	@TotalCount,
	@TotalCost,
	@TotalTaxCost,
	@AddMan,
	@AddTime,
	@CurrentDepartmentName,
	@CurrentContractCategoryName,
	@CurrentTaxRateName,
	@CurrentTaxRateValue 
); 

SELECT 
	[ID],
	[ContractNumber],
	[DepartmentID],
	[ContractCategoryID],
	[TaxRateID],
	[ContractName],
	[UnitPrice],
	[TotalCount],
	[TotalCost],
	[TotalTaxCost],
	[AddMan],
	[AddTime],
	[CurrentDepartmentName],
	[CurrentContractCategoryName],
	[CurrentTaxRateName],
	[CurrentTaxRateValue] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ContractNumber", EntityBase.GetDatabaseValue(@contractNumber)));
			parameters.Add(new SqlParameter("@DepartmentID", EntityBase.GetDatabaseValue(@departmentID)));
			parameters.Add(new SqlParameter("@ContractCategoryID", EntityBase.GetDatabaseValue(@contractCategoryID)));
			parameters.Add(new SqlParameter("@TaxRateID", EntityBase.GetDatabaseValue(@taxRateID)));
			parameters.Add(new SqlParameter("@ContractName", EntityBase.GetDatabaseValue(@contractName)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@TotalCount", EntityBase.GetDatabaseValue(@totalCount)));
			parameters.Add(new SqlParameter("@TotalCost", EntityBase.GetDatabaseValue(@totalCost)));
			parameters.Add(new SqlParameter("@TotalTaxCost", EntityBase.GetDatabaseValue(@totalTaxCost)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@CurrentDepartmentName", EntityBase.GetDatabaseValue(@currentDepartmentName)));
			parameters.Add(new SqlParameter("@CurrentContractCategoryName", EntityBase.GetDatabaseValue(@currentContractCategoryName)));
			parameters.Add(new SqlParameter("@CurrentTaxRateName", EntityBase.GetDatabaseValue(@currentTaxRateName)));
			parameters.Add(new SqlParameter("@CurrentTaxRateValue", EntityBase.GetDatabaseValue(@currentTaxRateValue)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_Tax into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractNumber">contractNumber</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="contractCategoryID">contractCategoryID</param>
		/// <param name="taxRateID">taxRateID</param>
		/// <param name="contractName">contractName</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="totalTaxCost">totalTaxCost</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="currentDepartmentName">currentDepartmentName</param>
		/// <param name="currentContractCategoryName">currentContractCategoryName</param>
		/// <param name="currentTaxRateName">currentTaxRateName</param>
		/// <param name="currentTaxRateValue">currentTaxRateValue</param>
		public static void UpdateCheque_Tax(int @iD, string @contractNumber, int @departmentID, int @contractCategoryID, int @taxRateID, string @contractName, decimal @unitPrice, int @totalCount, decimal @totalCost, decimal @totalTaxCost, string @addMan, DateTime @addTime, string @currentDepartmentName, string @currentContractCategoryName, string @currentTaxRateName, string @currentTaxRateValue)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_Tax(@iD, @contractNumber, @departmentID, @contractCategoryID, @taxRateID, @contractName, @unitPrice, @totalCount, @totalCost, @totalTaxCost, @addMan, @addTime, @currentDepartmentName, @currentContractCategoryName, @currentTaxRateName, @currentTaxRateValue, helper);
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
		/// Updates a Cheque_Tax into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractNumber">contractNumber</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="contractCategoryID">contractCategoryID</param>
		/// <param name="taxRateID">taxRateID</param>
		/// <param name="contractName">contractName</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="totalTaxCost">totalTaxCost</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="currentDepartmentName">currentDepartmentName</param>
		/// <param name="currentContractCategoryName">currentContractCategoryName</param>
		/// <param name="currentTaxRateName">currentTaxRateName</param>
		/// <param name="currentTaxRateValue">currentTaxRateValue</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_Tax(int @iD, string @contractNumber, int @departmentID, int @contractCategoryID, int @taxRateID, string @contractName, decimal @unitPrice, int @totalCount, decimal @totalCost, decimal @totalTaxCost, string @addMan, DateTime @addTime, string @currentDepartmentName, string @currentContractCategoryName, string @currentTaxRateName, string @currentTaxRateValue, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractNumber] nvarchar(200),
	[DepartmentID] int,
	[ContractCategoryID] int,
	[TaxRateID] int,
	[ContractName] nvarchar(100),
	[UnitPrice] decimal(18, 2),
	[TotalCount] int,
	[TotalCost] decimal(18, 2),
	[TotalTaxCost] decimal(18, 2),
	[AddMan] nvarchar(100),
	[AddTime] datetime,
	[CurrentDepartmentName] nvarchar(200),
	[CurrentContractCategoryName] nvarchar(200),
	[CurrentTaxRateName] nvarchar(200),
	[CurrentTaxRateValue] nvarchar(100)
);

UPDATE [dbo].[Cheque_Tax] SET 
	[Cheque_Tax].[ContractNumber] = @ContractNumber,
	[Cheque_Tax].[DepartmentID] = @DepartmentID,
	[Cheque_Tax].[ContractCategoryID] = @ContractCategoryID,
	[Cheque_Tax].[TaxRateID] = @TaxRateID,
	[Cheque_Tax].[ContractName] = @ContractName,
	[Cheque_Tax].[UnitPrice] = @UnitPrice,
	[Cheque_Tax].[TotalCount] = @TotalCount,
	[Cheque_Tax].[TotalCost] = @TotalCost,
	[Cheque_Tax].[TotalTaxCost] = @TotalTaxCost,
	[Cheque_Tax].[AddMan] = @AddMan,
	[Cheque_Tax].[AddTime] = @AddTime,
	[Cheque_Tax].[CurrentDepartmentName] = @CurrentDepartmentName,
	[Cheque_Tax].[CurrentContractCategoryName] = @CurrentContractCategoryName,
	[Cheque_Tax].[CurrentTaxRateName] = @CurrentTaxRateName,
	[Cheque_Tax].[CurrentTaxRateValue] = @CurrentTaxRateValue 
output 
	INSERTED.[ID],
	INSERTED.[ContractNumber],
	INSERTED.[DepartmentID],
	INSERTED.[ContractCategoryID],
	INSERTED.[TaxRateID],
	INSERTED.[ContractName],
	INSERTED.[UnitPrice],
	INSERTED.[TotalCount],
	INSERTED.[TotalCost],
	INSERTED.[TotalTaxCost],
	INSERTED.[AddMan],
	INSERTED.[AddTime],
	INSERTED.[CurrentDepartmentName],
	INSERTED.[CurrentContractCategoryName],
	INSERTED.[CurrentTaxRateName],
	INSERTED.[CurrentTaxRateValue]
into @table
WHERE 
	[Cheque_Tax].[ID] = @ID

SELECT 
	[ID],
	[ContractNumber],
	[DepartmentID],
	[ContractCategoryID],
	[TaxRateID],
	[ContractName],
	[UnitPrice],
	[TotalCount],
	[TotalCost],
	[TotalTaxCost],
	[AddMan],
	[AddTime],
	[CurrentDepartmentName],
	[CurrentContractCategoryName],
	[CurrentTaxRateName],
	[CurrentTaxRateValue] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ContractNumber", EntityBase.GetDatabaseValue(@contractNumber)));
			parameters.Add(new SqlParameter("@DepartmentID", EntityBase.GetDatabaseValue(@departmentID)));
			parameters.Add(new SqlParameter("@ContractCategoryID", EntityBase.GetDatabaseValue(@contractCategoryID)));
			parameters.Add(new SqlParameter("@TaxRateID", EntityBase.GetDatabaseValue(@taxRateID)));
			parameters.Add(new SqlParameter("@ContractName", EntityBase.GetDatabaseValue(@contractName)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@TotalCount", EntityBase.GetDatabaseValue(@totalCount)));
			parameters.Add(new SqlParameter("@TotalCost", EntityBase.GetDatabaseValue(@totalCost)));
			parameters.Add(new SqlParameter("@TotalTaxCost", EntityBase.GetDatabaseValue(@totalTaxCost)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@CurrentDepartmentName", EntityBase.GetDatabaseValue(@currentDepartmentName)));
			parameters.Add(new SqlParameter("@CurrentContractCategoryName", EntityBase.GetDatabaseValue(@currentContractCategoryName)));
			parameters.Add(new SqlParameter("@CurrentTaxRateName", EntityBase.GetDatabaseValue(@currentTaxRateName)));
			parameters.Add(new SqlParameter("@CurrentTaxRateValue", EntityBase.GetDatabaseValue(@currentTaxRateValue)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_Tax from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_Tax(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_Tax(@iD, helper);
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
		/// Deletes a Cheque_Tax from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_Tax(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_Tax]
WHERE 
	[Cheque_Tax].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_Tax object.
		/// </summary>
		/// <returns>The newly created Cheque_Tax object.</returns>
		public static Cheque_Tax CreateCheque_Tax()
		{
			return InitializeNew<Cheque_Tax>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_Tax by a Cheque_Tax's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_Tax</returns>
		public static Cheque_Tax GetCheque_Tax(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_Tax.SelectFieldList + @"
FROM [dbo].[Cheque_Tax] 
WHERE 
	[Cheque_Tax].[ID] = @ID " + Cheque_Tax.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_Tax>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_Tax by a Cheque_Tax's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_Tax</returns>
		public static Cheque_Tax GetCheque_Tax(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_Tax.SelectFieldList + @"
FROM [dbo].[Cheque_Tax] 
WHERE 
	[Cheque_Tax].[ID] = @ID " + Cheque_Tax.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_Tax>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Tax objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_Tax objects.</returns>
		public static EntityList<Cheque_Tax> GetCheque_Taxes()
		{
			string commandText = @"
SELECT " + Cheque_Tax.SelectFieldList + "FROM [dbo].[Cheque_Tax] " + Cheque_Tax.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_Tax>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_Tax objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_Tax objects.</returns>
        public static EntityList<Cheque_Tax> GetCheque_Taxes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Tax>(SelectFieldList, "FROM [dbo].[Cheque_Tax]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_Tax objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_Tax objects.</returns>
        public static EntityList<Cheque_Tax> GetCheque_Taxes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Tax>(SelectFieldList, "FROM [dbo].[Cheque_Tax]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_Tax objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_Tax objects.</returns>
		protected static EntityList<Cheque_Tax> GetCheque_Taxes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Taxes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Tax objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Tax objects.</returns>
		protected static EntityList<Cheque_Tax> GetCheque_Taxes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Taxes(string.Empty, where, parameters, Cheque_Tax.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Tax objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Tax objects.</returns>
		protected static EntityList<Cheque_Tax> GetCheque_Taxes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Taxes(prefix, where, parameters, Cheque_Tax.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Tax objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Tax objects.</returns>
		protected static EntityList<Cheque_Tax> GetCheque_Taxes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_Taxes(string.Empty, where, parameters, Cheque_Tax.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Tax objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Tax objects.</returns>
		protected static EntityList<Cheque_Tax> GetCheque_Taxes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_Taxes(prefix, where, parameters, Cheque_Tax.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Tax objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_Tax objects.</returns>
		protected static EntityList<Cheque_Tax> GetCheque_Taxes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_Tax.SelectFieldList + "FROM [dbo].[Cheque_Tax] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_Tax>(reader);
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
        protected static EntityList<Cheque_Tax> GetCheque_Taxes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Tax>(SelectFieldList, "FROM [dbo].[Cheque_Tax] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_Tax objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_TaxCount()
        {
            return GetCheque_TaxCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_Tax objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_TaxCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_Tax] " + where;

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
		public static partial class Cheque_Tax_Properties
		{
			public const string ID = "ID";
			public const string ContractNumber = "ContractNumber";
			public const string DepartmentID = "DepartmentID";
			public const string ContractCategoryID = "ContractCategoryID";
			public const string TaxRateID = "TaxRateID";
			public const string ContractName = "ContractName";
			public const string UnitPrice = "UnitPrice";
			public const string TotalCount = "TotalCount";
			public const string TotalCost = "TotalCost";
			public const string TotalTaxCost = "TotalTaxCost";
			public const string AddMan = "AddMan";
			public const string AddTime = "AddTime";
			public const string CurrentDepartmentName = "CurrentDepartmentName";
			public const string CurrentContractCategoryName = "CurrentContractCategoryName";
			public const string CurrentTaxRateName = "CurrentTaxRateName";
			public const string CurrentTaxRateValue = "CurrentTaxRateValue";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ContractNumber" , "string:"},
    			 {"DepartmentID" , "int:"},
    			 {"ContractCategoryID" , "int:"},
    			 {"TaxRateID" , "int:"},
    			 {"ContractName" , "string:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"TotalCount" , "int:"},
    			 {"TotalCost" , "decimal:"},
    			 {"TotalTaxCost" , "decimal:"},
    			 {"AddMan" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"CurrentDepartmentName" , "string:"},
    			 {"CurrentContractCategoryName" , "string:"},
    			 {"CurrentTaxRateName" , "string:"},
    			 {"CurrentTaxRateValue" , "string:"},
            };
		}
		#endregion
	}
}
