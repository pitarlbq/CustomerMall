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
	/// This object represents the properties and methods of a Cheque_OutingService.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Cheque_OutingService 
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
		private int _outingID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int OutingID
		{
			[DebuggerStepThrough()]
			get { return this._outingID; }
			set 
			{
				if (this._outingID != value) 
				{
					this._outingID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OutingID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _serviceName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceName
		{
			[DebuggerStepThrough()]
			get { return this._serviceName; }
			set 
			{
				if (this._serviceName != value) 
				{
					this._serviceName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _serviceAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceAddress
		{
			[DebuggerStepThrough()]
			get { return this._serviceAddress; }
			set 
			{
				if (this._serviceAddress != value) 
				{
					this._serviceAddress = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceAddress");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _serviceStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ServiceStartTime
		{
			[DebuggerStepThrough()]
			get { return this._serviceStartTime; }
			set 
			{
				if (this._serviceStartTime != value) 
				{
					this._serviceStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceStartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _serviceEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ServiceEndTime
		{
			[DebuggerStepThrough()]
			get { return this._serviceEndTime; }
			set 
			{
				if (this._serviceEndTime != value) 
				{
					this._serviceEndTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceEndTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _contractMoney = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ContractMoney
		{
			[DebuggerStepThrough()]
			get { return this._contractMoney; }
			set 
			{
				if (this._contractMoney != value) 
				{
					this._contractMoney = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractMoney");
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
	[OutingID] int,
	[ServiceName] nvarchar(500),
	[ServiceAddress] nvarchar(500),
	[ServiceStartTime] datetime,
	[ServiceEndTime] datetime,
	[ContractMoney] decimal(18, 2),
	[AddTime] datetime,
	[GUID] nvarchar(500)
);

INSERT INTO [dbo].[Cheque_OutingService] (
	[Cheque_OutingService].[OutingID],
	[Cheque_OutingService].[ServiceName],
	[Cheque_OutingService].[ServiceAddress],
	[Cheque_OutingService].[ServiceStartTime],
	[Cheque_OutingService].[ServiceEndTime],
	[Cheque_OutingService].[ContractMoney],
	[Cheque_OutingService].[AddTime],
	[Cheque_OutingService].[GUID]
) 
output 
	INSERTED.[ID],
	INSERTED.[OutingID],
	INSERTED.[ServiceName],
	INSERTED.[ServiceAddress],
	INSERTED.[ServiceStartTime],
	INSERTED.[ServiceEndTime],
	INSERTED.[ContractMoney],
	INSERTED.[AddTime],
	INSERTED.[GUID]
into @table
VALUES ( 
	@OutingID,
	@ServiceName,
	@ServiceAddress,
	@ServiceStartTime,
	@ServiceEndTime,
	@ContractMoney,
	@AddTime,
	@GUID 
); 

SELECT 
	[ID],
	[OutingID],
	[ServiceName],
	[ServiceAddress],
	[ServiceStartTime],
	[ServiceEndTime],
	[ContractMoney],
	[AddTime],
	[GUID] 
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
	[OutingID] int,
	[ServiceName] nvarchar(500),
	[ServiceAddress] nvarchar(500),
	[ServiceStartTime] datetime,
	[ServiceEndTime] datetime,
	[ContractMoney] decimal(18, 2),
	[AddTime] datetime,
	[GUID] nvarchar(500)
);

UPDATE [dbo].[Cheque_OutingService] SET 
	[Cheque_OutingService].[OutingID] = @OutingID,
	[Cheque_OutingService].[ServiceName] = @ServiceName,
	[Cheque_OutingService].[ServiceAddress] = @ServiceAddress,
	[Cheque_OutingService].[ServiceStartTime] = @ServiceStartTime,
	[Cheque_OutingService].[ServiceEndTime] = @ServiceEndTime,
	[Cheque_OutingService].[ContractMoney] = @ContractMoney,
	[Cheque_OutingService].[AddTime] = @AddTime,
	[Cheque_OutingService].[GUID] = @GUID 
output 
	INSERTED.[ID],
	INSERTED.[OutingID],
	INSERTED.[ServiceName],
	INSERTED.[ServiceAddress],
	INSERTED.[ServiceStartTime],
	INSERTED.[ServiceEndTime],
	INSERTED.[ContractMoney],
	INSERTED.[AddTime],
	INSERTED.[GUID]
into @table
WHERE 
	[Cheque_OutingService].[ID] = @ID

SELECT 
	[ID],
	[OutingID],
	[ServiceName],
	[ServiceAddress],
	[ServiceStartTime],
	[ServiceEndTime],
	[ContractMoney],
	[AddTime],
	[GUID] 
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
DELETE FROM [dbo].[Cheque_OutingService]
WHERE 
	[Cheque_OutingService].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Cheque_OutingService() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCheque_OutingService(this.ID));
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
	[Cheque_OutingService].[ID],
	[Cheque_OutingService].[OutingID],
	[Cheque_OutingService].[ServiceName],
	[Cheque_OutingService].[ServiceAddress],
	[Cheque_OutingService].[ServiceStartTime],
	[Cheque_OutingService].[ServiceEndTime],
	[Cheque_OutingService].[ContractMoney],
	[Cheque_OutingService].[AddTime],
	[Cheque_OutingService].[GUID]
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
                return "Cheque_OutingService";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Cheque_OutingService into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="outingID">outingID</param>
		/// <param name="serviceName">serviceName</param>
		/// <param name="serviceAddress">serviceAddress</param>
		/// <param name="serviceStartTime">serviceStartTime</param>
		/// <param name="serviceEndTime">serviceEndTime</param>
		/// <param name="contractMoney">contractMoney</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		public static void InsertCheque_OutingService(int @outingID, string @serviceName, string @serviceAddress, DateTime @serviceStartTime, DateTime @serviceEndTime, decimal @contractMoney, DateTime @addTime, string @gUID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCheque_OutingService(@outingID, @serviceName, @serviceAddress, @serviceStartTime, @serviceEndTime, @contractMoney, @addTime, @gUID, helper);
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
		/// Insert a Cheque_OutingService into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="outingID">outingID</param>
		/// <param name="serviceName">serviceName</param>
		/// <param name="serviceAddress">serviceAddress</param>
		/// <param name="serviceStartTime">serviceStartTime</param>
		/// <param name="serviceEndTime">serviceEndTime</param>
		/// <param name="contractMoney">contractMoney</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="helper">helper</param>
		internal static void InsertCheque_OutingService(int @outingID, string @serviceName, string @serviceAddress, DateTime @serviceStartTime, DateTime @serviceEndTime, decimal @contractMoney, DateTime @addTime, string @gUID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OutingID] int,
	[ServiceName] nvarchar(500),
	[ServiceAddress] nvarchar(500),
	[ServiceStartTime] datetime,
	[ServiceEndTime] datetime,
	[ContractMoney] decimal(18, 2),
	[AddTime] datetime,
	[GUID] nvarchar(500)
);

INSERT INTO [dbo].[Cheque_OutingService] (
	[Cheque_OutingService].[OutingID],
	[Cheque_OutingService].[ServiceName],
	[Cheque_OutingService].[ServiceAddress],
	[Cheque_OutingService].[ServiceStartTime],
	[Cheque_OutingService].[ServiceEndTime],
	[Cheque_OutingService].[ContractMoney],
	[Cheque_OutingService].[AddTime],
	[Cheque_OutingService].[GUID]
) 
output 
	INSERTED.[ID],
	INSERTED.[OutingID],
	INSERTED.[ServiceName],
	INSERTED.[ServiceAddress],
	INSERTED.[ServiceStartTime],
	INSERTED.[ServiceEndTime],
	INSERTED.[ContractMoney],
	INSERTED.[AddTime],
	INSERTED.[GUID]
into @table
VALUES ( 
	@OutingID,
	@ServiceName,
	@ServiceAddress,
	@ServiceStartTime,
	@ServiceEndTime,
	@ContractMoney,
	@AddTime,
	@GUID 
); 

SELECT 
	[ID],
	[OutingID],
	[ServiceName],
	[ServiceAddress],
	[ServiceStartTime],
	[ServiceEndTime],
	[ContractMoney],
	[AddTime],
	[GUID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OutingID", EntityBase.GetDatabaseValue(@outingID)));
			parameters.Add(new SqlParameter("@ServiceName", EntityBase.GetDatabaseValue(@serviceName)));
			parameters.Add(new SqlParameter("@ServiceAddress", EntityBase.GetDatabaseValue(@serviceAddress)));
			parameters.Add(new SqlParameter("@ServiceStartTime", EntityBase.GetDatabaseValue(@serviceStartTime)));
			parameters.Add(new SqlParameter("@ServiceEndTime", EntityBase.GetDatabaseValue(@serviceEndTime)));
			parameters.Add(new SqlParameter("@ContractMoney", EntityBase.GetDatabaseValue(@contractMoney)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Cheque_OutingService into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="outingID">outingID</param>
		/// <param name="serviceName">serviceName</param>
		/// <param name="serviceAddress">serviceAddress</param>
		/// <param name="serviceStartTime">serviceStartTime</param>
		/// <param name="serviceEndTime">serviceEndTime</param>
		/// <param name="contractMoney">contractMoney</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		public static void UpdateCheque_OutingService(int @iD, int @outingID, string @serviceName, string @serviceAddress, DateTime @serviceStartTime, DateTime @serviceEndTime, decimal @contractMoney, DateTime @addTime, string @gUID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCheque_OutingService(@iD, @outingID, @serviceName, @serviceAddress, @serviceStartTime, @serviceEndTime, @contractMoney, @addTime, @gUID, helper);
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
		/// Updates a Cheque_OutingService into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="outingID">outingID</param>
		/// <param name="serviceName">serviceName</param>
		/// <param name="serviceAddress">serviceAddress</param>
		/// <param name="serviceStartTime">serviceStartTime</param>
		/// <param name="serviceEndTime">serviceEndTime</param>
		/// <param name="contractMoney">contractMoney</param>
		/// <param name="addTime">addTime</param>
		/// <param name="gUID">gUID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCheque_OutingService(int @iD, int @outingID, string @serviceName, string @serviceAddress, DateTime @serviceStartTime, DateTime @serviceEndTime, decimal @contractMoney, DateTime @addTime, string @gUID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OutingID] int,
	[ServiceName] nvarchar(500),
	[ServiceAddress] nvarchar(500),
	[ServiceStartTime] datetime,
	[ServiceEndTime] datetime,
	[ContractMoney] decimal(18, 2),
	[AddTime] datetime,
	[GUID] nvarchar(500)
);

UPDATE [dbo].[Cheque_OutingService] SET 
	[Cheque_OutingService].[OutingID] = @OutingID,
	[Cheque_OutingService].[ServiceName] = @ServiceName,
	[Cheque_OutingService].[ServiceAddress] = @ServiceAddress,
	[Cheque_OutingService].[ServiceStartTime] = @ServiceStartTime,
	[Cheque_OutingService].[ServiceEndTime] = @ServiceEndTime,
	[Cheque_OutingService].[ContractMoney] = @ContractMoney,
	[Cheque_OutingService].[AddTime] = @AddTime,
	[Cheque_OutingService].[GUID] = @GUID 
output 
	INSERTED.[ID],
	INSERTED.[OutingID],
	INSERTED.[ServiceName],
	INSERTED.[ServiceAddress],
	INSERTED.[ServiceStartTime],
	INSERTED.[ServiceEndTime],
	INSERTED.[ContractMoney],
	INSERTED.[AddTime],
	INSERTED.[GUID]
into @table
WHERE 
	[Cheque_OutingService].[ID] = @ID

SELECT 
	[ID],
	[OutingID],
	[ServiceName],
	[ServiceAddress],
	[ServiceStartTime],
	[ServiceEndTime],
	[ContractMoney],
	[AddTime],
	[GUID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OutingID", EntityBase.GetDatabaseValue(@outingID)));
			parameters.Add(new SqlParameter("@ServiceName", EntityBase.GetDatabaseValue(@serviceName)));
			parameters.Add(new SqlParameter("@ServiceAddress", EntityBase.GetDatabaseValue(@serviceAddress)));
			parameters.Add(new SqlParameter("@ServiceStartTime", EntityBase.GetDatabaseValue(@serviceStartTime)));
			parameters.Add(new SqlParameter("@ServiceEndTime", EntityBase.GetDatabaseValue(@serviceEndTime)));
			parameters.Add(new SqlParameter("@ContractMoney", EntityBase.GetDatabaseValue(@contractMoney)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Cheque_OutingService from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCheque_OutingService(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCheque_OutingService(@iD, helper);
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
		/// Deletes a Cheque_OutingService from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCheque_OutingService(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Cheque_OutingService]
WHERE 
	[Cheque_OutingService].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Cheque_OutingService object.
		/// </summary>
		/// <returns>The newly created Cheque_OutingService object.</returns>
		public static Cheque_OutingService CreateCheque_OutingService()
		{
			return InitializeNew<Cheque_OutingService>();
		}
		
		/// <summary>
		/// Retrieve information for a Cheque_OutingService by a Cheque_OutingService's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Cheque_OutingService</returns>
		public static Cheque_OutingService GetCheque_OutingService(int @iD)
		{
			string commandText = @"
SELECT 
" + Cheque_OutingService.SelectFieldList + @"
FROM [dbo].[Cheque_OutingService] 
WHERE 
	[Cheque_OutingService].[ID] = @ID " + Cheque_OutingService.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_OutingService>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Cheque_OutingService by a Cheque_OutingService's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Cheque_OutingService</returns>
		public static Cheque_OutingService GetCheque_OutingService(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Cheque_OutingService.SelectFieldList + @"
FROM [dbo].[Cheque_OutingService] 
WHERE 
	[Cheque_OutingService].[ID] = @ID " + Cheque_OutingService.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Cheque_OutingService>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutingService objects.
		/// </summary>
		/// <returns>The retrieved collection of Cheque_OutingService objects.</returns>
		public static EntityList<Cheque_OutingService> GetCheque_OutingServices()
		{
			string commandText = @"
SELECT " + Cheque_OutingService.SelectFieldList + "FROM [dbo].[Cheque_OutingService] " + Cheque_OutingService.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Cheque_OutingService>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Cheque_OutingService objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_OutingService objects.</returns>
        public static EntityList<Cheque_OutingService> GetCheque_OutingServices(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_OutingService>(SelectFieldList, "FROM [dbo].[Cheque_OutingService]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Cheque_OutingService objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Cheque_OutingService objects.</returns>
        public static EntityList<Cheque_OutingService> GetCheque_OutingServices(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_OutingService>(SelectFieldList, "FROM [dbo].[Cheque_OutingService]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Cheque_OutingService objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_OutingService objects.</returns>
		protected static EntityList<Cheque_OutingService> GetCheque_OutingServices(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_OutingServices(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutingService objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_OutingService objects.</returns>
		protected static EntityList<Cheque_OutingService> GetCheque_OutingServices(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_OutingServices(string.Empty, where, parameters, Cheque_OutingService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutingService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Cheque_OutingService objects.</returns>
		protected static EntityList<Cheque_OutingService> GetCheque_OutingServices(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCheque_OutingServices(prefix, where, parameters, Cheque_OutingService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutingService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_OutingService objects.</returns>
		protected static EntityList<Cheque_OutingService> GetCheque_OutingServices(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_OutingServices(string.Empty, where, parameters, Cheque_OutingService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutingService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Cheque_OutingService objects.</returns>
		protected static EntityList<Cheque_OutingService> GetCheque_OutingServices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCheque_OutingServices(prefix, where, parameters, Cheque_OutingService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Cheque_OutingService objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Cheque_OutingService objects.</returns>
		protected static EntityList<Cheque_OutingService> GetCheque_OutingServices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Cheque_OutingService.SelectFieldList + "FROM [dbo].[Cheque_OutingService] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Cheque_OutingService>(reader);
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
        protected static EntityList<Cheque_OutingService> GetCheque_OutingServices(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Cheque_OutingService>(SelectFieldList, "FROM [dbo].[Cheque_OutingService] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Cheque_OutingService objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_OutingServiceCount()
        {
            return GetCheque_OutingServiceCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Cheque_OutingService objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCheque_OutingServiceCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Cheque_OutingService] " + where;

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
		public static partial class Cheque_OutingService_Properties
		{
			public const string ID = "ID";
			public const string OutingID = "OutingID";
			public const string ServiceName = "ServiceName";
			public const string ServiceAddress = "ServiceAddress";
			public const string ServiceStartTime = "ServiceStartTime";
			public const string ServiceEndTime = "ServiceEndTime";
			public const string ContractMoney = "ContractMoney";
			public const string AddTime = "AddTime";
			public const string GUID = "GUID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OutingID" , "int:"},
    			 {"ServiceName" , "string:"},
    			 {"ServiceAddress" , "string:"},
    			 {"ServiceStartTime" , "DateTime:"},
    			 {"ServiceEndTime" , "DateTime:"},
    			 {"ContractMoney" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"GUID" , "string:"},
            };
		}
		#endregion
	}
}
