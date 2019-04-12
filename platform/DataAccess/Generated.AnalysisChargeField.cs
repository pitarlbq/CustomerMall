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
	/// This object represents the properties and methods of a AnalysisChargeField.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class AnalysisChargeField 
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
		private int _chargeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ChargeID
		{
			[DebuggerStepThrough()]
			get { return this._chargeID; }
			set 
			{
				if (this._chargeID != value) 
				{
					this._chargeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _sortOrder = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SortOrder
		{
			[DebuggerStepThrough()]
			get { return this._sortOrder; }
			set 
			{
				if (this._sortOrder != value) 
				{
					this._sortOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("SortOrder");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _pageCode = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PageCode
		{
			[DebuggerStepThrough()]
			get { return this._pageCode; }
			set 
			{
				if (this._pageCode != value) 
				{
					this._pageCode = value;
					this.IsDirty = true;	
					OnPropertyChanged("PageCode");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isHide = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsHide
		{
			[DebuggerStepThrough()]
			get { return this._isHide; }
			set 
			{
				if (this._isHide != value) 
				{
					this._isHide = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsHide");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isHideTotal = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsHideTotal
		{
			[DebuggerStepThrough()]
			get { return this._isHideTotal; }
			set 
			{
				if (this._isHideTotal != value) 
				{
					this._isHideTotal = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsHideTotal");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isHideReal = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsHideReal
		{
			[DebuggerStepThrough()]
			get { return this._isHideReal; }
			set 
			{
				if (this._isHideReal != value) 
				{
					this._isHideReal = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsHideReal");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isHideRest = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsHideRest
		{
			[DebuggerStepThrough()]
			get { return this._isHideRest; }
			set 
			{
				if (this._isHideRest != value) 
				{
					this._isHideRest = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsHideRest");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isHideDiscount = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsHideDiscount
		{
			[DebuggerStepThrough()]
			get { return this._isHideDiscount; }
			set 
			{
				if (this._isHideDiscount != value) 
				{
					this._isHideDiscount = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsHideDiscount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _fieldType = int.MinValue;
		/// <summary>
		/// 1-收款情况表 2-月度分析表
		/// </summary>
        [Description("1-收款情况表 2-月度分析表")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int FieldType
		{
			[DebuggerStepThrough()]
			get { return this._fieldType; }
			set 
			{
				if (this._fieldType != value) 
				{
					this._fieldType = value;
					this.IsDirty = true;	
					OnPropertyChanged("FieldType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isHideChargeFee = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsHideChargeFee
		{
			[DebuggerStepThrough()]
			get { return this._isHideChargeFee; }
			set 
			{
				if (this._isHideChargeFee != value) 
				{
					this._isHideChargeFee = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsHideChargeFee");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isHideHistoryRoomFee = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsHideHistoryRoomFee
		{
			[DebuggerStepThrough()]
			get { return this._isHideHistoryRoomFee; }
			set 
			{
				if (this._isHideHistoryRoomFee != value) 
				{
					this._isHideHistoryRoomFee = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsHideHistoryRoomFee");
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
	[ChargeID] int,
	[SortOrder] int,
	[PageCode] nvarchar(500),
	[IsHide] bit,
	[IsHideTotal] bit,
	[IsHideReal] bit,
	[IsHideRest] bit,
	[IsHideDiscount] bit,
	[FieldType] int,
	[IsHideChargeFee] bit,
	[IsHideHistoryRoomFee] bit
);

INSERT INTO [dbo].[AnalysisChargeField] (
	[AnalysisChargeField].[ChargeID],
	[AnalysisChargeField].[SortOrder],
	[AnalysisChargeField].[PageCode],
	[AnalysisChargeField].[IsHide],
	[AnalysisChargeField].[IsHideTotal],
	[AnalysisChargeField].[IsHideReal],
	[AnalysisChargeField].[IsHideRest],
	[AnalysisChargeField].[IsHideDiscount],
	[AnalysisChargeField].[FieldType],
	[AnalysisChargeField].[IsHideChargeFee],
	[AnalysisChargeField].[IsHideHistoryRoomFee]
) 
output 
	INSERTED.[ID],
	INSERTED.[ChargeID],
	INSERTED.[SortOrder],
	INSERTED.[PageCode],
	INSERTED.[IsHide],
	INSERTED.[IsHideTotal],
	INSERTED.[IsHideReal],
	INSERTED.[IsHideRest],
	INSERTED.[IsHideDiscount],
	INSERTED.[FieldType],
	INSERTED.[IsHideChargeFee],
	INSERTED.[IsHideHistoryRoomFee]
into @table
VALUES ( 
	@ChargeID,
	@SortOrder,
	@PageCode,
	@IsHide,
	@IsHideTotal,
	@IsHideReal,
	@IsHideRest,
	@IsHideDiscount,
	@FieldType,
	@IsHideChargeFee,
	@IsHideHistoryRoomFee 
); 

SELECT 
	[ID],
	[ChargeID],
	[SortOrder],
	[PageCode],
	[IsHide],
	[IsHideTotal],
	[IsHideReal],
	[IsHideRest],
	[IsHideDiscount],
	[FieldType],
	[IsHideChargeFee],
	[IsHideHistoryRoomFee] 
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
	[ChargeID] int,
	[SortOrder] int,
	[PageCode] nvarchar(500),
	[IsHide] bit,
	[IsHideTotal] bit,
	[IsHideReal] bit,
	[IsHideRest] bit,
	[IsHideDiscount] bit,
	[FieldType] int,
	[IsHideChargeFee] bit,
	[IsHideHistoryRoomFee] bit
);

UPDATE [dbo].[AnalysisChargeField] SET 
	[AnalysisChargeField].[ChargeID] = @ChargeID,
	[AnalysisChargeField].[SortOrder] = @SortOrder,
	[AnalysisChargeField].[PageCode] = @PageCode,
	[AnalysisChargeField].[IsHide] = @IsHide,
	[AnalysisChargeField].[IsHideTotal] = @IsHideTotal,
	[AnalysisChargeField].[IsHideReal] = @IsHideReal,
	[AnalysisChargeField].[IsHideRest] = @IsHideRest,
	[AnalysisChargeField].[IsHideDiscount] = @IsHideDiscount,
	[AnalysisChargeField].[FieldType] = @FieldType,
	[AnalysisChargeField].[IsHideChargeFee] = @IsHideChargeFee,
	[AnalysisChargeField].[IsHideHistoryRoomFee] = @IsHideHistoryRoomFee 
output 
	INSERTED.[ID],
	INSERTED.[ChargeID],
	INSERTED.[SortOrder],
	INSERTED.[PageCode],
	INSERTED.[IsHide],
	INSERTED.[IsHideTotal],
	INSERTED.[IsHideReal],
	INSERTED.[IsHideRest],
	INSERTED.[IsHideDiscount],
	INSERTED.[FieldType],
	INSERTED.[IsHideChargeFee],
	INSERTED.[IsHideHistoryRoomFee]
into @table
WHERE 
	[AnalysisChargeField].[ID] = @ID

SELECT 
	[ID],
	[ChargeID],
	[SortOrder],
	[PageCode],
	[IsHide],
	[IsHideTotal],
	[IsHideReal],
	[IsHideRest],
	[IsHideDiscount],
	[FieldType],
	[IsHideChargeFee],
	[IsHideHistoryRoomFee] 
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
DELETE FROM [dbo].[AnalysisChargeField]
WHERE 
	[AnalysisChargeField].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public AnalysisChargeField() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetAnalysisChargeField(this.ID));
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
	[AnalysisChargeField].[ID],
	[AnalysisChargeField].[ChargeID],
	[AnalysisChargeField].[SortOrder],
	[AnalysisChargeField].[PageCode],
	[AnalysisChargeField].[IsHide],
	[AnalysisChargeField].[IsHideTotal],
	[AnalysisChargeField].[IsHideReal],
	[AnalysisChargeField].[IsHideRest],
	[AnalysisChargeField].[IsHideDiscount],
	[AnalysisChargeField].[FieldType],
	[AnalysisChargeField].[IsHideChargeFee],
	[AnalysisChargeField].[IsHideHistoryRoomFee]
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
                return "AnalysisChargeField";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a AnalysisChargeField into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeID">chargeID</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="pageCode">pageCode</param>
		/// <param name="isHide">isHide</param>
		/// <param name="isHideTotal">isHideTotal</param>
		/// <param name="isHideReal">isHideReal</param>
		/// <param name="isHideRest">isHideRest</param>
		/// <param name="isHideDiscount">isHideDiscount</param>
		/// <param name="fieldType">fieldType</param>
		/// <param name="isHideChargeFee">isHideChargeFee</param>
		/// <param name="isHideHistoryRoomFee">isHideHistoryRoomFee</param>
		public static void InsertAnalysisChargeField(int @chargeID, int @sortOrder, string @pageCode, bool @isHide, bool @isHideTotal, bool @isHideReal, bool @isHideRest, bool @isHideDiscount, int @fieldType, bool @isHideChargeFee, bool @isHideHistoryRoomFee)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertAnalysisChargeField(@chargeID, @sortOrder, @pageCode, @isHide, @isHideTotal, @isHideReal, @isHideRest, @isHideDiscount, @fieldType, @isHideChargeFee, @isHideHistoryRoomFee, helper);
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
		/// Insert a AnalysisChargeField into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeID">chargeID</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="pageCode">pageCode</param>
		/// <param name="isHide">isHide</param>
		/// <param name="isHideTotal">isHideTotal</param>
		/// <param name="isHideReal">isHideReal</param>
		/// <param name="isHideRest">isHideRest</param>
		/// <param name="isHideDiscount">isHideDiscount</param>
		/// <param name="fieldType">fieldType</param>
		/// <param name="isHideChargeFee">isHideChargeFee</param>
		/// <param name="isHideHistoryRoomFee">isHideHistoryRoomFee</param>
		/// <param name="helper">helper</param>
		internal static void InsertAnalysisChargeField(int @chargeID, int @sortOrder, string @pageCode, bool @isHide, bool @isHideTotal, bool @isHideReal, bool @isHideRest, bool @isHideDiscount, int @fieldType, bool @isHideChargeFee, bool @isHideHistoryRoomFee, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ChargeID] int,
	[SortOrder] int,
	[PageCode] nvarchar(500),
	[IsHide] bit,
	[IsHideTotal] bit,
	[IsHideReal] bit,
	[IsHideRest] bit,
	[IsHideDiscount] bit,
	[FieldType] int,
	[IsHideChargeFee] bit,
	[IsHideHistoryRoomFee] bit
);

INSERT INTO [dbo].[AnalysisChargeField] (
	[AnalysisChargeField].[ChargeID],
	[AnalysisChargeField].[SortOrder],
	[AnalysisChargeField].[PageCode],
	[AnalysisChargeField].[IsHide],
	[AnalysisChargeField].[IsHideTotal],
	[AnalysisChargeField].[IsHideReal],
	[AnalysisChargeField].[IsHideRest],
	[AnalysisChargeField].[IsHideDiscount],
	[AnalysisChargeField].[FieldType],
	[AnalysisChargeField].[IsHideChargeFee],
	[AnalysisChargeField].[IsHideHistoryRoomFee]
) 
output 
	INSERTED.[ID],
	INSERTED.[ChargeID],
	INSERTED.[SortOrder],
	INSERTED.[PageCode],
	INSERTED.[IsHide],
	INSERTED.[IsHideTotal],
	INSERTED.[IsHideReal],
	INSERTED.[IsHideRest],
	INSERTED.[IsHideDiscount],
	INSERTED.[FieldType],
	INSERTED.[IsHideChargeFee],
	INSERTED.[IsHideHistoryRoomFee]
into @table
VALUES ( 
	@ChargeID,
	@SortOrder,
	@PageCode,
	@IsHide,
	@IsHideTotal,
	@IsHideReal,
	@IsHideRest,
	@IsHideDiscount,
	@FieldType,
	@IsHideChargeFee,
	@IsHideHistoryRoomFee 
); 

SELECT 
	[ID],
	[ChargeID],
	[SortOrder],
	[PageCode],
	[IsHide],
	[IsHideTotal],
	[IsHideReal],
	[IsHideRest],
	[IsHideDiscount],
	[FieldType],
	[IsHideChargeFee],
	[IsHideHistoryRoomFee] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@PageCode", EntityBase.GetDatabaseValue(@pageCode)));
			parameters.Add(new SqlParameter("@IsHide", @isHide));
			parameters.Add(new SqlParameter("@IsHideTotal", @isHideTotal));
			parameters.Add(new SqlParameter("@IsHideReal", @isHideReal));
			parameters.Add(new SqlParameter("@IsHideRest", @isHideRest));
			parameters.Add(new SqlParameter("@IsHideDiscount", @isHideDiscount));
			parameters.Add(new SqlParameter("@FieldType", EntityBase.GetDatabaseValue(@fieldType)));
			parameters.Add(new SqlParameter("@IsHideChargeFee", @isHideChargeFee));
			parameters.Add(new SqlParameter("@IsHideHistoryRoomFee", @isHideHistoryRoomFee));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a AnalysisChargeField into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="pageCode">pageCode</param>
		/// <param name="isHide">isHide</param>
		/// <param name="isHideTotal">isHideTotal</param>
		/// <param name="isHideReal">isHideReal</param>
		/// <param name="isHideRest">isHideRest</param>
		/// <param name="isHideDiscount">isHideDiscount</param>
		/// <param name="fieldType">fieldType</param>
		/// <param name="isHideChargeFee">isHideChargeFee</param>
		/// <param name="isHideHistoryRoomFee">isHideHistoryRoomFee</param>
		public static void UpdateAnalysisChargeField(int @iD, int @chargeID, int @sortOrder, string @pageCode, bool @isHide, bool @isHideTotal, bool @isHideReal, bool @isHideRest, bool @isHideDiscount, int @fieldType, bool @isHideChargeFee, bool @isHideHistoryRoomFee)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateAnalysisChargeField(@iD, @chargeID, @sortOrder, @pageCode, @isHide, @isHideTotal, @isHideReal, @isHideRest, @isHideDiscount, @fieldType, @isHideChargeFee, @isHideHistoryRoomFee, helper);
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
		/// Updates a AnalysisChargeField into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="pageCode">pageCode</param>
		/// <param name="isHide">isHide</param>
		/// <param name="isHideTotal">isHideTotal</param>
		/// <param name="isHideReal">isHideReal</param>
		/// <param name="isHideRest">isHideRest</param>
		/// <param name="isHideDiscount">isHideDiscount</param>
		/// <param name="fieldType">fieldType</param>
		/// <param name="isHideChargeFee">isHideChargeFee</param>
		/// <param name="isHideHistoryRoomFee">isHideHistoryRoomFee</param>
		/// <param name="helper">helper</param>
		internal static void UpdateAnalysisChargeField(int @iD, int @chargeID, int @sortOrder, string @pageCode, bool @isHide, bool @isHideTotal, bool @isHideReal, bool @isHideRest, bool @isHideDiscount, int @fieldType, bool @isHideChargeFee, bool @isHideHistoryRoomFee, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ChargeID] int,
	[SortOrder] int,
	[PageCode] nvarchar(500),
	[IsHide] bit,
	[IsHideTotal] bit,
	[IsHideReal] bit,
	[IsHideRest] bit,
	[IsHideDiscount] bit,
	[FieldType] int,
	[IsHideChargeFee] bit,
	[IsHideHistoryRoomFee] bit
);

UPDATE [dbo].[AnalysisChargeField] SET 
	[AnalysisChargeField].[ChargeID] = @ChargeID,
	[AnalysisChargeField].[SortOrder] = @SortOrder,
	[AnalysisChargeField].[PageCode] = @PageCode,
	[AnalysisChargeField].[IsHide] = @IsHide,
	[AnalysisChargeField].[IsHideTotal] = @IsHideTotal,
	[AnalysisChargeField].[IsHideReal] = @IsHideReal,
	[AnalysisChargeField].[IsHideRest] = @IsHideRest,
	[AnalysisChargeField].[IsHideDiscount] = @IsHideDiscount,
	[AnalysisChargeField].[FieldType] = @FieldType,
	[AnalysisChargeField].[IsHideChargeFee] = @IsHideChargeFee,
	[AnalysisChargeField].[IsHideHistoryRoomFee] = @IsHideHistoryRoomFee 
output 
	INSERTED.[ID],
	INSERTED.[ChargeID],
	INSERTED.[SortOrder],
	INSERTED.[PageCode],
	INSERTED.[IsHide],
	INSERTED.[IsHideTotal],
	INSERTED.[IsHideReal],
	INSERTED.[IsHideRest],
	INSERTED.[IsHideDiscount],
	INSERTED.[FieldType],
	INSERTED.[IsHideChargeFee],
	INSERTED.[IsHideHistoryRoomFee]
into @table
WHERE 
	[AnalysisChargeField].[ID] = @ID

SELECT 
	[ID],
	[ChargeID],
	[SortOrder],
	[PageCode],
	[IsHide],
	[IsHideTotal],
	[IsHideReal],
	[IsHideRest],
	[IsHideDiscount],
	[FieldType],
	[IsHideChargeFee],
	[IsHideHistoryRoomFee] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@PageCode", EntityBase.GetDatabaseValue(@pageCode)));
			parameters.Add(new SqlParameter("@IsHide", @isHide));
			parameters.Add(new SqlParameter("@IsHideTotal", @isHideTotal));
			parameters.Add(new SqlParameter("@IsHideReal", @isHideReal));
			parameters.Add(new SqlParameter("@IsHideRest", @isHideRest));
			parameters.Add(new SqlParameter("@IsHideDiscount", @isHideDiscount));
			parameters.Add(new SqlParameter("@FieldType", EntityBase.GetDatabaseValue(@fieldType)));
			parameters.Add(new SqlParameter("@IsHideChargeFee", @isHideChargeFee));
			parameters.Add(new SqlParameter("@IsHideHistoryRoomFee", @isHideHistoryRoomFee));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a AnalysisChargeField from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteAnalysisChargeField(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteAnalysisChargeField(@iD, helper);
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
		/// Deletes a AnalysisChargeField from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteAnalysisChargeField(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[AnalysisChargeField]
WHERE 
	[AnalysisChargeField].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new AnalysisChargeField object.
		/// </summary>
		/// <returns>The newly created AnalysisChargeField object.</returns>
		public static AnalysisChargeField CreateAnalysisChargeField()
		{
			return InitializeNew<AnalysisChargeField>();
		}
		
		/// <summary>
		/// Retrieve information for a AnalysisChargeField by a AnalysisChargeField's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>AnalysisChargeField</returns>
		public static AnalysisChargeField GetAnalysisChargeField(int @iD)
		{
			string commandText = @"
SELECT 
" + AnalysisChargeField.SelectFieldList + @"
FROM [dbo].[AnalysisChargeField] 
WHERE 
	[AnalysisChargeField].[ID] = @ID " + AnalysisChargeField.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<AnalysisChargeField>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a AnalysisChargeField by a AnalysisChargeField's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>AnalysisChargeField</returns>
		public static AnalysisChargeField GetAnalysisChargeField(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + AnalysisChargeField.SelectFieldList + @"
FROM [dbo].[AnalysisChargeField] 
WHERE 
	[AnalysisChargeField].[ID] = @ID " + AnalysisChargeField.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<AnalysisChargeField>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection AnalysisChargeField objects.
		/// </summary>
		/// <returns>The retrieved collection of AnalysisChargeField objects.</returns>
		public static EntityList<AnalysisChargeField> GetAnalysisChargeFields()
		{
			string commandText = @"
SELECT " + AnalysisChargeField.SelectFieldList + "FROM [dbo].[AnalysisChargeField] " + AnalysisChargeField.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<AnalysisChargeField>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection AnalysisChargeField objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of AnalysisChargeField objects.</returns>
        public static EntityList<AnalysisChargeField> GetAnalysisChargeFields(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<AnalysisChargeField>(SelectFieldList, "FROM [dbo].[AnalysisChargeField]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection AnalysisChargeField objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of AnalysisChargeField objects.</returns>
        public static EntityList<AnalysisChargeField> GetAnalysisChargeFields(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<AnalysisChargeField>(SelectFieldList, "FROM [dbo].[AnalysisChargeField]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection AnalysisChargeField objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of AnalysisChargeField objects.</returns>
		protected static EntityList<AnalysisChargeField> GetAnalysisChargeFields(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetAnalysisChargeFields(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection AnalysisChargeField objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of AnalysisChargeField objects.</returns>
		protected static EntityList<AnalysisChargeField> GetAnalysisChargeFields(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetAnalysisChargeFields(string.Empty, where, parameters, AnalysisChargeField.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection AnalysisChargeField objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of AnalysisChargeField objects.</returns>
		protected static EntityList<AnalysisChargeField> GetAnalysisChargeFields(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetAnalysisChargeFields(prefix, where, parameters, AnalysisChargeField.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection AnalysisChargeField objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of AnalysisChargeField objects.</returns>
		protected static EntityList<AnalysisChargeField> GetAnalysisChargeFields(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetAnalysisChargeFields(string.Empty, where, parameters, AnalysisChargeField.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection AnalysisChargeField objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of AnalysisChargeField objects.</returns>
		protected static EntityList<AnalysisChargeField> GetAnalysisChargeFields(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetAnalysisChargeFields(prefix, where, parameters, AnalysisChargeField.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection AnalysisChargeField objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of AnalysisChargeField objects.</returns>
		protected static EntityList<AnalysisChargeField> GetAnalysisChargeFields(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + AnalysisChargeField.SelectFieldList + "FROM [dbo].[AnalysisChargeField] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<AnalysisChargeField>(reader);
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
        protected static EntityList<AnalysisChargeField> GetAnalysisChargeFields(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<AnalysisChargeField>(SelectFieldList, "FROM [dbo].[AnalysisChargeField] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of AnalysisChargeField objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetAnalysisChargeFieldCount()
        {
            return GetAnalysisChargeFieldCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of AnalysisChargeField objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetAnalysisChargeFieldCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[AnalysisChargeField] " + where;

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
		public static partial class AnalysisChargeField_Properties
		{
			public const string ID = "ID";
			public const string ChargeID = "ChargeID";
			public const string SortOrder = "SortOrder";
			public const string PageCode = "PageCode";
			public const string IsHide = "IsHide";
			public const string IsHideTotal = "IsHideTotal";
			public const string IsHideReal = "IsHideReal";
			public const string IsHideRest = "IsHideRest";
			public const string IsHideDiscount = "IsHideDiscount";
			public const string FieldType = "FieldType";
			public const string IsHideChargeFee = "IsHideChargeFee";
			public const string IsHideHistoryRoomFee = "IsHideHistoryRoomFee";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ChargeID" , "int:"},
    			 {"SortOrder" , "int:"},
    			 {"PageCode" , "string:"},
    			 {"IsHide" , "bool:"},
    			 {"IsHideTotal" , "bool:"},
    			 {"IsHideReal" , "bool:"},
    			 {"IsHideRest" , "bool:"},
    			 {"IsHideDiscount" , "bool:"},
    			 {"FieldType" , "int:1-收款情况表 2-月度分析表"},
    			 {"IsHideChargeFee" , "bool:"},
    			 {"IsHideHistoryRoomFee" , "bool:"},
            };
		}
		#endregion
	}
}
