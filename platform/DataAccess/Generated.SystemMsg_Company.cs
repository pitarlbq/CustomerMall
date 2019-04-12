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
	/// This object represents the properties and methods of a SystemMsg_Company.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class SystemMsg_Company 
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
		private int _systemMsgID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int SystemMsgID
		{
			[DebuggerStepThrough()]
			get { return this._systemMsgID; }
			set 
			{
				if (this._systemMsgID != value) 
				{
					this._systemMsgID = value;
					this.IsDirty = true;	
					OnPropertyChanged("SystemMsgID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _companyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int CompanyID
		{
			[DebuggerStepThrough()]
			get { return this._companyID; }
			set 
			{
				if (this._companyID != value) 
				{
					this._companyID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CompanyID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isReading = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsReading
		{
			[DebuggerStepThrough()]
			get { return this._isReading; }
			set 
			{
				if (this._isReading != value) 
				{
					this._isReading = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsReading");
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
		private DateTime _readingTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ReadingTime
		{
			[DebuggerStepThrough()]
			get { return this._readingTime; }
			set 
			{
				if (this._readingTime != value) 
				{
					this._readingTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ReadingTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDeleting = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDeleting
		{
			[DebuggerStepThrough()]
			get { return this._isDeleting; }
			set 
			{
				if (this._isDeleting != value) 
				{
					this._isDeleting = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDeleting");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _deleteTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime DeleteTime
		{
			[DebuggerStepThrough()]
			get { return this._deleteTime; }
			set 
			{
				if (this._deleteTime != value) 
				{
					this._deleteTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeleteTime");
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
	[SystemMsgID] int,
	[CompanyID] int,
	[IsReading] bit,
	[AddTime] datetime,
	[ReadingTime] datetime,
	[IsDeleting] bit,
	[DeleteTime] datetime
);

INSERT INTO [dbo].[SystemMsg_Company] (
	[SystemMsg_Company].[SystemMsgID],
	[SystemMsg_Company].[CompanyID],
	[SystemMsg_Company].[IsReading],
	[SystemMsg_Company].[AddTime],
	[SystemMsg_Company].[ReadingTime],
	[SystemMsg_Company].[IsDeleting],
	[SystemMsg_Company].[DeleteTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[SystemMsgID],
	INSERTED.[CompanyID],
	INSERTED.[IsReading],
	INSERTED.[AddTime],
	INSERTED.[ReadingTime],
	INSERTED.[IsDeleting],
	INSERTED.[DeleteTime]
into @table
VALUES ( 
	@SystemMsgID,
	@CompanyID,
	@IsReading,
	@AddTime,
	@ReadingTime,
	@IsDeleting,
	@DeleteTime 
); 

SELECT 
	[ID],
	[SystemMsgID],
	[CompanyID],
	[IsReading],
	[AddTime],
	[ReadingTime],
	[IsDeleting],
	[DeleteTime] 
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
	[SystemMsgID] int,
	[CompanyID] int,
	[IsReading] bit,
	[AddTime] datetime,
	[ReadingTime] datetime,
	[IsDeleting] bit,
	[DeleteTime] datetime
);

UPDATE [dbo].[SystemMsg_Company] SET 
	[SystemMsg_Company].[SystemMsgID] = @SystemMsgID,
	[SystemMsg_Company].[CompanyID] = @CompanyID,
	[SystemMsg_Company].[IsReading] = @IsReading,
	[SystemMsg_Company].[AddTime] = @AddTime,
	[SystemMsg_Company].[ReadingTime] = @ReadingTime,
	[SystemMsg_Company].[IsDeleting] = @IsDeleting,
	[SystemMsg_Company].[DeleteTime] = @DeleteTime 
output 
	INSERTED.[ID],
	INSERTED.[SystemMsgID],
	INSERTED.[CompanyID],
	INSERTED.[IsReading],
	INSERTED.[AddTime],
	INSERTED.[ReadingTime],
	INSERTED.[IsDeleting],
	INSERTED.[DeleteTime]
into @table
WHERE 
	[SystemMsg_Company].[ID] = @ID

SELECT 
	[ID],
	[SystemMsgID],
	[CompanyID],
	[IsReading],
	[AddTime],
	[ReadingTime],
	[IsDeleting],
	[DeleteTime] 
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
DELETE FROM [dbo].[SystemMsg_Company]
WHERE 
	[SystemMsg_Company].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public SystemMsg_Company() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetSystemMsg_Company(this.ID));
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
	[SystemMsg_Company].[ID],
	[SystemMsg_Company].[SystemMsgID],
	[SystemMsg_Company].[CompanyID],
	[SystemMsg_Company].[IsReading],
	[SystemMsg_Company].[AddTime],
	[SystemMsg_Company].[ReadingTime],
	[SystemMsg_Company].[IsDeleting],
	[SystemMsg_Company].[DeleteTime]
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
                return "SystemMsg_Company";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a SystemMsg_Company into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="systemMsgID">systemMsgID</param>
		/// <param name="companyID">companyID</param>
		/// <param name="isReading">isReading</param>
		/// <param name="addTime">addTime</param>
		/// <param name="readingTime">readingTime</param>
		/// <param name="isDeleting">isDeleting</param>
		/// <param name="deleteTime">deleteTime</param>
		public static void InsertSystemMsg_Company(int @systemMsgID, int @companyID, bool @isReading, DateTime @addTime, DateTime @readingTime, bool @isDeleting, DateTime @deleteTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertSystemMsg_Company(@systemMsgID, @companyID, @isReading, @addTime, @readingTime, @isDeleting, @deleteTime, helper);
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
		/// Insert a SystemMsg_Company into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="systemMsgID">systemMsgID</param>
		/// <param name="companyID">companyID</param>
		/// <param name="isReading">isReading</param>
		/// <param name="addTime">addTime</param>
		/// <param name="readingTime">readingTime</param>
		/// <param name="isDeleting">isDeleting</param>
		/// <param name="deleteTime">deleteTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertSystemMsg_Company(int @systemMsgID, int @companyID, bool @isReading, DateTime @addTime, DateTime @readingTime, bool @isDeleting, DateTime @deleteTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SystemMsgID] int,
	[CompanyID] int,
	[IsReading] bit,
	[AddTime] datetime,
	[ReadingTime] datetime,
	[IsDeleting] bit,
	[DeleteTime] datetime
);

INSERT INTO [dbo].[SystemMsg_Company] (
	[SystemMsg_Company].[SystemMsgID],
	[SystemMsg_Company].[CompanyID],
	[SystemMsg_Company].[IsReading],
	[SystemMsg_Company].[AddTime],
	[SystemMsg_Company].[ReadingTime],
	[SystemMsg_Company].[IsDeleting],
	[SystemMsg_Company].[DeleteTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[SystemMsgID],
	INSERTED.[CompanyID],
	INSERTED.[IsReading],
	INSERTED.[AddTime],
	INSERTED.[ReadingTime],
	INSERTED.[IsDeleting],
	INSERTED.[DeleteTime]
into @table
VALUES ( 
	@SystemMsgID,
	@CompanyID,
	@IsReading,
	@AddTime,
	@ReadingTime,
	@IsDeleting,
	@DeleteTime 
); 

SELECT 
	[ID],
	[SystemMsgID],
	[CompanyID],
	[IsReading],
	[AddTime],
	[ReadingTime],
	[IsDeleting],
	[DeleteTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@SystemMsgID", EntityBase.GetDatabaseValue(@systemMsgID)));
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			parameters.Add(new SqlParameter("@IsReading", @isReading));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ReadingTime", EntityBase.GetDatabaseValue(@readingTime)));
			parameters.Add(new SqlParameter("@IsDeleting", @isDeleting));
			parameters.Add(new SqlParameter("@DeleteTime", EntityBase.GetDatabaseValue(@deleteTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a SystemMsg_Company into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="systemMsgID">systemMsgID</param>
		/// <param name="companyID">companyID</param>
		/// <param name="isReading">isReading</param>
		/// <param name="addTime">addTime</param>
		/// <param name="readingTime">readingTime</param>
		/// <param name="isDeleting">isDeleting</param>
		/// <param name="deleteTime">deleteTime</param>
		public static void UpdateSystemMsg_Company(int @iD, int @systemMsgID, int @companyID, bool @isReading, DateTime @addTime, DateTime @readingTime, bool @isDeleting, DateTime @deleteTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateSystemMsg_Company(@iD, @systemMsgID, @companyID, @isReading, @addTime, @readingTime, @isDeleting, @deleteTime, helper);
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
		/// Updates a SystemMsg_Company into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="systemMsgID">systemMsgID</param>
		/// <param name="companyID">companyID</param>
		/// <param name="isReading">isReading</param>
		/// <param name="addTime">addTime</param>
		/// <param name="readingTime">readingTime</param>
		/// <param name="isDeleting">isDeleting</param>
		/// <param name="deleteTime">deleteTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateSystemMsg_Company(int @iD, int @systemMsgID, int @companyID, bool @isReading, DateTime @addTime, DateTime @readingTime, bool @isDeleting, DateTime @deleteTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SystemMsgID] int,
	[CompanyID] int,
	[IsReading] bit,
	[AddTime] datetime,
	[ReadingTime] datetime,
	[IsDeleting] bit,
	[DeleteTime] datetime
);

UPDATE [dbo].[SystemMsg_Company] SET 
	[SystemMsg_Company].[SystemMsgID] = @SystemMsgID,
	[SystemMsg_Company].[CompanyID] = @CompanyID,
	[SystemMsg_Company].[IsReading] = @IsReading,
	[SystemMsg_Company].[AddTime] = @AddTime,
	[SystemMsg_Company].[ReadingTime] = @ReadingTime,
	[SystemMsg_Company].[IsDeleting] = @IsDeleting,
	[SystemMsg_Company].[DeleteTime] = @DeleteTime 
output 
	INSERTED.[ID],
	INSERTED.[SystemMsgID],
	INSERTED.[CompanyID],
	INSERTED.[IsReading],
	INSERTED.[AddTime],
	INSERTED.[ReadingTime],
	INSERTED.[IsDeleting],
	INSERTED.[DeleteTime]
into @table
WHERE 
	[SystemMsg_Company].[ID] = @ID

SELECT 
	[ID],
	[SystemMsgID],
	[CompanyID],
	[IsReading],
	[AddTime],
	[ReadingTime],
	[IsDeleting],
	[DeleteTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@SystemMsgID", EntityBase.GetDatabaseValue(@systemMsgID)));
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			parameters.Add(new SqlParameter("@IsReading", @isReading));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ReadingTime", EntityBase.GetDatabaseValue(@readingTime)));
			parameters.Add(new SqlParameter("@IsDeleting", @isDeleting));
			parameters.Add(new SqlParameter("@DeleteTime", EntityBase.GetDatabaseValue(@deleteTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a SystemMsg_Company from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteSystemMsg_Company(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteSystemMsg_Company(@iD, helper);
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
		/// Deletes a SystemMsg_Company from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteSystemMsg_Company(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[SystemMsg_Company]
WHERE 
	[SystemMsg_Company].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new SystemMsg_Company object.
		/// </summary>
		/// <returns>The newly created SystemMsg_Company object.</returns>
		public static SystemMsg_Company CreateSystemMsg_Company()
		{
			return InitializeNew<SystemMsg_Company>();
		}
		
		/// <summary>
		/// Retrieve information for a SystemMsg_Company by a SystemMsg_Company's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>SystemMsg_Company</returns>
		public static SystemMsg_Company GetSystemMsg_Company(int @iD)
		{
			string commandText = @"
SELECT 
" + SystemMsg_Company.SelectFieldList + @"
FROM [dbo].[SystemMsg_Company] 
WHERE 
	[SystemMsg_Company].[ID] = @ID " + SystemMsg_Company.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<SystemMsg_Company>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a SystemMsg_Company by a SystemMsg_Company's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>SystemMsg_Company</returns>
		public static SystemMsg_Company GetSystemMsg_Company(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + SystemMsg_Company.SelectFieldList + @"
FROM [dbo].[SystemMsg_Company] 
WHERE 
	[SystemMsg_Company].[ID] = @ID " + SystemMsg_Company.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<SystemMsg_Company>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection SystemMsg_Company objects.
		/// </summary>
		/// <returns>The retrieved collection of SystemMsg_Company objects.</returns>
		public static EntityList<SystemMsg_Company> GetSystemMsg_Companies()
		{
			string commandText = @"
SELECT " + SystemMsg_Company.SelectFieldList + "FROM [dbo].[SystemMsg_Company] " + SystemMsg_Company.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<SystemMsg_Company>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection SystemMsg_Company objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of SystemMsg_Company objects.</returns>
        public static EntityList<SystemMsg_Company> GetSystemMsg_Companies(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SystemMsg_Company>(SelectFieldList, "FROM [dbo].[SystemMsg_Company]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection SystemMsg_Company objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of SystemMsg_Company objects.</returns>
        public static EntityList<SystemMsg_Company> GetSystemMsg_Companies(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SystemMsg_Company>(SelectFieldList, "FROM [dbo].[SystemMsg_Company]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection SystemMsg_Company objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of SystemMsg_Company objects.</returns>
		protected static EntityList<SystemMsg_Company> GetSystemMsg_Companies(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSystemMsg_Companies(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection SystemMsg_Company objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of SystemMsg_Company objects.</returns>
		protected static EntityList<SystemMsg_Company> GetSystemMsg_Companies(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSystemMsg_Companies(string.Empty, where, parameters, SystemMsg_Company.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SystemMsg_Company objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of SystemMsg_Company objects.</returns>
		protected static EntityList<SystemMsg_Company> GetSystemMsg_Companies(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSystemMsg_Companies(prefix, where, parameters, SystemMsg_Company.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SystemMsg_Company objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of SystemMsg_Company objects.</returns>
		protected static EntityList<SystemMsg_Company> GetSystemMsg_Companies(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSystemMsg_Companies(string.Empty, where, parameters, SystemMsg_Company.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SystemMsg_Company objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of SystemMsg_Company objects.</returns>
		protected static EntityList<SystemMsg_Company> GetSystemMsg_Companies(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSystemMsg_Companies(prefix, where, parameters, SystemMsg_Company.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SystemMsg_Company objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of SystemMsg_Company objects.</returns>
		protected static EntityList<SystemMsg_Company> GetSystemMsg_Companies(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + SystemMsg_Company.SelectFieldList + "FROM [dbo].[SystemMsg_Company] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<SystemMsg_Company>(reader);
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
        protected static EntityList<SystemMsg_Company> GetSystemMsg_Companies(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SystemMsg_Company>(SelectFieldList, "FROM [dbo].[SystemMsg_Company] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of SystemMsg_Company objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSystemMsg_CompanyCount()
        {
            return GetSystemMsg_CompanyCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of SystemMsg_Company objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSystemMsg_CompanyCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[SystemMsg_Company] " + where;

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
		public static partial class SystemMsg_Company_Properties
		{
			public const string ID = "ID";
			public const string SystemMsgID = "SystemMsgID";
			public const string CompanyID = "CompanyID";
			public const string IsReading = "IsReading";
			public const string AddTime = "AddTime";
			public const string ReadingTime = "ReadingTime";
			public const string IsDeleting = "IsDeleting";
			public const string DeleteTime = "DeleteTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"SystemMsgID" , "int:"},
    			 {"CompanyID" , "int:"},
    			 {"IsReading" , "bool:"},
    			 {"AddTime" , "DateTime:"},
    			 {"ReadingTime" , "DateTime:"},
    			 {"IsDeleting" , "bool:"},
    			 {"DeleteTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
