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
	/// This object represents the properties and methods of a Wechat_RentHomeType.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_RentHomeType 
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
		private int _rentRoomID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RentRoomID
		{
			[DebuggerStepThrough()]
			get { return this._rentRoomID; }
			set 
			{
				if (this._rentRoomID != value) 
				{
					this._rentRoomID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RentRoomID");
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
		private decimal _typeArea = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TypeArea
		{
			[DebuggerStepThrough()]
			get { return this._typeArea; }
			set 
			{
				if (this._typeArea != value) 
				{
					this._typeArea = value;
					this.IsDirty = true;	
					OnPropertyChanged("TypeArea");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _typeTags = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TypeTags
		{
			[DebuggerStepThrough()]
			get { return this._typeTags; }
			set 
			{
				if (this._typeTags != value) 
				{
					this._typeTags = value;
					this.IsDirty = true;	
					OnPropertyChanged("TypeTags");
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
		private string _addMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddMan
		{
			[DebuggerStepThrough()]
			get { return this._addMan; }
			set 
			{
				if (this._addMan != value) 
				{
					this._addMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _rentStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RentStatus
		{
			[DebuggerStepThrough()]
			get { return this._rentStatus; }
			set 
			{
				if (this._rentStatus != value) 
				{
					this._rentStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("RentStatus");
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
	[RentRoomID] int,
	[TypeName] nvarchar(200),
	[UnitPrice] decimal(18, 2),
	[Unit] nvarchar(50),
	[TypeArea] decimal(18, 2),
	[TypeTags] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200),
	[RentStatus] int
);

INSERT INTO [dbo].[Wechat_RentHomeType] (
	[Wechat_RentHomeType].[RentRoomID],
	[Wechat_RentHomeType].[TypeName],
	[Wechat_RentHomeType].[UnitPrice],
	[Wechat_RentHomeType].[Unit],
	[Wechat_RentHomeType].[TypeArea],
	[Wechat_RentHomeType].[TypeTags],
	[Wechat_RentHomeType].[AddTime],
	[Wechat_RentHomeType].[AddMan],
	[Wechat_RentHomeType].[RentStatus]
) 
output 
	INSERTED.[ID],
	INSERTED.[RentRoomID],
	INSERTED.[TypeName],
	INSERTED.[UnitPrice],
	INSERTED.[Unit],
	INSERTED.[TypeArea],
	INSERTED.[TypeTags],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[RentStatus]
into @table
VALUES ( 
	@RentRoomID,
	@TypeName,
	@UnitPrice,
	@Unit,
	@TypeArea,
	@TypeTags,
	@AddTime,
	@AddMan,
	@RentStatus 
); 

SELECT 
	[ID],
	[RentRoomID],
	[TypeName],
	[UnitPrice],
	[Unit],
	[TypeArea],
	[TypeTags],
	[AddTime],
	[AddMan],
	[RentStatus] 
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
	[RentRoomID] int,
	[TypeName] nvarchar(200),
	[UnitPrice] decimal(18, 2),
	[Unit] nvarchar(50),
	[TypeArea] decimal(18, 2),
	[TypeTags] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200),
	[RentStatus] int
);

UPDATE [dbo].[Wechat_RentHomeType] SET 
	[Wechat_RentHomeType].[RentRoomID] = @RentRoomID,
	[Wechat_RentHomeType].[TypeName] = @TypeName,
	[Wechat_RentHomeType].[UnitPrice] = @UnitPrice,
	[Wechat_RentHomeType].[Unit] = @Unit,
	[Wechat_RentHomeType].[TypeArea] = @TypeArea,
	[Wechat_RentHomeType].[TypeTags] = @TypeTags,
	[Wechat_RentHomeType].[AddTime] = @AddTime,
	[Wechat_RentHomeType].[AddMan] = @AddMan,
	[Wechat_RentHomeType].[RentStatus] = @RentStatus 
output 
	INSERTED.[ID],
	INSERTED.[RentRoomID],
	INSERTED.[TypeName],
	INSERTED.[UnitPrice],
	INSERTED.[Unit],
	INSERTED.[TypeArea],
	INSERTED.[TypeTags],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[RentStatus]
into @table
WHERE 
	[Wechat_RentHomeType].[ID] = @ID

SELECT 
	[ID],
	[RentRoomID],
	[TypeName],
	[UnitPrice],
	[Unit],
	[TypeArea],
	[TypeTags],
	[AddTime],
	[AddMan],
	[RentStatus] 
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
DELETE FROM [dbo].[Wechat_RentHomeType]
WHERE 
	[Wechat_RentHomeType].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_RentHomeType() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_RentHomeType(this.ID));
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
	[Wechat_RentHomeType].[ID],
	[Wechat_RentHomeType].[RentRoomID],
	[Wechat_RentHomeType].[TypeName],
	[Wechat_RentHomeType].[UnitPrice],
	[Wechat_RentHomeType].[Unit],
	[Wechat_RentHomeType].[TypeArea],
	[Wechat_RentHomeType].[TypeTags],
	[Wechat_RentHomeType].[AddTime],
	[Wechat_RentHomeType].[AddMan],
	[Wechat_RentHomeType].[RentStatus]
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
                return "Wechat_RentHomeType";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_RentHomeType into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="rentRoomID">rentRoomID</param>
		/// <param name="typeName">typeName</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="unit">unit</param>
		/// <param name="typeArea">typeArea</param>
		/// <param name="typeTags">typeTags</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="rentStatus">rentStatus</param>
		public static void InsertWechat_RentHomeType(int @rentRoomID, string @typeName, decimal @unitPrice, string @unit, decimal @typeArea, string @typeTags, DateTime @addTime, string @addMan, int @rentStatus)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_RentHomeType(@rentRoomID, @typeName, @unitPrice, @unit, @typeArea, @typeTags, @addTime, @addMan, @rentStatus, helper);
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
		/// Insert a Wechat_RentHomeType into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="rentRoomID">rentRoomID</param>
		/// <param name="typeName">typeName</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="unit">unit</param>
		/// <param name="typeArea">typeArea</param>
		/// <param name="typeTags">typeTags</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="rentStatus">rentStatus</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_RentHomeType(int @rentRoomID, string @typeName, decimal @unitPrice, string @unit, decimal @typeArea, string @typeTags, DateTime @addTime, string @addMan, int @rentStatus, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RentRoomID] int,
	[TypeName] nvarchar(200),
	[UnitPrice] decimal(18, 2),
	[Unit] nvarchar(50),
	[TypeArea] decimal(18, 2),
	[TypeTags] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200),
	[RentStatus] int
);

INSERT INTO [dbo].[Wechat_RentHomeType] (
	[Wechat_RentHomeType].[RentRoomID],
	[Wechat_RentHomeType].[TypeName],
	[Wechat_RentHomeType].[UnitPrice],
	[Wechat_RentHomeType].[Unit],
	[Wechat_RentHomeType].[TypeArea],
	[Wechat_RentHomeType].[TypeTags],
	[Wechat_RentHomeType].[AddTime],
	[Wechat_RentHomeType].[AddMan],
	[Wechat_RentHomeType].[RentStatus]
) 
output 
	INSERTED.[ID],
	INSERTED.[RentRoomID],
	INSERTED.[TypeName],
	INSERTED.[UnitPrice],
	INSERTED.[Unit],
	INSERTED.[TypeArea],
	INSERTED.[TypeTags],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[RentStatus]
into @table
VALUES ( 
	@RentRoomID,
	@TypeName,
	@UnitPrice,
	@Unit,
	@TypeArea,
	@TypeTags,
	@AddTime,
	@AddMan,
	@RentStatus 
); 

SELECT 
	[ID],
	[RentRoomID],
	[TypeName],
	[UnitPrice],
	[Unit],
	[TypeArea],
	[TypeTags],
	[AddTime],
	[AddMan],
	[RentStatus] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RentRoomID", EntityBase.GetDatabaseValue(@rentRoomID)));
			parameters.Add(new SqlParameter("@TypeName", EntityBase.GetDatabaseValue(@typeName)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@Unit", EntityBase.GetDatabaseValue(@unit)));
			parameters.Add(new SqlParameter("@TypeArea", EntityBase.GetDatabaseValue(@typeArea)));
			parameters.Add(new SqlParameter("@TypeTags", EntityBase.GetDatabaseValue(@typeTags)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@RentStatus", EntityBase.GetDatabaseValue(@rentStatus)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_RentHomeType into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="rentRoomID">rentRoomID</param>
		/// <param name="typeName">typeName</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="unit">unit</param>
		/// <param name="typeArea">typeArea</param>
		/// <param name="typeTags">typeTags</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="rentStatus">rentStatus</param>
		public static void UpdateWechat_RentHomeType(int @iD, int @rentRoomID, string @typeName, decimal @unitPrice, string @unit, decimal @typeArea, string @typeTags, DateTime @addTime, string @addMan, int @rentStatus)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_RentHomeType(@iD, @rentRoomID, @typeName, @unitPrice, @unit, @typeArea, @typeTags, @addTime, @addMan, @rentStatus, helper);
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
		/// Updates a Wechat_RentHomeType into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="rentRoomID">rentRoomID</param>
		/// <param name="typeName">typeName</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="unit">unit</param>
		/// <param name="typeArea">typeArea</param>
		/// <param name="typeTags">typeTags</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="rentStatus">rentStatus</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_RentHomeType(int @iD, int @rentRoomID, string @typeName, decimal @unitPrice, string @unit, decimal @typeArea, string @typeTags, DateTime @addTime, string @addMan, int @rentStatus, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RentRoomID] int,
	[TypeName] nvarchar(200),
	[UnitPrice] decimal(18, 2),
	[Unit] nvarchar(50),
	[TypeArea] decimal(18, 2),
	[TypeTags] nvarchar(500),
	[AddTime] datetime,
	[AddMan] nvarchar(200),
	[RentStatus] int
);

UPDATE [dbo].[Wechat_RentHomeType] SET 
	[Wechat_RentHomeType].[RentRoomID] = @RentRoomID,
	[Wechat_RentHomeType].[TypeName] = @TypeName,
	[Wechat_RentHomeType].[UnitPrice] = @UnitPrice,
	[Wechat_RentHomeType].[Unit] = @Unit,
	[Wechat_RentHomeType].[TypeArea] = @TypeArea,
	[Wechat_RentHomeType].[TypeTags] = @TypeTags,
	[Wechat_RentHomeType].[AddTime] = @AddTime,
	[Wechat_RentHomeType].[AddMan] = @AddMan,
	[Wechat_RentHomeType].[RentStatus] = @RentStatus 
output 
	INSERTED.[ID],
	INSERTED.[RentRoomID],
	INSERTED.[TypeName],
	INSERTED.[UnitPrice],
	INSERTED.[Unit],
	INSERTED.[TypeArea],
	INSERTED.[TypeTags],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[RentStatus]
into @table
WHERE 
	[Wechat_RentHomeType].[ID] = @ID

SELECT 
	[ID],
	[RentRoomID],
	[TypeName],
	[UnitPrice],
	[Unit],
	[TypeArea],
	[TypeTags],
	[AddTime],
	[AddMan],
	[RentStatus] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RentRoomID", EntityBase.GetDatabaseValue(@rentRoomID)));
			parameters.Add(new SqlParameter("@TypeName", EntityBase.GetDatabaseValue(@typeName)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@Unit", EntityBase.GetDatabaseValue(@unit)));
			parameters.Add(new SqlParameter("@TypeArea", EntityBase.GetDatabaseValue(@typeArea)));
			parameters.Add(new SqlParameter("@TypeTags", EntityBase.GetDatabaseValue(@typeTags)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@RentStatus", EntityBase.GetDatabaseValue(@rentStatus)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_RentHomeType from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_RentHomeType(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_RentHomeType(@iD, helper);
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
		/// Deletes a Wechat_RentHomeType from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_RentHomeType(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_RentHomeType]
WHERE 
	[Wechat_RentHomeType].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_RentHomeType object.
		/// </summary>
		/// <returns>The newly created Wechat_RentHomeType object.</returns>
		public static Wechat_RentHomeType CreateWechat_RentHomeType()
		{
			return InitializeNew<Wechat_RentHomeType>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_RentHomeType by a Wechat_RentHomeType's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_RentHomeType</returns>
		public static Wechat_RentHomeType GetWechat_RentHomeType(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_RentHomeType.SelectFieldList + @"
FROM [dbo].[Wechat_RentHomeType] 
WHERE 
	[Wechat_RentHomeType].[ID] = @ID " + Wechat_RentHomeType.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_RentHomeType>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_RentHomeType by a Wechat_RentHomeType's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_RentHomeType</returns>
		public static Wechat_RentHomeType GetWechat_RentHomeType(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_RentHomeType.SelectFieldList + @"
FROM [dbo].[Wechat_RentHomeType] 
WHERE 
	[Wechat_RentHomeType].[ID] = @ID " + Wechat_RentHomeType.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_RentHomeType>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentHomeType objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_RentHomeType objects.</returns>
		public static EntityList<Wechat_RentHomeType> GetWechat_RentHomeTypes()
		{
			string commandText = @"
SELECT " + Wechat_RentHomeType.SelectFieldList + "FROM [dbo].[Wechat_RentHomeType] " + Wechat_RentHomeType.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_RentHomeType>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_RentHomeType objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_RentHomeType objects.</returns>
        public static EntityList<Wechat_RentHomeType> GetWechat_RentHomeTypes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_RentHomeType>(SelectFieldList, "FROM [dbo].[Wechat_RentHomeType]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_RentHomeType objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_RentHomeType objects.</returns>
        public static EntityList<Wechat_RentHomeType> GetWechat_RentHomeTypes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_RentHomeType>(SelectFieldList, "FROM [dbo].[Wechat_RentHomeType]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_RentHomeType objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_RentHomeType objects.</returns>
		protected static EntityList<Wechat_RentHomeType> GetWechat_RentHomeTypes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_RentHomeTypes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentHomeType objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentHomeType objects.</returns>
		protected static EntityList<Wechat_RentHomeType> GetWechat_RentHomeTypes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_RentHomeTypes(string.Empty, where, parameters, Wechat_RentHomeType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentHomeType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentHomeType objects.</returns>
		protected static EntityList<Wechat_RentHomeType> GetWechat_RentHomeTypes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_RentHomeTypes(prefix, where, parameters, Wechat_RentHomeType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentHomeType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentHomeType objects.</returns>
		protected static EntityList<Wechat_RentHomeType> GetWechat_RentHomeTypes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_RentHomeTypes(string.Empty, where, parameters, Wechat_RentHomeType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentHomeType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_RentHomeType objects.</returns>
		protected static EntityList<Wechat_RentHomeType> GetWechat_RentHomeTypes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_RentHomeTypes(prefix, where, parameters, Wechat_RentHomeType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_RentHomeType objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_RentHomeType objects.</returns>
		protected static EntityList<Wechat_RentHomeType> GetWechat_RentHomeTypes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_RentHomeType.SelectFieldList + "FROM [dbo].[Wechat_RentHomeType] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_RentHomeType>(reader);
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
        protected static EntityList<Wechat_RentHomeType> GetWechat_RentHomeTypes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_RentHomeType>(SelectFieldList, "FROM [dbo].[Wechat_RentHomeType] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_RentHomeType objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_RentHomeTypeCount()
        {
            return GetWechat_RentHomeTypeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_RentHomeType objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_RentHomeTypeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_RentHomeType] " + where;

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
		public static partial class Wechat_RentHomeType_Properties
		{
			public const string ID = "ID";
			public const string RentRoomID = "RentRoomID";
			public const string TypeName = "TypeName";
			public const string UnitPrice = "UnitPrice";
			public const string Unit = "Unit";
			public const string TypeArea = "TypeArea";
			public const string TypeTags = "TypeTags";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string RentStatus = "RentStatus";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RentRoomID" , "int:"},
    			 {"TypeName" , "string:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"Unit" , "string:"},
    			 {"TypeArea" , "decimal:"},
    			 {"TypeTags" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"RentStatus" , "int:"},
            };
		}
		#endregion
	}
}
