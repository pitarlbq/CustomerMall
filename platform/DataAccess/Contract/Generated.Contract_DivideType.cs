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
	/// This object represents the properties and methods of a Contract_DivideType.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Contract_DivideType 
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
		private int _contract_DivideID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int Contract_DivideID
		{
			[DebuggerStepThrough()]
			get { return this._contract_DivideID; }
			set 
			{
				if (this._contract_DivideID != value) 
				{
					this._contract_DivideID = value;
					this.IsDirty = true;	
					OnPropertyChanged("Contract_DivideID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _divideType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DivideType
		{
			[DebuggerStepThrough()]
			get { return this._divideType; }
			set 
			{
				if (this._divideType != value) 
				{
					this._divideType = value;
					this.IsDirty = true;	
					OnPropertyChanged("DivideType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _divide_Percent = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal Divide_Percent
		{
			[DebuggerStepThrough()]
			get { return this._divide_Percent; }
			set 
			{
				if (this._divide_Percent != value) 
				{
					this._divide_Percent = value;
					this.IsDirty = true;	
					OnPropertyChanged("Divide_Percent");
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
		private decimal _divideStartCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal DivideStartCost
		{
			[DebuggerStepThrough()]
			get { return this._divideStartCost; }
			set 
			{
				if (this._divideStartCost != value) 
				{
					this._divideStartCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("DivideStartCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _divideEndCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal DivideEndCost
		{
			[DebuggerStepThrough()]
			get { return this._divideEndCost; }
			set 
			{
				if (this._divideEndCost != value) 
				{
					this._divideEndCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("DivideEndCost");
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
	[Contract_DivideID] int,
	[DivideType] nvarchar(50),
	[Divide_Percent] decimal(18, 2),
	[AddTime] datetime,
	[DivideStartCost] decimal(18, 2),
	[DivideEndCost] decimal(18, 2)
);

INSERT INTO [dbo].[Contract_DivideType] (
	[Contract_DivideType].[Contract_DivideID],
	[Contract_DivideType].[DivideType],
	[Contract_DivideType].[Divide_Percent],
	[Contract_DivideType].[AddTime],
	[Contract_DivideType].[DivideStartCost],
	[Contract_DivideType].[DivideEndCost]
) 
output 
	INSERTED.[ID],
	INSERTED.[Contract_DivideID],
	INSERTED.[DivideType],
	INSERTED.[Divide_Percent],
	INSERTED.[AddTime],
	INSERTED.[DivideStartCost],
	INSERTED.[DivideEndCost]
into @table
VALUES ( 
	@Contract_DivideID,
	@DivideType,
	@Divide_Percent,
	@AddTime,
	@DivideStartCost,
	@DivideEndCost 
); 

SELECT 
	[ID],
	[Contract_DivideID],
	[DivideType],
	[Divide_Percent],
	[AddTime],
	[DivideStartCost],
	[DivideEndCost] 
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
	[Contract_DivideID] int,
	[DivideType] nvarchar(50),
	[Divide_Percent] decimal(18, 2),
	[AddTime] datetime,
	[DivideStartCost] decimal(18, 2),
	[DivideEndCost] decimal(18, 2)
);

UPDATE [dbo].[Contract_DivideType] SET 
	[Contract_DivideType].[Contract_DivideID] = @Contract_DivideID,
	[Contract_DivideType].[DivideType] = @DivideType,
	[Contract_DivideType].[Divide_Percent] = @Divide_Percent,
	[Contract_DivideType].[AddTime] = @AddTime,
	[Contract_DivideType].[DivideStartCost] = @DivideStartCost,
	[Contract_DivideType].[DivideEndCost] = @DivideEndCost 
output 
	INSERTED.[ID],
	INSERTED.[Contract_DivideID],
	INSERTED.[DivideType],
	INSERTED.[Divide_Percent],
	INSERTED.[AddTime],
	INSERTED.[DivideStartCost],
	INSERTED.[DivideEndCost]
into @table
WHERE 
	[Contract_DivideType].[ID] = @ID

SELECT 
	[ID],
	[Contract_DivideID],
	[DivideType],
	[Divide_Percent],
	[AddTime],
	[DivideStartCost],
	[DivideEndCost] 
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
DELETE FROM [dbo].[Contract_DivideType]
WHERE 
	[Contract_DivideType].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Contract_DivideType() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetContract_DivideType(this.ID));
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
	[Contract_DivideType].[ID],
	[Contract_DivideType].[Contract_DivideID],
	[Contract_DivideType].[DivideType],
	[Contract_DivideType].[Divide_Percent],
	[Contract_DivideType].[AddTime],
	[Contract_DivideType].[DivideStartCost],
	[Contract_DivideType].[DivideEndCost]
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
                return "Contract_DivideType";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Contract_DivideType into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contract_DivideID">contract_DivideID</param>
		/// <param name="divideType">divideType</param>
		/// <param name="divide_Percent">divide_Percent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="divideStartCost">divideStartCost</param>
		/// <param name="divideEndCost">divideEndCost</param>
		public static void InsertContract_DivideType(int @contract_DivideID, string @divideType, decimal @divide_Percent, DateTime @addTime, decimal @divideStartCost, decimal @divideEndCost)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertContract_DivideType(@contract_DivideID, @divideType, @divide_Percent, @addTime, @divideStartCost, @divideEndCost, helper);
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
		/// Insert a Contract_DivideType into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contract_DivideID">contract_DivideID</param>
		/// <param name="divideType">divideType</param>
		/// <param name="divide_Percent">divide_Percent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="divideStartCost">divideStartCost</param>
		/// <param name="divideEndCost">divideEndCost</param>
		/// <param name="helper">helper</param>
		internal static void InsertContract_DivideType(int @contract_DivideID, string @divideType, decimal @divide_Percent, DateTime @addTime, decimal @divideStartCost, decimal @divideEndCost, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Contract_DivideID] int,
	[DivideType] nvarchar(50),
	[Divide_Percent] decimal(18, 2),
	[AddTime] datetime,
	[DivideStartCost] decimal(18, 2),
	[DivideEndCost] decimal(18, 2)
);

INSERT INTO [dbo].[Contract_DivideType] (
	[Contract_DivideType].[Contract_DivideID],
	[Contract_DivideType].[DivideType],
	[Contract_DivideType].[Divide_Percent],
	[Contract_DivideType].[AddTime],
	[Contract_DivideType].[DivideStartCost],
	[Contract_DivideType].[DivideEndCost]
) 
output 
	INSERTED.[ID],
	INSERTED.[Contract_DivideID],
	INSERTED.[DivideType],
	INSERTED.[Divide_Percent],
	INSERTED.[AddTime],
	INSERTED.[DivideStartCost],
	INSERTED.[DivideEndCost]
into @table
VALUES ( 
	@Contract_DivideID,
	@DivideType,
	@Divide_Percent,
	@AddTime,
	@DivideStartCost,
	@DivideEndCost 
); 

SELECT 
	[ID],
	[Contract_DivideID],
	[DivideType],
	[Divide_Percent],
	[AddTime],
	[DivideStartCost],
	[DivideEndCost] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Contract_DivideID", EntityBase.GetDatabaseValue(@contract_DivideID)));
			parameters.Add(new SqlParameter("@DivideType", EntityBase.GetDatabaseValue(@divideType)));
			parameters.Add(new SqlParameter("@Divide_Percent", EntityBase.GetDatabaseValue(@divide_Percent)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@DivideStartCost", EntityBase.GetDatabaseValue(@divideStartCost)));
			parameters.Add(new SqlParameter("@DivideEndCost", EntityBase.GetDatabaseValue(@divideEndCost)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Contract_DivideType into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contract_DivideID">contract_DivideID</param>
		/// <param name="divideType">divideType</param>
		/// <param name="divide_Percent">divide_Percent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="divideStartCost">divideStartCost</param>
		/// <param name="divideEndCost">divideEndCost</param>
		public static void UpdateContract_DivideType(int @iD, int @contract_DivideID, string @divideType, decimal @divide_Percent, DateTime @addTime, decimal @divideStartCost, decimal @divideEndCost)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateContract_DivideType(@iD, @contract_DivideID, @divideType, @divide_Percent, @addTime, @divideStartCost, @divideEndCost, helper);
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
		/// Updates a Contract_DivideType into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contract_DivideID">contract_DivideID</param>
		/// <param name="divideType">divideType</param>
		/// <param name="divide_Percent">divide_Percent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="divideStartCost">divideStartCost</param>
		/// <param name="divideEndCost">divideEndCost</param>
		/// <param name="helper">helper</param>
		internal static void UpdateContract_DivideType(int @iD, int @contract_DivideID, string @divideType, decimal @divide_Percent, DateTime @addTime, decimal @divideStartCost, decimal @divideEndCost, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Contract_DivideID] int,
	[DivideType] nvarchar(50),
	[Divide_Percent] decimal(18, 2),
	[AddTime] datetime,
	[DivideStartCost] decimal(18, 2),
	[DivideEndCost] decimal(18, 2)
);

UPDATE [dbo].[Contract_DivideType] SET 
	[Contract_DivideType].[Contract_DivideID] = @Contract_DivideID,
	[Contract_DivideType].[DivideType] = @DivideType,
	[Contract_DivideType].[Divide_Percent] = @Divide_Percent,
	[Contract_DivideType].[AddTime] = @AddTime,
	[Contract_DivideType].[DivideStartCost] = @DivideStartCost,
	[Contract_DivideType].[DivideEndCost] = @DivideEndCost 
output 
	INSERTED.[ID],
	INSERTED.[Contract_DivideID],
	INSERTED.[DivideType],
	INSERTED.[Divide_Percent],
	INSERTED.[AddTime],
	INSERTED.[DivideStartCost],
	INSERTED.[DivideEndCost]
into @table
WHERE 
	[Contract_DivideType].[ID] = @ID

SELECT 
	[ID],
	[Contract_DivideID],
	[DivideType],
	[Divide_Percent],
	[AddTime],
	[DivideStartCost],
	[DivideEndCost] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Contract_DivideID", EntityBase.GetDatabaseValue(@contract_DivideID)));
			parameters.Add(new SqlParameter("@DivideType", EntityBase.GetDatabaseValue(@divideType)));
			parameters.Add(new SqlParameter("@Divide_Percent", EntityBase.GetDatabaseValue(@divide_Percent)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@DivideStartCost", EntityBase.GetDatabaseValue(@divideStartCost)));
			parameters.Add(new SqlParameter("@DivideEndCost", EntityBase.GetDatabaseValue(@divideEndCost)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Contract_DivideType from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteContract_DivideType(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteContract_DivideType(@iD, helper);
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
		/// Deletes a Contract_DivideType from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteContract_DivideType(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Contract_DivideType]
WHERE 
	[Contract_DivideType].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Contract_DivideType object.
		/// </summary>
		/// <returns>The newly created Contract_DivideType object.</returns>
		public static Contract_DivideType CreateContract_DivideType()
		{
			return InitializeNew<Contract_DivideType>();
		}
		
		/// <summary>
		/// Retrieve information for a Contract_DivideType by a Contract_DivideType's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Contract_DivideType</returns>
		public static Contract_DivideType GetContract_DivideType(int @iD)
		{
			string commandText = @"
SELECT 
" + Contract_DivideType.SelectFieldList + @"
FROM [dbo].[Contract_DivideType] 
WHERE 
	[Contract_DivideType].[ID] = @ID " + Contract_DivideType.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_DivideType>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Contract_DivideType by a Contract_DivideType's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Contract_DivideType</returns>
		public static Contract_DivideType GetContract_DivideType(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Contract_DivideType.SelectFieldList + @"
FROM [dbo].[Contract_DivideType] 
WHERE 
	[Contract_DivideType].[ID] = @ID " + Contract_DivideType.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_DivideType>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Contract_DivideType objects.
		/// </summary>
		/// <returns>The retrieved collection of Contract_DivideType objects.</returns>
		public static EntityList<Contract_DivideType> GetContract_DivideTypes()
		{
			string commandText = @"
SELECT " + Contract_DivideType.SelectFieldList + "FROM [dbo].[Contract_DivideType] " + Contract_DivideType.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Contract_DivideType>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Contract_DivideType objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_DivideType objects.</returns>
        public static EntityList<Contract_DivideType> GetContract_DivideTypes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_DivideType>(SelectFieldList, "FROM [dbo].[Contract_DivideType]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Contract_DivideType objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_DivideType objects.</returns>
        public static EntityList<Contract_DivideType> GetContract_DivideTypes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_DivideType>(SelectFieldList, "FROM [dbo].[Contract_DivideType]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Contract_DivideType objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Contract_DivideType objects.</returns>
		protected static EntityList<Contract_DivideType> GetContract_DivideTypes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_DivideTypes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Contract_DivideType objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_DivideType objects.</returns>
		protected static EntityList<Contract_DivideType> GetContract_DivideTypes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_DivideTypes(string.Empty, where, parameters, Contract_DivideType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_DivideType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_DivideType objects.</returns>
		protected static EntityList<Contract_DivideType> GetContract_DivideTypes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_DivideTypes(prefix, where, parameters, Contract_DivideType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_DivideType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_DivideType objects.</returns>
		protected static EntityList<Contract_DivideType> GetContract_DivideTypes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_DivideTypes(string.Empty, where, parameters, Contract_DivideType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_DivideType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_DivideType objects.</returns>
		protected static EntityList<Contract_DivideType> GetContract_DivideTypes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_DivideTypes(prefix, where, parameters, Contract_DivideType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_DivideType objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Contract_DivideType objects.</returns>
		protected static EntityList<Contract_DivideType> GetContract_DivideTypes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Contract_DivideType.SelectFieldList + "FROM [dbo].[Contract_DivideType] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Contract_DivideType>(reader);
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
        protected static EntityList<Contract_DivideType> GetContract_DivideTypes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_DivideType>(SelectFieldList, "FROM [dbo].[Contract_DivideType] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Contract_DivideType objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_DivideTypeCount()
        {
            return GetContract_DivideTypeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Contract_DivideType objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_DivideTypeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Contract_DivideType] " + where;

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
		public static partial class Contract_DivideType_Properties
		{
			public const string ID = "ID";
			public const string Contract_DivideID = "Contract_DivideID";
			public const string DivideType = "DivideType";
			public const string Divide_Percent = "Divide_Percent";
			public const string AddTime = "AddTime";
			public const string DivideStartCost = "DivideStartCost";
			public const string DivideEndCost = "DivideEndCost";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Contract_DivideID" , "int:"},
    			 {"DivideType" , "string:"},
    			 {"Divide_Percent" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"DivideStartCost" , "decimal:"},
    			 {"DivideEndCost" , "decimal:"},
            };
		}
		#endregion
	}
}
