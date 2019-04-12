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
	/// This object represents the properties and methods of a InsideCustomer.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class InsideCustomer 
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
		private string _customerName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CustomerName
		{
			[DebuggerStepThrough()]
			get { return this._customerName; }
			set 
			{
				if (this._customerName != value) 
				{
					this._customerName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CustomerName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _industryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string IndustryName
		{
			[DebuggerStepThrough()]
			get { return this._industryName; }
			set 
			{
				if (this._industryName != value) 
				{
					this._industryName = value;
					this.IsDirty = true;	
					OnPropertyChanged("IndustryName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _categoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CategoryName
		{
			[DebuggerStepThrough()]
			get { return this._categoryName; }
			set 
			{
				if (this._categoryName != value) 
				{
					this._categoryName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CategoryName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _interesting = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Interesting
		{
			[DebuggerStepThrough()]
			get { return this._interesting; }
			set 
			{
				if (this._interesting != value) 
				{
					this._interesting = value;
					this.IsDirty = true;	
					OnPropertyChanged("Interesting");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contactMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContactMan
		{
			[DebuggerStepThrough()]
			get { return this._contactMan; }
			set 
			{
				if (this._contactMan != value) 
				{
					this._contactMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContactMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contactPhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContactPhone
		{
			[DebuggerStepThrough()]
			get { return this._contactPhone; }
			set 
			{
				if (this._contactPhone != value) 
				{
					this._contactPhone = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContactPhone");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _qQNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string QQNo
		{
			[DebuggerStepThrough()]
			get { return this._qQNo; }
			set 
			{
				if (this._qQNo != value) 
				{
					this._qQNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("QQNo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _qQGroupInvitation = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string QQGroupInvitation
		{
			[DebuggerStepThrough()]
			get { return this._qQGroupInvitation; }
			set 
			{
				if (this._qQGroupInvitation != value) 
				{
					this._qQGroupInvitation = value;
					this.IsDirty = true;	
					OnPropertyChanged("QQGroupInvitation");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _wechatNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string WechatNo
		{
			[DebuggerStepThrough()]
			get { return this._wechatNo; }
			set 
			{
				if (this._wechatNo != value) 
				{
					this._wechatNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("WechatNo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _wechaGroupInvitation = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string WechaGroupInvitation
		{
			[DebuggerStepThrough()]
			get { return this._wechaGroupInvitation; }
			set 
			{
				if (this._wechaGroupInvitation != value) 
				{
					this._wechaGroupInvitation = value;
					this.IsDirty = true;	
					OnPropertyChanged("WechaGroupInvitation");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _otherContactMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OtherContactMan
		{
			[DebuggerStepThrough()]
			get { return this._otherContactMan; }
			set 
			{
				if (this._otherContactMan != value) 
				{
					this._otherContactMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("OtherContactMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _customerBelonger = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CustomerBelonger
		{
			[DebuggerStepThrough()]
			get { return this._customerBelonger; }
			set 
			{
				if (this._customerBelonger != value) 
				{
					this._customerBelonger = value;
					this.IsDirty = true;	
					OnPropertyChanged("CustomerBelonger");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _newFollowup = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string NewFollowup
		{
			[DebuggerStepThrough()]
			get { return this._newFollowup; }
			set 
			{
				if (this._newFollowup != value) 
				{
					this._newFollowup = value;
					this.IsDirty = true;	
					OnPropertyChanged("NewFollowup");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _newFollowupDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime NewFollowupDate
		{
			[DebuggerStepThrough()]
			get { return this._newFollowupDate; }
			set 
			{
				if (this._newFollowupDate != value) 
				{
					this._newFollowupDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("NewFollowupDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _region = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Region
		{
			[DebuggerStepThrough()]
			get { return this._region; }
			set 
			{
				if (this._region != value) 
				{
					this._region = value;
					this.IsDirty = true;	
					OnPropertyChanged("Region");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _province = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Province
		{
			[DebuggerStepThrough()]
			get { return this._province; }
			set 
			{
				if (this._province != value) 
				{
					this._province = value;
					this.IsDirty = true;	
					OnPropertyChanged("Province");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _city = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string City
		{
			[DebuggerStepThrough()]
			get { return this._city; }
			set 
			{
				if (this._city != value) 
				{
					this._city = value;
					this.IsDirty = true;	
					OnPropertyChanged("City");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _businessStage = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BusinessStage
		{
			[DebuggerStepThrough()]
			get { return this._businessStage; }
			set 
			{
				if (this._businessStage != value) 
				{
					this._businessStage = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessStage");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _cost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal Cost
		{
			[DebuggerStepThrough()]
			get { return this._cost; }
			set 
			{
				if (this._cost != value) 
				{
					this._cost = value;
					this.IsDirty = true;	
					OnPropertyChanged("Cost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _dealProbably = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DealProbably
		{
			[DebuggerStepThrough()]
			get { return this._dealProbably; }
			set 
			{
				if (this._dealProbably != value) 
				{
					this._dealProbably = value;
					this.IsDirty = true;	
					OnPropertyChanged("DealProbably");
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
	[CustomerName] nvarchar(200),
	[IndustryName] nvarchar(200),
	[CategoryName] nvarchar(200),
	[Interesting] nvarchar(200),
	[ContactMan] nvarchar(200),
	[ContactPhone] nvarchar(200),
	[QQNo] nvarchar(200),
	[QQGroupInvitation] nvarchar(200),
	[WechatNo] nvarchar(200),
	[WechaGroupInvitation] nvarchar(200),
	[OtherContactMan] nvarchar(200),
	[CustomerBelonger] nvarchar(200),
	[NewFollowup] ntext,
	[NewFollowupDate] datetime,
	[Region] nvarchar(200),
	[Province] nvarchar(200),
	[City] nvarchar(200),
	[BusinessStage] nvarchar(200),
	[Cost] decimal(18, 2),
	[DealProbably] nvarchar(200),
	[Remark] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

INSERT INTO [dbo].[InsideCustomer] (
	[InsideCustomer].[CustomerName],
	[InsideCustomer].[IndustryName],
	[InsideCustomer].[CategoryName],
	[InsideCustomer].[Interesting],
	[InsideCustomer].[ContactMan],
	[InsideCustomer].[ContactPhone],
	[InsideCustomer].[QQNo],
	[InsideCustomer].[QQGroupInvitation],
	[InsideCustomer].[WechatNo],
	[InsideCustomer].[WechaGroupInvitation],
	[InsideCustomer].[OtherContactMan],
	[InsideCustomer].[CustomerBelonger],
	[InsideCustomer].[NewFollowup],
	[InsideCustomer].[NewFollowupDate],
	[InsideCustomer].[Region],
	[InsideCustomer].[Province],
	[InsideCustomer].[City],
	[InsideCustomer].[BusinessStage],
	[InsideCustomer].[Cost],
	[InsideCustomer].[DealProbably],
	[InsideCustomer].[Remark],
	[InsideCustomer].[AddTime],
	[InsideCustomer].[AddMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[CustomerName],
	INSERTED.[IndustryName],
	INSERTED.[CategoryName],
	INSERTED.[Interesting],
	INSERTED.[ContactMan],
	INSERTED.[ContactPhone],
	INSERTED.[QQNo],
	INSERTED.[QQGroupInvitation],
	INSERTED.[WechatNo],
	INSERTED.[WechaGroupInvitation],
	INSERTED.[OtherContactMan],
	INSERTED.[CustomerBelonger],
	INSERTED.[NewFollowup],
	INSERTED.[NewFollowupDate],
	INSERTED.[Region],
	INSERTED.[Province],
	INSERTED.[City],
	INSERTED.[BusinessStage],
	INSERTED.[Cost],
	INSERTED.[DealProbably],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
VALUES ( 
	@CustomerName,
	@IndustryName,
	@CategoryName,
	@Interesting,
	@ContactMan,
	@ContactPhone,
	@QQNo,
	@QQGroupInvitation,
	@WechatNo,
	@WechaGroupInvitation,
	@OtherContactMan,
	@CustomerBelonger,
	@NewFollowup,
	@NewFollowupDate,
	@Region,
	@Province,
	@City,
	@BusinessStage,
	@Cost,
	@DealProbably,
	@Remark,
	@AddTime,
	@AddMan 
); 

SELECT 
	[ID],
	[CustomerName],
	[IndustryName],
	[CategoryName],
	[Interesting],
	[ContactMan],
	[ContactPhone],
	[QQNo],
	[QQGroupInvitation],
	[WechatNo],
	[WechaGroupInvitation],
	[OtherContactMan],
	[CustomerBelonger],
	[NewFollowup],
	[NewFollowupDate],
	[Region],
	[Province],
	[City],
	[BusinessStage],
	[Cost],
	[DealProbably],
	[Remark],
	[AddTime],
	[AddMan] 
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
	[CustomerName] nvarchar(200),
	[IndustryName] nvarchar(200),
	[CategoryName] nvarchar(200),
	[Interesting] nvarchar(200),
	[ContactMan] nvarchar(200),
	[ContactPhone] nvarchar(200),
	[QQNo] nvarchar(200),
	[QQGroupInvitation] nvarchar(200),
	[WechatNo] nvarchar(200),
	[WechaGroupInvitation] nvarchar(200),
	[OtherContactMan] nvarchar(200),
	[CustomerBelonger] nvarchar(200),
	[NewFollowup] ntext,
	[NewFollowupDate] datetime,
	[Region] nvarchar(200),
	[Province] nvarchar(200),
	[City] nvarchar(200),
	[BusinessStage] nvarchar(200),
	[Cost] decimal(18, 2),
	[DealProbably] nvarchar(200),
	[Remark] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

UPDATE [dbo].[InsideCustomer] SET 
	[InsideCustomer].[CustomerName] = @CustomerName,
	[InsideCustomer].[IndustryName] = @IndustryName,
	[InsideCustomer].[CategoryName] = @CategoryName,
	[InsideCustomer].[Interesting] = @Interesting,
	[InsideCustomer].[ContactMan] = @ContactMan,
	[InsideCustomer].[ContactPhone] = @ContactPhone,
	[InsideCustomer].[QQNo] = @QQNo,
	[InsideCustomer].[QQGroupInvitation] = @QQGroupInvitation,
	[InsideCustomer].[WechatNo] = @WechatNo,
	[InsideCustomer].[WechaGroupInvitation] = @WechaGroupInvitation,
	[InsideCustomer].[OtherContactMan] = @OtherContactMan,
	[InsideCustomer].[CustomerBelonger] = @CustomerBelonger,
	[InsideCustomer].[NewFollowup] = @NewFollowup,
	[InsideCustomer].[NewFollowupDate] = @NewFollowupDate,
	[InsideCustomer].[Region] = @Region,
	[InsideCustomer].[Province] = @Province,
	[InsideCustomer].[City] = @City,
	[InsideCustomer].[BusinessStage] = @BusinessStage,
	[InsideCustomer].[Cost] = @Cost,
	[InsideCustomer].[DealProbably] = @DealProbably,
	[InsideCustomer].[Remark] = @Remark,
	[InsideCustomer].[AddTime] = @AddTime,
	[InsideCustomer].[AddMan] = @AddMan 
output 
	INSERTED.[ID],
	INSERTED.[CustomerName],
	INSERTED.[IndustryName],
	INSERTED.[CategoryName],
	INSERTED.[Interesting],
	INSERTED.[ContactMan],
	INSERTED.[ContactPhone],
	INSERTED.[QQNo],
	INSERTED.[QQGroupInvitation],
	INSERTED.[WechatNo],
	INSERTED.[WechaGroupInvitation],
	INSERTED.[OtherContactMan],
	INSERTED.[CustomerBelonger],
	INSERTED.[NewFollowup],
	INSERTED.[NewFollowupDate],
	INSERTED.[Region],
	INSERTED.[Province],
	INSERTED.[City],
	INSERTED.[BusinessStage],
	INSERTED.[Cost],
	INSERTED.[DealProbably],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
WHERE 
	[InsideCustomer].[ID] = @ID

SELECT 
	[ID],
	[CustomerName],
	[IndustryName],
	[CategoryName],
	[Interesting],
	[ContactMan],
	[ContactPhone],
	[QQNo],
	[QQGroupInvitation],
	[WechatNo],
	[WechaGroupInvitation],
	[OtherContactMan],
	[CustomerBelonger],
	[NewFollowup],
	[NewFollowupDate],
	[Region],
	[Province],
	[City],
	[BusinessStage],
	[Cost],
	[DealProbably],
	[Remark],
	[AddTime],
	[AddMan] 
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
DELETE FROM [dbo].[InsideCustomer]
WHERE 
	[InsideCustomer].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public InsideCustomer() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetInsideCustomer(this.ID));
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
	[InsideCustomer].[ID],
	[InsideCustomer].[CustomerName],
	[InsideCustomer].[IndustryName],
	[InsideCustomer].[CategoryName],
	[InsideCustomer].[Interesting],
	[InsideCustomer].[ContactMan],
	[InsideCustomer].[ContactPhone],
	[InsideCustomer].[QQNo],
	[InsideCustomer].[QQGroupInvitation],
	[InsideCustomer].[WechatNo],
	[InsideCustomer].[WechaGroupInvitation],
	[InsideCustomer].[OtherContactMan],
	[InsideCustomer].[CustomerBelonger],
	[InsideCustomer].[NewFollowup],
	[InsideCustomer].[NewFollowupDate],
	[InsideCustomer].[Region],
	[InsideCustomer].[Province],
	[InsideCustomer].[City],
	[InsideCustomer].[BusinessStage],
	[InsideCustomer].[Cost],
	[InsideCustomer].[DealProbably],
	[InsideCustomer].[Remark],
	[InsideCustomer].[AddTime],
	[InsideCustomer].[AddMan]
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
                return "InsideCustomer";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a InsideCustomer into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="customerName">customerName</param>
		/// <param name="industryName">industryName</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="interesting">interesting</param>
		/// <param name="contactMan">contactMan</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="qQNo">qQNo</param>
		/// <param name="qQGroupInvitation">qQGroupInvitation</param>
		/// <param name="wechatNo">wechatNo</param>
		/// <param name="wechaGroupInvitation">wechaGroupInvitation</param>
		/// <param name="otherContactMan">otherContactMan</param>
		/// <param name="customerBelonger">customerBelonger</param>
		/// <param name="newFollowup">newFollowup</param>
		/// <param name="newFollowupDate">newFollowupDate</param>
		/// <param name="region">region</param>
		/// <param name="province">province</param>
		/// <param name="city">city</param>
		/// <param name="businessStage">businessStage</param>
		/// <param name="cost">cost</param>
		/// <param name="dealProbably">dealProbably</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		public static void InsertInsideCustomer(string @customerName, string @industryName, string @categoryName, string @interesting, string @contactMan, string @contactPhone, string @qQNo, string @qQGroupInvitation, string @wechatNo, string @wechaGroupInvitation, string @otherContactMan, string @customerBelonger, string @newFollowup, DateTime @newFollowupDate, string @region, string @province, string @city, string @businessStage, decimal @cost, string @dealProbably, string @remark, DateTime @addTime, string @addMan)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertInsideCustomer(@customerName, @industryName, @categoryName, @interesting, @contactMan, @contactPhone, @qQNo, @qQGroupInvitation, @wechatNo, @wechaGroupInvitation, @otherContactMan, @customerBelonger, @newFollowup, @newFollowupDate, @region, @province, @city, @businessStage, @cost, @dealProbably, @remark, @addTime, @addMan, helper);
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
		/// Insert a InsideCustomer into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="customerName">customerName</param>
		/// <param name="industryName">industryName</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="interesting">interesting</param>
		/// <param name="contactMan">contactMan</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="qQNo">qQNo</param>
		/// <param name="qQGroupInvitation">qQGroupInvitation</param>
		/// <param name="wechatNo">wechatNo</param>
		/// <param name="wechaGroupInvitation">wechaGroupInvitation</param>
		/// <param name="otherContactMan">otherContactMan</param>
		/// <param name="customerBelonger">customerBelonger</param>
		/// <param name="newFollowup">newFollowup</param>
		/// <param name="newFollowupDate">newFollowupDate</param>
		/// <param name="region">region</param>
		/// <param name="province">province</param>
		/// <param name="city">city</param>
		/// <param name="businessStage">businessStage</param>
		/// <param name="cost">cost</param>
		/// <param name="dealProbably">dealProbably</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="helper">helper</param>
		internal static void InsertInsideCustomer(string @customerName, string @industryName, string @categoryName, string @interesting, string @contactMan, string @contactPhone, string @qQNo, string @qQGroupInvitation, string @wechatNo, string @wechaGroupInvitation, string @otherContactMan, string @customerBelonger, string @newFollowup, DateTime @newFollowupDate, string @region, string @province, string @city, string @businessStage, decimal @cost, string @dealProbably, string @remark, DateTime @addTime, string @addMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CustomerName] nvarchar(200),
	[IndustryName] nvarchar(200),
	[CategoryName] nvarchar(200),
	[Interesting] nvarchar(200),
	[ContactMan] nvarchar(200),
	[ContactPhone] nvarchar(200),
	[QQNo] nvarchar(200),
	[QQGroupInvitation] nvarchar(200),
	[WechatNo] nvarchar(200),
	[WechaGroupInvitation] nvarchar(200),
	[OtherContactMan] nvarchar(200),
	[CustomerBelonger] nvarchar(200),
	[NewFollowup] ntext,
	[NewFollowupDate] datetime,
	[Region] nvarchar(200),
	[Province] nvarchar(200),
	[City] nvarchar(200),
	[BusinessStage] nvarchar(200),
	[Cost] decimal(18, 2),
	[DealProbably] nvarchar(200),
	[Remark] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

INSERT INTO [dbo].[InsideCustomer] (
	[InsideCustomer].[CustomerName],
	[InsideCustomer].[IndustryName],
	[InsideCustomer].[CategoryName],
	[InsideCustomer].[Interesting],
	[InsideCustomer].[ContactMan],
	[InsideCustomer].[ContactPhone],
	[InsideCustomer].[QQNo],
	[InsideCustomer].[QQGroupInvitation],
	[InsideCustomer].[WechatNo],
	[InsideCustomer].[WechaGroupInvitation],
	[InsideCustomer].[OtherContactMan],
	[InsideCustomer].[CustomerBelonger],
	[InsideCustomer].[NewFollowup],
	[InsideCustomer].[NewFollowupDate],
	[InsideCustomer].[Region],
	[InsideCustomer].[Province],
	[InsideCustomer].[City],
	[InsideCustomer].[BusinessStage],
	[InsideCustomer].[Cost],
	[InsideCustomer].[DealProbably],
	[InsideCustomer].[Remark],
	[InsideCustomer].[AddTime],
	[InsideCustomer].[AddMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[CustomerName],
	INSERTED.[IndustryName],
	INSERTED.[CategoryName],
	INSERTED.[Interesting],
	INSERTED.[ContactMan],
	INSERTED.[ContactPhone],
	INSERTED.[QQNo],
	INSERTED.[QQGroupInvitation],
	INSERTED.[WechatNo],
	INSERTED.[WechaGroupInvitation],
	INSERTED.[OtherContactMan],
	INSERTED.[CustomerBelonger],
	INSERTED.[NewFollowup],
	INSERTED.[NewFollowupDate],
	INSERTED.[Region],
	INSERTED.[Province],
	INSERTED.[City],
	INSERTED.[BusinessStage],
	INSERTED.[Cost],
	INSERTED.[DealProbably],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
VALUES ( 
	@CustomerName,
	@IndustryName,
	@CategoryName,
	@Interesting,
	@ContactMan,
	@ContactPhone,
	@QQNo,
	@QQGroupInvitation,
	@WechatNo,
	@WechaGroupInvitation,
	@OtherContactMan,
	@CustomerBelonger,
	@NewFollowup,
	@NewFollowupDate,
	@Region,
	@Province,
	@City,
	@BusinessStage,
	@Cost,
	@DealProbably,
	@Remark,
	@AddTime,
	@AddMan 
); 

SELECT 
	[ID],
	[CustomerName],
	[IndustryName],
	[CategoryName],
	[Interesting],
	[ContactMan],
	[ContactPhone],
	[QQNo],
	[QQGroupInvitation],
	[WechatNo],
	[WechaGroupInvitation],
	[OtherContactMan],
	[CustomerBelonger],
	[NewFollowup],
	[NewFollowupDate],
	[Region],
	[Province],
	[City],
	[BusinessStage],
	[Cost],
	[DealProbably],
	[Remark],
	[AddTime],
	[AddMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CustomerName", EntityBase.GetDatabaseValue(@customerName)));
			parameters.Add(new SqlParameter("@IndustryName", EntityBase.GetDatabaseValue(@industryName)));
			parameters.Add(new SqlParameter("@CategoryName", EntityBase.GetDatabaseValue(@categoryName)));
			parameters.Add(new SqlParameter("@Interesting", EntityBase.GetDatabaseValue(@interesting)));
			parameters.Add(new SqlParameter("@ContactMan", EntityBase.GetDatabaseValue(@contactMan)));
			parameters.Add(new SqlParameter("@ContactPhone", EntityBase.GetDatabaseValue(@contactPhone)));
			parameters.Add(new SqlParameter("@QQNo", EntityBase.GetDatabaseValue(@qQNo)));
			parameters.Add(new SqlParameter("@QQGroupInvitation", EntityBase.GetDatabaseValue(@qQGroupInvitation)));
			parameters.Add(new SqlParameter("@WechatNo", EntityBase.GetDatabaseValue(@wechatNo)));
			parameters.Add(new SqlParameter("@WechaGroupInvitation", EntityBase.GetDatabaseValue(@wechaGroupInvitation)));
			parameters.Add(new SqlParameter("@OtherContactMan", EntityBase.GetDatabaseValue(@otherContactMan)));
			parameters.Add(new SqlParameter("@CustomerBelonger", EntityBase.GetDatabaseValue(@customerBelonger)));
			parameters.Add(new SqlParameter("@NewFollowup", EntityBase.GetDatabaseValue(@newFollowup)));
			parameters.Add(new SqlParameter("@NewFollowupDate", EntityBase.GetDatabaseValue(@newFollowupDate)));
			parameters.Add(new SqlParameter("@Region", EntityBase.GetDatabaseValue(@region)));
			parameters.Add(new SqlParameter("@Province", EntityBase.GetDatabaseValue(@province)));
			parameters.Add(new SqlParameter("@City", EntityBase.GetDatabaseValue(@city)));
			parameters.Add(new SqlParameter("@BusinessStage", EntityBase.GetDatabaseValue(@businessStage)));
			parameters.Add(new SqlParameter("@Cost", EntityBase.GetDatabaseValue(@cost)));
			parameters.Add(new SqlParameter("@DealProbably", EntityBase.GetDatabaseValue(@dealProbably)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a InsideCustomer into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="customerName">customerName</param>
		/// <param name="industryName">industryName</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="interesting">interesting</param>
		/// <param name="contactMan">contactMan</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="qQNo">qQNo</param>
		/// <param name="qQGroupInvitation">qQGroupInvitation</param>
		/// <param name="wechatNo">wechatNo</param>
		/// <param name="wechaGroupInvitation">wechaGroupInvitation</param>
		/// <param name="otherContactMan">otherContactMan</param>
		/// <param name="customerBelonger">customerBelonger</param>
		/// <param name="newFollowup">newFollowup</param>
		/// <param name="newFollowupDate">newFollowupDate</param>
		/// <param name="region">region</param>
		/// <param name="province">province</param>
		/// <param name="city">city</param>
		/// <param name="businessStage">businessStage</param>
		/// <param name="cost">cost</param>
		/// <param name="dealProbably">dealProbably</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		public static void UpdateInsideCustomer(int @iD, string @customerName, string @industryName, string @categoryName, string @interesting, string @contactMan, string @contactPhone, string @qQNo, string @qQGroupInvitation, string @wechatNo, string @wechaGroupInvitation, string @otherContactMan, string @customerBelonger, string @newFollowup, DateTime @newFollowupDate, string @region, string @province, string @city, string @businessStage, decimal @cost, string @dealProbably, string @remark, DateTime @addTime, string @addMan)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateInsideCustomer(@iD, @customerName, @industryName, @categoryName, @interesting, @contactMan, @contactPhone, @qQNo, @qQGroupInvitation, @wechatNo, @wechaGroupInvitation, @otherContactMan, @customerBelonger, @newFollowup, @newFollowupDate, @region, @province, @city, @businessStage, @cost, @dealProbably, @remark, @addTime, @addMan, helper);
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
		/// Updates a InsideCustomer into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="customerName">customerName</param>
		/// <param name="industryName">industryName</param>
		/// <param name="categoryName">categoryName</param>
		/// <param name="interesting">interesting</param>
		/// <param name="contactMan">contactMan</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="qQNo">qQNo</param>
		/// <param name="qQGroupInvitation">qQGroupInvitation</param>
		/// <param name="wechatNo">wechatNo</param>
		/// <param name="wechaGroupInvitation">wechaGroupInvitation</param>
		/// <param name="otherContactMan">otherContactMan</param>
		/// <param name="customerBelonger">customerBelonger</param>
		/// <param name="newFollowup">newFollowup</param>
		/// <param name="newFollowupDate">newFollowupDate</param>
		/// <param name="region">region</param>
		/// <param name="province">province</param>
		/// <param name="city">city</param>
		/// <param name="businessStage">businessStage</param>
		/// <param name="cost">cost</param>
		/// <param name="dealProbably">dealProbably</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="helper">helper</param>
		internal static void UpdateInsideCustomer(int @iD, string @customerName, string @industryName, string @categoryName, string @interesting, string @contactMan, string @contactPhone, string @qQNo, string @qQGroupInvitation, string @wechatNo, string @wechaGroupInvitation, string @otherContactMan, string @customerBelonger, string @newFollowup, DateTime @newFollowupDate, string @region, string @province, string @city, string @businessStage, decimal @cost, string @dealProbably, string @remark, DateTime @addTime, string @addMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CustomerName] nvarchar(200),
	[IndustryName] nvarchar(200),
	[CategoryName] nvarchar(200),
	[Interesting] nvarchar(200),
	[ContactMan] nvarchar(200),
	[ContactPhone] nvarchar(200),
	[QQNo] nvarchar(200),
	[QQGroupInvitation] nvarchar(200),
	[WechatNo] nvarchar(200),
	[WechaGroupInvitation] nvarchar(200),
	[OtherContactMan] nvarchar(200),
	[CustomerBelonger] nvarchar(200),
	[NewFollowup] ntext,
	[NewFollowupDate] datetime,
	[Region] nvarchar(200),
	[Province] nvarchar(200),
	[City] nvarchar(200),
	[BusinessStage] nvarchar(200),
	[Cost] decimal(18, 2),
	[DealProbably] nvarchar(200),
	[Remark] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

UPDATE [dbo].[InsideCustomer] SET 
	[InsideCustomer].[CustomerName] = @CustomerName,
	[InsideCustomer].[IndustryName] = @IndustryName,
	[InsideCustomer].[CategoryName] = @CategoryName,
	[InsideCustomer].[Interesting] = @Interesting,
	[InsideCustomer].[ContactMan] = @ContactMan,
	[InsideCustomer].[ContactPhone] = @ContactPhone,
	[InsideCustomer].[QQNo] = @QQNo,
	[InsideCustomer].[QQGroupInvitation] = @QQGroupInvitation,
	[InsideCustomer].[WechatNo] = @WechatNo,
	[InsideCustomer].[WechaGroupInvitation] = @WechaGroupInvitation,
	[InsideCustomer].[OtherContactMan] = @OtherContactMan,
	[InsideCustomer].[CustomerBelonger] = @CustomerBelonger,
	[InsideCustomer].[NewFollowup] = @NewFollowup,
	[InsideCustomer].[NewFollowupDate] = @NewFollowupDate,
	[InsideCustomer].[Region] = @Region,
	[InsideCustomer].[Province] = @Province,
	[InsideCustomer].[City] = @City,
	[InsideCustomer].[BusinessStage] = @BusinessStage,
	[InsideCustomer].[Cost] = @Cost,
	[InsideCustomer].[DealProbably] = @DealProbably,
	[InsideCustomer].[Remark] = @Remark,
	[InsideCustomer].[AddTime] = @AddTime,
	[InsideCustomer].[AddMan] = @AddMan 
output 
	INSERTED.[ID],
	INSERTED.[CustomerName],
	INSERTED.[IndustryName],
	INSERTED.[CategoryName],
	INSERTED.[Interesting],
	INSERTED.[ContactMan],
	INSERTED.[ContactPhone],
	INSERTED.[QQNo],
	INSERTED.[QQGroupInvitation],
	INSERTED.[WechatNo],
	INSERTED.[WechaGroupInvitation],
	INSERTED.[OtherContactMan],
	INSERTED.[CustomerBelonger],
	INSERTED.[NewFollowup],
	INSERTED.[NewFollowupDate],
	INSERTED.[Region],
	INSERTED.[Province],
	INSERTED.[City],
	INSERTED.[BusinessStage],
	INSERTED.[Cost],
	INSERTED.[DealProbably],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
WHERE 
	[InsideCustomer].[ID] = @ID

SELECT 
	[ID],
	[CustomerName],
	[IndustryName],
	[CategoryName],
	[Interesting],
	[ContactMan],
	[ContactPhone],
	[QQNo],
	[QQGroupInvitation],
	[WechatNo],
	[WechaGroupInvitation],
	[OtherContactMan],
	[CustomerBelonger],
	[NewFollowup],
	[NewFollowupDate],
	[Region],
	[Province],
	[City],
	[BusinessStage],
	[Cost],
	[DealProbably],
	[Remark],
	[AddTime],
	[AddMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@CustomerName", EntityBase.GetDatabaseValue(@customerName)));
			parameters.Add(new SqlParameter("@IndustryName", EntityBase.GetDatabaseValue(@industryName)));
			parameters.Add(new SqlParameter("@CategoryName", EntityBase.GetDatabaseValue(@categoryName)));
			parameters.Add(new SqlParameter("@Interesting", EntityBase.GetDatabaseValue(@interesting)));
			parameters.Add(new SqlParameter("@ContactMan", EntityBase.GetDatabaseValue(@contactMan)));
			parameters.Add(new SqlParameter("@ContactPhone", EntityBase.GetDatabaseValue(@contactPhone)));
			parameters.Add(new SqlParameter("@QQNo", EntityBase.GetDatabaseValue(@qQNo)));
			parameters.Add(new SqlParameter("@QQGroupInvitation", EntityBase.GetDatabaseValue(@qQGroupInvitation)));
			parameters.Add(new SqlParameter("@WechatNo", EntityBase.GetDatabaseValue(@wechatNo)));
			parameters.Add(new SqlParameter("@WechaGroupInvitation", EntityBase.GetDatabaseValue(@wechaGroupInvitation)));
			parameters.Add(new SqlParameter("@OtherContactMan", EntityBase.GetDatabaseValue(@otherContactMan)));
			parameters.Add(new SqlParameter("@CustomerBelonger", EntityBase.GetDatabaseValue(@customerBelonger)));
			parameters.Add(new SqlParameter("@NewFollowup", EntityBase.GetDatabaseValue(@newFollowup)));
			parameters.Add(new SqlParameter("@NewFollowupDate", EntityBase.GetDatabaseValue(@newFollowupDate)));
			parameters.Add(new SqlParameter("@Region", EntityBase.GetDatabaseValue(@region)));
			parameters.Add(new SqlParameter("@Province", EntityBase.GetDatabaseValue(@province)));
			parameters.Add(new SqlParameter("@City", EntityBase.GetDatabaseValue(@city)));
			parameters.Add(new SqlParameter("@BusinessStage", EntityBase.GetDatabaseValue(@businessStage)));
			parameters.Add(new SqlParameter("@Cost", EntityBase.GetDatabaseValue(@cost)));
			parameters.Add(new SqlParameter("@DealProbably", EntityBase.GetDatabaseValue(@dealProbably)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a InsideCustomer from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteInsideCustomer(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteInsideCustomer(@iD, helper);
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
		/// Deletes a InsideCustomer from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteInsideCustomer(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[InsideCustomer]
WHERE 
	[InsideCustomer].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new InsideCustomer object.
		/// </summary>
		/// <returns>The newly created InsideCustomer object.</returns>
		public static InsideCustomer CreateInsideCustomer()
		{
			return InitializeNew<InsideCustomer>();
		}
		
		/// <summary>
		/// Retrieve information for a InsideCustomer by a InsideCustomer's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>InsideCustomer</returns>
		public static InsideCustomer GetInsideCustomer(int @iD)
		{
			string commandText = @"
SELECT 
" + InsideCustomer.SelectFieldList + @"
FROM [dbo].[InsideCustomer] 
WHERE 
	[InsideCustomer].[ID] = @ID " + InsideCustomer.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<InsideCustomer>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a InsideCustomer by a InsideCustomer's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>InsideCustomer</returns>
		public static InsideCustomer GetInsideCustomer(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + InsideCustomer.SelectFieldList + @"
FROM [dbo].[InsideCustomer] 
WHERE 
	[InsideCustomer].[ID] = @ID " + InsideCustomer.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<InsideCustomer>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection InsideCustomer objects.
		/// </summary>
		/// <returns>The retrieved collection of InsideCustomer objects.</returns>
		public static EntityList<InsideCustomer> GetInsideCustomers()
		{
			string commandText = @"
SELECT " + InsideCustomer.SelectFieldList + "FROM [dbo].[InsideCustomer] " + InsideCustomer.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<InsideCustomer>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection InsideCustomer objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of InsideCustomer objects.</returns>
        public static EntityList<InsideCustomer> GetInsideCustomers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<InsideCustomer>(SelectFieldList, "FROM [dbo].[InsideCustomer]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection InsideCustomer objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of InsideCustomer objects.</returns>
        public static EntityList<InsideCustomer> GetInsideCustomers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<InsideCustomer>(SelectFieldList, "FROM [dbo].[InsideCustomer]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection InsideCustomer objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of InsideCustomer objects.</returns>
		protected static EntityList<InsideCustomer> GetInsideCustomers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetInsideCustomers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection InsideCustomer objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of InsideCustomer objects.</returns>
		protected static EntityList<InsideCustomer> GetInsideCustomers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetInsideCustomers(string.Empty, where, parameters, InsideCustomer.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection InsideCustomer objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of InsideCustomer objects.</returns>
		protected static EntityList<InsideCustomer> GetInsideCustomers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetInsideCustomers(prefix, where, parameters, InsideCustomer.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection InsideCustomer objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of InsideCustomer objects.</returns>
		protected static EntityList<InsideCustomer> GetInsideCustomers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetInsideCustomers(string.Empty, where, parameters, InsideCustomer.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection InsideCustomer objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of InsideCustomer objects.</returns>
		protected static EntityList<InsideCustomer> GetInsideCustomers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetInsideCustomers(prefix, where, parameters, InsideCustomer.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection InsideCustomer objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of InsideCustomer objects.</returns>
		protected static EntityList<InsideCustomer> GetInsideCustomers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + InsideCustomer.SelectFieldList + "FROM [dbo].[InsideCustomer] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<InsideCustomer>(reader);
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
        protected static EntityList<InsideCustomer> GetInsideCustomers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<InsideCustomer>(SelectFieldList, "FROM [dbo].[InsideCustomer] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of InsideCustomer objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetInsideCustomerCount()
        {
            return GetInsideCustomerCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of InsideCustomer objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetInsideCustomerCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[InsideCustomer] " + where;

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
		public static partial class InsideCustomer_Properties
		{
			public const string ID = "ID";
			public const string CustomerName = "CustomerName";
			public const string IndustryName = "IndustryName";
			public const string CategoryName = "CategoryName";
			public const string Interesting = "Interesting";
			public const string ContactMan = "ContactMan";
			public const string ContactPhone = "ContactPhone";
			public const string QQNo = "QQNo";
			public const string QQGroupInvitation = "QQGroupInvitation";
			public const string WechatNo = "WechatNo";
			public const string WechaGroupInvitation = "WechaGroupInvitation";
			public const string OtherContactMan = "OtherContactMan";
			public const string CustomerBelonger = "CustomerBelonger";
			public const string NewFollowup = "NewFollowup";
			public const string NewFollowupDate = "NewFollowupDate";
			public const string Region = "Region";
			public const string Province = "Province";
			public const string City = "City";
			public const string BusinessStage = "BusinessStage";
			public const string Cost = "Cost";
			public const string DealProbably = "DealProbably";
			public const string Remark = "Remark";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CustomerName" , "string:"},
    			 {"IndustryName" , "string:"},
    			 {"CategoryName" , "string:"},
    			 {"Interesting" , "string:"},
    			 {"ContactMan" , "string:"},
    			 {"ContactPhone" , "string:"},
    			 {"QQNo" , "string:"},
    			 {"QQGroupInvitation" , "string:"},
    			 {"WechatNo" , "string:"},
    			 {"WechaGroupInvitation" , "string:"},
    			 {"OtherContactMan" , "string:"},
    			 {"CustomerBelonger" , "string:"},
    			 {"NewFollowup" , "string:"},
    			 {"NewFollowupDate" , "DateTime:"},
    			 {"Region" , "string:"},
    			 {"Province" , "string:"},
    			 {"City" , "string:"},
    			 {"BusinessStage" , "string:"},
    			 {"Cost" , "decimal:"},
    			 {"DealProbably" , "string:"},
    			 {"Remark" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
            };
		}
		#endregion
	}
}
