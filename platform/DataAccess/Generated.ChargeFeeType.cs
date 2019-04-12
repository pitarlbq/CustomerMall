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
	/// This object represents the properties and methods of a ChargeFeeType.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ChargeFeeType 
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
		private string _feeTypeName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FeeTypeName
		{
			[DebuggerStepThrough()]
			get { return this._feeTypeName; }
			set 
			{
				if (this._feeTypeName != value) 
				{
					this._feeTypeName = value;
					this.IsDirty = true;	
					OnPropertyChanged("FeeTypeName");
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
	[FeeTypeName] nvarchar(50)
);

INSERT INTO [dbo].[ChargeFeeType] (
	[ChargeFeeType].[FeeTypeName]
) 
output 
	INSERTED.[ID],
	INSERTED.[FeeTypeName]
into @table
VALUES ( 
	@FeeTypeName 
); 

SELECT 
	[ID],
	[FeeTypeName] 
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
	[FeeTypeName] nvarchar(50)
);

UPDATE [dbo].[ChargeFeeType] SET 
	[ChargeFeeType].[FeeTypeName] = @FeeTypeName 
output 
	INSERTED.[ID],
	INSERTED.[FeeTypeName]
into @table
WHERE 
	[ChargeFeeType].[ID] = @ID

SELECT 
	[ID],
	[FeeTypeName] 
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
DELETE FROM [dbo].[ChargeFeeType]
WHERE 
	[ChargeFeeType].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ChargeFeeType() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetChargeFeeType(this.ID));
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
	[ChargeFeeType].[ID],
	[ChargeFeeType].[FeeTypeName]
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
                return "ChargeFeeType";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ChargeFeeType into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="feeTypeName">feeTypeName</param>
		public static void InsertChargeFeeType(string @feeTypeName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertChargeFeeType(@feeTypeName, helper);
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
		/// Insert a ChargeFeeType into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="feeTypeName">feeTypeName</param>
		/// <param name="helper">helper</param>
		internal static void InsertChargeFeeType(string @feeTypeName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[FeeTypeName] nvarchar(50)
);

INSERT INTO [dbo].[ChargeFeeType] (
	[ChargeFeeType].[FeeTypeName]
) 
output 
	INSERTED.[ID],
	INSERTED.[FeeTypeName]
into @table
VALUES ( 
	@FeeTypeName 
); 

SELECT 
	[ID],
	[FeeTypeName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@FeeTypeName", EntityBase.GetDatabaseValue(@feeTypeName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ChargeFeeType into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="feeTypeName">feeTypeName</param>
		public static void UpdateChargeFeeType(int @iD, string @feeTypeName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateChargeFeeType(@iD, @feeTypeName, helper);
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
		/// Updates a ChargeFeeType into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="feeTypeName">feeTypeName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateChargeFeeType(int @iD, string @feeTypeName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[FeeTypeName] nvarchar(50)
);

UPDATE [dbo].[ChargeFeeType] SET 
	[ChargeFeeType].[FeeTypeName] = @FeeTypeName 
output 
	INSERTED.[ID],
	INSERTED.[FeeTypeName]
into @table
WHERE 
	[ChargeFeeType].[ID] = @ID

SELECT 
	[ID],
	[FeeTypeName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@FeeTypeName", EntityBase.GetDatabaseValue(@feeTypeName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ChargeFeeType from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteChargeFeeType(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteChargeFeeType(@iD, helper);
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
		/// Deletes a ChargeFeeType from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteChargeFeeType(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ChargeFeeType]
WHERE 
	[ChargeFeeType].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ChargeFeeType object.
		/// </summary>
		/// <returns>The newly created ChargeFeeType object.</returns>
		public static ChargeFeeType CreateChargeFeeType()
		{
			return InitializeNew<ChargeFeeType>();
		}
		
		/// <summary>
		/// Retrieve information for a ChargeFeeType by a ChargeFeeType's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ChargeFeeType</returns>
		public static ChargeFeeType GetChargeFeeType(int @iD)
		{
			string commandText = @"
SELECT 
" + ChargeFeeType.SelectFieldList + @"
FROM [dbo].[ChargeFeeType] 
WHERE 
	[ChargeFeeType].[ID] = @ID " + ChargeFeeType.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeFeeType>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ChargeFeeType by a ChargeFeeType's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ChargeFeeType</returns>
		public static ChargeFeeType GetChargeFeeType(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ChargeFeeType.SelectFieldList + @"
FROM [dbo].[ChargeFeeType] 
WHERE 
	[ChargeFeeType].[ID] = @ID " + ChargeFeeType.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeFeeType>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ChargeFeeType objects.
		/// </summary>
		/// <returns>The retrieved collection of ChargeFeeType objects.</returns>
		public static EntityList<ChargeFeeType> GetChargeFeeTypes()
		{
			string commandText = @"
SELECT " + ChargeFeeType.SelectFieldList + "FROM [dbo].[ChargeFeeType] " + ChargeFeeType.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ChargeFeeType>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ChargeFeeType objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeFeeType objects.</returns>
        public static EntityList<ChargeFeeType> GetChargeFeeTypes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeFeeType>(SelectFieldList, "FROM [dbo].[ChargeFeeType]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ChargeFeeType objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeFeeType objects.</returns>
        public static EntityList<ChargeFeeType> GetChargeFeeTypes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeFeeType>(SelectFieldList, "FROM [dbo].[ChargeFeeType]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ChargeFeeType objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ChargeFeeType objects.</returns>
		protected static EntityList<ChargeFeeType> GetChargeFeeTypes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeFeeTypes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ChargeFeeType objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeFeeType objects.</returns>
		protected static EntityList<ChargeFeeType> GetChargeFeeTypes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeFeeTypes(string.Empty, where, parameters, ChargeFeeType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeFeeType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeFeeType objects.</returns>
		protected static EntityList<ChargeFeeType> GetChargeFeeTypes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeFeeTypes(prefix, where, parameters, ChargeFeeType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeFeeType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeFeeType objects.</returns>
		protected static EntityList<ChargeFeeType> GetChargeFeeTypes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeFeeTypes(string.Empty, where, parameters, ChargeFeeType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeFeeType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeFeeType objects.</returns>
		protected static EntityList<ChargeFeeType> GetChargeFeeTypes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeFeeTypes(prefix, where, parameters, ChargeFeeType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeFeeType objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ChargeFeeType objects.</returns>
		protected static EntityList<ChargeFeeType> GetChargeFeeTypes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ChargeFeeType.SelectFieldList + "FROM [dbo].[ChargeFeeType] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ChargeFeeType>(reader);
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
        protected static EntityList<ChargeFeeType> GetChargeFeeTypes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeFeeType>(SelectFieldList, "FROM [dbo].[ChargeFeeType] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class ChargeFeeTypeProperties
		{
			public const string ID = "ID";
			public const string FeeTypeName = "FeeTypeName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"FeeTypeName" , "string:"},
            };
		}
		#endregion
	}
}
