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
	/// This object represents the properties and methods of a Cheque_OutSummary.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_OutSummary 
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
		private DateTime _writeDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private string _writeMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string WriteMan
		{
			[DebuggerStepThrough()]
			get { return this._writeMan; }
			set 
			{
				if (this._writeMan != value) 
				{
					this._writeMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("WriteMan");
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
		private string _departmentFile = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DepartmentFile
		{
			[DebuggerStepThrough()]
			get { return this._departmentFile; }
			set 
			{
				if (this._departmentFile != value) 
				{
					this._departmentFile = value;
					this.IsDirty = true;	
					OnPropertyChanged("DepartmentFile");
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
		private int _sellerID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SellerID
		{
			[DebuggerStepThrough()]
			get { return this._sellerID; }
			set 
			{
				if (this._sellerID != value) 
				{
					this._sellerID = value;
					this.IsDirty = true;	
					OnPropertyChanged("SellerID");
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
		private int _signState = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SignState
		{
			[DebuggerStepThrough()]
			get { return this._signState; }
			set 
			{
				if (this._signState != value) 
				{
					this._signState = value;
					this.IsDirty = true;	
					OnPropertyChanged("SignState");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _signOperator = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SignOperator
		{
			[DebuggerStepThrough()]
			get { return this._signOperator; }
			set 
			{
				if (this._signOperator != value) 
				{
					this._signOperator = value;
					this.IsDirty = true;	
					OnPropertyChanged("SignOperator");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _signRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SignRemark
		{
			[DebuggerStepThrough()]
			get { return this._signRemark; }
			set 
			{
				if (this._signRemark != value) 
				{
					this._signRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("SignRemark");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _signTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime SignTime
		{
			[DebuggerStepThrough()]
			get { return this._signTime; }
			set 
			{
				if (this._signTime != value) 
				{
					this._signTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("SignTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _approveState = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ApproveState
		{
			[DebuggerStepThrough()]
			get { return this._approveState; }
			set 
			{
				if (this._approveState != value) 
				{
					this._approveState = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveState");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveOperator = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveOperator
		{
			[DebuggerStepThrough()]
			get { return this._approveOperator; }
			set 
			{
				if (this._approveOperator != value) 
				{
					this._approveOperator = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveOperator");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveRemark
		{
			[DebuggerStepThrough()]
			get { return this._approveRemark; }
			set 
			{
				if (this._approveRemark != value) 
				{
					this._approveRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApproveRemark");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _apporveTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ApporveTime
		{
			[DebuggerStepThrough()]
			get { return this._apporveTime; }
			set 
			{
				if (this._apporveTime != value) 
				{
					this._apporveTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ApporveTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chequeNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChequeNumber
		{
			[DebuggerStepThrough()]
			get { return this._chequeNumber; }
			set 
			{
				if (this._chequeNumber != value) 
				{
					this._chequeNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChequeNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _chequeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ChequeTime
		{
			[DebuggerStepThrough()]
			get { return this._chequeTime; }
			set 
			{
				if (this._chequeTime != value) 
				{
					this._chequeTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChequeTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _buyerID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int BuyerID
		{
			[DebuggerStepThrough()]
			get { return this._buyerID; }
			set 
			{
				if (this._buyerID != value) 
				{
					this._buyerID = value;
					this.IsDirty = true;	
					OnPropertyChanged("BuyerID");
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
		private string _currentSellerName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CurrentSellerName
		{
			[DebuggerStepThrough()]
			get { return this._currentSellerName; }
			set 
			{
				if (this._currentSellerName != value) 
				{
					this._currentSellerName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CurrentSellerName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _currentSellerTaxNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CurrentSellerTaxNumber
		{
			[DebuggerStepThrough()]
			get { return this._currentSellerTaxNumber; }
			set 
			{
				if (this._currentSellerTaxNumber != value) 
				{
					this._currentSellerTaxNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("CurrentSellerTaxNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _currentSellerAddressPhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CurrentSellerAddressPhone
		{
			[DebuggerStepThrough()]
			get { return this._currentSellerAddressPhone; }
			set 
			{
				if (this._currentSellerAddressPhone != value) 
				{
					this._currentSellerAddressPhone = value;
					this.IsDirty = true;	
					OnPropertyChanged("CurrentSellerAddressPhone");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _currentSellerBankAccount = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CurrentSellerBankAccount
		{
			[DebuggerStepThrough()]
			get { return this._currentSellerBankAccount; }
			set 
			{
				if (this._currentSellerBankAccount != value) 
				{
					this._currentSellerBankAccount = value;
					this.IsDirty = true;	
					OnPropertyChanged("CurrentSellerBankAccount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _currentBuyerName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CurrentBuyerName
		{
			[DebuggerStepThrough()]
			get { return this._currentBuyerName; }
			set 
			{
				if (this._currentBuyerName != value) 
				{
					this._currentBuyerName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CurrentBuyerName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _currentBuyerTaxNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CurrentBuyerTaxNumber
		{
			[DebuggerStepThrough()]
			get { return this._currentBuyerTaxNumber; }
			set 
			{
				if (this._currentBuyerTaxNumber != value) 
				{
					this._currentBuyerTaxNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("CurrentBuyerTaxNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _currentBuyerAddressPhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CurrentBuyerAddressPhone
		{
			[DebuggerStepThrough()]
			get { return this._currentBuyerAddressPhone; }
			set 
			{
				if (this._currentBuyerAddressPhone != value) 
				{
					this._currentBuyerAddressPhone = value;
					this.IsDirty = true;	
					OnPropertyChanged("CurrentBuyerAddressPhone");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _currentBuyerBankAccount = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CurrentBuyerBankAccount
		{
			[DebuggerStepThrough()]
			get { return this._currentBuyerBankAccount; }
			set 
			{
				if (this._currentBuyerBankAccount != value) 
				{
					this._currentBuyerBankAccount = value;
					this.IsDirty = true;	
					OnPropertyChanged("CurrentBuyerBankAccount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chequeCode = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChequeCode
		{
			[DebuggerStepThrough()]
			get { return this._chequeCode; }
			set 
			{
				if (this._chequeCode != value) 
				{
					this._chequeCode = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChequeCode");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chequeCategory = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChequeCategory
		{
			[DebuggerStepThrough()]
			get { return this._chequeCategory; }
			set 
			{
				if (this._chequeCategory != value) 
				{
					this._chequeCategory = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChequeCategory");
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
	[WriteDate] datetime,
	[WriteMan] nvarchar(50),
	[DepartmentID] int,
	[DepartmentFile] nvarchar(200),
	[ProjectID] int,
	[SellerID] int,
	[AddTime] datetime,
	[Remark] ntext,
	[SignState] int,
	[SignOperator] nvarchar(50),
	[SignRemark] ntext,
	[SignTime] datetime,
	[ApproveState] int,
	[ApproveOperator] nvarchar(50),
	[ApproveRemark] ntext,
	[ApporveTime] datetime,
	[ChequeNumber] nvarchar(50),
	[ChequeTime] datetime,
	[BuyerID] int,
	[CurrentDepartmentName] nvarchar(200),
	[CurrentProjectName] nvarchar(200),
	[CurrentSellerName] nvarchar(200),
	[CurrentSellerTaxNumber] nvarchar(200),
	[CurrentSellerAddressPhone] nvarchar(200),
	[CurrentSellerBankAccount] nvarchar(200),
	[CurrentBuyerName] nvarchar(200),
	[CurrentBuyerTaxNumber] nvarchar(200),
	[CurrentBuyerAddressPhone] nvarchar(200),
	[CurrentBuyerBankAccount] nvarchar(200),
	[ChequeCode] nvarchar(500),
	[ChequeCategory] nvarchar(500)
);

INSERT INTO [dbo].[Cheque_OutSummary] (
	[Cheque_OutSummary].[WriteDate],
	[Cheque_OutSummary].[WriteMan],
	[Cheque_OutSummary].[DepartmentID],
	[Cheque_OutSummary].[DepartmentFile],
	[Cheque_OutSummary].[ProjectID],
	[Cheque_OutSummary].[SellerID],
	[Cheque_OutSummary].[AddTime],
	[Cheque_OutSummary].[Remark],
	[Cheque_OutSummary].[SignState],
	[Cheque_OutSummary].[SignOperator],
	[Cheque_OutSummary].[SignRemark],
	[Cheque_OutSummary].[SignTime],
	[Cheque_OutSummary].[ApproveState],
	[Cheque_OutSummary].[ApproveOperator],
	[Cheque_OutSummary].[ApproveRemark],
	[Cheque_OutSummary].[ApporveTime],
	[Cheque_OutSummary].[ChequeNumber],
	[Cheque_OutSummary].[ChequeTime],
	[Cheque_OutSummary].[BuyerID],
	[Cheque_OutSummary].[CurrentDepartmentName],
	[Cheque_OutSummary].[CurrentProjectName],
	[Cheque_OutSummary].[CurrentSellerName],
	[Cheque_OutSummary].[CurrentSellerTaxNumber],
	[Cheque_OutSummary].[CurrentSellerAddressPhone],
	[Cheque_OutSummary].[CurrentSellerBankAccount],
	[Cheque_OutSummary].[CurrentBuyerName],
	[Cheque_OutSummary].[CurrentBuyerTaxNumber],
	[Cheque_OutSummary].[CurrentBuyerAddressPhone],
	[Cheque_OutSummary].[CurrentBuyerBankAccount],
	[Cheque_OutSummary].[ChequeCode],
	[Cheque_OutSummary].[ChequeCategory]
) 
output 
	INSERTED.[ID],
	INSERTED.[WriteDate],
	INSERTED.[WriteMan],
	INSERTED.[DepartmentID],
	INSERTED.[DepartmentFile],
	INSERTED.[ProjectID],
	INSERTED.[SellerID],
	INSERTED.[AddTime],
	INSERTED.[Remark],
	INSERTED.[SignState],
	INSERTED.[SignOperator],
	INSERTED.[SignRemark],
	INSERTED.[SignTime],
	INSERTED.[ApproveState],
	INSERTED.[ApproveOperator],
	INSERTED.[ApproveRemark],
	INSERTED.[ApporveTime],
	INSERTED.[ChequeNumber],
	INSERTED.[ChequeTime],
	INSERTED.[BuyerID],
	INSERTED.[CurrentDepartmentName],
	INSERTED.[CurrentProjectName],
	INSERTED.[CurrentSellerName],
	INSERTED.[CurrentSellerTaxNumber],
	INSERTED.[CurrentSellerAddressPhone],
	INSERTED.[CurrentSellerBankAccount],
	INSERTED.[CurrentBuyerName],
	INSERTED.[CurrentBuyerTaxNumber],
	INSERTED.[CurrentBuyerAddressPhone],
	INSERTED.[CurrentBuyerBankAccount],
	INSERTED.[ChequeCode],
	INSERTED.[ChequeCategory]
into @table
VALUES ( 
	@WriteDate,
	@WriteMan,
	@DepartmentID,
	@DepartmentFile,
	@ProjectID,
	@SellerID,
	@AddTime,
	@Remark,
	@SignState,
	@SignOperator,
	@SignRemark,
	@SignTime,
	@ApproveState,
	@ApproveOperator,
	@ApproveRemark,
	@ApporveTime,
	@ChequeNumber,
	@ChequeTime,
	@BuyerID,
	@CurrentDepartmentName,
	@CurrentProjectName,
	@CurrentSellerName,
	@CurrentSellerTaxNumber,
	@CurrentSellerAddressPhone,
	@CurrentSellerBankAccount,
	@CurrentBuyerName,
	@CurrentBuyerTaxNumber,
	@CurrentBuyerAddressPhone,
	@CurrentBuyerBankAccount,
	@ChequeCode,
	@ChequeCategory 
); 

SELECT 
	[ID],
	[WriteDate],
	[WriteMan],
	[DepartmentID],
	[DepartmentFile],
	[ProjectID],
	[SellerID],
	[AddTime],
	[Remark],
	[SignState],
	[SignOperator],
	[SignRemark],
	[SignTime],
	[ApproveState],
	[ApproveOperator],
	[ApproveRemark],
	[ApporveTime],
	[ChequeNumber],
	[ChequeTime],
	[BuyerID],
	[CurrentDepartmentName],
	[CurrentProjectName],
	[CurrentSellerName],
	[CurrentSellerTaxNumber],
	[CurrentSellerAddressPhone],
	[CurrentSellerBankAccount],
	[CurrentBuyerName],
	[CurrentBuyerTaxNumber],
	[CurrentBuyerAddressPhone],
	[CurrentBuyerBankAccount],
	[ChequeCode],
	[ChequeCategory] 
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
	[WriteDate] datetime,
	[WriteMan] nvarchar(50),
	[DepartmentID] int,
	[DepartmentFile] nvarchar(200),
	[ProjectID] int,
	[SellerID] int,
	[AddTime] datetime,
	[Remark] ntext,
	[SignState] int,
	[SignOperator] nvarchar(50),
	[SignRemark] ntext,
	[SignTime] datetime,
	[ApproveState] int,
	[ApproveOperator] nvarchar(50),
	[ApproveRemark] ntext,
	[ApporveTime] datetime,
	[ChequeNumber] nvarchar(50),
	[ChequeTime] datetime,
	[BuyerID] int,
	[CurrentDepartmentName] nvarchar(200),
	[CurrentProjectName] nvarchar(200),
	[CurrentSellerName] nvarchar(200),
	[CurrentSellerTaxNumber] nvarchar(200),
	[CurrentSellerAddressPhone] nvarchar(200),
	[CurrentSellerBankAccount] nvarchar(200),
	[CurrentBuyerName] nvarchar(200),
	[CurrentBuyerTaxNumber] nvarchar(200),
	[CurrentBuyerAddressPhone] nvarchar(200),
	[CurrentBuyerBankAccount] nvarchar(200),
	[ChequeCode] nvarchar(500),
	[ChequeCategory] nvarchar(500)
);

UPDATE [dbo].[Cheque_OutSummary] SET 
	[Cheque_OutSummary].[WriteDate] = @WriteDate,
	[Cheque_OutSummary].[WriteMan] = @WriteMan,
	[Cheque_OutSummary].[DepartmentID] = @DepartmentID,
	[Cheque_OutSummary].[DepartmentFile] = @DepartmentFile,
	[Cheque_OutSummary].[ProjectID] = @ProjectID,
	[Cheque_OutSummary].[SellerID] = @SellerID,
	[Cheque_OutSummary].[AddTime] = @AddTime,
	[Cheque_OutSummary].[Remark] = @Remark,
	[Cheque_OutSummary].[SignState] = @SignState,
	[Cheque_OutSummary].[SignOperator] = @SignOperator,
	[Cheque_OutSummary].[SignRemark] = @SignRemark,
	[Cheque_OutSummary].[SignTime] = @SignTime,
	[Cheque_OutSummary].[ApproveState] = @ApproveState,
	[Cheque_OutSummary].[ApproveOperator] = @ApproveOperator,
	[Cheque_OutSummary].[ApproveRemark] = @ApproveRemark,
	[Cheque_OutSummary].[ApporveTime] = @ApporveTime,
	[Cheque_OutSummary].[ChequeNumber] = @ChequeNumber,
	[Cheque_OutSummary].[ChequeTime] = @ChequeTime,
	[Cheque_OutSummary].[BuyerID] = @BuyerID,
	[Cheque_OutSummary].[CurrentDepartmentName] = @CurrentDepartmentName,
	[Cheque_OutSummary].[CurrentProjectName] = @CurrentProjectName,
	[Cheque_OutSummary].[CurrentSellerName] = @CurrentSellerName,
	[Cheque_OutSummary].[CurrentSellerTaxNumber] = @CurrentSellerTaxNumber,
	[Cheque_OutSummary].[CurrentSellerAddressPhone] = @CurrentSellerAddressPhone,
	[Cheque_OutSummary].[CurrentSellerBankAccount] = @CurrentSellerBankAccount,
	[Cheque_OutSummary].[CurrentBuyerName] = @CurrentBuyerName,
	[Cheque_OutSummary].[CurrentBuyerTaxNumber] = @CurrentBuyerTaxNumber,
	[Cheque_OutSummary].[CurrentBuyerAddressPhone] = @CurrentBuyerAddressPhone,
	[Cheque_OutSummary].[CurrentBuyerBankAccount] = @CurrentBuyerBankAccount,
	[Cheque_OutSummary].[ChequeCode] = @ChequeCode,
	[Cheque_OutSummary].[ChequeCategory] = @ChequeCategory 
output 
	INSERTED.[ID],
	INSERTED.[WriteDate],
	INSERTED.[WriteMan],
	INSERTED.[DepartmentID],
	INSERTED.[DepartmentFile],
	INSERTED.[ProjectID],
	INSERTED.[SellerID],
	INSERTED.[AddTime],
	INSERTED.[Remark],
	INSERTED.[SignState],
	INSERTED.[SignOperator],
	INSERTED.[SignRemark],
	INSERTED.[SignTime],
	INSERTED.[ApproveState],
	INSERTED.[ApproveOperator],
	INSERTED.[ApproveRemark],
	INSERTED.[ApporveTime],
	INSERTED.[ChequeNumber],
	INSERTED.[ChequeTime],
	INSERTED.[BuyerID],
	INSERTED.[CurrentDepartmentName],
	INSERTED.[CurrentProjectName],
	INSERTED.[CurrentSellerName],
	INSERTED.[CurrentSellerTaxNumber],
	INSERTED.[CurrentSellerAddressPhone],
	INSERTED.[CurrentSellerBankAccount],
	INSERTED.[CurrentBuyerName],
	INSERTED.[CurrentBuyerTaxNumber],
	INSERTED.[CurrentBuyerAddressPhone],
	INSERTED.[CurrentBuyerBankAccount],
	INSERTED.[ChequeCode],
	INSERTED.[ChequeCategory]
into @table
WHERE 
	[Cheque_OutSummary].[ID] = @ID

SELECT 
	[ID],
	[WriteDate],
	[WriteMan],
	[DepartmentID],
	[DepartmentFile],
	[ProjectID],
	[SellerID],
	[AddTime],
	[Remark],
	[SignState],
	[SignOperator],
	[SignRemark],
	[SignTime],
	[ApproveState],
	[ApproveOperator],
	[ApproveRemark],
	[ApporveTime],
	[ChequeNumber],
	[ChequeTime],
	[BuyerID],
	[CurrentDepartmentName],
	[CurrentProjectName],
	[CurrentSellerName],
	[CurrentSellerTaxNumber],
	[CurrentSellerAddressPhone],
	[CurrentSellerBankAccount],
	[CurrentBuyerName],
	[CurrentBuyerTaxNumber],
	[CurrentBuyerAddressPhone],
	[CurrentBuyerBankAccount],
	[ChequeCode],
	[ChequeCategory] 
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
DELETE FROM [dbo].[Cheque_OutSummary]
WHERE 
	[Cheque_OutSummary].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_OutSummary() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_OutSummary(this.ID));
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
	[Cheque_OutSummary].[ID],
	[Cheque_OutSummary].[WriteDate],
	[Cheque_OutSummary].[WriteMan],
	[Cheque_OutSummary].[DepartmentID],
	[Cheque_OutSummary].[DepartmentFile],
	[Cheque_OutSummary].[ProjectID],
	[Cheque_OutSummary].[SellerID],
	[Cheque_OutSummary].[AddTime],
	[Cheque_OutSummary].[Remark],
	[Cheque_OutSummary].[SignState],
	[Cheque_OutSummary].[SignOperator],
	[Cheque_OutSummary].[SignRemark],
	[Cheque_OutSummary].[SignTime],
	[Cheque_OutSummary].[ApproveState],
	[Cheque_OutSummary].[ApproveOperator],
	[Cheque_OutSummary].[ApproveRemark],
	[Cheque_OutSummary].[ApporveTime],
	[Cheque_OutSummary].[ChequeNumber],
	[Cheque_OutSummary].[ChequeTime],
	[Cheque_OutSummary].[BuyerID],
	[Cheque_OutSummary].[CurrentDepartmentName],
	[Cheque_OutSummary].[CurrentProjectName],
	[Cheque_OutSummary].[CurrentSellerName],
	[Cheque_OutSummary].[CurrentSellerTaxNumber],
	[Cheque_OutSummary].[CurrentSellerAddressPhone],
	[Cheque_OutSummary].[CurrentSellerBankAccount],
	[Cheque_OutSummary].[CurrentBuyerName],
	[Cheque_OutSummary].[CurrentBuyerTaxNumber],
	[Cheque_OutSummary].[CurrentBuyerAddressPhone],
	[Cheque_OutSummary].[CurrentBuyerBankAccount],
	[Cheque_OutSummary].[ChequeCode],
	[Cheque_OutSummary].[ChequeCategory]
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
                return "Cheque_OutSummary";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_OutSummary into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="writeDate">writeDate</param>
		/// <param name="writeMan">writeMan</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="departmentFile">departmentFile</param>
		/// <param name="projectID">projectID</param>
		/// <param name="sellerID">sellerID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="remark">remark</param>
		/// <param name="signState">signState</param>
		/// <param name="signOperator">signOperator</param>
		/// <param name="signRemark">signRemark</param>
		/// <param name="signTime">signTime</param>
		/// <param name="approveState">approveState</param>
		/// <param name="approveOperator">approveOperator</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="apporveTime">apporveTime</param>
		/// <param name="chequeNumber">chequeNumber</param>
		/// <param name="chequeTime">chequeTime</param>
		/// <param name="buyerID">buyerID</param>
		/// <param name="currentDepartmentName">currentDepartmentName</param>
		/// <param name="currentProjectName">currentProjectName</param>
		/// <param name="currentSellerName">currentSellerName</param>
		/// <param name="currentSellerTaxNumber">currentSellerTaxNumber</param>
		/// <param name="currentSellerAddressPhone">currentSellerAddressPhone</param>
		/// <param name="currentSellerBankAccount">currentSellerBankAccount</param>
		/// <param name="currentBuyerName">currentBuyerName</param>
		/// <param name="currentBuyerTaxNumber">currentBuyerTaxNumber</param>
		/// <param name="currentBuyerAddressPhone">currentBuyerAddressPhone</param>
		/// <param name="currentBuyerBankAccount">currentBuyerBankAccount</param>
		/// <param name="chequeCode">chequeCode</param>
		/// <param name="chequeCategory">chequeCategory</param>
		public static void InsertCheque_OutSummary(DateTime @writeDate, string @writeMan, int @departmentID, string @departmentFile, int @projectID, int @sellerID, DateTime @addTime, string @remark, int @signState, string @signOperator, string @signRemark, DateTime @signTime, int @approveState, string @approveOperator, string @approveRemark, DateTime @apporveTime, string @chequeNumber, DateTime @chequeTime, int @buyerID, string @currentDepartmentName, string @currentProjectName, string @currentSellerName, string @currentSellerTaxNumber, string @currentSellerAddressPhone, string @currentSellerBankAccount, string @currentBuyerName, string @currentBuyerTaxNumber, string @currentBuyerAddressPhone, string @currentBuyerBankAccount, string @chequeCode, string @chequeCategory)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_OutSummary(@writeDate, @writeMan, @departmentID, @departmentFile, @projectID, @sellerID, @addTime, @remark, @signState, @signOperator, @signRemark, @signTime, @approveState, @approveOperator, @approveRemark, @apporveTime, @chequeNumber, @chequeTime, @buyerID, @currentDepartmentName, @currentProjectName, @currentSellerName, @currentSellerTaxNumber, @currentSellerAddressPhone, @currentSellerBankAccount, @currentBuyerName, @currentBuyerTaxNumber, @currentBuyerAddressPhone, @currentBuyerBankAccount, @chequeCode, @chequeCategory, helper);
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
		/// Insert a Cheque_OutSummary into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="writeDate">writeDate</param>
		/// <param name="writeMan">writeMan</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="departmentFile">departmentFile</param>
		/// <param name="projectID">projectID</param>
		/// <param name="sellerID">sellerID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="remark">remark</param>
		/// <param name="signState">signState</param>
		/// <param name="signOperator">signOperator</param>
		/// <param name="signRemark">signRemark</param>
		/// <param name="signTime">signTime</param>
		/// <param name="approveState">approveState</param>
		/// <param name="approveOperator">approveOperator</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="apporveTime">apporveTime</param>
		/// <param name="chequeNumber">chequeNumber</param>
		/// <param name="chequeTime">chequeTime</param>
		/// <param name="buyerID">buyerID</param>
		/// <param name="currentDepartmentName">currentDepartmentName</param>
		/// <param name="currentProjectName">currentProjectName</param>
		/// <param name="currentSellerName">currentSellerName</param>
		/// <param name="currentSellerTaxNumber">currentSellerTaxNumber</param>
		/// <param name="currentSellerAddressPhone">currentSellerAddressPhone</param>
		/// <param name="currentSellerBankAccount">currentSellerBankAccount</param>
		/// <param name="currentBuyerName">currentBuyerName</param>
		/// <param name="currentBuyerTaxNumber">currentBuyerTaxNumber</param>
		/// <param name="currentBuyerAddressPhone">currentBuyerAddressPhone</param>
		/// <param name="currentBuyerBankAccount">currentBuyerBankAccount</param>
		/// <param name="chequeCode">chequeCode</param>
		/// <param name="chequeCategory">chequeCategory</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_OutSummary(DateTime @writeDate, string @writeMan, int @departmentID, string @departmentFile, int @projectID, int @sellerID, DateTime @addTime, string @remark, int @signState, string @signOperator, string @signRemark, DateTime @signTime, int @approveState, string @approveOperator, string @approveRemark, DateTime @apporveTime, string @chequeNumber, DateTime @chequeTime, int @buyerID, string @currentDepartmentName, string @currentProjectName, string @currentSellerName, string @currentSellerTaxNumber, string @currentSellerAddressPhone, string @currentSellerBankAccount, string @currentBuyerName, string @currentBuyerTaxNumber, string @currentBuyerAddressPhone, string @currentBuyerBankAccount, string @chequeCode, string @chequeCategory, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[WriteDate] datetime,
	[WriteMan] nvarchar(50),
	[DepartmentID] int,
	[DepartmentFile] nvarchar(200),
	[ProjectID] int,
	[SellerID] int,
	[AddTime] datetime,
	[Remark] ntext,
	[SignState] int,
	[SignOperator] nvarchar(50),
	[SignRemark] ntext,
	[SignTime] datetime,
	[ApproveState] int,
	[ApproveOperator] nvarchar(50),
	[ApproveRemark] ntext,
	[ApporveTime] datetime,
	[ChequeNumber] nvarchar(50),
	[ChequeTime] datetime,
	[BuyerID] int,
	[CurrentDepartmentName] nvarchar(200),
	[CurrentProjectName] nvarchar(200),
	[CurrentSellerName] nvarchar(200),
	[CurrentSellerTaxNumber] nvarchar(200),
	[CurrentSellerAddressPhone] nvarchar(200),
	[CurrentSellerBankAccount] nvarchar(200),
	[CurrentBuyerName] nvarchar(200),
	[CurrentBuyerTaxNumber] nvarchar(200),
	[CurrentBuyerAddressPhone] nvarchar(200),
	[CurrentBuyerBankAccount] nvarchar(200),
	[ChequeCode] nvarchar(500),
	[ChequeCategory] nvarchar(500)
);

INSERT INTO [dbo].[Cheque_OutSummary] (
	[Cheque_OutSummary].[WriteDate],
	[Cheque_OutSummary].[WriteMan],
	[Cheque_OutSummary].[DepartmentID],
	[Cheque_OutSummary].[DepartmentFile],
	[Cheque_OutSummary].[ProjectID],
	[Cheque_OutSummary].[SellerID],
	[Cheque_OutSummary].[AddTime],
	[Cheque_OutSummary].[Remark],
	[Cheque_OutSummary].[SignState],
	[Cheque_OutSummary].[SignOperator],
	[Cheque_OutSummary].[SignRemark],
	[Cheque_OutSummary].[SignTime],
	[Cheque_OutSummary].[ApproveState],
	[Cheque_OutSummary].[ApproveOperator],
	[Cheque_OutSummary].[ApproveRemark],
	[Cheque_OutSummary].[ApporveTime],
	[Cheque_OutSummary].[ChequeNumber],
	[Cheque_OutSummary].[ChequeTime],
	[Cheque_OutSummary].[BuyerID],
	[Cheque_OutSummary].[CurrentDepartmentName],
	[Cheque_OutSummary].[CurrentProjectName],
	[Cheque_OutSummary].[CurrentSellerName],
	[Cheque_OutSummary].[CurrentSellerTaxNumber],
	[Cheque_OutSummary].[CurrentSellerAddressPhone],
	[Cheque_OutSummary].[CurrentSellerBankAccount],
	[Cheque_OutSummary].[CurrentBuyerName],
	[Cheque_OutSummary].[CurrentBuyerTaxNumber],
	[Cheque_OutSummary].[CurrentBuyerAddressPhone],
	[Cheque_OutSummary].[CurrentBuyerBankAccount],
	[Cheque_OutSummary].[ChequeCode],
	[Cheque_OutSummary].[ChequeCategory]
) 
output 
	INSERTED.[ID],
	INSERTED.[WriteDate],
	INSERTED.[WriteMan],
	INSERTED.[DepartmentID],
	INSERTED.[DepartmentFile],
	INSERTED.[ProjectID],
	INSERTED.[SellerID],
	INSERTED.[AddTime],
	INSERTED.[Remark],
	INSERTED.[SignState],
	INSERTED.[SignOperator],
	INSERTED.[SignRemark],
	INSERTED.[SignTime],
	INSERTED.[ApproveState],
	INSERTED.[ApproveOperator],
	INSERTED.[ApproveRemark],
	INSERTED.[ApporveTime],
	INSERTED.[ChequeNumber],
	INSERTED.[ChequeTime],
	INSERTED.[BuyerID],
	INSERTED.[CurrentDepartmentName],
	INSERTED.[CurrentProjectName],
	INSERTED.[CurrentSellerName],
	INSERTED.[CurrentSellerTaxNumber],
	INSERTED.[CurrentSellerAddressPhone],
	INSERTED.[CurrentSellerBankAccount],
	INSERTED.[CurrentBuyerName],
	INSERTED.[CurrentBuyerTaxNumber],
	INSERTED.[CurrentBuyerAddressPhone],
	INSERTED.[CurrentBuyerBankAccount],
	INSERTED.[ChequeCode],
	INSERTED.[ChequeCategory]
into @table
VALUES ( 
	@WriteDate,
	@WriteMan,
	@DepartmentID,
	@DepartmentFile,
	@ProjectID,
	@SellerID,
	@AddTime,
	@Remark,
	@SignState,
	@SignOperator,
	@SignRemark,
	@SignTime,
	@ApproveState,
	@ApproveOperator,
	@ApproveRemark,
	@ApporveTime,
	@ChequeNumber,
	@ChequeTime,
	@BuyerID,
	@CurrentDepartmentName,
	@CurrentProjectName,
	@CurrentSellerName,
	@CurrentSellerTaxNumber,
	@CurrentSellerAddressPhone,
	@CurrentSellerBankAccount,
	@CurrentBuyerName,
	@CurrentBuyerTaxNumber,
	@CurrentBuyerAddressPhone,
	@CurrentBuyerBankAccount,
	@ChequeCode,
	@ChequeCategory 
); 

SELECT 
	[ID],
	[WriteDate],
	[WriteMan],
	[DepartmentID],
	[DepartmentFile],
	[ProjectID],
	[SellerID],
	[AddTime],
	[Remark],
	[SignState],
	[SignOperator],
	[SignRemark],
	[SignTime],
	[ApproveState],
	[ApproveOperator],
	[ApproveRemark],
	[ApporveTime],
	[ChequeNumber],
	[ChequeTime],
	[BuyerID],
	[CurrentDepartmentName],
	[CurrentProjectName],
	[CurrentSellerName],
	[CurrentSellerTaxNumber],
	[CurrentSellerAddressPhone],
	[CurrentSellerBankAccount],
	[CurrentBuyerName],
	[CurrentBuyerTaxNumber],
	[CurrentBuyerAddressPhone],
	[CurrentBuyerBankAccount],
	[ChequeCode],
	[ChequeCategory] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@WriteDate", EntityBase.GetDatabaseValue(@writeDate)));
			parameters.Add(new SqlParameter("@WriteMan", EntityBase.GetDatabaseValue(@writeMan)));
			parameters.Add(new SqlParameter("@DepartmentID", EntityBase.GetDatabaseValue(@departmentID)));
			parameters.Add(new SqlParameter("@DepartmentFile", EntityBase.GetDatabaseValue(@departmentFile)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@SellerID", EntityBase.GetDatabaseValue(@sellerID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@SignState", EntityBase.GetDatabaseValue(@signState)));
			parameters.Add(new SqlParameter("@SignOperator", EntityBase.GetDatabaseValue(@signOperator)));
			parameters.Add(new SqlParameter("@SignRemark", EntityBase.GetDatabaseValue(@signRemark)));
			parameters.Add(new SqlParameter("@SignTime", EntityBase.GetDatabaseValue(@signTime)));
			parameters.Add(new SqlParameter("@ApproveState", EntityBase.GetDatabaseValue(@approveState)));
			parameters.Add(new SqlParameter("@ApproveOperator", EntityBase.GetDatabaseValue(@approveOperator)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@ApporveTime", EntityBase.GetDatabaseValue(@apporveTime)));
			parameters.Add(new SqlParameter("@ChequeNumber", EntityBase.GetDatabaseValue(@chequeNumber)));
			parameters.Add(new SqlParameter("@ChequeTime", EntityBase.GetDatabaseValue(@chequeTime)));
			parameters.Add(new SqlParameter("@BuyerID", EntityBase.GetDatabaseValue(@buyerID)));
			parameters.Add(new SqlParameter("@CurrentDepartmentName", EntityBase.GetDatabaseValue(@currentDepartmentName)));
			parameters.Add(new SqlParameter("@CurrentProjectName", EntityBase.GetDatabaseValue(@currentProjectName)));
			parameters.Add(new SqlParameter("@CurrentSellerName", EntityBase.GetDatabaseValue(@currentSellerName)));
			parameters.Add(new SqlParameter("@CurrentSellerTaxNumber", EntityBase.GetDatabaseValue(@currentSellerTaxNumber)));
			parameters.Add(new SqlParameter("@CurrentSellerAddressPhone", EntityBase.GetDatabaseValue(@currentSellerAddressPhone)));
			parameters.Add(new SqlParameter("@CurrentSellerBankAccount", EntityBase.GetDatabaseValue(@currentSellerBankAccount)));
			parameters.Add(new SqlParameter("@CurrentBuyerName", EntityBase.GetDatabaseValue(@currentBuyerName)));
			parameters.Add(new SqlParameter("@CurrentBuyerTaxNumber", EntityBase.GetDatabaseValue(@currentBuyerTaxNumber)));
			parameters.Add(new SqlParameter("@CurrentBuyerAddressPhone", EntityBase.GetDatabaseValue(@currentBuyerAddressPhone)));
			parameters.Add(new SqlParameter("@CurrentBuyerBankAccount", EntityBase.GetDatabaseValue(@currentBuyerBankAccount)));
			parameters.Add(new SqlParameter("@ChequeCode", EntityBase.GetDatabaseValue(@chequeCode)));
			parameters.Add(new SqlParameter("@ChequeCategory", EntityBase.GetDatabaseValue(@chequeCategory)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_OutSummary into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="writeMan">writeMan</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="departmentFile">departmentFile</param>
		/// <param name="projectID">projectID</param>
		/// <param name="sellerID">sellerID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="remark">remark</param>
		/// <param name="signState">signState</param>
		/// <param name="signOperator">signOperator</param>
		/// <param name="signRemark">signRemark</param>
		/// <param name="signTime">signTime</param>
		/// <param name="approveState">approveState</param>
		/// <param name="approveOperator">approveOperator</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="apporveTime">apporveTime</param>
		/// <param name="chequeNumber">chequeNumber</param>
		/// <param name="chequeTime">chequeTime</param>
		/// <param name="buyerID">buyerID</param>
		/// <param name="currentDepartmentName">currentDepartmentName</param>
		/// <param name="currentProjectName">currentProjectName</param>
		/// <param name="currentSellerName">currentSellerName</param>
		/// <param name="currentSellerTaxNumber">currentSellerTaxNumber</param>
		/// <param name="currentSellerAddressPhone">currentSellerAddressPhone</param>
		/// <param name="currentSellerBankAccount">currentSellerBankAccount</param>
		/// <param name="currentBuyerName">currentBuyerName</param>
		/// <param name="currentBuyerTaxNumber">currentBuyerTaxNumber</param>
		/// <param name="currentBuyerAddressPhone">currentBuyerAddressPhone</param>
		/// <param name="currentBuyerBankAccount">currentBuyerBankAccount</param>
		/// <param name="chequeCode">chequeCode</param>
		/// <param name="chequeCategory">chequeCategory</param>
		public static void UpdateCheque_OutSummary(int @iD, DateTime @writeDate, string @writeMan, int @departmentID, string @departmentFile, int @projectID, int @sellerID, DateTime @addTime, string @remark, int @signState, string @signOperator, string @signRemark, DateTime @signTime, int @approveState, string @approveOperator, string @approveRemark, DateTime @apporveTime, string @chequeNumber, DateTime @chequeTime, int @buyerID, string @currentDepartmentName, string @currentProjectName, string @currentSellerName, string @currentSellerTaxNumber, string @currentSellerAddressPhone, string @currentSellerBankAccount, string @currentBuyerName, string @currentBuyerTaxNumber, string @currentBuyerAddressPhone, string @currentBuyerBankAccount, string @chequeCode, string @chequeCategory)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_OutSummary(@iD, @writeDate, @writeMan, @departmentID, @departmentFile, @projectID, @sellerID, @addTime, @remark, @signState, @signOperator, @signRemark, @signTime, @approveState, @approveOperator, @approveRemark, @apporveTime, @chequeNumber, @chequeTime, @buyerID, @currentDepartmentName, @currentProjectName, @currentSellerName, @currentSellerTaxNumber, @currentSellerAddressPhone, @currentSellerBankAccount, @currentBuyerName, @currentBuyerTaxNumber, @currentBuyerAddressPhone, @currentBuyerBankAccount, @chequeCode, @chequeCategory, helper);
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
		/// Updates a Cheque_OutSummary into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="writeMan">writeMan</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="departmentFile">departmentFile</param>
		/// <param name="projectID">projectID</param>
		/// <param name="sellerID">sellerID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="remark">remark</param>
		/// <param name="signState">signState</param>
		/// <param name="signOperator">signOperator</param>
		/// <param name="signRemark">signRemark</param>
		/// <param name="signTime">signTime</param>
		/// <param name="approveState">approveState</param>
		/// <param name="approveOperator">approveOperator</param>
		/// <param name="approveRemark">approveRemark</param>
		/// <param name="apporveTime">apporveTime</param>
		/// <param name="chequeNumber">chequeNumber</param>
		/// <param name="chequeTime">chequeTime</param>
		/// <param name="buyerID">buyerID</param>
		/// <param name="currentDepartmentName">currentDepartmentName</param>
		/// <param name="currentProjectName">currentProjectName</param>
		/// <param name="currentSellerName">currentSellerName</param>
		/// <param name="currentSellerTaxNumber">currentSellerTaxNumber</param>
		/// <param name="currentSellerAddressPhone">currentSellerAddressPhone</param>
		/// <param name="currentSellerBankAccount">currentSellerBankAccount</param>
		/// <param name="currentBuyerName">currentBuyerName</param>
		/// <param name="currentBuyerTaxNumber">currentBuyerTaxNumber</param>
		/// <param name="currentBuyerAddressPhone">currentBuyerAddressPhone</param>
		/// <param name="currentBuyerBankAccount">currentBuyerBankAccount</param>
		/// <param name="chequeCode">chequeCode</param>
		/// <param name="chequeCategory">chequeCategory</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_OutSummary(int @iD, DateTime @writeDate, string @writeMan, int @departmentID, string @departmentFile, int @projectID, int @sellerID, DateTime @addTime, string @remark, int @signState, string @signOperator, string @signRemark, DateTime @signTime, int @approveState, string @approveOperator, string @approveRemark, DateTime @apporveTime, string @chequeNumber, DateTime @chequeTime, int @buyerID, string @currentDepartmentName, string @currentProjectName, string @currentSellerName, string @currentSellerTaxNumber, string @currentSellerAddressPhone, string @currentSellerBankAccount, string @currentBuyerName, string @currentBuyerTaxNumber, string @currentBuyerAddressPhone, string @currentBuyerBankAccount, string @chequeCode, string @chequeCategory, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[WriteDate] datetime,
	[WriteMan] nvarchar(50),
	[DepartmentID] int,
	[DepartmentFile] nvarchar(200),
	[ProjectID] int,
	[SellerID] int,
	[AddTime] datetime,
	[Remark] ntext,
	[SignState] int,
	[SignOperator] nvarchar(50),
	[SignRemark] ntext,
	[SignTime] datetime,
	[ApproveState] int,
	[ApproveOperator] nvarchar(50),
	[ApproveRemark] ntext,
	[ApporveTime] datetime,
	[ChequeNumber] nvarchar(50),
	[ChequeTime] datetime,
	[BuyerID] int,
	[CurrentDepartmentName] nvarchar(200),
	[CurrentProjectName] nvarchar(200),
	[CurrentSellerName] nvarchar(200),
	[CurrentSellerTaxNumber] nvarchar(200),
	[CurrentSellerAddressPhone] nvarchar(200),
	[CurrentSellerBankAccount] nvarchar(200),
	[CurrentBuyerName] nvarchar(200),
	[CurrentBuyerTaxNumber] nvarchar(200),
	[CurrentBuyerAddressPhone] nvarchar(200),
	[CurrentBuyerBankAccount] nvarchar(200),
	[ChequeCode] nvarchar(500),
	[ChequeCategory] nvarchar(500)
);

UPDATE [dbo].[Cheque_OutSummary] SET 
	[Cheque_OutSummary].[WriteDate] = @WriteDate,
	[Cheque_OutSummary].[WriteMan] = @WriteMan,
	[Cheque_OutSummary].[DepartmentID] = @DepartmentID,
	[Cheque_OutSummary].[DepartmentFile] = @DepartmentFile,
	[Cheque_OutSummary].[ProjectID] = @ProjectID,
	[Cheque_OutSummary].[SellerID] = @SellerID,
	[Cheque_OutSummary].[AddTime] = @AddTime,
	[Cheque_OutSummary].[Remark] = @Remark,
	[Cheque_OutSummary].[SignState] = @SignState,
	[Cheque_OutSummary].[SignOperator] = @SignOperator,
	[Cheque_OutSummary].[SignRemark] = @SignRemark,
	[Cheque_OutSummary].[SignTime] = @SignTime,
	[Cheque_OutSummary].[ApproveState] = @ApproveState,
	[Cheque_OutSummary].[ApproveOperator] = @ApproveOperator,
	[Cheque_OutSummary].[ApproveRemark] = @ApproveRemark,
	[Cheque_OutSummary].[ApporveTime] = @ApporveTime,
	[Cheque_OutSummary].[ChequeNumber] = @ChequeNumber,
	[Cheque_OutSummary].[ChequeTime] = @ChequeTime,
	[Cheque_OutSummary].[BuyerID] = @BuyerID,
	[Cheque_OutSummary].[CurrentDepartmentName] = @CurrentDepartmentName,
	[Cheque_OutSummary].[CurrentProjectName] = @CurrentProjectName,
	[Cheque_OutSummary].[CurrentSellerName] = @CurrentSellerName,
	[Cheque_OutSummary].[CurrentSellerTaxNumber] = @CurrentSellerTaxNumber,
	[Cheque_OutSummary].[CurrentSellerAddressPhone] = @CurrentSellerAddressPhone,
	[Cheque_OutSummary].[CurrentSellerBankAccount] = @CurrentSellerBankAccount,
	[Cheque_OutSummary].[CurrentBuyerName] = @CurrentBuyerName,
	[Cheque_OutSummary].[CurrentBuyerTaxNumber] = @CurrentBuyerTaxNumber,
	[Cheque_OutSummary].[CurrentBuyerAddressPhone] = @CurrentBuyerAddressPhone,
	[Cheque_OutSummary].[CurrentBuyerBankAccount] = @CurrentBuyerBankAccount,
	[Cheque_OutSummary].[ChequeCode] = @ChequeCode,
	[Cheque_OutSummary].[ChequeCategory] = @ChequeCategory 
output 
	INSERTED.[ID],
	INSERTED.[WriteDate],
	INSERTED.[WriteMan],
	INSERTED.[DepartmentID],
	INSERTED.[DepartmentFile],
	INSERTED.[ProjectID],
	INSERTED.[SellerID],
	INSERTED.[AddTime],
	INSERTED.[Remark],
	INSERTED.[SignState],
	INSERTED.[SignOperator],
	INSERTED.[SignRemark],
	INSERTED.[SignTime],
	INSERTED.[ApproveState],
	INSERTED.[ApproveOperator],
	INSERTED.[ApproveRemark],
	INSERTED.[ApporveTime],
	INSERTED.[ChequeNumber],
	INSERTED.[ChequeTime],
	INSERTED.[BuyerID],
	INSERTED.[CurrentDepartmentName],
	INSERTED.[CurrentProjectName],
	INSERTED.[CurrentSellerName],
	INSERTED.[CurrentSellerTaxNumber],
	INSERTED.[CurrentSellerAddressPhone],
	INSERTED.[CurrentSellerBankAccount],
	INSERTED.[CurrentBuyerName],
	INSERTED.[CurrentBuyerTaxNumber],
	INSERTED.[CurrentBuyerAddressPhone],
	INSERTED.[CurrentBuyerBankAccount],
	INSERTED.[ChequeCode],
	INSERTED.[ChequeCategory]
into @table
WHERE 
	[Cheque_OutSummary].[ID] = @ID

SELECT 
	[ID],
	[WriteDate],
	[WriteMan],
	[DepartmentID],
	[DepartmentFile],
	[ProjectID],
	[SellerID],
	[AddTime],
	[Remark],
	[SignState],
	[SignOperator],
	[SignRemark],
	[SignTime],
	[ApproveState],
	[ApproveOperator],
	[ApproveRemark],
	[ApporveTime],
	[ChequeNumber],
	[ChequeTime],
	[BuyerID],
	[CurrentDepartmentName],
	[CurrentProjectName],
	[CurrentSellerName],
	[CurrentSellerTaxNumber],
	[CurrentSellerAddressPhone],
	[CurrentSellerBankAccount],
	[CurrentBuyerName],
	[CurrentBuyerTaxNumber],
	[CurrentBuyerAddressPhone],
	[CurrentBuyerBankAccount],
	[ChequeCode],
	[ChequeCategory] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@WriteDate", EntityBase.GetDatabaseValue(@writeDate)));
			parameters.Add(new SqlParameter("@WriteMan", EntityBase.GetDatabaseValue(@writeMan)));
			parameters.Add(new SqlParameter("@DepartmentID", EntityBase.GetDatabaseValue(@departmentID)));
			parameters.Add(new SqlParameter("@DepartmentFile", EntityBase.GetDatabaseValue(@departmentFile)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@SellerID", EntityBase.GetDatabaseValue(@sellerID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@SignState", EntityBase.GetDatabaseValue(@signState)));
			parameters.Add(new SqlParameter("@SignOperator", EntityBase.GetDatabaseValue(@signOperator)));
			parameters.Add(new SqlParameter("@SignRemark", EntityBase.GetDatabaseValue(@signRemark)));
			parameters.Add(new SqlParameter("@SignTime", EntityBase.GetDatabaseValue(@signTime)));
			parameters.Add(new SqlParameter("@ApproveState", EntityBase.GetDatabaseValue(@approveState)));
			parameters.Add(new SqlParameter("@ApproveOperator", EntityBase.GetDatabaseValue(@approveOperator)));
			parameters.Add(new SqlParameter("@ApproveRemark", EntityBase.GetDatabaseValue(@approveRemark)));
			parameters.Add(new SqlParameter("@ApporveTime", EntityBase.GetDatabaseValue(@apporveTime)));
			parameters.Add(new SqlParameter("@ChequeNumber", EntityBase.GetDatabaseValue(@chequeNumber)));
			parameters.Add(new SqlParameter("@ChequeTime", EntityBase.GetDatabaseValue(@chequeTime)));
			parameters.Add(new SqlParameter("@BuyerID", EntityBase.GetDatabaseValue(@buyerID)));
			parameters.Add(new SqlParameter("@CurrentDepartmentName", EntityBase.GetDatabaseValue(@currentDepartmentName)));
			parameters.Add(new SqlParameter("@CurrentProjectName", EntityBase.GetDatabaseValue(@currentProjectName)));
			parameters.Add(new SqlParameter("@CurrentSellerName", EntityBase.GetDatabaseValue(@currentSellerName)));
			parameters.Add(new SqlParameter("@CurrentSellerTaxNumber", EntityBase.GetDatabaseValue(@currentSellerTaxNumber)));
			parameters.Add(new SqlParameter("@CurrentSellerAddressPhone", EntityBase.GetDatabaseValue(@currentSellerAddressPhone)));
			parameters.Add(new SqlParameter("@CurrentSellerBankAccount", EntityBase.GetDatabaseValue(@currentSellerBankAccount)));
			parameters.Add(new SqlParameter("@CurrentBuyerName", EntityBase.GetDatabaseValue(@currentBuyerName)));
			parameters.Add(new SqlParameter("@CurrentBuyerTaxNumber", EntityBase.GetDatabaseValue(@currentBuyerTaxNumber)));
			parameters.Add(new SqlParameter("@CurrentBuyerAddressPhone", EntityBase.GetDatabaseValue(@currentBuyerAddressPhone)));
			parameters.Add(new SqlParameter("@CurrentBuyerBankAccount", EntityBase.GetDatabaseValue(@currentBuyerBankAccount)));
			parameters.Add(new SqlParameter("@ChequeCode", EntityBase.GetDatabaseValue(@chequeCode)));
			parameters.Add(new SqlParameter("@ChequeCategory", EntityBase.GetDatabaseValue(@chequeCategory)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_OutSummary from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_OutSummary(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_OutSummary(@iD, helper);
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
		/// Deletes a Cheque_OutSummary from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_OutSummary(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_OutSummary]
WHERE 
	[Cheque_OutSummary].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_OutSummary object.
		/// </summary>
		/// <returns>The newly created Cheque_OutSummary object.</returns>
		public static Cheque_OutSummary CreateCheque_OutSummary()
		{
			return InitializeNew<Cheque_OutSummary>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_OutSummary by a Cheque_OutSummary's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_OutSummary</returns>
		public static Cheque_OutSummary GetCheque_OutSummary(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_OutSummary.SelectFieldList + @"
FROM [dbo].[Cheque_OutSummary] 
WHERE 
	[Cheque_OutSummary].[ID] = @ID " + Cheque_OutSummary.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_OutSummary>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_OutSummary by a Cheque_OutSummary's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_OutSummary</returns>
		public static Cheque_OutSummary GetCheque_OutSummary(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_OutSummary.SelectFieldList + @"
FROM [dbo].[Cheque_OutSummary] 
WHERE 
	[Cheque_OutSummary].[ID] = @ID " + Cheque_OutSummary.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_OutSummary>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutSummary objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_OutSummary objects.</returns>
		public static EntityList<Cheque_OutSummary> GetCheque_OutSummaries()
		{
			string commandText = @"
SELECT " + Cheque_OutSummary.SelectFieldList + "FROM [dbo].[Cheque_OutSummary] " + Cheque_OutSummary.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_OutSummary>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_OutSummary objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_OutSummary objects.</returns>
        public static EntityList<Cheque_OutSummary> GetCheque_OutSummaries(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_OutSummary>(SelectFieldList, "FROM [dbo].[Cheque_OutSummary]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_OutSummary objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_OutSummary objects.</returns>
        public static EntityList<Cheque_OutSummary> GetCheque_OutSummaries(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_OutSummary>(SelectFieldList, "FROM [dbo].[Cheque_OutSummary]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_OutSummary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_OutSummary objects.</returns>
		protected static EntityList<Cheque_OutSummary> GetCheque_OutSummaries(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_OutSummaries(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutSummary objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_OutSummary objects.</returns>
		protected static EntityList<Cheque_OutSummary> GetCheque_OutSummaries(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_OutSummaries(string.Empty, where, parameters, Cheque_OutSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_OutSummary objects.</returns>
		protected static EntityList<Cheque_OutSummary> GetCheque_OutSummaries(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_OutSummaries(prefix, where, parameters, Cheque_OutSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_OutSummary objects.</returns>
		protected static EntityList<Cheque_OutSummary> GetCheque_OutSummaries(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_OutSummaries(string.Empty, where, parameters, Cheque_OutSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutSummary objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_OutSummary objects.</returns>
		protected static EntityList<Cheque_OutSummary> GetCheque_OutSummaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_OutSummaries(prefix, where, parameters, Cheque_OutSummary.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutSummary objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_OutSummary objects.</returns>
		protected static EntityList<Cheque_OutSummary> GetCheque_OutSummaries(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_OutSummary.SelectFieldList + "FROM [dbo].[Cheque_OutSummary] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_OutSummary>(reader);
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
        protected static EntityList<Cheque_OutSummary> GetCheque_OutSummaries(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_OutSummary>(SelectFieldList, "FROM [dbo].[Cheque_OutSummary] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_OutSummary objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_OutSummaryCount()
        {
            return GetCheque_OutSummaryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_OutSummary objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_OutSummaryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_OutSummary] " + where;

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
		public static partial class Cheque_OutSummary_Properties
		{
			public const string ID = "ID";
			public const string WriteDate = "WriteDate";
			public const string WriteMan = "WriteMan";
			public const string DepartmentID = "DepartmentID";
			public const string DepartmentFile = "DepartmentFile";
			public const string ProjectID = "ProjectID";
			public const string SellerID = "SellerID";
			public const string AddTime = "AddTime";
			public const string Remark = "Remark";
			public const string SignState = "SignState";
			public const string SignOperator = "SignOperator";
			public const string SignRemark = "SignRemark";
			public const string SignTime = "SignTime";
			public const string ApproveState = "ApproveState";
			public const string ApproveOperator = "ApproveOperator";
			public const string ApproveRemark = "ApproveRemark";
			public const string ApporveTime = "ApporveTime";
			public const string ChequeNumber = "ChequeNumber";
			public const string ChequeTime = "ChequeTime";
			public const string BuyerID = "BuyerID";
			public const string CurrentDepartmentName = "CurrentDepartmentName";
			public const string CurrentProjectName = "CurrentProjectName";
			public const string CurrentSellerName = "CurrentSellerName";
			public const string CurrentSellerTaxNumber = "CurrentSellerTaxNumber";
			public const string CurrentSellerAddressPhone = "CurrentSellerAddressPhone";
			public const string CurrentSellerBankAccount = "CurrentSellerBankAccount";
			public const string CurrentBuyerName = "CurrentBuyerName";
			public const string CurrentBuyerTaxNumber = "CurrentBuyerTaxNumber";
			public const string CurrentBuyerAddressPhone = "CurrentBuyerAddressPhone";
			public const string CurrentBuyerBankAccount = "CurrentBuyerBankAccount";
			public const string ChequeCode = "ChequeCode";
			public const string ChequeCategory = "ChequeCategory";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"WriteDate" , "DateTime:"},
    			 {"WriteMan" , "string:"},
    			 {"DepartmentID" , "int:"},
    			 {"DepartmentFile" , "string:"},
    			 {"ProjectID" , "int:"},
    			 {"SellerID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"Remark" , "string:"},
    			 {"SignState" , "int:"},
    			 {"SignOperator" , "string:"},
    			 {"SignRemark" , "string:"},
    			 {"SignTime" , "DateTime:"},
    			 {"ApproveState" , "int:"},
    			 {"ApproveOperator" , "string:"},
    			 {"ApproveRemark" , "string:"},
    			 {"ApporveTime" , "DateTime:"},
    			 {"ChequeNumber" , "string:"},
    			 {"ChequeTime" , "DateTime:"},
    			 {"BuyerID" , "int:"},
    			 {"CurrentDepartmentName" , "string:"},
    			 {"CurrentProjectName" , "string:"},
    			 {"CurrentSellerName" , "string:"},
    			 {"CurrentSellerTaxNumber" , "string:"},
    			 {"CurrentSellerAddressPhone" , "string:"},
    			 {"CurrentSellerBankAccount" , "string:"},
    			 {"CurrentBuyerName" , "string:"},
    			 {"CurrentBuyerTaxNumber" , "string:"},
    			 {"CurrentBuyerAddressPhone" , "string:"},
    			 {"CurrentBuyerBankAccount" , "string:"},
    			 {"ChequeCode" , "string:"},
    			 {"ChequeCategory" , "string:"},
            };
		}
		#endregion
	}
}
