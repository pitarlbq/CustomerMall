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
	/// This object represents the properties and methods of a InventoryInfo.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class InventoryInfo 
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
		private string _inventoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string InventoryName
		{
			[DebuggerStepThrough()]
			get { return this._inventoryName; }
			set 
			{
				if (this._inventoryName != value) 
				{
					this._inventoryName = value;
					this.IsDirty = true;	
					OnPropertyChanged("InventoryName");
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
	[InventoryName] nvarchar(50)
);

INSERT INTO [dbo].[InventoryInfo] (
	[InventoryInfo].[InventoryName]
) 
output 
	INSERTED.[ID],
	INSERTED.[InventoryName]
into @table
VALUES ( 
	@InventoryName 
); 

SELECT 
	[ID],
	[InventoryName] 
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
	[InventoryName] nvarchar(50)
);

UPDATE [dbo].[InventoryInfo] SET 
	[InventoryInfo].[InventoryName] = @InventoryName 
output 
	INSERTED.[ID],
	INSERTED.[InventoryName]
into @table
WHERE 
	[InventoryInfo].[ID] = @ID

SELECT 
	[ID],
	[InventoryName] 
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
DELETE FROM [dbo].[InventoryInfo]
WHERE 
	[InventoryInfo].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public InventoryInfo() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetInventoryInfo(this.ID));
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
	[InventoryInfo].[ID],
	[InventoryInfo].[InventoryName]
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
                return "InventoryInfo";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a InventoryInfo into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="inventoryName">inventoryName</param>
		public static void InsertInventoryInfo(string @inventoryName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertInventoryInfo(@inventoryName, helper);
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
		/// Insert a InventoryInfo into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="inventoryName">inventoryName</param>
		/// <param name="helper">helper</param>
		internal static void InsertInventoryInfo(string @inventoryName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[InventoryName] nvarchar(50)
);

INSERT INTO [dbo].[InventoryInfo] (
	[InventoryInfo].[InventoryName]
) 
output 
	INSERTED.[ID],
	INSERTED.[InventoryName]
into @table
VALUES ( 
	@InventoryName 
); 

SELECT 
	[ID],
	[InventoryName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@InventoryName", EntityBase.GetDatabaseValue(@inventoryName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a InventoryInfo into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="inventoryName">inventoryName</param>
		public static void UpdateInventoryInfo(int @iD, string @inventoryName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateInventoryInfo(@iD, @inventoryName, helper);
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
		/// Updates a InventoryInfo into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="inventoryName">inventoryName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateInventoryInfo(int @iD, string @inventoryName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[InventoryName] nvarchar(50)
);

UPDATE [dbo].[InventoryInfo] SET 
	[InventoryInfo].[InventoryName] = @InventoryName 
output 
	INSERTED.[ID],
	INSERTED.[InventoryName]
into @table
WHERE 
	[InventoryInfo].[ID] = @ID

SELECT 
	[ID],
	[InventoryName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@InventoryName", EntityBase.GetDatabaseValue(@inventoryName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a InventoryInfo from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteInventoryInfo(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteInventoryInfo(@iD, helper);
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
		/// Deletes a InventoryInfo from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteInventoryInfo(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[InventoryInfo]
WHERE 
	[InventoryInfo].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new InventoryInfo object.
		/// </summary>
		/// <returns>The newly created InventoryInfo object.</returns>
		public static InventoryInfo CreateInventoryInfo()
		{
			return InitializeNew<InventoryInfo>();
		}
		
		/// <summary>
		/// Retrieve information for a InventoryInfo by a InventoryInfo's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>InventoryInfo</returns>
		public static InventoryInfo GetInventoryInfo(int @iD)
		{
			string commandText = @"
SELECT 
" + InventoryInfo.SelectFieldList + @"
FROM [dbo].[InventoryInfo] 
WHERE 
	[InventoryInfo].[ID] = @ID " + InventoryInfo.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<InventoryInfo>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a InventoryInfo by a InventoryInfo's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>InventoryInfo</returns>
		public static InventoryInfo GetInventoryInfo(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + InventoryInfo.SelectFieldList + @"
FROM [dbo].[InventoryInfo] 
WHERE 
	[InventoryInfo].[ID] = @ID " + InventoryInfo.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<InventoryInfo>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection InventoryInfo objects.
		/// </summary>
		/// <returns>The retrieved collection of InventoryInfo objects.</returns>
		public static EntityList<InventoryInfo> GetInventoryInfos()
		{
			string commandText = @"
SELECT " + InventoryInfo.SelectFieldList + "FROM [dbo].[InventoryInfo] " + InventoryInfo.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<InventoryInfo>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection InventoryInfo objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of InventoryInfo objects.</returns>
        public static EntityList<InventoryInfo> GetInventoryInfos(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<InventoryInfo>(SelectFieldList, "FROM [dbo].[InventoryInfo]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection InventoryInfo objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of InventoryInfo objects.</returns>
        public static EntityList<InventoryInfo> GetInventoryInfos(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<InventoryInfo>(SelectFieldList, "FROM [dbo].[InventoryInfo]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection InventoryInfo objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of InventoryInfo objects.</returns>
		protected static EntityList<InventoryInfo> GetInventoryInfos(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetInventoryInfos(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection InventoryInfo objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of InventoryInfo objects.</returns>
		protected static EntityList<InventoryInfo> GetInventoryInfos(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetInventoryInfos(string.Empty, where, parameters, InventoryInfo.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection InventoryInfo objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of InventoryInfo objects.</returns>
		protected static EntityList<InventoryInfo> GetInventoryInfos(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetInventoryInfos(prefix, where, parameters, InventoryInfo.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection InventoryInfo objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of InventoryInfo objects.</returns>
		protected static EntityList<InventoryInfo> GetInventoryInfos(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetInventoryInfos(string.Empty, where, parameters, InventoryInfo.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection InventoryInfo objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of InventoryInfo objects.</returns>
		protected static EntityList<InventoryInfo> GetInventoryInfos(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetInventoryInfos(prefix, where, parameters, InventoryInfo.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection InventoryInfo objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of InventoryInfo objects.</returns>
		protected static EntityList<InventoryInfo> GetInventoryInfos(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + InventoryInfo.SelectFieldList + "FROM [dbo].[InventoryInfo] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<InventoryInfo>(reader);
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
        protected static EntityList<InventoryInfo> GetInventoryInfos(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<InventoryInfo>(SelectFieldList, "FROM [dbo].[InventoryInfo] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class InventoryInfoProperties
		{
			public const string ID = "ID";
			public const string InventoryName = "InventoryName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"InventoryName" , "string:"},
            };
		}
		#endregion
	}
}
