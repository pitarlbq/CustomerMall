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
	/// This object represents the properties and methods of a ChargeRule.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ChargeRule 
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
		private string _name = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string Name
		{
			[DebuggerStepThrough()]
			get { return this._name; }
			set 
			{
				if (this._name != value) 
				{
					this._name = value;
					this.IsDirty = true;	
					OnPropertyChanged("Name");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _desc = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Desc
		{
			[DebuggerStepThrough()]
			get { return this._desc; }
			set 
			{
				if (this._desc != value) 
				{
					this._desc = value;
					this.IsDirty = true;	
					OnPropertyChanged("Desc");
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
	[Name] nvarchar(100),
	[Desc] nvarchar(500)
);

INSERT INTO [dbo].[ChargeRule] (
	[ChargeRule].[Name],
	[ChargeRule].[Desc]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Desc]
into @table
VALUES ( 
	@Name,
	@Desc 
); 

SELECT 
	[ID],
	[Name],
	[Desc] 
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
	[Name] nvarchar(100),
	[Desc] nvarchar(500)
);

UPDATE [dbo].[ChargeRule] SET 
	[ChargeRule].[Name] = @Name,
	[ChargeRule].[Desc] = @Desc 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Desc]
into @table
WHERE 
	[ChargeRule].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[Desc] 
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
DELETE FROM [dbo].[ChargeRule]
WHERE 
	[ChargeRule].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ChargeRule() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetChargeRule(this.ID));
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
	[ChargeRule].[ID],
	[ChargeRule].[Name],
	[ChargeRule].[Desc]
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
                return "ChargeRule";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ChargeRule into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="desc">desc</param>
		public static void InsertChargeRule(string @name, string @desc)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertChargeRule(@name, @desc, helper);
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
		/// Insert a ChargeRule into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="desc">desc</param>
		/// <param name="helper">helper</param>
		internal static void InsertChargeRule(string @name, string @desc, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(100),
	[Desc] nvarchar(500)
);

INSERT INTO [dbo].[ChargeRule] (
	[ChargeRule].[Name],
	[ChargeRule].[Desc]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Desc]
into @table
VALUES ( 
	@Name,
	@Desc 
); 

SELECT 
	[ID],
	[Name],
	[Desc] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Desc", EntityBase.GetDatabaseValue(@desc)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ChargeRule into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="desc">desc</param>
		public static void UpdateChargeRule(int @iD, string @name, string @desc)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateChargeRule(@iD, @name, @desc, helper);
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
		/// Updates a ChargeRule into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="desc">desc</param>
		/// <param name="helper">helper</param>
		internal static void UpdateChargeRule(int @iD, string @name, string @desc, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(100),
	[Desc] nvarchar(500)
);

UPDATE [dbo].[ChargeRule] SET 
	[ChargeRule].[Name] = @Name,
	[ChargeRule].[Desc] = @Desc 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Desc]
into @table
WHERE 
	[ChargeRule].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[Desc] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Desc", EntityBase.GetDatabaseValue(@desc)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ChargeRule from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteChargeRule(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteChargeRule(@iD, helper);
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
		/// Deletes a ChargeRule from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteChargeRule(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ChargeRule]
WHERE 
	[ChargeRule].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ChargeRule object.
		/// </summary>
		/// <returns>The newly created ChargeRule object.</returns>
		public static ChargeRule CreateChargeRule()
		{
			return InitializeNew<ChargeRule>();
		}
		
		/// <summary>
		/// Retrieve information for a ChargeRule by a ChargeRule's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ChargeRule</returns>
		public static ChargeRule GetChargeRule(int @iD)
		{
			string commandText = @"
SELECT 
" + ChargeRule.SelectFieldList + @"
FROM [dbo].[ChargeRule] 
WHERE 
	[ChargeRule].[ID] = @ID " + ChargeRule.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeRule>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ChargeRule by a ChargeRule's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ChargeRule</returns>
		public static ChargeRule GetChargeRule(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ChargeRule.SelectFieldList + @"
FROM [dbo].[ChargeRule] 
WHERE 
	[ChargeRule].[ID] = @ID " + ChargeRule.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeRule>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ChargeRule objects.
		/// </summary>
		/// <returns>The retrieved collection of ChargeRule objects.</returns>
		public static EntityList<ChargeRule> GetChargeRules()
		{
			string commandText = @"
SELECT " + ChargeRule.SelectFieldList + "FROM [dbo].[ChargeRule] " + ChargeRule.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ChargeRule>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ChargeRule objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeRule objects.</returns>
        public static EntityList<ChargeRule> GetChargeRules(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeRule>(SelectFieldList, "FROM [dbo].[ChargeRule]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ChargeRule objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeRule objects.</returns>
        public static EntityList<ChargeRule> GetChargeRules(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeRule>(SelectFieldList, "FROM [dbo].[ChargeRule]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ChargeRule objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ChargeRule objects.</returns>
		protected static EntityList<ChargeRule> GetChargeRules(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeRules(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ChargeRule objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeRule objects.</returns>
		protected static EntityList<ChargeRule> GetChargeRules(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeRules(string.Empty, where, parameters, ChargeRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeRule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeRule objects.</returns>
		protected static EntityList<ChargeRule> GetChargeRules(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeRules(prefix, where, parameters, ChargeRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeRule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeRule objects.</returns>
		protected static EntityList<ChargeRule> GetChargeRules(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeRules(string.Empty, where, parameters, ChargeRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeRule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeRule objects.</returns>
		protected static EntityList<ChargeRule> GetChargeRules(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeRules(prefix, where, parameters, ChargeRule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeRule objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ChargeRule objects.</returns>
		protected static EntityList<ChargeRule> GetChargeRules(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ChargeRule.SelectFieldList + "FROM [dbo].[ChargeRule] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ChargeRule>(reader);
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
        protected static EntityList<ChargeRule> GetChargeRules(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeRule>(SelectFieldList, "FROM [dbo].[ChargeRule] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class ChargeRuleProperties
		{
			public const string ID = "ID";
			public const string Name = "Name";
			public const string Desc = "Desc";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Name" , "string:"},
    			 {"Desc" , "string:"},
            };
		}
		#endregion
	}
}
