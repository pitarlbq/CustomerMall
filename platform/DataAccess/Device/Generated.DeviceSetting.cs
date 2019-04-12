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
	/// This object represents the properties and methods of a DeviceSetting.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class DeviceSetting 
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
		private string _title = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Title
		{
			[DebuggerStepThrough()]
			get { return this._title; }
			set 
			{
				if (this._title != value) 
				{
					this._title = value;
					this.IsDirty = true;	
					OnPropertyChanged("Title");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _moduleCode = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ModuleCode
		{
			[DebuggerStepThrough()]
			get { return this._moduleCode; }
			set 
			{
				if (this._moduleCode != value) 
				{
					this._moduleCode = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModuleCode");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _parameters1 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Parameters1
		{
			[DebuggerStepThrough()]
			get { return this._parameters1; }
			set 
			{
				if (this._parameters1 != value) 
				{
					this._parameters1 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Parameters1");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _parameters2 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Parameters2
		{
			[DebuggerStepThrough()]
			get { return this._parameters2; }
			set 
			{
				if (this._parameters2 != value) 
				{
					this._parameters2 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Parameters2");
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
		private string _parameters3 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Parameters3
		{
			[DebuggerStepThrough()]
			get { return this._parameters3; }
			set 
			{
				if (this._parameters3 != value) 
				{
					this._parameters3 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Parameters3");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isShow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsShow
		{
			[DebuggerStepThrough()]
			get { return this._isShow; }
			set 
			{
				if (this._isShow != value) 
				{
					this._isShow = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsShow");
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
	[Title] nvarchar(50),
	[ModuleCode] nvarchar(50),
	[Parameters1] nvarchar(50),
	[Parameters2] nvarchar(50),
	[AddTime] datetime,
	[Parameters3] ntext,
	[IsShow] bit
);

INSERT INTO [dbo].[DeviceSetting] (
	[DeviceSetting].[Title],
	[DeviceSetting].[ModuleCode],
	[DeviceSetting].[Parameters1],
	[DeviceSetting].[Parameters2],
	[DeviceSetting].[AddTime],
	[DeviceSetting].[Parameters3],
	[DeviceSetting].[IsShow]
) 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[ModuleCode],
	INSERTED.[Parameters1],
	INSERTED.[Parameters2],
	INSERTED.[AddTime],
	INSERTED.[Parameters3],
	INSERTED.[IsShow]
into @table
VALUES ( 
	@Title,
	@ModuleCode,
	@Parameters1,
	@Parameters2,
	@AddTime,
	@Parameters3,
	@IsShow 
); 

SELECT 
	[ID],
	[Title],
	[ModuleCode],
	[Parameters1],
	[Parameters2],
	[AddTime],
	[Parameters3],
	[IsShow] 
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
	[Title] nvarchar(50),
	[ModuleCode] nvarchar(50),
	[Parameters1] nvarchar(50),
	[Parameters2] nvarchar(50),
	[AddTime] datetime,
	[Parameters3] ntext,
	[IsShow] bit
);

UPDATE [dbo].[DeviceSetting] SET 
	[DeviceSetting].[Title] = @Title,
	[DeviceSetting].[ModuleCode] = @ModuleCode,
	[DeviceSetting].[Parameters1] = @Parameters1,
	[DeviceSetting].[Parameters2] = @Parameters2,
	[DeviceSetting].[AddTime] = @AddTime,
	[DeviceSetting].[Parameters3] = @Parameters3,
	[DeviceSetting].[IsShow] = @IsShow 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[ModuleCode],
	INSERTED.[Parameters1],
	INSERTED.[Parameters2],
	INSERTED.[AddTime],
	INSERTED.[Parameters3],
	INSERTED.[IsShow]
into @table
WHERE 
	[DeviceSetting].[ID] = @ID

SELECT 
	[ID],
	[Title],
	[ModuleCode],
	[Parameters1],
	[Parameters2],
	[AddTime],
	[Parameters3],
	[IsShow] 
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
DELETE FROM [dbo].[DeviceSetting]
WHERE 
	[DeviceSetting].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public DeviceSetting() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetDeviceSetting(this.ID));
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
	[DeviceSetting].[ID],
	[DeviceSetting].[Title],
	[DeviceSetting].[ModuleCode],
	[DeviceSetting].[Parameters1],
	[DeviceSetting].[Parameters2],
	[DeviceSetting].[AddTime],
	[DeviceSetting].[Parameters3],
	[DeviceSetting].[IsShow]
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
                return "DeviceSetting";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a DeviceSetting into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="title">title</param>
		/// <param name="moduleCode">moduleCode</param>
		/// <param name="parameters1">parameters1</param>
		/// <param name="parameters2">parameters2</param>
		/// <param name="addTime">addTime</param>
		/// <param name="parameters3">parameters3</param>
		/// <param name="isShow">isShow</param>
		public static void InsertDeviceSetting(string @title, string @moduleCode, string @parameters1, string @parameters2, DateTime @addTime, string @parameters3, bool @isShow)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertDeviceSetting(@title, @moduleCode, @parameters1, @parameters2, @addTime, @parameters3, @isShow, helper);
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
		/// Insert a DeviceSetting into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="title">title</param>
		/// <param name="moduleCode">moduleCode</param>
		/// <param name="parameters1">parameters1</param>
		/// <param name="parameters2">parameters2</param>
		/// <param name="addTime">addTime</param>
		/// <param name="parameters3">parameters3</param>
		/// <param name="isShow">isShow</param>
		/// <param name="helper">helper</param>
		internal static void InsertDeviceSetting(string @title, string @moduleCode, string @parameters1, string @parameters2, DateTime @addTime, string @parameters3, bool @isShow, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Title] nvarchar(50),
	[ModuleCode] nvarchar(50),
	[Parameters1] nvarchar(50),
	[Parameters2] nvarchar(50),
	[AddTime] datetime,
	[Parameters3] ntext,
	[IsShow] bit
);

INSERT INTO [dbo].[DeviceSetting] (
	[DeviceSetting].[Title],
	[DeviceSetting].[ModuleCode],
	[DeviceSetting].[Parameters1],
	[DeviceSetting].[Parameters2],
	[DeviceSetting].[AddTime],
	[DeviceSetting].[Parameters3],
	[DeviceSetting].[IsShow]
) 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[ModuleCode],
	INSERTED.[Parameters1],
	INSERTED.[Parameters2],
	INSERTED.[AddTime],
	INSERTED.[Parameters3],
	INSERTED.[IsShow]
into @table
VALUES ( 
	@Title,
	@ModuleCode,
	@Parameters1,
	@Parameters2,
	@AddTime,
	@Parameters3,
	@IsShow 
); 

SELECT 
	[ID],
	[Title],
	[ModuleCode],
	[Parameters1],
	[Parameters2],
	[AddTime],
	[Parameters3],
	[IsShow] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@ModuleCode", EntityBase.GetDatabaseValue(@moduleCode)));
			parameters.Add(new SqlParameter("@Parameters1", EntityBase.GetDatabaseValue(@parameters1)));
			parameters.Add(new SqlParameter("@Parameters2", EntityBase.GetDatabaseValue(@parameters2)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Parameters3", EntityBase.GetDatabaseValue(@parameters3)));
			parameters.Add(new SqlParameter("@IsShow", @isShow));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a DeviceSetting into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="title">title</param>
		/// <param name="moduleCode">moduleCode</param>
		/// <param name="parameters1">parameters1</param>
		/// <param name="parameters2">parameters2</param>
		/// <param name="addTime">addTime</param>
		/// <param name="parameters3">parameters3</param>
		/// <param name="isShow">isShow</param>
		public static void UpdateDeviceSetting(int @iD, string @title, string @moduleCode, string @parameters1, string @parameters2, DateTime @addTime, string @parameters3, bool @isShow)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateDeviceSetting(@iD, @title, @moduleCode, @parameters1, @parameters2, @addTime, @parameters3, @isShow, helper);
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
		/// Updates a DeviceSetting into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="title">title</param>
		/// <param name="moduleCode">moduleCode</param>
		/// <param name="parameters1">parameters1</param>
		/// <param name="parameters2">parameters2</param>
		/// <param name="addTime">addTime</param>
		/// <param name="parameters3">parameters3</param>
		/// <param name="isShow">isShow</param>
		/// <param name="helper">helper</param>
		internal static void UpdateDeviceSetting(int @iD, string @title, string @moduleCode, string @parameters1, string @parameters2, DateTime @addTime, string @parameters3, bool @isShow, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Title] nvarchar(50),
	[ModuleCode] nvarchar(50),
	[Parameters1] nvarchar(50),
	[Parameters2] nvarchar(50),
	[AddTime] datetime,
	[Parameters3] ntext,
	[IsShow] bit
);

UPDATE [dbo].[DeviceSetting] SET 
	[DeviceSetting].[Title] = @Title,
	[DeviceSetting].[ModuleCode] = @ModuleCode,
	[DeviceSetting].[Parameters1] = @Parameters1,
	[DeviceSetting].[Parameters2] = @Parameters2,
	[DeviceSetting].[AddTime] = @AddTime,
	[DeviceSetting].[Parameters3] = @Parameters3,
	[DeviceSetting].[IsShow] = @IsShow 
output 
	INSERTED.[ID],
	INSERTED.[Title],
	INSERTED.[ModuleCode],
	INSERTED.[Parameters1],
	INSERTED.[Parameters2],
	INSERTED.[AddTime],
	INSERTED.[Parameters3],
	INSERTED.[IsShow]
into @table
WHERE 
	[DeviceSetting].[ID] = @ID

SELECT 
	[ID],
	[Title],
	[ModuleCode],
	[Parameters1],
	[Parameters2],
	[AddTime],
	[Parameters3],
	[IsShow] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@ModuleCode", EntityBase.GetDatabaseValue(@moduleCode)));
			parameters.Add(new SqlParameter("@Parameters1", EntityBase.GetDatabaseValue(@parameters1)));
			parameters.Add(new SqlParameter("@Parameters2", EntityBase.GetDatabaseValue(@parameters2)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Parameters3", EntityBase.GetDatabaseValue(@parameters3)));
			parameters.Add(new SqlParameter("@IsShow", @isShow));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a DeviceSetting from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteDeviceSetting(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteDeviceSetting(@iD, helper);
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
		/// Deletes a DeviceSetting from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteDeviceSetting(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[DeviceSetting]
WHERE 
	[DeviceSetting].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new DeviceSetting object.
		/// </summary>
		/// <returns>The newly created DeviceSetting object.</returns>
		public static DeviceSetting CreateDeviceSetting()
		{
			return InitializeNew<DeviceSetting>();
		}
		
		/// <summary>
		/// Retrieve information for a DeviceSetting by a DeviceSetting's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>DeviceSetting</returns>
		public static DeviceSetting GetDeviceSetting(int @iD)
		{
			string commandText = @"
SELECT 
" + DeviceSetting.SelectFieldList + @"
FROM [dbo].[DeviceSetting] 
WHERE 
	[DeviceSetting].[ID] = @ID " + DeviceSetting.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<DeviceSetting>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a DeviceSetting by a DeviceSetting's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>DeviceSetting</returns>
		public static DeviceSetting GetDeviceSetting(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + DeviceSetting.SelectFieldList + @"
FROM [dbo].[DeviceSetting] 
WHERE 
	[DeviceSetting].[ID] = @ID " + DeviceSetting.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<DeviceSetting>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection DeviceSetting objects.
		/// </summary>
		/// <returns>The retrieved collection of DeviceSetting objects.</returns>
		public static EntityList<DeviceSetting> GetDeviceSettings()
		{
			string commandText = @"
SELECT " + DeviceSetting.SelectFieldList + "FROM [dbo].[DeviceSetting] " + DeviceSetting.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<DeviceSetting>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection DeviceSetting objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of DeviceSetting objects.</returns>
        public static EntityList<DeviceSetting> GetDeviceSettings(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<DeviceSetting>(SelectFieldList, "FROM [dbo].[DeviceSetting]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection DeviceSetting objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of DeviceSetting objects.</returns>
        public static EntityList<DeviceSetting> GetDeviceSettings(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<DeviceSetting>(SelectFieldList, "FROM [dbo].[DeviceSetting]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection DeviceSetting objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of DeviceSetting objects.</returns>
		protected static EntityList<DeviceSetting> GetDeviceSettings(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDeviceSettings(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection DeviceSetting objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of DeviceSetting objects.</returns>
		protected static EntityList<DeviceSetting> GetDeviceSettings(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDeviceSettings(string.Empty, where, parameters, DeviceSetting.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection DeviceSetting objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of DeviceSetting objects.</returns>
		protected static EntityList<DeviceSetting> GetDeviceSettings(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDeviceSettings(prefix, where, parameters, DeviceSetting.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection DeviceSetting objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of DeviceSetting objects.</returns>
		protected static EntityList<DeviceSetting> GetDeviceSettings(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetDeviceSettings(string.Empty, where, parameters, DeviceSetting.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection DeviceSetting objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of DeviceSetting objects.</returns>
		protected static EntityList<DeviceSetting> GetDeviceSettings(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetDeviceSettings(prefix, where, parameters, DeviceSetting.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection DeviceSetting objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of DeviceSetting objects.</returns>
		protected static EntityList<DeviceSetting> GetDeviceSettings(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + DeviceSetting.SelectFieldList + "FROM [dbo].[DeviceSetting] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<DeviceSetting>(reader);
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
        protected static EntityList<DeviceSetting> GetDeviceSettings(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<DeviceSetting>(SelectFieldList, "FROM [dbo].[DeviceSetting] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of DeviceSetting objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetDeviceSettingCount()
        {
            return GetDeviceSettingCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of DeviceSetting objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetDeviceSettingCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[DeviceSetting] " + where;

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
		public static partial class DeviceSetting_Properties
		{
			public const string ID = "ID";
			public const string Title = "Title";
			public const string ModuleCode = "ModuleCode";
			public const string Parameters1 = "Parameters1";
			public const string Parameters2 = "Parameters2";
			public const string AddTime = "AddTime";
			public const string Parameters3 = "Parameters3";
			public const string IsShow = "IsShow";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Title" , "string:"},
    			 {"ModuleCode" , "string:"},
    			 {"Parameters1" , "string:"},
    			 {"Parameters2" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"Parameters3" , "string:"},
    			 {"IsShow" , "bool:"},
            };
		}
		#endregion
	}
}
