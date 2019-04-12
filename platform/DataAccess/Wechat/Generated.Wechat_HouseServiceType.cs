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
	/// This object represents the properties and methods of a Wechat_HouseServiceType.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_HouseServiceType 
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
		private int _serviceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ServiceID
		{
			[DebuggerStepThrough()]
			get { return this._serviceID; }
			set 
			{
				if (this._serviceID != value) 
				{
					this._serviceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _typeName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TypeName
		{
			[DebuggerStepThrough()]
			get { return this._typeName; }
			set 
			{
				if (this._typeName != value) 
				{
					this._typeName = value;
					this.IsDirty = true;	
					OnPropertyChanged("TypeName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _unitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal UnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._unitPrice; }
			set 
			{
				if (this._unitPrice != value) 
				{
					this._unitPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("UnitPrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _unit = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Unit
		{
			[DebuggerStepThrough()]
			get { return this._unit; }
			set 
			{
				if (this._unit != value) 
				{
					this._unit = value;
					this.IsDirty = true;	
					OnPropertyChanged("Unit");
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _basicPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal BasicPrice
		{
			[DebuggerStepThrough()]
			get { return this._basicPrice; }
			set 
			{
				if (this._basicPrice != value) 
				{
					this._basicPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("BasicPrice");
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
	[ServiceID] int,
	[TypeName] nvarchar(50),
	[UnitPrice] decimal(18, 2),
	[Unit] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime,
	[BasicPrice] decimal(18, 2)
);

INSERT INTO [dbo].[Wechat_HouseServiceType] (
	[Wechat_HouseServiceType].[ServiceID],
	[Wechat_HouseServiceType].[TypeName],
	[Wechat_HouseServiceType].[UnitPrice],
	[Wechat_HouseServiceType].[Unit],
	[Wechat_HouseServiceType].[Remark],
	[Wechat_HouseServiceType].[AddTime],
	[Wechat_HouseServiceType].[BasicPrice]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[TypeName],
	INSERTED.[UnitPrice],
	INSERTED.[Unit],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[BasicPrice]
into @table
VALUES ( 
	@ServiceID,
	@TypeName,
	@UnitPrice,
	@Unit,
	@Remark,
	@AddTime,
	@BasicPrice 
); 

SELECT 
	[ID],
	[ServiceID],
	[TypeName],
	[UnitPrice],
	[Unit],
	[Remark],
	[AddTime],
	[BasicPrice] 
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
	[ServiceID] int,
	[TypeName] nvarchar(50),
	[UnitPrice] decimal(18, 2),
	[Unit] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime,
	[BasicPrice] decimal(18, 2)
);

UPDATE [dbo].[Wechat_HouseServiceType] SET 
	[Wechat_HouseServiceType].[ServiceID] = @ServiceID,
	[Wechat_HouseServiceType].[TypeName] = @TypeName,
	[Wechat_HouseServiceType].[UnitPrice] = @UnitPrice,
	[Wechat_HouseServiceType].[Unit] = @Unit,
	[Wechat_HouseServiceType].[Remark] = @Remark,
	[Wechat_HouseServiceType].[AddTime] = @AddTime,
	[Wechat_HouseServiceType].[BasicPrice] = @BasicPrice 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[TypeName],
	INSERTED.[UnitPrice],
	INSERTED.[Unit],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[BasicPrice]
into @table
WHERE 
	[Wechat_HouseServiceType].[ID] = @ID

SELECT 
	[ID],
	[ServiceID],
	[TypeName],
	[UnitPrice],
	[Unit],
	[Remark],
	[AddTime],
	[BasicPrice] 
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
DELETE FROM [dbo].[Wechat_HouseServiceType]
WHERE 
	[Wechat_HouseServiceType].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_HouseServiceType() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_HouseServiceType(this.ID));
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
	[Wechat_HouseServiceType].[ID],
	[Wechat_HouseServiceType].[ServiceID],
	[Wechat_HouseServiceType].[TypeName],
	[Wechat_HouseServiceType].[UnitPrice],
	[Wechat_HouseServiceType].[Unit],
	[Wechat_HouseServiceType].[Remark],
	[Wechat_HouseServiceType].[AddTime],
	[Wechat_HouseServiceType].[BasicPrice]
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
                return "Wechat_HouseServiceType";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_HouseServiceType into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="typeName">typeName</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="unit">unit</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="basicPrice">basicPrice</param>
		public static void InsertWechat_HouseServiceType(int @serviceID, string @typeName, decimal @unitPrice, string @unit, string @remark, DateTime @addTime, decimal @basicPrice)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_HouseServiceType(@serviceID, @typeName, @unitPrice, @unit, @remark, @addTime, @basicPrice, helper);
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
		/// Insert a Wechat_HouseServiceType into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="typeName">typeName</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="unit">unit</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="basicPrice">basicPrice</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_HouseServiceType(int @serviceID, string @typeName, decimal @unitPrice, string @unit, string @remark, DateTime @addTime, decimal @basicPrice, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceID] int,
	[TypeName] nvarchar(50),
	[UnitPrice] decimal(18, 2),
	[Unit] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime,
	[BasicPrice] decimal(18, 2)
);

INSERT INTO [dbo].[Wechat_HouseServiceType] (
	[Wechat_HouseServiceType].[ServiceID],
	[Wechat_HouseServiceType].[TypeName],
	[Wechat_HouseServiceType].[UnitPrice],
	[Wechat_HouseServiceType].[Unit],
	[Wechat_HouseServiceType].[Remark],
	[Wechat_HouseServiceType].[AddTime],
	[Wechat_HouseServiceType].[BasicPrice]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[TypeName],
	INSERTED.[UnitPrice],
	INSERTED.[Unit],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[BasicPrice]
into @table
VALUES ( 
	@ServiceID,
	@TypeName,
	@UnitPrice,
	@Unit,
	@Remark,
	@AddTime,
	@BasicPrice 
); 

SELECT 
	[ID],
	[ServiceID],
	[TypeName],
	[UnitPrice],
	[Unit],
	[Remark],
	[AddTime],
	[BasicPrice] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@TypeName", EntityBase.GetDatabaseValue(@typeName)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@Unit", EntityBase.GetDatabaseValue(@unit)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@BasicPrice", EntityBase.GetDatabaseValue(@basicPrice)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_HouseServiceType into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="typeName">typeName</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="unit">unit</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="basicPrice">basicPrice</param>
		public static void UpdateWechat_HouseServiceType(int @iD, int @serviceID, string @typeName, decimal @unitPrice, string @unit, string @remark, DateTime @addTime, decimal @basicPrice)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_HouseServiceType(@iD, @serviceID, @typeName, @unitPrice, @unit, @remark, @addTime, @basicPrice, helper);
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
		/// Updates a Wechat_HouseServiceType into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="typeName">typeName</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="unit">unit</param>
		/// <param name="remark">remark</param>
		/// <param name="addTime">addTime</param>
		/// <param name="basicPrice">basicPrice</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_HouseServiceType(int @iD, int @serviceID, string @typeName, decimal @unitPrice, string @unit, string @remark, DateTime @addTime, decimal @basicPrice, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceID] int,
	[TypeName] nvarchar(50),
	[UnitPrice] decimal(18, 2),
	[Unit] nvarchar(50),
	[Remark] ntext,
	[AddTime] datetime,
	[BasicPrice] decimal(18, 2)
);

UPDATE [dbo].[Wechat_HouseServiceType] SET 
	[Wechat_HouseServiceType].[ServiceID] = @ServiceID,
	[Wechat_HouseServiceType].[TypeName] = @TypeName,
	[Wechat_HouseServiceType].[UnitPrice] = @UnitPrice,
	[Wechat_HouseServiceType].[Unit] = @Unit,
	[Wechat_HouseServiceType].[Remark] = @Remark,
	[Wechat_HouseServiceType].[AddTime] = @AddTime,
	[Wechat_HouseServiceType].[BasicPrice] = @BasicPrice 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[TypeName],
	INSERTED.[UnitPrice],
	INSERTED.[Unit],
	INSERTED.[Remark],
	INSERTED.[AddTime],
	INSERTED.[BasicPrice]
into @table
WHERE 
	[Wechat_HouseServiceType].[ID] = @ID

SELECT 
	[ID],
	[ServiceID],
	[TypeName],
	[UnitPrice],
	[Unit],
	[Remark],
	[AddTime],
	[BasicPrice] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@TypeName", EntityBase.GetDatabaseValue(@typeName)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@Unit", EntityBase.GetDatabaseValue(@unit)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@BasicPrice", EntityBase.GetDatabaseValue(@basicPrice)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_HouseServiceType from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_HouseServiceType(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_HouseServiceType(@iD, helper);
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
		/// Deletes a Wechat_HouseServiceType from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_HouseServiceType(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_HouseServiceType]
WHERE 
	[Wechat_HouseServiceType].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_HouseServiceType object.
		/// </summary>
		/// <returns>The newly created Wechat_HouseServiceType object.</returns>
		public static Wechat_HouseServiceType CreateWechat_HouseServiceType()
		{
			return InitializeNew<Wechat_HouseServiceType>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_HouseServiceType by a Wechat_HouseServiceType's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_HouseServiceType</returns>
		public static Wechat_HouseServiceType GetWechat_HouseServiceType(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_HouseServiceType.SelectFieldList + @"
FROM [dbo].[Wechat_HouseServiceType] 
WHERE 
	[Wechat_HouseServiceType].[ID] = @ID " + Wechat_HouseServiceType.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_HouseServiceType>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_HouseServiceType by a Wechat_HouseServiceType's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_HouseServiceType</returns>
		public static Wechat_HouseServiceType GetWechat_HouseServiceType(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_HouseServiceType.SelectFieldList + @"
FROM [dbo].[Wechat_HouseServiceType] 
WHERE 
	[Wechat_HouseServiceType].[ID] = @ID " + Wechat_HouseServiceType.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_HouseServiceType>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceType objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_HouseServiceType objects.</returns>
		public static EntityList<Wechat_HouseServiceType> GetWechat_HouseServiceTypes()
		{
			string commandText = @"
SELECT " + Wechat_HouseServiceType.SelectFieldList + "FROM [dbo].[Wechat_HouseServiceType] " + Wechat_HouseServiceType.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_HouseServiceType>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_HouseServiceType objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_HouseServiceType objects.</returns>
        public static EntityList<Wechat_HouseServiceType> GetWechat_HouseServiceTypes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_HouseServiceType>(SelectFieldList, "FROM [dbo].[Wechat_HouseServiceType]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_HouseServiceType objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_HouseServiceType objects.</returns>
        public static EntityList<Wechat_HouseServiceType> GetWechat_HouseServiceTypes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_HouseServiceType>(SelectFieldList, "FROM [dbo].[Wechat_HouseServiceType]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceType objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceType objects.</returns>
		protected static EntityList<Wechat_HouseServiceType> GetWechat_HouseServiceTypes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_HouseServiceTypes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceType objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceType objects.</returns>
		protected static EntityList<Wechat_HouseServiceType> GetWechat_HouseServiceTypes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_HouseServiceTypes(string.Empty, where, parameters, Wechat_HouseServiceType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceType objects.</returns>
		protected static EntityList<Wechat_HouseServiceType> GetWechat_HouseServiceTypes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_HouseServiceTypes(prefix, where, parameters, Wechat_HouseServiceType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceType objects.</returns>
		protected static EntityList<Wechat_HouseServiceType> GetWechat_HouseServiceTypes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_HouseServiceTypes(string.Empty, where, parameters, Wechat_HouseServiceType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceType objects.</returns>
		protected static EntityList<Wechat_HouseServiceType> GetWechat_HouseServiceTypes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_HouseServiceTypes(prefix, where, parameters, Wechat_HouseServiceType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_HouseServiceType objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_HouseServiceType objects.</returns>
		protected static EntityList<Wechat_HouseServiceType> GetWechat_HouseServiceTypes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_HouseServiceType.SelectFieldList + "FROM [dbo].[Wechat_HouseServiceType] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_HouseServiceType>(reader);
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
        protected static EntityList<Wechat_HouseServiceType> GetWechat_HouseServiceTypes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_HouseServiceType>(SelectFieldList, "FROM [dbo].[Wechat_HouseServiceType] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_HouseServiceType objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_HouseServiceTypeCount()
        {
            return GetWechat_HouseServiceTypeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_HouseServiceType objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_HouseServiceTypeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_HouseServiceType] " + where;

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
		public static partial class Wechat_HouseServiceType_Properties
		{
			public const string ID = "ID";
			public const string ServiceID = "ServiceID";
			public const string TypeName = "TypeName";
			public const string UnitPrice = "UnitPrice";
			public const string Unit = "Unit";
			public const string Remark = "Remark";
			public const string AddTime = "AddTime";
			public const string BasicPrice = "BasicPrice";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ServiceID" , "int:"},
    			 {"TypeName" , "string:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"Unit" , "string:"},
    			 {"Remark" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"BasicPrice" , "decimal:"},
            };
		}
		#endregion
	}
}
