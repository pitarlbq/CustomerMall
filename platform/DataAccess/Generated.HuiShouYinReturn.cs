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
	/// This object represents the properties and methods of a HuiShouYinReturn.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class HuiShouYinReturn 
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
		private string _out_trade_no = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string out_trade_no
		{
			[DebuggerStepThrough()]
			get { return this._out_trade_no; }
			set 
			{
				if (this._out_trade_no != value) 
				{
					this._out_trade_no = value;
					this.IsDirty = true;	
					OnPropertyChanged("out_trade_no");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _hy_bill_no = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string hy_bill_no
		{
			[DebuggerStepThrough()]
			get { return this._hy_bill_no; }
			set 
			{
				if (this._hy_bill_no != value) 
				{
					this._hy_bill_no = value;
					this.IsDirty = true;	
					OnPropertyChanged("hy_bill_no");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _total_fee = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int total_fee
		{
			[DebuggerStepThrough()]
			get { return this._total_fee; }
			set 
			{
				if (this._total_fee != value) 
				{
					this._total_fee = value;
					this.IsDirty = true;	
					OnPropertyChanged("total_fee");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _real_fee = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int real_fee
		{
			[DebuggerStepThrough()]
			get { return this._real_fee; }
			set 
			{
				if (this._real_fee != value) 
				{
					this._real_fee = value;
					this.IsDirty = true;	
					OnPropertyChanged("real_fee");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _trade_status = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string trade_status
		{
			[DebuggerStepThrough()]
			get { return this._trade_status; }
			set 
			{
				if (this._trade_status != value) 
				{
					this._trade_status = value;
					this.IsDirty = true;	
					OnPropertyChanged("trade_status");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _openID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OpenID
		{
			[DebuggerStepThrough()]
			get { return this._openID; }
			set 
			{
				if (this._openID != value) 
				{
					this._openID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OpenID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _subject = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string subject
		{
			[DebuggerStepThrough()]
			get { return this._subject; }
			set 
			{
				if (this._subject != value) 
				{
					this._subject = value;
					this.IsDirty = true;	
					OnPropertyChanged("subject");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _pay_option = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string pay_option
		{
			[DebuggerStepThrough()]
			get { return this._pay_option; }
			set 
			{
				if (this._pay_option != value) 
				{
					this._pay_option = value;
					this.IsDirty = true;	
					OnPropertyChanged("pay_option");
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
	[out_trade_no] nvarchar(200),
	[hy_bill_no] nvarchar(200),
	[total_fee] int,
	[real_fee] int,
	[trade_status] nvarchar(200),
	[OpenID] nvarchar(500),
	[subject] nvarchar(200),
	[pay_option] nvarchar(500)
);

INSERT INTO [dbo].[HuiShouYinReturn] (
	[HuiShouYinReturn].[out_trade_no],
	[HuiShouYinReturn].[hy_bill_no],
	[HuiShouYinReturn].[total_fee],
	[HuiShouYinReturn].[real_fee],
	[HuiShouYinReturn].[trade_status],
	[HuiShouYinReturn].[OpenID],
	[HuiShouYinReturn].[subject],
	[HuiShouYinReturn].[pay_option]
) 
output 
	INSERTED.[ID],
	INSERTED.[out_trade_no],
	INSERTED.[hy_bill_no],
	INSERTED.[total_fee],
	INSERTED.[real_fee],
	INSERTED.[trade_status],
	INSERTED.[OpenID],
	INSERTED.[subject],
	INSERTED.[pay_option]
into @table
VALUES ( 
	@out_trade_no,
	@hy_bill_no,
	@total_fee,
	@real_fee,
	@trade_status,
	@OpenID,
	@subject,
	@pay_option 
); 

SELECT 
	[ID],
	[out_trade_no],
	[hy_bill_no],
	[total_fee],
	[real_fee],
	[trade_status],
	[OpenID],
	[subject],
	[pay_option] 
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
	[out_trade_no] nvarchar(200),
	[hy_bill_no] nvarchar(200),
	[total_fee] int,
	[real_fee] int,
	[trade_status] nvarchar(200),
	[OpenID] nvarchar(500),
	[subject] nvarchar(200),
	[pay_option] nvarchar(500)
);

UPDATE [dbo].[HuiShouYinReturn] SET 
	[HuiShouYinReturn].[out_trade_no] = @out_trade_no,
	[HuiShouYinReturn].[hy_bill_no] = @hy_bill_no,
	[HuiShouYinReturn].[total_fee] = @total_fee,
	[HuiShouYinReturn].[real_fee] = @real_fee,
	[HuiShouYinReturn].[trade_status] = @trade_status,
	[HuiShouYinReturn].[OpenID] = @OpenID,
	[HuiShouYinReturn].[subject] = @subject,
	[HuiShouYinReturn].[pay_option] = @pay_option 
output 
	INSERTED.[ID],
	INSERTED.[out_trade_no],
	INSERTED.[hy_bill_no],
	INSERTED.[total_fee],
	INSERTED.[real_fee],
	INSERTED.[trade_status],
	INSERTED.[OpenID],
	INSERTED.[subject],
	INSERTED.[pay_option]
into @table
WHERE 
	[HuiShouYinReturn].[ID] = @ID

SELECT 
	[ID],
	[out_trade_no],
	[hy_bill_no],
	[total_fee],
	[real_fee],
	[trade_status],
	[OpenID],
	[subject],
	[pay_option] 
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
DELETE FROM [dbo].[HuiShouYinReturn]
WHERE 
	[HuiShouYinReturn].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public HuiShouYinReturn() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetHuiShouYinReturn(this.ID));
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
	[HuiShouYinReturn].[ID],
	[HuiShouYinReturn].[out_trade_no],
	[HuiShouYinReturn].[hy_bill_no],
	[HuiShouYinReturn].[total_fee],
	[HuiShouYinReturn].[real_fee],
	[HuiShouYinReturn].[trade_status],
	[HuiShouYinReturn].[OpenID],
	[HuiShouYinReturn].[subject],
	[HuiShouYinReturn].[pay_option]
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
                return "HuiShouYinReturn";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a HuiShouYinReturn into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="out_trade_no">out_trade_no</param>
		/// <param name="hy_bill_no">hy_bill_no</param>
		/// <param name="total_fee">total_fee</param>
		/// <param name="real_fee">real_fee</param>
		/// <param name="trade_status">trade_status</param>
		/// <param name="openID">openID</param>
		/// <param name="subject">subject</param>
		/// <param name="pay_option">pay_option</param>
		public static void InsertHuiShouYinReturn(string @out_trade_no, string @hy_bill_no, int @total_fee, int @real_fee, string @trade_status, string @openID, string @subject, string @pay_option)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertHuiShouYinReturn(@out_trade_no, @hy_bill_no, @total_fee, @real_fee, @trade_status, @openID, @subject, @pay_option, helper);
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
		/// Insert a HuiShouYinReturn into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="out_trade_no">out_trade_no</param>
		/// <param name="hy_bill_no">hy_bill_no</param>
		/// <param name="total_fee">total_fee</param>
		/// <param name="real_fee">real_fee</param>
		/// <param name="trade_status">trade_status</param>
		/// <param name="openID">openID</param>
		/// <param name="subject">subject</param>
		/// <param name="pay_option">pay_option</param>
		/// <param name="helper">helper</param>
		internal static void InsertHuiShouYinReturn(string @out_trade_no, string @hy_bill_no, int @total_fee, int @real_fee, string @trade_status, string @openID, string @subject, string @pay_option, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[out_trade_no] nvarchar(200),
	[hy_bill_no] nvarchar(200),
	[total_fee] int,
	[real_fee] int,
	[trade_status] nvarchar(200),
	[OpenID] nvarchar(500),
	[subject] nvarchar(200),
	[pay_option] nvarchar(500)
);

INSERT INTO [dbo].[HuiShouYinReturn] (
	[HuiShouYinReturn].[out_trade_no],
	[HuiShouYinReturn].[hy_bill_no],
	[HuiShouYinReturn].[total_fee],
	[HuiShouYinReturn].[real_fee],
	[HuiShouYinReturn].[trade_status],
	[HuiShouYinReturn].[OpenID],
	[HuiShouYinReturn].[subject],
	[HuiShouYinReturn].[pay_option]
) 
output 
	INSERTED.[ID],
	INSERTED.[out_trade_no],
	INSERTED.[hy_bill_no],
	INSERTED.[total_fee],
	INSERTED.[real_fee],
	INSERTED.[trade_status],
	INSERTED.[OpenID],
	INSERTED.[subject],
	INSERTED.[pay_option]
into @table
VALUES ( 
	@out_trade_no,
	@hy_bill_no,
	@total_fee,
	@real_fee,
	@trade_status,
	@OpenID,
	@subject,
	@pay_option 
); 

SELECT 
	[ID],
	[out_trade_no],
	[hy_bill_no],
	[total_fee],
	[real_fee],
	[trade_status],
	[OpenID],
	[subject],
	[pay_option] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@out_trade_no", EntityBase.GetDatabaseValue(@out_trade_no)));
			parameters.Add(new SqlParameter("@hy_bill_no", EntityBase.GetDatabaseValue(@hy_bill_no)));
			parameters.Add(new SqlParameter("@total_fee", EntityBase.GetDatabaseValue(@total_fee)));
			parameters.Add(new SqlParameter("@real_fee", EntityBase.GetDatabaseValue(@real_fee)));
			parameters.Add(new SqlParameter("@trade_status", EntityBase.GetDatabaseValue(@trade_status)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@subject", EntityBase.GetDatabaseValue(@subject)));
			parameters.Add(new SqlParameter("@pay_option", EntityBase.GetDatabaseValue(@pay_option)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a HuiShouYinReturn into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="out_trade_no">out_trade_no</param>
		/// <param name="hy_bill_no">hy_bill_no</param>
		/// <param name="total_fee">total_fee</param>
		/// <param name="real_fee">real_fee</param>
		/// <param name="trade_status">trade_status</param>
		/// <param name="openID">openID</param>
		/// <param name="subject">subject</param>
		/// <param name="pay_option">pay_option</param>
		public static void UpdateHuiShouYinReturn(int @iD, string @out_trade_no, string @hy_bill_no, int @total_fee, int @real_fee, string @trade_status, string @openID, string @subject, string @pay_option)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateHuiShouYinReturn(@iD, @out_trade_no, @hy_bill_no, @total_fee, @real_fee, @trade_status, @openID, @subject, @pay_option, helper);
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
		/// Updates a HuiShouYinReturn into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="out_trade_no">out_trade_no</param>
		/// <param name="hy_bill_no">hy_bill_no</param>
		/// <param name="total_fee">total_fee</param>
		/// <param name="real_fee">real_fee</param>
		/// <param name="trade_status">trade_status</param>
		/// <param name="openID">openID</param>
		/// <param name="subject">subject</param>
		/// <param name="pay_option">pay_option</param>
		/// <param name="helper">helper</param>
		internal static void UpdateHuiShouYinReturn(int @iD, string @out_trade_no, string @hy_bill_no, int @total_fee, int @real_fee, string @trade_status, string @openID, string @subject, string @pay_option, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[out_trade_no] nvarchar(200),
	[hy_bill_no] nvarchar(200),
	[total_fee] int,
	[real_fee] int,
	[trade_status] nvarchar(200),
	[OpenID] nvarchar(500),
	[subject] nvarchar(200),
	[pay_option] nvarchar(500)
);

UPDATE [dbo].[HuiShouYinReturn] SET 
	[HuiShouYinReturn].[out_trade_no] = @out_trade_no,
	[HuiShouYinReturn].[hy_bill_no] = @hy_bill_no,
	[HuiShouYinReturn].[total_fee] = @total_fee,
	[HuiShouYinReturn].[real_fee] = @real_fee,
	[HuiShouYinReturn].[trade_status] = @trade_status,
	[HuiShouYinReturn].[OpenID] = @OpenID,
	[HuiShouYinReturn].[subject] = @subject,
	[HuiShouYinReturn].[pay_option] = @pay_option 
output 
	INSERTED.[ID],
	INSERTED.[out_trade_no],
	INSERTED.[hy_bill_no],
	INSERTED.[total_fee],
	INSERTED.[real_fee],
	INSERTED.[trade_status],
	INSERTED.[OpenID],
	INSERTED.[subject],
	INSERTED.[pay_option]
into @table
WHERE 
	[HuiShouYinReturn].[ID] = @ID

SELECT 
	[ID],
	[out_trade_no],
	[hy_bill_no],
	[total_fee],
	[real_fee],
	[trade_status],
	[OpenID],
	[subject],
	[pay_option] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@out_trade_no", EntityBase.GetDatabaseValue(@out_trade_no)));
			parameters.Add(new SqlParameter("@hy_bill_no", EntityBase.GetDatabaseValue(@hy_bill_no)));
			parameters.Add(new SqlParameter("@total_fee", EntityBase.GetDatabaseValue(@total_fee)));
			parameters.Add(new SqlParameter("@real_fee", EntityBase.GetDatabaseValue(@real_fee)));
			parameters.Add(new SqlParameter("@trade_status", EntityBase.GetDatabaseValue(@trade_status)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@subject", EntityBase.GetDatabaseValue(@subject)));
			parameters.Add(new SqlParameter("@pay_option", EntityBase.GetDatabaseValue(@pay_option)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a HuiShouYinReturn from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteHuiShouYinReturn(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteHuiShouYinReturn(@iD, helper);
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
		/// Deletes a HuiShouYinReturn from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteHuiShouYinReturn(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[HuiShouYinReturn]
WHERE 
	[HuiShouYinReturn].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new HuiShouYinReturn object.
		/// </summary>
		/// <returns>The newly created HuiShouYinReturn object.</returns>
		public static HuiShouYinReturn CreateHuiShouYinReturn()
		{
			return InitializeNew<HuiShouYinReturn>();
		}
		
		/// <summary>
		/// Retrieve information for a HuiShouYinReturn by a HuiShouYinReturn's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>HuiShouYinReturn</returns>
		public static HuiShouYinReturn GetHuiShouYinReturn(int @iD)
		{
			string commandText = @"
SELECT 
" + HuiShouYinReturn.SelectFieldList + @"
FROM [dbo].[HuiShouYinReturn] 
WHERE 
	[HuiShouYinReturn].[ID] = @ID " + HuiShouYinReturn.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<HuiShouYinReturn>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a HuiShouYinReturn by a HuiShouYinReturn's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>HuiShouYinReturn</returns>
		public static HuiShouYinReturn GetHuiShouYinReturn(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + HuiShouYinReturn.SelectFieldList + @"
FROM [dbo].[HuiShouYinReturn] 
WHERE 
	[HuiShouYinReturn].[ID] = @ID " + HuiShouYinReturn.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<HuiShouYinReturn>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection HuiShouYinReturn objects.
		/// </summary>
		/// <returns>The retrieved collection of HuiShouYinReturn objects.</returns>
		public static EntityList<HuiShouYinReturn> GetHuiShouYinReturns()
		{
			string commandText = @"
SELECT " + HuiShouYinReturn.SelectFieldList + "FROM [dbo].[HuiShouYinReturn] " + HuiShouYinReturn.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<HuiShouYinReturn>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection HuiShouYinReturn objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of HuiShouYinReturn objects.</returns>
        public static EntityList<HuiShouYinReturn> GetHuiShouYinReturns(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<HuiShouYinReturn>(SelectFieldList, "FROM [dbo].[HuiShouYinReturn]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection HuiShouYinReturn objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of HuiShouYinReturn objects.</returns>
        public static EntityList<HuiShouYinReturn> GetHuiShouYinReturns(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<HuiShouYinReturn>(SelectFieldList, "FROM [dbo].[HuiShouYinReturn]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection HuiShouYinReturn objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of HuiShouYinReturn objects.</returns>
		protected static EntityList<HuiShouYinReturn> GetHuiShouYinReturns(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetHuiShouYinReturns(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection HuiShouYinReturn objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of HuiShouYinReturn objects.</returns>
		protected static EntityList<HuiShouYinReturn> GetHuiShouYinReturns(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetHuiShouYinReturns(string.Empty, where, parameters, HuiShouYinReturn.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection HuiShouYinReturn objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of HuiShouYinReturn objects.</returns>
		protected static EntityList<HuiShouYinReturn> GetHuiShouYinReturns(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetHuiShouYinReturns(prefix, where, parameters, HuiShouYinReturn.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection HuiShouYinReturn objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of HuiShouYinReturn objects.</returns>
		protected static EntityList<HuiShouYinReturn> GetHuiShouYinReturns(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetHuiShouYinReturns(string.Empty, where, parameters, HuiShouYinReturn.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection HuiShouYinReturn objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of HuiShouYinReturn objects.</returns>
		protected static EntityList<HuiShouYinReturn> GetHuiShouYinReturns(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetHuiShouYinReturns(prefix, where, parameters, HuiShouYinReturn.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection HuiShouYinReturn objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of HuiShouYinReturn objects.</returns>
		protected static EntityList<HuiShouYinReturn> GetHuiShouYinReturns(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + HuiShouYinReturn.SelectFieldList + "FROM [dbo].[HuiShouYinReturn] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<HuiShouYinReturn>(reader);
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
        protected static EntityList<HuiShouYinReturn> GetHuiShouYinReturns(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<HuiShouYinReturn>(SelectFieldList, "FROM [dbo].[HuiShouYinReturn] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of HuiShouYinReturn objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetHuiShouYinReturnCount()
        {
            return GetHuiShouYinReturnCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of HuiShouYinReturn objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetHuiShouYinReturnCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[HuiShouYinReturn] " + where;

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
		public static partial class HuiShouYinReturn_Properties
		{
			public const string ID = "ID";
			public const string out_trade_no = "out_trade_no";
			public const string hy_bill_no = "hy_bill_no";
			public const string total_fee = "total_fee";
			public const string real_fee = "real_fee";
			public const string trade_status = "trade_status";
			public const string OpenID = "OpenID";
			public const string subject = "subject";
			public const string pay_option = "pay_option";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"out_trade_no" , "string:"},
    			 {"hy_bill_no" , "string:"},
    			 {"total_fee" , "int:"},
    			 {"real_fee" , "int:"},
    			 {"trade_status" , "string:"},
    			 {"OpenID" , "string:"},
    			 {"subject" , "string:"},
    			 {"pay_option" , "string:"},
            };
		}
		#endregion
	}
}
