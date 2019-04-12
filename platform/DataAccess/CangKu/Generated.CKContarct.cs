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
	/// This object represents the properties and methods of a CKContarct.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CKContarct 
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
		private string _contractNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractNumber
		{
			[DebuggerStepThrough()]
			get { return this._contractNumber; }
			set 
			{
				if (this._contractNumber != value) 
				{
					this._contractNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contractName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string ContractName
		{
			[DebuggerStepThrough()]
			get { return this._contractName; }
			set 
			{
				if (this._contractName != value) 
				{
					this._contractName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contractFullName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractFullName
		{
			[DebuggerStepThrough()]
			get { return this._contractFullName; }
			set 
			{
				if (this._contractFullName != value) 
				{
					this._contractFullName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractFullName");
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
		private string _faxNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FaxNumber
		{
			[DebuggerStepThrough()]
			get { return this._faxNumber; }
			set 
			{
				if (this._faxNumber != value) 
				{
					this._faxNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("FaxNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _eMailAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string EMailAddress
		{
			[DebuggerStepThrough()]
			get { return this._eMailAddress; }
			set 
			{
				if (this._eMailAddress != value) 
				{
					this._eMailAddress = value;
					this.IsDirty = true;	
					OnPropertyChanged("EMailAddress");
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
	[ContractNumber] nvarchar(100),
	[ContractName] nvarchar(100),
	[ContractFullName] nvarchar(200),
	[Address] nvarchar(100),
	[ContactMan] nvarchar(50),
	[PhoneNumber] nvarchar(50),
	[FaxNumber] nvarchar(50),
	[EMailAddress] nvarchar(100),
	[Remark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime
);

INSERT INTO [dbo].[CKContarct] (
	[CKContarct].[ContractNumber],
	[CKContarct].[ContractName],
	[CKContarct].[ContractFullName],
	[CKContarct].[Address],
	[CKContarct].[ContactMan],
	[CKContarct].[PhoneNumber],
	[CKContarct].[FaxNumber],
	[CKContarct].[EMailAddress],
	[CKContarct].[Remark],
	[CKContarct].[AddMan],
	[CKContarct].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractNumber],
	INSERTED.[ContractName],
	INSERTED.[ContractFullName],
	INSERTED.[Address],
	INSERTED.[ContactMan],
	INSERTED.[PhoneNumber],
	INSERTED.[FaxNumber],
	INSERTED.[EMailAddress],
	INSERTED.[Remark],
	INSERTED.[AddMan],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@ContractNumber,
	@ContractName,
	@ContractFullName,
	@Address,
	@ContactMan,
	@PhoneNumber,
	@FaxNumber,
	@EMailAddress,
	@Remark,
	@AddMan,
	@AddTime 
); 

SELECT 
	[ID],
	[ContractNumber],
	[ContractName],
	[ContractFullName],
	[Address],
	[ContactMan],
	[PhoneNumber],
	[FaxNumber],
	[EMailAddress],
	[Remark],
	[AddMan],
	[AddTime] 
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
	[ContractNumber] nvarchar(100),
	[ContractName] nvarchar(100),
	[ContractFullName] nvarchar(200),
	[Address] nvarchar(100),
	[ContactMan] nvarchar(50),
	[PhoneNumber] nvarchar(50),
	[FaxNumber] nvarchar(50),
	[EMailAddress] nvarchar(100),
	[Remark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime
);

UPDATE [dbo].[CKContarct] SET 
	[CKContarct].[ContractNumber] = @ContractNumber,
	[CKContarct].[ContractName] = @ContractName,
	[CKContarct].[ContractFullName] = @ContractFullName,
	[CKContarct].[Address] = @Address,
	[CKContarct].[ContactMan] = @ContactMan,
	[CKContarct].[PhoneNumber] = @PhoneNumber,
	[CKContarct].[FaxNumber] = @FaxNumber,
	[CKContarct].[EMailAddress] = @EMailAddress,
	[CKContarct].[Remark] = @Remark,
	[CKContarct].[AddMan] = @AddMan,
	[CKContarct].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[ContractNumber],
	INSERTED.[ContractName],
	INSERTED.[ContractFullName],
	INSERTED.[Address],
	INSERTED.[ContactMan],
	INSERTED.[PhoneNumber],
	INSERTED.[FaxNumber],
	INSERTED.[EMailAddress],
	INSERTED.[Remark],
	INSERTED.[AddMan],
	INSERTED.[AddTime]
into @table
WHERE 
	[CKContarct].[ID] = @ID

SELECT 
	[ID],
	[ContractNumber],
	[ContractName],
	[ContractFullName],
	[Address],
	[ContactMan],
	[PhoneNumber],
	[FaxNumber],
	[EMailAddress],
	[Remark],
	[AddMan],
	[AddTime] 
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
DELETE FROM [dbo].[CKContarct]
WHERE 
	[CKContarct].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CKContarct() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCKContarct(this.ID));
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
	[CKContarct].[ID],
	[CKContarct].[ContractNumber],
	[CKContarct].[ContractName],
	[CKContarct].[ContractFullName],
	[CKContarct].[Address],
	[CKContarct].[ContactMan],
	[CKContarct].[PhoneNumber],
	[CKContarct].[FaxNumber],
	[CKContarct].[EMailAddress],
	[CKContarct].[Remark],
	[CKContarct].[AddMan],
	[CKContarct].[AddTime]
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
                return "CKContarct";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CKContarct into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractNumber">contractNumber</param>
		/// <param name="contractName">contractName</param>
		/// <param name="contractFullName">contractFullName</param>
		/// <param name="address">address</param>
		/// <param name="contactMan">contactMan</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="faxNumber">faxNumber</param>
		/// <param name="eMailAddress">eMailAddress</param>
		/// <param name="remark">remark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		public static void InsertCKContarct(string @contractNumber, string @contractName, string @contractFullName, string @address, string @contactMan, string @phoneNumber, string @faxNumber, string @eMailAddress, string @remark, string @addMan, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCKContarct(@contractNumber, @contractName, @contractFullName, @address, @contactMan, @phoneNumber, @faxNumber, @eMailAddress, @remark, @addMan, @addTime, helper);
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
		/// Insert a CKContarct into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractNumber">contractNumber</param>
		/// <param name="contractName">contractName</param>
		/// <param name="contractFullName">contractFullName</param>
		/// <param name="address">address</param>
		/// <param name="contactMan">contactMan</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="faxNumber">faxNumber</param>
		/// <param name="eMailAddress">eMailAddress</param>
		/// <param name="remark">remark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertCKContarct(string @contractNumber, string @contractName, string @contractFullName, string @address, string @contactMan, string @phoneNumber, string @faxNumber, string @eMailAddress, string @remark, string @addMan, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractNumber] nvarchar(100),
	[ContractName] nvarchar(100),
	[ContractFullName] nvarchar(200),
	[Address] nvarchar(100),
	[ContactMan] nvarchar(50),
	[PhoneNumber] nvarchar(50),
	[FaxNumber] nvarchar(50),
	[EMailAddress] nvarchar(100),
	[Remark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime
);

INSERT INTO [dbo].[CKContarct] (
	[CKContarct].[ContractNumber],
	[CKContarct].[ContractName],
	[CKContarct].[ContractFullName],
	[CKContarct].[Address],
	[CKContarct].[ContactMan],
	[CKContarct].[PhoneNumber],
	[CKContarct].[FaxNumber],
	[CKContarct].[EMailAddress],
	[CKContarct].[Remark],
	[CKContarct].[AddMan],
	[CKContarct].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractNumber],
	INSERTED.[ContractName],
	INSERTED.[ContractFullName],
	INSERTED.[Address],
	INSERTED.[ContactMan],
	INSERTED.[PhoneNumber],
	INSERTED.[FaxNumber],
	INSERTED.[EMailAddress],
	INSERTED.[Remark],
	INSERTED.[AddMan],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@ContractNumber,
	@ContractName,
	@ContractFullName,
	@Address,
	@ContactMan,
	@PhoneNumber,
	@FaxNumber,
	@EMailAddress,
	@Remark,
	@AddMan,
	@AddTime 
); 

SELECT 
	[ID],
	[ContractNumber],
	[ContractName],
	[ContractFullName],
	[Address],
	[ContactMan],
	[PhoneNumber],
	[FaxNumber],
	[EMailAddress],
	[Remark],
	[AddMan],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ContractNumber", EntityBase.GetDatabaseValue(@contractNumber)));
			parameters.Add(new SqlParameter("@ContractName", EntityBase.GetDatabaseValue(@contractName)));
			parameters.Add(new SqlParameter("@ContractFullName", EntityBase.GetDatabaseValue(@contractFullName)));
			parameters.Add(new SqlParameter("@Address", EntityBase.GetDatabaseValue(@address)));
			parameters.Add(new SqlParameter("@ContactMan", EntityBase.GetDatabaseValue(@contactMan)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@FaxNumber", EntityBase.GetDatabaseValue(@faxNumber)));
			parameters.Add(new SqlParameter("@EMailAddress", EntityBase.GetDatabaseValue(@eMailAddress)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CKContarct into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractNumber">contractNumber</param>
		/// <param name="contractName">contractName</param>
		/// <param name="contractFullName">contractFullName</param>
		/// <param name="address">address</param>
		/// <param name="contactMan">contactMan</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="faxNumber">faxNumber</param>
		/// <param name="eMailAddress">eMailAddress</param>
		/// <param name="remark">remark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateCKContarct(int @iD, string @contractNumber, string @contractName, string @contractFullName, string @address, string @contactMan, string @phoneNumber, string @faxNumber, string @eMailAddress, string @remark, string @addMan, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCKContarct(@iD, @contractNumber, @contractName, @contractFullName, @address, @contactMan, @phoneNumber, @faxNumber, @eMailAddress, @remark, @addMan, @addTime, helper);
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
		/// Updates a CKContarct into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractNumber">contractNumber</param>
		/// <param name="contractName">contractName</param>
		/// <param name="contractFullName">contractFullName</param>
		/// <param name="address">address</param>
		/// <param name="contactMan">contactMan</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="faxNumber">faxNumber</param>
		/// <param name="eMailAddress">eMailAddress</param>
		/// <param name="remark">remark</param>
		/// <param name="addMan">addMan</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCKContarct(int @iD, string @contractNumber, string @contractName, string @contractFullName, string @address, string @contactMan, string @phoneNumber, string @faxNumber, string @eMailAddress, string @remark, string @addMan, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractNumber] nvarchar(100),
	[ContractName] nvarchar(100),
	[ContractFullName] nvarchar(200),
	[Address] nvarchar(100),
	[ContactMan] nvarchar(50),
	[PhoneNumber] nvarchar(50),
	[FaxNumber] nvarchar(50),
	[EMailAddress] nvarchar(100),
	[Remark] ntext,
	[AddMan] nvarchar(50),
	[AddTime] datetime
);

UPDATE [dbo].[CKContarct] SET 
	[CKContarct].[ContractNumber] = @ContractNumber,
	[CKContarct].[ContractName] = @ContractName,
	[CKContarct].[ContractFullName] = @ContractFullName,
	[CKContarct].[Address] = @Address,
	[CKContarct].[ContactMan] = @ContactMan,
	[CKContarct].[PhoneNumber] = @PhoneNumber,
	[CKContarct].[FaxNumber] = @FaxNumber,
	[CKContarct].[EMailAddress] = @EMailAddress,
	[CKContarct].[Remark] = @Remark,
	[CKContarct].[AddMan] = @AddMan,
	[CKContarct].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[ContractNumber],
	INSERTED.[ContractName],
	INSERTED.[ContractFullName],
	INSERTED.[Address],
	INSERTED.[ContactMan],
	INSERTED.[PhoneNumber],
	INSERTED.[FaxNumber],
	INSERTED.[EMailAddress],
	INSERTED.[Remark],
	INSERTED.[AddMan],
	INSERTED.[AddTime]
into @table
WHERE 
	[CKContarct].[ID] = @ID

SELECT 
	[ID],
	[ContractNumber],
	[ContractName],
	[ContractFullName],
	[Address],
	[ContactMan],
	[PhoneNumber],
	[FaxNumber],
	[EMailAddress],
	[Remark],
	[AddMan],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ContractNumber", EntityBase.GetDatabaseValue(@contractNumber)));
			parameters.Add(new SqlParameter("@ContractName", EntityBase.GetDatabaseValue(@contractName)));
			parameters.Add(new SqlParameter("@ContractFullName", EntityBase.GetDatabaseValue(@contractFullName)));
			parameters.Add(new SqlParameter("@Address", EntityBase.GetDatabaseValue(@address)));
			parameters.Add(new SqlParameter("@ContactMan", EntityBase.GetDatabaseValue(@contactMan)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@FaxNumber", EntityBase.GetDatabaseValue(@faxNumber)));
			parameters.Add(new SqlParameter("@EMailAddress", EntityBase.GetDatabaseValue(@eMailAddress)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CKContarct from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCKContarct(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCKContarct(@iD, helper);
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
		/// Deletes a CKContarct from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCKContarct(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CKContarct]
WHERE 
	[CKContarct].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CKContarct object.
		/// </summary>
		/// <returns>The newly created CKContarct object.</returns>
		public static CKContarct CreateCKContarct()
		{
			return InitializeNew<CKContarct>();
		}
		
		/// <summary>
		/// Retrieve information for a CKContarct by a CKContarct's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CKContarct</returns>
		public static CKContarct GetCKContarct(int @iD)
		{
			string commandText = @"
SELECT 
" + CKContarct.SelectFieldList + @"
FROM [dbo].[CKContarct] 
WHERE 
	[CKContarct].[ID] = @ID " + CKContarct.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKContarct>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CKContarct by a CKContarct's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CKContarct</returns>
		public static CKContarct GetCKContarct(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CKContarct.SelectFieldList + @"
FROM [dbo].[CKContarct] 
WHERE 
	[CKContarct].[ID] = @ID " + CKContarct.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKContarct>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CKContarct objects.
		/// </summary>
		/// <returns>The retrieved collection of CKContarct objects.</returns>
		public static EntityList<CKContarct> GetCKContarcts()
		{
			string commandText = @"
SELECT " + CKContarct.SelectFieldList + "FROM [dbo].[CKContarct] " + CKContarct.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CKContarct>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CKContarct objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKContarct objects.</returns>
        public static EntityList<CKContarct> GetCKContarcts(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKContarct>(SelectFieldList, "FROM [dbo].[CKContarct]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CKContarct objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKContarct objects.</returns>
        public static EntityList<CKContarct> GetCKContarcts(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKContarct>(SelectFieldList, "FROM [dbo].[CKContarct]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CKContarct objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CKContarct objects.</returns>
		protected static EntityList<CKContarct> GetCKContarcts(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKContarcts(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CKContarct objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKContarct objects.</returns>
		protected static EntityList<CKContarct> GetCKContarcts(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKContarcts(string.Empty, where, parameters, CKContarct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKContarct objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKContarct objects.</returns>
		protected static EntityList<CKContarct> GetCKContarcts(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKContarcts(prefix, where, parameters, CKContarct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKContarct objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKContarct objects.</returns>
		protected static EntityList<CKContarct> GetCKContarcts(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKContarcts(string.Empty, where, parameters, CKContarct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKContarct objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKContarct objects.</returns>
		protected static EntityList<CKContarct> GetCKContarcts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKContarcts(prefix, where, parameters, CKContarct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKContarct objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CKContarct objects.</returns>
		protected static EntityList<CKContarct> GetCKContarcts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CKContarct.SelectFieldList + "FROM [dbo].[CKContarct] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CKContarct>(reader);
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
        protected static EntityList<CKContarct> GetCKContarcts(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKContarct>(SelectFieldList, "FROM [dbo].[CKContarct] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CKContarct objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKContarctCount()
        {
            return GetCKContarctCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CKContarct objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKContarctCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CKContarct] " + where;

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
		public static partial class CKContarct_Properties
		{
			public const string ID = "ID";
			public const string ContractNumber = "ContractNumber";
			public const string ContractName = "ContractName";
			public const string ContractFullName = "ContractFullName";
			public const string Address = "Address";
			public const string ContactMan = "ContactMan";
			public const string PhoneNumber = "PhoneNumber";
			public const string FaxNumber = "FaxNumber";
			public const string EMailAddress = "EMailAddress";
			public const string Remark = "Remark";
			public const string AddMan = "AddMan";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ContractNumber" , "string:"},
    			 {"ContractName" , "string:"},
    			 {"ContractFullName" , "string:"},
    			 {"Address" , "string:"},
    			 {"ContactMan" , "string:"},
    			 {"PhoneNumber" , "string:"},
    			 {"FaxNumber" , "string:"},
    			 {"EMailAddress" , "string:"},
    			 {"Remark" , "string:"},
    			 {"AddMan" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
