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
	/// This object represents the properties and methods of a Mall_DoorCard.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_DoorCard 
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
		private int _projectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
			set 
			{
				if (this._projectName != value) 
				{
					this._projectName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectName");
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
		[DataObjectField(false, false, false)]
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
		private string _cardName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string CardName
		{
			[DebuggerStepThrough()]
			get { return this._cardName; }
			set 
			{
				if (this._cardName != value) 
				{
					this._cardName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CardName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _cardSummary = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CardSummary
		{
			[DebuggerStepThrough()]
			get { return this._cardSummary; }
			set 
			{
				if (this._cardSummary != value) 
				{
					this._cardSummary = value;
					this.IsDirty = true;	
					OnPropertyChanged("CardSummary");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _cardUID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string CardUID
		{
			[DebuggerStepThrough()]
			get { return this._cardUID; }
			set 
			{
				if (this._cardUID != value) 
				{
					this._cardUID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CardUID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _endDays = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int EndDays
		{
			[DebuggerStepThrough()]
			get { return this._endDays; }
			set 
			{
				if (this._endDays != value) 
				{
					this._endDays = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndDays");
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
		private int _sortOrder = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SortOrder
		{
			[DebuggerStepThrough()]
			get { return this._sortOrder; }
			set 
			{
				if (this._sortOrder != value) 
				{
					this._sortOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("SortOrder");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _doorNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DoorNumber
		{
			[DebuggerStepThrough()]
			get { return this._doorNumber; }
			set 
			{
				if (this._doorNumber != value) 
				{
					this._doorNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("DoorNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _roomPhoneRelationID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RoomPhoneRelationID
		{
			[DebuggerStepThrough()]
			get { return this._roomPhoneRelationID; }
			set 
			{
				if (this._roomPhoneRelationID != value) 
				{
					this._roomPhoneRelationID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomPhoneRelationID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _expireDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ExpireDate
		{
			[DebuggerStepThrough()]
			get { return this._expireDate; }
			set 
			{
				if (this._expireDate != value) 
				{
					this._expireDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("ExpireDate");
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
	[ProjectID] int,
	[ProjectName] nvarchar(500),
	[UserID] int,
	[CardName] nvarchar(200),
	[CardSummary] ntext,
	[CardUID] nvarchar(200),
	[EndDays] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[SortOrder] int,
	[DoorNumber] nvarchar(50),
	[RoomPhoneRelationID] int,
	[ExpireDate] datetime
);

INSERT INTO [dbo].[Mall_DoorCard] (
	[Mall_DoorCard].[ProjectID],
	[Mall_DoorCard].[ProjectName],
	[Mall_DoorCard].[UserID],
	[Mall_DoorCard].[CardName],
	[Mall_DoorCard].[CardSummary],
	[Mall_DoorCard].[CardUID],
	[Mall_DoorCard].[EndDays],
	[Mall_DoorCard].[AddTime],
	[Mall_DoorCard].[AddUserName],
	[Mall_DoorCard].[SortOrder],
	[Mall_DoorCard].[DoorNumber],
	[Mall_DoorCard].[RoomPhoneRelationID],
	[Mall_DoorCard].[ExpireDate]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[ProjectName],
	INSERTED.[UserID],
	INSERTED.[CardName],
	INSERTED.[CardSummary],
	INSERTED.[CardUID],
	INSERTED.[EndDays],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[SortOrder],
	INSERTED.[DoorNumber],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[ExpireDate]
into @table
VALUES ( 
	@ProjectID,
	@ProjectName,
	@UserID,
	@CardName,
	@CardSummary,
	@CardUID,
	@EndDays,
	@AddTime,
	@AddUserName,
	@SortOrder,
	@DoorNumber,
	@RoomPhoneRelationID,
	@ExpireDate 
); 

SELECT 
	[ID],
	[ProjectID],
	[ProjectName],
	[UserID],
	[CardName],
	[CardSummary],
	[CardUID],
	[EndDays],
	[AddTime],
	[AddUserName],
	[SortOrder],
	[DoorNumber],
	[RoomPhoneRelationID],
	[ExpireDate] 
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
	[ProjectID] int,
	[ProjectName] nvarchar(500),
	[UserID] int,
	[CardName] nvarchar(200),
	[CardSummary] ntext,
	[CardUID] nvarchar(200),
	[EndDays] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[SortOrder] int,
	[DoorNumber] nvarchar(50),
	[RoomPhoneRelationID] int,
	[ExpireDate] datetime
);

UPDATE [dbo].[Mall_DoorCard] SET 
	[Mall_DoorCard].[ProjectID] = @ProjectID,
	[Mall_DoorCard].[ProjectName] = @ProjectName,
	[Mall_DoorCard].[UserID] = @UserID,
	[Mall_DoorCard].[CardName] = @CardName,
	[Mall_DoorCard].[CardSummary] = @CardSummary,
	[Mall_DoorCard].[CardUID] = @CardUID,
	[Mall_DoorCard].[EndDays] = @EndDays,
	[Mall_DoorCard].[AddTime] = @AddTime,
	[Mall_DoorCard].[AddUserName] = @AddUserName,
	[Mall_DoorCard].[SortOrder] = @SortOrder,
	[Mall_DoorCard].[DoorNumber] = @DoorNumber,
	[Mall_DoorCard].[RoomPhoneRelationID] = @RoomPhoneRelationID,
	[Mall_DoorCard].[ExpireDate] = @ExpireDate 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[ProjectName],
	INSERTED.[UserID],
	INSERTED.[CardName],
	INSERTED.[CardSummary],
	INSERTED.[CardUID],
	INSERTED.[EndDays],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[SortOrder],
	INSERTED.[DoorNumber],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[ExpireDate]
into @table
WHERE 
	[Mall_DoorCard].[ID] = @ID

SELECT 
	[ID],
	[ProjectID],
	[ProjectName],
	[UserID],
	[CardName],
	[CardSummary],
	[CardUID],
	[EndDays],
	[AddTime],
	[AddUserName],
	[SortOrder],
	[DoorNumber],
	[RoomPhoneRelationID],
	[ExpireDate] 
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
DELETE FROM [dbo].[Mall_DoorCard]
WHERE 
	[Mall_DoorCard].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_DoorCard() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_DoorCard(this.ID));
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
	[Mall_DoorCard].[ID],
	[Mall_DoorCard].[ProjectID],
	[Mall_DoorCard].[ProjectName],
	[Mall_DoorCard].[UserID],
	[Mall_DoorCard].[CardName],
	[Mall_DoorCard].[CardSummary],
	[Mall_DoorCard].[CardUID],
	[Mall_DoorCard].[EndDays],
	[Mall_DoorCard].[AddTime],
	[Mall_DoorCard].[AddUserName],
	[Mall_DoorCard].[SortOrder],
	[Mall_DoorCard].[DoorNumber],
	[Mall_DoorCard].[RoomPhoneRelationID],
	[Mall_DoorCard].[ExpireDate]
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
                return "Mall_DoorCard";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_DoorCard into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="projectName">projectName</param>
		/// <param name="userID">userID</param>
		/// <param name="cardName">cardName</param>
		/// <param name="cardSummary">cardSummary</param>
		/// <param name="cardUID">cardUID</param>
		/// <param name="endDays">endDays</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="doorNumber">doorNumber</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="expireDate">expireDate</param>
		public static void InsertMall_DoorCard(int @projectID, string @projectName, int @userID, string @cardName, string @cardSummary, string @cardUID, int @endDays, DateTime @addTime, string @addUserName, int @sortOrder, string @doorNumber, int @roomPhoneRelationID, DateTime @expireDate)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_DoorCard(@projectID, @projectName, @userID, @cardName, @cardSummary, @cardUID, @endDays, @addTime, @addUserName, @sortOrder, @doorNumber, @roomPhoneRelationID, @expireDate, helper);
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
		/// Insert a Mall_DoorCard into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="projectName">projectName</param>
		/// <param name="userID">userID</param>
		/// <param name="cardName">cardName</param>
		/// <param name="cardSummary">cardSummary</param>
		/// <param name="cardUID">cardUID</param>
		/// <param name="endDays">endDays</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="doorNumber">doorNumber</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="expireDate">expireDate</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_DoorCard(int @projectID, string @projectName, int @userID, string @cardName, string @cardSummary, string @cardUID, int @endDays, DateTime @addTime, string @addUserName, int @sortOrder, string @doorNumber, int @roomPhoneRelationID, DateTime @expireDate, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectID] int,
	[ProjectName] nvarchar(500),
	[UserID] int,
	[CardName] nvarchar(200),
	[CardSummary] ntext,
	[CardUID] nvarchar(200),
	[EndDays] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[SortOrder] int,
	[DoorNumber] nvarchar(50),
	[RoomPhoneRelationID] int,
	[ExpireDate] datetime
);

INSERT INTO [dbo].[Mall_DoorCard] (
	[Mall_DoorCard].[ProjectID],
	[Mall_DoorCard].[ProjectName],
	[Mall_DoorCard].[UserID],
	[Mall_DoorCard].[CardName],
	[Mall_DoorCard].[CardSummary],
	[Mall_DoorCard].[CardUID],
	[Mall_DoorCard].[EndDays],
	[Mall_DoorCard].[AddTime],
	[Mall_DoorCard].[AddUserName],
	[Mall_DoorCard].[SortOrder],
	[Mall_DoorCard].[DoorNumber],
	[Mall_DoorCard].[RoomPhoneRelationID],
	[Mall_DoorCard].[ExpireDate]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[ProjectName],
	INSERTED.[UserID],
	INSERTED.[CardName],
	INSERTED.[CardSummary],
	INSERTED.[CardUID],
	INSERTED.[EndDays],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[SortOrder],
	INSERTED.[DoorNumber],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[ExpireDate]
into @table
VALUES ( 
	@ProjectID,
	@ProjectName,
	@UserID,
	@CardName,
	@CardSummary,
	@CardUID,
	@EndDays,
	@AddTime,
	@AddUserName,
	@SortOrder,
	@DoorNumber,
	@RoomPhoneRelationID,
	@ExpireDate 
); 

SELECT 
	[ID],
	[ProjectID],
	[ProjectName],
	[UserID],
	[CardName],
	[CardSummary],
	[CardUID],
	[EndDays],
	[AddTime],
	[AddUserName],
	[SortOrder],
	[DoorNumber],
	[RoomPhoneRelationID],
	[ExpireDate] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@ProjectName", EntityBase.GetDatabaseValue(@projectName)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@CardName", EntityBase.GetDatabaseValue(@cardName)));
			parameters.Add(new SqlParameter("@CardSummary", EntityBase.GetDatabaseValue(@cardSummary)));
			parameters.Add(new SqlParameter("@CardUID", EntityBase.GetDatabaseValue(@cardUID)));
			parameters.Add(new SqlParameter("@EndDays", EntityBase.GetDatabaseValue(@endDays)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@DoorNumber", EntityBase.GetDatabaseValue(@doorNumber)));
			parameters.Add(new SqlParameter("@RoomPhoneRelationID", EntityBase.GetDatabaseValue(@roomPhoneRelationID)));
			parameters.Add(new SqlParameter("@ExpireDate", EntityBase.GetDatabaseValue(@expireDate)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_DoorCard into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectID">projectID</param>
		/// <param name="projectName">projectName</param>
		/// <param name="userID">userID</param>
		/// <param name="cardName">cardName</param>
		/// <param name="cardSummary">cardSummary</param>
		/// <param name="cardUID">cardUID</param>
		/// <param name="endDays">endDays</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="doorNumber">doorNumber</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="expireDate">expireDate</param>
		public static void UpdateMall_DoorCard(int @iD, int @projectID, string @projectName, int @userID, string @cardName, string @cardSummary, string @cardUID, int @endDays, DateTime @addTime, string @addUserName, int @sortOrder, string @doorNumber, int @roomPhoneRelationID, DateTime @expireDate)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_DoorCard(@iD, @projectID, @projectName, @userID, @cardName, @cardSummary, @cardUID, @endDays, @addTime, @addUserName, @sortOrder, @doorNumber, @roomPhoneRelationID, @expireDate, helper);
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
		/// Updates a Mall_DoorCard into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectID">projectID</param>
		/// <param name="projectName">projectName</param>
		/// <param name="userID">userID</param>
		/// <param name="cardName">cardName</param>
		/// <param name="cardSummary">cardSummary</param>
		/// <param name="cardUID">cardUID</param>
		/// <param name="endDays">endDays</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="doorNumber">doorNumber</param>
		/// <param name="roomPhoneRelationID">roomPhoneRelationID</param>
		/// <param name="expireDate">expireDate</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_DoorCard(int @iD, int @projectID, string @projectName, int @userID, string @cardName, string @cardSummary, string @cardUID, int @endDays, DateTime @addTime, string @addUserName, int @sortOrder, string @doorNumber, int @roomPhoneRelationID, DateTime @expireDate, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectID] int,
	[ProjectName] nvarchar(500),
	[UserID] int,
	[CardName] nvarchar(200),
	[CardSummary] ntext,
	[CardUID] nvarchar(200),
	[EndDays] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[SortOrder] int,
	[DoorNumber] nvarchar(50),
	[RoomPhoneRelationID] int,
	[ExpireDate] datetime
);

UPDATE [dbo].[Mall_DoorCard] SET 
	[Mall_DoorCard].[ProjectID] = @ProjectID,
	[Mall_DoorCard].[ProjectName] = @ProjectName,
	[Mall_DoorCard].[UserID] = @UserID,
	[Mall_DoorCard].[CardName] = @CardName,
	[Mall_DoorCard].[CardSummary] = @CardSummary,
	[Mall_DoorCard].[CardUID] = @CardUID,
	[Mall_DoorCard].[EndDays] = @EndDays,
	[Mall_DoorCard].[AddTime] = @AddTime,
	[Mall_DoorCard].[AddUserName] = @AddUserName,
	[Mall_DoorCard].[SortOrder] = @SortOrder,
	[Mall_DoorCard].[DoorNumber] = @DoorNumber,
	[Mall_DoorCard].[RoomPhoneRelationID] = @RoomPhoneRelationID,
	[Mall_DoorCard].[ExpireDate] = @ExpireDate 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[ProjectName],
	INSERTED.[UserID],
	INSERTED.[CardName],
	INSERTED.[CardSummary],
	INSERTED.[CardUID],
	INSERTED.[EndDays],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[SortOrder],
	INSERTED.[DoorNumber],
	INSERTED.[RoomPhoneRelationID],
	INSERTED.[ExpireDate]
into @table
WHERE 
	[Mall_DoorCard].[ID] = @ID

SELECT 
	[ID],
	[ProjectID],
	[ProjectName],
	[UserID],
	[CardName],
	[CardSummary],
	[CardUID],
	[EndDays],
	[AddTime],
	[AddUserName],
	[SortOrder],
	[DoorNumber],
	[RoomPhoneRelationID],
	[ExpireDate] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@ProjectName", EntityBase.GetDatabaseValue(@projectName)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@CardName", EntityBase.GetDatabaseValue(@cardName)));
			parameters.Add(new SqlParameter("@CardSummary", EntityBase.GetDatabaseValue(@cardSummary)));
			parameters.Add(new SqlParameter("@CardUID", EntityBase.GetDatabaseValue(@cardUID)));
			parameters.Add(new SqlParameter("@EndDays", EntityBase.GetDatabaseValue(@endDays)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@DoorNumber", EntityBase.GetDatabaseValue(@doorNumber)));
			parameters.Add(new SqlParameter("@RoomPhoneRelationID", EntityBase.GetDatabaseValue(@roomPhoneRelationID)));
			parameters.Add(new SqlParameter("@ExpireDate", EntityBase.GetDatabaseValue(@expireDate)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_DoorCard from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_DoorCard(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_DoorCard(@iD, helper);
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
		/// Deletes a Mall_DoorCard from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_DoorCard(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_DoorCard]
WHERE 
	[Mall_DoorCard].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_DoorCard object.
		/// </summary>
		/// <returns>The newly created Mall_DoorCard object.</returns>
		public static Mall_DoorCard CreateMall_DoorCard()
		{
			return InitializeNew<Mall_DoorCard>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_DoorCard by a Mall_DoorCard's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_DoorCard</returns>
		public static Mall_DoorCard GetMall_DoorCard(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_DoorCard.SelectFieldList + @"
FROM [dbo].[Mall_DoorCard] 
WHERE 
	[Mall_DoorCard].[ID] = @ID " + Mall_DoorCard.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_DoorCard>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_DoorCard by a Mall_DoorCard's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_DoorCard</returns>
		public static Mall_DoorCard GetMall_DoorCard(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_DoorCard.SelectFieldList + @"
FROM [dbo].[Mall_DoorCard] 
WHERE 
	[Mall_DoorCard].[ID] = @ID " + Mall_DoorCard.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_DoorCard>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorCard objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_DoorCard objects.</returns>
		public static EntityList<Mall_DoorCard> GetMall_DoorCards()
		{
			string commandText = @"
SELECT " + Mall_DoorCard.SelectFieldList + "FROM [dbo].[Mall_DoorCard] " + Mall_DoorCard.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_DoorCard>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_DoorCard objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_DoorCard objects.</returns>
        public static EntityList<Mall_DoorCard> GetMall_DoorCards(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorCard>(SelectFieldList, "FROM [dbo].[Mall_DoorCard]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_DoorCard objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_DoorCard objects.</returns>
        public static EntityList<Mall_DoorCard> GetMall_DoorCards(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorCard>(SelectFieldList, "FROM [dbo].[Mall_DoorCard]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_DoorCard objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_DoorCard objects.</returns>
		protected static EntityList<Mall_DoorCard> GetMall_DoorCards(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorCards(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorCard objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorCard objects.</returns>
		protected static EntityList<Mall_DoorCard> GetMall_DoorCards(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorCards(string.Empty, where, parameters, Mall_DoorCard.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorCard objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorCard objects.</returns>
		protected static EntityList<Mall_DoorCard> GetMall_DoorCards(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorCards(prefix, where, parameters, Mall_DoorCard.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorCard objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorCard objects.</returns>
		protected static EntityList<Mall_DoorCard> GetMall_DoorCards(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_DoorCards(string.Empty, where, parameters, Mall_DoorCard.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorCard objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorCard objects.</returns>
		protected static EntityList<Mall_DoorCard> GetMall_DoorCards(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_DoorCards(prefix, where, parameters, Mall_DoorCard.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorCard objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_DoorCard objects.</returns>
		protected static EntityList<Mall_DoorCard> GetMall_DoorCards(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_DoorCard.SelectFieldList + "FROM [dbo].[Mall_DoorCard] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_DoorCard>(reader);
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
        protected static EntityList<Mall_DoorCard> GetMall_DoorCards(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorCard>(SelectFieldList, "FROM [dbo].[Mall_DoorCard] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_DoorCard objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_DoorCardCount()
        {
            return GetMall_DoorCardCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_DoorCard objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_DoorCardCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_DoorCard] " + where;

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
		public static partial class Mall_DoorCard_Properties
		{
			public const string ID = "ID";
			public const string ProjectID = "ProjectID";
			public const string ProjectName = "ProjectName";
			public const string UserID = "UserID";
			public const string CardName = "CardName";
			public const string CardSummary = "CardSummary";
			public const string CardUID = "CardUID";
			public const string EndDays = "EndDays";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string SortOrder = "SortOrder";
			public const string DoorNumber = "DoorNumber";
			public const string RoomPhoneRelationID = "RoomPhoneRelationID";
			public const string ExpireDate = "ExpireDate";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProjectID" , "int:"},
    			 {"ProjectName" , "string:"},
    			 {"UserID" , "int:"},
    			 {"CardName" , "string:"},
    			 {"CardSummary" , "string:"},
    			 {"CardUID" , "string:"},
    			 {"EndDays" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"SortOrder" , "int:"},
    			 {"DoorNumber" , "string:"},
    			 {"RoomPhoneRelationID" , "int:"},
    			 {"ExpireDate" , "DateTime:"},
            };
		}
		#endregion
	}
}
