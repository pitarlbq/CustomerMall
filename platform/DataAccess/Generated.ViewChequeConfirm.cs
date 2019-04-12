using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Foresight.DataAccess.Framework;


namespace Foresight.DataAccess
{
	/// <summary>
	/// This object represents the properties and methods of a ViewChequeConfirm.
	/// </summary>
	[Serializable()]
	public partial class ViewChequeConfirm 
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
		[DataObjectField(false, false, true)]
		public int ID
		{
			[DebuggerStepThrough()]
			get { return this._iD; }
            protected set { this._iD = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _summaryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SummaryID
		{
			[DebuggerStepThrough()]
			get { return this._summaryID; }
            protected set { this._summaryID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _takeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime TakeTime
		{
			[DebuggerStepThrough()]
			get { return this._takeTime; }
            protected set { this._takeTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _takeUser = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TakeUser
		{
			[DebuggerStepThrough()]
			get { return this._takeUser; }
            protected set { this._takeUser = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _takeStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TakeStatus
		{
			[DebuggerStepThrough()]
			get { return this._takeStatus; }
            protected set { this._takeStatus = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _takeRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TakeRemark
		{
			[DebuggerStepThrough()]
			get { return this._takeRemark; }
            protected set { this._takeRemark = value;}
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
            protected set { this._approveTime = value;}
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
            protected set { this._approveMan = value;}
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
            protected set { this._approveStatus = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _checkApproveRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CheckApproveRemark
		{
			[DebuggerStepThrough()]
			get { return this._checkApproveRemark; }
            protected set { this._checkApproveRemark = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveMethod = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveMethod
		{
			[DebuggerStepThrough()]
			get { return this._approveMethod; }
            protected set { this._approveMethod = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _approveMonth = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ApproveMonth
		{
			[DebuggerStepThrough()]
			get { return this._approveMonth; }
            protected set { this._approveMonth = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _transferTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime TransferTime
		{
			[DebuggerStepThrough()]
			get { return this._transferTime; }
            protected set { this._transferTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _transferMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TransferMan
		{
			[DebuggerStepThrough()]
			get { return this._transferMan; }
            protected set { this._transferMan = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _transferRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TransferRemark
		{
			[DebuggerStepThrough()]
			get { return this._transferRemark; }
            protected set { this._transferRemark = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _transferStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TransferStatus
		{
			[DebuggerStepThrough()]
			get { return this._transferStatus; }
            protected set { this._transferStatus = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _transferMoney = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TransferMoney
		{
			[DebuggerStepThrough()]
			get { return this._transferMoney; }
            protected set { this._transferMoney = value;}
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
            protected set { this._writeDate = value;}
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
            protected set { this._writeMan = value;}
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
            protected set { this._departmentID = value;}
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
            protected set { this._departmentFile = value;}
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
            protected set { this._projectID = value;}
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
            protected set { this._sellerID = value;}
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
            protected set { this._addTime = value;}
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
            protected set { this._remark = value;}
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
            protected set { this._signState = value;}
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
            protected set { this._signOperator = value;}
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
            protected set { this._signRemark = value;}
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
            protected set { this._signTime = value;}
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
            protected set { this._approveState = value;}
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
            protected set { this._approveOperator = value;}
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
            protected set { this._approveRemark = value;}
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
            protected set { this._apporveTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _departmentName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DepartmentName
		{
			[DebuggerStepThrough()]
			get { return this._departmentName; }
            protected set { this._departmentName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _projectName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProjectName
		{
			[DebuggerStepThrough()]
			get { return this._projectName; }
            protected set { this._projectName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sellerName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SellerName
		{
			[DebuggerStepThrough()]
			get { return this._sellerName; }
            protected set { this._sellerName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sellerTaxNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SellerTaxNumber
		{
			[DebuggerStepThrough()]
			get { return this._sellerTaxNumber; }
            protected set { this._sellerTaxNumber = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sellerAddressPhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SellerAddressPhone
		{
			[DebuggerStepThrough()]
			get { return this._sellerAddressPhone; }
            protected set { this._sellerAddressPhone = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sellerBankAccount = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SellerBankAccount
		{
			[DebuggerStepThrough()]
			get { return this._sellerBankAccount; }
            protected set { this._sellerBankAccount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _productID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProductID
		{
			[DebuggerStepThrough()]
			get { return this._productID; }
            protected set { this._productID = value;}
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
            protected set { this._productName = value;}
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
            protected set { this._modelNumber = value;}
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
            protected set { this._unit = value;}
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
            protected set { this._unitPrice = value;}
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
            protected set { this._totalCount = value;}
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
            protected set { this._totalCost = value;}
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
            protected set { this._taxRate = value;}
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
            protected set { this._totalTaxCost = value;}
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
            protected set { this._totalSummaryCost = value;}
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
            protected set { this._gUID = value;}
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
            protected set { this._chequeNumber = value;}
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
            protected set { this._chequeTime = value;}
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
            protected set { this._buyerID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _buyerName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BuyerName
		{
			[DebuggerStepThrough()]
			get { return this._buyerName; }
            protected set { this._buyerName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _buyerTaxNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BuyerTaxNumber
		{
			[DebuggerStepThrough()]
			get { return this._buyerTaxNumber; }
            protected set { this._buyerTaxNumber = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _buyerBankAccount = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BuyerBankAccount
		{
			[DebuggerStepThrough()]
			get { return this._buyerBankAccount; }
            protected set { this._buyerBankAccount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _projectCategoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProjectCategoryName
		{
			[DebuggerStepThrough()]
			get { return this._projectCategoryName; }
            protected set { this._projectCategoryName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _departmentCategoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DepartmentCategoryName
		{
			[DebuggerStepThrough()]
			get { return this._departmentCategoryName; }
            protected set { this._departmentCategoryName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sellerCategoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SellerCategoryName
		{
			[DebuggerStepThrough()]
			get { return this._sellerCategoryName; }
            protected set { this._sellerCategoryName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _buyerCategoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BuyerCategoryName
		{
			[DebuggerStepThrough()]
			get { return this._buyerCategoryName; }
            protected set { this._buyerCategoryName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _productCategoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProductCategoryName
		{
			[DebuggerStepThrough()]
			get { return this._productCategoryName; }
            protected set { this._productCategoryName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _buyerAddressPhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BuyerAddressPhone
		{
			[DebuggerStepThrough()]
			get { return this._buyerAddressPhone; }
            protected set { this._buyerAddressPhone = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _projectCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProjectCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._projectCategoryID; }
            protected set { this._projectCategoryID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _departmentCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int DepartmentCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._departmentCategoryID; }
            protected set { this._departmentCategoryID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _sellerCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SellerCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._sellerCategoryID; }
            protected set { this._sellerCategoryID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _buyerCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int BuyerCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._buyerCategoryID; }
            protected set { this._buyerCategoryID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _productCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProductCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._productCategoryID; }
            protected set { this._productCategoryID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _detailID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int DetailID
		{
			[DebuggerStepThrough()]
			get { return this._detailID; }
            protected set { this._detailID = value;}
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
            protected set { this._chequeCode = value;}
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
            protected set { this._currentDepartmentName = value;}
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
            protected set { this._currentSellerName = value;}
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
            protected set { this._currentProjectName = value;}
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
            protected set { this._currentSellerTaxNumber = value;}
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
            protected set { this._currentSellerAddressPhone = value;}
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
            protected set { this._currentSellerBankAccount = value;}
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
            protected set { this._currentBuyerName = value;}
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
            protected set { this._currentBuyerTaxNumber = value;}
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
            protected set { this._currentBuyerAddressPhone = value;}
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
            protected set { this._currentBuyerBankAccount = value;}
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
            protected set { this._inSummaryID = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewChequeConfirm() { }
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
	[ViewChequeConfirm].[ID],
	[ViewChequeConfirm].[SummaryID],
	[ViewChequeConfirm].[TakeTime],
	[ViewChequeConfirm].[TakeUser],
	[ViewChequeConfirm].[TakeStatus],
	[ViewChequeConfirm].[TakeRemark],
	[ViewChequeConfirm].[ApproveTime],
	[ViewChequeConfirm].[ApproveMan],
	[ViewChequeConfirm].[ApproveStatus],
	[ViewChequeConfirm].[CheckApproveRemark],
	[ViewChequeConfirm].[ApproveMethod],
	[ViewChequeConfirm].[ApproveMonth],
	[ViewChequeConfirm].[TransferTime],
	[ViewChequeConfirm].[TransferMan],
	[ViewChequeConfirm].[TransferRemark],
	[ViewChequeConfirm].[TransferStatus],
	[ViewChequeConfirm].[TransferMoney],
	[ViewChequeConfirm].[WriteDate],
	[ViewChequeConfirm].[WriteMan],
	[ViewChequeConfirm].[DepartmentID],
	[ViewChequeConfirm].[DepartmentFile],
	[ViewChequeConfirm].[ProjectID],
	[ViewChequeConfirm].[SellerID],
	[ViewChequeConfirm].[AddTime],
	[ViewChequeConfirm].[Remark],
	[ViewChequeConfirm].[SignState],
	[ViewChequeConfirm].[SignOperator],
	[ViewChequeConfirm].[SignRemark],
	[ViewChequeConfirm].[SignTime],
	[ViewChequeConfirm].[ApproveState],
	[ViewChequeConfirm].[ApproveOperator],
	[ViewChequeConfirm].[ApproveRemark],
	[ViewChequeConfirm].[ApporveTime],
	[ViewChequeConfirm].[DepartmentName],
	[ViewChequeConfirm].[ProjectName],
	[ViewChequeConfirm].[SellerName],
	[ViewChequeConfirm].[SellerTaxNumber],
	[ViewChequeConfirm].[SellerAddressPhone],
	[ViewChequeConfirm].[SellerBankAccount],
	[ViewChequeConfirm].[ProductID],
	[ViewChequeConfirm].[ProductName],
	[ViewChequeConfirm].[ModelNumber],
	[ViewChequeConfirm].[Unit],
	[ViewChequeConfirm].[UnitPrice],
	[ViewChequeConfirm].[TotalCount],
	[ViewChequeConfirm].[TotalCost],
	[ViewChequeConfirm].[TaxRate],
	[ViewChequeConfirm].[TotalTaxCost],
	[ViewChequeConfirm].[TotalSummaryCost],
	[ViewChequeConfirm].[GUID],
	[ViewChequeConfirm].[ChequeNumber],
	[ViewChequeConfirm].[ChequeTime],
	[ViewChequeConfirm].[BuyerID],
	[ViewChequeConfirm].[BuyerName],
	[ViewChequeConfirm].[BuyerTaxNumber],
	[ViewChequeConfirm].[BuyerBankAccount],
	[ViewChequeConfirm].[ProjectCategoryName],
	[ViewChequeConfirm].[DepartmentCategoryName],
	[ViewChequeConfirm].[SellerCategoryName],
	[ViewChequeConfirm].[BuyerCategoryName],
	[ViewChequeConfirm].[ProductCategoryName],
	[ViewChequeConfirm].[BuyerAddressPhone],
	[ViewChequeConfirm].[ProjectCategoryID],
	[ViewChequeConfirm].[DepartmentCategoryID],
	[ViewChequeConfirm].[SellerCategoryID],
	[ViewChequeConfirm].[BuyerCategoryID],
	[ViewChequeConfirm].[ProductCategoryID],
	[ViewChequeConfirm].[DetailID],
	[ViewChequeConfirm].[ChequeCode],
	[ViewChequeConfirm].[CurrentDepartmentName],
	[ViewChequeConfirm].[CurrentSellerName],
	[ViewChequeConfirm].[CurrentProjectName],
	[ViewChequeConfirm].[CurrentSellerTaxNumber],
	[ViewChequeConfirm].[CurrentSellerAddressPhone],
	[ViewChequeConfirm].[CurrentSellerBankAccount],
	[ViewChequeConfirm].[CurrentBuyerName],
	[ViewChequeConfirm].[CurrentBuyerTaxNumber],
	[ViewChequeConfirm].[CurrentBuyerAddressPhone],
	[ViewChequeConfirm].[CurrentBuyerBankAccount],
	[ViewChequeConfirm].[InSummaryID]
";
			}
		}
		
		
		/// <summary>
        /// View Name
        /// </summary>
        public static string ViewName
        {
            get
            {
                return "ViewChequeConfirm";
            }
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
		
		#region Static Methods
				
		/// <summary>
		/// Gets a collection ViewChequeConfirm objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewChequeConfirm objects.</returns>
		public static EntityList<ViewChequeConfirm> GetViewChequeConfirms()
		{
			string commandText = @"
SELECT " + ViewChequeConfirm.SelectFieldList + "FROM [dbo].[ViewChequeConfirm] " + ViewChequeConfirm.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewChequeConfirm>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewChequeConfirm objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewChequeConfirm objects.</returns>
        public static EntityList<ViewChequeConfirm> GetViewChequeConfirms(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewChequeConfirm>(SelectFieldList, "FROM [dbo].[ViewChequeConfirm]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewChequeConfirm objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewChequeConfirm objects.</returns>
        public static EntityList<ViewChequeConfirm> GetViewChequeConfirms(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewChequeConfirm>(SelectFieldList, "FROM [dbo].[ViewChequeConfirm]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewChequeConfirm objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewChequeConfirmCount()
        {
            return GetViewChequeConfirmCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewChequeConfirm objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewChequeConfirmCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewChequeConfirm] " + where;

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
		
		/// <summary>
		/// Gets a collection ViewChequeConfirm objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewChequeConfirm objects.</returns>
		protected static EntityList<ViewChequeConfirm> GetViewChequeConfirms(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewChequeConfirms(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewChequeConfirm objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewChequeConfirm objects.</returns>
		protected static EntityList<ViewChequeConfirm> GetViewChequeConfirms(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewChequeConfirms(string.Empty, where, parameters, ViewChequeConfirm.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewChequeConfirm objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewChequeConfirm objects.</returns>
		protected static EntityList<ViewChequeConfirm> GetViewChequeConfirms(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewChequeConfirms(prefix, where, parameters, ViewChequeConfirm.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewChequeConfirm objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewChequeConfirm objects.</returns>
		protected static EntityList<ViewChequeConfirm> GetViewChequeConfirms(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewChequeConfirms(string.Empty, where, parameters, ViewChequeConfirm.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewChequeConfirm objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewChequeConfirm objects.</returns>
		protected static EntityList<ViewChequeConfirm> GetViewChequeConfirms(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewChequeConfirms(prefix, where, parameters, ViewChequeConfirm.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewChequeConfirm objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewChequeConfirm objects.</returns>
		protected static EntityList<ViewChequeConfirm> GetViewChequeConfirms(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewChequeConfirm.SelectFieldList + "FROM [dbo].[ViewChequeConfirm] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewChequeConfirm>(reader);
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
        protected static EntityList<ViewChequeConfirm> GetViewChequeConfirms(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewChequeConfirm>(SelectFieldList, "FROM [dbo].[ViewChequeConfirm] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewChequeConfirmProperties
		{
			public const string ID = "ID";
			public const string SummaryID = "SummaryID";
			public const string TakeTime = "TakeTime";
			public const string TakeUser = "TakeUser";
			public const string TakeStatus = "TakeStatus";
			public const string TakeRemark = "TakeRemark";
			public const string ApproveTime = "ApproveTime";
			public const string ApproveMan = "ApproveMan";
			public const string ApproveStatus = "ApproveStatus";
			public const string CheckApproveRemark = "CheckApproveRemark";
			public const string ApproveMethod = "ApproveMethod";
			public const string ApproveMonth = "ApproveMonth";
			public const string TransferTime = "TransferTime";
			public const string TransferMan = "TransferMan";
			public const string TransferRemark = "TransferRemark";
			public const string TransferStatus = "TransferStatus";
			public const string TransferMoney = "TransferMoney";
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
			public const string DepartmentName = "DepartmentName";
			public const string ProjectName = "ProjectName";
			public const string SellerName = "SellerName";
			public const string SellerTaxNumber = "SellerTaxNumber";
			public const string SellerAddressPhone = "SellerAddressPhone";
			public const string SellerBankAccount = "SellerBankAccount";
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
			public const string ChequeNumber = "ChequeNumber";
			public const string ChequeTime = "ChequeTime";
			public const string BuyerID = "BuyerID";
			public const string BuyerName = "BuyerName";
			public const string BuyerTaxNumber = "BuyerTaxNumber";
			public const string BuyerBankAccount = "BuyerBankAccount";
			public const string ProjectCategoryName = "ProjectCategoryName";
			public const string DepartmentCategoryName = "DepartmentCategoryName";
			public const string SellerCategoryName = "SellerCategoryName";
			public const string BuyerCategoryName = "BuyerCategoryName";
			public const string ProductCategoryName = "ProductCategoryName";
			public const string BuyerAddressPhone = "BuyerAddressPhone";
			public const string ProjectCategoryID = "ProjectCategoryID";
			public const string DepartmentCategoryID = "DepartmentCategoryID";
			public const string SellerCategoryID = "SellerCategoryID";
			public const string BuyerCategoryID = "BuyerCategoryID";
			public const string ProductCategoryID = "ProductCategoryID";
			public const string DetailID = "DetailID";
			public const string ChequeCode = "ChequeCode";
			public const string CurrentDepartmentName = "CurrentDepartmentName";
			public const string CurrentSellerName = "CurrentSellerName";
			public const string CurrentProjectName = "CurrentProjectName";
			public const string CurrentSellerTaxNumber = "CurrentSellerTaxNumber";
			public const string CurrentSellerAddressPhone = "CurrentSellerAddressPhone";
			public const string CurrentSellerBankAccount = "CurrentSellerBankAccount";
			public const string CurrentBuyerName = "CurrentBuyerName";
			public const string CurrentBuyerTaxNumber = "CurrentBuyerTaxNumber";
			public const string CurrentBuyerAddressPhone = "CurrentBuyerAddressPhone";
			public const string CurrentBuyerBankAccount = "CurrentBuyerBankAccount";
			public const string InSummaryID = "InSummaryID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"SummaryID" , "int:"},
    			 {"TakeTime" , "DateTime:"},
    			 {"TakeUser" , "string:"},
    			 {"TakeStatus" , "int:"},
    			 {"TakeRemark" , "string:"},
    			 {"ApproveTime" , "DateTime:"},
    			 {"ApproveMan" , "string:"},
    			 {"ApproveStatus" , "int:"},
    			 {"CheckApproveRemark" , "string:"},
    			 {"ApproveMethod" , "string:"},
    			 {"ApproveMonth" , "string:"},
    			 {"TransferTime" , "DateTime:"},
    			 {"TransferMan" , "string:"},
    			 {"TransferRemark" , "string:"},
    			 {"TransferStatus" , "int:"},
    			 {"TransferMoney" , "decimal:"},
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
    			 {"DepartmentName" , "string:"},
    			 {"ProjectName" , "string:"},
    			 {"SellerName" , "string:"},
    			 {"SellerTaxNumber" , "string:"},
    			 {"SellerAddressPhone" , "string:"},
    			 {"SellerBankAccount" , "string:"},
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
    			 {"ChequeNumber" , "string:"},
    			 {"ChequeTime" , "DateTime:"},
    			 {"BuyerID" , "int:"},
    			 {"BuyerName" , "string:"},
    			 {"BuyerTaxNumber" , "string:"},
    			 {"BuyerBankAccount" , "string:"},
    			 {"ProjectCategoryName" , "string:"},
    			 {"DepartmentCategoryName" , "string:"},
    			 {"SellerCategoryName" , "string:"},
    			 {"BuyerCategoryName" , "string:"},
    			 {"ProductCategoryName" , "string:"},
    			 {"BuyerAddressPhone" , "string:"},
    			 {"ProjectCategoryID" , "int:"},
    			 {"DepartmentCategoryID" , "int:"},
    			 {"SellerCategoryID" , "int:"},
    			 {"BuyerCategoryID" , "int:"},
    			 {"ProductCategoryID" , "int:"},
    			 {"DetailID" , "int:"},
    			 {"ChequeCode" , "string:"},
    			 {"CurrentDepartmentName" , "string:"},
    			 {"CurrentSellerName" , "string:"},
    			 {"CurrentProjectName" , "string:"},
    			 {"CurrentSellerTaxNumber" , "string:"},
    			 {"CurrentSellerAddressPhone" , "string:"},
    			 {"CurrentSellerBankAccount" , "string:"},
    			 {"CurrentBuyerName" , "string:"},
    			 {"CurrentBuyerTaxNumber" , "string:"},
    			 {"CurrentBuyerAddressPhone" , "string:"},
    			 {"CurrentBuyerBankAccount" , "string:"},
    			 {"InSummaryID" , "int:"},
            };
		}
		#endregion
	}
}
