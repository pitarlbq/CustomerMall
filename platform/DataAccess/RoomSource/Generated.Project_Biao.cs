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
	/// This object represents the properties and methods of a Project_Biao.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Project_Biao 
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
		private int _projectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ProjectID
		{
			[DebuggerStepThrough()]
			get { return this._projectID; }
			set 
			{
				if (this._projectID != value) 
				{
					this._projectID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _biaoID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int BiaoID
		{
			[DebuggerStepThrough()]
			get { return this._biaoID; }
			set 
			{
				if (this._biaoID != value) 
				{
					this._biaoID = value;
					this.IsDirty = true;	
					OnPropertyChanged("BiaoID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isActive = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsActive
		{
			[DebuggerStepThrough()]
			get { return this._isActive; }
			set 
			{
				if (this._isActive != value) 
				{
					this._isActive = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsActive");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _biaoCategory = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BiaoCategory
		{
			[DebuggerStepThrough()]
			get { return this._biaoCategory; }
			set 
			{
				if (this._biaoCategory != value) 
				{
					this._biaoCategory = value;
					this.IsDirty = true;	
					OnPropertyChanged("BiaoCategory");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _biaoName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BiaoName
		{
			[DebuggerStepThrough()]
			get { return this._biaoName; }
			set 
			{
				if (this._biaoName != value) 
				{
					this._biaoName = value;
					this.IsDirty = true;	
					OnPropertyChanged("BiaoName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _biaoGuiGe = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BiaoGuiGe
		{
			[DebuggerStepThrough()]
			get { return this._biaoGuiGe; }
			set 
			{
				if (this._biaoGuiGe != value) 
				{
					this._biaoGuiGe = value;
					this.IsDirty = true;	
					OnPropertyChanged("BiaoGuiGe");
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
		private decimal _rate = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal Rate
		{
			[DebuggerStepThrough()]
			get { return this._rate; }
			set 
			{
				if (this._rate != value) 
				{
					this._rate = value;
					this.IsDirty = true;	
					OnPropertyChanged("Rate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _startPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal StartPoint
		{
			[DebuggerStepThrough()]
			get { return this._startPoint; }
			set 
			{
				if (this._startPoint != value) 
				{
					this._startPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("StartPoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _endPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal EndPoint
		{
			[DebuggerStepThrough()]
			get { return this._endPoint; }
			set 
			{
				if (this._endPoint != value) 
				{
					this._endPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndPoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalPoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalPoint
		{
			[DebuggerStepThrough()]
			get { return this._totalPoint; }
			set 
			{
				if (this._totalPoint != value) 
				{
					this._totalPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalPoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _reducePoint = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ReducePoint
		{
			[DebuggerStepThrough()]
			get { return this._reducePoint; }
			set 
			{
				if (this._reducePoint != value) 
				{
					this._reducePoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("ReducePoint");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChargeID
		{
			[DebuggerStepThrough()]
			get { return this._chargeID; }
			set 
			{
				if (this._chargeID != value) 
				{
					this._chargeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeID");
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
		private DateTime _writeDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime WriteDate
		{
			[DebuggerStepThrough()]
			get { return this._writeDate; }
			set 
			{
				if (this._writeDate != value) 
				{
					this._writeDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("WriteDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _coefficient = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal Coefficient
		{
			[DebuggerStepThrough()]
			get { return this._coefficient; }
			set 
			{
				if (this._coefficient != value) 
				{
					this._coefficient = value;
					this.IsDirty = true;	
					OnPropertyChanged("Coefficient");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeRoomNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeRoomNo
		{
			[DebuggerStepThrough()]
			get { return this._chargeRoomNo; }
			set 
			{
				if (this._chargeRoomNo != value) 
				{
					this._chargeRoomNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeRoomNo");
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
	[ProjectID] int,
	[BiaoID] int,
	[IsActive] bit,
	[BiaoCategory] nvarchar(50),
	[BiaoName] nvarchar(50),
	[BiaoGuiGe] nvarchar(50),
	[Remark] ntext,
	[Rate] decimal(18, 4),
	[StartPoint] decimal(18, 2),
	[EndPoint] decimal(18, 2),
	[TotalPoint] decimal(18, 2),
	[ReducePoint] decimal(18, 2),
	[ChargeID] int,
	[UnitPrice] decimal(18, 4),
	[WriteDate] datetime,
	[Coefficient] decimal(18, 4),
	[ChargeRoomNo] nvarchar(200)
);

INSERT INTO [dbo].[Project_Biao] (
	[Project_Biao].[ProjectID],
	[Project_Biao].[BiaoID],
	[Project_Biao].[IsActive],
	[Project_Biao].[BiaoCategory],
	[Project_Biao].[BiaoName],
	[Project_Biao].[BiaoGuiGe],
	[Project_Biao].[Remark],
	[Project_Biao].[Rate],
	[Project_Biao].[StartPoint],
	[Project_Biao].[EndPoint],
	[Project_Biao].[TotalPoint],
	[Project_Biao].[ReducePoint],
	[Project_Biao].[ChargeID],
	[Project_Biao].[UnitPrice],
	[Project_Biao].[WriteDate],
	[Project_Biao].[Coefficient],
	[Project_Biao].[ChargeRoomNo]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[BiaoID],
	INSERTED.[IsActive],
	INSERTED.[BiaoCategory],
	INSERTED.[BiaoName],
	INSERTED.[BiaoGuiGe],
	INSERTED.[Remark],
	INSERTED.[Rate],
	INSERTED.[StartPoint],
	INSERTED.[EndPoint],
	INSERTED.[TotalPoint],
	INSERTED.[ReducePoint],
	INSERTED.[ChargeID],
	INSERTED.[UnitPrice],
	INSERTED.[WriteDate],
	INSERTED.[Coefficient],
	INSERTED.[ChargeRoomNo]
into @table
VALUES ( 
	@ProjectID,
	@BiaoID,
	@IsActive,
	@BiaoCategory,
	@BiaoName,
	@BiaoGuiGe,
	@Remark,
	@Rate,
	@StartPoint,
	@EndPoint,
	@TotalPoint,
	@ReducePoint,
	@ChargeID,
	@UnitPrice,
	@WriteDate,
	@Coefficient,
	@ChargeRoomNo 
); 

SELECT 
	[ID],
	[ProjectID],
	[BiaoID],
	[IsActive],
	[BiaoCategory],
	[BiaoName],
	[BiaoGuiGe],
	[Remark],
	[Rate],
	[StartPoint],
	[EndPoint],
	[TotalPoint],
	[ReducePoint],
	[ChargeID],
	[UnitPrice],
	[WriteDate],
	[Coefficient],
	[ChargeRoomNo] 
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
	[ProjectID] int,
	[BiaoID] int,
	[IsActive] bit,
	[BiaoCategory] nvarchar(50),
	[BiaoName] nvarchar(50),
	[BiaoGuiGe] nvarchar(50),
	[Remark] ntext,
	[Rate] decimal(18, 4),
	[StartPoint] decimal(18, 2),
	[EndPoint] decimal(18, 2),
	[TotalPoint] decimal(18, 2),
	[ReducePoint] decimal(18, 2),
	[ChargeID] int,
	[UnitPrice] decimal(18, 4),
	[WriteDate] datetime,
	[Coefficient] decimal(18, 4),
	[ChargeRoomNo] nvarchar(200)
);

UPDATE [dbo].[Project_Biao] SET 
	[Project_Biao].[ProjectID] = @ProjectID,
	[Project_Biao].[BiaoID] = @BiaoID,
	[Project_Biao].[IsActive] = @IsActive,
	[Project_Biao].[BiaoCategory] = @BiaoCategory,
	[Project_Biao].[BiaoName] = @BiaoName,
	[Project_Biao].[BiaoGuiGe] = @BiaoGuiGe,
	[Project_Biao].[Remark] = @Remark,
	[Project_Biao].[Rate] = @Rate,
	[Project_Biao].[StartPoint] = @StartPoint,
	[Project_Biao].[EndPoint] = @EndPoint,
	[Project_Biao].[TotalPoint] = @TotalPoint,
	[Project_Biao].[ReducePoint] = @ReducePoint,
	[Project_Biao].[ChargeID] = @ChargeID,
	[Project_Biao].[UnitPrice] = @UnitPrice,
	[Project_Biao].[WriteDate] = @WriteDate,
	[Project_Biao].[Coefficient] = @Coefficient,
	[Project_Biao].[ChargeRoomNo] = @ChargeRoomNo 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[BiaoID],
	INSERTED.[IsActive],
	INSERTED.[BiaoCategory],
	INSERTED.[BiaoName],
	INSERTED.[BiaoGuiGe],
	INSERTED.[Remark],
	INSERTED.[Rate],
	INSERTED.[StartPoint],
	INSERTED.[EndPoint],
	INSERTED.[TotalPoint],
	INSERTED.[ReducePoint],
	INSERTED.[ChargeID],
	INSERTED.[UnitPrice],
	INSERTED.[WriteDate],
	INSERTED.[Coefficient],
	INSERTED.[ChargeRoomNo]
into @table
WHERE 
	[Project_Biao].[ID] = @ID

SELECT 
	[ID],
	[ProjectID],
	[BiaoID],
	[IsActive],
	[BiaoCategory],
	[BiaoName],
	[BiaoGuiGe],
	[Remark],
	[Rate],
	[StartPoint],
	[EndPoint],
	[TotalPoint],
	[ReducePoint],
	[ChargeID],
	[UnitPrice],
	[WriteDate],
	[Coefficient],
	[ChargeRoomNo] 
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
DELETE FROM [dbo].[Project_Biao]
WHERE 
	[Project_Biao].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Project_Biao() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetProject_Biao(this.ID));
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
	[Project_Biao].[ID],
	[Project_Biao].[ProjectID],
	[Project_Biao].[BiaoID],
	[Project_Biao].[IsActive],
	[Project_Biao].[BiaoCategory],
	[Project_Biao].[BiaoName],
	[Project_Biao].[BiaoGuiGe],
	[Project_Biao].[Remark],
	[Project_Biao].[Rate],
	[Project_Biao].[StartPoint],
	[Project_Biao].[EndPoint],
	[Project_Biao].[TotalPoint],
	[Project_Biao].[ReducePoint],
	[Project_Biao].[ChargeID],
	[Project_Biao].[UnitPrice],
	[Project_Biao].[WriteDate],
	[Project_Biao].[Coefficient],
	[Project_Biao].[ChargeRoomNo]
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
                return "Project_Biao";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Project_Biao into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="biaoID">biaoID</param>
		/// <param name="isActive">isActive</param>
		/// <param name="biaoCategory">biaoCategory</param>
		/// <param name="biaoName">biaoName</param>
		/// <param name="biaoGuiGe">biaoGuiGe</param>
		/// <param name="remark">remark</param>
		/// <param name="rate">rate</param>
		/// <param name="startPoint">startPoint</param>
		/// <param name="endPoint">endPoint</param>
		/// <param name="totalPoint">totalPoint</param>
		/// <param name="reducePoint">reducePoint</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="coefficient">coefficient</param>
		/// <param name="chargeRoomNo">chargeRoomNo</param>
		public static void InsertProject_Biao(int @projectID, int @biaoID, bool @isActive, string @biaoCategory, string @biaoName, string @biaoGuiGe, string @remark, decimal @rate, decimal @startPoint, decimal @endPoint, decimal @totalPoint, decimal @reducePoint, int @chargeID, decimal @unitPrice, DateTime @writeDate, decimal @coefficient, string @chargeRoomNo)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertProject_Biao(@projectID, @biaoID, @isActive, @biaoCategory, @biaoName, @biaoGuiGe, @remark, @rate, @startPoint, @endPoint, @totalPoint, @reducePoint, @chargeID, @unitPrice, @writeDate, @coefficient, @chargeRoomNo, helper);
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
		/// Insert a Project_Biao into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="biaoID">biaoID</param>
		/// <param name="isActive">isActive</param>
		/// <param name="biaoCategory">biaoCategory</param>
		/// <param name="biaoName">biaoName</param>
		/// <param name="biaoGuiGe">biaoGuiGe</param>
		/// <param name="remark">remark</param>
		/// <param name="rate">rate</param>
		/// <param name="startPoint">startPoint</param>
		/// <param name="endPoint">endPoint</param>
		/// <param name="totalPoint">totalPoint</param>
		/// <param name="reducePoint">reducePoint</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="coefficient">coefficient</param>
		/// <param name="chargeRoomNo">chargeRoomNo</param>
		/// <param name="helper">helper</param>
		internal static void InsertProject_Biao(int @projectID, int @biaoID, bool @isActive, string @biaoCategory, string @biaoName, string @biaoGuiGe, string @remark, decimal @rate, decimal @startPoint, decimal @endPoint, decimal @totalPoint, decimal @reducePoint, int @chargeID, decimal @unitPrice, DateTime @writeDate, decimal @coefficient, string @chargeRoomNo, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectID] int,
	[BiaoID] int,
	[IsActive] bit,
	[BiaoCategory] nvarchar(50),
	[BiaoName] nvarchar(50),
	[BiaoGuiGe] nvarchar(50),
	[Remark] ntext,
	[Rate] decimal(18, 4),
	[StartPoint] decimal(18, 2),
	[EndPoint] decimal(18, 2),
	[TotalPoint] decimal(18, 2),
	[ReducePoint] decimal(18, 2),
	[ChargeID] int,
	[UnitPrice] decimal(18, 4),
	[WriteDate] datetime,
	[Coefficient] decimal(18, 4),
	[ChargeRoomNo] nvarchar(200)
);

INSERT INTO [dbo].[Project_Biao] (
	[Project_Biao].[ProjectID],
	[Project_Biao].[BiaoID],
	[Project_Biao].[IsActive],
	[Project_Biao].[BiaoCategory],
	[Project_Biao].[BiaoName],
	[Project_Biao].[BiaoGuiGe],
	[Project_Biao].[Remark],
	[Project_Biao].[Rate],
	[Project_Biao].[StartPoint],
	[Project_Biao].[EndPoint],
	[Project_Biao].[TotalPoint],
	[Project_Biao].[ReducePoint],
	[Project_Biao].[ChargeID],
	[Project_Biao].[UnitPrice],
	[Project_Biao].[WriteDate],
	[Project_Biao].[Coefficient],
	[Project_Biao].[ChargeRoomNo]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[BiaoID],
	INSERTED.[IsActive],
	INSERTED.[BiaoCategory],
	INSERTED.[BiaoName],
	INSERTED.[BiaoGuiGe],
	INSERTED.[Remark],
	INSERTED.[Rate],
	INSERTED.[StartPoint],
	INSERTED.[EndPoint],
	INSERTED.[TotalPoint],
	INSERTED.[ReducePoint],
	INSERTED.[ChargeID],
	INSERTED.[UnitPrice],
	INSERTED.[WriteDate],
	INSERTED.[Coefficient],
	INSERTED.[ChargeRoomNo]
into @table
VALUES ( 
	@ProjectID,
	@BiaoID,
	@IsActive,
	@BiaoCategory,
	@BiaoName,
	@BiaoGuiGe,
	@Remark,
	@Rate,
	@StartPoint,
	@EndPoint,
	@TotalPoint,
	@ReducePoint,
	@ChargeID,
	@UnitPrice,
	@WriteDate,
	@Coefficient,
	@ChargeRoomNo 
); 

SELECT 
	[ID],
	[ProjectID],
	[BiaoID],
	[IsActive],
	[BiaoCategory],
	[BiaoName],
	[BiaoGuiGe],
	[Remark],
	[Rate],
	[StartPoint],
	[EndPoint],
	[TotalPoint],
	[ReducePoint],
	[ChargeID],
	[UnitPrice],
	[WriteDate],
	[Coefficient],
	[ChargeRoomNo] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@BiaoID", EntityBase.GetDatabaseValue(@biaoID)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@BiaoCategory", EntityBase.GetDatabaseValue(@biaoCategory)));
			parameters.Add(new SqlParameter("@BiaoName", EntityBase.GetDatabaseValue(@biaoName)));
			parameters.Add(new SqlParameter("@BiaoGuiGe", EntityBase.GetDatabaseValue(@biaoGuiGe)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@Rate", EntityBase.GetDatabaseValue(@rate)));
			parameters.Add(new SqlParameter("@StartPoint", EntityBase.GetDatabaseValue(@startPoint)));
			parameters.Add(new SqlParameter("@EndPoint", EntityBase.GetDatabaseValue(@endPoint)));
			parameters.Add(new SqlParameter("@TotalPoint", EntityBase.GetDatabaseValue(@totalPoint)));
			parameters.Add(new SqlParameter("@ReducePoint", EntityBase.GetDatabaseValue(@reducePoint)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@WriteDate", EntityBase.GetDatabaseValue(@writeDate)));
			parameters.Add(new SqlParameter("@Coefficient", EntityBase.GetDatabaseValue(@coefficient)));
			parameters.Add(new SqlParameter("@ChargeRoomNo", EntityBase.GetDatabaseValue(@chargeRoomNo)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Project_Biao into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectID">projectID</param>
		/// <param name="biaoID">biaoID</param>
		/// <param name="isActive">isActive</param>
		/// <param name="biaoCategory">biaoCategory</param>
		/// <param name="biaoName">biaoName</param>
		/// <param name="biaoGuiGe">biaoGuiGe</param>
		/// <param name="remark">remark</param>
		/// <param name="rate">rate</param>
		/// <param name="startPoint">startPoint</param>
		/// <param name="endPoint">endPoint</param>
		/// <param name="totalPoint">totalPoint</param>
		/// <param name="reducePoint">reducePoint</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="coefficient">coefficient</param>
		/// <param name="chargeRoomNo">chargeRoomNo</param>
		public static void UpdateProject_Biao(int @iD, int @projectID, int @biaoID, bool @isActive, string @biaoCategory, string @biaoName, string @biaoGuiGe, string @remark, decimal @rate, decimal @startPoint, decimal @endPoint, decimal @totalPoint, decimal @reducePoint, int @chargeID, decimal @unitPrice, DateTime @writeDate, decimal @coefficient, string @chargeRoomNo)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateProject_Biao(@iD, @projectID, @biaoID, @isActive, @biaoCategory, @biaoName, @biaoGuiGe, @remark, @rate, @startPoint, @endPoint, @totalPoint, @reducePoint, @chargeID, @unitPrice, @writeDate, @coefficient, @chargeRoomNo, helper);
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
		/// Updates a Project_Biao into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectID">projectID</param>
		/// <param name="biaoID">biaoID</param>
		/// <param name="isActive">isActive</param>
		/// <param name="biaoCategory">biaoCategory</param>
		/// <param name="biaoName">biaoName</param>
		/// <param name="biaoGuiGe">biaoGuiGe</param>
		/// <param name="remark">remark</param>
		/// <param name="rate">rate</param>
		/// <param name="startPoint">startPoint</param>
		/// <param name="endPoint">endPoint</param>
		/// <param name="totalPoint">totalPoint</param>
		/// <param name="reducePoint">reducePoint</param>
		/// <param name="chargeID">chargeID</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="writeDate">writeDate</param>
		/// <param name="coefficient">coefficient</param>
		/// <param name="chargeRoomNo">chargeRoomNo</param>
		/// <param name="helper">helper</param>
		internal static void UpdateProject_Biao(int @iD, int @projectID, int @biaoID, bool @isActive, string @biaoCategory, string @biaoName, string @biaoGuiGe, string @remark, decimal @rate, decimal @startPoint, decimal @endPoint, decimal @totalPoint, decimal @reducePoint, int @chargeID, decimal @unitPrice, DateTime @writeDate, decimal @coefficient, string @chargeRoomNo, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectID] int,
	[BiaoID] int,
	[IsActive] bit,
	[BiaoCategory] nvarchar(50),
	[BiaoName] nvarchar(50),
	[BiaoGuiGe] nvarchar(50),
	[Remark] ntext,
	[Rate] decimal(18, 4),
	[StartPoint] decimal(18, 2),
	[EndPoint] decimal(18, 2),
	[TotalPoint] decimal(18, 2),
	[ReducePoint] decimal(18, 2),
	[ChargeID] int,
	[UnitPrice] decimal(18, 4),
	[WriteDate] datetime,
	[Coefficient] decimal(18, 4),
	[ChargeRoomNo] nvarchar(200)
);

UPDATE [dbo].[Project_Biao] SET 
	[Project_Biao].[ProjectID] = @ProjectID,
	[Project_Biao].[BiaoID] = @BiaoID,
	[Project_Biao].[IsActive] = @IsActive,
	[Project_Biao].[BiaoCategory] = @BiaoCategory,
	[Project_Biao].[BiaoName] = @BiaoName,
	[Project_Biao].[BiaoGuiGe] = @BiaoGuiGe,
	[Project_Biao].[Remark] = @Remark,
	[Project_Biao].[Rate] = @Rate,
	[Project_Biao].[StartPoint] = @StartPoint,
	[Project_Biao].[EndPoint] = @EndPoint,
	[Project_Biao].[TotalPoint] = @TotalPoint,
	[Project_Biao].[ReducePoint] = @ReducePoint,
	[Project_Biao].[ChargeID] = @ChargeID,
	[Project_Biao].[UnitPrice] = @UnitPrice,
	[Project_Biao].[WriteDate] = @WriteDate,
	[Project_Biao].[Coefficient] = @Coefficient,
	[Project_Biao].[ChargeRoomNo] = @ChargeRoomNo 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[BiaoID],
	INSERTED.[IsActive],
	INSERTED.[BiaoCategory],
	INSERTED.[BiaoName],
	INSERTED.[BiaoGuiGe],
	INSERTED.[Remark],
	INSERTED.[Rate],
	INSERTED.[StartPoint],
	INSERTED.[EndPoint],
	INSERTED.[TotalPoint],
	INSERTED.[ReducePoint],
	INSERTED.[ChargeID],
	INSERTED.[UnitPrice],
	INSERTED.[WriteDate],
	INSERTED.[Coefficient],
	INSERTED.[ChargeRoomNo]
into @table
WHERE 
	[Project_Biao].[ID] = @ID

SELECT 
	[ID],
	[ProjectID],
	[BiaoID],
	[IsActive],
	[BiaoCategory],
	[BiaoName],
	[BiaoGuiGe],
	[Remark],
	[Rate],
	[StartPoint],
	[EndPoint],
	[TotalPoint],
	[ReducePoint],
	[ChargeID],
	[UnitPrice],
	[WriteDate],
	[Coefficient],
	[ChargeRoomNo] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@BiaoID", EntityBase.GetDatabaseValue(@biaoID)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@BiaoCategory", EntityBase.GetDatabaseValue(@biaoCategory)));
			parameters.Add(new SqlParameter("@BiaoName", EntityBase.GetDatabaseValue(@biaoName)));
			parameters.Add(new SqlParameter("@BiaoGuiGe", EntityBase.GetDatabaseValue(@biaoGuiGe)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@Rate", EntityBase.GetDatabaseValue(@rate)));
			parameters.Add(new SqlParameter("@StartPoint", EntityBase.GetDatabaseValue(@startPoint)));
			parameters.Add(new SqlParameter("@EndPoint", EntityBase.GetDatabaseValue(@endPoint)));
			parameters.Add(new SqlParameter("@TotalPoint", EntityBase.GetDatabaseValue(@totalPoint)));
			parameters.Add(new SqlParameter("@ReducePoint", EntityBase.GetDatabaseValue(@reducePoint)));
			parameters.Add(new SqlParameter("@ChargeID", EntityBase.GetDatabaseValue(@chargeID)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@WriteDate", EntityBase.GetDatabaseValue(@writeDate)));
			parameters.Add(new SqlParameter("@Coefficient", EntityBase.GetDatabaseValue(@coefficient)));
			parameters.Add(new SqlParameter("@ChargeRoomNo", EntityBase.GetDatabaseValue(@chargeRoomNo)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Project_Biao from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteProject_Biao(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteProject_Biao(@iD, helper);
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
		/// Deletes a Project_Biao from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteProject_Biao(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Project_Biao]
WHERE 
	[Project_Biao].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Project_Biao object.
		/// </summary>
		/// <returns>The newly created Project_Biao object.</returns>
		public static Project_Biao CreateProject_Biao()
		{
			return InitializeNew<Project_Biao>();
		}
		
		/// <summary>
		/// Retrieve information for a Project_Biao by a Project_Biao's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Project_Biao</returns>
		public static Project_Biao GetProject_Biao(int @iD)
		{
			string commandText = @"
SELECT 
" + Project_Biao.SelectFieldList + @"
FROM [dbo].[Project_Biao] 
WHERE 
	[Project_Biao].[ID] = @ID " + Project_Biao.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Project_Biao>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Project_Biao by a Project_Biao's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Project_Biao</returns>
		public static Project_Biao GetProject_Biao(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Project_Biao.SelectFieldList + @"
FROM [dbo].[Project_Biao] 
WHERE 
	[Project_Biao].[ID] = @ID " + Project_Biao.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Project_Biao>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Project_Biao objects.
		/// </summary>
		/// <returns>The retrieved collection of Project_Biao objects.</returns>
		public static EntityList<Project_Biao> GetProject_Biaos()
		{
			string commandText = @"
SELECT " + Project_Biao.SelectFieldList + "FROM [dbo].[Project_Biao] " + Project_Biao.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Project_Biao>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Project_Biao objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Project_Biao objects.</returns>
        public static EntityList<Project_Biao> GetProject_Biaos(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Project_Biao>(SelectFieldList, "FROM [dbo].[Project_Biao]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Project_Biao objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Project_Biao objects.</returns>
        public static EntityList<Project_Biao> GetProject_Biaos(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Project_Biao>(SelectFieldList, "FROM [dbo].[Project_Biao]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Project_Biao objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Project_Biao objects.</returns>
		protected static EntityList<Project_Biao> GetProject_Biaos(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProject_Biaos(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Project_Biao objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Project_Biao objects.</returns>
		protected static EntityList<Project_Biao> GetProject_Biaos(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProject_Biaos(string.Empty, where, parameters, Project_Biao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project_Biao objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Project_Biao objects.</returns>
		protected static EntityList<Project_Biao> GetProject_Biaos(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProject_Biaos(prefix, where, parameters, Project_Biao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project_Biao objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Project_Biao objects.</returns>
		protected static EntityList<Project_Biao> GetProject_Biaos(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProject_Biaos(string.Empty, where, parameters, Project_Biao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project_Biao objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Project_Biao objects.</returns>
		protected static EntityList<Project_Biao> GetProject_Biaos(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProject_Biaos(prefix, where, parameters, Project_Biao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project_Biao objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Project_Biao objects.</returns>
		protected static EntityList<Project_Biao> GetProject_Biaos(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Project_Biao.SelectFieldList + "FROM [dbo].[Project_Biao] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Project_Biao>(reader);
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
        protected static EntityList<Project_Biao> GetProject_Biaos(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Project_Biao>(SelectFieldList, "FROM [dbo].[Project_Biao] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Project_Biao objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetProject_BiaoCount()
        {
            return GetProject_BiaoCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Project_Biao objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetProject_BiaoCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Project_Biao] " + where;

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
		public static partial class Project_Biao_Properties
		{
			public const string ID = "ID";
			public const string ProjectID = "ProjectID";
			public const string BiaoID = "BiaoID";
			public const string IsActive = "IsActive";
			public const string BiaoCategory = "BiaoCategory";
			public const string BiaoName = "BiaoName";
			public const string BiaoGuiGe = "BiaoGuiGe";
			public const string Remark = "Remark";
			public const string Rate = "Rate";
			public const string StartPoint = "StartPoint";
			public const string EndPoint = "EndPoint";
			public const string TotalPoint = "TotalPoint";
			public const string ReducePoint = "ReducePoint";
			public const string ChargeID = "ChargeID";
			public const string UnitPrice = "UnitPrice";
			public const string WriteDate = "WriteDate";
			public const string Coefficient = "Coefficient";
			public const string ChargeRoomNo = "ChargeRoomNo";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProjectID" , "int:"},
    			 {"BiaoID" , "int:"},
    			 {"IsActive" , "bool:"},
    			 {"BiaoCategory" , "string:"},
    			 {"BiaoName" , "string:"},
    			 {"BiaoGuiGe" , "string:"},
    			 {"Remark" , "string:"},
    			 {"Rate" , "decimal:"},
    			 {"StartPoint" , "decimal:"},
    			 {"EndPoint" , "decimal:"},
    			 {"TotalPoint" , "decimal:"},
    			 {"ReducePoint" , "decimal:"},
    			 {"ChargeID" , "int:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"WriteDate" , "DateTime:"},
    			 {"Coefficient" , "decimal:"},
    			 {"ChargeRoomNo" , "string:"},
            };
		}
		#endregion
	}
}
