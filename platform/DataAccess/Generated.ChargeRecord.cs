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
	/// This object represents the properties and methods of a ChargeRecord.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ChargeRecord 
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
		private int _chargeType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChargeType
		{
			[DebuggerStepThrough()]
			get { return this._chargeType; }
			set 
			{
				if (this._chargeType != value) 
				{
					this._chargeType = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _chargeFee = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ChargeFee
		{
			[DebuggerStepThrough()]
			get { return this._chargeFee; }
			set 
			{
				if (this._chargeFee != value) 
				{
					this._chargeFee = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeFee");
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _roomFeeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RoomFeeID
		{
			[DebuggerStepThrough()]
			get { return this._roomFeeID; }
			set 
			{
				if (this._roomFeeID != value) 
				{
					this._roomFeeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomFeeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _roomID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RoomID
		{
			[DebuggerStepThrough()]
			get { return this._roomID; }
			set 
			{
				if (this._roomID != value) 
				{
					this._roomID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomID");
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
	[ChargeType] int,
	[ChargeFee] decimal(18, 2),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[RoomFeeID] int,
	[RoomID] int
);

INSERT INTO [dbo].[ChargeRecord] (
	[ChargeRecord].[ChargeType],
	[ChargeRecord].[ChargeFee],
	[ChargeRecord].[AddTime],
	[ChargeRecord].[AddMan],
	[ChargeRecord].[RoomFeeID],
	[ChargeRecord].[RoomID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ChargeType],
	INSERTED.[ChargeFee],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[RoomFeeID],
	INSERTED.[RoomID]
into @table
VALUES ( 
	@ChargeType,
	@ChargeFee,
	@AddTime,
	@AddMan,
	@RoomFeeID,
	@RoomID 
); 

SELECT 
	[ID],
	[ChargeType],
	[ChargeFee],
	[AddTime],
	[AddMan],
	[RoomFeeID],
	[RoomID] 
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
	[ChargeType] int,
	[ChargeFee] decimal(18, 2),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[RoomFeeID] int,
	[RoomID] int
);

UPDATE [dbo].[ChargeRecord] SET 
	[ChargeRecord].[ChargeType] = @ChargeType,
	[ChargeRecord].[ChargeFee] = @ChargeFee,
	[ChargeRecord].[AddTime] = @AddTime,
	[ChargeRecord].[AddMan] = @AddMan,
	[ChargeRecord].[RoomFeeID] = @RoomFeeID,
	[ChargeRecord].[RoomID] = @RoomID 
output 
	INSERTED.[ID],
	INSERTED.[ChargeType],
	INSERTED.[ChargeFee],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[RoomFeeID],
	INSERTED.[RoomID]
into @table
WHERE 
	[ChargeRecord].[ID] = @ID

SELECT 
	[ID],
	[ChargeType],
	[ChargeFee],
	[AddTime],
	[AddMan],
	[RoomFeeID],
	[RoomID] 
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
DELETE FROM [dbo].[ChargeRecord]
WHERE 
	[ChargeRecord].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ChargeRecord() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetChargeRecord(this.ID));
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
	[ChargeRecord].[ID],
	[ChargeRecord].[ChargeType],
	[ChargeRecord].[ChargeFee],
	[ChargeRecord].[AddTime],
	[ChargeRecord].[AddMan],
	[ChargeRecord].[RoomFeeID],
	[ChargeRecord].[RoomID]
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
                return "ChargeRecord";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ChargeRecord into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeType">chargeType</param>
		/// <param name="chargeFee">chargeFee</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="roomFeeID">roomFeeID</param>
		/// <param name="roomID">roomID</param>
		public static void InsertChargeRecord(int @chargeType, decimal @chargeFee, DateTime @addTime, string @addMan, int @roomFeeID, int @roomID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertChargeRecord(@chargeType, @chargeFee, @addTime, @addMan, @roomFeeID, @roomID, helper);
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
		/// Insert a ChargeRecord into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="chargeType">chargeType</param>
		/// <param name="chargeFee">chargeFee</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="roomFeeID">roomFeeID</param>
		/// <param name="roomID">roomID</param>
		/// <param name="helper">helper</param>
		internal static void InsertChargeRecord(int @chargeType, decimal @chargeFee, DateTime @addTime, string @addMan, int @roomFeeID, int @roomID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ChargeType] int,
	[ChargeFee] decimal(18, 2),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[RoomFeeID] int,
	[RoomID] int
);

INSERT INTO [dbo].[ChargeRecord] (
	[ChargeRecord].[ChargeType],
	[ChargeRecord].[ChargeFee],
	[ChargeRecord].[AddTime],
	[ChargeRecord].[AddMan],
	[ChargeRecord].[RoomFeeID],
	[ChargeRecord].[RoomID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ChargeType],
	INSERTED.[ChargeFee],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[RoomFeeID],
	INSERTED.[RoomID]
into @table
VALUES ( 
	@ChargeType,
	@ChargeFee,
	@AddTime,
	@AddMan,
	@RoomFeeID,
	@RoomID 
); 

SELECT 
	[ID],
	[ChargeType],
	[ChargeFee],
	[AddTime],
	[AddMan],
	[RoomFeeID],
	[RoomID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ChargeType", EntityBase.GetDatabaseValue(@chargeType)));
			parameters.Add(new SqlParameter("@ChargeFee", EntityBase.GetDatabaseValue(@chargeFee)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@RoomFeeID", EntityBase.GetDatabaseValue(@roomFeeID)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ChargeRecord into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="chargeType">chargeType</param>
		/// <param name="chargeFee">chargeFee</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="roomFeeID">roomFeeID</param>
		/// <param name="roomID">roomID</param>
		public static void UpdateChargeRecord(int @iD, int @chargeType, decimal @chargeFee, DateTime @addTime, string @addMan, int @roomFeeID, int @roomID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateChargeRecord(@iD, @chargeType, @chargeFee, @addTime, @addMan, @roomFeeID, @roomID, helper);
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
		/// Updates a ChargeRecord into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="chargeType">chargeType</param>
		/// <param name="chargeFee">chargeFee</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="roomFeeID">roomFeeID</param>
		/// <param name="roomID">roomID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateChargeRecord(int @iD, int @chargeType, decimal @chargeFee, DateTime @addTime, string @addMan, int @roomFeeID, int @roomID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ChargeType] int,
	[ChargeFee] decimal(18, 2),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[RoomFeeID] int,
	[RoomID] int
);

UPDATE [dbo].[ChargeRecord] SET 
	[ChargeRecord].[ChargeType] = @ChargeType,
	[ChargeRecord].[ChargeFee] = @ChargeFee,
	[ChargeRecord].[AddTime] = @AddTime,
	[ChargeRecord].[AddMan] = @AddMan,
	[ChargeRecord].[RoomFeeID] = @RoomFeeID,
	[ChargeRecord].[RoomID] = @RoomID 
output 
	INSERTED.[ID],
	INSERTED.[ChargeType],
	INSERTED.[ChargeFee],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[RoomFeeID],
	INSERTED.[RoomID]
into @table
WHERE 
	[ChargeRecord].[ID] = @ID

SELECT 
	[ID],
	[ChargeType],
	[ChargeFee],
	[AddTime],
	[AddMan],
	[RoomFeeID],
	[RoomID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ChargeType", EntityBase.GetDatabaseValue(@chargeType)));
			parameters.Add(new SqlParameter("@ChargeFee", EntityBase.GetDatabaseValue(@chargeFee)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@RoomFeeID", EntityBase.GetDatabaseValue(@roomFeeID)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ChargeRecord from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteChargeRecord(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteChargeRecord(@iD, helper);
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
		/// Deletes a ChargeRecord from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteChargeRecord(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ChargeRecord]
WHERE 
	[ChargeRecord].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ChargeRecord object.
		/// </summary>
		/// <returns>The newly created ChargeRecord object.</returns>
		public static ChargeRecord CreateChargeRecord()
		{
			return InitializeNew<ChargeRecord>();
		}
		
		/// <summary>
		/// Retrieve information for a ChargeRecord by a ChargeRecord's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ChargeRecord</returns>
		public static ChargeRecord GetChargeRecord(int @iD)
		{
			string commandText = @"
SELECT 
" + ChargeRecord.SelectFieldList + @"
FROM [dbo].[ChargeRecord] 
WHERE 
	[ChargeRecord].[ID] = @ID " + ChargeRecord.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeRecord>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ChargeRecord by a ChargeRecord's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ChargeRecord</returns>
		public static ChargeRecord GetChargeRecord(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ChargeRecord.SelectFieldList + @"
FROM [dbo].[ChargeRecord] 
WHERE 
	[ChargeRecord].[ID] = @ID " + ChargeRecord.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeRecord>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ChargeRecord objects.
		/// </summary>
		/// <returns>The retrieved collection of ChargeRecord objects.</returns>
		public static EntityList<ChargeRecord> GetChargeRecords()
		{
			string commandText = @"
SELECT " + ChargeRecord.SelectFieldList + "FROM [dbo].[ChargeRecord] " + ChargeRecord.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ChargeRecord>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ChargeRecord objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeRecord objects.</returns>
        public static EntityList<ChargeRecord> GetChargeRecords(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeRecord>(SelectFieldList, "FROM [dbo].[ChargeRecord]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ChargeRecord objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeRecord objects.</returns>
        public static EntityList<ChargeRecord> GetChargeRecords(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeRecord>(SelectFieldList, "FROM [dbo].[ChargeRecord]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ChargeRecord objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ChargeRecord objects.</returns>
		protected static EntityList<ChargeRecord> GetChargeRecords(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeRecords(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ChargeRecord objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeRecord objects.</returns>
		protected static EntityList<ChargeRecord> GetChargeRecords(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeRecords(string.Empty, where, parameters, ChargeRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeRecord objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeRecord objects.</returns>
		protected static EntityList<ChargeRecord> GetChargeRecords(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeRecords(prefix, where, parameters, ChargeRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeRecord objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeRecord objects.</returns>
		protected static EntityList<ChargeRecord> GetChargeRecords(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeRecords(string.Empty, where, parameters, ChargeRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeRecord objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeRecord objects.</returns>
		protected static EntityList<ChargeRecord> GetChargeRecords(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeRecords(prefix, where, parameters, ChargeRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeRecord objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ChargeRecord objects.</returns>
		protected static EntityList<ChargeRecord> GetChargeRecords(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ChargeRecord.SelectFieldList + "FROM [dbo].[ChargeRecord] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ChargeRecord>(reader);
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
        protected static EntityList<ChargeRecord> GetChargeRecords(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeRecord>(SelectFieldList, "FROM [dbo].[ChargeRecord] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class ChargeRecordProperties
		{
			public const string ID = "ID";
			public const string ChargeType = "ChargeType";
			public const string ChargeFee = "ChargeFee";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string RoomFeeID = "RoomFeeID";
			public const string RoomID = "RoomID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ChargeType" , "int:"},
    			 {"ChargeFee" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"RoomFeeID" , "int:"},
    			 {"RoomID" , "int:"},
            };
		}
		#endregion
	}
}
