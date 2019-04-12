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
	/// This object represents the properties and methods of a ChargeMeter_ProjectFee.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ChargeMeter_ProjectFee 
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
		private int _meterProjectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int MeterProjectID
		{
			[DebuggerStepThrough()]
			get { return this._meterProjectID; }
			set 
			{
				if (this._meterProjectID != value) 
				{
					this._meterProjectID = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterProjectID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _roomFeeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RoomFeeID
		{
			[DebuggerStepThrough()]
			get { return this._roomFeeID; }
			set 
			{
				if (this._roomFeeID != value) 
				{
					this._roomFeeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomFeeID");
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
		private DateTime _meterStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime MeterStartTime
		{
			[DebuggerStepThrough()]
			get { return this._meterStartTime; }
			set 
			{
				if (this._meterStartTime != value) 
				{
					this._meterStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterStartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _meterEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime MeterEndTime
		{
			[DebuggerStepThrough()]
			get { return this._meterEndTime; }
			set 
			{
				if (this._meterEndTime != value) 
				{
					this._meterEndTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterEndTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _meterWriteDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime MeterWriteDate
		{
			[DebuggerStepThrough()]
			get { return this._meterWriteDate; }
			set 
			{
				if (this._meterWriteDate != value) 
				{
					this._meterWriteDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterWriteDate");
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
		private bool _isDeleted = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDeleted
		{
			[DebuggerStepThrough()]
			get { return this._isDeleted; }
			set 
			{
				if (this._isDeleted != value) 
				{
					this._isDeleted = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDeleted");
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
	[MeterProjectID] int,
	[RoomFeeID] int,
	[MeterID] int,
	[ProjectID] int,
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
	[MeterStartTime] datetime,
	[MeterEndTime] datetime,
	[MeterWriteDate] datetime,
	[WriteDate] datetime,
	[WriteUserName] nvarchar(100),
	[IsDeleted] bit
);

INSERT INTO [dbo].[ChargeMeter_ProjectFee] (
	[ChargeMeter_ProjectFee].[MeterProjectID],
	[ChargeMeter_ProjectFee].[RoomFeeID],
	[ChargeMeter_ProjectFee].[MeterID],
	[ChargeMeter_ProjectFee].[ProjectID],
	[ChargeMeter_ProjectFee].[MeterName],
	[ChargeMeter_ProjectFee].[MeterNumber],
	[ChargeMeter_ProjectFee].[MeterCategoryID],
	[ChargeMeter_ProjectFee].[MeterType],
	[ChargeMeter_ProjectFee].[MeterSpec],
	[ChargeMeter_ProjectFee].[MeterCoefficient],
	[ChargeMeter_ProjectFee].[MeterRemark],
	[ChargeMeter_ProjectFee].[MeterChargeID],
	[ChargeMeter_ProjectFee].[MeterHouseNo],
	[ChargeMeter_ProjectFee].[MeterLocation],
	[ChargeMeter_ProjectFee].[SortOrder],
	[ChargeMeter_ProjectFee].[MeterStartPoint],
	[ChargeMeter_ProjectFee].[MeterEndPoint],
	[ChargeMeter_ProjectFee].[MeterTotalPoint],
	[ChargeMeter_ProjectFee].[AddTime],
	[ChargeMeter_ProjectFee].[AddUserName],
	[ChargeMeter_ProjectFee].[MeterStartTime],
	[ChargeMeter_ProjectFee].[MeterEndTime],
	[ChargeMeter_ProjectFee].[MeterWriteDate],
	[ChargeMeter_ProjectFee].[WriteDate],
	[ChargeMeter_ProjectFee].[WriteUserName],
	[ChargeMeter_ProjectFee].[IsDeleted]
) 
output 
	INSERTED.[ID],
	INSERTED.[MeterProjectID],
	INSERTED.[RoomFeeID],
	INSERTED.[MeterID],
	INSERTED.[ProjectID],
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
	INSERTED.[MeterStartTime],
	INSERTED.[MeterEndTime],
	INSERTED.[MeterWriteDate],
	INSERTED.[WriteDate],
	INSERTED.[WriteUserName],
	INSERTED.[IsDeleted]
into @table
VALUES ( 
	@MeterProjectID,
	@RoomFeeID,
	@MeterID,
	@ProjectID,
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
	@MeterStartTime,
	@MeterEndTime,
	@MeterWriteDate,
	@WriteDate,
	@WriteUserName,
	@IsDeleted 
); 

SELECT 
	[ID],
	[MeterProjectID],
	[RoomFeeID],
	[MeterID],
	[ProjectID],
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
	[MeterStartTime],
	[MeterEndTime],
	[MeterWriteDate],
	[WriteDate],
	[WriteUserName],
	[IsDeleted] 
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
	[MeterProjectID] int,
	[RoomFeeID] int,
	[MeterID] int,
	[ProjectID] int,
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
	[MeterStartTime] datetime,
	[MeterEndTime] datetime,
	[MeterWriteDate] datetime,
	[WriteDate] datetime,
	[WriteUserName] nvarchar(100),
	[IsDeleted] bit
);

UPDATE [dbo].[ChargeMeter_ProjectFee] SET 
	[ChargeMeter_ProjectFee].[MeterProjectID] = @MeterProjectID,
	[ChargeMeter_ProjectFee].[RoomFeeID] = @RoomFeeID,
	[ChargeMeter_ProjectFee].[MeterID] = @MeterID,
	[ChargeMeter_ProjectFee].[ProjectID] = @ProjectID,
	[ChargeMeter_ProjectFee].[MeterName] = @MeterName,
	[ChargeMeter_ProjectFee].[MeterNumber] = @MeterNumber,
	[ChargeMeter_ProjectFee].[MeterCategoryID] = @MeterCategoryID,
	[ChargeMeter_ProjectFee].[MeterType] = @MeterType,
	[ChargeMeter_ProjectFee].[MeterSpec] = @MeterSpec,
	[ChargeMeter_ProjectFee].[MeterCoefficient] = @MeterCoefficient,
	[ChargeMeter_ProjectFee].[MeterRemark] = @MeterRemark,
	[ChargeMeter_ProjectFee].[MeterChargeID] = @MeterChargeID,
	[ChargeMeter_ProjectFee].[MeterHouseNo] = @MeterHouseNo,
	[ChargeMeter_ProjectFee].[MeterLocation] = @MeterLocation,
	[ChargeMeter_ProjectFee].[SortOrder] = @SortOrder,
	[ChargeMeter_ProjectFee].[MeterStartPoint] = @MeterStartPoint,
	[ChargeMeter_ProjectFee].[MeterEndPoint] = @MeterEndPoint,
	[ChargeMeter_ProjectFee].[MeterTotalPoint] = @MeterTotalPoint,
	[ChargeMeter_ProjectFee].[AddTime] = @AddTime,
	[ChargeMeter_ProjectFee].[AddUserName] = @AddUserName,
	[ChargeMeter_ProjectFee].[MeterStartTime] = @MeterStartTime,
	[ChargeMeter_ProjectFee].[MeterEndTime] = @MeterEndTime,
	[ChargeMeter_ProjectFee].[MeterWriteDate] = @MeterWriteDate,
	[ChargeMeter_ProjectFee].[WriteDate] = @WriteDate,
	[ChargeMeter_ProjectFee].[WriteUserName] = @WriteUserName,
	[ChargeMeter_ProjectFee].[IsDeleted] = @IsDeleted 
output 
	INSERTED.[ID],
	INSERTED.[MeterProjectID],
	INSERTED.[RoomFeeID],
	INSERTED.[MeterID],
	INSERTED.[ProjectID],
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
	INSERTED.[MeterStartTime],
	INSERTED.[MeterEndTime],
	INSERTED.[MeterWriteDate],
	INSERTED.[WriteDate],
	INSERTED.[WriteUserName],
	INSERTED.[IsDeleted]
into @table
WHERE 
	[ChargeMeter_ProjectFee].[ID] = @ID

SELECT 
	[ID],
	[MeterProjectID],
	[RoomFeeID],
	[MeterID],
	[ProjectID],
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
	[MeterStartTime],
	[MeterEndTime],
	[MeterWriteDate],
	[WriteDate],
	[WriteUserName],
	[IsDeleted] 
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
DELETE FROM [dbo].[ChargeMeter_ProjectFee]
WHERE 
	[ChargeMeter_ProjectFee].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ChargeMeter_ProjectFee() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetChargeMeter_ProjectFee(this.ID));
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
	[ChargeMeter_ProjectFee].[ID],
	[ChargeMeter_ProjectFee].[MeterProjectID],
	[ChargeMeter_ProjectFee].[RoomFeeID],
	[ChargeMeter_ProjectFee].[MeterID],
	[ChargeMeter_ProjectFee].[ProjectID],
	[ChargeMeter_ProjectFee].[MeterName],
	[ChargeMeter_ProjectFee].[MeterNumber],
	[ChargeMeter_ProjectFee].[MeterCategoryID],
	[ChargeMeter_ProjectFee].[MeterType],
	[ChargeMeter_ProjectFee].[MeterSpec],
	[ChargeMeter_ProjectFee].[MeterCoefficient],
	[ChargeMeter_ProjectFee].[MeterRemark],
	[ChargeMeter_ProjectFee].[MeterChargeID],
	[ChargeMeter_ProjectFee].[MeterHouseNo],
	[ChargeMeter_ProjectFee].[MeterLocation],
	[ChargeMeter_ProjectFee].[SortOrder],
	[ChargeMeter_ProjectFee].[MeterStartPoint],
	[ChargeMeter_ProjectFee].[MeterEndPoint],
	[ChargeMeter_ProjectFee].[MeterTotalPoint],
	[ChargeMeter_ProjectFee].[AddTime],
	[ChargeMeter_ProjectFee].[AddUserName],
	[ChargeMeter_ProjectFee].[MeterStartTime],
	[ChargeMeter_ProjectFee].[MeterEndTime],
	[ChargeMeter_ProjectFee].[MeterWriteDate],
	[ChargeMeter_ProjectFee].[WriteDate],
	[ChargeMeter_ProjectFee].[WriteUserName],
	[ChargeMeter_ProjectFee].[IsDeleted]
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
                return "ChargeMeter_ProjectFee";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ChargeMeter_ProjectFee into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="meterProjectID">meterProjectID</param>
		/// <param name="roomFeeID">roomFeeID</param>
		/// <param name="meterID">meterID</param>
		/// <param name="projectID">projectID</param>
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
		/// <param name="meterStartTime">meterStartTime</param>
		/// <param name="meterEndTime">meterEndTime</param>
		/// <param name="meterWriteDate">meterWriteDate</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="writeUserName">writeUserName</param>
		/// <param name="isDeleted">isDeleted</param>
		public static void InsertChargeMeter_ProjectFee(int @meterProjectID, int @roomFeeID, int @meterID, int @projectID, string @meterName, string @meterNumber, int @meterCategoryID, int @meterType, int @meterSpec, decimal @meterCoefficient, string @meterRemark, int @meterChargeID, string @meterHouseNo, string @meterLocation, int @sortOrder, decimal @meterStartPoint, decimal @meterEndPoint, decimal @meterTotalPoint, DateTime @addTime, string @addUserName, DateTime @meterStartTime, DateTime @meterEndTime, DateTime @meterWriteDate, DateTime @writeDate, string @writeUserName, bool @isDeleted)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertChargeMeter_ProjectFee(@meterProjectID, @roomFeeID, @meterID, @projectID, @meterName, @meterNumber, @meterCategoryID, @meterType, @meterSpec, @meterCoefficient, @meterRemark, @meterChargeID, @meterHouseNo, @meterLocation, @sortOrder, @meterStartPoint, @meterEndPoint, @meterTotalPoint, @addTime, @addUserName, @meterStartTime, @meterEndTime, @meterWriteDate, @writeDate, @writeUserName, @isDeleted, helper);
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
		/// Insert a ChargeMeter_ProjectFee into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="meterProjectID">meterProjectID</param>
		/// <param name="roomFeeID">roomFeeID</param>
		/// <param name="meterID">meterID</param>
		/// <param name="projectID">projectID</param>
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
		/// <param name="meterStartTime">meterStartTime</param>
		/// <param name="meterEndTime">meterEndTime</param>
		/// <param name="meterWriteDate">meterWriteDate</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="writeUserName">writeUserName</param>
		/// <param name="isDeleted">isDeleted</param>
		/// <param name="helper">helper</param>
		internal static void InsertChargeMeter_ProjectFee(int @meterProjectID, int @roomFeeID, int @meterID, int @projectID, string @meterName, string @meterNumber, int @meterCategoryID, int @meterType, int @meterSpec, decimal @meterCoefficient, string @meterRemark, int @meterChargeID, string @meterHouseNo, string @meterLocation, int @sortOrder, decimal @meterStartPoint, decimal @meterEndPoint, decimal @meterTotalPoint, DateTime @addTime, string @addUserName, DateTime @meterStartTime, DateTime @meterEndTime, DateTime @meterWriteDate, DateTime @writeDate, string @writeUserName, bool @isDeleted, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[MeterProjectID] int,
	[RoomFeeID] int,
	[MeterID] int,
	[ProjectID] int,
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
	[MeterStartTime] datetime,
	[MeterEndTime] datetime,
	[MeterWriteDate] datetime,
	[WriteDate] datetime,
	[WriteUserName] nvarchar(100),
	[IsDeleted] bit
);

INSERT INTO [dbo].[ChargeMeter_ProjectFee] (
	[ChargeMeter_ProjectFee].[MeterProjectID],
	[ChargeMeter_ProjectFee].[RoomFeeID],
	[ChargeMeter_ProjectFee].[MeterID],
	[ChargeMeter_ProjectFee].[ProjectID],
	[ChargeMeter_ProjectFee].[MeterName],
	[ChargeMeter_ProjectFee].[MeterNumber],
	[ChargeMeter_ProjectFee].[MeterCategoryID],
	[ChargeMeter_ProjectFee].[MeterType],
	[ChargeMeter_ProjectFee].[MeterSpec],
	[ChargeMeter_ProjectFee].[MeterCoefficient],
	[ChargeMeter_ProjectFee].[MeterRemark],
	[ChargeMeter_ProjectFee].[MeterChargeID],
	[ChargeMeter_ProjectFee].[MeterHouseNo],
	[ChargeMeter_ProjectFee].[MeterLocation],
	[ChargeMeter_ProjectFee].[SortOrder],
	[ChargeMeter_ProjectFee].[MeterStartPoint],
	[ChargeMeter_ProjectFee].[MeterEndPoint],
	[ChargeMeter_ProjectFee].[MeterTotalPoint],
	[ChargeMeter_ProjectFee].[AddTime],
	[ChargeMeter_ProjectFee].[AddUserName],
	[ChargeMeter_ProjectFee].[MeterStartTime],
	[ChargeMeter_ProjectFee].[MeterEndTime],
	[ChargeMeter_ProjectFee].[MeterWriteDate],
	[ChargeMeter_ProjectFee].[WriteDate],
	[ChargeMeter_ProjectFee].[WriteUserName],
	[ChargeMeter_ProjectFee].[IsDeleted]
) 
output 
	INSERTED.[ID],
	INSERTED.[MeterProjectID],
	INSERTED.[RoomFeeID],
	INSERTED.[MeterID],
	INSERTED.[ProjectID],
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
	INSERTED.[MeterStartTime],
	INSERTED.[MeterEndTime],
	INSERTED.[MeterWriteDate],
	INSERTED.[WriteDate],
	INSERTED.[WriteUserName],
	INSERTED.[IsDeleted]
into @table
VALUES ( 
	@MeterProjectID,
	@RoomFeeID,
	@MeterID,
	@ProjectID,
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
	@MeterStartTime,
	@MeterEndTime,
	@MeterWriteDate,
	@WriteDate,
	@WriteUserName,
	@IsDeleted 
); 

SELECT 
	[ID],
	[MeterProjectID],
	[RoomFeeID],
	[MeterID],
	[ProjectID],
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
	[MeterStartTime],
	[MeterEndTime],
	[MeterWriteDate],
	[WriteDate],
	[WriteUserName],
	[IsDeleted] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@MeterProjectID", EntityBase.GetDatabaseValue(@meterProjectID)));
			parameters.Add(new SqlParameter("@RoomFeeID", EntityBase.GetDatabaseValue(@roomFeeID)));
			parameters.Add(new SqlParameter("@MeterID", EntityBase.GetDatabaseValue(@meterID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
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
			parameters.Add(new SqlParameter("@MeterStartTime", EntityBase.GetDatabaseValue(@meterStartTime)));
			parameters.Add(new SqlParameter("@MeterEndTime", EntityBase.GetDatabaseValue(@meterEndTime)));
			parameters.Add(new SqlParameter("@MeterWriteDate", EntityBase.GetDatabaseValue(@meterWriteDate)));
			parameters.Add(new SqlParameter("@WriteDate", EntityBase.GetDatabaseValue(@writeDate)));
			parameters.Add(new SqlParameter("@WriteUserName", EntityBase.GetDatabaseValue(@writeUserName)));
			parameters.Add(new SqlParameter("@IsDeleted", @isDeleted));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ChargeMeter_ProjectFee into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="meterProjectID">meterProjectID</param>
		/// <param name="roomFeeID">roomFeeID</param>
		/// <param name="meterID">meterID</param>
		/// <param name="projectID">projectID</param>
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
		/// <param name="meterStartTime">meterStartTime</param>
		/// <param name="meterEndTime">meterEndTime</param>
		/// <param name="meterWriteDate">meterWriteDate</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="writeUserName">writeUserName</param>
		/// <param name="isDeleted">isDeleted</param>
		public static void UpdateChargeMeter_ProjectFee(int @iD, int @meterProjectID, int @roomFeeID, int @meterID, int @projectID, string @meterName, string @meterNumber, int @meterCategoryID, int @meterType, int @meterSpec, decimal @meterCoefficient, string @meterRemark, int @meterChargeID, string @meterHouseNo, string @meterLocation, int @sortOrder, decimal @meterStartPoint, decimal @meterEndPoint, decimal @meterTotalPoint, DateTime @addTime, string @addUserName, DateTime @meterStartTime, DateTime @meterEndTime, DateTime @meterWriteDate, DateTime @writeDate, string @writeUserName, bool @isDeleted)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateChargeMeter_ProjectFee(@iD, @meterProjectID, @roomFeeID, @meterID, @projectID, @meterName, @meterNumber, @meterCategoryID, @meterType, @meterSpec, @meterCoefficient, @meterRemark, @meterChargeID, @meterHouseNo, @meterLocation, @sortOrder, @meterStartPoint, @meterEndPoint, @meterTotalPoint, @addTime, @addUserName, @meterStartTime, @meterEndTime, @meterWriteDate, @writeDate, @writeUserName, @isDeleted, helper);
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
		/// Updates a ChargeMeter_ProjectFee into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="meterProjectID">meterProjectID</param>
		/// <param name="roomFeeID">roomFeeID</param>
		/// <param name="meterID">meterID</param>
		/// <param name="projectID">projectID</param>
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
		/// <param name="meterStartTime">meterStartTime</param>
		/// <param name="meterEndTime">meterEndTime</param>
		/// <param name="meterWriteDate">meterWriteDate</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="writeUserName">writeUserName</param>
		/// <param name="isDeleted">isDeleted</param>
		/// <param name="helper">helper</param>
		internal static void UpdateChargeMeter_ProjectFee(int @iD, int @meterProjectID, int @roomFeeID, int @meterID, int @projectID, string @meterName, string @meterNumber, int @meterCategoryID, int @meterType, int @meterSpec, decimal @meterCoefficient, string @meterRemark, int @meterChargeID, string @meterHouseNo, string @meterLocation, int @sortOrder, decimal @meterStartPoint, decimal @meterEndPoint, decimal @meterTotalPoint, DateTime @addTime, string @addUserName, DateTime @meterStartTime, DateTime @meterEndTime, DateTime @meterWriteDate, DateTime @writeDate, string @writeUserName, bool @isDeleted, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[MeterProjectID] int,
	[RoomFeeID] int,
	[MeterID] int,
	[ProjectID] int,
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
	[MeterStartTime] datetime,
	[MeterEndTime] datetime,
	[MeterWriteDate] datetime,
	[WriteDate] datetime,
	[WriteUserName] nvarchar(100),
	[IsDeleted] bit
);

UPDATE [dbo].[ChargeMeter_ProjectFee] SET 
	[ChargeMeter_ProjectFee].[MeterProjectID] = @MeterProjectID,
	[ChargeMeter_ProjectFee].[RoomFeeID] = @RoomFeeID,
	[ChargeMeter_ProjectFee].[MeterID] = @MeterID,
	[ChargeMeter_ProjectFee].[ProjectID] = @ProjectID,
	[ChargeMeter_ProjectFee].[MeterName] = @MeterName,
	[ChargeMeter_ProjectFee].[MeterNumber] = @MeterNumber,
	[ChargeMeter_ProjectFee].[MeterCategoryID] = @MeterCategoryID,
	[ChargeMeter_ProjectFee].[MeterType] = @MeterType,
	[ChargeMeter_ProjectFee].[MeterSpec] = @MeterSpec,
	[ChargeMeter_ProjectFee].[MeterCoefficient] = @MeterCoefficient,
	[ChargeMeter_ProjectFee].[MeterRemark] = @MeterRemark,
	[ChargeMeter_ProjectFee].[MeterChargeID] = @MeterChargeID,
	[ChargeMeter_ProjectFee].[MeterHouseNo] = @MeterHouseNo,
	[ChargeMeter_ProjectFee].[MeterLocation] = @MeterLocation,
	[ChargeMeter_ProjectFee].[SortOrder] = @SortOrder,
	[ChargeMeter_ProjectFee].[MeterStartPoint] = @MeterStartPoint,
	[ChargeMeter_ProjectFee].[MeterEndPoint] = @MeterEndPoint,
	[ChargeMeter_ProjectFee].[MeterTotalPoint] = @MeterTotalPoint,
	[ChargeMeter_ProjectFee].[AddTime] = @AddTime,
	[ChargeMeter_ProjectFee].[AddUserName] = @AddUserName,
	[ChargeMeter_ProjectFee].[MeterStartTime] = @MeterStartTime,
	[ChargeMeter_ProjectFee].[MeterEndTime] = @MeterEndTime,
	[ChargeMeter_ProjectFee].[MeterWriteDate] = @MeterWriteDate,
	[ChargeMeter_ProjectFee].[WriteDate] = @WriteDate,
	[ChargeMeter_ProjectFee].[WriteUserName] = @WriteUserName,
	[ChargeMeter_ProjectFee].[IsDeleted] = @IsDeleted 
output 
	INSERTED.[ID],
	INSERTED.[MeterProjectID],
	INSERTED.[RoomFeeID],
	INSERTED.[MeterID],
	INSERTED.[ProjectID],
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
	INSERTED.[MeterStartTime],
	INSERTED.[MeterEndTime],
	INSERTED.[MeterWriteDate],
	INSERTED.[WriteDate],
	INSERTED.[WriteUserName],
	INSERTED.[IsDeleted]
into @table
WHERE 
	[ChargeMeter_ProjectFee].[ID] = @ID

SELECT 
	[ID],
	[MeterProjectID],
	[RoomFeeID],
	[MeterID],
	[ProjectID],
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
	[MeterStartTime],
	[MeterEndTime],
	[MeterWriteDate],
	[WriteDate],
	[WriteUserName],
	[IsDeleted] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@MeterProjectID", EntityBase.GetDatabaseValue(@meterProjectID)));
			parameters.Add(new SqlParameter("@RoomFeeID", EntityBase.GetDatabaseValue(@roomFeeID)));
			parameters.Add(new SqlParameter("@MeterID", EntityBase.GetDatabaseValue(@meterID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
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
			parameters.Add(new SqlParameter("@MeterStartTime", EntityBase.GetDatabaseValue(@meterStartTime)));
			parameters.Add(new SqlParameter("@MeterEndTime", EntityBase.GetDatabaseValue(@meterEndTime)));
			parameters.Add(new SqlParameter("@MeterWriteDate", EntityBase.GetDatabaseValue(@meterWriteDate)));
			parameters.Add(new SqlParameter("@WriteDate", EntityBase.GetDatabaseValue(@writeDate)));
			parameters.Add(new SqlParameter("@WriteUserName", EntityBase.GetDatabaseValue(@writeUserName)));
			parameters.Add(new SqlParameter("@IsDeleted", @isDeleted));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ChargeMeter_ProjectFee from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteChargeMeter_ProjectFee(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteChargeMeter_ProjectFee(@iD, helper);
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
		/// Deletes a ChargeMeter_ProjectFee from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteChargeMeter_ProjectFee(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ChargeMeter_ProjectFee]
WHERE 
	[ChargeMeter_ProjectFee].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ChargeMeter_ProjectFee object.
		/// </summary>
		/// <returns>The newly created ChargeMeter_ProjectFee object.</returns>
		public static ChargeMeter_ProjectFee CreateChargeMeter_ProjectFee()
		{
			return InitializeNew<ChargeMeter_ProjectFee>();
		}
		
		/// <summary>
		/// Retrieve information for a ChargeMeter_ProjectFee by a ChargeMeter_ProjectFee's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ChargeMeter_ProjectFee</returns>
		public static ChargeMeter_ProjectFee GetChargeMeter_ProjectFee(int @iD)
		{
			string commandText = @"
SELECT 
" + ChargeMeter_ProjectFee.SelectFieldList + @"
FROM [dbo].[ChargeMeter_ProjectFee] 
WHERE 
	[ChargeMeter_ProjectFee].[ID] = @ID " + ChargeMeter_ProjectFee.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeMeter_ProjectFee>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ChargeMeter_ProjectFee by a ChargeMeter_ProjectFee's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ChargeMeter_ProjectFee</returns>
		public static ChargeMeter_ProjectFee GetChargeMeter_ProjectFee(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ChargeMeter_ProjectFee.SelectFieldList + @"
FROM [dbo].[ChargeMeter_ProjectFee] 
WHERE 
	[ChargeMeter_ProjectFee].[ID] = @ID " + ChargeMeter_ProjectFee.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeMeter_ProjectFee>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ChargeMeter_ProjectFee objects.
		/// </summary>
		/// <returns>The retrieved collection of ChargeMeter_ProjectFee objects.</returns>
		public static EntityList<ChargeMeter_ProjectFee> GetChargeMeter_ProjectFees()
		{
			string commandText = @"
SELECT " + ChargeMeter_ProjectFee.SelectFieldList + "FROM [dbo].[ChargeMeter_ProjectFee] " + ChargeMeter_ProjectFee.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ChargeMeter_ProjectFee>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ChargeMeter_ProjectFee objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeMeter_ProjectFee objects.</returns>
        public static EntityList<ChargeMeter_ProjectFee> GetChargeMeter_ProjectFees(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeMeter_ProjectFee>(SelectFieldList, "FROM [dbo].[ChargeMeter_ProjectFee]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ChargeMeter_ProjectFee objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeMeter_ProjectFee objects.</returns>
        public static EntityList<ChargeMeter_ProjectFee> GetChargeMeter_ProjectFees(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeMeter_ProjectFee>(SelectFieldList, "FROM [dbo].[ChargeMeter_ProjectFee]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ChargeMeter_ProjectFee objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ChargeMeter_ProjectFee objects.</returns>
		protected static EntityList<ChargeMeter_ProjectFee> GetChargeMeter_ProjectFees(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeMeter_ProjectFees(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ChargeMeter_ProjectFee objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeMeter_ProjectFee objects.</returns>
		protected static EntityList<ChargeMeter_ProjectFee> GetChargeMeter_ProjectFees(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeMeter_ProjectFees(string.Empty, where, parameters, ChargeMeter_ProjectFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeMeter_ProjectFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeMeter_ProjectFee objects.</returns>
		protected static EntityList<ChargeMeter_ProjectFee> GetChargeMeter_ProjectFees(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeMeter_ProjectFees(prefix, where, parameters, ChargeMeter_ProjectFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeMeter_ProjectFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeMeter_ProjectFee objects.</returns>
		protected static EntityList<ChargeMeter_ProjectFee> GetChargeMeter_ProjectFees(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeMeter_ProjectFees(string.Empty, where, parameters, ChargeMeter_ProjectFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeMeter_ProjectFee objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeMeter_ProjectFee objects.</returns>
		protected static EntityList<ChargeMeter_ProjectFee> GetChargeMeter_ProjectFees(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeMeter_ProjectFees(prefix, where, parameters, ChargeMeter_ProjectFee.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeMeter_ProjectFee objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ChargeMeter_ProjectFee objects.</returns>
		protected static EntityList<ChargeMeter_ProjectFee> GetChargeMeter_ProjectFees(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ChargeMeter_ProjectFee.SelectFieldList + "FROM [dbo].[ChargeMeter_ProjectFee] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ChargeMeter_ProjectFee>(reader);
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
        protected static EntityList<ChargeMeter_ProjectFee> GetChargeMeter_ProjectFees(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeMeter_ProjectFee>(SelectFieldList, "FROM [dbo].[ChargeMeter_ProjectFee] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ChargeMeter_ProjectFee objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargeMeter_ProjectFeeCount()
        {
            return GetChargeMeter_ProjectFeeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ChargeMeter_ProjectFee objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargeMeter_ProjectFeeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ChargeMeter_ProjectFee] " + where;

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
		public static partial class ChargeMeter_ProjectFee_Properties
		{
			public const string ID = "ID";
			public const string MeterProjectID = "MeterProjectID";
			public const string RoomFeeID = "RoomFeeID";
			public const string MeterID = "MeterID";
			public const string ProjectID = "ProjectID";
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
			public const string MeterStartTime = "MeterStartTime";
			public const string MeterEndTime = "MeterEndTime";
			public const string MeterWriteDate = "MeterWriteDate";
			public const string WriteDate = "WriteDate";
			public const string WriteUserName = "WriteUserName";
			public const string IsDeleted = "IsDeleted";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"MeterProjectID" , "int:"},
    			 {"RoomFeeID" , "int:"},
    			 {"MeterID" , "int:"},
    			 {"ProjectID" , "int:"},
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
    			 {"MeterStartTime" , "DateTime:"},
    			 {"MeterEndTime" , "DateTime:"},
    			 {"MeterWriteDate" , "DateTime:"},
    			 {"WriteDate" , "DateTime:"},
    			 {"WriteUserName" , "string:"},
    			 {"IsDeleted" , "bool:"},
            };
		}
		#endregion
	}
}
