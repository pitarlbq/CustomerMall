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
	/// This object represents the properties and methods of a Wechat_LotteryActivityPrize.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_LotteryActivityPrize 
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
		/// 活动ID
		/// </summary>
        [Description("活动ID")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private string _levelName = String.Empty;
		/// <summary>
		/// 奖品等级
		/// </summary>
        [Description("奖品等级")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string LevelName
		{
			[DebuggerStepThrough()]
			get { return this._levelName; }
			set 
			{
				if (this._levelName != value) 
				{
					this._levelName = value;
					this.IsDirty = true;	
					OnPropertyChanged("LevelName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _quota = int.MinValue;
		/// <summary>
		/// 中奖名额
		/// </summary>
        [Description("中奖名额")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int Quota
		{
			[DebuggerStepThrough()]
			get { return this._quota; }
			set 
			{
				if (this._quota != value) 
				{
					this._quota = value;
					this.IsDirty = true;	
					OnPropertyChanged("Quota");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _prizeName = String.Empty;
		/// <summary>
		/// 奖品名称
		/// </summary>
        [Description("奖品名称")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string PrizeName
		{
			[DebuggerStepThrough()]
			get { return this._prizeName; }
			set 
			{
				if (this._prizeName != value) 
				{
					this._prizeName = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrizeName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _prizeQuantity = decimal.MinValue;
		/// <summary>
		/// 奖品金额/数量
		/// </summary>
        [Description("奖品金额/数量")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal PrizeQuantity
		{
			[DebuggerStepThrough()]
			get { return this._prizeQuantity; }
			set 
			{
				if (this._prizeQuantity != value) 
				{
					this._prizeQuantity = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrizeQuantity");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _prizeUnit = String.Empty;
		/// <summary>
		/// 奖品单位
		/// </summary>
        [Description("奖品单位")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string PrizeUnit
		{
			[DebuggerStepThrough()]
			get { return this._prizeUnit; }
			set 
			{
				if (this._prizeUnit != value) 
				{
					this._prizeUnit = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrizeUnit");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _type = String.Empty;
		/// <summary>
		/// 奖品类型(红包、实物、积分etc)
		/// </summary>
        [Description("奖品类型(红包、实物、积分etc)")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string Type
		{
			[DebuggerStepThrough()]
			get { return this._type; }
			set 
			{
				if (this._type != value) 
				{
					this._type = value;
					this.IsDirty = true;	
					OnPropertyChanged("Type");
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
		private int _repeatTime = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RepeatTime
		{
			[DebuggerStepThrough()]
			get { return this._repeatTime; }
			set 
			{
				if (this._repeatTime != value) 
				{
					this._repeatTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("RepeatTime");
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
	[LevelName] nvarchar(50),
	[Quota] int,
	[PrizeName] nvarchar(50),
	[PrizeQuantity] decimal(18, 2),
	[PrizeUnit] nvarchar(50),
	[Type] nvarchar(50),
	[SortOrder] int,
	[RepeatTime] int
);

INSERT INTO [dbo].[Wechat_LotteryActivityPrize] (
	[Wechat_LotteryActivityPrize].[ActivityID],
	[Wechat_LotteryActivityPrize].[LevelName],
	[Wechat_LotteryActivityPrize].[Quota],
	[Wechat_LotteryActivityPrize].[PrizeName],
	[Wechat_LotteryActivityPrize].[PrizeQuantity],
	[Wechat_LotteryActivityPrize].[PrizeUnit],
	[Wechat_LotteryActivityPrize].[Type],
	[Wechat_LotteryActivityPrize].[SortOrder],
	[Wechat_LotteryActivityPrize].[RepeatTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ActivityID],
	INSERTED.[LevelName],
	INSERTED.[Quota],
	INSERTED.[PrizeName],
	INSERTED.[PrizeQuantity],
	INSERTED.[PrizeUnit],
	INSERTED.[Type],
	INSERTED.[SortOrder],
	INSERTED.[RepeatTime]
into @table
VALUES ( 
	@ActivityID,
	@LevelName,
	@Quota,
	@PrizeName,
	@PrizeQuantity,
	@PrizeUnit,
	@Type,
	@SortOrder,
	@RepeatTime 
); 

SELECT 
	[ID],
	[ActivityID],
	[LevelName],
	[Quota],
	[PrizeName],
	[PrizeQuantity],
	[PrizeUnit],
	[Type],
	[SortOrder],
	[RepeatTime] 
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
	[LevelName] nvarchar(50),
	[Quota] int,
	[PrizeName] nvarchar(50),
	[PrizeQuantity] decimal(18, 2),
	[PrizeUnit] nvarchar(50),
	[Type] nvarchar(50),
	[SortOrder] int,
	[RepeatTime] int
);

UPDATE [dbo].[Wechat_LotteryActivityPrize] SET 
	[Wechat_LotteryActivityPrize].[ActivityID] = @ActivityID,
	[Wechat_LotteryActivityPrize].[LevelName] = @LevelName,
	[Wechat_LotteryActivityPrize].[Quota] = @Quota,
	[Wechat_LotteryActivityPrize].[PrizeName] = @PrizeName,
	[Wechat_LotteryActivityPrize].[PrizeQuantity] = @PrizeQuantity,
	[Wechat_LotteryActivityPrize].[PrizeUnit] = @PrizeUnit,
	[Wechat_LotteryActivityPrize].[Type] = @Type,
	[Wechat_LotteryActivityPrize].[SortOrder] = @SortOrder,
	[Wechat_LotteryActivityPrize].[RepeatTime] = @RepeatTime 
output 
	INSERTED.[ID],
	INSERTED.[ActivityID],
	INSERTED.[LevelName],
	INSERTED.[Quota],
	INSERTED.[PrizeName],
	INSERTED.[PrizeQuantity],
	INSERTED.[PrizeUnit],
	INSERTED.[Type],
	INSERTED.[SortOrder],
	INSERTED.[RepeatTime]
into @table
WHERE 
	[Wechat_LotteryActivityPrize].[ID] = @ID

SELECT 
	[ID],
	[ActivityID],
	[LevelName],
	[Quota],
	[PrizeName],
	[PrizeQuantity],
	[PrizeUnit],
	[Type],
	[SortOrder],
	[RepeatTime] 
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
DELETE FROM [dbo].[Wechat_LotteryActivityPrize]
WHERE 
	[Wechat_LotteryActivityPrize].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_LotteryActivityPrize() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_LotteryActivityPrize(this.ID));
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
	[Wechat_LotteryActivityPrize].[ID],
	[Wechat_LotteryActivityPrize].[ActivityID],
	[Wechat_LotteryActivityPrize].[LevelName],
	[Wechat_LotteryActivityPrize].[Quota],
	[Wechat_LotteryActivityPrize].[PrizeName],
	[Wechat_LotteryActivityPrize].[PrizeQuantity],
	[Wechat_LotteryActivityPrize].[PrizeUnit],
	[Wechat_LotteryActivityPrize].[Type],
	[Wechat_LotteryActivityPrize].[SortOrder],
	[Wechat_LotteryActivityPrize].[RepeatTime]
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
                return "Wechat_LotteryActivityPrize";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_LotteryActivityPrize into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="activityID">activityID</param>
		/// <param name="levelName">levelName</param>
		/// <param name="quota">quota</param>
		/// <param name="prizeName">prizeName</param>
		/// <param name="prizeQuantity">prizeQuantity</param>
		/// <param name="prizeUnit">prizeUnit</param>
		/// <param name="type">type</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="repeatTime">repeatTime</param>
		public static void InsertWechat_LotteryActivityPrize(int @activityID, string @levelName, int @quota, string @prizeName, decimal @prizeQuantity, string @prizeUnit, string @type, int @sortOrder, int @repeatTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_LotteryActivityPrize(@activityID, @levelName, @quota, @prizeName, @prizeQuantity, @prizeUnit, @type, @sortOrder, @repeatTime, helper);
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
		/// Insert a Wechat_LotteryActivityPrize into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="activityID">activityID</param>
		/// <param name="levelName">levelName</param>
		/// <param name="quota">quota</param>
		/// <param name="prizeName">prizeName</param>
		/// <param name="prizeQuantity">prizeQuantity</param>
		/// <param name="prizeUnit">prizeUnit</param>
		/// <param name="type">type</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="repeatTime">repeatTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_LotteryActivityPrize(int @activityID, string @levelName, int @quota, string @prizeName, decimal @prizeQuantity, string @prizeUnit, string @type, int @sortOrder, int @repeatTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ActivityID] int,
	[LevelName] nvarchar(50),
	[Quota] int,
	[PrizeName] nvarchar(50),
	[PrizeQuantity] decimal(18, 2),
	[PrizeUnit] nvarchar(50),
	[Type] nvarchar(50),
	[SortOrder] int,
	[RepeatTime] int
);

INSERT INTO [dbo].[Wechat_LotteryActivityPrize] (
	[Wechat_LotteryActivityPrize].[ActivityID],
	[Wechat_LotteryActivityPrize].[LevelName],
	[Wechat_LotteryActivityPrize].[Quota],
	[Wechat_LotteryActivityPrize].[PrizeName],
	[Wechat_LotteryActivityPrize].[PrizeQuantity],
	[Wechat_LotteryActivityPrize].[PrizeUnit],
	[Wechat_LotteryActivityPrize].[Type],
	[Wechat_LotteryActivityPrize].[SortOrder],
	[Wechat_LotteryActivityPrize].[RepeatTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ActivityID],
	INSERTED.[LevelName],
	INSERTED.[Quota],
	INSERTED.[PrizeName],
	INSERTED.[PrizeQuantity],
	INSERTED.[PrizeUnit],
	INSERTED.[Type],
	INSERTED.[SortOrder],
	INSERTED.[RepeatTime]
into @table
VALUES ( 
	@ActivityID,
	@LevelName,
	@Quota,
	@PrizeName,
	@PrizeQuantity,
	@PrizeUnit,
	@Type,
	@SortOrder,
	@RepeatTime 
); 

SELECT 
	[ID],
	[ActivityID],
	[LevelName],
	[Quota],
	[PrizeName],
	[PrizeQuantity],
	[PrizeUnit],
	[Type],
	[SortOrder],
	[RepeatTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ActivityID", EntityBase.GetDatabaseValue(@activityID)));
			parameters.Add(new SqlParameter("@LevelName", EntityBase.GetDatabaseValue(@levelName)));
			parameters.Add(new SqlParameter("@Quota", EntityBase.GetDatabaseValue(@quota)));
			parameters.Add(new SqlParameter("@PrizeName", EntityBase.GetDatabaseValue(@prizeName)));
			parameters.Add(new SqlParameter("@PrizeQuantity", EntityBase.GetDatabaseValue(@prizeQuantity)));
			parameters.Add(new SqlParameter("@PrizeUnit", EntityBase.GetDatabaseValue(@prizeUnit)));
			parameters.Add(new SqlParameter("@Type", EntityBase.GetDatabaseValue(@type)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@RepeatTime", EntityBase.GetDatabaseValue(@repeatTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_LotteryActivityPrize into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="activityID">activityID</param>
		/// <param name="levelName">levelName</param>
		/// <param name="quota">quota</param>
		/// <param name="prizeName">prizeName</param>
		/// <param name="prizeQuantity">prizeQuantity</param>
		/// <param name="prizeUnit">prizeUnit</param>
		/// <param name="type">type</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="repeatTime">repeatTime</param>
		public static void UpdateWechat_LotteryActivityPrize(int @iD, int @activityID, string @levelName, int @quota, string @prizeName, decimal @prizeQuantity, string @prizeUnit, string @type, int @sortOrder, int @repeatTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_LotteryActivityPrize(@iD, @activityID, @levelName, @quota, @prizeName, @prizeQuantity, @prizeUnit, @type, @sortOrder, @repeatTime, helper);
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
		/// Updates a Wechat_LotteryActivityPrize into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="activityID">activityID</param>
		/// <param name="levelName">levelName</param>
		/// <param name="quota">quota</param>
		/// <param name="prizeName">prizeName</param>
		/// <param name="prizeQuantity">prizeQuantity</param>
		/// <param name="prizeUnit">prizeUnit</param>
		/// <param name="type">type</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="repeatTime">repeatTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_LotteryActivityPrize(int @iD, int @activityID, string @levelName, int @quota, string @prizeName, decimal @prizeQuantity, string @prizeUnit, string @type, int @sortOrder, int @repeatTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ActivityID] int,
	[LevelName] nvarchar(50),
	[Quota] int,
	[PrizeName] nvarchar(50),
	[PrizeQuantity] decimal(18, 2),
	[PrizeUnit] nvarchar(50),
	[Type] nvarchar(50),
	[SortOrder] int,
	[RepeatTime] int
);

UPDATE [dbo].[Wechat_LotteryActivityPrize] SET 
	[Wechat_LotteryActivityPrize].[ActivityID] = @ActivityID,
	[Wechat_LotteryActivityPrize].[LevelName] = @LevelName,
	[Wechat_LotteryActivityPrize].[Quota] = @Quota,
	[Wechat_LotteryActivityPrize].[PrizeName] = @PrizeName,
	[Wechat_LotteryActivityPrize].[PrizeQuantity] = @PrizeQuantity,
	[Wechat_LotteryActivityPrize].[PrizeUnit] = @PrizeUnit,
	[Wechat_LotteryActivityPrize].[Type] = @Type,
	[Wechat_LotteryActivityPrize].[SortOrder] = @SortOrder,
	[Wechat_LotteryActivityPrize].[RepeatTime] = @RepeatTime 
output 
	INSERTED.[ID],
	INSERTED.[ActivityID],
	INSERTED.[LevelName],
	INSERTED.[Quota],
	INSERTED.[PrizeName],
	INSERTED.[PrizeQuantity],
	INSERTED.[PrizeUnit],
	INSERTED.[Type],
	INSERTED.[SortOrder],
	INSERTED.[RepeatTime]
into @table
WHERE 
	[Wechat_LotteryActivityPrize].[ID] = @ID

SELECT 
	[ID],
	[ActivityID],
	[LevelName],
	[Quota],
	[PrizeName],
	[PrizeQuantity],
	[PrizeUnit],
	[Type],
	[SortOrder],
	[RepeatTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ActivityID", EntityBase.GetDatabaseValue(@activityID)));
			parameters.Add(new SqlParameter("@LevelName", EntityBase.GetDatabaseValue(@levelName)));
			parameters.Add(new SqlParameter("@Quota", EntityBase.GetDatabaseValue(@quota)));
			parameters.Add(new SqlParameter("@PrizeName", EntityBase.GetDatabaseValue(@prizeName)));
			parameters.Add(new SqlParameter("@PrizeQuantity", EntityBase.GetDatabaseValue(@prizeQuantity)));
			parameters.Add(new SqlParameter("@PrizeUnit", EntityBase.GetDatabaseValue(@prizeUnit)));
			parameters.Add(new SqlParameter("@Type", EntityBase.GetDatabaseValue(@type)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@RepeatTime", EntityBase.GetDatabaseValue(@repeatTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_LotteryActivityPrize from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_LotteryActivityPrize(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_LotteryActivityPrize(@iD, helper);
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
		/// Deletes a Wechat_LotteryActivityPrize from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_LotteryActivityPrize(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_LotteryActivityPrize]
WHERE 
	[Wechat_LotteryActivityPrize].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_LotteryActivityPrize object.
		/// </summary>
		/// <returns>The newly created Wechat_LotteryActivityPrize object.</returns>
		public static Wechat_LotteryActivityPrize CreateWechat_LotteryActivityPrize()
		{
			return InitializeNew<Wechat_LotteryActivityPrize>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_LotteryActivityPrize by a Wechat_LotteryActivityPrize's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_LotteryActivityPrize</returns>
		public static Wechat_LotteryActivityPrize GetWechat_LotteryActivityPrize(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_LotteryActivityPrize.SelectFieldList + @"
FROM [dbo].[Wechat_LotteryActivityPrize] 
WHERE 
	[Wechat_LotteryActivityPrize].[ID] = @ID " + Wechat_LotteryActivityPrize.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_LotteryActivityPrize>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_LotteryActivityPrize by a Wechat_LotteryActivityPrize's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_LotteryActivityPrize</returns>
		public static Wechat_LotteryActivityPrize GetWechat_LotteryActivityPrize(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_LotteryActivityPrize.SelectFieldList + @"
FROM [dbo].[Wechat_LotteryActivityPrize] 
WHERE 
	[Wechat_LotteryActivityPrize].[ID] = @ID " + Wechat_LotteryActivityPrize.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_LotteryActivityPrize>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityPrize objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_LotteryActivityPrize objects.</returns>
		public static EntityList<Wechat_LotteryActivityPrize> GetWechat_LotteryActivityPrizes()
		{
			string commandText = @"
SELECT " + Wechat_LotteryActivityPrize.SelectFieldList + "FROM [dbo].[Wechat_LotteryActivityPrize] " + Wechat_LotteryActivityPrize.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_LotteryActivityPrize>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_LotteryActivityPrize objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_LotteryActivityPrize objects.</returns>
        public static EntityList<Wechat_LotteryActivityPrize> GetWechat_LotteryActivityPrizes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_LotteryActivityPrize>(SelectFieldList, "FROM [dbo].[Wechat_LotteryActivityPrize]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_LotteryActivityPrize objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_LotteryActivityPrize objects.</returns>
        public static EntityList<Wechat_LotteryActivityPrize> GetWechat_LotteryActivityPrizes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_LotteryActivityPrize>(SelectFieldList, "FROM [dbo].[Wechat_LotteryActivityPrize]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityPrize objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivityPrize objects.</returns>
		protected static EntityList<Wechat_LotteryActivityPrize> GetWechat_LotteryActivityPrizes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_LotteryActivityPrizes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityPrize objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivityPrize objects.</returns>
		protected static EntityList<Wechat_LotteryActivityPrize> GetWechat_LotteryActivityPrizes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_LotteryActivityPrizes(string.Empty, where, parameters, Wechat_LotteryActivityPrize.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityPrize objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivityPrize objects.</returns>
		protected static EntityList<Wechat_LotteryActivityPrize> GetWechat_LotteryActivityPrizes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_LotteryActivityPrizes(prefix, where, parameters, Wechat_LotteryActivityPrize.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityPrize objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivityPrize objects.</returns>
		protected static EntityList<Wechat_LotteryActivityPrize> GetWechat_LotteryActivityPrizes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_LotteryActivityPrizes(string.Empty, where, parameters, Wechat_LotteryActivityPrize.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityPrize objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivityPrize objects.</returns>
		protected static EntityList<Wechat_LotteryActivityPrize> GetWechat_LotteryActivityPrizes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_LotteryActivityPrizes(prefix, where, parameters, Wechat_LotteryActivityPrize.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_LotteryActivityPrize objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_LotteryActivityPrize objects.</returns>
		protected static EntityList<Wechat_LotteryActivityPrize> GetWechat_LotteryActivityPrizes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_LotteryActivityPrize.SelectFieldList + "FROM [dbo].[Wechat_LotteryActivityPrize] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_LotteryActivityPrize>(reader);
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
        protected static EntityList<Wechat_LotteryActivityPrize> GetWechat_LotteryActivityPrizes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_LotteryActivityPrize>(SelectFieldList, "FROM [dbo].[Wechat_LotteryActivityPrize] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_LotteryActivityPrize objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_LotteryActivityPrizeCount()
        {
            return GetWechat_LotteryActivityPrizeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_LotteryActivityPrize objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_LotteryActivityPrizeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_LotteryActivityPrize] " + where;

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
		public static partial class Wechat_LotteryActivityPrize_Properties
		{
			public const string ID = "ID";
			public const string ActivityID = "ActivityID";
			public const string LevelName = "LevelName";
			public const string Quota = "Quota";
			public const string PrizeName = "PrizeName";
			public const string PrizeQuantity = "PrizeQuantity";
			public const string PrizeUnit = "PrizeUnit";
			public const string Type = "Type";
			public const string SortOrder = "SortOrder";
			public const string RepeatTime = "RepeatTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ActivityID" , "int:活动ID"},
    			 {"LevelName" , "string:奖品等级"},
    			 {"Quota" , "int:中奖名额"},
    			 {"PrizeName" , "string:奖品名称"},
    			 {"PrizeQuantity" , "decimal:奖品金额/数量"},
    			 {"PrizeUnit" , "string:奖品单位"},
    			 {"Type" , "string:奖品类型(红包、实物、积分etc)"},
    			 {"SortOrder" , "int:"},
    			 {"RepeatTime" , "int:"},
            };
		}
		#endregion
	}
}
