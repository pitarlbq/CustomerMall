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
	/// This object represents the properties and methods of a Mall_BalanceRule.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_BalanceRule 
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
		private string _title = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private decimal _backPercent = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal BackPercent
		{
			[DebuggerStepThrough()]
			get { return this._backPercent; }
			set 
			{
				if (this._backPercent != value) 
				{
					this._backPercent = value;
					this.IsDirty = true;	
					OnPropertyChanged("BackPercent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _backAmount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal BackAmount
		{
			[DebuggerStepThrough()]
			get { return this._backAmount; }
			set 
			{
				if (this._backAmount != value) 
				{
					this._backAmount = value;
					this.IsDirty = true;	
					OnPropertyChanged("BackAmount");
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
		private bool _isActive = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsActive
		{
			[DebuggerStepThrough()]
			get { return this._isActive; }
			set 
			{
				if (this._isActive != value) 
				{
					this._isActive = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsActive");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _backBalanceType = int.MinValue;
		/// <summary>
		/// 1-按比例 2-固定金额
		/// </summary>
        [Description("1-按比例 2-固定金额")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int BackBalanceType
		{
			[DebuggerStepThrough()]
			get { return this._backBalanceType; }
			set 
			{
				if (this._backBalanceType != value) 
				{
					this._backBalanceType = value;
					this.IsDirty = true;	
					OnPropertyChanged("BackBalanceType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _ruleType = int.MinValue;
		/// <summary>
		/// 1-商家结算 2-业主结算
		/// </summary>
        [Description("1-商家结算 2-业主结算")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
	[Title] nvarchar(200),
	[BackPercent] decimal(18, 2),
	[BackAmount] decimal(18, 2),
	[Remark] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[IsActive] bit,
	[BackBalanceType] int,
	[RuleType] int
);

INSERT INTO [dbo].[Mall_BalanceRule] (
	[Mall_BalanceRule].[Title],
	[Mall_BalanceRule].[BackPercent],
	[Mall_BalanceRule].[BackAmount],
	[Mall_BalanceRule].[Remark],
	[Mall_BalanceRule].[AddTime],
	[Mall_BalanceRule].[AddUserName],
	[Mall_BalanceRule].[IsActive],
	[Mall_BalanceRule].[BackBalanceType],
	[Mall_BalanceRule].[RuleType]
) 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[BackPercent],
	INSERTED.[BackAmount],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[IsActive],
	INSERTED.[BackBalanceType],
	INSERTED.[RuleType]
into @table
VALUES ( 
	@Title,
	@BackPercent,
	@BackAmount,
	@Remark,
	@AddTime,
	@AddUserName,
	@IsActive,
	@BackBalanceType,
	@RuleType 
); 

SELECT 
	[ID],
	[Title],
	[BackPercent],
	[BackAmount],
	[Remark],
	[AddTime],
	[AddUserName],
	[IsActive],
	[BackBalanceType],
	[RuleType] 
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
	[Title] nvarchar(200),
	[BackPercent] decimal(18, 2),
	[BackAmount] decimal(18, 2),
	[Remark] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[IsActive] bit,
	[BackBalanceType] int,
	[RuleType] int
);

UPDATE [dbo].[Mall_BalanceRule] SET 
	[Mall_BalanceRule].[Title] = @Title,
	[Mall_BalanceRule].[BackPercent] = @BackPercent,
	[Mall_BalanceRule].[BackAmount] = @BackAmount,
	[Mall_BalanceRule].[Remark] = @Remark,
	[Mall_BalanceRule].[AddTime] = @AddTime,
	[Mall_BalanceRule].[AddUserName] = @AddUserName,
	[Mall_BalanceRule].[IsActive] = @IsActive,
	[Mall_BalanceRule].[BackBalanceType] = @BackBalanceType,
	[Mall_BalanceRule].[RuleType] = @RuleType 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[BackPercent],
	INSERTED.[BackAmount],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[IsActive],
	INSERTED.[BackBalanceType],
	INSERTED.[RuleType]
into @table
WHERE 
	[Mall_BalanceRule].[ID] = @ID

SELECT 
	[ID],
	[Title],
	[BackPercent],
	[BackAmount],
	[Remark],
	[AddTime],
	[AddUserName],
	[IsActive],
	[BackBalanceType],
	[RuleType] 
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
DELETE FROM [dbo].[Mall_BalanceRule]
WHERE 
	[Mall_BalanceRule].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_BalanceRule() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_BalanceRule(this.ID));
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
	[Mall_BalanceRule].[ID],
	[Mall_BalanceRule].[Title],
	[Mall_BalanceRule].[BackPercent],
	[Mall_BalanceRule].[BackAmount],
	[Mall_BalanceRule].[Remark],
	[Mall_BalanceRule].[AddTime],
	[Mall_BalanceRule].[AddUserName],
	[Mall_BalanceRule].[IsActive],
	[Mall_BalanceRule].[BackBalanceType],
	[Mall_BalanceRule].[RuleType]
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
                return "Mall_BalanceRule";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_BalanceRule into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="title">title</param>
		/// <param name="backPercent">backPercent</param>
		/// <param name="backAmount">backAmount</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="isActive">isActive</param>
		/// <param name="backBalanceType">backBalanceType</param>
		/// <param name="ruleType">ruleType</param>
		public static void InsertMall_BalanceRule(string @title, decimal @backPercent, decimal @backAmount, string @remark, DateTime @addTime, string @addUserName, bool @isActive, int @backBalanceType, int @ruleType)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_BalanceRule(@title, @backPercent, @backAmount, @remark, @addTime, @addUserName, @isActive, @backBalanceType, @ruleType, helper);
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
		/// Insert a Mall_BalanceRule into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="title">title</param>
		/// <param name="backPercent">backPercent</param>
		/// <param name="backAmount">backAmount</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="isActive">isActive</param>
		/// <param name="backBalanceType">backBalanceType</param>
		/// <param name="ruleType">ruleType</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_BalanceRule(string @title, decimal @backPercent, decimal @backAmount, string @remark, DateTime @addTime, string @addUserName, bool @isActive, int @backBalanceType, int @ruleType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Title] nvarchar(200),
	[BackPercent] decimal(18, 2),
	[BackAmount] decimal(18, 2),
	[Remark] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[IsActive] bit,
	[BackBalanceType] int,
	[RuleType] int
);

INSERT INTO [dbo].[Mall_BalanceRule] (
	[Mall_BalanceRule].[Title],
	[Mall_BalanceRule].[BackPercent],
	[Mall_BalanceRule].[BackAmount],
	[Mall_BalanceRule].[Remark],
	[Mall_BalanceRule].[AddTime],
	[Mall_BalanceRule].[AddUserName],
	[Mall_BalanceRule].[IsActive],
	[Mall_BalanceRule].[BackBalanceType],
	[Mall_BalanceRule].[RuleType]
) 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[BackPercent],
	INSERTED.[BackAmount],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[IsActive],
	INSERTED.[BackBalanceType],
	INSERTED.[RuleType]
into @table
VALUES ( 
	@Title,
	@BackPercent,
	@BackAmount,
	@Remark,
	@AddTime,
	@AddUserName,
	@IsActive,
	@BackBalanceType,
	@RuleType 
); 

SELECT 
	[ID],
	[Title],
	[BackPercent],
	[BackAmount],
	[Remark],
	[AddTime],
	[AddUserName],
	[IsActive],
	[BackBalanceType],
	[RuleType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@BackPercent", EntityBase.GetDatabaseValue(@backPercent)));
			parameters.Add(new SqlParameter("@BackAmount", EntityBase.GetDatabaseValue(@backAmount)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@BackBalanceType", EntityBase.GetDatabaseValue(@backBalanceType)));
			parameters.Add(new SqlParameter("@RuleType", EntityBase.GetDatabaseValue(@ruleType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_BalanceRule into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="title">title</param>
		/// <param name="backPercent">backPercent</param>
		/// <param name="backAmount">backAmount</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="isActive">isActive</param>
		/// <param name="backBalanceType">backBalanceType</param>
		/// <param name="ruleType">ruleType</param>
		public static void UpdateMall_BalanceRule(int @iD, string @title, decimal @backPercent, decimal @backAmount, string @remark, DateTime @addTime, string @addUserName, bool @isActive, int @backBalanceType, int @ruleType)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_BalanceRule(@iD, @title, @backPercent, @backAmount, @remark, @addTime, @addUserName, @isActive, @backBalanceType, @ruleType, helper);
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
		/// Updates a Mall_BalanceRule into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="title">title</param>
		/// <param name="backPercent">backPercent</param>
		/// <param name="backAmount">backAmount</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="isActive">isActive</param>
		/// <param name="backBalanceType">backBalanceType</param>
		/// <param name="ruleType">ruleType</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_BalanceRule(int @iD, string @title, decimal @backPercent, decimal @backAmount, string @remark, DateTime @addTime, string @addUserName, bool @isActive, int @backBalanceType, int @ruleType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Title] nvarchar(200),
	[BackPercent] decimal(18, 2),
	[BackAmount] decimal(18, 2),
	[Remark] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[IsActive] bit,
	[BackBalanceType] int,
	[RuleType] int
);

UPDATE [dbo].[Mall_BalanceRule] SET 
	[Mall_BalanceRule].[Title] = @Title,
	[Mall_BalanceRule].[BackPercent] = @BackPercent,
	[Mall_BalanceRule].[BackAmount] = @BackAmount,
	[Mall_BalanceRule].[Remark] = @Remark,
	[Mall_BalanceRule].[AddTime] = @AddTime,
	[Mall_BalanceRule].[AddUserName] = @AddUserName,
	[Mall_BalanceRule].[IsActive] = @IsActive,
	[Mall_BalanceRule].[BackBalanceType] = @BackBalanceType,
	[Mall_BalanceRule].[RuleType] = @RuleType 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[BackPercent],
	INSERTED.[BackAmount],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[IsActive],
	INSERTED.[BackBalanceType],
	INSERTED.[RuleType]
into @table
WHERE 
	[Mall_BalanceRule].[ID] = @ID

SELECT 
	[ID],
	[Title],
	[BackPercent],
	[BackAmount],
	[Remark],
	[AddTime],
	[AddUserName],
	[IsActive],
	[BackBalanceType],
	[RuleType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@BackPercent", EntityBase.GetDatabaseValue(@backPercent)));
			parameters.Add(new SqlParameter("@BackAmount", EntityBase.GetDatabaseValue(@backAmount)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@BackBalanceType", EntityBase.GetDatabaseValue(@backBalanceType)));
			parameters.Add(new SqlParameter("@RuleType", EntityBase.GetDatabaseValue(@ruleType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_BalanceRule from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_BalanceRule(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_BalanceRule(@iD, helper);
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
		/// Deletes a Mall_BalanceRule from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_BalanceRule(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_BalanceRule]
WHERE 
	[Mall_BalanceRule].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_BalanceRule object.
		/// </summary>
		/// <returns>The newly created Mall_BalanceRule object.</returns>
		public static Mall_BalanceRule CreateMall_BalanceRule()
		{
			return InitializeNew<Mall_BalanceRule>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_BalanceRule by a Mall_BalanceRule's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_BalanceRule</returns>
		public static Mall_BalanceRule GetMall_BalanceRule(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_BalanceRule.SelectFieldList + @"
FROM [dbo].[Mall_BalanceRule] 
WHERE 
	[Mall_BalanceRule].[ID] = @ID " + Mall_BalanceRule.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_BalanceRule>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_BalanceRule by a Mall_BalanceRule's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_BalanceRule</returns>
		public static Mall_BalanceRule GetMall_BalanceRule(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_BalanceRule.SelectFieldList + @"
FROM [dbo].[Mall_BalanceRule] 
WHERE 
	[Mall_BalanceRule].[ID] = @ID " + Mall_BalanceRule.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_BalanceRule>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_BalanceRule objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_BalanceRule objects.</returns>
		public static EntityList<Mall_BalanceRule> GetMall_BalanceRules()
		{
			string commandText = @"
SELECT " + Mall_BalanceRule.SelectFieldList + "FROM [dbo].[Mall_BalanceRule] " + Mall_BalanceRule.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_BalanceRule>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_BalanceRule objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_BalanceRule objects.</returns>
        public static EntityList<Mall_BalanceRule> GetMall_BalanceRules(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_BalanceRule>(SelectFieldList, "FROM [dbo].[Mall_BalanceRule]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_BalanceRule objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_BalanceRule objects.</returns>
        public static EntityList<Mall_BalanceRule> GetMall_BalanceRules(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_BalanceRule>(SelectFieldList, "FROM [dbo].[Mall_BalanceRule]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_BalanceRule objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_BalanceRule objects.</returns>
		protected static EntityList<Mall_BalanceRule> GetMall_BalanceRules(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_BalanceRules(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_BalanceRule objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_BalanceRule objects.</returns>
		protected static EntityList<Mall_BalanceRule> GetMall_BalanceRules(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_BalanceRules(string.Empty, where, parameters, Mall_BalanceRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BalanceRule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_BalanceRule objects.</returns>
		protected static EntityList<Mall_BalanceRule> GetMall_BalanceRules(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_BalanceRules(prefix, where, parameters, Mall_BalanceRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BalanceRule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_BalanceRule objects.</returns>
		protected static EntityList<Mall_BalanceRule> GetMall_BalanceRules(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_BalanceRules(string.Empty, where, parameters, Mall_BalanceRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BalanceRule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_BalanceRule objects.</returns>
		protected static EntityList<Mall_BalanceRule> GetMall_BalanceRules(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_BalanceRules(prefix, where, parameters, Mall_BalanceRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_BalanceRule objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_BalanceRule objects.</returns>
		protected static EntityList<Mall_BalanceRule> GetMall_BalanceRules(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_BalanceRule.SelectFieldList + "FROM [dbo].[Mall_BalanceRule] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_BalanceRule>(reader);
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
        protected static EntityList<Mall_BalanceRule> GetMall_BalanceRules(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_BalanceRule>(SelectFieldList, "FROM [dbo].[Mall_BalanceRule] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_BalanceRule objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_BalanceRuleCount()
        {
            return GetMall_BalanceRuleCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_BalanceRule objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_BalanceRuleCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_BalanceRule] " + where;

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
		public static partial class Mall_BalanceRule_Properties
		{
			public const string ID = "ID";
			public const string Title = "Title";
			public const string BackPercent = "BackPercent";
			public const string BackAmount = "BackAmount";
			public const string Remark = "Remark";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string IsActive = "IsActive";
			public const string BackBalanceType = "BackBalanceType";
			public const string RuleType = "RuleType";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Title" , "string:"},
    			 {"BackPercent" , "decimal:"},
    			 {"BackAmount" , "decimal:"},
    			 {"Remark" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"IsActive" , "bool:"},
    			 {"BackBalanceType" , "int:1-按比例 2-固定金额"},
    			 {"RuleType" , "int:1-商家结算 2-业主结算"},
            };
		}
		#endregion
	}
}
