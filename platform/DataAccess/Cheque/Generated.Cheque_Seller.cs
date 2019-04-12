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
	/// This object represents the properties and methods of a Cheque_Seller.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_Seller 
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
			set 
			{
				if (this._sellerName != value) 
				{
					this._sellerName = value;
					this.IsDirty = true;	
					OnPropertyChanged("SellerName");
				}
			}
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
			set 
			{
				if (this._sellerTaxNumber != value) 
				{
					this._sellerTaxNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("SellerTaxNumber");
				}
			}
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
			set 
			{
				if (this._sellerAddressPhone != value) 
				{
					this._sellerAddressPhone = value;
					this.IsDirty = true;	
					OnPropertyChanged("SellerAddressPhone");
				}
			}
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
			set 
			{
				if (this._sellerBankAccount != value) 
				{
					this._sellerBankAccount = value;
					this.IsDirty = true;	
					OnPropertyChanged("SellerBankAccount");
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
		private string _sellerSocialCreditCode = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SellerSocialCreditCode
		{
			[DebuggerStepThrough()]
			get { return this._sellerSocialCreditCode; }
			set 
			{
				if (this._sellerSocialCreditCode != value) 
				{
					this._sellerSocialCreditCode = value;
					this.IsDirty = true;	
					OnPropertyChanged("SellerSocialCreditCode");
				}
			}
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
			set 
			{
				if (this._sellerCategoryID != value) 
				{
					this._sellerCategoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("SellerCategoryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sellerType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SellerType
		{
			[DebuggerStepThrough()]
			get { return this._sellerType; }
			set 
			{
				if (this._sellerType != value) 
				{
					this._sellerType = value;
					this.IsDirty = true;	
					OnPropertyChanged("SellerType");
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
	[SellerName] nvarchar(200),
	[SellerTaxNumber] nvarchar(100),
	[SellerAddressPhone] nvarchar(50),
	[SellerBankAccount] nvarchar(100),
	[AddTime] datetime,
	[GUID] nvarchar(200),
	[SellerSocialCreditCode] nvarchar(200),
	[SellerCategoryID] int,
	[SellerType] nvarchar(50)
);

INSERT INTO [dbo].[Cheque_Seller] (
	[Cheque_Seller].[SellerName],
	[Cheque_Seller].[SellerTaxNumber],
	[Cheque_Seller].[SellerAddressPhone],
	[Cheque_Seller].[SellerBankAccount],
	[Cheque_Seller].[AddTime],
	[Cheque_Seller].[GUID],
	[Cheque_Seller].[SellerSocialCreditCode],
	[Cheque_Seller].[SellerCategoryID],
	[Cheque_Seller].[SellerType]
) 
output 
	INSERTED.[ID],
	INSERTED.[SellerName],
	INSERTED.[SellerTaxNumber],
	INSERTED.[SellerAddressPhone],
	INSERTED.[SellerBankAccount],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[SellerSocialCreditCode],
	INSERTED.[SellerCategoryID],
	INSERTED.[SellerType]
into @table
VALUES ( 
	@SellerName,
	@SellerTaxNumber,
	@SellerAddressPhone,
	@SellerBankAccount,
	@AddTime,
	@GUID,
	@SellerSocialCreditCode,
	@SellerCategoryID,
	@SellerType 
); 

SELECT 
	[ID],
	[SellerName],
	[SellerTaxNumber],
	[SellerAddressPhone],
	[SellerBankAccount],
	[AddTime],
	[GUID],
	[SellerSocialCreditCode],
	[SellerCategoryID],
	[SellerType] 
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
	[SellerName] nvarchar(200),
	[SellerTaxNumber] nvarchar(100),
	[SellerAddressPhone] nvarchar(50),
	[SellerBankAccount] nvarchar(100),
	[AddTime] datetime,
	[GUID] nvarchar(200),
	[SellerSocialCreditCode] nvarchar(200),
	[SellerCategoryID] int,
	[SellerType] nvarchar(50)
);

UPDATE [dbo].[Cheque_Seller] SET 
	[Cheque_Seller].[SellerName] = @SellerName,
	[Cheque_Seller].[SellerTaxNumber] = @SellerTaxNumber,
	[Cheque_Seller].[SellerAddressPhone] = @SellerAddressPhone,
	[Cheque_Seller].[SellerBankAccount] = @SellerBankAccount,
	[Cheque_Seller].[AddTime] = @AddTime,
	[Cheque_Seller].[GUID] = @GUID,
	[Cheque_Seller].[SellerSocialCreditCode] = @SellerSocialCreditCode,
	[Cheque_Seller].[SellerCategoryID] = @SellerCategoryID,
	[Cheque_Seller].[SellerType] = @SellerType 
output 
	INSERTED.[ID],
	INSERTED.[SellerName],
	INSERTED.[SellerTaxNumber],
	INSERTED.[SellerAddressPhone],
	INSERTED.[SellerBankAccount],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[SellerSocialCreditCode],
	INSERTED.[SellerCategoryID],
	INSERTED.[SellerType]
into @table
WHERE 
	[Cheque_Seller].[ID] = @ID

SELECT 
	[ID],
	[SellerName],
	[SellerTaxNumber],
	[SellerAddressPhone],
	[SellerBankAccount],
	[AddTime],
	[GUID],
	[SellerSocialCreditCode],
	[SellerCategoryID],
	[SellerType] 
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
DELETE FROM [dbo].[Cheque_Seller]
WHERE 
	[Cheque_Seller].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_Seller() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_Seller(this.ID));
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
	[Cheque_Seller].[ID],
	[Cheque_Seller].[SellerName],
	[Cheque_Seller].[SellerTaxNumber],
	[Cheque_Seller].[SellerAddressPhone],
	[Cheque_Seller].[SellerBankAccount],
	[Cheque_Seller].[AddTime],
	[Cheque_Seller].[GUID],
	[Cheque_Seller].[SellerSocialCreditCode],
	[Cheque_Seller].[SellerCategoryID],
	[Cheque_Seller].[SellerType]
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
                return "Cheque_Seller";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_Seller into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="sellerName">sellerName</param>
		/// <param name="sellerTaxNumber">sellerTaxNumber</param>
		/// <param name="sellerAddressPhone">sellerAddressPhone</param>
		/// <param name="sellerBankAccount">sellerBankAccount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="sellerSocialCreditCode">sellerSocialCreditCode</param>
		/// <param name="sellerCategoryID">sellerCategoryID</param>
		/// <param name="sellerType">sellerType</param>
		public static void InsertCheque_Seller(string @sellerName, string @sellerTaxNumber, string @sellerAddressPhone, string @sellerBankAccount, DateTime @addTime, string @gUID, string @sellerSocialCreditCode, int @sellerCategoryID, string @sellerType)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_Seller(@sellerName, @sellerTaxNumber, @sellerAddressPhone, @sellerBankAccount, @addTime, @gUID, @sellerSocialCreditCode, @sellerCategoryID, @sellerType, helper);
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
		/// Insert a Cheque_Seller into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="sellerName">sellerName</param>
		/// <param name="sellerTaxNumber">sellerTaxNumber</param>
		/// <param name="sellerAddressPhone">sellerAddressPhone</param>
		/// <param name="sellerBankAccount">sellerBankAccount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="sellerSocialCreditCode">sellerSocialCreditCode</param>
		/// <param name="sellerCategoryID">sellerCategoryID</param>
		/// <param name="sellerType">sellerType</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_Seller(string @sellerName, string @sellerTaxNumber, string @sellerAddressPhone, string @sellerBankAccount, DateTime @addTime, string @gUID, string @sellerSocialCreditCode, int @sellerCategoryID, string @sellerType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SellerName] nvarchar(200),
	[SellerTaxNumber] nvarchar(100),
	[SellerAddressPhone] nvarchar(50),
	[SellerBankAccount] nvarchar(100),
	[AddTime] datetime,
	[GUID] nvarchar(200),
	[SellerSocialCreditCode] nvarchar(200),
	[SellerCategoryID] int,
	[SellerType] nvarchar(50)
);

INSERT INTO [dbo].[Cheque_Seller] (
	[Cheque_Seller].[SellerName],
	[Cheque_Seller].[SellerTaxNumber],
	[Cheque_Seller].[SellerAddressPhone],
	[Cheque_Seller].[SellerBankAccount],
	[Cheque_Seller].[AddTime],
	[Cheque_Seller].[GUID],
	[Cheque_Seller].[SellerSocialCreditCode],
	[Cheque_Seller].[SellerCategoryID],
	[Cheque_Seller].[SellerType]
) 
output 
	INSERTED.[ID],
	INSERTED.[SellerName],
	INSERTED.[SellerTaxNumber],
	INSERTED.[SellerAddressPhone],
	INSERTED.[SellerBankAccount],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[SellerSocialCreditCode],
	INSERTED.[SellerCategoryID],
	INSERTED.[SellerType]
into @table
VALUES ( 
	@SellerName,
	@SellerTaxNumber,
	@SellerAddressPhone,
	@SellerBankAccount,
	@AddTime,
	@GUID,
	@SellerSocialCreditCode,
	@SellerCategoryID,
	@SellerType 
); 

SELECT 
	[ID],
	[SellerName],
	[SellerTaxNumber],
	[SellerAddressPhone],
	[SellerBankAccount],
	[AddTime],
	[GUID],
	[SellerSocialCreditCode],
	[SellerCategoryID],
	[SellerType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@SellerName", EntityBase.GetDatabaseValue(@sellerName)));
			parameters.Add(new SqlParameter("@SellerTaxNumber", EntityBase.GetDatabaseValue(@sellerTaxNumber)));
			parameters.Add(new SqlParameter("@SellerAddressPhone", EntityBase.GetDatabaseValue(@sellerAddressPhone)));
			parameters.Add(new SqlParameter("@SellerBankAccount", EntityBase.GetDatabaseValue(@sellerBankAccount)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@SellerSocialCreditCode", EntityBase.GetDatabaseValue(@sellerSocialCreditCode)));
			parameters.Add(new SqlParameter("@SellerCategoryID", EntityBase.GetDatabaseValue(@sellerCategoryID)));
			parameters.Add(new SqlParameter("@SellerType", EntityBase.GetDatabaseValue(@sellerType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_Seller into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="sellerName">sellerName</param>
		/// <param name="sellerTaxNumber">sellerTaxNumber</param>
		/// <param name="sellerAddressPhone">sellerAddressPhone</param>
		/// <param name="sellerBankAccount">sellerBankAccount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="sellerSocialCreditCode">sellerSocialCreditCode</param>
		/// <param name="sellerCategoryID">sellerCategoryID</param>
		/// <param name="sellerType">sellerType</param>
		public static void UpdateCheque_Seller(int @iD, string @sellerName, string @sellerTaxNumber, string @sellerAddressPhone, string @sellerBankAccount, DateTime @addTime, string @gUID, string @sellerSocialCreditCode, int @sellerCategoryID, string @sellerType)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_Seller(@iD, @sellerName, @sellerTaxNumber, @sellerAddressPhone, @sellerBankAccount, @addTime, @gUID, @sellerSocialCreditCode, @sellerCategoryID, @sellerType, helper);
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
		/// Updates a Cheque_Seller into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="sellerName">sellerName</param>
		/// <param name="sellerTaxNumber">sellerTaxNumber</param>
		/// <param name="sellerAddressPhone">sellerAddressPhone</param>
		/// <param name="sellerBankAccount">sellerBankAccount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="sellerSocialCreditCode">sellerSocialCreditCode</param>
		/// <param name="sellerCategoryID">sellerCategoryID</param>
		/// <param name="sellerType">sellerType</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_Seller(int @iD, string @sellerName, string @sellerTaxNumber, string @sellerAddressPhone, string @sellerBankAccount, DateTime @addTime, string @gUID, string @sellerSocialCreditCode, int @sellerCategoryID, string @sellerType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SellerName] nvarchar(200),
	[SellerTaxNumber] nvarchar(100),
	[SellerAddressPhone] nvarchar(50),
	[SellerBankAccount] nvarchar(100),
	[AddTime] datetime,
	[GUID] nvarchar(200),
	[SellerSocialCreditCode] nvarchar(200),
	[SellerCategoryID] int,
	[SellerType] nvarchar(50)
);

UPDATE [dbo].[Cheque_Seller] SET 
	[Cheque_Seller].[SellerName] = @SellerName,
	[Cheque_Seller].[SellerTaxNumber] = @SellerTaxNumber,
	[Cheque_Seller].[SellerAddressPhone] = @SellerAddressPhone,
	[Cheque_Seller].[SellerBankAccount] = @SellerBankAccount,
	[Cheque_Seller].[AddTime] = @AddTime,
	[Cheque_Seller].[GUID] = @GUID,
	[Cheque_Seller].[SellerSocialCreditCode] = @SellerSocialCreditCode,
	[Cheque_Seller].[SellerCategoryID] = @SellerCategoryID,
	[Cheque_Seller].[SellerType] = @SellerType 
output 
	INSERTED.[ID],
	INSERTED.[SellerName],
	INSERTED.[SellerTaxNumber],
	INSERTED.[SellerAddressPhone],
	INSERTED.[SellerBankAccount],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[SellerSocialCreditCode],
	INSERTED.[SellerCategoryID],
	INSERTED.[SellerType]
into @table
WHERE 
	[Cheque_Seller].[ID] = @ID

SELECT 
	[ID],
	[SellerName],
	[SellerTaxNumber],
	[SellerAddressPhone],
	[SellerBankAccount],
	[AddTime],
	[GUID],
	[SellerSocialCreditCode],
	[SellerCategoryID],
	[SellerType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@SellerName", EntityBase.GetDatabaseValue(@sellerName)));
			parameters.Add(new SqlParameter("@SellerTaxNumber", EntityBase.GetDatabaseValue(@sellerTaxNumber)));
			parameters.Add(new SqlParameter("@SellerAddressPhone", EntityBase.GetDatabaseValue(@sellerAddressPhone)));
			parameters.Add(new SqlParameter("@SellerBankAccount", EntityBase.GetDatabaseValue(@sellerBankAccount)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@SellerSocialCreditCode", EntityBase.GetDatabaseValue(@sellerSocialCreditCode)));
			parameters.Add(new SqlParameter("@SellerCategoryID", EntityBase.GetDatabaseValue(@sellerCategoryID)));
			parameters.Add(new SqlParameter("@SellerType", EntityBase.GetDatabaseValue(@sellerType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_Seller from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_Seller(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_Seller(@iD, helper);
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
		/// Deletes a Cheque_Seller from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_Seller(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_Seller]
WHERE 
	[Cheque_Seller].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_Seller object.
		/// </summary>
		/// <returns>The newly created Cheque_Seller object.</returns>
		public static Cheque_Seller CreateCheque_Seller()
		{
			return InitializeNew<Cheque_Seller>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_Seller by a Cheque_Seller's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_Seller</returns>
		public static Cheque_Seller GetCheque_Seller(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_Seller.SelectFieldList + @"
FROM [dbo].[Cheque_Seller] 
WHERE 
	[Cheque_Seller].[ID] = @ID " + Cheque_Seller.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_Seller>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_Seller by a Cheque_Seller's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_Seller</returns>
		public static Cheque_Seller GetCheque_Seller(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_Seller.SelectFieldList + @"
FROM [dbo].[Cheque_Seller] 
WHERE 
	[Cheque_Seller].[ID] = @ID " + Cheque_Seller.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_Seller>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Seller objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_Seller objects.</returns>
		public static EntityList<Cheque_Seller> GetCheque_Sellers()
		{
			string commandText = @"
SELECT " + Cheque_Seller.SelectFieldList + "FROM [dbo].[Cheque_Seller] " + Cheque_Seller.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_Seller>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_Seller objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_Seller objects.</returns>
        public static EntityList<Cheque_Seller> GetCheque_Sellers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Seller>(SelectFieldList, "FROM [dbo].[Cheque_Seller]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_Seller objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_Seller objects.</returns>
        public static EntityList<Cheque_Seller> GetCheque_Sellers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Seller>(SelectFieldList, "FROM [dbo].[Cheque_Seller]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_Seller objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_Seller objects.</returns>
		protected static EntityList<Cheque_Seller> GetCheque_Sellers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Sellers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Seller objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Seller objects.</returns>
		protected static EntityList<Cheque_Seller> GetCheque_Sellers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Sellers(string.Empty, where, parameters, Cheque_Seller.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Seller objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Seller objects.</returns>
		protected static EntityList<Cheque_Seller> GetCheque_Sellers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Sellers(prefix, where, parameters, Cheque_Seller.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Seller objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Seller objects.</returns>
		protected static EntityList<Cheque_Seller> GetCheque_Sellers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_Sellers(string.Empty, where, parameters, Cheque_Seller.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Seller objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Seller objects.</returns>
		protected static EntityList<Cheque_Seller> GetCheque_Sellers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_Sellers(prefix, where, parameters, Cheque_Seller.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Seller objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_Seller objects.</returns>
		protected static EntityList<Cheque_Seller> GetCheque_Sellers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_Seller.SelectFieldList + "FROM [dbo].[Cheque_Seller] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_Seller>(reader);
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
        protected static EntityList<Cheque_Seller> GetCheque_Sellers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Seller>(SelectFieldList, "FROM [dbo].[Cheque_Seller] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_Seller objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_SellerCount()
        {
            return GetCheque_SellerCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_Seller objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_SellerCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_Seller] " + where;

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
		public static partial class Cheque_Seller_Properties
		{
			public const string ID = "ID";
			public const string SellerName = "SellerName";
			public const string SellerTaxNumber = "SellerTaxNumber";
			public const string SellerAddressPhone = "SellerAddressPhone";
			public const string SellerBankAccount = "SellerBankAccount";
			public const string AddTime = "AddTime";
			public const string GUID = "GUID";
			public const string SellerSocialCreditCode = "SellerSocialCreditCode";
			public const string SellerCategoryID = "SellerCategoryID";
			public const string SellerType = "SellerType";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"SellerName" , "string:"},
    			 {"SellerTaxNumber" , "string:"},
    			 {"SellerAddressPhone" , "string:"},
    			 {"SellerBankAccount" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"GUID" , "string:"},
    			 {"SellerSocialCreditCode" , "string:"},
    			 {"SellerCategoryID" , "int:"},
    			 {"SellerType" , "string:"},
            };
		}
		#endregion
	}
}
