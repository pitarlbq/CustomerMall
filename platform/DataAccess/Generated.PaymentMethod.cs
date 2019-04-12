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
	/// This object represents the properties and methods of a PaymentMethod.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class PaymentMethod 
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
		private string _paymentMethodName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PaymentMethodName
		{
			[DebuggerStepThrough()]
			get { return this._paymentMethodName; }
			set 
			{
				if (this._paymentMethodName != value) 
				{
					this._paymentMethodName = value;
					this.IsDirty = true;	
					OnPropertyChanged("PaymentMethodName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isActive = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsActive
		{
			[DebuggerStepThrough()]
			get { return this._isActive; }
			set 
			{
				if (this._isActive != value) 
				{
					this._isActive = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsActive");
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
		private string _iconPath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string IconPath
		{
			[DebuggerStepThrough()]
			get { return this._iconPath; }
			set 
			{
				if (this._iconPath != value) 
				{
					this._iconPath = value;
					this.IsDirty = true;	
					OnPropertyChanged("IconPath");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _value = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Value
		{
			[DebuggerStepThrough()]
			get { return this._value; }
			set 
			{
				if (this._value != value) 
				{
					this._value = value;
					this.IsDirty = true;	
					OnPropertyChanged("Value");
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
	[PaymentMethodName] nvarchar(50),
	[IsActive] bit,
	[AddTime] datetime,
	[IconPath] nvarchar(500),
	[Value] nvarchar(50)
);

INSERT INTO [dbo].[PaymentMethod] (
	[PaymentMethod].[PaymentMethodName],
	[PaymentMethod].[IsActive],
	[PaymentMethod].[AddTime],
	[PaymentMethod].[IconPath],
	[PaymentMethod].[Value]
) 
output 
	INSERTED.[ID],
	INSERTED.[PaymentMethodName],
	INSERTED.[IsActive],
	INSERTED.[AddTime],
	INSERTED.[IconPath],
	INSERTED.[Value]
into @table
VALUES ( 
	@PaymentMethodName,
	@IsActive,
	@AddTime,
	@IconPath,
	@Value 
); 

SELECT 
	[ID],
	[PaymentMethodName],
	[IsActive],
	[AddTime],
	[IconPath],
	[Value] 
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
	[PaymentMethodName] nvarchar(50),
	[IsActive] bit,
	[AddTime] datetime,
	[IconPath] nvarchar(500),
	[Value] nvarchar(50)
);

UPDATE [dbo].[PaymentMethod] SET 
	[PaymentMethod].[PaymentMethodName] = @PaymentMethodName,
	[PaymentMethod].[IsActive] = @IsActive,
	[PaymentMethod].[AddTime] = @AddTime,
	[PaymentMethod].[IconPath] = @IconPath,
	[PaymentMethod].[Value] = @Value 
output 
	INSERTED.[ID],
	INSERTED.[PaymentMethodName],
	INSERTED.[IsActive],
	INSERTED.[AddTime],
	INSERTED.[IconPath],
	INSERTED.[Value]
into @table
WHERE 
	[PaymentMethod].[ID] = @ID

SELECT 
	[ID],
	[PaymentMethodName],
	[IsActive],
	[AddTime],
	[IconPath],
	[Value] 
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
DELETE FROM [dbo].[PaymentMethod]
WHERE 
	[PaymentMethod].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public PaymentMethod() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetPaymentMethod(this.ID));
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
	[PaymentMethod].[ID],
	[PaymentMethod].[PaymentMethodName],
	[PaymentMethod].[IsActive],
	[PaymentMethod].[AddTime],
	[PaymentMethod].[IconPath],
	[PaymentMethod].[Value]
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
                return "PaymentMethod";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a PaymentMethod into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="paymentMethodName">paymentMethodName</param>
		/// <param name="isActive">isActive</param>
		/// <param name="addTime">addTime</param>
		/// <param name="iconPath">iconPath</param>
		/// <param name="value">value</param>
		public static void InsertPaymentMethod(string @paymentMethodName, bool @isActive, DateTime @addTime, string @iconPath, string @value)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertPaymentMethod(@paymentMethodName, @isActive, @addTime, @iconPath, @value, helper);
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
		/// Insert a PaymentMethod into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="paymentMethodName">paymentMethodName</param>
		/// <param name="isActive">isActive</param>
		/// <param name="addTime">addTime</param>
		/// <param name="iconPath">iconPath</param>
		/// <param name="value">value</param>
		/// <param name="helper">helper</param>
		internal static void InsertPaymentMethod(string @paymentMethodName, bool @isActive, DateTime @addTime, string @iconPath, string @value, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[PaymentMethodName] nvarchar(50),
	[IsActive] bit,
	[AddTime] datetime,
	[IconPath] nvarchar(500),
	[Value] nvarchar(50)
);

INSERT INTO [dbo].[PaymentMethod] (
	[PaymentMethod].[PaymentMethodName],
	[PaymentMethod].[IsActive],
	[PaymentMethod].[AddTime],
	[PaymentMethod].[IconPath],
	[PaymentMethod].[Value]
) 
output 
	INSERTED.[ID],
	INSERTED.[PaymentMethodName],
	INSERTED.[IsActive],
	INSERTED.[AddTime],
	INSERTED.[IconPath],
	INSERTED.[Value]
into @table
VALUES ( 
	@PaymentMethodName,
	@IsActive,
	@AddTime,
	@IconPath,
	@Value 
); 

SELECT 
	[ID],
	[PaymentMethodName],
	[IsActive],
	[AddTime],
	[IconPath],
	[Value] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@PaymentMethodName", EntityBase.GetDatabaseValue(@paymentMethodName)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@IconPath", EntityBase.GetDatabaseValue(@iconPath)));
			parameters.Add(new SqlParameter("@Value", EntityBase.GetDatabaseValue(@value)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a PaymentMethod into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="paymentMethodName">paymentMethodName</param>
		/// <param name="isActive">isActive</param>
		/// <param name="addTime">addTime</param>
		/// <param name="iconPath">iconPath</param>
		/// <param name="value">value</param>
		public static void UpdatePaymentMethod(int @iD, string @paymentMethodName, bool @isActive, DateTime @addTime, string @iconPath, string @value)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdatePaymentMethod(@iD, @paymentMethodName, @isActive, @addTime, @iconPath, @value, helper);
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
		/// Updates a PaymentMethod into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="paymentMethodName">paymentMethodName</param>
		/// <param name="isActive">isActive</param>
		/// <param name="addTime">addTime</param>
		/// <param name="iconPath">iconPath</param>
		/// <param name="value">value</param>
		/// <param name="helper">helper</param>
		internal static void UpdatePaymentMethod(int @iD, string @paymentMethodName, bool @isActive, DateTime @addTime, string @iconPath, string @value, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[PaymentMethodName] nvarchar(50),
	[IsActive] bit,
	[AddTime] datetime,
	[IconPath] nvarchar(500),
	[Value] nvarchar(50)
);

UPDATE [dbo].[PaymentMethod] SET 
	[PaymentMethod].[PaymentMethodName] = @PaymentMethodName,
	[PaymentMethod].[IsActive] = @IsActive,
	[PaymentMethod].[AddTime] = @AddTime,
	[PaymentMethod].[IconPath] = @IconPath,
	[PaymentMethod].[Value] = @Value 
output 
	INSERTED.[ID],
	INSERTED.[PaymentMethodName],
	INSERTED.[IsActive],
	INSERTED.[AddTime],
	INSERTED.[IconPath],
	INSERTED.[Value]
into @table
WHERE 
	[PaymentMethod].[ID] = @ID

SELECT 
	[ID],
	[PaymentMethodName],
	[IsActive],
	[AddTime],
	[IconPath],
	[Value] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@PaymentMethodName", EntityBase.GetDatabaseValue(@paymentMethodName)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@IconPath", EntityBase.GetDatabaseValue(@iconPath)));
			parameters.Add(new SqlParameter("@Value", EntityBase.GetDatabaseValue(@value)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a PaymentMethod from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeletePaymentMethod(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeletePaymentMethod(@iD, helper);
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
		/// Deletes a PaymentMethod from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeletePaymentMethod(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[PaymentMethod]
WHERE 
	[PaymentMethod].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new PaymentMethod object.
		/// </summary>
		/// <returns>The newly created PaymentMethod object.</returns>
		public static PaymentMethod CreatePaymentMethod()
		{
			return InitializeNew<PaymentMethod>();
		}
		
		/// <summary>
		/// Retrieve information for a PaymentMethod by a PaymentMethod's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>PaymentMethod</returns>
		public static PaymentMethod GetPaymentMethod(int @iD)
		{
			string commandText = @"
SELECT 
" + PaymentMethod.SelectFieldList + @"
FROM [dbo].[PaymentMethod] 
WHERE 
	[PaymentMethod].[ID] = @ID " + PaymentMethod.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<PaymentMethod>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a PaymentMethod by a PaymentMethod's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>PaymentMethod</returns>
		public static PaymentMethod GetPaymentMethod(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + PaymentMethod.SelectFieldList + @"
FROM [dbo].[PaymentMethod] 
WHERE 
	[PaymentMethod].[ID] = @ID " + PaymentMethod.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<PaymentMethod>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection PaymentMethod objects.
		/// </summary>
		/// <returns>The retrieved collection of PaymentMethod objects.</returns>
		public static EntityList<PaymentMethod> GetPaymentMethods()
		{
			string commandText = @"
SELECT " + PaymentMethod.SelectFieldList + "FROM [dbo].[PaymentMethod] " + PaymentMethod.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<PaymentMethod>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection PaymentMethod objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of PaymentMethod objects.</returns>
        public static EntityList<PaymentMethod> GetPaymentMethods(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PaymentMethod>(SelectFieldList, "FROM [dbo].[PaymentMethod]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection PaymentMethod objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of PaymentMethod objects.</returns>
        public static EntityList<PaymentMethod> GetPaymentMethods(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PaymentMethod>(SelectFieldList, "FROM [dbo].[PaymentMethod]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection PaymentMethod objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of PaymentMethod objects.</returns>
		protected static EntityList<PaymentMethod> GetPaymentMethods(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPaymentMethods(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection PaymentMethod objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of PaymentMethod objects.</returns>
		protected static EntityList<PaymentMethod> GetPaymentMethods(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPaymentMethods(string.Empty, where, parameters, PaymentMethod.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PaymentMethod objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of PaymentMethod objects.</returns>
		protected static EntityList<PaymentMethod> GetPaymentMethods(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPaymentMethods(prefix, where, parameters, PaymentMethod.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PaymentMethod objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of PaymentMethod objects.</returns>
		protected static EntityList<PaymentMethod> GetPaymentMethods(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetPaymentMethods(string.Empty, where, parameters, PaymentMethod.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PaymentMethod objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of PaymentMethod objects.</returns>
		protected static EntityList<PaymentMethod> GetPaymentMethods(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetPaymentMethods(prefix, where, parameters, PaymentMethod.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PaymentMethod objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of PaymentMethod objects.</returns>
		protected static EntityList<PaymentMethod> GetPaymentMethods(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + PaymentMethod.SelectFieldList + "FROM [dbo].[PaymentMethod] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<PaymentMethod>(reader);
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
        protected static EntityList<PaymentMethod> GetPaymentMethods(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PaymentMethod>(SelectFieldList, "FROM [dbo].[PaymentMethod] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of PaymentMethod objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetPaymentMethodCount()
        {
            return GetPaymentMethodCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of PaymentMethod objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetPaymentMethodCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[PaymentMethod] " + where;

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
		public static partial class PaymentMethod_Properties
		{
			public const string ID = "ID";
			public const string PaymentMethodName = "PaymentMethodName";
			public const string IsActive = "IsActive";
			public const string AddTime = "AddTime";
			public const string IconPath = "IconPath";
			public const string Value = "Value";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"PaymentMethodName" , "string:"},
    			 {"IsActive" , "bool:"},
    			 {"AddTime" , "DateTime:"},
    			 {"IconPath" , "string:"},
    			 {"Value" , "string:"},
            };
		}
		#endregion
	}
}
