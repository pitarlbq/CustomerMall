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
	/// This object represents the properties and methods of a Wechat_ZhuangXiu.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_ZhuangXiu 
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
		private int _zXMonth = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ZXMonth
		{
			[DebuggerStepThrough()]
			get { return this._zXMonth; }
			set 
			{
				if (this._zXMonth != value) 
				{
					this._zXMonth = value;
					this.IsDirty = true;	
					OnPropertyChanged("ZXMonth");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sGFDW = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SGFDW
		{
			[DebuggerStepThrough()]
			get { return this._sGFDW; }
			set 
			{
				if (this._sGFDW != value) 
				{
					this._sGFDW = value;
					this.IsDirty = true;	
					OnPropertyChanged("SGFDW");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sGFFZR = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SGFFZR
		{
			[DebuggerStepThrough()]
			get { return this._sGFFZR; }
			set 
			{
				if (this._sGFFZR != value) 
				{
					this._sGFFZR = value;
					this.IsDirty = true;	
					OnPropertyChanged("SGFFZR");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sGFLXDH = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SGFLXDH
		{
			[DebuggerStepThrough()]
			get { return this._sGFLXDH; }
			set 
			{
				if (this._sGFLXDH != value) 
				{
					this._sGFLXDH = value;
					this.IsDirty = true;	
					OnPropertyChanged("SGFLXDH");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _zXXM = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ZXXM
		{
			[DebuggerStepThrough()]
			get { return this._zXXM; }
			set 
			{
				if (this._zXXM != value) 
				{
					this._zXXM = value;
					this.IsDirty = true;	
					OnPropertyChanged("ZXXM");
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
	[ZXMonth] int,
	[SGFDW] nvarchar(50),
	[SGFFZR] nvarchar(50),
	[SGFLXDH] nvarchar(50),
	[ZXXM] nvarchar(500),
	[OpenID] nvarchar(500),
	[AddTime] datetime
);

INSERT INTO [dbo].[Wechat_ZhuangXiu] (
	[Wechat_ZhuangXiu].[ZXMonth],
	[Wechat_ZhuangXiu].[SGFDW],
	[Wechat_ZhuangXiu].[SGFFZR],
	[Wechat_ZhuangXiu].[SGFLXDH],
	[Wechat_ZhuangXiu].[ZXXM],
	[Wechat_ZhuangXiu].[OpenID],
	[Wechat_ZhuangXiu].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ZXMonth],
	INSERTED.[SGFDW],
	INSERTED.[SGFFZR],
	INSERTED.[SGFLXDH],
	INSERTED.[ZXXM],
	INSERTED.[OpenID],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@ZXMonth,
	@SGFDW,
	@SGFFZR,
	@SGFLXDH,
	@ZXXM,
	@OpenID,
	@AddTime 
); 

SELECT 
	[ID],
	[ZXMonth],
	[SGFDW],
	[SGFFZR],
	[SGFLXDH],
	[ZXXM],
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
	[ZXMonth] int,
	[SGFDW] nvarchar(50),
	[SGFFZR] nvarchar(50),
	[SGFLXDH] nvarchar(50),
	[ZXXM] nvarchar(500),
	[OpenID] nvarchar(500),
	[AddTime] datetime
);

UPDATE [dbo].[Wechat_ZhuangXiu] SET 
	[Wechat_ZhuangXiu].[ZXMonth] = @ZXMonth,
	[Wechat_ZhuangXiu].[SGFDW] = @SGFDW,
	[Wechat_ZhuangXiu].[SGFFZR] = @SGFFZR,
	[Wechat_ZhuangXiu].[SGFLXDH] = @SGFLXDH,
	[Wechat_ZhuangXiu].[ZXXM] = @ZXXM,
	[Wechat_ZhuangXiu].[OpenID] = @OpenID,
	[Wechat_ZhuangXiu].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[ZXMonth],
	INSERTED.[SGFDW],
	INSERTED.[SGFFZR],
	INSERTED.[SGFLXDH],
	INSERTED.[ZXXM],
	INSERTED.[OpenID],
	INSERTED.[AddTime]
into @table
WHERE 
	[Wechat_ZhuangXiu].[ID] = @ID

SELECT 
	[ID],
	[ZXMonth],
	[SGFDW],
	[SGFFZR],
	[SGFLXDH],
	[ZXXM],
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
DELETE FROM [dbo].[Wechat_ZhuangXiu]
WHERE 
	[Wechat_ZhuangXiu].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_ZhuangXiu() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_ZhuangXiu(this.ID));
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
	[Wechat_ZhuangXiu].[ID],
	[Wechat_ZhuangXiu].[ZXMonth],
	[Wechat_ZhuangXiu].[SGFDW],
	[Wechat_ZhuangXiu].[SGFFZR],
	[Wechat_ZhuangXiu].[SGFLXDH],
	[Wechat_ZhuangXiu].[ZXXM],
	[Wechat_ZhuangXiu].[OpenID],
	[Wechat_ZhuangXiu].[AddTime]
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
                return "Wechat_ZhuangXiu";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_ZhuangXiu into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="zXMonth">zXMonth</param>
		/// <param name="sGFDW">sGFDW</param>
		/// <param name="sGFFZR">sGFFZR</param>
		/// <param name="sGFLXDH">sGFLXDH</param>
		/// <param name="zXXM">zXXM</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		public static void InsertWechat_ZhuangXiu(int @zXMonth, string @sGFDW, string @sGFFZR, string @sGFLXDH, string @zXXM, string @openID, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_ZhuangXiu(@zXMonth, @sGFDW, @sGFFZR, @sGFLXDH, @zXXM, @openID, @addTime, helper);
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
		/// Insert a Wechat_ZhuangXiu into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="zXMonth">zXMonth</param>
		/// <param name="sGFDW">sGFDW</param>
		/// <param name="sGFFZR">sGFFZR</param>
		/// <param name="sGFLXDH">sGFLXDH</param>
		/// <param name="zXXM">zXXM</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_ZhuangXiu(int @zXMonth, string @sGFDW, string @sGFFZR, string @sGFLXDH, string @zXXM, string @openID, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ZXMonth] int,
	[SGFDW] nvarchar(50),
	[SGFFZR] nvarchar(50),
	[SGFLXDH] nvarchar(50),
	[ZXXM] nvarchar(500),
	[OpenID] nvarchar(500),
	[AddTime] datetime
);

INSERT INTO [dbo].[Wechat_ZhuangXiu] (
	[Wechat_ZhuangXiu].[ZXMonth],
	[Wechat_ZhuangXiu].[SGFDW],
	[Wechat_ZhuangXiu].[SGFFZR],
	[Wechat_ZhuangXiu].[SGFLXDH],
	[Wechat_ZhuangXiu].[ZXXM],
	[Wechat_ZhuangXiu].[OpenID],
	[Wechat_ZhuangXiu].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ZXMonth],
	INSERTED.[SGFDW],
	INSERTED.[SGFFZR],
	INSERTED.[SGFLXDH],
	INSERTED.[ZXXM],
	INSERTED.[OpenID],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@ZXMonth,
	@SGFDW,
	@SGFFZR,
	@SGFLXDH,
	@ZXXM,
	@OpenID,
	@AddTime 
); 

SELECT 
	[ID],
	[ZXMonth],
	[SGFDW],
	[SGFFZR],
	[SGFLXDH],
	[ZXXM],
	[OpenID],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ZXMonth", EntityBase.GetDatabaseValue(@zXMonth)));
			parameters.Add(new SqlParameter("@SGFDW", EntityBase.GetDatabaseValue(@sGFDW)));
			parameters.Add(new SqlParameter("@SGFFZR", EntityBase.GetDatabaseValue(@sGFFZR)));
			parameters.Add(new SqlParameter("@SGFLXDH", EntityBase.GetDatabaseValue(@sGFLXDH)));
			parameters.Add(new SqlParameter("@ZXXM", EntityBase.GetDatabaseValue(@zXXM)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_ZhuangXiu into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="zXMonth">zXMonth</param>
		/// <param name="sGFDW">sGFDW</param>
		/// <param name="sGFFZR">sGFFZR</param>
		/// <param name="sGFLXDH">sGFLXDH</param>
		/// <param name="zXXM">zXXM</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateWechat_ZhuangXiu(int @iD, int @zXMonth, string @sGFDW, string @sGFFZR, string @sGFLXDH, string @zXXM, string @openID, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_ZhuangXiu(@iD, @zXMonth, @sGFDW, @sGFFZR, @sGFLXDH, @zXXM, @openID, @addTime, helper);
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
		/// Updates a Wechat_ZhuangXiu into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="zXMonth">zXMonth</param>
		/// <param name="sGFDW">sGFDW</param>
		/// <param name="sGFFZR">sGFFZR</param>
		/// <param name="sGFLXDH">sGFLXDH</param>
		/// <param name="zXXM">zXXM</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_ZhuangXiu(int @iD, int @zXMonth, string @sGFDW, string @sGFFZR, string @sGFLXDH, string @zXXM, string @openID, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ZXMonth] int,
	[SGFDW] nvarchar(50),
	[SGFFZR] nvarchar(50),
	[SGFLXDH] nvarchar(50),
	[ZXXM] nvarchar(500),
	[OpenID] nvarchar(500),
	[AddTime] datetime
);

UPDATE [dbo].[Wechat_ZhuangXiu] SET 
	[Wechat_ZhuangXiu].[ZXMonth] = @ZXMonth,
	[Wechat_ZhuangXiu].[SGFDW] = @SGFDW,
	[Wechat_ZhuangXiu].[SGFFZR] = @SGFFZR,
	[Wechat_ZhuangXiu].[SGFLXDH] = @SGFLXDH,
	[Wechat_ZhuangXiu].[ZXXM] = @ZXXM,
	[Wechat_ZhuangXiu].[OpenID] = @OpenID,
	[Wechat_ZhuangXiu].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[ZXMonth],
	INSERTED.[SGFDW],
	INSERTED.[SGFFZR],
	INSERTED.[SGFLXDH],
	INSERTED.[ZXXM],
	INSERTED.[OpenID],
	INSERTED.[AddTime]
into @table
WHERE 
	[Wechat_ZhuangXiu].[ID] = @ID

SELECT 
	[ID],
	[ZXMonth],
	[SGFDW],
	[SGFFZR],
	[SGFLXDH],
	[ZXXM],
	[OpenID],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ZXMonth", EntityBase.GetDatabaseValue(@zXMonth)));
			parameters.Add(new SqlParameter("@SGFDW", EntityBase.GetDatabaseValue(@sGFDW)));
			parameters.Add(new SqlParameter("@SGFFZR", EntityBase.GetDatabaseValue(@sGFFZR)));
			parameters.Add(new SqlParameter("@SGFLXDH", EntityBase.GetDatabaseValue(@sGFLXDH)));
			parameters.Add(new SqlParameter("@ZXXM", EntityBase.GetDatabaseValue(@zXXM)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_ZhuangXiu from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_ZhuangXiu(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_ZhuangXiu(@iD, helper);
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
		/// Deletes a Wechat_ZhuangXiu from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_ZhuangXiu(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_ZhuangXiu]
WHERE 
	[Wechat_ZhuangXiu].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_ZhuangXiu object.
		/// </summary>
		/// <returns>The newly created Wechat_ZhuangXiu object.</returns>
		public static Wechat_ZhuangXiu CreateWechat_ZhuangXiu()
		{
			return InitializeNew<Wechat_ZhuangXiu>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_ZhuangXiu by a Wechat_ZhuangXiu's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_ZhuangXiu</returns>
		public static Wechat_ZhuangXiu GetWechat_ZhuangXiu(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_ZhuangXiu.SelectFieldList + @"
FROM [dbo].[Wechat_ZhuangXiu] 
WHERE 
	[Wechat_ZhuangXiu].[ID] = @ID " + Wechat_ZhuangXiu.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_ZhuangXiu>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_ZhuangXiu by a Wechat_ZhuangXiu's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_ZhuangXiu</returns>
		public static Wechat_ZhuangXiu GetWechat_ZhuangXiu(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_ZhuangXiu.SelectFieldList + @"
FROM [dbo].[Wechat_ZhuangXiu] 
WHERE 
	[Wechat_ZhuangXiu].[ID] = @ID " + Wechat_ZhuangXiu.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_ZhuangXiu>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ZhuangXiu objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_ZhuangXiu objects.</returns>
		public static EntityList<Wechat_ZhuangXiu> GetWechat_ZhuangXius()
		{
			string commandText = @"
SELECT " + Wechat_ZhuangXiu.SelectFieldList + "FROM [dbo].[Wechat_ZhuangXiu] " + Wechat_ZhuangXiu.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_ZhuangXiu>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_ZhuangXiu objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_ZhuangXiu objects.</returns>
        public static EntityList<Wechat_ZhuangXiu> GetWechat_ZhuangXius(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_ZhuangXiu>(SelectFieldList, "FROM [dbo].[Wechat_ZhuangXiu]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_ZhuangXiu objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_ZhuangXiu objects.</returns>
        public static EntityList<Wechat_ZhuangXiu> GetWechat_ZhuangXius(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_ZhuangXiu>(SelectFieldList, "FROM [dbo].[Wechat_ZhuangXiu]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_ZhuangXiu objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_ZhuangXiu objects.</returns>
		protected static EntityList<Wechat_ZhuangXiu> GetWechat_ZhuangXius(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_ZhuangXius(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ZhuangXiu objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ZhuangXiu objects.</returns>
		protected static EntityList<Wechat_ZhuangXiu> GetWechat_ZhuangXius(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_ZhuangXius(string.Empty, where, parameters, Wechat_ZhuangXiu.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ZhuangXiu objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ZhuangXiu objects.</returns>
		protected static EntityList<Wechat_ZhuangXiu> GetWechat_ZhuangXius(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_ZhuangXius(prefix, where, parameters, Wechat_ZhuangXiu.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ZhuangXiu objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ZhuangXiu objects.</returns>
		protected static EntityList<Wechat_ZhuangXiu> GetWechat_ZhuangXius(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_ZhuangXius(string.Empty, where, parameters, Wechat_ZhuangXiu.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ZhuangXiu objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ZhuangXiu objects.</returns>
		protected static EntityList<Wechat_ZhuangXiu> GetWechat_ZhuangXius(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_ZhuangXius(prefix, where, parameters, Wechat_ZhuangXiu.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ZhuangXiu objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_ZhuangXiu objects.</returns>
		protected static EntityList<Wechat_ZhuangXiu> GetWechat_ZhuangXius(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_ZhuangXiu.SelectFieldList + "FROM [dbo].[Wechat_ZhuangXiu] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_ZhuangXiu>(reader);
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
        protected static EntityList<Wechat_ZhuangXiu> GetWechat_ZhuangXius(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_ZhuangXiu>(SelectFieldList, "FROM [dbo].[Wechat_ZhuangXiu] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_ZhuangXiu objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_ZhuangXiuCount()
        {
            return GetWechat_ZhuangXiuCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_ZhuangXiu objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_ZhuangXiuCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_ZhuangXiu] " + where;

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
		public static partial class Wechat_ZhuangXiu_Properties
		{
			public const string ID = "ID";
			public const string ZXMonth = "ZXMonth";
			public const string SGFDW = "SGFDW";
			public const string SGFFZR = "SGFFZR";
			public const string SGFLXDH = "SGFLXDH";
			public const string ZXXM = "ZXXM";
			public const string OpenID = "OpenID";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ZXMonth" , "int:"},
    			 {"SGFDW" , "string:"},
    			 {"SGFFZR" , "string:"},
    			 {"SGFLXDH" , "string:"},
    			 {"ZXXM" , "string:"},
    			 {"OpenID" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
