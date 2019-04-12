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
	/// This object represents the properties and methods of a Mall_PointRule.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_PointRule 
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
		private string _ruleName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RuleName
		{
			[DebuggerStepThrough()]
			get { return this._ruleName; }
			set 
			{
				if (this._ruleName != value) 
				{
					this._ruleName = value;
					this.IsDirty = true;	
					OnPropertyChanged("RuleName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _ruleType = int.MinValue;
		/// <summary>
		/// 1-购买商品返还
		/// </summary>
        [Description("1-购买商品返还")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RuleType
		{
			[DebuggerStepThrough()]
			get { return this._ruleType; }
			set 
			{
				if (this._ruleType != value) 
				{
					this._ruleType = value;
					this.IsDirty = true;	
					OnPropertyChanged("RuleType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _ruleSummary = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RuleSummary
		{
			[DebuggerStepThrough()]
			get { return this._ruleSummary; }
			set 
			{
				if (this._ruleSummary != value) 
				{
					this._ruleSummary = value;
					this.IsDirty = true;	
					OnPropertyChanged("RuleSummary");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _ruleStatus = int.MinValue;
		/// <summary>
		/// 1-有效 0-失效
		/// </summary>
        [Description("1-有效 0-失效")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RuleStatus
		{
			[DebuggerStepThrough()]
			get { return this._ruleStatus; }
			set 
			{
				if (this._ruleStatus != value) 
				{
					this._ruleStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("RuleStatus");
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
		private string _productIDRange = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProductIDRange
		{
			[DebuggerStepThrough()]
			get { return this._productIDRange; }
			set 
			{
				if (this._productIDRange != value) 
				{
					this._productIDRange = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductIDRange");
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
		private string _addUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
		private int _returnPoint = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ReturnPoint
		{
			[DebuggerStepThrough()]
			get { return this._returnPoint; }
			set 
			{
				if (this._returnPoint != value) 
				{
					this._returnPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("ReturnPoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isUseForAllProduct = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsUseForAllProduct
		{
			[DebuggerStepThrough()]
			get { return this._isUseForAllProduct; }
			set 
			{
				if (this._isUseForAllProduct != value) 
				{
					this._isUseForAllProduct = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsUseForAllProduct");
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
	[RuleName] nvarchar(500),
	[RuleType] int,
	[RuleSummary] ntext,
	[RuleStatus] int,
	[StartTime] datetime,
	[EndTime] datetime,
	[ProductIDRange] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[ReturnPoint] int,
	[IsUseForAllProduct] bit
);

INSERT INTO [dbo].[Mall_PointRule] (
	[Mall_PointRule].[RuleName],
	[Mall_PointRule].[RuleType],
	[Mall_PointRule].[RuleSummary],
	[Mall_PointRule].[RuleStatus],
	[Mall_PointRule].[StartTime],
	[Mall_PointRule].[EndTime],
	[Mall_PointRule].[ProductIDRange],
	[Mall_PointRule].[AddTime],
	[Mall_PointRule].[AddUserName],
	[Mall_PointRule].[ReturnPoint],
	[Mall_PointRule].[IsUseForAllProduct]
) 
output 
	INSERTED.[ID],
	INSERTED.[RuleName],
	INSERTED.[RuleType],
	INSERTED.[RuleSummary],
	INSERTED.[RuleStatus],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[ProductIDRange],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ReturnPoint],
	INSERTED.[IsUseForAllProduct]
into @table
VALUES ( 
	@RuleName,
	@RuleType,
	@RuleSummary,
	@RuleStatus,
	@StartTime,
	@EndTime,
	@ProductIDRange,
	@AddTime,
	@AddUserName,
	@ReturnPoint,
	@IsUseForAllProduct 
); 

SELECT 
	[ID],
	[RuleName],
	[RuleType],
	[RuleSummary],
	[RuleStatus],
	[StartTime],
	[EndTime],
	[ProductIDRange],
	[AddTime],
	[AddUserName],
	[ReturnPoint],
	[IsUseForAllProduct] 
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
	[RuleName] nvarchar(500),
	[RuleType] int,
	[RuleSummary] ntext,
	[RuleStatus] int,
	[StartTime] datetime,
	[EndTime] datetime,
	[ProductIDRange] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[ReturnPoint] int,
	[IsUseForAllProduct] bit
);

UPDATE [dbo].[Mall_PointRule] SET 
	[Mall_PointRule].[RuleName] = @RuleName,
	[Mall_PointRule].[RuleType] = @RuleType,
	[Mall_PointRule].[RuleSummary] = @RuleSummary,
	[Mall_PointRule].[RuleStatus] = @RuleStatus,
	[Mall_PointRule].[StartTime] = @StartTime,
	[Mall_PointRule].[EndTime] = @EndTime,
	[Mall_PointRule].[ProductIDRange] = @ProductIDRange,
	[Mall_PointRule].[AddTime] = @AddTime,
	[Mall_PointRule].[AddUserName] = @AddUserName,
	[Mall_PointRule].[ReturnPoint] = @ReturnPoint,
	[Mall_PointRule].[IsUseForAllProduct] = @IsUseForAllProduct 
output 
	INSERTED.[ID],
	INSERTED.[RuleName],
	INSERTED.[RuleType],
	INSERTED.[RuleSummary],
	INSERTED.[RuleStatus],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[ProductIDRange],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ReturnPoint],
	INSERTED.[IsUseForAllProduct]
into @table
WHERE 
	[Mall_PointRule].[ID] = @ID

SELECT 
	[ID],
	[RuleName],
	[RuleType],
	[RuleSummary],
	[RuleStatus],
	[StartTime],
	[EndTime],
	[ProductIDRange],
	[AddTime],
	[AddUserName],
	[ReturnPoint],
	[IsUseForAllProduct] 
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
DELETE FROM [dbo].[Mall_PointRule]
WHERE 
	[Mall_PointRule].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_PointRule() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_PointRule(this.ID));
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
	[Mall_PointRule].[ID],
	[Mall_PointRule].[RuleName],
	[Mall_PointRule].[RuleType],
	[Mall_PointRule].[RuleSummary],
	[Mall_PointRule].[RuleStatus],
	[Mall_PointRule].[StartTime],
	[Mall_PointRule].[EndTime],
	[Mall_PointRule].[ProductIDRange],
	[Mall_PointRule].[AddTime],
	[Mall_PointRule].[AddUserName],
	[Mall_PointRule].[ReturnPoint],
	[Mall_PointRule].[IsUseForAllProduct]
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
                return "Mall_PointRule";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_PointRule into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="ruleName">ruleName</param>
		/// <param name="ruleType">ruleType</param>
		/// <param name="ruleSummary">ruleSummary</param>
		/// <param name="ruleStatus">ruleStatus</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="productIDRange">productIDRange</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="returnPoint">returnPoint</param>
		/// <param name="isUseForAllProduct">isUseForAllProduct</param>
		public static void InsertMall_PointRule(string @ruleName, int @ruleType, string @ruleSummary, int @ruleStatus, DateTime @startTime, DateTime @endTime, string @productIDRange, DateTime @addTime, string @addUserName, int @returnPoint, bool @isUseForAllProduct)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_PointRule(@ruleName, @ruleType, @ruleSummary, @ruleStatus, @startTime, @endTime, @productIDRange, @addTime, @addUserName, @returnPoint, @isUseForAllProduct, helper);
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
		/// Insert a Mall_PointRule into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="ruleName">ruleName</param>
		/// <param name="ruleType">ruleType</param>
		/// <param name="ruleSummary">ruleSummary</param>
		/// <param name="ruleStatus">ruleStatus</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="productIDRange">productIDRange</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="returnPoint">returnPoint</param>
		/// <param name="isUseForAllProduct">isUseForAllProduct</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_PointRule(string @ruleName, int @ruleType, string @ruleSummary, int @ruleStatus, DateTime @startTime, DateTime @endTime, string @productIDRange, DateTime @addTime, string @addUserName, int @returnPoint, bool @isUseForAllProduct, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RuleName] nvarchar(500),
	[RuleType] int,
	[RuleSummary] ntext,
	[RuleStatus] int,
	[StartTime] datetime,
	[EndTime] datetime,
	[ProductIDRange] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[ReturnPoint] int,
	[IsUseForAllProduct] bit
);

INSERT INTO [dbo].[Mall_PointRule] (
	[Mall_PointRule].[RuleName],
	[Mall_PointRule].[RuleType],
	[Mall_PointRule].[RuleSummary],
	[Mall_PointRule].[RuleStatus],
	[Mall_PointRule].[StartTime],
	[Mall_PointRule].[EndTime],
	[Mall_PointRule].[ProductIDRange],
	[Mall_PointRule].[AddTime],
	[Mall_PointRule].[AddUserName],
	[Mall_PointRule].[ReturnPoint],
	[Mall_PointRule].[IsUseForAllProduct]
) 
output 
	INSERTED.[ID],
	INSERTED.[RuleName],
	INSERTED.[RuleType],
	INSERTED.[RuleSummary],
	INSERTED.[RuleStatus],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[ProductIDRange],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ReturnPoint],
	INSERTED.[IsUseForAllProduct]
into @table
VALUES ( 
	@RuleName,
	@RuleType,
	@RuleSummary,
	@RuleStatus,
	@StartTime,
	@EndTime,
	@ProductIDRange,
	@AddTime,
	@AddUserName,
	@ReturnPoint,
	@IsUseForAllProduct 
); 

SELECT 
	[ID],
	[RuleName],
	[RuleType],
	[RuleSummary],
	[RuleStatus],
	[StartTime],
	[EndTime],
	[ProductIDRange],
	[AddTime],
	[AddUserName],
	[ReturnPoint],
	[IsUseForAllProduct] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RuleName", EntityBase.GetDatabaseValue(@ruleName)));
			parameters.Add(new SqlParameter("@RuleType", EntityBase.GetDatabaseValue(@ruleType)));
			parameters.Add(new SqlParameter("@RuleSummary", EntityBase.GetDatabaseValue(@ruleSummary)));
			parameters.Add(new SqlParameter("@RuleStatus", EntityBase.GetDatabaseValue(@ruleStatus)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@ProductIDRange", EntityBase.GetDatabaseValue(@productIDRange)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@ReturnPoint", EntityBase.GetDatabaseValue(@returnPoint)));
			parameters.Add(new SqlParameter("@IsUseForAllProduct", @isUseForAllProduct));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_PointRule into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="ruleName">ruleName</param>
		/// <param name="ruleType">ruleType</param>
		/// <param name="ruleSummary">ruleSummary</param>
		/// <param name="ruleStatus">ruleStatus</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="productIDRange">productIDRange</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="returnPoint">returnPoint</param>
		/// <param name="isUseForAllProduct">isUseForAllProduct</param>
		public static void UpdateMall_PointRule(int @iD, string @ruleName, int @ruleType, string @ruleSummary, int @ruleStatus, DateTime @startTime, DateTime @endTime, string @productIDRange, DateTime @addTime, string @addUserName, int @returnPoint, bool @isUseForAllProduct)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_PointRule(@iD, @ruleName, @ruleType, @ruleSummary, @ruleStatus, @startTime, @endTime, @productIDRange, @addTime, @addUserName, @returnPoint, @isUseForAllProduct, helper);
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
		/// Updates a Mall_PointRule into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="ruleName">ruleName</param>
		/// <param name="ruleType">ruleType</param>
		/// <param name="ruleSummary">ruleSummary</param>
		/// <param name="ruleStatus">ruleStatus</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="productIDRange">productIDRange</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="returnPoint">returnPoint</param>
		/// <param name="isUseForAllProduct">isUseForAllProduct</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_PointRule(int @iD, string @ruleName, int @ruleType, string @ruleSummary, int @ruleStatus, DateTime @startTime, DateTime @endTime, string @productIDRange, DateTime @addTime, string @addUserName, int @returnPoint, bool @isUseForAllProduct, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RuleName] nvarchar(500),
	[RuleType] int,
	[RuleSummary] ntext,
	[RuleStatus] int,
	[StartTime] datetime,
	[EndTime] datetime,
	[ProductIDRange] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[ReturnPoint] int,
	[IsUseForAllProduct] bit
);

UPDATE [dbo].[Mall_PointRule] SET 
	[Mall_PointRule].[RuleName] = @RuleName,
	[Mall_PointRule].[RuleType] = @RuleType,
	[Mall_PointRule].[RuleSummary] = @RuleSummary,
	[Mall_PointRule].[RuleStatus] = @RuleStatus,
	[Mall_PointRule].[StartTime] = @StartTime,
	[Mall_PointRule].[EndTime] = @EndTime,
	[Mall_PointRule].[ProductIDRange] = @ProductIDRange,
	[Mall_PointRule].[AddTime] = @AddTime,
	[Mall_PointRule].[AddUserName] = @AddUserName,
	[Mall_PointRule].[ReturnPoint] = @ReturnPoint,
	[Mall_PointRule].[IsUseForAllProduct] = @IsUseForAllProduct 
output 
	INSERTED.[ID],
	INSERTED.[RuleName],
	INSERTED.[RuleType],
	INSERTED.[RuleSummary],
	INSERTED.[RuleStatus],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[ProductIDRange],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ReturnPoint],
	INSERTED.[IsUseForAllProduct]
into @table
WHERE 
	[Mall_PointRule].[ID] = @ID

SELECT 
	[ID],
	[RuleName],
	[RuleType],
	[RuleSummary],
	[RuleStatus],
	[StartTime],
	[EndTime],
	[ProductIDRange],
	[AddTime],
	[AddUserName],
	[ReturnPoint],
	[IsUseForAllProduct] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RuleName", EntityBase.GetDatabaseValue(@ruleName)));
			parameters.Add(new SqlParameter("@RuleType", EntityBase.GetDatabaseValue(@ruleType)));
			parameters.Add(new SqlParameter("@RuleSummary", EntityBase.GetDatabaseValue(@ruleSummary)));
			parameters.Add(new SqlParameter("@RuleStatus", EntityBase.GetDatabaseValue(@ruleStatus)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@ProductIDRange", EntityBase.GetDatabaseValue(@productIDRange)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@ReturnPoint", EntityBase.GetDatabaseValue(@returnPoint)));
			parameters.Add(new SqlParameter("@IsUseForAllProduct", @isUseForAllProduct));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_PointRule from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_PointRule(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_PointRule(@iD, helper);
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
		/// Deletes a Mall_PointRule from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_PointRule(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_PointRule]
WHERE 
	[Mall_PointRule].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_PointRule object.
		/// </summary>
		/// <returns>The newly created Mall_PointRule object.</returns>
		public static Mall_PointRule CreateMall_PointRule()
		{
			return InitializeNew<Mall_PointRule>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_PointRule by a Mall_PointRule's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_PointRule</returns>
		public static Mall_PointRule GetMall_PointRule(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_PointRule.SelectFieldList + @"
FROM [dbo].[Mall_PointRule] 
WHERE 
	[Mall_PointRule].[ID] = @ID " + Mall_PointRule.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_PointRule>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_PointRule by a Mall_PointRule's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_PointRule</returns>
		public static Mall_PointRule GetMall_PointRule(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_PointRule.SelectFieldList + @"
FROM [dbo].[Mall_PointRule] 
WHERE 
	[Mall_PointRule].[ID] = @ID " + Mall_PointRule.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_PointRule>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_PointRule objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_PointRule objects.</returns>
		public static EntityList<Mall_PointRule> GetMall_PointRules()
		{
			string commandText = @"
SELECT " + Mall_PointRule.SelectFieldList + "FROM [dbo].[Mall_PointRule] " + Mall_PointRule.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_PointRule>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_PointRule objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_PointRule objects.</returns>
        public static EntityList<Mall_PointRule> GetMall_PointRules(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_PointRule>(SelectFieldList, "FROM [dbo].[Mall_PointRule]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_PointRule objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_PointRule objects.</returns>
        public static EntityList<Mall_PointRule> GetMall_PointRules(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_PointRule>(SelectFieldList, "FROM [dbo].[Mall_PointRule]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_PointRule objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_PointRule objects.</returns>
		protected static EntityList<Mall_PointRule> GetMall_PointRules(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_PointRules(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_PointRule objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_PointRule objects.</returns>
		protected static EntityList<Mall_PointRule> GetMall_PointRules(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_PointRules(string.Empty, where, parameters, Mall_PointRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_PointRule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_PointRule objects.</returns>
		protected static EntityList<Mall_PointRule> GetMall_PointRules(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_PointRules(prefix, where, parameters, Mall_PointRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_PointRule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_PointRule objects.</returns>
		protected static EntityList<Mall_PointRule> GetMall_PointRules(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_PointRules(string.Empty, where, parameters, Mall_PointRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_PointRule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_PointRule objects.</returns>
		protected static EntityList<Mall_PointRule> GetMall_PointRules(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_PointRules(prefix, where, parameters, Mall_PointRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_PointRule objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_PointRule objects.</returns>
		protected static EntityList<Mall_PointRule> GetMall_PointRules(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_PointRule.SelectFieldList + "FROM [dbo].[Mall_PointRule] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_PointRule>(reader);
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
        protected static EntityList<Mall_PointRule> GetMall_PointRules(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_PointRule>(SelectFieldList, "FROM [dbo].[Mall_PointRule] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_PointRule objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_PointRuleCount()
        {
            return GetMall_PointRuleCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_PointRule objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_PointRuleCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_PointRule] " + where;

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
		public static partial class Mall_PointRule_Properties
		{
			public const string ID = "ID";
			public const string RuleName = "RuleName";
			public const string RuleType = "RuleType";
			public const string RuleSummary = "RuleSummary";
			public const string RuleStatus = "RuleStatus";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string ProductIDRange = "ProductIDRange";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string ReturnPoint = "ReturnPoint";
			public const string IsUseForAllProduct = "IsUseForAllProduct";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RuleName" , "string:"},
    			 {"RuleType" , "int:1-购买商品返还"},
    			 {"RuleSummary" , "string:"},
    			 {"RuleStatus" , "int:1-有效 0-失效"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"ProductIDRange" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"ReturnPoint" , "int:"},
    			 {"IsUseForAllProduct" , "bool:"},
            };
		}
		#endregion
	}
}
