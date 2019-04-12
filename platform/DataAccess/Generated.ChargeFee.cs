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
	/// This object represents the properties and methods of a ChargeFee.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ChargeFee 
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
		private DateTime _startTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime StartTime
		{
			[DebuggerStepThrough()]
			get { return this._startTime; }
			set 
			{
				if (this._startTime != value) 
				{
					this._startTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("StartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _endTypeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int EndTypeID
		{
			[DebuggerStepThrough()]
			get { return this._endTypeID; }
			set 
			{
				if (this._endTypeID != value) 
				{
					this._endTypeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndTypeID");
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
		[DataObjectField(false, false, false)]
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
		private decimal _changeUnitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ChangeUnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._changeUnitPrice; }
			set 
			{
				if (this._changeUnitPrice != value) 
				{
					this._changeUnitPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChangeUnitPrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _changeStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ChangeStartTime
		{
			[DebuggerStepThrough()]
			get { return this._changeStartTime; }
			set 
			{
				if (this._changeStartTime != value) 
				{
					this._changeStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChangeStartTime");
				}
			}
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
			set 
			{
				if (this._isActive != value) 
				{
					this._isActive = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsActive");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _cID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CID
		{
			[DebuggerStepThrough()]
			get { return this._cID; }
			set 
			{
				if (this._cID != value) 
				{
					this._cID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _endTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime EndTime
		{
			[DebuggerStepThrough()]
			get { return this._endTime; }
			set 
			{
				if (this._endTime != value) 
				{
					this._endTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndTime");
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargeTypeCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChargeTypeCount
		{
			[DebuggerStepThrough()]
			get { return this._chargeTypeCount; }
			set 
			{
				if (this._chargeTypeCount != value) 
				{
					this._chargeTypeCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeTypeCount");
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
	[UnitPrice] decimal(18, 4),
	[StartTime] datetime,
	[EndTypeID] int,
	[AddTime] datetime,
	[ChargeID] int,
	[ChangeUnitPrice] decimal(18, 3),
	[ChangeStartTime] datetime,
	[IsActive] bit,
	[CID] int,
	[EndTime] datetime,
	[SortOrder] int,
	[Remark] ntext,
	[ChargeTypeCount] int
);

INSERT INTO [dbo].[ChargeFee] (
	[ChargeFee].[UnitPrice],
	[ChargeFee].[StartTime],
	[ChargeFee].[EndTypeID],
	[ChargeFee].[AddTime],
	[ChargeFee].[ChargeID],
	[ChargeFee].[ChangeUnitPrice],
	[ChargeFee].[ChangeStartTime],
	[ChargeFee].[IsActive],
	[ChargeFee].[CID],
	[ChargeFee].[EndTime],
	[ChargeFee].[SortOrder],
	[ChargeFee].[Remark],
	[ChargeFee].[ChargeTypeCount]
) 
output 
	INSERTED.[ID],
	INSERTED.[UnitPrice],
	INSERTED.[StartTime],
	INSERTED.[EndTypeID],
	INSERTED.[AddTime],
	INSERTED.[ChargeID],
	INSERTED.[ChangeUnitPrice],
	INSERTED.[ChangeStartTime],
	INSERTED.[IsActive],
	INSERTED.[CID],
	INSERTED.[EndTime],
	INSERTED.[SortOrder],
	INSERTED.[Remark],
	INSERTED.[ChargeTypeCount]
into @table
VALUES ( 
	@UnitPrice,
	@StartTime,
	@EndTypeID,
	@AddTime,
	@ChargeID,
	@ChangeUnitPrice,
	@ChangeStartTime,
	@IsActive,
	@CID,
	@EndTime,
	@SortOrder,
	@Remark,
	@ChargeTypeCount 
); 

SELECT 
	[ID],
	[UnitPrice],
	[StartTime],
	[EndTypeID],
	[AddTime],
	[ChargeID],
	[ChangeUnitPrice],
	[ChangeStartTime],
	[IsActive],
	[CID],
	[EndTime],
	[SortOrder],
	[Remark],
	[ChargeTypeCount] 
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
	[UnitPrice] decimal(18, 4),
	[StartTime] datetime,
	[EndTypeID] int,
	[AddTime] datetime,
	[ChargeID] int,
	[ChangeUnitPrice] decimal(18, 3),
	[ChangeStartTime] datetime,
	[IsActive] bit,
	[CID] int,
	[EndTime] datetime,
	[SortOrder] int,
	[Remark] ntext,
	[ChargeTypeCount] int
);

UPDATE [dbo].[ChargeFee] SET 
	[ChargeFee].[UnitPrice] = @UnitPrice,
	[ChargeFee].[StartTime] = @StartTime,
	[ChargeFee].[EndTypeID] = @EndTypeID,
	[ChargeFee].[AddTime] = @AddTime,
	[ChargeFee].[ChargeID] = @ChargeID,
	[ChargeFee].[ChangeUnitPrice] = @ChangeUnitPrice,
	[ChargeFee].[ChangeStartTime] = @ChangeStartTime,
	[ChargeFee].[IsActive] = @IsActive,
	[ChargeFee].[CID] = @CID,
	[ChargeFee].[EndTime] = @EndTime,
	[ChargeFee].[SortOrder] = @SortOrder,
	[ChargeFee].[Remark] = @Remark,
	[ChargeFee].[ChargeTypeCount] = @ChargeTypeCount 
output 
	INSERTED.[ID],
	INSERTED.[UnitPrice],
	INSERTED.[StartTime],
	INSERTED.[EndTypeID],
	INSERTED.[AddTime],
	INSERTED.[ChargeID],
	INSERTED.[ChangeUnitPrice],
	INSERTED.[ChangeStartTime],
	INSERTED.[IsActive],
	INSERTED.[CID],
	INSERTED.[EndTime],
	INSERTED.[SortOrder],
	INSERTED.[Remark],
	INSERTED.[ChargeTypeCount]
into @table
WHERE 
	[ChargeFee].[ID] = @ID

SELECT 
	[ID],
	[UnitPrice],
	[StartTime],
	[EndTypeID],
	[AddTime],
	[ChargeID],
	[ChangeUnitPrice],
	[ChangeStartTime],
	[IsActive],
	[CID],
	[EndTime],
	[SortOrder],
	[Remark],
	[ChargeTypeCount] 
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
DELETE FROM [dbo].[ChargeFee]
WHERE 
	[ChargeFee].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ChargeFee() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetChargeFee(this.ID));
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
	[ChargeFee].[ID],
	[ChargeFee].[UnitPrice],
	[ChargeFee].[StartTime],
	[ChargeFee].[EndTypeID],
	[ChargeFee].[AddTime],
	[ChargeFee].[ChargeID],
	[ChargeFee].[ChangeUnitPrice],
	[ChargeFee].[ChangeStartTime],
	[ChargeFee].[IsActive],
	[ChargeFee].[CID],
	[ChargeFee].[EndTime],
	[ChargeFee].[SortOrder],
	[ChargeFee].[Remark],
	[ChargeFee].[ChargeTypeCount]
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
                return "ChargeFee";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ChargeFee into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTypeID">endTypeID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="changeUnitPrice">changeUnitPrice</param>
		/// <param name="changeStartTime">changeStartTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="cID">cID</param>
		/// <param name="endTime">endTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="remark">remark</param>
		/// <param name="chargeTypeCount">chargeTypeCount</param>
		public static void InsertChargeFee(decimal @unitPrice, DateTime @startTime, int @endTypeID, DateTime @addTime, int @chargeID, decimal @changeUnitPrice, DateTime @changeStartTime, bool @isActive, int @cID, DateTime @endTime, int @sortOrder, string @remark, int @chargeTypeCount)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertChargeFee(@unitPrice, @startTime, @endTypeID, @addTime, @chargeID, @changeUnitPrice, @changeStartTime, @isActive, @cID, @endTime, @sortOrder, @remark, @chargeTypeCount, helper);
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
		/// Insert a ChargeFee into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTypeID">endTypeID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="changeUnitPrice">changeUnitPrice</param>
		/// <param name="changeStartTime">changeStartTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="cID">cID</param>
		/// <param name="endTime">endTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="remark">remark</param>
		/// <param name="chargeTypeCount">chargeTypeCount</param>
		/// <param name="helper">helper</param>
		internal static void InsertChargeFee(decimal @unitPrice, DateTime @startTime, int @endTypeID, DateTime @addTime, int @chargeID, decimal @changeUnitPrice, DateTime @changeStartTime, bool @isActive, int @cID, DateTime @endTime, int @sortOrder, string @remark, int @chargeTypeCount, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UnitPrice] decimal(18, 4),
	[StartTime] datetime,
	[EndTypeID] int,
	[AddTime] datetime,
	[ChargeID] int,
	[ChangeUnitPrice] decimal(18, 3),
	[ChangeStartTime] datetime,
	[IsActive] bit,
	[CID] int,
	[EndTime] datetime,
	[SortOrder] int,
	[Remark] ntext,
	[ChargeTypeCount] int
);

INSERT INTO [dbo].[ChargeFee] (
	[ChargeFee].[UnitPrice],
	[ChargeFee].[StartTime],
	[ChargeFee].[EndTypeID],
	[ChargeFee].[AddTime],
	[ChargeFee].[ChargeID],
	[ChargeFee].[ChangeUnitPrice],
	[ChargeFee].[ChangeStartTime],
	[ChargeFee].[IsActive],
	[ChargeFee].[CID],
	[ChargeFee].[EndTime],
	[ChargeFee].[SortOrder],
	[ChargeFee].[Remark],
	[ChargeFee].[ChargeTypeCount]
) 
output 
	INSERTED.[ID],
	INSERTED.[UnitPrice],
	INSERTED.[StartTime],
	INSERTED.[EndTypeID],
	INSERTED.[AddTime],
	INSERTED.[ChargeID],
	INSERTED.[ChangeUnitPrice],
	INSERTED.[ChangeStartTime],
	INSERTED.[IsActive],
	INSERTED.[CID],
	INSERTED.[EndTime],
	INSERTED.[SortOrder],
	INSERTED.[Remark],
	INSERTED.[ChargeTypeCount]
into @table
VALUES ( 
	@UnitPrice,
	@StartTime,
	@EndTypeID,
	@AddTime,
	@ChargeID,
	@ChangeUnitPrice,
	@ChangeStartTime,
	@IsActive,
	@CID,
	@EndTime,
	@SortOrder,
	@Remark,
	@ChargeTypeCount 
); 

SELECT 
	[ID],
	[UnitPrice],
	[StartTime],
	[EndTypeID],
	[AddTime],
	[ChargeID],
	[ChangeUnitPrice],
	[ChangeStartTime],
	[IsActive],
	[CID],
	[EndTime],
	[SortOrder],
	[Remark],
	[ChargeTypeCount] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTypeID", EntityBase.GetDatabaseValue(@endTypeID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@ChangeUnitPrice", EntityBase.GetDatabaseValue(@changeUnitPrice)));
			parameters.Add(new SqlParameter("@ChangeStartTime", EntityBase.GetDatabaseValue(@changeStartTime)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@CID", EntityBase.GetDatabaseValue(@cID)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@ChargeTypeCount", EntityBase.GetDatabaseValue(@chargeTypeCount)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ChargeFee into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTypeID">endTypeID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="changeUnitPrice">changeUnitPrice</param>
		/// <param name="changeStartTime">changeStartTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="cID">cID</param>
		/// <param name="endTime">endTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="remark">remark</param>
		/// <param name="chargeTypeCount">chargeTypeCount</param>
		public static void UpdateChargeFee(int @iD, decimal @unitPrice, DateTime @startTime, int @endTypeID, DateTime @addTime, int @chargeID, decimal @changeUnitPrice, DateTime @changeStartTime, bool @isActive, int @cID, DateTime @endTime, int @sortOrder, string @remark, int @chargeTypeCount)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateChargeFee(@iD, @unitPrice, @startTime, @endTypeID, @addTime, @chargeID, @changeUnitPrice, @changeStartTime, @isActive, @cID, @endTime, @sortOrder, @remark, @chargeTypeCount, helper);
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
		/// Updates a ChargeFee into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTypeID">endTypeID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="changeUnitPrice">changeUnitPrice</param>
		/// <param name="changeStartTime">changeStartTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="cID">cID</param>
		/// <param name="endTime">endTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="remark">remark</param>
		/// <param name="chargeTypeCount">chargeTypeCount</param>
		/// <param name="helper">helper</param>
		internal static void UpdateChargeFee(int @iD, decimal @unitPrice, DateTime @startTime, int @endTypeID, DateTime @addTime, int @chargeID, decimal @changeUnitPrice, DateTime @changeStartTime, bool @isActive, int @cID, DateTime @endTime, int @sortOrder, string @remark, int @chargeTypeCount, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UnitPrice] decimal(18, 4),
	[StartTime] datetime,
	[EndTypeID] int,
	[AddTime] datetime,
	[ChargeID] int,
	[ChangeUnitPrice] decimal(18, 3),
	[ChangeStartTime] datetime,
	[IsActive] bit,
	[CID] int,
	[EndTime] datetime,
	[SortOrder] int,
	[Remark] ntext,
	[ChargeTypeCount] int
);

UPDATE [dbo].[ChargeFee] SET 
	[ChargeFee].[UnitPrice] = @UnitPrice,
	[ChargeFee].[StartTime] = @StartTime,
	[ChargeFee].[EndTypeID] = @EndTypeID,
	[ChargeFee].[AddTime] = @AddTime,
	[ChargeFee].[ChargeID] = @ChargeID,
	[ChargeFee].[ChangeUnitPrice] = @ChangeUnitPrice,
	[ChargeFee].[ChangeStartTime] = @ChangeStartTime,
	[ChargeFee].[IsActive] = @IsActive,
	[ChargeFee].[CID] = @CID,
	[ChargeFee].[EndTime] = @EndTime,
	[ChargeFee].[SortOrder] = @SortOrder,
	[ChargeFee].[Remark] = @Remark,
	[ChargeFee].[ChargeTypeCount] = @ChargeTypeCount 
output 
	INSERTED.[ID],
	INSERTED.[UnitPrice],
	INSERTED.[StartTime],
	INSERTED.[EndTypeID],
	INSERTED.[AddTime],
	INSERTED.[ChargeID],
	INSERTED.[ChangeUnitPrice],
	INSERTED.[ChangeStartTime],
	INSERTED.[IsActive],
	INSERTED.[CID],
	INSERTED.[EndTime],
	INSERTED.[SortOrder],
	INSERTED.[Remark],
	INSERTED.[ChargeTypeCount]
into @table
WHERE 
	[ChargeFee].[ID] = @ID

SELECT 
	[ID],
	[UnitPrice],
	[StartTime],
	[EndTypeID],
	[AddTime],
	[ChargeID],
	[ChangeUnitPrice],
	[ChangeStartTime],
	[IsActive],
	[CID],
	[EndTime],
	[SortOrder],
	[Remark],
	[ChargeTypeCount] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTypeID", EntityBase.GetDatabaseValue(@endTypeID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@ChangeUnitPrice", EntityBase.GetDatabaseValue(@changeUnitPrice)));
			parameters.Add(new SqlParameter("@ChangeStartTime", EntityBase.GetDatabaseValue(@changeStartTime)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@CID", EntityBase.GetDatabaseValue(@cID)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@ChargeTypeCount", EntityBase.GetDatabaseValue(@chargeTypeCount)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ChargeFee from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteChargeFee(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteChargeFee(@iD, helper);
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
		/// Deletes a ChargeFee from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteChargeFee(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ChargeFee]
WHERE 
	[ChargeFee].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ChargeFee object.
		/// </summary>
		/// <returns>The newly created ChargeFee object.</returns>
		public static ChargeFee CreateChargeFee()
		{
			return InitializeNew<ChargeFee>();
		}
		
		/// <summary>
		/// Retrieve information for a ChargeFee by a ChargeFee's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ChargeFee</returns>
		public static ChargeFee GetChargeFee(int @iD)
		{
			string commandText = @"
SELECT 
" + ChargeFee.SelectFieldList + @"
FROM [dbo].[ChargeFee] 
WHERE 
	[ChargeFee].[ID] = @ID " + ChargeFee.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeFee>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ChargeFee by a ChargeFee's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ChargeFee</returns>
		public static ChargeFee GetChargeFee(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ChargeFee.SelectFieldList + @"
FROM [dbo].[ChargeFee] 
WHERE 
	[ChargeFee].[ID] = @ID " + ChargeFee.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeFee>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ChargeFee objects.
		/// </summary>
		/// <returns>The retrieved collection of ChargeFee objects.</returns>
		public static EntityList<ChargeFee> GetChargeFees()
		{
			string commandText = @"
SELECT " + ChargeFee.SelectFieldList + "FROM [dbo].[ChargeFee] " + ChargeFee.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ChargeFee>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ChargeFee objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeFee objects.</returns>
        public static EntityList<ChargeFee> GetChargeFees(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeFee>(SelectFieldList, "FROM [dbo].[ChargeFee]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ChargeFee objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeFee objects.</returns>
        public static EntityList<ChargeFee> GetChargeFees(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeFee>(SelectFieldList, "FROM [dbo].[ChargeFee]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ChargeFee objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ChargeFee objects.</returns>
		protected static EntityList<ChargeFee> GetChargeFees(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeFees(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ChargeFee objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeFee objects.</returns>
		protected static EntityList<ChargeFee> GetChargeFees(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeFees(string.Empty, where, parameters, ChargeFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeFee objects.</returns>
		protected static EntityList<ChargeFee> GetChargeFees(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeFees(prefix, where, parameters, ChargeFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeFee objects.</returns>
		protected static EntityList<ChargeFee> GetChargeFees(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeFees(string.Empty, where, parameters, ChargeFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeFee objects.</returns>
		protected static EntityList<ChargeFee> GetChargeFees(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeFees(prefix, where, parameters, ChargeFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeFee objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ChargeFee objects.</returns>
		protected static EntityList<ChargeFee> GetChargeFees(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ChargeFee.SelectFieldList + "FROM [dbo].[ChargeFee] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ChargeFee>(reader);
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
        protected static EntityList<ChargeFee> GetChargeFees(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeFee>(SelectFieldList, "FROM [dbo].[ChargeFee] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ChargeFee objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargeFeeCount()
        {
            return GetChargeFeeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ChargeFee objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargeFeeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ChargeFee] " + where;

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
		public static partial class ChargeFee_Properties
		{
			public const string ID = "ID";
			public const string UnitPrice = "UnitPrice";
			public const string StartTime = "StartTime";
			public const string EndTypeID = "EndTypeID";
			public const string AddTime = "AddTime";
			public const string ChargeID = "ChargeID";
			public const string ChangeUnitPrice = "ChangeUnitPrice";
			public const string ChangeStartTime = "ChangeStartTime";
			public const string IsActive = "IsActive";
			public const string CID = "CID";
			public const string EndTime = "EndTime";
			public const string SortOrder = "SortOrder";
			public const string Remark = "Remark";
			public const string ChargeTypeCount = "ChargeTypeCount";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTypeID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"ChargeID" , "int:"},
    			 {"ChangeUnitPrice" , "decimal:"},
    			 {"ChangeStartTime" , "DateTime:"},
    			 {"IsActive" , "bool:"},
    			 {"CID" , "int:"},
    			 {"EndTime" , "DateTime:"},
    			 {"SortOrder" , "int:"},
    			 {"Remark" , "string:"},
    			 {"ChargeTypeCount" , "int:"},
            };
		}
		#endregion
	}
}
