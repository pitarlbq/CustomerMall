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
	/// This object represents the properties and methods of a ChargeBiao.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ChargeBiao 
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
		private string _biaoName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BiaoName
		{
			[DebuggerStepThrough()]
			get { return this._biaoName; }
			set 
			{
				if (this._biaoName != value) 
				{
					this._biaoName = value;
					this.IsDirty = true;	
					OnPropertyChanged("BiaoName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _biaoCategory = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string BiaoCategory
		{
			[DebuggerStepThrough()]
			get { return this._biaoCategory; }
			set 
			{
				if (this._biaoCategory != value) 
				{
					this._biaoCategory = value;
					this.IsDirty = true;	
					OnPropertyChanged("BiaoCategory");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _biaoGuiGe = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BiaoGuiGe
		{
			[DebuggerStepThrough()]
			get { return this._biaoGuiGe; }
			set 
			{
				if (this._biaoGuiGe != value) 
				{
					this._biaoGuiGe = value;
					this.IsDirty = true;	
					OnPropertyChanged("BiaoGuiGe");
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
	[BiaoName] nvarchar(50),
	[BiaoCategory] nvarchar(50),
	[BiaoGuiGe] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime
);

INSERT INTO [dbo].[ChargeBiao] (
	[ChargeBiao].[BiaoName],
	[ChargeBiao].[BiaoCategory],
	[ChargeBiao].[BiaoGuiGe],
	[ChargeBiao].[Remark],
	[ChargeBiao].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[BiaoName],
	INSERTED.[BiaoCategory],
	INSERTED.[BiaoGuiGe],
	INSERTED.[Remark],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@BiaoName,
	@BiaoCategory,
	@BiaoGuiGe,
	@Remark,
	@AddTime 
); 

SELECT 
	[ID],
	[BiaoName],
	[BiaoCategory],
	[BiaoGuiGe],
	[Remark],
	[AddTime] 
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
	[BiaoName] nvarchar(50),
	[BiaoCategory] nvarchar(50),
	[BiaoGuiGe] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime
);

UPDATE [dbo].[ChargeBiao] SET 
	[ChargeBiao].[BiaoName] = @BiaoName,
	[ChargeBiao].[BiaoCategory] = @BiaoCategory,
	[ChargeBiao].[BiaoGuiGe] = @BiaoGuiGe,
	[ChargeBiao].[Remark] = @Remark,
	[ChargeBiao].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[BiaoName],
	INSERTED.[BiaoCategory],
	INSERTED.[BiaoGuiGe],
	INSERTED.[Remark],
	INSERTED.[AddTime]
into @table
WHERE 
	[ChargeBiao].[ID] = @ID

SELECT 
	[ID],
	[BiaoName],
	[BiaoCategory],
	[BiaoGuiGe],
	[Remark],
	[AddTime] 
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
DELETE FROM [dbo].[ChargeBiao]
WHERE 
	[ChargeBiao].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ChargeBiao() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetChargeBiao(this.ID));
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
	[ChargeBiao].[ID],
	[ChargeBiao].[BiaoName],
	[ChargeBiao].[BiaoCategory],
	[ChargeBiao].[BiaoGuiGe],
	[ChargeBiao].[Remark],
	[ChargeBiao].[AddTime]
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
                return "ChargeBiao";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ChargeBiao into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="biaoName">biaoName</param>
		/// <param name="biaoCategory">biaoCategory</param>
		/// <param name="biaoGuiGe">biaoGuiGe</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		public static void InsertChargeBiao(string @biaoName, string @biaoCategory, string @biaoGuiGe, string @remark, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertChargeBiao(@biaoName, @biaoCategory, @biaoGuiGe, @remark, @addTime, helper);
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
		/// Insert a ChargeBiao into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="biaoName">biaoName</param>
		/// <param name="biaoCategory">biaoCategory</param>
		/// <param name="biaoGuiGe">biaoGuiGe</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertChargeBiao(string @biaoName, string @biaoCategory, string @biaoGuiGe, string @remark, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BiaoName] nvarchar(50),
	[BiaoCategory] nvarchar(50),
	[BiaoGuiGe] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime
);

INSERT INTO [dbo].[ChargeBiao] (
	[ChargeBiao].[BiaoName],
	[ChargeBiao].[BiaoCategory],
	[ChargeBiao].[BiaoGuiGe],
	[ChargeBiao].[Remark],
	[ChargeBiao].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[BiaoName],
	INSERTED.[BiaoCategory],
	INSERTED.[BiaoGuiGe],
	INSERTED.[Remark],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@BiaoName,
	@BiaoCategory,
	@BiaoGuiGe,
	@Remark,
	@AddTime 
); 

SELECT 
	[ID],
	[BiaoName],
	[BiaoCategory],
	[BiaoGuiGe],
	[Remark],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@BiaoName", EntityBase.GetDatabaseValue(@biaoName)));
			parameters.Add(new SqlParameter("@BiaoCategory", EntityBase.GetDatabaseValue(@biaoCategory)));
			parameters.Add(new SqlParameter("@BiaoGuiGe", EntityBase.GetDatabaseValue(@biaoGuiGe)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ChargeBiao into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="biaoName">biaoName</param>
		/// <param name="biaoCategory">biaoCategory</param>
		/// <param name="biaoGuiGe">biaoGuiGe</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateChargeBiao(int @iD, string @biaoName, string @biaoCategory, string @biaoGuiGe, string @remark, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateChargeBiao(@iD, @biaoName, @biaoCategory, @biaoGuiGe, @remark, @addTime, helper);
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
		/// Updates a ChargeBiao into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="biaoName">biaoName</param>
		/// <param name="biaoCategory">biaoCategory</param>
		/// <param name="biaoGuiGe">biaoGuiGe</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateChargeBiao(int @iD, string @biaoName, string @biaoCategory, string @biaoGuiGe, string @remark, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BiaoName] nvarchar(50),
	[BiaoCategory] nvarchar(50),
	[BiaoGuiGe] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime
);

UPDATE [dbo].[ChargeBiao] SET 
	[ChargeBiao].[BiaoName] = @BiaoName,
	[ChargeBiao].[BiaoCategory] = @BiaoCategory,
	[ChargeBiao].[BiaoGuiGe] = @BiaoGuiGe,
	[ChargeBiao].[Remark] = @Remark,
	[ChargeBiao].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[BiaoName],
	INSERTED.[BiaoCategory],
	INSERTED.[BiaoGuiGe],
	INSERTED.[Remark],
	INSERTED.[AddTime]
into @table
WHERE 
	[ChargeBiao].[ID] = @ID

SELECT 
	[ID],
	[BiaoName],
	[BiaoCategory],
	[BiaoGuiGe],
	[Remark],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@BiaoName", EntityBase.GetDatabaseValue(@biaoName)));
			parameters.Add(new SqlParameter("@BiaoCategory", EntityBase.GetDatabaseValue(@biaoCategory)));
			parameters.Add(new SqlParameter("@BiaoGuiGe", EntityBase.GetDatabaseValue(@biaoGuiGe)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ChargeBiao from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteChargeBiao(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteChargeBiao(@iD, helper);
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
		/// Deletes a ChargeBiao from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteChargeBiao(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ChargeBiao]
WHERE 
	[ChargeBiao].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ChargeBiao object.
		/// </summary>
		/// <returns>The newly created ChargeBiao object.</returns>
		public static ChargeBiao CreateChargeBiao()
		{
			return InitializeNew<ChargeBiao>();
		}
		
		/// <summary>
		/// Retrieve information for a ChargeBiao by a ChargeBiao's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ChargeBiao</returns>
		public static ChargeBiao GetChargeBiao(int @iD)
		{
			string commandText = @"
SELECT 
" + ChargeBiao.SelectFieldList + @"
FROM [dbo].[ChargeBiao] 
WHERE 
	[ChargeBiao].[ID] = @ID " + ChargeBiao.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeBiao>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ChargeBiao by a ChargeBiao's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ChargeBiao</returns>
		public static ChargeBiao GetChargeBiao(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ChargeBiao.SelectFieldList + @"
FROM [dbo].[ChargeBiao] 
WHERE 
	[ChargeBiao].[ID] = @ID " + ChargeBiao.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeBiao>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ChargeBiao objects.
		/// </summary>
		/// <returns>The retrieved collection of ChargeBiao objects.</returns>
		public static EntityList<ChargeBiao> GetChargeBiaos()
		{
			string commandText = @"
SELECT " + ChargeBiao.SelectFieldList + "FROM [dbo].[ChargeBiao] " + ChargeBiao.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ChargeBiao>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ChargeBiao objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeBiao objects.</returns>
        public static EntityList<ChargeBiao> GetChargeBiaos(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeBiao>(SelectFieldList, "FROM [dbo].[ChargeBiao]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ChargeBiao objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeBiao objects.</returns>
        public static EntityList<ChargeBiao> GetChargeBiaos(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeBiao>(SelectFieldList, "FROM [dbo].[ChargeBiao]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ChargeBiao objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ChargeBiao objects.</returns>
		protected static EntityList<ChargeBiao> GetChargeBiaos(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeBiaos(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ChargeBiao objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeBiao objects.</returns>
		protected static EntityList<ChargeBiao> GetChargeBiaos(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeBiaos(string.Empty, where, parameters, ChargeBiao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeBiao objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeBiao objects.</returns>
		protected static EntityList<ChargeBiao> GetChargeBiaos(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeBiaos(prefix, where, parameters, ChargeBiao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeBiao objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeBiao objects.</returns>
		protected static EntityList<ChargeBiao> GetChargeBiaos(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeBiaos(string.Empty, where, parameters, ChargeBiao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeBiao objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeBiao objects.</returns>
		protected static EntityList<ChargeBiao> GetChargeBiaos(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeBiaos(prefix, where, parameters, ChargeBiao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeBiao objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ChargeBiao objects.</returns>
		protected static EntityList<ChargeBiao> GetChargeBiaos(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ChargeBiao.SelectFieldList + "FROM [dbo].[ChargeBiao] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ChargeBiao>(reader);
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
        protected static EntityList<ChargeBiao> GetChargeBiaos(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeBiao>(SelectFieldList, "FROM [dbo].[ChargeBiao] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ChargeBiao objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargeBiaoCount()
        {
            return GetChargeBiaoCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ChargeBiao objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargeBiaoCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ChargeBiao] " + where;

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
		public static partial class ChargeBiao_Properties
		{
			public const string ID = "ID";
			public const string BiaoName = "BiaoName";
			public const string BiaoCategory = "BiaoCategory";
			public const string BiaoGuiGe = "BiaoGuiGe";
			public const string Remark = "Remark";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"BiaoName" , "string:"},
    			 {"BiaoCategory" , "string:"},
    			 {"BiaoGuiGe" , "string:"},
    			 {"Remark" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
