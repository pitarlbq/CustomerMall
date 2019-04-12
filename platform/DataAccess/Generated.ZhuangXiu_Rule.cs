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
	/// This object represents the properties and methods of a ZhuangXiu_Rule.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ZhuangXiu_Rule 
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
		private string _ruleRequire = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RuleRequire
		{
			[DebuggerStepThrough()]
			get { return this._ruleRequire; }
			set 
			{
				if (this._ruleRequire != value) 
				{
					this._ruleRequire = value;
					this.IsDirty = true;	
					OnPropertyChanged("RuleRequire");
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
		private int _ruleCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RuleCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._ruleCategoryID; }
			set 
			{
				if (this._ruleCategoryID != value) 
				{
					this._ruleCategoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RuleCategoryID");
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
	[RuleName] nvarchar(200),
	[RuleRequire] ntext,
	[AddTime] datetime,
	[RuleCategoryID] int
);

INSERT INTO [dbo].[ZhuangXiu_Rule] (
	[ZhuangXiu_Rule].[RuleName],
	[ZhuangXiu_Rule].[RuleRequire],
	[ZhuangXiu_Rule].[AddTime],
	[ZhuangXiu_Rule].[RuleCategoryID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RuleName],
	INSERTED.[RuleRequire],
	INSERTED.[AddTime],
	INSERTED.[RuleCategoryID]
into @table
VALUES ( 
	@RuleName,
	@RuleRequire,
	@AddTime,
	@RuleCategoryID 
); 

SELECT 
	[ID],
	[RuleName],
	[RuleRequire],
	[AddTime],
	[RuleCategoryID] 
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
	[RuleName] nvarchar(200),
	[RuleRequire] ntext,
	[AddTime] datetime,
	[RuleCategoryID] int
);

UPDATE [dbo].[ZhuangXiu_Rule] SET 
	[ZhuangXiu_Rule].[RuleName] = @RuleName,
	[ZhuangXiu_Rule].[RuleRequire] = @RuleRequire,
	[ZhuangXiu_Rule].[AddTime] = @AddTime,
	[ZhuangXiu_Rule].[RuleCategoryID] = @RuleCategoryID 
output 
	INSERTED.[ID],
	INSERTED.[RuleName],
	INSERTED.[RuleRequire],
	INSERTED.[AddTime],
	INSERTED.[RuleCategoryID]
into @table
WHERE 
	[ZhuangXiu_Rule].[ID] = @ID

SELECT 
	[ID],
	[RuleName],
	[RuleRequire],
	[AddTime],
	[RuleCategoryID] 
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
DELETE FROM [dbo].[ZhuangXiu_Rule]
WHERE 
	[ZhuangXiu_Rule].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ZhuangXiu_Rule() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetZhuangXiu_Rule(this.ID));
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
	[ZhuangXiu_Rule].[ID],
	[ZhuangXiu_Rule].[RuleName],
	[ZhuangXiu_Rule].[RuleRequire],
	[ZhuangXiu_Rule].[AddTime],
	[ZhuangXiu_Rule].[RuleCategoryID]
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
                return "ZhuangXiu_Rule";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ZhuangXiu_Rule into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="ruleName">ruleName</param>
		/// <param name="ruleRequire">ruleRequire</param>
		/// <param name="addTime">addTime</param>
		/// <param name="ruleCategoryID">ruleCategoryID</param>
		public static void InsertZhuangXiu_Rule(string @ruleName, string @ruleRequire, DateTime @addTime, int @ruleCategoryID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertZhuangXiu_Rule(@ruleName, @ruleRequire, @addTime, @ruleCategoryID, helper);
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
		/// Insert a ZhuangXiu_Rule into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="ruleName">ruleName</param>
		/// <param name="ruleRequire">ruleRequire</param>
		/// <param name="addTime">addTime</param>
		/// <param name="ruleCategoryID">ruleCategoryID</param>
		/// <param name="helper">helper</param>
		internal static void InsertZhuangXiu_Rule(string @ruleName, string @ruleRequire, DateTime @addTime, int @ruleCategoryID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RuleName] nvarchar(200),
	[RuleRequire] ntext,
	[AddTime] datetime,
	[RuleCategoryID] int
);

INSERT INTO [dbo].[ZhuangXiu_Rule] (
	[ZhuangXiu_Rule].[RuleName],
	[ZhuangXiu_Rule].[RuleRequire],
	[ZhuangXiu_Rule].[AddTime],
	[ZhuangXiu_Rule].[RuleCategoryID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RuleName],
	INSERTED.[RuleRequire],
	INSERTED.[AddTime],
	INSERTED.[RuleCategoryID]
into @table
VALUES ( 
	@RuleName,
	@RuleRequire,
	@AddTime,
	@RuleCategoryID 
); 

SELECT 
	[ID],
	[RuleName],
	[RuleRequire],
	[AddTime],
	[RuleCategoryID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RuleName", EntityBase.GetDatabaseValue(@ruleName)));
			parameters.Add(new SqlParameter("@RuleRequire", EntityBase.GetDatabaseValue(@ruleRequire)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@RuleCategoryID", EntityBase.GetDatabaseValue(@ruleCategoryID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ZhuangXiu_Rule into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="ruleName">ruleName</param>
		/// <param name="ruleRequire">ruleRequire</param>
		/// <param name="addTime">addTime</param>
		/// <param name="ruleCategoryID">ruleCategoryID</param>
		public static void UpdateZhuangXiu_Rule(int @iD, string @ruleName, string @ruleRequire, DateTime @addTime, int @ruleCategoryID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateZhuangXiu_Rule(@iD, @ruleName, @ruleRequire, @addTime, @ruleCategoryID, helper);
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
		/// Updates a ZhuangXiu_Rule into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="ruleName">ruleName</param>
		/// <param name="ruleRequire">ruleRequire</param>
		/// <param name="addTime">addTime</param>
		/// <param name="ruleCategoryID">ruleCategoryID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateZhuangXiu_Rule(int @iD, string @ruleName, string @ruleRequire, DateTime @addTime, int @ruleCategoryID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RuleName] nvarchar(200),
	[RuleRequire] ntext,
	[AddTime] datetime,
	[RuleCategoryID] int
);

UPDATE [dbo].[ZhuangXiu_Rule] SET 
	[ZhuangXiu_Rule].[RuleName] = @RuleName,
	[ZhuangXiu_Rule].[RuleRequire] = @RuleRequire,
	[ZhuangXiu_Rule].[AddTime] = @AddTime,
	[ZhuangXiu_Rule].[RuleCategoryID] = @RuleCategoryID 
output 
	INSERTED.[ID],
	INSERTED.[RuleName],
	INSERTED.[RuleRequire],
	INSERTED.[AddTime],
	INSERTED.[RuleCategoryID]
into @table
WHERE 
	[ZhuangXiu_Rule].[ID] = @ID

SELECT 
	[ID],
	[RuleName],
	[RuleRequire],
	[AddTime],
	[RuleCategoryID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RuleName", EntityBase.GetDatabaseValue(@ruleName)));
			parameters.Add(new SqlParameter("@RuleRequire", EntityBase.GetDatabaseValue(@ruleRequire)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@RuleCategoryID", EntityBase.GetDatabaseValue(@ruleCategoryID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ZhuangXiu_Rule from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteZhuangXiu_Rule(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteZhuangXiu_Rule(@iD, helper);
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
		/// Deletes a ZhuangXiu_Rule from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteZhuangXiu_Rule(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ZhuangXiu_Rule]
WHERE 
	[ZhuangXiu_Rule].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ZhuangXiu_Rule object.
		/// </summary>
		/// <returns>The newly created ZhuangXiu_Rule object.</returns>
		public static ZhuangXiu_Rule CreateZhuangXiu_Rule()
		{
			return InitializeNew<ZhuangXiu_Rule>();
		}
		
		/// <summary>
		/// Retrieve information for a ZhuangXiu_Rule by a ZhuangXiu_Rule's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ZhuangXiu_Rule</returns>
		public static ZhuangXiu_Rule GetZhuangXiu_Rule(int @iD)
		{
			string commandText = @"
SELECT 
" + ZhuangXiu_Rule.SelectFieldList + @"
FROM [dbo].[ZhuangXiu_Rule] 
WHERE 
	[ZhuangXiu_Rule].[ID] = @ID " + ZhuangXiu_Rule.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ZhuangXiu_Rule>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ZhuangXiu_Rule by a ZhuangXiu_Rule's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ZhuangXiu_Rule</returns>
		public static ZhuangXiu_Rule GetZhuangXiu_Rule(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ZhuangXiu_Rule.SelectFieldList + @"
FROM [dbo].[ZhuangXiu_Rule] 
WHERE 
	[ZhuangXiu_Rule].[ID] = @ID " + ZhuangXiu_Rule.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ZhuangXiu_Rule>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Rule objects.
		/// </summary>
		/// <returns>The retrieved collection of ZhuangXiu_Rule objects.</returns>
		public static EntityList<ZhuangXiu_Rule> GetZhuangXiu_Rules()
		{
			string commandText = @"
SELECT " + ZhuangXiu_Rule.SelectFieldList + "FROM [dbo].[ZhuangXiu_Rule] " + ZhuangXiu_Rule.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ZhuangXiu_Rule>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ZhuangXiu_Rule objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ZhuangXiu_Rule objects.</returns>
        public static EntityList<ZhuangXiu_Rule> GetZhuangXiu_Rules(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ZhuangXiu_Rule>(SelectFieldList, "FROM [dbo].[ZhuangXiu_Rule]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ZhuangXiu_Rule objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ZhuangXiu_Rule objects.</returns>
        public static EntityList<ZhuangXiu_Rule> GetZhuangXiu_Rules(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ZhuangXiu_Rule>(SelectFieldList, "FROM [dbo].[ZhuangXiu_Rule]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Rule objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ZhuangXiu_Rule objects.</returns>
		protected static EntityList<ZhuangXiu_Rule> GetZhuangXiu_Rules(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetZhuangXiu_Rules(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Rule objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu_Rule objects.</returns>
		protected static EntityList<ZhuangXiu_Rule> GetZhuangXiu_Rules(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetZhuangXiu_Rules(string.Empty, where, parameters, ZhuangXiu_Rule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Rule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu_Rule objects.</returns>
		protected static EntityList<ZhuangXiu_Rule> GetZhuangXiu_Rules(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetZhuangXiu_Rules(prefix, where, parameters, ZhuangXiu_Rule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Rule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu_Rule objects.</returns>
		protected static EntityList<ZhuangXiu_Rule> GetZhuangXiu_Rules(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetZhuangXiu_Rules(string.Empty, where, parameters, ZhuangXiu_Rule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Rule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ZhuangXiu_Rule objects.</returns>
		protected static EntityList<ZhuangXiu_Rule> GetZhuangXiu_Rules(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetZhuangXiu_Rules(prefix, where, parameters, ZhuangXiu_Rule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ZhuangXiu_Rule objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ZhuangXiu_Rule objects.</returns>
		protected static EntityList<ZhuangXiu_Rule> GetZhuangXiu_Rules(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ZhuangXiu_Rule.SelectFieldList + "FROM [dbo].[ZhuangXiu_Rule] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ZhuangXiu_Rule>(reader);
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
        protected static EntityList<ZhuangXiu_Rule> GetZhuangXiu_Rules(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ZhuangXiu_Rule>(SelectFieldList, "FROM [dbo].[ZhuangXiu_Rule] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ZhuangXiu_Rule objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetZhuangXiu_RuleCount()
        {
            return GetZhuangXiu_RuleCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ZhuangXiu_Rule objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetZhuangXiu_RuleCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ZhuangXiu_Rule] " + where;

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
		public static partial class ZhuangXiu_Rule_Properties
		{
			public const string ID = "ID";
			public const string RuleName = "RuleName";
			public const string RuleRequire = "RuleRequire";
			public const string AddTime = "AddTime";
			public const string RuleCategoryID = "RuleCategoryID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RuleName" , "string:"},
    			 {"RuleRequire" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"RuleCategoryID" , "int:"},
            };
		}
		#endregion
	}
}
