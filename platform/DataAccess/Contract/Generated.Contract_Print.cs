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
	/// This object represents the properties and methods of a Contract_Print.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Contract_Print 
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
		private int _contractID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ContractID
		{
			[DebuggerStepThrough()]
			get { return this._contractID; }
			set 
			{
				if (this._contractID != value) 
				{
					this._contractID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _contractTemplateID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ContractTemplateID
		{
			[DebuggerStepThrough()]
			get { return this._contractTemplateID; }
			set 
			{
				if (this._contractTemplateID != value) 
				{
					this._contractTemplateID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractTemplateID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _printContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PrintContent
		{
			[DebuggerStepThrough()]
			get { return this._printContent; }
			set 
			{
				if (this._printContent != value) 
				{
					this._printContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintContent");
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
	[ContractID] int,
	[ContractTemplateID] int,
	[PrintContent] ntext,
	[AddTime] datetime
);

INSERT INTO [dbo].[Contract_Print] (
	[Contract_Print].[ContractID],
	[Contract_Print].[ContractTemplateID],
	[Contract_Print].[PrintContent],
	[Contract_Print].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[ContractTemplateID],
	INSERTED.[PrintContent],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@ContractID,
	@ContractTemplateID,
	@PrintContent,
	@AddTime 
); 

SELECT 
	[ID],
	[ContractID],
	[ContractTemplateID],
	[PrintContent],
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
	[ContractID] int,
	[ContractTemplateID] int,
	[PrintContent] ntext,
	[AddTime] datetime
);

UPDATE [dbo].[Contract_Print] SET 
	[Contract_Print].[ContractID] = @ContractID,
	[Contract_Print].[ContractTemplateID] = @ContractTemplateID,
	[Contract_Print].[PrintContent] = @PrintContent,
	[Contract_Print].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[ContractTemplateID],
	INSERTED.[PrintContent],
	INSERTED.[AddTime]
into @table
WHERE 
	[Contract_Print].[ID] = @ID

SELECT 
	[ID],
	[ContractID],
	[ContractTemplateID],
	[PrintContent],
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
DELETE FROM [dbo].[Contract_Print]
WHERE 
	[Contract_Print].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Contract_Print() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetContract_Print(this.ID));
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
	[Contract_Print].[ID],
	[Contract_Print].[ContractID],
	[Contract_Print].[ContractTemplateID],
	[Contract_Print].[PrintContent],
	[Contract_Print].[AddTime]
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
                return "Contract_Print";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Contract_Print into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractID">contractID</param>
		/// <param name="contractTemplateID">contractTemplateID</param>
		/// <param name="printContent">printContent</param>
		/// <param name="addTime">addTime</param>
		public static void InsertContract_Print(int @contractID, int @contractTemplateID, string @printContent, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertContract_Print(@contractID, @contractTemplateID, @printContent, @addTime, helper);
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
		/// Insert a Contract_Print into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="contractID">contractID</param>
		/// <param name="contractTemplateID">contractTemplateID</param>
		/// <param name="printContent">printContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertContract_Print(int @contractID, int @contractTemplateID, string @printContent, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractID] int,
	[ContractTemplateID] int,
	[PrintContent] ntext,
	[AddTime] datetime
);

INSERT INTO [dbo].[Contract_Print] (
	[Contract_Print].[ContractID],
	[Contract_Print].[ContractTemplateID],
	[Contract_Print].[PrintContent],
	[Contract_Print].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[ContractTemplateID],
	INSERTED.[PrintContent],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@ContractID,
	@ContractTemplateID,
	@PrintContent,
	@AddTime 
); 

SELECT 
	[ID],
	[ContractID],
	[ContractTemplateID],
	[PrintContent],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@ContractTemplateID", EntityBase.GetDatabaseValue(@contractTemplateID)));
			parameters.Add(new SqlParameter("@PrintContent", EntityBase.GetDatabaseValue(@printContent)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Contract_Print into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractID">contractID</param>
		/// <param name="contractTemplateID">contractTemplateID</param>
		/// <param name="printContent">printContent</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateContract_Print(int @iD, int @contractID, int @contractTemplateID, string @printContent, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateContract_Print(@iD, @contractID, @contractTemplateID, @printContent, @addTime, helper);
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
		/// Updates a Contract_Print into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="contractID">contractID</param>
		/// <param name="contractTemplateID">contractTemplateID</param>
		/// <param name="printContent">printContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateContract_Print(int @iD, int @contractID, int @contractTemplateID, string @printContent, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ContractID] int,
	[ContractTemplateID] int,
	[PrintContent] ntext,
	[AddTime] datetime
);

UPDATE [dbo].[Contract_Print] SET 
	[Contract_Print].[ContractID] = @ContractID,
	[Contract_Print].[ContractTemplateID] = @ContractTemplateID,
	[Contract_Print].[PrintContent] = @PrintContent,
	[Contract_Print].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[ContractID],
	INSERTED.[ContractTemplateID],
	INSERTED.[PrintContent],
	INSERTED.[AddTime]
into @table
WHERE 
	[Contract_Print].[ID] = @ID

SELECT 
	[ID],
	[ContractID],
	[ContractTemplateID],
	[PrintContent],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@ContractTemplateID", EntityBase.GetDatabaseValue(@contractTemplateID)));
			parameters.Add(new SqlParameter("@PrintContent", EntityBase.GetDatabaseValue(@printContent)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Contract_Print from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteContract_Print(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteContract_Print(@iD, helper);
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
		/// Deletes a Contract_Print from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteContract_Print(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Contract_Print]
WHERE 
	[Contract_Print].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Contract_Print object.
		/// </summary>
		/// <returns>The newly created Contract_Print object.</returns>
		public static Contract_Print CreateContract_Print()
		{
			return InitializeNew<Contract_Print>();
		}
		
		/// <summary>
		/// Retrieve information for a Contract_Print by a Contract_Print's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Contract_Print</returns>
		public static Contract_Print GetContract_Print(int @iD)
		{
			string commandText = @"
SELECT 
" + Contract_Print.SelectFieldList + @"
FROM [dbo].[Contract_Print] 
WHERE 
	[Contract_Print].[ID] = @ID " + Contract_Print.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_Print>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Contract_Print by a Contract_Print's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Contract_Print</returns>
		public static Contract_Print GetContract_Print(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Contract_Print.SelectFieldList + @"
FROM [dbo].[Contract_Print] 
WHERE 
	[Contract_Print].[ID] = @ID " + Contract_Print.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Contract_Print>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Contract_Print objects.
		/// </summary>
		/// <returns>The retrieved collection of Contract_Print objects.</returns>
		public static EntityList<Contract_Print> GetContract_Prints()
		{
			string commandText = @"
SELECT " + Contract_Print.SelectFieldList + "FROM [dbo].[Contract_Print] " + Contract_Print.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Contract_Print>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Contract_Print objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_Print objects.</returns>
        public static EntityList<Contract_Print> GetContract_Prints(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Print>(SelectFieldList, "FROM [dbo].[Contract_Print]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Contract_Print objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Contract_Print objects.</returns>
        public static EntityList<Contract_Print> GetContract_Prints(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Print>(SelectFieldList, "FROM [dbo].[Contract_Print]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Contract_Print objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Contract_Print objects.</returns>
		protected static EntityList<Contract_Print> GetContract_Prints(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Prints(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Contract_Print objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_Print objects.</returns>
		protected static EntityList<Contract_Print> GetContract_Prints(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Prints(string.Empty, where, parameters, Contract_Print.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Print objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Contract_Print objects.</returns>
		protected static EntityList<Contract_Print> GetContract_Prints(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetContract_Prints(prefix, where, parameters, Contract_Print.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Print objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_Print objects.</returns>
		protected static EntityList<Contract_Print> GetContract_Prints(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_Prints(string.Empty, where, parameters, Contract_Print.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Print objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Contract_Print objects.</returns>
		protected static EntityList<Contract_Print> GetContract_Prints(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetContract_Prints(prefix, where, parameters, Contract_Print.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Contract_Print objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Contract_Print objects.</returns>
		protected static EntityList<Contract_Print> GetContract_Prints(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Contract_Print.SelectFieldList + "FROM [dbo].[Contract_Print] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Contract_Print>(reader);
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
        protected static EntityList<Contract_Print> GetContract_Prints(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Contract_Print>(SelectFieldList, "FROM [dbo].[Contract_Print] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Contract_Print objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_PrintCount()
        {
            return GetContract_PrintCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Contract_Print objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetContract_PrintCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Contract_Print] " + where;

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
		public static partial class Contract_Print_Properties
		{
			public const string ID = "ID";
			public const string ContractID = "ContractID";
			public const string ContractTemplateID = "ContractTemplateID";
			public const string PrintContent = "PrintContent";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ContractID" , "int:"},
    			 {"ContractTemplateID" , "int:"},
    			 {"PrintContent" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
