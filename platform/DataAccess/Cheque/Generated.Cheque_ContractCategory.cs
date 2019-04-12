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
	/// This object represents the properties and methods of a Cheque_ContractCategory.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_ContractCategory 
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
		private string _contractCategoryNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractCategoryNumber
		{
			[DebuggerStepThrough()]
			get { return this._contractCategoryNumber; }
			set 
			{
				if (this._contractCategoryNumber != value) 
				{
					this._contractCategoryNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractCategoryNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contractCategoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractCategoryName
		{
			[DebuggerStepThrough()]
			get { return this._contractCategoryName; }
			set 
			{
				if (this._contractCategoryName != value) 
				{
					this._contractCategoryName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractCategoryName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _gUID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string GUID
		{
			[DebuggerStepThrough()]
			get { return this._gUID; }
			set 
			{
				if (this._gUID != value) 
				{
					this._gUID = value;
					this.IsDirty = true;	
					OnPropertyChanged("GUID");
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
	[ContractCategoryNumber] nvarchar(200),
	[ContractCategoryName] nvarchar(200),
	[GUID] nvarchar(500)
);

INSERT INTO [dbo].[Cheque_ContractCategory] (
	[Cheque_ContractCategory].[ContractCategoryNumber],
	[Cheque_ContractCategory].[ContractCategoryName],
	[Cheque_ContractCategory].[GUID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractCategoryNumber],
	INSERTED.[ContractCategoryName],
	INSERTED.[GUID]
into @table
VALUES ( 
	@ContractCategoryNumber,
	@ContractCategoryName,
	@GUID 
); 

SELECT 
	[ID],
	[ContractCategoryNumber],
	[ContractCategoryName],
	[GUID] 
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
	[ContractCategoryNumber] nvarchar(200),
	[ContractCategoryName] nvarchar(200),
	[GUID] nvarchar(500)
);

UPDATE [dbo].[Cheque_ContractCategory] SET 
	[Cheque_ContractCategory].[ContractCategoryNumber] = @ContractCategoryNumber,
	[Cheque_ContractCategory].[ContractCategoryName] = @ContractCategoryName,
	[Cheque_ContractCategory].[GUID] = @GUID 
output 
	INSERTED.[ID],
	INSERTED.[ContractCategoryNumber],
	INSERTED.[ContractCategoryName],
	INSERTED.[GUID]
into @table
WHERE 
	[Cheque_ContractCategory].[ID] = @ID

SELECT 
	[ID],
	[ContractCategoryNumber],
	[ContractCategoryName],
	[GUID] 
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
DELETE FROM [dbo].[Cheque_ContractCategory]
WHERE 
	[Cheque_ContractCategory].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_ContractCategory() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_ContractCategory(this.ID));
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
	[Cheque_ContractCategory].[ID],
	[Cheque_ContractCategory].[ContractCategoryNumber],
	[Cheque_ContractCategory].[ContractCategoryName],
	[Cheque_ContractCategory].[GUID]
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
                return "Cheque_ContractCategory";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_ContractCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractCategoryNumber">contractCategoryNumber</param>
		/// <param name="contractCategoryName">contractCategoryName</param>
		/// <param name="gUID">gUID</param>
		public static void InsertCheque_ContractCategory(string @contractCategoryNumber, string @contractCategoryName, string @gUID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_ContractCategory(@contractCategoryNumber, @contractCategoryName, @gUID, helper);
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
		/// Insert a Cheque_ContractCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractCategoryNumber">contractCategoryNumber</param>
		/// <param name="contractCategoryName">contractCategoryName</param>
		/// <param name="gUID">gUID</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_ContractCategory(string @contractCategoryNumber, string @contractCategoryName, string @gUID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractCategoryNumber] nvarchar(200),
	[ContractCategoryName] nvarchar(200),
	[GUID] nvarchar(500)
);

INSERT INTO [dbo].[Cheque_ContractCategory] (
	[Cheque_ContractCategory].[ContractCategoryNumber],
	[Cheque_ContractCategory].[ContractCategoryName],
	[Cheque_ContractCategory].[GUID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractCategoryNumber],
	INSERTED.[ContractCategoryName],
	INSERTED.[GUID]
into @table
VALUES ( 
	@ContractCategoryNumber,
	@ContractCategoryName,
	@GUID 
); 

SELECT 
	[ID],
	[ContractCategoryNumber],
	[ContractCategoryName],
	[GUID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ContractCategoryNumber", EntityBase.GetDatabaseValue(@contractCategoryNumber)));
			parameters.Add(new SqlParameter("@ContractCategoryName", EntityBase.GetDatabaseValue(@contractCategoryName)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_ContractCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractCategoryNumber">contractCategoryNumber</param>
		/// <param name="contractCategoryName">contractCategoryName</param>
		/// <param name="gUID">gUID</param>
		public static void UpdateCheque_ContractCategory(int @iD, string @contractCategoryNumber, string @contractCategoryName, string @gUID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_ContractCategory(@iD, @contractCategoryNumber, @contractCategoryName, @gUID, helper);
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
		/// Updates a Cheque_ContractCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractCategoryNumber">contractCategoryNumber</param>
		/// <param name="contractCategoryName">contractCategoryName</param>
		/// <param name="gUID">gUID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_ContractCategory(int @iD, string @contractCategoryNumber, string @contractCategoryName, string @gUID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractCategoryNumber] nvarchar(200),
	[ContractCategoryName] nvarchar(200),
	[GUID] nvarchar(500)
);

UPDATE [dbo].[Cheque_ContractCategory] SET 
	[Cheque_ContractCategory].[ContractCategoryNumber] = @ContractCategoryNumber,
	[Cheque_ContractCategory].[ContractCategoryName] = @ContractCategoryName,
	[Cheque_ContractCategory].[GUID] = @GUID 
output 
	INSERTED.[ID],
	INSERTED.[ContractCategoryNumber],
	INSERTED.[ContractCategoryName],
	INSERTED.[GUID]
into @table
WHERE 
	[Cheque_ContractCategory].[ID] = @ID

SELECT 
	[ID],
	[ContractCategoryNumber],
	[ContractCategoryName],
	[GUID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ContractCategoryNumber", EntityBase.GetDatabaseValue(@contractCategoryNumber)));
			parameters.Add(new SqlParameter("@ContractCategoryName", EntityBase.GetDatabaseValue(@contractCategoryName)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_ContractCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_ContractCategory(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_ContractCategory(@iD, helper);
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
		/// Deletes a Cheque_ContractCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_ContractCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_ContractCategory]
WHERE 
	[Cheque_ContractCategory].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_ContractCategory object.
		/// </summary>
		/// <returns>The newly created Cheque_ContractCategory object.</returns>
		public static Cheque_ContractCategory CreateCheque_ContractCategory()
		{
			return InitializeNew<Cheque_ContractCategory>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_ContractCategory by a Cheque_ContractCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_ContractCategory</returns>
		public static Cheque_ContractCategory GetCheque_ContractCategory(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_ContractCategory.SelectFieldList + @"
FROM [dbo].[Cheque_ContractCategory] 
WHERE 
	[Cheque_ContractCategory].[ID] = @ID " + Cheque_ContractCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_ContractCategory>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_ContractCategory by a Cheque_ContractCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_ContractCategory</returns>
		public static Cheque_ContractCategory GetCheque_ContractCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_ContractCategory.SelectFieldList + @"
FROM [dbo].[Cheque_ContractCategory] 
WHERE 
	[Cheque_ContractCategory].[ID] = @ID " + Cheque_ContractCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_ContractCategory>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_ContractCategory objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_ContractCategory objects.</returns>
		public static EntityList<Cheque_ContractCategory> GetCheque_ContractCategories()
		{
			string commandText = @"
SELECT " + Cheque_ContractCategory.SelectFieldList + "FROM [dbo].[Cheque_ContractCategory] " + Cheque_ContractCategory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_ContractCategory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_ContractCategory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_ContractCategory objects.</returns>
        public static EntityList<Cheque_ContractCategory> GetCheque_ContractCategories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_ContractCategory>(SelectFieldList, "FROM [dbo].[Cheque_ContractCategory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_ContractCategory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_ContractCategory objects.</returns>
        public static EntityList<Cheque_ContractCategory> GetCheque_ContractCategories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_ContractCategory>(SelectFieldList, "FROM [dbo].[Cheque_ContractCategory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_ContractCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_ContractCategory objects.</returns>
		protected static EntityList<Cheque_ContractCategory> GetCheque_ContractCategories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_ContractCategories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_ContractCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_ContractCategory objects.</returns>
		protected static EntityList<Cheque_ContractCategory> GetCheque_ContractCategories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_ContractCategories(string.Empty, where, parameters, Cheque_ContractCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_ContractCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_ContractCategory objects.</returns>
		protected static EntityList<Cheque_ContractCategory> GetCheque_ContractCategories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_ContractCategories(prefix, where, parameters, Cheque_ContractCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_ContractCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_ContractCategory objects.</returns>
		protected static EntityList<Cheque_ContractCategory> GetCheque_ContractCategories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_ContractCategories(string.Empty, where, parameters, Cheque_ContractCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_ContractCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_ContractCategory objects.</returns>
		protected static EntityList<Cheque_ContractCategory> GetCheque_ContractCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_ContractCategories(prefix, where, parameters, Cheque_ContractCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_ContractCategory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_ContractCategory objects.</returns>
		protected static EntityList<Cheque_ContractCategory> GetCheque_ContractCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_ContractCategory.SelectFieldList + "FROM [dbo].[Cheque_ContractCategory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_ContractCategory>(reader);
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
        protected static EntityList<Cheque_ContractCategory> GetCheque_ContractCategories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_ContractCategory>(SelectFieldList, "FROM [dbo].[Cheque_ContractCategory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_ContractCategory objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_ContractCategoryCount()
        {
            return GetCheque_ContractCategoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_ContractCategory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_ContractCategoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_ContractCategory] " + where;

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
		public static partial class Cheque_ContractCategory_Properties
		{
			public const string ID = "ID";
			public const string ContractCategoryNumber = "ContractCategoryNumber";
			public const string ContractCategoryName = "ContractCategoryName";
			public const string GUID = "GUID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ContractCategoryNumber" , "string:"},
    			 {"ContractCategoryName" , "string:"},
    			 {"GUID" , "string:"},
            };
		}
		#endregion
	}
}
