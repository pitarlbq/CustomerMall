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
	/// This object represents the properties and methods of a Cheque_Outing.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_Outing 
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
		private DateTime _notifyTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime NotifyTime
		{
			[DebuggerStepThrough()]
			get { return this._notifyTime; }
			set 
			{
				if (this._notifyTime != value) 
				{
					this._notifyTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("NotifyTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _operator = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Operator
		{
			[DebuggerStepThrough()]
			get { return this._operator; }
			set 
			{
				if (this._operator != value) 
				{
					this._operator = value;
					this.IsDirty = true;	
					OnPropertyChanged("Operator");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _operationTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime OperationTime
		{
			[DebuggerStepThrough()]
			get { return this._operationTime; }
			set 
			{
				if (this._operationTime != value) 
				{
					this._operationTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("OperationTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _iDCardStatus = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string IDCardStatus
		{
			[DebuggerStepThrough()]
			get { return this._iDCardStatus; }
			set 
			{
				if (this._iDCardStatus != value) 
				{
					this._iDCardStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("IDCardStatus");
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
		private string _currentProjectName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CurrentProjectName
		{
			[DebuggerStepThrough()]
			get { return this._currentProjectName; }
			set 
			{
				if (this._currentProjectName != value) 
				{
					this._currentProjectName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CurrentProjectName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _belongCompanyName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BelongCompanyName
		{
			[DebuggerStepThrough()]
			get { return this._belongCompanyName; }
			set 
			{
				if (this._belongCompanyName != value) 
				{
					this._belongCompanyName = value;
					this.IsDirty = true;	
					OnPropertyChanged("BelongCompanyName");
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
		private string _paperNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PaperNumber
		{
			[DebuggerStepThrough()]
			get { return this._paperNumber; }
			set 
			{
				if (this._paperNumber != value) 
				{
					this._paperNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("PaperNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _outingAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OutingAddress
		{
			[DebuggerStepThrough()]
			get { return this._outingAddress; }
			set 
			{
				if (this._outingAddress != value) 
				{
					this._outingAddress = value;
					this.IsDirty = true;	
					OnPropertyChanged("OutingAddress");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveMan
		{
			[DebuggerStepThrough()]
			get { return this._approveMan; }
			set 
			{
				if (this._approveMan != value) 
				{
					this._approveMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _approveTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ApproveTime
		{
			[DebuggerStepThrough()]
			get { return this._approveTime; }
			set 
			{
				if (this._approveTime != value) 
				{
					this._approveTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _approveStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ApproveStatus
		{
			[DebuggerStepThrough()]
			get { return this._approveStatus; }
			set 
			{
				if (this._approveStatus != value) 
				{
					this._approveStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveStatus");
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
		private string _belongCompanyName1 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BelongCompanyName1
		{
			[DebuggerStepThrough()]
			get { return this._belongCompanyName1; }
			set 
			{
				if (this._belongCompanyName1 != value) 
				{
					this._belongCompanyName1 = value;
					this.IsDirty = true;	
					OnPropertyChanged("BelongCompanyName1");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _departmentID1 = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int DepartmentID1
		{
			[DebuggerStepThrough()]
			get { return this._departmentID1; }
			set 
			{
				if (this._departmentID1 != value) 
				{
					this._departmentID1 = value;
					this.IsDirty = true;	
					OnPropertyChanged("DepartmentID1");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _paperNumber1 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PaperNumber1
		{
			[DebuggerStepThrough()]
			get { return this._paperNumber1; }
			set 
			{
				if (this._paperNumber1 != value) 
				{
					this._paperNumber1 = value;
					this.IsDirty = true;	
					OnPropertyChanged("PaperNumber1");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _outingAddress1 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OutingAddress1
		{
			[DebuggerStepThrough()]
			get { return this._outingAddress1; }
			set 
			{
				if (this._outingAddress1 != value) 
				{
					this._outingAddress1 = value;
					this.IsDirty = true;	
					OnPropertyChanged("OutingAddress1");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveMan1 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveMan1
		{
			[DebuggerStepThrough()]
			get { return this._approveMan1; }
			set 
			{
				if (this._approveMan1 != value) 
				{
					this._approveMan1 = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveMan1");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _approveTime1 = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ApproveTime1
		{
			[DebuggerStepThrough()]
			get { return this._approveTime1; }
			set 
			{
				if (this._approveTime1 != value) 
				{
					this._approveTime1 = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveTime1");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _approveStatus1 = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ApproveStatus1
		{
			[DebuggerStepThrough()]
			get { return this._approveStatus1; }
			set 
			{
				if (this._approveStatus1 != value) 
				{
					this._approveStatus1 = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveStatus1");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _currentDepartmentName1 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CurrentDepartmentName1
		{
			[DebuggerStepThrough()]
			get { return this._currentDepartmentName1; }
			set 
			{
				if (this._currentDepartmentName1 != value) 
				{
					this._currentDepartmentName1 = value;
					this.IsDirty = true;	
					OnPropertyChanged("CurrentDepartmentName1");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _taxManName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TaxManName
		{
			[DebuggerStepThrough()]
			get { return this._taxManName; }
			set 
			{
				if (this._taxManName != value) 
				{
					this._taxManName = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaxManName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _taxNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TaxNumber
		{
			[DebuggerStepThrough()]
			get { return this._taxNumber; }
			set 
			{
				if (this._taxNumber != value) 
				{
					this._taxNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaxNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _companyInChargeMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CompanyInChargeMan
		{
			[DebuggerStepThrough()]
			get { return this._companyInChargeMan; }
			set 
			{
				if (this._companyInChargeMan != value) 
				{
					this._companyInChargeMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("CompanyInChargeMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _iDCardType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string IDCardType
		{
			[DebuggerStepThrough()]
			get { return this._iDCardType; }
			set 
			{
				if (this._iDCardType != value) 
				{
					this._iDCardType = value;
					this.IsDirty = true;	
					OnPropertyChanged("IDCardType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _iDCardNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string IDCardNumber
		{
			[DebuggerStepThrough()]
			get { return this._iDCardNumber; }
			set 
			{
				if (this._iDCardNumber != value) 
				{
					this._iDCardNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("IDCardNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _produceAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProduceAddress
		{
			[DebuggerStepThrough()]
			get { return this._produceAddress; }
			set 
			{
				if (this._produceAddress != value) 
				{
					this._produceAddress = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProduceAddress");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _companyRegiserType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CompanyRegiserType
		{
			[DebuggerStepThrough()]
			get { return this._companyRegiserType; }
			set 
			{
				if (this._companyRegiserType != value) 
				{
					this._companyRegiserType = value;
					this.IsDirty = true;	
					OnPropertyChanged("CompanyRegiserType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _businessType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BusinessType
		{
			[DebuggerStepThrough()]
			get { return this._businessType; }
			set 
			{
				if (this._businessType != value) 
				{
					this._businessType = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _operationComment = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OperationComment
		{
			[DebuggerStepThrough()]
			get { return this._operationComment; }
			set 
			{
				if (this._operationComment != value) 
				{
					this._operationComment = value;
					this.IsDirty = true;	
					OnPropertyChanged("OperationComment");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _inChargeMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string InChargeMan
		{
			[DebuggerStepThrough()]
			get { return this._inChargeMan; }
			set 
			{
				if (this._inChargeMan != value) 
				{
					this._inChargeMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("InChargeMan");
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
	[StartTime] datetime,
	[EndTime] datetime,
	[NotifyTime] datetime,
	[Operator] nvarchar(50),
	[OperationTime] datetime,
	[IDCardStatus] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime,
	[CurrentProjectName] nvarchar(200),
	[BelongCompanyName] nvarchar(200),
	[DepartmentID] int,
	[PaperNumber] nvarchar(500),
	[OutingAddress] nvarchar(500),
	[ApproveMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveStatus] int,
	[CurrentDepartmentName] nvarchar(500),
	[BelongCompanyName1] nvarchar(200),
	[DepartmentID1] int,
	[PaperNumber1] nvarchar(500),
	[OutingAddress1] nvarchar(500),
	[ApproveMan1] nvarchar(200),
	[ApproveTime1] datetime,
	[ApproveStatus1] int,
	[CurrentDepartmentName1] nvarchar(500),
	[TaxManName] nvarchar(500),
	[TaxNumber] nvarchar(500),
	[CompanyInChargeMan] nvarchar(500),
	[IDCardType] nvarchar(100),
	[IDCardNumber] nvarchar(500),
	[ProduceAddress] nvarchar(500),
	[CompanyRegiserType] nvarchar(500),
	[BusinessType] nvarchar(500),
	[OperationComment] ntext,
	[InChargeMan] nvarchar(100)
);

INSERT INTO [dbo].[Cheque_Outing] (
	[Cheque_Outing].[ProjectID],
	[Cheque_Outing].[StartTime],
	[Cheque_Outing].[EndTime],
	[Cheque_Outing].[NotifyTime],
	[Cheque_Outing].[Operator],
	[Cheque_Outing].[OperationTime],
	[Cheque_Outing].[IDCardStatus],
	[Cheque_Outing].[Remark],
	[Cheque_Outing].[AddTime],
	[Cheque_Outing].[CurrentProjectName],
	[Cheque_Outing].[BelongCompanyName],
	[Cheque_Outing].[DepartmentID],
	[Cheque_Outing].[PaperNumber],
	[Cheque_Outing].[OutingAddress],
	[Cheque_Outing].[ApproveMan],
	[Cheque_Outing].[ApproveTime],
	[Cheque_Outing].[ApproveStatus],
	[Cheque_Outing].[CurrentDepartmentName],
	[Cheque_Outing].[BelongCompanyName1],
	[Cheque_Outing].[DepartmentID1],
	[Cheque_Outing].[PaperNumber1],
	[Cheque_Outing].[OutingAddress1],
	[Cheque_Outing].[ApproveMan1],
	[Cheque_Outing].[ApproveTime1],
	[Cheque_Outing].[ApproveStatus1],
	[Cheque_Outing].[CurrentDepartmentName1],
	[Cheque_Outing].[TaxManName],
	[Cheque_Outing].[TaxNumber],
	[Cheque_Outing].[CompanyInChargeMan],
	[Cheque_Outing].[IDCardType],
	[Cheque_Outing].[IDCardNumber],
	[Cheque_Outing].[ProduceAddress],
	[Cheque_Outing].[CompanyRegiserType],
	[Cheque_Outing].[BusinessType],
	[Cheque_Outing].[OperationComment],
	[Cheque_Outing].[InChargeMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[NotifyTime],
	INSERTED.[Operator],
	INSERTED.[OperationTime],
	INSERTED.[IDCardStatus],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[CurrentProjectName],
	INSERTED.[BelongCompanyName],
	INSERTED.[DepartmentID],
	INSERTED.[PaperNumber],
	INSERTED.[OutingAddress],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveStatus],
	INSERTED.[CurrentDepartmentName],
	INSERTED.[BelongCompanyName1],
	INSERTED.[DepartmentID1],
	INSERTED.[PaperNumber1],
	INSERTED.[OutingAddress1],
	INSERTED.[ApproveMan1],
	INSERTED.[ApproveTime1],
	INSERTED.[ApproveStatus1],
	INSERTED.[CurrentDepartmentName1],
	INSERTED.[TaxManName],
	INSERTED.[TaxNumber],
	INSERTED.[CompanyInChargeMan],
	INSERTED.[IDCardType],
	INSERTED.[IDCardNumber],
	INSERTED.[ProduceAddress],
	INSERTED.[CompanyRegiserType],
	INSERTED.[BusinessType],
	INSERTED.[OperationComment],
	INSERTED.[InChargeMan]
into @table
VALUES ( 
	@ProjectID,
	@StartTime,
	@EndTime,
	@NotifyTime,
	@Operator,
	@OperationTime,
	@IDCardStatus,
	@Remark,
	@AddTime,
	@CurrentProjectName,
	@BelongCompanyName,
	@DepartmentID,
	@PaperNumber,
	@OutingAddress,
	@ApproveMan,
	@ApproveTime,
	@ApproveStatus,
	@CurrentDepartmentName,
	@BelongCompanyName1,
	@DepartmentID1,
	@PaperNumber1,
	@OutingAddress1,
	@ApproveMan1,
	@ApproveTime1,
	@ApproveStatus1,
	@CurrentDepartmentName1,
	@TaxManName,
	@TaxNumber,
	@CompanyInChargeMan,
	@IDCardType,
	@IDCardNumber,
	@ProduceAddress,
	@CompanyRegiserType,
	@BusinessType,
	@OperationComment,
	@InChargeMan 
); 

SELECT 
	[ID],
	[ProjectID],
	[StartTime],
	[EndTime],
	[NotifyTime],
	[Operator],
	[OperationTime],
	[IDCardStatus],
	[Remark],
	[AddTime],
	[CurrentProjectName],
	[BelongCompanyName],
	[DepartmentID],
	[PaperNumber],
	[OutingAddress],
	[ApproveMan],
	[ApproveTime],
	[ApproveStatus],
	[CurrentDepartmentName],
	[BelongCompanyName1],
	[DepartmentID1],
	[PaperNumber1],
	[OutingAddress1],
	[ApproveMan1],
	[ApproveTime1],
	[ApproveStatus1],
	[CurrentDepartmentName1],
	[TaxManName],
	[TaxNumber],
	[CompanyInChargeMan],
	[IDCardType],
	[IDCardNumber],
	[ProduceAddress],
	[CompanyRegiserType],
	[BusinessType],
	[OperationComment],
	[InChargeMan] 
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
	[StartTime] datetime,
	[EndTime] datetime,
	[NotifyTime] datetime,
	[Operator] nvarchar(50),
	[OperationTime] datetime,
	[IDCardStatus] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime,
	[CurrentProjectName] nvarchar(200),
	[BelongCompanyName] nvarchar(200),
	[DepartmentID] int,
	[PaperNumber] nvarchar(500),
	[OutingAddress] nvarchar(500),
	[ApproveMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveStatus] int,
	[CurrentDepartmentName] nvarchar(500),
	[BelongCompanyName1] nvarchar(200),
	[DepartmentID1] int,
	[PaperNumber1] nvarchar(500),
	[OutingAddress1] nvarchar(500),
	[ApproveMan1] nvarchar(200),
	[ApproveTime1] datetime,
	[ApproveStatus1] int,
	[CurrentDepartmentName1] nvarchar(500),
	[TaxManName] nvarchar(500),
	[TaxNumber] nvarchar(500),
	[CompanyInChargeMan] nvarchar(500),
	[IDCardType] nvarchar(100),
	[IDCardNumber] nvarchar(500),
	[ProduceAddress] nvarchar(500),
	[CompanyRegiserType] nvarchar(500),
	[BusinessType] nvarchar(500),
	[OperationComment] ntext,
	[InChargeMan] nvarchar(100)
);

UPDATE [dbo].[Cheque_Outing] SET 
	[Cheque_Outing].[ProjectID] = @ProjectID,
	[Cheque_Outing].[StartTime] = @StartTime,
	[Cheque_Outing].[EndTime] = @EndTime,
	[Cheque_Outing].[NotifyTime] = @NotifyTime,
	[Cheque_Outing].[Operator] = @Operator,
	[Cheque_Outing].[OperationTime] = @OperationTime,
	[Cheque_Outing].[IDCardStatus] = @IDCardStatus,
	[Cheque_Outing].[Remark] = @Remark,
	[Cheque_Outing].[AddTime] = @AddTime,
	[Cheque_Outing].[CurrentProjectName] = @CurrentProjectName,
	[Cheque_Outing].[BelongCompanyName] = @BelongCompanyName,
	[Cheque_Outing].[DepartmentID] = @DepartmentID,
	[Cheque_Outing].[PaperNumber] = @PaperNumber,
	[Cheque_Outing].[OutingAddress] = @OutingAddress,
	[Cheque_Outing].[ApproveMan] = @ApproveMan,
	[Cheque_Outing].[ApproveTime] = @ApproveTime,
	[Cheque_Outing].[ApproveStatus] = @ApproveStatus,
	[Cheque_Outing].[CurrentDepartmentName] = @CurrentDepartmentName,
	[Cheque_Outing].[BelongCompanyName1] = @BelongCompanyName1,
	[Cheque_Outing].[DepartmentID1] = @DepartmentID1,
	[Cheque_Outing].[PaperNumber1] = @PaperNumber1,
	[Cheque_Outing].[OutingAddress1] = @OutingAddress1,
	[Cheque_Outing].[ApproveMan1] = @ApproveMan1,
	[Cheque_Outing].[ApproveTime1] = @ApproveTime1,
	[Cheque_Outing].[ApproveStatus1] = @ApproveStatus1,
	[Cheque_Outing].[CurrentDepartmentName1] = @CurrentDepartmentName1,
	[Cheque_Outing].[TaxManName] = @TaxManName,
	[Cheque_Outing].[TaxNumber] = @TaxNumber,
	[Cheque_Outing].[CompanyInChargeMan] = @CompanyInChargeMan,
	[Cheque_Outing].[IDCardType] = @IDCardType,
	[Cheque_Outing].[IDCardNumber] = @IDCardNumber,
	[Cheque_Outing].[ProduceAddress] = @ProduceAddress,
	[Cheque_Outing].[CompanyRegiserType] = @CompanyRegiserType,
	[Cheque_Outing].[BusinessType] = @BusinessType,
	[Cheque_Outing].[OperationComment] = @OperationComment,
	[Cheque_Outing].[InChargeMan] = @InChargeMan 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[NotifyTime],
	INSERTED.[Operator],
	INSERTED.[OperationTime],
	INSERTED.[IDCardStatus],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[CurrentProjectName],
	INSERTED.[BelongCompanyName],
	INSERTED.[DepartmentID],
	INSERTED.[PaperNumber],
	INSERTED.[OutingAddress],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveStatus],
	INSERTED.[CurrentDepartmentName],
	INSERTED.[BelongCompanyName1],
	INSERTED.[DepartmentID1],
	INSERTED.[PaperNumber1],
	INSERTED.[OutingAddress1],
	INSERTED.[ApproveMan1],
	INSERTED.[ApproveTime1],
	INSERTED.[ApproveStatus1],
	INSERTED.[CurrentDepartmentName1],
	INSERTED.[TaxManName],
	INSERTED.[TaxNumber],
	INSERTED.[CompanyInChargeMan],
	INSERTED.[IDCardType],
	INSERTED.[IDCardNumber],
	INSERTED.[ProduceAddress],
	INSERTED.[CompanyRegiserType],
	INSERTED.[BusinessType],
	INSERTED.[OperationComment],
	INSERTED.[InChargeMan]
into @table
WHERE 
	[Cheque_Outing].[ID] = @ID

SELECT 
	[ID],
	[ProjectID],
	[StartTime],
	[EndTime],
	[NotifyTime],
	[Operator],
	[OperationTime],
	[IDCardStatus],
	[Remark],
	[AddTime],
	[CurrentProjectName],
	[BelongCompanyName],
	[DepartmentID],
	[PaperNumber],
	[OutingAddress],
	[ApproveMan],
	[ApproveTime],
	[ApproveStatus],
	[CurrentDepartmentName],
	[BelongCompanyName1],
	[DepartmentID1],
	[PaperNumber1],
	[OutingAddress1],
	[ApproveMan1],
	[ApproveTime1],
	[ApproveStatus1],
	[CurrentDepartmentName1],
	[TaxManName],
	[TaxNumber],
	[CompanyInChargeMan],
	[IDCardType],
	[IDCardNumber],
	[ProduceAddress],
	[CompanyRegiserType],
	[BusinessType],
	[OperationComment],
	[InChargeMan] 
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
DELETE FROM [dbo].[Cheque_Outing]
WHERE 
	[Cheque_Outing].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_Outing() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_Outing(this.ID));
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
	[Cheque_Outing].[ID],
	[Cheque_Outing].[ProjectID],
	[Cheque_Outing].[StartTime],
	[Cheque_Outing].[EndTime],
	[Cheque_Outing].[NotifyTime],
	[Cheque_Outing].[Operator],
	[Cheque_Outing].[OperationTime],
	[Cheque_Outing].[IDCardStatus],
	[Cheque_Outing].[Remark],
	[Cheque_Outing].[AddTime],
	[Cheque_Outing].[CurrentProjectName],
	[Cheque_Outing].[BelongCompanyName],
	[Cheque_Outing].[DepartmentID],
	[Cheque_Outing].[PaperNumber],
	[Cheque_Outing].[OutingAddress],
	[Cheque_Outing].[ApproveMan],
	[Cheque_Outing].[ApproveTime],
	[Cheque_Outing].[ApproveStatus],
	[Cheque_Outing].[CurrentDepartmentName],
	[Cheque_Outing].[BelongCompanyName1],
	[Cheque_Outing].[DepartmentID1],
	[Cheque_Outing].[PaperNumber1],
	[Cheque_Outing].[OutingAddress1],
	[Cheque_Outing].[ApproveMan1],
	[Cheque_Outing].[ApproveTime1],
	[Cheque_Outing].[ApproveStatus1],
	[Cheque_Outing].[CurrentDepartmentName1],
	[Cheque_Outing].[TaxManName],
	[Cheque_Outing].[TaxNumber],
	[Cheque_Outing].[CompanyInChargeMan],
	[Cheque_Outing].[IDCardType],
	[Cheque_Outing].[IDCardNumber],
	[Cheque_Outing].[ProduceAddress],
	[Cheque_Outing].[CompanyRegiserType],
	[Cheque_Outing].[BusinessType],
	[Cheque_Outing].[OperationComment],
	[Cheque_Outing].[InChargeMan]
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
                return "Cheque_Outing";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_Outing into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="notifyTime">notifyTime</param>
		/// <param name="operator">operator</param>
		/// <param name="operationTime">operationTime</param>
		/// <param name="iDCardStatus">iDCardStatus</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="currentProjectName">currentProjectName</param>
		/// <param name="belongCompanyName">belongCompanyName</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="paperNumber">paperNumber</param>
		/// <param name="outingAddress">outingAddress</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="currentDepartmentName">currentDepartmentName</param>
		/// <param name="belongCompanyName1">belongCompanyName1</param>
		/// <param name="departmentID1">departmentID1</param>
		/// <param name="paperNumber1">paperNumber1</param>
		/// <param name="outingAddress1">outingAddress1</param>
		/// <param name="approveMan1">approveMan1</param>
		/// <param name="approveTime1">approveTime1</param>
		/// <param name="approveStatus1">approveStatus1</param>
		/// <param name="currentDepartmentName1">currentDepartmentName1</param>
		/// <param name="taxManName">taxManName</param>
		/// <param name="taxNumber">taxNumber</param>
		/// <param name="companyInChargeMan">companyInChargeMan</param>
		/// <param name="iDCardType">iDCardType</param>
		/// <param name="iDCardNumber">iDCardNumber</param>
		/// <param name="produceAddress">produceAddress</param>
		/// <param name="companyRegiserType">companyRegiserType</param>
		/// <param name="businessType">businessType</param>
		/// <param name="operationComment">operationComment</param>
		/// <param name="inChargeMan">inChargeMan</param>
		public static void InsertCheque_Outing(int @projectID, DateTime @startTime, DateTime @endTime, DateTime @notifyTime, string @operator, DateTime @operationTime, string @iDCardStatus, string @remark, DateTime @addTime, string @currentProjectName, string @belongCompanyName, int @departmentID, string @paperNumber, string @outingAddress, string @approveMan, DateTime @approveTime, int @approveStatus, string @currentDepartmentName, string @belongCompanyName1, int @departmentID1, string @paperNumber1, string @outingAddress1, string @approveMan1, DateTime @approveTime1, int @approveStatus1, string @currentDepartmentName1, string @taxManName, string @taxNumber, string @companyInChargeMan, string @iDCardType, string @iDCardNumber, string @produceAddress, string @companyRegiserType, string @businessType, string @operationComment, string @inChargeMan)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_Outing(@projectID, @startTime, @endTime, @notifyTime, @operator, @operationTime, @iDCardStatus, @remark, @addTime, @currentProjectName, @belongCompanyName, @departmentID, @paperNumber, @outingAddress, @approveMan, @approveTime, @approveStatus, @currentDepartmentName, @belongCompanyName1, @departmentID1, @paperNumber1, @outingAddress1, @approveMan1, @approveTime1, @approveStatus1, @currentDepartmentName1, @taxManName, @taxNumber, @companyInChargeMan, @iDCardType, @iDCardNumber, @produceAddress, @companyRegiserType, @businessType, @operationComment, @inChargeMan, helper);
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
		/// Insert a Cheque_Outing into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="notifyTime">notifyTime</param>
		/// <param name="operator">operator</param>
		/// <param name="operationTime">operationTime</param>
		/// <param name="iDCardStatus">iDCardStatus</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="currentProjectName">currentProjectName</param>
		/// <param name="belongCompanyName">belongCompanyName</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="paperNumber">paperNumber</param>
		/// <param name="outingAddress">outingAddress</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="currentDepartmentName">currentDepartmentName</param>
		/// <param name="belongCompanyName1">belongCompanyName1</param>
		/// <param name="departmentID1">departmentID1</param>
		/// <param name="paperNumber1">paperNumber1</param>
		/// <param name="outingAddress1">outingAddress1</param>
		/// <param name="approveMan1">approveMan1</param>
		/// <param name="approveTime1">approveTime1</param>
		/// <param name="approveStatus1">approveStatus1</param>
		/// <param name="currentDepartmentName1">currentDepartmentName1</param>
		/// <param name="taxManName">taxManName</param>
		/// <param name="taxNumber">taxNumber</param>
		/// <param name="companyInChargeMan">companyInChargeMan</param>
		/// <param name="iDCardType">iDCardType</param>
		/// <param name="iDCardNumber">iDCardNumber</param>
		/// <param name="produceAddress">produceAddress</param>
		/// <param name="companyRegiserType">companyRegiserType</param>
		/// <param name="businessType">businessType</param>
		/// <param name="operationComment">operationComment</param>
		/// <param name="inChargeMan">inChargeMan</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_Outing(int @projectID, DateTime @startTime, DateTime @endTime, DateTime @notifyTime, string @operator, DateTime @operationTime, string @iDCardStatus, string @remark, DateTime @addTime, string @currentProjectName, string @belongCompanyName, int @departmentID, string @paperNumber, string @outingAddress, string @approveMan, DateTime @approveTime, int @approveStatus, string @currentDepartmentName, string @belongCompanyName1, int @departmentID1, string @paperNumber1, string @outingAddress1, string @approveMan1, DateTime @approveTime1, int @approveStatus1, string @currentDepartmentName1, string @taxManName, string @taxNumber, string @companyInChargeMan, string @iDCardType, string @iDCardNumber, string @produceAddress, string @companyRegiserType, string @businessType, string @operationComment, string @inChargeMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectID] int,
	[StartTime] datetime,
	[EndTime] datetime,
	[NotifyTime] datetime,
	[Operator] nvarchar(50),
	[OperationTime] datetime,
	[IDCardStatus] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime,
	[CurrentProjectName] nvarchar(200),
	[BelongCompanyName] nvarchar(200),
	[DepartmentID] int,
	[PaperNumber] nvarchar(500),
	[OutingAddress] nvarchar(500),
	[ApproveMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveStatus] int,
	[CurrentDepartmentName] nvarchar(500),
	[BelongCompanyName1] nvarchar(200),
	[DepartmentID1] int,
	[PaperNumber1] nvarchar(500),
	[OutingAddress1] nvarchar(500),
	[ApproveMan1] nvarchar(200),
	[ApproveTime1] datetime,
	[ApproveStatus1] int,
	[CurrentDepartmentName1] nvarchar(500),
	[TaxManName] nvarchar(500),
	[TaxNumber] nvarchar(500),
	[CompanyInChargeMan] nvarchar(500),
	[IDCardType] nvarchar(100),
	[IDCardNumber] nvarchar(500),
	[ProduceAddress] nvarchar(500),
	[CompanyRegiserType] nvarchar(500),
	[BusinessType] nvarchar(500),
	[OperationComment] ntext,
	[InChargeMan] nvarchar(100)
);

INSERT INTO [dbo].[Cheque_Outing] (
	[Cheque_Outing].[ProjectID],
	[Cheque_Outing].[StartTime],
	[Cheque_Outing].[EndTime],
	[Cheque_Outing].[NotifyTime],
	[Cheque_Outing].[Operator],
	[Cheque_Outing].[OperationTime],
	[Cheque_Outing].[IDCardStatus],
	[Cheque_Outing].[Remark],
	[Cheque_Outing].[AddTime],
	[Cheque_Outing].[CurrentProjectName],
	[Cheque_Outing].[BelongCompanyName],
	[Cheque_Outing].[DepartmentID],
	[Cheque_Outing].[PaperNumber],
	[Cheque_Outing].[OutingAddress],
	[Cheque_Outing].[ApproveMan],
	[Cheque_Outing].[ApproveTime],
	[Cheque_Outing].[ApproveStatus],
	[Cheque_Outing].[CurrentDepartmentName],
	[Cheque_Outing].[BelongCompanyName1],
	[Cheque_Outing].[DepartmentID1],
	[Cheque_Outing].[PaperNumber1],
	[Cheque_Outing].[OutingAddress1],
	[Cheque_Outing].[ApproveMan1],
	[Cheque_Outing].[ApproveTime1],
	[Cheque_Outing].[ApproveStatus1],
	[Cheque_Outing].[CurrentDepartmentName1],
	[Cheque_Outing].[TaxManName],
	[Cheque_Outing].[TaxNumber],
	[Cheque_Outing].[CompanyInChargeMan],
	[Cheque_Outing].[IDCardType],
	[Cheque_Outing].[IDCardNumber],
	[Cheque_Outing].[ProduceAddress],
	[Cheque_Outing].[CompanyRegiserType],
	[Cheque_Outing].[BusinessType],
	[Cheque_Outing].[OperationComment],
	[Cheque_Outing].[InChargeMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[NotifyTime],
	INSERTED.[Operator],
	INSERTED.[OperationTime],
	INSERTED.[IDCardStatus],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[CurrentProjectName],
	INSERTED.[BelongCompanyName],
	INSERTED.[DepartmentID],
	INSERTED.[PaperNumber],
	INSERTED.[OutingAddress],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveStatus],
	INSERTED.[CurrentDepartmentName],
	INSERTED.[BelongCompanyName1],
	INSERTED.[DepartmentID1],
	INSERTED.[PaperNumber1],
	INSERTED.[OutingAddress1],
	INSERTED.[ApproveMan1],
	INSERTED.[ApproveTime1],
	INSERTED.[ApproveStatus1],
	INSERTED.[CurrentDepartmentName1],
	INSERTED.[TaxManName],
	INSERTED.[TaxNumber],
	INSERTED.[CompanyInChargeMan],
	INSERTED.[IDCardType],
	INSERTED.[IDCardNumber],
	INSERTED.[ProduceAddress],
	INSERTED.[CompanyRegiserType],
	INSERTED.[BusinessType],
	INSERTED.[OperationComment],
	INSERTED.[InChargeMan]
into @table
VALUES ( 
	@ProjectID,
	@StartTime,
	@EndTime,
	@NotifyTime,
	@Operator,
	@OperationTime,
	@IDCardStatus,
	@Remark,
	@AddTime,
	@CurrentProjectName,
	@BelongCompanyName,
	@DepartmentID,
	@PaperNumber,
	@OutingAddress,
	@ApproveMan,
	@ApproveTime,
	@ApproveStatus,
	@CurrentDepartmentName,
	@BelongCompanyName1,
	@DepartmentID1,
	@PaperNumber1,
	@OutingAddress1,
	@ApproveMan1,
	@ApproveTime1,
	@ApproveStatus1,
	@CurrentDepartmentName1,
	@TaxManName,
	@TaxNumber,
	@CompanyInChargeMan,
	@IDCardType,
	@IDCardNumber,
	@ProduceAddress,
	@CompanyRegiserType,
	@BusinessType,
	@OperationComment,
	@InChargeMan 
); 

SELECT 
	[ID],
	[ProjectID],
	[StartTime],
	[EndTime],
	[NotifyTime],
	[Operator],
	[OperationTime],
	[IDCardStatus],
	[Remark],
	[AddTime],
	[CurrentProjectName],
	[BelongCompanyName],
	[DepartmentID],
	[PaperNumber],
	[OutingAddress],
	[ApproveMan],
	[ApproveTime],
	[ApproveStatus],
	[CurrentDepartmentName],
	[BelongCompanyName1],
	[DepartmentID1],
	[PaperNumber1],
	[OutingAddress1],
	[ApproveMan1],
	[ApproveTime1],
	[ApproveStatus1],
	[CurrentDepartmentName1],
	[TaxManName],
	[TaxNumber],
	[CompanyInChargeMan],
	[IDCardType],
	[IDCardNumber],
	[ProduceAddress],
	[CompanyRegiserType],
	[BusinessType],
	[OperationComment],
	[InChargeMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@NotifyTime", EntityBase.GetDatabaseValue(@notifyTime)));
			parameters.Add(new SqlParameter("@Operator", EntityBase.GetDatabaseValue(@operator)));
			parameters.Add(new SqlParameter("@OperationTime", EntityBase.GetDatabaseValue(@operationTime)));
			parameters.Add(new SqlParameter("@IDCardStatus", EntityBase.GetDatabaseValue(@iDCardStatus)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@CurrentProjectName", EntityBase.GetDatabaseValue(@currentProjectName)));
			parameters.Add(new SqlParameter("@BelongCompanyName", EntityBase.GetDatabaseValue(@belongCompanyName)));
			parameters.Add(new SqlParameter("@DepartmentID", EntityBase.GetDatabaseValue(@departmentID)));
			parameters.Add(new SqlParameter("@PaperNumber", EntityBase.GetDatabaseValue(@paperNumber)));
			parameters.Add(new SqlParameter("@OutingAddress", EntityBase.GetDatabaseValue(@outingAddress)));
			parameters.Add(new SqlParameter("@ApproveMan", EntityBase.GetDatabaseValue(@approveMan)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveStatus", EntityBase.GetDatabaseValue(@approveStatus)));
			parameters.Add(new SqlParameter("@CurrentDepartmentName", EntityBase.GetDatabaseValue(@currentDepartmentName)));
			parameters.Add(new SqlParameter("@BelongCompanyName1", EntityBase.GetDatabaseValue(@belongCompanyName1)));
			parameters.Add(new SqlParameter("@DepartmentID1", EntityBase.GetDatabaseValue(@departmentID1)));
			parameters.Add(new SqlParameter("@PaperNumber1", EntityBase.GetDatabaseValue(@paperNumber1)));
			parameters.Add(new SqlParameter("@OutingAddress1", EntityBase.GetDatabaseValue(@outingAddress1)));
			parameters.Add(new SqlParameter("@ApproveMan1", EntityBase.GetDatabaseValue(@approveMan1)));
			parameters.Add(new SqlParameter("@ApproveTime1", EntityBase.GetDatabaseValue(@approveTime1)));
			parameters.Add(new SqlParameter("@ApproveStatus1", EntityBase.GetDatabaseValue(@approveStatus1)));
			parameters.Add(new SqlParameter("@CurrentDepartmentName1", EntityBase.GetDatabaseValue(@currentDepartmentName1)));
			parameters.Add(new SqlParameter("@TaxManName", EntityBase.GetDatabaseValue(@taxManName)));
			parameters.Add(new SqlParameter("@TaxNumber", EntityBase.GetDatabaseValue(@taxNumber)));
			parameters.Add(new SqlParameter("@CompanyInChargeMan", EntityBase.GetDatabaseValue(@companyInChargeMan)));
			parameters.Add(new SqlParameter("@IDCardType", EntityBase.GetDatabaseValue(@iDCardType)));
			parameters.Add(new SqlParameter("@IDCardNumber", EntityBase.GetDatabaseValue(@iDCardNumber)));
			parameters.Add(new SqlParameter("@ProduceAddress", EntityBase.GetDatabaseValue(@produceAddress)));
			parameters.Add(new SqlParameter("@CompanyRegiserType", EntityBase.GetDatabaseValue(@companyRegiserType)));
			parameters.Add(new SqlParameter("@BusinessType", EntityBase.GetDatabaseValue(@businessType)));
			parameters.Add(new SqlParameter("@OperationComment", EntityBase.GetDatabaseValue(@operationComment)));
			parameters.Add(new SqlParameter("@InChargeMan", EntityBase.GetDatabaseValue(@inChargeMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_Outing into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectID">projectID</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="notifyTime">notifyTime</param>
		/// <param name="operator">operator</param>
		/// <param name="operationTime">operationTime</param>
		/// <param name="iDCardStatus">iDCardStatus</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="currentProjectName">currentProjectName</param>
		/// <param name="belongCompanyName">belongCompanyName</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="paperNumber">paperNumber</param>
		/// <param name="outingAddress">outingAddress</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="currentDepartmentName">currentDepartmentName</param>
		/// <param name="belongCompanyName1">belongCompanyName1</param>
		/// <param name="departmentID1">departmentID1</param>
		/// <param name="paperNumber1">paperNumber1</param>
		/// <param name="outingAddress1">outingAddress1</param>
		/// <param name="approveMan1">approveMan1</param>
		/// <param name="approveTime1">approveTime1</param>
		/// <param name="approveStatus1">approveStatus1</param>
		/// <param name="currentDepartmentName1">currentDepartmentName1</param>
		/// <param name="taxManName">taxManName</param>
		/// <param name="taxNumber">taxNumber</param>
		/// <param name="companyInChargeMan">companyInChargeMan</param>
		/// <param name="iDCardType">iDCardType</param>
		/// <param name="iDCardNumber">iDCardNumber</param>
		/// <param name="produceAddress">produceAddress</param>
		/// <param name="companyRegiserType">companyRegiserType</param>
		/// <param name="businessType">businessType</param>
		/// <param name="operationComment">operationComment</param>
		/// <param name="inChargeMan">inChargeMan</param>
		public static void UpdateCheque_Outing(int @iD, int @projectID, DateTime @startTime, DateTime @endTime, DateTime @notifyTime, string @operator, DateTime @operationTime, string @iDCardStatus, string @remark, DateTime @addTime, string @currentProjectName, string @belongCompanyName, int @departmentID, string @paperNumber, string @outingAddress, string @approveMan, DateTime @approveTime, int @approveStatus, string @currentDepartmentName, string @belongCompanyName1, int @departmentID1, string @paperNumber1, string @outingAddress1, string @approveMan1, DateTime @approveTime1, int @approveStatus1, string @currentDepartmentName1, string @taxManName, string @taxNumber, string @companyInChargeMan, string @iDCardType, string @iDCardNumber, string @produceAddress, string @companyRegiserType, string @businessType, string @operationComment, string @inChargeMan)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_Outing(@iD, @projectID, @startTime, @endTime, @notifyTime, @operator, @operationTime, @iDCardStatus, @remark, @addTime, @currentProjectName, @belongCompanyName, @departmentID, @paperNumber, @outingAddress, @approveMan, @approveTime, @approveStatus, @currentDepartmentName, @belongCompanyName1, @departmentID1, @paperNumber1, @outingAddress1, @approveMan1, @approveTime1, @approveStatus1, @currentDepartmentName1, @taxManName, @taxNumber, @companyInChargeMan, @iDCardType, @iDCardNumber, @produceAddress, @companyRegiserType, @businessType, @operationComment, @inChargeMan, helper);
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
		/// Updates a Cheque_Outing into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectID">projectID</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="notifyTime">notifyTime</param>
		/// <param name="operator">operator</param>
		/// <param name="operationTime">operationTime</param>
		/// <param name="iDCardStatus">iDCardStatus</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="currentProjectName">currentProjectName</param>
		/// <param name="belongCompanyName">belongCompanyName</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="paperNumber">paperNumber</param>
		/// <param name="outingAddress">outingAddress</param>
		/// <param name="approveMan">approveMan</param>
		/// <param name="approveTime">approveTime</param>
		/// <param name="approveStatus">approveStatus</param>
		/// <param name="currentDepartmentName">currentDepartmentName</param>
		/// <param name="belongCompanyName1">belongCompanyName1</param>
		/// <param name="departmentID1">departmentID1</param>
		/// <param name="paperNumber1">paperNumber1</param>
		/// <param name="outingAddress1">outingAddress1</param>
		/// <param name="approveMan1">approveMan1</param>
		/// <param name="approveTime1">approveTime1</param>
		/// <param name="approveStatus1">approveStatus1</param>
		/// <param name="currentDepartmentName1">currentDepartmentName1</param>
		/// <param name="taxManName">taxManName</param>
		/// <param name="taxNumber">taxNumber</param>
		/// <param name="companyInChargeMan">companyInChargeMan</param>
		/// <param name="iDCardType">iDCardType</param>
		/// <param name="iDCardNumber">iDCardNumber</param>
		/// <param name="produceAddress">produceAddress</param>
		/// <param name="companyRegiserType">companyRegiserType</param>
		/// <param name="businessType">businessType</param>
		/// <param name="operationComment">operationComment</param>
		/// <param name="inChargeMan">inChargeMan</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_Outing(int @iD, int @projectID, DateTime @startTime, DateTime @endTime, DateTime @notifyTime, string @operator, DateTime @operationTime, string @iDCardStatus, string @remark, DateTime @addTime, string @currentProjectName, string @belongCompanyName, int @departmentID, string @paperNumber, string @outingAddress, string @approveMan, DateTime @approveTime, int @approveStatus, string @currentDepartmentName, string @belongCompanyName1, int @departmentID1, string @paperNumber1, string @outingAddress1, string @approveMan1, DateTime @approveTime1, int @approveStatus1, string @currentDepartmentName1, string @taxManName, string @taxNumber, string @companyInChargeMan, string @iDCardType, string @iDCardNumber, string @produceAddress, string @companyRegiserType, string @businessType, string @operationComment, string @inChargeMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectID] int,
	[StartTime] datetime,
	[EndTime] datetime,
	[NotifyTime] datetime,
	[Operator] nvarchar(50),
	[OperationTime] datetime,
	[IDCardStatus] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime,
	[CurrentProjectName] nvarchar(200),
	[BelongCompanyName] nvarchar(200),
	[DepartmentID] int,
	[PaperNumber] nvarchar(500),
	[OutingAddress] nvarchar(500),
	[ApproveMan] nvarchar(200),
	[ApproveTime] datetime,
	[ApproveStatus] int,
	[CurrentDepartmentName] nvarchar(500),
	[BelongCompanyName1] nvarchar(200),
	[DepartmentID1] int,
	[PaperNumber1] nvarchar(500),
	[OutingAddress1] nvarchar(500),
	[ApproveMan1] nvarchar(200),
	[ApproveTime1] datetime,
	[ApproveStatus1] int,
	[CurrentDepartmentName1] nvarchar(500),
	[TaxManName] nvarchar(500),
	[TaxNumber] nvarchar(500),
	[CompanyInChargeMan] nvarchar(500),
	[IDCardType] nvarchar(100),
	[IDCardNumber] nvarchar(500),
	[ProduceAddress] nvarchar(500),
	[CompanyRegiserType] nvarchar(500),
	[BusinessType] nvarchar(500),
	[OperationComment] ntext,
	[InChargeMan] nvarchar(100)
);

UPDATE [dbo].[Cheque_Outing] SET 
	[Cheque_Outing].[ProjectID] = @ProjectID,
	[Cheque_Outing].[StartTime] = @StartTime,
	[Cheque_Outing].[EndTime] = @EndTime,
	[Cheque_Outing].[NotifyTime] = @NotifyTime,
	[Cheque_Outing].[Operator] = @Operator,
	[Cheque_Outing].[OperationTime] = @OperationTime,
	[Cheque_Outing].[IDCardStatus] = @IDCardStatus,
	[Cheque_Outing].[Remark] = @Remark,
	[Cheque_Outing].[AddTime] = @AddTime,
	[Cheque_Outing].[CurrentProjectName] = @CurrentProjectName,
	[Cheque_Outing].[BelongCompanyName] = @BelongCompanyName,
	[Cheque_Outing].[DepartmentID] = @DepartmentID,
	[Cheque_Outing].[PaperNumber] = @PaperNumber,
	[Cheque_Outing].[OutingAddress] = @OutingAddress,
	[Cheque_Outing].[ApproveMan] = @ApproveMan,
	[Cheque_Outing].[ApproveTime] = @ApproveTime,
	[Cheque_Outing].[ApproveStatus] = @ApproveStatus,
	[Cheque_Outing].[CurrentDepartmentName] = @CurrentDepartmentName,
	[Cheque_Outing].[BelongCompanyName1] = @BelongCompanyName1,
	[Cheque_Outing].[DepartmentID1] = @DepartmentID1,
	[Cheque_Outing].[PaperNumber1] = @PaperNumber1,
	[Cheque_Outing].[OutingAddress1] = @OutingAddress1,
	[Cheque_Outing].[ApproveMan1] = @ApproveMan1,
	[Cheque_Outing].[ApproveTime1] = @ApproveTime1,
	[Cheque_Outing].[ApproveStatus1] = @ApproveStatus1,
	[Cheque_Outing].[CurrentDepartmentName1] = @CurrentDepartmentName1,
	[Cheque_Outing].[TaxManName] = @TaxManName,
	[Cheque_Outing].[TaxNumber] = @TaxNumber,
	[Cheque_Outing].[CompanyInChargeMan] = @CompanyInChargeMan,
	[Cheque_Outing].[IDCardType] = @IDCardType,
	[Cheque_Outing].[IDCardNumber] = @IDCardNumber,
	[Cheque_Outing].[ProduceAddress] = @ProduceAddress,
	[Cheque_Outing].[CompanyRegiserType] = @CompanyRegiserType,
	[Cheque_Outing].[BusinessType] = @BusinessType,
	[Cheque_Outing].[OperationComment] = @OperationComment,
	[Cheque_Outing].[InChargeMan] = @InChargeMan 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[NotifyTime],
	INSERTED.[Operator],
	INSERTED.[OperationTime],
	INSERTED.[IDCardStatus],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[CurrentProjectName],
	INSERTED.[BelongCompanyName],
	INSERTED.[DepartmentID],
	INSERTED.[PaperNumber],
	INSERTED.[OutingAddress],
	INSERTED.[ApproveMan],
	INSERTED.[ApproveTime],
	INSERTED.[ApproveStatus],
	INSERTED.[CurrentDepartmentName],
	INSERTED.[BelongCompanyName1],
	INSERTED.[DepartmentID1],
	INSERTED.[PaperNumber1],
	INSERTED.[OutingAddress1],
	INSERTED.[ApproveMan1],
	INSERTED.[ApproveTime1],
	INSERTED.[ApproveStatus1],
	INSERTED.[CurrentDepartmentName1],
	INSERTED.[TaxManName],
	INSERTED.[TaxNumber],
	INSERTED.[CompanyInChargeMan],
	INSERTED.[IDCardType],
	INSERTED.[IDCardNumber],
	INSERTED.[ProduceAddress],
	INSERTED.[CompanyRegiserType],
	INSERTED.[BusinessType],
	INSERTED.[OperationComment],
	INSERTED.[InChargeMan]
into @table
WHERE 
	[Cheque_Outing].[ID] = @ID

SELECT 
	[ID],
	[ProjectID],
	[StartTime],
	[EndTime],
	[NotifyTime],
	[Operator],
	[OperationTime],
	[IDCardStatus],
	[Remark],
	[AddTime],
	[CurrentProjectName],
	[BelongCompanyName],
	[DepartmentID],
	[PaperNumber],
	[OutingAddress],
	[ApproveMan],
	[ApproveTime],
	[ApproveStatus],
	[CurrentDepartmentName],
	[BelongCompanyName1],
	[DepartmentID1],
	[PaperNumber1],
	[OutingAddress1],
	[ApproveMan1],
	[ApproveTime1],
	[ApproveStatus1],
	[CurrentDepartmentName1],
	[TaxManName],
	[TaxNumber],
	[CompanyInChargeMan],
	[IDCardType],
	[IDCardNumber],
	[ProduceAddress],
	[CompanyRegiserType],
	[BusinessType],
	[OperationComment],
	[InChargeMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@NotifyTime", EntityBase.GetDatabaseValue(@notifyTime)));
			parameters.Add(new SqlParameter("@Operator", EntityBase.GetDatabaseValue(@operator)));
			parameters.Add(new SqlParameter("@OperationTime", EntityBase.GetDatabaseValue(@operationTime)));
			parameters.Add(new SqlParameter("@IDCardStatus", EntityBase.GetDatabaseValue(@iDCardStatus)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@CurrentProjectName", EntityBase.GetDatabaseValue(@currentProjectName)));
			parameters.Add(new SqlParameter("@BelongCompanyName", EntityBase.GetDatabaseValue(@belongCompanyName)));
			parameters.Add(new SqlParameter("@DepartmentID", EntityBase.GetDatabaseValue(@departmentID)));
			parameters.Add(new SqlParameter("@PaperNumber", EntityBase.GetDatabaseValue(@paperNumber)));
			parameters.Add(new SqlParameter("@OutingAddress", EntityBase.GetDatabaseValue(@outingAddress)));
			parameters.Add(new SqlParameter("@ApproveMan", EntityBase.GetDatabaseValue(@approveMan)));
			parameters.Add(new SqlParameter("@ApproveTime", EntityBase.GetDatabaseValue(@approveTime)));
			parameters.Add(new SqlParameter("@ApproveStatus", EntityBase.GetDatabaseValue(@approveStatus)));
			parameters.Add(new SqlParameter("@CurrentDepartmentName", EntityBase.GetDatabaseValue(@currentDepartmentName)));
			parameters.Add(new SqlParameter("@BelongCompanyName1", EntityBase.GetDatabaseValue(@belongCompanyName1)));
			parameters.Add(new SqlParameter("@DepartmentID1", EntityBase.GetDatabaseValue(@departmentID1)));
			parameters.Add(new SqlParameter("@PaperNumber1", EntityBase.GetDatabaseValue(@paperNumber1)));
			parameters.Add(new SqlParameter("@OutingAddress1", EntityBase.GetDatabaseValue(@outingAddress1)));
			parameters.Add(new SqlParameter("@ApproveMan1", EntityBase.GetDatabaseValue(@approveMan1)));
			parameters.Add(new SqlParameter("@ApproveTime1", EntityBase.GetDatabaseValue(@approveTime1)));
			parameters.Add(new SqlParameter("@ApproveStatus1", EntityBase.GetDatabaseValue(@approveStatus1)));
			parameters.Add(new SqlParameter("@CurrentDepartmentName1", EntityBase.GetDatabaseValue(@currentDepartmentName1)));
			parameters.Add(new SqlParameter("@TaxManName", EntityBase.GetDatabaseValue(@taxManName)));
			parameters.Add(new SqlParameter("@TaxNumber", EntityBase.GetDatabaseValue(@taxNumber)));
			parameters.Add(new SqlParameter("@CompanyInChargeMan", EntityBase.GetDatabaseValue(@companyInChargeMan)));
			parameters.Add(new SqlParameter("@IDCardType", EntityBase.GetDatabaseValue(@iDCardType)));
			parameters.Add(new SqlParameter("@IDCardNumber", EntityBase.GetDatabaseValue(@iDCardNumber)));
			parameters.Add(new SqlParameter("@ProduceAddress", EntityBase.GetDatabaseValue(@produceAddress)));
			parameters.Add(new SqlParameter("@CompanyRegiserType", EntityBase.GetDatabaseValue(@companyRegiserType)));
			parameters.Add(new SqlParameter("@BusinessType", EntityBase.GetDatabaseValue(@businessType)));
			parameters.Add(new SqlParameter("@OperationComment", EntityBase.GetDatabaseValue(@operationComment)));
			parameters.Add(new SqlParameter("@InChargeMan", EntityBase.GetDatabaseValue(@inChargeMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_Outing from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_Outing(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_Outing(@iD, helper);
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
		/// Deletes a Cheque_Outing from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_Outing(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_Outing]
WHERE 
	[Cheque_Outing].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_Outing object.
		/// </summary>
		/// <returns>The newly created Cheque_Outing object.</returns>
		public static Cheque_Outing CreateCheque_Outing()
		{
			return InitializeNew<Cheque_Outing>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_Outing by a Cheque_Outing's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_Outing</returns>
		public static Cheque_Outing GetCheque_Outing(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_Outing.SelectFieldList + @"
FROM [dbo].[Cheque_Outing] 
WHERE 
	[Cheque_Outing].[ID] = @ID " + Cheque_Outing.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_Outing>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_Outing by a Cheque_Outing's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_Outing</returns>
		public static Cheque_Outing GetCheque_Outing(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_Outing.SelectFieldList + @"
FROM [dbo].[Cheque_Outing] 
WHERE 
	[Cheque_Outing].[ID] = @ID " + Cheque_Outing.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_Outing>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Outing objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_Outing objects.</returns>
		public static EntityList<Cheque_Outing> GetCheque_Outings()
		{
			string commandText = @"
SELECT " + Cheque_Outing.SelectFieldList + "FROM [dbo].[Cheque_Outing] " + Cheque_Outing.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_Outing>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_Outing objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_Outing objects.</returns>
        public static EntityList<Cheque_Outing> GetCheque_Outings(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Outing>(SelectFieldList, "FROM [dbo].[Cheque_Outing]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_Outing objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_Outing objects.</returns>
        public static EntityList<Cheque_Outing> GetCheque_Outings(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Outing>(SelectFieldList, "FROM [dbo].[Cheque_Outing]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_Outing objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_Outing objects.</returns>
		protected static EntityList<Cheque_Outing> GetCheque_Outings(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Outings(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Outing objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Outing objects.</returns>
		protected static EntityList<Cheque_Outing> GetCheque_Outings(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Outings(string.Empty, where, parameters, Cheque_Outing.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Outing objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Outing objects.</returns>
		protected static EntityList<Cheque_Outing> GetCheque_Outings(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Outings(prefix, where, parameters, Cheque_Outing.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Outing objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Outing objects.</returns>
		protected static EntityList<Cheque_Outing> GetCheque_Outings(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_Outings(string.Empty, where, parameters, Cheque_Outing.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Outing objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Outing objects.</returns>
		protected static EntityList<Cheque_Outing> GetCheque_Outings(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_Outings(prefix, where, parameters, Cheque_Outing.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Outing objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_Outing objects.</returns>
		protected static EntityList<Cheque_Outing> GetCheque_Outings(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_Outing.SelectFieldList + "FROM [dbo].[Cheque_Outing] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_Outing>(reader);
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
        protected static EntityList<Cheque_Outing> GetCheque_Outings(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Outing>(SelectFieldList, "FROM [dbo].[Cheque_Outing] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_Outing objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_OutingCount()
        {
            return GetCheque_OutingCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_Outing objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_OutingCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_Outing] " + where;

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
		public static partial class Cheque_Outing_Properties
		{
			public const string ID = "ID";
			public const string ProjectID = "ProjectID";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string NotifyTime = "NotifyTime";
			public const string Operator = "Operator";
			public const string OperationTime = "OperationTime";
			public const string IDCardStatus = "IDCardStatus";
			public const string Remark = "Remark";
			public const string AddTime = "AddTime";
			public const string CurrentProjectName = "CurrentProjectName";
			public const string BelongCompanyName = "BelongCompanyName";
			public const string DepartmentID = "DepartmentID";
			public const string PaperNumber = "PaperNumber";
			public const string OutingAddress = "OutingAddress";
			public const string ApproveMan = "ApproveMan";
			public const string ApproveTime = "ApproveTime";
			public const string ApproveStatus = "ApproveStatus";
			public const string CurrentDepartmentName = "CurrentDepartmentName";
			public const string BelongCompanyName1 = "BelongCompanyName1";
			public const string DepartmentID1 = "DepartmentID1";
			public const string PaperNumber1 = "PaperNumber1";
			public const string OutingAddress1 = "OutingAddress1";
			public const string ApproveMan1 = "ApproveMan1";
			public const string ApproveTime1 = "ApproveTime1";
			public const string ApproveStatus1 = "ApproveStatus1";
			public const string CurrentDepartmentName1 = "CurrentDepartmentName1";
			public const string TaxManName = "TaxManName";
			public const string TaxNumber = "TaxNumber";
			public const string CompanyInChargeMan = "CompanyInChargeMan";
			public const string IDCardType = "IDCardType";
			public const string IDCardNumber = "IDCardNumber";
			public const string ProduceAddress = "ProduceAddress";
			public const string CompanyRegiserType = "CompanyRegiserType";
			public const string BusinessType = "BusinessType";
			public const string OperationComment = "OperationComment";
			public const string InChargeMan = "InChargeMan";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProjectID" , "int:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"NotifyTime" , "DateTime:"},
    			 {"Operator" , "string:"},
    			 {"OperationTime" , "DateTime:"},
    			 {"IDCardStatus" , "string:"},
    			 {"Remark" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"CurrentProjectName" , "string:"},
    			 {"BelongCompanyName" , "string:"},
    			 {"DepartmentID" , "int:"},
    			 {"PaperNumber" , "string:"},
    			 {"OutingAddress" , "string:"},
    			 {"ApproveMan" , "string:"},
    			 {"ApproveTime" , "DateTime:"},
    			 {"ApproveStatus" , "int:"},
    			 {"CurrentDepartmentName" , "string:"},
    			 {"BelongCompanyName1" , "string:"},
    			 {"DepartmentID1" , "int:"},
    			 {"PaperNumber1" , "string:"},
    			 {"OutingAddress1" , "string:"},
    			 {"ApproveMan1" , "string:"},
    			 {"ApproveTime1" , "DateTime:"},
    			 {"ApproveStatus1" , "int:"},
    			 {"CurrentDepartmentName1" , "string:"},
    			 {"TaxManName" , "string:"},
    			 {"TaxNumber" , "string:"},
    			 {"CompanyInChargeMan" , "string:"},
    			 {"IDCardType" , "string:"},
    			 {"IDCardNumber" , "string:"},
    			 {"ProduceAddress" , "string:"},
    			 {"CompanyRegiserType" , "string:"},
    			 {"BusinessType" , "string:"},
    			 {"OperationComment" , "string:"},
    			 {"InChargeMan" , "string:"},
            };
		}
		#endregion
	}
}
