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
	/// This object represents the properties and methods of a Wechat_YanShou.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_YanShou 
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
		[DataObjectField(true, false, false)]
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
		private decimal _sBDS = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal SBDS
		{
			[DebuggerStepThrough()]
			get { return this._sBDS; }
			set 
			{
				if (this._sBDS != value) 
				{
					this._sBDS = value;
					this.IsDirty = true;	
					OnPropertyChanged("SBDS");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _dBDS = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal DBDS
		{
			[DebuggerStepThrough()]
			get { return this._dBDS; }
			set 
			{
				if (this._dBDS != value) 
				{
					this._dBDS = value;
					this.IsDirty = true;	
					OnPropertyChanged("DBDS");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _qBDS = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal QBDS
		{
			[DebuggerStepThrough()]
			get { return this._qBDS; }
			set 
			{
				if (this._qBDS != value) 
				{
					this._qBDS = value;
					this.IsDirty = true;	
					OnPropertyChanged("QBDS");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _ySResult = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string YSResult
		{
			[DebuggerStepThrough()]
			get { return this._ySResult; }
			set 
			{
				if (this._ySResult != value) 
				{
					this._ySResult = value;
					this.IsDirty = true;	
					OnPropertyChanged("YSResult");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _ySContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string YSContent
		{
			[DebuggerStepThrough()]
			get { return this._ySContent; }
			set 
			{
				if (this._ySContent != value) 
				{
					this._ySContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("YSContent");
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
		[DataObjectField(false, false, false)]
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
	[SBDS] decimal(18, 4),
	[DBDS] decimal(18, 4),
	[QBDS] decimal(18, 4),
	[YSResult] nvarchar(50),
	[YSContent] ntext,
	[OpenID] nvarchar(200),
	[AddTime] datetime
);

INSERT INTO [dbo].[Wechat_YanShou] (
	[Wechat_YanShou].[ID],
	[Wechat_YanShou].[SBDS],
	[Wechat_YanShou].[DBDS],
	[Wechat_YanShou].[QBDS],
	[Wechat_YanShou].[YSResult],
	[Wechat_YanShou].[YSContent],
	[Wechat_YanShou].[OpenID],
	[Wechat_YanShou].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[SBDS],
	INSERTED.[DBDS],
	INSERTED.[QBDS],
	INSERTED.[YSResult],
	INSERTED.[YSContent],
	INSERTED.[OpenID],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@ID,
	@SBDS,
	@DBDS,
	@QBDS,
	@YSResult,
	@YSContent,
	@OpenID,
	@AddTime 
); 

SELECT 
	[ID],
	[SBDS],
	[DBDS],
	[QBDS],
	[YSResult],
	[YSContent],
	[OpenID],
	[AddTime] 
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
	[SBDS] decimal(18, 4),
	[DBDS] decimal(18, 4),
	[QBDS] decimal(18, 4),
	[YSResult] nvarchar(50),
	[YSContent] ntext,
	[OpenID] nvarchar(200),
	[AddTime] datetime
);

UPDATE [dbo].[Wechat_YanShou] SET 
	[Wechat_YanShou].[SBDS] = @SBDS,
	[Wechat_YanShou].[DBDS] = @DBDS,
	[Wechat_YanShou].[QBDS] = @QBDS,
	[Wechat_YanShou].[YSResult] = @YSResult,
	[Wechat_YanShou].[YSContent] = @YSContent,
	[Wechat_YanShou].[OpenID] = @OpenID,
	[Wechat_YanShou].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[SBDS],
	INSERTED.[DBDS],
	INSERTED.[QBDS],
	INSERTED.[YSResult],
	INSERTED.[YSContent],
	INSERTED.[OpenID],
	INSERTED.[AddTime]
into @table
WHERE 
	[Wechat_YanShou].[ID] = @ID

SELECT 
	[ID],
	[SBDS],
	[DBDS],
	[QBDS],
	[YSResult],
	[YSContent],
	[OpenID],
	[AddTime] 
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
DELETE FROM [dbo].[Wechat_YanShou]
WHERE 
	[Wechat_YanShou].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_YanShou() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_YanShou(this.ID));
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
	[Wechat_YanShou].[ID],
	[Wechat_YanShou].[SBDS],
	[Wechat_YanShou].[DBDS],
	[Wechat_YanShou].[QBDS],
	[Wechat_YanShou].[YSResult],
	[Wechat_YanShou].[YSContent],
	[Wechat_YanShou].[OpenID],
	[Wechat_YanShou].[AddTime]
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
                return "Wechat_YanShou";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_YanShou into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="sBDS">sBDS</param>
		/// <param name="dBDS">dBDS</param>
		/// <param name="qBDS">qBDS</param>
		/// <param name="ySResult">ySResult</param>
		/// <param name="ySContent">ySContent</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		public static void InsertWechat_YanShou(int @iD, decimal @sBDS, decimal @dBDS, decimal @qBDS, string @ySResult, string @ySContent, string @openID, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_YanShou(@iD, @sBDS, @dBDS, @qBDS, @ySResult, @ySContent, @openID, @addTime, helper);
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
		/// Insert a Wechat_YanShou into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="sBDS">sBDS</param>
		/// <param name="dBDS">dBDS</param>
		/// <param name="qBDS">qBDS</param>
		/// <param name="ySResult">ySResult</param>
		/// <param name="ySContent">ySContent</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_YanShou(int @iD, decimal @sBDS, decimal @dBDS, decimal @qBDS, string @ySResult, string @ySContent, string @openID, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SBDS] decimal(18, 4),
	[DBDS] decimal(18, 4),
	[QBDS] decimal(18, 4),
	[YSResult] nvarchar(50),
	[YSContent] ntext,
	[OpenID] nvarchar(200),
	[AddTime] datetime
);

INSERT INTO [dbo].[Wechat_YanShou] (
	[Wechat_YanShou].[ID],
	[Wechat_YanShou].[SBDS],
	[Wechat_YanShou].[DBDS],
	[Wechat_YanShou].[QBDS],
	[Wechat_YanShou].[YSResult],
	[Wechat_YanShou].[YSContent],
	[Wechat_YanShou].[OpenID],
	[Wechat_YanShou].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[SBDS],
	INSERTED.[DBDS],
	INSERTED.[QBDS],
	INSERTED.[YSResult],
	INSERTED.[YSContent],
	INSERTED.[OpenID],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@ID,
	@SBDS,
	@DBDS,
	@QBDS,
	@YSResult,
	@YSContent,
	@OpenID,
	@AddTime 
); 

SELECT 
	[ID],
	[SBDS],
	[DBDS],
	[QBDS],
	[YSResult],
	[YSContent],
	[OpenID],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@SBDS", EntityBase.GetDatabaseValue(@sBDS)));
			parameters.Add(new SqlParameter("@DBDS", EntityBase.GetDatabaseValue(@dBDS)));
			parameters.Add(new SqlParameter("@QBDS", EntityBase.GetDatabaseValue(@qBDS)));
			parameters.Add(new SqlParameter("@YSResult", EntityBase.GetDatabaseValue(@ySResult)));
			parameters.Add(new SqlParameter("@YSContent", EntityBase.GetDatabaseValue(@ySContent)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_YanShou into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="sBDS">sBDS</param>
		/// <param name="dBDS">dBDS</param>
		/// <param name="qBDS">qBDS</param>
		/// <param name="ySResult">ySResult</param>
		/// <param name="ySContent">ySContent</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateWechat_YanShou(int @iD, decimal @sBDS, decimal @dBDS, decimal @qBDS, string @ySResult, string @ySContent, string @openID, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_YanShou(@iD, @sBDS, @dBDS, @qBDS, @ySResult, @ySContent, @openID, @addTime, helper);
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
		/// Updates a Wechat_YanShou into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="sBDS">sBDS</param>
		/// <param name="dBDS">dBDS</param>
		/// <param name="qBDS">qBDS</param>
		/// <param name="ySResult">ySResult</param>
		/// <param name="ySContent">ySContent</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_YanShou(int @iD, decimal @sBDS, decimal @dBDS, decimal @qBDS, string @ySResult, string @ySContent, string @openID, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SBDS] decimal(18, 4),
	[DBDS] decimal(18, 4),
	[QBDS] decimal(18, 4),
	[YSResult] nvarchar(50),
	[YSContent] ntext,
	[OpenID] nvarchar(200),
	[AddTime] datetime
);

UPDATE [dbo].[Wechat_YanShou] SET 
	[Wechat_YanShou].[SBDS] = @SBDS,
	[Wechat_YanShou].[DBDS] = @DBDS,
	[Wechat_YanShou].[QBDS] = @QBDS,
	[Wechat_YanShou].[YSResult] = @YSResult,
	[Wechat_YanShou].[YSContent] = @YSContent,
	[Wechat_YanShou].[OpenID] = @OpenID,
	[Wechat_YanShou].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[SBDS],
	INSERTED.[DBDS],
	INSERTED.[QBDS],
	INSERTED.[YSResult],
	INSERTED.[YSContent],
	INSERTED.[OpenID],
	INSERTED.[AddTime]
into @table
WHERE 
	[Wechat_YanShou].[ID] = @ID

SELECT 
	[ID],
	[SBDS],
	[DBDS],
	[QBDS],
	[YSResult],
	[YSContent],
	[OpenID],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@SBDS", EntityBase.GetDatabaseValue(@sBDS)));
			parameters.Add(new SqlParameter("@DBDS", EntityBase.GetDatabaseValue(@dBDS)));
			parameters.Add(new SqlParameter("@QBDS", EntityBase.GetDatabaseValue(@qBDS)));
			parameters.Add(new SqlParameter("@YSResult", EntityBase.GetDatabaseValue(@ySResult)));
			parameters.Add(new SqlParameter("@YSContent", EntityBase.GetDatabaseValue(@ySContent)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_YanShou from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_YanShou(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_YanShou(@iD, helper);
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
		/// Deletes a Wechat_YanShou from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_YanShou(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_YanShou]
WHERE 
	[Wechat_YanShou].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_YanShou object.
		/// </summary>
		/// <returns>The newly created Wechat_YanShou object.</returns>
		public static Wechat_YanShou CreateWechat_YanShou()
		{
			return InitializeNew<Wechat_YanShou>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_YanShou by a Wechat_YanShou's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_YanShou</returns>
		public static Wechat_YanShou GetWechat_YanShou(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_YanShou.SelectFieldList + @"
FROM [dbo].[Wechat_YanShou] 
WHERE 
	[Wechat_YanShou].[ID] = @ID " + Wechat_YanShou.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_YanShou>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_YanShou by a Wechat_YanShou's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_YanShou</returns>
		public static Wechat_YanShou GetWechat_YanShou(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_YanShou.SelectFieldList + @"
FROM [dbo].[Wechat_YanShou] 
WHERE 
	[Wechat_YanShou].[ID] = @ID " + Wechat_YanShou.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_YanShou>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_YanShou objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_YanShou objects.</returns>
		public static EntityList<Wechat_YanShou> GetWechat_YanShous()
		{
			string commandText = @"
SELECT " + Wechat_YanShou.SelectFieldList + "FROM [dbo].[Wechat_YanShou] " + Wechat_YanShou.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_YanShou>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_YanShou objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_YanShou objects.</returns>
        public static EntityList<Wechat_YanShou> GetWechat_YanShous(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_YanShou>(SelectFieldList, "FROM [dbo].[Wechat_YanShou]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_YanShou objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_YanShou objects.</returns>
        public static EntityList<Wechat_YanShou> GetWechat_YanShous(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_YanShou>(SelectFieldList, "FROM [dbo].[Wechat_YanShou]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_YanShou objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_YanShou objects.</returns>
		protected static EntityList<Wechat_YanShou> GetWechat_YanShous(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_YanShous(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_YanShou objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_YanShou objects.</returns>
		protected static EntityList<Wechat_YanShou> GetWechat_YanShous(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_YanShous(string.Empty, where, parameters, Wechat_YanShou.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_YanShou objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_YanShou objects.</returns>
		protected static EntityList<Wechat_YanShou> GetWechat_YanShous(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_YanShous(prefix, where, parameters, Wechat_YanShou.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_YanShou objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_YanShou objects.</returns>
		protected static EntityList<Wechat_YanShou> GetWechat_YanShous(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_YanShous(string.Empty, where, parameters, Wechat_YanShou.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_YanShou objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_YanShou objects.</returns>
		protected static EntityList<Wechat_YanShou> GetWechat_YanShous(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_YanShous(prefix, where, parameters, Wechat_YanShou.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_YanShou objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_YanShou objects.</returns>
		protected static EntityList<Wechat_YanShou> GetWechat_YanShous(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_YanShou.SelectFieldList + "FROM [dbo].[Wechat_YanShou] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_YanShou>(reader);
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
        protected static EntityList<Wechat_YanShou> GetWechat_YanShous(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_YanShou>(SelectFieldList, "FROM [dbo].[Wechat_YanShou] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_YanShou objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_YanShouCount()
        {
            return GetWechat_YanShouCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_YanShou objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_YanShouCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_YanShou] " + where;

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
		public static partial class Wechat_YanShou_Properties
		{
			public const string ID = "ID";
			public const string SBDS = "SBDS";
			public const string DBDS = "DBDS";
			public const string QBDS = "QBDS";
			public const string YSResult = "YSResult";
			public const string YSContent = "YSContent";
			public const string OpenID = "OpenID";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"SBDS" , "decimal:"},
    			 {"DBDS" , "decimal:"},
    			 {"QBDS" , "decimal:"},
    			 {"YSResult" , "string:"},
    			 {"YSContent" , "string:"},
    			 {"OpenID" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
