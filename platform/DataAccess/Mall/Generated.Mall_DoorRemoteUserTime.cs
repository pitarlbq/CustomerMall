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
	/// This object represents the properties and methods of a Mall_DoorRemoteUserTime.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_DoorRemoteUserTime 
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
		private int _roomID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _startTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime StartTime
		{
			[DebuggerStepThrough()]
			get { return this._startTime; }
			set 
			{
				if (this._startTime != value) 
				{
					this._startTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("StartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _endTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime EndTime
		{
			[DebuggerStepThrough()]
			get { return this._endTime; }
			set 
			{
				if (this._endTime != value) 
				{
					this._endTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndTime");
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
		private string _addUserMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string AddUserMan
		{
			[DebuggerStepThrough()]
			get { return this._addUserMan; }
			set 
			{
				if (this._addUserMan != value) 
				{
					this._addUserMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUserMan");
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
		private int _delayDay = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int DelayDay
		{
			[DebuggerStepThrough()]
			get { return this._delayDay; }
			set 
			{
				if (this._delayDay != value) 
				{
					this._delayDay = value;
					this.IsDirty = true;	
					OnPropertyChanged("DelayDay");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _delayDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime DelayDate
		{
			[DebuggerStepThrough()]
			get { return this._delayDate; }
			set 
			{
				if (this._delayDate != value) 
				{
					this._delayDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("DelayDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDisable = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDisable
		{
			[DebuggerStepThrough()]
			get { return this._isDisable; }
			set 
			{
				if (this._isDisable != value) 
				{
					this._isDisable = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDisable");
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
	[RoomID] int,
	[StartTime] datetime,
	[EndTime] datetime,
	[AddTime] datetime,
	[AddUserMan] nvarchar(50),
	[Remark] ntext,
	[DelayDay] int,
	[DelayDate] datetime,
	[IsDisable] bit
);

INSERT INTO [dbo].[Mall_DoorRemoteUserTime] (
	[Mall_DoorRemoteUserTime].[RoomID],
	[Mall_DoorRemoteUserTime].[StartTime],
	[Mall_DoorRemoteUserTime].[EndTime],
	[Mall_DoorRemoteUserTime].[AddTime],
	[Mall_DoorRemoteUserTime].[AddUserMan],
	[Mall_DoorRemoteUserTime].[Remark],
	[Mall_DoorRemoteUserTime].[DelayDay],
	[Mall_DoorRemoteUserTime].[DelayDate],
	[Mall_DoorRemoteUserTime].[IsDisable]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[Remark],
	INSERTED.[DelayDay],
	INSERTED.[DelayDate],
	INSERTED.[IsDisable]
into @table
VALUES ( 
	@RoomID,
	@StartTime,
	@EndTime,
	@AddTime,
	@AddUserMan,
	@Remark,
	@DelayDay,
	@DelayDate,
	@IsDisable 
); 

SELECT 
	[ID],
	[RoomID],
	[StartTime],
	[EndTime],
	[AddTime],
	[AddUserMan],
	[Remark],
	[DelayDay],
	[DelayDate],
	[IsDisable] 
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
	[RoomID] int,
	[StartTime] datetime,
	[EndTime] datetime,
	[AddTime] datetime,
	[AddUserMan] nvarchar(50),
	[Remark] ntext,
	[DelayDay] int,
	[DelayDate] datetime,
	[IsDisable] bit
);

UPDATE [dbo].[Mall_DoorRemoteUserTime] SET 
	[Mall_DoorRemoteUserTime].[RoomID] = @RoomID,
	[Mall_DoorRemoteUserTime].[StartTime] = @StartTime,
	[Mall_DoorRemoteUserTime].[EndTime] = @EndTime,
	[Mall_DoorRemoteUserTime].[AddTime] = @AddTime,
	[Mall_DoorRemoteUserTime].[AddUserMan] = @AddUserMan,
	[Mall_DoorRemoteUserTime].[Remark] = @Remark,
	[Mall_DoorRemoteUserTime].[DelayDay] = @DelayDay,
	[Mall_DoorRemoteUserTime].[DelayDate] = @DelayDate,
	[Mall_DoorRemoteUserTime].[IsDisable] = @IsDisable 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[Remark],
	INSERTED.[DelayDay],
	INSERTED.[DelayDate],
	INSERTED.[IsDisable]
into @table
WHERE 
	[Mall_DoorRemoteUserTime].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[StartTime],
	[EndTime],
	[AddTime],
	[AddUserMan],
	[Remark],
	[DelayDay],
	[DelayDate],
	[IsDisable] 
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
DELETE FROM [dbo].[Mall_DoorRemoteUserTime]
WHERE 
	[Mall_DoorRemoteUserTime].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_DoorRemoteUserTime() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_DoorRemoteUserTime(this.ID));
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
	[Mall_DoorRemoteUserTime].[ID],
	[Mall_DoorRemoteUserTime].[RoomID],
	[Mall_DoorRemoteUserTime].[StartTime],
	[Mall_DoorRemoteUserTime].[EndTime],
	[Mall_DoorRemoteUserTime].[AddTime],
	[Mall_DoorRemoteUserTime].[AddUserMan],
	[Mall_DoorRemoteUserTime].[Remark],
	[Mall_DoorRemoteUserTime].[DelayDay],
	[Mall_DoorRemoteUserTime].[DelayDate],
	[Mall_DoorRemoteUserTime].[IsDisable]
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
                return "Mall_DoorRemoteUserTime";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_DoorRemoteUserTime into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="remark">remark</param>
		/// <param name="delayDay">delayDay</param>
		/// <param name="delayDate">delayDate</param>
		/// <param name="isDisable">isDisable</param>
		public static void InsertMall_DoorRemoteUserTime(int @roomID, DateTime @startTime, DateTime @endTime, DateTime @addTime, string @addUserMan, string @remark, int @delayDay, DateTime @delayDate, bool @isDisable)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_DoorRemoteUserTime(@roomID, @startTime, @endTime, @addTime, @addUserMan, @remark, @delayDay, @delayDate, @isDisable, helper);
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
		/// Insert a Mall_DoorRemoteUserTime into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="remark">remark</param>
		/// <param name="delayDay">delayDay</param>
		/// <param name="delayDate">delayDate</param>
		/// <param name="isDisable">isDisable</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_DoorRemoteUserTime(int @roomID, DateTime @startTime, DateTime @endTime, DateTime @addTime, string @addUserMan, string @remark, int @delayDay, DateTime @delayDate, bool @isDisable, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[StartTime] datetime,
	[EndTime] datetime,
	[AddTime] datetime,
	[AddUserMan] nvarchar(50),
	[Remark] ntext,
	[DelayDay] int,
	[DelayDate] datetime,
	[IsDisable] bit
);

INSERT INTO [dbo].[Mall_DoorRemoteUserTime] (
	[Mall_DoorRemoteUserTime].[RoomID],
	[Mall_DoorRemoteUserTime].[StartTime],
	[Mall_DoorRemoteUserTime].[EndTime],
	[Mall_DoorRemoteUserTime].[AddTime],
	[Mall_DoorRemoteUserTime].[AddUserMan],
	[Mall_DoorRemoteUserTime].[Remark],
	[Mall_DoorRemoteUserTime].[DelayDay],
	[Mall_DoorRemoteUserTime].[DelayDate],
	[Mall_DoorRemoteUserTime].[IsDisable]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[Remark],
	INSERTED.[DelayDay],
	INSERTED.[DelayDate],
	INSERTED.[IsDisable]
into @table
VALUES ( 
	@RoomID,
	@StartTime,
	@EndTime,
	@AddTime,
	@AddUserMan,
	@Remark,
	@DelayDay,
	@DelayDate,
	@IsDisable 
); 

SELECT 
	[ID],
	[RoomID],
	[StartTime],
	[EndTime],
	[AddTime],
	[AddUserMan],
	[Remark],
	[DelayDay],
	[DelayDate],
	[IsDisable] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserMan", EntityBase.GetDatabaseValue(@addUserMan)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@DelayDay", EntityBase.GetDatabaseValue(@delayDay)));
			parameters.Add(new SqlParameter("@DelayDate", EntityBase.GetDatabaseValue(@delayDate)));
			parameters.Add(new SqlParameter("@IsDisable", @isDisable));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_DoorRemoteUserTime into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="remark">remark</param>
		/// <param name="delayDay">delayDay</param>
		/// <param name="delayDate">delayDate</param>
		/// <param name="isDisable">isDisable</param>
		public static void UpdateMall_DoorRemoteUserTime(int @iD, int @roomID, DateTime @startTime, DateTime @endTime, DateTime @addTime, string @addUserMan, string @remark, int @delayDay, DateTime @delayDate, bool @isDisable)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_DoorRemoteUserTime(@iD, @roomID, @startTime, @endTime, @addTime, @addUserMan, @remark, @delayDay, @delayDate, @isDisable, helper);
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
		/// Updates a Mall_DoorRemoteUserTime into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="remark">remark</param>
		/// <param name="delayDay">delayDay</param>
		/// <param name="delayDate">delayDate</param>
		/// <param name="isDisable">isDisable</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_DoorRemoteUserTime(int @iD, int @roomID, DateTime @startTime, DateTime @endTime, DateTime @addTime, string @addUserMan, string @remark, int @delayDay, DateTime @delayDate, bool @isDisable, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[StartTime] datetime,
	[EndTime] datetime,
	[AddTime] datetime,
	[AddUserMan] nvarchar(50),
	[Remark] ntext,
	[DelayDay] int,
	[DelayDate] datetime,
	[IsDisable] bit
);

UPDATE [dbo].[Mall_DoorRemoteUserTime] SET 
	[Mall_DoorRemoteUserTime].[RoomID] = @RoomID,
	[Mall_DoorRemoteUserTime].[StartTime] = @StartTime,
	[Mall_DoorRemoteUserTime].[EndTime] = @EndTime,
	[Mall_DoorRemoteUserTime].[AddTime] = @AddTime,
	[Mall_DoorRemoteUserTime].[AddUserMan] = @AddUserMan,
	[Mall_DoorRemoteUserTime].[Remark] = @Remark,
	[Mall_DoorRemoteUserTime].[DelayDay] = @DelayDay,
	[Mall_DoorRemoteUserTime].[DelayDate] = @DelayDate,
	[Mall_DoorRemoteUserTime].[IsDisable] = @IsDisable 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[Remark],
	INSERTED.[DelayDay],
	INSERTED.[DelayDate],
	INSERTED.[IsDisable]
into @table
WHERE 
	[Mall_DoorRemoteUserTime].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[StartTime],
	[EndTime],
	[AddTime],
	[AddUserMan],
	[Remark],
	[DelayDay],
	[DelayDate],
	[IsDisable] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserMan", EntityBase.GetDatabaseValue(@addUserMan)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@DelayDay", EntityBase.GetDatabaseValue(@delayDay)));
			parameters.Add(new SqlParameter("@DelayDate", EntityBase.GetDatabaseValue(@delayDate)));
			parameters.Add(new SqlParameter("@IsDisable", @isDisable));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_DoorRemoteUserTime from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_DoorRemoteUserTime(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_DoorRemoteUserTime(@iD, helper);
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
		/// Deletes a Mall_DoorRemoteUserTime from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_DoorRemoteUserTime(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_DoorRemoteUserTime]
WHERE 
	[Mall_DoorRemoteUserTime].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_DoorRemoteUserTime object.
		/// </summary>
		/// <returns>The newly created Mall_DoorRemoteUserTime object.</returns>
		public static Mall_DoorRemoteUserTime CreateMall_DoorRemoteUserTime()
		{
			return InitializeNew<Mall_DoorRemoteUserTime>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_DoorRemoteUserTime by a Mall_DoorRemoteUserTime's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_DoorRemoteUserTime</returns>
		public static Mall_DoorRemoteUserTime GetMall_DoorRemoteUserTime(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_DoorRemoteUserTime.SelectFieldList + @"
FROM [dbo].[Mall_DoorRemoteUserTime] 
WHERE 
	[Mall_DoorRemoteUserTime].[ID] = @ID " + Mall_DoorRemoteUserTime.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_DoorRemoteUserTime>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_DoorRemoteUserTime by a Mall_DoorRemoteUserTime's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_DoorRemoteUserTime</returns>
		public static Mall_DoorRemoteUserTime GetMall_DoorRemoteUserTime(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_DoorRemoteUserTime.SelectFieldList + @"
FROM [dbo].[Mall_DoorRemoteUserTime] 
WHERE 
	[Mall_DoorRemoteUserTime].[ID] = @ID " + Mall_DoorRemoteUserTime.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_DoorRemoteUserTime>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteUserTime objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_DoorRemoteUserTime objects.</returns>
		public static EntityList<Mall_DoorRemoteUserTime> GetMall_DoorRemoteUserTimes()
		{
			string commandText = @"
SELECT " + Mall_DoorRemoteUserTime.SelectFieldList + "FROM [dbo].[Mall_DoorRemoteUserTime] " + Mall_DoorRemoteUserTime.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_DoorRemoteUserTime>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_DoorRemoteUserTime objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_DoorRemoteUserTime objects.</returns>
        public static EntityList<Mall_DoorRemoteUserTime> GetMall_DoorRemoteUserTimes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorRemoteUserTime>(SelectFieldList, "FROM [dbo].[Mall_DoorRemoteUserTime]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_DoorRemoteUserTime objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_DoorRemoteUserTime objects.</returns>
        public static EntityList<Mall_DoorRemoteUserTime> GetMall_DoorRemoteUserTimes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorRemoteUserTime>(SelectFieldList, "FROM [dbo].[Mall_DoorRemoteUserTime]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteUserTime objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteUserTime objects.</returns>
		protected static EntityList<Mall_DoorRemoteUserTime> GetMall_DoorRemoteUserTimes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorRemoteUserTimes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteUserTime objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteUserTime objects.</returns>
		protected static EntityList<Mall_DoorRemoteUserTime> GetMall_DoorRemoteUserTimes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorRemoteUserTimes(string.Empty, where, parameters, Mall_DoorRemoteUserTime.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteUserTime objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteUserTime objects.</returns>
		protected static EntityList<Mall_DoorRemoteUserTime> GetMall_DoorRemoteUserTimes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_DoorRemoteUserTimes(prefix, where, parameters, Mall_DoorRemoteUserTime.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteUserTime objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteUserTime objects.</returns>
		protected static EntityList<Mall_DoorRemoteUserTime> GetMall_DoorRemoteUserTimes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_DoorRemoteUserTimes(string.Empty, where, parameters, Mall_DoorRemoteUserTime.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteUserTime objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteUserTime objects.</returns>
		protected static EntityList<Mall_DoorRemoteUserTime> GetMall_DoorRemoteUserTimes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_DoorRemoteUserTimes(prefix, where, parameters, Mall_DoorRemoteUserTime.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_DoorRemoteUserTime objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_DoorRemoteUserTime objects.</returns>
		protected static EntityList<Mall_DoorRemoteUserTime> GetMall_DoorRemoteUserTimes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_DoorRemoteUserTime.SelectFieldList + "FROM [dbo].[Mall_DoorRemoteUserTime] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_DoorRemoteUserTime>(reader);
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
        protected static EntityList<Mall_DoorRemoteUserTime> GetMall_DoorRemoteUserTimes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_DoorRemoteUserTime>(SelectFieldList, "FROM [dbo].[Mall_DoorRemoteUserTime] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_DoorRemoteUserTime objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_DoorRemoteUserTimeCount()
        {
            return GetMall_DoorRemoteUserTimeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_DoorRemoteUserTime objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_DoorRemoteUserTimeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_DoorRemoteUserTime] " + where;

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
		public static partial class Mall_DoorRemoteUserTime_Properties
		{
			public const string ID = "ID";
			public const string RoomID = "RoomID";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string AddTime = "AddTime";
			public const string AddUserMan = "AddUserMan";
			public const string Remark = "Remark";
			public const string DelayDay = "DelayDay";
			public const string DelayDate = "DelayDate";
			public const string IsDisable = "IsDisable";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserMan" , "string:"},
    			 {"Remark" , "string:"},
    			 {"DelayDay" , "int:"},
    			 {"DelayDate" , "DateTime:"},
    			 {"IsDisable" , "bool:"},
            };
		}
		#endregion
	}
}
