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
	/// This object represents the properties and methods of a Contract_ModifyLog.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Contract_ModifyLog 
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
		private string _modifyMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ModifyMan
		{
			[DebuggerStepThrough()]
			get { return this._modifyMan; }
			set 
			{
				if (this._modifyMan != value) 
				{
					this._modifyMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModifyMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _modifyTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ModifyTime
		{
			[DebuggerStepThrough()]
			get { return this._modifyTime; }
			set 
			{
				if (this._modifyTime != value) 
				{
					this._modifyTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModifyTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _modifyTitle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ModifyTitle
		{
			[DebuggerStepThrough()]
			get { return this._modifyTitle; }
			set 
			{
				if (this._modifyTitle != value) 
				{
					this._modifyTitle = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModifyTitle");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _oldValue = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OldValue
		{
			[DebuggerStepThrough()]
			get { return this._oldValue; }
			set 
			{
				if (this._oldValue != value) 
				{
					this._oldValue = value;
					this.IsDirty = true;	
					OnPropertyChanged("OldValue");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _newValue = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string NewValue
		{
			[DebuggerStepThrough()]
			get { return this._newValue; }
			set 
			{
				if (this._newValue != value) 
				{
					this._newValue = value;
					this.IsDirty = true;	
					OnPropertyChanged("NewValue");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _guid = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Guid
		{
			[DebuggerStepThrough()]
			get { return this._guid; }
			set 
			{
				if (this._guid != value) 
				{
					this._guid = value;
					this.IsDirty = true;	
					OnPropertyChanged("Guid");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _modifyContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ModifyContent
		{
			[DebuggerStepThrough()]
			get { return this._modifyContent; }
			set 
			{
				if (this._modifyContent != value) 
				{
					this._modifyContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModifyContent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _modifyType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ModifyType
		{
			[DebuggerStepThrough()]
			get { return this._modifyType; }
			set 
			{
				if (this._modifyType != value) 
				{
					this._modifyType = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModifyType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _contract_RoomChargeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Contract_RoomChargeID
		{
			[DebuggerStepThrough()]
			get { return this._contract_RoomChargeID; }
			set 
			{
				if (this._contract_RoomChargeID != value) 
				{
					this._contract_RoomChargeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("Contract_RoomChargeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _contract_RoomID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Contract_RoomID
		{
			[DebuggerStepThrough()]
			get { return this._contract_RoomID; }
			set 
			{
				if (this._contract_RoomID != value) 
				{
					this._contract_RoomID = value;
					this.IsDirty = true;	
					OnPropertyChanged("Contract_RoomID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _modifyTypeDesc = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ModifyTypeDesc
		{
			[DebuggerStepThrough()]
			get { return this._modifyTypeDesc; }
			set 
			{
				if (this._modifyTypeDesc != value) 
				{
					this._modifyTypeDesc = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModifyTypeDesc");
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
	[ModifyMan] nvarchar(50),
	[ModifyTime] datetime,
	[ModifyTitle] nvarchar(100),
	[OldValue] nvarchar(500),
	[NewValue] nvarchar(500),
	[Guid] nvarchar(200),
	[ModifyContent] ntext,
	[ModifyType] nvarchar(500),
	[Contract_RoomChargeID] int,
	[Contract_RoomID] int,
	[ModifyTypeDesc] nvarchar(500)
);

INSERT INTO [dbo].[Contract_ModifyLog] (
	[Contract_ModifyLog].[ContractID],
	[Contract_ModifyLog].[ModifyMan],
	[Contract_ModifyLog].[ModifyTime],
	[Contract_ModifyLog].[ModifyTitle],
	[Contract_ModifyLog].[OldValue],
	[Contract_ModifyLog].[NewValue],
	[Contract_ModifyLog].[Guid],
	[Contract_ModifyLog].[ModifyContent],
	[Contract_ModifyLog].[ModifyType],
	[Contract_ModifyLog].[Contract_RoomChargeID],
	[Contract_ModifyLog].[Contract_RoomID],
	[Contract_ModifyLog].[ModifyTypeDesc]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[ModifyMan],
	INSERTED.[ModifyTime],
	INSERTED.[ModifyTitle],
	INSERTED.[OldValue],
	INSERTED.[NewValue],
	INSERTED.[Guid],
	INSERTED.[ModifyContent],
	INSERTED.[ModifyType],
	INSERTED.[Contract_RoomChargeID],
	INSERTED.[Contract_RoomID],
	INSERTED.[ModifyTypeDesc]
into @table
VALUES ( 
	@ContractID,
	@ModifyMan,
	@ModifyTime,
	@ModifyTitle,
	@OldValue,
	@NewValue,
	@Guid,
	@ModifyContent,
	@ModifyType,
	@Contract_RoomChargeID,
	@Contract_RoomID,
	@ModifyTypeDesc 
); 

SELECT 
	[ID],
	[ContractID],
	[ModifyMan],
	[ModifyTime],
	[ModifyTitle],
	[OldValue],
	[NewValue],
	[Guid],
	[ModifyContent],
	[ModifyType],
	[Contract_RoomChargeID],
	[Contract_RoomID],
	[ModifyTypeDesc] 
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
	[ModifyMan] nvarchar(50),
	[ModifyTime] datetime,
	[ModifyTitle] nvarchar(100),
	[OldValue] nvarchar(500),
	[NewValue] nvarchar(500),
	[Guid] nvarchar(200),
	[ModifyContent] ntext,
	[ModifyType] nvarchar(500),
	[Contract_RoomChargeID] int,
	[Contract_RoomID] int,
	[ModifyTypeDesc] nvarchar(500)
);

UPDATE [dbo].[Contract_ModifyLog] SET 
	[Contract_ModifyLog].[ContractID] = @ContractID,
	[Contract_ModifyLog].[ModifyMan] = @ModifyMan,
	[Contract_ModifyLog].[ModifyTime] = @ModifyTime,
	[Contract_ModifyLog].[ModifyTitle] = @ModifyTitle,
	[Contract_ModifyLog].[OldValue] = @OldValue,
	[Contract_ModifyLog].[NewValue] = @NewValue,
	[Contract_ModifyLog].[Guid] = @Guid,
	[Contract_ModifyLog].[ModifyContent] = @ModifyContent,
	[Contract_ModifyLog].[ModifyType] = @ModifyType,
	[Contract_ModifyLog].[Contract_RoomChargeID] = @Contract_RoomChargeID,
	[Contract_ModifyLog].[Contract_RoomID] = @Contract_RoomID,
	[Contract_ModifyLog].[ModifyTypeDesc] = @ModifyTypeDesc 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[ModifyMan],
	INSERTED.[ModifyTime],
	INSERTED.[ModifyTitle],
	INSERTED.[OldValue],
	INSERTED.[NewValue],
	INSERTED.[Guid],
	INSERTED.[ModifyContent],
	INSERTED.[ModifyType],
	INSERTED.[Contract_RoomChargeID],
	INSERTED.[Contract_RoomID],
	INSERTED.[ModifyTypeDesc]
into @table
WHERE 
	[Contract_ModifyLog].[ID] = @ID

SELECT 
	[ID],
	[ContractID],
	[ModifyMan],
	[ModifyTime],
	[ModifyTitle],
	[OldValue],
	[NewValue],
	[Guid],
	[ModifyContent],
	[ModifyType],
	[Contract_RoomChargeID],
	[Contract_RoomID],
	[ModifyTypeDesc] 
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
DELETE FROM [dbo].[Contract_ModifyLog]
WHERE 
	[Contract_ModifyLog].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Contract_ModifyLog() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetContract_ModifyLog(this.ID));
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
	[Contract_ModifyLog].[ID],
	[Contract_ModifyLog].[ContractID],
	[Contract_ModifyLog].[ModifyMan],
	[Contract_ModifyLog].[ModifyTime],
	[Contract_ModifyLog].[ModifyTitle],
	[Contract_ModifyLog].[OldValue],
	[Contract_ModifyLog].[NewValue],
	[Contract_ModifyLog].[Guid],
	[Contract_ModifyLog].[ModifyContent],
	[Contract_ModifyLog].[ModifyType],
	[Contract_ModifyLog].[Contract_RoomChargeID],
	[Contract_ModifyLog].[Contract_RoomID],
	[Contract_ModifyLog].[ModifyTypeDesc]
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
                return "Contract_ModifyLog";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Contract_ModifyLog into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractID">contractID</param>
		/// <param name="modifyMan">modifyMan</param>
		/// <param name="modifyTime">modifyTime</param>
		/// <param name="modifyTitle">modifyTitle</param>
		/// <param name="oldValue">oldValue</param>
		/// <param name="newValue">newValue</param>
		/// <param name="guid">guid</param>
		/// <param name="modifyContent">modifyContent</param>
		/// <param name="modifyType">modifyType</param>
		/// <param name="contract_RoomChargeID">contract_RoomChargeID</param>
		/// <param name="contract_RoomID">contract_RoomID</param>
		/// <param name="modifyTypeDesc">modifyTypeDesc</param>
		public static void InsertContract_ModifyLog(int @contractID, string @modifyMan, DateTime @modifyTime, string @modifyTitle, string @oldValue, string @newValue, string @guid, string @modifyContent, string @modifyType, int @contract_RoomChargeID, int @contract_RoomID, string @modifyTypeDesc)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertContract_ModifyLog(@contractID, @modifyMan, @modifyTime, @modifyTitle, @oldValue, @newValue, @guid, @modifyContent, @modifyType, @contract_RoomChargeID, @contract_RoomID, @modifyTypeDesc, helper);
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
		/// Insert a Contract_ModifyLog into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractID">contractID</param>
		/// <param name="modifyMan">modifyMan</param>
		/// <param name="modifyTime">modifyTime</param>
		/// <param name="modifyTitle">modifyTitle</param>
		/// <param name="oldValue">oldValue</param>
		/// <param name="newValue">newValue</param>
		/// <param name="guid">guid</param>
		/// <param name="modifyContent">modifyContent</param>
		/// <param name="modifyType">modifyType</param>
		/// <param name="contract_RoomChargeID">contract_RoomChargeID</param>
		/// <param name="contract_RoomID">contract_RoomID</param>
		/// <param name="modifyTypeDesc">modifyTypeDesc</param>
		/// <param name="helper">helper</param>
		internal static void InsertContract_ModifyLog(int @contractID, string @modifyMan, DateTime @modifyTime, string @modifyTitle, string @oldValue, string @newValue, string @guid, string @modifyContent, string @modifyType, int @contract_RoomChargeID, int @contract_RoomID, string @modifyTypeDesc, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractID] int,
	[ModifyMan] nvarchar(50),
	[ModifyTime] datetime,
	[ModifyTitle] nvarchar(100),
	[OldValue] nvarchar(500),
	[NewValue] nvarchar(500),
	[Guid] nvarchar(200),
	[ModifyContent] ntext,
	[ModifyType] nvarchar(500),
	[Contract_RoomChargeID] int,
	[Contract_RoomID] int,
	[ModifyTypeDesc] nvarchar(500)
);

INSERT INTO [dbo].[Contract_ModifyLog] (
	[Contract_ModifyLog].[ContractID],
	[Contract_ModifyLog].[ModifyMan],
	[Contract_ModifyLog].[ModifyTime],
	[Contract_ModifyLog].[ModifyTitle],
	[Contract_ModifyLog].[OldValue],
	[Contract_ModifyLog].[NewValue],
	[Contract_ModifyLog].[Guid],
	[Contract_ModifyLog].[ModifyContent],
	[Contract_ModifyLog].[ModifyType],
	[Contract_ModifyLog].[Contract_RoomChargeID],
	[Contract_ModifyLog].[Contract_RoomID],
	[Contract_ModifyLog].[ModifyTypeDesc]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[ModifyMan],
	INSERTED.[ModifyTime],
	INSERTED.[ModifyTitle],
	INSERTED.[OldValue],
	INSERTED.[NewValue],
	INSERTED.[Guid],
	INSERTED.[ModifyContent],
	INSERTED.[ModifyType],
	INSERTED.[Contract_RoomChargeID],
	INSERTED.[Contract_RoomID],
	INSERTED.[ModifyTypeDesc]
into @table
VALUES ( 
	@ContractID,
	@ModifyMan,
	@ModifyTime,
	@ModifyTitle,
	@OldValue,
	@NewValue,
	@Guid,
	@ModifyContent,
	@ModifyType,
	@Contract_RoomChargeID,
	@Contract_RoomID,
	@ModifyTypeDesc 
); 

SELECT 
	[ID],
	[ContractID],
	[ModifyMan],
	[ModifyTime],
	[ModifyTitle],
	[OldValue],
	[NewValue],
	[Guid],
	[ModifyContent],
	[ModifyType],
	[Contract_RoomChargeID],
	[Contract_RoomID],
	[ModifyTypeDesc] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@ModifyMan", EntityBase.GetDatabaseValue(@modifyMan)));
			parameters.Add(new SqlParameter("@ModifyTime", EntityBase.GetDatabaseValue(@modifyTime)));
			parameters.Add(new SqlParameter("@ModifyTitle", EntityBase.GetDatabaseValue(@modifyTitle)));
			parameters.Add(new SqlParameter("@OldValue", EntityBase.GetDatabaseValue(@oldValue)));
			parameters.Add(new SqlParameter("@NewValue", EntityBase.GetDatabaseValue(@newValue)));
			parameters.Add(new SqlParameter("@Guid", EntityBase.GetDatabaseValue(@guid)));
			parameters.Add(new SqlParameter("@ModifyContent", EntityBase.GetDatabaseValue(@modifyContent)));
			parameters.Add(new SqlParameter("@ModifyType", EntityBase.GetDatabaseValue(@modifyType)));
			parameters.Add(new SqlParameter("@Contract_RoomChargeID", EntityBase.GetDatabaseValue(@contract_RoomChargeID)));
			parameters.Add(new SqlParameter("@Contract_RoomID", EntityBase.GetDatabaseValue(@contract_RoomID)));
			parameters.Add(new SqlParameter("@ModifyTypeDesc", EntityBase.GetDatabaseValue(@modifyTypeDesc)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Contract_ModifyLog into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractID">contractID</param>
		/// <param name="modifyMan">modifyMan</param>
		/// <param name="modifyTime">modifyTime</param>
		/// <param name="modifyTitle">modifyTitle</param>
		/// <param name="oldValue">oldValue</param>
		/// <param name="newValue">newValue</param>
		/// <param name="guid">guid</param>
		/// <param name="modifyContent">modifyContent</param>
		/// <param name="modifyType">modifyType</param>
		/// <param name="contract_RoomChargeID">contract_RoomChargeID</param>
		/// <param name="contract_RoomID">contract_RoomID</param>
		/// <param name="modifyTypeDesc">modifyTypeDesc</param>
		public static void UpdateContract_ModifyLog(int @iD, int @contractID, string @modifyMan, DateTime @modifyTime, string @modifyTitle, string @oldValue, string @newValue, string @guid, string @modifyContent, string @modifyType, int @contract_RoomChargeID, int @contract_RoomID, string @modifyTypeDesc)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateContract_ModifyLog(@iD, @contractID, @modifyMan, @modifyTime, @modifyTitle, @oldValue, @newValue, @guid, @modifyContent, @modifyType, @contract_RoomChargeID, @contract_RoomID, @modifyTypeDesc, helper);
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
		/// Updates a Contract_ModifyLog into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractID">contractID</param>
		/// <param name="modifyMan">modifyMan</param>
		/// <param name="modifyTime">modifyTime</param>
		/// <param name="modifyTitle">modifyTitle</param>
		/// <param name="oldValue">oldValue</param>
		/// <param name="newValue">newValue</param>
		/// <param name="guid">guid</param>
		/// <param name="modifyContent">modifyContent</param>
		/// <param name="modifyType">modifyType</param>
		/// <param name="contract_RoomChargeID">contract_RoomChargeID</param>
		/// <param name="contract_RoomID">contract_RoomID</param>
		/// <param name="modifyTypeDesc">modifyTypeDesc</param>
		/// <param name="helper">helper</param>
		internal static void UpdateContract_ModifyLog(int @iD, int @contractID, string @modifyMan, DateTime @modifyTime, string @modifyTitle, string @oldValue, string @newValue, string @guid, string @modifyContent, string @modifyType, int @contract_RoomChargeID, int @contract_RoomID, string @modifyTypeDesc, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractID] int,
	[ModifyMan] nvarchar(50),
	[ModifyTime] datetime,
	[ModifyTitle] nvarchar(100),
	[OldValue] nvarchar(500),
	[NewValue] nvarchar(500),
	[Guid] nvarchar(200),
	[ModifyContent] ntext,
	[ModifyType] nvarchar(500),
	[Contract_RoomChargeID] int,
	[Contract_RoomID] int,
	[ModifyTypeDesc] nvarchar(500)
);

UPDATE [dbo].[Contract_ModifyLog] SET 
	[Contract_ModifyLog].[ContractID] = @ContractID,
	[Contract_ModifyLog].[ModifyMan] = @ModifyMan,
	[Contract_ModifyLog].[ModifyTime] = @ModifyTime,
	[Contract_ModifyLog].[ModifyTitle] = @ModifyTitle,
	[Contract_ModifyLog].[OldValue] = @OldValue,
	[Contract_ModifyLog].[NewValue] = @NewValue,
	[Contract_ModifyLog].[Guid] = @Guid,
	[Contract_ModifyLog].[ModifyContent] = @ModifyContent,
	[Contract_ModifyLog].[ModifyType] = @ModifyType,
	[Contract_ModifyLog].[Contract_RoomChargeID] = @Contract_RoomChargeID,
	[Contract_ModifyLog].[Contract_RoomID] = @Contract_RoomID,
	[Contract_ModifyLog].[ModifyTypeDesc] = @ModifyTypeDesc 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[ModifyMan],
	INSERTED.[ModifyTime],
	INSERTED.[ModifyTitle],
	INSERTED.[OldValue],
	INSERTED.[NewValue],
	INSERTED.[Guid],
	INSERTED.[ModifyContent],
	INSERTED.[ModifyType],
	INSERTED.[Contract_RoomChargeID],
	INSERTED.[Contract_RoomID],
	INSERTED.[ModifyTypeDesc]
into @table
WHERE 
	[Contract_ModifyLog].[ID] = @ID

SELECT 
	[ID],
	[ContractID],
	[ModifyMan],
	[ModifyTime],
	[ModifyTitle],
	[OldValue],
	[NewValue],
	[Guid],
	[ModifyContent],
	[ModifyType],
	[Contract_RoomChargeID],
	[Contract_RoomID],
	[ModifyTypeDesc] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@ModifyMan", EntityBase.GetDatabaseValue(@modifyMan)));
			parameters.Add(new SqlParameter("@ModifyTime", EntityBase.GetDatabaseValue(@modifyTime)));
			parameters.Add(new SqlParameter("@ModifyTitle", EntityBase.GetDatabaseValue(@modifyTitle)));
			parameters.Add(new SqlParameter("@OldValue", EntityBase.GetDatabaseValue(@oldValue)));
			parameters.Add(new SqlParameter("@NewValue", EntityBase.GetDatabaseValue(@newValue)));
			parameters.Add(new SqlParameter("@Guid", EntityBase.GetDatabaseValue(@guid)));
			parameters.Add(new SqlParameter("@ModifyContent", EntityBase.GetDatabaseValue(@modifyContent)));
			parameters.Add(new SqlParameter("@ModifyType", EntityBase.GetDatabaseValue(@modifyType)));
			parameters.Add(new SqlParameter("@Contract_RoomChargeID", EntityBase.GetDatabaseValue(@contract_RoomChargeID)));
			parameters.Add(new SqlParameter("@Contract_RoomID", EntityBase.GetDatabaseValue(@contract_RoomID)));
			parameters.Add(new SqlParameter("@ModifyTypeDesc", EntityBase.GetDatabaseValue(@modifyTypeDesc)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Contract_ModifyLog from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteContract_ModifyLog(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteContract_ModifyLog(@iD, helper);
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
		/// Deletes a Contract_ModifyLog from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteContract_ModifyLog(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Contract_ModifyLog]
WHERE 
	[Contract_ModifyLog].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Contract_ModifyLog object.
		/// </summary>
		/// <returns>The newly created Contract_ModifyLog object.</returns>
		public static Contract_ModifyLog CreateContract_ModifyLog()
		{
			return InitializeNew<Contract_ModifyLog>();
		}
		
		/// <summary>
		/// Retrieve information for a Contract_ModifyLog by a Contract_ModifyLog's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Contract_ModifyLog</returns>
		public static Contract_ModifyLog GetContract_ModifyLog(int @iD)
		{
			string commandText = @"
SELECT 
" + Contract_ModifyLog.SelectFieldList + @"
FROM [dbo].[Contract_ModifyLog] 
WHERE 
	[Contract_ModifyLog].[ID] = @ID " + Contract_ModifyLog.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_ModifyLog>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Contract_ModifyLog by a Contract_ModifyLog's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Contract_ModifyLog</returns>
		public static Contract_ModifyLog GetContract_ModifyLog(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Contract_ModifyLog.SelectFieldList + @"
FROM [dbo].[Contract_ModifyLog] 
WHERE 
	[Contract_ModifyLog].[ID] = @ID " + Contract_ModifyLog.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_ModifyLog>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Contract_ModifyLog objects.
		/// </summary>
		/// <returns>The retrieved collection of Contract_ModifyLog objects.</returns>
		public static EntityList<Contract_ModifyLog> GetContract_ModifyLogs()
		{
			string commandText = @"
SELECT " + Contract_ModifyLog.SelectFieldList + "FROM [dbo].[Contract_ModifyLog] " + Contract_ModifyLog.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Contract_ModifyLog>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Contract_ModifyLog objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_ModifyLog objects.</returns>
        public static EntityList<Contract_ModifyLog> GetContract_ModifyLogs(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_ModifyLog>(SelectFieldList, "FROM [dbo].[Contract_ModifyLog]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Contract_ModifyLog objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_ModifyLog objects.</returns>
        public static EntityList<Contract_ModifyLog> GetContract_ModifyLogs(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_ModifyLog>(SelectFieldList, "FROM [dbo].[Contract_ModifyLog]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Contract_ModifyLog objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Contract_ModifyLog objects.</returns>
		protected static EntityList<Contract_ModifyLog> GetContract_ModifyLogs(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_ModifyLogs(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Contract_ModifyLog objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_ModifyLog objects.</returns>
		protected static EntityList<Contract_ModifyLog> GetContract_ModifyLogs(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_ModifyLogs(string.Empty, where, parameters, Contract_ModifyLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_ModifyLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_ModifyLog objects.</returns>
		protected static EntityList<Contract_ModifyLog> GetContract_ModifyLogs(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_ModifyLogs(prefix, where, parameters, Contract_ModifyLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_ModifyLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_ModifyLog objects.</returns>
		protected static EntityList<Contract_ModifyLog> GetContract_ModifyLogs(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_ModifyLogs(string.Empty, where, parameters, Contract_ModifyLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_ModifyLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_ModifyLog objects.</returns>
		protected static EntityList<Contract_ModifyLog> GetContract_ModifyLogs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_ModifyLogs(prefix, where, parameters, Contract_ModifyLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_ModifyLog objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Contract_ModifyLog objects.</returns>
		protected static EntityList<Contract_ModifyLog> GetContract_ModifyLogs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Contract_ModifyLog.SelectFieldList + "FROM [dbo].[Contract_ModifyLog] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Contract_ModifyLog>(reader);
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
        protected static EntityList<Contract_ModifyLog> GetContract_ModifyLogs(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_ModifyLog>(SelectFieldList, "FROM [dbo].[Contract_ModifyLog] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Contract_ModifyLog objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_ModifyLogCount()
        {
            return GetContract_ModifyLogCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Contract_ModifyLog objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_ModifyLogCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Contract_ModifyLog] " + where;

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
		public static partial class Contract_ModifyLog_Properties
		{
			public const string ID = "ID";
			public const string ContractID = "ContractID";
			public const string ModifyMan = "ModifyMan";
			public const string ModifyTime = "ModifyTime";
			public const string ModifyTitle = "ModifyTitle";
			public const string OldValue = "OldValue";
			public const string NewValue = "NewValue";
			public const string Guid = "Guid";
			public const string ModifyContent = "ModifyContent";
			public const string ModifyType = "ModifyType";
			public const string Contract_RoomChargeID = "Contract_RoomChargeID";
			public const string Contract_RoomID = "Contract_RoomID";
			public const string ModifyTypeDesc = "ModifyTypeDesc";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ContractID" , "int:"},
    			 {"ModifyMan" , "string:"},
    			 {"ModifyTime" , "DateTime:"},
    			 {"ModifyTitle" , "string:"},
    			 {"OldValue" , "string:"},
    			 {"NewValue" , "string:"},
    			 {"Guid" , "string:"},
    			 {"ModifyContent" , "string:"},
    			 {"ModifyType" , "string:"},
    			 {"Contract_RoomChargeID" , "int:"},
    			 {"Contract_RoomID" , "int:"},
    			 {"ModifyTypeDesc" , "string:"},
            };
		}
		#endregion
	}
}
