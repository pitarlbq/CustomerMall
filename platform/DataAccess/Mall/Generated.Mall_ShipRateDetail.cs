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
	/// This object represents the properties and methods of a Mall_ShipRateDetail.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_ShipRateDetail 
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
		private int _rateID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RateID
		{
			[DebuggerStepThrough()]
			get { return this._rateID; }
			set 
			{
				if (this._rateID != value) 
				{
					this._rateID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RateID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _defaultQuantity = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int DefaultQuantity
		{
			[DebuggerStepThrough()]
			get { return this._defaultQuantity; }
			set 
			{
				if (this._defaultQuantity != value) 
				{
					this._defaultQuantity = value;
					this.IsDirty = true;	
					OnPropertyChanged("DefaultQuantity");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _defaultMoney = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal DefaultMoney
		{
			[DebuggerStepThrough()]
			get { return this._defaultMoney; }
			set 
			{
				if (this._defaultMoney != value) 
				{
					this._defaultMoney = value;
					this.IsDirty = true;	
					OnPropertyChanged("DefaultMoney");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _additionalQuantity = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int AdditionalQuantity
		{
			[DebuggerStepThrough()]
			get { return this._additionalQuantity; }
			set 
			{
				if (this._additionalQuantity != value) 
				{
					this._additionalQuantity = value;
					this.IsDirty = true;	
					OnPropertyChanged("AdditionalQuantity");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _additionalMoney = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal AdditionalMoney
		{
			[DebuggerStepThrough()]
			get { return this._additionalMoney; }
			set 
			{
				if (this._additionalMoney != value) 
				{
					this._additionalMoney = value;
					this.IsDirty = true;	
					OnPropertyChanged("AdditionalMoney");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDefault = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsDefault
		{
			[DebuggerStepThrough()]
			get { return this._isDefault; }
			set 
			{
				if (this._isDefault != value) 
				{
					this._isDefault = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDefault");
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
		[DataObjectField(false, false, false)]
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
		private string _addUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string AddUserName
		{
			[DebuggerStepThrough()]
			get { return this._addUserName; }
			set 
			{
				if (this._addUserName != value) 
				{
					this._addUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUserName");
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
	[RateID] int,
	[DefaultQuantity] int,
	[DefaultMoney] decimal(18, 2),
	[AdditionalQuantity] int,
	[AdditionalMoney] decimal(18, 2),
	[IsDefault] bit,
	[AddTime] datetime,
	[AddUserName] nvarchar(200)
);

INSERT INTO [dbo].[Mall_ShipRateDetail] (
	[Mall_ShipRateDetail].[RateID],
	[Mall_ShipRateDetail].[DefaultQuantity],
	[Mall_ShipRateDetail].[DefaultMoney],
	[Mall_ShipRateDetail].[AdditionalQuantity],
	[Mall_ShipRateDetail].[AdditionalMoney],
	[Mall_ShipRateDetail].[IsDefault],
	[Mall_ShipRateDetail].[AddTime],
	[Mall_ShipRateDetail].[AddUserName]
) 
output 
	INSERTED.[ID],
	INSERTED.[RateID],
	INSERTED.[DefaultQuantity],
	INSERTED.[DefaultMoney],
	INSERTED.[AdditionalQuantity],
	INSERTED.[AdditionalMoney],
	INSERTED.[IsDefault],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
VALUES ( 
	@RateID,
	@DefaultQuantity,
	@DefaultMoney,
	@AdditionalQuantity,
	@AdditionalMoney,
	@IsDefault,
	@AddTime,
	@AddUserName 
); 

SELECT 
	[ID],
	[RateID],
	[DefaultQuantity],
	[DefaultMoney],
	[AdditionalQuantity],
	[AdditionalMoney],
	[IsDefault],
	[AddTime],
	[AddUserName] 
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
	[RateID] int,
	[DefaultQuantity] int,
	[DefaultMoney] decimal(18, 2),
	[AdditionalQuantity] int,
	[AdditionalMoney] decimal(18, 2),
	[IsDefault] bit,
	[AddTime] datetime,
	[AddUserName] nvarchar(200)
);

UPDATE [dbo].[Mall_ShipRateDetail] SET 
	[Mall_ShipRateDetail].[RateID] = @RateID,
	[Mall_ShipRateDetail].[DefaultQuantity] = @DefaultQuantity,
	[Mall_ShipRateDetail].[DefaultMoney] = @DefaultMoney,
	[Mall_ShipRateDetail].[AdditionalQuantity] = @AdditionalQuantity,
	[Mall_ShipRateDetail].[AdditionalMoney] = @AdditionalMoney,
	[Mall_ShipRateDetail].[IsDefault] = @IsDefault,
	[Mall_ShipRateDetail].[AddTime] = @AddTime,
	[Mall_ShipRateDetail].[AddUserName] = @AddUserName 
output 
	INSERTED.[ID],
	INSERTED.[RateID],
	INSERTED.[DefaultQuantity],
	INSERTED.[DefaultMoney],
	INSERTED.[AdditionalQuantity],
	INSERTED.[AdditionalMoney],
	INSERTED.[IsDefault],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
WHERE 
	[Mall_ShipRateDetail].[ID] = @ID

SELECT 
	[ID],
	[RateID],
	[DefaultQuantity],
	[DefaultMoney],
	[AdditionalQuantity],
	[AdditionalMoney],
	[IsDefault],
	[AddTime],
	[AddUserName] 
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
DELETE FROM [dbo].[Mall_ShipRateDetail]
WHERE 
	[Mall_ShipRateDetail].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_ShipRateDetail() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_ShipRateDetail(this.ID));
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
	[Mall_ShipRateDetail].[ID],
	[Mall_ShipRateDetail].[RateID],
	[Mall_ShipRateDetail].[DefaultQuantity],
	[Mall_ShipRateDetail].[DefaultMoney],
	[Mall_ShipRateDetail].[AdditionalQuantity],
	[Mall_ShipRateDetail].[AdditionalMoney],
	[Mall_ShipRateDetail].[IsDefault],
	[Mall_ShipRateDetail].[AddTime],
	[Mall_ShipRateDetail].[AddUserName]
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
                return "Mall_ShipRateDetail";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_ShipRateDetail into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="rateID">rateID</param>
		/// <param name="defaultQuantity">defaultQuantity</param>
		/// <param name="defaultMoney">defaultMoney</param>
		/// <param name="additionalQuantity">additionalQuantity</param>
		/// <param name="additionalMoney">additionalMoney</param>
		/// <param name="isDefault">isDefault</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		public static void InsertMall_ShipRateDetail(int @rateID, int @defaultQuantity, decimal @defaultMoney, int @additionalQuantity, decimal @additionalMoney, bool @isDefault, DateTime @addTime, string @addUserName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_ShipRateDetail(@rateID, @defaultQuantity, @defaultMoney, @additionalQuantity, @additionalMoney, @isDefault, @addTime, @addUserName, helper);
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
		/// Insert a Mall_ShipRateDetail into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="rateID">rateID</param>
		/// <param name="defaultQuantity">defaultQuantity</param>
		/// <param name="defaultMoney">defaultMoney</param>
		/// <param name="additionalQuantity">additionalQuantity</param>
		/// <param name="additionalMoney">additionalMoney</param>
		/// <param name="isDefault">isDefault</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_ShipRateDetail(int @rateID, int @defaultQuantity, decimal @defaultMoney, int @additionalQuantity, decimal @additionalMoney, bool @isDefault, DateTime @addTime, string @addUserName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RateID] int,
	[DefaultQuantity] int,
	[DefaultMoney] decimal(18, 2),
	[AdditionalQuantity] int,
	[AdditionalMoney] decimal(18, 2),
	[IsDefault] bit,
	[AddTime] datetime,
	[AddUserName] nvarchar(200)
);

INSERT INTO [dbo].[Mall_ShipRateDetail] (
	[Mall_ShipRateDetail].[RateID],
	[Mall_ShipRateDetail].[DefaultQuantity],
	[Mall_ShipRateDetail].[DefaultMoney],
	[Mall_ShipRateDetail].[AdditionalQuantity],
	[Mall_ShipRateDetail].[AdditionalMoney],
	[Mall_ShipRateDetail].[IsDefault],
	[Mall_ShipRateDetail].[AddTime],
	[Mall_ShipRateDetail].[AddUserName]
) 
output 
	INSERTED.[ID],
	INSERTED.[RateID],
	INSERTED.[DefaultQuantity],
	INSERTED.[DefaultMoney],
	INSERTED.[AdditionalQuantity],
	INSERTED.[AdditionalMoney],
	INSERTED.[IsDefault],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
VALUES ( 
	@RateID,
	@DefaultQuantity,
	@DefaultMoney,
	@AdditionalQuantity,
	@AdditionalMoney,
	@IsDefault,
	@AddTime,
	@AddUserName 
); 

SELECT 
	[ID],
	[RateID],
	[DefaultQuantity],
	[DefaultMoney],
	[AdditionalQuantity],
	[AdditionalMoney],
	[IsDefault],
	[AddTime],
	[AddUserName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RateID", EntityBase.GetDatabaseValue(@rateID)));
			parameters.Add(new SqlParameter("@DefaultQuantity", EntityBase.GetDatabaseValue(@defaultQuantity)));
			parameters.Add(new SqlParameter("@DefaultMoney", EntityBase.GetDatabaseValue(@defaultMoney)));
			parameters.Add(new SqlParameter("@AdditionalQuantity", EntityBase.GetDatabaseValue(@additionalQuantity)));
			parameters.Add(new SqlParameter("@AdditionalMoney", EntityBase.GetDatabaseValue(@additionalMoney)));
			parameters.Add(new SqlParameter("@IsDefault", @isDefault));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_ShipRateDetail into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="rateID">rateID</param>
		/// <param name="defaultQuantity">defaultQuantity</param>
		/// <param name="defaultMoney">defaultMoney</param>
		/// <param name="additionalQuantity">additionalQuantity</param>
		/// <param name="additionalMoney">additionalMoney</param>
		/// <param name="isDefault">isDefault</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		public static void UpdateMall_ShipRateDetail(int @iD, int @rateID, int @defaultQuantity, decimal @defaultMoney, int @additionalQuantity, decimal @additionalMoney, bool @isDefault, DateTime @addTime, string @addUserName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_ShipRateDetail(@iD, @rateID, @defaultQuantity, @defaultMoney, @additionalQuantity, @additionalMoney, @isDefault, @addTime, @addUserName, helper);
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
		/// Updates a Mall_ShipRateDetail into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="rateID">rateID</param>
		/// <param name="defaultQuantity">defaultQuantity</param>
		/// <param name="defaultMoney">defaultMoney</param>
		/// <param name="additionalQuantity">additionalQuantity</param>
		/// <param name="additionalMoney">additionalMoney</param>
		/// <param name="isDefault">isDefault</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_ShipRateDetail(int @iD, int @rateID, int @defaultQuantity, decimal @defaultMoney, int @additionalQuantity, decimal @additionalMoney, bool @isDefault, DateTime @addTime, string @addUserName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RateID] int,
	[DefaultQuantity] int,
	[DefaultMoney] decimal(18, 2),
	[AdditionalQuantity] int,
	[AdditionalMoney] decimal(18, 2),
	[IsDefault] bit,
	[AddTime] datetime,
	[AddUserName] nvarchar(200)
);

UPDATE [dbo].[Mall_ShipRateDetail] SET 
	[Mall_ShipRateDetail].[RateID] = @RateID,
	[Mall_ShipRateDetail].[DefaultQuantity] = @DefaultQuantity,
	[Mall_ShipRateDetail].[DefaultMoney] = @DefaultMoney,
	[Mall_ShipRateDetail].[AdditionalQuantity] = @AdditionalQuantity,
	[Mall_ShipRateDetail].[AdditionalMoney] = @AdditionalMoney,
	[Mall_ShipRateDetail].[IsDefault] = @IsDefault,
	[Mall_ShipRateDetail].[AddTime] = @AddTime,
	[Mall_ShipRateDetail].[AddUserName] = @AddUserName 
output 
	INSERTED.[ID],
	INSERTED.[RateID],
	INSERTED.[DefaultQuantity],
	INSERTED.[DefaultMoney],
	INSERTED.[AdditionalQuantity],
	INSERTED.[AdditionalMoney],
	INSERTED.[IsDefault],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
WHERE 
	[Mall_ShipRateDetail].[ID] = @ID

SELECT 
	[ID],
	[RateID],
	[DefaultQuantity],
	[DefaultMoney],
	[AdditionalQuantity],
	[AdditionalMoney],
	[IsDefault],
	[AddTime],
	[AddUserName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RateID", EntityBase.GetDatabaseValue(@rateID)));
			parameters.Add(new SqlParameter("@DefaultQuantity", EntityBase.GetDatabaseValue(@defaultQuantity)));
			parameters.Add(new SqlParameter("@DefaultMoney", EntityBase.GetDatabaseValue(@defaultMoney)));
			parameters.Add(new SqlParameter("@AdditionalQuantity", EntityBase.GetDatabaseValue(@additionalQuantity)));
			parameters.Add(new SqlParameter("@AdditionalMoney", EntityBase.GetDatabaseValue(@additionalMoney)));
			parameters.Add(new SqlParameter("@IsDefault", @isDefault));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_ShipRateDetail from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_ShipRateDetail(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_ShipRateDetail(@iD, helper);
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
		/// Deletes a Mall_ShipRateDetail from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_ShipRateDetail(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_ShipRateDetail]
WHERE 
	[Mall_ShipRateDetail].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_ShipRateDetail object.
		/// </summary>
		/// <returns>The newly created Mall_ShipRateDetail object.</returns>
		public static Mall_ShipRateDetail CreateMall_ShipRateDetail()
		{
			return InitializeNew<Mall_ShipRateDetail>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_ShipRateDetail by a Mall_ShipRateDetail's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_ShipRateDetail</returns>
		public static Mall_ShipRateDetail GetMall_ShipRateDetail(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_ShipRateDetail.SelectFieldList + @"
FROM [dbo].[Mall_ShipRateDetail] 
WHERE 
	[Mall_ShipRateDetail].[ID] = @ID " + Mall_ShipRateDetail.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ShipRateDetail>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_ShipRateDetail by a Mall_ShipRateDetail's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_ShipRateDetail</returns>
		public static Mall_ShipRateDetail GetMall_ShipRateDetail(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_ShipRateDetail.SelectFieldList + @"
FROM [dbo].[Mall_ShipRateDetail] 
WHERE 
	[Mall_ShipRateDetail].[ID] = @ID " + Mall_ShipRateDetail.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_ShipRateDetail>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipRateDetail objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_ShipRateDetail objects.</returns>
		public static EntityList<Mall_ShipRateDetail> GetMall_ShipRateDetails()
		{
			string commandText = @"
SELECT " + Mall_ShipRateDetail.SelectFieldList + "FROM [dbo].[Mall_ShipRateDetail] " + Mall_ShipRateDetail.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_ShipRateDetail>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_ShipRateDetail objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ShipRateDetail objects.</returns>
        public static EntityList<Mall_ShipRateDetail> GetMall_ShipRateDetails(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ShipRateDetail>(SelectFieldList, "FROM [dbo].[Mall_ShipRateDetail]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_ShipRateDetail objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_ShipRateDetail objects.</returns>
        public static EntityList<Mall_ShipRateDetail> GetMall_ShipRateDetails(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ShipRateDetail>(SelectFieldList, "FROM [dbo].[Mall_ShipRateDetail]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_ShipRateDetail objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ShipRateDetail objects.</returns>
		protected static EntityList<Mall_ShipRateDetail> GetMall_ShipRateDetails(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ShipRateDetails(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipRateDetail objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShipRateDetail objects.</returns>
		protected static EntityList<Mall_ShipRateDetail> GetMall_ShipRateDetails(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ShipRateDetails(string.Empty, where, parameters, Mall_ShipRateDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipRateDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShipRateDetail objects.</returns>
		protected static EntityList<Mall_ShipRateDetail> GetMall_ShipRateDetails(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_ShipRateDetails(prefix, where, parameters, Mall_ShipRateDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipRateDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShipRateDetail objects.</returns>
		protected static EntityList<Mall_ShipRateDetail> GetMall_ShipRateDetails(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ShipRateDetails(string.Empty, where, parameters, Mall_ShipRateDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipRateDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_ShipRateDetail objects.</returns>
		protected static EntityList<Mall_ShipRateDetail> GetMall_ShipRateDetails(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_ShipRateDetails(prefix, where, parameters, Mall_ShipRateDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_ShipRateDetail objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_ShipRateDetail objects.</returns>
		protected static EntityList<Mall_ShipRateDetail> GetMall_ShipRateDetails(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_ShipRateDetail.SelectFieldList + "FROM [dbo].[Mall_ShipRateDetail] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_ShipRateDetail>(reader);
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
        protected static EntityList<Mall_ShipRateDetail> GetMall_ShipRateDetails(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_ShipRateDetail>(SelectFieldList, "FROM [dbo].[Mall_ShipRateDetail] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_ShipRateDetail objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ShipRateDetailCount()
        {
            return GetMall_ShipRateDetailCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_ShipRateDetail objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_ShipRateDetailCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_ShipRateDetail] " + where;

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
		public static partial class Mall_ShipRateDetail_Properties
		{
			public const string ID = "ID";
			public const string RateID = "RateID";
			public const string DefaultQuantity = "DefaultQuantity";
			public const string DefaultMoney = "DefaultMoney";
			public const string AdditionalQuantity = "AdditionalQuantity";
			public const string AdditionalMoney = "AdditionalMoney";
			public const string IsDefault = "IsDefault";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RateID" , "int:"},
    			 {"DefaultQuantity" , "int:"},
    			 {"DefaultMoney" , "decimal:"},
    			 {"AdditionalQuantity" , "int:"},
    			 {"AdditionalMoney" , "decimal:"},
    			 {"IsDefault" , "bool:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
            };
		}
		#endregion
	}
}
