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
	/// This object represents the properties and methods of a Cheque_Buyer.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_Buyer 
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
			set 
			{
				if (this._buyerName != value) 
				{
					this._buyerName = value;
					this.IsDirty = true;	
					OnPropertyChanged("BuyerName");
				}
			}
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
			set 
			{
				if (this._buyerTaxNumber != value) 
				{
					this._buyerTaxNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("BuyerTaxNumber");
				}
			}
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
			set 
			{
				if (this._buyerAddressPhone != value) 
				{
					this._buyerAddressPhone = value;
					this.IsDirty = true;	
					OnPropertyChanged("BuyerAddressPhone");
				}
			}
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
			set 
			{
				if (this._buyerBankAccount != value) 
				{
					this._buyerBankAccount = value;
					this.IsDirty = true;	
					OnPropertyChanged("BuyerBankAccount");
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
			set 
			{
				if (this._gUID != value) 
				{
					this._gUID = value;
					this.IsDirty = true;	
					OnPropertyChanged("GUID");
				}
			}
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
			set 
			{
				if (this._buyerCategoryID != value) 
				{
					this._buyerCategoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("BuyerCategoryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _buyerSocialCreditCode = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BuyerSocialCreditCode
		{
			[DebuggerStepThrough()]
			get { return this._buyerSocialCreditCode; }
			set 
			{
				if (this._buyerSocialCreditCode != value) 
				{
					this._buyerSocialCreditCode = value;
					this.IsDirty = true;	
					OnPropertyChanged("BuyerSocialCreditCode");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _buyerType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BuyerType
		{
			[DebuggerStepThrough()]
			get { return this._buyerType; }
			set 
			{
				if (this._buyerType != value) 
				{
					this._buyerType = value;
					this.IsDirty = true;	
					OnPropertyChanged("BuyerType");
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
	[BuyerName] nvarchar(200),
	[BuyerTaxNumber] nvarchar(100),
	[BuyerAddressPhone] nvarchar(50),
	[BuyerBankAccount] nvarchar(100),
	[AddTime] datetime,
	[GUID] nvarchar(200),
	[BuyerCategoryID] int,
	[BuyerSocialCreditCode] nvarchar(200),
	[BuyerType] nvarchar(50)
);

INSERT INTO [dbo].[Cheque_Buyer] (
	[Cheque_Buyer].[BuyerName],
	[Cheque_Buyer].[BuyerTaxNumber],
	[Cheque_Buyer].[BuyerAddressPhone],
	[Cheque_Buyer].[BuyerBankAccount],
	[Cheque_Buyer].[AddTime],
	[Cheque_Buyer].[GUID],
	[Cheque_Buyer].[BuyerCategoryID],
	[Cheque_Buyer].[BuyerSocialCreditCode],
	[Cheque_Buyer].[BuyerType]
) 
output 
	INSERTED.[ID],
	INSERTED.[BuyerName],
	INSERTED.[BuyerTaxNumber],
	INSERTED.[BuyerAddressPhone],
	INSERTED.[BuyerBankAccount],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[BuyerCategoryID],
	INSERTED.[BuyerSocialCreditCode],
	INSERTED.[BuyerType]
into @table
VALUES ( 
	@BuyerName,
	@BuyerTaxNumber,
	@BuyerAddressPhone,
	@BuyerBankAccount,
	@AddTime,
	@GUID,
	@BuyerCategoryID,
	@BuyerSocialCreditCode,
	@BuyerType 
); 

SELECT 
	[ID],
	[BuyerName],
	[BuyerTaxNumber],
	[BuyerAddressPhone],
	[BuyerBankAccount],
	[AddTime],
	[GUID],
	[BuyerCategoryID],
	[BuyerSocialCreditCode],
	[BuyerType] 
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
	[BuyerName] nvarchar(200),
	[BuyerTaxNumber] nvarchar(100),
	[BuyerAddressPhone] nvarchar(50),
	[BuyerBankAccount] nvarchar(100),
	[AddTime] datetime,
	[GUID] nvarchar(200),
	[BuyerCategoryID] int,
	[BuyerSocialCreditCode] nvarchar(200),
	[BuyerType] nvarchar(50)
);

UPDATE [dbo].[Cheque_Buyer] SET 
	[Cheque_Buyer].[BuyerName] = @BuyerName,
	[Cheque_Buyer].[BuyerTaxNumber] = @BuyerTaxNumber,
	[Cheque_Buyer].[BuyerAddressPhone] = @BuyerAddressPhone,
	[Cheque_Buyer].[BuyerBankAccount] = @BuyerBankAccount,
	[Cheque_Buyer].[AddTime] = @AddTime,
	[Cheque_Buyer].[GUID] = @GUID,
	[Cheque_Buyer].[BuyerCategoryID] = @BuyerCategoryID,
	[Cheque_Buyer].[BuyerSocialCreditCode] = @BuyerSocialCreditCode,
	[Cheque_Buyer].[BuyerType] = @BuyerType 
output 
	INSERTED.[ID],
	INSERTED.[BuyerName],
	INSERTED.[BuyerTaxNumber],
	INSERTED.[BuyerAddressPhone],
	INSERTED.[BuyerBankAccount],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[BuyerCategoryID],
	INSERTED.[BuyerSocialCreditCode],
	INSERTED.[BuyerType]
into @table
WHERE 
	[Cheque_Buyer].[ID] = @ID

SELECT 
	[ID],
	[BuyerName],
	[BuyerTaxNumber],
	[BuyerAddressPhone],
	[BuyerBankAccount],
	[AddTime],
	[GUID],
	[BuyerCategoryID],
	[BuyerSocialCreditCode],
	[BuyerType] 
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
DELETE FROM [dbo].[Cheque_Buyer]
WHERE 
	[Cheque_Buyer].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_Buyer() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_Buyer(this.ID));
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
	[Cheque_Buyer].[ID],
	[Cheque_Buyer].[BuyerName],
	[Cheque_Buyer].[BuyerTaxNumber],
	[Cheque_Buyer].[BuyerAddressPhone],
	[Cheque_Buyer].[BuyerBankAccount],
	[Cheque_Buyer].[AddTime],
	[Cheque_Buyer].[GUID],
	[Cheque_Buyer].[BuyerCategoryID],
	[Cheque_Buyer].[BuyerSocialCreditCode],
	[Cheque_Buyer].[BuyerType]
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
                return "Cheque_Buyer";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_Buyer into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="buyerName">buyerName</param>
		/// <param name="buyerTaxNumber">buyerTaxNumber</param>
		/// <param name="buyerAddressPhone">buyerAddressPhone</param>
		/// <param name="buyerBankAccount">buyerBankAccount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="buyerCategoryID">buyerCategoryID</param>
		/// <param name="buyerSocialCreditCode">buyerSocialCreditCode</param>
		/// <param name="buyerType">buyerType</param>
		public static void InsertCheque_Buyer(string @buyerName, string @buyerTaxNumber, string @buyerAddressPhone, string @buyerBankAccount, DateTime @addTime, string @gUID, int @buyerCategoryID, string @buyerSocialCreditCode, string @buyerType)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_Buyer(@buyerName, @buyerTaxNumber, @buyerAddressPhone, @buyerBankAccount, @addTime, @gUID, @buyerCategoryID, @buyerSocialCreditCode, @buyerType, helper);
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
		/// Insert a Cheque_Buyer into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="buyerName">buyerName</param>
		/// <param name="buyerTaxNumber">buyerTaxNumber</param>
		/// <param name="buyerAddressPhone">buyerAddressPhone</param>
		/// <param name="buyerBankAccount">buyerBankAccount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="buyerCategoryID">buyerCategoryID</param>
		/// <param name="buyerSocialCreditCode">buyerSocialCreditCode</param>
		/// <param name="buyerType">buyerType</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_Buyer(string @buyerName, string @buyerTaxNumber, string @buyerAddressPhone, string @buyerBankAccount, DateTime @addTime, string @gUID, int @buyerCategoryID, string @buyerSocialCreditCode, string @buyerType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BuyerName] nvarchar(200),
	[BuyerTaxNumber] nvarchar(100),
	[BuyerAddressPhone] nvarchar(50),
	[BuyerBankAccount] nvarchar(100),
	[AddTime] datetime,
	[GUID] nvarchar(200),
	[BuyerCategoryID] int,
	[BuyerSocialCreditCode] nvarchar(200),
	[BuyerType] nvarchar(50)
);

INSERT INTO [dbo].[Cheque_Buyer] (
	[Cheque_Buyer].[BuyerName],
	[Cheque_Buyer].[BuyerTaxNumber],
	[Cheque_Buyer].[BuyerAddressPhone],
	[Cheque_Buyer].[BuyerBankAccount],
	[Cheque_Buyer].[AddTime],
	[Cheque_Buyer].[GUID],
	[Cheque_Buyer].[BuyerCategoryID],
	[Cheque_Buyer].[BuyerSocialCreditCode],
	[Cheque_Buyer].[BuyerType]
) 
output 
	INSERTED.[ID],
	INSERTED.[BuyerName],
	INSERTED.[BuyerTaxNumber],
	INSERTED.[BuyerAddressPhone],
	INSERTED.[BuyerBankAccount],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[BuyerCategoryID],
	INSERTED.[BuyerSocialCreditCode],
	INSERTED.[BuyerType]
into @table
VALUES ( 
	@BuyerName,
	@BuyerTaxNumber,
	@BuyerAddressPhone,
	@BuyerBankAccount,
	@AddTime,
	@GUID,
	@BuyerCategoryID,
	@BuyerSocialCreditCode,
	@BuyerType 
); 

SELECT 
	[ID],
	[BuyerName],
	[BuyerTaxNumber],
	[BuyerAddressPhone],
	[BuyerBankAccount],
	[AddTime],
	[GUID],
	[BuyerCategoryID],
	[BuyerSocialCreditCode],
	[BuyerType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@BuyerName", EntityBase.GetDatabaseValue(@buyerName)));
			parameters.Add(new SqlParameter("@BuyerTaxNumber", EntityBase.GetDatabaseValue(@buyerTaxNumber)));
			parameters.Add(new SqlParameter("@BuyerAddressPhone", EntityBase.GetDatabaseValue(@buyerAddressPhone)));
			parameters.Add(new SqlParameter("@BuyerBankAccount", EntityBase.GetDatabaseValue(@buyerBankAccount)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@BuyerCategoryID", EntityBase.GetDatabaseValue(@buyerCategoryID)));
			parameters.Add(new SqlParameter("@BuyerSocialCreditCode", EntityBase.GetDatabaseValue(@buyerSocialCreditCode)));
			parameters.Add(new SqlParameter("@BuyerType", EntityBase.GetDatabaseValue(@buyerType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_Buyer into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="buyerName">buyerName</param>
		/// <param name="buyerTaxNumber">buyerTaxNumber</param>
		/// <param name="buyerAddressPhone">buyerAddressPhone</param>
		/// <param name="buyerBankAccount">buyerBankAccount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="buyerCategoryID">buyerCategoryID</param>
		/// <param name="buyerSocialCreditCode">buyerSocialCreditCode</param>
		/// <param name="buyerType">buyerType</param>
		public static void UpdateCheque_Buyer(int @iD, string @buyerName, string @buyerTaxNumber, string @buyerAddressPhone, string @buyerBankAccount, DateTime @addTime, string @gUID, int @buyerCategoryID, string @buyerSocialCreditCode, string @buyerType)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_Buyer(@iD, @buyerName, @buyerTaxNumber, @buyerAddressPhone, @buyerBankAccount, @addTime, @gUID, @buyerCategoryID, @buyerSocialCreditCode, @buyerType, helper);
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
		/// Updates a Cheque_Buyer into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="buyerName">buyerName</param>
		/// <param name="buyerTaxNumber">buyerTaxNumber</param>
		/// <param name="buyerAddressPhone">buyerAddressPhone</param>
		/// <param name="buyerBankAccount">buyerBankAccount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="buyerCategoryID">buyerCategoryID</param>
		/// <param name="buyerSocialCreditCode">buyerSocialCreditCode</param>
		/// <param name="buyerType">buyerType</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_Buyer(int @iD, string @buyerName, string @buyerTaxNumber, string @buyerAddressPhone, string @buyerBankAccount, DateTime @addTime, string @gUID, int @buyerCategoryID, string @buyerSocialCreditCode, string @buyerType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BuyerName] nvarchar(200),
	[BuyerTaxNumber] nvarchar(100),
	[BuyerAddressPhone] nvarchar(50),
	[BuyerBankAccount] nvarchar(100),
	[AddTime] datetime,
	[GUID] nvarchar(200),
	[BuyerCategoryID] int,
	[BuyerSocialCreditCode] nvarchar(200),
	[BuyerType] nvarchar(50)
);

UPDATE [dbo].[Cheque_Buyer] SET 
	[Cheque_Buyer].[BuyerName] = @BuyerName,
	[Cheque_Buyer].[BuyerTaxNumber] = @BuyerTaxNumber,
	[Cheque_Buyer].[BuyerAddressPhone] = @BuyerAddressPhone,
	[Cheque_Buyer].[BuyerBankAccount] = @BuyerBankAccount,
	[Cheque_Buyer].[AddTime] = @AddTime,
	[Cheque_Buyer].[GUID] = @GUID,
	[Cheque_Buyer].[BuyerCategoryID] = @BuyerCategoryID,
	[Cheque_Buyer].[BuyerSocialCreditCode] = @BuyerSocialCreditCode,
	[Cheque_Buyer].[BuyerType] = @BuyerType 
output 
	INSERTED.[ID],
	INSERTED.[BuyerName],
	INSERTED.[BuyerTaxNumber],
	INSERTED.[BuyerAddressPhone],
	INSERTED.[BuyerBankAccount],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[BuyerCategoryID],
	INSERTED.[BuyerSocialCreditCode],
	INSERTED.[BuyerType]
into @table
WHERE 
	[Cheque_Buyer].[ID] = @ID

SELECT 
	[ID],
	[BuyerName],
	[BuyerTaxNumber],
	[BuyerAddressPhone],
	[BuyerBankAccount],
	[AddTime],
	[GUID],
	[BuyerCategoryID],
	[BuyerSocialCreditCode],
	[BuyerType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@BuyerName", EntityBase.GetDatabaseValue(@buyerName)));
			parameters.Add(new SqlParameter("@BuyerTaxNumber", EntityBase.GetDatabaseValue(@buyerTaxNumber)));
			parameters.Add(new SqlParameter("@BuyerAddressPhone", EntityBase.GetDatabaseValue(@buyerAddressPhone)));
			parameters.Add(new SqlParameter("@BuyerBankAccount", EntityBase.GetDatabaseValue(@buyerBankAccount)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@BuyerCategoryID", EntityBase.GetDatabaseValue(@buyerCategoryID)));
			parameters.Add(new SqlParameter("@BuyerSocialCreditCode", EntityBase.GetDatabaseValue(@buyerSocialCreditCode)));
			parameters.Add(new SqlParameter("@BuyerType", EntityBase.GetDatabaseValue(@buyerType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_Buyer from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_Buyer(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_Buyer(@iD, helper);
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
		/// Deletes a Cheque_Buyer from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_Buyer(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_Buyer]
WHERE 
	[Cheque_Buyer].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_Buyer object.
		/// </summary>
		/// <returns>The newly created Cheque_Buyer object.</returns>
		public static Cheque_Buyer CreateCheque_Buyer()
		{
			return InitializeNew<Cheque_Buyer>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_Buyer by a Cheque_Buyer's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_Buyer</returns>
		public static Cheque_Buyer GetCheque_Buyer(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_Buyer.SelectFieldList + @"
FROM [dbo].[Cheque_Buyer] 
WHERE 
	[Cheque_Buyer].[ID] = @ID " + Cheque_Buyer.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_Buyer>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_Buyer by a Cheque_Buyer's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_Buyer</returns>
		public static Cheque_Buyer GetCheque_Buyer(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_Buyer.SelectFieldList + @"
FROM [dbo].[Cheque_Buyer] 
WHERE 
	[Cheque_Buyer].[ID] = @ID " + Cheque_Buyer.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_Buyer>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Buyer objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_Buyer objects.</returns>
		public static EntityList<Cheque_Buyer> GetCheque_Buyers()
		{
			string commandText = @"
SELECT " + Cheque_Buyer.SelectFieldList + "FROM [dbo].[Cheque_Buyer] " + Cheque_Buyer.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_Buyer>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_Buyer objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_Buyer objects.</returns>
        public static EntityList<Cheque_Buyer> GetCheque_Buyers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Buyer>(SelectFieldList, "FROM [dbo].[Cheque_Buyer]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_Buyer objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_Buyer objects.</returns>
        public static EntityList<Cheque_Buyer> GetCheque_Buyers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Buyer>(SelectFieldList, "FROM [dbo].[Cheque_Buyer]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_Buyer objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_Buyer objects.</returns>
		protected static EntityList<Cheque_Buyer> GetCheque_Buyers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Buyers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Buyer objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Buyer objects.</returns>
		protected static EntityList<Cheque_Buyer> GetCheque_Buyers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Buyers(string.Empty, where, parameters, Cheque_Buyer.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Buyer objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Buyer objects.</returns>
		protected static EntityList<Cheque_Buyer> GetCheque_Buyers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Buyers(prefix, where, parameters, Cheque_Buyer.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Buyer objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Buyer objects.</returns>
		protected static EntityList<Cheque_Buyer> GetCheque_Buyers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_Buyers(string.Empty, where, parameters, Cheque_Buyer.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Buyer objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Buyer objects.</returns>
		protected static EntityList<Cheque_Buyer> GetCheque_Buyers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_Buyers(prefix, where, parameters, Cheque_Buyer.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Buyer objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_Buyer objects.</returns>
		protected static EntityList<Cheque_Buyer> GetCheque_Buyers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_Buyer.SelectFieldList + "FROM [dbo].[Cheque_Buyer] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_Buyer>(reader);
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
        protected static EntityList<Cheque_Buyer> GetCheque_Buyers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Buyer>(SelectFieldList, "FROM [dbo].[Cheque_Buyer] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_Buyer objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_BuyerCount()
        {
            return GetCheque_BuyerCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_Buyer objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_BuyerCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_Buyer] " + where;

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
		public static partial class Cheque_Buyer_Properties
		{
			public const string ID = "ID";
			public const string BuyerName = "BuyerName";
			public const string BuyerTaxNumber = "BuyerTaxNumber";
			public const string BuyerAddressPhone = "BuyerAddressPhone";
			public const string BuyerBankAccount = "BuyerBankAccount";
			public const string AddTime = "AddTime";
			public const string GUID = "GUID";
			public const string BuyerCategoryID = "BuyerCategoryID";
			public const string BuyerSocialCreditCode = "BuyerSocialCreditCode";
			public const string BuyerType = "BuyerType";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"BuyerName" , "string:"},
    			 {"BuyerTaxNumber" , "string:"},
    			 {"BuyerAddressPhone" , "string:"},
    			 {"BuyerBankAccount" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"GUID" , "string:"},
    			 {"BuyerCategoryID" , "int:"},
    			 {"BuyerSocialCreditCode" , "string:"},
    			 {"BuyerType" , "string:"},
            };
		}
		#endregion
	}
}
