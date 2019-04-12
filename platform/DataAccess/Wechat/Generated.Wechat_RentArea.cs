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
	/// This object represents the properties and methods of a Wechat_RentArea.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_RentArea 
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
		private string _areaName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AreaName
		{
			[DebuggerStepThrough()]
			get { return this._areaName; }
			set 
			{
				if (this._areaName != value) 
				{
					this._areaName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AreaName");
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
	[AreaName] nvarchar(200),
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

INSERT INTO [dbo].[Wechat_RentArea] (
	[Wechat_RentArea].[AreaName],
	[Wechat_RentArea].[AddTime],
	[Wechat_RentArea].[AddMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[AreaName],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
VALUES ( 
	@AreaName,
	@AddTime,
	@AddMan 
); 

SELECT 
	[ID],
	[AreaName],
	[AddTime],
	[AddMan] 
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
	[AreaName] nvarchar(200),
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

UPDATE [dbo].[Wechat_RentArea] SET 
	[Wechat_RentArea].[AreaName] = @AreaName,
	[Wechat_RentArea].[AddTime] = @AddTime,
	[Wechat_RentArea].[AddMan] = @AddMan 
output 
	INSERTED.[ID],
	INSERTED.[AreaName],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
WHERE 
	[Wechat_RentArea].[ID] = @ID

SELECT 
	[ID],
	[AreaName],
	[AddTime],
	[AddMan] 
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
DELETE FROM [dbo].[Wechat_RentArea]
WHERE 
	[Wechat_RentArea].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_RentArea() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_RentArea(this.ID));
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
	[Wechat_RentArea].[ID],
	[Wechat_RentArea].[AreaName],
	[Wechat_RentArea].[AddTime],
	[Wechat_RentArea].[AddMan]
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
                return "Wechat_RentArea";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_RentArea into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="areaName">areaName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		public static void InsertWechat_RentArea(string @areaName, DateTime @addTime, string @addMan)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_RentArea(@areaName, @addTime, @addMan, helper);
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
		/// Insert a Wechat_RentArea into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="areaName">areaName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_RentArea(string @areaName, DateTime @addTime, string @addMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AreaName] nvarchar(200),
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

INSERT INTO [dbo].[Wechat_RentArea] (
	[Wechat_RentArea].[AreaName],
	[Wechat_RentArea].[AddTime],
	[Wechat_RentArea].[AddMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[AreaName],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
VALUES ( 
	@AreaName,
	@AddTime,
	@AddMan 
); 

SELECT 
	[ID],
	[AreaName],
	[AddTime],
	[AddMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@AreaName", EntityBase.GetDatabaseValue(@areaName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_RentArea into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="areaName">areaName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		public static void UpdateWechat_RentArea(int @iD, string @areaName, DateTime @addTime, string @addMan)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_RentArea(@iD, @areaName, @addTime, @addMan, helper);
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
		/// Updates a Wechat_RentArea into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="areaName">areaName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_RentArea(int @iD, string @areaName, DateTime @addTime, string @addMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AreaName] nvarchar(200),
	[AddTime] datetime,
	[AddMan] nvarchar(200)
);

UPDATE [dbo].[Wechat_RentArea] SET 
	[Wechat_RentArea].[AreaName] = @AreaName,
	[Wechat_RentArea].[AddTime] = @AddTime,
	[Wechat_RentArea].[AddMan] = @AddMan 
output 
	INSERTED.[ID],
	INSERTED.[AreaName],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
WHERE 
	[Wechat_RentArea].[ID] = @ID

SELECT 
	[ID],
	[AreaName],
	[AddTime],
	[AddMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@AreaName", EntityBase.GetDatabaseValue(@areaName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_RentArea from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_RentArea(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_RentArea(@iD, helper);
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
		/// Deletes a Wechat_RentArea from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_RentArea(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_RentArea]
WHERE 
	[Wechat_RentArea].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_RentArea object.
		/// </summary>
		/// <returns>The newly created Wechat_RentArea object.</returns>
		public static Wechat_RentArea CreateWechat_RentArea()
		{
			return InitializeNew<Wechat_RentArea>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_RentArea by a Wechat_RentArea's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_RentArea</returns>
		public static Wechat_RentArea GetWechat_RentArea(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_RentArea.SelectFieldList + @"
FROM [dbo].[Wechat_RentArea] 
WHERE 
	[Wechat_RentArea].[ID] = @ID " + Wechat_RentArea.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_RentArea>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_RentArea by a Wechat_RentArea's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_RentArea</returns>
		public static Wechat_RentArea GetWechat_RentArea(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_RentArea.SelectFieldList + @"
FROM [dbo].[Wechat_RentArea] 
WHERE 
	[Wechat_RentArea].[ID] = @ID " + Wechat_RentArea.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_RentArea>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentArea objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_RentArea objects.</returns>
		public static EntityList<Wechat_RentArea> GetWechat_RentAreas()
		{
			string commandText = @"
SELECT " + Wechat_RentArea.SelectFieldList + "FROM [dbo].[Wechat_RentArea] " + Wechat_RentArea.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_RentArea>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_RentArea objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_RentArea objects.</returns>
        public static EntityList<Wechat_RentArea> GetWechat_RentAreas(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_RentArea>(SelectFieldList, "FROM [dbo].[Wechat_RentArea]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_RentArea objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_RentArea objects.</returns>
        public static EntityList<Wechat_RentArea> GetWechat_RentAreas(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_RentArea>(SelectFieldList, "FROM [dbo].[Wechat_RentArea]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_RentArea objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_RentArea objects.</returns>
		protected static EntityList<Wechat_RentArea> GetWechat_RentAreas(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_RentAreas(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentArea objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentArea objects.</returns>
		protected static EntityList<Wechat_RentArea> GetWechat_RentAreas(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_RentAreas(string.Empty, where, parameters, Wechat_RentArea.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentArea objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentArea objects.</returns>
		protected static EntityList<Wechat_RentArea> GetWechat_RentAreas(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_RentAreas(prefix, where, parameters, Wechat_RentArea.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentArea objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentArea objects.</returns>
		protected static EntityList<Wechat_RentArea> GetWechat_RentAreas(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_RentAreas(string.Empty, where, parameters, Wechat_RentArea.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentArea objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentArea objects.</returns>
		protected static EntityList<Wechat_RentArea> GetWechat_RentAreas(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_RentAreas(prefix, where, parameters, Wechat_RentArea.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentArea objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_RentArea objects.</returns>
		protected static EntityList<Wechat_RentArea> GetWechat_RentAreas(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_RentArea.SelectFieldList + "FROM [dbo].[Wechat_RentArea] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_RentArea>(reader);
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
        protected static EntityList<Wechat_RentArea> GetWechat_RentAreas(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_RentArea>(SelectFieldList, "FROM [dbo].[Wechat_RentArea] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_RentArea objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_RentAreaCount()
        {
            return GetWechat_RentAreaCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_RentArea objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_RentAreaCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_RentArea] " + where;

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
		public static partial class Wechat_RentArea_Properties
		{
			public const string ID = "ID";
			public const string AreaName = "AreaName";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"AreaName" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
            };
		}
		#endregion
	}
}
