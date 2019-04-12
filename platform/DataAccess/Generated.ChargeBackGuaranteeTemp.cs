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
	/// This object represents the properties and methods of a ChargeBackGuaranteeTemp.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ChargeBackGuaranteeTemp 
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
		private int _historyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int HistoryID
		{
			[DebuggerStepThrough()]
			get { return this._historyID; }
			set 
			{
				if (this._historyID != value) 
				{
					this._historyID = value;
					this.IsDirty = true;	
					OnPropertyChanged("HistoryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _printID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PrintID
		{
			[DebuggerStepThrough()]
			get { return this._printID; }
			set 
			{
				if (this._printID != value) 
				{
					this._printID = value;
					this.IsDirty = true;	
					OnPropertyChanged("PrintID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _realPay = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal RealPay
		{
			[DebuggerStepThrough()]
			get { return this._realPay; }
			set 
			{
				if (this._realPay != value) 
				{
					this._realPay = value;
					this.IsDirty = true;	
					OnPropertyChanged("RealPay");
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
	[HistoryID] int,
	[PrintID] int,
	[RealPay] decimal(18, 2),
	[Remark] ntext,
	[GUID] nvarchar(200)
);

INSERT INTO [dbo].[ChargeBackGuaranteeTemp] (
	[ChargeBackGuaranteeTemp].[HistoryID],
	[ChargeBackGuaranteeTemp].[PrintID],
	[ChargeBackGuaranteeTemp].[RealPay],
	[ChargeBackGuaranteeTemp].[Remark],
	[ChargeBackGuaranteeTemp].[GUID]
) 
output 
	INSERTED.[ID],
	INSERTED.[HistoryID],
	INSERTED.[PrintID],
	INSERTED.[RealPay],
	INSERTED.[Remark],
	INSERTED.[GUID]
into @table
VALUES ( 
	@HistoryID,
	@PrintID,
	@RealPay,
	@Remark,
	@GUID 
); 

SELECT 
	[ID],
	[HistoryID],
	[PrintID],
	[RealPay],
	[Remark],
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
	[HistoryID] int,
	[PrintID] int,
	[RealPay] decimal(18, 2),
	[Remark] ntext,
	[GUID] nvarchar(200)
);

UPDATE [dbo].[ChargeBackGuaranteeTemp] SET 
	[ChargeBackGuaranteeTemp].[HistoryID] = @HistoryID,
	[ChargeBackGuaranteeTemp].[PrintID] = @PrintID,
	[ChargeBackGuaranteeTemp].[RealPay] = @RealPay,
	[ChargeBackGuaranteeTemp].[Remark] = @Remark,
	[ChargeBackGuaranteeTemp].[GUID] = @GUID 
output 
	INSERTED.[ID],
	INSERTED.[HistoryID],
	INSERTED.[PrintID],
	INSERTED.[RealPay],
	INSERTED.[Remark],
	INSERTED.[GUID]
into @table
WHERE 
	[ChargeBackGuaranteeTemp].[ID] = @ID

SELECT 
	[ID],
	[HistoryID],
	[PrintID],
	[RealPay],
	[Remark],
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
DELETE FROM [dbo].[ChargeBackGuaranteeTemp]
WHERE 
	[ChargeBackGuaranteeTemp].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ChargeBackGuaranteeTemp() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetChargeBackGuaranteeTemp(this.ID));
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
	[ChargeBackGuaranteeTemp].[ID],
	[ChargeBackGuaranteeTemp].[HistoryID],
	[ChargeBackGuaranteeTemp].[PrintID],
	[ChargeBackGuaranteeTemp].[RealPay],
	[ChargeBackGuaranteeTemp].[Remark],
	[ChargeBackGuaranteeTemp].[GUID]
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
                return "ChargeBackGuaranteeTemp";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ChargeBackGuaranteeTemp into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="historyID">historyID</param>
		/// <param name="printID">printID</param>
		/// <param name="realPay">realPay</param>
		/// <param name="remark">remark</param>
		/// <param name="gUID">gUID</param>
		public static void InsertChargeBackGuaranteeTemp(int @historyID, int @printID, decimal @realPay, string @remark, string @gUID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertChargeBackGuaranteeTemp(@historyID, @printID, @realPay, @remark, @gUID, helper);
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
		/// Insert a ChargeBackGuaranteeTemp into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="historyID">historyID</param>
		/// <param name="printID">printID</param>
		/// <param name="realPay">realPay</param>
		/// <param name="remark">remark</param>
		/// <param name="gUID">gUID</param>
		/// <param name="helper">helper</param>
		internal static void InsertChargeBackGuaranteeTemp(int @historyID, int @printID, decimal @realPay, string @remark, string @gUID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[HistoryID] int,
	[PrintID] int,
	[RealPay] decimal(18, 2),
	[Remark] ntext,
	[GUID] nvarchar(200)
);

INSERT INTO [dbo].[ChargeBackGuaranteeTemp] (
	[ChargeBackGuaranteeTemp].[HistoryID],
	[ChargeBackGuaranteeTemp].[PrintID],
	[ChargeBackGuaranteeTemp].[RealPay],
	[ChargeBackGuaranteeTemp].[Remark],
	[ChargeBackGuaranteeTemp].[GUID]
) 
output 
	INSERTED.[ID],
	INSERTED.[HistoryID],
	INSERTED.[PrintID],
	INSERTED.[RealPay],
	INSERTED.[Remark],
	INSERTED.[GUID]
into @table
VALUES ( 
	@HistoryID,
	@PrintID,
	@RealPay,
	@Remark,
	@GUID 
); 

SELECT 
	[ID],
	[HistoryID],
	[PrintID],
	[RealPay],
	[Remark],
	[GUID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@HistoryID", EntityBase.GetDatabaseValue(@historyID)));
			parameters.Add(new SqlParameter("@PrintID", EntityBase.GetDatabaseValue(@printID)));
			parameters.Add(new SqlParameter("@RealPay", EntityBase.GetDatabaseValue(@realPay)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ChargeBackGuaranteeTemp into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="historyID">historyID</param>
		/// <param name="printID">printID</param>
		/// <param name="realPay">realPay</param>
		/// <param name="remark">remark</param>
		/// <param name="gUID">gUID</param>
		public static void UpdateChargeBackGuaranteeTemp(int @iD, int @historyID, int @printID, decimal @realPay, string @remark, string @gUID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateChargeBackGuaranteeTemp(@iD, @historyID, @printID, @realPay, @remark, @gUID, helper);
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
		/// Updates a ChargeBackGuaranteeTemp into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="historyID">historyID</param>
		/// <param name="printID">printID</param>
		/// <param name="realPay">realPay</param>
		/// <param name="remark">remark</param>
		/// <param name="gUID">gUID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateChargeBackGuaranteeTemp(int @iD, int @historyID, int @printID, decimal @realPay, string @remark, string @gUID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[HistoryID] int,
	[PrintID] int,
	[RealPay] decimal(18, 2),
	[Remark] ntext,
	[GUID] nvarchar(200)
);

UPDATE [dbo].[ChargeBackGuaranteeTemp] SET 
	[ChargeBackGuaranteeTemp].[HistoryID] = @HistoryID,
	[ChargeBackGuaranteeTemp].[PrintID] = @PrintID,
	[ChargeBackGuaranteeTemp].[RealPay] = @RealPay,
	[ChargeBackGuaranteeTemp].[Remark] = @Remark,
	[ChargeBackGuaranteeTemp].[GUID] = @GUID 
output 
	INSERTED.[ID],
	INSERTED.[HistoryID],
	INSERTED.[PrintID],
	INSERTED.[RealPay],
	INSERTED.[Remark],
	INSERTED.[GUID]
into @table
WHERE 
	[ChargeBackGuaranteeTemp].[ID] = @ID

SELECT 
	[ID],
	[HistoryID],
	[PrintID],
	[RealPay],
	[Remark],
	[GUID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@HistoryID", EntityBase.GetDatabaseValue(@historyID)));
			parameters.Add(new SqlParameter("@PrintID", EntityBase.GetDatabaseValue(@printID)));
			parameters.Add(new SqlParameter("@RealPay", EntityBase.GetDatabaseValue(@realPay)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ChargeBackGuaranteeTemp from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteChargeBackGuaranteeTemp(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteChargeBackGuaranteeTemp(@iD, helper);
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
		/// Deletes a ChargeBackGuaranteeTemp from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteChargeBackGuaranteeTemp(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ChargeBackGuaranteeTemp]
WHERE 
	[ChargeBackGuaranteeTemp].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ChargeBackGuaranteeTemp object.
		/// </summary>
		/// <returns>The newly created ChargeBackGuaranteeTemp object.</returns>
		public static ChargeBackGuaranteeTemp CreateChargeBackGuaranteeTemp()
		{
			return InitializeNew<ChargeBackGuaranteeTemp>();
		}
		
		/// <summary>
		/// Retrieve information for a ChargeBackGuaranteeTemp by a ChargeBackGuaranteeTemp's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ChargeBackGuaranteeTemp</returns>
		public static ChargeBackGuaranteeTemp GetChargeBackGuaranteeTemp(int @iD)
		{
			string commandText = @"
SELECT 
" + ChargeBackGuaranteeTemp.SelectFieldList + @"
FROM [dbo].[ChargeBackGuaranteeTemp] 
WHERE 
	[ChargeBackGuaranteeTemp].[ID] = @ID " + ChargeBackGuaranteeTemp.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeBackGuaranteeTemp>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ChargeBackGuaranteeTemp by a ChargeBackGuaranteeTemp's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ChargeBackGuaranteeTemp</returns>
		public static ChargeBackGuaranteeTemp GetChargeBackGuaranteeTemp(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ChargeBackGuaranteeTemp.SelectFieldList + @"
FROM [dbo].[ChargeBackGuaranteeTemp] 
WHERE 
	[ChargeBackGuaranteeTemp].[ID] = @ID " + ChargeBackGuaranteeTemp.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ChargeBackGuaranteeTemp>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ChargeBackGuaranteeTemp objects.
		/// </summary>
		/// <returns>The retrieved collection of ChargeBackGuaranteeTemp objects.</returns>
		public static EntityList<ChargeBackGuaranteeTemp> GetChargeBackGuaranteeTemps()
		{
			string commandText = @"
SELECT " + ChargeBackGuaranteeTemp.SelectFieldList + "FROM [dbo].[ChargeBackGuaranteeTemp] " + ChargeBackGuaranteeTemp.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ChargeBackGuaranteeTemp>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ChargeBackGuaranteeTemp objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeBackGuaranteeTemp objects.</returns>
        public static EntityList<ChargeBackGuaranteeTemp> GetChargeBackGuaranteeTemps(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeBackGuaranteeTemp>(SelectFieldList, "FROM [dbo].[ChargeBackGuaranteeTemp]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ChargeBackGuaranteeTemp objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ChargeBackGuaranteeTemp objects.</returns>
        public static EntityList<ChargeBackGuaranteeTemp> GetChargeBackGuaranteeTemps(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeBackGuaranteeTemp>(SelectFieldList, "FROM [dbo].[ChargeBackGuaranteeTemp]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ChargeBackGuaranteeTemp objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ChargeBackGuaranteeTemp objects.</returns>
		protected static EntityList<ChargeBackGuaranteeTemp> GetChargeBackGuaranteeTemps(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeBackGuaranteeTemps(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ChargeBackGuaranteeTemp objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeBackGuaranteeTemp objects.</returns>
		protected static EntityList<ChargeBackGuaranteeTemp> GetChargeBackGuaranteeTemps(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeBackGuaranteeTemps(string.Empty, where, parameters, ChargeBackGuaranteeTemp.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeBackGuaranteeTemp objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ChargeBackGuaranteeTemp objects.</returns>
		protected static EntityList<ChargeBackGuaranteeTemp> GetChargeBackGuaranteeTemps(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetChargeBackGuaranteeTemps(prefix, where, parameters, ChargeBackGuaranteeTemp.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeBackGuaranteeTemp objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeBackGuaranteeTemp objects.</returns>
		protected static EntityList<ChargeBackGuaranteeTemp> GetChargeBackGuaranteeTemps(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeBackGuaranteeTemps(string.Empty, where, parameters, ChargeBackGuaranteeTemp.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeBackGuaranteeTemp objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ChargeBackGuaranteeTemp objects.</returns>
		protected static EntityList<ChargeBackGuaranteeTemp> GetChargeBackGuaranteeTemps(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetChargeBackGuaranteeTemps(prefix, where, parameters, ChargeBackGuaranteeTemp.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ChargeBackGuaranteeTemp objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ChargeBackGuaranteeTemp objects.</returns>
		protected static EntityList<ChargeBackGuaranteeTemp> GetChargeBackGuaranteeTemps(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ChargeBackGuaranteeTemp.SelectFieldList + "FROM [dbo].[ChargeBackGuaranteeTemp] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ChargeBackGuaranteeTemp>(reader);
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
        protected static EntityList<ChargeBackGuaranteeTemp> GetChargeBackGuaranteeTemps(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ChargeBackGuaranteeTemp>(SelectFieldList, "FROM [dbo].[ChargeBackGuaranteeTemp] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class ChargeBackGuaranteeTempProperties
		{
			public const string ID = "ID";
			public const string HistoryID = "HistoryID";
			public const string PrintID = "PrintID";
			public const string RealPay = "RealPay";
			public const string Remark = "Remark";
			public const string GUID = "GUID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"HistoryID" , "int:"},
    			 {"PrintID" , "int:"},
    			 {"RealPay" , "decimal:"},
    			 {"Remark" , "string:"},
    			 {"GUID" , "string:"},
            };
		}
		#endregion
	}
}
