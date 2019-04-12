﻿using System;
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
	/// This object represents the properties and methods of a ChargeDiscount.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ChargeDiscount 
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
		private string _discountName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string DiscountName
		{
			[DebuggerStepThrough()]
			get { return this._discountName; }
			set 
			{
				if (this._discountName != value) 
				{
					this._discountName = value;
					this.IsDirty = true;	
					OnPropertyChanged("DiscountName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _discountType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string DiscountType
		{
			[DebuggerStepThrough()]
			get { return this._discountType; }
			set 
			{
				if (this._discountType != value) 
				{
					this._discountType = value;
					this.IsDirty = true;	
					OnPropertyChanged("DiscountType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _discountValue = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal DiscountValue
		{
			[DebuggerStepThrough()]
			get { return this._discountValue; }
			set 
			{
				if (this._discountValue != value) 
				{
					this._discountValue = value;
					this.IsDirty = true;	
					OnPropertyChanged("DiscountValue");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _startTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime StartTime
		{
			[DebuggerStepThrough()]
			get { return this._startTime; }
			set 
			{
				if (this._startTime != value) 
				{
					this._startTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("StartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _endTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime EndTime
		{
			[DebuggerStepThrough()]
			get { return this._endTime; }
			set 
			{
				if (this._endTime != value) 
				{
					this._endTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndTime");
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
		private string _chargeSummaryIDs = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeSummaryIDs
		{
			[DebuggerStepThrough()]
			get { return this._chargeSummaryIDs; }
			set 
			{
				if (this._chargeSummaryIDs != value) 
				{
					this._chargeSummaryIDs = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeSummaryIDs");
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
	[DiscountName] nvarchar(50),
	[DiscountType] nvarchar(50),
	[DiscountValue] decimal(18, 2),
	[StartTime] datetime,
	[EndTime] datetime,
	[SortOrder] int,
	[ChargeSummaryIDs] nvarchar(200),
	[Remark] ntext
);

INSERT INTO [dbo].[ChargeDiscount] (
	[ChargeDiscount].[DiscountName],
	[ChargeDiscount].[DiscountType],
	[ChargeDiscount].[DiscountValue],
	[ChargeDiscount].[StartTime],
	[ChargeDiscount].[EndTime],
	[ChargeDiscount].[SortOrder],
	[ChargeDiscount].[ChargeSummaryIDs],
	[ChargeDiscount].[Remark]
) 
output 
	INSERTED.[ID],
	INSERTED.[DiscountName],
	INSERTED.[DiscountType],
	INSERTED.[DiscountValue],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[SortOrder],
	INSERTED.[ChargeSummaryIDs],
	INSERTED.[Remark]
into @table
VALUES ( 
	@DiscountName,
	@DiscountType,
	@DiscountValue,
	@StartTime,
	@EndTime,
	@SortOrder,
	@ChargeSummaryIDs,
	@Remark 
); 

SELECT 
	[ID],
	[DiscountName],
	[DiscountType],
	[DiscountValue],
	[StartTime],
	[EndTime],
	[SortOrder],
	[ChargeSummaryIDs],
	[Remark] 
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
	[DiscountName] nvarchar(50),
	[DiscountType] nvarchar(50),
	[DiscountValue] decimal(18, 2),
	[StartTime] datetime,
	[EndTime] datetime,
	[SortOrder] int,
	[ChargeSummaryIDs] nvarchar(200),
	[Remark] ntext
);

UPDATE [dbo].[ChargeDiscount] SET 
	[ChargeDiscount].[DiscountName] = @DiscountName,
	[ChargeDiscount].[DiscountType] = @DiscountType,
	[ChargeDiscount].[DiscountValue] = @DiscountValue,
	[ChargeDiscount].[StartTime] = @StartTime,
	[ChargeDiscount].[EndTime] = @EndTime,
	[ChargeDiscount].[SortOrder] = @SortOrder,
	[ChargeDiscount].[ChargeSummaryIDs] = @ChargeSummaryIDs,
	[ChargeDiscount].[Remark] = @Remark 
output 
	INSERTED.[ID],
	INSERTED.[DiscountName],
	INSERTED.[DiscountType],
	INSERTED.[DiscountValue],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[SortOrder],
	INSERTED.[ChargeSummaryIDs],
	INSERTED.[Remark]
into @table
WHERE 
	[ChargeDiscount].[ID] = @ID

SELECT 
	[ID],
	[DiscountName],
	[DiscountType],
	[DiscountValue],
	[StartTime],
	[EndTime],
	[SortOrder],
	[ChargeSummaryIDs],
	[Remark] 
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
DELETE FROM [dbo].[ChargeDiscount]
WHERE 
	[ChargeDiscount].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ChargeDiscount() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetChargeDiscount(this.ID));
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
	[ChargeDiscount].[ID],
	[ChargeDiscount].[DiscountName],
	[ChargeDiscount].[DiscountType],
	[ChargeDiscount].[DiscountValue],
	[ChargeDiscount].[StartTime],
	[ChargeDiscount].[EndTime],
	[ChargeDiscount].[SortOrder],
	[ChargeDiscount].[ChargeSummaryIDs],
	[ChargeDiscount].[Remark]
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
                return "ChargeDiscount";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ChargeDiscount into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="discountName">discountName</param>
		/// <param name="discountType">discountType</param>
		/// <param name="discountValue">discountValue</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="chargeSummaryIDs">chargeSummaryIDs</param>
		/// <param name="remark">remark</param>
		public static void InsertChargeDiscount(string @discountName, string @discountType, decimal @discountValue, DateTime @startTime, DateTime @endTime, int @sortOrder, string @chargeSummaryIDs, string @remark)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertChargeDiscount(@discountName, @discountType, @discountValue, @startTime, @endTime, @sortOrder, @chargeSummaryIDs, @remark, helper);
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
		/// Insert a ChargeDiscount into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="discountName">discountName</param>
		/// <param name="discountType">discountType</param>
		/// <param name="discountValue">discountValue</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="chargeSummaryIDs">chargeSummaryIDs</param>
		/// <param name="remark">remark</param>
		/// <param name="helper">helper</param>
		internal static void InsertChargeDiscount(string @discountName, string @discountType, decimal @discountValue, DateTime @startTime, DateTime @endTime, int @sortOrder, string @chargeSummaryIDs, string @remark, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DiscountName] nvarchar(50),
	[DiscountType] nvarchar(50),
	[DiscountValue] decimal(18, 2),
	[StartTime] datetime,
	[EndTime] datetime,
	[SortOrder] int,
	[ChargeSummaryIDs] nvarchar(200),
	[Remark] ntext
);

INSERT INTO [dbo].[ChargeDiscount] (
	[ChargeDiscount].[DiscountName],
	[ChargeDiscount].[DiscountType],
	[ChargeDiscount].[DiscountValue],
	[ChargeDiscount].[StartTime],
	[ChargeDiscount].[EndTime],
	[ChargeDiscount].[SortOrder],
	[ChargeDiscount].[ChargeSummaryIDs],
	[ChargeDiscount].[Remark]
) 
output 
	INSERTED.[ID],
	INSERTED.[DiscountName],
	INSERTED.[DiscountType],
	INSERTED.[DiscountValue],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[SortOrder],
	INSERTED.[ChargeSummaryIDs],
	INSERTED.[Remark]
into @table
VALUES ( 
	@DiscountName,
	@DiscountType,
	@DiscountValue,
	@StartTime,
	@EndTime,
	@SortOrder,
	@ChargeSummaryIDs,
	@Remark 
); 

SELECT 
	[ID],
	[DiscountName],
	[DiscountType],
	[DiscountValue],
	[StartTime],
	[EndTime],
	[SortOrder],
	[ChargeSummaryIDs],
	[Remark] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DiscountName", EntityBase.GetDatabaseValue(@discountName)));
			parameters.Add(new SqlParameter("@DiscountType", EntityBase.GetDatabaseValue(@discountType)));
			parameters.Add(new SqlParameter("@DiscountValue", EntityBase.GetDatabaseValue(@discountValue)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@ChargeSummaryIDs", EntityBase.GetDatabaseValue(@chargeSummaryIDs)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ChargeDiscount into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="discountName">discountName</param>
		/// <param name="discountType">discountType</param>
		/// <param name="discountValue">discountValue</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="chargeSummaryIDs">chargeSummaryIDs</param>
		/// <param name="remark">remark</param>
		public static void UpdateChargeDiscount(int @iD, string @discountName, string @discountType, decimal @discountValue, DateTime @startTime, DateTime @endTime, int @sortOrder, string @chargeSummaryIDs, string @remark)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateChargeDiscount(@iD, @discountName, @discountType, @discountValue, @startTime, @endTime, @sortOrder, @chargeSummaryIDs, @remark, helper);
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
		/// Updates a ChargeDiscount into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="discountName">discountName</param>
		/// <param name="discountType">discountType</param>
		/// <param name="discountValue">discountValue</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="chargeSummaryIDs">chargeSummaryIDs</param>
		/// <param name="remark">remark</param>
		/// <param name="helper">helper</param>
		internal static void UpdateChargeDiscount(int @iD, string @discountName, string @discountType, decimal @discountValue, DateTime @startTime, DateTime @endTime, int @sortOrder, string @chargeSummaryIDs, string @remark, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DiscountName] nvarchar(50),
	[DiscountType] nvarchar(50),
	[DiscountValue] decimal(18, 2),
	[StartTime] datetime,
	[EndTime] datetime,
	[SortOrder] int,
	[ChargeSummaryIDs] nvarchar(200),
	[Remark] ntext
);

UPDATE [dbo].[ChargeDiscount] SET 
	[ChargeDiscount].[DiscountName] = @DiscountName,
	[ChargeDiscount].[DiscountType] = @DiscountType,
	[ChargeDiscount].[DiscountValue] = @DiscountValue,
	[ChargeDiscount].[StartTime] = @StartTime,
	[ChargeDiscount].[EndTime] = @EndTime,
	[ChargeDiscount].[SortOrder] = @SortOrder,
	[ChargeDiscount].[ChargeSummaryIDs] = @ChargeSummaryIDs,
	[ChargeDiscount].[Remark] = @Remark 
output 
	INSERTED.[ID],
	INSERTED.[DiscountName],
	INSERTED.[DiscountType],
	INSERTED.[DiscountValue],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[SortOrder],
	INSERTED.[ChargeSummaryIDs],
	INSERTED.[Remark]
into @table
WHERE 
	[ChargeDiscount].[ID] = @ID

SELECT 
	[ID],
	[DiscountName],
	[DiscountType],
	[DiscountValue],
	[StartTime],
	[EndTime],
	[SortOrder],
	[ChargeSummaryIDs],
	[Remark] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@DiscountName", EntityBase.GetDatabaseValue(@discountName)));
			parameters.Add(new SqlParameter("@DiscountType", EntityBase.GetDatabaseValue(@discountType)));
			parameters.Add(new SqlParameter("@DiscountValue", EntityBase.GetDatabaseValue(@discountValue)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@ChargeSummaryIDs", EntityBase.GetDatabaseValue(@chargeSummaryIDs)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ChargeDiscount from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteChargeDiscount(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteChargeDiscount(@iD, helper);
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
		/// Deletes a ChargeDiscount from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteChargeDiscount(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ChargeDiscount]
WHERE 
	[ChargeDiscount].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ChargeDiscount object.
		/// </summary>
		/// <returns>The newly created ChargeDiscount object.</returns>
		public static ChargeDiscount CreateChargeDiscount()
		{
			return InitializeNew<ChargeDiscount>();
		}
		
		/// <summary>
		/// Retrieve information for a ChargeDiscount by a ChargeDiscount's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ChargeDiscount</returns>
		public static ChargeDiscount GetChargeDiscount(int @iD)
		{
			string commandText = @"
SELECT 
" + ChargeDiscount.SelectFieldList + @"
FROM [dbo].[ChargeDiscount] 
WHERE 
	[ChargeDiscount].[ID] = @ID " + ChargeDiscount.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeDiscount>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ChargeDiscount by a ChargeDiscount's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ChargeDiscount</returns>
		public static ChargeDiscount GetChargeDiscount(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ChargeDiscount.SelectFieldList + @"
FROM [dbo].[ChargeDiscount] 
WHERE 
	[ChargeDiscount].[ID] = @ID " + ChargeDiscount.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeDiscount>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ChargeDiscount objects.
		/// </summary>
		/// <returns>The retrieved collection of ChargeDiscount objects.</returns>
		public static EntityList<ChargeDiscount> GetChargeDiscounts()
		{
			string commandText = @"
SELECT " + ChargeDiscount.SelectFieldList + "FROM [dbo].[ChargeDiscount] " + ChargeDiscount.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ChargeDiscount>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ChargeDiscount objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeDiscount objects.</returns>
        public static EntityList<ChargeDiscount> GetChargeDiscounts(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeDiscount>(SelectFieldList, "FROM [dbo].[ChargeDiscount]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ChargeDiscount objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeDiscount objects.</returns>
        public static EntityList<ChargeDiscount> GetChargeDiscounts(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeDiscount>(SelectFieldList, "FROM [dbo].[ChargeDiscount]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ChargeDiscount objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ChargeDiscount objects.</returns>
		protected static EntityList<ChargeDiscount> GetChargeDiscounts(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeDiscounts(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ChargeDiscount objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeDiscount objects.</returns>
		protected static EntityList<ChargeDiscount> GetChargeDiscounts(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeDiscounts(string.Empty, where, parameters, ChargeDiscount.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeDiscount objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeDiscount objects.</returns>
		protected static EntityList<ChargeDiscount> GetChargeDiscounts(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeDiscounts(prefix, where, parameters, ChargeDiscount.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeDiscount objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeDiscount objects.</returns>
		protected static EntityList<ChargeDiscount> GetChargeDiscounts(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeDiscounts(string.Empty, where, parameters, ChargeDiscount.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeDiscount objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeDiscount objects.</returns>
		protected static EntityList<ChargeDiscount> GetChargeDiscounts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeDiscounts(prefix, where, parameters, ChargeDiscount.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeDiscount objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ChargeDiscount objects.</returns>
		protected static EntityList<ChargeDiscount> GetChargeDiscounts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ChargeDiscount.SelectFieldList + "FROM [dbo].[ChargeDiscount] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ChargeDiscount>(reader);
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
        protected static EntityList<ChargeDiscount> GetChargeDiscounts(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeDiscount>(SelectFieldList, "FROM [dbo].[ChargeDiscount] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ChargeDiscount objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargeDiscountCount()
        {
            return GetChargeDiscountCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ChargeDiscount objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetChargeDiscountCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ChargeDiscount] " + where;

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
		public static partial class ChargeDiscount_Properties
		{
			public const string ID = "ID";
			public const string DiscountName = "DiscountName";
			public const string DiscountType = "DiscountType";
			public const string DiscountValue = "DiscountValue";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string SortOrder = "SortOrder";
			public const string ChargeSummaryIDs = "ChargeSummaryIDs";
			public const string Remark = "Remark";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"DiscountName" , "string:"},
    			 {"DiscountType" , "string:"},
    			 {"DiscountValue" , "decimal:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"SortOrder" , "int:"},
    			 {"ChargeSummaryIDs" , "string:"},
    			 {"Remark" , "string:"},
            };
		}
		#endregion
	}
}
