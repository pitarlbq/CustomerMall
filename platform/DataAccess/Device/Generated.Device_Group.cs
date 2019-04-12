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
	/// This object represents the properties and methods of a Device_Group.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Device_Group 
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
		private string _deviceGroupName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DeviceGroupName
		{
			[DebuggerStepThrough()]
			get { return this._deviceGroupName; }
			set 
			{
				if (this._deviceGroupName != value) 
				{
					this._deviceGroupName = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeviceGroupName");
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
		private int _repairUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RepairUserID
		{
			[DebuggerStepThrough()]
			get { return this._repairUserID; }
			set 
			{
				if (this._repairUserID != value) 
				{
					this._repairUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RepairUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _checkUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CheckUserID
		{
			[DebuggerStepThrough()]
			get { return this._checkUserID; }
			set 
			{
				if (this._checkUserID != value) 
				{
					this._checkUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CheckUserID");
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
	[DeviceGroupName] nvarchar(200),
	[AddTime] datetime,
	[Code] nvarchar(100),
	[RepairUserID] int,
	[CheckUserID] int,
	[Description] ntext
);

INSERT INTO [dbo].[Device_Group] (
	[Device_Group].[DeviceGroupName],
	[Device_Group].[AddTime],
	[Device_Group].[Code],
	[Device_Group].[RepairUserID],
	[Device_Group].[CheckUserID],
	[Device_Group].[Description]
) 
output 
	INSERTED.[ID],
	INSERTED.[DeviceGroupName],
	INSERTED.[AddTime],
	INSERTED.[Code],
	INSERTED.[RepairUserID],
	INSERTED.[CheckUserID],
	INSERTED.[Description]
into @table
VALUES ( 
	@DeviceGroupName,
	@AddTime,
	@Code,
	@RepairUserID,
	@CheckUserID,
	@Description 
); 

SELECT 
	[ID],
	[DeviceGroupName],
	[AddTime],
	[Code],
	[RepairUserID],
	[CheckUserID],
	[Description] 
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
	[DeviceGroupName] nvarchar(200),
	[AddTime] datetime,
	[Code] nvarchar(100),
	[RepairUserID] int,
	[CheckUserID] int,
	[Description] ntext
);

UPDATE [dbo].[Device_Group] SET 
	[Device_Group].[DeviceGroupName] = @DeviceGroupName,
	[Device_Group].[AddTime] = @AddTime,
	[Device_Group].[Code] = @Code,
	[Device_Group].[RepairUserID] = @RepairUserID,
	[Device_Group].[CheckUserID] = @CheckUserID,
	[Device_Group].[Description] = @Description 
output 
	INSERTED.[ID],
	INSERTED.[DeviceGroupName],
	INSERTED.[AddTime],
	INSERTED.[Code],
	INSERTED.[RepairUserID],
	INSERTED.[CheckUserID],
	INSERTED.[Description]
into @table
WHERE 
	[Device_Group].[ID] = @ID

SELECT 
	[ID],
	[DeviceGroupName],
	[AddTime],
	[Code],
	[RepairUserID],
	[CheckUserID],
	[Description] 
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
DELETE FROM [dbo].[Device_Group]
WHERE 
	[Device_Group].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Device_Group() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetDevice_Group(this.ID));
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
	[Device_Group].[ID],
	[Device_Group].[DeviceGroupName],
	[Device_Group].[AddTime],
	[Device_Group].[Code],
	[Device_Group].[RepairUserID],
	[Device_Group].[CheckUserID],
	[Device_Group].[Description]
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
                return "Device_Group";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Device_Group into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="deviceGroupName">deviceGroupName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="code">code</param>
		/// <param name="repairUserID">repairUserID</param>
		/// <param name="checkUserID">checkUserID</param>
		/// <param name="description">description</param>
		public static void InsertDevice_Group(string @deviceGroupName, DateTime @addTime, string @code, int @repairUserID, int @checkUserID, string @description)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertDevice_Group(@deviceGroupName, @addTime, @code, @repairUserID, @checkUserID, @description, helper);
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
		/// Insert a Device_Group into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="deviceGroupName">deviceGroupName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="code">code</param>
		/// <param name="repairUserID">repairUserID</param>
		/// <param name="checkUserID">checkUserID</param>
		/// <param name="description">description</param>
		/// <param name="helper">helper</param>
		internal static void InsertDevice_Group(string @deviceGroupName, DateTime @addTime, string @code, int @repairUserID, int @checkUserID, string @description, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DeviceGroupName] nvarchar(200),
	[AddTime] datetime,
	[Code] nvarchar(100),
	[RepairUserID] int,
	[CheckUserID] int,
	[Description] ntext
);

INSERT INTO [dbo].[Device_Group] (
	[Device_Group].[DeviceGroupName],
	[Device_Group].[AddTime],
	[Device_Group].[Code],
	[Device_Group].[RepairUserID],
	[Device_Group].[CheckUserID],
	[Device_Group].[Description]
) 
output 
	INSERTED.[ID],
	INSERTED.[DeviceGroupName],
	INSERTED.[AddTime],
	INSERTED.[Code],
	INSERTED.[RepairUserID],
	INSERTED.[CheckUserID],
	INSERTED.[Description]
into @table
VALUES ( 
	@DeviceGroupName,
	@AddTime,
	@Code,
	@RepairUserID,
	@CheckUserID,
	@Description 
); 

SELECT 
	[ID],
	[DeviceGroupName],
	[AddTime],
	[Code],
	[RepairUserID],
	[CheckUserID],
	[Description] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DeviceGroupName", EntityBase.GetDatabaseValue(@deviceGroupName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Code", EntityBase.GetDatabaseValue(@code)));
			parameters.Add(new SqlParameter("@RepairUserID", EntityBase.GetDatabaseValue(@repairUserID)));
			parameters.Add(new SqlParameter("@CheckUserID", EntityBase.GetDatabaseValue(@checkUserID)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Device_Group into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="deviceGroupName">deviceGroupName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="code">code</param>
		/// <param name="repairUserID">repairUserID</param>
		/// <param name="checkUserID">checkUserID</param>
		/// <param name="description">description</param>
		public static void UpdateDevice_Group(int @iD, string @deviceGroupName, DateTime @addTime, string @code, int @repairUserID, int @checkUserID, string @description)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateDevice_Group(@iD, @deviceGroupName, @addTime, @code, @repairUserID, @checkUserID, @description, helper);
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
		/// Updates a Device_Group into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="deviceGroupName">deviceGroupName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="code">code</param>
		/// <param name="repairUserID">repairUserID</param>
		/// <param name="checkUserID">checkUserID</param>
		/// <param name="description">description</param>
		/// <param name="helper">helper</param>
		internal static void UpdateDevice_Group(int @iD, string @deviceGroupName, DateTime @addTime, string @code, int @repairUserID, int @checkUserID, string @description, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DeviceGroupName] nvarchar(200),
	[AddTime] datetime,
	[Code] nvarchar(100),
	[RepairUserID] int,
	[CheckUserID] int,
	[Description] ntext
);

UPDATE [dbo].[Device_Group] SET 
	[Device_Group].[DeviceGroupName] = @DeviceGroupName,
	[Device_Group].[AddTime] = @AddTime,
	[Device_Group].[Code] = @Code,
	[Device_Group].[RepairUserID] = @RepairUserID,
	[Device_Group].[CheckUserID] = @CheckUserID,
	[Device_Group].[Description] = @Description 
output 
	INSERTED.[ID],
	INSERTED.[DeviceGroupName],
	INSERTED.[AddTime],
	INSERTED.[Code],
	INSERTED.[RepairUserID],
	INSERTED.[CheckUserID],
	INSERTED.[Description]
into @table
WHERE 
	[Device_Group].[ID] = @ID

SELECT 
	[ID],
	[DeviceGroupName],
	[AddTime],
	[Code],
	[RepairUserID],
	[CheckUserID],
	[Description] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@DeviceGroupName", EntityBase.GetDatabaseValue(@deviceGroupName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Code", EntityBase.GetDatabaseValue(@code)));
			parameters.Add(new SqlParameter("@RepairUserID", EntityBase.GetDatabaseValue(@repairUserID)));
			parameters.Add(new SqlParameter("@CheckUserID", EntityBase.GetDatabaseValue(@checkUserID)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Device_Group from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteDevice_Group(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteDevice_Group(@iD, helper);
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
		/// Deletes a Device_Group from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteDevice_Group(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Device_Group]
WHERE 
	[Device_Group].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Device_Group object.
		/// </summary>
		/// <returns>The newly created Device_Group object.</returns>
		public static Device_Group CreateDevice_Group()
		{
			return InitializeNew<Device_Group>();
		}
		
		/// <summary>
		/// Retrieve information for a Device_Group by a Device_Group's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Device_Group</returns>
		public static Device_Group GetDevice_Group(int @iD)
		{
			string commandText = @"
SELECT 
" + Device_Group.SelectFieldList + @"
FROM [dbo].[Device_Group] 
WHERE 
	[Device_Group].[ID] = @ID " + Device_Group.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Device_Group>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Device_Group by a Device_Group's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Device_Group</returns>
		public static Device_Group GetDevice_Group(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Device_Group.SelectFieldList + @"
FROM [dbo].[Device_Group] 
WHERE 
	[Device_Group].[ID] = @ID " + Device_Group.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Device_Group>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Device_Group objects.
		/// </summary>
		/// <returns>The retrieved collection of Device_Group objects.</returns>
		public static EntityList<Device_Group> GetDevice_Groups()
		{
			string commandText = @"
SELECT " + Device_Group.SelectFieldList + "FROM [dbo].[Device_Group] " + Device_Group.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Device_Group>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Device_Group objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Device_Group objects.</returns>
        public static EntityList<Device_Group> GetDevice_Groups(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Device_Group>(SelectFieldList, "FROM [dbo].[Device_Group]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Device_Group objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Device_Group objects.</returns>
        public static EntityList<Device_Group> GetDevice_Groups(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Device_Group>(SelectFieldList, "FROM [dbo].[Device_Group]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Device_Group objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Device_Group objects.</returns>
		protected static EntityList<Device_Group> GetDevice_Groups(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDevice_Groups(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Device_Group objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Device_Group objects.</returns>
		protected static EntityList<Device_Group> GetDevice_Groups(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDevice_Groups(string.Empty, where, parameters, Device_Group.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_Group objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Device_Group objects.</returns>
		protected static EntityList<Device_Group> GetDevice_Groups(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDevice_Groups(prefix, where, parameters, Device_Group.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_Group objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Device_Group objects.</returns>
		protected static EntityList<Device_Group> GetDevice_Groups(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetDevice_Groups(string.Empty, where, parameters, Device_Group.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_Group objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Device_Group objects.</returns>
		protected static EntityList<Device_Group> GetDevice_Groups(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetDevice_Groups(prefix, where, parameters, Device_Group.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Device_Group objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Device_Group objects.</returns>
		protected static EntityList<Device_Group> GetDevice_Groups(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Device_Group.SelectFieldList + "FROM [dbo].[Device_Group] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Device_Group>(reader);
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
        protected static EntityList<Device_Group> GetDevice_Groups(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Device_Group>(SelectFieldList, "FROM [dbo].[Device_Group] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Device_Group objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetDevice_GroupCount()
        {
            return GetDevice_GroupCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Device_Group objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetDevice_GroupCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Device_Group] " + where;

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
		public static partial class Device_Group_Properties
		{
			public const string ID = "ID";
			public const string DeviceGroupName = "DeviceGroupName";
			public const string AddTime = "AddTime";
			public const string Code = "Code";
			public const string RepairUserID = "RepairUserID";
			public const string CheckUserID = "CheckUserID";
			public const string Description = "Description";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"DeviceGroupName" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"Code" , "string:"},
    			 {"RepairUserID" , "int:"},
    			 {"CheckUserID" , "int:"},
    			 {"Description" , "string:"},
            };
		}
		#endregion
	}
}
