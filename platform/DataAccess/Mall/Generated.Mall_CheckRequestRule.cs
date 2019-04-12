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
	/// This object represents the properties and methods of a Mall_CheckRequestRule.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_CheckRequestRule 
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
		private int _requestID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RequestID
		{
			[DebuggerStepThrough()]
			get { return this._requestID; }
			set 
			{
				if (this._requestID != value) 
				{
					this._requestID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RequestID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _ruleID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RuleID
		{
			[DebuggerStepThrough()]
			get { return this._ruleID; }
			set 
			{
				if (this._ruleID != value) 
				{
					this._ruleID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RuleID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _earnType = int.MinValue;
		/// <summary>
		/// 1-奖励 2-惩罚
		/// </summary>
        [Description("1-奖励 2-惩罚")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int EarnType
		{
			[DebuggerStepThrough()]
			get { return this._earnType; }
			set 
			{
				if (this._earnType != value) 
				{
					this._earnType = value;
					this.IsDirty = true;	
					OnPropertyChanged("EarnType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _pointValue = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int PointValue
		{
			[DebuggerStepThrough()]
			get { return this._pointValue; }
			set 
			{
				if (this._pointValue != value) 
				{
					this._pointValue = value;
					this.IsDirty = true;	
					OnPropertyChanged("PointValue");
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
		private string _title = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Title
		{
			[DebuggerStepThrough()]
			get { return this._title; }
			set 
			{
				if (this._title != value) 
				{
					this._title = value;
					this.IsDirty = true;	
					OnPropertyChanged("Title");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _fixedPointMonth = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int FixedPointMonth
		{
			[DebuggerStepThrough()]
			get { return this._fixedPointMonth; }
			set 
			{
				if (this._fixedPointMonth != value) 
				{
					this._fixedPointMonth = value;
					this.IsDirty = true;	
					OnPropertyChanged("FixedPointMonth");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _fixedPointDateTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime FixedPointDateTime
		{
			[DebuggerStepThrough()]
			get { return this._fixedPointDateTime; }
			set 
			{
				if (this._fixedPointDateTime != value) 
				{
					this._fixedPointDateTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("FixedPointDateTime");
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
	[RequestID] int,
	[RuleID] int,
	[EarnType] int,
	[PointValue] int,
	[AddTime] datetime,
	[Title] nvarchar(200),
	[FixedPointMonth] int,
	[FixedPointDateTime] datetime
);

INSERT INTO [dbo].[Mall_CheckRequestRule] (
	[Mall_CheckRequestRule].[RequestID],
	[Mall_CheckRequestRule].[RuleID],
	[Mall_CheckRequestRule].[EarnType],
	[Mall_CheckRequestRule].[PointValue],
	[Mall_CheckRequestRule].[AddTime],
	[Mall_CheckRequestRule].[Title],
	[Mall_CheckRequestRule].[FixedPointMonth],
	[Mall_CheckRequestRule].[FixedPointDateTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[RequestID],
	INSERTED.[RuleID],
	INSERTED.[EarnType],
	INSERTED.[PointValue],
	INSERTED.[AddTime],
	INSERTED.[Title],
	INSERTED.[FixedPointMonth],
	INSERTED.[FixedPointDateTime]
into @table
VALUES ( 
	@RequestID,
	@RuleID,
	@EarnType,
	@PointValue,
	@AddTime,
	@Title,
	@FixedPointMonth,
	@FixedPointDateTime 
); 

SELECT 
	[ID],
	[RequestID],
	[RuleID],
	[EarnType],
	[PointValue],
	[AddTime],
	[Title],
	[FixedPointMonth],
	[FixedPointDateTime] 
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
	[RequestID] int,
	[RuleID] int,
	[EarnType] int,
	[PointValue] int,
	[AddTime] datetime,
	[Title] nvarchar(200),
	[FixedPointMonth] int,
	[FixedPointDateTime] datetime
);

UPDATE [dbo].[Mall_CheckRequestRule] SET 
	[Mall_CheckRequestRule].[RequestID] = @RequestID,
	[Mall_CheckRequestRule].[RuleID] = @RuleID,
	[Mall_CheckRequestRule].[EarnType] = @EarnType,
	[Mall_CheckRequestRule].[PointValue] = @PointValue,
	[Mall_CheckRequestRule].[AddTime] = @AddTime,
	[Mall_CheckRequestRule].[Title] = @Title,
	[Mall_CheckRequestRule].[FixedPointMonth] = @FixedPointMonth,
	[Mall_CheckRequestRule].[FixedPointDateTime] = @FixedPointDateTime 
output 
	INSERTED.[ID],
	INSERTED.[RequestID],
	INSERTED.[RuleID],
	INSERTED.[EarnType],
	INSERTED.[PointValue],
	INSERTED.[AddTime],
	INSERTED.[Title],
	INSERTED.[FixedPointMonth],
	INSERTED.[FixedPointDateTime]
into @table
WHERE 
	[Mall_CheckRequestRule].[ID] = @ID

SELECT 
	[ID],
	[RequestID],
	[RuleID],
	[EarnType],
	[PointValue],
	[AddTime],
	[Title],
	[FixedPointMonth],
	[FixedPointDateTime] 
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
DELETE FROM [dbo].[Mall_CheckRequestRule]
WHERE 
	[Mall_CheckRequestRule].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_CheckRequestRule() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_CheckRequestRule(this.ID));
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
	[Mall_CheckRequestRule].[ID],
	[Mall_CheckRequestRule].[RequestID],
	[Mall_CheckRequestRule].[RuleID],
	[Mall_CheckRequestRule].[EarnType],
	[Mall_CheckRequestRule].[PointValue],
	[Mall_CheckRequestRule].[AddTime],
	[Mall_CheckRequestRule].[Title],
	[Mall_CheckRequestRule].[FixedPointMonth],
	[Mall_CheckRequestRule].[FixedPointDateTime]
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
                return "Mall_CheckRequestRule";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_CheckRequestRule into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="requestID">requestID</param>
		/// <param name="ruleID">ruleID</param>
		/// <param name="earnType">earnType</param>
		/// <param name="pointValue">pointValue</param>
		/// <param name="addTime">addTime</param>
		/// <param name="title">title</param>
		/// <param name="fixedPointMonth">fixedPointMonth</param>
		/// <param name="fixedPointDateTime">fixedPointDateTime</param>
		public static void InsertMall_CheckRequestRule(int @requestID, int @ruleID, int @earnType, int @pointValue, DateTime @addTime, string @title, int @fixedPointMonth, DateTime @fixedPointDateTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_CheckRequestRule(@requestID, @ruleID, @earnType, @pointValue, @addTime, @title, @fixedPointMonth, @fixedPointDateTime, helper);
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
		/// Insert a Mall_CheckRequestRule into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="requestID">requestID</param>
		/// <param name="ruleID">ruleID</param>
		/// <param name="earnType">earnType</param>
		/// <param name="pointValue">pointValue</param>
		/// <param name="addTime">addTime</param>
		/// <param name="title">title</param>
		/// <param name="fixedPointMonth">fixedPointMonth</param>
		/// <param name="fixedPointDateTime">fixedPointDateTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_CheckRequestRule(int @requestID, int @ruleID, int @earnType, int @pointValue, DateTime @addTime, string @title, int @fixedPointMonth, DateTime @fixedPointDateTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RequestID] int,
	[RuleID] int,
	[EarnType] int,
	[PointValue] int,
	[AddTime] datetime,
	[Title] nvarchar(200),
	[FixedPointMonth] int,
	[FixedPointDateTime] datetime
);

INSERT INTO [dbo].[Mall_CheckRequestRule] (
	[Mall_CheckRequestRule].[RequestID],
	[Mall_CheckRequestRule].[RuleID],
	[Mall_CheckRequestRule].[EarnType],
	[Mall_CheckRequestRule].[PointValue],
	[Mall_CheckRequestRule].[AddTime],
	[Mall_CheckRequestRule].[Title],
	[Mall_CheckRequestRule].[FixedPointMonth],
	[Mall_CheckRequestRule].[FixedPointDateTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[RequestID],
	INSERTED.[RuleID],
	INSERTED.[EarnType],
	INSERTED.[PointValue],
	INSERTED.[AddTime],
	INSERTED.[Title],
	INSERTED.[FixedPointMonth],
	INSERTED.[FixedPointDateTime]
into @table
VALUES ( 
	@RequestID,
	@RuleID,
	@EarnType,
	@PointValue,
	@AddTime,
	@Title,
	@FixedPointMonth,
	@FixedPointDateTime 
); 

SELECT 
	[ID],
	[RequestID],
	[RuleID],
	[EarnType],
	[PointValue],
	[AddTime],
	[Title],
	[FixedPointMonth],
	[FixedPointDateTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RequestID", EntityBase.GetDatabaseValue(@requestID)));
			parameters.Add(new SqlParameter("@RuleID", EntityBase.GetDatabaseValue(@ruleID)));
			parameters.Add(new SqlParameter("@EarnType", EntityBase.GetDatabaseValue(@earnType)));
			parameters.Add(new SqlParameter("@PointValue", EntityBase.GetDatabaseValue(@pointValue)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@FixedPointMonth", EntityBase.GetDatabaseValue(@fixedPointMonth)));
			parameters.Add(new SqlParameter("@FixedPointDateTime", EntityBase.GetDatabaseValue(@fixedPointDateTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_CheckRequestRule into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="requestID">requestID</param>
		/// <param name="ruleID">ruleID</param>
		/// <param name="earnType">earnType</param>
		/// <param name="pointValue">pointValue</param>
		/// <param name="addTime">addTime</param>
		/// <param name="title">title</param>
		/// <param name="fixedPointMonth">fixedPointMonth</param>
		/// <param name="fixedPointDateTime">fixedPointDateTime</param>
		public static void UpdateMall_CheckRequestRule(int @iD, int @requestID, int @ruleID, int @earnType, int @pointValue, DateTime @addTime, string @title, int @fixedPointMonth, DateTime @fixedPointDateTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_CheckRequestRule(@iD, @requestID, @ruleID, @earnType, @pointValue, @addTime, @title, @fixedPointMonth, @fixedPointDateTime, helper);
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
		/// Updates a Mall_CheckRequestRule into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="requestID">requestID</param>
		/// <param name="ruleID">ruleID</param>
		/// <param name="earnType">earnType</param>
		/// <param name="pointValue">pointValue</param>
		/// <param name="addTime">addTime</param>
		/// <param name="title">title</param>
		/// <param name="fixedPointMonth">fixedPointMonth</param>
		/// <param name="fixedPointDateTime">fixedPointDateTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_CheckRequestRule(int @iD, int @requestID, int @ruleID, int @earnType, int @pointValue, DateTime @addTime, string @title, int @fixedPointMonth, DateTime @fixedPointDateTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RequestID] int,
	[RuleID] int,
	[EarnType] int,
	[PointValue] int,
	[AddTime] datetime,
	[Title] nvarchar(200),
	[FixedPointMonth] int,
	[FixedPointDateTime] datetime
);

UPDATE [dbo].[Mall_CheckRequestRule] SET 
	[Mall_CheckRequestRule].[RequestID] = @RequestID,
	[Mall_CheckRequestRule].[RuleID] = @RuleID,
	[Mall_CheckRequestRule].[EarnType] = @EarnType,
	[Mall_CheckRequestRule].[PointValue] = @PointValue,
	[Mall_CheckRequestRule].[AddTime] = @AddTime,
	[Mall_CheckRequestRule].[Title] = @Title,
	[Mall_CheckRequestRule].[FixedPointMonth] = @FixedPointMonth,
	[Mall_CheckRequestRule].[FixedPointDateTime] = @FixedPointDateTime 
output 
	INSERTED.[ID],
	INSERTED.[RequestID],
	INSERTED.[RuleID],
	INSERTED.[EarnType],
	INSERTED.[PointValue],
	INSERTED.[AddTime],
	INSERTED.[Title],
	INSERTED.[FixedPointMonth],
	INSERTED.[FixedPointDateTime]
into @table
WHERE 
	[Mall_CheckRequestRule].[ID] = @ID

SELECT 
	[ID],
	[RequestID],
	[RuleID],
	[EarnType],
	[PointValue],
	[AddTime],
	[Title],
	[FixedPointMonth],
	[FixedPointDateTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RequestID", EntityBase.GetDatabaseValue(@requestID)));
			parameters.Add(new SqlParameter("@RuleID", EntityBase.GetDatabaseValue(@ruleID)));
			parameters.Add(new SqlParameter("@EarnType", EntityBase.GetDatabaseValue(@earnType)));
			parameters.Add(new SqlParameter("@PointValue", EntityBase.GetDatabaseValue(@pointValue)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@FixedPointMonth", EntityBase.GetDatabaseValue(@fixedPointMonth)));
			parameters.Add(new SqlParameter("@FixedPointDateTime", EntityBase.GetDatabaseValue(@fixedPointDateTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_CheckRequestRule from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_CheckRequestRule(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_CheckRequestRule(@iD, helper);
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
		/// Deletes a Mall_CheckRequestRule from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_CheckRequestRule(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_CheckRequestRule]
WHERE 
	[Mall_CheckRequestRule].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_CheckRequestRule object.
		/// </summary>
		/// <returns>The newly created Mall_CheckRequestRule object.</returns>
		public static Mall_CheckRequestRule CreateMall_CheckRequestRule()
		{
			return InitializeNew<Mall_CheckRequestRule>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_CheckRequestRule by a Mall_CheckRequestRule's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_CheckRequestRule</returns>
		public static Mall_CheckRequestRule GetMall_CheckRequestRule(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_CheckRequestRule.SelectFieldList + @"
FROM [dbo].[Mall_CheckRequestRule] 
WHERE 
	[Mall_CheckRequestRule].[ID] = @ID " + Mall_CheckRequestRule.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_CheckRequestRule>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_CheckRequestRule by a Mall_CheckRequestRule's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_CheckRequestRule</returns>
		public static Mall_CheckRequestRule GetMall_CheckRequestRule(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_CheckRequestRule.SelectFieldList + @"
FROM [dbo].[Mall_CheckRequestRule] 
WHERE 
	[Mall_CheckRequestRule].[ID] = @ID " + Mall_CheckRequestRule.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_CheckRequestRule>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestRule objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_CheckRequestRule objects.</returns>
		public static EntityList<Mall_CheckRequestRule> GetMall_CheckRequestRules()
		{
			string commandText = @"
SELECT " + Mall_CheckRequestRule.SelectFieldList + "FROM [dbo].[Mall_CheckRequestRule] " + Mall_CheckRequestRule.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_CheckRequestRule>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_CheckRequestRule objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_CheckRequestRule objects.</returns>
        public static EntityList<Mall_CheckRequestRule> GetMall_CheckRequestRules(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckRequestRule>(SelectFieldList, "FROM [dbo].[Mall_CheckRequestRule]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_CheckRequestRule objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_CheckRequestRule objects.</returns>
        public static EntityList<Mall_CheckRequestRule> GetMall_CheckRequestRules(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckRequestRule>(SelectFieldList, "FROM [dbo].[Mall_CheckRequestRule]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestRule objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_CheckRequestRule objects.</returns>
		protected static EntityList<Mall_CheckRequestRule> GetMall_CheckRequestRules(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckRequestRules(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestRule objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequestRule objects.</returns>
		protected static EntityList<Mall_CheckRequestRule> GetMall_CheckRequestRules(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckRequestRules(string.Empty, where, parameters, Mall_CheckRequestRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestRule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequestRule objects.</returns>
		protected static EntityList<Mall_CheckRequestRule> GetMall_CheckRequestRules(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CheckRequestRules(prefix, where, parameters, Mall_CheckRequestRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestRule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequestRule objects.</returns>
		protected static EntityList<Mall_CheckRequestRule> GetMall_CheckRequestRules(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_CheckRequestRules(string.Empty, where, parameters, Mall_CheckRequestRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestRule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_CheckRequestRule objects.</returns>
		protected static EntityList<Mall_CheckRequestRule> GetMall_CheckRequestRules(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_CheckRequestRules(prefix, where, parameters, Mall_CheckRequestRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CheckRequestRule objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_CheckRequestRule objects.</returns>
		protected static EntityList<Mall_CheckRequestRule> GetMall_CheckRequestRules(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_CheckRequestRule.SelectFieldList + "FROM [dbo].[Mall_CheckRequestRule] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_CheckRequestRule>(reader);
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
        protected static EntityList<Mall_CheckRequestRule> GetMall_CheckRequestRules(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CheckRequestRule>(SelectFieldList, "FROM [dbo].[Mall_CheckRequestRule] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_CheckRequestRule objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CheckRequestRuleCount()
        {
            return GetMall_CheckRequestRuleCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_CheckRequestRule objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CheckRequestRuleCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_CheckRequestRule] " + where;

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
		public static partial class Mall_CheckRequestRule_Properties
		{
			public const string ID = "ID";
			public const string RequestID = "RequestID";
			public const string RuleID = "RuleID";
			public const string EarnType = "EarnType";
			public const string PointValue = "PointValue";
			public const string AddTime = "AddTime";
			public const string Title = "Title";
			public const string FixedPointMonth = "FixedPointMonth";
			public const string FixedPointDateTime = "FixedPointDateTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RequestID" , "int:"},
    			 {"RuleID" , "int:"},
    			 {"EarnType" , "int:1-奖励 2-惩罚"},
    			 {"PointValue" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"Title" , "string:"},
    			 {"FixedPointMonth" , "int:"},
    			 {"FixedPointDateTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
