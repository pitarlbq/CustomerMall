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
	/// This object represents the properties and methods of a Device_Type.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Device_Type 
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
		private string _deviceTypeName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DeviceTypeName
		{
			[DebuggerStepThrough()]
			get { return this._deviceTypeName; }
			set 
			{
				if (this._deviceTypeName != value) 
				{
					this._deviceTypeName = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeviceTypeName");
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
		private int _parentID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ParentID
		{
			[DebuggerStepThrough()]
			get { return this._parentID; }
			set 
			{
				if (this._parentID != value) 
				{
					this._parentID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ParentID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _description = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Description
		{
			[DebuggerStepThrough()]
			get { return this._description; }
			set 
			{
				if (this._description != value) 
				{
					this._description = value;
					this.IsDirty = true;	
					OnPropertyChanged("Description");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _code = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Code
		{
			[DebuggerStepThrough()]
			get { return this._code; }
			set 
			{
				if (this._code != value) 
				{
					this._code = value;
					this.IsDirty = true;	
					OnPropertyChanged("Code");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _typeLevel = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TypeLevel
		{
			[DebuggerStepThrough()]
			get { return this._typeLevel; }
			set 
			{
				if (this._typeLevel != value) 
				{
					this._typeLevel = value;
					this.IsDirty = true;	
					OnPropertyChanged("TypeLevel");
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
	[DeviceTypeName] nvarchar(200),
	[AddTime] datetime,
	[ParentID] int,
	[Description] ntext,
	[Code] nvarchar(100),
	[TypeLevel] int
);

INSERT INTO [dbo].[Device_Type] (
	[Device_Type].[DeviceTypeName],
	[Device_Type].[AddTime],
	[Device_Type].[ParentID],
	[Device_Type].[Description],
	[Device_Type].[Code],
	[Device_Type].[TypeLevel]
) 
output 
	INSERTED.[ID],
	INSERTED.[DeviceTypeName],
	INSERTED.[AddTime],
	INSERTED.[ParentID],
	INSERTED.[Description],
	INSERTED.[Code],
	INSERTED.[TypeLevel]
into @table
VALUES ( 
	@DeviceTypeName,
	@AddTime,
	@ParentID,
	@Description,
	@Code,
	@TypeLevel 
); 

SELECT 
	[ID],
	[DeviceTypeName],
	[AddTime],
	[ParentID],
	[Description],
	[Code],
	[TypeLevel] 
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
	[DeviceTypeName] nvarchar(200),
	[AddTime] datetime,
	[ParentID] int,
	[Description] ntext,
	[Code] nvarchar(100),
	[TypeLevel] int
);

UPDATE [dbo].[Device_Type] SET 
	[Device_Type].[DeviceTypeName] = @DeviceTypeName,
	[Device_Type].[AddTime] = @AddTime,
	[Device_Type].[ParentID] = @ParentID,
	[Device_Type].[Description] = @Description,
	[Device_Type].[Code] = @Code,
	[Device_Type].[TypeLevel] = @TypeLevel 
output 
	INSERTED.[ID],
	INSERTED.[DeviceTypeName],
	INSERTED.[AddTime],
	INSERTED.[ParentID],
	INSERTED.[Description],
	INSERTED.[Code],
	INSERTED.[TypeLevel]
into @table
WHERE 
	[Device_Type].[ID] = @ID

SELECT 
	[ID],
	[DeviceTypeName],
	[AddTime],
	[ParentID],
	[Description],
	[Code],
	[TypeLevel] 
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
DELETE FROM [dbo].[Device_Type]
WHERE 
	[Device_Type].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Device_Type() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetDevice_Type(this.ID));
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
	[Device_Type].[ID],
	[Device_Type].[DeviceTypeName],
	[Device_Type].[AddTime],
	[Device_Type].[ParentID],
	[Device_Type].[Description],
	[Device_Type].[Code],
	[Device_Type].[TypeLevel]
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
                return "Device_Type";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Device_Type into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="deviceTypeName">deviceTypeName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="parentID">parentID</param>
		/// <param name="description">description</param>
		/// <param name="code">code</param>
		/// <param name="typeLevel">typeLevel</param>
		public static void InsertDevice_Type(string @deviceTypeName, DateTime @addTime, int @parentID, string @description, string @code, int @typeLevel)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertDevice_Type(@deviceTypeName, @addTime, @parentID, @description, @code, @typeLevel, helper);
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
		/// Insert a Device_Type into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="deviceTypeName">deviceTypeName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="parentID">parentID</param>
		/// <param name="description">description</param>
		/// <param name="code">code</param>
		/// <param name="typeLevel">typeLevel</param>
		/// <param name="helper">helper</param>
		internal static void InsertDevice_Type(string @deviceTypeName, DateTime @addTime, int @parentID, string @description, string @code, int @typeLevel, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DeviceTypeName] nvarchar(200),
	[AddTime] datetime,
	[ParentID] int,
	[Description] ntext,
	[Code] nvarchar(100),
	[TypeLevel] int
);

INSERT INTO [dbo].[Device_Type] (
	[Device_Type].[DeviceTypeName],
	[Device_Type].[AddTime],
	[Device_Type].[ParentID],
	[Device_Type].[Description],
	[Device_Type].[Code],
	[Device_Type].[TypeLevel]
) 
output 
	INSERTED.[ID],
	INSERTED.[DeviceTypeName],
	INSERTED.[AddTime],
	INSERTED.[ParentID],
	INSERTED.[Description],
	INSERTED.[Code],
	INSERTED.[TypeLevel]
into @table
VALUES ( 
	@DeviceTypeName,
	@AddTime,
	@ParentID,
	@Description,
	@Code,
	@TypeLevel 
); 

SELECT 
	[ID],
	[DeviceTypeName],
	[AddTime],
	[ParentID],
	[Description],
	[Code],
	[TypeLevel] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DeviceTypeName", EntityBase.GetDatabaseValue(@deviceTypeName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@Code", EntityBase.GetDatabaseValue(@code)));
			parameters.Add(new SqlParameter("@TypeLevel", EntityBase.GetDatabaseValue(@typeLevel)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Device_Type into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="deviceTypeName">deviceTypeName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="parentID">parentID</param>
		/// <param name="description">description</param>
		/// <param name="code">code</param>
		/// <param name="typeLevel">typeLevel</param>
		public static void UpdateDevice_Type(int @iD, string @deviceTypeName, DateTime @addTime, int @parentID, string @description, string @code, int @typeLevel)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateDevice_Type(@iD, @deviceTypeName, @addTime, @parentID, @description, @code, @typeLevel, helper);
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
		/// Updates a Device_Type into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="deviceTypeName">deviceTypeName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="parentID">parentID</param>
		/// <param name="description">description</param>
		/// <param name="code">code</param>
		/// <param name="typeLevel">typeLevel</param>
		/// <param name="helper">helper</param>
		internal static void UpdateDevice_Type(int @iD, string @deviceTypeName, DateTime @addTime, int @parentID, string @description, string @code, int @typeLevel, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DeviceTypeName] nvarchar(200),
	[AddTime] datetime,
	[ParentID] int,
	[Description] ntext,
	[Code] nvarchar(100),
	[TypeLevel] int
);

UPDATE [dbo].[Device_Type] SET 
	[Device_Type].[DeviceTypeName] = @DeviceTypeName,
	[Device_Type].[AddTime] = @AddTime,
	[Device_Type].[ParentID] = @ParentID,
	[Device_Type].[Description] = @Description,
	[Device_Type].[Code] = @Code,
	[Device_Type].[TypeLevel] = @TypeLevel 
output 
	INSERTED.[ID],
	INSERTED.[DeviceTypeName],
	INSERTED.[AddTime],
	INSERTED.[ParentID],
	INSERTED.[Description],
	INSERTED.[Code],
	INSERTED.[TypeLevel]
into @table
WHERE 
	[Device_Type].[ID] = @ID

SELECT 
	[ID],
	[DeviceTypeName],
	[AddTime],
	[ParentID],
	[Description],
	[Code],
	[TypeLevel] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@DeviceTypeName", EntityBase.GetDatabaseValue(@deviceTypeName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@Code", EntityBase.GetDatabaseValue(@code)));
			parameters.Add(new SqlParameter("@TypeLevel", EntityBase.GetDatabaseValue(@typeLevel)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Device_Type from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteDevice_Type(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteDevice_Type(@iD, helper);
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
		/// Deletes a Device_Type from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteDevice_Type(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Device_Type]
WHERE 
	[Device_Type].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Device_Type object.
		/// </summary>
		/// <returns>The newly created Device_Type object.</returns>
		public static Device_Type CreateDevice_Type()
		{
			return InitializeNew<Device_Type>();
		}
		
		/// <summary>
		/// Retrieve information for a Device_Type by a Device_Type's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Device_Type</returns>
		public static Device_Type GetDevice_Type(int @iD)
		{
			string commandText = @"
SELECT 
" + Device_Type.SelectFieldList + @"
FROM [dbo].[Device_Type] 
WHERE 
	[Device_Type].[ID] = @ID " + Device_Type.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Device_Type>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Device_Type by a Device_Type's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Device_Type</returns>
		public static Device_Type GetDevice_Type(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Device_Type.SelectFieldList + @"
FROM [dbo].[Device_Type] 
WHERE 
	[Device_Type].[ID] = @ID " + Device_Type.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Device_Type>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Device_Type objects.
		/// </summary>
		/// <returns>The retrieved collection of Device_Type objects.</returns>
		public static EntityList<Device_Type> GetDevice_Types()
		{
			string commandText = @"
SELECT " + Device_Type.SelectFieldList + "FROM [dbo].[Device_Type] " + Device_Type.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Device_Type>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Device_Type objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Device_Type objects.</returns>
        public static EntityList<Device_Type> GetDevice_Types(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Device_Type>(SelectFieldList, "FROM [dbo].[Device_Type]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Device_Type objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Device_Type objects.</returns>
        public static EntityList<Device_Type> GetDevice_Types(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Device_Type>(SelectFieldList, "FROM [dbo].[Device_Type]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Device_Type objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Device_Type objects.</returns>
		protected static EntityList<Device_Type> GetDevice_Types(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDevice_Types(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Device_Type objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Device_Type objects.</returns>
		protected static EntityList<Device_Type> GetDevice_Types(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDevice_Types(string.Empty, where, parameters, Device_Type.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_Type objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Device_Type objects.</returns>
		protected static EntityList<Device_Type> GetDevice_Types(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDevice_Types(prefix, where, parameters, Device_Type.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_Type objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Device_Type objects.</returns>
		protected static EntityList<Device_Type> GetDevice_Types(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetDevice_Types(string.Empty, where, parameters, Device_Type.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_Type objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Device_Type objects.</returns>
		protected static EntityList<Device_Type> GetDevice_Types(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetDevice_Types(prefix, where, parameters, Device_Type.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_Type objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Device_Type objects.</returns>
		protected static EntityList<Device_Type> GetDevice_Types(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Device_Type.SelectFieldList + "FROM [dbo].[Device_Type] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Device_Type>(reader);
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
        protected static EntityList<Device_Type> GetDevice_Types(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Device_Type>(SelectFieldList, "FROM [dbo].[Device_Type] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Device_Type objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetDevice_TypeCount()
        {
            return GetDevice_TypeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Device_Type objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetDevice_TypeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Device_Type] " + where;

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
		public static partial class Device_Type_Properties
		{
			public const string ID = "ID";
			public const string DeviceTypeName = "DeviceTypeName";
			public const string AddTime = "AddTime";
			public const string ParentID = "ParentID";
			public const string Description = "Description";
			public const string Code = "Code";
			public const string TypeLevel = "TypeLevel";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"DeviceTypeName" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"ParentID" , "int:"},
    			 {"Description" , "string:"},
    			 {"Code" , "string:"},
    			 {"TypeLevel" , "int:"},
            };
		}
		#endregion
	}
}
