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
	/// This object represents the properties and methods of a Wechat_VerifyCode.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_VerifyCode 
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
		private string _mobilePhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string MobilePhone
		{
			[DebuggerStepThrough()]
			get { return this._mobilePhone; }
			set 
			{
				if (this._mobilePhone != value) 
				{
					this._mobilePhone = value;
					this.IsDirty = true;	
					OnPropertyChanged("MobilePhone");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _verifyCode = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string VerifyCode
		{
			[DebuggerStepThrough()]
			get { return this._verifyCode; }
			set 
			{
				if (this._verifyCode != value) 
				{
					this._verifyCode = value;
					this.IsDirty = true;	
					OnPropertyChanged("VerifyCode");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _expireTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime ExpireTime
		{
			[DebuggerStepThrough()]
			get { return this._expireTime; }
			set 
			{
				if (this._expireTime != value) 
				{
					this._expireTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ExpireTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _openID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OpenID
		{
			[DebuggerStepThrough()]
			get { return this._openID; }
			set 
			{
				if (this._openID != value) 
				{
					this._openID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OpenID");
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
		private bool _sendStatus = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool SendStatus
		{
			[DebuggerStepThrough()]
			get { return this._sendStatus; }
			set 
			{
				if (this._sendStatus != value) 
				{
					this._sendStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("SendStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sendResult = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SendResult
		{
			[DebuggerStepThrough()]
			get { return this._sendResult; }
			set 
			{
				if (this._sendResult != value) 
				{
					this._sendResult = value;
					this.IsDirty = true;	
					OnPropertyChanged("SendResult");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isUsed = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsUsed
		{
			[DebuggerStepThrough()]
			get { return this._isUsed; }
			set 
			{
				if (this._isUsed != value) 
				{
					this._isUsed = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsUsed");
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
	[MobilePhone] nvarchar(50),
	[VerifyCode] nvarchar(50),
	[ExpireTime] datetime,
	[OpenID] nvarchar(200),
	[AddTime] datetime,
	[SendStatus] bit,
	[SendResult] ntext,
	[IsUsed] bit
);

INSERT INTO [dbo].[Wechat_VerifyCode] (
	[Wechat_VerifyCode].[MobilePhone],
	[Wechat_VerifyCode].[VerifyCode],
	[Wechat_VerifyCode].[ExpireTime],
	[Wechat_VerifyCode].[OpenID],
	[Wechat_VerifyCode].[AddTime],
	[Wechat_VerifyCode].[SendStatus],
	[Wechat_VerifyCode].[SendResult],
	[Wechat_VerifyCode].[IsUsed]
) 
output 
	INSERTED.[ID],
	INSERTED.[MobilePhone],
	INSERTED.[VerifyCode],
	INSERTED.[ExpireTime],
	INSERTED.[OpenID],
	INSERTED.[AddTime],
	INSERTED.[SendStatus],
	INSERTED.[SendResult],
	INSERTED.[IsUsed]
into @table
VALUES ( 
	@MobilePhone,
	@VerifyCode,
	@ExpireTime,
	@OpenID,
	@AddTime,
	@SendStatus,
	@SendResult,
	@IsUsed 
); 

SELECT 
	[ID],
	[MobilePhone],
	[VerifyCode],
	[ExpireTime],
	[OpenID],
	[AddTime],
	[SendStatus],
	[SendResult],
	[IsUsed] 
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
	[MobilePhone] nvarchar(50),
	[VerifyCode] nvarchar(50),
	[ExpireTime] datetime,
	[OpenID] nvarchar(200),
	[AddTime] datetime,
	[SendStatus] bit,
	[SendResult] ntext,
	[IsUsed] bit
);

UPDATE [dbo].[Wechat_VerifyCode] SET 
	[Wechat_VerifyCode].[MobilePhone] = @MobilePhone,
	[Wechat_VerifyCode].[VerifyCode] = @VerifyCode,
	[Wechat_VerifyCode].[ExpireTime] = @ExpireTime,
	[Wechat_VerifyCode].[OpenID] = @OpenID,
	[Wechat_VerifyCode].[AddTime] = @AddTime,
	[Wechat_VerifyCode].[SendStatus] = @SendStatus,
	[Wechat_VerifyCode].[SendResult] = @SendResult,
	[Wechat_VerifyCode].[IsUsed] = @IsUsed 
output 
	INSERTED.[ID],
	INSERTED.[MobilePhone],
	INSERTED.[VerifyCode],
	INSERTED.[ExpireTime],
	INSERTED.[OpenID],
	INSERTED.[AddTime],
	INSERTED.[SendStatus],
	INSERTED.[SendResult],
	INSERTED.[IsUsed]
into @table
WHERE 
	[Wechat_VerifyCode].[ID] = @ID

SELECT 
	[ID],
	[MobilePhone],
	[VerifyCode],
	[ExpireTime],
	[OpenID],
	[AddTime],
	[SendStatus],
	[SendResult],
	[IsUsed] 
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
DELETE FROM [dbo].[Wechat_VerifyCode]
WHERE 
	[Wechat_VerifyCode].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_VerifyCode() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_VerifyCode(this.ID));
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
	[Wechat_VerifyCode].[ID],
	[Wechat_VerifyCode].[MobilePhone],
	[Wechat_VerifyCode].[VerifyCode],
	[Wechat_VerifyCode].[ExpireTime],
	[Wechat_VerifyCode].[OpenID],
	[Wechat_VerifyCode].[AddTime],
	[Wechat_VerifyCode].[SendStatus],
	[Wechat_VerifyCode].[SendResult],
	[Wechat_VerifyCode].[IsUsed]
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
                return "Wechat_VerifyCode";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_VerifyCode into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="mobilePhone">mobilePhone</param>
		/// <param name="verifyCode">verifyCode</param>
		/// <param name="expireTime">expireTime</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sendStatus">sendStatus</param>
		/// <param name="sendResult">sendResult</param>
		/// <param name="isUsed">isUsed</param>
		public static void InsertWechat_VerifyCode(string @mobilePhone, string @verifyCode, DateTime @expireTime, string @openID, DateTime @addTime, bool @sendStatus, string @sendResult, bool @isUsed)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_VerifyCode(@mobilePhone, @verifyCode, @expireTime, @openID, @addTime, @sendStatus, @sendResult, @isUsed, helper);
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
		/// Insert a Wechat_VerifyCode into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="mobilePhone">mobilePhone</param>
		/// <param name="verifyCode">verifyCode</param>
		/// <param name="expireTime">expireTime</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sendStatus">sendStatus</param>
		/// <param name="sendResult">sendResult</param>
		/// <param name="isUsed">isUsed</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_VerifyCode(string @mobilePhone, string @verifyCode, DateTime @expireTime, string @openID, DateTime @addTime, bool @sendStatus, string @sendResult, bool @isUsed, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[MobilePhone] nvarchar(50),
	[VerifyCode] nvarchar(50),
	[ExpireTime] datetime,
	[OpenID] nvarchar(200),
	[AddTime] datetime,
	[SendStatus] bit,
	[SendResult] ntext,
	[IsUsed] bit
);

INSERT INTO [dbo].[Wechat_VerifyCode] (
	[Wechat_VerifyCode].[MobilePhone],
	[Wechat_VerifyCode].[VerifyCode],
	[Wechat_VerifyCode].[ExpireTime],
	[Wechat_VerifyCode].[OpenID],
	[Wechat_VerifyCode].[AddTime],
	[Wechat_VerifyCode].[SendStatus],
	[Wechat_VerifyCode].[SendResult],
	[Wechat_VerifyCode].[IsUsed]
) 
output 
	INSERTED.[ID],
	INSERTED.[MobilePhone],
	INSERTED.[VerifyCode],
	INSERTED.[ExpireTime],
	INSERTED.[OpenID],
	INSERTED.[AddTime],
	INSERTED.[SendStatus],
	INSERTED.[SendResult],
	INSERTED.[IsUsed]
into @table
VALUES ( 
	@MobilePhone,
	@VerifyCode,
	@ExpireTime,
	@OpenID,
	@AddTime,
	@SendStatus,
	@SendResult,
	@IsUsed 
); 

SELECT 
	[ID],
	[MobilePhone],
	[VerifyCode],
	[ExpireTime],
	[OpenID],
	[AddTime],
	[SendStatus],
	[SendResult],
	[IsUsed] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@MobilePhone", EntityBase.GetDatabaseValue(@mobilePhone)));
			parameters.Add(new SqlParameter("@VerifyCode", EntityBase.GetDatabaseValue(@verifyCode)));
			parameters.Add(new SqlParameter("@ExpireTime", EntityBase.GetDatabaseValue(@expireTime)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@SendStatus", @sendStatus));
			parameters.Add(new SqlParameter("@SendResult", EntityBase.GetDatabaseValue(@sendResult)));
			parameters.Add(new SqlParameter("@IsUsed", @isUsed));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_VerifyCode into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="mobilePhone">mobilePhone</param>
		/// <param name="verifyCode">verifyCode</param>
		/// <param name="expireTime">expireTime</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sendStatus">sendStatus</param>
		/// <param name="sendResult">sendResult</param>
		/// <param name="isUsed">isUsed</param>
		public static void UpdateWechat_VerifyCode(int @iD, string @mobilePhone, string @verifyCode, DateTime @expireTime, string @openID, DateTime @addTime, bool @sendStatus, string @sendResult, bool @isUsed)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_VerifyCode(@iD, @mobilePhone, @verifyCode, @expireTime, @openID, @addTime, @sendStatus, @sendResult, @isUsed, helper);
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
		/// Updates a Wechat_VerifyCode into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="mobilePhone">mobilePhone</param>
		/// <param name="verifyCode">verifyCode</param>
		/// <param name="expireTime">expireTime</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sendStatus">sendStatus</param>
		/// <param name="sendResult">sendResult</param>
		/// <param name="isUsed">isUsed</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_VerifyCode(int @iD, string @mobilePhone, string @verifyCode, DateTime @expireTime, string @openID, DateTime @addTime, bool @sendStatus, string @sendResult, bool @isUsed, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[MobilePhone] nvarchar(50),
	[VerifyCode] nvarchar(50),
	[ExpireTime] datetime,
	[OpenID] nvarchar(200),
	[AddTime] datetime,
	[SendStatus] bit,
	[SendResult] ntext,
	[IsUsed] bit
);

UPDATE [dbo].[Wechat_VerifyCode] SET 
	[Wechat_VerifyCode].[MobilePhone] = @MobilePhone,
	[Wechat_VerifyCode].[VerifyCode] = @VerifyCode,
	[Wechat_VerifyCode].[ExpireTime] = @ExpireTime,
	[Wechat_VerifyCode].[OpenID] = @OpenID,
	[Wechat_VerifyCode].[AddTime] = @AddTime,
	[Wechat_VerifyCode].[SendStatus] = @SendStatus,
	[Wechat_VerifyCode].[SendResult] = @SendResult,
	[Wechat_VerifyCode].[IsUsed] = @IsUsed 
output 
	INSERTED.[ID],
	INSERTED.[MobilePhone],
	INSERTED.[VerifyCode],
	INSERTED.[ExpireTime],
	INSERTED.[OpenID],
	INSERTED.[AddTime],
	INSERTED.[SendStatus],
	INSERTED.[SendResult],
	INSERTED.[IsUsed]
into @table
WHERE 
	[Wechat_VerifyCode].[ID] = @ID

SELECT 
	[ID],
	[MobilePhone],
	[VerifyCode],
	[ExpireTime],
	[OpenID],
	[AddTime],
	[SendStatus],
	[SendResult],
	[IsUsed] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@MobilePhone", EntityBase.GetDatabaseValue(@mobilePhone)));
			parameters.Add(new SqlParameter("@VerifyCode", EntityBase.GetDatabaseValue(@verifyCode)));
			parameters.Add(new SqlParameter("@ExpireTime", EntityBase.GetDatabaseValue(@expireTime)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@SendStatus", @sendStatus));
			parameters.Add(new SqlParameter("@SendResult", EntityBase.GetDatabaseValue(@sendResult)));
			parameters.Add(new SqlParameter("@IsUsed", @isUsed));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_VerifyCode from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_VerifyCode(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_VerifyCode(@iD, helper);
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
		/// Deletes a Wechat_VerifyCode from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_VerifyCode(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_VerifyCode]
WHERE 
	[Wechat_VerifyCode].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_VerifyCode object.
		/// </summary>
		/// <returns>The newly created Wechat_VerifyCode object.</returns>
		public static Wechat_VerifyCode CreateWechat_VerifyCode()
		{
			return InitializeNew<Wechat_VerifyCode>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_VerifyCode by a Wechat_VerifyCode's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_VerifyCode</returns>
		public static Wechat_VerifyCode GetWechat_VerifyCode(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_VerifyCode.SelectFieldList + @"
FROM [dbo].[Wechat_VerifyCode] 
WHERE 
	[Wechat_VerifyCode].[ID] = @ID " + Wechat_VerifyCode.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_VerifyCode>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_VerifyCode by a Wechat_VerifyCode's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_VerifyCode</returns>
		public static Wechat_VerifyCode GetWechat_VerifyCode(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_VerifyCode.SelectFieldList + @"
FROM [dbo].[Wechat_VerifyCode] 
WHERE 
	[Wechat_VerifyCode].[ID] = @ID " + Wechat_VerifyCode.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_VerifyCode>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_VerifyCode objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_VerifyCode objects.</returns>
		public static EntityList<Wechat_VerifyCode> GetWechat_VerifyCodes()
		{
			string commandText = @"
SELECT " + Wechat_VerifyCode.SelectFieldList + "FROM [dbo].[Wechat_VerifyCode] " + Wechat_VerifyCode.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_VerifyCode>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_VerifyCode objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_VerifyCode objects.</returns>
        public static EntityList<Wechat_VerifyCode> GetWechat_VerifyCodes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_VerifyCode>(SelectFieldList, "FROM [dbo].[Wechat_VerifyCode]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_VerifyCode objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_VerifyCode objects.</returns>
        public static EntityList<Wechat_VerifyCode> GetWechat_VerifyCodes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_VerifyCode>(SelectFieldList, "FROM [dbo].[Wechat_VerifyCode]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_VerifyCode objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_VerifyCode objects.</returns>
		protected static EntityList<Wechat_VerifyCode> GetWechat_VerifyCodes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_VerifyCodes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_VerifyCode objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_VerifyCode objects.</returns>
		protected static EntityList<Wechat_VerifyCode> GetWechat_VerifyCodes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_VerifyCodes(string.Empty, where, parameters, Wechat_VerifyCode.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_VerifyCode objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_VerifyCode objects.</returns>
		protected static EntityList<Wechat_VerifyCode> GetWechat_VerifyCodes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_VerifyCodes(prefix, where, parameters, Wechat_VerifyCode.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_VerifyCode objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_VerifyCode objects.</returns>
		protected static EntityList<Wechat_VerifyCode> GetWechat_VerifyCodes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_VerifyCodes(string.Empty, where, parameters, Wechat_VerifyCode.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_VerifyCode objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_VerifyCode objects.</returns>
		protected static EntityList<Wechat_VerifyCode> GetWechat_VerifyCodes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_VerifyCodes(prefix, where, parameters, Wechat_VerifyCode.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_VerifyCode objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_VerifyCode objects.</returns>
		protected static EntityList<Wechat_VerifyCode> GetWechat_VerifyCodes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_VerifyCode.SelectFieldList + "FROM [dbo].[Wechat_VerifyCode] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_VerifyCode>(reader);
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
        protected static EntityList<Wechat_VerifyCode> GetWechat_VerifyCodes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_VerifyCode>(SelectFieldList, "FROM [dbo].[Wechat_VerifyCode] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_VerifyCode objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_VerifyCodeCount()
        {
            return GetWechat_VerifyCodeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_VerifyCode objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_VerifyCodeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_VerifyCode] " + where;

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
		public static partial class Wechat_VerifyCode_Properties
		{
			public const string ID = "ID";
			public const string MobilePhone = "MobilePhone";
			public const string VerifyCode = "VerifyCode";
			public const string ExpireTime = "ExpireTime";
			public const string OpenID = "OpenID";
			public const string AddTime = "AddTime";
			public const string SendStatus = "SendStatus";
			public const string SendResult = "SendResult";
			public const string IsUsed = "IsUsed";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"MobilePhone" , "string:"},
    			 {"VerifyCode" , "string:"},
    			 {"ExpireTime" , "DateTime:"},
    			 {"OpenID" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"SendStatus" , "bool:"},
    			 {"SendResult" , "string:"},
    			 {"IsUsed" , "bool:"},
            };
		}
		#endregion
	}
}
