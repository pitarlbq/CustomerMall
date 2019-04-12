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
	/// This object represents the properties and methods of a Device.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Device 
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
		private string _deviceNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DeviceNo
		{
			[DebuggerStepThrough()]
			get { return this._deviceNo; }
			set 
			{
				if (this._deviceNo != value) 
				{
					this._deviceNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeviceNo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _deviceTypeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int DeviceTypeID
		{
			[DebuggerStepThrough()]
			get { return this._deviceTypeID; }
			set 
			{
				if (this._deviceTypeID != value) 
				{
					this._deviceTypeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeviceTypeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _deviceName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string DeviceName
		{
			[DebuggerStepThrough()]
			get { return this._deviceName; }
			set 
			{
				if (this._deviceName != value) 
				{
					this._deviceName = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeviceName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _deviceGroupID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int DeviceGroupID
		{
			[DebuggerStepThrough()]
			get { return this._deviceGroupID; }
			set 
			{
				if (this._deviceGroupID != value) 
				{
					this._deviceGroupID = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeviceGroupID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _modelNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ModelNo
		{
			[DebuggerStepThrough()]
			get { return this._modelNo; }
			set 
			{
				if (this._modelNo != value) 
				{
					this._modelNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModelNo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _deviceLevel = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DeviceLevel
		{
			[DebuggerStepThrough()]
			get { return this._deviceLevel; }
			set 
			{
				if (this._deviceLevel != value) 
				{
					this._deviceLevel = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeviceLevel");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _repairCompany = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RepairCompany
		{
			[DebuggerStepThrough()]
			get { return this._repairCompany; }
			set 
			{
				if (this._repairCompany != value) 
				{
					this._repairCompany = value;
					this.IsDirty = true;	
					OnPropertyChanged("RepairCompany");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _supplier = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Supplier
		{
			[DebuggerStepThrough()]
			get { return this._supplier; }
			set 
			{
				if (this._supplier != value) 
				{
					this._supplier = value;
					this.IsDirty = true;	
					OnPropertyChanged("Supplier");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _repairUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RepairUserID
		{
			[DebuggerStepThrough()]
			get { return this._repairUserID; }
			set 
			{
				if (this._repairUserID != value) 
				{
					this._repairUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RepairUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _checkUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CheckUserID
		{
			[DebuggerStepThrough()]
			get { return this._checkUserID; }
			set 
			{
				if (this._checkUserID != value) 
				{
					this._checkUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CheckUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _firstRepairDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime FirstRepairDate
		{
			[DebuggerStepThrough()]
			get { return this._firstRepairDate; }
			set 
			{
				if (this._firstRepairDate != value) 
				{
					this._firstRepairDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("FirstRepairDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _firstCheckDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime FirstCheckDate
		{
			[DebuggerStepThrough()]
			get { return this._firstCheckDate; }
			set 
			{
				if (this._firstCheckDate != value) 
				{
					this._firstCheckDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("FirstCheckDate");
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
		private int _deviceStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int DeviceStatus
		{
			[DebuggerStepThrough()]
			get { return this._deviceStatus; }
			set 
			{
				if (this._deviceStatus != value) 
				{
					this._deviceStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeviceStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _repairType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RepairType
		{
			[DebuggerStepThrough()]
			get { return this._repairType; }
			set 
			{
				if (this._repairType != value) 
				{
					this._repairType = value;
					this.IsDirty = true;	
					OnPropertyChanged("RepairType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _supplierMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SupplierMan
		{
			[DebuggerStepThrough()]
			get { return this._supplierMan; }
			set 
			{
				if (this._supplierMan != value) 
				{
					this._supplierMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("SupplierMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _supplierPhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SupplierPhone
		{
			[DebuggerStepThrough()]
			get { return this._supplierPhone; }
			set 
			{
				if (this._supplierPhone != value) 
				{
					this._supplierPhone = value;
					this.IsDirty = true;	
					OnPropertyChanged("SupplierPhone");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _repairUserPhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RepairUserPhone
		{
			[DebuggerStepThrough()]
			get { return this._repairUserPhone; }
			set 
			{
				if (this._repairUserPhone != value) 
				{
					this._repairUserPhone = value;
					this.IsDirty = true;	
					OnPropertyChanged("RepairUserPhone");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _repairCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RepairCount
		{
			[DebuggerStepThrough()]
			get { return this._repairCount; }
			set 
			{
				if (this._repairCount != value) 
				{
					this._repairCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("RepairCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _repairCycle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RepairCycle
		{
			[DebuggerStepThrough()]
			get { return this._repairCycle; }
			set 
			{
				if (this._repairCycle != value) 
				{
					this._repairCycle = value;
					this.IsDirty = true;	
					OnPropertyChanged("RepairCycle");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _lastRepairDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime LastRepairDate
		{
			[DebuggerStepThrough()]
			get { return this._lastRepairDate; }
			set 
			{
				if (this._lastRepairDate != value) 
				{
					this._lastRepairDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("LastRepairDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _thisRepairDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ThisRepairDate
		{
			[DebuggerStepThrough()]
			get { return this._thisRepairDate; }
			set 
			{
				if (this._thisRepairDate != value) 
				{
					this._thisRepairDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("ThisRepairDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _checkCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CheckCount
		{
			[DebuggerStepThrough()]
			get { return this._checkCount; }
			set 
			{
				if (this._checkCount != value) 
				{
					this._checkCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("CheckCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _checkCycle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CheckCycle
		{
			[DebuggerStepThrough()]
			get { return this._checkCycle; }
			set 
			{
				if (this._checkCycle != value) 
				{
					this._checkCycle = value;
					this.IsDirty = true;	
					OnPropertyChanged("CheckCycle");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _lastCheckDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime LastCheckDate
		{
			[DebuggerStepThrough()]
			get { return this._lastCheckDate; }
			set 
			{
				if (this._lastCheckDate != value) 
				{
					this._lastCheckDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("LastCheckDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _thisCheckDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ThisCheckDate
		{
			[DebuggerStepThrough()]
			get { return this._thisCheckDate; }
			set 
			{
				if (this._thisCheckDate != value) 
				{
					this._thisCheckDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("ThisCheckDate");
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
		private DateTime _purchaseDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime PurchaseDate
		{
			[DebuggerStepThrough()]
			get { return this._purchaseDate; }
			set 
			{
				if (this._purchaseDate != value) 
				{
					this._purchaseDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("PurchaseDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _guaranteeDate = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string GuaranteeDate
		{
			[DebuggerStepThrough()]
			get { return this._guaranteeDate; }
			set 
			{
				if (this._guaranteeDate != value) 
				{
					this._guaranteeDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("GuaranteeDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _guaranteeEndDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime GuaranteeEndDate
		{
			[DebuggerStepThrough()]
			get { return this._guaranteeEndDate; }
			set 
			{
				if (this._guaranteeEndDate != value) 
				{
					this._guaranteeEndDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("GuaranteeEndDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _taskTypeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TaskTypeID
		{
			[DebuggerStepThrough()]
			get { return this._taskTypeID; }
			set 
			{
				if (this._taskTypeID != value) 
				{
					this._taskTypeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaskTypeID");
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
		[DataObjectField(false, false, true)]
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
		private string _locationPlace = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string LocationPlace
		{
			[DebuggerStepThrough()]
			get { return this._locationPlace; }
			set 
			{
				if (this._locationPlace != value) 
				{
					this._locationPlace = value;
					this.IsDirty = true;	
					OnPropertyChanged("LocationPlace");
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
	[DeviceNo] nvarchar(100),
	[DeviceTypeID] int,
	[DeviceName] nvarchar(100),
	[DeviceGroupID] int,
	[ModelNo] nvarchar(100),
	[DeviceLevel] nvarchar(50),
	[RepairCompany] nvarchar(200),
	[Supplier] nvarchar(200),
	[RepairUserID] int,
	[CheckUserID] int,
	[FirstRepairDate] datetime,
	[FirstCheckDate] datetime,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[DeviceStatus] int,
	[RepairType] nvarchar(100),
	[SupplierMan] nvarchar(100),
	[SupplierPhone] nvarchar(100),
	[RepairUserPhone] nvarchar(100),
	[RepairCount] int,
	[RepairCycle] nvarchar(100),
	[LastRepairDate] datetime,
	[ThisRepairDate] datetime,
	[CheckCount] int,
	[CheckCycle] nvarchar(100),
	[LastCheckDate] datetime,
	[ThisCheckDate] datetime,
	[Remark] ntext,
	[PurchaseDate] datetime,
	[GuaranteeDate] nvarchar(50),
	[GuaranteeEndDate] datetime,
	[TaskTypeID] int,
	[ProjectID] int,
	[LocationPlace] nvarchar(200)
);

INSERT INTO [dbo].[Device] (
	[Device].[DeviceNo],
	[Device].[DeviceTypeID],
	[Device].[DeviceName],
	[Device].[DeviceGroupID],
	[Device].[ModelNo],
	[Device].[DeviceLevel],
	[Device].[RepairCompany],
	[Device].[Supplier],
	[Device].[RepairUserID],
	[Device].[CheckUserID],
	[Device].[FirstRepairDate],
	[Device].[FirstCheckDate],
	[Device].[AddTime],
	[Device].[AddMan],
	[Device].[DeviceStatus],
	[Device].[RepairType],
	[Device].[SupplierMan],
	[Device].[SupplierPhone],
	[Device].[RepairUserPhone],
	[Device].[RepairCount],
	[Device].[RepairCycle],
	[Device].[LastRepairDate],
	[Device].[ThisRepairDate],
	[Device].[CheckCount],
	[Device].[CheckCycle],
	[Device].[LastCheckDate],
	[Device].[ThisCheckDate],
	[Device].[Remark],
	[Device].[PurchaseDate],
	[Device].[GuaranteeDate],
	[Device].[GuaranteeEndDate],
	[Device].[TaskTypeID],
	[Device].[ProjectID],
	[Device].[LocationPlace]
) 
output 
	INSERTED.[ID],
	INSERTED.[DeviceNo],
	INSERTED.[DeviceTypeID],
	INSERTED.[DeviceName],
	INSERTED.[DeviceGroupID],
	INSERTED.[ModelNo],
	INSERTED.[DeviceLevel],
	INSERTED.[RepairCompany],
	INSERTED.[Supplier],
	INSERTED.[RepairUserID],
	INSERTED.[CheckUserID],
	INSERTED.[FirstRepairDate],
	INSERTED.[FirstCheckDate],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[DeviceStatus],
	INSERTED.[RepairType],
	INSERTED.[SupplierMan],
	INSERTED.[SupplierPhone],
	INSERTED.[RepairUserPhone],
	INSERTED.[RepairCount],
	INSERTED.[RepairCycle],
	INSERTED.[LastRepairDate],
	INSERTED.[ThisRepairDate],
	INSERTED.[CheckCount],
	INSERTED.[CheckCycle],
	INSERTED.[LastCheckDate],
	INSERTED.[ThisCheckDate],
	INSERTED.[Remark],
	INSERTED.[PurchaseDate],
	INSERTED.[GuaranteeDate],
	INSERTED.[GuaranteeEndDate],
	INSERTED.[TaskTypeID],
	INSERTED.[ProjectID],
	INSERTED.[LocationPlace]
into @table
VALUES ( 
	@DeviceNo,
	@DeviceTypeID,
	@DeviceName,
	@DeviceGroupID,
	@ModelNo,
	@DeviceLevel,
	@RepairCompany,
	@Supplier,
	@RepairUserID,
	@CheckUserID,
	@FirstRepairDate,
	@FirstCheckDate,
	@AddTime,
	@AddMan,
	@DeviceStatus,
	@RepairType,
	@SupplierMan,
	@SupplierPhone,
	@RepairUserPhone,
	@RepairCount,
	@RepairCycle,
	@LastRepairDate,
	@ThisRepairDate,
	@CheckCount,
	@CheckCycle,
	@LastCheckDate,
	@ThisCheckDate,
	@Remark,
	@PurchaseDate,
	@GuaranteeDate,
	@GuaranteeEndDate,
	@TaskTypeID,
	@ProjectID,
	@LocationPlace 
); 

SELECT 
	[ID],
	[DeviceNo],
	[DeviceTypeID],
	[DeviceName],
	[DeviceGroupID],
	[ModelNo],
	[DeviceLevel],
	[RepairCompany],
	[Supplier],
	[RepairUserID],
	[CheckUserID],
	[FirstRepairDate],
	[FirstCheckDate],
	[AddTime],
	[AddMan],
	[DeviceStatus],
	[RepairType],
	[SupplierMan],
	[SupplierPhone],
	[RepairUserPhone],
	[RepairCount],
	[RepairCycle],
	[LastRepairDate],
	[ThisRepairDate],
	[CheckCount],
	[CheckCycle],
	[LastCheckDate],
	[ThisCheckDate],
	[Remark],
	[PurchaseDate],
	[GuaranteeDate],
	[GuaranteeEndDate],
	[TaskTypeID],
	[ProjectID],
	[LocationPlace] 
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
	[DeviceNo] nvarchar(100),
	[DeviceTypeID] int,
	[DeviceName] nvarchar(100),
	[DeviceGroupID] int,
	[ModelNo] nvarchar(100),
	[DeviceLevel] nvarchar(50),
	[RepairCompany] nvarchar(200),
	[Supplier] nvarchar(200),
	[RepairUserID] int,
	[CheckUserID] int,
	[FirstRepairDate] datetime,
	[FirstCheckDate] datetime,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[DeviceStatus] int,
	[RepairType] nvarchar(100),
	[SupplierMan] nvarchar(100),
	[SupplierPhone] nvarchar(100),
	[RepairUserPhone] nvarchar(100),
	[RepairCount] int,
	[RepairCycle] nvarchar(100),
	[LastRepairDate] datetime,
	[ThisRepairDate] datetime,
	[CheckCount] int,
	[CheckCycle] nvarchar(100),
	[LastCheckDate] datetime,
	[ThisCheckDate] datetime,
	[Remark] ntext,
	[PurchaseDate] datetime,
	[GuaranteeDate] nvarchar(50),
	[GuaranteeEndDate] datetime,
	[TaskTypeID] int,
	[ProjectID] int,
	[LocationPlace] nvarchar(200)
);

UPDATE [dbo].[Device] SET 
	[Device].[DeviceNo] = @DeviceNo,
	[Device].[DeviceTypeID] = @DeviceTypeID,
	[Device].[DeviceName] = @DeviceName,
	[Device].[DeviceGroupID] = @DeviceGroupID,
	[Device].[ModelNo] = @ModelNo,
	[Device].[DeviceLevel] = @DeviceLevel,
	[Device].[RepairCompany] = @RepairCompany,
	[Device].[Supplier] = @Supplier,
	[Device].[RepairUserID] = @RepairUserID,
	[Device].[CheckUserID] = @CheckUserID,
	[Device].[FirstRepairDate] = @FirstRepairDate,
	[Device].[FirstCheckDate] = @FirstCheckDate,
	[Device].[AddTime] = @AddTime,
	[Device].[AddMan] = @AddMan,
	[Device].[DeviceStatus] = @DeviceStatus,
	[Device].[RepairType] = @RepairType,
	[Device].[SupplierMan] = @SupplierMan,
	[Device].[SupplierPhone] = @SupplierPhone,
	[Device].[RepairUserPhone] = @RepairUserPhone,
	[Device].[RepairCount] = @RepairCount,
	[Device].[RepairCycle] = @RepairCycle,
	[Device].[LastRepairDate] = @LastRepairDate,
	[Device].[ThisRepairDate] = @ThisRepairDate,
	[Device].[CheckCount] = @CheckCount,
	[Device].[CheckCycle] = @CheckCycle,
	[Device].[LastCheckDate] = @LastCheckDate,
	[Device].[ThisCheckDate] = @ThisCheckDate,
	[Device].[Remark] = @Remark,
	[Device].[PurchaseDate] = @PurchaseDate,
	[Device].[GuaranteeDate] = @GuaranteeDate,
	[Device].[GuaranteeEndDate] = @GuaranteeEndDate,
	[Device].[TaskTypeID] = @TaskTypeID,
	[Device].[ProjectID] = @ProjectID,
	[Device].[LocationPlace] = @LocationPlace 
output 
	INSERTED.[ID],
	INSERTED.[DeviceNo],
	INSERTED.[DeviceTypeID],
	INSERTED.[DeviceName],
	INSERTED.[DeviceGroupID],
	INSERTED.[ModelNo],
	INSERTED.[DeviceLevel],
	INSERTED.[RepairCompany],
	INSERTED.[Supplier],
	INSERTED.[RepairUserID],
	INSERTED.[CheckUserID],
	INSERTED.[FirstRepairDate],
	INSERTED.[FirstCheckDate],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[DeviceStatus],
	INSERTED.[RepairType],
	INSERTED.[SupplierMan],
	INSERTED.[SupplierPhone],
	INSERTED.[RepairUserPhone],
	INSERTED.[RepairCount],
	INSERTED.[RepairCycle],
	INSERTED.[LastRepairDate],
	INSERTED.[ThisRepairDate],
	INSERTED.[CheckCount],
	INSERTED.[CheckCycle],
	INSERTED.[LastCheckDate],
	INSERTED.[ThisCheckDate],
	INSERTED.[Remark],
	INSERTED.[PurchaseDate],
	INSERTED.[GuaranteeDate],
	INSERTED.[GuaranteeEndDate],
	INSERTED.[TaskTypeID],
	INSERTED.[ProjectID],
	INSERTED.[LocationPlace]
into @table
WHERE 
	[Device].[ID] = @ID

SELECT 
	[ID],
	[DeviceNo],
	[DeviceTypeID],
	[DeviceName],
	[DeviceGroupID],
	[ModelNo],
	[DeviceLevel],
	[RepairCompany],
	[Supplier],
	[RepairUserID],
	[CheckUserID],
	[FirstRepairDate],
	[FirstCheckDate],
	[AddTime],
	[AddMan],
	[DeviceStatus],
	[RepairType],
	[SupplierMan],
	[SupplierPhone],
	[RepairUserPhone],
	[RepairCount],
	[RepairCycle],
	[LastRepairDate],
	[ThisRepairDate],
	[CheckCount],
	[CheckCycle],
	[LastCheckDate],
	[ThisCheckDate],
	[Remark],
	[PurchaseDate],
	[GuaranteeDate],
	[GuaranteeEndDate],
	[TaskTypeID],
	[ProjectID],
	[LocationPlace] 
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
DELETE FROM [dbo].[Device]
WHERE 
	[Device].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Device() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetDevice(this.ID));
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
	[Device].[ID],
	[Device].[DeviceNo],
	[Device].[DeviceTypeID],
	[Device].[DeviceName],
	[Device].[DeviceGroupID],
	[Device].[ModelNo],
	[Device].[DeviceLevel],
	[Device].[RepairCompany],
	[Device].[Supplier],
	[Device].[RepairUserID],
	[Device].[CheckUserID],
	[Device].[FirstRepairDate],
	[Device].[FirstCheckDate],
	[Device].[AddTime],
	[Device].[AddMan],
	[Device].[DeviceStatus],
	[Device].[RepairType],
	[Device].[SupplierMan],
	[Device].[SupplierPhone],
	[Device].[RepairUserPhone],
	[Device].[RepairCount],
	[Device].[RepairCycle],
	[Device].[LastRepairDate],
	[Device].[ThisRepairDate],
	[Device].[CheckCount],
	[Device].[CheckCycle],
	[Device].[LastCheckDate],
	[Device].[ThisCheckDate],
	[Device].[Remark],
	[Device].[PurchaseDate],
	[Device].[GuaranteeDate],
	[Device].[GuaranteeEndDate],
	[Device].[TaskTypeID],
	[Device].[ProjectID],
	[Device].[LocationPlace]
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
                return "Device";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Device into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="deviceNo">deviceNo</param>
		/// <param name="deviceTypeID">deviceTypeID</param>
		/// <param name="deviceName">deviceName</param>
		/// <param name="deviceGroupID">deviceGroupID</param>
		/// <param name="modelNo">modelNo</param>
		/// <param name="deviceLevel">deviceLevel</param>
		/// <param name="repairCompany">repairCompany</param>
		/// <param name="supplier">supplier</param>
		/// <param name="repairUserID">repairUserID</param>
		/// <param name="checkUserID">checkUserID</param>
		/// <param name="firstRepairDate">firstRepairDate</param>
		/// <param name="firstCheckDate">firstCheckDate</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="deviceStatus">deviceStatus</param>
		/// <param name="repairType">repairType</param>
		/// <param name="supplierMan">supplierMan</param>
		/// <param name="supplierPhone">supplierPhone</param>
		/// <param name="repairUserPhone">repairUserPhone</param>
		/// <param name="repairCount">repairCount</param>
		/// <param name="repairCycle">repairCycle</param>
		/// <param name="lastRepairDate">lastRepairDate</param>
		/// <param name="thisRepairDate">thisRepairDate</param>
		/// <param name="checkCount">checkCount</param>
		/// <param name="checkCycle">checkCycle</param>
		/// <param name="lastCheckDate">lastCheckDate</param>
		/// <param name="thisCheckDate">thisCheckDate</param>
		/// <param name="remark">remark</param>
		/// <param name="purchaseDate">purchaseDate</param>
		/// <param name="guaranteeDate">guaranteeDate</param>
		/// <param name="guaranteeEndDate">guaranteeEndDate</param>
		/// <param name="taskTypeID">taskTypeID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="locationPlace">locationPlace</param>
		public static void InsertDevice(string @deviceNo, int @deviceTypeID, string @deviceName, int @deviceGroupID, string @modelNo, string @deviceLevel, string @repairCompany, string @supplier, int @repairUserID, int @checkUserID, DateTime @firstRepairDate, DateTime @firstCheckDate, DateTime @addTime, string @addMan, int @deviceStatus, string @repairType, string @supplierMan, string @supplierPhone, string @repairUserPhone, int @repairCount, string @repairCycle, DateTime @lastRepairDate, DateTime @thisRepairDate, int @checkCount, string @checkCycle, DateTime @lastCheckDate, DateTime @thisCheckDate, string @remark, DateTime @purchaseDate, string @guaranteeDate, DateTime @guaranteeEndDate, int @taskTypeID, int @projectID, string @locationPlace)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertDevice(@deviceNo, @deviceTypeID, @deviceName, @deviceGroupID, @modelNo, @deviceLevel, @repairCompany, @supplier, @repairUserID, @checkUserID, @firstRepairDate, @firstCheckDate, @addTime, @addMan, @deviceStatus, @repairType, @supplierMan, @supplierPhone, @repairUserPhone, @repairCount, @repairCycle, @lastRepairDate, @thisRepairDate, @checkCount, @checkCycle, @lastCheckDate, @thisCheckDate, @remark, @purchaseDate, @guaranteeDate, @guaranteeEndDate, @taskTypeID, @projectID, @locationPlace, helper);
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
		/// Insert a Device into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="deviceNo">deviceNo</param>
		/// <param name="deviceTypeID">deviceTypeID</param>
		/// <param name="deviceName">deviceName</param>
		/// <param name="deviceGroupID">deviceGroupID</param>
		/// <param name="modelNo">modelNo</param>
		/// <param name="deviceLevel">deviceLevel</param>
		/// <param name="repairCompany">repairCompany</param>
		/// <param name="supplier">supplier</param>
		/// <param name="repairUserID">repairUserID</param>
		/// <param name="checkUserID">checkUserID</param>
		/// <param name="firstRepairDate">firstRepairDate</param>
		/// <param name="firstCheckDate">firstCheckDate</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="deviceStatus">deviceStatus</param>
		/// <param name="repairType">repairType</param>
		/// <param name="supplierMan">supplierMan</param>
		/// <param name="supplierPhone">supplierPhone</param>
		/// <param name="repairUserPhone">repairUserPhone</param>
		/// <param name="repairCount">repairCount</param>
		/// <param name="repairCycle">repairCycle</param>
		/// <param name="lastRepairDate">lastRepairDate</param>
		/// <param name="thisRepairDate">thisRepairDate</param>
		/// <param name="checkCount">checkCount</param>
		/// <param name="checkCycle">checkCycle</param>
		/// <param name="lastCheckDate">lastCheckDate</param>
		/// <param name="thisCheckDate">thisCheckDate</param>
		/// <param name="remark">remark</param>
		/// <param name="purchaseDate">purchaseDate</param>
		/// <param name="guaranteeDate">guaranteeDate</param>
		/// <param name="guaranteeEndDate">guaranteeEndDate</param>
		/// <param name="taskTypeID">taskTypeID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="locationPlace">locationPlace</param>
		/// <param name="helper">helper</param>
		internal static void InsertDevice(string @deviceNo, int @deviceTypeID, string @deviceName, int @deviceGroupID, string @modelNo, string @deviceLevel, string @repairCompany, string @supplier, int @repairUserID, int @checkUserID, DateTime @firstRepairDate, DateTime @firstCheckDate, DateTime @addTime, string @addMan, int @deviceStatus, string @repairType, string @supplierMan, string @supplierPhone, string @repairUserPhone, int @repairCount, string @repairCycle, DateTime @lastRepairDate, DateTime @thisRepairDate, int @checkCount, string @checkCycle, DateTime @lastCheckDate, DateTime @thisCheckDate, string @remark, DateTime @purchaseDate, string @guaranteeDate, DateTime @guaranteeEndDate, int @taskTypeID, int @projectID, string @locationPlace, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DeviceNo] nvarchar(100),
	[DeviceTypeID] int,
	[DeviceName] nvarchar(100),
	[DeviceGroupID] int,
	[ModelNo] nvarchar(100),
	[DeviceLevel] nvarchar(50),
	[RepairCompany] nvarchar(200),
	[Supplier] nvarchar(200),
	[RepairUserID] int,
	[CheckUserID] int,
	[FirstRepairDate] datetime,
	[FirstCheckDate] datetime,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[DeviceStatus] int,
	[RepairType] nvarchar(100),
	[SupplierMan] nvarchar(100),
	[SupplierPhone] nvarchar(100),
	[RepairUserPhone] nvarchar(100),
	[RepairCount] int,
	[RepairCycle] nvarchar(100),
	[LastRepairDate] datetime,
	[ThisRepairDate] datetime,
	[CheckCount] int,
	[CheckCycle] nvarchar(100),
	[LastCheckDate] datetime,
	[ThisCheckDate] datetime,
	[Remark] ntext,
	[PurchaseDate] datetime,
	[GuaranteeDate] nvarchar(50),
	[GuaranteeEndDate] datetime,
	[TaskTypeID] int,
	[ProjectID] int,
	[LocationPlace] nvarchar(200)
);

INSERT INTO [dbo].[Device] (
	[Device].[DeviceNo],
	[Device].[DeviceTypeID],
	[Device].[DeviceName],
	[Device].[DeviceGroupID],
	[Device].[ModelNo],
	[Device].[DeviceLevel],
	[Device].[RepairCompany],
	[Device].[Supplier],
	[Device].[RepairUserID],
	[Device].[CheckUserID],
	[Device].[FirstRepairDate],
	[Device].[FirstCheckDate],
	[Device].[AddTime],
	[Device].[AddMan],
	[Device].[DeviceStatus],
	[Device].[RepairType],
	[Device].[SupplierMan],
	[Device].[SupplierPhone],
	[Device].[RepairUserPhone],
	[Device].[RepairCount],
	[Device].[RepairCycle],
	[Device].[LastRepairDate],
	[Device].[ThisRepairDate],
	[Device].[CheckCount],
	[Device].[CheckCycle],
	[Device].[LastCheckDate],
	[Device].[ThisCheckDate],
	[Device].[Remark],
	[Device].[PurchaseDate],
	[Device].[GuaranteeDate],
	[Device].[GuaranteeEndDate],
	[Device].[TaskTypeID],
	[Device].[ProjectID],
	[Device].[LocationPlace]
) 
output 
	INSERTED.[ID],
	INSERTED.[DeviceNo],
	INSERTED.[DeviceTypeID],
	INSERTED.[DeviceName],
	INSERTED.[DeviceGroupID],
	INSERTED.[ModelNo],
	INSERTED.[DeviceLevel],
	INSERTED.[RepairCompany],
	INSERTED.[Supplier],
	INSERTED.[RepairUserID],
	INSERTED.[CheckUserID],
	INSERTED.[FirstRepairDate],
	INSERTED.[FirstCheckDate],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[DeviceStatus],
	INSERTED.[RepairType],
	INSERTED.[SupplierMan],
	INSERTED.[SupplierPhone],
	INSERTED.[RepairUserPhone],
	INSERTED.[RepairCount],
	INSERTED.[RepairCycle],
	INSERTED.[LastRepairDate],
	INSERTED.[ThisRepairDate],
	INSERTED.[CheckCount],
	INSERTED.[CheckCycle],
	INSERTED.[LastCheckDate],
	INSERTED.[ThisCheckDate],
	INSERTED.[Remark],
	INSERTED.[PurchaseDate],
	INSERTED.[GuaranteeDate],
	INSERTED.[GuaranteeEndDate],
	INSERTED.[TaskTypeID],
	INSERTED.[ProjectID],
	INSERTED.[LocationPlace]
into @table
VALUES ( 
	@DeviceNo,
	@DeviceTypeID,
	@DeviceName,
	@DeviceGroupID,
	@ModelNo,
	@DeviceLevel,
	@RepairCompany,
	@Supplier,
	@RepairUserID,
	@CheckUserID,
	@FirstRepairDate,
	@FirstCheckDate,
	@AddTime,
	@AddMan,
	@DeviceStatus,
	@RepairType,
	@SupplierMan,
	@SupplierPhone,
	@RepairUserPhone,
	@RepairCount,
	@RepairCycle,
	@LastRepairDate,
	@ThisRepairDate,
	@CheckCount,
	@CheckCycle,
	@LastCheckDate,
	@ThisCheckDate,
	@Remark,
	@PurchaseDate,
	@GuaranteeDate,
	@GuaranteeEndDate,
	@TaskTypeID,
	@ProjectID,
	@LocationPlace 
); 

SELECT 
	[ID],
	[DeviceNo],
	[DeviceTypeID],
	[DeviceName],
	[DeviceGroupID],
	[ModelNo],
	[DeviceLevel],
	[RepairCompany],
	[Supplier],
	[RepairUserID],
	[CheckUserID],
	[FirstRepairDate],
	[FirstCheckDate],
	[AddTime],
	[AddMan],
	[DeviceStatus],
	[RepairType],
	[SupplierMan],
	[SupplierPhone],
	[RepairUserPhone],
	[RepairCount],
	[RepairCycle],
	[LastRepairDate],
	[ThisRepairDate],
	[CheckCount],
	[CheckCycle],
	[LastCheckDate],
	[ThisCheckDate],
	[Remark],
	[PurchaseDate],
	[GuaranteeDate],
	[GuaranteeEndDate],
	[TaskTypeID],
	[ProjectID],
	[LocationPlace] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DeviceNo", EntityBase.GetDatabaseValue(@deviceNo)));
			parameters.Add(new SqlParameter("@DeviceTypeID", EntityBase.GetDatabaseValue(@deviceTypeID)));
			parameters.Add(new SqlParameter("@DeviceName", EntityBase.GetDatabaseValue(@deviceName)));
			parameters.Add(new SqlParameter("@DeviceGroupID", EntityBase.GetDatabaseValue(@deviceGroupID)));
			parameters.Add(new SqlParameter("@ModelNo", EntityBase.GetDatabaseValue(@modelNo)));
			parameters.Add(new SqlParameter("@DeviceLevel", EntityBase.GetDatabaseValue(@deviceLevel)));
			parameters.Add(new SqlParameter("@RepairCompany", EntityBase.GetDatabaseValue(@repairCompany)));
			parameters.Add(new SqlParameter("@Supplier", EntityBase.GetDatabaseValue(@supplier)));
			parameters.Add(new SqlParameter("@RepairUserID", EntityBase.GetDatabaseValue(@repairUserID)));
			parameters.Add(new SqlParameter("@CheckUserID", EntityBase.GetDatabaseValue(@checkUserID)));
			parameters.Add(new SqlParameter("@FirstRepairDate", EntityBase.GetDatabaseValue(@firstRepairDate)));
			parameters.Add(new SqlParameter("@FirstCheckDate", EntityBase.GetDatabaseValue(@firstCheckDate)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@DeviceStatus", EntityBase.GetDatabaseValue(@deviceStatus)));
			parameters.Add(new SqlParameter("@RepairType", EntityBase.GetDatabaseValue(@repairType)));
			parameters.Add(new SqlParameter("@SupplierMan", EntityBase.GetDatabaseValue(@supplierMan)));
			parameters.Add(new SqlParameter("@SupplierPhone", EntityBase.GetDatabaseValue(@supplierPhone)));
			parameters.Add(new SqlParameter("@RepairUserPhone", EntityBase.GetDatabaseValue(@repairUserPhone)));
			parameters.Add(new SqlParameter("@RepairCount", EntityBase.GetDatabaseValue(@repairCount)));
			parameters.Add(new SqlParameter("@RepairCycle", EntityBase.GetDatabaseValue(@repairCycle)));
			parameters.Add(new SqlParameter("@LastRepairDate", EntityBase.GetDatabaseValue(@lastRepairDate)));
			parameters.Add(new SqlParameter("@ThisRepairDate", EntityBase.GetDatabaseValue(@thisRepairDate)));
			parameters.Add(new SqlParameter("@CheckCount", EntityBase.GetDatabaseValue(@checkCount)));
			parameters.Add(new SqlParameter("@CheckCycle", EntityBase.GetDatabaseValue(@checkCycle)));
			parameters.Add(new SqlParameter("@LastCheckDate", EntityBase.GetDatabaseValue(@lastCheckDate)));
			parameters.Add(new SqlParameter("@ThisCheckDate", EntityBase.GetDatabaseValue(@thisCheckDate)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@PurchaseDate", EntityBase.GetDatabaseValue(@purchaseDate)));
			parameters.Add(new SqlParameter("@GuaranteeDate", EntityBase.GetDatabaseValue(@guaranteeDate)));
			parameters.Add(new SqlParameter("@GuaranteeEndDate", EntityBase.GetDatabaseValue(@guaranteeEndDate)));
			parameters.Add(new SqlParameter("@TaskTypeID", EntityBase.GetDatabaseValue(@taskTypeID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@LocationPlace", EntityBase.GetDatabaseValue(@locationPlace)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Device into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="deviceNo">deviceNo</param>
		/// <param name="deviceTypeID">deviceTypeID</param>
		/// <param name="deviceName">deviceName</param>
		/// <param name="deviceGroupID">deviceGroupID</param>
		/// <param name="modelNo">modelNo</param>
		/// <param name="deviceLevel">deviceLevel</param>
		/// <param name="repairCompany">repairCompany</param>
		/// <param name="supplier">supplier</param>
		/// <param name="repairUserID">repairUserID</param>
		/// <param name="checkUserID">checkUserID</param>
		/// <param name="firstRepairDate">firstRepairDate</param>
		/// <param name="firstCheckDate">firstCheckDate</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="deviceStatus">deviceStatus</param>
		/// <param name="repairType">repairType</param>
		/// <param name="supplierMan">supplierMan</param>
		/// <param name="supplierPhone">supplierPhone</param>
		/// <param name="repairUserPhone">repairUserPhone</param>
		/// <param name="repairCount">repairCount</param>
		/// <param name="repairCycle">repairCycle</param>
		/// <param name="lastRepairDate">lastRepairDate</param>
		/// <param name="thisRepairDate">thisRepairDate</param>
		/// <param name="checkCount">checkCount</param>
		/// <param name="checkCycle">checkCycle</param>
		/// <param name="lastCheckDate">lastCheckDate</param>
		/// <param name="thisCheckDate">thisCheckDate</param>
		/// <param name="remark">remark</param>
		/// <param name="purchaseDate">purchaseDate</param>
		/// <param name="guaranteeDate">guaranteeDate</param>
		/// <param name="guaranteeEndDate">guaranteeEndDate</param>
		/// <param name="taskTypeID">taskTypeID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="locationPlace">locationPlace</param>
		public static void UpdateDevice(int @iD, string @deviceNo, int @deviceTypeID, string @deviceName, int @deviceGroupID, string @modelNo, string @deviceLevel, string @repairCompany, string @supplier, int @repairUserID, int @checkUserID, DateTime @firstRepairDate, DateTime @firstCheckDate, DateTime @addTime, string @addMan, int @deviceStatus, string @repairType, string @supplierMan, string @supplierPhone, string @repairUserPhone, int @repairCount, string @repairCycle, DateTime @lastRepairDate, DateTime @thisRepairDate, int @checkCount, string @checkCycle, DateTime @lastCheckDate, DateTime @thisCheckDate, string @remark, DateTime @purchaseDate, string @guaranteeDate, DateTime @guaranteeEndDate, int @taskTypeID, int @projectID, string @locationPlace)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateDevice(@iD, @deviceNo, @deviceTypeID, @deviceName, @deviceGroupID, @modelNo, @deviceLevel, @repairCompany, @supplier, @repairUserID, @checkUserID, @firstRepairDate, @firstCheckDate, @addTime, @addMan, @deviceStatus, @repairType, @supplierMan, @supplierPhone, @repairUserPhone, @repairCount, @repairCycle, @lastRepairDate, @thisRepairDate, @checkCount, @checkCycle, @lastCheckDate, @thisCheckDate, @remark, @purchaseDate, @guaranteeDate, @guaranteeEndDate, @taskTypeID, @projectID, @locationPlace, helper);
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
		/// Updates a Device into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="deviceNo">deviceNo</param>
		/// <param name="deviceTypeID">deviceTypeID</param>
		/// <param name="deviceName">deviceName</param>
		/// <param name="deviceGroupID">deviceGroupID</param>
		/// <param name="modelNo">modelNo</param>
		/// <param name="deviceLevel">deviceLevel</param>
		/// <param name="repairCompany">repairCompany</param>
		/// <param name="supplier">supplier</param>
		/// <param name="repairUserID">repairUserID</param>
		/// <param name="checkUserID">checkUserID</param>
		/// <param name="firstRepairDate">firstRepairDate</param>
		/// <param name="firstCheckDate">firstCheckDate</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="deviceStatus">deviceStatus</param>
		/// <param name="repairType">repairType</param>
		/// <param name="supplierMan">supplierMan</param>
		/// <param name="supplierPhone">supplierPhone</param>
		/// <param name="repairUserPhone">repairUserPhone</param>
		/// <param name="repairCount">repairCount</param>
		/// <param name="repairCycle">repairCycle</param>
		/// <param name="lastRepairDate">lastRepairDate</param>
		/// <param name="thisRepairDate">thisRepairDate</param>
		/// <param name="checkCount">checkCount</param>
		/// <param name="checkCycle">checkCycle</param>
		/// <param name="lastCheckDate">lastCheckDate</param>
		/// <param name="thisCheckDate">thisCheckDate</param>
		/// <param name="remark">remark</param>
		/// <param name="purchaseDate">purchaseDate</param>
		/// <param name="guaranteeDate">guaranteeDate</param>
		/// <param name="guaranteeEndDate">guaranteeEndDate</param>
		/// <param name="taskTypeID">taskTypeID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="locationPlace">locationPlace</param>
		/// <param name="helper">helper</param>
		internal static void UpdateDevice(int @iD, string @deviceNo, int @deviceTypeID, string @deviceName, int @deviceGroupID, string @modelNo, string @deviceLevel, string @repairCompany, string @supplier, int @repairUserID, int @checkUserID, DateTime @firstRepairDate, DateTime @firstCheckDate, DateTime @addTime, string @addMan, int @deviceStatus, string @repairType, string @supplierMan, string @supplierPhone, string @repairUserPhone, int @repairCount, string @repairCycle, DateTime @lastRepairDate, DateTime @thisRepairDate, int @checkCount, string @checkCycle, DateTime @lastCheckDate, DateTime @thisCheckDate, string @remark, DateTime @purchaseDate, string @guaranteeDate, DateTime @guaranteeEndDate, int @taskTypeID, int @projectID, string @locationPlace, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DeviceNo] nvarchar(100),
	[DeviceTypeID] int,
	[DeviceName] nvarchar(100),
	[DeviceGroupID] int,
	[ModelNo] nvarchar(100),
	[DeviceLevel] nvarchar(50),
	[RepairCompany] nvarchar(200),
	[Supplier] nvarchar(200),
	[RepairUserID] int,
	[CheckUserID] int,
	[FirstRepairDate] datetime,
	[FirstCheckDate] datetime,
	[AddTime] datetime,
	[AddMan] nvarchar(100),
	[DeviceStatus] int,
	[RepairType] nvarchar(100),
	[SupplierMan] nvarchar(100),
	[SupplierPhone] nvarchar(100),
	[RepairUserPhone] nvarchar(100),
	[RepairCount] int,
	[RepairCycle] nvarchar(100),
	[LastRepairDate] datetime,
	[ThisRepairDate] datetime,
	[CheckCount] int,
	[CheckCycle] nvarchar(100),
	[LastCheckDate] datetime,
	[ThisCheckDate] datetime,
	[Remark] ntext,
	[PurchaseDate] datetime,
	[GuaranteeDate] nvarchar(50),
	[GuaranteeEndDate] datetime,
	[TaskTypeID] int,
	[ProjectID] int,
	[LocationPlace] nvarchar(200)
);

UPDATE [dbo].[Device] SET 
	[Device].[DeviceNo] = @DeviceNo,
	[Device].[DeviceTypeID] = @DeviceTypeID,
	[Device].[DeviceName] = @DeviceName,
	[Device].[DeviceGroupID] = @DeviceGroupID,
	[Device].[ModelNo] = @ModelNo,
	[Device].[DeviceLevel] = @DeviceLevel,
	[Device].[RepairCompany] = @RepairCompany,
	[Device].[Supplier] = @Supplier,
	[Device].[RepairUserID] = @RepairUserID,
	[Device].[CheckUserID] = @CheckUserID,
	[Device].[FirstRepairDate] = @FirstRepairDate,
	[Device].[FirstCheckDate] = @FirstCheckDate,
	[Device].[AddTime] = @AddTime,
	[Device].[AddMan] = @AddMan,
	[Device].[DeviceStatus] = @DeviceStatus,
	[Device].[RepairType] = @RepairType,
	[Device].[SupplierMan] = @SupplierMan,
	[Device].[SupplierPhone] = @SupplierPhone,
	[Device].[RepairUserPhone] = @RepairUserPhone,
	[Device].[RepairCount] = @RepairCount,
	[Device].[RepairCycle] = @RepairCycle,
	[Device].[LastRepairDate] = @LastRepairDate,
	[Device].[ThisRepairDate] = @ThisRepairDate,
	[Device].[CheckCount] = @CheckCount,
	[Device].[CheckCycle] = @CheckCycle,
	[Device].[LastCheckDate] = @LastCheckDate,
	[Device].[ThisCheckDate] = @ThisCheckDate,
	[Device].[Remark] = @Remark,
	[Device].[PurchaseDate] = @PurchaseDate,
	[Device].[GuaranteeDate] = @GuaranteeDate,
	[Device].[GuaranteeEndDate] = @GuaranteeEndDate,
	[Device].[TaskTypeID] = @TaskTypeID,
	[Device].[ProjectID] = @ProjectID,
	[Device].[LocationPlace] = @LocationPlace 
output 
	INSERTED.[ID],
	INSERTED.[DeviceNo],
	INSERTED.[DeviceTypeID],
	INSERTED.[DeviceName],
	INSERTED.[DeviceGroupID],
	INSERTED.[ModelNo],
	INSERTED.[DeviceLevel],
	INSERTED.[RepairCompany],
	INSERTED.[Supplier],
	INSERTED.[RepairUserID],
	INSERTED.[CheckUserID],
	INSERTED.[FirstRepairDate],
	INSERTED.[FirstCheckDate],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[DeviceStatus],
	INSERTED.[RepairType],
	INSERTED.[SupplierMan],
	INSERTED.[SupplierPhone],
	INSERTED.[RepairUserPhone],
	INSERTED.[RepairCount],
	INSERTED.[RepairCycle],
	INSERTED.[LastRepairDate],
	INSERTED.[ThisRepairDate],
	INSERTED.[CheckCount],
	INSERTED.[CheckCycle],
	INSERTED.[LastCheckDate],
	INSERTED.[ThisCheckDate],
	INSERTED.[Remark],
	INSERTED.[PurchaseDate],
	INSERTED.[GuaranteeDate],
	INSERTED.[GuaranteeEndDate],
	INSERTED.[TaskTypeID],
	INSERTED.[ProjectID],
	INSERTED.[LocationPlace]
into @table
WHERE 
	[Device].[ID] = @ID

SELECT 
	[ID],
	[DeviceNo],
	[DeviceTypeID],
	[DeviceName],
	[DeviceGroupID],
	[ModelNo],
	[DeviceLevel],
	[RepairCompany],
	[Supplier],
	[RepairUserID],
	[CheckUserID],
	[FirstRepairDate],
	[FirstCheckDate],
	[AddTime],
	[AddMan],
	[DeviceStatus],
	[RepairType],
	[SupplierMan],
	[SupplierPhone],
	[RepairUserPhone],
	[RepairCount],
	[RepairCycle],
	[LastRepairDate],
	[ThisRepairDate],
	[CheckCount],
	[CheckCycle],
	[LastCheckDate],
	[ThisCheckDate],
	[Remark],
	[PurchaseDate],
	[GuaranteeDate],
	[GuaranteeEndDate],
	[TaskTypeID],
	[ProjectID],
	[LocationPlace] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@DeviceNo", EntityBase.GetDatabaseValue(@deviceNo)));
			parameters.Add(new SqlParameter("@DeviceTypeID", EntityBase.GetDatabaseValue(@deviceTypeID)));
			parameters.Add(new SqlParameter("@DeviceName", EntityBase.GetDatabaseValue(@deviceName)));
			parameters.Add(new SqlParameter("@DeviceGroupID", EntityBase.GetDatabaseValue(@deviceGroupID)));
			parameters.Add(new SqlParameter("@ModelNo", EntityBase.GetDatabaseValue(@modelNo)));
			parameters.Add(new SqlParameter("@DeviceLevel", EntityBase.GetDatabaseValue(@deviceLevel)));
			parameters.Add(new SqlParameter("@RepairCompany", EntityBase.GetDatabaseValue(@repairCompany)));
			parameters.Add(new SqlParameter("@Supplier", EntityBase.GetDatabaseValue(@supplier)));
			parameters.Add(new SqlParameter("@RepairUserID", EntityBase.GetDatabaseValue(@repairUserID)));
			parameters.Add(new SqlParameter("@CheckUserID", EntityBase.GetDatabaseValue(@checkUserID)));
			parameters.Add(new SqlParameter("@FirstRepairDate", EntityBase.GetDatabaseValue(@firstRepairDate)));
			parameters.Add(new SqlParameter("@FirstCheckDate", EntityBase.GetDatabaseValue(@firstCheckDate)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@DeviceStatus", EntityBase.GetDatabaseValue(@deviceStatus)));
			parameters.Add(new SqlParameter("@RepairType", EntityBase.GetDatabaseValue(@repairType)));
			parameters.Add(new SqlParameter("@SupplierMan", EntityBase.GetDatabaseValue(@supplierMan)));
			parameters.Add(new SqlParameter("@SupplierPhone", EntityBase.GetDatabaseValue(@supplierPhone)));
			parameters.Add(new SqlParameter("@RepairUserPhone", EntityBase.GetDatabaseValue(@repairUserPhone)));
			parameters.Add(new SqlParameter("@RepairCount", EntityBase.GetDatabaseValue(@repairCount)));
			parameters.Add(new SqlParameter("@RepairCycle", EntityBase.GetDatabaseValue(@repairCycle)));
			parameters.Add(new SqlParameter("@LastRepairDate", EntityBase.GetDatabaseValue(@lastRepairDate)));
			parameters.Add(new SqlParameter("@ThisRepairDate", EntityBase.GetDatabaseValue(@thisRepairDate)));
			parameters.Add(new SqlParameter("@CheckCount", EntityBase.GetDatabaseValue(@checkCount)));
			parameters.Add(new SqlParameter("@CheckCycle", EntityBase.GetDatabaseValue(@checkCycle)));
			parameters.Add(new SqlParameter("@LastCheckDate", EntityBase.GetDatabaseValue(@lastCheckDate)));
			parameters.Add(new SqlParameter("@ThisCheckDate", EntityBase.GetDatabaseValue(@thisCheckDate)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@PurchaseDate", EntityBase.GetDatabaseValue(@purchaseDate)));
			parameters.Add(new SqlParameter("@GuaranteeDate", EntityBase.GetDatabaseValue(@guaranteeDate)));
			parameters.Add(new SqlParameter("@GuaranteeEndDate", EntityBase.GetDatabaseValue(@guaranteeEndDate)));
			parameters.Add(new SqlParameter("@TaskTypeID", EntityBase.GetDatabaseValue(@taskTypeID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@LocationPlace", EntityBase.GetDatabaseValue(@locationPlace)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Device from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteDevice(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteDevice(@iD, helper);
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
		/// Deletes a Device from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteDevice(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Device]
WHERE 
	[Device].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Device object.
		/// </summary>
		/// <returns>The newly created Device object.</returns>
		public static Device CreateDevice()
		{
			return InitializeNew<Device>();
		}
		
		/// <summary>
		/// Retrieve information for a Device by a Device's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Device</returns>
		public static Device GetDevice(int @iD)
		{
			string commandText = @"
SELECT 
" + Device.SelectFieldList + @"
FROM [dbo].[Device] 
WHERE 
	[Device].[ID] = @ID " + Device.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Device>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Device by a Device's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Device</returns>
		public static Device GetDevice(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Device.SelectFieldList + @"
FROM [dbo].[Device] 
WHERE 
	[Device].[ID] = @ID " + Device.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Device>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Device objects.
		/// </summary>
		/// <returns>The retrieved collection of Device objects.</returns>
		public static EntityList<Device> GetDevices()
		{
			string commandText = @"
SELECT " + Device.SelectFieldList + "FROM [dbo].[Device] " + Device.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Device>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Device objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Device objects.</returns>
        public static EntityList<Device> GetDevices(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Device>(SelectFieldList, "FROM [dbo].[Device]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Device objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Device objects.</returns>
        public static EntityList<Device> GetDevices(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Device>(SelectFieldList, "FROM [dbo].[Device]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Device objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Device objects.</returns>
		protected static EntityList<Device> GetDevices(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDevices(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Device objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Device objects.</returns>
		protected static EntityList<Device> GetDevices(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDevices(string.Empty, where, parameters, Device.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Device objects.</returns>
		protected static EntityList<Device> GetDevices(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDevices(prefix, where, parameters, Device.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Device objects.</returns>
		protected static EntityList<Device> GetDevices(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetDevices(string.Empty, where, parameters, Device.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Device objects.</returns>
		protected static EntityList<Device> GetDevices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetDevices(prefix, where, parameters, Device.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Device objects.</returns>
		protected static EntityList<Device> GetDevices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Device.SelectFieldList + "FROM [dbo].[Device] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Device>(reader);
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
        protected static EntityList<Device> GetDevices(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Device>(SelectFieldList, "FROM [dbo].[Device] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Device objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetDeviceCount()
        {
            return GetDeviceCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Device objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetDeviceCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Device] " + where;

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
		public static partial class Device_Properties
		{
			public const string ID = "ID";
			public const string DeviceNo = "DeviceNo";
			public const string DeviceTypeID = "DeviceTypeID";
			public const string DeviceName = "DeviceName";
			public const string DeviceGroupID = "DeviceGroupID";
			public const string ModelNo = "ModelNo";
			public const string DeviceLevel = "DeviceLevel";
			public const string RepairCompany = "RepairCompany";
			public const string Supplier = "Supplier";
			public const string RepairUserID = "RepairUserID";
			public const string CheckUserID = "CheckUserID";
			public const string FirstRepairDate = "FirstRepairDate";
			public const string FirstCheckDate = "FirstCheckDate";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string DeviceStatus = "DeviceStatus";
			public const string RepairType = "RepairType";
			public const string SupplierMan = "SupplierMan";
			public const string SupplierPhone = "SupplierPhone";
			public const string RepairUserPhone = "RepairUserPhone";
			public const string RepairCount = "RepairCount";
			public const string RepairCycle = "RepairCycle";
			public const string LastRepairDate = "LastRepairDate";
			public const string ThisRepairDate = "ThisRepairDate";
			public const string CheckCount = "CheckCount";
			public const string CheckCycle = "CheckCycle";
			public const string LastCheckDate = "LastCheckDate";
			public const string ThisCheckDate = "ThisCheckDate";
			public const string Remark = "Remark";
			public const string PurchaseDate = "PurchaseDate";
			public const string GuaranteeDate = "GuaranteeDate";
			public const string GuaranteeEndDate = "GuaranteeEndDate";
			public const string TaskTypeID = "TaskTypeID";
			public const string ProjectID = "ProjectID";
			public const string LocationPlace = "LocationPlace";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"DeviceNo" , "string:"},
    			 {"DeviceTypeID" , "int:"},
    			 {"DeviceName" , "string:"},
    			 {"DeviceGroupID" , "int:"},
    			 {"ModelNo" , "string:"},
    			 {"DeviceLevel" , "string:"},
    			 {"RepairCompany" , "string:"},
    			 {"Supplier" , "string:"},
    			 {"RepairUserID" , "int:"},
    			 {"CheckUserID" , "int:"},
    			 {"FirstRepairDate" , "DateTime:"},
    			 {"FirstCheckDate" , "DateTime:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"DeviceStatus" , "int:"},
    			 {"RepairType" , "string:"},
    			 {"SupplierMan" , "string:"},
    			 {"SupplierPhone" , "string:"},
    			 {"RepairUserPhone" , "string:"},
    			 {"RepairCount" , "int:"},
    			 {"RepairCycle" , "string:"},
    			 {"LastRepairDate" , "DateTime:"},
    			 {"ThisRepairDate" , "DateTime:"},
    			 {"CheckCount" , "int:"},
    			 {"CheckCycle" , "string:"},
    			 {"LastCheckDate" , "DateTime:"},
    			 {"ThisCheckDate" , "DateTime:"},
    			 {"Remark" , "string:"},
    			 {"PurchaseDate" , "DateTime:"},
    			 {"GuaranteeDate" , "string:"},
    			 {"GuaranteeEndDate" , "DateTime:"},
    			 {"TaskTypeID" , "int:"},
    			 {"ProjectID" , "int:"},
    			 {"LocationPlace" , "string:"},
            };
		}
		#endregion
	}
}
