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
	/// This object represents the properties and methods of a Cheque_Project.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_Project 
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
		private string _projectName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProjectName
		{
			[DebuggerStepThrough()]
			get { return this._projectName; }
			set 
			{
				if (this._projectName != value) 
				{
					this._projectName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _projectNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProjectNumber
		{
			[DebuggerStepThrough()]
			get { return this._projectNumber; }
			set 
			{
				if (this._projectNumber != value) 
				{
					this._projectNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectNumber");
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _projectCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProjectCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._projectCategoryID; }
			set 
			{
				if (this._projectCategoryID != value) 
				{
					this._projectCategoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectCategoryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _departmentID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int DepartmentID
		{
			[DebuggerStepThrough()]
			get { return this._departmentID; }
			set 
			{
				if (this._departmentID != value) 
				{
					this._departmentID = value;
					this.IsDirty = true;	
					OnPropertyChanged("DepartmentID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _departmentName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DepartmentName
		{
			[DebuggerStepThrough()]
			get { return this._departmentName; }
			set 
			{
				if (this._departmentName != value) 
				{
					this._departmentName = value;
					this.IsDirty = true;	
					OnPropertyChanged("DepartmentName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _managerName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ManagerName
		{
			[DebuggerStepThrough()]
			get { return this._managerName; }
			set 
			{
				if (this._managerName != value) 
				{
					this._managerName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ManagerName");
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
	[ProjectName] nvarchar(200),
	[ProjectNumber] nvarchar(200),
	[AddTime] datetime,
	[GUID] nvarchar(200),
	[ProjectCategoryID] int,
	[DepartmentID] int,
	[DepartmentName] nvarchar(200),
	[ManagerName] nvarchar(50)
);

INSERT INTO [dbo].[Cheque_Project] (
	[Cheque_Project].[ProjectName],
	[Cheque_Project].[ProjectNumber],
	[Cheque_Project].[AddTime],
	[Cheque_Project].[GUID],
	[Cheque_Project].[ProjectCategoryID],
	[Cheque_Project].[DepartmentID],
	[Cheque_Project].[DepartmentName],
	[Cheque_Project].[ManagerName]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectName],
	INSERTED.[ProjectNumber],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[ProjectCategoryID],
	INSERTED.[DepartmentID],
	INSERTED.[DepartmentName],
	INSERTED.[ManagerName]
into @table
VALUES ( 
	@ProjectName,
	@ProjectNumber,
	@AddTime,
	@GUID,
	@ProjectCategoryID,
	@DepartmentID,
	@DepartmentName,
	@ManagerName 
); 

SELECT 
	[ID],
	[ProjectName],
	[ProjectNumber],
	[AddTime],
	[GUID],
	[ProjectCategoryID],
	[DepartmentID],
	[DepartmentName],
	[ManagerName] 
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
	[ProjectName] nvarchar(200),
	[ProjectNumber] nvarchar(200),
	[AddTime] datetime,
	[GUID] nvarchar(200),
	[ProjectCategoryID] int,
	[DepartmentID] int,
	[DepartmentName] nvarchar(200),
	[ManagerName] nvarchar(50)
);

UPDATE [dbo].[Cheque_Project] SET 
	[Cheque_Project].[ProjectName] = @ProjectName,
	[Cheque_Project].[ProjectNumber] = @ProjectNumber,
	[Cheque_Project].[AddTime] = @AddTime,
	[Cheque_Project].[GUID] = @GUID,
	[Cheque_Project].[ProjectCategoryID] = @ProjectCategoryID,
	[Cheque_Project].[DepartmentID] = @DepartmentID,
	[Cheque_Project].[DepartmentName] = @DepartmentName,
	[Cheque_Project].[ManagerName] = @ManagerName 
output 
	INSERTED.[ID],
	INSERTED.[ProjectName],
	INSERTED.[ProjectNumber],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[ProjectCategoryID],
	INSERTED.[DepartmentID],
	INSERTED.[DepartmentName],
	INSERTED.[ManagerName]
into @table
WHERE 
	[Cheque_Project].[ID] = @ID

SELECT 
	[ID],
	[ProjectName],
	[ProjectNumber],
	[AddTime],
	[GUID],
	[ProjectCategoryID],
	[DepartmentID],
	[DepartmentName],
	[ManagerName] 
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
DELETE FROM [dbo].[Cheque_Project]
WHERE 
	[Cheque_Project].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_Project() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_Project(this.ID));
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
	[Cheque_Project].[ID],
	[Cheque_Project].[ProjectName],
	[Cheque_Project].[ProjectNumber],
	[Cheque_Project].[AddTime],
	[Cheque_Project].[GUID],
	[Cheque_Project].[ProjectCategoryID],
	[Cheque_Project].[DepartmentID],
	[Cheque_Project].[DepartmentName],
	[Cheque_Project].[ManagerName]
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
                return "Cheque_Project";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_Project into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectName">projectName</param>
		/// <param name="projectNumber">projectNumber</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="projectCategoryID">projectCategoryID</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="departmentName">departmentName</param>
		/// <param name="managerName">managerName</param>
		public static void InsertCheque_Project(string @projectName, string @projectNumber, DateTime @addTime, string @gUID, int @projectCategoryID, int @departmentID, string @departmentName, string @managerName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_Project(@projectName, @projectNumber, @addTime, @gUID, @projectCategoryID, @departmentID, @departmentName, @managerName, helper);
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
		/// Insert a Cheque_Project into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectName">projectName</param>
		/// <param name="projectNumber">projectNumber</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="projectCategoryID">projectCategoryID</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="departmentName">departmentName</param>
		/// <param name="managerName">managerName</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_Project(string @projectName, string @projectNumber, DateTime @addTime, string @gUID, int @projectCategoryID, int @departmentID, string @departmentName, string @managerName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectName] nvarchar(200),
	[ProjectNumber] nvarchar(200),
	[AddTime] datetime,
	[GUID] nvarchar(200),
	[ProjectCategoryID] int,
	[DepartmentID] int,
	[DepartmentName] nvarchar(200),
	[ManagerName] nvarchar(50)
);

INSERT INTO [dbo].[Cheque_Project] (
	[Cheque_Project].[ProjectName],
	[Cheque_Project].[ProjectNumber],
	[Cheque_Project].[AddTime],
	[Cheque_Project].[GUID],
	[Cheque_Project].[ProjectCategoryID],
	[Cheque_Project].[DepartmentID],
	[Cheque_Project].[DepartmentName],
	[Cheque_Project].[ManagerName]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectName],
	INSERTED.[ProjectNumber],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[ProjectCategoryID],
	INSERTED.[DepartmentID],
	INSERTED.[DepartmentName],
	INSERTED.[ManagerName]
into @table
VALUES ( 
	@ProjectName,
	@ProjectNumber,
	@AddTime,
	@GUID,
	@ProjectCategoryID,
	@DepartmentID,
	@DepartmentName,
	@ManagerName 
); 

SELECT 
	[ID],
	[ProjectName],
	[ProjectNumber],
	[AddTime],
	[GUID],
	[ProjectCategoryID],
	[DepartmentID],
	[DepartmentName],
	[ManagerName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectName", EntityBase.GetDatabaseValue(@projectName)));
			parameters.Add(new SqlParameter("@ProjectNumber", EntityBase.GetDatabaseValue(@projectNumber)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@ProjectCategoryID", EntityBase.GetDatabaseValue(@projectCategoryID)));
			parameters.Add(new SqlParameter("@DepartmentID", EntityBase.GetDatabaseValue(@departmentID)));
			parameters.Add(new SqlParameter("@DepartmentName", EntityBase.GetDatabaseValue(@departmentName)));
			parameters.Add(new SqlParameter("@ManagerName", EntityBase.GetDatabaseValue(@managerName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_Project into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectName">projectName</param>
		/// <param name="projectNumber">projectNumber</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="projectCategoryID">projectCategoryID</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="departmentName">departmentName</param>
		/// <param name="managerName">managerName</param>
		public static void UpdateCheque_Project(int @iD, string @projectName, string @projectNumber, DateTime @addTime, string @gUID, int @projectCategoryID, int @departmentID, string @departmentName, string @managerName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_Project(@iD, @projectName, @projectNumber, @addTime, @gUID, @projectCategoryID, @departmentID, @departmentName, @managerName, helper);
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
		/// Updates a Cheque_Project into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectName">projectName</param>
		/// <param name="projectNumber">projectNumber</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="projectCategoryID">projectCategoryID</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="departmentName">departmentName</param>
		/// <param name="managerName">managerName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_Project(int @iD, string @projectName, string @projectNumber, DateTime @addTime, string @gUID, int @projectCategoryID, int @departmentID, string @departmentName, string @managerName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectName] nvarchar(200),
	[ProjectNumber] nvarchar(200),
	[AddTime] datetime,
	[GUID] nvarchar(200),
	[ProjectCategoryID] int,
	[DepartmentID] int,
	[DepartmentName] nvarchar(200),
	[ManagerName] nvarchar(50)
);

UPDATE [dbo].[Cheque_Project] SET 
	[Cheque_Project].[ProjectName] = @ProjectName,
	[Cheque_Project].[ProjectNumber] = @ProjectNumber,
	[Cheque_Project].[AddTime] = @AddTime,
	[Cheque_Project].[GUID] = @GUID,
	[Cheque_Project].[ProjectCategoryID] = @ProjectCategoryID,
	[Cheque_Project].[DepartmentID] = @DepartmentID,
	[Cheque_Project].[DepartmentName] = @DepartmentName,
	[Cheque_Project].[ManagerName] = @ManagerName 
output 
	INSERTED.[ID],
	INSERTED.[ProjectName],
	INSERTED.[ProjectNumber],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[ProjectCategoryID],
	INSERTED.[DepartmentID],
	INSERTED.[DepartmentName],
	INSERTED.[ManagerName]
into @table
WHERE 
	[Cheque_Project].[ID] = @ID

SELECT 
	[ID],
	[ProjectName],
	[ProjectNumber],
	[AddTime],
	[GUID],
	[ProjectCategoryID],
	[DepartmentID],
	[DepartmentName],
	[ManagerName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProjectName", EntityBase.GetDatabaseValue(@projectName)));
			parameters.Add(new SqlParameter("@ProjectNumber", EntityBase.GetDatabaseValue(@projectNumber)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@ProjectCategoryID", EntityBase.GetDatabaseValue(@projectCategoryID)));
			parameters.Add(new SqlParameter("@DepartmentID", EntityBase.GetDatabaseValue(@departmentID)));
			parameters.Add(new SqlParameter("@DepartmentName", EntityBase.GetDatabaseValue(@departmentName)));
			parameters.Add(new SqlParameter("@ManagerName", EntityBase.GetDatabaseValue(@managerName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_Project from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_Project(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_Project(@iD, helper);
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
		/// Deletes a Cheque_Project from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_Project(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_Project]
WHERE 
	[Cheque_Project].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_Project object.
		/// </summary>
		/// <returns>The newly created Cheque_Project object.</returns>
		public static Cheque_Project CreateCheque_Project()
		{
			return InitializeNew<Cheque_Project>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_Project by a Cheque_Project's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_Project</returns>
		public static Cheque_Project GetCheque_Project(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_Project.SelectFieldList + @"
FROM [dbo].[Cheque_Project] 
WHERE 
	[Cheque_Project].[ID] = @ID " + Cheque_Project.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_Project>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_Project by a Cheque_Project's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_Project</returns>
		public static Cheque_Project GetCheque_Project(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_Project.SelectFieldList + @"
FROM [dbo].[Cheque_Project] 
WHERE 
	[Cheque_Project].[ID] = @ID " + Cheque_Project.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_Project>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Project objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_Project objects.</returns>
		public static EntityList<Cheque_Project> GetCheque_Projects()
		{
			string commandText = @"
SELECT " + Cheque_Project.SelectFieldList + "FROM [dbo].[Cheque_Project] " + Cheque_Project.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_Project>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_Project objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_Project objects.</returns>
        public static EntityList<Cheque_Project> GetCheque_Projects(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Project>(SelectFieldList, "FROM [dbo].[Cheque_Project]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_Project objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_Project objects.</returns>
        public static EntityList<Cheque_Project> GetCheque_Projects(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Project>(SelectFieldList, "FROM [dbo].[Cheque_Project]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_Project objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_Project objects.</returns>
		protected static EntityList<Cheque_Project> GetCheque_Projects(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Projects(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Project objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Project objects.</returns>
		protected static EntityList<Cheque_Project> GetCheque_Projects(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Projects(string.Empty, where, parameters, Cheque_Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Project objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Project objects.</returns>
		protected static EntityList<Cheque_Project> GetCheque_Projects(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Projects(prefix, where, parameters, Cheque_Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Project objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Project objects.</returns>
		protected static EntityList<Cheque_Project> GetCheque_Projects(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_Projects(string.Empty, where, parameters, Cheque_Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Project objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Project objects.</returns>
		protected static EntityList<Cheque_Project> GetCheque_Projects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_Projects(prefix, where, parameters, Cheque_Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Project objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_Project objects.</returns>
		protected static EntityList<Cheque_Project> GetCheque_Projects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_Project.SelectFieldList + "FROM [dbo].[Cheque_Project] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_Project>(reader);
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
        protected static EntityList<Cheque_Project> GetCheque_Projects(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Project>(SelectFieldList, "FROM [dbo].[Cheque_Project] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_Project objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_ProjectCount()
        {
            return GetCheque_ProjectCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_Project objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_ProjectCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_Project] " + where;

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
		public static partial class Cheque_Project_Properties
		{
			public const string ID = "ID";
			public const string ProjectName = "ProjectName";
			public const string ProjectNumber = "ProjectNumber";
			public const string AddTime = "AddTime";
			public const string GUID = "GUID";
			public const string ProjectCategoryID = "ProjectCategoryID";
			public const string DepartmentID = "DepartmentID";
			public const string DepartmentName = "DepartmentName";
			public const string ManagerName = "ManagerName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProjectName" , "string:"},
    			 {"ProjectNumber" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"GUID" , "string:"},
    			 {"ProjectCategoryID" , "int:"},
    			 {"DepartmentID" , "int:"},
    			 {"DepartmentName" , "string:"},
    			 {"ManagerName" , "string:"},
            };
		}
		#endregion
	}
}
