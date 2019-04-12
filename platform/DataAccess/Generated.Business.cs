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
	/// This object represents the properties and methods of a Business.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Business 
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
		private string _category = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Category
		{
			[DebuggerStepThrough()]
			get { return this._category; }
			set 
			{
				if (this._category != value) 
				{
					this._category = value;
					this.IsDirty = true;	
					OnPropertyChanged("Category");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contactName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContactName
		{
			[DebuggerStepThrough()]
			get { return this._contactName; }
			set 
			{
				if (this._contactName != value) 
				{
					this._contactName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContactName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contactPhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContactPhone
		{
			[DebuggerStepThrough()]
			get { return this._contactPhone; }
			set 
			{
				if (this._contactPhone != value) 
				{
					this._contactPhone = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContactPhone");
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
	[Category] nvarchar(50),
	[ContactName] nvarchar(100),
	[ContactPhone] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime
);

INSERT INTO [dbo].[Business] (
	[Business].[Category],
	[Business].[ContactName],
	[Business].[ContactPhone],
	[Business].[Remark],
	[Business].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[Category],
	INSERTED.[ContactName],
	INSERTED.[ContactPhone],
	INSERTED.[Remark],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@Category,
	@ContactName,
	@ContactPhone,
	@Remark,
	@AddTime 
); 

SELECT 
	[ID],
	[Category],
	[ContactName],
	[ContactPhone],
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
	[Category] nvarchar(50),
	[ContactName] nvarchar(100),
	[ContactPhone] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime
);

UPDATE [dbo].[Business] SET 
	[Business].[Category] = @Category,
	[Business].[ContactName] = @ContactName,
	[Business].[ContactPhone] = @ContactPhone,
	[Business].[Remark] = @Remark,
	[Business].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[Category],
	INSERTED.[ContactName],
	INSERTED.[ContactPhone],
	INSERTED.[Remark],
	INSERTED.[AddTime]
into @table
WHERE 
	[Business].[ID] = @ID

SELECT 
	[ID],
	[Category],
	[ContactName],
	[ContactPhone],
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
DELETE FROM [dbo].[Business]
WHERE 
	[Business].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Business() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetBusiness(this.ID));
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
	[Business].[ID],
	[Business].[Category],
	[Business].[ContactName],
	[Business].[ContactPhone],
	[Business].[Remark],
	[Business].[AddTime]
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
                return "Business";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Business into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="category">category</param>
		/// <param name="contactName">contactName</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		public static void InsertBusiness(string @category, string @contactName, string @contactPhone, string @remark, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertBusiness(@category, @contactName, @contactPhone, @remark, @addTime, helper);
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
		/// Insert a Business into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="category">category</param>
		/// <param name="contactName">contactName</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertBusiness(string @category, string @contactName, string @contactPhone, string @remark, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Category] nvarchar(50),
	[ContactName] nvarchar(100),
	[ContactPhone] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime
);

INSERT INTO [dbo].[Business] (
	[Business].[Category],
	[Business].[ContactName],
	[Business].[ContactPhone],
	[Business].[Remark],
	[Business].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[Category],
	INSERTED.[ContactName],
	INSERTED.[ContactPhone],
	INSERTED.[Remark],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@Category,
	@ContactName,
	@ContactPhone,
	@Remark,
	@AddTime 
); 

SELECT 
	[ID],
	[Category],
	[ContactName],
	[ContactPhone],
	[Remark],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Category", EntityBase.GetDatabaseValue(@category)));
			parameters.Add(new SqlParameter("@ContactName", EntityBase.GetDatabaseValue(@contactName)));
			parameters.Add(new SqlParameter("@ContactPhone", EntityBase.GetDatabaseValue(@contactPhone)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Business into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="category">category</param>
		/// <param name="contactName">contactName</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateBusiness(int @iD, string @category, string @contactName, string @contactPhone, string @remark, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateBusiness(@iD, @category, @contactName, @contactPhone, @remark, @addTime, helper);
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
		/// Updates a Business into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="category">category</param>
		/// <param name="contactName">contactName</param>
		/// <param name="contactPhone">contactPhone</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateBusiness(int @iD, string @category, string @contactName, string @contactPhone, string @remark, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Category] nvarchar(50),
	[ContactName] nvarchar(100),
	[ContactPhone] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime
);

UPDATE [dbo].[Business] SET 
	[Business].[Category] = @Category,
	[Business].[ContactName] = @ContactName,
	[Business].[ContactPhone] = @ContactPhone,
	[Business].[Remark] = @Remark,
	[Business].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[Category],
	INSERTED.[ContactName],
	INSERTED.[ContactPhone],
	INSERTED.[Remark],
	INSERTED.[AddTime]
into @table
WHERE 
	[Business].[ID] = @ID

SELECT 
	[ID],
	[Category],
	[ContactName],
	[ContactPhone],
	[Remark],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Category", EntityBase.GetDatabaseValue(@category)));
			parameters.Add(new SqlParameter("@ContactName", EntityBase.GetDatabaseValue(@contactName)));
			parameters.Add(new SqlParameter("@ContactPhone", EntityBase.GetDatabaseValue(@contactPhone)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Business from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteBusiness(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteBusiness(@iD, helper);
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
		/// Deletes a Business from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteBusiness(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Business]
WHERE 
	[Business].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Business object.
		/// </summary>
		/// <returns>The newly created Business object.</returns>
		public static Business CreateBusiness()
		{
			return InitializeNew<Business>();
		}
		
		/// <summary>
		/// Retrieve information for a Business by a Business's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Business</returns>
		public static Business GetBusiness(int @iD)
		{
			string commandText = @"
SELECT 
" + Business.SelectFieldList + @"
FROM [dbo].[Business] 
WHERE 
	[Business].[ID] = @ID " + Business.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Business>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Business by a Business's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Business</returns>
		public static Business GetBusiness(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Business.SelectFieldList + @"
FROM [dbo].[Business] 
WHERE 
	[Business].[ID] = @ID " + Business.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Business>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Business objects.
		/// </summary>
		/// <returns>The retrieved collection of Business objects.</returns>
		public static EntityList<Business> GetBusinesses()
		{
			string commandText = @"
SELECT " + Business.SelectFieldList + "FROM [dbo].[Business] " + Business.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Business>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Business objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Business objects.</returns>
        public static EntityList<Business> GetBusinesses(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Business>(SelectFieldList, "FROM [dbo].[Business]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Business objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Business objects.</returns>
        public static EntityList<Business> GetBusinesses(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Business>(SelectFieldList, "FROM [dbo].[Business]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Business objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Business objects.</returns>
		protected static EntityList<Business> GetBusinesses(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetBusinesses(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Business objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Business objects.</returns>
		protected static EntityList<Business> GetBusinesses(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetBusinesses(string.Empty, where, parameters, Business.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Business objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Business objects.</returns>
		protected static EntityList<Business> GetBusinesses(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetBusinesses(prefix, where, parameters, Business.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Business objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Business objects.</returns>
		protected static EntityList<Business> GetBusinesses(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetBusinesses(string.Empty, where, parameters, Business.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Business objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Business objects.</returns>
		protected static EntityList<Business> GetBusinesses(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetBusinesses(prefix, where, parameters, Business.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Business objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Business objects.</returns>
		protected static EntityList<Business> GetBusinesses(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Business.SelectFieldList + "FROM [dbo].[Business] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Business>(reader);
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
        protected static EntityList<Business> GetBusinesses(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Business>(SelectFieldList, "FROM [dbo].[Business] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class BusinessProperties
		{
			public const string ID = "ID";
			public const string Category = "Category";
			public const string ContactName = "ContactName";
			public const string ContactPhone = "ContactPhone";
			public const string Remark = "Remark";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Category" , "string:"},
    			 {"ContactName" , "string:"},
    			 {"ContactPhone" , "string:"},
    			 {"Remark" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
