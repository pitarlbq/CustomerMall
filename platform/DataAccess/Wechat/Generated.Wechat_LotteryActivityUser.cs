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
	/// This object represents the properties and methods of a Wechat_LotteryActivityUser.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_LotteryActivityUser 
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
		private int _activityID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ActivityID
		{
			[DebuggerStepThrough()]
			get { return this._activityID; }
			set 
			{
				if (this._activityID != value) 
				{
					this._activityID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ActivityID");
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
		private string _creditCardNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CreditCardNumber
		{
			[DebuggerStepThrough()]
			get { return this._creditCardNumber; }
			set 
			{
				if (this._creditCardNumber != value) 
				{
					this._creditCardNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("CreditCardNumber");
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
		private int _userID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int UserID
		{
			[DebuggerStepThrough()]
			get { return this._userID; }
			set 
			{
				if (this._userID != value) 
				{
					this._userID = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserID");
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
		private string _indentCard = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string IndentCard
		{
			[DebuggerStepThrough()]
			get { return this._indentCard; }
			set 
			{
				if (this._indentCard != value) 
				{
					this._indentCard = value;
					this.IsDirty = true;	
					OnPropertyChanged("IndentCard");
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
	[ActivityID] int,
	[PhoneNumber] nvarchar(20),
	[CreditCardNumber] nvarchar(50),
	[OpenID] nvarchar(200),
	[UserID] int,
	[CustomerName] nvarchar(50),
	[IndentCard] nvarchar(50),
	[AddTime] datetime
);

INSERT INTO [dbo].[Wechat_LotteryActivityUser] (
	[Wechat_LotteryActivityUser].[ActivityID],
	[Wechat_LotteryActivityUser].[PhoneNumber],
	[Wechat_LotteryActivityUser].[CreditCardNumber],
	[Wechat_LotteryActivityUser].[OpenID],
	[Wechat_LotteryActivityUser].[UserID],
	[Wechat_LotteryActivityUser].[CustomerName],
	[Wechat_LotteryActivityUser].[IndentCard],
	[Wechat_LotteryActivityUser].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ActivityID],
	INSERTED.[PhoneNumber],
	INSERTED.[CreditCardNumber],
	INSERTED.[OpenID],
	INSERTED.[UserID],
	INSERTED.[CustomerName],
	INSERTED.[IndentCard],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@ActivityID,
	@PhoneNumber,
	@CreditCardNumber,
	@OpenID,
	@UserID,
	@CustomerName,
	@IndentCard,
	@AddTime 
); 

SELECT 
	[ID],
	[ActivityID],
	[PhoneNumber],
	[CreditCardNumber],
	[OpenID],
	[UserID],
	[CustomerName],
	[IndentCard],
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
	[ActivityID] int,
	[PhoneNumber] nvarchar(20),
	[CreditCardNumber] nvarchar(50),
	[OpenID] nvarchar(200),
	[UserID] int,
	[CustomerName] nvarchar(50),
	[IndentCard] nvarchar(50),
	[AddTime] datetime
);

UPDATE [dbo].[Wechat_LotteryActivityUser] SET 
	[Wechat_LotteryActivityUser].[ActivityID] = @ActivityID,
	[Wechat_LotteryActivityUser].[PhoneNumber] = @PhoneNumber,
	[Wechat_LotteryActivityUser].[CreditCardNumber] = @CreditCardNumber,
	[Wechat_LotteryActivityUser].[OpenID] = @OpenID,
	[Wechat_LotteryActivityUser].[UserID] = @UserID,
	[Wechat_LotteryActivityUser].[CustomerName] = @CustomerName,
	[Wechat_LotteryActivityUser].[IndentCard] = @IndentCard,
	[Wechat_LotteryActivityUser].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[ActivityID],
	INSERTED.[PhoneNumber],
	INSERTED.[CreditCardNumber],
	INSERTED.[OpenID],
	INSERTED.[UserID],
	INSERTED.[CustomerName],
	INSERTED.[IndentCard],
	INSERTED.[AddTime]
into @table
WHERE 
	[Wechat_LotteryActivityUser].[ID] = @ID

SELECT 
	[ID],
	[ActivityID],
	[PhoneNumber],
	[CreditCardNumber],
	[OpenID],
	[UserID],
	[CustomerName],
	[IndentCard],
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
DELETE FROM [dbo].[Wechat_LotteryActivityUser]
WHERE 
	[Wechat_LotteryActivityUser].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_LotteryActivityUser() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_LotteryActivityUser(this.ID));
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
	[Wechat_LotteryActivityUser].[ID],
	[Wechat_LotteryActivityUser].[ActivityID],
	[Wechat_LotteryActivityUser].[PhoneNumber],
	[Wechat_LotteryActivityUser].[CreditCardNumber],
	[Wechat_LotteryActivityUser].[OpenID],
	[Wechat_LotteryActivityUser].[UserID],
	[Wechat_LotteryActivityUser].[CustomerName],
	[Wechat_LotteryActivityUser].[IndentCard],
	[Wechat_LotteryActivityUser].[AddTime]
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
                return "Wechat_LotteryActivityUser";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_LotteryActivityUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="activityID">activityID</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="creditCardNumber">creditCardNumber</param>
		/// <param name="openID">openID</param>
		/// <param name="userID">userID</param>
		/// <param name="customerName">customerName</param>
		/// <param name="indentCard">indentCard</param>
		/// <param name="addTime">addTime</param>
		public static void InsertWechat_LotteryActivityUser(int @activityID, string @phoneNumber, string @creditCardNumber, string @openID, int @userID, string @customerName, string @indentCard, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_LotteryActivityUser(@activityID, @phoneNumber, @creditCardNumber, @openID, @userID, @customerName, @indentCard, @addTime, helper);
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
		/// Insert a Wechat_LotteryActivityUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="activityID">activityID</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="creditCardNumber">creditCardNumber</param>
		/// <param name="openID">openID</param>
		/// <param name="userID">userID</param>
		/// <param name="customerName">customerName</param>
		/// <param name="indentCard">indentCard</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_LotteryActivityUser(int @activityID, string @phoneNumber, string @creditCardNumber, string @openID, int @userID, string @customerName, string @indentCard, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ActivityID] int,
	[PhoneNumber] nvarchar(20),
	[CreditCardNumber] nvarchar(50),
	[OpenID] nvarchar(200),
	[UserID] int,
	[CustomerName] nvarchar(50),
	[IndentCard] nvarchar(50),
	[AddTime] datetime
);

INSERT INTO [dbo].[Wechat_LotteryActivityUser] (
	[Wechat_LotteryActivityUser].[ActivityID],
	[Wechat_LotteryActivityUser].[PhoneNumber],
	[Wechat_LotteryActivityUser].[CreditCardNumber],
	[Wechat_LotteryActivityUser].[OpenID],
	[Wechat_LotteryActivityUser].[UserID],
	[Wechat_LotteryActivityUser].[CustomerName],
	[Wechat_LotteryActivityUser].[IndentCard],
	[Wechat_LotteryActivityUser].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ActivityID],
	INSERTED.[PhoneNumber],
	INSERTED.[CreditCardNumber],
	INSERTED.[OpenID],
	INSERTED.[UserID],
	INSERTED.[CustomerName],
	INSERTED.[IndentCard],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@ActivityID,
	@PhoneNumber,
	@CreditCardNumber,
	@OpenID,
	@UserID,
	@CustomerName,
	@IndentCard,
	@AddTime 
); 

SELECT 
	[ID],
	[ActivityID],
	[PhoneNumber],
	[CreditCardNumber],
	[OpenID],
	[UserID],
	[CustomerName],
	[IndentCard],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ActivityID", EntityBase.GetDatabaseValue(@activityID)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@CreditCardNumber", EntityBase.GetDatabaseValue(@creditCardNumber)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@CustomerName", EntityBase.GetDatabaseValue(@customerName)));
			parameters.Add(new SqlParameter("@IndentCard", EntityBase.GetDatabaseValue(@indentCard)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_LotteryActivityUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="activityID">activityID</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="creditCardNumber">creditCardNumber</param>
		/// <param name="openID">openID</param>
		/// <param name="userID">userID</param>
		/// <param name="customerName">customerName</param>
		/// <param name="indentCard">indentCard</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateWechat_LotteryActivityUser(int @iD, int @activityID, string @phoneNumber, string @creditCardNumber, string @openID, int @userID, string @customerName, string @indentCard, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_LotteryActivityUser(@iD, @activityID, @phoneNumber, @creditCardNumber, @openID, @userID, @customerName, @indentCard, @addTime, helper);
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
		/// Updates a Wechat_LotteryActivityUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="activityID">activityID</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="creditCardNumber">creditCardNumber</param>
		/// <param name="openID">openID</param>
		/// <param name="userID">userID</param>
		/// <param name="customerName">customerName</param>
		/// <param name="indentCard">indentCard</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_LotteryActivityUser(int @iD, int @activityID, string @phoneNumber, string @creditCardNumber, string @openID, int @userID, string @customerName, string @indentCard, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ActivityID] int,
	[PhoneNumber] nvarchar(20),
	[CreditCardNumber] nvarchar(50),
	[OpenID] nvarchar(200),
	[UserID] int,
	[CustomerName] nvarchar(50),
	[IndentCard] nvarchar(50),
	[AddTime] datetime
);

UPDATE [dbo].[Wechat_LotteryActivityUser] SET 
	[Wechat_LotteryActivityUser].[ActivityID] = @ActivityID,
	[Wechat_LotteryActivityUser].[PhoneNumber] = @PhoneNumber,
	[Wechat_LotteryActivityUser].[CreditCardNumber] = @CreditCardNumber,
	[Wechat_LotteryActivityUser].[OpenID] = @OpenID,
	[Wechat_LotteryActivityUser].[UserID] = @UserID,
	[Wechat_LotteryActivityUser].[CustomerName] = @CustomerName,
	[Wechat_LotteryActivityUser].[IndentCard] = @IndentCard,
	[Wechat_LotteryActivityUser].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[ActivityID],
	INSERTED.[PhoneNumber],
	INSERTED.[CreditCardNumber],
	INSERTED.[OpenID],
	INSERTED.[UserID],
	INSERTED.[CustomerName],
	INSERTED.[IndentCard],
	INSERTED.[AddTime]
into @table
WHERE 
	[Wechat_LotteryActivityUser].[ID] = @ID

SELECT 
	[ID],
	[ActivityID],
	[PhoneNumber],
	[CreditCardNumber],
	[OpenID],
	[UserID],
	[CustomerName],
	[IndentCard],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ActivityID", EntityBase.GetDatabaseValue(@activityID)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@CreditCardNumber", EntityBase.GetDatabaseValue(@creditCardNumber)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@CustomerName", EntityBase.GetDatabaseValue(@customerName)));
			parameters.Add(new SqlParameter("@IndentCard", EntityBase.GetDatabaseValue(@indentCard)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_LotteryActivityUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_LotteryActivityUser(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_LotteryActivityUser(@iD, helper);
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
		/// Deletes a Wechat_LotteryActivityUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_LotteryActivityUser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_LotteryActivityUser]
WHERE 
	[Wechat_LotteryActivityUser].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_LotteryActivityUser object.
		/// </summary>
		/// <returns>The newly created Wechat_LotteryActivityUser object.</returns>
		public static Wechat_LotteryActivityUser CreateWechat_LotteryActivityUser()
		{
			return InitializeNew<Wechat_LotteryActivityUser>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_LotteryActivityUser by a Wechat_LotteryActivityUser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_LotteryActivityUser</returns>
		public static Wechat_LotteryActivityUser GetWechat_LotteryActivityUser(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_LotteryActivityUser.SelectFieldList + @"
FROM [dbo].[Wechat_LotteryActivityUser] 
WHERE 
	[Wechat_LotteryActivityUser].[ID] = @ID " + Wechat_LotteryActivityUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_LotteryActivityUser>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_LotteryActivityUser by a Wechat_LotteryActivityUser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_LotteryActivityUser</returns>
		public static Wechat_LotteryActivityUser GetWechat_LotteryActivityUser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_LotteryActivityUser.SelectFieldList + @"
FROM [dbo].[Wechat_LotteryActivityUser] 
WHERE 
	[Wechat_LotteryActivityUser].[ID] = @ID " + Wechat_LotteryActivityUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_LotteryActivityUser>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityUser objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_LotteryActivityUser objects.</returns>
		public static EntityList<Wechat_LotteryActivityUser> GetWechat_LotteryActivityUsers()
		{
			string commandText = @"
SELECT " + Wechat_LotteryActivityUser.SelectFieldList + "FROM [dbo].[Wechat_LotteryActivityUser] " + Wechat_LotteryActivityUser.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_LotteryActivityUser>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_LotteryActivityUser objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_LotteryActivityUser objects.</returns>
        public static EntityList<Wechat_LotteryActivityUser> GetWechat_LotteryActivityUsers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_LotteryActivityUser>(SelectFieldList, "FROM [dbo].[Wechat_LotteryActivityUser]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_LotteryActivityUser objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_LotteryActivityUser objects.</returns>
        public static EntityList<Wechat_LotteryActivityUser> GetWechat_LotteryActivityUsers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_LotteryActivityUser>(SelectFieldList, "FROM [dbo].[Wechat_LotteryActivityUser]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivityUser objects.</returns>
		protected static EntityList<Wechat_LotteryActivityUser> GetWechat_LotteryActivityUsers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_LotteryActivityUsers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivityUser objects.</returns>
		protected static EntityList<Wechat_LotteryActivityUser> GetWechat_LotteryActivityUsers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_LotteryActivityUsers(string.Empty, where, parameters, Wechat_LotteryActivityUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivityUser objects.</returns>
		protected static EntityList<Wechat_LotteryActivityUser> GetWechat_LotteryActivityUsers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_LotteryActivityUsers(prefix, where, parameters, Wechat_LotteryActivityUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivityUser objects.</returns>
		protected static EntityList<Wechat_LotteryActivityUser> GetWechat_LotteryActivityUsers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_LotteryActivityUsers(string.Empty, where, parameters, Wechat_LotteryActivityUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivityUser objects.</returns>
		protected static EntityList<Wechat_LotteryActivityUser> GetWechat_LotteryActivityUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_LotteryActivityUsers(prefix, where, parameters, Wechat_LotteryActivityUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityUser objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivityUser objects.</returns>
		protected static EntityList<Wechat_LotteryActivityUser> GetWechat_LotteryActivityUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_LotteryActivityUser.SelectFieldList + "FROM [dbo].[Wechat_LotteryActivityUser] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_LotteryActivityUser>(reader);
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
        protected static EntityList<Wechat_LotteryActivityUser> GetWechat_LotteryActivityUsers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_LotteryActivityUser>(SelectFieldList, "FROM [dbo].[Wechat_LotteryActivityUser] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_LotteryActivityUser objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_LotteryActivityUserCount()
        {
            return GetWechat_LotteryActivityUserCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_LotteryActivityUser objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_LotteryActivityUserCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_LotteryActivityUser] " + where;

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
		public static partial class Wechat_LotteryActivityUser_Properties
		{
			public const string ID = "ID";
			public const string ActivityID = "ActivityID";
			public const string PhoneNumber = "PhoneNumber";
			public const string CreditCardNumber = "CreditCardNumber";
			public const string OpenID = "OpenID";
			public const string UserID = "UserID";
			public const string CustomerName = "CustomerName";
			public const string IndentCard = "IndentCard";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ActivityID" , "int:"},
    			 {"PhoneNumber" , "string:"},
    			 {"CreditCardNumber" , "string:"},
    			 {"OpenID" , "string:"},
    			 {"UserID" , "int:"},
    			 {"CustomerName" , "string:"},
    			 {"IndentCard" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
