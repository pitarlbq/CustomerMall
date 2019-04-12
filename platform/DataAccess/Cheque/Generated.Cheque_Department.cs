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
	/// This object represents the properties and methods of a Cheque_Department.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_Department 
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
		private string _departmentNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DepartmentNumber
		{
			[DebuggerStepThrough()]
			get { return this._departmentNumber; }
			set 
			{
				if (this._departmentNumber != value) 
				{
					this._departmentNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("DepartmentNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _departmentInChargeMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DepartmentInChargeMan
		{
			[DebuggerStepThrough()]
			get { return this._departmentInChargeMan; }
			set 
			{
				if (this._departmentInChargeMan != value) 
				{
					this._departmentInChargeMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("DepartmentInChargeMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _departmentCategoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int DepartmentCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._departmentCategoryID; }
			set 
			{
				if (this._departmentCategoryID != value) 
				{
					this._departmentCategoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("DepartmentCategoryID");
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
	[DepartmentName] nvarchar(200),
	[Description] ntext,
	[AddTime] datetime,
	[GUID] nvarchar(200),
	[DepartmentNumber] nvarchar(200),
	[DepartmentInChargeMan] nvarchar(50),
	[DepartmentCategoryID] int
);

INSERT INTO [dbo].[Cheque_Department] (
	[Cheque_Department].[DepartmentName],
	[Cheque_Department].[Description],
	[Cheque_Department].[AddTime],
	[Cheque_Department].[GUID],
	[Cheque_Department].[DepartmentNumber],
	[Cheque_Department].[DepartmentInChargeMan],
	[Cheque_Department].[DepartmentCategoryID]
) 
output 
	INSERTED.[ID],
	INSERTED.[DepartmentName],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[DepartmentNumber],
	INSERTED.[DepartmentInChargeMan],
	INSERTED.[DepartmentCategoryID]
into @table
VALUES ( 
	@DepartmentName,
	@Description,
	@AddTime,
	@GUID,
	@DepartmentNumber,
	@DepartmentInChargeMan,
	@DepartmentCategoryID 
); 

SELECT 
	[ID],
	[DepartmentName],
	[Description],
	[AddTime],
	[GUID],
	[DepartmentNumber],
	[DepartmentInChargeMan],
	[DepartmentCategoryID] 
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
	[DepartmentName] nvarchar(200),
	[Description] ntext,
	[AddTime] datetime,
	[GUID] nvarchar(200),
	[DepartmentNumber] nvarchar(200),
	[DepartmentInChargeMan] nvarchar(50),
	[DepartmentCategoryID] int
);

UPDATE [dbo].[Cheque_Department] SET 
	[Cheque_Department].[DepartmentName] = @DepartmentName,
	[Cheque_Department].[Description] = @Description,
	[Cheque_Department].[AddTime] = @AddTime,
	[Cheque_Department].[GUID] = @GUID,
	[Cheque_Department].[DepartmentNumber] = @DepartmentNumber,
	[Cheque_Department].[DepartmentInChargeMan] = @DepartmentInChargeMan,
	[Cheque_Department].[DepartmentCategoryID] = @DepartmentCategoryID 
output 
	INSERTED.[ID],
	INSERTED.[DepartmentName],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[DepartmentNumber],
	INSERTED.[DepartmentInChargeMan],
	INSERTED.[DepartmentCategoryID]
into @table
WHERE 
	[Cheque_Department].[ID] = @ID

SELECT 
	[ID],
	[DepartmentName],
	[Description],
	[AddTime],
	[GUID],
	[DepartmentNumber],
	[DepartmentInChargeMan],
	[DepartmentCategoryID] 
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
DELETE FROM [dbo].[Cheque_Department]
WHERE 
	[Cheque_Department].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_Department() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_Department(this.ID));
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
	[Cheque_Department].[ID],
	[Cheque_Department].[DepartmentName],
	[Cheque_Department].[Description],
	[Cheque_Department].[AddTime],
	[Cheque_Department].[GUID],
	[Cheque_Department].[DepartmentNumber],
	[Cheque_Department].[DepartmentInChargeMan],
	[Cheque_Department].[DepartmentCategoryID]
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
                return "Cheque_Department";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_Department into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="departmentName">departmentName</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="departmentNumber">departmentNumber</param>
		/// <param name="departmentInChargeMan">departmentInChargeMan</param>
		/// <param name="departmentCategoryID">departmentCategoryID</param>
		public static void InsertCheque_Department(string @departmentName, string @description, DateTime @addTime, string @gUID, string @departmentNumber, string @departmentInChargeMan, int @departmentCategoryID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_Department(@departmentName, @description, @addTime, @gUID, @departmentNumber, @departmentInChargeMan, @departmentCategoryID, helper);
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
		/// Insert a Cheque_Department into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="departmentName">departmentName</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="departmentNumber">departmentNumber</param>
		/// <param name="departmentInChargeMan">departmentInChargeMan</param>
		/// <param name="departmentCategoryID">departmentCategoryID</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_Department(string @departmentName, string @description, DateTime @addTime, string @gUID, string @departmentNumber, string @departmentInChargeMan, int @departmentCategoryID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DepartmentName] nvarchar(200),
	[Description] ntext,
	[AddTime] datetime,
	[GUID] nvarchar(200),
	[DepartmentNumber] nvarchar(200),
	[DepartmentInChargeMan] nvarchar(50),
	[DepartmentCategoryID] int
);

INSERT INTO [dbo].[Cheque_Department] (
	[Cheque_Department].[DepartmentName],
	[Cheque_Department].[Description],
	[Cheque_Department].[AddTime],
	[Cheque_Department].[GUID],
	[Cheque_Department].[DepartmentNumber],
	[Cheque_Department].[DepartmentInChargeMan],
	[Cheque_Department].[DepartmentCategoryID]
) 
output 
	INSERTED.[ID],
	INSERTED.[DepartmentName],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[DepartmentNumber],
	INSERTED.[DepartmentInChargeMan],
	INSERTED.[DepartmentCategoryID]
into @table
VALUES ( 
	@DepartmentName,
	@Description,
	@AddTime,
	@GUID,
	@DepartmentNumber,
	@DepartmentInChargeMan,
	@DepartmentCategoryID 
); 

SELECT 
	[ID],
	[DepartmentName],
	[Description],
	[AddTime],
	[GUID],
	[DepartmentNumber],
	[DepartmentInChargeMan],
	[DepartmentCategoryID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DepartmentName", EntityBase.GetDatabaseValue(@departmentName)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@DepartmentNumber", EntityBase.GetDatabaseValue(@departmentNumber)));
			parameters.Add(new SqlParameter("@DepartmentInChargeMan", EntityBase.GetDatabaseValue(@departmentInChargeMan)));
			parameters.Add(new SqlParameter("@DepartmentCategoryID", EntityBase.GetDatabaseValue(@departmentCategoryID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_Department into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="departmentName">departmentName</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="departmentNumber">departmentNumber</param>
		/// <param name="departmentInChargeMan">departmentInChargeMan</param>
		/// <param name="departmentCategoryID">departmentCategoryID</param>
		public static void UpdateCheque_Department(int @iD, string @departmentName, string @description, DateTime @addTime, string @gUID, string @departmentNumber, string @departmentInChargeMan, int @departmentCategoryID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_Department(@iD, @departmentName, @description, @addTime, @gUID, @departmentNumber, @departmentInChargeMan, @departmentCategoryID, helper);
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
		/// Updates a Cheque_Department into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="departmentName">departmentName</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="departmentNumber">departmentNumber</param>
		/// <param name="departmentInChargeMan">departmentInChargeMan</param>
		/// <param name="departmentCategoryID">departmentCategoryID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_Department(int @iD, string @departmentName, string @description, DateTime @addTime, string @gUID, string @departmentNumber, string @departmentInChargeMan, int @departmentCategoryID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DepartmentName] nvarchar(200),
	[Description] ntext,
	[AddTime] datetime,
	[GUID] nvarchar(200),
	[DepartmentNumber] nvarchar(200),
	[DepartmentInChargeMan] nvarchar(50),
	[DepartmentCategoryID] int
);

UPDATE [dbo].[Cheque_Department] SET 
	[Cheque_Department].[DepartmentName] = @DepartmentName,
	[Cheque_Department].[Description] = @Description,
	[Cheque_Department].[AddTime] = @AddTime,
	[Cheque_Department].[GUID] = @GUID,
	[Cheque_Department].[DepartmentNumber] = @DepartmentNumber,
	[Cheque_Department].[DepartmentInChargeMan] = @DepartmentInChargeMan,
	[Cheque_Department].[DepartmentCategoryID] = @DepartmentCategoryID 
output 
	INSERTED.[ID],
	INSERTED.[DepartmentName],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[GUID],
	INSERTED.[DepartmentNumber],
	INSERTED.[DepartmentInChargeMan],
	INSERTED.[DepartmentCategoryID]
into @table
WHERE 
	[Cheque_Department].[ID] = @ID

SELECT 
	[ID],
	[DepartmentName],
	[Description],
	[AddTime],
	[GUID],
	[DepartmentNumber],
	[DepartmentInChargeMan],
	[DepartmentCategoryID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@DepartmentName", EntityBase.GetDatabaseValue(@departmentName)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@DepartmentNumber", EntityBase.GetDatabaseValue(@departmentNumber)));
			parameters.Add(new SqlParameter("@DepartmentInChargeMan", EntityBase.GetDatabaseValue(@departmentInChargeMan)));
			parameters.Add(new SqlParameter("@DepartmentCategoryID", EntityBase.GetDatabaseValue(@departmentCategoryID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_Department from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_Department(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_Department(@iD, helper);
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
		/// Deletes a Cheque_Department from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_Department(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_Department]
WHERE 
	[Cheque_Department].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_Department object.
		/// </summary>
		/// <returns>The newly created Cheque_Department object.</returns>
		public static Cheque_Department CreateCheque_Department()
		{
			return InitializeNew<Cheque_Department>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_Department by a Cheque_Department's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_Department</returns>
		public static Cheque_Department GetCheque_Department(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_Department.SelectFieldList + @"
FROM [dbo].[Cheque_Department] 
WHERE 
	[Cheque_Department].[ID] = @ID " + Cheque_Department.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_Department>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_Department by a Cheque_Department's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_Department</returns>
		public static Cheque_Department GetCheque_Department(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_Department.SelectFieldList + @"
FROM [dbo].[Cheque_Department] 
WHERE 
	[Cheque_Department].[ID] = @ID " + Cheque_Department.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_Department>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Department objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_Department objects.</returns>
		public static EntityList<Cheque_Department> GetCheque_Departments()
		{
			string commandText = @"
SELECT " + Cheque_Department.SelectFieldList + "FROM [dbo].[Cheque_Department] " + Cheque_Department.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_Department>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_Department objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_Department objects.</returns>
        public static EntityList<Cheque_Department> GetCheque_Departments(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Department>(SelectFieldList, "FROM [dbo].[Cheque_Department]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_Department objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_Department objects.</returns>
        public static EntityList<Cheque_Department> GetCheque_Departments(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Department>(SelectFieldList, "FROM [dbo].[Cheque_Department]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_Department objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_Department objects.</returns>
		protected static EntityList<Cheque_Department> GetCheque_Departments(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Departments(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Department objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Department objects.</returns>
		protected static EntityList<Cheque_Department> GetCheque_Departments(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Departments(string.Empty, where, parameters, Cheque_Department.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Department objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Department objects.</returns>
		protected static EntityList<Cheque_Department> GetCheque_Departments(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_Departments(prefix, where, parameters, Cheque_Department.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Department objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Department objects.</returns>
		protected static EntityList<Cheque_Department> GetCheque_Departments(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_Departments(string.Empty, where, parameters, Cheque_Department.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Department objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_Department objects.</returns>
		protected static EntityList<Cheque_Department> GetCheque_Departments(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_Departments(prefix, where, parameters, Cheque_Department.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_Department objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_Department objects.</returns>
		protected static EntityList<Cheque_Department> GetCheque_Departments(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_Department.SelectFieldList + "FROM [dbo].[Cheque_Department] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_Department>(reader);
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
        protected static EntityList<Cheque_Department> GetCheque_Departments(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_Department>(SelectFieldList, "FROM [dbo].[Cheque_Department] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_Department objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_DepartmentCount()
        {
            return GetCheque_DepartmentCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_Department objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_DepartmentCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_Department] " + where;

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
		public static partial class Cheque_Department_Properties
		{
			public const string ID = "ID";
			public const string DepartmentName = "DepartmentName";
			public const string Description = "Description";
			public const string AddTime = "AddTime";
			public const string GUID = "GUID";
			public const string DepartmentNumber = "DepartmentNumber";
			public const string DepartmentInChargeMan = "DepartmentInChargeMan";
			public const string DepartmentCategoryID = "DepartmentCategoryID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"DepartmentName" , "string:"},
    			 {"Description" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"GUID" , "string:"},
    			 {"DepartmentNumber" , "string:"},
    			 {"DepartmentInChargeMan" , "string:"},
    			 {"DepartmentCategoryID" , "int:"},
            };
		}
		#endregion
	}
}
