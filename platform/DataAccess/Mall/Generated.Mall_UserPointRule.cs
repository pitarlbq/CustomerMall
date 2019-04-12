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
	/// This object represents the properties and methods of a Mall_UserPointRule.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_UserPointRule 
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
		private int _startPoint = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int StartPoint
		{
			[DebuggerStepThrough()]
			get { return this._startPoint; }
			set 
			{
				if (this._startPoint != value) 
				{
					this._startPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("StartPoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _endPoint = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int EndPoint
		{
			[DebuggerStepThrough()]
			get { return this._endPoint; }
			set 
			{
				if (this._endPoint != value) 
				{
					this._endPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndPoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _pointType = int.MinValue;
		/// <summary>
		/// 1-固定积分 2-按比例
		/// </summary>
        [Description("1-固定积分 2-按比例")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int PointType
		{
			[DebuggerStepThrough()]
			get { return this._pointType; }
			set 
			{
				if (this._pointType != value) 
				{
					this._pointType = value;
					this.IsDirty = true;	
					OnPropertyChanged("PointType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _pointValue = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal PointValue
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
		[DataObjectField(false, false, false)]
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
		private bool _isUseForALLProduct = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsUseForALLProduct
		{
			[DebuggerStepThrough()]
			get { return this._isUseForALLProduct; }
			set 
			{
				if (this._isUseForALLProduct != value) 
				{
					this._isUseForALLProduct = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsUseForALLProduct");
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
	[StartPoint] int,
	[EndPoint] int,
	[PointType] int,
	[PointValue] decimal(18, 2),
	[Remark] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[IsActive] bit,
	[IsUseForALLProduct] bit
);

INSERT INTO [dbo].[Mall_UserPointRule] (
	[Mall_UserPointRule].[StartPoint],
	[Mall_UserPointRule].[EndPoint],
	[Mall_UserPointRule].[PointType],
	[Mall_UserPointRule].[PointValue],
	[Mall_UserPointRule].[Remark],
	[Mall_UserPointRule].[AddTime],
	[Mall_UserPointRule].[AddUserName],
	[Mall_UserPointRule].[IsActive],
	[Mall_UserPointRule].[IsUseForALLProduct]
) 
output 
	INSERTED.[ID],
	INSERTED.[StartPoint],
	INSERTED.[EndPoint],
	INSERTED.[PointType],
	INSERTED.[PointValue],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[IsActive],
	INSERTED.[IsUseForALLProduct]
into @table
VALUES ( 
	@StartPoint,
	@EndPoint,
	@PointType,
	@PointValue,
	@Remark,
	@AddTime,
	@AddUserName,
	@IsActive,
	@IsUseForALLProduct 
); 

SELECT 
	[ID],
	[StartPoint],
	[EndPoint],
	[PointType],
	[PointValue],
	[Remark],
	[AddTime],
	[AddUserName],
	[IsActive],
	[IsUseForALLProduct] 
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
	[StartPoint] int,
	[EndPoint] int,
	[PointType] int,
	[PointValue] decimal(18, 2),
	[Remark] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[IsActive] bit,
	[IsUseForALLProduct] bit
);

UPDATE [dbo].[Mall_UserPointRule] SET 
	[Mall_UserPointRule].[StartPoint] = @StartPoint,
	[Mall_UserPointRule].[EndPoint] = @EndPoint,
	[Mall_UserPointRule].[PointType] = @PointType,
	[Mall_UserPointRule].[PointValue] = @PointValue,
	[Mall_UserPointRule].[Remark] = @Remark,
	[Mall_UserPointRule].[AddTime] = @AddTime,
	[Mall_UserPointRule].[AddUserName] = @AddUserName,
	[Mall_UserPointRule].[IsActive] = @IsActive,
	[Mall_UserPointRule].[IsUseForALLProduct] = @IsUseForALLProduct 
output 
	INSERTED.[ID],
	INSERTED.[StartPoint],
	INSERTED.[EndPoint],
	INSERTED.[PointType],
	INSERTED.[PointValue],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[IsActive],
	INSERTED.[IsUseForALLProduct]
into @table
WHERE 
	[Mall_UserPointRule].[ID] = @ID

SELECT 
	[ID],
	[StartPoint],
	[EndPoint],
	[PointType],
	[PointValue],
	[Remark],
	[AddTime],
	[AddUserName],
	[IsActive],
	[IsUseForALLProduct] 
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
DELETE FROM [dbo].[Mall_UserPointRule]
WHERE 
	[Mall_UserPointRule].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_UserPointRule() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_UserPointRule(this.ID));
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
	[Mall_UserPointRule].[ID],
	[Mall_UserPointRule].[StartPoint],
	[Mall_UserPointRule].[EndPoint],
	[Mall_UserPointRule].[PointType],
	[Mall_UserPointRule].[PointValue],
	[Mall_UserPointRule].[Remark],
	[Mall_UserPointRule].[AddTime],
	[Mall_UserPointRule].[AddUserName],
	[Mall_UserPointRule].[IsActive],
	[Mall_UserPointRule].[IsUseForALLProduct]
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
                return "Mall_UserPointRule";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_UserPointRule into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="startPoint">startPoint</param>
		/// <param name="endPoint">endPoint</param>
		/// <param name="pointType">pointType</param>
		/// <param name="pointValue">pointValue</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="isActive">isActive</param>
		/// <param name="isUseForALLProduct">isUseForALLProduct</param>
		public static void InsertMall_UserPointRule(int @startPoint, int @endPoint, int @pointType, decimal @pointValue, string @remark, DateTime @addTime, string @addUserName, bool @isActive, bool @isUseForALLProduct)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_UserPointRule(@startPoint, @endPoint, @pointType, @pointValue, @remark, @addTime, @addUserName, @isActive, @isUseForALLProduct, helper);
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
		/// Insert a Mall_UserPointRule into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="startPoint">startPoint</param>
		/// <param name="endPoint">endPoint</param>
		/// <param name="pointType">pointType</param>
		/// <param name="pointValue">pointValue</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="isActive">isActive</param>
		/// <param name="isUseForALLProduct">isUseForALLProduct</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_UserPointRule(int @startPoint, int @endPoint, int @pointType, decimal @pointValue, string @remark, DateTime @addTime, string @addUserName, bool @isActive, bool @isUseForALLProduct, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[StartPoint] int,
	[EndPoint] int,
	[PointType] int,
	[PointValue] decimal(18, 2),
	[Remark] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[IsActive] bit,
	[IsUseForALLProduct] bit
);

INSERT INTO [dbo].[Mall_UserPointRule] (
	[Mall_UserPointRule].[StartPoint],
	[Mall_UserPointRule].[EndPoint],
	[Mall_UserPointRule].[PointType],
	[Mall_UserPointRule].[PointValue],
	[Mall_UserPointRule].[Remark],
	[Mall_UserPointRule].[AddTime],
	[Mall_UserPointRule].[AddUserName],
	[Mall_UserPointRule].[IsActive],
	[Mall_UserPointRule].[IsUseForALLProduct]
) 
output 
	INSERTED.[ID],
	INSERTED.[StartPoint],
	INSERTED.[EndPoint],
	INSERTED.[PointType],
	INSERTED.[PointValue],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[IsActive],
	INSERTED.[IsUseForALLProduct]
into @table
VALUES ( 
	@StartPoint,
	@EndPoint,
	@PointType,
	@PointValue,
	@Remark,
	@AddTime,
	@AddUserName,
	@IsActive,
	@IsUseForALLProduct 
); 

SELECT 
	[ID],
	[StartPoint],
	[EndPoint],
	[PointType],
	[PointValue],
	[Remark],
	[AddTime],
	[AddUserName],
	[IsActive],
	[IsUseForALLProduct] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@StartPoint", EntityBase.GetDatabaseValue(@startPoint)));
			parameters.Add(new SqlParameter("@EndPoint", EntityBase.GetDatabaseValue(@endPoint)));
			parameters.Add(new SqlParameter("@PointType", EntityBase.GetDatabaseValue(@pointType)));
			parameters.Add(new SqlParameter("@PointValue", EntityBase.GetDatabaseValue(@pointValue)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@IsUseForALLProduct", @isUseForALLProduct));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_UserPointRule into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="startPoint">startPoint</param>
		/// <param name="endPoint">endPoint</param>
		/// <param name="pointType">pointType</param>
		/// <param name="pointValue">pointValue</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="isActive">isActive</param>
		/// <param name="isUseForALLProduct">isUseForALLProduct</param>
		public static void UpdateMall_UserPointRule(int @iD, int @startPoint, int @endPoint, int @pointType, decimal @pointValue, string @remark, DateTime @addTime, string @addUserName, bool @isActive, bool @isUseForALLProduct)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_UserPointRule(@iD, @startPoint, @endPoint, @pointType, @pointValue, @remark, @addTime, @addUserName, @isActive, @isUseForALLProduct, helper);
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
		/// Updates a Mall_UserPointRule into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="startPoint">startPoint</param>
		/// <param name="endPoint">endPoint</param>
		/// <param name="pointType">pointType</param>
		/// <param name="pointValue">pointValue</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="isActive">isActive</param>
		/// <param name="isUseForALLProduct">isUseForALLProduct</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_UserPointRule(int @iD, int @startPoint, int @endPoint, int @pointType, decimal @pointValue, string @remark, DateTime @addTime, string @addUserName, bool @isActive, bool @isUseForALLProduct, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[StartPoint] int,
	[EndPoint] int,
	[PointType] int,
	[PointValue] decimal(18, 2),
	[Remark] ntext,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[IsActive] bit,
	[IsUseForALLProduct] bit
);

UPDATE [dbo].[Mall_UserPointRule] SET 
	[Mall_UserPointRule].[StartPoint] = @StartPoint,
	[Mall_UserPointRule].[EndPoint] = @EndPoint,
	[Mall_UserPointRule].[PointType] = @PointType,
	[Mall_UserPointRule].[PointValue] = @PointValue,
	[Mall_UserPointRule].[Remark] = @Remark,
	[Mall_UserPointRule].[AddTime] = @AddTime,
	[Mall_UserPointRule].[AddUserName] = @AddUserName,
	[Mall_UserPointRule].[IsActive] = @IsActive,
	[Mall_UserPointRule].[IsUseForALLProduct] = @IsUseForALLProduct 
output 
	INSERTED.[ID],
	INSERTED.[StartPoint],
	INSERTED.[EndPoint],
	INSERTED.[PointType],
	INSERTED.[PointValue],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[IsActive],
	INSERTED.[IsUseForALLProduct]
into @table
WHERE 
	[Mall_UserPointRule].[ID] = @ID

SELECT 
	[ID],
	[StartPoint],
	[EndPoint],
	[PointType],
	[PointValue],
	[Remark],
	[AddTime],
	[AddUserName],
	[IsActive],
	[IsUseForALLProduct] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@StartPoint", EntityBase.GetDatabaseValue(@startPoint)));
			parameters.Add(new SqlParameter("@EndPoint", EntityBase.GetDatabaseValue(@endPoint)));
			parameters.Add(new SqlParameter("@PointType", EntityBase.GetDatabaseValue(@pointType)));
			parameters.Add(new SqlParameter("@PointValue", EntityBase.GetDatabaseValue(@pointValue)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@IsUseForALLProduct", @isUseForALLProduct));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_UserPointRule from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_UserPointRule(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_UserPointRule(@iD, helper);
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
		/// Deletes a Mall_UserPointRule from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_UserPointRule(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_UserPointRule]
WHERE 
	[Mall_UserPointRule].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_UserPointRule object.
		/// </summary>
		/// <returns>The newly created Mall_UserPointRule object.</returns>
		public static Mall_UserPointRule CreateMall_UserPointRule()
		{
			return InitializeNew<Mall_UserPointRule>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_UserPointRule by a Mall_UserPointRule's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_UserPointRule</returns>
		public static Mall_UserPointRule GetMall_UserPointRule(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_UserPointRule.SelectFieldList + @"
FROM [dbo].[Mall_UserPointRule] 
WHERE 
	[Mall_UserPointRule].[ID] = @ID " + Mall_UserPointRule.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_UserPointRule>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_UserPointRule by a Mall_UserPointRule's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_UserPointRule</returns>
		public static Mall_UserPointRule GetMall_UserPointRule(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_UserPointRule.SelectFieldList + @"
FROM [dbo].[Mall_UserPointRule] 
WHERE 
	[Mall_UserPointRule].[ID] = @ID " + Mall_UserPointRule.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_UserPointRule>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserPointRule objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_UserPointRule objects.</returns>
		public static EntityList<Mall_UserPointRule> GetMall_UserPointRules()
		{
			string commandText = @"
SELECT " + Mall_UserPointRule.SelectFieldList + "FROM [dbo].[Mall_UserPointRule] " + Mall_UserPointRule.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_UserPointRule>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_UserPointRule objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_UserPointRule objects.</returns>
        public static EntityList<Mall_UserPointRule> GetMall_UserPointRules(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserPointRule>(SelectFieldList, "FROM [dbo].[Mall_UserPointRule]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_UserPointRule objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_UserPointRule objects.</returns>
        public static EntityList<Mall_UserPointRule> GetMall_UserPointRules(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserPointRule>(SelectFieldList, "FROM [dbo].[Mall_UserPointRule]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_UserPointRule objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_UserPointRule objects.</returns>
		protected static EntityList<Mall_UserPointRule> GetMall_UserPointRules(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserPointRules(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserPointRule objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserPointRule objects.</returns>
		protected static EntityList<Mall_UserPointRule> GetMall_UserPointRules(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserPointRules(string.Empty, where, parameters, Mall_UserPointRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserPointRule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserPointRule objects.</returns>
		protected static EntityList<Mall_UserPointRule> GetMall_UserPointRules(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserPointRules(prefix, where, parameters, Mall_UserPointRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserPointRule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserPointRule objects.</returns>
		protected static EntityList<Mall_UserPointRule> GetMall_UserPointRules(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_UserPointRules(string.Empty, where, parameters, Mall_UserPointRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserPointRule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserPointRule objects.</returns>
		protected static EntityList<Mall_UserPointRule> GetMall_UserPointRules(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_UserPointRules(prefix, where, parameters, Mall_UserPointRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserPointRule objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_UserPointRule objects.</returns>
		protected static EntityList<Mall_UserPointRule> GetMall_UserPointRules(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_UserPointRule.SelectFieldList + "FROM [dbo].[Mall_UserPointRule] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_UserPointRule>(reader);
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
        protected static EntityList<Mall_UserPointRule> GetMall_UserPointRules(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserPointRule>(SelectFieldList, "FROM [dbo].[Mall_UserPointRule] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_UserPointRule objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_UserPointRuleCount()
        {
            return GetMall_UserPointRuleCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_UserPointRule objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_UserPointRuleCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_UserPointRule] " + where;

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
		public static partial class Mall_UserPointRule_Properties
		{
			public const string ID = "ID";
			public const string StartPoint = "StartPoint";
			public const string EndPoint = "EndPoint";
			public const string PointType = "PointType";
			public const string PointValue = "PointValue";
			public const string Remark = "Remark";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string IsActive = "IsActive";
			public const string IsUseForALLProduct = "IsUseForALLProduct";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"StartPoint" , "int:"},
    			 {"EndPoint" , "int:"},
    			 {"PointType" , "int:1-固定积分 2-按比例"},
    			 {"PointValue" , "decimal:"},
    			 {"Remark" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"IsActive" , "bool:"},
    			 {"IsUseForALLProduct" , "bool:"},
            };
		}
		#endregion
	}
}
