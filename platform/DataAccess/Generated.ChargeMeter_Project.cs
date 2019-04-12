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
	/// This object represents the properties and methods of a ChargeMeter_Project.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ChargeMeter_Project 
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
		private int _projectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ProjectID
		{
			[DebuggerStepThrough()]
			get { return this._projectID; }
			set 
			{
				if (this._projectID != value) 
				{
					this._projectID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _meterID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int MeterID
		{
			[DebuggerStepThrough()]
			get { return this._meterID; }
			set 
			{
				if (this._meterID != value) 
				{
					this._meterID = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _meterName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string MeterName
		{
			[DebuggerStepThrough()]
			get { return this._meterName; }
			set 
			{
				if (this._meterName != value) 
				{
					this._meterName = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _meterNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string MeterNumber
		{
			[DebuggerStepThrough()]
			get { return this._meterNumber; }
			set 
			{
				if (this._meterNumber != value) 
				{
					this._meterNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _meterCategoryID = int.MinValue;
		/// <summary>
		/// 1-水表 2-电表 3-气表
		/// </summary>
        [Description("1-水表 2-电表 3-气表")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int MeterCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._meterCategoryID; }
			set 
			{
				if (this._meterCategoryID != value) 
				{
					this._meterCategoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterCategoryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _meterType = int.MinValue;
		/// <summary>
		/// 1-住户 2-公共
		/// </summary>
        [Description("1-住户 2-公共")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int MeterType
		{
			[DebuggerStepThrough()]
			get { return this._meterType; }
			set 
			{
				if (this._meterType != value) 
				{
					this._meterType = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _meterSpec = int.MinValue;
		/// <summary>
		/// 1-分表 2-总表
		/// </summary>
        [Description("1-分表 2-总表")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int MeterSpec
		{
			[DebuggerStepThrough()]
			get { return this._meterSpec; }
			set 
			{
				if (this._meterSpec != value) 
				{
					this._meterSpec = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterSpec");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _meterCoefficient = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal MeterCoefficient
		{
			[DebuggerStepThrough()]
			get { return this._meterCoefficient; }
			set 
			{
				if (this._meterCoefficient != value) 
				{
					this._meterCoefficient = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterCoefficient");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _meterRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string MeterRemark
		{
			[DebuggerStepThrough()]
			get { return this._meterRemark; }
			set 
			{
				if (this._meterRemark != value) 
				{
					this._meterRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterRemark");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _meterChargeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int MeterChargeID
		{
			[DebuggerStepThrough()]
			get { return this._meterChargeID; }
			set 
			{
				if (this._meterChargeID != value) 
				{
					this._meterChargeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterChargeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _meterHouseNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string MeterHouseNo
		{
			[DebuggerStepThrough()]
			get { return this._meterHouseNo; }
			set 
			{
				if (this._meterHouseNo != value) 
				{
					this._meterHouseNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterHouseNo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _meterLocation = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string MeterLocation
		{
			[DebuggerStepThrough()]
			get { return this._meterLocation; }
			set 
			{
				if (this._meterLocation != value) 
				{
					this._meterLocation = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterLocation");
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
		private decimal _meterStartPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal MeterStartPoint
		{
			[DebuggerStepThrough()]
			get { return this._meterStartPoint; }
			set 
			{
				if (this._meterStartPoint != value) 
				{
					this._meterStartPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterStartPoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _meterEndPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal MeterEndPoint
		{
			[DebuggerStepThrough()]
			get { return this._meterEndPoint; }
			set 
			{
				if (this._meterEndPoint != value) 
				{
					this._meterEndPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterEndPoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _meterTotalPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal MeterTotalPoint
		{
			[DebuggerStepThrough()]
			get { return this._meterTotalPoint; }
			set 
			{
				if (this._meterTotalPoint != value) 
				{
					this._meterTotalPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterTotalPoint");
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
		private string _addUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string AddUserName
		{
			[DebuggerStepThrough()]
			get { return this._addUserName; }
			set 
			{
				if (this._addUserName != value) 
				{
					this._addUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUserName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _writeStatus = int.MinValue;
		/// <summary>
		/// 0-开始抄表 1-结束抄表
		/// </summary>
        [Description("0-开始抄表 1-结束抄表")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int WriteStatus
		{
			[DebuggerStepThrough()]
			get { return this._writeStatus; }
			set 
			{
				if (this._writeStatus != value) 
				{
					this._writeStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("WriteStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _feeStatus = int.MinValue;
		/// <summary>
		/// 0-未生成 1-已生成
		/// </summary>
        [Description("0-未生成 1-已生成")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int FeeStatus
		{
			[DebuggerStepThrough()]
			get { return this._feeStatus; }
			set 
			{
				if (this._feeStatus != value) 
				{
					this._feeStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("FeeStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _writeDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime WriteDate
		{
			[DebuggerStepThrough()]
			get { return this._writeDate; }
			set 
			{
				if (this._writeDate != value) 
				{
					this._writeDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("WriteDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _writeUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string WriteUserName
		{
			[DebuggerStepThrough()]
			get { return this._writeUserName; }
			set 
			{
				if (this._writeUserName != value) 
				{
					this._writeUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("WriteUserName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAPPWriteEnable = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAPPWriteEnable
		{
			[DebuggerStepThrough()]
			get { return this._isAPPWriteEnable; }
			set 
			{
				if (this._isAPPWriteEnable != value) 
				{
					this._isAPPWriteEnable = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAPPWriteEnable");
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
	[ProjectID] int,
	[MeterID] int,
	[MeterName] nvarchar(50),
	[MeterNumber] nvarchar(200),
	[MeterCategoryID] int,
	[MeterType] int,
	[MeterSpec] int,
	[MeterCoefficient] decimal(18, 4),
	[MeterRemark] ntext,
	[MeterChargeID] int,
	[MeterHouseNo] nvarchar(200),
	[MeterLocation] nvarchar(200),
	[SortOrder] int,
	[MeterStartPoint] decimal(18, 2),
	[MeterEndPoint] decimal(18, 2),
	[MeterTotalPoint] decimal(18, 2),
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[WriteStatus] int,
	[FeeStatus] int,
	[WriteDate] datetime,
	[WriteUserName] nvarchar(100),
	[IsAPPWriteEnable] bit
);

INSERT INTO [dbo].[ChargeMeter_Project] (
	[ChargeMeter_Project].[ProjectID],
	[ChargeMeter_Project].[MeterID],
	[ChargeMeter_Project].[MeterName],
	[ChargeMeter_Project].[MeterNumber],
	[ChargeMeter_Project].[MeterCategoryID],
	[ChargeMeter_Project].[MeterType],
	[ChargeMeter_Project].[MeterSpec],
	[ChargeMeter_Project].[MeterCoefficient],
	[ChargeMeter_Project].[MeterRemark],
	[ChargeMeter_Project].[MeterChargeID],
	[ChargeMeter_Project].[MeterHouseNo],
	[ChargeMeter_Project].[MeterLocation],
	[ChargeMeter_Project].[SortOrder],
	[ChargeMeter_Project].[MeterStartPoint],
	[ChargeMeter_Project].[MeterEndPoint],
	[ChargeMeter_Project].[MeterTotalPoint],
	[ChargeMeter_Project].[AddTime],
	[ChargeMeter_Project].[AddUserName],
	[ChargeMeter_Project].[WriteStatus],
	[ChargeMeter_Project].[FeeStatus],
	[ChargeMeter_Project].[WriteDate],
	[ChargeMeter_Project].[WriteUserName],
	[ChargeMeter_Project].[IsAPPWriteEnable]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[MeterID],
	INSERTED.[MeterName],
	INSERTED.[MeterNumber],
	INSERTED.[MeterCategoryID],
	INSERTED.[MeterType],
	INSERTED.[MeterSpec],
	INSERTED.[MeterCoefficient],
	INSERTED.[MeterRemark],
	INSERTED.[MeterChargeID],
	INSERTED.[MeterHouseNo],
	INSERTED.[MeterLocation],
	INSERTED.[SortOrder],
	INSERTED.[MeterStartPoint],
	INSERTED.[MeterEndPoint],
	INSERTED.[MeterTotalPoint],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[WriteStatus],
	INSERTED.[FeeStatus],
	INSERTED.[WriteDate],
	INSERTED.[WriteUserName],
	INSERTED.[IsAPPWriteEnable]
into @table
VALUES ( 
	@ProjectID,
	@MeterID,
	@MeterName,
	@MeterNumber,
	@MeterCategoryID,
	@MeterType,
	@MeterSpec,
	@MeterCoefficient,
	@MeterRemark,
	@MeterChargeID,
	@MeterHouseNo,
	@MeterLocation,
	@SortOrder,
	@MeterStartPoint,
	@MeterEndPoint,
	@MeterTotalPoint,
	@AddTime,
	@AddUserName,
	@WriteStatus,
	@FeeStatus,
	@WriteDate,
	@WriteUserName,
	@IsAPPWriteEnable 
); 

SELECT 
	[ID],
	[ProjectID],
	[MeterID],
	[MeterName],
	[MeterNumber],
	[MeterCategoryID],
	[MeterType],
	[MeterSpec],
	[MeterCoefficient],
	[MeterRemark],
	[MeterChargeID],
	[MeterHouseNo],
	[MeterLocation],
	[SortOrder],
	[MeterStartPoint],
	[MeterEndPoint],
	[MeterTotalPoint],
	[AddTime],
	[AddUserName],
	[WriteStatus],
	[FeeStatus],
	[WriteDate],
	[WriteUserName],
	[IsAPPWriteEnable] 
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
	[ProjectID] int,
	[MeterID] int,
	[MeterName] nvarchar(50),
	[MeterNumber] nvarchar(200),
	[MeterCategoryID] int,
	[MeterType] int,
	[MeterSpec] int,
	[MeterCoefficient] decimal(18, 4),
	[MeterRemark] ntext,
	[MeterChargeID] int,
	[MeterHouseNo] nvarchar(200),
	[MeterLocation] nvarchar(200),
	[SortOrder] int,
	[MeterStartPoint] decimal(18, 2),
	[MeterEndPoint] decimal(18, 2),
	[MeterTotalPoint] decimal(18, 2),
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[WriteStatus] int,
	[FeeStatus] int,
	[WriteDate] datetime,
	[WriteUserName] nvarchar(100),
	[IsAPPWriteEnable] bit
);

UPDATE [dbo].[ChargeMeter_Project] SET 
	[ChargeMeter_Project].[ProjectID] = @ProjectID,
	[ChargeMeter_Project].[MeterID] = @MeterID,
	[ChargeMeter_Project].[MeterName] = @MeterName,
	[ChargeMeter_Project].[MeterNumber] = @MeterNumber,
	[ChargeMeter_Project].[MeterCategoryID] = @MeterCategoryID,
	[ChargeMeter_Project].[MeterType] = @MeterType,
	[ChargeMeter_Project].[MeterSpec] = @MeterSpec,
	[ChargeMeter_Project].[MeterCoefficient] = @MeterCoefficient,
	[ChargeMeter_Project].[MeterRemark] = @MeterRemark,
	[ChargeMeter_Project].[MeterChargeID] = @MeterChargeID,
	[ChargeMeter_Project].[MeterHouseNo] = @MeterHouseNo,
	[ChargeMeter_Project].[MeterLocation] = @MeterLocation,
	[ChargeMeter_Project].[SortOrder] = @SortOrder,
	[ChargeMeter_Project].[MeterStartPoint] = @MeterStartPoint,
	[ChargeMeter_Project].[MeterEndPoint] = @MeterEndPoint,
	[ChargeMeter_Project].[MeterTotalPoint] = @MeterTotalPoint,
	[ChargeMeter_Project].[AddTime] = @AddTime,
	[ChargeMeter_Project].[AddUserName] = @AddUserName,
	[ChargeMeter_Project].[WriteStatus] = @WriteStatus,
	[ChargeMeter_Project].[FeeStatus] = @FeeStatus,
	[ChargeMeter_Project].[WriteDate] = @WriteDate,
	[ChargeMeter_Project].[WriteUserName] = @WriteUserName,
	[ChargeMeter_Project].[IsAPPWriteEnable] = @IsAPPWriteEnable 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[MeterID],
	INSERTED.[MeterName],
	INSERTED.[MeterNumber],
	INSERTED.[MeterCategoryID],
	INSERTED.[MeterType],
	INSERTED.[MeterSpec],
	INSERTED.[MeterCoefficient],
	INSERTED.[MeterRemark],
	INSERTED.[MeterChargeID],
	INSERTED.[MeterHouseNo],
	INSERTED.[MeterLocation],
	INSERTED.[SortOrder],
	INSERTED.[MeterStartPoint],
	INSERTED.[MeterEndPoint],
	INSERTED.[MeterTotalPoint],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[WriteStatus],
	INSERTED.[FeeStatus],
	INSERTED.[WriteDate],
	INSERTED.[WriteUserName],
	INSERTED.[IsAPPWriteEnable]
into @table
WHERE 
	[ChargeMeter_Project].[ID] = @ID

SELECT 
	[ID],
	[ProjectID],
	[MeterID],
	[MeterName],
	[MeterNumber],
	[MeterCategoryID],
	[MeterType],
	[MeterSpec],
	[MeterCoefficient],
	[MeterRemark],
	[MeterChargeID],
	[MeterHouseNo],
	[MeterLocation],
	[SortOrder],
	[MeterStartPoint],
	[MeterEndPoint],
	[MeterTotalPoint],
	[AddTime],
	[AddUserName],
	[WriteStatus],
	[FeeStatus],
	[WriteDate],
	[WriteUserName],
	[IsAPPWriteEnable] 
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
DELETE FROM [dbo].[ChargeMeter_Project]
WHERE 
	[ChargeMeter_Project].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ChargeMeter_Project() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetChargeMeter_Project(this.ID));
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
	[ChargeMeter_Project].[ID],
	[ChargeMeter_Project].[ProjectID],
	[ChargeMeter_Project].[MeterID],
	[ChargeMeter_Project].[MeterName],
	[ChargeMeter_Project].[MeterNumber],
	[ChargeMeter_Project].[MeterCategoryID],
	[ChargeMeter_Project].[MeterType],
	[ChargeMeter_Project].[MeterSpec],
	[ChargeMeter_Project].[MeterCoefficient],
	[ChargeMeter_Project].[MeterRemark],
	[ChargeMeter_Project].[MeterChargeID],
	[ChargeMeter_Project].[MeterHouseNo],
	[ChargeMeter_Project].[MeterLocation],
	[ChargeMeter_Project].[SortOrder],
	[ChargeMeter_Project].[MeterStartPoint],
	[ChargeMeter_Project].[MeterEndPoint],
	[ChargeMeter_Project].[MeterTotalPoint],
	[ChargeMeter_Project].[AddTime],
	[ChargeMeter_Project].[AddUserName],
	[ChargeMeter_Project].[WriteStatus],
	[ChargeMeter_Project].[FeeStatus],
	[ChargeMeter_Project].[WriteDate],
	[ChargeMeter_Project].[WriteUserName],
	[ChargeMeter_Project].[IsAPPWriteEnable]
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
                return "ChargeMeter_Project";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ChargeMeter_Project into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="meterID">meterID</param>
		/// <param name="meterName">meterName</param>
		/// <param name="meterNumber">meterNumber</param>
		/// <param name="meterCategoryID">meterCategoryID</param>
		/// <param name="meterType">meterType</param>
		/// <param name="meterSpec">meterSpec</param>
		/// <param name="meterCoefficient">meterCoefficient</param>
		/// <param name="meterRemark">meterRemark</param>
		/// <param name="meterChargeID">meterChargeID</param>
		/// <param name="meterHouseNo">meterHouseNo</param>
		/// <param name="meterLocation">meterLocation</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="meterStartPoint">meterStartPoint</param>
		/// <param name="meterEndPoint">meterEndPoint</param>
		/// <param name="meterTotalPoint">meterTotalPoint</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="writeStatus">writeStatus</param>
		/// <param name="feeStatus">feeStatus</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="writeUserName">writeUserName</param>
		/// <param name="isAPPWriteEnable">isAPPWriteEnable</param>
		public static void InsertChargeMeter_Project(int @projectID, int @meterID, string @meterName, string @meterNumber, int @meterCategoryID, int @meterType, int @meterSpec, decimal @meterCoefficient, string @meterRemark, int @meterChargeID, string @meterHouseNo, string @meterLocation, int @sortOrder, decimal @meterStartPoint, decimal @meterEndPoint, decimal @meterTotalPoint, DateTime @addTime, string @addUserName, int @writeStatus, int @feeStatus, DateTime @writeDate, string @writeUserName, bool @isAPPWriteEnable)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertChargeMeter_Project(@projectID, @meterID, @meterName, @meterNumber, @meterCategoryID, @meterType, @meterSpec, @meterCoefficient, @meterRemark, @meterChargeID, @meterHouseNo, @meterLocation, @sortOrder, @meterStartPoint, @meterEndPoint, @meterTotalPoint, @addTime, @addUserName, @writeStatus, @feeStatus, @writeDate, @writeUserName, @isAPPWriteEnable, helper);
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
		/// Insert a ChargeMeter_Project into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="meterID">meterID</param>
		/// <param name="meterName">meterName</param>
		/// <param name="meterNumber">meterNumber</param>
		/// <param name="meterCategoryID">meterCategoryID</param>
		/// <param name="meterType">meterType</param>
		/// <param name="meterSpec">meterSpec</param>
		/// <param name="meterCoefficient">meterCoefficient</param>
		/// <param name="meterRemark">meterRemark</param>
		/// <param name="meterChargeID">meterChargeID</param>
		/// <param name="meterHouseNo">meterHouseNo</param>
		/// <param name="meterLocation">meterLocation</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="meterStartPoint">meterStartPoint</param>
		/// <param name="meterEndPoint">meterEndPoint</param>
		/// <param name="meterTotalPoint">meterTotalPoint</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="writeStatus">writeStatus</param>
		/// <param name="feeStatus">feeStatus</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="writeUserName">writeUserName</param>
		/// <param name="isAPPWriteEnable">isAPPWriteEnable</param>
		/// <param name="helper">helper</param>
		internal static void InsertChargeMeter_Project(int @projectID, int @meterID, string @meterName, string @meterNumber, int @meterCategoryID, int @meterType, int @meterSpec, decimal @meterCoefficient, string @meterRemark, int @meterChargeID, string @meterHouseNo, string @meterLocation, int @sortOrder, decimal @meterStartPoint, decimal @meterEndPoint, decimal @meterTotalPoint, DateTime @addTime, string @addUserName, int @writeStatus, int @feeStatus, DateTime @writeDate, string @writeUserName, bool @isAPPWriteEnable, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectID] int,
	[MeterID] int,
	[MeterName] nvarchar(50),
	[MeterNumber] nvarchar(200),
	[MeterCategoryID] int,
	[MeterType] int,
	[MeterSpec] int,
	[MeterCoefficient] decimal(18, 4),
	[MeterRemark] ntext,
	[MeterChargeID] int,
	[MeterHouseNo] nvarchar(200),
	[MeterLocation] nvarchar(200),
	[SortOrder] int,
	[MeterStartPoint] decimal(18, 2),
	[MeterEndPoint] decimal(18, 2),
	[MeterTotalPoint] decimal(18, 2),
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[WriteStatus] int,
	[FeeStatus] int,
	[WriteDate] datetime,
	[WriteUserName] nvarchar(100),
	[IsAPPWriteEnable] bit
);

INSERT INTO [dbo].[ChargeMeter_Project] (
	[ChargeMeter_Project].[ProjectID],
	[ChargeMeter_Project].[MeterID],
	[ChargeMeter_Project].[MeterName],
	[ChargeMeter_Project].[MeterNumber],
	[ChargeMeter_Project].[MeterCategoryID],
	[ChargeMeter_Project].[MeterType],
	[ChargeMeter_Project].[MeterSpec],
	[ChargeMeter_Project].[MeterCoefficient],
	[ChargeMeter_Project].[MeterRemark],
	[ChargeMeter_Project].[MeterChargeID],
	[ChargeMeter_Project].[MeterHouseNo],
	[ChargeMeter_Project].[MeterLocation],
	[ChargeMeter_Project].[SortOrder],
	[ChargeMeter_Project].[MeterStartPoint],
	[ChargeMeter_Project].[MeterEndPoint],
	[ChargeMeter_Project].[MeterTotalPoint],
	[ChargeMeter_Project].[AddTime],
	[ChargeMeter_Project].[AddUserName],
	[ChargeMeter_Project].[WriteStatus],
	[ChargeMeter_Project].[FeeStatus],
	[ChargeMeter_Project].[WriteDate],
	[ChargeMeter_Project].[WriteUserName],
	[ChargeMeter_Project].[IsAPPWriteEnable]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[MeterID],
	INSERTED.[MeterName],
	INSERTED.[MeterNumber],
	INSERTED.[MeterCategoryID],
	INSERTED.[MeterType],
	INSERTED.[MeterSpec],
	INSERTED.[MeterCoefficient],
	INSERTED.[MeterRemark],
	INSERTED.[MeterChargeID],
	INSERTED.[MeterHouseNo],
	INSERTED.[MeterLocation],
	INSERTED.[SortOrder],
	INSERTED.[MeterStartPoint],
	INSERTED.[MeterEndPoint],
	INSERTED.[MeterTotalPoint],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[WriteStatus],
	INSERTED.[FeeStatus],
	INSERTED.[WriteDate],
	INSERTED.[WriteUserName],
	INSERTED.[IsAPPWriteEnable]
into @table
VALUES ( 
	@ProjectID,
	@MeterID,
	@MeterName,
	@MeterNumber,
	@MeterCategoryID,
	@MeterType,
	@MeterSpec,
	@MeterCoefficient,
	@MeterRemark,
	@MeterChargeID,
	@MeterHouseNo,
	@MeterLocation,
	@SortOrder,
	@MeterStartPoint,
	@MeterEndPoint,
	@MeterTotalPoint,
	@AddTime,
	@AddUserName,
	@WriteStatus,
	@FeeStatus,
	@WriteDate,
	@WriteUserName,
	@IsAPPWriteEnable 
); 

SELECT 
	[ID],
	[ProjectID],
	[MeterID],
	[MeterName],
	[MeterNumber],
	[MeterCategoryID],
	[MeterType],
	[MeterSpec],
	[MeterCoefficient],
	[MeterRemark],
	[MeterChargeID],
	[MeterHouseNo],
	[MeterLocation],
	[SortOrder],
	[MeterStartPoint],
	[MeterEndPoint],
	[MeterTotalPoint],
	[AddTime],
	[AddUserName],
	[WriteStatus],
	[FeeStatus],
	[WriteDate],
	[WriteUserName],
	[IsAPPWriteEnable] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@MeterID", EntityBase.GetDatabaseValue(@meterID)));
			parameters.Add(new SqlParameter("@MeterName", EntityBase.GetDatabaseValue(@meterName)));
			parameters.Add(new SqlParameter("@MeterNumber", EntityBase.GetDatabaseValue(@meterNumber)));
			parameters.Add(new SqlParameter("@MeterCategoryID", EntityBase.GetDatabaseValue(@meterCategoryID)));
			parameters.Add(new SqlParameter("@MeterType", EntityBase.GetDatabaseValue(@meterType)));
			parameters.Add(new SqlParameter("@MeterSpec", EntityBase.GetDatabaseValue(@meterSpec)));
			parameters.Add(new SqlParameter("@MeterCoefficient", EntityBase.GetDatabaseValue(@meterCoefficient)));
			parameters.Add(new SqlParameter("@MeterRemark", EntityBase.GetDatabaseValue(@meterRemark)));
			parameters.Add(new SqlParameter("@MeterChargeID", EntityBase.GetDatabaseValue(@meterChargeID)));
			parameters.Add(new SqlParameter("@MeterHouseNo", EntityBase.GetDatabaseValue(@meterHouseNo)));
			parameters.Add(new SqlParameter("@MeterLocation", EntityBase.GetDatabaseValue(@meterLocation)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@MeterStartPoint", EntityBase.GetDatabaseValue(@meterStartPoint)));
			parameters.Add(new SqlParameter("@MeterEndPoint", EntityBase.GetDatabaseValue(@meterEndPoint)));
			parameters.Add(new SqlParameter("@MeterTotalPoint", EntityBase.GetDatabaseValue(@meterTotalPoint)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@WriteStatus", EntityBase.GetDatabaseValue(@writeStatus)));
			parameters.Add(new SqlParameter("@FeeStatus", EntityBase.GetDatabaseValue(@feeStatus)));
			parameters.Add(new SqlParameter("@WriteDate", EntityBase.GetDatabaseValue(@writeDate)));
			parameters.Add(new SqlParameter("@WriteUserName", EntityBase.GetDatabaseValue(@writeUserName)));
			parameters.Add(new SqlParameter("@IsAPPWriteEnable", @isAPPWriteEnable));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ChargeMeter_Project into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectID">projectID</param>
		/// <param name="meterID">meterID</param>
		/// <param name="meterName">meterName</param>
		/// <param name="meterNumber">meterNumber</param>
		/// <param name="meterCategoryID">meterCategoryID</param>
		/// <param name="meterType">meterType</param>
		/// <param name="meterSpec">meterSpec</param>
		/// <param name="meterCoefficient">meterCoefficient</param>
		/// <param name="meterRemark">meterRemark</param>
		/// <param name="meterChargeID">meterChargeID</param>
		/// <param name="meterHouseNo">meterHouseNo</param>
		/// <param name="meterLocation">meterLocation</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="meterStartPoint">meterStartPoint</param>
		/// <param name="meterEndPoint">meterEndPoint</param>
		/// <param name="meterTotalPoint">meterTotalPoint</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="writeStatus">writeStatus</param>
		/// <param name="feeStatus">feeStatus</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="writeUserName">writeUserName</param>
		/// <param name="isAPPWriteEnable">isAPPWriteEnable</param>
		public static void UpdateChargeMeter_Project(int @iD, int @projectID, int @meterID, string @meterName, string @meterNumber, int @meterCategoryID, int @meterType, int @meterSpec, decimal @meterCoefficient, string @meterRemark, int @meterChargeID, string @meterHouseNo, string @meterLocation, int @sortOrder, decimal @meterStartPoint, decimal @meterEndPoint, decimal @meterTotalPoint, DateTime @addTime, string @addUserName, int @writeStatus, int @feeStatus, DateTime @writeDate, string @writeUserName, bool @isAPPWriteEnable)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateChargeMeter_Project(@iD, @projectID, @meterID, @meterName, @meterNumber, @meterCategoryID, @meterType, @meterSpec, @meterCoefficient, @meterRemark, @meterChargeID, @meterHouseNo, @meterLocation, @sortOrder, @meterStartPoint, @meterEndPoint, @meterTotalPoint, @addTime, @addUserName, @writeStatus, @feeStatus, @writeDate, @writeUserName, @isAPPWriteEnable, helper);
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
		/// Updates a ChargeMeter_Project into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectID">projectID</param>
		/// <param name="meterID">meterID</param>
		/// <param name="meterName">meterName</param>
		/// <param name="meterNumber">meterNumber</param>
		/// <param name="meterCategoryID">meterCategoryID</param>
		/// <param name="meterType">meterType</param>
		/// <param name="meterSpec">meterSpec</param>
		/// <param name="meterCoefficient">meterCoefficient</param>
		/// <param name="meterRemark">meterRemark</param>
		/// <param name="meterChargeID">meterChargeID</param>
		/// <param name="meterHouseNo">meterHouseNo</param>
		/// <param name="meterLocation">meterLocation</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="meterStartPoint">meterStartPoint</param>
		/// <param name="meterEndPoint">meterEndPoint</param>
		/// <param name="meterTotalPoint">meterTotalPoint</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="writeStatus">writeStatus</param>
		/// <param name="feeStatus">feeStatus</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="writeUserName">writeUserName</param>
		/// <param name="isAPPWriteEnable">isAPPWriteEnable</param>
		/// <param name="helper">helper</param>
		internal static void UpdateChargeMeter_Project(int @iD, int @projectID, int @meterID, string @meterName, string @meterNumber, int @meterCategoryID, int @meterType, int @meterSpec, decimal @meterCoefficient, string @meterRemark, int @meterChargeID, string @meterHouseNo, string @meterLocation, int @sortOrder, decimal @meterStartPoint, decimal @meterEndPoint, decimal @meterTotalPoint, DateTime @addTime, string @addUserName, int @writeStatus, int @feeStatus, DateTime @writeDate, string @writeUserName, bool @isAPPWriteEnable, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectID] int,
	[MeterID] int,
	[MeterName] nvarchar(50),
	[MeterNumber] nvarchar(200),
	[MeterCategoryID] int,
	[MeterType] int,
	[MeterSpec] int,
	[MeterCoefficient] decimal(18, 4),
	[MeterRemark] ntext,
	[MeterChargeID] int,
	[MeterHouseNo] nvarchar(200),
	[MeterLocation] nvarchar(200),
	[SortOrder] int,
	[MeterStartPoint] decimal(18, 2),
	[MeterEndPoint] decimal(18, 2),
	[MeterTotalPoint] decimal(18, 2),
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[WriteStatus] int,
	[FeeStatus] int,
	[WriteDate] datetime,
	[WriteUserName] nvarchar(100),
	[IsAPPWriteEnable] bit
);

UPDATE [dbo].[ChargeMeter_Project] SET 
	[ChargeMeter_Project].[ProjectID] = @ProjectID,
	[ChargeMeter_Project].[MeterID] = @MeterID,
	[ChargeMeter_Project].[MeterName] = @MeterName,
	[ChargeMeter_Project].[MeterNumber] = @MeterNumber,
	[ChargeMeter_Project].[MeterCategoryID] = @MeterCategoryID,
	[ChargeMeter_Project].[MeterType] = @MeterType,
	[ChargeMeter_Project].[MeterSpec] = @MeterSpec,
	[ChargeMeter_Project].[MeterCoefficient] = @MeterCoefficient,
	[ChargeMeter_Project].[MeterRemark] = @MeterRemark,
	[ChargeMeter_Project].[MeterChargeID] = @MeterChargeID,
	[ChargeMeter_Project].[MeterHouseNo] = @MeterHouseNo,
	[ChargeMeter_Project].[MeterLocation] = @MeterLocation,
	[ChargeMeter_Project].[SortOrder] = @SortOrder,
	[ChargeMeter_Project].[MeterStartPoint] = @MeterStartPoint,
	[ChargeMeter_Project].[MeterEndPoint] = @MeterEndPoint,
	[ChargeMeter_Project].[MeterTotalPoint] = @MeterTotalPoint,
	[ChargeMeter_Project].[AddTime] = @AddTime,
	[ChargeMeter_Project].[AddUserName] = @AddUserName,
	[ChargeMeter_Project].[WriteStatus] = @WriteStatus,
	[ChargeMeter_Project].[FeeStatus] = @FeeStatus,
	[ChargeMeter_Project].[WriteDate] = @WriteDate,
	[ChargeMeter_Project].[WriteUserName] = @WriteUserName,
	[ChargeMeter_Project].[IsAPPWriteEnable] = @IsAPPWriteEnable 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[MeterID],
	INSERTED.[MeterName],
	INSERTED.[MeterNumber],
	INSERTED.[MeterCategoryID],
	INSERTED.[MeterType],
	INSERTED.[MeterSpec],
	INSERTED.[MeterCoefficient],
	INSERTED.[MeterRemark],
	INSERTED.[MeterChargeID],
	INSERTED.[MeterHouseNo],
	INSERTED.[MeterLocation],
	INSERTED.[SortOrder],
	INSERTED.[MeterStartPoint],
	INSERTED.[MeterEndPoint],
	INSERTED.[MeterTotalPoint],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[WriteStatus],
	INSERTED.[FeeStatus],
	INSERTED.[WriteDate],
	INSERTED.[WriteUserName],
	INSERTED.[IsAPPWriteEnable]
into @table
WHERE 
	[ChargeMeter_Project].[ID] = @ID

SELECT 
	[ID],
	[ProjectID],
	[MeterID],
	[MeterName],
	[MeterNumber],
	[MeterCategoryID],
	[MeterType],
	[MeterSpec],
	[MeterCoefficient],
	[MeterRemark],
	[MeterChargeID],
	[MeterHouseNo],
	[MeterLocation],
	[SortOrder],
	[MeterStartPoint],
	[MeterEndPoint],
	[MeterTotalPoint],
	[AddTime],
	[AddUserName],
	[WriteStatus],
	[FeeStatus],
	[WriteDate],
	[WriteUserName],
	[IsAPPWriteEnable] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@MeterID", EntityBase.GetDatabaseValue(@meterID)));
			parameters.Add(new SqlParameter("@MeterName", EntityBase.GetDatabaseValue(@meterName)));
			parameters.Add(new SqlParameter("@MeterNumber", EntityBase.GetDatabaseValue(@meterNumber)));
			parameters.Add(new SqlParameter("@MeterCategoryID", EntityBase.GetDatabaseValue(@meterCategoryID)));
			parameters.Add(new SqlParameter("@MeterType", EntityBase.GetDatabaseValue(@meterType)));
			parameters.Add(new SqlParameter("@MeterSpec", EntityBase.GetDatabaseValue(@meterSpec)));
			parameters.Add(new SqlParameter("@MeterCoefficient", EntityBase.GetDatabaseValue(@meterCoefficient)));
			parameters.Add(new SqlParameter("@MeterRemark", EntityBase.GetDatabaseValue(@meterRemark)));
			parameters.Add(new SqlParameter("@MeterChargeID", EntityBase.GetDatabaseValue(@meterChargeID)));
			parameters.Add(new SqlParameter("@MeterHouseNo", EntityBase.GetDatabaseValue(@meterHouseNo)));
			parameters.Add(new SqlParameter("@MeterLocation", EntityBase.GetDatabaseValue(@meterLocation)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@MeterStartPoint", EntityBase.GetDatabaseValue(@meterStartPoint)));
			parameters.Add(new SqlParameter("@MeterEndPoint", EntityBase.GetDatabaseValue(@meterEndPoint)));
			parameters.Add(new SqlParameter("@MeterTotalPoint", EntityBase.GetDatabaseValue(@meterTotalPoint)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@WriteStatus", EntityBase.GetDatabaseValue(@writeStatus)));
			parameters.Add(new SqlParameter("@FeeStatus", EntityBase.GetDatabaseValue(@feeStatus)));
			parameters.Add(new SqlParameter("@WriteDate", EntityBase.GetDatabaseValue(@writeDate)));
			parameters.Add(new SqlParameter("@WriteUserName", EntityBase.GetDatabaseValue(@writeUserName)));
			parameters.Add(new SqlParameter("@IsAPPWriteEnable", @isAPPWriteEnable));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ChargeMeter_Project from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteChargeMeter_Project(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteChargeMeter_Project(@iD, helper);
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
		/// Deletes a ChargeMeter_Project from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteChargeMeter_Project(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ChargeMeter_Project]
WHERE 
	[ChargeMeter_Project].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ChargeMeter_Project object.
		/// </summary>
		/// <returns>The newly created ChargeMeter_Project object.</returns>
		public static ChargeMeter_Project CreateChargeMeter_Project()
		{
			return InitializeNew<ChargeMeter_Project>();
		}
		
		/// <summary>
		/// Retrieve information for a ChargeMeter_Project by a ChargeMeter_Project's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ChargeMeter_Project</returns>
		public static ChargeMeter_Project GetChargeMeter_Project(int @iD)
		{
			string commandText = @"
SELECT 
" + ChargeMeter_Project.SelectFieldList + @"
FROM [dbo].[ChargeMeter_Project] 
WHERE 
	[ChargeMeter_Project].[ID] = @ID " + ChargeMeter_Project.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeMeter_Project>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ChargeMeter_Project by a ChargeMeter_Project's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ChargeMeter_Project</returns>
		public static ChargeMeter_Project GetChargeMeter_Project(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ChargeMeter_Project.SelectFieldList + @"
FROM [dbo].[ChargeMeter_Project] 
WHERE 
	[ChargeMeter_Project].[ID] = @ID " + ChargeMeter_Project.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeMeter_Project>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ChargeMeter_Project objects.
		/// </summary>
		/// <returns>The retrieved collection of ChargeMeter_Project objects.</returns>
		public static EntityList<ChargeMeter_Project> GetChargeMeter_Projects()
		{
			string commandText = @"
SELECT " + ChargeMeter_Project.SelectFieldList + "FROM [dbo].[ChargeMeter_Project] " + ChargeMeter_Project.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ChargeMeter_Project>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ChargeMeter_Project objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeMeter_Project objects.</returns>
        public static EntityList<ChargeMeter_Project> GetChargeMeter_Projects(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeMeter_Project>(SelectFieldList, "FROM [dbo].[ChargeMeter_Project]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ChargeMeter_Project objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeMeter_Project objects.</returns>
        public static EntityList<ChargeMeter_Project> GetChargeMeter_Projects(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeMeter_Project>(SelectFieldList, "FROM [dbo].[ChargeMeter_Project]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ChargeMeter_Project objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ChargeMeter_Project objects.</returns>
		protected static EntityList<ChargeMeter_Project> GetChargeMeter_Projects(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeMeter_Projects(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ChargeMeter_Project objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeMeter_Project objects.</returns>
		protected static EntityList<ChargeMeter_Project> GetChargeMeter_Projects(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeMeter_Projects(string.Empty, where, parameters, ChargeMeter_Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeMeter_Project objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeMeter_Project objects.</returns>
		protected static EntityList<ChargeMeter_Project> GetChargeMeter_Projects(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeMeter_Projects(prefix, where, parameters, ChargeMeter_Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeMeter_Project objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeMeter_Project objects.</returns>
		protected static EntityList<ChargeMeter_Project> GetChargeMeter_Projects(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeMeter_Projects(string.Empty, where, parameters, ChargeMeter_Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeMeter_Project objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeMeter_Project objects.</returns>
		protected static EntityList<ChargeMeter_Project> GetChargeMeter_Projects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeMeter_Projects(prefix, where, parameters, ChargeMeter_Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeMeter_Project objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ChargeMeter_Project objects.</returns>
		protected static EntityList<ChargeMeter_Project> GetChargeMeter_Projects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ChargeMeter_Project.SelectFieldList + "FROM [dbo].[ChargeMeter_Project] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ChargeMeter_Project>(reader);
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
        protected static EntityList<ChargeMeter_Project> GetChargeMeter_Projects(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeMeter_Project>(SelectFieldList, "FROM [dbo].[ChargeMeter_Project] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ChargeMeter_Project objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargeMeter_ProjectCount()
        {
            return GetChargeMeter_ProjectCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ChargeMeter_Project objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargeMeter_ProjectCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ChargeMeter_Project] " + where;

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
		public static partial class ChargeMeter_Project_Properties
		{
			public const string ID = "ID";
			public const string ProjectID = "ProjectID";
			public const string MeterID = "MeterID";
			public const string MeterName = "MeterName";
			public const string MeterNumber = "MeterNumber";
			public const string MeterCategoryID = "MeterCategoryID";
			public const string MeterType = "MeterType";
			public const string MeterSpec = "MeterSpec";
			public const string MeterCoefficient = "MeterCoefficient";
			public const string MeterRemark = "MeterRemark";
			public const string MeterChargeID = "MeterChargeID";
			public const string MeterHouseNo = "MeterHouseNo";
			public const string MeterLocation = "MeterLocation";
			public const string SortOrder = "SortOrder";
			public const string MeterStartPoint = "MeterStartPoint";
			public const string MeterEndPoint = "MeterEndPoint";
			public const string MeterTotalPoint = "MeterTotalPoint";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string WriteStatus = "WriteStatus";
			public const string FeeStatus = "FeeStatus";
			public const string WriteDate = "WriteDate";
			public const string WriteUserName = "WriteUserName";
			public const string IsAPPWriteEnable = "IsAPPWriteEnable";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProjectID" , "int:"},
    			 {"MeterID" , "int:"},
    			 {"MeterName" , "string:"},
    			 {"MeterNumber" , "string:"},
    			 {"MeterCategoryID" , "int:1-水表 2-电表 3-气表"},
    			 {"MeterType" , "int:1-住户 2-公共"},
    			 {"MeterSpec" , "int:1-分表 2-总表"},
    			 {"MeterCoefficient" , "decimal:"},
    			 {"MeterRemark" , "string:"},
    			 {"MeterChargeID" , "int:"},
    			 {"MeterHouseNo" , "string:"},
    			 {"MeterLocation" , "string:"},
    			 {"SortOrder" , "int:"},
    			 {"MeterStartPoint" , "decimal:"},
    			 {"MeterEndPoint" , "decimal:"},
    			 {"MeterTotalPoint" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"WriteStatus" , "int:0-开始抄表 1-结束抄表"},
    			 {"FeeStatus" , "int:0-未生成 1-已生成"},
    			 {"WriteDate" , "DateTime:"},
    			 {"WriteUserName" , "string:"},
    			 {"IsAPPWriteEnable" , "bool:"},
            };
		}
		#endregion
	}
}
