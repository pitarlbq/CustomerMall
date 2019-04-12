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
	/// This object represents the properties and methods of a ChargeMeter.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ChargeMeter 
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
		private string _meterName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string MeterName
		{
			[DebuggerStepThrough()]
			get { return this._meterName; }
			set 
			{
				if (this._meterName != value) 
				{
					this._meterName = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _meterNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string MeterNumber
		{
			[DebuggerStepThrough()]
			get { return this._meterNumber; }
			set 
			{
				if (this._meterNumber != value) 
				{
					this._meterNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _meterCategoryID = int.MinValue;
		/// <summary>
		/// 1-水表 2-电表 3-气表
		/// </summary>
        [Description("1-水表 2-电表 3-气表")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int MeterCategoryID
		{
			[DebuggerStepThrough()]
			get { return this._meterCategoryID; }
			set 
			{
				if (this._meterCategoryID != value) 
				{
					this._meterCategoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterCategoryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _meterType = int.MinValue;
		/// <summary>
		/// 1-住户 2-公共
		/// </summary>
        [Description("1-住户 2-公共")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int MeterType
		{
			[DebuggerStepThrough()]
			get { return this._meterType; }
			set 
			{
				if (this._meterType != value) 
				{
					this._meterType = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _meterSpec = int.MinValue;
		/// <summary>
		/// 1-分表 2-总表
		/// </summary>
        [Description("1-分表 2-总表")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int MeterSpec
		{
			[DebuggerStepThrough()]
			get { return this._meterSpec; }
			set 
			{
				if (this._meterSpec != value) 
				{
					this._meterSpec = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterSpec");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _meterCoefficient = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal MeterCoefficient
		{
			[DebuggerStepThrough()]
			get { return this._meterCoefficient; }
			set 
			{
				if (this._meterCoefficient != value) 
				{
					this._meterCoefficient = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterCoefficient");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _meterRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string MeterRemark
		{
			[DebuggerStepThrough()]
			get { return this._meterRemark; }
			set 
			{
				if (this._meterRemark != value) 
				{
					this._meterRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterRemark");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _meterChargeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int MeterChargeID
		{
			[DebuggerStepThrough()]
			get { return this._meterChargeID; }
			set 
			{
				if (this._meterChargeID != value) 
				{
					this._meterChargeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterChargeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _meterHouseNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string MeterHouseNo
		{
			[DebuggerStepThrough()]
			get { return this._meterHouseNo; }
			set 
			{
				if (this._meterHouseNo != value) 
				{
					this._meterHouseNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterHouseNo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _meterLocation = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string MeterLocation
		{
			[DebuggerStepThrough()]
			get { return this._meterLocation; }
			set 
			{
				if (this._meterLocation != value) 
				{
					this._meterLocation = value;
					this.IsDirty = true;	
					OnPropertyChanged("MeterLocation");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _sortOrder = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SortOrder
		{
			[DebuggerStepThrough()]
			get { return this._sortOrder; }
			set 
			{
				if (this._sortOrder != value) 
				{
					this._sortOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("SortOrder");
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
	[MeterName] nvarchar(50),
	[MeterNumber] nvarchar(200),
	[MeterCategoryID] int,
	[MeterType] int,
	[MeterSpec] int,
	[MeterCoefficient] decimal(18, 4),
	[MeterRemark] ntext,
	[MeterChargeID] int,
	[MeterHouseNo] nvarchar(200),
	[MeterLocation] nvarchar(200),
	[SortOrder] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200)
);

INSERT INTO [dbo].[ChargeMeter] (
	[ChargeMeter].[MeterName],
	[ChargeMeter].[MeterNumber],
	[ChargeMeter].[MeterCategoryID],
	[ChargeMeter].[MeterType],
	[ChargeMeter].[MeterSpec],
	[ChargeMeter].[MeterCoefficient],
	[ChargeMeter].[MeterRemark],
	[ChargeMeter].[MeterChargeID],
	[ChargeMeter].[MeterHouseNo],
	[ChargeMeter].[MeterLocation],
	[ChargeMeter].[SortOrder],
	[ChargeMeter].[AddTime],
	[ChargeMeter].[AddUserName]
) 
output 
	INSERTED.[ID],
	INSERTED.[MeterName],
	INSERTED.[MeterNumber],
	INSERTED.[MeterCategoryID],
	INSERTED.[MeterType],
	INSERTED.[MeterSpec],
	INSERTED.[MeterCoefficient],
	INSERTED.[MeterRemark],
	INSERTED.[MeterChargeID],
	INSERTED.[MeterHouseNo],
	INSERTED.[MeterLocation],
	INSERTED.[SortOrder],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
VALUES ( 
	@MeterName,
	@MeterNumber,
	@MeterCategoryID,
	@MeterType,
	@MeterSpec,
	@MeterCoefficient,
	@MeterRemark,
	@MeterChargeID,
	@MeterHouseNo,
	@MeterLocation,
	@SortOrder,
	@AddTime,
	@AddUserName 
); 

SELECT 
	[ID],
	[MeterName],
	[MeterNumber],
	[MeterCategoryID],
	[MeterType],
	[MeterSpec],
	[MeterCoefficient],
	[MeterRemark],
	[MeterChargeID],
	[MeterHouseNo],
	[MeterLocation],
	[SortOrder],
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
	[MeterName] nvarchar(50),
	[MeterNumber] nvarchar(200),
	[MeterCategoryID] int,
	[MeterType] int,
	[MeterSpec] int,
	[MeterCoefficient] decimal(18, 4),
	[MeterRemark] ntext,
	[MeterChargeID] int,
	[MeterHouseNo] nvarchar(200),
	[MeterLocation] nvarchar(200),
	[SortOrder] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200)
);

UPDATE [dbo].[ChargeMeter] SET 
	[ChargeMeter].[MeterName] = @MeterName,
	[ChargeMeter].[MeterNumber] = @MeterNumber,
	[ChargeMeter].[MeterCategoryID] = @MeterCategoryID,
	[ChargeMeter].[MeterType] = @MeterType,
	[ChargeMeter].[MeterSpec] = @MeterSpec,
	[ChargeMeter].[MeterCoefficient] = @MeterCoefficient,
	[ChargeMeter].[MeterRemark] = @MeterRemark,
	[ChargeMeter].[MeterChargeID] = @MeterChargeID,
	[ChargeMeter].[MeterHouseNo] = @MeterHouseNo,
	[ChargeMeter].[MeterLocation] = @MeterLocation,
	[ChargeMeter].[SortOrder] = @SortOrder,
	[ChargeMeter].[AddTime] = @AddTime,
	[ChargeMeter].[AddUserName] = @AddUserName 
output 
	INSERTED.[ID],
	INSERTED.[MeterName],
	INSERTED.[MeterNumber],
	INSERTED.[MeterCategoryID],
	INSERTED.[MeterType],
	INSERTED.[MeterSpec],
	INSERTED.[MeterCoefficient],
	INSERTED.[MeterRemark],
	INSERTED.[MeterChargeID],
	INSERTED.[MeterHouseNo],
	INSERTED.[MeterLocation],
	INSERTED.[SortOrder],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
WHERE 
	[ChargeMeter].[ID] = @ID

SELECT 
	[ID],
	[MeterName],
	[MeterNumber],
	[MeterCategoryID],
	[MeterType],
	[MeterSpec],
	[MeterCoefficient],
	[MeterRemark],
	[MeterChargeID],
	[MeterHouseNo],
	[MeterLocation],
	[SortOrder],
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
DELETE FROM [dbo].[ChargeMeter]
WHERE 
	[ChargeMeter].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ChargeMeter() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetChargeMeter(this.ID));
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
	[ChargeMeter].[ID],
	[ChargeMeter].[MeterName],
	[ChargeMeter].[MeterNumber],
	[ChargeMeter].[MeterCategoryID],
	[ChargeMeter].[MeterType],
	[ChargeMeter].[MeterSpec],
	[ChargeMeter].[MeterCoefficient],
	[ChargeMeter].[MeterRemark],
	[ChargeMeter].[MeterChargeID],
	[ChargeMeter].[MeterHouseNo],
	[ChargeMeter].[MeterLocation],
	[ChargeMeter].[SortOrder],
	[ChargeMeter].[AddTime],
	[ChargeMeter].[AddUserName]
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
                return "ChargeMeter";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ChargeMeter into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="meterName">meterName</param>
		/// <param name="meterNumber">meterNumber</param>
		/// <param name="meterCategoryID">meterCategoryID</param>
		/// <param name="meterType">meterType</param>
		/// <param name="meterSpec">meterSpec</param>
		/// <param name="meterCoefficient">meterCoefficient</param>
		/// <param name="meterRemark">meterRemark</param>
		/// <param name="meterChargeID">meterChargeID</param>
		/// <param name="meterHouseNo">meterHouseNo</param>
		/// <param name="meterLocation">meterLocation</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		public static void InsertChargeMeter(string @meterName, string @meterNumber, int @meterCategoryID, int @meterType, int @meterSpec, decimal @meterCoefficient, string @meterRemark, int @meterChargeID, string @meterHouseNo, string @meterLocation, int @sortOrder, DateTime @addTime, string @addUserName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertChargeMeter(@meterName, @meterNumber, @meterCategoryID, @meterType, @meterSpec, @meterCoefficient, @meterRemark, @meterChargeID, @meterHouseNo, @meterLocation, @sortOrder, @addTime, @addUserName, helper);
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
		/// Insert a ChargeMeter into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="meterName">meterName</param>
		/// <param name="meterNumber">meterNumber</param>
		/// <param name="meterCategoryID">meterCategoryID</param>
		/// <param name="meterType">meterType</param>
		/// <param name="meterSpec">meterSpec</param>
		/// <param name="meterCoefficient">meterCoefficient</param>
		/// <param name="meterRemark">meterRemark</param>
		/// <param name="meterChargeID">meterChargeID</param>
		/// <param name="meterHouseNo">meterHouseNo</param>
		/// <param name="meterLocation">meterLocation</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="helper">helper</param>
		internal static void InsertChargeMeter(string @meterName, string @meterNumber, int @meterCategoryID, int @meterType, int @meterSpec, decimal @meterCoefficient, string @meterRemark, int @meterChargeID, string @meterHouseNo, string @meterLocation, int @sortOrder, DateTime @addTime, string @addUserName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[MeterName] nvarchar(50),
	[MeterNumber] nvarchar(200),
	[MeterCategoryID] int,
	[MeterType] int,
	[MeterSpec] int,
	[MeterCoefficient] decimal(18, 4),
	[MeterRemark] ntext,
	[MeterChargeID] int,
	[MeterHouseNo] nvarchar(200),
	[MeterLocation] nvarchar(200),
	[SortOrder] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200)
);

INSERT INTO [dbo].[ChargeMeter] (
	[ChargeMeter].[MeterName],
	[ChargeMeter].[MeterNumber],
	[ChargeMeter].[MeterCategoryID],
	[ChargeMeter].[MeterType],
	[ChargeMeter].[MeterSpec],
	[ChargeMeter].[MeterCoefficient],
	[ChargeMeter].[MeterRemark],
	[ChargeMeter].[MeterChargeID],
	[ChargeMeter].[MeterHouseNo],
	[ChargeMeter].[MeterLocation],
	[ChargeMeter].[SortOrder],
	[ChargeMeter].[AddTime],
	[ChargeMeter].[AddUserName]
) 
output 
	INSERTED.[ID],
	INSERTED.[MeterName],
	INSERTED.[MeterNumber],
	INSERTED.[MeterCategoryID],
	INSERTED.[MeterType],
	INSERTED.[MeterSpec],
	INSERTED.[MeterCoefficient],
	INSERTED.[MeterRemark],
	INSERTED.[MeterChargeID],
	INSERTED.[MeterHouseNo],
	INSERTED.[MeterLocation],
	INSERTED.[SortOrder],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
VALUES ( 
	@MeterName,
	@MeterNumber,
	@MeterCategoryID,
	@MeterType,
	@MeterSpec,
	@MeterCoefficient,
	@MeterRemark,
	@MeterChargeID,
	@MeterHouseNo,
	@MeterLocation,
	@SortOrder,
	@AddTime,
	@AddUserName 
); 

SELECT 
	[ID],
	[MeterName],
	[MeterNumber],
	[MeterCategoryID],
	[MeterType],
	[MeterSpec],
	[MeterCoefficient],
	[MeterRemark],
	[MeterChargeID],
	[MeterHouseNo],
	[MeterLocation],
	[SortOrder],
	[AddTime],
	[AddUserName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@MeterName", EntityBase.GetDatabaseValue(@meterName)));
			parameters.Add(new SqlParameter("@MeterNumber", EntityBase.GetDatabaseValue(@meterNumber)));
			parameters.Add(new SqlParameter("@MeterCategoryID", EntityBase.GetDatabaseValue(@meterCategoryID)));
			parameters.Add(new SqlParameter("@MeterType", EntityBase.GetDatabaseValue(@meterType)));
			parameters.Add(new SqlParameter("@MeterSpec", EntityBase.GetDatabaseValue(@meterSpec)));
			parameters.Add(new SqlParameter("@MeterCoefficient", EntityBase.GetDatabaseValue(@meterCoefficient)));
			parameters.Add(new SqlParameter("@MeterRemark", EntityBase.GetDatabaseValue(@meterRemark)));
			parameters.Add(new SqlParameter("@MeterChargeID", EntityBase.GetDatabaseValue(@meterChargeID)));
			parameters.Add(new SqlParameter("@MeterHouseNo", EntityBase.GetDatabaseValue(@meterHouseNo)));
			parameters.Add(new SqlParameter("@MeterLocation", EntityBase.GetDatabaseValue(@meterLocation)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ChargeMeter into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="meterName">meterName</param>
		/// <param name="meterNumber">meterNumber</param>
		/// <param name="meterCategoryID">meterCategoryID</param>
		/// <param name="meterType">meterType</param>
		/// <param name="meterSpec">meterSpec</param>
		/// <param name="meterCoefficient">meterCoefficient</param>
		/// <param name="meterRemark">meterRemark</param>
		/// <param name="meterChargeID">meterChargeID</param>
		/// <param name="meterHouseNo">meterHouseNo</param>
		/// <param name="meterLocation">meterLocation</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		public static void UpdateChargeMeter(int @iD, string @meterName, string @meterNumber, int @meterCategoryID, int @meterType, int @meterSpec, decimal @meterCoefficient, string @meterRemark, int @meterChargeID, string @meterHouseNo, string @meterLocation, int @sortOrder, DateTime @addTime, string @addUserName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateChargeMeter(@iD, @meterName, @meterNumber, @meterCategoryID, @meterType, @meterSpec, @meterCoefficient, @meterRemark, @meterChargeID, @meterHouseNo, @meterLocation, @sortOrder, @addTime, @addUserName, helper);
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
		/// Updates a ChargeMeter into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="meterName">meterName</param>
		/// <param name="meterNumber">meterNumber</param>
		/// <param name="meterCategoryID">meterCategoryID</param>
		/// <param name="meterType">meterType</param>
		/// <param name="meterSpec">meterSpec</param>
		/// <param name="meterCoefficient">meterCoefficient</param>
		/// <param name="meterRemark">meterRemark</param>
		/// <param name="meterChargeID">meterChargeID</param>
		/// <param name="meterHouseNo">meterHouseNo</param>
		/// <param name="meterLocation">meterLocation</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateChargeMeter(int @iD, string @meterName, string @meterNumber, int @meterCategoryID, int @meterType, int @meterSpec, decimal @meterCoefficient, string @meterRemark, int @meterChargeID, string @meterHouseNo, string @meterLocation, int @sortOrder, DateTime @addTime, string @addUserName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[MeterName] nvarchar(50),
	[MeterNumber] nvarchar(200),
	[MeterCategoryID] int,
	[MeterType] int,
	[MeterSpec] int,
	[MeterCoefficient] decimal(18, 4),
	[MeterRemark] ntext,
	[MeterChargeID] int,
	[MeterHouseNo] nvarchar(200),
	[MeterLocation] nvarchar(200),
	[SortOrder] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200)
);

UPDATE [dbo].[ChargeMeter] SET 
	[ChargeMeter].[MeterName] = @MeterName,
	[ChargeMeter].[MeterNumber] = @MeterNumber,
	[ChargeMeter].[MeterCategoryID] = @MeterCategoryID,
	[ChargeMeter].[MeterType] = @MeterType,
	[ChargeMeter].[MeterSpec] = @MeterSpec,
	[ChargeMeter].[MeterCoefficient] = @MeterCoefficient,
	[ChargeMeter].[MeterRemark] = @MeterRemark,
	[ChargeMeter].[MeterChargeID] = @MeterChargeID,
	[ChargeMeter].[MeterHouseNo] = @MeterHouseNo,
	[ChargeMeter].[MeterLocation] = @MeterLocation,
	[ChargeMeter].[SortOrder] = @SortOrder,
	[ChargeMeter].[AddTime] = @AddTime,
	[ChargeMeter].[AddUserName] = @AddUserName 
output 
	INSERTED.[ID],
	INSERTED.[MeterName],
	INSERTED.[MeterNumber],
	INSERTED.[MeterCategoryID],
	INSERTED.[MeterType],
	INSERTED.[MeterSpec],
	INSERTED.[MeterCoefficient],
	INSERTED.[MeterRemark],
	INSERTED.[MeterChargeID],
	INSERTED.[MeterHouseNo],
	INSERTED.[MeterLocation],
	INSERTED.[SortOrder],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
WHERE 
	[ChargeMeter].[ID] = @ID

SELECT 
	[ID],
	[MeterName],
	[MeterNumber],
	[MeterCategoryID],
	[MeterType],
	[MeterSpec],
	[MeterCoefficient],
	[MeterRemark],
	[MeterChargeID],
	[MeterHouseNo],
	[MeterLocation],
	[SortOrder],
	[AddTime],
	[AddUserName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@MeterName", EntityBase.GetDatabaseValue(@meterName)));
			parameters.Add(new SqlParameter("@MeterNumber", EntityBase.GetDatabaseValue(@meterNumber)));
			parameters.Add(new SqlParameter("@MeterCategoryID", EntityBase.GetDatabaseValue(@meterCategoryID)));
			parameters.Add(new SqlParameter("@MeterType", EntityBase.GetDatabaseValue(@meterType)));
			parameters.Add(new SqlParameter("@MeterSpec", EntityBase.GetDatabaseValue(@meterSpec)));
			parameters.Add(new SqlParameter("@MeterCoefficient", EntityBase.GetDatabaseValue(@meterCoefficient)));
			parameters.Add(new SqlParameter("@MeterRemark", EntityBase.GetDatabaseValue(@meterRemark)));
			parameters.Add(new SqlParameter("@MeterChargeID", EntityBase.GetDatabaseValue(@meterChargeID)));
			parameters.Add(new SqlParameter("@MeterHouseNo", EntityBase.GetDatabaseValue(@meterHouseNo)));
			parameters.Add(new SqlParameter("@MeterLocation", EntityBase.GetDatabaseValue(@meterLocation)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ChargeMeter from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteChargeMeter(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteChargeMeter(@iD, helper);
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
		/// Deletes a ChargeMeter from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteChargeMeter(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ChargeMeter]
WHERE 
	[ChargeMeter].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ChargeMeter object.
		/// </summary>
		/// <returns>The newly created ChargeMeter object.</returns>
		public static ChargeMeter CreateChargeMeter()
		{
			return InitializeNew<ChargeMeter>();
		}
		
		/// <summary>
		/// Retrieve information for a ChargeMeter by a ChargeMeter's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ChargeMeter</returns>
		public static ChargeMeter GetChargeMeter(int @iD)
		{
			string commandText = @"
SELECT 
" + ChargeMeter.SelectFieldList + @"
FROM [dbo].[ChargeMeter] 
WHERE 
	[ChargeMeter].[ID] = @ID " + ChargeMeter.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeMeter>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ChargeMeter by a ChargeMeter's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ChargeMeter</returns>
		public static ChargeMeter GetChargeMeter(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ChargeMeter.SelectFieldList + @"
FROM [dbo].[ChargeMeter] 
WHERE 
	[ChargeMeter].[ID] = @ID " + ChargeMeter.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeMeter>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ChargeMeter objects.
		/// </summary>
		/// <returns>The retrieved collection of ChargeMeter objects.</returns>
		public static EntityList<ChargeMeter> GetChargeMeters()
		{
			string commandText = @"
SELECT " + ChargeMeter.SelectFieldList + "FROM [dbo].[ChargeMeter] " + ChargeMeter.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ChargeMeter>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ChargeMeter objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeMeter objects.</returns>
        public static EntityList<ChargeMeter> GetChargeMeters(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeMeter>(SelectFieldList, "FROM [dbo].[ChargeMeter]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ChargeMeter objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeMeter objects.</returns>
        public static EntityList<ChargeMeter> GetChargeMeters(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeMeter>(SelectFieldList, "FROM [dbo].[ChargeMeter]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ChargeMeter objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ChargeMeter objects.</returns>
		protected static EntityList<ChargeMeter> GetChargeMeters(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeMeters(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ChargeMeter objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeMeter objects.</returns>
		protected static EntityList<ChargeMeter> GetChargeMeters(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeMeters(string.Empty, where, parameters, ChargeMeter.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeMeter objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeMeter objects.</returns>
		protected static EntityList<ChargeMeter> GetChargeMeters(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeMeters(prefix, where, parameters, ChargeMeter.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeMeter objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeMeter objects.</returns>
		protected static EntityList<ChargeMeter> GetChargeMeters(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeMeters(string.Empty, where, parameters, ChargeMeter.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeMeter objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeMeter objects.</returns>
		protected static EntityList<ChargeMeter> GetChargeMeters(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeMeters(prefix, where, parameters, ChargeMeter.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeMeter objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ChargeMeter objects.</returns>
		protected static EntityList<ChargeMeter> GetChargeMeters(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ChargeMeter.SelectFieldList + "FROM [dbo].[ChargeMeter] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ChargeMeter>(reader);
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
        protected static EntityList<ChargeMeter> GetChargeMeters(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeMeter>(SelectFieldList, "FROM [dbo].[ChargeMeter] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ChargeMeter objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargeMeterCount()
        {
            return GetChargeMeterCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ChargeMeter objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargeMeterCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ChargeMeter] " + where;

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
		public static partial class ChargeMeter_Properties
		{
			public const string ID = "ID";
			public const string MeterName = "MeterName";
			public const string MeterNumber = "MeterNumber";
			public const string MeterCategoryID = "MeterCategoryID";
			public const string MeterType = "MeterType";
			public const string MeterSpec = "MeterSpec";
			public const string MeterCoefficient = "MeterCoefficient";
			public const string MeterRemark = "MeterRemark";
			public const string MeterChargeID = "MeterChargeID";
			public const string MeterHouseNo = "MeterHouseNo";
			public const string MeterLocation = "MeterLocation";
			public const string SortOrder = "SortOrder";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"MeterName" , "string:"},
    			 {"MeterNumber" , "string:"},
    			 {"MeterCategoryID" , "int:1-水表 2-电表 3-气表"},
    			 {"MeterType" , "int:1-住户 2-公共"},
    			 {"MeterSpec" , "int:1-分表 2-总表"},
    			 {"MeterCoefficient" , "decimal:"},
    			 {"MeterRemark" , "string:"},
    			 {"MeterChargeID" , "int:"},
    			 {"MeterHouseNo" , "string:"},
    			 {"MeterLocation" , "string:"},
    			 {"SortOrder" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
            };
		}
		#endregion
	}
}
