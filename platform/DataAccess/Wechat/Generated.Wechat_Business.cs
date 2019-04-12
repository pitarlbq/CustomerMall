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
	/// This object represents the properties and methods of a Wechat_Business.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_Business 
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
		private string _businessName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BusinessName
		{
			[DebuggerStepThrough()]
			get { return this._businessName; }
			set 
			{
				if (this._businessName != value) 
				{
					this._businessName = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _businessSummary = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BusinessSummary
		{
			[DebuggerStepThrough()]
			get { return this._businessSummary; }
			set 
			{
				if (this._businessSummary != value) 
				{
					this._businessSummary = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessSummary");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _businessImg = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BusinessImg
		{
			[DebuggerStepThrough()]
			get { return this._businessImg; }
			set 
			{
				if (this._businessImg != value) 
				{
					this._businessImg = value;
					this.IsDirty = true;	
					OnPropertyChanged("BusinessImg");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _phoneNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PhoneNumber
		{
			[DebuggerStepThrough()]
			get { return this._phoneNumber; }
			set 
			{
				if (this._phoneNumber != value) 
				{
					this._phoneNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("PhoneNumber");
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
		private bool _isPublish = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsPublish
		{
			[DebuggerStepThrough()]
			get { return this._isPublish; }
			set 
			{
				if (this._isPublish != value) 
				{
					this._isPublish = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsPublish");
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
	[BusinessName] nvarchar(200),
	[BusinessSummary] ntext,
	[BusinessImg] nvarchar(500),
	[PhoneNumber] nvarchar(200),
	[AddTime] datetime,
	[IsPublish] bit
);

INSERT INTO [dbo].[Wechat_Business] (
	[Wechat_Business].[BusinessName],
	[Wechat_Business].[BusinessSummary],
	[Wechat_Business].[BusinessImg],
	[Wechat_Business].[PhoneNumber],
	[Wechat_Business].[AddTime],
	[Wechat_Business].[IsPublish]
) 
output 
	INSERTED.[ID],
	INSERTED.[BusinessName],
	INSERTED.[BusinessSummary],
	INSERTED.[BusinessImg],
	INSERTED.[PhoneNumber],
	INSERTED.[AddTime],
	INSERTED.[IsPublish]
into @table
VALUES ( 
	@BusinessName,
	@BusinessSummary,
	@BusinessImg,
	@PhoneNumber,
	@AddTime,
	@IsPublish 
); 

SELECT 
	[ID],
	[BusinessName],
	[BusinessSummary],
	[BusinessImg],
	[PhoneNumber],
	[AddTime],
	[IsPublish] 
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
	[BusinessName] nvarchar(200),
	[BusinessSummary] ntext,
	[BusinessImg] nvarchar(500),
	[PhoneNumber] nvarchar(200),
	[AddTime] datetime,
	[IsPublish] bit
);

UPDATE [dbo].[Wechat_Business] SET 
	[Wechat_Business].[BusinessName] = @BusinessName,
	[Wechat_Business].[BusinessSummary] = @BusinessSummary,
	[Wechat_Business].[BusinessImg] = @BusinessImg,
	[Wechat_Business].[PhoneNumber] = @PhoneNumber,
	[Wechat_Business].[AddTime] = @AddTime,
	[Wechat_Business].[IsPublish] = @IsPublish 
output 
	INSERTED.[ID],
	INSERTED.[BusinessName],
	INSERTED.[BusinessSummary],
	INSERTED.[BusinessImg],
	INSERTED.[PhoneNumber],
	INSERTED.[AddTime],
	INSERTED.[IsPublish]
into @table
WHERE 
	[Wechat_Business].[ID] = @ID

SELECT 
	[ID],
	[BusinessName],
	[BusinessSummary],
	[BusinessImg],
	[PhoneNumber],
	[AddTime],
	[IsPublish] 
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
DELETE FROM [dbo].[Wechat_Business]
WHERE 
	[Wechat_Business].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_Business() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_Business(this.ID));
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
	[Wechat_Business].[ID],
	[Wechat_Business].[BusinessName],
	[Wechat_Business].[BusinessSummary],
	[Wechat_Business].[BusinessImg],
	[Wechat_Business].[PhoneNumber],
	[Wechat_Business].[AddTime],
	[Wechat_Business].[IsPublish]
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
                return "Wechat_Business";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_Business into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="businessName">businessName</param>
		/// <param name="businessSummary">businessSummary</param>
		/// <param name="businessImg">businessImg</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isPublish">isPublish</param>
		public static void InsertWechat_Business(string @businessName, string @businessSummary, string @businessImg, string @phoneNumber, DateTime @addTime, bool @isPublish)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_Business(@businessName, @businessSummary, @businessImg, @phoneNumber, @addTime, @isPublish, helper);
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
		/// Insert a Wechat_Business into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="businessName">businessName</param>
		/// <param name="businessSummary">businessSummary</param>
		/// <param name="businessImg">businessImg</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isPublish">isPublish</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_Business(string @businessName, string @businessSummary, string @businessImg, string @phoneNumber, DateTime @addTime, bool @isPublish, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BusinessName] nvarchar(200),
	[BusinessSummary] ntext,
	[BusinessImg] nvarchar(500),
	[PhoneNumber] nvarchar(200),
	[AddTime] datetime,
	[IsPublish] bit
);

INSERT INTO [dbo].[Wechat_Business] (
	[Wechat_Business].[BusinessName],
	[Wechat_Business].[BusinessSummary],
	[Wechat_Business].[BusinessImg],
	[Wechat_Business].[PhoneNumber],
	[Wechat_Business].[AddTime],
	[Wechat_Business].[IsPublish]
) 
output 
	INSERTED.[ID],
	INSERTED.[BusinessName],
	INSERTED.[BusinessSummary],
	INSERTED.[BusinessImg],
	INSERTED.[PhoneNumber],
	INSERTED.[AddTime],
	INSERTED.[IsPublish]
into @table
VALUES ( 
	@BusinessName,
	@BusinessSummary,
	@BusinessImg,
	@PhoneNumber,
	@AddTime,
	@IsPublish 
); 

SELECT 
	[ID],
	[BusinessName],
	[BusinessSummary],
	[BusinessImg],
	[PhoneNumber],
	[AddTime],
	[IsPublish] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@BusinessName", EntityBase.GetDatabaseValue(@businessName)));
			parameters.Add(new SqlParameter("@BusinessSummary", EntityBase.GetDatabaseValue(@businessSummary)));
			parameters.Add(new SqlParameter("@BusinessImg", EntityBase.GetDatabaseValue(@businessImg)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@IsPublish", @isPublish));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_Business into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="businessName">businessName</param>
		/// <param name="businessSummary">businessSummary</param>
		/// <param name="businessImg">businessImg</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isPublish">isPublish</param>
		public static void UpdateWechat_Business(int @iD, string @businessName, string @businessSummary, string @businessImg, string @phoneNumber, DateTime @addTime, bool @isPublish)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_Business(@iD, @businessName, @businessSummary, @businessImg, @phoneNumber, @addTime, @isPublish, helper);
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
		/// Updates a Wechat_Business into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="businessName">businessName</param>
		/// <param name="businessSummary">businessSummary</param>
		/// <param name="businessImg">businessImg</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isPublish">isPublish</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_Business(int @iD, string @businessName, string @businessSummary, string @businessImg, string @phoneNumber, DateTime @addTime, bool @isPublish, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[BusinessName] nvarchar(200),
	[BusinessSummary] ntext,
	[BusinessImg] nvarchar(500),
	[PhoneNumber] nvarchar(200),
	[AddTime] datetime,
	[IsPublish] bit
);

UPDATE [dbo].[Wechat_Business] SET 
	[Wechat_Business].[BusinessName] = @BusinessName,
	[Wechat_Business].[BusinessSummary] = @BusinessSummary,
	[Wechat_Business].[BusinessImg] = @BusinessImg,
	[Wechat_Business].[PhoneNumber] = @PhoneNumber,
	[Wechat_Business].[AddTime] = @AddTime,
	[Wechat_Business].[IsPublish] = @IsPublish 
output 
	INSERTED.[ID],
	INSERTED.[BusinessName],
	INSERTED.[BusinessSummary],
	INSERTED.[BusinessImg],
	INSERTED.[PhoneNumber],
	INSERTED.[AddTime],
	INSERTED.[IsPublish]
into @table
WHERE 
	[Wechat_Business].[ID] = @ID

SELECT 
	[ID],
	[BusinessName],
	[BusinessSummary],
	[BusinessImg],
	[PhoneNumber],
	[AddTime],
	[IsPublish] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@BusinessName", EntityBase.GetDatabaseValue(@businessName)));
			parameters.Add(new SqlParameter("@BusinessSummary", EntityBase.GetDatabaseValue(@businessSummary)));
			parameters.Add(new SqlParameter("@BusinessImg", EntityBase.GetDatabaseValue(@businessImg)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@IsPublish", @isPublish));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_Business from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_Business(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_Business(@iD, helper);
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
		/// Deletes a Wechat_Business from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_Business(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_Business]
WHERE 
	[Wechat_Business].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_Business object.
		/// </summary>
		/// <returns>The newly created Wechat_Business object.</returns>
		public static Wechat_Business CreateWechat_Business()
		{
			return InitializeNew<Wechat_Business>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_Business by a Wechat_Business's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_Business</returns>
		public static Wechat_Business GetWechat_Business(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_Business.SelectFieldList + @"
FROM [dbo].[Wechat_Business] 
WHERE 
	[Wechat_Business].[ID] = @ID " + Wechat_Business.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_Business>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_Business by a Wechat_Business's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_Business</returns>
		public static Wechat_Business GetWechat_Business(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_Business.SelectFieldList + @"
FROM [dbo].[Wechat_Business] 
WHERE 
	[Wechat_Business].[ID] = @ID " + Wechat_Business.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_Business>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Business objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_Business objects.</returns>
		public static EntityList<Wechat_Business> GetWechat_Businesses()
		{
			string commandText = @"
SELECT " + Wechat_Business.SelectFieldList + "FROM [dbo].[Wechat_Business] " + Wechat_Business.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_Business>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_Business objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_Business objects.</returns>
        public static EntityList<Wechat_Business> GetWechat_Businesses(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Business>(SelectFieldList, "FROM [dbo].[Wechat_Business]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_Business objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_Business objects.</returns>
        public static EntityList<Wechat_Business> GetWechat_Businesses(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Business>(SelectFieldList, "FROM [dbo].[Wechat_Business]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_Business objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_Business objects.</returns>
		protected static EntityList<Wechat_Business> GetWechat_Businesses(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Businesses(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Business objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Business objects.</returns>
		protected static EntityList<Wechat_Business> GetWechat_Businesses(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Businesses(string.Empty, where, parameters, Wechat_Business.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Business objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Business objects.</returns>
		protected static EntityList<Wechat_Business> GetWechat_Businesses(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Businesses(prefix, where, parameters, Wechat_Business.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Business objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Business objects.</returns>
		protected static EntityList<Wechat_Business> GetWechat_Businesses(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_Businesses(string.Empty, where, parameters, Wechat_Business.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Business objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Business objects.</returns>
		protected static EntityList<Wechat_Business> GetWechat_Businesses(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_Businesses(prefix, where, parameters, Wechat_Business.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Business objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_Business objects.</returns>
		protected static EntityList<Wechat_Business> GetWechat_Businesses(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_Business.SelectFieldList + "FROM [dbo].[Wechat_Business] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_Business>(reader);
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
        protected static EntityList<Wechat_Business> GetWechat_Businesses(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Business>(SelectFieldList, "FROM [dbo].[Wechat_Business] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_Business objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_BusinessCount()
        {
            return GetWechat_BusinessCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_Business objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_BusinessCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_Business] " + where;

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
		public static partial class Wechat_Business_Properties
		{
			public const string ID = "ID";
			public const string BusinessName = "BusinessName";
			public const string BusinessSummary = "BusinessSummary";
			public const string BusinessImg = "BusinessImg";
			public const string PhoneNumber = "PhoneNumber";
			public const string AddTime = "AddTime";
			public const string IsPublish = "IsPublish";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"BusinessName" , "string:"},
    			 {"BusinessSummary" , "string:"},
    			 {"BusinessImg" , "string:"},
    			 {"PhoneNumber" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"IsPublish" , "bool:"},
            };
		}
		#endregion
	}
}
