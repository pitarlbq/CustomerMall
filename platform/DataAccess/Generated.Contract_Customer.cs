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
	/// This object represents the properties and methods of a Contract_Customer.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Contract_Customer 
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
		private int _contractID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ContractID
		{
			[DebuggerStepThrough()]
			get { return this._contractID; }
			set 
			{
				if (this._contractID != value) 
				{
					this._contractID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractID");
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
		private string _address = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Address
		{
			[DebuggerStepThrough()]
			get { return this._address; }
			set 
			{
				if (this._address != value) 
				{
					this._address = value;
					this.IsDirty = true;	
					OnPropertyChanged("Address");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _officerName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OfficerName
		{
			[DebuggerStepThrough()]
			get { return this._officerName; }
			set 
			{
				if (this._officerName != value) 
				{
					this._officerName = value;
					this.IsDirty = true;	
					OnPropertyChanged("OfficerName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _phoneNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PhoneNumber
		{
			[DebuggerStepThrough()]
			get { return this._phoneNumber; }
			set 
			{
				if (this._phoneNumber != value) 
				{
					this._phoneNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("PhoneNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeIDs = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeIDs
		{
			[DebuggerStepThrough()]
			get { return this._chargeIDs; }
			set 
			{
				if (this._chargeIDs != value) 
				{
					this._chargeIDs = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeIDs");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _customerType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CustomerType
		{
			[DebuggerStepThrough()]
			get { return this._customerType; }
			set 
			{
				if (this._customerType != value) 
				{
					this._customerType = value;
					this.IsDirty = true;	
					OnPropertyChanged("CustomerType");
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
		private string _contactName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContactName
		{
			[DebuggerStepThrough()]
			get { return this._contactName; }
			set 
			{
				if (this._contactName != value) 
				{
					this._contactName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContactName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _chargePercent = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ChargePercent
		{
			[DebuggerStepThrough()]
			get { return this._chargePercent; }
			set 
			{
				if (this._chargePercent != value) 
				{
					this._chargePercent = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargePercent");
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
	[ContractID] int,
	[CustomerName] nvarchar(200),
	[Address] nvarchar(200),
	[OfficerName] nvarchar(200),
	[PhoneNumber] nvarchar(100),
	[ChargeIDs] nvarchar(200),
	[CustomerType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(100),
	[ContactName] nvarchar(200),
	[ChargePercent] decimal(18, 2)
);

INSERT INTO [dbo].[Contract_Customer] (
	[Contract_Customer].[ContractID],
	[Contract_Customer].[CustomerName],
	[Contract_Customer].[Address],
	[Contract_Customer].[OfficerName],
	[Contract_Customer].[PhoneNumber],
	[Contract_Customer].[ChargeIDs],
	[Contract_Customer].[CustomerType],
	[Contract_Customer].[AddTime],
	[Contract_Customer].[AddUserName],
	[Contract_Customer].[ContactName],
	[Contract_Customer].[ChargePercent]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[CustomerName],
	INSERTED.[Address],
	INSERTED.[OfficerName],
	INSERTED.[PhoneNumber],
	INSERTED.[ChargeIDs],
	INSERTED.[CustomerType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ContactName],
	INSERTED.[ChargePercent]
into @table
VALUES ( 
	@ContractID,
	@CustomerName,
	@Address,
	@OfficerName,
	@PhoneNumber,
	@ChargeIDs,
	@CustomerType,
	@AddTime,
	@AddUserName,
	@ContactName,
	@ChargePercent 
); 

SELECT 
	[ID],
	[ContractID],
	[CustomerName],
	[Address],
	[OfficerName],
	[PhoneNumber],
	[ChargeIDs],
	[CustomerType],
	[AddTime],
	[AddUserName],
	[ContactName],
	[ChargePercent] 
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
	[ContractID] int,
	[CustomerName] nvarchar(200),
	[Address] nvarchar(200),
	[OfficerName] nvarchar(200),
	[PhoneNumber] nvarchar(100),
	[ChargeIDs] nvarchar(200),
	[CustomerType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(100),
	[ContactName] nvarchar(200),
	[ChargePercent] decimal(18, 2)
);

UPDATE [dbo].[Contract_Customer] SET 
	[Contract_Customer].[ContractID] = @ContractID,
	[Contract_Customer].[CustomerName] = @CustomerName,
	[Contract_Customer].[Address] = @Address,
	[Contract_Customer].[OfficerName] = @OfficerName,
	[Contract_Customer].[PhoneNumber] = @PhoneNumber,
	[Contract_Customer].[ChargeIDs] = @ChargeIDs,
	[Contract_Customer].[CustomerType] = @CustomerType,
	[Contract_Customer].[AddTime] = @AddTime,
	[Contract_Customer].[AddUserName] = @AddUserName,
	[Contract_Customer].[ContactName] = @ContactName,
	[Contract_Customer].[ChargePercent] = @ChargePercent 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[CustomerName],
	INSERTED.[Address],
	INSERTED.[OfficerName],
	INSERTED.[PhoneNumber],
	INSERTED.[ChargeIDs],
	INSERTED.[CustomerType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ContactName],
	INSERTED.[ChargePercent]
into @table
WHERE 
	[Contract_Customer].[ID] = @ID

SELECT 
	[ID],
	[ContractID],
	[CustomerName],
	[Address],
	[OfficerName],
	[PhoneNumber],
	[ChargeIDs],
	[CustomerType],
	[AddTime],
	[AddUserName],
	[ContactName],
	[ChargePercent] 
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
DELETE FROM [dbo].[Contract_Customer]
WHERE 
	[Contract_Customer].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Contract_Customer() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetContract_Customer(this.ID));
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
	[Contract_Customer].[ID],
	[Contract_Customer].[ContractID],
	[Contract_Customer].[CustomerName],
	[Contract_Customer].[Address],
	[Contract_Customer].[OfficerName],
	[Contract_Customer].[PhoneNumber],
	[Contract_Customer].[ChargeIDs],
	[Contract_Customer].[CustomerType],
	[Contract_Customer].[AddTime],
	[Contract_Customer].[AddUserName],
	[Contract_Customer].[ContactName],
	[Contract_Customer].[ChargePercent]
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
                return "Contract_Customer";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Contract_Customer into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractID">contractID</param>
		/// <param name="customerName">customerName</param>
		/// <param name="address">address</param>
		/// <param name="officerName">officerName</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="chargeIDs">chargeIDs</param>
		/// <param name="customerType">customerType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="contactName">contactName</param>
		/// <param name="chargePercent">chargePercent</param>
		public static void InsertContract_Customer(int @contractID, string @customerName, string @address, string @officerName, string @phoneNumber, string @chargeIDs, int @customerType, DateTime @addTime, string @addUserName, string @contactName, decimal @chargePercent)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertContract_Customer(@contractID, @customerName, @address, @officerName, @phoneNumber, @chargeIDs, @customerType, @addTime, @addUserName, @contactName, @chargePercent, helper);
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
		/// Insert a Contract_Customer into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractID">contractID</param>
		/// <param name="customerName">customerName</param>
		/// <param name="address">address</param>
		/// <param name="officerName">officerName</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="chargeIDs">chargeIDs</param>
		/// <param name="customerType">customerType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="contactName">contactName</param>
		/// <param name="chargePercent">chargePercent</param>
		/// <param name="helper">helper</param>
		internal static void InsertContract_Customer(int @contractID, string @customerName, string @address, string @officerName, string @phoneNumber, string @chargeIDs, int @customerType, DateTime @addTime, string @addUserName, string @contactName, decimal @chargePercent, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractID] int,
	[CustomerName] nvarchar(200),
	[Address] nvarchar(200),
	[OfficerName] nvarchar(200),
	[PhoneNumber] nvarchar(100),
	[ChargeIDs] nvarchar(200),
	[CustomerType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(100),
	[ContactName] nvarchar(200),
	[ChargePercent] decimal(18, 2)
);

INSERT INTO [dbo].[Contract_Customer] (
	[Contract_Customer].[ContractID],
	[Contract_Customer].[CustomerName],
	[Contract_Customer].[Address],
	[Contract_Customer].[OfficerName],
	[Contract_Customer].[PhoneNumber],
	[Contract_Customer].[ChargeIDs],
	[Contract_Customer].[CustomerType],
	[Contract_Customer].[AddTime],
	[Contract_Customer].[AddUserName],
	[Contract_Customer].[ContactName],
	[Contract_Customer].[ChargePercent]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[CustomerName],
	INSERTED.[Address],
	INSERTED.[OfficerName],
	INSERTED.[PhoneNumber],
	INSERTED.[ChargeIDs],
	INSERTED.[CustomerType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ContactName],
	INSERTED.[ChargePercent]
into @table
VALUES ( 
	@ContractID,
	@CustomerName,
	@Address,
	@OfficerName,
	@PhoneNumber,
	@ChargeIDs,
	@CustomerType,
	@AddTime,
	@AddUserName,
	@ContactName,
	@ChargePercent 
); 

SELECT 
	[ID],
	[ContractID],
	[CustomerName],
	[Address],
	[OfficerName],
	[PhoneNumber],
	[ChargeIDs],
	[CustomerType],
	[AddTime],
	[AddUserName],
	[ContactName],
	[ChargePercent] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@CustomerName", EntityBase.GetDatabaseValue(@customerName)));
			parameters.Add(new SqlParameter("@Address", EntityBase.GetDatabaseValue(@address)));
			parameters.Add(new SqlParameter("@OfficerName", EntityBase.GetDatabaseValue(@officerName)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@ChargeIDs", EntityBase.GetDatabaseValue(@chargeIDs)));
			parameters.Add(new SqlParameter("@CustomerType", EntityBase.GetDatabaseValue(@customerType)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@ContactName", EntityBase.GetDatabaseValue(@contactName)));
			parameters.Add(new SqlParameter("@ChargePercent", EntityBase.GetDatabaseValue(@chargePercent)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Contract_Customer into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractID">contractID</param>
		/// <param name="customerName">customerName</param>
		/// <param name="address">address</param>
		/// <param name="officerName">officerName</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="chargeIDs">chargeIDs</param>
		/// <param name="customerType">customerType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="contactName">contactName</param>
		/// <param name="chargePercent">chargePercent</param>
		public static void UpdateContract_Customer(int @iD, int @contractID, string @customerName, string @address, string @officerName, string @phoneNumber, string @chargeIDs, int @customerType, DateTime @addTime, string @addUserName, string @contactName, decimal @chargePercent)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateContract_Customer(@iD, @contractID, @customerName, @address, @officerName, @phoneNumber, @chargeIDs, @customerType, @addTime, @addUserName, @contactName, @chargePercent, helper);
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
		/// Updates a Contract_Customer into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractID">contractID</param>
		/// <param name="customerName">customerName</param>
		/// <param name="address">address</param>
		/// <param name="officerName">officerName</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="chargeIDs">chargeIDs</param>
		/// <param name="customerType">customerType</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="contactName">contactName</param>
		/// <param name="chargePercent">chargePercent</param>
		/// <param name="helper">helper</param>
		internal static void UpdateContract_Customer(int @iD, int @contractID, string @customerName, string @address, string @officerName, string @phoneNumber, string @chargeIDs, int @customerType, DateTime @addTime, string @addUserName, string @contactName, decimal @chargePercent, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractID] int,
	[CustomerName] nvarchar(200),
	[Address] nvarchar(200),
	[OfficerName] nvarchar(200),
	[PhoneNumber] nvarchar(100),
	[ChargeIDs] nvarchar(200),
	[CustomerType] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(100),
	[ContactName] nvarchar(200),
	[ChargePercent] decimal(18, 2)
);

UPDATE [dbo].[Contract_Customer] SET 
	[Contract_Customer].[ContractID] = @ContractID,
	[Contract_Customer].[CustomerName] = @CustomerName,
	[Contract_Customer].[Address] = @Address,
	[Contract_Customer].[OfficerName] = @OfficerName,
	[Contract_Customer].[PhoneNumber] = @PhoneNumber,
	[Contract_Customer].[ChargeIDs] = @ChargeIDs,
	[Contract_Customer].[CustomerType] = @CustomerType,
	[Contract_Customer].[AddTime] = @AddTime,
	[Contract_Customer].[AddUserName] = @AddUserName,
	[Contract_Customer].[ContactName] = @ContactName,
	[Contract_Customer].[ChargePercent] = @ChargePercent 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[CustomerName],
	INSERTED.[Address],
	INSERTED.[OfficerName],
	INSERTED.[PhoneNumber],
	INSERTED.[ChargeIDs],
	INSERTED.[CustomerType],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ContactName],
	INSERTED.[ChargePercent]
into @table
WHERE 
	[Contract_Customer].[ID] = @ID

SELECT 
	[ID],
	[ContractID],
	[CustomerName],
	[Address],
	[OfficerName],
	[PhoneNumber],
	[ChargeIDs],
	[CustomerType],
	[AddTime],
	[AddUserName],
	[ContactName],
	[ChargePercent] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@CustomerName", EntityBase.GetDatabaseValue(@customerName)));
			parameters.Add(new SqlParameter("@Address", EntityBase.GetDatabaseValue(@address)));
			parameters.Add(new SqlParameter("@OfficerName", EntityBase.GetDatabaseValue(@officerName)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@ChargeIDs", EntityBase.GetDatabaseValue(@chargeIDs)));
			parameters.Add(new SqlParameter("@CustomerType", EntityBase.GetDatabaseValue(@customerType)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@ContactName", EntityBase.GetDatabaseValue(@contactName)));
			parameters.Add(new SqlParameter("@ChargePercent", EntityBase.GetDatabaseValue(@chargePercent)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Contract_Customer from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteContract_Customer(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteContract_Customer(@iD, helper);
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
		/// Deletes a Contract_Customer from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteContract_Customer(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Contract_Customer]
WHERE 
	[Contract_Customer].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Contract_Customer object.
		/// </summary>
		/// <returns>The newly created Contract_Customer object.</returns>
		public static Contract_Customer CreateContract_Customer()
		{
			return InitializeNew<Contract_Customer>();
		}
		
		/// <summary>
		/// Retrieve information for a Contract_Customer by a Contract_Customer's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Contract_Customer</returns>
		public static Contract_Customer GetContract_Customer(int @iD)
		{
			string commandText = @"
SELECT 
" + Contract_Customer.SelectFieldList + @"
FROM [dbo].[Contract_Customer] 
WHERE 
	[Contract_Customer].[ID] = @ID " + Contract_Customer.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_Customer>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Contract_Customer by a Contract_Customer's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Contract_Customer</returns>
		public static Contract_Customer GetContract_Customer(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Contract_Customer.SelectFieldList + @"
FROM [dbo].[Contract_Customer] 
WHERE 
	[Contract_Customer].[ID] = @ID " + Contract_Customer.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_Customer>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Contract_Customer objects.
		/// </summary>
		/// <returns>The retrieved collection of Contract_Customer objects.</returns>
		public static EntityList<Contract_Customer> GetContract_Customers()
		{
			string commandText = @"
SELECT " + Contract_Customer.SelectFieldList + "FROM [dbo].[Contract_Customer] " + Contract_Customer.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Contract_Customer>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Contract_Customer objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_Customer objects.</returns>
        public static EntityList<Contract_Customer> GetContract_Customers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Customer>(SelectFieldList, "FROM [dbo].[Contract_Customer]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Contract_Customer objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_Customer objects.</returns>
        public static EntityList<Contract_Customer> GetContract_Customers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Customer>(SelectFieldList, "FROM [dbo].[Contract_Customer]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Contract_Customer objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Contract_Customer objects.</returns>
		protected static EntityList<Contract_Customer> GetContract_Customers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Customers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Contract_Customer objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_Customer objects.</returns>
		protected static EntityList<Contract_Customer> GetContract_Customers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Customers(string.Empty, where, parameters, Contract_Customer.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Customer objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_Customer objects.</returns>
		protected static EntityList<Contract_Customer> GetContract_Customers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Customers(prefix, where, parameters, Contract_Customer.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Customer objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_Customer objects.</returns>
		protected static EntityList<Contract_Customer> GetContract_Customers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_Customers(string.Empty, where, parameters, Contract_Customer.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Customer objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_Customer objects.</returns>
		protected static EntityList<Contract_Customer> GetContract_Customers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_Customers(prefix, where, parameters, Contract_Customer.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Customer objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Contract_Customer objects.</returns>
		protected static EntityList<Contract_Customer> GetContract_Customers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Contract_Customer.SelectFieldList + "FROM [dbo].[Contract_Customer] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Contract_Customer>(reader);
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
        protected static EntityList<Contract_Customer> GetContract_Customers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Customer>(SelectFieldList, "FROM [dbo].[Contract_Customer] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Contract_Customer objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_CustomerCount()
        {
            return GetContract_CustomerCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Contract_Customer objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_CustomerCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Contract_Customer] " + where;

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
		public static partial class Contract_Customer_Properties
		{
			public const string ID = "ID";
			public const string ContractID = "ContractID";
			public const string CustomerName = "CustomerName";
			public const string Address = "Address";
			public const string OfficerName = "OfficerName";
			public const string PhoneNumber = "PhoneNumber";
			public const string ChargeIDs = "ChargeIDs";
			public const string CustomerType = "CustomerType";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string ContactName = "ContactName";
			public const string ChargePercent = "ChargePercent";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ContractID" , "int:"},
    			 {"CustomerName" , "string:"},
    			 {"Address" , "string:"},
    			 {"OfficerName" , "string:"},
    			 {"PhoneNumber" , "string:"},
    			 {"ChargeIDs" , "string:"},
    			 {"CustomerType" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"ContactName" , "string:"},
    			 {"ChargePercent" , "decimal:"},
            };
		}
		#endregion
	}
}
